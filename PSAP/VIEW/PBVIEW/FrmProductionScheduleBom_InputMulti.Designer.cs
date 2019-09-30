namespace PSAP.VIEW.BSVIEW
{
    partial class FrmProductionScheduleBom_InputMulti
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
            this.pnlPSBomInfo = new DevExpress.XtraEditors.PanelControl();
            this.labDesc = new DevExpress.XtraEditors.LabelControl();
            this.labPlanDate = new DevExpress.XtraEditors.LabelControl();
            this.labType = new DevExpress.XtraEditors.LabelControl();
            this.datePlanDate = new DevExpress.XtraEditors.DateEdit();
            this.labRemainQty = new DevExpress.XtraEditors.LabelControl();
            this.spinRemainQty = new DevExpress.XtraEditors.SpinEdit();
            this.radioType = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPSBomInfo)).BeginInit();
            this.pnlPSBomInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinRemainQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.BtnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 205);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(384, 36);
            this.pnlBottom.TabIndex = 3;
            this.pnlBottom.TabStop = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(295, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(214, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 13;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // pnlPSBomInfo
            // 
            this.pnlPSBomInfo.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlPSBomInfo.Appearance.Options.UseBackColor = true;
            this.pnlPSBomInfo.Controls.Add(this.labDesc);
            this.pnlPSBomInfo.Controls.Add(this.labPlanDate);
            this.pnlPSBomInfo.Controls.Add(this.labType);
            this.pnlPSBomInfo.Controls.Add(this.datePlanDate);
            this.pnlPSBomInfo.Controls.Add(this.labRemainQty);
            this.pnlPSBomInfo.Controls.Add(this.spinRemainQty);
            this.pnlPSBomInfo.Controls.Add(this.radioType);
            this.pnlPSBomInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPSBomInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlPSBomInfo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlPSBomInfo.LookAndFeel.UseWindowsXPTheme = true;
            this.pnlPSBomInfo.Name = "pnlPSBomInfo";
            this.pnlPSBomInfo.Size = new System.Drawing.Size(384, 205);
            this.pnlPSBomInfo.TabIndex = 4;
            this.pnlPSBomInfo.TabStop = true;
            // 
            // labDesc
            // 
            this.labDesc.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labDesc.Location = new System.Drawing.Point(52, 158);
            this.labDesc.Name = "labDesc";
            this.labDesc.Size = new System.Drawing.Size(274, 14);
            this.labDesc.TabIndex = 13;
            this.labDesc.Tag = "(注：1 全部计划方式下，数量默认为设计Bom的数量";
            this.labDesc.Text = "(注：全部计划方式下，数量默认为设计Bom的数量)";
            // 
            // labPlanDate
            // 
            this.labPlanDate.Location = new System.Drawing.Point(52, 124);
            this.labPlanDate.Name = "labPlanDate";
            this.labPlanDate.Size = new System.Drawing.Size(48, 14);
            this.labPlanDate.TabIndex = 8;
            this.labPlanDate.Text = "计划日期";
            // 
            // labType
            // 
            this.labType.Location = new System.Drawing.Point(52, 38);
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(48, 14);
            this.labType.TabIndex = 7;
            this.labType.Text = "计划方式";
            // 
            // datePlanDate
            // 
            this.datePlanDate.EditValue = null;
            this.datePlanDate.EnterMoveNextControl = true;
            this.datePlanDate.Location = new System.Drawing.Point(124, 121);
            this.datePlanDate.Name = "datePlanDate";
            this.datePlanDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePlanDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePlanDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.datePlanDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePlanDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.datePlanDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePlanDate.Size = new System.Drawing.Size(150, 20);
            this.datePlanDate.TabIndex = 12;
            // 
            // labRemainQty
            // 
            this.labRemainQty.Location = new System.Drawing.Point(52, 81);
            this.labRemainQty.Name = "labRemainQty";
            this.labRemainQty.Size = new System.Drawing.Size(48, 14);
            this.labRemainQty.TabIndex = 5;
            this.labRemainQty.Text = "计划数量";
            // 
            // spinRemainQty
            // 
            this.spinRemainQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinRemainQty.EnterMoveNextControl = true;
            this.spinRemainQty.Location = new System.Drawing.Point(124, 78);
            this.spinRemainQty.Name = "spinRemainQty";
            this.spinRemainQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinRemainQty.Size = new System.Drawing.Size(150, 20);
            this.spinRemainQty.TabIndex = 11;
            // 
            // radioType
            // 
            this.radioType.EditValue = ((short)(1));
            this.radioType.EnterMoveNextControl = true;
            this.radioType.Location = new System.Drawing.Point(141, 31);
            this.radioType.Name = "radioType";
            this.radioType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioType.Properties.Appearance.Options.UseBackColor = true;
            this.radioType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "部分")});
            this.radioType.Size = new System.Drawing.Size(165, 29);
            this.radioType.TabIndex = 10;
            this.radioType.SelectedIndexChanged += new System.EventHandler(this.radioType_SelectedIndexChanged);
            // 
            // FrmProductionScheduleBom_InputMulti
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.pnlPSBomInfo);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductionScheduleBom_InputMulti";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "输入生产计划信息";
            this.Text = "输入生产计划信息";
            this.Load += new System.EventHandler(this.FrmProductionScheduleBom_InputMulti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPSBomInfo)).EndInit();
            this.pnlPSBomInfo.ResumeLayout(false);
            this.pnlPSBomInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinRemainQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
        private DevExpress.XtraEditors.PanelControl pnlPSBomInfo;
        private DevExpress.XtraEditors.LabelControl labPlanDate;
        private DevExpress.XtraEditors.LabelControl labType;
        private DevExpress.XtraEditors.LabelControl labRemainQty;
        public DevExpress.XtraEditors.DateEdit datePlanDate;
        public DevExpress.XtraEditors.SpinEdit spinRemainQty;
        public DevExpress.XtraEditors.RadioGroup radioType;
        private DevExpress.XtraEditors.LabelControl labDesc;
    }
}