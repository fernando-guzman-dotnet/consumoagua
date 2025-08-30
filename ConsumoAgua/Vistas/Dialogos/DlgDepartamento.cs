using System;
using System.Windows.Forms;
using Clases;
using SAPA.Vistas.Paneles;
using SAPA.Clases;
using Exception = System.Exception;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgDepartamento : Form
    {
        public Departamento Departamento { get; set; } = new Departamento();

        public DlgDepartamento()
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

                bool actualizar = Departamento.Id > 0;

                Departamento.Descripcion = Utilerias.NormalizarEspacios(txtDescripcion.Text);

                if (actualizar)
                {
                    if (!Departamento.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar el departamento. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del departamento fueron actualizados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                }
                else
                {
                    if (!Departamento.Agregar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar Agregar el departamento. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del departamento fueron agregados correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAdd_Click - " + ex.Message, "Formulario DlgDepartamento", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void DlgDepartamento_Load(object sender, EventArgs e)
        {
            if (Departamento.Id > 0)
            {
                txtCodigo.Text = Departamento.Id.ToString("D3");
                txtDescripcion.Text = Departamento.Descripcion;
            }
            else
            {
                int ultimoDepartamento = Departamento.GetUltimoID();
                ultimoDepartamento = ultimoDepartamento == 0 ? 1 : ultimoDepartamento + 1;

                txtCodigo.Text = ultimoDepartamento.ToString("D3");
            }
        }
    }
}

