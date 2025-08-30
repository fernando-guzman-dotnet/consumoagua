using System;
using System.Windows.Forms;
using Clases;
using SAPA.Vistas.Paneles;
using SAPA.Clases;
using Exception = System.Exception;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgBanco : Form
    {

        public Banco Banco { get; set; } = new Banco();

        public DlgBanco()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtNombreBanco.Text))
            {
                MessageBox.Show("El nombre del banco no puede estar vacío. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK,
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

                bool actualizar = Banco.Id > 0;

                Banco.Nombre= Utilerias.NormalizarEspacios(txtNombreBanco.Text);

                if (actualizar)
                {
                    if (!Banco.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar el banco. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del banco fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                }
                else
                {
                    if (!Banco.Agregar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar agregar el banco. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del banco fueron agregados correctamente.", this.Text,
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

        private void DlgBanco_Load(object sender, EventArgs e)
        {
            if (Banco.Id > 0)
            {
                txtNombreBanco.Text = Banco.Nombre;
            }
        }
    }
}

