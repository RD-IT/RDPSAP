namespace PSAP.VIEW.BSVIEW
{
    partial class FrmProjectPlanTask
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
            DevExpress.XtraScheduler.TimeScaleYear timeScaleYear1 = new DevExpress.XtraScheduler.TimeScaleYear();
            DevExpress.XtraScheduler.TimeScaleQuarter timeScaleQuarter1 = new DevExpress.XtraScheduler.TimeScaleQuarter();
            DevExpress.XtraScheduler.TimeScaleMonth timeScaleMonth1 = new DevExpress.XtraScheduler.TimeScaleMonth();
            DevExpress.XtraScheduler.TimeScaleWeek timeScaleWeek1 = new DevExpress.XtraScheduler.TimeScaleWeek();
            DevExpress.XtraScheduler.TimeScaleDay timeScaleDay1 = new DevExpress.XtraScheduler.TimeScaleDay();
            DevExpress.XtraScheduler.TimeScaleHour timeScaleHour1 = new DevExpress.XtraScheduler.TimeScaleHour();
            DevExpress.XtraScheduler.TimeScale15Minutes timeScale15Minutes1 = new DevExpress.XtraScheduler.TimeScale15Minutes();
            DevExpress.XtraScheduler.SchedulerColorSchema schedulerColorSchema1 = new DevExpress.XtraScheduler.SchedulerColorSchema();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeScaleYear timeScaleYear2 = new DevExpress.XtraScheduler.TimeScaleYear();
            DevExpress.XtraScheduler.TimeScaleQuarter timeScaleQuarter2 = new DevExpress.XtraScheduler.TimeScaleQuarter();
            DevExpress.XtraScheduler.TimeScaleMonth timeScaleMonth2 = new DevExpress.XtraScheduler.TimeScaleMonth();
            DevExpress.XtraScheduler.TimeScaleWeek timeScaleWeek2 = new DevExpress.XtraScheduler.TimeScaleWeek();
            DevExpress.XtraScheduler.TimeScaleDay timeScaleDay2 = new DevExpress.XtraScheduler.TimeScaleDay();
            DevExpress.XtraScheduler.TimeScaleHour timeScaleHour2 = new DevExpress.XtraScheduler.TimeScaleHour();
            DevExpress.XtraScheduler.TimeScale15Minutes timeScale15Minutes2 = new DevExpress.XtraScheduler.TimeScale15Minutes();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.searchLookUpProjectNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpProjectNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labProjectNo = new DevExpress.XtraEditors.LabelControl();
            this.TabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.PagePlanTask = new DevExpress.XtraTab.XtraTabPage();
            this.splitControlPlanTask = new DevExpress.XtraEditors.SplitContainerControl();
            this.resourcesTreePlanTask = new DevExpress.XtraScheduler.UI.ResourcesTree();
            this.colPlanTaskText = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.col开始日期 = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.col结束日期 = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.colAutoId = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.schedulerPlanTask = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStoragePlanTask = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.dSScheduler = new System.Data.DataSet();
            this.TableAppointments = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.TableResources = new System.Data.DataTable();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.TableTaskDependencies = new System.Data.DataTable();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.pnlEditPlanTask = new DevExpress.XtraEditors.PanelControl();
            this.textPlanTaskStatus = new DevExpress.XtraEditors.TextEdit();
            this.bSProjectPlanTask = new System.Windows.Forms.BindingSource(this.components);
            this.dSProjectPlanTask = new System.Data.DataSet();
            this.TableProjectPlanTask = new System.Data.DataTable();
            this.dataColAutoId = new System.Data.DataColumn();
            this.dataColProjectNo = new System.Data.DataColumn();
            this.dataColPlanTaskText = new System.Data.DataColumn();
            this.dataColTaskNo = new System.Data.DataColumn();
            this.dataColPlanTaskStatus = new System.Data.DataColumn();
            this.dataColProjectUser = new System.Data.DataColumn();
            this.dataColPlanStartDate = new System.Data.DataColumn();
            this.dataColPlanEndDate = new System.Data.DataColumn();
            this.dataColPlanTotalDays = new System.Data.DataColumn();
            this.dataColRemark = new System.Data.DataColumn();
            this.dataColCreator = new System.Data.DataColumn();
            this.dataColCreateTime = new System.Data.DataColumn();
            this.dataColUserId = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.labPlanTaskStatus = new DevExpress.XtraEditors.LabelControl();
            this.lookUpCreator = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labCreator = new DevExpress.XtraEditors.LabelControl();
            this.textCreateTime = new DevExpress.XtraEditors.TextEdit();
            this.labPlanTotalDays = new DevExpress.XtraEditors.LabelControl();
            this.spinPlanTotalDays = new DevExpress.XtraEditors.SpinEdit();
            this.labPlanEndDate = new DevExpress.XtraEditors.LabelControl();
            this.datePlanEndDate = new DevExpress.XtraEditors.DateEdit();
            this.labPlanStartDate = new DevExpress.XtraEditors.LabelControl();
            this.datePlanStartDate = new DevExpress.XtraEditors.DateEdit();
            this.labProjectUser = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpProjectUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpProjectUserView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColuAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuDepartmentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColuDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchLookUpTaskNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpTaskNoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labTaskNo = new DevExpress.XtraEditors.LabelControl();
            this.textRemark = new DevExpress.XtraEditors.TextEdit();
            this.labRemark = new DevExpress.XtraEditors.LabelControl();
            this.textPlanTaskText = new DevExpress.XtraEditors.TextEdit();
            this.labPlanTaskText = new DevExpress.XtraEditors.LabelControl();
            this.pnlToolBarPlanTask = new DevExpress.XtraEditors.PanelControl();
            this.bSAppointments = new System.Windows.Forms.BindingSource(this.components);
            this.bSResources = new System.Windows.Forms.BindingSource(this.components);
            this.bSTaskDependencies = new System.Windows.Forms.BindingSource(this.components);
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlMain)).BeginInit();
            this.TabControlMain.SuspendLayout();
            this.PagePlanTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitControlPlanTask)).BeginInit();
            this.splitControlPlanTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesTreePlanTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerPlanTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStoragePlanTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSScheduler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableResources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableTaskDependencies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEditPlanTask)).BeginInit();
            this.pnlEditPlanTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPlanTaskStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSProjectPlanTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSProjectPlanTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableProjectPlanTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCreator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCreateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPlanTotalDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectUserView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpTaskNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpTaskNoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPlanTaskText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBarPlanTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSResources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSTaskDependencies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.searchLookUpProjectNo);
            this.pnlTop.Controls.Add(this.labProjectNo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1332, 52);
            this.pnlTop.TabIndex = 1;
            // 
            // searchLookUpProjectNo
            // 
            this.searchLookUpProjectNo.EnterMoveNextControl = true;
            this.searchLookUpProjectNo.Location = new System.Drawing.Point(76, 14);
            this.searchLookUpProjectNo.Name = "searchLookUpProjectNo";
            this.searchLookUpProjectNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpProjectNo.Properties.View = this.searchLookUpProjectNoView;
            this.searchLookUpProjectNo.Size = new System.Drawing.Size(180, 20);
            this.searchLookUpProjectNo.TabIndex = 40;
            this.searchLookUpProjectNo.EditValueChanged += new System.EventHandler(this.searchLookUpProjectNo_EditValueChanged);
            // 
            // searchLookUpProjectNoView
            // 
            this.searchLookUpProjectNoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpProjectNoView.Name = "searchLookUpProjectNoView";
            this.searchLookUpProjectNoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpProjectNoView.OptionsView.ShowGroupPanel = false;
            // 
            // labProjectNo
            // 
            this.labProjectNo.Location = new System.Drawing.Point(20, 17);
            this.labProjectNo.Name = "labProjectNo";
            this.labProjectNo.Size = new System.Drawing.Size(36, 14);
            this.labProjectNo.TabIndex = 41;
            this.labProjectNo.Text = "项目号";
            // 
            // TabControlMain
            // 
            this.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlMain.Location = new System.Drawing.Point(2, 2);
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedTabPage = this.PagePlanTask;
            this.TabControlMain.Size = new System.Drawing.Size(1328, 673);
            this.TabControlMain.TabIndex = 2;
            this.TabControlMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PagePlanTask});
            // 
            // PagePlanTask
            // 
            this.PagePlanTask.Controls.Add(this.splitControlPlanTask);
            this.PagePlanTask.Controls.Add(this.pnlEditPlanTask);
            this.PagePlanTask.Controls.Add(this.pnlToolBarPlanTask);
            this.PagePlanTask.Name = "PagePlanTask";
            this.PagePlanTask.Size = new System.Drawing.Size(1322, 644);
            this.PagePlanTask.Text = "计划任务登记";
            // 
            // splitControlPlanTask
            // 
            this.splitControlPlanTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitControlPlanTask.Location = new System.Drawing.Point(0, 174);
            this.splitControlPlanTask.Name = "splitControlPlanTask";
            this.splitControlPlanTask.Panel1.Controls.Add(this.resourcesTreePlanTask);
            this.splitControlPlanTask.Panel1.Text = "PnlLeft";
            this.splitControlPlanTask.Panel2.Controls.Add(this.schedulerPlanTask);
            this.splitControlPlanTask.Panel2.Text = "PnlRight";
            this.splitControlPlanTask.Size = new System.Drawing.Size(1322, 470);
            this.splitControlPlanTask.SplitterPosition = 360;
            this.splitControlPlanTask.TabIndex = 9;
            this.splitControlPlanTask.Text = "splitContainerControl1";
            // 
            // resourcesTreePlanTask
            // 
            this.resourcesTreePlanTask.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colPlanTaskText,
            this.col开始日期,
            this.col结束日期,
            this.colAutoId});
            this.resourcesTreePlanTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourcesTreePlanTask.IndicatorWidth = 40;
            this.resourcesTreePlanTask.KeyFieldName = "AutoId";
            this.resourcesTreePlanTask.Location = new System.Drawing.Point(0, 0);
            this.resourcesTreePlanTask.Name = "resourcesTreePlanTask";
            this.resourcesTreePlanTask.OptionsBehavior.Editable = false;
            this.resourcesTreePlanTask.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.resourcesTreePlanTask.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.resourcesTreePlanTask.OptionsMenu.EnableColumnMenu = false;
            this.resourcesTreePlanTask.OptionsMenu.EnableFooterMenu = false;
            this.resourcesTreePlanTask.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.resourcesTreePlanTask.OptionsView.EnableAppearanceOddRow = true;
            this.resourcesTreePlanTask.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
            this.resourcesTreePlanTask.OptionsView.ShowIndicator = true;
            this.resourcesTreePlanTask.OptionsView.ShowRoot = false;
            this.resourcesTreePlanTask.OptionsView.ShowSummaryFooter = true;
            this.resourcesTreePlanTask.OptionsView.ShowVertLines = true;
            this.resourcesTreePlanTask.ParentFieldName = "ParentId";
            this.resourcesTreePlanTask.SchedulerControl = this.schedulerPlanTask;
            this.resourcesTreePlanTask.Size = new System.Drawing.Size(360, 470);
            this.resourcesTreePlanTask.TabIndex = 0;
            this.resourcesTreePlanTask.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.resourcesTreePlanTask_BeforeFocusNode);
            this.resourcesTreePlanTask.CustomDrawNodeIndicator += new DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventHandler(this.resourcesTreePlanTask_CustomDrawNodeIndicator);
            this.resourcesTreePlanTask.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.resourcesTreePlanTask_MouseDoubleClick);
            // 
            // colPlanTaskText
            // 
            this.colPlanTaskText.AppearanceHeader.Options.UseTextOptions = true;
            this.colPlanTaskText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPlanTaskText.Caption = "任务名称";
            this.colPlanTaskText.FieldName = "PlanTaskText";
            this.colPlanTaskText.Name = "colPlanTaskText";
            this.colPlanTaskText.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count;
            this.colPlanTaskText.SummaryFooterStrFormat = "共计{0}条";
            this.colPlanTaskText.Visible = true;
            this.colPlanTaskText.VisibleIndex = 0;
            this.colPlanTaskText.Width = 138;
            // 
            // col开始日期
            // 
            this.col开始日期.AppearanceHeader.Options.UseTextOptions = true;
            this.col开始日期.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col开始日期.Caption = "开始日期";
            this.col开始日期.FieldName = "PlanStartDate";
            this.col开始日期.Format.FormatString = "yyyy-MM-dd";
            this.col开始日期.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col开始日期.Name = "col开始日期";
            this.col开始日期.Visible = true;
            this.col开始日期.VisibleIndex = 1;
            this.col开始日期.Width = 90;
            // 
            // col结束日期
            // 
            this.col结束日期.AppearanceHeader.Options.UseTextOptions = true;
            this.col结束日期.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col结束日期.Caption = "结束日期";
            this.col结束日期.FieldName = "PlanEndDate";
            this.col结束日期.Format.FormatString = "yyyy-MM-dd";
            this.col结束日期.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col结束日期.Name = "col结束日期";
            this.col结束日期.Visible = true;
            this.col结束日期.VisibleIndex = 2;
            this.col结束日期.Width = 90;
            // 
            // colAutoId
            // 
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            // 
            // schedulerPlanTask
            // 
            this.schedulerPlanTask.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Gantt;
            this.schedulerPlanTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerPlanTask.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource;
            this.schedulerPlanTask.Location = new System.Drawing.Point(0, 0);
            this.schedulerPlanTask.LookAndFeel.SkinMaskColor = System.Drawing.Color.White;
            this.schedulerPlanTask.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White;
            this.schedulerPlanTask.Name = "schedulerPlanTask";
            this.schedulerPlanTask.OptionsBehavior.TouchAllowed = false;
            this.schedulerPlanTask.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerPlanTask.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerPlanTask.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerPlanTask.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerPlanTask.OptionsCustomization.AllowAppointmentMultiSelect = false;
            this.schedulerPlanTask.OptionsCustomization.AllowDisplayAppointmentDependencyForm = DevExpress.XtraScheduler.AllowDisplayAppointmentDependencyForm.Never;
            this.schedulerPlanTask.OptionsCustomization.AllowDisplayAppointmentForm = DevExpress.XtraScheduler.AllowDisplayAppointmentForm.Never;
            this.schedulerPlanTask.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerPlanTask.OptionsRangeControl.AllowChangeActiveView = false;
            this.schedulerPlanTask.OptionsRangeControl.AutoAdjustMode = false;
            this.schedulerPlanTask.OptionsRangeControl.MaxIntervalWidth = 90;
            timeScaleYear1.Enabled = false;
            timeScaleQuarter1.Enabled = false;
            timeScaleQuarter1.Visible = false;
            timeScaleMonth1.Enabled = false;
            timeScaleWeek1.Enabled = false;
            timeScaleWeek1.Visible = false;
            timeScaleHour1.Enabled = false;
            timeScaleHour1.Visible = false;
            timeScale15Minutes1.Enabled = false;
            timeScale15Minutes1.Visible = false;
            this.schedulerPlanTask.OptionsRangeControl.Scales.Add(timeScaleYear1);
            this.schedulerPlanTask.OptionsRangeControl.Scales.Add(timeScaleQuarter1);
            this.schedulerPlanTask.OptionsRangeControl.Scales.Add(timeScaleMonth1);
            this.schedulerPlanTask.OptionsRangeControl.Scales.Add(timeScaleWeek1);
            this.schedulerPlanTask.OptionsRangeControl.Scales.Add(timeScaleDay1);
            this.schedulerPlanTask.OptionsRangeControl.Scales.Add(timeScaleHour1);
            this.schedulerPlanTask.OptionsRangeControl.Scales.Add(timeScale15Minutes1);
            this.schedulerPlanTask.OptionsView.ResourceHeaders.Height = 20;
            schedulerColorSchema1.Cell = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            schedulerColorSchema1.CellBorder = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            schedulerColorSchema1.CellBorderDark = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            schedulerColorSchema1.CellLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            schedulerColorSchema1.CellLightBorder = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            schedulerColorSchema1.CellLightBorderDark = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.schedulerPlanTask.ResourceColorSchemas.Add(schedulerColorSchema1);
            this.schedulerPlanTask.Size = new System.Drawing.Size(957, 470);
            this.schedulerPlanTask.Start = new System.DateTime(2019, 8, 1, 0, 0, 0, 0);
            this.schedulerPlanTask.Storage = this.schedulerStoragePlanTask;
            this.schedulerPlanTask.TabIndex = 0;
            this.schedulerPlanTask.Text = "任务进度图";
            this.schedulerPlanTask.Views.DayView.AllDayAreaScrollBarVisible = false;
            this.schedulerPlanTask.Views.DayView.AppointmentDisplayOptions.ContinueArrowDisplayType = DevExpress.XtraScheduler.AppointmentContinueArrowDisplayType.Never;
            this.schedulerPlanTask.Views.DayView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerPlanTask.Views.DayView.AppointmentDisplayOptions.ShowRecurrence = false;
            this.schedulerPlanTask.Views.DayView.AppointmentDisplayOptions.ShowReminder = false;
            this.schedulerPlanTask.Views.DayView.AppointmentDisplayOptions.ShowShadows = false;
            this.schedulerPlanTask.Views.DayView.AppointmentDisplayOptions.SnapToCellsMode = DevExpress.XtraScheduler.AppointmentSnapToCellsMode.Never;
            this.schedulerPlanTask.Views.DayView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerPlanTask.Views.DayView.AppointmentDisplayOptions.StatusDisplayType = DevExpress.XtraScheduler.AppointmentStatusDisplayType.Never;
            this.schedulerPlanTask.Views.DayView.DateTimeScrollbarVisible = false;
            this.schedulerPlanTask.Views.DayView.Enabled = false;
            this.schedulerPlanTask.Views.DayView.NavigationButtonVisibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.schedulerPlanTask.Views.DayView.ShowAllDayArea = false;
            this.schedulerPlanTask.Views.DayView.ShowDayHeaders = false;
            this.schedulerPlanTask.Views.DayView.ShowMoreButtons = false;
            this.schedulerPlanTask.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerPlanTask.Views.FullWeekView.AllDayAreaScrollBarVisible = false;
            this.schedulerPlanTask.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerPlanTask.Views.GanttView.AppointmentDisplayOptions.AppointmentHeight = 30;
            this.schedulerPlanTask.Views.GanttView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerPlanTask.Views.GanttView.AppointmentDisplayOptions.PercentCompleteDisplayType = DevExpress.XtraScheduler.PercentCompleteDisplayType.None;
            this.schedulerPlanTask.Views.GanttView.AppointmentDisplayOptions.ShowReminder = false;
            this.schedulerPlanTask.Views.GanttView.AppointmentDisplayOptions.SnapToCellsMode = DevExpress.XtraScheduler.AppointmentSnapToCellsMode.Never;
            this.schedulerPlanTask.Views.GanttView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerPlanTask.Views.GanttView.NavigationButtonVisibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.schedulerPlanTask.Views.GanttView.OptionsSelectionBehavior.KeepSelectedAppointments = true;
            this.schedulerPlanTask.Views.GanttView.ResourcesPerPage = 10;
            timeScaleYear2.Enabled = false;
            timeScaleQuarter2.Enabled = false;
            timeScaleQuarter2.Visible = false;
            timeScaleMonth2.DisplayFormat = "yyyy 年 MM 月";
            timeScaleWeek2.Enabled = false;
            timeScaleDay2.DisplayFormat = "dd 日";
            timeScaleHour2.Enabled = false;
            timeScaleHour2.Visible = false;
            timeScale15Minutes2.Enabled = false;
            timeScale15Minutes2.Visible = false;
            this.schedulerPlanTask.Views.GanttView.Scales.Add(timeScaleYear2);
            this.schedulerPlanTask.Views.GanttView.Scales.Add(timeScaleQuarter2);
            this.schedulerPlanTask.Views.GanttView.Scales.Add(timeScaleMonth2);
            this.schedulerPlanTask.Views.GanttView.Scales.Add(timeScaleWeek2);
            this.schedulerPlanTask.Views.GanttView.Scales.Add(timeScaleDay2);
            this.schedulerPlanTask.Views.GanttView.Scales.Add(timeScaleHour2);
            this.schedulerPlanTask.Views.GanttView.Scales.Add(timeScale15Minutes2);
            this.schedulerPlanTask.Views.GanttView.SelectionBar.Visible = false;
            this.schedulerPlanTask.Views.GanttView.ShowMoreButtons = false;
            this.schedulerPlanTask.Views.GanttView.ShowResourceHeaders = false;
            this.schedulerPlanTask.Views.MonthView.Enabled = false;
            this.schedulerPlanTask.Views.TimelineView.Enabled = false;
            this.schedulerPlanTask.Views.TimelineView.TimelineScrollBarVisible = false;
            this.schedulerPlanTask.Views.WeekView.Enabled = false;
            this.schedulerPlanTask.Views.WorkWeekView.AllDayAreaScrollBarVisible = false;
            this.schedulerPlanTask.Views.WorkWeekView.Enabled = false;
            this.schedulerPlanTask.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.schedulerPlanTask.ActiveViewChanging += new DevExpress.XtraScheduler.ActiveViewChangingEventHandler(this.schedulerPlanTask_ActiveViewChanging);
            this.schedulerPlanTask.AppointmentDrop += new DevExpress.XtraScheduler.AppointmentDragEventHandler(this.schedulerPlanTask_AppointmentDrop);
            this.schedulerPlanTask.AppointmentResized += new DevExpress.XtraScheduler.AppointmentResizeEventHandler(this.schedulerPlanTask_AppointmentResized);
            this.schedulerPlanTask.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.schedulerPlanTask_PopupMenuShowing);
            // 
            // schedulerStoragePlanTask
            // 
            this.schedulerStoragePlanTask.AppointmentDependencies.DataSource = this.dSScheduler;
            this.schedulerStoragePlanTask.AppointmentDependencies.Mappings.DependentId = "DependenId";
            this.schedulerStoragePlanTask.AppointmentDependencies.Mappings.ParentId = "ParentId";
            this.schedulerStoragePlanTask.Appointments.CommitIdToDataSource = true;
            this.schedulerStoragePlanTask.Appointments.DataSource = this.dSScheduler;
            this.schedulerStoragePlanTask.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128))))), "", "");
            this.schedulerStoragePlanTask.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(190))))), "Important", "&Important");
            this.schedulerStoragePlanTask.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(255))))), "Business", "&Business");
            this.schedulerStoragePlanTask.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(244)))), ((int)(((byte)(156))))), "Personal", "&Personal");
            this.schedulerStoragePlanTask.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(228)))), ((int)(((byte)(199))))), "Vacation", "&Vacation");
            this.schedulerStoragePlanTask.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(206)))), ((int)(((byte)(147))))), "Must Attend", "Must &Attend");
            this.schedulerStoragePlanTask.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255))))), "Travel Required", "&Travel Required");
            this.schedulerStoragePlanTask.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(152))))), "Needs Preparation", "&Needs Preparation");
            this.schedulerStoragePlanTask.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(207)))), ((int)(((byte)(233))))), "Birthday", "&Birthday");
            this.schedulerStoragePlanTask.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(233)))), ((int)(((byte)(223))))), "Anniversary", "&Anniversary");
            this.schedulerStoragePlanTask.Appointments.Labels.Add(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(165))))), "Phone Call", "Phone &Call");
            this.schedulerStoragePlanTask.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStoragePlanTask.Appointments.Mappings.End = "PlanEndDate";
            this.schedulerStoragePlanTask.Appointments.Mappings.ResourceId = "AutoId";
            this.schedulerStoragePlanTask.Appointments.Mappings.Start = "PlanStartDate";
            this.schedulerStoragePlanTask.Appointments.Mappings.Subject = "PlanTaskText";
            this.schedulerStoragePlanTask.Resources.CustomFieldMappings.Add(new DevExpress.XtraScheduler.ResourceCustomFieldMapping("结束日期", "PlanEndDate"));
            this.schedulerStoragePlanTask.Resources.CustomFieldMappings.Add(new DevExpress.XtraScheduler.ResourceCustomFieldMapping("开始日期", "PlanStartDate"));
            this.schedulerStoragePlanTask.Resources.DataSource = this.dSScheduler;
            this.schedulerStoragePlanTask.Resources.Mappings.Caption = "PlanTaskText";
            this.schedulerStoragePlanTask.Resources.Mappings.Id = "AutoId";
            // 
            // dSScheduler
            // 
            this.dSScheduler.DataSetName = "dSScheduler";
            this.dSScheduler.Tables.AddRange(new System.Data.DataTable[] {
            this.TableAppointments,
            this.TableResources,
            this.TableTaskDependencies});
            // 
            // TableAppointments
            // 
            this.TableAppointments.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn3,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9});
            this.TableAppointments.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "AutoId"}, true)});
            this.TableAppointments.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn1};
            this.TableAppointments.TableName = "Appointments";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.ColumnName = "AutoId";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "任务名称";
            this.dataColumn3.ColumnName = "PlanTaskText";
            // 
            // dataColumn7
            // 
            this.dataColumn7.Caption = "计划开始日期";
            this.dataColumn7.ColumnName = "PlanStartDate";
            this.dataColumn7.DataType = typeof(System.DateTime);
            // 
            // dataColumn8
            // 
            this.dataColumn8.Caption = "计划结束日期";
            this.dataColumn8.ColumnName = "PlanEndDate";
            this.dataColumn8.DataType = typeof(System.DateTime);
            // 
            // dataColumn9
            // 
            this.dataColumn9.Caption = "AllDay";
            this.dataColumn9.ColumnName = "AllDay";
            this.dataColumn9.DataType = typeof(bool);
            // 
            // TableResources
            // 
            this.TableResources.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn14,
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn18});
            this.TableResources.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "AutoId"}, true)});
            this.TableResources.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn14};
            this.TableResources.TableName = "Resources";
            // 
            // dataColumn14
            // 
            this.dataColumn14.AllowDBNull = false;
            this.dataColumn14.ColumnName = "AutoId";
            this.dataColumn14.DataType = typeof(int);
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "ParentId";
            this.dataColumn15.DataType = typeof(int);
            // 
            // dataColumn16
            // 
            this.dataColumn16.Caption = "任务名称";
            this.dataColumn16.ColumnName = "PlanTaskText";
            // 
            // dataColumn17
            // 
            this.dataColumn17.Caption = "开始日期";
            this.dataColumn17.ColumnName = "PlanStartDate";
            this.dataColumn17.DataType = typeof(System.DateTime);
            // 
            // dataColumn18
            // 
            this.dataColumn18.Caption = "结束日期";
            this.dataColumn18.ColumnName = "PlanEndDate";
            this.dataColumn18.DataType = typeof(System.DateTime);
            // 
            // TableTaskDependencies
            // 
            this.TableTaskDependencies.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn2,
            this.dataColumn4,
            this.dataColumn5});
            this.TableTaskDependencies.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "DependenId"}, true)});
            this.TableTaskDependencies.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn4};
            this.TableTaskDependencies.TableName = "TaskDependencies";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "ParentId";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.AllowDBNull = false;
            this.dataColumn4.ColumnName = "DependenId";
            this.dataColumn4.DataType = typeof(int);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Id";
            this.dataColumn5.DataType = typeof(int);
            // 
            // pnlEditPlanTask
            // 
            this.pnlEditPlanTask.Controls.Add(this.textPlanTaskStatus);
            this.pnlEditPlanTask.Controls.Add(this.labPlanTaskStatus);
            this.pnlEditPlanTask.Controls.Add(this.lookUpCreator);
            this.pnlEditPlanTask.Controls.Add(this.labelControl2);
            this.pnlEditPlanTask.Controls.Add(this.labCreator);
            this.pnlEditPlanTask.Controls.Add(this.textCreateTime);
            this.pnlEditPlanTask.Controls.Add(this.labPlanTotalDays);
            this.pnlEditPlanTask.Controls.Add(this.spinPlanTotalDays);
            this.pnlEditPlanTask.Controls.Add(this.labPlanEndDate);
            this.pnlEditPlanTask.Controls.Add(this.datePlanEndDate);
            this.pnlEditPlanTask.Controls.Add(this.labPlanStartDate);
            this.pnlEditPlanTask.Controls.Add(this.datePlanStartDate);
            this.pnlEditPlanTask.Controls.Add(this.labProjectUser);
            this.pnlEditPlanTask.Controls.Add(this.searchLookUpProjectUser);
            this.pnlEditPlanTask.Controls.Add(this.searchLookUpTaskNo);
            this.pnlEditPlanTask.Controls.Add(this.labTaskNo);
            this.pnlEditPlanTask.Controls.Add(this.textRemark);
            this.pnlEditPlanTask.Controls.Add(this.labRemark);
            this.pnlEditPlanTask.Controls.Add(this.textPlanTaskText);
            this.pnlEditPlanTask.Controls.Add(this.labPlanTaskText);
            this.pnlEditPlanTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEditPlanTask.Location = new System.Drawing.Point(0, 40);
            this.pnlEditPlanTask.Name = "pnlEditPlanTask";
            this.pnlEditPlanTask.Size = new System.Drawing.Size(1322, 134);
            this.pnlEditPlanTask.TabIndex = 8;
            // 
            // textPlanTaskStatus
            // 
            this.textPlanTaskStatus.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectPlanTask, "PlanTaskStatus", true));
            this.textPlanTaskStatus.EnterMoveNextControl = true;
            this.textPlanTaskStatus.Location = new System.Drawing.Point(910, 21);
            this.textPlanTaskStatus.Name = "textPlanTaskStatus";
            this.textPlanTaskStatus.Properties.ReadOnly = true;
            this.textPlanTaskStatus.Size = new System.Drawing.Size(160, 20);
            this.textPlanTaskStatus.TabIndex = 3;
            this.textPlanTaskStatus.TabStop = false;
            this.textPlanTaskStatus.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.textPlanTaskStatus_CustomDisplayText);
            // 
            // bSProjectPlanTask
            // 
            this.bSProjectPlanTask.DataMember = "ProjectPlanTask";
            this.bSProjectPlanTask.DataSource = this.dSProjectPlanTask;
            this.bSProjectPlanTask.PositionChanged += new System.EventHandler(this.bSProjectPlanTask_PositionChanged);
            // 
            // dSProjectPlanTask
            // 
            this.dSProjectPlanTask.DataSetName = "NewDataSet";
            this.dSProjectPlanTask.Tables.AddRange(new System.Data.DataTable[] {
            this.TableProjectPlanTask});
            // 
            // TableProjectPlanTask
            // 
            this.TableProjectPlanTask.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColAutoId,
            this.dataColProjectNo,
            this.dataColPlanTaskText,
            this.dataColTaskNo,
            this.dataColPlanTaskStatus,
            this.dataColProjectUser,
            this.dataColPlanStartDate,
            this.dataColPlanEndDate,
            this.dataColPlanTotalDays,
            this.dataColRemark,
            this.dataColCreator,
            this.dataColCreateTime,
            this.dataColUserId,
            this.dataColumn6});
            this.TableProjectPlanTask.TableName = "ProjectPlanTask";
            this.TableProjectPlanTask.TableNewRow += new System.Data.DataTableNewRowEventHandler(this.TableProjectPlanTask_TableNewRow);
            // 
            // dataColAutoId
            // 
            this.dataColAutoId.ColumnName = "AutoId";
            this.dataColAutoId.DataType = typeof(int);
            // 
            // dataColProjectNo
            // 
            this.dataColProjectNo.Caption = "项目号";
            this.dataColProjectNo.ColumnName = "ProjectNo";
            // 
            // dataColPlanTaskText
            // 
            this.dataColPlanTaskText.Caption = "任务名称";
            this.dataColPlanTaskText.ColumnName = "PlanTaskText";
            // 
            // dataColTaskNo
            // 
            this.dataColTaskNo.Caption = "任务类别";
            this.dataColTaskNo.ColumnName = "TaskNo";
            this.dataColTaskNo.DataType = typeof(int);
            // 
            // dataColPlanTaskStatus
            // 
            this.dataColPlanTaskStatus.Caption = "任务状态";
            this.dataColPlanTaskStatus.ColumnName = "PlanTaskStatus";
            this.dataColPlanTaskStatus.DataType = typeof(short);
            // 
            // dataColProjectUser
            // 
            this.dataColProjectUser.Caption = "任务实施人";
            this.dataColProjectUser.ColumnName = "ProjectUser";
            this.dataColProjectUser.DataType = typeof(int);
            // 
            // dataColPlanStartDate
            // 
            this.dataColPlanStartDate.Caption = "计划开始日期";
            this.dataColPlanStartDate.ColumnName = "PlanStartDate";
            this.dataColPlanStartDate.DataType = typeof(System.DateTime);
            // 
            // dataColPlanEndDate
            // 
            this.dataColPlanEndDate.Caption = "计划结束日期";
            this.dataColPlanEndDate.ColumnName = "PlanEndDate";
            this.dataColPlanEndDate.DataType = typeof(System.DateTime);
            // 
            // dataColPlanTotalDays
            // 
            this.dataColPlanTotalDays.Caption = "计划工期";
            this.dataColPlanTotalDays.ColumnName = "PlanTotalDays";
            this.dataColPlanTotalDays.DataType = typeof(int);
            // 
            // dataColRemark
            // 
            this.dataColRemark.Caption = "备注";
            this.dataColRemark.ColumnName = "Remark";
            // 
            // dataColCreator
            // 
            this.dataColCreator.Caption = "登记人";
            this.dataColCreator.ColumnName = "Creator";
            this.dataColCreator.DataType = typeof(int);
            // 
            // dataColCreateTime
            // 
            this.dataColCreateTime.Caption = "登记时间";
            this.dataColCreateTime.ColumnName = "CreateTime";
            this.dataColCreateTime.DataType = typeof(System.DateTime);
            // 
            // dataColUserId
            // 
            this.dataColUserId.Caption = "任务实施人";
            this.dataColUserId.ColumnName = "UserId";
            this.dataColUserId.DataType = typeof(int);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "ParentId";
            this.dataColumn6.DataType = typeof(int);
            // 
            // labPlanTaskStatus
            // 
            this.labPlanTaskStatus.Location = new System.Drawing.Point(830, 24);
            this.labPlanTaskStatus.Name = "labPlanTaskStatus";
            this.labPlanTaskStatus.Size = new System.Drawing.Size(24, 14);
            this.labPlanTaskStatus.TabIndex = 35;
            this.labPlanTaskStatus.Text = "状态";
            // 
            // lookUpCreator
            // 
            this.lookUpCreator.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectPlanTask, "Creator", true));
            this.lookUpCreator.EnterMoveNextControl = true;
            this.lookUpCreator.Location = new System.Drawing.Point(910, 55);
            this.lookUpCreator.Name = "lookUpCreator";
            this.lookUpCreator.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoId", "AutoId", 80, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoginId", "用户名", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "员工名", 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpCreator.Properties.DisplayMember = "EmpName";
            this.lookUpCreator.Properties.NullText = "";
            this.lookUpCreator.Properties.ReadOnly = true;
            this.lookUpCreator.Properties.ValueMember = "AutoId";
            this.lookUpCreator.Size = new System.Drawing.Size(160, 20);
            this.lookUpCreator.TabIndex = 7;
            this.lookUpCreator.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(830, 92);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "登记时间";
            // 
            // labCreator
            // 
            this.labCreator.Location = new System.Drawing.Point(830, 58);
            this.labCreator.Name = "labCreator";
            this.labCreator.Size = new System.Drawing.Size(60, 14);
            this.labCreator.TabIndex = 33;
            this.labCreator.Text = "登记修改人";
            // 
            // textCreateTime
            // 
            this.textCreateTime.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectPlanTask, "CreateTime", true));
            this.textCreateTime.EnterMoveNextControl = true;
            this.textCreateTime.Location = new System.Drawing.Point(910, 89);
            this.textCreateTime.Name = "textCreateTime";
            this.textCreateTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.textCreateTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textCreateTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.textCreateTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.textCreateTime.Properties.ReadOnly = true;
            this.textCreateTime.Size = new System.Drawing.Size(160, 20);
            this.textCreateTime.TabIndex = 9;
            this.textCreateTime.TabStop = false;
            // 
            // labPlanTotalDays
            // 
            this.labPlanTotalDays.Location = new System.Drawing.Point(575, 58);
            this.labPlanTotalDays.Name = "labPlanTotalDays";
            this.labPlanTotalDays.Size = new System.Drawing.Size(48, 14);
            this.labPlanTotalDays.TabIndex = 31;
            this.labPlanTotalDays.Text = "计划工期";
            // 
            // spinPlanTotalDays
            // 
            this.spinPlanTotalDays.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectPlanTask, "PlanTotalDays", true));
            this.spinPlanTotalDays.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinPlanTotalDays.EnterMoveNextControl = true;
            this.spinPlanTotalDays.Location = new System.Drawing.Point(646, 55);
            this.spinPlanTotalDays.Name = "spinPlanTotalDays";
            this.spinPlanTotalDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinPlanTotalDays.Properties.Mask.EditMask = "d";
            this.spinPlanTotalDays.Properties.MaxValue = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.spinPlanTotalDays.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinPlanTotalDays.Size = new System.Drawing.Size(160, 20);
            this.spinPlanTotalDays.TabIndex = 6;
            this.spinPlanTotalDays.EditValueChanged += new System.EventHandler(this.spinPlanTotalDays_EditValueChanged);
            // 
            // labPlanEndDate
            // 
            this.labPlanEndDate.Location = new System.Drawing.Point(306, 58);
            this.labPlanEndDate.Name = "labPlanEndDate";
            this.labPlanEndDate.Size = new System.Drawing.Size(72, 14);
            this.labPlanEndDate.TabIndex = 29;
            this.labPlanEndDate.Text = "计划结束日期";
            // 
            // datePlanEndDate
            // 
            this.datePlanEndDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectPlanTask, "PlanEndDate", true));
            this.datePlanEndDate.EditValue = null;
            this.datePlanEndDate.EnterMoveNextControl = true;
            this.datePlanEndDate.Location = new System.Drawing.Point(394, 55);
            this.datePlanEndDate.Name = "datePlanEndDate";
            this.datePlanEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePlanEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePlanEndDate.Size = new System.Drawing.Size(160, 20);
            this.datePlanEndDate.TabIndex = 5;
            this.datePlanEndDate.EditValueChanged += new System.EventHandler(this.datePlanStartDate_EditValueChanged);
            // 
            // labPlanStartDate
            // 
            this.labPlanStartDate.Location = new System.Drawing.Point(36, 58);
            this.labPlanStartDate.Name = "labPlanStartDate";
            this.labPlanStartDate.Size = new System.Drawing.Size(72, 14);
            this.labPlanStartDate.TabIndex = 27;
            this.labPlanStartDate.Text = "计划开始日期";
            // 
            // datePlanStartDate
            // 
            this.datePlanStartDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectPlanTask, "PlanStartDate", true));
            this.datePlanStartDate.EditValue = null;
            this.datePlanStartDate.EnterMoveNextControl = true;
            this.datePlanStartDate.Location = new System.Drawing.Point(124, 55);
            this.datePlanStartDate.Name = "datePlanStartDate";
            this.datePlanStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePlanStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePlanStartDate.Size = new System.Drawing.Size(160, 20);
            this.datePlanStartDate.TabIndex = 4;
            this.datePlanStartDate.EditValueChanged += new System.EventHandler(this.datePlanStartDate_EditValueChanged);
            // 
            // labProjectUser
            // 
            this.labProjectUser.Location = new System.Drawing.Point(575, 24);
            this.labProjectUser.Name = "labProjectUser";
            this.labProjectUser.Size = new System.Drawing.Size(36, 14);
            this.labProjectUser.TabIndex = 25;
            this.labProjectUser.Text = "实施人";
            // 
            // searchLookUpProjectUser
            // 
            this.searchLookUpProjectUser.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectPlanTask, "ProjectUser", true));
            this.searchLookUpProjectUser.EnterMoveNextControl = true;
            this.searchLookUpProjectUser.Location = new System.Drawing.Point(646, 21);
            this.searchLookUpProjectUser.Name = "searchLookUpProjectUser";
            this.searchLookUpProjectUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpProjectUser.Properties.DisplayMember = "EmpName";
            this.searchLookUpProjectUser.Properties.NullText = "";
            this.searchLookUpProjectUser.Properties.ValueMember = "AutoId";
            this.searchLookUpProjectUser.Properties.View = this.searchLookUpProjectUserView;
            this.searchLookUpProjectUser.Size = new System.Drawing.Size(160, 20);
            this.searchLookUpProjectUser.TabIndex = 2;
            // 
            // searchLookUpProjectUserView
            // 
            this.searchLookUpProjectUserView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColuAutoId,
            this.gridColuEmpName,
            this.gridColuDepartmentNo,
            this.gridColuDepartmentName});
            this.searchLookUpProjectUserView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpProjectUserView.IndicatorWidth = 60;
            this.searchLookUpProjectUserView.Name = "searchLookUpProjectUserView";
            this.searchLookUpProjectUserView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpProjectUserView.OptionsView.ShowGroupPanel = false;
            this.searchLookUpProjectUserView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewPlanTask_CustomDrawRowIndicator);
            // 
            // gridColuAutoId
            // 
            this.gridColuAutoId.Caption = "AutoId";
            this.gridColuAutoId.FieldName = "AutoId";
            this.gridColuAutoId.Name = "gridColuAutoId";
            // 
            // gridColuEmpName
            // 
            this.gridColuEmpName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColuEmpName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColuEmpName.Caption = "姓名";
            this.gridColuEmpName.FieldName = "EmpName";
            this.gridColuEmpName.Name = "gridColuEmpName";
            this.gridColuEmpName.Visible = true;
            this.gridColuEmpName.VisibleIndex = 0;
            // 
            // gridColuDepartmentNo
            // 
            this.gridColuDepartmentNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColuDepartmentNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColuDepartmentNo.Caption = "部门编号";
            this.gridColuDepartmentNo.FieldName = "DepartmentNo";
            this.gridColuDepartmentNo.Name = "gridColuDepartmentNo";
            this.gridColuDepartmentNo.Visible = true;
            this.gridColuDepartmentNo.VisibleIndex = 1;
            // 
            // gridColuDepartmentName
            // 
            this.gridColuDepartmentName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColuDepartmentName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColuDepartmentName.Caption = "部门名称";
            this.gridColuDepartmentName.FieldName = "DepartmentName";
            this.gridColuDepartmentName.Name = "gridColuDepartmentName";
            this.gridColuDepartmentName.Visible = true;
            this.gridColuDepartmentName.VisibleIndex = 2;
            // 
            // searchLookUpTaskNo
            // 
            this.searchLookUpTaskNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectPlanTask, "TaskNo", true));
            this.searchLookUpTaskNo.EnterMoveNextControl = true;
            this.searchLookUpTaskNo.Location = new System.Drawing.Point(394, 21);
            this.searchLookUpTaskNo.Name = "searchLookUpTaskNo";
            this.searchLookUpTaskNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpTaskNo.Properties.DisplayMember = "TaskText";
            this.searchLookUpTaskNo.Properties.NullText = "";
            this.searchLookUpTaskNo.Properties.ValueMember = "AutoId";
            this.searchLookUpTaskNo.Properties.View = this.searchLookUpTaskNoView;
            this.searchLookUpTaskNo.Size = new System.Drawing.Size(160, 20);
            this.searchLookUpTaskNo.TabIndex = 1;
            // 
            // searchLookUpTaskNoView
            // 
            this.searchLookUpTaskNoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.searchLookUpTaskNoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpTaskNoView.IndicatorWidth = 60;
            this.searchLookUpTaskNoView.Name = "searchLookUpTaskNoView";
            this.searchLookUpTaskNoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpTaskNoView.OptionsView.ShowGroupPanel = false;
            this.searchLookUpTaskNoView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewPlanTask_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "AutoId";
            this.gridColumn1.FieldName = "AutoId";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "类别编号";
            this.gridColumn2.FieldName = "TaskNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "类别名称";
            this.gridColumn3.FieldName = "TaskText";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // labTaskNo
            // 
            this.labTaskNo.Location = new System.Drawing.Point(306, 24);
            this.labTaskNo.Name = "labTaskNo";
            this.labTaskNo.Size = new System.Drawing.Size(48, 14);
            this.labTaskNo.TabIndex = 22;
            this.labTaskNo.Text = "任务类别";
            // 
            // textRemark
            // 
            this.textRemark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectPlanTask, "Remark", true));
            this.textRemark.EnterMoveNextControl = true;
            this.textRemark.Location = new System.Drawing.Point(124, 89);
            this.textRemark.Name = "textRemark";
            this.textRemark.Size = new System.Drawing.Size(682, 20);
            this.textRemark.TabIndex = 8;
            // 
            // labRemark
            // 
            this.labRemark.Location = new System.Drawing.Point(36, 92);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new System.Drawing.Size(24, 14);
            this.labRemark.TabIndex = 17;
            this.labRemark.Text = "备注";
            // 
            // textPlanTaskText
            // 
            this.textPlanTaskText.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bSProjectPlanTask, "PlanTaskText", true));
            this.textPlanTaskText.EnterMoveNextControl = true;
            this.textPlanTaskText.Location = new System.Drawing.Point(124, 21);
            this.textPlanTaskText.Name = "textPlanTaskText";
            this.textPlanTaskText.Size = new System.Drawing.Size(160, 20);
            this.textPlanTaskText.TabIndex = 0;
            // 
            // labPlanTaskText
            // 
            this.labPlanTaskText.Location = new System.Drawing.Point(36, 24);
            this.labPlanTaskText.Name = "labPlanTaskText";
            this.labPlanTaskText.Size = new System.Drawing.Size(48, 14);
            this.labPlanTaskText.TabIndex = 12;
            this.labPlanTaskText.Text = "任务名称";
            // 
            // pnlToolBarPlanTask
            // 
            this.pnlToolBarPlanTask.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.pnlToolBarPlanTask.Appearance.Options.UseBackColor = true;
            this.pnlToolBarPlanTask.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlToolBarPlanTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBarPlanTask.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBarPlanTask.Name = "pnlToolBarPlanTask";
            this.pnlToolBarPlanTask.Size = new System.Drawing.Size(1322, 40);
            this.pnlToolBarPlanTask.TabIndex = 3;
            // 
            // bSAppointments
            // 
            this.bSAppointments.DataMember = "Appointments";
            this.bSAppointments.DataSource = this.dSScheduler;
            // 
            // bSResources
            // 
            this.bSResources.DataMember = "Resources";
            this.bSResources.DataSource = this.dSScheduler;
            // 
            // bSTaskDependencies
            // 
            this.bSTaskDependencies.DataMember = "TaskDependencies";
            this.bSTaskDependencies.DataSource = this.dSScheduler;
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.Controls.Add(this.TabControlMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 52);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1332, 677);
            this.pnlMain.TabIndex = 3;
            // 
            // FrmProjectPlanTask
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1332, 729);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmProjectPlanTask";
            this.TabText = "项目计划任务管理";
            this.Text = "项目计划任务管理";
            this.Load += new System.EventHandler(this.FrmProjectPlanTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlMain)).EndInit();
            this.TabControlMain.ResumeLayout(false);
            this.PagePlanTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitControlPlanTask)).EndInit();
            this.splitControlPlanTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resourcesTreePlanTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerPlanTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStoragePlanTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSScheduler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableResources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableTaskDependencies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEditPlanTask)).EndInit();
            this.pnlEditPlanTask.ResumeLayout(false);
            this.pnlEditPlanTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPlanTaskStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSProjectPlanTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSProjectPlanTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableProjectPlanTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCreator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textCreateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPlanTotalDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePlanStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpProjectUserView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpTaskNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpTaskNoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPlanTaskText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolBarPlanTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSResources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSTaskDependencies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpProjectNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpProjectNoView;
        private DevExpress.XtraEditors.LabelControl labProjectNo;
        private DevExpress.XtraTab.XtraTabControl TabControlMain;
        private DevExpress.XtraTab.XtraTabPage PagePlanTask;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private System.Windows.Forms.BindingSource bSProjectPlanTask;
        private System.Data.DataSet dSProjectPlanTask;
        private System.Data.DataTable TableProjectPlanTask;
        private System.Data.DataColumn dataColAutoId;
        private System.Data.DataColumn dataColProjectNo;
        private System.Data.DataColumn dataColPlanTaskText;
        private System.Data.DataColumn dataColTaskNo;
        private System.Data.DataColumn dataColPlanTaskStatus;
        private System.Data.DataColumn dataColProjectUser;
        private System.Data.DataColumn dataColPlanStartDate;
        private System.Data.DataColumn dataColPlanEndDate;
        private System.Data.DataColumn dataColPlanTotalDays;
        private System.Data.DataColumn dataColRemark;
        private System.Data.DataColumn dataColCreator;
        private System.Data.DataColumn dataColCreateTime;
        private DevExpress.XtraEditors.PanelControl pnlToolBarPlanTask;
        private DevExpress.XtraEditors.PanelControl pnlEditPlanTask;
        private DevExpress.XtraEditors.TextEdit textRemark;
        private DevExpress.XtraEditors.LabelControl labRemark;
        private DevExpress.XtraEditors.TextEdit textPlanTaskText;
        private DevExpress.XtraEditors.LabelControl labPlanTaskText;
        private DevExpress.XtraEditors.LabelControl labTaskNo;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpTaskNo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpTaskNoView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.LabelControl labPlanTotalDays;
        private DevExpress.XtraEditors.SpinEdit spinPlanTotalDays;
        private DevExpress.XtraEditors.LabelControl labPlanEndDate;
        private DevExpress.XtraEditors.DateEdit datePlanEndDate;
        private DevExpress.XtraEditors.LabelControl labPlanStartDate;
        private DevExpress.XtraEditors.DateEdit datePlanStartDate;
        private DevExpress.XtraEditors.LabelControl labProjectUser;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpProjectUser;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpProjectUserView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuDepartmentNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColuDepartmentName;
        private System.Data.DataColumn dataColUserId;
        private DevExpress.XtraEditors.SplitContainerControl splitControlPlanTask;
        private DevExpress.XtraScheduler.UI.ResourcesTree resourcesTreePlanTask;
        private DevExpress.XtraScheduler.SchedulerControl schedulerPlanTask;
        private System.Data.DataSet dSScheduler;
        private System.Data.DataTable TableAppointments;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataTable TableResources;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumn15;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataTable TableTaskDependencies;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.BindingSource bSAppointments;
        private System.Windows.Forms.BindingSource bSResources;
        private System.Windows.Forms.BindingSource bSTaskDependencies;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn col开始日期;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn col结束日期;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn colPlanTaskText;
        private System.Data.DataColumn dataColumn6;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn colAutoId;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStoragePlanTask;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labCreator;
        private DevExpress.XtraEditors.TextEdit textCreateTime;
        private DevExpress.XtraEditors.LookUpEdit lookUpCreator;
        private DevExpress.XtraEditors.TextEdit textPlanTaskStatus;
        private DevExpress.XtraEditors.LabelControl labPlanTaskStatus;
    }
}