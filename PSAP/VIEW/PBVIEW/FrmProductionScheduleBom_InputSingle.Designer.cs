namespace PSAP.VIEW.BSVIEW
{
    partial class FrmProductionScheduleBom_InputSingle
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
            this.pnlDesignBom = new DevExpress.XtraEditors.PanelControl();
            this.textRemainQty = new DevExpress.XtraEditors.TextEdit();
            this.labRemainQty = new DevExpress.XtraEditors.LabelControl();
            this.textOKRemainQty = new DevExpress.XtraEditors.TextEdit();
            this.labOKRemainQty = new DevExpress.XtraEditors.LabelControl();
            this.textMaterielNo = new DevExpress.XtraEditors.TextEdit();
            this.labMaterielNo = new DevExpress.XtraEditors.LabelControl();
            this.textPbBomNo = new DevExpress.XtraEditors.TextEdit();
            this.labPbBomNo = new DevExpress.XtraEditors.LabelControl();
            this.pnlPSBomInfo = new DevExpress.XtraEditors.PanelControl();
            this.labPlanDate = new DevExpress.XtraEditors.LabelControl();
            this.labType = new DevExpress.XtraEditors.LabelControl();
            this.datePlanDate = new DevExpress.XtraEditors.DateEdit();
            this.labelRemainQty = new DevExpress.XtraEditors.LabelControl();
            this.spinRemainQty = new DevExpress.XtraEditors.SpinEdit();
            this.radioType = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesignBom)).BeginInit();
            this.pnlDesignBom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textRemainQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOKRemainQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMaterielNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPbBomNo.Properties)).BeginInit();
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 305);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(544, 36);
            this.pnlBottom.TabIndex = 2;
            this.pnlBottom.TabStop = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(455, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(374, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 13;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // pnlDesignBom
            // 
            this.pnlDesignBom.Controls.Add(this.textRemainQty);
            this.pnlDesignBom.Controls.Add(this.labRemainQty);
            this.pnlDesignBom.Controls.Add(this.textOKRemainQty);
            this.pnlDesignBom.Controls.Add(this.labOKRemainQty);
            this.pnlDesignBom.Controls.Add(this.textMaterielNo);
            this.pnlDesignBom.Controls.Add(this.labMaterielNo);
            this.pnlDesignBom.Controls.Add(this.textPbBomNo);
            this.pnlDesignBom.Controls.Add(this.labPbBomNo);
            this.pnlDesignBom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDesignBom.Location = new System.Drawing.Point(0, 0);
            this.pnlDesignBom.Name = "pnlDesignBom";
            this.pnlDesignBom.Size = new System.Drawing.Size(544, 85);
            this.pnlDesignBom.TabIndex = 0;
            // 
            // textRemainQty
            // 
            this.textRemainQty.Location = new System.Drawing.Point(109, 44);
            this.textRemainQty.Name = "textRemainQty";
            this.textRemainQty.Properties.ReadOnly = true;
            this.textRemainQty.Size = new System.Drawing.Size(150, 20);
            this.textRemainQty.TabIndex = 2;
            this.textRemainQty.TabStop = false;
            // 
            // labRemainQty
            // 
            this.labRemainQty.Location = new System.Drawing.Point(20, 47);
            this.labRemainQty.Name = "labRemainQty";
            this.labRemainQty.Size = new System.Drawing.Size(24, 14);
            this.labRemainQty.TabIndex = 6;
            this.labRemainQty.Text = "数量";
            // 
            // textOKRemainQty
            // 
            this.textOKRemainQty.Location = new System.Drawing.Point(359, 44);
            this.textOKRemainQty.Name = "textOKRemainQty";
            this.textOKRemainQty.Properties.ReadOnly = true;
            this.textOKRemainQty.Size = new System.Drawing.Size(150, 20);
            this.textOKRemainQty.TabIndex = 3;
            this.textOKRemainQty.TabStop = false;
            // 
            // labOKRemainQty
            // 
            this.labOKRemainQty.Location = new System.Drawing.Point(283, 47);
            this.labOKRemainQty.Name = "labOKRemainQty";
            this.labOKRemainQty.Size = new System.Drawing.Size(60, 14);
            this.labOKRemainQty.TabIndex = 4;
            this.labOKRemainQty.Text = "已计划数量";
            // 
            // textMaterielNo
            // 
            this.textMaterielNo.Location = new System.Drawing.Point(359, 14);
            this.textMaterielNo.Name = "textMaterielNo";
            this.textMaterielNo.Properties.ReadOnly = true;
            this.textMaterielNo.Size = new System.Drawing.Size(150, 20);
            this.textMaterielNo.TabIndex = 1;
            this.textMaterielNo.TabStop = false;
            // 
            // labMaterielNo
            // 
            this.labMaterielNo.Location = new System.Drawing.Point(283, 17);
            this.labMaterielNo.Name = "labMaterielNo";
            this.labMaterielNo.Size = new System.Drawing.Size(48, 14);
            this.labMaterielNo.TabIndex = 2;
            this.labMaterielNo.Text = "物料编号";
            // 
            // textPbBomNo
            // 
            this.textPbBomNo.Location = new System.Drawing.Point(109, 14);
            this.textPbBomNo.Name = "textPbBomNo";
            this.textPbBomNo.Properties.ReadOnly = true;
            this.textPbBomNo.Size = new System.Drawing.Size(150, 20);
            this.textPbBomNo.TabIndex = 0;
            this.textPbBomNo.TabStop = false;
            // 
            // labPbBomNo
            // 
            this.labPbBomNo.Location = new System.Drawing.Point(20, 17);
            this.labPbBomNo.Name = "labPbBomNo";
            this.labPbBomNo.Size = new System.Drawing.Size(72, 14);
            this.labPbBomNo.TabIndex = 0;
            this.labPbBomNo.Text = "设计Bom编号";
            // 
            // pnlPSBomInfo
            // 
            this.pnlPSBomInfo.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlPSBomInfo.Appearance.Options.UseBackColor = true;
            this.pnlPSBomInfo.Controls.Add(this.labPlanDate);
            this.pnlPSBomInfo.Controls.Add(this.labType);
            this.pnlPSBomInfo.Controls.Add(this.datePlanDate);
            this.pnlPSBomInfo.Controls.Add(this.labelRemainQty);
            this.pnlPSBomInfo.Controls.Add(this.spinRemainQty);
            this.pnlPSBomInfo.Controls.Add(this.radioType);
            this.pnlPSBomInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPSBomInfo.Location = new System.Drawing.Point(0, 85);
            this.pnlPSBomInfo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlPSBomInfo.LookAndFeel.UseWindowsXPTheme = true;
            this.pnlPSBomInfo.Name = "pnlPSBomInfo";
            this.pnlPSBomInfo.Size = new System.Drawing.Size(544, 220);
            this.pnlPSBomInfo.TabIndex = 1;
            this.pnlPSBomInfo.TabStop = true;
            // 
            // labPlanDate
            // 
            this.labPlanDate.Location = new System.Drawing.Point(76, 144);
            this.labPlanDate.Name = "labPlanDate";
            this.labPlanDate.Size = new System.Drawing.Size(48, 14);
            this.labPlanDate.TabIndex = 8;
            this.labPlanDate.Text = "计划日期";
            // 
            // labType
            // 
            this.labType.Location = new System.Drawing.Point(76, 38);
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(48, 14);
            this.labType.TabIndex = 7;
            this.labType.Text = "采购方式";
            // 
            // datePlanDate
            // 
            this.datePlanDate.EditValue = null;
            this.datePlanDate.EnterMoveNextControl = true;
            this.datePlanDate.Location = new System.Drawing.Point(148, 141);
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
            // labelRemainQty
            // 
            this.labelRemainQty.Location = new System.Drawing.Point(76, 94);
            this.labelRemainQty.Name = "labelRemainQty";
            this.labelRemainQty.Size = new System.Drawing.Size(48, 14);
            this.labelRemainQty.TabIndex = 5;
            this.labelRemainQty.Text = "计划数量";
            // 
            // spinRemainQty
            // 
            this.spinRemainQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinRemainQty.EnterMoveNextControl = true;
            this.spinRemainQty.Location = new System.Drawing.Point(148, 91);
            this.spinRemainQty.Name = "spinRemainQty";
            this.spinRemainQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinRemainQty.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.spinRemainQty.Size = new System.Drawing.Size(150, 20);
            this.spinRemainQty.TabIndex = 11;
            // 
            // radioType
            // 
            this.radioType.EditValue = ((short)(1));
            this.radioType.EnterMoveNextControl = true;
            this.radioType.Location = new System.Drawing.Point(165, 31);
            this.radioType.Name = "radioType";
            this.radioType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioType.Properties.Appearance.Options.UseBackColor = true;
            this.radioType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "统一采购"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "分批采购")});
            this.radioType.Size = new System.Drawing.Size(252, 29);
            this.radioType.TabIndex = 10;
            this.radioType.SelectedIndexChanged += new System.EventHandler(this.radioType_SelectedIndexChanged);
            // 
            // FrmProductionScheduleBom_InputSingle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(544, 341);
            this.Controls.Add(this.pnlPSBomInfo);
            this.Controls.Add(this.pnlDesignBom);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductionScheduleBom_InputSingle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "输入生产计划信息";
            this.Text = "输入生产计划信息";
            this.Load += new System.EventHandler(this.FrmProductionScheduleBom_InputSingle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesignBom)).EndInit();
            this.pnlDesignBom.ResumeLayout(false);
            this.pnlDesignBom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textRemainQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOKRemainQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMaterielNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPbBomNo.Properties)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl pnlDesignBom;
        private DevExpress.XtraEditors.PanelControl pnlPSBomInfo;
        private DevExpress.XtraEditors.TextEdit textPbBomNo;
        private DevExpress.XtraEditors.LabelControl labPbBomNo;
        private DevExpress.XtraEditors.TextEdit textRemainQty;
        private DevExpress.XtraEditors.LabelControl labRemainQty;
        private DevExpress.XtraEditors.TextEdit textOKRemainQty;
        private DevExpress.XtraEditors.LabelControl labOKRemainQty;
        private DevExpress.XtraEditors.TextEdit textMaterielNo;
        private DevExpress.XtraEditors.LabelControl labMaterielNo;
        private DevExpress.XtraEditors.RadioGroup radioType;
        private DevExpress.XtraEditors.LabelControl labelRemainQty;
        private DevExpress.XtraEditors.SpinEdit spinRemainQty;
        private DevExpress.XtraEditors.LabelControl labPlanDate;
        private DevExpress.XtraEditors.LabelControl labType;
        private DevExpress.XtraEditors.DateEdit datePlanDate;
    }
}