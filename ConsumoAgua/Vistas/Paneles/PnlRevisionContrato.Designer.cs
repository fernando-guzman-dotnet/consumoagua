namespace SAPA.Vistas.Paneles {
    partial class PnlRevisionContrato
    {
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
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.dgvContratosRevisiones = new System.Windows.Forms.DataGridView();
            this.btnVerRevision = new System.Windows.Forms.Button();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratosRevisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1404, 33);
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
            // dgvContratosRevisiones
            // 
            this.dgvContratosRevisiones.AllowUserToAddRows = false;
            this.dgvContratosRevisiones.AllowUserToDeleteRows = false;
            this.dgvContratosRevisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvContratosRevisiones.BackgroundColor = System.Drawing.Color.White;
            this.dgvContratosRevisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratosRevisiones.Location = new System.Drawing.Point(12, 40);
            this.dgvContratosRevisiones.MultiSelect = false;
            this.dgvContratosRevisiones.Name = "dgvContratosRevisiones";
            this.dgvContratosRevisiones.ReadOnly = true;
            this.dgvContratosRevisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContratosRevisiones.Size = new System.Drawing.Size(1380, 600);
            this.dgvContratosRevisiones.TabIndex = 6;
            // 
            // btnVerRevision
            // 
            this.btnVerRevision.BackColor = System.Drawing.Color.Transparent;
            this.btnVerRevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerRevision.Image = global::SAPA.Properties.Resources.Buscar_33x33;
            this.btnVerRevision.Location = new System.Drawing.Point(1247, 646);
            this.btnVerRevision.Name = "btnVerRevision";
            this.btnVerRevision.Size = new System.Drawing.Size(145, 43);
            this.btnVerRevision.TabIndex = 15;
            this.btnVerRevision.Text = "VER REVISIÓN";
            this.btnVerRevision.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerRevision.UseVisualStyleBackColor = false;
            this.btnVerRevision.Click += new System.EventHandler(this.btnVerRevision_Click);
            // 
            // PnlRevisionContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1404, 700);
            this.Controls.Add(this.btnVerRevision);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvContratosRevisiones);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlRevisionContrato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contrato";
            this.Load += new System.EventHandler(this.PnlContrato_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratosRevisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.DataGridView dgvContratosRevisiones;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.Button btnVerRevision;
    }
}
