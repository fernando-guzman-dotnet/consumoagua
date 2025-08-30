using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlRevisionContrato : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        public PnlRevisionContrato()
        {
            InitializeComponent();
        }

        private void CargarRevisionesContratos()
        {
            dgvContratosRevisiones.DataSource = Reporte.GetContratosRevisiones();
            FormatearDgvContratos();
        }

        public void FormatearDgvContratos()
        {
            try
            {
                dgvContratosRevisiones.Columns["Id"].Visible = true;
                dgvContratosRevisiones.Columns["Id"].HeaderText = "No. Revisión";
                dgvContratosRevisiones.Columns["Id"].DefaultCellStyle.Format = "D5";
                dgvContratosRevisiones.Columns["IdContrato"].Visible = false;
                dgvContratosRevisiones.Columns["NoContrato"].DefaultCellStyle.Format = "D10";
                dgvContratosRevisiones.Columns["NoContrato"].HeaderText = "No. Contrato";
                dgvContratosRevisiones.Columns["NoContrato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvContratosRevisiones.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvContratosRevisiones.Columns["Estatus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch (Exception ) { }

        }

        private void btnVerRevision_Click(object sender, EventArgs e)
        {
            if (dgvContratosRevisiones.SelectedRows.Count == 0 || dgvContratosRevisiones.CurrentRow == null)
            {
                MessageBox.Show(
                    "No has seleccionado una revisión de contrato. Seleccione un registro e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int rowIndex = dgvContratosRevisiones.SelectedRows[0].Cells[0].RowIndex;

            DlgVerRevision dlg = new DlgVerRevision();
            dlg.IdRevision = int.Parse(dgvContratosRevisiones.Rows[rowIndex].Cells["Id"].Value.ToString());

            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
        private void PnlContrato_Load(object sender, EventArgs e) => CargarRevisionesContratos();
    }
}

