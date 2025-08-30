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
    public partial class PnlUsuario : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }
        private List<Usuario> _usuarios;

        public PnlUsuario()
        {
            InitializeComponent();
        }

        public void CargarUsuarios()
        {
            _usuarios = Usuario.GetUsuarios();

            dgvUsuarios.DataSource = _usuarios;

            dgvUsuarios.Columns["Id"].Visible = false;
            dgvUsuarios.Columns["NombreCompleto"].Visible = false;
            dgvUsuarios.Columns["IdTipoUsuario"].Visible = false;
            dgvUsuarios.Columns["DescripcionTipoUsuario"].HeaderText = "Tipo de Usuario";
        }


        private void FastFilter()
        {
            if (_usuarios == null) return;

            List<Usuario> usuariosFiltrados = _usuarios;

            //  Filtramos primero por el nombre completo

            if (!string.IsNullOrWhiteSpace(tsTxtNombre.Text))
            {
                usuariosFiltrados = _usuarios.Where(u => u.NombreCompleto.Contains(tsTxtNombre.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            dgvUsuarios.DataSource = usuariosFiltrados;
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            DlgUsuario dlg = new DlgUsuario();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.CurrentRow == null || dgvUsuarios.Rows.Count == 0) return;

                DlgUsuario dlg = new DlgUsuario();

                dlg.Usuario = dgvUsuarios.CurrentRow.DataBoundItem as Usuario;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarUsuario_Click - " + ex.Message, "Formulario Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.Rows.Count == 0) return;

            if (MessageBox.Show("El usuario seleccionado será eliminado, ¿deseas continuar?", "Formulario Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Usuario usuario = new Usuario { Id = int.Parse(dgvUsuarios.CurrentRow.Cells["Id"].Value.ToString()) };

                if (!usuario.Eliminar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar eliminar el usuario seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("El usuario seleccionado fue eliminado correctamente.", "Formulario Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuarios();
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void PnlUsuario_Load(object sender, EventArgs e) => CargarUsuarios();

        private void tsTxtNombre_TextChanged(object sender, EventArgs e) => FastFilter();

        private void btnVerDirecciones_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.Rows.Count == 0 || dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado una dirección. Seleccione una e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DlgUsuariosDirecciones dlg = new DlgUsuariosDirecciones();

            dlg.Usuario = dgvUsuarios.CurrentRow.DataBoundItem as Usuario;

            dlg.ShowDialog();
        }
    }
}

