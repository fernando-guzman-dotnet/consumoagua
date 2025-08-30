using System;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas
{
    public partial class FrmCancelarPago : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        private Contrato _contrato;
        public Contrato Contrato
        {
            get { return _contrato; }
            set
            {
                _contrato = value;

                LimpiarGUI();

                CargarPagosContrato(value);
            }
        }

        private void CargarPagosContrato(Contrato contrato)
        {
            if (contrato == null) return;

            txtNoContrato.Text = contrato.NoContrato.ToString("D10");
            txtUsuario.Text = contrato.Usuario.NombreCompleto;
            txtDireccion.Text = contrato.Direccion;

            var pagosNoCancelados = Pago.GetPagosByNoContrato(contrato.NoContrato).OrderByDescending(p => p.Fecha);
            dgvPagos.DataSource = pagosNoCancelados.Take(1).ToList();
        }

        private void LimpiarGUI()
        {
            txtNoContrato.ResetText();
            txtDireccion.ResetText();
            txtUsuario.ResetText();

            dgvPagos.DataSource = null;
        }

        public FrmCancelarPago()
        {
            InitializeComponent();
        }

        private void btnSeleccionarContrato_Click(object sender, EventArgs e)
        {
            DlgSeleccionarCuenta dlg = new DlgSeleccionarCuenta();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Contrato = dlg.Contrato;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnCancelarPago_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado ninguna fila. Seleccione una fila e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var pago = dgvPagos.CurrentRow.DataBoundItem as Pago;

            if (!pago.Cancelar())
            {
                MessageBox.Show(
                    "Hubo un error al intentar cancelar el pago seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("El pago ha sido cancelado correctamente.", this.Text, MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            CargarPagosContrato(Contrato);
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ActiveControl == txtNoContrato)
            {
                if (keyData == Keys.Back || keyData == Keys.Delete)
                {
                    txtNoContrato.ResetText();
                    txtNoContrato.SelectionStart = txtNoContrato.Mask.Length + 1;
                    return true;
                }

                if (keyData == Keys.Enter)
                {
                    int noContrato = 0;

                    if (!int.TryParse(txtNoContrato.Text, out noContrato))
                    {
                        // El no. contrato especificado tiene un formato inválido
                        // Para mantener agilidad hacemos un sonidito de error y mostramos la ventana de selección de contrato

                        SystemSounds.Exclamation.Play();

                        btnSeleccionarContrato_Click(null, null);

                        return true;
                    }

                    Contrato contrato = Contrato.GetContrato(noContrato);

                    if (contrato == null)
                    {
                        // No hay contratos con el no. de contrato especificado
                        // Para mantener agilidad hacemos un sonidito de error y mostramos la ventana de selección de contrato

                        SystemSounds.Exclamation.Play();

                        btnSeleccionarContrato_Click(null, null);

                        return true;
                    }

                    this.Contrato = contrato;

                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }



        private void txtNoContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                string cadena = txtNoContrato.Text + e.KeyChar;
                txtNoContrato.Text = cadena.Substring(1, cadena.Length - 1);
                txtNoContrato.SelectionStart = txtNoContrato.Mask.Length + 1;
            }
        }

        private void FrmCancelarPago_Load(object sender, EventArgs e)
        {

        }
    }
}

