namespace PSAP.VIEW.BSVIEW
{
    partial class FrmPrReqQuery
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
            this.btnSaveExcel = new DevExpress.XtraEditors.SimpleButton();
            this.textCommon = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxReqState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lookUpPurCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpReqDep = new DevExpress.XtraEditors.LookUpEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.dateReqDateEnd = new DevExpress.XtraEditors.DateEdit();
            this.lab = new DevExpress.XtraEditors.LabelControl();
            this.dateReqDateBegin = new DevExpress.XtraEditors.DateEdit();
            this.labCommon = new DevExpress.XtraEditors.LabelControl();
            this.labCreator = new DevExpress.XtraEditors.LabelControl();
            this.labReqState = new DevExpress.XtraEditors.LabelControl();
            this.labPurCategory = new DevExpress.XtraEditors.LabelControl();
            this.labReqDep = new DevExpress.XtraEditors.LabelControl();
            this.labReqDate = new DevExpress.XtraEditors.LabelControl();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.gridControlPrReqHead = new DevExpress.XtraGrid.GridControl();
            this.bindingSource_PrReqHead = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_PrReq = new System.Data.DataSet();
            this.dataTablePrReqHead = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColPrReqNo = new System.Data.DataColumn();
            this.dataColReqDate = new System.Data.DataColumn();
            this.dataColReqDep = new System.Data.DataColumn();
            this.dataColProjectNo = new System.Data.DataColumn();
            this.dataColStnNo = new System.Data.DataColumn();
            this.dataColPurCategory = new System.Data.DataColumn();
            this.dataColReqState = new System.Data.DataColumn();
            this.dataColApplicantIp = new System.Data.DataColumn();
            this.dataColApplicantTime = new System.Data.DataColumn();
            this.dataColModifierIp = new System.Data.DataColumn();
            this.dataColModifierTime = new System.Data.DataColumn();
            this.dataColApprover = new System.Data.DataColumn();
            this.dataColApproverIp = new System.Data.DataColumn();
            this.dataColApproverTime = new System.Data.DataColumn();
            this.dataColPrReqRemark = new System.Data.DataColumn();
            this.dataColClosedIp = new System.Data.DataColumn();
            this.dataColClosedTime = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColModifierId = new System.Data.DataColumn();
            this.dataColClosedId = new System.Data.DataColumn();
            this.gridViewPrReqHead = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrReqNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReqState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReqDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReqDep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpReqDep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpPurCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModifierId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClosedId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrReqRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifierTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClosedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.gridBottomPrReq = new PSAP.VIEW.BSVIEW.GridBottom();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQgrq = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCxan = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCxjgc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSjcx = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreatorView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxReqState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpPurCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrReqHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_PrReqHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_PrReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTablePrReqHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPrReqHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpPurCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnltop
            // 
            this.pnltop.Controls.Add(this.searchLookUpCreator);
            this.pnltop.Controls.Add(this.btnSaveExcel);
            this.pnltop.Controls.Add(this.textCommon);
            this.pnltop.Controls.Add(this.comboBoxReqState);
            this.pnltop.Controls.Add(this.lookUpPurCategory);
            this.pnltop.Controls.Add(this.lookUpReqDep);
            this.pnltop.Controls.Add(this.btnQuery);
            this.pnltop.Controls.Add(this.dateReqDateEnd);
            this.pnltop.Controls.Add(this.lab);
            this.pnltop.Controls.Add(this.dateReqDateBegin);
            this.pnltop.Controls.Add(this.labCommon);
            this.pnltop.Controls.Add(this.labCreator);
            this.pnltop.Controls.Add(this.labReqState);
            this.pnltop.Controls.Add(this.labPurCategory);
            this.pnltop.Controls.Add(this.labReqDep);
            this.pnltop.Controls.Add(this.labReqDate);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1385, 78);
            this.pnltop.TabIndex = 1;
            // 
            // searchLookUpCreator
            // 
            this.searchLookUpCreator.Location = new System.Drawing.Point(274, 44);
            this.searchLookUpCreator.Name = "searchLookUpCreator";
            this.searchLookUpCreator.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpCreator.Properties.View = this.searchLookUpCreatorView;
            this.searchLookUpCreator.Size = new System.Drawing.Size(120, 20);
            this.searchLookUpCreator.TabIndex = 5;
            // 
            // searchLookUpCreatorView
            // 
            this.searchLookUpCreatorView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpCreatorView.Name = "searchLookUpCreatorView";
            this.searchLookUpCreatorView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpCreatorView.OptionsView.ShowGroupPanel = false;
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(732, 43);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveExcel.TabIndex = 8;
            this.btnSaveExcel.Text = "存为Excel";
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // textCommon
            // 
            this.textCommon.EnterMoveNextControl = true;
            this.textCommon.Location = new System.Drawing.Point(476, 44);
            this.textCommon.Name = "textCommon";
            this.textCommon.Size = new System.Drawing.Size(150, 20);
            this.textCommon.TabIndex = 6;
            // 
            // comboBoxReqState
            // 
            this.comboBoxReqState.EnterMoveNextControl = true;
            this.comboBoxReqState.Location = new System.Drawing.Point(86, 44);
            this.comboBoxReqState.Name = "comboBoxReqState";
            this.comboBoxReqState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxReqState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxReqState.Size = new System.Drawing.Size(120, 20);
            this.comboBoxReqState.TabIndex = 4;
            // 
            // lookUpPurCategory
            // 
            this.lookUpPurCategory.EnterMoveNextControl = true;
            this.lookUpPurCategory.Location = new System.Drawing.Point(582, 14);
            this.lookUpPurCategory.Name = "lookUpPurCategory";
            this.lookUpPurCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpPurCategory.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurCategory", "编号", 81, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurCategoryText", "名称", 111, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpPurCategory.Properties.DisplayMember = "PurCategoryText";
            this.lookUpPurCategory.Properties.NullText = "";
            this.lookUpPurCategory.Properties.ValueMember = "PurCategory";
            this.lookUpPurCategory.Size = new System.Drawing.Size(120, 20);
            this.lookUpPurCategory.TabIndex = 3;
            // 
            // lookUpReqDep
            // 
            this.lookUpReqDep.EnterMoveNextControl = true;
            this.lookUpReqDep.Location = new System.Drawing.Point(381, 14);
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
            this.lookUpReqDep.TabIndex = 2;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(642, 43);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dateReqDateEnd
            // 
            this.dateReqDateEnd.EditValue = null;
            this.dateReqDateEnd.EnterMoveNextControl = true;
            this.dateReqDateEnd.Location = new System.Drawing.Point(202, 14);
            this.dateReqDateEnd.Name = "dateReqDateEnd";
            this.dateReqDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateReqDateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateReqDateEnd.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateReqDateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateReqDateEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateReqDateEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateReqDateEnd.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateReqDateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateReqDateEnd.TabIndex = 1;
            // 
            // lab
            // 
            this.lab.Location = new System.Drawing.Point(192, 17);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(4, 14);
            this.lab.TabIndex = 2;
            this.lab.Text = "-";
            // 
            // dateReqDateBegin
            // 
            this.dateReqDateBegin.EditValue = null;
            this.dateReqDateBegin.EnterMoveNextControl = true;
            this.dateReqDateBegin.Location = new System.Drawing.Point(86, 14);
            this.dateReqDateBegin.Name = "dateReqDateBegin";
            this.dateReqDateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateReqDateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateReqDateBegin.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateReqDateBegin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateReqDateBegin.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateReqDateBegin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateReqDateBegin.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateReqDateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateReqDateBegin.TabIndex = 0;
            // 
            // labCommon
            // 
            this.labCommon.Location = new System.Drawing.Point(410, 47);
            this.labCommon.Name = "labCommon";
            this.labCommon.Size = new System.Drawing.Size(60, 14);
            this.labCommon.TabIndex = 12;
            this.labCommon.Text = "通用查询：";
            // 
            // labCreator
            // 
            this.labCreator.Location = new System.Drawing.Point(222, 47);
            this.labCreator.Name = "labCreator";
            this.labCreator.Size = new System.Drawing.Size(48, 14);
            this.labCreator.TabIndex = 11;
            this.labCreator.Text = "申请人：";
            // 
            // labReqState
            // 
            this.labReqState.Location = new System.Drawing.Point(20, 47);
            this.labReqState.Name = "labReqState";
            this.labReqState.Size = new System.Drawing.Size(60, 14);
            this.labReqState.TabIndex = 9;
            this.labReqState.Text = "单据状态：";
            // 
            // labPurCategory
            // 
            this.labPurCategory.Location = new System.Drawing.Point(516, 17);
            this.labPurCategory.Name = "labPurCategory";
            this.labPurCategory.Size = new System.Drawing.Size(60, 14);
            this.labPurCategory.TabIndex = 7;
            this.labPurCategory.Text = "采购类型：";
            // 
            // labReqDep
            // 
            this.labReqDep.Location = new System.Drawing.Point(315, 17);
            this.labReqDep.Name = "labReqDep";
            this.labReqDep.Size = new System.Drawing.Size(60, 14);
            this.labReqDep.TabIndex = 5;
            this.labReqDep.Text = "申请部门：";
            // 
            // labReqDate
            // 
            this.labReqDate.Location = new System.Drawing.Point(20, 17);
            this.labReqDate.Name = "labReqDate";
            this.labReqDate.Size = new System.Drawing.Size(60, 14);
            this.labReqDate.TabIndex = 1;
            this.labReqDate.Text = "请购日期：";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.gridControlPrReqHead);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 78);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1385, 288);
            this.pnlMiddle.TabIndex = 2;
            // 
            // gridControlPrReqHead
            // 
            this.gridControlPrReqHead.DataSource = this.bindingSource_PrReqHead;
            this.gridControlPrReqHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPrReqHead.Location = new System.Drawing.Point(2, 2);
            this.gridControlPrReqHead.MainView = this.gridViewPrReqHead;
            this.gridControlPrReqHead.Name = "gridControlPrReqHead";
            this.gridControlPrReqHead.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpReqDep,
            this.repLookUpPurCategory,
            this.repLookUpCreator});
            this.gridControlPrReqHead.Size = new System.Drawing.Size(1381, 284);
            this.gridControlPrReqHead.TabIndex = 1;
            this.gridControlPrReqHead.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPrReqHead});
            // 
            // bindingSource_PrReqHead
            // 
            this.bindingSource_PrReqHead.DataMember = "PrReqHead";
            this.bindingSource_PrReqHead.DataSource = this.dataSet_PrReq;
            // 
            // dataSet_PrReq
            // 
            this.dataSet_PrReq.DataSetName = "NewDataSet";
            this.dataSet_PrReq.EnforceConstraints = false;
            this.dataSet_PrReq.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTablePrReqHead});
            // 
            // dataTablePrReqHead
            // 
            this.dataTablePrReqHead.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColPrReqNo,
            this.dataColReqDate,
            this.dataColReqDep,
            this.dataColProjectNo,
            this.dataColStnNo,
            this.dataColPurCategory,
            this.dataColReqState,
            this.dataColApplicantIp,
            this.dataColApplicantTime,
            this.dataColModifierIp,
            this.dataColModifierTime,
            this.dataColApprover,
            this.dataColApproverIp,
            this.dataColApproverTime,
            this.dataColPrReqRemark,
            this.dataColClosedIp,
            this.dataColClosedTime,
            this.dataColCreator,
            this.dataColModifierId,
            this.dataColClosedId});
            this.dataTablePrReqHead.TableName = "PrReqHead";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColPrReqNo
            // 
            this.dataColPrReqNo.Caption = "请购单号";
            this.dataColPrReqNo.ColumnName = "PrReqNo";
            // 
            // dataColReqDate
            // 
            this.dataColReqDate.Caption = "请购日期";
            this.dataColReqDate.ColumnName = "ReqDate";
            this.dataColReqDate.DataType = typeof(System.DateTime);
            // 
            // dataColReqDep
            // 
            this.dataColReqDep.Caption = "申请部门";
            this.dataColReqDep.ColumnName = "ReqDep";
            // 
            // dataColProjectNo
            // 
            this.dataColProjectNo.Caption = "项目号";
            this.dataColProjectNo.ColumnName = "ProjectNo";
            // 
            // dataColStnNo
            // 
            this.dataColStnNo.Caption = "站号";
            this.dataColStnNo.ColumnName = "StnNo";
            // 
            // dataColPurCategory
            // 
            this.dataColPurCategory.Caption = "采购类型";
            this.dataColPurCategory.ColumnName = "PurCategory";
            // 
            // dataColReqState
            // 
            this.dataColReqState.Caption = "状态";
            this.dataColReqState.ColumnName = "ReqState";
            this.dataColReqState.DataType = typeof(short);
            // 
            // dataColApplicantIp
            // 
            this.dataColApplicantIp.Caption = "申请人IP";
            this.dataColApplicantIp.ColumnName = "ApplicantIp";
            // 
            // dataColApplicantTime
            // 
            this.dataColApplicantTime.Caption = "申请时间";
            this.dataColApplicantTime.ColumnName = "ApplicantTime";
            this.dataColApplicantTime.DataType = typeof(System.DateTime);
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
            // dataColApprover
            // 
            this.dataColApprover.Caption = "审批人";
            this.dataColApprover.ColumnName = "Approver";
            // 
            // dataColApproverIp
            // 
            this.dataColApproverIp.Caption = "审批人IP";
            this.dataColApproverIp.ColumnName = "ApproverIp";
            // 
            // dataColApproverTime
            // 
            this.dataColApproverTime.Caption = "审批时间";
            this.dataColApproverTime.ColumnName = "ApproverTime";
            this.dataColApproverTime.DataType = typeof(System.DateTime);
            // 
            // dataColPrReqRemark
            // 
            this.dataColPrReqRemark.Caption = "备注";
            this.dataColPrReqRemark.ColumnName = "PrReqRemark";
            // 
            // dataColClosedIp
            // 
            this.dataColClosedIp.Caption = "关闭人IP";
            this.dataColClosedIp.ColumnName = "ClosedIp";
            // 
            // dataColClosedTime
            // 
            this.dataColClosedTime.Caption = "关闭时间";
            this.dataColClosedTime.ColumnName = "ClosedTime";
            this.dataColClosedTime.DataType = typeof(System.DateTime);
            // 
            // dataColCreator
            // 
            this.dataColCreator.Caption = "申请人";
            this.dataColCreator.ColumnName = "Creator";
            this.dataColCreator.DataType = typeof(int);
            // 
            // dataColModifierId
            // 
            this.dataColModifierId.Caption = "修改人";
            this.dataColModifierId.ColumnName = "ModifierId";
            this.dataColModifierId.DataType = typeof(int);
            // 
            // dataColClosedId
            // 
            this.dataColClosedId.Caption = "关闭人";
            this.dataColClosedId.ColumnName = "ClosedId";
            this.dataColClosedId.DataType = typeof(int);
            // 
            // gridViewPrReqHead
            // 
            this.gridViewPrReqHead.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colPrReqNo,
            this.colReqState,
            this.colReqDate,
            this.colReqDep,
            this.colProjectNo,
            this.colStnNo,
            this.colPurCategory,
            this.colCreator,
            this.colModifierId,
            this.colClosedId,
            this.colPrReqRemark,
            this.colModifierTime,
            this.colClosedTime});
            this.gridViewPrReqHead.GridControl = this.gridControlPrReqHead;
            this.gridViewPrReqHead.IndicatorWidth = 40;
            this.gridViewPrReqHead.Name = "gridViewPrReqHead";
            this.gridViewPrReqHead.OptionsBehavior.Editable = false;
            this.gridViewPrReqHead.OptionsBehavior.ReadOnly = true;
            this.gridViewPrReqHead.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPrReqHead.OptionsView.ColumnAutoWidth = false;
            this.gridViewPrReqHead.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewPrReqHead.OptionsView.ShowFooter = true;
            this.gridViewPrReqHead.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewPrReqHead_RowClick);
            this.gridViewPrReqHead.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewPrReqHead_CustomDrawRowIndicator);
            this.gridViewPrReqHead.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewPrReqHead_CustomColumnDisplayText);
            this.gridViewPrReqHead.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewPrReqHead_KeyDown);
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colPrReqNo
            // 
            this.colPrReqNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrReqNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrReqNo.FieldName = "PrReqNo";
            this.colPrReqNo.Name = "colPrReqNo";
            this.colPrReqNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PrReqNo", "共计{0}条")});
            this.colPrReqNo.Visible = true;
            this.colPrReqNo.VisibleIndex = 0;
            this.colPrReqNo.Width = 110;
            // 
            // colReqState
            // 
            this.colReqState.AppearanceHeader.Options.UseTextOptions = true;
            this.colReqState.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReqState.FieldName = "ReqState";
            this.colReqState.Name = "colReqState";
            this.colReqState.Visible = true;
            this.colReqState.VisibleIndex = 1;
            this.colReqState.Width = 60;
            // 
            // colReqDate
            // 
            this.colReqDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colReqDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReqDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colReqDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colReqDate.FieldName = "ReqDate";
            this.colReqDate.Name = "colReqDate";
            this.colReqDate.Visible = true;
            this.colReqDate.VisibleIndex = 2;
            this.colReqDate.Width = 135;
            // 
            // colReqDep
            // 
            this.colReqDep.AppearanceHeader.Options.UseTextOptions = true;
            this.colReqDep.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReqDep.ColumnEdit = this.repLookUpReqDep;
            this.colReqDep.FieldName = "ReqDep";
            this.colReqDep.Name = "colReqDep";
            this.colReqDep.Visible = true;
            this.colReqDep.VisibleIndex = 3;
            this.colReqDep.Width = 120;
            // 
            // repLookUpReqDep
            // 
            this.repLookUpReqDep.AutoHeight = false;
            this.repLookUpReqDep.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpReqDep.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentNo", "部门编号", 95, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "部门名称", 111, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repLookUpReqDep.DisplayMember = "DepartmentName";
            this.repLookUpReqDep.Name = "repLookUpReqDep";
            this.repLookUpReqDep.NullText = "";
            this.repLookUpReqDep.ValueMember = "DepartmentNo";
            // 
            // colProjectNo
            // 
            this.colProjectNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectNo.FieldName = "ProjectNo";
            this.colProjectNo.Name = "colProjectNo";
            this.colProjectNo.Visible = true;
            this.colProjectNo.VisibleIndex = 4;
            this.colProjectNo.Width = 100;
            // 
            // colStnNo
            // 
            this.colStnNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colStnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStnNo.FieldName = "StnNo";
            this.colStnNo.Name = "colStnNo";
            this.colStnNo.Visible = true;
            this.colStnNo.VisibleIndex = 5;
            this.colStnNo.Width = 100;
            // 
            // colPurCategory
            // 
            this.colPurCategory.AppearanceHeader.Options.UseTextOptions = true;
            this.colPurCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPurCategory.ColumnEdit = this.repLookUpPurCategory;
            this.colPurCategory.FieldName = "PurCategory";
            this.colPurCategory.Name = "colPurCategory";
            this.colPurCategory.Visible = true;
            this.colPurCategory.VisibleIndex = 6;
            this.colPurCategory.Width = 80;
            // 
            // repLookUpPurCategory
            // 
            this.repLookUpPurCategory.AutoHeight = false;
            this.repLookUpPurCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpPurCategory.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurCategory", "编号", 81, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PurCategoryText", "名称", 111, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repLookUpPurCategory.DisplayMember = "PurCategoryText";
            this.repLookUpPurCategory.Name = "repLookUpPurCategory";
            this.repLookUpPurCategory.NullText = "";
            this.repLookUpPurCategory.ValueMember = "PurCategory";
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
            // colClosedId
            // 
            this.colClosedId.AppearanceHeader.Options.UseTextOptions = true;
            this.colClosedId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colClosedId.ColumnEdit = this.repLookUpCreator;
            this.colClosedId.FieldName = "ClosedId";
            this.colClosedId.Name = "colClosedId";
            this.colClosedId.Visible = true;
            this.colClosedId.VisibleIndex = 11;
            // 
            // colPrReqRemark
            // 
            this.colPrReqRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrReqRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrReqRemark.FieldName = "PrReqRemark";
            this.colPrReqRemark.Name = "colPrReqRemark";
            this.colPrReqRemark.Visible = true;
            this.colPrReqRemark.VisibleIndex = 7;
            this.colPrReqRemark.Width = 140;
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
            // colClosedTime
            // 
            this.colClosedTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colClosedTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colClosedTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colClosedTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colClosedTime.FieldName = "ClosedTime";
            this.colClosedTime.Name = "colClosedTime";
            this.colClosedTime.Visible = true;
            this.colClosedTime.VisibleIndex = 12;
            this.colClosedTime.Width = 135;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.gridBottomPrReq);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 366);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1385, 58);
            this.pnlBottom.TabIndex = 3;
            // 
            // gridBottomPrReq
            // 
            this.gridBottomPrReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBottomPrReq.Location = new System.Drawing.Point(2, 2);
            this.gridBottomPrReq.MasterDataSet = this.dataSet_PrReq;
            this.gridBottomPrReq.Name = "gridBottomPrReq";
            this.gridBottomPrReq.pageRowCount = 5;
            this.gridBottomPrReq.Size = new System.Drawing.Size(1381, 54);
            this.gridBottomPrReq.TabIndex = 0;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCt,
            this.tsmiQgrq,
            this.tsmiCxan,
            this.tsmiCxjgc,
            this.tsmiSjcx});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(317, 114);
            // 
            // tsmiCt
            // 
            this.tsmiCt.Name = "tsmiCt";
            this.tsmiCt.Size = new System.Drawing.Size(316, 22);
            this.tsmiCt.Text = "窗体加载事件错误。";
            // 
            // tsmiQgrq
            // 
            this.tsmiQgrq.Name = "tsmiQgrq";
            this.tsmiQgrq.Size = new System.Drawing.Size(316, 22);
            this.tsmiQgrq.Text = "请购日期不能为空，请设置后重新进行查询。";
            // 
            // tsmiCxan
            // 
            this.tsmiCxan.Name = "tsmiCxan";
            this.tsmiCxan.Size = new System.Drawing.Size(316, 22);
            this.tsmiCxan.Text = "查询按钮事件错误。";
            // 
            // tsmiCxjgc
            // 
            this.tsmiCxjgc.Name = "tsmiCxjgc";
            this.tsmiCxjgc.Size = new System.Drawing.Size(316, 22);
            this.tsmiCxjgc.Text = "查询结果存为Excel错误。";
            // 
            // tsmiSjcx
            // 
            this.tsmiSjcx.Name = "tsmiSjcx";
            this.tsmiSjcx.Size = new System.Drawing.Size(316, 22);
            this.tsmiSjcx.Text = "双击查询明细错误。";
            // 
            // FrmPrReqQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1385, 424);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnltop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "FrmPrReqQuery";
            this.TabText = "请购单查询-按订单";
            this.Text = "请购单查询-按订单";
            this.Load += new System.EventHandler(this.FrmPrReqQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCreatorView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxReqState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpPurCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrReqHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_PrReqHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_PrReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTablePrReqHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPrReqHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpPurCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnltop;
        private DevExpress.XtraEditors.TextEdit textCommon;
        private DevExpress.XtraEditors.LabelControl labCommon;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxReqState;
        private DevExpress.XtraEditors.LabelControl labCreator;
        private DevExpress.XtraEditors.LabelControl labReqState;
        private DevExpress.XtraEditors.LookUpEdit lookUpPurCategory;
        private DevExpress.XtraEditors.LabelControl labPurCategory;
        private DevExpress.XtraEditors.LookUpEdit lookUpReqDep;
        private DevExpress.XtraEditors.LabelControl labReqDep;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.DateEdit dateReqDateEnd;
        private DevExpress.XtraEditors.LabelControl lab;
        private DevExpress.XtraEditors.LabelControl labReqDate;
        private DevExpress.XtraEditors.DateEdit dateReqDateBegin;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private System.Data.DataSet dataSet_PrReq;
        private System.Data.DataTable dataTablePrReqHead;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColPrReqNo;
        private System.Data.DataColumn dataColReqDate;
        private System.Data.DataColumn dataColReqDep;
        private System.Data.DataColumn dataColProjectNo;
        private System.Data.DataColumn dataColStnNo;
        private System.Data.DataColumn dataColPurCategory;
        private System.Data.DataColumn dataColReqState;
        private System.Data.DataColumn dataColApplicantIp;
        private System.Data.DataColumn dataColApplicantTime;
        private System.Data.DataColumn dataColModifierIp;
        private System.Data.DataColumn dataColModifierTime;
        private System.Data.DataColumn dataColApprover;
        private System.Data.DataColumn dataColApproverIp;
        private System.Data.DataColumn dataColApproverTime;
        private System.Data.DataColumn dataColPrReqRemark;
        private System.Windows.Forms.BindingSource bindingSource_PrReqHead;
        private DevExpress.XtraGrid.GridControl gridControlPrReqHead;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPrReqHead;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colPrReqNo;
        private DevExpress.XtraGrid.Columns.GridColumn colReqState;
        private DevExpress.XtraGrid.Columns.GridColumn colReqDate;
        private DevExpress.XtraGrid.Columns.GridColumn colReqDep;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpReqDep;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNo;
        private DevExpress.XtraGrid.Columns.GridColumn colStnNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPurCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpPurCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colPrReqRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colModifierId;
        private DevExpress.XtraEditors.SimpleButton btnSaveExcel;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private GridBottom gridBottomPrReq;
        private System.Data.DataColumn dataColClosedIp;
        private System.Data.DataColumn dataColClosedTime;
        private DevExpress.XtraGrid.Columns.GridColumn colClosedId;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiCt;
        private System.Windows.Forms.ToolStripMenuItem tsmiQgrq;
        private System.Windows.Forms.ToolStripMenuItem tsmiCxan;
        private System.Windows.Forms.ToolStripMenuItem tsmiCxjgc;
        private System.Windows.Forms.ToolStripMenuItem tsmiSjcx;
        private DevExpress.XtraGrid.Columns.GridColumn colModifierTime;
        private DevExpress.XtraGrid.Columns.GridColumn colClosedTime;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpCreator;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpCreatorView;
        private System.Data.DataColumn dataColCreator;
        private System.Data.DataColumn dataColModifierId;
        private System.Data.DataColumn dataColClosedId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator;
    }
}