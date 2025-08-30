using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using SAPA.Clases;
using SAPA.Clases.Facturacion;
using SAPA.Reportes.Facturacion;
using SAPAFacturacionCFDI33;

namespace SAPA.Vistas
{
    public partial class FrmFacturasReenviarEmail : Form
    {
        public FrmFacturasReenviarEmail(Receptores cliente, RptFactura_CFDI33_2 rpt_33, Facturas factura_timbrada)
        {
            InitializeComponent();
            organismo = new Organismo();
            factura = new Facturas();
            factura = factura_timbrada;

            cliente_cfdi33 = new Receptores();
            emisor_cfdi33 = new Emisores();
            cliente_cfdi33 = cliente;

            organismo.Id = 1;
            emisor_cfdi33 = organismo.EmisoresSelectById().Rows[0];

            rpt = rpt_33;

            //dgvCorreos.DataSource = ObtenerCorreos(cliente_cfdi33.Correo);

            dgvCorreos.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            dgvCorreos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);


            UUID = factura_timbrada.FolioUUID;
            //f.FolioUUID = UUID;
            //f.Folio_Factura = Convert.ToInt32(f.SelectFacturasPorFolioUUID().Rows[0]["Folio_Factura"].ToString());
            esAmbientePruebas = true;
        }
        RptFactura_CFDI33_2 rpt { get; set; }
        SAPAFacturacionCFDI33.Receptores cliente_cfdi33 { get; set; }
        SAPAFacturacionCFDI33.Emisores emisor_cfdi33 { get; set; }

        DataTable correos_cliente { get; set; }
        String Ruta { get; set; }
        String UUID { get; set; }
        Boolean esAmbientePruebas { get; set; }
        
        Organismo organismo { get; set; }
        Facturas factura { get; set; }

        private DataTable ObtenerCorreos(String correos)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Correo", typeof(string));
            String[] lista_correos = correos.Split(';');
            foreach (string c in lista_correos) dt.Rows.Add(c);
            return dt;

        }

        //Enviar factura a correo del emisor
        private Boolean EnviarCorreoEmisor(String ruta)
        {
            Cursor = Cursors.WaitCursor;

            List<string> lstArchivos = new List<string>();

            String Correo = "";

            Correo = esAmbientePruebas ? "correo.de.prueba.123@hotmail.com" : emisor_cfdi33.Correo;

            //rpt.ExportToDisk(ExportFormatType.PortableDocFormat, rutaReporte);
            lstArchivos.Add(ruta + UUID + ".pdf");
            //lstArchivos.Add(Ruta + rt.FolioUUID + ".jpg");
            lstArchivos.Add(ruta + UUID + ".xml");

            Mail oMail = new Mail("servienvases.facturacion@gmail.com",
                                                                    emisor_cfdi33.Correo,
                                                                    "Archivo de Factura CFDI " + DateTime.Now.ToString(),
                                                                    "Factura " + factura.Folio_Factura, 
                                                                    lstArchivos);


            if (!oMail.enviaMail())
            {
                MessageBox.Show("No se pudo enviar la factura al correo del emisor (" + Correo + "):\n" + oMail.error, "Error de Envio",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                
            }

            MessageBox.Show("Se envió la factura al correo del emisor (" + Correo + ")", "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            Cursor = Cursors.Arrow;

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Enviar factura por Correo
            DialogResult confirmarCorreo = MessageBox.Show("¿Desea enviar la Factura por correo?", "Factura CFDI", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (confirmarCorreo == DialogResult.Yes)
            {


                Cursor = Cursors.WaitCursor;
                //Ruta = "C:\\Facturas\\" + cliente_cfdi33.Correo + "\\" + UUID + "\\";
                if (!Directory.Exists(Ruta)) Directory.CreateDirectory(Ruta);

                string Ubicacion = Ruta + UUID + ".pdf";
                if (File.Exists(Ubicacion))
                {
                    File.SetAttributes(Ubicacion, FileAttributes.Normal);
                    File.Delete(Ubicacion);
                }

                rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Ruta + UUID + ".pdf");

                EnviarCorreoEmisor(Ruta/*emisor.SelectEmisoresPorID().Rows[0]["RFC"].ToString()*/);

                List<string> lstArchivos = new List<string>();

                //rpt.ExportToDisk(ExportFormatType.PortableDocFormat, rutaReporte);
                lstArchivos.Add(Ruta + UUID + ".pdf");
                lstArchivos.Add(Ruta + UUID + ".xml");

                String Enviados = "Se envió la factura al correo: \n";
                String Error = "No se pudo enviar la factura al siguiente correo: \n";
                int contError = 0, contEnviados = 0;


                for (int i = 0; i < dgvCorreos.Rows.Count - 1; i++)
                {

                    Mail oMail = new Mail("servienvases.facturacion@gmail.com",
                    dgvCorreos.Rows[i].Cells[0].Value.ToString(),//txtCorreo.Text,
                         "Archivo de Factura CFDI " + DateTime.Now.ToString(),"Factura " + factura.Folio_Factura, lstArchivos);

                    if (oMail.enviaMail())
                    {
                        Enviados = Enviados + dgvCorreos.Rows[i].Cells[0].Value.ToString() + "\n";
                        contEnviados++;
                    }
                    else
                    {
                        Error = Error + dgvCorreos.Rows[i].Cells[0].Value.ToString() + "\n";
                        contError++;
                    }

                }
                Cursor = Cursors.Arrow;
                if (contEnviados > 0)
                {
                    MessageBox.Show(Enviados, "Correo Enviado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                if (contError > 0)
                {
                    MessageBox.Show(Error + "\n", "Error al enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                DialogResult = DialogResult.OK;
            }
        }
    }
}

