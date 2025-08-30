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
    public partial class PnlContrato : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }
        private List<Contrato> _contratos;

        public PnlContrato()
        {
            InitializeComponent();
        }

        private void CargarContratos()
        {
            _contratos = Contrato.GetContratos();
            dgvContratos.DataSource = _contratos;
            FormatearDgvContratos();
        }

        public void FormatearDgvContratos()
        {
            dgvContratos.Columns["Id"].Visible = false;
            dgvContratos.Columns["NoContrato"].HeaderText = "No. de Contrato";
            dgvContratos.Columns["NoContrato"].DefaultCellStyle.Format = "D10";
            dgvContratos.Columns["NoContrato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContratos.Columns["IdUsuario"].Visible = false;
            dgvContratos.Columns["NombreUsuario"].HeaderText = "Usuario";
            dgvContratos.Columns["NombreUsuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContratos.Columns["Direccion"].HeaderText = "Dirección del Contrato";
            dgvContratos.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContratos.Columns["IdTipoVivienda"].Visible = false;
            dgvContratos.Columns["IdTipoContrato"].Visible = false;
            dgvContratos.Columns["IdTarifa"].Visible = false;
            dgvContratos.Columns["IdEstado"].Visible = false;
            dgvContratos.Columns["IdLocalidad"].Visible = false;
            dgvContratos.Columns["IdMunicipio"].Visible = false;
            dgvContratos.Columns["IdSeccion"].Visible = false;
            dgvContratos.Columns["IdSector"].Visible = false;
            dgvContratos.Columns["IdColonia"].Visible = false;
            dgvContratos.Columns["IdCalle"].Visible = false;
            dgvContratos.Columns["CodigoPostal"].Visible = false;
            dgvContratos.Columns["NumeroExterior"].Visible = false;
            dgvContratos.Columns["NumeroInterior"].Visible = false;


            dgvContratos.Columns["DescripcionTipoVivienda"].HeaderText = "Tipo de Vivienda";
            dgvContratos.Columns["DescripcionTipoContrato"].HeaderText = "Tipo de Contrato";
            dgvContratos.Columns["NombreTarifa"].HeaderText = "Tarifa";
            dgvContratos.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ActiveControl == tsTxtUsuario.Control)
            {
                if (keyData == Keys.Enter)
                {
                    _contratos = Contrato.GetContratosByParams(tsTxtUsuario.Text);
                    dgvContratos.DataSource = _contratos;

                    FormatearDgvContratos();

                    dgvContratos.ClearSelection();

                    return true;
                }
            }

            if (ActiveControl == tsTxtNoContrato.Control)
            {
                if (keyData == Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(tsTxtNoContrato.Text))
                    {
                        _contratos = Contrato.GetContratos();
                        dgvContratos.DataSource = _contratos;

                        FormatearDgvContratos();
                        dgvContratos.ClearSelection();

                        return true;
                    }

                    int noContrato;

                    if (!int.TryParse(tsTxtNoContrato.Text, out noContrato))
                        return true;

                    _contratos = Contrato.GetContratosByParams(noContrato: int.Parse(tsTxtNoContrato.Text));
                    dgvContratos.DataSource = _contratos;

                    FormatearDgvContratos();

                    dgvContratos.ClearSelection();

                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void FastFilter()
        {

            if (_contratos == null) return;


            List<Contrato> contratosFiltrados = _contratos;

            //  Filtramos primero por nombre el nombre completo

            if (!string.IsNullOrWhiteSpace(tsTxtUsuario.Text))
            {
                contratosFiltrados = _contratos.Where(c =>
                    c.NombreUsuario.Contains(tsTxtUsuario.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Luego por dirección

            if (!string.IsNullOrWhiteSpace(tsTxtDireccion.Text))
            {
                contratosFiltrados = _contratos.Where(c =>
                    c.Direccion.Contains(tsTxtDireccion.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Luego por no contrato

            if (!string.IsNullOrWhiteSpace(tsTxtNoContrato.Text))
            {
                contratosFiltrados = _contratos.Where(c =>
                    c.NoContrato.ToString().Contains(tsTxtNoContrato.Text, StringComparison.OrdinalIgnoreCase)).ToList(); ;
            }

            dgvContratos.DataSource = contratosFiltrados;
        }

        private void btnAgregarContrato_Click(object sender, EventArgs e)
        {
            DlgContrato dlg = new DlgContrato();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _contratos = Contrato.GetContratosByParams(noContrato: dlg.Contrato.NoContrato);
                dgvContratos.DataSource = _contratos;

                FormatearDgvContratos();
            }
        }

        private void btnEditarContrato_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContratos.CurrentRow == null || dgvContratos.Rows.Count == 0) return;

                DlgContrato dlg = new DlgContrato();

                dlg.Contrato = dgvContratos.CurrentRow.DataBoundItem as Contrato;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _contratos = Contrato.GetContratosByParams(noContrato: dlg.Contrato.NoContrato);
                    dgvContratos.DataSource = _contratos;

                    FormatearDgvContratos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEdit_Click - " + ex.Message, "Formulario Panel_Contrato", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void dgvContratos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 && e.ColumnIndex == -1) return;
                
                // Mostrar históricos
            }
            catch (Exception ex)
            {
                MessageBox.Show("dgvContratos_CellDoubleClick - " + ex.Message, "Formulario Contrato",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PnlContrato_Load(object sender, EventArgs e) => CargarContratos();

        private void tsTxtUsuario_TextChanged(object sender, EventArgs e) => FastFilter();
        private void tsTxtDireccion_TextChanged(object sender, EventArgs e) => FastFilter();
        private void tsTxtNoContrato_TextChanged(object sender, EventArgs e) => FastFilter();

        private void tsmVerOrdenesTrabajo_Click(object sender, EventArgs e)
        {
            if (dgvContratos.CurrentRow == null || dgvContratos.Rows.Count == 0) return;

            var contrato = dgvContratos.CurrentRow.DataBoundItem as Contrato;

            if (FrmPrincipal.TabExists("Ordenes de Trabajo", false))
            {
                // Ya hay un pestaña abierta del módulo "Ordenes de Trabajo"
                
                // Consultamos al usuario si quiere cerrarla para abrir otra con el filtro necesario

                var dialogResult = MessageBox.Show(
                    "Actualmente hay una pestaña abierta para el módulo \"Ordenes de Trabajo\". Realizar esta acción cerrará la pestaña actual, ¿desea continuar de todos modos?",
                    this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                // El usuario no quiere cerrarla, cancelamos la acción
                if(dialogResult == DialogResult.No) return;


                // Si aceptó, cerramos la paestaña "Ordenes de Trabajo"

                for (int i = 0; i < FrmPrincipal.tabManager.TabPages.Count; i++)
                {
                    if (FrmPrincipal.tabManager.TabPages[i].Text.Equals("Ordenes de Trabajo", StringComparison.OrdinalIgnoreCase))
                    {
                        FrmPrincipal.tabManager.TabPages.RemoveAt(i);
                        break;
                    }
                }

                // Reabrimos la pestaña pasando como parametro el no. de contrato que deseamos buscar
                TabPage t = new TabPage("Ordenes de Trabajo");
                t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                FrmPrincipal.tabManager.TabPages.Add(t);
                FrmPrincipal.tabManager.SelectedTab = t;

                PnlOrdenesTrabajo pnl = new PnlOrdenesTrabajo();
                pnl.FrmPrincipal = FrmPrincipal;
                pnl.NoContrato = contrato.NoContrato;
                pnl.TopLevel = false;
                pnl.Parent = t;
                pnl.Show();
            }
            else
            {
                // Caso contrario...
                // Solo abrimos la pestaña pasando como parametro el no. de contrato que deseamos buscar

                TabPage t = new TabPage("Ordenes de Trabajo");
                t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                FrmPrincipal.tabManager.TabPages.Add(t);
                FrmPrincipal.tabManager.SelectedTab = t;

                PnlOrdenesTrabajo pnl = new PnlOrdenesTrabajo();
                pnl.FrmPrincipal = FrmPrincipal;
                pnl.NoContrato = contrato.NoContrato;
                pnl.TopLevel = false;
                pnl.Parent = t;
                pnl.Show();
            }


        }

        private void tsmAplicarDescuento_Click(object sender, EventArgs e)
        {
            if (dgvContratos.CurrentRow == null || dgvContratos.Rows.Count == 0) return;

            var contrato = dgvContratos.CurrentRow.DataBoundItem as Contrato;

            DlgAplicarDescuento dlg = new DlgAplicarDescuento();
            dlg.Contrato = contrato;
            dlg.ShowDialog();
        }
    }
}

