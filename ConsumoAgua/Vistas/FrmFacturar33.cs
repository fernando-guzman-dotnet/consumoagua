using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Clases;
using CrystalDecisions.Shared;
using Profact.TimbraCFDI;
using SAPAFacturacionCFDI33;
using SAPA.Clases;
using SAPA.Clases.Facturacion;
using SAPA.Clases.CatalogosSAT;
using SAPA.Reportes.Facturacion;
using System.Net.Mail;
using System.Net.Mime;

namespace SAPA.Vistas
{
    public partial class FrmFacturar33 : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

         public FrmFacturar33()
        {
            InitializeComponent();

            organismo = new Organismo(); // anteriormente, "sucursal"
            cliente = new Usuario();

            //u = new Clases.Usuarios();
            //venta = new Clases.Ventas(); // por definir

            factura_timbrada = new Facturas();
            factura_cuenta = new FacturasCuentas();
            abono = new FacturasAbonos();
            emisor = new Organismo();


            //p_sat = new Clases.Productos_ClaveSAT();
            //empresa = new Clases.Empresas();
            //lista_ventas = new List<Clases.Venta_Detalles>();
            //u.Id = IdUsuario;
            ////imp = new SAPAFacturacion.Impuestos();

            emisor.Id = 1;
            _tblEmisor = emisor.EmisoresSelectById();

            _tblClavesProdServ = Claves_Prod_Serv.ClavesProdServSelect();
            _tblClavesUnidad = Unidades.UnidadesSelect();
            _tblFormasPago = Formas_Pago.FormasPagoSATSelect();
            _tblMetodosPago = Metodos_Pago.MetodosPagoSATSelect();
            _tblMonedas = Monedas_SAT.MonedasSATSelect();
            _tblRegimenFiscal = Regimen_Fiscal.RegimeFiscalSelect();
            _tblUsoCFDI = Usos_CFDI.UsosCFDISelect();
            // _tblClavesSAT = p_sat.ProductosClavesSATSelect();

            //catalogo SAT
            regimen_fiscal = new Regimen_Fiscal();
            metodoPago_SAT = new Metodos_Pago();
            formaPago_SAT = new Formas_Pago();
            clave_unidad = new Unidades();
            clave_ProdServ = new Claves_Prod_Serv();
            cfdi = new Usos_CFDI();
            moneda = new Monedas_SAT();

            //Variables para facturar
            Pa = new Pagos();
            emisor_cfdi33 = new Emisores();
            receptor_cfdi33 = new Receptores();
            lista_conceptos_cfdi33 = new List<Conceptos>();
            datosfactura = new DatosFactura();
            f = new Facturacion();
            impuestos_cfdi33 = new Impuestos();

            //ambiente de facturacion
            if (Convert.ToInt32(factura_timbrada.SelectAmbienteFacturacion().Rows[0]["AMBIENTE"].ToString()) == 1)
                ban_ambiente = true;
            else
                ban_ambiente = false;

            ////cliente predeterminado "Publico en general"
            //txtCliente.Text = "Publico en General";
            //c.Nombre = txtCliente.Text;
            //c.Id = int.Parse(c.SelectClientesPorNombre(1).Rows[0]["ID"].ToString());

            txtTotal.Enabled = false;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            txtSubTotal.Enabled = false;
            txtCliente.Enabled = false;

            //cmb clientes
            cmbClientes.DataSource = Usuario.Select();
            cmbClientes.ValueMember = "Id";
            cmbClientes.DisplayMember = "Nombre";

            //cmb organismos
            cmbSucursales.DataSource = Organismo.Select();
            cmbSucursales.ValueMember = "Id";
            cmbSucursales.DisplayMember = "Nombre";

            //cmb formas de pago SAT
            cmbFormasPago.DataSource = _tblFormasPago;
            cmbFormasPago.ValueMember = "ID";
            cmbFormasPago.DisplayMember = "DESCRIPCION";

            //cmb metodos de pago SAT
            cmbTiposPago.DataSource = _tblMetodosPago;
            cmbTiposPago.ValueMember = "ID";
            cmbTiposPago.DisplayMember = "DESCRIPCION";

            //cmb usos cfdi
            cmbCFDI.DataSource = _tblUsoCFDI;
            cmbCFDI.ValueMember = "CLAVE_SAT";
            cmbCFDI.DisplayMember = "DESCRIPCION";

            //DefinirTabla();


            DateTime fechaInicio = dtpFechaInicio.Value.Date + new TimeSpan(0, 0, 0);
            DateTime fechaFin = dtpFechaFin.Value.Date + new TimeSpan(23, 59, 59);

            LlenarTablaDeProductosFacturables(1, fechaInicio, fechaFin);

            txtTimbresUsados.Enabled = false;
            txtTimbresDisponibles.Enabled = false;
            txtTimbresDisponibles.TextAlign = HorizontalAlignment.Right;
            txtTimbresUsados.TextAlign = HorizontalAlignment.Right;
            ObtenerTimbres("AAA010101AAA");

        }

        private Organismo organismo { get; set; }

        //Clases.Clientes c { get; set; }
        //Clases.FormasPago fp { get; set; }
        //Clases.TiposPago tp { get; set; }
        //Clases.Venta_Detalles vd { get; set; }

        // Clases.Ventas venta { get; set; }

        Usuario cliente { get; set; }
        Organismo emisor { get; set; }

        Facturas factura_timbrada { get; set; }
        FacturasCuentas factura_cuenta { get; set; }
        FacturasAbonos abono { get; set; }

        // Plasticos.Clases.Productos_ClaveSAT p_sat { get; set; }

        //Clases.Usuarios u { get; set; }
        //Clases.Empresas empresa { get; set; }

        string productos_sin_clavesat { get; set; }
        string productos_sin_clavesat_unidad { get; set; }
        string Ruta { get; set; }
        int productos_sin_clave { get; set; }
        bool ban_ambiente { get; set; }
        bool ban_clave_sat_prod_serv { get; set; }

        bool ban_clave_sat_unidad { get; set; }
        //List<Clases.Venta_Detalles> lista_ventas { get; set; }

        //tablas para reporte
        DataTable Datos_Factura { get; set; }
        DataTable datos_Emisores { get; set; }
        DataTable datos_Receptores { get; set; }
        DataTable DatosCertificado { get; set; }
        DataTable Conceptosfactura { get; set; }

        //catalogos del sat
        Regimen_Fiscal regimen_fiscal { get; set; }
        Formas_Pago formaPago_SAT { get; set; }
        Metodos_Pago metodoPago_SAT { get; set; }
        Unidades clave_unidad { get; set; }
        Claves_Prod_Serv clave_ProdServ { get; set; }
        Usos_CFDI cfdi { get; set; }
        Monedas_SAT moneda { get; set; }

        //Variables para facturacion
        Pagos Pa { get; set; }
        Emisores emisor_cfdi33 { get; set; }
        Receptores receptor_cfdi33 { get; set; }
        DatosFactura datosfactura { get; set; }
        Facturacion f { get; set; }
        Impuestos impuestos_cfdi33 { get; set; }
        List<Conceptos> lista_conceptos_cfdi33 { get; set; }

        ResultadoTimbre rt { get; set; }
        ResultadoConsultaTimbres rct { get; set; }

        #region banderas

        int cont_enviados { get; set; }
        int cont_error { get; set; }
        String msg_enviados { get; set; }
        String msg_error { get; set; }
        String msg_clave_prod_serv { get; set; }

        String msg_clave_unidad { get; set; }

        //String Ruta { get; set; }
        //Boolean ban_ambiente { get; set; }
        Boolean bandera_tipo_comprobante { get; set; }

        //Boolean ban_clave_sat_unidad { get; set; }
        Boolean ban_tipo_cambio { get; set; }

        //Boolean ban_clave_sat_prod_serv { get; set; }
        int ban_recibo { get; set; }

        #endregion

        DataTable _tblEmisor { get; set; }

        DataTable _tblClavesProdServ { get; set; }

        private DataTable fastFilterClavesProdServ(string clave)
        {
            DataTable tbl = _tblClavesProdServ.Clone();
            IEnumerable<DataRow> imqRows = from DataRow rdvgrw in _tblClavesProdServ.Rows
                where
                (
                    rdvgrw["Clave"].ToString() == clave
                )
                select rdvgrw;
            foreach (DataRow d in imqRows)
            {
                tbl.Rows.Add(d.ItemArray);
            }

            return tbl;
        }

        DataTable _tblClavesUnidad { get; set; }

        private DataTable fastFilterClavesUnidades(string clave)
        {
            DataTable tbl = _tblClavesUnidad.Clone();
            IEnumerable<DataRow> imqRows = from DataRow rdvgrw in _tblClavesUnidad.Rows
                where
                (
                    rdvgrw["Clave_SAT"].ToString() == clave
                )
                select rdvgrw;
            foreach (DataRow d in imqRows)
            {
                tbl.Rows.Add(d.ItemArray);
            }

            return tbl;
        }

        DataTable _tblFormasPago { get; set; }

        private DataTable fastFilterFormaPago(int id)
        {
            DataTable tbl = _tblFormasPago.Clone();
            IEnumerable<DataRow> imqRows = from DataRow rdvgrw in _tblFormasPago.Rows
                where
                (
                    Convert.ToInt32(rdvgrw["Id"].ToString()) == id
                )
                select rdvgrw;
            foreach (DataRow d in imqRows)
            {
                tbl.Rows.Add(d.ItemArray);
            }

            return tbl;
        }

        DataTable _tblMetodosPago { get; set; }

        private DataTable fastFilterMetodoPago(int id)
        {
            DataTable tbl = _tblMetodosPago.Clone();
            IEnumerable<DataRow> imqRows = from DataRow rdvgrw in _tblMetodosPago.Rows
                where
                (
                    Convert.ToInt32(rdvgrw["Id"].ToString()) == id
                )
                select rdvgrw;
            foreach (DataRow d in imqRows)
            {
                tbl.Rows.Add(d.ItemArray);
            }

            return tbl;
        }

        DataTable _tblMonedas { get; set; }

        private DataTable fastFilterMonedas(string clave)
        {
            DataTable tbl = _tblMonedas.Clone();
            IEnumerable<DataRow> imqRows = from DataRow rdvgrw in _tblMonedas.Rows
                where
                (
                    rdvgrw["Clave_sat"].ToString() == clave
                )
                select rdvgrw;
            foreach (DataRow d in imqRows)
            {
                tbl.Rows.Add(d.ItemArray);
            }

            return tbl;
        }

        DataTable _tblRegimenFiscal { get; set; }

        private DataTable fastFilterRegimenFiscal(string clave)
        {
            DataTable tbl = _tblRegimenFiscal.Clone();
            IEnumerable<DataRow> imqRows = from DataRow rdvgrw in _tblRegimenFiscal.Rows
                where
                (
                    rdvgrw["Clave_SAT"].ToString() == clave
                )
                select rdvgrw;
            foreach (DataRow d in imqRows)
            {
                tbl.Rows.Add(d.ItemArray);
            }

            return tbl;
        }

        DataTable _tblUsoCFDI { get; set; }

