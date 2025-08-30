namespace SAPA.Vistas.Dialogos.Complementarios
{
    partial class DlgVerBitacoraOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgVerBitacoraOrden));
            this.dgvRegistrosBitacora = new System.Windows.Forms.DataGridView();
            this.lblNoOrden = new System.Windows.Forms.Label();
            this.lblNoContrato = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRegistrosBitacora
            // 
            this.dgvRegistrosBitacora.AllowUserToAddRows = false;
            this.dgvRegistrosBitacora.AllowUserToDeleteRows = false;
            this.dgvRegistrosBitacora.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistrosBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistrosBitacora.Location = new System.Drawing.Point(12, 56);
            this.dgvRegistrosBitacora.Name = "dgvRegistrosBitacora";
            this.dgvRegistrosBitacora.ReadOnly = true;
            this.dgvRegistrosBitacora.Size = new System.Drawing.Size(892, 383);
            this.dgvRegistrosBitacora.TabIndex = 0;
            // 
            // lblNoOrden
            // 
            this.lblNoOrden.AutoSize = true;
            this.lblNoOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOrden.Location = new System.Drawing.Point(12, 9);
            this.lblNoOrden.Name = "lblNoOrden";
            this.lblNoOrden.Size = new System.Drawing.Size(201, 24);
            this.lblNoOrden.TabIndex = 1;
            this.lblNoOrden.Text = "BITACORA Orden # ";
            // 
            // lblNoContrato
            // 
            this.lblNoContrato.AutoSize = true;
            this.lblNoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoContrato.Location = new System.Drawing.Point(12, 33);
            this.lblNoContrato.Name = "lblNoContrato";
            this.lblNoContrato.Size = new System.Drawing.Size(84, 20);
            this.lblNoContrato.TabIndex = 1;
            this.lblNoContrato.Text = "Contrato #";
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(748, 445);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 39);
            this.btnAceptar.TabIndex = 45;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCancelar.Location = new System.Drawing.Point(829, 445);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 46;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // DlgVerBitacoraOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(916, 496);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblNoContrato);
            this.Controls.Add(this.lblNoOrden);
            this.Controls.Add(this.dgvRegistrosBitacora);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgVerBitacoraOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Bitacora";
            this.Load += new System.EventHandler(this.DlgVerBitacoraOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegistrosBitacora;
        private System.Windows.Forms.Label lblNoOrden;
        private System.Windows.Forms.Label lblNoContrato;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
