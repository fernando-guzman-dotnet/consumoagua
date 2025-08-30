namespace SAPA.Vistas
{
    partial class FrmSituacionActualContratos
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvSituacionActualContratos = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.chkUsarRespaldo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSituacionActualContratos)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(1021, 460);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(109, 35);
            this.btnExportar.TabIndex = 31;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvSituacionActualContratos
            // 
            this.dgvSituacionActualContratos.AllowUserToAddRows = false;
            this.dgvSituacionActualContratos.AllowUserToDeleteRows = false;
            this.dgvSituacionActualContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSituacionActualContratos.Location = new System.Drawing.Point(12, 77);
            this.dgvSituacionActualContratos.Name = "dgvSituacionActualContratos";
            this.dgvSituacionActualContratos.ReadOnly = true;
            this.dgvSituacionActualContratos.Size = new System.Drawing.Size(1118, 377);
            this.dgvSituacionActualContratos.TabIndex = 30;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1142, 33);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 32;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // chkUsarRespaldo
            // 
            this.chkUsarRespaldo.AutoSize = true;
            this.chkUsarRespaldo.Checked = true;
            this.chkUsarRespaldo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUsarRespaldo.Location = new System.Drawing.Point(13, 54);
            this.chkUsarRespaldo.Name = "chkUsarRespaldo";
            this.chkUsarRespaldo.Size = new System.Drawing.Size(214, 17);
            this.chkUsarRespaldo.TabIndex = 33;
            this.chkUsarRespaldo.Text = "Usar respaldo almacenado de deudores";
            this.chkUsarRespaldo.UseVisualStyleBackColor = true;
            this.chkUsarRespaldo.CheckedChanged += new System.EventHandler(this.chkCalcularEnTiempoReal_CheckedChanged);
            // 
            // FrmSituacionActualContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1142, 507);
            this.Controls.Add(this.chkUsarRespaldo);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvSituacionActualContratos);
            this.Controls.Add(this.btnExportar);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSituacionActualContratos";
            this.Text = "Situación Actual Contratos";
            this.Load += new System.EventHandler(this.FrmSituacionActualContratos_Load);
            this.Shown += new System.EventHandler(this.FrmSituacionActualContratos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSituacionActualContratos)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgvSituacionActualContratos;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.CheckBox chkUsarRespaldo;
    }
}
