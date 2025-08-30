using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgOrdenesTareas : Form
    {
        public OrdenTrabajo OrdenTrabajo { get; set; }

        public DlgOrdenesTareas()
        {
            InitializeComponent();
            dgvOrdenesTareas.AutoGenerateColumns = false;
        }

        private void DlgOrdenesTareas_Load(object sender, EventArgs e)
        {
            if (OrdenTrabajo == null)
            {
                MessageBox.Show(
                    "No se ha cargado una orden de trabajo para poder usar este formulario. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }

            CargarOrdenesTareas(OrdenTrabajo.Id);
        }


        private void CargarOrdenesTareas(int idOrdenTrabajo)
        {
            lblTitulo.Text = $"ORDEN DE TRABAJO #{OrdenTrabajo.Id:D5}";
            dgvOrdenesTareas.DataSource = OrdenTarea.GetOrdenTareas(OrdenTrabajo.Id);
        }


        private void btnAgregarTarea_Click(object sender, EventArgs e)
        {
            DlgAgregarOrdenTarea dlg = new DlgAgregarOrdenTarea();

            dlg.OrdenTrabajo = OrdenTrabajo;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarOrdenesTareas(OrdenTrabajo.Id);
            }
        }
    }
}

