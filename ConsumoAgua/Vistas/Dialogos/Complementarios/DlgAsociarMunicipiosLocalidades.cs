using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgAsociarMunicipiosLocalidades : Form
    {
        public Municipio Municipio { get; set; }

        private List<Localidad> _localidadesAsociadas, _localidadesDisponibles;

        public DlgAsociarMunicipiosLocalidades()
        {
            InitializeComponent();
        }

        private void DlgAsociarMunicipiosLocalidades_Load(object sender, EventArgs e)
        {
            txtMunicipio.Text = Municipio.Nombre;

            _localidadesAsociadas = new List<Localidad>(Localidad.GetLocalidadesAsociadas(Municipio.Id).OrderBy(c => c.Id).ToList());

            var localidadesExcluidas = new HashSet<int>(_localidadesAsociadas.Select(c => c.Id));

            _localidadesDisponibles = new List<Localidad>(Localidad.GetLocalidades())
                .OrderBy(c => c.Id).ToList();

            dgvLocalidades.DataSource = _localidadesDisponibles.Where(c => !localidadesExcluidas.Contains(c.Id)).ToList();
            dgvLocalidadesAsociadas.DataSource = _localidadesAsociadas;

            dgvLocalidades.Columns["Id"].Visible = false;
            //dgvLocalidades.Columns["Codigo"].DefaultCellStyle.Format = "D4";
            dgvLocalidades.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgvLocalidadesAsociadas.Columns["Id"].Visible = false;
            //dgvLocalidadesAsociadas.Columns["Codigo"].DefaultCellStyle.Format = "D4";
            dgvLocalidadesAsociadas.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvLocalidades.ClearSelection();
            dgvLocalidadesAsociadas.ClearSelection();
        }

        private void FastRebind()
        {
            if (!string.IsNullOrWhiteSpace(txtLocalidad.Text))
            {
                dgvLocalidadesAsociadas.DataSource = _localidadesAsociadas.OrderBy(c => c.Id).ToList();
                var coloniasExcluidas = new HashSet<int>(_localidadesAsociadas.Select(c => c.Id));

                dgvLocalidades.DataSource = _localidadesDisponibles.Where(c => !coloniasExcluidas.Contains(c.Id) &&
                                                                         c.Nombre.StartsWith(txtLocalidad.Text,
                                                                             StringComparison
                                                                                 .InvariantCultureIgnoreCase)).ToList();
            }
            else
            {
                dgvLocalidadesAsociadas.DataSource = _localidadesAsociadas.OrderBy(c => c.Id).ToList();
                var coloniasExcluidas = new HashSet<int>(_localidadesAsociadas.Select(c => c.Id));
                dgvLocalidades.DataSource = _localidadesDisponibles.Where(c => !coloniasExcluidas.Contains(c.Id)).ToList();
            }
        }



        private void btnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvLocalidades.SelectedRows)
                {
                    _localidadesAsociadas.Add(row.DataBoundItem as Localidad);
                }

                FastRebind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAddColonia_Click - " + ex.Message, "Formulario Dialog_AsociarSectores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarLocalidadesTodas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvLocalidades.SelectedRows)
                {
                    if (row.Index == -1) continue;

                    _localidadesAsociadas.Add(row.DataBoundItem as Localidad);
                }

                FastRebind();
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnAddColoniasTodas_Click - " + ex.Message, "Formulario Dialog_AsociarSectores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarLocalidad_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvLocalidadesAsociadas.SelectedRows)
                {
                    _localidadesAsociadas.Remove(row.DataBoundItem as Localidad);
                }

                FastRebind();
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnRemoveColonia_Click - " + ex.Message, "Formulario Dialog_AsociarSectores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarLocalidadesTodas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvLocalidadesAsociadas.SelectedRows)
                {
                    _localidadesAsociadas.Remove(row.DataBoundItem as Localidad);
                }

                FastRebind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnRemoveColoniasTodas_Click - " + ex.Message, "Formulario Dialog_AsociarSectores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Localidad.EliminarLocalidadesPrevias(Municipio.Id);

                foreach (DataGridViewRow row in dgvLocalidadesAsociadas.Rows)
                {
                    Localidad localidad = row.DataBoundItem as Localidad;

                    if (!localidad.AsociarMunicipio(Municipio.Id))
                    {
                        MessageBox.Show(
                            $"Hubo un error al intentar guardar la colonia {localidad.Nombre}. Intente nuevamente, si el problema persiste contacta al área de soporte de SAPA.",
                            "Formulario Asociar Sectores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Localidad.EliminarLocalidadesPrevias(Municipio.Id);
                        break;
                    }
                }

                MessageBox.Show("Cambios guardados correctamente", "Formulario Asociar Sectores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAdd_Click - " + ex.Message, "Formulario Dialog_AsociarSectores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Cancel;


        private void dgvLocalidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                btnAgregarLocalidad.Enabled = true;
            }
        }

        private void dgvLocalidadesAsociadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                btnQuitarLocalidad.Enabled = true;
            }
        }

        private void dgvLocalidades_SelectionChanged(object sender, EventArgs e) => btnAgregarLocalidad.Enabled = dgvLocalidades.Rows.Count > 0;

        private void txtLocalidad_TextChanged(object sender, EventArgs e)
        {

            var localidadesExcluidas = new HashSet<int>(_localidadesAsociadas.Select(c => c.Id));

            dgvLocalidades.DataSource = _localidadesDisponibles.Where(c => !localidadesExcluidas.Contains(c.Id) && c.Nombre.Contains(txtLocalidad.Text,
                StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private void dgvLocalidadesAsociadas_SelectionChanged(object sender, EventArgs e) => btnQuitarLocalidad.Enabled = dgvLocalidadesAsociadas.Rows.Count > 0;

    }
}

