using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using PSAP.PSAPCommon;
using PSAP.DAO.BSDAO;
using PSAP.DAO.PMDAO;
using System.Data.SqlClient;
using DevExpress.XtraScheduler;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmProjectPlanTask : DockContent
    {
        #region 私有变量

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmProjectPlanTaskDAO planTaskDAO = new FrmProjectPlanTaskDAO();
        FrmProjectUserAndTaskTypeDAO taskTypeDAO = new FrmProjectUserAndTaskTypeDAO();
        FrmBaseEdit editForm = null;

        /// <summary>
        /// 锁定控件状态
        /// </summary>
        bool isLockControl = false;

        /// <summary>
        /// 锁定列表控件更新
        /// </summary>
        bool isLockGrid = false;

        /// <summary>
        /// 每页显示的行数
        /// </summary>
        int ResourcesPerPage = 10;

        /// <summary>
        /// 日程条的高度
        /// </summary>
        int SchedulerBarHeight = 30;

        /// <summary>
        /// 日程条的颜色
        /// </summary>
        Color SchedulerBarColor = Color.FromArgb(128, 255, 128);

        #endregion

        #region 构造函数

        public FrmProjectPlanTask()
        {
            InitializeComponent();

            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.VisibleSearchControl = false;
                    editForm.TopLevel = false;
                    editForm.TableName = "PM_ProjectPlanTask";
                    editForm.TableCaption = "项目计划任务";
                    editForm.Sql = string.Format("select PM_ProjectPlanTask.*, BS_ProjectUser.UserId from PM_ProjectPlanTask left join BS_ProjectUser on PM_ProjectPlanTask.ProjectUser = BS_ProjectUser.AutoId where PM_ProjectPlanTask.ProjectNo = '{0}' order by AutoId", "");
                    editForm.PrimaryKeyColumn = "AutoId";
                    editForm.MasterDataSet = dSProjectPlanTask;
                    editForm.MasterBindingSource = bSProjectPlanTask;
                    editForm.MasterEditPanel = pnlEditPlanTask;
                    //editForm.BrowseXtraGridView = gridViewPlanTask;
                    editForm.CheckControl += CheckControl;
                    editForm.NewBefore += NewBefore;
                    editForm.AlterBefore += AlterBefore;
                    editForm.SaveRowBefore += SaveRowBefore;
                    editForm.DeleteRowBefore += DeleteRowBefore;
                    editForm.QueryDataAfter += QueryDataAfter;
                    editForm.CancelAfter += CancelAfter;
                    this.pnlToolBarPlanTask.Controls.Add(editForm);
                    editForm.Dock = DockStyle.Fill;
                    editForm.Show();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体构造函数错误。", ex);
            }
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmProjectPlanTask_Load(object sender, EventArgs e)
        {
            try
            {
                searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(false);
                DataTable userTable = commonDAO.QueryUserInfo(false);

                searchLookUpTaskNo.Properties.DataSource = null;
                searchLookUpProjectUser.Properties.DataSource = null;

                schedulerStoragePlanTask.Appointments.DataSource = bSAppointments;
                schedulerStoragePlanTask.Appointments.DataMember = "";
                schedulerStoragePlanTask.Resources.DataSource = bSProjectPlanTask;
                schedulerStoragePlanTask.Resources.DataMember = "";
                schedulerStoragePlanTask.AppointmentDependencies.DataSource = bSTaskDependencies;
                schedulerStoragePlanTask.AppointmentDependencies.DataMember = "";

                //schedulerPlanTask.ActiveViewType = SchedulerViewType.Gantt;
                //schedulerPlanTask.GroupType = SchedulerGroupType.Resource;
                //schedulerPlanTask.GanttView.ShowResourceHeaders = false;
                //schedulerPlanTask.GanttView.NavigationButtonVisibility = NavigationButtonVisibility.Never;

                schedulerPlanTask.Start = DateTime.Now.Date;

                schedulerPlanTask.Views.GanttView.ResourcesPerPage = ResourcesPerPage;
                schedulerPlanTask.Views[SchedulerViewType.Gantt].AppointmentDisplayOptions.AppointmentHeight = SchedulerBarHeight;
                schedulerStoragePlanTask.Appointments.Labels.GetById(0).Color = SchedulerBarColor;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        #endregion

        #region 主区域

        /// <summary>
        /// 选择项目号查询所有信息
        /// </summary>
        private void searchLookUpProjectNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string projectNoStr = DataTypeConvert.GetString(searchLookUpProjectNo.EditValue);

                DataTable taskTypeTable = planTaskDAO.QueryProjectTaskType(projectNoStr);
                searchLookUpTaskNo.Properties.DataSource = taskTypeTable;
                DataTable tempTable = new DataTable();
                taskTypeDAO.QueryProjectUser(tempTable, projectNoStr);
                searchLookUpProjectUser.Properties.DataSource = tempTable;

                RefreshProjectPlanTask(projectNoStr);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择项目号查询所有信息错误。", ex);
            }
        }

        #endregion

        #region 计划任务登记区域

        /// <summary>
        /// 刷新项目任务类别
        /// </summary>
        private void RefreshProjectPlanTask(string projectNoStr)
        {
            editForm.Sql = string.Format("select PM_ProjectPlanTask.*, BS_ProjectUser.UserId from PM_ProjectPlanTask left join BS_ProjectUser on PM_ProjectPlanTask.ProjectUser = BS_ProjectUser.AutoId where PM_ProjectPlanTask.ProjectNo = '{0}' order by AutoId", projectNoStr);
            editForm.btnRefresh_Click(null, null);
        }

        #region 登记单

        /// <summary>
        /// 新增设定默认值
        /// </summary>
        private void TableProjectPlanTask_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            DateTime nowTime = BaseSQL.GetServerDateTime();
            e.Row["PlanStartDate"] = nowTime.Date;
            e.Row["PlanEndDate"] = nowTime.Date;
            e.Row["PlanTotalDays"] = 1;
            e.Row["PlanTaskStatus"] = 1;
            e.Row["ProjectNo"] = DataTypeConvert.GetString(searchLookUpProjectNo.EditValue);
            e.Row["Creator"] = SystemInfo.user.AutoId;
            e.Row["CreateTime"] = nowTime;
        }

        /// <summary>
        /// 保存之前的回调方法
        /// </summary>
        private bool CheckControl()
        {
            if (textPlanTaskText.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("任务名称不能为空，请重新操作。");
                bSProjectPlanTask_PositionChanged(null, null);
                textPlanTaskText.Focus();
                return false;
            }
            if (searchLookUpTaskNo.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("任务类别不能为空，请重新操作。");
                bSProjectPlanTask_PositionChanged(null, null);
                searchLookUpTaskNo.Focus();
                return false;
            }
            if (searchLookUpProjectUser.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("实施人不能为空，请重新操作。");
                bSProjectPlanTask_PositionChanged(null, null);
                searchLookUpProjectUser.Focus();
                return false;
            }


            if (DataTypeConvert.GetString(datePlanStartDate.EditValue) == "")
            {
                MessageHandler.ShowMessageBox("计划开始日期不能为空，请重新操作。");
                bSProjectPlanTask_PositionChanged(null, null);
                datePlanStartDate.Focus();
                return false;
            }
            if (DataTypeConvert.GetString(datePlanEndDate.EditValue) == "")
            {
                MessageHandler.ShowMessageBox("计划结束日期不能为空，请重新操作。");
                bSProjectPlanTask_PositionChanged(null, null);
                datePlanEndDate.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 新增之前的回调方法
        /// </summary>
        private bool NewBefore()
        {
            if (searchLookUpProjectNo.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("请先选择要查询的项目号。");
                searchLookUpProjectNo.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 修改之前的回调方法
        /// </summary>
        private bool AlterBefore(DataRow dr)
        {
            return CheckIsPlanEdit(dr);
        }

        /// <summary>
        /// 删除之前的回调方法
        /// </summary>
        private bool DeleteRowBefore(DataRow dr, SqlCommand cmd)
        {
            return CheckIsPlanEdit(dr);
        }

        /// <summary>
        /// 保存之前的回调方法
        /// </summary>
        private bool SaveRowBefore(DataRow dr, SqlCommand cmd)
        {
            if (dr.RowState == DataRowState.Modified)
                return CheckIsPlanEdit(dr);
            return true;
        }

        /// <summary>
        /// 刷新后执行的查询
        /// </summary>
        private void QueryDataAfter()
        {
            TableAppointments.Rows.Clear();

            string projectNoStr = DataTypeConvert.GetString(searchLookUpProjectNo.EditValue);
            string Sql = string.Format("select AutoId, PlanTaskText, PlanStartDate, DATEADD(day, 1, PlanEndDate) as PlanEndDate, Cast(1 as bit) as AllDay from PM_ProjectPlanTask where ProjectNo = '{0}' order by AutoId", projectNoStr);
            BaseSQL.Query(Sql, TableAppointments);

            if (TableAppointments.Rows.Count > 0)
                schedulerPlanTask.Start = DataTypeConvert.GetDateTime(((TableAppointments.Compute("Min(PlanStartDate)", "true").ToString())));

            bSProjectPlanTask_PositionChanged(null, null);
        }

        /// <summary>
        /// 取消后执行的方法
        /// </summary>
        private void CancelAfter()
        {
            bSProjectPlanTask_PositionChanged(null, null);
            (((DataRowView)bSProjectPlanTask.Current).Row).RejectChanges();
        }

        /// <summary>
        /// 检查是否可以修改
        /// </summary>
        private bool CheckIsPlanEdit(DataRow dr)
        {
            int userIdInt = DataTypeConvert.GetInt(dr["UserId", DataRowVersion.Original]);
            if (userIdInt == SystemInfo.user.AutoId)
            {
                if (planTaskDAO.QueryProjectUser_SingleValue("IsPlanEdit", DataTypeConvert.GetInt(dr["ProjectUser", DataRowVersion.Original])) != 1)
                {
                    MessageHandler.ShowMessageBox("不可以修改实施人本人的计划任务。");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 设定计划的开始结束日期
        /// </summary>
        private void datePlanStartDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (bSProjectPlanTask.Current == null)
                    return;

                if (editForm.btnSave.Text != "保存")
                    return;

                if (isLockControl)
                    return;

                isLockControl = true;

                if (datePlanStartDate.DateTime.Date > datePlanEndDate.DateTime.Date)
                {
                    MessageHandler.ShowMessageBox("计划开始日期不能大于计划结束日期，请重新操作。");
                    datePlanEndDate.DateTime = datePlanStartDate.DateTime.Date;
                    isLockControl = false;
                    return;
                }

                spinPlanTotalDays.Value = (datePlanEndDate.DateTime.Date - datePlanStartDate.DateTime.Date).Days + 1;

                isLockControl = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定计划的开始结束日期错误。", ex);
            }
        }

        /// <summary>
        /// 设定计划的工期
        /// </summary>
        private void spinPlanTotalDays_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (bSProjectPlanTask.Current == null)
                    return;

                if (editForm.btnSave.Text != "保存")
                    return;

                if (isLockControl)
                    return;

                isLockControl = true;

                datePlanEndDate.DateTime = datePlanStartDate.DateTime.Date.AddDays(DataTypeConvert.GetInt(spinPlanTotalDays.Value) - 1);

                isLockControl = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定计划的工期错误。", ex);
            }
        }

        ///// <summary>
        ///// 设定列表显示信息
        ///// </summary>
        //private void gridViewPlanTask_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        //{
        //    if (e.Column.FieldName == "PlanTaskStatus")
        //    {
        //        e.DisplayText = CommonHandler.Get_PlanTaskStatus_Desc(e.Value.ToString());
        //    }
        //}

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewPlanTask_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewPlanTask_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ControlHandler.GridView_GetFocusedCellDisplayText_KeyDown(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--获取单元格显示的信息错误。", ex);
            }
        }

        /// <summary>
        /// 设定当前选中的节点
        /// </summary>
        private void bSProjectPlanTask_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (bSProjectPlanTask.Current != null)
                {
                    DataRow dr = ((DataRowView)bSProjectPlanTask.Current).Row;
                    int autoIdInt = DataTypeConvert.GetInt(dr["AutoId"]);

                    for (int i = 0; i < resourcesTreePlanTask.Nodes.Count; i++)
                    {
                        if (DataTypeConvert.GetInt(resourcesTreePlanTask.Nodes[i]["AutoId"]) == autoIdInt)
                        {
                            isLockGrid = true;
                            resourcesTreePlanTask.FocusedNode = resourcesTreePlanTask.Nodes[i];
                            isLockGrid = false;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定当前选中的节点错误。", ex);
            }
        }

        #endregion

        #region ResourcesTree 控件事件

        /// <summary>
        /// 确定行号
        /// </summary>
        private void resourcesTreePlanTask_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            ControlHandler.TreeList_CustomDrawNodeIndicator_AllNode(sender, e);
        }

        /// <summary>
        /// 列表聚焦改变刷新当前选中行的信息
        /// </summary>
        private void resourcesTreePlanTask_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            try
            {
                if (bSProjectPlanTask.Current != null && !isLockGrid)
                {
                    DataRow dr = ((DataRowView)bSProjectPlanTask.Current).Row;
                    if (e.OldNode != null)
                    {
                        int oldAutoId = DataTypeConvert.GetInt(e.OldNode["AutoId"]);
                        DataRow[] olddrs;
                        if (oldAutoId == 0)
                            olddrs = TableProjectPlanTask.Select("AutoId is null");
                        else
                            olddrs = TableProjectPlanTask.Select(string.Format("AutoId = {0}", oldAutoId));

                        if (olddrs.Length > 0 && dr == olddrs[0])
                        {
                            if (dr.RowState != DataRowState.Unchanged)
                            {
                                if (MessageHandler.ShowMessageBox_YesNo("确认是否保存当前行信息？") == DialogResult.Yes)
                                {
                                    if (!editForm.btnSave_Click())
                                    {
                                        //bSProjectPlanTask_PositionChanged(null, null);
                                        //e.Allow = false;
                                        e.CanFocus = false;
                                        return;
                                    }
                                }
                                else
                                {
                                    dr.RejectChanges();
                                    editForm.Set_Button_State(true);
                                    editForm.Set_EditZone_ControlReadOnly(true);
                                }
                            }
                            else
                            {
                                editForm.Set_Button_State(true);
                                editForm.Set_EditZone_ControlReadOnly(true);
                            }
                        }
                    }

                    if (e.Node != null)
                    {
                        DataRow[] newdrs = TableProjectPlanTask.Select(string.Format("AutoId = {0}", DataTypeConvert.GetInt(e.Node["AutoId"])));
                        if (newdrs.Length > 0)
                        {
                            bSProjectPlanTask.Position = TableProjectPlanTask.Rows.IndexOf(newdrs[0]);
                            if (resourcesTreePlanTask.FocusedNode == null)
                                bSProjectPlanTask_PositionChanged(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--列表聚焦改变刷新当前选中行的信息错误。", ex);
            }
        }

        /// <summary>
        /// 双击聚焦开始日期
        /// </summary>
        private void resourcesTreePlanTask_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (resourcesTreePlanTask.FocusedNode != null)
                schedulerPlanTask.Start = DataTypeConvert.GetDateTime(resourcesTreePlanTask.FocusedNode["PlanStartDate"]);
        }

        #endregion

        #region SchedulerControl 控件事件

        /// <summary>
        /// 屏蔽其他视图模式
        /// </summary>
        private void schedulerPlanTask_ActiveViewChanging(object sender, ActiveViewChangingEventArgs e)
        {
            if (e.NewView.Type != SchedulerViewType.Gantt)
                e.Cancel = true;
        }

        /// <summary>
        /// 屏蔽右击菜单
        /// </summary>
        private void schedulerPlanTask_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                for(int i = 0;i<e.Menu.Items.Count;i++)
                {
                    e.Menu.Items[i].Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--屏蔽右击菜单错误。", ex);
            }
        }

        #endregion

        #endregion
    }
}
