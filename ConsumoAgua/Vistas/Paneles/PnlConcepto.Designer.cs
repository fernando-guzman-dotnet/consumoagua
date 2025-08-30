namespace SAPA.Vistas.Paneles {
    partial class PnlConcepto {
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
            this.dgvConceptos = new System.Windows.Forms.DataGridView();
            this.btnAgregarConcepto = new System.Windows.Forms.ToolStripButton();
            this.btnEditarConcepto = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarConcepto = new System.Windows.Forms.ToolStripButton();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblDescripción = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtDescripcion = new System.Windows.Forms.ToolStripTextBox();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConceptos
            // 
            this.dgvConceptos.AllowUserToAddRows = false;
            this.dgvConceptos.AllowUserToDeleteRows = false;
            this.dgvConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConceptos.BackgroundColor = System.Drawing.Color.White;
            this.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptos.Location = new System.Drawing.Point(12, 45);
            this.dgvConceptos.MultiSelect = false;
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.ReadOnly = true;
            this.dgvConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptos.Size = new System.Drawing.Size(1380, 648);
            this.dgvConceptos.TabIndex = 4;
            // 
            // btnAgregarConcepto
            // 
            this.btnAgregarConcepto.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarConcepto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarConcepto.Name = "btnAgregarConcepto";
            this.btnAgregarConcepto.Size = new System.Drawing.Size(138, 34);
            this.btnAgregarConcepto.Text = "Agregar Concepto";
            this.btnAgregarConcepto.Click += new System.EventHandler(this.btnAgregarConcepto_Click);
            // 
            // btnEditarConcepto
            // 
            this.btnEditarConcepto.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarConcepto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarConcepto.Name = "btnEditarConcepto";
            this.btnEditarConcepto.Size = new System.Drawing.Size(126, 34);
            this.btnEditarConcepto.Text = "Editar Concepto";
            this.btnEditarConcepto.Click += new System.EventHandler(this.btnEditarConcepto_Click);
            // 
            // btnEliminarConcepto
            // 
            this.btnEliminarConcepto.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarConcepto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarConcepto.Name = "btnEliminarConcepto";
            this.btnEliminarConcepto.Size = new System.Drawing.Size(139, 34);
            this.btnEliminarConcepto.Text = "Eliminar Concepto";
            this.btnEliminarConcepto.Click += new System.EventHandler(this.btnEliminarConcepto_Click);
            // 
            // tsSeparador
            // 
            this.tsSeparador.Name = "tsSeparador";
            this.tsSeparador.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblDescripción,
            this.tsTxtDescripcion,
            this.tsSeparador,
            this.btnAgregarConcepto,
            this.btnEditarConcepto,
            this.btnEliminarConcepto,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1400, 37);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblDescripción
            // 
            this.tsLblDescripción.Name = "tsLblDescripción";
            this.tsLblDescripción.Size = new System.Drawing.Size(72, 34);
            this.tsLblDescripción.Text = "Descripción:";
            // 
            // tsTxtDescripcion
            // 
            this.tsTxtDescripcion.Name = "tsTxtDescripcion";
            this.tsTxtDescripcion.Size = new System.Drawing.Size(200, 37);
            this.tsTxtDescripcion.TextChanged += new System.EventHandler(this.tsTxtDescripcion_TextChanged);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlConcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvConceptos);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlConcepto";
            this.Text = "Panel_Conceptos";
            this.Load += new System.EventHandler(this.PnlConcepto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvConceptos;
        private System.Windows.Forms.ToolStripButton btnAgregarConcepto;
        private System.Windows.Forms.ToolStripButton btnEditarConcepto;
        private System.Windows.Forms.ToolStripButton btnEliminarConcepto;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblDescripción;
        private System.Windows.Forms.ToolStripTextBox tsTxtDescripcion;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
