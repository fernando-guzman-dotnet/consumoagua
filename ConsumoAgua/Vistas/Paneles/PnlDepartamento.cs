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
    public partial class PnlDepartamento : Form
    {

        public FrmPrincipal FrmPrincipal;
        private List<Departamento> _departamentos;

        public PnlDepartamento()
        {
            InitializeComponent();
        }

        public void CargarDepartamentos()
        {
            _departamentos = Departamento.GetDepartamentos();
            dgvDepartamento.DataSource = _departamentos;
            dgvDepartamento.Columns["Id"].DefaultCellStyle.Format = "D3";
            dgvDepartamento.Columns["Id"].HeaderText = "Código";
            dgvDepartamento.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDepartamento.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FastFilter(string descripcion)
        {
            var departamentosFiltrados = _departamentos.Where(dp => dp.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase));
            dgvDepartamento.DataSource = departamentosFiltrados.ToList();
        }

        private void btnAgregarDepartamento_Click(object sender, EventArgs e)
        {
            DlgDepartamento dlg = new DlgDepartamento();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarDepartamentos();
            }
        }

        private void btnEditarDepartamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDepartamento.CurrentRow == null || dgvDepartamento.Rows.Count == 0) return;

                DlgDepartamento dlg = new DlgDepartamento();

                dlg.Departamento = dgvDepartamento.CurrentRow.DataBoundItem as Departamento;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarDepartamentos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarDepartamento_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarDepartamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDepartamento.CurrentRow == null || dgvDepartamento.Rows.Count == 0) return;

                Departamento departamento = dgvDepartamento.CurrentRow.DataBoundItem as Departamento;

                if (MessageBox.Show("Se eliminará el departamento seleccionado, ¿desea continuar?", this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!departamento.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar eliminar el departamento seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("El departamento seleccionado fue eliminado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDepartamentos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEliminarConcepto_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void PnlDepartamento_Load(object sender, EventArgs e) => CargarDepartamentos();
        
        private void tsTxtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtDescripcion.Text);
        
    }
}

