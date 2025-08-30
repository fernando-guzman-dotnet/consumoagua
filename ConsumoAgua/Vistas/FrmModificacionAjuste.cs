using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas
{
    public partial class FrmModificacionAjuste : Form
    {
        public FrmModificacionAjuste()
        {
            InitializeComponent();
            Porcentajes = Clases.Porcentajes.GetPorcentajes();


            //Empleados = Empleado.Empleados_Select();

            //DataRow rw = Empleados.NewRow();
            //rw["Id"] = 0;
            //rw["Nombre"] = "[ -- Seleccione un empleado -- ]";

            //Empleados.Rows.InsertAt(rw, 0);
            //cmbEmpleado.DataSource = Empleados;
            cmbEmpleado.DisplayMember = "Id";
        }

        public DataTable DatosPago { get; set; }
        public DataTable Empleados { get; set; }
        public List<Porcentajes> Porcentajes { get; set; }
        public DataTable BonificacionAPagar { get; set; }


        public int tarifa { get; set; }
        public string tipoTarifa { get; set; }
        public DataTable DatosTarifaCli { get; set; }
        public DataTable DatosConvenio { get; set; }
        public DataTable UltimoPagoMes { get; set; }
        public bool Domestico { get; set; }
        public decimal AguaRezago { get; set; }
        public decimal AlcantarilladoRezago { get; set; }
        public int idTipoContrato { get; set; }
        public int MesesQueSePagan { get; set; }

        public decimal consIVA = 0;
        public decimal porAlcantarillado = 0;
        public decimal porSaneamiento = 0;
        public decimal Agua = 0m;
        public int perC = 0;
        public int bonC = 0;
        public decimal AguaRez = 0m;
        public decimal AlcantarilladoRez = 0m;
        public decimal auxAgua = 0m;
        public decimal auxAguaRezago = 0m;
        public decimal auxAlcantarilladoRezago = 0m;
        public decimal IVARezago = 0;
        public decimal IVACurrent = 0;

        public Empleado Empleado { get; set; }
        public FrmPrincipal FrmPrincipal { get; set; }

        public List<AdeudoVista> adeudoVistaBonificacion = new List<AdeudoVista>();
        //public List<ContratosConceptos> contratosConceptos = new List<ContratosConceptos>();
        //public List<Concepto_OrdenesTrabajo> concepto_OrdenTrabajo = new List<Concepto_OrdenesTrabajo>();

        public int Bandera = 0;
        //bandera = 0, el formulario se abrio desde pagos
        //bandera = 1, el fomulario se abrio desde el F_main

        decimal sumaParaIVA = 0m;
        public void AsignarPorcentajes(DataTable tbl)
        {
            consIVA = decimal.Parse(tbl.Rows[0]["IVA"].ToString());
            porAlcantarillado = decimal.Parse(tbl.Rows[0]["PorcentajeAlcantarillado"].ToString());
            porSaneamiento = decimal.Parse(tbl.Rows[0]["PorcentajeSaneamiento"].ToString());
        }

        private void btnCuentaBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //VistasReportes.DlgCuentaSelect dlg = new VistasReportes.DlgCuentaSelect();
                //dlg.Porcentajes = this.Porcentajes;
                //if (dlg.ShowDialog() == DialogResult.OK)
                //{
                //    if (dlg.SoloAnticipado)
                //    {
                //        MessageBox.Show("Esta cuenta tienes todos sus pagos al corriente, solo se pueden registrar pagos anticipados", "Formulario Bonificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //    if (dlg.ConvenioActivo)
                //    {
                //        MessageBox.Show("Esta cuenta tiene un Convenio activo, no se puede generar una bonificación", "Formulario Bonificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //    if (dlg.BonificacionActiva)
                //    {
                //        MessageBox.Show("Esta cuenta ya contiene una bonificación que actualmente esta activa", "Formulario Bonificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //    if (dlg.DescuentoParcialActivo)
                //    {
                //        MessageBox.Show("Esta cuenta tiene un descuento parcial activo, no se puede generar una bonificación", "Formulario Bonificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }

                //    tarifa = dlg.Tarifa.Id;
                //    tipoTarifa = dlg.Tarifa.Descripcion;
                //    txtTarifa.Text = dlg.Tarifa.ToString();
                //    txtNoContrato.Text = dlg.Contrato.NoContrato.ToString();
                //    //txtMedidor.Text = frm.medidor.ToString();
                //    //txtServicios.Text = frm.servicios.ToString();
                //    txtNombre.Text = dlg.Contrato.Usuario.NombreCompleto;
                //    adeudoVistaBonificacion = dlg.AdeudosBimestralesAgua;
                //    //txtColonia.Text = frm.Colonia;


                //    List<AdeudoVista> corriente = new List<AdeudoVista>();
                //    corriente = adeudoVistaBonificacion.Where(x => x.FechaPeriodo.Year == DateTime.Now.Year).ToList();
                //    txtAguaActual.Text = corriente.Sum(x => x.Agua).ToString("N2");
                //    txtAlcantarilladoActual.Text = corriente.Sum(x => x.Alcantarillado).ToString("N2");
                //    txtSaneamientoActual.Text = corriente.Sum(x => x.Saneamiento).ToString();
                //    corriente = adeudoVistaBonificacion.Where(x => x.FechaPeriodo.Year != DateTime.Now.Year).ToList();
                //    AguaRez = corriente.Sum(x => x.Agua);
                //    AlcantarilladoRez = corriente.Sum(x => x.Alcantarillado);


                //    txtRezagosActual.Text = (AguaRez + AlcantarilladoRez).ToString("N2");
                //    txtRecargosActual.Text = adeudoVistaBonificacion.Sum(x => x.Recargos).ToString("N2");
                //    txtMultasActual.Text = adeudoVistaBonificacion.Sum(x => x.Multas).ToString("N2");
                //    txtGastosActual.Text = adeudoVistaBonificacion.Sum(x => x.GastosEjecucion).ToString("N2");
                //    txtIVAActual.Text = adeudoVistaBonificacion.Sum(x => x.IVA).ToString("N2");

                //    //concepto_OrdenTrabajo = dlg.OrdenesTrabajo;
                //    //contratosConceptos = dlg.ContratosConceptos;

                //    txtVariosxCobrarActual.Text = "0.00";//(concepto_OrdenTrabajo.Sum(x => x.Importe)).ToString();
                //    txtVariosxCobrarAPagar.Text = txtVariosxCobrarActual.Text;
                //    //txtUltimoPago.Text = frm.UltimoPago.ToString();
                //    decimal redondeo = (Math.Ceiling(SumaCamposOriginal()) - SumaCamposOriginal());
                //    txtRedondeoActual.Text = redondeo.ToString();
                //    txtTotalActual.Text = (SumaCamposOriginal()).ToString();
                //    //txtAño.Text = frm.AñoPago.ToString();
                //    //txtMeses.Text = frm.MesesTotal.ToString();
                //    DatosTarifaCli = dlg.ValoresCobroAgua;
                //    DatosConvenio = dlg.Convenios;
                //    UltimoPagoMes = dlg.UltimosPagos;
                //    Domestico = dlg.Domestico;
                //    //--------------------------------------//
                //    //AguaRezago = frm.AguaRezago;
                //    //AlcantarilladoRezago = frm.AlcantarilladoRezago;
                //    //--------------------------------------//
                //    //txtPeriodo.Text = frm.PeriodoDePago;
                //    //this.activo = frm.Activo;
                //    //PagoDAO obj = new PagoDAO();
                //    //dgvHistorico.DataSource = obj.getPagosPorContrato(frm.noCuenta);
                //    //dgvHistorico.Columns["idFormaPago"].Visible = false;
                //    //dgvHistorico.Columns["Folio"].Visible = false;
                //    idTipoContrato = dlg.Contrato.IdTipoContrato;
                //    txtFechaInicio.Text = adeudoVistaBonificacion.First().FechaPeriodo.ToShortDateString();
                //    txtFechaFin.Text = adeudoVistaBonificacion.Last().FechaPeriodo.ToShortDateString();
                //    //MesesQueSePagan = adeudoVistaBonificacion.Last().Meses;
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnCuentaBuscar_Click - " + ex.Message, "Formulario frmModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmModificacionyAjuste_Load(object sender, EventArgs e)
        {
            if (Bandera == 0)
            {
                AsignarObjtoGUi();
                DateTime Fecha = DateTime.Now;
                DateTime Fecha2 = Fecha.AddYears(-5);
                /*DataTable aux = Bonificaciones.GetByNoContrato(Convert.ToInt32(DatosPago.Rows[0]["Cuenta"].ToString()), Fecha, Fecha2);
                if (aux.Rows.Count > 0)
                {
                    TableToGUI(aux);
                }
                */
            }
        }
        private void TableToGUI(DataTable Boni)
        {
            txtPorcentajeAgua.Text = Boni.Rows[0]["PorAgua"].ToString();
            txtperAgua_Validated(null, null);
            txtPorcentajeRezagos.Text = Boni.Rows[0]["PorRezagos"].ToString();
            txtPorRezagos_Validated(null, null);
            txtPorcentajeRecargos.Text = Boni.Rows[0]["PorRecargo"].ToString();
            txtperRecargos_Validated(null, null);
            txtPorcentajeMultas.Text = Boni.Rows[0]["PorMulta"].ToString();
            txtperMultas_Validated(null, null);
            txtPorcentajeGastosEjecucion.Text = Boni.Rows[0]["PorGastos"].ToString();
            txtPerGastosEjec_Validated(null, null);
        }

        private void AsignarObjtoGUi()
        {
            txtNoContrato.Text = DatosPago.Rows[0]["Cuenta"].ToString();
            txtTarifa.Text = DatosPago.Rows[0]["Tarifa"].ToString();
            txtNombre.Text = DatosPago.Rows[0]["Nombre"].ToString();
            txtDireccion.Text = DatosPago.Rows[0]["Direccion"].ToString();
            txtAguaActual.Text = Agua.ToString();
            txtAlcantarilladoActual.Text = (decimal.Parse(DatosPago.Rows[0]["PresenteMes"].ToString()) - Agua).ToString();
            txtSaneamientoActual.Text = "0.00";
            txtRezagosActual.Text = DatosPago.Rows[0]["Rezagos"].ToString();
            txtRecargosActual.Text = DatosPago.Rows[0]["Recargos"].ToString();
            txtMultasActual.Text = DatosPago.Rows[0]["Multas"].ToString();
            txtGastosActual.Text = DatosPago.Rows[0]["GastosEjecucion"].ToString();
            txtRedondeoActual.Text = DatosPago.Rows[0]["Otros"].ToString();
            txtIVAActual.Text = DatosPago.Rows[0]["IVA"].ToString();
            txtVariosxCobrarActual.Text = DatosPago.Rows[0]["VariosxCobrar"].ToString();
            txtTotalActual.Text = Suma().ToString();

        }
        private decimal Suma()
        {
            decimal suma1 = decimal.Parse(txtAguaActual.Text) + decimal.Parse(txtAlcantarilladoActual.Text) + decimal.Parse(txtSaneamientoActual.Text) + decimal.Parse(txtRezagosActual.Text) + decimal.Parse(txtRecargosActual.Text) +
                decimal.Parse(txtMultasActual.Text) + decimal.Parse(txtGastosActual.Text) + decimal.Parse(txtRedondeoActual.Text) + decimal.Parse(txtIVAActual.Text) + decimal.Parse(txtVariosxCobrarActual.Text);
            return suma1;
        }

        public void ObtenerDIF()
        {
            decimal redondeo = (Math.Ceiling(SumaAPagar()) - SumaAPagar());
            txtRedondeoAPagar.Text = redondeo.ToString("N2");
        }
        public void ObtenerRedondeoBonificacion()
        {
            txtBonificacionRedondeo.Text = "0.00";
            decimal SumaRedondear = Math.Ceiling(SumaCamposBonificar());
            decimal Suma = SumaCamposBonificar();
            decimal redondeo = (SumaRedondear - Suma);
            txtBonificacionRedondeo.Text = redondeo.ToString("N2");
        }

        private void txtBonAgua_Validated(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBonificacionAgua.Text) || txtBonificacionAgua.Text.Equals("0.00") || txtBonificacionAgua.Text.Equals("0"))
                {
                    txtBonificacionAgua.Text = "0.00";
                    txtPorcentajeAgua.Text = "0.00";
                    txtAguaAPagar.Text = (Convert.ToDecimal(txtAguaActual.Text) - Convert.ToDecimal(txtBonificacionAgua.Text)).ToString("N2");
                    txtBonificacionAlcantarillado.Text = "0.00";
                    txtAlcantarilladoAPagar.Text = (Convert.ToDecimal(txtAlcantarilladoActual.Text) - Convert.ToDecimal(txtAlcantarilladoAPagar.Text)).ToString("N2");
                }
                else
                {

                    decimal per = 100m / Convert.ToDecimal(txtAguaActual.Text);
                    txtPorcentajeAgua.Text = (Convert.ToDecimal(txtBonificacionAgua.Text) * per).ToString("N2");
                    txtBonificacionAlcantarillado.Text = (Convert.ToDecimal(txtBonificacionAgua.Text) * (Porcentajes[0].Alcantarillado / 100)).ToString("N2");
                    txtBonificacionSaneamiento.Text = "0.00"; /*(Convert.ToDecimal(txtBonAgua.Text) * (Convert.ToDecimal(Porcentajes.Rows[0]["PorcentajeSaneaminto"].ToString())) / 100).ToString("N2");*/
                    if (Bandera == 0)
                    {
                        if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionAgua.Text) + Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + Convert.ToDecimal(txtBonificacionSaneamiento.Text) + Convert.ToDecimal(txtBonificacionRezagos.Text));
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            decimal RezagosAlcantarillado = Convert.ToDecimal(txtBonificacionRezagos.Text) * (Porcentajes[0].Alcantarillado / 100);
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionSaneamiento.Text) + Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + RezagosAlcantarillado);
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");

                        }
                        txtAlcantarilladoAPagar.Text = (Convert.ToDecimal(txtAlcantarilladoActual.Text) - Convert.ToDecimal(txtBonificacionAlcantarillado.Text)).ToString("N2");
                        txtAguaAPagar.Text = (Convert.ToDecimal(txtAguaActual.Text) - Convert.ToDecimal(txtBonificacionAgua.Text)).ToString("N2");
                        if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtAguaAPagar.Text) + Convert.ToDecimal(txtAlcantarilladoAPagar.Text) +
                                             Convert.ToDecimal(txtSaneamientoAPagar.Text) + Convert.ToDecimal(txtRezagosAPagar.Text));
                            txtIVAAPagar.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            decimal RezagosAlcantarillado = Convert.ToDecimal(txtRezagosAPagar.Text) * (Porcentajes[0].Alcantarillado / 100);
                            sumaParaIVA = (Convert.ToDecimal(txtAlcantarilladoAPagar.Text) +
                                            Convert.ToDecimal(txtSaneamientoAPagar.Text) + RezagosAlcantarillado);
                            txtIVAAPagar.Text = (sumaParaIVA - (sumaParaIVA / ((Porcentajes[0].IVA / 100) + 1))).ToString("N2");
                        }
                    }
                    else
                    {
                        if (!Domestico)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionAgua.Text) + Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + Convert.ToDecimal(txtBonificacionSaneamiento.Text) + Convert.ToDecimal(txtBonificacionRezagos.Text));
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            decimal RezagosAlcantarillado = Convert.ToDecimal(txtBonificacionRezagos.Text) * (Porcentajes[0].Alcantarillado / 100);
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + Convert.ToDecimal(txtBonificacionSaneamiento.Text) + RezagosAlcantarillado);
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");


                        }
                        //auxAgua = (Convert.ToDecimal(txtAgua.Text) + Convert.ToDecimal(txtAlcantarillado.Text));
                        //auxAgua = auxAgua - Convert.ToDecimal(txtBonAgua.Text);
                        txtAlcantarilladoAPagar.Text = (Convert.ToDecimal(txtAlcantarilladoActual.Text) - Convert.ToDecimal(txtBonificacionAlcantarillado.Text)).ToString("N2");
                        txtAguaAPagar.Text = (Convert.ToDecimal(txtAguaActual.Text) - Convert.ToDecimal(txtBonificacionAgua.Text)).ToString("N2");
                        if (!Domestico)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtAguaAPagar.Text) + Convert.ToDecimal(txtAlcantarilladoAPagar.Text) +
                                             Convert.ToDecimal(txtSaneamientoAPagar.Text) + Convert.ToDecimal(txtRezagosAPagar.Text));
                            txtIVAAPagar.Text = (sumaParaIVA * ((Porcentajes[0].IVA / 100))).ToString("N2");
                        }
                        else
                        {
                            decimal RezagosAlcantarillado = Convert.ToDecimal(txtRezagosAPagar.Text) * (Porcentajes[0].Alcantarillado / 100);
                            sumaParaIVA = (Convert.ToDecimal(txtAlcantarilladoAPagar.Text) +
                                            Convert.ToDecimal(txtSaneamientoAPagar.Text) + RezagosAlcantarillado);
                            txtIVAAPagar.Text = (sumaParaIVA * ((Porcentajes[0].IVA / 100))).ToString("N2");
                        }
                    }
                }
                ObtenerDIF();
                txtTotalAPagar.Text = (Convert.ToDecimal(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                ObtenerRedondeoBonificacion();
                txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                txtSaldo.Text = txtTotalAPagar.Text;

            }
            catch (Exception ex)
            {

                MessageBox.Show("txtBonAgua_Validated - " + ex.Message, "Formulario frmModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtperAgua_Validated(object sender, EventArgs e)
        {

            try
            {
                if (txtPorcentajeAgua.Text.Equals("0"))
                {
                    txtPorcentajeAgua.Text = ("0.00");
                }
                if (string.IsNullOrEmpty(txtPorcentajeAgua.Text) || txtPorcentajeAgua.Text.Equals("0.00"))
                {
                    txtPorcentajeAgua.Text = "0.00";
                    txtBonificacionAgua.Text = "0.00";
                    txtAguaAPagar.Text = (Convert.ToDecimal(txtAguaActual.Text) - Convert.ToDecimal(txtBonificacionAgua.Text)).ToString("N2");
                    txtBonificacionAlcantarillado.Text = "0.00";
                    txtAlcantarilladoAPagar.Text = (Convert.ToDecimal(txtAlcantarilladoActual.Text) -
                                                Convert.ToDecimal(txtAlcantarilladoAPagar.Text)).ToString("N2");
                    txtTotalAPagar.Text = (Convert.ToDecimal(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
                else
                {

                    decimal porcentaje = Convert.ToDecimal(txtPorcentajeAgua.Text) / 100m;
                    txtBonificacionAgua.Text = (Convert.ToDecimal(txtAguaActual.Text) * porcentaje).ToString("N2");
                    txtBonificacionAlcantarillado.Text = (Convert.ToDecimal(txtBonificacionAgua.Text) * (Porcentajes[0].Alcantarillado / 100)).ToString("N2");
                    txtBonificacionSaneamiento.Text = "0.00"; /*(Convert.ToDecimal(txtBonAgua.Text) / (Convert.ToDecimal(Porcentajes.Rows[0]["PorcentajeSaneamiento"].ToString())) / 100).ToString("N2");*/
                    if (Bandera == 0)
                    {
                        if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionAgua.Text) + Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + Convert.ToDecimal(txtBonificacionSaneamiento.Text) + Convert.ToDecimal(txtBonificacionRezagos.Text));
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            decimal RezagosAlcantarillado = Convert.ToDecimal(txtBonificacionRezagos.Text) * (Porcentajes[0].Alcantarillado / 100);
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionSaneamiento.Text) + Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + RezagosAlcantarillado);
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");

                        }
                        txtAlcantarilladoAPagar.Text = (Convert.ToDecimal(txtAlcantarilladoActual.Text) - Convert.ToDecimal(txtBonificacionAlcantarillado.Text)).ToString("N2");
                        txtAguaAPagar.Text = (Convert.ToDecimal(txtAguaActual.Text) - Convert.ToDecimal(txtBonificacionAgua.Text)).ToString("N2");
                        if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtAguaAPagar.Text) + Convert.ToDecimal(txtAlcantarilladoAPagar.Text) +
                                             Convert.ToDecimal(txtSaneamientoAPagar.Text) + Convert.ToDecimal(txtRezagosAPagar.Text));
                            txtIVAAPagar.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            decimal RezagosAlcantarillado = Convert.ToDecimal(txtRezagosAPagar.Text) * (Porcentajes[0].Alcantarillado / 100);
                            sumaParaIVA = (Convert.ToDecimal(txtAlcantarilladoAPagar.Text) + Convert.ToDecimal(txtSaneamientoAPagar.Text) + RezagosAlcantarillado);
                            txtIVAAPagar.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                    }
                    else
                    {
                        if (!Domestico)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionAgua.Text) + Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + Convert.ToDecimal(txtBonificacionSaneamiento.Text) + Convert.ToDecimal(txtBonificacionRezagos.Text));
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            decimal RezagosAlcantarillado = Convert.ToDecimal(txtBonificacionRezagos.Text) * (Porcentajes[0].Alcantarillado / 100);
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + Convert.ToDecimal(txtBonificacionSaneamiento.Text) + RezagosAlcantarillado);
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");


                        }
                        //auxAgua = (Convert.ToDecimal(txtAgua.Text) + Convert.ToDecimal(txtAlcantarillado.Text));
                        //auxAgua = auxAgua - Convert.ToDecimal(txtBonAgua.Text);
                        txtAlcantarilladoAPagar.Text = (Convert.ToDecimal(txtAlcantarilladoActual.Text) - Convert.ToDecimal(txtBonificacionAlcantarillado.Text)).ToString("N2");
                        txtAguaAPagar.Text = (Convert.ToDecimal(txtAguaActual.Text) - Convert.ToDecimal(txtBonificacionAgua.Text)).ToString("N2");
                        if (!Domestico)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtAguaAPagar.Text) + Convert.ToDecimal(txtAlcantarilladoAPagar.Text) +
                                             Convert.ToDecimal(txtSaneamientoAPagar.Text) + Convert.ToDecimal(txtRezagosAPagar.Text));
                            txtIVAAPagar.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            decimal RezagosAlcantarillado = Convert.ToDecimal(txtRezagosAPagar.Text) * (Porcentajes[0].Alcantarillado / 100);
                            sumaParaIVA = (Convert.ToDecimal(txtAlcantarilladoAPagar.Text) + Convert.ToDecimal(txtSaneamientoAPagar.Text) + RezagosAlcantarillado);
                            txtIVAAPagar.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                    }
                }

                ObtenerDIF();
                txtTotalAPagar.Text = (Convert.ToDecimal(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                ObtenerRedondeoBonificacion();
                txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                txtSaldo.Text = txtTotalAPagar.Text;
            }
            catch (Exception ex)
            {

                MessageBox.Show("txtperAgua_Validated - " + ex.Message, "Formulario frmModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBonRecargos_Validated(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(txtBonificacionRecargos.Text) || txtBonificacionRecargos.Text.Equals("0.00") || txtBonificacionRecargos.Text.Equals("0"))
                {
                    txtBonificacionRecargos.Text = "0.00";
                    txtPorcentajeRecargos.Text = "0.00";
                    txtRecargosAPagar.Text = (Convert.ToDecimal(txtRecargosActual.Text) - Convert.ToDecimal(txtBonificacionRecargos.Text)).ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
                else
                {
                    decimal per = decimal.Parse(txtRecargosActual.Text) / 100m;

                    txtPorcentajeRecargos.Text = (decimal.Parse(txtBonificacionRecargos.Text) / per).ToString("N2");
                    txtRecargosAPagar.Text = (decimal.Parse(txtRecargosActual.Text) - decimal.Parse(txtBonificacionRecargos.Text)).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
                //if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                //{
                //    txtBonIVA.Text = ((decimal.Parse(txtBonAgua.Text) + decimal.Parse(txtBonRezagos.Text) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
                //else
                //{
                //    txtBonIVA.Text = ((decimal.Parse(DatosPago.Rows[0]["AlcantarilladoRezago"].ToString()) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtBonRecargos_Validated - " + ex.Message, "Formulario frmModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtperRecargos_Validated(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(txtPorcentajeRecargos.Text) || txtPorcentajeRecargos.Text.Equals("0.00") || txtPorcentajeRecargos.Text.Equals("0"))
                {
                    txtPorcentajeRecargos.Text = "0.00";
                    txtBonificacionRecargos.Text = "0.00";
                    txtRecargosAPagar.Text = (Convert.ToDecimal(txtRecargosActual.Text) - Convert.ToDecimal(txtBonificacionRecargos.Text)).ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
                else
                {
                    decimal per = decimal.Parse(txtPorcentajeRecargos.Text) / 100m;
                    txtBonificacionRecargos.Text = (decimal.Parse(txtRecargosActual.Text) * per).ToString("N2");
                    txtRecargosAPagar.Text = (decimal.Parse(txtRecargosActual.Text) - decimal.Parse(txtBonificacionRecargos.Text)).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
                //if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                //{
                //    txtBonIVA.Text = ((decimal.Parse(txtBonAgua.Text) + decimal.Parse(txtBonRezagos.Text) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
                //else
                //{
                //    txtBonIVA.Text = ((decimal.Parse(DatosPago.Rows[0]["AlcantarilladoRezago"].ToString()) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtperRecargos_Validated - " + ex.Message, "Formulario frmModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtperMultas_Validated(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(txtPorcentajeMultas.Text) || txtPorcentajeMultas.Text.Equals("0.00") || txtPorcentajeMultas.Text.Equals("0"))
                {
                    txtPorcentajeMultas.Text = "0.00";
                }
                else
                {
                    decimal per = decimal.Parse(txtPorcentajeMultas.Text) / 100m;

                    txtBonificacionMultas.Text = (decimal.Parse(txtMultasActual.Text) * per).ToString("N2");
                    txtMultasAPagar.Text = (decimal.Parse(txtMultasActual.Text) - decimal.Parse(txtBonificacionMultas.Text)).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }

                //if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                //{
                //    txtBonIVA.Text = ((decimal.Parse(txtBonAgua.Text) + decimal.Parse(txtBonRezagos.Text) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
                //else
                //{
                //    txtBonIVA.Text = ((decimal.Parse(DatosPago.Rows[0]["AlcantarilladoRezago"].ToString()) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show("txtperMultas_Validated - " + ex.Message, "Formulario ModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBonMultas_Validated(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtBonificacionMultas.Text) || txtBonificacionMultas.Text.Equals("0.00") || txtBonificacionMultas.Text.Equals("0"))
                {
                    txtBonificacionMultas.Text = "0.00";
                    txtPorcentajeMultas.Text = "0.00";
                    txtMultasAPagar.Text = (Convert.ToDecimal(txtMultasActual.Text) - Convert.ToDecimal(txtBonificacionMultas.Text)).ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
                else
                {
                    decimal per = decimal.Parse(txtMultasActual.Text) / 100m;

                    txtPorcentajeMultas.Text = (decimal.Parse(txtBonificacionMultas.Text) / per).ToString("N2");
                    txtMultasAPagar.Text = (Convert.ToDecimal(txtMultasActual.Text) - Convert.ToDecimal(txtBonificacionMultas.Text)).ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
                //if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                //{
                //    txtBonIVA.Text = ((decimal.Parse(txtBonAgua.Text) + decimal.Parse(txtBonRezagos.Text) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
                //else
                //{
                //    txtBonIVA.Text = ((decimal.Parse(DatosPago.Rows[0]["AlcantarilladoRezago"].ToString()) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show("txtBonMultas_Validated - " + ex.Message, "Formulario frmModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPerGastosEjec_Validated(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(txtPorcentajeGastosEjecucion.Text) || txtPorcentajeGastosEjecucion.Text.Equals("0.00") || txtPorcentajeGastosEjecucion.Text.Equals("0"))
                {
                    txtPorcentajeGastosEjecucion.Text = "0.00";
                    txtBonificacionGastos.Text = "0.00";
                    txtGastosEjecucionAPagar.Text = (Convert.ToDecimal(txtGastosActual.Text) - Convert.ToDecimal(txtBonificacionGastos.Text)).ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
                else
                {

                    decimal per = decimal.Parse(txtPorcentajeGastosEjecucion.Text) / 100m;

                    txtBonificacionGastos.Text = (decimal.Parse(txtGastosActual.Text) * per).ToString("N2");
                    txtGastosEjecucionAPagar.Text = (decimal.Parse(txtGastosActual.Text) - decimal.Parse(txtBonificacionGastos.Text)).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;

                }

                //if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                //{
                //    txtBonIVA.Text = ((decimal.Parse(txtBonAgua.Text) + decimal.Parse(txtBonRezagos.Text) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
                //else
                //{
                //    txtBonIVA.Text = ((decimal.Parse(DatosPago.Rows[0]["AlcantarilladoRezago"].ToString()) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show("txtPerGastosEjec_Validated - " + ex.Message, "Formulario frmModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBonGastos_Validated(object sender, EventArgs e)
        {
            try
            {

                if (txtBonificacionGastos.Text.Equals("0"))
                {
                    txtBonificacionGastos.Text = ("0.00");
                }
                if (string.IsNullOrEmpty(txtBonificacionGastos.Text) || txtBonificacionGastos.Text.Equals("0.00"))
                {
                    txtPorcentajeGastosEjecucion.Text = "0.00";
                    txtGastosEjecucionAPagar.Text = (Convert.ToDecimal(txtGastosActual.Text) -
                                            Convert.ToDecimal(txtBonificacionGastos.Text)).ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
                else
                {

                    decimal per = decimal.Parse(txtPorcentajeGastosEjecucion.Text) / 100m;
                    txtBonificacionGastos.Text = (decimal.Parse(txtGastosActual.Text) * per).ToString("N2");
                    txtGastosEjecucionAPagar.Text = (decimal.Parse(txtGastosActual.Text) - decimal.Parse(txtBonificacionGastos.Text)).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }

                //if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                //{
                //    txtBonIVA.Text = ((decimal.Parse(DatosPago.Rows[0]["AlcantarilladoRezago"].ToString()) + decimal.Parse(txtBonRezagos.Text) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
                //else
                //{
                //    txtBonIVA.Text = ((decimal.Parse(txtBonRezagos.Text) + decimal.Parse(txtBonSaneamiento.Text) + decimal.Parse(txtBonAlcantarillado.Text)) *
                //                      (decimal.Parse(Porcentajes.Rows[0]["IVA"].ToString()) / 100)).ToString("N2");
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show("txtBonGastos_Validated - " + ex.Message, "Formulario frmModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex > 0)
            {
                for (int i = 0; i < Empleados.Rows.Count; i++)
                {
                    if (int.Parse(Empleados.Rows[i]["IdEmpleado"].ToString()) == int.Parse(cmbEmpleado.SelectedValue.ToString()))
                    {
                        txtPuesto.Text = Empleados.Rows[i]["Descripcion"].ToString();
                        break;
                    }
                }
            }
        }

        private decimal SumaCamposOriginal()
        {
            decimal aux = (Convert.ToDecimal(txtAguaActual.Text) + Convert.ToDecimal(txtAlcantarilladoActual.Text) +
                            Convert.ToDecimal(txtSaneamientoActual.Text) + Convert.ToDecimal(txtRezagosActual.Text) +
                            Convert.ToDecimal(txtRecargosActual.Text) + Convert.ToDecimal(txtMultasActual.Text) +
                            Convert.ToDecimal(txtGastosActual.Text) + Convert.ToDecimal(txtIVAActual.Text) +
                            Convert.ToDecimal(txtRedondeoActual.Text) + Convert.ToDecimal(txtVariosxCobrarActual.Text));
            return aux;
        }
        private decimal SumaCamposBonificar()
        {
            decimal sumaTotal = 0m;
            sumaTotal = decimal.Parse(txtBonificacionAgua.Text) + decimal.Parse(txtBonificacionAlcantarillado.Text) +
                decimal.Parse(txtBonificacionSaneamiento.Text) + decimal.Parse(txtBonificacionRezagos.Text) + decimal.Parse(txtBonificacionRecargos.Text) +
                decimal.Parse(txtBonificacionMultas.Text) + decimal.Parse(txtBonificacionGastos.Text) + decimal.Parse(txtBonificacionRedondeo.Text) + decimal.Parse(txtBonificacionIVA.Text);
            return sumaTotal;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNoContrato.Text))
                {
                    MessageBox.Show("Seleccione una cuenta para hacer un descuento", "Formulario Bonificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(txtSaldo.Text) || decimal.Parse(txtSaldo.Text) < 0)
                {
                    if (MessageBox.Show("¿Desesas continuar sin realizar ninguna bonificación?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                    //if (string.IsNullOrEmpty(txtMotivo.Text) || cmbEmpleado.SelectedIndex == 0 || string.IsNullOrEmpty(txtJustificacion.Text))
                    //{
                    //    MessageBox.Show("Los campos Motivo, Empleado, Puesto y Jutificacion son campos obligatorios", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    if (Bandera == 0)
                    {
                        BonificacionAPagar = AsignarTablaAPagar();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        /*
                        Bonificaciones obj = AsignarGUItoObject();
                        int aux = obj.Bonificaciones_Insert();
                        if (aux > 0)
                        {
                            MessageBox.Show("Bonificación Exitosa", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                            //FrmPagos.Bonificacion = decimal.Parse(txtBonificacionTotal.Text);
                            if (Bandera == 0)
                            {
                                BonificacionAPagar = AsignarTablaAPagar();
                            }
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show("Error al ingresar la Bonificación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnGuardar_Click - " + ex.Message, "Formulario frmModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Limpiar()
        {
            txtNoContrato.ResetText();
            txtNombre.ResetText();
            txtTarifa.ResetText();
            txtDireccion.ResetText();
            txtFechaInicio.ResetText();
            txtFechaFin.ResetText();

            txtAguaActual.Text = "0.00";
            txtAlcantarilladoActual.Text = "0.00";
            txtSaneamientoActual.Text = "0.00";
            txtRezagosActual.Text = "0.00";
            txtRecargosActual.Text = "0.00";
            txtMultasActual.Text = "0.00";
            txtGastosActual.Text = "0.00";
            txtRedondeoActual.Text = "0.00";
            txtIVAActual.Text = "0.00";
            txtVariosxCobrarActual.Text = "0.00";
            txtTotalActual.Text = "0.00";

            txtPorcentajeAgua.Text = "0.00";
            txtBonificacionAgua.Text = "0.00";
            txtBonificacionAlcantarillado.Text = "0.00";
            txtBonificacionSaneamiento.Text = "0.00";
            txtPorcentajeRezagos.Text = "0.00";
            txtBonificacionRezagos.Text = "0.00";
            txtPorcentajeRecargos.Text = "0.00";
            txtBonificacionRecargos.Text = "0.00";
            txtPorcentajeMultas.Text = "0.00";
            txtBonificacionMultas.Text = "0.00";
            txtGastosActual.Text = "0.00";
            txtBonificacionGastos.Text = "0.00";
            txtBonificacionIVA.Text = "0.00";
            txtBonificacionTotal.Text = "0.00";
            txtBonificacionRedondeo.Text = "0.00";

            txtAguaAPagar.Text = "0.00";
            txtAlcantarilladoAPagar.Text = "0.00";
            txtSaneamientoAPagar.Text = "0.00";
            txtRezagosAPagar.Text = "0.00";
            txtRecargosAPagar.Text = "0.00";
            txtMultasAPagar.Text = "0.00";
            txtGastosEjecucionAPagar.Text = "0.00";
            txtRedondeoAPagar.Text = "0.00";
            txtIVAAPagar.Text = "0.00";
            txtTotalAPagar.Text = "0.00";
            txtVariosxCobrarAPagar.Text = "0.00";
            txtSaldo.Text = "0.00";

        }
        public DataTable AsignarTablaAPagar()
        {
            DataTable aux = new DataTable();
            aux.Columns.Add("AguaAPagar", typeof(decimal));
            aux.Columns.Add("AlcantarilladoAPagar", typeof(decimal));
            aux.Columns.Add("SaneamientoAPagar", typeof(decimal));
            aux.Columns.Add("RezagoAPagar", typeof(decimal));
            aux.Columns.Add("RecargoAPagar", typeof(decimal));
            aux.Columns.Add("MultasAPagar", typeof(decimal));
            aux.Columns.Add("GastosAPagar", typeof(decimal));
            aux.Columns.Add("IVAAPagar", typeof(decimal));

            DataRow newRow = aux.NewRow();
            newRow["AguaAPagar"] = Convert.ToDecimal(txtAguaAPagar.Text);
            newRow["AlcantarilladoAPagar"] = Convert.ToDecimal(txtAlcantarilladoAPagar.Text);
            newRow["SaneamientoAPagar"] = Convert.ToDecimal(txtSaneamientoAPagar.Text);
            newRow["RezagoAPagar"] = Convert.ToDecimal(txtRezagosAPagar.Text);
            newRow["RecargoAPagar"] = Convert.ToDecimal(txtRecargosAPagar.Text);
            newRow["MultasAPagar"] = Convert.ToDecimal(txtMultasAPagar.Text);
            newRow["GastosAPagar"] = Convert.ToDecimal(txtGastosEjecucionAPagar.Text);
            newRow["IVAAPagar"] = Convert.ToDecimal(txtIVAAPagar.Text);

            aux.Rows.InsertAt(newRow, 0);
            return aux;
        }
        /*public Bonificaciones AsignarGUItoObject()
        {
            Bonificaciones obj = new Bonificaciones();
            try
            {
                obj.Cuenta = Convert.ToInt32(txtNoContrato.Text);
                obj.TotalAgua = Convert.ToDecimal(txtAguaActual.Text);
                obj.PorAgua = Convert.ToDecimal(txtPorcentajeAgua.Text);
                obj.BonAgua = Convert.ToDecimal(txtBonificacionAgua.Text);
                obj.AguaAP = Convert.ToDecimal(txtAguaAPagar.Text);
                obj.TotalAlcantarillado = Convert.ToDecimal(txtAlcantarilladoActual.Text);
                obj.BonAlcantarillado = Convert.ToDecimal(txtBonificacionAlcantarillado.Text);
                obj.AlcantarilladoAP = Convert.ToDecimal(txtAlcantarilladoAPagar.Text);
                obj.TotalSaneamiento = Convert.ToDecimal(txtSaneamientoActual.Text);
                obj.BonSaneamiento = Convert.ToDecimal(txtBonificacionSaneamiento.Text);
                obj.SaneamientoAP = Convert.ToDecimal(txtSaneamientoAPagar.Text);
                obj.TotalRezagos = Convert.ToDecimal(txtRezagosActual.Text);
                obj.PorRezagos = Convert.ToDecimal(txtPorcentajeRezagos.Text);
                obj.BonRezagos = Convert.ToDecimal(txtBonificacionRezagos.Text);
                obj.RezagosAP = Convert.ToDecimal(txtRezagosAPagar.Text);
                obj.TotalRecargo = Convert.ToDecimal(txtRecargosActual.Text);
                obj.PorRecargo = Convert.ToDecimal(txtPorcentajeRecargos.Text);
                obj.BonRecargo = Convert.ToDecimal(txtBonificacionRecargos.Text);
                obj.RecargoAP = Convert.ToDecimal(txtRecargosAPagar.Text);
                obj.TotalMulta = Convert.ToDecimal(txtMultasActual.Text);
                obj.PorMulta = Convert.ToDecimal(txtPorcentajeMultas.Text);
                obj.BonMulta = Convert.ToDecimal(txtBonificacionMultas.Text);
                obj.MultaAP = Convert.ToDecimal(txtMultasAPagar.Text);
                obj.TotalGastos = Convert.ToDecimal(txtGastosActual.Text);
                obj.PorGastos = Convert.ToDecimal(txtPorcentajeGastosEjecucion.Text);
                obj.BonGastos = Convert.ToDecimal(txtBonificacionGastos.Text);
                obj.GastosAP = Convert.ToDecimal(txtGastosEjecucionAPagar.Text);
                obj.BonIVA = Convert.ToDecimal(txtBonificacionIVA.Text);
                obj.IVAAPagar = Convert.ToDecimal(txtIVAAPagar.Text);
                obj.IVATotal = Convert.ToDecimal(txtIVAActual.Text);
                obj.TotalBoni = Convert.ToDecimal(txtBonificacionTotal.Text);
                obj.TotalAP = Convert.ToDecimal(txtTotalAPagar.Text);
                obj.TotalAct = Convert.ToDecimal(txtTotalActual.Text);
                obj.Motivo = Empleado.Actual.Nombre;
                obj.IdEmpleado = Empleado.Actual.Id;
                obj.Justificacion = txtJustificacion.Text;
                obj.Observacion = txtObservacion.Text;
                obj.Fecha = DateTime.Now;
                obj.Periodo = Convert.ToDateTime(txtFechaInicio.Text).ToString("MMM") +
                    Convert.ToDateTime(txtFechaInicio.Text).ToString("yy") + "-" +
                    Convert.ToDateTime(txtFechaFin.Text).ToString("MMM") +
                    Convert.ToDateTime(txtFechaFin.Text).ToString("yy");

                obj.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                obj.FechaFin = Convert.ToDateTime(txtFechaFin.Text);
                obj.MesesQueSePagan = this.MesesQueSePagan;
            }
            catch (Exception ex)
            {

                MessageBox.Show("AsignarGUItoObject - " + ex, "Formulario frmModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return obj;
        }*/
        private void txtPorRezagos_Validated(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPorcentajeRezagos.Text) || txtPorcentajeRezagos.Text.Equals("0.00") || txtPorcentajeRezagos.Text.Equals("0"))
                {
                    txtPorcentajeRezagos.Text = "0.00";
                    txtBonificacionRezagos.Text = "0.00";
                    txtRezagosAPagar.Text = (Convert.ToDecimal(txtRezagosActual.Text) -
                                        Convert.ToDecimal(txtBonificacionRezagos.Text)).ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
                else
                {


                    //if (bandera == 0)
                    //{
                    //    AguaRez = (decimal.Parse(DatosPago.Rows[0]["AguaRezago"].ToString()) * per);
                    //    AlcantarilladoRez = (decimal.Parse(DatosPago.Rows[0]["AlcantarilladoRezago"].ToString()) * per);
                    //}
                    //else
                    //{
                    //    AguaRez = (AguaRezago * per);
                    //    AlcantarilladoRez = (AlcantarilladoRezago * per);

                    //}
                    decimal per = decimal.Parse(txtPorcentajeRezagos.Text) / 100m;
                    txtBonificacionRezagos.Text = (decimal.Parse(txtRezagosActual.Text) * per).ToString("N2");
                    if (Bandera == 0)
                    {
                        if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionRezagos.Text) + Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + Convert.ToDecimal(txtBonificacionAgua.Text));
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {

                            decimal RezagoAlcantarillado = Convert.ToDecimal(txtBonificacionRezagos.Text) * (Porcentajes[0].Alcantarillado / 100);
                            txtBonificacionIVA.Text = ((RezagoAlcantarillado + decimal.Parse(txtBonificacionSaneamiento.Text) + decimal.Parse(txtBonificacionAlcantarillado.Text)) * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                    }
                    else
                    {
                        if (!Domestico)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionRezagos.Text) + decimal.Parse(txtBonificacionAgua.Text) + decimal.Parse(txtBonificacionSaneamiento.Text) + decimal.Parse(txtBonificacionAlcantarillado.Text));
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            decimal RezagoAlcantarillado = Convert.ToDecimal(txtBonificacionRezagos.Text) * (Porcentajes[0].Alcantarillado / 100);
                            sumaParaIVA = (RezagoAlcantarillado + decimal.Parse(txtBonificacionSaneamiento.Text) + decimal.Parse(txtBonificacionAlcantarillado.Text));
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }

                    }
                    txtRezagosAPagar.Text = (Convert.ToDecimal(txtRezagosActual.Text) - Convert.ToDecimal(txtBonificacionRezagos.Text)).ToString("N2");
                    if (Bandera == 0)
                    {
                        if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                        {
                            IVARezago = (((decimal.Parse(txtAguaAPagar.Text) + decimal.Parse(txtAlcantarilladoAPagar.Text) + Convert.ToDecimal(txtRezagosAPagar.Text)) * (Porcentajes[0].Alcantarillado)));
                            txtIVAAPagar.Text = IVARezago.ToString("N2");
                        }
                        else
                        {
                            decimal RezagoAlcantarillado = Convert.ToDecimal(txtRezagosAPagar.Text) * (Porcentajes[0].Alcantarillado / 100);
                            IVARezago = (((RezagoAlcantarillado + decimal.Parse(txtAlcantarilladoAPagar.Text)) * (Porcentajes[0].IVA / 100)));
                            txtIVAAPagar.Text = IVARezago.ToString("N2");
                        }
                    }
                    else
                    {
                        if (!Domestico)
                        {
                            IVARezago = (((decimal.Parse(txtAguaAPagar.Text) + decimal.Parse(txtAlcantarilladoAPagar.Text) + Convert.ToDecimal(txtRezagosAPagar.Text)) * (Porcentajes[0].IVA / 100)));
                            txtIVAAPagar.Text = IVARezago.ToString("N2");
                        }
                        else
                        {
                            decimal RezagoAlcantarillado = Convert.ToDecimal(txtRezagosAPagar.Text) * (Porcentajes[0].Alcantarillado / 100);
                            IVARezago = (((RezagoAlcantarillado + decimal.Parse(txtAlcantarilladoAPagar.Text)) * (Porcentajes[0].IVA / 100)));
                            txtIVAAPagar.Text = IVARezago.ToString("N2");
                        }
                    }
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("txtPorRezagos_Validated -" + ex.Message, "Formulario ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBonRezagos_Validated(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBonificacionRezagos.Text) || txtBonificacionRezagos.Text.Equals("0.00") || txtBonificacionRezagos.Text.Equals("0"))
                {
                    txtBonificacionRezagos.Text = "0.00";
                    txtPorcentajeRezagos.Text = "0.00";
                    txtRezagosAPagar.Text = (Convert.ToDecimal(txtRezagosActual.Text) -
                                          Convert.ToDecimal(txtBonificacionRezagos.Text)).ToString("N2");
                    ObtenerDIF();
                    txtTotalAPagar.Text = (decimal.Parse(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
                else
                {
                    decimal PorcentajeRezagosActual = 100 / Convert.ToDecimal(txtRezagosActual.Text); //Esto se utiliza cuando se conoce el dinero pero no el porcentaje*/
                    txtPorcentajeRezagos.Text = (Convert.ToDecimal(txtBonificacionRezagos.Text) * PorcentajeRezagosActual).ToString("N2");
                    if (Bandera == 0)
                    {
                        if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionRezagos.Text) + Convert.ToDecimal(txtBonificacionSaneamiento.Text) + Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + Convert.ToDecimal(txtBonificacionAgua.Text) + Convert.ToDecimal(txtBonificacionRezagos));
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            var RezagoAlcantarillado = Convert.ToDecimal(txtBonificacionRezagos.Text) * (Porcentajes[0].Alcantarillado / 100);
                            sumaParaIVA = (RezagoAlcantarillado + Convert.ToDecimal(txtBonificacionSaneamiento.Text) + Convert.ToDecimal(txtBonificacionAlcantarillado.Text));
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                    }
                    else
                    {
                        if (!Domestico)
                        {
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionSaneamiento.Text) + Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + Convert.ToDecimal(txtBonificacionAgua.Text) + Convert.ToDecimal(txtBonificacionRezagos.Text));
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            decimal RezagoAlcantarillado = Convert.ToDecimal(txtBonificacionRezagos.Text) * (Porcentajes[0].Alcantarillado / 100);
                            sumaParaIVA = (Convert.ToDecimal(txtBonificacionSaneamiento.Text) + Convert.ToDecimal(txtBonificacionAlcantarillado.Text) + RezagoAlcantarillado);
                            txtBonificacionIVA.Text = (sumaParaIVA * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                    }
                    if (Bandera == 0)
                    {
                        txtRezagosAPagar.Text = (Convert.ToDecimal(txtRezagosActual.Text) - Convert.ToDecimal(txtBonificacionRezagos.Text)).ToString("N2");
                        if (int.Parse(DatosPago.Rows[0]["isDomestica"].ToString()) == 0)
                        {
                            IVARezago = (((Convert.ToDecimal(txtAguaAPagar.Text) + Convert.ToDecimal(txtAlcantarilladoAPagar.Text) + Convert.ToDecimal(txtRezagosAPagar.Text))));
                            txtIVAAPagar.Text = (IVARezago * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            decimal RezagoAlcantarillado = Convert.ToDecimal(txtRezagosAPagar.Text) * (Porcentajes[0].Alcantarillado / 100);
                            IVARezago = (((RezagoAlcantarillado + Convert.ToDecimal(txtAlcantarilladoAPagar.Text))));
                            txtIVAAPagar.Text = (IVARezago * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                    }
                    else
                    {

                        txtRezagosAPagar.Text = (Convert.ToDecimal(txtRezagosActual.Text) - Convert.ToDecimal(txtBonificacionRezagos.Text)).ToString("N2");
                        if (!Domestico)
                        {
                            IVARezago = (((Convert.ToDecimal(txtAguaAPagar.Text) + Convert.ToDecimal(txtAlcantarilladoAPagar.Text) + Convert.ToDecimal(txtRezagosAPagar.Text))));
                            txtIVAAPagar.Text = (IVARezago * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                        else
                        {
                            decimal RezagoAlcantarillado = Convert.ToDecimal(txtRezagosAPagar.Text) * (Convert.ToDecimal(Porcentajes[0].Alcantarillado / 100));
                            IVARezago = (((RezagoAlcantarillado + Convert.ToDecimal(txtAlcantarilladoAPagar.Text))));
                            txtIVAAPagar.Text = (IVARezago * (Porcentajes[0].IVA / 100)).ToString("N2");
                        }
                    }
                    ObtenerDIF();
                    txtTotalAPagar.Text = (Convert.ToDecimal(txtRedondeoAPagar.Text) + SumaAPagar()).ToString("N2");
                    ObtenerRedondeoBonificacion();
                    txtBonificacionTotal.Text = SumaCamposBonificar().ToString("N2");
                    txtSaldo.Text = txtTotalAPagar.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtBonRezagos_Validated " + ex.Message, "Formulario frmModificacionyAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public decimal SumaAPagar()
        {
            decimal aux = (Convert.ToDecimal(txtAguaAPagar.Text) + Convert.ToDecimal(txtAlcantarilladoAPagar.Text) +
                           Convert.ToDecimal(txtSaneamientoAPagar.Text) + Convert.ToDecimal(txtRezagosAPagar.Text) +
                           Convert.ToDecimal(txtRecargosAPagar.Text) + Convert.ToDecimal(txtMultasAPagar.Text) +
                           Convert.ToDecimal(txtGastosEjecucionAPagar.Text) +
                           Convert.ToDecimal(txtIVAAPagar.Text)) + Convert.ToDecimal(txtVariosxCobrarAPagar.Text);
            return aux;
        }

        private void frmModificacionyAjuste_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Bandera == 1) FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (Bandera == 1) FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
        }
    }
}

