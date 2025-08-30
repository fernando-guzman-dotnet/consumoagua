namespace SAPA.Vistas.Dialogos
{
    partial class DlgEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgEmpleado));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tabDatosGenerales = new System.Windows.Forms.TabPage();
            this.txtNoCuadrilla = new System.Windows.Forms.TextBox();
            this.lblNoCuadrilla = new System.Windows.Forms.Label();
            this.cmbCaja = new System.Windows.Forms.ComboBox();
            this.lblCajaAsignada = new System.Windows.Forms.Label();
            this.cmbPuesto = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellidoPaterno = new System.Windows.Forms.TextBox();
            this.txtApellidoMaterno = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellidoPaterno = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblApellidoMaterno = new System.Windows.Forms.Label();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.pnlContrasena = new System.Windows.Forms.Panel();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.lblRepetirContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtRepetirContrasena = new System.Windows.Forms.TextBox();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.lblRFC = new System.Windows.Forms.Label();
            this.chkModificarContrasena = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDatosGenerales.SuspendLayout();
            this.pnlContrasena.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(762, 568);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 1;
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
            this.btnAceptar.Location = new System.Drawing.Point(681, 568);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // tabDatosGenerales
            // 
            this.tabDatosGenerales.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.tabDatosGenerales.Controls.Add(this.txtNoCuadrilla);
            this.tabDatosGenerales.Controls.Add(this.lblNoCuadrilla);
            this.tabDatosGenerales.Controls.Add(this.cmbCaja);
            this.tabDatosGenerales.Controls.Add(this.lblCajaAsignada);
            this.tabDatosGenerales.Controls.Add(this.cmbPuesto);
            this.tabDatosGenerales.Controls.Add(this.lblUsuario);
            this.tabDatosGenerales.Controls.Add(this.txtTelefono);
            this.tabDatosGenerales.Controls.Add(this.txtRFC);
            this.tabDatosGenerales.Controls.Add(this.txtUsuario);
            this.tabDatosGenerales.Controls.Add(this.txtDomicilio);
            this.tabDatosGenerales.Controls.Add(this.txtNombre);
            this.tabDatosGenerales.Controls.Add(this.txtApellidoPaterno);
            this.tabDatosGenerales.Controls.Add(this.txtApellidoMaterno);
            this.tabDatosGenerales.Controls.Add(this.lblNombre);
            this.tabDatosGenerales.Controls.Add(this.lblApellidoPaterno);
            this.tabDatosGenerales.Controls.Add(this.lblTelefono);
            this.tabDatosGenerales.Controls.Add(this.lblApellidoMaterno);
            this.tabDatosGenerales.Controls.Add(this.lblDomicilio);
            this.tabDatosGenerales.Controls.Add(this.pnlContrasena);
            this.tabDatosGenerales.Controls.Add(this.lblPuesto);
            this.tabDatosGenerales.Controls.Add(this.lblRFC);
            this.tabDatosGenerales.Controls.Add(this.chkModificarContrasena);
            this.tabDatosGenerales.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tabDatosGenerales.Location = new System.Drawing.Point(4, 22);
            this.tabDatosGenerales.Name = "tabDatosGenerales";
            this.tabDatosGenerales.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatosGenerales.Size = new System.Drawing.Size(817, 524);
            this.tabDatosGenerales.TabIndex = 0;
            this.tabDatosGenerales.Text = "Datos del Empleado";
            // 
            // txtNoCuadrilla
            // 
            this.txtNoCuadrilla.Location = new System.Drawing.Point(167, 24);
            this.txtNoCuadrilla.Name = "txtNoCuadrilla";
            this.txtNoCuadrilla.Size = new System.Drawing.Size(130, 20);
            this.txtNoCuadrilla.TabIndex = 33;
            // 
            // lblNoCuadrilla
            // 
            this.lblNoCuadrilla.AutoSize = true;
            this.lblNoCuadrilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoCuadrilla.Location = new System.Drawing.Point(164, 3);
            this.lblNoCuadrilla.Name = "lblNoCuadrilla";
            this.lblNoCuadrilla.Size = new System.Drawing.Size(106, 18);
            this.lblNoCuadrilla.TabIndex = 32;
            this.lblNoCuadrilla.Text = "No. Cuadrilla";
            // 
            // cmbCaja
            // 
            this.cmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCaja.FormattingEnabled = true;
            this.cmbCaja.Location = new System.Drawing.Point(12, 473);
            this.cmbCaja.Name = "cmbCaja";
            this.cmbCaja.Size = new System.Drawing.Size(285, 21);
            this.cmbCaja.TabIndex = 10;
            // 
            // lblCajaAsignada
            // 
            this.lblCajaAsignada.AutoSize = true;
            this.lblCajaAsignada.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajaAsignada.Location = new System.Drawing.Point(12, 452);
            this.lblCajaAsignada.Name = "lblCajaAsignada";
            this.lblCajaAsignada.Size = new System.Drawing.Size(114, 18);
            this.lblCajaAsignada.TabIndex = 30;
            this.lblCajaAsignada.Text = "Caja asignada";
            // 
            // cmbPuesto
            // 
            this.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuesto.FormattingEnabled = true;
            this.cmbPuesto.Location = new System.Drawing.Point(12, 422);
            this.cmbPuesto.Name = "cmbPuesto";
            this.cmbPuesto.Size = new System.Drawing.Size(285, 21);
            this.cmbPuesto.TabIndex = 9;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(12, 3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 18);
            this.lblUsuario.TabIndex = 18;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(12, 319);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(369, 20);
            this.txtTelefono.TabIndex = 7;
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(12, 369);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(369, 20);
            this.txtRFC.TabIndex = 8;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(12, 24);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(130, 20);
            this.txtUsuario.TabIndex = 0;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(12, 275);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(369, 20);
            this.txtDomicilio.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(12, 78);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(130, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.Location = new System.Drawing.Point(12, 139);
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(133, 20);
            this.txtApellidoPaterno.TabIndex = 3;
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.Location = new System.Drawing.Point(167, 139);
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(130, 20);
            this.txtApellidoMaterno.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(12, 52);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(68, 18);
            this.lblNombre.TabIndex = 20;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellidoPaterno
            // 
            this.lblApellidoPaterno.AutoSize = true;
            this.lblApellidoPaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoPaterno.Location = new System.Drawing.Point(9, 113);
            this.lblApellidoPaterno.Name = "lblApellidoPaterno";
            this.lblApellidoPaterno.Size = new System.Drawing.Size(131, 18);
            this.lblApellidoPaterno.TabIndex = 22;
            this.lblApellidoPaterno.Text = "Apellido Paterno";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(12, 298);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(74, 18);
            this.lblTelefono.TabIndex = 28;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblApellidoMaterno
            // 
            this.lblApellidoMaterno.AutoSize = true;
            this.lblApellidoMaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoMaterno.Location = new System.Drawing.Point(164, 113);
            this.lblApellidoMaterno.Name = "lblApellidoMaterno";
            this.lblApellidoMaterno.Size = new System.Drawing.Size(134, 18);
            this.lblApellidoMaterno.TabIndex = 22;
            this.lblApellidoMaterno.Text = "Apellido Materno";
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomicilio.Location = new System.Drawing.Point(12, 254);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(79, 18);
            this.lblDomicilio.TabIndex = 24;
            this.lblDomicilio.Text = "Domicilio";
            // 
            // pnlContrasena
            // 
            this.pnlContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContrasena.Controls.Add(this.lblContrasena);
            this.pnlContrasena.Controls.Add(this.lblRepetirContrasena);
            this.pnlContrasena.Controls.Add(this.txtContrasena);
            this.pnlContrasena.Controls.Add(this.txtRepetirContrasena);
            this.pnlContrasena.Location = new System.Drawing.Point(8, 192);
            this.pnlContrasena.Name = "pnlContrasena";
            this.pnlContrasena.Size = new System.Drawing.Size(369, 59);
            this.pnlContrasena.TabIndex = 5;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasena.Location = new System.Drawing.Point(3, 1);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(95, 18);
            this.lblContrasena.TabIndex = 42;
            this.lblContrasena.Text = "Contraseña";
            // 
            // lblRepetirContrasena
            // 
            this.lblRepetirContrasena.AutoSize = true;
            this.lblRepetirContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepetirContrasena.Location = new System.Drawing.Point(155, 1);
            this.lblRepetirContrasena.Name = "lblRepetirContrasena";
            this.lblRepetirContrasena.Size = new System.Drawing.Size(151, 18);
            this.lblRepetirContrasena.TabIndex = 43;
            this.lblRepetirContrasena.Text = "Repetir contraseña";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.Location = new System.Drawing.Point(6, 27);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '•';
            this.txtContrasena.Size = new System.Drawing.Size(130, 26);
            this.txtContrasena.TabIndex = 0;
            // 
            // txtRepetirContrasena
            // 
            this.txtRepetirContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtRepetirContrasena.Location = new System.Drawing.Point(158, 27);
            this.txtRepetirContrasena.Name = "txtRepetirContrasena";
            this.txtRepetirContrasena.PasswordChar = '•';
            this.txtRepetirContrasena.Size = new System.Drawing.Size(130, 26);
            this.txtRepetirContrasena.TabIndex = 1;
            // 
            // lblPuesto
            // 
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuesto.Location = new System.Drawing.Point(12, 401);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(61, 18);
            this.lblPuesto.TabIndex = 26;
            this.lblPuesto.Text = "Puesto";
            // 
            // lblRFC
            // 
            this.lblRFC.AutoSize = true;
            this.lblRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFC.Location = new System.Drawing.Point(12, 348);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(42, 18);
            this.lblRFC.TabIndex = 26;
            this.lblRFC.Text = "RFC";
            // 
            // chkModificarContrasena
            // 
            this.chkModificarContrasena.AutoSize = true;
            this.chkModificarContrasena.Location = new System.Drawing.Point(8, 173);
            this.chkModificarContrasena.Name = "chkModificarContrasena";
            this.chkModificarContrasena.Size = new System.Drawing.Size(125, 17);
            this.chkModificarContrasena.TabIndex = 3;
            this.chkModificarContrasena.Text = "Modificar contraseña";
            this.chkModificarContrasena.UseVisualStyleBackColor = true;
            this.chkModificarContrasena.CheckedChanged += new System.EventHandler(this.chkModificarContrasena_CheckedChanged);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabDatosGenerales);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(825, 550);
            this.tabControl.TabIndex = 0;
            // 
            // DlgEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(849, 623);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleados";
            this.Load += new System.EventHandler(this.DlgEmpleado_Load);
            this.Shown += new System.EventHandler(this.DlgEmpleado_Shown);
            this.tabDatosGenerales.ResumeLayout(false);
            this.tabDatosGenerales.PerformLayout();
            this.pnlContrasena.ResumeLayout(false);
            this.pnlContrasena.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TabPage tabDatosGenerales;
        private System.Windows.Forms.ComboBox cmbCaja;
        private System.Windows.Forms.Label lblCajaAsignada;
        private System.Windows.Forms.ComboBox cmbPuesto;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellidoMaterno;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblApellidoMaterno;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.Panel pnlContrasena;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblRepetirContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtRepetirContrasena;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.Label lblRFC;
        private System.Windows.Forms.CheckBox chkModificarContrasena;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TextBox txtApellidoPaterno;
        private System.Windows.Forms.Label lblApellidoPaterno;
        private System.Windows.Forms.Label lblNoCuadrilla;
        private System.Windows.Forms.TextBox txtNoCuadrilla;
    }
}
