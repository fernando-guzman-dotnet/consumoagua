using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using SAPA.Clases;
using SAPA.DataSets;
using SAPA.Reportes;

namespace SAPA.Vistas
{
    public partial class FrmCorteCaja : Form
    {

        public FrmPrincipal FrmPrincipal { get; set; }

        public FrmCorteCaja()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date + new TimeSpan(0, 0, 0);
            DateTime fechaFin = dtpFechaFin.Value.Date + new TimeSpan(23, 59, 59);

            if (fechaInicio.Date > fechaFin.Date)
            {
                MessageBox.Show(
                    "La fecha inicial es superior a la fecha final. Corrija las fechas e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet dsReporte = new DataSet();


            var tablaCorteCaja = Reporte.CorteCajaByFechas(fechaInicio, fechaFin);

            if (tablaCorteCaja.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros dentro del rango de fechas especificado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable tablaCorteCajaReporte = new DataTable
            {
                TableName = "CorteCajaByFechas",
                Columns =
                {
                    {"Folio", typeof(string)},
                    {"FolioInterno", typeof(string)},
                    {"Fecha", typeof(string)},
                    {"NoContrato", typeof(string)},
                    {"MontoPagado", typeof(decimal)},
                    {"PeriodoPagado", typeof(string)}
                }
            };

            decimal totalTarjeta = 0;
            decimal totalEfectivo = 0;
            decimal totalChequesTransferencias = 0;

            decimal ingresoTotal = 0;

            foreach (DataRow fila in tablaCorteCaja.Rows)
            {

                var filaNueva = tablaCorteCajaReporte.NewRow();

                filaNueva["Folio"] = int.Parse(fila["Folio"].ToString()).ToString("D5");
                filaNueva["FolioInterno"] = fila["FolioInterno"].ToString();
                filaNueva["NoContrato"] = Int32.Parse(fila["NoContrato"].ToString()).ToString("D10");
                filaNueva["Fecha"] = DateTime.Parse(fila["Fecha"].ToString()).ToShortDateString();
                filaNueva["MontoPagado"] = decimal.Parse(fila["AdeudoTotal"].ToString());
                filaNueva["PeriodoPagado"] = string.IsNullOrWhiteSpace(fila["PeriodoInicio"].ToString()) 
                    ? "N/A"
                    : $"{DateTime.Parse(fila["PeriodoInicio"].ToString()).ToString("MMM yy", new CultureInfo("es-MX"))} - {DateTime.Parse(fila["PeriodoFin"].ToString()).ToString("MMM yy", new CultureInfo("es-MX"))}";



                tablaCorteCajaReporte.Rows.Add(filaNueva);

                decimal valorFilaActual = 0;

                switch (int.Parse(fila["IdFormaPago"].ToString()))
                {
                    case (int)Pago.Forma.Transferencia:
                    case (int)Pago.Forma.Cheque:
                        if (decimal.TryParse(fila["AdeudoTotal"].ToString(), out valorFilaActual))
                            totalChequesTransferencias = valorFilaActual;
                        break;
                    case (int)Pago.Forma.Efectivo:
                        if (decimal.TryParse(fila["AdeudoTotal"].ToString(), out valorFilaActual))
                            totalEfectivo += valorFilaActual;
                        break;
                    case (int)Pago.Forma.TarjetaDebito:
                    case (int)Pago.Forma.TarjetaCredito:
                        if (decimal.TryParse(fila["AdeudoTotal"].ToString(), out valorFilaActual))
                            totalTarjeta += valorFilaActual;
                        break;
                }

                if (decimal.TryParse(fila["AdeudoTotal"].ToString(), out valorFilaActual))
                    ingresoTotal += valorFilaActual;
            }

            DataTable tablaCorteCajaConceptos = Reporte.CorteCajaConceptosByFechas(fechaInicio, fechaFin);

            DataTable tablaCorteCajaConceptosReporte = new DataTable
            {
                TableName = "CorteCajaConceptosByFechas",
                Columns =
                {
                    {"Id", typeof(string)},
                    {"Folio", typeof(string)},
                    {"IdConcepto", typeof(string)},
                    {"DescripcionConcepto", typeof(string)},
                    {"Importe", typeof(decimal)}
                }
            };

            foreach (DataRow fila in tablaCorteCajaConceptos.Rows)
            {
                var filaNueva = tablaCorteCajaConceptosReporte.NewRow();

                filaNueva["Id"] = fila["Id"];
                filaNueva["Folio"] = int.Parse(fila["Folio"].ToString()).ToString("D5");
                filaNueva["IdConcepto"] = fila["IdConcepto"];
                filaNueva["DescripcionConcepto"] = fila["DescripcionConcepto"];
                filaNueva["Importe"] = decimal.Parse(fila["Importe"].ToString()).ToString("N2");

                tablaCorteCajaConceptosReporte.Rows.Add(filaNueva);
            }

            dsReporte.Tables.Add(tablaCorteCajaReporte);
            dsReporte.Tables.Add(tablaCorteCajaConceptosReporte);
            dsReporte.Tables.Add(Organismo.Actual);

            RptCorteCaja rpt = new RptCorteCaja();
            rpt.SetDataSource(dsReporte);


            string periodoCorteCaja = (fechaInicio.Date == fechaFin.Date) ? $"del {fechaInicio:D}" : $"del {fechaInicio:D} al {fechaFin:D}";

            rpt.SetParameterValue("PeriodoCorteCaja", periodoCorteCaja);

            rpt.SetParameterValue("totalTarjeta", $"${totalTarjeta:N2}");
            rpt.SetParameterValue("totalEfectivo", $"${totalEfectivo:N2}");
            rpt.SetParameterValue("totalChequesTransferencias", $"${totalChequesTransferencias:N2}");
            rpt.SetParameterValue("totalIngreso", $"${ingresoTotal:N2}");

            crvCorteCaja.ReportSource = rpt;

        }
    }
}

