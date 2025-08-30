using System;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgAgregarCalle : Form
    {

        public DlgAgregarCalle()
        {
            InitializeComponent();
        }

        public Calle Calle { get; set; } = new Calle();

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código de la calle no puede estar vacío. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la calle no puede estar vacío. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var codigo = int.Parse(txtCodigo.Text);

                if (codigo <= 0)
                {
                    MessageBox.Show(
                        "El código de la calle no es válido. Corrija el campo e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "El código de la calle debe ser un dato númerico. Corrija el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "El código de la calle no es válido. Corrija el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGui()) return;

                bool modificar = Calle.Id > 0;

                Calle.Descripcion = Utilerias.NormalizarEspacios(txtNombre.Text);

                if (modificar)
                {
                    if (!Calle.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar los datos de la calle. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datoa de la calle fueron actualizados correctamente.", "Formulario Calle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    Calle.Codigo = int.Parse(txtCodigo.Text);
                    
                    if (!Calle.Agregar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar registrar los datos de la calle. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos de la calle fueron agregados correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAdd_Click - " + ex.Message, "Dialog Agregar_Calles", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Dialog_AgregarColonia_Load(object sender, EventArgs e)
        {

            if (Calle.Id > 0)
            {
                txtCodigo.Text = Calle.Codigo.ToString("D3");
                txtNombre.Text = Calle.Descripcion;

            }
            else
            {
                txtCodigo.Text = (Calle.ObtenerUltimoID() + 1).ToString("D3");
            }

        }
    }
}

