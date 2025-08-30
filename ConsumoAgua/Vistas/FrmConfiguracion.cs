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
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        public FrmPrincipal FrmPrincipal { get; set; }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Configuracion.Actual == null) Configuracion.Actual = new Configuracion();

            Configuracion.Actual.LimiteAñosCobro = numLimiteAñosCobro.Value;
            Configuracion.Actual.LimiteBimestresVencidos = (int)numLimiteBimestresVencidos.Value;

            bool actualizar = Configuracion.Actual.Id > 0;

            if (actualizar)
            {
                if (!Configuracion.Actual.Actualizar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar actualizar la configuración del sistema. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("La configuración del sistema fue actualizada correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                if (!Configuracion.Actual.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar actualizar la configuración del sistema. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("La configuración del sistema fue registrada correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            if (Configuracion.Actual == null) return;

            if (Configuracion.Actual.Id > 0)
            {
                numLimiteAñosCobro.Value = Configuracion.Actual.LimiteAñosCobro;
                numLimiteBimestresVencidos.Value = Configuracion.Actual.LimiteBimestresVencidos;
            }
        }

        private void FrmConfiguracion_FormClosing(object sender, FormClosingEventArgs e) => FrmPrincipal.tabManager.TabPages.RemoveAt(FrmPrincipal.tabManager.SelectedIndex);
    }
}

