using Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using SAPA.Clases;
using SAPA.Properties;
using SAPA.Reportes;
using SAPA.Vistas;
using SAPA.Vistas.Dialogos;
using SAPA.Vistas.Dialogos.Complementarios;
using SAPA.Vistas.Paneles;


namespace SAPA
{
    public partial class FrmPrincipal : Form
    {
        private const string WIP_MSG =
            "Este módulo sigue en construcción. Revise nuevamente en próximas actualizaciones.";

        private string _ayuntamiento;

        public string Ayuntamiento
        {
            get { return _ayuntamiento; }
            set
            {
                _ayuntamiento = value;
                lblAyuntamiento.Text = $"SERVIDOR: {_ayuntamiento.ToUpper()}";
            }
        }

        private Empleado _empleadoActivo;

        public Empleado EmpleadoActivo
        {
            get { return _empleadoActivo; }
            set
            {
                _empleadoActivo = value;
                Empleado.Actual = value;
                lblUsuarioActivo.Text = $"USUARIO: {_empleadoActivo.Usuario}";
            }
        }

        public List<EmpleadoPermisosModulo> PermisosAplicables { get; set; } = new List<EmpleadoPermisosModulo>();

        public bool SesionCerrada { get; set; }

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        #region Menu Renderer

        // El texto usado para los items del Menú es blanco, al pasar el mouse sobre estos
        // es complicado visualizarlo.

        // Usar un Renderer nos permite reemplazar los colores usados, incluso crear degradados.

        // Más sobre ToolStripProfessionalRender
        // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.toolstripprofessionalrenderer?view=net-5.0

        private class Renderer : ToolStripProfessionalRenderer
        {
            public Renderer() : base(new ColorimetriaMenu())
            {
            }
        }

        private class ColorimetriaMenu : ProfessionalColorTable
        {
            public override Color MenuItemPressedGradientBegin => Color.FromArgb(0, 50, 78);
            public override Color MenuItemPressedGradientEnd => MenuItemPressedGradientBegin;
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(0, 50, 78);
            public override Color MenuItemSelectedGradientEnd => MenuItemSelectedGradientBegin;
            public override Color MenuItemBorder => Color.Black;
            public override Color MenuBorder => Color.Black;
        }

        #endregion

