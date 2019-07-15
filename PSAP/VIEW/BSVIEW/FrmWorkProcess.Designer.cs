namespace PSAP.VIEW.BSVIEW
{
    partial class FrmWorkProcess
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
            this.dSWorkProcess = new System.Data.DataSet();
            this.TableWorkProcess = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColWorkProcessNo = new System.Data.DataColumn();
            this.dataColWorkProcessText = new System.Data.DataColumn();
            this.dataColIsBuy = new System.Data.DataColumn();
            this.dataColRemark = new System.Data.DataColumn();
            this.bSWorkProcess = new System.Windows.Forms.BindingSource(this.components);
            this.pnlToolBar = new DevExpress.XtraEditors.PanelControl();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.textRemark = new DevExpress.XtraEditors.TextEdit();
            this.textWorkProcessText = new DevExpress.XtraEditors.TextEdit();
            this.textWorkProcessNo = new DevExpress.XtraEditors.TextEdit();
            this.labRemark = new DevExpress.XtraEditors.LabelControl();
            this.labWorkProcessText = new DevExpress.XtraEditors.LabelControl();
            this.labWorkProcessNo = new DevExpress.XtraEditors.LabelControl();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridCrlWorkProcess = new DevExpress.XtraGrid.GridControl();
            this.gridViewWorkProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkProcessNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkProcessText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBuy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckIsBuy = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.checkIsBuy = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dSWorkProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWorkProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSWorkProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWorkProcessText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWorkProcessNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlWorkProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWorkProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsBuy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dSWorkProcess
            // 
            this.dSWorkProcess.DataSetName = "NewDataSet";
            this.dSWorkProcess.Tables.AddRange(new System.Data.DataTable[] {
            this.TableWorkProcess});
            // 
            // TableWorkProcess
            // 
            this.TableWorkProcess.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColWorkProcessNo,
            this.dataColWorkProcessText,
            this.dataColIsBuy,
            this.dataColRemark});
            this.TableWorkProcess.TableName = "WorkProcess";
            this.TableWorkProcess.TableNewRow += new System.Data.DataTableNewRowEventHandler(this.TableWorkProcess_TableNewRow);
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(System.Guid);
            // 
            // dataColWorkProcessNo
            // 
            this.dataColWorkProcessNo.Caption = "工序编号";
            this.dataColWorkProcessNo.ColumnName = "WorkProcessNo";
            // 
            // dataColWorkProcessText
            // 
            this.dataColWorkProcessText.Caption = "工序名称";
            this.dataColWorkProcessText.ColumnName = "WorkProcessText";
            // 
            // dataColIsBuy
            // 
            this.dataColIsBuy.Caption = "是否购买";
            this.dataColIsBuy.ColumnName = "IsBuy";
            this.dataColIsBuy.DataType = typeof(short);
            // 
            // dataColRemark
            // 
            this.dataColRemark.Caption = "备注";
            this.dataColRemark.ColumnName = "Remark";
            // 
            // bSWorkProcess
            // 
            this.bSWorkProcess.DataMember = "WorkProcess";
            this.bSWorkProcess.DataSource = this.dSWorkProcess;
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(893, 40);
            this.pnlToolBar.TabIndex = 2;
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.checkIsBuy);
            this.pnlEdit.Controls.Add(this.textRemark);
            this.pnlEdit.Controls.Add(this.textWorkProcessText);
            this.pnlEdit.Controls.Add(this.textWorkProcessNo);
            this.pnlEdit.Controls.Add(this.labRemark);
            this.pnlEdit.Controls.Add(this.labWorkProcessText);
            this.pnlEdit.Controls.Add(this.labWorkProcessNo);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEdit.Location = new System.Drawing.Point(0, 40);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(893, 97);
            this.pnlEdit.TabIndex = 6;
            // 
            // textRemark
            // 
            this.textRemark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkProcess, "Remark", true));
            this.textRemark.Location = new System.Drawing.Point(112, 55);
            this.textRemark.Name = "textRemark";
            this.textRemark.Size = new System.Drawing.Size(448, 20);
            this.textRemark.TabIndex = 3;
            // 
            // textWorkProcessText
            // 
            this.textWorkProcessText.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkProcess, "WorkProcessText", true));
            this.textWorkProcessText.EnterMoveNextControl = true;
            this.textWorkProcessText.Location = new System.Drawing.Point(380, 21);
            this.textWorkProcessText.Name = "textWorkProcessText";
            this.textWorkProcessText.Size = new System.Drawing.Size(180, 20);
            this.textWorkProcessText.TabIndex = 1;
            // 
            // textWorkProcessNo
            // 
            this.textWorkProcessNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkProcess, "WorkProcessNo", true));
            this.textWorkProcessNo.EnterMoveNextControl = true;
            this.textWorkProcessNo.Location = new System.Drawing.Point(112, 21);
            this.textWorkProcessNo.Name = "textWorkProcessNo";
            this.textWorkProcessNo.Size = new System.Drawing.Size(150, 20);
            this.textWorkProcessNo.TabIndex = 0;
            // 
            // labRemark
            // 
            this.labRemark.Location = new System.Drawing.Point(36, 58);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new System.Drawing.Size(24, 14);
            this.labRemark.TabIndex = 15;
            this.labRemark.Text = "备注";
            // 
            // labWorkProcessText
            // 
            this.labWorkProcessText.Location = new System.Drawing.Point(300, 24);
            this.labWorkProcessText.Name = "labWorkProcessText";
            this.labWorkProcessText.Size = new System.Drawing.Size(48, 14);
            this.labWorkProcessText.TabIndex = 14;
            this.labWorkProcessText.Text = "工序名称";
            // 
            // labWorkProcessNo
            // 
            this.labWorkProcessNo.Location = new System.Drawing.Point(36, 24);
            this.labWorkProcessNo.Name = "labWorkProcessNo";
            this.labWorkProcessNo.Size = new System.Drawing.Size(48, 14);
            this.labWorkProcessNo.TabIndex = 12;
            this.labWorkProcessNo.Text = "工序编号";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.gridCrlWorkProcess);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 137);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(893, 390);
            this.pnlGrid.TabIndex = 7;
            // 
            // gridCrlWorkProcess
            // 
            this.gridCrlWorkProcess.DataSource = this.bSWorkProcess;
            this.gridCrlWorkProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlWorkProcess.Location = new System.Drawing.Point(2, 2);
            this.gridCrlWorkProcess.MainView = this.gridViewWorkProcess;
            this.gridCrlWorkProcess.Name = "gridCrlWorkProcess";
            this.gridCrlWorkProcess.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckIsBuy});
            this.gridCrlWorkProcess.Size = new System.Drawing.Size(889, 386);
            this.gridCrlWorkProcess.TabIndex = 0;
            this.gridCrlWorkProcess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWorkProcess});
            // 
            // gridViewWorkProcess
            // 
            this.gridViewWorkProcess.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colWorkProcessNo,
            this.colWorkProcessText,
            this.colIsBuy,
            this.colRemark});
            this.gridViewWorkProcess.GridControl = this.gridCrlWorkProcess;
            this.gridViewWorkProcess.IndicatorWidth = 40;
            this.gridViewWorkProcess.Name = "gridViewWorkProcess";
            this.gridViewWorkProcess.OptionsBehavior.Editable = false;
            this.gridViewWorkProcess.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewWorkProcess.OptionsView.ColumnAutoWidth = false;
            this.gridViewWorkProcess.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewWorkProcess.OptionsView.ShowFooter = true;
            this.gridViewWorkProcess.OptionsView.ShowGroupPanel = false;
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // colWorkProcessNo
            // 
            this.colWorkProcessNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colWorkProcessNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWorkProcessNo.FieldName = "WorkProcessNo";
            this.colWorkProcessNo.Name = "colWorkProcessNo";
            this.colWorkProcessNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProjectNo", "共计{0}条")});
            this.colWorkProcessNo.Visible = true;
            this.colWorkProcessNo.VisibleIndex = 0;
            this.colWorkProcessNo.Width = 150;
            // 
            // colWorkProcessText
            // 
            this.colWorkProcessText.AppearanceHeader.Options.UseTextOptions = true;
            this.colWorkProcessText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWorkProcessText.FieldName = "WorkProcessText";
            this.colWorkProcessText.Name = "colWorkProcessText";
            this.colWorkProcessText.Visible = true;
            this.colWorkProcessText.VisibleIndex = 1;
            this.colWorkProcessText.Width = 180;
            // 
            // colRemark
            // 
            this.colRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.colRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 3;
            this.colRemark.Width = 240;
            // 
            // colIsBuy
            // 
            this.colIsBuy.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsBuy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsBuy.ColumnEdit = this.repCheckIsBuy;
            this.colIsBuy.FieldName = "IsBuy";
            this.colIsBuy.Name = "colIsBuy";
            this.colIsBuy.Visible = true;
            this.colIsBuy.VisibleIndex = 2;
            this.colIsBuy.Width = 80;
            // 
            // repCheckIsBuy
            // 
            this.repCheckIsBuy.AutoHeight = false;
            this.repCheckIsBuy.Name = "repCheckIsBuy";
            this.repCheckIsBuy.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repCheckIsBuy.ValueChecked = ((short)(1));
            this.repCheckIsBuy.ValueGrayed = ((short)(0));
            this.repCheckIsBuy.ValueUnchecked = ((short)(0));
            // 
            // checkIsBuy
            // 
            this.checkIsBuy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSWorkProcess, "IsBuy", true));
            this.checkIsBuy.EnterMoveNextControl = true;
            this.checkIsBuy.Location = new System.Drawing.Point(601, 21);
            this.checkIsBuy.Name = "checkIsBuy";
            this.checkIsBuy.Properties.Caption = "是否购买";
            this.checkIsBuy.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkIsBuy.Properties.ValueChecked = ((short)(1));
            this.checkIsBuy.Properties.ValueUnchecked = ((short)(0));
            this.checkIsBuy.Size = new System.Drawing.Size(97, 19);
            this.checkIsBuy.TabIndex = 2;
            // 
            // FrmWorkProcess
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(893, 527);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "FrmWorkProcess";
            this.TabText = "基本工序";
            this.Text = "基本工序";
            this.Load += new System.EventHandler(this.FrmWorkProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSWorkProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableWorkProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSWorkProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWorkProcessText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWorkProcessNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlWorkProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWorkProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckIsBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkIsBuy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dSWorkProcess;
        private System.Data.DataTable TableWorkProcess;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColWorkProcessNo;
        private System.Data.DataColumn dataColWorkProcessText;
        private System.Data.DataColumn dataColIsBuy;
        private System.Windows.Forms.BindingSource bSWorkProcess;
        private System.Data.DataColumn dataColRemark;
        private DevExpress.XtraEditors.PanelControl pnlToolBar;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.TextEdit textRemark;
        private DevExpress.XtraEditors.TextEdit textWorkProcessText;
        private DevExpress.XtraEditors.TextEdit textWorkProcessNo;
        private DevExpress.XtraEditors.LabelControl labRemark;
        private DevExpress.XtraEditors.LabelControl labWorkProcessText;
        private DevExpress.XtraEditors.LabelControl labWorkProcessNo;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl gridCrlWorkProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWorkProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkProcessNo;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkProcessText;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBuy;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckIsBuy;
        private DevExpress.XtraEditors.CheckEdit checkIsBuy;
    }
}