namespace SAPA.Vistas.Paneles {
    partial class PnlMunicipio
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
            this.dgvMunicipios = new System.Windows.Forms.DataGridView();
            this.btnAgregarMunicipio = new System.Windows.Forms.ToolStripButton();
            this.btnEditarMunicipio = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarMunicipio = new System.Windows.Forms.ToolStripButton();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblNombre = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNombre = new System.Windows.Forms.ToolStripTextBox();
            this.btnAsociarLocalidad = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMunicipios)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMunicipios
            // 
            this.dgvMunicipios.AllowUserToAddRows = false;
            this.dgvMunicipios.AllowUserToDeleteRows = false;
            this.dgvMunicipios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMunicipios.BackgroundColor = System.Drawing.Color.White;
            this.dgvMunicipios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMunicipios.Location = new System.Drawing.Point(12, 40);
            this.dgvMunicipios.MultiSelect = false;
            this.dgvMunicipios.Name = "dgvMunicipios";
            this.dgvMunicipios.ReadOnly = true;
            this.dgvMunicipios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMunicipios.Size = new System.Drawing.Size(1380, 653);
            this.dgvMunicipios.TabIndex = 4;
            // 
            // btnAgregarMunicipio
            // 
            this.btnAgregarMunicipio.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarMunicipio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarMunicipio.Name = "btnAgregarMunicipio";
            this.btnAgregarMunicipio.Size = new System.Drawing.Size(140, 34);
            this.btnAgregarMunicipio.Text = "Agregar Municipio";
            this.btnAgregarMunicipio.Click += new System.EventHandler(this.btnAgregarMunicipio_Click);
            // 
            // btnEditarMunicipio
            // 
            this.btnEditarMunicipio.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarMunicipio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarMunicipio.Name = "btnEditarMunicipio";
            this.btnEditarMunicipio.Size = new System.Drawing.Size(128, 34);
            this.btnEditarMunicipio.Text = "Editar Municipio";
            this.btnEditarMunicipio.Click += new System.EventHandler(this.btnEditarMunicipio_Click);
            // 
            // btnEliminarMunicipio
            // 
            this.btnEliminarMunicipio.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarMunicipio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarMunicipio.Name = "btnEliminarMunicipio";
            this.btnEliminarMunicipio.Size = new System.Drawing.Size(141, 34);
            this.btnEliminarMunicipio.Text = "Eliminar Municipio";
            this.btnEliminarMunicipio.Visible = false;
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
            this.btnAgregarMunicipio,
            this.btnEditarMunicipio,
            this.btnEliminarMunicipio,
            this.btnAsociarLocalidad,
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
            this.tsTxtNombre.TextChanged += new System.EventHandler(this.tsTxtNombre_TextChanged);
            // 
            // btnAsociarLocalidad
            // 
            this.btnAsociarLocalidad.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAsociarLocalidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAsociarLocalidad.Name = "btnAsociarLocalidad";
            this.btnAsociarLocalidad.Size = new System.Drawing.Size(134, 34);
            this.btnAsociarLocalidad.Text = "Asociar Localidad";
            this.btnAsociarLocalidad.Click += new System.EventHandler(this.btnAsociarLocalidad_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlMunicipio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvMunicipios);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlMunicipio";
            this.Text = "Catálogo Bancos";
            this.Load += new System.EventHandler(this.PnlMunicipios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMunicipios)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMunicipios;
        private System.Windows.Forms.ToolStripButton btnAgregarMunicipio;
        private System.Windows.Forms.ToolStripButton btnEditarMunicipio;
        private System.Windows.Forms.ToolStripButton btnEliminarMunicipio;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblNombre;
        private System.Windows.Forms.ToolStripTextBox tsTxtNombre;
        private System.Windows.Forms.ToolStripButton btnAsociarLocalidad;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
