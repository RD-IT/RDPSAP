namespace PSAP.VIEW.BSVIEW
{
    partial class FrmInventoryMove_Drag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventoryMove_Drag));
            this.dataSet_IM = new System.Data.DataSet();
            this.dataTableIMHead = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColInventoryMoveNo = new System.Data.DataColumn();
            this.dataColInventoryMoveDate = new System.Data.DataColumn();
            this.dataColInRepertoryId = new System.Data.DataColumn();
            this.dataColOutRepertoryId = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColCreatorIp = new System.Data.DataColumn();
            this.dataColumnRemark = new System.Data.DataColumn();
            this.dataColModifier = new System.Data.DataColumn();
            this.dataColModifierIp = new System.Data.DataColumn();
            this.dataColModifierTime = new System.Data.DataColumn();
            this.dataColSelect = new System.Data.DataColumn();
            this.dataColReqDep = new System.Data.DataColumn();
            this.dataColInLocationId = new System.Data.DataColumn();
            this.dataColOutLocationId = new System.Data.DataColumn();
            this.dataTableIMList = new System.Data.DataTable();
            this.dataColumnAutoId = new System.Data.DataColumn();
            this.dataColumnInventoryMoveNo = new System.Data.DataColumn();
            this.dataColCodeFileName = new System.Data.DataColumn();
            this.dataColQty = new System.Data.DataColumn();
            this.dataColInProjectNo = new System.Data.DataColumn();
            this.dataColInShelfNo = new System.Data.DataColumn();
            this.dataColRemark = new System.Data.DataColumn();
            this.dataColOutProjectNo = new System.Data.DataColumn();
            this.dataColOutShelfNo = new System.Data.DataColumn();
            this.dataColumnInventoryMoveDate = new System.Data.DataColumn();
            this.dataColumnInRepertoryId = new System.Data.DataColumn();
            this.dataColumnOutRepertoryId = new System.Data.DataColumn();
            this.dataColCodeName = new System.Data.DataColumn();
            this.dataColInProjectName = new System.Data.DataColumn();
            this.dataColOutProjectName = new System.Data.DataColumn();
            this.dataColuInLocationId = new System.Data.DataColumn();
            this.dataColuOutLocationId = new System.Data.DataColumn();
            this.bindingSource_IMHead = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource_IMList = new System.Windows.Forms.BindingSource(this.components);
            this.dockManagerLeft = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPnlLeft = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.pnlLeftMiddle = new DevExpress.XtraEditors.PanelControl();
            this.gridControlWNowInfo = new DevExpress.XtraGrid.GridControl();
            this.bindingSource_WNowInfo = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_WNowInfo = new System.Data.DataSet();
            this.TableWNowInfo = new System.Data.DataTable();
            this.dataAutoId = new System.Data.DataColumn();
            this.dataCodeFileName = new System.Data.DataColumn();
            this.dataCodeName = new System.Data.DataColumn();
            this.dataProjectNo = new System.Data.DataColumn();
            this.dataProjectName = new System.Data.DataColumn();
            this.dataRepertoryId = new System.Data.DataColumn();
            this.dataShelfId = new System.Data.DataColumn();
            this.dataQty = new System.Data.DataColumn();
            this.dataColumnLocationId = new System.Data.DataColumn();
            this.gridViewWNowInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepertoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSShelfId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpShelfId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProjectNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpLocationId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.pnlLeftTop = new DevExpress.XtraEditors.PanelControl();
            this.checkZero = new DevExpress.XtraEditors.CheckEdit();
            this.lookUpRepertoryId = new DevExpress.XtraEditors.LookUpEdit();
            this.searchLookUpCodeFileName = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpCodeFileNameView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labCodeFileName = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpProjectNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpProjectNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnWNowInfoQuery = new DevExpress.XtraEditors.SimpleButton();
            this.labProjectNo = new DevExpress.XtraEditors.LabelControl();
            this.labPrReqNo = new DevExpress.XtraEditors.LabelControl();
            this.pnlRight = new DevExpress.XtraEditors.PanelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnListAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlIMList = new DevExpress.XtraGrid.GridControl();
            this.gridViewIMList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnInventoryMoveNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchCodeFileName = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchCodeFileNameView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCodeFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSpinQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repbtnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colOutProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchOutProjectNo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchOutProjectNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutShelfId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchOutShelfId = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchOutShelfNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInShelfId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventoryMoveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnOutRepertoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnInRepertoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.checkAll = new DevExpress.XtraEditors.CheckEdit();
            this.gridControlIMHead = new DevExpress.XtraGrid.GridControl();
            this.gridViewIMHead = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colInventoryMoveNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderHeadDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInRepertoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpInRepertoryId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colOutRepertoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReqDep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpReqDep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colPRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModifier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInLocationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSearchInLocationId = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repSearchInLocationIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutLocationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlMiddleTop = new DevExpress.XtraEditors.PanelControl();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.pnltop = new DevExpress.XtraEditors.PanelControl();
            this.labInLocationId = new DevExpress.XtraEditors.LabelControl();
            this.SearchInLocationId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.SearchInLocationIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuLocationNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuLocationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuRepertoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labOutLocationId = new DevExpress.XtraEditors.LabelControl();
            this.SearchOutLocationId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.SearchOutLocationIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpOutRepertoryId = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpReqDep = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpInRepertoryId = new DevExpress.XtraEditors.LookUpEdit();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.textCommon = new DevExpress.XtraEditors.TextEdit();
            this.lookUpCreator = new DevExpress.XtraEditors.LookUpEdit();
            this.dateIMDateEnd = new DevExpress.XtraEditors.DateEdit();
            this.lab1 = new DevExpress.XtraEditors.LabelControl();
            this.dateIMDateBegin = new DevExpress.XtraEditors.DateEdit();
            this.labReqDep = new DevExpress.XtraEditors.LabelControl();
            this.labOutRepertoryId = new DevExpress.XtraEditors.LabelControl();
            this.labInRepertoryId = new DevExpress.XtraEditors.LabelControl();
            this.labCommon = new DevExpress.XtraEditors.LabelControl();
            this.labCreator = new DevExpress.XtraEditors.LabelControl();
            this.labIMDate = new DevExpress.XtraEditors.LabelControl();
            this.cms1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRkrqbnwkcx = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDqrkdyjxghh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRkbmbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRkckbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRklbbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSplxbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRkmxbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSlbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHjbhbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQgsyansjcw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRkdmxbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCxmxdsyjcgdcw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCxmxdxyjcgjzdcw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDgrqbnwkcx = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCxcgddsjcw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiJjcxcgddmxsjcw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSxtzcgddsjcw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiYzrkdzrxxtdxmhjxdj = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiYzrkdzrxxtdgysjxdj = new System.Windows.Forms.ToolStripMenuItem();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCkrqbnwkcx = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDqckdyjxghh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCkbmbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCkckbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCklbbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCkdmxbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiYzkcyddbxxz = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiYdrqbnwkcx = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDqkcyddyjxghh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSqbmbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCkxmhbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCkhjhbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRkxmhbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRkhjhbnwkbc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCkdckxmhhjhhrk = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSxtddqkcsjcw = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colOutLocationId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInLocationId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_IM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableIMHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableIMList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_IMHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_IMList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerLeft)).BeginInit();
            this.dockPnlLeft.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftMiddle)).BeginInit();
            this.pnlLeftMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWNowInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_WNowInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_WNowInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWNowInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWNowInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpShelfId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpLocationId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftTop)).BeginInit();
            this.pnlLeftTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkZero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileNameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIMList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIMList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchCodeFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchCodeFileNameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repbtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchOutProjectNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchOutProjectNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchOutShelfId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchOutShelfNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIMHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIMHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpInRepertoryId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchInLocationId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchInLocationIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddleTop)).BeginInit();
            this.pnlMiddleTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchInLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchInLocationIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchOutLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchOutLocationIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpOutRepertoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpInRepertoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCreator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIMDateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIMDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIMDateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIMDateBegin.Properties)).BeginInit();
            this.cms1.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSet_IM
            // 
            this.dataSet_IM.DataSetName = "NewDataSet";
            this.dataSet_IM.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableIMHead,
            this.dataTableIMList});
            // 
            // dataTableIMHead
            // 
            this.dataTableIMHead.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColInventoryMoveNo,
            this.dataColInventoryMoveDate,
            this.dataColInRepertoryId,
            this.dataColOutRepertoryId,
            this.dataColCreator,
            this.dataColCreatorIp,
            this.dataColumnRemark,
            this.dataColModifier,
            this.dataColModifierIp,
            this.dataColModifierTime,
            this.dataColSelect,
            this.dataColReqDep,
            this.dataColInLocationId,
            this.dataColOutLocationId});
            this.dataTableIMHead.TableName = "IMHead";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColInventoryMoveNo
            // 
            this.dataColInventoryMoveNo.Caption = "移动单号";
            this.dataColInventoryMoveNo.ColumnName = "InventoryMoveNo";
            // 
            // dataColInventoryMoveDate
            // 
            this.dataColInventoryMoveDate.Caption = "移动日期";
            this.dataColInventoryMoveDate.ColumnName = "InventoryMoveDate";
            this.dataColInventoryMoveDate.DataType = typeof(System.DateTime);
            // 
            // dataColInRepertoryId
            // 
            this.dataColInRepertoryId.Caption = "入库仓库";
            this.dataColInRepertoryId.ColumnName = "InRepertoryId";
            this.dataColInRepertoryId.DataType = typeof(int);
            // 
            // dataColOutRepertoryId
            // 
            this.dataColOutRepertoryId.Caption = "出库仓库";
            this.dataColOutRepertoryId.ColumnName = "OutRepertoryId";
            this.dataColOutRepertoryId.DataType = typeof(int);
            // 
            // dataColCreator
            // 
            this.dataColCreator.Caption = "制单人";
            this.dataColCreator.ColumnName = "Creator";
            this.dataColCreator.DataType = typeof(int);
            // 
            // dataColCreatorIp
            // 
            this.dataColCreatorIp.Caption = "制单人IP";
            this.dataColCreatorIp.ColumnName = "CreatorIp";
            // 
            // dataColumnRemark
            // 
            this.dataColumnRemark.Caption = "备注";
            this.dataColumnRemark.ColumnName = "Remark";
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
            // dataColSelect
            // 
            this.dataColSelect.Caption = "";
            this.dataColSelect.ColumnName = "Select";
            this.dataColSelect.DataType = typeof(bool);
            // 
            // dataColReqDep
            // 
            this.dataColReqDep.Caption = "部门";
            this.dataColReqDep.ColumnName = "ReqDep";
            // 
            // dataColInLocationId
            // 
            this.dataColInLocationId.Caption = "入库仓位";
            this.dataColInLocationId.ColumnName = "InLocationId";
            this.dataColInLocationId.DataType = typeof(int);
            // 
            // dataColOutLocationId
            // 
            this.dataColOutLocationId.Caption = "出库仓位";
            this.dataColOutLocationId.ColumnName = "OutLocationId";
            this.dataColOutLocationId.DataType = typeof(int);
            // 
            // dataTableIMList
            // 
            this.dataTableIMList.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnAutoId,
            this.dataColumnInventoryMoveNo,
            this.dataColCodeFileName,
            this.dataColQty,
            this.dataColInProjectNo,
            this.dataColInShelfNo,
            this.dataColRemark,
            this.dataColOutProjectNo,
            this.dataColOutShelfNo,
            this.dataColumnInventoryMoveDate,
            this.dataColumnInRepertoryId,
            this.dataColumnOutRepertoryId,
            this.dataColCodeName,
            this.dataColInProjectName,
            this.dataColOutProjectName,
            this.dataColuInLocationId,
            this.dataColuOutLocationId});
            this.dataTableIMList.TableName = "IMList";
            // 
            // dataColumnAutoId
            // 
            this.dataColumnAutoId.ColumnName = "AutoId";
            this.dataColumnAutoId.DataType = typeof(int);
            // 
            // dataColumnInventoryMoveNo
            // 
            this.dataColumnInventoryMoveNo.Caption = "移动单号";
            this.dataColumnInventoryMoveNo.ColumnName = "InventoryMoveNo";
            // 
            // dataColCodeFileName
            // 
            this.dataColCodeFileName.Caption = "零件编号";
            this.dataColCodeFileName.ColumnName = "CodeFileName";
            // 
            // dataColQty
            // 
            this.dataColQty.Caption = "移动数量";
            this.dataColQty.ColumnName = "Qty";
            this.dataColQty.DataType = typeof(double);
            // 
            // dataColInProjectNo
            // 
            this.dataColInProjectNo.Caption = "入库项目号";
            this.dataColInProjectNo.ColumnName = "InProjectNo";
            // 
            // dataColInShelfNo
            // 
            this.dataColInShelfNo.Caption = "入库货架号";
            this.dataColInShelfNo.ColumnName = "InShelfId";
            this.dataColInShelfNo.DataType = typeof(int);
            // 
            // dataColRemark
            // 
            this.dataColRemark.Caption = "备注";
            this.dataColRemark.ColumnName = "Remark";
            // 
            // dataColOutProjectNo
            // 
            this.dataColOutProjectNo.Caption = "出库项目号";
            this.dataColOutProjectNo.ColumnName = "OutProjectNo";
            // 
            // dataColOutShelfNo
            // 
            this.dataColOutShelfNo.Caption = "出库货架号";
            this.dataColOutShelfNo.ColumnName = "OutShelfId";
            this.dataColOutShelfNo.DataType = typeof(int);
            // 
            // dataColumnInventoryMoveDate
            // 
            this.dataColumnInventoryMoveDate.Caption = "移动日期";
            this.dataColumnInventoryMoveDate.ColumnName = "InventoryMoveDate";
            this.dataColumnInventoryMoveDate.DataType = typeof(System.DateTime);
            // 
            // dataColumnInRepertoryId
            // 
            this.dataColumnInRepertoryId.Caption = "入库仓库";
            this.dataColumnInRepertoryId.ColumnName = "InRepertoryId";
            this.dataColumnInRepertoryId.DataType = typeof(int);
            // 
            // dataColumnOutRepertoryId
            // 
            this.dataColumnOutRepertoryId.Caption = "出库仓库";
            this.dataColumnOutRepertoryId.ColumnName = "OutRepertoryId";
            this.dataColumnOutRepertoryId.DataType = typeof(int);
            // 
            // dataColCodeName
            // 
            this.dataColCodeName.Caption = "零件名称";
            this.dataColCodeName.ColumnName = "CodeName";
            // 
            // dataColInProjectName
            // 
            this.dataColInProjectName.Caption = "入库项目名称";
            this.dataColInProjectName.ColumnName = "InProjectName";
            // 
            // dataColOutProjectName
            // 
            this.dataColOutProjectName.Caption = "出库项目名称";
            this.dataColOutProjectName.ColumnName = "OutProjectName";
            // 
            // dataColuInLocationId
            // 
            this.dataColuInLocationId.Caption = "入库仓位";
            this.dataColuInLocationId.ColumnName = "InLocationId";
            this.dataColuInLocationId.DataType = typeof(int);
            // 
            // dataColuOutLocationId
            // 
            this.dataColuOutLocationId.Caption = "出库仓位";
            this.dataColuOutLocationId.ColumnName = "OutLocationId";
            this.dataColuOutLocationId.DataType = typeof(int);
            // 
            // bindingSource_IMHead
            // 
            this.bindingSource_IMHead.DataMember = "IMHead";
            this.bindingSource_IMHead.DataSource = this.dataSet_IM;
            // 
            // bindingSource_IMList
            // 
            this.bindingSource_IMList.DataMember = "IMList";
            this.bindingSource_IMList.DataSource = this.dataSet_IM;
            // 
            // dockManagerLeft
            // 
            this.dockManagerLeft.AutoHideSpeed = 5;
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
            this.dockPnlLeft.ID = new System.Guid("b4bf55cd-2af8-430c-bdda-dcc8c365bf19");
            this.dockPnlLeft.Image = ((System.Drawing.Image)(resources.GetObject("dockPnlLeft.Image")));
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
            this.dockPnlLeft.OriginalSize = new System.Drawing.Size(350, 200);
            this.dockPnlLeft.Size = new System.Drawing.Size(350, 601);
            this.dockPnlLeft.Text = "当前库存";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.pnlLeftMiddle);
            this.dockPanel1_Container.Controls.Add(this.pnlLeftTop);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(342, 574);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // pnlLeftMiddle
            // 
            this.pnlLeftMiddle.Controls.Add(this.gridControlWNowInfo);
            this.pnlLeftMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftMiddle.Location = new System.Drawing.Point(0, 110);
            this.pnlLeftMiddle.Name = "pnlLeftMiddle";
            this.pnlLeftMiddle.Size = new System.Drawing.Size(342, 464);
            this.pnlLeftMiddle.TabIndex = 2;
            // 
            // gridControlWNowInfo
            // 
            this.gridControlWNowInfo.AllowDrop = true;
            this.gridControlWNowInfo.DataSource = this.bindingSource_WNowInfo;
            this.gridControlWNowInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlWNowInfo.Location = new System.Drawing.Point(2, 2);
            this.gridControlWNowInfo.MainView = this.gridViewWNowInfo;
            this.gridControlWNowInfo.Name = "gridControlWNowInfo";
            this.gridControlWNowInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpRepertoryId,
            this.repLookUpLocationId,
            this.repLookUpShelfId});
            this.gridControlWNowInfo.Size = new System.Drawing.Size(338, 460);
            this.gridControlWNowInfo.TabIndex = 4;
            this.gridControlWNowInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWNowInfo});
            // 
            // bindingSource_WNowInfo
            // 
            this.bindingSource_WNowInfo.DataMember = "WNowInfo";
            this.bindingSource_WNowInfo.DataSource = this.dataSet_WNowInfo;
            // 
            // dataSet_WNowInfo
            // 
            this.dataSet_WNowInfo.DataSetName = "NewDataSet";
            this.dataSet_WNowInfo.Tables.AddRange(new System.Data.DataTable[] {
            this.TableWNowInfo});
            // 
            // TableWNowInfo
            // 
            this.TableWNowInfo.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataAutoId,
            this.dataCodeFileName,
            this.dataCodeName,
            this.dataProjectNo,
            this.dataProjectName,
            this.dataRepertoryId,
            this.dataShelfId,
            this.dataQty,
            this.dataColumnLocationId});
            this.TableWNowInfo.TableName = "WNowInfo";
            // 
            // dataAutoId
            // 
            this.dataAutoId.ColumnName = "AutoId";
            this.dataAutoId.DataType = typeof(int);
            // 
            // dataCodeFileName
            // 
            this.dataCodeFileName.Caption = "零件编号";
            this.dataCodeFileName.ColumnName = "CodeFileName";
            // 
            // dataCodeName
            // 
            this.dataCodeName.Caption = "零件名称";
            this.dataCodeName.ColumnName = "CodeName";
            // 
            // dataProjectNo
            // 
            this.dataProjectNo.Caption = "项目号";
            this.dataProjectNo.ColumnName = "ProjectNo";
            // 
            // dataProjectName
            // 
            this.dataProjectName.Caption = "项目号";
            this.dataProjectName.ColumnName = "ProjectName";
            // 
            // dataRepertoryId
            // 
            this.dataRepertoryId.Caption = "仓库";
            this.dataRepertoryId.ColumnName = "RepertoryId";
            this.dataRepertoryId.DataType = typeof(int);
            // 
            // dataShelfId
            // 
            this.dataShelfId.Caption = "货架号";
            this.dataShelfId.ColumnName = "ShelfId";
            this.dataShelfId.DataType = typeof(int);
            // 
            // dataQty
            // 
            this.dataQty.Caption = "数量";
            this.dataQty.ColumnName = "Qty";
            this.dataQty.DataType = typeof(double);
            // 
            // dataColumnLocationId
            // 
            this.dataColumnLocationId.Caption = "仓位";
            this.dataColumnLocationId.ColumnName = "LocationId";
            this.dataColumnLocationId.DataType = typeof(int);
            // 
            // gridViewWNowInfo
            // 
            this.gridViewWNowInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn18,
            this.gridColumn19,
            this.colProjectName,
            this.colRepertoryId,
            this.colSShelfId,
            this.colProjectNo1,
            this.colLocationId});
            this.gridViewWNowInfo.GridControl = this.gridControlWNowInfo;
            this.gridViewWNowInfo.IndicatorWidth = 40;
            this.gridViewWNowInfo.Name = "gridViewWNowInfo";
            this.gridViewWNowInfo.OptionsBehavior.Editable = false;
            this.gridViewWNowInfo.OptionsBehavior.ReadOnly = true;
            this.gridViewWNowInfo.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridViewWNowInfo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewWNowInfo.OptionsSelection.MultiSelect = true;
            this.gridViewWNowInfo.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewWNowInfo.OptionsView.ColumnAutoWidth = false;
            this.gridViewWNowInfo.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewWNowInfo.OptionsView.ShowGroupPanel = false;
            this.gridViewWNowInfo.OptionsView.ShowIndicator = false;
            this.gridViewWNowInfo.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewIMHead_CustomDrawRowIndicator);
            this.gridViewWNowInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewIMHead_KeyDown);
            this.gridViewWNowInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridViewWNowInfo_MouseDown);
            this.gridViewWNowInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridViewWNowInfo_MouseMove);
            // 
            // gridColumn13
            // 
            this.gridColumn13.FieldName = "AutoId";
            this.gridColumn13.Name = "gridColumn13";
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.FieldName = "CodeFileName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 110;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.FieldName = "CodeName";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 7;
            this.gridColumn18.Width = 110;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.FieldName = "Qty";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:0.##}")});
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 5;
            this.gridColumn19.Width = 60;
            // 
            // colProjectName
            // 
            this.colProjectName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectName.FieldName = "ProjectName";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.Visible = true;
            this.colProjectName.VisibleIndex = 3;
            this.colProjectName.Width = 100;
            // 
            // colRepertoryId
            // 
            this.colRepertoryId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRepertoryId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRepertoryId.ColumnEdit = this.repLookUpRepertoryId;
            this.colRepertoryId.FieldName = "RepertoryId";
            this.colRepertoryId.Name = "colRepertoryId";
            this.colRepertoryId.Visible = true;
            this.colRepertoryId.VisibleIndex = 1;
            this.colRepertoryId.Width = 80;
            // 
            // repLookUpRepertoryId
            // 
            this.repLookUpRepertoryId.AutoHeight = false;
            this.repLookUpRepertoryId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpRepertoryId.DisplayMember = "RepertoryName";
            this.repLookUpRepertoryId.Name = "repLookUpRepertoryId";
            this.repLookUpRepertoryId.NullText = "";
            this.repLookUpRepertoryId.ValueMember = "AutoId";
            // 
            // colSShelfId
            // 
            this.colSShelfId.AppearanceHeader.Options.UseTextOptions = true;
            this.colSShelfId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSShelfId.ColumnEdit = this.repLookUpShelfId;
            this.colSShelfId.FieldName = "ShelfId";
            this.colSShelfId.Name = "colSShelfId";
            this.colSShelfId.Visible = true;
            this.colSShelfId.VisibleIndex = 6;
            this.colSShelfId.Width = 80;
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
            // colProjectNo1
            // 
            this.colProjectNo1.FieldName = "ProjectNo";
            this.colProjectNo1.Name = "colProjectNo1";
            // 
            // colLocationId
            // 
            this.colLocationId.AppearanceHeader.Options.UseTextOptions = true;
            this.colLocationId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLocationId.ColumnEdit = this.repLookUpLocationId;
            this.colLocationId.FieldName = "LocationId";
            this.colLocationId.Name = "colLocationId";
            this.colLocationId.Visible = true;
            this.colLocationId.VisibleIndex = 2;
            this.colLocationId.Width = 80;
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
            // pnlLeftTop
            // 
            this.pnlLeftTop.Controls.Add(this.checkZero);
            this.pnlLeftTop.Controls.Add(this.lookUpRepertoryId);
            this.pnlLeftTop.Controls.Add(this.searchLookUpCodeFileName);
            this.pnlLeftTop.Controls.Add(this.labCodeFileName);
            this.pnlLeftTop.Controls.Add(this.searchLookUpProjectNo);
            this.pnlLeftTop.Controls.Add(this.btnWNowInfoQuery);
            this.pnlLeftTop.Controls.Add(this.labProjectNo);
            this.pnlLeftTop.Controls.Add(this.labPrReqNo);
            this.pnlLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftTop.Name = "pnlLeftTop";
            this.pnlLeftTop.Size = new System.Drawing.Size(342, 110);
            this.pnlLeftTop.TabIndex = 1;
            // 
            // checkZero
            // 
            this.checkZero.EditValue = true;
            this.checkZero.Location = new System.Drawing.Point(221, 14);
            this.checkZero.Name = "checkZero";
            this.checkZero.Properties.Caption = "库存数不等于0";
            this.checkZero.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkZero.Properties.ValueGrayed = false;
            this.checkZero.Size = new System.Drawing.Size(111, 19);
            this.checkZero.TabIndex = 208;
            // 
            // lookUpRepertoryId
            // 
            this.lookUpRepertoryId.EnterMoveNextControl = true;
            this.lookUpRepertoryId.Location = new System.Drawing.Point(86, 14);
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
            this.lookUpRepertoryId.TabIndex = 201;
            // 
            // searchLookUpCodeFileName
            // 
            this.searchLookUpCodeFileName.EnterMoveNextControl = true;
            this.searchLookUpCodeFileName.Location = new System.Drawing.Point(86, 44);
            this.searchLookUpCodeFileName.Name = "searchLookUpCodeFileName";
            this.searchLookUpCodeFileName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpCodeFileName.Properties.DisplayMember = "CodeName";
            this.searchLookUpCodeFileName.Properties.NullText = "";
            this.searchLookUpCodeFileName.Properties.ValueMember = "CodeFileName";
            this.searchLookUpCodeFileName.Properties.View = this.searchLookUpCodeFileNameView;
            this.searchLookUpCodeFileName.Size = new System.Drawing.Size(150, 20);
            this.searchLookUpCodeFileName.TabIndex = 202;
            // 
            // searchLookUpCodeFileNameView
            // 
            this.searchLookUpCodeFileNameView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3});
            this.searchLookUpCodeFileNameView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpCodeFileNameView.IndicatorWidth = 60;
            this.searchLookUpCodeFileNameView.Name = "searchLookUpCodeFileNameView";
            this.searchLookUpCodeFileNameView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpCodeFileNameView.OptionsView.ShowGroupPanel = false;
            this.searchLookUpCodeFileNameView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.repSearchCodeFileNameView_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "零件编号";
            this.gridColumn1.FieldName = "CodeFileName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "零件名称";
            this.gridColumn3.FieldName = "CodeName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // labCodeFileName
            // 
            this.labCodeFileName.Location = new System.Drawing.Point(20, 47);
            this.labCodeFileName.Name = "labCodeFileName";
            this.labCodeFileName.Size = new System.Drawing.Size(60, 14);
            this.labCodeFileName.TabIndex = 207;
            this.labCodeFileName.Text = "物料名称：";
            // 
            // searchLookUpProjectNo
            // 
            this.searchLookUpProjectNo.EnterMoveNextControl = true;
            this.searchLookUpProjectNo.Location = new System.Drawing.Point(86, 74);
            this.searchLookUpProjectNo.Name = "searchLookUpProjectNo";
            this.searchLookUpProjectNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpProjectNo.Properties.DisplayMember = "ProjectName";
            this.searchLookUpProjectNo.Properties.NullText = "";
            this.searchLookUpProjectNo.Properties.ValueMember = "ProjectNo";
            this.searchLookUpProjectNo.Properties.View = this.searchLookUpProjectNoView;
            this.searchLookUpProjectNo.Size = new System.Drawing.Size(150, 20);
            this.searchLookUpProjectNo.TabIndex = 203;
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
            this.searchLookUpProjectNoView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.repSearchCodeFileNameView_CustomDrawRowIndicator);
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
            // btnWNowInfoQuery
            // 
            this.btnWNowInfoQuery.Location = new System.Drawing.Point(245, 73);
            this.btnWNowInfoQuery.Name = "btnWNowInfoQuery";
            this.btnWNowInfoQuery.Size = new System.Drawing.Size(75, 23);
            this.btnWNowInfoQuery.TabIndex = 204;
            this.btnWNowInfoQuery.Text = "库存查询";
            this.btnWNowInfoQuery.Click += new System.EventHandler(this.btnWNowInfoQuery_Click);
            // 
            // labProjectNo
            // 
            this.labProjectNo.Location = new System.Drawing.Point(20, 77);
            this.labProjectNo.Name = "labProjectNo";
            this.labProjectNo.Size = new System.Drawing.Size(48, 14);
            this.labProjectNo.TabIndex = 114;
            this.labProjectNo.Text = "项目号：";
            // 
            // labPrReqNo
            // 
            this.labPrReqNo.Location = new System.Drawing.Point(20, 17);
            this.labPrReqNo.Name = "labPrReqNo";
            this.labPrReqNo.Size = new System.Drawing.Size(36, 14);
            this.labPrReqNo.TabIndex = 108;
            this.labPrReqNo.Text = "仓库：";
            // 
            // pnlRight
            // 
            this.pnlRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlRight.Controls.Add(this.pnlBottom);
            this.pnlRight.Controls.Add(this.splitterControl1);
            this.pnlRight.Controls.Add(this.pnlMiddle);
            this.pnlRight.Controls.Add(this.pnltop);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(350, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(1020, 601);
            this.pnlRight.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnListAdd);
            this.pnlBottom.Controls.Add(this.gridControlIMList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 269);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1020, 332);
            this.pnlBottom.TabIndex = 7;
            // 
            // btnListAdd
            // 
            this.btnListAdd.Enabled = false;
            this.btnListAdd.Location = new System.Drawing.Point(2, 2);
            this.btnListAdd.Name = "btnListAdd";
            this.btnListAdd.Size = new System.Drawing.Size(40, 21);
            this.btnListAdd.TabIndex = 5;
            this.btnListAdd.Text = "+";
            this.btnListAdd.Click += new System.EventHandler(this.btnListAdd_Click);
            // 
            // gridControlIMList
            // 
            this.gridControlIMList.AllowDrop = true;
            this.gridControlIMList.DataSource = this.bindingSource_IMList;
            this.gridControlIMList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlIMList.Location = new System.Drawing.Point(2, 2);
            this.gridControlIMList.MainView = this.gridViewIMList;
            this.gridControlIMList.Name = "gridControlIMList";
            this.gridControlIMList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSpinQty,
            this.repSearchCodeFileName,
            this.repbtnDelete,
            this.repSearchOutProjectNo,
            this.repSearchOutShelfId});
            this.gridControlIMList.Size = new System.Drawing.Size(1016, 328);
            this.gridControlIMList.TabIndex = 2;
            this.gridControlIMList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewIMList});
            this.gridControlIMList.DragDrop += new System.Windows.Forms.DragEventHandler(this.gridControlIMList_DragDrop);
            this.gridControlIMList.DragEnter += new System.Windows.Forms.DragEventHandler(this.gridControlIMList_DragEnter);
            this.gridControlIMList.DragOver += new System.Windows.Forms.DragEventHandler(this.gridControlIMList_DragOver);
            // 
            // gridViewIMList
            // 
            this.gridViewIMList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId1,
            this.columnInventoryMoveNo,
            this.colCodeFileName,
            this.colCodeName,
            this.colQty,
            this.colRemark,
            this.colDelete,
            this.colOutProjectNo,
            this.colOutShelfId,
            this.colInProjectNo,
            this.colInShelfId,
            this.colInventoryMoveDate,
            this.columnOutRepertoryId,
            this.columnInRepertoryId,
            this.colOutProjectName,
            this.colInProjectName,
            this.colOutLocationId1,
            this.colInLocationId1});
            this.gridViewIMList.GridControl = this.gridControlIMList;
            this.gridViewIMList.IndicatorWidth = 40;
            this.gridViewIMList.Name = "gridViewIMList";
            this.gridViewIMList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewIMList.OptionsMenu.EnableColumnMenu = false;
            this.gridViewIMList.OptionsMenu.EnableFooterMenu = false;
            this.gridViewIMList.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewIMList.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewIMList.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewIMList.OptionsView.ColumnAutoWidth = false;
            this.gridViewIMList.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewIMList.OptionsView.ShowFooter = true;
            this.gridViewIMList.OptionsView.ShowGroupPanel = false;
            this.gridViewIMList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewIMHead_CustomDrawRowIndicator);
            this.gridViewIMList.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewIMList_InitNewRow);
            this.gridViewIMList.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewIMList_CellValueChanged);
            this.gridViewIMList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewIMList_KeyDown);
            // 
            // colAutoId1
            // 
            this.colAutoId1.FieldName = "AutoId";
            this.colAutoId1.Name = "colAutoId1";
            // 
            // columnInventoryMoveNo
            // 
            this.columnInventoryMoveNo.AppearanceHeader.Options.UseTextOptions = true;
            this.columnInventoryMoveNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnInventoryMoveNo.FieldName = "InventoryMoveNo";
            this.columnInventoryMoveNo.Name = "columnInventoryMoveNo";
            this.columnInventoryMoveNo.OptionsColumn.AllowEdit = false;
            this.columnInventoryMoveNo.OptionsColumn.TabStop = false;
            this.columnInventoryMoveNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PrReqNo", "共计{0}条")});
            this.columnInventoryMoveNo.Visible = true;
            this.columnInventoryMoveNo.VisibleIndex = 0;
            this.columnInventoryMoveNo.Width = 110;
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
            this.repSearchCodeFileName.DisplayMember = "CodeFileName";
            this.repSearchCodeFileName.Name = "repSearchCodeFileName";
            this.repSearchCodeFileName.NullText = "";
            this.repSearchCodeFileName.ValueMember = "CodeFileName";
            this.repSearchCodeFileName.View = this.repSearchCodeFileNameView;
            // 
            // repSearchCodeFileNameView
            // 
            this.repSearchCodeFileNameView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumnCodeFileName,
            this.gridColumnCodeName});
            this.repSearchCodeFileNameView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchCodeFileNameView.IndicatorWidth = 60;
            this.repSearchCodeFileNameView.Name = "repSearchCodeFileNameView";
            this.repSearchCodeFileNameView.OptionsBehavior.Editable = false;
            this.repSearchCodeFileNameView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchCodeFileNameView.OptionsView.ShowGroupPanel = false;
            this.repSearchCodeFileNameView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.repSearchCodeFileNameView_CustomDrawRowIndicator);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "AutoId";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumnCodeFileName
            // 
            this.gridColumnCodeFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnCodeFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnCodeFileName.Caption = "零件编号";
            this.gridColumnCodeFileName.FieldName = "CodeFileName";
            this.gridColumnCodeFileName.Name = "gridColumnCodeFileName";
            this.gridColumnCodeFileName.Visible = true;
            this.gridColumnCodeFileName.VisibleIndex = 0;
            this.gridColumnCodeFileName.Width = 130;
            // 
            // gridColumnCodeName
            // 
            this.gridColumnCodeName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnCodeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnCodeName.Caption = "零件名称";
            this.gridColumnCodeName.FieldName = "CodeName";
            this.gridColumnCodeName.Name = "gridColumnCodeName";
            this.gridColumnCodeName.Visible = true;
            this.gridColumnCodeName.VisibleIndex = 1;
            this.gridColumnCodeName.Width = 130;
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
            this.colQty.VisibleIndex = 3;
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
            // colRemark
            // 
            this.colRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 8;
            this.colRemark.Width = 140;
            // 
            // colDelete
            // 
            this.colDelete.ColumnEdit = this.repbtnDelete;
            this.colDelete.Name = "colDelete";
            this.colDelete.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 9;
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
            // colOutProjectNo
            // 
            this.colOutProjectNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colOutProjectNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOutProjectNo.ColumnEdit = this.repSearchOutProjectNo;
            this.colOutProjectNo.FieldName = "OutProjectNo";
            this.colOutProjectNo.Name = "colOutProjectNo";
            this.colOutProjectNo.OptionsColumn.AllowEdit = false;
            this.colOutProjectNo.Visible = true;
            this.colOutProjectNo.VisibleIndex = 4;
            this.colOutProjectNo.Width = 100;
            // 
            // repSearchOutProjectNo
            // 
            this.repSearchOutProjectNo.AutoHeight = false;
            this.repSearchOutProjectNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearchOutProjectNo.DisplayMember = "ProjectName";
            this.repSearchOutProjectNo.Name = "repSearchOutProjectNo";
            this.repSearchOutProjectNo.NullText = "";
            this.repSearchOutProjectNo.ValueMember = "ProjectNo";
            this.repSearchOutProjectNo.View = this.repSearchOutProjectNoView;
            // 
            // repSearchOutProjectNoView
            // 
            this.repSearchOutProjectNoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.repSearchOutProjectNoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchOutProjectNoView.IndicatorWidth = 60;
            this.repSearchOutProjectNoView.Name = "repSearchOutProjectNoView";
            this.repSearchOutProjectNoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchOutProjectNoView.OptionsView.ShowGroupPanel = false;
            this.repSearchOutProjectNoView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.repSearchCodeFileNameView_CustomDrawRowIndicator);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "项目号";
            this.gridColumn4.FieldName = "ProjectNo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "项目名称";
            this.gridColumn5.FieldName = "ProjectName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "备注";
            this.gridColumn6.FieldName = "Remark";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // colOutShelfId
            // 
            this.colOutShelfId.AppearanceHeader.Options.UseTextOptions = true;
            this.colOutShelfId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOutShelfId.ColumnEdit = this.repSearchOutShelfId;
            this.colOutShelfId.FieldName = "OutShelfId";
            this.colOutShelfId.Name = "colOutShelfId";
            this.colOutShelfId.OptionsColumn.AllowEdit = false;
            this.colOutShelfId.Visible = true;
            this.colOutShelfId.VisibleIndex = 5;
            this.colOutShelfId.Width = 100;
            // 
            // repSearchOutShelfId
            // 
            this.repSearchOutShelfId.AutoHeight = false;
            this.repSearchOutShelfId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearchOutShelfId.DisplayMember = "ShelfNo";
            this.repSearchOutShelfId.Name = "repSearchOutShelfId";
            this.repSearchOutShelfId.NullText = "";
            this.repSearchOutShelfId.ValueMember = "AutoId";
            this.repSearchOutShelfId.View = this.repSearchOutShelfNoView;
            this.repSearchOutShelfId.Popup += new System.EventHandler(this.repSearchOutShelfId_Popup);
            // 
            // repSearchOutShelfNoView
            // 
            this.repSearchOutShelfNoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn17,
            this.gridColumn20});
            this.repSearchOutShelfNoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchOutShelfNoView.IndicatorWidth = 60;
            this.repSearchOutShelfNoView.Name = "repSearchOutShelfNoView";
            this.repSearchOutShelfNoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchOutShelfNoView.OptionsView.ShowGroupPanel = false;
            this.repSearchOutShelfNoView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.repSearchCodeFileNameView_CustomDrawRowIndicator);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "货架号";
            this.gridColumn7.FieldName = "ShelfNo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "货架位置";
            this.gridColumn8.FieldName = "ShelfLocation";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "AutoId";
            this.gridColumn9.FieldName = "AutoId";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "仓位名称";
            this.gridColumn17.FieldName = "LocationName";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 2;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "RepertoryLocationId";
            this.gridColumn20.FieldName = "RepertoryLocationId";
            this.gridColumn20.Name = "gridColumn20";
            // 
            // colInProjectNo
            // 
            this.colInProjectNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colInProjectNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInProjectNo.ColumnEdit = this.repSearchOutProjectNo;
            this.colInProjectNo.FieldName = "InProjectNo";
            this.colInProjectNo.Name = "colInProjectNo";
            this.colInProjectNo.OptionsColumn.AllowEdit = false;
            this.colInProjectNo.Visible = true;
            this.colInProjectNo.VisibleIndex = 6;
            this.colInProjectNo.Width = 100;
            // 
            // colInShelfId
            // 
            this.colInShelfId.AppearanceHeader.Options.UseTextOptions = true;
            this.colInShelfId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInShelfId.ColumnEdit = this.repSearchOutShelfId;
            this.colInShelfId.FieldName = "InShelfId";
            this.colInShelfId.Name = "colInShelfId";
            this.colInShelfId.OptionsColumn.AllowEdit = false;
            this.colInShelfId.Visible = true;
            this.colInShelfId.VisibleIndex = 7;
            this.colInShelfId.Width = 100;
            // 
            // colInventoryMoveDate
            // 
            this.colInventoryMoveDate.FieldName = "InventoryMoveDate";
            this.colInventoryMoveDate.Name = "colInventoryMoveDate";
            // 
            // columnOutRepertoryId
            // 
            this.columnOutRepertoryId.FieldName = "OutRepertoryId";
            this.columnOutRepertoryId.Name = "columnOutRepertoryId";
            // 
            // columnInRepertoryId
            // 
            this.columnInRepertoryId.FieldName = "InRepertoryId";
            this.columnInRepertoryId.Name = "columnInRepertoryId";
            // 
            // colOutProjectName
            // 
            this.colOutProjectName.FieldName = "OutProjectName";
            this.colOutProjectName.Name = "colOutProjectName";
            // 
            // colInProjectName
            // 
            this.colInProjectName.FieldName = "InProjectName";
            this.colInProjectName.Name = "colInProjectName";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 264);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(1020, 5);
            this.splitterControl1.TabIndex = 6;
            this.splitterControl1.TabStop = false;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.checkAll);
            this.pnlMiddle.Controls.Add(this.gridControlIMHead);
            this.pnlMiddle.Controls.Add(this.pnlMiddleTop);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 78);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1020, 186);
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
            this.checkAll.TabIndex = 18;
            this.checkAll.TabStop = false;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // gridControlIMHead
            // 
            this.gridControlIMHead.AllowDrop = true;
            this.gridControlIMHead.DataSource = this.bindingSource_IMHead;
            this.gridControlIMHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlIMHead.Location = new System.Drawing.Point(2, 36);
            this.gridControlIMHead.MainView = this.gridViewIMHead;
            this.gridControlIMHead.Name = "gridControlIMHead";
            this.gridControlIMHead.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpReqDep,
            this.repCheckSelect,
            this.repLookUpInRepertoryId,
            this.repLookUpCreator,
            this.repSearchInLocationId});
            this.gridControlIMHead.Size = new System.Drawing.Size(1016, 148);
            this.gridControlIMHead.TabIndex = 3;
            this.gridControlIMHead.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewIMHead});
            this.gridControlIMHead.DragDrop += new System.Windows.Forms.DragEventHandler(this.gridControlIMList_DragDrop);
            this.gridControlIMHead.DragEnter += new System.Windows.Forms.DragEventHandler(this.gridControlIMList_DragEnter);
            this.gridControlIMHead.DragOver += new System.Windows.Forms.DragEventHandler(this.gridControlIMList_DragOver);
            // 
            // gridViewIMHead
            // 
            this.gridViewIMHead.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colSelect,
            this.colInventoryMoveNo,
            this.colOrderHeadDate,
            this.colInRepertoryId,
            this.colOutRepertoryId,
            this.colReqDep,
            this.colPRemark,
            this.colCreator,
            this.colModifier,
            this.colInLocationId,
            this.colOutLocationId});
            this.gridViewIMHead.GridControl = this.gridControlIMHead;
            this.gridViewIMHead.IndicatorWidth = 40;
            this.gridViewIMHead.Name = "gridViewIMHead";
            this.gridViewIMHead.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewIMHead.OptionsMenu.EnableColumnMenu = false;
            this.gridViewIMHead.OptionsMenu.EnableFooterMenu = false;
            this.gridViewIMHead.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewIMHead.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewIMHead.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewIMHead.OptionsView.ColumnAutoWidth = false;
            this.gridViewIMHead.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewIMHead.OptionsView.ShowFooter = true;
            this.gridViewIMHead.OptionsView.ShowGroupPanel = false;
            this.gridViewIMHead.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewIMHead_CustomDrawRowIndicator);
            this.gridViewIMHead.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewIMHead_InitNewRow);
            this.gridViewIMHead.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewIMHead_FocusedRowChanged);
            this.gridViewIMHead.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewIMHead_CellValueChanged);
            this.gridViewIMHead.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewIMHead_KeyDown);
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
            this.repCheckSelect.CheckedChanged += new System.EventHandler(this.repCheckSelect_EditValueChanged);
            // 
            // colInventoryMoveNo
            // 
            this.colInventoryMoveNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colInventoryMoveNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInventoryMoveNo.FieldName = "InventoryMoveNo";
            this.colInventoryMoveNo.Name = "colInventoryMoveNo";
            this.colInventoryMoveNo.OptionsColumn.AllowEdit = false;
            this.colInventoryMoveNo.OptionsColumn.TabStop = false;
            this.colInventoryMoveNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "InventoryMoveNo", "共计{0}条")});
            this.colInventoryMoveNo.Visible = true;
            this.colInventoryMoveNo.VisibleIndex = 1;
            this.colInventoryMoveNo.Width = 110;
            // 
            // colOrderHeadDate
            // 
            this.colOrderHeadDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderHeadDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOrderHeadDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colOrderHeadDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colOrderHeadDate.FieldName = "InventoryMoveDate";
            this.colOrderHeadDate.Name = "colOrderHeadDate";
            this.colOrderHeadDate.OptionsColumn.AllowEdit = false;
            this.colOrderHeadDate.OptionsColumn.TabStop = false;
            this.colOrderHeadDate.Visible = true;
            this.colOrderHeadDate.VisibleIndex = 2;
            this.colOrderHeadDate.Width = 90;
            // 
            // colInRepertoryId
            // 
            this.colInRepertoryId.AppearanceHeader.Options.UseTextOptions = true;
            this.colInRepertoryId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInRepertoryId.ColumnEdit = this.repLookUpInRepertoryId;
            this.colInRepertoryId.FieldName = "InRepertoryId";
            this.colInRepertoryId.Name = "colInRepertoryId";
            this.colInRepertoryId.OptionsColumn.AllowEdit = false;
            this.colInRepertoryId.Visible = true;
            this.colInRepertoryId.VisibleIndex = 5;
            this.colInRepertoryId.Width = 100;
            // 
            // repLookUpInRepertoryId
            // 
            this.repLookUpInRepertoryId.AutoHeight = false;
            this.repLookUpInRepertoryId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpInRepertoryId.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryNo", "仓库编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryName", "仓库名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryTypeText", "仓库类型")});
            this.repLookUpInRepertoryId.DisplayMember = "RepertoryName";
            this.repLookUpInRepertoryId.Name = "repLookUpInRepertoryId";
            this.repLookUpInRepertoryId.NullText = "";
            this.repLookUpInRepertoryId.ValueMember = "AutoId";
            // 
            // colOutRepertoryId
            // 
            this.colOutRepertoryId.AppearanceHeader.Options.UseTextOptions = true;
            this.colOutRepertoryId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOutRepertoryId.ColumnEdit = this.repLookUpInRepertoryId;
            this.colOutRepertoryId.FieldName = "OutRepertoryId";
            this.colOutRepertoryId.Name = "colOutRepertoryId";
            this.colOutRepertoryId.OptionsColumn.AllowEdit = false;
            this.colOutRepertoryId.Visible = true;
            this.colOutRepertoryId.VisibleIndex = 3;
            this.colOutRepertoryId.Width = 100;
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
            this.colReqDep.Width = 80;
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
            // colPRemark
            // 
            this.colPRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colPRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPRemark.FieldName = "Remark";
            this.colPRemark.Name = "colPRemark";
            this.colPRemark.OptionsColumn.AllowEdit = false;
            this.colPRemark.Visible = true;
            this.colPRemark.VisibleIndex = 7;
            this.colPRemark.Width = 140;
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
            this.colCreator.Width = 80;
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
            this.colModifier.VisibleIndex = 10;
            this.colModifier.Width = 80;
            // 
            // colInLocationId
            // 
            this.colInLocationId.AppearanceHeader.Options.UseTextOptions = true;
            this.colInLocationId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInLocationId.ColumnEdit = this.repSearchInLocationId;
            this.colInLocationId.FieldName = "InLocationId";
            this.colInLocationId.Name = "colInLocationId";
            this.colInLocationId.OptionsColumn.AllowEdit = false;
            this.colInLocationId.Visible = true;
            this.colInLocationId.VisibleIndex = 6;
            this.colInLocationId.Width = 100;
            // 
            // repSearchInLocationId
            // 
            this.repSearchInLocationId.AutoHeight = false;
            this.repSearchInLocationId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSearchInLocationId.DisplayMember = "LocationName";
            this.repSearchInLocationId.Name = "repSearchInLocationId";
            this.repSearchInLocationId.NullText = "";
            this.repSearchInLocationId.ValueMember = "AutoId";
            this.repSearchInLocationId.View = this.repSearchInLocationIdView;
            this.repSearchInLocationId.Popup += new System.EventHandler(this.repSearchInLocationId_Popup);
            // 
            // repSearchInLocationIdView
            // 
            this.repSearchInLocationIdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25});
            this.repSearchInLocationIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repSearchInLocationIdView.IndicatorWidth = 60;
            this.repSearchInLocationIdView.Name = "repSearchInLocationIdView";
            this.repSearchInLocationIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repSearchInLocationIdView.OptionsView.ShowGroupPanel = false;
            this.repSearchInLocationIdView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.repSearchCodeFileNameView_CustomDrawRowIndicator);
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "AutoId";
            this.gridColumn21.FieldName = "AutoId";
            this.gridColumn21.Name = "gridColumn21";
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "仓位编号";
            this.gridColumn22.FieldName = "LocationNo";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 0;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "仓位名称";
            this.gridColumn23.FieldName = "LocationName";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 1;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "仓库名称";
            this.gridColumn24.FieldName = "RepertoryName";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 2;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "RepertoryId";
            this.gridColumn25.FieldName = "RepertoryId";
            this.gridColumn25.Name = "gridColumn25";
            // 
            // colOutLocationId
            // 
            this.colOutLocationId.AppearanceHeader.Options.UseTextOptions = true;
            this.colOutLocationId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOutLocationId.ColumnEdit = this.repSearchInLocationId;
            this.colOutLocationId.FieldName = "OutLocationId";
            this.colOutLocationId.Name = "colOutLocationId";
            this.colOutLocationId.OptionsColumn.AllowEdit = false;
            this.colOutLocationId.Visible = true;
            this.colOutLocationId.VisibleIndex = 4;
            this.colOutLocationId.Width = 100;
            // 
            // pnlMiddleTop
            // 
            this.pnlMiddleTop.Controls.Add(this.btnPreview);
            this.pnlMiddleTop.Controls.Add(this.btnDelete);
            this.pnlMiddleTop.Controls.Add(this.btnCancel);
            this.pnlMiddleTop.Controls.Add(this.btnSave);
            this.pnlMiddleTop.Controls.Add(this.btnNew);
            this.pnlMiddleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddleTop.Location = new System.Drawing.Point(2, 2);
            this.pnlMiddleTop.Name = "pnlMiddleTop";
            this.pnlMiddleTop.Size = new System.Drawing.Size(1016, 34);
            this.pnlMiddleTop.TabIndex = 2;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(329, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 24;
            this.btnPreview.TabStop = false;
            this.btnPreview.Text = "预览";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
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
            // pnltop
            // 
            this.pnltop.Controls.Add(this.labInLocationId);
            this.pnltop.Controls.Add(this.SearchInLocationId);
            this.pnltop.Controls.Add(this.labOutLocationId);
            this.pnltop.Controls.Add(this.SearchOutLocationId);
            this.pnltop.Controls.Add(this.lookUpOutRepertoryId);
            this.pnltop.Controls.Add(this.lookUpReqDep);
            this.pnltop.Controls.Add(this.lookUpInRepertoryId);
            this.pnltop.Controls.Add(this.btnQuery);
            this.pnltop.Controls.Add(this.textCommon);
            this.pnltop.Controls.Add(this.lookUpCreator);
            this.pnltop.Controls.Add(this.dateIMDateEnd);
            this.pnltop.Controls.Add(this.lab1);
            this.pnltop.Controls.Add(this.dateIMDateBegin);
            this.pnltop.Controls.Add(this.labReqDep);
            this.pnltop.Controls.Add(this.labOutRepertoryId);
            this.pnltop.Controls.Add(this.labInRepertoryId);
            this.pnltop.Controls.Add(this.labCommon);
            this.pnltop.Controls.Add(this.labCreator);
            this.pnltop.Controls.Add(this.labIMDate);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Margin = new System.Windows.Forms.Padding(4);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1020, 78);
            this.pnltop.TabIndex = 1;
            // 
            // labInLocationId
            // 
            this.labInLocationId.Location = new System.Drawing.Point(223, 47);
            this.labInLocationId.Name = "labInLocationId";
            this.labInLocationId.Size = new System.Drawing.Size(60, 14);
            this.labInLocationId.TabIndex = 51;
            this.labInLocationId.Text = "入库仓位：";
            // 
            // SearchInLocationId
            // 
            this.SearchInLocationId.EnterMoveNextControl = true;
            this.SearchInLocationId.Location = new System.Drawing.Point(289, 44);
            this.SearchInLocationId.Name = "SearchInLocationId";
            this.SearchInLocationId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchInLocationId.Properties.DisplayMember = "LocationName";
            this.SearchInLocationId.Properties.NullText = "";
            this.SearchInLocationId.Properties.ValueMember = "AutoId";
            this.SearchInLocationId.Properties.View = this.SearchInLocationIdView;
            this.SearchInLocationId.Size = new System.Drawing.Size(120, 20);
            this.SearchInLocationId.TabIndex = 6;
            // 
            // SearchInLocationIdView
            // 
            this.SearchInLocationIdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn16,
            this.gridColuLocationNo,
            this.gridColuLocationName,
            this.gridColuRepertoryName});
            this.SearchInLocationIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.SearchInLocationIdView.IndicatorWidth = 60;
            this.SearchInLocationIdView.Name = "SearchInLocationIdView";
            this.SearchInLocationIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.SearchInLocationIdView.OptionsView.ShowGroupPanel = false;
            this.SearchInLocationIdView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.repSearchCodeFileNameView_CustomDrawRowIndicator);
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "AutoId";
            this.gridColumn16.FieldName = "AutoId";
            this.gridColumn16.Name = "gridColumn16";
            // 
            // gridColuLocationNo
            // 
            this.gridColuLocationNo.Caption = "仓位编号";
            this.gridColuLocationNo.FieldName = "LocationNo";
            this.gridColuLocationNo.Name = "gridColuLocationNo";
            this.gridColuLocationNo.Visible = true;
            this.gridColuLocationNo.VisibleIndex = 0;
            // 
            // gridColuLocationName
            // 
            this.gridColuLocationName.Caption = "仓位名称";
            this.gridColuLocationName.FieldName = "LocationName";
            this.gridColuLocationName.Name = "gridColuLocationName";
            this.gridColuLocationName.Visible = true;
            this.gridColuLocationName.VisibleIndex = 1;
            // 
            // gridColuRepertoryName
            // 
            this.gridColuRepertoryName.Caption = "仓库名称";
            this.gridColuRepertoryName.FieldName = "RepertoryName";
            this.gridColuRepertoryName.Name = "gridColuRepertoryName";
            this.gridColuRepertoryName.Visible = true;
            this.gridColuRepertoryName.VisibleIndex = 2;
            // 
            // labOutLocationId
            // 
            this.labOutLocationId.Location = new System.Drawing.Point(523, 17);
            this.labOutLocationId.Name = "labOutLocationId";
            this.labOutLocationId.Size = new System.Drawing.Size(60, 14);
            this.labOutLocationId.TabIndex = 49;
            this.labOutLocationId.Text = "出库仓位：";
            // 
            // SearchOutLocationId
            // 
            this.SearchOutLocationId.EnterMoveNextControl = true;
            this.SearchOutLocationId.Location = new System.Drawing.Point(589, 14);
            this.SearchOutLocationId.Name = "SearchOutLocationId";
            this.SearchOutLocationId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchOutLocationId.Properties.DisplayMember = "LocationName";
            this.SearchOutLocationId.Properties.NullText = "";
            this.SearchOutLocationId.Properties.ValueMember = "AutoId";
            this.SearchOutLocationId.Properties.View = this.SearchOutLocationIdView;
            this.SearchOutLocationId.Size = new System.Drawing.Size(120, 20);
            this.SearchOutLocationId.TabIndex = 3;
            // 
            // SearchOutLocationIdView
            // 
            this.SearchOutLocationIdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn15});
            this.SearchOutLocationIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.SearchOutLocationIdView.IndicatorWidth = 60;
            this.SearchOutLocationIdView.Name = "SearchOutLocationIdView";
            this.SearchOutLocationIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.SearchOutLocationIdView.OptionsView.ShowGroupPanel = false;
            this.SearchOutLocationIdView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.repSearchCodeFileNameView_CustomDrawRowIndicator);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "AutoId";
            this.gridColumn10.FieldName = "AutoId";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "仓位编号";
            this.gridColumn11.FieldName = "LocationNo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "仓位名称";
            this.gridColumn12.FieldName = "LocationName";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "仓库名称";
            this.gridColumn15.FieldName = "RepertoryName";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            // 
            // lookUpOutRepertoryId
            // 
            this.lookUpOutRepertoryId.EnterMoveNextControl = true;
            this.lookUpOutRepertoryId.Location = new System.Drawing.Point(386, 14);
            this.lookUpOutRepertoryId.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpOutRepertoryId.Name = "lookUpOutRepertoryId";
            this.lookUpOutRepertoryId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpOutRepertoryId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryNo", "仓库编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryName", "仓库名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryTypeText", "仓库类型")});
            this.lookUpOutRepertoryId.Properties.DisplayMember = "RepertoryName";
            this.lookUpOutRepertoryId.Properties.NullText = "";
            this.lookUpOutRepertoryId.Properties.ValueMember = "AutoId";
            this.lookUpOutRepertoryId.Size = new System.Drawing.Size(120, 20);
            this.lookUpOutRepertoryId.TabIndex = 2;
            // 
            // lookUpReqDep
            // 
            this.lookUpReqDep.EnterMoveNextControl = true;
            this.lookUpReqDep.Location = new System.Drawing.Point(771, 14);
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
            // lookUpInRepertoryId
            // 
            this.lookUpInRepertoryId.EnterMoveNextControl = true;
            this.lookUpInRepertoryId.Location = new System.Drawing.Point(86, 44);
            this.lookUpInRepertoryId.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpInRepertoryId.Name = "lookUpInRepertoryId";
            this.lookUpInRepertoryId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpInRepertoryId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryNo", "仓库编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryName", "仓库名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RepertoryTypeText", "仓库类型")});
            this.lookUpInRepertoryId.Properties.DisplayMember = "RepertoryName";
            this.lookUpInRepertoryId.Properties.NullText = "";
            this.lookUpInRepertoryId.Properties.ValueMember = "AutoId";
            this.lookUpInRepertoryId.Size = new System.Drawing.Size(120, 20);
            this.lookUpInRepertoryId.TabIndex = 5;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(861, 43);
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
            this.textCommon.Location = new System.Drawing.Point(687, 44);
            this.textCommon.Margin = new System.Windows.Forms.Padding(4);
            this.textCommon.Name = "textCommon";
            this.textCommon.Size = new System.Drawing.Size(150, 20);
            this.textCommon.TabIndex = 8;
            // 
            // lookUpCreator
            // 
            this.lookUpCreator.EnterMoveNextControl = true;
            this.lookUpCreator.Location = new System.Drawing.Point(482, 44);
            this.lookUpCreator.Margin = new System.Windows.Forms.Padding(4);
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
            this.lookUpCreator.TabIndex = 7;
            // 
            // dateIMDateEnd
            // 
            this.dateIMDateEnd.EditValue = null;
            this.dateIMDateEnd.EnterMoveNextControl = true;
            this.dateIMDateEnd.Location = new System.Drawing.Point(202, 14);
            this.dateIMDateEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dateIMDateEnd.Name = "dateIMDateEnd";
            this.dateIMDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIMDateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIMDateEnd.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateIMDateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateIMDateEnd.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateIMDateEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateIMDateEnd.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateIMDateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateIMDateEnd.TabIndex = 1;
            // 
            // lab1
            // 
            this.lab1.Location = new System.Drawing.Point(192, 17);
            this.lab1.Margin = new System.Windows.Forms.Padding(4);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(4, 14);
            this.lab1.TabIndex = 6;
            this.lab1.Text = "-";
            // 
            // dateIMDateBegin
            // 
            this.dateIMDateBegin.EditValue = null;
            this.dateIMDateBegin.EnterMoveNextControl = true;
            this.dateIMDateBegin.Location = new System.Drawing.Point(86, 14);
            this.dateIMDateBegin.Margin = new System.Windows.Forms.Padding(4);
            this.dateIMDateBegin.Name = "dateIMDateBegin";
            this.dateIMDateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIMDateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIMDateBegin.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateIMDateBegin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateIMDateBegin.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateIMDateBegin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateIMDateBegin.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateIMDateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateIMDateBegin.TabIndex = 0;
            // 
            // labReqDep
            // 
            this.labReqDep.Location = new System.Drawing.Point(727, 17);
            this.labReqDep.Margin = new System.Windows.Forms.Padding(4);
            this.labReqDep.Name = "labReqDep";
            this.labReqDep.Size = new System.Drawing.Size(36, 14);
            this.labReqDep.TabIndex = 32;
            this.labReqDep.Text = "部门：";
            // 
            // labOutRepertoryId
            // 
            this.labOutRepertoryId.Location = new System.Drawing.Point(318, 17);
            this.labOutRepertoryId.Margin = new System.Windows.Forms.Padding(4);
            this.labOutRepertoryId.Name = "labOutRepertoryId";
            this.labOutRepertoryId.Size = new System.Drawing.Size(60, 14);
            this.labOutRepertoryId.TabIndex = 28;
            this.labOutRepertoryId.Text = "出库仓库：";
            // 
            // labInRepertoryId
            // 
            this.labInRepertoryId.Location = new System.Drawing.Point(20, 47);
            this.labInRepertoryId.Margin = new System.Windows.Forms.Padding(4);
            this.labInRepertoryId.Name = "labInRepertoryId";
            this.labInRepertoryId.Size = new System.Drawing.Size(60, 14);
            this.labInRepertoryId.TabIndex = 26;
            this.labInRepertoryId.Text = "入库仓库：";
            // 
            // labCommon
            // 
            this.labCommon.Location = new System.Drawing.Point(619, 47);
            this.labCommon.Margin = new System.Windows.Forms.Padding(4);
            this.labCommon.Name = "labCommon";
            this.labCommon.Size = new System.Drawing.Size(60, 14);
            this.labCommon.TabIndex = 22;
            this.labCommon.Text = "通用查询：";
            // 
            // labCreator
            // 
            this.labCreator.Location = new System.Drawing.Point(426, 47);
            this.labCreator.Margin = new System.Windows.Forms.Padding(4);
            this.labCreator.Name = "labCreator";
            this.labCreator.Size = new System.Drawing.Size(48, 14);
            this.labCreator.TabIndex = 20;
            this.labCreator.Text = "制单人：";
            // 
            // labIMDate
            // 
            this.labIMDate.Location = new System.Drawing.Point(20, 17);
            this.labIMDate.Margin = new System.Windows.Forms.Padding(4);
            this.labIMDate.Name = "labIMDate";
            this.labIMDate.Size = new System.Drawing.Size(60, 14);
            this.labIMDate.TabIndex = 5;
            this.labIMDate.Text = "移动日期：";
            // 
            // cms1
            // 
            this.cms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRkrqbnwkcx,
            this.tsmiDqrkdyjxghh,
            this.tsmiRkbmbnwkbc,
            this.tsmiRkckbnwkbc,
            this.tsmiRklbbnwkbc,
            this.tsmiSplxbnwkbc,
            this.tsmiRkmxbnwkbc,
            this.tsmiSlbnwkbc,
            this.tsmiHjbhbnwkbc,
            this.tsmiQgsyansjcw,
            this.tsmiRkdmxbnwkbc,
            this.tsmiCxmxdsyjcgdcw,
            this.tsmiCxmxdxyjcgjzdcw,
            this.tsmiDgrqbnwkcx,
            this.tsmiCxcgddsjcw,
            this.tsmiJjcxcgddmxsjcw,
            this.tsmiSxtzcgddsjcw,
            this.tsmiYzrkdzrxxtdxmhjxdj,
            this.tsmiYzrkdzrxxtdgysjxdj});
            this.cms1.Name = "cms";
            this.cms1.Size = new System.Drawing.Size(365, 422);
            // 
            // tsmiRkrqbnwkcx
            // 
            this.tsmiRkrqbnwkcx.Name = "tsmiRkrqbnwkcx";
            this.tsmiRkrqbnwkcx.Size = new System.Drawing.Size(364, 22);
            this.tsmiRkrqbnwkcx.Text = "入库日期不能为空，请设置后重新进行查询。";
            // 
            // tsmiDqrkdyjxghh
            // 
            this.tsmiDqrkdyjxghh.Name = "tsmiDqrkdyjxghh";
            this.tsmiDqrkdyjxghh.Size = new System.Drawing.Size(364, 22);
            this.tsmiDqrkdyjxghh.Text = "当前入库单已经修改，请保存后再进行换行。";
            // 
            // tsmiRkbmbnwkbc
            // 
            this.tsmiRkbmbnwkbc.Name = "tsmiRkbmbnwkbc";
            this.tsmiRkbmbnwkbc.Size = new System.Drawing.Size(364, 22);
            this.tsmiRkbmbnwkbc.Text = "入库部门不能为空，请填写后再进行保存。";
            // 
            // tsmiRkckbnwkbc
            // 
            this.tsmiRkckbnwkbc.Name = "tsmiRkckbnwkbc";
            this.tsmiRkckbnwkbc.Size = new System.Drawing.Size(364, 22);
            this.tsmiRkckbnwkbc.Text = "入库仓库不能为空，请填写后再进行保存。";
            // 
            // tsmiRklbbnwkbc
            // 
            this.tsmiRklbbnwkbc.Name = "tsmiRklbbnwkbc";
            this.tsmiRklbbnwkbc.Size = new System.Drawing.Size(364, 22);
            this.tsmiRklbbnwkbc.Text = "入库类别不能为空，请填写后再进行保存。";
            // 
            // tsmiSplxbnwkbc
            // 
            this.tsmiSplxbnwkbc.Name = "tsmiSplxbnwkbc";
            this.tsmiSplxbnwkbc.Size = new System.Drawing.Size(364, 22);
            this.tsmiSplxbnwkbc.Text = "审批类型不能为空，请填写后再进行保存。";
            // 
            // tsmiRkmxbnwkbc
            // 
            this.tsmiRkmxbnwkbc.Name = "tsmiRkmxbnwkbc";
            this.tsmiRkmxbnwkbc.Size = new System.Drawing.Size(364, 22);
            this.tsmiRkmxbnwkbc.Text = "入库单明细不能为空，请重新订单适用后再进行保存。";
            // 
            // tsmiSlbnwkbc
            // 
            this.tsmiSlbnwkbc.Name = "tsmiSlbnwkbc";
            this.tsmiSlbnwkbc.Size = new System.Drawing.Size(364, 22);
            this.tsmiSlbnwkbc.Text = "数量不能为空，请填写后再进行保存。";
            // 
            // tsmiHjbhbnwkbc
            // 
            this.tsmiHjbhbnwkbc.Name = "tsmiHjbhbnwkbc";
            this.tsmiHjbhbnwkbc.Size = new System.Drawing.Size(364, 22);
            this.tsmiHjbhbnwkbc.Text = "货架编号不能为空，请填写后再进行保存。";
            // 
            // tsmiQgsyansjcw
            // 
            this.tsmiQgsyansjcw.Name = "tsmiQgsyansjcw";
            this.tsmiQgsyansjcw.Size = new System.Drawing.Size(364, 22);
            this.tsmiQgsyansjcw.Text = "请购适用按钮事件错误。";
            // 
            // tsmiRkdmxbnwkbc
            // 
            this.tsmiRkdmxbnwkbc.Name = "tsmiRkdmxbnwkbc";
            this.tsmiRkdmxbnwkbc.Size = new System.Drawing.Size(364, 22);
            this.tsmiRkdmxbnwkbc.Text = "入库单明细不能为空，请重新订单适用后再进行保存。";
            // 
            // tsmiCxmxdsyjcgdcw
            // 
            this.tsmiCxmxdsyjcgdcw.Name = "tsmiCxmxdsyjcgdcw";
            this.tsmiCxmxdsyjcgdcw.Size = new System.Drawing.Size(364, 22);
            this.tsmiCxmxdsyjcgdcw.Text = "查询明细的上一级采购单错误。";
            // 
            // tsmiCxmxdxyjcgjzdcw
            // 
            this.tsmiCxmxdxyjcgjzdcw.Name = "tsmiCxmxdxyjcgjzdcw";
            this.tsmiCxmxdxyjcgjzdcw.Size = new System.Drawing.Size(364, 22);
            this.tsmiCxmxdxyjcgjzdcw.Text = "查询明细的下一级采购结账单错误。";
            // 
            // tsmiDgrqbnwkcx
            // 
            this.tsmiDgrqbnwkcx.Name = "tsmiDgrqbnwkcx";
            this.tsmiDgrqbnwkcx.Size = new System.Drawing.Size(364, 22);
            this.tsmiDgrqbnwkcx.Text = "订购日期不能为空，请设置后重新进行查询。";
            // 
            // tsmiCxcgddsjcw
            // 
            this.tsmiCxcgddsjcw.Name = "tsmiCxcgddsjcw";
            this.tsmiCxcgddsjcw.Size = new System.Drawing.Size(364, 22);
            this.tsmiCxcgddsjcw.Text = "查询采购订单事件错误。";
            // 
            // tsmiJjcxcgddmxsjcw
            // 
            this.tsmiJjcxcgddmxsjcw.Name = "tsmiJjcxcgddmxsjcw";
            this.tsmiJjcxcgddmxsjcw.Size = new System.Drawing.Size(364, 22);
            this.tsmiJjcxcgddmxsjcw.Text = "聚焦查询采购订单明细事件错误。";
            // 
            // tsmiSxtzcgddsjcw
            // 
            this.tsmiSxtzcgddsjcw.Name = "tsmiSxtzcgddsjcw";
            this.tsmiSxtzcgddsjcw.Size = new System.Drawing.Size(364, 22);
            this.tsmiSxtzcgddsjcw.Text = "实现拖拽采购订单事件错误。";
            // 
            // tsmiYzrkdzrxxtdxmhjxdj
            // 
            this.tsmiYzrkdzrxxtdxmhjxdj.Name = "tsmiYzrkdzrxxtdxmhjxdj";
            this.tsmiYzrkdzrxxtdxmhjxdj.Size = new System.Drawing.Size(364, 22);
            this.tsmiYzrkdzrxxtdxmhjxdj.Text = "\"一张入库单只允许相同的项目号进行登记。";
            // 
            // tsmiYzrkdzrxxtdgysjxdj
            // 
            this.tsmiYzrkdzrxxtdgysjxdj.Name = "tsmiYzrkdzrxxtdgysjxdj";
            this.tsmiYzrkdzrxxtdgysjxdj.Size = new System.Drawing.Size(364, 22);
            this.tsmiYzrkdzrxxtdgysjxdj.Text = "一张入库单只允许相同的供应商进行登记。";
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCkrqbnwkcx,
            this.tsmiDqckdyjxghh,
            this.tsmiCkbmbnwkbc,
            this.tsmiCkckbnwkbc,
            this.tsmiCklbbnwkbc,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.tsmiCkdmxbnwkbc,
            this.tsmiYzkcyddbxxz,
            this.tsmiYdrqbnwkcx,
            this.tsmiDqkcyddyjxghh,
            this.tsmiSqbmbnwkbc,
            this.tsmiCkxmhbnwkbc,
            this.tsmiCkhjhbnwkbc,
            this.tsmiRkxmhbnwkbc,
            this.tsmiRkhjhbnwkbc,
            this.tsmiCkdckxmhhjhhrk,
            this.tsmiSxtddqkcsjcw});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(533, 422);
            // 
            // tsmiCkrqbnwkcx
            // 
            this.tsmiCkrqbnwkcx.Name = "tsmiCkrqbnwkcx";
            this.tsmiCkrqbnwkcx.Size = new System.Drawing.Size(532, 22);
            this.tsmiCkrqbnwkcx.Text = "出库日期不能为空，请设置后重新进行查询。";
            // 
            // tsmiDqckdyjxghh
            // 
            this.tsmiDqckdyjxghh.Name = "tsmiDqckdyjxghh";
            this.tsmiDqckdyjxghh.Size = new System.Drawing.Size(532, 22);
            this.tsmiDqckdyjxghh.Text = "当前出库单已经修改，请保存后再进行换行。";
            // 
            // tsmiCkbmbnwkbc
            // 
            this.tsmiCkbmbnwkbc.Name = "tsmiCkbmbnwkbc";
            this.tsmiCkbmbnwkbc.Size = new System.Drawing.Size(532, 22);
            this.tsmiCkbmbnwkbc.Text = "出库部门不能为空，请填写后再进行保存。";
            // 
            // tsmiCkckbnwkbc
            // 
            this.tsmiCkckbnwkbc.Name = "tsmiCkckbnwkbc";
            this.tsmiCkckbnwkbc.Size = new System.Drawing.Size(532, 22);
            this.tsmiCkckbnwkbc.Text = "出库仓库不能为空，请填写后再进行保存。";
            // 
            // tsmiCklbbnwkbc
            // 
            this.tsmiCklbbnwkbc.Name = "tsmiCklbbnwkbc";
            this.tsmiCklbbnwkbc.Size = new System.Drawing.Size(532, 22);
            this.tsmiCklbbnwkbc.Text = "出库类别不能为空，请填写后再进行保存。";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(532, 22);
            this.toolStripMenuItem1.Text = "审批类型不能为空，请填写后再进行保存。";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(532, 22);
            this.toolStripMenuItem2.Text = "数量不能为空，请填写后再进行保存。";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(532, 22);
            this.toolStripMenuItem3.Text = "货架编号不能为空，请填写后再进行保存。";
            // 
            // tsmiCkdmxbnwkbc
            // 
            this.tsmiCkdmxbnwkbc.Name = "tsmiCkdmxbnwkbc";
            this.tsmiCkdmxbnwkbc.Size = new System.Drawing.Size(532, 22);
            this.tsmiCkdmxbnwkbc.Text = "出库单明细不能为空，请填写后再进行保存。";
            // 
            // tsmiYzkcyddbxxz
            // 
            this.tsmiYzkcyddbxxz.Name = "tsmiYzkcyddbxxz";
            this.tsmiYzkcyddbxxz.Size = new System.Drawing.Size(532, 22);
            this.tsmiYzkcyddbxxz.Text = "一张库存移动单必须选择相同的仓库进行登记，请重新操作。";
            // 
            // tsmiYdrqbnwkcx
            // 
            this.tsmiYdrqbnwkcx.Name = "tsmiYdrqbnwkcx";
            this.tsmiYdrqbnwkcx.Size = new System.Drawing.Size(532, 22);
            this.tsmiYdrqbnwkcx.Text = "移动日期不能为空，请设置后重新进行查询。";
            // 
            // tsmiDqkcyddyjxghh
            // 
            this.tsmiDqkcyddyjxghh.Name = "tsmiDqkcyddyjxghh";
            this.tsmiDqkcyddyjxghh.Size = new System.Drawing.Size(532, 22);
            this.tsmiDqkcyddyjxghh.Text = "当前库存移动单已经修改，请保存后再进行换行。";
            // 
            // tsmiSqbmbnwkbc
            // 
            this.tsmiSqbmbnwkbc.Name = "tsmiSqbmbnwkbc";
            this.tsmiSqbmbnwkbc.Size = new System.Drawing.Size(532, 22);
            this.tsmiSqbmbnwkbc.Text = "申请部门不能为空，请填写后再进行保存。";
            // 
            // tsmiCkxmhbnwkbc
            // 
            this.tsmiCkxmhbnwkbc.Name = "tsmiCkxmhbnwkbc";
            this.tsmiCkxmhbnwkbc.Size = new System.Drawing.Size(532, 22);
            this.tsmiCkxmhbnwkbc.Text = "出库项目号不能为空，请填写后再进行保存。";
            // 
            // tsmiCkhjhbnwkbc
            // 
            this.tsmiCkhjhbnwkbc.Name = "tsmiCkhjhbnwkbc";
            this.tsmiCkhjhbnwkbc.Size = new System.Drawing.Size(532, 22);
            this.tsmiCkhjhbnwkbc.Text = "出库货架号不能为空，请填写后再进行保存。";
            // 
            // tsmiRkxmhbnwkbc
            // 
            this.tsmiRkxmhbnwkbc.Name = "tsmiRkxmhbnwkbc";
            this.tsmiRkxmhbnwkbc.Size = new System.Drawing.Size(532, 22);
            this.tsmiRkxmhbnwkbc.Text = "入库项目号不能为空，请填写后再进行保存。";
            // 
            // tsmiRkhjhbnwkbc
            // 
            this.tsmiRkhjhbnwkbc.Name = "tsmiRkhjhbnwkbc";
            this.tsmiRkhjhbnwkbc.Size = new System.Drawing.Size(532, 22);
            this.tsmiRkhjhbnwkbc.Text = "入库货架号不能为空，请填写后再进行保存。";
            // 
            // tsmiCkdckxmhhjhhrk
            // 
            this.tsmiCkdckxmhhjhhrk.Name = "tsmiCkdckxmhhjhhrk";
            this.tsmiCkdckxmhhjhhrk.Size = new System.Drawing.Size(532, 22);
            this.tsmiCkdckxmhhjhhrk.Text = "出库的仓库项目号货架号和入库的仓库项目号货架号完全相同，请填写后再进行保存。";
            // 
            // tsmiSxtddqkcsjcw
            // 
            this.tsmiSxtddqkcsjcw.Name = "tsmiSxtddqkcsjcw";
            this.tsmiSxtddqkcsjcw.Size = new System.Drawing.Size(532, 22);
            this.tsmiSxtddqkcsjcw.Text = "实现拖拽当前库存事件错误。";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // colOutLocationId1
            // 
            this.colOutLocationId1.FieldName = "OutLocationId";
            this.colOutLocationId1.Name = "colOutLocationId1";
            // 
            // colInLocationId1
            // 
            this.colInLocationId1.FieldName = "InLocationId";
            this.colInLocationId1.Name = "colInLocationId1";
            // 
            // FrmInventoryMove_Drag
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1370, 601);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.dockPnlLeft);
            this.Name = "FrmInventoryMove_Drag";
            this.TabText = "库存移动单";
            this.Text = "库存移动单";
            this.Activated += new System.EventHandler(this.FrmInventoryMove_Activated);
            this.Load += new System.EventHandler(this.FrmInventoryMove_Load);
            this.Shown += new System.EventHandler(this.FrmInventoryMove_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_IM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableIMHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableIMList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_IMHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_IMList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManagerLeft)).EndInit();
            this.dockPnlLeft.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftMiddle)).EndInit();
            this.pnlLeftMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWNowInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_WNowInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_WNowInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWNowInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWNowInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpShelfId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpLocationId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftTop)).EndInit();
            this.pnlLeftTop.ResumeLayout(false);
            this.pnlLeftTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkZero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpCodeFileNameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIMList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIMList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchCodeFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchCodeFileNameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repbtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchOutProjectNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchOutProjectNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchOutShelfId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchOutShelfNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIMHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIMHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpInRepertoryId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpReqDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchInLocationId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSearchInLocationIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddleTop)).EndInit();
            this.pnlMiddleTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchInLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchInLocationIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchOutLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchOutLocationIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpOutRepertoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpReqDep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpInRepertoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCreator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIMDateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIMDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIMDateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIMDateBegin.Properties)).EndInit();
            this.cms1.ResumeLayout(false);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSet_IM;
        private System.Data.DataTable dataTableIMHead;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColInventoryMoveNo;
        private System.Data.DataColumn dataColInventoryMoveDate;
        private System.Data.DataColumn dataColInRepertoryId;
        private System.Data.DataColumn dataColOutRepertoryId;
        private System.Data.DataColumn dataColCreator;
        private System.Data.DataColumn dataColCreatorIp;
        private System.Data.DataColumn dataColumnRemark;
        private System.Data.DataColumn dataColModifier;
        private System.Data.DataColumn dataColModifierIp;
        private System.Data.DataColumn dataColModifierTime;
        private System.Data.DataColumn dataColSelect;
        private System.Data.DataColumn dataColReqDep;
        private System.Data.DataTable dataTableIMList;
        private System.Data.DataColumn dataColumnAutoId;
        private System.Data.DataColumn dataColumnInventoryMoveNo;
        private System.Data.DataColumn dataColCodeFileName;
        private System.Data.DataColumn dataColQty;
        private System.Data.DataColumn dataColInProjectNo;
        private System.Data.DataColumn dataColInShelfNo;
        private System.Data.DataColumn dataColRemark;
        private System.Data.DataColumn dataColOutProjectNo;
        private System.Data.DataColumn dataColOutShelfNo;
        private System.Data.DataColumn dataColumnInventoryMoveDate;
        private System.Data.DataColumn dataColumnInRepertoryId;
        private System.Data.DataColumn dataColumnOutRepertoryId;
        private System.Windows.Forms.BindingSource bindingSource_IMHead;
        private System.Windows.Forms.BindingSource bindingSource_IMList;
        private System.Data.DataColumn dataColCodeName;
        private DevExpress.XtraBars.Docking.DockManager dockManagerLeft;
        private DevExpress.XtraBars.Docking.DockPanel dockPnlLeft;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.PanelControl pnlRight;
        private DevExpress.XtraEditors.PanelControl pnltop;
        private DevExpress.XtraEditors.LookUpEdit lookUpReqDep;
        private DevExpress.XtraEditors.LookUpEdit lookUpInRepertoryId;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.TextEdit textCommon;
        private DevExpress.XtraEditors.LookUpEdit lookUpCreator;
        private DevExpress.XtraEditors.DateEdit dateIMDateEnd;
        private DevExpress.XtraEditors.LabelControl lab1;
        private DevExpress.XtraEditors.DateEdit dateIMDateBegin;
        private DevExpress.XtraEditors.LabelControl labReqDep;
        private DevExpress.XtraEditors.LabelControl labOutRepertoryId;
        private DevExpress.XtraEditors.LabelControl labInRepertoryId;
        private DevExpress.XtraEditors.LabelControl labCommon;
        private DevExpress.XtraEditors.LabelControl labCreator;
        private DevExpress.XtraEditors.LabelControl labIMDate;
        private System.Data.DataColumn dataColInProjectName;
        private System.Data.DataColumn dataColOutProjectName;
        private DevExpress.XtraEditors.LookUpEdit lookUpOutRepertoryId;
        private System.Data.DataSet dataSet_WNowInfo;
        private System.Data.DataTable TableWNowInfo;
        private System.Data.DataColumn dataAutoId;
        private System.Data.DataColumn dataCodeFileName;
        private System.Data.DataColumn dataCodeName;
        private System.Data.DataColumn dataProjectNo;
        private System.Data.DataColumn dataProjectName;
        private System.Data.DataColumn dataRepertoryId;
        private System.Data.DataColumn dataShelfId;
        private System.Data.DataColumn dataQty;
        private System.Windows.Forms.BindingSource bindingSource_WNowInfo;
        private DevExpress.XtraEditors.PanelControl pnlLeftTop;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpProjectNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpProjectNoView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProjectNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private DevExpress.XtraEditors.SimpleButton btnWNowInfoQuery;
        private DevExpress.XtraEditors.LabelControl labProjectNo;
        private DevExpress.XtraEditors.LabelControl labPrReqNo;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpCodeFileName;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpCodeFileNameView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.LabelControl labCodeFileName;
        private DevExpress.XtraEditors.LookUpEdit lookUpRepertoryId;
        private DevExpress.XtraEditors.PanelControl pnlLeftMiddle;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraEditors.CheckEdit checkAll;
        private DevExpress.XtraGrid.GridControl gridControlIMHead;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewIMHead;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colInventoryMoveNo;
        private DevExpress.XtraGrid.Columns.GridColumn colInRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderHeadDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOutRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colReqDep;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpReqDep;
        private DevExpress.XtraGrid.Columns.GridColumn colPRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraEditors.PanelControl pnlMiddleTop;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnListAdd;
        private DevExpress.XtraGrid.GridControl gridControlIMList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewIMList;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId1;
        private DevExpress.XtraGrid.Columns.GridColumn columnInventoryMoveNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeFileName;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchCodeFileName;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchCodeFileNameView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repbtnDelete;
        private DevExpress.XtraGrid.GridControl gridControlWNowInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWNowInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colSShelfId;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNo1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpRepertoryId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpInRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colInventoryMoveDate;
        private DevExpress.XtraGrid.Columns.GridColumn columnInRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn columnOutRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colInProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colOutProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colOutProjectNo;
        private DevExpress.XtraGrid.Columns.GridColumn colOutShelfId;
        private DevExpress.XtraGrid.Columns.GridColumn colInProjectNo;
        private DevExpress.XtraGrid.Columns.GridColumn colInShelfId;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchOutProjectNo;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchOutProjectNoView;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchOutShelfId;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchOutShelfNoView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn colModifier;
        private DevExpress.XtraEditors.CheckEdit checkZero;
        internal System.Windows.Forms.ContextMenuStrip cms1;
        internal System.Windows.Forms.ToolStripMenuItem tsmiRkrqbnwkcx;
        internal System.Windows.Forms.ToolStripMenuItem tsmiDqrkdyjxghh;
        internal System.Windows.Forms.ToolStripMenuItem tsmiRkbmbnwkbc;
        internal System.Windows.Forms.ToolStripMenuItem tsmiRkckbnwkbc;
        internal System.Windows.Forms.ToolStripMenuItem tsmiRklbbnwkbc;
        internal System.Windows.Forms.ToolStripMenuItem tsmiSplxbnwkbc;
        internal System.Windows.Forms.ToolStripMenuItem tsmiRkmxbnwkbc;
        internal System.Windows.Forms.ToolStripMenuItem tsmiSlbnwkbc;
        internal System.Windows.Forms.ToolStripMenuItem tsmiHjbhbnwkbc;
        internal System.Windows.Forms.ToolStripMenuItem tsmiQgsyansjcw;
        internal System.Windows.Forms.ToolStripMenuItem tsmiRkdmxbnwkbc;
        internal System.Windows.Forms.ToolStripMenuItem tsmiCxmxdsyjcgdcw;
        internal System.Windows.Forms.ToolStripMenuItem tsmiCxmxdxyjcgjzdcw;
        private System.Windows.Forms.ToolStripMenuItem tsmiDgrqbnwkcx;
        private System.Windows.Forms.ToolStripMenuItem tsmiCxcgddsjcw;
        private System.Windows.Forms.ToolStripMenuItem tsmiJjcxcgddmxsjcw;
        private System.Windows.Forms.ToolStripMenuItem tsmiSxtzcgddsjcw;
        private System.Windows.Forms.ToolStripMenuItem tsmiYzrkdzrxxtdxmhjxdj;
        private System.Windows.Forms.ToolStripMenuItem tsmiYzrkdzrxxtdgysjxdj;
        internal System.Windows.Forms.ContextMenuStrip cms;
        internal System.Windows.Forms.ToolStripMenuItem tsmiCkrqbnwkcx;
        internal System.Windows.Forms.ToolStripMenuItem tsmiDqckdyjxghh;
        internal System.Windows.Forms.ToolStripMenuItem tsmiCkbmbnwkbc;
        internal System.Windows.Forms.ToolStripMenuItem tsmiCkckbnwkbc;
        internal System.Windows.Forms.ToolStripMenuItem tsmiCklbbnwkbc;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        internal System.Windows.Forms.ToolStripMenuItem tsmiCkdmxbnwkbc;
        private System.Windows.Forms.ToolStripMenuItem tsmiYzkcyddbxxz;
        private System.Windows.Forms.ToolStripMenuItem tsmiYdrqbnwkcx;
        private System.Windows.Forms.ToolStripMenuItem tsmiDqkcyddyjxghh;
        private System.Windows.Forms.ToolStripMenuItem tsmiSqbmbnwkbc;
        private System.Windows.Forms.ToolStripMenuItem tsmiCkxmhbnwkbc;
        private System.Windows.Forms.ToolStripMenuItem tsmiCkhjhbnwkbc;
        private System.Windows.Forms.ToolStripMenuItem tsmiRkxmhbnwkbc;
        private System.Windows.Forms.ToolStripMenuItem tsmiRkhjhbnwkbc;
        private System.Windows.Forms.ToolStripMenuItem tsmiCkdckxmhhjhhrk;
        private System.Windows.Forms.ToolStripMenuItem tsmiSxtddqkcsjcw;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Data.DataColumn dataColInLocationId;
        private System.Data.DataColumn dataColOutLocationId;
        private System.Data.DataColumn dataColuInLocationId;
        private System.Data.DataColumn dataColuOutLocationId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator;
        private DevExpress.XtraEditors.LabelControl labOutLocationId;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchOutLocationId;
        private DevExpress.XtraGrid.Views.Grid.GridView SearchOutLocationIdView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.LabelControl labInLocationId;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchInLocationId;
        private DevExpress.XtraGrid.Views.Grid.GridView SearchInLocationIdView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuLocationNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuLocationName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuRepertoryName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn colInLocationId;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repSearchInLocationId;
        private DevExpress.XtraGrid.Views.Grid.GridView repSearchInLocationIdView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn colOutLocationId;
        private System.Data.DataColumn dataColumnLocationId;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpLocationId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpShelfId;
        private DevExpress.XtraGrid.Columns.GridColumn colOutLocationId1;
        private DevExpress.XtraGrid.Columns.GridColumn colInLocationId1;
    }
}