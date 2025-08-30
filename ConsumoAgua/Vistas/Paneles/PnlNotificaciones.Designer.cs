namespace SAPA.Vistas.Paneles {
    partial class PnlNotificaciones {
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblNoContrato = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNoContrato = new System.Windows.Forms.ToolStripTextBox();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.tsLblDireccion = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtDireccion = new System.Windows.Forms.ToolStripTextBox();
            this.tsLblMesesAdeudo = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtMesesAdeudo = new System.Windows.Forms.ToolStripTextBox();
            this.tsLblMonto = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtMonto = new System.Windows.Forms.ToolStripTextBox();
            this.dgvNotificaciones = new System.Windows.Forms.DataGridView();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotificaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblNoContrato,
            this.tsTxtNoContrato,
            this.btnCerrar,
            this.tsLblDireccion,
            this.tsTxtDireccion,
            this.tsLblMesesAdeudo,
            this.tsTxtMesesAdeudo,
            this.tsLblMonto,
            this.tsTxtMonto});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1404, 33);
            this.toolStrip.TabIndex = 11;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblNoContrato
            // 
            this.tsLblNoContrato.Name = "tsLblNoContrato";
            this.tsLblNoContrato.Size = new System.Drawing.Size(76, 30);
            this.tsLblNoContrato.Text = "No. Contrato";
            // 
            // tsTxtNoContrato
            // 
            this.tsTxtNoContrato.Name = "tsTxtNoContrato";
            this.tsTxtNoContrato.Size = new System.Drawing.Size(100, 33);
            this.tsTxtNoContrato.TextChanged += new System.EventHandler(this.genericEvent_TextChanged);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tsLblDireccion
            // 
            this.tsLblDireccion.Name = "tsLblDireccion";
            this.tsLblDireccion.Size = new System.Drawing.Size(57, 30);
            this.tsLblDireccion.Text = "Dirección";
            // 
            // tsTxtDireccion
            // 
            this.tsTxtDireccion.Name = "tsTxtDireccion";
            this.tsTxtDireccion.Size = new System.Drawing.Size(150, 33);
            this.tsTxtDireccion.TextChanged += new System.EventHandler(this.genericEvent_TextChanged);
            // 
            // tsLblMesesAdeudo
            // 
            this.tsLblMesesAdeudo.Name = "tsLblMesesAdeudo";
            this.tsLblMesesAdeudo.Size = new System.Drawing.Size(40, 30);
            this.tsLblMesesAdeudo.Text = "Meses";
            // 
            // tsTxtMesesAdeudo
            // 
            this.tsTxtMesesAdeudo.Name = "tsTxtMesesAdeudo";
            this.tsTxtMesesAdeudo.Size = new System.Drawing.Size(60, 33);
            this.tsTxtMesesAdeudo.TextChanged += new System.EventHandler(this.genericEvent_TextChanged);
            // 
            // tsLblMonto
            // 
            this.tsLblMonto.Name = "tsLblMonto";
            this.tsLblMonto.Size = new System.Drawing.Size(43, 30);
            this.tsLblMonto.Text = "Monto";
            // 
            // tsTxtMonto
            // 
            this.tsTxtMonto.Name = "tsTxtMonto";
            this.tsTxtMonto.Size = new System.Drawing.Size(80, 33);
            this.tsTxtMonto.TextChanged += new System.EventHandler(this.genericEvent_TextChanged);
            // 
            // dgvNotificaciones
            // 
            this.dgvNotificaciones.AllowUserToAddRows = false;
            this.dgvNotificaciones.AllowUserToDeleteRows = false;
            this.dgvNotificaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotificaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNotificaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvNotificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotificaciones.Location = new System.Drawing.Point(12, 40);
            this.dgvNotificaciones.MultiSelect = false;
            this.dgvNotificaciones.Name = "dgvNotificaciones";
            this.dgvNotificaciones.ReadOnly = true;
            this.dgvNotificaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotificaciones.Size = new System.Drawing.Size(1380, 548);
            this.dgvNotificaciones.TabIndex = 12;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(1283, 594);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(109, 35);
            this.btnGenerar.TabIndex = 31;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // PnlNotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1404, 700);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvNotificaciones);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlNotificaciones";
            this.Text = "Panel_Quejas";
            this.Load += new System.EventHandler(this.PnlNotificaciones_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotificaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.DataGridView dgvNotificaciones;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.ToolStripLabel tsLblNoContrato;
        private System.Windows.Forms.ToolStripTextBox tsTxtNoContrato;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.ToolStripLabel tsLblDireccion;
        private System.Windows.Forms.ToolStripTextBox tsTxtDireccion;
        private System.Windows.Forms.ToolStripLabel tsLblMesesAdeudo;
        private System.Windows.Forms.ToolStripTextBox tsTxtMesesAdeudo;
        private System.Windows.Forms.ToolStripLabel tsLblMonto;
        private System.Windows.Forms.ToolStripTextBox tsTxtMonto;
    }
}
