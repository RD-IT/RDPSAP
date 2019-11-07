namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWorkFlowsDataHandle
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
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.lookUpPrepared = new DevExpress.XtraEditors.LookUpEdit();
            this.memoApproverOption = new DevExpress.XtraEditors.MemoEdit();
            this.radioApproverResult = new DevExpress.XtraEditors.RadioGroup();
            this.labApproverResult = new DevExpress.XtraEditors.LabelControl();
            this.labApproverOption = new DevExpress.XtraEditors.LabelControl();
            this.labApprover = new DevExpress.XtraEditors.LabelControl();
            this.textDataNo = new DevExpress.XtraEditors.TextEdit();
            this.labDataNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpPrepared.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoApproverOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioApproverResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDataNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.BtnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 285);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(624, 36);
            this.pnlBottom.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(535, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(454, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 6;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.lookUpPrepared);
            this.pnlEdit.Controls.Add(this.memoApproverOption);
            this.pnlEdit.Controls.Add(this.radioApproverResult);
            this.pnlEdit.Controls.Add(this.labApproverResult);
            this.pnlEdit.Controls.Add(this.labApproverOption);
            this.pnlEdit.Controls.Add(this.labApprover);
            this.pnlEdit.Controls.Add(this.textDataNo);
            this.pnlEdit.Controls.Add(this.labDataNo);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEdit.Location = new System.Drawing.Point(0, 0);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(624, 285);
            this.pnlEdit.TabIndex = 0;
            // 
            // lookUpPrepared
            // 
            this.lookUpPrepared.EnterMoveNextControl = true;
            this.lookUpPrepared.Location = new System.Drawing.Point(112, 55);
            this.lookUpPrepared.Name = "lookUpPrepared";
            this.lookUpPrepared.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpPrepared.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 80, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoginId", "用户名", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "员工名", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpPrepared.Properties.DisplayMember = "EmpName";
            this.lookUpPrepared.Properties.NullText = "";
            this.lookUpPrepared.Properties.ReadOnly = true;
            this.lookUpPrepared.Properties.ValueMember = "AutoId";
            this.lookUpPrepared.Size = new System.Drawing.Size(150, 20);
            this.lookUpPrepared.TabIndex = 10;
            // 
            // memoApproverOption
            // 
            this.memoApproverOption.EnterMoveNextControl = true;
            this.memoApproverOption.Location = new System.Drawing.Point(112, 90);
            this.memoApproverOption.Name = "memoApproverOption";
            this.memoApproverOption.Size = new System.Drawing.Size(450, 120);
            this.memoApproverOption.TabIndex = 4;
            // 
            // radioApproverResult
            // 
            this.radioApproverResult.EnterMoveNextControl = true;
            this.radioApproverResult.Location = new System.Drawing.Point(132, 224);
            this.radioApproverResult.Name = "radioApproverResult";
            this.radioApproverResult.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioApproverResult.Properties.Appearance.Options.UseBackColor = true;
            this.radioApproverResult.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioApproverResult.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "同意"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "不同意")});
            this.radioApproverResult.Size = new System.Drawing.Size(195, 29);
            this.radioApproverResult.TabIndex = 5;
            // 
            // labApproverResult
            // 
            this.labApproverResult.Location = new System.Drawing.Point(36, 231);
            this.labApproverResult.Name = "labApproverResult";
            this.labApproverResult.Size = new System.Drawing.Size(48, 14);
            this.labApproverResult.TabIndex = 5;
            this.labApproverResult.Text = "审批结果";
            // 
            // labApproverOption
            // 
            this.labApproverOption.Location = new System.Drawing.Point(36, 92);
            this.labApproverOption.Name = "labApproverOption";
            this.labApproverOption.Size = new System.Drawing.Size(48, 14);
            this.labApproverOption.TabIndex = 3;
            this.labApproverOption.Text = "审批意见";
            // 
            // labApprover
            // 
            this.labApprover.Location = new System.Drawing.Point(36, 58);
            this.labApprover.Name = "labApprover";
            this.labApprover.Size = new System.Drawing.Size(36, 14);
            this.labApprover.TabIndex = 2;
            this.labApprover.Text = "审批人";
            // 
            // textDataNo
            // 
            this.textDataNo.EnterMoveNextControl = true;
            this.textDataNo.Location = new System.Drawing.Point(112, 21);
            this.textDataNo.Name = "textDataNo";
            this.textDataNo.Properties.ReadOnly = true;
            this.textDataNo.Size = new System.Drawing.Size(450, 20);
            this.textDataNo.TabIndex = 0;
            this.textDataNo.TabStop = false;
            // 
            // labDataNo
            // 
            this.labDataNo.Location = new System.Drawing.Point(36, 24);
            this.labDataNo.Name = "labDataNo";
            this.labDataNo.Size = new System.Drawing.Size(36, 14);
            this.labDataNo.TabIndex = 0;
            this.labDataNo.Text = "单据号";
            // 
            // FrmWorkFlowDataHandle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkFlowDataHandle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "流程单据处理";
            this.Text = "流程单据处理";
            this.Load += new System.EventHandler(this.FrmWorkFlowDataHandle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpPrepared.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoApproverOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioApproverResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDataNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.LabelControl labApproverOption;
        private DevExpress.XtraEditors.LabelControl labApprover;
        private DevExpress.XtraEditors.TextEdit textDataNo;
        private DevExpress.XtraEditors.LabelControl labDataNo;
        private DevExpress.XtraEditors.LabelControl labApproverResult;
        public DevExpress.XtraEditors.MemoEdit memoApproverOption;
        public DevExpress.XtraEditors.RadioGroup radioApproverResult;
        private DevExpress.XtraEditors.LookUpEdit lookUpPrepared;
    }
}