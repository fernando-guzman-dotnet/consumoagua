namespace SAPA.Vistas
{
    partial class FrmDeudores
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.chkUsarFiltroExperimental = new System.Windows.Forms.CheckBox();
            this.cmbColonias = new System.Windows.Forms.ComboBox();
            this.lblColonia = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvDeudores = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudores)).BeginInit();
            this.SuspendLayout();
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
            this.toolStrip.Size = new System.Drawing.Size(1004, 33);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 8;
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
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.chkUsarFiltroExperimental);
            this.grpFiltros.Controls.Add(this.cmbColonias);
            this.grpFiltros.Controls.Add(this.lblColonia);
            this.grpFiltros.Controls.Add(this.btnGenerar);
            this.grpFiltros.Location = new System.Drawing.Point(12, 49);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(980, 55);
            this.grpFiltros.TabIndex = 14;
            this.grpFiltros.TabStop = false;
            // 
            // chkUsarFiltroExperimental
            // 
            this.chkUsarFiltroExperimental.AutoSize = true;
            this.chkUsarFiltroExperimental.Location = new System.Drawing.Point(252, 23);
            this.chkUsarFiltroExperimental.Name = "chkUsarFiltroExperimental";
            this.chkUsarFiltroExperimental.Size = new System.Drawing.Size(144, 17);
            this.chkUsarFiltroExperimental.TabIndex = 30;
            this.chkUsarFiltroExperimental.Text = "¿Usar filtro experimental?";
            this.toolTip.SetToolTip(this.chkUsarFiltroExperimental, "Usar este filtro podría reducir el numero de registros que se cargan, haciendo qu" +
        "e se genere más rapido la lista.");
            this.chkUsarFiltroExperimental.UseVisualStyleBackColor = true;
            // 
            // cmbColonias
            // 
            this.cmbColonias.FormattingEnabled = true;
            this.cmbColonias.Location = new System.Drawing.Point(54, 21);
            this.cmbColonias.Name = "cmbColonias";
            this.cmbColonias.Size = new System.Drawing.Size(192, 21);
            this.cmbColonias.TabIndex = 29;
            // 
            // lblColonia
            // 
            this.lblColonia.AutoSize = true;
            this.lblColonia.Location = new System.Drawing.Point(6, 25);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(42, 13);
            this.lblColonia.TabIndex = 1;
            this.lblColonia.Text = "Colonia";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(853, 14);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(109, 35);
            this.btnGenerar.TabIndex = 28;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dgvDeudores
            // 
            this.dgvDeudores.AllowUserToAddRows = false;
            this.dgvDeudores.AllowUserToDeleteRows = false;
            this.dgvDeudores.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeudores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeudores.Location = new System.Drawing.Point(12, 110);
            this.dgvDeudores.Name = "dgvDeudores";
            this.dgvDeudores.ReadOnly = true;
            this.dgvDeudores.Size = new System.Drawing.Size(980, 335);
            this.dgvDeudores.TabIndex = 15;
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(883, 451);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(109, 35);
            this.btnExportar.TabIndex = 30;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // FrmDeudores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1004, 500);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.dgvDeudores);
            this.Controls.Add(this.toolStrip);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDeudores";
            this.Text = "Deudores";
            this.Load += new System.EventHandler(this.FrmDeudores_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.ComboBox cmbColonias;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvDeudores;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.CheckBox chkUsarFiltroExperimental;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
