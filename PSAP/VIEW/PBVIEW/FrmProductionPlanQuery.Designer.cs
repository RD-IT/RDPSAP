namespace PSAP.VIEW.BSVIEW
{
    partial class FrmProductionPlanQuery
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
            this.components = new System.ComponentModel.Container();
            this.dataSet_ProductionPlan = new System.Data.DataSet();
            this.dataTableProductionPlan = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColPlanNo = new System.Data.DataColumn();
            this.dataColCodeId = new System.Data.DataColumn();
            this.dataColQty = new System.Data.DataColumn();
            this.dataColProjectNo = new System.Data.DataColumn();
            this.dataColManufactureNo = new System.Data.DataColumn();
            this.dataColCurrentdatetime = new System.Data.DataColumn();
            this.dataColLine = new System.Data.DataColumn();
            this.dataColStartTime = new System.Data.DataColumn();
            this.dataColEndTime = new System.Data.DataColumn();
            this.dataColPlanStatus = new System.Data.DataColumn();
            this.dataColCurrentStatus = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColCreatorIp = new System.Data.DataColumn();
            this.dataColModifier = new System.Data.DataColumn();
            this.dataColModifierIp = new System.Data.DataColumn();
            this.dataColModifierTime = new System.Data.DataColumn();
            this.dataColRemark = new System.Data.DataColumn();
            this.dataColDesignBomListId = new System.Data.DataColumn();
            this.dataColCodeName = new System.Data.DataColumn();
            this.dataColCodeFileName = new System.Data.DataColumn();
            this.bindingSource_ProductionPlan = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.gridBottomOrderHead = new PSAP.VIEW.BSVIEW.GridBottom();
            this.pnltop = new DevExpress.XtraEditors.PanelControl();
            this.btnSaveExcel = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpManufactureNo = new DevExpress.XtraEditors.LookUpEdit();
            this.searchLookUpCodeFileName = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpCodeFileNameView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColuCodeFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuCodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchLookUpProjectNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpProjectNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labCodeFileName = new DevExpress.XtraEditors.LabelControl();
            this.labProjectNo = new DevExpress.XtraEditors.LabelControl();
            this.textCommon = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxCurrentStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lookUpCreator = new DevExpress.XtraEditors.LookUpEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.datePlanDateEnd = new DevExpress.XtraEditors.DateEdit();
            this.lab = new DevExpress.XtraEditors.LabelControl();
            this.datePlanDateBegin = new DevExpress.XtraEditors.DateEdit();
            this.labCommon = new DevExpress.XtraEditors.LabelControl();
            this.labCreator = new DevExpress.XtraEditors.LabelControl();
            this.labCurrentStatus = new DevExpress.XtraEditors.LabelControl();
            this.labManufactureNo = new DevExpress.XtraEditors.LabelControl();
            this.labPlanDate = new DevExpress.XtraEditors.LabelControl();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.gridControlProductionPlan = new DevExpress.XtraGrid.GridControl();
            this.gridViewProductionPlan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentdatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchProjectNo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModifier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluCodeFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManufactureNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpManufactureNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSpinQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifierTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckPlanStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCodeFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignBomListId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_ProductionPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableProductionPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_ProductionPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpManufactureNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileNameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCurrentStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCreator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductionPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductionPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProjectNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpManufactureNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckPlanStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet_ProductionPlan
            // 
            this.dataSet_ProductionPlan.DataSetName = "NewDataSet";
            this.dataSet_ProductionPlan.EnforceConstraints = false;
            this.dataSet_ProductionPlan.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableProductionPlan});
            // 
            // dataTableProductionPlan
            // 
            this.dataTableProductionPlan.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColPlanNo,
            this.dataColCodeId,
            this.dataColQty,
            this.dataColProjectNo,
            this.dataColManufactureNo,
            this.dataColCurrentdatetime,
            this.dataColLine,
            this.dataColStartTime,
            this.dataColEndTime,
            this.dataColPlanStatus,
            this.dataColCurrentStatus,
            this.dataColCreator,
            this.dataColCreatorIp,
            this.dataColModifier,
            this.dataColModifierIp,
            this.dataColModifierTime,
            this.dataColRemark,
            this.dataColDesignBomListId,
            this.dataColCodeName,
            this.dataColCodeFileName});
            this.dataTableProductionPlan.TableName = "ProductionPlan";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColPlanNo
            // 
            this.dataColPlanNo.Caption = "工单号";
            this.dataColPlanNo.ColumnName = "PlanNo";
            // 
            // dataColCodeId
            // 
            this.dataColCodeId.Caption = "零件Id";
            this.dataColCodeId.ColumnName = "CodeId";
            this.dataColCodeId.DataType = typeof(int);
            // 
            // dataColQty
            // 
            this.dataColQty.Caption = "数量";
            this.dataColQty.ColumnName = "Qty";
            this.dataColQty.DataType = typeof(double);
            // 
            // dataColProjectNo
            // 
            this.dataColProjectNo.Caption = "项目号";
            this.dataColProjectNo.ColumnName = "ProjectNo";
            // 
            // dataColManufactureNo
            // 
            this.dataColManufactureNo.Caption = "工程信息";
            this.dataColManufactureNo.ColumnName = "ManufactureNo";
            // 
            // dataColCurrentdatetime
            // 
            this.dataColCurrentdatetime.Caption = "登记时间";
            this.dataColCurrentdatetime.ColumnName = "Currentdatetime";
            this.dataColCurrentdatetime.DataType = typeof(System.DateTime);
            // 
            // dataColLine
            // 
            this.dataColLine.Caption = "产线名称";
            this.dataColLine.ColumnName = "Line";
            // 
            // dataColStartTime
            // 
            this.dataColStartTime.Caption = "计划开始日期";
            this.dataColStartTime.ColumnName = "StartTime";
            this.dataColStartTime.DataType = typeof(System.DateTime);
            // 
            // dataColEndTime
            // 
            this.dataColEndTime.Caption = "计划结束日期";
            this.dataColEndTime.ColumnName = "EndTime";
            this.dataColEndTime.DataType = typeof(System.DateTime);
            // 
            // dataColPlanStatus
            // 
            this.dataColPlanStatus.Caption = "展开";
            this.dataColPlanStatus.ColumnName = "PlanStatus";
            this.dataColPlanStatus.DataType = typeof(int);
            // 
            // dataColCurrentStatus
            // 
            this.dataColCurrentStatus.Caption = "状态";
            this.dataColCurrentStatus.ColumnName = "CurrentStatus";
            this.dataColCurrentStatus.DataType = typeof(short);
            // 
            // dataColCreator
            // 
            this.dataColCreator.Caption = "创建人";
            this.dataColCreator.ColumnName = "Creator";
            this.dataColCreator.DataType = typeof(int);
            // 
            // dataColCreatorIp
            // 
            this.dataColCreatorIp.Caption = "创建人IP";
            this.dataColCreatorIp.ColumnName = "CreatorIp";
            // 
            // dataColModifier
            // 
            this.dataColModifier.Caption = "修改人";
            this.dataColModifier.ColumnName = "Modifier";
            this.dataColModifier.DataType = typeof(int);
            // 
            // dataColModifierIp
            // 
            this.dataColModifierIp.Caption = "修改人IP";
            this.dataColModifierIp.ColumnName = "ModifierIp";
            // 
            // dataColModifierTime
            // 
            this.dataColModifierTime.Caption = "修改时间";
            this.dataColModifierTime.ColumnName = "ModifierTime";
            this.dataColModifierTime.DataType = typeof(System.DateTime);
            // 
            // dataColRemark
            // 
            this.dataColRemark.Caption = "备注";
            this.dataColRemark.ColumnName = "Remark";
            // 
            // dataColDesignBomListId
            // 
            this.dataColDesignBomListId.Caption = "设计BomID";
            this.dataColDesignBomListId.ColumnName = "DesignBomListId";
            this.dataColDesignBomListId.DataType = typeof(int);
            // 
            // dataColCodeName
            // 
            this.dataColCodeName.Caption = "零件名称";
            this.dataColCodeName.ColumnName = "CodeName";
            // 
            // dataColCodeFileName
            // 
            this.dataColCodeFileName.Caption = "零件编号";
            this.dataColCodeFileName.ColumnName = "CodeFileName";
            // 
            // bindingSource_ProductionPlan
            // 
            this.bindingSource_ProductionPlan.DataMember = "ProductionPlan";
            this.bindingSource_ProductionPlan.DataSource = this.dataSet_ProductionPlan;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.gridBottomOrderHead);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 529);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1066, 58);
            this.pnlBottom.TabIndex = 7;
            // 
            // gridBottomOrderHead
            // 
            this.gridBottomOrderHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBottomOrderHead.Location = new System.Drawing.Point(2, 2);
            this.gridBottomOrderHead.MasterDataSet = this.dataSet_ProductionPlan;
            this.gridBottomOrderHead.Name = "gridBottomOrderHead";
            this.gridBottomOrderHead.pageRowCount = 5;
            this.gridBottomOrderHead.Size = new System.Drawing.Size(1062, 54);
            this.gridBottomOrderHead.TabIndex = 0;
            // 
            // pnltop
            // 
            this.pnltop.Controls.Add(this.btnSaveExcel);
            this.pnltop.Controls.Add(this.lookUpManufactureNo);
            this.pnltop.Controls.Add(this.searchLookUpCodeFileName);
            this.pnltop.Controls.Add(this.searchLookUpProjectNo);
            this.pnltop.Controls.Add(this.labCodeFileName);
            this.pnltop.Controls.Add(this.labProjectNo);
            this.pnltop.Controls.Add(this.textCommon);
            this.pnltop.Controls.Add(this.comboBoxCurrentStatus);
            this.pnltop.Controls.Add(this.lookUpCreator);
            this.pnltop.Controls.Add(this.btnQuery);
            this.pnltop.Controls.Add(this.datePlanDateEnd);
            this.pnltop.Controls.Add(this.lab);
            this.pnltop.Controls.Add(this.datePlanDateBegin);
            this.pnltop.Controls.Add(this.labCommon);
            this.pnltop.Controls.Add(this.labCreator);
            this.pnltop.Controls.Add(this.labCurrentStatus);
            this.pnltop.Controls.Add(this.labManufactureNo);
            this.pnltop.Controls.Add(this.labPlanDate);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1066, 78);
            this.pnltop.TabIndex = 8;
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(737, 43);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveExcel.TabIndex = 9;
            this.btnSaveExcel.Text = "存为Excel";
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // lookUpManufactureNo
            // 
            this.lookUpManufactureNo.EnterMoveNextControl = true;
            this.lookUpManufactureNo.Location = new System.Drawing.Point(384, 14);
            this.lookUpManufactureNo.Name = "lookUpManufactureNo";
            this.lookUpManufactureNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpManufactureNo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManufactureNo", "工程编号", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManufactureName", "工程名称", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManufactureTypeText", 80, "工程类型")});
            this.lookUpManufactureNo.Properties.DisplayMember = "ManufactureName";
            this.lookUpManufactureNo.Properties.NullText = "";
            this.lookUpManufactureNo.Properties.ValueMember = "ManufactureNo";
            this.lookUpManufactureNo.Size = new System.Drawing.Size(120, 20);
            this.lookUpManufactureNo.TabIndex = 2;
            // 
            // searchLookUpCodeFileName
            // 
            this.searchLookUpCodeFileName.EnterMoveNextControl = true;
            this.searchLookUpCodeFileName.Location = new System.Drawing.Point(587, 14);
            this.searchLookUpCodeFileName.Name = "searchLookUpCodeFileName";
            this.searchLookUpCodeFileName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpCodeFileName.Properties.DisplayMember = "CodeName";
            this.searchLookUpCodeFileName.Properties.NullText = "";
            this.searchLookUpCodeFileName.Properties.ValueMember = "AutoId";
            this.searchLookUpCodeFileName.Properties.View = this.searchLookUpCodeFileNameView;
            this.searchLookUpCodeFileName.Size = new System.Drawing.Size(150, 20);
            this.searchLookUpCodeFileName.TabIndex = 3;
            // 
            // searchLookUpCodeFileNameView
            // 
            this.searchLookUpCodeFileNameView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColuCodeFileName,
            this.gridColuCodeName,
            this.gridColuAutoId});
            this.searchLookUpCodeFileNameView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpCodeFileNameView.IndicatorWidth = 60;
            this.searchLookUpCodeFileNameView.Name = "searchLookUpCodeFileNameView";
            this.searchLookUpCodeFileNameView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpCodeFileNameView.OptionsView.ShowGroupPanel = false;
            this.searchLookUpCodeFileNameView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewProductionPlan_CustomDrawRowIndicator);
            // 
            // gridColuCodeFileName
            // 
            this.gridColuCodeFileName.Caption = "零件编号";
            this.gridColuCodeFileName.FieldName = "CodeFileName";
            this.gridColuCodeFileName.Name = "gridColuCodeFileName";
            this.gridColuCodeFileName.Visible = true;
            this.gridColuCodeFileName.VisibleIndex = 0;
            // 
            // gridColuCodeName
            // 
            this.gridColuCodeName.Caption = "零件名称";
            this.gridColuCodeName.FieldName = "CodeName";
            this.gridColuCodeName.Name = "gridColuCodeName";
            this.gridColuCodeName.Visible = true;
            this.gridColuCodeName.VisibleIndex = 1;
            // 
            // gridColuAutoId
            // 
            this.gridColuAutoId.Caption = "AutoId";
            this.gridColuAutoId.FieldName = "AutoId";
            this.gridColuAutoId.Name = "gridColuAutoId";
            // 
            // searchLookUpProjectNo
            // 
            this.searchLookUpProjectNo.EnterMoveNextControl = true;
            this.searchLookUpProjectNo.Location = new System.Drawing.Point(807, 14);
            this.searchLookUpProjectNo.Name = "searchLookUpProjectNo";
            this.searchLookUpProjectNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpProjectNo.Properties.DisplayMember = "ProjectName";
            this.searchLookUpProjectNo.Properties.NullText = "";
            this.searchLookUpProjectNo.Properties.ValueMember = "ProjectNo";
            this.searchLookUpProjectNo.Properties.View = this.searchLookUpProjectNoView;
            this.searchLookUpProjectNo.Size = new System.Drawing.Size(150, 20);
            this.searchLookUpProjectNo.TabIndex = 4;
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
            this.searchLookUpProjectNoView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewProductionPlan_CustomDrawRowIndicator);
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
            // labCodeFileName
            // 
            this.labCodeFileName.Location = new System.Drawing.Point(521, 17);
            this.labCodeFileName.Name = "labCodeFileName";
            this.labCodeFileName.Size = new System.Drawing.Size(60, 14);
            this.labCodeFileName.TabIndex = 43;
            this.labCodeFileName.Text = "零件名称：";
            // 
            // labProjectNo
            // 
            this.labProjectNo.Location = new System.Drawing.Point(753, 17);
            this.labProjectNo.Name = "labProjectNo";
            this.labProjectNo.Size = new System.Drawing.Size(48, 14);
            this.labProjectNo.TabIndex = 42;
            this.labProjectNo.Text = "项目号：";
            // 
            // textCommon
            // 
            this.textCommon.EnterMoveNextControl = true;
            this.textCommon.Location = new System.Drawing.Point(481, 44);
            this.textCommon.Name = "textCommon";
            this.textCommon.Size = new System.Drawing.Size(150, 20);
            this.textCommon.TabIndex = 7;
            // 
            // comboBoxCurrentStatus
            // 
            this.comboBoxCurrentStatus.EnterMoveNextControl = true;
            this.comboBoxCurrentStatus.Location = new System.Drawing.Point(86, 44);
            this.comboBoxCurrentStatus.Name = "comboBoxCurrentStatus";
            this.comboBoxCurrentStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCurrentStatus.Properties.Items.AddRange(new object[] {
            "全部",
            "待审批",
            "审批",
            "审批中",
            "提交",
            "拒绝"});
            this.comboBoxCurrentStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxCurrentStatus.Size = new System.Drawing.Size(120, 20);
            this.comboBoxCurrentStatus.TabIndex = 5;
            // 
            // lookUpCreator
            // 
            this.lookUpCreator.EnterMoveNextControl = true;
            this.lookUpCreator.Location = new System.Drawing.Point(277, 44);
            this.lookUpCreator.Name = "lookUpCreator";
            this.lookUpCreator.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCreator.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 80, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoginId", "用户名", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "员工名", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpCreator.Properties.DisplayMember = "EmpName";
            this.lookUpCreator.Properties.NullText = "";
            this.lookUpCreator.Properties.ValueMember = "AutoId";
            this.lookUpCreator.Size = new System.Drawing.Size(120, 20);
            this.lookUpCreator.TabIndex = 6;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(647, 43);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // datePlanDateEnd
            // 
            this.datePlanDateEnd.EditValue = null;
            this.datePlanDateEnd.EnterMoveNextControl = true;
            this.datePlanDateEnd.Location = new System.Drawing.Point(202, 14);
            this.datePlanDateEnd.Name = "datePlanDateEnd";
            this.datePlanDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePlanDateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePlanDateEnd.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.datePlanDateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePlanDateEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.datePlanDateEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePlanDateEnd.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.datePlanDateEnd.Size = new System.Drawing.Size(100, 20);
            this.datePlanDateEnd.TabIndex = 1;
            // 
            // lab
            // 
            this.lab.Location = new System.Drawing.Point(192, 17);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(4, 14);
            this.lab.TabIndex = 2;
            this.lab.Text = "-";
            // 
            // datePlanDateBegin
            // 
            this.datePlanDateBegin.EditValue = null;
            this.datePlanDateBegin.EnterMoveNextControl = true;
            this.datePlanDateBegin.Location = new System.Drawing.Point(86, 14);
            this.datePlanDateBegin.Name = "datePlanDateBegin";
            this.datePlanDateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePlanDateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePlanDateBegin.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.datePlanDateBegin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePlanDateBegin.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.datePlanDateBegin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePlanDateBegin.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.datePlanDateBegin.Size = new System.Drawing.Size(100, 20);
            this.datePlanDateBegin.TabIndex = 0;
            // 
            // labCommon
            // 
            this.labCommon.Location = new System.Drawing.Point(415, 47);
            this.labCommon.Name = "labCommon";
            this.labCommon.Size = new System.Drawing.Size(60, 14);
            this.labCommon.TabIndex = 14;
            this.labCommon.Text = "通用查询：";
            // 
            // labCreator
            // 
            this.labCreator.Location = new System.Drawing.Point(223, 47);
            this.labCreator.Name = "labCreator";
            this.labCreator.Size = new System.Drawing.Size(48, 14);
            this.labCreator.TabIndex = 11;
            this.labCreator.Text = "创建人：";
            // 
            // labCurrentStatus
            // 
            this.labCurrentStatus.Location = new System.Drawing.Point(20, 47);
            this.labCurrentStatus.Name = "labCurrentStatus";
            this.labCurrentStatus.Size = new System.Drawing.Size(60, 14);
            this.labCurrentStatus.TabIndex = 9;
            this.labCurrentStatus.Text = "单据状态：";
            // 
            // labManufactureNo
            // 
            this.labManufactureNo.Location = new System.Drawing.Point(318, 17);
            this.labManufactureNo.Name = "labManufactureNo";
            this.labManufactureNo.Size = new System.Drawing.Size(60, 14);
            this.labManufactureNo.TabIndex = 7;
            this.labManufactureNo.Text = "工程名称：";
            // 
            // labPlanDate
            // 
            this.labPlanDate.Location = new System.Drawing.Point(20, 17);
            this.labPlanDate.Name = "labPlanDate";
            this.labPlanDate.Size = new System.Drawing.Size(60, 14);
            this.labPlanDate.TabIndex = 1;
            this.labPlanDate.Text = "计划日期：";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.gridControlProductionPlan);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 78);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1066, 451);
            this.pnlMiddle.TabIndex = 9;
            // 
            // gridControlProductionPlan
            // 
            this.gridControlProductionPlan.DataSource = this.bindingSource_ProductionPlan;
            this.gridControlProductionPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProductionPlan.Location = new System.Drawing.Point(2, 2);
            this.gridControlProductionPlan.MainView = this.gridViewProductionPlan;
            this.gridControlProductionPlan.Name = "gridControlProductionPlan";
            this.gridControlProductionPlan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSearchProjectNo,
            this.repSpinQty,
            this.repLookUpManufactureNo,
            this.repLookUpCreator,
            this.repCheckPlanStatus});
            this.gridControlProductionPlan.Size = new System.Drawing.Size(1062, 447);
            this.gridControlProductionPlan.TabIndex = 4;
            this.gridControlProductionPlan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProductionPlan});
            // 
            // gridViewProductionPlan
            // 
            this.gridViewProductionPlan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colPlanNo,
            this.colCurrentStatus,
            this.colCurrentdatetime,
            this.colProjectNo,
            this.colRemark,
            this.colCreator,
            this.colModifier,
            this.coluCodeFileName,
            this.colLine,
            this.colManufactureNo,
            this.colQty,
            this.colStartTime,
            this.colEndTime,
            this.colModifierTime,
            this.colPlanStatus,
            this.colCodeFileName,
            this.colDesignBomListId,
            this.colCodeId});
            this.gridViewProductionPlan.GridControl = this.gridControlProductionPlan;
            this.gridViewProductionPlan.IndicatorWidth = 40;
            this.gridViewProductionPlan.Name = "gridViewProductionPlan";
            this.gridViewProductionPlan.OptionsBehavior.Editable = false;
            this.gridViewProductionPlan.OptionsBehavior.ReadOnly = true;
            this.gridViewProductionPlan.OptionsMenu.EnableColumnMenu = false;
            this.gridViewProductionPlan.OptionsMenu.EnableFooterMenu = false;
            this.gridViewProductionPlan.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewProductionPlan.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewProductionPlan.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewProductionPlan.OptionsView.ColumnAutoWidth = false;
            this.gridViewProductionPlan.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewProductionPlan.OptionsView.ShowFooter = true;
            this.gridViewProductionPlan.OptionsView.ShowGroupPanel = false;
            this.gridViewProductionPlan.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewProductionPlan_RowClick);
            this.gridViewProductionPlan.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewProductionPlan_CustomDrawRowIndicator);
            this.gridViewProductionPlan.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewProductionPlan_CustomColumnDisplayText);
            this.gridViewProductionPlan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewProductionPlan_KeyDown);
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colPlanNo
            // 
            this.colPlanNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colPlanNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPlanNo.FieldName = "PlanNo";
            this.colPlanNo.Name = "colPlanNo";
            this.colPlanNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PlanNo", "共计{0}条")});
            this.colPlanNo.Visible = true;
            this.colPlanNo.VisibleIndex = 0;
            this.colPlanNo.Width = 110;
            // 
            // colCurrentStatus
            // 
            this.colCurrentStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentStatus.FieldName = "CurrentStatus";
            this.colCurrentStatus.Name = "colCurrentStatus";
            this.colCurrentStatus.Visible = true;
            this.colCurrentStatus.VisibleIndex = 1;
            this.colCurrentStatus.Width = 60;
            // 
            // colCurrentdatetime
            // 
            this.colCurrentdatetime.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentdatetime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentdatetime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCurrentdatetime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCurrentdatetime.FieldName = "Currentdatetime";
            this.colCurrentdatetime.Name = "colCurrentdatetime";
            this.colCurrentdatetime.Visible = true;
            this.colCurrentdatetime.VisibleIndex = 13;
            this.colCurrentdatetime.Width = 135;
            // 
            // colProjectNo
            // 
            this.colProjectNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectNo.ColumnEdit = this.repSearchProjectNo;
            this.colProjectNo.FieldName = "ProjectNo";
            this.colProjectNo.Name = "colProjectNo";
            this.colProjectNo.Visible = true;
            this.colProjectNo.VisibleIndex = 6;
            this.colProjectNo.Width = 100;
            // 
            // repSearchProjectNo
            // 
            this.repSearchProjectNo.AutoHeight = false;
            this.repSearchProjectNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearchProjectNo.DisplayMember = "ProjectNo";
            this.repSearchProjectNo.Name = "repSearchProjectNo";
            this.repSearchProjectNo.NullText = "";
            this.repSearchProjectNo.ValueMember = "ProjectNo";
            this.repSearchProjectNo.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnProjectNo,
            this.gridColumnProjectName,
            this.gridColumnRemark});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.IndicatorWidth = 60;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnProjectNo
            // 
            this.gridColumnProjectNo.Caption = "项目号";
            this.gridColumnProjectNo.FieldName = "ProjectNo";
            this.gridColumnProjectNo.Name = "gridColumnProjectNo";
            this.gridColumnProjectNo.Visible = true;
            this.gridColumnProjectNo.VisibleIndex = 0;
            // 
            // gridColumnProjectName
            // 
            this.gridColumnProjectName.Caption = "项目名称";
            this.gridColumnProjectName.FieldName = "ProjectName";
            this.gridColumnProjectName.Name = "gridColumnProjectName";
            this.gridColumnProjectName.Visible = true;
            this.gridColumnProjectName.VisibleIndex = 1;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "备注";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 2;
            // 
            // colRemark
            // 
            this.colRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 11;
            this.colRemark.Width = 140;
            // 
            // colCreator
            // 
            this.colCreator.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreator.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreator.ColumnEdit = this.repLookUpCreator;
            this.colCreator.FieldName = "Creator";
            this.colCreator.Name = "colCreator";
            this.colCreator.Visible = true;
            this.colCreator.VisibleIndex = 12;
            this.colCreator.Width = 70;
            // 
            // repLookUpCreator
            // 
            this.repLookUpCreator.AutoHeight = false;
            this.repLookUpCreator.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpCreator.DisplayMember = "EmpName";
            this.repLookUpCreator.Name = "repLookUpCreator";
            this.repLookUpCreator.NullText = "";
            this.repLookUpCreator.ValueMember = "AutoId";
            // 
            // colModifier
            // 
            this.colModifier.AppearanceHeader.Options.UseTextOptions = true;
            this.colModifier.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifier.ColumnEdit = this.repLookUpCreator;
            this.colModifier.FieldName = "Modifier";
            this.colModifier.Name = "colModifier";
            this.colModifier.Visible = true;
            this.colModifier.VisibleIndex = 14;
            this.colModifier.Width = 70;
            // 
            // coluCodeFileName
            // 
            this.coluCodeFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.coluCodeFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coluCodeFileName.FieldName = "CodeFileName";
            this.coluCodeFileName.Name = "coluCodeFileName";
            this.coluCodeFileName.Visible = true;
            this.coluCodeFileName.VisibleIndex = 2;
            this.coluCodeFileName.Width = 140;
            // 
            // colLine
            // 
            this.colLine.AppearanceHeader.Options.UseTextOptions = true;
            this.colLine.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLine.FieldName = "Line";
            this.colLine.Name = "colLine";
            this.colLine.Visible = true;
            this.colLine.VisibleIndex = 7;
            this.colLine.Width = 100;
            // 
            // colManufactureNo
            // 
            this.colManufactureNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colManufactureNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colManufactureNo.ColumnEdit = this.repLookUpManufactureNo;
            this.colManufactureNo.FieldName = "ManufactureNo";
            this.colManufactureNo.Name = "colManufactureNo";
            this.colManufactureNo.Visible = true;
            this.colManufactureNo.VisibleIndex = 5;
            this.colManufactureNo.Width = 100;
            // 
            // repLookUpManufactureNo
            // 
            this.repLookUpManufactureNo.AutoHeight = false;
            this.repLookUpManufactureNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpManufactureNo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManufactureNo", "工程编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManufactureName", "工程名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManufactureTypeText", "工程类型")});
            this.repLookUpManufactureNo.DisplayMember = "ManufactureName";
            this.repLookUpManufactureNo.Name = "repLookUpManufactureNo";
            this.repLookUpManufactureNo.NullText = "";
            this.repLookUpManufactureNo.ValueMember = "ManufactureNo";
            // 
            // colQty
            // 
            this.colQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQty.ColumnEdit = this.repSpinQty;
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:0.##}")});
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 4;
            // 
            // repSpinQty
            // 
            this.repSpinQty.AutoHeight = false;
            this.repSpinQty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpinQty.MaxValue = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.repSpinQty.Name = "repSpinQty";
            // 
            // colStartTime
            // 
            this.colStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStartTime.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 8;
            this.colStartTime.Width = 100;
            // 
            // colEndTime
            // 
            this.colEndTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colEndTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEndTime.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 9;
            this.colEndTime.Width = 100;
            // 
            // colModifierTime
            // 
            this.colModifierTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colModifierTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifierTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colModifierTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colModifierTime.FieldName = "ModifierTime";
            this.colModifierTime.Name = "colModifierTime";
            this.colModifierTime.Visible = true;
            this.colModifierTime.VisibleIndex = 15;
            this.colModifierTime.Width = 135;
            // 
            // colPlanStatus
            // 
            this.colPlanStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colPlanStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPlanStatus.ColumnEdit = this.repCheckPlanStatus;
            this.colPlanStatus.FieldName = "PlanStatus";
            this.colPlanStatus.Name = "colPlanStatus";
            this.colPlanStatus.Visible = true;
            this.colPlanStatus.VisibleIndex = 10;
            this.colPlanStatus.Width = 60;
            // 
            // repCheckPlanStatus
            // 
            this.repCheckPlanStatus.AutoHeight = false;
            this.repCheckPlanStatus.Name = "repCheckPlanStatus";
            this.repCheckPlanStatus.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckPlanStatus.ValueChecked = 1;
            this.repCheckPlanStatus.ValueGrayed = 0;
            this.repCheckPlanStatus.ValueUnchecked = 0;
            // 
            // colCodeFileName
            // 
            this.colCodeFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeFileName.FieldName = "CodeName";
            this.colCodeFileName.Name = "colCodeFileName";
            this.colCodeFileName.Visible = true;
            this.colCodeFileName.VisibleIndex = 3;
            this.colCodeFileName.Width = 120;
            // 
            // colDesignBomListId
            // 
            this.colDesignBomListId.FieldName = "DesignBomListId";
            this.colDesignBomListId.Name = "colDesignBomListId";
            // 
            // colCodeId
            // 
            this.colCodeId.FieldName = "CodeId";
            this.colCodeId.Name = "colCodeId";
            // 
            // FrmProductionPlanQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1066, 587);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnltop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "FrmProductionPlanQuery";
            this.TabText = "工单查询";
            this.Text = "工单查询";
            this.Load += new System.EventHandler(this.FrmProductionPlanQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_ProductionPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableProductionPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_ProductionPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpManufactureNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileNameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCurrentStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCreator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductionPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductionPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProjectNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpManufactureNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckPlanStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSet_ProductionPlan;
        private System.Data.DataTable dataTableProductionPlan;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColPlanNo;
        private System.Data.DataColumn dataColCodeId;
        private System.Data.DataColumn dataColQty;
        private System.Data.DataColumn dataColProjectNo;
        private System.Data.DataColumn dataColManufactureNo;
        private System.Data.DataColumn dataColCurrentdatetime;
        private System.Data.DataColumn dataColLine;
        private System.Data.DataColumn dataColStartTime;
        private System.Data.DataColumn dataColEndTime;
        private System.Data.DataColumn dataColPlanStatus;
        private System.Data.DataColumn dataColCurrentStatus;
        private System.Data.DataColumn dataColCreator;
        private System.Data.DataColumn dataColCreatorIp;
        private System.Data.DataColumn dataColModifier;
        private System.Data.DataColumn dataColModifierIp;
        private System.Data.DataColumn dataColModifierTime;
        private System.Data.DataColumn dataColRemark;
        private System.Data.DataColumn dataColDesignBomListId;
        private System.Data.DataColumn dataColCodeName;
        private System.Data.DataColumn dataColCodeFileName;
        private System.Windows.Forms.BindingSource bindingSource_ProductionPlan;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private GridBottom gridBottomOrderHead;
        private DevExpress.XtraEditors.PanelControl pnltop;
        private DevExpress.XtraEditors.LookUpEdit lookUpManufactureNo;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpCodeFileName;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpCodeFileNameView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuAutoId;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpProjectNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpProjectNoView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProjectNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private DevExpress.XtraEditors.LabelControl labCodeFileName;
        private DevExpress.XtraEditors.LabelControl labProjectNo;
        private DevExpress.XtraEditors.TextEdit textCommon;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxCurrentStatus;
        private DevExpress.XtraEditors.LookUpEdit lookUpCreator;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.DateEdit datePlanDateEnd;
        private DevExpress.XtraEditors.LabelControl lab;
        private DevExpress.XtraEditors.DateEdit datePlanDateBegin;
        private DevExpress.XtraEditors.LabelControl labCommon;
        private DevExpress.XtraEditors.LabelControl labCreator;
        private DevExpress.XtraEditors.LabelControl labCurrentStatus;
        private DevExpress.XtraEditors.LabelControl labManufactureNo;
        private DevExpress.XtraEditors.LabelControl labPlanDate;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraGrid.GridControl gridControlProductionPlan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductionPlan;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentdatetime;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchProjectNo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProjectNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colModifier;
        private DevExpress.XtraGrid.Columns.GridColumn coluCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.Columns.GridColumn colManufactureNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpManufactureNo;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinQty;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colModifierTime;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckPlanStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignBomListId;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeId;
        private DevExpress.XtraEditors.SimpleButton btnSaveExcel;
    }
}