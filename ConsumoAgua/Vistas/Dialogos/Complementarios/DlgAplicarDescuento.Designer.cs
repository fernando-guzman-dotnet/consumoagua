namespace SAPA.Vistas.Dialogos.Complementarios
{
    partial class DlgAplicarDescuento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAplicarDescuento));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.mtxtNoContrato = new System.Windows.Forms.MaskedTextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTipoOrden = new System.Windows.Forms.Label();
            this.cmbDescuentos = new System.Windows.Forms.ComboBox();
            this.lblNoContrato = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(292, 120);
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
            this.btnAceptar.Location = new System.Drawing.Point(236, 120);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(79, 67);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaInicio.TabIndex = 3;
            // 
            // mtxtNoContrato
            // 
            this.mtxtNoContrato.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.mtxtNoContrato.Location = new System.Drawing.Point(79, 12);
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
            this.btnBuscar.Location = new System.Drawing.Point(152, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblTipoOrden
            // 
            this.lblTipoOrden.AutoSize = true;
            this.lblTipoOrden.Location = new System.Drawing.Point(14, 43);
            this.lblTipoOrden.Name = "lblTipoOrden";
            this.lblTipoOrden.Size = new System.Drawing.Size(59, 13);
            this.lblTipoOrden.TabIndex = 56;
            this.lblTipoOrden.Text = "Descuento";
            // 
            // cmbDescuentos
            // 
            this.cmbDescuentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDescuentos.FormattingEnabled = true;
            this.cmbDescuentos.Location = new System.Drawing.Point(79, 40);
            this.cmbDescuentos.Name = "cmbDescuentos";
            this.cmbDescuentos.Size = new System.Drawing.Size(253, 21);
            this.cmbDescuentos.TabIndex = 5;
            // 
            // lblNoContrato
            // 
            this.lblNoContrato.AutoSize = true;
            this.lblNoContrato.Location = new System.Drawing.Point(6, 16);
            this.lblNoContrato.Name = "lblNoContrato";
            this.lblNoContrato.Size = new System.Drawing.Size(67, 13);
            this.lblNoContrato.TabIndex = 52;
            this.lblNoContrato.Text = "No. Contrato";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(50, 71);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(23, 13);
            this.lblFecha.TabIndex = 53;
            this.lblFecha.Text = "Del";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Al";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(224, 67);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.mtxtNoContrato);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.lblNoContrato);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTipoOrden);
            this.groupBox1.Controls.Add(this.cmbDescuentos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 102);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            // 
            // DlgAplicarDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(379, 172);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgAplicarDescuento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicar Descuento";
            this.Load += new System.EventHandler(this.DlgAplicarDescuento_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.MaskedTextBox mtxtNoContrato;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTipoOrden;
        private System.Windows.Forms.ComboBox cmbDescuentos;
        private System.Windows.Forms.Label lblNoContrato;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
