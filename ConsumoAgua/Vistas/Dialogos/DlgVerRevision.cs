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

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgVerRevision : Form
    {
        public int IdRevision { get; set; }

        private DataSet DsContrato { get; set; }

        public DlgVerRevision()
        {
            InitializeComponent();
        }

        private void DlgVerRevision_Load(object sender, EventArgs e) => CargarDatosRevision();

        private void CargarDatosRevision()
        {

            if (IdRevision == 0)
            {
                MessageBox.Show("No se ha cargado una revisión de contrato. Cargue uno e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }

            DsContrato = Reporte.GetRptRevision(IdRevision);

            if (DsContrato.Tables.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró la revisión especificada. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
                return;
            }


            lblTitulo.Text = $"REVISIÓN #{IdRevision:D5}";

            // DATOS GENERALES

            var tablaDatosGenerales = DsContrato.Tables["DatosGenerales"];

            txtNoContrato.Text = int.Parse(tablaDatosGenerales.Rows[0]["noContrato"].ToString()).ToString("D10");
            txtNombreUsuario.Text = tablaDatosGenerales.Rows[0]["NombreCompleto"].ToString();
            txtTelefono.Text = tablaDatosGenerales.Rows[0]["telefono"].ToString();
            txtTipoContrato.Text = tablaDatosGenerales.Rows[0]["TipoContrato"].ToString();

            // DATOS GENERALES - UBICACIÓN DEL PREDIO

            txtEstado.Text = tablaDatosGenerales.Rows[0]["Estado"].ToString();
            txtMunicipio.Text = tablaDatosGenerales.Rows[0]["Municipio"].ToString();
            txtLocalidad.Text = tablaDatosGenerales.Rows[0]["Localidad"].ToString();
            txtColonia.Text = tablaDatosGenerales.Rows[0]["Colonia"].ToString();
            txtCalle.Text = tablaDatosGenerales.Rows[0]["Calle"].ToString();
            txtNoExterior.Text = tablaDatosGenerales.Rows[0]["noExterior"].ToString();
            txtNoInterior.Text = tablaDatosGenerales.Rows[0]["noInterior"].ToString();
            txtCodigoPostal.Text = tablaDatosGenerales.Rows[0]["cp"].ToString();

            // DATOS DE LA VIVIENDA

            var tablaDatosVivienda = DsContrato.Tables["DatosVivienda"];

            string condiciones = tablaDatosVivienda.Rows[0]["CondicionesPropiedad"].ToString().Replace("|", "");

            chkCondicion1.Checked = condiciones[0].Equals('1');
            chkCondicion2.Checked = condiciones[1].Equals('1');
            chkCondicion3.Checked = condiciones[2].Equals('1');
            chkCondicion4.Checked = condiciones[3].Equals('1');
            chkCondicion5.Checked = condiciones[4].Equals('1');
            chkCondicion6.Checked = condiciones[5].Equals('1');
            chkCondicion7.Checked = condiciones[6].Equals('1');
            chkCondicion8.Checked = condiciones[7].Equals('1');
            chkCondicion9.Checked = condiciones[8].Equals('1');
            chkCondicion10.Checked = condiciones[9].Equals('1');
            chkCondicion11.Checked = condiciones[10].Equals('1');
            chkCondicion12.Checked = condiciones[11].Equals('1');
            chkCondicion13.Checked = condiciones[12].Equals('1');

            txtNoHabitantes.Text = tablaDatosVivienda.Rows[0]["noHabitantes"].ToString();
            txtNoCuartos.Text = tablaDatosVivienda.Rows[0]["noCuartos"].ToString();
            txtNoBaños.Text = tablaDatosVivienda.Rows[0]["noBaños"].ToString();
            txtEstadoPropiedad.Text = tablaDatosVivienda.Rows[0]["estadoPropiedad"].ToString();
            txtEstatus.Text = tablaDatosVivienda.Rows[0]["estatusPropiedad"].ToString();

            // DATOS DEL SERVICIO

            var tablaDatosServicio = DsContrato.Tables["DatosServicio"];

            txtMaterialCalle.Text = tablaDatosServicio.Rows[0]["materialCalle"].ToString();
            txtMaterialBanqueta.Text = tablaDatosServicio.Rows[0]["materialBanqueta"].ToString();

            txtTipoMedidor.Text = tablaDatosServicio.Rows[0]["tipoMedidor"].ToString();
            txtDiametroToma.Text = tablaDatosServicio.Rows[0]["diametroToma"].ToString();
            txtDiametroMedidor.Text = tablaDatosServicio.Rows[0]["diametroMedidor"].ToString();
            txtUnidadesConsumo.Text = tablaDatosServicio.Rows[0]["unidadesConsumo"].ToString();

            // DATOS DEL SERVICIO -- CONDICIONES ALMACENAMIENTO INTERNO
            string condicionesAlmacenamiento = tablaDatosServicio.Rows[0]["almacenamientoInterno"].ToString().Replace("|", "");

            if (!string.IsNullOrWhiteSpace(condicionesAlmacenamiento))
            {
                chkCisterna.Checked = condicionesAlmacenamiento[0].Equals('1');
                chkTinaco.Checked = condicionesAlmacenamiento[1].Equals('1');
                chkPipa.Checked = condicionesAlmacenamiento[2].Equals('1');
                chkOtro.Checked = condicionesAlmacenamiento[3].Equals('1');
            }


            // DATOS DEL SERVICIO -- CONDICIONES ADICIONALES DEL SERVICIO

            chkHayRedAgua.Checked = tablaDatosServicio.Rows[0]["existeRedAgua"].ToString().Equals("S");
            chkHayToma.Checked = tablaDatosServicio.Rows[0]["existeToma"].ToString().Equals("S");
            chkHayAlcantarillado.Checked = tablaDatosServicio.Rows[0]["existeAlcantarillado"].ToString().Equals("S");
            chkHayDescarga.Checked = tablaDatosServicio.Rows[0]["existeDescarga"].ToString().Equals("S");
            chkHayDerivaciones.Checked = tablaDatosServicio.Rows[0]["existeDerivaciones"].ToString().Equals("S");
            chkHayFuenteAlterna.Checked = tablaDatosServicio.Rows[0]["existeFuenteAlterna"].ToString().Equals("S");
        }

    }
}

