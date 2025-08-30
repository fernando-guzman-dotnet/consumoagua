using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgActualizarEstatusOrden : Form
    {
        public DlgActualizarEstatusOrden()
        {
            InitializeComponent();
        }

        public BitacoraOrdenTrabajo BitacoraOrdenTrabajo { get; set; } = new BitacoraOrdenTrabajo();
        public OrdenTrabajo OrdenTrabajo { get; set; } = new OrdenTrabajo();

        private int _idEstatus
        {
            get
            {
                int idEstatus = (int)OrdenTrabajo.Estatus.Pendiente;

                if (rbPendiente.Checked)
                    idEstatus = (int)OrdenTrabajo.Estatus.Pendiente;
                if (rbCancelada.Checked)
                    idEstatus = (int)OrdenTrabajo.Estatus.Cancelada;
                if (rbCompletada.Checked)
                    idEstatus = (int)OrdenTrabajo.Estatus.Completada;
                if (rbEnProceso.Checked)
                    idEstatus = (int)OrdenTrabajo.Estatus.EnProceso;
                return idEstatus;
            }
        }


        private void DlgActualizarEstatusOrden_Load(object sender, EventArgs e)
        {
            CargarCmbJefesCuadrilla();
            if (OrdenTrabajo.Id > 0)
            {
                switch ((OrdenTrabajo.Estatus)OrdenTrabajo.IdEstatus)
                {
                    case OrdenTrabajo.Estatus.Cancelada:
                        rbCancelada.Checked = true;
                        break;
                    case OrdenTrabajo.Estatus.Pendiente:
                        rbPendiente.Checked = true;
                        break;
                    case OrdenTrabajo.Estatus.Completada:
                        rbCompletada.Checked = true;
                        break;
                }
            }
            else
            {
                MessageBox.Show(
                    "No se pasó una orden de trabajo valida a este dialogo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
            }
        }

        private void CargarCmbJefesCuadrilla()
        {
            List<Empleado> jefesCuadrilla = Empleado.GetJefesCuadrilla();

            /*if (jefesCuadrilla.Count == 0)
            {
                MessageBox.Show(
                    "No hay empleados con el puesto de jefe de cuadrilla asignado. Revise el catálogo de empleados e intente nuevamente. Si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }*/

            jefesCuadrilla.Insert(0, new Empleado { Id = 0, Nombre = "[ -- SELECCIONE UN JEFE DE CUADRILLA -- ]" });

            cmbJefesCuadrilla.DataSource = jefesCuadrilla;
            cmbJefesCuadrilla.ValueMember = "Id";
            cmbJefesCuadrilla.DisplayMember = "NombreCompleto";

        }


        private bool ValidarGui()
        {
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (!ValidarGui()) return;

            BitacoraOrdenTrabajo.Fecha = Utilerias.GetDateTimeFromControls(dtpFecha, dtpHora);
            BitacoraOrdenTrabajo.IdOrden = OrdenTrabajo.Id;
            BitacoraOrdenTrabajo.IdEstatus = _idEstatus;
            BitacoraOrdenTrabajo.Observaciones = txtObservaciones.Text;
            BitacoraOrdenTrabajo.IdEmpleado = Empleado.Actual.Id;

            OrdenTrabajo.IdEstatus = _idEstatus;
            OrdenTrabajo.JefeCuadrilla = cmbJefesCuadrilla.SelectedItem as Empleado;

            if (!OrdenTrabajo.Actualizar())
            {
                MessageBox.Show(
                    "Hubo un error al intentar actualizar el estatus de la orden de trabajo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!BitacoraOrdenTrabajo.Agregar())
            {
                MessageBox.Show(
                    "Hubo un error al intentar agregar un registro en la bitacora de la orden de trabajo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("El estatus de la orden ha sido actualizado correctamente.", this.Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}

