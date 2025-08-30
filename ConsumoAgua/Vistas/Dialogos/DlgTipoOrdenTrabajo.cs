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

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgTipoOrdenTrabajo : Form
    {
        public TipoOrdenTrabajo TipoOrdenTrabajo { get; set; } = new TipoOrdenTrabajo();

        public DlgTipoOrdenTrabajo()
        {
            InitializeComponent();
        }

        private void DlgTipoOrdenTrabajo_Load(object sender, EventArgs e)
        {
            if (TipoOrdenTrabajo.Id > 0)
            {
                txtDescripcion.Text = TipoOrdenTrabajo.Tipo;
            }
        }

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "La descripción del tipo de orden de trabajo no puede estar vacía. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            bool actualizar = TipoOrdenTrabajo.Id > 0;

            TipoOrdenTrabajo.Tipo = txtDescripcion.Text;

            if (actualizar)
            {
                if (!TipoOrdenTrabajo.Actualizar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar actualizar los datos del tipo de orden de trabajo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Los datos del tipo de orden de trabajo fueron actualizados correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!TipoOrdenTrabajo.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar guardar los datos del tipo de orden de trabajo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Los datos del tipo de orden de trabajo fueron registrados correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

    }
}

