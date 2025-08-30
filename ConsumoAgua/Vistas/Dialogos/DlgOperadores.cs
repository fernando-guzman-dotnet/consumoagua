using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SAPA.Vistas.Paneles;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgOperadores : Form
    {
        public Operador Operador { get; set; } = new Operador();

        public DlgOperadores()
        {
            InitializeComponent();
        }

        private void CargarSectores()
        {
            List<Sector> sectores = Sector.GetSectores();

            cmbSectores.DataSource = sectores;
            cmbSectores.DisplayMember = "Descripcion";
            cmbSectores.ValueMember = "Id";
        }

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El usuario no puede estar vacío. Complete el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // TODO: Validar si este usuario ya se usó anteriormente

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del operador no puede estar vacío. Complete el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido del operador no puede estar vacío. Complete el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (PnlContrasena.Enabled)
            {
                // Validamos el primer campo de contraseña y el otra no, igual si no la llenan, no coincidirán y más abajo tirará error.

                if (string.IsNullOrWhiteSpace(txtContrasena.Text))
                {
                    MessageBox.Show("La contraseña no puede estar vacía. Complete el campo e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!txtContrasena.Text.Equals(txtRepetirContrasena.Text))
                {
                    MessageBox.Show("Las contrañseñas ingresadas no coinciden. Escríbalas de nuevo e intente nuevamente..", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


            if (string.IsNullOrWhiteSpace(txtDomicilio.Text))
            {
                MessageBox.Show("El usuario no puede estar vacío. Complete el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (!ValidarGui()) return;

            bool actualizar = Operador.Id > 0;

            Operador.Usuario = txtUsuario.Text;

            if (PnlContrasena.Enabled)
            {
                Operador.Contrasena = encryptPass(txtContrasena.Text);
                var newToken = txtUsuario.Text + txtContrasena.Text + DateTime.Now.ToShortDateString();
                Operador.AuthToken = encryptPass(newToken);
            }
            else
            {
                Operador.Contrasena = "";
                Operador.AuthToken = "";
            }

            Operador.Nombre = Utilerias.NormalizarEspacios(txtNombre.Text);
            Operador.Apellido = Utilerias.NormalizarEspacios(txtApellido.Text);
            Operador.Domicilio = Utilerias.NormalizarEspacios(txtDomicilio.Text);
            Operador.IdSector = Int32.Parse(cmbSectores.SelectedValue.ToString());

            if (actualizar)
            {
                if (!Operador.Actualizar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar actualizar los datos del operador. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        "Formulario Operadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                MessageBox.Show("Operador actualizado correctamente", "Formulario Operadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                if (!Operador.Guardar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar guardar los datos del operador. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        "Formulario Operadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Operador agregado correctamente", "Formulario Operadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }

        private string encryptPass(string pass)
        {
            try
            {

                string vaa = pass;

                var apiKey = vaa;
                var apiSecret = "VVhwTmVVNHlVbWhPVjFsNVVrRTlQUT09";
                var key = Convert.FromBase64String(apiSecret);
                var provider = new System.Security.Cryptography.HMACSHA256(key);
                var hash = provider.ComputeHash(Encoding.UTF8.GetBytes(apiKey));
                var signature = Convert.ToBase64String(hash);

                return signature;
            }
            catch (Exception ex)
            {

                MessageBox.Show("encryptPass - " + ex.Message, "Formulario Operadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        private void chkModificarContrasena_CheckedChanged(object sender, EventArgs e) => PnlContrasena.Enabled = chkModificarContrasena.Checked;

        private void DlgOperadores_Load(object sender, EventArgs e)
        {
            CargarSectores();

            if (Operador.Id > 0)
            {
                chkModificarContrasena.Enabled = false;
                PnlContrasena.Enabled = false;

                txtContrasena.Text = "";
                txtRepetirContrasena.Text = "";

                txtUsuario.Text = Operador.Usuario;
                txtNombre.Text = Operador.Nombre;
                txtApellido.Text = Operador.Apellido;
                txtDomicilio.Text = Operador.Domicilio;
                cmbSectores.SelectedValue = Operador.IdSector;
            }
            else
            {
                chkModificarContrasena.Enabled = true;
                chkModificarContrasena.Checked = true;
            }
        }
    }
}

