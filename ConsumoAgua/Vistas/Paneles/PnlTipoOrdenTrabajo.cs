using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlTipoOrdenTrabajo : Form
    {
        private List<TipoOrdenTrabajo> _tiposOrdenesTrabajo;
        public FrmPrincipal FrmPrincipal;

        public PnlTipoOrdenTrabajo()
        {
            InitializeComponent();
        }

        private void PnlTipoOrdenTrabajo_Load(object sender, EventArgs e)
        {
            CargarTiposOrdenesTrabajo();
        }

        private void CargarTiposOrdenesTrabajo()
        {
            _tiposOrdenesTrabajo = TipoOrdenTrabajo.GetTiposOrdenesTrabajo();
            dgvTiposOrdenesTrabajo.DataSource = _tiposOrdenesTrabajo;

            dgvTiposOrdenesTrabajo.Columns["Id"].Visible = false;

            dgvTiposOrdenesTrabajo.ClearSelection();

        }

        private void FastFilter(string descripcion)
        {
            var tipoDescuentosFiltrados = _tiposOrdenesTrabajo.Where(t => t.Tipo.Contains(descripcion, StringComparison.OrdinalIgnoreCase));
            dgvTiposOrdenesTrabajo.DataSource = tipoDescuentosFiltrados.ToList();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnAgregarTipoOrdenTrabajo_Click(object sender, EventArgs e)
        {
            DlgTipoOrdenTrabajo dlg = new DlgTipoOrdenTrabajo();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarTiposOrdenesTrabajo();
            }
        }

        private void btnEditarTipoOrdenTrabajo_Click(object sender, EventArgs e)
        {
            if (dgvTiposOrdenesTrabajo.CurrentRow == null || dgvTiposOrdenesTrabajo.Rows.Count == 0) return;

            DlgTipoOrdenTrabajo dlg = new DlgTipoOrdenTrabajo();

            dlg.TipoOrdenTrabajo = dgvTiposOrdenesTrabajo.CurrentRow.DataBoundItem as TipoOrdenTrabajo;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarTiposOrdenesTrabajo();
            }
        }

        private void btnEliminarTipoOrdenTrabajo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTiposOrdenesTrabajo.CurrentRow == null || dgvTiposOrdenesTrabajo.Rows.Count == 0) return;

                TipoOrdenTrabajo tipoOrdenTrabajo = dgvTiposOrdenesTrabajo.CurrentRow.DataBoundItem as TipoOrdenTrabajo;

                if (MessageBox.Show("Se eliminará el tipo de orden de trabajo seleccionado, ¿desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!tipoOrdenTrabajo.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un problema al intentar eliminar el tipo de orden de trabajo seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("El tipo de orden de trabajo seleccionado fue eliminado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTiposOrdenesTrabajo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("borrarToolStripMenuItem_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsTxtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtDescripcion.Text);

        private void tsmBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTiposOrdenesTrabajo.CurrentRow == null || dgvTiposOrdenesTrabajo.Rows.Count == 0) return;

                TipoOrdenTrabajo tipoOrdenTrabajo = dgvTiposOrdenesTrabajo.CurrentRow.DataBoundItem as TipoOrdenTrabajo;

                if (MessageBox.Show("Se eliminará el tipo de orden de trabajo seleccionado, ¿desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!tipoOrdenTrabajo.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un problema al intentar eliminar el tipo de orden de trabajo seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("El tipo de orden de trabajo seleccionado fue eliminado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTiposOrdenesTrabajo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("borrarToolStripMenuItem_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}




