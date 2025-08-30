using System;
using System.Windows.Forms;
using SAPA.Reportes.Facturacion;

namespace SAPA.Vistas
{
    public partial class FrmVistaRpt : Form
    {
        //public frmVistaRpt(Venta.Abono.ReciboVenta rpt)
        //{
        //    InitializeComponent();
        //    crystalReportViewer1.ReportSource = rpt;
        //}

        //public frmVistaRpt(Reportes.RptInventarioPrecios rpt)
        //{
        //    InitializeComponent();
        //    crystalReportViewer1.ReportSource = rpt;
        //}

        //public frmVistaRpt(Reportes.RptCotizacion rpt)
        //{
        //    InitializeComponent();
        //    crystalReportViewer1.ReportSource = rpt;
        //}

        //public frmVistaRpt(Reportes.RptFactura_CFDI33 rpt)
        //{
        //    InitializeComponent();
        //    crystalReportViewer1.ReportSource = rpt;
        //}

        public FrmVistaRpt(RptFactura_CFDI33_2 rpt)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = rpt;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

