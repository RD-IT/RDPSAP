namespace PSAP.VIEW.BSVIEW
{
    partial class FrmEDrawingPreview
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
            this.pnleDrawing = new DevExpress.XtraEditors.PanelControl();
            this.eDrawingCtl = new eDrawingHostControl.eDrawingControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnleDrawing)).BeginInit();
            this.pnleDrawing.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnleDrawing
            // 
            this.pnleDrawing.Controls.Add(this.eDrawingCtl);
            this.pnleDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnleDrawing.Location = new System.Drawing.Point(0, 0);
            this.pnleDrawing.Name = "pnleDrawing";
            this.pnleDrawing.Size = new System.Drawing.Size(784, 561);
            this.pnleDrawing.TabIndex = 0;
            // 
            // eDrawingCtl
            // 
            this.eDrawingCtl.BackColor = System.Drawing.Color.White;
            this.eDrawingCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eDrawingCtl.EnableFeatures = 1577040;
            this.eDrawingCtl.Location = new System.Drawing.Point(2, 2);
            this.eDrawingCtl.Name = "eDrawingCtl";
            this.eDrawingCtl.ShowControlInformation = false;
            this.eDrawingCtl.Size = new System.Drawing.Size(780, 557);
            this.eDrawingCtl.TabIndex = 1;
            // 
            // FrmEDrawingPreview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnleDrawing);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEDrawingPreview";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "零件预览";
            this.Text = "零件预览";
            this.Load += new System.EventHandler(this.FrmEDrawingPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnleDrawing)).EndInit();
            this.pnleDrawing.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnleDrawing;
        private eDrawingHostControl.eDrawingControl eDrawingCtl;
    }
}