namespace SAPA.Vistas.Paneles
{
    partial class PnlTipoDescuento
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
            this.dgvTipoDescuento = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmBorrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblDescripción = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtDescripcion = new System.Windows.Forms.ToolStripTextBox();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregarTipoDescuento = new System.Windows.Forms.ToolStripButton();
            this.btnEditarTipoDescuento = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarTipoDescuento = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoDescuento)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTipoDescuento
            // 
            this.dgvTipoDescuento.AllowUserToAddRows = false;
            this.dgvTipoDescuento.AllowUserToDeleteRows = false;
            this.dgvTipoDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTipoDescuento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTipoDescuento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoDescuento.ContextMenuStrip = this.contextMenuStrip;
            this.dgvTipoDescuento.Location = new System.Drawing.Point(12, 40);
            this.dgvTipoDescuento.Name = "dgvTipoDescuento";
            this.dgvTipoDescuento.ReadOnly = true;
            this.dgvTipoDescuento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTipoDescuento.Size = new System.Drawing.Size(1376, 648);
            this.dgvTipoDescuento.TabIndex = 30;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmBorrar});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(107, 26);
            // 
            // tsmBorrar
            // 
            this.tsmBorrar.Name = "tsmBorrar";
            this.tsmBorrar.Size = new System.Drawing.Size(106, 22);
            this.tsmBorrar.Text = "Borrar";
            this.tsmBorrar.Click += new System.EventHandler(this.tsmBorrar_Click);
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
            this.btnAgregarTipoDescuento,
            this.btnEditarTipoDescuento,
            this.btnEliminarTipoDescuento,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1400, 37);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 31;
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
            // tsSeparador
            // 
            this.tsSeparador.Name = "tsSeparador";
            this.tsSeparador.Size = new System.Drawing.Size(6, 37);
            // 
            // btnAgregarTipoDescuento
            // 
            this.btnAgregarTipoDescuento.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarTipoDescuento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarTipoDescuento.Name = "btnAgregarTipoDescuento";
            this.btnAgregarTipoDescuento.Size = new System.Drawing.Size(168, 34);
            this.btnAgregarTipoDescuento.Text = "Agregar Tipo Descuento";
            this.btnAgregarTipoDescuento.Click += new System.EventHandler(this.btnAgregarTipoDescuento_Click);
            // 
            // btnEditarTipoDescuento
            // 
            this.btnEditarTipoDescuento.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarTipoDescuento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarTipoDescuento.Name = "btnEditarTipoDescuento";
            this.btnEditarTipoDescuento.Size = new System.Drawing.Size(156, 34);
            this.btnEditarTipoDescuento.Text = "Editar Tipo Descuento";
            this.btnEditarTipoDescuento.Click += new System.EventHandler(this.btnEditarTipoDescuento_Click);
            // 
            // btnEliminarTipoDescuento
            // 
            this.btnEliminarTipoDescuento.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarTipoDescuento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarTipoDescuento.Name = "btnEliminarTipoDescuento";
            this.btnEliminarTipoDescuento.Size = new System.Drawing.Size(169, 34);
            this.btnEliminarTipoDescuento.Text = "Eliminar Tipo Descuento";
            this.btnEliminarTipoDescuento.Click += new System.EventHandler(this.btnEliminarTipoDescuento_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlTipoDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvTipoDescuento);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlTipoDescuento";
            this.Text = "Tipo de Descuento";
            this.Load += new System.EventHandler(this.PnlTipoDescuento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoDescuento)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTipoDescuento;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmBorrar;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblDescripción;
        private System.Windows.Forms.ToolStripTextBox tsTxtDescripcion;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStripButton btnAgregarTipoDescuento;
        private System.Windows.Forms.ToolStripButton btnEditarTipoDescuento;
        private System.Windows.Forms.ToolStripButton btnEliminarTipoDescuento;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
