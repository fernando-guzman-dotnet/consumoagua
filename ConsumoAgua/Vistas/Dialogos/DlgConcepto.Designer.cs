namespace SAPA.Vistas.Dialogos {
    partial class DlgConcepto {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgConcepto));
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.chkAplicaIVA = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.chkImporteFijo = new System.Windows.Forms.CheckBox();
            this.grpDatosConcepto = new System.Windows.Forms.GroupBox();
            this.grpDatosConcepto.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(6, 22);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 32;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(75, 19);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(150, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // chkAplicaIVA
            // 
            this.chkAplicaIVA.AutoSize = true;
            this.chkAplicaIVA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAplicaIVA.Location = new System.Drawing.Point(230, 81);
            this.chkAplicaIVA.Name = "chkAplicaIVA";
            this.chkAplicaIVA.Size = new System.Drawing.Size(87, 17);
            this.chkAplicaIVA.TabIndex = 2;
            this.chkAplicaIVA.Text = "¿Aplica IVA?";
            this.chkAplicaIVA.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(260, 154);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(179, 155);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(75, 45);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(76, 20);
            this.txtImporte.TabIndex = 1;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(27, 48);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(42, 13);
            this.lblImporte.TabIndex = 32;
            this.lblImporte.Text = "Importe";
            // 
            // chkImporteFijo
            // 
            this.chkImporteFijo.AutoSize = true;
            this.chkImporteFijo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkImporteFijo.Location = new System.Drawing.Point(203, 104);
            this.chkImporteFijo.Name = "chkImporteFijo";
            this.chkImporteFijo.Size = new System.Drawing.Size(114, 17);
            this.chkImporteFijo.TabIndex = 2;
            this.chkImporteFijo.Text = "¿El importe es fijo?";
            this.chkImporteFijo.UseVisualStyleBackColor = true;
            // 
            // grpDatosConcepto
            // 
            this.grpDatosConcepto.Controls.Add(this.txtDescripcion);
            this.grpDatosConcepto.Controls.Add(this.txtImporte);
            this.grpDatosConcepto.Controls.Add(this.lblDescripcion);
            this.grpDatosConcepto.Controls.Add(this.chkImporteFijo);
            this.grpDatosConcepto.Controls.Add(this.lblImporte);
            this.grpDatosConcepto.Controls.Add(this.chkAplicaIVA);
            this.grpDatosConcepto.Location = new System.Drawing.Point(12, 12);
            this.grpDatosConcepto.Name = "grpDatosConcepto";
            this.grpDatosConcepto.Size = new System.Drawing.Size(323, 136);
            this.grpDatosConcepto.TabIndex = 33;
            this.grpDatosConcepto.TabStop = false;
            // 
            // DlgConcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(347, 207);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpDatosConcepto);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgConcepto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Concepto";
            this.Load += new System.EventHandler(this.DlgConcepto_Load);
            this.grpDatosConcepto.ResumeLayout(false);
            this.grpDatosConcepto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.CheckBox chkAplicaIVA;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.CheckBox chkImporteFijo;
        private System.Windows.Forms.GroupBox grpDatosConcepto;
    }
}