        private DataTable fastFilterUsoCFDI(string clave)
        {
            DataTable tbl = _tblUsoCFDI.Clone();
            IEnumerable<DataRow> imqRows = from DataRow rdvgrw in _tblUsoCFDI.Rows
                where
                (
                    rdvgrw["Clave_SAT"].ToString() == clave
                )
                select rdvgrw;
            foreach (DataRow d in imqRows)
            {
                tbl.Rows.Add(d.ItemArray);
            }

            return tbl;
        }

        private DataTable _tblFacturas { get; set; }

        private DataTable FastFilterFacturas(string folios)
        {
            int folio = 0;
            var foliosList = folios.Split(',')
                .Where(m => int.TryParse(m, out folio))
                .Select(m => int.Parse(m))
                .Where(m => m != 0)
                .ToList();


            if (!foliosList.Any()) return _tblFacturas;

            var filteredRows = _tblFacturas.AsEnumerable().Where(r => foliosList.Contains(r.Field<int>("Folio")));

            if (!filteredRows.Any()) return _tblFacturas;

            DataTable tbl = filteredRows.CopyToDataTable();
            return tbl;

        }


        //Enviar factura a correo del emisor
        private bool EnviarCorreoEmisor(string ruta)  
        {
            List<string> lstArchivos = new List<string>();

            //rpt.ExportToDisk(ExportFormatType.PortableDocFormat, rutaReporte);
            lstArchivos.Add(ruta + ".pdf");
            //lstArchivos.Add(Ruta + rt.FolioUUID + ".jpg");
            lstArchivos.Add(ruta + ".xml");

            Mail oMail = new Mail("servienvases.facturacion@gmail.com",
                                                                    emisor_cfdi33.Correo,
                                                                    "Archivo de Factura CFDI " + DateTime.Now.ToString(),
                                                                    "Factura " + Datos_Factura.Rows[0][1].ToString(),
                                                                    lstArchivos);

            if (oMail.enviaMail())
            {
                MessageBox.Show("Se envió la factura al correo del emisor (" + emisor_cfdi33.Correo + ")", "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return true;
            }
            else
            {
                MessageBox.Show("No se pudo enviar la factura al correo del emisor (" + emisor_cfdi33.Correo + "):\n" + oMail.error, "Error de Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //SAPAFacturacionCFDI33.Facturacion f { get; set; }
        private void ObtenerTimbres(string RFC)
        {
            Facturacion facturacion = new Facturacion();
            ResultadoConsultaTimbres timbrado;
            timbrado = facturacion.ObtenerTimbres33(ban_ambiente, RFC);
            if (ban_ambiente == true)
            {
                txtTimbresDisponibles.Text = timbrado.Disponibles.ToString();
                txtTimbresUsados.Text = timbrado.Consumidos.ToString();
            }
            else
            {
                txtTimbresUsados.Text = timbrado.Consumidos.ToString();//10.ToString();
                txtTimbresDisponibles.Text = timbrado.Disponibles.ToString();//10.ToString();
            }
            #region comentarios
            //if (ban_ambiente==true)
            //{
            //    txtTimbresUsados.Text = factura_cfdi.ObtenerTimbres33(ban_ambiente, rfc_emisor).Consumidos.ToString();
            //    txtTimbresDisponibles.Text = factura_cfdi.ObtenerTimbres33(ban_ambiente, rfc_emisor).Disponibles.ToString();
            //}
            //else
            //{
            //    txtTimbresUsados.Text = 10.ToString();
            //    txtTimbresDisponibles.Text = 10.ToString();
            //}
            #endregion
        }

        private DataTable tablaPagos(Pagos pago)  
        {
            DataTable complemento_PA = new DataTable();
            complemento_PA.Columns.Add("Id", Type.GetType("System.Int32"));
            complemento_PA.Columns.Add("IdFactura", Type.GetType("System.Int32"));
            complemento_PA.Columns.Add("Monto", Type.GetType("System.Decimal"));
            complemento_PA.Columns.Add("Moneda", Type.GetType("System.String"));
            complemento_PA.Columns.Add("FormaPago", Type.GetType("System.String"));
            complemento_PA.Columns.Add("FechaPago", Type.GetType("System.DateTime"));
            complemento_PA.Columns.Add("CtaOrdenante", Type.GetType("System.String"));
            complemento_PA.Columns.Add("CtaOrdenanteRFC", Type.GetType("System.String"));
            complemento_PA.Columns.Add("CtaBeneficiaria", Type.GetType("System.String"));
            complemento_PA.Columns.Add("CtaBeneficiariaRFC", Type.GetType("System.String"));
            complemento_PA.Columns.Add("NoOperacion", Type.GetType("System.String"));
            complemento_PA.Columns.Add("Banco", Type.GetType("System.String"));
            //complemento_PA.TableName = "RptComplemento_PA";
            //DataRow r_PA = complemento_PA.NewRow();
            //r_PA[0] = 1;
            //r_PA[1] = 1;
            //r_PA[2] = pago.pagos[0].Monto;
            //r_PA[3] = pago.pagos[0].MonedaP;
            //r_PA[4] = pago.pagos[0].FormaDePagoP;
            //r_PA[5] = pago.pagos[0].FechaPago;
            //complemento_PA.Rows.Add(r_PA);

            return complemento_PA;
        }

        private DataTable tablaPagosDetalles(Pagos pago, string FolioUUID)  
        {
            DataTable DatosComplementoPA = new DataTable();
            DatosComplementoPA.TableName = "RptComplemento_PA_Detalles";
            DatosComplementoPA.Columns.Add("Id", Type.GetType("System.Int32"));
            DatosComplementoPA.Columns.Add("IdComplemento", Type.GetType("System.Int32"));
            DatosComplementoPA.Columns.Add("Folio", Type.GetType("System.String"));
            DatosComplementoPA.Columns.Add("Imp_Saldo_Insoluto", Type.GetType("System.Decimal"));
            DatosComplementoPA.Columns.Add("Imp_Saldo_Anterior", Type.GetType("System.Decimal"));
            DatosComplementoPA.Columns.Add("Imp_Pagado", Type.GetType("System.Decimal"));
            DatosComplementoPA.Columns.Add("Parcialidad", Type.GetType("System.String"));
            DatosComplementoPA.Columns.Add("Metodo_Pago", Type.GetType("System.String"));
            DatosComplementoPA.Columns.Add("Moneda", Type.GetType("System.String"));
            DatosComplementoPA.Columns.Add("IdDocumento", Type.GetType("System.String"));
            DatosComplementoPA.Columns.Add("IdFactura", Type.GetType("System.Int32"));
            DatosComplementoPA.Columns.Add("FolioUUID", Type.GetType("System.String"));
            //DatosComplementoPA.TableName = "RptComplemento_PA_Detalles";

            //foreach (Profact.TimbraCFDI33.Complementos.Pagos10.PagosPagoDoctoRelacionado p in Pa.pagos[0].DoctoRelacionado)
            //{
            //    DataRow rd_PA = DatosComplementoPA.NewRow();
            //    rd_PA[0] = 1;
            //    rd_PA[1] = 1;
            //    rd_PA[2] = p.Folio;
            //    rd_PA[3] = p.ImpSaldoInsoluto;
            //    rd_PA[4] = p.ImpSaldoAnt;
            //    rd_PA[5] = p.ImpPagado;
            //    rd_PA[6] = p.NumParcialidad;
            //    rd_PA[7] = p.MetodoDePagoDR;
            //    rd_PA[8] = p.MonedaDR;
            //    rd_PA[9] = p.IdDocumento;
            //    rd_PA[10] = 1;
            //    rd_PA[11] = FolioUUID;
            //    DatosComplementoPA.Rows.Add(rd_PA);
            //}



            return DatosComplementoPA;
        }

        private string getNombreImpuesto(string clave)  
        {
            string impuesto = "";
            switch (clave)
            {
                case "001":
                    impuesto = "ISR";
                    break;
                case "002":
                    impuesto = "IVA";
                    break;
                case "003":
                    impuesto = "IEPS";
                    break;
                default:
                    impuesto = "000";
                    break;
            }
            return impuesto;
        }

        //limpiar formulario
        private void limpiar()  
        {
            txtNoRef.Text = "";
            txtIVA.Text = 0.ToString("N2");
            txtRetISR.Text = 0.ToString("N2");
            txtRetIVA.Text = 0.ToString("N2");
            txtSubTotal.Text = 0.ToString("N2");
            txtTotal.Text = 0.ToString("N2");
            cmbSucursales.Enabled = true;
        }

        #region definir datagrid
        ////definir columnas de datagrid
        //private void DefinirTabla()
        //{
        //    dgvFacturas.Columns.Clear();
        //    dgvFacturas.Rows.Clear();

        //    //0.- No. de Venta
        //    dgvFacturas.Columns.Add("No. de Venta", "No. de Venta");
        //    dgvFacturas.Columns["No. de Venta"].ReadOnly = true;
        //    //1.- Fecha
        //    dgvFacturas.Columns.Add("Fecha", "Fecha");
        //    dgvFacturas.Columns["Fecha"].ReadOnly = true;
        //    //2.- Cliente
        //    dgvFacturas.Columns.Add("Cliente", "Cliente");
        //    dgvFacturas.Columns["Cliente"].ReadOnly = true;
        //    //3.- SubTotal
        //    dgvFacturas.Columns.Add("SubTotal", "SubTotal");
        //    dgvFacturas.Columns["SubTotal"].ReadOnly = true;
        //    dgvFacturas.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    dgvFacturas.Columns["SubTotal"].DefaultCellStyle.Format = "N2";
        //    //4.- Total
        //    dgvFacturas.Columns.Add("Total", "Total");
        //    dgvFacturas.Columns["Total"].ReadOnly = true;
        //    dgvFacturas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    dgvFacturas.Columns["Total"].DefaultCellStyle.Format = "N2";
        //    //5.- Retencion_ISR
        //    dgvFacturas.Columns.Add("Retencion_ISR", "Retencion_ISR");
        //    dgvFacturas.Columns["Retencion_ISR"].ReadOnly = true;
        //    dgvFacturas.Columns["Retencion_ISR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    dgvFacturas.Columns["Retencion_ISR"].DefaultCellStyle.Format = "N2";
        //    dgvFacturas.Columns[5].Visible = false;
        //    //6.- Retencion_IVA
        //    dgvFacturas.Columns.Add("Retencion_IVA", "Retencion_IVA");
        //    dgvFacturas.Columns["Retencion_IVA"].ReadOnly = true;
        //    dgvFacturas.Columns["Retencion_IVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    dgvFacturas.Columns["Retencion_IVA"].DefaultCellStyle.Format = "N2";
        //    dgvFacturas.Columns[6].Visible = false;
        //    //7.- IEPS
        //    dgvFacturas.Columns.Add("IEPS", "IEPS");
        //    dgvFacturas.Columns["IEPS"].ReadOnly = true;
        //    dgvFacturas.Columns["IEPS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    dgvFacturas.Columns["IEPS"].DefaultCellStyle.Format = "N2";
        //    dgvFacturas.Columns[7].Visible = false;
        //    //8.- IVA 
        //    dgvFacturas.Columns.Add("IVA", "IVA");
        //    dgvFacturas.Columns["IVA"].ReadOnly = true;
        //    dgvFacturas.Columns["IVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    dgvFacturas.Columns["IVA"].DefaultCellStyle.Format = "N2";
        //    dgvFacturas.Columns[8].Visible = false;
        //    //9.- Seleccionar
        //    DataGridViewCheckBoxColumn Chk = new DataGridViewCheckBoxColumn();
        //    dgvFacturas.Columns.Add(Chk);
        //    Chk.Name = "Seleccionar";
        //    Chk.ReadOnly = false;

        //    dgvFacturas.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
        //    dgvFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
        //    dgvFacturas.DefaultCellStyle.ForeColor = Color.Black;
        //}
        #endregion


        //llenar datagrid con ventas por facturar
        private void LlenarTablaDeProductosFacturables(int IdSucursal, DateTime FechaInicio, DateTime FechaFin)  
        {
            //dgvFacturas.Rows.Clear();
            //vd.IdSucursal = IdSucursal;
            
            _tblFacturas = Facturas.SelectFacturas(FechaInicio, FechaFin, IdSucursal,txtNombre.Text);
            
            dgvFacturas.DataSource = _tblFacturas;

            dgvFacturas.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            dgvFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvFacturas.AllowUserToAddRows = false;
            
            if(dgvFacturas.Rows.Count != 0)
            {
                try { dgvFacturas.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try
                {
                    dgvFacturas.Columns["NoContrato"].DefaultCellStyle.Format = "D10";
                    dgvFacturas.Columns["Folio"].DefaultCellStyle.Format = "D5";
                    dgvFacturas.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvFacturas.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
                    dgvFacturas.Columns["Subtotal"].Visible = false;
                } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try
                {
                    dgvFacturas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvFacturas.Columns["Total"].DefaultCellStyle.Format = "N2";
                } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["ISR_Retencion"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["IVA_Retencion"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["IVA"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["IEPS"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }

                foreach (DataGridViewColumn c in dgvFacturas.Columns)
                {
                    if (c.Name.Equals("Seleccionar"))
                        c.ReadOnly = false;
                    else
                        c.ReadOnly = true;
                }
            }
            else
            {
                dgvFacturas.DataSource = null;
            }
            
        }

        #region llenado de lista de conceptos para la factura
        List<Facturas_Detalles> lista_conceptos_pago { get; set; }
        private void LlenarListaDeProductos()  
        {
            lista_conceptos_pago = new List<Facturas_Detalles>();
            foreach (DataGridViewRow r in dgvFacturas.Rows)
            {
                if(Convert.ToBoolean(r.Cells["Seleccionar"].Value.ToString()) == true)
                {
                    Facturas_Detalles detalle = new Facturas_Detalles();
                    detalle.IdProducto = Convert.ToInt32(r.Cells["Folio"].Value.ToString());
                    detalle.Imp_retencion_isr = 0.00M;
                    detalle.Imp_retencion_iva = 0.00M;
                    detalle.Imp_traslados_ieps = 0.00M;
                    detalle.Imp_traslado_iva = Convert.ToDecimal(r.Cells["IVA"].Value.ToString());
                    detalle.Codigo = "-";
                    detalle.Cantidad = 1;
                    detalle.Clave_Prod_Serv = "83101500";
                    detalle.Clave_Unidad = "A9";
                    detalle.Descripcion = "PAGO DE SERVICIO";
                    detalle.Precio_Unitario = Convert.ToDecimal(r.Cells["Subtotal"].Value.ToString());
                    detalle.Importe = Convert.ToDecimal(r.Cells["Subtotal"].Value.ToString());
                    detalle.Unidad = "Tarifa";
                    lista_conceptos_pago.Add(detalle);
                }
            }
        //    DS = new List<VistasReportes.Reportes.Tipos.DetalladoDeVenta>();

        //    string numeros_ventas = "";
        //    foreach (DataGridViewRow r in dgvFacturas.Rows)
        //    {
        //        if(Convert.ToBoolean(r.Cells["Seleccionar"].Value.ToString()) == true)
        //        {
        //            numeros_ventas +=r.Cells["No. de Venta"].Value.ToString() + ",";
        //            //int idventa = Convert.ToInt32(r.Cells["No. de Venta"].Value.ToString()); 
        //        }
        //    }

        //    //select de la venta de acuerdo a los tickets que se ingresan
        //    var entidades = new Datos.PlasticosContainer();
        //    var tmpIdVenta = numeros_ventas.Substring(0,numeros_ventas.Length-1);
        //    var token = ',';
        //    if (Regex.IsMatch(tmpIdVenta, "^([0-9]+,?)+$"))
        //    {
        //        token = ',';
        //    }
        //    else if (Regex.IsMatch(tmpIdVenta, "^([0-9]+;?)+$"))
        //    {
        //        token = ';';
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    var tickets = tmpIdVenta.Split(new[] { token }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        //    //
        //    //var v_todos = entidades.Ventas.ToList();
        //    var venta = entidades.Ventas.Where(x => tickets.Contains(x.id)).ToList();

        //    if (venta.Count == 0)
        //    {
        //        return;
        //    }

        //    var Cliente = venta.First().Cliente;

        //    var ds = venta.SelectMany(g => g.Detalles).Select(x => new Reportes.Tipos.DetalladoDeVenta()
        //    {
        //        Cantidad = x.CantidadAbsoluta,
        //        Cliente = Cliente.Nombre,
        //        Codigo = x.Producto.Clave,
        //        Descripcion = x.Producto.Nombre,
        //        Fecha = x.Venta.Fecha.ToShortDateString(),
        //        NVenta = x.Venta_id.ToString(),
        //        PrecioUnitario = x.PU / (1 + ((x.Producto.IVAPorcentaje + x.Producto.IEPS) / 100)),//x.PUSinImpuestos,
        //        Total = x.PrecioTotal / (1 + ((x.Producto.IVAPorcentaje + x.Producto.IEPS) / 100)),//x.PUSinImpuestos * x.Cantidad,//x.PrecioSinImpuestos,
        //        Unidad = x.Unidad,
        //        IEPS = (x.PrecioTotal / (1 + ((x.Producto.IVAPorcentaje + x.Producto.IEPS) / 100)) * x.Producto.IEPS) / 100,//x.PrecioSinImpuestos * (x.Producto.IEPS / 100M),
        //        IVA = (x.PrecioTotal / (1 + ((x.Producto.IVAPorcentaje + x.Producto.IEPS) / 100)) * x.Producto.IVAPorcentaje) / 100,//x.PrecioSinImpuestos * (x.Producto.IVAPorcentaje / 100M),
        //        IVAPorcentaje = x.Producto.IVAPorcentaje
        //        //x.


        //    }).ToList();

        //    DS = ds;

        //    //var IEPS = DS.Sum(g => g.IEPS);
        //    //var IVA = DS.Sum(g => g.IVA);

            
        //    //var conce = DS.Select(g => new ComprobanteConcepto()
        //    //{

        //    //    Cantidad = g.Cantidad,
        //    //    Descripcion = g.Descripcion,
        //    //    Importe = g.Total,
        //    //    NoIdentificacion = "S/N",
        //    //    Unidad = g.Unidad,
        //    //    ValorUnitario = g.PrecioUnitario.TruncateDecimal(4)

        //    //}).ToList();

        }
        #endregion 

        //validar clave sat
        private int ValidarClaveSAT_ProdServ()  
        {
            productos_sin_clave = 0;

            ////for (int i = 0; i < dgvFacturas.Rows.Count - 1; i++)
            //foreach (DataGridViewRow r in dgvFacturas.Rows)
            //{
            //    //obtener ventas seleccionadas
            //    if (r.Cells["Seleccionar"].Value.Equals(true))
            //    {
            //        Clases.Venta_Detalles ved = new Clases.Venta_Detalles();
            //        ved.IdVenta = int.Parse(r.Cells["No. de Venta"].Value.ToString());

            //        //llenar lista con los productos de las ventas seleccionadas
            //        foreach (DataRow r1 in ved.SelectVentaDetallesPorIDVenta(1).Rows)
            //        {
            //            Clases.Catalogos ca = new Clases.Catalogos();
            //            ca.Id = int.Parse(r1["IdProducto"].ToString());
            //            ca.Clave_Prod_Serv = ca.SelectCatalogoPorID(1).Rows[0]["CLAVE_PROD_SERV"].ToString();
            //            if (ca.Clave_Prod_Serv.Equals(""))
            //            {
            //                productos_sin_clave++;
            //            }
            //        }
            //    }
            //}

            return productos_sin_clave;
        }

        //validar clave sat
        private int ValidarClaveSAT_Unidad()  
        {
            productos_sin_clave = 0;

            ////for (int i = 0; i < dgvFacturas.Rows.Count - 1; i++)
            //foreach (DataGridViewRow r in dgvFacturas.Rows)
            //{
            //    //obtener ventas seleccionadas
            //    if (r.Cells["Seleccionar"].Value.Equals(true))
            //    {
            //        Clases.Venta_Detalles ved = new Clases.Venta_Detalles();
            //        ved.IdVenta = int.Parse(r.Cells["No. de Venta"].Value.ToString());

            //        //llenar lista con los productos de las ventas seleccionadas
            //        foreach (DataRow r1 in ved.SelectVentaDetallesPorIDVenta(1).Rows)
            //        {
            //            Clases.Catalogos ca = new Clases.Catalogos();
            //            ca.Id = int.Parse(r1["IdProducto"].ToString());
            //            ca.Clave_Prod_Serv = ca.SelectCatalogoPorID(1).Rows[0]["CLAVE_UNIDAD"].ToString();
            //            if (ca.Clave_Prod_Serv.Equals(""))
            //            {
            //                productos_sin_clave++;
            //            }
            //        }
            //    }
            //}
            return productos_sin_clave;
        }

        
        DataTable _tblClavesSAT { get; set; }
        private DataTable fastFilterClavesSATByIdProducto(string clave_producto, string presentacion)  
        {
            DataTable tbl = _tblClavesSAT.Clone();
            IEnumerable<DataRow> imqRows = from DataRow rdvgrw in _tblClavesSAT.Rows
                                           where
                                           (
                                             rdvgrw["Clave"].ToString().ToLower() == clave_producto.ToLower() &&
                                             rdvgrw["Unidad"].ToString().ToLower().Contains(Regex.Replace(presentacion.Split()[0], @"[^0-9a-zA-Z\ ]+", "").ToLower())
                                           )
                                           select rdvgrw;
            foreach (DataRow d in imqRows)
            {
                tbl.Rows.Add(d.ItemArray);
            }

            return tbl;
        }

        private int ValidarClavesSAT(/*List<VistasReportes.Reportes.Tipos.DetalladoDeVenta> lista*/)  
        {
            productos_sin_clavesat = "";
            int cont = 0;
            //foreach (Reportes.Tipos.DetalladoDeVenta detalle in lista)
            //{
            //    try
            //    {
            //        Clases.Productos_ClaveSAT p_sat = new Clases.Productos_ClaveSAT();
            //        //if (p_sat.SelectProductosClaveSAT_PorClaveProducto(detalle.Codigo, detalle.Unidad).Rows[0]["CLAVE_SAT"].ToString().Equals(""))
            //        if (fastFilterClavesSATByIdProducto(detalle.Codigo, detalle.Unidad).Rows[0]["CLAVE_SAT"].ToString().Equals(""))
            //        {
            //            cont++;
            //            productos_sin_clavesat = detalle.Descripcion + "\n";
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //    }

            //}
            return cont;
        }

        private int ValidarClavesSAT_Unidades(/*List<Reportes.Tipos.DetalladoDeVenta> lista*/)  
        {
            productos_sin_clavesat_unidad = "";
            int cont = 0;
            //foreach (Reportes.Tipos.DetalladoDeVenta detalle in lista)
            //{
            //    try
            //    {
            //        Clases.Productos_ClaveSAT p_sat = new Clases.Productos_ClaveSAT();
            //        //if (p_sat.SelectProductosClaveSAT_PorClaveProducto(prro.Codigo, prro.Unidad).Rows[0]["CLAVE_SAT_UNIDAD"].ToString().Equals(""))
            //        if (fastFilterClavesSATByIdProducto(detalle.Codigo, detalle.Unidad).Rows[0]["CLAVE_SAT_UNIDAD"].ToString().Equals(""))
            //        {
            //            cont++;
            //            productos_sin_clavesat_unidad = detalle.Descripcion + "\n";
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //    }

            //}
            return cont;
        }

        private bool validarFilas()  
        {
            bool ban = false;
            //for (int i = 0; i < dgvFacturas.Rows.Count - 1; i++)
            foreach (DataGridViewRow r in dgvFacturas.Rows)
            {
                if (r.Cells["Seleccionar"].Value.Equals(true))
                {
                    ban = true;
                }
            }
            return ban;
        }

        private string ObtenerTasaOCuotaIEPS(decimal prro, decimal porcentaje)
        {
            if (prro == 0)
            {
                return "0.000000";
            }
            else
            {
                return (decimal.Round((porcentaje / 100), 6)).ToString("N6");
            }
        }

        private decimal PorcentajeIEPSPorProducto(decimal subtotal, decimal ieps)
        {
            return decimal.Round(((ieps * 100) / subtotal), 2);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            facturar(true);
            DialogResult = DialogResult.OK;
        }

        private void btnBuscarVentas_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DateTime fechaInicio = dtpFechaInicio.Value.Date + new TimeSpan(0, 0, 0);
                DateTime fechaFin = dtpFechaFin.Value.Date + new TimeSpan(23, 59, 59);

                LlenarTablaDeProductosFacturables(Convert.ToInt32(cmbSucursales.SelectedValue.ToString()),
                                                  fechaInicio,
                                                  fechaFin);
                getTotales();
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show("Ocurrió un error al cargar las ventas pendientes de facturar: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSucursales_SelectedValueChanged(object sender, EventArgs e)
        {
            try { btnBuscarVentas.PerformClick(); } catch (Exception ex) { }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnBuscarVentas.PerformClick();
        }

        private void chkTodas_Click(object sender, EventArgs e)
        {
            decimal Total = 0;
            decimal SubTotal = 0;
            decimal Retencion_ISR = 0;
            decimal Retencion_IVA = 0;
            decimal IEPS = 0;
            decimal IVA = 0;
            int cont = 0;

            foreach (DataGridViewRow r in dgvFacturas.Rows)
            {
                r.Cells["Seleccionar"].Value = chkTodas.Checked;
                if (r.Cells["Seleccionar"].Value.Equals(true))
                {
                    Total += Convert.ToDecimal(r.Cells["TOTAL"].Value.ToString());
                    SubTotal += Convert.ToDecimal(r.Cells["SUBTOTAL"].Value.ToString());
                    Retencion_ISR += Convert.ToDecimal(r.Cells["ISR_Retencion"].Value.ToString());
                    Retencion_IVA += Convert.ToDecimal(r.Cells["IVA_Retencion"].Value.ToString());
                    IEPS += Convert.ToDecimal(r.Cells["IEPS"].Value.ToString());
                    IVA += Convert.ToDecimal(r.Cells["IVA"].Value.ToString());
                    cont++;
                }
            }

            txtRetISR.Text = Retencion_ISR.ToString("N2");
            txtIVA.Text = IVA.ToString("N2");
            txtRetIVA.Text = Retencion_IVA.ToString("N2");
            txtIEPS.Text = IEPS.ToString("N2");
            txtTotal.Text = Total.ToString("N2");
            txtSubTotal.Text = SubTotal.ToString("N2");
        }

        private void getTotales()
        {
            decimal Total = 0;
            decimal SubTotal = 0;
            decimal Retencion_ISR = 0;
            decimal Retencion_IVA = 0;
            decimal IEPS = 0;
            decimal IVA = 0;
            int cont = 0;

            //for (int i = 0; i < dgvFacturas.RowCount - 1; i++)
            foreach (DataGridViewRow r in dgvFacturas.Rows)
            {
                if (r.Cells["Seleccionar"].Value.Equals(true))
                {
                    Total += Convert.ToDecimal(r.Cells["TOTAL"].Value.ToString());
                    SubTotal += Convert.ToDecimal(r.Cells["SUBTOTAL"].Value.ToString());
                    Retencion_ISR += Convert.ToDecimal(r.Cells["ISR_Retencion"].Value.ToString());
                    Retencion_IVA += Convert.ToDecimal(r.Cells["IVA_Retencion"].Value.ToString());
                    IEPS += Convert.ToDecimal(r.Cells["IEPS"].Value.ToString());
                    IVA += Convert.ToDecimal(r.Cells["IVA"].Value.ToString());
                    cont++;
                }
            }

            txtRetISR.Text = Retencion_ISR.ToString("N2");
            txtIVA.Text = IVA.ToString("N2");
            txtRetIVA.Text = Retencion_IVA.ToString("N2");
            txtIEPS.Text = IEPS.ToString("N2");
            txtTotal.Text = Total.ToString("N2");
            txtSubTotal.Text = SubTotal.ToString("N2");///*(Decimal.Parse(txtTotal.Text) -*/ ((Decimal.Parse(txtTotal.Text) * 100) / 116).ToString("N2");

            if (cont > 0)
                cmbSucursales.Enabled = false;
            else
                cmbSucursales.Enabled = true;
        }

        private void dgvFacturas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            getTotales();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            facturar(false);
        }


        private void facturar(bool timbrado)
        {
            //validar que se hayan selccionado ventas
            if (validarFilas() == false)
            {
                MessageBox.Show("Debes seleccionar al menos una venta para generar una vista previa de la factura.", "Factura sin datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //validar que los productos tengan asignada una clave del sat para producto / servicio
            else if (ValidarClaveSAT_ProdServ() != 0)
            {
                MessageBox.Show("Para facturar CFDI 3.3 debes haber asignado una clave de Producto/Servicio del SAT previamente a los productos que deseas facturar.",
                    "Productos sin clave SAT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //validar que los productos tengan asignada una clave del sat para unidad
            else if (ValidarClaveSAT_Unidad() != 0)
            {
                MessageBox.Show("Para facturar CFDI 3.3 debes haber asignado una clave de Unidad del SAT previamente a los productos que deseas facturar.",
                    "Productos sin clave SAT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    /*----------------------------------------------------------DATOS DEL EMISOR--------------------------------------------------------------*/
                    //DATOS DEL EMISOR
                    DataTable emisor_id = emisor.EmisoresSelectById();

                    //emisor_cfdi33.Nombre = emisor_id.Rows[0]["RAZONSOCIAL"].ToString();
                    //emisor_cfdi33.RFC = emisor_id.Rows[0]["RFC"].ToString();
                    //emisor_cfdi33.RazonSocial = emisor_id.Rows[0]["RAZONSOCIAL"].ToString();
                    //emisor_cfdi33.Calle = emisor_id.Rows[0]["CALLE"].ToString();
                    //emisor_cfdi33.NoExterior = emisor_id.Rows[0]["NOEXTERIOR"].ToString();
                    //emisor_cfdi33.NoInterior = emisor_id.Rows[0]["NOINTERIOR"].ToString();
                    //emisor_cfdi33.Colonia = emisor_id.Rows[0]["COLONIA"].ToString();
                    //emisor_cfdi33.Municipio = emisor_id.Rows[0]["MUNICIPIO"].ToString();
                    //emisor_cfdi33.Estado = emisor_id.Rows[0]["ESTADO"].ToString();
                    //emisor_cfdi33.CP = emisor_id.Rows[0]["CP"].ToString();
                    //emisor_cfdi33.Pais = emisor_id.Rows[0]["PAIS"].ToString();
                    //emisor_cfdi33.Telefono = emisor_id.Rows[0]["TELEFONO1"].ToString();
                    //emisor_cfdi33.Regimen_Fiscal = emisor_id.Rows[0]["REGIMENFISCAL"].ToString();

                    emisor_cfdi33 = emisor_id.Rows[0];
                    if (ban_ambiente == false)
                        emisor_cfdi33.RFC = "IVD920810GU2";
                    /*----------------------------------------------------------------------------------------------------------------------------------------*/

                    /*------------------------------------------------------------DATOS DEL RECEPTOR----------------------------------------------------------*/
                    //DATOS DEL RECEPTOR
                    DataTable cliente_id = cliente.ClientesSelectById();

                    //receptor_cfdi33.Nombre = cliente_id.Rows[0]["NOMBRE"].ToString();
                    //receptor_cfdi33.RFC = cliente_id.Rows[0]["RFC"].ToString();
                    //receptor_cfdi33.Calle = cliente_id.Rows[0]["CALLE"].ToString();
                    //receptor_cfdi33.NoExterior = cliente_id.Rows[0]["NOEXTERIOR"].ToString();
                    //receptor_cfdi33.NoInterior = cliente_id.Rows[0]["NOINTERIOR"].ToString();
                    //receptor_cfdi33.Colonia = cliente_id.Rows[0]["COLONIA"].ToString();
                    //receptor_cfdi33.Municipio = cliente_id.Rows[0]["MUNICIPIO"].ToString();
                    //receptor_cfdi33.Estado = cliente_id.Rows[0]["ESTADO"].ToString();
                    //receptor_cfdi33.CP = cliente_id.Rows[0]["CP"].ToString();
                    //receptor_cfdi33.Pais = cliente_id.Rows[0]["PAIS"].ToString();
                    //receptor_cfdi33.Telefono = cliente_id.Rows[0]["TELEFONO1"].ToString();

                    receptor_cfdi33 = cliente_id.Rows[0];
                    /*----------------------------------------------------------------------------------------------------------------------------------------*/

                    /*--------------------------------------------------------DATOS DE LA FACTURA-------------------------------------------------------------*/
                    //DATOS DE LA FACTURA
                    formaPago_SAT = fastFilterFormaPago(Convert.ToInt32(cmbFormasPago.SelectedValue.ToString())).Rows[0];
                    metodoPago_SAT = fastFilterMetodoPago(Convert.ToInt32(cmbTiposPago.SelectedValue.ToString())).Rows[0];
                    moneda = fastFilterMonedas("MXN").Rows[0];
                    cfdi = fastFilterUsoCFDI(cmbCFDI.SelectedValue.ToString()).Rows[0];

                    datosfactura.Folio = (Convert.ToInt32(txtTimbresUsados.Text) + 1).ToString();
                    datosfactura.Fecha = DateTime.Now;
                    datosfactura.FormaPago = formaPago_SAT.Clave_SAT;
                    datosfactura.ban_FormaPago = true;
                    datosfactura.MetodoPago = metodoPago_SAT.Clave_SAT;
                    datosfactura.ban_MetodoPago = true;
                    datosfactura.Tipo_Comprobante_ = "I";
                    datosfactura.ban_Descuento = false;
                    datosfactura.SubTotal = Convert.ToDecimal(txtSubTotal.Text);
                    datosfactura.Total = Convert.ToDecimal(txtTotal.Text);
                    datosfactura.LugarExpedicion = emisor_cfdi33.CP;
                    datosfactura.Moneda = "MXN";
                    datosfactura.Tipo_Comprobante = 1;
                    datosfactura.Uso_CFDI = cmbCFDI.SelectedValue.ToString();
                    /*----------------------------------------------------------------------------------------------------------------------------------------*/

                    /*--------------------------------------------------------DATOS DE LOS CONCEPTOS----------------------------------------------------------*/
                    LlenarListaDeProductos();

                    //var IEPS = DS.Sum(g => g.IEPS);
                    //var IVA = DS.Sum(g => g.IVA);

                    //if (ValidarClavesSAT(DS) != 0)
                    //{
                    //    MessageBox.Show("Los siguientes productos no cuentan con clave SAT Producto / Servicio: \n" + productos_sin_clavesat, "Productos sin clave SAT",
                    //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    //if (ValidarClavesSAT_Unidades(DS) != 0)
                    //{
                    //    MessageBox.Show("Los siguientes productos no cuentan con clave SAT Unidad: \n" + productos_sin_clavesat_unidad, "Productos sin clave SAT",
                    //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                    string producto_factura = "";
                    datosfactura.Total = 0;
                    datosfactura.SubTotal = 0;
                    impuestos_cfdi33.IVA = 0;
                    impuestos_cfdi33.IEPS = 0;
                    impuestos_cfdi33.RetISR = 0;
                    impuestos_cfdi33.RetIVA = 0;

                    foreach(Facturas_Detalles detalle in lista_conceptos_pago)
                    {
                        //p_sat = new Clases.Productos_ClaveSAT();
                        //p_sat.ClaveSAT = DS[i].Codigo;

                        Conceptos concepto_cfdi33 = new Conceptos();
                        concepto_cfdi33.Cantidad = detalle.Cantidad;
                        concepto_cfdi33.NoIdentificacion = detalle.Codigo;
                        try
                        {
                            concepto_cfdi33.Clave_Producto_Servicio = detalle.Clave_Prod_Serv;//fastFilterClavesSATByIdProducto(DS[i].Codigo, DS[i].Unidad).Rows[0]["CLAVE_SAT"].ToString();
                        }
                        catch (Exception ex) { concepto_cfdi33.Clave_Producto_Servicio = ""; }
                        try
                        {
                            concepto_cfdi33.Clave_Unidad = detalle.Clave_Unidad;//fastFilterClavesSATByIdProducto(DS[i].Codigo, DS[i].Unidad).Rows[0]["CLAVE_SAT_UNIDAD"].ToString();
                        }
                        catch (Exception ex) { concepto_cfdi33.Clave_Unidad = ""; }
                        concepto_cfdi33.Unidad = detalle.Unidad;//DS[i].Unidad;
                        concepto_cfdi33.Descripcion = detalle.Descripcion; //DS[i].Descripcion;
                        concepto_cfdi33.PrecioUnitario = detalle.Precio_Unitario;//Decimal.Round(DS[i].PrecioUnitario, 4);
                        concepto_cfdi33.Importe = detalle.Importe;//Decimal.Round((concepto_cfdi33.PrecioUnitario * concepto_cfdi33.Cantidad), 2);//(DS[i].Total, 2);
                        concepto_cfdi33.descuento = 0;
                        concepto_cfdi33.ban_descuento = false;

                        try
                        {
                            clave_ProdServ = fastFilterClavesProdServ(concepto_cfdi33.Clave_Producto_Servicio).Rows[0];
                        }
                        catch (Exception ex) { ban_clave_sat_prod_serv = false; }

                        try
                        {
                            clave_unidad = fastFilterClavesUnidades(concepto_cfdi33.Clave_Unidad).Rows[0];
                        }
                        catch (Exception ex) { ban_clave_sat_unidad = false; }
                        concepto_cfdi33.Descripcion_SAT_Prod_Serv = clave_ProdServ.Descripcion;
                        concepto_cfdi33.Descripcion_SAT_Unidad = clave_unidad.Descripcion;

                        //iva
                        concepto_cfdi33.trasladados_IVA = new Conceptos_Impuestos_Trasladados();
                        concepto_cfdi33.trasladados_IVA.impuesto_base = concepto_cfdi33.Importe;
                        concepto_cfdi33.trasladados_IVA.tipo_impuesto = "002";
                        concepto_cfdi33.trasladados_IVA.tipo_factor = "Tasa";
                        concepto_cfdi33.trasladados_IVA.importe_impuesto = detalle.Imp_traslado_iva;//Decimal.Round(detalle.Imp_traslado_iva, 2).TruncateDecimal(2);
                        concepto_cfdi33.trasladados_IVA.ban_importe_impuesto = true;
                        if(detalle.Imp_traslado_iva != 0)
                            concepto_cfdi33.trasladados_IVA.tasa_o_cuota = "0.160000";//Decimal.Round(((decimal)DS[i].IVAPorcentaje / 100M), 6).ToString("N6");
                        else
                            concepto_cfdi33.trasladados_IVA.tasa_o_cuota = "0.000000";
                        concepto_cfdi33.trasladados_IVA.ban_tasa_o_cuota = true;

                        //ieps
                        concepto_cfdi33.trasladados_IEPS = new Conceptos_Impuestos_Trasladados();
                        concepto_cfdi33.trasladados_IEPS.impuesto_base = concepto_cfdi33.Importe;
                        concepto_cfdi33.trasladados_IEPS.tipo_impuesto = "003";
                        concepto_cfdi33.trasladados_IEPS.tipo_factor = "Tasa";
                        concepto_cfdi33.trasladados_IEPS.importe_impuesto = detalle.Imp_traslados_ieps;//Decimal.Round(DS[i].IEPS, 2);
                        concepto_cfdi33.trasladados_IEPS.ban_importe_impuesto = true;
                        concepto_cfdi33.trasladados_IEPS.tasa_o_cuota = "0.000000";
                        concepto_cfdi33.trasladados_IEPS.ban_tasa_o_cuota = true;

                        //ret. isr
                        concepto_cfdi33.retenciones_ISR = new Conceptos_Impuestos_Retenciones();
                        concepto_cfdi33.retenciones_ISR.impuesto_base = concepto_cfdi33.Importe;
                        concepto_cfdi33.retenciones_ISR.tipo_impuesto = "001";
                        concepto_cfdi33.retenciones_ISR.tipo_factor = "Tasa";
                        concepto_cfdi33.retenciones_ISR.importe_impuesto = Decimal.Round(0, 2);
                        concepto_cfdi33.retenciones_ISR.ban_importe_impuesto = true;
                        concepto_cfdi33.retenciones_ISR.tasa_o_cuota = "0.000000";//ObtenerTasaOCuotaISR(con.retenciones_ISR.importe_impuesto);
                        concepto_cfdi33.retenciones_ISR.ban_tasa_o_cuota = true;

                        //ret. iva
                        concepto_cfdi33.retenciones_IVA = new Conceptos_Impuestos_Retenciones();
                        concepto_cfdi33.retenciones_IVA.impuesto_base = concepto_cfdi33.Importe;
                        concepto_cfdi33.retenciones_IVA.tipo_impuesto = "002";
                        concepto_cfdi33.retenciones_IVA.tipo_factor = "Tasa";
                        concepto_cfdi33.retenciones_IVA.importe_impuesto = Decimal.Round(0, 2);
                        concepto_cfdi33.retenciones_IVA.ban_importe_impuesto = true;
                        concepto_cfdi33.retenciones_IVA.tasa_o_cuota = "0.000000";//ObtenerTasaOCuotaRetIVA(con.retenciones_IVA.importe_impuesto);
                        concepto_cfdi33.retenciones_IVA.ban_tasa_o_cuota = true;

                        lista_conceptos_cfdi33.Add(concepto_cfdi33);

                        //SubTotal = SubTotal + con.Importe;

                        impuestos_cfdi33.IVA += concepto_cfdi33.trasladados_IVA.importe_impuesto;
                        impuestos_cfdi33.IEPS += concepto_cfdi33.trasladados_IEPS.importe_impuesto;
                        impuestos_cfdi33.RetIVA += concepto_cfdi33.retenciones_IVA.importe_impuesto;
                        impuestos_cfdi33.RetISR += concepto_cfdi33.retenciones_ISR.importe_impuesto;

                        datosfactura.SubTotal = datosfactura.SubTotal + concepto_cfdi33.Importe;
                        datosfactura.Total = datosfactura.Total + concepto_cfdi33.Importe 
                                                                + concepto_cfdi33.trasladados_IEPS.importe_impuesto
                                                                + concepto_cfdi33.trasladados_IVA.importe_impuesto
                                                                - concepto_cfdi33.retenciones_ISR.importe_impuesto
                                                                - concepto_cfdi33.retenciones_IVA.importe_impuesto;
                    }

                    /*----------------------------------------------------------------------------------------------------------------------------------------*/


                    /*----------------------------------------------------------------------IMPUESTOS----------------------------------------------------------------*/
                    //impuestos y retenciones sobre la factura
                    impuestos_cfdi33.TipoFactor = "Tasa";
                    impuestos_cfdi33.IVA_TasaOCuota = "0.160000";
                    impuestos_cfdi33.IEPS_TasaOCuota = "0.000000";
                    impuestos_cfdi33.PorcentajeIEPS = 0.00M;
                    impuestos_cfdi33.ban_ImpuestosRetenidos = true;
                    impuestos_cfdi33.ban_ImpuestosTrasladados = true;
                    //imp.IVA = Decimal.Round(imp.IVA,2);
                    /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

                    /*--------------------------------------------------------TABLA EMISORES PARA REPORTE-----------------------------------------------------------------*/
                    datos_Emisores = new DataTable();
                    DataRow filaE = datos_Emisores.NewRow();
                    datos_Emisores.Columns.Add("RFC", Type.GetType("System.String"));                   //0.-
                    datos_Emisores.Columns.Add("Nombre", Type.GetType("System.String"));                //1.-
                    datos_Emisores.Columns.Add("Calle", Type.GetType("System.String"));                 //2.- 
                    datos_Emisores.Columns.Add("NoExterior", Type.GetType("System.String"));            //3.-
                    datos_Emisores.Columns.Add("NoInterior", Type.GetType("System.String"));            //4.-
                    datos_Emisores.Columns.Add("Colonia", Type.GetType("System.String"));               //5.-
                    datos_Emisores.Columns.Add("Municipio", Type.GetType("System.String"));             //6.-
                    datos_Emisores.Columns.Add("Estado", Type.GetType("System.String"));                //7.-
                    datos_Emisores.Columns.Add("Pais", Type.GetType("System.String"));                  //8.-
                    datos_Emisores.Columns.Add("CP", Type.GetType("System.String"));                    //9.-
                    datos_Emisores.Columns.Add("Telefono", Type.GetType("System.String"));              //10.-
                    datos_Emisores.Columns.Add("Regimen_Fiscal", Type.GetType("System.String"));        //11.-
                    datos_Emisores.Columns.Add("Logo", Type.GetType("System.Byte[]"));                  //12.-
                    datos_Emisores.TableName = "Emisores";

                    filaE["RFC"] = emisor_cfdi33.RFC;
                    filaE["Nombre"] = emisor_cfdi33.Nombre;//emisor_id.Rows[0]["NOMBRE"].ToString();
                    filaE["Calle"] = emisor_cfdi33.Calle;
                    filaE["NoExterior"] = emisor_cfdi33.NoExterior;
                    filaE["NoInterior"] = emisor_cfdi33.NoInterior;
                    filaE["Colonia"] = emisor_cfdi33.Colonia;
                    filaE["Municipio"] = emisor_cfdi33.Municipio;
                    filaE["Estado"] = emisor_cfdi33.Estado;
                    filaE["Pais"] = emisor_cfdi33.Pais;
                    filaE["CP"] = emisor_cfdi33.CP;
                    filaE["Telefono"] = emisor_cfdi33.Telefono;
                    filaE["Regimen_Fiscal"] = emisor_cfdi33.Regimen_Fiscal;
                    filaE["Logo"] = Organismo.Actual.Imagen;

                    try
                    {
                        //byte[] arg = (byte[])emisor_id.Rows[0]["LOGO"];
                        //System.IO.MemoryStream ms = new System.IO.MemoryStream(arg);
                        //filaE[12] = arg;
                    }
                    catch (Exception ex) { /*MessageBox.Show(ex.Message);*/ }

                    datos_Emisores.Rows.Add(filaE);
                    /*-------------------------------------------------------------------------------------------------------------------------------------------------*/


                    /*-------------------------------------------------TABLA RECEPTORES PARA REPORTE-------------------------------------------------------------------*/
                    datos_Receptores = new DataTable();
                    datos_Receptores.Columns.Add("RFC", Type.GetType("System.String"));                    //0.-
                    datos_Receptores.Columns.Add("Nombre", Type.GetType("System.String"));                 //1.-
                    datos_Receptores.Columns.Add("Calle", Type.GetType("System.String"));                  //2.-
                    datos_Receptores.Columns.Add("NoExterior", Type.GetType("System.String"));             //3.-
                    datos_Receptores.Columns.Add("NoInterior", Type.GetType("System.String"));             //4.-
                    datos_Receptores.Columns.Add("Colonia", Type.GetType("System.String"));                //5.-
                    datos_Receptores.Columns.Add("Municipio", Type.GetType("System.String"));              //6.-
                    datos_Receptores.Columns.Add("Estado", Type.GetType("System.String"));                 //7.-
                    datos_Receptores.Columns.Add("Pais", Type.GetType("System.String"));                   //8.-
                    datos_Receptores.Columns.Add("CP", Type.GetType("System.String"));                     //9.-
                    datos_Receptores.Columns.Add("Telefono", Type.GetType("System.String"));               //10.-
                    datos_Receptores.TableName = "Receptores";

                    DataRow filaR = datos_Receptores.NewRow();
                    filaR["RFC"] = receptor_cfdi33.RFC;
                    filaR["Nombre"] = receptor_cfdi33.Nombre;
                    filaR["Calle"] = receptor_cfdi33.Calle;
                    filaR["NoExterior"] = receptor_cfdi33.NoExterior;
                    filaR["NoInterior"] = receptor_cfdi33.NoInterior;
                    filaR["Colonia"] = receptor_cfdi33.Colonia;
                    filaR["Municipio"] = receptor_cfdi33.Municipio;
                    filaR["Estado"] = receptor_cfdi33.Estado;
                    filaR["Pais"] = receptor_cfdi33.Pais;
                    filaR["CP"] = receptor_cfdi33.CP;
                    filaR["Telefono"] = receptor_cfdi33.Telefono;
                    datos_Receptores.Rows.Add(filaR);

                    /*-----------------------------------------------------------------------------------------------------------------------------------------------------*/

                    /*----------------------------------------------------TABLA DE CONCEPTOS DE FACTURACION PARA REPORTE---------------------------------------------------*/
                    Conceptosfactura = new DataTable();
                    Conceptosfactura.Columns.Add("Cantidad", Type.GetType("System.Decimal"));                          //0.-
                    Conceptosfactura.Columns.Add("Unidad", Type.GetType("System.String"));                             //1.-
                    Conceptosfactura.Columns.Add("Descripcion", Type.GetType("System.String"));                        //2.-
                    Conceptosfactura.Columns.Add("P_Unitario", Type.GetType("System.Decimal"));                        //3.-
                    Conceptosfactura.Columns.Add("Importe", Type.GetType("System.Decimal"));                           //4.-
                    Conceptosfactura.Columns.Add("Clave_Prod_Serv", Type.GetType("System.String"));                    //5.-
                    Conceptosfactura.Columns.Add("Clave_Unidad", Type.GetType("System.String"));                       //6.- 
                    Conceptosfactura.Columns.Add("CodigoIdentificacion", Type.GetType("System.String"));               //7.-
                    Conceptosfactura.Columns.Add("DescripcionSATProdServ", Type.GetType("System.String"));             //8.-
                    Conceptosfactura.Columns.Add("DescripcionSATUnidad", Type.GetType("System.String"));               //9.-
                    Conceptosfactura.Columns.Add("Descuento", Type.GetType("System.Decimal"));                         //10.-
                    Conceptosfactura.Columns.Add("IVA_traslado_base", Type.GetType("System.Decimal"));                 //11.-
                    Conceptosfactura.Columns.Add("IVA_traslado_tipo", Type.GetType("System.String"));                  //12.-
                    Conceptosfactura.Columns.Add("IVA_traslado_factor", Type.GetType("System.String"));                //13.-
                    Conceptosfactura.Columns.Add("IVA_traslado_tasa", Type.GetType("System.String"));                  //14.-
                    Conceptosfactura.Columns.Add("IVA_traslado_importe", Type.GetType("System.Decimal"));              //15.-
                    Conceptosfactura.Columns.Add("IEPS_traslado_base", Type.GetType("System.Decimal"));                //16.-
                    Conceptosfactura.Columns.Add("IEPS_traslado_tipo", Type.GetType("System.String"));                 //17.-
                    Conceptosfactura.Columns.Add("IEPS_traslado_factor", Type.GetType("System.String"));               //18.-
                    Conceptosfactura.Columns.Add("IEPS_traslado_tasa", Type.GetType("System.String"));                 //19.-
                    Conceptosfactura.Columns.Add("IEPS_traslado_importe", Type.GetType("System.Decimal"));             //20.-
                    Conceptosfactura.Columns.Add("IVA_retencion_base", Type.GetType("System.Decimal"));                //21.-
                    Conceptosfactura.Columns.Add("IVA_retencion_tipo", Type.GetType("System.String"));                 //22.-
                    Conceptosfactura.Columns.Add("IVA_retencion_factor", Type.GetType("System.String"));               //23.-
                    Conceptosfactura.Columns.Add("IVA_retencion_tasa", Type.GetType("System.String"));                 //24.-
                    Conceptosfactura.Columns.Add("IVA_retencion_importe", Type.GetType("System.Decimal"));             //25.-
                    Conceptosfactura.Columns.Add("ISR_retencion_base", Type.GetType("System.Decimal"));                //26.-
                    Conceptosfactura.Columns.Add("ISR_retencion_tipo", Type.GetType("System.String"));                 //27.-
                    Conceptosfactura.Columns.Add("ISR_retencion_factor", Type.GetType("System.String"));               //28.-
                    Conceptosfactura.Columns.Add("ISR_retencion_tasa", Type.GetType("System.String"));                 //29.-
                    Conceptosfactura.Columns.Add("ISR_retencion_importe", Type.GetType("System.Decimal"));             //30.-
                    Conceptosfactura.TableName = "ConceptosFactura33";


                    foreach (Conceptos con in lista_conceptos_cfdi33)
                    {
                        DataRow filaCF = Conceptosfactura.NewRow();
                        filaCF["Cantidad"] = con.Cantidad;
                        filaCF["Unidad"] = con.Unidad;
                        filaCF["Descripcion"] = con.Descripcion;
                        filaCF["P_Unitario"] = con.PrecioUnitario;
                        filaCF["Importe"] = con.Importe;
                        filaCF["Clave_Prod_Serv"] = con.Clave_Producto_Servicio;
                        filaCF["Clave_Unidad"] = con.Clave_Unidad;
                        filaCF["CodigoIdentificacion"] = con.NoIdentificacion;
                        filaCF["DescripcionSATProdServ"] = con.Descripcion_SAT_Prod_Serv;
                        filaCF["DescripcionSATUnidad"] = con.Descripcion_SAT_Unidad;
                        filaCF["Descuento"] = con.descuento;
                        filaCF["IVA_traslado_base"] = con.trasladados_IVA.impuesto_base;
                        filaCF["IVA_traslado_tipo"] = getNombreImpuesto(con.trasladados_IVA.tipo_impuesto);
                        filaCF["IVA_traslado_factor"] = con.trasladados_IVA.tipo_factor;
                        filaCF["IVA_traslado_tasa"] = con.trasladados_IVA.tasa_o_cuota;
                        filaCF["IVA_traslado_importe"] = con.trasladados_IVA.importe_impuesto;
                        filaCF["IEPS_traslado_base"] = con.trasladados_IEPS.impuesto_base;
                        filaCF["IEPS_traslado_tipo"] = getNombreImpuesto(con.trasladados_IEPS.tipo_impuesto);
                        filaCF["IEPS_traslado_factor"] = con.trasladados_IEPS.tipo_factor;
                        filaCF["IEPS_traslado_tasa"] = con.trasladados_IEPS.tasa_o_cuota;
                        filaCF["IEPS_traslado_importe"] = con.trasladados_IEPS.importe_impuesto;
                        filaCF["IVA_retencion_base"] = con.retenciones_IVA.impuesto_base;
                        filaCF["IVA_retencion_tipo"] = getNombreImpuesto(con.retenciones_IVA.tipo_impuesto);
                        filaCF["IVA_retencion_factor"] = con.retenciones_IVA.tipo_factor;
                        filaCF["IVA_retencion_tasa"] = con.retenciones_IVA.tasa_o_cuota;
                        filaCF["IVA_retencion_importe"] = con.retenciones_IVA.importe_impuesto;
                        filaCF["ISR_retencion_base"] = con.retenciones_ISR.impuesto_base;
                        filaCF["ISR_retencion_tipo"] = getNombreImpuesto(con.retenciones_ISR.tipo_impuesto);
                        filaCF["ISR_retencion_factor"] = con.retenciones_ISR.tipo_factor;
                        filaCF["ISR_retencion_tasa"] = con.retenciones_ISR.tasa_o_cuota;
                        filaCF["ISR_retencion_importe"] = con.retenciones_ISR.importe_impuesto;
                        Conceptosfactura.Rows.Add(filaCF);
                    }
                    /*-----------------------------------------------------------------------------------------------------------------------------------------------------*/


                    /*---------------------------------------------------------------------------DATOS DE LA FACTURA-------------------------------------------------------*/
                    Datos_Factura = new DataTable();
                    Datos_Factura.Columns.Add("Serie", Type.GetType("System.String"));                          //0.-
                    Datos_Factura.Columns.Add("Folio", Type.GetType("System.String"));                          //1.-
                    Datos_Factura.Columns.Add("Fecha", Type.GetType("System.DateTime"));                        //2.-
                    Datos_Factura.Columns.Add("FormaPago", Type.GetType("System.String"));                      //3.-
                    Datos_Factura.Columns.Add("MetodoPago", Type.GetType("System.String"));                     //4.-
                    Datos_Factura.Columns.Add("SubTotal", Type.GetType("System.Decimal"));                      //5.-
                    Datos_Factura.Columns.Add("Total", Type.GetType("System.Decimal"));                         //6.-
                    Datos_Factura.Columns.Add("Pais", Type.GetType("System.String"));                           //7.-
                    Datos_Factura.Columns.Add("Estado", Type.GetType("System.String"));                         //8.-
                    Datos_Factura.Columns.Add("TipoComprobante", Type.GetType("System.Int32"));                 //9.-
                    Datos_Factura.Columns.Add("UsoCFDI", Type.GetType("System.String"));                        //10.-
                    Datos_Factura.Columns.Add("Tipo_comprobante", Type.GetType("System.String"));               //11.-
                    Datos_Factura.Columns.Add("Moneda", Type.GetType("System.String"));                         //12.-
                    Datos_Factura.Columns.Add("CFDIRelacionados", Type.GetType("System.String"));               //13.-
                    Datos_Factura.TableName = "Datos_Factura";

                    DataRow filaDF = Datos_Factura.NewRow();
                    filaDF["Serie"] = datosfactura.Serie;
                    filaDF["Folio"] = datosfactura.Folio;
                    filaDF["Fecha"] = datosfactura.Fecha;
                    filaDF["FormaPago"] = datosfactura.FormaPago;
                    filaDF["MetodoPago"] = datosfactura.MetodoPago;
                    filaDF["SubTotal"] = datosfactura.SubTotal;
                    filaDF["Total"] = datosfactura.Total;
                    filaDF["Pais"] = emisor_cfdi33.Pais;
                    filaDF["Estado"] = emisor_cfdi33.Estado;
                    filaDF["TipoComprobante"] = datosfactura.Tipo_Comprobante;
                    filaDF["UsoCFDI"] = "(" + cfdi.Clave_SAT + ")" + " " + cfdi.descripcion;
                    filaDF["Tipo_comprobante"] = "I Ingreso";//df.Tipo_Comprobante;
                    filaDF["Moneda"] = "(MXN) Peso Mexicano";
                    filaDF["CFDIRelacionados"] = "";
                    Datos_Factura.Rows.Add(filaDF);
                    /*-----------------------------------------------------------------------------------------------------------------------------------------------------*/

                    /*-------------------------------------------------------------CERTIFICADO-----------------------------------------------------------------------------*/
                    DatosCertificado = new DataTable();
                    DatosCertificado.Columns.Add("FolioFiscal", Type.GetType("System.String"));                             //0.-
                    DatosCertificado.Columns.Add("NoCertificadoCSD", Type.GetType("System.String"));                        //1.-
                    DatosCertificado.Columns.Add("NoCertificadoSAT", Type.GetType("System.String"));                        //2.-
                    DatosCertificado.Columns.Add("FechaCertificacion", Type.GetType("System.String"));                      //3.-
                    DatosCertificado.Columns.Add("SelloCFDI", Type.GetType("System.String"));                               //4.-
                    DatosCertificado.Columns.Add("SelloSAT", Type.GetType("System.String"));                                //5.-
                    DatosCertificado.Columns.Add("CadenaOriginalComplemento", Type.GetType("System.String"));               //6.-
                    DatosCertificado.Columns.Add("Imagen", Type.GetType("System.Byte[]"));                                  //7.-
                    DatosCertificado.TableName = "DatosCertificado";

                    DataRow filaDC = DatosCertificado.NewRow();
                    List<string> lista_uuid = new List<string>();

                    if(timbrado == true)
                    {
                        rt = f.Facturar(ban_ambiente, emisor_cfdi33, receptor_cfdi33, datosfactura, lista_conceptos_cfdi33, impuestos_cfdi33, lista_uuid);

                        filaDC["FolioFiscal"] = rt.FolioUUID;
                        filaDC["NoCertificadoCSD"] = rt.No_Certificado;
                        filaDC["NoCertificadoSAT"] = rt.No_Certificado_SAT;
                        filaDC["FechaCertificacion"] = rt.FechaCertificacion;
                        filaDC["SelloCFDI"] = rt.SelloCFDI;
                        filaDC["SelloSAT"] = rt.SelloSAT;
                        filaDC["CadenaOriginalComplemento"] = rt.CadenaTimbre;
                        filaDC["Imagen"] = rt.CodigoBidimensional;
                    }
                    else
                    {
                        filaDC["FolioFiscal"] = "VISTA PREVIA";
                        filaDC["NoCertificadoCSD"] = "";
                        filaDC["NoCertificadoSAT"] = "";
                        filaDC["FechaCertificacion"] = "";
                        filaDC["SelloCFDI"] = "";
                        filaDC["SelloSAT"] = "";
                        filaDC["CadenaOriginalComplemento"] = "";
                        filaDC["Imagen"] = null;
                    }

                    DatosCertificado.Rows.Add(filaDC);
                    /*-----------------------------------------------------------------------------------------------------------------------------------------------------*/

                    /*----------------------------------------------------TABLA COMPLEMENTO DE PAGOS----------------------------------------------------------------*/

                    FacturasPagos pago = new FacturasPagos();
                    FacturasPagosDetalles pago_detalles = new FacturasPagosDetalles();
                    //SAPA_Facturacion.Catalogos_SAT.Monedas_SAT moneda = new Catalogos_SAT.Monedas_SAT();
                    Formas_Pago forma_pago = new Formas_Pago();

                    pago.IdFactura = factura_timbrada.Id;

                    DataTable complemento_PA = tablaPagos(Pa);
                    complemento_PA.TableName = "RptComplemento_PA";

                    DataTable complemento_PA2 = tablaPagos(Pa);
                    complemento_PA2.TableName = "RptComplemento_PA";

                    try
                    {
                        //moneda.Clave_SAT = complemento_PA.Rows[0]["MONEDA"].ToString();
                        //moneda.Descripcion = "(" + moneda.Clave_SAT + ") " + moneda.SelectMonedasSATPorClave().Rows[0]["DESCRIPCION"].ToString();

                        forma_pago.Clave_SAT = complemento_PA.Rows[0]["FORMAPAGO"].ToString();
                        forma_pago.Descripcion = "(" + forma_pago.Clave_SAT + ") " + forma_pago.FormasPagoSATSelectByClaveSAT().Rows[0]["DESCRIPCION"].ToString();

                        pago.Id = int.Parse(complemento_PA.Rows[0]["ID"].ToString());
                        pago.MonedaP = "(MXN) Peso Mexicano";
                        pago.FormaPagoP = forma_pago.Descripcion;
                    }
                    catch (Exception ex)
                    {
                        pago.Id = 0;
                        pago.MonedaP = "";
                        pago.FormaPagoP = "";
                    }

                    pago_detalles.IdComplemento = pago.Id;

                    DataTable DatosComplementoPA = tablaPagosDetalles(Pa, filaDC[0].ToString());
                    DatosComplementoPA.TableName = "RptComplemento_PA_Detalles";

                    DataTable DatosComplementoPA2 = tablaPagosDetalles(Pa, filaDC[0].ToString());
                    DatosComplementoPA2.TableName = "RptComplemento_PA_Detalles";

                    RptFactura_CFDI33_Pagos rpt_pago = new RptFactura_CFDI33_Pagos();
                    DataSet ds_pago = new DataSet();
                    ds_pago.Tables.Add(DatosComplementoPA);
                    ds_pago.Tables.Add(complemento_PA);
                    rpt_pago.SetDataSource(ds_pago);
                    rpt_pago.SetParameterValue("filas", DatosComplementoPA.Rows.Count);
                    rpt_pago.SetParameterValue("Moneda_Descripcion", pago.MonedaP);
                    rpt_pago.SetParameterValue("FormaPago_Descripcion", pago.FormaPagoP);

                    /*----------------------------------------------------------------------------------------------------------------------------------*/
                    ConvertidorLetrasV2.Class1 ImporteLetra = new ConvertidorLetrasV2.Class1();

                    regimen_fiscal = fastFilterRegimenFiscal(emisor_cfdi33.Regimen_Fiscal).Rows[0];

                    DataSet ds = new DataSet();
                    ds.Tables.Add(datos_Emisores);
                    ds.Tables.Add(datos_Receptores);
                    ds.Tables.Add(Datos_Factura);
                    ds.Tables.Add(DatosCertificado);
                    ds.Tables.Add(Conceptosfactura);
                    ds.Tables.Add(DatosComplementoPA2);
                    ds.Tables.Add(complemento_PA2);
                    RptFactura_CFDI33_2 rpt = new RptFactura_CFDI33_2();
                    rpt.SetDataSource(ds);

                    rpt.SetParameterValue("Comentarios", txtComentarios.Text);
                    rpt.SetParameterValue("Referencia", txtNoRef.Text);
                    rpt.SetParameterValue("ImporteLetra", ImporteLetra.enletras(txtTotal.Text));
                    rpt.SetParameterValue("IVA", impuestos_cfdi33.IVA);
                    rpt.SetParameterValue("IEPS_Producto", impuestos_cfdi33.IEPS);
                    rpt.SetParameterValue("Ret_ISR_Producto", impuestos_cfdi33.RetISR);
                    rpt.SetParameterValue("Ret_IVA_Producto", impuestos_cfdi33.RetIVA);
                    rpt.SetParameterValue("Subtotal_Producto", datosfactura.SubTotal);
                    rpt.SetParameterValue("NoFactura", datosfactura.Folio/*(Convert.ToInt32(factura_timbrada.FacturasSelectMaxID().Rows[0]["ID"].ToString()) + 1).ToString()*/);
                    rpt.SetParameterValue("Razon_social", emisor_cfdi33.RazonSocial);
                    rpt.SetParameterValue("Fecha_Emision", datosfactura.Fecha);
                    rpt.SetParameterValue("Hora_emision", datosfactura.Fecha);
                    rpt.SetParameterValue("Regimen_Fiscal_Descripcion", "(" + regimen_fiscal.Clave_SAT + ") " + regimen_fiscal.Descripcion);
                    rpt.SetParameterValue("FormaPago", formaPago_SAT.Descripcion);
                    rpt.SetParameterValue("MetodoPago", metodoPago_SAT.Descripcion);
                    rpt.SetParameterValue("Razon_social_cliente", receptor_cfdi33.Nombre);
                    rpt.SetParameterValue("Descuento", 0);
                    rpt.SetParameterValue("ISH", 0);
                    rpt.SetParameterValue("filas", 0);
                    rpt.SetParameterValue("Moneda_Descripcion", "");
                    rpt.SetParameterValue("FormaPago_Descripcion", "");

                    if(timbrado == true)
                    {
                        //validar si se genero la factura
                        if (rt.Exitoso == false)
                        {
                            MessageBox.Show("No se pudo generar la factura: \n " + rt.Descripcion, "Error al facturar",MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Cursor = Cursors.Arrow;
                        }

                        else if (rt.Exitoso == true)
                        {
                            //crear pdf de la factura
                            Ruta = "C:\\Facturas\\" + receptor_cfdi33.Nombre + "\\" + rt.FolioUUID + "\\";
                            if (!Directory.Exists(Ruta))
                                Directory.CreateDirectory(Ruta);
                            rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta + rt.FolioUUID + ".pdf");

                            //Guardar factura generada
                            //factura_timbrada.IdVenta = 0;
                            factura_timbrada.Folio_Factura = Convert.ToInt32(datosfactura.Folio);
                            factura_timbrada.FolioUUID = rt.FolioUUID;
                            factura_timbrada.IdCliente = receptor_cfdi33.Id;
                            factura_timbrada.Fecha = datosfactura.Fecha;
                            factura_timbrada.Total = datosfactura.Total;
                            factura_timbrada.SubTotal = datosfactura.SubTotal;
                            factura_timbrada.IVA = impuestos_cfdi33.IVA/*Convert.ToDecimal(txtIVA.Text)*/;
                            factura_timbrada.Ret_IVA = impuestos_cfdi33.RetIVA/*Convert.ToDecimal(txtRetIVA.Text)*/;
                            factura_timbrada.Ret_ISR = impuestos_cfdi33.RetISR/*Convert.ToDecimal(txtRetISR.Text)*/;
                            factura_timbrada.IEPS = impuestos_cfdi33.IEPS/*Convert.ToDecimal(txtIEPS.Text)*/;
                            factura_timbrada.MetodoPago = metodoPago_SAT.Clave_SAT;
                            factura_timbrada.FormaPago = formaPago_SAT.Clave_SAT;
                            factura_timbrada.Referencia = txtNoRef.Text;
                            factura_timbrada.Comentarios = txtComentarios.Text;
                            factura_timbrada.Uso_CFDI = cmbCFDI.SelectedValue.ToString();
                            //factura_timbrada.Version_CFDI = "3.3";
                            factura_timbrada.Tipo_Comprobante = "I Ingreso";
                            factura_timbrada.Id = factura_timbrada.Guardar();
                            Cursor = Cursors.Arrow;

                            //Aqui se ocupa guardar una relacion de pagos facturados
                            foreach (DataGridViewRow r in dgvFacturas.Rows)
                            {
                                if (Convert.ToBoolean(r.Cells["Seleccionar"].Value.ToString()))
                                {
                                    // Clases.Ventas venta = new Clases.Ventas();
                                    // venta.id = Convert.ToInt32(r.Cells["No. de Venta"].Value.ToString());
                                    // venta.VentaDetallesUpdateFactura(factura_timbrada.Id);
                                }
                            }

                            foreach (Conceptos concepto in lista_conceptos_cfdi33)
                            {
                                Facturas_Detalles fd = new Facturas_Detalles();
                                fd.IdFactura = factura_timbrada.Id;
                                fd.Codigo = concepto.NoIdentificacion;
                                fd.Descripcion = concepto.Descripcion;
                                fd.Cantidad = concepto.Cantidad;
                                fd.Precio_Unitario = concepto.PrecioUnitario;
                                fd.Importe = concepto.Importe;
                                fd.Imp_traslado_iva = concepto.trasladados_IVA.importe_impuesto;
                                fd.Imp_traslados_ieps = concepto.trasladados_IEPS.importe_impuesto;
                                fd.Imp_retencion_iva = concepto.retenciones_IVA.importe_impuesto;
                                fd.Imp_retencion_isr = concepto.retenciones_ISR.importe_impuesto;
                                fd.Clave_Prod_Serv = concepto.Clave_Producto_Servicio;
                                fd.Clave_Unidad = concepto.Clave_Unidad;
                                fd.Unidad = concepto.Unidad;
                                fd.IdProducto = 0;
                                fd.Guardar();
                            }

                            //Guardar cuenta de la factura
                            factura_cuenta = new FacturasCuentas();
                            factura_cuenta.Fecha = DateTime.Now;
                            factura_cuenta.FechaPago = DateTime.Now;
                            factura_cuenta.IdFactura = factura_timbrada.Id;
                            if (metodoPago_SAT.Id == 1)
                            {
                                factura_cuenta.Abonado = datosfactura.Total;
                                factura_cuenta.Restante = 0;
                            }
                            else
                            {
                                factura_cuenta.Abonado = 0;
                                factura_cuenta.Restante = datosfactura.Total;
                            }
                            factura_cuenta.TipoPago = metodoPago_SAT.Clave_SAT;
                            factura_cuenta.Guardar(1/*u.Id*/);

                            //Guardar abono de la factura
                            if (metodoPago_SAT.Id == 1)
                            {
                                abono = new FacturasAbonos();
                                abono.Cantidad = datosfactura.Total;
                                abono.Fecha = DateTime.Now;
                                abono.Forma_Pago = formaPago_SAT.Clave_SAT;
                                abono.IdFactura = factura_timbrada.Id;
                                abono.IdFactura_Abonada = factura_timbrada.Id;
                                abono.Moneda = "MXN";
                                abono.Tipo_Cambio = 1;
                                abono.Guardar(/*u.Id*/1);
                            }

                            /*-------------------------------------------CORREO SENDGRID--------------------------------------------------*/
                            String Correo = "";
                            string msg_enviados = "Se envió la factura al correo: \n";
                            string msg_error = "No se pudo enviar la factura al correo: \n";
                            int cont_enviados = 0;
                            int cont_error = 0;

                            if (ban_ambiente == true)
                            {
                                Correo = emisor_id.Rows[0]["CORREO"].ToString();
                            }
                            else if (ban_ambiente == false)
                            {
                                Correo = "correo.de.prueba.123@hotmail.com";
                            }

                            //correo emisor
                            OtherWay(Correo,
                                     Ruta + factura_timbrada.FolioUUID + ".pdf",
                                     Ruta + factura_timbrada.FolioUUID + ".xml",
                                     Correo,
                                     emisor_id.Rows[0]["NOMBRE"].ToString(),
                                     int.Parse(Datos_Factura.Rows[0][1].ToString()));

                            //correo sapa
                            OtherWay("sapa.facturacion1@gmail.com",
                                     Ruta + factura_timbrada.FolioUUID + ".pdf",
                                     Ruta + factura_timbrada.FolioUUID + ".xml",
                                     Correo,
                                     emisor_id.Rows[0]["NOMBRE"].ToString(),
                                     int.Parse(Datos_Factura.Rows[0][1].ToString()));

                            //correo receptor
                            DataTable correos_cliente = new DataTable();
                            correos_cliente.Columns.Add("Correo",typeof(string));
                            correos_cliente.Rows.Add(cliente_id.Rows[0]["CORREO"].ToString());//c.SelectClientesPorID();//.Rows[0]["CORREO"].ToString();//tablacorreos();
                            foreach (DataRow r in correos_cliente.Rows)
                            {
                                OtherWay(r["correo"].ToString(),
                                         Ruta + factura_timbrada.FolioUUID + ".pdf",
                                         Ruta + factura_timbrada.FolioUUID + ".xml",
                                         Correo,
                                         emisor_id.Rows[0]["NOMBRE"].ToString(),
                                         int.Parse(Datos_Factura.Rows[0][1].ToString()));
                            }

                            //mostrar mensaje de correos enviados
                            if (cont_enviados != 0)
                            {
                                MessageBox.Show(msg_enviados, "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            //mostrar mensaje de correos no enviados
                            if (cont_error != 0)
                            {
                                MessageBox.Show(msg_error, "Error al enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            /*------------------------------------------------------------------------------------------------------------*/

                            //EnviarCorreoEmisor(Ruta + factura_timbrada.FolioUUID);

                            //Enviar factura por Correo
                            //DialogResult confirmarCorreo = MessageBox.Show("¿Desea enviar la factura por correo al cliente?", "Factura CFDI",
                            //    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                            /*
                            if (confirmarCorreo == DialogResult.Yes)
                            {

                                Cursor = Cursors.WaitCursor;
                                List<string> lstArchivos = new List<string>();

                                //rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta);
                                lstArchivos.Add(Ruta + rt.FolioUUID + ".pdf");
                                //lstArchivos.Add(Ruta + rt.FolioUUID + ".jpg");
                                lstArchivos.Add(Ruta + rt.FolioUUID + ".xml");

                                Liverpool.Clases.Mail oMail = new Liverpool.Clases.Mail("servienvases.facturacion@gmail.com",
                                                                                        receptor_cfdi33.Correo,
                                                                                        "Archivo de Factura CFDI " + DateTime.Now,
                                                                                        "Factura " + Datos_Factura.Rows[0][1].ToString(),
                                                                                        lstArchivos);*

                                if (oMail.enviaMail())
                                {
                                    MessageBox.Show("Se envió la factura al correo " + receptor_cfdi33.Correo, "Correo enviado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo enviar la factura a " + ": " + oMail.error, "Error de Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                               
                                Cursor = Cursors.Arrow;
                            }
                             */

                            ////Enviar factura por correo
                            MessageBox.Show("Factura Registrada", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            DialogResult = DialogResult.OK;

                            FrmVistaRpt frm = new FrmVistaRpt(rpt);
                            frm.ShowDialog();
                            lista_conceptos_cfdi33.Clear();
                            ds.Clear();
                            rpt.SetDataSource(ds);
                            btnBuscarVentas.PerformClick();
                            limpiar();
                            ObtenerTimbres(emisor_cfdi33.RFC);
                        }
                    }
                    else
                    {
                        FrmVistaRpt frm = new FrmVistaRpt(rpt);
                        frm.ShowDialog();
                    }
                    
                    lista_conceptos_cfdi33.Clear();
                    
                    
                    //llenarTablaDeProductosFacturables(Convert.ToInt32(cmbSucursales.SelectedValue.ToString()), dtpFechaInicio.Value.Date, );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un problema al generar la factura : " + ex.Message, "Error al facturar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lista_conceptos_cfdi33.Clear();
                }

            }
        }

        private void cmbClientes_SelectedValueChanged(object sender, EventArgs e)
        {
            try { cliente.Id = Convert.ToInt32(cmbClientes.SelectedValue.ToString()); } catch (Exception ex) { cliente.Id = 0; }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void txtPagos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataTable filteredTable = FastFilterFacturas(txtPagos.Text);

                dgvFacturas.DataSource = filteredTable;
                dgvFacturas.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
                dgvFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvFacturas.AllowUserToAddRows = false;

                if (dgvFacturas.Rows.Count != 0)
                {
                    try { dgvFacturas.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                    try
                    {
                        dgvFacturas.Columns["NoContrato"].DefaultCellStyle.Format = "D10";
                        dgvFacturas.Columns["Folio"].DefaultCellStyle.Format = "D5";
                        dgvFacturas.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvFacturas.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
                        dgvFacturas.Columns["Subtotal"].Visible = false;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    try
                    {
                        dgvFacturas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvFacturas.Columns["Total"].DefaultCellStyle.Format = "N2";
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    try { dgvFacturas.Columns["ISR_Retencion"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                    try { dgvFacturas.Columns["IVA_Retencion"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                    try { dgvFacturas.Columns["IVA"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                    try { dgvFacturas.Columns["IEPS"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }

                    foreach (DataGridViewColumn c in dgvFacturas.Columns)
                    {
                        if (c.Name.Equals("Seleccionar"))
                            c.ReadOnly = false;
                        else
                            c.ReadOnly = true;
                    }
                }
                else
                {
                    dgvFacturas.DataSource = null;
                }
            }
        }
    }
}


