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
    public partial class PnlConvenio : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }
        private List<Convenio> _convenios;

        public PnlConvenio()
        {
            InitializeComponent();

            dgvConvenios.AutoGenerateColumns = false;
        }

        private void CargarConvenios()
        {
            _convenios = Convenio.GetConvenios();
            dgvConvenios.DataSource = _convenios;
        }

        private void PnlConvenio_Load(object sender, EventArgs e) => CargarConvenios();

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnEstablecerConvenio_Click(object sender, EventArgs e)
        {
            DlgSeleccionarContratoPagosUltimaSemana dlg = new DlgSeleccionarContratoPagosUltimaSemana();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var dsCobro = CalculoCobroAgua.CobroAgua.GetContratoAdeudos(dlg.Contrato.NoContrato);

                if (dsCobro.Tables["ERRORES"] != null)
                {
                    MessageBox.Show(
                        $"No se puede calcular el adeudo del contrato {dlg.Contrato:D10}.\n\n\t{dsCobro.Tables["ERRORES"].Rows[0]["ERROR"]}",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var adeudoTotal = decimal.Parse(dsCobro.Tables["RESUMEN"].Rows[0]["AdeudoTotal"].ToString());

                if (adeudoTotal == 0)
                {
                    MessageBox.Show(
                        "No se puede establecer un convenio de pago si el contrato no tiene adeudos pendientes.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // Después de todas las validaciones, preparamos el dialogo para generar el convenio

                DlgConvenio innerDlg = new DlgConvenio();

                innerDlg.AdeudoTotal = adeudoTotal;
                innerDlg.Contrato = dlg.Contrato;
                innerDlg.PeriodoInicio = DateTime.Parse(dsCobro.Tables["RESUMEN"].Rows[0]["PeriodoInicio"].ToString());
                innerDlg.PeriodoFin = DateTime.Parse(dsCobro.Tables["RESUMEN"].Rows[0]["PeriodoFin"].ToString());

                if (innerDlg.ShowDialog() == DialogResult.OK)
                {
                    CargarConvenios();
                }

            }
        }

        private void btnModificarConvenio_Click(object sender, EventArgs e)
        {
            if (dgvConvenios.CurrentRow == null) return;

            DlgConvenio dlg = new DlgConvenio();

            dlg.Convenio = dgvConvenios.CurrentRow.DataBoundItem as Convenio;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarConvenios();
            }
        }

        private void btnCancelarConvenio_Click(object sender, EventArgs e)
        {
            Convenio convenio = dgvConvenios.CurrentRow?.DataBoundItem as Convenio;

            if (convenio == null) return;

            DialogResult mboxDlgResult = MessageBox.Show("¿Está seguro de que desea cancelar el convenio seleccionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (mboxDlgResult == DialogResult.Yes)
            {
                if (!convenio.Cancelar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar cancelar el convenio seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("El convenio seleccionado fue cancelado correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarConvenios();
            }
        }


    }
}

