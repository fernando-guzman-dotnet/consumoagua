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

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgVerBitacoraOrden : Form
    {
        public DlgVerBitacoraOrden()
        {
            InitializeComponent();
        }

        public OrdenTrabajo OrdenTrabajo { get; set; } = new OrdenTrabajo();

        private void DlgVerBitacoraOrden_Load(object sender, EventArgs e)
        {
            if (OrdenTrabajo.Id > 0)
            {
                lblNoOrden.Text = $"BITACORA Orden #{OrdenTrabajo.Id:D5}";
                lblNoContrato.Text = $"Contrato #{OrdenTrabajo.NoContrato:D10} | Supervisor {OrdenTrabajo.Supervisor.NombreCompleto}";

                dgvRegistrosBitacora.DataSource = BitacoraOrdenTrabajo.GetByIdOrden(OrdenTrabajo.Id);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}

