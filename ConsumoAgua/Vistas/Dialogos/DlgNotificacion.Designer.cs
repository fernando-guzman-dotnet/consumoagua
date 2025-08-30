namespace SAPA.Vistas.Dialogos {
    partial class DlgNotificacion {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgNotificacion));
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.cmbNotificadores = new System.Windows.Forms.ComboBox();
            this.lblNotificador = new System.Windows.Forms.Label();
            this.lblNoContrato = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblNombreContrato = new System.Windows.Forms.Label();
            this.txtNombreContrato = new System.Windows.Forms.TextBox();
            this.mtxtNoContrato = new System.Windows.Forms.MaskedTextBox();
            this.grpDatosContrato = new System.Windows.Forms.GroupBox();
            this.txtDireccionContrato = new System.Windows.Forms.TextBox();
            this.lblDireccionContrato = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblCapturador = new System.Windows.Forms.Label();
            this.txtCapturador = new System.Windows.Forms.TextBox();
            this.grpDatosContrato.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(56, 16);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(205, 16);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(30, 13);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "Hora";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(99, 166);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(253, 52);
            this.txtObservaciones.TabIndex = 13;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(15, 166);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(78, 13);
            this.lblObservaciones.TabIndex = 40;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // cmbNotificadores
            // 
            this.cmbNotificadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNotificadores.FormattingEnabled = true;
            this.cmbNotificadores.Location = new System.Drawing.Point(99, 41);
            this.cmbNotificadores.Name = "cmbNotificadores";
            this.cmbNotificadores.Size = new System.Drawing.Size(253, 21);
            this.cmbNotificadores.TabIndex = 2;
            // 
            // lblNotificador
            // 
            this.lblNotificador.AutoSize = true;
            this.lblNotificador.Location = new System.Drawing.Point(35, 45);
            this.lblNotificador.Name = "lblNotificador";
            this.lblNotificador.Size = new System.Drawing.Size(58, 13);
            this.lblNotificador.TabIndex = 7;
            this.lblNotificador.Text = "Notificador";
            // 
            // lblNoContrato
            // 
            this.lblNoContrato.AutoSize = true;
            this.lblNoContrato.Location = new System.Drawing.Point(26, 75);
            this.lblNoContrato.Name = "lblNoContrato";
            this.lblNoContrato.Size = new System.Drawing.Size(67, 13);
            this.lblNoContrato.TabIndex = 3;
            this.lblNoContrato.Text = "No. Contrato";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(172, 70);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblNombreContrato
            // 
            this.lblNombreContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombreContrato.AutoSize = true;
            this.lblNombreContrato.Location = new System.Drawing.Point(44, 16);
            this.lblNombreContrato.Name = "lblNombreContrato";
            this.lblNombreContrato.Size = new System.Drawing.Size(44, 13);
            this.lblNombreContrato.TabIndex = 3;
            this.lblNombreContrato.Text = "Nombre";
            // 
            // txtNombreContrato
            // 
            this.txtNombreContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreContrato.Enabled = false;
            this.txtNombreContrato.Location = new System.Drawing.Point(94, 12);
            this.txtNombreContrato.Name = "txtNombreContrato";
            this.txtNombreContrato.Size = new System.Drawing.Size(253, 20);
            this.txtNombreContrato.TabIndex = 5;
            // 
            // mtxtNoContrato
            // 
            this.mtxtNoContrato.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.mtxtNoContrato.Location = new System.Drawing.Point(99, 71);
            this.mtxtNoContrato.Mask = "0000000000";
            this.mtxtNoContrato.Name = "mtxtNoContrato";
            this.mtxtNoContrato.PromptChar = '0';
            this.mtxtNoContrato.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtxtNoContrato.ShortcutsEnabled = false;
            this.mtxtNoContrato.Size = new System.Drawing.Size(67, 20);
            this.mtxtNoContrato.TabIndex = 3;
            this.mtxtNoContrato.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.mtxtNoContrato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtNoContrato_KeyPress);
            // 
            // grpDatosContrato
            // 
            this.grpDatosContrato.Controls.Add(this.txtDireccionContrato);
            this.grpDatosContrato.Controls.Add(this.lblDireccionContrato);
            this.grpDatosContrato.Controls.Add(this.txtNombreContrato);
            this.grpDatosContrato.Controls.Add(this.lblNombreContrato);
            this.grpDatosContrato.Location = new System.Drawing.Point(5, 91);
            this.grpDatosContrato.Name = "grpDatosContrato";
            this.grpDatosContrato.Size = new System.Drawing.Size(355, 69);
            this.grpDatosContrato.TabIndex = 46;
            this.grpDatosContrato.TabStop = false;
            // 
            // txtDireccionContrato
            // 
            this.txtDireccionContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccionContrato.Enabled = false;
            this.txtDireccionContrato.Location = new System.Drawing.Point(94, 38);
            this.txtDireccionContrato.Name = "txtDireccionContrato";
            this.txtDireccionContrato.Size = new System.Drawing.Size(253, 20);
            this.txtDireccionContrato.TabIndex = 7;
            // 
            // lblDireccionContrato
            // 
            this.lblDireccionContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDireccionContrato.AutoSize = true;
            this.lblDireccionContrato.Location = new System.Drawing.Point(36, 41);
            this.lblDireccionContrato.Name = "lblDireccionContrato";
            this.lblDireccionContrato.Size = new System.Drawing.Size(52, 13);
            this.lblDireccionContrato.TabIndex = 6;
            this.lblDireccionContrato.Text = "Dirección";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(277, 250);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(196, 251);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(99, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(95, 20);
            this.dtpFecha.TabIndex = 47;
            // 
            // dtpHora
            // 
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(241, 12);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(93, 20);
            this.dtpHora.TabIndex = 48;
            // 
            // lblCapturador
            // 
            this.lblCapturador.AutoSize = true;
            this.lblCapturador.Location = new System.Drawing.Point(49, 228);
            this.lblCapturador.Name = "lblCapturador";
            this.lblCapturador.Size = new System.Drawing.Size(44, 13);
            this.lblCapturador.TabIndex = 9;
            this.lblCapturador.Text = "Capturó";
            // 
            // txtCapturador
            // 
            this.txtCapturador.Enabled = false;
            this.txtCapturador.Location = new System.Drawing.Point(99, 224);
            this.txtCapturador.Name = "txtCapturador";
            this.txtCapturador.Size = new System.Drawing.Size(253, 20);
            this.txtCapturador.TabIndex = 17;
            // 
            // DlgNotificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(364, 303);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.mtxtNoContrato);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCapturador);
            this.Controls.Add(this.lblCapturador);
            this.Controls.Add(this.lblNotificador);
            this.Controls.Add(this.cmbNotificadores);
            this.Controls.Add(this.lblNoContrato);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.grpDatosContrato);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgNotificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notificación";
            this.Load += new System.EventHandler(this.DlgNotificacion_Load);
            this.grpDatosContrato.ResumeLayout(false);
            this.grpDatosContrato.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.ComboBox cmbNotificadores;
        private System.Windows.Forms.Label lblNotificador;
        private System.Windows.Forms.Label lblNoContrato;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblNombreContrato;
        private System.Windows.Forms.TextBox txtNombreContrato;
        private System.Windows.Forms.MaskedTextBox mtxtNoContrato;
        private System.Windows.Forms.GroupBox grpDatosContrato;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.TextBox txtDireccionContrato;
        private System.Windows.Forms.Label lblDireccionContrato;
        private System.Windows.Forms.Label lblCapturador;
        private System.Windows.Forms.TextBox txtCapturador;
    }
}
