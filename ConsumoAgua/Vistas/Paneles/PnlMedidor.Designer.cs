namespace SAPA.Vistas.Paneles
{
    partial class PnlMedidor
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
            this.dgvMedidores = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmBorrar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmActualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblNoMedidor = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNoMedidor = new System.Windows.Forms.ToolStripTextBox();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregarMedidor = new System.Windows.Forms.ToolStripButton();
            this.btnEditarMedidor = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarMedidor = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedidores)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMedidores
            // 
            this.dgvMedidores.AllowUserToAddRows = false;
            this.dgvMedidores.AllowUserToDeleteRows = false;
            this.dgvMedidores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMedidores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedidores.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedidores.ContextMenuStrip = this.contextMenuStrip;
            this.dgvMedidores.Location = new System.Drawing.Point(12, 45);
            this.dgvMedidores.Name = "dgvMedidores";
            this.dgvMedidores.ReadOnly = true;
            this.dgvMedidores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedidores.Size = new System.Drawing.Size(1380, 643);
            this.dgvMedidores.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmBorrar,
            this.tsmActualizar});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(107, 48);
            // 
            // tsmBorrar
            // 
            this.tsmBorrar.Name = "tsmBorrar";
            this.tsmBorrar.Size = new System.Drawing.Size(106, 22);
            this.tsmBorrar.Text = "Borrar";
            this.tsmBorrar.Click += new System.EventHandler(this.tsmBorrar_Click);
            // 
            // tsmActualizar
            // 
            this.tsmActualizar.Name = "tsmActualizar";
            this.tsmActualizar.Size = new System.Drawing.Size(106, 22);
            this.tsmActualizar.Text = "Editar";
            this.tsmActualizar.Click += new System.EventHandler(this.tsmActualizar_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblNoMedidor,
            this.tsTxtNoMedidor,
            this.tsSeparador,
            this.btnAgregarMedidor,
            this.btnEditarMedidor,
            this.btnEliminarMedidor,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1404, 37);
            this.toolStrip.TabIndex = 6;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblNoMedidor
            // 
            this.tsLblNoMedidor.Name = "tsLblNoMedidor";
            this.tsLblNoMedidor.Size = new System.Drawing.Size(115, 34);
            this.tsLblNoMedidor.Text = "Numero de Medidor";
            // 
            // tsTxtNoMedidor
            // 
            this.tsTxtNoMedidor.Name = "tsTxtNoMedidor";
            this.tsTxtNoMedidor.Size = new System.Drawing.Size(200, 37);
            this.tsTxtNoMedidor.TextChanged += new System.EventHandler(this.tsTxtNoMedidor_TextChanged);
            // 
            // tsSeparador
            // 
            this.tsSeparador.Name = "tsSeparador";
            this.tsSeparador.Size = new System.Drawing.Size(6, 37);
            // 
            // btnAgregarMedidor
            // 
            this.btnAgregarMedidor.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarMedidor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarMedidor.Name = "btnAgregarMedidor";
            this.btnAgregarMedidor.Size = new System.Drawing.Size(131, 34);
            this.btnAgregarMedidor.Text = "Agregar Medidor";
            this.btnAgregarMedidor.Click += new System.EventHandler(this.btnAgregarMedidor_Click);
            // 
            // btnEditarMedidor
            // 
            this.btnEditarMedidor.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarMedidor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarMedidor.Name = "btnEditarMedidor";
            this.btnEditarMedidor.Size = new System.Drawing.Size(119, 34);
            this.btnEditarMedidor.Text = "Editar Medidor";
            this.btnEditarMedidor.Click += new System.EventHandler(this.btnEditarMedidor_Click);
            // 
            // btnEliminarMedidor
            // 
            this.btnEliminarMedidor.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarMedidor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarMedidor.Name = "btnEliminarMedidor";
            this.btnEliminarMedidor.Size = new System.Drawing.Size(132, 34);
            this.btnEliminarMedidor.Text = "Eliminar Medidor";
            this.btnEliminarMedidor.Click += new System.EventHandler(this.btnEliminarMedidor_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlMedidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1404, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvMedidores);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlMedidor";
            this.Text = "Medidores";
            this.Load += new System.EventHandler(this.FrmMedidores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedidores)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMedidores;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmBorrar;
        private System.Windows.Forms.ToolStripMenuItem tsmActualizar;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblNoMedidor;
        private System.Windows.Forms.ToolStripTextBox tsTxtNoMedidor;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStripButton btnAgregarMedidor;
        private System.Windows.Forms.ToolStripButton btnEditarMedidor;
        private System.Windows.Forms.ToolStripButton btnEliminarMedidor;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
