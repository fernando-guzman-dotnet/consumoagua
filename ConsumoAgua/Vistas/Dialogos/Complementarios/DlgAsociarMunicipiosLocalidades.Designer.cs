namespace SAPA.Vistas.Dialogos.Complementarios {
    partial class DlgAsociarMunicipiosLocalidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAsociarMunicipiosLocalidades));
            this.dgvLocalidadesAsociadas = new System.Windows.Forms.DataGridView();
            this.dgvLocalidades = new System.Windows.Forms.DataGridView();
            this.btnQuitarLocalidadesTodas = new System.Windows.Forms.Button();
            this.btnQuitarLocalidad = new System.Windows.Forms.Button();
            this.btnAgregarLocalidades = new System.Windows.Forms.Button();
            this.btnAgregarLocalidad = new System.Windows.Forms.Button();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblMunicipio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalidadesAsociadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLocalidadesAsociadas
            // 
            this.dgvLocalidadesAsociadas.AllowUserToAddRows = false;
            this.dgvLocalidadesAsociadas.AllowUserToDeleteRows = false;
            this.dgvLocalidadesAsociadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalidadesAsociadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalidadesAsociadas.Location = new System.Drawing.Point(398, 82);
            this.dgvLocalidadesAsociadas.Name = "dgvLocalidadesAsociadas";
            this.dgvLocalidadesAsociadas.ReadOnly = true;
            this.dgvLocalidadesAsociadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalidadesAsociadas.Size = new System.Drawing.Size(307, 316);
            this.dgvLocalidadesAsociadas.TabIndex = 7;
            this.dgvLocalidadesAsociadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocalidadesAsociadas_CellClick);
            this.dgvLocalidadesAsociadas.SelectionChanged += new System.EventHandler(this.dgvLocalidadesAsociadas_SelectionChanged);
            // 
            // dgvLocalidades
            // 
            this.dgvLocalidades.AllowUserToAddRows = false;
            this.dgvLocalidades.AllowUserToDeleteRows = false;
            this.dgvLocalidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalidades.Location = new System.Drawing.Point(8, 82);
            this.dgvLocalidades.Name = "dgvLocalidades";
            this.dgvLocalidades.ReadOnly = true;
            this.dgvLocalidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalidades.Size = new System.Drawing.Size(307, 316);
            this.dgvLocalidades.TabIndex = 6;
            this.dgvLocalidades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocalidades_CellClick);
            this.dgvLocalidades.SelectionChanged += new System.EventHandler(this.dgvLocalidades_SelectionChanged);
            // 
            // btnQuitarLocalidadesTodas
            // 
            this.btnQuitarLocalidadesTodas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarLocalidadesTodas.Location = new System.Drawing.Point(321, 282);
            this.btnQuitarLocalidadesTodas.Name = "btnQuitarLocalidadesTodas";
            this.btnQuitarLocalidadesTodas.Size = new System.Drawing.Size(71, 23);
            this.btnQuitarLocalidadesTodas.TabIndex = 5;
            this.btnQuitarLocalidadesTodas.Text = "<<";
            this.btnQuitarLocalidadesTodas.UseVisualStyleBackColor = true;
            this.btnQuitarLocalidadesTodas.Visible = false;
            this.btnQuitarLocalidadesTodas.Click += new System.EventHandler(this.btnQuitarLocalidadesTodas_Click);
            // 
            // btnQuitarLocalidad
            // 
            this.btnQuitarLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarLocalidad.Location = new System.Drawing.Point(321, 253);
            this.btnQuitarLocalidad.Name = "btnQuitarLocalidad";
            this.btnQuitarLocalidad.Size = new System.Drawing.Size(71, 23);
            this.btnQuitarLocalidad.TabIndex = 4;
            this.btnQuitarLocalidad.Text = "<";
            this.btnQuitarLocalidad.UseVisualStyleBackColor = true;
            this.btnQuitarLocalidad.Click += new System.EventHandler(this.btnQuitarLocalidad_Click);
            // 
            // btnAgregarLocalidades
            // 
            this.btnAgregarLocalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarLocalidades.Location = new System.Drawing.Point(321, 184);
            this.btnAgregarLocalidades.Name = "btnAgregarLocalidades";
            this.btnAgregarLocalidades.Size = new System.Drawing.Size(71, 23);
            this.btnAgregarLocalidades.TabIndex = 3;
            this.btnAgregarLocalidades.Text = ">>";
            this.btnAgregarLocalidades.UseVisualStyleBackColor = true;
            this.btnAgregarLocalidades.Visible = false;
            this.btnAgregarLocalidades.Click += new System.EventHandler(this.btnAgregarLocalidadesTodas_Click);
            // 
            // btnAgregarLocalidad
            // 
            this.btnAgregarLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarLocalidad.Location = new System.Drawing.Point(321, 155);
            this.btnAgregarLocalidad.Name = "btnAgregarLocalidad";
            this.btnAgregarLocalidad.Size = new System.Drawing.Size(71, 23);
            this.btnAgregarLocalidad.TabIndex = 2;
            this.btnAgregarLocalidad.Text = ">";
            this.btnAgregarLocalidad.UseVisualStyleBackColor = true;
            this.btnAgregarLocalidad.Click += new System.EventHandler(this.btnAgregarLocalidad_Click);
            // 
            // lblNota
            // 
            this.lblNota.Location = new System.Drawing.Point(8, 401);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(307, 39);
            this.lblNota.TabIndex = 12;
            this.lblNota.Text = "* Puede seleccionar más de una opción dejando presionada la tecla CTRL mientras d" +
    "a clic.";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Enabled = false;
            this.txtMunicipio.Location = new System.Drawing.Point(80, 11);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(485, 20);
            this.txtMunicipio.TabIndex = 0;
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
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(67, 56);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(199, 20);
            this.txtLocalidad.TabIndex = 1;
            this.txtLocalidad.TextChanged += new System.EventHandler(this.txtLocalidad_TextChanged);
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(8, 59);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(53, 13);
            this.lblLocalidad.TabIndex = 11;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(22, 15);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(52, 13);
            this.lblMunicipio.TabIndex = 10;
            this.lblMunicipio.Text = "Municipio";
            // 
            // DlgAsociarMunicipiosLocalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(717, 480);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.lblMunicipio);
            this.Controls.Add(this.txtMunicipio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.dgvLocalidadesAsociadas);
            this.Controls.Add(this.dgvLocalidades);
            this.Controls.Add(this.btnQuitarLocalidadesTodas);
            this.Controls.Add(this.btnQuitarLocalidad);
            this.Controls.Add(this.btnAgregarLocalidades);
            this.Controls.Add(this.btnAgregarLocalidad);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgAsociarMunicipiosLocalidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asociar Localidades";
            this.Load += new System.EventHandler(this.DlgAsociarMunicipiosLocalidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalidadesAsociadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLocalidadesAsociadas;
        private System.Windows.Forms.DataGridView dgvLocalidades;
        private System.Windows.Forms.Button btnQuitarLocalidadesTodas;
        private System.Windows.Forms.Button btnQuitarLocalidad;
        private System.Windows.Forms.Button btnAgregarLocalidades;
        private System.Windows.Forms.Button btnAgregarLocalidad;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblMunicipio;
    }
}
