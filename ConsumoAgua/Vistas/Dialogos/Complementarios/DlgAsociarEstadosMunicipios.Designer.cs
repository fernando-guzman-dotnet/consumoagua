namespace SAPA.Vistas.Dialogos.Complementarios {
    partial class DlgAsociarEstadosMunicipios
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAsociarEstadosMunicipios));
            this.dgvMunicipiosAsociados = new System.Windows.Forms.DataGridView();
            this.dgvMunicipios = new System.Windows.Forms.DataGridView();
            this.btnQuitarMunicipiosTodos = new System.Windows.Forms.Button();
            this.btnQuitarMunicipio = new System.Windows.Forms.Button();
            this.btnAgregarMunicipioTodos = new System.Windows.Forms.Button();
            this.btnAgregarMunicipio = new System.Windows.Forms.Button();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMunicipiosAsociados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMunicipios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMunicipiosAsociados
            // 
            this.dgvMunicipiosAsociados.AllowUserToAddRows = false;
            this.dgvMunicipiosAsociados.AllowUserToDeleteRows = false;
            this.dgvMunicipiosAsociados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMunicipiosAsociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMunicipiosAsociados.Location = new System.Drawing.Point(398, 82);
            this.dgvMunicipiosAsociados.Name = "dgvMunicipiosAsociados";
            this.dgvMunicipiosAsociados.ReadOnly = true;
            this.dgvMunicipiosAsociados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMunicipiosAsociados.Size = new System.Drawing.Size(307, 316);
            this.dgvMunicipiosAsociados.TabIndex = 7;
            this.dgvMunicipiosAsociados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMunicipiosAsociados_CellClick);
            this.dgvMunicipiosAsociados.SelectionChanged += new System.EventHandler(this.dgvMunicipiosAsociados_SelectionChanged);
            // 
            // dgvMunicipios
            // 
            this.dgvMunicipios.AllowUserToAddRows = false;
            this.dgvMunicipios.AllowUserToDeleteRows = false;
            this.dgvMunicipios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMunicipios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMunicipios.Location = new System.Drawing.Point(8, 82);
            this.dgvMunicipios.Name = "dgvMunicipios";
            this.dgvMunicipios.ReadOnly = true;
            this.dgvMunicipios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMunicipios.Size = new System.Drawing.Size(307, 316);
            this.dgvMunicipios.TabIndex = 6;
            this.dgvMunicipios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMunicipios_CellClick);
            this.dgvMunicipios.SelectionChanged += new System.EventHandler(this.dgvMunicipios_SelectionChanged);
            // 
            // btnQuitarMunicipiosTodos
            // 
            this.btnQuitarMunicipiosTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarMunicipiosTodos.Location = new System.Drawing.Point(321, 282);
            this.btnQuitarMunicipiosTodos.Name = "btnQuitarMunicipiosTodos";
            this.btnQuitarMunicipiosTodos.Size = new System.Drawing.Size(71, 23);
            this.btnQuitarMunicipiosTodos.TabIndex = 5;
            this.btnQuitarMunicipiosTodos.Text = "<<";
            this.btnQuitarMunicipiosTodos.UseVisualStyleBackColor = true;
            this.btnQuitarMunicipiosTodos.Visible = false;
            this.btnQuitarMunicipiosTodos.Click += new System.EventHandler(this.btnQuitarMunicipiosTodos_Click);
            // 
            // btnQuitarMunicipio
            // 
            this.btnQuitarMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarMunicipio.Location = new System.Drawing.Point(321, 253);
            this.btnQuitarMunicipio.Name = "btnQuitarMunicipio";
            this.btnQuitarMunicipio.Size = new System.Drawing.Size(71, 23);
            this.btnQuitarMunicipio.TabIndex = 4;
            this.btnQuitarMunicipio.Text = "<";
            this.btnQuitarMunicipio.UseVisualStyleBackColor = true;
            this.btnQuitarMunicipio.Click += new System.EventHandler(this.btnQuitarMunicipios_Click);
            // 
            // btnAgregarMunicipioTodos
            // 
            this.btnAgregarMunicipioTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMunicipioTodos.Location = new System.Drawing.Point(321, 184);
            this.btnAgregarMunicipioTodos.Name = "btnAgregarMunicipioTodos";
            this.btnAgregarMunicipioTodos.Size = new System.Drawing.Size(71, 23);
            this.btnAgregarMunicipioTodos.TabIndex = 3;
            this.btnAgregarMunicipioTodos.Text = ">>";
            this.btnAgregarMunicipioTodos.UseVisualStyleBackColor = true;
            this.btnAgregarMunicipioTodos.Visible = false;
            this.btnAgregarMunicipioTodos.Click += new System.EventHandler(this.btnAgregarMunicipiosTodos_Click);
            // 
            // btnAgregarMunicipio
            // 
            this.btnAgregarMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMunicipio.Location = new System.Drawing.Point(321, 155);
            this.btnAgregarMunicipio.Name = "btnAgregarMunicipio";
            this.btnAgregarMunicipio.Size = new System.Drawing.Size(71, 23);
            this.btnAgregarMunicipio.TabIndex = 2;
            this.btnAgregarMunicipio.Text = ">";
            this.btnAgregarMunicipio.UseVisualStyleBackColor = true;
            this.btnAgregarMunicipio.Click += new System.EventHandler(this.btnAgregarMunicipio_Click);
            // 
            // lblNota
            // 
            this.lblNota.Location = new System.Drawing.Point(8, 401);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(307, 37);
            this.lblNota.TabIndex = 12;
            this.lblNota.Text = "* Puede seleccionar más de una opción dejando presionada la tecla CTRL mientras d" +
    "a clic.";
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(66, 16);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(485, 20);
            this.txtEstado.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(630, 429);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(549, 429);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Location = new System.Drawing.Point(66, 55);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(199, 20);
            this.txtMunicipio.TabIndex = 1;
            this.txtMunicipio.TextChanged += new System.EventHandler(this.txtMunicipio_TextChanged);
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(8, 59);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(52, 13);
            this.lblMunicipio.TabIndex = 11;
            this.lblMunicipio.Text = "Municipio";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(20, 19);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado";
            // 
            // DlgAsociarEstadosMunicipios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(717, 480);
            this.Controls.Add(this.txtMunicipio);
            this.Controls.Add(this.lblMunicipio);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.dgvMunicipiosAsociados);
            this.Controls.Add(this.dgvMunicipios);
            this.Controls.Add(this.btnQuitarMunicipiosTodos);
            this.Controls.Add(this.btnQuitarMunicipio);
            this.Controls.Add(this.btnAgregarMunicipioTodos);
            this.Controls.Add(this.btnAgregarMunicipio);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgAsociarEstadosMunicipios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asociar Municipios";
            this.Load += new System.EventHandler(this.DlgAsociarEstadosMunicipios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMunicipiosAsociados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMunicipios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMunicipiosAsociados;
        private System.Windows.Forms.DataGridView dgvMunicipios;
        private System.Windows.Forms.Button btnQuitarMunicipiosTodos;
        private System.Windows.Forms.Button btnQuitarMunicipio;
        private System.Windows.Forms.Button btnAgregarMunicipioTodos;
        private System.Windows.Forms.Button btnAgregarMunicipio;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblEstado;
    }
}
