using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlTarifa : Form
    {

        public FrmPrincipal FrmPrincipal { get; set; }

        private List<Tarifa> _tarifas = new List<Tarifa>();

        public PnlTarifa()
        {
            InitializeComponent();
        }

        public void CargarTarifas()
        {
            _tarifas = Tarifa.GetTarifas();

            dgvTarifas.DataSource = _tarifas;
            dgvTarifas.Columns["Id"].Visible = false;

            dgvTarifas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void FastFilter(string descripcion)
        {
            var tarifasFiltradas = _tarifas.Where(t => t.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase));

            dgvTarifas.DataSource = tarifasFiltradas.ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DlgTarifa dlg = new DlgTarifa();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarTarifas();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTarifas.CurrentRow == null || dgvTarifas.Rows.Count == 0) return;

                DlgTarifa dlg = new DlgTarifa();

                dlg.Tarifa = dgvTarifas.CurrentRow.DataBoundItem as Tarifa;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarTarifas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditar_Click - " + ex.Message, "Formulario Panel_Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTarifas.CurrentRow == null || dgvTarifas.Rows.Count == 0) return;

            Tarifa tarifa = dgvTarifas.CurrentRow.DataBoundItem as Tarifa;

            if (MessageBox.Show("Se eliminará la tarifa seleccionada, ¿desea continuar?", "Formulario Tarifa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!tarifa.Eliminar())
                {
                    MessageBox.Show(
                        "Hubo un problema al intentar eliminar la tarifa seleccionada. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("La tarifa fue eliminada correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTarifas();
            }

        }

        private void PnlTarifa_Load(object sender, EventArgs e) => CargarTarifas();

        private void tsTxtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtDescripcion.Text);

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
    }
}

