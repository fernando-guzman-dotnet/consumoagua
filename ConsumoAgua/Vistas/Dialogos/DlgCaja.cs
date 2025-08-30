using System;
using System.Windows.Forms;
using Clases;
using SAPA.Vistas.Paneles;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgCaja : Form
    {

        public Caja Caja { get; set; } = new Caja();

        public DlgCaja()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcionCaja.Text))
            {
                MessageBox.Show("La descripción de la caja no puede estar vacío. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK,
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

                bool actualizar = Caja.Id > 0;

                Caja.Descripcion = Utilerias.NormalizarEspacios(txtDescripcionCaja.Text);

                if (actualizar)
                {
                    if (!Caja.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar la caja. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos de la caja fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                }
                else
                {
                    if (!Caja.Agregar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar agregar el banco. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos de la caja fueron agregados correctamente.", this.Text,
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

        private void DlgCaja_Load(object sender, EventArgs e)
        {
            if (Caja.Id > 0)
            {
                txtDescripcionCaja.Text = Caja.Descripcion;
            }
        }
    }
}

