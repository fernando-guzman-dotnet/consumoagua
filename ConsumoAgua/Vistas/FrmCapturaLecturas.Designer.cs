namespace SAPA.Vistas
{
    partial class FrmCapturaLecturas
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
            this.lblNoContrato = new System.Windows.Forms.Label();
            this.btnSeleccionarContrato = new System.Windows.Forms.Button();
            this.grpBuscarContrato = new System.Windows.Forms.GroupBox();
            this.txtNoContrato = new System.Windows.Forms.MaskedTextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.dgvMedidorLecturas = new System.Windows.Forms.DataGridView();
            this.btnAgregarLectura = new System.Windows.Forms.Button();
            this.btnModificarLectura = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.grpBuscarContrato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedidorLecturas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNoContrato
            // 
            this.lblNoContrato.AutoSize = true;
            this.lblNoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoContrato.Location = new System.Drawing.Point(38, 20);
            this.lblNoContrato.Name = "lblNoContrato";
            this.lblNoContrato.Size = new System.Drawing.Size(79, 13);
            this.lblNoContrato.TabIndex = 33;
            this.lblNoContrato.Text = "No. Contrato";
            // 
            // btnSeleccionarContrato
            // 
            this.btnSeleccionarContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarContrato.Location = new System.Drawing.Point(250, 16);
            this.btnSeleccionarContrato.Name = "btnSeleccionarContrato";
            this.btnSeleccionarContrato.Size = new System.Drawing.Size(42, 20);
            this.btnSeleccionarContrato.TabIndex = 29;
            this.btnSeleccionarContrato.Text = ">>>";
            this.btnSeleccionarContrato.UseVisualStyleBackColor = true;
            this.btnSeleccionarContrato.Click += new System.EventHandler(this.btnSeleccionarContrato_Click);
            // 
            // grpBuscarContrato
            // 
            this.grpBuscarContrato.Controls.Add(this.lblNoContrato);
            this.grpBuscarContrato.Controls.Add(this.txtNoContrato);
            this.grpBuscarContrato.Controls.Add(this.btnSeleccionarContrato);
            this.grpBuscarContrato.Controls.Add(this.lblUsuario);
            this.grpBuscarContrato.Controls.Add(this.txtUsuario);
            this.grpBuscarContrato.Controls.Add(this.lblDireccion);
            this.grpBuscarContrato.Controls.Add(this.txtDireccion);
            this.grpBuscarContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBuscarContrato.Location = new System.Drawing.Point(12, 12);
            this.grpBuscarContrato.Name = "grpBuscarContrato";
            this.grpBuscarContrato.Size = new System.Drawing.Size(1025, 111);
            this.grpBuscarContrato.TabIndex = 35;
            this.grpBuscarContrato.TabStop = false;
            this.grpBuscarContrato.Text = "BUSCAR CONTRATO";
            // 
            // txtNoContrato
            // 
            this.txtNoContrato.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.txtNoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNoContrato.Location = new System.Drawing.Point(123, 16);
            this.txtNoContrato.Mask = "0000000000";
            this.txtNoContrato.Name = "txtNoContrato";
            this.txtNoContrato.PromptChar = '0';
            this.txtNoContrato.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNoContrato.ShortcutsEnabled = false;
            this.txtNoContrato.Size = new System.Drawing.Size(119, 20);
            this.txtNoContrato.TabIndex = 35;
            this.txtNoContrato.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.txtNoContrato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoContrato_KeyPress);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(67, 46);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 13);
            this.lblUsuario.TabIndex = 34;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUsuario.Location = new System.Drawing.Point(123, 42);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(465, 20);
            this.txtUsuario.TabIndex = 30;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(56, 72);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(61, 13);
            this.lblDireccion.TabIndex = 32;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDireccion.Location = new System.Drawing.Point(123, 68);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(465, 20);
            this.txtDireccion.TabIndex = 31;
            // 
            // dgvMedidorLecturas
            // 
            this.dgvMedidorLecturas.AllowUserToAddRows = false;
            this.dgvMedidorLecturas.AllowUserToDeleteRows = false;
            this.dgvMedidorLecturas.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedidorLecturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedidorLecturas.Location = new System.Drawing.Point(12, 129);
            this.dgvMedidorLecturas.Name = "dgvMedidorLecturas";
            this.dgvMedidorLecturas.ReadOnly = true;
            this.dgvMedidorLecturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedidorLecturas.Size = new System.Drawing.Size(1070, 451);
            this.dgvMedidorLecturas.TabIndex = 36;
            // 
            // btnAgregarLectura
            // 
            this.btnAgregarLectura.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAgregarLectura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarLectura.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnAgregarLectura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarLectura.Location = new System.Drawing.Point(12, 586);
            this.btnAgregarLectura.Name = "btnAgregarLectura";
            this.btnAgregarLectura.Size = new System.Drawing.Size(183, 46);
            this.btnAgregarLectura.TabIndex = 37;
            this.btnAgregarLectura.Text = "Agregar Lectura";
            this.btnAgregarLectura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarLectura.UseVisualStyleBackColor = true;
            this.btnAgregarLectura.Click += new System.EventHandler(this.btnAgregarLectura_Click);
            // 
            // btnModificarLectura
            // 
            this.btnModificarLectura.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnModificarLectura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarLectura.Image = global::SAPA.Properties.Resources.Editar_33x33;
            this.btnModificarLectura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarLectura.Location = new System.Drawing.Point(201, 586);
            this.btnModificarLectura.Name = "btnModificarLectura";
            this.btnModificarLectura.Size = new System.Drawing.Size(190, 46);
            this.btnModificarLectura.TabIndex = 38;
            this.btnModificarLectura.Text = "Modificar Lectura";
            this.btnModificarLectura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarLectura.UseVisualStyleBackColor = true;
            this.btnModificarLectura.Click += new System.EventHandler(this.btnModificarLectura_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.AutoSize = true;
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Location = new System.Drawing.Point(1043, 9);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(39, 39);
            this.btnCerrar.TabIndex = 39;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmCapturaLecturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1094, 644);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnModificarLectura);
            this.Controls.Add(this.btnAgregarLectura);
            this.Controls.Add(this.dgvMedidorLecturas);
            this.Controls.Add(this.grpBuscarContrato);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCapturaLecturas";
            this.Text = "Capturar Lecturas";
            this.grpBuscarContrato.ResumeLayout(false);
            this.grpBuscarContrato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedidorLecturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNoContrato;
        private System.Windows.Forms.Button btnSeleccionarContrato;
        private System.Windows.Forms.GroupBox grpBuscarContrato;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.DataGridView dgvMedidorLecturas;
        private System.Windows.Forms.Button btnAgregarLectura;
        private System.Windows.Forms.MaskedTextBox txtNoContrato;
        private System.Windows.Forms.Button btnModificarLectura;
        private System.Windows.Forms.Button btnCerrar;
    }
}
