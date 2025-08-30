using System;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgSeccion : Form
    {

        public DlgSeccion()
        {
            InitializeComponent();
        }

        public Seccion Seccion { get; set; } = new Seccion();

        private bool ValidarGui()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "La descrípción de la sección no puede estar vacía. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGui()) return;

                bool actualizar = Seccion.Id > 0;

                
                Seccion.Descripcion = Utilerias.NormalizarEspacios(txtDescripcion.Text);

                if (actualizar)
                {
                    if (!Seccion.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un problema al intentar actualizar los datos de la sección. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos de la sección fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!Seccion.Guardar())
                    {
                        MessageBox.Show(
                            "Hubo un problema al intentar guardar los datos de la sección. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos de la sección fueron registrados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregar_Click - " + ex.Message, "Formulario Dialog_Seccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void DlgSeccion_Load(object sender, EventArgs e)
        {
            if (Seccion.Id > 0)
            {
                txtDescripcion.Text = Seccion.Descripcion;
            }
        }
    }
}

