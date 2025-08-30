namespace SAPA.Vistas
{
    partial class FrmPorcentajes
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
            this.lblIVA = new System.Windows.Forms.Label();
            this.lblPorcentajeAlcantarillado = new System.Windows.Forms.Label();
            this.lblPorcentajeSaneamiento = new System.Windows.Forms.Label();
            this.dgvPorcentajes = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmsBorrar = new System.Windows.Forms.ToolStripMenuItem();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.txtPorcentajeAlcantarillado = new System.Windows.Forms.TextBox();
            this.txtPorcentajeSaneamiento = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblSalarioMinimo = new System.Windows.Forms.Label();
            this.txtSalarioMinimo = new System.Windows.Forms.TextBox();
            this.lblPorcentajeMultas = new System.Windows.Forms.Label();
            this.txtPorcentajeMultas = new System.Windows.Forms.TextBox();
            this.lblPorcentajeRecargos = new System.Windows.Forms.Label();
            this.txtPorcentajeRecargos = new System.Windows.Forms.TextBox();
            this.lblDescuentoAnual = new System.Windows.Forms.Label();
            this.txtDescuentoAnual = new System.Windows.Forms.TextBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblRangoFechas = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAumentoAnual = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorcentajes)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIVA
            // 
            this.lblIVA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIVA.AutoSize = true;
            this.lblIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblIVA.Location = new System.Drawing.Point(139, 35);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(39, 20);
            this.lblIVA.TabIndex = 0;
            this.lblIVA.Text = "IVA";
            // 
            // lblPorcentajeAlcantarillado
            // 
            this.lblPorcentajeAlcantarillado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPorcentajeAlcantarillado.AutoSize = true;
            this.lblPorcentajeAlcantarillado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblPorcentajeAlcantarillado.Location = new System.Drawing.Point(15, 72);
            this.lblPorcentajeAlcantarillado.Name = "lblPorcentajeAlcantarillado";
            this.lblPorcentajeAlcantarillado.Size = new System.Drawing.Size(163, 20);
            this.lblPorcentajeAlcantarillado.TabIndex = 0;
            this.lblPorcentajeAlcantarillado.Text = "% de Alcantarillado";
            // 
            // lblPorcentajeSaneamiento
            // 
            this.lblPorcentajeSaneamiento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPorcentajeSaneamiento.AutoSize = true;
            this.lblPorcentajeSaneamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblPorcentajeSaneamiento.Location = new System.Drawing.Point(18, 109);
            this.lblPorcentajeSaneamiento.Name = "lblPorcentajeSaneamiento";
            this.lblPorcentajeSaneamiento.Size = new System.Drawing.Size(160, 20);
            this.lblPorcentajeSaneamiento.TabIndex = 0;
            this.lblPorcentajeSaneamiento.Text = "% de Saneamiento";
            // 
            // dgvPorcentajes
            // 
            this.dgvPorcentajes.AllowUserToAddRows = false;
            this.dgvPorcentajes.AllowUserToDeleteRows = false;
            this.dgvPorcentajes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPorcentajes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPorcentajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPorcentajes.ContextMenuStrip = this.contextMenuStrip;
            this.dgvPorcentajes.Location = new System.Drawing.Point(12, 221);
            this.dgvPorcentajes.MultiSelect = false;
            this.dgvPorcentajes.Name = "dgvPorcentajes";
            this.dgvPorcentajes.ReadOnly = true;
            this.dgvPorcentajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPorcentajes.Size = new System.Drawing.Size(1011, 234);
            this.dgvPorcentajes.TabIndex = 1;
            this.dgvPorcentajes.TabStop = false;
            this.dgvPorcentajes.SelectionChanged += new System.EventHandler(this.dgvPorcentajes_SelectionChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsBorrar});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(107, 26);
            // 
            // tmsBorrar
            // 
            this.tmsBorrar.Name = "tmsBorrar";
            this.tmsBorrar.Size = new System.Drawing.Size(106, 22);
            this.tmsBorrar.Text = "Borrar";
            this.tmsBorrar.Click += new System.EventHandler(this.tsmBorrar_Click);
            // 
            // txtIVA
            // 
            this.txtIVA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIVA.Location = new System.Drawing.Point(184, 35);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(100, 20);
            this.txtIVA.TabIndex = 0;
            this.txtIVA.Text = "0.00";
            this.txtIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIVA_KeyPress);
            // 
            // txtPorcentajeAlcantarillado
            // 
            this.txtPorcentajeAlcantarillado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPorcentajeAlcantarillado.Location = new System.Drawing.Point(184, 74);
            this.txtPorcentajeAlcantarillado.Name = "txtPorcentajeAlcantarillado";
            this.txtPorcentajeAlcantarillado.Size = new System.Drawing.Size(100, 20);
            this.txtPorcentajeAlcantarillado.TabIndex = 1;
            this.txtPorcentajeAlcantarillado.Text = "0.00";
            this.txtPorcentajeAlcantarillado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlcantarillado_KeyPress);
            // 
            // txtPorcentajeSaneamiento
            // 
            this.txtPorcentajeSaneamiento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPorcentajeSaneamiento.Location = new System.Drawing.Point(184, 109);
            this.txtPorcentajeSaneamiento.Name = "txtPorcentajeSaneamiento";
            this.txtPorcentajeSaneamiento.Size = new System.Drawing.Size(100, 20);
            this.txtPorcentajeSaneamiento.TabIndex = 2;
            this.txtPorcentajeSaneamiento.Text = "0.00";
            this.txtPorcentajeSaneamiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaneamiento_KeyPress);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(829, 184);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(94, 29);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(929, 183);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 31);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.AutoSize = true;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Location = new System.Drawing.Point(984, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(39, 39);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblSalarioMinimo
            // 
            this.lblSalarioMinimo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSalarioMinimo.AutoSize = true;
            this.lblSalarioMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblSalarioMinimo.Location = new System.Drawing.Point(52, 146);
            this.lblSalarioMinimo.Name = "lblSalarioMinimo";
            this.lblSalarioMinimo.Size = new System.Drawing.Size(126, 20);
            this.lblSalarioMinimo.TabIndex = 0;
            this.lblSalarioMinimo.Text = "Salario Minimo";
            // 
            // txtSalarioMinimo
            // 
            this.txtSalarioMinimo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSalarioMinimo.Location = new System.Drawing.Point(184, 146);
            this.txtSalarioMinimo.Name = "txtSalarioMinimo";
            this.txtSalarioMinimo.Size = new System.Drawing.Size(100, 20);
            this.txtSalarioMinimo.TabIndex = 3;
            this.txtSalarioMinimo.Text = "0.00";
            // 
            // lblPorcentajeMultas
            // 
            this.lblPorcentajeMultas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPorcentajeMultas.AutoSize = true;
            this.lblPorcentajeMultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblPorcentajeMultas.Location = new System.Drawing.Point(373, 35);
            this.lblPorcentajeMultas.Name = "lblPorcentajeMultas";
            this.lblPorcentajeMultas.Size = new System.Drawing.Size(82, 20);
            this.lblPorcentajeMultas.TabIndex = 0;
            this.lblPorcentajeMultas.Text = "% Multas";
            // 
            // txtPorcentajeMultas
            // 
            this.txtPorcentajeMultas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPorcentajeMultas.Location = new System.Drawing.Point(461, 35);
            this.txtPorcentajeMultas.Name = "txtPorcentajeMultas";
            this.txtPorcentajeMultas.Size = new System.Drawing.Size(100, 20);
            this.txtPorcentajeMultas.TabIndex = 4;
            this.txtPorcentajeMultas.Text = "0.00";
            this.txtPorcentajeMultas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentajeMultas_KeyPress);
            // 
            // lblPorcentajeRecargos
            // 
            this.lblPorcentajeRecargos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPorcentajeRecargos.AutoSize = true;
            this.lblPorcentajeRecargos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblPorcentajeRecargos.Location = new System.Drawing.Point(349, 74);
            this.lblPorcentajeRecargos.Name = "lblPorcentajeRecargos";
            this.lblPorcentajeRecargos.Size = new System.Drawing.Size(106, 20);
            this.lblPorcentajeRecargos.TabIndex = 0;
            this.lblPorcentajeRecargos.Text = "% Recargos";
            // 
            // txtPorcentajeRecargos
            // 
            this.txtPorcentajeRecargos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPorcentajeRecargos.Location = new System.Drawing.Point(461, 74);
            this.txtPorcentajeRecargos.Name = "txtPorcentajeRecargos";
            this.txtPorcentajeRecargos.Size = new System.Drawing.Size(100, 20);
            this.txtPorcentajeRecargos.TabIndex = 5;
            this.txtPorcentajeRecargos.Text = "0.00";
            this.txtPorcentajeRecargos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentajeRecargos_KeyPress);
            // 
            // lblDescuentoAnual
            // 
            this.lblDescuentoAnual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDescuentoAnual.AutoSize = true;
            this.lblDescuentoAnual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDescuentoAnual.Location = new System.Drawing.Point(332, 109);
            this.lblDescuentoAnual.Name = "lblDescuentoAnual";
            this.lblDescuentoAnual.Size = new System.Drawing.Size(123, 20);
            this.lblDescuentoAnual.TabIndex = 0;
            this.lblDescuentoAnual.Text = "% Dcto. Anual";
            // 
            // txtDescuentoAnual
            // 
            this.txtDescuentoAnual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDescuentoAnual.Location = new System.Drawing.Point(461, 109);
            this.txtDescuentoAnual.Name = "txtDescuentoAnual";
            this.txtDescuentoAnual.Size = new System.Drawing.Size(100, 20);
            this.txtDescuentoAnual.TabIndex = 6;
            this.txtDescuentoAnual.Text = "0.00";
            this.txtDescuentoAnual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuentoAnual_KeyPress);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaFin.Location = new System.Drawing.Point(755, 109);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 8;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaInicio.Location = new System.Drawing.Point(755, 74);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 7;
            // 
            // lblRangoFechas
            // 
            this.lblRangoFechas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRangoFechas.AutoSize = true;
            this.lblRangoFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblRangoFechas.Location = new System.Drawing.Point(692, 35);
            this.lblRangoFechas.Name = "lblRangoFechas";
            this.lblRangoFechas.Size = new System.Drawing.Size(263, 20);
            this.lblRangoFechas.TabIndex = 0;
            this.lblRangoFechas.Text = "Rango de Fechas de Aplicación";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.Location = new System.Drawing.Point(726, 109);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(23, 20);
            this.lblFechaFin.TabIndex = 0;
            this.lblFechaFin.Text = "al";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.Location = new System.Drawing.Point(716, 74);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(33, 20);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "del";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(303, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "% Aumento Anual";
            // 
            // txtAumentoAnual
            // 
            this.txtAumentoAnual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAumentoAnual.Location = new System.Drawing.Point(461, 146);
            this.txtAumentoAnual.Name = "txtAumentoAnual";
            this.txtAumentoAnual.Size = new System.Drawing.Size(100, 20);
            this.txtAumentoAnual.TabIndex = 6;
            this.txtAumentoAnual.Text = "0.00";
            this.txtAumentoAnual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuentoAnual_KeyPress);
            // 
            // FrmPorcentajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 467);
            this.ControlBox = false;
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtSalarioMinimo);
            this.Controls.Add(this.txtPorcentajeSaneamiento);
            this.Controls.Add(this.txtPorcentajeAlcantarillado);
            this.Controls.Add(this.txtAumentoAnual);
            this.Controls.Add(this.txtDescuentoAnual);
            this.Controls.Add(this.txtPorcentajeRecargos);
            this.Controls.Add(this.txtPorcentajeMultas);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.lblSalarioMinimo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRangoFechas);
            this.Controls.Add(this.lblDescuentoAnual);
            this.Controls.Add(this.dgvPorcentajes);
            this.Controls.Add(this.lblPorcentajeRecargos);
            this.Controls.Add(this.lblPorcentajeSaneamiento);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblPorcentajeMultas);
            this.Controls.Add(this.lblPorcentajeAlcantarillado);
            this.Controls.Add(this.lblIVA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPorcentajes";
            this.Text = "Porcentajes";
            this.Load += new System.EventHandler(this.frmPorcentajes_Load);
            this.Shown += new System.EventHandler(this.FrmPorcentajes_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorcentajes)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Label lblPorcentajeAlcantarillado;
        private System.Windows.Forms.Label lblPorcentajeSaneamiento;
        private System.Windows.Forms.DataGridView dgvPorcentajes;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.TextBox txtPorcentajeAlcantarillado;
        private System.Windows.Forms.TextBox txtPorcentajeSaneamiento;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblSalarioMinimo;
        private System.Windows.Forms.TextBox txtSalarioMinimo;
        private System.Windows.Forms.Label lblPorcentajeMultas;
        private System.Windows.Forms.TextBox txtPorcentajeMultas;
        private System.Windows.Forms.Label lblPorcentajeRecargos;
        private System.Windows.Forms.TextBox txtPorcentajeRecargos;
        private System.Windows.Forms.Label lblDescuentoAnual;
        private System.Windows.Forms.TextBox txtDescuentoAnual;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblRangoFechas;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tmsBorrar;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAumentoAnual;
    }
}
