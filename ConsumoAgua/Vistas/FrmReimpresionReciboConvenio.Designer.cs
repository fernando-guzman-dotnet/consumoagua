namespace SAPA.Vistas
{
    partial class FrmReimpresionReciboConvenio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.grpPagos = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpPagos = new System.Windows.Forms.TabPage();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.grpDatosContrato = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblColonia = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTipoServicio = new System.Windows.Forms.Label();
            this.lblNoMedidor = new System.Windows.Forms.Label();
            this.lblNoContrato = new System.Windows.Forms.Label();
            this.txtNoContrato = new System.Windows.Forms.MaskedTextBox();
            this.btnSeleccionarCuenta = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.PagoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoIdConvenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoNombreEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoNombreBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoNombreCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoTotalPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip.SuspendLayout();
            this.grpPagos.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.grpDatosContrato.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip.Size = new System.Drawing.Size(811, 33);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 29;
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
            // grpPagos
            // 
            this.grpPagos.Controls.Add(this.tabControl);
            this.grpPagos.Location = new System.Drawing.Point(12, 170);
            this.grpPagos.Name = "grpPagos";
            this.grpPagos.Size = new System.Drawing.Size(784, 368);
            this.grpPagos.TabIndex = 34;
            this.grpPagos.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpPagos);
            this.tabControl.Location = new System.Drawing.Point(10, 20);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(768, 342);
            this.tabControl.TabIndex = 0;
            // 
            // tpPagos
            // 
            this.tpPagos.Controls.Add(this.dgvPagos);
            this.tpPagos.Location = new System.Drawing.Point(4, 22);
            this.tpPagos.Name = "tpPagos";
            this.tpPagos.Padding = new System.Windows.Forms.Padding(3);
            this.tpPagos.Size = new System.Drawing.Size(760, 316);
            this.tpPagos.TabIndex = 1;
            this.tpPagos.Text = "PAGOS";
            this.tpPagos.UseVisualStyleBackColor = true;
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PagoId,
            this.PagoIdConvenio,
            this.PagoFecha,
            this.PagoFormaPago,
            this.PagoNombreEmpleado,
            this.PagoNombreBanco,
            this.PagoNombreCaja,
            this.PagoReferencia,
            this.PagoTotalPagado});
            this.dgvPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPagos.Location = new System.Drawing.Point(3, 3);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.ReadOnly = true;
            this.dgvPagos.RowHeadersVisible = false;
            this.dgvPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagos.Size = new System.Drawing.Size(754, 310);
            this.dgvPagos.TabIndex = 42;
            // 
            // grpDatosContrato
            // 
            this.grpDatosContrato.Controls.Add(this.lblNombre);
            this.grpDatosContrato.Controls.Add(this.txtUsuario);
            this.grpDatosContrato.Controls.Add(this.txtDireccion);
            this.grpDatosContrato.Controls.Add(this.lblColonia);
            this.grpDatosContrato.Controls.Add(this.txtColonia);
            this.grpDatosContrato.Controls.Add(this.lblDireccion);
            this.grpDatosContrato.Controls.Add(this.lblTipoServicio);
            this.grpDatosContrato.Controls.Add(this.lblNoMedidor);
            this.grpDatosContrato.Location = new System.Drawing.Point(12, 67);
            this.grpDatosContrato.Name = "grpDatosContrato";
            this.grpDatosContrato.Size = new System.Drawing.Size(784, 97);
            this.grpDatosContrato.TabIndex = 33;
            this.grpDatosContrato.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(6, 16);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(175, 20);
            this.lblNombre.TabIndex = 17;
            this.lblNombre.Text = "Nombre del Usuario";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(210, 16);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(349, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(210, 42);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(349, 20);
            this.txtDireccion.TabIndex = 4;
            // 
            // lblColonia
            // 
            this.lblColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColonia.Location = new System.Drawing.Point(6, 68);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(175, 20);
            this.lblColonia.TabIndex = 17;
            this.lblColonia.Text = "Colonia";
            this.lblColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtColonia
            // 
            this.txtColonia.Enabled = false;
            this.txtColonia.Location = new System.Drawing.Point(210, 68);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.ReadOnly = true;
            this.txtColonia.Size = new System.Drawing.Size(349, 20);
            this.txtColonia.TabIndex = 4;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(6, 42);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(175, 20);
            this.lblDireccion.TabIndex = 17;
            this.lblDireccion.Text = "Dirección";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTipoServicio
            // 
            this.lblTipoServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoServicio.Location = new System.Drawing.Point(584, 16);
            this.lblTipoServicio.Name = "lblTipoServicio";
            this.lblTipoServicio.Size = new System.Drawing.Size(162, 20);
            this.lblTipoServicio.TabIndex = 17;
            this.lblTipoServicio.Text = "TIPO DE SERVICIO";
            this.lblTipoServicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoMedidor
            // 
            this.lblNoMedidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoMedidor.Location = new System.Drawing.Point(587, 42);
            this.lblNoMedidor.Name = "lblNoMedidor";
            this.lblNoMedidor.Size = new System.Drawing.Size(159, 20);
            this.lblNoMedidor.TabIndex = 17;
            this.lblNoMedidor.Text = "MEDIDOR NO. 000";
            this.lblNoMedidor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoContrato
            // 
            this.lblNoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoContrato.Location = new System.Drawing.Point(8, 44);
            this.lblNoContrato.Name = "lblNoContrato";
            this.lblNoContrato.Size = new System.Drawing.Size(175, 20);
            this.lblNoContrato.TabIndex = 31;
            this.lblNoContrato.Text = "No. de Contrato";
            this.lblNoContrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoContrato
            // 
            this.txtNoContrato.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.txtNoContrato.Location = new System.Drawing.Point(189, 44);
            this.txtNoContrato.Mask = "0000000000";
            this.txtNoContrato.Name = "txtNoContrato";
            this.txtNoContrato.PromptChar = '0';
            this.txtNoContrato.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNoContrato.ShortcutsEnabled = false;
            this.txtNoContrato.Size = new System.Drawing.Size(119, 20);
            this.txtNoContrato.TabIndex = 32;
            this.txtNoContrato.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.txtNoContrato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoContrato_KeyPress);
            // 
            // btnSeleccionarCuenta
            // 
            this.btnSeleccionarCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarCuenta.Location = new System.Drawing.Point(314, 44);
            this.btnSeleccionarCuenta.Name = "btnSeleccionarCuenta";
            this.btnSeleccionarCuenta.Size = new System.Drawing.Size(41, 20);
            this.btnSeleccionarCuenta.TabIndex = 30;
            this.btnSeleccionarCuenta.Text = ">>>";
            this.btnSeleccionarCuenta.UseVisualStyleBackColor = true;
            this.btnSeleccionarCuenta.Click += new System.EventHandler(this.btnSeleccionarCuenta_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(675, 544);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(121, 35);
            this.btnGenerar.TabIndex = 35;
            this.btnGenerar.Text = "REIMPRIMIR";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Visible = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // PagoId
            // 
            this.PagoId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoId.DataPropertyName = "Id";
            dataGridViewCellStyle2.Format = "D5";
            this.PagoId.DefaultCellStyle = dataGridViewCellStyle2;
            this.PagoId.HeaderText = "Folio";
            this.PagoId.Name = "PagoId";
            this.PagoId.ReadOnly = true;
            this.PagoId.Width = 59;
            // 
            // PagoIdConvenio
            // 
            this.PagoIdConvenio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoIdConvenio.DataPropertyName = "IdConvenio";
            dataGridViewCellStyle3.Format = "D10";
            this.PagoIdConvenio.DefaultCellStyle = dataGridViewCellStyle3;
            this.PagoIdConvenio.HeaderText = "IdConvenio";
            this.PagoIdConvenio.Name = "PagoIdConvenio";
            this.PagoIdConvenio.ReadOnly = true;
            this.PagoIdConvenio.Visible = false;
            this.PagoIdConvenio.Width = 96;
            // 
            // PagoFecha
            // 
            this.PagoFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoFecha.DataPropertyName = "Fecha";
            this.PagoFecha.HeaderText = "Fecha";
            this.PagoFecha.MinimumWidth = 150;
            this.PagoFecha.Name = "PagoFecha";
            this.PagoFecha.ReadOnly = true;
            this.PagoFecha.Width = 150;
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
            // PagoTotalPagado
            // 
            this.PagoTotalPagado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PagoTotalPagado.DataPropertyName = "Importe";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "\\$0.00";
            this.PagoTotalPagado.DefaultCellStyle = dataGridViewCellStyle4;
            this.PagoTotalPagado.HeaderText = "Total Pagado";
            this.PagoTotalPagado.Name = "PagoTotalPagado";
            this.PagoTotalPagado.ReadOnly = true;
            this.PagoTotalPagado.Width = 99;
            // 
            // FrmReimpresionReciboConvenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(811, 610);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.grpPagos);
            this.Controls.Add(this.grpDatosContrato);
            this.Controls.Add(this.lblNoContrato);
            this.Controls.Add(this.txtNoContrato);
            this.Controls.Add(this.btnSeleccionarCuenta);
            this.Controls.Add(this.toolStrip);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReimpresionReciboConvenio";
            this.Text = "Consulta de Históricos";
            this.Load += new System.EventHandler(this.FrmHistoricos_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpPagos.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpPagos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.grpDatosContrato.ResumeLayout(false);
            this.grpDatosContrato.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.GroupBox grpPagos;
        private System.Windows.Forms.GroupBox grpDatosContrato;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTipoServicio;
        private System.Windows.Forms.Label lblNoMedidor;
        private System.Windows.Forms.Label lblNoContrato;
        private System.Windows.Forms.MaskedTextBox txtNoContrato;
        private System.Windows.Forms.Button btnSeleccionarCuenta;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpPagos;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoIdConvenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoFormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoNombreEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoNombreBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoNombreCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoTotalPagado;
    }
}
