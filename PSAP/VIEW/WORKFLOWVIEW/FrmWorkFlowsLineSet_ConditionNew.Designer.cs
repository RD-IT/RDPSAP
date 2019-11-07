namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWorkFlowsLineSet_ConditionNew
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.labConditionText = new DevExpress.XtraEditors.LabelControl();
            this.textConditionText = new DevExpress.XtraEditors.TextEdit();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.btnListAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlCondition = new DevExpress.XtraGrid.GridControl();
            this.bindingSource_Condition = new System.Windows.Forms.BindingSource(this.components);
            this.dSCondition = new System.Data.DataSet();
            this.TableCondition = new System.Data.DataTable();
            this.dataColCondition = new System.Data.DataColumn();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColConditionId = new System.Data.DataColumn();
            this.dataColLogicType = new System.Data.DataColumn();
            this.dataColFieldName = new System.Data.DataColumn();
            this.dataColOperateType = new System.Data.DataColumn();
            this.dataColOperateValue = new System.Data.DataColumn();
            this.gridViewCondition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColCondition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConditionId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpFieldName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLogicType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpLogicType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colOperateType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpOperateType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colOperateValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTextOperateValue = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repbtnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repDateOperateValue = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repSpinOperateValue = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textConditionText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Condition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpFieldName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpLogicType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpOperateType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTextOperateValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repbtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDateOperateValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDateOperateValue.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinOperateValue)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.BtnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 325);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(544, 36);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(455, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(374, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 2;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.labConditionText);
            this.pnlTop.Controls.Add(this.textConditionText);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(544, 51);
            this.pnlTop.TabIndex = 0;
            // 
            // labConditionText
            // 
            this.labConditionText.Location = new System.Drawing.Point(20, 17);
            this.labConditionText.Name = "labConditionText";
            this.labConditionText.Size = new System.Drawing.Size(48, 14);
            this.labConditionText.TabIndex = 9;
            this.labConditionText.Text = "条件名称";
            // 
            // textConditionText
            // 
            this.textConditionText.Location = new System.Drawing.Point(86, 14);
            this.textConditionText.Name = "textConditionText";
            this.textConditionText.Size = new System.Drawing.Size(130, 20);
            this.textConditionText.TabIndex = 0;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.btnListAdd);
            this.pnlMiddle.Controls.Add(this.gridControlCondition);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 51);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(544, 274);
            this.pnlMiddle.TabIndex = 1;
            // 
            // btnListAdd
            // 
            this.btnListAdd.Location = new System.Drawing.Point(2, 2);
            this.btnListAdd.Name = "btnListAdd";
            this.btnListAdd.Size = new System.Drawing.Size(40, 21);
            this.btnListAdd.TabIndex = 6;
            this.btnListAdd.Text = "+";
            this.btnListAdd.Click += new System.EventHandler(this.btnListAdd_Click);
            // 
            // gridControlCondition
            // 
            this.gridControlCondition.DataMember = null;
            this.gridControlCondition.DataSource = this.bindingSource_Condition;
            this.gridControlCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCondition.Location = new System.Drawing.Point(2, 2);
            this.gridControlCondition.MainView = this.gridViewCondition;
            this.gridControlCondition.Name = "gridControlCondition";
            this.gridControlCondition.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpFieldName,
            this.repLookUpLogicType,
            this.repLookUpOperateType,
            this.repDateOperateValue,
            this.repTextOperateValue,
            this.repSpinOperateValue,
            this.repbtnDelete});
            this.gridControlCondition.Size = new System.Drawing.Size(540, 270);
            this.gridControlCondition.TabIndex = 5;
            this.gridControlCondition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCondition});
            // 
            // bindingSource_Condition
            // 
            this.bindingSource_Condition.DataMember = "Condition";
            this.bindingSource_Condition.DataSource = this.dSCondition;
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
            this.dataColAutoId,
            this.dataColConditionId,
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
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColConditionId
            // 
            this.dataColConditionId.Caption = "条件Id";
            this.dataColConditionId.ColumnName = "ConditionId";
            this.dataColConditionId.DataType = typeof(int);
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
            // gridViewCondition
            // 
            this.gridViewCondition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColCondition,
            this.colAutoId,
            this.colConditionId,
            this.colFieldName,
            this.colLogicType,
            this.colOperateType,
            this.colOperateValue,
            this.colDelete});
            this.gridViewCondition.GridControl = this.gridControlCondition;
            this.gridViewCondition.IndicatorWidth = 40;
            this.gridViewCondition.Name = "gridViewCondition";
            this.gridViewCondition.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewCondition.OptionsMenu.EnableColumnMenu = false;
            this.gridViewCondition.OptionsMenu.EnableFooterMenu = false;
            this.gridViewCondition.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewCondition.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewCondition.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewCondition.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridViewCondition.OptionsView.ColumnAutoWidth = false;
            this.gridViewCondition.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewCondition.OptionsView.ShowGroupPanel = false;
            this.gridViewCondition.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewCondition_CustomDrawRowIndicator);
            this.gridViewCondition.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewCondition_InitNewRow);
            this.gridViewCondition.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewCondition_FocusedRowChanged);
            this.gridViewCondition.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewCondition_CellValueChanged);
            this.gridViewCondition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewCondition_KeyDown);
            // 
            // gridColCondition
            // 
            this.gridColCondition.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColCondition.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColCondition.FieldName = "Condition";
            this.gridColCondition.Name = "gridColCondition";
            this.gridColCondition.OptionsColumn.AllowEdit = false;
            this.gridColCondition.OptionsColumn.ReadOnly = true;
            this.gridColCondition.OptionsColumn.TabStop = false;
            this.gridColCondition.Width = 150;
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colConditionId
            // 
            this.colConditionId.FieldName = "ConditionId";
            this.colConditionId.Name = "colConditionId";
            // 
            // colFieldName
            // 
            this.colFieldName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFieldName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFieldName.ColumnEdit = this.repLookUpFieldName;
            this.colFieldName.FieldName = "FieldName";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.Visible = true;
            this.colFieldName.VisibleIndex = 2;
            this.colFieldName.Width = 130;
            // 
            // repLookUpFieldName
            // 
            this.repLookUpFieldName.AutoHeight = false;
            this.repLookUpFieldName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpFieldName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FieldName", "FieldName", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FieldText", "FieldText"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataTypeName", "DataTypeName", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.repLookUpFieldName.DisplayMember = "FieldText";
            this.repLookUpFieldName.Name = "repLookUpFieldName";
            this.repLookUpFieldName.NullText = "";
            this.repLookUpFieldName.PopupFormMinSize = new System.Drawing.Size(180, 300);
            this.repLookUpFieldName.ShowHeader = false;
            this.repLookUpFieldName.ValueMember = "FieldName";
            // 
            // colLogicType
            // 
            this.colLogicType.AppearanceHeader.Options.UseTextOptions = true;
            this.colLogicType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLogicType.ColumnEdit = this.repLookUpLogicType;
            this.colLogicType.FieldName = "LogicType";
            this.colLogicType.Name = "colLogicType";
            this.colLogicType.Visible = true;
            this.colLogicType.VisibleIndex = 1;
            this.colLogicType.Width = 80;
            // 
            // repLookUpLogicType
            // 
            this.repLookUpLogicType.AutoHeight = false;
            this.repLookUpLogicType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpLogicType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LogicName", "LogicName")});
            this.repLookUpLogicType.DisplayMember = "LogicName";
            this.repLookUpLogicType.DropDownRows = 3;
            this.repLookUpLogicType.Name = "repLookUpLogicType";
            this.repLookUpLogicType.NullText = "";
            this.repLookUpLogicType.PopupFormMinSize = new System.Drawing.Size(30, 0);
            this.repLookUpLogicType.PopupWidth = 30;
            this.repLookUpLogicType.ShowHeader = false;
            this.repLookUpLogicType.ValueMember = "LogicId";
            // 
            // colOperateType
            // 
            this.colOperateType.AppearanceHeader.Options.UseTextOptions = true;
            this.colOperateType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOperateType.ColumnEdit = this.repLookUpOperateType;
            this.colOperateType.FieldName = "OperateType";
            this.colOperateType.Name = "colOperateType";
            this.colOperateType.Visible = true;
            this.colOperateType.VisibleIndex = 3;
            this.colOperateType.Width = 80;
            // 
            // repLookUpOperateType
            // 
            this.repLookUpOperateType.AutoHeight = false;
            this.repLookUpOperateType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpOperateType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", "TypeName")});
            this.repLookUpOperateType.DisplayMember = "TypeName";
            this.repLookUpOperateType.DropDownRows = 9;
            this.repLookUpOperateType.Name = "repLookUpOperateType";
            this.repLookUpOperateType.NullText = "";
            this.repLookUpOperateType.PopupFormMinSize = new System.Drawing.Size(30, 0);
            this.repLookUpOperateType.PopupWidth = 30;
            this.repLookUpOperateType.ShowHeader = false;
            this.repLookUpOperateType.ValueMember = "TypeId";
            // 
            // colOperateValue
            // 
            this.colOperateValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colOperateValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOperateValue.ColumnEdit = this.repTextOperateValue;
            this.colOperateValue.FieldName = "OperateValue";
            this.colOperateValue.Name = "colOperateValue";
            this.colOperateValue.Visible = true;
            this.colOperateValue.VisibleIndex = 4;
            this.colOperateValue.Width = 180;
            // 
            // repTextOperateValue
            // 
            this.repTextOperateValue.AutoHeight = false;
            this.repTextOperateValue.Name = "repTextOperateValue";
            // 
            // colDelete
            // 
            this.colDelete.ColumnEdit = this.repbtnDelete;
            this.colDelete.Name = "colDelete";
            this.colDelete.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 0;
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
            // repDateOperateValue
            // 
            this.repDateOperateValue.AutoHeight = false;
            this.repDateOperateValue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDateOperateValue.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDateOperateValue.Name = "repDateOperateValue";
            // 
            // repSpinOperateValue
            // 
            this.repSpinOperateValue.AutoHeight = false;
            this.repSpinOperateValue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpinOperateValue.Name = "repSpinOperateValue";
            // 
            // FrmWorkFlowsLineSet_ConditionNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 361);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkFlowsLineSet_ConditionNew";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "设定结点之间关系条件";
            this.Text = "设定结点之间关系条件";
            this.Load += new System.EventHandler(this.FrmWorkFlowNToN_Condition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textConditionText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Condition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpFieldName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpLogicType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpOperateType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTextOperateValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repbtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDateOperateValue.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDateOperateValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinOperateValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraGrid.GridControl gridControlCondition;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCondition;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCondition;
        private System.Data.DataSet dSCondition;
        private System.Data.DataColumn dataColCondition;
        private DevExpress.XtraEditors.LabelControl labConditionText;
        public DevExpress.XtraEditors.TextEdit textConditionText;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColConditionId;
        private System.Data.DataColumn dataColLogicType;
        private System.Data.DataColumn dataColFieldName;
        private System.Data.DataColumn dataColOperateType;
        private System.Data.DataColumn dataColOperateValue;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colConditionId;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldName;
        private DevExpress.XtraGrid.Columns.GridColumn colLogicType;
        private DevExpress.XtraGrid.Columns.GridColumn colOperateType;
        private DevExpress.XtraGrid.Columns.GridColumn colOperateValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpFieldName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpLogicType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpOperateType;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repDateOperateValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinOperateValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repTextOperateValue;
        private DevExpress.XtraEditors.SimpleButton btnListAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repbtnDelete;
        private System.Data.DataTable TableCondition;
        public System.Windows.Forms.BindingSource bindingSource_Condition;
    }
}