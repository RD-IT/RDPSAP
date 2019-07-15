﻿namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWorkFlowModule
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
            this.dSWorkFlowModule = new System.Data.DataSet();
            this.TableWorkFlowModule = new System.Data.DataTable();
            this.ColAutoId = new System.Data.DataColumn();
            this.ColFlowModuleId = new System.Data.DataColumn();
            this.ColFlowModuleText = new System.Data.DataColumn();
            this.ColFlowModuleFormName = new System.Data.DataColumn();
            this.ColFlowModuleTableName = new System.Data.DataColumn();
            this.bSWorkFlowModule = new System.Windows.Forms.BindingSource(this.components);
            this.pnlToolBar = new DevExpress.XtraEditors.PanelControl();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.textFlowModuleText = new DevExpress.XtraEditors.TextEdit();
            this.textFlowModuleTableName = new DevExpress.XtraEditors.TextEdit();
            this.textFlowModuleFormName = new DevExpress.XtraEditors.TextEdit();
            this.textFlowModuleId = new DevExpress.XtraEditors.TextEdit();
            this.labFlowModuleTableName = new DevExpress.XtraEditors.LabelControl();
            this.labFlowModuleFormName = new DevExpress.XtraEditors.LabelControl();
            this.labFlowModuleText = new DevExpress.XtraEditors.LabelControl();
            this.labFlowModuleId = new DevExpress.XtraEditors.LabelControl();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridCrlWorkFlowModule = new DevExpress.XtraGrid.GridControl();
            this.gridViewWorkFlowModule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluFlowModuleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluFlowModuleText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluFlowModuleFormName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluFlowModuleTableName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnModuleProper = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dSWorkFlowModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWorkFlowModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSWorkFlowModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).BeginInit();
            this.pnlToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textFlowModuleText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textFlowModuleTableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textFlowModuleFormName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textFlowModuleId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlWorkFlowModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWorkFlowModule)).BeginInit();
            this.SuspendLayout();
            // 
            // dSWorkFlowModule
            // 
            this.dSWorkFlowModule.DataSetName = "NewDataSet";
            this.dSWorkFlowModule.Tables.AddRange(new System.Data.DataTable[] {
            this.TableWorkFlowModule});
            // 
            // TableWorkFlowModule
            // 
            this.TableWorkFlowModule.Columns.AddRange(new System.Data.DataColumn[] {
            this.ColAutoId,
            this.ColFlowModuleId,
            this.ColFlowModuleText,
            this.ColFlowModuleFormName,
            this.ColFlowModuleTableName});
            this.TableWorkFlowModule.TableName = "WorkFlowModule";
            // 
            // ColAutoId
            // 
            this.ColAutoId.ColumnName = "AutoId";
            this.ColAutoId.DataType = typeof(int);
            // 
            // ColFlowModuleId
            // 
            this.ColFlowModuleId.Caption = "模块编号";
            this.ColFlowModuleId.ColumnName = "FlowModuleId";
            // 
            // ColFlowModuleText
            // 
            this.ColFlowModuleText.Caption = "模块名称";
            this.ColFlowModuleText.ColumnName = "FlowModuleText";
            // 
            // ColFlowModuleFormName
            // 
            this.ColFlowModuleFormName.Caption = "项目窗体名称";
            this.ColFlowModuleFormName.ColumnName = "FlowModuleFormName";
            // 
            // ColFlowModuleTableName
            // 
            this.ColFlowModuleTableName.Caption = "数据库表名";
            this.ColFlowModuleTableName.ColumnName = "FlowModuleTableName";
            // 
            // bSWorkFlowModule
            // 
            this.bSWorkFlowModule.DataMember = "WorkFlowModule";
            this.bSWorkFlowModule.DataSource = this.dSWorkFlowModule;
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Controls.Add(this.btnModuleProper);
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(1081, 40);
            this.pnlToolBar.TabIndex = 1;
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.textFlowModuleText);
            this.pnlEdit.Controls.Add(this.textFlowModuleTableName);
            this.pnlEdit.Controls.Add(this.textFlowModuleFormName);
            this.pnlEdit.Controls.Add(this.textFlowModuleId);
            this.pnlEdit.Controls.Add(this.labFlowModuleTableName);
            this.pnlEdit.Controls.Add(this.labFlowModuleFormName);
            this.pnlEdit.Controls.Add(this.labFlowModuleText);
            this.pnlEdit.Controls.Add(this.labFlowModuleId);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEdit.Location = new System.Drawing.Point(0, 40);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(1081, 97);
            this.pnlEdit.TabIndex = 5;
            // 
            // textFlowModuleText
            // 
            this.textFlowModuleText.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkFlowModule, "FlowModuleText", true));
            this.textFlowModuleText.EnterMoveNextControl = true;
            this.textFlowModuleText.Location = new System.Drawing.Point(438, 21);
            this.textFlowModuleText.Name = "textFlowModuleText";
            this.textFlowModuleText.Size = new System.Drawing.Size(200, 20);
            this.textFlowModuleText.TabIndex = 1;
            // 
            // textFlowModuleTableName
            // 
            this.textFlowModuleTableName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkFlowModule, "FlowModuleTableName", true));
            this.textFlowModuleTableName.Location = new System.Drawing.Point(438, 55);
            this.textFlowModuleTableName.Name = "textFlowModuleTableName";
            this.textFlowModuleTableName.Size = new System.Drawing.Size(200, 20);
            this.textFlowModuleTableName.TabIndex = 3;
            // 
            // textFlowModuleFormName
            // 
            this.textFlowModuleFormName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkFlowModule, "FlowModuleFormName", true));
            this.textFlowModuleFormName.EnterMoveNextControl = true;
            this.textFlowModuleFormName.Location = new System.Drawing.Point(128, 55);
            this.textFlowModuleFormName.Name = "textFlowModuleFormName";
            this.textFlowModuleFormName.Size = new System.Drawing.Size(200, 20);
            this.textFlowModuleFormName.TabIndex = 2;
            // 
            // textFlowModuleId
            // 
            this.textFlowModuleId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkFlowModule, "FlowModuleId", true));
            this.textFlowModuleId.EnterMoveNextControl = true;
            this.textFlowModuleId.Location = new System.Drawing.Point(128, 21);
            this.textFlowModuleId.Name = "textFlowModuleId";
            this.textFlowModuleId.Size = new System.Drawing.Size(200, 20);
            this.textFlowModuleId.TabIndex = 0;
            // 
            // labFlowModuleTableName
            // 
            this.labFlowModuleTableName.Location = new System.Drawing.Point(360, 58);
            this.labFlowModuleTableName.Name = "labFlowModuleTableName";
            this.labFlowModuleTableName.Size = new System.Drawing.Size(60, 14);
            this.labFlowModuleTableName.TabIndex = 15;
            this.labFlowModuleTableName.Text = "数据库表名";
            // 
            // labFlowModuleFormName
            // 
            this.labFlowModuleFormName.Location = new System.Drawing.Point(36, 58);
            this.labFlowModuleFormName.Name = "labFlowModuleFormName";
            this.labFlowModuleFormName.Size = new System.Drawing.Size(72, 14);
            this.labFlowModuleFormName.TabIndex = 14;
            this.labFlowModuleFormName.Text = "项目窗体名称";
            // 
            // labFlowModuleText
            // 
            this.labFlowModuleText.Location = new System.Drawing.Point(360, 24);
            this.labFlowModuleText.Name = "labFlowModuleText";
            this.labFlowModuleText.Size = new System.Drawing.Size(48, 14);
            this.labFlowModuleText.TabIndex = 13;
            this.labFlowModuleText.Text = "模块名称";
            // 
            // labFlowModuleId
            // 
            this.labFlowModuleId.Location = new System.Drawing.Point(36, 24);
            this.labFlowModuleId.Name = "labFlowModuleId";
            this.labFlowModuleId.Size = new System.Drawing.Size(48, 14);
            this.labFlowModuleId.TabIndex = 12;
            this.labFlowModuleId.Text = "模块编号";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridCrlWorkFlowModule);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 137);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1081, 449);
            this.pnlGrid.TabIndex = 6;
            // 
            // gridCrlWorkFlowModule
            // 
            this.gridCrlWorkFlowModule.DataSource = this.bSWorkFlowModule;
            this.gridCrlWorkFlowModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlWorkFlowModule.Location = new System.Drawing.Point(2, 2);
            this.gridCrlWorkFlowModule.MainView = this.gridViewWorkFlowModule;
            this.gridCrlWorkFlowModule.Name = "gridCrlWorkFlowModule";
            this.gridCrlWorkFlowModule.Size = new System.Drawing.Size(1077, 445);
            this.gridCrlWorkFlowModule.TabIndex = 0;
            this.gridCrlWorkFlowModule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWorkFlowModule});
            // 
            // gridViewWorkFlowModule
            // 
            this.gridViewWorkFlowModule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.coluFlowModuleId,
            this.coluFlowModuleText,
            this.coluFlowModuleFormName,
            this.coluFlowModuleTableName});
            this.gridViewWorkFlowModule.GridControl = this.gridCrlWorkFlowModule;
            this.gridViewWorkFlowModule.IndicatorWidth = 40;
            this.gridViewWorkFlowModule.Name = "gridViewWorkFlowModule";
            this.gridViewWorkFlowModule.OptionsBehavior.Editable = false;
            this.gridViewWorkFlowModule.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewWorkFlowModule.OptionsView.ColumnAutoWidth = false;
            this.gridViewWorkFlowModule.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewWorkFlowModule.OptionsView.ShowFooter = true;
            this.gridViewWorkFlowModule.OptionsView.ShowGroupPanel = false;
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
            // coluFlowModuleText
            // 
            this.coluFlowModuleText.AppearanceHeader.Options.UseTextOptions = true;
            this.coluFlowModuleText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coluFlowModuleText.FieldName = "FlowModuleText";
            this.coluFlowModuleText.Name = "coluFlowModuleText";
            this.coluFlowModuleText.Visible = true;
            this.coluFlowModuleText.VisibleIndex = 1;
            this.coluFlowModuleText.Width = 160;
            // 
            // coluFlowModuleFormName
            // 
            this.coluFlowModuleFormName.AppearanceHeader.Options.UseTextOptions = true;
            this.coluFlowModuleFormName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coluFlowModuleFormName.FieldName = "FlowModuleFormName";
            this.coluFlowModuleFormName.Name = "coluFlowModuleFormName";
            this.coluFlowModuleFormName.Visible = true;
            this.coluFlowModuleFormName.VisibleIndex = 2;
            this.coluFlowModuleFormName.Width = 160;
            // 
            // coluFlowModuleTableName
            // 
            this.coluFlowModuleTableName.AppearanceHeader.Options.UseTextOptions = true;
            this.coluFlowModuleTableName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coluFlowModuleTableName.FieldName = "FlowModuleTableName";
            this.coluFlowModuleTableName.Name = "coluFlowModuleTableName";
            this.coluFlowModuleTableName.Visible = true;
            this.coluFlowModuleTableName.VisibleIndex = 3;
            this.coluFlowModuleTableName.Width = 200;
            // 
            // btnModuleProper
            // 
            this.btnModuleProper.Location = new System.Drawing.Point(496, 9);
            this.btnModuleProper.Name = "btnModuleProper";
            this.btnModuleProper.Size = new System.Drawing.Size(90, 23);
            this.btnModuleProper.TabIndex = 17;
            this.btnModuleProper.TabStop = false;
            this.btnModuleProper.Text = "生成模块字段";
            this.btnModuleProper.Click += new System.EventHandler(this.btnModuleProper_Click);
            // 
            // FrmWorkFlowModule
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1081, 586);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "FrmWorkFlowModule";
            this.TabText = "审核流-业务模块";
            this.Text = "审核流-业务模块";
            this.Load += new System.EventHandler(this.FrmWorkFlowModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSWorkFlowModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWorkFlowModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSWorkFlowModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).EndInit();
            this.pnlToolBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textFlowModuleText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textFlowModuleTableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textFlowModuleFormName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textFlowModuleId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlWorkFlowModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWorkFlowModule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dSWorkFlowModule;
        private System.Data.DataTable TableWorkFlowModule;
        private System.Data.DataColumn ColAutoId;
        private System.Data.DataColumn ColFlowModuleId;
        private System.Data.DataColumn ColFlowModuleText;
        private System.Data.DataColumn ColFlowModuleFormName;
        private System.Data.DataColumn ColFlowModuleTableName;
        private System.Windows.Forms.BindingSource bSWorkFlowModule;
        private DevExpress.XtraEditors.PanelControl pnlToolBar;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.TextEdit textFlowModuleTableName;
        private DevExpress.XtraEditors.TextEdit textFlowModuleFormName;
        private DevExpress.XtraEditors.TextEdit textFlowModuleId;
        private DevExpress.XtraEditors.LabelControl labFlowModuleTableName;
        private DevExpress.XtraEditors.LabelControl labFlowModuleFormName;
        private DevExpress.XtraEditors.LabelControl labFlowModuleText;
        private DevExpress.XtraEditors.LabelControl labFlowModuleId;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl gridCrlWorkFlowModule;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWorkFlowModule;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn coluFlowModuleId;
        private DevExpress.XtraGrid.Columns.GridColumn coluFlowModuleText;
        private DevExpress.XtraGrid.Columns.GridColumn coluFlowModuleFormName;
        private DevExpress.XtraGrid.Columns.GridColumn coluFlowModuleTableName;
        private DevExpress.XtraEditors.TextEdit textFlowModuleText;
        private DevExpress.XtraEditors.SimpleButton btnModuleProper;
    }
}