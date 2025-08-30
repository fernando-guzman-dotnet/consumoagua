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
    public partial class FrmCapturaLecturas : Form
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

                // Cargar Lecturas
                CargarContratoMediciones(_contrato);
            }
        }

        private void CargarContratoMediciones(Contrato contrato)
        {

            if (contrato == null) return;

            txtNoContrato.Text = contrato.NoContrato.ToString("D10");
            txtUsuario.Text = contrato.Usuario.NombreCompleto;
            txtDireccion.Text = contrato.Direccion;

            var mediciones = Medicion.GetMedicionesByNoContrato(contrato.NoContrato);
            dgvMedidorLecturas.DataSource = mediciones;

            dgvMedidorLecturas.Columns["NoContrato"].DefaultCellStyle.Format = "D10";
            dgvMedidorLecturas.Columns["NombreLecturista"].HeaderText = "Lecturista";
            dgvMedidorLecturas.Columns["LitrosLeidos"].HeaderText = "Litros Leídos";
            dgvMedidorLecturas.Columns["LitrosConsumidos"].HeaderText = "Litros Consumidos";
            dgvMedidorLecturas.Columns["TieneAnomalia"].HeaderText = "¿Presenta Anomalía?";
            dgvMedidorLecturas.Columns["DescripcionAnomalia"].HeaderText = "Anomalía";


            dgvMedidorLecturas.Columns["NoContrato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMedidorLecturas.Columns["NombreLecturista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMedidorLecturas.Columns["LitrosLeidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMedidorLecturas.Columns["LitrosConsumidos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMedidorLecturas.Columns["DescripcionAnomalia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvMedidorLecturas.Columns["Id"].Visible = false;
            dgvMedidorLecturas.Columns["Fecha"].Visible = false;
            dgvMedidorLecturas.Columns["IdMedidor"].Visible = false;
            dgvMedidorLecturas.Columns["IdLecturista"].Visible = false;
            dgvMedidorLecturas.Columns["IdPago"].Visible = false;

            dgvMedidorLecturas.ClearSelection();
        }

        public FrmCapturaLecturas()
        {
            InitializeComponent();
        }

        private void btnSeleccionarContrato_Click(object sender, EventArgs e)
        {
            DlgSeleccionarCuenta dlg = new DlgSeleccionarCuenta();

            dlg.SoloServicioMedido = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Contrato = dlg.Contrato;
            }
        }

        private void LimpiarGUI()
        {
            txtNoContrato.ResetText();
            txtDireccion.ResetText();
            txtUsuario.ResetText();

            dgvMedidorLecturas.DataSource = null;
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

                    if ((Contrato.Tipo)contrato.IdTipoContrato != Contrato.Tipo.ServicioMedido)
                    {
                        MessageBox.Show(
                            "El contrato ingresado no es del tipo \"Servicio Medido\". Revise el no. de contrato o actualice el tipo de contrato para el contrato especificado.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Contrato = null;

                        return true;
                    }

                    if (contrato.Medidor == null)
                    {
                        MessageBox.Show(
                            "El contrato ingresado no tiene un medidor asignado. Revise el registro del contrato especificado.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Contrato = null;

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

        private void btnAgregarLectura_Click(object sender, EventArgs e)
        {
            if (Contrato == null)
            {
                MessageBox.Show("No se ha cargado un contrato. Cargue uno e intente nuevamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DlgAgregarLectura dlg = new DlgAgregarLectura();

            dlg.Contrato = Contrato;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarContratoMediciones(dlg.Contrato);
            }

        }

        private void btnModificarLectura_Click(object sender, EventArgs e)
        {
            if (Contrato == null)
            {
                MessageBox.Show("No se ha cargado un contrato. Cargue uno e intente nuevamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvMedidorLecturas.CurrentRow == null)
                return;

            DlgAgregarLectura dlg = new DlgAgregarLectura();

            dlg.Contrato = Contrato;
            dlg.Medicion = dgvMedidorLecturas.CurrentRow.DataBoundItem as Medicion;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CargarContratoMediciones(dlg.Contrato);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
    }
}

