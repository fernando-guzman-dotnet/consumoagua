namespace SAPA.Vistas
{
    partial class FrmBitacora
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
            this.grpBuscarRegistros = new System.Windows.Forms.GroupBox();
            this.cmbEmpleados = new System.Windows.Forms.ComboBox();
            this.lblEmpleados = new System.Windows.Forms.Label();
            this.lblModulo = new System.Windows.Forms.Label();
            this.txtModulo = new System.Windows.Forms.TextBox();
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.grpBuscarRegistros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBuscarRegistros
            // 
            this.grpBuscarRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBuscarRegistros.BackColor = System.Drawing.SystemColors.Control;
            this.grpBuscarRegistros.Controls.Add(this.cmbEmpleados);
            this.grpBuscarRegistros.Controls.Add(this.lblEmpleados);
            this.grpBuscarRegistros.Controls.Add(this.lblModulo);
            this.grpBuscarRegistros.Controls.Add(this.txtModulo);
            this.grpBuscarRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.grpBuscarRegistros.Location = new System.Drawing.Point(12, 12);
            this.grpBuscarRegistros.Name = "grpBuscarRegistros";
            this.grpBuscarRegistros.Size = new System.Drawing.Size(986, 104);
            this.grpBuscarRegistros.TabIndex = 0;
            this.grpBuscarRegistros.TabStop = false;
            this.grpBuscarRegistros.Text = "Buscar registros";
            // 
            // cmbEmpleados
            // 
            this.cmbEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpleados.FormattingEnabled = true;
            this.cmbEmpleados.Location = new System.Drawing.Point(101, 25);
            this.cmbEmpleados.Name = "cmbEmpleados";
            this.cmbEmpleados.Size = new System.Drawing.Size(458, 24);
            this.cmbEmpleados.TabIndex = 0;
            this.cmbEmpleados.SelectedIndexChanged += new System.EventHandler(this.cmbEmpleados_SelectedIndexChanged);
            // 
            // lblEmpleados
            // 
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblEmpleados.Location = new System.Drawing.Point(14, 27);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.Size = new System.Drawing.Size(81, 20);
            this.lblEmpleados.TabIndex = 19;
            this.lblEmpleados.Text = "Empleado";
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblModulo.Location = new System.Drawing.Point(34, 54);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(61, 20);
            this.lblModulo.TabIndex = 19;
            this.lblModulo.Text = "Módulo";
            // 
            // txtModulo
            // 
            this.txtModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModulo.Location = new System.Drawing.Point(101, 54);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(194, 22);
            this.txtModulo.TabIndex = 1;
            this.txtModulo.TextChanged += new System.EventHandler(this.txtModulo_TextChanged);
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.AllowUserToAddRows = false;
            this.dgvBitacora.AllowUserToDeleteRows = false;
            this.dgvBitacora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvBitacora.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBitacora.Location = new System.Drawing.Point(12, 122);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.ReadOnly = true;
            this.dgvBitacora.Size = new System.Drawing.Size(986, 509);
            this.dgvBitacora.TabIndex = 1;
            // 
            // FrmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 643);
            this.Controls.Add(this.dgvBitacora);
            this.Controls.Add(this.grpBuscarRegistros);
            this.Name = "FrmBitacora";
            this.ShowIcon = false;
            this.Text = "Bitácora de empleado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBitacora_FormClosing);
            this.Load += new System.EventHandler(this.frmBitacora_Load);
            this.grpBuscarRegistros.ResumeLayout(false);
            this.grpBuscarRegistros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBuscarRegistros;
        private System.Windows.Forms.ComboBox cmbEmpleados;
        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.TextBox txtModulo;
        private System.Windows.Forms.DataGridView dgvBitacora;
    }
}
