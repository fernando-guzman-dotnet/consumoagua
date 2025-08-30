namespace SAPA.Vistas
{
    partial class FrmRptPagosCancelados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpBuscarContrato = new System.Windows.Forms.GroupBox();
            this.lblNoContrato = new System.Windows.Forms.Label();
            this.txtNoContrato = new System.Windows.Forms.MaskedTextBox();
            this.btnSeleccionarContrato = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.PagoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoFolioInterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoNoContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoNombreEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoNombreBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoNombreCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoPeriodoPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoTotalPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbEmpleados = new System.Windows.Forms.ComboBox();
            this.lblcmbEmpleados = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.btnAplicarFiltros = new System.Windows.Forms.Button();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.grpBuscarContrato.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBuscarContrato
            // 
            this.grpBuscarContrato.Controls.Add(this.lblNoContrato);
            this.grpBuscarContrato.Controls.Add(this.txtNoContrato);
            this.grpBuscarContrato.Controls.Add(this.btnSeleccionarContrato);
            this.grpBuscarContrato.Controls.Add(this.lblUsuario);
            this.grpBuscarContrato.Controls.Add(this.txtUsuario);
            this.grpBuscarContrato.Controls.Add(this.lblDireccion);
            this.grpBuscarContrato.Controls.Add(this.txtDireccion);
            this.grpBuscarContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBuscarContrato.Location = new System.Drawing.Point(12, 38);
            this.grpBuscarContrato.Name = "grpBuscarContrato";
            this.grpBuscarContrato.Size = new System.Drawing.Size(813, 111);
            this.grpBuscarContrato.TabIndex = 37;
            this.grpBuscarContrato.TabStop = false;
            this.grpBuscarContrato.Text = "BUSCAR CONTRATO";
            // 
            // lblNoContrato
            // 
            this.lblNoContrato.AutoSize = true;
            this.lblNoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoContrato.Location = new System.Drawing.Point(38, 20);
            this.lblNoContrato.Name = "lblNoContrato";
            this.lblNoContrato.Size = new System.Drawing.Size(79, 13);
            this.lblNoContrato.TabIndex = 33;
            this.lblNoContrato.Text = "No. Contrato";
            // 
            // txtNoContrato
            // 
            this.txtNoContrato.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.txtNoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNoContrato.Location = new System.Drawing.Point(123, 16);
            this.txtNoContrato.Mask = "0000000000";
            this.txtNoContrato.Name = "txtNoContrato";
            this.txtNoContrato.PromptChar = '0';
            this.txtNoContrato.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNoContrato.ShortcutsEnabled = false;
            this.txtNoContrato.Size = new System.Drawing.Size(119, 20);
            this.txtNoContrato.TabIndex = 35;
            this.txtNoContrato.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.txtNoContrato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoContrato_KeyPress);
            // 
            // btnSeleccionarContrato
            // 
            this.btnSeleccionarContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarContrato.Location = new System.Drawing.Point(250, 16);
            this.btnSeleccionarContrato.Name = "btnSeleccionarContrato";
            this.btnSeleccionarContrato.Size = new System.Drawing.Size(42, 20);
            this.btnSeleccionarContrato.TabIndex = 29;
            this.btnSeleccionarContrato.Text = ">>>";
            this.btnSeleccionarContrato.UseVisualStyleBackColor = true;
            this.btnSeleccionarContrato.Click += new System.EventHandler(this.btnSeleccionarContrato_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(67, 46);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 13);
            this.lblUsuario.TabIndex = 34;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUsuario.Location = new System.Drawing.Point(123, 42);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(465, 20);
            this.txtUsuario.TabIndex = 30;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(56, 72);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(61, 13);
            this.lblDireccion.TabIndex = 32;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDireccion.Location = new System.Drawing.Point(123, 68);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(465, 20);
            this.txtDireccion.TabIndex = 31;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(840, 33);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 38;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PagoId,
            this.PagoFolioInterno,
            this.PagoNoContrato,
            this.PagoFecha,
            this.PagoFormaPago,
            this.PagoNombreEmpleado,
            this.PagoNombreBanco,
            this.PagoNombreCaja,
            this.PagoReferencia,
            this.PagoPeriodoPagado,
            this.PagoTotalPagado});
            this.dgvPagos.Location = new System.Drawing.Point(12, 219);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.ReadOnly = true;
            this.dgvPagos.RowHeadersVisible = false;
            this.dgvPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagos.Size = new System.Drawing.Size(813, 342);
            this.dgvPagos.TabIndex = 39;
            // 
            // PagoId
            // 
            this.PagoId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoId.DataPropertyName = "Id";
            dataGridViewCellStyle6.Format = "D5";
            this.PagoId.DefaultCellStyle = dataGridViewCellStyle6;
            this.PagoId.HeaderText = "Folio";
            this.PagoId.Name = "PagoId";
            this.PagoId.ReadOnly = true;
            this.PagoId.Width = 59;
            // 
            // PagoFolioInterno
            // 
            this.PagoFolioInterno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoFolioInterno.DataPropertyName = "FolioInterno";
            this.PagoFolioInterno.HeaderText = "Folio Interno";
            this.PagoFolioInterno.Name = "PagoFolioInterno";
            this.PagoFolioInterno.ReadOnly = true;
            this.PagoFolioInterno.Width = 95;
            // 
            // PagoNoContrato
            // 
            this.PagoNoContrato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoNoContrato.DataPropertyName = "NoContrato";
            dataGridViewCellStyle7.Format = "D10";
            this.PagoNoContrato.DefaultCellStyle = dataGridViewCellStyle7;
            this.PagoNoContrato.HeaderText = "No. Contrato";
            this.PagoNoContrato.Name = "PagoNoContrato";
            this.PagoNoContrato.ReadOnly = true;
            this.PagoNoContrato.Width = 96;
            // 
            // PagoFecha
            // 
            this.PagoFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoFecha.DataPropertyName = "Fecha";
            this.PagoFecha.HeaderText = "Fecha";
            this.PagoFecha.Name = "PagoFecha";
            this.PagoFecha.ReadOnly = true;
            this.PagoFecha.Width = 67;
            // 
            // PagoFormaPago
            // 
            this.PagoFormaPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoFormaPago.DataPropertyName = "DescripcionFormaPago";
            this.PagoFormaPago.HeaderText = "Forma de Pago";
            this.PagoFormaPago.Name = "PagoFormaPago";
            this.PagoFormaPago.ReadOnly = true;
            this.PagoFormaPago.Width = 81;
            // 
            // PagoNombreEmpleado
            // 
            this.PagoNombreEmpleado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoNombreEmpleado.DataPropertyName = "NombreEmpleado";
            this.PagoNombreEmpleado.HeaderText = "Empleado";
            this.PagoNombreEmpleado.Name = "PagoNombreEmpleado";
            this.PagoNombreEmpleado.ReadOnly = true;
            this.PagoNombreEmpleado.Width = 87;
            // 
            // PagoNombreBanco
            // 
            this.PagoNombreBanco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoNombreBanco.DataPropertyName = "NombreBanco";
            this.PagoNombreBanco.HeaderText = "Banco";
            this.PagoNombreBanco.Name = "PagoNombreBanco";
            this.PagoNombreBanco.ReadOnly = true;
            this.PagoNombreBanco.Width = 68;
            // 
            // PagoNombreCaja
            // 
            this.PagoNombreCaja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoNombreCaja.DataPropertyName = "NombreCaja";
            this.PagoNombreCaja.HeaderText = "Caja";
            this.PagoNombreCaja.Name = "PagoNombreCaja";
            this.PagoNombreCaja.ReadOnly = true;
            this.PagoNombreCaja.Width = 57;
            // 
            // PagoReferencia
            // 
            this.PagoReferencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoReferencia.DataPropertyName = "Referencia";
            this.PagoReferencia.HeaderText = "Referencia";
            this.PagoReferencia.Name = "PagoReferencia";
            this.PagoReferencia.ReadOnly = true;
            this.PagoReferencia.Width = 94;
            // 
            // PagoPeriodoPagado
            // 
            this.PagoPeriodoPagado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoPeriodoPagado.DataPropertyName = "PeriodoPagado";
            this.PagoPeriodoPagado.HeaderText = "Periodo Pagado";
            this.PagoPeriodoPagado.Name = "PagoPeriodoPagado";
            this.PagoPeriodoPagado.ReadOnly = true;
            this.PagoPeriodoPagado.Width = 112;
            // 
            // PagoTotalPagado
            // 
            this.PagoTotalPagado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoTotalPagado.DataPropertyName = "TotalPagado";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "\\$0.00";
            this.PagoTotalPagado.DefaultCellStyle = dataGridViewCellStyle8;
            this.PagoTotalPagado.HeaderText = "TotalPagado";
            this.PagoTotalPagado.Name = "PagoTotalPagado";
            this.PagoTotalPagado.ReadOnly = true;
            this.PagoTotalPagado.Width = 104;
            // 
            // cmbEmpleados
            // 
            this.cmbEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpleados.FormattingEnabled = true;
            this.cmbEmpleados.Location = new System.Drawing.Point(73, 22);
            this.cmbEmpleados.Name = "cmbEmpleados";
            this.cmbEmpleados.Size = new System.Drawing.Size(172, 21);
            this.cmbEmpleados.TabIndex = 40;
            // 
            // lblcmbEmpleados
            // 
            this.lblcmbEmpleados.AutoSize = true;
            this.lblcmbEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcmbEmpleados.Location = new System.Drawing.Point(6, 26);
            this.lblcmbEmpleados.Name = "lblcmbEmpleados";
            this.lblcmbEmpleados.Size = new System.Drawing.Size(62, 13);
            this.lblcmbEmpleados.TabIndex = 41;
            this.lblcmbEmpleados.Text = "Empleado";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.btnAplicarFiltros);
            this.grpFiltros.Controls.Add(this.lblFechaDesde);
            this.grpFiltros.Controls.Add(this.dtpFechaInicio);
            this.grpFiltros.Controls.Add(this.lblFechaHasta);
            this.grpFiltros.Controls.Add(this.dtpFechaFin);
            this.grpFiltros.Controls.Add(this.lblcmbEmpleados);
            this.grpFiltros.Controls.Add(this.cmbEmpleados);
            this.grpFiltros.Enabled = false;
            this.grpFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltros.Location = new System.Drawing.Point(12, 155);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(731, 58);
            this.grpFiltros.TabIndex = 42;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "FILTROS";
            // 
            // btnAplicarFiltros
            // 
            this.btnAplicarFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltros.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnAplicarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicarFiltros.Location = new System.Drawing.Point(616, 14);
            this.btnAplicarFiltros.Name = "btnAplicarFiltros";
            this.btnAplicarFiltros.Size = new System.Drawing.Size(109, 35);
            this.btnAplicarFiltros.TabIndex = 46;
            this.btnAplicarFiltros.Text = "APLICAR";
            this.btnAplicarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAplicarFiltros.UseVisualStyleBackColor = true;
            this.btnAplicarFiltros.Click += new System.EventHandler(this.btnAplicarFiltros_Click);
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(258, 26);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(43, 13);
            this.lblFechaDesde.TabIndex = 43;
            this.lblFechaDesde.Text = "Desde";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(307, 22);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaInicio.TabIndex = 42;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(408, 26);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(40, 13);
            this.lblFechaHasta.TabIndex = 45;
            this.lblFechaHasta.Text = "Hasta";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(454, 22);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaFin.TabIndex = 44;
            // 
            // FrmRptPagosCancelados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(840, 573);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.grpBuscarContrato);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.dgvPagos);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRptPagosCancelados";
            this.ShowIcon = false;
            this.Text = "Desaplicación de pagos";
            this.Load += new System.EventHandler(this.FrmRptPagosCancelados_Load);
            this.grpBuscarContrato.ResumeLayout(false);
            this.grpBuscarContrato.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBuscarContrato;
        private System.Windows.Forms.Label lblNoContrato;
        private System.Windows.Forms.MaskedTextBox txtNoContrato;
        private System.Windows.Forms.Button btnSeleccionarContrato;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoFolioInterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoNoContrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoFormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoNombreEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoNombreBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoNombreCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoPeriodoPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoTotalPagado;
        private System.Windows.Forms.ComboBox cmbEmpleados;
        private System.Windows.Forms.Label lblcmbEmpleados;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnAplicarFiltros;
    }
}
