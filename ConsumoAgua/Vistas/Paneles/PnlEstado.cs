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
    public partial class PnlEstado : Form
    {

        public FrmPrincipal FrmPrincipal;
        private List<Estado> _estados;

        public PnlEstado()
        {
            InitializeComponent();
        }

        public void CargarEstados()
        {
            _estados = Estado.GetEstados();

            dgvEstados.DataSource = _estados;

            dgvEstados.Columns["Id"].Visible = false;
            dgvEstados.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FastFilter(string nombre)
        {
            var estadosFiltrados = _estados.Where(e => e.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            dgvEstados.DataSource = estadosFiltrados.ToList();
        }

        private void btnAgregarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                DlgEstado dlg = new DlgEstado();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarEstados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregarEstado_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEstados.CurrentRow == null || dgvEstados.Rows.Count == 0) return;

                DlgEstado dlg = new DlgEstado();

                dlg.Estado = dgvEstados.CurrentRow.DataBoundItem as Estado;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarEstados();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarEstado_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void PnlEstado_Load(object sender, EventArgs e) => CargarEstados();

        private void tsTxtNombre_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtNombre.Text);

        private void btnAsociarMunicipio_Click(object sender, EventArgs e)
        {
            if (dgvEstados.CurrentRow == null || dgvEstados.Rows.Count == 0) return;

            DlgAsociarEstadosMunicipios dlg = new DlgAsociarEstadosMunicipios();

            dlg.Estado = dgvEstados.CurrentRow.DataBoundItem as Estado;

            dlg.ShowDialog();
        }
    }
}

