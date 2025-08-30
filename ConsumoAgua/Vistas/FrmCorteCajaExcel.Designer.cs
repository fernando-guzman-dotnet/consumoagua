namespace SAPA.Vistas
{
    partial class FrmCorteCajaExcel
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
            this.cmbCajas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvCorteCaja = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblTotalCorteCaja = new System.Windows.Forms.Label();
            this.lblTotalArqueo = new System.Windows.Forms.Label();
            this.lblTotalDiferencia = new System.Windows.Forms.Label();
            this.txtTotalCorteCaja = new System.Windows.Forms.TextBox();
            this.txtTotalArqueo = new System.Windows.Forms.TextBox();
            this.txtDiferencia = new System.Windows.Forms.TextBox();
            this.grpTotales = new System.Windows.Forms.GroupBox();
            this.toolStrip.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorteCaja)).BeginInit();
            this.grpTotales.SuspendLayout();
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
            this.grpFiltros.Controls.Add(this.cmbCajas);
            this.grpFiltros.Controls.Add(this.label1);
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
            // cmbCajas
            // 
            this.cmbCajas.FormattingEnabled = true;
            this.cmbCajas.Location = new System.Drawing.Point(344, 21);
            this.cmbCajas.Name = "cmbCajas";
            this.cmbCajas.Size = new System.Drawing.Size(173, 21);
            this.cmbCajas.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Caja";
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
            // dgvCorteCaja
            // 
            this.dgvCorteCaja.AllowUserToAddRows = false;
            this.dgvCorteCaja.AllowUserToDeleteRows = false;
            this.dgvCorteCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorteCaja.Location = new System.Drawing.Point(8, 109);
            this.dgvCorteCaja.Name = "dgvCorteCaja";
            this.dgvCorteCaja.ReadOnly = true;
            this.dgvCorteCaja.Size = new System.Drawing.Size(1112, 377);
            this.dgvCorteCaja.TabIndex = 10;
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(1011, 491);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(109, 35);
            this.btnExportar.TabIndex = 29;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblTotalCorteCaja
            // 
            this.lblTotalCorteCaja.AutoSize = true;
            this.lblTotalCorteCaja.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCorteCaja.Location = new System.Drawing.Point(6, 16);
            this.lblTotalCorteCaja.Name = "lblTotalCorteCaja";
            this.lblTotalCorteCaja.Size = new System.Drawing.Size(154, 17);
            this.lblTotalCorteCaja.TabIndex = 30;
            this.lblTotalCorteCaja.Text = "TOTAL CORTE DE CAJA:";
            // 
            // lblTotalArqueo
            // 
            this.lblTotalArqueo.AutoSize = true;
            this.lblTotalArqueo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArqueo.Location = new System.Drawing.Point(51, 42);
            this.lblTotalArqueo.Name = "lblTotalArqueo";
            this.lblTotalArqueo.Size = new System.Drawing.Size(109, 17);
            this.lblTotalArqueo.TabIndex = 30;
            this.lblTotalArqueo.Text = "TOTAL ARQUEO:";
            // 
            // lblTotalDiferencia
            // 
            this.lblTotalDiferencia.AutoSize = true;
            this.lblTotalDiferencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiferencia.Location = new System.Drawing.Point(74, 68);
            this.lblTotalDiferencia.Name = "lblTotalDiferencia";
            this.lblTotalDiferencia.Size = new System.Drawing.Size(86, 17);
            this.lblTotalDiferencia.TabIndex = 30;
            this.lblTotalDiferencia.Text = "DIFERENCIA:";
            // 
            // txtTotalCorteCaja
            // 
            this.txtTotalCorteCaja.Location = new System.Drawing.Point(166, 14);
            this.txtTotalCorteCaja.Name = "txtTotalCorteCaja";
            this.txtTotalCorteCaja.ReadOnly = true;
            this.txtTotalCorteCaja.Size = new System.Drawing.Size(158, 20);
            this.txtTotalCorteCaja.TabIndex = 31;
            this.txtTotalCorteCaja.TabStop = false;
            this.txtTotalCorteCaja.Text = "0.00";
            this.txtTotalCorteCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalArqueo
            // 
            this.txtTotalArqueo.Location = new System.Drawing.Point(166, 41);
            this.txtTotalArqueo.Name = "txtTotalArqueo";
            this.txtTotalArqueo.ReadOnly = true;
            this.txtTotalArqueo.Size = new System.Drawing.Size(158, 20);
            this.txtTotalArqueo.TabIndex = 32;
            this.txtTotalArqueo.TabStop = false;
            this.txtTotalArqueo.Text = "0.00";
            this.txtTotalArqueo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.Location = new System.Drawing.Point(166, 66);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.ReadOnly = true;
            this.txtDiferencia.Size = new System.Drawing.Size(158, 20);
            this.txtDiferencia.TabIndex = 33;
            this.txtDiferencia.TabStop = false;
            this.txtDiferencia.Text = "0.00";
            this.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpTotales
            // 
            this.grpTotales.Controls.Add(this.txtDiferencia);
            this.grpTotales.Controls.Add(this.lblTotalCorteCaja);
            this.grpTotales.Controls.Add(this.txtTotalArqueo);
            this.grpTotales.Controls.Add(this.lblTotalArqueo);
            this.grpTotales.Controls.Add(this.txtTotalCorteCaja);
            this.grpTotales.Controls.Add(this.lblTotalDiferencia);
            this.grpTotales.Location = new System.Drawing.Point(8, 492);
            this.grpTotales.Name = "grpTotales";
            this.grpTotales.Size = new System.Drawing.Size(337, 100);
            this.grpTotales.TabIndex = 34;
            this.grpTotales.TabStop = false;
            // 
            // FrmCorteCajaExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1136, 604);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvCorteCaja);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.grpTotales);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCorteCajaExcel";
            this.Text = "FrmCorteCaja";
            this.Load += new System.EventHandler(this.FrmCorteCajaExcel_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorteCaja)).EndInit();
            this.grpTotales.ResumeLayout(false);
            this.grpTotales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvCorteCaja;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ComboBox cmbCajas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalCorteCaja;
        private System.Windows.Forms.Label lblTotalArqueo;
        private System.Windows.Forms.Label lblTotalDiferencia;
        private System.Windows.Forms.TextBox txtTotalCorteCaja;
        private System.Windows.Forms.TextBox txtTotalArqueo;
        private System.Windows.Forms.TextBox txtDiferencia;
        private System.Windows.Forms.GroupBox grpTotales;
    }
}
