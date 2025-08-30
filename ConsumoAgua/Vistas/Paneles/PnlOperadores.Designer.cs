namespace SAPA.Vistas.Paneles {
    partial class PnlOperadores {
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
            this.tsLblUsuario = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtUsuario = new System.Windows.Forms.ToolStripTextBox();
            this.tsLblNombre = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNombre = new System.Windows.Forms.ToolStripTextBox();
            this.tsLblDomicilio = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtDomicilio = new System.Windows.Forms.ToolStripTextBox();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregarOperador = new System.Windows.Forms.ToolStripButton();
            this.btnEditarOperador = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarOperador = new System.Windows.Forms.ToolStripButton();
            this.dgvOperadores = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperadores)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblUsuario,
            this.tsTxtUsuario,
            this.tsLblNombre,
            this.tsTxtNombre,
            this.tsLblDomicilio,
            this.tsTxtDomicilio,
            this.tsSeparador,
            this.btnAgregarOperador,
            this.btnEditarOperador,
            this.btnEliminarOperador,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1404, 37);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 11;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblUsuario
            // 
            this.tsLblUsuario.Name = "tsLblUsuario";
            this.tsLblUsuario.Size = new System.Drawing.Size(50, 34);
            this.tsLblUsuario.Text = "Usuario:";
            // 
            // tsTxtUsuario
            // 
            this.tsTxtUsuario.Name = "tsTxtUsuario";
            this.tsTxtUsuario.Size = new System.Drawing.Size(150, 37);
            this.tsTxtUsuario.TextChanged += new System.EventHandler(this.tsTxtUsuario_TextChanged);
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
            this.tsTxtNombre.Size = new System.Drawing.Size(100, 37);
            this.tsTxtNombre.TextChanged += new System.EventHandler(this.tsTxtNombre_TextChanged);
            // 
            // tsLblDomicilio
            // 
            this.tsLblDomicilio.Name = "tsLblDomicilio";
            this.tsLblDomicilio.Size = new System.Drawing.Size(61, 34);
            this.tsLblDomicilio.Text = "Domicilio:";
            // 
            // tsTxtDomicilio
            // 
            this.tsTxtDomicilio.Name = "tsTxtDomicilio";
            this.tsTxtDomicilio.Size = new System.Drawing.Size(100, 37);
            this.tsTxtDomicilio.TextChanged += new System.EventHandler(this.tsTxtDomicilio_TextChanged);
            // 
            // tsSeparador
            // 
            this.tsSeparador.Name = "tsSeparador";
            this.tsSeparador.Size = new System.Drawing.Size(6, 37);
            // 
            // btnAgregarOperador
            // 
            this.btnAgregarOperador.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarOperador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarOperador.Name = "btnAgregarOperador";
            this.btnAgregarOperador.Size = new System.Drawing.Size(136, 34);
            this.btnAgregarOperador.Text = "Agregar Operador";
            this.btnAgregarOperador.Click += new System.EventHandler(this.btnAgregarOperador_Click);
            // 
            // btnEditarOperador
            // 
            this.btnEditarOperador.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarOperador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarOperador.Name = "btnEditarOperador";
            this.btnEditarOperador.Size = new System.Drawing.Size(124, 34);
            this.btnEditarOperador.Text = "Editar Operador";
            this.btnEditarOperador.Click += new System.EventHandler(this.btnEditarOperador_Click);
            // 
            // btnEliminarOperador
            // 
            this.btnEliminarOperador.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarOperador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarOperador.Name = "btnEliminarOperador";
            this.btnEliminarOperador.Size = new System.Drawing.Size(137, 34);
            this.btnEliminarOperador.Text = "Eliminar Operador";
            this.btnEliminarOperador.Click += new System.EventHandler(this.btnEliminarOperador_Click);
            // 
            // dgvOperadores
            // 
            this.dgvOperadores.AllowUserToAddRows = false;
            this.dgvOperadores.AllowUserToDeleteRows = false;
            this.dgvOperadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOperadores.BackgroundColor = System.Drawing.Color.White;
            this.dgvOperadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperadores.Location = new System.Drawing.Point(12, 40);
            this.dgvOperadores.MultiSelect = false;
            this.dgvOperadores.Name = "dgvOperadores";
            this.dgvOperadores.ReadOnly = true;
            this.dgvOperadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperadores.Size = new System.Drawing.Size(1380, 648);
            this.dgvOperadores.TabIndex = 10;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlOperadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1404, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvOperadores);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlOperadores";
            this.Text = "Panel Operadores";
            this.Load += new System.EventHandler(this.PnlOperadores_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAgregarOperador;
        private System.Windows.Forms.ToolStripButton btnEditarOperador;
        private System.Windows.Forms.ToolStripButton btnEliminarOperador;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.DataGridView dgvOperadores;
        private System.Windows.Forms.ToolStripLabel tsLblUsuario;
        private System.Windows.Forms.ToolStripTextBox tsTxtUsuario;
        private System.Windows.Forms.ToolStripLabel tsLblNombre;
        private System.Windows.Forms.ToolStripTextBox tsTxtNombre;
        private System.Windows.Forms.ToolStripLabel tsLblDomicilio;
        private System.Windows.Forms.ToolStripTextBox tsTxtDomicilio;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
