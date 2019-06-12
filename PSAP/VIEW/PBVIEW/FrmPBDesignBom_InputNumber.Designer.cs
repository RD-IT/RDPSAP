namespace PSAP.VIEW.BSVIEW
{
    partial class FrmPBDesignBom_InputNumber
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
            this.textCodeFileName = new DevExpress.XtraEditors.TextEdit();
            this.labPartsCodeId = new DevExpress.XtraEditors.LabelControl();
            this.spinNumber = new DevExpress.XtraEditors.SpinEdit();
            this.labNumber = new DevExpress.XtraEditors.LabelControl();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.TabCtl = new DevExpress.XtraTab.XtraTabControl();
            this.PageList = new DevExpress.XtraTab.XtraTabPage();
            this.treeListDesignBom = new DevExpress.XtraTreeList.TreeList();
            this.colParentCodeFileName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAutoId1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTotalQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCodeFileName1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCodeName1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHasLevel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsUse = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repCheckEditIsUse = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colRemainQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repSpinRemainQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colPbBomNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bindingSource_DesignBom = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_DesignBom = new System.Data.DataSet();
            this.dataTableDesignBom = new System.Data.DataTable();
            this.coluReId = new System.Data.DataColumn();
            this.coluReParent = new System.Data.DataColumn();
            this.coluCodeFileName = new System.Data.DataColumn();
            this.coluParentCodeFileName = new System.Data.DataColumn();
            this.coluCodeName = new System.Data.DataColumn();
            this.coluAutoId = new System.Data.DataColumn();
            this.coluPbBomNo = new System.Data.DataColumn();
            this.coluIsUse = new System.Data.DataColumn();
            this.coluTotalQty = new System.Data.DataColumn();
            this.coluRemainQty = new System.Data.DataColumn();
            this.coluHasLevel = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textCodeFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabCtl)).BeginInit();
            this.TabCtl.SuspendLayout();
            this.PageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditIsUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinRemainQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_DesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DesignBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDesignBom)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.BtnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 485);
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
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(534, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 1;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.textCodeFileName);
            this.pnlTop.Controls.Add(this.labPartsCodeId);
            this.pnlTop.Controls.Add(this.spinNumber);
            this.pnlTop.Controls.Add(this.labNumber);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(704, 89);
            this.pnlTop.TabIndex = 0;
            // 
            // textCodeFileName
            // 
            this.textCodeFileName.Location = new System.Drawing.Point(95, 23);
            this.textCodeFileName.Name = "textCodeFileName";
            this.textCodeFileName.Properties.ReadOnly = true;
            this.textCodeFileName.Size = new System.Drawing.Size(568, 20);
            this.textCodeFileName.TabIndex = 10;
            this.textCodeFileName.TabStop = false;
            // 
            // labPartsCodeId
            // 
            this.labPartsCodeId.Location = new System.Drawing.Point(28, 26);
            this.labPartsCodeId.Name = "labPartsCodeId";
            this.labPartsCodeId.Size = new System.Drawing.Size(48, 14);
            this.labPartsCodeId.TabIndex = 16;
            this.labPartsCodeId.Text = "零件编号";
            // 
            // spinNumber
            // 
            this.spinNumber.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinNumber.EnterMoveNextControl = true;
            this.spinNumber.Location = new System.Drawing.Point(95, 53);
            this.spinNumber.Name = "spinNumber";
            this.spinNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinNumber.Size = new System.Drawing.Size(150, 20);
            this.spinNumber.TabIndex = 0;
            // 
            // labNumber
            // 
            this.labNumber.Location = new System.Drawing.Point(28, 56);
            this.labNumber.Name = "labNumber";
            this.labNumber.Size = new System.Drawing.Size(48, 14);
            this.labNumber.TabIndex = 3;
            this.labNumber.Text = "增加数量";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.TabCtl);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 89);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(704, 396);
            this.pnlMiddle.TabIndex = 3;
            // 
            // TabCtl
            // 
            this.TabCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCtl.Location = new System.Drawing.Point(2, 2);
            this.TabCtl.Name = "TabCtl";
            this.TabCtl.SelectedTabPage = this.PageList;
            this.TabCtl.Size = new System.Drawing.Size(700, 392);
            this.TabCtl.TabIndex = 0;
            this.TabCtl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PageList});
            // 
            // PageList
            // 
            this.PageList.Controls.Add(this.treeListDesignBom);
            this.PageList.Name = "PageList";
            this.PageList.Size = new System.Drawing.Size(694, 363);
            this.PageList.Text = "已经包含当前零件或 Bom 的信息";
            // 
            // treeListDesignBom
            // 
            this.treeListDesignBom.AllowDrop = true;
            this.treeListDesignBom.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colParentCodeFileName,
            this.colAutoId1,
            this.colTotalQty,
            this.colCodeFileName1,
            this.colCodeName1,
            this.colHasLevel,
            this.colIsUse,
            this.colRemainQty,
            this.colPbBomNo});
            this.treeListDesignBom.DataSource = this.bindingSource_DesignBom;
            this.treeListDesignBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDesignBom.IndicatorWidth = 40;
            this.treeListDesignBom.KeyFieldName = "ReId";
            this.treeListDesignBom.Location = new System.Drawing.Point(0, 0);
            this.treeListDesignBom.Name = "treeListDesignBom";
            this.treeListDesignBom.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListDesignBom.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListDesignBom.OptionsView.AutoWidth = false;
            this.treeListDesignBom.ParentFieldName = "ReParent";
            this.treeListDesignBom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckEditIsUse,
            this.repSpinRemainQty});
            this.treeListDesignBom.Size = new System.Drawing.Size(694, 363);
            this.treeListDesignBom.TabIndex = 1;
            this.treeListDesignBom.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.treeListBom_CustomDrawNodeIndicator);
            // 
            // colParentCodeFileName
            // 
            this.colParentCodeFileName.FieldName = "ParentCodeFileName";
            this.colParentCodeFileName.Name = "colParentCodeFileName";
            this.colParentCodeFileName.Width = 30;
            // 
            // colAutoId1
            // 
            this.colAutoId1.FieldName = "AutoId";
            this.colAutoId1.Name = "colAutoId1";
            this.colAutoId1.Width = 30;
            // 
            // colTotalQty
            // 
            this.colTotalQty.FieldName = "TotalQty";
            this.colTotalQty.Name = "colTotalQty";
            this.colTotalQty.Width = 31;
            // 
            // colCodeFileName1
            // 
            this.colCodeFileName1.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeFileName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeFileName1.Caption = "零件编号";
            this.colCodeFileName1.FieldName = "CodeFileName";
            this.colCodeFileName1.Name = "colCodeFileName1";
            this.colCodeFileName1.OptionsColumn.AllowEdit = false;
            this.colCodeFileName1.Visible = true;
            this.colCodeFileName1.VisibleIndex = 0;
            this.colCodeFileName1.Width = 200;
            // 
            // colCodeName1
            // 
            this.colCodeName1.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeName1.Caption = "零件名称";
            this.colCodeName1.FieldName = "CodeName";
            this.colCodeName1.Name = "colCodeName1";
            this.colCodeName1.OptionsColumn.AllowEdit = false;
            this.colCodeName1.Visible = true;
            this.colCodeName1.VisibleIndex = 1;
            this.colCodeName1.Width = 120;
            // 
            // colHasLevel
            // 
            this.colHasLevel.AppearanceHeader.Options.UseTextOptions = true;
            this.colHasLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHasLevel.Caption = "类型";
            this.colHasLevel.FieldName = "HasLevel";
            this.colHasLevel.Name = "colHasLevel";
            this.colHasLevel.OptionsColumn.AllowEdit = false;
            this.colHasLevel.Visible = true;
            this.colHasLevel.VisibleIndex = 2;
            this.colHasLevel.Width = 40;
            // 
            // colIsUse
            // 
            this.colIsUse.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsUse.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsUse.Caption = "使用";
            this.colIsUse.ColumnEdit = this.repCheckEditIsUse;
            this.colIsUse.FieldName = "IsUse";
            this.colIsUse.Name = "colIsUse";
            this.colIsUse.OptionsColumn.AllowEdit = false;
            this.colIsUse.Visible = true;
            this.colIsUse.VisibleIndex = 4;
            this.colIsUse.Width = 40;
            // 
            // repCheckEditIsUse
            // 
            this.repCheckEditIsUse.AutoHeight = false;
            this.repCheckEditIsUse.Name = "repCheckEditIsUse";
            this.repCheckEditIsUse.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckEditIsUse.ValueChecked = ((short)(1));
            this.repCheckEditIsUse.ValueGrayed = ((short)(0));
            this.repCheckEditIsUse.ValueUnchecked = ((short)(0));
            // 
            // colRemainQty
            // 
            this.colRemainQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemainQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemainQty.Caption = "数量";
            this.colRemainQty.ColumnEdit = this.repSpinRemainQty;
            this.colRemainQty.FieldName = "RemainQty";
            this.colRemainQty.Name = "colRemainQty";
            this.colRemainQty.OptionsColumn.AllowEdit = false;
            this.colRemainQty.Visible = true;
            this.colRemainQty.VisibleIndex = 3;
            this.colRemainQty.Width = 80;
            // 
            // repSpinRemainQty
            // 
            this.repSpinRemainQty.AutoHeight = false;
            this.repSpinRemainQty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpinRemainQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinRemainQty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSpinRemainQty.Name = "repSpinRemainQty";
            // 
            // colPbBomNo
            // 
            this.colPbBomNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colPbBomNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPbBomNo.Caption = "设计Bom编号";
            this.colPbBomNo.FieldName = "PbBomNo";
            this.colPbBomNo.Name = "colPbBomNo";
            this.colPbBomNo.OptionsColumn.AllowEdit = false;
            this.colPbBomNo.Visible = true;
            this.colPbBomNo.VisibleIndex = 5;
            this.colPbBomNo.Width = 100;
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
            this.dataTableDesignBom});
            // 
            // dataTableDesignBom
            // 
            this.dataTableDesignBom.Columns.AddRange(new System.Data.DataColumn[] {
            this.coluReId,
            this.coluReParent,
            this.coluCodeFileName,
            this.coluParentCodeFileName,
            this.coluCodeName,
            this.coluAutoId,
            this.coluPbBomNo,
            this.coluIsUse,
            this.coluTotalQty,
            this.coluRemainQty,
            this.coluHasLevel});
            this.dataTableDesignBom.TableName = "DesignBom";
            // 
            // coluReId
            // 
            this.coluReId.ColumnName = "ReId";
            // 
            // coluReParent
            // 
            this.coluReParent.ColumnName = "ReParent";
            // 
            // coluCodeFileName
            // 
            this.coluCodeFileName.Caption = "零件编号";
            this.coluCodeFileName.ColumnName = "CodeFileName";
            // 
            // coluParentCodeFileName
            // 
            this.coluParentCodeFileName.Caption = "父零件编号";
            this.coluParentCodeFileName.ColumnName = "ParentCodeFileName";
            // 
            // coluCodeName
            // 
            this.coluCodeName.Caption = "零件名称";
            this.coluCodeName.ColumnName = "CodeName";
            // 
            // coluAutoId
            // 
            this.coluAutoId.ColumnName = "AutoId";
            this.coluAutoId.DataType = typeof(int);
            // 
            // coluPbBomNo
            // 
            this.coluPbBomNo.Caption = "BOM编号";
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
            // FrmPBDesignBom_InputNumber
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(704, 521);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPBDesignBom_InputNumber";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "输入数量";
            this.Text = "输入数量";
            this.Load += new System.EventHandler(this.FrmPBDesignBom_InputNumber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textCodeFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabCtl)).EndInit();
            this.TabCtl.ResumeLayout(false);
            this.PageList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditIsUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinRemainQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_DesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DesignBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDesignBom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.SpinEdit spinNumber;
        private DevExpress.XtraEditors.LabelControl labNumber;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraTab.XtraTabControl TabCtl;
        private DevExpress.XtraTab.XtraTabPage PageList;
        private DevExpress.XtraTreeList.TreeList treeListDesignBom;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentCodeFileName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAutoId1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTotalQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeFileName1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeName1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHasLevel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsUse;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckEditIsUse;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRemainQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinRemainQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPbBomNo;
        private System.Windows.Forms.BindingSource bindingSource_DesignBom;
        public System.Data.DataSet dataSet_DesignBom;
        private System.Data.DataTable dataTableDesignBom;
        private System.Data.DataColumn coluReId;
        private System.Data.DataColumn coluReParent;
        private System.Data.DataColumn coluCodeFileName;
        private System.Data.DataColumn coluParentCodeFileName;
        private System.Data.DataColumn coluCodeName;
        private System.Data.DataColumn coluAutoId;
        private System.Data.DataColumn coluPbBomNo;
        private System.Data.DataColumn coluIsUse;
        private System.Data.DataColumn coluTotalQty;
        private System.Data.DataColumn coluRemainQty;
        private System.Data.DataColumn coluHasLevel;
        private DevExpress.XtraEditors.LabelControl labPartsCodeId;
        private DevExpress.XtraEditors.TextEdit textCodeFileName;
    }
}