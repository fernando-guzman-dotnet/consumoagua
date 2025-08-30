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

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgAplicarDescuentoMasivamente : Form
    {
        public DlgAplicarDescuentoMasivamente()
        {
            InitializeComponent();
        }


        private void CargarCmbDescuentos()
        {
            List<Descuento> descuentos = Descuento.GetDescuentos();

            if (descuentos.Count == 0)
            {
                MessageBox.Show("No hay tipos de descuento registrados. Revise el catalogo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }

            descuentos.Insert(0, new Descuento { Id = 0, TipoDescuento = new TipoDescuento { Id = 0, Descripcion = "[ - - Seleccione un descuento - - ]" } });
            cmbDescuentos.DataSource = descuentos;
            cmbDescuentos.DisplayMember = "NombreTipoDescuento";
            cmbDescuentos.ValueMember = "Id";

        }

        private void CargarCmbColonias()
        {
            var colonias = Colonia.GetColonias();
            
            colonias.Insert(0, new Colonia {Id = 0, Descripcion = "[ -- Seleccione una colonia -- ]"});

            cmbColonia.DataSource = colonias;
            cmbColonia.ValueMember = "Id";
            cmbColonia.DisplayMember = "Descripcion";
        }


        private void CargarCmbCalles(int idColonia)
        {
            var calles = Colonia.GetCallesAsociadas(idColonia);

            calles.Insert(0, new Calle { Id = 0, Descripcion = "[ -- Seleccione una calle -- ]" });

            cmbCalle.DataSource = calles;
            cmbCalle.ValueMember = "Id";
            cmbCalle.DisplayMember = "Descripcion";
        }

        private bool ValidarGui()
        {
            if (cmbDescuentos.SelectedIndex == 0 || cmbDescuentos.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha elegido un descuento. Elija un descuento e intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            ContratoDescuento contratoDescuento = new ContratoDescuento();

            contratoDescuento.Descuento = cmbDescuentos.SelectedItem as Descuento;
            contratoDescuento.FechaInicio = dtpFechaInicio.Value;
            contratoDescuento.FechaFin = dtpFechaFin.Value;

            Colonia colonia = cmbColonia.SelectedItem as Colonia;
            Calle calle = cmbCalle.SelectedItem as Calle;

            if (!contratoDescuento.AplicarMasivamente(colonia.Id, calle.Id))
            {
                MessageBox.Show(
                    "No se pudo aplicar el descuento masivamente a ningún contrato. Puede que ya se haya aplicado anteriormente. Si esto no es así, contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("El descuento seleccionado ha sido aplicado masivamente correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void DlgAplicarDescuentoMasivamente_Load(object sender, EventArgs e)
        {
            CargarCmbColonias();
            CargarCmbDescuentos();

            dtpFechaInicio.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpFechaFin.Value = new DateTime(DateTime.Now.Year, 12, 31);

        }

        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbColonia.SelectedIndex == -1) return;

            var coloniaSeleccionada = cmbColonia.SelectedItem as Colonia;
            CargarCmbCalles(coloniaSeleccionada.Id);
        }
    }
}

