using System;
using System.Windows.Forms;
using Clases;
using SAPA.Vistas.Paneles;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgTipoVivienda : Form
    {
        public DlgTipoVivienda()
        {
            InitializeComponent();
        }

        public TipoVivienda TipoVivienda { get; set; } = new TipoVivienda();

        private bool ValidarGui()
        {

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "La descripción del tipo de vivienda no puede estar vacía. Complete el campo e intente nuevamente.",
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

                bool actualizar = TipoVivienda.Id > 0;

                TipoVivienda.Descripcion = Utilerias.NormalizarEspacios(txtDescripcion.Text);
                
                if (actualizar)
                {
                    if (!TipoVivienda.Actualizar())
                    {
                        MessageBox.Show("Hubo un problema al intentar actualizar los datos del tipo de vivienda. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del tipo de vivienda fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!TipoVivienda.Guardar())
                    {
                        MessageBox.Show(
                            "Hubo un problema al intentar guardar los datos del tipo de vivienda. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA,",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del tipo de vivienda fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnAdd_Click - " + ex.Message, "Formulario Dialog_TipoVivienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void DlgTipoVivienda_Load(object sender, EventArgs e)
        {
            if (TipoVivienda.Id > 0)
            {
                txtDescripcion.Text = TipoVivienda.Descripcion;
            }
        }
    }
}

