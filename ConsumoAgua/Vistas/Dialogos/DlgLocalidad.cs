using System;
using System.Windows.Forms;
using Clases;
using SAPA.Vistas.Paneles;
using SAPA.Clases;
using Exception = System.Exception;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgLocalidad : Form
    {

        public Localidad Localidad { get; set; } = new Localidad();

        public DlgLocalidad()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtNombreLocalidad.Text))
            {
                MessageBox.Show("El nombre de la localidad no puede estar vacío. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGui()) return;

                bool actualizar = Localidad.Id > 0;

                Localidad.Nombre = Utilerias.NormalizarEspacios(txtNombreLocalidad.Text);

                if (actualizar)
                {
                    if (!Localidad.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar la localidad. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos de la localidad fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                }
                else
                {
                    if (!Localidad.Agregar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar agregar la localidad. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos de la localidad fueron agregados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAceptar - " + ex.Message, this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void DlgLocalidad_Load(object sender, EventArgs e)
        {
            if (Localidad.Id > 0)
            {
                txtNombreLocalidad.Text = Localidad.Nombre;
            }
        }
    }
}

