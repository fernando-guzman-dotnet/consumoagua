namespace SAPA.Vistas.Paneles {
    partial class PnlTarifario {
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
            this.dgvTarifas = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnEstablecerCuotaFija = new System.Windows.Forms.ToolStripButton();
            this.btnEstablecerCuotaMedida = new System.Windows.Forms.ToolStripButton();
            this.btnAgregarTarifaConcepto = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.lblAño = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifas)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTarifas
            // 
            this.dgvTarifas.AllowUserToAddRows = false;
            this.dgvTarifas.AllowUserToDeleteRows = false;
            this.dgvTarifas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTarifas.BackgroundColor = System.Drawing.Color.White;
            this.dgvTarifas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarifas.Location = new System.Drawing.Point(10, 90);
            this.dgvTarifas.MultiSelect = false;
            this.dgvTarifas.Name = "dgvTarifas";
            this.dgvTarifas.ReadOnly = true;
            this.dgvTarifas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTarifas.Size = new System.Drawing.Size(1380, 488);
            this.dgvTarifas.TabIndex = 6;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEstablecerCuotaFija,
            this.btnEstablecerCuotaMedida,
            this.btnAgregarTarifaConcepto,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1404, 37);
            this.toolStrip.TabIndex = 22;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnEstablecerCuotaFija
            // 
            this.btnEstablecerCuotaFija.Image = global::SAPA.Properties.Resources.TarifaFija;
            this.btnEstablecerCuotaFija.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEstablecerCuotaFija.Name = "btnEstablecerCuotaFija";
            this.btnEstablecerCuotaFija.Size = new System.Drawing.Size(150, 34);
            this.btnEstablecerCuotaFija.Text = "Establecer Cuota Fija";
            this.btnEstablecerCuotaFija.Click += new System.EventHandler(this.btnEstablecerCuotaFija_Click);
            // 
            // btnEstablecerCuotaMedida
            // 
            this.btnEstablecerCuotaMedida.Image = global::SAPA.Properties.Resources.TarifaMedida;
            this.btnEstablecerCuotaMedida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEstablecerCuotaMedida.Name = "btnEstablecerCuotaMedida";
            this.btnEstablecerCuotaMedida.Size = new System.Drawing.Size(172, 34);
            this.btnEstablecerCuotaMedida.Text = "Establecer Cuota Medida";
            this.btnEstablecerCuotaMedida.Click += new System.EventHandler(this.btnEstablecerCuotaMedida_Click);
            // 
            // btnAgregarTarifaConcepto
            // 
            this.btnAgregarTarifaConcepto.Image = global::SAPA.Properties.Resources.ConceptoTarifa;
            this.btnAgregarTarifaConcepto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarTarifaConcepto.Name = "btnAgregarTarifaConcepto";
            this.btnAgregarTarifaConcepto.Size = new System.Drawing.Size(178, 34);
            this.btnAgregarTarifaConcepto.Text = "Agregar Concepto a Tarifa";
            this.btnAgregarTarifaConcepto.Click += new System.EventHandler(this.btnAgregarTarifaConcepto_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.cmbAño);
            this.grpFiltros.Controls.Add(this.lblAño);
            this.grpFiltros.Location = new System.Drawing.Point(10, 40);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(365, 44);
            this.grpFiltros.TabIndex = 23;
            this.grpFiltros.TabStop = false;
            // 
            // cmbAño
            // 
            this.cmbAño.DisplayMember = "Año";
            this.cmbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Location = new System.Drawing.Point(38, 13);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(121, 21);
            this.cmbAño.TabIndex = 1;
            this.cmbAño.ValueMember = "Año";
            this.cmbAño.SelectedIndexChanged += new System.EventHandler(this.cmbAño_SelectedIndexChanged);
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Location = new System.Drawing.Point(6, 16);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(26, 13);
            this.lblAño.TabIndex = 0;
            this.lblAño.Text = "Año";
            // 
            // PnlTarifario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1404, 590);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvTarifas);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlTarifario";
            this.Text = "Tarifario";
            this.Load += new System.EventHandler(this.PnlTarifario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifas)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dgvTarifas;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAgregarTarifaConcepto;
        private System.Windows.Forms.ToolStripButton btnEstablecerCuotaFija;
        private System.Windows.Forms.ToolStripButton btnEstablecerCuotaMedida;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.Label lblAño;
    }
}
