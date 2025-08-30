using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgAsociarEstadosMunicipios : Form
    {

        public Estado Estado { get; set; }

        private List<Municipio> _municipiosAsociados, _municipiosDisponibles;

        public DlgAsociarEstadosMunicipios()
        {
            InitializeComponent();
        }

        private void DlgAsociarEstadosMunicipios_Load(object sender, EventArgs e)
        {
            txtEstado.Text = Estado.Nombre;

            _municipiosAsociados = new List<Municipio>(Municipio.GetMunicipiosAsociados(Estado.Id).OrderBy(c => c.Id).ToList());

            var municipiosExcluidos = new HashSet<int>(_municipiosAsociados.Select(c => c.Id));

            _municipiosDisponibles = Municipio.GetMunicipios().OrderBy(c => c.Id).ToList();

            dgvMunicipios.DataSource = _municipiosDisponibles.Where(c => !municipiosExcluidos.Contains(c.Id)).ToList();
            dgvMunicipiosAsociados.DataSource = _municipiosAsociados;

            dgvMunicipios.Columns["Id"].Visible = false;
            //dgvMunicipios.Columns["Codigo"].DefaultCellStyle.Format = "D4";
            dgvMunicipios.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgvMunicipiosAsociados.Columns["Id"].Visible = false;
            //dgvMunicipiosAsociados.Columns["Codigo"].DefaultCellStyle.Format = "D4";
            dgvMunicipiosAsociados.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvMunicipios.ClearSelection();
            dgvMunicipiosAsociados.ClearSelection();
        }

        private void FastRebind()
        {
            if (!string.IsNullOrWhiteSpace(txtMunicipio.Text))
            {
                dgvMunicipiosAsociados.DataSource = _municipiosAsociados.OrderBy(c => c.Id).ToList();
                var coloniasExcluidas = new HashSet<int>(_municipiosAsociados.Select(c => c.Id));

                dgvMunicipios.DataSource = _municipiosDisponibles.Where(c => !coloniasExcluidas.Contains(c.Id) &&
                                                                         c.Nombre.StartsWith(txtMunicipio.Text,
                                                                             StringComparison
                                                                                 .InvariantCultureIgnoreCase)).ToList();
            }
            else
            {
                dgvMunicipiosAsociados.DataSource = _municipiosAsociados.OrderBy(c => c.Id).ToList();
                var coloniasExcluidas = new HashSet<int>(_municipiosAsociados.Select(c => c.Id));
                dgvMunicipios.DataSource = _municipiosDisponibles.Where(c => !coloniasExcluidas.Contains(c.Id)).ToList();
            }
        }



        private void btnAgregarMunicipio_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvMunicipios.SelectedRows)
                {
                    _municipiosAsociados.Add(row.DataBoundItem as Municipio);
                }

                FastRebind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregarMunicipio_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarMunicipiosTodos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvMunicipios.SelectedRows)
                {
                    if (row.Index == -1) continue;

                    _municipiosAsociados.Add(row.DataBoundItem as Municipio);
                }

                FastRebind();
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnAgregarMunicipiosTodos_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarMunicipios_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvMunicipiosAsociados.SelectedRows)
                {
                    _municipiosAsociados.Remove(row.DataBoundItem as Municipio);
                }

                FastRebind();
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnQuitarMunicipios_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarMunicipiosTodos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvMunicipiosAsociados.SelectedRows)
                {
                    _municipiosAsociados.Remove(row.DataBoundItem as Municipio);
                }

                FastRebind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnQuitarMunicipiosTodos_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Municipio.EliminarMunicipiosPrevios(Estado.Id);

                foreach (DataGridViewRow row in dgvMunicipiosAsociados.Rows)
                {
                    Municipio municipio = row.DataBoundItem as Municipio;

                    if (!municipio.AsociarEstado(Estado.Id))
                    {
                        MessageBox.Show(
                            $"Hubo un error al intentar guardar el municipio {municipio.Nombre}. Intente nuevamente, si el problema persiste contacta al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Municipio.EliminarMunicipiosPrevios(Estado.Id);
                        break;
                    }
                }

                MessageBox.Show("Cambios guardados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAceptar_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Cancel;


        private void dgvMunicipios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                btnAgregarMunicipio.Enabled = true;
            }
        }

        private void dgvMunicipiosAsociados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                btnQuitarMunicipio.Enabled = true;
            }
        }

        private void dgvMunicipios_SelectionChanged(object sender, EventArgs e) => btnAgregarMunicipio.Enabled = dgvMunicipios.Rows.Count > 0;

        private void txtMunicipio_TextChanged(object sender, EventArgs e)
        {

            var municipiosExcluidos = new HashSet<int>(_municipiosAsociados.Select(c => c.Id));

            dgvMunicipios.DataSource = _municipiosDisponibles.Where(c => !municipiosExcluidos.Contains(c.Id) && c.Nombre.Contains(txtMunicipio.Text,
                StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private void dgvMunicipiosAsociados_SelectionChanged(object sender, EventArgs e) => btnQuitarMunicipio.Enabled = dgvMunicipiosAsociados.Rows.Count > 0;

    }
}

