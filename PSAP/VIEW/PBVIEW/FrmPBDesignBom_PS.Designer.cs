namespace PSAP.VIEW.BSVIEW
{
    partial class FrmPBDesignBom_PS
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.pnlDesignBom = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabDesignBom = new DevExpress.XtraTab.XtraTabControl();
            this.PageDesignBom = new DevExpress.XtraTab.XtraTabPage();
            this.treeListDesignBom = new DevExpress.XtraTreeList.TreeList();
            this.colParentCodeFileName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTotalQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCodeFileName1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCodeName1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHasLevel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsUse = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repCheckEditIsUse = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colRemainQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repSpinRemainQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colPbBomNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colReId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
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
            this.pnlDesignBomToolBar = new DevExpress.XtraEditors.PanelControl();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnCollapse = new DevExpress.XtraEditors.SimpleButton();
            this.btnExpand = new DevExpress.XtraEditors.SimpleButton();
            this.btnRecover = new DevExpress.XtraEditors.SimpleButton();
            this.btnStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.splitterRight = new DevExpress.XtraEditors.SplitterControl();
            this.pnlPS = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabPS = new DevExpress.XtraTab.XtraTabControl();
            this.PagePS = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlPSBom = new DevExpress.XtraGrid.GridControl();
            this.bindingSource_PSBom = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_PSBom = new System.Data.DataSet();
            this.TablePSBom = new System.Data.DataTable();
            this.ColuAutoId = new System.Data.DataColumn();
            this.ColBomListAutoId = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.ColumnRemainQty = new System.Data.DataColumn();
            this.dataColIsBuy = new System.Data.DataColumn();
            this.dataColuPbBomNo = new System.Data.DataColumn();
            this.dataColuPlanDate = new System.Data.DataColumn();
            this.ColIsAbsorb = new System.Data.DataColumn();
            this.dataColPrReqNo = new System.Data.DataColumn();
            this.gridViewPSBom = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBomListAutoId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeFileName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainQty1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBuy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPbBomNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsAbsorb1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckIsAbsorb = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colPrReqNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpReqDep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repSearchBussinessBaseNo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCBussinessBaseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCBussinessBaseText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCBussinessCategoryText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSpinTax = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repLookUpApprovalType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repCheckIsVoucher = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.pnlPSToolBar = new DevExpress.XtraEditors.PanelControl();
            this.btnAlterPSBom = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteBom = new DevExpress.XtraEditors.SimpleButton();
            this.btnPlan = new DevExpress.XtraEditors.SimpleButton();
            this.radioType = new DevExpress.XtraEditors.RadioGroup();
            this.pnlSalesOrder = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditAutoSalesOrderNo = new DevExpress.XtraEditors.ButtonEdit();
            this.textProjectName = new DevExpress.XtraEditors.TextEdit();
            this.textProjectNo = new DevExpress.XtraEditors.TextEdit();
            this.labProjectNo = new DevExpress.XtraEditors.LabelControl();
            this.labProjectName = new DevExpress.XtraEditors.LabelControl();
            this.labAutoSalesOrderNo = new DevExpress.XtraEditors.LabelControl();
            this.pnlLeft = new DevExpress.XtraEditors.PanelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.TabControlBaseInfo = new DevExpress.XtraTab.XtraTabControl();
            this.PageBomInfo = new DevExpress.XtraTab.XtraTabPage();
            this.treeListBom = new DevExpress.XtraTreeList.TreeList();
            this.CCodeFileName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CCodeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CParentCodeFileName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CPCAutoId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CReID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CReParent = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CMaterieStateText = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CCodeSpec = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CBrand = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CUnit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CCatgName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.PagePartsCodeInfo = new DevExpress.XtraTab.XtraTabPage();
            this.gridCrlPartsCode = new DevExpress.XtraGrid.GridControl();
            this.bSPartsCode = new System.Windows.Forms.BindingSource(this.components);
            this.dSPartsCode = new System.Data.DataSet();
            this.TablePartsCode = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColCodeFileName = new System.Data.DataColumn();
            this.dataColCodeNo = new System.Data.DataColumn();
            this.dataColCodeName = new System.Data.DataColumn();
            this.dataColCatgName = new System.Data.DataColumn();
            this.dataColCodeSpec = new System.Data.DataColumn();
            this.dataColCodeWeight = new System.Data.DataColumn();
            this.dataColMaterial = new System.Data.DataColumn();
            this.dataColBrand = new System.Data.DataColumn();
            this.dataColUnit = new System.Data.DataColumn();
            this.dataColIsPreferred = new System.Data.DataColumn();
            this.dataColIsLongPeriod = new System.Data.DataColumn();
            this.dataColIsPrecious = new System.Data.DataColumn();
            this.dataColIsPreprocessing = new System.Data.DataColumn();
            this.dataColDesigner = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColuIsBuy = new System.Data.DataColumn();
            this.gridViewPartsCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCatgName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeSpec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPreferred = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLongPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPrecious = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPreprocessing = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBuy1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesigner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGetTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.labBrand = new DevExpress.XtraEditors.LabelControl();
            this.lookUpBrand = new DevExpress.XtraEditors.LookUpEdit();
            this.labCatgName = new DevExpress.XtraEditors.LabelControl();
            this.lookUpCatgName = new DevExpress.XtraEditors.LookUpEdit();
            this.textCodeName = new DevExpress.XtraEditors.TextEdit();
            this.labCodeName = new DevExpress.XtraEditors.LabelControl();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.labPartsCodeId = new DevExpress.XtraEditors.LabelControl();
            this.searchCodeFileName = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchCodeFileNameView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterLeft = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesignBom)).BeginInit();
            this.pnlDesignBom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabDesignBom)).BeginInit();
            this.xtraTabDesignBom.SuspendLayout();
            this.PageDesignBom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditIsUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinRemainQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_DesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesignBomToolBar)).BeginInit();
            this.pnlDesignBomToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPS)).BeginInit();
            this.pnlPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabPS)).BeginInit();
            this.xtraTabPS.SuspendLayout();
            this.PagePS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPSBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_PSBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_PSBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePSBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPSBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsAbsorb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchBussinessBaseNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPSToolBar)).BeginInit();
            this.pnlPSToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSalesOrder)).BeginInit();
            this.pnlSalesOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAutoSalesOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProjectNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlBaseInfo)).BeginInit();
            this.TabControlBaseInfo.SuspendLayout();
            this.PageBomInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListBom)).BeginInit();
            this.PagePartsCodeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlPartsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSPartsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPartsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePartsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPartsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBrand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCatgName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCodeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchCodeFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchCodeFileNameView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMiddle.Controls.Add(this.pnlDesignBom);
            this.pnlMiddle.Controls.Add(this.splitterRight);
            this.pnlMiddle.Controls.Add(this.pnlPS);
            this.pnlMiddle.Controls.Add(this.pnlSalesOrder);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(465, 0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1019, 681);
            this.pnlMiddle.TabIndex = 0;
            // 
            // pnlDesignBom
            // 
            this.pnlDesignBom.Controls.Add(this.xtraTabDesignBom);
            this.pnlDesignBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesignBom.Location = new System.Drawing.Point(0, 112);
            this.pnlDesignBom.Name = "pnlDesignBom";
            this.pnlDesignBom.Size = new System.Drawing.Size(514, 569);
            this.pnlDesignBom.TabIndex = 1;
            // 
            // xtraTabDesignBom
            // 
            this.xtraTabDesignBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabDesignBom.Location = new System.Drawing.Point(2, 2);
            this.xtraTabDesignBom.Name = "xtraTabDesignBom";
            this.xtraTabDesignBom.SelectedTabPage = this.PageDesignBom;
            this.xtraTabDesignBom.Size = new System.Drawing.Size(510, 565);
            this.xtraTabDesignBom.TabIndex = 2;
            this.xtraTabDesignBom.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PageDesignBom});
            // 
            // PageDesignBom
            // 
            this.PageDesignBom.Controls.Add(this.treeListDesignBom);
            this.PageDesignBom.Controls.Add(this.pnlDesignBomToolBar);
            this.PageDesignBom.Name = "PageDesignBom";
            this.PageDesignBom.Size = new System.Drawing.Size(504, 536);
            this.PageDesignBom.Text = "制作Bom登记";
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
            this.colRemainQty,
            this.colPbBomNo,
            this.colReId});
            this.treeListDesignBom.DataSource = this.bindingSource_DesignBom;
            this.treeListDesignBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDesignBom.IndicatorWidth = 40;
            this.treeListDesignBom.KeyFieldName = "ReId";
            this.treeListDesignBom.Location = new System.Drawing.Point(0, 35);
            this.treeListDesignBom.Name = "treeListDesignBom";
            this.treeListDesignBom.OptionsSelection.MultiSelect = true;
            this.treeListDesignBom.OptionsSelection.UseIndicatorForSelection = true;
            this.treeListDesignBom.OptionsView.AutoWidth = false;
            this.treeListDesignBom.OptionsView.EnableAppearanceEvenRow = true;
            this.treeListDesignBom.OptionsView.EnableAppearanceOddRow = true;
            this.treeListDesignBom.OptionsView.ShowCheckBoxes = true;
            this.treeListDesignBom.OptionsView.ShowSummaryFooter = true;
            this.treeListDesignBom.ParentFieldName = "ReParent";
            this.treeListDesignBom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckEditIsUse,
            this.repSpinRemainQty});
            this.treeListDesignBom.RowHeight = 21;
            this.treeListDesignBom.Size = new System.Drawing.Size(504, 501);
            this.treeListDesignBom.TabIndex = 0;
            this.treeListDesignBom.GetNodeDisplayValue += new DevExpress.XtraTreeList.GetNodeDisplayValueEventHandler(this.treeListDesignBom_GetNodeDisplayValue);
            this.treeListDesignBom.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.treeListDesignBom_BeforeCheckNode);
            this.treeListDesignBom.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListDesignBom_FocusedNodeChanged);
            this.treeListDesignBom.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.treeListBom_CustomDrawNodeIndicator);
            this.treeListDesignBom.CustomDrawNodeCheckBox += new DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventHandler(this.treeListDesignBom_CustomDrawNodeCheckBox);
            this.treeListDesignBom.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeListDesignBom_DragDrop);
            this.treeListDesignBom.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeListDesignBom_DragEnter);
            this.treeListDesignBom.DragOver += new System.Windows.Forms.DragEventHandler(this.treeListDesignBom_DragOver);
            this.treeListDesignBom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeListBom_KeyDown);
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
            this.colHasLevel.Visible = true;
            this.colHasLevel.VisibleIndex = 2;
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
            this.colIsUse.Visible = true;
            this.colIsUse.VisibleIndex = 4;
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
            // colRemainQty
            // 
            this.colRemainQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemainQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemainQty.Caption = "数量";
            this.colRemainQty.ColumnEdit = this.repSpinRemainQty;
            this.colRemainQty.FieldName = "RemainQty";
            this.colRemainQty.Name = "colRemainQty";
            this.colRemainQty.OptionsColumn.AllowEdit = false;
            this.colRemainQty.Visible = true;
            this.colRemainQty.VisibleIndex = 3;
            this.colRemainQty.Width = 80;
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
            this.colPbBomNo.VisibleIndex = 5;
            this.colPbBomNo.Width = 100;
            // 
            // colReId
            // 
            this.colReId.FieldName = "ReId";
            this.colReId.Name = "colReId";
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
            this.coluHasLevel});
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
            this.coluRemainQty.Caption = "数量";
            this.coluRemainQty.ColumnName = "RemainQty";
            this.coluRemainQty.DataType = typeof(double);
            // 
            // coluHasLevel
            // 
            this.coluHasLevel.Caption = "类型";
            this.coluHasLevel.ColumnName = "HasLevel";
            this.coluHasLevel.DataType = typeof(short);
            // 
            // pnlDesignBomToolBar
            // 
            this.pnlDesignBomToolBar.Controls.Add(this.btnPreview);
            this.pnlDesignBomToolBar.Controls.Add(this.btnCollapse);
            this.pnlDesignBomToolBar.Controls.Add(this.btnExpand);
            this.pnlDesignBomToolBar.Controls.Add(this.btnRecover);
            this.pnlDesignBomToolBar.Controls.Add(this.btnStop);
            this.pnlDesignBomToolBar.Controls.Add(this.btnDelete);
            this.pnlDesignBomToolBar.Controls.Add(this.btnAdd);
            this.pnlDesignBomToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDesignBomToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlDesignBomToolBar.Name = "pnlDesignBomToolBar";
            this.pnlDesignBomToolBar.Size = new System.Drawing.Size(504, 35);
            this.pnlDesignBomToolBar.TabIndex = 1;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(273, 6);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(60, 23);
            this.btnPreview.TabIndex = 205;
            this.btnPreview.TabStop = false;
            this.btnPreview.Text = "预览";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.AllowFocus = false;
            this.btnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapse.Location = new System.Drawing.Point(476, 6);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(23, 23);
            this.btnCollapse.TabIndex = 206;
            this.btnCollapse.TabStop = false;
            this.btnCollapse.Text = "-";
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.AllowFocus = false;
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpand.Location = new System.Drawing.Point(447, 6);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(23, 23);
            this.btnExpand.TabIndex = 205;
            this.btnExpand.TabStop = false;
            this.btnExpand.Text = "+";
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnRecover
            // 
            this.btnRecover.Location = new System.Drawing.Point(207, 6);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(60, 23);
            this.btnRecover.TabIndex = 204;
            this.btnRecover.TabStop = false;
            this.btnRecover.Text = "恢复";
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(141, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(60, 23);
            this.btnStop.TabIndex = 203;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "停用";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(75, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 202;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 201;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "修改";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splitterRight
            // 
            this.splitterRight.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.splitterRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterRight.Location = new System.Drawing.Point(514, 112);
            this.splitterRight.Name = "splitterRight";
            this.splitterRight.Size = new System.Drawing.Size(5, 569);
            this.splitterRight.TabIndex = 18;
            this.splitterRight.TabStop = false;
            // 
            // pnlPS
            // 
            this.pnlPS.Controls.Add(this.xtraTabPS);
            this.pnlPS.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPS.Location = new System.Drawing.Point(519, 112);
            this.pnlPS.Name = "pnlPS";
            this.pnlPS.Size = new System.Drawing.Size(500, 569);
            this.pnlPS.TabIndex = 17;
            // 
            // xtraTabPS
            // 
            this.xtraTabPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabPS.Location = new System.Drawing.Point(2, 2);
            this.xtraTabPS.Name = "xtraTabPS";
            this.xtraTabPS.SelectedTabPage = this.PagePS;
            this.xtraTabPS.Size = new System.Drawing.Size(496, 565);
            this.xtraTabPS.TabIndex = 1;
            this.xtraTabPS.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PagePS});
            // 
            // PagePS
            // 
            this.PagePS.Controls.Add(this.gridControlPSBom);
            this.PagePS.Controls.Add(this.pnlPSToolBar);
            this.PagePS.Name = "PagePS";
            this.PagePS.Size = new System.Drawing.Size(490, 536);
            this.PagePS.Text = "生产计划登记";
            // 
            // gridControlPSBom
            // 
            this.gridControlPSBom.DataSource = this.bindingSource_PSBom;
            this.gridControlPSBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPSBom.Location = new System.Drawing.Point(0, 35);
            this.gridControlPSBom.MainView = this.gridViewPSBom;
            this.gridControlPSBom.Name = "gridControlPSBom";
            this.gridControlPSBom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpReqDep,
            this.repSearchBussinessBaseNo,
            this.repCheckIsAbsorb,
            this.repSpinTax,
            this.repLookUpApprovalType,
            this.repCheckIsVoucher});
            this.gridControlPSBom.Size = new System.Drawing.Size(490, 501);
            this.gridControlPSBom.TabIndex = 8;
            this.gridControlPSBom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPSBom});
            // 
            // bindingSource_PSBom
            // 
            this.bindingSource_PSBom.DataMember = "PSBom";
            this.bindingSource_PSBom.DataSource = this.dataSet_PSBom;
            // 
            // dataSet_PSBom
            // 
            this.dataSet_PSBom.DataSetName = "NewDataSet";
            this.dataSet_PSBom.Tables.AddRange(new System.Data.DataTable[] {
            this.TablePSBom});
            // 
            // TablePSBom
            // 
            this.TablePSBom.Columns.AddRange(new System.Data.DataColumn[] {
            this.ColuAutoId,
            this.ColBomListAutoId,
            this.dataColumn3,
            this.dataColumn4,
            this.ColumnRemainQty,
            this.dataColIsBuy,
            this.dataColuPbBomNo,
            this.dataColuPlanDate,
            this.ColIsAbsorb,
            this.dataColPrReqNo});
            this.TablePSBom.TableName = "PSBom";
            // 
            // ColuAutoId
            // 
            this.ColuAutoId.ColumnName = "AutoId";
            this.ColuAutoId.DataType = typeof(int);
            // 
            // ColBomListAutoId
            // 
            this.ColBomListAutoId.ColumnName = "BomListAutoId";
            this.ColBomListAutoId.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "零件编号";
            this.dataColumn3.ColumnName = "CodeFileName";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "零件名称";
            this.dataColumn4.ColumnName = "CodeName";
            // 
            // ColumnRemainQty
            // 
            this.ColumnRemainQty.Caption = "需求数量";
            this.ColumnRemainQty.ColumnName = "RemainQty";
            this.ColumnRemainQty.DataType = typeof(double);
            // 
            // dataColIsBuy
            // 
            this.dataColIsBuy.Caption = "购买类型";
            this.dataColIsBuy.ColumnName = "IsBuy";
            this.dataColIsBuy.DataType = typeof(short);
            // 
            // dataColuPbBomNo
            // 
            this.dataColuPbBomNo.Caption = "设计Bom编号";
            this.dataColuPbBomNo.ColumnName = "PbBomNo";
            // 
            // dataColuPlanDate
            // 
            this.dataColuPlanDate.Caption = "需求日期";
            this.dataColuPlanDate.ColumnName = "PlanDate";
            this.dataColuPlanDate.DataType = typeof(System.DateTime);
            // 
            // ColIsAbsorb
            // 
            this.ColIsAbsorb.Caption = "吸收";
            this.ColIsAbsorb.ColumnName = "IsAbsorb";
            this.ColIsAbsorb.DataType = typeof(short);
            // 
            // dataColPrReqNo
            // 
            this.dataColPrReqNo.Caption = "采购单号";
            this.dataColPrReqNo.ColumnName = "PrReqNo";
            // 
            // gridViewPSBom
            // 
            this.gridViewPSBom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId1,
            this.colBomListAutoId1,
            this.colCodeFileName2,
            this.colCodeName2,
            this.colRemainQty1,
            this.colPlanDate,
            this.colIsBuy,
            this.colPbBomNo1,
            this.colIsAbsorb1,
            this.colPrReqNo});
            this.gridViewPSBom.GridControl = this.gridControlPSBom;
            this.gridViewPSBom.IndicatorWidth = 40;
            this.gridViewPSBom.Name = "gridViewPSBom";
            this.gridViewPSBom.OptionsBehavior.Editable = false;
            this.gridViewPSBom.OptionsBehavior.ReadOnly = true;
            this.gridViewPSBom.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridViewPSBom.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPSBom.OptionsSelection.MultiSelect = true;
            this.gridViewPSBom.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewPSBom.OptionsView.ColumnAutoWidth = false;
            this.gridViewPSBom.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewPSBom.OptionsView.ShowFooter = true;
            this.gridViewPSBom.OptionsView.ShowGroupPanel = false;
            this.gridViewPSBom.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewPSBom_RowClick);
            this.gridViewPSBom.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewBomMateriel_CustomDrawRowIndicator);
            this.gridViewPSBom.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewPSBom_CustomColumnDisplayText);
            // 
            // colAutoId1
            // 
            this.colAutoId1.FieldName = "AutoId";
            this.colAutoId1.Name = "colAutoId1";
            // 
            // colBomListAutoId1
            // 
            this.colBomListAutoId1.FieldName = "BomListAutoId";
            this.colBomListAutoId1.Name = "colBomListAutoId1";
            // 
            // colCodeFileName2
            // 
            this.colCodeFileName2.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeFileName2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeFileName2.FieldName = "CodeFileName";
            this.colCodeFileName2.Name = "colCodeFileName2";
            this.colCodeFileName2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CodeFileName", "共计{0}条")});
            this.colCodeFileName2.Visible = true;
            this.colCodeFileName2.VisibleIndex = 1;
            this.colCodeFileName2.Width = 120;
            // 
            // colCodeName2
            // 
            this.colCodeName2.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeName2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeName2.FieldName = "CodeName";
            this.colCodeName2.Name = "colCodeName2";
            this.colCodeName2.Visible = true;
            this.colCodeName2.VisibleIndex = 2;
            this.colCodeName2.Width = 120;
            // 
            // colRemainQty1
            // 
            this.colRemainQty1.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemainQty1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemainQty1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRemainQty1.FieldName = "RemainQty";
            this.colRemainQty1.Name = "colRemainQty1";
            this.colRemainQty1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RemainQty", "{0}")});
            this.colRemainQty1.Visible = true;
            this.colRemainQty1.VisibleIndex = 3;
            this.colRemainQty1.Width = 80;
            // 
            // colPlanDate
            // 
            this.colPlanDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colPlanDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPlanDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colPlanDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPlanDate.FieldName = "PlanDate";
            this.colPlanDate.Name = "colPlanDate";
            this.colPlanDate.Visible = true;
            this.colPlanDate.VisibleIndex = 4;
            this.colPlanDate.Width = 80;
            // 
            // colIsBuy
            // 
            this.colIsBuy.AppearanceCell.Options.UseTextOptions = true;
            this.colIsBuy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIsBuy.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsBuy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsBuy.FieldName = "IsBuy";
            this.colIsBuy.Name = "colIsBuy";
            this.colIsBuy.Visible = true;
            this.colIsBuy.VisibleIndex = 5;
            this.colIsBuy.Width = 60;
            // 
            // colPbBomNo1
            // 
            this.colPbBomNo1.AppearanceHeader.Options.UseTextOptions = true;
            this.colPbBomNo1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPbBomNo1.FieldName = "PbBomNo";
            this.colPbBomNo1.Name = "colPbBomNo1";
            this.colPbBomNo1.Visible = true;
            this.colPbBomNo1.VisibleIndex = 6;
            this.colPbBomNo1.Width = 100;
            // 
            // colIsAbsorb1
            // 
            this.colIsAbsorb1.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsAbsorb1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsAbsorb1.ColumnEdit = this.repCheckIsAbsorb;
            this.colIsAbsorb1.FieldName = "IsAbsorb";
            this.colIsAbsorb1.Name = "colIsAbsorb1";
            this.colIsAbsorb1.Visible = true;
            this.colIsAbsorb1.VisibleIndex = 7;
            this.colIsAbsorb1.Width = 40;
            // 
            // repCheckIsAbsorb
            // 
            this.repCheckIsAbsorb.AutoHeight = false;
            this.repCheckIsAbsorb.Name = "repCheckIsAbsorb";
            this.repCheckIsAbsorb.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckIsAbsorb.ValueChecked = ((short)(1));
            this.repCheckIsAbsorb.ValueGrayed = ((short)(0));
            this.repCheckIsAbsorb.ValueUnchecked = ((short)(0));
            // 
            // colPrReqNo
            // 
            this.colPrReqNo.FieldName = "PrReqNo";
            this.colPrReqNo.Name = "colPrReqNo";
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
            // repSpinTax
            // 
            this.repSpinTax.AutoHeight = false;
            this.repSpinTax.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpinTax.DisplayFormat.FormatString = "p0";
            this.repSpinTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinTax.EditFormat.FormatString = "p0";
            this.repSpinTax.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinTax.Mask.EditMask = "p0";
            this.repSpinTax.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repSpinTax.Name = "repSpinTax";
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
            // repCheckIsVoucher
            // 
            this.repCheckIsVoucher.AutoHeight = false;
            this.repCheckIsVoucher.Name = "repCheckIsVoucher";
            this.repCheckIsVoucher.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckIsVoucher.ValueGrayed = false;
            // 
            // pnlPSToolBar
            // 
            this.pnlPSToolBar.Controls.Add(this.btnAlterPSBom);
            this.pnlPSToolBar.Controls.Add(this.btnDeleteBom);
            this.pnlPSToolBar.Controls.Add(this.btnPlan);
            this.pnlPSToolBar.Controls.Add(this.radioType);
            this.pnlPSToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPSToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlPSToolBar.Name = "pnlPSToolBar";
            this.pnlPSToolBar.Size = new System.Drawing.Size(490, 35);
            this.pnlPSToolBar.TabIndex = 0;
            // 
            // btnAlterPSBom
            // 
            this.btnAlterPSBom.Location = new System.Drawing.Point(75, 6);
            this.btnAlterPSBom.Name = "btnAlterPSBom";
            this.btnAlterPSBom.Size = new System.Drawing.Size(60, 23);
            this.btnAlterPSBom.TabIndex = 302;
            this.btnAlterPSBom.TabStop = false;
            this.btnAlterPSBom.Text = "修改计划";
            this.btnAlterPSBom.Click += new System.EventHandler(this.btnAlterPSBom_Click);
            // 
            // btnDeleteBom
            // 
            this.btnDeleteBom.Location = new System.Drawing.Point(141, 6);
            this.btnDeleteBom.Name = "btnDeleteBom";
            this.btnDeleteBom.Size = new System.Drawing.Size(60, 23);
            this.btnDeleteBom.TabIndex = 303;
            this.btnDeleteBom.TabStop = false;
            this.btnDeleteBom.Text = "删除计划";
            this.btnDeleteBom.Click += new System.EventHandler(this.btnDeleteBom_Click);
            // 
            // btnPlan
            // 
            this.btnPlan.Location = new System.Drawing.Point(9, 6);
            this.btnPlan.Name = "btnPlan";
            this.btnPlan.Size = new System.Drawing.Size(60, 23);
            this.btnPlan.TabIndex = 301;
            this.btnPlan.TabStop = false;
            this.btnPlan.Text = "设定计划";
            this.btnPlan.Click += new System.EventHandler(this.btnPlan_Click);
            // 
            // radioType
            // 
            this.radioType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioType.EditValue = ((short)(0));
            this.radioType.Location = new System.Drawing.Point(287, 4);
            this.radioType.Name = "radioType";
            this.radioType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioType.Properties.Appearance.Options.UseBackColor = true;
            this.radioType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "选中节点及子节点"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "选中节点")});
            this.radioType.Size = new System.Drawing.Size(252, 27);
            this.radioType.TabIndex = 304;
            this.radioType.TabStop = false;
            this.radioType.SelectedIndexChanged += new System.EventHandler(this.radioType_SelectedIndexChanged);
            // 
            // pnlSalesOrder
            // 
            this.pnlSalesOrder.Controls.Add(this.btnRefresh);
            this.pnlSalesOrder.Controls.Add(this.btnEditAutoSalesOrderNo);
            this.pnlSalesOrder.Controls.Add(this.textProjectName);
            this.pnlSalesOrder.Controls.Add(this.textProjectNo);
            this.pnlSalesOrder.Controls.Add(this.labProjectNo);
            this.pnlSalesOrder.Controls.Add(this.labProjectName);
            this.pnlSalesOrder.Controls.Add(this.labAutoSalesOrderNo);
            this.pnlSalesOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSalesOrder.Location = new System.Drawing.Point(0, 0);
            this.pnlSalesOrder.Name = "pnlSalesOrder";
            this.pnlSalesOrder.Size = new System.Drawing.Size(1019, 112);
            this.pnlSalesOrder.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(286, 73);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 104;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "查询";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnEditAutoSalesOrderNo
            // 
            this.btnEditAutoSalesOrderNo.Location = new System.Drawing.Point(86, 14);
            this.btnEditAutoSalesOrderNo.Name = "btnEditAutoSalesOrderNo";
            this.btnEditAutoSalesOrderNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "选择", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnEditAutoSalesOrderNo.Properties.ReadOnly = true;
            this.btnEditAutoSalesOrderNo.Size = new System.Drawing.Size(180, 21);
            this.btnEditAutoSalesOrderNo.TabIndex = 101;
            this.btnEditAutoSalesOrderNo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEditAutoSalesOrderNo_ButtonClick);
            // 
            // textProjectName
            // 
            this.textProjectName.Location = new System.Drawing.Point(86, 74);
            this.textProjectName.Name = "textProjectName";
            this.textProjectName.Properties.ReadOnly = true;
            this.textProjectName.Size = new System.Drawing.Size(180, 20);
            this.textProjectName.TabIndex = 103;
            this.textProjectName.TabStop = false;
            // 
            // textProjectNo
            // 
            this.textProjectNo.Location = new System.Drawing.Point(86, 44);
            this.textProjectNo.Name = "textProjectNo";
            this.textProjectNo.Properties.ReadOnly = true;
            this.textProjectNo.Size = new System.Drawing.Size(180, 20);
            this.textProjectNo.TabIndex = 102;
            this.textProjectNo.TabStop = false;
            // 
            // labProjectNo
            // 
            this.labProjectNo.Location = new System.Drawing.Point(20, 47);
            this.labProjectNo.Name = "labProjectNo";
            this.labProjectNo.Size = new System.Drawing.Size(48, 14);
            this.labProjectNo.TabIndex = 9;
            this.labProjectNo.Text = "项目号：";
            // 
            // labProjectName
            // 
            this.labProjectName.Location = new System.Drawing.Point(20, 77);
            this.labProjectName.Name = "labProjectName";
            this.labProjectName.Size = new System.Drawing.Size(60, 14);
            this.labProjectName.TabIndex = 8;
            this.labProjectName.Text = "项目名称：";
            // 
            // labAutoSalesOrderNo
            // 
            this.labAutoSalesOrderNo.Location = new System.Drawing.Point(20, 17);
            this.labAutoSalesOrderNo.Name = "labAutoSalesOrderNo";
            this.labAutoSalesOrderNo.Size = new System.Drawing.Size(60, 14);
            this.labAutoSalesOrderNo.TabIndex = 2;
            this.labAutoSalesOrderNo.Text = "销售单号：";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLeft.Controls.Add(this.pnlBottom);
            this.pnlLeft.Controls.Add(this.pnlTop);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(460, 681);
            this.pnlLeft.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.TabControlBaseInfo);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 112);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(460, 569);
            this.pnlBottom.TabIndex = 2;
            // 
            // TabControlBaseInfo
            // 
            this.TabControlBaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlBaseInfo.Location = new System.Drawing.Point(2, 2);
            this.TabControlBaseInfo.Name = "TabControlBaseInfo";
            this.TabControlBaseInfo.SelectedTabPage = this.PageBomInfo;
            this.TabControlBaseInfo.Size = new System.Drawing.Size(456, 565);
            this.TabControlBaseInfo.TabIndex = 0;
            this.TabControlBaseInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PageBomInfo,
            this.PagePartsCodeInfo});
            // 
            // PageBomInfo
            // 
            this.PageBomInfo.Controls.Add(this.treeListBom);
            this.PageBomInfo.Name = "PageBomInfo";
            this.PageBomInfo.Size = new System.Drawing.Size(450, 536);
            this.PageBomInfo.Text = "Bom信息";
            // 
            // treeListBom
            // 
            this.treeListBom.AllowDrop = true;
            this.treeListBom.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.CCodeFileName,
            this.CCodeName,
            this.CQty,
            this.CParentCodeFileName,
            this.CPCAutoId,
            this.CReID,
            this.CReParent,
            this.CMaterieStateText,
            this.CCodeSpec,
            this.CBrand,
            this.CUnit,
            this.CCatgName});
            this.treeListBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListBom.IndicatorWidth = 50;
            this.treeListBom.KeyFieldName = "ReID";
            this.treeListBom.Location = new System.Drawing.Point(0, 0);
            this.treeListBom.Name = "treeListBom";
            this.treeListBom.OptionsBehavior.Editable = false;
            this.treeListBom.OptionsBehavior.EnableFiltering = true;
            this.treeListBom.OptionsBehavior.ReadOnly = true;
            this.treeListBom.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListBom.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListBom.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListBom.OptionsView.AutoWidth = false;
            this.treeListBom.OptionsView.EnableAppearanceEvenRow = true;
            this.treeListBom.OptionsView.EnableAppearanceOddRow = true;
            this.treeListBom.OptionsView.ShowHorzLines = false;
            this.treeListBom.OptionsView.ShowVertLines = false;
            this.treeListBom.ParentFieldName = "ReParent";
            this.treeListBom.RowHeight = 21;
            this.treeListBom.Size = new System.Drawing.Size(450, 536);
            this.treeListBom.TabIndex = 3;
            this.treeListBom.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.treeListBom_CustomDrawNodeIndicator);
            this.treeListBom.DoubleClick += new System.EventHandler(this.treeListBom_DoubleClick);
            this.treeListBom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeListBom_KeyDown);
            this.treeListBom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeListBom_MouseDown);
            this.treeListBom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeListBom_MouseMove);
            // 
            // CCodeFileName
            // 
            this.CCodeFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.CCodeFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CCodeFileName.Caption = "零件编号";
            this.CCodeFileName.FieldName = "CodeFileName";
            this.CCodeFileName.Name = "CCodeFileName";
            this.CCodeFileName.Visible = true;
            this.CCodeFileName.VisibleIndex = 0;
            this.CCodeFileName.Width = 200;
            // 
            // CCodeName
            // 
            this.CCodeName.AppearanceHeader.Options.UseTextOptions = true;
            this.CCodeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CCodeName.Caption = "零件名称";
            this.CCodeName.FieldName = "CodeName";
            this.CCodeName.Name = "CCodeName";
            this.CCodeName.Visible = true;
            this.CCodeName.VisibleIndex = 1;
            this.CCodeName.Width = 120;
            // 
            // CQty
            // 
            this.CQty.AppearanceHeader.Options.UseTextOptions = true;
            this.CQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CQty.Caption = "数量";
            this.CQty.FieldName = "Qty";
            this.CQty.Name = "CQty";
            this.CQty.Visible = true;
            this.CQty.VisibleIndex = 2;
            this.CQty.Width = 80;
            // 
            // CParentCodeFileName
            // 
            this.CParentCodeFileName.Caption = "ParentCodeFileName";
            this.CParentCodeFileName.FieldName = "ParentCodeFileName";
            this.CParentCodeFileName.Name = "CParentCodeFileName";
            // 
            // CPCAutoId
            // 
            this.CPCAutoId.Caption = "PCAutoId";
            this.CPCAutoId.FieldName = "PCAutoId";
            this.CPCAutoId.Name = "CPCAutoId";
            // 
            // CReID
            // 
            this.CReID.Caption = "ReID";
            this.CReID.FieldName = "ReID";
            this.CReID.Name = "CReID";
            // 
            // CReParent
            // 
            this.CReParent.Caption = "ReParent";
            this.CReParent.FieldName = "ReParent";
            this.CReParent.Name = "CReParent";
            // 
            // CMaterieStateText
            // 
            this.CMaterieStateText.AppearanceHeader.Options.UseTextOptions = true;
            this.CMaterieStateText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CMaterieStateText.Caption = "物料状态";
            this.CMaterieStateText.FieldName = "MaterieStateText";
            this.CMaterieStateText.Name = "CMaterieStateText";
            this.CMaterieStateText.Visible = true;
            this.CMaterieStateText.VisibleIndex = 3;
            this.CMaterieStateText.Width = 100;
            // 
            // CCodeSpec
            // 
            this.CCodeSpec.AppearanceHeader.Options.UseTextOptions = true;
            this.CCodeSpec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CCodeSpec.Caption = "规格型号";
            this.CCodeSpec.FieldName = "CodeSpec";
            this.CCodeSpec.Name = "CCodeSpec";
            this.CCodeSpec.Visible = true;
            this.CCodeSpec.VisibleIndex = 4;
            this.CCodeSpec.Width = 120;
            // 
            // CBrand
            // 
            this.CBrand.AppearanceHeader.Options.UseTextOptions = true;
            this.CBrand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CBrand.Caption = "品牌";
            this.CBrand.FieldName = "Brand";
            this.CBrand.Name = "CBrand";
            this.CBrand.Visible = true;
            this.CBrand.VisibleIndex = 5;
            this.CBrand.Width = 80;
            // 
            // CUnit
            // 
            this.CUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.CUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CUnit.Caption = "单位";
            this.CUnit.FieldName = "Unit";
            this.CUnit.Name = "CUnit";
            this.CUnit.Visible = true;
            this.CUnit.VisibleIndex = 6;
            this.CUnit.Width = 80;
            // 
            // CCatgName
            // 
            this.CCatgName.AppearanceHeader.Options.UseTextOptions = true;
            this.CCatgName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CCatgName.Caption = "分类";
            this.CCatgName.FieldName = "CatgName";
            this.CCatgName.Name = "CCatgName";
            this.CCatgName.Visible = true;
            this.CCatgName.VisibleIndex = 7;
            this.CCatgName.Width = 80;
            // 
            // PagePartsCodeInfo
            // 
            this.PagePartsCodeInfo.Controls.Add(this.gridCrlPartsCode);
            this.PagePartsCodeInfo.Name = "PagePartsCodeInfo";
            this.PagePartsCodeInfo.Size = new System.Drawing.Size(450, 536);
            this.PagePartsCodeInfo.Text = "零件信息";
            // 
            // gridCrlPartsCode
            // 
            this.gridCrlPartsCode.AllowDrop = true;
            this.gridCrlPartsCode.DataSource = this.bSPartsCode;
            this.gridCrlPartsCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlPartsCode.Location = new System.Drawing.Point(0, 0);
            this.gridCrlPartsCode.MainView = this.gridViewPartsCode;
            this.gridCrlPartsCode.Name = "gridCrlPartsCode";
            this.gridCrlPartsCode.Size = new System.Drawing.Size(450, 536);
            this.gridCrlPartsCode.TabIndex = 1;
            this.gridCrlPartsCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPartsCode});
            // 
            // bSPartsCode
            // 
            this.bSPartsCode.DataMember = "PartsCode";
            this.bSPartsCode.DataSource = this.dSPartsCode;
            // 
            // dSPartsCode
            // 
            this.dSPartsCode.DataSetName = "NewDataSet";
            this.dSPartsCode.Tables.AddRange(new System.Data.DataTable[] {
            this.TablePartsCode});
            // 
            // TablePartsCode
            // 
            this.TablePartsCode.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColCodeFileName,
            this.dataColCodeNo,
            this.dataColCodeName,
            this.dataColCatgName,
            this.dataColCodeSpec,
            this.dataColCodeWeight,
            this.dataColMaterial,
            this.dataColBrand,
            this.dataColUnit,
            this.dataColIsPreferred,
            this.dataColIsLongPeriod,
            this.dataColIsPrecious,
            this.dataColIsPreprocessing,
            this.dataColDesigner,
            this.dataColumn2,
            this.dataColuIsBuy});
            this.TablePartsCode.TableName = "PartsCode";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "AutoId";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColCodeFileName
            // 
            this.dataColCodeFileName.Caption = "零件编号";
            this.dataColCodeFileName.ColumnName = "CodeFileName";
            // 
            // dataColCodeNo
            // 
            this.dataColCodeNo.Caption = "物料编号";
            this.dataColCodeNo.ColumnName = "CodeNo";
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
            this.dataColCodeWeight.DataType = typeof(double);
            // 
            // dataColMaterial
            // 
            this.dataColMaterial.Caption = "材料";
            this.dataColMaterial.ColumnName = "Material";
            this.dataColMaterial.DataType = typeof(int);
            // 
            // dataColBrand
            // 
            this.dataColBrand.Caption = "品牌 ";
            this.dataColBrand.ColumnName = "Brand";
            // 
            // dataColUnit
            // 
            this.dataColUnit.Caption = "单位";
            this.dataColUnit.ColumnName = "Unit";
            // 
            // dataColIsPreferred
            // 
            this.dataColIsPreferred.Caption = "优选";
            this.dataColIsPreferred.ColumnName = "IsPreferred";
            this.dataColIsPreferred.DataType = typeof(bool);
            // 
            // dataColIsLongPeriod
            // 
            this.dataColIsLongPeriod.Caption = "长周期";
            this.dataColIsLongPeriod.ColumnName = "IsLongPeriod";
            this.dataColIsLongPeriod.DataType = typeof(bool);
            // 
            // dataColIsPrecious
            // 
            this.dataColIsPrecious.Caption = "贵重";
            this.dataColIsPrecious.ColumnName = "IsPrecious";
            this.dataColIsPrecious.DataType = typeof(bool);
            // 
            // dataColIsPreprocessing
            // 
            this.dataColIsPreprocessing.Caption = "预处理";
            this.dataColIsPreprocessing.ColumnName = "IsPreprocessing";
            this.dataColIsPreprocessing.DataType = typeof(bool);
            // 
            // dataColDesigner
            // 
            this.dataColDesigner.Caption = "设计者";
            this.dataColDesigner.ColumnName = "Designer";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "登记时间";
            this.dataColumn2.ColumnName = "GetTime";
            this.dataColumn2.DataType = typeof(System.DateTime);
            // 
            // dataColuIsBuy
            // 
            this.dataColuIsBuy.Caption = "购买类型";
            this.dataColuIsBuy.ColumnName = "IsBuy";
            this.dataColuIsBuy.DataType = typeof(short);
            // 
            // gridViewPartsCode
            // 
            this.gridViewPartsCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colCodeFileName,
            this.colCodeNo,
            this.colCodeName,
            this.colCatgName,
            this.colCodeSpec,
            this.colCodeWeight,
            this.colMaterial,
            this.colBrand,
            this.colUnit,
            this.colIsPreferred,
            this.colIsLongPeriod,
            this.colIsPrecious,
            this.colIsPreprocessing,
            this.colIsBuy1,
            this.colDesigner,
            this.colGetTime});
            this.gridViewPartsCode.GridControl = this.gridCrlPartsCode;
            this.gridViewPartsCode.IndicatorWidth = 60;
            this.gridViewPartsCode.Name = "gridViewPartsCode";
            this.gridViewPartsCode.OptionsBehavior.Editable = false;
            this.gridViewPartsCode.OptionsBehavior.ReadOnly = true;
            this.gridViewPartsCode.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridViewPartsCode.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPartsCode.OptionsSelection.MultiSelect = true;
            this.gridViewPartsCode.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewPartsCode.OptionsView.ColumnAutoWidth = false;
            this.gridViewPartsCode.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewPartsCode.OptionsView.ShowFooter = true;
            this.gridViewPartsCode.OptionsView.ShowGroupPanel = false;
            this.gridViewPartsCode.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewBomMateriel_CustomDrawRowIndicator);
            this.gridViewPartsCode.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewPSBom_CustomColumnDisplayText);
            this.gridViewPartsCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewPartsCode_KeyDown);
            this.gridViewPartsCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridViewPartsCode_MouseDown);
            this.gridViewPartsCode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridViewPartsCode_MouseMove);
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
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
            this.colCodeFileName.Width = 120;
            // 
            // colCodeNo
            // 
            this.colCodeNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeNo.FieldName = "CodeNo";
            this.colCodeNo.Name = "colCodeNo";
            this.colCodeNo.Visible = true;
            this.colCodeNo.VisibleIndex = 2;
            this.colCodeNo.Width = 120;
            // 
            // colCodeName
            // 
            this.colCodeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeName.FieldName = "CodeName";
            this.colCodeName.Name = "colCodeName";
            this.colCodeName.Visible = true;
            this.colCodeName.VisibleIndex = 3;
            this.colCodeName.Width = 120;
            // 
            // colCatgName
            // 
            this.colCatgName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCatgName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCatgName.FieldName = "CatgName";
            this.colCatgName.Name = "colCatgName";
            this.colCatgName.Visible = true;
            this.colCatgName.VisibleIndex = 4;
            // 
            // colCodeSpec
            // 
            this.colCodeSpec.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeSpec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeSpec.FieldName = "CodeSpec";
            this.colCodeSpec.Name = "colCodeSpec";
            this.colCodeSpec.Visible = true;
            this.colCodeSpec.VisibleIndex = 5;
            this.colCodeSpec.Width = 130;
            // 
            // colCodeWeight
            // 
            this.colCodeWeight.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeWeight.FieldName = "CodeWeight";
            this.colCodeWeight.Name = "colCodeWeight";
            this.colCodeWeight.Visible = true;
            this.colCodeWeight.VisibleIndex = 6;
            this.colCodeWeight.Width = 90;
            // 
            // colMaterial
            // 
            this.colMaterial.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaterial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaterial.FieldName = "Material";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.Visible = true;
            this.colMaterial.VisibleIndex = 7;
            // 
            // colBrand
            // 
            this.colBrand.AppearanceHeader.Options.UseTextOptions = true;
            this.colBrand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBrand.FieldName = "Brand";
            this.colBrand.Name = "colBrand";
            this.colBrand.Visible = true;
            this.colBrand.VisibleIndex = 8;
            this.colBrand.Width = 90;
            // 
            // colUnit
            // 
            this.colUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 9;
            this.colUnit.Width = 60;
            // 
            // colIsPreferred
            // 
            this.colIsPreferred.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsPreferred.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsPreferred.FieldName = "IsPreferred";
            this.colIsPreferred.Name = "colIsPreferred";
            this.colIsPreferred.Visible = true;
            this.colIsPreferred.VisibleIndex = 10;
            this.colIsPreferred.Width = 60;
            // 
            // colIsLongPeriod
            // 
            this.colIsLongPeriod.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsLongPeriod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsLongPeriod.FieldName = "IsLongPeriod";
            this.colIsLongPeriod.Name = "colIsLongPeriod";
            this.colIsLongPeriod.Visible = true;
            this.colIsLongPeriod.VisibleIndex = 11;
            this.colIsLongPeriod.Width = 60;
            // 
            // colIsPrecious
            // 
            this.colIsPrecious.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsPrecious.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsPrecious.FieldName = "IsPrecious";
            this.colIsPrecious.Name = "colIsPrecious";
            this.colIsPrecious.Visible = true;
            this.colIsPrecious.VisibleIndex = 12;
            this.colIsPrecious.Width = 60;
            // 
            // colIsPreprocessing
            // 
            this.colIsPreprocessing.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsPreprocessing.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsPreprocessing.FieldName = "IsPreprocessing";
            this.colIsPreprocessing.Name = "colIsPreprocessing";
            this.colIsPreprocessing.Visible = true;
            this.colIsPreprocessing.VisibleIndex = 13;
            this.colIsPreprocessing.Width = 60;
            // 
            // colIsBuy1
            // 
            this.colIsBuy1.FieldName = "IsBuy";
            this.colIsBuy1.Name = "colIsBuy1";
            this.colIsBuy1.Visible = true;
            this.colIsBuy1.VisibleIndex = 14;
            this.colIsBuy1.Width = 60;
            // 
            // colDesigner
            // 
            this.colDesigner.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesigner.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesigner.FieldName = "Designer";
            this.colDesigner.Name = "colDesigner";
            this.colDesigner.Visible = true;
            this.colDesigner.VisibleIndex = 15;
            this.colDesigner.Width = 60;
            // 
            // colGetTime
            // 
            this.colGetTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colGetTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGetTime.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colGetTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colGetTime.FieldName = "GetTime";
            this.colGetTime.Name = "colGetTime";
            this.colGetTime.Visible = true;
            this.colGetTime.VisibleIndex = 16;
            this.colGetTime.Width = 90;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.labBrand);
            this.pnlTop.Controls.Add(this.lookUpBrand);
            this.pnlTop.Controls.Add(this.labCatgName);
            this.pnlTop.Controls.Add(this.lookUpCatgName);
            this.pnlTop.Controls.Add(this.textCodeName);
            this.pnlTop.Controls.Add(this.labCodeName);
            this.pnlTop.Controls.Add(this.btnQuery);
            this.pnlTop.Controls.Add(this.labPartsCodeId);
            this.pnlTop.Controls.Add(this.searchCodeFileName);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(460, 112);
            this.pnlTop.TabIndex = 1;
            // 
            // labBrand
            // 
            this.labBrand.Location = new System.Drawing.Point(20, 77);
            this.labBrand.Name = "labBrand";
            this.labBrand.Size = new System.Drawing.Size(36, 14);
            this.labBrand.TabIndex = 40;
            this.labBrand.Text = "品牌：";
            // 
            // lookUpBrand
            // 
            this.lookUpBrand.EnterMoveNextControl = true;
            this.lookUpBrand.Location = new System.Drawing.Point(86, 74);
            this.lookUpBrand.Name = "lookUpBrand";
            this.lookUpBrand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpBrand.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BrandNo", "品牌编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BrandName", "品牌名称")});
            this.lookUpBrand.Properties.DisplayMember = "BrandName";
            this.lookUpBrand.Properties.NullText = "";
            this.lookUpBrand.Properties.ValueMember = "BrandName";
            this.lookUpBrand.Size = new System.Drawing.Size(160, 20);
            this.lookUpBrand.TabIndex = 3;
            // 
            // labCatgName
            // 
            this.labCatgName.Location = new System.Drawing.Point(264, 17);
            this.labCatgName.Name = "labCatgName";
            this.labCatgName.Size = new System.Drawing.Size(60, 14);
            this.labCatgName.TabIndex = 38;
            this.labCatgName.Text = "零件分类：";
            // 
            // lookUpCatgName
            // 
            this.lookUpCatgName.EnterMoveNextControl = true;
            this.lookUpCatgName.Location = new System.Drawing.Point(330, 14);
            this.lookUpCatgName.Name = "lookUpCatgName";
            this.lookUpCatgName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCatgName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CatgName", "分类名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CatgDescription", "分类说明")});
            this.lookUpCatgName.Properties.DisplayMember = "CatgName";
            this.lookUpCatgName.Properties.NullText = "";
            this.lookUpCatgName.Properties.ValueMember = "CatgName";
            this.lookUpCatgName.Size = new System.Drawing.Size(120, 20);
            this.lookUpCatgName.TabIndex = 1;
            // 
            // textCodeName
            // 
            this.textCodeName.EnterMoveNextControl = true;
            this.textCodeName.Location = new System.Drawing.Point(86, 44);
            this.textCodeName.Name = "textCodeName";
            this.textCodeName.Size = new System.Drawing.Size(160, 20);
            this.textCodeName.TabIndex = 2;
            // 
            // labCodeName
            // 
            this.labCodeName.Location = new System.Drawing.Point(20, 47);
            this.labCodeName.Name = "labCodeName";
            this.labCodeName.Size = new System.Drawing.Size(60, 14);
            this.labCodeName.TabIndex = 18;
            this.labCodeName.Text = "零件名称：";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(264, 73);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "信息查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // labPartsCodeId
            // 
            this.labPartsCodeId.Location = new System.Drawing.Point(20, 17);
            this.labPartsCodeId.Name = "labPartsCodeId";
            this.labPartsCodeId.Size = new System.Drawing.Size(60, 14);
            this.labPartsCodeId.TabIndex = 15;
            this.labPartsCodeId.Text = "零件编号：";
            // 
            // searchCodeFileName
            // 
            this.searchCodeFileName.EnterMoveNextControl = true;
            this.searchCodeFileName.Location = new System.Drawing.Point(86, 14);
            this.searchCodeFileName.Name = "searchCodeFileName";
            this.searchCodeFileName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchCodeFileName.Properties.View = this.searchCodeFileNameView;
            this.searchCodeFileName.Size = new System.Drawing.Size(160, 20);
            this.searchCodeFileName.TabIndex = 0;
            // 
            // searchCodeFileNameView
            // 
            this.searchCodeFileNameView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchCodeFileNameView.Name = "searchCodeFileNameView";
            this.searchCodeFileNameView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchCodeFileNameView.OptionsView.ShowGroupPanel = false;
            // 
            // splitterLeft
            // 
            this.splitterLeft.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.splitterLeft.Location = new System.Drawing.Point(460, 0);
            this.splitterLeft.Name = "splitterLeft";
            this.splitterLeft.Size = new System.Drawing.Size(5, 681);
            this.splitterLeft.TabIndex = 15;
            this.splitterLeft.TabStop = false;
            // 
            // FrmPBDesignBom_PS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1484, 681);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.splitterLeft);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FrmPBDesignBom_PS";
            this.TabText = "生产视图登记";
            this.Text = "生产视图登记";
            this.Activated += new System.EventHandler(this.FrmPBDesignBom_PS_Activated);
            this.Load += new System.EventHandler(this.FrmPBDesignBom_PS_Load);
            this.Shown += new System.EventHandler(this.FrmPBDesignBom_PS_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesignBom)).EndInit();
            this.pnlDesignBom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabDesignBom)).EndInit();
            this.xtraTabDesignBom.ResumeLayout(false);
            this.PageDesignBom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditIsUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinRemainQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_DesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesignBomToolBar)).EndInit();
            this.pnlDesignBomToolBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPS)).EndInit();
            this.pnlPS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabPS)).EndInit();
            this.xtraTabPS.ResumeLayout(false);
            this.PagePS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPSBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_PSBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_PSBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePSBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPSBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsAbsorb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchBussinessBaseNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpApprovalType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPSToolBar)).EndInit();
            this.pnlPSToolBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSalesOrder)).EndInit();
            this.pnlSalesOrder.ResumeLayout(false);
            this.pnlSalesOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAutoSalesOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProjectNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabControlBaseInfo)).EndInit();
            this.TabControlBaseInfo.ResumeLayout(false);
            this.PageBomInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListBom)).EndInit();
            this.PagePartsCodeInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlPartsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSPartsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPartsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePartsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPartsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBrand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCatgName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCodeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchCodeFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchCodeFileNameView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraEditors.PanelControl pnlLeft;
        private DevExpress.XtraEditors.PanelControl pnlDesignBom;
        private DevExpress.XtraEditors.PanelControl pnlSalesOrder;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.PanelControl pnlTop;
        public System.Data.DataSet dataSet_DesignBom;
        private System.Data.DataTable dataTableDesignBom;
        private System.Windows.Forms.BindingSource bindingSource_DesignBom;
        private DevExpress.XtraEditors.LabelControl labAutoSalesOrderNo;
        private DevExpress.XtraEditors.LabelControl labProjectName;
        private DevExpress.XtraEditors.TextEdit textProjectName;
        private DevExpress.XtraEditors.TextEdit textProjectNo;
        private DevExpress.XtraEditors.LabelControl labProjectNo;
        private DevExpress.XtraTab.XtraTabControl TabControlBaseInfo;
        private DevExpress.XtraTab.XtraTabPage PageBomInfo;
        private DevExpress.XtraTab.XtraTabPage PagePartsCodeInfo;
        private System.Data.DataSet dSPartsCode;
        private System.Data.DataTable TablePartsCode;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColCodeFileName;
        private System.Data.DataColumn dataColCodeNo;
        private System.Data.DataColumn dataColCodeName;
        private System.Data.DataColumn dataColCatgName;
        private System.Data.DataColumn dataColCodeSpec;
        private System.Data.DataColumn dataColCodeWeight;
        private System.Data.DataColumn dataColMaterial;
        private System.Data.DataColumn dataColBrand;
        private System.Data.DataColumn dataColUnit;
        private System.Data.DataColumn dataColIsPreferred;
        private System.Data.DataColumn dataColIsLongPeriod;
        private System.Data.DataColumn dataColIsPrecious;
        private System.Data.DataColumn dataColIsPreprocessing;
        private System.Data.DataColumn dataColDesigner;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.BindingSource bSPartsCode;
        private DevExpress.XtraGrid.GridControl gridCrlPartsCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPartsCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCatgName;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeSpec;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn colBrand;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPreferred;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLongPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPrecious;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPreprocessing;
        private DevExpress.XtraGrid.Columns.GridColumn colDesigner;
        private DevExpress.XtraGrid.Columns.GridColumn colGetTime;
        private DevExpress.XtraTreeList.TreeList treeListBom;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CCodeFileName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CCodeName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CParentCodeFileName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CPCAutoId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CReID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CReParent;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CMaterieStateText;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CCodeSpec;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CBrand;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CUnit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CCatgName;
        private DevExpress.XtraEditors.LabelControl labPartsCodeId;
        private DevExpress.XtraEditors.SearchLookUpEdit searchCodeFileName;
        private DevExpress.XtraGrid.Views.Grid.GridView searchCodeFileNameView;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.TextEdit textCodeName;
        private DevExpress.XtraEditors.LabelControl labCodeName;
        private DevExpress.XtraEditors.LabelControl labCatgName;
        private DevExpress.XtraEditors.LookUpEdit lookUpCatgName;
        private DevExpress.XtraEditors.LabelControl labBrand;
        private DevExpress.XtraEditors.LookUpEdit lookUpBrand;
        private DevExpress.XtraEditors.ButtonEdit btnEditAutoSalesOrderNo;
        private DevExpress.XtraTreeList.TreeList treeListDesignBom;
        private System.Data.DataColumn coluReId;
        private System.Data.DataColumn coluReParent;
        private System.Data.DataColumn coluCodeFileName;
        private System.Data.DataColumn coluParentCodeFileName;
        private System.Data.DataColumn coluCodeName;
        private System.Data.DataColumn coluPbBomNo;
        private System.Data.DataColumn coluIsUse;
        private System.Data.DataColumn coluTotalQty;
        private System.Data.DataColumn coluRemainQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentCodeFileName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTotalQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeFileName1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeName1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPbBomNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsUse;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRemainQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckEditIsUse;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinRemainQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHasLevel;
        private System.Data.DataColumn coluHasLevel;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl pnlDesignBomToolBar;
        private DevExpress.XtraEditors.SimpleButton btnRecover;
        private DevExpress.XtraEditors.SimpleButton btnStop;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SplitterControl splitterLeft;
        private DevExpress.XtraEditors.SplitterControl splitterRight;
        private DevExpress.XtraEditors.PanelControl pnlPS;
        private DevExpress.XtraEditors.PanelControl pnlPSToolBar;
        private DevExpress.XtraEditors.SimpleButton btnPlan;
        private DevExpress.XtraEditors.RadioGroup radioType;
        private DevExpress.XtraTab.XtraTabControl xtraTabDesignBom;
        private DevExpress.XtraTab.XtraTabPage PageDesignBom;
        private DevExpress.XtraTab.XtraTabControl xtraTabPS;
        private DevExpress.XtraTab.XtraTabPage PagePS;
        private DevExpress.XtraEditors.SimpleButton btnDeleteBom;
        private System.Data.DataSet dataSet_PSBom;
        private System.Data.DataTable TablePSBom;
        private System.Data.DataColumn ColuAutoId;
        private System.Data.DataColumn ColBomListAutoId;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn ColumnRemainQty;
        private System.Data.DataColumn dataColIsBuy;
        private System.Data.DataColumn dataColuPbBomNo;
        private System.Data.DataColumn dataColuPlanDate;
        private System.Windows.Forms.BindingSource bindingSource_PSBom;
        private DevExpress.XtraGrid.GridControl gridControlPSBom;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPSBom;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId1;
        private DevExpress.XtraGrid.Columns.GridColumn colBomListAutoId1;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeFileName2;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeName2;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainQty1;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBuy;
        private DevExpress.XtraGrid.Columns.GridColumn colPbBomNo1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpReqDep;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchBussinessBaseNo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCBussinessBaseNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridCBussinessBaseText;
        private DevExpress.XtraGrid.Columns.GridColumn gridCBussinessCategoryText;
        private DevExpress.XtraGrid.Columns.GridColumn gridCAutoId;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckIsAbsorb;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinTax;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpApprovalType;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckIsVoucher;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colReId;
        private DevExpress.XtraEditors.SimpleButton btnAlterPSBom;
        private DevExpress.XtraEditors.SimpleButton btnCollapse;
        private DevExpress.XtraEditors.SimpleButton btnExpand;
        private System.Data.DataColumn ColIsAbsorb;
        private DevExpress.XtraGrid.Columns.GridColumn colIsAbsorb1;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private System.Data.DataColumn dataColuIsBuy;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBuy1;
        private System.Data.DataColumn dataColPrReqNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPrReqNo;
    }
}