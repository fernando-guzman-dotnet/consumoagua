using System.Windows.Forms;

namespace SAPA.Vistas.Dialogos.Complementarios {
    partial class DlgAsociarColoniasCalles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAsociarColoniasCalles));
            this.dgvCallesAsociadas = new System.Windows.Forms.DataGridView();
            this.dgvCallesDisponibles = new System.Windows.Forms.DataGridView();
            this.btnQuitarCalle = new System.Windows.Forms.Button();
            this.btnAgregarCalle = new System.Windows.Forms.Button();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCalleBuscar = new System.Windows.Forms.TextBox();
            this.lblCalleBuscar = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblEncabezadoCallesDisponibles = new System.Windows.Forms.Label();
            this.lblEncabezadoCallesAsociadas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCallesAsociadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCallesDisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCallesAsociadas
            // 
            this.dgvCallesAsociadas.AllowUserToAddRows = false;
            this.dgvCallesAsociadas.AllowUserToDeleteRows = false;
            this.dgvCallesAsociadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCallesAsociadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCallesAsociadas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCallesAsociadas.Location = new System.Drawing.Point(402, 114);
            this.dgvCallesAsociadas.Name = "dgvCallesAsociadas";
            this.dgvCallesAsociadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCallesAsociadas.Size = new System.Drawing.Size(307, 316);
            this.dgvCallesAsociadas.TabIndex = 7;
            this.dgvCallesAsociadas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvColoniasAsociadas_EditingControlShowing);
            this.dgvCallesAsociadas.SelectionChanged += new System.EventHandler(this.dgvColoniasAsociadas_SelectionChanged);
            // 
            // dgvCallesDisponibles
            // 
            this.dgvCallesDisponibles.AllowUserToAddRows = false;
            this.dgvCallesDisponibles.AllowUserToDeleteRows = false;
            this.dgvCallesDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCallesDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCallesDisponibles.Location = new System.Drawing.Point(12, 114);
            this.dgvCallesDisponibles.Name = "dgvCallesDisponibles";
            this.dgvCallesDisponibles.ReadOnly = true;
            this.dgvCallesDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCallesDisponibles.Size = new System.Drawing.Size(307, 316);
            this.dgvCallesDisponibles.TabIndex = 6;
            this.dgvCallesDisponibles.SelectionChanged += new System.EventHandler(this.dgvColonias_SelectionChanged);
            // 
            // btnQuitarCalle
            // 
            this.btnQuitarCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarCalle.Location = new System.Drawing.Point(325, 285);
            this.btnQuitarCalle.Name = "btnQuitarCalle";
            this.btnQuitarCalle.Size = new System.Drawing.Size(71, 23);
            this.btnQuitarCalle.TabIndex = 4;
            this.btnQuitarCalle.Text = "<<";
            this.btnQuitarCalle.UseVisualStyleBackColor = true;
            this.btnQuitarCalle.Click += new System.EventHandler(this.btnQuitarCalle_Click);
            // 
            // btnAgregarCalle
            // 
            this.btnAgregarCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCalle.Location = new System.Drawing.Point(325, 256);
            this.btnAgregarCalle.Name = "btnAgregarCalle";
            this.btnAgregarCalle.Size = new System.Drawing.Size(71, 23);
            this.btnAgregarCalle.TabIndex = 2;
            this.btnAgregarCalle.Text = ">>";
            this.btnAgregarCalle.UseVisualStyleBackColor = true;
            this.btnAgregarCalle.Click += new System.EventHandler(this.btnAgregarCalle_Click);
            // 
            // lblNota
            // 
            this.lblNota.Location = new System.Drawing.Point(9, 433);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(310, 43);
            this.lblNota.TabIndex = 12;
            this.lblNota.Text = "* Puede seleccionar más de una opción dejando presionada la tecla CTRL mientras d" +
    "a click.";
            // 
            // txtColonia
            // 
            this.txtColonia.Enabled = false;
            this.txtColonia.Location = new System.Drawing.Point(66, 12);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(558, 20);
            this.txtColonia.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(634, 438);
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
            this.btnAceptar.Location = new System.Drawing.Point(553, 438);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCalleBuscar
            // 
            this.txtCalleBuscar.Location = new System.Drawing.Point(60, 55);
            this.txtCalleBuscar.Name = "txtCalleBuscar";
            this.txtCalleBuscar.Size = new System.Drawing.Size(199, 20);
            this.txtCalleBuscar.TabIndex = 1;
            this.txtCalleBuscar.TextChanged += new System.EventHandler(this.txtColoniaBuscar_TextChanged);
            // 
            // lblCalleBuscar
            // 
            this.lblCalleBuscar.AutoSize = true;
            this.lblCalleBuscar.Location = new System.Drawing.Point(24, 59);
            this.lblCalleBuscar.Name = "lblCalleBuscar";
            this.lblCalleBuscar.Size = new System.Drawing.Size(30, 13);
            this.lblCalleBuscar.TabIndex = 11;
            this.lblCalleBuscar.Text = "Calle";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(18, 16);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(42, 13);
            this.lblCalle.TabIndex = 10;
            this.lblCalle.Text = "Colonia";
            // 
            // lblEncabezadoCallesDisponibles
            // 
            this.lblEncabezadoCallesDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezadoCallesDisponibles.Location = new System.Drawing.Point(12, 88);
            this.lblEncabezadoCallesDisponibles.Name = "lblEncabezadoCallesDisponibles";
            this.lblEncabezadoCallesDisponibles.Size = new System.Drawing.Size(307, 23);
            this.lblEncabezadoCallesDisponibles.TabIndex = 13;
            this.lblEncabezadoCallesDisponibles.Text = "CALLES DISPONIBLES";
            this.lblEncabezadoCallesDisponibles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEncabezadoCallesAsociadas
            // 
            this.lblEncabezadoCallesAsociadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezadoCallesAsociadas.Location = new System.Drawing.Point(402, 88);
            this.lblEncabezadoCallesAsociadas.Name = "lblEncabezadoCallesAsociadas";
            this.lblEncabezadoCallesAsociadas.Size = new System.Drawing.Size(307, 23);
            this.lblEncabezadoCallesAsociadas.TabIndex = 13;
            this.lblEncabezadoCallesAsociadas.Text = "CALLES ASOCIADAS";
            this.lblEncabezadoCallesAsociadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DlgAsociarColoniasCalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(717, 489);
            this.Controls.Add(this.lblEncabezadoCallesAsociadas);
            this.Controls.Add(this.lblEncabezadoCallesDisponibles);
            this.Controls.Add(this.txtCalleBuscar);
            this.Controls.Add(this.lblCalleBuscar);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.txtColonia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.dgvCallesAsociadas);
            this.Controls.Add(this.dgvCallesDisponibles);
            this.Controls.Add(this.btnQuitarCalle);
            this.Controls.Add(this.btnAgregarCalle);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgAsociarColoniasCalles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asociar Calles";
            this.Load += new System.EventHandler(this.DlgAsociarColoniasCalles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCallesAsociadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCallesDisponibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCallesAsociadas;
        private System.Windows.Forms.DataGridView dgvCallesDisponibles;
        private System.Windows.Forms.Button btnQuitarCalle;
        private System.Windows.Forms.Button btnAgregarCalle;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.TextBox txtCalleBuscar;
        private System.Windows.Forms.Label lblCalleBuscar;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblEncabezadoCallesDisponibles;
        private System.Windows.Forms.Label lblEncabezadoCallesAsociadas;
    }
}
