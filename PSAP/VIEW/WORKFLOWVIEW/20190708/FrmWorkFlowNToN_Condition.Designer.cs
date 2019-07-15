namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWorkFlowNToN_Condition
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
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.dateConditionValue = new DevExpress.XtraEditors.DateEdit();
            this.spinConditionValue = new DevExpress.XtraEditors.SpinEdit();
            this.btnJoin = new DevExpress.XtraEditors.SimpleButton();
            this.labConditionValue = new DevExpress.XtraEditors.LabelControl();
            this.textConditionValue = new DevExpress.XtraEditors.TextEdit();
            this.labRelationSelect = new DevExpress.XtraEditors.LabelControl();
            this.comBoxRelationSelect = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labConditionItem = new DevExpress.XtraEditors.LabelControl();
            this.lookUpConditionItem = new DevExpress.XtraEditors.LookUpEdit();
            this.labRelation = new DevExpress.XtraEditors.LabelControl();
            this.comBoxRelation = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.gridControlCondition = new DevExpress.XtraGrid.GridControl();
            this.dSCondition = new System.Data.DataSet();
            this.TableCondition = new System.Data.DataTable();
            this.dataColCondition = new System.Data.DataColumn();
            this.gridViewCondition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColCondition = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateConditionValue.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateConditionValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinConditionValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textConditionValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxRelationSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpConditionItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxRelation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCondition)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnClear);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.BtnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 325);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(584, 36);
            this.pnlBottom.TabIndex = 12;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(9, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "清除条件";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(495, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(414, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 0;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.dateConditionValue);
            this.pnlTop.Controls.Add(this.spinConditionValue);
            this.pnlTop.Controls.Add(this.btnJoin);
            this.pnlTop.Controls.Add(this.labConditionValue);
            this.pnlTop.Controls.Add(this.textConditionValue);
            this.pnlTop.Controls.Add(this.labRelationSelect);
            this.pnlTop.Controls.Add(this.comBoxRelationSelect);
            this.pnlTop.Controls.Add(this.labConditionItem);
            this.pnlTop.Controls.Add(this.lookUpConditionItem);
            this.pnlTop.Controls.Add(this.labRelation);
            this.pnlTop.Controls.Add(this.comBoxRelation);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(584, 80);
            this.pnlTop.TabIndex = 13;
            // 
            // dateConditionValue
            // 
            this.dateConditionValue.EditValue = null;
            this.dateConditionValue.EnterMoveNextControl = true;
            this.dateConditionValue.Location = new System.Drawing.Point(324, 42);
            this.dateConditionValue.Name = "dateConditionValue";
            this.dateConditionValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateConditionValue.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateConditionValue.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateConditionValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateConditionValue.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateConditionValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateConditionValue.Properties.Mask.EditMask = "G";
            this.dateConditionValue.Size = new System.Drawing.Size(150, 20);
            this.dateConditionValue.TabIndex = 3;
            this.dateConditionValue.Visible = false;
            // 
            // spinConditionValue
            // 
            this.spinConditionValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinConditionValue.EnterMoveNextControl = true;
            this.spinConditionValue.Location = new System.Drawing.Point(324, 42);
            this.spinConditionValue.Name = "spinConditionValue";
            this.spinConditionValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinConditionValue.Size = new System.Drawing.Size(150, 20);
            this.spinConditionValue.TabIndex = 3;
            this.spinConditionValue.Visible = false;
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(486, 41);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(75, 23);
            this.btnJoin.TabIndex = 4;
            this.btnJoin.Text = "加入条件";
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // labConditionValue
            // 
            this.labConditionValue.Location = new System.Drawing.Point(375, 22);
            this.labConditionValue.Name = "labConditionValue";
            this.labConditionValue.Size = new System.Drawing.Size(36, 14);
            this.labConditionValue.TabIndex = 7;
            this.labConditionValue.Text = "条件值";
            // 
            // textConditionValue
            // 
            this.textConditionValue.EnterMoveNextControl = true;
            this.textConditionValue.Location = new System.Drawing.Point(324, 42);
            this.textConditionValue.Name = "textConditionValue";
            this.textConditionValue.Size = new System.Drawing.Size(150, 20);
            this.textConditionValue.TabIndex = 3;
            // 
            // labRelationSelect
            // 
            this.labRelationSelect.Location = new System.Drawing.Point(254, 22);
            this.labRelationSelect.Name = "labRelationSelect";
            this.labRelationSelect.Size = new System.Drawing.Size(48, 14);
            this.labRelationSelect.TabIndex = 5;
            this.labRelationSelect.Text = "关系选择";
            // 
            // comBoxRelationSelect
            // 
            this.comBoxRelationSelect.EnterMoveNextControl = true;
            this.comBoxRelationSelect.Location = new System.Drawing.Point(238, 42);
            this.comBoxRelationSelect.Name = "comBoxRelationSelect";
            this.comBoxRelationSelect.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comBoxRelationSelect.Properties.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "<>",
            "IN",
            "LIKE"});
            this.comBoxRelationSelect.Size = new System.Drawing.Size(80, 20);
            this.comBoxRelationSelect.TabIndex = 2;
            // 
            // labConditionItem
            // 
            this.labConditionItem.Location = new System.Drawing.Point(149, 22);
            this.labConditionItem.Name = "labConditionItem";
            this.labConditionItem.Size = new System.Drawing.Size(36, 14);
            this.labConditionItem.TabIndex = 3;
            this.labConditionItem.Text = "条件项";
            // 
            // lookUpConditionItem
            // 
            this.lookUpConditionItem.EnterMoveNextControl = true;
            this.lookUpConditionItem.Location = new System.Drawing.Point(102, 42);
            this.lookUpConditionItem.Name = "lookUpConditionItem";
            this.lookUpConditionItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpConditionItem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProperName", "数据库列名"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProperText", "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Proper", "数据类型", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataTypeName", "数据类型"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataTypeNo", "类型编号", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lookUpConditionItem.Properties.DisplayMember = "ProperText";
            this.lookUpConditionItem.Properties.NullText = "";
            this.lookUpConditionItem.Properties.PopupFormMinSize = new System.Drawing.Size(300, 300);
            this.lookUpConditionItem.Properties.ValueMember = "ProperName";
            this.lookUpConditionItem.Size = new System.Drawing.Size(130, 20);
            this.lookUpConditionItem.TabIndex = 1;
            this.lookUpConditionItem.EditValueChanged += new System.EventHandler(this.lookUpConditionItem_EditValueChanged);
            // 
            // labRelation
            // 
            this.labRelation.Location = new System.Drawing.Point(36, 22);
            this.labRelation.Name = "labRelation";
            this.labRelation.Size = new System.Drawing.Size(48, 14);
            this.labRelation.TabIndex = 1;
            this.labRelation.Text = "逻辑关系";
            // 
            // comBoxRelation
            // 
            this.comBoxRelation.EnterMoveNextControl = true;
            this.comBoxRelation.Location = new System.Drawing.Point(26, 42);
            this.comBoxRelation.Name = "comBoxRelation";
            this.comBoxRelation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comBoxRelation.Properties.Items.AddRange(new object[] {
            "并且",
            "或者"});
            this.comBoxRelation.Size = new System.Drawing.Size(70, 20);
            this.comBoxRelation.TabIndex = 0;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.gridControlCondition);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 80);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(584, 245);
            this.pnlMiddle.TabIndex = 14;
            // 
            // gridControlCondition
            // 
            this.gridControlCondition.DataMember = "Condition";
            this.gridControlCondition.DataSource = this.dSCondition;
            this.gridControlCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCondition.Location = new System.Drawing.Point(2, 2);
            this.gridControlCondition.MainView = this.gridViewCondition;
            this.gridControlCondition.Name = "gridControlCondition";
            this.gridControlCondition.Size = new System.Drawing.Size(580, 241);
            this.gridControlCondition.TabIndex = 5;
            this.gridControlCondition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCondition});
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
            this.dataColCondition});
            this.TableCondition.TableName = "Condition";
            // 
            // dataColCondition
            // 
            this.dataColCondition.Caption = "已加入关系条件";
            this.dataColCondition.ColumnName = "Condition";
            // 
            // gridViewCondition
            // 
            this.gridViewCondition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColCondition});
            this.gridViewCondition.GridControl = this.gridControlCondition;
            this.gridViewCondition.IndicatorWidth = 40;
            this.gridViewCondition.Name = "gridViewCondition";
            this.gridViewCondition.OptionsBehavior.Editable = false;
            this.gridViewCondition.OptionsBehavior.ReadOnly = true;
            this.gridViewCondition.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewCondition.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewCondition.OptionsView.ShowGroupPanel = false;
            this.gridViewCondition.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewCondition_CustomDrawRowIndicator);
            // 
            // gridColCondition
            // 
            this.gridColCondition.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColCondition.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColCondition.FieldName = "Condition";
            this.gridColCondition.Name = "gridColCondition";
            this.gridColCondition.Visible = true;
            this.gridColCondition.VisibleIndex = 0;
            // 
            // FrmWorkFlowNToN_Condition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkFlowNToN_Condition";
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
            ((System.ComponentModel.ISupportInitialize)(this.dateConditionValue.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateConditionValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinConditionValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textConditionValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxRelationSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpConditionItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxRelation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCondition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraEditors.LabelControl labRelation;
        private DevExpress.XtraEditors.ComboBoxEdit comBoxRelation;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnJoin;
        private DevExpress.XtraEditors.LabelControl labConditionValue;
        private DevExpress.XtraEditors.TextEdit textConditionValue;
        private DevExpress.XtraEditors.LabelControl labRelationSelect;
        private DevExpress.XtraEditors.ComboBoxEdit comBoxRelationSelect;
        private DevExpress.XtraEditors.LabelControl labConditionItem;
        private DevExpress.XtraEditors.LookUpEdit lookUpConditionItem;
        private DevExpress.XtraGrid.GridControl gridControlCondition;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCondition;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCondition;
        private System.Data.DataSet dSCondition;
        private System.Data.DataTable TableCondition;
        private System.Data.DataColumn dataColCondition;
        private DevExpress.XtraEditors.DateEdit dateConditionValue;
        private DevExpress.XtraEditors.SpinEdit spinConditionValue;
    }
}