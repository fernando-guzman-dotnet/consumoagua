namespace SAPA.Vistas.Dialogos.Complementarios
{
    partial class DlgAplicarDescuentoMasivamente
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
            this.grpColoniaCalle = new System.Windows.Forms.GroupBox();
            this.lblCalle = new System.Windows.Forms.Label();
            this.cmbCalle = new System.Windows.Forms.ComboBox();
            this.lblColonia = new System.Windows.Forms.Label();
            this.cmbColonia = new System.Windows.Forms.ComboBox();
            this.grpDescuento = new System.Windows.Forms.GroupBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblTipoOrden = new System.Windows.Forms.Label();
            this.cmbDescuentos = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grpColoniaCalle.SuspendLayout();
            this.grpDescuento.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpColoniaCalle
            // 
            this.grpColoniaCalle.Controls.Add(this.lblCalle);
            this.grpColoniaCalle.Controls.Add(this.cmbCalle);
            this.grpColoniaCalle.Controls.Add(this.lblColonia);
            this.grpColoniaCalle.Controls.Add(this.cmbColonia);
            this.grpColoniaCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpColoniaCalle.Location = new System.Drawing.Point(12, 12);
            this.grpColoniaCalle.Name = "grpColoniaCalle";
            this.grpColoniaCalle.Size = new System.Drawing.Size(355, 106);
            this.grpColoniaCalle.TabIndex = 5;
            this.grpColoniaCalle.TabStop = false;
            this.grpColoniaCalle.Text = "APLICAR POR COLONIA Y CALLE";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCalle.Location = new System.Drawing.Point(25, 64);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(30, 13);
            this.lblCalle.TabIndex = 3;
            this.lblCalle.Text = "Calle";
            // 
            // cmbCalle
            // 
            this.cmbCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbCalle.FormattingEnabled = true;
            this.cmbCalle.Location = new System.Drawing.Point(61, 61);
            this.cmbCalle.Name = "cmbCalle";
            this.cmbCalle.Size = new System.Drawing.Size(219, 21);
            this.cmbCalle.TabIndex = 2;
            // 
            // lblColonia
            // 
            this.lblColonia.AutoSize = true;
            this.lblColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblColonia.Location = new System.Drawing.Point(13, 37);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(42, 13);
            this.lblColonia.TabIndex = 1;
            this.lblColonia.Text = "Colonia";
            // 
            // cmbColonia
            // 
            this.cmbColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbColonia.FormattingEnabled = true;
            this.cmbColonia.Location = new System.Drawing.Point(61, 34);
            this.cmbColonia.Name = "cmbColonia";
            this.cmbColonia.Size = new System.Drawing.Size(219, 21);
            this.cmbColonia.TabIndex = 0;
            this.cmbColonia.SelectedIndexChanged += new System.EventHandler(this.cmbColonia_SelectedIndexChanged);
            // 
            // grpDescuento
            // 
            this.grpDescuento.Controls.Add(this.dtpFechaFin);
            this.grpDescuento.Controls.Add(this.dtpFechaInicio);
            this.grpDescuento.Controls.Add(this.lblFechaInicio);
            this.grpDescuento.Controls.Add(this.lblFechaFin);
            this.grpDescuento.Controls.Add(this.lblTipoOrden);
            this.grpDescuento.Controls.Add(this.cmbDescuentos);
            this.grpDescuento.Location = new System.Drawing.Point(12, 124);
            this.grpDescuento.Name = "grpDescuento";
            this.grpDescuento.Size = new System.Drawing.Size(355, 75);
            this.grpDescuento.TabIndex = 59;
            this.grpDescuento.TabStop = false;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(229, 40);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(84, 40);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaInicio.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(55, 44);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(23, 13);
            this.lblFechaInicio.TabIndex = 53;
            this.lblFechaInicio.Text = "Del";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(207, 44);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(16, 13);
            this.lblFechaFin.TabIndex = 53;
            this.lblFechaFin.Text = "Al";
            // 
            // lblTipoOrden
            // 
            this.lblTipoOrden.AutoSize = true;
            this.lblTipoOrden.Location = new System.Drawing.Point(19, 16);
            this.lblTipoOrden.Name = "lblTipoOrden";
            this.lblTipoOrden.Size = new System.Drawing.Size(59, 13);
            this.lblTipoOrden.TabIndex = 56;
            this.lblTipoOrden.Text = "Descuento";
            // 
            // cmbDescuentos
            // 
            this.cmbDescuentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDescuentos.FormattingEnabled = true;
            this.cmbDescuentos.Location = new System.Drawing.Point(84, 13);
            this.cmbDescuentos.Name = "cmbDescuentos";
            this.cmbDescuentos.Size = new System.Drawing.Size(253, 21);
            this.cmbDescuentos.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(292, 205);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 61;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(211, 205);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 60;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // DlgAplicarDescuentoMasivamente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(379, 262);
            this.Controls.Add(this.grpColoniaCalle);
            this.Controls.Add(this.grpDescuento);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DlgAplicarDescuentoMasivamente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicar Descuento Masivamente";
            this.Load += new System.EventHandler(this.DlgAplicarDescuentoMasivamente_Load);
            this.grpColoniaCalle.ResumeLayout(false);
            this.grpColoniaCalle.PerformLayout();
            this.grpDescuento.ResumeLayout(false);
            this.grpDescuento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpColoniaCalle;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.ComboBox cmbCalle;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.ComboBox cmbColonia;
        private System.Windows.Forms.GroupBox grpDescuento;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblTipoOrden;
        private System.Windows.Forms.ComboBox cmbDescuentos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}
