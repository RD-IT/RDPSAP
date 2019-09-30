namespace PSAP.VIEW.BSVIEW
{
    partial class FrmListDesignBomWorkProcess
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
            this.bindingSource_DesignBom = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_DesignBom = new System.Data.DataSet();
            this.TableDesignBom = new System.Data.DataTable();
            this.coluAutoId = new System.Data.DataColumn();
            this.coluSalesOrderNo = new System.Data.DataColumn();
            this.coluMaterielNo = new System.Data.DataColumn();
            this.coluCodeFileName = new System.Data.DataColumn();
            this.coluCodeName = new System.Data.DataColumn();
            this.coluPbBomNo = new System.Data.DataColumn();
            this.coluIsUse = new System.Data.DataColumn();
            this.coluTotalQty = new System.Data.DataColumn();
            this.coluRemainQty = new System.Data.DataColumn();
            this.coluHasLevel = new System.Data.DataColumn();
            this.ColuQty = new System.Data.DataColumn();
            this.ColuIsMaterial = new System.Data.DataColumn();
            this.ColuCodeAutoId = new System.Data.DataColumn();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.pnlRightTop = new DevExpress.XtraEditors.PanelControl();
            this.labCodeId = new DevExpress.XtraEditors.LabelControl();
            this.spinCodeId = new DevExpress.XtraEditors.SpinEdit();
            this.labWorkProcessQty = new DevExpress.XtraEditors.LabelControl();
            this.spinWorkProcessQty = new DevExpress.XtraEditors.SpinEdit();
            this.textWorkProcessNo = new DevExpress.XtraEditors.TextEdit();
            this.labWorkProcessNo = new DevExpress.XtraEditors.LabelControl();
            this.textCodeName = new DevExpress.XtraEditors.TextEdit();
            this.labCodeName = new DevExpress.XtraEditors.LabelControl();
            this.textCodeFileName = new DevExpress.XtraEditors.TextEdit();
            this.labCodeFileName = new DevExpress.XtraEditors.LabelControl();
            this.textPbBomNo = new DevExpress.XtraEditors.TextEdit();
            this.labPbBomNo = new DevExpress.XtraEditors.LabelControl();
            this.textSalesOrderNo = new DevExpress.XtraEditors.TextEdit();
            this.labSalesOrderNo = new DevExpress.XtraEditors.LabelControl();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.gridCrlWorkProcess = new DevExpress.XtraGrid.GridControl();
            this.bSWorkProcess = new System.Windows.Forms.BindingSource(this.components);
            this.dSWorkProcess = new System.Data.DataSet();
            this.TableWorkProcess = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColWorkProcessNo = new System.Data.DataColumn();
            this.dataColWorkProcessText = new System.Data.DataColumn();
            this.dataColIsBuy = new System.Data.DataColumn();
            this.dataColRemark = new System.Data.DataColumn();
            this.gridViewWorkProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkProcessNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkProcessText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBuy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckIsBuy = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.textCommon = new DevExpress.XtraEditors.TextEdit();
            this.labCommon = new DevExpress.XtraEditors.LabelControl();
            this.pnlCondition = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_DesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRightTop)).BeginInit();
            this.pnlRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinCodeId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinWorkProcessQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWorkProcessNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCodeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCodeFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPbBomNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSalesOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlWorkProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSWorkProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSWorkProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWorkProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWorkProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            this.SuspendLayout();
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
            this.TableDesignBom});
            // 
            // TableDesignBom
            // 
            this.TableDesignBom.Columns.AddRange(new System.Data.DataColumn[] {
            this.coluAutoId,
            this.coluSalesOrderNo,
            this.coluMaterielNo,
            this.coluCodeFileName,
            this.coluCodeName,
            this.coluPbBomNo,
            this.coluIsUse,
            this.coluTotalQty,
            this.coluRemainQty,
            this.coluHasLevel,
            this.ColuQty,
            this.ColuIsMaterial,
            this.ColuCodeAutoId});
            this.TableDesignBom.TableName = "DesignBom";
            // 
            // coluAutoId
            // 
            this.coluAutoId.ColumnName = "AutoId";
            this.coluAutoId.DataType = typeof(int);
            // 
            // coluSalesOrderNo
            // 
            this.coluSalesOrderNo.Caption = "销售订单";
            this.coluSalesOrderNo.ColumnName = "SalesOrderNo";
            // 
            // coluMaterielNo
            // 
            this.coluMaterielNo.Caption = "父级零件编号";
            this.coluMaterielNo.ColumnName = "MaterielNo";
            // 
            // coluCodeFileName
            // 
            this.coluCodeFileName.Caption = "零件编号";
            this.coluCodeFileName.ColumnName = "CodeFileName";
            // 
            // coluCodeName
            // 
            this.coluCodeName.Caption = "零件名称";
            this.coluCodeName.ColumnName = "CodeName";
            // 
            // coluPbBomNo
            // 
            this.coluPbBomNo.Caption = "制作BOM编号";
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
            // ColuQty
            // 
            this.ColuQty.Caption = "数量";
            this.ColuQty.ColumnName = "Qty";
            this.ColuQty.DataType = typeof(double);
            // 
            // ColuIsMaterial
            // 
            this.ColuIsMaterial.Caption = "零件";
            this.ColuIsMaterial.ColumnName = "IsMaterial";
            this.ColuIsMaterial.DataType = typeof(short);
            // 
            // ColuCodeAutoId
            // 
            this.ColuCodeAutoId.Caption = "零件Id";
            this.ColuCodeAutoId.ColumnName = "CodeAutoId";
            this.ColuCodeAutoId.DataType = typeof(int);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.BtnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 405);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(704, 36);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(615, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(534, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 10;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // pnlRightTop
            // 
            this.pnlRightTop.Controls.Add(this.labCodeId);
            this.pnlRightTop.Controls.Add(this.spinCodeId);
            this.pnlRightTop.Controls.Add(this.labWorkProcessQty);
            this.pnlRightTop.Controls.Add(this.spinWorkProcessQty);
            this.pnlRightTop.Controls.Add(this.textWorkProcessNo);
            this.pnlRightTop.Controls.Add(this.labWorkProcessNo);
            this.pnlRightTop.Controls.Add(this.textCodeName);
            this.pnlRightTop.Controls.Add(this.labCodeName);
            this.pnlRightTop.Controls.Add(this.textCodeFileName);
            this.pnlRightTop.Controls.Add(this.labCodeFileName);
            this.pnlRightTop.Controls.Add(this.textPbBomNo);
            this.pnlRightTop.Controls.Add(this.labPbBomNo);
            this.pnlRightTop.Controls.Add(this.textSalesOrderNo);
            this.pnlRightTop.Controls.Add(this.labSalesOrderNo);
            this.pnlRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRightTop.Location = new System.Drawing.Point(0, 0);
            this.pnlRightTop.Name = "pnlRightTop";
            this.pnlRightTop.Size = new System.Drawing.Size(704, 124);
            this.pnlRightTop.TabIndex = 0;
            // 
            // labCodeId
            // 
            this.labCodeId.Location = new System.Drawing.Point(28, 152);
            this.labCodeId.Name = "labCodeId";
            this.labCodeId.Size = new System.Drawing.Size(48, 14);
            this.labCodeId.TabIndex = 114;
            this.labCodeId.Text = "零件编号";
            // 
            // spinCodeId
            // 
            this.spinCodeId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_DesignBom, "CodeAutoId", true));
            this.spinCodeId.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinCodeId.Location = new System.Drawing.Point(95, 149);
            this.spinCodeId.Name = "spinCodeId";
            this.spinCodeId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinCodeId.Properties.Mask.EditMask = "d";
            this.spinCodeId.Properties.ReadOnly = true;
            this.spinCodeId.Size = new System.Drawing.Size(100, 20);
            this.spinCodeId.TabIndex = 113;
            // 
            // labWorkProcessQty
            // 
            this.labWorkProcessQty.Location = new System.Drawing.Point(315, 86);
            this.labWorkProcessQty.Name = "labWorkProcessQty";
            this.labWorkProcessQty.Size = new System.Drawing.Size(48, 14);
            this.labWorkProcessQty.TabIndex = 112;
            this.labWorkProcessQty.Text = "工序数量";
            // 
            // spinWorkProcessQty
            // 
            this.spinWorkProcessQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinWorkProcessQty.EnterMoveNextControl = true;
            this.spinWorkProcessQty.Location = new System.Drawing.Point(401, 83);
            this.spinWorkProcessQty.Name = "spinWorkProcessQty";
            this.spinWorkProcessQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinWorkProcessQty.Properties.MaxValue = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.spinWorkProcessQty.Size = new System.Drawing.Size(180, 20);
            this.spinWorkProcessQty.TabIndex = 5;
            // 
            // textWorkProcessNo
            // 
            this.textWorkProcessNo.EnterMoveNextControl = true;
            this.textWorkProcessNo.Location = new System.Drawing.Point(95, 83);
            this.textWorkProcessNo.Name = "textWorkProcessNo";
            this.textWorkProcessNo.Properties.ReadOnly = true;
            this.textWorkProcessNo.Size = new System.Drawing.Size(180, 20);
            this.textWorkProcessNo.TabIndex = 4;
            this.textWorkProcessNo.TabStop = false;
            // 
            // labWorkProcessNo
            // 
            this.labWorkProcessNo.Location = new System.Drawing.Point(28, 86);
            this.labWorkProcessNo.Name = "labWorkProcessNo";
            this.labWorkProcessNo.Size = new System.Drawing.Size(48, 14);
            this.labWorkProcessNo.TabIndex = 110;
            this.labWorkProcessNo.Text = "工序编号";
            // 
            // textCodeName
            // 
            this.textCodeName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_DesignBom, "CodeName", true));
            this.textCodeName.EnterMoveNextControl = true;
            this.textCodeName.Location = new System.Drawing.Point(401, 53);
            this.textCodeName.Name = "textCodeName";
            this.textCodeName.Properties.ReadOnly = true;
            this.textCodeName.Size = new System.Drawing.Size(180, 20);
            this.textCodeName.TabIndex = 3;
            this.textCodeName.TabStop = false;
            // 
            // labCodeName
            // 
            this.labCodeName.Location = new System.Drawing.Point(315, 56);
            this.labCodeName.Name = "labCodeName";
            this.labCodeName.Size = new System.Drawing.Size(48, 14);
            this.labCodeName.TabIndex = 108;
            this.labCodeName.Text = "零件名称";
            // 
            // textCodeFileName
            // 
            this.textCodeFileName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_DesignBom, "CodeFileName", true));
            this.textCodeFileName.EnterMoveNextControl = true;
            this.textCodeFileName.Location = new System.Drawing.Point(95, 53);
            this.textCodeFileName.Name = "textCodeFileName";
            this.textCodeFileName.Properties.ReadOnly = true;
            this.textCodeFileName.Size = new System.Drawing.Size(180, 20);
            this.textCodeFileName.TabIndex = 2;
            this.textCodeFileName.TabStop = false;
            // 
            // labCodeFileName
            // 
            this.labCodeFileName.Location = new System.Drawing.Point(28, 56);
            this.labCodeFileName.Name = "labCodeFileName";
            this.labCodeFileName.Size = new System.Drawing.Size(48, 14);
            this.labCodeFileName.TabIndex = 106;
            this.labCodeFileName.Text = "零件编号";
            // 
            // textPbBomNo
            // 
            this.textPbBomNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_DesignBom, "PbBomNo", true));
            this.textPbBomNo.EnterMoveNextControl = true;
            this.textPbBomNo.Location = new System.Drawing.Point(401, 23);
            this.textPbBomNo.Name = "textPbBomNo";
            this.textPbBomNo.Properties.ReadOnly = true;
            this.textPbBomNo.Size = new System.Drawing.Size(180, 20);
            this.textPbBomNo.TabIndex = 1;
            this.textPbBomNo.TabStop = false;
            // 
            // labPbBomNo
            // 
            this.labPbBomNo.Location = new System.Drawing.Point(315, 26);
            this.labPbBomNo.Name = "labPbBomNo";
            this.labPbBomNo.Size = new System.Drawing.Size(72, 14);
            this.labPbBomNo.TabIndex = 104;
            this.labPbBomNo.Text = "制作Bom编号";
            // 
            // textSalesOrderNo
            // 
            this.textSalesOrderNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource_DesignBom, "SalesOrderNo", true));
            this.textSalesOrderNo.EnterMoveNextControl = true;
            this.textSalesOrderNo.Location = new System.Drawing.Point(95, 23);
            this.textSalesOrderNo.Name = "textSalesOrderNo";
            this.textSalesOrderNo.Properties.ReadOnly = true;
            this.textSalesOrderNo.Size = new System.Drawing.Size(180, 20);
            this.textSalesOrderNo.TabIndex = 0;
            this.textSalesOrderNo.TabStop = false;
            // 
            // labSalesOrderNo
            // 
            this.labSalesOrderNo.Location = new System.Drawing.Point(28, 26);
            this.labSalesOrderNo.Name = "labSalesOrderNo";
            this.labSalesOrderNo.Size = new System.Drawing.Size(48, 14);
            this.labSalesOrderNo.TabIndex = 3;
            this.labSalesOrderNo.Text = "销售单号";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.gridCrlWorkProcess);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 161);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(704, 244);
            this.pnlMiddle.TabIndex = 5;
            // 
            // gridCrlWorkProcess
            // 
            this.gridCrlWorkProcess.DataSource = this.bSWorkProcess;
            this.gridCrlWorkProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlWorkProcess.Location = new System.Drawing.Point(2, 2);
            this.gridCrlWorkProcess.MainView = this.gridViewWorkProcess;
            this.gridCrlWorkProcess.Name = "gridCrlWorkProcess";
            this.gridCrlWorkProcess.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckIsBuy});
            this.gridCrlWorkProcess.Size = new System.Drawing.Size(700, 240);
            this.gridCrlWorkProcess.TabIndex = 50;
            this.gridCrlWorkProcess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWorkProcess});
            // 
            // bSWorkProcess
            // 
            this.bSWorkProcess.DataMember = "WorkProcess";
            this.bSWorkProcess.DataSource = this.dSWorkProcess;
            // 
            // dSWorkProcess
            // 
            this.dSWorkProcess.DataSetName = "NewDataSet";
            this.dSWorkProcess.Tables.AddRange(new System.Data.DataTable[] {
            this.TableWorkProcess});
            // 
            // TableWorkProcess
            // 
            this.TableWorkProcess.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColWorkProcessNo,
            this.dataColWorkProcessText,
            this.dataColIsBuy,
            this.dataColRemark});
            this.TableWorkProcess.TableName = "WorkProcess";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(System.Guid);
            // 
            // dataColWorkProcessNo
            // 
            this.dataColWorkProcessNo.Caption = "工序编号";
            this.dataColWorkProcessNo.ColumnName = "WorkProcessNo";
            // 
            // dataColWorkProcessText
            // 
            this.dataColWorkProcessText.Caption = "工序名称";
            this.dataColWorkProcessText.ColumnName = "WorkProcessText";
            // 
            // dataColIsBuy
            // 
            this.dataColIsBuy.Caption = "是否购买";
            this.dataColIsBuy.ColumnName = "IsBuy";
            this.dataColIsBuy.DataType = typeof(short);
            // 
            // dataColRemark
            // 
            this.dataColRemark.Caption = "备注";
            this.dataColRemark.ColumnName = "Remark";
            // 
            // gridViewWorkProcess
            // 
            this.gridViewWorkProcess.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colWorkProcessNo,
            this.colWorkProcessText,
            this.colIsBuy,
            this.colRemark});
            this.gridViewWorkProcess.GridControl = this.gridCrlWorkProcess;
            this.gridViewWorkProcess.IndicatorWidth = 40;
            this.gridViewWorkProcess.Name = "gridViewWorkProcess";
            this.gridViewWorkProcess.OptionsBehavior.Editable = false;
            this.gridViewWorkProcess.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewWorkProcess.OptionsView.ColumnAutoWidth = false;
            this.gridViewWorkProcess.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewWorkProcess.OptionsView.ShowFooter = true;
            this.gridViewWorkProcess.OptionsView.ShowGroupPanel = false;
            this.gridViewWorkProcess.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewWorkProcess_RowClick);
            this.gridViewWorkProcess.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewWorkProcess_CustomDrawRowIndicator);
            this.gridViewWorkProcess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewWorkProcess_KeyDown);
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colWorkProcessNo
            // 
            this.colWorkProcessNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colWorkProcessNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWorkProcessNo.Caption = "工序编号";
            this.colWorkProcessNo.FieldName = "WorkProcessNo";
            this.colWorkProcessNo.Name = "colWorkProcessNo";
            this.colWorkProcessNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProjectNo", "共计{0}条")});
            this.colWorkProcessNo.Visible = true;
            this.colWorkProcessNo.VisibleIndex = 0;
            this.colWorkProcessNo.Width = 150;
            // 
            // colWorkProcessText
            // 
            this.colWorkProcessText.AppearanceHeader.Options.UseTextOptions = true;
            this.colWorkProcessText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWorkProcessText.Caption = "工序名称";
            this.colWorkProcessText.FieldName = "WorkProcessText";
            this.colWorkProcessText.Name = "colWorkProcessText";
            this.colWorkProcessText.Visible = true;
            this.colWorkProcessText.VisibleIndex = 1;
            this.colWorkProcessText.Width = 180;
            // 
            // colIsBuy
            // 
            this.colIsBuy.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsBuy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsBuy.Caption = "是否购买";
            this.colIsBuy.ColumnEdit = this.repCheckIsBuy;
            this.colIsBuy.FieldName = "IsBuy";
            this.colIsBuy.Name = "colIsBuy";
            this.colIsBuy.Visible = true;
            this.colIsBuy.VisibleIndex = 2;
            this.colIsBuy.Width = 80;
            // 
            // repCheckIsBuy
            // 
            this.repCheckIsBuy.AutoHeight = false;
            this.repCheckIsBuy.DisplayValueChecked = "1";
            this.repCheckIsBuy.DisplayValueGrayed = "0";
            this.repCheckIsBuy.DisplayValueUnchecked = "0";
            this.repCheckIsBuy.Name = "repCheckIsBuy";
            this.repCheckIsBuy.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckIsBuy.ValueChecked = ((short)(1));
            this.repCheckIsBuy.ValueGrayed = ((short)(0));
            this.repCheckIsBuy.ValueUnchecked = ((short)(0));
            // 
            // colRemark
            // 
            this.colRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 3;
            this.colRemark.Width = 220;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(303, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 211;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // textCommon
            // 
            this.textCommon.EnterMoveNextControl = true;
            this.textCommon.Location = new System.Drawing.Point(95, 8);
            this.textCommon.Name = "textCommon";
            this.textCommon.Size = new System.Drawing.Size(180, 20);
            this.textCommon.TabIndex = 210;
            // 
            // labCommon
            // 
            this.labCommon.Location = new System.Drawing.Point(28, 11);
            this.labCommon.Name = "labCommon";
            this.labCommon.Size = new System.Drawing.Size(60, 14);
            this.labCommon.TabIndex = 115;
            this.labCommon.Text = "通用查询：";
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.btnQuery);
            this.pnlCondition.Controls.Add(this.labCommon);
            this.pnlCondition.Controls.Add(this.textCommon);
            this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCondition.Location = new System.Drawing.Point(0, 124);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(704, 37);
            this.pnlCondition.TabIndex = 3;
            // 
            // FrmListDesignBomWorkProcess
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlCondition);
            this.Controls.Add(this.pnlRightTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListDesignBomWorkProcess";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "登记工序信息";
            this.Text = "登记工序信息";
            this.Load += new System.EventHandler(this.FrmListDesignBomWorkProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_DesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlRightTop)).EndInit();
            this.pnlRightTop.ResumeLayout(false);
            this.pnlRightTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinCodeId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinWorkProcessQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWorkProcessNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCodeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCodeFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPbBomNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSalesOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlWorkProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSWorkProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSWorkProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWorkProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWorkProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCommon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource_DesignBom;
        public System.Data.DataSet dataSet_DesignBom;
        private System.Data.DataTable TableDesignBom;
        private System.Data.DataColumn coluAutoId;
        private System.Data.DataColumn coluSalesOrderNo;
        private System.Data.DataColumn coluMaterielNo;
        private System.Data.DataColumn coluCodeFileName;
        private System.Data.DataColumn coluCodeName;
        private System.Data.DataColumn coluPbBomNo;
        private System.Data.DataColumn coluIsUse;
        private System.Data.DataColumn coluTotalQty;
        private System.Data.DataColumn coluRemainQty;
        private System.Data.DataColumn coluHasLevel;
        private System.Data.DataColumn ColuQty;
        private System.Data.DataColumn ColuIsMaterial;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
        private DevExpress.XtraEditors.PanelControl pnlRightTop;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraGrid.GridControl gridCrlWorkProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWorkProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkProcessNo;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkProcessText;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBuy;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckIsBuy;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraEditors.LabelControl labSalesOrderNo;
        private DevExpress.XtraEditors.TextEdit textSalesOrderNo;
        private DevExpress.XtraEditors.TextEdit textPbBomNo;
        private DevExpress.XtraEditors.LabelControl labPbBomNo;
        private DevExpress.XtraEditors.TextEdit textCodeName;
        private DevExpress.XtraEditors.LabelControl labCodeName;
        private DevExpress.XtraEditors.TextEdit textCodeFileName;
        private DevExpress.XtraEditors.LabelControl labCodeFileName;
        private DevExpress.XtraEditors.TextEdit textWorkProcessNo;
        private DevExpress.XtraEditors.LabelControl labWorkProcessNo;
        private DevExpress.XtraEditors.LabelControl labWorkProcessQty;
        public DevExpress.XtraEditors.SpinEdit spinWorkProcessQty;
        private System.Windows.Forms.BindingSource bSWorkProcess;
        private System.Data.DataSet dSWorkProcess;
        private System.Data.DataTable TableWorkProcess;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColWorkProcessNo;
        private System.Data.DataColumn dataColWorkProcessText;
        private System.Data.DataColumn dataColIsBuy;
        private System.Data.DataColumn dataColRemark;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.TextEdit textCommon;
        private DevExpress.XtraEditors.LabelControl labCommon;
        private DevExpress.XtraEditors.PanelControl pnlCondition;
        private DevExpress.XtraEditors.LabelControl labCodeId;
        private DevExpress.XtraEditors.SpinEdit spinCodeId;
        private System.Data.DataColumn ColuCodeAutoId;
    }
}