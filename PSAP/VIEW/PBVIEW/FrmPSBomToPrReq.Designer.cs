namespace PSAP.VIEW.BSVIEW
{
    partial class FrmPSBomToPrReq
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
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridControlPSBom = new DevExpress.XtraGrid.GridControl();
            this.gridViewPSBom = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColMaterielNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPlanDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemainQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textPbBomNo = new DevExpress.XtraEditors.TextEdit();
            this.labProjectNo = new DevExpress.XtraEditors.LabelControl();
            this.labPbBomNo = new DevExpress.XtraEditors.LabelControl();
            this.labStnNo = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditApprovalType = new DevExpress.XtraEditors.LookUpEdit();
            this.labPurCategory = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpStnNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpStnNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColStnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStnText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labApprovalType = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpProjectNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpProjectNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpPurCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpReqDep = new DevExpress.XtraEditors.LookUpEdit();
            this.labReqDep = new DevExpress.XtraEditors.LabelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfirm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPSBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPSBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPbBomNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditApprovalType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpStnNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpStnNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpPurCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEdit
            // 
            this.pnlEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlEdit.Controls.Add(this.pnlGrid);
            this.pnlEdit.Controls.Add(this.panelControl1);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEdit.Location = new System.Drawing.Point(0, 0);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(777, 499);
            this.pnlEdit.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridControlPSBom);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 140);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(777, 359);
            this.pnlGrid.TabIndex = 3;
            // 
            // gridControlPSBom
            // 
            this.gridControlPSBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPSBom.Location = new System.Drawing.Point(2, 2);
            this.gridControlPSBom.MainView = this.gridViewPSBom;
            this.gridControlPSBom.Name = "gridControlPSBom";
            this.gridControlPSBom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlPSBom.Size = new System.Drawing.Size(773, 355);
            this.gridControlPSBom.TabIndex = 20;
            this.gridControlPSBom.TabStop = false;
            this.gridControlPSBom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPSBom});
            // 
            // gridViewPSBom
            // 
            this.gridViewPSBom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColAutoId,
            this.gridColMaterielNo,
            this.gridColCodeName,
            this.gridColPlanDate,
            this.gridColRemainQty});
            this.gridViewPSBom.GridControl = this.gridControlPSBom;
            this.gridViewPSBom.IndicatorWidth = 40;
            this.gridViewPSBom.Name = "gridViewPSBom";
            this.gridViewPSBom.OptionsBehavior.Editable = false;
            this.gridViewPSBom.OptionsBehavior.ReadOnly = true;
            this.gridViewPSBom.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPSBom.OptionsView.ColumnAutoWidth = false;
            this.gridViewPSBom.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewPSBom.OptionsView.ShowFooter = true;
            this.gridViewPSBom.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewPSBom_CustomDrawRowIndicator);
            this.gridViewPSBom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewPSBom_KeyDown);
            // 
            // gridColAutoId
            // 
            this.gridColAutoId.Caption = "AutoId";
            this.gridColAutoId.FieldName = "AutoId";
            this.gridColAutoId.Name = "gridColAutoId";
            // 
            // gridColMaterielNo
            // 
            this.gridColMaterielNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColMaterielNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColMaterielNo.Caption = "零件编号";
            this.gridColMaterielNo.FieldName = "MaterielNo";
            this.gridColMaterielNo.Name = "gridColMaterielNo";
            this.gridColMaterielNo.Visible = true;
            this.gridColMaterielNo.VisibleIndex = 0;
            this.gridColMaterielNo.Width = 130;
            // 
            // gridColCodeName
            // 
            this.gridColCodeName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColCodeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColCodeName.Caption = "零件名称";
            this.gridColCodeName.FieldName = "CodeName";
            this.gridColCodeName.Name = "gridColCodeName";
            this.gridColCodeName.Visible = true;
            this.gridColCodeName.VisibleIndex = 1;
            this.gridColCodeName.Width = 130;
            // 
            // gridColPlanDate
            // 
            this.gridColPlanDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColPlanDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColPlanDate.Caption = "计划日期";
            this.gridColPlanDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gridColPlanDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColPlanDate.FieldName = "PlanDate";
            this.gridColPlanDate.Name = "gridColPlanDate";
            this.gridColPlanDate.Visible = true;
            this.gridColPlanDate.VisibleIndex = 2;
            this.gridColPlanDate.Width = 110;
            // 
            // gridColRemainQty
            // 
            this.gridColRemainQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColRemainQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColRemainQty.Caption = "数量";
            this.gridColRemainQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColRemainQty.FieldName = "RemainQty";
            this.gridColRemainQty.Name = "gridColRemainQty";
            this.gridColRemainQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RemainQty", "{0}")});
            this.gridColRemainQty.Visible = true;
            this.gridColRemainQty.VisibleIndex = 3;
            this.gridColRemainQty.Width = 100;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEdit1.ValueChecked = ((short)(1));
            this.repositoryItemCheckEdit1.ValueGrayed = ((short)(0));
            this.repositoryItemCheckEdit1.ValueUnchecked = ((short)(0));
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textPbBomNo);
            this.panelControl1.Controls.Add(this.labProjectNo);
            this.panelControl1.Controls.Add(this.labPbBomNo);
            this.panelControl1.Controls.Add(this.labStnNo);
            this.panelControl1.Controls.Add(this.lookUpEditApprovalType);
            this.panelControl1.Controls.Add(this.labPurCategory);
            this.panelControl1.Controls.Add(this.searchLookUpStnNo);
            this.panelControl1.Controls.Add(this.labApprovalType);
            this.panelControl1.Controls.Add(this.searchLookUpProjectNo);
            this.panelControl1.Controls.Add(this.lookUpPurCategory);
            this.panelControl1.Controls.Add(this.lookUpReqDep);
            this.panelControl1.Controls.Add(this.labReqDep);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(777, 140);
            this.panelControl1.TabIndex = 1;
            // 
            // textPbBomNo
            // 
            this.textPbBomNo.EnterMoveNextControl = true;
            this.textPbBomNo.Location = new System.Drawing.Point(127, 23);
            this.textPbBomNo.Name = "textPbBomNo";
            this.textPbBomNo.Properties.ReadOnly = true;
            this.textPbBomNo.Size = new System.Drawing.Size(180, 20);
            this.textPbBomNo.TabIndex = 0;
            // 
            // labProjectNo
            // 
            this.labProjectNo.Location = new System.Drawing.Point(41, 62);
            this.labProjectNo.Name = "labProjectNo";
            this.labProjectNo.Size = new System.Drawing.Size(36, 14);
            this.labProjectNo.TabIndex = 0;
            this.labProjectNo.Text = "项目号";
            // 
            // labPbBomNo
            // 
            this.labPbBomNo.Location = new System.Drawing.Point(40, 26);
            this.labPbBomNo.Name = "labPbBomNo";
            this.labPbBomNo.Size = new System.Drawing.Size(72, 14);
            this.labPbBomNo.TabIndex = 14;
            this.labPbBomNo.Text = "设计Bom单号";
            // 
            // labStnNo
            // 
            this.labStnNo.Location = new System.Drawing.Point(356, 62);
            this.labStnNo.Name = "labStnNo";
            this.labStnNo.Size = new System.Drawing.Size(24, 14);
            this.labStnNo.TabIndex = 1;
            this.labStnNo.Text = "站号";
            // 
            // lookUpEditApprovalType
            // 
            this.lookUpEditApprovalType.EnterMoveNextControl = true;
            this.lookUpEditApprovalType.Location = new System.Drawing.Point(442, 95);
            this.lookUpEditApprovalType.Name = "lookUpEditApprovalType";
            this.lookUpEditApprovalType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditApprovalType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeNo", "审批类型"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeNoText", "审批名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ApprovalText", "审批方式")});
            this.lookUpEditApprovalType.Properties.DisplayMember = "TypeNoText";
            this.lookUpEditApprovalType.Properties.NullText = "";
            this.lookUpEditApprovalType.Properties.ValueMember = "TypeNo";
            this.lookUpEditApprovalType.Size = new System.Drawing.Size(180, 20);
            this.lookUpEditApprovalType.TabIndex = 5;
            // 
            // labPurCategory
            // 
            this.labPurCategory.Location = new System.Drawing.Point(41, 98);
            this.labPurCategory.Name = "labPurCategory";
            this.labPurCategory.Size = new System.Drawing.Size(48, 14);
            this.labPurCategory.TabIndex = 2;
            this.labPurCategory.Text = "采购类型";
            // 
            // searchLookUpStnNo
            // 
            this.searchLookUpStnNo.EnterMoveNextControl = true;
            this.searchLookUpStnNo.Location = new System.Drawing.Point(442, 59);
            this.searchLookUpStnNo.Name = "searchLookUpStnNo";
            this.searchLookUpStnNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpStnNo.Properties.DisplayMember = "StnNo";
            this.searchLookUpStnNo.Properties.NullText = "";
            this.searchLookUpStnNo.Properties.ValueMember = "StnNo";
            this.searchLookUpStnNo.Properties.View = this.searchLookUpStnNoView;
            this.searchLookUpStnNo.Size = new System.Drawing.Size(180, 20);
            this.searchLookUpStnNo.TabIndex = 3;
            // 
            // searchLookUpStnNoView
            // 
            this.searchLookUpStnNoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColStnNo,
            this.gridColStnText});
            this.searchLookUpStnNoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpStnNoView.IndicatorWidth = 60;
            this.searchLookUpStnNoView.Name = "searchLookUpStnNoView";
            this.searchLookUpStnNoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpStnNoView.OptionsView.ShowGroupPanel = false;
            this.searchLookUpStnNoView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewPSBom_CustomDrawRowIndicator);
            // 
            // gridColStnNo
            // 
            this.gridColStnNo.Caption = "站号";
            this.gridColStnNo.FieldName = "StnNo";
            this.gridColStnNo.Name = "gridColStnNo";
            this.gridColStnNo.Visible = true;
            this.gridColStnNo.VisibleIndex = 0;
            // 
            // gridColStnText
            // 
            this.gridColStnText.Caption = "站号名称";
            this.gridColStnText.FieldName = "StnText";
            this.gridColStnText.Name = "gridColStnText";
            this.gridColStnText.Visible = true;
            this.gridColStnText.VisibleIndex = 1;
            // 
            // labApprovalType
            // 
            this.labApprovalType.Location = new System.Drawing.Point(356, 98);
            this.labApprovalType.Name = "labApprovalType";
            this.labApprovalType.Size = new System.Drawing.Size(48, 14);
            this.labApprovalType.TabIndex = 3;
            this.labApprovalType.Text = "审批类型";
            // 
            // searchLookUpProjectNo
            // 
            this.searchLookUpProjectNo.EnterMoveNextControl = true;
            this.searchLookUpProjectNo.Location = new System.Drawing.Point(127, 59);
            this.searchLookUpProjectNo.Name = "searchLookUpProjectNo";
            this.searchLookUpProjectNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpProjectNo.Properties.DisplayMember = "ProjectName";
            this.searchLookUpProjectNo.Properties.NullText = "";
            this.searchLookUpProjectNo.Properties.ReadOnly = true;
            this.searchLookUpProjectNo.Properties.ValueMember = "ProjectNo";
            this.searchLookUpProjectNo.Properties.View = this.searchLookUpProjectNoView;
            this.searchLookUpProjectNo.Size = new System.Drawing.Size(180, 20);
            this.searchLookUpProjectNo.TabIndex = 2;
            // 
            // searchLookUpProjectNoView
            // 
            this.searchLookUpProjectNoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColProjectNo,
            this.gridColProjectName,
            this.gridColRemark});
            this.searchLookUpProjectNoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpProjectNoView.IndicatorWidth = 60;
            this.searchLookUpProjectNoView.Name = "searchLookUpProjectNoView";
            this.searchLookUpProjectNoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpProjectNoView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColProjectNo
            // 
            this.gridColProjectNo.Caption = "项目号";
            this.gridColProjectNo.FieldName = "ProjectNo";
            this.gridColProjectNo.Name = "gridColProjectNo";
            this.gridColProjectNo.Visible = true;
            this.gridColProjectNo.VisibleIndex = 0;
            // 
            // gridColProjectName
            // 
            this.gridColProjectName.Caption = "项目名称";
            this.gridColProjectName.FieldName = "ProjectName";
            this.gridColProjectName.Name = "gridColProjectName";
            this.gridColProjectName.Visible = true;
            this.gridColProjectName.VisibleIndex = 1;
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "备注";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 2;
            // 
            // lookUpPurCategory
            // 
            this.lookUpPurCategory.EnterMoveNextControl = true;
            this.lookUpPurCategory.Location = new System.Drawing.Point(126, 95);
            this.lookUpPurCategory.Name = "lookUpPurCategory";
            this.lookUpPurCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpPurCategory.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurCategory", "编号", 81, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurCategoryText", "名称", 111, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpPurCategory.Properties.DisplayMember = "PurCategoryText";
            this.lookUpPurCategory.Properties.NullText = "";
            this.lookUpPurCategory.Properties.ValueMember = "PurCategory";
            this.lookUpPurCategory.Size = new System.Drawing.Size(180, 20);
            this.lookUpPurCategory.TabIndex = 4;
            // 
            // lookUpReqDep
            // 
            this.lookUpReqDep.EnterMoveNextControl = true;
            this.lookUpReqDep.Location = new System.Drawing.Point(442, 23);
            this.lookUpReqDep.Name = "lookUpReqDep";
            this.lookUpReqDep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpReqDep.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentNo", "部门编号", 95, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "部门名称", 111, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpReqDep.Properties.DisplayMember = "DepartmentName";
            this.lookUpReqDep.Properties.NullText = "";
            this.lookUpReqDep.Properties.ValueMember = "DepartmentNo";
            this.lookUpReqDep.Size = new System.Drawing.Size(180, 20);
            this.lookUpReqDep.TabIndex = 1;
            // 
            // labReqDep
            // 
            this.labReqDep.Location = new System.Drawing.Point(356, 25);
            this.labReqDep.Name = "labReqDep";
            this.labReqDep.Size = new System.Drawing.Size(48, 14);
            this.labReqDep.TabIndex = 6;
            this.labReqDep.Text = "申请部门";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.BtnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 499);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(777, 36);
            this.pnlBottom.TabIndex = 3;
            this.pnlBottom.TabStop = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(688, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(607, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 10;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // FrmPSBomToPrReq
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(777, 535);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPSBomToPrReq";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "生产计划生成请购单";
            this.Text = "生产计划生成请购单";
            this.Load += new System.EventHandler(this.FrmPSBomToPrReq_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPSBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPSBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPbBomNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditApprovalType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpStnNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpStnNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpPurCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
        private DevExpress.XtraEditors.LabelControl labApprovalType;
        private DevExpress.XtraEditors.LabelControl labPurCategory;
        private DevExpress.XtraEditors.LabelControl labStnNo;
        private DevExpress.XtraEditors.LabelControl labProjectNo;
        private DevExpress.XtraEditors.LookUpEdit lookUpPurCategory;
        private DevExpress.XtraEditors.LabelControl labReqDep;
        private DevExpress.XtraEditors.LookUpEdit lookUpReqDep;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpProjectNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpProjectNoView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProjectNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpStnNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpStnNoView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStnNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStnText;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditApprovalType;
        private DevExpress.XtraEditors.TextEdit textPbBomNo;
        private DevExpress.XtraEditors.LabelControl labPbBomNo;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlPSBom;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPSBom;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColMaterielNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPlanDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemainQty;
    }
}