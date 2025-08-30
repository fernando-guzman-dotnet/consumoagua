namespace SAPA.Vistas.Paneles {
    partial class PnlSeccion {
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
            this.btnAgregarSeccion = new System.Windows.Forms.ToolStripButton();
            this.btnEditarSeccion = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarSeccion = new System.Windows.Forms.ToolStripButton();
            this.dgvSecciones = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecciones)).BeginInit();
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
            this.btnAgregarSeccion,
            this.btnEditarSeccion,
            this.btnEliminarSeccion,
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
            this.tsLblDescripcion.Text = "Descripcion:";
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
            // btnAgregarSeccion
            // 
            this.btnAgregarSeccion.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarSeccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarSeccion.Name = "btnAgregarSeccion";
            this.btnAgregarSeccion.Size = new System.Drawing.Size(127, 34);
            this.btnAgregarSeccion.Text = "Agregar Seccion";
            this.btnAgregarSeccion.Click += new System.EventHandler(this.btnAgregarSeccion_Click);
            // 
            // btnEditarSeccion
            // 
            this.btnEditarSeccion.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarSeccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarSeccion.Name = "btnEditarSeccion";
            this.btnEditarSeccion.Size = new System.Drawing.Size(115, 34);
            this.btnEditarSeccion.Text = "Editar Seccion";
            this.btnEditarSeccion.Click += new System.EventHandler(this.btnEditarSeccion_Click);
            // 
            // btnEliminarSeccion
            // 
            this.btnEliminarSeccion.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarSeccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarSeccion.Name = "btnEliminarSeccion";
            this.btnEliminarSeccion.Size = new System.Drawing.Size(128, 34);
            this.btnEliminarSeccion.Text = "Eliminar Seccion";
            this.btnEliminarSeccion.Click += new System.EventHandler(this.btnEliminarSeccion_Click);
            // 
            // dgvSecciones
            // 
            this.dgvSecciones.AllowUserToAddRows = false;
            this.dgvSecciones.AllowUserToDeleteRows = false;
            this.dgvSecciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvSecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSecciones.Location = new System.Drawing.Point(12, 40);
            this.dgvSecciones.MultiSelect = false;
            this.dgvSecciones.Name = "dgvSecciones";
            this.dgvSecciones.ReadOnly = true;
            this.dgvSecciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSecciones.Size = new System.Drawing.Size(1378, 648);
            this.dgvSecciones.TabIndex = 2;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlSeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1404, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvSecciones);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlSeccion";
            this.Text = "Seccion";
            this.Load += new System.EventHandler(this.PnlSeccion_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAgregarSeccion;
        private System.Windows.Forms.ToolStripButton btnEditarSeccion;
        private System.Windows.Forms.ToolStripButton btnEliminarSeccion;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.DataGridView dgvSecciones;
        private System.Windows.Forms.ToolStripLabel tsLblDescripcion;
        private System.Windows.Forms.ToolStripTextBox tsTxtDescripcion;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
