namespace SAPA.Vistas.Dialogos
{
    partial class DlgPagoCompletar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgPagoCompletar));
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.lblNotaFolio = new System.Windows.Forms.Label();
            this.lblFolioInterno = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.txtFolioInterno = new System.Windows.Forms.TextBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.cmbBanco = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.grpPago = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grpPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.Location = new System.Drawing.Point(23, 151);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(116, 20);
            this.lblTotalPagar.TabIndex = 28;
            this.lblTotalPagar.Text = "Total a Pagar";
            // 
            // lblNotaFolio
            // 
            this.lblNotaFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotaFolio.Location = new System.Drawing.Point(6, 43);
            this.lblNotaFolio.Name = "lblNotaFolio";
            this.lblNotaFolio.Size = new System.Drawing.Size(243, 35);
            this.lblNotaFolio.TabIndex = 29;
            this.lblNotaFolio.Text = "* El folio guardado puede ser diferente al mostrado";
            this.lblNotaFolio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFolioInterno
            // 
            this.lblFolioInterno.AutoSize = true;
            this.lblFolioInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioInterno.Location = new System.Drawing.Point(11, 78);
            this.lblFolioInterno.Name = "lblFolioInterno";
            this.lblFolioInterno.Size = new System.Drawing.Size(111, 20);
            this.lblFolioInterno.TabIndex = 30;
            this.lblFolioInterno.Text = "Folio Interno";
            // 
            // lblFolio
            // 
            this.lblFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolio.Location = new System.Drawing.Point(11, 17);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(111, 20);
            this.lblFolio.TabIndex = 31;
            this.lblFolio.Text = "Folio";
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Location = new System.Drawing.Point(145, 151);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.ReadOnly = true;
            this.txtTotalPagar.Size = new System.Drawing.Size(126, 20);
            this.txtTotalPagar.TabIndex = 2;
            this.txtTotalPagar.Text = "0.00";
            // 
            // txtFolioInterno
            // 
            this.txtFolioInterno.Location = new System.Drawing.Point(128, 78);
            this.txtFolioInterno.Name = "txtFolioInterno";
            this.txtFolioInterno.Size = new System.Drawing.Size(126, 20);
            this.txtFolioInterno.TabIndex = 1;
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(128, 17);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.ReadOnly = true;
            this.txtFolio.Size = new System.Drawing.Size(126, 20);
            this.txtFolio.TabIndex = 0;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPago.Location = new System.Drawing.Point(8, 175);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(131, 20);
            this.lblFormaPago.TabIndex = 28;
            this.lblFormaPago.Text = "Forma de Pago";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(145, 177);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(126, 21);
            this.cmbFormaPago.TabIndex = 3;
            this.cmbFormaPago.SelectedIndexChanged += new System.EventHandler(this.cmbTipoPago_SelectedIndexChanged);
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(145, 257);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(126, 20);
            this.txtReferencia.TabIndex = 6;
            // 
            // lblReferencia
            // 
            this.lblReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencia.Location = new System.Drawing.Point(32, 257);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(107, 20);
            this.lblReferencia.TabIndex = 30;
            this.lblReferencia.Text = "Referencia";
            this.lblReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.Location = new System.Drawing.Point(79, 231);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(60, 20);
            this.lblBanco.TabIndex = 28;
            this.lblBanco.Text = "Banco";
            // 
            // cmbBanco
            // 
            this.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.Location = new System.Drawing.Point(145, 230);
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(126, 21);
            this.cmbBanco.TabIndex = 5;
            this.cmbBanco.VisibleChanged += new System.EventHandler(this.cmbBanco_VisibleChanged);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(58, 204);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(81, 20);
            this.lblCantidad.TabIndex = 34;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(145, 204);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(126, 20);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.Text = "0.00";
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.Location = new System.Drawing.Point(111, 297);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(69, 20);
            this.lblCambio.TabIndex = 28;
            this.lblCambio.Text = "Cambio";
            // 
            // txtCambio
            // 
            this.txtCambio.Location = new System.Drawing.Point(186, 297);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.Size = new System.Drawing.Size(85, 20);
            this.txtCambio.TabIndex = 7;
            this.txtCambio.Text = "0.00";
            // 
            // grpPago
            // 
            this.grpPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpPago.Controls.Add(this.lblFolio);
            this.grpPago.Controls.Add(this.txtFolio);
            this.grpPago.Controls.Add(this.lblNotaFolio);
            this.grpPago.Controls.Add(this.lblFolioInterno);
            this.grpPago.Controls.Add(this.txtFolioInterno);
            this.grpPago.Controls.Add(this.lblTotalPagar);
            this.grpPago.Controls.Add(this.txtTotalPagar);
            this.grpPago.Controls.Add(this.lblFormaPago);
            this.grpPago.Controls.Add(this.cmbFormaPago);
            this.grpPago.Controls.Add(this.lblCantidad);
            this.grpPago.Controls.Add(this.txtCantidad);
            this.grpPago.Controls.Add(this.lblBanco);
            this.grpPago.Controls.Add(this.cmbBanco);
            this.grpPago.Controls.Add(this.lblReferencia);
            this.grpPago.Controls.Add(this.txtReferencia);
            this.grpPago.Controls.Add(this.lblCambio);
            this.grpPago.Controls.Add(this.txtCambio);
            this.grpPago.Location = new System.Drawing.Point(12, 12);
            this.grpPago.Name = "grpPago";
            this.grpPago.Size = new System.Drawing.Size(285, 319);
            this.grpPago.TabIndex = 0;
            this.grpPago.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(198, 337);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 34);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // DlgPagoCompletar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(308, 383);
            this.Controls.Add(this.grpPago);
            this.Controls.Add(this.btnAceptar);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgPagoCompletar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago";
            this.Load += new System.EventHandler(this.DlgPagoCompletar_Load);
            this.grpPago.ResumeLayout(false);
            this.grpPago.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label lblNotaFolio;
        private System.Windows.Forms.Label lblFolioInterno;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.TextBox txtFolioInterno;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.ComboBox cmbBanco;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.GroupBox grpPago;
        private System.Windows.Forms.Button btnAceptar;
    }
}
