namespace SAPA.Vistas.Paneles
{
    partial class PnlCalle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvCalles = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmActualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBorrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblCalle = new System.Windows.Forms.ToolStripLabel();
            this.tstTxtCalle = new System.Windows.Forms.ToolStripTextBox();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregarCalle = new System.Windows.Forms.ToolStripButton();
            this.btnEditarCalle = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalles)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCalles
            // 
            this.dgvCalles.AllowUserToAddRows = false;
            this.dgvCalles.AllowUserToDeleteRows = false;
            this.dgvCalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvCalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalles.ContextMenuStrip = this.contextMenuStrip;
            this.dgvCalles.Location = new System.Drawing.Point(12, 40);
            this.dgvCalles.Name = "dgvCalles";
            this.dgvCalles.ReadOnly = true;
            this.dgvCalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCalles.Size = new System.Drawing.Size(1376, 616);
            this.dgvCalles.TabIndex = 4;
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
            this.tsLblCalle,
            this.tstTxtCalle,
            this.tsSeparador,
            this.btnAgregarCalle,
            this.btnEditarCalle,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1400, 37);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 6;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblCalle
            // 
            this.tsLblCalle.Name = "tsLblCalle";
            this.tsLblCalle.Size = new System.Drawing.Size(36, 34);
            this.tsLblCalle.Text = "Calle:";
            // 
            // tstTxtCalle
            // 
            this.tstTxtCalle.Name = "tstTxtCalle";
            this.tstTxtCalle.Size = new System.Drawing.Size(200, 37);
            this.tstTxtCalle.TextChanged += new System.EventHandler(this.tsTxtCalle_TextChanged);
            // 
            // tsSeparador
            // 
            this.tsSeparador.Name = "tsSeparador";
            this.tsSeparador.Size = new System.Drawing.Size(6, 37);
            // 
            // btnAgregarCalle
            // 
            this.btnAgregarCalle.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarCalle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarCalle.Name = "btnAgregarCalle";
            this.btnAgregarCalle.Size = new System.Drawing.Size(112, 34);
            this.btnAgregarCalle.Text = "Agregar Calle";
            this.btnAgregarCalle.Click += new System.EventHandler(this.btnAgregarCalle_Click);
            // 
            // btnEditarCalle
            // 
            this.btnEditarCalle.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarCalle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarCalle.Name = "btnEditarCalle";
            this.btnEditarCalle.Size = new System.Drawing.Size(100, 34);
            this.btnEditarCalle.Text = "Editar Calle";
            this.btnEditarCalle.Click += new System.EventHandler(this.btnEditarCalle_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlCalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 668);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvCalles);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlCalle";
            this.Text = "Calles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PnlCalle_FormClosing);
            this.Load += new System.EventHandler(this.PnlCalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalles)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCalles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmBorrar;
        private System.Windows.Forms.ToolStripMenuItem tsmActualizar;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblCalle;
        private System.Windows.Forms.ToolStripTextBox tstTxtCalle;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStripButton btnAgregarCalle;
        private System.Windows.Forms.ToolStripButton btnEditarCalle;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
