namespace SAPA.Vistas.Paneles
{
    partial class PnlAdminOrdenesTrabajo
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
            this.btnAgregarConceptoOrden = new System.Windows.Forms.ToolStripButton();
            this.btnActualizarEstatus = new System.Windows.Forms.ToolStripButton();
            this.btnRevisarTareas = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.btnVerBitacora = new System.Windows.Forms.Button();
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
            this.dgvOrdenesTrabajo.Size = new System.Drawing.Size(1364, 557);
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
            this.btnAgregarConceptoOrden,
            this.btnActualizarEstatus,
            this.btnRevisarTareas,
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
            // btnAgregarConceptoOrden
            // 
            this.btnAgregarConceptoOrden.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarConceptoOrden.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarConceptoOrden.Name = "btnAgregarConceptoOrden";
            this.btnAgregarConceptoOrden.Size = new System.Drawing.Size(183, 34);
            this.btnAgregarConceptoOrden.Text = "Agregar Concepto a Orden";
            this.btnAgregarConceptoOrden.Click += new System.EventHandler(this.btnAgregarConceptoOrden_Click);
            // 
            // btnActualizarEstatus
            // 
            this.btnActualizarEstatus.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnActualizarEstatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizarEstatus.Name = "btnActualizarEstatus";
            this.btnActualizarEstatus.Size = new System.Drawing.Size(133, 34);
            this.btnActualizarEstatus.Text = "Actualizar Estatus";
            this.btnActualizarEstatus.Click += new System.EventHandler(this.btnActualizarEstatus_Click);
            // 
            // btnRevisarTareas
            // 
            this.btnRevisarTareas.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnRevisarTareas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRevisarTareas.Name = "btnRevisarTareas";
            this.btnRevisarTareas.Size = new System.Drawing.Size(113, 34);
            this.btnRevisarTareas.Text = "Revisar Tareas";
            this.btnRevisarTareas.Click += new System.EventHandler(this.btnRevisarTareas_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnVerBitacora
            // 
            this.btnVerBitacora.BackColor = System.Drawing.Color.Transparent;
            this.btnVerBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerBitacora.Image = global::SAPA.Properties.Resources.Buscar_33x33;
            this.btnVerBitacora.Location = new System.Drawing.Point(1231, 606);
            this.btnVerBitacora.Name = "btnVerBitacora";
            this.btnVerBitacora.Size = new System.Drawing.Size(145, 43);
            this.btnVerBitacora.TabIndex = 14;
            this.btnVerBitacora.Text = "Ver Bitacora";
            this.btnVerBitacora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerBitacora.UseVisualStyleBackColor = false;
            this.btnVerBitacora.Click += new System.EventHandler(this.btnVerBitacora_Click);
            // 
            // PnlAdminOrdenesTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1388, 661);
            this.Controls.Add(this.btnVerBitacora);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvOrdenesTrabajo);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlAdminOrdenesTrabajo";
            this.Text = "Administrador de Ordenes de Trabajo";
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
        private System.Windows.Forms.ToolStripSeparator tsSeparator;
        private System.Windows.Forms.ToolStripLabel tsLblNoContrato;
        private System.Windows.Forms.ToolStripTextBox tsTxtNoContrato;
        private System.Windows.Forms.ToolStripButton btnAgregarConceptoOrden;
        private System.Windows.Forms.ToolStripButton btnActualizarEstatus;
        private System.Windows.Forms.Button btnVerBitacora;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.ToolStripButton btnRevisarTareas;
    }
}
