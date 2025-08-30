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
    public partial class DlgTarifasMedidas : Form
    {
        public Tarifa Tarifa { get; set; } = new Tarifa();
        public TarifaMedida TarifaMedida { get; set; } = new TarifaMedida();
        public int AñoTarifaSeleccionada { get; set; }

        public List<TarifaMedida> TarifasMedidas { get; set; } = new List<TarifaMedida>();

        public DlgTarifasMedidas()
        {
            InitializeComponent();
        }

        private void DlgTarifasMedidas_Load(object sender, EventArgs e)
        {
            if (Tarifa.Id > 0)
            {
                TarifaMedida.IdTarifa = Tarifa.Id;        

                txtTarifaActual.Text = Tarifa.Descripcion;

                TarifasMedidas = TarifaMedida.GetTarifasMedidasByIdTarifa(Tarifa.Id);

                if (!TarifasMedidas.Any())
                {
                    // Al ser la primer cuota asignada, partimos del año seleccionado

                    TarifasMedidas.Add(new TarifaMedida
                    {
                        IdTarifa = Tarifa.Id,
                        Año = AñoTarifaSeleccionada
                    });
                }

                cmbAño.DataSource = TarifasMedidas.OrderByDescending(tf => tf.Año).ToList();
                cmbAño.SelectedValue = AñoTarifaSeleccionada;

                CargarTarifasMedidas(Tarifa.Id);
            }
            else
            {
                MessageBox.Show(
                    "No se cargó una tarifa. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }

        private void CargarTarifasMedidas(int idTarifa)
        {
            dgvTarifasMedidas.DataSource = TarifaMedida.GetTarifasMedidas(idTarifa);
            dgvTarifasMedidas.AutoGenerateColumns = false;
        }


        private bool ValidarGui()
        {
            if (dgvTarifasMedidas.Rows.Count == 0)
            {
                MessageBox.Show("No se ha agregado ninguna tarifa medida. Agregue una e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dgvTarifasMedidas.Rows.Count == 1 && dgvTarifasMedidas.Rows[0].IsNewRow)
            {
                MessageBox.Show("No se ha agregado ninguna tarifa medida. Agregue una e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            foreach (DataGridViewRow row in dgvTarifasMedidas.Rows)
            {
                if (row.IsNewRow) continue;

                if (string.IsNullOrWhiteSpace(row.Cells["Descripcion"].Value.ToString()))
                {
                    MessageBox.Show("La descripción de la tarifa no puede estar vacía. Revise el campo en las filas e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(row.Cells["LimiteMenor"].Value.ToString()))
                {
                    MessageBox.Show("El límite menor de la tarifa no puede estar vacía. Revise el campo en las filas e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(row.Cells["LimiteMayor"].Value.ToString()))
                {
                    MessageBox.Show("El límite mayor de la tarifa no puede estar vacía. Revise el campo en las filas e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(row.Cells["Cantidad"].Value.ToString()))
                {
                    MessageBox.Show("La cantidad para la cuota de la tarifa no puede estar vacía. Revise el campo en las filas e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                try
                {
                    var limiteMenor = decimal.Parse(row.Cells["LimiteMenor"].Value.ToString());

                    if (limiteMenor < 0)
                    {
                        MessageBox.Show(
                            "El limite menor de la tarifa no debe ser negativo. Revise el campo en alguna fila e intente nuevamente.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(
                        "El limite menor la tarifa debe ser ingresada como un número. Revise el campo en alguna fila e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (OverflowException)
                {
                    MessageBox.Show($"El limite menor de la tarifa ({row.Cells["LimiteMenor"].Value}) no es válida. Revise el campo en alguna fila e intente nuevamente.");
                    return false;
                }


                try
                {
                    var limiteMayor = decimal.Parse(row.Cells["LimiteMayor"].Value.ToString());

                    if (limiteMayor < 0)
                    {
                        MessageBox.Show(
                            "El limite mayor de la tarifa no debe ser negativo. Revise el campo en alguna fila e intente nuevamente.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(
                        "El limite mayor la tarifa debe ser ingresada como un número. Revise el campo en alguna fila e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (OverflowException)
                {
                    MessageBox.Show($"El limite mayor de la tarifa ({row.Cells["LimiteMayor"].Value}) no es válida. Revise el campo en alguna fila e intente nuevamente.");
                    return false;
                }


                try
                {
                    var cantidad = decimal.Parse(row.Cells["Cantidad"].Value.ToString());

                    if (cantidad <= 0)
                    {
                        MessageBox.Show(
                            "La cantidad para la cuota de la tarifa no debe ser cero o negativo. Revise el campo en alguna fila e intente nuevamente.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(
                        "La cantidad para la cuota de la tarifa debe ser ingresada como un número. Revise el campo en alguna fila e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (OverflowException)
                {
                    MessageBox.Show($"La cantidad para la cuota de la tarifa ({row.Cells["Cantidad"].Value}) no es válida. Revise el campo en alguna fila e intente nuevamente.");
                    return false;
                }


                try
                {
                    var excedente = decimal.Parse(row.Cells["Excedente"].Value.ToString());

                    if (excedente < 0)
                    {
                        MessageBox.Show(
                            "El excedente para la cuota de la tarifa no debe ser negativo. Revise el campo en alguna fila e intente nuevamente.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(
                        "El excedente para la cuota de la tarifa debe ser ingresada como un número. Revise el campo en alguna fila e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (OverflowException)
                {
                    MessageBox.Show($"El excedente para la cuota de la tarifa ({row.Cells["Excedente"].Value}) no es válido. Revise el campo en alguna fila e intente nuevamente.");
                    return false;
                }

            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            TarifaMedida.EliminarCuotasMedidas((int)cmbAño.SelectedValue);

            foreach (DataGridViewRow row in dgvTarifasMedidas.Rows)
            {
                if (row.IsNewRow) continue;


                TarifaMedida tarifaMedida = new TarifaMedida()
                {
                    Id = Tarifa.Id,
                    Descripcion = row.Cells["Descripcion"].Value.ToString(),
                    LimiteMenor = decimal.Parse(row.Cells["LimiteMenor"].Value.ToString()),
                    LimiteMayor = decimal.Parse(row.Cells["LimiteMayor"].Value.ToString()),
                    Cantidad = decimal.Parse(row.Cells["Cantidad"].Value.ToString()),
                    Excedente = decimal.Parse(row.Cells["Excedente"].Value.ToString()),
                    Año = (int)cmbAño.SelectedValue
                };

                if (!tarifaMedida.Guardar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar guardar la cuota medida. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Las cuotas medidas fueron guardadas correctamente.", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;


        private void btnAgregarAño_Click(object sender, EventArgs e)
        {
            int año = 0;

            if (!int.TryParse(txtAño.Text, out año))
            {
                MessageBox.Show("El año ingresado no es válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TarifasMedidas.Add(new TarifaMedida
            {
                IdTarifa = Tarifa.Id,
                Año = año
            });

            cmbAño.DataSource = TarifasMedidas.OrderByDescending(tf => tf.Año).ToList();
            cmbAño.SelectedValue = año;

            MessageBox.Show(
                "El año ingresado se agregó a la lista correctamente. Para guardar la tarifa fija para ese año complete los campos 'Cuota Mensual' y 'Cuota Anual'.",
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void dgvTarifasMedidas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= EntradaNumerica_KeyPress;

            if (dgvTarifasMedidas.CurrentCell.ColumnIndex ==
                dgvTarifasMedidas.Columns.IndexOf(dgvTarifasMedidas.Columns["LimiteMayor"]) ||
                dgvTarifasMedidas.CurrentCell.ColumnIndex ==
                dgvTarifasMedidas.Columns.IndexOf(dgvTarifasMedidas.Columns["LimiteMenor"]) ||
                dgvTarifasMedidas.CurrentCell.ColumnIndex ==
                dgvTarifasMedidas.Columns.IndexOf(dgvTarifasMedidas.Columns["Cantidad"]))
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


        private void cmbAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAño.SelectedIndex == -1) return;

            dgvTarifasMedidas.DataSource = TarifasMedidas.Where(tm => tm.Año == (int) cmbAño.SelectedValue);
        }
    }
}

