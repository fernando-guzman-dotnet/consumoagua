using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Clases;
using CrystalDecisions.Shared;
using Profact.TimbraCFDI;
using SAPA.Clases;
using SAPA.Clases.Facturacion;
using SAPA.Clases.CatalogosSAT;
using SAPA.Reportes.Facturacion;
using System.Net.Mail;
using System.Net.Mime;

namespace SAPA.Vistas
{
    public partial class FrmFacturasBuscar33 : Form
    {
        public FrmFacturasBuscar33(Boolean bandera, String TipoComprobante)
        {
            InitializeComponent();

            factura_abono = new FacturasAbonos();
            factura_cuenta = new FacturasCuentas();
            factura_timbrada = new Facturas();
            factura_detalle = new Facturas_Detalles();
            cliente = new Usuario();
            emisor = new Organismo();

            emisor.Id = 1;
            //_tblEmisor = emisor.EmisoresSelectById();

            //catalogo SAT
            cfdi = new Usos_CFDI();
            regimen_fiscal = new Regimen_Fiscal();
            metodoPago_SAT = new Metodos_Pago();
            formaPago_SAT = new Formas_Pago();
            clave_unidad = new Unidades();
            clave_prod_serv = new Claves_Prod_Serv();

            //Variables para facturar
            emisor_cfdi33 = new SAPAFacturacionCFDI33.Emisores();
            receptor_cfdi33 = new SAPAFacturacionCFDI33.Receptores();
            lista_conceptos_cfdi33 = new List<SAPAFacturacionCFDI33.Conceptos>();
            datosfactura = new SAPAFacturacionCFDI33.DatosFactura();
            factura = new SAPAFacturacionCFDI33.Facturacion();
            impuestos_cfdi33 = new SAPAFacturacionCFDI33.Impuestos();

            _tbl = Facturas.FacturasSelect();
            emisor.Id = 1;
            _tblEmisor = emisor.EmisoresSelectById(); // Luis: Lo comenté
            _tblClavesProdServ = Claves_Prod_Serv.ClavesProdServSelect();
            _tblClavesUnidad = Unidades.UnidadesSelect();
            _tblFormasPago = Formas_Pago.FormasPagoSATSelect();
            _tblMetodosPago = Metodos_Pago.MetodosPagoSATSelect();
            _tblMonedas = Monedas_SAT.MonedasSATSelect();
            _tblRegimenFiscal = Regimen_Fiscal.RegimeFiscalSelect();
            _tblUsoCFDI = Usos_CFDI.UsosCFDISelect();
            //_tblClavesSAT = p_sat.ProductosClavesSATSelect();

            //cmb formas de pago SAT
            cmbFormaPago.DataSource = _tblFormasPago;
            cmbFormaPago.ValueMember = "Clave_SAT";
            cmbFormaPago.DisplayMember = "Descripcion";

            cancelada = 1;

            Comprobante = TipoComprobante;
            toolStrip1.Visible = bandera;

            if (Convert.ToInt32(factura_timbrada.SelectAmbienteFacturacion().Rows[0]["AMBIENTE"].ToString()) == 1)
            {
                ban_ambiente = true;
                rfc_emisor = _tblEmisor.Rows[0]["RFC"].ToString();//"SER070503DG9";
            }
            else
            {
                ban_ambiente = false;
                rfc_emisor = "IVD920810GU2"; //"LAN7008173R5";
            }

            chkFacturas.Checked = true;
            llenarTabla(/*factura_timbrada.FacturasSelectVisorByMes(cancelada)*/);
        }
        String Comprobante { get; set; }
        Boolean ban_ambiente { get; set; }
        String rfc_emisor { get; set; }
        String Ruta { get; set; }
        int cancelada { get; set; }

        //facturas
        FacturasAbonos factura_abono { get; set; }
        FacturasCuentas factura_cuenta { get; set; }
        public Facturas factura_timbrada { get; set; }
        Facturas_Detalles factura_detalle { get; set; }
        Usuario cliente { get; set; }
        Organismo emisor { get; set; }

        //tablas para reporte
        DataTable Datos_Factura { get; set; }
        DataTable datos_Emisores { get; set; }
        DataTable datos_Receptores { get; set; }
        DataTable DatosCertificado { get; set; }
        DataTable Conceptosfactura { get; set; }

        //catalogos del sat
        Usos_CFDI cfdi { get; set; }
        Regimen_Fiscal regimen_fiscal { get; set; }
        Formas_Pago formaPago_SAT { get; set; }
        Metodos_Pago metodoPago_SAT { get; set; }
        Unidades clave_unidad { get; set; }
        Claves_Prod_Serv clave_prod_serv { get; set; }

        //Variables para facturacion
        SAPAFacturacionCFDI33.Emisores emisor_cfdi33 { get; set; }
        SAPAFacturacionCFDI33.Receptores receptor_cfdi33 { get; set; }
        SAPAFacturacionCFDI33.DatosFactura datosfactura { get; set; }
        SAPAFacturacionCFDI33.Facturacion factura { get; set; }
        SAPAFacturacionCFDI33.Impuestos impuestos_cfdi33 { get; set; }
        List<SAPAFacturacionCFDI33.Conceptos> lista_conceptos_cfdi33 { get; set; }
        ResultadoTimbre rt { get; set; }
        ResultadoConsulta rc { get; set; }
        ResultadoCancelacion rcn { get; set; }

        DataTable _tblEmisor { get; set; }

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
        Boolean ban_clave_sat_unidad { get; set; }
        Boolean ban_tipo_cambio { get; set; }
        Boolean ban_clave_sat_prod_serv { get; set; }
        int ban_recibo { get; set; }
        #endregion

        /*
            Luis: Lo comenté
            
        private int getFolioFacturaByVenta(int idventa)
        {
            int folio_factura = 0;
            
            DataTable dt = Clases.VentaDetalles.VentaDetallesSelectByIdVenta(idventa);

            if (dt.Rows.Count != 0)
                folio_factura = Convert.ToInt32(dt.Rows[0]["IdFactura"].ToString());

            return folio_factura;
        }
        */

        #region correo SENDGRID
        public MailMessage MensajeAvicola(String Correo, String ruta_pdf, String ruta_xml, String Correo_emisor, String nombre_emisor, int nofactura)
        {
            MailMessage mailMsg = new MailMessage();
            mailMsg.To.Add(new MailAddress(Correo, ""));
            mailMsg.From = new MailAddress(Correo_emisor, nombre_emisor);
            mailMsg.Subject = "Factura  " + nofactura;// + " " + DateTime.Now.ToString();
            string html = "Archivo de Factura CFDI " + DateTime.Now + @"
                          <p>
                             <br>
                             <!--Usted podrá encontrar sus facturas adjuntas a este correo.<br><br>
                             No responda a este mensaje, ya que procede de un buzón de correo desatendido. Si responde a este correo electrónico, el mensaje no se atenderá ni se 
                             reenviará. Este servicio se usa únicamente para mensajes de correo electrónico salientes y no para responder consultas.-->
                          </p>";
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            //xml cfdi
            string factura_xml = ruta_xml;
            Attachment data_xml = new Attachment(factura_xml, MediaTypeNames.Application.Octet);
            ContentDisposition disposition_xml = data_xml.ContentDisposition;
            disposition_xml.CreationDate = System.IO.File.GetCreationTime(factura_xml);
            disposition_xml.ModificationDate = System.IO.File.GetLastWriteTime(factura_xml);
            disposition_xml.ReadDate = System.IO.File.GetLastAccessTime(factura_xml);

            //pdf cfdi
            string factura_pdf = ruta_pdf;
            Attachment data_pdf = new Attachment(factura_pdf, MediaTypeNames.Application.Octet);
            ContentDisposition disposition_pdf = data_pdf.ContentDisposition;
            disposition_pdf.CreationDate = System.IO.File.GetCreationTime(factura_pdf);
            disposition_pdf.ModificationDate = System.IO.File.GetLastWriteTime(factura_pdf);
            disposition_pdf.ReadDate = System.IO.File.GetLastAccessTime(factura_pdf);

            mailMsg.Attachments.Add(data_xml);
            mailMsg.Attachments.Add(data_pdf);

            return mailMsg;
        }

