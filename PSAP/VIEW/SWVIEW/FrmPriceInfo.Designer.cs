namespace PSAP.VIEW.BSVIEW
{
    partial class FrmPriceInfo
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
            this.dSPriceInfo = new System.Data.DataSet();
            this.TablePriceInfo = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColBussinessBaseNo = new System.Data.DataColumn();
            this.dataColCodeId = new System.Data.DataColumn();
            this.dataColCurrencyCate = new System.Data.DataColumn();
            this.dataColUnit = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColCreatorIp = new System.Data.DataColumn();
            this.dataColModifier = new System.Data.DataColumn();
            this.dataColModifierIp = new System.Data.DataColumn();
            this.dataColModifierTime = new System.Data.DataColumn();
            this.dataColRemark = new System.Data.DataColumn();
            this.bSPriceInfo = new System.Windows.Forms.BindingSource(this.components);
            this.pnlToolBar = new DevExpress.XtraEditors.PanelControl();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.spinUnit = new DevExpress.XtraEditors.SpinEdit();
            this.lookUpCurrencyCate = new DevExpress.XtraEditors.LookUpEdit();
            this.searchLookUpBussinessBaseNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpBussinessBaseNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnBussinessBaseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBussinessBaseText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBussinessCategoryText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labCurrencyCate = new DevExpress.XtraEditors.LabelControl();
            this.textRemark = new DevExpress.XtraEditors.TextEdit();
            this.labRemark = new DevExpress.XtraEditors.LabelControl();
            this.labUnit = new DevExpress.XtraEditors.LabelControl();
            this.labBussinessBaseNo = new DevExpress.XtraEditors.LabelControl();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridCrlPriceInfo = new DevExpress.XtraGrid.GridControl();
            this.gridViewPriceInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBussinessBaseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpBussinessBaseNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCodeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyCate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCurrencyCate = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colModifier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifierTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dSPriceInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePriceInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSPriceInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCurrencyCate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpBussinessBaseNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpBussinessBaseNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlPriceInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPriceInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpBussinessBaseNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCurrencyCate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            this.SuspendLayout();
            // 
            // dSPriceInfo
            // 
            this.dSPriceInfo.DataSetName = "NewDataSet";
            this.dSPriceInfo.Tables.AddRange(new System.Data.DataTable[] {
            this.TablePriceInfo});
            // 
            // TablePriceInfo
            // 
            this.TablePriceInfo.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColBussinessBaseNo,
            this.dataColCodeId,
            this.dataColCurrencyCate,
            this.dataColUnit,
            this.dataColCreator,
            this.dataColCreatorIp,
            this.dataColModifier,
            this.dataColModifierIp,
            this.dataColModifierTime,
            this.dataColRemark});
            this.TablePriceInfo.TableName = "PriceInfo";
            this.TablePriceInfo.TableNewRow += new System.Data.DataTableNewRowEventHandler(this.TablePriceInfo_TableNewRow);
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColBussinessBaseNo
            // 
            this.dataColBussinessBaseNo.Caption = "供应商";
            this.dataColBussinessBaseNo.ColumnName = "BussinessBaseNo";
            // 
            // dataColCodeId
            // 
            this.dataColCodeId.Caption = "物料编号";
            this.dataColCodeId.ColumnName = "CodeId";
            this.dataColCodeId.DataType = typeof(int);
            // 
            // dataColCurrencyCate
            // 
            this.dataColCurrencyCate.Caption = "币种名称";
            this.dataColCurrencyCate.ColumnName = "CurrencyCate";
            this.dataColCurrencyCate.DataType = typeof(int);
            // 
            // dataColUnit
            // 
            this.dataColUnit.Caption = "单价";
            this.dataColUnit.ColumnName = "Unit";
            this.dataColUnit.DataType = typeof(double);
            // 
            // dataColCreator
            // 
            this.dataColCreator.Caption = "创建人";
            this.dataColCreator.ColumnName = "Creator";
            this.dataColCreator.DataType = typeof(int);
            // 
            // dataColCreatorIp
            // 
            this.dataColCreatorIp.Caption = "创建人IP";
            this.dataColCreatorIp.ColumnName = "CreatorIp";
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
            // dataColRemark
            // 
            this.dataColRemark.Caption = "备注";
            this.dataColRemark.ColumnName = "Remark";
            // 
            // bSPriceInfo
            // 
            this.bSPriceInfo.DataMember = "PriceInfo";
            this.bSPriceInfo.DataSource = this.dSPriceInfo;
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(683, 40);
            this.pnlToolBar.TabIndex = 2;
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.spinUnit);
            this.pnlEdit.Controls.Add(this.lookUpCurrencyCate);
            this.pnlEdit.Controls.Add(this.searchLookUpBussinessBaseNo);
            this.pnlEdit.Controls.Add(this.labCurrencyCate);
            this.pnlEdit.Controls.Add(this.textRemark);
            this.pnlEdit.Controls.Add(this.labRemark);
            this.pnlEdit.Controls.Add(this.labUnit);
            this.pnlEdit.Controls.Add(this.labBussinessBaseNo);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEdit.Location = new System.Drawing.Point(0, 40);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(683, 97);
            this.pnlEdit.TabIndex = 6;
            // 
            // spinUnit
            // 
            this.spinUnit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSPriceInfo, "Unit", true));
            this.spinUnit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinUnit.EnterMoveNextControl = true;
            this.spinUnit.Location = new System.Drawing.Point(529, 21);
            this.spinUnit.Name = "spinUnit";
            this.spinUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinUnit.Properties.DisplayFormat.FormatString = "N2";
            this.spinUnit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinUnit.Properties.EditFormat.FormatString = "N2";
            this.spinUnit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinUnit.Properties.Mask.EditMask = "N2";
            this.spinUnit.Properties.MaxValue = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.spinUnit.Size = new System.Drawing.Size(130, 20);
            this.spinUnit.TabIndex = 2;
            // 
            // lookUpCurrencyCate
            // 
            this.lookUpCurrencyCate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSPriceInfo, "CurrencyCate", true));
            this.lookUpCurrencyCate.EnterMoveNextControl = true;
            this.lookUpCurrencyCate.Location = new System.Drawing.Point(324, 21);
            this.lookUpCurrencyCate.Name = "lookUpCurrencyCate";
            this.lookUpCurrencyCate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCurrencyCate.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyCateAbb", "币种缩写"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyCateName", "币种名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ExchangeRate", "汇率")});
            this.lookUpCurrencyCate.Properties.DisplayMember = "CurrencyCateName";
            this.lookUpCurrencyCate.Properties.DropDownRows = 12;
            this.lookUpCurrencyCate.Properties.NullText = "";
            this.lookUpCurrencyCate.Properties.PopupWidth = 300;
            this.lookUpCurrencyCate.Properties.ValueMember = "AutoId";
            this.lookUpCurrencyCate.Size = new System.Drawing.Size(130, 20);
            this.lookUpCurrencyCate.TabIndex = 1;
            // 
            // searchLookUpBussinessBaseNo
            // 
            this.searchLookUpBussinessBaseNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSPriceInfo, "BussinessBaseNo", true));
            this.searchLookUpBussinessBaseNo.EnterMoveNextControl = true;
            this.searchLookUpBussinessBaseNo.Location = new System.Drawing.Point(89, 21);
            this.searchLookUpBussinessBaseNo.Name = "searchLookUpBussinessBaseNo";
            this.searchLookUpBussinessBaseNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpBussinessBaseNo.Properties.DisplayMember = "BussinessBaseText";
            this.searchLookUpBussinessBaseNo.Properties.NullText = "";
            this.searchLookUpBussinessBaseNo.Properties.ValueMember = "BussinessBaseNo";
            this.searchLookUpBussinessBaseNo.Properties.View = this.searchLookUpBussinessBaseNoView;
            this.searchLookUpBussinessBaseNo.Size = new System.Drawing.Size(160, 20);
            this.searchLookUpBussinessBaseNo.TabIndex = 0;
            // 
            // searchLookUpBussinessBaseNoView
            // 
            this.searchLookUpBussinessBaseNoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnBussinessBaseNo,
            this.gridColumnBussinessBaseText,
            this.gridColumnBussinessCategoryText,
            this.gridColumnAutoId});
            this.searchLookUpBussinessBaseNoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpBussinessBaseNoView.IndicatorWidth = 60;
            this.searchLookUpBussinessBaseNoView.Name = "searchLookUpBussinessBaseNoView";
            this.searchLookUpBussinessBaseNoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpBussinessBaseNoView.OptionsView.ShowGroupPanel = false;
            this.searchLookUpBussinessBaseNoView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.searchLookUpBussinessBaseNoView_CustomDrawRowIndicator);
            // 
            // gridColumnBussinessBaseNo
            // 
            this.gridColumnBussinessBaseNo.Caption = "往来方编号";
            this.gridColumnBussinessBaseNo.FieldName = "BussinessBaseNo";
            this.gridColumnBussinessBaseNo.Name = "gridColumnBussinessBaseNo";
            this.gridColumnBussinessBaseNo.Visible = true;
            this.gridColumnBussinessBaseNo.VisibleIndex = 0;
            // 
            // gridColumnBussinessBaseText
            // 
            this.gridColumnBussinessBaseText.Caption = "往来方名称";
            this.gridColumnBussinessBaseText.FieldName = "BussinessBaseText";
            this.gridColumnBussinessBaseText.Name = "gridColumnBussinessBaseText";
            this.gridColumnBussinessBaseText.Visible = true;
            this.gridColumnBussinessBaseText.VisibleIndex = 1;
            // 
            // gridColumnBussinessCategoryText
            // 
            this.gridColumnBussinessCategoryText.Caption = "往来方分类";
            this.gridColumnBussinessCategoryText.FieldName = "BussinessCategoryText";
            this.gridColumnBussinessCategoryText.Name = "gridColumnBussinessCategoryText";
            this.gridColumnBussinessCategoryText.Visible = true;
            this.gridColumnBussinessCategoryText.VisibleIndex = 2;
            // 
            // gridColumnAutoId
            // 
            this.gridColumnAutoId.Caption = "gridColumnAutoId";
            this.gridColumnAutoId.Name = "gridColumnAutoId";
            // 
            // labCurrencyCate
            // 
            this.labCurrencyCate.Location = new System.Drawing.Point(277, 24);
            this.labCurrencyCate.Name = "labCurrencyCate";
            this.labCurrencyCate.Size = new System.Drawing.Size(24, 14);
            this.labCurrencyCate.TabIndex = 17;
            this.labCurrencyCate.Text = "币种";
            // 
            // textRemark
            // 
            this.textRemark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSPriceInfo, "Remark", true));
            this.textRemark.Location = new System.Drawing.Point(89, 55);
            this.textRemark.Name = "textRemark";
            this.textRemark.Size = new System.Drawing.Size(570, 20);
            this.textRemark.TabIndex = 3;
            // 
            // labRemark
            // 
            this.labRemark.Location = new System.Drawing.Point(36, 58);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new System.Drawing.Size(24, 14);
            this.labRemark.TabIndex = 15;
            this.labRemark.Text = "备注";
            // 
            // labUnit
            // 
            this.labUnit.Location = new System.Drawing.Point(484, 24);
            this.labUnit.Name = "labUnit";
            this.labUnit.Size = new System.Drawing.Size(24, 14);
            this.labUnit.TabIndex = 13;
            this.labUnit.Text = "单价";
            // 
            // labBussinessBaseNo
            // 
            this.labBussinessBaseNo.Location = new System.Drawing.Point(36, 24);
            this.labBussinessBaseNo.Name = "labBussinessBaseNo";
            this.labBussinessBaseNo.Size = new System.Drawing.Size(36, 14);
            this.labBussinessBaseNo.TabIndex = 12;
            this.labBussinessBaseNo.Text = "供应商";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridCrlPriceInfo);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 137);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(683, 409);
            this.pnlGrid.TabIndex = 7;
            // 
            // gridCrlPriceInfo
            // 
            this.gridCrlPriceInfo.DataSource = this.bSPriceInfo;
            this.gridCrlPriceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlPriceInfo.Location = new System.Drawing.Point(2, 2);
            this.gridCrlPriceInfo.MainView = this.gridViewPriceInfo;
            this.gridCrlPriceInfo.Name = "gridCrlPriceInfo";
            this.gridCrlPriceInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpCreator,
            this.repLookUpBussinessBaseNo,
            this.repLookUpCurrencyCate});
            this.gridCrlPriceInfo.Size = new System.Drawing.Size(679, 405);
            this.gridCrlPriceInfo.TabIndex = 0;
            this.gridCrlPriceInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPriceInfo});
            // 
            // gridViewPriceInfo
            // 
            this.gridViewPriceInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colBussinessBaseNo,
            this.colCodeId,
            this.colCurrencyCate,
            this.colUnit,
            this.colRemark,
            this.colCreator,
            this.colModifier,
            this.colModifierTime});
            this.gridViewPriceInfo.GridControl = this.gridCrlPriceInfo;
            this.gridViewPriceInfo.IndicatorWidth = 40;
            this.gridViewPriceInfo.Name = "gridViewPriceInfo";
            this.gridViewPriceInfo.OptionsBehavior.Editable = false;
            this.gridViewPriceInfo.OptionsFilter.AllowFilterEditor = false;
            this.gridViewPriceInfo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPriceInfo.OptionsView.ColumnAutoWidth = false;
            this.gridViewPriceInfo.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewPriceInfo.OptionsView.ShowFooter = true;
            this.gridViewPriceInfo.OptionsView.ShowGroupPanel = false;
            this.gridViewPriceInfo.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewPriceInfo_InitNewRow);
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colBussinessBaseNo
            // 
            this.colBussinessBaseNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colBussinessBaseNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBussinessBaseNo.ColumnEdit = this.repLookUpBussinessBaseNo;
            this.colBussinessBaseNo.FieldName = "BussinessBaseNo";
            this.colBussinessBaseNo.Name = "colBussinessBaseNo";
            this.colBussinessBaseNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "BussinessBaseNo", "共计{0}条")});
            this.colBussinessBaseNo.Visible = true;
            this.colBussinessBaseNo.VisibleIndex = 0;
            this.colBussinessBaseNo.Width = 130;
            // 
            // repLookUpBussinessBaseNo
            // 
            this.repLookUpBussinessBaseNo.AutoHeight = false;
            this.repLookUpBussinessBaseNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpBussinessBaseNo.DisplayMember = "BussinessBaseText";
            this.repLookUpBussinessBaseNo.Name = "repLookUpBussinessBaseNo";
            this.repLookUpBussinessBaseNo.NullText = "";
            this.repLookUpBussinessBaseNo.ValueMember = "BussinessBaseNo";
            // 
            // colCodeId
            // 
            this.colCodeId.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeId.FieldName = "CodeId";
            this.colCodeId.Name = "colCodeId";
            this.colCodeId.Width = 130;
            // 
            // colCurrencyCate
            // 
            this.colCurrencyCate.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrencyCate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrencyCate.ColumnEdit = this.repLookUpCurrencyCate;
            this.colCurrencyCate.FieldName = "CurrencyCate";
            this.colCurrencyCate.Name = "colCurrencyCate";
            this.colCurrencyCate.Visible = true;
            this.colCurrencyCate.VisibleIndex = 1;
            this.colCurrencyCate.Width = 80;
            // 
            // repLookUpCurrencyCate
            // 
            this.repLookUpCurrencyCate.AutoHeight = false;
            this.repLookUpCurrencyCate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpCurrencyCate.DisplayMember = "CurrencyCateName";
            this.repLookUpCurrencyCate.Name = "repLookUpCurrencyCate";
            this.repLookUpCurrencyCate.NullText = "";
            this.repLookUpCurrencyCate.ValueMember = "AutoId";
            // 
            // colUnit
            // 
            this.colUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 2;
            this.colUnit.Width = 100;
            // 
            // colRemark
            // 
            this.colRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 3;
            this.colRemark.Width = 120;
            // 
            // colCreator
            // 
            this.colCreator.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreator.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreator.ColumnEdit = this.repLookUpCreator;
            this.colCreator.FieldName = "Creator";
            this.colCreator.Name = "colCreator";
            this.colCreator.Visible = true;
            this.colCreator.VisibleIndex = 4;
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
            this.colModifier.Visible = true;
            this.colModifier.VisibleIndex = 5;
            // 
            // colModifierTime
            // 
            this.colModifierTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colModifierTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifierTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colModifierTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colModifierTime.FieldName = "ModifierTime";
            this.colModifierTime.Name = "colModifierTime";
            this.colModifierTime.Visible = true;
            this.colModifierTime.VisibleIndex = 6;
            this.colModifierTime.Width = 135;
            // 
            // FrmPriceInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(683, 546);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "FrmPriceInfo";
            this.TabText = "供应商价格信息";
            this.Text = "供应商价格信息";
            this.Load += new System.EventHandler(this.FrmPriceInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSPriceInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePriceInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSPriceInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCurrencyCate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpBussinessBaseNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpBussinessBaseNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlPriceInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPriceInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpBussinessBaseNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCurrencyCate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dSPriceInfo;
        private System.Data.DataTable TablePriceInfo;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColBussinessBaseNo;
        private System.Data.DataColumn dataColCodeId;
        private System.Data.DataColumn dataColCurrencyCate;
        private System.Data.DataColumn dataColUnit;
        private System.Data.DataColumn dataColCreator;
        private System.Windows.Forms.BindingSource bSPriceInfo;
        private System.Data.DataColumn dataColCreatorIp;
        private System.Data.DataColumn dataColModifier;
        private System.Data.DataColumn dataColModifierIp;
        private System.Data.DataColumn dataColModifierTime;
        private System.Data.DataColumn dataColRemark;
        private DevExpress.XtraEditors.PanelControl pnlToolBar;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.LabelControl labCurrencyCate;
        private DevExpress.XtraEditors.TextEdit textRemark;
        private DevExpress.XtraEditors.LabelControl labRemark;
        private DevExpress.XtraEditors.LabelControl labUnit;
        private DevExpress.XtraEditors.LabelControl labBussinessBaseNo;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl gridCrlPriceInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPriceInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colBussinessBaseNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeId;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCate;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colModifier;
        private DevExpress.XtraGrid.Columns.GridColumn colModifierTime;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpBussinessBaseNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpBussinessBaseNoView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBussinessBaseNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBussinessBaseText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBussinessCategoryText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAutoId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator;
        private DevExpress.XtraEditors.LookUpEdit lookUpCurrencyCate;
        private DevExpress.XtraEditors.SpinEdit spinUnit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpBussinessBaseNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCurrencyCate;
    }
}