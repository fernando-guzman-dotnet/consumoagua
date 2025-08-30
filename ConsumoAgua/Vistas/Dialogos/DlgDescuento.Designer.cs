namespace SAPA.Vistas.Dialogos
{
    partial class DlgDescuento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgDescuento));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.grpPorcentajes = new System.Windows.Forms.GroupBox();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.lblIVA = new System.Windows.Forms.Label();
            this.txtGastosEjecucion = new System.Windows.Forms.TextBox();
            this.lblGastosEjecucion = new System.Windows.Forms.Label();
            this.txtMultas = new System.Windows.Forms.TextBox();
            this.lblMultas = new System.Windows.Forms.Label();
            this.txtRecargos = new System.Windows.Forms.TextBox();
            this.lblRecargos = new System.Windows.Forms.Label();
            this.txtSaneamiento = new System.Windows.Forms.TextBox();
            this.lblSaneamiento = new System.Windows.Forms.Label();
            this.txtAlcantarillado = new System.Windows.Forms.TextBox();
            this.lblAlcantarillado = new System.Windows.Forms.Label();
            this.txtAgua = new System.Windows.Forms.TextBox();
            this.lblAgua = new System.Windows.Forms.Label();
            this.cmbTiposDescuento = new System.Windows.Forms.ComboBox();
            this.lblTipoDescuento = new System.Windows.Forms.Label();
            this.grpDatos.SuspendLayout();
            this.grpPorcentajes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(273, 345);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(192, 345);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.grpPorcentajes);
            this.grpDatos.Controls.Add(this.cmbTiposDescuento);
            this.grpDatos.Controls.Add(this.lblTipoDescuento);
            this.grpDatos.Location = new System.Drawing.Point(12, 12);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(336, 327);
            this.grpDatos.TabIndex = 4;
            this.grpDatos.TabStop = false;
            // 
            // grpPorcentajes
            // 
            this.grpPorcentajes.Controls.Add(this.txtIVA);
            this.grpPorcentajes.Controls.Add(this.lblIVA);
            this.grpPorcentajes.Controls.Add(this.txtGastosEjecucion);
            this.grpPorcentajes.Controls.Add(this.lblGastosEjecucion);
            this.grpPorcentajes.Controls.Add(this.txtMultas);
            this.grpPorcentajes.Controls.Add(this.lblMultas);
            this.grpPorcentajes.Controls.Add(this.txtRecargos);
            this.grpPorcentajes.Controls.Add(this.lblRecargos);
            this.grpPorcentajes.Controls.Add(this.txtSaneamiento);
            this.grpPorcentajes.Controls.Add(this.lblSaneamiento);
            this.grpPorcentajes.Controls.Add(this.txtAlcantarillado);
            this.grpPorcentajes.Controls.Add(this.lblAlcantarillado);
            this.grpPorcentajes.Controls.Add(this.txtAgua);
            this.grpPorcentajes.Controls.Add(this.lblAgua);
            this.grpPorcentajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPorcentajes.Location = new System.Drawing.Point(110, 59);
            this.grpPorcentajes.Name = "grpPorcentajes";
            this.grpPorcentajes.Size = new System.Drawing.Size(209, 222);
            this.grpPorcentajes.TabIndex = 4;
            this.grpPorcentajes.TabStop = false;
            this.grpPorcentajes.Text = "PORCENTAJES";
            // 
            // txtIVA
            // 
            this.txtIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(102, 187);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ShortcutsEnabled = false;
            this.txtIVA.Size = new System.Drawing.Size(78, 20);
            this.txtIVA.TabIndex = 13;
            this.txtIVA.Text = "0.00";
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIVA.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtIVA.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtIVA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtIVA.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA.Location = new System.Drawing.Point(72, 190);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(24, 13);
            this.lblIVA.TabIndex = 12;
            this.lblIVA.Text = "IVA";
            // 
            // txtGastosEjecucion
            // 
            this.txtGastosEjecucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastosEjecucion.Location = new System.Drawing.Point(102, 161);
            this.txtGastosEjecucion.Name = "txtGastosEjecucion";
            this.txtGastosEjecucion.ShortcutsEnabled = false;
            this.txtGastosEjecucion.Size = new System.Drawing.Size(78, 20);
            this.txtGastosEjecucion.TabIndex = 11;
            this.txtGastosEjecucion.Text = "0.00";
            this.txtGastosEjecucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGastosEjecucion.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtGastosEjecucion.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtGastosEjecucion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtGastosEjecucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtGastosEjecucion.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblGastosEjecucion
            // 
            this.lblGastosEjecucion.AutoSize = true;
            this.lblGastosEjecucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGastosEjecucion.Location = new System.Drawing.Point(6, 164);
            this.lblGastosEjecucion.Name = "lblGastosEjecucion";
            this.lblGastosEjecucion.Size = new System.Drawing.Size(90, 13);
            this.lblGastosEjecucion.TabIndex = 10;
            this.lblGastosEjecucion.Text = "Gastos Ejecucion";
            // 
            // txtMultas
            // 
            this.txtMultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMultas.Location = new System.Drawing.Point(102, 135);
            this.txtMultas.Name = "txtMultas";
            this.txtMultas.ShortcutsEnabled = false;
            this.txtMultas.Size = new System.Drawing.Size(78, 20);
            this.txtMultas.TabIndex = 9;
            this.txtMultas.Text = "0.00";
            this.txtMultas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMultas.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtMultas.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtMultas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtMultas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtMultas.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblMultas
            // 
            this.lblMultas.AutoSize = true;
            this.lblMultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultas.Location = new System.Drawing.Point(58, 138);
            this.lblMultas.Name = "lblMultas";
            this.lblMultas.Size = new System.Drawing.Size(38, 13);
            this.lblMultas.TabIndex = 8;
            this.lblMultas.Text = "Multas";
            // 
            // txtRecargos
            // 
            this.txtRecargos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecargos.Location = new System.Drawing.Point(102, 109);
            this.txtRecargos.Name = "txtRecargos";
            this.txtRecargos.ShortcutsEnabled = false;
            this.txtRecargos.Size = new System.Drawing.Size(78, 20);
            this.txtRecargos.TabIndex = 7;
            this.txtRecargos.Text = "0.00";
            this.txtRecargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecargos.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtRecargos.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtRecargos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtRecargos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtRecargos.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblRecargos
            // 
            this.lblRecargos.AutoSize = true;
            this.lblRecargos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecargos.Location = new System.Drawing.Point(43, 112);
            this.lblRecargos.Name = "lblRecargos";
            this.lblRecargos.Size = new System.Drawing.Size(53, 13);
            this.lblRecargos.TabIndex = 6;
            this.lblRecargos.Text = "Recargos";
            // 
            // txtSaneamiento
            // 
            this.txtSaneamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaneamiento.Location = new System.Drawing.Point(102, 83);
            this.txtSaneamiento.Name = "txtSaneamiento";
            this.txtSaneamiento.ShortcutsEnabled = false;
            this.txtSaneamiento.Size = new System.Drawing.Size(78, 20);
            this.txtSaneamiento.TabIndex = 5;
            this.txtSaneamiento.Text = "0.00";
            this.txtSaneamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSaneamiento.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtSaneamiento.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtSaneamiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtSaneamiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtSaneamiento.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblSaneamiento
            // 
            this.lblSaneamiento.AutoSize = true;
            this.lblSaneamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaneamiento.Location = new System.Drawing.Point(27, 87);
            this.lblSaneamiento.Name = "lblSaneamiento";
            this.lblSaneamiento.Size = new System.Drawing.Size(69, 13);
            this.lblSaneamiento.TabIndex = 4;
            this.lblSaneamiento.Text = "Saneamiento";
            // 
            // txtAlcantarillado
            // 
            this.txtAlcantarillado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlcantarillado.Location = new System.Drawing.Point(102, 57);
            this.txtAlcantarillado.Name = "txtAlcantarillado";
            this.txtAlcantarillado.ShortcutsEnabled = false;
            this.txtAlcantarillado.Size = new System.Drawing.Size(78, 20);
            this.txtAlcantarillado.TabIndex = 3;
            this.txtAlcantarillado.Text = "0.00";
            this.txtAlcantarillado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAlcantarillado.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtAlcantarillado.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtAlcantarillado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtAlcantarillado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtAlcantarillado.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblAlcantarillado
            // 
            this.lblAlcantarillado.AutoSize = true;
            this.lblAlcantarillado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlcantarillado.Location = new System.Drawing.Point(26, 61);
            this.lblAlcantarillado.Name = "lblAlcantarillado";
            this.lblAlcantarillado.Size = new System.Drawing.Size(70, 13);
            this.lblAlcantarillado.TabIndex = 2;
            this.lblAlcantarillado.Text = "Alcantarillado";
            // 
            // txtAgua
            // 
            this.txtAgua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgua.Location = new System.Drawing.Point(102, 31);
            this.txtAgua.Name = "txtAgua";
            this.txtAgua.ShortcutsEnabled = false;
            this.txtAgua.Size = new System.Drawing.Size(78, 20);
            this.txtAgua.TabIndex = 1;
            this.txtAgua.Text = "0.00";
            this.txtAgua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAgua.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtAgua.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtAgua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtAgua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtAgua.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblAgua
            // 
            this.lblAgua.AutoSize = true;
            this.lblAgua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgua.Location = new System.Drawing.Point(64, 35);
            this.lblAgua.Name = "lblAgua";
            this.lblAgua.Size = new System.Drawing.Size(32, 13);
            this.lblAgua.TabIndex = 0;
            this.lblAgua.Text = "Agua";
            // 
            // cmbTiposDescuento
            // 
            this.cmbTiposDescuento.FormattingEnabled = true;
            this.cmbTiposDescuento.Location = new System.Drawing.Point(110, 13);
            this.cmbTiposDescuento.Name = "cmbTiposDescuento";
            this.cmbTiposDescuento.Size = new System.Drawing.Size(209, 21);
            this.cmbTiposDescuento.TabIndex = 1;
            // 
            // lblTipoDescuento
            // 
            this.lblTipoDescuento.AutoSize = true;
            this.lblTipoDescuento.Location = new System.Drawing.Point(6, 16);
            this.lblTipoDescuento.Name = "lblTipoDescuento";
            this.lblTipoDescuento.Size = new System.Drawing.Size(98, 13);
            this.lblTipoDescuento.TabIndex = 0;
            this.lblTipoDescuento.Text = "Tipo de Descuento";
            // 
            // DlgDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(360, 397);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgDescuento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descuento";
            this.Load += new System.EventHandler(this.DlgDescuento_Load);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.grpPorcentajes.ResumeLayout(false);
            this.grpPorcentajes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.GroupBox grpPorcentajes;
        private System.Windows.Forms.TextBox txtSaneamiento;
        private System.Windows.Forms.Label lblSaneamiento;
        private System.Windows.Forms.TextBox txtAlcantarillado;
        private System.Windows.Forms.Label lblAlcantarillado;
        private System.Windows.Forms.TextBox txtAgua;
        private System.Windows.Forms.Label lblAgua;
        private System.Windows.Forms.ComboBox cmbTiposDescuento;
        private System.Windows.Forms.Label lblTipoDescuento;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.TextBox txtGastosEjecucion;
        private System.Windows.Forms.Label lblGastosEjecucion;
        private System.Windows.Forms.TextBox txtMultas;
        private System.Windows.Forms.Label lblMultas;
        private System.Windows.Forms.TextBox txtRecargos;
        private System.Windows.Forms.Label lblRecargos;
    }
}
