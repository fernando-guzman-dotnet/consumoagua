namespace SAPA.Vistas.Paneles {
    partial class PnlColonia {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlColonia));
            this.dgvColonias = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmActualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBorrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblColonia = new System.Windows.Forms.ToolStripLabel();
            this.tstTxtColonia = new System.Windows.Forms.ToolStripTextBox();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregarColonia = new System.Windows.Forms.ToolStripButton();
            this.btnEditarColonia = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarColonia = new System.Windows.Forms.ToolStripButton();
            this.btnAsociarCalles = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColonias)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvColonias
            // 
            this.dgvColonias.AllowUserToAddRows = false;
            this.dgvColonias.AllowUserToDeleteRows = false;
            this.dgvColonias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColonias.BackgroundColor = System.Drawing.Color.White;
            this.dgvColonias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColonias.ContextMenuStrip = this.contextMenuStrip;
            this.dgvColonias.Location = new System.Drawing.Point(12, 40);
            this.dgvColonias.MultiSelect = false;
            this.dgvColonias.Name = "dgvColonias";
            this.dgvColonias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColonias.Size = new System.Drawing.Size(1376, 648);
            this.dgvColonias.TabIndex = 3;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmActualizar,
            this.tsmBorrar});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(127, 48);
            // 
            // tsmActualizar
            // 
            this.tsmActualizar.Name = "tsmActualizar";
            this.tsmActualizar.Size = new System.Drawing.Size(126, 22);
            this.tsmActualizar.Text = "Actualizar";
            this.tsmActualizar.Click += new System.EventHandler(this.tsmActualizar_Click);
            // 
            // tsmBorrar
            // 
            this.tsmBorrar.Name = "tsmBorrar";
            this.tsmBorrar.Size = new System.Drawing.Size(126, 22);
            this.tsmBorrar.Text = "Borrar";
            this.tsmBorrar.Click += new System.EventHandler(this.tsmBorrar_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblColonia,
            this.tstTxtColonia,
            this.tsSeparador,
            this.btnAgregarColonia,
            this.btnEditarColonia,
            this.btnEliminarColonia,
            this.btnAsociarCalles,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1400, 37);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 44;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblColonia
            // 
            this.tsLblColonia.Name = "tsLblColonia";
            this.tsLblColonia.Size = new System.Drawing.Size(51, 34);
            this.tsLblColonia.Text = "Colonia:";
            // 
            // tstTxtColonia
            // 
            this.tstTxtColonia.Name = "tstTxtColonia";
            this.tstTxtColonia.Size = new System.Drawing.Size(200, 37);
            this.tstTxtColonia.TextChanged += new System.EventHandler(this.tsTxtColonia_TextChanged);
            // 
            // tsSeparador
            // 
            this.tsSeparador.Name = "tsSeparador";
            this.tsSeparador.Size = new System.Drawing.Size(6, 37);
            // 
            // btnAgregarColonia
            // 
            this.btnAgregarColonia.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarColonia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarColonia.Name = "btnAgregarColonia";
            this.btnAgregarColonia.Size = new System.Drawing.Size(127, 34);
            this.btnAgregarColonia.Text = "Agregar Colonia";
            this.btnAgregarColonia.Click += new System.EventHandler(this.btnAgregarColonia_Click);
            // 
            // btnEditarColonia
            // 
            this.btnEditarColonia.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarColonia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarColonia.Name = "btnEditarColonia";
            this.btnEditarColonia.Size = new System.Drawing.Size(115, 34);
            this.btnEditarColonia.Text = "Editar Colonia";
            this.btnEditarColonia.Click += new System.EventHandler(this.btnEditarColonia_Click);
            // 
            // btnEliminarColonia
            // 
            this.btnEliminarColonia.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarColonia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarColonia.Name = "btnEliminarColonia";
            this.btnEliminarColonia.Size = new System.Drawing.Size(128, 34);
            this.btnEliminarColonia.Text = "Eliminar Colonia";
            this.btnEliminarColonia.Click += new System.EventHandler(this.btnEliminarColonia_Click);
            // 
            // btnAsociarCalles
            // 
            this.btnAsociarCalles.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAsociarCalles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAsociarCalles.Name = "btnAsociarCalles";
            this.btnAsociarCalles.Size = new System.Drawing.Size(114, 34);
            this.btnAsociarCalles.Text = "Asociar Calles";
            this.btnAsociarCalles.Click += new System.EventHandler(this.btnAsociarCalles_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlColonia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvColonias);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PnlColonia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Colonias";
            this.Load += new System.EventHandler(this.DlgVerColonias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColonias)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvColonias;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmBorrar;
        private System.Windows.Forms.ToolStripMenuItem tsmActualizar;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblColonia;
        private System.Windows.Forms.ToolStripTextBox tstTxtColonia;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStripButton btnAgregarColonia;
        private System.Windows.Forms.ToolStripButton btnEditarColonia;
        private System.Windows.Forms.ToolStripButton btnEliminarColonia;
        private System.Windows.Forms.ToolStripButton btnAsociarCalles;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
