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
using Clases;
using SAPA.Clases;
using SAPA.Reportes;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgPagoCompletar : Form
    {
        public Contrato Contrato { get; set; }
        public Pago Pago { get; set; }
        public List<AdeudoVista> Adeudos { get; set; }

        private decimal _totalPagar;

        public DlgPagoCompletar()
        {
            InitializeComponent();
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

            if (cantidadPagar < _totalPagar)
            {
                MessageBox.Show(
                    "La cantidad a pagar ingresada no cubre el monto total a pagar. Ingrese la cantidad completa e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

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

        private void DlgPagoCompletar_Load(object sender, EventArgs e)
        {
            CargarBancos();
            CargarTiposPago();

            txtFolio.Text = (Pago.GetUltimoFolio() + 1).ToString("D5");

            if (Pago != null)
            {
                _totalPagar = Math.Round(Pago.Detalles.AdeudoTotal);
                txtTotalPagar.Text = _totalPagar.ToString("N2");
                txtCantidad.Text = txtTotalPagar.Text;
            }
            else
            {
                _totalPagar = Contrato.ConceptosAdicionales.Sum(ca => ca.Importe);
                txtTotalPagar.Text = _totalPagar.ToString("N2");
                txtCantidad.Text = txtTotalPagar.Text;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            if (Pago == null)
            {
                var formaPago = cmbFormaPago.SelectedItem as FormaPago;

                bool requiereReferencia = formaPago.Descripcion.Contains("TRANSFERENCIA") ||
                                          formaPago.Descripcion.Contains("TARJETA DEBITO") ||
                                          formaPago.Descripcion.Contains("TARJETA CREDITO") ||
                                          formaPago.Descripcion.Contains("CHEQUE");

                Pago = new Pago
                {
                    Fecha = DateTime.Now,
                    NoContrato = Contrato.NoContrato,
                    FolioInterno = txtFolioInterno.Text,
                    FormaPago = formaPago,
                    Empleado = Empleado.Actual,
                    Caja = new Caja { Id = Empleado.Actual.IdCaja },
                    Banco = (requiereReferencia) ? cmbBanco.SelectedItem as Banco : new Banco { Id = 0 },
                    Referencia = (requiereReferencia) ? txtReferencia.Text : string.Empty,
                    Detalles = new PagoDetalle { ConceptosAdicionales = Contrato.ConceptosAdicionales }
                };

                Pago.Detalles.AdeudoTotal += Pago.Detalles.ConceptosAdicionales.Sum(ca => ca.Importe);

                // Creamos el registro de pago

                if (!Pago.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar agregar el registro de pago. Intente nuevamente si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Pago.Detalles.IdPago = Pago.Id;

                // Agregar registro de detalles sobre el registro de pago

                if (!Pago.Detalles.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar agregar los detalles del registro de pago. Intente nuevamente si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Pago.Detalles.DescuentoValores.Total > 0)
                {
                    if (!Pago.Detalles.AgregarDescuentoValores())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar agregar los valores de los descuentos al registro de pago. Intente nuevamente si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                foreach (ConceptoAdicional conceptoAdicional in Pago.Detalles.ConceptosAdicionales)
                {
                    if (!Pago.Detalles.AgregarConceptoAdicional(conceptoAdicional))
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar integrar los conceptos adicionales al pago. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }

                MessageBox.Show("El pago fue realizado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Completar el objeto de pago

                Pago.Fecha = DateTime.Now;
                Pago.FolioInterno = txtFolioInterno.Text;
                Pago.FormaPago = cmbFormaPago.SelectedItem as FormaPago;
                Pago.Empleado = Empleado.Actual;
                Pago.Caja = new Caja { Id = Empleado.Actual.IdCaja };

                var formaPago = cmbFormaPago.SelectedItem as FormaPago;

                bool requiereReferencia = formaPago.Descripcion.Contains("TRANSFERENCIA") ||
                                          formaPago.Descripcion.Contains("TARJETA DEBITO") ||
                                          formaPago.Descripcion.Contains("TARJETA CREDITO") ||
                                          formaPago.Descripcion.Contains("CHEQUE");

                Pago.Banco = (requiereReferencia) ? cmbBanco.SelectedItem as Banco : new Banco { Id = 0 };
                Pago.Referencia = (requiereReferencia) ? txtReferencia.Text : string.Empty;

                // Creamos el registro de pago

                if (!Pago.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar agregar el registro de pago. Intente nuevamente si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Pago.Detalles.IdPago = Pago.Id;

                // Agregar registro de detalles sobre el registro de pago

                if (!Pago.Detalles.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar agregar los detalles del registro de pago. Intente nuevamente si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Pago.Detalles.DescuentoValores.Total > 0)
                {
                    if (!Pago.Detalles.AgregarDescuentoValores())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar agregar los valores de los descuentos al registro de pago. Intente nuevamente si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Agregar registro de detalles de descuentos para cada descuento

                foreach (ContratoDescuento contratoDescuento in Pago.Detalles.DescuentosAplicados)
                {
                    if (!Pago.Detalles.AgregarDescuento(contratoDescuento))
                    {
                        MessageBox.Show(
                            $"Hubo un error al intentar agregar el descuento {contratoDescuento.Descuento.NombreTipoDescuento} del registro de pago. Intente nuevamente si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }

                foreach (ConceptoAdicional conceptoAdicional in Pago.Detalles.ConceptosAdicionales)
                {
                    if (!Pago.Detalles.AgregarConceptoAdicional(conceptoAdicional))
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar integrar los conceptos adicionales al pago. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }


                if (Contrato.IdTipoContrato == (int)Contrato.Tipo.ServicioMedido)
                {
                    // Actualizar ID de pago en Mediciones Pagadas

                    if (!Medicion.ActualizarPagoMediciones(Pago))
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar el folio de pago de las las mediciones afectadas. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MessageBox.Show("El pago fue realizado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            var msgBoxDlgResult = MessageBox.Show("¿Desea imprimir el recibo del pago que acaba de realizar?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgBoxDlgResult == DialogResult.Yes)
            {
                // Imprimir ticket y asignar parametros

                RptReciboPago rpt = new RptReciboPago();

                DataSet dsReporte = new DataSet();

                dsReporte.Tables.Add(Organismo.Actual);

                // Datos del encabezado
                rpt.SetDataSource(dsReporte);

                // Parametros del recibo
                rpt.SetParameterValue("Titulo", "RECIBO DE PAGO");
                rpt.SetParameterValue("Folio", Pago.Folio.ToString("D5"));

                rpt.SetParameterValue("NoContrato", Contrato.NoContrato.ToString("D10"));
                rpt.SetParameterValue("NombreContribuyente", Contrato.NombreUsuario);
                rpt.SetParameterValue("Direccion", Contrato.Direccion);

                if (Pago.Detalles.PeriodoInicio == default(DateTime) && Pago.Detalles.PeriodoFin == default(DateTime))
                    rpt.SetParameterValue("PeriodoPago", "N/A");
                else
                    rpt.SetParameterValue("PeriodoPago", $"{Pago.Detalles.PeriodoInicio.ToString("MMMM yyyy", new CultureInfo("es-MX"))} - {Pago.Detalles.PeriodoFin.ToString("MMMM yyyy", new CultureInfo("es-MX"))}".ToUpper());

                rpt.SetParameterValue("Tarifa", Contrato.NombreTarifa);
                rpt.SetParameterValue("FormaPago", (Pago.FormaPago == null) ? "N/A" : Pago.FormaPago.Descripcion);

                var totalAgua = Adeudos.Sum(a => a.Agua);
                var totalAlcantarillado = Adeudos.Sum(a => a.Alcantarillado);
                var totalSaneamiento = Adeudos.Sum(a => a.Saneamiento);
                var totalRecargos = Adeudos.Sum(a => a.Recargos);
                var totalMultas = Adeudos.Sum(a => a.Multas);
                var totalIVA = Adeudos.Sum(a => a.IVA);

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

                rpt.SetParameterValue("FechaPago", $"{Pago.Fecha.ToShortDateString()} {Pago.Fecha.ToShortTimeString()}");
                rpt.SetParameterValue("TotalEnLetra", Utilerias.CantidadEnLetras(Pago.Detalles.AdeudoTotal));

                string cadenaListadoConceptos = string.Empty;

                foreach (ConceptoAdicional ca in Pago.Detalles.ConceptosAdicionales)
                {
                    cadenaListadoConceptos += $"{ca.Concepto.Descripcion}\t{ca.Importe.ToString("N2")}\n";
                }

                rpt.SetParameterValue("CadenaListadoConceptos", string.IsNullOrWhiteSpace(cadenaListadoConceptos) ? " " : cadenaListadoConceptos);

                rpt.PrintToPrinter(1, true, 1, 1);
            }

            DialogResult = DialogResult.OK;
        }

        // Funcionalidad responsiva del formulario

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

                    txtCambio.Visible = true;
                    lblCambio.Visible = true;
                    break;


                case "TRANSFERENCIA":
                case "TARJETA DEBITO":
                case "TARJETA CREDITO":
                    lblReferencia.Text = "Referencia";

                    lblReferencia.Visible = true;
                    txtReferencia.Visible = true;

                    lblBanco.Visible = true;
                    cmbBanco.Visible = true;

                    txtCambio.Visible = false;
                    lblCambio.Visible = false;
                    break;

                case "CHEQUE":
                    lblReferencia.Text = "No. Cheque";

                    lblReferencia.Visible = true;
                    txtReferencia.Visible = true;

                    lblBanco.Visible = true;
                    cmbBanco.Visible = true;

                    txtCambio.Visible = false;
                    lblCambio.Visible = false;
                    break;

                default:
                    lblReferencia.Text = "Referencia";

                    lblReferencia.Visible = false;
                    txtReferencia.Visible = false;

                    lblBanco.Visible = false;
                    cmbBanco.Visible = false;

                    txtCambio.Visible = true;
                    lblCambio.Visible = true;
                    break;
            }
        }

        private Point? _txtCambioOriginalLocation;
        private Point? _lblCambioOriginalLocation;
        private Size? _frmOriginalSize;

        private void cmbBanco_VisibleChanged(object sender, EventArgs e)
        {
            if (!cmbBanco.Visible)
            {
                // Guardamos la ubicación original de los controles y el tamaño original del formulario
                if (_lblCambioOriginalLocation == null) _lblCambioOriginalLocation = lblCambio.Location;
                if (_txtCambioOriginalLocation == null) _txtCambioOriginalLocation = txtCambio.Location;
                if (_frmOriginalSize == null) _frmOriginalSize = this.Size;

                // Creamos ubicaciones a partir de sus ejes X, Y
                Point textBoxNewLocation = new Point(txtCambio.Location.X, txtReferencia.Location.Y);
                Point labelNewLocation = new Point(lblCambio.Location.X, lblReferencia.Location.Y);

                // Redimensionamos el formulario

                Size formNewSize = new Size(324, 396);

                this.Size = formNewSize;
                txtCambio.Location = textBoxNewLocation;
                lblCambio.Location = labelNewLocation;
                return;
            }

            // Si el control cmbBanco es visible otra vez, reestablecemos las ubicaciones originales de los controles
            // y el tamaño original del formulario

            if (_lblCambioOriginalLocation == null) return;
            lblCambio.Location = _lblCambioOriginalLocation.Value;

            if (_txtCambioOriginalLocation == null) return;
            txtCambio.Location = _txtCambioOriginalLocation.Value;

            if (_frmOriginalSize == null) return;
            this.Size = (Size)_frmOriginalSize;

        }

        // Actualizar el cambio a dar

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (!txtCambio.Visible) return;

            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                txtCambio.Text = "00.00";
                return;
            }

            decimal cantidadAdeudo = 0m;
            decimal cantidadPagar = 0m;

            if (!decimal.TryParse(txtTotalPagar.Text, out cantidadAdeudo)) return;
            if (!decimal.TryParse(txtCantidad.Text, out cantidadPagar)) return;

            decimal cambio = cantidadPagar - cantidadAdeudo;

            txtCambio.Text = cambio <= 0 ? "00.00" : cambio.ToString("N2");
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
    }
}

