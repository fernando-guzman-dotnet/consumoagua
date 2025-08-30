using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlMedidor : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        public List<ContratoMedidor> _contratosMedidores = new List<ContratoMedidor>();

        private List<Medidor> _medidores;

        public PnlMedidor()
        {
            InitializeComponent();
        }

        private void CargarMedidores()
        {
            _medidores = Medidor.GetTodos();
            _contratosMedidores = ContratoMedidor.GetTodos();

            dgvMedidores.DataSource = _medidores;
            dgvMedidores.Columns["Id"].Visible = false;
            dgvMedidores.Columns["NoMedidor"].DefaultCellStyle.Format = "D3";
        }

        private void FastFilter(string noMedidor)
        {
            var medidoresFiltrados = _medidores.Where(m => m.NoMedidor.ToString().Contains(noMedidor, StringComparison.OrdinalIgnoreCase));

            dgvMedidores.DataSource = medidoresFiltrados.ToList();
        }

        private void btnAgregarMedidor_Click(object sender, EventArgs e)
        {
            DlgMedidor dlg = new DlgMedidor();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarMedidores();
            }
        }

        private void btnEditarMedidor_Click(object sender, EventArgs e)
        {
            Medidor medidor = dgvMedidores.CurrentRow.DataBoundItem as Medidor;

            var medidoresAsignados = _contratosMedidores.Where(x => x.IdMedidor == medidor.NoMedidor).ToList();

            if (medidoresAsignados.Count > 0)
            {
                MessageBox.Show("Este medidor está asignado a un contrato.", "Formulario Medidor", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DlgMedidor dlg = new DlgMedidor();

            dlg.Medidor = medidor;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarMedidores();
            }
        }

        private void btnEliminarMedidor_Click(object sender, EventArgs e)
        {
            try
            {
                Medidor medidor = dgvMedidores.CurrentRow.DataBoundItem as Medidor;

                var medidoresAsignados = _contratosMedidores.Where(cm => cm.IdMedidor == medidor.NoMedidor).ToList();

                if (medidoresAsignados.Count > 0)
                {
                    MessageBox.Show("Este medidor está asignado a un contrato.", "Formulario Medidor",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Se eliminara el Medidor seleccionado, ¿desea continuar?", "Formulario Medidores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!medidor.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar eliminar el medidor seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("El medidor seleccionado fue eliminado correctamente.", this.Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    CargarMedidores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("dgvMedidores_CellClick - " + ex.Message, "Formulario Medidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);


        private void tsmBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                Medidor medidor = dgvMedidores.CurrentRow.DataBoundItem as Medidor;

                var medidoresAsignados = _contratosMedidores.Where(x => x.IdMedidor == medidor.NoMedidor).ToList();

                if (medidoresAsignados.Count > 0)
                {
                    MessageBox.Show("Este medidor está asignado a un contrato.", "Formulario Medidor",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Se eliminara el Medidor seleccionado, ¿desea continuar?", "Formulario Medidores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!medidor.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar eliminar el medidor seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("El medidor seleccionado fue eliminado correctamente.", this.Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    CargarMedidores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("dgvMedidores_CellClick - " + ex.Message, "Formulario Medidores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsmActualizar_Click(object sender, EventArgs e)
        {
            Medidor medidor = dgvMedidores.CurrentRow.DataBoundItem as Medidor;

            var medidoresAsignados = _contratosMedidores.Where(x => x.IdMedidor == medidor.NoMedidor).ToList();

            if (medidoresAsignados.Count > 0)
            {
                MessageBox.Show("Este medidor está asignado a un contrato.", "Formulario Medidor", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DlgMedidor dlg = new DlgMedidor();

            dlg.Medidor = dgvMedidores.CurrentRow.DataBoundItem as Medidor;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarMedidores();
            }
        }


        private void tsTxtNoMedidor_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtNoMedidor.Text);

        private void FrmMedidores_Load(object sender, EventArgs e) => CargarMedidores();
    }
}

