namespace SAPA.Vistas.Paneles {
    partial class PnlTipoVivienda {
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
            this.tsLblDescripcion = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtDescripcion = new System.Windows.Forms.ToolStripTextBox();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregarTipoVivienda = new System.Windows.Forms.ToolStripButton();
            this.btnEditarTipoVivienda = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarTipoVivienda = new System.Windows.Forms.ToolStripButton();
            this.dgvTipoViviendas = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoViviendas)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblDescripcion,
            this.tsTxtDescripcion,
            this.tsSeparador,
            this.btnAgregarTipoVivienda,
            this.btnEditarTipoVivienda,
            this.btnEliminarTipoVivienda,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1404, 37);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblDescripcion
            // 
            this.tsLblDescripcion.Name = "tsLblDescripcion";
            this.tsLblDescripcion.Size = new System.Drawing.Size(72, 34);
            this.tsLblDescripcion.Text = "Descripción:";
            // 
            // tsTxtDescripcion
            // 
            this.tsTxtDescripcion.Name = "tsTxtDescripcion";
            this.tsTxtDescripcion.Size = new System.Drawing.Size(200, 37);
            this.tsTxtDescripcion.TextChanged += new System.EventHandler(this.tsTxtDescripcion_TextChanged);
            // 
            // tsSeparador
            // 
            this.tsSeparador.Name = "tsSeparador";
            this.tsSeparador.Size = new System.Drawing.Size(6, 37);
            // 
            // btnAgregarTipoVivienda
            // 
            this.btnAgregarTipoVivienda.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarTipoVivienda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarTipoVivienda.Name = "btnAgregarTipoVivienda";
            this.btnAgregarTipoVivienda.Size = new System.Drawing.Size(157, 34);
            this.btnAgregarTipoVivienda.Text = "Agregar Tipo Vivienda";
            this.btnAgregarTipoVivienda.Click += new System.EventHandler(this.btnAgregarTipoVivienda_Click);
            // 
            // btnEditarTipoVivienda
            // 
            this.btnEditarTipoVivienda.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarTipoVivienda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarTipoVivienda.Name = "btnEditarTipoVivienda";
            this.btnEditarTipoVivienda.Size = new System.Drawing.Size(145, 34);
            this.btnEditarTipoVivienda.Text = "Editar Tipo Vivienda";
            this.btnEditarTipoVivienda.Click += new System.EventHandler(this.btnEditarTipoVivienda_Click);
            // 
            // btnEliminarTipoVivienda
            // 
            this.btnEliminarTipoVivienda.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarTipoVivienda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarTipoVivienda.Name = "btnEliminarTipoVivienda";
            this.btnEliminarTipoVivienda.Size = new System.Drawing.Size(174, 34);
            this.btnEliminarTipoVivienda.Text = "Eliminar Tipo de Vivienda";
            this.btnEliminarTipoVivienda.Click += new System.EventHandler(this.btnEliminarTipoVivienda_Click);
            // 
            // dgvTipoViviendas
            // 
            this.dgvTipoViviendas.AllowUserToAddRows = false;
            this.dgvTipoViviendas.AllowUserToDeleteRows = false;
            this.dgvTipoViviendas.BackgroundColor = System.Drawing.Color.White;
            this.dgvTipoViviendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoViviendas.Location = new System.Drawing.Point(12, 40);
            this.dgvTipoViviendas.MultiSelect = false;
            this.dgvTipoViviendas.Name = "dgvTipoViviendas";
            this.dgvTipoViviendas.ReadOnly = true;
            this.dgvTipoViviendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTipoViviendas.Size = new System.Drawing.Size(1378, 648);
            this.dgvTipoViviendas.TabIndex = 2;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlTipoVivienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1404, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvTipoViviendas);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlTipoVivienda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel_TipoVivienda";
            this.Load += new System.EventHandler(this.PnlTipoVivienda_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoViviendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAgregarTipoVivienda;
        private System.Windows.Forms.ToolStripButton btnEditarTipoVivienda;
        private System.Windows.Forms.ToolStripButton btnEliminarTipoVivienda;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.DataGridView dgvTipoViviendas;
        private System.Windows.Forms.ToolStripLabel tsLblDescripcion;
        private System.Windows.Forms.ToolStripTextBox tsTxtDescripcion;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
