namespace SAPA.Vistas.Dialogos {
    partial class DlgTarifa {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgTarifa));
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.grpDatosTarifa = new System.Windows.Forms.GroupBox();
            this.chkGeneraIVA = new System.Windows.Forms.CheckBox();
            this.grpDatosTarifa.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(14, 22);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 26;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(83, 19);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(150, 20);
            this.txtDescripcion.TabIndex = 23;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(186, 108);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 38;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSize = true;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAgregar.Location = new System.Drawing.Point(105, 108);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 39);
            this.btnAgregar.TabIndex = 37;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // grpDatosTarifa
            // 
            this.grpDatosTarifa.Controls.Add(this.chkGeneraIVA);
            this.grpDatosTarifa.Controls.Add(this.txtDescripcion);
            this.grpDatosTarifa.Controls.Add(this.lblDescripcion);
            this.grpDatosTarifa.Location = new System.Drawing.Point(12, 12);
            this.grpDatosTarifa.Name = "grpDatosTarifa";
            this.grpDatosTarifa.Size = new System.Drawing.Size(249, 90);
            this.grpDatosTarifa.TabIndex = 39;
            this.grpDatosTarifa.TabStop = false;
            // 
            // chkGeneraIVA
            // 
            this.chkGeneraIVA.AutoSize = true;
            this.chkGeneraIVA.Location = new System.Drawing.Point(140, 55);
            this.chkGeneraIVA.Name = "chkGeneraIVA";
            this.chkGeneraIVA.Size = new System.Drawing.Size(93, 17);
            this.chkGeneraIVA.TabIndex = 27;
            this.chkGeneraIVA.Text = "¿Genera IVA?";
            this.chkGeneraIVA.UseVisualStyleBackColor = true;
            // 
            // DlgTarifa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(273, 155);
            this.Controls.Add(this.grpDatosTarifa);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCancelar);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgTarifa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarifa";
            this.Load += new System.EventHandler(this.Dialog_Tarifa_Load);
            this.grpDatosTarifa.ResumeLayout(false);
            this.grpDatosTarifa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox grpDatosTarifa;
        private System.Windows.Forms.CheckBox chkGeneraIVA;
    }
}
