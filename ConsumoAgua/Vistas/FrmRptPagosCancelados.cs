using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas
{
    public partial class FrmRptPagosCancelados : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        private Contrato _contrato;
        public Contrato Contrato
        {
            get { return _contrato; }
            set
            {
                _contrato = value;

                LimpiarGUI();

                CargarPagosContrato(value);
            }
        }

        private void CargarPagosContrato(Contrato contrato)
        {
            if (contrato == null) return;

            txtNoContrato.Text = contrato.NoContrato.ToString("D10");
            txtUsuario.Text = contrato.Usuario.NombreCompleto;
            txtDireccion.Text = contrato.Direccion;

            dgvPagos.DataSource = Pago.GetPagosCanceladosByNoContrato(contrato.NoContrato);
            grpFiltros.Enabled = true;
        }

        private void LimpiarGUI()
        {
            txtNoContrato.ResetText();
            txtDireccion.ResetText();
            txtUsuario.ResetText();

            dgvPagos.DataSource = null;
            grpFiltros.Enabled = false;
        }

        public FrmRptPagosCancelados()
        {
            InitializeComponent();
        }

        private void btnSeleccionarContrato_Click(object sender, EventArgs e)
        {
            DlgSeleccionarCuenta dlg = new DlgSeleccionarCuenta();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Contrato = dlg.Contrato;
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ActiveControl == txtNoContrato)
            {
                if (keyData == Keys.Back || keyData == Keys.Delete)
                {
                    txtNoContrato.ResetText();
                    txtNoContrato.SelectionStart = txtNoContrato.Mask.Length + 1;
                    return true;
                }

                if (keyData == Keys.Enter)
                {
                    int noContrato = 0;

                    if (!int.TryParse(txtNoContrato.Text, out noContrato))
                    {
                        // El no. contrato especificado tiene un formato inválido
                        // Para mantener agilidad hacemos un sonidito de error y mostramos la ventana de selección de contrato

                        SystemSounds.Exclamation.Play();

                        btnSeleccionarContrato_Click(null, null);

                        return true;
                    }

                    Contrato contrato = Contrato.GetContrato(noContrato);

                    if (contrato == null)
                    {
                        // No hay contratos con el no. de contrato especificado
                        // Para mantener agilidad hacemos un sonidito de error y mostramos la ventana de selección de contrato

                        SystemSounds.Exclamation.Play();

                        btnSeleccionarContrato_Click(null, null);

                        return true;
                    }

                    this.Contrato = contrato;

                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }



        private void txtNoContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                string cadena = txtNoContrato.Text + e.KeyChar;
                txtNoContrato.Text = cadena.Substring(1, cadena.Length - 1);
                txtNoContrato.SelectionStart = txtNoContrato.Mask.Length + 1;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);


        private void CargarCmbEmpleados()
        {
            List<Empleado> empleados = Empleado.GetEmpleados();

            if (empleados.Count == 0)
            {
                MessageBox.Show(" No hay empleados registrados. Revise el catalogo de empleados e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCerrar_Click(null, null);
                return;
            }

            empleados.Insert(0, new Empleado { Id = 0, Nombre = "[ -- SELECCIONE UN EMPLEADO -- ]" });

            cmbEmpleados.DataSource = empleados;
            cmbEmpleados.ValueMember = "Id";
            cmbEmpleados.DisplayMember = "NombreCompleto";
        }

        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            List<Pago> pagosFiltrados = Pago.GetPagosCanceladosByNoContrato(Contrato.NoContrato);

            if (cmbEmpleados.SelectedIndex > 0)
            {
                // Filtro empleados

                pagosFiltrados = pagosFiltrados.Where(p => p.IdEmpleado == (int) cmbEmpleados.SelectedValue).ToList();
            }

            // Filtro fechas

            pagosFiltrados = pagosFiltrados.Where(p =>
                p.Fecha.Date >= dtpFechaInicio.Value.Date && p.Fecha.Date <= dtpFechaFin.Value.Date).ToList();

            dgvPagos.DataSource = pagosFiltrados;
        }

        private void FrmRptPagosCancelados_Load(object sender, EventArgs e)
        {
            CargarCmbEmpleados();
        }
    }
}