        public void OtherWay(String correo, String ruta_pdf, String ruta_xml, String correo_emisor, String nombre_emisor, int nofactura)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));

                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("apikey", "YOUR_SENDGRID_API_KEY"); // Reemplazar con tu API key real
                smtpClient.Credentials = credentials;

                smtpClient.Credentials = credentials;
                smtpClient.Send(MensajeAvicola(correo, ruta_pdf, ruta_xml, correo_emisor, nombre_emisor, nofactura));

                if (correo.Equals("sapa.facturacion1@gmail.com") == false)
                {
                    msg_enviados = msg_enviados + correo + "\n";
                    cont_enviados++;
                }

            }
            catch (Exception ex)
            {
                if (correo.Equals("sapa.facturacion1@gmail.com") == false)
                {
                    msg_error = msg_error + correo + "\n";
                    cont_error++;
                }

            }

        }
        #endregion


        DataTable _tbl { get; set; }
        private void fastFilterFacturas()
        {
            int folio_factura = 0, numero_venta = 0, numero_factura = 0;
            try { folio_factura = Convert.ToInt32(txtFolio.Text); } catch (Exception ex) { folio_factura = 0; }
            try { numero_venta = Convert.ToInt32(txtVenta.Text); } catch (Exception ex) { numero_venta = 0; }

            // numero_factura = getFolioFacturaByVenta(numero_venta); // Luis: Lo comenté justo arriba también

            DataTable tbl = _tbl.Clone();
            IEnumerable<DataRow> imqRows = from DataRow rdvgrw in _tbl.Rows
                                           where
                                           (
                                             //filtro por cliente
                                             (
                                               rdvgrw["Cliente"].ToString().ToUpper().Contains(txtNombre.Text.ToUpper())
                                             ) 
                                             &&
                                             //filtro por fecha 
                                             (
                                               ChkFecha.Checked == false || (ChkFecha.Checked == true &&
                                               Convert.ToDateTime(rdvgrw["Fecha"].ToString()) >=  dtpFechaInicio.Value.Date &&
                                               Convert.ToDateTime(rdvgrw["Fecha"].ToString()) <= dtpFechaFin.Value.Date.AddHours(23).AddMinutes(59))
                                             ) 
                                             &&
                                             //filtro por folio
                                             (
                                               chkFolio.Checked == false || 
                                               (chkFolio.Checked == true && Convert.ToInt32(rdvgrw["No. Factura"].ToString()) == folio_factura)
                                             )
                                             &&
                                             //filtro por numero de venta
                                             (
                                               chkVenta.Checked == false || (chkVenta.Checked == true && Convert.ToInt32(rdvgrw["Folio"].ToString()) == numero_factura)
                                             )
                                             &&
                                             //filtro por forma de pago
                                             (
                                               chkFormaPago.Checked == false || 
                                               (chkFormaPago.Checked == true && rdvgrw["FormaPago"].ToString() == cmbFormaPago.SelectedValue.ToString())
                                             )
                                             &&
                                             //filtro por tipo de comprobante
                                             (
                                               !Comprobante.Equals("P Pago") || (Comprobante.Equals("P Pago") && Convert.ToDecimal(rdvgrw["Saldo"].ToString()) != 0)
                                             )
                                             &&
                                             //filtrar canceladas
                                             (
                                              chkCanceladas.Checked == false || (chkCanceladas.Checked == true && Convert.ToBoolean(rdvgrw["Cancelada"].ToString()) == true)
                                             )
                                           )
                                           select rdvgrw;
            foreach (DataRow d in imqRows)
            {
                tbl.Rows.Add(d.ItemArray);
            }

            dgvFacturas.DataSource = tbl;
            formatoDataGrid();

            //return tbl;
        }

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
        private DataTable fastFilterFormaPago(string clave)  
        {
            DataTable tbl = _tblFormasPago.Clone();
            IEnumerable<DataRow> imqRows = from DataRow rdvgrw in _tblFormasPago.Rows
                                           where
                                           (
                                             rdvgrw["clave_SAT"].ToString() == clave
                                           )
                                           select rdvgrw;
            foreach (DataRow d in imqRows)
            {
                tbl.Rows.Add(d.ItemArray);
            }

            return tbl;
        }

        DataTable _tblMetodosPago { get; set; }
        private DataTable fastFilterMetodoPago(string clave)  
        {
            DataTable tbl = _tblMetodosPago.Clone();
            IEnumerable<DataRow> imqRows = from DataRow rdvgrw in _tblMetodosPago.Rows
                                           where
                                           (
                                             rdvgrw["clave_SAT"].ToString() == clave
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
        public FrmPrincipal FrmPrincipal { get; set; }

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

        private String getNombreImpuesto(string clave)  
        {
            if (clave.Equals("001"))
            {
                return "ISR";
            }
            else
            {
                if (clave.Equals("002"))
                {
                    return "IVA";
                }
                else
                {
                    if (clave.Equals("003"))
                    {
                        return "IEPS";
                    }
                    else
                    {
                        return "000";
                    }
                }
            }
        }

        private String ValidarCancelada(String CFDI)  
        {
            try
            {
                if (CFDI.Equals("") || CFDI.Equals(null))
                {
                    return "CANCELADA";
                }
                else
                {
                    return CFDI;
                }
            }
            catch
            {
                return "CANCELADA";
            }

        }

        private void formatoDataGrid()
        {
            dgvFacturas.DefaultCellStyle.Font = new Font("Microsoft Sans Serif",8,FontStyle.Regular);
            dgvFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif",8,FontStyle.Bold);
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.ReadOnly = true;

            if (dgvFacturas.Rows.Count != 0)
            {
                try { dgvFacturas.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["Folio"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["Referencia"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["Ret_ISR"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["Ret_IVA"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["IEPS"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["IdUsuario"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["UUID"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["TipoPago"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["FormaPago"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["IVA"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["IdEmisor"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["Saldo"].Visible = false; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try { dgvFacturas.Columns["TipoComprobante"].HeaderText = "Tipo de Comprobante"; } catch (Exception ex) { MessageBox.Show(ex.Message); }
                try
                {
                    dgvFacturas.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
                    dgvFacturas.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                try
                {
                    dgvFacturas.Columns["Total"].DefaultCellStyle.Format = "N2";
                    dgvFacturas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                } catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                dgvFacturas.DataSource = null;
            }
        }

        //llenar datagrid
        private void llenarTabla()
        {
            fastFilterFacturas();

            //dgvFacturas.Rows.Clear();
            //dgvFacturas.Columns.Clear();

            ////0.-  Folio
            //dgvFacturas.Columns.Add("Folio", "Folio");
            //dgvFacturas.Columns["Folio"].Visible = false;
            ////1.-  No. Factura
            //dgvFacturas.Columns.Add("No. Factura", "No. Factura");
            ////2.-  Fecha
            //dgvFacturas.Columns.Add("Fecha", "Fecha");
            ////3.-  RFC
            //dgvFacturas.Columns.Add("RFC", "RFC");
            ////4.-  Cliente
            //dgvFacturas.Columns.Add("Cliente", "Cliente");
            ////5.-  Metodo de Pago
            //dgvFacturas.Columns.Add("Metodo de Pago", "Forma de Pago");
            ////6.-  Forma de Pago
            //dgvFacturas.Columns.Add("Forma de Pago", "Metodo de Pago");
            ////7.-  Referencia
            //dgvFacturas.Columns.Add("Referencia", "Referencia");
            ////8.-  SubTotal
            //dgvFacturas.Columns.Add("SubTotal", "SubTotal");
            //dgvFacturas.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
            //dgvFacturas.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ////9.-  Total
            //dgvFacturas.Columns.Add("Total", "Total");
            //dgvFacturas.Columns["Total"].DefaultCellStyle.Format = "N2";
            //dgvFacturas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ////10.- Cancelada
            //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            //chk.Name = "Cancelada";
            //chk.HeaderText = "Cancelada";
            //dgvFacturas.Columns.Add(chk);
            ////11.-  Ret_ISR
            //dgvFacturas.Columns.Add("Ret_ISR", "Ret_ISR");
            //dgvFacturas.Columns["Ret_ISR"].Visible = false;
            ////12.- Ret_IVA
            //dgvFacturas.Columns.Add("Ret_IVA", "Ret_IVA");
            //dgvFacturas.Columns["Ret_IVA"].Visible = false;
            ////13.- IEPS
            //dgvFacturas.Columns.Add("IEPS", "IEPS");
            //dgvFacturas.Columns["IEPS"].Visible = false;
            ////14.- IdUsuario
            //dgvFacturas.Columns.Add("IdUsuario", "IdUsuario");
            //dgvFacturas.Columns["IdUSuario"].Visible = false;
            ////15.- UUID
            //dgvFacturas.Columns.Add("UUID", "UUID");
            //dgvFacturas.Columns["UUID"].Visible = false;
            ////16.- TipoPago
            //dgvFacturas.Columns.Add("TipoPago", "TipoPago");
            //dgvFacturas.Columns["TipoPago"].Visible = false;
            ////17.- FormaPago
            //dgvFacturas.Columns.Add("FormaPago", "FormaPago");
            //dgvFacturas.Columns["FormaPago"].Visible = false;
            ////18.- IVA
            //dgvFacturas.Columns.Add("IVA", "IVA");
            //dgvFacturas.Columns["IVA"].Visible = false;
            ////19.- IdEmisor
            //dgvFacturas.Columns.Add("IdEmisor", "IdEmisor");
            //dgvFacturas.Columns["IdEmisor"].Visible = false;
            ////20.- TipoComprobante
            //dgvFacturas.Columns.Add("TipoComprobante", "Tipo de Comprobante");
            ////21.- Saldo de la factura
            //dgvFacturas.Columns.Add("Saldo", "Saldo");
            //dgvFacturas.Columns["Saldo"].Visible = false;

            //dgvFacturas.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            //dgvFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            //dgvFacturas.ReadOnly = true;

            //foreach (DataRow r in dt.Rows)
            //{
            //    //llenar grid con facturas pagadas en parcialidades
            //    if (Comprobante.Equals("P Pago"))
            //    {
            //        if (/*r["metodo_PAGO"].ToString() != "PUE" &&*/ Decimal.Parse(r["Restante"].ToString()) != 0)
            //        {
            //            dgvFacturas.Rows.Add(
            //                int.Parse(r["Folio"].ToString()),                         //0.-  IdFactura
            //                int.Parse(r["Folio_Factura"].ToString()),                 //1.-  Folio Interno   
            //                Convert.ToDateTime(r["Fecha"].ToString()),                //2.-  Fecha
            //                rfc_emisor,/*r["RFC"].ToString(),*/                       //3.-  RFC
            //                r["Cliente"].ToString(),                                  //4.-  Cliente
            //                r["Forma de Pago"].ToString(),                            //5.-  Forma de Pago
            //                r["Metodo de Pago"],                                      //6.-  Metodo de Pago
            //                r["Referencia"].ToString(),                               //7.-  Referencia
            //                Decimal.Parse(r["Subtotal"].ToString()),                  //8.-  Subtotal
            //                Decimal.Parse(r["Total"].ToString()),                     //9.-  Total
            //                ObtenerCancelada(int.Parse(r["estatus"].ToString())),     //10.-  Estatus
            //                Decimal.Parse(r["ret_ISR"].ToString()),                   //11.- Retencion ISR
            //                Decimal.Parse(r["ret_IVA"].ToString()),                   //12.- Retencion IVA
            //                Decimal.Parse(r["IEPS"].ToString()),                      //13.- IEPS
            //                                                                          /*int.Parse(r["IdUsuario"].ToString()),*/1,               //14.- IdUsuario
            //                r["FOLIO_UUID"].ToString(),                               //15.- FolioUUID
            //                r["Metodo_Pago"].ToString(),//int.Parse(),                //16.- TipoPago
            //                r["Forma_Pago"].ToString(),//int.Parse(),                 //17.- FormaPago
            //                Decimal.Parse(r["IVA"].ToString()),                       //18.- IVA
            //                                                                          /*int.Parse(r["IdEmisor"].ToString())*/1,                 //19.- IdEmisor
            //                r["Tipo_Comprobante"].ToString(),                         //20.- Tipo Comprobante
            //                Decimal.Parse(r["Restante"].ToString())                   //21.- Restante
            //            );
            //        }
            //    }
            //    else
            //    {
            //        Decimal total_ = 0;
            //        Decimal subtotal_ = 0;
            //        if (r["Tipo_Comprobante"].Equals("P Pago") == false)
            //        {
            //            total_ = Decimal.Parse(r["Total"].ToString());
            //            subtotal_ = Decimal.Parse(r["Subtotal"].ToString());
            //        }

            //        dgvFacturas.Rows.Add(
            //            int.Parse(r["Folio"].ToString()),                         //0.-  IdFactura
            //            int.Parse(r["Folio_Factura"].ToString()),                 //1.-  Folio Interno   
            //            Convert.ToDateTime(r["Fecha"].ToString()),                //2.-  Fecha
            //            rfc_emisor,/*r["RFC"].ToString(),*/                       //3.-  RFC
            //            r["Cliente"].ToString(),                                  //4.-  Cliente
            //            r["Forma de Pago"].ToString(),                            //5.-  Forma de Pago
            //            r["Metodo de Pago"],                                      //6.-  Metodo de Pago
            //            r["Referencia"].ToString(),                               //7.-  Referencia
            //            subtotal_,                                                //8.-  Subtotal
            //            total_,                                                   //9.-  Total
            //            ObtenerCancelada(int.Parse(r["estatus"].ToString())),     //10.-  Estatus
            //            Decimal.Parse(r["ret_ISR"].ToString()),                   //11.- Retencion ISR
            //            Decimal.Parse(r["ret_IVA"].ToString()),                   //12.- Retencion IVA
            //            Decimal.Parse(r["IEPS"].ToString()),                      //13.- IEPS
            //                                                                      /*int.Parse(r["IdUsuario"].ToString()),*/1,               //14.- IdUsuario
            //            r["FOLIO_UUID"].ToString(),                               //15.- FolioUUID
            //            r["Metodo_Pago"].ToString(),//int.Parse(),                //16.- TipoPago
            //            r["Forma_Pago"].ToString(),//int.Parse(),                 //17.- FormaPago
            //            Decimal.Parse(r["IVA"].ToString()),                       //18.- IVA
            //                                                                      /*int.Parse(r["IdEmisor"].ToString())*/1,                 //19.- IdEmisor
            //            r["Tipo_Comprobante"].ToString(),                         //20.- Tipo Comprobante
            //            Decimal.Parse(r["Restante"].ToString())                   //21.- Saldo
            //        );
            //    }
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verFactura(int timbrado)
        {
            //validar fila seleccionada
            if (dgvFacturas.Rows.Count == 0)
            {
                MessageBox.Show("Selecciona una factura para ver sus detalles.", "Fila sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //vista previa
            else
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    factura_timbrada.Id = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["Folio"].Value.ToString());
                    factura_timbrada = factura_timbrada.FacturasSelectById().Rows[0];
                    //factura_timbrada.FolioUUID = dgvFacturas.SelectedRows[0].Cells["UUID"].Value.ToString();
                    /*------------------------------------------------DATOS DEL EMISOR------------------------------------------------------------------*/
                    //emisor.Id = int.Parse(/*u.SelectUsuariosPorId(1).Rows[0]["IdEmisor"].ToString()*/dgvFacturas.SelectedRows[0].Cells["IdEmisor"].Value.ToString());

                    lista_conceptos_cfdi33.Clear();

                    /*--------------------------------------------------------DATOS DEL EMISOR------------------------------------------------------*/
                    Organismo emisor = new Organismo();
                    emisor.Id = 1;
                    DataTable dt_emisor = emisor.EmisoresSelectById();

                    //emisor_cfdi33.Nombre = dt_emisor.Rows[0]["NOMBRE"].ToString();//"SERVIENVASES S DE RL MI";
                    //emisor_cfdi33.RFC = rfc_emisor;//"LAN7008173R5";//"SER070503DG9";
                    //emisor_cfdi33.RazonSocial = dt_emisor.Rows[0]["RAZONSOCIAL"].ToString();//"SERVIENVASES S DE RL MI";
                    //emisor_cfdi33.Calle = dt_emisor.Rows[0]["CALLE"].ToString();//"LEONARDO CASTELLANOS";
                    //emisor_cfdi33.NoExterior = dt_emisor.Rows[0]["NOEXTERIOR"].ToString();//"198";
                    //emisor_cfdi33.NoInterior = dt_emisor.Rows[0]["NOINTERIOR"].ToString();//"A";
                    //emisor_cfdi33.Colonia = dt_emisor.Rows[0]["COLONIA"].ToString();//"CENTRO";
                    //emisor_cfdi33.Municipio = dt_emisor.Rows[0]["MUNICIPIO"].ToString();//"Zamora";
                    //emisor_cfdi33.Estado = dt_emisor.Rows[0]["ESTADO"].ToString();//"MICHOACAN";
                    //emisor_cfdi33.CP = dt_emisor.Rows[0]["CP"].ToString();//"59600";
                    //emisor_cfdi33.Pais = dt_emisor.Rows[0]["PAIS"].ToString();//"México";
                    //emisor_cfdi33.Telefono = dt_emisor.Rows[0]["TELEFONO"].ToString();//"01 (351) 512 3741";
                    //emisor_cfdi33.Regimen_Fiscal = dt_emisor.Rows[0]["REGIMEN_FISCAL"].ToString();//"601";

                    emisor_cfdi33 = dt_emisor.Rows[0];
                    if (ban_ambiente == false)
                        emisor_cfdi33.RFC = "IVD920810GU2";
                    /*------------------------------------------------------------------------------------------------------------------------------*/


                    /*------------------------------------------------DATOS DEL RECEPTOR----------------------------------------------------------------*/
                    cliente.Id = factura_timbrada.IdCliente; //int.Parse(ft.FacturasSelectById().Rows[0]["IdCliente"].ToString());

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
                    //receptor_cfdi33.Telefono = cliente_id.Rows[0]["TELEFONO"].ToString();
                    
                    receptor_cfdi33 = cliente_id.Rows[0];
                    /*----------------------------------------------------------------------------------------------------------------------------------*/


                    /*------------------------------------------------DATOS DE LA FACTURA---------------------------------------------------------------*/
                    formaPago_SAT = fastFilterFormaPago(factura_timbrada.FormaPago).Rows[0];
                    metodoPago_SAT = fastFilterMetodoPago(factura_timbrada.MetodoPago).Rows[0];

                    datosfactura.Folio = factura_timbrada.Folio_Factura.ToString();
                    datosfactura.Fecha = DateTime.Now;
                    datosfactura.FormaPago = formaPago_SAT.Clave_SAT;
                    datosfactura.ban_FormaPago = true;
                    datosfactura.MetodoPago = metodoPago_SAT.Clave_SAT;
                    datosfactura.ban_MetodoPago = true;
                    datosfactura.Tipo_Comprobante_ = "I";
                    datosfactura.ban_Descuento = false;
                    datosfactura.SubTotal = factura_timbrada.SubTotal;
                    datosfactura.Total = factura_timbrada.Total;
                    datosfactura.LugarExpedicion = emisor_cfdi33.CP;
                    datosfactura.Moneda = "MXN";
                    datosfactura.Tipo_Comprobante = 1;
                    datosfactura.Uso_CFDI = factura_timbrada.Uso_CFDI;

                    cfdi = fastFilterUsoCFDI(datosfactura.Uso_CFDI).Rows[0];

                    if (dgvFacturas.SelectedRows[0].Cells["TipoComprobante"].Value.Equals("P Pago"))
                    {
                        datosfactura.Moneda = "(XXX) Sin Divisa";
                    }
                    else
                    {
                        datosfactura.Moneda = "(MXN) Peso Mexicano";
                    }
                    /*----------------------------------------------------------------------------------------------------------------------------------*/


                    /*------------------------------------------------CONCEPTOS DE LA FACTURA-----------------------------------------------------------*/
                    Decimal TotalFactura = 0;
                    Decimal SubTotalFactura = 0;
                    Decimal Dif = 0;

                    factura_detalle.IdFactura = factura_timbrada.Id;
                    DataTable dt = factura_detalle.SelectFacturaDetallesIDFactura();

                    foreach (DataRow r in dt.Rows)
                    {
                        SAPAFacturacionCFDI33.Conceptos concepto_cfdi33 = new SAPAFacturacionCFDI33.Conceptos();
                        concepto_cfdi33.Cantidad = Convert.ToDecimal(r["CANTIDAD"].ToString());
                        concepto_cfdi33.NoIdentificacion = r["CODIGO"].ToString();
                        concepto_cfdi33.Clave_Unidad = r["CLAVE_UNIDAD"].ToString();//"H87";
                        concepto_cfdi33.Clave_Producto_Servicio = r["CLAVE_PROD_SERV"].ToString();//"01010101";
                        concepto_cfdi33.Unidad = r["UNIDAD"].ToString();
                        concepto_cfdi33.Descripcion = r["DESCRIPCION"].ToString();
                        concepto_cfdi33.PrecioUnitario = Convert.ToDecimal(r["PRECIO_UNITARIO"].ToString());
                        concepto_cfdi33.Importe = Convert.ToDecimal(r["IMPORTE"].ToString());

                        try
                        {
                            clave_prod_serv = fastFilterClavesProdServ(concepto_cfdi33.Clave_Producto_Servicio).Rows[0];
                        }
                        catch (Exception ex) { /*ban_clave_sat_prod_serv = false;*/ }

                        try
                        {
                            clave_unidad = fastFilterClavesUnidades(concepto_cfdi33.Clave_Unidad).Rows[0];
                        }
                        catch (Exception ex) { /*ban_clave_sat_unidad = false;*/ }

                        concepto_cfdi33.Descripcion_SAT_Prod_Serv = clave_prod_serv.Descripcion;
                        concepto_cfdi33.Descripcion_SAT_Unidad = clave_unidad.Descripcion;

                        //iva
                        concepto_cfdi33.trasladados_IVA = new SAPAFacturacionCFDI33.Conceptos_Impuestos_Trasladados();
                        concepto_cfdi33.trasladados_IVA.impuesto_base = 0;
                        concepto_cfdi33.trasladados_IVA.tipo_impuesto = "002";
                        concepto_cfdi33.trasladados_IVA.tipo_factor = "Tasa";
                        concepto_cfdi33.trasladados_IVA.importe_impuesto = 0;
                        concepto_cfdi33.trasladados_IVA.ban_importe_impuesto = true;
                        concepto_cfdi33.trasladados_IVA.tasa_o_cuota = "0.000000";
                        concepto_cfdi33.trasladados_IVA.ban_tasa_o_cuota = true;

                        //ieps
                        concepto_cfdi33.trasladados_IEPS = new SAPAFacturacionCFDI33.Conceptos_Impuestos_Trasladados();
                        concepto_cfdi33.trasladados_IEPS.impuesto_base = 0;
                        concepto_cfdi33.trasladados_IEPS.tipo_impuesto = "003";
                        concepto_cfdi33.trasladados_IEPS.tipo_factor = "Tasa";
                        concepto_cfdi33.trasladados_IEPS.importe_impuesto = 0;
                        concepto_cfdi33.trasladados_IEPS.ban_importe_impuesto = true;
                        concepto_cfdi33.trasladados_IEPS.tasa_o_cuota = "0.000000";                                                                                                              //PorcentajeIEPSPorProducto(con.trasladados_IEPS.impuesto_base, ObtenerIEPS()));
                        concepto_cfdi33.trasladados_IEPS.ban_tasa_o_cuota = true;

                        //ret. isr
                        concepto_cfdi33.retenciones_ISR = new SAPAFacturacionCFDI33.Conceptos_Impuestos_Retenciones();
                        concepto_cfdi33.retenciones_ISR.impuesto_base = 0;
                        concepto_cfdi33.retenciones_ISR.tipo_impuesto = "001";
                        concepto_cfdi33.retenciones_ISR.tipo_factor = "Tasa";
                        concepto_cfdi33.retenciones_ISR.importe_impuesto = 0;
                        concepto_cfdi33.retenciones_ISR.ban_importe_impuesto = true;
                        concepto_cfdi33.retenciones_ISR.tasa_o_cuota = "0.000000";
                        concepto_cfdi33.retenciones_ISR.ban_tasa_o_cuota = true;

                        //ret. iva
                        concepto_cfdi33.retenciones_IVA = new SAPAFacturacionCFDI33.Conceptos_Impuestos_Retenciones();
                        concepto_cfdi33.retenciones_IVA.impuesto_base = 0;
                        concepto_cfdi33.retenciones_IVA.tipo_impuesto = "002";
                        concepto_cfdi33.retenciones_IVA.tipo_factor = "Tasa";
                        concepto_cfdi33.retenciones_IVA.importe_impuesto = 0;
                        concepto_cfdi33.retenciones_IVA.ban_importe_impuesto = true;
                        concepto_cfdi33.retenciones_IVA.tasa_o_cuota = "0.000000";
                        concepto_cfdi33.retenciones_IVA.ban_tasa_o_cuota = true;

                        lista_conceptos_cfdi33.Add(concepto_cfdi33);
                        //SubTotalFactura = SubTotalFactura + con.Importe;
                        //TotalFactura = TotalFactura + (Decimal.Parse(r["IMPORTE"].ToString()));
                    }
                    /*----------------------------------------------------------------------------------------------------------------------------------*/

                    /*-----------------------------------------------------------IMPUESTOS--------------------------------------------------------------*/
                    impuestos_cfdi33.TipoFactor = "Tasa";
                    impuestos_cfdi33.IVA = factura_timbrada.IVA;
                    impuestos_cfdi33.IVA_TasaOCuota = "0.160000";
                    impuestos_cfdi33.IEPS = factura_timbrada.IEPS;
                    impuestos_cfdi33.IEPS_TasaOCuota = 0.ToString("N6");
                    impuestos_cfdi33.RetIVA = factura_timbrada.Ret_IVA;
                    impuestos_cfdi33.RetISR = factura_timbrada.Ret_ISR;
                    impuestos_cfdi33.PorcentajeIEPS = 0;
                    impuestos_cfdi33.ban_ImpuestosRetenidos = true;
                    impuestos_cfdi33.ban_ImpuestosTrasladados = true;
                    /*----------------------------------------------------------------------------------------------------------------------------------*/

                    /*------------------------------------------------TABLA EMISORES PARA REPORTE-------------------------------------------------------*/
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

                    try
                    {
                        //byte[] arg = (byte[])emisor.SelectEmisoresPorID().Rows[0]["LOGO"];
                        //System.IO.MemoryStream ms = new System.IO.MemoryStream(arg);
                        filaE[12] = null;// arg;
                    }
                    catch (Exception ex) { }
                    datos_Emisores.Rows.Add(filaE);
                    /*----------------------------------------------------------------------------------------------------------------------------------*/


                    /*------------------------------------------------TABLA RECEPTORES PARA REPORTE-----------------------------------------------------*/
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
                    /*----------------------------------------------------------------------------------------------------------------------------------*/


                    /*------------------------------------------------TABLA DATOS DE FACTURA PARA REPORTE-----------------------------------------------*/
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
                    /*----------------------------------------------------------------------------------------------------------------------------------*/


                    /*------------------------------------------------TABLA CONCEPTOS PARA REPORTE------------------------------------------------------*/
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

                    foreach (SAPAFacturacionCFDI33.Conceptos con in lista_conceptos_cfdi33)
                    {
                        DataRow filaCF = Conceptosfactura.NewRow();
                        filaCF[0] = con.Cantidad;
                        filaCF[1] = con.Unidad;
                        filaCF[2] = con.Descripcion;
                        filaCF[3] = con.PrecioUnitario;
                        filaCF[4] = con.Importe;
                        filaCF[5] = con.Clave_Producto_Servicio;
                        filaCF[6] = con.Clave_Unidad;
                        filaCF[7] = con.NoIdentificacion;
                        filaCF[8] = con.Descripcion_SAT_Prod_Serv;
                        filaCF[9] = con.Descripcion_SAT_Unidad;
                        filaCF[10] = con.descuento;
                        filaCF[11] = con.trasladados_IVA.impuesto_base;
                        filaCF[12] = getNombreImpuesto(con.trasladados_IVA.tipo_impuesto);
                        filaCF[13] = con.trasladados_IVA.tipo_factor;
                        filaCF[14] = con.trasladados_IVA.tasa_o_cuota;
                        filaCF[15] = con.trasladados_IVA.importe_impuesto;
                        filaCF[16] = con.trasladados_IEPS.impuesto_base;
                        filaCF[17] = getNombreImpuesto(con.trasladados_IEPS.tipo_impuesto);
                        filaCF[18] = con.trasladados_IEPS.tipo_factor;
                        filaCF[19] = con.trasladados_IEPS.tasa_o_cuota;
                        filaCF[20] = con.trasladados_IEPS.importe_impuesto;
                        filaCF[21] = con.retenciones_IVA.impuesto_base;
                        filaCF[22] = getNombreImpuesto(con.retenciones_IVA.tipo_impuesto);
                        filaCF[23] = con.retenciones_IVA.tipo_factor;
                        filaCF[24] = con.retenciones_IVA.tasa_o_cuota;
                        filaCF[25] = con.retenciones_IVA.importe_impuesto;
                        filaCF[26] = con.retenciones_ISR.impuesto_base;
                        filaCF[27] = getNombreImpuesto(con.retenciones_ISR.tipo_impuesto);
                        filaCF[28] = con.retenciones_ISR.tipo_factor;
                        filaCF[29] = con.retenciones_ISR.tasa_o_cuota;
                        filaCF[30] = con.retenciones_ISR.importe_impuesto;
                        Conceptosfactura.Rows.Add(filaCF);
                    }
                    /*----------------------------------------------------------------------------------------------------------------------------------*/

                    /*------------------------------------------------TABLA CERTIFICADO PARA REPORTE----------------------------------------------------*/
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

                    rc = factura.ConsultarFactura(ban_ambiente, rfc_emisor, factura_timbrada.FolioUUID, receptor_cfdi33.Nombre);
                    DataRow filaDC = DatosCertificado.NewRow();

                    DataTable CFDI_XML = new DataTable();
                    DataTable Comprobante_XML = new DataTable();

                    try
                    {
                        DataSet ds_XML = new DataSet();
                        ds_XML.ReadXml("C:\\Facturas\\" + receptor_cfdi33.Nombre + "\\" + factura_timbrada.FolioUUID + "\\" + factura_timbrada.FolioUUID + ".xml");
                        CFDI_XML = ds_XML.Tables["TimbreFiscalDigital"];
                        Comprobante_XML = ds_XML.Tables["Comprobante"];
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Ocurrió un error al cargar el archivo XML de la factura.", "Erro al cargar los datos",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    filaDC[0] = factura_timbrada.FolioUUID;//ValidarCancelada(rc.FolioUUID);
                    //No_Certificado
                    try
                    {
                        filaDC[1] = ValidarCancelada(Comprobante_XML.Rows[0]["NoCertificado"].ToString()/*rc.No_Certificado*/);
                    }
                    catch
                    {
                        filaDC[1] = ValidarCancelada(rc.No_Certificado);
                    }
                    //No_Certificado_SAT
                    try
                    {
                        filaDC[2] = ValidarCancelada(CFDI_XML.Rows[0]["NoCertificadoSAT"].ToString()/*rc.No_Certificado_SAT*/);
                    }
                    catch
                    {
                        filaDC[2] = ValidarCancelada(rc.No_Certificado_SAT);
                    }
                    //FechaCertificacion
                    try
                    {
                        filaDC[3] = ValidarCancelada(CFDI_XML.Rows[0]["FechaTimbrado"].ToString()/*rc.FechaCertificacion*/);
                    }
                    catch
                    {
                        filaDC[3] = ValidarCancelada(rc.FechaCertificacion);
                    }
                    //SelloCFDI
                    try
                    {
                        filaDC[4] = ValidarCancelada(Comprobante_XML.Rows[0]["Sello"].ToString()/*rc.SelloCFDI*/);
                    }
                    catch
                    {
                        filaDC[4] = ValidarCancelada(rc.SelloCFDI);
                    }
                    //SelloSAT
                    try
                    {
                        filaDC[5] = ValidarCancelada(CFDI_XML.Rows[0]["SelloSAT"].ToString()/*rc.SelloSAT*/);
                    }
                    catch
                    {
                        filaDC[5] = ValidarCancelada(rc.SelloSAT);
                    }
                    filaDC[6] = ValidarCancelada(/*Comprobante_XML.Rows[0]["Certificado"].ToString()*/rc.CadenaTimbre);
                    filaDC[7] = rc.CodigoBidimensional;


                    DatosCertificado.Rows.Add(filaDC);
                    /*----------------------------------------------------------------------------------------------------------------------------------*/


                    /*------------------------------------------------TABLA COMPLEMENTO DE PAGOS--------------------------------------------------------*/
                    FacturasPagos pago = new FacturasPagos();
                    FacturasPagosDetalles pago_detalles = new FacturasPagosDetalles();
                    Monedas_SAT moneda = new Monedas_SAT();
                    Formas_Pago forma_pago = new Formas_Pago();

                    pago.IdFactura = factura_timbrada.Id;

                    DataTable complemento_PA = pago.Complemento_PA_SelectByIdFactura();
                    complemento_PA.TableName = "RptComplemento_PA";

                    DataTable complemento_PA2 = pago.Complemento_PA_SelectByIdFactura();
                    complemento_PA2.TableName = "RptComplemento_PA";

                    try
                    {
                        moneda.Clave_SAT = complemento_PA.Rows[0]["MONEDA"].ToString();
                        moneda.Descripcion = "(" + moneda.Clave_SAT + ") " + moneda.MonedasSATSelectByClave().Rows[0]["DESCRIPCION"].ToString();

                        forma_pago.Clave_SAT = complemento_PA.Rows[0]["FORMAPAGO"].ToString();
                        forma_pago.Descripcion = "(" + forma_pago.Clave_SAT + ") " + forma_pago.FormasPagoSATSelectByClaveSAT().Rows[0]["DESCRIPCION"].ToString();

                        pago.Id = int.Parse(complemento_PA.Rows[0]["ID"].ToString());
                        pago.MonedaP = moneda.Descripcion;
                        pago.FormaPagoP = forma_pago.Descripcion;
                    }
                    catch (Exception ex)
                    {
                        pago.Id = 0;
                        pago.MonedaP = "";
                        pago.FormaPagoP = "";
                    }

                    pago_detalles.IdComplemento = pago.Id;

                    DataTable DatosComplementoPA = pago_detalles.Complemento_PA_Detalles_SelectByIdComplemento();
                    DatosComplementoPA.TableName = "RptComplemento_PA_Detalles";

                    DataTable DatosComplementoPA2 = pago_detalles.Complemento_PA_Detalles_SelectByIdComplemento();
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


                    /*----------------------------------------------------PARAMETROS PARA REPORTE-------------------------------------------------------*/
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
                    rpt.SetParameterValue("Comentarios", factura_timbrada.Comentarios);
                    rpt.SetParameterValue("Referencia", factura_timbrada.Referencia/*dgvFacturas.SelectedRows[0].Cells["Referencia"].Value.ToString()*/);
                    rpt.SetParameterValue("ImporteLetra", ImporteLetra.enletras(datosfactura.Total.ToString()));
                    rpt.SetParameterValue("IVA", factura_timbrada.IVA);
                    rpt.SetParameterValue("IEPS_Producto", factura_timbrada.IEPS);
                    rpt.SetParameterValue("Ret_ISR_Producto", factura_timbrada.Ret_ISR);
                    rpt.SetParameterValue("Ret_IVA_Producto", factura_timbrada.Ret_IVA);
                    rpt.SetParameterValue("Subtotal_Producto", datosfactura.SubTotal);
                    rpt.SetParameterValue("NoFactura", factura_timbrada.Folio_Factura.ToString()/*dgvFacturas.SelectedRows[0].Cells["No. Factura"].Value.ToString()*/);
                    rpt.SetParameterValue("Razon_social", emisor_cfdi33.RazonSocial);
                    rpt.SetParameterValue("Fecha_Emision", datosfactura.Fecha);
                    rpt.SetParameterValue("Hora_emision", datosfactura.Fecha);
                    rpt.SetParameterValue("Regimen_Fiscal_Descripcion", "(" + regimen_fiscal.Clave_SAT+ ") " + regimen_fiscal.Descripcion);
                    rpt.SetParameterValue("FormaPago", formaPago_SAT.Descripcion/*dgvFacturas.SelectedRows[0].Cells["Metodo de Pago"].Value.ToString()*/);
                    rpt.SetParameterValue("MetodoPago", metodoPago_SAT.Descripcion/*dgvFacturas.SelectedRows[0].Cells["Forma de Pago"].Value.ToString()*/);
                    rpt.SetParameterValue("Razon_social_cliente", receptor_cfdi33.Nombre);
                    rpt.SetParameterValue("Descuento", 0/*Decimal.Parse(ft.SelectFacturasID().Rows[0]["DESCUENTO"].ToString())*/);
                    rpt.SetParameterValue("ISH", 0);
                    rpt.SetParameterValue("filas", DatosComplementoPA.Rows.Count);
                    rpt.SetParameterValue("Moneda_Descripcion", pago.MonedaP);
                    rpt.SetParameterValue("FormaPago_Descripcion", pago.FormaPagoP);

                    if (rc.Exitoso)
                    {
                        //crear pdf de la factura
                        Ruta = "C:\\Facturas\\" + receptor_cfdi33.Nombre + "\\" + factura_timbrada.FolioUUID + "\\";
                        if (!Directory.Exists(Ruta)) Directory.CreateDirectory(Ruta);
                        rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta + factura_timbrada.FolioUUID + ".pdf");
                    }

                    //VER FACTURA
                    if(timbrado == 1)
                    {
                        Cursor = Cursors.Arrow;
                        FrmVistaRpt frm = new FrmVistaRpt(rpt);
                        frm.ShowDialog();
                    }
                    //MANDAR CORREO
                    else if(timbrado == 2)
                    {
                        Cursor = Cursors.Arrow;
                        FrmFacturasReenviarEmail frm = new FrmFacturasReenviarEmail(receptor_cfdi33, rpt, factura_timbrada);
                        frm.ShowDialog();
                    }
                    //ABRIR CARPETA
                    else if(timbrado == 3)
                    {
                        Cursor = Cursors.Arrow;
                        try
                        {
                            Process.Start(/*@"C:\\Facturas"+*/Ruta);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    
                    lista_conceptos_cfdi33.Clear();
                    ds.Clear();
                    rpt.SetDataSource(ds);
                    /*----------------------------------------------------------------------------------------------------------------------------------*/

                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Arrow;
                    MessageBox.Show("No se pudo generar la vista de la factura: \n" + ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVerFactura_Click(object sender, EventArgs e)
        {
            verFactura(1);
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            verFactura(2);
        }

        private void btnAbrirCarpeta_Click(object sender, EventArgs e)
        {
            verFactura(3);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void chkCanceladas_Click(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }

        private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Vistas.FrmFacturar33 frm1 = new Vistas.FrmFacturar33();
            frm1.ShowDialog();
            if (frm1.DialogResult == DialogResult.OK)
            {
                _tbl = Facturas.FacturasSelect();
                btnBuscar.PerformClick();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("¿Desea cancelar esta factura?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (confirmar == DialogResult.Yes)
            {
                factura_timbrada.Id = int.Parse(dgvFacturas.SelectedRows[0].Cells["Folio"].Value.ToString());
                factura_abono.IdFactura = factura_timbrada.Id;
                factura_cuenta.IdFactura = factura_timbrada.Id;
                factura_timbrada.FolioUUID = dgvFacturas.SelectedRows[0].Cells["UUID"].Value.ToString();


                rcn = factura.CancelarFactura(ban_ambiente, rfc_emisor, factura_timbrada.FolioUUID);

                if (rcn.Exitoso)
                {
                    factura_timbrada.Eliminar();

                    if (dgvFacturas.SelectedRows[0].Cells["TipoComprobante"].Value.Equals("P Pago"))
                    {
                        //cancelar abono
                        factura_abono.Eliminar(1);

                        //Actualizar saldo de la factura
                        foreach (DataRow r in factura_abono.AbonosSelectByIdFactura().Rows)
                        {
                            factura_cuenta = new FacturasCuentas();
                            factura_cuenta.IdFactura = Convert.ToInt32(r["IDFACTURA_ABONADA"].ToString());
                            factura_cuenta.Abonado = Convert.ToDecimal(r["CANTIDAD"].ToString());
                            factura_cuenta.FacturasCuentasUpdateSaldoCancelacion(1);
                        }
                    }

                    MessageBox.Show("La factura ha sido cancelada.", "CFDI Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _tbl = Facturas.FacturasSelect();
                    llenarTabla();
                    //llenarTabla(ft.FacturasSelectVisor(cancelada));
                }

                else
                {
                    MessageBox.Show("No ha sido posible cancelar la factura: \n" + rcn.Descripcion, "Error al cancelar factura",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataTable tbl = (DataTable)dgvFacturas.DataSource;
            List<string> arCol = new List<string>();

            foreach (DataGridViewColumn col in dgvFacturas.Columns)
                if (col.DataPropertyName != "" && col.Visible)
                    arCol.Add(col.DataPropertyName);

            tbl = new DataView(tbl).ToTable(false, arCol.ToArray());

            foreach (DataGridViewColumn col in dgvFacturas.Columns) // chales los hardcodeso. sorry
                if (col.DataPropertyName != "" && col.Visible)
                    tbl.Columns[col.DataPropertyName].ColumnName = col.HeaderText;


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "XLSX Document|*.xlsx";
            saveFileDialog1.Title = "Ruta a guardar el Reporte";
            saveFileDialog1.FileName = this.Text + DateTime.Now.ToString(" dd.MM.yyy HH.mm.ss");

            DialogResult sfdr = saveFileDialog1.ShowDialog();



            if (sfdr == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                exportExcel(tbl, saveFileDialog1.FileName, this.Text /*+ " " + cmbTiposNomina.Text*/);

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "EXCEL.EXE";
                startInfo.Arguments = "\"" + saveFileDialog1.FileName + "\"";
                Process.Start(startInfo);
            }
        }

        #region exportacion excel

        public static string getLogo_path()
        {
            string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";
            //aqui bro el logo que ocupes va?  es poara que no tengas que pasarselo al cleitne   "pagalo en c en la carpeta x". sino que vaya en los recursos del proyecto.

            //presupuestoBioTecnologia.Properties.Resources.WhatsApp_Image_2019_06_01_at_9_09_33_AM.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            return path;
        }


        private static string toExcelCellName(int colIndex, int RowIndex)
        {
            return toExcelColName(colIndex + 1) + (RowIndex + 1).ToString();
        }
        private static string toExcelColName(int columnIndex)
        {
            int dividend = columnIndex;
            string columnName = String.Empty;
            int modulo = 0;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }
            return columnName;
        }
        private static string alignment_horizontal = "Izquierda";
        private static Microsoft.Office.Interop.Excel.XlHAlign getExcel_defaultHalign()
        {
            Microsoft.Office.Interop.Excel.XlHAlign res = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            switch (alignment_horizontal)
            {
                case "Centro":
                    res = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    break;
                case "Derecha":
                    res = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    break;
                default:
                    res = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    break;
            }
            return res;

        }
        private static string alignment_vertical = "Arriba";
        private static Microsoft.Office.Interop.Excel.XlVAlign getExcel_defaultValign()
        {
            Microsoft.Office.Interop.Excel.XlVAlign res = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

            switch (alignment_vertical)
            {
                case "Medio":
                    res = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    break;
                case "Abajo":
                    res = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    break;
                default:
                    res = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                    break;
            }
            return res;
        }

        private static Microsoft.Office.Interop.Excel.Style getDefaultStyle(Microsoft.Office.Interop.Excel.Workbook xlWorkBook)
        {
            Microsoft.Office.Interop.Excel.Style defaultStyle = xlWorkBook.Styles.Add("default" + xlWorkBook.Styles.Count);

            defaultStyle.HorizontalAlignment = getExcel_defaultHalign();
            defaultStyle.VerticalAlignment = getExcel_defaultValign();

            defaultStyle.Font.Color = getExcel_defaultFontColor();
            defaultStyle.Font.Size = font_size;
            defaultStyle.Font.Bold = font_bold == 1;
            defaultStyle.Font.Italic = font_Italic == 1;

            defaultStyle.Interior.Color = getExcel_defaultBgColor();
            defaultStyle.Borders.Color = getExcel_defaultBorderColor();

            defaultStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            defaultStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            defaultStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            defaultStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            defaultStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            defaultStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

            return defaultStyle;
        }
        private static Microsoft.Office.Interop.Excel.Style getHeaderStyle(Microsoft.Office.Interop.Excel.Workbook xlWorkBook)
        {
            Microsoft.Office.Interop.Excel.Style headerStyle = xlWorkBook.Styles.Add("headers" + xlWorkBook.Styles.Count);

            headerStyle.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            headerStyle.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            headerStyle.Font.Color = getExcel_defaultFontColor();
            headerStyle.Font.Size = font_size + 3;
            headerStyle.Font.Bold = true;
            headerStyle.Font.Italic = font_Italic == 1;

            headerStyle.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            headerStyle.Borders.Color = getExcel_defaultBorderColor();

            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

            return headerStyle;
        }
        private static Microsoft.Office.Interop.Excel.Style getTableHeaderStyle(Microsoft.Office.Interop.Excel.Workbook xlWorkBook)
        {
            Microsoft.Office.Interop.Excel.Style headerStyle = xlWorkBook.Styles.Add("table_headers" + xlWorkBook.Styles.Count);

            headerStyle.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            headerStyle.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            headerStyle.Font.Color = getExcel_defaultFontColor();
            headerStyle.Font.Size = font_size;
            headerStyle.Font.Bold = true;
            headerStyle.Font.Italic = font_Italic == 1;

            headerStyle.Interior.Color = getExcelHeaderBgColor(); // 
            headerStyle.Borders.Color = getExcel_defaultBorderColor();

            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

            return headerStyle;
        }
        private static Microsoft.Office.Interop.Excel.Style getBoldStyle(Microsoft.Office.Interop.Excel.Workbook xlWorkBook)
        {
            Microsoft.Office.Interop.Excel.Style headerStyle = xlWorkBook.Styles.Add("bolder" + xlWorkBook.Styles.Count);

            headerStyle.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            headerStyle.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            headerStyle.Font.Color = System.Drawing.ColorTranslator.FromHtml("#000000");
            headerStyle.Font.Size = font_size;
            headerStyle.Font.Bold = true;
            headerStyle.Font.Italic = font_Italic == 1;

            headerStyle.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            headerStyle.Borders.Color = System.Drawing.ColorTranslator.FromHtml("#000000");

            headerStyle.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

            return headerStyle;
        }
        private static Microsoft.Office.Interop.Excel.Style getUnderlinedStyle(Microsoft.Office.Interop.Excel.Workbook xlWorkBook)
        {
            Microsoft.Office.Interop.Excel.Style headerStyle = xlWorkBook.Styles.Add("underlined" + xlWorkBook.Styles.Count);

            headerStyle.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            headerStyle.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            headerStyle.Font.Color = System.Drawing.ColorTranslator.FromHtml("#2E75B6");
            headerStyle.Font.Size = font_size;
            headerStyle.Font.Bold = true;
            headerStyle.Font.Italic = font_Italic == 1;

            //headerStyle.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            //headerStyle.Borders.Color = System.Drawing.ColorTranslator.FromHtml("#000000");
            //headerStyle.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

            //headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            //headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            //headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.ColorTranslator.FromHtml("#000000");
            headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;

            //headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
            //headerStyle.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;

            return headerStyle;
        }

        private static string font_color = "#000000";
        private static double getExcel_defaultFontColor()
        {
            return System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml(font_color));
        }

        private static int font_size = 9;

        private static int font_bold = 0;
        private static int font_Italic = 0;

        private static int cell_colspan = 1;
        private static int cell_rowspan = 1;

        private static string cell_bgcolor = "#FDFDFD";
        private static double getExcel_defaultBgColor()
        {
            return System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml(cell_bgcolor));
        }

        private static double getExcel_Colorstring(string htmlcolor)
        {
            return System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml(htmlcolor));
        }

        private static string cellHeaderBgcolor = "#83CDFC";//"#3B963B";
        private static double getExcelHeaderBgColor()
        {
            return System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml(cellHeaderBgcolor));
        }

        private static string cell_bordercolor = "#909090";
        private static double getExcel_defaultBorderColor()
        {
            return System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml(cell_bordercolor));
        }



        public static string exportExcel(
               DataTable tbl
               , String path
               , string strTitulo

           )
        {

            #region create document
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
                return "Excel is not properly installed!!";

            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            #region Estilos
            Microsoft.Office.Interop.Excel.Style defaultStyle = getDefaultStyle(xlWorkBook);
            Microsoft.Office.Interop.Excel.Style tableHeaderStyle = getTableHeaderStyle(xlWorkBook);
            Microsoft.Office.Interop.Excel.Style headerStyle = getHeaderStyle(xlWorkBook);

            Microsoft.Office.Interop.Excel.Style bolderStyle = getBoldStyle(xlWorkBook);
            Microsoft.Office.Interop.Excel.Style underlinedStyle = getUnderlinedStyle(xlWorkBook);
            #endregion


            #endregion




            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------
            {



                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                Microsoft.Office.Interop.Excel.Range rn = xlWorkSheet.Range[toExcelCellName(0, 0)];


                #region titulos
                int rwIndex = 0;

                //string cell1 = "";
                //string cell2 = "";

                //cell1 = toExcelCellName(0, rwIndex);
                //cell2 = toExcelCellName(tbl.Columns.Count, rwIndex);
                //rn = xlWorkSheet.Range[cell1, cell2];
                //rn.Merge();
                //rn.Style = headerStyle;
                //if (tbl.Rows.Count > 0)
                //    rn.Value = strTitulo;

                #endregion

                #region exportacionDocumento


                //rwIndex += 2;

                for (int cCol = 0; cCol < tbl.Columns.Count; cCol++)
                {
                    rn = xlWorkSheet.Range[toExcelCellName(cCol, rwIndex)];
                    rn.Style = tableHeaderStyle;
                    rn.Value = tbl.Columns[cCol].ColumnName;

                    rn.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                    rn.Font.Size = 12;
                    rn.Font.Bold = true;
                }
                rwIndex++;

                for (int cRw = 0; cRw < tbl.Rows.Count; cRw++)
                {
                    for (int cCol = 0; cCol < tbl.Columns.Count; cCol++)
                    {
                        rn = xlWorkSheet.Range[toExcelCellName(cCol, rwIndex)];

                        object value = tbl.Rows[cRw][cCol];

                        if (value is DateTime)
                        {
                            rn.NumberFormat = "dd/MM/e";
                            rn.Value = ((DateTime)value).Date.ToOADate();
                            //rn.NumberFormat = "@";
                            //rn.Value = "'" + ((DateTime)value).ToString("dd/MM/yyyy");
                        }
                        else if (value is decimal)
                        {
                            rn.NumberFormat = "#,##0.0000";
                            rn.Value = decimal.Round((decimal)value, 4);
                        }
                        else if (value is int)
                        {
                            rn.Value = ((int)value).ToString();
                        }
                        else
                        {
                            rn.NumberFormat = "@";
                            rn.Value = "'" + value.ToString() != " " ? value.ToString().Trim() : value.ToString();
                        }
                        //else
                        //    rn.Value = tbl.Rows[cRw][cCol].ToString();
                    }
                    rwIndex++;
                }


                rwIndex++;

                #endregion

                xlWorkSheet.Columns.AutoFit();

                #region firmantes

                //rwIndex += 4;

                //cell1 = toExcelCellName(1, rwIndex); cell2 = toExcelCellName(1, rwIndex); rn = xlWorkSheet.Range[cell1, cell2];
                //rn.Merge(); rn.Style = underlinedStyle; rn.Value = "";
                //rn.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                //cell1 = toExcelCellName(4, rwIndex); cell2 = toExcelCellName(7, rwIndex); rn = xlWorkSheet.Range[cell1, cell2];
                //rn.Merge(); rn.Style = underlinedStyle; rn.Value = "";
                //rn.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                //rwIndex++;
                //cell1 = toExcelCellName(1, rwIndex); cell2 = toExcelCellName(3, rwIndex); rn = xlWorkSheet.Range[cell1, cell2];
                //rn.Merge(); rn.Style = bolderStyle; rn.Value = "Almacenista";
                //cell1 = toExcelCellName(5, rwIndex); cell2 = toExcelCellName(6, rwIndex); rn = xlWorkSheet.Range[cell1, cell2];
                //rn.Merge(); rn.Style = bolderStyle; rn.Value = "Auditor";


                #endregion

                //decimal totalEntradas = 0;
                //decimal totalSalidas = 0;



                //xlWorkSheet.Shapes.AddPicture(
                //       getLogo_path(), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue
                //       , 0, 0, 101f, 45f
                //   );

                xlWorkSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                xlWorkSheet.PageSetup.Zoom = false;
                xlWorkSheet.PageSetup.FitToPagesWide = 1;
                xlWorkSheet.PageSetup.FitToPagesTall = false;

                xlWorkSheet.Name = "Datos";
            }
            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------------------------------



            #region saveDocument

            xlWorkBook.SaveAs(
                    path
                    , Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault
                    , misValue, misValue, misValue, misValue
                    , Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive
                    , misValue, misValue, misValue, misValue, misValue
               );
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            #endregion

            return "";
        }



        #endregion

        private void dgvFacturas_DoubleClick(object sender, EventArgs e)
        {
            factura_timbrada.Id = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["Folio"].Value.ToString());
            factura_timbrada.FolioUUID = dgvFacturas.SelectedRows[0].Cells["UUID"].Value.ToString();
            factura_timbrada.Folio_Factura = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["No. Factura"].Value.ToString());
            factura_timbrada.Total = Convert.ToDecimal(dgvFacturas.SelectedRows[0].Cells["Total"].Value.ToString());
            factura_timbrada.IdCliente = Convert.ToInt32(factura_timbrada.FacturasSelectById().Rows[0]["IDCLIENTE"].ToString());
            factura_timbrada.Tipo_Comprobante = dgvFacturas.SelectedRows[0].Cells["TipoComprobante"].Value.ToString();
            factura_timbrada.IdEmisor = 1;// int.Parse(dgvFacturas.SelectedRows[0].Cells["IdEmisor"].Value.ToString());
            factura_timbrada.cancelada = Convert.ToBoolean(dgvFacturas.SelectedRows[0].Cells["Cancelada"].Value.ToString());
            this.DialogResult = DialogResult.OK;
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
    }
}


