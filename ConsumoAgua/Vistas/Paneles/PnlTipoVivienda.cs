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
    public partial class PnlTipoVivienda : Form
    {
        public FrmPrincipal FrmPrincipal;
        private List<TipoVivienda> _tiposVivienda = new List<TipoVivienda>();

        public PnlTipoVivienda()
        {
            InitializeComponent();
        }

        public void CargarTiposVivienda()
        {
            _tiposVivienda = TipoVivienda.GetTiposVivienda();

            dgvTipoViviendas.DataSource = _tiposVivienda;

            dgvTipoViviendas.Columns["Id"].Visible = false;
            dgvTipoViviendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FastFilter(string descripcion)
        {
            var tiposViviendaFiltrados = _tiposVivienda.Where(t => t.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase));

            dgvTipoViviendas.DataSource = tiposViviendaFiltrados.ToList();

        }
        private void btnAgregarTipoVivienda_Click(object sender, EventArgs e)
        {
            DlgTipoVivienda dlg = new DlgTipoVivienda();
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarTiposVivienda();
            }
        }

        private void btnEditarTipoVivienda_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTipoViviendas.CurrentRow == null || dgvTipoViviendas.Rows.Count == 0) return;

                DlgTipoVivienda dlg = new DlgTipoVivienda();
                dlg.TipoVivienda = dgvTipoViviendas.CurrentRow.DataBoundItem as TipoVivienda;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarTiposVivienda();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("btnEdit_Click - " + ex.Message, "Formulario Panel_TipoVivienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarTipoVivienda_Click(object sender, EventArgs e)
        {
            if (dgvTipoViviendas.CurrentRow == null || dgvTipoViviendas.Rows.Count == 0) return;

            TipoVivienda tipoVivienda = dgvTipoViviendas.CurrentRow.DataBoundItem as TipoVivienda;

            if (MessageBox.Show("Se eliminará el tipo de vivienda seleccionado, ¿desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!tipoVivienda.Eliminar())
                {
                    MessageBox.Show(
                        "Hubo un problema al eliminar el tipo de vivienda seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("El tipo de vivienda seleccionado fue eliminado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTiposVivienda();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
        }

        private void PnlTipoVivienda_Load(object sender, EventArgs e) => CargarTiposVivienda();

        private void tsTxtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtDescripcion.Text);
    }
}

