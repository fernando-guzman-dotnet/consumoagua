using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Deployment.Application;
using System.Drawing;
using System.Web.Configuration;
using CalculoCobroAgua;
using SAPA;
using SAPA.Properties;
using SAPA.Clases;

namespace SAPA
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            AplicarIconografia();
        }

        private const string USUARIO_DEFAULT = "Admin";
        private const string CONTRASEÑA_DEFAULT = "Admin123";

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void LogIn_Load(object sender, EventArgs e)
        {
            var municipiosConexiones = Enum.GetValues(typeof(Globales.Municipios));

            // Filtrar los municipios según la disponibilidad en cada Entry Point
            // <...>

            cmbMunicipiosConexiones.DataSource = municipiosConexiones;

            if (!ApplicationDeployment.IsNetworkDeployed)
            {
                txtUsuario.Text = USUARIO_DEFAULT;
                txtContrasena.Text = CONTRASEÑA_DEFAULT;
            }
        }

        private void AplicarIconografia()
        {
            this.Icon = Globales.GetIcon("Sistema");
            pbLogo.Image = Globales.GetImage("LogIn");
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = string.Empty;

                // Colorearlo como un campo activo

                txtUsuario.ResetForeColor();
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "CONTRASEÑA")
            {
                txtContrasena.Text = string.Empty;

                // Colorearlo como un campo activo

                txtContrasena.ResetForeColor();
            }

        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "USUARIO";

                // Colorearlo como un campo inactivo

                txtUsuario.ForeColor = SystemColors.GrayText;
            }

        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                txtContrasena.Text = "CONTRASEÑA";

                // Colorearlo como un campo inactivo

                txtContrasena.ForeColor = SystemColors.GrayText;
            }
        }

        //private void chkVerContrasena_CheckedChanged(object sender, EventArgs e) => txtContrasena.UseSystemPasswordChar = !chkVerContrasena.Checked;

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Text) || txtUsuario.Text.Equals("USUARIO"))
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    txtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtContrasena.Text) || txtContrasena.Text.Equals("CONTRASEÑA"))
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    txtUsuario.Focus();
                    return;
                }

                Cursor = Cursors.WaitCursor;

                Empleado empleado = Empleado.GetEmpleadoByCredenciales(txtUsuario.Text, Utilerias.EncriptarContrasena(txtContrasena.Text));

                Cursor = Cursors.Arrow;

                if (empleado == null)
                {
                    MessageBox.Show(
                        "No se pudo ingresar al sistema con las credenciales ingresadas.\n\nRevise el usuario y la contraseña.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                empleado.PermisosModulos = EmpleadoPermisosModulo.GetEmpleadoPermisos(empleado.Id);

                FrmPrincipal frm = new FrmPrincipal
                {
                    Ayuntamiento = Globales.MunicipioActual.ToString(),
                    EmpleadoActivo = empleado
                };

                frm.FormClosed += on_Closed;

                frm.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAcceder_Click - " + ex.Message, "Formulario Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void on_Closed(object sender, FormClosedEventArgs e)
        {
            if (((FrmPrincipal)sender).SesionCerrada)
            {
                if (!ApplicationDeployment.IsNetworkDeployed)
                {
                    txtUsuario.Text = USUARIO_DEFAULT;
                    txtContrasena.Text = CONTRASEÑA_DEFAULT;
                }
                else
                {
                    this.txtUsuario.Text = string.Empty;
                    this.txtContrasena.Text = string.Empty;
                }

                this.Show();

                this.ActiveControl = txtUsuario;
            }
            else
            {
                this.Close();
            }
        }

        private void btnAcceder_MouseEnter(object sender, EventArgs e) => btnAcceder.ForeColor = Color.White;
        private void btnAcceder_MouseLeave(object sender, EventArgs e) => btnAcceder.ForeColor = Color.FromArgb(48, 49, 51);

        private bool _frmShown;
        private void LogIn_Shown(object sender, EventArgs e) => _frmShown = true;

        private void cmbMunicipiosConexiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            var municipioSeleccionado = (Globales.Municipios)cmbMunicipiosConexiones.SelectedValue;

            if (Globales.CurrentEntryPoint == Globales.EntryPoints.Pruebas && municipioSeleccionado != Globales.Municipios.Pruebas)
            {
                if (_frmShown)
                {
                    MessageBox.Show("Solo puede conectarse a la base de datos de pruebas desde este sistema.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cmbMunicipiosConexiones.SelectedItem = Globales.Municipios.Pruebas;
                return;
            }


            if (Globales.CurrentEntryPoint != Globales.EntryPoints.Pruebas && municipioSeleccionado == Globales.Municipios.Pruebas)
            {
                if (_frmShown)
                {
                    MessageBox.Show("La conexión a la base de datos de pruebas está restringida en este sistema.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                cmbMunicipiosConexiones.SelectedItem = Globales.Municipios.Tinguindin;
                return;
            }

            // No permitir seleccionar Jacona -- la base de datos no está adaptada para el sistema 10/11/2021
            if (municipioSeleccionado == Globales.Municipios.Jacona)
            {
                // Mostrar el mensaje de error solo cuando el formulario ya esté mostrado

                if (_frmShown)
                {
                    MessageBox.Show("La conexión a esta base de datos está restringida temporalmente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cmbMunicipiosConexiones.SelectedItem = Globales.Municipios.Tinguindin;
                return;
            }


            Globales.MunicipioActual = municipioSeleccionado;
            CobroAgua.SetMunicipioConexion(municipioSeleccionado.ToString());
            Configuracion.Actual = Configuracion.GetConfiguracion();
        }

        // Mostrar todos los elementos del ComboBox en mayusculas

        private void cmbMunicipiosConexiones_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = e.ListItem.ToString().ToUpper();

            // En el caso de tingüindin, agregamos la dieresis (¨) en la u
            if ((Globales.Municipios)e.ListItem == Globales.Municipios.Tinguindin)
                e.Value = "TINGÜINDIN";
        }

        private void chkVerContraseña_CheckedChanged(object sender, EventArgs e) => txtContrasena.UseSystemPasswordChar = !chkVerContraseña.Checked;
    }
}

