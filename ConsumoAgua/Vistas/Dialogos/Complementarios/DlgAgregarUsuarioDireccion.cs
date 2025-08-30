using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgAgregarUsuarioDireccion : Form
    {
        public Usuario Usuario { get; set; } = new Usuario();
        public UsuarioDireccion UsuarioDireccion { get; set; } = new UsuarioDireccion();

        public DlgAgregarUsuarioDireccion()
        {
            InitializeComponent();
        }

        private void DlgAgregarUsuarioDireccion_Load(object sender, EventArgs e)
        {
            if (UsuarioDireccion.Id > 0)
            {
                txtEstado.Text = UsuarioDireccion.Estado;
                txtMunicipio.Text = UsuarioDireccion.Municipio;
                txtColonia.Text = UsuarioDireccion.Colonia;
                txtCalle.Text = UsuarioDireccion.Calle;
                txtCodigoPostal.Text = UsuarioDireccion.CodigoPostal;
                txtNoExterior.Text = UsuarioDireccion.NumeroExterior;
                txtNoInterior.Text = UsuarioDireccion.NumeroInterior;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioDireccion.IdUsuario = Usuario.Id;
            UsuarioDireccion.Estado = Utilerias.NormalizarEspacios(txtEstado.Text);
            UsuarioDireccion.Municipio = Utilerias.NormalizarEspacios(txtMunicipio.Text);
            UsuarioDireccion.Colonia = Utilerias.NormalizarEspacios(txtColonia.Text);
            UsuarioDireccion.Calle = Utilerias.NormalizarEspacios(txtCalle.Text);
            UsuarioDireccion.CodigoPostal = Utilerias.NormalizarEspacios(txtCodigoPostal.Text);
            UsuarioDireccion.NumeroExterior = Utilerias.NormalizarEspacios(txtNoExterior.Text);
            UsuarioDireccion.NumeroInterior = Utilerias.NormalizarEspacios(txtNoInterior.Text);

            bool actualizar = UsuarioDireccion.Id > 0;

            if (actualizar)
            {
                if (!UsuarioDireccion.Actualizar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar actualizar los datos de la dirección del usuario. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("La dirección del usuario ha sido actualizada correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                if (!UsuarioDireccion.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar registrar los datos de la dirección del usuario. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("La dirección del usuario ha sido registrada correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void Direccion_TextChanged(object sender, EventArgs e)
        {
            var calle = string.IsNullOrWhiteSpace(txtCalle.Text) ? string.Empty : txtCalle.Text;
            var noExterior = string.IsNullOrWhiteSpace(txtNoExterior.Text) ? string.Empty : $" No. {txtNoExterior.Text}";
            var noInterior = string.IsNullOrWhiteSpace(txtNoInterior.Text) ? string.Empty : $" Int. {txtNoInterior.Text}";
            var colonia = string.IsNullOrWhiteSpace(txtColonia.Text) ? string.Empty : $"Col. {txtColonia.Text}";
            var codigoPostal = string.IsNullOrWhiteSpace(txtCodigoPostal.Text) ? string.Empty : $"CP. {txtCodigoPostal.Text} ";
            var municipio = string.IsNullOrWhiteSpace(txtMunicipio.Text) ? string.Empty : txtMunicipio.Text;
            var estado = string.IsNullOrWhiteSpace(txtEstado.Text) ? string.Empty : txtEstado.Text;

            txtPrevisualizacionDireccion.Text = $"{calle}{noExterior}{noInterior}, {colonia}, {codigoPostal}{municipio}, {estado}".ToUpper();
        }


    }
}

