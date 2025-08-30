using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using SAPA.Clases;
using TextBox = System.Windows.Forms.TextBox;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgTarifaFija : Form
    {
        public List<TarifaFija> TarifasFijas { get; set; }
        public Tarifa Tarifa { get; set; }

        public int AñoTarifaSeleccionada { get; set; }

        public DlgTarifaFija()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {
            if (cmbAño.SelectedIndex == -1)
            {
                MessageBox.Show("No se ha seleccionado el año de la tarifa. Seleccione el año e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidadMensual.Text))
            {
                MessageBox.Show("La cuota mensual no puede estar vacía. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidadAnual.Text))
            {
                MessageBox.Show("La cuota anual no puede estar vacía. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var cuotaMensual = decimal.Parse(txtCantidadMensual.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "La cuota mensual debe ser ingresado como un dato númerico. Corrija el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("La cuota mensual ingresada no es válida. Corrija el campo e intente nuevamente.");
                return false;
            }

            try
            {
                var cuotaAnual = decimal.Parse(txtCantidadAnual.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "La cuota mensual debe ser ingresado como un dato númerico. Corrija el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("La cuota mensual ingresada no es válida. Corrija el campo e intente nuevamente.");
                return false;
            }

            return true;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            var tarifaFijaActual = cmbAño.SelectedItem as TarifaFija;

            bool actualizar = tarifaFijaActual.Id > 0;

            tarifaFijaActual.CantidadMensual = decimal.Parse(txtCantidadMensual.Text);
            tarifaFijaActual.CantidadAnual = decimal.Parse(txtCantidadAnual.Text);

            bool eliminar = tarifaFijaActual.CantidadMensual == 0m && tarifaFijaActual.CantidadAnual == 0m;

            if (eliminar)
            {
                // Si la cantidad para las cuotas es 0, eliminamos las tarifas fijas de la tabla para el mismo año
                tarifaFijaActual.EliminarCuotasFijas();
  
                MessageBox.Show("Las cuotas fijas de la tarifa para el año seleccionado fueron borradas correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                return;
            }



            if (actualizar)
            {
                if (!tarifaFijaActual.ActualizarCuotasFijas())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar actualizar las cuotas fijas de la tarifa. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Las cuotas fijas de la tarifa fueron actualizados correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            else
            {

                if (!tarifaFijaActual.GuardarCuotasFijas())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar guardar las cuotas fijas de la tarifa. Intente nuevamente, si el problema persiste contacte el área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Las cuotas fijas de la tarifa fueron guardadas correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void DlgTarifaFija_Load(object sender, EventArgs e)
        {
            if (Tarifa.Id > 0)
            {
                txtTarifa.Text = Tarifa.Descripcion;

                TarifasFijas = TarifaFija.GetTarifasFijasByIdTarifa(Tarifa.Id);

                if (!TarifasFijas.Any())
                {
                    // Al ser la primer cuota asignada, partimos del año seleccionado

                    TarifasFijas.Add(new TarifaFija
                    {
                        IdTarifa = Tarifa.Id,
                        Año = AñoTarifaSeleccionada
                    });
                }

                cmbAño.DataSource = TarifasFijas.OrderByDescending(tf => tf.Año).ToList();
                cmbAño.SelectedValue = AñoTarifaSeleccionada;
            }
            else
            {
                MessageBox.Show(
                    "No se cargó una tarifa. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }

        private void cmbAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAño.SelectedIndex == -1) return;

            TarifaFija tarifaFija = cmbAño.SelectedItem as TarifaFija;

            txtCantidadAnual.Text = tarifaFija.CantidadAnual.ToString("N2");
            txtCantidadMensual.Text = tarifaFija.CantidadMensual.ToString("N2");
        }


        private void entradaPersonalizada_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ya hay 4 carácteres
            if (_tieneCuatroCaracteres && (sender as TextBox).SelectedText.Length != 4 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Cancelar la entrada de cualquier tecla que no sea dígito o de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool _tieneCuatroCaracteres;
        private void entradaPersonalizada_KeyDown(object sender, KeyEventArgs e)
        {
            _tieneCuatroCaracteres = (sender as TextBox).Text.Length == 4;
        }

        private void btnAgregarAño_Click(object sender, EventArgs e)
        {
            int año = 0;

            if (!int.TryParse(txtAño.Text, out año))
            {
                MessageBox.Show("El año ingresado no es válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TarifasFijas.Add(new TarifaFija
            {
                IdTarifa = Tarifa.Id,
                Año =  año
            });

            cmbAño.DataSource = TarifasFijas.OrderByDescending(tf => tf.Año).ToList();
            cmbAño.SelectedValue = año;

            MessageBox.Show(
                "El año ingresado se agregó a la lista correctamente. Para guardar la tarifa fija para ese año complete los campos 'Cuota Mensual' y 'Cuota Anual'.",
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

