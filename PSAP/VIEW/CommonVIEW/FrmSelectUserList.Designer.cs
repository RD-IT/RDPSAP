namespace PSAP.VIEW.BSVIEW
{
    partial class FrmSelectUserList
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
            this.groupCtlNoSelect = new DevExpress.XtraEditors.GroupControl();
            this.gridCrlLeft = new DevExpress.XtraGrid.GridControl();
            this.bSLeft = new System.Windows.Forms.BindingSource(this.components);
            this.dSLeft = new System.Data.DataSet();
            this.TableLeft = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.gridViewLeft = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupCtlSelect = new DevExpress.XtraEditors.GroupControl();
            this.gridCrlRight = new DevExpress.XtraGrid.GridControl();
            this.bSRight = new System.Windows.Forms.BindingSource(this.components);
            this.dSRight = new System.Data.DataSet();
            this.TableRight = new System.Data.DataTable();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.gridViewRight = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlForm = new DevExpress.XtraEditors.PanelControl();
            this.btnLeftAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnLeftOne = new DevExpress.XtraEditors.SimpleButton();
            this.btnRightAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnRightOne = new DevExpress.XtraEditors.SimpleButton();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfirm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupCtlNoSelect)).BeginInit();
            this.groupCtlNoSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCtlSelect)).BeginInit();
            this.groupCtlSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlForm)).BeginInit();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupCtlNoSelect
            // 
            this.groupCtlNoSelect.Controls.Add(this.gridCrlLeft);
            this.groupCtlNoSelect.Location = new System.Drawing.Point(32, 32);
            this.groupCtlNoSelect.Name = "groupCtlNoSelect";
            this.groupCtlNoSelect.Size = new System.Drawing.Size(350, 380);
            this.groupCtlNoSelect.TabIndex = 0;
            this.groupCtlNoSelect.Text = "未选择的用户";
            // 
            // gridCrlLeft
            // 
            this.gridCrlLeft.DataSource = this.bSLeft;
            this.gridCrlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlLeft.Location = new System.Drawing.Point(2, 21);
            this.gridCrlLeft.MainView = this.gridViewLeft;
            this.gridCrlLeft.Name = "gridCrlLeft";
            this.gridCrlLeft.Size = new System.Drawing.Size(346, 357);
            this.gridCrlLeft.TabIndex = 2;
            this.gridCrlLeft.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLeft});
            // 
            // bSLeft
            // 
            this.bSLeft.DataMember = "TableLeft";
            this.bSLeft.DataSource = this.dSLeft;
            // 
            // dSLeft
            // 
            this.dSLeft.DataSetName = "NewDataSet";
            this.dSLeft.Tables.AddRange(new System.Data.DataTable[] {
            this.TableLeft});
            // 
            // TableLeft
            // 
            this.TableLeft.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.TableLeft.TableName = "TableLeft";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "AutoId";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "姓名";
            this.dataColumn3.ColumnName = "EmpName";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "部门编号";
            this.dataColumn4.ColumnName = "DepartmentNo";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "部门名称";
            this.dataColumn5.ColumnName = "DepartmentName";
            // 
            // gridViewLeft
            // 
            this.gridViewLeft.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId1,
            this.colEmpName,
            this.colDepartmentNo,
            this.colDepartmentName});
            this.gridViewLeft.GridControl = this.gridCrlLeft;
            this.gridViewLeft.IndicatorWidth = 35;
            this.gridViewLeft.Name = "gridViewLeft";
            this.gridViewLeft.OptionsBehavior.Editable = false;
            this.gridViewLeft.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridViewLeft.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewLeft.OptionsSelection.MultiSelect = true;
            this.gridViewLeft.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewLeft.OptionsView.ColumnAutoWidth = false;
            this.gridViewLeft.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewLeft.OptionsView.ShowGroupPanel = false;
            this.gridViewLeft.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewLeft_CustomDrawRowIndicator);
            // 
            // colAutoId1
            // 
            this.colAutoId1.FieldName = "AutoId";
            this.colAutoId1.Name = "colAutoId1";
            // 
            // colEmpName
            // 
            this.colEmpName.AppearanceHeader.Options.UseTextOptions = true;
            this.colEmpName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmpName.FieldName = "EmpName";
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.Visible = true;
            this.colEmpName.VisibleIndex = 0;
            this.colEmpName.Width = 70;
            // 
            // colDepartmentNo
            // 
            this.colDepartmentNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colDepartmentNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDepartmentNo.FieldName = "DepartmentNo";
            this.colDepartmentNo.Name = "colDepartmentNo";
            this.colDepartmentNo.Visible = true;
            this.colDepartmentNo.VisibleIndex = 1;
            this.colDepartmentNo.Width = 80;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.AppearanceHeader.Options.UseTextOptions = true;
            this.colDepartmentName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 2;
            this.colDepartmentName.Width = 100;
            // 
            // groupCtlSelect
            // 
            this.groupCtlSelect.Controls.Add(this.gridCrlRight);
            this.groupCtlSelect.Location = new System.Drawing.Point(461, 32);
            this.groupCtlSelect.Name = "groupCtlSelect";
            this.groupCtlSelect.Size = new System.Drawing.Size(350, 380);
            this.groupCtlSelect.TabIndex = 1;
            this.groupCtlSelect.Text = "已选择的用户";
            // 
            // gridCrlRight
            // 
            this.gridCrlRight.DataSource = this.bSRight;
            this.gridCrlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrlRight.Location = new System.Drawing.Point(2, 21);
            this.gridCrlRight.MainView = this.gridViewRight;
            this.gridCrlRight.Name = "gridCrlRight";
            this.gridCrlRight.Size = new System.Drawing.Size(346, 357);
            this.gridCrlRight.TabIndex = 3;
            this.gridCrlRight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRight});
            // 
            // bSRight
            // 
            this.bSRight.DataMember = "TableRight";
            this.bSRight.DataSource = this.dSRight;
            // 
            // dSRight
            // 
            this.dSRight.DataSetName = "NewDataSet";
            this.dSRight.Tables.AddRange(new System.Data.DataTable[] {
            this.TableRight});
            // 
            // TableRight
            // 
            this.TableRight.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn6,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10});
            this.TableRight.TableName = "TableRight";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "AutoId";
            this.dataColumn6.DataType = typeof(int);
            // 
            // dataColumn8
            // 
            this.dataColumn8.Caption = "姓名";
            this.dataColumn8.ColumnName = "EmpName";
            // 
            // dataColumn9
            // 
            this.dataColumn9.Caption = "部门编号";
            this.dataColumn9.ColumnName = "DepartmentNo";
            // 
            // dataColumn10
            // 
            this.dataColumn10.Caption = "部门名称";
            this.dataColumn10.ColumnName = "DepartmentName";
            // 
            // gridViewRight
            // 
            this.gridViewRight.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridViewRight.GridControl = this.gridCrlRight;
            this.gridViewRight.IndicatorWidth = 35;
            this.gridViewRight.Name = "gridViewRight";
            this.gridViewRight.OptionsBehavior.Editable = false;
            this.gridViewRight.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridViewRight.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewRight.OptionsSelection.MultiSelect = true;
            this.gridViewRight.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewRight.OptionsView.ColumnAutoWidth = false;
            this.gridViewRight.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewRight.OptionsView.ShowGroupPanel = false;
            this.gridViewRight.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewLeft_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "AutoId";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.FieldName = "EmpName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 70;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.FieldName = "DepartmentNo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.FieldName = "DepartmentName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 100;
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.btnLeftAll);
            this.pnlForm.Controls.Add(this.btnLeftOne);
            this.pnlForm.Controls.Add(this.btnRightAll);
            this.pnlForm.Controls.Add(this.btnRightOne);
            this.pnlForm.Controls.Add(this.groupCtlNoSelect);
            this.pnlForm.Controls.Add(this.groupCtlSelect);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(844, 445);
            this.pnlForm.TabIndex = 2;
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.Location = new System.Drawing.Point(408, 325);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(28, 24);
            this.btnLeftAll.TabIndex = 5;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // btnLeftOne
            // 
            this.btnLeftOne.Location = new System.Drawing.Point(408, 273);
            this.btnLeftOne.Name = "btnLeftOne";
            this.btnLeftOne.Size = new System.Drawing.Size(28, 24);
            this.btnLeftOne.TabIndex = 4;
            this.btnLeftOne.Text = "<";
            this.btnLeftOne.Click += new System.EventHandler(this.btnLeftOne_Click);
            // 
            // btnRightAll
            // 
            this.btnRightAll.Location = new System.Drawing.Point(408, 132);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(28, 24);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // btnRightOne
            // 
            this.btnRightOne.Location = new System.Drawing.Point(408, 81);
            this.btnRightOne.Name = "btnRightOne";
            this.btnRightOne.Size = new System.Drawing.Size(28, 24);
            this.btnRightOne.TabIndex = 2;
            this.btnRightOne.Text = ">";
            this.btnRightOne.Click += new System.EventHandler(this.btnRightOne_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.BtnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 445);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(844, 36);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(755, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.Location = new System.Drawing.Point(674, 7);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 1;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // FrmSelectUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 481);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectUserList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "选择人员信息";
            this.Text = "选择人员信息";
            this.Load += new System.EventHandler(this.FrmSelectUserList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupCtlNoSelect)).EndInit();
            this.groupCtlNoSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCtlSelect)).EndInit();
            this.groupCtlSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrlRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlForm)).EndInit();
            this.pnlForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupCtlNoSelect;
        private DevExpress.XtraEditors.GroupControl groupCtlSelect;
        private DevExpress.XtraEditors.PanelControl pnlForm;
        private DevExpress.XtraEditors.SimpleButton btnLeftAll;
        private DevExpress.XtraEditors.SimpleButton btnLeftOne;
        private DevExpress.XtraEditors.SimpleButton btnRightAll;
        private DevExpress.XtraEditors.SimpleButton btnRightOne;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
        private DevExpress.XtraGrid.GridControl gridCrlLeft;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLeft;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private System.Data.DataSet dSLeft;
        private System.Data.DataTable TableLeft;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.BindingSource bSLeft;
        private System.Data.DataSet dSRight;
        private System.Data.DataTable TableRight;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Windows.Forms.BindingSource bSRight;
        private DevExpress.XtraGrid.GridControl gridCrlRight;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}