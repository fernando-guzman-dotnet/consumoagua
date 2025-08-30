using System;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas
{
    public partial class FrmArqueo : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }
        public Arqueo Arqueo { get; set; } = new Arqueo();

        public FrmArqueo()
        {
            InitializeComponent();
        }

        private void ActualizarGui()
        {
            decimal totalEfectivo = 0;

            // Monedas

            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtCincuentaCentavos.Text) ? "0" : txtCincuentaCentavos.Text) * 0.50m;
            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtUnPeso.Text) ? "0" : txtUnPeso.Text) * 1.00m;
            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtDosPesos.Text) ? "0" : txtDosPesos.Text) * 2.00m;
            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtCincoPesos.Text) ? "0" : txtCincoPesos.Text) * 5.00m;
            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtDiezPesos.Text) ? "0" : txtDiezPesos.Text) * 10.00m;

            // Billetes

            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtVeintePesos.Text) ? "0" : txtVeintePesos.Text) * 20.00m;
            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtCincuentaPesos.Text) ? "0" : txtCincuentaPesos.Text) * 50.00m;
            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtCienPesos.Text) ? "0" : txtCienPesos.Text) * 100.00m;
            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtDoscientosPesos.Text) ? "0" : txtDoscientosPesos.Text) * 200.00m;
            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtQuinientosPesos.Text) ? "0" : txtQuinientosPesos.Text) * 500.00m;
            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtMilPesos.Text) ? "0" : txtMilPesos.Text) * 1000.00m;

            // Otros

            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtVaucher.Text) ? "0.00" : txtVaucher.Text);
            totalEfectivo += decimal.Parse(string.IsNullOrWhiteSpace(txtChequesTransferencias.Text) ? "0.00" : txtChequesTransferencias.Text);

            txtTotalEfectivo.Text = totalEfectivo.ToString("N2");
        }

        private void CargarArqueoGui()
        {
            LimpiarGui();

            if (Arqueo.Id > 0)
            {
                // Monedas

                txtCincuentaCentavos.Text = Arqueo.MonedasCincuentaCentavos.ToString("D");
                txtUnPeso.Text = Arqueo.MonedasUnPeso.ToString("D");
                txtDosPesos.Text = Arqueo.MonedasDosPesos.ToString("D");
                txtCincoPesos.Text = Arqueo.MonedasCincoPesos.ToString("D");
                txtDiezPesos.Text = Arqueo.MonedasDiezPesos.ToString("D");

                // Billetes

                txtVeintePesos.Text = Arqueo.BilletesVeintePesos.ToString("D");
                txtCincuentaPesos.Text = Arqueo.BilletesCincuentaPesos.ToString("D");
                txtCienPesos.Text = Arqueo.BilletesCienPesos.ToString("D");
                txtDoscientosPesos.Text = Arqueo.BilletesDoscientosPesos.ToString("D");
                txtQuinientosPesos.Text = Arqueo.BilletesQuinientosPesos.ToString("D");
                txtMilPesos.Text = Arqueo.BilletesMilPesos.ToString("D");

                // Otros

                txtVaucher.Text = Arqueo.Vauchers.ToString("N2");
                txtChequesTransferencias.Text = Arqueo.ChequesTransferencias.ToString("N2");
            }

            ActualizarGui();
        }

        private void LimpiarGui()
        {
            // Monedas

            txtCincuentaCentavos.Text = "0";
            txtUnPeso.Text = "0";
            txtDosPesos.Text = "0";
            txtCincoPesos.Text = "0";
            txtDiezPesos.Text = "0";

            // Billetes

            txtVeintePesos.Text = "0";
            txtCincuentaPesos.Text = "0";
            txtCienPesos.Text = "0";
            txtDoscientosPesos.Text = "0";
            txtQuinientosPesos.Text = "0";
            txtMilPesos.Text = "0";

            // Otros

            txtVaucher.Text = "0.00";
            txtChequesTransferencias.Text = "0.00";

            // Total efectivo

            txtTotalEfectivo.Text = "0.00";
        }

        private bool ValidarGui()
        {
            if (decimal.Parse(txtTotalEfectivo.Text) <= 0)
            {
                MessageBox.Show("El total de efectivo del arqueo debe ser mayor a cero.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Campos vacíos

            if (string.IsNullOrWhiteSpace(txtCincuentaCentavos.Text))
            {
                MessageBox.Show("El campo \"Cincuenta Centavos\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUnPeso.Text))
            {
                MessageBox.Show("El campo \"Un Peso\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDosPesos.Text))
            {
                MessageBox.Show("El campo \"Dos Pesos\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCincoPesos.Text))
            {
                MessageBox.Show("El campo \"Cinco Pesos\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiezPesos.Text))
            {
                MessageBox.Show("El campo \"Diez Pesos\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtVeintePesos.Text))
            {
                MessageBox.Show("El campo \"Veinte Pesos\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCincuentaPesos.Text))
            {
                MessageBox.Show("El campo \"Cincuenta Pesos\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCienPesos.Text))
            {
                MessageBox.Show("El campo \"Cien Pesos\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDoscientosPesos.Text))
            {
                MessageBox.Show("El campo \"Doscientos Pesos\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtQuinientosPesos.Text))
            {
                MessageBox.Show("El campo \"Quinientos Pesos\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMilPesos.Text))
            {
                MessageBox.Show("El campo \"Mil Pesos\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtVaucher.Text))
            {
                MessageBox.Show("El campo \"Váucher\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtChequesTransferencias.Text))
            {
                MessageBox.Show("El campo \"Cheques y transferencias\" no puede quedar vacío. Ingresa 0 para omitir el campo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Cantidades negativas

            if (int.Parse(txtCincuentaCentavos.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Cincuenta Centavos\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(txtUnPeso.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Un Peso\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(txtDosPesos.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Dos Pesos\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(txtCincoPesos.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Cinco Pesos\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(txtDiezPesos.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Diez Pesos\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(txtVeintePesos.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Veinte Pesos\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(txtCincuentaPesos.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Cincuenta Pesos\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(txtCienPesos.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Cien Pesos\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(txtDoscientosPesos.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Doscientos Pesos\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(txtQuinientosPesos.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Quinientos Pesos\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(txtMilPesos.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Mil Pesos\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (decimal.Parse(txtVaucher.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Vaucher\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (decimal.Parse(txtChequesTransferencias.Text) < 0)
            {
                MessageBox.Show("El valor ingresado para el campo \"Cheques y Transferencias\" no debe ser menor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar

            if (!ValidarGui()) return;

            Arqueo.MonedasCincuentaCentavos = int.Parse(txtCincuentaCentavos.Text);
            Arqueo.MonedasUnPeso = int.Parse(txtUnPeso.Text);
            Arqueo.MonedasDosPesos = int.Parse(txtDosPesos.Text);
            Arqueo.MonedasCincoPesos = int.Parse(txtCincoPesos.Text);
            Arqueo.MonedasDiezPesos = int.Parse(txtDiezPesos.Text);
            Arqueo.BilletesVeintePesos = int.Parse(txtVeintePesos.Text);
            Arqueo.BilletesCincuentaPesos = int.Parse(txtCincuentaPesos.Text);
            Arqueo.BilletesCienPesos = int.Parse(txtCienPesos.Text);
            Arqueo.BilletesDoscientosPesos = int.Parse(txtDoscientosPesos.Text);
            Arqueo.BilletesQuinientosPesos = int.Parse(txtQuinientosPesos.Text);
            Arqueo.BilletesMilPesos = int.Parse(txtMilPesos.Text);

            Arqueo.Vauchers = decimal.Parse(txtVaucher.Text);
            Arqueo.ChequesTransferencias = decimal.Parse(txtChequesTransferencias.Text);

            bool actualizar = Arqueo.Id > 0;

            if (actualizar)
            {
                if (!Arqueo.Actualizar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar actualizar los datos del arqueo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Los datos del arqueo fueron actualizados correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Arqueo.Fecha = dtpFechaArqueo.Value;
                if (!Arqueo.Guardar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar guardar los datos del arqueo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Los datos del arqueo fueron guardados correctamente.", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            dtpFechaArqueo_ValueChanged(null, null);
        }

        private void dtpFechaArqueo_ValueChanged(object sender, EventArgs e)
        {
            // Al actualizar la fecha, cargar el arqueo y detalles correspondientes

            Arqueo = Arqueo.GetArqueoByFecha(dtpFechaArqueo.Value);
            CargarArqueoGui();
        }


        private void entradaNumerica_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cancelar la entrada de cualquier tecla que no sea dígito, punto o de control

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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

        private void entradaActualizada_TextChanged(object sender, EventArgs e) => ActualizarGui();

        private void frmArqueo_FormClosing(object sender, FormClosingEventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void frmArqueo_Shown(object sender, EventArgs e) => dtpFechaArqueo_ValueChanged(null, null);

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
    }
}

