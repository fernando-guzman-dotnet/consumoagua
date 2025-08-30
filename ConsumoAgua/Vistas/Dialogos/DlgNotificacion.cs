using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgNotificacion : Form
    {
        public Notificacion Notificacion { get; set; } = new Notificacion();

        public DlgNotificacion()
        {
            InitializeComponent();
        }

        private void CargarCmbNotificadores()
        {
            List<Empleado> notificadores = Empleado.GetNotificadores();

            if (notificadores.Count == 0)
            {
                MessageBox.Show(
                    "No hay empleados con el puesto de notificador asignado. Revise el catálogo de empleados e intente nuevamente. Si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }

            notificadores.Insert(0, new Empleado { Id = 0, Nombre = "[ -- SELECCIONE UN NOTIFICADOR -- ]" });

            cmbNotificadores.DataSource = notificadores;
            cmbNotificadores.ValueMember = "Id";
            cmbNotificadores.DisplayMember = "NombreCompleto";
        }

        private bool ValidarGui()
        {

            try
            {
                if (Int32.Parse(mtxtNoContrato.Text) == 0)
                {
                    MessageBox.Show(
                        "No se ha elegido un contrato para la notificación. Elija uno e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "El número de contrato ingresado no es válido. Revise el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (!Contrato.Existe(Int32.Parse(mtxtNoContrato.Text)))
            {
                MessageBox.Show(
                    "No se ha elegido un contrato válido para la notificación. Elija un contrato válido e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int noContrato;

            if (!Int32.TryParse(mtxtNoContrato.Text, out noContrato))
            {
                MessageBox.Show("El número de contrato ingresado no es válido. Revise el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbNotificadores.SelectedIndex == 0 || cmbNotificadores.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado un notificador. Seleccione una de las opciones disponibles e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGui()) return;

                bool actualizar = Notificacion.Id > 0;

                Notificacion.NoContrato = int.Parse(mtxtNoContrato.Text);
                Notificacion.Fecha = Utilerias.GetDateTimeFromControls(dtpFecha, dtpHora);
                Notificacion.Empleado = Empleado.Actual;
                Notificacion.Notificador = new Empleado
                {
                    Id = (int)cmbNotificadores.SelectedValue
                };

                Notificacion.Observaciones = txtObservaciones.Text;

                // El contrato debe tener adeudos por los conceptos que se requieren en el reporte
                // Si el adeudo total es 0, entonces no se podrá generar una notificación

                if (actualizar)
                {
                    if (!Notificacion.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar los datos de la notificación. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos de la notificación fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Confirmar impresión
                }
                else
                {

                    Notificacion.IdEstatus = (int) Notificacion.Estatus.Impresa;

                    if (!Notificacion.Agregar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar guardar los datos de la notificación. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos de la notificación fueron registrados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Confirmar impresión
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAceptar_Click - " + ex.Message, "Formulario DlgNotificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void mtxtNoContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                string cadena = mtxtNoContrato.Text + e.KeyChar;
                mtxtNoContrato.Text = cadena.Substring(1, cadena.Length - 1);
                mtxtNoContrato.SelectionStart = mtxtNoContrato.Mask.Length + 1;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ActiveControl == mtxtNoContrato)
            {
                if (keyData == Keys.Back || keyData == Keys.Delete)
                {
                    mtxtNoContrato.ResetText();
                    mtxtNoContrato.SelectionStart = mtxtNoContrato.Mask.Length + 1;
                    return true;
                }

                if (keyData == Keys.Enter)
                {
                    try
                    {
                        var noContrato = int.Parse(mtxtNoContrato.Text);

                        if (!CargarDatosContrato(noContrato))
                            btnBuscar_Click(null, null);
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show(
                            "El número de contrato ingresado no es válido. Revise el campo e intente nuevamente.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private bool CargarDatosContrato(int noContrato)
        {
            Contrato contrato = Contrato.GetContrato(noContrato);

            if (contrato == null)
                return false;

            txtNombreContrato.Text = contrato.NombreUsuario;
            txtDireccionContrato.Text = contrato.Direccion;

            return true;
        }


        private void DlgNotificacion_Load(object sender, EventArgs e)
        {

            CargarCmbNotificadores();

            if (Notificacion.Id > 0)
            {
                dtpFecha.Value = Notificacion.Fecha;
                dtpHora.Value = Notificacion.Fecha;

                CargarDatosContrato(Notificacion.NoContrato);

                cmbNotificadores.SelectedValue = Notificacion.IdEmpleadoNotificador;

                txtObservaciones.Text = Notificacion.Observaciones;
                txtCapturador.Text = Notificacion.Empleado.NombreCompleto;
            }
            else
            {
                txtCapturador.Text = Empleado.Actual.NombreCompleto;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DlgSeleccionarCuenta dlg = new DlgSeleccionarCuenta();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                mtxtNoContrato.Text = dlg.Contrato.NoContrato.ToString("D10");
                txtNombreContrato.Text = dlg.Contrato.Usuario.NombreCompleto;
            }
        }
    }
}

