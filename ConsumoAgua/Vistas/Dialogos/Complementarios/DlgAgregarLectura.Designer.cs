namespace SAPA.Vistas.Dialogos.Complementarios
{
    partial class DlgAgregarLectura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAgregarLectura));
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblLecturista = new System.Windows.Forms.Label();
            this.cmbLecturistas = new System.Windows.Forms.ComboBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.grpMediciones = new System.Windows.Forms.GroupBox();
            this.chkReiniciarLecturas = new System.Windows.Forms.CheckBox();
            this.txtDescripcionAnomalia = new System.Windows.Forms.TextBox();
            this.chkTieneAnomalia = new System.Windows.Forms.CheckBox();
            this.txtLecturaActual = new System.Windows.Forms.TextBox();
            this.lblMedicionActual = new System.Windows.Forms.Label();
            this.txtNoContrato = new System.Windows.Forms.TextBox();
            this.lblNoContrato = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblLecturaAnterior = new System.Windows.Forms.Label();
            this.txtLecturaAnterior = new System.Windows.Forms.TextBox();
            this.txtLitrosConsumidos = new System.Windows.Forms.TextBox();
            this.lblLitrosConsumidos = new System.Windows.Forms.Label();
            this.grpMediciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(95, 39);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(95, 20);
            this.dtpFecha.TabIndex = 57;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // dtpHora
            // 
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(237, 39);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(93, 20);
            this.dtpHora.TabIndex = 58;
            this.dtpHora.ValueChanged += new System.EventHandler(this.dtpHora_ValueChanged);
            // 
            // lblLecturista
            // 
            this.lblLecturista.AutoSize = true;
            this.lblLecturista.Location = new System.Drawing.Point(36, 68);
            this.lblLecturista.Name = "lblLecturista";
            this.lblLecturista.Size = new System.Drawing.Size(53, 13);
            this.lblLecturista.TabIndex = 62;
            this.lblLecturista.Text = "Lecturista";
            // 
            // cmbLecturistas
            // 
            this.cmbLecturistas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLecturistas.FormattingEnabled = true;
            this.cmbLecturistas.Location = new System.Drawing.Point(95, 65);
            this.cmbLecturistas.Name = "cmbLecturistas";
            this.cmbLecturistas.Size = new System.Drawing.Size(253, 21);
            this.cmbLecturistas.TabIndex = 59;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(201, 43);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(30, 13);
            this.lblHora.TabIndex = 61;
            this.lblHora.Text = "Hora";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(52, 43);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 60;
            this.lblFecha.Text = "Fecha";
            // 
            // grpMediciones
            // 
            this.grpMediciones.Controls.Add(this.chkReiniciarLecturas);
            this.grpMediciones.Controls.Add(this.txtDescripcionAnomalia);
            this.grpMediciones.Controls.Add(this.chkTieneAnomalia);
            this.grpMediciones.Controls.Add(this.txtLecturaActual);
            this.grpMediciones.Controls.Add(this.lblMedicionActual);
            this.grpMediciones.Controls.Add(this.txtNoContrato);
            this.grpMediciones.Controls.Add(this.lblNoContrato);
            this.grpMediciones.Controls.Add(this.dtpFecha);
            this.grpMediciones.Controls.Add(this.cmbLecturistas);
            this.grpMediciones.Controls.Add(this.dtpHora);
            this.grpMediciones.Controls.Add(this.lblFecha);
            this.grpMediciones.Controls.Add(this.lblLecturista);
            this.grpMediciones.Controls.Add(this.lblHora);
            this.grpMediciones.Location = new System.Drawing.Point(12, 12);
            this.grpMediciones.Name = "grpMediciones";
            this.grpMediciones.Size = new System.Drawing.Size(407, 172);
            this.grpMediciones.TabIndex = 63;
            this.grpMediciones.TabStop = false;
            // 
            // chkReiniciarLecturas
            // 
            this.chkReiniciarLecturas.AutoSize = true;
            this.chkReiniciarLecturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReiniciarLecturas.Location = new System.Drawing.Point(228, 118);
            this.chkReiniciarLecturas.Name = "chkReiniciarLecturas";
            this.chkReiniciarLecturas.Size = new System.Drawing.Size(129, 17);
            this.chkReiniciarLecturas.TabIndex = 67;
            this.chkReiniciarLecturas.Text = "Reiniciar Lecturas";
            this.chkReiniciarLecturas.UseVisualStyleBackColor = true;
            this.chkReiniciarLecturas.CheckedChanged += new System.EventHandler(this.chkReiniciarLecturas_CheckedChanged);
            // 
            // txtDescripcionAnomalia
            // 
            this.txtDescripcionAnomalia.Location = new System.Drawing.Point(95, 141);
            this.txtDescripcionAnomalia.Name = "txtDescripcionAnomalia";
            this.txtDescripcionAnomalia.Size = new System.Drawing.Size(306, 20);
            this.txtDescripcionAnomalia.TabIndex = 66;
            this.txtDescripcionAnomalia.Visible = false;
            // 
            // chkTieneAnomalia
            // 
            this.chkTieneAnomalia.AutoSize = true;
            this.chkTieneAnomalia.Location = new System.Drawing.Point(95, 118);
            this.chkTieneAnomalia.Name = "chkTieneAnomalia";
            this.chkTieneAnomalia.Size = new System.Drawing.Size(127, 17);
            this.chkTieneAnomalia.TabIndex = 65;
            this.chkTieneAnomalia.Text = "¿Presenta anomalía?";
            this.chkTieneAnomalia.UseVisualStyleBackColor = true;
            this.chkTieneAnomalia.CheckedChanged += new System.EventHandler(this.chkTieneAnomalia_CheckedChanged);
            // 
            // txtLecturaActual
            // 
            this.txtLecturaActual.Location = new System.Drawing.Point(95, 92);
            this.txtLecturaActual.Name = "txtLecturaActual";
            this.txtLecturaActual.Size = new System.Drawing.Size(100, 20);
            this.txtLecturaActual.TabIndex = 64;
            this.txtLecturaActual.Text = "0.00";
            this.txtLecturaActual.TextChanged += new System.EventHandler(this.txtLecturaActual_TextChanged);
            this.txtLecturaActual.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLecturaActual_KeyDown);
            this.txtLecturaActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLecturaActual_KeyPress);
            // 
            // lblMedicionActual
            // 
            this.lblMedicionActual.AutoSize = true;
            this.lblMedicionActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicionActual.Location = new System.Drawing.Point(13, 96);
            this.lblMedicionActual.Name = "lblMedicionActual";
            this.lblMedicionActual.Size = new System.Drawing.Size(76, 13);
            this.lblMedicionActual.TabIndex = 63;
            this.lblMedicionActual.Text = "Lect. Actual";
            // 
            // txtNoContrato
            // 
            this.txtNoContrato.Enabled = false;
            this.txtNoContrato.Location = new System.Drawing.Point(95, 13);
            this.txtNoContrato.Name = "txtNoContrato";
            this.txtNoContrato.ReadOnly = true;
            this.txtNoContrato.Size = new System.Drawing.Size(100, 20);
            this.txtNoContrato.TabIndex = 64;
            // 
            // lblNoContrato
            // 
            this.lblNoContrato.AutoSize = true;
            this.lblNoContrato.Location = new System.Drawing.Point(22, 17);
            this.lblNoContrato.Name = "lblNoContrato";
            this.lblNoContrato.Size = new System.Drawing.Size(67, 13);
            this.lblNoContrato.TabIndex = 63;
            this.lblNoContrato.Text = "No. Contrato";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(344, 242);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(263, 242);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 66;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblLecturaAnterior
            // 
            this.lblLecturaAnterior.AutoSize = true;
            this.lblLecturaAnterior.Location = new System.Drawing.Point(197, 193);
            this.lblLecturaAnterior.Name = "lblLecturaAnterior";
            this.lblLecturaAnterior.Size = new System.Drawing.Size(116, 13);
            this.lblLecturaAnterior.TabIndex = 68;
            this.lblLecturaAnterior.Text = "LECTURA ANTERIOR";
            // 
            // txtLecturaAnterior
            // 
            this.txtLecturaAnterior.Enabled = false;
            this.txtLecturaAnterior.Location = new System.Drawing.Point(319, 190);
            this.txtLecturaAnterior.Name = "txtLecturaAnterior";
            this.txtLecturaAnterior.ReadOnly = true;
            this.txtLecturaAnterior.Size = new System.Drawing.Size(100, 20);
            this.txtLecturaAnterior.TabIndex = 69;
            // 
            // txtLitrosConsumidos
            // 
            this.txtLitrosConsumidos.Enabled = false;
            this.txtLitrosConsumidos.Location = new System.Drawing.Point(319, 216);
            this.txtLitrosConsumidos.Name = "txtLitrosConsumidos";
            this.txtLitrosConsumidos.ReadOnly = true;
            this.txtLitrosConsumidos.Size = new System.Drawing.Size(100, 20);
            this.txtLitrosConsumidos.TabIndex = 69;
            // 
            // lblLitrosConsumidos
            // 
            this.lblLitrosConsumidos.AutoSize = true;
            this.lblLitrosConsumidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLitrosConsumidos.Location = new System.Drawing.Point(174, 220);
            this.lblLitrosConsumidos.Name = "lblLitrosConsumidos";
            this.lblLitrosConsumidos.Size = new System.Drawing.Size(139, 13);
            this.lblLitrosConsumidos.TabIndex = 68;
            this.lblLitrosConsumidos.Text = "LITROS CONSUMIDOS";
            // 
            // DlgAgregarLectura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(431, 302);
            this.Controls.Add(this.grpMediciones);
            this.Controls.Add(this.lblLecturaAnterior);
            this.Controls.Add(this.txtLecturaAnterior);
            this.Controls.Add(this.lblLitrosConsumidos);
            this.Controls.Add(this.txtLitrosConsumidos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgAgregarLectura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Lectura";
            this.Load += new System.EventHandler(this.DlgAgregarLectura_Load);
            this.Shown += new System.EventHandler(this.DlgAgregarLectura_Shown);
            this.grpMediciones.ResumeLayout(false);
            this.grpMediciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label lblLecturista;
        private System.Windows.Forms.ComboBox cmbLecturistas;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox grpMediciones;
        private System.Windows.Forms.TextBox txtDescripcionAnomalia;
        private System.Windows.Forms.CheckBox chkTieneAnomalia;
        private System.Windows.Forms.TextBox txtLecturaActual;
        private System.Windows.Forms.Label lblMedicionActual;
        private System.Windows.Forms.TextBox txtNoContrato;
        private System.Windows.Forms.Label lblNoContrato;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblLecturaAnterior;
        private System.Windows.Forms.TextBox txtLecturaAnterior;
        private System.Windows.Forms.TextBox txtLitrosConsumidos;
        private System.Windows.Forms.Label lblLitrosConsumidos;
        private System.Windows.Forms.CheckBox chkReiniciarLecturas;
    }
}
