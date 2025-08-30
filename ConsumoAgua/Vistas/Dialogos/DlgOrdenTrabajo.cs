using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgOrdenTrabajo : Form
    {

        public OrdenTrabajo OrdenTrabajo { get; set; } = new OrdenTrabajo();

        public DlgOrdenTrabajo()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {

            try
            {
                if (Int32.Parse(mtxtNoContrato.Text) == 0)
                {
                    MessageBox.Show(
                        "No se ha elegido un contrato para la orden. Elija uno e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
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
                    "No se ha elegido un contrato válido para la orden. Elija un contrato válido e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbTipoOrdenes.SelectedIndex == 0 || cmbTipoOrdenes.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha elegido un tipo de orden. Elija un tipo de orden e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbSupervisores.SelectedIndex == 0 || cmbSupervisores.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha elegido un supervisor para la orden. Elija un supervisor e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            OrdenTrabajo.NoContrato = Int32.Parse(mtxtNoContrato.Text);
            OrdenTrabajo.Fecha = Utilerias.GetDateTimeFromControls(dtpFecha, dtpHora);
            OrdenTrabajo.TipoOrdenTrabajo = cmbTipoOrdenes.SelectedItem as TipoOrdenTrabajo;
            OrdenTrabajo.Observaciones = txtObservaciones.Text;
            OrdenTrabajo.Supervisor = new Empleado { Id = (int)cmbSupervisores.SelectedValue };
            OrdenTrabajo.Empleado = Empleado.Actual;

            bool actualizar = OrdenTrabajo.Id > 0;

            if (actualizar)
            {
                if (!OrdenTrabajo.Actualizar())
                {
                    MessageBox.Show(
                        "Hubo un problema al intentar actualizar los datos de la orden de trabajo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                BitacoraOrdenTrabajo bitacoraOrdenTrabajo = new BitacoraOrdenTrabajo
                {
                    Fecha = Utilerias.GetDateTimeFromControls(dtpFecha, dtpHora),
                    IdOrden = OrdenTrabajo.Id,
                    IdEstatus = OrdenTrabajo.IdEstatus,
                    Observaciones = "Se actualizaron los datos de la orden de trabajo.",
                    IdEmpleado = Empleado.Actual.Id
                };

                if (!bitacoraOrdenTrabajo.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar agregar un registro en la bitacora de la orden de trabajo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Los datos de la orden de trabajo fueron actualizados correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            else
            {
                OrdenTrabajo.IdEstatus = (int)OrdenTrabajo.Estatus.Pendiente;
                OrdenTrabajo.JefeCuadrilla = new Empleado();

                if (!OrdenTrabajo.Guardar())
                {
                    MessageBox.Show(
                        "Hubo un problema al intentar guardar los datos de la orden de trabajo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BitacoraOrdenTrabajo bitacoraOrdenTrabajo = new BitacoraOrdenTrabajo
                {
                    Fecha = Utilerias.GetDateTimeFromControls(dtpFecha, dtpHora),
                    IdOrden = OrdenTrabajo.Id,
                    IdEstatus = OrdenTrabajo.IdEstatus,
                    Observaciones = "Se creó la orden de trabajo.",
                    IdEmpleado = Empleado.Actual.Id
                };

                if (!bitacoraOrdenTrabajo.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar agregar un registro en la bitacora de la orden de trabajo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Los datos de la orden de trabajo fueron registrados correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DlgSeleccionarCuenta dlg = new DlgSeleccionarCuenta();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                mtxtNoContrato.Text = dlg.Contrato.NoContrato.ToString("D10");

                grpDatosContrato.Visible = true;

                txtNombreContratista.Text = dlg.Contrato.NombreUsuario;
                txtDireccionContrato.Text = dlg.Contrato.Direccion;
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

            txtNombreContratista.Text = contrato.NombreUsuario;
            txtDireccionContrato.Text = contrato.Direccion;

            return true;
        }

        private void CargarCmbSupervisores()
        {
            List<Empleado> supervisor = Empleado.GetSupervisores();

            if (supervisor.Count == 0)
            {
                MessageBox.Show(
                    "No hay empleados con el puesto de supervisor asignado. Revise el catálogo de empleados e intente nuevamente. Si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }

            supervisor.Insert(0, new Empleado { Id = 0, Nombre = "[ -- SELECCIONE UN SUPERVISOR -- ]" });

            cmbSupervisores.DataSource = supervisor;
            cmbSupervisores.ValueMember = "Id";
            cmbSupervisores.DisplayMember = "NombreCompleto";

        }

        private void CargarCmbTipoOrdenes()
        {
            List<TipoOrdenTrabajo> tiposOrdenesTrabajo = TipoOrdenTrabajo.GetTiposOrdenesTrabajo();

            if (tiposOrdenesTrabajo.Count == 0)
            {
                MessageBox.Show("No hay tipos de ordenes registradas. Contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }

            tiposOrdenesTrabajo.Insert(0, new TipoOrdenTrabajo() { Id = 0, Tipo = "[ -- Seleccione un tipo de orden -- ]" });
            cmbTipoOrdenes.DataSource = tiposOrdenesTrabajo;
            cmbTipoOrdenes.DisplayMember = "Tipo";
            cmbTipoOrdenes.ValueMember = "Id";

        }

        private void DlgOrdenTrabajo_Load(object sender, EventArgs e)
        {
            CargarCmbSupervisores();
            CargarCmbTipoOrdenes();

            if (OrdenTrabajo.Id > 0)
            {
                mtxtNoContrato.Text = OrdenTrabajo.NoContrato.ToString("D10");

                CargarDatosContrato(OrdenTrabajo.NoContrato);

                dtpFecha.Value = OrdenTrabajo.Fecha;
                dtpHora.Value = OrdenTrabajo.Fecha;

                cmbTipoOrdenes.SelectedValue = OrdenTrabajo.IdTipoOrdenTrabajo;
                txtObservaciones.Text = OrdenTrabajo.Observaciones;
                cmbSupervisores.SelectedValue = OrdenTrabajo.IdEmpleadoSupervisor;
                txtCapturador.Text = OrdenTrabajo.NombreEmpleado;
            }
            else
            {
                grpDatosContrato.Visible = false;

                dtpFecha.Value = DateTime.Now;
                dtpHora.Value = DateTime.Now;
                txtCapturador.Text = Empleado.Actual.NombreCompleto;
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
    }
}

