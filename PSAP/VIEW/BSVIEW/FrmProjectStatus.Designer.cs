namespace PSAP.VIEW.BSVIEW
{
    partial class FrmProjectStatus
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
            this.dSProjectStatus = new System.Data.DataSet();
            this.TableProjectStatus = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColStatusText = new System.Data.DataColumn();
            this.dataColIsDefault = new System.Data.DataColumn();
            this.bSProjectStatus = new System.Windows.Forms.BindingSource(this.components);
            this.pnlToolBar = new DevExpress.XtraEditors.PanelControl();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.textStatusText = new DevExpress.XtraEditors.TextEdit();
            this.labStatusText = new DevExpress.XtraEditors.LabelControl();
            this.checkIsDefault = new DevExpress.XtraEditors.CheckEdit();
            this.labIsDefault = new DevExpress.XtraEditors.LabelControl();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridCrlProjectStatus = new DevExpress.XtraGrid.GridControl();
            this.gridViewProjectStatus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemCheckIsDefault = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dSProjectStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableProjectStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSProjectStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textStatusText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlProjectStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProjectStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckIsDefault)).BeginInit();
            this.SuspendLayout();
            // 
            // dSProjectStatus
            // 
            this.dSProjectStatus.DataSetName = "NewDataSet";
            this.dSProjectStatus.Tables.AddRange(new System.Data.DataTable[] {
            this.TableProjectStatus});
            // 
            // TableProjectStatus
            // 
            this.TableProjectStatus.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColStatusText,
            this.dataColIsDefault});
            this.TableProjectStatus.TableName = "ProjectStatus";
            this.TableProjectStatus.TableNewRow += new System.Data.DataTableNewRowEventHandler(this.TableProjectStatus_TableNewRow);
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColStatusText
            // 
            this.dataColStatusText.Caption = "状态名称";
            this.dataColStatusText.ColumnName = "StatusText";
            // 
            // dataColIsDefault
            // 
            this.dataColIsDefault.Caption = "默认";
            this.dataColIsDefault.ColumnName = "IsDefault";
            this.dataColIsDefault.DataType = typeof(short);
            // 
            // bSProjectStatus
            // 
            this.bSProjectStatus.DataMember = "ProjectStatus";
            this.bSProjectStatus.DataSource = this.dSProjectStatus;
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(944, 40);
            this.pnlToolBar.TabIndex = 2;
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.labIsDefault);
            this.pnlEdit.Controls.Add(this.checkIsDefault);
            this.pnlEdit.Controls.Add(this.textStatusText);
            this.pnlEdit.Controls.Add(this.labStatusText);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEdit.Location = new System.Drawing.Point(0, 40);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(944, 64);
            this.pnlEdit.TabIndex = 6;
            // 
            // textStatusText
            // 
            this.textStatusText.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectStatus, "StatusText", true));
            this.textStatusText.EnterMoveNextControl = true;
            this.textStatusText.Location = new System.Drawing.Point(112, 21);
            this.textStatusText.Name = "textStatusText";
            this.textStatusText.Size = new System.Drawing.Size(150, 20);
            this.textStatusText.TabIndex = 0;
            // 
            // labStatusText
            // 
            this.labStatusText.Location = new System.Drawing.Point(36, 24);
            this.labStatusText.Name = "labStatusText";
            this.labStatusText.Size = new System.Drawing.Size(48, 14);
            this.labStatusText.TabIndex = 12;
            this.labStatusText.Text = "状态名称";
            // 
            // checkIsDefault
            // 
            this.checkIsDefault.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectStatus, "IsDefault", true));
            this.checkIsDefault.Location = new System.Drawing.Point(368, 21);
            this.checkIsDefault.Name = "checkIsDefault";
            this.checkIsDefault.Properties.Caption = "";
            this.checkIsDefault.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkIsDefault.Properties.ValueChecked = ((short)(1));
            this.checkIsDefault.Properties.ValueGrayed = ((short)(0));
            this.checkIsDefault.Properties.ValueUnchecked = ((short)(0));
            this.checkIsDefault.Size = new System.Drawing.Size(22, 19);
            this.checkIsDefault.TabIndex = 13;
            // 
            // labIsDefault
            // 
            this.labIsDefault.Location = new System.Drawing.Point(313, 24);
            this.labIsDefault.Name = "labIsDefault";
            this.labIsDefault.Size = new System.Drawing.Size(24, 14);
            this.labIsDefault.TabIndex = 14;
            this.labIsDefault.Text = "默认";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridCrlProjectStatus);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 104);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(944, 537);
            this.pnlGrid.TabIndex = 7;
            // 
            // gridCrlProjectStatus
            // 
            this.gridCrlProjectStatus.DataSource = this.bSProjectStatus;
            this.gridCrlProjectStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlProjectStatus.Location = new System.Drawing.Point(2, 2);
            this.gridCrlProjectStatus.MainView = this.gridViewProjectStatus;
            this.gridCrlProjectStatus.Name = "gridCrlProjectStatus";
            this.gridCrlProjectStatus.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemCheckIsDefault});
            this.gridCrlProjectStatus.Size = new System.Drawing.Size(940, 533);
            this.gridCrlProjectStatus.TabIndex = 0;
            this.gridCrlProjectStatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProjectStatus});
            // 
            // gridViewProjectStatus
            // 
            this.gridViewProjectStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colStatusText,
            this.colIsDefault});
            this.gridViewProjectStatus.GridControl = this.gridCrlProjectStatus;
            this.gridViewProjectStatus.IndicatorWidth = 40;
            this.gridViewProjectStatus.Name = "gridViewProjectStatus";
            this.gridViewProjectStatus.OptionsBehavior.Editable = false;
            this.gridViewProjectStatus.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewProjectStatus.OptionsView.ColumnAutoWidth = false;
            this.gridViewProjectStatus.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewProjectStatus.OptionsView.ShowFooter = true;
            this.gridViewProjectStatus.OptionsView.ShowGroupPanel = false;
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colStatusText
            // 
            this.colStatusText.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatusText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusText.FieldName = "StatusText";
            this.colStatusText.Name = "colStatusText";
            this.colStatusText.Visible = true;
            this.colStatusText.VisibleIndex = 0;
            this.colStatusText.Width = 200;
            // 
            // colIsDefault
            // 
            this.colIsDefault.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsDefault.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsDefault.ColumnEdit = this.repItemCheckIsDefault;
            this.colIsDefault.FieldName = "IsDefault";
            this.colIsDefault.Name = "colIsDefault";
            this.colIsDefault.Visible = true;
            this.colIsDefault.VisibleIndex = 1;
            // 
            // repItemCheckIsDefault
            // 
            this.repItemCheckIsDefault.AutoHeight = false;
            this.repItemCheckIsDefault.Name = "repItemCheckIsDefault";
            this.repItemCheckIsDefault.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repItemCheckIsDefault.ValueChecked = ((short)(1));
            this.repItemCheckIsDefault.ValueGrayed = ((short)(0));
            this.repItemCheckIsDefault.ValueUnchecked = ((short)(0));
            // 
            // FrmProjectStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(944, 641);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "FrmProjectStatus";
            this.TabText = "项目状态信息";
            this.Text = "项目状态信息";
            this.Load += new System.EventHandler(this.FrmProjectStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSProjectStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableProjectStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSProjectStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textStatusText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlProjectStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProjectStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckIsDefault)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dSProjectStatus;
        private System.Data.DataTable TableProjectStatus;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColStatusText;
        private System.Data.DataColumn dataColIsDefault;
        private System.Windows.Forms.BindingSource bSProjectStatus;
        private DevExpress.XtraEditors.PanelControl pnlToolBar;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.LabelControl labIsDefault;
        private DevExpress.XtraEditors.CheckEdit checkIsDefault;
        private DevExpress.XtraEditors.TextEdit textStatusText;
        private DevExpress.XtraEditors.LabelControl labStatusText;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl gridCrlProjectStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProjectStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusText;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDefault;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItemCheckIsDefault;
    }
}