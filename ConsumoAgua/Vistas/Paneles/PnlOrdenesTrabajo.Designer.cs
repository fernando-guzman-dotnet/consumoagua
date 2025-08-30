namespace SAPA.Vistas.Paneles
{
    partial class PnlOrdenesTrabajo
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
            this.dgvOrdenesTrabajo = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblNoContrato = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNoContrato = new System.Windows.Forms.ToolStripTextBox();
            this.tsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesTrabajo)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrdenesTrabajo
            // 
            this.dgvOrdenesTrabajo.AllowUserToAddRows = false;
            this.dgvOrdenesTrabajo.AllowUserToDeleteRows = false;
            this.dgvOrdenesTrabajo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdenesTrabajo.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenesTrabajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenesTrabajo.Location = new System.Drawing.Point(12, 40);
            this.dgvOrdenesTrabajo.MultiSelect = false;
            this.dgvOrdenesTrabajo.Name = "dgvOrdenesTrabajo";
            this.dgvOrdenesTrabajo.ReadOnly = true;
            this.dgvOrdenesTrabajo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenesTrabajo.Size = new System.Drawing.Size(1364, 615);
            this.dgvOrdenesTrabajo.TabIndex = 0;
            this.dgvOrdenesTrabajo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvOrdenesTrabajo_RowsAdded);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblNoContrato,
            this.tsTxtNoContrato,
            this.tsSeparator,
            this.btnAgregar,
            this.btnEditar,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1388, 37);
            this.toolStrip.TabIndex = 8;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblNoContrato
            // 
            this.tsLblNoContrato.Name = "tsLblNoContrato";
            this.tsLblNoContrato.Size = new System.Drawing.Size(76, 34);
            this.tsLblNoContrato.Text = "No. Contrato";
            // 
            // tsTxtNoContrato
            // 
            this.tsTxtNoContrato.Name = "tsTxtNoContrato";
            this.tsTxtNoContrato.Size = new System.Drawing.Size(100, 37);
            this.tsTxtNoContrato.TextChanged += new System.EventHandler(this.tsTxtNoContrato_TextChanged);
            // 
            // tsSeparator
            // 
            this.tsSeparator.Name = "tsSeparator";
            this.tsSeparator.Size = new System.Drawing.Size(6, 37);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(176, 34);
            this.btnAgregar.Text = "Agregar Orden de Trabajo";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(164, 34);
            this.btnEditar.Text = "Editar Orden de Trabajo";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlOrdenesTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1388, 661);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvOrdenesTrabajo);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlOrdenesTrabajo";
            this.Text = "PanelAccionesQuejas";
            this.Load += new System.EventHandler(this.PnlOrdenesTrabajo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesTrabajo)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdenesTrabajo;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripSeparator tsSeparator;
        private System.Windows.Forms.ToolStripLabel tsLblNoContrato;
        private System.Windows.Forms.ToolStripTextBox tsTxtNoContrato;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
