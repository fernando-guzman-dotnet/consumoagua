using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using SAPA.Clases;
using SAPA.Reportes;
using SAPA.Vistas.Dialogos.Complementarios;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgConvenio : Form
    {

        /**
         REGLAS
            -	El contrato solo puede tener un convenio activo a la vez.
            -	Al cargarse la lista de los contratos que han pagado en los últimos 7 días, estos no deberían tener convenios activos.
            -	Las parcialidades en la periodicidad elegida parten de la fecha inicio asignada.
            -	Las quincenas se definen desde los próximos 15 días al inicio del mes hasta el último día de este.
            -	Los pagos se cobran separadamente y en abonos abiertos. 
            -	Si se cancela el convenio, se cobrará desde la última fecha de pago.
            -	Si el convenio se concluye, cobro desde… ¿?
         
         */


        public Convenio Convenio { get; set; } = new Convenio();
        public Contrato Contrato { get; set; }

        public decimal AdeudoTotal { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }


        public DlgConvenio()
        {
            InitializeComponent();

            dgvProyeccionPagos.AutoGenerateColumns = false;
        }

        private void CargarPeriodicidadesPago()
        {
            var periodicidadesPago = PeriodicidadPago.GetPeriodicidadesPago();

            if (periodicidadesPago.Count == 0)
            {
                MessageBox.Show("No se han registrado las periodicidades de pago. Contacte al área de soporte de SAPA.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;

                return;
            }

            periodicidadesPago.Insert(0, new PeriodicidadPago {Id = 0, Descripcion = "[ -- SELECCIONE LA PERIODICIDAD DEL PAGO -- ]"});

            cmbPeriodicidades.DataSource = periodicidadesPago;
            cmbPeriodicidades.DisplayMember = "Descripcion";
            cmbPeriodicidades.ValueMember = "Id";
        }

        private bool ValidarGui()
        {
            if (AdeudoTotal == 0)
            {
                MessageBox.Show("No se puede establecer un convenio cuando el adeudo del contrato es igual a cero.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbPeriodicidades.SelectedIndex == 0 || cmbPeriodicidades.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado la periocididad con la que se realizará el cobro de los pagos del convenio. Seleccione uno e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;

            bool actualizar = Convenio.Id > 0;

            Convenio.NoContrato = Contrato == null ? Convenio.NoContrato : Contrato.NoContrato;
            Convenio.FechaInicio = dtpFechaInicio.Value;
            Convenio.FechaFin = dtpFechaFin.Value;
            Convenio.AdeudoPeriodoInicio = (PeriodoInicio == default(DateTime)) ? Convenio.AdeudoPeriodoInicio : PeriodoInicio;
            Convenio.AdeudoPeriodoFin = (PeriodoFin == default(DateTime)) ? Convenio.AdeudoPeriodoFin : PeriodoFin;
            Convenio.NumeroPagos = (int)nudNumeroPagos.Value;
            Convenio.PeriodicidadPago = cmbPeriodicidades.SelectedItem as PeriodicidadPago;
            Convenio.Empleado = Empleado.Actual;
            Convenio.Total = AdeudoTotal;

            if (actualizar)
            {
                if (!Convenio.Actualizar())
                {
                    MessageBox.Show(
                        "Hubo un problema al intentar actualizar el convenio establecido. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("El convenio establecido ha sido actualizado correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!Convenio.Agregar())
                {
                    MessageBox.Show(
                        "Hubo un problema al intentar guardar el convenio establecido. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("El convenio establecido ha sido guardado correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            if (chkImprimirConvenio.Checked)
            {
                RptConvenio rpt = new RptConvenio();

                DataSet dsReporte = new DataSet();
                dsReporte.Tables.Add(Organismo.Actual);

                rpt.SetDataSource(dsReporte);

                rpt.SetParameterValue("FechaCompleta", DateTime.Now.ToString("dd 'de' MMMM 'del' yyyy", new CultureInfo("es-MX")).ToUpper());

                if(Contrato == null)
                    Contrato = Contrato.GetContrato(Convenio.NoContrato);

                rpt.SetParameterValue("NombreContribuyente", Contrato.NombreUsuario);
                rpt.SetParameterValue("NoContrato", Contrato.NoContrato.ToString("D10"));
                rpt.SetParameterValue("DomicilioContribuyente", Contrato.Direccion);
                rpt.SetParameterValue("AdeudoTotal", (AdeudoTotal == 0) ? Convenio.Total : AdeudoTotal);
                rpt.SetParameterValue("AdeudoTotalLetra", Utilerias.CantidadEnLetras((AdeudoTotal == 0) ? Convenio.Total : AdeudoTotal));
                rpt.SetParameterValue("PeriodoInicio", $"{Utilerias.GetInicioPeriodoBimestral(Convenio.AdeudoPeriodoInicio).ToString("MMMM", new CultureInfo("es-MX")).ToUpper()} - {Utilerias.GetFinPeriodoBimestral(Convenio.AdeudoPeriodoInicio).ToString("MMMM yyyy", new CultureInfo("es-MX")).ToUpper()}");
                rpt.SetParameterValue("PeriodoFin", $"{Utilerias.GetInicioPeriodoBimestral(Convenio.AdeudoPeriodoFin).ToString("MMMM", new CultureInfo("es-MX")).ToUpper()} - {Utilerias.GetFinPeriodoBimestral(Convenio.AdeudoPeriodoFin).ToString("MMMM yyyy", new CultureInfo("es-MX")).ToUpper()}");

                var parcialidades = Utilerias.GenerarFechasParcialidades(
                    (Convenio.Periodicidades)cmbPeriodicidades.SelectedValue, dtpFechaInicio.Value,
                    (int)nudNumeroPagos.Value);

                decimal importeParcialidad = AdeudoTotal / parcialidades.Count;

                var listaProyecciones = parcialidades.Select(p => new { Fecha = p, Importe = importeParcialidad }).ToList();

                string proyeccionPagos = string.Empty;

                int conteo = 0;

                foreach (var proyeccion in listaProyecciones)
                {
                    conteo++;
                    proyeccionPagos += $"PAGO {conteo}. {proyeccion.Fecha.ToShortDateString()} | ${proyeccion.Importe:N2}\n";
                }

                rpt.SetParameterValue("ProyeccionPagos", proyeccionPagos);

                DlgVistaPreviaReporte dlg = new DlgVistaPreviaReporte();
                dlg.Reporte = rpt;
                dlg.ShowDialog();
            }

            DialogResult = DialogResult.OK;
        }

        private void DlgConvenio_Load(object sender, EventArgs e)
        {
            CargarPeriodicidadesPago();

            if (Convenio.Id > 0)
            {
                AdeudoTotal = Convenio.Total;

                txtNoContrato.Text = Convenio.NoContrato.ToString("D10");

                dtpFechaInicio.Value = Convenio.FechaInicio;
                dtpFechaFin.Value = Convenio.FechaFin;

                nudNumeroPagos.Value = Convenio.NumeroPagos;
                cmbPeriodicidades.SelectedValue = Convenio.IdPeriodicidadPago;
                lblTotalPago.Text = $"Total a pagar ${AdeudoTotal:N2}";
            }
            else
            {
                if (Contrato == null)
                {
                    MessageBox.Show(
                        "No se ha cargado un contrato. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.Abort;
                    return;
                }


                if (AdeudoTotal == 0m)
                {
                    MessageBox.Show(
                        "No se puede establecer un convenio cuando el adeudo es igual a cero. Si esto no es así, contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.Abort;
                    return;
                }

                txtNoContrato.Text = Contrato.NoContrato.ToString("D10");
                lblTotalPago.Text = $"Total a pagar ${AdeudoTotal:N2}";

                nudNumeroPagos.Value = 1;

                if (Globales.MunicipioActual == Globales.Municipios.Tinguindin)
                {
                    // En tingüindin las parcialidades se establecen en mensualidades por defecto
                    cmbPeriodicidades.SelectedValue = (int)Convenio.Periodicidades.Mensual;
                }
            }
        }

        private void GenerarProyeccionesPagos()
        {
            if (cmbPeriodicidades.SelectedIndex == 0 || cmbPeriodicidades.SelectedIndex == -1) return;

            var parcialidades = Utilerias.GenerarFechasParcialidades(
                (Convenio.Periodicidades)cmbPeriodicidades.SelectedValue, dtpFechaInicio.Value,
                (int)nudNumeroPagos.Value);

            decimal importeParcialidad = AdeudoTotal / parcialidades.Count;

            var listaProyecciones = parcialidades.Select(p => new { Fecha = p, Importe = importeParcialidad }).ToList();

            dgvProyeccionPagos.DataSource = listaProyecciones;

            dtpFechaFin.Value = listaProyecciones.Last().Fecha;
        }


        private void nudNumeroPagos_ValueChanged(object sender, EventArgs e) => GenerarProyeccionesPagos();
        private void cmbPeriodicidades_SelectedIndexChanged(object sender, EventArgs e) => GenerarProyeccionesPagos();

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e) => GenerarProyeccionesPagos();

    }
}

