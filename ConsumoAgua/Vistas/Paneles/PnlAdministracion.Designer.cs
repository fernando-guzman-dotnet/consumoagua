namespace SAPA.Vistas.Paneles {
    partial class PnlAdministracion {
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNombreOrganismo = new System.Windows.Forms.TextBox();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtNoExterior = new System.Windows.Forms.TextBox();
            this.txtNoInterior = new System.Windows.Forms.TextBox();
            this.txtDireccionCompleta = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lblOrganismo = new System.Windows.Forms.Label();
            this.lblRFC = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.lblColonia = new System.Windows.Forms.Label();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblNoExterior = new System.Windows.Forms.Label();
            this.lblNoInterior = new System.Windows.Forms.Label();
            this.lblDireccionCompleta = new System.Windows.Forms.Label();
            this.lblNotaDireccionCompleta = new System.Windows.Forms.Label();
            this.pbImagenOrganismo = new System.Windows.Forms.PictureBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenOrganismo)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(554, 379);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(116, 34);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNombreOrganismo
            // 
            this.txtNombreOrganismo.Location = new System.Drawing.Point(213, 74);
            this.txtNombreOrganismo.Name = "txtNombreOrganismo";
            this.txtNombreOrganismo.Size = new System.Drawing.Size(455, 20);
            this.txtNombreOrganismo.TabIndex = 1;
            this.txtNombreOrganismo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToUpper_KeyPress);
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(213, 120);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(237, 20);
            this.txtRFC.TabIndex = 2;
            this.txtRFC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToUpper_KeyPress);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(476, 118);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(193, 20);
            this.txtTelefono.TabIndex = 3;
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Location = new System.Drawing.Point(213, 265);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(237, 20);
            this.txtMunicipio.TabIndex = 9;
            this.txtMunicipio.TextChanged += new System.EventHandler(this.Direccion_TextChanged);
            this.txtMunicipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToUpper_KeyPress);
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(213, 213);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(352, 20);
            this.txtColonia.TabIndex = 7;
            this.txtColonia.TextChanged += new System.EventHandler(this.Direccion_TextChanged);
            this.txtColonia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToUpper_KeyPress);
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(581, 213);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(89, 20);
            this.txtCodigoPostal.TabIndex = 8;
            this.txtCodigoPostal.TextChanged += new System.EventHandler(this.Direccion_TextChanged);
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToUpper_KeyPress);
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(213, 167);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(237, 20);
            this.txtCalle.TabIndex = 4;
            this.txtCalle.TextChanged += new System.EventHandler(this.Direccion_TextChanged);
            this.txtCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToUpper_KeyPress);
            // 
            // txtNoExterior
            // 
            this.txtNoExterior.Location = new System.Drawing.Point(476, 167);
            this.txtNoExterior.Name = "txtNoExterior";
            this.txtNoExterior.Size = new System.Drawing.Size(89, 20);
            this.txtNoExterior.TabIndex = 5;
            this.txtNoExterior.TextChanged += new System.EventHandler(this.Direccion_TextChanged);
            this.txtNoExterior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToUpper_KeyPress);
            // 
            // txtNoInterior
            // 
            this.txtNoInterior.Location = new System.Drawing.Point(581, 167);
            this.txtNoInterior.Name = "txtNoInterior";
            this.txtNoInterior.Size = new System.Drawing.Size(89, 20);
            this.txtNoInterior.TabIndex = 6;
            this.txtNoInterior.TextChanged += new System.EventHandler(this.Direccion_TextChanged);
            this.txtNoInterior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToUpper_KeyPress);
            // 
            // txtDireccionCompleta
            // 
            this.txtDireccionCompleta.Enabled = false;
            this.txtDireccionCompleta.Location = new System.Drawing.Point(213, 316);
            this.txtDireccionCompleta.Name = "txtDireccionCompleta";
            this.txtDireccionCompleta.Size = new System.Drawing.Size(457, 20);
            this.txtDireccionCompleta.TabIndex = 11;
            this.txtDireccionCompleta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToUpper_KeyPress);
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(476, 265);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(193, 20);
            this.txtEstado.TabIndex = 10;
            this.txtEstado.TextChanged += new System.EventHandler(this.Direccion_TextChanged);
            this.txtEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToUpper_KeyPress);
            // 
            // lblOrganismo
            // 
            this.lblOrganismo.AutoSize = true;
            this.lblOrganismo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrganismo.Location = new System.Drawing.Point(213, 51);
            this.lblOrganismo.Name = "lblOrganismo";
            this.lblOrganismo.Size = new System.Drawing.Size(95, 20);
            this.lblOrganismo.TabIndex = 17;
            this.lblOrganismo.Text = "Organismo";
            // 
            // lblRFC
            // 
            this.lblRFC.AutoSize = true;
            this.lblRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFC.Location = new System.Drawing.Point(213, 97);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(60, 20);
            this.lblRFC.TabIndex = 18;
            this.lblRFC.Text = "R.F.C.";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(476, 97);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(79, 20);
            this.lblTelefono.TabIndex = 19;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(476, 242);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(66, 20);
            this.lblEstado.TabIndex = 20;
            this.lblEstado.Text = "Estado";
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMunicipio.Location = new System.Drawing.Point(213, 242);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(84, 20);
            this.lblMunicipio.TabIndex = 21;
            this.lblMunicipio.Text = "Municipio";
            // 
            // lblColonia
            // 
            this.lblColonia.AutoSize = true;
            this.lblColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColonia.Location = new System.Drawing.Point(213, 190);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(69, 20);
            this.lblColonia.TabIndex = 22;
            this.lblColonia.Text = "Colonia";
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoPostal.Location = new System.Drawing.Point(581, 190);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(42, 20);
            this.lblCodigoPostal.TabIndex = 23;
            this.lblCodigoPostal.Text = "C.P.";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.Location = new System.Drawing.Point(213, 144);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(49, 20);
            this.lblCalle.TabIndex = 24;
            this.lblCalle.Text = "Calle";
            // 
            // lblNoExterior
            // 
            this.lblNoExterior.AutoSize = true;
            this.lblNoExterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoExterior.Location = new System.Drawing.Point(476, 144);
            this.lblNoExterior.Name = "lblNoExterior";
            this.lblNoExterior.Size = new System.Drawing.Size(64, 18);
            this.lblNoExterior.TabIndex = 25;
            this.lblNoExterior.Text = "No. Ext";
            // 
            // lblNoInterior
            // 
            this.lblNoInterior.AutoSize = true;
            this.lblNoInterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoInterior.Location = new System.Drawing.Point(581, 143);
            this.lblNoInterior.Name = "lblNoInterior";
            this.lblNoInterior.Size = new System.Drawing.Size(63, 20);
            this.lblNoInterior.TabIndex = 26;
            this.lblNoInterior.Text = "No. Int";
            // 
            // lblDireccionCompleta
            // 
            this.lblDireccionCompleta.AutoSize = true;
            this.lblDireccionCompleta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccionCompleta.Location = new System.Drawing.Point(213, 293);
            this.lblDireccionCompleta.Name = "lblDireccionCompleta";
            this.lblDireccionCompleta.Size = new System.Drawing.Size(165, 20);
            this.lblDireccionCompleta.TabIndex = 27;
            this.lblDireccionCompleta.Text = "Dirección Completa";
            // 
            // lblNotaDireccionCompleta
            // 
            this.lblNotaDireccionCompleta.AutoSize = true;
            this.lblNotaDireccionCompleta.Location = new System.Drawing.Point(213, 339);
            this.lblNotaDireccionCompleta.Name = "lblNotaDireccionCompleta";
            this.lblNotaDireccionCompleta.Size = new System.Drawing.Size(307, 13);
            this.lblNotaDireccionCompleta.TabIndex = 28;
            this.lblNotaDireccionCompleta.Text = "* Esta dirección será la que se muestre en los reportes y tickets.";
            // 
            // pbImagenOrganismo
            // 
            this.pbImagenOrganismo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagenOrganismo.Location = new System.Drawing.Point(12, 59);
            this.pbImagenOrganismo.Name = "pbImagenOrganismo";
            this.pbImagenOrganismo.Size = new System.Drawing.Size(128, 128);
            this.pbImagenOrganismo.TabIndex = 29;
            this.pbImagenOrganismo.TabStop = false;
            this.pbImagenOrganismo.Click += new System.EventHandler(this.pbImagenOrganismo_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(759, 33);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 45;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(759, 448);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.pbImagenOrganismo);
            this.Controls.Add(this.lblNotaDireccionCompleta);
            this.Controls.Add(this.lblDireccionCompleta);
            this.Controls.Add(this.lblNoInterior);
            this.Controls.Add(this.lblNoExterior);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.lblCodigoPostal);
            this.Controls.Add(this.lblColonia);
            this.Controls.Add(this.lblMunicipio);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblRFC);
            this.Controls.Add(this.lblOrganismo);
            this.Controls.Add(this.txtDireccionCompleta);
            this.Controls.Add(this.txtNoInterior);
            this.Controls.Add(this.txtNoExterior);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.txtCodigoPostal);
            this.Controls.Add(this.txtColonia);
            this.Controls.Add(this.txtMunicipio);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.txtNombreOrganismo);
            this.Controls.Add(this.btnGuardar);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlAdministracion";
            this.Text = "Panel_Administracion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PnlAdministracion_FormClosing);
            this.Load += new System.EventHandler(this.PnlAdministracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenOrganismo)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNombreOrganismo;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtNoExterior;
        private System.Windows.Forms.TextBox txtNoInterior;
        private System.Windows.Forms.TextBox txtDireccionCompleta;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label lblOrganismo;
        private System.Windows.Forms.Label lblRFC;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblNoExterior;
        private System.Windows.Forms.Label lblNoInterior;
        private System.Windows.Forms.Label lblDireccionCompleta;
        private System.Windows.Forms.Label lblNotaDireccionCompleta;
        private System.Windows.Forms.PictureBox pbImagenOrganismo;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
