using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlCalle : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }
        private List<Calle> _calles = new List<Calle>();

        public PnlCalle()
        {
            InitializeComponent();
        }

        private void PnlCalle_Load(object sender, EventArgs e) => CargarCalles();

        private void CargarCalles()
        {
            _calles = Calle.GetCalles();
            dgvCalles.DataSource = _calles;

            dgvCalles.Columns["Codigo"].DefaultCellStyle.Format = "D4";
            dgvCalles.Columns["Descripcion"].HeaderText = "Nombre";

            dgvCalles.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCalles.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvCalles.Columns["Id"].Visible = false;
            dgvCalles.Columns["CodigoPostal"].Visible = false;
        }

        private void FastFilter(string descripcion)
        {
            var callesFiltradas = _calles.Where(c => c.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase));

            dgvCalles.DataSource = callesFiltradas.ToList();
        }

        private void tsTxtCalle_TextChanged(object sender, EventArgs e) => FastFilter(tstTxtCalle.Text);

        private void PnlCalle_FormClosing(object sender, FormClosingEventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void tsmBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCalles.Rows.Count == 0 || dgvCalles.CurrentRow == null) return;

                Calle calle = dgvCalles.CurrentRow.DataBoundItem as Calle;

                if (MessageBox.Show("Se eliminará el dato seleccionado, ¿desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!calle.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar eliminar la calle seleccionada. Intente nuevamente, si el problema persiste contacta al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Calle eliminada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarCalles();
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
                if (dgvCalles.Rows.Count == 0 || dgvCalles.CurrentRow == null) return;

                DlgAgregarCalle dlg = new DlgAgregarCalle();

                dlg.Calle = dgvCalles.CurrentRow.DataBoundItem as Calle;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarCalles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("tsmActualizar_Click - " + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarCalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCalles.Rows.Count == 0 || dgvCalles.CurrentRow == null) return;

                DlgAgregarCalle dlg = new DlgAgregarCalle();

                dlg.Calle = dgvCalles.CurrentRow.DataBoundItem as Calle;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarCalles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarCalle_Click - " + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarCalle_Click(object sender, EventArgs e)
        {
            try
            {
                DlgAgregarCalle dlg = new DlgAgregarCalle();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarCalles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregarCalle_Click - " + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
    }
}


