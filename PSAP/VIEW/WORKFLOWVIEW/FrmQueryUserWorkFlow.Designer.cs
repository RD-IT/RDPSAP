namespace PSAP.VIEW.BSVIEW
{
    partial class FrmQueryUserWorkFlow
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
            this.dataSet_UserWF = new System.Data.DataSet();
            this.TableUserWorkFlow = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColDataNo = new System.Data.DataColumn();
            this.dataColFlowModuleId = new System.Data.DataColumn();
            this.dataColNodeText = new System.Data.DataColumn();
            this.dataColFlowModuleText = new System.Data.DataColumn();
            this.dataColModuleType = new System.Data.DataColumn();
            this.dataColFMTable = new System.Data.DataColumn();
            this.dataColLFMTable = new System.Data.DataColumn();
            this.bindingSource_UserWF = new System.Windows.Forms.BindingSource(this.components);
            this.pnltop = new DevExpress.XtraEditors.PanelControl();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.gridControlUserWF = new DevExpress.XtraGrid.GridControl();
            this.gridViewUserWF = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowModuleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowModuleText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNodeText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModuleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpModuleType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colFlowModuleTableName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLFMTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_UserWF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableUserWorkFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_UserWF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUserWF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUserWF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpModuleType)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet_UserWF
            // 
            this.dataSet_UserWF.DataSetName = "NewDataSet";
            this.dataSet_UserWF.EnforceConstraints = false;
            this.dataSet_UserWF.Tables.AddRange(new System.Data.DataTable[] {
            this.TableUserWorkFlow});
            // 
            // TableUserWorkFlow
            // 
            this.TableUserWorkFlow.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColDataNo,
            this.dataColFlowModuleId,
            this.dataColNodeText,
            this.dataColFlowModuleText,
            this.dataColModuleType,
            this.dataColFMTable,
            this.dataColLFMTable});
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
            // dataColFlowModuleId
            // 
            this.dataColFlowModuleId.Caption = "业务模块编号";
            this.dataColFlowModuleId.ColumnName = "FlowModuleId";
            // 
            // dataColNodeText
            // 
            this.dataColNodeText.Caption = "流程节点名称";
            this.dataColNodeText.ColumnName = "NodeText";
            // 
            // dataColFlowModuleText
            // 
            this.dataColFlowModuleText.Caption = "业务模块内容";
            this.dataColFlowModuleText.ColumnName = "FlowModuleText";
            // 
            // dataColModuleType
            // 
            this.dataColModuleType.Caption = "当前业务状态";
            this.dataColModuleType.ColumnName = "ModuleType";
            this.dataColModuleType.DataType = typeof(int);
            // 
            // dataColFMTable
            // 
            this.dataColFMTable.Caption = "数据库表名";
            this.dataColFMTable.ColumnName = "FMTable";
            // 
            // dataColLFMTable
            // 
            this.dataColLFMTable.Caption = "下级节点数据库表名";
            this.dataColLFMTable.ColumnName = "LFMTable";
            // 
            // bindingSource_UserWF
            // 
            this.bindingSource_UserWF.DataMember = "UserWorkFlow";
            this.bindingSource_UserWF.DataSource = this.dataSet_UserWF;
            // 
            // pnltop
            // 
            this.pnltop.Controls.Add(this.btnTest);
            this.pnltop.Controls.Add(this.btnQuery);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Margin = new System.Windows.Forms.Padding(4);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1008, 40);
            this.pnltop.TabIndex = 3;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(10, 9);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "刷新";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.gridControlUserWF);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 40);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1008, 689);
            this.pnlMiddle.TabIndex = 6;
            // 
            // gridControlUserWF
            // 
            this.gridControlUserWF.DataSource = this.bindingSource_UserWF;
            this.gridControlUserWF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlUserWF.Location = new System.Drawing.Point(2, 2);
            this.gridControlUserWF.MainView = this.gridViewUserWF;
            this.gridControlUserWF.Name = "gridControlUserWF";
            this.gridControlUserWF.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpModuleType});
            this.gridControlUserWF.Size = new System.Drawing.Size(1004, 685);
            this.gridControlUserWF.TabIndex = 4;
            this.gridControlUserWF.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUserWF});
            // 
            // gridViewUserWF
            // 
            this.gridViewUserWF.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colDataNo,
            this.colFlowModuleId,
            this.colFlowModuleText,
            this.colNodeText,
            this.colModuleType,
            this.colFlowModuleTableName,
            this.colLFMTable});
            this.gridViewUserWF.GridControl = this.gridControlUserWF;
            this.gridViewUserWF.IndicatorWidth = 40;
            this.gridViewUserWF.Name = "gridViewUserWF";
            this.gridViewUserWF.OptionsBehavior.Editable = false;
            this.gridViewUserWF.OptionsBehavior.ReadOnly = true;
            this.gridViewUserWF.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewUserWF.OptionsView.ColumnAutoWidth = false;
            this.gridViewUserWF.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewUserWF.OptionsView.ShowFooter = true;
            this.gridViewUserWF.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewUserWF_RowClick);
            this.gridViewUserWF.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewUserWF_CustomDrawRowIndicator);
            this.gridViewUserWF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewUserWF_KeyDown);
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
            this.colDataNo.Visible = true;
            this.colDataNo.VisibleIndex = 0;
            this.colDataNo.Width = 120;
            // 
            // colFlowModuleId
            // 
            this.colFlowModuleId.AppearanceHeader.Options.UseTextOptions = true;
            this.colFlowModuleId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFlowModuleId.FieldName = "FlowModuleId";
            this.colFlowModuleId.Name = "colFlowModuleId";
            this.colFlowModuleId.Visible = true;
            this.colFlowModuleId.VisibleIndex = 1;
            this.colFlowModuleId.Width = 120;
            // 
            // colFlowModuleText
            // 
            this.colFlowModuleText.AppearanceHeader.Options.UseTextOptions = true;
            this.colFlowModuleText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFlowModuleText.FieldName = "FlowModuleText";
            this.colFlowModuleText.Name = "colFlowModuleText";
            this.colFlowModuleText.Visible = true;
            this.colFlowModuleText.VisibleIndex = 2;
            this.colFlowModuleText.Width = 120;
            // 
            // colNodeText
            // 
            this.colNodeText.AppearanceHeader.Options.UseTextOptions = true;
            this.colNodeText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNodeText.FieldName = "NodeText";
            this.colNodeText.Name = "colNodeText";
            this.colNodeText.Visible = true;
            this.colNodeText.VisibleIndex = 3;
            this.colNodeText.Width = 120;
            // 
            // colModuleType
            // 
            this.colModuleType.AppearanceHeader.Options.UseTextOptions = true;
            this.colModuleType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModuleType.ColumnEdit = this.repLookUpModuleType;
            this.colModuleType.FieldName = "ModuleType";
            this.colModuleType.Name = "colModuleType";
            this.colModuleType.Visible = true;
            this.colModuleType.VisibleIndex = 4;
            this.colModuleType.Width = 100;
            // 
            // repLookUpModuleType
            // 
            this.repLookUpModuleType.AutoHeight = false;
            this.repLookUpModuleType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpModuleType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentNo", "部门编号", 95, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "部门名称", 111, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repLookUpModuleType.DisplayMember = "ModuleTypeName";
            this.repLookUpModuleType.Name = "repLookUpModuleType";
            this.repLookUpModuleType.NullText = "";
            this.repLookUpModuleType.ValueMember = "AutoId";
            // 
            // colFlowModuleTableName
            // 
            this.colFlowModuleTableName.FieldName = "FMTable";
            this.colFlowModuleTableName.Name = "colFlowModuleTableName";
            // 
            // colLFMTable
            // 
            this.colLFMTable.FieldName = "LFMTable";
            this.colLFMTable.Name = "colLFMTable";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(106, 9);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // FrmQueryUserWorkFlow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnltop);
            this.Name = "FrmQueryUserWorkFlow";
            this.TabText = "查询用户流程信息";
            this.Text = "查询用户流程信息";
            this.Load += new System.EventHandler(this.FrmQueryUserWorkFlow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_UserWF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableUserWorkFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_UserWF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUserWF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUserWF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpModuleType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSet_UserWF;
        private System.Data.DataTable TableUserWorkFlow;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColDataNo;
        private System.Windows.Forms.BindingSource bindingSource_UserWF;
        private DevExpress.XtraEditors.PanelControl pnltop;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraGrid.GridControl gridControlUserWF;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUserWF;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpModuleType;
        private System.Data.DataColumn dataColFlowModuleId;
        private System.Data.DataColumn dataColNodeText;
        private System.Data.DataColumn dataColFlowModuleText;
        private System.Data.DataColumn dataColModuleType;
        private DevExpress.XtraGrid.Columns.GridColumn colDataNo;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowModuleId;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowModuleText;
        private DevExpress.XtraGrid.Columns.GridColumn colNodeText;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleType;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private System.Data.DataColumn dataColFMTable;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowModuleTableName;
        private System.Data.DataColumn dataColLFMTable;
        private DevExpress.XtraGrid.Columns.GridColumn colLFMTable;
        private DevExpress.XtraEditors.SimpleButton btnTest;
    }
}