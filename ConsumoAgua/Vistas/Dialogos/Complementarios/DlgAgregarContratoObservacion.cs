using System;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgAgregarContratoObservacion : Form
    {
        public DlgAgregarContratoObservacion()
        {
            InitializeComponent();
        }

        public ContratoObservacion ContratoObservacion { get; set; } = new ContratoObservacion();

        private void DlgAgregarContratoObservacion_Load(object sender, EventArgs e)
        {
            if (ContratoObservacion.NoContrato == 0)
            {
                MessageBox.Show(
                    "No hay un no. de contrato asignado para esta observación. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
                return;
            }
        }

        private bool ValidarGui()
        {
            if (string.IsNullOrEmpty(txtComentario.Text))
            {
                MessageBox.Show(
                    "El comentario de la observación no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            ContratoObservacion.Comentario = txtComentario.Text;
            ContratoObservacion.Fecha = DateTime.Now;
            ContratoObservacion.Empleado = Empleado.Actual;

            MessageBox.Show("La observación fue agregada al contrato correctamente. Se guardará hasta que guarde el contrato.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Cancel;
    }
}

