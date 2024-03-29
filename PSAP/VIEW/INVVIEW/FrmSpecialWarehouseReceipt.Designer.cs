﻿namespace PSAP.VIEW.BSVIEW
{
    partial class FrmSpecialWarehouseReceipt
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
            this.dataSet_SWR = new System.Data.DataSet();
            this.dataTableSWRHead = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColSpecialWarehouseReceipt = new System.Data.DataColumn();
            this.dataColSpecialWarehouseReceiptDate = new System.Data.DataColumn();
            this.dataColReqDep = new System.Data.DataColumn();
            this.dataColRepertoryId = new System.Data.DataColumn();
            this.dataColApprovalType = new System.Data.DataColumn();
            this.dataColPreparedIp = new System.Data.DataColumn();
            this.dataColModifierIp = new System.Data.DataColumn();
            this.dataColModifierTime = new System.Data.DataColumn();
            this.dataColRemark = new System.Data.DataColumn();
            this.dataColSelect = new System.Data.DataColumn();
            this.dataColWarehouseState = new System.Data.DataColumn();
            this.dataColRepertoryLocationId = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColModifierId = new System.Data.DataColumn();
            this.dataTableSWRList = new System.Data.DataTable();
            this.dataColumnAutoId = new System.Data.DataColumn();
            this.dataColumnSpecialWarehouseReceipt = new System.Data.DataColumn();
            this.dataColCodeFileName = new System.Data.DataColumn();
            this.dataColQty = new System.Data.DataColumn();
            this.dataColProjectName = new System.Data.DataColumn();
            this.dataColStnNo = new System.Data.DataColumn();
            this.dataColumnRemark = new System.Data.DataColumn();
            this.dataColCodeName = new System.Data.DataColumn();
            this.dataColShelfId = new System.Data.DataColumn();
            this.dataColumnProjectNo = new System.Data.DataColumn();
            this.dataColCodeId = new System.Data.DataColumn();
            this.bindingSource_SWRHead = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource_SWRList = new System.Windows.Forms.BindingSource(this.components);
            this.pnlRight = new DevExpress.XtraEditors.PanelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnListAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlSWRList = new DevExpress.XtraGrid.GridControl();
            this.gridViewSWRList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnWarehouseReceipt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchCodeFileName = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchCodeFileNameView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSpinQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colShelfId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchShelfId = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchShelfIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchProjectNo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchProjectNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repComboBoxStnNo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repbtnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.checkAll = new DevExpress.XtraEditors.CheckEdit();
            this.gridControlSWRHead = new DevExpress.XtraGrid.GridControl();
            this.gridViewSWRHead = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colWarehouseWarrant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReqDep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpReqDep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colWarehouseWarrantDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepertoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colApprovalType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpApprovalType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRemark1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModifierId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepertoryLocationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchRepertoryLocationId = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchRepertoryLocationIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlMiddleTop = new DevExpress.XtraEditors.PanelControl();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.pnltop = new DevExpress.XtraEditors.PanelControl();
            this.searchLookUpApprover = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.searchLookUpCreator = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpCreatorView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labLocationId = new DevExpress.XtraEditors.LabelControl();
            this.SearchLocationId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.SearchLocationIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lookUpReqDep = new DevExpress.XtraEditors.LookUpEdit();
            this.comboBoxWarehouseState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lookUpRepertoryId = new DevExpress.XtraEditors.LookUpEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.textCommon = new DevExpress.XtraEditors.TextEdit();
            this.dateSWRDateEnd = new DevExpress.XtraEditors.DateEdit();
            this.lab1 = new DevExpress.XtraEditors.LabelControl();
            this.dateSWRDateBegin = new DevExpress.XtraEditors.DateEdit();
            this.labReqDep = new DevExpress.XtraEditors.LabelControl();
            this.labRepertoryId = new DevExpress.XtraEditors.LabelControl();
            this.labApprover = new DevExpress.XtraEditors.LabelControl();
            this.labCommon = new DevExpress.XtraEditors.LabelControl();
            this.labCreator = new DevExpress.XtraEditors.LabelControl();
            this.labWarehouseState = new DevExpress.XtraEditors.LabelControl();
            this.labSWRDate = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_SWR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSWRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSWRList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SWRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SWRList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSWRList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSWRList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchCodeFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchCodeFileNameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchShelfId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchShelfIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProjectNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProjectNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repComboBoxStnNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repbtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSWRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSWRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchRepertoryLocationId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchRepertoryLocationIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddleTop)).BeginInit();
            this.pnlMiddleTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpApprover.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreatorView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxWarehouseState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSWRDateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSWRDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSWRDateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSWRDateBegin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet_SWR
            // 
            this.dataSet_SWR.DataSetName = "NewDataSet";
            this.dataSet_SWR.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableSWRHead,
            this.dataTableSWRList});
            // 
            // dataTableSWRHead
            // 
            this.dataTableSWRHead.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColSpecialWarehouseReceipt,
            this.dataColSpecialWarehouseReceiptDate,
            this.dataColReqDep,
            this.dataColRepertoryId,
            this.dataColApprovalType,
            this.dataColPreparedIp,
            this.dataColModifierIp,
            this.dataColModifierTime,
            this.dataColRemark,
            this.dataColSelect,
            this.dataColWarehouseState,
            this.dataColRepertoryLocationId,
            this.dataColCreator,
            this.dataColModifierId});
            this.dataTableSWRHead.TableName = "SWRHead";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColSpecialWarehouseReceipt
            // 
            this.dataColSpecialWarehouseReceipt.Caption = "预算外出库单号";
            this.dataColSpecialWarehouseReceipt.ColumnName = "SpecialWarehouseReceipt";
            // 
            // dataColSpecialWarehouseReceiptDate
            // 
            this.dataColSpecialWarehouseReceiptDate.Caption = "出库日期";
            this.dataColSpecialWarehouseReceiptDate.ColumnName = "SpecialWarehouseReceiptDate";
            this.dataColSpecialWarehouseReceiptDate.DataType = typeof(System.DateTime);
            // 
            // dataColReqDep
            // 
            this.dataColReqDep.Caption = "出库部门";
            this.dataColReqDep.ColumnName = "ReqDep";
            // 
            // dataColRepertoryId
            // 
            this.dataColRepertoryId.Caption = "出库仓库";
            this.dataColRepertoryId.ColumnName = "RepertoryId";
            this.dataColRepertoryId.DataType = typeof(int);
            // 
            // dataColApprovalType
            // 
            this.dataColApprovalType.Caption = "审批类型";
            this.dataColApprovalType.ColumnName = "ApprovalType";
            // 
            // dataColPreparedIp
            // 
            this.dataColPreparedIp.Caption = "制单人IP";
            this.dataColPreparedIp.ColumnName = "PreparedIp";
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
            // dataColWarehouseState
            // 
            this.dataColWarehouseState.Caption = "状态";
            this.dataColWarehouseState.ColumnName = "WarehouseState";
            this.dataColWarehouseState.DataType = typeof(int);
            // 
            // dataColRepertoryLocationId
            // 
            this.dataColRepertoryLocationId.Caption = "出库仓位";
            this.dataColRepertoryLocationId.ColumnName = "RepertoryLocationId";
            this.dataColRepertoryLocationId.DataType = typeof(int);
            // 
            // dataColCreator
            // 
            this.dataColCreator.Caption = "制单人";
            this.dataColCreator.ColumnName = "Creator";
            this.dataColCreator.DataType = typeof(int);
            // 
            // dataColModifierId
            // 
            this.dataColModifierId.Caption = "修改人";
            this.dataColModifierId.ColumnName = "ModifierId";
            this.dataColModifierId.DataType = typeof(int);
            // 
            // dataTableSWRList
            // 
            this.dataTableSWRList.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnAutoId,
            this.dataColumnSpecialWarehouseReceipt,
            this.dataColCodeFileName,
            this.dataColQty,
            this.dataColProjectName,
            this.dataColStnNo,
            this.dataColumnRemark,
            this.dataColCodeName,
            this.dataColShelfId,
            this.dataColumnProjectNo,
            this.dataColCodeId});
            this.dataTableSWRList.TableName = "SWRList";
            // 
            // dataColumnAutoId
            // 
            this.dataColumnAutoId.ColumnName = "AutoId";
            this.dataColumnAutoId.DataType = typeof(int);
            // 
            // dataColumnSpecialWarehouseReceipt
            // 
            this.dataColumnSpecialWarehouseReceipt.Caption = "预算外出库单号";
            this.dataColumnSpecialWarehouseReceipt.ColumnName = "SpecialWarehouseReceipt";
            // 
            // dataColCodeFileName
            // 
            this.dataColCodeFileName.Caption = "零件编号";
            this.dataColCodeFileName.ColumnName = "CodeFileName";
            // 
            // dataColQty
            // 
            this.dataColQty.Caption = "出库数量";
            this.dataColQty.ColumnName = "Qty";
            this.dataColQty.DataType = typeof(double);
            // 
            // dataColProjectName
            // 
            this.dataColProjectName.Caption = "项目号";
            this.dataColProjectName.ColumnName = "ProjectName";
            // 
            // dataColStnNo
            // 
            this.dataColStnNo.Caption = "站号";
            this.dataColStnNo.ColumnName = "StnNo";
            // 
            // dataColumnRemark
            // 
            this.dataColumnRemark.Caption = "备注";
            this.dataColumnRemark.ColumnName = "Remark";
            // 
            // dataColCodeName
            // 
            this.dataColCodeName.Caption = "零件名称";
            this.dataColCodeName.ColumnName = "CodeName";
            // 
            // dataColShelfId
            // 
            this.dataColShelfId.Caption = "货架号";
            this.dataColShelfId.ColumnName = "ShelfId";
            this.dataColShelfId.DataType = typeof(int);
            // 
            // dataColumnProjectNo
            // 
            this.dataColumnProjectNo.Caption = "项目编号";
            this.dataColumnProjectNo.ColumnName = "ProjectNo";
            // 
            // dataColCodeId
            // 
            this.dataColCodeId.Caption = "零件Id";
            this.dataColCodeId.ColumnName = "CodeId";
            this.dataColCodeId.DataType = typeof(int);
            // 
            // bindingSource_SWRHead
            // 
            this.bindingSource_SWRHead.DataMember = "SWRHead";
            this.bindingSource_SWRHead.DataSource = this.dataSet_SWR;
            // 
            // bindingSource_SWRList
            // 
            this.bindingSource_SWRList.DataMember = "SWRList";
            this.bindingSource_SWRList.DataSource = this.dataSet_SWR;
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
            this.pnlRight.Size = new System.Drawing.Size(1264, 681);
            this.pnlRight.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnListAdd);
            this.pnlBottom.Controls.Add(this.gridControlSWRList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 322);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1264, 359);
            this.pnlBottom.TabIndex = 10;
            // 
            // btnListAdd
            // 
            this.btnListAdd.Enabled = false;
            this.btnListAdd.Location = new System.Drawing.Point(2, 2);
            this.btnListAdd.Name = "btnListAdd";
            this.btnListAdd.Size = new System.Drawing.Size(40, 21);
            this.btnListAdd.TabIndex = 7;
            this.btnListAdd.Text = "+";
            this.btnListAdd.Click += new System.EventHandler(this.btnListAdd_Click);
            // 
            // gridControlSWRList
            // 
            this.gridControlSWRList.AllowDrop = true;
            this.gridControlSWRList.DataSource = this.bindingSource_SWRList;
            this.gridControlSWRList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSWRList.Location = new System.Drawing.Point(2, 2);
            this.gridControlSWRList.MainView = this.gridViewSWRList;
            this.gridControlSWRList.Name = "gridControlSWRList";
            this.gridControlSWRList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSpinQty,
            this.repSearchCodeFileName,
            this.repbtnDelete,
            this.repSearchShelfId,
            this.repComboBoxStnNo,
            this.repSearchProjectNo});
            this.gridControlSWRList.Size = new System.Drawing.Size(1260, 355);
            this.gridControlSWRList.TabIndex = 29;
            this.gridControlSWRList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSWRList});
            // 
            // gridViewSWRList
            // 
            this.gridViewSWRList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId1,
            this.columnWarehouseReceipt,
            this.colCodeFileName,
            this.colCodeName,
            this.colQty,
            this.colShelfId,
            this.colRemark,
            this.colProjectName,
            this.colStnNo,
            this.colDelete,
            this.colProjectNo,
            this.colCodeId});
            this.gridViewSWRList.GridControl = this.gridControlSWRList;
            this.gridViewSWRList.IndicatorWidth = 40;
            this.gridViewSWRList.Name = "gridViewSWRList";
            this.gridViewSWRList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewSWRList.OptionsMenu.EnableColumnMenu = false;
            this.gridViewSWRList.OptionsMenu.EnableFooterMenu = false;
            this.gridViewSWRList.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewSWRList.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewSWRList.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewSWRList.OptionsView.ColumnAutoWidth = false;
            this.gridViewSWRList.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewSWRList.OptionsView.ShowFooter = true;
            this.gridViewSWRList.OptionsView.ShowGroupPanel = false;
            this.gridViewSWRList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewSWRHead_CustomDrawRowIndicator);
            this.gridViewSWRList.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewSWRList_InitNewRow);
            this.gridViewSWRList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewSWRList_FocusedRowChanged);
            this.gridViewSWRList.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewSWRList_CellValueChanged);
            this.gridViewSWRList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewSWRList_KeyDown);
            // 
            // colAutoId1
            // 
            this.colAutoId1.FieldName = "AutoId";
            this.colAutoId1.Name = "colAutoId1";
            // 
            // columnWarehouseReceipt
            // 
            this.columnWarehouseReceipt.AppearanceHeader.Options.UseTextOptions = true;
            this.columnWarehouseReceipt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnWarehouseReceipt.FieldName = "SpecialWarehouseReceipt";
            this.columnWarehouseReceipt.Name = "columnWarehouseReceipt";
            this.columnWarehouseReceipt.OptionsColumn.AllowEdit = false;
            this.columnWarehouseReceipt.OptionsColumn.TabStop = false;
            this.columnWarehouseReceipt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "WarehouseWarrant", "共计{0}条")});
            this.columnWarehouseReceipt.Visible = true;
            this.columnWarehouseReceipt.VisibleIndex = 0;
            this.columnWarehouseReceipt.Width = 110;
            // 
            // colCodeFileName
            // 
            this.colCodeFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeFileName.ColumnEdit = this.repSearchCodeFileName;
            this.colCodeFileName.FieldName = "CodeFileName";
            this.colCodeFileName.Name = "colCodeFileName";
            this.colCodeFileName.OptionsColumn.AllowEdit = false;
            this.colCodeFileName.Visible = true;
            this.colCodeFileName.VisibleIndex = 1;
            this.colCodeFileName.Width = 120;
            // 
            // repSearchCodeFileName
            // 
            this.repSearchCodeFileName.AutoHeight = false;
            this.repSearchCodeFileName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearchCodeFileName.Name = "repSearchCodeFileName";
            this.repSearchCodeFileName.View = this.repSearchCodeFileNameView;
            // 
            // repSearchCodeFileNameView
            // 
            this.repSearchCodeFileNameView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchCodeFileNameView.Name = "repSearchCodeFileNameView";
            this.repSearchCodeFileNameView.OptionsBehavior.Editable = false;
            this.repSearchCodeFileNameView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchCodeFileNameView.OptionsView.ShowGroupPanel = false;
            // 
            // colCodeName
            // 
            this.colCodeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeName.FieldName = "CodeName";
            this.colCodeName.Name = "colCodeName";
            this.colCodeName.OptionsColumn.AllowEdit = false;
            this.colCodeName.OptionsColumn.TabStop = false;
            this.colCodeName.Visible = true;
            this.colCodeName.VisibleIndex = 2;
            this.colCodeName.Width = 120;
            // 
            // colQty
            // 
            this.colQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQty.ColumnEdit = this.repSpinQty;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.OptionsColumn.AllowEdit = false;
            this.colQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:0.##}")});
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 4;
            this.colQty.Width = 80;
            // 
            // repSpinQty
            // 
            this.repSpinQty.AutoHeight = false;
            this.repSpinQty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpinQty.DisplayFormat.FormatString = "d";
            this.repSpinQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinQty.EditFormat.FormatString = "d";
            this.repSpinQty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinQty.MaxValue = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.repSpinQty.Name = "repSpinQty";
            // 
            // colShelfId
            // 
            this.colShelfId.AppearanceHeader.Options.UseTextOptions = true;
            this.colShelfId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShelfId.ColumnEdit = this.repSearchShelfId;
            this.colShelfId.FieldName = "ShelfId";
            this.colShelfId.Name = "colShelfId";
            this.colShelfId.OptionsColumn.AllowEdit = false;
            this.colShelfId.Visible = true;
            this.colShelfId.VisibleIndex = 3;
            this.colShelfId.Width = 100;
            // 
            // repSearchShelfId
            // 
            this.repSearchShelfId.AutoHeight = false;
            this.repSearchShelfId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearchShelfId.Name = "repSearchShelfId";
            this.repSearchShelfId.View = this.repSearchShelfIdView;
            this.repSearchShelfId.Popup += new System.EventHandler(this.repSearchShelfId_Popup);
            // 
            // repSearchShelfIdView
            // 
            this.repSearchShelfIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchShelfIdView.Name = "repSearchShelfIdView";
            this.repSearchShelfIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchShelfIdView.OptionsView.ShowGroupPanel = false;
            // 
            // colRemark
            // 
            this.colRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 7;
            this.colRemark.Width = 120;
            // 
            // colProjectName
            // 
            this.colProjectName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectName.ColumnEdit = this.repSearchProjectNo;
            this.colProjectName.FieldName = "ProjectName";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.OptionsColumn.AllowEdit = false;
            this.colProjectName.Visible = true;
            this.colProjectName.VisibleIndex = 5;
            this.colProjectName.Width = 120;
            // 
            // repSearchProjectNo
            // 
            this.repSearchProjectNo.AutoHeight = false;
            this.repSearchProjectNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearchProjectNo.Name = "repSearchProjectNo";
            this.repSearchProjectNo.View = this.repSearchProjectNoView;
            // 
            // repSearchProjectNoView
            // 
            this.repSearchProjectNoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchProjectNoView.Name = "repSearchProjectNoView";
            this.repSearchProjectNoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchProjectNoView.OptionsView.ShowGroupPanel = false;
            // 
            // colStnNo
            // 
            this.colStnNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colStnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStnNo.ColumnEdit = this.repComboBoxStnNo;
            this.colStnNo.FieldName = "StnNo";
            this.colStnNo.Name = "colStnNo";
            this.colStnNo.OptionsColumn.AllowEdit = false;
            this.colStnNo.Visible = true;
            this.colStnNo.VisibleIndex = 6;
            this.colStnNo.Width = 100;
            // 
            // repComboBoxStnNo
            // 
            this.repComboBoxStnNo.AutoHeight = false;
            this.repComboBoxStnNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repComboBoxStnNo.DropDownRows = 10;
            this.repComboBoxStnNo.ImmediatePopup = true;
            this.repComboBoxStnNo.Name = "repComboBoxStnNo";
            // 
            // colDelete
            // 
            this.colDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.colDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDelete.ColumnEdit = this.repbtnDelete;
            this.colDelete.Name = "colDelete";
            this.colDelete.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 8;
            this.colDelete.Width = 27;
            // 
            // repbtnDelete
            // 
            this.repbtnDelete.AutoHeight = false;
            this.repbtnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repbtnDelete.Name = "repbtnDelete";
            this.repbtnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repbtnDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repbtnDelete_ButtonClick);
            // 
            // colProjectNo
            // 
            this.colProjectNo.FieldName = "ProjectNo";
            this.colProjectNo.Name = "colProjectNo";
            // 
            // colCodeId
            // 
            this.colCodeId.FieldName = "CodeId";
            this.colCodeId.Name = "colCodeId";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 317);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(4);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(1264, 5);
            this.splitterControl1.TabIndex = 9;
            this.splitterControl1.TabStop = false;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.checkAll);
            this.pnlMiddle.Controls.Add(this.gridControlSWRHead);
            this.pnlMiddle.Controls.Add(this.pnlMiddleTop);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 78);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1264, 239);
            this.pnlMiddle.TabIndex = 3;
            // 
            // checkAll
            // 
            this.checkAll.Location = new System.Drawing.Point(53, 40);
            this.checkAll.Margin = new System.Windows.Forms.Padding(4);
            this.checkAll.Name = "checkAll";
            this.checkAll.Properties.AutoHeight = false;
            this.checkAll.Properties.Caption = "";
            this.checkAll.Size = new System.Drawing.Size(16, 15);
            this.checkAll.TabIndex = 20;
            this.checkAll.TabStop = false;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // gridControlSWRHead
            // 
            this.gridControlSWRHead.DataSource = this.bindingSource_SWRHead;
            this.gridControlSWRHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSWRHead.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlSWRHead.Location = new System.Drawing.Point(2, 36);
            this.gridControlSWRHead.MainView = this.gridViewSWRHead;
            this.gridControlSWRHead.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlSWRHead.Name = "gridControlSWRHead";
            this.gridControlSWRHead.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpRepertoryId,
            this.repCheckSelect,
            this.repLookUpApprovalType,
            this.repLookUpReqDep,
            this.repSearchRepertoryLocationId,
            this.repLookUpCreator});
            this.gridControlSWRHead.Size = new System.Drawing.Size(1260, 201);
            this.gridControlSWRHead.TabIndex = 6;
            this.gridControlSWRHead.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSWRHead});
            // 
            // gridViewSWRHead
            // 
            this.gridViewSWRHead.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colSelect,
            this.colWarehouseWarrant,
            this.colWarehouseState,
            this.colReqDep,
            this.colWarehouseWarrantDate,
            this.colRepertoryId,
            this.colApprovalType,
            this.colRemark1,
            this.colCreator,
            this.colModifierId,
            this.colRepertoryLocationId});
            this.gridViewSWRHead.GridControl = this.gridControlSWRHead;
            this.gridViewSWRHead.IndicatorWidth = 40;
            this.gridViewSWRHead.Name = "gridViewSWRHead";
            this.gridViewSWRHead.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewSWRHead.OptionsMenu.EnableColumnMenu = false;
            this.gridViewSWRHead.OptionsMenu.EnableFooterMenu = false;
            this.gridViewSWRHead.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewSWRHead.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewSWRHead.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewSWRHead.OptionsView.ColumnAutoWidth = false;
            this.gridViewSWRHead.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewSWRHead.OptionsView.ShowFooter = true;
            this.gridViewSWRHead.OptionsView.ShowGroupPanel = false;
            this.gridViewSWRHead.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewSWRHead_CustomDrawRowIndicator);
            this.gridViewSWRHead.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewSWRHead_InitNewRow);
            this.gridViewSWRHead.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewSWRHead_FocusedRowChanged);
            this.gridViewSWRHead.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewSWRHead_CellValueChanged);
            this.gridViewSWRHead.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewSWRHead_CustomColumnDisplayText);
            this.gridViewSWRHead.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewSWRHead_KeyDown);
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colSelect
            // 
            this.colSelect.ColumnEdit = this.repCheckSelect;
            this.colSelect.FieldName = "Select";
            this.colSelect.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colSelect.Name = "colSelect";
            this.colSelect.Visible = true;
            this.colSelect.VisibleIndex = 0;
            this.colSelect.Width = 35;
            // 
            // repCheckSelect
            // 
            this.repCheckSelect.AutoHeight = false;
            this.repCheckSelect.Name = "repCheckSelect";
            this.repCheckSelect.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckSelect.ValueGrayed = false;
            this.repCheckSelect.EditValueChanged += new System.EventHandler(this.repCheckSelect_EditValueChanged);
            // 
            // colWarehouseWarrant
            // 
            this.colWarehouseWarrant.AppearanceHeader.Options.UseTextOptions = true;
            this.colWarehouseWarrant.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWarehouseWarrant.FieldName = "SpecialWarehouseReceipt";
            this.colWarehouseWarrant.Name = "colWarehouseWarrant";
            this.colWarehouseWarrant.OptionsColumn.AllowEdit = false;
            this.colWarehouseWarrant.OptionsColumn.TabStop = false;
            this.colWarehouseWarrant.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "WarehouseWarrant", "共计{0}条")});
            this.colWarehouseWarrant.Visible = true;
            this.colWarehouseWarrant.VisibleIndex = 1;
            this.colWarehouseWarrant.Width = 110;
            // 
            // colWarehouseState
            // 
            this.colWarehouseState.AppearanceHeader.Options.UseTextOptions = true;
            this.colWarehouseState.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWarehouseState.FieldName = "WarehouseState";
            this.colWarehouseState.Name = "colWarehouseState";
            this.colWarehouseState.OptionsColumn.AllowEdit = false;
            this.colWarehouseState.OptionsColumn.TabStop = false;
            this.colWarehouseState.Visible = true;
            this.colWarehouseState.VisibleIndex = 2;
            this.colWarehouseState.Width = 60;
            // 
            // colReqDep
            // 
            this.colReqDep.AppearanceHeader.Options.UseTextOptions = true;
            this.colReqDep.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReqDep.ColumnEdit = this.repLookUpReqDep;
            this.colReqDep.FieldName = "ReqDep";
            this.colReqDep.Name = "colReqDep";
            this.colReqDep.OptionsColumn.AllowEdit = false;
            this.colReqDep.OptionsColumn.TabStop = false;
            this.colReqDep.Visible = true;
            this.colReqDep.VisibleIndex = 8;
            this.colReqDep.Width = 110;
            // 
            // repLookUpReqDep
            // 
            this.repLookUpReqDep.AutoHeight = false;
            this.repLookUpReqDep.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpReqDep.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentNo", "部门编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "部门名称")});
            this.repLookUpReqDep.DisplayMember = "DepartmentName";
            this.repLookUpReqDep.Name = "repLookUpReqDep";
            this.repLookUpReqDep.NullText = "";
            this.repLookUpReqDep.ValueMember = "DepartmentNo";
            // 
            // colWarehouseWarrantDate
            // 
            this.colWarehouseWarrantDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colWarehouseWarrantDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWarehouseWarrantDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colWarehouseWarrantDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colWarehouseWarrantDate.FieldName = "SpecialWarehouseReceiptDate";
            this.colWarehouseWarrantDate.Name = "colWarehouseWarrantDate";
            this.colWarehouseWarrantDate.OptionsColumn.AllowEdit = false;
            this.colWarehouseWarrantDate.OptionsColumn.TabStop = false;
            this.colWarehouseWarrantDate.Visible = true;
            this.colWarehouseWarrantDate.VisibleIndex = 3;
            this.colWarehouseWarrantDate.Width = 90;
            // 
            // colRepertoryId
            // 
            this.colRepertoryId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRepertoryId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRepertoryId.ColumnEdit = this.repLookUpRepertoryId;
            this.colRepertoryId.FieldName = "RepertoryId";
            this.colRepertoryId.Name = "colRepertoryId";
            this.colRepertoryId.OptionsColumn.AllowEdit = false;
            this.colRepertoryId.Visible = true;
            this.colRepertoryId.VisibleIndex = 4;
            this.colRepertoryId.Width = 100;
            // 
            // repLookUpRepertoryId
            // 
            this.repLookUpRepertoryId.AutoHeight = false;
            this.repLookUpRepertoryId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpRepertoryId.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryNo", "仓库编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryName", "仓库名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryTypeText", "仓库类型")});
            this.repLookUpRepertoryId.DisplayMember = "RepertoryName";
            this.repLookUpRepertoryId.Name = "repLookUpRepertoryId";
            this.repLookUpRepertoryId.NullText = "";
            this.repLookUpRepertoryId.ValueMember = "AutoId";
            // 
            // colApprovalType
            // 
            this.colApprovalType.AppearanceHeader.Options.UseTextOptions = true;
            this.colApprovalType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colApprovalType.ColumnEdit = this.repLookUpApprovalType;
            this.colApprovalType.FieldName = "ApprovalType";
            this.colApprovalType.Name = "colApprovalType";
            this.colApprovalType.OptionsColumn.AllowEdit = false;
            this.colApprovalType.Visible = true;
            this.colApprovalType.VisibleIndex = 6;
            this.colApprovalType.Width = 100;
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
            // colRemark1
            // 
            this.colRemark1.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemark1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemark1.FieldName = "Remark";
            this.colRemark1.Name = "colRemark1";
            this.colRemark1.OptionsColumn.AllowEdit = false;
            this.colRemark1.Visible = true;
            this.colRemark1.VisibleIndex = 7;
            this.colRemark1.Width = 100;
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
            this.colCreator.VisibleIndex = 9;
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
            // colModifierId
            // 
            this.colModifierId.AppearanceHeader.Options.UseTextOptions = true;
            this.colModifierId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifierId.ColumnEdit = this.repLookUpCreator;
            this.colModifierId.FieldName = "ModifierId";
            this.colModifierId.Name = "colModifierId";
            this.colModifierId.OptionsColumn.AllowEdit = false;
            this.colModifierId.OptionsColumn.TabStop = false;
            this.colModifierId.Visible = true;
            this.colModifierId.VisibleIndex = 10;
            this.colModifierId.Width = 70;
            // 
            // colRepertoryLocationId
            // 
            this.colRepertoryLocationId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRepertoryLocationId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRepertoryLocationId.ColumnEdit = this.repSearchRepertoryLocationId;
            this.colRepertoryLocationId.FieldName = "RepertoryLocationId";
            this.colRepertoryLocationId.Name = "colRepertoryLocationId";
            this.colRepertoryLocationId.OptionsColumn.AllowEdit = false;
            this.colRepertoryLocationId.Visible = true;
            this.colRepertoryLocationId.VisibleIndex = 5;
            this.colRepertoryLocationId.Width = 100;
            // 
            // repSearchRepertoryLocationId
            // 
            this.repSearchRepertoryLocationId.AutoHeight = false;
            this.repSearchRepertoryLocationId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearchRepertoryLocationId.Name = "repSearchRepertoryLocationId";
            this.repSearchRepertoryLocationId.View = this.repSearchRepertoryLocationIdView;
            this.repSearchRepertoryLocationId.Popup += new System.EventHandler(this.repSearchRepertoryLocationId_Popup);
            // 
            // repSearchRepertoryLocationIdView
            // 
            this.repSearchRepertoryLocationIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchRepertoryLocationIdView.Name = "repSearchRepertoryLocationIdView";
            this.repSearchRepertoryLocationIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchRepertoryLocationIdView.OptionsView.ShowGroupPanel = false;
            // 
            // pnlMiddleTop
            // 
            this.pnlMiddleTop.Controls.Add(this.btnNew);
            this.pnlMiddleTop.Controls.Add(this.btnPreview);
            this.pnlMiddleTop.Controls.Add(this.btnCancelApprove);
            this.pnlMiddleTop.Controls.Add(this.btnApprove);
            this.pnlMiddleTop.Controls.Add(this.btnDelete);
            this.pnlMiddleTop.Controls.Add(this.btnCancel);
            this.pnlMiddleTop.Controls.Add(this.btnSave);
            this.pnlMiddleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddleTop.Location = new System.Drawing.Point(2, 2);
            this.pnlMiddleTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMiddleTop.Name = "pnlMiddleTop";
            this.pnlMiddleTop.Size = new System.Drawing.Size(1260, 34);
            this.pnlMiddleTop.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(5, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 26;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(491, 5);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 25;
            this.btnPreview.TabStop = false;
            this.btnPreview.Text = "预览";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCancelApprove
            // 
            this.btnCancelApprove.Location = new System.Drawing.Point(410, 5);
            this.btnCancelApprove.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelApprove.Name = "btnCancelApprove";
            this.btnCancelApprove.Size = new System.Drawing.Size(75, 23);
            this.btnCancelApprove.TabIndex = 23;
            this.btnCancelApprove.TabStop = false;
            this.btnCancelApprove.Text = "取消审批";
            this.btnCancelApprove.Click += new System.EventHandler(this.btnCancelApprove_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(329, 5);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(4);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 23);
            this.btnApprove.TabIndex = 22;
            this.btnApprove.TabStop = false;
            this.btnApprove.Text = "审批";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(248, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(167, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(86, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "修改";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnltop
            // 
            this.pnltop.Controls.Add(this.searchLookUpApprover);
            this.pnltop.Controls.Add(this.searchLookUpCreator);
            this.pnltop.Controls.Add(this.labLocationId);
            this.pnltop.Controls.Add(this.SearchLocationId);
            this.pnltop.Controls.Add(this.lookUpReqDep);
            this.pnltop.Controls.Add(this.comboBoxWarehouseState);
            this.pnltop.Controls.Add(this.lookUpRepertoryId);
            this.pnltop.Controls.Add(this.btnQuery);
            this.pnltop.Controls.Add(this.textCommon);
            this.pnltop.Controls.Add(this.dateSWRDateEnd);
            this.pnltop.Controls.Add(this.lab1);
            this.pnltop.Controls.Add(this.dateSWRDateBegin);
            this.pnltop.Controls.Add(this.labReqDep);
            this.pnltop.Controls.Add(this.labRepertoryId);
            this.pnltop.Controls.Add(this.labApprover);
            this.pnltop.Controls.Add(this.labCommon);
            this.pnltop.Controls.Add(this.labCreator);
            this.pnltop.Controls.Add(this.labWarehouseState);
            this.pnltop.Controls.Add(this.labSWRDate);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Margin = new System.Windows.Forms.Padding(4);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1264, 78);
            this.pnltop.TabIndex = 2;
            // 
            // searchLookUpApprover
            // 
            this.searchLookUpApprover.Location = new System.Drawing.Point(468, 44);
            this.searchLookUpApprover.Name = "searchLookUpApprover";
            this.searchLookUpApprover.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpApprover.Properties.View = this.gridView1;
            this.searchLookUpApprover.Size = new System.Drawing.Size(120, 20);
            this.searchLookUpApprover.TabIndex = 7;
            this.searchLookUpApprover.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchLookUpApprover_KeyDown);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // searchLookUpCreator
            // 
            this.searchLookUpCreator.Location = new System.Drawing.Point(279, 44);
            this.searchLookUpCreator.Name = "searchLookUpCreator";
            this.searchLookUpCreator.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpCreator.Properties.View = this.searchLookUpCreatorView;
            this.searchLookUpCreator.Size = new System.Drawing.Size(120, 20);
            this.searchLookUpCreator.TabIndex = 6;
            // 
            // searchLookUpCreatorView
            // 
            this.searchLookUpCreatorView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpCreatorView.Name = "searchLookUpCreatorView";
            this.searchLookUpCreatorView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpCreatorView.OptionsView.ShowGroupPanel = false;
            // 
            // labLocationId
            // 
            this.labLocationId.Location = new System.Drawing.Point(564, 17);
            this.labLocationId.Name = "labLocationId";
            this.labLocationId.Size = new System.Drawing.Size(60, 14);
            this.labLocationId.TabIndex = 43;
            this.labLocationId.Text = "出库仓位：";
            // 
            // SearchLocationId
            // 
            this.SearchLocationId.EnterMoveNextControl = true;
            this.SearchLocationId.Location = new System.Drawing.Point(630, 14);
            this.SearchLocationId.Name = "SearchLocationId";
            this.SearchLocationId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLocationId.Properties.View = this.SearchLocationIdView;
            this.SearchLocationId.Size = new System.Drawing.Size(120, 20);
            this.SearchLocationId.TabIndex = 3;
            // 
            // SearchLocationIdView
            // 
            this.SearchLocationIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.SearchLocationIdView.Name = "SearchLocationIdView";
            this.SearchLocationIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.SearchLocationIdView.OptionsView.ShowGroupPanel = false;
            // 
            // lookUpReqDep
            // 
            this.lookUpReqDep.EnterMoveNextControl = true;
            this.lookUpReqDep.Location = new System.Drawing.Point(836, 14);
            this.lookUpReqDep.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpReqDep.Name = "lookUpReqDep";
            this.lookUpReqDep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpReqDep.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentNo", "部门编号", 95, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "部门名称", 111, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpReqDep.Properties.DisplayMember = "DepartmentName";
            this.lookUpReqDep.Properties.NullText = "";
            this.lookUpReqDep.Properties.ValueMember = "DepartmentNo";
            this.lookUpReqDep.Size = new System.Drawing.Size(120, 20);
            this.lookUpReqDep.TabIndex = 4;
            // 
            // comboBoxWarehouseState
            // 
            this.comboBoxWarehouseState.EnterMoveNextControl = true;
            this.comboBoxWarehouseState.Location = new System.Drawing.Point(86, 44);
            this.comboBoxWarehouseState.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxWarehouseState.Name = "comboBoxWarehouseState";
            this.comboBoxWarehouseState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxWarehouseState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxWarehouseState.Size = new System.Drawing.Size(120, 20);
            this.comboBoxWarehouseState.TabIndex = 5;
            // 
            // lookUpRepertoryId
            // 
            this.lookUpRepertoryId.EnterMoveNextControl = true;
            this.lookUpRepertoryId.Location = new System.Drawing.Point(424, 14);
            this.lookUpRepertoryId.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpRepertoryId.Name = "lookUpRepertoryId";
            this.lookUpRepertoryId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpRepertoryId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryNo", "仓库编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryName", "仓库名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryTypeText", "仓库类型")});
            this.lookUpRepertoryId.Properties.DisplayMember = "RepertoryName";
            this.lookUpRepertoryId.Properties.NullText = "";
            this.lookUpRepertoryId.Properties.ValueMember = "AutoId";
            this.lookUpRepertoryId.Size = new System.Drawing.Size(120, 20);
            this.lookUpRepertoryId.TabIndex = 2;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(853, 43);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // textCommon
            // 
            this.textCommon.EnterMoveNextControl = true;
            this.textCommon.Location = new System.Drawing.Point(678, 44);
            this.textCommon.Margin = new System.Windows.Forms.Padding(4);
            this.textCommon.Name = "textCommon";
            this.textCommon.Size = new System.Drawing.Size(150, 20);
            this.textCommon.TabIndex = 8;
            // 
            // dateSWRDateEnd
            // 
            this.dateSWRDateEnd.EditValue = null;
            this.dateSWRDateEnd.EnterMoveNextControl = true;
            this.dateSWRDateEnd.Location = new System.Drawing.Point(238, 14);
            this.dateSWRDateEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dateSWRDateEnd.Name = "dateSWRDateEnd";
            this.dateSWRDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSWRDateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSWRDateEnd.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateSWRDateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateSWRDateEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateSWRDateEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateSWRDateEnd.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateSWRDateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateSWRDateEnd.TabIndex = 1;
            // 
            // lab1
            // 
            this.lab1.Location = new System.Drawing.Point(228, 17);
            this.lab1.Margin = new System.Windows.Forms.Padding(4);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(4, 14);
            this.lab1.TabIndex = 6;
            this.lab1.Text = "-";
            // 
            // dateSWRDateBegin
            // 
            this.dateSWRDateBegin.EditValue = null;
            this.dateSWRDateBegin.EnterMoveNextControl = true;
            this.dateSWRDateBegin.Location = new System.Drawing.Point(122, 14);
            this.dateSWRDateBegin.Margin = new System.Windows.Forms.Padding(4);
            this.dateSWRDateBegin.Name = "dateSWRDateBegin";
            this.dateSWRDateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSWRDateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSWRDateBegin.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateSWRDateBegin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateSWRDateBegin.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateSWRDateBegin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateSWRDateBegin.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateSWRDateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateSWRDateBegin.TabIndex = 0;
            // 
            // labReqDep
            // 
            this.labReqDep.Location = new System.Drawing.Point(770, 17);
            this.labReqDep.Margin = new System.Windows.Forms.Padding(4);
            this.labReqDep.Name = "labReqDep";
            this.labReqDep.Size = new System.Drawing.Size(60, 14);
            this.labReqDep.TabIndex = 32;
            this.labReqDep.Text = "出库部门：";
            // 
            // labRepertoryId
            // 
            this.labRepertoryId.Location = new System.Drawing.Point(358, 17);
            this.labRepertoryId.Margin = new System.Windows.Forms.Padding(4);
            this.labRepertoryId.Name = "labRepertoryId";
            this.labRepertoryId.Size = new System.Drawing.Size(60, 14);
            this.labRepertoryId.TabIndex = 26;
            this.labRepertoryId.Text = "出库仓库：";
            // 
            // labApprover
            // 
            this.labApprover.Location = new System.Drawing.Point(416, 47);
            this.labApprover.Margin = new System.Windows.Forms.Padding(4);
            this.labApprover.Name = "labApprover";
            this.labApprover.Size = new System.Drawing.Size(48, 14);
            this.labApprover.TabIndex = 24;
            this.labApprover.Text = "审批人：";
            // 
            // labCommon
            // 
            this.labCommon.Location = new System.Drawing.Point(610, 47);
            this.labCommon.Margin = new System.Windows.Forms.Padding(4);
            this.labCommon.Name = "labCommon";
            this.labCommon.Size = new System.Drawing.Size(60, 14);
            this.labCommon.TabIndex = 22;
            this.labCommon.Text = "通用查询：";
            // 
            // labCreator
            // 
            this.labCreator.Location = new System.Drawing.Point(224, 47);
            this.labCreator.Margin = new System.Windows.Forms.Padding(4);
            this.labCreator.Name = "labCreator";
            this.labCreator.Size = new System.Drawing.Size(48, 14);
            this.labCreator.TabIndex = 20;
            this.labCreator.Text = "制单人：";
            // 
            // labWarehouseState
            // 
            this.labWarehouseState.Location = new System.Drawing.Point(20, 47);
            this.labWarehouseState.Margin = new System.Windows.Forms.Padding(4);
            this.labWarehouseState.Name = "labWarehouseState";
            this.labWarehouseState.Size = new System.Drawing.Size(60, 14);
            this.labWarehouseState.TabIndex = 30;
            this.labWarehouseState.Text = "单据状态：";
            // 
            // labSWRDate
            // 
            this.labSWRDate.Location = new System.Drawing.Point(20, 17);
            this.labSWRDate.Margin = new System.Windows.Forms.Padding(4);
            this.labSWRDate.Name = "labSWRDate";
            this.labSWRDate.Size = new System.Drawing.Size(96, 14);
            this.labSWRDate.TabIndex = 5;
            this.labSWRDate.Text = "预算外出库日期：";
            // 
            // FrmSpecialWarehouseReceipt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlRight);
            this.Name = "FrmSpecialWarehouseReceipt";
            this.TabText = "预算外出库单";
            this.Text = "预算外出库单";
            this.Activated += new System.EventHandler(this.FrmSpecialWarehouseReceipt_Activated);
            this.Load += new System.EventHandler(this.FrmSpecialWarehouseReceipt_Load);
            this.Shown += new System.EventHandler(this.FrmSpecialWarehouseReceipt_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_SWR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSWRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSWRList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SWRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SWRList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSWRList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSWRList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchCodeFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchCodeFileNameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchShelfId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchShelfIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProjectNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchProjectNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repComboBoxStnNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repbtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSWRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSWRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchRepertoryLocationId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchRepertoryLocationIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddleTop)).EndInit();
            this.pnlMiddleTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpApprover.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreatorView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxWarehouseState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSWRDateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSWRDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSWRDateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSWRDateBegin.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSet_SWR;
        private System.Data.DataTable dataTableSWRHead;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColSpecialWarehouseReceipt;
        private System.Data.DataColumn dataColSpecialWarehouseReceiptDate;
        private System.Data.DataColumn dataColReqDep;
        private System.Data.DataColumn dataColRepertoryId;
        private System.Data.DataColumn dataColApprovalType;
        private System.Data.DataColumn dataColPreparedIp;
        private System.Data.DataColumn dataColModifierIp;
        private System.Data.DataColumn dataColModifierTime;
        private System.Data.DataColumn dataColRemark;
        private System.Data.DataColumn dataColSelect;
        private System.Data.DataColumn dataColWarehouseState;
        private System.Data.DataTable dataTableSWRList;
        private System.Data.DataColumn dataColumnAutoId;
        private System.Data.DataColumn dataColumnSpecialWarehouseReceipt;
        private System.Data.DataColumn dataColCodeFileName;
        private System.Data.DataColumn dataColQty;
        private System.Data.DataColumn dataColProjectName;
        private System.Data.DataColumn dataColStnNo;
        private System.Data.DataColumn dataColumnRemark;
        private System.Data.DataColumn dataColCodeName;
        private System.Data.DataColumn dataColShelfId;
        private System.Windows.Forms.BindingSource bindingSource_SWRHead;
        private System.Windows.Forms.BindingSource bindingSource_SWRList;
        private DevExpress.XtraEditors.PanelControl pnlRight;
        private DevExpress.XtraEditors.PanelControl pnltop;
        private DevExpress.XtraEditors.LookUpEdit lookUpReqDep;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxWarehouseState;
        private DevExpress.XtraEditors.LookUpEdit lookUpRepertoryId;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.TextEdit textCommon;
        private DevExpress.XtraEditors.DateEdit dateSWRDateEnd;
        private DevExpress.XtraEditors.LabelControl lab1;
        private DevExpress.XtraEditors.DateEdit dateSWRDateBegin;
        private DevExpress.XtraEditors.LabelControl labReqDep;
        private DevExpress.XtraEditors.LabelControl labRepertoryId;
        private DevExpress.XtraEditors.LabelControl labApprover;
        private DevExpress.XtraEditors.LabelControl labCommon;
        private DevExpress.XtraEditors.LabelControl labCreator;
        private DevExpress.XtraEditors.LabelControl labWarehouseState;
        private DevExpress.XtraEditors.LabelControl labSWRDate;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.PanelControl pnlMiddleTop;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnCancelApprove;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl gridControlSWRHead;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSWRHead;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseWarrant;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseState;
        private DevExpress.XtraGrid.Columns.GridColumn colReqDep;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpReqDep;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseWarrantDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovalType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpApprovalType;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colModifierId;
        private DevExpress.XtraEditors.CheckEdit checkAll;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnListAdd;
        private System.Data.DataColumn dataColumnProjectNo;
        private DevExpress.XtraGrid.GridControl gridControlSWRList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSWRList;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId1;
        private DevExpress.XtraGrid.Columns.GridColumn columnWarehouseReceipt;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeFileName;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchCodeFileName;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchCodeFileNameView;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinQty;
        private DevExpress.XtraGrid.Columns.GridColumn colShelfId;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchShelfId;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchShelfIdView;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchProjectNo;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchProjectNoView;
        private DevExpress.XtraGrid.Columns.GridColumn colStnNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repComboBoxStnNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repbtnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNo;
        private System.Data.DataColumn dataColRepertoryLocationId;
        private DevExpress.XtraEditors.LabelControl labLocationId;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLocationId;
        private DevExpress.XtraGrid.Views.Grid.GridView SearchLocationIdView;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryLocationId;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchRepertoryLocationId;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchRepertoryLocationIdView;
        private System.Data.DataColumn dataColCodeId;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeId;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpApprover;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpCreator;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpCreatorView;
        private System.Data.DataColumn dataColCreator;
        private System.Data.DataColumn dataColModifierId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator;
    }
}