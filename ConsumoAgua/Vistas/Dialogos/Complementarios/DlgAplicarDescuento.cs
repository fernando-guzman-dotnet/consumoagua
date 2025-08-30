using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgAplicarDescuento : Form
    {
        public List<ContratoDescuento> DescuentosAplicados { get; set; }
        public Contrato Contrato { get; set; }

        public DlgAplicarDescuento()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {

            if (!Contrato.Existe(Int32.Parse(mtxtNoContrato.Text)))
            {
                MessageBox.Show(
                    "No se ha elegido un contrato válido para aplicar el descuento. Elija un contrato válido e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbDescuentos.SelectedIndex == 0 || cmbDescuentos.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha elegido un descuento. Elija un descuento e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                if (Int32.Parse(mtxtNoContrato.Text) == 0)
                {
                    MessageBox.Show(
                        "No se ha elegido un contrato para aplicar el descuento. Elija uno e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "El número de contrato ingresado no es válido. Revise el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (Contrato.Id > 0)
            {
                var contratosDescuentos = ContratoDescuento.GetTodosByUsuario(Contrato.IdUsuario);

                foreach (var contratoDescuento in contratosDescuentos.Where(cd => DateTime.Now.Date >= cd.FechaInicio.Date && DateTime.Now.Date < cd.FechaFin.Date))
                {
                    if (contratoDescuento.Descuento.IdTipoDescuento ==
                        (cmbDescuentos.SelectedItem as Descuento).IdTipoDescuento)
                    {
                        MessageBox.Show("Ya hay un descuento aplicado vigente del mismo tipo en uno de los contratos del usuario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }


            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            ContratoDescuento contratoDescuento = new ContratoDescuento();

            contratoDescuento.NoContrato = Contrato.NoContrato;
            contratoDescuento.Descuento = cmbDescuentos.SelectedItem as Descuento;
            contratoDescuento.FechaInicio = dtpFechaInicio.Value;
            contratoDescuento.FechaFin = dtpFechaFin.Value;

            if (!contratoDescuento.Agregar())
            {
                MessageBox.Show(
                    "Hubo un problema al intentar aplicar el descuento al contrato. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("El descuento seleccionado ha sido aplicado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DlgSeleccionarCuenta dlg = new DlgSeleccionarCuenta();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.Contrato = dlg.Contrato;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ActiveControl == mtxtNoContrato)
            {
                if (keyData == Keys.Back || keyData == Keys.Delete)
                {
                    mtxtNoContrato.ResetText();
                    mtxtNoContrato.SelectionStart = mtxtNoContrato.Mask.Length + 1;
                    return true;
                }

                if (keyData == Keys.Enter)
                {
                    try
                    {
                        var noContrato = int.Parse(mtxtNoContrato.Text);

                        if (!CargarDatosContrato(noContrato))
                            btnBuscar_Click(null, null);
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show(
                            "El número de contrato ingresado no es válido. Revise el campo e intente nuevamente.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private bool CargarDatosContrato(int noContrato)
        {
            Contrato contrato = Contrato.GetContrato(noContrato);

            if (contrato == null)
                return false;

            DescuentosAplicados = ContratoDescuento.GetTodosByNoContrato(noContrato);

            return true;
        }

        private void CargarDescuentos()
        {
            List<Descuento> descuentos = Descuento.GetDescuentos();

            if (descuentos.Count == 0)
            {
                MessageBox.Show("No hay tipos de descuento registrados. Revise el catalogo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }

            descuentos.Insert(0, new Descuento { Id = 0, TipoDescuento = new TipoDescuento {Id = 0, Descripcion = "[ - - Seleccione un descuento - - ]"}});
            cmbDescuentos.DataSource = descuentos;
            cmbDescuentos.DisplayMember = "NombreTipoDescuento";
            cmbDescuentos.ValueMember = "Id";

        }

        private void DlgAplicarDescuento_Load(object sender, EventArgs e)
        {
            CargarDescuentos();

            dtpFechaInicio.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpFechaFin.Value = new DateTime(DateTime.Now.Year, 12, 31);


            if (Contrato.Id > 0)
            {
                DescuentosAplicados = ContratoDescuento.GetTodosByNoContrato(Contrato.NoContrato);
                mtxtNoContrato.Text = Contrato.NoContrato.ToString("D10");
            }
        }

        private void mtxtNoContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                string cadena = mtxtNoContrato.Text + e.KeyChar;
                mtxtNoContrato.Text = cadena.Substring(1, cadena.Length - 1);
                mtxtNoContrato.SelectionStart = mtxtNoContrato.Mask.Length + 1;
            }
        }
    }
}


