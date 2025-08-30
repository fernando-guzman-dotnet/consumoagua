using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgSeleccionarCuenta : Form
    {
        public bool SoloServicioMedido { get; set; }
        public Contrato Contrato { get; set; }

        private List<Contrato> _contratos;

        public DlgSeleccionarCuenta()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ActiveControl == txtUsuario)
            {
                if (keyData == Keys.Enter)
                {
                    txtDireccion.ResetText();
                    txtNoContrato.ResetText();

                    if (string.IsNullOrWhiteSpace(txtUsuario.Text)) return true;

                    _contratos = Contrato.GetContratosByParams(txtUsuario.Text);

                    if(SoloServicioMedido)
                        _contratos = _contratos.Where(c => (Contrato.Tipo)c.IdTipoContrato == Contrato.Tipo.ServicioMedido).ToList();

                    dgvContratos.DataSource = _contratos;

                    DarFormatoDgv();
                    return true;
                }
            }

            if (ActiveControl == txtNoContrato)
            {
                if (keyData == Keys.Enter)
                {
                    txtUsuario.ResetText();
                    txtDireccion.ResetText();

                    if (string.IsNullOrWhiteSpace(txtNoContrato.Text)) return true;

                    _contratos = Contrato.GetContratosByParams(noContrato: int.Parse(txtNoContrato.Text));

                    if (SoloServicioMedido)
                        _contratos = _contratos.Where(c => (Contrato.Tipo)c.IdTipoContrato == Contrato.Tipo.ServicioMedido).ToList();

                    dgvContratos.DataSource = _contratos;

                    DarFormatoDgv();

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

            if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                contratosFiltrados = _contratos.Where(c =>
                    c.NombreUsuario.Contains(txtUsuario.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Luego por dirección

            if (!string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                contratosFiltrados = _contratos.Where(c =>
                    c.Direccion.Contains(txtDireccion.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Luego por no contrato

            if (!string.IsNullOrWhiteSpace(txtNoContrato.Text))
            {
                contratosFiltrados = _contratos.Where(c =>
                    c.Direccion.Contains(txtNoContrato.Text, StringComparison.OrdinalIgnoreCase)).ToList(); ;
            }

            dgvContratos.DataSource = contratosFiltrados;
            DarFormatoDgv();
            DarFormatoContratosInactivos();
        }



        private void DarFormatoDgv()
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
            dgvContratos.Columns["Manzana"].Visible = false;
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
            dgvContratos.Columns["Activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == -1 && e.RowIndex == -1) return;

                if (dgvContratos.CurrentRow == null) return;

                Contrato = dgvContratos.CurrentRow.DataBoundItem as Contrato;

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show("dataUsuarios_CellDoubleClick - " + ex.Message, "Formulario Dialog_SeleccionarUsuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContratos.SelectedRows.Count == 0) return;

                Contrato = dgvContratos.SelectedRows[0].DataBoundItem as Contrato;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAceptar_Click - " + ex.Message, "Formulario Dialog_SeleccionarUsuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNoContrato_TextChanged(object sender, EventArgs e) => FastFilter();
        private void txtDireccion_TextChanged(object sender, EventArgs e) => FastFilter();
        private void txtUsuario_TextChanged(object sender, EventArgs e) => FastFilter();

        private void DlgSeleccionarCuenta_Load(object sender, EventArgs e)
        {
            _contratos = SoloServicioMedido 
                ? Contrato.GetContratos().Where(c => (Contrato.Tipo)c.IdTipoContrato == Contrato.Tipo.ServicioMedido).ToList() 
                : Contrato.GetContratos();

            dgvContratos.DataSource = _contratos;
            DarFormatoDgv();
        }

        private void DarFormatoContratosInactivos()
        {
            // Poner fondo rojo a las celdas de las filas de contratos inactivos

            foreach (DataGridViewRow fila in dgvContratos.Rows)
            {
                bool activo = bool.Parse(fila.Cells["Activo"].Value.ToString());

                if (activo)
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                    continue;
                }

                fila.DefaultCellStyle.BackColor = Color.Red;
            }
        }


        private void dgvContratos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowCount == 0) return;

            DarFormatoContratosInactivos();
        }
    }
}

