using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgSeleccionarContratoPagosUltimaSemana : Form
    {
        public Contrato Contrato { get; set; }

        private DataTable _pagosUltimaSemana { get; set; }

        public DlgSeleccionarContratoPagosUltimaSemana()
        {
            InitializeComponent();
        }

        private void DlgSeleccionarContratoPagosUltimaSemana_Load(object sender, EventArgs e)
        {
            _pagosUltimaSemana = Reporte.GetPagosUltimaSemana();

            if (_pagosUltimaSemana.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se han realizado pagos durante esta semana. Solamente se pueden seleccionar contratos que han realizado pagos dentro de la última semana.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
                return;
            }

            dgvUltimosPagos.DataSource = _pagosUltimaSemana;

            try
            {
                dgvUltimosPagos.Columns["Folio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvUltimosPagos.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvUltimosPagos.Columns["NoContrato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvUltimosPagos.Columns["AdeudoTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvUltimosPagos.Columns["Otros"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvUltimosPagos.Columns["PeriodoInicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvUltimosPagos.Columns["PeriodoFin"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvUltimosPagos.Columns["NoContrato"].HeaderText = "No. Contrato";
                dgvUltimosPagos.Columns["AdeudoTotal"].HeaderText = "Importe";
                dgvUltimosPagos.Columns["PeriodoInicio"].HeaderText = "Periodo Inicio";
                dgvUltimosPagos.Columns["PeriodoFin"].HeaderText = "Periodo Fin";

                dgvUltimosPagos.Columns["Folio"].DefaultCellStyle.Format = "D5";
                dgvUltimosPagos.Columns["NoContrato"].DefaultCellStyle.Format = "D10";
                dgvUltimosPagos.Columns["PeriodoInicio"].DefaultCellStyle.Format = "MMM yy";
                dgvUltimosPagos.Columns["PeriodoFin"].DefaultCellStyle.Format = "MMM yy";
            }
            catch (Exception)
            {
                // Descartar excepciones por columnas nulas
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvUltimosPagos.CurrentRow == null || dgvUltimosPagos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se ha seleccionado un pago. Seleccione uno e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Int32 noContrato = Int32.Parse(dgvUltimosPagos.SelectedRows[0].Cells["NoContrato"].Value.ToString());

            Contrato = Contrato.GetContrato(noContrato);

            DialogResult = DialogResult.OK;
        }
    }
}

