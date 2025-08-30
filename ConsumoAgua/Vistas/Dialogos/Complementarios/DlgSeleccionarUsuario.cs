using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgSeleccionarUsuario : Form
    {
        public Usuario Usuario { get; set; } = new Usuario();

        private DataTable _usuarios;

        public DlgSeleccionarUsuario()
        {
            InitializeComponent();
        }

        private void CargarUsuarios()
        {
            _usuarios = Usuario.GetUsuariosLikeNombre();

            dgvUsuarios.DataSource = _usuarios;

            dgvUsuarios.Columns["Id"].Visible = false;
            dgvUsuarios.Columns["Nombre"].Visible = false;
            dgvUsuarios.Columns["ApellidoPaterno"].Visible = false;
            dgvUsuarios.Columns["ApellidoMaterno"].Visible = false;
        }

        private void FastFilter()
        {
            IEnumerable<DataRow> usuariosFiltrados = _usuarios.AsEnumerable();
            DataTable tablaUsuarios = _usuarios.Clone();

            if (!string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                usuariosFiltrados = _usuarios.AsEnumerable().Where(c =>
                    c.Field<string>("Usuario").Contains(txtNombre.Text, StringComparison.OrdinalIgnoreCase));
            }

            foreach (DataRow empleado in usuariosFiltrados.ToList())
            {
                tablaUsuarios.Rows.Add(empleado.ItemArray);
            }

            dgvUsuarios.DataSource = tablaUsuarios;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e) => FastFilter();

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == -1 || e.RowIndex == -1) return;

                Usuario.Id = int.Parse(dgvUsuarios.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                Usuario.Nombre = dgvUsuarios.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                Usuario.ApellidoPaterno = dgvUsuarios.Rows[e.RowIndex].Cells["ApellidoPaterno"].Value.ToString();
                Usuario.ApellidoMaterno = dgvUsuarios.Rows[e.RowIndex].Cells["ApellidoMaterno"].Value.ToString();
                Usuario.FechaNacimiento = DateTime.Parse(dgvUsuarios.Rows[e.RowIndex].Cells["FechaNacimiento"].Value.ToString());
                Usuario.Email = dgvUsuarios.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                Usuario.RFC = dgvUsuarios.Rows[e.RowIndex].Cells["RFC"].Value.ToString();
                Usuario.CURP = dgvUsuarios.Rows[e.RowIndex].Cells["CURP"].Value.ToString();
                Usuario.Telefono = dgvUsuarios.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show("dataUsuarios_CellDoubleClick - " + ex.Message, "Formulario Dialog_SeleccionarUsuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario.Id = int.Parse(dgvUsuarios.CurrentRow.Cells["Id"].Value.ToString());
                Usuario.Nombre = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
                Usuario.ApellidoPaterno = dgvUsuarios.CurrentRow.Cells["ApellidoPaterno"].Value.ToString();
                Usuario.ApellidoMaterno = dgvUsuarios.CurrentRow.Cells["ApellidoMaterno"].Value.ToString();
                Usuario.FechaNacimiento = DateTime.Parse(dgvUsuarios.CurrentRow.Cells["FechaNacimiento"].Value.ToString());
                Usuario.Email = dgvUsuarios.CurrentRow.Cells["Email"].Value.ToString();
                Usuario.RFC = dgvUsuarios.CurrentRow.Cells["RFC"].Value.ToString();
                Usuario.CURP = dgvUsuarios.CurrentRow.Cells["CURP"].Value.ToString();
                Usuario.Telefono = dgvUsuarios.CurrentRow.Cells["Telefono"].Value.ToString();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAceptar_Click - " + ex.Message, "Formulario Dialog_SeleccionarUsuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                DlgUsuario dlg = new DlgUsuario();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnBuscarUsuario_Click - " + ex.Message, "Formulario Dialog_SeleccionarUsuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario.Id = int.Parse(dgvUsuarios.CurrentRow.Cells["Id"].Value.ToString());
                Usuario.Nombre = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
                Usuario.ApellidoPaterno = dgvUsuarios.CurrentRow.Cells["ApellidoPaterno"].Value.ToString();
                Usuario.ApellidoMaterno = dgvUsuarios.CurrentRow.Cells["ApellidoMaterno"].Value.ToString();
                Usuario.FechaNacimiento = DateTime.Parse(dgvUsuarios.CurrentRow.Cells["FechaNacimiento"].Value.ToString());
                Usuario.Email = dgvUsuarios.CurrentRow.Cells["Email"].Value.ToString();
                Usuario.RFC = dgvUsuarios.CurrentRow.Cells["RFC"].Value.ToString();
                Usuario.CURP = dgvUsuarios.CurrentRow.Cells["CURP"].Value.ToString();
                Usuario.Telefono = dgvUsuarios.CurrentRow.Cells["Telefono"].Value.ToString();

                DlgUsuario dlg = new DlgUsuario();

                dlg.Usuario = Usuario;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarUsuario_Click - " + ex.Message, "Formulario Dialog_SeleccionarUsuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dlg_SeleccionarUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
    }
}

