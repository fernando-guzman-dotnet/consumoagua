using System;
using System.Data;
using System.Windows.Forms;
using SAPA.Reportes;

namespace SAPA.Vistas
{
    public partial class FrmHistograma : Form
    {
        public FrmHistograma()
        {
            InitializeComponent();

        }
        public DataTable Mediciones { get; set; }
        public DataTable DatosPago { get; set; }

        private void frmHistograma_Load(object sender, EventArgs e)
        {
            //Llenado de dataset de los datos
            DataSet ds = new DataSet();
            RptHistograma rpt = new RptHistograma();
            ds.Tables.Add(LitrosConsumidos(Mediciones));
            rpt.SetDataSource(ds);
            rpt.SetParameterValue("Cuenta", DatosPago.Rows[0]["Cuenta"].ToString());
            rpt.SetParameterValue("Nombre", DatosPago.Rows[0]["Nombre"].ToString());
            rpt.SetParameterValue("Direccion", DatosPago.Rows[0]["Direccion"].ToString());
            rpt.SetParameterValue("Colonia", DatosPago.Rows[0]["Colonia"].ToString());

            crystalReportViewer1.ReportSource = rpt;
        }

        private DataTable LitrosConsumidos(DataTable tbl)
        {
            try
            {

                DataTable DatosReporte = new DataTable();
                DatosReporte.Columns.Add("Cuenta", typeof(int));
                DatosReporte.Columns.Add("A_Nombre_De", typeof(string));
                DatosReporte.Columns.Add("Fecha", typeof(DateTime));
                DatosReporte.Columns.Add("Litros", typeof(decimal));
                DatosReporte.TableName = "DatosReporte";


                decimal Mayor = 0m;
                decimal Menor = 0m;
                for (int i = 0; i < tbl.Rows.Count - 1; i++)
                {
                    Mayor = Convert.ToDecimal(tbl.Rows[i]["Litros"].ToString());
                    Menor = Convert.ToDecimal(tbl.Rows[i + 1]["Litros"].ToString());

                    DataRow newRow = DatosReporte.NewRow();
                    newRow["Cuenta"] = Convert.ToInt32(tbl.Rows[i]["Cuenta"].ToString());
                    newRow["A_Nombre_De"] = tbl.Rows[i]["A_Nombre_De"].ToString();
                    newRow["Fecha"] = Convert.ToDateTime(tbl.Rows[i]["fecha"].ToString());
                    newRow["Litros"] = Mayor - Menor;
                    DatosReporte.Rows.InsertAt(newRow, i);

                }

                return DatosReporte;
            }
            catch (Exception ex)
            {

                MessageBox.Show("LitrosConsumidos - " + ex.Message, "Formulario frmHistograma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

