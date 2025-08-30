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
    public partial class PnlBanco : Form
    {

        public FrmPrincipal FrmPrincipal;
        private List<Banco> _bancos;

        public PnlBanco()
        {
            InitializeComponent();
        }

        public void CargarBancos()
        {
            _bancos = Banco.GetBancos();

            dgvBancos.DataSource = _bancos;
           
            dgvBancos.Columns["Id"].Visible = false;

            dgvBancos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvBancos.Columns["Domicilio"].Visible = false;
            dgvBancos.Columns["Telefono"].Visible = false;
        }

        private void FastFilter(string nombre)
        {
            var bancosFiltrados = _bancos.Where(b => b.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            dgvBancos.DataSource = bancosFiltrados.ToList();
        }

        private void btnAgregarBanco_Click(object sender, EventArgs e)
        {
            DlgBanco dlg = new DlgBanco();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarBancos();
            }
        }

        private void btnEditarBanco_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBancos.CurrentRow == null || dgvBancos.Rows.Count == 0) return;

                DlgBanco dlg = new DlgBanco();

                dlg.Banco = dgvBancos.CurrentRow.DataBoundItem as Banco;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarBancos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarBanco_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarBanco_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBancos.CurrentRow == null || dgvBancos.Rows.Count == 0) return;

                Banco banco = dgvBancos.CurrentRow.DataBoundItem as Banco;

                if (Banco.EsUsado(banco.Id))
                {
                    MessageBox.Show(
                        "El banco seleccionado ya está en uso y no se puede eliminar. Si tiene problemas con registros duplicados y renombrarlos no ayuda, contacte al área de soporte de SAPA.",
                             this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Se eliminará el banco seleccionado, ¿desea continuar?", this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!banco.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar eliminar el banco seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("El banco seleccionado fue eliminado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarBancos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEliminarBanco_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void PnlBanco_Load(object sender, EventArgs e) => CargarBancos();
        
        private void tsTxtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtNombre.Text);
        
    }
}

