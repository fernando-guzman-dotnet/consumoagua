using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas
{
    public partial class FrmBitacora : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }
        private List<BitacoraEmpleado> _registrosBitacora = new List<BitacoraEmpleado>();

        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            LlenarCmbEmpleados();
        }

        private void LlenarCmbEmpleados()
        {
            List<Empleado> empleados = Empleado.GetEmpleados();

            if (empleados.Count == 0)
            {
                MessageBox.Show(" No hay empleados registrados. Revise el catalogo de empleados e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmBitacora_FormClosing(null, null);
                return;
            }

            empleados.Insert(0, new Empleado { Id = 0, Nombre = "[ -- SELECCIONE UN EMPLEADO -- ]"});

            cmbEmpleados.DataSource = empleados;
            cmbEmpleados.ValueMember = "Id";
            cmbEmpleados.DisplayMember = "NombreCompleto";
        }

        private void FastFilter(string modulo)
        {
            try
            {
                var registrosBitacoraFiltrados = _registrosBitacora.Where(l => l.Modulo.StartsWith(modulo,
                    StringComparison.InvariantCultureIgnoreCase));

                Cursor = Cursors.WaitCursor;
                dgvBitacora.DataSource = registrosBitacoraFiltrados.ToList();
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Filtrar - " + ex.Message, "Formulario frmBitacora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpleados.SelectedIndex == -1 || cmbEmpleados.SelectedIndex == 0)
                {
                    dgvBitacora.DataSource = null;
                    return;
                }

                _registrosBitacora = BitacoraEmpleado.Select(Convert.ToInt32(cmbEmpleados.SelectedValue));

                Cursor = Cursors.WaitCursor;
                dgvBitacora.DataSource = _registrosBitacora;
                Cursor = Cursors.Arrow;

                dgvBitacora.Columns["Id"].Visible = false;
                dgvBitacora.Columns["IdEmpleado"].Visible = false;

                // Reaplicar el filtro por módulo si el texto no está vacío
                if (!string.IsNullOrWhiteSpace(txtModulo.Text))
                    FastFilter(txtModulo.Text);

            }
            catch (Exception ex)
            {

                MessageBox.Show("cmbEmpleados_SelectedIndexChanged - " + ex.Message, "Formulario frmBitacora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBitacora_FormClosing(object sender, FormClosingEventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void txtModulo_TextChanged(object sender, EventArgs e) => FastFilter(txtModulo.Text);
    }
}

