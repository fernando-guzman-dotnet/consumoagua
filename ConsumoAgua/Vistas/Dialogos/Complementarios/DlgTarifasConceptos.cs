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
    public partial class DlgTarifasConceptos : Form
    {
        public DlgTarifasConceptos()
        {
            InitializeComponent();
        }

        public Tarifa Tarifa { get; set; }

        private void DlgTarifasConceptos_Load(object sender, EventArgs e)
        {
            
            CargarDgvCmbConceptos();
            if (Tarifa.Id > 0)
            {
                txtTarifaActual.Text = Tarifa.Descripcion;
                CargarTarifasConceptos(Tarifa.Id);
            }
            else
            {
                MessageBox.Show(
                    "No se cargó una tarifa. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDgv()) return;

            Tarifa.EliminarConceptos();


            foreach (DataGridViewRow row in dgvTarifasConceptos.Rows)
            {
                if (row.IsNewRow) continue;

                int idConcepto = int.Parse(row.Cells["TarifaConcepto"].Value.ToString());
                decimal cantidad = int.Parse(row.Cells["Cantidad"].Value.ToString());

                if (!Tarifa.AgregarConcepto(idConcepto, cantidad))
                {
                    MessageBox.Show(
                        "Hubo un error al intentar guardar los conceptos para la tarifa. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
            }

            MessageBox.Show("Los conceptos fueron agregados a la tarifa correctamente.", this.Text, MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;

        }

        private bool ValidarDgv()
        {
            if (dgvTarifasConceptos.Rows.Count == 0)
            {
                MessageBox.Show("No se ha agregado ningún concepto para la tarifa. Agregue una e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dgvTarifasConceptos.Rows.Count == 1 && dgvTarifasConceptos.Rows[0].IsNewRow)
            {
                MessageBox.Show("No se ha agregado ningún concepto para la tarifa. Agregue uno e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            List<int> conceptos = new List<int>();

            foreach (DataGridViewRow row in dgvTarifasConceptos.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["TarifaConcepto"].Value == null)
                {
                    MessageBox.Show(
                        "No se seleccionó el concepto de la tarifa en alguna fila. Seleccione uno e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                conceptos.Add(int.Parse(row.Cells["TarifaConcepto"].Value.ToString()));

                if(string.IsNullOrWhiteSpace(row.Cells["Cantidad"].Value.ToString()))
                {
                    MessageBox.Show(
                        "La cantidad del concepto de la tarifa no puede estar vacía. Revise el campo en alguna fila e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                try
                {
                    var cantidad = decimal.Parse(row.Cells["Cantidad"].Value.ToString());

                    if (cantidad < 0)
                    {
                        MessageBox.Show(
                            "La cantidad del concepto de la tarifa no debe ser negativo. Revise el campo en alguna fila e intente nuevamente.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(
                        "La cantidad del concepto de la tarifa debe ser ingresada como un número. Revise el campo en alguna fila e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (OverflowException)
                {
                    MessageBox.Show($"La cantidad del concepto ({row.Cells["Cantidad"].Value}) no es válida. Revise el campo en alguna fila e intente nuevamente.");
                    return false;
                }
            }

            var dummyHash = new HashSet<int>();
            var conceptosDuplicados = conceptos.Where(item => !dummyHash.Add(item)).Distinct().ToList();

            if (conceptosDuplicados.Count > 0)
            {
                MessageBox.Show(
                    "No puede haber conceptos duplicados en la tarifa. Remueva los duplicados e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void CargarTarifasConceptos(int idTarifa)
        {
            var tarifasConceptos = Tarifa.GetTarifaConceptos(idTarifa);
            dgvTarifasConceptos.DataSource = tarifasConceptos;
        }

        private void CargarDgvCmbConceptos()
        {
            DataGridViewComboBoxColumn cmbConceptos = dgvTarifasConceptos.Columns["TarifaConcepto"] as DataGridViewComboBoxColumn;

            var conceptos = Concepto.GetConceptos().OrderBy(c => c.Descripcion).ToList();

            cmbConceptos.DataSource = conceptos;
            cmbConceptos.DisplayMember = "Descripcion";
            cmbConceptos.ValueMember = "Id";
        }


        private void dgvTarifasConceptos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= EntradaNumerica_KeyPress;

            if (dgvTarifasConceptos.CurrentCell.ColumnIndex == dgvTarifasConceptos.Columns.IndexOf(dgvTarifasConceptos.Columns["Cantidad"]))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += EntradaNumerica_KeyPress;
                }
            }
        }

        private void EntradaNumerica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

    }
}

