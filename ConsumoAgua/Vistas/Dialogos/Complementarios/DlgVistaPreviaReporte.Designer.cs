namespace SAPA.Vistas.Dialogos.Complementarios
{
    partial class DlgVistaPreviaReporte
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
            this.crvVistaPreviaReporte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvVistaPreviaReporte
            // 
            this.crvVistaPreviaReporte.ActiveViewIndex = -1;
            this.crvVistaPreviaReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVistaPreviaReporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVistaPreviaReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVistaPreviaReporte.Location = new System.Drawing.Point(0, 0);
            this.crvVistaPreviaReporte.Name = "crvVistaPreviaReporte";
            this.crvVistaPreviaReporte.ShowLogo = false;
            this.crvVistaPreviaReporte.ShowParameterPanelButton = false;
            this.crvVistaPreviaReporte.Size = new System.Drawing.Size(1002, 531);
            this.crvVistaPreviaReporte.TabIndex = 1;
            this.crvVistaPreviaReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // DlgVistaPreviaReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 531);
            this.Controls.Add(this.crvVistaPreviaReporte);
            this.Name = "DlgVistaPreviaReporte";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista previa del reporte";
            this.Load += new System.EventHandler(this.DlgVistaPreviaReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVistaPreviaReporte;
    }
}
