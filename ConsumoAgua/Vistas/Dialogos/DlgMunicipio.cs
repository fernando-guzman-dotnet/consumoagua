using System;
using System.Windows.Forms;
using Clases;
using SAPA.Vistas.Paneles;
using SAPA.Clases;
using Exception = System.Exception;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgMunicipio : Form
    {

        public Municipio Municipio { get; set; } = new Municipio();

        public DlgMunicipio()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtNombreMunicipio.Text))
            {
                MessageBox.Show("El nombre del municipio no puede estar vacío. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK,
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

                bool actualizar = Municipio.Id > 0;

                Municipio.Nombre= Utilerias.NormalizarEspacios(txtNombreMunicipio.Text);

                if (actualizar)
                {
                    if (!Municipio.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar el municipio. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del municipio fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                }
                else
                {
                    if (!Municipio.Agregar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar agregar el municipio. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del municipio fueron agregados correctamente.", this.Text,
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

        private void DlgMunicipio_Load(object sender, EventArgs e)
        {
            if (Municipio.Id > 0)
            {
                txtNombreMunicipio.Text = Municipio.Nombre;
            }
        }
    }
}

