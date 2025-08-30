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
    public partial class PnlMunicipio : Form
    {

        public FrmPrincipal FrmPrincipal;
        private List<Municipio> _municipios;

        public PnlMunicipio()
        {
            InitializeComponent();
        }

        public void CargarMunicipios()
        {
            _municipios = Municipio.GetMunicipios();

            dgvMunicipios.DataSource = _municipios;

            dgvMunicipios.Columns["Id"].Visible = false;
            dgvMunicipios.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void FastFilter(string nombre)
        {
            var municipiosFiltrados = _municipios.Where(m => m.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            dgvMunicipios.DataSource = municipiosFiltrados.ToList();
        }

        private void btnAgregarMunicipio_Click(object sender, EventArgs e)
        {
            try
            {
                DlgMunicipio dlg = new DlgMunicipio();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarMunicipios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregarMunicipio_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarMunicipio_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMunicipios.CurrentRow == null || dgvMunicipios.Rows.Count == 0) return;

                DlgMunicipio dlg = new DlgMunicipio();

                dlg.Municipio = dgvMunicipios.CurrentRow.DataBoundItem as Municipio;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarMunicipios();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarMunicipio_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void PnlMunicipios_Load(object sender, EventArgs e) => CargarMunicipios();

        private void tsTxtNombre_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtNombre.Text);

        private void btnAsociarLocalidad_Click(object sender, EventArgs e)
        {
            if (dgvMunicipios.CurrentRow == null || dgvMunicipios.Rows.Count == 0) return;

            DlgAsociarMunicipiosLocalidades dlg = new DlgAsociarMunicipiosLocalidades();

            dlg.Municipio = dgvMunicipios.CurrentRow.DataBoundItem as Municipio;

            dlg.ShowDialog();
        }
    }
}

