namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWorkFlowsUserQuery
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
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.TabControlWorkFlows = new DevExpress.XtraTab.XtraTabControl();
            this.PageWorkFlowsInfo = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlUserWorkFlow = new DevExpress.XtraGrid.GridControl();
            this.bindingSource_UserWorkFlow = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_UserWorkFlow = new System.Data.DataSet();
            this.TableUserWorkFlow = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColDataNo = new System.Data.DataColumn();
            this.dataColCurrentNodeId = new System.Data.DataColumn();
            this.dataColCurrentState = new System.Data.DataColumn();
            this.dataColApproverLevel = new System.Data.DataColumn();
            this.dataColWorkFlowsType = new System.Data.DataColumn();
            this.dataColLineType = new System.Data.DataColumn();
            this.dataColLFMTable = new System.Data.DataColumn();
            this.dataColNextWorkFlowsType = new System.Data.DataColumn();
            this.gridViewUserWorkFlow = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentNodeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCurrentNodeId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCurrentState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApproverLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkFlowsType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpWorkFlowsType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNextWorkFlowsType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpNextWorkFlowsType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLineType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpLineType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLevelNodeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlHandleTop = new DevExpress.XtraEditors.PanelControl();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlWorkFlows)).BeginInit();
            this.TabControlWorkFlows.SuspendLayout();
            this.PageWorkFlowsInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUserWorkFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_UserWorkFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_UserWorkFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableUserWorkFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUserWorkFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCurrentNodeId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpWorkFlowsType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpNextWorkFlowsType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpLineType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHandleTop)).BeginInit();
            this.pnlHandleTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.TabControlWorkFlows);
            this.pnlMain.Controls.Add(this.pnlHandleTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1139, 616);
            this.pnlMain.TabIndex = 5;
            // 
            // TabControlWorkFlows
            // 
            this.TabControlWorkFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlWorkFlows.Location = new System.Drawing.Point(0, 40);
            this.TabControlWorkFlows.Name = "TabControlWorkFlows";
            this.TabControlWorkFlows.SelectedTabPage = this.PageWorkFlowsInfo;
            this.TabControlWorkFlows.Size = new System.Drawing.Size(1139, 576);
            this.TabControlWorkFlows.TabIndex = 6;
            this.TabControlWorkFlows.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PageWorkFlowsInfo});
            // 
            // PageWorkFlowsInfo
            // 
            this.PageWorkFlowsInfo.Controls.Add(this.gridControlUserWorkFlow);
            this.PageWorkFlowsInfo.Name = "PageWorkFlowsInfo";
            this.PageWorkFlowsInfo.Size = new System.Drawing.Size(1133, 547);
            this.PageWorkFlowsInfo.Text = "工作流提醒信息查询";
            // 
            // gridControlUserWorkFlow
            // 
            this.gridControlUserWorkFlow.DataSource = this.bindingSource_UserWorkFlow;
            this.gridControlUserWorkFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlUserWorkFlow.Location = new System.Drawing.Point(0, 0);
            this.gridControlUserWorkFlow.MainView = this.gridViewUserWorkFlow;
            this.gridControlUserWorkFlow.Name = "gridControlUserWorkFlow";
            this.gridControlUserWorkFlow.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpCurrentNodeId,
            this.repLookUpWorkFlowsType,
            this.repLookUpLineType,
            this.repLookUpNextWorkFlowsType});
            this.gridControlUserWorkFlow.Size = new System.Drawing.Size(1133, 547);
            this.gridControlUserWorkFlow.TabIndex = 5;
            this.gridControlUserWorkFlow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUserWorkFlow});
            // 
            // bindingSource_UserWorkFlow
            // 
            this.bindingSource_UserWorkFlow.DataMember = "UserWorkFlow";
            this.bindingSource_UserWorkFlow.DataSource = this.dataSet_UserWorkFlow;
            // 
            // dataSet_UserWorkFlow
            // 
            this.dataSet_UserWorkFlow.DataSetName = "NewDataSet";
            this.dataSet_UserWorkFlow.EnforceConstraints = false;
            this.dataSet_UserWorkFlow.Tables.AddRange(new System.Data.DataTable[] {
            this.TableUserWorkFlow});
            // 
            // TableUserWorkFlow
            // 
            this.TableUserWorkFlow.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColDataNo,
            this.dataColCurrentNodeId,
            this.dataColCurrentState,
            this.dataColApproverLevel,
            this.dataColWorkFlowsType,
            this.dataColLineType,
            this.dataColLFMTable,
            this.dataColNextWorkFlowsType});
            this.TableUserWorkFlow.TableName = "UserWorkFlow";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColDataNo
            // 
            this.dataColDataNo.Caption = "单据号";
            this.dataColDataNo.ColumnName = "DataNo";
            // 
            // dataColCurrentNodeId
            // 
            this.dataColCurrentNodeId.Caption = "当前状态节点";
            this.dataColCurrentNodeId.ColumnName = "CurrentNodeId";
            this.dataColCurrentNodeId.DataType = typeof(int);
            // 
            // dataColCurrentState
            // 
            this.dataColCurrentState.Caption = "单据状态";
            this.dataColCurrentState.ColumnName = "CurrentState";
            this.dataColCurrentState.DataType = typeof(int);
            // 
            // dataColApproverLevel
            // 
            this.dataColApproverLevel.Caption = "审批级别";
            this.dataColApproverLevel.ColumnName = "ApproverLevel";
            this.dataColApproverLevel.DataType = typeof(int);
            // 
            // dataColWorkFlowsType
            // 
            this.dataColWorkFlowsType.Caption = "流程图类型";
            this.dataColWorkFlowsType.ColumnName = "WorkFlowsType";
            this.dataColWorkFlowsType.DataType = typeof(int);
            // 
            // dataColLineType
            // 
            this.dataColLineType.Caption = "下级操作类型";
            this.dataColLineType.ColumnName = "LineType";
            this.dataColLineType.DataType = typeof(int);
            // 
            // dataColLFMTable
            // 
            this.dataColLFMTable.Caption = "下级状态节点";
            this.dataColLFMTable.ColumnName = "LevelNodeId";
            this.dataColLFMTable.DataType = typeof(int);
            // 
            // dataColNextWorkFlowsType
            // 
            this.dataColNextWorkFlowsType.Caption = "下级流程模块";
            this.dataColNextWorkFlowsType.ColumnName = "NextType";
            this.dataColNextWorkFlowsType.DataType = typeof(int);
            // 
            // gridViewUserWorkFlow
            // 
            this.gridViewUserWorkFlow.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colDataNo,
            this.colCurrentNodeId,
            this.colCurrentState,
            this.colApproverLevel,
            this.colWorkFlowsType,
            this.colNextWorkFlowsType,
            this.colLineType,
            this.colLevelNodeId});
            this.gridViewUserWorkFlow.GridControl = this.gridControlUserWorkFlow;
            this.gridViewUserWorkFlow.IndicatorWidth = 40;
            this.gridViewUserWorkFlow.Name = "gridViewUserWorkFlow";
            this.gridViewUserWorkFlow.OptionsBehavior.Editable = false;
            this.gridViewUserWorkFlow.OptionsBehavior.ReadOnly = true;
            this.gridViewUserWorkFlow.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewUserWorkFlow.OptionsView.AllowCellMerge = true;
            this.gridViewUserWorkFlow.OptionsView.ColumnAutoWidth = false;
            this.gridViewUserWorkFlow.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewUserWorkFlow.OptionsView.ShowFooter = true;
            this.gridViewUserWorkFlow.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWorkFlowsType, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDataNo, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCurrentState, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewUserWorkFlow.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewUserWorkFlow_RowClick);
            this.gridViewUserWorkFlow.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gridViewUserWorkFlow_CellMerge);
            this.gridViewUserWorkFlow.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewUserWorkFlow_CustomDrawRowIndicator);
            this.gridViewUserWorkFlow.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewUserWorkFlow_CustomColumnDisplayText);
            this.gridViewUserWorkFlow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewUserWorkFlow_KeyDown);
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colDataNo
            // 
            this.colDataNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataNo.FieldName = "DataNo";
            this.colDataNo.Name = "colDataNo";
            this.colDataNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DataNo", "共计{0}条")});
            this.colDataNo.Visible = true;
            this.colDataNo.VisibleIndex = 1;
            this.colDataNo.Width = 120;
            // 
            // colCurrentNodeId
            // 
            this.colCurrentNodeId.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentNodeId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentNodeId.ColumnEdit = this.repLookUpCurrentNodeId;
            this.colCurrentNodeId.FieldName = "CurrentNodeId";
            this.colCurrentNodeId.Name = "colCurrentNodeId";
            this.colCurrentNodeId.Visible = true;
            this.colCurrentNodeId.VisibleIndex = 3;
            this.colCurrentNodeId.Width = 120;
            // 
            // repLookUpCurrentNodeId
            // 
            this.repLookUpCurrentNodeId.AutoHeight = false;
            this.repLookUpCurrentNodeId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpCurrentNodeId.DisplayMember = "NodeText";
            this.repLookUpCurrentNodeId.Name = "repLookUpCurrentNodeId";
            this.repLookUpCurrentNodeId.NullText = "";
            this.repLookUpCurrentNodeId.ValueMember = "AutoId";
            // 
            // colCurrentState
            // 
            this.colCurrentState.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentState.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentState.FieldName = "CurrentState";
            this.colCurrentState.Name = "colCurrentState";
            this.colCurrentState.Visible = true;
            this.colCurrentState.VisibleIndex = 2;
            this.colCurrentState.Width = 80;
            // 
            // colApproverLevel
            // 
            this.colApproverLevel.AppearanceHeader.Options.UseTextOptions = true;
            this.colApproverLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colApproverLevel.FieldName = "ApproverLevel";
            this.colApproverLevel.Name = "colApproverLevel";
            this.colApproverLevel.Visible = true;
            this.colApproverLevel.VisibleIndex = 4;
            this.colApproverLevel.Width = 80;
            // 
            // colWorkFlowsType
            // 
            this.colWorkFlowsType.AppearanceHeader.Options.UseTextOptions = true;
            this.colWorkFlowsType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWorkFlowsType.ColumnEdit = this.repLookUpWorkFlowsType;
            this.colWorkFlowsType.FieldName = "WorkFlowsType";
            this.colWorkFlowsType.Name = "colWorkFlowsType";
            this.colWorkFlowsType.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colWorkFlowsType.Visible = true;
            this.colWorkFlowsType.VisibleIndex = 0;
            this.colWorkFlowsType.Width = 120;
            // 
            // repLookUpWorkFlowsType
            // 
            this.repLookUpWorkFlowsType.AutoHeight = false;
            this.repLookUpWorkFlowsType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpWorkFlowsType.DisplayMember = "OrderType";
            this.repLookUpWorkFlowsType.Name = "repLookUpWorkFlowsType";
            this.repLookUpWorkFlowsType.NullText = "";
            this.repLookUpWorkFlowsType.ValueMember = "TypeId";
            // 
            // colNextWorkFlowsType
            // 
            this.colNextWorkFlowsType.AppearanceHeader.Options.UseTextOptions = true;
            this.colNextWorkFlowsType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNextWorkFlowsType.ColumnEdit = this.repLookUpNextWorkFlowsType;
            this.colNextWorkFlowsType.FieldName = "NextType";
            this.colNextWorkFlowsType.Name = "colNextWorkFlowsType";
            this.colNextWorkFlowsType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colNextWorkFlowsType.Visible = true;
            this.colNextWorkFlowsType.VisibleIndex = 5;
            this.colNextWorkFlowsType.Width = 120;
            // 
            // repLookUpNextWorkFlowsType
            // 
            this.repLookUpNextWorkFlowsType.AutoHeight = false;
            this.repLookUpNextWorkFlowsType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpNextWorkFlowsType.DisplayMember = "NextWorkFlowsType";
            this.repLookUpNextWorkFlowsType.Name = "repLookUpNextWorkFlowsType";
            this.repLookUpNextWorkFlowsType.NullText = "";
            this.repLookUpNextWorkFlowsType.ValueMember = "NextTypeId";
            // 
            // colLineType
            // 
            this.colLineType.AppearanceHeader.Options.UseTextOptions = true;
            this.colLineType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLineType.ColumnEdit = this.repLookUpLineType;
            this.colLineType.FieldName = "LineType";
            this.colLineType.Name = "colLineType";
            this.colLineType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colLineType.Visible = true;
            this.colLineType.VisibleIndex = 6;
            this.colLineType.Width = 120;
            // 
            // repLookUpLineType
            // 
            this.repLookUpLineType.AutoHeight = false;
            this.repLookUpLineType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpLineType.DisplayMember = "LineType";
            this.repLookUpLineType.Name = "repLookUpLineType";
            this.repLookUpLineType.NullText = "";
            this.repLookUpLineType.ValueMember = "TypeId";
            // 
            // colLevelNodeId
            // 
            this.colLevelNodeId.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevelNodeId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevelNodeId.ColumnEdit = this.repLookUpCurrentNodeId;
            this.colLevelNodeId.FieldName = "LevelNodeId";
            this.colLevelNodeId.Name = "colLevelNodeId";
            this.colLevelNodeId.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colLevelNodeId.Visible = true;
            this.colLevelNodeId.VisibleIndex = 7;
            this.colLevelNodeId.Width = 120;
            // 
            // pnlHandleTop
            // 
            this.pnlHandleTop.Controls.Add(this.btnQuery);
            this.pnlHandleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHandleTop.Location = new System.Drawing.Point(0, 0);
            this.pnlHandleTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHandleTop.Name = "pnlHandleTop";
            this.pnlHandleTop.Size = new System.Drawing.Size(1139, 40);
            this.pnlHandleTop.TabIndex = 5;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(10, 9);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // FrmWorkFlowsUserQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1139, 616);
            this.Controls.Add(this.pnlMain);
            this.Name = "FrmWorkFlowsUserQuery";
            this.TabText = "工作流提醒信息查询";
            this.Text = "工作流提醒信息查询";
            this.Activated += new System.EventHandler(this.FrmWorkFlowsUserQuery_Activated);
            this.Load += new System.EventHandler(this.FrmWorkFlowsUserQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabControlWorkFlows)).EndInit();
            this.TabControlWorkFlows.ResumeLayout(false);
            this.PageWorkFlowsInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUserWorkFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_UserWorkFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_UserWorkFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableUserWorkFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUserWorkFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCurrentNodeId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpWorkFlowsType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpNextWorkFlowsType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpLineType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHandleTop)).EndInit();
            this.pnlHandleTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.PanelControl pnlHandleTop;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraTab.XtraTabControl TabControlWorkFlows;
        private DevExpress.XtraTab.XtraTabPage PageWorkFlowsInfo;
        private System.Data.DataSet dataSet_UserWorkFlow;
        private System.Data.DataTable TableUserWorkFlow;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColDataNo;
        private System.Data.DataColumn dataColCurrentNodeId;
        private System.Data.DataColumn dataColCurrentState;
        private System.Data.DataColumn dataColApproverLevel;
        private System.Data.DataColumn dataColWorkFlowsType;
        private System.Data.DataColumn dataColLineType;
        private System.Data.DataColumn dataColLFMTable;
        private System.Windows.Forms.BindingSource bindingSource_UserWorkFlow;
        private DevExpress.XtraGrid.GridControl gridControlUserWorkFlow;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUserWorkFlow;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colDataNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentNodeId;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentState;
        private DevExpress.XtraGrid.Columns.GridColumn colApproverLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkFlowsType;
        private DevExpress.XtraGrid.Columns.GridColumn colLineType;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelNodeId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCurrentNodeId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpWorkFlowsType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpLineType;
        private System.Data.DataColumn dataColNextWorkFlowsType;
        private DevExpress.XtraGrid.Columns.GridColumn colNextWorkFlowsType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpNextWorkFlowsType;
    }
}