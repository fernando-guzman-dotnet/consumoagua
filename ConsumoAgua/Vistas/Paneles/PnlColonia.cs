using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlColonia : Form
    {
        public FrmPrincipal FrmPrincipal;

        private List<Colonia> _colonias = new List<Colonia>();

        public PnlColonia()
        {
            InitializeComponent();
        }

        public void CargarColonias()
        {
            _colonias = Colonia.GetColonias();

            dgvColonias.DataSource = _colonias;

            dgvColonias.Columns["Id"].Visible = false;
            dgvColonias.Columns["Codigo"].DefaultCellStyle.Format = "D4";
            dgvColonias.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvColonias.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FastFilter(string descripcion)
        {
            var coloniasFiltradas = _colonias.Where(c => c.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase));

            dgvColonias.DataSource = coloniasFiltradas.ToList();
        }

        private void DlgVerColonias_Load(object sender, EventArgs e)
        {
            CargarColonias();
        }

        private void btnAgregarColonia_Click(object sender, EventArgs e)
        {
            DlgAgregarColonia dlg = new DlgAgregarColonia();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarColonias();
            }
        }

        private void tsmBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                Colonia colonia = dgvColonias.CurrentRow.DataBoundItem as Colonia;

                if (colonia.TieneCalleAsignada())
                {
                    MessageBox.Show(
                        "No se puede eliminar la colonia seleccionada ya que se encuentra asignada a una calle.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Se eliminará el dato seleccionado, ¿desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!colonia.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar eliminar la colonia seleccionada. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Colonia eliminada correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarColonias();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("borrarToolStripMenuItem_Click - " + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsmActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvColonias.Rows.Count == 0 || dgvColonias.CurrentRow == null) return;

                DlgAgregarColonia dlg = new DlgAgregarColonia();

                dlg.Colonia = dgvColonias.CurrentRow.DataBoundItem as Colonia;
                
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarColonias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("actualizarToolStripMenuItem_Click - " + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsTxtColonia_TextChanged(object sender, EventArgs e) => FastFilter(tstTxtColonia.Text);

        private void btnAsociarCalles_Click(object sender, EventArgs e)
        {
            if (dgvColonias.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado una colonia. Seleccione una e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DlgAsociarColoniasCalles dlg = new DlgAsociarColoniasCalles();

            dlg.Colonia = dgvColonias.CurrentRow.DataBoundItem as Colonia;
            dlg.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnEditarColonia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvColonias.Rows.Count == 0 || dgvColonias.CurrentRow == null) return;

                DlgAgregarColonia dlg = new DlgAgregarColonia();

                dlg.Colonia = dgvColonias.CurrentRow.DataBoundItem as Colonia;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarColonias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarColonia_Click - " + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarColonia_Click(object sender, EventArgs e)
        {
            try
            {
                Colonia colonia = dgvColonias.CurrentRow.DataBoundItem as Colonia;

                if (colonia.TieneCalleAsignada())
                {
                    MessageBox.Show(
                        "No se puede eliminar la colonia seleccionada ya que se encuentra asignada a una calle.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Se eliminará el dato seleccionado, ¿desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!colonia.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar eliminar la colonia seleccionada. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Colonia eliminada correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarColonias();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEliminarColonia_Click - " + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

