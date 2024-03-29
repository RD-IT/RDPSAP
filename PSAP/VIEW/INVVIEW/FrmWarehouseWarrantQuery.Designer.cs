﻿namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWarehouseWarrantQuery
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
            this.pnltop = new DevExpress.XtraEditors.PanelControl();
            this.searchLookUpCreator = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpCreatorView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labLocationId = new DevExpress.XtraEditors.LabelControl();
            this.spinorderListAutoId = new DevExpress.XtraEditors.SpinEdit();
            this.checkorderListAutoId = new DevExpress.XtraEditors.CheckEdit();
            this.btnSaveExcel = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpReqDep = new DevExpress.XtraEditors.LookUpEdit();
            this.comboBoxWarehouseState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lookUpWarehouseWarrantTypeNo = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpRepertoryId = new DevExpress.XtraEditors.LookUpEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.textCommon = new DevExpress.XtraEditors.TextEdit();
            this.searchLookUpBussinessBaseNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpBussinessBaseNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnBussinessBaseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBussinessBaseText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBussinessCategoryText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateWWDateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateWWDateBegin = new DevExpress.XtraEditors.DateEdit();
            this.labReqDep = new DevExpress.XtraEditors.LabelControl();
            this.labWarehouseState = new DevExpress.XtraEditors.LabelControl();
            this.labWarehouseWarrantTypeNo = new DevExpress.XtraEditors.LabelControl();
            this.labRepertoryId = new DevExpress.XtraEditors.LabelControl();
            this.labCommon = new DevExpress.XtraEditors.LabelControl();
            this.labCreator = new DevExpress.XtraEditors.LabelControl();
            this.labBussinessBaseNo = new DevExpress.XtraEditors.LabelControl();
            this.lab1 = new DevExpress.XtraEditors.LabelControl();
            this.labWWDate = new DevExpress.XtraEditors.LabelControl();
            this.SearchLocationId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.SearchLocationIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dataSet_WW = new System.Data.DataSet();
            this.dataTableWWHead = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColWarehouseWarrant = new System.Data.DataColumn();
            this.dataColWarehouseWarrantDate = new System.Data.DataColumn();
            this.dataColBussinessBaseNo = new System.Data.DataColumn();
            this.dataColRepertoryId = new System.Data.DataColumn();
            this.dataColWarehouseWarrantTypeNo = new System.Data.DataColumn();
            this.dataColPreparedIp = new System.Data.DataColumn();
            this.dataColumnRemark = new System.Data.DataColumn();
            this.dataColApprovalType = new System.Data.DataColumn();
            this.dataColModifierIp = new System.Data.DataColumn();
            this.dataColModifierTime = new System.Data.DataColumn();
            this.dataColWarehouseState = new System.Data.DataColumn();
            this.dataColReqDep = new System.Data.DataColumn();
            this.dataColRepertoryLocationId = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColModifierId = new System.Data.DataColumn();
            this.bindingSource_WWHead = new System.Windows.Forms.BindingSource(this.components);
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.gridControlWWHead = new DevExpress.XtraGrid.GridControl();
            this.gridViewWWHead = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseWarrant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReqDep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpReqDep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colWarehouseWarrantDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBussinessBaseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchBussinessBaseNo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCBussinessBaseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCBussinessBaseText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCBussinessCategoryText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepertoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRepertoryLocationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryLocationId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colWarehouseWarrantTypeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpWWTypeNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colApprovalType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpApprovalType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRemark1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModifier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifierTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.gridBottomOrderHead = new PSAP.VIEW.BSVIEW.GridBottom();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRkrqbnwkcx = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreatorView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinorderListAutoId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkorderListAutoId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxWarehouseState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpWarehouseWarrantTypeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpBussinessBaseNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpBussinessBaseNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWWDateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWWDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWWDateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWWDateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_WW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableWWHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_WWHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWWHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWWHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchBussinessBaseNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryLocationId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpWWTypeNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnltop
            // 
            this.pnltop.Controls.Add(this.searchLookUpCreator);
            this.pnltop.Controls.Add(this.labLocationId);
            this.pnltop.Controls.Add(this.spinorderListAutoId);
            this.pnltop.Controls.Add(this.checkorderListAutoId);
            this.pnltop.Controls.Add(this.btnSaveExcel);
            this.pnltop.Controls.Add(this.lookUpReqDep);
            this.pnltop.Controls.Add(this.comboBoxWarehouseState);
            this.pnltop.Controls.Add(this.lookUpWarehouseWarrantTypeNo);
            this.pnltop.Controls.Add(this.lookUpRepertoryId);
            this.pnltop.Controls.Add(this.btnQuery);
            this.pnltop.Controls.Add(this.textCommon);
            this.pnltop.Controls.Add(this.searchLookUpBussinessBaseNo);
            this.pnltop.Controls.Add(this.dateWWDateEnd);
            this.pnltop.Controls.Add(this.dateWWDateBegin);
            this.pnltop.Controls.Add(this.labReqDep);
            this.pnltop.Controls.Add(this.labWarehouseState);
            this.pnltop.Controls.Add(this.labWarehouseWarrantTypeNo);
            this.pnltop.Controls.Add(this.labRepertoryId);
            this.pnltop.Controls.Add(this.labCommon);
            this.pnltop.Controls.Add(this.labCreator);
            this.pnltop.Controls.Add(this.labBussinessBaseNo);
            this.pnltop.Controls.Add(this.lab1);
            this.pnltop.Controls.Add(this.labWWDate);
            this.pnltop.Controls.Add(this.SearchLocationId);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1276, 78);
            this.pnltop.TabIndex = 1;
            // 
            // searchLookUpCreator
            // 
            this.searchLookUpCreator.Location = new System.Drawing.Point(478, 44);
            this.searchLookUpCreator.Name = "searchLookUpCreator";
            this.searchLookUpCreator.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpCreator.Properties.View = this.searchLookUpCreatorView;
            this.searchLookUpCreator.Size = new System.Drawing.Size(120, 20);
            this.searchLookUpCreator.TabIndex = 8;
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
            this.labLocationId.Location = new System.Drawing.Point(735, 17);
            this.labLocationId.Name = "labLocationId";
            this.labLocationId.Size = new System.Drawing.Size(60, 14);
            this.labLocationId.TabIndex = 37;
            this.labLocationId.Text = "入库仓位：";
            // 
            // spinorderListAutoId
            // 
            this.spinorderListAutoId.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinorderListAutoId.Enabled = false;
            this.spinorderListAutoId.EnterMoveNextControl = true;
            this.spinorderListAutoId.Location = new System.Drawing.Point(951, 44);
            this.spinorderListAutoId.Name = "spinorderListAutoId";
            this.spinorderListAutoId.Properties.Mask.EditMask = "d";
            this.spinorderListAutoId.Size = new System.Drawing.Size(80, 20);
            this.spinorderListAutoId.TabIndex = 11;
            this.spinorderListAutoId.TabStop = false;
            // 
            // checkorderListAutoId
            // 
            this.checkorderListAutoId.EnterMoveNextControl = true;
            this.checkorderListAutoId.Location = new System.Drawing.Point(845, 44);
            this.checkorderListAutoId.Name = "checkorderListAutoId";
            this.checkorderListAutoId.Properties.Caption = "采购单明细ID";
            this.checkorderListAutoId.Size = new System.Drawing.Size(100, 19);
            this.checkorderListAutoId.TabIndex = 10;
            this.checkorderListAutoId.TabStop = false;
            this.checkorderListAutoId.CheckedChanged += new System.EventHandler(this.checkorderListAutoId_CheckedChanged);
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(1140, 43);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveExcel.TabIndex = 13;
            this.btnSaveExcel.Text = "存为Excel";
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // lookUpReqDep
            // 
            this.lookUpReqDep.EnterMoveNextControl = true;
            this.lookUpReqDep.Location = new System.Drawing.Point(1003, 14);
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
            this.lookUpReqDep.TabIndex = 5;
            // 
            // comboBoxWarehouseState
            // 
            this.comboBoxWarehouseState.EnterMoveNextControl = true;
            this.comboBoxWarehouseState.Location = new System.Drawing.Point(288, 44);
            this.comboBoxWarehouseState.Name = "comboBoxWarehouseState";
            this.comboBoxWarehouseState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxWarehouseState.Size = new System.Drawing.Size(120, 20);
            this.comboBoxWarehouseState.TabIndex = 7;
            // 
            // lookUpWarehouseWarrantTypeNo
            // 
            this.lookUpWarehouseWarrantTypeNo.EnterMoveNextControl = true;
            this.lookUpWarehouseWarrantTypeNo.Location = new System.Drawing.Point(86, 44);
            this.lookUpWarehouseWarrantTypeNo.Name = "lookUpWarehouseWarrantTypeNo";
            this.lookUpWarehouseWarrantTypeNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpWarehouseWarrantTypeNo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseWarrantTypeNo", "类别编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseWarrantTypeName", "类别名称")});
            this.lookUpWarehouseWarrantTypeNo.Properties.DisplayMember = "WarehouseWarrantTypeName";
            this.lookUpWarehouseWarrantTypeNo.Properties.NullText = "";
            this.lookUpWarehouseWarrantTypeNo.Properties.ValueMember = "WarehouseWarrantTypeNo";
            this.lookUpWarehouseWarrantTypeNo.Size = new System.Drawing.Size(120, 20);
            this.lookUpWarehouseWarrantTypeNo.TabIndex = 6;
            // 
            // lookUpRepertoryId
            // 
            this.lookUpRepertoryId.EnterMoveNextControl = true;
            this.lookUpRepertoryId.Location = new System.Drawing.Point(600, 14);
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
            this.lookUpRepertoryId.TabIndex = 3;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(1048, 43);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // textCommon
            // 
            this.textCommon.EnterMoveNextControl = true;
            this.textCommon.Location = new System.Drawing.Point(680, 44);
            this.textCommon.Name = "textCommon";
            this.textCommon.Size = new System.Drawing.Size(150, 20);
            this.textCommon.TabIndex = 9;
            // 
            // searchLookUpBussinessBaseNo
            // 
            this.searchLookUpBussinessBaseNo.EnterMoveNextControl = true;
            this.searchLookUpBussinessBaseNo.Location = new System.Drawing.Point(369, 14);
            this.searchLookUpBussinessBaseNo.Name = "searchLookUpBussinessBaseNo";
            this.searchLookUpBussinessBaseNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpBussinessBaseNo.Properties.DisplayMember = "BussinessBaseText";
            this.searchLookUpBussinessBaseNo.Properties.NullText = "";
            this.searchLookUpBussinessBaseNo.Properties.ValueMember = "BussinessBaseNo";
            this.searchLookUpBussinessBaseNo.Properties.View = this.searchLookUpBussinessBaseNoView;
            this.searchLookUpBussinessBaseNo.Size = new System.Drawing.Size(150, 20);
            this.searchLookUpBussinessBaseNo.TabIndex = 2;
            // 
            // searchLookUpBussinessBaseNoView
            // 
            this.searchLookUpBussinessBaseNoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnBussinessBaseNo,
            this.gridColumnBussinessBaseText,
            this.gridColumnBussinessCategoryText,
            this.gridColumnAutoId});
            this.searchLookUpBussinessBaseNoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpBussinessBaseNoView.IndicatorWidth = 60;
            this.searchLookUpBussinessBaseNoView.Name = "searchLookUpBussinessBaseNoView";
            this.searchLookUpBussinessBaseNoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpBussinessBaseNoView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnBussinessBaseNo
            // 
            this.gridColumnBussinessBaseNo.Caption = "往来方编号";
            this.gridColumnBussinessBaseNo.FieldName = "BussinessBaseNo";
            this.gridColumnBussinessBaseNo.Name = "gridColumnBussinessBaseNo";
            this.gridColumnBussinessBaseNo.Visible = true;
            this.gridColumnBussinessBaseNo.VisibleIndex = 0;
            // 
            // gridColumnBussinessBaseText
            // 
            this.gridColumnBussinessBaseText.Caption = "往来方名称";
            this.gridColumnBussinessBaseText.FieldName = "BussinessBaseText";
            this.gridColumnBussinessBaseText.Name = "gridColumnBussinessBaseText";
            this.gridColumnBussinessBaseText.Visible = true;
            this.gridColumnBussinessBaseText.VisibleIndex = 1;
            // 
            // gridColumnBussinessCategoryText
            // 
            this.gridColumnBussinessCategoryText.Caption = "往来方分类";
            this.gridColumnBussinessCategoryText.FieldName = "BussinessCategoryText";
            this.gridColumnBussinessCategoryText.Name = "gridColumnBussinessCategoryText";
            this.gridColumnBussinessCategoryText.Visible = true;
            this.gridColumnBussinessCategoryText.VisibleIndex = 2;
            // 
            // gridColumnAutoId
            // 
            this.gridColumnAutoId.Caption = "gridColumnAutoId";
            this.gridColumnAutoId.Name = "gridColumnAutoId";
            // 
            // dateWWDateEnd
            // 
            this.dateWWDateEnd.EditValue = null;
            this.dateWWDateEnd.EnterMoveNextControl = true;
            this.dateWWDateEnd.Location = new System.Drawing.Point(202, 14);
            this.dateWWDateEnd.Name = "dateWWDateEnd";
            this.dateWWDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWWDateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWWDateEnd.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateWWDateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWWDateEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateWWDateEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWWDateEnd.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateWWDateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateWWDateEnd.TabIndex = 1;
            // 
            // dateWWDateBegin
            // 
            this.dateWWDateBegin.EditValue = null;
            this.dateWWDateBegin.EnterMoveNextControl = true;
            this.dateWWDateBegin.Location = new System.Drawing.Point(86, 14);
            this.dateWWDateBegin.Name = "dateWWDateBegin";
            this.dateWWDateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWWDateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWWDateBegin.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateWWDateBegin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWWDateBegin.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateWWDateBegin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWWDateBegin.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateWWDateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateWWDateBegin.TabIndex = 0;
            // 
            // labReqDep
            // 
            this.labReqDep.Location = new System.Drawing.Point(937, 17);
            this.labReqDep.Name = "labReqDep";
            this.labReqDep.Size = new System.Drawing.Size(60, 14);
            this.labReqDep.TabIndex = 32;
            this.labReqDep.Text = "入库部门：";
            // 
            // labWarehouseState
            // 
            this.labWarehouseState.Location = new System.Drawing.Point(222, 47);
            this.labWarehouseState.Name = "labWarehouseState";
            this.labWarehouseState.Size = new System.Drawing.Size(60, 14);
            this.labWarehouseState.TabIndex = 30;
            this.labWarehouseState.Text = "单据状态：";
            // 
            // labWarehouseWarrantTypeNo
            // 
            this.labWarehouseWarrantTypeNo.Location = new System.Drawing.Point(20, 47);
            this.labWarehouseWarrantTypeNo.Name = "labWarehouseWarrantTypeNo";
            this.labWarehouseWarrantTypeNo.Size = new System.Drawing.Size(60, 14);
            this.labWarehouseWarrantTypeNo.TabIndex = 28;
            this.labWarehouseWarrantTypeNo.Text = "入库类别：";
            // 
            // labRepertoryId
            // 
            this.labRepertoryId.Location = new System.Drawing.Point(534, 17);
            this.labRepertoryId.Name = "labRepertoryId";
            this.labRepertoryId.Size = new System.Drawing.Size(60, 14);
            this.labRepertoryId.TabIndex = 26;
            this.labRepertoryId.Text = "入库仓库：";
            // 
            // labCommon
            // 
            this.labCommon.Location = new System.Drawing.Point(616, 47);
            this.labCommon.Name = "labCommon";
            this.labCommon.Size = new System.Drawing.Size(60, 14);
            this.labCommon.TabIndex = 22;
            this.labCommon.Text = "通用查询：";
            // 
            // labCreator
            // 
            this.labCreator.Location = new System.Drawing.Point(424, 47);
            this.labCreator.Name = "labCreator";
            this.labCreator.Size = new System.Drawing.Size(48, 14);
            this.labCreator.TabIndex = 20;
            this.labCreator.Text = "制单人：";
            // 
            // labBussinessBaseNo
            // 
            this.labBussinessBaseNo.Location = new System.Drawing.Point(315, 17);
            this.labBussinessBaseNo.Name = "labBussinessBaseNo";
            this.labBussinessBaseNo.Size = new System.Drawing.Size(48, 14);
            this.labBussinessBaseNo.TabIndex = 18;
            this.labBussinessBaseNo.Text = "供应商：";
            // 
            // lab1
            // 
            this.lab1.Location = new System.Drawing.Point(192, 17);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(4, 14);
            this.lab1.TabIndex = 6;
            this.lab1.Text = "-";
            // 
            // labWWDate
            // 
            this.labWWDate.Location = new System.Drawing.Point(20, 17);
            this.labWWDate.Name = "labWWDate";
            this.labWWDate.Size = new System.Drawing.Size(60, 14);
            this.labWWDate.TabIndex = 5;
            this.labWWDate.Text = "入库日期：";
            // 
            // SearchLocationId
            // 
            this.SearchLocationId.EnterMoveNextControl = true;
            this.SearchLocationId.Location = new System.Drawing.Point(801, 14);
            this.SearchLocationId.Name = "SearchLocationId";
            this.SearchLocationId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLocationId.Properties.View = this.SearchLocationIdView;
            this.SearchLocationId.Size = new System.Drawing.Size(120, 20);
            this.SearchLocationId.TabIndex = 4;
            // 
            // SearchLocationIdView
            // 
            this.SearchLocationIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.SearchLocationIdView.Name = "SearchLocationIdView";
            this.SearchLocationIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.SearchLocationIdView.OptionsView.ShowGroupPanel = false;
            // 
            // dataSet_WW
            // 
            this.dataSet_WW.DataSetName = "NewDataSet";
            this.dataSet_WW.EnforceConstraints = false;
            this.dataSet_WW.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableWWHead});
            // 
            // dataTableWWHead
            // 
            this.dataTableWWHead.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColWarehouseWarrant,
            this.dataColWarehouseWarrantDate,
            this.dataColBussinessBaseNo,
            this.dataColRepertoryId,
            this.dataColWarehouseWarrantTypeNo,
            this.dataColPreparedIp,
            this.dataColumnRemark,
            this.dataColApprovalType,
            this.dataColModifierIp,
            this.dataColModifierTime,
            this.dataColWarehouseState,
            this.dataColReqDep,
            this.dataColRepertoryLocationId,
            this.dataColCreator,
            this.dataColModifierId});
            this.dataTableWWHead.TableName = "WWHead";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColWarehouseWarrant
            // 
            this.dataColWarehouseWarrant.Caption = "入库单号";
            this.dataColWarehouseWarrant.ColumnName = "WarehouseWarrant";
            // 
            // dataColWarehouseWarrantDate
            // 
            this.dataColWarehouseWarrantDate.Caption = "入库日期";
            this.dataColWarehouseWarrantDate.ColumnName = "WarehouseWarrantDate";
            this.dataColWarehouseWarrantDate.DataType = typeof(System.DateTime);
            // 
            // dataColBussinessBaseNo
            // 
            this.dataColBussinessBaseNo.Caption = "供应商";
            this.dataColBussinessBaseNo.ColumnName = "BussinessBaseNo";
            // 
            // dataColRepertoryId
            // 
            this.dataColRepertoryId.Caption = "入库仓库";
            this.dataColRepertoryId.ColumnName = "RepertoryId";
            this.dataColRepertoryId.DataType = typeof(int);
            // 
            // dataColWarehouseWarrantTypeNo
            // 
            this.dataColWarehouseWarrantTypeNo.Caption = "入库类别";
            this.dataColWarehouseWarrantTypeNo.ColumnName = "WarehouseWarrantTypeNo";
            // 
            // dataColPreparedIp
            // 
            this.dataColPreparedIp.Caption = "制单人IP";
            this.dataColPreparedIp.ColumnName = "PreparedIp";
            // 
            // dataColumnRemark
            // 
            this.dataColumnRemark.Caption = "备注";
            this.dataColumnRemark.ColumnName = "Remark";
            // 
            // dataColApprovalType
            // 
            this.dataColApprovalType.Caption = "审批类型";
            this.dataColApprovalType.ColumnName = "ApprovalType";
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
            // dataColWarehouseState
            // 
            this.dataColWarehouseState.Caption = "状态";
            this.dataColWarehouseState.ColumnName = "WarehouseState";
            this.dataColWarehouseState.DataType = typeof(int);
            // 
            // dataColReqDep
            // 
            this.dataColReqDep.Caption = "入库部门";
            this.dataColReqDep.ColumnName = "ReqDep";
            // 
            // dataColRepertoryLocationId
            // 
            this.dataColRepertoryLocationId.Caption = "入库仓位";
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
            // bindingSource_WWHead
            // 
            this.bindingSource_WWHead.DataMember = "WWHead";
            this.bindingSource_WWHead.DataSource = this.dataSet_WW;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.gridControlWWHead);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 78);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1276, 311);
            this.pnlMiddle.TabIndex = 6;
            // 
            // gridControlWWHead
            // 
            this.gridControlWWHead.DataSource = this.bindingSource_WWHead;
            this.gridControlWWHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlWWHead.Location = new System.Drawing.Point(2, 2);
            this.gridControlWWHead.MainView = this.gridViewWWHead;
            this.gridControlWWHead.Name = "gridControlWWHead";
            this.gridControlWWHead.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpRepertoryId,
            this.repLookUpWWTypeNo,
            this.repSearchBussinessBaseNo,
            this.repCheckSelect,
            this.repLookUpApprovalType,
            this.repLookUpReqDep,
            this.repLookUpRepertoryLocationId,
            this.repLookUpCreator});
            this.gridControlWWHead.Size = new System.Drawing.Size(1272, 307);
            this.gridControlWWHead.TabIndex = 4;
            this.gridControlWWHead.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWWHead});
            // 
            // gridViewWWHead
            // 
            this.gridViewWWHead.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colWarehouseWarrant,
            this.colWarehouseState,
            this.colReqDep,
            this.colWarehouseWarrantDate,
            this.colBussinessBaseNo,
            this.colRepertoryId,
            this.colRepertoryLocationId,
            this.colWarehouseWarrantTypeNo,
            this.colApprovalType,
            this.colRemark1,
            this.colCreator,
            this.colModifier,
            this.colModifierTime});
            this.gridViewWWHead.GridControl = this.gridControlWWHead;
            this.gridViewWWHead.IndicatorWidth = 40;
            this.gridViewWWHead.Name = "gridViewWWHead";
            this.gridViewWWHead.OptionsBehavior.Editable = false;
            this.gridViewWWHead.OptionsBehavior.ReadOnly = true;
            this.gridViewWWHead.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewWWHead.OptionsView.ColumnAutoWidth = false;
            this.gridViewWWHead.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewWWHead.OptionsView.ShowFooter = true;
            this.gridViewWWHead.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewWWHead_RowClick);
            this.gridViewWWHead.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewWWHead_CustomDrawRowIndicator);
            this.gridViewWWHead.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewWWHead_CustomColumnDisplayText);
            this.gridViewWWHead.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewWWHead_KeyDown);
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colWarehouseWarrant
            // 
            this.colWarehouseWarrant.AppearanceHeader.Options.UseTextOptions = true;
            this.colWarehouseWarrant.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWarehouseWarrant.FieldName = "WarehouseWarrant";
            this.colWarehouseWarrant.Name = "colWarehouseWarrant";
            this.colWarehouseWarrant.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "WarehouseWarrant", "共计{0}条")});
            this.colWarehouseWarrant.Visible = true;
            this.colWarehouseWarrant.VisibleIndex = 0;
            this.colWarehouseWarrant.Width = 110;
            // 
            // colWarehouseState
            // 
            this.colWarehouseState.AppearanceHeader.Options.UseTextOptions = true;
            this.colWarehouseState.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWarehouseState.FieldName = "WarehouseState";
            this.colWarehouseState.Name = "colWarehouseState";
            this.colWarehouseState.Visible = true;
            this.colWarehouseState.VisibleIndex = 1;
            this.colWarehouseState.Width = 60;
            // 
            // colReqDep
            // 
            this.colReqDep.AppearanceHeader.Options.UseTextOptions = true;
            this.colReqDep.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReqDep.ColumnEdit = this.repLookUpReqDep;
            this.colReqDep.FieldName = "ReqDep";
            this.colReqDep.Name = "colReqDep";
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
            this.colWarehouseWarrantDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colWarehouseWarrantDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colWarehouseWarrantDate.FieldName = "WarehouseWarrantDate";
            this.colWarehouseWarrantDate.Name = "colWarehouseWarrantDate";
            this.colWarehouseWarrantDate.Visible = true;
            this.colWarehouseWarrantDate.VisibleIndex = 3;
            this.colWarehouseWarrantDate.Width = 135;
            // 
            // colBussinessBaseNo
            // 
            this.colBussinessBaseNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colBussinessBaseNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBussinessBaseNo.ColumnEdit = this.repSearchBussinessBaseNo;
            this.colBussinessBaseNo.FieldName = "BussinessBaseNo";
            this.colBussinessBaseNo.Name = "colBussinessBaseNo";
            this.colBussinessBaseNo.Visible = true;
            this.colBussinessBaseNo.VisibleIndex = 2;
            this.colBussinessBaseNo.Width = 130;
            // 
            // repSearchBussinessBaseNo
            // 
            this.repSearchBussinessBaseNo.AutoHeight = false;
            this.repSearchBussinessBaseNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearchBussinessBaseNo.DisplayMember = "BussinessBaseText";
            this.repSearchBussinessBaseNo.Name = "repSearchBussinessBaseNo";
            this.repSearchBussinessBaseNo.NullText = "";
            this.repSearchBussinessBaseNo.ValueMember = "BussinessBaseNo";
            this.repSearchBussinessBaseNo.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCBussinessBaseNo,
            this.gridCBussinessBaseText,
            this.gridCBussinessCategoryText,
            this.gridCAutoId});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.IndicatorWidth = 60;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridCBussinessBaseNo
            // 
            this.gridCBussinessBaseNo.Caption = "往来方编号";
            this.gridCBussinessBaseNo.FieldName = "BussinessBaseNo";
            this.gridCBussinessBaseNo.Name = "gridCBussinessBaseNo";
            this.gridCBussinessBaseNo.Visible = true;
            this.gridCBussinessBaseNo.VisibleIndex = 0;
            // 
            // gridCBussinessBaseText
            // 
            this.gridCBussinessBaseText.Caption = "往来方名称";
            this.gridCBussinessBaseText.FieldName = "BussinessBaseText";
            this.gridCBussinessBaseText.Name = "gridCBussinessBaseText";
            this.gridCBussinessBaseText.Visible = true;
            this.gridCBussinessBaseText.VisibleIndex = 1;
            // 
            // gridCBussinessCategoryText
            // 
            this.gridCBussinessCategoryText.Caption = "往来方分类";
            this.gridCBussinessCategoryText.FieldName = "BussinessCategoryText";
            this.gridCBussinessCategoryText.Name = "gridCBussinessCategoryText";
            this.gridCBussinessCategoryText.Visible = true;
            this.gridCBussinessCategoryText.VisibleIndex = 2;
            // 
            // gridCAutoId
            // 
            this.gridCAutoId.Caption = "AutoId";
            this.gridCAutoId.FieldName = "AutoId";
            this.gridCAutoId.Name = "gridCAutoId";
            // 
            // colRepertoryId
            // 
            this.colRepertoryId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRepertoryId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRepertoryId.ColumnEdit = this.repLookUpRepertoryId;
            this.colRepertoryId.FieldName = "RepertoryId";
            this.colRepertoryId.Name = "colRepertoryId";
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
            // colRepertoryLocationId
            // 
            this.colRepertoryLocationId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRepertoryLocationId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRepertoryLocationId.ColumnEdit = this.repLookUpRepertoryLocationId;
            this.colRepertoryLocationId.FieldName = "RepertoryLocationId";
            this.colRepertoryLocationId.Name = "colRepertoryLocationId";
            this.colRepertoryLocationId.Visible = true;
            this.colRepertoryLocationId.VisibleIndex = 5;
            this.colRepertoryLocationId.Width = 100;
            // 
            // repLookUpRepertoryLocationId
            // 
            this.repLookUpRepertoryLocationId.AutoHeight = false;
            this.repLookUpRepertoryLocationId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpRepertoryLocationId.DisplayMember = "LocationName";
            this.repLookUpRepertoryLocationId.Name = "repLookUpRepertoryLocationId";
            this.repLookUpRepertoryLocationId.NullText = "";
            this.repLookUpRepertoryLocationId.ValueMember = "AutoId";
            // 
            // colWarehouseWarrantTypeNo
            // 
            this.colWarehouseWarrantTypeNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colWarehouseWarrantTypeNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWarehouseWarrantTypeNo.ColumnEdit = this.repLookUpWWTypeNo;
            this.colWarehouseWarrantTypeNo.FieldName = "WarehouseWarrantTypeNo";
            this.colWarehouseWarrantTypeNo.Name = "colWarehouseWarrantTypeNo";
            this.colWarehouseWarrantTypeNo.Visible = true;
            this.colWarehouseWarrantTypeNo.VisibleIndex = 6;
            this.colWarehouseWarrantTypeNo.Width = 100;
            // 
            // repLookUpWWTypeNo
            // 
            this.repLookUpWWTypeNo.AutoHeight = false;
            this.repLookUpWWTypeNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpWWTypeNo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseWarrantTypeNo", "类别编号", 81, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseWarrantTypeName", "类别名称", 111, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repLookUpWWTypeNo.DisplayMember = "WarehouseWarrantTypeName";
            this.repLookUpWWTypeNo.Name = "repLookUpWWTypeNo";
            this.repLookUpWWTypeNo.NullText = "";
            this.repLookUpWWTypeNo.ValueMember = "WarehouseWarrantTypeNo";
            // 
            // colApprovalType
            // 
            this.colApprovalType.AppearanceHeader.Options.UseTextOptions = true;
            this.colApprovalType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colApprovalType.ColumnEdit = this.repLookUpApprovalType;
            this.colApprovalType.FieldName = "ApprovalType";
            this.colApprovalType.Name = "colApprovalType";
            this.colApprovalType.Visible = true;
            this.colApprovalType.VisibleIndex = 7;
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
            this.colRemark1.Visible = true;
            this.colRemark1.VisibleIndex = 9;
            this.colRemark1.Width = 100;
            // 
            // colCreator
            // 
            this.colCreator.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreator.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreator.ColumnEdit = this.repLookUpCreator;
            this.colCreator.FieldName = "Creator";
            this.colCreator.Name = "colCreator";
            this.colCreator.Visible = true;
            this.colCreator.VisibleIndex = 10;
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
            this.colModifier.FieldName = "ModifierId";
            this.colModifier.Name = "colModifier";
            this.colModifier.Visible = true;
            this.colModifier.VisibleIndex = 11;
            this.colModifier.Width = 70;
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
            this.colModifierTime.VisibleIndex = 12;
            this.colModifierTime.Width = 135;
            // 
            // repCheckSelect
            // 
            this.repCheckSelect.AutoHeight = false;
            this.repCheckSelect.Name = "repCheckSelect";
            this.repCheckSelect.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckSelect.ValueGrayed = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.gridBottomOrderHead);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 389);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1276, 58);
            this.pnlBottom.TabIndex = 5;
            // 
            // gridBottomOrderHead
            // 
            this.gridBottomOrderHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBottomOrderHead.Location = new System.Drawing.Point(2, 2);
            this.gridBottomOrderHead.MasterDataSet = this.dataSet_WW;
            this.gridBottomOrderHead.Name = "gridBottomOrderHead";
            this.gridBottomOrderHead.pageRowCount = 5;
            this.gridBottomOrderHead.Size = new System.Drawing.Size(1272, 54);
            this.gridBottomOrderHead.TabIndex = 0;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRkrqbnwkcx});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(317, 26);
            // 
            // tsmiRkrqbnwkcx
            // 
            this.tsmiRkrqbnwkcx.Name = "tsmiRkrqbnwkcx";
            this.tsmiRkrqbnwkcx.Size = new System.Drawing.Size(316, 22);
            this.tsmiRkrqbnwkcx.Text = "入库日期不能为空，请设置后重新进行查询。";
            // 
            // FrmWarehouseWarrantQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1276, 447);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnltop);
            this.Name = "FrmWarehouseWarrantQuery";
            this.TabText = "入库单查询";
            this.Text = "入库单查询";
            this.Activated += new System.EventHandler(this.FrmWarehouseWarrantQuery_Activated);
            this.Load += new System.EventHandler(this.FrmWarehouseWarrantQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreatorView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinorderListAutoId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkorderListAutoId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxWarehouseState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpWarehouseWarrantTypeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpBussinessBaseNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpBussinessBaseNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWWDateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWWDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWWDateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWWDateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_WW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableWWHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_WWHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWWHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWWHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchBussinessBaseNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryLocationId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpWWTypeNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnltop;
        private DevExpress.XtraEditors.LookUpEdit lookUpReqDep;
        private DevExpress.XtraEditors.LabelControl labReqDep;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxWarehouseState;
        private DevExpress.XtraEditors.LabelControl labWarehouseState;
        private DevExpress.XtraEditors.LookUpEdit lookUpWarehouseWarrantTypeNo;
        private DevExpress.XtraEditors.LabelControl labWarehouseWarrantTypeNo;
        private DevExpress.XtraEditors.LookUpEdit lookUpRepertoryId;
        private DevExpress.XtraEditors.LabelControl labRepertoryId;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.TextEdit textCommon;
        private DevExpress.XtraEditors.LabelControl labCommon;
        private DevExpress.XtraEditors.LabelControl labCreator;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpBussinessBaseNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpBussinessBaseNoView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBussinessBaseNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBussinessBaseText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBussinessCategoryText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAutoId;
        private DevExpress.XtraEditors.LabelControl labBussinessBaseNo;
        private DevExpress.XtraEditors.DateEdit dateWWDateEnd;
        private DevExpress.XtraEditors.LabelControl lab1;
        private DevExpress.XtraEditors.LabelControl labWWDate;
        private DevExpress.XtraEditors.DateEdit dateWWDateBegin;
        private System.Data.DataSet dataSet_WW;
        private System.Data.DataTable dataTableWWHead;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColWarehouseWarrant;
        private System.Data.DataColumn dataColWarehouseWarrantDate;
        private System.Data.DataColumn dataColBussinessBaseNo;
        private System.Data.DataColumn dataColRepertoryId;
        private System.Data.DataColumn dataColWarehouseWarrantTypeNo;
        private System.Data.DataColumn dataColPreparedIp;
        private System.Data.DataColumn dataColumnRemark;
        private System.Data.DataColumn dataColApprovalType;
        private System.Data.DataColumn dataColModifierIp;
        private System.Data.DataColumn dataColModifierTime;
        private System.Data.DataColumn dataColWarehouseState;
        private System.Data.DataColumn dataColReqDep;
        private System.Windows.Forms.BindingSource bindingSource_WWHead;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraGrid.GridControl gridControlWWHead;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWWHead;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseWarrant;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseState;
        private DevExpress.XtraGrid.Columns.GridColumn colReqDep;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpReqDep;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseWarrantDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBussinessBaseNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchBussinessBaseNo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCBussinessBaseNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridCBussinessBaseText;
        private DevExpress.XtraGrid.Columns.GridColumn gridCBussinessCategoryText;
        private DevExpress.XtraGrid.Columns.GridColumn gridCAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseWarrantTypeNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpWWTypeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovalType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpApprovalType;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colModifier;
        private DevExpress.XtraEditors.SimpleButton btnSaveExcel;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private GridBottom gridBottomOrderHead;
        private DevExpress.XtraEditors.SpinEdit spinorderListAutoId;
        private DevExpress.XtraEditors.CheckEdit checkorderListAutoId;
        internal System.Windows.Forms.ContextMenuStrip cms;
        internal System.Windows.Forms.ToolStripMenuItem tsmiRkrqbnwkcx;
        private DevExpress.XtraEditors.LabelControl labLocationId;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLocationId;
        private DevExpress.XtraGrid.Views.Grid.GridView SearchLocationIdView;
        private System.Data.DataColumn dataColRepertoryLocationId;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryLocationId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpRepertoryLocationId;
        private DevExpress.XtraGrid.Columns.GridColumn colModifierTime;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpCreator;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpCreatorView;
        private System.Data.DataColumn dataColCreator;
        private System.Data.DataColumn dataColModifierId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator;
    }
}