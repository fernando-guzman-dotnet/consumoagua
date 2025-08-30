using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlTipoDescuento : Form
    {
        private List<TipoDescuento> _tipoDescuentos;
        public FrmPrincipal FrmPrincipal;

        public PnlTipoDescuento()
        {
            InitializeComponent();
        }

        private void PnlTipoDescuento_Load(object sender, EventArgs e)
        {
            CargarTiposDescuento();
        }

        private void CargarTiposDescuento()
        {
            _tipoDescuentos = TipoDescuento.GetTiposDescuento();
            dgvTipoDescuento.DataSource = _tipoDescuentos;

            dgvTipoDescuento.Columns["Id"].Visible = false;

        }

        private void FastFilter(string descripcion)
        {
            var tipoDescuentosFiltrados = _tipoDescuentos.Where(t => t.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase));
            dgvTipoDescuento.DataSource = tipoDescuentosFiltrados.ToList();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnAgregarTipoDescuento_Click(object sender, EventArgs e)
        {
            DlgTipoDescuento dlg = new DlgTipoDescuento();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarTiposDescuento();
            }
        }

        private void btnEditarTipoDescuento_Click(object sender, EventArgs e)
        {
            if (dgvTipoDescuento.CurrentRow == null || dgvTipoDescuento.Rows.Count == 0) return;
            DlgTipoDescuento dlg = new DlgTipoDescuento();

            dlg.TipoDescuento = dgvTipoDescuento.CurrentRow.DataBoundItem as TipoDescuento;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarTiposDescuento();
            }
        }

        private void btnEliminarTipoDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTipoDescuento.CurrentRow == null || dgvTipoDescuento.Rows.Count == 0) return;

                TipoDescuento tipoDescuento = dgvTipoDescuento.CurrentRow.DataBoundItem as TipoDescuento;

                if (MessageBox.Show("Se eliminará el tipo de descuento seleccionado, ¿desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!tipoDescuento.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un problema al intentar eliminar el tipo de descuento seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("El tipo de descuento seleccionado fue eliminado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTiposDescuento();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("borrarToolStripMenuItem_Click - " + ex.Message, "Formulario frmTipoDescuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsTxtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtDescripcion.Text);

        private void tsmBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTipoDescuento.CurrentRow == null || dgvTipoDescuento.Rows.Count == 0) return;

                TipoDescuento tipoDescuento = dgvTipoDescuento.CurrentRow.DataBoundItem as TipoDescuento;

                if (MessageBox.Show("Se eliminará el tipo de descuento seleccionado, ¿desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!tipoDescuento.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un problema al intentar eliminar el tipo de descuento seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("El tipo de descuento seleccionado fue eliminado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTiposDescuento();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("borrarToolStripMenuItem_Click - " + ex.Message, "Formulario frmTipoDescuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}




