using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgDescuento : Form
    {
        public Descuento Descuento { get; set; } = new Descuento();

        public DlgDescuento()
        {
            InitializeComponent();
        }

        private void DlgDescuento_Load(object sender, EventArgs e)
        {
            CargarCmbTiposDescuento();

            if (Descuento.Id > 0)
            {
                cmbTiposDescuento.SelectedValue = Descuento.IdTipoDescuento;

                txtAgua.Text = Descuento.PorcentajeAgua.ToString("N2");
                txtAlcantarillado.Text = Descuento.PorcentajeAlcantarillado.ToString("N2");
                txtSaneamiento.Text = Descuento.PorcentajeSaneamiento.ToString("N2");
                txtRecargos.Text = Descuento.PorcentajeRecargos.ToString("N2");
                txtMultas.Text = Descuento.PorcentajeMultas.ToString("N2");
                txtGastosEjecucion.Text = Descuento.PorcentajeGastosEjecucion.ToString("N2");
                txtIVA.Text = Descuento.PorcentajeIVA.ToString("N2");
            }
        }

        private void CargarCmbTiposDescuento()
        {
            List<TipoDescuento> tiposDescuento = new List<TipoDescuento>(TipoDescuento.GetTiposDescuento());

            if (tiposDescuento.Count > 0)
            {
                tiposDescuento.Insert(0, new TipoDescuento { Id = 0, Descripcion = "[ -- SELECCIONAR TIPO DE DESCUENTO -- ]"});
                cmbTiposDescuento.DataSource = tiposDescuento;
                cmbTiposDescuento.DisplayMember = "Descripcion";
                cmbTiposDescuento.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No hay tipos de descuento registrados. Revise el catálogo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
            }
        }



        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtAgua.Text))
            {
                MessageBox.Show(
                    "El campo para el porcentaje de Agua no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAlcantarillado.Text))
            {
                MessageBox.Show(
                    "El campo para el porcentaje de Alcantarillado no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSaneamiento.Text))
            {
                MessageBox.Show(
                    "El campo para el porcentaje de Saneamiento no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRecargos.Text))
            {
                MessageBox.Show(
                    "El campo para el porcentaje de Recargos no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMultas.Text))
            {
                MessageBox.Show(
                    "El campo para el porcentaje de Multas no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGastosEjecucion.Text))
            {
                MessageBox.Show(
                    "El campo para el porcentaje de Gastos de Ejecucion no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIVA.Text))
            {
                MessageBox.Show(
                    "El campo para el porcentaje de IVA no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            bool actualizar = Descuento.Id > 0;

            Descuento.TipoDescuento = cmbTiposDescuento.SelectedItem as TipoDescuento;
            Descuento.PorcentajeAgua = decimal.Parse(txtAgua.Text);
            Descuento.PorcentajeAlcantarillado = decimal.Parse(txtAlcantarillado.Text);
            Descuento.PorcentajeSaneamiento = decimal.Parse(txtSaneamiento.Text);
            Descuento.PorcentajeRecargos = decimal.Parse(txtRecargos.Text);
            Descuento.PorcentajeMultas = decimal.Parse(txtMultas.Text);
            Descuento.PorcentajeGastosEjecucion = decimal.Parse(txtGastosEjecucion.Text);
            Descuento.PorcentajeIVA = decimal.Parse(txtIVA.Text);

            if (actualizar)
            {
                if (!Descuento.Actualizar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar actualizar la información del descuento. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("El descuento se ha actualizado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                if (!Descuento.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar registrar la información del descuento. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("El descuento se ha registrado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void entradaDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Limitar la entrada de puntos decimales a uno

            if (e.KeyChar == '.' && _tienePunto)
            {
                e.Handled = true;
            }

            // Cancelar la entrada de cualquier tecla que no sea dígito, punto o de control

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private bool _tienePunto;
        private void entradaDecimal_KeyDown(object sender, KeyEventArgs e)
        {
            // Al presionar el punto, ya sea desde el lado izquierdo o desde el NumPad
            // Contar el numero de puntos actuales

            if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
            {
                if (sender == null) return;

                var puntos = (sender as TextBox).Text.ToCharArray().Where(c => c == '.').ToList();
                _tienePunto = puntos.Count > 0;
            }
        }

        private void seleccionarEntrada_AnyEvent(object sender, EventArgs e)
        {
            if (sender == null) return;
            (sender as TextBox).SelectAll();
        }

        private void reestablecerEntradasVacias_Leave(object sender, EventArgs e)
        {
            if (sender == null) return;

            var txtCampo = (sender as TextBox);

            if (string.IsNullOrWhiteSpace(txtCampo.Text))
                txtCampo.Text = "0.00";
        }
    }
}

