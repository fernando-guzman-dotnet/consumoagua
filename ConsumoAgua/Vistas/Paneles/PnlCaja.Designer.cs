namespace SAPA.Vistas.Paneles {
    partial class PnlCaja
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
            this.dgvCajas = new System.Windows.Forms.DataGridView();
            this.btnAgregarCaja = new System.Windows.Forms.ToolStripButton();
            this.btnEditarCaja = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarCaja = new System.Windows.Forms.ToolStripButton();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblDescripcion = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNombre = new System.Windows.Forms.ToolStripTextBox();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBancos
            // 
            this.dgvCajas.AllowUserToAddRows = false;
            this.dgvCajas.AllowUserToDeleteRows = false;
            this.dgvCajas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCajas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajas.Location = new System.Drawing.Point(12, 45);
            this.dgvCajas.MultiSelect = false;
            this.dgvCajas.Name = "dgvCajas";
            this.dgvCajas.ReadOnly = true;
            this.dgvCajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCajas.Size = new System.Drawing.Size(1380, 648);
            this.dgvCajas.TabIndex = 4;
            // 
            // btnAgregarCaja
            // 
            this.btnAgregarCaja.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarCaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarCaja.Name = "btnAgregarCaja";
            this.btnAgregarCaja.Size = new System.Drawing.Size(109, 34);
            this.btnAgregarCaja.Text = "Agregar Caja";
            this.btnAgregarCaja.Click += new System.EventHandler(this.btnAgregarCaja_Click);
            // 
            // btnEditarCaja
            // 
            this.btnEditarCaja.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarCaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarCaja.Name = "btnEditarCaja";
            this.btnEditarCaja.Size = new System.Drawing.Size(97, 34);
            this.btnEditarCaja.Text = "Editar Caja";
            this.btnEditarCaja.Click += new System.EventHandler(this.btnEditarCaja_Click);
            // 
            // btnEliminarCaja
            // 
            this.btnEliminarCaja.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarCaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarCaja.Name = "btnEliminarCaja";
            this.btnEliminarCaja.Size = new System.Drawing.Size(110, 34);
            this.btnEliminarCaja.Text = "Eliminar Caja";
            this.btnEliminarCaja.Click += new System.EventHandler(this.btnEliminarCaja_Click);
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
            this.tsLblDescripcion,
            this.tsTxtNombre,
            this.tsSeparador,
            this.btnAgregarCaja,
            this.btnEditarCaja,
            this.btnEliminarCaja,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1400, 37);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblDescripcion
            // 
            this.tsLblDescripcion.Name = "tsLblDescripcion";
            this.tsLblDescripcion.Size = new System.Drawing.Size(72, 34);
            this.tsLblDescripcion.Text = "Descripción:";
            // 
            // tsTxtNombre
            // 
            this.tsTxtNombre.Name = "tsTxtNombre";
            this.tsTxtNombre.Size = new System.Drawing.Size(200, 37);
            this.tsTxtNombre.TextChanged += new System.EventHandler(this.tsTxtDescripcion_TextChanged);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvCajas);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlCaja";
            this.Text = "Catálogo Bancos";
            this.Load += new System.EventHandler(this.PnlCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCajas;
        private System.Windows.Forms.ToolStripButton btnAgregarCaja;
        private System.Windows.Forms.ToolStripButton btnEditarCaja;
        private System.Windows.Forms.ToolStripButton btnEliminarCaja;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblDescripcion;
        private System.Windows.Forms.ToolStripTextBox tsTxtNombre;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
