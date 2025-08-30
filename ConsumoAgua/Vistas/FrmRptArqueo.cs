using System;
using System.Data;
using System.Windows.Forms;
using SAPA.Reportes;

namespace SAPA.Vistas
{
    public partial class FrmRptArqueo : Form
    {


        public DateTime FechaArqueo { get; set; }
        public int CantidadCincuentaCentavos { get; set; }
        public decimal TotalCincuentaCentavos { get; set; }
        public int CantidadUnPeso { get; set; }
        public decimal TotalUnPeso { get; set; }
        public int CantidadDosPesos { get; set; }
        public decimal TotalDosPesos { get; set; }
        public int CantidadCincoPesos { get; set; }
        public decimal TotalCincoPesos { get; set; }
        public int CantidadDiezPesos { get; set; }
        public decimal TotalDiezPesos { get; set; }
        public int CantidadVeintePesos { get; set; }
        public decimal TotalVeintePesos { get; set; }
        public int CantidadCincuentaPesos { get; set; }
        public decimal TotalCincuentaPesos { get; set; }
        public int CantidadCienPesos { get; set; }
        public decimal TotalCienPesos { get; set; }
        public int CantidadDoscientosPesos { get; set; }
        public decimal TotalDoscientosPesos { get; set; }
        public int CantidadQuinientosPesos { get; set; }
        public decimal TotalQuinientosPesos { get; set; }
        public int CantidadMilPesos { get; set; }
        public decimal TotalMilPesos { get; set; }
        public decimal TotalVauchers { get; set; }
        public decimal TotalChequesTransferencias { get; set; }
        public decimal TotalArqueo { get; set; }

        private FrmPrincipal _srcFrm = null;

        public FrmRptArqueo(FrmPrincipal srcFrm)
        {
            InitializeComponent();
            _srcFrm = srcFrm;
        }

        private void frmRptArqueo_FormClosing(object sender, FormClosingEventArgs e) => _srcFrm.tabManager.TabPages.RemoveAt(_srcFrm.tabManager.SelectedIndex);

        private void frmRptArqueo_Load(object sender, EventArgs e)
        {

            RptArqueo rpt = new RptArqueo();

            DataTable tblOrganismo = new DataTable(); // TODO: Reasignar
            tblOrganismo.TableName = "datosGenerales";

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(tblOrganismo);

            rpt.SetDataSource(dataSet);

            rpt.SetParameterValue("FechaArqueo", FechaArqueo);

            rpt.SetParameterValue("CantidadCincuentaCentavos", CantidadCincuentaCentavos);
            rpt.SetParameterValue("TotalCincuentaCentavos", TotalCincuentaCentavos.ToString("N2"));

            rpt.SetParameterValue("CantidadUnPeso", CantidadUnPeso);
            rpt.SetParameterValue("TotalUnPeso", TotalUnPeso.ToString("N2"));

            rpt.SetParameterValue("CantidadDosPesos", CantidadDosPesos);
            rpt.SetParameterValue("TotalDosPesos", TotalDosPesos.ToString("N2"));

            rpt.SetParameterValue("CantidadCincoPesos", CantidadCincoPesos);
            rpt.SetParameterValue("TotalCincoPesos", TotalCincoPesos.ToString("N2"));

            rpt.SetParameterValue("CantidadDiezPesos", CantidadDiezPesos);
            rpt.SetParameterValue("TotalDiezPesos", TotalDiezPesos.ToString("N2"));

            rpt.SetParameterValue("CantidadVeintePesos", CantidadVeintePesos);
            rpt.SetParameterValue("TotalVeintePesos", TotalVeintePesos.ToString("N2"));

            rpt.SetParameterValue("CantidadCincuentaPesos", CantidadCincuentaPesos);
            rpt.SetParameterValue("TotalCincuentaPesos", TotalCincuentaPesos.ToString("N2"));

            rpt.SetParameterValue("CantidadCienPesos", CantidadCienPesos);
            rpt.SetParameterValue("TotalCienPesos", TotalCienPesos.ToString("N2"));

            rpt.SetParameterValue("CantidadDoscientosPesos", CantidadDoscientosPesos);
            rpt.SetParameterValue("TotalDoscientosPesos", TotalDoscientosPesos.ToString("N2"));

            rpt.SetParameterValue("CantidadQuinientosPesos", CantidadQuinientosPesos);
            rpt.SetParameterValue("TotalQuinientosPesos", TotalQuinientosPesos.ToString("N2"));

            rpt.SetParameterValue("CantidadMilPesos", CantidadMilPesos);
            rpt.SetParameterValue("TotalMilPesos", TotalMilPesos.ToString("N2"));

            rpt.SetParameterValue("TotalVauchers", TotalVauchers.ToString("N2"));
            rpt.SetParameterValue("TotalChequesTransferencias", TotalChequesTransferencias.ToString("N2"));

            rpt.SetParameterValue("TotalArqueo", TotalArqueo.ToString("N2"));

            crvArqueo.ReportSource = rpt;
        }
    }
}

