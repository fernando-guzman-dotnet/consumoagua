namespace SAPA.Vistas.Paneles {
    partial class PnlLocalidad {
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
            this.dgvLocalidades = new System.Windows.Forms.DataGridView();
            this.btnAgregarLocalidad = new System.Windows.Forms.ToolStripButton();
            this.btnEditarLocalidad = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarLocalidad = new System.Windows.Forms.ToolStripButton();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblNombre = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNombre = new System.Windows.Forms.ToolStripTextBox();
            this.btnAsociarColonia = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalidades)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLocalidades
            // 
            this.dgvLocalidades.AllowUserToAddRows = false;
            this.dgvLocalidades.AllowUserToDeleteRows = false;
            this.dgvLocalidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalidades.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalidades.Location = new System.Drawing.Point(12, 45);
            this.dgvLocalidades.MultiSelect = false;
            this.dgvLocalidades.Name = "dgvLocalidades";
            this.dgvLocalidades.ReadOnly = true;
            this.dgvLocalidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalidades.Size = new System.Drawing.Size(1380, 648);
            this.dgvLocalidades.TabIndex = 4;
            // 
            // btnAgregarLocalidad
            // 
            this.btnAgregarLocalidad.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarLocalidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarLocalidad.Name = "btnAgregarLocalidad";
            this.btnAgregarLocalidad.Size = new System.Drawing.Size(137, 34);
            this.btnAgregarLocalidad.Text = "Agregar Localidad";
            this.btnAgregarLocalidad.Click += new System.EventHandler(this.btnAgregarLocalidad_Click);
            // 
            // btnEditarLocalidad
            // 
            this.btnEditarLocalidad.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarLocalidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarLocalidad.Name = "btnEditarLocalidad";
            this.btnEditarLocalidad.Size = new System.Drawing.Size(125, 34);
            this.btnEditarLocalidad.Text = "Editar Localidad";
            this.btnEditarLocalidad.Click += new System.EventHandler(this.btnEditarLocalidad_Click);
            // 
            // btnEliminarLocalidad
            // 
            this.btnEliminarLocalidad.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarLocalidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarLocalidad.Name = "btnEliminarLocalidad";
            this.btnEliminarLocalidad.Size = new System.Drawing.Size(138, 34);
            this.btnEliminarLocalidad.Text = "Eliminar Localidad";
            this.btnEliminarLocalidad.Visible = false;
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
            this.btnAgregarLocalidad,
            this.btnEditarLocalidad,
            this.btnEliminarLocalidad,
            this.btnAsociarColonia,
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
            // btnAsociarColonia
            // 
            this.btnAsociarColonia.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAsociarColonia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAsociarColonia.Name = "btnAsociarColonia";
            this.btnAsociarColonia.Size = new System.Drawing.Size(124, 34);
            this.btnAsociarColonia.Text = "Asociar Colonia";
            this.btnAsociarColonia.Click += new System.EventHandler(this.btnAsociarColonia_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlLocalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvLocalidades);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlLocalidad";
            this.Text = "Catálogo Bancos";
            this.Load += new System.EventHandler(this.PnlBanco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalidades)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvLocalidades;
        private System.Windows.Forms.ToolStripButton btnAgregarLocalidad;
        private System.Windows.Forms.ToolStripButton btnEditarLocalidad;
        private System.Windows.Forms.ToolStripButton btnEliminarLocalidad;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblNombre;
        private System.Windows.Forms.ToolStripTextBox tsTxtNombre;
        private System.Windows.Forms.ToolStripButton btnAsociarColonia;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
