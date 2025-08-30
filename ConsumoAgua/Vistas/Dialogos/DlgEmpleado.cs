using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using SAPA.Vistas.Paneles;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgEmpleado : Form
    {

        public DlgEmpleado()
        {
            InitializeComponent();
        }

        public Empleado Empleado { get; set; } = new Empleado();

        private void CargarCajas()
        {
            List<Caja> cajas = new List<Caja>();

            cajas = Caja.GetCajas();

            if (cajas.Count > 0)
            {
                cajas.Insert(0, new Caja
                {
                    Id = 0,
                    Descripcion = "[ -- Seleccione una caja -- ]"
                });

                cmbCaja.DataSource = cajas;
                cmbCaja.ValueMember = "Id";
                cmbCaja.DisplayMember = "Descripcion";
            }
            else
            {
                MessageBox.Show("No hay cajas registradas. Revise el catalogo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }

        private void CargarPuestos()
        {
            List<Puesto> puestos = new List<Puesto>();

            puestos = Puesto.GetPuestos();

            if (puestos.Count > 0)
            {
                puestos.Insert(0, new Puesto
                {
                    Id = 0,
                    Descripcion = "[ -- Seleccione un puesto -- ]"
                });

                cmbPuesto.DataSource = puestos;
                cmbPuesto.ValueMember = "Id";
                cmbPuesto.DisplayMember = "Descripcion";
            }
            else
            {
                MessageBox.Show("No hay puestos registrados. Contacte al área de soporte de SAPA.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }

        private bool ValidarGui()
        {
            if (!string.IsNullOrWhiteSpace(txtNoCuadrilla.Text))
            {
                try
                {
                    int.Parse(txtNoCuadrilla.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show(
                        "El número de cuadrilla ingresado no es válido. Revise el campo e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (pnlContrasena.Enabled)
            {
                if (!txtContrasena.Text.Equals(txtRepetirContrasena.Text))
                {
                    MessageBox.Show("Las contraseñas ingresadas no coinciden. Intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del empleado no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGui()) return;

                bool actualizar = Empleado.Id > 0;

                if (actualizar)
                {
                    // Modificar un empleado

                    Empleado empleado = new Empleado
                    {
                        Id = Empleado.Id,
                        Usuario = txtUsuario.Text,
                        Contrasena = pnlContrasena.Enabled ? Utilerias.EncriptarContrasena(txtContrasena.Text) : "",
                        Nombre = txtNombre.Text,
                        ApellidoPaterno = string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) ? string.Empty : txtApellidoPaterno.Text,
                        ApellidoMaterno = string.IsNullOrWhiteSpace(txtApellidoMaterno.Text) ? string.Empty : txtApellidoMaterno.Text,
                        Domicilio = txtDomicilio.Text,
                        Telefono = txtTelefono.Text,
                        RFC = txtRFC.Text,
                        Puesto = cmbPuesto.SelectedItem as Puesto,
                        Caja = cmbCaja.SelectedItem as Caja ?? new Caja(),
                        NoCuadrilla = (string.IsNullOrWhiteSpace(txtNoCuadrilla.Text) ? 0 : Convert.ToInt32(txtNoCuadrilla.Text))
                    };

                    if (!empleado.Actualizar())
                    {
                        MessageBox.Show("Ocurrió un error al actualizar el operador", this.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }

                    MessageBox.Show("Los datos del empleado fueron actualizados correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;

                }
                else
                {
                    // Agregar un nuevo empleado

                    Empleado empleado = new Empleado
                    {
                        Usuario = txtUsuario.Text,
                        Contrasena = Utilerias.EncriptarContrasena(txtContrasena.Text),
                        Nombre = txtNombre.Text,
                        ApellidoPaterno = string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) ? string.Empty : txtApellidoPaterno.Text,
                        ApellidoMaterno = string.IsNullOrWhiteSpace(txtApellidoMaterno.Text) ? string.Empty : txtApellidoMaterno.Text,
                        Domicilio = txtDomicilio.Text,
                        Telefono = txtTelefono.Text,
                        RFC = txtRFC.Text,
                        Puesto = (Puesto)cmbPuesto.SelectedItem,
                        Caja = cmbCaja.SelectedItem as Caja ?? new Caja(),
                        NoCuadrilla = (string.IsNullOrWhiteSpace(txtNoCuadrilla.Text) ? 0 : Convert.ToInt32(txtNoCuadrilla.Text))
                    };

                    if (!empleado.Agregar())
                    {
                        MessageBox.Show("Ocurrió un error al agregar el empleado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    MessageBox.Show("Empleado agregado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAceptar_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void chkModificarContrasena_CheckedChanged(object sender, EventArgs e) => pnlContrasena.Enabled = chkModificarContrasena.Checked;

        private void DlgEmpleado_Load(object sender, EventArgs e)
        {
            CargarCajas();
            CargarPuestos();

            if (Empleado.Id > 0)
            {
                pnlContrasena.Enabled = false;
                txtUsuario.Enabled = false;

                txtUsuario.Text = Empleado.Usuario;
                txtNombre.Text = Empleado.Nombre;
                txtApellidoPaterno.Text = Empleado.ApellidoPaterno;
                txtApellidoMaterno.Text = Empleado.ApellidoMaterno;
                txtDomicilio.Text = Empleado.Domicilio;
                txtTelefono.Text = Empleado.Telefono;

                txtRFC.Text = Empleado.RFC;

                txtContrasena.Text = "";
                txtRepetirContrasena.Text = "";

                if(Empleado.NoCuadrilla > 0)
                    txtNoCuadrilla.Text = Empleado.NoCuadrilla.ToString();
            }
            else
            {
                chkModificarContrasena.Enabled = false;
                chkModificarContrasena.Visible = false;
                pnlContrasena.Enabled = true;
            }
        }

        private void DlgEmpleado_Shown(object sender, EventArgs e)
        {
            if (Empleado.Id > 0)
            {
                cmbPuesto.SelectedValue = Empleado.IdPuesto;
                cmbCaja.SelectedValue = Empleado.Caja == null ? 0 : Empleado.IdCaja;
            }
        }
    }
}


