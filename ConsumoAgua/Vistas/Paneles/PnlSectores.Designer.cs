namespace SAPA.Vistas.Paneles {
    partial class PnlSectores {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PnlSectores));
            this.dgvSectores = new System.Windows.Forms.DataGridView();
            this.cmsOpcionesSector = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmActualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBorrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsLblDescripcion = new System.Windows.Forms.ToolStripLabel();
            this.tstTxtDescripcion = new System.Windows.Forms.ToolStripTextBox();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregarSector = new System.Windows.Forms.ToolStripButton();
            this.btnEditarSector = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarSector = new System.Windows.Forms.ToolStripButton();
            this.btnAsociarColonias = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSectores)).BeginInit();
            this.cmsOpcionesSector.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSectores
            // 
            this.dgvSectores.AllowUserToAddRows = false;
            this.dgvSectores.AllowUserToDeleteRows = false;
            this.dgvSectores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSectores.BackgroundColor = System.Drawing.Color.White;
            this.dgvSectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSectores.ContextMenuStrip = this.cmsOpcionesSector;
            this.dgvSectores.Location = new System.Drawing.Point(13, 40);
            this.dgvSectores.MultiSelect = false;
            this.dgvSectores.Name = "dgvSectores";
            this.dgvSectores.ReadOnly = true;
            this.dgvSectores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSectores.Size = new System.Drawing.Size(1375, 648);
            this.dgvSectores.TabIndex = 1;
            // 
            // cmsOpcionesSector
            // 
            this.cmsOpcionesSector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmActualizar,
            this.tsmBorrar});
            this.cmsOpcionesSector.Name = "contextMenuStrip1";
            this.cmsOpcionesSector.Size = new System.Drawing.Size(127, 48);
            // 
            // tsmActualizar
            // 
            this.tsmActualizar.Name = "tsmActualizar";
            this.tsmActualizar.Size = new System.Drawing.Size(126, 22);
            this.tsmActualizar.Text = "Actualizar";
            this.tsmActualizar.Click += new System.EventHandler(this.tsmActualizar_Click);
            // 
            // tsmBorrar
            // 
            this.tsmBorrar.Name = "tsmBorrar";
            this.tsmBorrar.Size = new System.Drawing.Size(126, 22);
            this.tsmBorrar.Text = "Borrar";
            this.tsmBorrar.Click += new System.EventHandler(this.tsmBorrar_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.toolStrip.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblDescripcion,
            this.tstTxtDescripcion,
            this.tsSeparador,
            this.btnAgregarSector,
            this.btnEditarSector,
            this.btnEliminarSector,
            this.btnAsociarColonias,
            this.btnCerrar});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1400, 37);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 43;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsLblDescripcion
            // 
            this.tsLblDescripcion.Name = "tsLblDescripcion";
            this.tsLblDescripcion.Size = new System.Drawing.Size(36, 34);
            this.tsLblDescripcion.Text = "Calle:";
            // 
            // tstTxtDescripcion
            // 
            this.tstTxtDescripcion.Name = "tstTxtDescripcion";
            this.tstTxtDescripcion.Size = new System.Drawing.Size(200, 37);
            this.tstTxtDescripcion.TextChanged += new System.EventHandler(this.tstTxtDescripcion_TextChanged);
            // 
            // tsSeparador
            // 
            this.tsSeparador.Name = "tsSeparador";
            this.tsSeparador.Size = new System.Drawing.Size(6, 37);
            // 
            // btnAgregarSector
            // 
            this.btnAgregarSector.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAgregarSector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarSector.Name = "btnAgregarSector";
            this.btnAgregarSector.Size = new System.Drawing.Size(119, 34);
            this.btnAgregarSector.Text = "Agregar Sector";
            this.btnAgregarSector.Click += new System.EventHandler(this.btnAgregarSector_Click);
            // 
            // btnEditarSector
            // 
            this.btnEditarSector.Image = global::SAPA.Properties.Resources.Editar;
            this.btnEditarSector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarSector.Name = "btnEditarSector";
            this.btnEditarSector.Size = new System.Drawing.Size(107, 34);
            this.btnEditarSector.Text = "Editar Sector";
            this.btnEditarSector.Click += new System.EventHandler(this.btnEditarSector_Click);
            // 
            // btnEliminarSector
            // 
            this.btnEliminarSector.Image = global::SAPA.Properties.Resources.Eliminar;
            this.btnEliminarSector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarSector.Name = "btnEliminarSector";
            this.btnEliminarSector.Size = new System.Drawing.Size(120, 34);
            this.btnEliminarSector.Text = "Eliminar Sector";
            this.btnEliminarSector.Click += new System.EventHandler(this.btnEliminarSector_Click);
            // 
            // btnAsociarColonias
            // 
            this.btnAsociarColonias.Image = global::SAPA.Properties.Resources.Agregar;
            this.btnAsociarColonias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAsociarColonias.Name = "btnAsociarColonias";
            this.btnAsociarColonias.Size = new System.Drawing.Size(129, 34);
            this.btnAsociarColonias.Text = "Asociar Colonias";
            this.btnAsociarColonias.Click += new System.EventHandler(this.btnAsociarColonias_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.Image = global::SAPA.Properties.Resources.CerrarPantalla;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 34);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PnlSectores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::SAPA.Properties.Settings.Default.FondoVentanaCaptura;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvSectores);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::SAPA.Properties.Settings.Default, "FondoVentanaCaptura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PnlSectores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sectores";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PnlSectores_FormClosed);
            this.Load += new System.EventHandler(this.PnlSectores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSectores)).EndInit();
            this.cmsOpcionesSector.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvSectores;
        private System.Windows.Forms.ContextMenuStrip cmsOpcionesSector;
        private System.Windows.Forms.ToolStripMenuItem tsmActualizar;
        private System.Windows.Forms.ToolStripMenuItem tsmBorrar;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tsLblDescripcion;
        private System.Windows.Forms.ToolStripTextBox tstTxtDescripcion;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStripButton btnAsociarColonias;
        private System.Windows.Forms.ToolStripButton btnAgregarSector;
        private System.Windows.Forms.ToolStripButton btnEditarSector;
        private System.Windows.Forms.ToolStripButton btnEliminarSector;
        private System.Windows.Forms.ToolStripLabel btnCerrar;
    }
}
