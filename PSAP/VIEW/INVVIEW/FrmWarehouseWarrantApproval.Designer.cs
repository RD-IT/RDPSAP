﻿namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWarehouseWarrantApproval
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
            this.lookUpApprovalType = new DevExpress.XtraEditors.LookUpEdit();
            this.bsWWHead = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_WW = new System.Data.DataSet();
            this.dataTableWWHead = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColWarehouseWarrant = new System.Data.DataColumn();
            this.dataColWarehouseWarrantDate = new System.Data.DataColumn();
            this.dataColBussinessBaseNo = new System.Data.DataColumn();
            this.dataColOrderHeadNo = new System.Data.DataColumn();
            this.dataColRepertoryId = new System.Data.DataColumn();
            this.dataColWarehouseWarrantTypeNo = new System.Data.DataColumn();
            this.dataColPrepared = new System.Data.DataColumn();
            this.dataColPreparedIp = new System.Data.DataColumn();
            this.dataColumnRemark = new System.Data.DataColumn();
            this.dataColApprovalType = new System.Data.DataColumn();
            this.dataColModifier = new System.Data.DataColumn();
            this.dataColModifierIp = new System.Data.DataColumn();
            this.dataColModifierTime = new System.Data.DataColumn();
            this.dataColWarehouseState = new System.Data.DataColumn();
            this.dataColSelect = new System.Data.DataColumn();
            this.dataColApprovalCat = new System.Data.DataColumn();
            this.TableWarehouseApprovalInfo = new System.Data.DataTable();
            this.dataColAutoId1 = new System.Data.DataColumn();
            this.dataColTypeNo = new System.Data.DataColumn();
            this.dataColTypeNoText = new System.Data.DataColumn();
            this.dataColAppSequence = new System.Data.DataColumn();
            this.dataColApprover = new System.Data.DataColumn();
            this.dataColEmpName = new System.Data.DataColumn();
            this.dataColLoginId = new System.Data.DataColumn();
            this.dataColumnWarehouseWarrant = new System.Data.DataColumn();
            this.dataColApproverTime = new System.Data.DataColumn();
            this.textApprovalCat = new DevExpress.XtraEditors.TextEdit();
            this.textReqState = new DevExpress.XtraEditors.TextEdit();
            this.textOrderHeadNo = new DevExpress.XtraEditors.TextEdit();
            this.labApprovalCat = new DevExpress.XtraEditors.LabelControl();
            this.labApprovalType = new DevExpress.XtraEditors.LabelControl();
            this.labReqState = new DevExpress.XtraEditors.LabelControl();
            this.labOrderHeadNo = new DevExpress.XtraEditors.LabelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnApproval = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.gridCrlWWAppInfo = new DevExpress.XtraGrid.GridControl();
            this.bsWWApprovalInfo = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewWWAppInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeNoText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppSequence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApprover = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoginId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderHeadNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApproverTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCxrkdxxcwqcxcz = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpApprovalType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWWHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_WW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableWWHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWarehouseApprovalInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textApprovalCat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textReqState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOrderHeadNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlWWAppInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWWApprovalInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWWAppInfo)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lookUpApprovalType);
            this.pnlTop.Controls.Add(this.textApprovalCat);
            this.pnlTop.Controls.Add(this.textReqState);
            this.pnlTop.Controls.Add(this.textOrderHeadNo);
            this.pnlTop.Controls.Add(this.labApprovalCat);
            this.pnlTop.Controls.Add(this.labApprovalType);
            this.pnlTop.Controls.Add(this.labReqState);
            this.pnlTop.Controls.Add(this.labOrderHeadNo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(584, 89);
            this.pnlTop.TabIndex = 5;
            // 
            // lookUpApprovalType
            // 
            this.lookUpApprovalType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsWWHead, "ApprovalType", true));
            this.lookUpApprovalType.EnterMoveNextControl = true;
            this.lookUpApprovalType.Location = new System.Drawing.Point(95, 53);
            this.lookUpApprovalType.Name = "lookUpApprovalType";
            this.lookUpApprovalType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpApprovalType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeNo", "TypeNo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeNoText", "TypeNoText")});
            this.lookUpApprovalType.Properties.DisplayMember = "TypeNoText";
            this.lookUpApprovalType.Properties.NullText = "";
            this.lookUpApprovalType.Properties.ReadOnly = true;
            this.lookUpApprovalType.Properties.ValueMember = "TypeNo";
            this.lookUpApprovalType.Size = new System.Drawing.Size(120, 20);
            this.lookUpApprovalType.TabIndex = 2;
            // 
            // bsWWHead
            // 
            this.bsWWHead.DataMember = "WWHead";
            this.bsWWHead.DataSource = this.dataSet_WW;
            // 
            // dataSet_WW
            // 
            this.dataSet_WW.DataSetName = "NewDataSet";
            this.dataSet_WW.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableWWHead,
            this.TableWarehouseApprovalInfo});
            // 
            // dataTableWWHead
            // 
            this.dataTableWWHead.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColWarehouseWarrant,
            this.dataColWarehouseWarrantDate,
            this.dataColBussinessBaseNo,
            this.dataColOrderHeadNo,
            this.dataColRepertoryId,
            this.dataColWarehouseWarrantTypeNo,
            this.dataColPrepared,
            this.dataColPreparedIp,
            this.dataColumnRemark,
            this.dataColApprovalType,
            this.dataColModifier,
            this.dataColModifierIp,
            this.dataColModifierTime,
            this.dataColWarehouseState,
            this.dataColSelect,
            this.dataColApprovalCat});
            this.dataTableWWHead.TableName = "WWHead";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColWarehouseWarrant
            // 
            this.dataColWarehouseWarrant.Caption = "入库单号";
            this.dataColWarehouseWarrant.ColumnName = "WarehouseWarrant";
            // 
            // dataColWarehouseWarrantDate
            // 
            this.dataColWarehouseWarrantDate.Caption = "入库日期";
            this.dataColWarehouseWarrantDate.ColumnName = "WarehouseWarrantDate";
            this.dataColWarehouseWarrantDate.DataType = typeof(System.DateTime);
            // 
            // dataColBussinessBaseNo
            // 
            this.dataColBussinessBaseNo.Caption = "供应商";
            this.dataColBussinessBaseNo.ColumnName = "BussinessBaseNo";
            // 
            // dataColOrderHeadNo
            // 
            this.dataColOrderHeadNo.Caption = "采购订单号";
            this.dataColOrderHeadNo.ColumnName = "OrderHeadNo";
            // 
            // dataColRepertoryId
            // 
            this.dataColRepertoryId.Caption = "入库仓库";
            this.dataColRepertoryId.ColumnName = "RepertoryId";
            this.dataColRepertoryId.DataType = typeof(int);
            // 
            // dataColWarehouseWarrantTypeNo
            // 
            this.dataColWarehouseWarrantTypeNo.Caption = "入库类别";
            this.dataColWarehouseWarrantTypeNo.ColumnName = "WarehouseWarrantTypeNo";
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
            // dataColumnRemark
            // 
            this.dataColumnRemark.Caption = "备注";
            this.dataColumnRemark.ColumnName = "Remark";
            // 
            // dataColApprovalType
            // 
            this.dataColApprovalType.Caption = "审核类型";
            this.dataColApprovalType.ColumnName = "ApprovalType";
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
            // dataColWarehouseState
            // 
            this.dataColWarehouseState.Caption = "状态";
            this.dataColWarehouseState.ColumnName = "WarehouseState";
            this.dataColWarehouseState.DataType = typeof(int);
            // 
            // dataColSelect
            // 
            this.dataColSelect.Caption = "";
            this.dataColSelect.ColumnName = "Select";
            this.dataColSelect.DataType = typeof(bool);
            // 
            // dataColApprovalCat
            // 
            this.dataColApprovalCat.Caption = "审批方式";
            this.dataColApprovalCat.ColumnName = "ApprovalCat";
            this.dataColApprovalCat.DataType = typeof(int);
            // 
            // TableWarehouseApprovalInfo
            // 
            this.TableWarehouseApprovalInfo.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId1,
            this.dataColTypeNo,
            this.dataColTypeNoText,
            this.dataColAppSequence,
            this.dataColApprover,
            this.dataColEmpName,
            this.dataColLoginId,
            this.dataColumnWarehouseWarrant,
            this.dataColApproverTime});
            this.TableWarehouseApprovalInfo.TableName = "OrderApprovalInfo";
            // 
            // dataColAutoId1
            // 
            this.dataColAutoId1.ColumnName = "AutoId";
            this.dataColAutoId1.DataType = typeof(int);
            // 
            // dataColTypeNo
            // 
            this.dataColTypeNo.Caption = "类型编码";
            this.dataColTypeNo.ColumnName = "TypeNo";
            // 
            // dataColTypeNoText
            // 
            this.dataColTypeNoText.Caption = "审批名称";
            this.dataColTypeNoText.ColumnName = "TypeNoText";
            // 
            // dataColAppSequence
            // 
            this.dataColAppSequence.Caption = "审批顺序";
            this.dataColAppSequence.ColumnName = "AppSequence";
            this.dataColAppSequence.DataType = typeof(int);
            // 
            // dataColApprover
            // 
            this.dataColApprover.Caption = "审批用户AutoId";
            this.dataColApprover.ColumnName = "Approver";
            this.dataColApprover.DataType = typeof(int);
            // 
            // dataColEmpName
            // 
            this.dataColEmpName.Caption = "员工名字";
            this.dataColEmpName.ColumnName = "EmpName";
            // 
            // dataColLoginId
            // 
            this.dataColLoginId.Caption = "用户名";
            this.dataColLoginId.ColumnName = "LoginId";
            // 
            // dataColumnWarehouseWarrant
            // 
            this.dataColumnWarehouseWarrant.Caption = "入库单号";
            this.dataColumnWarehouseWarrant.ColumnName = "WarehouseWarrant";
            // 
            // dataColApproverTime
            // 
            this.dataColApproverTime.Caption = "审批时间";
            this.dataColApproverTime.ColumnName = "ApproverTime";
            this.dataColApproverTime.DataType = typeof(System.DateTime);
            // 
            // textApprovalCat
            // 
            this.textApprovalCat.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsWWHead, "ApprovalCat", true));
            this.textApprovalCat.Location = new System.Drawing.Point(312, 53);
            this.textApprovalCat.Name = "textApprovalCat";
            this.textApprovalCat.Properties.AllowFocused = false;
            this.textApprovalCat.Properties.ReadOnly = true;
            this.textApprovalCat.Size = new System.Drawing.Size(120, 20);
            this.textApprovalCat.TabIndex = 3;
            this.textApprovalCat.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.textApprovalCat_CustomDisplayText);
            // 
            // textReqState
            // 
            this.textReqState.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsWWHead, "WarehouseState", true));
            this.textReqState.Location = new System.Drawing.Point(312, 23);
            this.textReqState.Name = "textReqState";
            this.textReqState.Properties.AllowFocused = false;
            this.textReqState.Properties.ReadOnly = true;
            this.textReqState.Size = new System.Drawing.Size(120, 20);
            this.textReqState.TabIndex = 1;
            this.textReqState.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.textReqState_CustomDisplayText);
            // 
            // textOrderHeadNo
            // 
            this.textOrderHeadNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsWWHead, "WarehouseWarrant", true));
            this.textOrderHeadNo.Location = new System.Drawing.Point(95, 23);
            this.textOrderHeadNo.Name = "textOrderHeadNo";
            this.textOrderHeadNo.Properties.ReadOnly = true;
            this.textOrderHeadNo.Size = new System.Drawing.Size(120, 20);
            this.textOrderHeadNo.TabIndex = 0;
            // 
            // labApprovalCat
            // 
            this.labApprovalCat.Location = new System.Drawing.Point(239, 56);
            this.labApprovalCat.Name = "labApprovalCat";
            this.labApprovalCat.Size = new System.Drawing.Size(48, 14);
            this.labApprovalCat.TabIndex = 7;
            this.labApprovalCat.Text = "审批方式";
            // 
            // labApprovalType
            // 
            this.labApprovalType.Location = new System.Drawing.Point(28, 56);
            this.labApprovalType.Name = "labApprovalType";
            this.labApprovalType.Size = new System.Drawing.Size(48, 14);
            this.labApprovalType.TabIndex = 4;
            this.labApprovalType.Text = "审批类型";
            // 
            // labReqState
            // 
            this.labReqState.Location = new System.Drawing.Point(239, 26);
            this.labReqState.Name = "labReqState";
            this.labReqState.Size = new System.Drawing.Size(48, 14);
            this.labReqState.TabIndex = 2;
            this.labReqState.Text = "单据状态";
            // 
            // labOrderHeadNo
            // 
            this.labOrderHeadNo.Location = new System.Drawing.Point(28, 26);
            this.labOrderHeadNo.Name = "labOrderHeadNo";
            this.labOrderHeadNo.Size = new System.Drawing.Size(48, 14);
            this.labOrderHeadNo.TabIndex = 0;
            this.labOrderHeadNo.Text = "入库单号";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnApproval);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 322);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(584, 40);
            this.pnlBottom.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(497, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApproval
            // 
            this.btnApproval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproval.Location = new System.Drawing.Point(416, 8);
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.Size = new System.Drawing.Size(75, 23);
            this.btnApproval.TabIndex = 1;
            this.btnApproval.TabStop = false;
            this.btnApproval.Text = "审批";
            this.btnApproval.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.gridCrlWWAppInfo);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 89);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(584, 233);
            this.pnlMiddle.TabIndex = 8;
            // 
            // gridCrlWWAppInfo
            // 
            this.gridCrlWWAppInfo.DataSource = this.bsWWApprovalInfo;
            this.gridCrlWWAppInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlWWAppInfo.Location = new System.Drawing.Point(2, 2);
            this.gridCrlWWAppInfo.MainView = this.gridViewWWAppInfo;
            this.gridCrlWWAppInfo.Name = "gridCrlWWAppInfo";
            this.gridCrlWWAppInfo.Size = new System.Drawing.Size(580, 229);
            this.gridCrlWWAppInfo.TabIndex = 10;
            this.gridCrlWWAppInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWWAppInfo});
            // 
            // bsWWApprovalInfo
            // 
            this.bsWWApprovalInfo.DataMember = "OrderApprovalInfo";
            this.bsWWApprovalInfo.DataSource = this.dataSet_WW;
            // 
            // gridViewWWAppInfo
            // 
            this.gridViewWWAppInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colTypeNo,
            this.colTypeNoText,
            this.colAppSequence,
            this.colApprover,
            this.colEmpName,
            this.colLoginId,
            this.colOrderHeadNo,
            this.colApproverTime});
            this.gridViewWWAppInfo.GridControl = this.gridCrlWWAppInfo;
            this.gridViewWWAppInfo.IndicatorWidth = 40;
            this.gridViewWWAppInfo.Name = "gridViewWWAppInfo";
            this.gridViewWWAppInfo.OptionsBehavior.Editable = false;
            this.gridViewWWAppInfo.OptionsFilter.AllowFilterEditor = false;
            this.gridViewWWAppInfo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewWWAppInfo.OptionsView.ColumnAutoWidth = false;
            this.gridViewWWAppInfo.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewWWAppInfo.OptionsView.ShowGroupPanel = false;
            this.gridViewWWAppInfo.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewWAppInfo_CustomDrawRowIndicator);
            this.gridViewWWAppInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewWWAppInfo_KeyDown);
            // 
            // colAutoId
            // 
            this.colAutoId.AppearanceHeader.Options.UseTextOptions = true;
            this.colAutoId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colTypeNo
            // 
            this.colTypeNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colTypeNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypeNo.FieldName = "TypeNo";
            this.colTypeNo.Name = "colTypeNo";
            this.colTypeNo.Visible = true;
            this.colTypeNo.VisibleIndex = 1;
            this.colTypeNo.Width = 80;
            // 
            // colTypeNoText
            // 
            this.colTypeNoText.AppearanceHeader.Options.UseTextOptions = true;
            this.colTypeNoText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypeNoText.FieldName = "TypeNoText";
            this.colTypeNoText.Name = "colTypeNoText";
            this.colTypeNoText.Visible = true;
            this.colTypeNoText.VisibleIndex = 2;
            this.colTypeNoText.Width = 100;
            // 
            // colAppSequence
            // 
            this.colAppSequence.AppearanceHeader.Options.UseTextOptions = true;
            this.colAppSequence.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAppSequence.FieldName = "AppSequence";
            this.colAppSequence.Name = "colAppSequence";
            this.colAppSequence.Visible = true;
            this.colAppSequence.VisibleIndex = 0;
            this.colAppSequence.Width = 60;
            // 
            // colApprover
            // 
            this.colApprover.AppearanceHeader.Options.UseTextOptions = true;
            this.colApprover.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colApprover.FieldName = "Approver";
            this.colApprover.Name = "colApprover";
            // 
            // colEmpName
            // 
            this.colEmpName.AppearanceHeader.Options.UseTextOptions = true;
            this.colEmpName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmpName.FieldName = "EmpName";
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.Visible = true;
            this.colEmpName.VisibleIndex = 3;
            this.colEmpName.Width = 80;
            // 
            // colLoginId
            // 
            this.colLoginId.AppearanceHeader.Options.UseTextOptions = true;
            this.colLoginId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLoginId.FieldName = "LoginId";
            this.colLoginId.Name = "colLoginId";
            this.colLoginId.Visible = true;
            this.colLoginId.VisibleIndex = 4;
            this.colLoginId.Width = 80;
            // 
            // colOrderHeadNo
            // 
            this.colOrderHeadNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderHeadNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOrderHeadNo.FieldName = "OrderHeadNo";
            this.colOrderHeadNo.Name = "colOrderHeadNo";
            // 
            // colApproverTime
            // 
            this.colApproverTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colApproverTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colApproverTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colApproverTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colApproverTime.FieldName = "ApproverTime";
            this.colApproverTime.Name = "colApproverTime";
            this.colApproverTime.Visible = true;
            this.colApproverTime.VisibleIndex = 5;
            this.colApproverTime.Width = 135;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCxrkdxxcwqcxcz});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(269, 26);
            // 
            // tsmiCxrkdxxcwqcxcz
            // 
            this.tsmiCxrkdxxcwqcxcz.Name = "tsmiCxrkdxxcwqcxcz";
            this.tsmiCxrkdxxcwqcxcz.Size = new System.Drawing.Size(268, 22);
            this.tsmiCxrkdxxcwqcxcz.Text = "查询入库单信息错误，请重新操作。";
            // 
            // FrmWarehouseWarrantApproval
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FrmWarehouseWarrantApproval";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "审批信息";
            this.Text = "审批信息";
            this.Load += new System.EventHandler(this.FrmApprovalWarehouseWarrant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpApprovalType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWWHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_WW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableWWHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWarehouseApprovalInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textApprovalCat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textReqState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOrderHeadNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlWWAppInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWWApprovalInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWWAppInfo)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.LabelControl labApprovalCat;
        private DevExpress.XtraEditors.LookUpEdit lookUpApprovalType;
        private DevExpress.XtraEditors.TextEdit textApprovalCat;
        private DevExpress.XtraEditors.LabelControl labApprovalType;
        private DevExpress.XtraEditors.TextEdit textReqState;
        private DevExpress.XtraEditors.LabelControl labReqState;
        private DevExpress.XtraEditors.TextEdit textOrderHeadNo;
        private DevExpress.XtraEditors.LabelControl labOrderHeadNo;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnApproval;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private System.Data.DataSet dataSet_WW;
        private System.Data.DataTable dataTableWWHead;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColWarehouseWarrant;
        private System.Data.DataColumn dataColWarehouseWarrantDate;
        private System.Data.DataColumn dataColBussinessBaseNo;
        private System.Data.DataColumn dataColOrderHeadNo;
        private System.Data.DataColumn dataColRepertoryId;
        private System.Data.DataColumn dataColWarehouseWarrantTypeNo;
        private System.Data.DataColumn dataColPrepared;
        private System.Data.DataColumn dataColPreparedIp;
        private System.Data.DataColumn dataColumnRemark;
        private System.Data.DataColumn dataColApprovalType;
        private System.Data.DataColumn dataColModifier;
        private System.Data.DataColumn dataColModifierIp;
        private System.Data.DataColumn dataColModifierTime;
        private System.Data.DataColumn dataColWarehouseState;
        private System.Data.DataColumn dataColSelect;
        private System.Data.DataTable TableWarehouseApprovalInfo;
        private System.Data.DataColumn dataColAutoId1;
        private System.Data.DataColumn dataColTypeNo;
        private System.Data.DataColumn dataColTypeNoText;
        private System.Data.DataColumn dataColAppSequence;
        private System.Data.DataColumn dataColApprover;
        private System.Data.DataColumn dataColEmpName;
        private System.Data.DataColumn dataColLoginId;
        private System.Data.DataColumn dataColumnWarehouseWarrant;
        private System.Data.DataColumn dataColApproverTime;
        private DevExpress.XtraGrid.GridControl gridCrlWWAppInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWWAppInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeNoText;
        private DevExpress.XtraGrid.Columns.GridColumn colAppSequence;
        private DevExpress.XtraGrid.Columns.GridColumn colApprover;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn colLoginId;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderHeadNo;
        private DevExpress.XtraGrid.Columns.GridColumn colApproverTime;
        private System.Windows.Forms.BindingSource bsWWApprovalInfo;
        private System.Windows.Forms.BindingSource bsWWHead;
        private System.Data.DataColumn dataColApprovalCat;
        internal System.Windows.Forms.ContextMenuStrip cms;
        internal System.Windows.Forms.ToolStripMenuItem tsmiCxrkdxxcwqcxcz;
    }
}