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
    public partial class DlgAgregarOrdenTarea : Form
    {
        public OrdenTrabajo OrdenTrabajo { get; set; }

        public OrdenTarea OrdenTarea { get; set; } = new OrdenTarea();

        public DlgAgregarOrdenTarea()
        {
            InitializeComponent();
        }

        private void DlgAgregarOrdenTarea_Load(object sender, EventArgs e)
        {
            if (OrdenTrabajo == null)
            {
                MessageBox.Show(
                    "No se ha cargado una orden de trabajo para poder registrar la tarea. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }
        }


        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo 'Descripción' no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            OrdenTarea.IdOrdenTrabajo = OrdenTrabajo.Id;
            OrdenTarea.Fecha = DateTime.Now;
            OrdenTarea.Descripcion = txtDescripcion.Text;

            bool actualizar = OrdenTarea.Id > 0;

            if (actualizar)
            {
                // TODO: Actualizar tareas de ordenes
            }
            else
            {
                if (!OrdenTarea.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar registrar la tarea en la orden. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("La tarea se ha registrado en la orden correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}

