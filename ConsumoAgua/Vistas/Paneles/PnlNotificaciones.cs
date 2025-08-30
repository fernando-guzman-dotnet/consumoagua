using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CalculoCobroAgua;
using Clases;
using NodaTime;
using NodaTime.Extensions;
using SAPA.Clases;
using SAPA.Reportes;
using SAPA.Vistas.Dialogos;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlNotificaciones : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }
        private DataTable _deudores { get; set; }

        public PnlNotificaciones()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void CargarNotificaciones()
        {
            _deudores = Reporte.GetDeudores();

            _deudores.Columns.Add("MesesAdeudo", typeof(int));

            foreach (DataRow fila in _deudores.Rows)
            {
                if (string.IsNullOrWhiteSpace(fila["PeriodoInicio"].ToString()) ||
                    string.IsNullOrWhiteSpace(fila["PeriodoFin"].ToString()))
                {
                    fila["MesesAdeudo"] = 0;
                    continue;
                }

                var periodoFechas = Period.Between(DateTime.Parse(fila["PeriodoInicio"].ToString()).ToLocalDateTime(),
                    DateTime.Parse(fila["PeriodoFin"].ToString()).ToLocalDateTime(), PeriodUnits.Months);

                fila["MesesAdeudo"] = periodoFechas.Months + 1;
            }

            dgvNotificaciones.DataSource = _deudores;

            dgvNotificaciones.Columns["NoContrato"].DefaultCellStyle.Format = "D10";
            dgvNotificaciones.Columns["PeriodoInicio"].DefaultCellStyle.Format = "MMMM yyyy";
            dgvNotificaciones.Columns["PeriodoFin"].DefaultCellStyle.Format = "MMMM yyyy";

            dgvNotificaciones.Columns["Usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNotificaciones.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }


        private void FastFilter()
        {

            IEnumerable<DataRow> deudoresFiltrados = _deudores.AsEnumerable();
            DataTable deudores = _deudores.Clone();

            //  Filtramos primero por No Contrato

            if (!string.IsNullOrWhiteSpace(tsTxtNoContrato.Text))
            {
                deudoresFiltrados = _deudores.AsEnumerable().Where(c => c.Field<int>("NoContrato").ToString().Contains(tsTxtNoContrato.Text, StringComparison.OrdinalIgnoreCase));
            }

            // Luego por dirección

            if (!string.IsNullOrWhiteSpace(tsTxtDireccion.Text))
            {
                deudoresFiltrados = deudoresFiltrados.Where(c => c.Field<string>("Direccion").Contains(tsTxtDireccion.Text, StringComparison.OrdinalIgnoreCase));
            }

            // Luego por meses

            int mesesAdeudo = 0;
            if (!string.IsNullOrWhiteSpace(tsTxtMesesAdeudo.Text) && int.TryParse(tsTxtMesesAdeudo.Text, out mesesAdeudo))
            {
                deudoresFiltrados = _deudores.AsEnumerable().Where(c => c.Field<int>("MesesAdeudo").ToString().Contains(tsTxtMesesAdeudo.Text, StringComparison.OrdinalIgnoreCase));
            }

            // Luego por monto

            decimal monto = 0m;
            if (!string.IsNullOrWhiteSpace(tsTxtMonto.Text) && decimal.TryParse(tsTxtMonto.Text, out monto))
            {
                deudoresFiltrados = deudoresFiltrados.Where(c => c.Field<decimal>("AdeudoTotal") == monto);
            }

            foreach (DataRow contrato in deudoresFiltrados.ToList())
            {
                deudores.Rows.Add(contrato.ItemArray);
            }

            dgvNotificaciones.DataSource = deudores;
        }


        private void PnlNotificaciones_Load(object sender, EventArgs e)
        {
            CargarNotificaciones();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dgvNotificaciones.SelectedRows.Count == 0 || dgvNotificaciones.CurrentRow == null) return;


            DateTime periodoInicio = DateTime.Parse(dgvNotificaciones.SelectedRows[0].Cells["PeriodoInicio"].Value.ToString());
            DateTime periodoFin = DateTime.Parse(dgvNotificaciones.SelectedRows[0].Cells["PeriodoFin"].Value.ToString());

            int noContrato = int.Parse(dgvNotificaciones.SelectedRows[0].Cells["NoContrato"].Value.ToString());

            var contrato = Contrato.GetContrato(noContrato);

            var cobroAgua = CobroAgua.GetContratoAdeudos(noContrato);

            if (cobroAgua.Tables["ERRORES"] != null)
            {
                MessageBox.Show(cobroAgua.Tables["ERRORES"].Rows[0]["ERROR"].ToString(), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var resumen = cobroAgua.Tables["RESUMEN"];

            List<AdeudoVista> adeudos = new List<AdeudoVista>();

            foreach (DataRow fila in cobroAgua.Tables["DETALLES"].Rows)
            {
                AdeudoVista adeudo = new AdeudoVista();
                adeudo = fila;

                if (adeudo.FechaPeriodo.Year > DateTime.Now.Year)
                    continue;

                adeudos.Add(adeudo);
            }

            RptTinguindinNotificacion rpt = new RptTinguindinNotificacion();

            DataSet dsReporte = new DataSet();
            dsReporte.Tables.Add(Organismo.Actual);

            rpt.SetDataSource(dsReporte);

            rpt.SetParameterValue("NombreCompletoUsuario", contrato.NombreUsuario);
            rpt.SetParameterValue("Domicilio", contrato.Direccion);
            rpt.SetParameterValue("TipoServicio", contrato.TipoContrato.Descripcion);
            rpt.SetParameterValue("PeriodoInicio", periodoInicio.ToString("MMMM yyyy").ToUpper());
            rpt.SetParameterValue("PeriodoFin", periodoFin.ToString("MMMM yyyy").ToUpper());
            rpt.SetParameterValue("TotalAgua", adeudos.Where(a => a.FechaPeriodo < Utilerias.GetFinPeriodoBimestral(DateTime.Now)).Sum(a => a.Agua).ToString("N2"));
            rpt.SetParameterValue("TotalAlcantarillado", adeudos.Where(a => a.FechaPeriodo < Utilerias.GetFinPeriodoBimestral(DateTime.Now)).Sum(a => a.Alcantarillado).ToString("N2"));
            rpt.SetParameterValue("TotalRecargos", adeudos.Where(a => a.FechaPeriodo < Utilerias.GetFinPeriodoBimestral(DateTime.Now)).Sum(a => a.Recargos).ToString("N2"));
            rpt.SetParameterValue("TotalIVA", adeudos.Where(a => a.FechaPeriodo < Utilerias.GetFinPeriodoBimestral(DateTime.Now)).Sum(a => a.IVA).ToString("N2"));
            rpt.SetParameterValue("Total", decimal.Parse(resumen.Rows[0]["AdeudoTotal"].ToString()).ToString("N2"));

            DlgVistaPreviaReporte dlg = new DlgVistaPreviaReporte();
            dlg.Reporte = rpt;
            dlg.ShowDialog();
        }

        private void genericEvent_TextChanged(object sender, EventArgs e) => FastFilter();
    }
}

