namespace SAPA.Vistas.Dialogos
{
    partial class DlgConvenio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgConvenio));
            this.grpConvenio = new System.Windows.Forms.GroupBox();
            this.lblTituloDgv = new System.Windows.Forms.Label();
            this.lblTotalPago = new System.Windows.Forms.Label();
            this.dgvProyeccionPagos = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nudNumeroPagos = new System.Windows.Forms.NumericUpDown();
            this.lblNumeroPagos = new System.Windows.Forms.Label();
            this.cmbPeriodicidades = new System.Windows.Forms.ComboBox();
            this.lblPeriodicidadesCobro = new System.Windows.Forms.Label();
            this.txtNoContrato = new System.Windows.Forms.TextBox();
            this.lblNoContrato = new System.Windows.Forms.Label();
            this.grpPeriodoConvenio = new System.Windows.Forms.GroupBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.chkImprimirConvenio = new System.Windows.Forms.CheckBox();
            this.grpConvenio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyeccionPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroPagos)).BeginInit();
            this.grpPeriodoConvenio.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConvenio
            // 
            this.grpConvenio.Controls.Add(this.lblTituloDgv);
            this.grpConvenio.Controls.Add(this.lblTotalPago);
            this.grpConvenio.Controls.Add(this.dgvProyeccionPagos);
            this.grpConvenio.Controls.Add(this.nudNumeroPagos);
            this.grpConvenio.Controls.Add(this.lblNumeroPagos);
            this.grpConvenio.Controls.Add(this.cmbPeriodicidades);
            this.grpConvenio.Controls.Add(this.lblPeriodicidadesCobro);
            this.grpConvenio.Controls.Add(this.txtNoContrato);
            this.grpConvenio.Controls.Add(this.lblNoContrato);
            this.grpConvenio.Controls.Add(this.grpPeriodoConvenio);
            this.grpConvenio.Location = new System.Drawing.Point(8, 12);
            this.grpConvenio.Name = "grpConvenio";
            this.grpConvenio.Size = new System.Drawing.Size(653, 449);
            this.grpConvenio.TabIndex = 0;
            this.grpConvenio.TabStop = false;
            // 
            // lblTituloDgv
            // 
            this.lblTituloDgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDgv.Location = new System.Drawing.Point(315, 26);
            this.lblTituloDgv.Name = "lblTituloDgv";
            this.lblTituloDgv.Size = new System.Drawing.Size(332, 33);
            this.lblTituloDgv.TabIndex = 14;
            this.lblTituloDgv.Text = "PROYECCIÓN DE PAGOS";
            this.lblTituloDgv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalPago
            // 
            this.lblTotalPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPago.Location = new System.Drawing.Point(60, 411);
            this.lblTotalPago.Name = "lblTotalPago";
            this.lblTotalPago.Size = new System.Drawing.Size(249, 23);
            this.lblTotalPago.TabIndex = 13;
            this.lblTotalPago.Text = "Total a pagar $00.00";
            this.lblTotalPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvProyeccionPagos
            // 
            this.dgvProyeccionPagos.AllowUserToAddRows = false;
            this.dgvProyeccionPagos.AllowUserToDeleteRows = false;
            this.dgvProyeccionPagos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProyeccionPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProyeccionPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProyeccionPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colImporte});
            this.dgvProyeccionPagos.Location = new System.Drawing.Point(315, 62);
            this.dgvProyeccionPagos.MultiSelect = false;
            this.dgvProyeccionPagos.Name = "dgvProyeccionPagos";
            this.dgvProyeccionPagos.ReadOnly = true;
            this.dgvProyeccionPagos.RowHeadersVisible = false;
            this.dgvProyeccionPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProyeccionPagos.Size = new System.Drawing.Size(332, 372);
            this.dgvProyeccionPagos.TabIndex = 12;
            // 
            // colFecha
            // 
            this.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.colFecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 67;
            // 
            // colImporte
            // 
            this.colImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colImporte.DataPropertyName = "Importe";
            dataGridViewCellStyle3.Format = "N2";
            this.colImporte.DefaultCellStyle = dataGridViewCellStyle3;
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            // 
            // nudNumeroPagos
            // 
            this.nudNumeroPagos.Location = new System.Drawing.Point(169, 62);
            this.nudNumeroPagos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroPagos.Name = "nudNumeroPagos";
            this.nudNumeroPagos.Size = new System.Drawing.Size(65, 20);
            this.nudNumeroPagos.TabIndex = 11;
            this.nudNumeroPagos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroPagos.ValueChanged += new System.EventHandler(this.nudNumeroPagos_ValueChanged);
            // 
            // lblNumeroPagos
            // 
            this.lblNumeroPagos.AutoSize = true;
            this.lblNumeroPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroPagos.Location = new System.Drawing.Point(57, 66);
            this.lblNumeroPagos.Name = "lblNumeroPagos";
            this.lblNumeroPagos.Size = new System.Drawing.Size(106, 13);
            this.lblNumeroPagos.TabIndex = 10;
            this.lblNumeroPagos.Text = "Número de pagos";
            // 
            // cmbPeriodicidades
            // 
            this.cmbPeriodicidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodicidades.FormattingEnabled = true;
            this.cmbPeriodicidades.Location = new System.Drawing.Point(169, 87);
            this.cmbPeriodicidades.Name = "cmbPeriodicidades";
            this.cmbPeriodicidades.Size = new System.Drawing.Size(140, 21);
            this.cmbPeriodicidades.TabIndex = 6;
            this.cmbPeriodicidades.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodicidades_SelectedIndexChanged);
            // 
            // lblPeriodicidadesCobro
            // 
            this.lblPeriodicidadesCobro.AutoSize = true;
            this.lblPeriodicidadesCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodicidadesCobro.Location = new System.Drawing.Point(29, 91);
            this.lblPeriodicidadesCobro.Name = "lblPeriodicidadesCobro";
            this.lblPeriodicidadesCobro.Size = new System.Drawing.Size(134, 13);
            this.lblPeriodicidadesCobro.TabIndex = 5;
            this.lblPeriodicidadesCobro.Text = "Periodicidad del cobro";
            // 
            // txtNoContrato
            // 
            this.txtNoContrato.Enabled = false;
            this.txtNoContrato.Location = new System.Drawing.Point(94, 12);
            this.txtNoContrato.Name = "txtNoContrato";
            this.txtNoContrato.ReadOnly = true;
            this.txtNoContrato.Size = new System.Drawing.Size(140, 20);
            this.txtNoContrato.TabIndex = 1;
            // 
            // lblNoContrato
            // 
            this.lblNoContrato.AutoSize = true;
            this.lblNoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoContrato.Location = new System.Drawing.Point(9, 16);
            this.lblNoContrato.Name = "lblNoContrato";
            this.lblNoContrato.Size = new System.Drawing.Size(79, 13);
            this.lblNoContrato.TabIndex = 0;
            this.lblNoContrato.Text = "No. Contrato";
            // 
            // grpPeriodoConvenio
            // 
            this.grpPeriodoConvenio.Controls.Add(this.lblFechaInicio);
            this.grpPeriodoConvenio.Controls.Add(this.dtpFechaInicio);
            this.grpPeriodoConvenio.Controls.Add(this.lblFechaFin);
            this.grpPeriodoConvenio.Controls.Add(this.dtpFechaFin);
            this.grpPeriodoConvenio.Location = new System.Drawing.Point(116, 114);
            this.grpPeriodoConvenio.Name = "grpPeriodoConvenio";
            this.grpPeriodoConvenio.Size = new System.Drawing.Size(193, 68);
            this.grpPeriodoConvenio.TabIndex = 9;
            this.grpPeriodoConvenio.TabStop = false;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(6, 16);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(77, 13);
            this.lblFechaInicio.TabIndex = 2;
            this.lblFechaInicio.Text = "Fecha Inicio";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(89, 12);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaInicio.TabIndex = 4;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(4, 42);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(79, 13);
            this.lblFechaFin.TabIndex = 2;
            this.lblFechaFin.Text = "Fecha Limite";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Enabled = false;
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(89, 38);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaFin.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(586, 467);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(505, 467);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // chkImprimirConvenio
            // 
            this.chkImprimirConvenio.AutoSize = true;
            this.chkImprimirConvenio.Checked = true;
            this.chkImprimirConvenio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImprimirConvenio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImprimirConvenio.Location = new System.Drawing.Point(8, 468);
            this.chkImprimirConvenio.Name = "chkImprimirConvenio";
            this.chkImprimirConvenio.Size = new System.Drawing.Size(248, 17);
            this.chkImprimirConvenio.TabIndex = 13;
            this.chkImprimirConvenio.Text = "GENERAR IMPRESIÓN DE CONVENIO";
            this.chkImprimirConvenio.UseVisualStyleBackColor = true;
            // 
            // DlgConvenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(673, 518);
            this.Controls.Add(this.chkImprimirConvenio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grpConvenio);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgConvenio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convenio";
            this.Load += new System.EventHandler(this.DlgConvenio_Load);
            this.grpConvenio.ResumeLayout(false);
            this.grpConvenio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyeccionPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroPagos)).EndInit();
            this.grpPeriodoConvenio.ResumeLayout(false);
            this.grpPeriodoConvenio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConvenio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.TextBox txtNoContrato;
        private System.Windows.Forms.Label lblNoContrato;
        private System.Windows.Forms.ComboBox cmbPeriodicidades;
        private System.Windows.Forms.Label lblPeriodicidadesCobro;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.GroupBox grpPeriodoConvenio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.NumericUpDown nudNumeroPagos;
        private System.Windows.Forms.Label lblNumeroPagos;
        private System.Windows.Forms.Label lblTotalPago;
        private System.Windows.Forms.DataGridView dgvProyeccionPagos;
        private System.Windows.Forms.Label lblTituloDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.CheckBox chkImprimirConvenio;
    }
}