        private const int cGrip = 16; // Grip size
        private const int cCaption = 32; // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2; // HTCAPTION
                    return;
                }

                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }

            base.WndProc(ref m);
        }


        public bool TabExists(string tabName, bool forceFocus = true)
        {
            bool tabFound = false;

            foreach (TabPage item in tabManager.TabPages)
            {
                if (item.Text == tabName)
                {
                    tabFound = true;

                    if (forceFocus)
                        tabManager.SelectedTab = item;
                }
            }

            return tabFound;
        }

        private void tabManager_ControlAdded(object sender, ControlEventArgs e) =>
            tabManager.Visible = tabManager.TabCount != 0;

        private void tabManager_ControlRemoved(object sender, ControlEventArgs e) =>
            tabManager.Visible = !(tabManager.TabCount <= 1);


        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = $"{Globales.CurrentEntryPoint.ToString()}";
            this.Text += " - SAPA - ";

            if (Globales.CurrentEntryPoint == Globales.EntryPoints.Pruebas) this.Text += "[AMBIENTE DE PRUEBAS]" + ' ';


            if (ApplicationDeployment.IsNetworkDeployed)
            {
                this.Text += $"[Version {ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4)}]";
            }
            else this.Text += "[DEBUG]";

            Organismo.Actual = Organismo.GetOrganismo();

            if (Organismo.Actual == null)
            {
                MessageBox.Show("El sistema ha detectado que no se han agregado los datos del Organismo.\n\n"
                                + "Para hacerlo, haga clic sobre la pestaña \"Administración\"", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Organismo.Actual = new Organismo();
            }

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            menuStrip.Renderer = new Renderer();

            AplicarIconografia();
            GenerarPermisosAplicables();

            CargarPermisosUsuario();
        }

        private void CargarPermisosUsuario()
        {
            if (Empleado.Actual.PermisosModulos.Count == 0)
            {
                foreach (ToolStripMenuItem item in menuStrip.Items)
                {
                    // Permisos sobre modulos

                    var permiso = PermisosAplicables.FirstOrDefault(p => p.Codigo.Contains(item.Name));

                    if (permiso != null)
                    {
                        item.Enabled = permiso.Habilitado;
                        item.Visible = permiso.Visible;
                    }

                    // Permisos sobre submodulos

                    foreach (var dropItem in GetDropDownItems(item))
                    {
                        permiso = PermisosAplicables.FirstOrDefault(p => p.Codigo.Contains(dropItem.Name));

                        if (permiso != null)
                        {
                            dropItem.Enabled = permiso.Habilitado;
                            dropItem.Visible = permiso.Visible;
                        }
                    }
                }
                return;
            }

            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                // Permisos sobre modulos

                var permiso = Empleado.Actual.PermisosModulos.FirstOrDefault(p => p.Codigo.Contains(item.Name));

                if (permiso != null)
                {
                    item.Enabled = permiso.Habilitado;
                    item.Visible = permiso.Visible;
                }

                // Permisos sobre submodulos

                foreach (var dropItem in GetDropDownItems(item))
                {
                    permiso = Empleado.Actual.PermisosModulos.FirstOrDefault(p => p.Codigo.Contains(dropItem.Name));

                    if (permiso != null)
                    {
                        dropItem.Enabled = permiso.Habilitado;
                        dropItem.Visible = permiso.Visible;
                    }
                }
            }

        }

        private void AplicarIconografia()
        {
            // Ocultar botones para temas en barra de estado en builds SAPA
            if (Globales.CurrentEntryPoint != Globales.EntryPoints.SAPA)
            {
                Azul.Visible = false;
                Verde.Visible = false;
                Rojo.Visible = false;
                Guinda.Visible = false;
                Amarillo.Visible = false;
                Morado.Visible = false;
            }

            // Ocultar el botón Acerca De para builds SAPA
            if (Globales.CurrentEntryPoint == Globales.EntryPoints.SAPA)
                acercaDeToolStripMenuItem.Visible = false;

            // Iconos de los modulos
            if (Globales.GetImage("CerrarSesion") != null)
                cerrarSesionToolStripMenuItem.Image = Globales.GetImage("CerrarSesion");
            if (Globales.GetImage("ModuloAcercaDe") != null)
                acercaDeToolStripMenuItem.Image = Globales.GetImage("ModuloAcercaDe");
            if (Globales.GetImage("ModuloAdministracion") != null)
                menuAdministracion.Image = Globales.GetImage("ModuloAdministracion");
            ;
            if (Globales.GetImage("ModuloOrdenesTrabajo") != null)
                menuOrdenesTrabajo.Image = Globales.GetImage("ModuloOrdenesTrabajo");
            if (Globales.GetImage("ModuloLecturas") != null) menuLecturas.Image = Globales.GetImage("ModuloLecturas");
            if (Globales.GetImage("ModuloConvenios") != null)
                menuConvenios.Image = Globales.GetImage("ModuloConvenios");
            if (Globales.GetImage("ModuloReportes") != null) menuReportes.Image = Globales.GetImage("ModuloReportes");
            if (Globales.GetImage("ModuloCobranza") != null) menuCobranza.Image = Globales.GetImage("ModuloCobranza");
            if (Globales.GetImage("ModuloFacturacion") != null)
                menuFacturacion.Image = Globales.GetImage("ModuloFacturacion");
            if (Globales.GetImage("ModuloNotificaciones") != null)
                menuNotificaciones.Image = Globales.GetImage("ModuloNotificaciones");
            if (Globales.GetImage("ModuloTarifas") != null) menuTarifario.Image = Globales.GetImage("ModuloTarifas");
            if (Globales.GetImage("ModuloContratos") != null)
                menuContratos.Image = Globales.GetImage("ModuloContratos");
            if (Globales.GetImage("ModuloCatalogos") != null)
                menuCatalogos.Image = Globales.GetImage("ModuloCatalogos");


            // Imagen de fondo
            this.Icon = Globales.GetIcon("Sistema");
            ImagenFondo.BackgroundImage = Globales.GetImage("ImagenMenuPrincipal");

            foreach (ToolStripStatusLabel label in statusStrip.Items)
            {
                if (Globales.CurrentEntryPoint == Globales.EntryPoints.SAPA) label.ForeColor = Color.Black;
            }

            // Icono para submodulos
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {

                if (Globales.CurrentEntryPoint == Globales.EntryPoints.SAPA) item.ForeColor = Color.Black;

                // Submenús
                foreach (var children in GetDropDownItems(item))
                {
                    if (!(children is ToolStripMenuItem)) continue;
                    ((ToolStripMenuItem)children).Image = Globales.GetImage("Submodulos");
                }
            }


        }


        private void GenerarPermisosAplicables()
        {
            List<ToolStripItem> listaModulos = new List<ToolStripItem>();

            foreach (ToolStripItem toolItem in menuStrip.Items)
            {
                if (toolItem is ToolStripSeparator) continue;

                listaModulos.Add(toolItem);
                listaModulos.AddRange(GetDropDownItems(toolItem));
            }

            foreach (var modulo in listaModulos)
            {
                if (modulo.Text.Contains("acercaDe") || modulo.Text.Contains("cerrarSesion")) continue;

                PermisosAplicables.Add(new EmpleadoPermisosModulo
                {
                    Codigo = modulo.Name,
                    Descripcion = modulo.Name.Contains("menu", StringComparison.Ordinal) ? $"Módulo {modulo.Text}" : $"Submodulo {modulo.Text}",
                    Visible = false,
                    Habilitado = false
                });
            }
        }

        private IEnumerable<ToolStripItem> GetDropDownItems(ToolStripItem item)
        {
            if (item is ToolStripMenuItem)
            {
                foreach (ToolStripItem tsi in (item as ToolStripMenuItem).DropDownItems)
                {
                    if (tsi is ToolStripMenuItem)
                    {
                        if ((tsi as ToolStripMenuItem).HasDropDownItems)
                        {
                            foreach (ToolStripItem subItem in GetDropDownItems((tsi as ToolStripMenuItem)))
                                yield return subItem;
                        }
                        yield return (tsi as ToolStripMenuItem);
                    }
                }
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Usuarios"))
                {
                    TabPage t = new TabPage("Usuarios");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlUsuario frm = new PnlUsuario();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("serviciosToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tarifaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Catálogo Tarifas"))
                {
                    TabPage t = new TabPage("Catálogo Tarifas");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlTarifa pnl = new PnlTarifa();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("tarifaToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void seccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Secciones"))
                {
                    TabPage t = new TabPage("Secciones");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlSeccion pnl = new PnlSeccion();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("seccionToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tipoViviendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Tipos de Vivienda"))
                {
                    TabPage t = new TabPage("Tipo de Vivienda");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlTipoVivienda pnl = new PnlTipoVivienda();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    //if (empleado.seccionesPermisos.Length > 4)
                    //{
                    //    frm.setPermisos(empleado.seccionesPermisos[4]);
                    //}
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("tipoViviendaToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void conceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Conceptos"))
                {
                    TabPage t = new TabPage("Conceptos");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlConcepto pnl = new PnlConcepto();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("conceptoToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Contratos"))
                {
                    TabPage t = new TabPage("Contratos");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlContrato pnl = new PnlContrato();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;

                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("contratoToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuTarifario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Tarifario"))
                {
                    TabPage t = new TabPage("Tarifario");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlTarifario pnl = new PnlTarifario();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;

                    pnl.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("menuPagos_Click - " + ex.Message, "Formulario Principal", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        public bool cerrando = false;

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cerrando)
                return;
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabManager.TabCount > 0)
                {
                    frmSalirMensaje3 frmSalir = new frmSalirMensaje3();
                    frmSalir.ShowDialog();

                    if (frmSalir.DialogResult == DialogResult.Yes)
                    {
                        SesionCerrada = true;
                        this.Close();
                    }
                    //string cadenaPanel = "";
                    //if (tabManager.TabCount == 1)
                    //{
                    //    cadenaPanel = tabManager.TabCount + " panel abierto";
                    //}
                    //else
                    //{
                    //    cadenaPanel = tabManager.TabCount + " paneles abiertos";
                    //}
                    //result = D_YesNo.ShowResponse("ADVERTENCIA: PANELES ABIERTOS",
                    //"Actualmente hay " + cadenaPanel + ".\n¿Desea continuar?",
                    //Properties.Resources.warning,
                    //"Aceptar",
                    //"Cancelar"
                    //);
                }
                else
                {
                    frmSalirMensaje2 frm = new frmSalirMensaje2();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Yes)
                    {
                        SesionCerrada = true;
                        this.Close();
                    }
                }
                //if (result == DialogResult.Yes)
                //{
                //    new Login().Show();
                //    this.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("cerrarSesionToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Empleados"))
                {
                    TabPage t = new TabPage("Empleados");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlEmpleados pnl = new PnlEmpleados();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("empleadosToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FrmPrincipal_SizeChanged(object sender, EventArgs e)
        {
            float percentW = 1404 * 100 / 1420;
            float percentH = 741 * 100 / 839;
            int w = (int)(this.Width * percentW / 100);
            int h = (int)(this.Height * percentH / 100);
            ImagenFondo.Size = new Size(this.Width, h);
            tabManager.Size = new Size(this.Width, h);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start("https://sapa.com.mx");

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e) => cerrando = true;

        private void capturaDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Cobranza"))
                {

                    TabPage t = new TabPage("Cobranza");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlPagos frm = new PnlPagos();

                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;

                    frm.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("capturaDePagosToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void porcentajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Porcentajes"))
                {
                    TabPage t = new TabPage("Porcentajes");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmPorcentajes frm = new FrmPorcentajes();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("porcentajesToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void capturaLecturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Captura de Lecturas"))
                {
                    TabPage t = new TabPage("Captura de Lecturas");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;


                    FrmCapturaLecturas frm = new FrmCapturaLecturas();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("capturaLecturasToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tipoDeDescuentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Tipos de Descuento"))
                {
                    TabPage t = new TabPage("Tipos de Descuento");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;


                    PnlTipoDescuento frm = new PnlTipoDescuento();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("tipoDeDescuentosToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void descuentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Descuentos"))
                {
                    TabPage t = new TabPage("Descuentos");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);

                    PnlDescuentos pnl = new PnlDescuentos();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    tabManager.SelectedTab = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("descuentosToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void callesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Calles"))
                {
                    TabPage t = new TabPage("Calles");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);

                    PnlCalle frm = new PnlCalle();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;

                    tabManager.SelectedTab = t;

                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("callesToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void coloniasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Colonias"))
                {
                    TabPage t = new TabPage("Colonias");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);

                    PnlColonia dlg = new PnlColonia();
                    dlg.FrmPrincipal = this;
                    dlg.TopLevel = false;
                    dlg.Parent = t;

                    tabManager.SelectedTab = t;

                    dlg.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("coloniasToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Sectores"))
                {
                    TabPage t = new TabPage("Sectores");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);

                    PnlSectores pnl = new PnlSectores();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();

                    tabManager.SelectedTab = t;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("sectoresToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void medidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Medidores"))
                {
                    TabPage t = new TabPage("Medidores");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlMedidor frm = new PnlMedidor();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("medidoresToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void organismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Organismo"))
                {
                    TabPage t = new TabPage("Organismo");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlAdministracion pnl = new PnlAdministracion();
                    pnl.FrmPrincipal = this;
                    pnl.Organismo = Organismo.Actual;
                    pnl.TopLevel = false;
                    pnl.Parent = t;

                    pnl.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("organismoToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void bitacoraEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Bitacora empleado"))
                {
                    TabPage t = new TabPage("Bitacora empleado");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmBitacora frm = new FrmBitacora();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("bitacoraEmpleadosToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void consultaDeHistoricosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void capturaPorLotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Lectura Por Lotes"))
                {
                    FrmLecturaPorLotes frm = new FrmLecturaPorLotes(this);
                    TabPage t = new TabPage("Lectura Por Lotes");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);

                    frm.TopLevel = false;
                    frm.Parent = t;
                    tabManager.SelectedTab = t;
                    //if (empleado.seccionesPermisos.Length > 8)
                    //{
                    //    frm.setPermisos(empleado.seccionesPermisos[8]);
                    //}
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("capturaPorLotesToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void notificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Notificaciones"))
                {
                    TabPage t = new TabPage("Notificaciones");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlNotificaciones pnl = new PnlNotificaciones();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("notificacionesToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void arqueoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Arqueo"))
                {
                    TabPage t = new TabPage("Arqueo");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmArqueo frm = new FrmArqueo();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("QuejasToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminOrdenesTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Administrar Ordenes"))
                {
                    TabPage t = new TabPage("Administrar Ordenes");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlAdminOrdenesTrabajo pnl = new PnlAdminOrdenesTrabajo();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("accionesToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void departamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Departamentos"))
                {
                    TabPage t = new TabPage("Departamentos");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlDepartamento pnl = new PnlDepartamento();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("departamentosToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Bancos"))
                {
                    TabPage t = new TabPage("Bancos");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlBanco pnl = new PnlBanco();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("bancosToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void configuracionSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Config. del Sistema"))
                {
                    TabPage t = new TabPage("Config. del Sistema");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmConfiguracion frm = new FrmConfiguracion();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;

                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("configuracionSistemaToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ordenesTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Ordenes de Trabajo"))
                {
                    TabPage t = new TabPage("Ordenes de Trabajo");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlOrdenesTrabajo pnl = new PnlOrdenesTrabajo();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("bancosToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void genericWipMessage_Click(object sender, EventArgs e) => MessageBox.Show(WIP_MSG,
            "TRABAJO EN PROGRESO", MessageBoxButtons.OK, MessageBoxIcon.Information);


        private void Morado_Click(object sender, EventArgs e) => this.Icon = Globales.GetIcon("SistemaMorado");
        private void Amarillo_Click(object sender, EventArgs e) => this.Icon = Globales.GetIcon("SistemaAmarillo");
        private void Guinda_Click(object sender, EventArgs e) => this.Icon = Globales.GetIcon("SistemaGuinda");
        private void Rojo_Click(object sender, EventArgs e) => this.Icon = Globales.GetIcon("SistemaRojo");
        private void Verde_Click(object sender, EventArgs e) => this.Icon = Globales.GetIcon("SistemaVerde");
        private void Azul_Click(object sender, EventArgs e) => this.Icon = Globales.GetIcon("SistemaAzul");

        private void estadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Estados"))
                {
                    TabPage t = new TabPage("Estados");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlEstado pnl = new PnlEstado();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("estadosToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Localidades"))
                {
                    TabPage t = new TabPage("Localidades");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlLocalidad pnl = new PnlLocalidad();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("localidadesToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void municipiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Municipios"))
                {
                    TabPage t = new TabPage("Municipios");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlMunicipio pnl = new PnlMunicipio();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("municipiosToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cajasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (!this.TabExists("Cajas"))
                {
                    TabPage t = new TabPage("Cajas");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    PnlCaja pnl = new PnlCaja();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("cajasToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void corteCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Corte de Caja"))
                {
                    TabPage t = new TabPage("Corte de Caja");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmCorteCajaExcel frm = new FrmCorteCajaExcel();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("corteCajaToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reporteDeudoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Deudores"))
                {
                    TabPage t = new TabPage("Deudores");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmDeudores frm = new FrmDeudores();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("reporteDeudoresToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void desaplicacionPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Desaplicación Pagos"))
                {
                    TabPage t = new TabPage("Desaplicación Pagos");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmCancelarPago frm = new FrmCancelarPago();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("desaplicacionPagosToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportePagosCancelados_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Pagos Cancelados"))
                {
                    TabPage t = new TabPage("Pagos Cancelados");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmRptPagosCancelados frm = new FrmRptPagosCancelados();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("desaplicacionPagosToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void permisosEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Permisos Empleado"))
                {
                    TabPage t = new TabPage("Permisos Empleado");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmPermisosEmpleado frm = new FrmPermisosEmpleado();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("permisosEmpleadoToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reimpresionRecibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Reimpresión Recibos"))
                {
                    TabPage t = new TabPage("Reimpresión Recibos");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmReimpresionRecibo frm = new FrmReimpresionRecibo();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("permisosEmpleadoToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void facturaIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Factura de Ingresos"))
                {
                    TabPage t = new TabPage("Factura de Ingresos");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmFacturar33 frm = new FrmFacturar33();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("facturaIngresosToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Ver Facturas"))
                {
                    TabPage t = new TabPage("Ver Facturas");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmFacturasBuscar33 frm = new FrmFacturasBuscar33(true, "I Ingreso");
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("permisosEmpleadoToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tipoDeOrdenTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Tipos de Orden de Trabajo"))
                {
                    TabPage t = new TabPage("Tipos de Orden de Trabajo");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;


                    PnlTipoOrdenTrabajo frm = new PnlTipoOrdenTrabajo();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("tipoDeOrdenTrabajoToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void situacionActualCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Situación actual de contratos"))
                {
                    TabPage t = new TabPage("Situación actual de contratos");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;


                    FrmSituacionActualContratos frm = new FrmSituacionActualContratos();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("situacionActualCuentasToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuConvenios_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Convenios"))
                {
                    TabPage t = new TabPage("Convenios");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;


                    PnlConvenio pnl = new PnlConvenio();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("menuConvenios_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void revisionesContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Revisiones de Contratos"))
                {
                    TabPage t = new TabPage("Revisiones de Contratos");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;


                    PnlRevisionContrato pnl = new PnlRevisionContrato();
                    pnl.FrmPrincipal = this;
                    pnl.TopLevel = false;
                    pnl.Parent = t;
                    pnl.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("revisionesContratosToolStripMenuItem_Click - " + ex.Message, "Formulario Principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void constanciaDeNoAdeudosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DlgSeleccionarCuenta dlg = new DlgSeleccionarCuenta();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                RptTinguindinConstanciaNoAdeudo rpt = new RptTinguindinConstanciaNoAdeudo();


                DataSet dsReporte = new DataSet();
                dsReporte.Tables.Add(Organismo.Actual);

                rpt.SetDataSource(dsReporte);

                rpt.SetParameterValue("Domicilio", dlg.Contrato.Direccion);
                rpt.SetParameterValue("FechaCompleta", DateTime.Now.ToString("dd 'de' MMMM 'del' yyyy", new CultureInfo("es-MX")));
                rpt.SetParameterValue("NombreCompletoUsuario", dlg.Contrato.Usuario.NombreCompleto);

                DlgVistaPreviaReporte dlgVistaPrevia = new DlgVistaPreviaReporte();
                dlgVistaPrevia.Reporte = rpt;
                dlgVistaPrevia.ShowDialog();
            }
        }

        private void constanciaDeNoServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DlgConstanciaNoServicios dlg = new DlgConstanciaNoServicios();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                RptTinguindinConstanciaNoServicios rpt = new RptTinguindinConstanciaNoServicios();

                DataSet dsReporte = new DataSet();
                dsReporte.Tables.Add(Organismo.Actual);

                rpt.SetDataSource(dsReporte);

                rpt.SetParameterValue("Domicilio", dlg.Domicilio.ToUpper());
                rpt.SetParameterValue("FechaCompleta",
                    DateTime.Now.ToString("dd 'de' MMMM 'del' yyyy", new CultureInfo("es-MX")));
                rpt.SetParameterValue("NombreCompletoUsuario", dlg.NombreUsuario.ToUpper());

                DlgVistaPreviaReporte dlgVistaPrevia = new DlgVistaPreviaReporte();
                dlgVistaPrevia.Reporte = rpt;
                dlgVistaPrevia.ShowDialog();

            }
        }

        private void reimpresionRecibosConveniosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.TabExists("Reimpresión Recibos (Convenios)"))
                {
                    TabPage t = new TabPage("Reimpresión Recibos (Convenios)");
                    t.BackColor = Globales.GetColor("FondoVentanaCaptura");
                    tabManager.TabPages.Add(t);
                    tabManager.SelectedTab = t;

                    FrmReimpresionReciboConvenio frm = new FrmReimpresionReciboConvenio();
                    frm.FrmPrincipal = this;
                    frm.TopLevel = false;
                    frm.Parent = t;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("permisosEmpleadoToolStripMenuItem_Click - " + ex.Message, "Formulario Frincipal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

