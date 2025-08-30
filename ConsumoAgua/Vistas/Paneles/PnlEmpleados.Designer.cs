namespace SAPA.Vistas.Paneles {
    partial class PnlEmpleados {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblUsuario = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtUsuario = new System.Windows.Forms.ToolStripTextBox();
            this.tsLblNombre = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtNombre = new System.Windows.Forms.ToolStripTextBox();
            this.tsLblDomicilio = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtDomicilio = new System.Windows.Forms.ToolStripTextBox();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregarEmpleado = new System.Windows.Forms.ToolStripButton();
            this.btnEditarEmplaedo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarEmpleado = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contrasena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoCuadrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblUsuario,
            this.tsTxtUsuario,
            this.tsLblNombre,
            this.tsTxtNombre,
            this.tsLblDomicilio,
            this.tsTxtDomicilio,
            this.tsSeparador,
            this.btnAgregarEmpleado,
            this.btnEditarEmplaedo,
            this.btnEliminarEmpleado,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1404, 37);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 14;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblUsuario
            // 
            this.tsLblUsuario.Name = "tsLblUsuario";
            this.tsLblUsuario.Size = new System.Drawing.Size(47, 34);
            this.tsLblUsuario.Text = "Usuario";
            // 
            // tsTxtUsuario
            // 
            this.tsTxtUsuario.Name = "tsTxtUsuario";
            this.tsTxtUsuario.Size = new System.Drawing.Size(150, 37);
            this.tsTxtUsuario.TextChanged += new System.EventHandler(this.tsTxtUsuario_TextChanged);
            // 
            // tsLblNombre
            // 
            this.tsLblNombre.Name = "tsLblNombre";
            this.tsLblNombre.Size = new System.Drawing.Size(51, 34);
            this.tsLblNombre.Text = "Nombre";
            // 
            // tsTxtNombre
            // 
            this.tsTxtNombre.Name = "tsTxtNombre";
            this.tsTxtNombre.Size = new System.Drawing.Size(150, 37);
            this.tsTxtNombre.TextChanged += new System.EventHandler(this.tsTxtNombre_TextChanged);
            // 
            // tsLblDomicilio
            // 
            this.tsLblDomicilio.Name = "tsLblDomicilio";
            this.tsLblDomicilio.Size = new System.Drawing.Size(58, 34);
            this.tsLblDomicilio.Text = "Domicilio";
            // 
            // tsTxtDomicilio
            // 
            this.tsTxtDomicilio.Name = "tsTxtDomicilio";
            this.tsTxtDomicilio.Size = new System.Drawing.Size(150, 37);
            this.tsTxtDomicilio.TextChanged += new System.EventHandler(this.tsTxtDomicilio_TextChanged);
            // 
            // tsSeparador
            // 
            this.tsSeparador.Name = "tsSeparador";
            this.tsSeparador.Size = new System.Drawing.Size(6, 37);
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarEmpleado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(139, 34);
            this.btnAgregarEmpleado.Text = "Agregar Empleado";
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.btnAgregarEmpleado_Click);
            // 
            // btnEditarEmplaedo
            // 
            this.btnEditarEmplaedo.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarEmplaedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarEmplaedo.Name = "btnEditarEmplaedo";
            this.btnEditarEmplaedo.Size = new System.Drawing.Size(127, 34);
            this.btnEditarEmplaedo.Text = "Editar Empleado";
            this.btnEditarEmplaedo.Click += new System.EventHandler(this.btnEditarEmpleado_Click);
            // 
            // btnEliminarEmpleado
            // 
            this.btnEliminarEmpleado.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarEmpleado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarEmpleado.Name = "btnEliminarEmpleado";
            this.btnEliminarEmpleado.Size = new System.Drawing.Size(140, 34);
            this.btnEliminarEmpleado.Text = "Eliminar Empleado";
            this.btnEliminarEmpleado.Click += new System.EventHandler(this.btnEliminarEmpleado_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToDeleteRows = false;
            this.dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpleados.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Contrasena,
            this.ApellidoPaterno,
            this.ApellidoMaterno,
            this.NombreCompleto,
            this.Usuario,
            this.Domicilio,
            this.Telefono,
            this.RFC,
            this.NoCuadrilla,
            this.Puesto,
            this.Caja});
            this.dgvEmpleados.Location = new System.Drawing.Point(12, 40);
            this.dgvEmpleados.MultiSelect = false;
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.ReadOnly = true;
            this.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleados.Size = new System.Drawing.Size(1380, 648);
            this.dgvEmpleados.TabIndex = 13;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Visible = false;
            // 
            // Contrasena
            // 
            this.Contrasena.DataPropertyName = "Contrasena";
            this.Contrasena.HeaderText = "Contrasena";
            this.Contrasena.Name = "Contrasena";
            this.Contrasena.ReadOnly = true;
            this.Contrasena.Visible = false;
            // 
            // ApellidoPaterno
            // 
            this.ApellidoPaterno.DataPropertyName = "ApellidoPaterno";
            this.ApellidoPaterno.HeaderText = "ApellidoPaterno";
            this.ApellidoPaterno.Name = "ApellidoPaterno";
            this.ApellidoPaterno.ReadOnly = true;
            this.ApellidoPaterno.Visible = false;
            // 
            // ApellidoMaterno
            // 
            this.ApellidoMaterno.DataPropertyName = "ApellidoMaterno";
            this.ApellidoMaterno.HeaderText = "ApellidoMaterno";
            this.ApellidoMaterno.Name = "ApellidoMaterno";
            this.ApellidoMaterno.ReadOnly = true;
            this.ApellidoMaterno.Visible = false;
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NombreCompleto.DataPropertyName = "NombreCompleto";
            this.NombreCompleto.HeaderText = "Nombre Completo";
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            this.NombreCompleto.Width = 120;
            // 
            // Usuario
            // 
            this.Usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Usuario.DataPropertyName = "Usuario";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 75;
            // 
            // Domicilio
            // 
            this.Domicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Domicilio.DataPropertyName = "Domicilio";
            this.Domicilio.HeaderText = "Domicilio";
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.ReadOnly = true;
            this.Domicilio.Width = 83;
            // 
            // Telefono
            // 
            this.Telefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Telefono.DataPropertyName = "Telefono";
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 82;
            // 
            // RFC
            // 
            this.RFC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RFC.DataPropertyName = "RFC";
            this.RFC.HeaderText = "RFC";
            this.RFC.Name = "RFC";
            this.RFC.ReadOnly = true;
            this.RFC.Width = 56;
            // 
            // NoCuadrilla
            // 
            this.NoCuadrilla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NoCuadrilla.DataPropertyName = "NoCuadrilla";
            dataGridViewCellStyle2.Format = "D4";
            this.NoCuadrilla.DefaultCellStyle = dataGridViewCellStyle2;
            this.NoCuadrilla.HeaderText = "No. de Cuadrilla";
            this.NoCuadrilla.Name = "NoCuadrilla";
            this.NoCuadrilla.ReadOnly = true;
            this.NoCuadrilla.Width = 113;
            // 
            // Puesto
            // 
            this.Puesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Puesto.DataPropertyName = "NombrePuesto";
            this.Puesto.HeaderText = "Puesto";
            this.Puesto.Name = "Puesto";
            this.Puesto.ReadOnly = true;
            this.Puesto.Width = 71;
            // 
            // Caja
            // 
            this.Caja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Caja.DataPropertyName = "NombreCaja";
            this.Caja.HeaderText = "Caja";
            this.Caja.Name = "Caja";
            this.Caja.ReadOnly = true;
            this.Caja.Width = 57;
            // 
            // PnlEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1404, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvEmpleados);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlEmpleados";
            this.Text = "Panel_Empleados";
            this.Load += new System.EventHandler(this.PnlEmpleados_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAgregarEmpleado;
        private System.Windows.Forms.ToolStripButton btnEditarEmplaedo;
        private System.Windows.Forms.ToolStripButton btnEliminarEmpleado;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.ToolStripLabel tsLblUsuario;
        private System.Windows.Forms.ToolStripTextBox tsTxtUsuario;
        private System.Windows.Forms.ToolStripLabel tsLblNombre;
        private System.Windows.Forms.ToolStripTextBox tsTxtNombre;
        private System.Windows.Forms.ToolStripLabel tsLblDomicilio;
        private System.Windows.Forms.ToolStripTextBox tsTxtDomicilio;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contrasena;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoCuadrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caja;
    }
}
