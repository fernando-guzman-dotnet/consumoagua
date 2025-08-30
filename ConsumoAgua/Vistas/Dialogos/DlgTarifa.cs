using System;
using System.Windows.Forms;
using Clases;
using Microsoft.Office.Interop.Excel;
using SAPA.Vistas.Paneles;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgTarifa : Form
    {

        public Tarifa Tarifa { get; set; } = new Tarifa();

        public DlgTarifa()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "La descripción de la tarifa no puede estar vacía. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGui()) return;

                bool actualizar = Tarifa.Id > 0;

                Tarifa.Descripcion = Utilerias.NormalizarEspacios(txtDescripcion.Text);
                Tarifa.GeneraIVA = chkGeneraIVA.Checked;

                if (actualizar)
                {
                    if (!Tarifa.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar los datos de la tarifa. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos de la tarifa se han actualizado correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!Tarifa.Guardar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar guardar los datos de la tarifa. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos de la tarifa se han registrado correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregar_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void Dialog_Tarifa_Load(object sender, EventArgs e)
        {
            if (Tarifa.Id > 0)
            {
                txtDescripcion.Text = Tarifa.Descripcion;
                chkGeneraIVA.Checked = Tarifa.GeneraIVA;
            }
        }
    }
}

