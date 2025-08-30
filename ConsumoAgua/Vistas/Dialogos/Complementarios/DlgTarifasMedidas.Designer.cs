namespace SAPA.Vistas.Dialogos.Complementarios
{
    partial class DlgTarifasMedidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgTarifasMedidas));
            this.lblTarifaActual = new System.Windows.Forms.Label();
            this.txtTarifaActual = new System.Windows.Forms.TextBox();
            this.dgvTarifasMedidas = new System.Windows.Forms.DataGridView();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteMenor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteMayor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Excedente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnAgregarAño = new System.Windows.Forms.Button();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.lblAño = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasMedidas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTarifaActual
            // 
            this.lblTarifaActual.AutoSize = true;
            this.lblTarifaActual.Location = new System.Drawing.Point(12, 32);
            this.lblTarifaActual.Name = "lblTarifaActual";
            this.lblTarifaActual.Size = new System.Drawing.Size(34, 13);
            this.lblTarifaActual.TabIndex = 0;
            this.lblTarifaActual.Text = "Tarifa";
            // 
            // txtTarifaActual
            // 
            this.txtTarifaActual.Enabled = false;
            this.txtTarifaActual.Location = new System.Drawing.Point(53, 28);
            this.txtTarifaActual.Name = "txtTarifaActual";
            this.txtTarifaActual.Size = new System.Drawing.Size(166, 20);
            this.txtTarifaActual.TabIndex = 1;
            // 
            // dgvTarifasMedidas
            // 
            this.dgvTarifasMedidas.AllowUserToResizeRows = false;
            this.dgvTarifasMedidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarifasMedidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.LimiteMenor,
            this.LimiteMayor,
            this.Cantidad,
            this.Excedente});
            this.dgvTarifasMedidas.Location = new System.Drawing.Point(15, 70);
            this.dgvTarifasMedidas.Name = "dgvTarifasMedidas";
            this.dgvTarifasMedidas.Size = new System.Drawing.Size(624, 333);
            this.dgvTarifasMedidas.TabIndex = 2;
            this.dgvTarifasMedidas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTarifasMedidas_EditingControlShowing);
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // LimiteMenor
            // 
            this.LimiteMenor.DataPropertyName = "LimiteMenor";
            this.LimiteMenor.HeaderText = "Limite Menor";
            this.LimiteMenor.Name = "LimiteMenor";
            // 
            // LimiteMayor
            // 
            this.LimiteMayor.DataPropertyName = "LimiteMayor";
            this.LimiteMayor.HeaderText = "Limite Mayor";
            this.LimiteMayor.Name = "LimiteMayor";
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad / Base";
            this.Cantidad.Name = "Cantidad";
            // 
            // Excedente
            // 
            this.Excedente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Excedente.DataPropertyName = "Excedente";
            this.Excedente.HeaderText = "Excedente";
            this.Excedente.Name = "Excedente";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(564, 409);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(483, 409);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 41;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnAgregarAño
            // 
            this.btnAgregarAño.Location = new System.Drawing.Point(566, 27);
            this.btnAgregarAño.Name = "btnAgregarAño";
            this.btnAgregarAño.Size = new System.Drawing.Size(73, 23);
            this.btnAgregarAño.TabIndex = 56;
            this.btnAgregarAño.Text = "Agregar";
            this.btnAgregarAño.UseVisualStyleBackColor = true;
            this.btnAgregarAño.Click += new System.EventHandler(this.btnAgregarAño_Click);
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(468, 28);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(92, 20);
            this.txtAño.TabIndex = 55;
            // 
            // cmbAño
            // 
            this.cmbAño.DisplayMember = "Año";
            this.cmbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Location = new System.Drawing.Point(371, 28);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(91, 21);
            this.cmbAño.TabIndex = 54;
            this.cmbAño.ValueMember = "Año";
            this.cmbAño.SelectedIndexChanged += new System.EventHandler(this.cmbAño_SelectedIndexChanged);
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAño.Location = new System.Drawing.Point(336, 32);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(29, 13);
            this.lblAño.TabIndex = 53;
            this.lblAño.Text = "Año";
            // 
            // DlgTarifasMedidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(651, 452);
            this.Controls.Add(this.btnAgregarAño);
            this.Controls.Add(this.txtAño);
            this.Controls.Add(this.cmbAño);
            this.Controls.Add(this.lblAño);
            this.Controls.Add(this.dgvTarifasMedidas);
            this.Controls.Add(this.txtTarifaActual);
            this.Controls.Add(this.lblTarifaActual);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DlgTarifasMedidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarifas Medidas";
            this.Load += new System.EventHandler(this.DlgTarifasMedidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasMedidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTarifaActual;
        private System.Windows.Forms.TextBox txtTarifaActual;
        private System.Windows.Forms.DataGridView dgvTarifasMedidas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteMenor;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteMayor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Excedente;
        private System.Windows.Forms.Button btnAgregarAño;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.Label lblAño;
    }
}
