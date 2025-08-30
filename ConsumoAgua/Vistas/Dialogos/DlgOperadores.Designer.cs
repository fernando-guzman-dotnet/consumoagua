namespace SAPA.Vistas.Dialogos {
    partial class DlgOperadores {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgOperadores));
            this.lblSectorAsignado = new System.Windows.Forms.Label();
            this.cmbSectores = new System.Windows.Forms.ComboBox();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.chkModificarContrasena = new System.Windows.Forms.CheckBox();
            this.txtRepetirContrasena = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblRepetirContrasena = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.PnlContrasena = new System.Windows.Forms.Panel();
            this.PnlContrasena.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSectorAsignado
            // 
            this.lblSectorAsignado.AutoSize = true;
            this.lblSectorAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectorAsignado.Location = new System.Drawing.Point(14, 235);
            this.lblSectorAsignado.Name = "lblSectorAsignado";
            this.lblSectorAsignado.Size = new System.Drawing.Size(131, 18);
            this.lblSectorAsignado.TabIndex = 12;
            this.lblSectorAsignado.Text = "Sector asignado";
            // 
            // cmbSectores
            // 
            this.cmbSectores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSectores.FormattingEnabled = true;
            this.cmbSectores.Location = new System.Drawing.Point(17, 256);
            this.cmbSectores.Name = "cmbSectores";
            this.cmbSectores.Size = new System.Drawing.Size(366, 21);
            this.cmbSectores.TabIndex = 6;
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomicilio.Location = new System.Drawing.Point(11, 191);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(79, 18);
            this.lblDomicilio.TabIndex = 10;
            this.lblDomicilio.Text = "Domicilio";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(163, 58);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(67, 18);
            this.lblApellido.TabIndex = 9;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(11, 58);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(68, 18);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(12, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 18);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "Usuario";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(308, 295);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(227, 295);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(15, 30);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(130, 20);
            this.txtUsuario.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(15, 84);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(130, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(166, 84);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(217, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(14, 212);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(369, 20);
            this.txtDomicilio.TabIndex = 5;
            // 
            // chkModificarContrasena
            // 
            this.chkModificarContrasena.AutoSize = true;
            this.chkModificarContrasena.Location = new System.Drawing.Point(14, 110);
            this.chkModificarContrasena.Name = "chkModificarContrasena";
            this.chkModificarContrasena.Size = new System.Drawing.Size(125, 17);
            this.chkModificarContrasena.TabIndex = 3;
            this.chkModificarContrasena.Text = "Modificar contraseña";
            this.chkModificarContrasena.UseVisualStyleBackColor = true;
            this.chkModificarContrasena.CheckedChanged += new System.EventHandler(this.chkModificarContrasena_CheckedChanged);
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
            // txtContrasena
            // 
            this.txtContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.Location = new System.Drawing.Point(6, 27);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '•';
            this.txtContrasena.Size = new System.Drawing.Size(130, 26);
            this.txtContrasena.TabIndex = 0;
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
            // PnlContrasena
            // 
            this.PnlContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlContrasena.Controls.Add(this.lblContrasena);
            this.PnlContrasena.Controls.Add(this.lblRepetirContrasena);
            this.PnlContrasena.Controls.Add(this.txtContrasena);
            this.PnlContrasena.Controls.Add(this.txtRepetirContrasena);
            this.PnlContrasena.Location = new System.Drawing.Point(14, 129);
            this.PnlContrasena.Name = "PnlContrasena";
            this.PnlContrasena.Size = new System.Drawing.Size(369, 59);
            this.PnlContrasena.TabIndex = 4;
            // 
            // DlgOperadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(395, 350);
            this.Controls.Add(this.PnlContrasena);
            this.Controls.Add(this.chkModificarContrasena);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblSectorAsignado);
            this.Controls.Add(this.cmbSectores);
            this.Controls.Add(this.lblDomicilio);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblUsuario);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgOperadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Operadores";
            this.Load += new System.EventHandler(this.DlgOperadores_Load);
            this.PnlContrasena.ResumeLayout(false);
            this.PnlContrasena.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSectorAsignado;
        private System.Windows.Forms.ComboBox cmbSectores;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.CheckBox chkModificarContrasena;
        private System.Windows.Forms.TextBox txtRepetirContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblRepetirContrasena;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Panel PnlContrasena;
    }
}
