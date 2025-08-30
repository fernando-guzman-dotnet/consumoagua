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
    public partial class FrmReimpresionRecibo : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        public FrmReimpresionRecibo()
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

            dgvPagos.DataSource = Pago.GetPagosByNoContrato(Contrato.NoContrato);

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

            var pago =  dgvPagos.CurrentRow.DataBoundItem as Pago;

            // Imprimir ticket y asignar parametros

            RptReciboPago rpt = new RptReciboPago();

            DataSet dsReporte = new DataSet();

            dsReporte.Tables.Add(Organismo.Actual);

            // Datos del encabezado
            rpt.SetDataSource(dsReporte);

            // Parametros del recibo
            rpt.SetParameterValue("Titulo", "RECIBO DE PAGO");
            rpt.SetParameterValue("Folio", pago.Id.ToString("D5"));

            rpt.SetParameterValue("NoContrato", Contrato.NoContrato.ToString("D10"));
            rpt.SetParameterValue("NombreContribuyente", Contrato.NombreUsuario);
            rpt.SetParameterValue("Direccion", Contrato.Direccion);

            if (pago.Detalles.PeriodoInicio == default(DateTime) && pago.Detalles.PeriodoFin == default(DateTime))
                rpt.SetParameterValue("PeriodoPago", "N/A");
            else
                rpt.SetParameterValue("PeriodoPago", $"{pago.Detalles.PeriodoInicio.ToString("MMMM yyyy", new CultureInfo("es-MX"))} - {pago.Detalles.PeriodoFin.ToString("MMMM yyyy", new CultureInfo("es-MX"))}".ToUpper());

            rpt.SetParameterValue("Tarifa", Contrato.NombreTarifa);
            rpt.SetParameterValue("FormaPago", (pago.FormaPago == null) ? "N/A" : pago.FormaPago.Descripcion);


            rpt.SetParameterValue("Agua", pago.Detalles.Agua.ToString("N2"));
            rpt.SetParameterValue("Alcantarillado", pago.Detalles.Alcantarillado.ToString("N2"));
            rpt.SetParameterValue("Saneamiento", pago.Detalles.Saneamiento.ToString("N2"));
            rpt.SetParameterValue("Multas", pago.Detalles.Multas.ToString("N2"));
            rpt.SetParameterValue("Recargos", pago.Detalles.Recargos.ToString("N2"));
            rpt.SetParameterValue("Otros", pago.Detalles.ConceptosAdicionales.Sum(ca => ca.Importe).ToString("N2"));
            rpt.SetParameterValue("IVA", pago.Detalles.IVA.ToString("N2"));
            rpt.SetParameterValue("Redondeo", pago.Detalles.Redondeo.ToString("N2"));
            rpt.SetParameterValue("AdeudoTotal", pago.Detalles.AdeudoTotal.ToString("N2"));

            rpt.SetParameterValue("DescuentoAgua", pago.Detalles.DescuentoTemporal.PorcentajeAgua > 0 ? $"- {(pago.Detalles.DescuentoTemporal.PorcentajeAgua * 100).ToString("N2")}%" : " ");
            rpt.SetParameterValue("DescuentoAlcantarillado", pago.Detalles.DescuentoTemporal.PorcentajeAlcantarillado > 0 ? $"- {(pago.Detalles.DescuentoTemporal.PorcentajeAlcantarillado * 100).ToString("N2")}%" : " ");
            rpt.SetParameterValue("DescuentoSaneamiento", pago.Detalles.DescuentoTemporal.PorcentajeSaneamiento > 0 ? $"- {(pago.Detalles.DescuentoTemporal.PorcentajeSaneamiento * 100).ToString("N2")}%" : " ");
            rpt.SetParameterValue("DescuentoMultas", pago.Detalles.DescuentoTemporal.PorcentajeMultas > 0 ? $"- {(pago.Detalles.DescuentoTemporal.PorcentajeMultas * 100).ToString("N2")}%" : " ");
            rpt.SetParameterValue("DescuentoRecargos", pago.Detalles.DescuentoTemporal.PorcentajeRecargos > 0 ? $"- {(pago.Detalles.DescuentoTemporal.PorcentajeRecargos * 100).ToString("N2")}%" : " ");
            rpt.SetParameterValue("DescuentoIVA", pago.Detalles.DescuentoTemporal.PorcentajeIVA > 0 ? $"- {(pago.Detalles.DescuentoTemporal.PorcentajeIVA * 100).ToString("N2")}%" : " ");


            rpt.SetParameterValue("DescuentoTotal", pago.Detalles.DescuentoValores.Total > 0 ? $"- {pago.Detalles.DescuentoValores.Total.ToString("N2")}" : " ");

            rpt.SetParameterValue("FechaPago", $"{pago.Fecha.ToShortDateString()} {pago.Fecha.ToShortTimeString()}");
            rpt.SetParameterValue("TotalEnLetra", Utilerias.CantidadEnLetras(pago.Detalles.AdeudoTotal));

            string cadenaListadoConceptos = string.Empty;

            foreach (ConceptoAdicional ca in pago.Detalles.ConceptosAdicionales)
            {
                cadenaListadoConceptos += $"{ca.Concepto.Descripcion}\t{ca.Importe.ToString("N2")}\n";
            }

            rpt.SetParameterValue("CadenaListadoConceptos", string.IsNullOrWhiteSpace(cadenaListadoConceptos) ? " " : cadenaListadoConceptos);

            DlgVistaPreviaReporte dlg = new DlgVistaPreviaReporte();
            dlg.Reporte = rpt;
            dlg.Show();

        }
    }
}

