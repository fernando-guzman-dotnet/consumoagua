using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculoCobroAgua;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas
{
    public partial class FrmHistoricos : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        public FrmHistoricos()
        {
            InitializeComponent();
        }

        private Contrato _contrato;
        public Contrato Contrato
        {
            get
            {
                return _contrato;
            }
            private set
            {
                _contrato = value;

                LimpiarGUI();
                CargarContrato(value);
            }
        }


        private void FrmHistoricos_Load(object sender, EventArgs e) => LimpiarGUI();


        private void LimpiarGUI()
        {
            txtUsuario.ResetText();
            txtDireccion.ResetText();
            txtColonia.ResetText();
            txtSaldoPendienteActual.ResetText();

            lblTipoServicio.ResetText();
            lblNoMedidor.ResetText();

            lblTitulo.Visible = false;
            grpHistoricos.Visible = false;
            lblEstatus.Visible = false;

            dgvAdeudos.DataSource = null;
            dgvDescuentosAplicados.DataSource = null;
            dgvPagos.DataSource = null;
            dgvLecturas.DataSource = null;
            dgvEstatus.DataSource = null;
            dgvEstatus.AutoGenerateColumns = false;
        }

        public void CargarContrato(Contrato contrato)
        {
            if (contrato == null)
                return;

            txtUsuario.Text = contrato.Usuario.NombreCompleto;
            txtDireccion.Text = contrato.Direccion;
            txtColonia.Text = contrato.Colonia.Descripcion;

            lblTipoServicio.Text = contrato.IdTipoContrato == (int)Contrato.Tipo.CuotaFija ? "CUOTA FIJA" : "SERVICIO MEDIDO";

            if (contrato.IdTipoContrato == (int)Contrato.Tipo.ServicioMedido)
                lblNoMedidor.Text = $"MEDIDOR NO. {contrato.Medidor.Id.ToString("D3")}";

            lblEstatus.Text = contrato.Activo ? "ACTIVO" : "SUSPENDIDO";
            lblEstatus.BackColor = contrato.Activo ? Color.MediumSeaGreen : Color.Red;

            lblEstatus.Visible = true;

            grpHistoricos.Visible = true;
            lblTitulo.Visible = true;

            if (contrato.IdTipoContrato == (int)Contrato.Tipo.ServicioMedido)
            {
                // Agregar pestaña "Lecturas" solo si el servicio es medido
                tabControl.TabPages.Insert(2, tpLecturas);
            }
            else
            {
                // Quitar pestaña "Lecturas" en contratos de cuota fija
                if (tabControl.Controls.Contains(tpLecturas))
                    tabControl.TabPages.Remove(tpLecturas);
            }

            // Cargar adeudos

            var cobroAgua = CobroAgua.GetContratoAdeudos(Contrato.NoContrato);

            if (cobroAgua.Tables["ERRORES"] != null)
            {
                MessageBox.Show(cobroAgua.Tables["ERRORES"].Rows[0]["ERROR"] + "\n\nNo se pueden calcular los adeudos ni cargar los descuentos aplicados en contratos suspendidos.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                contrato.Adeudos = new List<AdeudoVista>();

                foreach (DataRow fila in cobroAgua.Tables["DETALLES"].Rows)
                {
                    AdeudoVista adeudo = new AdeudoVista();
                    adeudo = fila;
                    contrato.Adeudos.Add(adeudo);
                }

                dgvAdeudos.DataSource = contrato.Adeudos;

                if(cobroAgua.Tables["DESCUENTOS"] != null)
                    dgvDescuentosAplicados.DataSource = cobroAgua.Tables["DESCUENTOS"];

                var adeudoTotal = decimal.Parse(cobroAgua.Tables["RESUMEN"].Rows[0]["AdeudoTotal"].ToString());

                txtSaldoPendienteActual.Text = adeudoTotal.ToString("N2");

            }

            if (contrato.IdTipoContrato == (int)Contrato.Tipo.ServicioMedido)
                dgvLecturas.DataSource = Medicion.GetMedicionesByNoContrato(contrato.NoContrato);

            dgvPagos.DataSource = Pago.GetPagosByNoContrato(Contrato.NoContrato);

            dgvEstatus.DataSource = ContratoHistoricoEstatus.GetContratoHistoricoEstatus(contrato.NoContrato);
        }


        private void btnSeleccionarCuenta_Click(object sender, EventArgs e)
        {
            DlgSeleccionarCuenta dlg = new DlgSeleccionarCuenta();

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            this.Contrato = dlg.Contrato;
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

                        DlgSeleccionarCuenta dlg = new DlgSeleccionarCuenta();

                        Contrato = null;

                        if (dlg.ShowDialog() != DialogResult.OK)
                        {
                            return true;
                        }
                        return true;
                    }

                    Contrato contrato = Contrato.GetContrato(noContrato);

                    if (contrato == null)
                    {
                        // No hay contratos con el no. de contrato especificado
                        // Para mantener agilidad hacemos un sonidito de error y mostramos la ventana de selección de contrato

                        SystemSounds.Exclamation.Play();

                        DlgSeleccionarCuenta dlg = new DlgSeleccionarCuenta();

                        Contrato = null;

                        if (dlg.ShowDialog() != DialogResult.OK)
                        {
                            return true;
                        }
                    }

                    this.Contrato = contrato;

                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
    }
}

