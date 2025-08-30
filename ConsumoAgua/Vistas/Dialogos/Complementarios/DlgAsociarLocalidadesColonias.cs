using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgAsociarLocalidadesColonias : Form
    {

        public Localidad Localidad { get; set; }

        private List<Colonia> _coloniasAsociadas, _coloniasDisponibles;

        public DlgAsociarLocalidadesColonias()
        {
            InitializeComponent();
        }

        private void DlgAsociarSectoresColonias_Load(object sender, EventArgs e)
        {
            txtLocalidad.Text = Localidad.Nombre;

            _coloniasAsociadas = new List<Colonia>(Colonia.GetColoniasAsociadas(Localidad.Id).OrderBy(c => c.Id).ToList());

            var coloniasExcluidas = new HashSet<int>(_coloniasAsociadas.Select(c => c.Id));

            _coloniasDisponibles = new List<Colonia>(Colonia.GetColonias())
                .OrderBy(c => c.Id).ToList();

            dgvColonias.DataSource = _coloniasDisponibles.Where(c => !coloniasExcluidas.Contains(c.Id)).ToList();
            dgvColoniasAsociadas.DataSource = _coloniasAsociadas;

            dgvColonias.Columns["Id"].Visible = false;
            //dgvColonias.Columns["Codigo"].DefaultCellStyle.Format = "D4";
            dgvColonias.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgvColoniasAsociadas.Columns["Id"].Visible = false;
            //dgvColoniasAsociadas.Columns["Codigo"].DefaultCellStyle.Format = "D4";
            dgvColoniasAsociadas.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvColonias.ClearSelection();
            dgvColoniasAsociadas.ClearSelection();
        }

        private void FastRebind()
        {
            if (!string.IsNullOrWhiteSpace(txtColoniaBuscar.Text))
            {
                dgvColoniasAsociadas.DataSource = _coloniasAsociadas.OrderBy(c => c.Id).ToList();
                var coloniasExcluidas = new HashSet<int>(_coloniasAsociadas.Select(c => c.Id));

                dgvColonias.DataSource = _coloniasDisponibles.Where(c => !coloniasExcluidas.Contains(c.Id) &&
                                                                         c.Descripcion.StartsWith(txtColoniaBuscar.Text,
                                                                             StringComparison
                                                                                 .InvariantCultureIgnoreCase)).ToList();
            }
            else
            {
                dgvColoniasAsociadas.DataSource = _coloniasAsociadas.OrderBy(c => c.Id).ToList();
                var coloniasExcluidas = new HashSet<int>(_coloniasAsociadas.Select(c => c.Id));
                dgvColonias.DataSource = _coloniasDisponibles.Where(c => !coloniasExcluidas.Contains(c.Id)).ToList();
            }
        }



        private void btnAgregarColonia_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvColonias.SelectedRows)
                {
                    _coloniasAsociadas.Add(row.DataBoundItem as Colonia);
                }

                FastRebind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregarColonia_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarColoniasTodas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvColonias.SelectedRows)
                {
                    if (row.Index == -1) continue;

                    _coloniasAsociadas.Add(row.DataBoundItem as Colonia);
                }

                FastRebind();
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnAgregarColoniasTodas_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarColonia_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvColoniasAsociadas.SelectedRows)
                {
                    _coloniasAsociadas.Remove(row.DataBoundItem as Colonia);
                }

                FastRebind();
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnQuitarColonia_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarColoniasTodas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvColoniasAsociadas.SelectedRows)
                {
                    _coloniasAsociadas.Remove(row.DataBoundItem as Colonia);
                }

                FastRebind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnQuitarColoniasTodas_Click - " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Colonia.EliminarColoniasPrevias(Localidad.Id);

                foreach (DataGridViewRow row in dgvColoniasAsociadas.Rows)
                {
                    Colonia colonia = row.DataBoundItem as Colonia;

                    if (!colonia.AsociarLocalidad(Localidad.Id))
                    {
                        MessageBox.Show(
                            $"Hubo un error al intentar guardar la colonia {colonia.Descripcion}. Intente nuevamente, si el problema persiste contacta al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Colonia.EliminarColoniasPrevias(Localidad.Id);
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


        private void dgvColonias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                btnAgregarColonia.Enabled = true;
            }
        }

        private void dgvColoniasAsociadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                btnQuitarColonia.Enabled = true;
            }
        }

        private void dgvColonias_SelectionChanged(object sender, EventArgs e) => btnAgregarColonia.Enabled = dgvColonias.Rows.Count > 0;

        private void txtColoniaBuscar_TextChanged(object sender, EventArgs e)
        {

            var coloniasExcluidas = new HashSet<int>(_coloniasAsociadas.Select(c => c.Id));

            dgvColonias.DataSource = _coloniasDisponibles.Where(c => !coloniasExcluidas.Contains(c.Id) && c.Descripcion.Contains(txtColoniaBuscar.Text,
                StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private void dgvColoniasAsociadas_SelectionChanged(object sender, EventArgs e) => btnQuitarColonia.Enabled = dgvColoniasAsociadas.Rows.Count > 0;

    }
}

