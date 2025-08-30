namespace SAPA.Vistas.Dialogos
{
    partial class DlgPagoConvenio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgPagoConvenio));
            this.btnPagar = new System.Windows.Forms.Button();
            this.grpPago = new System.Windows.Forms.GroupBox();
            this.grpAbono = new System.Windows.Forms.GroupBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.cmbBanco = new System.Windows.Forms.ComboBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.txtSaldoPendiente = new System.Windows.Forms.TextBox();
            this.txtTotalEstablecido = new System.Windows.Forms.TextBox();
            this.lblSaldoPendiente = new System.Windows.Forms.Label();
            this.lblMontoTotalEstablecido = new System.Windows.Forms.Label();
            this.grpPago.SuspendLayout();
            this.grpAbono.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(215, 228);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(90, 35);
            this.btnPagar.TabIndex = 1;
            this.btnPagar.Text = "PAGAR";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // grpPago
            // 
            this.grpPago.Controls.Add(this.grpAbono);
            this.grpPago.Controls.Add(this.txtSaldoPendiente);
            this.grpPago.Controls.Add(this.txtTotalEstablecido);
            this.grpPago.Controls.Add(this.lblSaldoPendiente);
            this.grpPago.Controls.Add(this.lblMontoTotalEstablecido);
            this.grpPago.Location = new System.Drawing.Point(12, 12);
            this.grpPago.Name = "grpPago";
            this.grpPago.Size = new System.Drawing.Size(293, 210);
            this.grpPago.TabIndex = 0;
            this.grpPago.TabStop = false;
            // 
            // grpAbono
            // 
            this.grpAbono.Controls.Add(this.lblFormaPago);
            this.grpAbono.Controls.Add(this.cmbFormaPago);
            this.grpAbono.Controls.Add(this.lblCantidad);
            this.grpAbono.Controls.Add(this.txtCantidad);
            this.grpAbono.Controls.Add(this.lblBanco);
            this.grpAbono.Controls.Add(this.cmbBanco);
            this.grpAbono.Controls.Add(this.lblReferencia);
            this.grpAbono.Controls.Add(this.txtReferencia);
            this.grpAbono.Location = new System.Drawing.Point(9, 64);
            this.grpAbono.Name = "grpAbono";
            this.grpAbono.Size = new System.Drawing.Size(278, 134);
            this.grpAbono.TabIndex = 0;
            this.grpAbono.TabStop = false;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPago.Location = new System.Drawing.Point(6, 16);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(131, 20);
            this.lblFormaPago.TabIndex = 41;
            this.lblFormaPago.Text = "Forma de Pago";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(143, 18);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(126, 21);
            this.cmbFormaPago.TabIndex = 0;
            this.cmbFormaPago.SelectedIndexChanged += new System.EventHandler(this.cmbTipoPago_SelectedIndexChanged);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(56, 45);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(81, 20);
            this.lblCantidad.TabIndex = 44;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(143, 45);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(126, 20);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.Text = "0.00";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.Location = new System.Drawing.Point(77, 72);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(60, 20);
            this.lblBanco.TabIndex = 42;
            this.lblBanco.Text = "Banco";
            // 
            // cmbBanco
            // 
            this.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.Location = new System.Drawing.Point(143, 71);
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(126, 21);
            this.cmbBanco.TabIndex = 2;
            // 
            // lblReferencia
            // 
            this.lblReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencia.Location = new System.Drawing.Point(30, 98);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(107, 20);
            this.lblReferencia.TabIndex = 43;
            this.lblReferencia.Text = "Referencia";
            this.lblReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(143, 98);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(126, 20);
            this.txtReferencia.TabIndex = 3;
            // 
            // txtSaldoPendiente
            // 
            this.txtSaldoPendiente.Enabled = false;
            this.txtSaldoPendiente.Location = new System.Drawing.Point(152, 38);
            this.txtSaldoPendiente.Name = "txtSaldoPendiente";
            this.txtSaldoPendiente.Size = new System.Drawing.Size(114, 20);
            this.txtSaldoPendiente.TabIndex = 3;
            this.txtSaldoPendiente.Text = "0.00";
            // 
            // txtTotalEstablecido
            // 
            this.txtTotalEstablecido.Enabled = false;
            this.txtTotalEstablecido.Location = new System.Drawing.Point(152, 12);
            this.txtTotalEstablecido.Name = "txtTotalEstablecido";
            this.txtTotalEstablecido.Size = new System.Drawing.Size(114, 20);
            this.txtTotalEstablecido.TabIndex = 2;
            this.txtTotalEstablecido.Text = "0.00";
            // 
            // lblSaldoPendiente
            // 
            this.lblSaldoPendiente.AutoSize = true;
            this.lblSaldoPendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoPendiente.Location = new System.Drawing.Point(47, 42);
            this.lblSaldoPendiente.Name = "lblSaldoPendiente";
            this.lblSaldoPendiente.Size = new System.Drawing.Size(99, 13);
            this.lblSaldoPendiente.TabIndex = 1;
            this.lblSaldoPendiente.Text = "Saldo pendiente";
            // 
            // lblMontoTotalEstablecido
            // 
            this.lblMontoTotalEstablecido.AutoSize = true;
            this.lblMontoTotalEstablecido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotalEstablecido.Location = new System.Drawing.Point(6, 16);
            this.lblMontoTotalEstablecido.Name = "lblMontoTotalEstablecido";
            this.lblMontoTotalEstablecido.Size = new System.Drawing.Size(140, 13);
            this.lblMontoTotalEstablecido.TabIndex = 0;
            this.lblMontoTotalEstablecido.Text = "Monto total establecido";
            // 
            // DlgPagoConvenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(317, 271);
            this.Controls.Add(this.grpPago);
            this.Controls.Add(this.btnPagar);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DlgPagoConvenio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago a Convenio";
            this.Load += new System.EventHandler(this.DlgPagoConvenio_Load);
            this.grpPago.ResumeLayout(false);
            this.grpPago.PerformLayout();
            this.grpAbono.ResumeLayout(false);
            this.grpAbono.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.GroupBox grpPago;
        private System.Windows.Forms.TextBox txtSaldoPendiente;
        private System.Windows.Forms.TextBox txtTotalEstablecido;
        private System.Windows.Forms.Label lblSaldoPendiente;
        private System.Windows.Forms.Label lblMontoTotalEstablecido;
        private System.Windows.Forms.GroupBox grpAbono;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.ComboBox cmbBanco;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtReferencia;
    }
}
