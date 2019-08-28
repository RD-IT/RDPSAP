namespace PSAP.VIEW.BSVIEW
{
    partial class FrmRepertoryLocationInfo
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
            this.dSLocationInfo = new System.Data.DataSet();
            this.TableLocationInfo = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColRepertoryId = new System.Data.DataColumn();
            this.dataColLocationNo = new System.Data.DataColumn();
            this.dataColLocationName = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColCreatorIp = new System.Data.DataColumn();
            this.dataColRemark = new System.Data.DataColumn();
            this.bSLocationInfo = new System.Windows.Forms.BindingSource(this.components);
            this.pnlToolBar = new DevExpress.XtraEditors.PanelControl();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.labRemark = new DevExpress.XtraEditors.LabelControl();
            this.textRemark = new DevExpress.XtraEditors.TextEdit();
            this.labRepertoryId = new DevExpress.XtraEditors.LabelControl();
            this.lookUpRepertoryId = new DevExpress.XtraEditors.LookUpEdit();
            this.labLocationName = new DevExpress.XtraEditors.LabelControl();
            this.labLocationNo = new DevExpress.XtraEditors.LabelControl();
            this.textLocationName = new DevExpress.XtraEditors.TextEdit();
            this.textLocationNo = new DevExpress.XtraEditors.TextEdit();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridCrlLocationInfo = new DevExpress.XtraGrid.GridControl();
            this.gridViewLocationInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepertoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dSLocationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLocationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSLocationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textLocationName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textLocationNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlLocationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLocationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            this.SuspendLayout();
            // 
            // dSLocationInfo
            // 
            this.dSLocationInfo.DataSetName = "NewDataSet";
            this.dSLocationInfo.Tables.AddRange(new System.Data.DataTable[] {
            this.TableLocationInfo});
            // 
            // TableLocationInfo
            // 
            this.TableLocationInfo.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColRepertoryId,
            this.dataColLocationNo,
            this.dataColLocationName,
            this.dataColCreator,
            this.dataColCreatorIp,
            this.dataColRemark});
            this.TableLocationInfo.TableName = "LocationInfo";
            this.TableLocationInfo.TableNewRow += new System.Data.DataTableNewRowEventHandler(this.TableLocationInfo_TableNewRow);
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColRepertoryId
            // 
            this.dataColRepertoryId.Caption = "所属仓库";
            this.dataColRepertoryId.ColumnName = "RepertoryId";
            this.dataColRepertoryId.DataType = typeof(int);
            // 
            // dataColLocationNo
            // 
            this.dataColLocationNo.Caption = "仓位编号";
            this.dataColLocationNo.ColumnName = "LocationNo";
            // 
            // dataColLocationName
            // 
            this.dataColLocationName.Caption = "仓位名称";
            this.dataColLocationName.ColumnName = "LocationName";
            // 
            // dataColCreator
            // 
            this.dataColCreator.Caption = "登记人";
            this.dataColCreator.ColumnName = "Creator";
            this.dataColCreator.DataType = typeof(int);
            // 
            // dataColCreatorIp
            // 
            this.dataColCreatorIp.Caption = "登记人IP";
            this.dataColCreatorIp.ColumnName = "CreatorIp";
            // 
            // dataColRemark
            // 
            this.dataColRemark.Caption = "备注";
            this.dataColRemark.ColumnName = "Remark";
            // 
            // bSLocationInfo
            // 
            this.bSLocationInfo.DataMember = "LocationInfo";
            this.bSLocationInfo.DataSource = this.dSLocationInfo;
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(853, 40);
            this.pnlToolBar.TabIndex = 4;
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.labRemark);
            this.pnlEdit.Controls.Add(this.textRemark);
            this.pnlEdit.Controls.Add(this.labRepertoryId);
            this.pnlEdit.Controls.Add(this.lookUpRepertoryId);
            this.pnlEdit.Controls.Add(this.labLocationName);
            this.pnlEdit.Controls.Add(this.labLocationNo);
            this.pnlEdit.Controls.Add(this.textLocationName);
            this.pnlEdit.Controls.Add(this.textLocationNo);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEdit.Location = new System.Drawing.Point(0, 40);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(853, 97);
            this.pnlEdit.TabIndex = 8;
            // 
            // labRemark
            // 
            this.labRemark.Location = new System.Drawing.Point(36, 58);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new System.Drawing.Size(24, 14);
            this.labRemark.TabIndex = 19;
            this.labRemark.Text = "备注";
            // 
            // textRemark
            // 
            this.textRemark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSLocationInfo, "Remark", true));
            this.textRemark.EnterMoveNextControl = true;
            this.textRemark.Location = new System.Drawing.Point(104, 55);
            this.textRemark.Name = "textRemark";
            this.textRemark.Size = new System.Drawing.Size(411, 20);
            this.textRemark.TabIndex = 3;
            // 
            // labRepertoryId
            // 
            this.labRepertoryId.Location = new System.Drawing.Point(542, 24);
            this.labRepertoryId.Name = "labRepertoryId";
            this.labRepertoryId.Size = new System.Drawing.Size(48, 14);
            this.labRepertoryId.TabIndex = 17;
            this.labRepertoryId.Text = "所属仓库";
            // 
            // lookUpRepertoryId
            // 
            this.lookUpRepertoryId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSLocationInfo, "RepertoryId", true));
            this.lookUpRepertoryId.EnterMoveNextControl = true;
            this.lookUpRepertoryId.Location = new System.Drawing.Point(611, 21);
            this.lookUpRepertoryId.Margin = new System.Windows.Forms.Padding(4);
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
            this.lookUpRepertoryId.Size = new System.Drawing.Size(160, 20);
            this.lookUpRepertoryId.TabIndex = 2;
            // 
            // labLocationName
            // 
            this.labLocationName.Location = new System.Drawing.Point(286, 24);
            this.labLocationName.Name = "labLocationName";
            this.labLocationName.Size = new System.Drawing.Size(48, 14);
            this.labLocationName.TabIndex = 15;
            this.labLocationName.Text = "仓位名称";
            // 
            // labLocationNo
            // 
            this.labLocationNo.Location = new System.Drawing.Point(36, 24);
            this.labLocationNo.Name = "labLocationNo";
            this.labLocationNo.Size = new System.Drawing.Size(48, 14);
            this.labLocationNo.TabIndex = 12;
            this.labLocationNo.Text = "仓位编号";
            // 
            // textLocationName
            // 
            this.textLocationName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSLocationInfo, "LocationName", true));
            this.textLocationName.EnterMoveNextControl = true;
            this.textLocationName.Location = new System.Drawing.Point(355, 21);
            this.textLocationName.Name = "textLocationName";
            this.textLocationName.Size = new System.Drawing.Size(160, 20);
            this.textLocationName.TabIndex = 1;
            // 
            // textLocationNo
            // 
            this.textLocationNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSLocationInfo, "LocationNo", true));
            this.textLocationNo.EnterMoveNextControl = true;
            this.textLocationNo.Location = new System.Drawing.Point(104, 21);
            this.textLocationNo.Name = "textLocationNo";
            this.textLocationNo.Size = new System.Drawing.Size(160, 20);
            this.textLocationNo.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridCrlLocationInfo);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 137);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(853, 369);
            this.pnlGrid.TabIndex = 9;
            // 
            // gridCrlLocationInfo
            // 
            this.gridCrlLocationInfo.DataSource = this.bSLocationInfo;
            this.gridCrlLocationInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlLocationInfo.Location = new System.Drawing.Point(2, 2);
            this.gridCrlLocationInfo.MainView = this.gridViewLocationInfo;
            this.gridCrlLocationInfo.Name = "gridCrlLocationInfo";
            this.gridCrlLocationInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpRepertoryId,
            this.repLookUpCreator});
            this.gridCrlLocationInfo.Size = new System.Drawing.Size(849, 365);
            this.gridCrlLocationInfo.TabIndex = 0;
            this.gridCrlLocationInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLocationInfo});
            // 
            // gridViewLocationInfo
            // 
            this.gridViewLocationInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colLocationNo,
            this.colLocationName,
            this.colRepertoryId,
            this.colCreator,
            this.colRemark});
            this.gridViewLocationInfo.GridControl = this.gridCrlLocationInfo;
            this.gridViewLocationInfo.IndicatorWidth = 40;
            this.gridViewLocationInfo.Name = "gridViewLocationInfo";
            this.gridViewLocationInfo.OptionsBehavior.Editable = false;
            this.gridViewLocationInfo.OptionsFilter.AllowFilterEditor = false;
            this.gridViewLocationInfo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewLocationInfo.OptionsView.ColumnAutoWidth = false;
            this.gridViewLocationInfo.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewLocationInfo.OptionsView.ShowFooter = true;
            this.gridViewLocationInfo.OptionsView.ShowGroupPanel = false;
            // 
            // colAutoId
            // 
            this.colAutoId.AppearanceHeader.Options.UseTextOptions = true;
            this.colAutoId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colLocationNo
            // 
            this.colLocationNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colLocationNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLocationNo.FieldName = "LocationNo";
            this.colLocationNo.Name = "colLocationNo";
            this.colLocationNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "LocationyNo", "共计{0}条")});
            this.colLocationNo.Visible = true;
            this.colLocationNo.VisibleIndex = 0;
            this.colLocationNo.Width = 160;
            // 
            // colLocationName
            // 
            this.colLocationName.AppearanceHeader.Options.UseTextOptions = true;
            this.colLocationName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLocationName.FieldName = "LocationName";
            this.colLocationName.Name = "colLocationName";
            this.colLocationName.Visible = true;
            this.colLocationName.VisibleIndex = 1;
            this.colLocationName.Width = 160;
            // 
            // colRepertoryId
            // 
            this.colRepertoryId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRepertoryId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRepertoryId.ColumnEdit = this.repLookUpRepertoryId;
            this.colRepertoryId.FieldName = "RepertoryId";
            this.colRepertoryId.Name = "colRepertoryId";
            this.colRepertoryId.Visible = true;
            this.colRepertoryId.VisibleIndex = 2;
            this.colRepertoryId.Width = 160;
            // 
            // repLookUpRepertoryId
            // 
            this.repLookUpRepertoryId.AutoHeight = false;
            this.repLookUpRepertoryId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpRepertoryId.DisplayMember = "RepertoryName";
            this.repLookUpRepertoryId.Name = "repLookUpRepertoryId";
            this.repLookUpRepertoryId.NullText = "";
            this.repLookUpRepertoryId.ValueMember = "AutoId";
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
            // colRemark
            // 
            this.colRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 3;
            this.colRemark.Width = 300;
            // 
            // FrmRepertoryLocationInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(853, 506);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "FrmRepertoryLocationInfo";
            this.TabText = "仓位信息";
            this.Text = "仓位信息";
            this.Load += new System.EventHandler(this.FrmRepertoryLocationInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSLocationInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLocationInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSLocationInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpRepertoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textLocationName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textLocationNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlLocationInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLocationInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dSLocationInfo;
        private System.Data.DataTable TableLocationInfo;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColRepertoryId;
        private System.Data.DataColumn dataColLocationNo;
        private System.Data.DataColumn dataColLocationName;
        private System.Data.DataColumn dataColCreator;
        private System.Data.DataColumn dataColCreatorIp;
        private System.Data.DataColumn dataColRemark;
        private System.Windows.Forms.BindingSource bSLocationInfo;
        private DevExpress.XtraEditors.PanelControl pnlToolBar;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.LabelControl labLocationName;
        private DevExpress.XtraEditors.LabelControl labLocationNo;
        private DevExpress.XtraEditors.TextEdit textLocationName;
        private DevExpress.XtraEditors.TextEdit textLocationNo;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl gridCrlLocationInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLocationInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationNo;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationName;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryId;
        private DevExpress.XtraEditors.LabelControl labRepertoryId;
        private DevExpress.XtraEditors.LookUpEdit lookUpRepertoryId;
        private DevExpress.XtraEditors.LabelControl labRemark;
        private DevExpress.XtraEditors.TextEdit textRemark;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpRepertoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
    }
}