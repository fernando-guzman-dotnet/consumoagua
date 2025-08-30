namespace SAPA.Vistas
{
    partial class FrmLecturaPorLotes
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
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLecturista = new System.Windows.Forms.ComboBox();
            this.btnCuentaSelect = new System.Windows.Forms.Button();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLectura = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLecturaAnterior = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbOrden = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvCapturaPorLotes = new System.Windows.Forms.DataGridView();
            this.CuentaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LecturaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LecAnteriorDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsumoDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MesQueSePagaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AñoQueSePagaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMedidorDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagadaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BitAnomaliaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnomaliaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdLecturistaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbAnomalia = new System.Windows.Forms.ComboBox();
            this.txtDescrAnomalia = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapturaPorLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(95, 23);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(96, 20);
            this.dtpFecha.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lecturista:";
            // 
            // cmbLecturista
            // 
            this.cmbLecturista.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbLecturista.FormattingEnabled = true;
            this.cmbLecturista.Location = new System.Drawing.Point(95, 72);
            this.cmbLecturista.Name = "cmbLecturista";
            this.cmbLecturista.Size = new System.Drawing.Size(242, 21);
            this.cmbLecturista.TabIndex = 0;
            // 
            // btnCuentaSelect
            // 
            this.btnCuentaSelect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCuentaSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuentaSelect.Location = new System.Drawing.Point(79, 131);
            this.btnCuentaSelect.Name = "btnCuentaSelect";
            this.btnCuentaSelect.Size = new System.Drawing.Size(50, 23);
            this.btnCuentaSelect.TabIndex = 2;
            this.btnCuentaSelect.Text = ">>>";
            this.btnCuentaSelect.UseVisualStyleBackColor = true;
            this.btnCuentaSelect.Click += new System.EventHandler(this.btnCuentaSelect_Click);
            // 
            // txtCuenta
            // 
            this.txtCuenta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCuenta.Enabled = false;
            this.txtCuenta.Location = new System.Drawing.Point(15, 132);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(66, 20);
            this.txtCuenta.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cuenta";
            // 
            // txtLectura
            // 
            this.txtLectura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLectura.Location = new System.Drawing.Point(135, 133);
            this.txtLectura.Name = "txtLectura";
            this.txtLectura.Size = new System.Drawing.Size(100, 20);
            this.txtLectura.TabIndex = 3;
            this.txtLectura.Text = "0.00";
            this.txtLectura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLectura_KeyPress);
            this.txtLectura.Validating += new System.ComponentModel.CancelEventHandler(this.txtLectura_Validating);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(153, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Lectura:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(238, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Lectura Anterior:";
            // 
            // txtLecturaAnterior
            // 
            this.txtLecturaAnterior.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLecturaAnterior.Enabled = false;
            this.txtLecturaAnterior.Location = new System.Drawing.Point(247, 132);
            this.txtLecturaAnterior.Name = "txtLecturaAnterior";
            this.txtLecturaAnterior.Size = new System.Drawing.Size(100, 20);
            this.txtLecturaAnterior.TabIndex = 4;
            this.txtLecturaAnterior.Text = "0.00";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(379, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "An:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(555, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Anomalía:";
            // 
            // cmbOrden
            // 
            this.cmbOrden.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbOrden.FormattingEnabled = true;
            this.cmbOrden.Items.AddRange(new object[] {
            "NO",
            "SI"});
            this.cmbOrden.Location = new System.Drawing.Point(745, 133);
            this.cmbOrden.Name = "cmbOrden";
            this.cmbOrden.Size = new System.Drawing.Size(68, 21);
            this.cmbOrden.TabIndex = 7;
            this.cmbOrden.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(753, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Orden:";
            this.label8.Visible = false;
            // 
            // dgvCapturaPorLotes
            // 
            this.dgvCapturaPorLotes.AllowUserToAddRows = false;
            this.dgvCapturaPorLotes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvCapturaPorLotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCapturaPorLotes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCapturaPorLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCapturaPorLotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CuentaDGV,
            this.LecturaDGV,
            this.LecAnteriorDGV,
            this.FechaDGV,
            this.ConsumoDGV,
            this.DescripcionDGV,
            this.MesQueSePagaDGV,
            this.AñoQueSePagaDGV,
            this.IdMedidorDGV,
            this.PagadaDGV,
            this.BitAnomaliaDGV,
            this.AnomaliaDGV,
            this.IdLecturistaDGV});
            this.dgvCapturaPorLotes.Location = new System.Drawing.Point(12, 160);
            this.dgvCapturaPorLotes.Name = "dgvCapturaPorLotes";
            this.dgvCapturaPorLotes.ReadOnly = true;
            this.dgvCapturaPorLotes.Size = new System.Drawing.Size(1032, 280);
            this.dgvCapturaPorLotes.TabIndex = 5;
            // 
            // CuentaDGV
            // 
            this.CuentaDGV.HeaderText = "Cuenta";
            this.CuentaDGV.Name = "CuentaDGV";
            this.CuentaDGV.ReadOnly = true;
            // 
            // LecturaDGV
            // 
            this.LecturaDGV.HeaderText = "Lectura";
            this.LecturaDGV.Name = "LecturaDGV";
            this.LecturaDGV.ReadOnly = true;
            // 
            // LecAnteriorDGV
            // 
            this.LecAnteriorDGV.HeaderText = "Lectura_Anterior";
            this.LecAnteriorDGV.Name = "LecAnteriorDGV";
            this.LecAnteriorDGV.ReadOnly = true;
            // 
            // FechaDGV
            // 
            this.FechaDGV.HeaderText = "Fecha";
            this.FechaDGV.Name = "FechaDGV";
            this.FechaDGV.ReadOnly = true;
            // 
            // ConsumoDGV
            // 
            this.ConsumoDGV.HeaderText = "Consumo";
            this.ConsumoDGV.Name = "ConsumoDGV";
            this.ConsumoDGV.ReadOnly = true;
            // 
            // DescripcionDGV
            // 
            this.DescripcionDGV.HeaderText = "Descripcion";
            this.DescripcionDGV.Name = "DescripcionDGV";
            this.DescripcionDGV.ReadOnly = true;
            // 
            // MesQueSePagaDGV
            // 
            this.MesQueSePagaDGV.HeaderText = "MesQueSePaga";
            this.MesQueSePagaDGV.Name = "MesQueSePagaDGV";
            this.MesQueSePagaDGV.ReadOnly = true;
            // 
            // AñoQueSePagaDGV
            // 
            this.AñoQueSePagaDGV.HeaderText = "AñoQueSePaga";
            this.AñoQueSePagaDGV.Name = "AñoQueSePagaDGV";
            this.AñoQueSePagaDGV.ReadOnly = true;
            // 
            // IdMedidorDGV
            // 
            this.IdMedidorDGV.HeaderText = "IdMedidor";
            this.IdMedidorDGV.Name = "IdMedidorDGV";
            this.IdMedidorDGV.ReadOnly = true;
            // 
            // PagadaDGV
            // 
            this.PagadaDGV.HeaderText = "Pagada";
            this.PagadaDGV.Name = "PagadaDGV";
            this.PagadaDGV.ReadOnly = true;
            // 
            // BitAnomaliaDGV
            // 
            this.BitAnomaliaDGV.HeaderText = "BitAnomalia";
            this.BitAnomaliaDGV.Name = "BitAnomaliaDGV";
            this.BitAnomaliaDGV.ReadOnly = true;
            // 
            // AnomaliaDGV
            // 
            this.AnomaliaDGV.HeaderText = "Anomalia";
            this.AnomaliaDGV.Name = "AnomaliaDGV";
            this.AnomaliaDGV.ReadOnly = true;
            // 
            // IdLecturistaDGV
            // 
            this.IdLecturistaDGV.HeaderText = "IdLecturista";
            this.IdLecturistaDGV.Name = "IdLecturistaDGV";
            this.IdLecturistaDGV.ReadOnly = true;
            // 
            // cmbAnomalia
            // 
            this.cmbAnomalia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbAnomalia.FormattingEnabled = true;
            this.cmbAnomalia.Items.AddRange(new object[] {
            "NO",
            "SI"});
            this.cmbAnomalia.Location = new System.Drawing.Point(360, 132);
            this.cmbAnomalia.Name = "cmbAnomalia";
            this.cmbAnomalia.Size = new System.Drawing.Size(68, 21);
            this.cmbAnomalia.TabIndex = 5;
            this.cmbAnomalia.SelectedIndexChanged += new System.EventHandler(this.cmbAnomalia_SelectedIndexChanged);
            // 
            // txtDescrAnomalia
            // 
            this.txtDescrAnomalia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDescrAnomalia.Enabled = false;
            this.txtDescrAnomalia.Location = new System.Drawing.Point(443, 133);
            this.txtDescrAnomalia.Name = "txtDescrAnomalia";
            this.txtDescrAnomalia.Size = new System.Drawing.Size(296, 20);
            this.txtDescrAnomalia.TabIndex = 6;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(778, 118);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(50, 35);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "+";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Location = new System.Drawing.Point(422, 464);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(68, 31);
            this.btnAplicar.TabIndex = 9;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(505, 464);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(50, 31);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmLecturaPorLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 539);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvCapturaPorLotes);
            this.Controls.Add(this.txtLecturaAnterior);
            this.Controls.Add(this.txtDescrAnomalia);
            this.Controls.Add(this.txtLectura);
            this.Controls.Add(this.txtCuenta);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnCuentaSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbAnomalia);
            this.Controls.Add(this.cmbOrden);
            this.Controls.Add(this.cmbLecturista);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFecha);
            this.Name = "frmLecturaPorLotes";
            this.Text = "Lectura Por Lotes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLecturaPorLotes_FormClosing);
            this.Load += new System.EventHandler(this.frmLecturaPorLotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapturaPorLotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLecturista;
        private System.Windows.Forms.Button btnCuentaSelect;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLectura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLecturaAnterior;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbOrden;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvCapturaPorLotes;
        private System.Windows.Forms.ComboBox cmbAnomalia;
        private System.Windows.Forms.TextBox txtDescrAnomalia;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn LecturaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn LecAnteriorDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsumoDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MesQueSePagaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn AñoQueSePagaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMedidorDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagadaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn BitAnomaliaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnomaliaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdLecturistaDGV;
    }
}
