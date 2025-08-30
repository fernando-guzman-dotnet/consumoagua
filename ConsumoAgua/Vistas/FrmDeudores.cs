using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Reportes;

namespace SAPA.Vistas
{
    public partial class FrmDeudores : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }
        private DataTable tblDeudores { get; set; }

        public FrmDeudores()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void FrmDeudores_Load(object sender, EventArgs e)
        {
            CargarColonias();
            CargarDeudoresGuardados();
        }

        private void CargarDeudoresGuardados()
        {
            var deudores = Reporte.GetDeudores();

            dgvDeudores.DataSource = deudores;

            dgvDeudores.Columns["NoContrato"].DefaultCellStyle.Format = "D10";
            dgvDeudores.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDeudores.Columns["AdeudoTotal"].DefaultCellStyle.Format = "N2";
        }

        private void CargarColonias()
        {
            var colonias = Colonia.GetColonias();

            if (colonias.Count > 0)
            {
                colonias.Insert(0, new Colonia {Id =  0, Descripcion = "[ -- SELECCIONE UNA COLONIA -- ]"});

                cmbColonias.DataSource = colonias;
                cmbColonias.DisplayMember = "Descripcion";
                cmbColonias.ValueMember = "Id";
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            var dsBulkContratosDeudores =
                CalculoCobroAgua.CobroAgua.GetBulkContratosDeudores(chkUsarFiltroExperimental.Checked, (int)cmbColonias.SelectedValue);

            stopWatch.Stop();

            if (dsBulkContratosDeudores.Tables["RESUMEN"] == null || dsBulkContratosDeudores.Tables["RESUMEN"].Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron deudores con los filtro aplicados.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tblDeudores = dsBulkContratosDeudores.Tables["RESUMEN"];

            dgvDeudores.DataSource = tblDeudores;

            dgvDeudores.Columns["NoContrato"].DefaultCellStyle.Format = "D10";
            dgvDeudores.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDeudores.Columns["AdeudoTotal"].DefaultCellStyle.Format = "N2";

            MessageBox.Show(
                $"La operación se completó en {stopWatch.Elapsed.Hours:D2} horas, {stopWatch.Elapsed.Minutes:D2} minutos y {stopWatch.Elapsed.Seconds:D2} segundos. ({dgvDeudores.Rows.Count} registros generados)",
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if ((int)cmbColonias.SelectedValue == 0)
            {
                Reporte.LimpiarDeudores();
                Reporte.CargarBulkDeudores(tblDeudores, OnSqlRowsCopied);
            }
        }


        private void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            MessageBox.Show(
                $"Los datos generados se han guardado, se cargarán automaticamente la proxima vez que se abra el formulario. ({e.RowsCopied} filas guardadas)",
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (tblDeudores == null || tblDeudores.Rows.Count == 0) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel (*.xls)|*.xls";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tblDeudores.ExportToExcel(dlg.FileName);
            }
        }
    }
}

