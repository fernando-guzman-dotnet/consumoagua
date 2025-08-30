using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgVistaPreviaReporte : Form
    {
        public object Reporte { get; set; }

        public DlgVistaPreviaReporte()
        {
            InitializeComponent();
        }

        private void DlgVistaPreviaReporte_Load(object sender, EventArgs e) => CargarReporte();

        private void CargarReporte()
        {
            if (Reporte == null)
            {
                MessageBox.Show(
                    "No se puede generar la vista previa para el reporte cargado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }

            crvVistaPreviaReporte.ReportSource = Reporte;
        }
    }
}

