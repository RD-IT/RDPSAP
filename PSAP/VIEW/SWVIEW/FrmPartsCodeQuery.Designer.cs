namespace PSAP.VIEW.BSVIEW
{
    partial class FrmPartsCodeQuery
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
            this.dSPartsCode = new System.Data.DataSet();
            this.TablePartsCode = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColCodeFileName = new System.Data.DataColumn();
            this.dataColCodeNo = new System.Data.DataColumn();
            this.dataColCodeName = new System.Data.DataColumn();
            this.dataColFilePath = new System.Data.DataColumn();
            this.dataColCatgName = new System.Data.DataColumn();
            this.dataColCodeSpec = new System.Data.DataColumn();
            this.dataColCodeWeight = new System.Data.DataColumn();
            this.dataColMaterialVersion = new System.Data.DataColumn();
            this.dataColMaterial = new System.Data.DataColumn();
            this.dataColBrand = new System.Data.DataColumn();
            this.dataColFinish = new System.Data.DataColumn();
            this.dataColMachiningLevel = new System.Data.DataColumn();
            this.dataColUnit = new System.Data.DataColumn();
            this.dataColIsPreferred = new System.Data.DataColumn();
            this.dataColIsLongPeriod = new System.Data.DataColumn();
            this.dataColIsPrecious = new System.Data.DataColumn();
            this.dataColIsPreprocessing = new System.Data.DataColumn();
            this.dataColDesigner = new System.Data.DataColumn();
            this.dataColTel = new System.Data.DataColumn();
            this.dataColGetTime = new System.Data.DataColumn();
            this.dataColBfree1 = new System.Data.DataColumn();
            this.dataColBfree2 = new System.Data.DataColumn();
            this.dataColBfree3 = new System.Data.DataColumn();
            this.dataColIsBuy = new System.Data.DataColumn();
            this.bSPartsCode = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.gridBottomPrReq = new PSAP.VIEW.BSVIEW.GridBottom();
            this.pnltop = new DevExpress.XtraEditors.PanelControl();
            this.lookUpBrand = new DevExpress.XtraEditors.LookUpEdit();
            this.labBrand = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveExcel = new DevExpress.XtraEditors.SimpleButton();
            this.textCommon = new DevExpress.XtraEditors.TextEdit();
            this.searchLookUpMaterial = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpMaterialView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColuAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuLibName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuMaterialCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labMaterial = new DevExpress.XtraEditors.LabelControl();
            this.lookUpCatgName = new DevExpress.XtraEditors.LookUpEdit();
            this.labCatgName = new DevExpress.XtraEditors.LabelControl();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.labCommon = new DevExpress.XtraEditors.LabelControl();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridCrlPartsCode = new DevExpress.XtraGrid.GridControl();
            this.gridViewPartsCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCatgName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCatgName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCodeSpec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpMaterial = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinish = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpFinish = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMachiningLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpMachiningLevel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPreferred = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLongPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPrecious = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPreprocessing = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBuy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckIsBuy = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colDesigner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGetTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBfree1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBfree2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBfree3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dSPartsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePartsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSPartsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).BeginInit();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBrand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpMaterialView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCatgName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlPartsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPartsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCatgName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpMachiningLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsBuy)).BeginInit();
            this.SuspendLayout();
            // 
            // dSPartsCode
            // 
            this.dSPartsCode.DataSetName = "NewDataSet";
            this.dSPartsCode.EnforceConstraints = false;
            this.dSPartsCode.Tables.AddRange(new System.Data.DataTable[] {
            this.TablePartsCode});
            // 
            // TablePartsCode
            // 
            this.TablePartsCode.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColCodeFileName,
            this.dataColCodeNo,
            this.dataColCodeName,
            this.dataColFilePath,
            this.dataColCatgName,
            this.dataColCodeSpec,
            this.dataColCodeWeight,
            this.dataColMaterialVersion,
            this.dataColMaterial,
            this.dataColBrand,
            this.dataColFinish,
            this.dataColMachiningLevel,
            this.dataColUnit,
            this.dataColIsPreferred,
            this.dataColIsLongPeriod,
            this.dataColIsPrecious,
            this.dataColIsPreprocessing,
            this.dataColDesigner,
            this.dataColTel,
            this.dataColGetTime,
            this.dataColBfree1,
            this.dataColBfree2,
            this.dataColBfree3,
            this.dataColIsBuy});
            this.TablePartsCode.TableName = "PartsCode";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
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
            // dataColFilePath
            // 
            this.dataColFilePath.Caption = "文件路径";
            this.dataColFilePath.ColumnName = "FilePath";
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
            // dataColMaterialVersion
            // 
            this.dataColMaterialVersion.Caption = "物料版本";
            this.dataColMaterialVersion.ColumnName = "MaterialVersion";
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
            // dataColFinish
            // 
            this.dataColFinish.Caption = "表面处理";
            this.dataColFinish.ColumnName = "Finish";
            this.dataColFinish.DataType = typeof(int);
            // 
            // dataColMachiningLevel
            // 
            this.dataColMachiningLevel.Caption = "加工等级";
            this.dataColMachiningLevel.ColumnName = "MachiningLevel";
            this.dataColMachiningLevel.DataType = typeof(int);
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
            // dataColTel
            // 
            this.dataColTel.Caption = "电话";
            this.dataColTel.ColumnName = "Tel";
            // 
            // dataColGetTime
            // 
            this.dataColGetTime.Caption = "登记时间";
            this.dataColGetTime.ColumnName = "GetTime";
            this.dataColGetTime.DataType = typeof(System.DateTime);
            // 
            // dataColBfree1
            // 
            this.dataColBfree1.ColumnName = "Bfree1";
            // 
            // dataColBfree2
            // 
            this.dataColBfree2.ColumnName = "Bfree2";
            // 
            // dataColBfree3
            // 
            this.dataColBfree3.ColumnName = "Bfree3";
            // 
            // dataColIsBuy
            // 
            this.dataColIsBuy.Caption = "是否购买";
            this.dataColIsBuy.ColumnName = "IsBuy";
            this.dataColIsBuy.DataType = typeof(short);
            // 
            // bSPartsCode
            // 
            this.bSPartsCode.DataMember = "PartsCode";
            this.bSPartsCode.DataSource = this.dSPartsCode;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.gridBottomPrReq);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 642);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1611, 58);
            this.pnlBottom.TabIndex = 4;
            // 
            // gridBottomPrReq
            // 
            this.gridBottomPrReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBottomPrReq.Location = new System.Drawing.Point(2, 2);
            this.gridBottomPrReq.MasterDataSet = this.dSPartsCode;
            this.gridBottomPrReq.Name = "gridBottomPrReq";
            this.gridBottomPrReq.pageRowCount = 5;
            this.gridBottomPrReq.Size = new System.Drawing.Size(1607, 54);
            this.gridBottomPrReq.TabIndex = 0;
            // 
            // pnltop
            // 
            this.pnltop.Controls.Add(this.lookUpBrand);
            this.pnltop.Controls.Add(this.labBrand);
            this.pnltop.Controls.Add(this.btnSaveExcel);
            this.pnltop.Controls.Add(this.textCommon);
            this.pnltop.Controls.Add(this.searchLookUpMaterial);
            this.pnltop.Controls.Add(this.labMaterial);
            this.pnltop.Controls.Add(this.lookUpCatgName);
            this.pnltop.Controls.Add(this.labCatgName);
            this.pnltop.Controls.Add(this.btnQuery);
            this.pnltop.Controls.Add(this.labCommon);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1611, 78);
            this.pnltop.TabIndex = 5;
            // 
            // lookUpBrand
            // 
            this.lookUpBrand.EnterMoveNextControl = true;
            this.lookUpBrand.Location = new System.Drawing.Point(446, 14);
            this.lookUpBrand.Name = "lookUpBrand";
            this.lookUpBrand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpBrand.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BrandNo", "品牌编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BrandName", "品牌名称")});
            this.lookUpBrand.Properties.DisplayMember = "BrandName";
            this.lookUpBrand.Properties.NullText = "";
            this.lookUpBrand.Properties.ValueMember = "BrandName";
            this.lookUpBrand.Size = new System.Drawing.Size(120, 20);
            this.lookUpBrand.TabIndex = 2;
            // 
            // labBrand
            // 
            this.labBrand.Location = new System.Drawing.Point(404, 17);
            this.labBrand.Name = "labBrand";
            this.labBrand.Size = new System.Drawing.Size(36, 14);
            this.labBrand.TabIndex = 44;
            this.labBrand.Text = "品牌：";
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(356, 43);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveExcel.TabIndex = 5;
            this.btnSaveExcel.Text = "存为Excel";
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // textCommon
            // 
            this.textCommon.EnterMoveNextControl = true;
            this.textCommon.Location = new System.Drawing.Point(86, 44);
            this.textCommon.Name = "textCommon";
            this.textCommon.Size = new System.Drawing.Size(150, 20);
            this.textCommon.TabIndex = 3;
            // 
            // searchLookUpMaterial
            // 
            this.searchLookUpMaterial.EditValue = "";
            this.searchLookUpMaterial.EnterMoveNextControl = true;
            this.searchLookUpMaterial.Location = new System.Drawing.Point(266, 14);
            this.searchLookUpMaterial.Name = "searchLookUpMaterial";
            this.searchLookUpMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpMaterial.Properties.DisplayMember = "MaterialName";
            this.searchLookUpMaterial.Properties.NullText = "";
            this.searchLookUpMaterial.Properties.ValueMember = "AutoId";
            this.searchLookUpMaterial.Properties.View = this.searchLookUpMaterialView;
            this.searchLookUpMaterial.Size = new System.Drawing.Size(120, 20);
            this.searchLookUpMaterial.TabIndex = 1;
            // 
            // searchLookUpMaterialView
            // 
            this.searchLookUpMaterialView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColuAutoId,
            this.gridColuLibName,
            this.gridColuMaterialCategory,
            this.gridColuMaterialName});
            this.searchLookUpMaterialView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpMaterialView.IndicatorWidth = 40;
            this.searchLookUpMaterialView.Name = "searchLookUpMaterialView";
            this.searchLookUpMaterialView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpMaterialView.OptionsView.ShowGroupPanel = false;
            this.searchLookUpMaterialView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewPartsCode_CustomDrawRowIndicator);
            // 
            // gridColuAutoId
            // 
            this.gridColuAutoId.Caption = "AutoId";
            this.gridColuAutoId.FieldName = "AutoId";
            this.gridColuAutoId.Name = "gridColuAutoId";
            // 
            // gridColuLibName
            // 
            this.gridColuLibName.Caption = "LibName";
            this.gridColuLibName.FieldName = "LibName";
            this.gridColuLibName.Name = "gridColuLibName";
            this.gridColuLibName.Visible = true;
            this.gridColuLibName.VisibleIndex = 0;
            // 
            // gridColuMaterialCategory
            // 
            this.gridColuMaterialCategory.Caption = "材料类别";
            this.gridColuMaterialCategory.FieldName = "MaterialCategory";
            this.gridColuMaterialCategory.Name = "gridColuMaterialCategory";
            this.gridColuMaterialCategory.Visible = true;
            this.gridColuMaterialCategory.VisibleIndex = 1;
            // 
            // gridColuMaterialName
            // 
            this.gridColuMaterialName.Caption = "材料名称";
            this.gridColuMaterialName.FieldName = "MaterialName";
            this.gridColuMaterialName.Name = "gridColuMaterialName";
            this.gridColuMaterialName.Visible = true;
            this.gridColuMaterialName.VisibleIndex = 2;
            // 
            // labMaterial
            // 
            this.labMaterial.Location = new System.Drawing.Point(224, 17);
            this.labMaterial.Name = "labMaterial";
            this.labMaterial.Size = new System.Drawing.Size(36, 14);
            this.labMaterial.TabIndex = 42;
            this.labMaterial.Text = "材料：";
            // 
            // lookUpCatgName
            // 
            this.lookUpCatgName.EnterMoveNextControl = true;
            this.lookUpCatgName.Location = new System.Drawing.Point(86, 14);
            this.lookUpCatgName.Name = "lookUpCatgName";
            this.lookUpCatgName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCatgName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CatgName", "分类名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CatgDescription", "分类说明")});
            this.lookUpCatgName.Properties.DisplayMember = "CatgDescription";
            this.lookUpCatgName.Properties.NullText = "";
            this.lookUpCatgName.Properties.ValueMember = "CatgName";
            this.lookUpCatgName.Size = new System.Drawing.Size(120, 20);
            this.lookUpCatgName.TabIndex = 0;
            // 
            // labCatgName
            // 
            this.labCatgName.Location = new System.Drawing.Point(20, 17);
            this.labCatgName.Name = "labCatgName";
            this.labCatgName.Size = new System.Drawing.Size(60, 14);
            this.labCatgName.TabIndex = 43;
            this.labCatgName.Text = "零件分类：";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(266, 43);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // labCommon
            // 
            this.labCommon.Location = new System.Drawing.Point(20, 47);
            this.labCommon.Name = "labCommon";
            this.labCommon.Size = new System.Drawing.Size(60, 14);
            this.labCommon.TabIndex = 12;
            this.labCommon.Text = "通用查询：";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridCrlPartsCode);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 78);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1611, 564);
            this.pnlGrid.TabIndex = 9;
            // 
            // gridCrlPartsCode
            // 
            this.gridCrlPartsCode.DataSource = this.bSPartsCode;
            this.gridCrlPartsCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlPartsCode.Location = new System.Drawing.Point(2, 2);
            this.gridCrlPartsCode.MainView = this.gridViewPartsCode;
            this.gridCrlPartsCode.Name = "gridCrlPartsCode";
            this.gridCrlPartsCode.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckIsBuy,
            this.repLookUpMaterial,
            this.repLookUpCatgName,
            this.repLookUpFinish,
            this.repLookUpMachiningLevel});
            this.gridCrlPartsCode.Size = new System.Drawing.Size(1607, 560);
            this.gridCrlPartsCode.TabIndex = 0;
            this.gridCrlPartsCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPartsCode});
            // 
            // gridViewPartsCode
            // 
            this.gridViewPartsCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colCodeFileName,
            this.colCodeNo,
            this.colCodeName,
            this.colFilePath,
            this.colCatgName,
            this.colCodeSpec,
            this.colCodeWeight,
            this.colMaterialVersion,
            this.colMaterial,
            this.colBrand,
            this.colFinish,
            this.colMachiningLevel,
            this.colUnit,
            this.colIsPreferred,
            this.colIsLongPeriod,
            this.colIsPrecious,
            this.colIsPreprocessing,
            this.colIsBuy,
            this.colDesigner,
            this.colTel,
            this.colGetTime,
            this.colBfree1,
            this.colBfree2,
            this.colBfree3});
            this.gridViewPartsCode.GridControl = this.gridCrlPartsCode;
            this.gridViewPartsCode.IndicatorWidth = 60;
            this.gridViewPartsCode.Name = "gridViewPartsCode";
            this.gridViewPartsCode.OptionsBehavior.Editable = false;
            this.gridViewPartsCode.OptionsBehavior.ReadOnly = true;
            this.gridViewPartsCode.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPartsCode.OptionsView.ColumnAutoWidth = false;
            this.gridViewPartsCode.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewPartsCode.OptionsView.ShowFooter = true;
            this.gridViewPartsCode.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewPartsCode_RowClick);
            this.gridViewPartsCode.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewPartsCode_CustomDrawRowIndicator);
            this.gridViewPartsCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewPartsCode_KeyDown);
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
            this.colCodeFileName.VisibleIndex = 0;
            this.colCodeFileName.Width = 120;
            // 
            // colCodeNo
            // 
            this.colCodeNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeNo.FieldName = "CodeNo";
            this.colCodeNo.Name = "colCodeNo";
            this.colCodeNo.Visible = true;
            this.colCodeNo.VisibleIndex = 1;
            this.colCodeNo.Width = 120;
            // 
            // colCodeName
            // 
            this.colCodeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeName.FieldName = "CodeName";
            this.colCodeName.Name = "colCodeName";
            this.colCodeName.Visible = true;
            this.colCodeName.VisibleIndex = 2;
            this.colCodeName.Width = 120;
            // 
            // colFilePath
            // 
            this.colFilePath.AppearanceHeader.Options.UseTextOptions = true;
            this.colFilePath.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFilePath.FieldName = "FilePath";
            this.colFilePath.Name = "colFilePath";
            this.colFilePath.Visible = true;
            this.colFilePath.VisibleIndex = 3;
            this.colFilePath.Width = 250;
            // 
            // colCatgName
            // 
            this.colCatgName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCatgName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCatgName.ColumnEdit = this.repLookUpCatgName;
            this.colCatgName.FieldName = "CatgName";
            this.colCatgName.Name = "colCatgName";
            this.colCatgName.Visible = true;
            this.colCatgName.VisibleIndex = 4;
            this.colCatgName.Width = 80;
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
            this.colCodeWeight.Width = 130;
            // 
            // colMaterialVersion
            // 
            this.colMaterialVersion.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaterialVersion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaterialVersion.FieldName = "MaterialVersion";
            this.colMaterialVersion.Name = "colMaterialVersion";
            this.colMaterialVersion.Visible = true;
            this.colMaterialVersion.VisibleIndex = 7;
            // 
            // colMaterial
            // 
            this.colMaterial.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaterial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaterial.ColumnEdit = this.repLookUpMaterial;
            this.colMaterial.FieldName = "Material";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.Visible = true;
            this.colMaterial.VisibleIndex = 8;
            this.colMaterial.Width = 100;
            // 
            // repLookUpMaterial
            // 
            this.repLookUpMaterial.AutoHeight = false;
            this.repLookUpMaterial.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpMaterial.DisplayMember = "MaterialName";
            this.repLookUpMaterial.Name = "repLookUpMaterial";
            this.repLookUpMaterial.NullText = "";
            this.repLookUpMaterial.ValueMember = "AutoId";
            // 
            // colBrand
            // 
            this.colBrand.AppearanceHeader.Options.UseTextOptions = true;
            this.colBrand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBrand.FieldName = "Brand";
            this.colBrand.Name = "colBrand";
            this.colBrand.Visible = true;
            this.colBrand.VisibleIndex = 9;
            this.colBrand.Width = 90;
            // 
            // colFinish
            // 
            this.colFinish.AppearanceHeader.Options.UseTextOptions = true;
            this.colFinish.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFinish.ColumnEdit = this.repLookUpFinish;
            this.colFinish.FieldName = "Finish";
            this.colFinish.Name = "colFinish";
            this.colFinish.Visible = true;
            this.colFinish.VisibleIndex = 10;
            // 
            // repLookUpFinish
            // 
            this.repLookUpFinish.AutoHeight = false;
            this.repLookUpFinish.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpFinish.DisplayMember = "FinishCatg";
            this.repLookUpFinish.Name = "repLookUpFinish";
            this.repLookUpFinish.NullText = "";
            this.repLookUpFinish.ValueMember = "AutoId";
            // 
            // colMachiningLevel
            // 
            this.colMachiningLevel.AppearanceHeader.Options.UseTextOptions = true;
            this.colMachiningLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMachiningLevel.ColumnEdit = this.repLookUpMachiningLevel;
            this.colMachiningLevel.FieldName = "MachiningLevel";
            this.colMachiningLevel.Name = "colMachiningLevel";
            this.colMachiningLevel.Visible = true;
            this.colMachiningLevel.VisibleIndex = 11;
            // 
            // repLookUpMachiningLevel
            // 
            this.repLookUpMachiningLevel.AutoHeight = false;
            this.repLookUpMachiningLevel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpMachiningLevel.DisplayMember = "LevelCatg";
            this.repLookUpMachiningLevel.Name = "repLookUpMachiningLevel";
            this.repLookUpMachiningLevel.NullText = "";
            this.repLookUpMachiningLevel.ValueMember = "AutoId";
            // 
            // colUnit
            // 
            this.colUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 12;
            // 
            // colIsPreferred
            // 
            this.colIsPreferred.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsPreferred.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsPreferred.FieldName = "IsPreferred";
            this.colIsPreferred.Name = "colIsPreferred";
            this.colIsPreferred.Visible = true;
            this.colIsPreferred.VisibleIndex = 13;
            this.colIsPreferred.Width = 60;
            // 
            // colIsLongPeriod
            // 
            this.colIsLongPeriod.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsLongPeriod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsLongPeriod.FieldName = "IsLongPeriod";
            this.colIsLongPeriod.Name = "colIsLongPeriod";
            this.colIsLongPeriod.Visible = true;
            this.colIsLongPeriod.VisibleIndex = 14;
            this.colIsLongPeriod.Width = 60;
            // 
            // colIsPrecious
            // 
            this.colIsPrecious.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsPrecious.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsPrecious.FieldName = "IsPrecious";
            this.colIsPrecious.Name = "colIsPrecious";
            this.colIsPrecious.Visible = true;
            this.colIsPrecious.VisibleIndex = 15;
            this.colIsPrecious.Width = 60;
            // 
            // colIsPreprocessing
            // 
            this.colIsPreprocessing.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsPreprocessing.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsPreprocessing.FieldName = "IsPreprocessing";
            this.colIsPreprocessing.Name = "colIsPreprocessing";
            this.colIsPreprocessing.Visible = true;
            this.colIsPreprocessing.VisibleIndex = 16;
            this.colIsPreprocessing.Width = 60;
            // 
            // colIsBuy
            // 
            this.colIsBuy.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsBuy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsBuy.ColumnEdit = this.repCheckIsBuy;
            this.colIsBuy.FieldName = "IsBuy";
            this.colIsBuy.Name = "colIsBuy";
            this.colIsBuy.Visible = true;
            this.colIsBuy.VisibleIndex = 17;
            this.colIsBuy.Width = 60;
            // 
            // repCheckIsBuy
            // 
            this.repCheckIsBuy.AutoHeight = false;
            this.repCheckIsBuy.Name = "repCheckIsBuy";
            this.repCheckIsBuy.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckIsBuy.ValueChecked = ((short)(1));
            this.repCheckIsBuy.ValueUnchecked = ((short)(0));
            // 
            // colDesigner
            // 
            this.colDesigner.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesigner.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesigner.FieldName = "Designer";
            this.colDesigner.Name = "colDesigner";
            this.colDesigner.Visible = true;
            this.colDesigner.VisibleIndex = 18;
            this.colDesigner.Width = 100;
            // 
            // colTel
            // 
            this.colTel.AppearanceHeader.Options.UseTextOptions = true;
            this.colTel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTel.FieldName = "Tel";
            this.colTel.Name = "colTel";
            this.colTel.Visible = true;
            this.colTel.VisibleIndex = 19;
            this.colTel.Width = 120;
            // 
            // colGetTime
            // 
            this.colGetTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colGetTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGetTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colGetTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colGetTime.FieldName = "GetTime";
            this.colGetTime.Name = "colGetTime";
            this.colGetTime.Visible = true;
            this.colGetTime.VisibleIndex = 20;
            this.colGetTime.Width = 130;
            // 
            // colBfree1
            // 
            this.colBfree1.FieldName = "Bfree1";
            this.colBfree1.Name = "colBfree1";
            // 
            // colBfree2
            // 
            this.colBfree2.FieldName = "Bfree2";
            this.colBfree2.Name = "colBfree2";
            // 
            // colBfree3
            // 
            this.colBfree3.FieldName = "Bfree3";
            this.colBfree3.Name = "colBfree3";
            // 
            // FrmPartsCodeQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1611, 700);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnltop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "FrmPartsCodeQuery";
            this.TabText = "物料信息查询";
            this.Text = "物料信息查询";
            this.Load += new System.EventHandler(this.FrmPartsCodeQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSPartsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePartsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSPartsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnltop)).EndInit();
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBrand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpMaterialView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCatgName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlPartsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPartsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCatgName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpMachiningLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsBuy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dSPartsCode;
        private System.Data.DataTable TablePartsCode;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColCodeFileName;
        private System.Data.DataColumn dataColCodeNo;
        private System.Data.DataColumn dataColCodeName;
        private System.Data.DataColumn dataColFilePath;
        private System.Data.DataColumn dataColCatgName;
        private System.Data.DataColumn dataColCodeSpec;
        private System.Data.DataColumn dataColCodeWeight;
        private System.Data.DataColumn dataColMaterialVersion;
        private System.Data.DataColumn dataColMaterial;
        private System.Data.DataColumn dataColBrand;
        private System.Data.DataColumn dataColFinish;
        private System.Data.DataColumn dataColMachiningLevel;
        private System.Data.DataColumn dataColUnit;
        private System.Data.DataColumn dataColIsPreferred;
        private System.Data.DataColumn dataColIsLongPeriod;
        private System.Data.DataColumn dataColIsPrecious;
        private System.Data.DataColumn dataColIsPreprocessing;
        private System.Data.DataColumn dataColDesigner;
        private System.Data.DataColumn dataColTel;
        private System.Data.DataColumn dataColGetTime;
        private System.Data.DataColumn dataColBfree1;
        private System.Data.DataColumn dataColBfree2;
        private System.Data.DataColumn dataColBfree3;
        private System.Data.DataColumn dataColIsBuy;
        private System.Windows.Forms.BindingSource bSPartsCode;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private GridBottom gridBottomPrReq;
        private DevExpress.XtraEditors.PanelControl pnltop;
        private DevExpress.XtraEditors.SimpleButton btnSaveExcel;
        private DevExpress.XtraEditors.TextEdit textCommon;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.LabelControl labCommon;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl gridCrlPartsCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPartsCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn colFilePath;
        private DevExpress.XtraGrid.Columns.GridColumn colCatgName;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeSpec;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn colBrand;
        private DevExpress.XtraGrid.Columns.GridColumn colFinish;
        private DevExpress.XtraGrid.Columns.GridColumn colMachiningLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPreferred;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLongPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPrecious;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPreprocessing;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBuy;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckIsBuy;
        private DevExpress.XtraGrid.Columns.GridColumn colDesigner;
        private DevExpress.XtraGrid.Columns.GridColumn colTel;
        private DevExpress.XtraGrid.Columns.GridColumn colGetTime;
        private DevExpress.XtraGrid.Columns.GridColumn colBfree1;
        private DevExpress.XtraGrid.Columns.GridColumn colBfree2;
        private DevExpress.XtraGrid.Columns.GridColumn colBfree3;
        private DevExpress.XtraEditors.LookUpEdit lookUpBrand;
        private DevExpress.XtraEditors.LabelControl labBrand;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpMaterialView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuLibName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuMaterialCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuMaterialName;
        private DevExpress.XtraEditors.LabelControl labMaterial;
        private DevExpress.XtraEditors.LookUpEdit lookUpCatgName;
        private DevExpress.XtraEditors.LabelControl labCatgName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpMaterial;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCatgName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpFinish;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpMachiningLevel;
    }
}