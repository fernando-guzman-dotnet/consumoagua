using System;
using System.Windows.Forms;
using Clases;
using SAPA.Vistas.Paneles;
using SAPA.Clases;
using Exception = System.Exception;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgEstado : Form
    {

        public Estado Estado { get; set; } = new Estado();

        public DlgEstado()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtNombreEstado.Text))
            {
                MessageBox.Show("El nombre del estado no puede estar vacío. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK,
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

                bool actualizar = Estado.Id > 0;

                Estado.Nombre= Utilerias.NormalizarEspacios(txtNombreEstado.Text);

                if (actualizar)
                {
                    if (!Estado.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar el estado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del estado fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                }
                else
                {
                    if (!Estado.Agregar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar agregar el estado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del estado fueron agregados correctamente.", this.Text,
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

        private void DlgEstado_Load(object sender, EventArgs e)
        {
            if (Estado.Id > 0)
            {
                txtNombreEstado.Text = Estado.Nombre;
            }
        }
    }
}

