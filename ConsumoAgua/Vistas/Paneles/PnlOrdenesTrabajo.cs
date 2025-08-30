using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlOrdenesTrabajo : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        public int NoContrato { get; set; } = -1;
        public int IdEstatus { get; set; } = -1;

        private List<OrdenTrabajo> _ordenes = new List<OrdenTrabajo>();

        public PnlOrdenesTrabajo()
        {
            InitializeComponent();
        }

        public void CargarOrdenesTrabajo()
        {
            if (NoContrato != -1)
            {
                tsTxtNoContrato.Text = NoContrato.ToString("D10");
                _ordenes = OrdenTrabajo.GetOrdenesTrabajoByNoContrato(NoContrato);

                if (IdEstatus != -1)
                    _ordenes = _ordenes.Where(o => o.IdEstatus == IdEstatus).ToList();

                dgvOrdenesTrabajo.DataSource = _ordenes;

                DarFormatoDgv();
                return;
            }

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
                    o.NoContrato.ToString("D10").Contains(tsTxtNoContrato.Text, StringComparison.OrdinalIgnoreCase)).ToList(); ;
            }

            dgvOrdenesTrabajo.DataSource = ordenesFiltradas;
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DlgOrdenTrabajo dlg = new DlgOrdenTrabajo();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarOrdenesTrabajo();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesTrabajo.CurrentRow == null || dgvOrdenesTrabajo.Rows.Count == 0) return;

            DlgOrdenTrabajo dlg = new DlgOrdenTrabajo();
            dlg.OrdenTrabajo = dgvOrdenesTrabajo.CurrentRow.DataBoundItem as OrdenTrabajo;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarOrdenesTrabajo();
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ActiveControl == tsTxtNoContrato.Control)
            {
                if (keyData == Keys.Enter)
                {
                    int noContrato;

                    if (!int.TryParse(tsTxtNoContrato.Text, out noContrato))
                    {
                        NoContrato = -1;
                        CargarOrdenesTrabajo();
                        return true;
                    }

                    NoContrato = noContrato;
                    CargarOrdenesTrabajo();

                    tsTxtNoContrato.SelectionStart = tsTxtNoContrato.Text.Length;

                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void PnlOrdenesTrabajo_Load(object sender, EventArgs e) => CargarOrdenesTrabajo();

        private void tsTxtNoContrato_TextChanged(object sender, EventArgs e) => FastFilter();

        private void dgvOrdenesTrabajo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowCount == 0) return;

            foreach (DataGridViewRow fila in dgvOrdenesTrabajo.Rows)
            {
                if (fila.Cells["OrdenEstatus"] == null) break;
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

