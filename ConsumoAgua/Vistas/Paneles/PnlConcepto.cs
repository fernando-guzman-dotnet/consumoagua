using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlConcepto : Form
    {

        public FrmPrincipal FrmPrincipal;
        private List<Concepto> _conceptos;

        public PnlConcepto()
        {
            InitializeComponent();
        }

        public void CargarOtrosServicios()
        {

            _conceptos = Concepto.GetConceptos();
            dgvConceptos.DataSource = _conceptos;
            dgvConceptos.Columns["Id"].DefaultCellStyle.Format = "D3";
            dgvConceptos.Columns["Id"].HeaderText = "Código";
            dgvConceptos.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvConceptos.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvConceptos.Columns["Importe"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            foreach (DataGridViewColumn col in dgvConceptos.Columns)
            {
                if (col.ValueType == typeof(Decimal))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void FastFilter(string descripcion)
        {
            var otrosServiciosFiltrados = _conceptos.Where(os => os.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase));
            dgvConceptos.DataSource = otrosServiciosFiltrados.ToList();
        }

        private void btnAgregarConcepto_Click(object sender, EventArgs e)
        {
            DlgConcepto dlg = new DlgConcepto();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarOtrosServicios();
            }
        }

        private void btnEditarConcepto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvConceptos.CurrentRow == null || dgvConceptos.Rows.Count == 0) return;

                DlgConcepto dlg = new DlgConcepto();

                dlg.Concepto = dgvConceptos.CurrentRow.DataBoundItem as Concepto;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarOtrosServicios();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarConcepto_Click - " + ex.Message, "Formulario Panel_Concepto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarConcepto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvConceptos.CurrentRow == null || dgvConceptos.Rows.Count == 0) return;

                Concepto concepto = dgvConceptos.CurrentRow.DataBoundItem as Concepto;

                if (MessageBox.Show("Se eliminará el concepto seleccionado, ¿desea continuar?", "Formulario Concepto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!concepto.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar eliminar el concepto seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("El concepto seleccionado fue eliminado correctamente.", "Formulario Concepto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarOtrosServicios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEliminarConcepto_Click - " + ex.Message, "Formulario Panel_Concepto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void PnlConcepto_Load(object sender, EventArgs e) => CargarOtrosServicios();
        
        private void tsTxtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtDescripcion.Text);
        
    }
}

