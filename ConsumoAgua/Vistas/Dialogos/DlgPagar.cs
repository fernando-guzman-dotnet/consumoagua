using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Reportes;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgPagar : Form
    {
        public DlgPagar()
        {
            InitializeComponent();
        }

        public Contrato Contrato { get; set; }
        public Pago Pago { get; set; }

        private void DlgPagar_Load(object sender, EventArgs e)
        {
            if (Contrato.Id > 0)
            {
                if (!Contrato.ConceptosAdicionales.Any() && (Contrato.Adeudos == null || !Contrato.Adeudos.Any()))
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Esta cuenta no tiene adeudos pendientes.", this.Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                txtNoContrato.Text = Contrato.NoContrato.ToString("D10");
                txtTitular.Text = Contrato.NombreUsuario;
                txtDireccion.Text = Contrato.Direccion;
                txtTipoServicio.Text = Contrato.TipoContrato.Descripcion;
                txtTarifa.Text = Contrato.NombreTarifa;

                if (Contrato.Descuentos == null || Contrato.Descuentos.Count > 0)
                    grpDescuentos.Visible = false;

                dgvAdeudosPendientes.DataSource = Contrato.Adeudos;

                if (Contrato.IdTipoContrato == (int)Contrato.Tipo.CuotaFija)
                {
                    dgvAdeudosPendientes.Columns["FechaPeriodo"].Visible = false;

                }
                else
                {
                    dgvAdeudosPendientes.Columns["FechaPeriodo"].Visible = true;
                    dgvAdeudosPendientes.Columns["FechaPeriodo"].HeaderText = "Periodo";
                    dgvAdeudosPendientes.Columns["Periodo"].Visible = false;
                }

                dgvAdeudosPendientes.Columns["Agua"].Visible = false;
                dgvAdeudosPendientes.Columns["Alcantarillado"].Visible = false;
                dgvAdeudosPendientes.Columns["Saneamiento"].Visible = false;
                dgvAdeudosPendientes.Columns["Recargos"].Visible = false;
                dgvAdeudosPendientes.Columns["Multas"].Visible = false;
                dgvAdeudosPendientes.Columns["GastosEjecucion"].Visible = false;
                dgvAdeudosPendientes.Columns["Redondeo"].Visible = false;
                dgvAdeudosPendientes.Columns["IVA"].Visible = false;

                dgvAdeudosPendientes.Columns["AdeudoTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                const int espacioEntreRows = 28;

                dgvAdeudosPendientes.Height = Contrato.Adeudos.Count == 1 ? espacioEntreRows * 2
                    : Contrato.Adeudos.Count * espacioEntreRows;


                nudAdeudosPagar.Maximum = Contrato.Adeudos.Count;
                nudAdeudosPagar.Minimum = 1;
            }
        }


        private void RecalcularTotales()
        {
            var adeudosSeleccionados = Contrato.Adeudos.OrderBy(a => a.FechaPeriodo).Take((int)nudAdeudosPagar.Value);

            var fechaPrimerAdeudo = adeudosSeleccionados.First().FechaPeriodo;
            var fechaUltimoAdeudo = adeudosSeleccionados.Last().FechaPeriodo;

            bool esAnticipado = adeudosSeleccionados.FirstOrDefault(a => a.FechaPeriodo.Year > DateTime.Now.Year) != null;

            var adeudosCorriente = (esAnticipado)
                ? adeudosSeleccionados.Where(a => a.FechaPeriodo.Year > DateTime.Now.Year)
                : adeudosSeleccionados.Where(a => a.FechaPeriodo.Year == DateTime.Now.Year);
            var adeudosRezagados = (esAnticipado)
                ? adeudosSeleccionados.Where(a => a.FechaPeriodo.Year <= DateTime.Now.Year)
                : adeudosSeleccionados.Where(a => a.FechaPeriodo.Year < DateTime.Now.Year);

            // Los periodos son bimestrales, obtenemos inicio / fin de cada uno en cada fecha
            if (Contrato.IdTipoContrato == (int)Contrato.Tipo.CuotaFija)
            {
                fechaPrimerAdeudo = Utilerias.GetInicioPeriodoBimestral(fechaPrimerAdeudo);
                fechaUltimoAdeudo = Utilerias.GetFinPeriodoBimestral(fechaUltimoAdeudo);
            }

            string periodo = (fechaPrimerAdeudo.Date != fechaUltimoAdeudo.Date)
                ? $"{fechaPrimerAdeudo.ToString("MMM yy", new CultureInfo("es-MX"))} - {fechaUltimoAdeudo.ToString("MMM yy", new CultureInfo("es-MX"))}"
                : fechaPrimerAdeudo.ToString("MMM yy", new CultureInfo("es-MX"));

            grpDesgloseTotal.Text = $"TOTAL {periodo}";

            decimal totalAguaCorriente = adeudosCorriente.Sum(a => a.Agua);
            decimal totalAlcantarilladoCorriente = adeudosCorriente.Sum(a => a.Alcantarillado);
            decimal totalSaneamientoCorriente = adeudosCorriente.Sum(a => a.Saneamiento);
            decimal totalRecargosCorriente = adeudosCorriente.Sum(a => a.Recargos);
            decimal totalMultasCorriente = adeudosCorriente.Sum(a => a.Multas);
            decimal totalGastosEjecucionCorriente = adeudosCorriente.Sum(a => a.GastosEjecucion);
            decimal totalIVACorriente = adeudosCorriente.Sum(a => a.IVA);

            decimal totalAguaRezagado = adeudosRezagados.Sum(a => a.Agua);
            decimal totalAlcantarilladoRezagado = adeudosRezagados.Sum(a => a.Alcantarillado);
            decimal totalSaneamientoRezagado = adeudosRezagados.Sum(a => a.Saneamiento);
            decimal totalRecargosRezagado = adeudosRezagados.Sum(a => a.Recargos);
            decimal totalMultasRezagado = adeudosRezagados.Sum(a => a.Multas);
            decimal totalGastosEjecucionRezagado = adeudosRezagados.Sum(a => a.GastosEjecucion);
            decimal totalIVARezagado = adeudosRezagados.Sum(a => a.IVA);

            decimal totalDescuentos = 0;

            var bimestreActual = Utilerias.GetBimestre(DateTime.Now);

            bool aplicarDescuentoAnual = Contrato.IdTipoContrato == (int)Contrato.Tipo.CuotaFija
                ? adeudosCorriente.Count() >= 6 && bimestreActual == 1
                : adeudosCorriente.Count() >= 12 && bimestreActual == 1;


            lblDescuentosAplicados.Text = string.Empty;

            if (Contrato.Descuentos.Count > 0)
            {
                // Estos ya vienen aplicados desde la DLL
                List<string> descuentos = Contrato.Descuentos.Select(a => $"* \"{a.Descuento.NombreTipoDescuento}\"\n").ToList();

                foreach (string descuento in descuentos)
                {
                    lblDescuentosAplicados.Text += descuento;
                }

                lblDescuentosAplicados.Visible = true;
            }

            decimal totalPagar = 0;

            if (aplicarDescuentoAnual)
            {
                // Obtener porcentajes

                List<Porcentajes> porcentajes = Porcentajes.GetPorcentajes().DividirEntreCien();

                if (porcentajes.Count == 0)
                {
                    MessageBox.Show(
                        "No se han registrado los valores para los porcentajes. Verifique desde el Catálogo de Porcentajes.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (porcentajes[0].DescuentoAnual > 0)
                {
                    lblDescuentosAplicados.Text += "* DESCUENTO ANUAL APLICADO\n";

                    totalAguaCorriente -= (totalAguaCorriente * porcentajes[0].DescuentoAnual);
                    totalAlcantarilladoCorriente -= (totalAlcantarilladoCorriente * porcentajes[0].DescuentoAnual);
                    totalSaneamientoCorriente -= (totalSaneamientoCorriente * porcentajes[0].DescuentoAnual);
                    totalRecargosCorriente -= (totalRecargosCorriente * porcentajes[0].DescuentoAnual);
                    totalMultasCorriente -= (totalMultasCorriente * porcentajes[0].DescuentoAnual);
                    totalGastosEjecucionCorriente -= (totalGastosEjecucionCorriente * porcentajes[0].DescuentoAnual);
                    totalIVACorriente -= (totalIVACorriente * porcentajes[0].DescuentoAnual);
                }
            }


            txtAgua.Text = (totalAguaCorriente + totalAguaRezagado).ToString("N2");
            txtAlcantarillado.Text = (totalAlcantarilladoCorriente + totalAlcantarilladoRezagado).ToString("N2");
            txtSaneamiento.Text = (totalSaneamientoCorriente + totalSaneamientoRezagado).ToString("N2");
            txtRecargos.Text = (totalRecargosCorriente + totalRecargosRezagado).ToString("N2");
            txtMultas.Text = (totalMultasCorriente + totalMultasRezagado).ToString("N2");
            txtGastosEjecucion.Text = (totalGastosEjecucionCorriente + totalGastosEjecucionRezagado).ToString("N2");
            txtOtros.Text = Contrato.ConceptosAdicionales.Sum(ca => ca.Importe).ToString("N2");
            txtIVA.Text = (totalIVACorriente + totalIVARezagado).ToString("N2");

            DescuentoTemporal descuentoTemporal = new DescuentoTemporal();

            decimal tmp;

            descuentoTemporal.PorcentajeAgua = decimal.TryParse(txtDescuentoPorcentualAgua.Text, out tmp) ? tmp / 100 : 0m;
            descuentoTemporal.PorcentajeAlcantarillado = decimal.TryParse(txtDescuentoPorcentualAlcantarillado.Text, out tmp) ? tmp / 100 : 0m;
            descuentoTemporal.PorcentajeSaneamiento = decimal.TryParse(txtDescuentoPorcentualSaneamiento.Text, out tmp) ? tmp / 100 : 0m;
            descuentoTemporal.PorcentajeRecargos = decimal.TryParse(txtDescuentoPorcentualRecargos.Text, out tmp) ? tmp / 100 : 0m;
            descuentoTemporal.PorcentajeMultas = decimal.TryParse(txtDescuentoPorcentualMultas.Text, out tmp) ? tmp / 100 : 0m;
            descuentoTemporal.PorcentajeGastosEjecucion = decimal.TryParse(txtDescuentoPorcentualGastosEjecucion.Text, out tmp) ? tmp / 100 : 0m;
            descuentoTemporal.PorcentajeIVA = decimal.TryParse(txtDescuentoPorcentualIVA.Text, out tmp) ? tmp / 100 : 0m;


            DescuentoValores descuentoValores = new DescuentoValores();

            var totalAgua = (totalAguaCorriente + totalAguaRezagado);
            descuentoValores.Agua = totalAgua * descuentoTemporal.PorcentajeAgua;
            totalAgua -= descuentoValores.Agua;

            var totalAlcantarillado = (totalAlcantarilladoCorriente + totalAlcantarilladoRezagado);
            descuentoValores.Alcantarillado = totalAlcantarillado * descuentoTemporal.PorcentajeAlcantarillado;
            totalAlcantarillado -= descuentoValores.Alcantarillado;

            var totalSaneamiento = (totalSaneamientoCorriente + totalSaneamientoRezagado);
            descuentoValores.Saneamiento = totalSaneamiento * descuentoTemporal.PorcentajeSaneamiento;
            totalSaneamiento -= descuentoValores.Saneamiento;

            var totalRecargos = (totalRecargosCorriente + totalRecargosRezagado);
            descuentoValores.Recargos = totalRecargos * descuentoTemporal.PorcentajeRecargos;
            totalRecargos -= descuentoValores.Recargos;

            var totalMultas = (totalMultasCorriente + totalMultasRezagado);
            descuentoValores.Multas = totalMultas * descuentoTemporal.PorcentajeMultas;
            totalMultas -= descuentoValores.Multas;

            var totalGastosEjecucion = (totalGastosEjecucionCorriente + totalGastosEjecucionRezagado);
            descuentoValores.GastosEjecucion = totalGastosEjecucion * descuentoTemporal.PorcentajeGastosEjecucion;
            totalGastosEjecucion -= descuentoValores.GastosEjecucion;

            var totalOtros = Contrato.ConceptosAdicionales.Sum(ca => ca.Importe);

            var totalIVA = (totalIVACorriente + totalIVARezagado);
            descuentoValores.IVA = totalIVA * descuentoTemporal.PorcentajeIVA;
            totalIVA -= descuentoValores.IVA;

            descuentoValores.Total = descuentoValores.Agua + descuentoValores.Alcantarillado +
                                     descuentoValores.Saneamiento + descuentoValores.Recargos +
                                     descuentoValores.Multas + descuentoValores.GastosEjecucion +
                                     descuentoValores.IVA;

            totalPagar = totalAgua +
                         totalAlcantarillado +
                         totalSaneamiento +
                         totalRecargos +
                         totalMultas +
                         totalGastosEjecucion +
                         totalOtros +
                         totalIVA;

            txtRedondeo.Text = (Math.Round(totalPagar) - totalPagar).ToString("N2");

            lblTotalPagar.Text = $"TOTAL A PAGAR ${Math.Round(totalPagar).ToString("N2")}";

            Pago = new Pago
            {
                NoContrato = Contrato.NoContrato,
                Detalles = new PagoDetalle
                {
                    Agua = totalAgua,
                    Alcantarillado = totalAlcantarillado,
                    Saneamiento = totalSaneamiento,
                    Recargos = totalRecargos,
                    Multas = totalMultas,
                    GastosEjecucion = totalGastosEjecucion,
                    IVA = totalIVA,
                    AdeudoTotal = Math.Round(totalPagar),
                    Redondeo = Math.Abs(totalPagar - Math.Round(totalPagar)),
                    DescuentosAplicados = Contrato.Descuentos,
                    DescuentoValores = descuentoValores,
                    DescuentoTemporal = descuentoTemporal,
                    ConceptosAdicionales = Contrato.ConceptosAdicionales,
                    PeriodoInicio = (Contrato.IdTipoContrato == (int)Contrato.Tipo.CuotaFija) ? Utilerias.GetInicioPeriodoBimestral(fechaPrimerAdeudo) : fechaPrimerAdeudo,
                    PeriodoFin = (Contrato.IdTipoContrato == (int)Contrato.Tipo.CuotaFija) ? Utilerias.GetFinPeriodoBimestral(fechaUltimoAdeudo) : fechaUltimoAdeudo
                }
            };

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


        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (sender == null) return;

            var txtCampo = (sender as TextBox);

            if (string.IsNullOrWhiteSpace(txtCampo.Text))
                txtCampo.Text = "0.00";

            decimal valorDescuento = 0m;

            if (decimal.TryParse(txtCampo.Text, out valorDescuento))
            {
                if (valorDescuento > 100m)
                {
                    valorDescuento = 100m;

                    txtCampo.Text = valorDescuento.ToString("N2");
                    txtCampo.SelectAll();
                }

                RecalcularTotales();
            }
        }


        private void nudAdeudosPagar_ValueChanged(object sender, EventArgs e)
        {
            if (dgvAdeudosPendientes.Rows.Count == 0) return;

            dgvAdeudosPendientes.ClearSelection();

            // Seleccionamos la cantidad de adeudos elegidos

            for (int idx = 0; idx < nudAdeudosPagar.Value; idx++)
            {
                // Omitir filas nulas

                if (dgvAdeudosPendientes.Rows[idx] == null)
                    continue;

                dgvAdeudosPendientes.Rows[idx].Selected = true;
            }

            // Recalcular totales
            RecalcularTotales();
        }

        private void DlgPagar_Shown(object sender, EventArgs e) => RecalcularTotales();

        private void btnSeleccionarTodos_Click(object sender, EventArgs e) => nudAdeudosPagar.Value = nudAdeudosPagar.Maximum;

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (Pago == null || Pago.Detalles == null)
            {
                MessageBox.Show("No hay adeudos pendientes. Si no es asi, contacte al área soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DlgPagoCompletar dlg = new DlgPagoCompletar();

            dlg.Pago = Pago;
            dlg.Adeudos = Contrato.Adeudos.OrderBy(a => a.FechaPeriodo).Take((int)nudAdeudosPagar.Value).ToList();
            dlg.Contrato = Contrato;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void txtDescuentoGeneral_TextChanged(object sender, EventArgs e)
        {
            txtDescuentoPorcentualAgua.Text = txtDescuentoGeneral.Text;
            txtDescuentoPorcentualAlcantarillado.Text = txtDescuentoGeneral.Text;
            txtDescuentoPorcentualSaneamiento.Text = txtDescuentoGeneral.Text;
            txtDescuentoPorcentualRecargos.Text = txtDescuentoGeneral.Text;
            txtDescuentoPorcentualMultas.Text = txtDescuentoGeneral.Text;
            txtDescuentoPorcentualGastosEjecucion.Text = txtDescuentoGeneral.Text;
            txtDescuentoPorcentualIVA.Text = txtDescuentoGeneral.Text;

            RecalcularTotales();
        }

        private void btnGenerarCotizacion_Click(object sender, EventArgs e)
        {
            if (Pago == null || Pago.Detalles == null)
            {
                MessageBox.Show("No hay adeudos pendientes. Si no es asi, contacte al área soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var adeudos = Contrato.Adeudos.OrderBy(a => a.FechaPeriodo).Take((int)nudAdeudosPagar.Value).ToList();

            // Imprimir ticket y asignar parametros

            RptReciboPago rpt = new RptReciboPago();

            DataSet dsReporte = new DataSet();

            dsReporte.Tables.Add(Organismo.Actual);

            // Datos del encabezado
            rpt.SetDataSource(dsReporte);

            // Parametros del recibo

            rpt.SetParameterValue("Titulo", "COTIZACIÓN DE PAGO");

            rpt.SetParameterValue("Folio", "—————");
            rpt.SetParameterValue("FechaPago", "—————");

            rpt.SetParameterValue("NoContrato", Contrato.NoContrato.ToString("D10"));
            rpt.SetParameterValue("NombreContribuyente", Contrato.NombreUsuario);
            rpt.SetParameterValue("Direccion", Contrato.Direccion);

            if (Pago.Detalles.PeriodoInicio == default(DateTime) && Pago.Detalles.PeriodoFin == default(DateTime))
                rpt.SetParameterValue("PeriodoPago", "N/A");
            else
                rpt.SetParameterValue("PeriodoPago", $"{Pago.Detalles.PeriodoInicio.ToString("MMMM yyyy", new CultureInfo("es-MX"))} - {Pago.Detalles.PeriodoFin.ToString("MMMM yyyy", new CultureInfo("es-MX"))}".ToUpper());

            rpt.SetParameterValue("Tarifa", Contrato.NombreTarifa);
            rpt.SetParameterValue("FormaPago", "—————");

            var totalAgua = adeudos.Sum(a => a.Agua);
            var totalAlcantarillado = adeudos.Sum(a => a.Alcantarillado);
            var totalSaneamiento = adeudos.Sum(a => a.Saneamiento);
            var totalRecargos = adeudos.Sum(a => a.Recargos);
            var totalMultas = adeudos.Sum(a => a.Multas);
            var totalIVA = adeudos.Sum(a => a.IVA);

            totalAgua -= Pago.Detalles.DescuentoValores.Agua;
            totalAlcantarillado -= Pago.Detalles.DescuentoValores.Alcantarillado;
            totalSaneamiento -= Pago.Detalles.DescuentoValores.Saneamiento;
            totalRecargos -= Pago.Detalles.DescuentoValores.Recargos;
            totalMultas -= Pago.Detalles.DescuentoValores.Multas;
            totalIVA -= Pago.Detalles.DescuentoValores.IVA;

            rpt.SetParameterValue("Agua", totalAgua.ToString("N2"));
            rpt.SetParameterValue("Alcantarillado", totalAlcantarillado.ToString("N2"));
            rpt.SetParameterValue("Saneamiento", totalSaneamiento.ToString("N2"));
            rpt.SetParameterValue("Multas", totalMultas.ToString("N2"));
            rpt.SetParameterValue("Recargos", totalRecargos.ToString("N2"));
            rpt.SetParameterValue("Otros", Pago.Detalles.ConceptosAdicionales.Sum(ca => ca.Importe).ToString("N2"));
            rpt.SetParameterValue("IVA", totalIVA.ToString("N2"));
            rpt.SetParameterValue("Redondeo", Pago.Detalles.Redondeo.ToString("N2"));
            rpt.SetParameterValue("AdeudoTotal", Pago.Detalles.AdeudoTotal.ToString("N2"));

            rpt.SetParameterValue("DescuentoAgua", Pago.Detalles.DescuentoTemporal.PorcentajeAgua > 0 ? $"- {(Pago.Detalles.DescuentoTemporal.PorcentajeAgua * 100).ToString("N2")}%" : " ");
            rpt.SetParameterValue("DescuentoAlcantarillado", Pago.Detalles.DescuentoTemporal.PorcentajeAlcantarillado > 0 ? $"- {(Pago.Detalles.DescuentoTemporal.PorcentajeAlcantarillado * 100).ToString("N2")}%" : " ");
            rpt.SetParameterValue("DescuentoSaneamiento", Pago.Detalles.DescuentoTemporal.PorcentajeSaneamiento > 0 ? $"- {(Pago.Detalles.DescuentoTemporal.PorcentajeSaneamiento * 100).ToString("N2")}%" : " ");
            rpt.SetParameterValue("DescuentoMultas", Pago.Detalles.DescuentoTemporal.PorcentajeMultas > 0 ? $"- {(Pago.Detalles.DescuentoTemporal.PorcentajeMultas * 100).ToString("N2")}%" : " ");
            rpt.SetParameterValue("DescuentoRecargos", Pago.Detalles.DescuentoTemporal.PorcentajeRecargos > 0 ? $"- {(Pago.Detalles.DescuentoTemporal.PorcentajeRecargos * 100).ToString("N2")}%" : " ");
            rpt.SetParameterValue("DescuentoIVA", Pago.Detalles.DescuentoTemporal.PorcentajeIVA > 0 ? $"- {(Pago.Detalles.DescuentoTemporal.PorcentajeIVA * 100).ToString("N2")}%" : " ");

            rpt.SetParameterValue("DescuentoTotal", Pago.Detalles.DescuentoValores.Total > 0 ? $"- {Pago.Detalles.DescuentoValores.Total.ToString("N2")}" : " ");

            rpt.SetParameterValue("TotalEnLetra", Utilerias.CantidadEnLetras(Pago.Detalles.AdeudoTotal));

            string cadenaListadoConceptos = string.Empty;

            foreach (ConceptoAdicional ca in Pago.Detalles.ConceptosAdicionales)
            {
                cadenaListadoConceptos += $"{ca.Concepto.Descripcion}\t{ca.Importe.ToString("N2")}\n";
            }

            rpt.SetParameterValue("CadenaListadoConceptos", string.IsNullOrWhiteSpace(cadenaListadoConceptos) ? " " : cadenaListadoConceptos);

            rpt.PrintToPrinter(1, true, 1, 1);

            MessageBox.Show("La cotización de pago se imprimió correctamente.", this.Text, MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }
    }
}

