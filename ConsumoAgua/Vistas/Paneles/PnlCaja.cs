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
    public partial class PnlCaja : Form
    {

        public FrmPrincipal FrmPrincipal;
        private List<Caja> _cajas;

        public PnlCaja()
        {
            InitializeComponent();
        }

        public void CargarCajas()
        {
            _cajas = Caja.GetCajas();

            dgvCajas.DataSource = _cajas;
            dgvCajas.Columns["Id"].Visible = false;
            dgvCajas.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FastFilter(string nombre)
        {
            var cajasFiltradas = _cajas.Where(c => c.Descripcion.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            dgvCajas.DataSource = cajasFiltradas.ToList();
        }

        private void btnAgregarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                DlgCaja dlg = new DlgCaja();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarCajas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregarCaja_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCajas.CurrentRow == null || dgvCajas.Rows.Count == 0) return;

                DlgCaja dlg = new DlgCaja();

                dlg.Caja = dgvCajas.CurrentRow.DataBoundItem as Caja;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarCajas();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarCaja_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCajas.CurrentRow == null || dgvCajas.Rows.Count == 0) return;

                Caja caja = dgvCajas.CurrentRow.DataBoundItem as Caja;

                if (MessageBox.Show("Se eliminará la caja seleccionada, ¿desea continuar?", this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!caja.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar eliminar la caja seleccionada. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("La caja seleccionada fue eliminada correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarCajas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEliminarCaja_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void PnlCaja_Load(object sender, EventArgs e) => CargarCajas();

        private void tsTxtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtNombre.Text);
    }
}

