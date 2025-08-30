using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Vistas.Dialogos;

namespace SAPA.Vistas.Paneles
{
    public partial class PnlSeccion : Form
    {
        public FrmPrincipal FrmPrincipal { get; set; }

        private List<Seccion> _secciones = new List<Seccion>();

        public PnlSeccion()
        {
            InitializeComponent();

        }

        public void CargarSecciones()
        {
            _secciones = Seccion.GetSecciones();

            dgvSecciones.DataSource = _secciones;

            dgvSecciones.Columns["Id"].Visible = false;

            dgvSecciones.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSecciones.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FastFilter(string descripcion)
        {
            var seccionesFiltradas = _secciones.Where(s => s.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase));

            dgvSecciones.DataSource = seccionesFiltradas.ToList();

        }
        private void btnAgregarSeccion_Click(object sender, EventArgs e)
        {
            DlgSeccion dlg = new DlgSeccion();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarSecciones();
            }
        }

        private void btnEditarSeccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSecciones.CurrentRow == null || dgvSecciones.Rows.Count == 0) return;

                DlgSeccion dlg = new DlgSeccion();

                dlg.Seccion = dgvSecciones.CurrentRow.DataBoundItem as Seccion;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CargarSecciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnEditarSeccion_Click - " + ex.Message, "Formulario Panel_Seccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarSeccion_Click(object sender, EventArgs e)
        {
            if (dgvSecciones.CurrentRow == null || dgvSecciones.Rows.Count == 0) return;

            Seccion seccion = dgvSecciones.CurrentRow.DataBoundItem as Seccion;

            if (MessageBox.Show("Se eliminará la sección seleccionada ¿desea continuar?", "Formulario Seccion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!seccion.Eliminar())
                {
                    MessageBox.Show(
                        "Hubo un problema al intentar eliminar la sección seleccionada. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("La sección fue eliminada correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarSecciones();
            }
        }

        private void tsTxtDescripcion_TextChanged(object sender, EventArgs e) => FastFilter(tsTxtDescripcion.Text);

        private void PnlSeccion_Load(object sender, EventArgs e) => CargarSecciones();

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
    }
}
