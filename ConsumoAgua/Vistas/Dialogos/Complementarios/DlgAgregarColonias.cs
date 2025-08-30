using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgAgregarColonia : Form
    {
        public Colonia Colonia { get; set; } = new Colonia();

        public DlgAgregarColonia()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código de la colonia no puede estar vacío. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La dirección no puede estar vacía. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                int.Parse(txtCodigo.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("El código de la colonia debe ser un dato númerico. Corrija el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGui()) return;

                bool modificar = Colonia.Id > 0;

                Colonia.Codigo =  int.Parse(txtCodigo.Text);
                Colonia.Descripcion = Utilerias.NormalizarEspacios(txtDescripcion.Text);

                if (modificar)
                {
                    if (!Colonia.Actualizar())
                    {
                        MessageBox.Show("Hubo un error al intentar actualizar los datos de la colonia. Intente nuevamente, si el problema persiste contactea al área de soporte de SAPA.", this.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    MessageBox.Show("Los datos de la colonia se actualizaron correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!Colonia.Agregar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar registrar los datos de la colonia. Intente nuevamente, si el problema persiste contactea al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    MessageBox.Show("Colonia agregada correctamente.", "Formulario Agregar Colonias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregar_Click - " + ex.Message, "Dialog Agregar_Colonias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Dialog_AgregarColonia_Load(object sender, EventArgs e)
        {
            if (Colonia.Id > 0)
            {
                txtDescripcion.Text = Colonia.Descripcion;
                txtCodigo.Text = Colonia.Codigo.ToString("D3");
            }
        }
    }
}

