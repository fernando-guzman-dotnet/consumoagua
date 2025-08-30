using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlEmpleados : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        private List<Empleado> _empleados;

        public PnlEmpleados()
        {
            InitializeComponent();
        }

        public void CargarEmpleados()
        {
            _empleados = Empleado.GetEmpleados();
            dgvEmpleados.DataSource = _empleados;

            dgvEmpleados.Columns["Id"].Visible = false;
            dgvEmpleados.Columns["IdPuesto"].Visible = false;
            dgvEmpleados.Columns["IdCaja"].Visible = false;

            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FastFilter()
        {
            List<Empleado> empleadosFiltrados = _empleados;

            //  Filtramos primero por usuario

            if (!string.IsNullOrWhiteSpace(tsTxtUsuario.Text))
            {
                empleadosFiltrados = _empleados
                    .Where(e => e.Usuario.Contains(tsTxtUsuario.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Luego por nombre

            if (!string.IsNullOrWhiteSpace(tsTxtNombre.Text))
            {
                empleadosFiltrados = empleadosFiltrados.Where(e =>
                    e.NombreCompleto.Contains(tsTxtNombre.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Luego por domicilio

            if (!string.IsNullOrWhiteSpace(tsTxtDomicilio.Text))
            {
                empleadosFiltrados = empleadosFiltrados.Where(e =>
                    e.Domicilio.Contains(tsTxtDomicilio.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            dgvEmpleados.DataSource = empleadosFiltrados;

        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            DlgEmpleado dlg = new DlgEmpleado();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarEmpleados();
            }
        }


        private void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmpleados.CurrentRow == null || dgvEmpleados.Rows.Count == 0) return;

                DlgEmpleado dlg = new DlgEmpleado();

                dlg.Empleado = dgvEmpleados.CurrentRow.DataBoundItem as Empleado;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarEmpleados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarEmpleado_Click - " + ex.Message, "Formulario Panel_Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null || dgvEmpleados.Rows.Count == 0) return;

            if (MessageBox.Show("El empleado seleccionado será eliminado, ¿desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Empleado empleado = new Empleado { Id = int.Parse(dgvEmpleados.CurrentRow.Cells["Id"].Value.ToString()) };

                if (!empleado.Eliminar())
                {
                    MessageBox.Show(
                        "Hubo un problema al intentar eliminar el empleado seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("El empleado seleccionado fue eliminado correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarEmpleados();
            }

        }

        private void PnlEmpleados_Load(object sender, EventArgs e) => CargarEmpleados();


        private void tsTxtUsuario_TextChanged(object sender, EventArgs e) => FastFilter();

        private void tsTxtNombre_TextChanged(object sender, EventArgs e) => FastFilter();

        private void tsTxtDomicilio_TextChanged(object sender, EventArgs e) => FastFilter();
    }
}

