using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using CalculoCobroAgua;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlPagos : Form
    {
        public PnlPagos()
        {
            InitializeComponent();
        }

        public FrmPrincipal FrmPrincipal { get; set; }

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

        private void CargarContrato(Contrato contrato)
        {
            if (contrato == null) return;

            txtNoContrato.Text = contrato.NoContrato.ToString("D10");

            txtUsuario.Text = contrato.NombreUsuario;
            txtDireccion.Text = contrato.Direccion;
            txtColonia.Text = contrato.Colonia.Descripcion;

            lblTipoServicio.Text = contrato.IdTipoContrato == (int)Contrato.Tipo.CuotaFija ? "CUOTA FIJA" : "SERVICIO MEDIDO";

            if (contrato.IdTipoContrato == (int)Contrato.Tipo.ServicioMedido)
                lblNoMedidor.Text = $"MEDIDOR NO. {contrato.Medidor.Id.ToString("D3")}";

            contrato.Convenios = Convenio.GetConveniosByNoContrato(contrato.NoContrato);


            // Cargar adeudos
            var cobroAgua = CobroAgua.GetContratoAdeudos(Contrato.NoContrato);

            if (cobroAgua.Tables["ERRORES"] != null)
            {
                MessageBox.Show(cobroAgua.Tables["ERRORES"].Rows[0]["ERROR"].ToString(), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarGUI();
                return;
            }

            contrato.Adeudos = new List<AdeudoVista>();

            foreach (DataRow fila in cobroAgua.Tables["DETALLES"].Rows)
            {
                AdeudoVista adeudo = new AdeudoVista();
                adeudo = fila;

                if (adeudo.FechaPeriodo.Year > DateTime.Now.Year)
                    continue;

                contrato.Adeudos.Add(adeudo);
            }

            var conteoAdeudos = contrato.IdTipoContrato == (int)Contrato.Tipo.CuotaFija
                ? contrato.Adeudos.Count(a => a.FechaPeriodo.Date <= Utilerias.GetFinPeriodoBimestral(DateTime.Now).Date)
                : contrato.Adeudos.Count(a => a.FechaPeriodo.Date <= DateTime.Now.Date);

            bool tieneConvenio = bool.Parse(cobroAgua.Tables["RESUMEN"].Rows[0]["TieneConvenio"].ToString());

            if (conteoAdeudos > 0)
            {
                var adeudosCorriente = contrato.Adeudos.Where(a => a.FechaPeriodo.Year == DateTime.Now.Year).ToList();
                var adeudosRezago = contrato.Adeudos.Where(a => a.FechaPeriodo.Year < DateTime.Now.Year).ToList();

                var primerAdeudo = adeudosRezago.FirstOrDefault() == null ? adeudosCorriente.First() : adeudosRezago.First();
                var ultimoAdeudo = adeudosCorriente.Find(a =>
                    Utilerias.GetBimestre(a.FechaPeriodo) == Utilerias.GetBimestre(DateTime.Now) &&
                    a.FechaPeriodo.Year == DateTime.Now.Year);

                if (ultimoAdeudo == null)
                    ultimoAdeudo = contrato.Adeudos.Last();

                if (!tieneConvenio)
                {
                    if (contrato.IdTipoContrato == (int)Contrato.Tipo.CuotaFija)
                        lblPeriodo.Text =
                            $"{Utilerias.GetInicioPeriodoBimestral(primerAdeudo.FechaPeriodo).ToString("MMM yy", new CultureInfo("es-MX"))} - {Utilerias.GetFinPeriodoBimestral(ultimoAdeudo.FechaPeriodo).ToString("MMM yy", new CultureInfo("es-MX"))}" +
                            $"\n({conteoAdeudos} bimestres)";
                    else
                        lblPeriodo.Text =
                            $"{primerAdeudo.FechaPeriodo.ToString("MMM yy", new CultureInfo("es-MX"))} - {ultimoAdeudo.FechaPeriodo.ToString("MMM yy", new CultureInfo("es-MX"))}" +
                            $"\n({conteoAdeudos} meses)";
                }
                else
                {
                    var ultimoConvenioVigente = Contrato.Convenios.Last(c => DateTime.Now >= c.FechaInicio && DateTime.Now <= c.FechaFin);

                    lblPeriodo.Text =
                        $"{Utilerias.GetInicioPeriodoBimestral(primerAdeudo.FechaPeriodo).ToString("MMM yy", new CultureInfo("es-MX"))} - {Utilerias.GetFinPeriodoBimestral(ultimoAdeudo.FechaPeriodo).ToString("MMM yy", new CultureInfo("es-MX"))}" +
                        $"\nCONVENIO ESTABLECIDO POR {ultimoConvenioVigente.NumeroPagos} PAGOS";
                }

                lblPeriodo.ForeColor = Color.Sienna;
                lblPeriodo.Visible = true;

                lblTarifa.Text = $"TARIFA {Contrato.NombreTarifa.ToUpper()}";
                lblTarifa.Visible = true;

                grpAdeudos.Visible = true;

                dgvAdeudosCorriente.DataSource = adeudosCorriente;
                dgvAdeudosRezago.DataSource = adeudosRezago;


                if (contrato.IdTipoContrato == (int)Contrato.Tipo.ServicioMedido)
                {
                    dgvAdeudosCorriente.Columns["Periodo"].Visible = false;
                    dgvAdeudosRezago.Columns["rezagoPeriodo"].Visible = false;


                    dgvAdeudosCorriente.Columns["FechaPeriodo"].HeaderText = "Periodo";
                    dgvAdeudosRezago.Columns["rezagoFechaPeriodo"].HeaderText = "Periodo";

                    dgvAdeudosCorriente.Columns["FechaPeriodo"].DefaultCellStyle.Format = "MMMM yyyy";
                    dgvAdeudosRezago.Columns["rezagoFechaPeriodo"].DefaultCellStyle.Format = "MMMM yyyy";

                    dgvAdeudosCorriente.Columns["FechaPeriodo"].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.DisplayedCells;

                    dgvAdeudosRezago.Columns["rezagoFechaPeriodo"].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                else
                {
                    dgvAdeudosCorriente.Columns["Periodo"].Visible = true;
                    dgvAdeudosRezago.Columns["rezagoPeriodo"].Visible = true;

                    dgvAdeudosCorriente.Columns["FechaPeriodo"].HeaderText = "Fecha Periodo";
                    dgvAdeudosRezago.Columns["rezagoFechaPeriodo"].HeaderText = "Fecha Periodo";

                    dgvAdeudosCorriente.Columns["FechaPeriodo"].DefaultCellStyle.Format = "";
                    dgvAdeudosRezago.Columns["rezagoFechaPeriodo"].DefaultCellStyle.Format = "";

                    dgvAdeudosCorriente.Columns["FechaPeriodo"].DefaultCellStyle.Format = "";
                    dgvAdeudosRezago.Columns["rezagoFechaPeriodo"].DefaultCellStyle.Format = "";

                    dgvAdeudosCorriente.Columns["FechaPeriodo"].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvAdeudosRezago.Columns["rezagoFechaPeriodo"].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.DisplayedCells;
                }

                if (tieneConvenio)
                {
                    dgvAdeudosCorriente.Columns["Periodo"].Visible = false;

                    dgvAdeudosCorriente.Columns["Agua"].Visible = false;
                    dgvAdeudosCorriente.Columns["Alcantarillado"].Visible = false;
                    dgvAdeudosCorriente.Columns["Saneamiento"].Visible = false;
                    dgvAdeudosCorriente.Columns["Recargos"].Visible = false;
                    dgvAdeudosCorriente.Columns["Multas"].Visible = false;
                    dgvAdeudosCorriente.Columns["GastosEjecucion"].Visible = false;
                    dgvAdeudosCorriente.Columns["Redondeo"].Visible = false;
                    dgvAdeudosCorriente.Columns["IVA"].Visible = false;

                    dgvAdeudosRezago.Columns["rezagoAgua"].Visible = false;
                    dgvAdeudosRezago.Columns["rezagoAlcantarillado"].Visible = false;
                    dgvAdeudosRezago.Columns["rezagoSaneamiento"].Visible = false;
                    dgvAdeudosRezago.Columns["rezagoRecargos"].Visible = false;
                    dgvAdeudosRezago.Columns["rezagoMultas"].Visible = false;
                    dgvAdeudosRezago.Columns["rezagoGastosEjecucion"].Visible = false;
                    dgvAdeudosRezago.Columns["rezagoRedondeo"].Visible = false;
                    dgvAdeudosRezago.Columns["rezagoIVA"].Visible = false;
                }
                else
                {
                    dgvAdeudosCorriente.Columns["Agua"].Visible = true;
                    dgvAdeudosCorriente.Columns["Alcantarillado"].Visible = true;
                    dgvAdeudosCorriente.Columns["Saneamiento"].Visible = true;
                    dgvAdeudosCorriente.Columns["Recargos"].Visible = true;
                    dgvAdeudosCorriente.Columns["Multas"].Visible = true;
                    dgvAdeudosCorriente.Columns["GastosEjecucion"].Visible = true;
                    dgvAdeudosCorriente.Columns["Redondeo"].Visible = true;
                    dgvAdeudosCorriente.Columns["IVA"].Visible = true;

                    dgvAdeudosRezago.Columns["rezagoAgua"].Visible = true;
                    dgvAdeudosRezago.Columns["rezagoAlcantarillado"].Visible = true;
                    dgvAdeudosRezago.Columns["rezagoSaneamiento"].Visible = true;
                    dgvAdeudosRezago.Columns["rezagoRecargos"].Visible = true;
                    dgvAdeudosRezago.Columns["rezagoMultas"].Visible = true;
                    dgvAdeudosRezago.Columns["rezagoGastosEjecucion"].Visible = true;
                    dgvAdeudosRezago.Columns["rezagoRedondeo"].Visible = true;
                    dgvAdeudosRezago.Columns["rezagoIVA"].Visible = true;
                }

                dgvDescuentosAplicados.DataSource = cobroAgua.Tables["DESCUENTOS"];

                var totalCorriente = adeudosCorriente.Sum(a => a.AdeudoTotal);
                var totalRezago = adeudosRezago.Sum(a => a.AdeudoTotal);
                var totalOtros = Contrato.ConceptosAdicionales.Sum(ca => ca.Importe);

                txtCorriente.Text = totalCorriente.ToString("N2");
                txtRezagos.Text = totalRezago.ToString("N2");
                txtOtros.Text = totalOtros.ToString("N2");

                var adeudoTotal = totalCorriente + totalRezago + totalOtros;
                var redondeo = Math.Abs(adeudoTotal - Math.Round(adeudoTotal));
                adeudoTotal = Math.Round(adeudoTotal);

                txtRedondeo.Text = redondeo.ToString("N2");
                txtAdeudoTotal.Text = adeudoTotal.ToString("N2");

                if (cobroAgua.Tables["DESCUENTOS"] != null)
                {
                    Contrato.Descuentos = new List<ContratoDescuento>();

                    foreach (DataRow fila in cobroAgua.Tables["DESCUENTOS"].Rows)
                    {
                        Contrato.Descuentos.Add(new ContratoDescuento
                        {
                            Id = int.Parse(fila["IdContratoDescuento"].ToString()),
                            NoContrato = contrato.NoContrato,
                            Descuento = new Descuento
                            {
                                TipoDescuento = new TipoDescuento
                                {
                                    Descripcion = fila["NombreDescuento"].ToString()
                                },
                                PorcentajeAgua = decimal.Parse(fila["PorcentajeAgua"].ToString()),
                                PorcentajeAlcantarillado = decimal.Parse(fila["PorcentajeAlcantarillado"].ToString()),
                                PorcentajeSaneamiento = decimal.Parse(fila["PorcentajeSaneamiento"].ToString()),
                                PorcentajeRecargos = decimal.Parse(fila["PorcentajeRecargos"].ToString()),
                                PorcentajeMultas = decimal.Parse(fila["PorcentajeMultas"].ToString()),
                                PorcentajeGastosEjecucion = decimal.Parse(fila["PorcentajeGastosEjecucion"].ToString()),
                                PorcentajeIVA = decimal.Parse(fila["PorcentajeIVA"].ToString()),
                            },
                            FechaInicio = DateTime.Parse(fila["FechaInicio"].ToString()),
                            FechaFin = DateTime.Parse(fila["FechaFin"].ToString()),
                        });
                    }
                }

                lblConteoDescuentosAplicados.Text = contrato.Descuentos == null || contrato.Descuentos.Count == 0 
                    ? string.Empty 
                    : $"* {contrato.Descuentos.Count} {(contrato.Descuentos.Count > 1 ? "DESCUENTOS APLICADOS" : "DESCUENTO APLICADO")}";


                btnPagar.Visible = true;
            }
            else
            {
                lblPeriodo.Visible = true;

                lblTarifa.Text = $"SERVICIO {Contrato.NombreTarifa.ToUpper()}";
                lblTarifa.Visible = true;

                grpAdeudos.Visible = true;

                lblPeriodo.Text = contrato.IdTipoContrato == (int)Contrato.Tipo.CuotaFija 
                    ? "CUENTA AL CORRIENTE\n(SOLO PAGOS ANTICIPADOS)" 
                    : "CUENTA AL CORRIENTE\n(ESPERE SIGUIENTE MEDICIÓN)";

                lblPeriodo.ForeColor = Color.Green;

                var adeudosCorriente = contrato.Adeudos.Where(a => a.FechaPeriodo.Year >= DateTime.Now.Year).ToList();
                var adeudosRezago = contrato.Adeudos.Where(a => a.FechaPeriodo.Year < DateTime.Now.Year).ToList();

                dgvAdeudosCorriente.DataSource = adeudosCorriente;
                dgvAdeudosRezago.DataSource = adeudosRezago;
                dgvDescuentosAplicados.DataSource = cobroAgua.Tables["DESCUENTOS"];
                dgvDescuentosAplicados.Columns["IdContratoDescuento"].Visible = false;

                var totalCorriente = adeudosCorriente.Sum(a => a.AdeudoTotal);
                var totalRezago = adeudosRezago.Sum(a => a.AdeudoTotal);
                var totalOtros = Contrato.ConceptosAdicionales.Sum(ca => ca.Importe);

                txtCorriente.Text = totalCorriente.ToString("N2");
                txtRezagos.Text = totalRezago.ToString("N2");
                txtOtros.Text = totalOtros.ToString("N2");

                var adeudoTotal = totalCorriente + totalRezago + totalOtros;
                var redondeo = Math.Abs(adeudoTotal - Math.Round(adeudoTotal));
                adeudoTotal = Math.Round(adeudoTotal);

                txtRedondeo.Text = redondeo.ToString("N2");
                txtAdeudoTotal.Text = adeudoTotal.ToString("N2");

                if (cobroAgua.Tables["DESCUENTOS"] != null)
                {
                    Contrato.Descuentos = new List<ContratoDescuento>();

                    foreach (DataRow fila in cobroAgua.Tables["DESCUENTOS"].Rows)
                    {
                        Contrato.Descuentos.Add(new ContratoDescuento
                        {
                            Id = int.Parse(fila["IdContratoDescuento"].ToString()),
                            NoContrato = contrato.NoContrato,
                            Descuento = new Descuento
                            {
                                TipoDescuento = new TipoDescuento
                                {
                                    Descripcion = fila["NombreDescuento"].ToString()
                                },
                                PorcentajeAgua = decimal.Parse(fila["PorcentajeAgua"].ToString()),
                                PorcentajeAlcantarillado = decimal.Parse(fila["PorcentajeAlcantarillado"].ToString()),
                                PorcentajeSaneamiento = decimal.Parse(fila["PorcentajeSaneamiento"].ToString()),
                                PorcentajeRecargos = decimal.Parse(fila["PorcentajeRecargos"].ToString()),
                                PorcentajeMultas = decimal.Parse(fila["PorcentajeMultas"].ToString()),
                                PorcentajeGastosEjecucion = decimal.Parse(fila["PorcentajeGastosEjecucion"].ToString()),
                                PorcentajeIVA = decimal.Parse(fila["PorcentajeIVA"].ToString()),
                            },
                            FechaInicio = DateTime.Parse(fila["FechaInicio"].ToString()),
                            FechaFin = DateTime.Parse(fila["FechaFin"].ToString()),
                        });
                    }
                }


                btnPagar.Visible = contrato.IdTipoContrato == (int)Contrato.Tipo.CuotaFija;
            }

            CargarDgvCmbConceptos();
        }
    



        private void LimpiarGUI()
        {
            txtUsuario.ResetText();
            txtDireccion.ResetText();
            txtColonia.ResetText();

            lblTipoServicio.ResetText();
            lblNoMedidor.ResetText();

            lblPeriodo.ResetText();
            lblTarifa.ResetText();

            dgvServiciosAdicionales.Rows.Clear();
            dgvServiciosAdicionales.Refresh();

            tcAdeudos.SelectedIndex = 0;

            grpAdeudos.Visible = false;
            btnPagar.Visible = false;
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

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void FrmPagos_Load(object sender, EventArgs e) => LimpiarGUI();


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
            if (keyData == Keys.F8)
            {
                if (btnPagar.Visible)
                {
                    btnPagar_Click(null, null);
                    return true;
                }
            }

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

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (Contrato == null)
            {
                MessageBox.Show("No ha seleccionado un contrato. Seleccione un contrato e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Contrato.ConceptosAdicionales.Any() && (Contrato.Adeudos == null || !Contrato.Adeudos.Any()))
            {
                MessageBox.Show(
                    "No se puede proceder al pago si no hay adeudos ni servicios adicionales cargados en el contrato.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (Contrato.Convenios.Count > 0)
            {
                DlgPagoConvenio dlg = new DlgPagoConvenio();
                dlg.Contrato = Contrato;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Contrato = Contrato.GetContrato(Contrato.NoContrato);
                }

                return;
            }

            if (Contrato.Adeudos.Any())
            {
                // Si hay adeudos del agua y por servicios adicionales, preguntamos si se desean pagar a la par
                // o de manera individual

                if (Contrato.ConceptosAdicionales.Any())
                {
                    var mboxDlgResult = MessageBox.Show(
                        "Hay servicios adicionales cargados al contrato. ¿Desea cobrarlos a la par con adeudos pendientes?", this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (mboxDlgResult == DialogResult.No)
                    {

                        // Omitimos el dialogo de seleccion de adeudos

                        DlgPagoCompletar dlgPagoCompletar = new DlgPagoCompletar();
                        dlgPagoCompletar.Contrato = Contrato;
                        dlgPagoCompletar.Adeudos = new List<AdeudoVista>();

                        if (dlgPagoCompletar.ShowDialog() == DialogResult.OK)
                        {
                            Contrato = Contrato.GetContrato(Contrato.NoContrato);
                        }

                        return;
                    }
                }


                DlgPagar dlg = new DlgPagar();

                dlg.Contrato = Contrato;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Contrato = Contrato.GetContrato(Contrato.NoContrato);
                }
            }
            else
            {
                // Si no hay adeudos del agua, pero sí hay por servicios adicionales, cobramos solamente estos

                if (Contrato.ConceptosAdicionales.Any())
                {
                    // Omitimos el dialogo de seleccion de adeudos

                    DlgPagoCompletar dlgPagoCompletar = new DlgPagoCompletar();
                    dlgPagoCompletar.Contrato = Contrato;

                    if (dlgPagoCompletar.ShowDialog() == DialogResult.OK)
                    {
                        Contrato = Contrato.GetContrato(Contrato.NoContrato);
                    }
                }
            }

        }

        private void btnVerHistorico_Click(object sender, EventArgs e)
        {
            if (!FrmPrincipal.TabExists("Históricos"))
            {
                TabPage t = new TabPage("Históricos");
                t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                FrmPrincipal.tabManager.TabPages.Add(t);
                FrmPrincipal.tabManager.SelectedTab = t;

                FrmHistoricos frm = new FrmHistoricos();
                frm.FrmPrincipal = FrmPrincipal;
                frm.TopLevel = false;
                frm.Parent = t;
                frm.Show();
            }
        }

        private void btnVerCorteCaja_Click(object sender, EventArgs e)
        {
            if (!FrmPrincipal.TabExists("Corte de Caja"))
            {
                TabPage t = new TabPage("Corte de Caja");
                t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                FrmPrincipal.tabManager.TabPages.Add(t);
                FrmPrincipal.tabManager.SelectedTab = t;

                FrmCorteCaja frm = new FrmCorteCaja();
                frm.FrmPrincipal = FrmPrincipal;
                frm.TopLevel = false;
                frm.Parent = t;
                frm.Show();
            }
        }

        private void CargarDgvCmbConceptos()
        {
            var conceptos = Concepto.GetConceptos().OrderBy(c => c.Descripcion).ToList();

            ServicioConcepto.DataSource = conceptos;
            ServicioConcepto.DisplayMember = "Descripcion";
            ServicioConcepto.ValueMember = "Id";
        }

        private void dgvServiciosAdicionales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvServiciosAdicionales.CurrentCell.ColumnIndex == dgvServiciosAdicionales.Columns.IndexOf(Importe))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    e.Control.KeyPress -= entradaDecimal_KeyPress;
                    e.Control.KeyDown -= entradaDecimal_KeyDown;
                    e.Control.Leave -= reestablecerEntradasVacias_Leave;

                    tb.KeyPress += entradaDecimal_KeyPress;
                    tb.KeyDown += entradaDecimal_KeyDown;

                    tb.Leave += reestablecerEntradasVacias_Leave;
                }
            }


            if (dgvServiciosAdicionales.CurrentCell.ColumnIndex == dgvServiciosAdicionales.Columns.IndexOf(ServicioConcepto))
            {
                ComboBox cb = e.Control as ComboBox;

                if (cb != null)
                {
                    cb.SelectionChangeCommitted -= cmbServicioAdicional_SelectionChangeComitted;
                    cb.SelectionChangeCommitted += cmbServicioAdicional_SelectionChangeComitted;
                }
            }

        }

        private void cmbServicioAdicional_SelectionChangeComitted(object sender, EventArgs e)
        {
            var cb = dgvServiciosAdicionales.EditingControl as ComboBox;

            if (cb == null)
                return;

            int currentRowIdx = dgvServiciosAdicionales.SelectedCells[0].RowIndex;

            if (dgvServiciosAdicionales.SelectedCells[0] == null)
                return;

            var concepto = cb.SelectedItem as Concepto;

            if (concepto == null)
                return;

            int targetCell = dgvServiciosAdicionales.Columns.IndexOf(Importe);

            dgvServiciosAdicionales.Rows[currentRowIdx].Cells[targetCell].Value = concepto.Importe;
        }



        private void GenerarConceptosAdicionales()
        {
            if (Contrato == null) return;

            Contrato.ConceptosAdicionales = new List<ConceptoAdicional>();

            foreach (DataGridViewRow row in dgvServiciosAdicionales.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["ServicioConcepto"].Value == null) continue;

                decimal importe = 0m;

                var cmbServicioConcepto = row.Cells["ServicioConcepto"] as DataGridViewComboBoxCell;
                var cmbItems = cmbServicioConcepto.Items.Cast<Concepto>().ToList();
                var selectedItem = cmbItems.First(c => c.Id == (int)cmbServicioConcepto.Value);

                decimal.TryParse(row.Cells["Importe"].Value.ToString(), out importe);

                ConceptoAdicional conceptoAdicional = new ConceptoAdicional
                {
                    Concepto = selectedItem,
                    Importe = importe
                };

                Contrato.ConceptosAdicionales.Add(conceptoAdicional);
            }

            var adeudosCorriente = Contrato.Adeudos.Where(a => a.FechaPeriodo.Year == DateTime.Now.Year).ToList();
            var adeudosRezago = Contrato.Adeudos.Where(a => a.FechaPeriodo.Year < DateTime.Now.Year).ToList();

            var totalCorriente = adeudosCorriente.Sum(a => a.AdeudoTotal);
            var totalRezago = adeudosRezago.Sum(a => a.AdeudoTotal);
            var totalOtros = Contrato.ConceptosAdicionales.Sum(ca => ca.Importe);
            txtOtros.Text = totalOtros.ToString("N2");

            txtCorriente.Text = totalCorriente.ToString("N2");
            txtRezagos.Text = totalRezago.ToString("N2");

            var adeudoTotal = totalCorriente + totalRezago + totalOtros;
            var redondeo = Math.Abs(adeudoTotal - Math.Round(adeudoTotal));
            adeudoTotal = Math.Round(adeudoTotal);

            txtRedondeo.Text = redondeo.ToString("N2");
            txtAdeudoTotal.Text = adeudoTotal.ToString("N2");
        }

        private void dgvServiciosAdicionales_CellEndEdit(object sender, DataGridViewCellEventArgs e) => GenerarConceptosAdicionales();

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


        private void reestablecerEntradasVacias_Leave(object sender, EventArgs e)
        {
            if (sender == null) return;

            var txtCampo = (sender as TextBox);

            if (string.IsNullOrWhiteSpace(txtCampo.Text))
                txtCampo.Text = "0.00";
        }

        private void dgvServiciosAdicionales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dgvServiciosAdicionales.Rows[e.RowIndex].IsNewRow) return;

            if (e.ColumnIndex == dgvServiciosAdicionales.Columns.IndexOf(Importe))
            {
                dgvServiciosAdicionales.EndEdit();
                dgvServiciosAdicionales.BeginEdit(true);

            }
        }
    }
}


