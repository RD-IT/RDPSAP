namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWarehouseReceiptQuery
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
            this.dataSet_WR = new System.Data.DataSet();
            this.dataTableWRHead = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColWarehouseReceipt = new System.Data.DataColumn();
            this.dataColWarehouseReceiptDate = new System.Data.DataColumn();
            this.dataColReqDep = new System.Data.DataColumn();
            this.dataColRepertoryId = new System.Data.DataColumn();
            this.dataColWarehouseReceiptTypeNo = new System.Data.DataColumn();
            this.dataColApprovalType = new System.Data.DataColumn();
            this.dataColPreparedIp = new System.Data.DataColumn();
            this.dataColModifierIp = new System.Data.DataColumn();
            this.dataColModifierTime = new System.Data.DataColumn();
            this.dataColRemark = new System.Data.DataColumn();
            this.dataColSelect = new System.Data.DataColumn();
            this.dataColWarehouseState = new System.Data.DataColumn();
            this.dataColManufactureNo = new System.Data.DataColumn();
            this.dataColRepertoryLocationId = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColModifierId = new System.Data.DataColumn();
            this.bindingSource_WRHead = new System.Windows.Forms.BindingSource(this.components);
            this.pnltop = new DevExpress.XtraEditors.PanelControl();
            this.searchLookUpCreator = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpCreatorView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labLocationId = new DevExpress.XtraEditors.LabelControl();
            this.SearchLocationId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.SearchLocationIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSaveExcel = new DevExpress.XtraEditors.SimpleButton();
            this.labManufactureNo = new DevExpress.XtraEditors.LabelControl();
            this.lookUpManufactureNo = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpReqDep = new DevExpress.XtraEditors.LookUpEdit();
            this.comboBoxWarehouseState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lookUpWarehouseReceiptTypeNo = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpRepertoryId = new DevExpress.XtraEditors.LookUpEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.textCommon = new DevExpress.XtraEditors.TextEdit();
            this.dateWRDateEnd = new DevExpress.XtraEditors.DateEdit();
            this.lab1 = new DevExpress.XtraEditors.LabelControl();
            this.dateWRDateBegin = new DevExpress.XtraEditors.DateEdit();
            this.labReqDep = new DevExpress.XtraEditors.LabelControl();
            this.labWarehouseReceiptTypeNo = new DevExpress.XtraEditors.LabelControl();
            this.labRepertoryId = new DevExpress.XtraEditors.LabelControl();
            this.labCommon = new DevExpress.XtraEditors.LabelControl();
            this.labCreator = new DevExpress.XtraEditors.LabelControl();
            this.labWarehouseState = new DevExpress.XtraEditors.LabelControl();
            this.labWRDate = new DevExpress.XtraEditors.LabelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.gridBottomOrderHead = new PSAP.VIEW.BSVIEW.GridBottom();
            this.gridControlWRHead = new DevExpress.XtraGrid.GridControl();
            this.gridViewWRHead = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseReceipt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReqDep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpReqDep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colWarehouseReceiptDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepertoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colWarehouseReceiptTypeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpWRTypeNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colApprovalType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpApprovalType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRemark1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModifierId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManufactureNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpManufactureNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRepertoryLocationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryLocationId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModifierTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCkrqbnwkcx = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_WR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableWRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_WRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreatorView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpManufactureNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxWarehouseState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpWarehouseReceiptTypeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWRDateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWRDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWRDateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWRDateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpWRTypeNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpManufactureNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryLocationId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSet_WR
            // 
            this.dataSet_WR.DataSetName = "NewDataSet";
            this.dataSet_WR.EnforceConstraints = false;
            this.dataSet_WR.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableWRHead});
            // 
            // dataTableWRHead
            // 
            this.dataTableWRHead.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColWarehouseReceipt,
            this.dataColWarehouseReceiptDate,
            this.dataColReqDep,
            this.dataColRepertoryId,
            this.dataColWarehouseReceiptTypeNo,
            this.dataColApprovalType,
            this.dataColPreparedIp,
            this.dataColModifierIp,
            this.dataColModifierTime,
            this.dataColRemark,
            this.dataColSelect,
            this.dataColWarehouseState,
            this.dataColManufactureNo,
            this.dataColRepertoryLocationId,
            this.dataColCreator,
            this.dataColModifierId});
            this.dataTableWRHead.TableName = "WRHead";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColWarehouseReceipt
            // 
            this.dataColWarehouseReceipt.Caption = "出库单号";
            this.dataColWarehouseReceipt.ColumnName = "WarehouseReceipt";
            // 
            // dataColWarehouseReceiptDate
            // 
            this.dataColWarehouseReceiptDate.Caption = "出库日期";
            this.dataColWarehouseReceiptDate.ColumnName = "WarehouseReceiptDate";
            this.dataColWarehouseReceiptDate.DataType = typeof(System.DateTime);
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
            // dataColWarehouseReceiptTypeNo
            // 
            this.dataColWarehouseReceiptTypeNo.Caption = "出库类别";
            this.dataColWarehouseReceiptTypeNo.ColumnName = "WarehouseReceiptTypeNo";
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
            // dataColManufactureNo
            // 
            this.dataColManufactureNo.Caption = "出库工程";
            this.dataColManufactureNo.ColumnName = "ManufactureNo";
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
            // bindingSource_WRHead
            // 
            this.bindingSource_WRHead.DataMember = "WRHead";
            this.bindingSource_WRHead.DataSource = this.dataSet_WR;
            // 
            // pnltop
            // 
            this.pnltop.Controls.Add(this.searchLookUpCreator);
            this.pnltop.Controls.Add(this.labLocationId);
            this.pnltop.Controls.Add(this.SearchLocationId);
            this.pnltop.Controls.Add(this.btnSaveExcel);
            this.pnltop.Controls.Add(this.labManufactureNo);
            this.pnltop.Controls.Add(this.lookUpManufactureNo);
            this.pnltop.Controls.Add(this.lookUpReqDep);
            this.pnltop.Controls.Add(this.comboBoxWarehouseState);
            this.pnltop.Controls.Add(this.lookUpWarehouseReceiptTypeNo);
            this.pnltop.Controls.Add(this.lookUpRepertoryId);
            this.pnltop.Controls.Add(this.btnQuery);
            this.pnltop.Controls.Add(this.textCommon);
            this.pnltop.Controls.Add(this.dateWRDateEnd);
            this.pnltop.Controls.Add(this.lab1);
            this.pnltop.Controls.Add(this.dateWRDateBegin);
            this.pnltop.Controls.Add(this.labReqDep);
            this.pnltop.Controls.Add(this.labWarehouseReceiptTypeNo);
            this.pnltop.Controls.Add(this.labRepertoryId);
            this.pnltop.Controls.Add(this.labCommon);
            this.pnltop.Controls.Add(this.labCreator);
            this.pnltop.Controls.Add(this.labWarehouseState);
            this.pnltop.Controls.Add(this.labWRDate);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1166, 78);
            this.pnltop.TabIndex = 2;
            // 
            // searchLookUpCreator
            // 
            this.searchLookUpCreator.Location = new System.Drawing.Point(479, 44);
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
            this.labLocationId.Location = new System.Drawing.Point(522, 17);
            this.labLocationId.Name = "labLocationId";
            this.labLocationId.Size = new System.Drawing.Size(60, 14);
            this.labLocationId.TabIndex = 39;
            this.labLocationId.Text = "出库仓位：";
            // 
            // SearchLocationId
            // 
            this.SearchLocationId.EnterMoveNextControl = true;
            this.SearchLocationId.Location = new System.Drawing.Point(588, 14);
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
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(941, 43);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveExcel.TabIndex = 35;
            this.btnSaveExcel.Text = "存为Excel";
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // labManufactureNo
            // 
            this.labManufactureNo.Location = new System.Drawing.Point(20, 47);
            this.labManufactureNo.Name = "labManufactureNo";
            this.labManufactureNo.Size = new System.Drawing.Size(60, 14);
            this.labManufactureNo.TabIndex = 34;
            this.labManufactureNo.Text = "出库工程：";
            // 
            // lookUpManufactureNo
            // 
            this.lookUpManufactureNo.EnterMoveNextControl = true;
            this.lookUpManufactureNo.Location = new System.Drawing.Point(86, 44);
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
            this.lookUpManufactureNo.TabIndex = 6;
            // 
            // lookUpReqDep
            // 
            this.lookUpReqDep.EnterMoveNextControl = true;
            this.lookUpReqDep.Location = new System.Drawing.Point(993, 14);
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
            this.comboBoxWarehouseState.Location = new System.Drawing.Point(289, 44);
            this.comboBoxWarehouseState.Name = "comboBoxWarehouseState";
            this.comboBoxWarehouseState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxWarehouseState.Size = new System.Drawing.Size(120, 20);
            this.comboBoxWarehouseState.TabIndex = 7;
            // 
            // lookUpWarehouseReceiptTypeNo
            // 
            this.lookUpWarehouseReceiptTypeNo.EnterMoveNextControl = true;
            this.lookUpWarehouseReceiptTypeNo.Location = new System.Drawing.Point(791, 14);
            this.lookUpWarehouseReceiptTypeNo.Name = "lookUpWarehouseReceiptTypeNo";
            this.lookUpWarehouseReceiptTypeNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpWarehouseReceiptTypeNo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseReceiptTypeNo", "类别编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseReceiptTypeName", "类别名称")});
            this.lookUpWarehouseReceiptTypeNo.Properties.DisplayMember = "WarehouseReceiptTypeName";
            this.lookUpWarehouseReceiptTypeNo.Properties.NullText = "";
            this.lookUpWarehouseReceiptTypeNo.Properties.ValueMember = "WarehouseReceiptTypeNo";
            this.lookUpWarehouseReceiptTypeNo.Size = new System.Drawing.Size(120, 20);
            this.lookUpWarehouseReceiptTypeNo.TabIndex = 4;
            // 
            // lookUpRepertoryId
            // 
            this.lookUpRepertoryId.EnterMoveNextControl = true;
            this.lookUpRepertoryId.Location = new System.Drawing.Point(385, 14);
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
            this.btnQuery.Location = new System.Drawing.Point(850, 43);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // textCommon
            // 
            this.textCommon.EnterMoveNextControl = true;
            this.textCommon.Location = new System.Drawing.Point(683, 44);
            this.textCommon.Name = "textCommon";
            this.textCommon.Size = new System.Drawing.Size(150, 20);
            this.textCommon.TabIndex = 9;
            // 
            // dateWRDateEnd
            // 
            this.dateWRDateEnd.EditValue = null;
            this.dateWRDateEnd.EnterMoveNextControl = true;
            this.dateWRDateEnd.Location = new System.Drawing.Point(202, 14);
            this.dateWRDateEnd.Name = "dateWRDateEnd";
            this.dateWRDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWRDateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWRDateEnd.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateWRDateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWRDateEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateWRDateEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWRDateEnd.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateWRDateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateWRDateEnd.TabIndex = 1;
            // 
            // lab1
            // 
            this.lab1.Location = new System.Drawing.Point(192, 17);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(4, 14);
            this.lab1.TabIndex = 6;
            this.lab1.Text = "-";
            // 
            // dateWRDateBegin
            // 
            this.dateWRDateBegin.EditValue = null;
            this.dateWRDateBegin.EnterMoveNextControl = true;
            this.dateWRDateBegin.Location = new System.Drawing.Point(86, 14);
            this.dateWRDateBegin.Name = "dateWRDateBegin";
            this.dateWRDateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWRDateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWRDateBegin.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateWRDateBegin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWRDateBegin.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateWRDateBegin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWRDateBegin.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateWRDateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateWRDateBegin.TabIndex = 0;
            // 
            // labReqDep
            // 
            this.labReqDep.Location = new System.Drawing.Point(927, 17);
            this.labReqDep.Name = "labReqDep";
            this.labReqDep.Size = new System.Drawing.Size(60, 14);
            this.labReqDep.TabIndex = 32;
            this.labReqDep.Text = "出库部门：";
            // 
            // labWarehouseReceiptTypeNo
            // 
            this.labWarehouseReceiptTypeNo.Location = new System.Drawing.Point(725, 17);
            this.labWarehouseReceiptTypeNo.Name = "labWarehouseReceiptTypeNo";
            this.labWarehouseReceiptTypeNo.Size = new System.Drawing.Size(60, 14);
            this.labWarehouseReceiptTypeNo.TabIndex = 28;
            this.labWarehouseReceiptTypeNo.Text = "出库类别：";
            // 
            // labRepertoryId
            // 
            this.labRepertoryId.Location = new System.Drawing.Point(319, 17);
            this.labRepertoryId.Name = "labRepertoryId";
            this.labRepertoryId.Size = new System.Drawing.Size(60, 14);
            this.labRepertoryId.TabIndex = 26;
            this.labRepertoryId.Text = "出库仓库：";
            // 
            // labCommon
            // 
            this.labCommon.Location = new System.Drawing.Point(617, 47);
            this.labCommon.Name = "labCommon";
            this.labCommon.Size = new System.Drawing.Size(60, 14);
            this.labCommon.TabIndex = 22;
            this.labCommon.Text = "通用查询：";
            // 
            // labCreator
            // 
            this.labCreator.Location = new System.Drawing.Point(425, 47);
            this.labCreator.Name = "labCreator";
            this.labCreator.Size = new System.Drawing.Size(48, 14);
            this.labCreator.TabIndex = 20;
            this.labCreator.Text = "制单人：";
            // 
            // labWarehouseState
            // 
            this.labWarehouseState.Location = new System.Drawing.Point(223, 47);
            this.labWarehouseState.Name = "labWarehouseState";
            this.labWarehouseState.Size = new System.Drawing.Size(60, 14);
            this.labWarehouseState.TabIndex = 30;
            this.labWarehouseState.Text = "单据状态：";
            // 
            // labWRDate
            // 
            this.labWRDate.Location = new System.Drawing.Point(20, 17);
            this.labWRDate.Name = "labWRDate";
            this.labWRDate.Size = new System.Drawing.Size(60, 14);
            this.labWRDate.TabIndex = 5;
            this.labWRDate.Text = "出库日期：";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.gridBottomOrderHead);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 389);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1166, 58);
            this.pnlBottom.TabIndex = 6;
            // 
            // gridBottomOrderHead
            // 
            this.gridBottomOrderHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBottomOrderHead.Location = new System.Drawing.Point(2, 2);
            this.gridBottomOrderHead.MasterDataSet = this.dataSet_WR;
            this.gridBottomOrderHead.Name = "gridBottomOrderHead";
            this.gridBottomOrderHead.pageRowCount = 5;
            this.gridBottomOrderHead.Size = new System.Drawing.Size(1162, 54);
            this.gridBottomOrderHead.TabIndex = 0;
            // 
            // gridControlWRHead
            // 
            this.gridControlWRHead.DataSource = this.bindingSource_WRHead;
            this.gridControlWRHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlWRHead.Location = new System.Drawing.Point(2, 2);
            this.gridControlWRHead.MainView = this.gridViewWRHead;
            this.gridControlWRHead.Name = "gridControlWRHead";
            this.gridControlWRHead.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpRepertoryId,
            this.repLookUpWRTypeNo,
            this.repCheckSelect,
            this.repLookUpApprovalType,
            this.repLookUpReqDep,
            this.repLookUpManufactureNo,
            this.repLookUpRepertoryLocationId,
            this.repLookUpCreator});
            this.gridControlWRHead.Size = new System.Drawing.Size(1162, 307);
            this.gridControlWRHead.TabIndex = 7;
            this.gridControlWRHead.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWRHead});
            // 
            // gridViewWRHead
            // 
            this.gridViewWRHead.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colWarehouseReceipt,
            this.colWarehouseState,
            this.colReqDep,
            this.colWarehouseReceiptDate,
            this.colRepertoryId,
            this.colWarehouseReceiptTypeNo,
            this.colApprovalType,
            this.colRemark1,
            this.colCreator,
            this.colModifierId,
            this.colManufactureNo,
            this.colRepertoryLocationId,
            this.colModifierTime});
            this.gridViewWRHead.GridControl = this.gridControlWRHead;
            this.gridViewWRHead.IndicatorWidth = 40;
            this.gridViewWRHead.Name = "gridViewWRHead";
            this.gridViewWRHead.OptionsBehavior.Editable = false;
            this.gridViewWRHead.OptionsBehavior.ReadOnly = true;
            this.gridViewWRHead.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewWRHead.OptionsView.ColumnAutoWidth = false;
            this.gridViewWRHead.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewWRHead.OptionsView.ShowFooter = true;
            this.gridViewWRHead.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewWRHead_RowClick);
            this.gridViewWRHead.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewWRHead_CustomDrawRowIndicator);
            this.gridViewWRHead.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewWRHead_CustomColumnDisplayText);
            this.gridViewWRHead.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewWRHead_KeyDown);
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colWarehouseReceipt
            // 
            this.colWarehouseReceipt.AppearanceHeader.Options.UseTextOptions = true;
            this.colWarehouseReceipt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWarehouseReceipt.FieldName = "WarehouseReceipt";
            this.colWarehouseReceipt.Name = "colWarehouseReceipt";
            this.colWarehouseReceipt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "WarehouseWarrant", "共计{0}条")});
            this.colWarehouseReceipt.Visible = true;
            this.colWarehouseReceipt.VisibleIndex = 0;
            this.colWarehouseReceipt.Width = 110;
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
            // colWarehouseReceiptDate
            // 
            this.colWarehouseReceiptDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colWarehouseReceiptDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWarehouseReceiptDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colWarehouseReceiptDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colWarehouseReceiptDate.FieldName = "WarehouseReceiptDate";
            this.colWarehouseReceiptDate.Name = "colWarehouseReceiptDate";
            this.colWarehouseReceiptDate.Visible = true;
            this.colWarehouseReceiptDate.VisibleIndex = 2;
            this.colWarehouseReceiptDate.Width = 135;
            // 
            // colRepertoryId
            // 
            this.colRepertoryId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRepertoryId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRepertoryId.ColumnEdit = this.repLookUpRepertoryId;
            this.colRepertoryId.FieldName = "RepertoryId";
            this.colRepertoryId.Name = "colRepertoryId";
            this.colRepertoryId.Visible = true;
            this.colRepertoryId.VisibleIndex = 3;
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
            // colWarehouseReceiptTypeNo
            // 
            this.colWarehouseReceiptTypeNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colWarehouseReceiptTypeNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWarehouseReceiptTypeNo.ColumnEdit = this.repLookUpWRTypeNo;
            this.colWarehouseReceiptTypeNo.FieldName = "WarehouseReceiptTypeNo";
            this.colWarehouseReceiptTypeNo.Name = "colWarehouseReceiptTypeNo";
            this.colWarehouseReceiptTypeNo.Visible = true;
            this.colWarehouseReceiptTypeNo.VisibleIndex = 5;
            this.colWarehouseReceiptTypeNo.Width = 100;
            // 
            // repLookUpWRTypeNo
            // 
            this.repLookUpWRTypeNo.AutoHeight = false;
            this.repLookUpWRTypeNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpWRTypeNo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseReceiptTypeNo", "类别编号", 81, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseReceiptTypeName", "类别名称", 111, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repLookUpWRTypeNo.DisplayMember = "WarehouseReceiptTypeName";
            this.repLookUpWRTypeNo.Name = "repLookUpWRTypeNo";
            this.repLookUpWRTypeNo.NullText = "";
            this.repLookUpWRTypeNo.ValueMember = "WarehouseReceiptTypeNo";
            // 
            // colApprovalType
            // 
            this.colApprovalType.AppearanceHeader.Options.UseTextOptions = true;
            this.colApprovalType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colApprovalType.ColumnEdit = this.repLookUpApprovalType;
            this.colApprovalType.FieldName = "ApprovalType";
            this.colApprovalType.Name = "colApprovalType";
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
            // colModifierId
            // 
            this.colModifierId.AppearanceHeader.Options.UseTextOptions = true;
            this.colModifierId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifierId.ColumnEdit = this.repLookUpCreator;
            this.colModifierId.FieldName = "ModifierId";
            this.colModifierId.Name = "colModifierId";
            this.colModifierId.Visible = true;
            this.colModifierId.VisibleIndex = 11;
            this.colModifierId.Width = 70;
            // 
            // colManufactureNo
            // 
            this.colManufactureNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colManufactureNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colManufactureNo.ColumnEdit = this.repLookUpManufactureNo;
            this.colManufactureNo.FieldName = "ManufactureNo";
            this.colManufactureNo.Name = "colManufactureNo";
            this.colManufactureNo.Visible = true;
            this.colManufactureNo.VisibleIndex = 7;
            this.colManufactureNo.Width = 100;
            // 
            // repLookUpManufactureNo
            // 
            this.repLookUpManufactureNo.AutoHeight = false;
            this.repLookUpManufactureNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpManufactureNo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManufactureNo", "工程编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManufactureName", "工程名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManufactureType", "工程类型")});
            this.repLookUpManufactureNo.DisplayMember = "ManufactureName";
            this.repLookUpManufactureNo.Name = "repLookUpManufactureNo";
            this.repLookUpManufactureNo.NullText = "";
            this.repLookUpManufactureNo.ValueMember = "ManufactureNo";
            // 
            // colRepertoryLocationId
            // 
            this.colRepertoryLocationId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRepertoryLocationId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRepertoryLocationId.ColumnEdit = this.repLookUpRepertoryLocationId;
            this.colRepertoryLocationId.FieldName = "RepertoryLocationId";
            this.colRepertoryLocationId.Name = "colRepertoryLocationId";
            this.colRepertoryLocationId.Visible = true;
            this.colRepertoryLocationId.VisibleIndex = 4;
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
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.gridControlWRHead);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 78);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1166, 311);
            this.pnlMiddle.TabIndex = 8;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCkrqbnwkcx});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(317, 26);
            // 
            // tsmiCkrqbnwkcx
            // 
            this.tsmiCkrqbnwkcx.Name = "tsmiCkrqbnwkcx";
            this.tsmiCkrqbnwkcx.Size = new System.Drawing.Size(316, 22);
            this.tsmiCkrqbnwkcx.Text = "出库日期不能为空，请设置后重新进行查询。";
            // 
            // FrmWarehouseReceiptQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1166, 447);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnltop);
            this.Name = "FrmWarehouseReceiptQuery";
            this.TabText = "材料出库查询";
            this.Text = "材料出库查询";
            this.Load += new System.EventHandler(this.FrmWarehouseReceiptQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_WR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableWRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_WRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreatorView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpManufactureNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxWarehouseState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpWarehouseReceiptTypeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWRDateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWRDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWRDateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWRDateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpWRTypeNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpManufactureNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryLocationId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSet_WR;
        private System.Data.DataTable dataTableWRHead;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColWarehouseReceipt;
        private System.Data.DataColumn dataColWarehouseReceiptDate;
        private System.Data.DataColumn dataColReqDep;
        private System.Data.DataColumn dataColRepertoryId;
        private System.Data.DataColumn dataColWarehouseReceiptTypeNo;
        private System.Data.DataColumn dataColApprovalType;
        private System.Data.DataColumn dataColPreparedIp;
        private System.Data.DataColumn dataColModifierIp;
        private System.Data.DataColumn dataColModifierTime;
        private System.Data.DataColumn dataColRemark;
        private System.Data.DataColumn dataColSelect;
        private System.Data.DataColumn dataColWarehouseState;
        private System.Data.DataColumn dataColManufactureNo;
        private System.Windows.Forms.BindingSource bindingSource_WRHead;
        private DevExpress.XtraEditors.PanelControl pnltop;
        private DevExpress.XtraEditors.LabelControl labManufactureNo;
        private DevExpress.XtraEditors.LookUpEdit lookUpManufactureNo;
        private DevExpress.XtraEditors.LookUpEdit lookUpReqDep;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxWarehouseState;
        private DevExpress.XtraEditors.LookUpEdit lookUpWarehouseReceiptTypeNo;
        private DevExpress.XtraEditors.LookUpEdit lookUpRepertoryId;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.TextEdit textCommon;
        private DevExpress.XtraEditors.DateEdit dateWRDateEnd;
        private DevExpress.XtraEditors.LabelControl lab1;
        private DevExpress.XtraEditors.DateEdit dateWRDateBegin;
        private DevExpress.XtraEditors.LabelControl labReqDep;
        private DevExpress.XtraEditors.LabelControl labWarehouseReceiptTypeNo;
        private DevExpress.XtraEditors.LabelControl labRepertoryId;
        private DevExpress.XtraEditors.LabelControl labCommon;
        private DevExpress.XtraEditors.LabelControl labCreator;
        private DevExpress.XtraEditors.LabelControl labWarehouseState;
        private DevExpress.XtraEditors.LabelControl labWRDate;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private GridBottom gridBottomOrderHead;
        private DevExpress.XtraGrid.GridControl gridControlWRHead;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWRHead;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseReceipt;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseState;
        private DevExpress.XtraGrid.Columns.GridColumn colReqDep;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpReqDep;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseReceiptDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseReceiptTypeNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpWRTypeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovalType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpApprovalType;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colModifierId;
        private DevExpress.XtraGrid.Columns.GridColumn colManufactureNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpManufactureNo;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraEditors.SimpleButton btnSaveExcel;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiCkrqbnwkcx;
        private System.Data.DataColumn dataColRepertoryLocationId;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryLocationId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpRepertoryLocationId;
        private DevExpress.XtraEditors.LabelControl labLocationId;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLocationId;
        private DevExpress.XtraGrid.Views.Grid.GridView SearchLocationIdView;
        private DevExpress.XtraGrid.Columns.GridColumn colModifierTime;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpCreator;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpCreatorView;
        private System.Data.DataColumn dataColCreator;
        private System.Data.DataColumn dataColModifierId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator;
    }
}