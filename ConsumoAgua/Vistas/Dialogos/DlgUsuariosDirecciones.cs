using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgUsuariosDirecciones : Form
    {
        public Usuario Usuario { get; set; } = new Usuario();

        public DlgUsuariosDirecciones()
        {
            InitializeComponent();
        }

        private void CargarUsuarioDirecciones(int idUsuario)
        {
            dgvUsuariosDirecciones.DataSource = UsuarioDireccion.GetByIdUsuario(idUsuario);

            if (dgvUsuariosDirecciones.Rows.Count == 0)
            {
                dgvUsuariosDirecciones.DataSource = null;
                return;
            }

            dgvUsuariosDirecciones.Columns["Id"].Visible = false;
            dgvUsuariosDirecciones.Columns["IdUsuario"].Visible = false;
        }

        private void DlgUsuariosDirecciones_Load(object sender, EventArgs e)
        {
            if (Usuario.Id > 0)
            {
                txtUsuario.Text = Usuario.NombreCompleto;
                CargarUsuarioDirecciones(Usuario.Id);
            }
        }

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            DlgAgregarUsuarioDireccion dlg = new DlgAgregarUsuarioDireccion();

            dlg.Usuario = Usuario;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarUsuarioDirecciones(Usuario.Id);
            }
        }

        private void btnEditarDireccion_Click(object sender, EventArgs e)
        {
            if (dgvUsuariosDirecciones.Rows.Count == 0 || dgvUsuariosDirecciones.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado una dirección. Seleccione una direccion e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DlgAgregarUsuarioDireccion dlg = new DlgAgregarUsuarioDireccion();

            dlg.Usuario = Usuario;
            dlg.UsuarioDireccion = dgvUsuariosDirecciones.CurrentRow.DataBoundItem as UsuarioDireccion;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarUsuarioDirecciones(Usuario.Id);
            }

        }

        private void btnHacerPrincipal_Click(object sender, EventArgs e)
        {
            if (dgvUsuariosDirecciones.Rows.Count == 0 || dgvUsuariosDirecciones.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado una dirección. Seleccione una direccion e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UsuarioDireccion usuarioDireccion = dgvUsuariosDirecciones.CurrentRow.DataBoundItem as UsuarioDireccion;

            if (!usuarioDireccion.HacerPredeterminada())
            {
                MessageBox.Show(
                    "Hubo un problema al intentar hacer la dirección seleccionada predeterminada. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(
                "La dirección seleccionado se ha marcado como la dirección predeterminada del usuario correctamente.",
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarUsuarioDirecciones(Usuario.Id);
        }
    }
}

