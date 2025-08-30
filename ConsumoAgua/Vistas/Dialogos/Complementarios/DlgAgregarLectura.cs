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
    public partial class DlgAgregarLectura : Form
    {
        public DlgAgregarLectura()
        {
            InitializeComponent();
        }

        public Contrato Contrato { get; set; }
        public List<Medicion> Mediciones { get; set; }
        public Medicion Medicion { get; set; } = new Medicion();

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtLecturaActual.Text))
            {
                MessageBox.Show(
                    "El campo \"Lectura Actual\" no puede estar vacío. Complete el campo e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbLecturistas.SelectedIndex == 0 || cmbLecturistas.SelectedIndex == -1)
            {

                MessageBox.Show(
                    "No se ha seleccionado un lecturista. Seleccione uno e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            decimal lecturaActual, lecturaAnterior;

            if (!decimal.TryParse(txtLecturaActual.Text, out lecturaActual))
            {
                MessageBox.Show(
                    "La lectura ingresada no es válida. Corrija el campo e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(txtLecturaAnterior.Text, out lecturaAnterior))
            {
                MessageBox.Show(
                    "No se pudo leer la lectura anterior. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (!chkReiniciarLecturas.Checked)
            {
                if (lecturaActual <= lecturaAnterior)
                {
                    MessageBox.Show(
                        "La lectura actual no puede ser menor o igual que la anterior, marque la opción \"Reiniciar Lecturas\" si desea ingresar '0' u otro valor o corrija el campo e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }


        private void CargarCmbLecturistas()
        {
            List<Empleado> lecturistas = Empleado.GetLecturistas();

            if (lecturistas.Count == 0)
            {
                MessageBox.Show(
                    "No hay empleados con el puesto de lecturista asignado. Revise el catálogo de empleados e intente nuevamente. Si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }

            lecturistas.Insert(0, new Empleado { Id = 0, Nombre = "[ -- SELECCIONE UN LECTURISTA -- ]" });

            cmbLecturistas.DataSource = lecturistas;
            cmbLecturistas.ValueMember = "Id";
            cmbLecturistas.DisplayMember = "NombreCompleto";
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            Medicion.NoContrato = Contrato.NoContrato;
            Medicion.IdMedidor = Contrato.Medidor.Id;
            Medicion.Fecha = Utilerias.GetDateTimeFromControls(dtpFecha, dtpHora);
            Medicion.Lecturista = new Empleado { Id = (int)cmbLecturistas.SelectedValue };
            Medicion.LitrosLeidos = decimal.Parse(txtLecturaActual.Text);
            Medicion.LitrosConsumidos = decimal.Parse(txtLitrosConsumidos.Text);
            Medicion.TieneAnomalia = chkTieneAnomalia.Checked;
            Medicion.DescripcionAnomalia = txtDescripcionAnomalia.Text;

            bool actualizar = Medicion.Id > 0;


            if (actualizar)
            {
                if (!Medicion.Actualizar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar actualizar la lectura. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("La lectura ha sido actualizada correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            else
            {

                if (!Medicion.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar registrar la lectura. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                MessageBox.Show("La lectura ha sido registrada correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void DlgAgregarLectura_Load(object sender, EventArgs e)
        {
            if (Contrato == null)
            {
                MessageBox.Show("No se pasó un contrato al formulario. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
                return;
            }

            if (Contrato.Medidor == null)
            {
                MessageBox.Show(
                    "El contrato seleccionado no tiene un medidor asignado. Asigne uno desde el módulo de contratos e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
                return;
            }

            txtNoContrato.Text = Contrato.NoContrato.ToString("D10");

            CargarCmbLecturistas();
            CargarMediciones();

            if (Medicion.Id > 0)
            {
                dtpFecha.Value = Medicion.Fecha;
                dtpHora.Value = Medicion.Fecha;

                txtLecturaActual.Text = Medicion.LitrosLeidos.ToString("N2");
                chkReiniciarLecturas.Checked = Medicion.LitrosLeidos == 0;
                cmbLecturistas.SelectedValue = Medicion.IdLecturista;
                chkTieneAnomalia.Checked = Medicion.TieneAnomalia;
                txtDescripcionAnomalia.Text = Medicion.DescripcionAnomalia;
            }
            else
            {
                txtLecturaActual.Text = "0.00";
                txtLitrosConsumidos.Text = "0.00";
            }
        }


        private void CargarLecturaAnterior(DateTime fecha)
        {
            if (Medicion.Id > 0) return;
            if (!_DlgMostrado) return;

            if (Mediciones == null)
            {
                txtLecturaAnterior.Text = "0.00";
                return;
            }

            if (chkReiniciarLecturas.Checked)
            {
                txtLecturaAnterior.Text = "0.00";
                return;
            }

            if (Mediciones.Count == 0)
            {
                txtLecturaAnterior.Text = "0.00";
                return;
            }

            var ultimaMedicion = Mediciones.FindLast(m => m.Fecha.Month == fecha.Month && m.Fecha.Year == fecha.Year);

            if (ultimaMedicion == null) return;

            txtLecturaAnterior.Text = ultimaMedicion.LitrosLeidos.ToString("N2");
        }

        private void CargarLecturaAnterior()
        {
            if (Mediciones == null)
            {
                txtLecturaAnterior.Text = "0.00";
                return;
            }

            if (chkReiniciarLecturas.Checked)
            {
                txtLecturaAnterior.Text = "0.00";
                return;
            }

            if (Mediciones.Count == 0)
            {
                txtLecturaAnterior.Text = "0.00";
                return;
            }

            if (Medicion.Id > 0)
            {
                int idxMedicionActual = Mediciones.FindIndex(m => m.Fecha == Medicion.Fecha);


                if ((idxMedicionActual -1) < 0)
                {
                    txtLecturaAnterior.Text = "0.00";
                    return;
                }

                var medicionAnterior = Mediciones[idxMedicionActual - 1];
                txtLecturaAnterior.Text = medicionAnterior == null ? "0.00" : medicionAnterior.LitrosLeidos.ToString("N2");
            }
            else
            {
                var ultimaMedicion = Mediciones.Last();
                txtLecturaAnterior.Text = ultimaMedicion == null ? "0.00" : ultimaMedicion.LitrosLeidos.ToString("N2");
            }
        }

        private void CalcularLitrosConsumidos()
        {
            if (!_DlgMostrado) return;

            if (string.IsNullOrWhiteSpace(txtLecturaActual.Text))
            {
                txtLitrosConsumidos.Text = "0.00";
                return;
            }

            // Calcular los litros consumidos

            decimal lecturaActual;

            if (!decimal.TryParse(txtLecturaActual.Text, out lecturaActual)) return;

            decimal lecturaAnterior = decimal.Parse(txtLecturaAnterior.Text);

            decimal litrosConsumidos = 0;

            if (lecturaAnterior < lecturaActual)
                litrosConsumidos = lecturaActual - lecturaAnterior;

            if (lecturaAnterior == 0)
                litrosConsumidos = lecturaActual;

            if (litrosConsumidos >= 0)
                txtLitrosConsumidos.Text = litrosConsumidos.ToString("N2");
            else
                txtLitrosConsumidos.Text = "<ERROR>";
        }

        private void CargarMediciones() => Mediciones = Medicion.GetMedicionesByNoContrato(Contrato.NoContrato).OrderBy(m => m.Fecha).ToList();

        private void chkTieneAnomalia_CheckedChanged(object sender, EventArgs e) => txtDescripcionAnomalia.Visible = chkTieneAnomalia.Checked;

        private void txtLecturaActual_TextChanged(object sender, EventArgs e) => CalcularLitrosConsumidos();


        private void chkReiniciarLecturas_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkReiniciarLecturas.Checked)
            {
                if (Mediciones.Count > 0)
                {
                    CargarLecturaAnterior();
                }
                else
                {
                    txtLecturaAnterior.Text = "0.00";
                }

                return;
            }

            txtLecturaAnterior.Text = "0.00";
        }

        private void txtLecturaActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Limitar la entrada de puntos decimales a uno

            if (e.KeyChar == '.' && _tienePunto)
            {
                e.Handled = true;
            }

            // Cancelar la entrada de cualquier tecla que no sea dígito, punto o de control

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private bool _tienePunto;
        private void txtLecturaActual_KeyDown(object sender, KeyEventArgs e)
        {
            // Al presionar el punto, ya sea desde el lado izquierdo o desde el NumPad
            // Contar el numero de puntos actuales

            if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
            {
                var puntos = txtLecturaActual.Text.ToCharArray().Where(c => c == '.').ToList();
                _tienePunto = puntos.Count > 0;
            }
        }

        private bool _DlgMostrado;
        private void DlgAgregarLectura_Shown(object sender, EventArgs e)
        {
            _DlgMostrado = true;

            CargarLecturaAnterior();
            CalcularLitrosConsumidos();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e) => CargarLecturaAnterior(Utilerias.GetDateTimeFromControls(dtpFecha, dtpHora));
        private void dtpHora_ValueChanged(object sender, EventArgs e) => CargarLecturaAnterior(Utilerias.GetDateTimeFromControls(dtpFecha, dtpHora));
    }
}

