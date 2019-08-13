namespace PSAP.VIEW.BSVIEW
{
    partial class FrmRegisterSchedule
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
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.labActualStartDate = new DevExpress.XtraEditors.LabelControl();
            this.dateActualStartDate = new DevExpress.XtraEditors.DateEdit();
            this.labActualEndDate = new DevExpress.XtraEditors.LabelControl();
            this.dateActualEndDate = new DevExpress.XtraEditors.DateEdit();
            this.labSchedule = new DevExpress.XtraEditors.LabelControl();
            this.labModifierint = new DevExpress.XtraEditors.LabelControl();
            this.spinSchedule = new DevExpress.XtraEditors.SpinEdit();
            this.textModifierint = new DevExpress.XtraEditors.TextEdit();
            this.labProjectUser = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpProjectUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpProjectUserView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColuAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuDepartmentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textPlanTaskText = new DevExpress.XtraEditors.TextEdit();
            this.labPlanTaskText = new DevExpress.XtraEditors.LabelControl();
            this.textPlanTaskStatus = new DevExpress.XtraEditors.TextEdit();
            this.labPlanTaskStatus = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateActualStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateActualStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateActualEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateActualEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSchedule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textModifierint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectUserView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPlanTaskText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPlanTaskStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.BtnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 225);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(604, 36);
            this.pnlBottom.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(515, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(434, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 7;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.textPlanTaskStatus);
            this.pnlMain.Controls.Add(this.labPlanTaskStatus);
            this.pnlMain.Controls.Add(this.labProjectUser);
            this.pnlMain.Controls.Add(this.searchLookUpProjectUser);
            this.pnlMain.Controls.Add(this.textPlanTaskText);
            this.pnlMain.Controls.Add(this.labPlanTaskText);
            this.pnlMain.Controls.Add(this.textModifierint);
            this.pnlMain.Controls.Add(this.spinSchedule);
            this.pnlMain.Controls.Add(this.labModifierint);
            this.pnlMain.Controls.Add(this.labSchedule);
            this.pnlMain.Controls.Add(this.dateActualEndDate);
            this.pnlMain.Controls.Add(this.labActualEndDate);
            this.pnlMain.Controls.Add(this.dateActualStartDate);
            this.pnlMain.Controls.Add(this.labActualStartDate);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(604, 225);
            this.pnlMain.TabIndex = 13;
            // 
            // labActualStartDate
            // 
            this.labActualStartDate.Location = new System.Drawing.Point(40, 76);
            this.labActualStartDate.Name = "labActualStartDate";
            this.labActualStartDate.Size = new System.Drawing.Size(72, 14);
            this.labActualStartDate.TabIndex = 0;
            this.labActualStartDate.Text = "实际开始日期";
            // 
            // dateActualStartDate
            // 
            this.dateActualStartDate.EditValue = null;
            this.dateActualStartDate.Location = new System.Drawing.Point(130, 73);
            this.dateActualStartDate.Name = "dateActualStartDate";
            this.dateActualStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateActualStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateActualStartDate.Size = new System.Drawing.Size(160, 20);
            this.dateActualStartDate.TabIndex = 2;
            // 
            // labActualEndDate
            // 
            this.labActualEndDate.Location = new System.Drawing.Point(311, 76);
            this.labActualEndDate.Name = "labActualEndDate";
            this.labActualEndDate.Size = new System.Drawing.Size(72, 14);
            this.labActualEndDate.TabIndex = 2;
            this.labActualEndDate.Text = "实际结束日期";
            // 
            // dateActualEndDate
            // 
            this.dateActualEndDate.EditValue = null;
            this.dateActualEndDate.Location = new System.Drawing.Point(401, 73);
            this.dateActualEndDate.Name = "dateActualEndDate";
            this.dateActualEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateActualEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateActualEndDate.Size = new System.Drawing.Size(160, 20);
            this.dateActualEndDate.TabIndex = 3;
            // 
            // labSchedule
            // 
            this.labSchedule.Location = new System.Drawing.Point(40, 116);
            this.labSchedule.Name = "labSchedule";
            this.labSchedule.Size = new System.Drawing.Size(48, 14);
            this.labSchedule.TabIndex = 5;
            this.labSchedule.Text = "完成进度";
            // 
            // labModifierint
            // 
            this.labModifierint.Location = new System.Drawing.Point(40, 156);
            this.labModifierint.Name = "labModifierint";
            this.labModifierint.Size = new System.Drawing.Size(36, 14);
            this.labModifierint.TabIndex = 6;
            this.labModifierint.Text = "修改人";
            // 
            // spinSchedule
            // 
            this.spinSchedule.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSchedule.EnterMoveNextControl = true;
            this.spinSchedule.Location = new System.Drawing.Point(130, 113);
            this.spinSchedule.Name = "spinSchedule";
            this.spinSchedule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinSchedule.Properties.DisplayFormat.FormatString = "p";
            this.spinSchedule.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinSchedule.Properties.EditFormat.FormatString = "p";
            this.spinSchedule.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinSchedule.Properties.Mask.EditMask = "p";
            this.spinSchedule.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSchedule.Size = new System.Drawing.Size(160, 20);
            this.spinSchedule.TabIndex = 4;
            // 
            // textModifierint
            // 
            this.textModifierint.Location = new System.Drawing.Point(130, 153);
            this.textModifierint.Name = "textModifierint";
            this.textModifierint.Properties.ReadOnly = true;
            this.textModifierint.Size = new System.Drawing.Size(160, 20);
            this.textModifierint.TabIndex = 6;
            this.textModifierint.TabStop = false;
            // 
            // labProjectUser
            // 
            this.labProjectUser.Location = new System.Drawing.Point(311, 36);
            this.labProjectUser.Name = "labProjectUser";
            this.labProjectUser.Size = new System.Drawing.Size(36, 14);
            this.labProjectUser.TabIndex = 29;
            this.labProjectUser.Text = "实施人";
            // 
            // searchLookUpProjectUser
            // 
            this.searchLookUpProjectUser.EnterMoveNextControl = true;
            this.searchLookUpProjectUser.Location = new System.Drawing.Point(401, 30);
            this.searchLookUpProjectUser.Name = "searchLookUpProjectUser";
            this.searchLookUpProjectUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpProjectUser.Properties.DisplayMember = "EmpName";
            this.searchLookUpProjectUser.Properties.NullText = "";
            this.searchLookUpProjectUser.Properties.ReadOnly = true;
            this.searchLookUpProjectUser.Properties.ValueMember = "AutoId";
            this.searchLookUpProjectUser.Properties.View = this.searchLookUpProjectUserView;
            this.searchLookUpProjectUser.Size = new System.Drawing.Size(160, 20);
            this.searchLookUpProjectUser.TabIndex = 1;
            this.searchLookUpProjectUser.TabStop = false;
            // 
            // searchLookUpProjectUserView
            // 
            this.searchLookUpProjectUserView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColuAutoId,
            this.gridColuEmpName,
            this.gridColuDepartmentNo,
            this.gridColuDepartmentName});
            this.searchLookUpProjectUserView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpProjectUserView.IndicatorWidth = 60;
            this.searchLookUpProjectUserView.Name = "searchLookUpProjectUserView";
            this.searchLookUpProjectUserView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpProjectUserView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColuAutoId
            // 
            this.gridColuAutoId.Caption = "AutoId";
            this.gridColuAutoId.FieldName = "AutoId";
            this.gridColuAutoId.Name = "gridColuAutoId";
            // 
            // gridColuEmpName
            // 
            this.gridColuEmpName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColuEmpName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColuEmpName.Caption = "姓名";
            this.gridColuEmpName.FieldName = "EmpName";
            this.gridColuEmpName.Name = "gridColuEmpName";
            this.gridColuEmpName.Visible = true;
            this.gridColuEmpName.VisibleIndex = 0;
            // 
            // gridColuDepartmentNo
            // 
            this.gridColuDepartmentNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColuDepartmentNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColuDepartmentNo.Caption = "部门编号";
            this.gridColuDepartmentNo.FieldName = "DepartmentNo";
            this.gridColuDepartmentNo.Name = "gridColuDepartmentNo";
            this.gridColuDepartmentNo.Visible = true;
            this.gridColuDepartmentNo.VisibleIndex = 1;
            // 
            // gridColuDepartmentName
            // 
            this.gridColuDepartmentName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColuDepartmentName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColuDepartmentName.Caption = "部门名称";
            this.gridColuDepartmentName.FieldName = "DepartmentName";
            this.gridColuDepartmentName.Name = "gridColuDepartmentName";
            this.gridColuDepartmentName.Visible = true;
            this.gridColuDepartmentName.VisibleIndex = 2;
            // 
            // textPlanTaskText
            // 
            this.textPlanTaskText.EnterMoveNextControl = true;
            this.textPlanTaskText.Location = new System.Drawing.Point(130, 33);
            this.textPlanTaskText.Name = "textPlanTaskText";
            this.textPlanTaskText.Properties.ReadOnly = true;
            this.textPlanTaskText.Size = new System.Drawing.Size(160, 20);
            this.textPlanTaskText.TabIndex = 0;
            this.textPlanTaskText.TabStop = false;
            // 
            // labPlanTaskText
            // 
            this.labPlanTaskText.Location = new System.Drawing.Point(40, 36);
            this.labPlanTaskText.Name = "labPlanTaskText";
            this.labPlanTaskText.Size = new System.Drawing.Size(48, 14);
            this.labPlanTaskText.TabIndex = 28;
            this.labPlanTaskText.Text = "任务名称";
            // 
            // textPlanTaskStatus
            // 
            this.textPlanTaskStatus.EnterMoveNextControl = true;
            this.textPlanTaskStatus.Location = new System.Drawing.Point(401, 113);
            this.textPlanTaskStatus.Name = "textPlanTaskStatus";
            this.textPlanTaskStatus.Properties.ReadOnly = true;
            this.textPlanTaskStatus.Size = new System.Drawing.Size(160, 20);
            this.textPlanTaskStatus.TabIndex = 5;
            this.textPlanTaskStatus.TabStop = false;
            // 
            // labPlanTaskStatus
            // 
            this.labPlanTaskStatus.Location = new System.Drawing.Point(311, 116);
            this.labPlanTaskStatus.Name = "labPlanTaskStatus";
            this.labPlanTaskStatus.Size = new System.Drawing.Size(48, 14);
            this.labPlanTaskStatus.TabIndex = 31;
            this.labPlanTaskStatus.Text = "任务状态";
            // 
            // FrmRegisterSchedule
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(604, 261);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegisterSchedule";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "任务进度登记";
            this.Text = "任务进度登记";
            this.Load += new System.EventHandler(this.FrmRegisterSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateActualStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateActualStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateActualEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateActualEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSchedule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textModifierint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectUserView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPlanTaskText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPlanTaskStatus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl labModifierint;
        private DevExpress.XtraEditors.LabelControl labSchedule;
        private DevExpress.XtraEditors.DateEdit dateActualEndDate;
        private DevExpress.XtraEditors.LabelControl labActualEndDate;
        private DevExpress.XtraEditors.DateEdit dateActualStartDate;
        private DevExpress.XtraEditors.LabelControl labActualStartDate;
        private DevExpress.XtraEditors.TextEdit textModifierint;
        private DevExpress.XtraEditors.SpinEdit spinSchedule;
        private DevExpress.XtraEditors.TextEdit textPlanTaskStatus;
        private DevExpress.XtraEditors.LabelControl labPlanTaskStatus;
        private DevExpress.XtraEditors.LabelControl labProjectUser;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpProjectUser;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpProjectUserView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuDepartmentNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuDepartmentName;
        private DevExpress.XtraEditors.TextEdit textPlanTaskText;
        private DevExpress.XtraEditors.LabelControl labPlanTaskText;
    }
}