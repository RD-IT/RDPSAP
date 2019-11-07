namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWarehouseNowInfo_Bom
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
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.labLocationId = new DevExpress.XtraEditors.LabelControl();
            this.SearchLocationId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.SearchLocationIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lookUpRepertoryId = new DevExpress.XtraEditors.LookUpEdit();
            this.labRepertoryId = new DevExpress.XtraEditors.LabelControl();
            this.textCodeName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.labPartsCodeId = new DevExpress.XtraEditors.LabelControl();
            this.searchCodeFileName = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchCodeFileNameView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabBom = new DevExpress.XtraTab.XtraTabControl();
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
            this.repLookUpCatgName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.CFilePath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CWarehouseQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.pnlPage = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCodeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchCodeFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchCodeFileNameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabBom)).BeginInit();
            this.xtraTabBom.SuspendLayout();
            this.PageBomInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCatgName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPage)).BeginInit();
            this.pnlPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.labLocationId);
            this.pnlTop.Controls.Add(this.SearchLocationId);
            this.pnlTop.Controls.Add(this.lookUpRepertoryId);
            this.pnlTop.Controls.Add(this.labRepertoryId);
            this.pnlTop.Controls.Add(this.textCodeName);
            this.pnlTop.Controls.Add(this.labelControl1);
            this.pnlTop.Controls.Add(this.btnSaveExcel);
            this.pnlTop.Controls.Add(this.btnQuery);
            this.pnlTop.Controls.Add(this.labPartsCodeId);
            this.pnlTop.Controls.Add(this.searchCodeFileName);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1303, 68);
            this.pnlTop.TabIndex = 1;
            // 
            // labLocationId
            // 
            this.labLocationId.Location = new System.Drawing.Point(694, 26);
            this.labLocationId.Name = "labLocationId";
            this.labLocationId.Size = new System.Drawing.Size(36, 14);
            this.labLocationId.TabIndex = 110;
            this.labLocationId.Text = "仓位：";
            // 
            // SearchLocationId
            // 
            this.SearchLocationId.EnterMoveNextControl = true;
            this.SearchLocationId.Location = new System.Drawing.Point(736, 23);
            this.SearchLocationId.Name = "SearchLocationId";
            this.SearchLocationId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLocationId.Properties.View = this.SearchLocationIdView;
            this.SearchLocationId.Size = new System.Drawing.Size(120, 20);
            this.SearchLocationId.TabIndex = 109;
            // 
            // SearchLocationIdView
            // 
            this.SearchLocationIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.SearchLocationIdView.Name = "SearchLocationIdView";
            this.SearchLocationIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.SearchLocationIdView.OptionsView.ShowGroupPanel = false;
            // 
            // lookUpRepertoryId
            // 
            this.lookUpRepertoryId.EnterMoveNextControl = true;
            this.lookUpRepertoryId.Location = new System.Drawing.Point(558, 23);
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
            this.labRepertoryId.Location = new System.Drawing.Point(516, 26);
            this.labRepertoryId.Name = "labRepertoryId";
            this.labRepertoryId.Size = new System.Drawing.Size(36, 14);
            this.labRepertoryId.TabIndex = 108;
            this.labRepertoryId.Text = "仓库：";
            // 
            // textCodeName
            // 
            this.textCodeName.Location = new System.Drawing.Point(347, 23);
            this.textCodeName.Name = "textCodeName";
            this.textCodeName.Properties.ReadOnly = true;
            this.textCodeName.Size = new System.Drawing.Size(150, 20);
            this.textCodeName.TabIndex = 1;
            this.textCodeName.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(281, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 105;
            this.labelControl1.Text = "零件名称：";
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(966, 22);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveExcel.TabIndex = 4;
            this.btnSaveExcel.Text = "存为Excel";
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(883, 22);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // labPartsCodeId
            // 
            this.labPartsCodeId.Location = new System.Drawing.Point(45, 26);
            this.labPartsCodeId.Name = "labPartsCodeId";
            this.labPartsCodeId.Size = new System.Drawing.Size(60, 14);
            this.labPartsCodeId.TabIndex = 13;
            this.labPartsCodeId.Text = "零件编号：";
            // 
            // searchCodeFileName
            // 
            this.searchCodeFileName.EnterMoveNextControl = true;
            this.searchCodeFileName.Location = new System.Drawing.Point(111, 23);
            this.searchCodeFileName.Name = "searchCodeFileName";
            this.searchCodeFileName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchCodeFileName.Properties.View = this.searchCodeFileNameView;
            this.searchCodeFileName.Size = new System.Drawing.Size(150, 20);
            this.searchCodeFileName.TabIndex = 0;
            this.searchCodeFileName.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.searchCodeFileName_EditValueChanging);
            // 
            // searchCodeFileNameView
            // 
            this.searchCodeFileNameView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchCodeFileNameView.Name = "searchCodeFileNameView";
            this.searchCodeFileNameView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchCodeFileNameView.OptionsView.ShowGroupPanel = false;
            // 
            // xtraTabBom
            // 
            this.xtraTabBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabBom.Location = new System.Drawing.Point(2, 2);
            this.xtraTabBom.Name = "xtraTabBom";
            this.xtraTabBom.SelectedTabPage = this.PageBomInfo;
            this.xtraTabBom.Size = new System.Drawing.Size(1299, 553);
            this.xtraTabBom.TabIndex = 2;
            this.xtraTabBom.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PageBomInfo});
            // 
            // PageBomInfo
            // 
            this.PageBomInfo.Controls.Add(this.treeListBom);
            this.PageBomInfo.Name = "PageBomInfo";
            this.PageBomInfo.Size = new System.Drawing.Size(1293, 524);
            this.PageBomInfo.Text = "Bom零件库存";
            // 
            // treeListBom
            // 
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
            this.CCatgName,
            this.CFilePath,
            this.CWarehouseQty});
            this.treeListBom.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.treeListBom.OptionsView.ShowIndicator = false;
            this.treeListBom.OptionsView.ShowVertLines = false;
            this.treeListBom.ParentFieldName = "ReParent";
            this.treeListBom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpCatgName});
            this.treeListBom.Size = new System.Drawing.Size(1293, 524);
            this.treeListBom.TabIndex = 3;
            this.treeListBom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeListBom_KeyDown);
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
            this.CCodeFileName.Width = 350;
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
            this.CCodeName.Width = 150;
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
            this.CQty.Width = 60;
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
            this.CMaterieStateText.VisibleIndex = 4;
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
            this.CCodeSpec.VisibleIndex = 5;
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
            this.CBrand.VisibleIndex = 6;
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
            this.CUnit.VisibleIndex = 7;
            this.CUnit.Width = 80;
            // 
            // CCatgName
            // 
            this.CCatgName.AppearanceHeader.Options.UseTextOptions = true;
            this.CCatgName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CCatgName.Caption = "分类名称";
            this.CCatgName.ColumnEdit = this.repLookUpCatgName;
            this.CCatgName.FieldName = "CatgName";
            this.CCatgName.Name = "CCatgName";
            this.CCatgName.Visible = true;
            this.CCatgName.VisibleIndex = 8;
            this.CCatgName.Width = 80;
            // 
            // repLookUpCatgName
            // 
            this.repLookUpCatgName.AutoHeight = false;
            this.repLookUpCatgName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpCatgName.DisplayMember = "CatgDescription";
            this.repLookUpCatgName.Name = "repLookUpCatgName";
            this.repLookUpCatgName.NullText = "";
            this.repLookUpCatgName.ValueMember = "CatgName";
            // 
            // CFilePath
            // 
            this.CFilePath.AppearanceHeader.Options.UseTextOptions = true;
            this.CFilePath.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CFilePath.Caption = "文件路径";
            this.CFilePath.FieldName = "FilePath";
            this.CFilePath.Name = "CFilePath";
            this.CFilePath.Visible = true;
            this.CFilePath.VisibleIndex = 9;
            this.CFilePath.Width = 400;
            // 
            // CWarehouseQty
            // 
            this.CWarehouseQty.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.CWarehouseQty.AppearanceCell.Options.UseForeColor = true;
            this.CWarehouseQty.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.CWarehouseQty.AppearanceHeader.Options.UseForeColor = true;
            this.CWarehouseQty.AppearanceHeader.Options.UseTextOptions = true;
            this.CWarehouseQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CWarehouseQty.Caption = "当前库存数";
            this.CWarehouseQty.FieldName = "WarehouseQty";
            this.CWarehouseQty.Name = "CWarehouseQty";
            this.CWarehouseQty.Visible = true;
            this.CWarehouseQty.VisibleIndex = 3;
            this.CWarehouseQty.Width = 90;
            // 
            // pnlPage
            // 
            this.pnlPage.Controls.Add(this.xtraTabBom);
            this.pnlPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPage.Location = new System.Drawing.Point(0, 68);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(1303, 557);
            this.pnlPage.TabIndex = 3;
            // 
            // FrmWarehouseNowInfo_Bom
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1303, 625);
            this.Controls.Add(this.pnlPage);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmWarehouseNowInfo_Bom";
            this.TabText = "BOM零件库存查询";
            this.Text = "BOM零件库存查询";
            this.Load += new System.EventHandler(this.FrmWarehouseNowInfo_Bom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLocationIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCodeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchCodeFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchCodeFileNameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabBom)).EndInit();
            this.xtraTabBom.ResumeLayout(false);
            this.PageBomInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCatgName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPage)).EndInit();
            this.pnlPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.TextEdit textCodeName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSaveExcel;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.LabelControl labPartsCodeId;
        private DevExpress.XtraEditors.SearchLookUpEdit searchCodeFileName;
        private DevExpress.XtraGrid.Views.Grid.GridView searchCodeFileNameView;
        private DevExpress.XtraTab.XtraTabControl xtraTabBom;
        private DevExpress.XtraTab.XtraTabPage PageBomInfo;
        private DevExpress.XtraEditors.PanelControl pnlPage;
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
        private DevExpress.XtraTreeList.Columns.TreeListColumn CFilePath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CWarehouseQty;
        private DevExpress.XtraEditors.LookUpEdit lookUpRepertoryId;
        private DevExpress.XtraEditors.LabelControl labRepertoryId;
        private DevExpress.XtraEditors.LabelControl labLocationId;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLocationId;
        private DevExpress.XtraGrid.Views.Grid.GridView SearchLocationIdView;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCatgName;
    }
}