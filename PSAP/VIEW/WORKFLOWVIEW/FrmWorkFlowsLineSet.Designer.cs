namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWorkFlowsLineSet
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
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.pnlBaseInfo = new DevExpress.XtraEditors.PanelControl();
            this.labLineType = new DevExpress.XtraEditors.LabelControl();
            this.lookUpLineType = new DevExpress.XtraEditors.LookUpEdit();
            this.labEnabled = new DevExpress.XtraEditors.LabelControl();
            this.checkEnabled = new DevExpress.XtraEditors.CheckEdit();
            this.textLineText = new DevExpress.XtraEditors.TextEdit();
            this.labLineText = new DevExpress.XtraEditors.LabelControl();
            this.TabControlLineSet = new DevExpress.XtraTab.XtraTabControl();
            this.PageBaseInfo = new DevExpress.XtraTab.XtraTabPage();
            this.PageCondition = new DevExpress.XtraTab.XtraTabPage();
            this.pnlConditionSet = new DevExpress.XtraEditors.PanelControl();
            this.pnlConditionRight = new DevExpress.XtraEditors.PanelControl();
            this.TabControlConditionOtherInfo = new DevExpress.XtraTab.XtraTabControl();
            this.PageLineHandle = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlLineHandle = new DevExpress.XtraGrid.GridControl();
            this.BSLineHandle = new System.Windows.Forms.BindingSource(this.components);
            this.dSLineCondition = new System.Data.DataSet();
            this.TableLineCondition = new System.Data.DataTable();
            this.ColAutoId = new System.Data.DataColumn();
            this.ColLineId = new System.Data.DataColumn();
            this.ColConditionText = new System.Data.DataColumn();
            this.ColCondition = new System.Data.DataColumn();
            this.ColCreator = new System.Data.DataColumn();
            this.ColGetTime = new System.Data.DataColumn();
            this.ColWorkFlowsId = new System.Data.DataColumn();
            this.TableLineHandle = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColLineId = new System.Data.DataColumn();
            this.dataColConditionId = new System.Data.DataColumn();
            this.dataColLineHandleCate = new System.Data.DataColumn();
            this.dataColHandleOwner = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColGetTime = new System.Data.DataColumn();
            this.dataColHandleName = new System.Data.DataColumn();
            this.dataColMultiLevelApprover = new System.Data.DataColumn();
            this.TableLineNotice = new System.Data.DataTable();
            this.dataColuAutoId = new System.Data.DataColumn();
            this.dataColuLineId = new System.Data.DataColumn();
            this.dataColuConditionId = new System.Data.DataColumn();
            this.dataColuLineHandleCate = new System.Data.DataColumn();
            this.dataColuHandleOwner = new System.Data.DataColumn();
            this.dataColuCreator = new System.Data.DataColumn();
            this.dataColuGetTime = new System.Data.DataColumn();
            this.dataColuHandleName = new System.Data.DataColumn();
            this.dataColuMultiLevelApprover = new System.Data.DataColumn();
            this.gridViewLineHandle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConditionId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHandleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMultiLevelApprover = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PageLineNotice = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlLineNotice = new DevExpress.XtraGrid.GridControl();
            this.BSLineNotice = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewLineNotice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHandleName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMultiLevelApprover1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlLineHandleTop = new DevExpress.XtraEditors.PanelControl();
            this.BtnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.labMultiLevelApprover = new DevExpress.XtraEditors.LabelControl();
            this.spinMultiLevelApprover = new DevExpress.XtraEditors.SpinEdit();
            this.btnHandleDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnHandleNew = new DevExpress.XtraEditors.SimpleButton();
            this.labHandleOwner = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpHandleOwner = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpHandleOwnerView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRoleNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLoginId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labHandleCate = new DevExpress.XtraEditors.LabelControl();
            this.radioHandleCate = new DevExpress.XtraEditors.RadioGroup();
            this.splitterCtlOne = new DevExpress.XtraEditors.SplitterControl();
            this.pnlConditionLeft = new DevExpress.XtraEditors.PanelControl();
            this.gridControlLineCondition = new DevExpress.XtraGrid.GridControl();
            this.bSLineCondition = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewLineCondition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConditionText1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCondition1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colGetTime1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlLeftBtnBar = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.dSCondition = new System.Data.DataSet();
            this.TableCondition = new System.Data.DataTable();
            this.dataColCondition = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColLogicType = new System.Data.DataColumn();
            this.dataColFieldName = new System.Data.DataColumn();
            this.dataColOperateType = new System.Data.DataColumn();
            this.dataColOperateValue = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBaseInfo)).BeginInit();
            this.pnlBaseInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpLineType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEnabled.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textLineText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlLineSet)).BeginInit();
            this.TabControlLineSet.SuspendLayout();
            this.PageBaseInfo.SuspendLayout();
            this.PageCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlConditionSet)).BeginInit();
            this.pnlConditionSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlConditionRight)).BeginInit();
            this.pnlConditionRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlConditionOtherInfo)).BeginInit();
            this.TabControlConditionOtherInfo.SuspendLayout();
            this.PageLineHandle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLineHandle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSLineHandle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSLineCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLineCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLineHandle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLineNotice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineHandle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator1)).BeginInit();
            this.PageLineNotice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLineNotice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSLineNotice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineNotice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineHandleTop)).BeginInit();
            this.pnlLineHandleTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinMultiLevelApprover.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpHandleOwner.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpHandleOwnerView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioHandleCate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlConditionLeft)).BeginInit();
            this.pnlConditionLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLineCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSLineCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftBtnBar)).BeginInit();
            this.pnlLeftBtnBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableCondition)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.BtnSave);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 455);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(784, 36);
            this.pnlBottom.TabIndex = 5;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(614, 7);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "确定";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(695, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "取消";
            // 
            // pnlBaseInfo
            // 
            this.pnlBaseInfo.Controls.Add(this.labLineType);
            this.pnlBaseInfo.Controls.Add(this.lookUpLineType);
            this.pnlBaseInfo.Controls.Add(this.labEnabled);
            this.pnlBaseInfo.Controls.Add(this.checkEnabled);
            this.pnlBaseInfo.Controls.Add(this.textLineText);
            this.pnlBaseInfo.Controls.Add(this.labLineText);
            this.pnlBaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBaseInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlBaseInfo.Name = "pnlBaseInfo";
            this.pnlBaseInfo.Size = new System.Drawing.Size(774, 422);
            this.pnlBaseInfo.TabIndex = 2;
            // 
            // labLineType
            // 
            this.labLineType.Location = new System.Drawing.Point(45, 83);
            this.labLineType.Name = "labLineType";
            this.labLineType.Size = new System.Drawing.Size(60, 14);
            this.labLineType.TabIndex = 22;
            this.labLineType.Text = "连接线类型";
            // 
            // lookUpLineType
            // 
            this.lookUpLineType.EnterMoveNextControl = true;
            this.lookUpLineType.Location = new System.Drawing.Point(122, 80);
            this.lookUpLineType.Name = "lookUpLineType";
            this.lookUpLineType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpLineType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeId", "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineType", "类型名称")});
            this.lookUpLineType.Properties.DisplayMember = "LineType";
            this.lookUpLineType.Properties.NullText = "";
            this.lookUpLineType.Properties.ValueMember = "TypeId";
            this.lookUpLineType.Size = new System.Drawing.Size(180, 20);
            this.lookUpLineType.TabIndex = 1;
            // 
            // labEnabled
            // 
            this.labEnabled.Location = new System.Drawing.Point(45, 125);
            this.labEnabled.Name = "labEnabled";
            this.labEnabled.Size = new System.Drawing.Size(108, 14);
            this.labEnabled.TabIndex = 20;
            this.labEnabled.Text = "启用连接线条件设定";
            // 
            // checkEnabled
            // 
            this.checkEnabled.EnterMoveNextControl = true;
            this.checkEnabled.Location = new System.Drawing.Point(203, 122);
            this.checkEnabled.Name = "checkEnabled";
            this.checkEnabled.Properties.Caption = "";
            this.checkEnabled.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkEnabled.Properties.ValueChecked = 1;
            this.checkEnabled.Properties.ValueGrayed = 0;
            this.checkEnabled.Properties.ValueUnchecked = 0;
            this.checkEnabled.Size = new System.Drawing.Size(23, 19);
            this.checkEnabled.TabIndex = 2;
            // 
            // textLineText
            // 
            this.textLineText.EnterMoveNextControl = true;
            this.textLineText.Location = new System.Drawing.Point(122, 38);
            this.textLineText.Name = "textLineText";
            this.textLineText.Size = new System.Drawing.Size(180, 20);
            this.textLineText.TabIndex = 0;
            // 
            // labLineText
            // 
            this.labLineText.Location = new System.Drawing.Point(45, 41);
            this.labLineText.Name = "labLineText";
            this.labLineText.Size = new System.Drawing.Size(60, 14);
            this.labLineText.TabIndex = 0;
            this.labLineText.Text = "连接线名称";
            // 
            // TabControlLineSet
            // 
            this.TabControlLineSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlLineSet.Location = new System.Drawing.Point(2, 2);
            this.TabControlLineSet.Name = "TabControlLineSet";
            this.TabControlLineSet.SelectedTabPage = this.PageBaseInfo;
            this.TabControlLineSet.Size = new System.Drawing.Size(780, 451);
            this.TabControlLineSet.TabIndex = 1;
            this.TabControlLineSet.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PageBaseInfo,
            this.PageCondition});
            // 
            // PageBaseInfo
            // 
            this.PageBaseInfo.Controls.Add(this.pnlBaseInfo);
            this.PageBaseInfo.Name = "PageBaseInfo";
            this.PageBaseInfo.Size = new System.Drawing.Size(774, 422);
            this.PageBaseInfo.Text = "基本信息";
            // 
            // PageCondition
            // 
            this.PageCondition.Controls.Add(this.pnlConditionSet);
            this.PageCondition.Name = "PageCondition";
            this.PageCondition.Size = new System.Drawing.Size(774, 422);
            this.PageCondition.Text = "条件设定";
            // 
            // pnlConditionSet
            // 
            this.pnlConditionSet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.pnlConditionSet.Appearance.Options.UseBackColor = true;
            this.pnlConditionSet.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlConditionSet.Controls.Add(this.pnlConditionRight);
            this.pnlConditionSet.Controls.Add(this.splitterCtlOne);
            this.pnlConditionSet.Controls.Add(this.pnlConditionLeft);
            this.pnlConditionSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConditionSet.Location = new System.Drawing.Point(0, 0);
            this.pnlConditionSet.Name = "pnlConditionSet";
            this.pnlConditionSet.Size = new System.Drawing.Size(774, 422);
            this.pnlConditionSet.TabIndex = 3;
            // 
            // pnlConditionRight
            // 
            this.pnlConditionRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlConditionRight.Controls.Add(this.TabControlConditionOtherInfo);
            this.pnlConditionRight.Controls.Add(this.pnlLineHandleTop);
            this.pnlConditionRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConditionRight.Location = new System.Drawing.Point(305, 0);
            this.pnlConditionRight.Name = "pnlConditionRight";
            this.pnlConditionRight.Size = new System.Drawing.Size(469, 422);
            this.pnlConditionRight.TabIndex = 16;
            // 
            // TabControlConditionOtherInfo
            // 
            this.TabControlConditionOtherInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlConditionOtherInfo.Location = new System.Drawing.Point(0, 131);
            this.TabControlConditionOtherInfo.Name = "TabControlConditionOtherInfo";
            this.TabControlConditionOtherInfo.SelectedTabPage = this.PageLineHandle;
            this.TabControlConditionOtherInfo.Size = new System.Drawing.Size(469, 291);
            this.TabControlConditionOtherInfo.TabIndex = 0;
            this.TabControlConditionOtherInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PageLineHandle,
            this.PageLineNotice});
            this.TabControlConditionOtherInfo.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.TabControlConditionOtherInfo_SelectedPageChanged);
            // 
            // PageLineHandle
            // 
            this.PageLineHandle.Controls.Add(this.gridControlLineHandle);
            this.PageLineHandle.Name = "PageLineHandle";
            this.PageLineHandle.Size = new System.Drawing.Size(463, 262);
            this.PageLineHandle.Text = "处理人员";
            // 
            // gridControlLineHandle
            // 
            this.gridControlLineHandle.DataSource = this.BSLineHandle;
            this.gridControlLineHandle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLineHandle.Location = new System.Drawing.Point(0, 0);
            this.gridControlLineHandle.MainView = this.gridViewLineHandle;
            this.gridControlLineHandle.Name = "gridControlLineHandle";
            this.gridControlLineHandle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpCreator1});
            this.gridControlLineHandle.Size = new System.Drawing.Size(463, 262);
            this.gridControlLineHandle.TabIndex = 6;
            this.gridControlLineHandle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLineHandle});
            // 
            // BSLineHandle
            // 
            this.BSLineHandle.DataMember = "LineHandle";
            this.BSLineHandle.DataSource = this.dSLineCondition;
            // 
            // dSLineCondition
            // 
            this.dSLineCondition.DataSetName = "NewDataSet";
            this.dSLineCondition.Tables.AddRange(new System.Data.DataTable[] {
            this.TableLineCondition,
            this.TableLineHandle,
            this.TableLineNotice});
            // 
            // TableLineCondition
            // 
            this.TableLineCondition.Columns.AddRange(new System.Data.DataColumn[] {
            this.ColAutoId,
            this.ColLineId,
            this.ColConditionText,
            this.ColCondition,
            this.ColCreator,
            this.ColGetTime,
            this.ColWorkFlowsId});
            this.TableLineCondition.TableName = "LineCondition";
            // 
            // ColAutoId
            // 
            this.ColAutoId.ColumnName = "AutoId";
            this.ColAutoId.DataType = typeof(int);
            // 
            // ColLineId
            // 
            this.ColLineId.Caption = "连接线Id";
            this.ColLineId.ColumnName = "LineId";
            this.ColLineId.DataType = typeof(int);
            // 
            // ColConditionText
            // 
            this.ColConditionText.Caption = "条件名称";
            this.ColConditionText.ColumnName = "ConditionText";
            // 
            // ColCondition
            // 
            this.ColCondition.Caption = "条件";
            this.ColCondition.ColumnName = "Condition";
            // 
            // ColCreator
            // 
            this.ColCreator.Caption = "创建人";
            this.ColCreator.ColumnName = "Creator";
            this.ColCreator.DataType = typeof(int);
            // 
            // ColGetTime
            // 
            this.ColGetTime.Caption = "创建时间";
            this.ColGetTime.ColumnName = "GetTime";
            this.ColGetTime.DataType = typeof(System.DateTime);
            // 
            // ColWorkFlowsId
            // 
            this.ColWorkFlowsId.Caption = "流程图Id";
            this.ColWorkFlowsId.ColumnName = "WorkFlowsId";
            this.ColWorkFlowsId.DataType = typeof(int);
            // 
            // TableLineHandle
            // 
            this.TableLineHandle.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColLineId,
            this.dataColConditionId,
            this.dataColLineHandleCate,
            this.dataColHandleOwner,
            this.dataColCreator,
            this.dataColGetTime,
            this.dataColHandleName,
            this.dataColMultiLevelApprover});
            this.TableLineHandle.TableName = "LineHandle";
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColLineId
            // 
            this.dataColLineId.Caption = "连接线ID";
            this.dataColLineId.ColumnName = "LineId";
            this.dataColLineId.DataType = typeof(int);
            // 
            // dataColConditionId
            // 
            this.dataColConditionId.Caption = "设定条件ID";
            this.dataColConditionId.ColumnName = "ConditionId";
            this.dataColConditionId.DataType = typeof(int);
            // 
            // dataColLineHandleCate
            // 
            this.dataColLineHandleCate.Caption = "类型";
            this.dataColLineHandleCate.ColumnName = "LineHandleCate";
            this.dataColLineHandleCate.DataType = typeof(short);
            // 
            // dataColHandleOwner
            // 
            this.dataColHandleOwner.Caption = "操作员角色编号";
            this.dataColHandleOwner.ColumnName = "HandleOwner";
            // 
            // dataColCreator
            // 
            this.dataColCreator.Caption = "创建人";
            this.dataColCreator.ColumnName = "Creator";
            this.dataColCreator.DataType = typeof(int);
            // 
            // dataColGetTime
            // 
            this.dataColGetTime.Caption = "创建时间";
            this.dataColGetTime.ColumnName = "GetTime";
            this.dataColGetTime.DataType = typeof(System.DateTime);
            // 
            // dataColHandleName
            // 
            this.dataColHandleName.Caption = "操作员角色名称";
            this.dataColHandleName.ColumnName = "HandleName";
            // 
            // dataColMultiLevelApprover
            // 
            this.dataColMultiLevelApprover.Caption = "审批级别";
            this.dataColMultiLevelApprover.ColumnName = "MultiLevelApprover";
            this.dataColMultiLevelApprover.DataType = typeof(int);
            // 
            // TableLineNotice
            // 
            this.TableLineNotice.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColuAutoId,
            this.dataColuLineId,
            this.dataColuConditionId,
            this.dataColuLineHandleCate,
            this.dataColuHandleOwner,
            this.dataColuCreator,
            this.dataColuGetTime,
            this.dataColuHandleName,
            this.dataColuMultiLevelApprover});
            this.TableLineNotice.TableName = "LineNotice";
            // 
            // dataColuAutoId
            // 
            this.dataColuAutoId.ColumnName = "AutoId";
            this.dataColuAutoId.DataType = typeof(int);
            // 
            // dataColuLineId
            // 
            this.dataColuLineId.Caption = "连接线ID";
            this.dataColuLineId.ColumnName = "LineId";
            this.dataColuLineId.DataType = typeof(int);
            // 
            // dataColuConditionId
            // 
            this.dataColuConditionId.Caption = "设定条件ID";
            this.dataColuConditionId.ColumnName = "ConditionId";
            this.dataColuConditionId.DataType = typeof(int);
            // 
            // dataColuLineHandleCate
            // 
            this.dataColuLineHandleCate.Caption = "类型";
            this.dataColuLineHandleCate.ColumnName = "LineHandleCate";
            this.dataColuLineHandleCate.DataType = typeof(short);
            // 
            // dataColuHandleOwner
            // 
            this.dataColuHandleOwner.Caption = "操作员角色编号";
            this.dataColuHandleOwner.ColumnName = "HandleOwner";
            // 
            // dataColuCreator
            // 
            this.dataColuCreator.Caption = "创建人";
            this.dataColuCreator.ColumnName = "Creator";
            this.dataColuCreator.DataType = typeof(int);
            // 
            // dataColuGetTime
            // 
            this.dataColuGetTime.Caption = "创建时间";
            this.dataColuGetTime.ColumnName = "GetTime";
            this.dataColuGetTime.DataType = typeof(System.DateTime);
            // 
            // dataColuHandleName
            // 
            this.dataColuHandleName.Caption = "操作员角色名称";
            this.dataColuHandleName.ColumnName = "HandleName";
            // 
            // dataColuMultiLevelApprover
            // 
            this.dataColuMultiLevelApprover.Caption = "审批级别";
            this.dataColuMultiLevelApprover.ColumnName = "MultiLevelApprover";
            this.dataColuMultiLevelApprover.DataType = typeof(int);
            // 
            // gridViewLineHandle
            // 
            this.gridViewLineHandle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.colConditionId,
            this.colHandleName,
            this.colMultiLevelApprover});
            this.gridViewLineHandle.GridControl = this.gridControlLineHandle;
            this.gridViewLineHandle.IndicatorWidth = 30;
            this.gridViewLineHandle.Name = "gridViewLineHandle";
            this.gridViewLineHandle.OptionsBehavior.Editable = false;
            this.gridViewLineHandle.OptionsBehavior.ReadOnly = true;
            this.gridViewLineHandle.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewLineHandle.OptionsView.ColumnAutoWidth = false;
            this.gridViewLineHandle.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewLineHandle.OptionsView.ShowGroupPanel = false;
            this.gridViewLineHandle.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewLineHandle_CustomDrawRowIndicator);
            this.gridViewLineHandle.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewLineHandle_CustomColumnDisplayText);
            this.gridViewLineHandle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewLineHandle_KeyDown);
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "AutoId";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "LineId";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.FieldName = "HandleOwner";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ConditionText", "共计{0}条")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 120;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.FieldName = "LineHandleCate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 60;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.ColumnEdit = this.repLookUpCreator1;
            this.gridColumn6.FieldName = "Creator";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // repLookUpCreator1
            // 
            this.repLookUpCreator1.AutoHeight = false;
            this.repLookUpCreator1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpCreator1.DisplayMember = "EmpName";
            this.repLookUpCreator1.Name = "repLookUpCreator1";
            this.repLookUpCreator1.NullText = "";
            this.repLookUpCreator1.ValueMember = "AutoId";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "GetTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 135;
            // 
            // colConditionId
            // 
            this.colConditionId.FieldName = "ConditionId";
            this.colConditionId.Name = "colConditionId";
            // 
            // colHandleName
            // 
            this.colHandleName.AppearanceHeader.Options.UseTextOptions = true;
            this.colHandleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHandleName.FieldName = "HandleName";
            this.colHandleName.Name = "colHandleName";
            this.colHandleName.Visible = true;
            this.colHandleName.VisibleIndex = 2;
            this.colHandleName.Width = 120;
            // 
            // colMultiLevelApprover
            // 
            this.colMultiLevelApprover.AppearanceHeader.Options.UseTextOptions = true;
            this.colMultiLevelApprover.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMultiLevelApprover.FieldName = "MultiLevelApprover";
            this.colMultiLevelApprover.Name = "colMultiLevelApprover";
            this.colMultiLevelApprover.Visible = true;
            this.colMultiLevelApprover.VisibleIndex = 3;
            // 
            // PageLineNotice
            // 
            this.PageLineNotice.Controls.Add(this.gridControlLineNotice);
            this.PageLineNotice.Name = "PageLineNotice";
            this.PageLineNotice.Size = new System.Drawing.Size(463, 262);
            this.PageLineNotice.Text = "通知人员";
            // 
            // gridControlLineNotice
            // 
            this.gridControlLineNotice.DataSource = this.BSLineNotice;
            this.gridControlLineNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLineNotice.Location = new System.Drawing.Point(0, 0);
            this.gridControlLineNotice.MainView = this.gridViewLineNotice;
            this.gridControlLineNotice.Name = "gridControlLineNotice";
            this.gridControlLineNotice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpCreator2});
            this.gridControlLineNotice.Size = new System.Drawing.Size(463, 262);
            this.gridControlLineNotice.TabIndex = 7;
            this.gridControlLineNotice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLineNotice});
            // 
            // BSLineNotice
            // 
            this.BSLineNotice.DataMember = "LineNotice";
            this.BSLineNotice.DataSource = this.dSLineCondition;
            // 
            // gridViewLineNotice
            // 
            this.gridViewLineNotice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.colHandleName1,
            this.colMultiLevelApprover1});
            this.gridViewLineNotice.GridControl = this.gridControlLineNotice;
            this.gridViewLineNotice.IndicatorWidth = 30;
            this.gridViewLineNotice.Name = "gridViewLineNotice";
            this.gridViewLineNotice.OptionsBehavior.Editable = false;
            this.gridViewLineNotice.OptionsBehavior.ReadOnly = true;
            this.gridViewLineNotice.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewLineNotice.OptionsView.ColumnAutoWidth = false;
            this.gridViewLineNotice.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewLineNotice.OptionsView.ShowGroupPanel = false;
            this.gridViewLineNotice.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewLineHandle_CustomDrawRowIndicator);
            this.gridViewLineNotice.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewLineHandle_CustomColumnDisplayText);
            this.gridViewLineNotice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewLineHandle_KeyDown);
            // 
            // gridColumn8
            // 
            this.gridColumn8.FieldName = "AutoId";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.FieldName = "LineId";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.FieldName = "HandleOwner";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ConditionText", "共计{0}条")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 120;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.FieldName = "LineHandleCate";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 60;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.ColumnEdit = this.repLookUpCreator2;
            this.gridColumn12.FieldName = "Creator";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            // 
            // repLookUpCreator2
            // 
            this.repLookUpCreator2.AutoHeight = false;
            this.repLookUpCreator2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpCreator2.DisplayMember = "EmpName";
            this.repLookUpCreator2.Name = "repLookUpCreator2";
            this.repLookUpCreator2.NullText = "";
            this.repLookUpCreator2.ValueMember = "AutoId";
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn13.FieldName = "GetTime";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            this.gridColumn13.Width = 135;
            // 
            // gridColumn14
            // 
            this.gridColumn14.FieldName = "ConditionId";
            this.gridColumn14.Name = "gridColumn14";
            // 
            // colHandleName1
            // 
            this.colHandleName1.AppearanceHeader.Options.UseTextOptions = true;
            this.colHandleName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHandleName1.FieldName = "HandleName";
            this.colHandleName1.Name = "colHandleName1";
            this.colHandleName1.Visible = true;
            this.colHandleName1.VisibleIndex = 2;
            this.colHandleName1.Width = 120;
            // 
            // colMultiLevelApprover1
            // 
            this.colMultiLevelApprover1.AppearanceHeader.Options.UseTextOptions = true;
            this.colMultiLevelApprover1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMultiLevelApprover1.FieldName = "MultiLevelApprover";
            this.colMultiLevelApprover1.Name = "colMultiLevelApprover1";
            this.colMultiLevelApprover1.Visible = true;
            this.colMultiLevelApprover1.VisibleIndex = 3;
            // 
            // pnlLineHandleTop
            // 
            this.pnlLineHandleTop.Controls.Add(this.BtnCopy);
            this.pnlLineHandleTop.Controls.Add(this.labMultiLevelApprover);
            this.pnlLineHandleTop.Controls.Add(this.spinMultiLevelApprover);
            this.pnlLineHandleTop.Controls.Add(this.btnHandleDelete);
            this.pnlLineHandleTop.Controls.Add(this.btnHandleNew);
            this.pnlLineHandleTop.Controls.Add(this.labHandleOwner);
            this.pnlLineHandleTop.Controls.Add(this.searchLookUpHandleOwner);
            this.pnlLineHandleTop.Controls.Add(this.labHandleCate);
            this.pnlLineHandleTop.Controls.Add(this.radioHandleCate);
            this.pnlLineHandleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineHandleTop.Location = new System.Drawing.Point(0, 0);
            this.pnlLineHandleTop.Name = "pnlLineHandleTop";
            this.pnlLineHandleTop.Size = new System.Drawing.Size(469, 131);
            this.pnlLineHandleTop.TabIndex = 0;
            // 
            // BtnCopy
            // 
            this.BtnCopy.Location = new System.Drawing.Point(350, 20);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(96, 23);
            this.BtnCopy.TabIndex = 28;
            this.BtnCopy.Text = "通知人员复制";
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // labMultiLevelApprover
            // 
            this.labMultiLevelApprover.Location = new System.Drawing.Point(30, 92);
            this.labMultiLevelApprover.Name = "labMultiLevelApprover";
            this.labMultiLevelApprover.Size = new System.Drawing.Size(48, 14);
            this.labMultiLevelApprover.TabIndex = 27;
            this.labMultiLevelApprover.Text = "审批级别";
            this.labMultiLevelApprover.Visible = false;
            // 
            // spinMultiLevelApprover
            // 
            this.spinMultiLevelApprover.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinMultiLevelApprover.Location = new System.Drawing.Point(123, 89);
            this.spinMultiLevelApprover.Name = "spinMultiLevelApprover";
            this.spinMultiLevelApprover.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinMultiLevelApprover.Properties.Mask.EditMask = "d";
            this.spinMultiLevelApprover.Properties.MaxValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spinMultiLevelApprover.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinMultiLevelApprover.Size = new System.Drawing.Size(53, 20);
            this.spinMultiLevelApprover.TabIndex = 26;
            this.spinMultiLevelApprover.Visible = false;
            // 
            // btnHandleDelete
            // 
            this.btnHandleDelete.Location = new System.Drawing.Point(265, 88);
            this.btnHandleDelete.Name = "btnHandleDelete";
            this.btnHandleDelete.Size = new System.Drawing.Size(50, 23);
            this.btnHandleDelete.TabIndex = 25;
            this.btnHandleDelete.Text = "删除";
            this.btnHandleDelete.Click += new System.EventHandler(this.btnHandleDelete_Click);
            // 
            // btnHandleNew
            // 
            this.btnHandleNew.Location = new System.Drawing.Point(209, 88);
            this.btnHandleNew.Name = "btnHandleNew";
            this.btnHandleNew.Size = new System.Drawing.Size(50, 23);
            this.btnHandleNew.TabIndex = 24;
            this.btnHandleNew.Text = "新增";
            this.btnHandleNew.Click += new System.EventHandler(this.btnHandleNew_Click);
            // 
            // labHandleOwner
            // 
            this.labHandleOwner.Location = new System.Drawing.Point(30, 58);
            this.labHandleOwner.Name = "labHandleOwner";
            this.labHandleOwner.Size = new System.Drawing.Size(48, 14);
            this.labHandleOwner.TabIndex = 23;
            this.labHandleOwner.Text = "权限角色";
            // 
            // searchLookUpHandleOwner
            // 
            this.searchLookUpHandleOwner.EditValue = "";
            this.searchLookUpHandleOwner.Location = new System.Drawing.Point(123, 55);
            this.searchLookUpHandleOwner.Name = "searchLookUpHandleOwner";
            this.searchLookUpHandleOwner.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpHandleOwner.Properties.NullText = "";
            this.searchLookUpHandleOwner.Properties.View = this.searchLookUpHandleOwnerView;
            this.searchLookUpHandleOwner.Size = new System.Drawing.Size(160, 20);
            this.searchLookUpHandleOwner.TabIndex = 22;
            // 
            // searchLookUpHandleOwnerView
            // 
            this.searchLookUpHandleOwnerView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColRoleNo,
            this.gridColRoleName,
            this.gridColLoginId,
            this.gridColEmpName});
            this.searchLookUpHandleOwnerView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpHandleOwnerView.IndicatorWidth = 40;
            this.searchLookUpHandleOwnerView.Name = "searchLookUpHandleOwnerView";
            this.searchLookUpHandleOwnerView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpHandleOwnerView.OptionsView.ShowGroupPanel = false;
            this.searchLookUpHandleOwnerView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewLineHandle_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "AutoId";
            this.gridColumn1.FieldName = "AutoId";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColRoleNo
            // 
            this.gridColRoleNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColRoleNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColRoleNo.Caption = "角色编号";
            this.gridColRoleNo.FieldName = "RoleNo";
            this.gridColRoleNo.Name = "gridColRoleNo";
            this.gridColRoleNo.Visible = true;
            this.gridColRoleNo.VisibleIndex = 0;
            // 
            // gridColRoleName
            // 
            this.gridColRoleName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColRoleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColRoleName.Caption = "角色名称";
            this.gridColRoleName.FieldName = "RoleName";
            this.gridColRoleName.Name = "gridColRoleName";
            this.gridColRoleName.Visible = true;
            this.gridColRoleName.VisibleIndex = 1;
            // 
            // gridColLoginId
            // 
            this.gridColLoginId.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColLoginId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColLoginId.Caption = "员工编号";
            this.gridColLoginId.FieldName = "LoginId";
            this.gridColLoginId.Name = "gridColLoginId";
            this.gridColLoginId.Visible = true;
            this.gridColLoginId.VisibleIndex = 2;
            // 
            // gridColEmpName
            // 
            this.gridColEmpName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColEmpName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColEmpName.Caption = "员工姓名";
            this.gridColEmpName.FieldName = "EmpName";
            this.gridColEmpName.Name = "gridColEmpName";
            this.gridColEmpName.Visible = true;
            this.gridColEmpName.VisibleIndex = 3;
            // 
            // labHandleCate
            // 
            this.labHandleCate.Location = new System.Drawing.Point(30, 24);
            this.labHandleCate.Name = "labHandleCate";
            this.labHandleCate.Size = new System.Drawing.Size(72, 14);
            this.labHandleCate.TabIndex = 20;
            this.labHandleCate.Text = "处理人员类型";
            // 
            // radioHandleCate
            // 
            this.radioHandleCate.EditValue = ((short)(1));
            this.radioHandleCate.Location = new System.Drawing.Point(123, 15);
            this.radioHandleCate.Name = "radioHandleCate";
            this.radioHandleCate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioHandleCate.Properties.Appearance.Options.UseBackColor = true;
            this.radioHandleCate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioHandleCate.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "操作员"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "权限角色")});
            this.radioHandleCate.Size = new System.Drawing.Size(159, 34);
            this.radioHandleCate.TabIndex = 21;
            this.radioHandleCate.SelectedIndexChanged += new System.EventHandler(this.radioHandleCate_SelectedIndexChanged);
            // 
            // splitterCtlOne
            // 
            this.splitterCtlOne.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.splitterCtlOne.Location = new System.Drawing.Point(300, 0);
            this.splitterCtlOne.Name = "splitterCtlOne";
            this.splitterCtlOne.Size = new System.Drawing.Size(5, 422);
            this.splitterCtlOne.TabIndex = 15;
            this.splitterCtlOne.TabStop = false;
            // 
            // pnlConditionLeft
            // 
            this.pnlConditionLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlConditionLeft.Controls.Add(this.gridControlLineCondition);
            this.pnlConditionLeft.Controls.Add(this.pnlLeftBtnBar);
            this.pnlConditionLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlConditionLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlConditionLeft.Name = "pnlConditionLeft";
            this.pnlConditionLeft.Size = new System.Drawing.Size(300, 422);
            this.pnlConditionLeft.TabIndex = 0;
            // 
            // gridControlLineCondition
            // 
            this.gridControlLineCondition.DataSource = this.bSLineCondition;
            this.gridControlLineCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLineCondition.Location = new System.Drawing.Point(0, 40);
            this.gridControlLineCondition.MainView = this.gridViewLineCondition;
            this.gridControlLineCondition.Name = "gridControlLineCondition";
            this.gridControlLineCondition.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpCreator});
            this.gridControlLineCondition.Size = new System.Drawing.Size(300, 382);
            this.gridControlLineCondition.TabIndex = 5;
            this.gridControlLineCondition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLineCondition});
            // 
            // bSLineCondition
            // 
            this.bSLineCondition.DataMember = "LineCondition";
            this.bSLineCondition.DataSource = this.dSLineCondition;
            // 
            // gridViewLineCondition
            // 
            this.gridViewLineCondition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId1,
            this.colLineId1,
            this.colConditionText1,
            this.colCondition1,
            this.colCreator1,
            this.colGetTime1});
            this.gridViewLineCondition.GridControl = this.gridControlLineCondition;
            this.gridViewLineCondition.IndicatorWidth = 30;
            this.gridViewLineCondition.Name = "gridViewLineCondition";
            this.gridViewLineCondition.OptionsBehavior.Editable = false;
            this.gridViewLineCondition.OptionsBehavior.ReadOnly = true;
            this.gridViewLineCondition.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewLineCondition.OptionsView.ColumnAutoWidth = false;
            this.gridViewLineCondition.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewLineCondition.OptionsView.ShowFooter = true;
            this.gridViewLineCondition.OptionsView.ShowGroupPanel = false;
            this.gridViewLineCondition.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewLineCondition_RowClick);
            this.gridViewLineCondition.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewLineHandle_CustomDrawRowIndicator);
            this.gridViewLineCondition.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewLineCondition_FocusedRowChanged);
            // 
            // colAutoId1
            // 
            this.colAutoId1.FieldName = "AutoId";
            this.colAutoId1.Name = "colAutoId1";
            // 
            // colLineId1
            // 
            this.colLineId1.FieldName = "LineId";
            this.colLineId1.Name = "colLineId1";
            // 
            // colConditionText1
            // 
            this.colConditionText1.AppearanceHeader.Options.UseTextOptions = true;
            this.colConditionText1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colConditionText1.FieldName = "ConditionText";
            this.colConditionText1.Name = "colConditionText1";
            this.colConditionText1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ConditionText", "共计{0}条")});
            this.colConditionText1.Visible = true;
            this.colConditionText1.VisibleIndex = 0;
            this.colConditionText1.Width = 100;
            // 
            // colCondition1
            // 
            this.colCondition1.AppearanceHeader.Options.UseTextOptions = true;
            this.colCondition1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCondition1.FieldName = "Condition";
            this.colCondition1.Name = "colCondition1";
            this.colCondition1.Visible = true;
            this.colCondition1.VisibleIndex = 1;
            this.colCondition1.Width = 150;
            // 
            // colCreator1
            // 
            this.colCreator1.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreator1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreator1.ColumnEdit = this.repLookUpCreator;
            this.colCreator1.FieldName = "Creator";
            this.colCreator1.Name = "colCreator1";
            this.colCreator1.Visible = true;
            this.colCreator1.VisibleIndex = 2;
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
            // colGetTime1
            // 
            this.colGetTime1.AppearanceHeader.Options.UseTextOptions = true;
            this.colGetTime1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGetTime1.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colGetTime1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colGetTime1.FieldName = "GetTime";
            this.colGetTime1.Name = "colGetTime1";
            this.colGetTime1.Visible = true;
            this.colGetTime1.VisibleIndex = 3;
            this.colGetTime1.Width = 135;
            // 
            // pnlLeftBtnBar
            // 
            this.pnlLeftBtnBar.Controls.Add(this.btnDelete);
            this.pnlLeftBtnBar.Controls.Add(this.btnNew);
            this.pnlLeftBtnBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftBtnBar.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftBtnBar.Name = "pnlLeftBtnBar";
            this.pnlLeftBtnBar.Size = new System.Drawing.Size(300, 40);
            this.pnlLeftBtnBar.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(91, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(10, 9);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.TabControlLineSet);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(784, 455);
            this.pnlMain.TabIndex = 0;
            // 
            // dSCondition
            // 
            this.dSCondition.DataSetName = "NewDataSet";
            this.dSCondition.Tables.AddRange(new System.Data.DataTable[] {
            this.TableCondition});
            // 
            // TableCondition
            // 
            this.TableCondition.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColCondition,
            this.dataColumn1,
            this.dataColumn2,
            this.dataColLogicType,
            this.dataColFieldName,
            this.dataColOperateType,
            this.dataColOperateValue});
            this.TableCondition.TableName = "Condition";
            // 
            // dataColCondition
            // 
            this.dataColCondition.Caption = "已加入关系条件";
            this.dataColCondition.ColumnName = "Condition";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "AutoId";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "条件Id";
            this.dataColumn2.ColumnName = "ConditionId";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColLogicType
            // 
            this.dataColLogicType.Caption = "逻辑关系";
            this.dataColLogicType.ColumnName = "LogicType";
            this.dataColLogicType.DataType = typeof(int);
            // 
            // dataColFieldName
            // 
            this.dataColFieldName.Caption = "条件项";
            this.dataColFieldName.ColumnName = "FieldName";
            // 
            // dataColOperateType
            // 
            this.dataColOperateType.Caption = "关系选择";
            this.dataColOperateType.ColumnName = "OperateType";
            this.dataColOperateType.DataType = typeof(int);
            // 
            // dataColOperateValue
            // 
            this.dataColOperateValue.Caption = "条件值";
            this.dataColOperateValue.ColumnName = "OperateValue";
            // 
            // FrmWorkFlowsLineSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 491);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkFlowsLineSet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "流程图中的连接线设定";
            this.Text = "流程图中的连接线设定";
            this.Activated += new System.EventHandler(this.FrmWorkFlowsLineSet_Activated);
            this.Load += new System.EventHandler(this.FrmWorkFlowsLineSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBaseInfo)).EndInit();
            this.pnlBaseInfo.ResumeLayout(false);
            this.pnlBaseInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpLineType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEnabled.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textLineText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlLineSet)).EndInit();
            this.TabControlLineSet.ResumeLayout(false);
            this.PageBaseInfo.ResumeLayout(false);
            this.PageCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlConditionSet)).EndInit();
            this.pnlConditionSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlConditionRight)).EndInit();
            this.pnlConditionRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabControlConditionOtherInfo)).EndInit();
            this.TabControlConditionOtherInfo.ResumeLayout(false);
            this.PageLineHandle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLineHandle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSLineHandle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSLineCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLineCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLineHandle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLineNotice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineHandle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator1)).EndInit();
            this.PageLineNotice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLineNotice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSLineNotice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineNotice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineHandleTop)).EndInit();
            this.pnlLineHandleTop.ResumeLayout(false);
            this.pnlLineHandleTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinMultiLevelApprover.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpHandleOwner.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpHandleOwnerView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioHandleCate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlConditionLeft)).EndInit();
            this.pnlConditionLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLineCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSLineCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLineCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftBtnBar)).EndInit();
            this.pnlLeftBtnBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dSCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableCondition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraEditors.PanelControl pnlBaseInfo;
        private DevExpress.XtraEditors.LabelControl labEnabled;
        private DevExpress.XtraEditors.CheckEdit checkEnabled;
        public DevExpress.XtraEditors.TextEdit textLineText;
        private DevExpress.XtraEditors.LabelControl labLineText;
        private DevExpress.XtraEditors.LabelControl labLineType;
        public DevExpress.XtraEditors.LookUpEdit lookUpLineType;
        private DevExpress.XtraTab.XtraTabControl TabControlLineSet;
        private DevExpress.XtraTab.XtraTabPage PageBaseInfo;
        private DevExpress.XtraTab.XtraTabPage PageCondition;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.PanelControl pnlConditionSet;
        private DevExpress.XtraEditors.PanelControl pnlConditionLeft;
        private DevExpress.XtraEditors.PanelControl pnlLeftBtnBar;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.GridControl gridControlLineCondition;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLineCondition;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator;
        private System.Windows.Forms.BindingSource bSLineCondition;
        private System.Data.DataSet dSLineCondition;
        private System.Data.DataTable TableLineCondition;
        private System.Data.DataColumn ColAutoId;
        private System.Data.DataColumn ColLineId;
        private System.Data.DataColumn ColConditionText;
        private System.Data.DataColumn ColCondition;
        private System.Data.DataColumn ColCreator;
        private System.Data.DataColumn ColGetTime;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId1;
        private DevExpress.XtraGrid.Columns.GridColumn colLineId1;
        private DevExpress.XtraGrid.Columns.GridColumn colConditionText1;
        private DevExpress.XtraGrid.Columns.GridColumn colCondition1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator1;
        private DevExpress.XtraGrid.Columns.GridColumn colGetTime1;
        private DevExpress.XtraEditors.PanelControl pnlConditionRight;
        private DevExpress.XtraEditors.SplitterControl splitterCtlOne;
        private DevExpress.XtraTab.XtraTabControl TabControlConditionOtherInfo;
        private DevExpress.XtraTab.XtraTabPage PageLineHandle;
        private DevExpress.XtraTab.XtraTabPage PageLineNotice;
        private DevExpress.XtraEditors.PanelControl pnlLineHandleTop;
        private DevExpress.XtraEditors.SimpleButton btnHandleDelete;
        private DevExpress.XtraEditors.SimpleButton btnHandleNew;
        private DevExpress.XtraEditors.LabelControl labHandleOwner;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpHandleOwner;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpHandleOwnerView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRoleNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRoleName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLoginId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColEmpName;
        private DevExpress.XtraEditors.LabelControl labHandleCate;
        private DevExpress.XtraEditors.RadioGroup radioHandleCate;
        private System.Data.DataTable TableLineHandle;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColLineId;
        private System.Data.DataColumn dataColConditionId;
        private System.Data.DataColumn dataColLineHandleCate;
        private System.Data.DataColumn dataColHandleOwner;
        private System.Data.DataColumn dataColCreator;
        private System.Data.DataColumn dataColGetTime;
        private System.Data.DataTable TableLineNotice;
        private System.Data.DataColumn dataColuAutoId;
        private System.Data.DataColumn dataColuLineId;
        private System.Data.DataColumn dataColuConditionId;
        private System.Data.DataColumn dataColuLineHandleCate;
        private System.Data.DataColumn dataColuHandleOwner;
        private System.Data.DataColumn dataColuCreator;
        private System.Data.DataColumn dataColuGetTime;
        private System.Windows.Forms.BindingSource BSLineHandle;
        private System.Windows.Forms.BindingSource BSLineNotice;
        private DevExpress.XtraGrid.GridControl gridControlLineHandle;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLineHandle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn colConditionId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator1;
        private DevExpress.XtraGrid.GridControl gridControlLineNotice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLineNotice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private System.Data.DataColumn dataColHandleName;
        private System.Data.DataColumn dataColuHandleName;
        private DevExpress.XtraGrid.Columns.GridColumn colHandleName;
        private DevExpress.XtraGrid.Columns.GridColumn colHandleName1;
        private DevExpress.XtraEditors.LabelControl labMultiLevelApprover;
        private DevExpress.XtraEditors.SpinEdit spinMultiLevelApprover;
        private System.Data.DataColumn dataColMultiLevelApprover;
        private DevExpress.XtraGrid.Columns.GridColumn colMultiLevelApprover;
        private System.Data.DataColumn dataColuMultiLevelApprover;
        private DevExpress.XtraGrid.Columns.GridColumn colMultiLevelApprover1;
        private DevExpress.XtraEditors.SimpleButton BtnCopy;
        private System.Data.DataColumn ColWorkFlowsId;
        private System.Data.DataSet dSCondition;
        public System.Data.DataTable TableCondition;
        private System.Data.DataColumn dataColCondition;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColLogicType;
        private System.Data.DataColumn dataColFieldName;
        private System.Data.DataColumn dataColOperateType;
        private System.Data.DataColumn dataColOperateValue;
    }
}