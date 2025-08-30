using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgAsociarColoniasCalles : Form
    {

        public Colonia Colonia { get; set; }

        private List<Calle> _callesAsociadas, _callesDisponibles;

        public DlgAsociarColoniasCalles()
        {
            InitializeComponent();
        }

        private void DlgAsociarColoniasCalles_Load(object sender, EventArgs e)
        {
            txtColonia.Text = Colonia.Descripcion;

            _callesAsociadas = new List<Calle>(Colonia.GetCallesAsociadas(Colonia.Id).OrderBy(c => c.Id).ToList());

            var callesExcluidas = new HashSet<int>(_callesAsociadas.Select(c => c.Id));

            _callesDisponibles = new List<Calle>(Calle.GetCalles())
                .OrderBy(c => c.Id).ToList();

            dgvCallesDisponibles.DataSource = _callesDisponibles.Where(c => !callesExcluidas.Contains(c.Id)).ToList();
            dgvCallesAsociadas.DataSource = _callesAsociadas;

            dgvCallesDisponibles.Columns["Id"].Visible = false;

            dgvCallesDisponibles.Columns["CodigoPostal"].Visible = false;

            dgvCallesDisponibles.Columns["Codigo"].DefaultCellStyle.Format = "D4";
            dgvCallesDisponibles.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvCallesDisponibles.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgvCallesAsociadas.Columns["Id"].Visible = false;
            dgvCallesAsociadas.Columns["Id"].ReadOnly = true;

            dgvCallesAsociadas.Columns["Codigo"].DefaultCellStyle.Format = "D4";

            dgvCallesAsociadas.Columns["Codigo"].ReadOnly = true;
            dgvCallesAsociadas.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvCallesAsociadas.Columns["Descripcion"].ReadOnly = true;
            dgvCallesAsociadas.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            (dgvCallesAsociadas.Columns["CodigoPostal"] as DataGridViewTextBoxColumn).MaxInputLength = 5;

            dgvCallesDisponibles.ClearSelection();
            dgvCallesAsociadas.ClearSelection();
        }

        private void FastRebind()
        {
            if (!string.IsNullOrWhiteSpace(txtCalleBuscar.Text))
            {
                dgvCallesAsociadas.DataSource = _callesAsociadas.OrderBy(c => c.Id).ToList();
                var callesExcluidas = new HashSet<int>(_callesAsociadas.Select(c => c.Id));

                dgvCallesDisponibles.DataSource = _callesDisponibles.Where(c => !callesExcluidas.Contains(c.Id) &&
                                                                         c.Descripcion.StartsWith(txtCalleBuscar.Text,
                                                                             StringComparison
                                                                                 .InvariantCultureIgnoreCase)).ToList();
            }
            else
            {
                dgvCallesAsociadas.DataSource = _callesAsociadas.OrderBy(c => c.Id).ToList();
                var coloniasExcluidas = new HashSet<int>(_callesAsociadas.Select(c => c.Id));
                dgvCallesDisponibles.DataSource = _callesDisponibles.Where(c => !coloniasExcluidas.Contains(c.Id)).ToList();
            }
        }


        private void btnAgregarCalle_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvCallesDisponibles.SelectedRows)
                {
                    _callesAsociadas.Add(row.DataBoundItem as Calle);
                }

                FastRebind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregarCalle_Click - " + ex.Message, "Formulario Dialog_AsociarSectores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarCalle_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvCallesAsociadas.SelectedRows)
                {
                    _callesAsociadas.Remove(row.DataBoundItem as Calle);
                }

                FastRebind();
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnQuitarCalle_Click - " + ex.Message, "Formulario Dialog_AsociarSectores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Colonia.EliminarCallesPrevias(Colonia.Id);

                foreach (DataGridViewRow row in dgvCallesAsociadas.Rows)
                {
                    Calle calle = row.DataBoundItem as Calle;

                    if (!Colonia.AsociarCalle(Colonia.Id, calle))
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar asociar las colonias a la calle. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                }

                MessageBox.Show("Cambios guardados correctamente", "Formulario Asociar Sectores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAceptar_Click - " + ex.Message, "Formulario Dialog_AsociarSectores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Cancel;

        private void dgvColonias_SelectionChanged(object sender, EventArgs e) => btnAgregarCalle.Enabled = dgvCallesDisponibles.Rows.Count > 0;

        private void txtColoniaBuscar_TextChanged(object sender, EventArgs e)
        {

            var coloniasExcluidas = new HashSet<int>(_callesAsociadas.Select(c => c.Id));

            dgvCallesDisponibles.DataSource = _callesDisponibles.Where(c => !coloniasExcluidas.Contains(c.Id) && c.Descripcion.Contains(txtCalleBuscar.Text,
                StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private void dgvColoniasAsociadas_SelectionChanged(object sender, EventArgs e) => btnQuitarCalle.Enabled = dgvCallesAsociadas.Rows.Count > 0;

        private void dgvColoniasAsociadas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= CodigoPostal_KeyPress;

            if (dgvCallesAsociadas.CurrentCell.ColumnIndex == dgvCallesAsociadas.Columns.IndexOf(dgvCallesAsociadas.Columns["CodigoPostal"]))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += CodigoPostal_KeyPress;
                }
            }
        }

        private void CodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}

