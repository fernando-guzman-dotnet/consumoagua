namespace SAPA.Vistas.Paneles {
    partial class PnlUsuario {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlUsuario));
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblNombre = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNombre = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregarUsuario = new System.Windows.Forms.ToolStripButton();
            this.btnEditarUsuario = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarUsuario = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.btnVerDirecciones = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 43);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(1380, 645);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblNombre,
            this.tsTxtNombre,
            this.toolStripSeparator1,
            this.btnAgregarUsuario,
            this.btnEditarUsuario,
            this.btnEliminarUsuario,
            this.btnCerrar,
            this.btnVerDirecciones});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1404, 37);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblNombre
            // 
            this.tsLblNombre.Name = "tsLblNombre";
            this.tsLblNombre.Size = new System.Drawing.Size(51, 34);
            this.tsLblNombre.Text = "Nombre";
            // 
            // tsTxtNombre
            // 
            this.tsTxtNombre.Name = "tsTxtNombre";
            this.tsTxtNombre.Size = new System.Drawing.Size(150, 37);
            this.tsTxtNombre.TextChanged += new System.EventHandler(this.tsTxtNombre_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(126, 34);
            this.btnAgregarUsuario.Text = "Agregar Usuario";
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(114, 34);
            this.btnEditarUsuario.Text = "Editar Usuario";
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(127, 34);
            this.btnEliminarUsuario.Text = "Eliminar Usuario";
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnVerDirecciones
            // 
            this.btnVerDirecciones.Image = global::SAPA.Properties.Resources.Editar;
            this.btnVerDirecciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerDirecciones.Name = "btnVerDirecciones";
            this.btnVerDirecciones.Size = new System.Drawing.Size(121, 34);
            this.btnVerDirecciones.Text = "Ver Direcciones";
            this.btnVerDirecciones.Click += new System.EventHandler(this.btnVerDirecciones_Click);
            // 
            // PnlUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1404, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvUsuarios);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PnlUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Panel_Usuario";
            this.Load += new System.EventHandler(this.PnlUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAgregarUsuario;
        private System.Windows.Forms.ToolStripButton btnEditarUsuario;
        private System.Windows.Forms.ToolStripButton btnEliminarUsuario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tsLblNombre;
        private System.Windows.Forms.ToolStripTextBox tsTxtNombre;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.ToolStripButton btnVerDirecciones;
    }
}
