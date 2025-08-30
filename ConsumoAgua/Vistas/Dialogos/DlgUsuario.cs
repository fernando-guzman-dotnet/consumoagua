using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgUsuario : Form
    {

        public Usuario Usuario { get; set; } = new Usuario();
        private DataTable _colonias = new DataTable();
        private DataTable _calles = new DataTable();

        public DlgUsuario()
        {
            InitializeComponent();
        }


        private void CargarCmbTipoUsuario()
        {
            List<TipoUsuario> tipoUsuarios = TipoUsuario.GetTipoUsuarios();

            tipoUsuarios.Insert(0, new TipoUsuario {Id = 0, Descripcion = "[ -- Seleccione un tipo de usuario -- ]"});

            cmbTipoUsuario.DataSource = tipoUsuarios;

            cmbTipoUsuario.ValueMember = "Id";
            cmbTipoUsuario.DisplayMember = "Descripcion";
        }

        private void DlgUsuario_Load(object sender, EventArgs e)
        {
            CargarCmbTipoUsuario();

            if (Usuario.Id > 0)
            {
                cmbTipoUsuario.SelectedValue = Usuario.IdTipoUsuario;

                txtNombre.Text = Usuario.Nombre;
                txtApellidoPaterno.Text = Usuario.ApellidoPaterno;
                txtApellidoMaterno.Text = Usuario.ApellidoMaterno;
                txtRFC.Text = Usuario.RFC;
                txtTelefono.Text = Usuario.Telefono;
                txtCURP.Text = Usuario.CURP;
                txtEmail.Text = Usuario.Email;
                dtpFechaNacimiento.Value = Usuario.FechaNacimiento;
            }
        }




        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo nombre no puede estar vacío. Complete el campo e intente nuevamente.", "Formulario Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidoPaterno.Text))
            {
                MessageBox.Show("El campo apellido paterno no puede estar vacío. Complete el campo e intente nuevamente.", "Formulario Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidoMaterno.Text))
            {
                MessageBox.Show("El campo apellido materno no puede estar vacío. Complete el campo e intente nuevamente.", "Formulario Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGui()) return;

                Usuario.TipoUsuario = cmbTipoUsuario.SelectedItem as TipoUsuario;
                Usuario.Nombre = Utilerias.NormalizarEspacios(txtNombre.Text);
                Usuario.ApellidoPaterno = Utilerias.NormalizarEspacios(txtApellidoPaterno.Text);
                Usuario.ApellidoMaterno = Utilerias.NormalizarEspacios(txtApellidoMaterno.Text);
                Usuario.RFC = Utilerias.NormalizarEspacios(txtRFC.Text);
                Usuario.Telefono = txtTelefono.Text;
                Usuario.CURP = Utilerias.NormalizarEspacios(txtCURP.Text);
                Usuario.Email = Utilerias.NormalizarEspacios(txtEmail.Text);
                Usuario.FechaNacimiento = dtpFechaNacimiento.Value;

                bool actualizar = Usuario.Id > 0;

                if (actualizar)
                {
                    if (!Usuario.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar los datos del usuario. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del usuario fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }
                else
                {

                    if (!Usuario.Guardar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar guardar los datos del usuario. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del usuario fueron guardados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAceptar_Click - " + ex.Message, "Formulario Dialog_Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

    }
}

