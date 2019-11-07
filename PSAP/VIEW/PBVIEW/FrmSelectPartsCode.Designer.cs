namespace PSAP.VIEW.BSVIEW
{
    partial class FrmSelectPartsCode
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
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.pnltop = new DevExpress.XtraEditors.PanelControl();
            this.searchLookUpCodeFileName = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpCodeFileNameView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.searchLookUpProjectNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpProjectNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labCodeFileName = new DevExpress.XtraEditors.LabelControl();
            this.labProjectNo = new DevExpress.XtraEditors.LabelControl();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.textCommon = new DevExpress.XtraEditors.TextEdit();
            this.labCommon = new DevExpress.XtraEditors.LabelControl();
            this.bindingSource_DesignBom = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_DesignBom = new System.Data.DataSet();
            this.dataTableDesignBom = new System.Data.DataTable();
            this.coluReId = new System.Data.DataColumn();
            this.coluReParent = new System.Data.DataColumn();
            this.coluCodeFileName = new System.Data.DataColumn();
            this.coluParentCodeFileName = new System.Data.DataColumn();
            this.coluCodeName = new System.Data.DataColumn();
            this.coluPbBomNo = new System.Data.DataColumn();
            this.coluIsUse = new System.Data.DataColumn();
            this.coluTotalQty = new System.Data.DataColumn();
            this.coluRemainQty = new System.Data.DataColumn();
            this.coluHasLevel = new System.Data.DataColumn();
            this.ColuNewQty = new System.Data.DataColumn();
            this.ColuIsMaterial = new System.Data.DataColumn();
            this.ColuPlanMark = new System.Data.DataColumn();
            this.ColuPrReqMark = new System.Data.DataColumn();
            this.dataColSalesOrderNo = new System.Data.DataColumn();
            this.dataColProjectNo = new System.Data.DataColumn();
            this.dataColIsBuy = new System.Data.DataColumn();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.treeListDesignBom = new DevExpress.XtraTreeList.TreeList();
            this.colParentCodeFileName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTotalQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCodeFileName1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCodeName1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHasLevel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsUse = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repCheckEditIsUse = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNewQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repSpinRemainQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colPbBomNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colReId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPlanMark = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPrReqMark = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSalesOrderNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colProjectNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileNameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_DesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditIsUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinRemainQty)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.BtnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 405);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(804, 36);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(715, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(634, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 4;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // pnltop
            // 
            this.pnltop.Controls.Add(this.searchLookUpCodeFileName);
            this.pnltop.Controls.Add(this.searchLookUpProjectNo);
            this.pnltop.Controls.Add(this.labCodeFileName);
            this.pnltop.Controls.Add(this.labProjectNo);
            this.pnltop.Controls.Add(this.btnQuery);
            this.pnltop.Controls.Add(this.textCommon);
            this.pnltop.Controls.Add(this.labCommon);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(804, 51);
            this.pnltop.TabIndex = 0;
            // 
            // searchLookUpCodeFileName
            // 
            this.searchLookUpCodeFileName.EnterMoveNextControl = true;
            this.searchLookUpCodeFileName.Location = new System.Drawing.Point(305, 14);
            this.searchLookUpCodeFileName.Name = "searchLookUpCodeFileName";
            this.searchLookUpCodeFileName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpCodeFileName.Properties.View = this.searchLookUpCodeFileNameView;
            this.searchLookUpCodeFileName.Size = new System.Drawing.Size(150, 20);
            this.searchLookUpCodeFileName.TabIndex = 1;
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
            this.searchLookUpProjectNo.Location = new System.Drawing.Point(74, 14);
            this.searchLookUpProjectNo.Name = "searchLookUpProjectNo";
            this.searchLookUpProjectNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpProjectNo.Properties.View = this.searchLookUpProjectNoView;
            this.searchLookUpProjectNo.Size = new System.Drawing.Size(150, 20);
            this.searchLookUpProjectNo.TabIndex = 0;
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
            this.labCodeFileName.Location = new System.Drawing.Point(239, 17);
            this.labCodeFileName.Name = "labCodeFileName";
            this.labCodeFileName.Size = new System.Drawing.Size(60, 14);
            this.labCodeFileName.TabIndex = 40;
            this.labCodeFileName.Text = "物料名称：";
            // 
            // labProjectNo
            // 
            this.labProjectNo.Location = new System.Drawing.Point(20, 17);
            this.labProjectNo.Name = "labProjectNo";
            this.labProjectNo.Size = new System.Drawing.Size(48, 14);
            this.labProjectNo.TabIndex = 39;
            this.labProjectNo.Text = "项目号：";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(706, 13);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // textCommon
            // 
            this.textCommon.EnterMoveNextControl = true;
            this.textCommon.Location = new System.Drawing.Point(536, 14);
            this.textCommon.Name = "textCommon";
            this.textCommon.Size = new System.Drawing.Size(150, 20);
            this.textCommon.TabIndex = 2;
            // 
            // labCommon
            // 
            this.labCommon.Location = new System.Drawing.Point(470, 17);
            this.labCommon.Name = "labCommon";
            this.labCommon.Size = new System.Drawing.Size(60, 14);
            this.labCommon.TabIndex = 22;
            this.labCommon.Text = "通用查询：";
            // 
            // bindingSource_DesignBom
            // 
            this.bindingSource_DesignBom.DataMember = "DesignBom";
            this.bindingSource_DesignBom.DataSource = this.dataSet_DesignBom;
            // 
            // dataSet_DesignBom
            // 
            this.dataSet_DesignBom.DataSetName = "NewDataSet";
            this.dataSet_DesignBom.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableDesignBom});
            // 
            // dataTableDesignBom
            // 
            this.dataTableDesignBom.Columns.AddRange(new System.Data.DataColumn[] {
            this.coluReId,
            this.coluReParent,
            this.coluCodeFileName,
            this.coluParentCodeFileName,
            this.coluCodeName,
            this.coluPbBomNo,
            this.coluIsUse,
            this.coluTotalQty,
            this.coluRemainQty,
            this.coluHasLevel,
            this.ColuNewQty,
            this.ColuIsMaterial,
            this.ColuPlanMark,
            this.ColuPrReqMark,
            this.dataColSalesOrderNo,
            this.dataColProjectNo,
            this.dataColIsBuy});
            this.dataTableDesignBom.TableName = "DesignBom";
            // 
            // coluReId
            // 
            this.coluReId.ColumnName = "ReId";
            // 
            // coluReParent
            // 
            this.coluReParent.ColumnName = "ReParent";
            // 
            // coluCodeFileName
            // 
            this.coluCodeFileName.Caption = "零件编号";
            this.coluCodeFileName.ColumnName = "CodeFileName";
            // 
            // coluParentCodeFileName
            // 
            this.coluParentCodeFileName.Caption = "父零件编号";
            this.coluParentCodeFileName.ColumnName = "ParentCodeFileName";
            // 
            // coluCodeName
            // 
            this.coluCodeName.Caption = "零件名称";
            this.coluCodeName.ColumnName = "CodeName";
            // 
            // coluPbBomNo
            // 
            this.coluPbBomNo.Caption = "BOM编号";
            this.coluPbBomNo.ColumnName = "PbBomNo";
            // 
            // coluIsUse
            // 
            this.coluIsUse.Caption = "是否使用";
            this.coluIsUse.ColumnName = "IsUse";
            this.coluIsUse.DataType = typeof(short);
            // 
            // coluTotalQty
            // 
            this.coluTotalQty.Caption = "合计数量";
            this.coluTotalQty.ColumnName = "TotalQty";
            this.coluTotalQty.DataType = typeof(double);
            // 
            // coluRemainQty
            // 
            this.coluRemainQty.Caption = "当前数量";
            this.coluRemainQty.ColumnName = "RemainQty";
            this.coluRemainQty.DataType = typeof(double);
            // 
            // coluHasLevel
            // 
            this.coluHasLevel.Caption = "类型";
            this.coluHasLevel.ColumnName = "HasLevel";
            this.coluHasLevel.DataType = typeof(short);
            // 
            // ColuNewQty
            // 
            this.ColuNewQty.Caption = "数量";
            this.ColuNewQty.ColumnName = "NewQty";
            this.ColuNewQty.DataType = typeof(double);
            // 
            // ColuIsMaterial
            // 
            this.ColuIsMaterial.Caption = "零件";
            this.ColuIsMaterial.ColumnName = "IsMaterial";
            this.ColuIsMaterial.DataType = typeof(short);
            // 
            // ColuPlanMark
            // 
            this.ColuPlanMark.Caption = "生产计划";
            this.ColuPlanMark.ColumnName = "PlanMark";
            this.ColuPlanMark.DataType = typeof(short);
            // 
            // ColuPrReqMark
            // 
            this.ColuPrReqMark.Caption = "请购单";
            this.ColuPrReqMark.ColumnName = "PrReqMark";
            this.ColuPrReqMark.DataType = typeof(short);
            // 
            // dataColSalesOrderNo
            // 
            this.dataColSalesOrderNo.Caption = "销售单号";
            this.dataColSalesOrderNo.ColumnName = "SalesOrderNo";
            // 
            // dataColProjectNo
            // 
            this.dataColProjectNo.Caption = "项目号";
            this.dataColProjectNo.ColumnName = "ProjectNo";
            // 
            // dataColIsBuy
            // 
            this.dataColIsBuy.Caption = "购买方式";
            this.dataColIsBuy.ColumnName = "IsBuy";
            this.dataColIsBuy.DataType = typeof(short);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.treeListDesignBom);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 51);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(804, 354);
            this.pnlGrid.TabIndex = 15;
            // 
            // treeListDesignBom
            // 
            this.treeListDesignBom.AllowDrop = true;
            this.treeListDesignBom.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colParentCodeFileName,
            this.colTotalQty,
            this.colCodeFileName1,
            this.colCodeName1,
            this.colHasLevel,
            this.colIsUse,
            this.colNewQty,
            this.colPbBomNo,
            this.colReId,
            this.colPlanMark,
            this.colPrReqMark,
            this.colSalesOrderNo,
            this.colProjectNo});
            this.treeListDesignBom.DataSource = this.bindingSource_DesignBom;
            this.treeListDesignBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDesignBom.IndicatorWidth = 40;
            this.treeListDesignBom.KeyFieldName = "ReId";
            this.treeListDesignBom.Location = new System.Drawing.Point(2, 2);
            this.treeListDesignBom.Name = "treeListDesignBom";
            this.treeListDesignBom.OptionsView.AutoWidth = false;
            this.treeListDesignBom.OptionsView.ShowHorzLines = false;
            this.treeListDesignBom.OptionsView.ShowSummaryFooter = true;
            this.treeListDesignBom.OptionsView.ShowVertLines = false;
            this.treeListDesignBom.ParentFieldName = "ReParent";
            this.treeListDesignBom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckEditIsUse,
            this.repSpinRemainQty});
            this.treeListDesignBom.RowHeight = 21;
            this.treeListDesignBom.Size = new System.Drawing.Size(800, 350);
            this.treeListDesignBom.TabIndex = 1;
            this.treeListDesignBom.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.treeListBom_CustomDrawNodeIndicator);
            this.treeListDesignBom.DoubleClick += new System.EventHandler(this.treeListDesignBom_DoubleClick);
            this.treeListDesignBom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeListDesignBom_KeyDown);
            // 
            // colParentCodeFileName
            // 
            this.colParentCodeFileName.FieldName = "ParentCodeFileName";
            this.colParentCodeFileName.Name = "colParentCodeFileName";
            this.colParentCodeFileName.Width = 30;
            // 
            // colTotalQty
            // 
            this.colTotalQty.FieldName = "TotalQty";
            this.colTotalQty.Name = "colTotalQty";
            this.colTotalQty.Width = 31;
            // 
            // colCodeFileName1
            // 
            this.colCodeFileName1.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeFileName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeFileName1.Caption = "零件编号";
            this.colCodeFileName1.FieldName = "CodeFileName";
            this.colCodeFileName1.MinWidth = 32;
            this.colCodeFileName1.Name = "colCodeFileName1";
            this.colCodeFileName1.OptionsColumn.AllowEdit = false;
            this.colCodeFileName1.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count;
            this.colCodeFileName1.SummaryFooterStrFormat = "共计{0}条";
            this.colCodeFileName1.Visible = true;
            this.colCodeFileName1.VisibleIndex = 0;
            this.colCodeFileName1.Width = 220;
            // 
            // colCodeName1
            // 
            this.colCodeName1.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeName1.Caption = "零件名称";
            this.colCodeName1.FieldName = "CodeName";
            this.colCodeName1.Name = "colCodeName1";
            this.colCodeName1.OptionsColumn.AllowEdit = false;
            this.colCodeName1.Visible = true;
            this.colCodeName1.VisibleIndex = 1;
            this.colCodeName1.Width = 120;
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
            // colIsUse
            // 
            this.colIsUse.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsUse.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsUse.Caption = "使用";
            this.colIsUse.ColumnEdit = this.repCheckEditIsUse;
            this.colIsUse.FieldName = "IsUse";
            this.colIsUse.Name = "colIsUse";
            this.colIsUse.OptionsColumn.AllowEdit = false;
            this.colIsUse.Width = 40;
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
            // colNewQty
            // 
            this.colNewQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colNewQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNewQty.Caption = "数量";
            this.colNewQty.ColumnEdit = this.repSpinRemainQty;
            this.colNewQty.FieldName = "RemainQty";
            this.colNewQty.Name = "colNewQty";
            this.colNewQty.OptionsColumn.AllowEdit = false;
            this.colNewQty.Visible = true;
            this.colNewQty.VisibleIndex = 2;
            this.colNewQty.Width = 80;
            // 
            // repSpinRemainQty
            // 
            this.repSpinRemainQty.AutoHeight = false;
            this.repSpinRemainQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinRemainQty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinRemainQty.Name = "repSpinRemainQty";
            // 
            // colPbBomNo
            // 
            this.colPbBomNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colPbBomNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPbBomNo.Caption = "设计Bom编号";
            this.colPbBomNo.FieldName = "PbBomNo";
            this.colPbBomNo.Name = "colPbBomNo";
            this.colPbBomNo.OptionsColumn.AllowEdit = false;
            this.colPbBomNo.Visible = true;
            this.colPbBomNo.VisibleIndex = 3;
            this.colPbBomNo.Width = 100;
            // 
            // colReId
            // 
            this.colReId.FieldName = "ReId";
            this.colReId.Name = "colReId";
            // 
            // colPlanMark
            // 
            this.colPlanMark.AppearanceHeader.Options.UseTextOptions = true;
            this.colPlanMark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPlanMark.Caption = "生产计划";
            this.colPlanMark.ColumnEdit = this.repCheckEditIsUse;
            this.colPlanMark.FieldName = "PlanMark";
            this.colPlanMark.Name = "colPlanMark";
            this.colPlanMark.OptionsColumn.AllowEdit = false;
            this.colPlanMark.Width = 60;
            // 
            // colPrReqMark
            // 
            this.colPrReqMark.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrReqMark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrReqMark.Caption = "请购单";
            this.colPrReqMark.ColumnEdit = this.repCheckEditIsUse;
            this.colPrReqMark.FieldName = "PrReqMark";
            this.colPrReqMark.Name = "colPrReqMark";
            this.colPrReqMark.OptionsColumn.AllowEdit = false;
            this.colPrReqMark.Width = 60;
            // 
            // colSalesOrderNo
            // 
            this.colSalesOrderNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colSalesOrderNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSalesOrderNo.Caption = "销售单号";
            this.colSalesOrderNo.FieldName = "SalesOrderNo";
            this.colSalesOrderNo.Name = "colSalesOrderNo";
            this.colSalesOrderNo.OptionsColumn.AllowEdit = false;
            this.colSalesOrderNo.Visible = true;
            this.colSalesOrderNo.VisibleIndex = 4;
            this.colSalesOrderNo.Width = 120;
            // 
            // colProjectNo
            // 
            this.colProjectNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectNo.Caption = "项目号";
            this.colProjectNo.FieldName = "ProjectNo";
            this.colProjectNo.Name = "colProjectNo";
            this.colProjectNo.OptionsColumn.AllowEdit = false;
            this.colProjectNo.Visible = true;
            this.colProjectNo.VisibleIndex = 5;
            this.colProjectNo.Width = 90;
            // 
            // FrmSelectPartsCode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(804, 441);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnltop);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectPartsCode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "选择设计Bom零件";
            this.Text = "选择设计Bom零件";
            this.Load += new System.EventHandler(this.FrmSelectPartsCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileNameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_DesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditIsUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinRemainQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
        private DevExpress.XtraEditors.PanelControl pnltop;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpCodeFileName;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpCodeFileNameView;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpProjectNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpProjectNoView;
        private DevExpress.XtraEditors.LabelControl labCodeFileName;
        private DevExpress.XtraEditors.LabelControl labProjectNo;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.TextEdit textCommon;
        private DevExpress.XtraEditors.LabelControl labCommon;
        private System.Windows.Forms.BindingSource bindingSource_DesignBom;
        public System.Data.DataSet dataSet_DesignBom;
        private System.Data.DataTable dataTableDesignBom;
        private System.Data.DataColumn coluReId;
        private System.Data.DataColumn coluReParent;
        private System.Data.DataColumn coluCodeFileName;
        private System.Data.DataColumn coluParentCodeFileName;
        private System.Data.DataColumn coluCodeName;
        private System.Data.DataColumn coluPbBomNo;
        private System.Data.DataColumn coluIsUse;
        private System.Data.DataColumn coluTotalQty;
        private System.Data.DataColumn coluRemainQty;
        private System.Data.DataColumn coluHasLevel;
        private System.Data.DataColumn ColuNewQty;
        private System.Data.DataColumn ColuIsMaterial;
        private System.Data.DataColumn ColuPlanMark;
        private System.Data.DataColumn ColuPrReqMark;
        private System.Data.DataColumn dataColSalesOrderNo;
        private System.Data.DataColumn dataColProjectNo;
        private System.Data.DataColumn dataColIsBuy;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentCodeFileName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTotalQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeFileName1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeName1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHasLevel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsUse;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckEditIsUse;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNewQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinRemainQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPbBomNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colReId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPlanMark;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPrReqMark;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSalesOrderNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colProjectNo;
        public DevExpress.XtraTreeList.TreeList treeListDesignBom;
    }
}