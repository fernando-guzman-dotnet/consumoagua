namespace SAPA.Vistas.Paneles {
    partial class PnlEstado
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
            this.dgvEstados = new System.Windows.Forms.DataGridView();
            this.btnAgregarEstado = new System.Windows.Forms.ToolStripButton();
            this.btnEditarEstado = new System.Windows.Forms.ToolStripButton();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblNombre = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNombre = new System.Windows.Forms.ToolStripTextBox();
            this.btnEliminarEstado = new System.Windows.Forms.ToolStripButton();
            this.btnAsociarMunicipio = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstados)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEstados
            // 
            this.dgvEstados.AllowUserToAddRows = false;
            this.dgvEstados.AllowUserToDeleteRows = false;
            this.dgvEstados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstados.BackgroundColor = System.Drawing.Color.White;
            this.dgvEstados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstados.Location = new System.Drawing.Point(12, 45);
            this.dgvEstados.MultiSelect = false;
            this.dgvEstados.Name = "dgvEstados";
            this.dgvEstados.ReadOnly = true;
            this.dgvEstados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstados.Size = new System.Drawing.Size(1380, 648);
            this.dgvEstados.TabIndex = 4;
            // 
            // btnAgregarEstado
            // 
            this.btnAgregarEstado.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarEstado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarEstado.Name = "btnAgregarEstado";
            this.btnAgregarEstado.Size = new System.Drawing.Size(121, 34);
            this.btnAgregarEstado.Text = "Agregar Estado";
            this.btnAgregarEstado.Click += new System.EventHandler(this.btnAgregarEstado_Click);
            // 
            // btnEditarEstado
            // 
            this.btnEditarEstado.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarEstado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarEstado.Name = "btnEditarEstado";
            this.btnEditarEstado.Size = new System.Drawing.Size(109, 34);
            this.btnEditarEstado.Text = "Editar Estado";
            this.btnEditarEstado.Click += new System.EventHandler(this.btnEditarEstado_Click);
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
            this.btnAgregarEstado,
            this.btnEditarEstado,
            this.btnEliminarEstado,
            this.btnAsociarMunicipio,
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
            // btnEliminarEstado
            // 
            this.btnEliminarEstado.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarEstado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarEstado.Name = "btnEliminarEstado";
            this.btnEliminarEstado.Size = new System.Drawing.Size(122, 34);
            this.btnEliminarEstado.Text = "Eliminar Estado";
            this.btnEliminarEstado.Visible = false;
            // 
            // btnAsociarMunicipio
            // 
            this.btnAsociarMunicipio.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAsociarMunicipio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAsociarMunicipio.Name = "btnAsociarMunicipio";
            this.btnAsociarMunicipio.Size = new System.Drawing.Size(137, 34);
            this.btnAsociarMunicipio.Text = "Asociar Municipio";
            this.btnAsociarMunicipio.Click += new System.EventHandler(this.btnAsociarMunicipio_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvEstados);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlEstado";
            this.Text = "Catálogo Bancos";
            this.Load += new System.EventHandler(this.PnlEstado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstados)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEstados;
        private System.Windows.Forms.ToolStripButton btnAgregarEstado;
        private System.Windows.Forms.ToolStripButton btnEditarEstado;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblNombre;
        private System.Windows.Forms.ToolStripTextBox tsTxtNombre;
        private System.Windows.Forms.ToolStripButton btnEliminarEstado;
        private System.Windows.Forms.ToolStripButton btnAsociarMunicipio;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
