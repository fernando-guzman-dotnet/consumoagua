using System;
using System.Windows.Forms;
using SAPA.Vistas.Paneles;
using SAPA.Clases;
using Exception = System.Exception;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgMedidor : Form
    {

        public Medidor Medidor { get; set; } = new Medidor();

        public DlgMedidor()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {

            if (string.IsNullOrWhiteSpace(txtNoMedidor.Text))
            {
                MessageBox.Show("El número del medidor no puede estar vacío. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("La marca del medidor no puede estar vacía. Complete el campo e intente nuevamente.", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var noMedidor = int.Parse(txtNoMedidor.Text);

                if (noMedidor <= 0)
                {
                    MessageBox.Show(
                        "El número del medidor ingresado no es válido. Revise el campo e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "El número del medidor debe ser ingresado como un número. Revise el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "El número del medidor debe ser ingresado como un número. Revise el campo e intente nuevamente.",
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

                bool actualizar = Medidor.Id > 0;

                Medidor.NoMedidor = int.Parse(txtNoMedidor.Text);
                Medidor.Marca = txtMarca.Text;
                Medidor.Estatus = chkEstatus.Checked;

                if (actualizar)
                {
                    if (!Medidor.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar los datos del medidor. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del medidor fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (Medidor.Existe(Medidor.NoMedidor))
                    {
                        MessageBox.Show(
                            "El número de medidor ingresado ya está siendo usado. Ingrese uno nuevo e intente nuevamente.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!Medidor.Guardar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar registrar los datos del medidor. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del medidor fueron registrados correctamente.", this.Text,
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
            if (Medidor.Id > 0)
            {
                txtNoMedidor.Text = Medidor.NoMedidor.ToString();
                txtMarca.Text = Medidor.Marca;
                chkEstatus.Checked = Medidor.Estatus;
            }
            else
            {
                chkEstatus.Checked = true;
            }
        }
    }
}

