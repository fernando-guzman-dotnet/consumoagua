using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlSectores : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        private List<Sector> _sectores;

        public PnlSectores()
        {
            InitializeComponent();
        }

        private void PnlSectores_Load(object sender, EventArgs e) => CargarSectores();

        private void FastFilter(string descripcion)
        {
            var sectoresFiltrados = _sectores.Where(s => s.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase));

            dgvSectores.DataSource = sectoresFiltrados.ToList();
        }

        public void CargarSectores()
        {
            _sectores = Sector.GetSectores();

            dgvSectores.DataSource = _sectores;

            btnAsociarColonias.Enabled = dgvSectores.Rows.Count > 0;

            dgvSectores.Columns["Id"].Visible = false;
        }

        private void btnAsociarColonias_Click(object sender, EventArgs e)
        {
            if (dgvSectores.CurrentRow == null || dgvSectores.Rows.Count == 0) return;

            DlgAsociarSectoresColonias dlg = new DlgAsociarSectoresColonias();
            dlg.Sector = (Sector)dgvSectores.CurrentRow.DataBoundItem;

            if (dlg.ShowDialog() == DialogResult.OK)
                CargarSectores();
        }

        private void btnAgregarSector_Click(object sender, EventArgs e)
        {
            DlgAgregarSector dlg = new DlgAgregarSector();

            if (dlg.ShowDialog() == DialogResult.OK)
                CargarSectores();
        }

        private void tsmActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSectores.CurrentRow == null || dgvSectores.Rows.Count == 0) return;

                DlgAgregarSector dlg = new DlgAgregarSector();

                dlg.Sector = (Sector)dgvSectores.CurrentRow.DataBoundItem;


                if (dlg.ShowDialog() == DialogResult.OK)
                    CargarSectores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("tsmActualizar_Click " + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tstTxtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter(tstTxtDescripcion.Text);

        private void tsmBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSectores.CurrentRow == null || dgvSectores.Rows.Count == 0) return;

                Sector sector = (Sector)dgvSectores.CurrentRow.DataBoundItem;

                if (sector.TieneContrato())
                {
                    MessageBox.Show("No es posible eliminar el sector ya que está asignado a un contrato.", "Formulario Ver Sectores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Se eliminará el sector seleccionado, ¿desea continuar?", "Formulario Ver Sectores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!sector.Eliminar())
                    {
                        MessageBox.Show("Hubo un problema al intentar eliminar el sector seleccionado. Intente nuevamente, si el problema persiste contacta al área de soporte de SAPA");
                        return;
                    }

                    MessageBox.Show("Sector eliminado de forma correcta.", "Formulario Ver Sectores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarSectores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("tsmBorrar_Click  " + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PnlSectores_FormClosed(object sender, FormClosedEventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnEditarSector_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSectores.CurrentRow == null || dgvSectores.Rows.Count == 0) return;

                DlgAgregarSector dlg = new DlgAgregarSector();

                dlg.Sector = (Sector)dgvSectores.CurrentRow.DataBoundItem;


                if (dlg.ShowDialog() == DialogResult.OK)
                    CargarSectores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarSector_Click " + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarSector_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSectores.CurrentRow == null || dgvSectores.Rows.Count == 0) return;

                Sector sector = (Sector)dgvSectores.CurrentRow.DataBoundItem;

                if (sector.TieneContrato())
                {
                    MessageBox.Show("No es posible eliminar el sector ya que está asignado a un contrato.", "Formulario Ver Sectores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Se eliminará el sector seleccionado, ¿desea continuar?", "Formulario Ver Sectores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!sector.Eliminar())
                    {
                        MessageBox.Show("Hubo un problema al intentar eliminar el sector seleccionado. Intente nuevamente, si el problema persiste contacta al área de soporte de SAPA");
                        return;
                    }

                    MessageBox.Show("Sector eliminado de forma correcta.", "Formulario Ver Sectores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarSectores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEliminarSector_Click  " + ex, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
        
    }
}

