namespace SAPA.Vistas.Dialogos
{
    partial class DlgUsuariosDirecciones
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
            this.grpUsuario = new System.Windows.Forms.GroupBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.dgvUsuariosDirecciones = new System.Windows.Forms.DataGridView();
            this.btnAgregarDireccion = new System.Windows.Forms.Button();
            this.btnEditarDireccion = new System.Windows.Forms.Button();
            this.btnHacerPrincipal = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Municipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colonia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroExterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroInterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Predeterminada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosDirecciones)).BeginInit();
            this.SuspendLayout();
            // 
            // grpUsuario
            // 
            this.grpUsuario.Controls.Add(this.txtUsuario);
            this.grpUsuario.Controls.Add(this.lblNombreUsuario);
            this.grpUsuario.Location = new System.Drawing.Point(12, 12);
            this.grpUsuario.Name = "grpUsuario";
            this.grpUsuario.Size = new System.Drawing.Size(725, 40);
            this.grpUsuario.TabIndex = 0;
            this.grpUsuario.TabStop = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(79, 12);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(294, 20);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.TabStop = false;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(6, 16);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(67, 13);
            this.lblNombreUsuario.TabIndex = 0;
            this.lblNombreUsuario.Text = "USUARIO:";
            // 
            // dgvUsuariosDirecciones
            // 
            this.dgvUsuariosDirecciones.AllowUserToAddRows = false;
            this.dgvUsuariosDirecciones.AllowUserToDeleteRows = false;
            this.dgvUsuariosDirecciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuariosDirecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuariosDirecciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdUsuario,
            this.Estado,
            this.Municipio,
            this.Colonia,
            this.Calle,
            this.CodigoPostal,
            this.NumeroExterior,
            this.NumeroInterior,
            this.Direccion,
            this.Predeterminada});
            this.dgvUsuariosDirecciones.Location = new System.Drawing.Point(12, 59);
            this.dgvUsuariosDirecciones.Name = "dgvUsuariosDirecciones";
            this.dgvUsuariosDirecciones.ReadOnly = true;
            this.dgvUsuariosDirecciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuariosDirecciones.Size = new System.Drawing.Size(725, 415);
            this.dgvUsuariosDirecciones.TabIndex = 1;
            // 
            // btnAgregarDireccion
            // 
            this.btnAgregarDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDireccion.Image = global::SAPA.Properties.Resources.Agregar_33x33;
            this.btnAgregarDireccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarDireccion.Location = new System.Drawing.Point(12, 480);
            this.btnAgregarDireccion.Name = "btnAgregarDireccion";
            this.btnAgregarDireccion.Size = new System.Drawing.Size(182, 45);
            this.btnAgregarDireccion.TabIndex = 2;
            this.btnAgregarDireccion.Text = "Agregar Direccion";
            this.btnAgregarDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarDireccion.UseVisualStyleBackColor = true;
            this.btnAgregarDireccion.Click += new System.EventHandler(this.btnAgregarDireccion_Click);
            // 
            // btnEditarDireccion
            // 
            this.btnEditarDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarDireccion.Image = global::SAPA.Properties.Resources.Editar_33x33;
            this.btnEditarDireccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarDireccion.Location = new System.Drawing.Point(200, 480);
            this.btnEditarDireccion.Name = "btnEditarDireccion";
            this.btnEditarDireccion.Size = new System.Drawing.Size(169, 45);
            this.btnEditarDireccion.TabIndex = 3;
            this.btnEditarDireccion.Text = "Editar Direccion";
            this.btnEditarDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarDireccion.UseVisualStyleBackColor = true;
            this.btnEditarDireccion.Click += new System.EventHandler(this.btnEditarDireccion_Click);
            // 
            // btnHacerPrincipal
            // 
            this.btnHacerPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHacerPrincipal.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnHacerPrincipal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHacerPrincipal.Location = new System.Drawing.Point(518, 480);
            this.btnHacerPrincipal.Name = "btnHacerPrincipal";
            this.btnHacerPrincipal.Size = new System.Drawing.Size(219, 45);
            this.btnHacerPrincipal.TabIndex = 4;
            this.btnHacerPrincipal.Text = "Hacer Predeterminada";
            this.btnHacerPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHacerPrincipal.UseVisualStyleBackColor = true;
            this.btnHacerPrincipal.Click += new System.EventHandler(this.btnHacerPrincipal_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // IdUsuario
            // 
            this.IdUsuario.DataPropertyName = "IdUsuario";
            this.IdUsuario.HeaderText = "IdUsuario";
            this.IdUsuario.Name = "IdUsuario";
            this.IdUsuario.ReadOnly = true;
            this.IdUsuario.Visible = false;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // Municipio
            // 
            this.Municipio.DataPropertyName = "Municipio";
            this.Municipio.HeaderText = "Municipio";
            this.Municipio.Name = "Municipio";
            this.Municipio.ReadOnly = true;
            this.Municipio.Visible = false;
            // 
            // Colonia
            // 
            this.Colonia.DataPropertyName = "Colonia";
            this.Colonia.HeaderText = "Colonia";
            this.Colonia.Name = "Colonia";
            this.Colonia.ReadOnly = true;
            this.Colonia.Visible = false;
            // 
            // Calle
            // 
            this.Calle.DataPropertyName = "Calle";
            this.Calle.HeaderText = "Calle";
            this.Calle.Name = "Calle";
            this.Calle.ReadOnly = true;
            this.Calle.Visible = false;
            // 
            // CodigoPostal
            // 
            this.CodigoPostal.DataPropertyName = "CodigoPostal";
            this.CodigoPostal.HeaderText = "Código Postal";
            this.CodigoPostal.Name = "CodigoPostal";
            this.CodigoPostal.ReadOnly = true;
            this.CodigoPostal.Visible = false;
            // 
            // NumeroExterior
            // 
            this.NumeroExterior.DataPropertyName = "NumeroExterior";
            this.NumeroExterior.HeaderText = "Numero Exterior";
            this.NumeroExterior.Name = "NumeroExterior";
            this.NumeroExterior.ReadOnly = true;
            this.NumeroExterior.Visible = false;
            // 
            // NumeroInterior
            // 
            this.NumeroInterior.DataPropertyName = "NumeroInterior";
            this.NumeroInterior.HeaderText = "Numero Interior";
            this.NumeroInterior.Name = "NumeroInterior";
            this.NumeroInterior.ReadOnly = true;
            this.NumeroInterior.Visible = false;
            // 
            // Direccion
            // 
            this.Direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Direccion.DataPropertyName = "DireccionCompleta";
            this.Direccion.HeaderText = "Dirección completa";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 113;
            // 
            // Predeterminada
            // 
            this.Predeterminada.DataPropertyName = "Predeterminada";
            this.Predeterminada.HeaderText = "Predeterminada";
            this.Predeterminada.Name = "Predeterminada";
            this.Predeterminada.ReadOnly = true;
            // 
            // DlgUsuariosDirecciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(749, 531);
            this.Controls.Add(this.btnHacerPrincipal);
            this.Controls.Add(this.btnEditarDireccion);
            this.Controls.Add(this.btnAgregarDireccion);
            this.Controls.Add(this.dgvUsuariosDirecciones);
            this.Controls.Add(this.grpUsuario);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgUsuariosDirecciones";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Direcciones del Usuario";
            this.Load += new System.EventHandler(this.DlgUsuariosDirecciones_Load);
            this.grpUsuario.ResumeLayout(false);
            this.grpUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosDirecciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.DataGridView dgvUsuariosDirecciones;
        private System.Windows.Forms.Button btnAgregarDireccion;
        private System.Windows.Forms.Button btnEditarDireccion;
        private System.Windows.Forms.Button btnHacerPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Municipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colonia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPostal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroExterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroInterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Predeterminada;
    }
}
