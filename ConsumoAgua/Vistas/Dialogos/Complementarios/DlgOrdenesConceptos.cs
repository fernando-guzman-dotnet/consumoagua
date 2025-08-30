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
    public partial class DlgOrdenesConceptos : Form
    {
        public DlgOrdenesConceptos()
        {
            InitializeComponent();
        }

        public OrdenTrabajo OrdenTrabajo { get; set; }

        private void DlgOrdenesConceptos_Load(object sender, EventArgs e)
        {
            CargarDgvCmbConceptos();

            if (OrdenTrabajo.Id > 0)
            {
                CargarOrdenConceptos(OrdenTrabajo.Id);
            }
            else
            {
                MessageBox.Show(
                    "No se cargó una orden de trabajo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDgv()) return;

            OrdenTrabajo.EliminarConceptos();

            foreach (DataGridViewRow row in dgvOrdenesConceptos.Rows)
            {
                if (row.IsNewRow) continue;

                int idConcepto = int.Parse(row.Cells["OrdenConcepto"].Value.ToString());
                decimal cantidad = decimal.Parse(row.Cells["Cantidad"].Value.ToString());

                if (!OrdenTrabajo.AgregarConcepto(idConcepto, cantidad))
                {
                    MessageBox.Show(
                        "Hubo un error al intentar guardar los conceptos para la orden de trabajo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
            }


            BitacoraOrdenTrabajo bitacoraOrdenTrabajo = new BitacoraOrdenTrabajo
            {
                Fecha = DateTime.Now,
                IdOrden = OrdenTrabajo.Id,
                IdEstatus = OrdenTrabajo.IdEstatus,
                Observaciones = "Se actualizaron los conceptos de la orden de trabajo.",
                IdEmpleado = Empleado.Actual.Id
            };

            if (!bitacoraOrdenTrabajo.Agregar())
            {
                MessageBox.Show(
                    "Hubo un error al intentar agregar un registro en la bitacora de la orden de trabajo. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Los conceptos fueron agregados a la orden de trabajo correctamente.", this.Text, MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;

        }

        private bool ValidarDgv()
        {
            if (dgvOrdenesConceptos.Rows.Count == 0)
            {
                MessageBox.Show("No se ha agregado ningún concepto para la orden de trabajo. Agregue una e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dgvOrdenesConceptos.Rows.Count == 1 && dgvOrdenesConceptos.Rows[0].IsNewRow)
            {
                MessageBox.Show("No se ha agregado ningún concepto para la orden de trabajo. Agregue uno e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            List<int> conceptos = new List<int>();

            foreach (DataGridViewRow row in dgvOrdenesConceptos.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["OrdenConcepto"].Value == null)
                {
                    MessageBox.Show(
                        "No se seleccionó un concepto para la orden de trabajo en alguna fila. Seleccione uno e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                conceptos.Add(int.Parse(row.Cells["OrdenConcepto"].Value.ToString()));

                if (string.IsNullOrWhiteSpace(row.Cells["Cantidad"].Value.ToString()))
                {
                    MessageBox.Show(
                        "La cantidad del concepto de la orden de trabajo no puede estar vacía. Revise el campo en alguna fila e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                try
                {
                    var cantidad = decimal.Parse(row.Cells["Cantidad"].Value.ToString());

                    if (cantidad < 0)
                    {
                        MessageBox.Show(
                            "La cantidad del concepto de la orden de trabajo no debe ser negativo. Revise el campo en alguna fila e intente nuevamente.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(
                        "La cantidad del concepto de la orden de trabajo debe ser ingresada como un número. Revise el campo en alguna fila e intente nuevamente.",
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

        private void CargarOrdenConceptos(int idOrden)
        {
            var ordenesConceptos = OrdenTrabajo.GetOrdenConceptos(idOrden);
            dgvOrdenesConceptos.DataSource = ordenesConceptos;
        }

        private void CargarDgvCmbConceptos()
        {
            DataGridViewComboBoxColumn cmbConceptos = dgvOrdenesConceptos.Columns["OrdenConcepto"] as DataGridViewComboBoxColumn;

            var conceptos = Concepto.GetConceptos().OrderBy(c => c.Descripcion).ToList();

            cmbConceptos.DataSource = conceptos;
            cmbConceptos.DisplayMember = "Descripcion";
            cmbConceptos.ValueMember = "Id";
        }


        private void dgvOrdenesConceptos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= EntradaNumerica_KeyPress;

            if (dgvOrdenesConceptos.CurrentCell.ColumnIndex == dgvOrdenesConceptos.Columns.IndexOf(dgvOrdenesConceptos.Columns["Cantidad"]))
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

