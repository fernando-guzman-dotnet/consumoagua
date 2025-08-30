namespace SAPA.Vistas.Dialogos
{
    partial class DlgOrdenTrabajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgOrdenTrabajo));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.mtxtNoContrato = new System.Windows.Forms.MaskedTextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblComentarios = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblTelefonoContacto = new System.Windows.Forms.Label();
            this.txtCapturador = new System.Windows.Forms.TextBox();
            this.lblTipoOrden = new System.Windows.Forms.Label();
            this.cmbTipoOrdenes = new System.Windows.Forms.ComboBox();
            this.lblNoContrato = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.grpDatosContrato = new System.Windows.Forms.GroupBox();
            this.txtDireccionContrato = new System.Windows.Forms.TextBox();
            this.lblDireccionContrato = new System.Windows.Forms.Label();
            this.txtNombreContratista = new System.Windows.Forms.TextBox();
            this.lblNombreContrato = new System.Windows.Forms.Label();
            this.lblCapturador = new System.Windows.Forms.Label();
            this.cmbSupervisores = new System.Windows.Forms.ComboBox();
            this.grpDatosContrato.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(292, 289);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(211, 289);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(106, 109);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(95, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // dtpHora
            // 
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(248, 109);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(93, 20);
            this.dtpHora.TabIndex = 4;
            // 
            // mtxtNoContrato
            // 
            this.mtxtNoContrato.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.mtxtNoContrato.Location = new System.Drawing.Point(106, 14);
            this.mtxtNoContrato.Mask = "0000000000";
            this.mtxtNoContrato.Name = "mtxtNoContrato";
            this.mtxtNoContrato.PromptChar = '0';
            this.mtxtNoContrato.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtxtNoContrato.ShortcutsEnabled = false;
            this.mtxtNoContrato.Size = new System.Drawing.Size(67, 20);
            this.mtxtNoContrato.TabIndex = 0;
            this.mtxtNoContrato.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.mtxtNoContrato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtNoContrato_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(179, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblComentarios
            // 
            this.lblComentarios.AutoSize = true;
            this.lblComentarios.Location = new System.Drawing.Point(22, 162);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(78, 13);
            this.lblComentarios.TabIndex = 67;
            this.lblComentarios.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(106, 162);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(253, 52);
            this.txtObservaciones.TabIndex = 6;
            // 
            // lblTelefonoContacto
            // 
            this.lblTelefonoContacto.AutoSize = true;
            this.lblTelefonoContacto.Location = new System.Drawing.Point(43, 239);
            this.lblTelefonoContacto.Name = "lblTelefonoContacto";
            this.lblTelefonoContacto.Size = new System.Drawing.Size(57, 13);
            this.lblTelefonoContacto.TabIndex = 60;
            this.lblTelefonoContacto.Text = "Supervisor";
            // 
            // txtCapturador
            // 
            this.txtCapturador.Enabled = false;
            this.txtCapturador.Location = new System.Drawing.Point(106, 263);
            this.txtCapturador.Name = "txtCapturador";
            this.txtCapturador.Size = new System.Drawing.Size(253, 20);
            this.txtCapturador.TabIndex = 8;
            // 
            // lblTipoOrden
            // 
            this.lblTipoOrden.AutoSize = true;
            this.lblTipoOrden.Location = new System.Drawing.Point(25, 138);
            this.lblTipoOrden.Name = "lblTipoOrden";
            this.lblTipoOrden.Size = new System.Drawing.Size(75, 13);
            this.lblTipoOrden.TabIndex = 56;
            this.lblTipoOrden.Text = "Tipo de Orden";
            // 
            // cmbTipoOrdenes
            // 
            this.cmbTipoOrdenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoOrdenes.FormattingEnabled = true;
            this.cmbTipoOrdenes.Location = new System.Drawing.Point(106, 135);
            this.cmbTipoOrdenes.Name = "cmbTipoOrdenes";
            this.cmbTipoOrdenes.Size = new System.Drawing.Size(253, 21);
            this.cmbTipoOrdenes.TabIndex = 5;
            // 
            // lblNoContrato
            // 
            this.lblNoContrato.AutoSize = true;
            this.lblNoContrato.Location = new System.Drawing.Point(33, 18);
            this.lblNoContrato.Name = "lblNoContrato";
            this.lblNoContrato.Size = new System.Drawing.Size(67, 13);
            this.lblNoContrato.TabIndex = 52;
            this.lblNoContrato.Text = "No. Contrato";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(212, 113);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(30, 13);
            this.lblHora.TabIndex = 55;
            this.lblHora.Text = "Hora";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(63, 113);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 53;
            this.lblFecha.Text = "Fecha";
            // 
            // grpDatosContrato
            // 
            this.grpDatosContrato.Controls.Add(this.txtDireccionContrato);
            this.grpDatosContrato.Controls.Add(this.lblDireccionContrato);
            this.grpDatosContrato.Controls.Add(this.txtNombreContratista);
            this.grpDatosContrato.Controls.Add(this.lblNombreContrato);
            this.grpDatosContrato.Location = new System.Drawing.Point(12, 34);
            this.grpDatosContrato.Name = "grpDatosContrato";
            this.grpDatosContrato.Size = new System.Drawing.Size(355, 69);
            this.grpDatosContrato.TabIndex = 2;
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
            // txtNombreContratista
            // 
            this.txtNombreContratista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreContratista.Enabled = false;
            this.txtNombreContratista.Location = new System.Drawing.Point(94, 12);
            this.txtNombreContratista.Name = "txtNombreContratista";
            this.txtNombreContratista.Size = new System.Drawing.Size(253, 20);
            this.txtNombreContratista.TabIndex = 5;
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
            // lblCapturador
            // 
            this.lblCapturador.AutoSize = true;
            this.lblCapturador.Location = new System.Drawing.Point(56, 267);
            this.lblCapturador.Name = "lblCapturador";
            this.lblCapturador.Size = new System.Drawing.Size(44, 13);
            this.lblCapturador.TabIndex = 71;
            this.lblCapturador.Text = "Capturó";
            // 
            // cmbSupervisores
            // 
            this.cmbSupervisores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupervisores.FormattingEnabled = true;
            this.cmbSupervisores.Location = new System.Drawing.Point(106, 236);
            this.cmbSupervisores.Name = "cmbSupervisores";
            this.cmbSupervisores.Size = new System.Drawing.Size(253, 21);
            this.cmbSupervisores.TabIndex = 7;
            // 
            // DlgOrdenTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(379, 337);
            this.Controls.Add(this.cmbSupervisores);
            this.Controls.Add(this.lblCapturador);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.mtxtNoContrato);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblComentarios);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblTelefonoContacto);
            this.Controls.Add(this.txtCapturador);
            this.Controls.Add(this.lblTipoOrden);
            this.Controls.Add(this.cmbTipoOrdenes);
            this.Controls.Add(this.lblNoContrato);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.grpDatosContrato);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgOrdenTrabajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden de Trabajo";
            this.Load += new System.EventHandler(this.DlgOrdenTrabajo_Load);
            this.grpDatosContrato.ResumeLayout(false);
            this.grpDatosContrato.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.MaskedTextBox mtxtNoContrato;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblComentarios;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblTelefonoContacto;
        private System.Windows.Forms.TextBox txtCapturador;
        private System.Windows.Forms.Label lblTipoOrden;
        private System.Windows.Forms.ComboBox cmbTipoOrdenes;
        private System.Windows.Forms.Label lblNoContrato;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox grpDatosContrato;
        private System.Windows.Forms.TextBox txtDireccionContrato;
        private System.Windows.Forms.Label lblDireccionContrato;
        private System.Windows.Forms.TextBox txtNombreContratista;
        private System.Windows.Forms.Label lblNombreContrato;
        private System.Windows.Forms.Label lblCapturador;
        private System.Windows.Forms.ComboBox cmbSupervisores;
    }
}
