using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlLocalidad : Form
    {

        public FrmPrincipal FrmPrincipal;
        private List<Localidad> _localidades;

        public PnlLocalidad()
        {
            InitializeComponent();
        }

        public void CargarLocalidades()
        {
            _localidades = Localidad.GetLocalidades();

            dgvLocalidades.DataSource = _localidades;

            dgvLocalidades.Columns["Id"].Visible = false;
            dgvLocalidades.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FastFilter(string nombre)
        {
            var localidadesFiltradas = _localidades.Where(l => l.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            dgvLocalidades.DataSource = localidadesFiltradas.ToList();
        }

        private void btnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            try
            {
                DlgLocalidad dlg = new DlgLocalidad();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarLocalidades();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarLocalidad_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarLocalidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLocalidades.CurrentRow == null || dgvLocalidades.Rows.Count == 0) return;

                DlgLocalidad dlg = new DlgLocalidad();

                dlg.Localidad = dgvLocalidades.CurrentRow.DataBoundItem as Localidad;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarLocalidades();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarLocalidad_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void PnlBanco_Load(object sender, EventArgs e) => CargarLocalidades();

        private void tsTxtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtNombre.Text);

        private void btnAsociarColonia_Click(object sender, EventArgs e)
        {
            if (dgvLocalidades.CurrentRow == null || dgvLocalidades.Rows.Count == 0) return;

            DlgAsociarLocalidadesColonias dlg = new DlgAsociarLocalidadesColonias();

            dlg.Localidad = dgvLocalidades.CurrentRow.DataBoundItem as Localidad;

            dlg.ShowDialog();
        }
    }
}

