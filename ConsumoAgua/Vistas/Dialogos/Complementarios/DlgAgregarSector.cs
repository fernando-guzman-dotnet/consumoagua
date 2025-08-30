using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgAgregarSector : Form
    {
        public DlgAgregarSector()
        {
            InitializeComponent();
        }

        public Sector Sector { get; set; } = new Sector();

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtSector.Text))
            {
                MessageBox.Show("El nombre del sector no puede estar vacío. Complete el campo e intente nuevamente.",
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

                bool actualizar = Sector.Id > 0;

                Sector.Descripcion = Utilerias.NormalizarEspacios(txtSector.Text);

                if (actualizar)
                {
                    if (!Sector.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un problema al actualizar los datos del sector. Intenta nuevamente, si el problema persiste contacta al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del sector fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!Sector.Guardar())
                    {
                        MessageBox.Show(
                            "Hubo un problema al guardar los datos del sector. Intenta nuevamente, si el problema persiste contacta al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    MessageBox.Show("Los datos del sector fueron guardados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregar_Click " + ex.Message, "Formulario Dialog_AgregarSector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void Dialog_AgregarSector_Load(object sender, EventArgs e)
        {
            if (Sector.Id > 0)
            {
                txtSector.Text = Sector.Descripcion;
            }
        }
    }
}

