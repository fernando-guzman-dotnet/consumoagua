using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculoCobroAgua;
using Clases;
using SAPA.Clases;
using SAPA.Reportes;
using SAPA.Vistas.Dialogos.Complementarios;

namespace SAPA.Vistas.Dialogos
{
    public partial class DlgContrato : Form
    {
        public DlgContrato()
        {
            InitializeComponent();
        }

        public Contrato Contrato { get; set; } = new Contrato();

        private List<ContratoObservacion> _contratoObservacionesAdicionales = new List<ContratoObservacion>();


        private void LlenarCmbMedidores()
        {
            List<Medidor> medidores = Medidor.GetTodos();

            if (medidores.Count > 0)
            {
                medidores.Insert(0, new Medidor
                {
                    Id = 0,
                    Marca = "[ -- Seleccione un medidor -- ]"
                });

                cmbMedidores.DataSource = medidores;
                cmbMedidores.DisplayMember = "Marca";
                cmbMedidores.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No hay medidores registrados. Revise el catalogo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }


        private void LlenarCmbSeccion()
        {
            List<Seccion> secciones = Seccion.GetSecciones();

            if (secciones.Count > 0)
            {
                secciones.Insert(0, new Seccion { Id = 0, Descripcion = "[ -- Seleccione una sección -- ]" });

                cmbSeccion.DataSource = secciones;
                cmbSeccion.DisplayMember = "Descripcion";
                cmbSeccion.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No hay secciones registradas. Revise el catalogo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }

        private void LlenarCmbTarifa()
        {
            List<Tarifa> tarifas = Tarifa.GetTarifas();
            if (tarifas.Count > 0)
            {
                tarifas.Insert(0, new Tarifa { Id = 0, Descripcion = "[ -- Seleccione una tarifa -- ]" });

                cmbTarifa.DataSource = tarifas;
                cmbTarifa.DisplayMember = "Descripcion";
                cmbTarifa.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No hay tarifas registradas. Revise el catalogo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }

        private void LlenarCmbTipoVivienda()
        {
            List<TipoVivienda> tipoViviendas = TipoVivienda.GetTiposVivienda();

            if (tipoViviendas.Count > 0)
            {
                tipoViviendas.Insert(0, new TipoVivienda { Id = 0, Descripcion = "[ -- Seleccione un tipo de vivienda -- ]" });

                cmbTipoVivienda.DataSource = tipoViviendas;
                cmbTipoVivienda.DisplayMember = "Descripcion";
                cmbTipoVivienda.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No hay tipos de vivienda registrados. Revise el catalogo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }

        private void LlenarCmbTipoContrato()
        {
            List<TipoContrato> tipoContratos = TipoContrato.GetTiposContrato();


            if (tipoContratos.Count > 0)
            {
                tipoContratos.Insert(0, new TipoContrato { Id = 0, Descripcion = "[ -- Seleccione un tipo de contrato -- ]" });

                cmbTipoContrato.DataSource = tipoContratos;
                cmbTipoContrato.DisplayMember = "Descripcion";
                cmbTipoContrato.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No hay tipos de contrato registrados. Revise el catalogo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }

        private void LlenarCmbSector()
        {
            List<Sector> sectores = Sector.GetSectores();

            if (sectores.Count > 0)
            {
                sectores.Insert(0, new Sector { Id = 0, Descripcion = "[ -- Seleccione un sector -- ]" });

                cmbSector.DataSource = sectores;
                cmbSector.DisplayMember = "Descripcion";
                cmbSector.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No hay sectores registrados. Revise el catalogo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }

        private void LlenarCmbEstado()
        {
            List<Estado> estados = Estado.GetEstados();

            if (estados.Count > 0)
            {
                estados.Insert(0, new Estado { Id = 0, Nombre = "[ -- Seleccione un estado -- ]" });

                cmbEstado.DataSource = estados;
                cmbEstado.DisplayMember = "Nombre";
                cmbEstado.ValueMember = "Id";

                cmbEstado.Enabled = true;
            }
            else
            {
                MessageBox.Show("No hay estados registrados. Revise el catalogo e intente nuevamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
            }
        }


        private void LlenarCmbMunicipio(int idEstado)
        {
            if (cmbEstado.Items.Count == 0)
            {
                cmbEstado.Enabled = false;
                return;
            }

            List<Municipio> municipios = Municipio.GetMunicipiosAsociados(idEstado);

            if (municipios.Count == 0)
            {
                if (_formShown)
                    MessageBox.Show("No hay municipios asignados al estado seleccionado.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbMunicipio.DataSource = null;
                cmbMunicipio.Enabled = false;
                return;
            }


            municipios.Insert(0, new Municipio { Id = 0, Nombre = "[ -- Seleccione un municipio -- ]" });

            cmbMunicipio.DataSource = municipios;
            cmbMunicipio.DisplayMember = "Nombre";
            cmbMunicipio.ValueMember = "Id";

            cmbMunicipio.Enabled = true;
        }


        private void LlenarCmbLocalidad(int idMunicipio)
        {

            if (cmbMunicipio.Items.Count == 0)
            {
                cmbMunicipio.Enabled = false;
                return;
            }

            List<Localidad> localidades = Localidad.GetLocalidadesAsociadas(idMunicipio);

            if (localidades.Count == 0)
            {
                if (_formShown)
                    MessageBox.Show("No hay localidades asignadas al municipio seleccionado.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbLocalidad.DataSource = null;
                cmbLocalidad.Enabled = false;
                return;
            }

            localidades.Insert(0, new Localidad { Id = 0, Nombre = "[ -- Seleccione una localidad -- ]" });

            cmbLocalidad.DataSource = localidades;
            cmbLocalidad.DisplayMember = "Nombre";
            cmbLocalidad.ValueMember = "Id";

            cmbLocalidad.Enabled = true;
        }


        private void LlenarCmbColonias(int idLocalidad)
        {
            try
            {
                if (cmbLocalidad.Items.Count == 0)
                {
                    cmbColonia.Enabled = false;
                    return;
                }

                List<Colonia> colonias = Colonia.GetColoniasAsociadas(idLocalidad);

                if (colonias.Count == 0)
                {
                    if (_formShown)
                        MessageBox.Show("No hay colonias asignadas a la localidad seleccionada.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbColonia.DataSource = null;
                    cmbColonia.Enabled = false;
                    return;
                }

                colonias.Insert(0, new Colonia { Id = 0, Descripcion = "[ -- Seleccione una colonia -- ]" });

                cmbColonia.DataSource = colonias;
                cmbColonia.DisplayMember = "Descripcion";
                cmbColonia.ValueMember = "id";

                cmbColonia.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LlenarCmbColonias - " + ex.Message, "DlgContrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarCmbCalles(int idColonia)
        {
            try
            {
                if (cmbColonia.Items.Count == 0)
                {
                    cmbCalle.Enabled = false;
                    return;
                }

                List<Calle> calles = Calle.GetCallesByIdColonia(idColonia);

                if (calles.Count == 0)
                {

                    if (_formShown)
                        MessageBox.Show("No hay calles asignadas a la colonia seleccionada.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbCalle.DataSource = null;
                    cmbCalle.Enabled = false;
                    return;
                }

                calles.Insert(0, new Calle { Id = 0, Descripcion = "[ -- Seleccione una calle -- ]" });

                cmbCalle.DataSource = calles;
                cmbCalle.DisplayMember = "Descripcion";
                cmbCalle.ValueMember = "Id";

                cmbCalle.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LlenarCmbCalles - " + ex.Message, "DlgContrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DlgContrato_Load(object sender, EventArgs e)
        {
            cmbEstado.Enabled = false;
            cmbMunicipio.Enabled = false;
            cmbLocalidad.Enabled = false;
            cmbColonia.Enabled = false;
            cmbCalle.Enabled = false;

            LlenarCmbEstado();
            LlenarCmbSector();
            LlenarCmbSeccion();
            LlenarCmbTipoVivienda();
            LlenarCmbTipoContrato();
            LlenarCmbTarifa();
            LlenarCmbMedidores();

            if (Contrato.Id > 0)
            {
                tabControl.SelectedTab = tpContratista;

                dtpFecha.Value = Contrato.Fecha;
                dtpFecha.Enabled = false;

                txtNoContrato.Text = Contrato.NoContrato.ToString("D10");
                cmbSector.SelectedValue = Contrato.IdSector;
                chkActivo.Checked = Contrato.Activo;

                chkTieneAgua.Checked = Contrato.TieneAgua;
                chkTieneAlcantarillado.Checked = Contrato.TieneAlcantarillado;

                // Pestaña Detalles del Contrato
                cmbSeccion.SelectedValue = Contrato.IdSeccion;
                cmbTipoVivienda.SelectedValue = Contrato.IdTipoVivienda;
                cmbTipoContrato.SelectedValue = Contrato.IdTipoContrato;
                cmbTarifa.SelectedValue = Contrato.IdTarifa;

                if ((Contrato.Tipo)Contrato.IdTipoContrato == Contrato.Tipo.ServicioMedido)
                {
                    cmbMedidores.SelectedValue = Contrato.Medidor.Id;
                }

                // Pestaña Ubicación del Predio
                cmbEstado.SelectedValue = Contrato.IdEstado;

                LlenarCmbMunicipio(Contrato.IdEstado);
                cmbMunicipio.SelectedValue = Contrato.IdMunicipio;

                LlenarCmbLocalidad(Contrato.IdMunicipio);
                cmbLocalidad.SelectedValue = Contrato.IdLocalidad;

                LlenarCmbColonias(Contrato.IdSector);
                cmbColonia.SelectedValue = Contrato.IdColonia;

                LlenarCmbCalles(Contrato.IdColonia);
                cmbCalle.SelectedValue = Contrato.IdCalle;

                // Pestaña Contratista
                txtNombre.Text = Contrato.Usuario.Nombre;
                txtApellidoPaterno.Text = Contrato.Usuario.ApellidoPaterno;
                txtApellidoMaterno.Text = Contrato.Usuario.ApellidoMaterno;
                txtCURP.Text = Contrato.Usuario.CURP;
                txtRFC.Text = Contrato.Usuario.RFC;
                txtTelefono.Text = Contrato.Usuario.Telefono;
                txtCorreo.Text = Contrato.Usuario.Email;

                // Pestaña Ubicación de la toma
                txtCodigoPostal.Text = Contrato.CodigoPostal;
                txtNumeroExterior.Text = Contrato.NumeroExterior;
                txtNumeroInterior.Text = Contrato.NumeroInterior;

                // Pestaña Archivos Adjuntos
                CargarContratoBlobs();
                CargarContratoObservaciones();
            }
            else
            {
                tabControl.SelectedTab = tpContratista;
                lblAvisoContratoSinGuardar.Visible = true;
                lblAvisoContratoSinGuardarObservaciones.Visible = true;

                int ultimoNoContrato = Contrato.GetUltimoNoContrato();
                txtNoContrato.Text = (ultimoNoContrato + 1).ToString("D10");

                dtpFecha.Value = DateTime.Now;
            }

        }


        private bool ValidarGui()
        {
            if (string.IsNullOrWhiteSpace(txtNoContrato.Text))
            {
                MessageBox.Show(
                    "El numero de contrato no puede estar vacío. Complete el campo e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbSector.SelectedIndex == 0 || cmbSector.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado un sector. Seleccione una de las opciones e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (Contrato.Usuario == null)
            {
                MessageBox.Show(
                    "No has seleccionado un usuario para el contrato. Selecciona uno e intenta nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl.SelectedTab = tpContratista;
                return false;
            }

            if (cmbSeccion.SelectedIndex == 0 || cmbSeccion.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado una sección. Seleccione una de las opciones e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                tabControl.SelectedTab = tpContrato;
                return false;
            }

            if (cmbTipoContrato.SelectedIndex == 0 || cmbTipoContrato.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado un tipo de contrato. Seleccione una de las opciones e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                tabControl.SelectedTab = tpContrato;
                return false;
            }

            if (cmbTipoVivienda.SelectedIndex == 0 || cmbTipoVivienda.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado un tipo de vivienda. Seleccione una de las opciones e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                tabControl.SelectedTab = tpContrato;
                return false;
            }

            if (cmbTarifa.SelectedIndex == 0 || cmbTarifa.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado una tarifa. Seleccione una de las opciones e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                tabControl.SelectedTab = tpContrato;
                return false;
            }


            // Es un servicio medido

            if ((int)cmbTipoContrato.SelectedValue == (int)Contrato.Tipo.ServicioMedido)
            {
                if (cmbMedidores.SelectedIndex == 0 || cmbMedidores.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "No se ha seleccionado un medidor para este tipo de contrato. Seleccione una de las opciones e intente nuevamente.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    tabControl.SelectedTab = tpContrato;
                    return false;
                }
            }

            bool actualizar = Contrato.Id > 0;

            if (actualizar)
            {
                if ((int)cmbTipoContrato.SelectedValue != Contrato.IdTipoContrato)
                {
                    var contratoInfo = CalculoCobroAgua.CobroAgua.GetContratoInfo(Contrato.NoContrato);

                    if (contratoInfo.Tables["ERRORES"] != null)
                    {
                        MessageBox.Show($"No es posible cambiar el tipo de contrato debido a que no se puede calcular el adeudo actual del contrato. Contacte al área de soporte de SAPA.\n{contratoInfo.Tables["ERRORES"].Rows[0]["ERROR"]}");
                        return false;
                    }

                    var adeudoTotal = decimal.Parse(contratoInfo.Tables["CONTRATO"].Rows[0]["AdeudoTotal"].ToString());
                    if (adeudoTotal > 0)
                    {
                        var periodoInicio =
                            DateTime.Parse(
                                contratoInfo.Tables["CONTRATO"].Rows[0]["AdeudoPeriodoInicio"].ToString());

                        var periodoFin =
                            DateTime.Parse(
                                contratoInfo.Tables["CONTRATO"].Rows[0]["AdeudoPeriodoFin"].ToString());

                        MessageBox.Show(
                            $"No es posible cambiar el tipo de contrato hasta que se cubra el total de los adeudos pendientes.\n\n\tAdeudo Total: ${adeudoTotal:N2}\n\tPeriodo: {periodoInicio.ToString("MMMM yyyy", new CultureInfo("es-MX"))} - {periodoFin.ToString("MMMM yyyy", new CultureInfo("es-MX"))}",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                }


                if (!chkActivo.Checked && Contrato.Activo)
                {
                    /*var contratoInfo = CobroAgua.GetContratoInfo(Contrato.NoContrato);

                    if (contratoInfo.Tables["ERRORES"] != null)
                    {
                        MessageBox.Show($"No es posible cambiar el estatus del contrato debido a que no se puede calcular el adeudo actual del contrato. Contacte al área de soporte de SAPA.\n{contratoInfo.Tables["ERRORES"].Rows[0]["ERROR"]}");
                        return false;
                    }

                    var adeudoTotal = decimal.Parse(contratoInfo.Tables["CONTRATO"].Rows[0]["AdeudoTotal"].ToString());
                    if (adeudoTotal > 0)
                    {
                        var periodoInicio =
                            DateTime.Parse(
                                contratoInfo.Tables["CONTRATO"].Rows[0]["AdeudoPeriodoInicio"].ToString());

                        var periodoFin =
                            DateTime.Parse(
                                contratoInfo.Tables["CONTRATO"].Rows[0]["AdeudoPeriodoFin"].ToString());

                        MessageBox.Show(
                            $"No es posible cambiar el estatus del contrato hasta que se cubra el total de los adeudos pendientes.\n\n\tAdeudo Total: ${adeudoTotal:N2}\n\tPeriodo: {periodoInicio.ToString("MMMM yyyy", new CultureInfo("es-MX"))} - {periodoFin.ToString("MMMM yyyy", new CultureInfo("es-MX"))}",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        chkActivo.Checked = Contrato.Activo;
                        return false;
                    }*/


                    var cobroAgua = CobroAgua.GetContratoAdeudos(Contrato.NoContrato);

                    if (cobroAgua.Tables["ERRORES"] != null)
                    {
                        MessageBox.Show(cobroAgua.Tables["ERRORES"].Rows[0]["ERROR"].ToString(), this.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    bool tieneConvenio = bool.Parse(cobroAgua.Tables["RESUMEN"].Rows[0]["TieneConvenio"].ToString());

                    if (tieneConvenio)
                    {
                        MessageBox.Show("El contrato no puede ser suspendido porque tiene un convenio activo.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    List<AdeudoVista> adeudos = new List<AdeudoVista>();

                    foreach (DataRow fila in cobroAgua.Tables["DETALLES"].Rows)
                    {
                        AdeudoVista adeudo = new AdeudoVista();
                        adeudo = fila;

                        if (adeudo.FechaPeriodo.Year > DateTime.Now.Year)
                            continue;

                        adeudos.Add(adeudo);
                    }

                    int adeudosVencidos = adeudos.Count(a =>
                        a.FechaPeriodo < Utilerias.GetInicioPeriodoBimestral(DateTime.Now));

                    if (adeudosVencidos <= 6 && adeudosVencidos != 0)
                    {
                        MessageBox.Show(
                            "El contrato no puede ser suspendido porque hay menos de 6 bimestres vencidos a partir del corriente.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
            }


            if (cmbEstado.SelectedIndex == 0 || cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado un estado. Seleccione una de las opciones e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl.SelectedTab = tpUbicacionToma;
                return false;
            }

            if (cmbLocalidad.SelectedIndex == 0 || cmbLocalidad.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado una localidad. Seleccione una de las opciones e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl.SelectedTab = tpUbicacionToma;
                return false;
            }

            if (cmbMunicipio.SelectedIndex == 0 || cmbMunicipio.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado un municipio. Seleccione una de las opciones e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl.SelectedTab = tpUbicacionToma;
                return false;
            }


            if (cmbColonia.SelectedIndex == 0 || cmbColonia.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado una colonia. Seleccione una de las opciones e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl.SelectedTab = tpUbicacionToma;
                return false;
            }


            if (cmbCalle.SelectedIndex == 0 || cmbCalle.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No se ha seleccionado una calle. Seleccione una de las opciones e intente nuevamente.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                tabControl.SelectedTab = tpUbicacionToma;
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarGui()) return;


            bool actualizar = Contrato.Id > 0;

            bool anteriorEstatusActivo = Contrato.Activo;

            Contrato.NoContrato = int.Parse(txtNoContrato.Text);
            Contrato.Fecha = dtpFecha.Value;

            Contrato.Sector = cmbSector.SelectedItem as Sector;
            Contrato.Seccion = cmbSeccion.SelectedItem as Seccion;
            Contrato.TipoContrato = cmbTipoContrato.SelectedItem as TipoContrato;
            Contrato.TipoVivienda = cmbTipoVivienda.SelectedItem as TipoVivienda;
            Contrato.Tarifa = cmbTarifa.SelectedItem as Tarifa;


            if ((Contrato.Tipo)Contrato.IdTipoContrato == Contrato.Tipo.ServicioMedido)
            {
                Contrato.Medidor = new Medidor
                {
                    Id = (int)cmbMedidores.SelectedValue
                };
            }

            Contrato.Estado = cmbEstado.SelectedItem as Estado;
            Contrato.Municipio = cmbMunicipio.SelectedItem as Municipio;
            Contrato.Localidad = cmbLocalidad.SelectedItem as Localidad;
            Contrato.Colonia = cmbColonia.SelectedItem as Colonia;
            Contrato.Calle = cmbCalle.SelectedItem as Calle;

            Contrato.CodigoPostal = txtCodigoPostal.Text;
            Contrato.NumeroExterior = txtNumeroExterior.Text;
            Contrato.NumeroInterior = txtNumeroInterior.Text;

            Contrato.TieneAgua = chkTieneAgua.Checked;
            Contrato.TieneAlcantarillado = chkTieneAlcantarillado.Checked;

            Contrato.Activo = chkActivo.Checked;

            if (actualizar)
            {
                if (!Contrato.Actualizar())
                {
                    MessageBox.Show(
                        "Hubo un problema al intentar actualizar los datos del contrato. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (anteriorEstatusActivo != Contrato.Activo)
                {
                    ContratoHistoricoEstatus contratoHistoricoEstatus = new ContratoHistoricoEstatus();
                    contratoHistoricoEstatus.NoContrato = Contrato.NoContrato;
                    contratoHistoricoEstatus.Estatus = Contrato.Activo;
                    contratoHistoricoEstatus.Fecha = DateTime.Now;

                    if (!contratoHistoricoEstatus.Agregar())
                    {
                        MessageBox.Show(
                            "Hubo un problem al intentar registrar el historico del cambio de estatus del contrato. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (_contratoObservacionesAdicionales.Any())
                {
                    foreach (ContratoObservacion contratoObservacion in _contratoObservacionesAdicionales)
                    {
                        if (!contratoObservacion.Agregar())
                        {
                            MessageBox.Show(
                                "Hubo un error al intentar registrar una de las observaciones del contrato. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.");
                        }
                    }
                }


                MessageBox.Show("Los datos del contrato se actualizaron correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!Contrato.Guardar())
                {
                    MessageBox.Show(
                        "Hubo un problema al intentar guardar los datos del contrato. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                MessageBox.Show("Los datos del contrato fueron guardados correctamente.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            if (chkImprimirAlGuardarse.Checked)
            {
                RptContratoPrestacion rpt = new RptContratoPrestacion();

                DataSet dsReporte = new DataSet();
                dsReporte.Tables.Add(Organismo.Actual);

                rpt.SetDataSource(dsReporte);

                rpt.SetParameterValue("FechaSolicitud", Contrato.Fecha.ToShortDateString());
                rpt.SetParameterValue("NombreContribuyente", Contrato.NombreUsuario);
                rpt.SetParameterValue("Direccion", Contrato.Direccion);

                rpt.SetParameterValue("NoContrato", Contrato.NoContrato.ToString("D10"));

                rpt.SetParameterValue("NombreMunicipio", Contrato.Municipio.Nombre);
                rpt.SetParameterValue("FechaCompleta", Contrato.Fecha.ToString("dd 'de' MMMM 'del' yyyy", new CultureInfo("es-MX")));

                DlgVistaPreviaReporte dlg = new DlgVistaPreviaReporte();
                dlg.Reporte = rpt;
                dlg.ShowDialog();
            }

            DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;


        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            DlgSeleccionarUsuario dlg = new DlgSeleccionarUsuario();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Contrato.Usuario = dlg.Usuario;
                txtNombre.Text = Contrato.Usuario.Nombre;
                txtApellidoPaterno.Text = Contrato.Usuario.ApellidoPaterno;
                txtApellidoMaterno.Text = Contrato.Usuario.ApellidoMaterno;
                txtCURP.Text = Contrato.Usuario.CURP;
                txtRFC.Text = Contrato.Usuario.RFC;
                txtCorreo.Text = Contrato.Usuario.Email;
                txtTelefono.Text = Contrato.Usuario.Telefono;
            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarPrevisualizacionDireccion();

                if (cmbEstado.SelectedIndex == 0 || cmbEstado.SelectedIndex == -1)
                {
                    cmbMunicipio.DataSource = null;
                    cmbMunicipio.Enabled = false;
                    return;
                }

                int idEstado = int.Parse(cmbEstado.SelectedValue.ToString());
                LlenarCmbMunicipio(idEstado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("cmbEstado_SelectedIndexChanged - " + ex.Message, "Formulario Dialog_Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarPrevisualizacionDireccion();

                if (cmbMunicipio.SelectedIndex == 0 || cmbMunicipio.SelectedIndex == -1)
                {
                    cmbLocalidad.DataSource = null;
                    cmbLocalidad.Enabled = false;
                    return;
                }

                int idMunicipio = int.Parse(cmbMunicipio.SelectedValue.ToString());
                LlenarCmbLocalidad(idMunicipio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("cmbMunicipio_SelectedIndexChanged - " + ex.Message, "Formulario Dialog_Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarPrevisualizacionDireccion();

                if (cmbLocalidad.SelectedIndex == 0 || cmbLocalidad.SelectedIndex == -1)
                {
                    cmbColonia.DataSource = null;
                    cmbColonia.Enabled = false;
                    return;
                }

                int idLocalidad = int.Parse(cmbLocalidad.SelectedValue.ToString());
                LlenarCmbColonias(idLocalidad);

            }
            catch (Exception ex)
            {
                MessageBox.Show("cmbLocalidad_SelectedIndexChanged - " + ex.Message, "Formulario Dialog_Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmbColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarPrevisualizacionDireccion();

                if (cmbColonia.SelectedIndex == 0 || cmbColonia.SelectedIndex == -1)
                {
                    cmbCalle.DataSource = null;
                    cmbCalle.Enabled = false;
                    return;
                }

                int idColonia = int.Parse(cmbColonia.SelectedValue.ToString());
                LlenarCmbCalles(idColonia);
            }
            catch (Exception ex)
            {
                MessageBox.Show("cmbColonia_SelectedIndexChanged - " + ex.Message, "Formulario Dialog_Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTipoContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var tipoContrato = cmbTipoContrato.SelectedItem as TipoContrato;
                if ((Contrato.Tipo)tipoContrato.Id == Contrato.Tipo.ServicioMedido)
                    grpDetallesMedidor.Visible = true;
                else
                    grpDetallesMedidor.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("cmbTipoContrato_SelectedIndexChanged - " + ex, "Formulario Dialog_Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTarifa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_formShown) return;
            if (cmbTarifa.SelectedIndex == 0 || cmbTarifa.SelectedIndex == -1) return;
        }



        private bool _formShown;
        private void DlgContrato_Shown(object sender, EventArgs e) => _formShown = true;

        private void cmbCalle_SelectedIndexChanged(object sender, EventArgs e) => ActualizarPrevisualizacionDireccion();
        private void txtCodigoPostal_TextChanged(object sender, EventArgs e) => ActualizarPrevisualizacionDireccion();
        private void txtNumeroExterior_TextChanged(object sender, EventArgs e) => ActualizarPrevisualizacionDireccion();
        private void txtNumeroInterior_TextChanged(object sender, EventArgs e) => ActualizarPrevisualizacionDireccion();


        private void ActualizarPrevisualizacionDireccion()
        {
            var calle = (cmbCalle.SelectedIndex == 0 || cmbCalle.SelectedIndex == -1) ? string.Empty : cmbCalle.Text;
            var noExterior = string.IsNullOrWhiteSpace(txtNumeroExterior.Text) ? string.Empty : $" No. {txtNumeroExterior.Text}";
            var noInterior = string.IsNullOrWhiteSpace(txtNumeroInterior.Text) ? string.Empty : $" Int. {txtNumeroInterior.Text}";
            var colonia = (cmbColonia.SelectedIndex == 0 || cmbColonia.SelectedIndex == -1) ? string.Empty : $"Col. {cmbColonia.Text}";
            var codigoPostal = string.IsNullOrWhiteSpace(txtCodigoPostal.Text) ? string.Empty : $"CP. {txtCodigoPostal.Text}";
            var municipio = (cmbMunicipio.SelectedIndex == 0 || cmbMunicipio.SelectedIndex == -1) ? string.Empty : $" {cmbMunicipio.Text}";
            var estado = (cmbMunicipio.SelectedIndex == 0 || cmbMunicipio.SelectedIndex == -1) ? string.Empty : cmbEstado.Text;

            txtPrevDireccion.Text = $"{calle}{noExterior}{noInterior}, {colonia}, {codigoPostal}{municipio}, {estado}".ToUpper();
        }


        private void CargarContratoBlobs()
        {
            dgvCargas.DataSource = ContratoBlob.GetContratoBlobs(Contrato.NoContrato);

            dgvCargas.Columns["Id"].Visible = false;
            dgvCargas.Columns["GuidBlob"].Visible = false;
            dgvCargas.Columns["NoContrato"].Visible = false;
            dgvCargas.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCargas.Columns["Extension"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCargas.Columns["FechaSubida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void CargarContratoObservaciones()
        {
            dgvObservaciones.AutoGenerateColumns = false;

            var contratoObservaciones = ContratoObservacion.GetContratoObservaciones(Contrato.NoContrato);

            if (_contratoObservacionesAdicionales.Any())
            {
                contratoObservaciones.AddRange(_contratoObservacionesAdicionales);
            }

            dgvObservaciones.DataSource = contratoObservaciones.OrderBy(co => co.Fecha).ToList();
        }


        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.Filter = "All files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                var guidBlob = azureBlobHelper.uploadFile(dlg.FileName,
                    azureBlobHelper.BlobFolders.ArchivosContratos);

                if (guidBlob == null)
                {
                    MessageBox.Show("Hubo un error al intentar cargar el archivo adjunto. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.");
                    return;
                }

                ContratoBlob contratoBlob = new ContratoBlob();

                contratoBlob.GuidBlob = guidBlob;
                contratoBlob.NoContrato = int.Parse(txtNoContrato.Text);
                contratoBlob.Nombre = Path.GetFileNameWithoutExtension(dlg.FileName);
                contratoBlob.Extension = Path.GetExtension(dlg.FileName);

                if (!contratoBlob.Subir())
                {
                    MessageBox.Show(
                        "Hubo un error al intentar registrar la carga del archivo del contrato. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("El archivo fue cargado correctamente.", this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarContratoBlobs();
            }
        }

        private void dgvCargas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCargas.CurrentRow == null) return;

            ContratoBlob contratoBlob = dgvCargas.CurrentRow.DataBoundItem as ContratoBlob;

            string myDocDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            myDocDir = $"{myDocDir}\\{azureBlobHelper.BlobFolders.ArchivosContratos.ToString()}\\{$"Contrato {contratoBlob.NoContrato:D10}"}\\{contratoBlob.Nombre}{contratoBlob.Extension}";

            if (File.Exists(myDocDir))
            {
                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{@myDocDir}\"");
                return;
            }


            bool archivoDescargado = azureBlobHelper.downloadFile(contratoBlob.GuidBlob, myDocDir, azureBlobHelper.BlobFolders.ArchivosContratos);

            if (!archivoDescargado)
            {
                MessageBox.Show(
                    "Hubo un problema al intentar descargar el archivo seleccionado. Intente nuevamente, si el problema persiste contacte al área de soporte de SAPA.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"El archivo {contratoBlob.Nombre}{contratoBlob.Extension} fue descargado correctamente. El archivo también podrá ser encontrado en Documentos\\ArchivosContratos\\{Contrato.NoContrato:D10}.",
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{myDocDir}\"");
        }

        private void cmbMedidores_Format(object sender, ListControlConvertEventArgs e)
        {
            var medidor = (e.ListItem as Medidor);

            if (medidor == null) return;

            if (medidor.Id > 0)
                e.Value = $"{medidor.NoMedidor:D3} | {medidor.Marca.ToUpper()}";
        }

        private void btnAgregarObservacion_Click(object sender, EventArgs e)
        {
            DlgAgregarContratoObservacion dlg = new DlgAgregarContratoObservacion();

            dlg.ContratoObservacion = new ContratoObservacion
            {
                NoContrato = Contrato.NoContrato
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _contratoObservacionesAdicionales.Add(dlg.ContratoObservacion); 
                CargarContratoObservaciones();
            }
        }
    }
}


