namespace PSAP.VIEW.BSVIEW
{
    partial class FrmProductOpenAccount
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
            this.dataSet_OpenAccount = new System.Data.DataSet();
            this.TableOpenAccount = new System.Data.DataTable();
            this.dataColCodeFileName = new System.Data.DataColumn();
            this.dataColCodeName = new System.Data.DataColumn();
            this.dataColCatgName = new System.Data.DataColumn();
            this.dataColCodeSpec = new System.Data.DataColumn();
            this.dataColCodeWeight = new System.Data.DataColumn();
            this.dataColMaterialVersion = new System.Data.DataColumn();
            this.dataColBrand = new System.Data.DataColumn();
            this.dataColUnit = new System.Data.DataColumn();
            this.dataColProjectName = new System.Data.DataColumn();
            this.dataColRepertoryId = new System.Data.DataColumn();
            this.dataColProjectNo = new System.Data.DataColumn();
            this.dataColBeginingQty = new System.Data.DataColumn();
            this.dataColInQty = new System.Data.DataColumn();
            this.dataColOutQty = new System.Data.DataColumn();
            this.dataColLocationId = new System.Data.DataColumn();
            this.dataColStockId = new System.Data.DataColumn();
            this.dataColOpDate = new System.Data.DataColumn();
            this.dataColTypeNo = new System.Data.DataColumn();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColOrderNo = new System.Data.DataColumn();
            this.dataColShelfId = new System.Data.DataColumn();
            this.dataColCurQty = new System.Data.DataColumn();
            this.dataColQty = new System.Data.DataColumn();
            this.dataColCodeId = new System.Data.DataColumn();
            this.bindingSource_OpenAccount = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.gridBottomWNowInfo = new PSAP.VIEW.BSVIEW.GridBottom();
            this.pnltop = new DevExpress.XtraEditors.PanelControl();
            this.searchLookUpShelfId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpShelfView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labShelfId = new DevExpress.XtraEditors.LabelControl();
            this.labLocationId = new DevExpress.XtraEditors.LabelControl();
            this.SearchLocationId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.SearchLocationIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dateOpEnd = new DevExpress.XtraEditors.DateEdit();
            this.lab1 = new DevExpress.XtraEditors.LabelControl();
            this.dateOpBegin = new DevExpress.XtraEditors.DateEdit();
            this.labOpDate = new DevExpress.XtraEditors.LabelControl();
            this.lookUpRepertoryId = new DevExpress.XtraEditors.LookUpEdit();
            this.labRepertoryId = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpCodeFileName = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpCodeFileNameView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.searchLookUpProjectNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpProjectNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labCodeFileName = new DevExpress.XtraEditors.LabelControl();
            this.labProjectNo = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.gridControlOpenAccount = new DevExpress.XtraGrid.GridControl();
            this.gridViewOpenAccount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCatgName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeSpec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepertoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeginingQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpLocationId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colOpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpShelfId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colStockId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_OpenAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableOpenAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_OpenAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpShelfId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpShelfView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOpEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOpEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOpBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOpBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileNameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOpenAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOpenAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpLocationId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpShelfId)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet_OpenAccount
            // 
            this.dataSet_OpenAccount.DataSetName = "NewDataSet";
            this.dataSet_OpenAccount.EnforceConstraints = false;
            this.dataSet_OpenAccount.Tables.AddRange(new System.Data.DataTable[] {
            this.TableOpenAccount});
            // 
            // TableOpenAccount
            // 
            this.TableOpenAccount.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColCodeFileName,
            this.dataColCodeName,
            this.dataColCatgName,
            this.dataColCodeSpec,
            this.dataColCodeWeight,
            this.dataColMaterialVersion,
            this.dataColBrand,
            this.dataColUnit,
            this.dataColProjectName,
            this.dataColRepertoryId,
            this.dataColProjectNo,
            this.dataColBeginingQty,
            this.dataColInQty,
            this.dataColOutQty,
            this.dataColLocationId,
            this.dataColStockId,
            this.dataColOpDate,
            this.dataColTypeNo,
            this.dataColAutoId,
            this.dataColOrderNo,
            this.dataColShelfId,
            this.dataColCurQty,
            this.dataColQty,
            this.dataColCodeId});
            this.TableOpenAccount.TableName = "OpenAccount";
            // 
            // dataColCodeFileName
            // 
            this.dataColCodeFileName.Caption = "零件编号";
            this.dataColCodeFileName.ColumnName = "CodeFileName";
            // 
            // dataColCodeName
            // 
            this.dataColCodeName.Caption = "零件名称";
            this.dataColCodeName.ColumnName = "CodeName";
            // 
            // dataColCatgName
            // 
            this.dataColCatgName.Caption = "分类名称";
            this.dataColCatgName.ColumnName = "CatgName";
            // 
            // dataColCodeSpec
            // 
            this.dataColCodeSpec.Caption = "规格型号";
            this.dataColCodeSpec.ColumnName = "CodeSpec";
            // 
            // dataColCodeWeight
            // 
            this.dataColCodeWeight.Caption = "重量";
            this.dataColCodeWeight.ColumnName = "CodeWeight";
            // 
            // dataColMaterialVersion
            // 
            this.dataColMaterialVersion.Caption = "物料版本";
            this.dataColMaterialVersion.ColumnName = "MaterialVersion";
            // 
            // dataColBrand
            // 
            this.dataColBrand.Caption = "品牌";
            this.dataColBrand.ColumnName = "Brand";
            // 
            // dataColUnit
            // 
            this.dataColUnit.Caption = "单位";
            this.dataColUnit.ColumnName = "Unit";
            // 
            // dataColProjectName
            // 
            this.dataColProjectName.Caption = "项目名称";
            this.dataColProjectName.ColumnName = "ProjectName";
            // 
            // dataColRepertoryId
            // 
            this.dataColRepertoryId.Caption = "仓库";
            this.dataColRepertoryId.ColumnName = "RepertoryId";
            this.dataColRepertoryId.DataType = typeof(int);
            // 
            // dataColProjectNo
            // 
            this.dataColProjectNo.Caption = "项目号";
            this.dataColProjectNo.ColumnName = "ProjectNo";
            // 
            // dataColBeginingQty
            // 
            this.dataColBeginingQty.Caption = "期初数量";
            this.dataColBeginingQty.ColumnName = "BeginingQty";
            this.dataColBeginingQty.DataType = typeof(double);
            // 
            // dataColInQty
            // 
            this.dataColInQty.Caption = "入库数量";
            this.dataColInQty.ColumnName = "InQty";
            this.dataColInQty.DataType = typeof(double);
            // 
            // dataColOutQty
            // 
            this.dataColOutQty.Caption = "出库数量";
            this.dataColOutQty.ColumnName = "OutQty";
            this.dataColOutQty.DataType = typeof(double);
            // 
            // dataColLocationId
            // 
            this.dataColLocationId.Caption = "仓位";
            this.dataColLocationId.ColumnName = "LocationId";
            this.dataColLocationId.DataType = typeof(int);
            // 
            // dataColStockId
            // 
            this.dataColStockId.Caption = "编号";
            this.dataColStockId.ColumnName = "StockId";
            this.dataColStockId.DataType = typeof(int);
            // 
            // dataColOpDate
            // 
            this.dataColOpDate.Caption = "操作时间";
            this.dataColOpDate.ColumnName = "OpDate";
            this.dataColOpDate.DataType = typeof(System.DateTime);
            // 
            // dataColTypeNo
            // 
            this.dataColTypeNo.Caption = "单据类型";
            this.dataColTypeNo.ColumnName = "TypeNo";
            this.dataColTypeNo.DataType = typeof(short);
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColOrderNo
            // 
            this.dataColOrderNo.Caption = "单据号";
            this.dataColOrderNo.ColumnName = "OrderNo";
            // 
            // dataColShelfId
            // 
            this.dataColShelfId.Caption = "货架号";
            this.dataColShelfId.ColumnName = "ShelfId";
            this.dataColShelfId.DataType = typeof(int);
            // 
            // dataColCurQty
            // 
            this.dataColCurQty.Caption = "在库数量";
            this.dataColCurQty.ColumnName = "CurQty";
            this.dataColCurQty.DataType = typeof(double);
            // 
            // dataColQty
            // 
            this.dataColQty.Caption = "操作数量";
            this.dataColQty.ColumnName = "Qty";
            this.dataColQty.DataType = typeof(double);
            // 
            // dataColCodeId
            // 
            this.dataColCodeId.Caption = "零件Id";
            this.dataColCodeId.ColumnName = "CodeId";
            this.dataColCodeId.DataType = typeof(int);
            // 
            // bindingSource_OpenAccount
            // 
            this.bindingSource_OpenAccount.DataMember = "OpenAccount";
            this.bindingSource_OpenAccount.DataSource = this.dataSet_OpenAccount;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.gridBottomWNowInfo);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 403);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1584, 58);
            this.pnlBottom.TabIndex = 8;
            // 
            // gridBottomWNowInfo
            // 
            this.gridBottomWNowInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBottomWNowInfo.Location = new System.Drawing.Point(2, 2);
            this.gridBottomWNowInfo.MasterDataSet = this.dataSet_OpenAccount;
            this.gridBottomWNowInfo.Name = "gridBottomWNowInfo";
            this.gridBottomWNowInfo.pageRowCount = 5;
            this.gridBottomWNowInfo.Size = new System.Drawing.Size(1580, 54);
            this.gridBottomWNowInfo.TabIndex = 0;
            // 
            // pnltop
            // 
            this.pnltop.Controls.Add(this.searchLookUpShelfId);
            this.pnltop.Controls.Add(this.labShelfId);
            this.pnltop.Controls.Add(this.labLocationId);
            this.pnltop.Controls.Add(this.SearchLocationId);
            this.pnltop.Controls.Add(this.dateOpEnd);
            this.pnltop.Controls.Add(this.lab1);
            this.pnltop.Controls.Add(this.dateOpBegin);
            this.pnltop.Controls.Add(this.labOpDate);
            this.pnltop.Controls.Add(this.lookUpRepertoryId);
            this.pnltop.Controls.Add(this.labRepertoryId);
            this.pnltop.Controls.Add(this.searchLookUpCodeFileName);
            this.pnltop.Controls.Add(this.searchLookUpProjectNo);
            this.pnltop.Controls.Add(this.labCodeFileName);
            this.pnltop.Controls.Add(this.labProjectNo);
            this.pnltop.Controls.Add(this.btnSaveExcel);
            this.pnltop.Controls.Add(this.btnQuery);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1584, 78);
            this.pnltop.TabIndex = 9;
            // 
            // searchLookUpShelfId
            // 
            this.searchLookUpShelfId.EnterMoveNextControl = true;
            this.searchLookUpShelfId.Location = new System.Drawing.Point(957, 14);
            this.searchLookUpShelfId.Name = "searchLookUpShelfId";
            this.searchLookUpShelfId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpShelfId.Properties.View = this.searchLookUpShelfView;
            this.searchLookUpShelfId.Size = new System.Drawing.Size(120, 20);
            this.searchLookUpShelfId.TabIndex = 5;
            // 
            // searchLookUpShelfView
            // 
            this.searchLookUpShelfView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpShelfView.Name = "searchLookUpShelfView";
            this.searchLookUpShelfView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpShelfView.OptionsView.ShowGroupPanel = false;
            // 
            // labShelfId
            // 
            this.labShelfId.Location = new System.Drawing.Point(903, 17);
            this.labShelfId.Name = "labShelfId";
            this.labShelfId.Size = new System.Drawing.Size(48, 14);
            this.labShelfId.TabIndex = 216;
            this.labShelfId.Text = "货架号：";
            // 
            // labLocationId
            // 
            this.labLocationId.Location = new System.Drawing.Point(501, 17);
            this.labLocationId.Name = "labLocationId";
            this.labLocationId.Size = new System.Drawing.Size(36, 14);
            this.labLocationId.TabIndex = 214;
            this.labLocationId.Text = "仓位：";
            // 
            // SearchLocationId
            // 
            this.SearchLocationId.EnterMoveNextControl = true;
            this.SearchLocationId.Location = new System.Drawing.Point(543, 14);
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
            // dateOpEnd
            // 
            this.dateOpEnd.EditValue = null;
            this.dateOpEnd.EnterMoveNextControl = true;
            this.dateOpEnd.Location = new System.Drawing.Point(202, 14);
            this.dateOpEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dateOpEnd.Name = "dateOpEnd";
            this.dateOpEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateOpEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateOpEnd.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateOpEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateOpEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateOpEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateOpEnd.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateOpEnd.Size = new System.Drawing.Size(100, 20);
            this.dateOpEnd.TabIndex = 1;
            // 
            // lab1
            // 
            this.lab1.Location = new System.Drawing.Point(192, 17);
            this.lab1.Margin = new System.Windows.Forms.Padding(4);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(4, 14);
            this.lab1.TabIndex = 45;
            this.lab1.Text = "-";
            // 
            // dateOpBegin
            // 
            this.dateOpBegin.EditValue = null;
            this.dateOpBegin.EnterMoveNextControl = true;
            this.dateOpBegin.Location = new System.Drawing.Point(86, 14);
            this.dateOpBegin.Margin = new System.Windows.Forms.Padding(4);
            this.dateOpBegin.Name = "dateOpBegin";
            this.dateOpBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateOpBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateOpBegin.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateOpBegin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateOpBegin.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateOpBegin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateOpBegin.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateOpBegin.Size = new System.Drawing.Size(100, 20);
            this.dateOpBegin.TabIndex = 0;
            // 
            // labOpDate
            // 
            this.labOpDate.Location = new System.Drawing.Point(20, 17);
            this.labOpDate.Margin = new System.Windows.Forms.Padding(4);
            this.labOpDate.Name = "labOpDate";
            this.labOpDate.Size = new System.Drawing.Size(60, 14);
            this.labOpDate.TabIndex = 44;
            this.labOpDate.Text = "操作日期：";
            // 
            // lookUpRepertoryId
            // 
            this.lookUpRepertoryId.EnterMoveNextControl = true;
            this.lookUpRepertoryId.Location = new System.Drawing.Point(363, 14);
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
            // labRepertoryId
            // 
            this.labRepertoryId.Location = new System.Drawing.Point(321, 17);
            this.labRepertoryId.Name = "labRepertoryId";
            this.labRepertoryId.Size = new System.Drawing.Size(36, 14);
            this.labRepertoryId.TabIndex = 41;
            this.labRepertoryId.Text = "仓库：";
            // 
            // searchLookUpCodeFileName
            // 
            this.searchLookUpCodeFileName.EnterMoveNextControl = true;
            this.searchLookUpCodeFileName.Location = new System.Drawing.Point(86, 44);
            this.searchLookUpCodeFileName.Name = "searchLookUpCodeFileName";
            this.searchLookUpCodeFileName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpCodeFileName.Properties.View = this.searchLookUpCodeFileNameView;
            this.searchLookUpCodeFileName.Size = new System.Drawing.Size(150, 20);
            this.searchLookUpCodeFileName.TabIndex = 6;
            // 
            // searchLookUpCodeFileNameView
            // 
            this.searchLookUpCodeFileNameView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpCodeFileNameView.Name = "searchLookUpCodeFileNameView";
            this.searchLookUpCodeFileNameView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpCodeFileNameView.OptionsView.ShowGroupPanel = false;
            // 
            // searchLookUpProjectNo
            // 
            this.searchLookUpProjectNo.EnterMoveNextControl = true;
            this.searchLookUpProjectNo.Location = new System.Drawing.Point(734, 14);
            this.searchLookUpProjectNo.Name = "searchLookUpProjectNo";
            this.searchLookUpProjectNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpProjectNo.Properties.View = this.searchLookUpProjectNoView;
            this.searchLookUpProjectNo.Size = new System.Drawing.Size(150, 20);
            this.searchLookUpProjectNo.TabIndex = 4;
            // 
            // searchLookUpProjectNoView
            // 
            this.searchLookUpProjectNoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpProjectNoView.Name = "searchLookUpProjectNoView";
            this.searchLookUpProjectNoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpProjectNoView.OptionsView.ShowGroupPanel = false;
            // 
            // labCodeFileName
            // 
            this.labCodeFileName.Location = new System.Drawing.Point(20, 47);
            this.labCodeFileName.Name = "labCodeFileName";
            this.labCodeFileName.Size = new System.Drawing.Size(60, 14);
            this.labCodeFileName.TabIndex = 39;
            this.labCodeFileName.Text = "物料名称：";
            // 
            // labProjectNo
            // 
            this.labProjectNo.Location = new System.Drawing.Point(680, 17);
            this.labProjectNo.Name = "labProjectNo";
            this.labProjectNo.Size = new System.Drawing.Size(48, 14);
            this.labProjectNo.TabIndex = 38;
            this.labProjectNo.Text = "项目号：";
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(353, 43);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveExcel.TabIndex = 8;
            this.btnSaveExcel.Text = "存为Excel";
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(263, 43);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.gridControlOpenAccount);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 78);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1584, 325);
            this.pnlMiddle.TabIndex = 10;
            // 
            // gridControlOpenAccount
            // 
            this.gridControlOpenAccount.DataSource = this.bindingSource_OpenAccount;
            this.gridControlOpenAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlOpenAccount.Location = new System.Drawing.Point(2, 2);
            this.gridControlOpenAccount.MainView = this.gridViewOpenAccount;
            this.gridControlOpenAccount.Name = "gridControlOpenAccount";
            this.gridControlOpenAccount.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpRepertoryId,
            this.repLookUpLocationId,
            this.repLookUpShelfId});
            this.gridControlOpenAccount.Size = new System.Drawing.Size(1580, 321);
            this.gridControlOpenAccount.TabIndex = 7;
            this.gridControlOpenAccount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOpenAccount});
            // 
            // gridViewOpenAccount
            // 
            this.gridViewOpenAccount.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colCatgName,
            this.colMaterialVersion,
            this.colCodeWeight,
            this.colCodeSpec,
            this.gridColumn7,
            this.colRepertoryId,
            this.colProjectNo,
            this.colProjectName,
            this.colBrand,
            this.colCodeName,
            this.colUnit,
            this.colCodeFileName,
            this.colCurQty,
            this.colInQty,
            this.colOutQty,
            this.colBeginingQty,
            this.colLocationId,
            this.colOpDate,
            this.colOrderNo,
            this.colShelfId,
            this.colStockId,
            this.colTypeNo,
            this.colCodeId});
            this.gridViewOpenAccount.GridControl = this.gridControlOpenAccount;
            this.gridViewOpenAccount.IndicatorWidth = 40;
            this.gridViewOpenAccount.Name = "gridViewOpenAccount";
            this.gridViewOpenAccount.OptionsBehavior.Editable = false;
            this.gridViewOpenAccount.OptionsBehavior.ReadOnly = true;
            this.gridViewOpenAccount.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewOpenAccount.OptionsView.ColumnAutoWidth = false;
            this.gridViewOpenAccount.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewOpenAccount.OptionsView.ShowFooter = true;
            this.gridViewOpenAccount.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewOpenAccount_CustomDrawRowIndicator);
            this.gridViewOpenAccount.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewOpenAccount_CustomColumnDisplayText);
            this.gridViewOpenAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewOpenAccount_KeyDown);
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colCatgName
            // 
            this.colCatgName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCatgName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCatgName.FieldName = "CatgName";
            this.colCatgName.Name = "colCatgName";
            this.colCatgName.Width = 90;
            // 
            // colMaterialVersion
            // 
            this.colMaterialVersion.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaterialVersion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaterialVersion.FieldName = "MaterialVersion";
            this.colMaterialVersion.Name = "colMaterialVersion";
            this.colMaterialVersion.Width = 90;
            // 
            // colCodeWeight
            // 
            this.colCodeWeight.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeWeight.FieldName = "CodeWeight";
            this.colCodeWeight.Name = "colCodeWeight";
            this.colCodeWeight.Width = 80;
            // 
            // colCodeSpec
            // 
            this.colCodeSpec.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeSpec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeSpec.FieldName = "CodeSpec";
            this.colCodeSpec.Name = "colCodeSpec";
            this.colCodeSpec.Width = 110;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "Qty";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:0.##}")});
            this.gridColumn7.Width = 90;
            // 
            // colRepertoryId
            // 
            this.colRepertoryId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRepertoryId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRepertoryId.ColumnEdit = this.repLookUpRepertoryId;
            this.colRepertoryId.FieldName = "RepertoryId";
            this.colRepertoryId.Name = "colRepertoryId";
            this.colRepertoryId.Visible = true;
            this.colRepertoryId.VisibleIndex = 9;
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
            // colProjectNo
            // 
            this.colProjectNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectNo.FieldName = "ProjectNo";
            this.colProjectNo.Name = "colProjectNo";
            this.colProjectNo.Visible = true;
            this.colProjectNo.VisibleIndex = 11;
            this.colProjectNo.Width = 100;
            // 
            // colProjectName
            // 
            this.colProjectName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectName.FieldName = "ProjectName";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.Visible = true;
            this.colProjectName.VisibleIndex = 13;
            this.colProjectName.Width = 130;
            // 
            // colBrand
            // 
            this.colBrand.AppearanceHeader.Options.UseTextOptions = true;
            this.colBrand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBrand.FieldName = "Brand";
            this.colBrand.Name = "colBrand";
            this.colBrand.Visible = true;
            this.colBrand.VisibleIndex = 15;
            this.colBrand.Width = 80;
            // 
            // colCodeName
            // 
            this.colCodeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeName.FieldName = "CodeName";
            this.colCodeName.Name = "colCodeName";
            this.colCodeName.Visible = true;
            this.colCodeName.VisibleIndex = 2;
            this.colCodeName.Width = 110;
            // 
            // colUnit
            // 
            this.colUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 14;
            this.colUnit.Width = 70;
            // 
            // colCodeFileName
            // 
            this.colCodeFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeFileName.FieldName = "CodeFileName";
            this.colCodeFileName.Name = "colCodeFileName";
            this.colCodeFileName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CodeFileName", "共计{0}条")});
            this.colCodeFileName.Visible = true;
            this.colCodeFileName.VisibleIndex = 1;
            this.colCodeFileName.Width = 110;
            // 
            // colCurQty
            // 
            this.colCurQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCurQty.FieldName = "CurQty";
            this.colCurQty.Name = "colCurQty";
            this.colCurQty.Visible = true;
            this.colCurQty.VisibleIndex = 6;
            this.colCurQty.Width = 80;
            // 
            // colInQty
            // 
            this.colInQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colInQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colInQty.FieldName = "InQty";
            this.colInQty.Name = "colInQty";
            this.colInQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InQty", "{0:0.##}")});
            this.colInQty.Visible = true;
            this.colInQty.VisibleIndex = 4;
            this.colInQty.Width = 80;
            // 
            // colOutQty
            // 
            this.colOutQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colOutQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOutQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOutQty.FieldName = "OutQty";
            this.colOutQty.Name = "colOutQty";
            this.colOutQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutQty", "{0:0.##}")});
            this.colOutQty.Visible = true;
            this.colOutQty.VisibleIndex = 5;
            this.colOutQty.Width = 80;
            // 
            // colBeginingQty
            // 
            this.colBeginingQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colBeginingQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBeginingQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBeginingQty.FieldName = "BeginingQty";
            this.colBeginingQty.Name = "colBeginingQty";
            this.colBeginingQty.Visible = true;
            this.colBeginingQty.VisibleIndex = 3;
            this.colBeginingQty.Width = 80;
            // 
            // colLocationId
            // 
            this.colLocationId.AppearanceHeader.Options.UseTextOptions = true;
            this.colLocationId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLocationId.ColumnEdit = this.repLookUpLocationId;
            this.colLocationId.FieldName = "LocationId";
            this.colLocationId.Name = "colLocationId";
            this.colLocationId.Visible = true;
            this.colLocationId.VisibleIndex = 10;
            this.colLocationId.Width = 100;
            // 
            // repLookUpLocationId
            // 
            this.repLookUpLocationId.AutoHeight = false;
            this.repLookUpLocationId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpLocationId.DisplayMember = "LocationName";
            this.repLookUpLocationId.Name = "repLookUpLocationId";
            this.repLookUpLocationId.NullText = "";
            this.repLookUpLocationId.ValueMember = "AutoId";
            // 
            // colOpDate
            // 
            this.colOpDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colOpDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOpDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colOpDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colOpDate.FieldName = "OpDate";
            this.colOpDate.Name = "colOpDate";
            this.colOpDate.Visible = true;
            this.colOpDate.VisibleIndex = 0;
            this.colOpDate.Width = 135;
            // 
            // colOrderNo
            // 
            this.colOrderNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOrderNo.FieldName = "OrderNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.Visible = true;
            this.colOrderNo.VisibleIndex = 8;
            this.colOrderNo.Width = 120;
            // 
            // colShelfId
            // 
            this.colShelfId.AppearanceHeader.Options.UseTextOptions = true;
            this.colShelfId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShelfId.ColumnEdit = this.repLookUpShelfId;
            this.colShelfId.FieldName = "ShelfId";
            this.colShelfId.Name = "colShelfId";
            this.colShelfId.Visible = true;
            this.colShelfId.VisibleIndex = 12;
            this.colShelfId.Width = 100;
            // 
            // repLookUpShelfId
            // 
            this.repLookUpShelfId.AutoHeight = false;
            this.repLookUpShelfId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpShelfId.DisplayMember = "ShelfNo";
            this.repLookUpShelfId.Name = "repLookUpShelfId";
            this.repLookUpShelfId.NullText = "";
            this.repLookUpShelfId.ValueMember = "AutoId";
            // 
            // colStockId
            // 
            this.colStockId.AppearanceHeader.Options.UseTextOptions = true;
            this.colStockId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStockId.FieldName = "StockId";
            this.colStockId.Name = "colStockId";
            // 
            // colTypeNo
            // 
            this.colTypeNo.AppearanceCell.Options.UseTextOptions = true;
            this.colTypeNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypeNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colTypeNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypeNo.FieldName = "TypeNo";
            this.colTypeNo.Name = "colTypeNo";
            this.colTypeNo.Visible = true;
            this.colTypeNo.VisibleIndex = 7;
            this.colTypeNo.Width = 120;
            // 
            // colCodeId
            // 
            this.colCodeId.FieldName = "CodeId";
            this.colCodeId.Name = "colCodeId";
            // 
            // FrmProductOpenAccount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1584, 461);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnltop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "FrmProductOpenAccount";
            this.TabText = "产品收发帐";
            this.Text = "产品收发帐";
            this.Load += new System.EventHandler(this.FrmProductOpenAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_OpenAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableOpenAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_OpenAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpShelfId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpShelfView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOpEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOpEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOpBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOpBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileNameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOpenAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOpenAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpLocationId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpShelfId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSet_OpenAccount;
        private System.Data.DataTable TableOpenAccount;
        private System.Data.DataColumn dataColCodeFileName;
        private System.Data.DataColumn dataColCodeName;
        private System.Data.DataColumn dataColCatgName;
        private System.Data.DataColumn dataColCodeSpec;
        private System.Data.DataColumn dataColCodeWeight;
        private System.Data.DataColumn dataColMaterialVersion;
        private System.Data.DataColumn dataColBrand;
        private System.Data.DataColumn dataColUnit;
        private System.Data.DataColumn dataColProjectName;
        private System.Data.DataColumn dataColRepertoryId;
        private System.Data.DataColumn dataColProjectNo;
        private System.Data.DataColumn dataColBeginingQty;
        private System.Data.DataColumn dataColInQty;
        private System.Data.DataColumn dataColOutQty;
        private System.Data.DataColumn dataColLocationId;
        private System.Data.DataColumn dataColStockId;
        private System.Data.DataColumn dataColOpDate;
        private System.Data.DataColumn dataColTypeNo;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColOrderNo;
        private System.Data.DataColumn dataColShelfId;
        private System.Data.DataColumn dataColCurQty;
        private System.Data.DataColumn dataColQty;
        private System.Windows.Forms.BindingSource bindingSource_OpenAccount;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private GridBottom gridBottomWNowInfo;
        private DevExpress.XtraEditors.PanelControl pnltop;
        private DevExpress.XtraEditors.LabelControl labLocationId;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLocationId;
        private DevExpress.XtraGrid.Views.Grid.GridView SearchLocationIdView;
        private DevExpress.XtraEditors.DateEdit dateOpEnd;
        private DevExpress.XtraEditors.LabelControl lab1;
        private DevExpress.XtraEditors.DateEdit dateOpBegin;
        private DevExpress.XtraEditors.LabelControl labOpDate;
        private DevExpress.XtraEditors.LookUpEdit lookUpRepertoryId;
        private DevExpress.XtraEditors.LabelControl labRepertoryId;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpCodeFileName;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpCodeFileNameView;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpProjectNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpProjectNoView;
        private DevExpress.XtraEditors.LabelControl labCodeFileName;
        private DevExpress.XtraEditors.LabelControl labProjectNo;
        private DevExpress.XtraEditors.SimpleButton btnSaveExcel;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpShelfId;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpShelfView;
        private DevExpress.XtraEditors.LabelControl labShelfId;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraGrid.GridControl gridControlOpenAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOpenAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colCatgName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colBrand;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeSpec;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colCurQty;
        private DevExpress.XtraGrid.Columns.GridColumn colInQty;
        private DevExpress.XtraGrid.Columns.GridColumn colOutQty;
        private DevExpress.XtraGrid.Columns.GridColumn colBeginingQty;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpLocationId;
        private DevExpress.XtraGrid.Columns.GridColumn colOpDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn colShelfId;
        private DevExpress.XtraGrid.Columns.GridColumn colStockId;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpShelfId;
        private System.Data.DataColumn dataColCodeId;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeId;
    }
}