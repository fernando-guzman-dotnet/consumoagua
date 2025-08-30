using System;
using System.Windows.Forms;
using Clases;
using SAPA.Vistas.Paneles;
using SAPA.Clases;
using Exception = System.Exception;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgConcepto : Form
    {

        public Concepto Concepto { get; set; } = new Concepto();

        public DlgConcepto()
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

            if (string.IsNullOrWhiteSpace(txtImporte.Text))
            {
                MessageBox.Show("El importe no puede estar vacía. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var importe = decimal.Parse(txtImporte.Text);

                if (importe < 0)
                {
                    MessageBox.Show("El importe debe ser ingresado como un entero positivo.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El importe solo puede ser ingresado como un numero entero o decimal.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGui()) return;

                bool actualizar = Concepto.Id > 0;

                Concepto.Descripcion = Utilerias.NormalizarEspacios(txtDescripcion.Text);
                Concepto.Importe = decimal.Parse(txtImporte.Text);
                Concepto.EsFijo = chkImporteFijo.Checked;
                Concepto.AplicaIVA = chkAplicaIVA.Checked;

                if (actualizar)
                {
                    if (!Concepto.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar el concepto. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del concepto fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                }
                else
                {
                    if (!Concepto.Guardar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar Agregar el concepto. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del concepto fueron agregados correctamente.", this.Text,
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

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void DlgConcepto_Load(object sender, EventArgs e)
        {
            if (Concepto.Id > 0)
            {
                txtDescripcion.Text = Concepto.Descripcion;
                txtImporte.Text = Concepto.Importe.ToString();
                chkImporteFijo.Checked = Concepto.EsFijo;
                chkAplicaIVA.Checked = Concepto.AplicaIVA;
            }
        }
    }
}

