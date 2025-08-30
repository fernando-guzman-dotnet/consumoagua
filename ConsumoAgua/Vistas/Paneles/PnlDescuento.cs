using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlDescuentos : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }
        private List<Descuento> _descuentos { get; set; }

        public PnlDescuentos()
        {
            InitializeComponent();
        }

        private void PnlDescuentos_Load(object sender, EventArgs e) => CargarDescuentos();

        private void CargarDescuentos()
        {
            _descuentos = Descuento.GetDescuentos();
            dgvDescuentos.DataSource = _descuentos;
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);


        private void btnAgregarDescuento_Click(object sender, EventArgs e)
        {
            DlgDescuento dlg = new DlgDescuento();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarDescuentos();
            }
        }

        private void btnEditarDescuento_Click(object sender, EventArgs e)
        {
            if (dgvDescuentos.Rows.Count == 0 || dgvDescuentos.CurrentRow == null) return;

            DlgDescuento dlg = new DlgDescuento();

            dlg.Descuento = dgvDescuentos.CurrentRow.DataBoundItem as Descuento;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarDescuentos();
            }
        }

        private void btnEliminarDescuento_Click(object sender, EventArgs e)
        {
            if (dgvDescuentos.Rows.Count == 0 || dgvDescuentos.CurrentRow == null) return;

            Descuento descuento = dgvDescuentos.CurrentRow.DataBoundItem as Descuento;

            if (descuento == null) return;

            if (MessageBox.Show("Se eliminara el descuento seleccionado, ¿desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!descuento.Eliminar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar eliminar el descuento seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("El descuento seleccionado fue eliminado correctamente.", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                CargarDescuentos();
            }
        }

        private void btnAplicarDescuentoContrato_Click(object sender, EventArgs e)
        {
            DlgSeleccionarCuenta dlg = new DlgSeleccionarCuenta();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DlgAplicarDescuento postDlg = new DlgAplicarDescuento();
                postDlg.Contrato = dlg.Contrato;
                postDlg.ShowDialog();
            }
        }

        private void btnAplicarDescuentoMasivamente_Click(object sender, EventArgs e)
        {
            DlgAplicarDescuentoMasivamente dlg = new DlgAplicarDescuentoMasivamente();

            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}


