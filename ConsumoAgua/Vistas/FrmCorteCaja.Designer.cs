namespace SAPA.Vistas
{
    partial class FrmCorteCaja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.crvCorteCaja = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.toolStrip.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1136, 33);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 7;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.lblFechaDesde);
            this.grpFiltros.Controls.Add(this.dtpFechaInicio);
            this.grpFiltros.Controls.Add(this.lblFechaHasta);
            this.grpFiltros.Controls.Add(this.dtpFechaFin);
            this.grpFiltros.Controls.Add(this.btnGenerar);
            this.grpFiltros.Location = new System.Drawing.Point(8, 36);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1112, 55);
            this.grpFiltros.TabIndex = 9;
            this.grpFiltros.TabStop = false;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Location = new System.Drawing.Point(6, 25);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(38, 13);
            this.lblFechaDesde.TabIndex = 1;
            this.lblFechaDesde.Text = "Desde";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(50, 21);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaInicio.TabIndex = 0;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Location = new System.Drawing.Point(151, 25);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(35, 13);
            this.lblFechaHasta.TabIndex = 8;
            this.lblFechaHasta.Text = "Hasta";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(192, 21);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaFin.TabIndex = 6;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(997, 14);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(109, 35);
            this.btnGenerar.TabIndex = 28;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // crvCorteCaja
            // 
            this.crvCorteCaja.ActiveViewIndex = -1;
            this.crvCorteCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCorteCaja.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCorteCaja.EnableDrillDown = false;
            this.crvCorteCaja.Location = new System.Drawing.Point(8, 97);
            this.crvCorteCaja.Name = "crvCorteCaja";
            this.crvCorteCaja.ShowCloseButton = false;
            this.crvCorteCaja.ShowCopyButton = false;
            this.crvCorteCaja.ShowGroupTreeButton = false;
            this.crvCorteCaja.ShowLogo = false;
            this.crvCorteCaja.ShowParameterPanelButton = false;
            this.crvCorteCaja.ShowRefreshButton = false;
            this.crvCorteCaja.Size = new System.Drawing.Size(1112, 495);
            this.crvCorteCaja.TabIndex = 10;
            this.crvCorteCaja.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmCorteCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1136, 604);
            this.Controls.Add(this.crvCorteCaja);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.toolStrip);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCorteCaja";
            this.Text = "FrmCorteCaja";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCorteCaja;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnGenerar;
    }
}
