using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlAdminOrdenesTrabajo : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        private List<OrdenTrabajo> _ordenes = new List<OrdenTrabajo>();

        public PnlAdminOrdenesTrabajo()
        {
            InitializeComponent();
        }

        private void CargarOrdenesTrabajo()
        {
            _ordenes = OrdenTrabajo.GetOrdenesTrabajo();
            dgvOrdenesTrabajo.DataSource = _ordenes;

            DarFormatoDgv();
        }

        private void DarFormatoDgv()
        {
            dgvOrdenesTrabajo.Columns["Id"].Visible = false;
            dgvOrdenesTrabajo.Columns["IdTipoOrdenTrabajo"].Visible = false;
            dgvOrdenesTrabajo.Columns["IdEmpleado"].Visible = false;
            dgvOrdenesTrabajo.Columns["IdEmpleadoSupervisor"].Visible = false;
            dgvOrdenesTrabajo.Columns["IdEmpleadoJefeCuadrilla"].Visible = false;
            dgvOrdenesTrabajo.Columns["IdEstatus"].Visible = false;
            dgvOrdenesTrabajo.Columns["IdPago"].Visible = false;
            dgvOrdenesTrabajo.Columns["NoContrato"].DefaultCellStyle.Format = "D10";
            dgvOrdenesTrabajo.Columns["NoContrato"].HeaderText = "No. de Contrato";
            dgvOrdenesTrabajo.Columns["NoContrato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvOrdenesTrabajo.Columns["TipoOrden"].HeaderText = "Tipo de Orden";
            dgvOrdenesTrabajo.Columns["TipoOrden"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvOrdenesTrabajo.Columns["NombreEmpleado"].HeaderText = "Atendió";
            dgvOrdenesTrabajo.Columns["NombreEmpleado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvOrdenesTrabajo.Columns["NombreEmpleadoSupervisor"].HeaderText = "Supervisor";
            dgvOrdenesTrabajo.Columns["NombreEmpleadoSupervisor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvOrdenesTrabajo.Columns["NombreEmpleadoJefeCuadrilla"].HeaderText = "Jefe Cuadrilla";
            dgvOrdenesTrabajo.Columns["NombreEmpleadoJefeCuadrilla"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvOrdenesTrabajo.Columns["NoCuadrilla"].HeaderText = "No. de Cuadrilla";
            dgvOrdenesTrabajo.Columns["OrdenEstatus"].HeaderText = "Estatus";
        }

        private void FastFilter()
        {
            if (_ordenes == null) return;


            List<OrdenTrabajo> ordenesFiltradas = _ordenes;

            // Luego por no contrato

            if (!string.IsNullOrWhiteSpace(tsTxtNoContrato.Text))
            {
                ordenesFiltradas = _ordenes.Where(o =>
                    o.NoContrato.ToString().Contains(tsTxtNoContrato.Text, StringComparison.OrdinalIgnoreCase)).ToList(); ;
            }

            dgvOrdenesTrabajo.DataSource = ordenesFiltradas;
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);


        private void btnVerBitacora_Click(object sender, EventArgs e)
        {
            DlgVerBitacoraOrden dlg = new DlgVerBitacoraOrden();
            dlg.OrdenTrabajo = dgvOrdenesTrabajo.CurrentRow.DataBoundItem as OrdenTrabajo;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarOrdenesTrabajo();
            }
        }

        private void PnlOrdenesTrabajo_Load(object sender, EventArgs e) => CargarOrdenesTrabajo();

        private void tsTxtNoContrato_TextChanged(object sender, EventArgs e) => FastFilter();

        private void btnAgregarConceptoOrden_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesTrabajo.CurrentRow == null) return;

            DlgOrdenesConceptos dlg = new DlgOrdenesConceptos();

            dlg.OrdenTrabajo = dgvOrdenesTrabajo.CurrentRow.DataBoundItem as OrdenTrabajo;

            if ((OrdenTrabajo.Estatus)dlg.OrdenTrabajo.IdEstatus == OrdenTrabajo.Estatus.Completada)
            {
                MessageBox.Show(
                    "No se pueden agregar conceptos a la orden de trabajo cuando ésta ya ha sido completada. Cambie el estatus de la orden e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarOrdenesTrabajo();
            }
        }

        private void btnActualizarEstatus_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesTrabajo.CurrentRow == null) return;

            DlgActualizarEstatusOrden dlg = new DlgActualizarEstatusOrden();
            dlg.OrdenTrabajo = dgvOrdenesTrabajo.CurrentRow.DataBoundItem as OrdenTrabajo;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarOrdenesTrabajo();
            }
        }



        private void btnRevisarTareas_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesTrabajo.CurrentRow == null) return;

            DlgOrdenesTareas dlg = new DlgOrdenesTareas();
            dlg.OrdenTrabajo = dgvOrdenesTrabajo.CurrentRow.DataBoundItem as OrdenTrabajo;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarOrdenesTrabajo();
            }
        }


        private void dgvOrdenesTrabajo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowCount == 0) return;

            foreach (DataGridViewRow fila in dgvOrdenesTrabajo.Rows)
            {
                if (fila.Cells["OrdenEstatus"] == null)
                    break;

                switch (fila.Cells["OrdenEstatus"].Value.ToString())
                {
                    case "CANCELADA":
                        fila.DefaultCellStyle.BackColor = Color.DarkRed;
                        break;

                    case "PENDIENTE":
                        fila.DefaultCellStyle.BackColor = Color.Goldenrod;
                        break;

                    case "COMPLETADA":
                        fila.DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                        break;

                    case "EN PROCESO":
                        fila.DefaultCellStyle.BackColor = Color.DarkCyan;
                        break;
                }
            }
        }
    }
}

