using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas
{
    public partial class FrmPorcentajes : Form
    {
        public FrmPrincipal FrmPrincipal;
        private List<Porcentajes> _porcentajes = new List<Porcentajes>();

        public FrmPorcentajes()
        {
            InitializeComponent();
        }

        private void CargarPorcentajes()
        {
            _porcentajes = Porcentajes.GetPorcentajes();
            dgvPorcentajes.DataSource = _porcentajes;

            dgvPorcentajes.Columns["Id"].Visible = false;
            dgvPorcentajes.Columns["FechaRegistrados"].Visible = false;

            dgvPorcentajes.Columns["AumentoAnual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void frmPorcentajes_Load(object sender, EventArgs e)
        {
            CargarPorcentajes();
        }

        private bool ValidarGui()
        {
            #region Validar campos vacíos o con espacios en blanco

            if (string.IsNullOrWhiteSpace(txtIVA.Text))
            {
                MessageBox.Show("El porcentaje de IVA no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPorcentajeAlcantarillado.Text))
            {
                MessageBox.Show(
                    "El porcentaje de Alcantarillado no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPorcentajeSaneamiento.Text))
            {
                MessageBox.Show(
                    "El porcentaje de Saneamiento no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSalarioMinimo.Text))
            {
                MessageBox.Show("El Salario Mínimo no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescuentoAnual.Text))
            {
                MessageBox.Show(
                    "El porcentaje de Descuento Anual no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPorcentajeMultas.Text))
            {
                MessageBox.Show("El porcentaje de Multas no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPorcentajeRecargos.Text))
            {
                MessageBox.Show(
                    "El porcentaje de Recargos no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAumentoAnual.Text))
            {
                MessageBox.Show(
                    "El porcentaje de Aumento Anual no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            #endregion

            #region Validar negativos o con formato incorrecto
            try
            {
                var IVA = decimal.Parse(txtIVA.Text);

                if (IVA < 0)
                {
                    MessageBox.Show("El porcentaje de IVA no puede ser negativo. Corrija el campo e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El porcentaje de IVA no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("El porcentaje de IVA no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var Alcantarillado = decimal.Parse(txtPorcentajeAlcantarillado.Text);

                if (Alcantarillado < 0)
                {
                    MessageBox.Show("El porcentaje de Alcantarillado no puede ser negativo. Corrija el campo e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El porcentaje de Alcantarillado no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("El porcentaje de Alcantarillado no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            try
            {
                var Saneamiento = decimal.Parse(txtPorcentajeSaneamiento.Text);

                if (Saneamiento < 0)
                {
                    MessageBox.Show("El porcentaje de Saneamiento no puede ser negativo. Corrija el campo e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El porcentaje de Saneamiento no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("El porcentaje de Saneamiento no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            try
            {
                var SalarioMinimo = decimal.Parse(txtSalarioMinimo.Text);

                if (SalarioMinimo < 0)
                {
                    MessageBox.Show("El Salario Mínimo no puede ser negativo. Corrija el campo e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El Salario Mínimo no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("El Salario Mínimo no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var DescuentoAnual = decimal.Parse(txtDescuentoAnual.Text);

                if (DescuentoAnual < 0)
                {
                    MessageBox.Show("El porcentaje de Descuento Anual no puede ser negativo. Corrija el campo e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El porcentaje de Descuento Anual no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("El porcentaje de Descuento Anual no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var Multas = decimal.Parse(txtPorcentajeMultas.Text);

                if (Multas < 0)
                {
                    MessageBox.Show("El porcentaje de Multas no puede ser negativo. Corrija el campo e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El porcentaje de Multas no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("El porcentaje de Multas no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            try
            {
                var Recargos = decimal.Parse(txtPorcentajeRecargos.Text);

                if (Recargos < 0)
                {
                    MessageBox.Show("El porcentaje de Recargos no puede ser negativo. Corrija el campo e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El porcentaje de Recargos no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("El porcentaje de Recargos no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            try
            {
                var Recargos = decimal.Parse(txtAumentoAnual.Text);

                if (Recargos < 0)
                {
                    MessageBox.Show("El porcentaje de Aumento Anual no puede ser negativo. Corrija el campo e intente nuevamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El porcentaje de Aumento Anual no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("El porcentaje de Aumento Anual no es un numero válido. Corrija el campo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            return true;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGui()) return;

                bool actualizar = dgvPorcentajes.SelectedRows.Count > 0;


                if (actualizar)
                {
                    Porcentajes porcentajes = dgvPorcentajes.CurrentRow.DataBoundItem as Porcentajes;

                    porcentajes.IVA = decimal.Parse(txtIVA.Text);
                    porcentajes.Alcantarillado = decimal.Parse(txtPorcentajeAlcantarillado.Text);
                    porcentajes.Saneamiento = decimal.Parse(txtPorcentajeSaneamiento.Text);
                    porcentajes.SalarioMinimo = decimal.Parse(txtSalarioMinimo.Text);
                    porcentajes.DescuentoAnual = decimal.Parse(txtDescuentoAnual.Text);
                    porcentajes.FechaInicio = dtpFechaInicio.Value;
                    porcentajes.FechaFin = dtpFechaFin.Value;
                    porcentajes.Multas = decimal.Parse(txtPorcentajeMultas.Text);
                    porcentajes.Recargos = decimal.Parse(txtPorcentajeRecargos.Text);
                    porcentajes.AumentoAnual = decimal.Parse((txtAumentoAnual.Text));

                    if (!porcentajes.Actualizar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar actualizar los datos de la fila de porcentajes seleccionada. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            "Formulario Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("La fila de porcentajes selecionada fue actualizada correctamente.",
                        "Formulario Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarPorcentajes();
                    LimpiarGui();
                }
                else
                {
                    Porcentajes porcentajes = new Porcentajes
                    {
                        IVA = decimal.Parse(txtIVA.Text),
                        Alcantarillado = decimal.Parse(txtPorcentajeAlcantarillado.Text),
                        Saneamiento = decimal.Parse(txtPorcentajeSaneamiento.Text),
                        SalarioMinimo = decimal.Parse(txtSalarioMinimo.Text),
                        DescuentoAnual = decimal.Parse(txtDescuentoAnual.Text),

                        FechaInicio = dtpFechaInicio.Value,
                        FechaFin = dtpFechaFin.Value,

                        Multas = decimal.Parse(txtPorcentajeMultas.Text),
                        Recargos = decimal.Parse(txtPorcentajeRecargos.Text)
                    };


                    if (!porcentajes.Guardar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar guardar los porcentajes. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            "Formulario Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    MessageBox.Show("Los porcentajes fueron guardados correctamente.", "Formulario Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarPorcentajes();
                    LimpiarGui();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("btnGuardar_Click - " + ex.Message, "Formulario frmPorcentajes ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void LimpiarGui()
        {
            txtIVA.Text = "0.00";
            txtPorcentajeAlcantarillado.Text = "0.00";
            txtPorcentajeSaneamiento.Text = "0.00";
            txtSalarioMinimo.Text = "0.00";
            txtPorcentajeMultas.Text = "0.00";
            txtPorcentajeRecargos.Text = "0.00";
            txtDescuentoAnual.Text = "0.00";

            btnGuardar.Text = "Guardar";

            dtpFechaInicio.ResetText();
            dtpFechaFin.ResetText();

            dgvPorcentajes.ClearSelection();
            dgvPorcentajes.CurrentCell = null;

        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarGui();

        private void tsmBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPorcentajes.CurrentRow == null || dgvPorcentajes.Rows.Count == 0) return;

                Porcentajes porcentajes = dgvPorcentajes.CurrentRow.DataBoundItem as Porcentajes;

                if (MessageBox.Show("¿Desea eliminar los porcentajes seleccionados?", "Formulario Porcentajes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!porcentajes.Eliminar())
                    {
                        MessageBox.Show(
                            "Hubo un error al intentar eliminar la fila de porcentajes seleccionados. Intenta nuevamente,",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("La fila de porcentjaes seleccionada fue eliminada correctamente.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarPorcentajes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("borrarToolStripMenuItem_Click - " + ex, "Formulario frmPorcentajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SoloDecimales(KeyPressEventArgs e)
        {
            // Solo permitir digitos, la tecla de retroceso y el punto para los decimales

            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.')
            {
                e.Handled = false;
                return;
            }

            // El resto de teclas pulsadas se deshabilitan
            e.Handled = true;
            SystemSounds.Beep.Play();

        }

        private void txtIVA_KeyPress(object sender, KeyPressEventArgs e) => SoloDecimales(e);

        private void txtAlcantarillado_KeyPress(object sender, KeyPressEventArgs e) => SoloDecimales(e);

        private void txtSaneamiento_KeyPress(object sender, KeyPressEventArgs e) => SoloDecimales(e);

        private void txtPorcentajeMultas_KeyPress(object sender, KeyPressEventArgs e) => SoloDecimales(e);

        private void txtPorcentajeRecargos_KeyPress(object sender, KeyPressEventArgs e) => SoloDecimales(e);

        private void txtDescuentoAnual_KeyPress(object sender, KeyPressEventArgs e) => SoloDecimales(e);

        private void dgvPorcentajes_SelectionChanged(object sender, EventArgs e)
        {
            // Permitir guardar al no haber selección

            if (dgvPorcentajes.SelectedRows.Count == 0 || dgvPorcentajes.Rows.Count == 0)
            {
                LimpiarGui();
                return;
            }

            // Traerse el objeto a la GUI y permitir modificar

            Porcentajes porcentajes = dgvPorcentajes.CurrentRow.DataBoundItem as Porcentajes;

            txtIVA.Text = porcentajes.IVA.ToString();
            txtPorcentajeAlcantarillado.Text = porcentajes.Alcantarillado.ToString();
            txtPorcentajeSaneamiento.Text = porcentajes.Saneamiento.ToString();
            txtSalarioMinimo.Text = porcentajes.SalarioMinimo.ToString();
            txtDescuentoAnual.Text = porcentajes.DescuentoAnual.ToString();

            txtPorcentajeMultas.Text = porcentajes.Multas.ToString();
            txtPorcentajeRecargos.Text = porcentajes.Recargos.ToString();
            txtAumentoAnual.Text = porcentajes.AumentoAnual.ToString();

            dtpFechaInicio.Value = porcentajes.FechaInicio;
            dtpFechaFin.Value = porcentajes.FechaFin;

            txtIVA.Focus();
            txtIVA.Select(0, txtIVA.Text.Length);

            btnGuardar.Text = "Modificar";
        }

        private void FrmPorcentajes_Shown(object sender, EventArgs e)
        {
            dgvPorcentajes.ClearSelection();
            dgvPorcentajes.CurrentCell = null; // Esto quita la flecha al inicio de la fila
        }
    }
}

