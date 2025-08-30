namespace SAPA.Vistas.Dialogos.Complementarios {
    partial class DlgAsociarSectoresColonias {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAsociarSectoresColonias));
            this.dgvColoniasAsociadas = new System.Windows.Forms.DataGridView();
            this.dgvColonias = new System.Windows.Forms.DataGridView();
            this.btnQuitarColoniasTodas = new System.Windows.Forms.Button();
            this.btnQuitarColonia = new System.Windows.Forms.Button();
            this.btnAgregarColonias = new System.Windows.Forms.Button();
            this.btnAgregarColonia = new System.Windows.Forms.Button();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtSector = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtColoniaBuscar = new System.Windows.Forms.TextBox();
            this.lblColoniaBuscar = new System.Windows.Forms.Label();
            this.lblSector = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColoniasAsociadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColonias)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvColoniasAsociadas
            // 
            this.dgvColoniasAsociadas.AllowUserToAddRows = false;
            this.dgvColoniasAsociadas.AllowUserToDeleteRows = false;
            this.dgvColoniasAsociadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColoniasAsociadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColoniasAsociadas.Location = new System.Drawing.Point(398, 82);
            this.dgvColoniasAsociadas.Name = "dgvColoniasAsociadas";
            this.dgvColoniasAsociadas.ReadOnly = true;
            this.dgvColoniasAsociadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColoniasAsociadas.Size = new System.Drawing.Size(307, 316);
            this.dgvColoniasAsociadas.TabIndex = 7;
            this.dgvColoniasAsociadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColoniasAsociadas_CellClick);
            this.dgvColoniasAsociadas.SelectionChanged += new System.EventHandler(this.dgvColoniasAsociadas_SelectionChanged);
            // 
            // dgvColonias
            // 
            this.dgvColonias.AllowUserToAddRows = false;
            this.dgvColonias.AllowUserToDeleteRows = false;
            this.dgvColonias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColonias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColonias.Location = new System.Drawing.Point(8, 82);
            this.dgvColonias.Name = "dgvColonias";
            this.dgvColonias.ReadOnly = true;
            this.dgvColonias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColonias.Size = new System.Drawing.Size(307, 316);
            this.dgvColonias.TabIndex = 6;
            this.dgvColonias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColonias_CellClick);
            this.dgvColonias.SelectionChanged += new System.EventHandler(this.dgvColonias_SelectionChanged);
            // 
            // btnQuitarColoniasTodas
            // 
            this.btnQuitarColoniasTodas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarColoniasTodas.Location = new System.Drawing.Point(321, 282);
            this.btnQuitarColoniasTodas.Name = "btnQuitarColoniasTodas";
            this.btnQuitarColoniasTodas.Size = new System.Drawing.Size(71, 23);
            this.btnQuitarColoniasTodas.TabIndex = 5;
            this.btnQuitarColoniasTodas.Text = "<<";
            this.btnQuitarColoniasTodas.UseVisualStyleBackColor = true;
            this.btnQuitarColoniasTodas.Visible = false;
            this.btnQuitarColoniasTodas.Click += new System.EventHandler(this.btnQuitarColoniasTodas_Click);
            // 
            // btnQuitarColonia
            // 
            this.btnQuitarColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarColonia.Location = new System.Drawing.Point(321, 253);
            this.btnQuitarColonia.Name = "btnQuitarColonia";
            this.btnQuitarColonia.Size = new System.Drawing.Size(71, 23);
            this.btnQuitarColonia.TabIndex = 4;
            this.btnQuitarColonia.Text = "<";
            this.btnQuitarColonia.UseVisualStyleBackColor = true;
            this.btnQuitarColonia.Click += new System.EventHandler(this.btnQuitarColonia_Click);
            // 
            // btnAgregarColonias
            // 
            this.btnAgregarColonias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarColonias.Location = new System.Drawing.Point(321, 184);
            this.btnAgregarColonias.Name = "btnAgregarColonias";
            this.btnAgregarColonias.Size = new System.Drawing.Size(71, 23);
            this.btnAgregarColonias.TabIndex = 3;
            this.btnAgregarColonias.Text = ">>";
            this.btnAgregarColonias.UseVisualStyleBackColor = true;
            this.btnAgregarColonias.Visible = false;
            this.btnAgregarColonias.Click += new System.EventHandler(this.btnAgregarColoniasTodas_Click);
            // 
            // btnAgregarColonia
            // 
            this.btnAgregarColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarColonia.Location = new System.Drawing.Point(321, 155);
            this.btnAgregarColonia.Name = "btnAgregarColonia";
            this.btnAgregarColonia.Size = new System.Drawing.Size(71, 23);
            this.btnAgregarColonia.TabIndex = 2;
            this.btnAgregarColonia.Text = ">";
            this.btnAgregarColonia.UseVisualStyleBackColor = true;
            this.btnAgregarColonia.Click += new System.EventHandler(this.btnAgregarColonia_Click);
            // 
            // lblNota
            // 
            this.lblNota.Location = new System.Drawing.Point(8, 401);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(307, 40);
            this.lblNota.TabIndex = 12;
            this.lblNota.Text = "* Puede seleccionar más de una opción dejando presionada la tecla Ctrl mientras d" +
    "a click.";
            // 
            // txtSector
            // 
            this.txtSector.Enabled = false;
            this.txtSector.Location = new System.Drawing.Point(66, 12);
            this.txtSector.Name = "txtSector";
            this.txtSector.Size = new System.Drawing.Size(485, 20);
            this.txtSector.TabIndex = 0;
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
            // txtColoniaBuscar
            // 
            this.txtColoniaBuscar.Location = new System.Drawing.Point(56, 55);
            this.txtColoniaBuscar.Name = "txtColoniaBuscar";
            this.txtColoniaBuscar.Size = new System.Drawing.Size(199, 20);
            this.txtColoniaBuscar.TabIndex = 1;
            this.txtColoniaBuscar.TextChanged += new System.EventHandler(this.txtColoniaBuscar_TextChanged);
            // 
            // lblColoniaBuscar
            // 
            this.lblColoniaBuscar.AutoSize = true;
            this.lblColoniaBuscar.Location = new System.Drawing.Point(8, 59);
            this.lblColoniaBuscar.Name = "lblColoniaBuscar";
            this.lblColoniaBuscar.Size = new System.Drawing.Size(42, 13);
            this.lblColoniaBuscar.TabIndex = 11;
            this.lblColoniaBuscar.Text = "Colonia";
            // 
            // lblSector
            // 
            this.lblSector.AutoSize = true;
            this.lblSector.Location = new System.Drawing.Point(22, 15);
            this.lblSector.Name = "lblSector";
            this.lblSector.Size = new System.Drawing.Size(38, 13);
            this.lblSector.TabIndex = 10;
            this.lblSector.Text = "Sector";
            // 
            // DlgAsociarSectoresColonias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(717, 480);
            this.Controls.Add(this.txtColoniaBuscar);
            this.Controls.Add(this.lblColoniaBuscar);
            this.Controls.Add(this.lblSector);
            this.Controls.Add(this.txtSector);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.dgvColoniasAsociadas);
            this.Controls.Add(this.dgvColonias);
            this.Controls.Add(this.btnQuitarColoniasTodas);
            this.Controls.Add(this.btnQuitarColonia);
            this.Controls.Add(this.btnAgregarColonias);
            this.Controls.Add(this.btnAgregarColonia);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgAsociarSectoresColonias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asociar Sectores";
            this.Load += new System.EventHandler(this.DlgAsociarSectoresColonias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColoniasAsociadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColonias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvColoniasAsociadas;
        private System.Windows.Forms.DataGridView dgvColonias;
        private System.Windows.Forms.Button btnQuitarColoniasTodas;
        private System.Windows.Forms.Button btnQuitarColonia;
        private System.Windows.Forms.Button btnAgregarColonias;
        private System.Windows.Forms.Button btnAgregarColonia;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtSector;
        private System.Windows.Forms.TextBox txtColoniaBuscar;
        private System.Windows.Forms.Label lblColoniaBuscar;
        private System.Windows.Forms.Label lblSector;
    }
}
