using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculoCobroAgua;
using Clases;
using SAPA.Clases;
using SAPA.Reportes;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas
{
    public partial class FrmReimpresionReciboConvenio : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        public FrmReimpresionReciboConvenio()
        {
            InitializeComponent();
            dgvPagos.AutoGenerateColumns = false;
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

            lblTipoServicio.ResetText();
            lblNoMedidor.ResetText();

            btnGenerar.Visible = false;

            grpPagos.Visible = false;
            dgvPagos.DataSource = null;
            
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


            var ultimoConvenioVigente = Convenio.GetConveniosByNoContrato(Contrato.NoContrato)
                .LastOrDefault(c => DateTime.Now >= c.FechaInicio && DateTime.Now <= c.FechaFin);

            if (ultimoConvenioVigente == null)
            {
                MessageBox.Show("No se pudo cargar el último convenio vigente. Contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvPagos.DataSource = PagoConvenio.GetPagosByIdConvenio(ultimoConvenioVigente.Id);

            grpPagos.Visible = true;
            btnGenerar.Visible = dgvPagos.Rows.Count > 0;
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

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dgvPagos.Rows.Count == 0 || dgvPagos.CurrentRow == null)
                return;

            var pago =  dgvPagos.CurrentRow.DataBoundItem as PagoConvenio;

            // Imprimir ticket y asignar parametros

            RptReciboPago rpt = new RptReciboPago();

            DataSet dsReporte = new DataSet();

            dsReporte.Tables.Add(Organismo.Actual);

            // Datos del encabezado
            rpt.SetDataSource(dsReporte);

            // Parametros del recibo
            rpt.SetParameterValue("Titulo", $"RECIBO DE PAGO POR CONVENIO {pago.IdConvenio:D5}");
            rpt.SetParameterValue("Folio", pago.Id.ToString("D5"));

            rpt.SetParameterValue("NoContrato", Contrato.NoContrato.ToString("D10"));
            rpt.SetParameterValue("NombreContribuyente", Contrato.NombreUsuario);
            rpt.SetParameterValue("Direccion", Contrato.Direccion);

            rpt.SetParameterValue("PeriodoPago", "N/A");
 
            rpt.SetParameterValue("Tarifa", Contrato.NombreTarifa);
            rpt.SetParameterValue("FormaPago", (pago.FormaPago == null) ? "N/A" : pago.FormaPago.Descripcion);


            rpt.SetParameterValue("Agua", "0.00");
            rpt.SetParameterValue("Alcantarillado", "0.00");
            rpt.SetParameterValue("Saneamiento", "0.00");
            rpt.SetParameterValue("Multas", "0.00");
            rpt.SetParameterValue("Recargos", "0.00");
            rpt.SetParameterValue("Otros", "0.00");
            rpt.SetParameterValue("IVA", "0.00");
            rpt.SetParameterValue("Redondeo", "0.00");
            rpt.SetParameterValue("AdeudoTotal", pago.Importe.ToString("N2"));

            rpt.SetParameterValue("DescuentoAgua", " ");
            rpt.SetParameterValue("DescuentoAlcantarillado", " ");
            rpt.SetParameterValue("DescuentoSaneamiento", " ");
            rpt.SetParameterValue("DescuentoMultas", " ");
            rpt.SetParameterValue("DescuentoRecargos", " ");
            rpt.SetParameterValue("DescuentoIVA", " ");


            rpt.SetParameterValue("DescuentoTotal", " ");

            rpt.SetParameterValue("FechaPago", $"{pago.Fecha.ToShortDateString()} {pago.Fecha.ToShortTimeString()}");
            rpt.SetParameterValue("TotalEnLetra", Utilerias.CantidadEnLetras(pago.Importe));

            rpt.SetParameterValue("CadenaListadoConceptos", " ");

            DlgVistaPreviaReporte dlg = new DlgVistaPreviaReporte();
            dlg.Reporte = rpt;
            dlg.Show();

        }
    }
}

