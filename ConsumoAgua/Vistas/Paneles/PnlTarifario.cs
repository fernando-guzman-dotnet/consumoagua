using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Clases;
using SAPA.Vistas.Dialogos;
using SAPA.Clases;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlTarifario : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        public PnlTarifario()
        {
            InitializeComponent();
        }

        public void CargarTarifas(int año)
        {
            dgvTarifas.DataSource = Reporte.GetCuotasTarifas(año);

            dgvTarifas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTarifas.Columns["Id"].Visible = false;
            dgvTarifas.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTarifas.Columns["Tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvTarifas.Columns["CantidadMensual"].HeaderText = "Cuota Fija Mensual";
            dgvTarifas.Columns["CantidadAnual"].HeaderText = "Cuota Fija Anual";


            foreach (DataGridViewColumn col in dgvTarifas.Columns)
            {
                if (col.ValueType == typeof(Decimal))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void PnlTarifario_Load(object sender, EventArgs e)
        {
            CargarTarifas(DateTime.Now.Year);
            CargarCmbAño();
        }

        private void CargarCmbAño(int selectedValue = -1) 
        {
            DataTable dtAñosDisponiblesTarifa = Reporte.GetAñosDisponiblesTarifas();
            cmbAño.DataSource = dtAñosDisponiblesTarifa;

            if (selectedValue != -1) cmbAño.SelectedValue = selectedValue;
        }

        private void btnEstablecerCuotaFija_Click(object sender, EventArgs e)
        {
            if (dgvTarifas.Rows.Count == 0 || dgvTarifas.CurrentRow == null)
                return;

            DlgTarifaFija dlg = new DlgTarifaFija();

            dlg.Tarifa = new Tarifa { Id = int.Parse(dgvTarifas.CurrentRow.Cells["Id"].Value.ToString()), Descripcion = dgvTarifas.CurrentRow.Cells["Descripcion"].Value.ToString() };
            dlg.AñoTarifaSeleccionada = int.Parse(dgvTarifas.CurrentRow.Cells["Año"].Value.ToString());

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarCmbAño(dlg.AñoTarifaSeleccionada);
            }
        }


        private void btnEstablecerCuotaMedida_Click(object sender, EventArgs e)
        {

            if (dgvTarifas.Rows.Count == 0 || dgvTarifas.CurrentRow == null)
                return;

            DlgTarifasMedidas dlg = new DlgTarifasMedidas();

            dlg.Tarifa = new Tarifa { Id = int.Parse(dgvTarifas.CurrentRow.Cells["Id"].Value.ToString()), Descripcion = dgvTarifas.CurrentRow.Cells["Descripcion"].Value.ToString() };
            dlg.AñoTarifaSeleccionada = int.Parse(dgvTarifas.CurrentRow.Cells["Año"].Value.ToString());

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarCmbAño();
            }
        }

        private void btnAgregarTarifaConcepto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad fue desactivada. Contacte al área de soporte de SAPA para habilitarla nuevamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

            if (dgvTarifas.Rows.Count == 0 || dgvTarifas.CurrentRow == null)
                return;

            DlgTarifasConceptos dlg = new DlgTarifasConceptos();

            dlg.Tarifa = dgvTarifas.CurrentRow.DataBoundItem as Tarifa;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarCmbAño();
            }

        }

        private void cmbAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAño.SelectedIndex == -1) return;

            CargarTarifas((int)cmbAño.SelectedValue);
        }
    }
}

