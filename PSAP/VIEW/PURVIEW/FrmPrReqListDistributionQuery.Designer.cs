namespace PSAP.VIEW.BSVIEW
{
    partial class FrmPrReqListDistributionQuery
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
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpArrangement = new DevExpress.XtraEditors.LookUpEdit();
            this.labArrangement = new DevExpress.XtraEditors.LabelControl();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.gridControlPrReqList = new DevExpress.XtraGrid.GridControl();
            this.bindingSource_PrReqList = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_PrReqList = new System.Data.DataSet();
            this.dataTablePrReqList = new System.Data.DataTable();
            this.dataColumnAutoId = new System.Data.DataColumn();
            this.dataColumnPrReqNo = new System.Data.DataColumn();
            this.dataColCodeFileName = new System.Data.DataColumn();
            this.dataColQty = new System.Data.DataColumn();
            this.dataColRequirementDate = new System.Data.DataColumn();
            this.dataColPrReqListRemark = new System.Data.DataColumn();
            this.dataColArrangement = new System.Data.DataColumn();
            this.dataColOperator = new System.Data.DataColumn();
            this.dataColArrangementTime = new System.Data.DataColumn();
            this.dataColArrangementFlat = new System.Data.DataColumn();
            this.dataColProjectNo = new System.Data.DataColumn();
            this.dataColStnNo = new System.Data.DataColumn();
            this.gridViewPrReqList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrReqNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCodeName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequirementDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrReqListRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpOperator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colArrangementTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArrangement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArrangementFlat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dataColCodeId = new System.Data.DataColumn();
            this.colCodeId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpArrangement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrReqList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_PrReqList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_PrReqList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTablePrReqList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPrReqList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpOperator)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnQuery);
            this.pnlTop.Controls.Add(this.lookUpArrangement);
            this.pnlTop.Controls.Add(this.labArrangement);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1093, 50);
            this.pnlTop.TabIndex = 7;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(210, 13);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lookUpArrangement
            // 
            this.lookUpArrangement.EnterMoveNextControl = true;
            this.lookUpArrangement.Location = new System.Drawing.Point(68, 14);
            this.lookUpArrangement.Name = "lookUpArrangement";
            this.lookUpArrangement.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpArrangement.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 80, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoginId", "用户名", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "员工名", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpArrangement.Properties.DisplayMember = "EmpName";
            this.lookUpArrangement.Properties.NullText = "";
            this.lookUpArrangement.Properties.ValueMember = "AutoId";
            this.lookUpArrangement.Size = new System.Drawing.Size(120, 20);
            this.lookUpArrangement.TabIndex = 0;
            // 
            // labArrangement
            // 
            this.labArrangement.Location = new System.Drawing.Point(20, 17);
            this.labArrangement.Name = "labArrangement";
            this.labArrangement.Size = new System.Drawing.Size(36, 14);
            this.labArrangement.TabIndex = 13;
            this.labArrangement.Text = "执行人";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.gridControlPrReqList);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 50);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1093, 393);
            this.pnlMiddle.TabIndex = 8;
            // 
            // gridControlPrReqList
            // 
            this.gridControlPrReqList.DataSource = this.bindingSource_PrReqList;
            this.gridControlPrReqList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPrReqList.Location = new System.Drawing.Point(2, 2);
            this.gridControlPrReqList.MainView = this.gridViewPrReqList;
            this.gridControlPrReqList.Name = "gridControlPrReqList";
            this.gridControlPrReqList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpCodeName,
            this.repLookUpOperator});
            this.gridControlPrReqList.Size = new System.Drawing.Size(1089, 389);
            this.gridControlPrReqList.TabIndex = 6;
            this.gridControlPrReqList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPrReqList});
            // 
            // bindingSource_PrReqList
            // 
            this.bindingSource_PrReqList.DataMember = "PrReqList";
            this.bindingSource_PrReqList.DataSource = this.dataSet_PrReqList;
            // 
            // dataSet_PrReqList
            // 
            this.dataSet_PrReqList.DataSetName = "NewDataSet";
            this.dataSet_PrReqList.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTablePrReqList});
            // 
            // dataTablePrReqList
            // 
            this.dataTablePrReqList.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnAutoId,
            this.dataColumnPrReqNo,
            this.dataColCodeFileName,
            this.dataColQty,
            this.dataColRequirementDate,
            this.dataColPrReqListRemark,
            this.dataColArrangement,
            this.dataColOperator,
            this.dataColArrangementTime,
            this.dataColArrangementFlat,
            this.dataColProjectNo,
            this.dataColStnNo,
            this.dataColCodeId});
            this.dataTablePrReqList.TableName = "PrReqList";
            // 
            // dataColumnAutoId
            // 
            this.dataColumnAutoId.ColumnName = "AutoId";
            // 
            // dataColumnPrReqNo
            // 
            this.dataColumnPrReqNo.Caption = "请购单号";
            this.dataColumnPrReqNo.ColumnName = "PrReqNo";
            // 
            // dataColCodeFileName
            // 
            this.dataColCodeFileName.Caption = "零件编号";
            this.dataColCodeFileName.ColumnName = "CodeFileName";
            // 
            // dataColQty
            // 
            this.dataColQty.Caption = "数量";
            this.dataColQty.ColumnName = "Qty";
            this.dataColQty.DataType = typeof(double);
            // 
            // dataColRequirementDate
            // 
            this.dataColRequirementDate.Caption = "需求日期";
            this.dataColRequirementDate.ColumnName = "RequirementDate";
            this.dataColRequirementDate.DataType = typeof(System.DateTime);
            // 
            // dataColPrReqListRemark
            // 
            this.dataColPrReqListRemark.Caption = "备注";
            this.dataColPrReqListRemark.ColumnName = "PrReqListRemark";
            // 
            // dataColArrangement
            // 
            this.dataColArrangement.Caption = "执行人";
            this.dataColArrangement.ColumnName = "Arrangement";
            this.dataColArrangement.DataType = typeof(int);
            // 
            // dataColOperator
            // 
            this.dataColOperator.Caption = "分配人";
            this.dataColOperator.ColumnName = "Operator";
            this.dataColOperator.DataType = typeof(int);
            // 
            // dataColArrangementTime
            // 
            this.dataColArrangementTime.Caption = "分配时间";
            this.dataColArrangementTime.ColumnName = "ArrangementTime";
            this.dataColArrangementTime.DataType = typeof(System.DateTime);
            // 
            // dataColArrangementFlat
            // 
            this.dataColArrangementFlat.Caption = "分配标志";
            this.dataColArrangementFlat.ColumnName = "ArrangementFlat";
            this.dataColArrangementFlat.DataType = typeof(int);
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
            // gridViewPrReqList
            // 
            this.gridViewPrReqList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colPrReqNo,
            this.colCodeFileName,
            this.colCodeName,
            this.colQty,
            this.colRequirementDate,
            this.colPrReqListRemark,
            this.colProjectNo,
            this.colStnNo,
            this.colOperator,
            this.colArrangementTime,
            this.colArrangement,
            this.colArrangementFlat,
            this.colCodeId});
            this.gridViewPrReqList.GridControl = this.gridControlPrReqList;
            this.gridViewPrReqList.IndicatorWidth = 40;
            this.gridViewPrReqList.Name = "gridViewPrReqList";
            this.gridViewPrReqList.OptionsBehavior.Editable = false;
            this.gridViewPrReqList.OptionsBehavior.ReadOnly = true;
            this.gridViewPrReqList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPrReqList.OptionsView.ColumnAutoWidth = false;
            this.gridViewPrReqList.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewPrReqList.OptionsView.ShowFooter = true;
            this.gridViewPrReqList.OptionsView.ShowGroupPanel = false;
            this.gridViewPrReqList.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewPrReqList_RowClick);
            this.gridViewPrReqList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewPrReqList_CustomDrawRowIndicator);
            this.gridViewPrReqList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewPrReqList_KeyDown);
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
            // colCodeFileName
            // 
            this.colCodeFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeFileName.FieldName = "CodeFileName";
            this.colCodeFileName.Name = "colCodeFileName";
            this.colCodeFileName.Visible = true;
            this.colCodeFileName.VisibleIndex = 1;
            this.colCodeFileName.Width = 110;
            // 
            // colCodeName
            // 
            this.colCodeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeName.Caption = "零件名称";
            this.colCodeName.ColumnEdit = this.repLookUpCodeName;
            this.colCodeName.FieldName = "CodeFileName";
            this.colCodeName.Name = "colCodeName";
            this.colCodeName.Visible = true;
            this.colCodeName.VisibleIndex = 2;
            this.colCodeName.Width = 110;
            // 
            // repLookUpCodeName
            // 
            this.repLookUpCodeName.AutoHeight = false;
            this.repLookUpCodeName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpCodeName.DisplayMember = "CodeName";
            this.repLookUpCodeName.Name = "repLookUpCodeName";
            this.repLookUpCodeName.NullText = "";
            this.repLookUpCodeName.ValueMember = "CodeFileName";
            // 
            // colQty
            // 
            this.colQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:0.##}")});
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 3;
            this.colQty.Width = 80;
            // 
            // colRequirementDate
            // 
            this.colRequirementDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colRequirementDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequirementDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colRequirementDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colRequirementDate.FieldName = "RequirementDate";
            this.colRequirementDate.Name = "colRequirementDate";
            this.colRequirementDate.Visible = true;
            this.colRequirementDate.VisibleIndex = 4;
            this.colRequirementDate.Width = 90;
            // 
            // colPrReqListRemark
            // 
            this.colPrReqListRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrReqListRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrReqListRemark.FieldName = "PrReqListRemark";
            this.colPrReqListRemark.Name = "colPrReqListRemark";
            this.colPrReqListRemark.Visible = true;
            this.colPrReqListRemark.VisibleIndex = 5;
            this.colPrReqListRemark.Width = 120;
            // 
            // colProjectNo
            // 
            this.colProjectNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectNo.FieldName = "ProjectNo";
            this.colProjectNo.Name = "colProjectNo";
            this.colProjectNo.Visible = true;
            this.colProjectNo.VisibleIndex = 6;
            this.colProjectNo.Width = 100;
            // 
            // colStnNo
            // 
            this.colStnNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colStnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStnNo.FieldName = "StnNo";
            this.colStnNo.Name = "colStnNo";
            this.colStnNo.Visible = true;
            this.colStnNo.VisibleIndex = 7;
            this.colStnNo.Width = 100;
            // 
            // colOperator
            // 
            this.colOperator.AppearanceHeader.Options.UseTextOptions = true;
            this.colOperator.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOperator.ColumnEdit = this.repLookUpOperator;
            this.colOperator.FieldName = "Operator";
            this.colOperator.Name = "colOperator";
            this.colOperator.Visible = true;
            this.colOperator.VisibleIndex = 8;
            this.colOperator.Width = 80;
            // 
            // repLookUpOperator
            // 
            this.repLookUpOperator.AutoHeight = false;
            this.repLookUpOperator.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpOperator.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoginId", "登陆名"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "用户名")});
            this.repLookUpOperator.DisplayMember = "EmpName";
            this.repLookUpOperator.Name = "repLookUpOperator";
            this.repLookUpOperator.NullText = "";
            this.repLookUpOperator.ValueMember = "AutoId";
            // 
            // colArrangementTime
            // 
            this.colArrangementTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colArrangementTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colArrangementTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colArrangementTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colArrangementTime.FieldName = "ArrangementTime";
            this.colArrangementTime.Name = "colArrangementTime";
            this.colArrangementTime.Visible = true;
            this.colArrangementTime.VisibleIndex = 10;
            this.colArrangementTime.Width = 135;
            // 
            // colArrangement
            // 
            this.colArrangement.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.colArrangement.AppearanceHeader.Options.UseForeColor = true;
            this.colArrangement.AppearanceHeader.Options.UseTextOptions = true;
            this.colArrangement.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colArrangement.ColumnEdit = this.repLookUpOperator;
            this.colArrangement.FieldName = "Arrangement";
            this.colArrangement.Name = "colArrangement";
            this.colArrangement.Visible = true;
            this.colArrangement.VisibleIndex = 9;
            this.colArrangement.Width = 100;
            // 
            // colArrangementFlat
            // 
            this.colArrangementFlat.FieldName = "ArrangementFlat";
            this.colArrangementFlat.Name = "colArrangementFlat";
            // 
            // dataColCodeId
            // 
            this.dataColCodeId.Caption = "零件Id";
            this.dataColCodeId.ColumnName = "CodeId";
            this.dataColCodeId.DataType = typeof(int);
            // 
            // colCodeId
            // 
            this.colCodeId.FieldName = "CodeId";
            this.colCodeId.Name = "colCodeId";
            // 
            // FrmPrReqListDistributionQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1093, 443);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmPrReqListDistributionQuery";
            this.TabText = "请购明细分配查询";
            this.Text = "请购明细分配查询";
            this.Load += new System.EventHandler(this.FrmPrReqListDistributionQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpArrangement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrReqList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_PrReqList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_PrReqList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTablePrReqList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPrReqList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpOperator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.LookUpEdit lookUpArrangement;
        private DevExpress.XtraEditors.LabelControl labArrangement;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private System.Data.DataSet dataSet_PrReqList;
        private System.Data.DataTable dataTablePrReqList;
        private System.Data.DataColumn dataColumnAutoId;
        private System.Data.DataColumn dataColumnPrReqNo;
        private System.Data.DataColumn dataColCodeFileName;
        private System.Data.DataColumn dataColQty;
        private System.Data.DataColumn dataColRequirementDate;
        private System.Data.DataColumn dataColPrReqListRemark;
        private System.Data.DataColumn dataColArrangement;
        private System.Data.DataColumn dataColOperator;
        private System.Data.DataColumn dataColArrangementTime;
        private System.Data.DataColumn dataColArrangementFlat;
        private System.Data.DataColumn dataColProjectNo;
        private System.Data.DataColumn dataColStnNo;
        private System.Windows.Forms.BindingSource bindingSource_PrReqList;
        private DevExpress.XtraGrid.GridControl gridControlPrReqList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPrReqList;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colPrReqNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRequirementDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPrReqListRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNo;
        private DevExpress.XtraGrid.Columns.GridColumn colStnNo;
        private DevExpress.XtraGrid.Columns.GridColumn colOperator;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colArrangementTime;
        private DevExpress.XtraGrid.Columns.GridColumn colArrangement;
        private DevExpress.XtraGrid.Columns.GridColumn colArrangementFlat;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private System.Data.DataColumn dataColCodeId;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeId;
    }
}