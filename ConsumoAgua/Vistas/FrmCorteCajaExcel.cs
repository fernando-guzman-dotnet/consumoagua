using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.DataSets;
using SAPA.Reportes;

namespace SAPA.Vistas
{
    public partial class FrmCorteCajaExcel : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        private DataTable _tblCorteCaja { get; set; }

        public FrmCorteCajaExcel()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date + new TimeSpan(0, 0, 0);
            DateTime fechaFin = dtpFechaFin.Value.Date + new TimeSpan(23, 59, 59);

            if (fechaInicio.Date > fechaFin.Date)
            {
                MessageBox.Show(
                    "La fecha inicial es superior a la fecha final. Corrija las fechas e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _tblCorteCaja = Reporte.CorteCajaExcelByFechas(fechaInicio, fechaFin, (int)cmbCajas.SelectedValue);

            if (_tblCorteCaja.Rows.Count == 0)
            {
                dgvCorteCaja.DataSource = null;

                MessageBox.Show("No se encontraron registros dentro del rango de fechas especificado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = _tblCorteCaja.Rows.Cast<DataRow>().Sum(fila => decimal.Parse(fila["Total"].ToString()));

            DataRow nuevaFila = _tblCorteCaja.NewRow();

            nuevaFila["Total"] = total;

            _tblCorteCaja.Rows.Add(nuevaFila);

            dgvCorteCaja.DataSource = _tblCorteCaja;

            if (dgvCorteCaja.Rows.Count > 0)
            {
                dgvCorteCaja.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvCorteCaja.Columns["Folio"].DefaultCellStyle.Format = "D5";
                dgvCorteCaja.Columns["NoContrato"].DefaultCellStyle.Format = "D10";
            }

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            if (_tblCorteCaja == null || _tblCorteCaja.Rows.Count == 0)
            {
                txtTotalCorteCaja.Text = "0.00";
                txtTotalArqueo.Text = "0.00";
                txtDiferencia.Text = "0.00";
                return;
            }
            
            DateTime fechaInicio = dtpFechaInicio.Value.Date + new TimeSpan(0, 0, 0);
            DateTime fechaFin = dtpFechaFin.Value.Date + new TimeSpan(23, 59, 59);

            List<Arqueo> arqueos = Arqueo.GetArqueosByFecha(fechaInicio, fechaFin);

            decimal totalArqueo = 0m;

            // Monedas

            totalArqueo += arqueos.Sum(a => a.MonedasCincuentaCentavos) * 0.50m;
            totalArqueo += arqueos.Sum(a => a.MonedasUnPeso) * 1.00m;
            totalArqueo += arqueos.Sum(a => a.MonedasDosPesos) * 2.00m;
            totalArqueo += arqueos.Sum(a => a.MonedasCincoPesos) * 5.00m;
            totalArqueo += arqueos.Sum(a => a.MonedasDiezPesos) * 10.00m;

            // Billetes

            totalArqueo += arqueos.Sum(a => a.BilletesVeintePesos) * 20.00m;
            totalArqueo += arqueos.Sum(a => a.BilletesCincuentaPesos) * 50.00m;
            totalArqueo += arqueos.Sum(a => a.BilletesCienPesos) * 100.00m;
            totalArqueo += arqueos.Sum(a => a.BilletesDoscientosPesos) * 200.00m;
            totalArqueo += arqueos.Sum(a => a.BilletesQuinientosPesos) * 500.00m;
            totalArqueo += arqueos.Sum(a => a.BilletesMilPesos) * 1000.00m;

            // Otros

            totalArqueo += arqueos.Sum(a => a.Vauchers);
            totalArqueo += arqueos.Sum(a => a.ChequesTransferencias);

            var tblCorteCaja = Reporte.CorteCajaExcelByFechas(fechaInicio, fechaFin, (int)cmbCajas.SelectedValue);
            decimal totalCorteCaja = tblCorteCaja.Rows.Cast<DataRow>().Sum(fila => decimal.Parse(fila["Total"].ToString()));


            txtTotalArqueo.Text = totalArqueo.ToString("N2");
            txtTotalCorteCaja.Text = totalCorteCaja.ToString("N2");
            txtDiferencia.Text = (totalCorteCaja - totalArqueo).ToString("N2");


        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_tblCorteCaja == null || _tblCorteCaja.Rows.Count == 0) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel (*.xls)|*.xls";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _tblCorteCaja.ExportToExcel(dlg.FileName);
            }
        }


        private void CargarCmbCajas()
        {
            var cajas = Caja.GetCajas();

            if (cajas.Count == 0)
            {
                MessageBox.Show("No hay cajas registradas. Revise el catalogo de cajas e intente nuevamente. Si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCerrar_Click(null, null);
                return;
            }

            cajas.Insert(0, new Caja {Id = 0, Descripcion = "[ -- TODAS LAS CAJAS -- ]"});

            cmbCajas.DataSource = cajas;
            cmbCajas.DisplayMember = "Descripcion";
            cmbCajas.ValueMember = "Id";
        }

        private void FrmCorteCajaExcel_Load(object sender, EventArgs e) => CargarCmbCajas();
    }
}

