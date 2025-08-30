using System;
using System.Data;
using System.Windows.Forms;
using SAPA.Reportes;

namespace SAPA.Vistas
{
    public partial class FrmRptOrdenTrabajo : Form
    {
        public FrmRptOrdenTrabajo()
        {
            InitializeComponent();
        }
        public string Cuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Colonia { get; set; }
        public string Direccion { get; set; }
        public DataTable OtrosServicios { get; set; }
        public string Observaciones { get; set; }
        private void frmrptOrdenTrabajo_Load(object sender, EventArgs e)
        {
            try
            {
                RptOrdenTrabajo rpt = new RptOrdenTrabajo();
                rpt.SetParameterValue("Cuenta", Cuenta);
                rpt.SetParameterValue("fecha", Fecha);
                rpt.SetParameterValue("Nombre", Nombre);
                rpt.SetParameterValue("Colonia", Colonia);
                rpt.SetParameterValue("Direccion", Direccion);
                rpt.SetParameterValue("Observaciones", Observaciones);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmrptOrdenTrabajo_Load - " + ex.Message, "Formulario frmrptOrdenTrabajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

