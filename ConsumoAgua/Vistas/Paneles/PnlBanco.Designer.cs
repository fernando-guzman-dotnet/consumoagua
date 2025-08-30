namespace SAPA.Vistas.Paneles {
    partial class PnlBanco {
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
            this.dgvBancos = new System.Windows.Forms.DataGridView();
            this.btnAgregarBanco = new System.Windows.Forms.ToolStripButton();
            this.btnEditarBanco = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarBanco = new System.Windows.Forms.ToolStripButton();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblNombre = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNombre = new System.Windows.Forms.ToolStripTextBox();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBancos)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBancos
            // 
            this.dgvBancos.AllowUserToAddRows = false;
            this.dgvBancos.AllowUserToDeleteRows = false;
            this.dgvBancos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBancos.BackgroundColor = System.Drawing.Color.White;
            this.dgvBancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBancos.Location = new System.Drawing.Point(12, 45);
            this.dgvBancos.MultiSelect = false;
            this.dgvBancos.Name = "dgvBancos";
            this.dgvBancos.ReadOnly = true;
            this.dgvBancos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBancos.Size = new System.Drawing.Size(1380, 648);
            this.dgvBancos.TabIndex = 4;
            // 
            // btnAgregarBanco
            // 
            this.btnAgregarBanco.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarBanco.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarBanco.Name = "btnAgregarBanco";
            this.btnAgregarBanco.Size = new System.Drawing.Size(119, 34);
            this.btnAgregarBanco.Text = "Agregar Banco";
            this.btnAgregarBanco.Click += new System.EventHandler(this.btnAgregarBanco_Click);
            // 
            // btnEditarBanco
            // 
            this.btnEditarBanco.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarBanco.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarBanco.Name = "btnEditarBanco";
            this.btnEditarBanco.Size = new System.Drawing.Size(107, 34);
            this.btnEditarBanco.Text = "Editar Banco";
            this.btnEditarBanco.Click += new System.EventHandler(this.btnEditarBanco_Click);
            // 
            // btnEliminarBanco
            // 
            this.btnEliminarBanco.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarBanco.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarBanco.Name = "btnEliminarBanco";
            this.btnEliminarBanco.Size = new System.Drawing.Size(120, 34);
            this.btnEliminarBanco.Text = "Eliminar Banco";
            this.btnEliminarBanco.Click += new System.EventHandler(this.btnEliminarBanco_Click);
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
            this.tsLblNombre,
            this.tsTxtNombre,
            this.tsSeparador,
            this.btnAgregarBanco,
            this.btnEditarBanco,
            this.btnEliminarBanco,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1400, 37);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblNombre
            // 
            this.tsLblNombre.Name = "tsLblNombre";
            this.tsLblNombre.Size = new System.Drawing.Size(54, 34);
            this.tsLblNombre.Text = "Nombre:";
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
            // PnlBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvBancos);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlBanco";
            this.Text = "Catálogo Bancos";
            this.Load += new System.EventHandler(this.PnlBanco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBancos)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvBancos;
        private System.Windows.Forms.ToolStripButton btnAgregarBanco;
        private System.Windows.Forms.ToolStripButton btnEditarBanco;
        private System.Windows.Forms.ToolStripButton btnEliminarBanco;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblNombre;
        private System.Windows.Forms.ToolStripTextBox tsTxtNombre;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
