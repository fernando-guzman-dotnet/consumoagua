using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlAdministracion : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }
        public Organismo Organismo { get; set; }

        public PnlAdministracion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pbImagenOrganismo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                Organismo.Imagen = ms.ToArray();

                Organismo.Nombre = Utilerias.NormalizarEspacios(txtNombreOrganismo.Text);
                Organismo.RFC = Utilerias.NormalizarEspacios(txtRFC.Text);
                Organismo.Telefono = Utilerias.NormalizarEspacios(txtTelefono.Text);
                Organismo.Estado = Utilerias.NormalizarEspacios(txtEstado.Text);
                Organismo.Municipio = Utilerias.NormalizarEspacios(txtMunicipio.Text);
                Organismo.Colonia = Utilerias.NormalizarEspacios(txtColonia.Text);
                Organismo.CodigoPostal = int.Parse(txtCodigoPostal.Text);
                Organismo.Calle = Utilerias.NormalizarEspacios(txtCalle.Text);
                Organismo.NumeroExterior = Utilerias.NormalizarEspacios(txtNoExterior.Text);
                Organismo.NumeroInterior = Utilerias.NormalizarEspacios(txtNoInterior.Text);
                Organismo.DireccionCompleta = Utilerias.NormalizarEspacios(txtDireccionCompleta.Text);

                bool actualizar = Organismo.Id > 0;

                if (actualizar)
                {
                    if (!Organismo.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar los datos del organismo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del organismo fueron actualizados correctamente.", "Formulario Organismo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Organismo.Actual = Organismo;
                }
                else
                {
                    if (!Organismo.Agregar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar registrar los datos del organismo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Los datos del organismo fueron registrados correctamente.", "Formulario Organismo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Organismo.Actual = Organismo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnGuardar_Click - " + ex.Message, "Formulario Panel_Administracion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este evento está suscrito a todos los campos relacionados a la dirección y va actualizando el campo de la dirección completa

        private void Direccion_TextChanged(object sender, EventArgs e)
        {
            string calle = string.IsNullOrWhiteSpace(txtCalle.Text) ? string.Empty : txtCalle.Text;
            string noExterior = string.IsNullOrWhiteSpace(txtNoExterior.Text) ? string.Empty : $" No. {txtNoExterior.Text}";
            string noInterior = string.IsNullOrWhiteSpace(txtNoInterior.Text) ? string.Empty : $" Int. {txtNoInterior.Text}";
            string colonia = string.IsNullOrWhiteSpace(txtColonia.Text) ? string.Empty : $"Col. {txtColonia.Text}";
            string codigoPostal = string.IsNullOrWhiteSpace(txtCodigoPostal.Text) ? string.Empty : $"CP. {txtCodigoPostal.Text}";
            string municipio = string.IsNullOrWhiteSpace(txtMunicipio.Text) ? string.Empty : txtMunicipio.Text;
            string estado = string.IsNullOrWhiteSpace(txtEstado.Text) ? string.Empty : txtEstado.Text;

            txtDireccionCompleta.Text = $"{calle}{noExterior}{noInterior}, {colonia}, {codigoPostal} {municipio}, {estado}".ToUpper();
        }

        // Este evento cambia las letras presionadas a mayúsculas en todos los campos suscritos

        private void ToUpper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);
        }


        private void pbImagenOrganismo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp, *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png;";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap imagenOriginal = new Bitmap(dlg.FileName);
                Bitmap imagenRedimensionada = new Bitmap(imagenOriginal, new Size(128, 128));

                pbImagenOrganismo.Image = imagenRedimensionada;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void PnlAdministracion_FormClosing(object sender, FormClosingEventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void PnlAdministracion_Load(object sender, EventArgs e)
        {
            if (Organismo.Id > 0)
            {
                txtNombreOrganismo.Text = Organismo.Nombre;

                Image imagen = Image.FromStream(new MemoryStream(Organismo.Imagen));
                pbImagenOrganismo.Image = imagen.Resize(new Size(128, 128));

                txtRFC.Text = Organismo.RFC;
                txtTelefono.Text = Organismo.Telefono;
                txtEstado.Text = Organismo.Estado;
                txtMunicipio.Text = Organismo.Municipio;
                txtColonia.Text = Organismo.Colonia;
                txtCodigoPostal.Text = "" + Organismo.CodigoPostal;
                txtCalle.Text = Organismo.Calle;
                txtNoExterior.Text = Organismo.NumeroExterior;
                txtNoInterior.Text = Organismo.NumeroInterior;
                txtDireccionCompleta.Text = Organismo.DireccionCompleta;

                btnGuardar.Text = "Actualizar";
            }
            else
            {
                btnGuardar.Text = "Guardar";
            }
        }

    }
}

