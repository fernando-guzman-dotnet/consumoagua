namespace SAPA.Vistas
{
    partial class FrmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracion));
            this.grpVariablesCobro = new System.Windows.Forms.GroupBox();
            this.lblLimiteAñosCobro = new System.Windows.Forms.Label();
            this.numLimiteAñosCobro = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblLimiteBimestresVencidos = new System.Windows.Forms.Label();
            this.numLimiteBimestresVencidos = new System.Windows.Forms.NumericUpDown();
            this.grpVariablesCobro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimiteAñosCobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLimiteBimestresVencidos)).BeginInit();
            this.SuspendLayout();
            // 
            // grpVariablesCobro
            // 
            this.grpVariablesCobro.Controls.Add(this.lblLimiteBimestresVencidos);
            this.grpVariablesCobro.Controls.Add(this.numLimiteBimestresVencidos);
            this.grpVariablesCobro.Controls.Add(this.lblLimiteAñosCobro);
            this.grpVariablesCobro.Controls.Add(this.numLimiteAñosCobro);
            this.grpVariablesCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVariablesCobro.Location = new System.Drawing.Point(12, 12);
            this.grpVariablesCobro.Name = "grpVariablesCobro";
            this.grpVariablesCobro.Size = new System.Drawing.Size(265, 184);
            this.grpVariablesCobro.TabIndex = 0;
            this.grpVariablesCobro.TabStop = false;
            this.grpVariablesCobro.Text = "VARIABLES PARA COBRO";
            // 
            // lblLimiteAñosCobro
            // 
            this.lblLimiteAñosCobro.AutoSize = true;
            this.lblLimiteAñosCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLimiteAñosCobro.Location = new System.Drawing.Point(28, 35);
            this.lblLimiteAñosCobro.Name = "lblLimiteAñosCobro";
            this.lblLimiteAñosCobro.Size = new System.Drawing.Size(105, 13);
            this.lblLimiteAñosCobro.TabIndex = 0;
            this.lblLimiteAñosCobro.Text = "Limite años de cobro";
            // 
            // numLimiteAñosCobro
            // 
            this.numLimiteAñosCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLimiteAñosCobro.Location = new System.Drawing.Point(139, 31);
            this.numLimiteAñosCobro.Name = "numLimiteAñosCobro";
            this.numLimiteAñosCobro.Size = new System.Drawing.Size(48, 20);
            this.numLimiteAñosCobro.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Image = global::SAPA.Properties.Resources.Aceptar;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(138, 202);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(139, 46);
            this.btnActualizar.TabIndex = 14;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblLimiteBimestresVencidos
            // 
            this.lblLimiteBimestresVencidos.AutoSize = true;
            this.lblLimiteBimestresVencidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLimiteBimestresVencidos.Location = new System.Drawing.Point(6, 57);
            this.lblLimiteBimestresVencidos.Name = "lblLimiteBimestresVencidos";
            this.lblLimiteBimestresVencidos.Size = new System.Drawing.Size(127, 13);
            this.lblLimiteBimestresVencidos.TabIndex = 2;
            this.lblLimiteBimestresVencidos.Text = "Limite bimestres vencidos";
            // 
            // numLimiteBimestresVencidos
            // 
            this.numLimiteBimestresVencidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLimiteBimestresVencidos.Location = new System.Drawing.Point(139, 55);
            this.numLimiteBimestresVencidos.Name = "numLimiteBimestresVencidos";
            this.numLimiteBimestresVencidos.Size = new System.Drawing.Size(48, 20);
            this.numLimiteBimestresVencidos.TabIndex = 3;
            this.numLimiteBimestresVencidos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 260);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.grpVariablesCobro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmConfiguracion";
            this.Text = "Configuración del sistema";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConfiguracion_FormClosing);
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            this.grpVariablesCobro.ResumeLayout(false);
            this.grpVariablesCobro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimiteAñosCobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLimiteBimestresVencidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpVariablesCobro;
        private System.Windows.Forms.Label lblLimiteAñosCobro;
        private System.Windows.Forms.NumericUpDown numLimiteAñosCobro;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblLimiteBimestresVencidos;
        private System.Windows.Forms.NumericUpDown numLimiteBimestresVencidos;
    }
}
