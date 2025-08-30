using System;
using System.Windows.Forms;
using SAPA.Vistas.Paneles;
using SAPA.Clases;
using Exception = System.Exception;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgTipoDescuento : Form
    {

        public TipoDescuento TipoDescuento { get; set; } = new TipoDescuento();

        public DlgTipoDescuento()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK,
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

                bool actualizar = TipoDescuento.Id > 0;

                TipoDescuento.Descripcion = Utilerias.NormalizarEspacios(txtDescripcion.Text);
                TipoDescuento.UnicoPorUsuario = chkUnicoPorUsuario.Checked;

                if (actualizar)
                {
                    if (!TipoDescuento.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar los datos del tipo de descuento. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del tipo de descuento fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!TipoDescuento.Guardar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar registrar los datos del tipo de descuento. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del tipo de descuento fueron registrados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAdd_Click - " + ex.Message, "Formulario Dialog_Concepto", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void DlgTipoDescuento_Load(object sender, EventArgs e)
        {
            if (TipoDescuento.Id > 0)
            {
                txtDescripcion.Text = TipoDescuento.Descripcion;
                chkUnicoPorUsuario.Checked = TipoDescuento.UnicoPorUsuario;
            }
        }
    }
}

