namespace SAPA.Vistas.Paneles {
    partial class PnlDepartamento {
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
            this.dgvDepartamento = new System.Windows.Forms.DataGridView();
            this.btnAgregarDepartamento = new System.Windows.Forms.ToolStripButton();
            this.btnEditarDepartamento = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarDepartamento = new System.Windows.Forms.ToolStripButton();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblDescripción = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtDescripcion = new System.Windows.Forms.ToolStripTextBox();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamento)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDepartamento
            // 
            this.dgvDepartamento.AllowUserToAddRows = false;
            this.dgvDepartamento.AllowUserToDeleteRows = false;
            this.dgvDepartamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartamento.BackgroundColor = System.Drawing.Color.White;
            this.dgvDepartamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamento.Location = new System.Drawing.Point(12, 45);
            this.dgvDepartamento.MultiSelect = false;
            this.dgvDepartamento.Name = "dgvDepartamento";
            this.dgvDepartamento.ReadOnly = true;
            this.dgvDepartamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartamento.Size = new System.Drawing.Size(1380, 648);
            this.dgvDepartamento.TabIndex = 4;
            // 
            // btnAgregarDepartamento
            // 
            this.btnAgregarDepartamento.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarDepartamento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarDepartamento.Name = "btnAgregarDepartamento";
            this.btnAgregarDepartamento.Size = new System.Drawing.Size(162, 34);
            this.btnAgregarDepartamento.Text = "Agregar Departamento";
            this.btnAgregarDepartamento.Click += new System.EventHandler(this.btnAgregarDepartamento_Click);
            // 
            // btnEditarDepartamento
            // 
            this.btnEditarDepartamento.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarDepartamento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarDepartamento.Name = "btnEditarDepartamento";
            this.btnEditarDepartamento.Size = new System.Drawing.Size(150, 34);
            this.btnEditarDepartamento.Text = "Editar Departamento";
            this.btnEditarDepartamento.Click += new System.EventHandler(this.btnEditarDepartamento_Click);
            // 
            // btnEliminarDepartamento
            // 
            this.btnEliminarDepartamento.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarDepartamento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarDepartamento.Name = "btnEliminarDepartamento";
            this.btnEliminarDepartamento.Size = new System.Drawing.Size(163, 34);
            this.btnEliminarDepartamento.Text = "Eliminar Departamento";
            this.btnEliminarDepartamento.Click += new System.EventHandler(this.btnEliminarDepartamento_Click);
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
            this.btnAgregarDepartamento,
            this.btnEditarDepartamento,
            this.btnEliminarDepartamento,
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
            // PnlDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvDepartamento);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlDepartamento";
            this.Text = "Panel_Conceptos";
            this.Load += new System.EventHandler(this.PnlDepartamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamento)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDepartamento;
        private System.Windows.Forms.ToolStripButton btnAgregarDepartamento;
        private System.Windows.Forms.ToolStripButton btnEditarDepartamento;
        private System.Windows.Forms.ToolStripButton btnEliminarDepartamento;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblDescripción;
        private System.Windows.Forms.ToolStripTextBox tsTxtDescripcion;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
