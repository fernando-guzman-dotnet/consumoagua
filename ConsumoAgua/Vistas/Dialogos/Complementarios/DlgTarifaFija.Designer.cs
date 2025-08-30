namespace SAPA.Vistas.Dialogos.Complementarios
{
    partial class DlgTarifaFija
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgTarifaFija));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtTarifa = new System.Windows.Forms.TextBox();
            this.txtCantidadMensual = new System.Windows.Forms.TextBox();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.lblCuotaMensual = new System.Windows.Forms.Label();
            this.lblCuotaAnual = new System.Windows.Forms.Label();
            this.txtCantidadAnual = new System.Windows.Forms.TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.lblAño = new System.Windows.Forms.Label();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.btnAgregarAño = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(250, 203);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(169, 203);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtTarifa
            // 
            this.txtTarifa.Enabled = false;
            this.txtTarifa.Location = new System.Drawing.Point(58, 27);
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.Size = new System.Drawing.Size(188, 20);
            this.txtTarifa.TabIndex = 0;
            // 
            // txtCantidadMensual
            // 
            this.txtCantidadMensual.Location = new System.Drawing.Point(154, 79);
            this.txtCantidadMensual.Name = "txtCantidadMensual";
            this.txtCantidadMensual.Size = new System.Drawing.Size(92, 20);
            this.txtCantidadMensual.TabIndex = 1;
            // 
            // lblTarifa
            // 
            this.lblTarifa.AutoSize = true;
            this.lblTarifa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarifa.Location = new System.Drawing.Point(12, 30);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Size = new System.Drawing.Size(40, 13);
            this.lblTarifa.TabIndex = 41;
            this.lblTarifa.Text = "Tarifa";
            // 
            // lblCuotaMensual
            // 
            this.lblCuotaMensual.AutoSize = true;
            this.lblCuotaMensual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuotaMensual.Location = new System.Drawing.Point(57, 83);
            this.lblCuotaMensual.Name = "lblCuotaMensual";
            this.lblCuotaMensual.Size = new System.Drawing.Size(91, 13);
            this.lblCuotaMensual.TabIndex = 42;
            this.lblCuotaMensual.Text = "Cuota Mensual";
            // 
            // lblCuotaAnual
            // 
            this.lblCuotaAnual.AutoSize = true;
            this.lblCuotaAnual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuotaAnual.Location = new System.Drawing.Point(72, 109);
            this.lblCuotaAnual.Name = "lblCuotaAnual";
            this.lblCuotaAnual.Size = new System.Drawing.Size(76, 13);
            this.lblCuotaAnual.TabIndex = 42;
            this.lblCuotaAnual.Text = "Cuota Anual";
            // 
            // txtCantidadAnual
            // 
            this.txtCantidadAnual.Location = new System.Drawing.Point(154, 105);
            this.txtCantidadAnual.Name = "txtCantidadAnual";
            this.txtCantidadAnual.Size = new System.Drawing.Size(92, 20);
            this.txtCantidadAnual.TabIndex = 2;
            // 
            // lblNota
            // 
            this.lblNota.Location = new System.Drawing.Point(12, 154);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(313, 46);
            this.lblNota.TabIndex = 47;
            this.lblNota.Text = "* Puede dejarse la cantidad para ambas cuotas en 0.00 para quitar la tarifa fija." +
    "";
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAño.Location = new System.Drawing.Point(22, 57);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(29, 13);
            this.lblAño.TabIndex = 49;
            this.lblAño.Text = "Año";
            // 
            // cmbAño
            // 
            this.cmbAño.DisplayMember = "Año";
            this.cmbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Location = new System.Drawing.Point(57, 53);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(91, 21);
            this.cmbAño.TabIndex = 50;
            this.cmbAño.ValueMember = "Año";
            this.cmbAño.SelectedIndexChanged += new System.EventHandler(this.cmbAño_SelectedIndexChanged);
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(154, 53);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(92, 20);
            this.txtAño.TabIndex = 51;
            this.txtAño.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaPersonalizada_KeyDown);
            this.txtAño.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaPersonalizada_KeyPress);
            // 
            // btnAgregarAño
            // 
            this.btnAgregarAño.Location = new System.Drawing.Point(252, 52);
            this.btnAgregarAño.Name = "btnAgregarAño";
            this.btnAgregarAño.Size = new System.Drawing.Size(73, 23);
            this.btnAgregarAño.TabIndex = 52;
            this.btnAgregarAño.Text = "Agregar";
            this.btnAgregarAño.UseVisualStyleBackColor = true;
            this.btnAgregarAño.Click += new System.EventHandler(this.btnAgregarAño_Click);
            // 
            // DlgTarifaFija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(337, 255);
            this.Controls.Add(this.btnAgregarAño);
            this.Controls.Add(this.txtAño);
            this.Controls.Add(this.cmbAño);
            this.Controls.Add(this.lblAño);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtTarifa);
            this.Controls.Add(this.txtCantidadAnual);
            this.Controls.Add(this.txtCantidadMensual);
            this.Controls.Add(this.lblCuotaAnual);
            this.Controls.Add(this.lblTarifa);
            this.Controls.Add(this.lblCuotaMensual);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DlgTarifaFija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarifa fija";
            this.Load += new System.EventHandler(this.DlgTarifaFija_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtTarifa;
        private System.Windows.Forms.TextBox txtCantidadMensual;
        private System.Windows.Forms.Label lblTarifa;
        private System.Windows.Forms.Label lblCuotaMensual;
        private System.Windows.Forms.Label lblCuotaAnual;
        private System.Windows.Forms.TextBox txtCantidadAnual;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.Button btnAgregarAño;
    }
}
