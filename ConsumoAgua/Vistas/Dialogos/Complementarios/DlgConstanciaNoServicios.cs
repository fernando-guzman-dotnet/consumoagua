using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPA.Vistas.Dialogos.Complementarios
{
    public partial class DlgConstanciaNoServicios : Form
    {

        public string NombreUsuario { get; set; } = string.Empty;
        public string Domicilio { get; set; } = string.Empty;

        public DlgConstanciaNoServicios()
        {
            InitializeComponent();
        }

        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("No se ha ingresado el nombre del usuario. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDomiclio.Text))
            {
                MessageBox.Show("No se ha ingresado el domicilio del usuario. COmplete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            NombreUsuario = txtNombreUsuario.Text;
            Domicilio = txtDomiclio.Text;

            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}

