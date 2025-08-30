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
using SAPA.Reportes;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgPagoConvenio : Form
    {
        public DlgPagoConvenio()
        {
            InitializeComponent();
        }

        public Contrato Contrato { get; set; }
        private Convenio UltimoConvenioVigente { get; set; }
        private List<PagoConvenio> PagosRealizados { get; set; }

        private void CargarBancos()
        {
            var bancos = Banco.GetBancos();
            bancos.Insert(0, new Banco { Id = 0, Nombre = "[ -- SELECCIONAR -- ]" });

            if (bancos.Count == 0)
            {
                MessageBox.Show(
                    "No hay bancos registrados. Revise el catalogo e intente nuevamente. Si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;

                return;
            }

            cmbBanco.DataSource = bancos;
            cmbBanco.DisplayMember = "Nombre";
            cmbBanco.ValueMember = "Id";
        }

        public void CargarTiposPago()
        {
            var tiposPago = FormaPago.GetFormasPago();


            if (tiposPago.Count == 0)
            {
                MessageBox.Show(
                    "No hay tipos de pago registrados. Revise el catalogo e intente nuevamente. Si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;

                return;
            }

            cmbFormaPago.DataSource = tiposPago;
            cmbFormaPago.DisplayMember = "Descripcion";
            cmbFormaPago.ValueMember = "Id";
        }

        private bool ValidarGui()
        {
            if (Empleado.Actual.IdCaja == 0)
            {
                MessageBox.Show("El empleado actual no tiene asignada una caja. Contacte a un administrador.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var formaPago = cmbFormaPago.SelectedItem as FormaPago;

            if (formaPago.Descripcion.Contains("TRANSFERENCIA") || formaPago.Descripcion.Contains("TARJETA DEBITO") ||
                formaPago.Descripcion.Contains("TARJETA CREDITO") || formaPago.Descripcion.Contains("CHEQUE"))
            {
                if (cmbBanco.SelectedIndex == 0 || cmbBanco.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "No se ha seleccionado un banco. Seleccione un banco e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtReferencia.Text))
                {
                    MessageBox.Show(
                        "El campo 'Referencia' no debe ser omitido cuando se usa la forma de pago elegida. Complete el campo e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }

            decimal cantidadPagar = 0;

            if (!decimal.TryParse(txtCantidad.Text, out cantidadPagar))
            {
                MessageBox.Show(
                    "La cantidad ingresada no es un número valido. Coriija el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cantidadPagar < 0)
            {
                MessageBox.Show(
                    "La cantidad a pagar ingresada no debe ser menor a cero. Ingrese la cantidad adecuada e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            decimal saldoPendiente = UltimoConvenioVigente.Total - PagosRealizados.Sum(pr => pr.Importe);

            if (cantidadPagar > saldoPendiente)
            {
                MessageBox.Show(
                    "La cantidad a pagar ingresada no debe ser mayor al saldo pendiente. Ingrese la cantidad adecuada e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }



        private void DlgPagoConvenio_Load(object sender, EventArgs e)
        {
            CargarBancos();
            CargarTiposPago();

            if (Contrato == null)
            {
                MessageBox.Show(
                    "No se ha cargado un contrato. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Contrato.Convenios.Count == 0)
            {
                MessageBox.Show("El contrato no tiene convenios establecidos. Establezca uno e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
                return;
            }

            UltimoConvenioVigente = Convenio.GetConveniosByNoContrato(Contrato.NoContrato)
                .LastOrDefault(c => DateTime.Now >= c.FechaInicio && DateTime.Now <= c.FechaFin);

            if (UltimoConvenioVigente == null)
            {
                MessageBox.Show("No se pudo cargar el último convenio vigente. Contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PagosRealizados = PagoConvenio.GetPagosByIdConvenio(UltimoConvenioVigente.Id);

            txtTotalEstablecido.Text = UltimoConvenioVigente.Total.ToString("N2");
            txtSaldoPendiente.Text = (UltimoConvenioVigente.Total - PagosRealizados.Sum(pr => pr.Importe)).ToString("N2");

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            var formaPago = cmbFormaPago.SelectedItem as FormaPago;

            bool requiereReferencia = formaPago.Descripcion.Contains("TRANSFERENCIA") ||
                                      formaPago.Descripcion.Contains("TARJETA DEBITO") ||
                                      formaPago.Descripcion.Contains("TARJETA CREDITO") ||
                                      formaPago.Descripcion.Contains("CHEQUE");

            PagoConvenio pagoConvenio = new PagoConvenio
            {
                IdConvenio = UltimoConvenioVigente.Id,
                Fecha = DateTime.Now,
                FormaPago = formaPago,
                Empleado = Empleado.Actual,
                Caja = new Caja { Id = Empleado.Actual.IdCaja },
                Banco = (requiereReferencia) ? cmbBanco.SelectedItem as Banco : new Banco { Id = 0 },
                Referencia = (requiereReferencia) ? txtReferencia.Text : string.Empty,
                Importe = decimal.Parse(txtCantidad.Text)
            };

            if (!pagoConvenio.Agregar())
            {
                MessageBox.Show(
                    "Hubo un problema al intentar registar el pago al convenio. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("El pago al convenio ha sido registrado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;

            RptReciboPago rpt = new RptReciboPago();

            DataSet dsReporte = new DataSet();

            dsReporte.Tables.Add(Organismo.Actual);

            // Datos del encabezado
            rpt.SetDataSource(dsReporte);

            // Parametros del recibo
            rpt.SetParameterValue("Titulo", $"RECIBO DE PAGO POR CONVENIO {pagoConvenio.IdConvenio:D5}");
            rpt.SetParameterValue("Folio", pagoConvenio.Id.ToString("D5"));

            rpt.SetParameterValue("NoContrato", Contrato.NoContrato.ToString("D10"));
            rpt.SetParameterValue("NombreContribuyente", Contrato.NombreUsuario);
            rpt.SetParameterValue("Direccion", Contrato.Direccion);

            rpt.SetParameterValue("PeriodoPago", "N/A");

            rpt.SetParameterValue("Tarifa", Contrato.NombreTarifa);
            rpt.SetParameterValue("FormaPago", (pagoConvenio.FormaPago == null) ? "N/A" : pagoConvenio.FormaPago.Descripcion);


            rpt.SetParameterValue("Agua", "0.00");
            rpt.SetParameterValue("Alcantarillado", "0.00");
            rpt.SetParameterValue("Saneamiento", "0.00");
            rpt.SetParameterValue("Multas", "0.00");
            rpt.SetParameterValue("Recargos", "0.00");
            rpt.SetParameterValue("Otros", "0.00");
            rpt.SetParameterValue("IVA", "0.00");
            rpt.SetParameterValue("Redondeo", "0.00");
            rpt.SetParameterValue("AdeudoTotal", pagoConvenio.Importe.ToString("N2"));

            rpt.SetParameterValue("DescuentoAgua", " ");
            rpt.SetParameterValue("DescuentoAlcantarillado", " ");
            rpt.SetParameterValue("DescuentoSaneamiento", " ");
            rpt.SetParameterValue("DescuentoMultas", " ");
            rpt.SetParameterValue("DescuentoRecargos", " ");
            rpt.SetParameterValue("DescuentoIVA", " ");


            rpt.SetParameterValue("DescuentoTotal", " ");

            rpt.SetParameterValue("FechaPago", $"{pagoConvenio.Fecha.ToShortDateString()} {pagoConvenio.Fecha.ToShortTimeString()}");
            rpt.SetParameterValue("TotalEnLetra", Utilerias.CantidadEnLetras(pagoConvenio.Importe));

            rpt.SetParameterValue("CadenaListadoConceptos", " ");


            DlgVistaPreviaReporte dlg = new DlgVistaPreviaReporte();
            dlg.Reporte = rpt;
            dlg.Show();
        }


        private void cmbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

            string nombreFormaPago = (cmbFormaPago.SelectedItem as FormaPago).Descripcion;

            switch (nombreFormaPago)
            {
                case "EFECTIVO":
                    lblReferencia.Visible = false;
                    txtReferencia.Visible = false;

                    lblBanco.Visible = false;
                    cmbBanco.Visible = false;

                    break;


                case "TRANSFERENCIA":
                case "TARJETA DEBITO":
                case "TARJETA CREDITO":
                    lblReferencia.Text = "Referencia";

                    lblReferencia.Visible = true;
                    txtReferencia.Visible = true;

                    lblBanco.Visible = true;
                    cmbBanco.Visible = true;
                    break;

                case "CHEQUE":
                    lblReferencia.Text = "No. Cheque";

                    lblReferencia.Visible = true;
                    txtReferencia.Visible = true;

                    lblBanco.Visible = true;
                    cmbBanco.Visible = true;
                    break;

                default:
                    lblReferencia.Text = "Referencia";

                    lblReferencia.Visible = false;
                    txtReferencia.Visible = false;

                    lblBanco.Visible = false;
                    cmbBanco.Visible = false;
                    break;

            }

        }
    }
}

