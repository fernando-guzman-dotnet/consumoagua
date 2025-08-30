using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPA.Clases;

namespace SAPA.Vistas
{
    public partial class FrmPermisosEmpleado : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        private List<EmpleadoPermisosModulo> _permisosAplicables { get; set; }

        public FrmPermisosEmpleado()
        {
            InitializeComponent();
        }

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

            cmbEmpleado.DataSource = empleados;
            cmbEmpleado.ValueMember = "Id";
            cmbEmpleado.DisplayMember = "NombreCompleto";
        }

        private void FrmPermisosEmpleado_Load(object sender, EventArgs e) => CargarCmbEmpleados();

        private void btnCerrar_Click(object sender, EventArgs e) =>
            FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex == 0 || cmbEmpleado.SelectedIndex == -1)
            {
                dgvPermisos.DataSource = null;
                _permisosAplicables = new List<EmpleadoPermisosModulo>();
                return;
            }

            List<EmpleadoPermisosModulo> empleadoPermisos = EmpleadoPermisosModulo.GetEmpleadoPermisos((int)cmbEmpleado.SelectedValue);
            List<EmpleadoPermisosModulo> permisosAplicables = new List<EmpleadoPermisosModulo>(FrmPrincipal.PermisosAplicables);

            foreach (var permiso in permisosAplicables)
            {
                var empleadoPermiso = empleadoPermisos.FirstOrDefault(p => p.Codigo.Contains(permiso.Codigo));

                if (empleadoPermiso == null)
                    continue;

                permiso.Habilitado = empleadoPermiso.Habilitado;
                permiso.Visible = empleadoPermiso.Visible;
            }

            _permisosAplicables = permisosAplicables;

            dgvPermisos.DataSource = _permisosAplicables;

        }

        private void commitChanges(object sender, DataGridViewCellEventArgs e) => dgvPermisos.CommitEdit(DataGridViewDataErrorContexts.Commit);

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex == 0 || cmbEmpleado.SelectedIndex == -1)
            {
                MessageBox.Show("No se ha seleccionado un empleado. Seleccione un empleado e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EmpleadoPermisosModulo.EliminarPermisosPrevios((int)cmbEmpleado.SelectedValue);

            foreach (var permiso in _permisosAplicables)
            {
                permiso.IdEmpleado = (int) cmbEmpleado.SelectedValue;

                if (!permiso.Guardar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar guardar los permisos. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Los permisos del empleado fueron guardados correctamente.", this.Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            if ((int)cmbEmpleado.SelectedValue == Empleado.Actual.Id)
            {
                MessageBox.Show(
                    "Los permisos del usuario actualmente en el sistema fueron cambiados. Por favor vuelva a reingresar al sistema.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmPrincipal.SesionCerrada = true;
                FrmPrincipal.Close();
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter();

        private void FastFilter()
        {
            List<EmpleadoPermisosModulo> permisosFiltrados = _permisosAplicables.ToList();

            if (!string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                permisosFiltrados = permisosFiltrados.Where(p =>
                    p.Descripcion.Contains(txtDescripcion.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            dgvPermisos.DataSource = permisosFiltrados;
        }

        private void chkMarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (_permisosAplicables.Count == 0)
            {
                if(chkMarcarTodos.Checked) chkMarcarTodos.Checked = false;
                return;
            }

            foreach (var permiso in _permisosAplicables)
            {
                permiso.Habilitado = chkMarcarTodos.Checked;
                permiso.Visible = chkMarcarTodos.Checked;
            }

            dgvPermisos.DataSource = _permisosAplicables;
            dgvPermisos.Refresh();
        }
    }
}

