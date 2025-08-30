using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlOperadores : Form
    {
        public FrmPrincipal FrmPrincipal;

        private List<Operador> _operadores;

        public PnlOperadores()
        {
            InitializeComponent();
        }

        public void CargarOperadores()
        {
            _operadores = Operador.GetOperadores();

            dgvOperadores.DataSource = _operadores;

            dgvOperadores.Columns["Id"].Visible = false;
            dgvOperadores.Columns["Contrasena"].Visible = false;
            dgvOperadores.Columns["IdSector"].Visible = false;

            dgvOperadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void FastFilter()
        {
            IEnumerable<Operador> _operadoresFiltrados = _operadores;


            // Filtramos los operadores primero por usuario

            if (!string.IsNullOrWhiteSpace(tsTxtUsuario.Text))
            {
                _operadoresFiltrados = _operadores.Where(o => o.Usuario.Contains(tsTxtUsuario.Text, StringComparison.OrdinalIgnoreCase));
            }

            // Luego nombre

            if (!string.IsNullOrWhiteSpace(tsTxtNombre.Text))
            {
                _operadoresFiltrados = _operadoresFiltrados.Where(o => o.Nombre.Contains(tsTxtNombre.Text, StringComparison.OrdinalIgnoreCase));
            }

            // Luego domicilio

            if (!string.IsNullOrWhiteSpace(tsTxtDomicilio.Text))
            {
                _operadoresFiltrados = _operadoresFiltrados.Where(o => o.Domicilio.Contains(tsTxtDomicilio.Text, StringComparison.OrdinalIgnoreCase));
            }

            // Si no se cumple ninguna condición, se muestran todos sin problema

            dgvOperadores.DataSource = _operadoresFiltrados.ToList();
        }


        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);

        private void btnAgregarOperador_Click(object sender, EventArgs e)
        {
            DlgOperadores dlg = new DlgOperadores();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarOperadores();
            }
        }

        private void btnEditarOperador_Click(object sender, EventArgs e)
        {
            try
            {
                DlgOperadores dlg = new DlgOperadores();
                dlg.Operador = dgvOperadores.CurrentRow.DataBoundItem as Operador;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarOperadores();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarOperador_Click - " + ex.Message, "Formulario Panel_Operadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarOperador_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Se eliminará al operador seleccionado, ¿desea continuar?", "Formulario Operador", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Operador operador = dgvOperadores.CurrentRow.DataBoundItem as Operador;

                if (!operador.Eliminar())
                {
                    MessageBox.Show("Hubo un error al intentar eliminar el operador seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("El operador seleccionado fue eliminado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarOperadores();
            }
        }

        private void tsTxtUsuario_TextChanged(object sender, EventArgs e) => FastFilter();

        private void tsTxtNombre_TextChanged(object sender, EventArgs e) => FastFilter();

        private void tsTxtDomicilio_TextChanged(object sender, EventArgs e) => FastFilter();

        private void PnlOperadores_Load(object sender, EventArgs e) => CargarOperadores();
    }
}

