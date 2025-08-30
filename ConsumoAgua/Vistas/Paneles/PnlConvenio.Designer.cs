namespace SAPA.Vistas.Paneles
{
    partial class PnlConvenio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnEstablecerConvenio = new System.Windows.Forms.ToolStripButton();
            this.btnModificarConvenio = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.btnCancelarConvenio = new System.Windows.Forms.ToolStripButton();
            this.dgvConvenios = new System.Windows.Forms.DataGridView();
            this.colNoContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroPagos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodicidadPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVerPagos = new System.Windows.Forms.Button();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConvenios)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEstablecerConvenio,
            this.btnModificarConvenio,
            this.btnCerrar,
            this.btnCancelarConvenio});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1404, 37);
            this.toolStrip.TabIndex = 7;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnEstablecerConvenio
            // 
            this.btnEstablecerConvenio.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnEstablecerConvenio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEstablecerConvenio.Name = "btnEstablecerConvenio";
            this.btnEstablecerConvenio.Size = new System.Drawing.Size(148, 34);
            this.btnEstablecerConvenio.Text = "Establecer Convenio";
            this.btnEstablecerConvenio.Click += new System.EventHandler(this.btnEstablecerConvenio_Click);
            // 
            // btnModificarConvenio
            // 
            this.btnModificarConvenio.Image = global::SAPA.Properties.Resources.Editar;
            this.btnModificarConvenio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificarConvenio.Name = "btnModificarConvenio";
            this.btnModificarConvenio.Size = new System.Drawing.Size(146, 34);
            this.btnModificarConvenio.Text = "Modificar Convenio";
            this.btnModificarConvenio.Click += new System.EventHandler(this.btnModificarConvenio_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCancelarConvenio
            // 
            this.btnCancelarConvenio.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnCancelarConvenio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelarConvenio.Name = "btnCancelarConvenio";
            this.btnCancelarConvenio.Size = new System.Drawing.Size(141, 34);
            this.btnCancelarConvenio.Text = "Cancelar Convenio";
            this.btnCancelarConvenio.Click += new System.EventHandler(this.btnCancelarConvenio_Click);
            // 
            // dgvConvenios
            // 
            this.dgvConvenios.AllowUserToAddRows = false;
            this.dgvConvenios.AllowUserToDeleteRows = false;
            this.dgvConvenios.AllowUserToResizeRows = false;
            this.dgvConvenios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConvenios.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConvenios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConvenios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConvenios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNoContrato,
            this.colFechaInicio,
            this.colFechaFin,
            this.colNumeroPagos,
            this.colPeriodicidadPago,
            this.colEmpleado,
            this.colTotal});
            this.dgvConvenios.Location = new System.Drawing.Point(12, 40);
            this.dgvConvenios.MultiSelect = false;
            this.dgvConvenios.Name = "dgvConvenios";
            this.dgvConvenios.ReadOnly = true;
            this.dgvConvenios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConvenios.Size = new System.Drawing.Size(1380, 600);
            this.dgvConvenios.TabIndex = 6;
            // 
            // colNoContrato
            // 
            this.colNoContrato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNoContrato.DataPropertyName = "NoContrato";
            dataGridViewCellStyle2.Format = "D10";
            this.colNoContrato.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNoContrato.HeaderText = "No. Contrato";
            this.colNoContrato.Name = "colNoContrato";
            this.colNoContrato.ReadOnly = true;
            this.colNoContrato.Width = 96;
            // 
            // colFechaInicio
            // 
            this.colFechaInicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFechaInicio.DataPropertyName = "Fechainicio";
            this.colFechaInicio.HeaderText = "Fecha Inicio";
            this.colFechaInicio.Name = "colFechaInicio";
            this.colFechaInicio.ReadOnly = true;
            this.colFechaInicio.Width = 94;
            // 
            // colFechaFin
            // 
            this.colFechaFin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFechaFin.DataPropertyName = "FechaFin";
            this.colFechaFin.HeaderText = "Fecha Límite";
            this.colFechaFin.Name = "colFechaFin";
            this.colFechaFin.ReadOnly = true;
            this.colFechaFin.Width = 97;
            // 
            // colNumeroPagos
            // 
            this.colNumeroPagos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNumeroPagos.DataPropertyName = "NumeroPagos";
            this.colNumeroPagos.HeaderText = "No. Pagos";
            this.colNumeroPagos.Name = "colNumeroPagos";
            this.colNumeroPagos.ReadOnly = true;
            this.colNumeroPagos.Width = 84;
            // 
            // colPeriodicidadPago
            // 
            this.colPeriodicidadPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPeriodicidadPago.DataPropertyName = "DescripcionPeriodicidad";
            this.colPeriodicidadPago.HeaderText = "Periodicidad";
            this.colPeriodicidadPago.Name = "colPeriodicidadPago";
            this.colPeriodicidadPago.ReadOnly = true;
            this.colPeriodicidadPago.Width = 102;
            // 
            // colEmpleado
            // 
            this.colEmpleado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEmpleado.DataPropertyName = "NombreEmpleado";
            this.colEmpleado.HeaderText = "Empleado";
            this.colEmpleado.Name = "colEmpleado";
            this.colEmpleado.ReadOnly = true;
            this.colEmpleado.Width = 87;
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "Monto Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 92;
            // 
            // btnVerPagos
            // 
            this.btnVerPagos.BackColor = System.Drawing.Color.Transparent;
            this.btnVerPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerPagos.Image = global::SAPA.Properties.Resources.Buscar_33x33;
            this.btnVerPagos.Location = new System.Drawing.Point(1247, 645);
            this.btnVerPagos.Name = "btnVerPagos";
            this.btnVerPagos.Size = new System.Drawing.Size(145, 43);
            this.btnVerPagos.TabIndex = 15;
            this.btnVerPagos.Text = "Ver Pagos";
            this.btnVerPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerPagos.UseVisualStyleBackColor = false;
            this.btnVerPagos.Visible = false;
            // 
            // PnlConvenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1404, 700);
            this.Controls.Add(this.btnVerPagos);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvConvenios);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlConvenio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convenio";
            this.Load += new System.EventHandler(this.PnlConvenio_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConvenios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnEstablecerConvenio;
        private System.Windows.Forms.DataGridView dgvConvenios;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.ToolStripButton btnModificarConvenio;
        private System.Windows.Forms.ToolStripButton btnCancelarConvenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoContrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodicidadPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Button btnVerPagos;
    }
}
