namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWorkFlowModuleProper
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
            this.dSWorkFlowModuleProper = new System.Data.DataSet();
            this.TableWorkFlowModuleProper = new System.Data.DataTable();
            this.ColAutoId = new System.Data.DataColumn();
            this.ColFlowModuleId = new System.Data.DataColumn();
            this.ColProperName = new System.Data.DataColumn();
            this.ColProperText = new System.Data.DataColumn();
            this.ColProper = new System.Data.DataColumn();
            this.ColFlowModuleText = new System.Data.DataColumn();
            this.bSWorkFlowModuleProper = new System.Windows.Forms.BindingSource(this.components);
            this.pnlToolBar = new DevExpress.XtraEditors.PanelControl();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.searchLookUplabProper = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchLookUpFlowModuleId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpFlowModuleIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColFlowModuleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFlowModuleText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFlowModuleFormName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textProperName = new DevExpress.XtraEditors.TextEdit();
            this.textProperText = new DevExpress.XtraEditors.TextEdit();
            this.labProper = new DevExpress.XtraEditors.LabelControl();
            this.labProperText = new DevExpress.XtraEditors.LabelControl();
            this.labProperName = new DevExpress.XtraEditors.LabelControl();
            this.labFlowModuleId = new DevExpress.XtraEditors.LabelControl();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridCrlWorkFlowModuleProper = new DevExpress.XtraGrid.GridControl();
            this.gridViewWorkFlowModuleProper = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluFlowModuleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowModuleText1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluProperName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluProperText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluProper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemSearchProper = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.dSWorkFlowModuleProper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWorkFlowModuleProper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSWorkFlowModuleProper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUplabProper.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpFlowModuleId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpFlowModuleIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProperName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProperText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlWorkFlowModuleProper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWorkFlowModuleProper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemSearchProper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dSWorkFlowModuleProper
            // 
            this.dSWorkFlowModuleProper.DataSetName = "NewDataSet";
            this.dSWorkFlowModuleProper.Tables.AddRange(new System.Data.DataTable[] {
            this.TableWorkFlowModuleProper});
            // 
            // TableWorkFlowModuleProper
            // 
            this.TableWorkFlowModuleProper.Columns.AddRange(new System.Data.DataColumn[] {
            this.ColAutoId,
            this.ColFlowModuleId,
            this.ColProperName,
            this.ColProperText,
            this.ColProper,
            this.ColFlowModuleText});
            this.TableWorkFlowModuleProper.TableName = "WorkFlowModuleProper";
            // 
            // ColAutoId
            // 
            this.ColAutoId.ColumnName = "AutoId";
            this.ColAutoId.DataType = typeof(int);
            // 
            // ColFlowModuleId
            // 
            this.ColFlowModuleId.Caption = "业务模块编号";
            this.ColFlowModuleId.ColumnName = "FlowModuleId";
            // 
            // ColProperName
            // 
            this.ColProperName.Caption = "数据库列名";
            this.ColProperName.ColumnName = "ProperName";
            // 
            // ColProperText
            // 
            this.ColProperText.Caption = "说明";
            this.ColProperText.ColumnName = "ProperText";
            // 
            // ColProper
            // 
            this.ColProper.Caption = "数据类型";
            this.ColProper.ColumnName = "Proper";
            this.ColProper.DataType = typeof(int);
            // 
            // ColFlowModuleText
            // 
            this.ColFlowModuleText.Caption = "业务模块名称";
            this.ColFlowModuleText.ColumnName = "FlowModuleText";
            // 
            // bSWorkFlowModuleProper
            // 
            this.bSWorkFlowModuleProper.DataMember = "WorkFlowModuleProper";
            this.bSWorkFlowModuleProper.DataSource = this.dSWorkFlowModuleProper;
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(1043, 40);
            this.pnlToolBar.TabIndex = 2;
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.searchLookUplabProper);
            this.pnlEdit.Controls.Add(this.searchLookUpFlowModuleId);
            this.pnlEdit.Controls.Add(this.textProperName);
            this.pnlEdit.Controls.Add(this.textProperText);
            this.pnlEdit.Controls.Add(this.labProper);
            this.pnlEdit.Controls.Add(this.labProperText);
            this.pnlEdit.Controls.Add(this.labProperName);
            this.pnlEdit.Controls.Add(this.labFlowModuleId);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEdit.Location = new System.Drawing.Point(0, 40);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(1043, 97);
            this.pnlEdit.TabIndex = 6;
            // 
            // searchLookUplabProper
            // 
            this.searchLookUplabProper.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkFlowModuleProper, "Proper", true));
            this.searchLookUplabProper.Location = new System.Drawing.Point(438, 55);
            this.searchLookUplabProper.Name = "searchLookUplabProper";
            this.searchLookUplabProper.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUplabProper.Properties.DisplayMember = "DataTypeName";
            this.searchLookUplabProper.Properties.NullText = "";
            this.searchLookUplabProper.Properties.ValueMember = "AutoId";
            this.searchLookUplabProper.Properties.View = this.gridView1;
            this.searchLookUplabProper.Size = new System.Drawing.Size(200, 20);
            this.searchLookUplabProper.TabIndex = 3;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.IndicatorWidth = 60;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "数据类型名称";
            this.gridColumn4.FieldName = "DataTypeName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "AutoId";
            this.gridColumn5.FieldName = "AutoId";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // searchLookUpFlowModuleId
            // 
            this.searchLookUpFlowModuleId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkFlowModuleProper, "FlowModuleId", true));
            this.searchLookUpFlowModuleId.EnterMoveNextControl = true;
            this.searchLookUpFlowModuleId.Location = new System.Drawing.Point(128, 21);
            this.searchLookUpFlowModuleId.Name = "searchLookUpFlowModuleId";
            this.searchLookUpFlowModuleId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpFlowModuleId.Properties.DisplayMember = "FlowModuleText";
            this.searchLookUpFlowModuleId.Properties.NullText = "";
            this.searchLookUpFlowModuleId.Properties.ValueMember = "FlowModuleId";
            this.searchLookUpFlowModuleId.Properties.View = this.searchLookUpFlowModuleIdView;
            this.searchLookUpFlowModuleId.Size = new System.Drawing.Size(200, 20);
            this.searchLookUpFlowModuleId.TabIndex = 0;
            // 
            // searchLookUpFlowModuleIdView
            // 
            this.searchLookUpFlowModuleIdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColFlowModuleId,
            this.gridColFlowModuleText,
            this.gridColFlowModuleFormName,
            this.gridColAutoId});
            this.searchLookUpFlowModuleIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpFlowModuleIdView.IndicatorWidth = 60;
            this.searchLookUpFlowModuleIdView.Name = "searchLookUpFlowModuleIdView";
            this.searchLookUpFlowModuleIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpFlowModuleIdView.OptionsView.ShowGroupPanel = false;
            this.searchLookUpFlowModuleIdView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.searchLookUpFlowModuleIdView_CustomDrawRowIndicator);
            // 
            // gridColFlowModuleId
            // 
            this.gridColFlowModuleId.Caption = "模块编号";
            this.gridColFlowModuleId.FieldName = "FlowModuleId";
            this.gridColFlowModuleId.Name = "gridColFlowModuleId";
            this.gridColFlowModuleId.Visible = true;
            this.gridColFlowModuleId.VisibleIndex = 0;
            // 
            // gridColFlowModuleText
            // 
            this.gridColFlowModuleText.Caption = "模块名称";
            this.gridColFlowModuleText.FieldName = "FlowModuleText";
            this.gridColFlowModuleText.Name = "gridColFlowModuleText";
            this.gridColFlowModuleText.Visible = true;
            this.gridColFlowModuleText.VisibleIndex = 1;
            // 
            // gridColFlowModuleFormName
            // 
            this.gridColFlowModuleFormName.Caption = "项目窗体名称";
            this.gridColFlowModuleFormName.FieldName = "FlowModuleFormName";
            this.gridColFlowModuleFormName.Name = "gridColFlowModuleFormName";
            this.gridColFlowModuleFormName.Visible = true;
            this.gridColFlowModuleFormName.VisibleIndex = 2;
            // 
            // gridColAutoId
            // 
            this.gridColAutoId.Caption = "AutoId";
            this.gridColAutoId.FieldName = "AutoId";
            this.gridColAutoId.Name = "gridColAutoId";
            // 
            // textProperName
            // 
            this.textProperName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkFlowModuleProper, "ProperName", true));
            this.textProperName.EnterMoveNextControl = true;
            this.textProperName.Location = new System.Drawing.Point(438, 21);
            this.textProperName.Name = "textProperName";
            this.textProperName.Size = new System.Drawing.Size(200, 20);
            this.textProperName.TabIndex = 1;
            // 
            // textProperText
            // 
            this.textProperText.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkFlowModuleProper, "ProperText", true));
            this.textProperText.EnterMoveNextControl = true;
            this.textProperText.Location = new System.Drawing.Point(128, 55);
            this.textProperText.Name = "textProperText";
            this.textProperText.Size = new System.Drawing.Size(200, 20);
            this.textProperText.TabIndex = 2;
            // 
            // labProper
            // 
            this.labProper.Location = new System.Drawing.Point(360, 58);
            this.labProper.Name = "labProper";
            this.labProper.Size = new System.Drawing.Size(48, 14);
            this.labProper.TabIndex = 15;
            this.labProper.Text = "数据类型";
            // 
            // labProperText
            // 
            this.labProperText.Location = new System.Drawing.Point(36, 58);
            this.labProperText.Name = "labProperText";
            this.labProperText.Size = new System.Drawing.Size(24, 14);
            this.labProperText.TabIndex = 14;
            this.labProperText.Text = "说明";
            // 
            // labProperName
            // 
            this.labProperName.Location = new System.Drawing.Point(360, 24);
            this.labProperName.Name = "labProperName";
            this.labProperName.Size = new System.Drawing.Size(60, 14);
            this.labProperName.TabIndex = 13;
            this.labProperName.Text = "数据库列名";
            // 
            // labFlowModuleId
            // 
            this.labFlowModuleId.Location = new System.Drawing.Point(36, 24);
            this.labFlowModuleId.Name = "labFlowModuleId";
            this.labFlowModuleId.Size = new System.Drawing.Size(72, 14);
            this.labFlowModuleId.TabIndex = 12;
            this.labFlowModuleId.Text = "业务模块名称";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridCrlWorkFlowModuleProper);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 137);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1043, 488);
            this.pnlGrid.TabIndex = 7;
            // 
            // gridCrlWorkFlowModuleProper
            // 
            this.gridCrlWorkFlowModuleProper.DataSource = this.bSWorkFlowModuleProper;
            this.gridCrlWorkFlowModuleProper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlWorkFlowModuleProper.Location = new System.Drawing.Point(2, 2);
            this.gridCrlWorkFlowModuleProper.MainView = this.gridViewWorkFlowModuleProper;
            this.gridCrlWorkFlowModuleProper.Name = "gridCrlWorkFlowModuleProper";
            this.gridCrlWorkFlowModuleProper.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemSearchProper});
            this.gridCrlWorkFlowModuleProper.Size = new System.Drawing.Size(1039, 484);
            this.gridCrlWorkFlowModuleProper.TabIndex = 0;
            this.gridCrlWorkFlowModuleProper.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWorkFlowModuleProper});
            // 
            // gridViewWorkFlowModuleProper
            // 
            this.gridViewWorkFlowModuleProper.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.coluFlowModuleId,
            this.colFlowModuleText1,
            this.coluProperName,
            this.coluProperText,
            this.coluProper});
            this.gridViewWorkFlowModuleProper.GridControl = this.gridCrlWorkFlowModuleProper;
            this.gridViewWorkFlowModuleProper.IndicatorWidth = 40;
            this.gridViewWorkFlowModuleProper.Name = "gridViewWorkFlowModuleProper";
            this.gridViewWorkFlowModuleProper.OptionsBehavior.Editable = false;
            this.gridViewWorkFlowModuleProper.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewWorkFlowModuleProper.OptionsView.ColumnAutoWidth = false;
            this.gridViewWorkFlowModuleProper.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewWorkFlowModuleProper.OptionsView.ShowFooter = true;
            this.gridViewWorkFlowModuleProper.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "AutoId";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // coluFlowModuleId
            // 
            this.coluFlowModuleId.AppearanceHeader.Options.UseTextOptions = true;
            this.coluFlowModuleId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coluFlowModuleId.FieldName = "FlowModuleId";
            this.coluFlowModuleId.Name = "coluFlowModuleId";
            this.coluFlowModuleId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProjectNo", "共计{0}条")});
            this.coluFlowModuleId.Visible = true;
            this.coluFlowModuleId.VisibleIndex = 0;
            this.coluFlowModuleId.Width = 160;
            // 
            // colFlowModuleText1
            // 
            this.colFlowModuleText1.AppearanceHeader.Options.UseTextOptions = true;
            this.colFlowModuleText1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFlowModuleText1.FieldName = "FlowModuleText";
            this.colFlowModuleText1.Name = "colFlowModuleText1";
            this.colFlowModuleText1.Visible = true;
            this.colFlowModuleText1.VisibleIndex = 1;
            this.colFlowModuleText1.Width = 160;
            // 
            // coluProperName
            // 
            this.coluProperName.AppearanceHeader.Options.UseTextOptions = true;
            this.coluProperName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coluProperName.FieldName = "ProperName";
            this.coluProperName.Name = "coluProperName";
            this.coluProperName.Visible = true;
            this.coluProperName.VisibleIndex = 2;
            this.coluProperName.Width = 160;
            // 
            // coluProperText
            // 
            this.coluProperText.AppearanceHeader.Options.UseTextOptions = true;
            this.coluProperText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coluProperText.FieldName = "ProperText";
            this.coluProperText.Name = "coluProperText";
            this.coluProperText.Visible = true;
            this.coluProperText.VisibleIndex = 3;
            this.coluProperText.Width = 160;
            // 
            // coluProper
            // 
            this.coluProper.AppearanceHeader.Options.UseTextOptions = true;
            this.coluProper.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coluProper.ColumnEdit = this.repItemSearchProper;
            this.coluProper.FieldName = "Proper";
            this.coluProper.Name = "coluProper";
            this.coluProper.Visible = true;
            this.coluProper.VisibleIndex = 4;
            this.coluProper.Width = 200;
            // 
            // repItemSearchProper
            // 
            this.repItemSearchProper.AutoHeight = false;
            this.repItemSearchProper.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemSearchProper.DisplayMember = "DataTypeName";
            this.repItemSearchProper.Name = "repItemSearchProper";
            this.repItemSearchProper.NullText = "";
            this.repItemSearchProper.ValueMember = "AutoId";
            this.repItemSearchProper.View = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // FrmWorkFlowModuleProper
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1043, 625);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "FrmWorkFlowModuleProper";
            this.TabText = "审核流-模块字段";
            this.Text = "审核流-模块字段";
            this.Load += new System.EventHandler(this.FrmWorkFlowModuleProper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSWorkFlowModuleProper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWorkFlowModuleProper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSWorkFlowModuleProper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUplabProper.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpFlowModuleId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpFlowModuleIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProperName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textProperText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlWorkFlowModuleProper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWorkFlowModuleProper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemSearchProper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dSWorkFlowModuleProper;
        private System.Data.DataTable TableWorkFlowModuleProper;
        private System.Data.DataColumn ColAutoId;
        private System.Data.DataColumn ColFlowModuleId;
        private System.Data.DataColumn ColProperName;
        private System.Data.DataColumn ColProperText;
        private System.Data.DataColumn ColProper;
        private System.Windows.Forms.BindingSource bSWorkFlowModuleProper;
        private DevExpress.XtraEditors.PanelControl pnlToolBar;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.TextEdit textProperName;
        private DevExpress.XtraEditors.TextEdit textProperText;
        private DevExpress.XtraEditors.LabelControl labProper;
        private DevExpress.XtraEditors.LabelControl labProperText;
        private DevExpress.XtraEditors.LabelControl labProperName;
        private DevExpress.XtraEditors.LabelControl labFlowModuleId;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl gridCrlWorkFlowModuleProper;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWorkFlowModuleProper;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn coluFlowModuleId;
        private DevExpress.XtraGrid.Columns.GridColumn coluProperName;
        private DevExpress.XtraGrid.Columns.GridColumn coluProperText;
        private DevExpress.XtraGrid.Columns.GridColumn coluProper;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpFlowModuleId;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpFlowModuleIdView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFlowModuleId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFlowModuleText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFlowModuleFormName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAutoId;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUplabProper;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repItemSearchProper;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Data.DataColumn ColFlowModuleText;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowModuleText1;
    }
}