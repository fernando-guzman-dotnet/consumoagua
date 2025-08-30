using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas
{
    public partial class FrmSituacionActualContratos : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        private DataTable _tblSituacionActualContratos { get; set; }

        public FrmSituacionActualContratos()
        {
            InitializeComponent();
        }

        private void FrmSituacionActualContratos_Load(object sender, EventArgs e) => CargarDgvSituacionActualContratos(chkUsarRespaldo.Checked);

        private void CargarDgvSituacionActualContratos(bool usarRespaldo = true)
        {
            if (usarRespaldo)
            {
                _tblSituacionActualContratos = Reporte.SituacionActualContratos();

                dgvSituacionActualContratos.DataSource = _tblSituacionActualContratos;

                dgvSituacionActualContratos.Columns["IdTarifa"].Visible = false;

                return;
            }

            _tblSituacionActualContratos = Reporte.SituacionActualContratos();

            MessageBox.Show("Espere, por favor.\n\n Se están calculando los adeudos rezagados para todos los contratos, este proceso podría tardar demasiado, dependiendo del número de contratos y los recursos de su computadora.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Cursor = Cursors.WaitCursor;

            //_tblSituacionActualContratos.Columns.Add("Rezagos", typeof(decimal));


            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            var dsCobroAgua = CalculoCobroAgua.CobroAgua.GetBulkResumenContratosByTarifa();

            stopWatch.Stop();

            foreach (DataRow fila in dsCobroAgua.Tables["RESUMEN"].Rows)
            {
                int idTarifaActual = int.Parse(fila["IdTarifa"].ToString());

                foreach (DataRow filaInterior in _tblSituacionActualContratos.Rows)
                {
                    int idTarifa = int.Parse(filaInterior["Id"].ToString());

                    if (idTarifaActual == idTarifa)
                    {
                        filaInterior["Rezagos"] = fila["RezagoTotal"];
                    }
                }
            }

            dgvSituacionActualContratos.DataSource = _tblSituacionActualContratos;

            if (dgvSituacionActualContratos.Columns["Id"] != null)
                dgvSituacionActualContratos.Columns["Id"].Visible = false;

            MessageBox.Show(
                $"La operación se completó en {stopWatch.Elapsed.Hours:D2} horas, {stopWatch.Elapsed.Minutes:D2} minutos y {stopWatch.Elapsed.Seconds:D2} segundos.",
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Cursor = Cursors.Default;
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_tblSituacionActualContratos == null || _tblSituacionActualContratos.Rows.Count == 0) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel (*.xls)|*.xls";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _tblSituacionActualContratos.ExportToExcel(dlg.FileName);
            }
        }

        private void chkCalcularEnTiempoReal_CheckedChanged(object sender, EventArgs e)
        {
            if (!_frmShown) return;

            CargarDgvSituacionActualContratos(chkUsarRespaldo.Checked);
        }

        private bool _frmShown;
        private void FrmSituacionActualContratos_Shown(object sender, EventArgs e)
        {
            _frmShown = true;
        }
    }
}

