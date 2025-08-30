namespace SAPA.Vistas.Dialogos.Complementarios
{
    partial class DlgTarifasConceptos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgTarifasConceptos));
            this.txtTarifaActual = new System.Windows.Forms.TextBox();
            this.lblTarifaActual = new System.Windows.Forms.Label();
            this.dgvTarifasConceptos = new System.Windows.Forms.DataGridView();
            this.TarifaConcepto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTarifaActual
            // 
            this.txtTarifaActual.Enabled = false;
            this.txtTarifaActual.Location = new System.Drawing.Point(53, 18);
            this.txtTarifaActual.Name = "txtTarifaActual";
            this.txtTarifaActual.Size = new System.Drawing.Size(310, 20);
            this.txtTarifaActual.TabIndex = 3;
            // 
            // lblTarifaActual
            // 
            this.lblTarifaActual.AutoSize = true;
            this.lblTarifaActual.Location = new System.Drawing.Point(12, 22);
            this.lblTarifaActual.Name = "lblTarifaActual";
            this.lblTarifaActual.Size = new System.Drawing.Size(34, 13);
            this.lblTarifaActual.TabIndex = 2;
            this.lblTarifaActual.Text = "Tarifa";
            // 
            // dgvTarifasConceptos
            // 
            this.dgvTarifasConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarifasConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TarifaConcepto,
            this.Cantidad});
            this.dgvTarifasConceptos.Location = new System.Drawing.Point(15, 57);
            this.dgvTarifasConceptos.Name = "dgvTarifasConceptos";
            this.dgvTarifasConceptos.Size = new System.Drawing.Size(621, 301);
            this.dgvTarifasConceptos.TabIndex = 4;
            this.dgvTarifasConceptos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTarifasConceptos_EditingControlShowing);
            // 
            // TarifaConcepto
            // 
            this.TarifaConcepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TarifaConcepto.DataPropertyName = "IdConcepto";
            dataGridViewCellStyle1.NullValue = "[ -- SELECCIONAR -- ]";
            this.TarifaConcepto.DefaultCellStyle = dataGridViewCellStyle1;
            this.TarifaConcepto.HeaderText = "Concepto";
            this.TarifaConcepto.Name = "TarifaConcepto";
            this.TarifaConcepto.Width = 137;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(480, 364);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 43;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(561, 364);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 44;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // DlgTarifasConceptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(648, 419);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvTarifasConceptos);
            this.Controls.Add(this.txtTarifaActual);
            this.Controls.Add(this.lblTarifaActual);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DlgTarifasConceptos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conceptos Tarifa";
            this.Load += new System.EventHandler(this.DlgTarifasConceptos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarifasConceptos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTarifaActual;
        private System.Windows.Forms.Label lblTarifaActual;
        private System.Windows.Forms.DataGridView dgvTarifasConceptos;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewComboBoxColumn TarifaConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
    }
}
