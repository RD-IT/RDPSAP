namespace PSAP.VIEW.BSVIEW
{
    partial class FrmProductionPlan
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
            this.repCheckEditIsUse = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
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
            this.dataColSelect = new System.Data.DataColumn();
            this.dataColDesignBomListId = new System.Data.DataColumn();
            this.dataColCodeName = new System.Data.DataColumn();
            this.dataColCodeFileName = new System.Data.DataColumn();
            this.dataTableProductionPlanList = new System.Data.DataTable();
            this.dataColuAutoId = new System.Data.DataColumn();
            this.dataColuPlanNo = new System.Data.DataColumn();
            this.dataColuCodeId = new System.Data.DataColumn();
            this.dataColuUnitQty = new System.Data.DataColumn();
            this.dataColuPlanQty = new System.Data.DataColumn();
            this.dataColuQty = new System.Data.DataColumn();
            this.dataColuAfterFlag = new System.Data.DataColumn();
            this.dataColuCodeName = new System.Data.DataColumn();
            this.dataColuLevelCodeId = new System.Data.DataColumn();
            this.dataColuParentId = new System.Data.DataColumn();
            this.dataColuHasLevel = new System.Data.DataColumn();
            this.dataColuIsAll = new System.Data.DataColumn();
            this.dataColuIsBuy = new System.Data.DataColumn();
            this.dataColuDesignBomListId = new System.Data.DataColumn();
            this.dataColuDesignBomListParentId = new System.Data.DataColumn();
            this.bindingSource_ProductionPlan = new System.Windows.Forms.BindingSource(this.components);
            this.pnltop = new DevExpress.XtraEditors.PanelControl();
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
            this.lookUpApprover = new DevExpress.XtraEditors.LookUpEdit();
            this.textCommon = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxCurrentStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lookUpCreator = new DevExpress.XtraEditors.LookUpEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.datePlanDateEnd = new DevExpress.XtraEditors.DateEdit();
            this.lab = new DevExpress.XtraEditors.LabelControl();
            this.datePlanDateBegin = new DevExpress.XtraEditors.DateEdit();
            this.labApprover = new DevExpress.XtraEditors.LabelControl();
            this.labCommon = new DevExpress.XtraEditors.LabelControl();
            this.labCreator = new DevExpress.XtraEditors.LabelControl();
            this.labCurrentStatus = new DevExpress.XtraEditors.LabelControl();
            this.labManufactureNo = new DevExpress.XtraEditors.LabelControl();
            this.labPlanDate = new DevExpress.XtraEditors.LabelControl();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.checkAll = new DevExpress.XtraEditors.CheckEdit();
            this.gridControlProductionPlan = new DevExpress.XtraGrid.GridControl();
            this.gridViewProductionPlan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colPlanNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentdatetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchProjectNo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchProjectNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModifier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluCodeFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repButtonCodeId = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTextLine = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
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
            this.repLookUpApprovalType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.pnlMiddleTop = new DevExpress.XtraEditors.PanelControl();
            this.btnCancelSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.treeListDesignBom = new DevExpress.XtraTreeList.TreeList();
            this.columnAutoId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnPlanNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnLevelCodeId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repLookUpCodeId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCodeName1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repLookUpCodeName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colHasLevel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnIsAll = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsBuy = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUnitQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPlanQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repSpinRemainQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.columnAfterFlag = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnCodeId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.columnDesignBomListId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bindingSource_ProductionPlanList = new System.Windows.Forms.BindingSource(this.components);
            this.pnlRight = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditIsUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_ProductionPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableProductionPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableProductionPlanList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_ProductionPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpManufactureNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileNameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpApprover.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCurrentStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCreator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductionPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductionPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProjectNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProjectNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repButtonCodeId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTextLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpManufactureNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckPlanStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddleTop)).BeginInit();
            this.pnlMiddleTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCodeId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinRemainQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_ProductionPlanList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // repCheckEditIsUse
            // 
            this.repCheckEditIsUse.AutoHeight = false;
            this.repCheckEditIsUse.Name = "repCheckEditIsUse";
            this.repCheckEditIsUse.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckEditIsUse.ValueChecked = ((short)(1));
            this.repCheckEditIsUse.ValueGrayed = ((short)(0));
            this.repCheckEditIsUse.ValueUnchecked = ((short)(0));
            // 
            // dataSet_ProductionPlan
            // 
            this.dataSet_ProductionPlan.DataSetName = "NewDataSet";
            this.dataSet_ProductionPlan.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableProductionPlan,
            this.dataTableProductionPlanList});
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
            this.dataColSelect,
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
            // dataColSelect
            // 
            this.dataColSelect.Caption = "";
            this.dataColSelect.ColumnName = "Select";
            this.dataColSelect.DataType = typeof(bool);
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
            // dataTableProductionPlanList
            // 
            this.dataTableProductionPlanList.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColuAutoId,
            this.dataColuPlanNo,
            this.dataColuCodeId,
            this.dataColuUnitQty,
            this.dataColuPlanQty,
            this.dataColuQty,
            this.dataColuAfterFlag,
            this.dataColuCodeName,
            this.dataColuLevelCodeId,
            this.dataColuParentId,
            this.dataColuHasLevel,
            this.dataColuIsAll,
            this.dataColuIsBuy,
            this.dataColuDesignBomListId,
            this.dataColuDesignBomListParentId});
            this.dataTableProductionPlanList.TableName = "ProductionPlanList";
            // 
            // dataColuAutoId
            // 
            this.dataColuAutoId.ColumnName = "AutoId";
            this.dataColuAutoId.DataType = typeof(int);
            // 
            // dataColuPlanNo
            // 
            this.dataColuPlanNo.Caption = "工单号";
            this.dataColuPlanNo.ColumnName = "PlanNo";
            // 
            // dataColuCodeId
            // 
            this.dataColuCodeId.Caption = "子零件编号";
            this.dataColuCodeId.ColumnName = "CodeId";
            this.dataColuCodeId.DataType = typeof(int);
            // 
            // dataColuUnitQty
            // 
            this.dataColuUnitQty.Caption = "单位数量";
            this.dataColuUnitQty.ColumnName = "UnitQty";
            this.dataColuUnitQty.DataType = typeof(double);
            // 
            // dataColuPlanQty
            // 
            this.dataColuPlanQty.Caption = "计划数量";
            this.dataColuPlanQty.ColumnName = "PlanQty";
            this.dataColuPlanQty.DataType = typeof(double);
            // 
            // dataColuQty
            // 
            this.dataColuQty.Caption = "实际数量";
            this.dataColuQty.ColumnName = "Qty";
            this.dataColuQty.DataType = typeof(double);
            // 
            // dataColuAfterFlag
            // 
            this.dataColuAfterFlag.Caption = "后续标记";
            this.dataColuAfterFlag.ColumnName = "AfterFlag";
            this.dataColuAfterFlag.DataType = typeof(int);
            // 
            // dataColuCodeName
            // 
            this.dataColuCodeName.Caption = "子零件名称";
            this.dataColuCodeName.ColumnName = "CodeName";
            // 
            // dataColuLevelCodeId
            // 
            this.dataColuLevelCodeId.Caption = "下级零件编号";
            this.dataColuLevelCodeId.ColumnName = "LevelCodeId";
            this.dataColuLevelCodeId.DataType = typeof(int);
            // 
            // dataColuParentId
            // 
            this.dataColuParentId.ColumnName = "ParentId";
            this.dataColuParentId.DataType = typeof(int);
            // 
            // dataColuHasLevel
            // 
            this.dataColuHasLevel.ColumnName = "HasLevel";
            this.dataColuHasLevel.DataType = typeof(int);
            // 
            // dataColuIsAll
            // 
            this.dataColuIsAll.ColumnName = "IsAll";
            this.dataColuIsAll.DataType = typeof(int);
            // 
            // dataColuIsBuy
            // 
            this.dataColuIsBuy.ColumnName = "IsBuy";
            this.dataColuIsBuy.DataType = typeof(int);
            // 
            // dataColuDesignBomListId
            // 
            this.dataColuDesignBomListId.ColumnName = "DesignBomListId";
            this.dataColuDesignBomListId.DataType = typeof(int);
            // 
            // dataColuDesignBomListParentId
            // 
            this.dataColuDesignBomListParentId.ColumnName = "DesignBomListParentId";
            this.dataColuDesignBomListParentId.DataType = typeof(int);
            // 
            // bindingSource_ProductionPlan
            // 
            this.bindingSource_ProductionPlan.DataMember = "ProductionPlan";
            this.bindingSource_ProductionPlan.DataSource = this.dataSet_ProductionPlan;
            // 
            // pnltop
            // 
            this.pnltop.Controls.Add(this.lookUpManufactureNo);
            this.pnltop.Controls.Add(this.searchLookUpCodeFileName);
            this.pnltop.Controls.Add(this.searchLookUpProjectNo);
            this.pnltop.Controls.Add(this.labCodeFileName);
            this.pnltop.Controls.Add(this.labProjectNo);
            this.pnltop.Controls.Add(this.lookUpApprover);
            this.pnltop.Controls.Add(this.textCommon);
            this.pnltop.Controls.Add(this.comboBoxCurrentStatus);
            this.pnltop.Controls.Add(this.lookUpCreator);
            this.pnltop.Controls.Add(this.btnQuery);
            this.pnltop.Controls.Add(this.datePlanDateEnd);
            this.pnltop.Controls.Add(this.lab);
            this.pnltop.Controls.Add(this.datePlanDateBegin);
            this.pnltop.Controls.Add(this.labApprover);
            this.pnltop.Controls.Add(this.labCommon);
            this.pnltop.Controls.Add(this.labCreator);
            this.pnltop.Controls.Add(this.labCurrentStatus);
            this.pnltop.Controls.Add(this.labManufactureNo);
            this.pnltop.Controls.Add(this.labPlanDate);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1304, 78);
            this.pnltop.TabIndex = 1;
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
            // lookUpApprover
            // 
            this.lookUpApprover.EnterMoveNextControl = true;
            this.lookUpApprover.Location = new System.Drawing.Point(461, 44);
            this.lookUpApprover.Name = "lookUpApprover";
            this.lookUpApprover.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpApprover.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpApprover.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 80, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoginId", "用户名", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "员工名", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpApprover.Properties.DisplayMember = "EmpName";
            this.lookUpApprover.Properties.NullText = "";
            this.lookUpApprover.Properties.ValueMember = "AutoId";
            this.lookUpApprover.Size = new System.Drawing.Size(120, 20);
            this.lookUpApprover.TabIndex = 7;
            this.lookUpApprover.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lookUpApprover_KeyDown);
            // 
            // textCommon
            // 
            this.textCommon.EnterMoveNextControl = true;
            this.textCommon.Location = new System.Drawing.Point(661, 44);
            this.textCommon.Name = "textCommon";
            this.textCommon.Size = new System.Drawing.Size(150, 20);
            this.textCommon.TabIndex = 8;
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
            this.btnQuery.Location = new System.Drawing.Point(827, 43);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 9;
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
            // labApprover
            // 
            this.labApprover.Location = new System.Drawing.Point(413, 47);
            this.labApprover.Name = "labApprover";
            this.labApprover.Size = new System.Drawing.Size(48, 14);
            this.labApprover.TabIndex = 24;
            this.labApprover.Text = "审批人：";
            // 
            // labCommon
            // 
            this.labCommon.Location = new System.Drawing.Point(595, 47);
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
            this.pnlMiddle.Controls.Add(this.checkAll);
            this.pnlMiddle.Controls.Add(this.gridControlProductionPlan);
            this.pnlMiddle.Controls.Add(this.pnlMiddleTop);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 78);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1304, 228);
            this.pnlMiddle.TabIndex = 2;
            // 
            // checkAll
            // 
            this.checkAll.Location = new System.Drawing.Point(53, 40);
            this.checkAll.Margin = new System.Windows.Forms.Padding(4);
            this.checkAll.Name = "checkAll";
            this.checkAll.Properties.AutoHeight = false;
            this.checkAll.Properties.Caption = "";
            this.checkAll.Size = new System.Drawing.Size(16, 15);
            this.checkAll.TabIndex = 19;
            this.checkAll.TabStop = false;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // gridControlProductionPlan
            // 
            this.gridControlProductionPlan.DataSource = this.bindingSource_ProductionPlan;
            this.gridControlProductionPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProductionPlan.Location = new System.Drawing.Point(2, 36);
            this.gridControlProductionPlan.MainView = this.gridViewProductionPlan;
            this.gridControlProductionPlan.Name = "gridControlProductionPlan";
            this.gridControlProductionPlan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSearchProjectNo,
            this.repCheckSelect,
            this.repLookUpApprovalType,
            this.repSpinQty,
            this.repLookUpManufactureNo,
            this.repLookUpCreator,
            this.repTextLine,
            this.repCheckPlanStatus,
            this.repButtonCodeId});
            this.gridControlProductionPlan.Size = new System.Drawing.Size(1300, 190);
            this.gridControlProductionPlan.TabIndex = 3;
            this.gridControlProductionPlan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProductionPlan});
            // 
            // gridViewProductionPlan
            // 
            this.gridViewProductionPlan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.gridColSelect,
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
            this.gridViewProductionPlan.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewProductionPlan.OptionsMenu.EnableColumnMenu = false;
            this.gridViewProductionPlan.OptionsMenu.EnableFooterMenu = false;
            this.gridViewProductionPlan.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewProductionPlan.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewProductionPlan.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewProductionPlan.OptionsView.ColumnAutoWidth = false;
            this.gridViewProductionPlan.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewProductionPlan.OptionsView.ShowFooter = true;
            this.gridViewProductionPlan.OptionsView.ShowGroupPanel = false;
            this.gridViewProductionPlan.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewProductionPlan_CustomDrawRowIndicator);
            this.gridViewProductionPlan.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewProductionPlan_InitNewRow);
            this.gridViewProductionPlan.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewProductionPlan_FocusedRowChanged);
            this.gridViewProductionPlan.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewProductionPlan_CellValueChanged);
            this.gridViewProductionPlan.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewProductionPlan_CustomColumnDisplayText);
            this.gridViewProductionPlan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewProductionPlan_KeyDown);
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // gridColSelect
            // 
            this.gridColSelect.ColumnEdit = this.repCheckSelect;
            this.gridColSelect.FieldName = "Select";
            this.gridColSelect.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColSelect.Name = "gridColSelect";
            this.gridColSelect.Visible = true;
            this.gridColSelect.VisibleIndex = 0;
            this.gridColSelect.Width = 35;
            // 
            // repCheckSelect
            // 
            this.repCheckSelect.AutoHeight = false;
            this.repCheckSelect.Name = "repCheckSelect";
            this.repCheckSelect.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckSelect.ValueGrayed = false;
            this.repCheckSelect.CheckedChanged += new System.EventHandler(this.repCheckSelect_EditValueChanged);
            // 
            // colPlanNo
            // 
            this.colPlanNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colPlanNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPlanNo.FieldName = "PlanNo";
            this.colPlanNo.Name = "colPlanNo";
            this.colPlanNo.OptionsColumn.AllowEdit = false;
            this.colPlanNo.OptionsColumn.TabStop = false;
            this.colPlanNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PlanNo", "共计{0}条")});
            this.colPlanNo.Visible = true;
            this.colPlanNo.VisibleIndex = 1;
            this.colPlanNo.Width = 110;
            // 
            // colCurrentStatus
            // 
            this.colCurrentStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentStatus.FieldName = "CurrentStatus";
            this.colCurrentStatus.Name = "colCurrentStatus";
            this.colCurrentStatus.OptionsColumn.AllowEdit = false;
            this.colCurrentStatus.OptionsColumn.TabStop = false;
            this.colCurrentStatus.Visible = true;
            this.colCurrentStatus.VisibleIndex = 2;
            this.colCurrentStatus.Width = 60;
            // 
            // colCurrentdatetime
            // 
            this.colCurrentdatetime.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentdatetime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentdatetime.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colCurrentdatetime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCurrentdatetime.FieldName = "Currentdatetime";
            this.colCurrentdatetime.Name = "colCurrentdatetime";
            this.colCurrentdatetime.OptionsColumn.AllowEdit = false;
            this.colCurrentdatetime.OptionsColumn.TabStop = false;
            this.colCurrentdatetime.Width = 90;
            // 
            // colProjectNo
            // 
            this.colProjectNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectNo.ColumnEdit = this.repSearchProjectNo;
            this.colProjectNo.FieldName = "ProjectNo";
            this.colProjectNo.Name = "colProjectNo";
            this.colProjectNo.OptionsColumn.AllowEdit = false;
            this.colProjectNo.OptionsColumn.TabStop = false;
            this.colProjectNo.Visible = true;
            this.colProjectNo.VisibleIndex = 7;
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
            this.repSearchProjectNo.View = this.repSearchProjectNoView;
            // 
            // repSearchProjectNoView
            // 
            this.repSearchProjectNoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnProjectNo,
            this.gridColumnProjectName,
            this.gridColumnRemark});
            this.repSearchProjectNoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchProjectNoView.IndicatorWidth = 60;
            this.repSearchProjectNoView.Name = "repSearchProjectNoView";
            this.repSearchProjectNoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchProjectNoView.OptionsView.ShowGroupPanel = false;
            this.repSearchProjectNoView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewProductionPlan_CustomDrawRowIndicator);
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
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 12;
            this.colRemark.Width = 140;
            // 
            // colCreator
            // 
            this.colCreator.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreator.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreator.ColumnEdit = this.repLookUpCreator;
            this.colCreator.FieldName = "Creator";
            this.colCreator.Name = "colCreator";
            this.colCreator.OptionsColumn.AllowEdit = false;
            this.colCreator.OptionsColumn.TabStop = false;
            this.colCreator.Visible = true;
            this.colCreator.VisibleIndex = 13;
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
            this.colModifier.OptionsColumn.AllowEdit = false;
            this.colModifier.OptionsColumn.TabStop = false;
            this.colModifier.Visible = true;
            this.colModifier.VisibleIndex = 14;
            this.colModifier.Width = 70;
            // 
            // coluCodeFileName
            // 
            this.coluCodeFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.coluCodeFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coluCodeFileName.ColumnEdit = this.repButtonCodeId;
            this.coluCodeFileName.FieldName = "CodeFileName";
            this.coluCodeFileName.Name = "coluCodeFileName";
            this.coluCodeFileName.OptionsColumn.AllowEdit = false;
            this.coluCodeFileName.Visible = true;
            this.coluCodeFileName.VisibleIndex = 3;
            this.coluCodeFileName.Width = 140;
            // 
            // repButtonCodeId
            // 
            this.repButtonCodeId.AutoHeight = false;
            this.repButtonCodeId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repButtonCodeId.Name = "repButtonCodeId";
            this.repButtonCodeId.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repButtonCodeId.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repButtonCodeId_ButtonClick);
            this.repButtonCodeId.Enter += new System.EventHandler(this.repButtonCodeId_Enter);
            // 
            // colLine
            // 
            this.colLine.AppearanceHeader.Options.UseTextOptions = true;
            this.colLine.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLine.ColumnEdit = this.repTextLine;
            this.colLine.FieldName = "Line";
            this.colLine.Name = "colLine";
            this.colLine.OptionsColumn.AllowEdit = false;
            this.colLine.Visible = true;
            this.colLine.VisibleIndex = 8;
            this.colLine.Width = 100;
            // 
            // repTextLine
            // 
            this.repTextLine.AutoHeight = false;
            this.repTextLine.MaxLength = 10;
            this.repTextLine.Name = "repTextLine";
            // 
            // colManufactureNo
            // 
            this.colManufactureNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colManufactureNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colManufactureNo.ColumnEdit = this.repLookUpManufactureNo;
            this.colManufactureNo.FieldName = "ManufactureNo";
            this.colManufactureNo.Name = "colManufactureNo";
            this.colManufactureNo.OptionsColumn.AllowEdit = false;
            this.colManufactureNo.Visible = true;
            this.colManufactureNo.VisibleIndex = 6;
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
            this.colQty.OptionsColumn.AllowEdit = false;
            this.colQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:0.##}")});
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 5;
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
            this.repSpinQty.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repSpinQty_EditValueChanging);
            // 
            // colStartTime
            // 
            this.colStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStartTime.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.OptionsColumn.AllowEdit = false;
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 9;
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
            this.colEndTime.OptionsColumn.AllowEdit = false;
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 10;
            this.colEndTime.Width = 100;
            // 
            // colModifierTime
            // 
            this.colModifierTime.FieldName = "ModifierTime";
            this.colModifierTime.Name = "colModifierTime";
            // 
            // colPlanStatus
            // 
            this.colPlanStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colPlanStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPlanStatus.ColumnEdit = this.repCheckPlanStatus;
            this.colPlanStatus.FieldName = "PlanStatus";
            this.colPlanStatus.Name = "colPlanStatus";
            this.colPlanStatus.OptionsColumn.AllowEdit = false;
            this.colPlanStatus.Visible = true;
            this.colPlanStatus.VisibleIndex = 11;
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
            this.repCheckPlanStatus.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repCheckPlanStatus_EditValueChanging);
            // 
            // colCodeFileName
            // 
            this.colCodeFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeFileName.FieldName = "CodeName";
            this.colCodeFileName.Name = "colCodeFileName";
            this.colCodeFileName.OptionsColumn.AllowEdit = false;
            this.colCodeFileName.OptionsColumn.TabStop = false;
            this.colCodeFileName.Visible = true;
            this.colCodeFileName.VisibleIndex = 4;
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
            // repLookUpApprovalType
            // 
            this.repLookUpApprovalType.AutoHeight = false;
            this.repLookUpApprovalType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpApprovalType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeNo", "审批类型"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeNoText", "审批名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ApprovalText", "审批方式")});
            this.repLookUpApprovalType.DisplayMember = "TypeNoText";
            this.repLookUpApprovalType.Name = "repLookUpApprovalType";
            this.repLookUpApprovalType.NullText = "";
            this.repLookUpApprovalType.ValueMember = "TypeNo";
            // 
            // pnlMiddleTop
            // 
            this.pnlMiddleTop.Controls.Add(this.btnCancelSubmit);
            this.pnlMiddleTop.Controls.Add(this.btnSubmit);
            this.pnlMiddleTop.Controls.Add(this.btnPreview);
            this.pnlMiddleTop.Controls.Add(this.btnCancelApprove);
            this.pnlMiddleTop.Controls.Add(this.btnApprove);
            this.pnlMiddleTop.Controls.Add(this.btnDelete);
            this.pnlMiddleTop.Controls.Add(this.btnCancel);
            this.pnlMiddleTop.Controls.Add(this.btnSave);
            this.pnlMiddleTop.Controls.Add(this.btnNew);
            this.pnlMiddleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddleTop.Location = new System.Drawing.Point(2, 2);
            this.pnlMiddleTop.Name = "pnlMiddleTop";
            this.pnlMiddleTop.Size = new System.Drawing.Size(1300, 34);
            this.pnlMiddleTop.TabIndex = 2;
            // 
            // btnCancelSubmit
            // 
            this.btnCancelSubmit.Location = new System.Drawing.Point(410, 5);
            this.btnCancelSubmit.Name = "btnCancelSubmit";
            this.btnCancelSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSubmit.TabIndex = 22;
            this.btnCancelSubmit.TabStop = false;
            this.btnCancelSubmit.Text = "取消提交";
            this.btnCancelSubmit.Click += new System.EventHandler(this.btnCancelSubmit_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(329, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 21;
            this.btnSubmit.TabStop = false;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(653, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 20;
            this.btnPreview.TabStop = false;
            this.btnPreview.Text = "预览";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCancelApprove
            // 
            this.btnCancelApprove.Location = new System.Drawing.Point(572, 5);
            this.btnCancelApprove.Name = "btnCancelApprove";
            this.btnCancelApprove.Size = new System.Drawing.Size(75, 23);
            this.btnCancelApprove.TabIndex = 17;
            this.btnCancelApprove.TabStop = false;
            this.btnCancelApprove.Text = "取消审批";
            this.btnCancelApprove.Click += new System.EventHandler(this.btnCancelApprove_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(491, 5);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 23);
            this.btnApprove.TabIndex = 16;
            this.btnApprove.TabStop = false;
            this.btnApprove.Text = "审批";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(248, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(167, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(86, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "修改";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(5, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 10;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.treeListDesignBom);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 311);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1304, 290);
            this.pnlBottom.TabIndex = 3;
            // 
            // treeListDesignBom
            // 
            this.treeListDesignBom.AllowDrop = true;
            this.treeListDesignBom.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.columnAutoId,
            this.columnParentId,
            this.columnPlanNo,
            this.columnLevelCodeId,
            this.colCodeName1,
            this.colHasLevel,
            this.columnIsAll,
            this.colIsBuy,
            this.colUnitQty,
            this.colPlanQty,
            this.columnQty,
            this.columnAfterFlag,
            this.columnCodeId,
            this.columnDesignBomListId});
            this.treeListDesignBom.DataSource = this.bindingSource_ProductionPlanList;
            this.treeListDesignBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDesignBom.IndicatorWidth = 40;
            this.treeListDesignBom.KeyFieldName = "AutoId";
            this.treeListDesignBom.Location = new System.Drawing.Point(2, 2);
            this.treeListDesignBom.Name = "treeListDesignBom";
            this.treeListDesignBom.OptionsView.AutoWidth = false;
            this.treeListDesignBom.OptionsView.ShowHorzLines = false;
            this.treeListDesignBom.OptionsView.ShowSummaryFooter = true;
            this.treeListDesignBom.OptionsView.ShowVertLines = false;
            this.treeListDesignBom.ParentFieldName = "ParentId";
            this.treeListDesignBom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSpinRemainQty,
            this.repLookUpCodeId,
            this.repLookUpCodeName});
            this.treeListDesignBom.RowHeight = 21;
            this.treeListDesignBom.Size = new System.Drawing.Size(1300, 286);
            this.treeListDesignBom.TabIndex = 2;
            this.treeListDesignBom.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.treeListDesignBom_CustomDrawNodeIndicator);
            // 
            // columnAutoId
            // 
            this.columnAutoId.FieldName = "AutoId";
            this.columnAutoId.Name = "columnAutoId";
            // 
            // columnParentId
            // 
            this.columnParentId.FieldName = "ParentId";
            this.columnParentId.Name = "columnParentId";
            this.columnParentId.Width = 30;
            // 
            // columnPlanNo
            // 
            this.columnPlanNo.FieldName = "PlanNo";
            this.columnPlanNo.Name = "columnPlanNo";
            this.columnPlanNo.Width = 31;
            // 
            // columnLevelCodeId
            // 
            this.columnLevelCodeId.AppearanceHeader.Options.UseTextOptions = true;
            this.columnLevelCodeId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnLevelCodeId.Caption = "零件编号";
            this.columnLevelCodeId.ColumnEdit = this.repLookUpCodeId;
            this.columnLevelCodeId.FieldName = "LevelCodeId";
            this.columnLevelCodeId.MinWidth = 32;
            this.columnLevelCodeId.Name = "columnLevelCodeId";
            this.columnLevelCodeId.OptionsColumn.AllowEdit = false;
            this.columnLevelCodeId.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count;
            this.columnLevelCodeId.SummaryFooterStrFormat = "共计{0}条";
            this.columnLevelCodeId.Visible = true;
            this.columnLevelCodeId.VisibleIndex = 0;
            this.columnLevelCodeId.Width = 250;
            // 
            // repLookUpCodeId
            // 
            this.repLookUpCodeId.AutoHeight = false;
            this.repLookUpCodeId.DisplayMember = "CodeFileName";
            this.repLookUpCodeId.Name = "repLookUpCodeId";
            this.repLookUpCodeId.NullText = "";
            this.repLookUpCodeId.ValueMember = "AutoId";
            // 
            // colCodeName1
            // 
            this.colCodeName1.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeName1.Caption = "零件名称";
            this.colCodeName1.ColumnEdit = this.repLookUpCodeName;
            this.colCodeName1.FieldName = "CodeName";
            this.colCodeName1.Name = "colCodeName1";
            this.colCodeName1.OptionsColumn.AllowEdit = false;
            this.colCodeName1.Visible = true;
            this.colCodeName1.VisibleIndex = 1;
            this.colCodeName1.Width = 120;
            // 
            // repLookUpCodeName
            // 
            this.repLookUpCodeName.AutoHeight = false;
            this.repLookUpCodeName.DisplayMember = "CodeName";
            this.repLookUpCodeName.Name = "repLookUpCodeName";
            this.repLookUpCodeName.ValueMember = "AutoId";
            // 
            // colHasLevel
            // 
            this.colHasLevel.AppearanceHeader.Options.UseTextOptions = true;
            this.colHasLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHasLevel.Caption = "类型";
            this.colHasLevel.FieldName = "HasLevel";
            this.colHasLevel.Name = "colHasLevel";
            this.colHasLevel.OptionsColumn.AllowEdit = false;
            this.colHasLevel.Width = 40;
            // 
            // columnIsAll
            // 
            this.columnIsAll.AppearanceHeader.Options.UseTextOptions = true;
            this.columnIsAll.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnIsAll.Caption = "使用";
            this.columnIsAll.FieldName = "IsAll";
            this.columnIsAll.Name = "columnIsAll";
            this.columnIsAll.OptionsColumn.AllowEdit = false;
            this.columnIsAll.Width = 40;
            // 
            // colIsBuy
            // 
            this.colIsBuy.FieldName = "IsBuy";
            this.colIsBuy.Name = "colIsBuy";
            // 
            // colUnitQty
            // 
            this.colUnitQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnitQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnitQty.Caption = "单位数量";
            this.colUnitQty.FieldName = "UnitQty";
            this.colUnitQty.Name = "colUnitQty";
            this.colUnitQty.OptionsColumn.AllowEdit = false;
            this.colUnitQty.Visible = true;
            this.colUnitQty.VisibleIndex = 2;
            this.colUnitQty.Width = 90;
            // 
            // colPlanQty
            // 
            this.colPlanQty.Caption = "计划数量";
            this.colPlanQty.FieldName = "PlanQty";
            this.colPlanQty.Name = "colPlanQty";
            // 
            // columnQty
            // 
            this.columnQty.AppearanceHeader.Options.UseTextOptions = true;
            this.columnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnQty.Caption = "数量";
            this.columnQty.ColumnEdit = this.repSpinRemainQty;
            this.columnQty.FieldName = "Qty";
            this.columnQty.Name = "columnQty";
            this.columnQty.OptionsColumn.AllowEdit = false;
            this.columnQty.Visible = true;
            this.columnQty.VisibleIndex = 3;
            this.columnQty.Width = 90;
            // 
            // repSpinRemainQty
            // 
            this.repSpinRemainQty.AutoHeight = false;
            this.repSpinRemainQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinRemainQty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinRemainQty.Name = "repSpinRemainQty";
            this.repSpinRemainQty.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repSpinRemainQty_EditValueChanging);
            // 
            // columnAfterFlag
            // 
            this.columnAfterFlag.AppearanceHeader.Options.UseTextOptions = true;
            this.columnAfterFlag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnAfterFlag.ColumnEdit = this.repCheckEditIsUse;
            this.columnAfterFlag.FieldName = "AfterFlag";
            this.columnAfterFlag.Name = "columnAfterFlag";
            this.columnAfterFlag.OptionsColumn.AllowEdit = false;
            this.columnAfterFlag.Width = 60;
            // 
            // columnCodeId
            // 
            this.columnCodeId.AppearanceHeader.Options.UseTextOptions = true;
            this.columnCodeId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnCodeId.ColumnEdit = this.repCheckEditIsUse;
            this.columnCodeId.FieldName = "CodeId";
            this.columnCodeId.Name = "columnCodeId";
            this.columnCodeId.OptionsColumn.AllowEdit = false;
            this.columnCodeId.Width = 60;
            // 
            // columnDesignBomListId
            // 
            this.columnDesignBomListId.FieldName = "DesignBomListId";
            this.columnDesignBomListId.Name = "columnDesignBomListId";
            // 
            // bindingSource_ProductionPlanList
            // 
            this.bindingSource_ProductionPlanList.DataMember = "ProductionPlanList";
            this.bindingSource_ProductionPlanList.DataSource = this.dataSet_ProductionPlan;
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlRight.Controls.Add(this.pnlBottom);
            this.pnlRight.Controls.Add(this.splitterControl1);
            this.pnlRight.Controls.Add(this.pnlMiddle);
            this.pnlRight.Controls.Add(this.pnltop);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(1304, 601);
            this.pnlRight.TabIndex = 6;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 306);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(1304, 5);
            this.splitterControl1.TabIndex = 6;
            this.splitterControl1.TabStop = false;
            // 
            // FrmProductionPlan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1304, 601);
            this.Controls.Add(this.pnlRight);
            this.Name = "FrmProductionPlan";
            this.TabText = "工单";
            this.Text = "工单";
            this.Activated += new System.EventHandler(this.FrmProductionPlan_Activated);
            this.Load += new System.EventHandler(this.FrmProductionPlan_Load);
            this.Shown += new System.EventHandler(this.FrmProductionPlan_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditIsUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_ProductionPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableProductionPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableProductionPlanList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_ProductionPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpManufactureNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileNameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpApprover.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCurrentStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCreator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanDateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductionPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductionPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProjectNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProjectNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repButtonCodeId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTextLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpManufactureNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckPlanStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddleTop)).EndInit();
            this.pnlMiddleTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCodeId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinRemainQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_ProductionPlanList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).EndInit();
            this.pnlRight.ResumeLayout(false);
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
        private System.Windows.Forms.BindingSource bindingSource_ProductionPlan;
        private DevExpress.XtraEditors.PanelControl pnltop;
        private DevExpress.XtraEditors.LookUpEdit lookUpApprover;
        private DevExpress.XtraEditors.TextEdit textCommon;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxCurrentStatus;
        private DevExpress.XtraEditors.LookUpEdit lookUpCreator;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.DateEdit datePlanDateEnd;
        private DevExpress.XtraEditors.LabelControl lab;
        private DevExpress.XtraEditors.DateEdit datePlanDateBegin;
        private DevExpress.XtraEditors.LabelControl labApprover;
        private DevExpress.XtraEditors.LabelControl labCommon;
        private DevExpress.XtraEditors.LabelControl labCreator;
        private DevExpress.XtraEditors.LabelControl labCurrentStatus;
        private DevExpress.XtraEditors.LabelControl labManufactureNo;
        private DevExpress.XtraEditors.LabelControl labPlanDate;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpCodeFileName;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpCodeFileNameView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuCodeName;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpProjectNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpProjectNoView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProjectNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private DevExpress.XtraEditors.LabelControl labCodeFileName;
        private DevExpress.XtraEditors.LabelControl labProjectNo;
        private DevExpress.XtraEditors.LookUpEdit lookUpManufactureNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuAutoId;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraEditors.PanelControl pnlMiddleTop;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnCancelApprove;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraGrid.GridControl gridControlProductionPlan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductionPlan;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentdatetime;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchProjectNo;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchProjectNoView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProjectNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpApprovalType;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colModifier;
        private System.Data.DataColumn dataColSelect;
        private DevExpress.XtraEditors.CheckEdit checkAll;
        private DevExpress.XtraGrid.Columns.GridColumn coluCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.Columns.GridColumn colManufactureNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpManufactureNo;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinQty;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colModifierTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanStatus;
        private DevExpress.XtraEditors.SimpleButton btnCancelSubmit;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repTextLine;
        private System.Data.DataTable dataTableProductionPlanList;
        private System.Data.DataColumn dataColuAutoId;
        private System.Data.DataColumn dataColuPlanNo;
        private System.Data.DataColumn dataColuCodeId;
        private System.Data.DataColumn dataColuUnitQty;
        private System.Data.DataColumn dataColuPlanQty;
        private System.Data.DataColumn dataColuQty;
        private System.Data.DataColumn dataColuAfterFlag;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckPlanStatus;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.PanelControl pnlRight;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private System.Windows.Forms.BindingSource bindingSource_ProductionPlanList;
        private System.Data.DataColumn dataColuCodeName;
        private System.Data.DataColumn dataColDesignBomListId;
        private System.Data.DataColumn dataColuLevelCodeId;
        private System.Data.DataColumn dataColuParentId;
        private System.Data.DataColumn dataColuHasLevel;
        private System.Data.DataColumn dataColuIsAll;
        private System.Data.DataColumn dataColuIsBuy;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repButtonCodeId;
        private System.Data.DataColumn dataColCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignBomListId;
        private System.Data.DataColumn dataColuDesignBomListId;
        public DevExpress.XtraTreeList.TreeList treeListDesignBom;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnParentId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnPlanNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnLevelCodeId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeName1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHasLevel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnIsAll;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinRemainQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnAutoId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnAfterFlag;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnCodeId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsBuy;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUnitQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPlanQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnDesignBomListId;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckEditIsUse;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCodeId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCodeName;
        private System.Data.DataColumn dataColuDesignBomListParentId;
        private System.Data.DataColumn dataColCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeId;
    }
}