namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWorkFlowsNodeSet
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
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.radioBeginNode = new DevExpress.XtraEditors.RadioGroup();
            this.labBeginNode = new DevExpress.XtraEditors.LabelControl();
            this.labEnabled = new DevExpress.XtraEditors.LabelControl();
            this.checkEnabled = new DevExpress.XtraEditors.CheckEdit();
            this.textNodeText = new DevExpress.XtraEditors.TextEdit();
            this.labNodeText = new DevExpress.XtraEditors.LabelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfirm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioBeginNode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEnabled.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNodeText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.radioBeginNode);
            this.pnlMain.Controls.Add(this.labBeginNode);
            this.pnlMain.Controls.Add(this.labEnabled);
            this.pnlMain.Controls.Add(this.checkEnabled);
            this.pnlMain.Controls.Add(this.textNodeText);
            this.pnlMain.Controls.Add(this.labNodeText);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(484, 275);
            this.pnlMain.TabIndex = 0;
            // 
            // radioBeginNode
            // 
            this.radioBeginNode.EnterMoveNextControl = true;
            this.radioBeginNode.Location = new System.Drawing.Point(122, 73);
            this.radioBeginNode.Name = "radioBeginNode";
            this.radioBeginNode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioBeginNode.Properties.Appearance.Options.UseBackColor = true;
            this.radioBeginNode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioBeginNode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "开始节点"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "中间节点"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "结束节点")});
            this.radioBeginNode.Size = new System.Drawing.Size(296, 27);
            this.radioBeginNode.TabIndex = 1;
            this.radioBeginNode.SelectedIndexChanged += new System.EventHandler(this.radioBeginNode_SelectedIndexChanged);
            // 
            // labBeginNode
            // 
            this.labBeginNode.Location = new System.Drawing.Point(45, 79);
            this.labBeginNode.Name = "labBeginNode";
            this.labBeginNode.Size = new System.Drawing.Size(48, 14);
            this.labBeginNode.TabIndex = 21;
            this.labBeginNode.Text = "节点位置";
            // 
            // labEnabled
            // 
            this.labEnabled.Location = new System.Drawing.Point(45, 117);
            this.labEnabled.Name = "labEnabled";
            this.labEnabled.Size = new System.Drawing.Size(24, 14);
            this.labEnabled.TabIndex = 20;
            this.labEnabled.Text = "启用";
            // 
            // checkEnabled
            // 
            this.checkEnabled.EnterMoveNextControl = true;
            this.checkEnabled.Location = new System.Drawing.Point(158, 114);
            this.checkEnabled.Name = "checkEnabled";
            this.checkEnabled.Properties.Caption = "";
            this.checkEnabled.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkEnabled.Properties.ValueChecked = 1;
            this.checkEnabled.Properties.ValueGrayed = 0;
            this.checkEnabled.Properties.ValueUnchecked = 0;
            this.checkEnabled.Size = new System.Drawing.Size(23, 19);
            this.checkEnabled.TabIndex = 2;
            // 
            // textNodeText
            // 
            this.textNodeText.EnterMoveNextControl = true;
            this.textNodeText.Location = new System.Drawing.Point(122, 38);
            this.textNodeText.Name = "textNodeText";
            this.textNodeText.Size = new System.Drawing.Size(180, 20);
            this.textNodeText.TabIndex = 0;
            // 
            // labNodeText
            // 
            this.labNodeText.Location = new System.Drawing.Point(45, 41);
            this.labNodeText.Name = "labNodeText";
            this.labNodeText.Size = new System.Drawing.Size(48, 14);
            this.labNodeText.TabIndex = 0;
            this.labNodeText.Text = "节点名称";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.BtnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 275);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(484, 36);
            this.pnlBottom.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(395, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(314, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 0;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // FrmWorkFlowsNodeSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkFlowsNodeSet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "流程图中的节点设定";
            this.Text = "流程图中的节点设定";
            this.Load += new System.EventHandler(this.FrmWorkFlowsNodeSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioBeginNode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEnabled.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNodeText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
        private DevExpress.XtraEditors.LabelControl labNodeText;
        private DevExpress.XtraEditors.LabelControl labEnabled;
        private DevExpress.XtraEditors.CheckEdit checkEnabled;
        public DevExpress.XtraEditors.TextEdit textNodeText;
        private DevExpress.XtraEditors.LabelControl labBeginNode;
        public DevExpress.XtraEditors.RadioGroup radioBeginNode;
    }
}