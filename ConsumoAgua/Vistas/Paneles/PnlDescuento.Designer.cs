namespace SAPA.Vistas.Paneles
{
    partial class PnlDescuentos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDescuentos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTipoDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreTipoDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeAgua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeAlcantarillado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeSaneamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeRecargos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeMultas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeGastosEjecucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAgregarDescuento = new System.Windows.Forms.ToolStripButton();
            this.btnEditarDescuento = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarDescuento = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            this.btnAplicarDescuentoContrato = new System.Windows.Forms.ToolStripButton();
            this.btnAplicarDescuentoMasivamente = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDescuentos
            // 
            this.dgvDescuentos.AllowUserToAddRows = false;
            this.dgvDescuentos.AllowUserToDeleteRows = false;
            this.dgvDescuentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDescuentos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescuentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdTipoDescuento,
            this.NombreTipoDescuento,
            this.PorcentajeAgua,
            this.PorcentajeAlcantarillado,
            this.PorcentajeSaneamiento,
            this.PorcentajeRecargos,
            this.PorcentajeMultas,
            this.PorcentajeGastosEjecucion,
            this.PorcentajeIVA,
            this.FechaCreado});
            this.dgvDescuentos.Location = new System.Drawing.Point(12, 40);
            this.dgvDescuentos.Name = "dgvDescuentos";
            this.dgvDescuentos.ReadOnly = true;
            this.dgvDescuentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDescuentos.Size = new System.Drawing.Size(1376, 616);
            this.dgvDescuentos.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // IdTipoDescuento
            // 
            this.IdTipoDescuento.DataPropertyName = "IdTipoDescuento";
            this.IdTipoDescuento.HeaderText = "IdTipoDescuento";
            this.IdTipoDescuento.Name = "IdTipoDescuento";
            this.IdTipoDescuento.ReadOnly = true;
            this.IdTipoDescuento.Visible = false;
            // 
            // NombreTipoDescuento
            // 
            this.NombreTipoDescuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NombreTipoDescuento.DataPropertyName = "NombreTipoDescuento";
            this.NombreTipoDescuento.HeaderText = "Tipo de Descuento";
            this.NombreTipoDescuento.Name = "NombreTipoDescuento";
            this.NombreTipoDescuento.ReadOnly = true;
            this.NombreTipoDescuento.Width = 113;
            // 
            // PorcentajeAgua
            // 
            this.PorcentajeAgua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PorcentajeAgua.DataPropertyName = "PorcentajeAgua";
            dataGridViewCellStyle1.Format = "0.00\\%";
            dataGridViewCellStyle1.NullValue = null;
            this.PorcentajeAgua.DefaultCellStyle = dataGridViewCellStyle1;
            this.PorcentajeAgua.HeaderText = "Agua";
            this.PorcentajeAgua.Name = "PorcentajeAgua";
            this.PorcentajeAgua.ReadOnly = true;
            this.PorcentajeAgua.Width = 57;
            // 
            // PorcentajeAlcantarillado
            // 
            this.PorcentajeAlcantarillado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PorcentajeAlcantarillado.DataPropertyName = "PorcentajeAlcantarillado";
            dataGridViewCellStyle2.Format = "0.00\\%";
            this.PorcentajeAlcantarillado.DefaultCellStyle = dataGridViewCellStyle2;
            this.PorcentajeAlcantarillado.HeaderText = "Alcantarillado";
            this.PorcentajeAlcantarillado.Name = "PorcentajeAlcantarillado";
            this.PorcentajeAlcantarillado.ReadOnly = true;
            this.PorcentajeAlcantarillado.Width = 95;
            // 
            // PorcentajeSaneamiento
            // 
            this.PorcentajeSaneamiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PorcentajeSaneamiento.DataPropertyName = "PorcentajeSaneamiento";
            dataGridViewCellStyle3.Format = "0.00\\%";
            this.PorcentajeSaneamiento.DefaultCellStyle = dataGridViewCellStyle3;
            this.PorcentajeSaneamiento.HeaderText = "Saneamiento";
            this.PorcentajeSaneamiento.Name = "PorcentajeSaneamiento";
            this.PorcentajeSaneamiento.ReadOnly = true;
            this.PorcentajeSaneamiento.Width = 94;
            // 
            // PorcentajeRecargos
            // 
            this.PorcentajeRecargos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PorcentajeRecargos.DataPropertyName = "PorcentajeRecargos";
            dataGridViewCellStyle4.Format = "0.00\\%";
            this.PorcentajeRecargos.DefaultCellStyle = dataGridViewCellStyle4;
            this.PorcentajeRecargos.HeaderText = "Recargos";
            this.PorcentajeRecargos.Name = "PorcentajeRecargos";
            this.PorcentajeRecargos.ReadOnly = true;
            this.PorcentajeRecargos.Width = 78;
            // 
            // PorcentajeMultas
            // 
            this.PorcentajeMultas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PorcentajeMultas.DataPropertyName = "PorcentajeMultas";
            dataGridViewCellStyle5.Format = "0.00\\%";
            this.PorcentajeMultas.DefaultCellStyle = dataGridViewCellStyle5;
            this.PorcentajeMultas.HeaderText = "Multas";
            this.PorcentajeMultas.Name = "PorcentajeMultas";
            this.PorcentajeMultas.ReadOnly = true;
            this.PorcentajeMultas.Width = 63;
            // 
            // PorcentajeGastosEjecucion
            // 
            this.PorcentajeGastosEjecucion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PorcentajeGastosEjecucion.DataPropertyName = "PorcentajeGastosEjecucion";
            dataGridViewCellStyle6.Format = "0.00\\%";
            this.PorcentajeGastosEjecucion.DefaultCellStyle = dataGridViewCellStyle6;
            this.PorcentajeGastosEjecucion.HeaderText = "Gastos de Ejecución";
            this.PorcentajeGastosEjecucion.Name = "PorcentajeGastosEjecucion";
            this.PorcentajeGastosEjecucion.ReadOnly = true;
            this.PorcentajeGastosEjecucion.Width = 119;
            // 
            // PorcentajeIVA
            // 
            this.PorcentajeIVA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PorcentajeIVA.DataPropertyName = "PorcentajeIVA";
            dataGridViewCellStyle7.Format = "0.00\\%";
            this.PorcentajeIVA.DefaultCellStyle = dataGridViewCellStyle7;
            this.PorcentajeIVA.HeaderText = "IVA";
            this.PorcentajeIVA.Name = "PorcentajeIVA";
            this.PorcentajeIVA.ReadOnly = true;
            this.PorcentajeIVA.Width = 49;
            // 
            // FechaCreado
            // 
            this.FechaCreado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FechaCreado.DataPropertyName = "FechaCreado";
            this.FechaCreado.HeaderText = "Fecha Registrado";
            this.FechaCreado.Name = "FechaCreado";
            this.FechaCreado.ReadOnly = true;
            this.FechaCreado.Width = 106;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarDescuento,
            this.btnEditarDescuento,
            this.btnEliminarDescuento,
            this.btnCerrar,
            this.btnAplicarDescuentoContrato,
            this.btnAplicarDescuentoMasivamente});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1400, 37);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 6;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnAgregarDescuento
            // 
            this.btnAgregarDescuento.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarDescuento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarDescuento.Name = "btnAgregarDescuento";
            this.btnAgregarDescuento.Size = new System.Drawing.Size(142, 34);
            this.btnAgregarDescuento.Text = "Agregar Descuento";
            this.btnAgregarDescuento.Click += new System.EventHandler(this.btnAgregarDescuento_Click);
            // 
            // btnEditarDescuento
            // 
            this.btnEditarDescuento.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarDescuento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarDescuento.Name = "btnEditarDescuento";
            this.btnEditarDescuento.Size = new System.Drawing.Size(130, 34);
            this.btnEditarDescuento.Text = "Editar Descuento";
            this.btnEditarDescuento.Click += new System.EventHandler(this.btnEditarDescuento_Click);
            // 
            // btnEliminarDescuento
            // 
            this.btnEliminarDescuento.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarDescuento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarDescuento.Name = "btnEliminarDescuento";
            this.btnEliminarDescuento.Size = new System.Drawing.Size(143, 34);
            this.btnEliminarDescuento.Text = "Eliminar Descuento";
            this.btnEliminarDescuento.Click += new System.EventHandler(this.btnEliminarDescuento_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAplicarDescuentoContrato
            // 
            this.btnAplicarDescuentoContrato.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAplicarDescuentoContrato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAplicarDescuentoContrato.Name = "btnAplicarDescuentoContrato";
            this.btnAplicarDescuentoContrato.Size = new System.Drawing.Size(137, 34);
            this.btnAplicarDescuentoContrato.Text = "Aplicar a Contrato";
            this.btnAplicarDescuentoContrato.Click += new System.EventHandler(this.btnAplicarDescuentoContrato_Click);
            // 
            // btnAplicarDescuentoMasivamente
            // 
            this.btnAplicarDescuentoMasivamente.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAplicarDescuentoMasivamente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAplicarDescuentoMasivamente.Name = "btnAplicarDescuentoMasivamente";
            this.btnAplicarDescuentoMasivamente.Size = new System.Drawing.Size(152, 34);
            this.btnAplicarDescuentoMasivamente.Text = "Aplicar masivamente";
            this.btnAplicarDescuentoMasivamente.Click += new System.EventHandler(this.btnAplicarDescuentoMasivamente_Click);
            // 
            // PnlDescuentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 668);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvDescuentos);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PnlDescuentos";
            this.Text = "Calles";
            this.Load += new System.EventHandler(this.PnlDescuentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDescuentos;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAgregarDescuento;
        private System.Windows.Forms.ToolStripButton btnEditarDescuento;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
        private System.Windows.Forms.ToolStripButton btnEliminarDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTipoDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreTipoDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentajeAgua;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentajeAlcantarillado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentajeSaneamiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentajeRecargos;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentajeMultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentajeGastosEjecucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentajeIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreado;
        private System.Windows.Forms.ToolStripButton btnAplicarDescuentoContrato;
        private System.Windows.Forms.ToolStripButton btnAplicarDescuentoMasivamente;
    }
}
