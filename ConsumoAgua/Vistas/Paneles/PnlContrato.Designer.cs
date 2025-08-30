namespace SAPA.Vistas.Paneles {
    partial class PnlContrato {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblUsuario = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtUsuario = new System.Windows.Forms.ToolStripTextBox();
            this.tsLblDireccion = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtDireccion = new System.Windows.Forms.ToolStripTextBox();
            this.tsLblNoContrato = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNoContrato = new System.Windows.Forms.ToolStripTextBox();
            this.tsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregarContrato = new System.Windows.Forms.ToolStripButton();
            this.btnEditarContrato = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.dgvContratos = new System.Windows.Forms.DataGridView();
            this.cmsOpcionesContrato = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmVerOrdenesTrabajo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAplicarDescuento = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
            this.cmsOpcionesContrato.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblUsuario,
            this.tsTxtUsuario,
            this.tsLblDireccion,
            this.tsTxtDireccion,
            this.tsLblNoContrato,
            this.tsTxtNoContrato,
            this.tsSeparator,
            this.btnAgregarContrato,
            this.btnEditarContrato,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1404, 37);
            this.toolStrip.TabIndex = 7;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblUsuario
            // 
            this.tsLblUsuario.Name = "tsLblUsuario";
            this.tsLblUsuario.Size = new System.Drawing.Size(47, 34);
            this.tsLblUsuario.Text = "Usuario";
            // 
            // tsTxtUsuario
            // 
            this.tsTxtUsuario.Name = "tsTxtUsuario";
            this.tsTxtUsuario.Size = new System.Drawing.Size(150, 37);
            this.tsTxtUsuario.TextChanged += new System.EventHandler(this.tsTxtUsuario_TextChanged);
            // 
            // tsLblDireccion
            // 
            this.tsLblDireccion.Name = "tsLblDireccion";
            this.tsLblDireccion.Size = new System.Drawing.Size(57, 34);
            this.tsLblDireccion.Text = "Direccion";
            // 
            // tsTxtDireccion
            // 
            this.tsTxtDireccion.Name = "tsTxtDireccion";
            this.tsTxtDireccion.Size = new System.Drawing.Size(150, 37);
            this.tsTxtDireccion.TextChanged += new System.EventHandler(this.tsTxtDireccion_TextChanged);
            // 
            // tsLblNoContrato
            // 
            this.tsLblNoContrato.Name = "tsLblNoContrato";
            this.tsLblNoContrato.Size = new System.Drawing.Size(76, 34);
            this.tsLblNoContrato.Text = "No. Contrato";
            // 
            // tsTxtNoContrato
            // 
            this.tsTxtNoContrato.Name = "tsTxtNoContrato";
            this.tsTxtNoContrato.Size = new System.Drawing.Size(150, 37);
            this.tsTxtNoContrato.TextChanged += new System.EventHandler(this.tsTxtNoContrato_TextChanged);
            // 
            // tsSeparator
            // 
            this.tsSeparator.Name = "tsSeparator";
            this.tsSeparator.Size = new System.Drawing.Size(6, 37);
            // 
            // btnAgregarContrato
            // 
            this.btnAgregarContrato.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarContrato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarContrato.Name = "btnAgregarContrato";
            this.btnAgregarContrato.Size = new System.Drawing.Size(133, 34);
            this.btnAgregarContrato.Text = "Agregar Contrato";
            this.btnAgregarContrato.Click += new System.EventHandler(this.btnAgregarContrato_Click);
            // 
            // btnEditarContrato
            // 
            this.btnEditarContrato.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarContrato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarContrato.Name = "btnEditarContrato";
            this.btnEditarContrato.Size = new System.Drawing.Size(121, 34);
            this.btnEditarContrato.Text = "Editar Contrato";
            this.btnEditarContrato.Click += new System.EventHandler(this.btnEditarContrato_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvContratos
            // 
            this.dgvContratos.AllowUserToAddRows = false;
            this.dgvContratos.AllowUserToDeleteRows = false;
            this.dgvContratos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvContratos.BackgroundColor = System.Drawing.Color.White;
            this.dgvContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratos.ContextMenuStrip = this.cmsOpcionesContrato;
            this.dgvContratos.Location = new System.Drawing.Point(12, 40);
            this.dgvContratos.MultiSelect = false;
            this.dgvContratos.Name = "dgvContratos";
            this.dgvContratos.ReadOnly = true;
            this.dgvContratos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContratos.Size = new System.Drawing.Size(1380, 600);
            this.dgvContratos.TabIndex = 6;
            this.dgvContratos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContratos_CellDoubleClick);
            // 
            // cmsOpcionesContrato
            // 
            this.cmsOpcionesContrato.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVerOrdenesTrabajo,
            this.tsmAplicarDescuento});
            this.cmsOpcionesContrato.Name = "cmsOpcionesContrato";
            this.cmsOpcionesContrato.Size = new System.Drawing.Size(195, 48);
            // 
            // tsmVerOrdenesTrabajo
            // 
            this.tsmVerOrdenesTrabajo.Name = "tsmVerOrdenesTrabajo";
            this.tsmVerOrdenesTrabajo.Size = new System.Drawing.Size(194, 22);
            this.tsmVerOrdenesTrabajo.Text = "Ver Ordenes de Trabajo";
            this.tsmVerOrdenesTrabajo.Click += new System.EventHandler(this.tsmVerOrdenesTrabajo_Click);
            // 
            // tsmAplicarDescuento
            // 
            this.tsmAplicarDescuento.Name = "tsmAplicarDescuento";
            this.tsmAplicarDescuento.Size = new System.Drawing.Size(194, 22);
            this.tsmAplicarDescuento.Text = "Aplicar Descuento";
            this.tsmAplicarDescuento.Click += new System.EventHandler(this.tsmAplicarDescuento_Click);
            // 
            // PnlContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1404, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvContratos);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlContrato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contrato";
            this.Load += new System.EventHandler(this.PnlContrato_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
            this.cmsOpcionesContrato.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAgregarContrato;
        private System.Windows.Forms.ToolStripButton btnEditarContrato;
        private System.Windows.Forms.ToolStripSeparator tsSeparator;
        private System.Windows.Forms.DataGridView dgvContratos;
        private System.Windows.Forms.ToolStripLabel tsLblUsuario;
        private System.Windows.Forms.ToolStripTextBox tsTxtUsuario;
        private System.Windows.Forms.ToolStripLabel tsLblDireccion;
        private System.Windows.Forms.ToolStripTextBox tsTxtDireccion;
        private System.Windows.Forms.ToolStripLabel tsLblNoContrato;
        private System.Windows.Forms.ToolStripTextBox tsTxtNoContrato;
        private System.Windows.Forms.ContextMenuStrip cmsOpcionesContrato;
        private System.Windows.Forms.ToolStripMenuItem tsmVerOrdenesTrabajo;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.ToolStripMenuItem tsmAplicarDescuento;
    }
}
