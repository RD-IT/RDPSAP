namespace PSAP.VIEW.BSVIEW
{
    partial class FrmProductionSchedule_Drag
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.dockManagerLeft = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPnlLeft = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.pnlDesignBom = new DevExpress.XtraEditors.PanelControl();
            this.treeListDesignBom = new DevExpress.XtraTreeList.TreeList();
            this.colParentCodeFileName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAutoId1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTotalQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repSpinRemainQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colCodeFileName1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCodeName1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHasLevel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsUse = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repCheckEditIsUse = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colRemainQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPbBomNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colOpBtn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repButtonOpBtn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.bindingSource_DesignBom = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_DesignBom = new System.Data.DataSet();
            this.dataTableDesignBom = new System.Data.DataTable();
            this.coluReId = new System.Data.DataColumn();
            this.coluReParent = new System.Data.DataColumn();
            this.coluCodeFileName = new System.Data.DataColumn();
            this.coluParentCodeFileName = new System.Data.DataColumn();
            this.coluCodeName = new System.Data.DataColumn();
            this.coluAutoId = new System.Data.DataColumn();
            this.coluPbBomNo = new System.Data.DataColumn();
            this.coluIsUse = new System.Data.DataColumn();
            this.coluTotalQty = new System.Data.DataColumn();
            this.coluRemainQty = new System.Data.DataColumn();
            this.coluHasLevel = new System.Data.DataColumn();
            this.pnlSalesOrder = new DevExpress.XtraEditors.PanelControl();
            this.btnEditAutoSalesOrderNo = new DevExpress.XtraEditors.ButtonEdit();
            this.textProjectName = new DevExpress.XtraEditors.TextEdit();
            this.textProjectNo = new DevExpress.XtraEditors.TextEdit();
            this.labProjectNo = new DevExpress.XtraEditors.LabelControl();
            this.labProjectName = new DevExpress.XtraEditors.LabelControl();
            this.labAutoSalesOrderNo = new DevExpress.XtraEditors.LabelControl();
            this.pnlRight = new DevExpress.XtraEditors.PanelControl();
            this.pnlPSBom = new DevExpress.XtraEditors.PanelControl();
            this.treeListPSBom = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPbBomNo1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colReqDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bindingSource_PSBom = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_PSchedule = new System.Data.DataSet();
            this.TableProductionSchedule = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColPsNo = new System.Data.DataColumn();
            this.dataColCurrentDate = new System.Data.DataColumn();
            this.dataColReqDate = new System.Data.DataColumn();
            this.dataColPrepared = new System.Data.DataColumn();
            this.dataColPreparedIp = new System.Data.DataColumn();
            this.dataColModifier = new System.Data.DataColumn();
            this.dataColModifierIp = new System.Data.DataColumn();
            this.dataColModifierTime = new System.Data.DataColumn();
            this.dataColPsState = new System.Data.DataColumn();
            this.dataColGetTime = new System.Data.DataColumn();
            this.dataColSelect = new System.Data.DataColumn();
            this.dataColRemark = new System.Data.DataColumn();
            this.dataColSalesOrderNo = new System.Data.DataColumn();
            this.dataColPlannedText = new System.Data.DataColumn();
            this.TablePSBom = new System.Data.DataTable();
            this.ColReId = new System.Data.DataColumn();
            this.ColReParent = new System.Data.DataColumn();
            this.ColCodeFileName = new System.Data.DataColumn();
            this.dataColParentCodeFileName = new System.Data.DataColumn();
            this.ColCodeName = new System.Data.DataColumn();
            this.ColAutoId = new System.Data.DataColumn();
            this.ColPsNo = new System.Data.DataColumn();
            this.ColPurQty = new System.Data.DataColumn();
            this.dataColHasLevel = new System.Data.DataColumn();
            this.ColListAutoId = new System.Data.DataColumn();
            this.dataColuPbBomNo = new System.Data.DataColumn();
            this.dataColuReqDate = new System.Data.DataColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnBomPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnReqDate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteBom = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.buttonEditSalesOrderNo = new DevExpress.XtraEditors.ButtonEdit();
            this.bindingSource_PSchedule = new System.Windows.Forms.BindingSource(this.components);
            this.textModifier = new DevExpress.XtraEditors.TextEdit();
            this.textPrepared = new DevExpress.XtraEditors.TextEdit();
            this.dateModifierTime = new DevExpress.XtraEditors.DateEdit();
            this.labModifierTime = new DevExpress.XtraEditors.LabelControl();
            this.labModifier = new DevExpress.XtraEditors.LabelControl();
            this.labPrepared = new DevExpress.XtraEditors.LabelControl();
            this.textRemark = new DevExpress.XtraEditors.TextEdit();
            this.labRemark = new DevExpress.XtraEditors.LabelControl();
            this.textPlannedText = new DevExpress.XtraEditors.TextEdit();
            this.labPlannedText = new DevExpress.XtraEditors.LabelControl();
            this.labReqDate = new DevExpress.XtraEditors.LabelControl();
            this.dateReqDate = new DevExpress.XtraEditors.DateEdit();
            this.labCurrentDate = new DevExpress.XtraEditors.LabelControl();
            this.dateCurrentDate = new DevExpress.XtraEditors.DateEdit();
            this.labSalesOrderNo = new DevExpress.XtraEditors.LabelControl();
            this.textPsNo = new DevExpress.XtraEditors.TextEdit();
            this.labPsNo = new DevExpress.XtraEditors.LabelControl();
            this.pnlToolBar = new DevExpress.XtraEditors.PanelControl();
            this.btnEditQueryPsNo = new DevExpress.XtraEditors.ButtonEdit();
            this.labQueryAutoQuotationNo = new DevExpress.XtraEditors.LabelControl();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerLeft)).BeginInit();
            this.dockPnlLeft.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesignBom)).BeginInit();
            this.pnlDesignBom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinRemainQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditIsUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repButtonOpBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_DesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSalesOrder)).BeginInit();
            this.pnlSalesOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAutoSalesOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProjectNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPSBom)).BeginInit();
            this.pnlPSBom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListPSBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_PSBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_PSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableProductionSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePSBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditSalesOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_PSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textModifier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPrepared.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateModifierTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateModifierTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPlannedText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCurrentDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCurrentDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPsNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).BeginInit();
            this.pnlToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditQueryPsNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManagerLeft
            // 
            this.dockManagerLeft.Form = this;
            this.dockManagerLeft.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPnlLeft});
            this.dockManagerLeft.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // dockPnlLeft
            // 
            this.dockPnlLeft.Controls.Add(this.dockPanel1_Container);
            this.dockPnlLeft.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPnlLeft.ID = new System.Guid("4e45f3ad-1dee-4ff5-b648-af3a65318259");
            this.dockPnlLeft.Location = new System.Drawing.Point(0, 0);
            this.dockPnlLeft.Name = "dockPnlLeft";
            this.dockPnlLeft.Options.AllowDockAsTabbedDocument = false;
            this.dockPnlLeft.Options.AllowDockBottom = false;
            this.dockPnlLeft.Options.AllowDockFill = false;
            this.dockPnlLeft.Options.AllowDockRight = false;
            this.dockPnlLeft.Options.AllowDockTop = false;
            this.dockPnlLeft.Options.AllowFloating = false;
            this.dockPnlLeft.Options.FloatOnDblClick = false;
            this.dockPnlLeft.Options.ShowCloseButton = false;
            this.dockPnlLeft.Options.ShowMaximizeButton = false;
            this.dockPnlLeft.OriginalSize = new System.Drawing.Size(450, 200);
            this.dockPnlLeft.Size = new System.Drawing.Size(450, 635);
            this.dockPnlLeft.Text = "设计Bom信息";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.pnlDesignBom);
            this.dockPanel1_Container.Controls.Add(this.pnlSalesOrder);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(442, 608);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // pnlDesignBom
            // 
            this.pnlDesignBom.Controls.Add(this.treeListDesignBom);
            this.pnlDesignBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesignBom.Location = new System.Drawing.Point(0, 112);
            this.pnlDesignBom.Name = "pnlDesignBom";
            this.pnlDesignBom.Size = new System.Drawing.Size(442, 496);
            this.pnlDesignBom.TabIndex = 2;
            // 
            // treeListDesignBom
            // 
            this.treeListDesignBom.AllowDrop = true;
            this.treeListDesignBom.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colParentCodeFileName,
            this.colAutoId1,
            this.colTotalQty,
            this.colCodeFileName1,
            this.colCodeName1,
            this.colHasLevel,
            this.colIsUse,
            this.colRemainQty,
            this.colPbBomNo,
            this.colOpBtn});
            this.treeListDesignBom.DataSource = this.bindingSource_DesignBom;
            this.treeListDesignBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDesignBom.IndicatorWidth = 40;
            this.treeListDesignBom.KeyFieldName = "ReId";
            this.treeListDesignBom.Location = new System.Drawing.Point(2, 2);
            this.treeListDesignBom.Name = "treeListDesignBom";
            this.treeListDesignBom.OptionsBehavior.Editable = false;
            this.treeListDesignBom.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListDesignBom.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListDesignBom.OptionsView.AutoWidth = false;
            this.treeListDesignBom.OptionsView.ShowCheckBoxes = true;
            this.treeListDesignBom.OptionsView.ShowSummaryFooter = true;
            this.treeListDesignBom.ParentFieldName = "ReParent";
            this.treeListDesignBom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckEditIsUse,
            this.repSpinRemainQty,
            this.repButtonOpBtn});
            this.treeListDesignBom.Size = new System.Drawing.Size(438, 492);
            this.treeListDesignBom.TabIndex = 1;
            this.treeListDesignBom.GetNodeDisplayValue += new DevExpress.XtraTreeList.GetNodeDisplayValueEventHandler(this.treeListDesignBom_GetNodeDisplayValue);
            this.treeListDesignBom.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.treeListDesignBom_BeforeCheckNode);
            this.treeListDesignBom.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.treeListDesignBom_CustomDrawNodeIndicator);
            this.treeListDesignBom.CustomDrawNodeCheckBox += new DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventHandler(this.treeListDesignBom_CustomDrawNodeCheckBox);
            this.treeListDesignBom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeListDesignBom_KeyDown);
            this.treeListDesignBom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeListDesignBom_MouseDown);
            this.treeListDesignBom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeListDesignBom_MouseMove);
            // 
            // colParentCodeFileName
            // 
            this.colParentCodeFileName.FieldName = "ParentCodeFileName";
            this.colParentCodeFileName.Name = "colParentCodeFileName";
            this.colParentCodeFileName.Width = 30;
            // 
            // colAutoId1
            // 
            this.colAutoId1.FieldName = "AutoId";
            this.colAutoId1.Name = "colAutoId1";
            this.colAutoId1.Width = 30;
            // 
            // colTotalQty
            // 
            this.colTotalQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalQty.Caption = "数量";
            this.colTotalQty.ColumnEdit = this.repSpinRemainQty;
            this.colTotalQty.FieldName = "TotalQty";
            this.colTotalQty.Name = "colTotalQty";
            this.colTotalQty.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.colTotalQty.Width = 80;
            // 
            // repSpinRemainQty
            // 
            this.repSpinRemainQty.AutoHeight = false;
            this.repSpinRemainQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinRemainQty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinRemainQty.Name = "repSpinRemainQty";
            // 
            // colCodeFileName1
            // 
            this.colCodeFileName1.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeFileName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeFileName1.Caption = "零件编号";
            this.colCodeFileName1.FieldName = "CodeFileName";
            this.colCodeFileName1.MinWidth = 32;
            this.colCodeFileName1.Name = "colCodeFileName1";
            this.colCodeFileName1.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count;
            this.colCodeFileName1.SummaryFooterStrFormat = "共计{0}条";
            this.colCodeFileName1.Visible = true;
            this.colCodeFileName1.VisibleIndex = 0;
            this.colCodeFileName1.Width = 200;
            // 
            // colCodeName1
            // 
            this.colCodeName1.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeName1.Caption = "零件名称";
            this.colCodeName1.FieldName = "CodeName";
            this.colCodeName1.Name = "colCodeName1";
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
            this.colRemainQty.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.colRemainQty.Visible = true;
            this.colRemainQty.VisibleIndex = 3;
            this.colRemainQty.Width = 80;
            // 
            // colPbBomNo
            // 
            this.colPbBomNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colPbBomNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPbBomNo.Caption = "设计Bom编号";
            this.colPbBomNo.FieldName = "PbBomNo";
            this.colPbBomNo.Name = "colPbBomNo";
            this.colPbBomNo.Visible = true;
            this.colPbBomNo.VisibleIndex = 4;
            this.colPbBomNo.Width = 100;
            // 
            // colOpBtn
            // 
            this.colOpBtn.AppearanceHeader.Options.UseTextOptions = true;
            this.colOpBtn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOpBtn.Caption = "操作";
            this.colOpBtn.ColumnEdit = this.repButtonOpBtn;
            this.colOpBtn.FieldName = "OpBtn";
            this.colOpBtn.Name = "colOpBtn";
            // 
            // repButtonOpBtn
            // 
            this.repButtonOpBtn.AutoHeight = false;
            this.repButtonOpBtn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "增加", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "删除", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, null, true)});
            this.repButtonOpBtn.Name = "repButtonOpBtn";
            this.repButtonOpBtn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
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
            this.coluAutoId,
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
            // coluAutoId
            // 
            this.coluAutoId.ColumnName = "AutoId";
            this.coluAutoId.DataType = typeof(int);
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
            // pnlSalesOrder
            // 
            this.pnlSalesOrder.Controls.Add(this.btnEditAutoSalesOrderNo);
            this.pnlSalesOrder.Controls.Add(this.textProjectName);
            this.pnlSalesOrder.Controls.Add(this.textProjectNo);
            this.pnlSalesOrder.Controls.Add(this.labProjectNo);
            this.pnlSalesOrder.Controls.Add(this.labProjectName);
            this.pnlSalesOrder.Controls.Add(this.labAutoSalesOrderNo);
            this.pnlSalesOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSalesOrder.Location = new System.Drawing.Point(0, 0);
            this.pnlSalesOrder.Name = "pnlSalesOrder";
            this.pnlSalesOrder.Size = new System.Drawing.Size(442, 112);
            this.pnlSalesOrder.TabIndex = 1;
            // 
            // btnEditAutoSalesOrderNo
            // 
            this.btnEditAutoSalesOrderNo.Location = new System.Drawing.Point(86, 14);
            this.btnEditAutoSalesOrderNo.Name = "btnEditAutoSalesOrderNo";
            this.btnEditAutoSalesOrderNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "选择", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "", null, null, true)});
            this.btnEditAutoSalesOrderNo.Properties.ReadOnly = true;
            this.btnEditAutoSalesOrderNo.Size = new System.Drawing.Size(180, 20);
            this.btnEditAutoSalesOrderNo.TabIndex = 101;
            this.btnEditAutoSalesOrderNo.TabStop = false;
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
            // pnlRight
            // 
            this.pnlRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlRight.Controls.Add(this.pnlPSBom);
            this.pnlRight.Controls.Add(this.pnlEdit);
            this.pnlRight.Controls.Add(this.pnlToolBar);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(450, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(868, 635);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlPSBom
            // 
            this.pnlPSBom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlPSBom.Controls.Add(this.treeListPSBom);
            this.pnlPSBom.Controls.Add(this.panelControl1);
            this.pnlPSBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPSBom.Location = new System.Drawing.Point(0, 205);
            this.pnlPSBom.Name = "pnlPSBom";
            this.pnlPSBom.Size = new System.Drawing.Size(868, 430);
            this.pnlPSBom.TabIndex = 2;
            // 
            // treeListPSBom
            // 
            this.treeListPSBom.AllowDrop = true;
            this.treeListPSBom.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6,
            this.treeListColumn8,
            this.treeListColumn9,
            this.colPbBomNo1,
            this.colReqDate});
            this.treeListPSBom.DataSource = this.bindingSource_PSBom;
            this.treeListPSBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListPSBom.IndicatorWidth = 40;
            this.treeListPSBom.KeyFieldName = "ReId";
            this.treeListPSBom.Location = new System.Drawing.Point(0, 40);
            this.treeListPSBom.Name = "treeListPSBom";
            this.treeListPSBom.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListPSBom.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListPSBom.OptionsView.AutoWidth = false;
            this.treeListPSBom.OptionsView.ShowCheckBoxes = true;
            this.treeListPSBom.OptionsView.ShowSummaryFooter = true;
            this.treeListPSBom.ParentFieldName = "ReParent";
            this.treeListPSBom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemSpinEdit1});
            this.treeListPSBom.Size = new System.Drawing.Size(868, 390);
            this.treeListPSBom.TabIndex = 2;
            this.treeListPSBom.GetNodeDisplayValue += new DevExpress.XtraTreeList.GetNodeDisplayValueEventHandler(this.treeListDesignBom_GetNodeDisplayValue);
            this.treeListPSBom.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.treeListDesignBom_CustomDrawNodeIndicator);
            this.treeListPSBom.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeListPSBom_DragDrop);
            this.treeListPSBom.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeListPSBom_DragEnter);
            this.treeListPSBom.DragOver += new System.Windows.Forms.DragEventHandler(this.treeListPSBom_DragOver);
            this.treeListPSBom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeListDesignBom_KeyDown);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.FieldName = "ParentCodeFileName";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Width = 30;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.FieldName = "AutoId";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Width = 30;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn4.Caption = "零件编号";
            this.treeListColumn4.FieldName = "CodeFileName";
            this.treeListColumn4.MinWidth = 32;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count;
            this.treeListColumn4.SummaryFooterStrFormat = "共计{0}条";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 0;
            this.treeListColumn4.Width = 200;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn5.Caption = "零件名称";
            this.treeListColumn5.FieldName = "CodeName";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.OptionsColumn.AllowEdit = false;
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 1;
            this.treeListColumn5.Width = 120;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn6.Caption = "类型";
            this.treeListColumn6.FieldName = "HasLevel";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.OptionsColumn.AllowEdit = false;
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 2;
            this.treeListColumn6.Width = 40;
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn8.Caption = "采购数量";
            this.treeListColumn8.ColumnEdit = this.repositoryItemSpinEdit1;
            this.treeListColumn8.FieldName = "PurQty";
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.OptionsColumn.AllowEdit = false;
            this.treeListColumn8.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColumn8.Visible = true;
            this.treeListColumn8.VisibleIndex = 3;
            this.treeListColumn8.Width = 80;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // treeListColumn9
            // 
            this.treeListColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn9.Caption = "生产计划单号";
            this.treeListColumn9.FieldName = "PsNo";
            this.treeListColumn9.Name = "treeListColumn9";
            this.treeListColumn9.Width = 100;
            // 
            // colPbBomNo1
            // 
            this.colPbBomNo1.AppearanceHeader.Options.UseTextOptions = true;
            this.colPbBomNo1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPbBomNo1.Caption = "设计 Bom 编号";
            this.colPbBomNo1.FieldName = "PbBomNo";
            this.colPbBomNo1.Name = "colPbBomNo1";
            this.colPbBomNo1.OptionsColumn.AllowEdit = false;
            this.colPbBomNo1.Visible = true;
            this.colPbBomNo1.VisibleIndex = 4;
            this.colPbBomNo1.Width = 130;
            // 
            // colReqDate
            // 
            this.colReqDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colReqDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReqDate.Caption = "需求日期";
            this.colReqDate.FieldName = "ReqDate";
            this.colReqDate.Name = "colReqDate";
            this.colReqDate.OptionsColumn.AllowEdit = false;
            this.colReqDate.Visible = true;
            this.colReqDate.VisibleIndex = 5;
            this.colReqDate.Width = 85;
            // 
            // bindingSource_PSBom
            // 
            this.bindingSource_PSBom.DataMember = "PSBom";
            this.bindingSource_PSBom.DataSource = this.dataSet_PSchedule;
            // 
            // dataSet_PSchedule
            // 
            this.dataSet_PSchedule.DataSetName = "NewDataSet";
            this.dataSet_PSchedule.Tables.AddRange(new System.Data.DataTable[] {
            this.TableProductionSchedule,
            this.TablePSBom});
            // 
            // TableProductionSchedule
            // 
            this.TableProductionSchedule.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColPsNo,
            this.dataColCurrentDate,
            this.dataColReqDate,
            this.dataColPrepared,
            this.dataColPreparedIp,
            this.dataColModifier,
            this.dataColModifierIp,
            this.dataColModifierTime,
            this.dataColPsState,
            this.dataColGetTime,
            this.dataColSelect,
            this.dataColRemark,
            this.dataColSalesOrderNo,
            this.dataColPlannedText});
            this.TableProductionSchedule.TableName = "ProductionSchedule";
            this.TableProductionSchedule.TableNewRow += new System.Data.DataTableNewRowEventHandler(this.TableProductionSchedule_TableNewRow);
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColPsNo
            // 
            this.dataColPsNo.Caption = "生产计划单号";
            this.dataColPsNo.ColumnName = "PsNo";
            // 
            // dataColCurrentDate
            // 
            this.dataColCurrentDate.Caption = "单据日期";
            this.dataColCurrentDate.ColumnName = "CurrentDate";
            this.dataColCurrentDate.DataType = typeof(System.DateTime);
            // 
            // dataColReqDate
            // 
            this.dataColReqDate.Caption = "需求日期";
            this.dataColReqDate.ColumnName = "ReqDate";
            this.dataColReqDate.DataType = typeof(System.DateTime);
            // 
            // dataColPrepared
            // 
            this.dataColPrepared.Caption = "制单人";
            this.dataColPrepared.ColumnName = "Prepared";
            // 
            // dataColPreparedIp
            // 
            this.dataColPreparedIp.Caption = "制单人IP";
            this.dataColPreparedIp.ColumnName = "PreparedIp";
            // 
            // dataColModifier
            // 
            this.dataColModifier.Caption = "修改人";
            this.dataColModifier.ColumnName = "Modifier";
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
            // dataColPsState
            // 
            this.dataColPsState.Caption = "状态";
            this.dataColPsState.ColumnName = "PsState";
            this.dataColPsState.DataType = typeof(int);
            // 
            // dataColGetTime
            // 
            this.dataColGetTime.Caption = "登记时间";
            this.dataColGetTime.ColumnName = "GetTime";
            this.dataColGetTime.DataType = typeof(System.DateTime);
            // 
            // dataColSelect
            // 
            this.dataColSelect.Caption = "";
            this.dataColSelect.ColumnName = "Select";
            this.dataColSelect.DataType = typeof(bool);
            // 
            // dataColRemark
            // 
            this.dataColRemark.Caption = "备注";
            this.dataColRemark.ColumnName = "Remark";
            // 
            // dataColSalesOrderNo
            // 
            this.dataColSalesOrderNo.Caption = "销售单号";
            this.dataColSalesOrderNo.ColumnName = "SalesOrderNo";
            // 
            // dataColPlannedText
            // 
            this.dataColPlannedText.Caption = "计划项";
            this.dataColPlannedText.ColumnName = "PlannedText";
            // 
            // TablePSBom
            // 
            this.TablePSBom.Columns.AddRange(new System.Data.DataColumn[] {
            this.ColReId,
            this.ColReParent,
            this.ColCodeFileName,
            this.dataColParentCodeFileName,
            this.ColCodeName,
            this.ColAutoId,
            this.ColPsNo,
            this.ColPurQty,
            this.dataColHasLevel,
            this.ColListAutoId,
            this.dataColuPbBomNo,
            this.dataColuReqDate});
            this.TablePSBom.TableName = "PSBom";
            // 
            // ColReId
            // 
            this.ColReId.ColumnName = "ReId";
            // 
            // ColReParent
            // 
            this.ColReParent.ColumnName = "ReParent";
            // 
            // ColCodeFileName
            // 
            this.ColCodeFileName.Caption = "零件编号";
            this.ColCodeFileName.ColumnName = "CodeFileName";
            // 
            // dataColParentCodeFileName
            // 
            this.dataColParentCodeFileName.Caption = "父级零件编号";
            this.dataColParentCodeFileName.ColumnName = "ParentCodeFileName";
            // 
            // ColCodeName
            // 
            this.ColCodeName.Caption = "零件名称";
            this.ColCodeName.ColumnName = "CodeName";
            // 
            // ColAutoId
            // 
            this.ColAutoId.ColumnName = "AutoId";
            this.ColAutoId.DataType = typeof(int);
            // 
            // ColPsNo
            // 
            this.ColPsNo.Caption = "生产计划单号";
            this.ColPsNo.ColumnName = "PsNo";
            // 
            // ColPurQty
            // 
            this.ColPurQty.Caption = "采购数量";
            this.ColPurQty.ColumnName = "PurQty";
            this.ColPurQty.DataType = typeof(double);
            // 
            // dataColHasLevel
            // 
            this.dataColHasLevel.Caption = "类型";
            this.dataColHasLevel.ColumnName = "HasLevel";
            this.dataColHasLevel.DataType = typeof(short);
            // 
            // ColListAutoId
            // 
            this.ColListAutoId.Caption = "ListAutoId";
            this.ColListAutoId.ColumnName = "ListAutoId";
            this.ColListAutoId.DataType = typeof(int);
            // 
            // dataColuPbBomNo
            // 
            this.dataColuPbBomNo.Caption = "设计Bom编号";
            this.dataColuPbBomNo.ColumnName = "PbBomNo";
            // 
            // dataColuReqDate
            // 
            this.dataColuReqDate.Caption = "需求日期";
            this.dataColuReqDate.ColumnName = "ReqDate";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEdit1.ValueChecked = ((short)(1));
            this.repositoryItemCheckEdit1.ValueGrayed = ((short)(0));
            this.repositoryItemCheckEdit1.ValueUnchecked = ((short)(0));
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnBomPreview);
            this.panelControl1.Controls.Add(this.btnReqDate);
            this.panelControl1.Controls.Add(this.btnDeleteBom);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(868, 40);
            this.panelControl1.TabIndex = 3;
            // 
            // btnBomPreview
            // 
            this.btnBomPreview.Location = new System.Drawing.Point(253, 9);
            this.btnBomPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnBomPreview.Name = "btnBomPreview";
            this.btnBomPreview.Size = new System.Drawing.Size(75, 23);
            this.btnBomPreview.TabIndex = 54;
            this.btnBomPreview.TabStop = false;
            this.btnBomPreview.Text = "Bom 预览";
            this.btnBomPreview.Click += new System.EventHandler(this.btnBomPreview_Click);
            // 
            // btnReqDate
            // 
            this.btnReqDate.Location = new System.Drawing.Point(172, 9);
            this.btnReqDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnReqDate.Name = "btnReqDate";
            this.btnReqDate.Size = new System.Drawing.Size(75, 23);
            this.btnReqDate.TabIndex = 53;
            this.btnReqDate.TabStop = false;
            this.btnReqDate.Text = "需求日期";
            this.btnReqDate.Click += new System.EventHandler(this.btnReqDate_Click);
            // 
            // btnDeleteBom
            // 
            this.btnDeleteBom.Location = new System.Drawing.Point(91, 9);
            this.btnDeleteBom.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteBom.Name = "btnDeleteBom";
            this.btnDeleteBom.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteBom.TabIndex = 52;
            this.btnDeleteBom.TabStop = false;
            this.btnDeleteBom.Text = "删除零件";
            this.btnDeleteBom.Click += new System.EventHandler(this.btnDeleteBom_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 9);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 51;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "新增零件";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.buttonEditSalesOrderNo);
            this.pnlEdit.Controls.Add(this.textModifier);
            this.pnlEdit.Controls.Add(this.textPrepared);
            this.pnlEdit.Controls.Add(this.dateModifierTime);
            this.pnlEdit.Controls.Add(this.labModifierTime);
            this.pnlEdit.Controls.Add(this.labModifier);
            this.pnlEdit.Controls.Add(this.labPrepared);
            this.pnlEdit.Controls.Add(this.textRemark);
            this.pnlEdit.Controls.Add(this.labRemark);
            this.pnlEdit.Controls.Add(this.textPlannedText);
            this.pnlEdit.Controls.Add(this.labPlannedText);
            this.pnlEdit.Controls.Add(this.labReqDate);
            this.pnlEdit.Controls.Add(this.dateReqDate);
            this.pnlEdit.Controls.Add(this.labCurrentDate);
            this.pnlEdit.Controls.Add(this.dateCurrentDate);
            this.pnlEdit.Controls.Add(this.labSalesOrderNo);
            this.pnlEdit.Controls.Add(this.textPsNo);
            this.pnlEdit.Controls.Add(this.labPsNo);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEdit.Location = new System.Drawing.Point(0, 40);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(868, 165);
            this.pnlEdit.TabIndex = 1;
            // 
            // buttonEditSalesOrderNo
            // 
            this.buttonEditSalesOrderNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_PSchedule, "SalesOrderNo", true));
            this.buttonEditSalesOrderNo.EnterMoveNextControl = true;
            this.buttonEditSalesOrderNo.Location = new System.Drawing.Point(371, 21);
            this.buttonEditSalesOrderNo.Name = "buttonEditSalesOrderNo";
            this.buttonEditSalesOrderNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "选择", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.buttonEditSalesOrderNo.Properties.ReadOnly = true;
            this.buttonEditSalesOrderNo.Size = new System.Drawing.Size(150, 21);
            this.buttonEditSalesOrderNo.TabIndex = 1;
            this.buttonEditSalesOrderNo.TabStop = false;
            this.buttonEditSalesOrderNo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditSalesOrderNo_ButtonClick);
            // 
            // bindingSource_PSchedule
            // 
            this.bindingSource_PSchedule.DataMember = "ProductionSchedule";
            this.bindingSource_PSchedule.DataSource = this.dataSet_PSchedule;
            // 
            // textModifier
            // 
            this.textModifier.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_PSchedule, "Modifier", true));
            this.textModifier.EnterMoveNextControl = true;
            this.textModifier.Location = new System.Drawing.Point(371, 123);
            this.textModifier.Name = "textModifier";
            this.textModifier.Properties.ReadOnly = true;
            this.textModifier.Size = new System.Drawing.Size(150, 20);
            this.textModifier.TabIndex = 7;
            this.textModifier.TabStop = false;
            // 
            // textPrepared
            // 
            this.textPrepared.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_PSchedule, "Prepared", true));
            this.textPrepared.EnterMoveNextControl = true;
            this.textPrepared.Location = new System.Drawing.Point(120, 123);
            this.textPrepared.Name = "textPrepared";
            this.textPrepared.Properties.ReadOnly = true;
            this.textPrepared.Size = new System.Drawing.Size(150, 20);
            this.textPrepared.TabIndex = 6;
            this.textPrepared.TabStop = false;
            // 
            // dateModifierTime
            // 
            this.dateModifierTime.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_PSchedule, "ModifierTime", true));
            this.dateModifierTime.EditValue = null;
            this.dateModifierTime.EnterMoveNextControl = true;
            this.dateModifierTime.Location = new System.Drawing.Point(622, 123);
            this.dateModifierTime.Name = "dateModifierTime";
            this.dateModifierTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateModifierTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateModifierTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateModifierTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateModifierTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateModifierTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateModifierTime.Properties.Mask.EditMask = "G";
            this.dateModifierTime.Properties.ReadOnly = true;
            this.dateModifierTime.Size = new System.Drawing.Size(150, 20);
            this.dateModifierTime.TabIndex = 8;
            this.dateModifierTime.TabStop = false;
            // 
            // labModifierTime
            // 
            this.labModifierTime.Location = new System.Drawing.Point(550, 126);
            this.labModifierTime.Name = "labModifierTime";
            this.labModifierTime.Size = new System.Drawing.Size(48, 14);
            this.labModifierTime.TabIndex = 27;
            this.labModifierTime.Text = "修改时间";
            // 
            // labModifier
            // 
            this.labModifier.Location = new System.Drawing.Point(296, 126);
            this.labModifier.Name = "labModifier";
            this.labModifier.Size = new System.Drawing.Size(36, 14);
            this.labModifier.TabIndex = 26;
            this.labModifier.Text = "修改人";
            // 
            // labPrepared
            // 
            this.labPrepared.Location = new System.Drawing.Point(36, 126);
            this.labPrepared.Name = "labPrepared";
            this.labPrepared.Size = new System.Drawing.Size(36, 14);
            this.labPrepared.TabIndex = 25;
            this.labPrepared.Text = "制单人";
            // 
            // textRemark
            // 
            this.textRemark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_PSchedule, "Remark", true));
            this.textRemark.EnterMoveNextControl = true;
            this.textRemark.Location = new System.Drawing.Point(120, 89);
            this.textRemark.Name = "textRemark";
            this.textRemark.Size = new System.Drawing.Size(652, 20);
            this.textRemark.TabIndex = 5;
            // 
            // labRemark
            // 
            this.labRemark.Location = new System.Drawing.Point(36, 92);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new System.Drawing.Size(24, 14);
            this.labRemark.TabIndex = 24;
            this.labRemark.Text = "备注";
            // 
            // textPlannedText
            // 
            this.textPlannedText.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_PSchedule, "PlannedText", true));
            this.textPlannedText.EnterMoveNextControl = true;
            this.textPlannedText.Location = new System.Drawing.Point(371, 57);
            this.textPlannedText.Name = "textPlannedText";
            this.textPlannedText.Size = new System.Drawing.Size(401, 20);
            this.textPlannedText.TabIndex = 4;
            // 
            // labPlannedText
            // 
            this.labPlannedText.Location = new System.Drawing.Point(296, 60);
            this.labPlannedText.Name = "labPlannedText";
            this.labPlannedText.Size = new System.Drawing.Size(36, 14);
            this.labPlannedText.TabIndex = 19;
            this.labPlannedText.Text = "计划项";
            // 
            // labReqDate
            // 
            this.labReqDate.Location = new System.Drawing.Point(36, 58);
            this.labReqDate.Name = "labReqDate";
            this.labReqDate.Size = new System.Drawing.Size(48, 14);
            this.labReqDate.TabIndex = 17;
            this.labReqDate.Text = "需求日期";
            // 
            // dateReqDate
            // 
            this.dateReqDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_PSchedule, "ReqDate", true));
            this.dateReqDate.EditValue = null;
            this.dateReqDate.EnterMoveNextControl = true;
            this.dateReqDate.Location = new System.Drawing.Point(120, 57);
            this.dateReqDate.Name = "dateReqDate";
            this.dateReqDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateReqDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateReqDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateReqDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateReqDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateReqDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateReqDate.Size = new System.Drawing.Size(150, 20);
            this.dateReqDate.TabIndex = 3;
            // 
            // labCurrentDate
            // 
            this.labCurrentDate.Location = new System.Drawing.Point(550, 24);
            this.labCurrentDate.Name = "labCurrentDate";
            this.labCurrentDate.Size = new System.Drawing.Size(48, 14);
            this.labCurrentDate.TabIndex = 15;
            this.labCurrentDate.Text = "单据日期";
            // 
            // dateCurrentDate
            // 
            this.dateCurrentDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_PSchedule, "CurrentDate", true));
            this.dateCurrentDate.EditValue = null;
            this.dateCurrentDate.EnterMoveNextControl = true;
            this.dateCurrentDate.Location = new System.Drawing.Point(622, 21);
            this.dateCurrentDate.Name = "dateCurrentDate";
            this.dateCurrentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateCurrentDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateCurrentDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateCurrentDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateCurrentDate.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateCurrentDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateCurrentDate.Properties.Mask.EditMask = "G";
            this.dateCurrentDate.Properties.ReadOnly = true;
            this.dateCurrentDate.Size = new System.Drawing.Size(150, 20);
            this.dateCurrentDate.TabIndex = 2;
            this.dateCurrentDate.TabStop = false;
            // 
            // labSalesOrderNo
            // 
            this.labSalesOrderNo.Location = new System.Drawing.Point(296, 24);
            this.labSalesOrderNo.Name = "labSalesOrderNo";
            this.labSalesOrderNo.Size = new System.Drawing.Size(48, 14);
            this.labSalesOrderNo.TabIndex = 3;
            this.labSalesOrderNo.Text = "销售单号";
            // 
            // textPsNo
            // 
            this.textPsNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_PSchedule, "PsNo", true));
            this.textPsNo.EnterMoveNextControl = true;
            this.textPsNo.Location = new System.Drawing.Point(120, 21);
            this.textPsNo.Name = "textPsNo";
            this.textPsNo.Properties.ReadOnly = true;
            this.textPsNo.Size = new System.Drawing.Size(150, 20);
            this.textPsNo.TabIndex = 0;
            this.textPsNo.TabStop = false;
            // 
            // labPsNo
            // 
            this.labPsNo.Location = new System.Drawing.Point(36, 24);
            this.labPsNo.Name = "labPsNo";
            this.labPsNo.Size = new System.Drawing.Size(72, 14);
            this.labPsNo.TabIndex = 2;
            this.labPsNo.Text = "生产计划单号";
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Controls.Add(this.btnEditQueryPsNo);
            this.pnlToolBar.Controls.Add(this.labQueryAutoQuotationNo);
            this.pnlToolBar.Controls.Add(this.btnPreview);
            this.pnlToolBar.Controls.Add(this.btnRefresh);
            this.pnlToolBar.Controls.Add(this.btnDelete);
            this.pnlToolBar.Controls.Add(this.btnCancel);
            this.pnlToolBar.Controls.Add(this.btnSave);
            this.pnlToolBar.Controls.Add(this.btnNew);
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(868, 40);
            this.pnlToolBar.TabIndex = 0;
            // 
            // btnEditQueryPsNo
            // 
            this.btnEditQueryPsNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditQueryPsNo.Location = new System.Drawing.Point(676, 10);
            this.btnEditQueryPsNo.Name = "btnEditQueryPsNo";
            this.btnEditQueryPsNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.btnEditQueryPsNo.Properties.NullValuePrompt = "请输入生产计划单号....";
            this.btnEditQueryPsNo.Properties.NullValuePromptShowForEmptyValue = true;
            this.btnEditQueryPsNo.Size = new System.Drawing.Size(180, 20);
            this.btnEditQueryPsNo.TabIndex = 34;
            this.btnEditQueryPsNo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEditQueryPsNo_ButtonClick);
            this.btnEditQueryPsNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEditQueryPsNo_KeyDown);
            // 
            // labQueryAutoQuotationNo
            // 
            this.labQueryAutoQuotationNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labQueryAutoQuotationNo.Location = new System.Drawing.Point(596, 13);
            this.labQueryAutoQuotationNo.Name = "labQueryAutoQuotationNo";
            this.labQueryAutoQuotationNo.Size = new System.Drawing.Size(72, 14);
            this.labQueryAutoQuotationNo.TabIndex = 33;
            this.labQueryAutoQuotationNo.Text = "生产计划单号";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(415, 9);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 32;
            this.btnPreview.TabStop = false;
            this.btnPreview.Text = "预览";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(334, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "查询";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(253, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(172, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(91, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "修改";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(10, 9);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 27;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // FrmProductionSchedule_Drag
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1318, 635);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.dockPnlLeft);
            this.Name = "FrmProductionSchedule_Drag";
            this.TabText = "生产计划单";
            this.Text = "生产计划单";
            this.Activated += new System.EventHandler(this.FrmProductionSchedule_Drag_Activated);
            this.Load += new System.EventHandler(this.FrmProductionSchedule_Drag_Load);
            this.Shown += new System.EventHandler(this.FrmProductionSchedule_Drag_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerLeft)).EndInit();
            this.dockPnlLeft.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesignBom)).EndInit();
            this.pnlDesignBom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinRemainQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditIsUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repButtonOpBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_DesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSalesOrder)).EndInit();
            this.pnlSalesOrder.ResumeLayout(false);
            this.pnlSalesOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAutoSalesOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProjectNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPSBom)).EndInit();
            this.pnlPSBom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListPSBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_PSBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_PSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableProductionSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePSBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditSalesOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_PSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textModifier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPrepared.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateModifierTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateModifierTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPlannedText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateReqDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCurrentDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCurrentDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPsNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).EndInit();
            this.pnlToolBar.ResumeLayout(false);
            this.pnlToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditQueryPsNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManagerLeft;
        private DevExpress.XtraBars.Docking.DockPanel dockPnlLeft;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.PanelControl pnlSalesOrder;
        private DevExpress.XtraEditors.ButtonEdit btnEditAutoSalesOrderNo;
        private DevExpress.XtraEditors.TextEdit textProjectName;
        private DevExpress.XtraEditors.TextEdit textProjectNo;
        private DevExpress.XtraEditors.LabelControl labProjectNo;
        private DevExpress.XtraEditors.LabelControl labProjectName;
        private DevExpress.XtraEditors.LabelControl labAutoSalesOrderNo;
        private DevExpress.XtraEditors.PanelControl pnlDesignBom;
        public System.Data.DataSet dataSet_DesignBom;
        private System.Data.DataTable dataTableDesignBom;
        private System.Data.DataColumn coluReId;
        private System.Data.DataColumn coluReParent;
        private System.Data.DataColumn coluCodeFileName;
        private System.Data.DataColumn coluParentCodeFileName;
        private System.Data.DataColumn coluCodeName;
        private System.Data.DataColumn coluAutoId;
        private System.Data.DataColumn coluPbBomNo;
        private System.Data.DataColumn coluIsUse;
        private System.Data.DataColumn coluTotalQty;
        private System.Data.DataColumn coluRemainQty;
        private System.Data.DataColumn coluHasLevel;
        private System.Windows.Forms.BindingSource bindingSource_DesignBom;
        private DevExpress.XtraTreeList.TreeList treeListDesignBom;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentCodeFileName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAutoId1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTotalQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeFileName1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeName1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHasLevel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsUse;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckEditIsUse;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRemainQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinRemainQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPbBomNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOpBtn;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repButtonOpBtn;
        private DevExpress.XtraEditors.PanelControl pnlRight;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.PanelControl pnlToolBar;
        private DevExpress.XtraEditors.PanelControl pnlPSBom;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.TextEdit textPsNo;
        private DevExpress.XtraEditors.LabelControl labPsNo;
        private DevExpress.XtraEditors.LabelControl labSalesOrderNo;
        private System.Data.DataSet dataSet_PSchedule;
        private System.Data.DataTable TableProductionSchedule;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColPsNo;
        private System.Data.DataColumn dataColCurrentDate;
        private System.Data.DataColumn dataColReqDate;
        private System.Data.DataColumn dataColPrepared;
        private System.Data.DataColumn dataColPreparedIp;
        private System.Data.DataColumn dataColModifier;
        private System.Data.DataColumn dataColModifierIp;
        private System.Data.DataColumn dataColModifierTime;
        private System.Data.DataColumn dataColPsState;
        private System.Data.DataColumn dataColGetTime;
        private System.Data.DataColumn dataColSelect;
        private System.Data.DataColumn dataColRemark;
        private System.Data.DataColumn dataColSalesOrderNo;
        private System.Data.DataColumn dataColPlannedText;
        private DevExpress.XtraEditors.LabelControl labReqDate;
        private DevExpress.XtraEditors.DateEdit dateReqDate;
        private DevExpress.XtraEditors.LabelControl labCurrentDate;
        private DevExpress.XtraEditors.DateEdit dateCurrentDate;
        private DevExpress.XtraEditors.TextEdit textPlannedText;
        private DevExpress.XtraEditors.LabelControl labPlannedText;
        private DevExpress.XtraEditors.TextEdit textModifier;
        private DevExpress.XtraEditors.TextEdit textPrepared;
        private DevExpress.XtraEditors.DateEdit dateModifierTime;
        private DevExpress.XtraEditors.LabelControl labModifierTime;
        private DevExpress.XtraEditors.LabelControl labModifier;
        private DevExpress.XtraEditors.LabelControl labPrepared;
        private DevExpress.XtraEditors.TextEdit textRemark;
        private DevExpress.XtraEditors.LabelControl labRemark;
        private System.Windows.Forms.BindingSource bindingSource_PSchedule;
        private DevExpress.XtraEditors.ButtonEdit btnEditQueryPsNo;
        private DevExpress.XtraEditors.LabelControl labQueryAutoQuotationNo;
        private System.Data.DataTable TablePSBom;
        private System.Data.DataColumn ColReId;
        private System.Data.DataColumn ColReParent;
        private System.Data.DataColumn ColCodeFileName;
        private System.Data.DataColumn dataColParentCodeFileName;
        private System.Data.DataColumn ColCodeName;
        private System.Data.DataColumn ColAutoId;
        private System.Data.DataColumn ColPsNo;
        private System.Data.DataColumn ColPurQty;
        private System.Data.DataColumn dataColHasLevel;
        private System.Data.DataColumn ColListAutoId;
        private DevExpress.XtraTreeList.TreeList treeListPSBom;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
        private System.Windows.Forms.BindingSource bindingSource_PSBom;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.ButtonEdit buttonEditSalesOrderNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPbBomNo1;
        private System.Data.DataColumn dataColuPbBomNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colReqDate;
        private System.Data.DataColumn dataColuReqDate;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnReqDate;
        private DevExpress.XtraEditors.SimpleButton btnDeleteBom;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnBomPreview;
    }
}