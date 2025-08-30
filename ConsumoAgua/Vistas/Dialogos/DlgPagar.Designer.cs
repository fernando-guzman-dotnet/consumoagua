namespace SAPA.Vistas.Dialogos
{
    partial class DlgPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgPagar));
            this.txtNoContrato = new System.Windows.Forms.TextBox();
            this.lblNoContrato = new System.Windows.Forms.Label();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.lblTitular = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.grpDatosContrato = new System.Windows.Forms.GroupBox();
            this.lblTipoServicio = new System.Windows.Forms.Label();
            this.txtTipoServicio = new System.Windows.Forms.TextBox();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.txtTarifa = new System.Windows.Forms.TextBox();
            this.dgvAdeudosPendientes = new System.Windows.Forms.DataGridView();
            this.lblTituloDgv = new System.Windows.Forms.Label();
            this.lblCantidadAdeudosPagar = new System.Windows.Forms.Label();
            this.grpDesgloseTotal = new System.Windows.Forms.GroupBox();
            this.lblOtros = new System.Windows.Forms.Label();
            this.txtOtros = new System.Windows.Forms.TextBox();
            this.lblRedondeo = new System.Windows.Forms.Label();
            this.txtRedondeo = new System.Windows.Forms.TextBox();
            this.lblDescuentosAplicados = new System.Windows.Forms.Label();
            this.lblAgua = new System.Windows.Forms.Label();
            this.txtAgua = new System.Windows.Forms.TextBox();
            this.lblAlcantarillado = new System.Windows.Forms.Label();
            this.txtAlcantarillado = new System.Windows.Forms.TextBox();
            this.lblSaneamiento = new System.Windows.Forms.Label();
            this.txtSaneamiento = new System.Windows.Forms.TextBox();
            this.lblRecargos = new System.Windows.Forms.Label();
            this.txtRecargos = new System.Windows.Forms.TextBox();
            this.lblMultas = new System.Windows.Forms.Label();
            this.txtMultas = new System.Windows.Forms.TextBox();
            this.lblGastosEjecucion = new System.Windows.Forms.Label();
            this.txtGastosEjecucion = new System.Windows.Forms.TextBox();
            this.lblIVA = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.grpAdeudos = new System.Windows.Forms.GroupBox();
            this.btnSeleccionarTodos = new System.Windows.Forms.Button();
            this.nudAdeudosPagar = new System.Windows.Forms.NumericUpDown();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.pnlAdeudosPendientes = new System.Windows.Forms.Panel();
            this.pnlDesgloseAdeudos = new System.Windows.Forms.Panel();
            this.grpDescuentos = new System.Windows.Forms.GroupBox();
            this.txtDescuentoGeneral = new System.Windows.Forms.TextBox();
            this.lblDescuentoPorcentualAgua = new System.Windows.Forms.Label();
            this.txtDescuentoPorcentualAgua = new System.Windows.Forms.TextBox();
            this.lblDescuentoPorcentualAlcantarillado = new System.Windows.Forms.Label();
            this.txtDescuentoPorcentualAlcantarillado = new System.Windows.Forms.TextBox();
            this.lblDescuentoPorcentualSaneamiento = new System.Windows.Forms.Label();
            this.txtDescuentoPorcentualSaneamiento = new System.Windows.Forms.TextBox();
            this.lblDescuentoPorcentualRecargos = new System.Windows.Forms.Label();
            this.txtDescuentoPorcentualRecargos = new System.Windows.Forms.TextBox();
            this.lblDescuentoPorcentualIVA = new System.Windows.Forms.Label();
            this.txtDescuentoPorcentualIVA = new System.Windows.Forms.TextBox();
            this.lblDescuentoPorcentualMultas = new System.Windows.Forms.Label();
            this.txtDescuentoPorcentualMultas = new System.Windows.Forms.TextBox();
            this.lblDescuentoPorcentualGastosEjecucion = new System.Windows.Forms.Label();
            this.txtDescuentoPorcentualGastosEjecucion = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnGenerarCotizacion = new System.Windows.Forms.Button();
            this.grpDatosContrato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdeudosPendientes)).BeginInit();
            this.grpDesgloseTotal.SuspendLayout();
            this.grpAdeudos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdeudosPagar)).BeginInit();
            this.pnlAdeudosPendientes.SuspendLayout();
            this.pnlDesgloseAdeudos.SuspendLayout();
            this.grpDescuentos.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNoContrato
            // 
            this.txtNoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoContrato.Location = new System.Drawing.Point(95, 33);
            this.txtNoContrato.Name = "txtNoContrato";
            this.txtNoContrato.ReadOnly = true;
            this.txtNoContrato.Size = new System.Drawing.Size(100, 20);
            this.txtNoContrato.TabIndex = 0;
            // 
            // lblNoContrato
            // 
            this.lblNoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoContrato.Location = new System.Drawing.Point(6, 32);
            this.lblNoContrato.Name = "lblNoContrato";
            this.lblNoContrato.Size = new System.Drawing.Size(83, 23);
            this.lblNoContrato.TabIndex = 1;
            this.lblNoContrato.Text = "No. Contrato";
            this.lblNoContrato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTitular
            // 
            this.txtTitular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitular.Location = new System.Drawing.Point(95, 59);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.ReadOnly = true;
            this.txtTitular.Size = new System.Drawing.Size(280, 20);
            this.txtTitular.TabIndex = 0;
            // 
            // lblTitular
            // 
            this.lblTitular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitular.Location = new System.Drawing.Point(6, 63);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(83, 13);
            this.lblTitular.TabIndex = 1;
            this.lblTitular.Text = "Titular";
            this.lblTitular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(95, 85);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(280, 20);
            this.txtDireccion.TabIndex = 0;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(6, 89);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(83, 13);
            this.lblDireccion.TabIndex = 1;
            this.lblDireccion.Text = "Dirección";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpDatosContrato
            // 
            this.grpDatosContrato.Controls.Add(this.lblNoContrato);
            this.grpDatosContrato.Controls.Add(this.txtNoContrato);
            this.grpDatosContrato.Controls.Add(this.lblTitular);
            this.grpDatosContrato.Controls.Add(this.txtTitular);
            this.grpDatosContrato.Controls.Add(this.lblDireccion);
            this.grpDatosContrato.Controls.Add(this.txtDireccion);
            this.grpDatosContrato.Controls.Add(this.lblTipoServicio);
            this.grpDatosContrato.Controls.Add(this.txtTipoServicio);
            this.grpDatosContrato.Controls.Add(this.lblTarifa);
            this.grpDatosContrato.Controls.Add(this.txtTarifa);
            this.grpDatosContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatosContrato.Location = new System.Drawing.Point(15, 12);
            this.grpDatosContrato.Name = "grpDatosContrato";
            this.grpDatosContrato.Size = new System.Drawing.Size(847, 120);
            this.grpDatosContrato.TabIndex = 2;
            this.grpDatosContrato.TabStop = false;
            this.grpDatosContrato.Text = "DATOS DEL CONTRATO";
            // 
            // lblTipoServicio
            // 
            this.lblTipoServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoServicio.Location = new System.Drawing.Point(431, 32);
            this.lblTipoServicio.Name = "lblTipoServicio";
            this.lblTipoServicio.Size = new System.Drawing.Size(102, 23);
            this.lblTipoServicio.TabIndex = 1;
            this.lblTipoServicio.Text = "Tipo de Servicio";
            this.lblTipoServicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTipoServicio
            // 
            this.txtTipoServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoServicio.Location = new System.Drawing.Point(539, 33);
            this.txtTipoServicio.Name = "txtTipoServicio";
            this.txtTipoServicio.ReadOnly = true;
            this.txtTipoServicio.Size = new System.Drawing.Size(170, 20);
            this.txtTipoServicio.TabIndex = 0;
            // 
            // lblTarifa
            // 
            this.lblTarifa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarifa.Location = new System.Drawing.Point(431, 58);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Size = new System.Drawing.Size(102, 23);
            this.lblTarifa.TabIndex = 1;
            this.lblTarifa.Text = "Tarifa";
            this.lblTarifa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTarifa
            // 
            this.txtTarifa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarifa.Location = new System.Drawing.Point(539, 59);
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.ReadOnly = true;
            this.txtTarifa.Size = new System.Drawing.Size(170, 20);
            this.txtTarifa.TabIndex = 0;
            // 
            // dgvAdeudosPendientes
            // 
            this.dgvAdeudosPendientes.AllowUserToAddRows = false;
            this.dgvAdeudosPendientes.AllowUserToDeleteRows = false;
            this.dgvAdeudosPendientes.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAdeudosPendientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAdeudosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdeudosPendientes.Enabled = false;
            this.dgvAdeudosPendientes.Location = new System.Drawing.Point(0, 4);
            this.dgvAdeudosPendientes.Name = "dgvAdeudosPendientes";
            this.dgvAdeudosPendientes.ReadOnly = true;
            this.dgvAdeudosPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdeudosPendientes.Size = new System.Drawing.Size(351, 269);
            this.dgvAdeudosPendientes.TabIndex = 3;
            // 
            // lblTituloDgv
            // 
            this.lblTituloDgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDgv.Location = new System.Drawing.Point(11, 14);
            this.lblTituloDgv.Name = "lblTituloDgv";
            this.lblTituloDgv.Size = new System.Drawing.Size(339, 23);
            this.lblTituloDgv.TabIndex = 4;
            this.lblTituloDgv.Text = "ADEUDOS PENDIENTES";
            this.lblTituloDgv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCantidadAdeudosPagar
            // 
            this.lblCantidadAdeudosPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadAdeudosPagar.Location = new System.Drawing.Point(461, 41);
            this.lblCantidadAdeudosPagar.Name = "lblCantidadAdeudosPagar";
            this.lblCantidadAdeudosPagar.Size = new System.Drawing.Size(142, 23);
            this.lblCantidadAdeudosPagar.TabIndex = 7;
            this.lblCantidadAdeudosPagar.Text = "ADEUDOS A PAGAR";
            this.lblCantidadAdeudosPagar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpDesgloseTotal
            // 
            this.grpDesgloseTotal.Controls.Add(this.lblOtros);
            this.grpDesgloseTotal.Controls.Add(this.txtOtros);
            this.grpDesgloseTotal.Controls.Add(this.lblRedondeo);
            this.grpDesgloseTotal.Controls.Add(this.txtRedondeo);
            this.grpDesgloseTotal.Controls.Add(this.lblDescuentosAplicados);
            this.grpDesgloseTotal.Controls.Add(this.lblAgua);
            this.grpDesgloseTotal.Controls.Add(this.txtAgua);
            this.grpDesgloseTotal.Controls.Add(this.lblAlcantarillado);
            this.grpDesgloseTotal.Controls.Add(this.txtAlcantarillado);
            this.grpDesgloseTotal.Controls.Add(this.lblSaneamiento);
            this.grpDesgloseTotal.Controls.Add(this.txtSaneamiento);
            this.grpDesgloseTotal.Controls.Add(this.lblRecargos);
            this.grpDesgloseTotal.Controls.Add(this.txtRecargos);
            this.grpDesgloseTotal.Controls.Add(this.lblMultas);
            this.grpDesgloseTotal.Controls.Add(this.txtMultas);
            this.grpDesgloseTotal.Controls.Add(this.lblGastosEjecucion);
            this.grpDesgloseTotal.Controls.Add(this.txtGastosEjecucion);
            this.grpDesgloseTotal.Controls.Add(this.lblIVA);
            this.grpDesgloseTotal.Controls.Add(this.txtIVA);
            this.grpDesgloseTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDesgloseTotal.Location = new System.Drawing.Point(17, 19);
            this.grpDesgloseTotal.Name = "grpDesgloseTotal";
            this.grpDesgloseTotal.Size = new System.Drawing.Size(387, 203);
            this.grpDesgloseTotal.TabIndex = 8;
            this.grpDesgloseTotal.TabStop = false;
            this.grpDesgloseTotal.Text = "TOTAL <Mes. Año — Mes. Año>";
            // 
            // lblOtros
            // 
            this.lblOtros.AutoSize = true;
            this.lblOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtros.Location = new System.Drawing.Point(218, 35);
            this.lblOtros.Name = "lblOtros";
            this.lblOtros.Size = new System.Drawing.Size(32, 13);
            this.lblOtros.TabIndex = 12;
            this.lblOtros.Text = "Otros";
            this.lblOtros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOtros
            // 
            this.txtOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtros.Location = new System.Drawing.Point(258, 31);
            this.txtOtros.Name = "txtOtros";
            this.txtOtros.ReadOnly = true;
            this.txtOtros.Size = new System.Drawing.Size(88, 20);
            this.txtOtros.TabIndex = 11;
            this.txtOtros.Text = "0.00";
            this.txtOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRedondeo
            // 
            this.lblRedondeo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedondeo.Location = new System.Drawing.Point(194, 82);
            this.lblRedondeo.Name = "lblRedondeo";
            this.lblRedondeo.Size = new System.Drawing.Size(58, 23);
            this.lblRedondeo.TabIndex = 10;
            this.lblRedondeo.Text = "Redondeo";
            this.lblRedondeo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRedondeo
            // 
            this.txtRedondeo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRedondeo.Location = new System.Drawing.Point(258, 83);
            this.txtRedondeo.Name = "txtRedondeo";
            this.txtRedondeo.ReadOnly = true;
            this.txtRedondeo.Size = new System.Drawing.Size(88, 20);
            this.txtRedondeo.TabIndex = 9;
            this.txtRedondeo.Text = "0.00";
            this.txtRedondeo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDescuentosAplicados
            // 
            this.lblDescuentosAplicados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentosAplicados.ForeColor = System.Drawing.Color.Red;
            this.lblDescuentosAplicados.Location = new System.Drawing.Point(195, 109);
            this.lblDescuentosAplicados.Name = "lblDescuentosAplicados";
            this.lblDescuentosAplicados.Size = new System.Drawing.Size(179, 74);
            this.lblDescuentosAplicados.TabIndex = 6;
            // 
            // lblAgua
            // 
            this.lblAgua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgua.Location = new System.Drawing.Point(6, 31);
            this.lblAgua.Name = "lblAgua";
            this.lblAgua.Size = new System.Drawing.Size(80, 23);
            this.lblAgua.TabIndex = 3;
            this.lblAgua.Text = "Agua";
            this.lblAgua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAgua
            // 
            this.txtAgua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgua.Location = new System.Drawing.Point(92, 31);
            this.txtAgua.Name = "txtAgua";
            this.txtAgua.ReadOnly = true;
            this.txtAgua.Size = new System.Drawing.Size(91, 20);
            this.txtAgua.TabIndex = 2;
            this.txtAgua.Text = "0.00";
            this.txtAgua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAlcantarillado
            // 
            this.lblAlcantarillado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlcantarillado.Location = new System.Drawing.Point(6, 57);
            this.lblAlcantarillado.Name = "lblAlcantarillado";
            this.lblAlcantarillado.Size = new System.Drawing.Size(80, 23);
            this.lblAlcantarillado.TabIndex = 5;
            this.lblAlcantarillado.Text = "Alcantarillado";
            this.lblAlcantarillado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAlcantarillado
            // 
            this.txtAlcantarillado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlcantarillado.Location = new System.Drawing.Point(92, 58);
            this.txtAlcantarillado.Name = "txtAlcantarillado";
            this.txtAlcantarillado.ReadOnly = true;
            this.txtAlcantarillado.Size = new System.Drawing.Size(91, 20);
            this.txtAlcantarillado.TabIndex = 4;
            this.txtAlcantarillado.Text = "0.00";
            this.txtAlcantarillado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSaneamiento
            // 
            this.lblSaneamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaneamiento.Location = new System.Drawing.Point(6, 83);
            this.lblSaneamiento.Name = "lblSaneamiento";
            this.lblSaneamiento.Size = new System.Drawing.Size(80, 23);
            this.lblSaneamiento.TabIndex = 5;
            this.lblSaneamiento.Text = "Saneamiento";
            this.lblSaneamiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSaneamiento
            // 
            this.txtSaneamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaneamiento.Location = new System.Drawing.Point(92, 84);
            this.txtSaneamiento.Name = "txtSaneamiento";
            this.txtSaneamiento.ReadOnly = true;
            this.txtSaneamiento.Size = new System.Drawing.Size(91, 20);
            this.txtSaneamiento.TabIndex = 4;
            this.txtSaneamiento.Text = "0.00";
            this.txtSaneamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRecargos
            // 
            this.lblRecargos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecargos.Location = new System.Drawing.Point(6, 109);
            this.lblRecargos.Name = "lblRecargos";
            this.lblRecargos.Size = new System.Drawing.Size(80, 23);
            this.lblRecargos.TabIndex = 5;
            this.lblRecargos.Text = "Recargos";
            this.lblRecargos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRecargos
            // 
            this.txtRecargos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecargos.Location = new System.Drawing.Point(92, 110);
            this.txtRecargos.Name = "txtRecargos";
            this.txtRecargos.ReadOnly = true;
            this.txtRecargos.Size = new System.Drawing.Size(91, 20);
            this.txtRecargos.TabIndex = 4;
            this.txtRecargos.Text = "0.00";
            this.txtRecargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMultas
            // 
            this.lblMultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultas.Location = new System.Drawing.Point(6, 135);
            this.lblMultas.Name = "lblMultas";
            this.lblMultas.Size = new System.Drawing.Size(80, 23);
            this.lblMultas.TabIndex = 5;
            this.lblMultas.Text = "Multas";
            this.lblMultas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMultas
            // 
            this.txtMultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMultas.Location = new System.Drawing.Point(92, 136);
            this.txtMultas.Name = "txtMultas";
            this.txtMultas.ReadOnly = true;
            this.txtMultas.Size = new System.Drawing.Size(91, 20);
            this.txtMultas.TabIndex = 4;
            this.txtMultas.Text = "0.00";
            this.txtMultas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGastosEjecucion
            // 
            this.lblGastosEjecucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGastosEjecucion.Location = new System.Drawing.Point(6, 161);
            this.lblGastosEjecucion.Name = "lblGastosEjecucion";
            this.lblGastosEjecucion.Size = new System.Drawing.Size(80, 23);
            this.lblGastosEjecucion.TabIndex = 5;
            this.lblGastosEjecucion.Text = "Gastos Ejec.";
            this.lblGastosEjecucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGastosEjecucion
            // 
            this.txtGastosEjecucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastosEjecucion.Location = new System.Drawing.Point(92, 162);
            this.txtGastosEjecucion.Name = "txtGastosEjecucion";
            this.txtGastosEjecucion.ReadOnly = true;
            this.txtGastosEjecucion.Size = new System.Drawing.Size(91, 20);
            this.txtGastosEjecucion.TabIndex = 4;
            this.txtGastosEjecucion.Text = "0.00";
            this.txtGastosEjecucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIVA
            // 
            this.lblIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA.Location = new System.Drawing.Point(226, 56);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(26, 23);
            this.lblIVA.TabIndex = 5;
            this.lblIVA.Text = "IVA";
            this.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIVA
            // 
            this.txtIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(258, 57);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(88, 20);
            this.txtIVA.TabIndex = 4;
            this.txtIVA.Text = "0.00";
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpAdeudos
            // 
            this.grpAdeudos.Controls.Add(this.btnSeleccionarTodos);
            this.grpAdeudos.Controls.Add(this.lblTituloDgv);
            this.grpAdeudos.Controls.Add(this.nudAdeudosPagar);
            this.grpAdeudos.Controls.Add(this.lblCantidadAdeudosPagar);
            this.grpAdeudos.Controls.Add(this.lblTotalPagar);
            this.grpAdeudos.Controls.Add(this.pnlAdeudosPendientes);
            this.grpAdeudos.Controls.Add(this.pnlDesgloseAdeudos);
            this.grpAdeudos.Location = new System.Drawing.Point(13, 139);
            this.grpAdeudos.Name = "grpAdeudos";
            this.grpAdeudos.Size = new System.Drawing.Size(849, 374);
            this.grpAdeudos.TabIndex = 14;
            this.grpAdeudos.TabStop = false;
            // 
            // btnSeleccionarTodos
            // 
            this.btnSeleccionarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarTodos.Location = new System.Drawing.Point(610, 41);
            this.btnSeleccionarTodos.Name = "btnSeleccionarTodos";
            this.btnSeleccionarTodos.Size = new System.Drawing.Size(156, 23);
            this.btnSeleccionarTodos.TabIndex = 14;
            this.btnSeleccionarTodos.Text = "SELECCIONAR TODOS";
            this.btnSeleccionarTodos.UseVisualStyleBackColor = true;
            this.btnSeleccionarTodos.Click += new System.EventHandler(this.btnSeleccionarTodos_Click);
            // 
            // nudAdeudosPagar
            // 
            this.nudAdeudosPagar.Location = new System.Drawing.Point(420, 42);
            this.nudAdeudosPagar.Name = "nudAdeudosPagar";
            this.nudAdeudosPagar.Size = new System.Drawing.Size(35, 20);
            this.nudAdeudosPagar.TabIndex = 11;
            this.nudAdeudosPagar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAdeudosPagar.ValueChanged += new System.EventHandler(this.nudAdeudosPagar_ValueChanged);
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.Location = new System.Drawing.Point(399, 334);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(407, 23);
            this.lblTotalPagar.TabIndex = 10;
            this.lblTotalPagar.Text = "Total a pagar $0.00";
            this.lblTotalPagar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAdeudosPendientes
            // 
            this.pnlAdeudosPendientes.AutoScroll = true;
            this.pnlAdeudosPendientes.Controls.Add(this.dgvAdeudosPendientes);
            this.pnlAdeudosPendientes.Location = new System.Drawing.Point(7, 40);
            this.pnlAdeudosPendientes.Name = "pnlAdeudosPendientes";
            this.pnlAdeudosPendientes.Size = new System.Drawing.Size(354, 276);
            this.pnlAdeudosPendientes.TabIndex = 13;
            // 
            // pnlDesgloseAdeudos
            // 
            this.pnlDesgloseAdeudos.AutoScroll = true;
            this.pnlDesgloseAdeudos.Controls.Add(this.grpDesgloseTotal);
            this.pnlDesgloseAdeudos.Controls.Add(this.grpDescuentos);
            this.pnlDesgloseAdeudos.Location = new System.Drawing.Point(403, 68);
            this.pnlDesgloseAdeudos.Name = "pnlDesgloseAdeudos";
            this.pnlDesgloseAdeudos.Size = new System.Drawing.Size(440, 245);
            this.pnlDesgloseAdeudos.TabIndex = 29;
            // 
            // grpDescuentos
            // 
            this.grpDescuentos.Controls.Add(this.txtDescuentoGeneral);
            this.grpDescuentos.Controls.Add(this.lblDescuentoPorcentualAgua);
            this.grpDescuentos.Controls.Add(this.txtDescuentoPorcentualAgua);
            this.grpDescuentos.Controls.Add(this.lblDescuentoPorcentualAlcantarillado);
            this.grpDescuentos.Controls.Add(this.txtDescuentoPorcentualAlcantarillado);
            this.grpDescuentos.Controls.Add(this.lblDescuentoPorcentualSaneamiento);
            this.grpDescuentos.Controls.Add(this.txtDescuentoPorcentualSaneamiento);
            this.grpDescuentos.Controls.Add(this.lblDescuentoPorcentualRecargos);
            this.grpDescuentos.Controls.Add(this.txtDescuentoPorcentualRecargos);
            this.grpDescuentos.Controls.Add(this.lblDescuentoPorcentualIVA);
            this.grpDescuentos.Controls.Add(this.txtDescuentoPorcentualIVA);
            this.grpDescuentos.Controls.Add(this.lblDescuentoPorcentualMultas);
            this.grpDescuentos.Controls.Add(this.txtDescuentoPorcentualMultas);
            this.grpDescuentos.Controls.Add(this.lblDescuentoPorcentualGastosEjecucion);
            this.grpDescuentos.Controls.Add(this.txtDescuentoPorcentualGastosEjecucion);
            this.grpDescuentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDescuentos.Location = new System.Drawing.Point(16, 228);
            this.grpDescuentos.Name = "grpDescuentos";
            this.grpDescuentos.Size = new System.Drawing.Size(388, 130);
            this.grpDescuentos.TabIndex = 28;
            this.grpDescuentos.TabStop = false;
            this.grpDescuentos.Text = "DESCUENTOS %";
            // 
            // txtDescuentoGeneral
            // 
            this.txtDescuentoGeneral.Location = new System.Drawing.Point(284, 95);
            this.txtDescuentoGeneral.Name = "txtDescuentoGeneral";
            this.txtDescuentoGeneral.Size = new System.Drawing.Size(91, 20);
            this.txtDescuentoGeneral.TabIndex = 20;
            this.txtDescuentoGeneral.TextChanged += new System.EventHandler(this.txtDescuentoGeneral_TextChanged);
            this.txtDescuentoGeneral.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoGeneral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtDescuentoGeneral.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            // 
            // lblDescuentoPorcentualAgua
            // 
            this.lblDescuentoPorcentualAgua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoPorcentualAgua.Location = new System.Drawing.Point(7, 16);
            this.lblDescuentoPorcentualAgua.Name = "lblDescuentoPorcentualAgua";
            this.lblDescuentoPorcentualAgua.Size = new System.Drawing.Size(80, 23);
            this.lblDescuentoPorcentualAgua.TabIndex = 7;
            this.lblDescuentoPorcentualAgua.Text = "Agua";
            this.lblDescuentoPorcentualAgua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescuentoPorcentualAgua
            // 
            this.txtDescuentoPorcentualAgua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuentoPorcentualAgua.Location = new System.Drawing.Point(93, 17);
            this.txtDescuentoPorcentualAgua.Name = "txtDescuentoPorcentualAgua";
            this.txtDescuentoPorcentualAgua.Size = new System.Drawing.Size(91, 20);
            this.txtDescuentoPorcentualAgua.TabIndex = 6;
            this.txtDescuentoPorcentualAgua.Text = "0.00";
            this.txtDescuentoPorcentualAgua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuentoPorcentualAgua.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualAgua.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuentoPorcentualAgua.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualAgua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtDescuentoPorcentualAgua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtDescuentoPorcentualAgua.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblDescuentoPorcentualAlcantarillado
            // 
            this.lblDescuentoPorcentualAlcantarillado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoPorcentualAlcantarillado.Location = new System.Drawing.Point(198, 16);
            this.lblDescuentoPorcentualAlcantarillado.Name = "lblDescuentoPorcentualAlcantarillado";
            this.lblDescuentoPorcentualAlcantarillado.Size = new System.Drawing.Size(80, 23);
            this.lblDescuentoPorcentualAlcantarillado.TabIndex = 14;
            this.lblDescuentoPorcentualAlcantarillado.Text = "Alcantarillado";
            this.lblDescuentoPorcentualAlcantarillado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescuentoPorcentualAlcantarillado
            // 
            this.txtDescuentoPorcentualAlcantarillado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuentoPorcentualAlcantarillado.Location = new System.Drawing.Point(284, 17);
            this.txtDescuentoPorcentualAlcantarillado.Name = "txtDescuentoPorcentualAlcantarillado";
            this.txtDescuentoPorcentualAlcantarillado.Size = new System.Drawing.Size(91, 20);
            this.txtDescuentoPorcentualAlcantarillado.TabIndex = 8;
            this.txtDescuentoPorcentualAlcantarillado.Text = "0.00";
            this.txtDescuentoPorcentualAlcantarillado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuentoPorcentualAlcantarillado.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualAlcantarillado.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuentoPorcentualAlcantarillado.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualAlcantarillado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtDescuentoPorcentualAlcantarillado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtDescuentoPorcentualAlcantarillado.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblDescuentoPorcentualSaneamiento
            // 
            this.lblDescuentoPorcentualSaneamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoPorcentualSaneamiento.Location = new System.Drawing.Point(7, 42);
            this.lblDescuentoPorcentualSaneamiento.Name = "lblDescuentoPorcentualSaneamiento";
            this.lblDescuentoPorcentualSaneamiento.Size = new System.Drawing.Size(80, 23);
            this.lblDescuentoPorcentualSaneamiento.TabIndex = 15;
            this.lblDescuentoPorcentualSaneamiento.Text = "Saneamiento";
            this.lblDescuentoPorcentualSaneamiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescuentoPorcentualSaneamiento
            // 
            this.txtDescuentoPorcentualSaneamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuentoPorcentualSaneamiento.Location = new System.Drawing.Point(93, 43);
            this.txtDescuentoPorcentualSaneamiento.Name = "txtDescuentoPorcentualSaneamiento";
            this.txtDescuentoPorcentualSaneamiento.Size = new System.Drawing.Size(91, 20);
            this.txtDescuentoPorcentualSaneamiento.TabIndex = 9;
            this.txtDescuentoPorcentualSaneamiento.Text = "0.00";
            this.txtDescuentoPorcentualSaneamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuentoPorcentualSaneamiento.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualSaneamiento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuentoPorcentualSaneamiento.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualSaneamiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtDescuentoPorcentualSaneamiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtDescuentoPorcentualSaneamiento.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblDescuentoPorcentualRecargos
            // 
            this.lblDescuentoPorcentualRecargos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoPorcentualRecargos.Location = new System.Drawing.Point(198, 42);
            this.lblDescuentoPorcentualRecargos.Name = "lblDescuentoPorcentualRecargos";
            this.lblDescuentoPorcentualRecargos.Size = new System.Drawing.Size(80, 23);
            this.lblDescuentoPorcentualRecargos.TabIndex = 16;
            this.lblDescuentoPorcentualRecargos.Text = "Recargos";
            this.lblDescuentoPorcentualRecargos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescuentoPorcentualRecargos
            // 
            this.txtDescuentoPorcentualRecargos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuentoPorcentualRecargos.Location = new System.Drawing.Point(284, 43);
            this.txtDescuentoPorcentualRecargos.Name = "txtDescuentoPorcentualRecargos";
            this.txtDescuentoPorcentualRecargos.Size = new System.Drawing.Size(91, 20);
            this.txtDescuentoPorcentualRecargos.TabIndex = 10;
            this.txtDescuentoPorcentualRecargos.Text = "0.00";
            this.txtDescuentoPorcentualRecargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuentoPorcentualRecargos.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualRecargos.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuentoPorcentualRecargos.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualRecargos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtDescuentoPorcentualRecargos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtDescuentoPorcentualRecargos.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblDescuentoPorcentualIVA
            // 
            this.lblDescuentoPorcentualIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoPorcentualIVA.Location = new System.Drawing.Point(7, 94);
            this.lblDescuentoPorcentualIVA.Name = "lblDescuentoPorcentualIVA";
            this.lblDescuentoPorcentualIVA.Size = new System.Drawing.Size(80, 23);
            this.lblDescuentoPorcentualIVA.TabIndex = 19;
            this.lblDescuentoPorcentualIVA.Text = "IVA";
            this.lblDescuentoPorcentualIVA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescuentoPorcentualIVA
            // 
            this.txtDescuentoPorcentualIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuentoPorcentualIVA.Location = new System.Drawing.Point(93, 95);
            this.txtDescuentoPorcentualIVA.Name = "txtDescuentoPorcentualIVA";
            this.txtDescuentoPorcentualIVA.Size = new System.Drawing.Size(91, 20);
            this.txtDescuentoPorcentualIVA.TabIndex = 13;
            this.txtDescuentoPorcentualIVA.Text = "0.00";
            this.txtDescuentoPorcentualIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuentoPorcentualIVA.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualIVA.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuentoPorcentualIVA.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualIVA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtDescuentoPorcentualIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtDescuentoPorcentualIVA.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblDescuentoPorcentualMultas
            // 
            this.lblDescuentoPorcentualMultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoPorcentualMultas.Location = new System.Drawing.Point(7, 68);
            this.lblDescuentoPorcentualMultas.Name = "lblDescuentoPorcentualMultas";
            this.lblDescuentoPorcentualMultas.Size = new System.Drawing.Size(80, 23);
            this.lblDescuentoPorcentualMultas.TabIndex = 17;
            this.lblDescuentoPorcentualMultas.Text = "Multas";
            this.lblDescuentoPorcentualMultas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescuentoPorcentualMultas
            // 
            this.txtDescuentoPorcentualMultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuentoPorcentualMultas.Location = new System.Drawing.Point(93, 69);
            this.txtDescuentoPorcentualMultas.Name = "txtDescuentoPorcentualMultas";
            this.txtDescuentoPorcentualMultas.Size = new System.Drawing.Size(91, 20);
            this.txtDescuentoPorcentualMultas.TabIndex = 11;
            this.txtDescuentoPorcentualMultas.Text = "0.00";
            this.txtDescuentoPorcentualMultas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuentoPorcentualMultas.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualMultas.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuentoPorcentualMultas.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualMultas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtDescuentoPorcentualMultas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtDescuentoPorcentualMultas.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // lblDescuentoPorcentualGastosEjecucion
            // 
            this.lblDescuentoPorcentualGastosEjecucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoPorcentualGastosEjecucion.Location = new System.Drawing.Point(198, 66);
            this.lblDescuentoPorcentualGastosEjecucion.Name = "lblDescuentoPorcentualGastosEjecucion";
            this.lblDescuentoPorcentualGastosEjecucion.Size = new System.Drawing.Size(80, 23);
            this.lblDescuentoPorcentualGastosEjecucion.TabIndex = 18;
            this.lblDescuentoPorcentualGastosEjecucion.Text = "Gastos Ejec.";
            this.lblDescuentoPorcentualGastosEjecucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescuentoPorcentualGastosEjecucion
            // 
            this.txtDescuentoPorcentualGastosEjecucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuentoPorcentualGastosEjecucion.Location = new System.Drawing.Point(284, 67);
            this.txtDescuentoPorcentualGastosEjecucion.Name = "txtDescuentoPorcentualGastosEjecucion";
            this.txtDescuentoPorcentualGastosEjecucion.Size = new System.Drawing.Size(91, 20);
            this.txtDescuentoPorcentualGastosEjecucion.TabIndex = 12;
            this.txtDescuentoPorcentualGastosEjecucion.Text = "0.00";
            this.txtDescuentoPorcentualGastosEjecucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuentoPorcentualGastosEjecucion.Click += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualGastosEjecucion.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuentoPorcentualGastosEjecucion.Enter += new System.EventHandler(this.seleccionarEntrada_AnyEvent);
            this.txtDescuentoPorcentualGastosEjecucion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaDecimal_KeyDown);
            this.txtDescuentoPorcentualGastosEjecucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entradaDecimal_KeyPress);
            this.txtDescuentoPorcentualGastosEjecucion.Leave += new System.EventHandler(this.reestablecerEntradasVacias_Leave);
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(772, 518);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(90, 35);
            this.btnPagar.TabIndex = 27;
            this.btnPagar.Text = "PAGAR";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnGenerarCotizacion
            // 
            this.btnGenerarCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarCotizacion.Image = global::SAPA.Properties.Resources.Aceptar_33x33;
            this.btnGenerarCotizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarCotizacion.Location = new System.Drawing.Point(12, 515);
            this.btnGenerarCotizacion.Name = "btnGenerarCotizacion";
            this.btnGenerarCotizacion.Size = new System.Drawing.Size(184, 35);
            this.btnGenerarCotizacion.TabIndex = 28;
            this.btnGenerarCotizacion.Text = "GENERAR COTIZACIÓN";
            this.btnGenerarCotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarCotizacion.UseVisualStyleBackColor = true;
            this.btnGenerarCotizacion.Click += new System.EventHandler(this.btnGenerarCotizacion_Click);
            // 
            // DlgPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(876, 562);
            this.Controls.Add(this.btnGenerarCotizacion);
            this.Controls.Add(this.grpDatosContrato);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.grpAdeudos);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DlgPagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagar Adeudos";
            this.Load += new System.EventHandler(this.DlgPagar_Load);
            this.Shown += new System.EventHandler(this.DlgPagar_Shown);
            this.grpDatosContrato.ResumeLayout(false);
            this.grpDatosContrato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdeudosPendientes)).EndInit();
            this.grpDesgloseTotal.ResumeLayout(false);
            this.grpDesgloseTotal.PerformLayout();
            this.grpAdeudos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudAdeudosPagar)).EndInit();
            this.pnlAdeudosPendientes.ResumeLayout(false);
            this.pnlDesgloseAdeudos.ResumeLayout(false);
            this.grpDescuentos.ResumeLayout(false);
            this.grpDescuentos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoContrato;
        private System.Windows.Forms.Label lblNoContrato;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.GroupBox grpDatosContrato;
        private System.Windows.Forms.TextBox txtTarifa;
        private System.Windows.Forms.TextBox txtTipoServicio;
        private System.Windows.Forms.Label lblTarifa;
        private System.Windows.Forms.Label lblTipoServicio;
        private System.Windows.Forms.DataGridView dgvAdeudosPendientes;
        private System.Windows.Forms.Label lblTituloDgv;
        private System.Windows.Forms.Label lblCantidadAdeudosPagar;
        private System.Windows.Forms.GroupBox grpDesgloseTotal;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Label lblGastosEjecucion;
        private System.Windows.Forms.Label lblMultas;
        private System.Windows.Forms.Label lblRecargos;
        private System.Windows.Forms.Label lblSaneamiento;
        private System.Windows.Forms.Label lblAlcantarillado;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.TextBox txtGastosEjecucion;
        private System.Windows.Forms.TextBox txtMultas;
        private System.Windows.Forms.TextBox txtRecargos;
        private System.Windows.Forms.TextBox txtSaneamiento;
        private System.Windows.Forms.TextBox txtAlcantarillado;
        private System.Windows.Forms.Label lblAgua;
        private System.Windows.Forms.TextBox txtAgua;
        private System.Windows.Forms.GroupBox grpAdeudos;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.NumericUpDown nudAdeudosPagar;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label lblDescuentosAplicados;
        private System.Windows.Forms.Panel pnlAdeudosPendientes;
        private System.Windows.Forms.Button btnSeleccionarTodos;
        private System.Windows.Forms.Label lblRedondeo;
        private System.Windows.Forms.TextBox txtRedondeo;
        private System.Windows.Forms.GroupBox grpDescuentos;
        private System.Windows.Forms.Label lblDescuentoPorcentualAgua;
        private System.Windows.Forms.TextBox txtDescuentoPorcentualAgua;
        private System.Windows.Forms.Label lblDescuentoPorcentualAlcantarillado;
        private System.Windows.Forms.TextBox txtDescuentoPorcentualAlcantarillado;
        private System.Windows.Forms.Label lblDescuentoPorcentualSaneamiento;
        private System.Windows.Forms.TextBox txtDescuentoPorcentualSaneamiento;
        private System.Windows.Forms.Label lblDescuentoPorcentualRecargos;
        private System.Windows.Forms.TextBox txtDescuentoPorcentualRecargos;
        private System.Windows.Forms.TextBox txtDescuentoPorcentualIVA;
        private System.Windows.Forms.Label lblDescuentoPorcentualIVA;
        private System.Windows.Forms.Label lblDescuentoPorcentualMultas;
        private System.Windows.Forms.TextBox txtDescuentoPorcentualMultas;
        private System.Windows.Forms.Label lblDescuentoPorcentualGastosEjecucion;
        private System.Windows.Forms.TextBox txtDescuentoPorcentualGastosEjecucion;
        private System.Windows.Forms.Panel pnlDesgloseAdeudos;
        private System.Windows.Forms.TextBox txtDescuentoGeneral;
        private System.Windows.Forms.Label lblOtros;
        private System.Windows.Forms.TextBox txtOtros;
        private System.Windows.Forms.Button btnGenerarCotizacion;
    }
}
