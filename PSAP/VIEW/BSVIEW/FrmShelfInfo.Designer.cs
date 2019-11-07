namespace PSAP.VIEW.BSVIEW
{
    partial class FrmShelfInfo
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
            this.dSShelfInfo = new System.Data.DataSet();
            this.TableShelfInfo = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColShelfNo = new System.Data.DataColumn();
            this.dataColShelfLocation = new System.Data.DataColumn();
            this.dataColShelfDescription = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColCreatorIp = new System.Data.DataColumn();
            this.dataColRemark = new System.Data.DataColumn();
            this.dataColRepertoryInfoId = new System.Data.DataColumn();
            this.dataColRepertoryLocationId = new System.Data.DataColumn();
            this.bSShelfInfo = new System.Windows.Forms.BindingSource(this.components);
            this.pnlToolBar = new DevExpress.XtraEditors.PanelControl();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.labRemark = new DevExpress.XtraEditors.LabelControl();
            this.textRemark = new DevExpress.XtraEditors.TextEdit();
            this.labRepertoryLocationId = new DevExpress.XtraEditors.LabelControl();
            this.textShelfDescription = new DevExpress.XtraEditors.TextEdit();
            this.textShelfLocation = new DevExpress.XtraEditors.TextEdit();
            this.textShelfNo = new DevExpress.XtraEditors.TextEdit();
            this.labShelfDescription = new DevExpress.XtraEditors.LabelControl();
            this.labShelfLocation = new DevExpress.XtraEditors.LabelControl();
            this.labShelfNo = new DevExpress.XtraEditors.LabelControl();
            this.SearchRepertoryLocationId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.SearchRepertoryLocationIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridCrlShelfInfo = new DevExpress.XtraGrid.GridControl();
            this.gridViewShelfInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRepertoryInfoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryInfoId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRepertoryLocationId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpRepertoryLocationId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLookUpCreator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiHjbhbnwk = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHjwzbnwk = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dSShelfInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableShelfInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSShelfInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textShelfDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textShelfLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textShelfNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchRepertoryLocationId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchRepertoryLocationIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlShelfInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewShelfInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryInfoId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryLocationId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSShelfInfo
            // 
            this.dSShelfInfo.DataSetName = "NewDataSet";
            this.dSShelfInfo.Tables.AddRange(new System.Data.DataTable[] {
            this.TableShelfInfo});
            // 
            // TableShelfInfo
            // 
            this.TableShelfInfo.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColShelfNo,
            this.dataColShelfLocation,
            this.dataColShelfDescription,
            this.dataColCreator,
            this.dataColCreatorIp,
            this.dataColRemark,
            this.dataColRepertoryInfoId,
            this.dataColRepertoryLocationId});
            this.TableShelfInfo.TableName = "ShelfInfo";
            this.TableShelfInfo.TableNewRow += new System.Data.DataTableNewRowEventHandler(this.TableShelfInfo_TableNewRow);
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColShelfNo
            // 
            this.dataColShelfNo.Caption = "货架号";
            this.dataColShelfNo.ColumnName = "ShelfNo";
            // 
            // dataColShelfLocation
            // 
            this.dataColShelfLocation.Caption = "货架位置";
            this.dataColShelfLocation.ColumnName = "ShelfLocation";
            // 
            // dataColShelfDescription
            // 
            this.dataColShelfDescription.Caption = "货架说明";
            this.dataColShelfDescription.ColumnName = "ShelfDescription";
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
            // dataColRepertoryInfoId
            // 
            this.dataColRepertoryInfoId.Caption = "所属仓库";
            this.dataColRepertoryInfoId.ColumnName = "RepertoryInfoId";
            this.dataColRepertoryInfoId.DataType = typeof(int);
            // 
            // dataColRepertoryLocationId
            // 
            this.dataColRepertoryLocationId.Caption = "所属仓位";
            this.dataColRepertoryLocationId.ColumnName = "RepertoryLocationId";
            this.dataColRepertoryLocationId.DataType = typeof(int);
            // 
            // bSShelfInfo
            // 
            this.bSShelfInfo.DataMember = "ShelfInfo";
            this.bSShelfInfo.DataSource = this.dSShelfInfo;
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(1170, 40);
            this.pnlToolBar.TabIndex = 1;
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.labRemark);
            this.pnlEdit.Controls.Add(this.textRemark);
            this.pnlEdit.Controls.Add(this.labRepertoryLocationId);
            this.pnlEdit.Controls.Add(this.textShelfDescription);
            this.pnlEdit.Controls.Add(this.textShelfLocation);
            this.pnlEdit.Controls.Add(this.textShelfNo);
            this.pnlEdit.Controls.Add(this.labShelfDescription);
            this.pnlEdit.Controls.Add(this.labShelfLocation);
            this.pnlEdit.Controls.Add(this.labShelfNo);
            this.pnlEdit.Controls.Add(this.SearchRepertoryLocationId);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEdit.Location = new System.Drawing.Point(0, 40);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(1170, 131);
            this.pnlEdit.TabIndex = 5;
            // 
            // labRemark
            // 
            this.labRemark.Location = new System.Drawing.Point(36, 92);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new System.Drawing.Size(24, 14);
            this.labRemark.TabIndex = 21;
            this.labRemark.Text = "备注";
            // 
            // textRemark
            // 
            this.textRemark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSShelfInfo, "Remark", true));
            this.textRemark.EnterMoveNextControl = true;
            this.textRemark.Location = new System.Drawing.Point(104, 89);
            this.textRemark.Name = "textRemark";
            this.textRemark.Size = new System.Drawing.Size(411, 20);
            this.textRemark.TabIndex = 4;
            // 
            // labRepertoryLocationId
            // 
            this.labRepertoryLocationId.Location = new System.Drawing.Point(542, 24);
            this.labRepertoryLocationId.Name = "labRepertoryLocationId";
            this.labRepertoryLocationId.Size = new System.Drawing.Size(48, 14);
            this.labRepertoryLocationId.TabIndex = 19;
            this.labRepertoryLocationId.Text = "所属仓位";
            // 
            // textShelfDescription
            // 
            this.textShelfDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSShelfInfo, "ShelfDescription", true));
            this.textShelfDescription.EnterMoveNextControl = true;
            this.textShelfDescription.Location = new System.Drawing.Point(104, 55);
            this.textShelfDescription.Name = "textShelfDescription";
            this.textShelfDescription.Size = new System.Drawing.Size(411, 20);
            this.textShelfDescription.TabIndex = 3;
            // 
            // textShelfLocation
            // 
            this.textShelfLocation.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSShelfInfo, "ShelfLocation", true));
            this.textShelfLocation.EnterMoveNextControl = true;
            this.textShelfLocation.Location = new System.Drawing.Point(355, 21);
            this.textShelfLocation.Name = "textShelfLocation";
            this.textShelfLocation.Size = new System.Drawing.Size(160, 20);
            this.textShelfLocation.TabIndex = 1;
            // 
            // textShelfNo
            // 
            this.textShelfNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSShelfInfo, "ShelfNo", true));
            this.textShelfNo.EnterMoveNextControl = true;
            this.textShelfNo.Location = new System.Drawing.Point(104, 21);
            this.textShelfNo.Name = "textShelfNo";
            this.textShelfNo.Size = new System.Drawing.Size(160, 20);
            this.textShelfNo.TabIndex = 0;
            // 
            // labShelfDescription
            // 
            this.labShelfDescription.Location = new System.Drawing.Point(36, 58);
            this.labShelfDescription.Name = "labShelfDescription";
            this.labShelfDescription.Size = new System.Drawing.Size(48, 14);
            this.labShelfDescription.TabIndex = 15;
            this.labShelfDescription.Text = "货架说明";
            // 
            // labShelfLocation
            // 
            this.labShelfLocation.Location = new System.Drawing.Point(286, 24);
            this.labShelfLocation.Name = "labShelfLocation";
            this.labShelfLocation.Size = new System.Drawing.Size(48, 14);
            this.labShelfLocation.TabIndex = 14;
            this.labShelfLocation.Text = "货架位置";
            // 
            // labShelfNo
            // 
            this.labShelfNo.Location = new System.Drawing.Point(36, 24);
            this.labShelfNo.Name = "labShelfNo";
            this.labShelfNo.Size = new System.Drawing.Size(36, 14);
            this.labShelfNo.TabIndex = 12;
            this.labShelfNo.Text = "货架号";
            // 
            // SearchRepertoryLocationId
            // 
            this.SearchRepertoryLocationId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSShelfInfo, "RepertoryLocationId", true));
            this.SearchRepertoryLocationId.EnterMoveNextControl = true;
            this.SearchRepertoryLocationId.Location = new System.Drawing.Point(611, 21);
            this.SearchRepertoryLocationId.Margin = new System.Windows.Forms.Padding(4);
            this.SearchRepertoryLocationId.Name = "SearchRepertoryLocationId";
            this.SearchRepertoryLocationId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchRepertoryLocationId.Properties.View = this.SearchRepertoryLocationIdView;
            this.SearchRepertoryLocationId.Size = new System.Drawing.Size(160, 20);
            this.SearchRepertoryLocationId.TabIndex = 2;
            // 
            // SearchRepertoryLocationIdView
            // 
            this.SearchRepertoryLocationIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.SearchRepertoryLocationIdView.Name = "SearchRepertoryLocationIdView";
            this.SearchRepertoryLocationIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.SearchRepertoryLocationIdView.OptionsView.ShowGroupPanel = false;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridCrlShelfInfo);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 171);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1170, 394);
            this.pnlGrid.TabIndex = 6;
            // 
            // gridCrlShelfInfo
            // 
            this.gridCrlShelfInfo.DataSource = this.bSShelfInfo;
            this.gridCrlShelfInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlShelfInfo.Location = new System.Drawing.Point(2, 2);
            this.gridCrlShelfInfo.MainView = this.gridViewShelfInfo;
            this.gridCrlShelfInfo.Name = "gridCrlShelfInfo";
            this.gridCrlShelfInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLookUpCreator,
            this.repLookUpRepertoryInfoId,
            this.repLookUpRepertoryLocationId});
            this.gridCrlShelfInfo.Size = new System.Drawing.Size(1166, 390);
            this.gridCrlShelfInfo.TabIndex = 0;
            this.gridCrlShelfInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewShelfInfo});
            // 
            // gridViewShelfInfo
            // 
            this.gridViewShelfInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colShelfNo,
            this.colShelfLocation,
            this.colShelfDescription,
            this.colRepertoryInfoId,
            this.colRepertoryLocationId,
            this.colRemark,
            this.colCreator});
            this.gridViewShelfInfo.GridControl = this.gridCrlShelfInfo;
            this.gridViewShelfInfo.IndicatorWidth = 40;
            this.gridViewShelfInfo.Name = "gridViewShelfInfo";
            this.gridViewShelfInfo.OptionsBehavior.Editable = false;
            this.gridViewShelfInfo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewShelfInfo.OptionsView.ColumnAutoWidth = false;
            this.gridViewShelfInfo.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewShelfInfo.OptionsView.ShowFooter = true;
            this.gridViewShelfInfo.OptionsView.ShowGroupPanel = false;
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colShelfNo
            // 
            this.colShelfNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colShelfNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShelfNo.FieldName = "ShelfNo";
            this.colShelfNo.Name = "colShelfNo";
            this.colShelfNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProjectNo", "共计{0}条")});
            this.colShelfNo.Visible = true;
            this.colShelfNo.VisibleIndex = 0;
            this.colShelfNo.Width = 160;
            // 
            // colShelfLocation
            // 
            this.colShelfLocation.AppearanceHeader.Options.UseTextOptions = true;
            this.colShelfLocation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShelfLocation.FieldName = "ShelfLocation";
            this.colShelfLocation.Name = "colShelfLocation";
            this.colShelfLocation.Visible = true;
            this.colShelfLocation.VisibleIndex = 1;
            this.colShelfLocation.Width = 160;
            // 
            // colShelfDescription
            // 
            this.colShelfDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colShelfDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShelfDescription.FieldName = "ShelfDescription";
            this.colShelfDescription.Name = "colShelfDescription";
            this.colShelfDescription.Visible = true;
            this.colShelfDescription.VisibleIndex = 2;
            this.colShelfDescription.Width = 200;
            // 
            // colRepertoryInfoId
            // 
            this.colRepertoryInfoId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRepertoryInfoId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRepertoryInfoId.ColumnEdit = this.repLookUpRepertoryInfoId;
            this.colRepertoryInfoId.FieldName = "RepertoryInfoId";
            this.colRepertoryInfoId.Name = "colRepertoryInfoId";
            this.colRepertoryInfoId.Visible = true;
            this.colRepertoryInfoId.VisibleIndex = 3;
            this.colRepertoryInfoId.Width = 130;
            // 
            // repLookUpRepertoryInfoId
            // 
            this.repLookUpRepertoryInfoId.AutoHeight = false;
            this.repLookUpRepertoryInfoId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpRepertoryInfoId.DisplayMember = "RepertoryName";
            this.repLookUpRepertoryInfoId.Name = "repLookUpRepertoryInfoId";
            this.repLookUpRepertoryInfoId.NullText = "";
            this.repLookUpRepertoryInfoId.ValueMember = "AutoId";
            // 
            // colRepertoryLocationId
            // 
            this.colRepertoryLocationId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRepertoryLocationId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRepertoryLocationId.ColumnEdit = this.repLookUpRepertoryLocationId;
            this.colRepertoryLocationId.FieldName = "RepertoryLocationId";
            this.colRepertoryLocationId.Name = "colRepertoryLocationId";
            this.colRepertoryLocationId.Visible = true;
            this.colRepertoryLocationId.VisibleIndex = 4;
            this.colRepertoryLocationId.Width = 130;
            // 
            // repLookUpRepertoryLocationId
            // 
            this.repLookUpRepertoryLocationId.AutoHeight = false;
            this.repLookUpRepertoryLocationId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLookUpRepertoryLocationId.DisplayMember = "LocationName";
            this.repLookUpRepertoryLocationId.Name = "repLookUpRepertoryLocationId";
            this.repLookUpRepertoryLocationId.NullText = "";
            this.repLookUpRepertoryLocationId.ValueMember = "AutoId";
            // 
            // colRemark
            // 
            this.colRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 5;
            this.colRemark.Width = 240;
            // 
            // colCreator
            // 
            this.colCreator.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreator.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreator.ColumnEdit = this.repLookUpCreator;
            this.colCreator.FieldName = "Creator";
            this.colCreator.Name = "colCreator";
            this.colCreator.Visible = true;
            this.colCreator.VisibleIndex = 6;
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
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHjbhbnwk,
            this.tsmiHjwzbnwk});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(257, 48);
            // 
            // tsmiHjbhbnwk
            // 
            this.tsmiHjbhbnwk.Name = "tsmiHjbhbnwk";
            this.tsmiHjbhbnwk.Size = new System.Drawing.Size(256, 22);
            this.tsmiHjbhbnwk.Text = "货架编号不能为空，请重新操作。";
            // 
            // tsmiHjwzbnwk
            // 
            this.tsmiHjwzbnwk.Name = "tsmiHjwzbnwk";
            this.tsmiHjwzbnwk.Size = new System.Drawing.Size(256, 22);
            this.tsmiHjwzbnwk.Text = "货架位置不能为空，请重新操作。";
            // 
            // FrmShelfInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1170, 565);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "FrmShelfInfo";
            this.TabText = "货架信息";
            this.Text = "货架信息";
            this.Load += new System.EventHandler(this.FrmShelfInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSShelfInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableShelfInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSShelfInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textShelfDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textShelfLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textShelfNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchRepertoryLocationId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchRepertoryLocationIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlShelfInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewShelfInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryInfoId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpRepertoryLocationId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLookUpCreator)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dSShelfInfo;
        private System.Data.DataTable TableShelfInfo;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColShelfNo;
        private System.Data.DataColumn dataColShelfLocation;
        private System.Data.DataColumn dataColShelfDescription;
        private System.Windows.Forms.BindingSource bSShelfInfo;
        private DevExpress.XtraEditors.PanelControl pnlToolBar;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.LabelControl labShelfDescription;
        private DevExpress.XtraEditors.LabelControl labShelfLocation;
        private DevExpress.XtraEditors.LabelControl labShelfNo;
        private DevExpress.XtraEditors.TextEdit textShelfDescription;
        private DevExpress.XtraEditors.TextEdit textShelfLocation;
        private DevExpress.XtraEditors.TextEdit textShelfNo;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl gridCrlShelfInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewShelfInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colShelfNo;
        private DevExpress.XtraGrid.Columns.GridColumn colShelfLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colShelfDescription;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiHjbhbnwk;
        private System.Windows.Forms.ToolStripMenuItem tsmiHjwzbnwk;
        private System.Data.DataColumn dataColCreator;
        private System.Data.DataColumn dataColCreatorIp;
        private System.Data.DataColumn dataColRemark;
        private System.Data.DataColumn dataColRepertoryInfoId;
        private System.Data.DataColumn dataColRepertoryLocationId;
        private DevExpress.XtraEditors.LabelControl labRepertoryLocationId;
        private DevExpress.XtraEditors.LabelControl labRemark;
        private DevExpress.XtraEditors.TextEdit textRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryInfoId;
        private DevExpress.XtraGrid.Columns.GridColumn colRepertoryLocationId;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpCreator;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpRepertoryInfoId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookUpRepertoryLocationId;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchRepertoryLocationId;
        private DevExpress.XtraGrid.Views.Grid.GridView SearchRepertoryLocationIdView;
    }
}