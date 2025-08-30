namespace SAPA.Vistas
{
    partial class FrmListadoLecturas
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
            this.cmbRuta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrdenInicial = new System.Windows.Forms.TextBox();
            this.txtOrdenFinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIncluirSuspendidas = new System.Windows.Forms.CheckBox();
            this.btnVerReporte = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbRuta
            // 
            this.cmbRuta.FormattingEnabled = true;
            this.cmbRuta.Location = new System.Drawing.Point(116, 33);
            this.cmbRuta.Name = "cmbRuta";
            this.cmbRuta.Size = new System.Drawing.Size(100, 21);
            this.cmbRuta.TabIndex = 0;
            this.cmbRuta.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta";
            this.label1.Visible = false;
            // 
            // txtOrdenInicial
            // 
            this.txtOrdenInicial.Location = new System.Drawing.Point(116, 75);
            this.txtOrdenInicial.Name = "txtOrdenInicial";
            this.txtOrdenInicial.Size = new System.Drawing.Size(100, 20);
            this.txtOrdenInicial.TabIndex = 2;
            this.txtOrdenInicial.Visible = false;
            // 
            // txtOrdenFinal
            // 
            this.txtOrdenFinal.Location = new System.Drawing.Point(116, 116);
            this.txtOrdenFinal.Name = "txtOrdenFinal";
            this.txtOrdenFinal.Size = new System.Drawing.Size(100, 20);
            this.txtOrdenFinal.TabIndex = 2;
            this.txtOrdenFinal.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Orden Inicial";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Orden Final";
            this.label3.Visible = false;
            // 
            // chkIncluirSuspendidas
            // 
            this.chkIncluirSuspendidas.AutoSize = true;
            this.chkIncluirSuspendidas.Location = new System.Drawing.Point(82, 227);
            this.chkIncluirSuspendidas.Name = "chkIncluirSuspendidas";
            this.chkIncluirSuspendidas.Size = new System.Drawing.Size(118, 17);
            this.chkIncluirSuspendidas.TabIndex = 3;
            this.chkIncluirSuspendidas.Text = "Incluir Suspendidos";
            this.chkIncluirSuspendidas.UseVisualStyleBackColor = true;
            // 
            // btnVerReporte
            // 
            this.btnVerReporte.Location = new System.Drawing.Point(46, 284);
            this.btnVerReporte.Name = "btnVerReporte";
            this.btnVerReporte.Size = new System.Drawing.Size(75, 23);
            this.btnVerReporte.TabIndex = 4;
            this.btnVerReporte.Text = "Ver Reporte";
            this.btnVerReporte.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(141, 284);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(116, 159);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaInicial.TabIndex = 5;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(115, 185);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaFinal.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Periodo";
            // 
            // frmListadoParaLecturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 349);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnVerReporte);
            this.Controls.Add(this.chkIncluirSuspendidas);
            this.Controls.Add(this.txtOrdenFinal);
            this.Controls.Add(this.txtOrdenInicial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRuta);
            this.Name = "frmListadoParaLecturas";
            this.Text = "Reporte Para Lecturas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRuta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrdenInicial;
        private System.Windows.Forms.TextBox txtOrdenFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIncluirSuspendidas;
        private System.Windows.Forms.Button btnVerReporte;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label4;
    }
}
