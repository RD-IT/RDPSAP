namespace PSAP.VIEW.BSVIEW
{
    partial class FrmSpecialWarehouseReceiptQuery
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
            this.dataColWarehouseState = new System.Data.DataColumn();
            this.dataColRepertoryLocationId = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColModifierId = new System.Data.DataColumn();
            this.bindingSource_SWRHead = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.gridBottomOrderHead = new PSAP.VIEW.BSVIEW.GridBottom();
            this.pnltop = new DevExpress.XtraEditors.PanelControl();
            this.searchLookUpCreator = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpCreatorView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labLocationId = new DevExpress.XtraEditors.LabelControl();
            this.SearchLocationId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.SearchLocationIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSaveExcel = new DevExpress.XtraEditors.SimpleButton();
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
            this.labCommon = new DevExpress.XtraEditors.LabelControl();
            this.labCreator = new DevExpress.XtraEditors.LabelControl();
            this.labWarehouseState = new DevExpress.XtraEditors.LabelControl();
            this.labSWRDate = new DevExpress.XtraEditors.LabelControl();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.gridControlSWRHead = new DevExpress.XtraGrid.GridControl();
            this.gridViewSWRHead = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseReceipt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReqDep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpReqDep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colWarehouseReceiptDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepertoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colApprovalType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpApprovalType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRemark1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModifierId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepertoryLocationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryLocationId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModifierTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_SWR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSWRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SWRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSWRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSWRHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryLocationId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet_SWR
            // 
            this.dataSet_SWR.DataSetName = "NewDataSet";
            this.dataSet_SWR.EnforceConstraints = false;
            this.dataSet_SWR.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableSWRHead});
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
            // bindingSource_SWRHead
            // 
            this.bindingSource_SWRHead.DataMember = "SWRHead";
            this.bindingSource_SWRHead.DataSource = this.dataSet_SWR;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.gridBottomOrderHead);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 503);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1224, 58);
            this.pnlBottom.TabIndex = 7;
            // 
            // gridBottomOrderHead
            // 
            this.gridBottomOrderHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBottomOrderHead.Location = new System.Drawing.Point(2, 2);
            this.gridBottomOrderHead.MasterDataSet = this.dataSet_SWR;
            this.gridBottomOrderHead.Name = "gridBottomOrderHead";
            this.gridBottomOrderHead.pageRowCount = 5;
            this.gridBottomOrderHead.Size = new System.Drawing.Size(1220, 54);
            this.gridBottomOrderHead.TabIndex = 0;
            // 
            // pnltop
            // 
            this.pnltop.Controls.Add(this.searchLookUpCreator);
            this.pnltop.Controls.Add(this.labLocationId);
            this.pnltop.Controls.Add(this.SearchLocationId);
            this.pnltop.Controls.Add(this.btnSaveExcel);
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
            this.pnltop.Controls.Add(this.labCommon);
            this.pnltop.Controls.Add(this.labCreator);
            this.pnltop.Controls.Add(this.labWarehouseState);
            this.pnltop.Controls.Add(this.labSWRDate);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Margin = new System.Windows.Forms.Padding(4);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1224, 78);
            this.pnltop.TabIndex = 8;
            // 
            // searchLookUpCreator
            // 
            this.searchLookUpCreator.Location = new System.Drawing.Point(278, 44);
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
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(753, 43);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveExcel.TabIndex = 9;
            this.btnSaveExcel.Text = "存为Excel";
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
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
            this.btnQuery.Location = new System.Drawing.Point(659, 43);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // textCommon
            // 
            this.textCommon.EnterMoveNextControl = true;
            this.textCommon.Location = new System.Drawing.Point(484, 44);
            this.textCommon.Margin = new System.Windows.Forms.Padding(4);
            this.textCommon.Name = "textCommon";
            this.textCommon.Size = new System.Drawing.Size(150, 20);
            this.textCommon.TabIndex = 7;
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
            // labCommon
            // 
            this.labCommon.Location = new System.Drawing.Point(416, 47);
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
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.gridControlSWRHead);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 78);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1224, 425);
            this.pnlMiddle.TabIndex = 9;
            // 
            // gridControlSWRHead
            // 
            this.gridControlSWRHead.DataSource = this.bindingSource_SWRHead;
            this.gridControlSWRHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSWRHead.Location = new System.Drawing.Point(2, 2);
            this.gridControlSWRHead.MainView = this.gridViewSWRHead;
            this.gridControlSWRHead.Name = "gridControlSWRHead";
            this.gridControlSWRHead.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpRepertoryId,
            this.repCheckSelect,
            this.repLookUpApprovalType,
            this.repLookUpReqDep,
            this.repLookUpRepertoryLocationId,
            this.repLookUpCreator});
            this.gridControlSWRHead.Size = new System.Drawing.Size(1220, 421);
            this.gridControlSWRHead.TabIndex = 7;
            this.gridControlSWRHead.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSWRHead});
            // 
            // gridViewSWRHead
            // 
            this.gridViewSWRHead.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colWarehouseReceipt,
            this.colWarehouseState,
            this.colReqDep,
            this.colWarehouseReceiptDate,
            this.colRepertoryId,
            this.colApprovalType,
            this.colRemark1,
            this.colCreator,
            this.colModifierId,
            this.colRepertoryLocationId,
            this.colModifierTime});
            this.gridViewSWRHead.GridControl = this.gridControlSWRHead;
            this.gridViewSWRHead.IndicatorWidth = 40;
            this.gridViewSWRHead.Name = "gridViewSWRHead";
            this.gridViewSWRHead.OptionsBehavior.Editable = false;
            this.gridViewSWRHead.OptionsBehavior.ReadOnly = true;
            this.gridViewSWRHead.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewSWRHead.OptionsView.ColumnAutoWidth = false;
            this.gridViewSWRHead.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewSWRHead.OptionsView.ShowFooter = true;
            this.gridViewSWRHead.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewSWRHead_RowClick);
            this.gridViewSWRHead.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewSWRHead_CustomDrawRowIndicator);
            this.gridViewSWRHead.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewSWRHead_CustomColumnDisplayText);
            this.gridViewSWRHead.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewSWRHead_KeyDown);
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
            this.colWarehouseReceipt.FieldName = "SpecialWarehouseReceipt";
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
            this.colReqDep.VisibleIndex = 6;
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
            this.colWarehouseReceiptDate.FieldName = "SpecialWarehouseReceiptDate";
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
            // colApprovalType
            // 
            this.colApprovalType.AppearanceHeader.Options.UseTextOptions = true;
            this.colApprovalType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colApprovalType.ColumnEdit = this.repLookUpApprovalType;
            this.colApprovalType.FieldName = "ApprovalType";
            this.colApprovalType.Name = "colApprovalType";
            this.colApprovalType.Visible = true;
            this.colApprovalType.VisibleIndex = 5;
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
            this.colCreator.Visible = true;
            this.colCreator.VisibleIndex = 8;
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
            this.colModifierId.VisibleIndex = 9;
            this.colModifierId.Width = 70;
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
            this.colModifierTime.VisibleIndex = 10;
            this.colModifierTime.Width = 135;
            // 
            // repCheckSelect
            // 
            this.repCheckSelect.AutoHeight = false;
            this.repCheckSelect.Name = "repCheckSelect";
            this.repCheckSelect.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckSelect.ValueGrayed = false;
            // 
            // FrmSpecialWarehouseReceiptQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1224, 561);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnltop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "FrmSpecialWarehouseReceiptQuery";
            this.TabText = "预算外出库单查询";
            this.Text = "预算外出库单查询";
            this.Load += new System.EventHandler(this.FrmSpecialWarehouseReceiptQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_SWR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSWRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SWRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSWRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSWRHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryLocationId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).EndInit();
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
        private System.Data.DataColumn dataColWarehouseState;
        private System.Windows.Forms.BindingSource bindingSource_SWRHead;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private GridBottom gridBottomOrderHead;
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
        private DevExpress.XtraEditors.LabelControl labCommon;
        private DevExpress.XtraEditors.LabelControl labCreator;
        private DevExpress.XtraEditors.LabelControl labWarehouseState;
        private DevExpress.XtraEditors.LabelControl labSWRDate;
        private DevExpress.XtraEditors.SimpleButton btnSaveExcel;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraGrid.GridControl gridControlSWRHead;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSWRHead;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseReceipt;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseState;
        private DevExpress.XtraGrid.Columns.GridColumn colReqDep;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpReqDep;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseReceiptDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovalType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpApprovalType;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colModifierId;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckSelect;
        private System.Data.DataColumn dataColRepertoryLocationId;
        private DevExpress.XtraEditors.LabelControl labLocationId;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLocationId;
        private DevExpress.XtraGrid.Views.Grid.GridView SearchLocationIdView;
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