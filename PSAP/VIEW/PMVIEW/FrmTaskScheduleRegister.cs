using DevExpress.XtraGrid.Views.Base;
using PSAP.DAO.BSDAO;
using PSAP.DAO.PMDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmTaskScheduleRegister : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmProjectListDAO projectDAO = new FrmProjectListDAO();
        FrmProjectPlanTaskDAO planTaskDAO = new FrmProjectPlanTaskDAO();
        FrmTaskScheduleRegisterDAO taskSRDAO = new FrmTaskScheduleRegisterDAO();

        /// <summary>
        /// 锁定控件状态
        /// </summary>
        bool isLockControl = false;

        public FrmTaskScheduleRegister()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmRegisterScheduleQuery_Load(object sender, EventArgs e)
        {
            try
            {
                ControlCommonInit ctlInit = new ControlCommonInit();
                ctlInit.SearchLookUpEdit_ProjectList(searchLookUpProjectNo, true);
                searchLookUpProjectNo.Text = "全部";
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpRSProjectUser);
                searchLookUpRSProjectUser.EditValue = SystemInfo.user.AutoId;
                //searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(true);
                //searchLookUpProjectNo.Text = "全部";

                searchLookUpRSTaskNo.Properties.DataSource = null;

                //searchLookUpRSProjectUser.Properties.DataSource = projectDAO.QueryUserInfo(true);
                //searchLookUpRSProjectUser.EditValue = SystemInfo.user.AutoId;

                textCommon.Text = "";

                checkNoComplete.Checked = true;

                repLookUpUserId.DataSource = searchLookUpRSProjectUser.Properties.DataSource;

                btnQueryTask_Click(null, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 选择项目号事件
        /// </summary>
        private void searchLookUpProjectNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string projectNoStr = DataTypeConvert.GetString(searchLookUpProjectNo.EditValue);

                if (projectNoStr == "")
                {
                    searchLookUpRSTaskNo.Properties.DataSource = null;
                }
                else
                {
                    DataTable taskTypeTable = planTaskDAO.QueryProjectTaskType(projectNoStr);
                    searchLookUpRSTaskNo.Properties.DataSource = taskTypeTable;
                }

                //DataTable tempTable = new DataTable();
                //taskTypeDAO.QueryProjectUser(tempTable, projectNoStr);
                //searchLookUpRSProjectUser.Properties.DataSource = tempTable;

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择项目号查询所有信息错误。", ex);
            }
        }

        /// <summary>
        /// 查询任务进度信息
        /// </summary>
        private void btnQueryTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                string projectNoStr = DataTypeConvert.GetString(searchLookUpProjectNo.EditValue) != "全部" ? DataTypeConvert.GetString(searchLookUpProjectNo.EditValue) : "";

                string taskNoStr = searchLookUpRSTaskNo.Text.Trim() == "" ? "" : DataTypeConvert.GetString(searchLookUpRSTaskNo.EditValue);
                string projectUserStr = DataTypeConvert.GetString(searchLookUpRSProjectUser.EditValue) != "0" ? DataTypeConvert.GetString(searchLookUpRSProjectUser.EditValue) : "";
                string commonStr = textCommon.Text.Trim();

                dSRegisterSchedule.Tables[0].Rows.Clear();
                taskSRDAO.QueryProjectPlanTask(dSRegisterSchedule.Tables[0], projectNoStr, taskNoStr, projectUserStr, commonStr, checkNoComplete.Checked, false);

                SetButtonAndColumnState(false);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询任务进度信息错误。", ex);
            }
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (gridViewRegisterSchedule.DataRowCount == 0)
                {
                    MessageHandler.ShowMessageBox("请先查询要修改的任务进度信息。");
                    return;
                }

                if (btnSave.Text != "保存")
                {
                    SetButtonAndColumnState(true);
                    FocusedHeadView("ActualStartDate");
                }
                else
                {                    
                    for (int i = 0; i < TableRegisterSchedule.Rows.Count; i++)
                    {
                        if (gridViewRegisterSchedule.GetDataRow(i).RowState == DataRowState.Modified)
                        {                            
                            string actualStartDate = DataTypeConvert.GetString(gridViewRegisterSchedule.GetRowCellValue(i, "ActualStartDate"));
                            string actualEndDate = DataTypeConvert.GetString(gridViewRegisterSchedule.GetRowCellValue(i, "ActualEndDate"));
                            int schedule = DataTypeConvert.GetInt(gridViewRegisterSchedule.GetRowCellValue(i, "Schedule"));

                            if (actualStartDate == "" && actualEndDate != "")
                            {
                                MessageHandler.ShowMessageBox("设定了实际结束日期，必须设定实际开始日期。");
                                gridViewRegisterSchedule.FocusedRowHandle = i;
                                FocusedHeadView("ActualStartDate");
                                return;
                            }
                            if (actualStartDate == "" && schedule > 0)
                            {
                                MessageHandler.ShowMessageBox("完成进度已经开始，必须设定实际开始日期。");
                                gridViewRegisterSchedule.FocusedRowHandle = i;
                                FocusedHeadView("ActualStartDate");
                                return;
                            }
                            if (actualStartDate != "" && actualEndDate != "")
                            {
                                if (DataTypeConvert.GetDateTime(gridViewRegisterSchedule.GetRowCellValue(i, "ActualStartDate")) > DataTypeConvert.GetDateTime(gridViewRegisterSchedule.GetRowCellValue(i, "ActualEndDate")))
                                {
                                    MessageHandler.ShowMessageBox("实际开始日期不能大于实际结束日期。");
                                    gridViewRegisterSchedule.FocusedRowHandle = i;
                                    FocusedHeadView("ActualEndDate");
                                    return;
                                }
                                if (DataTypeConvert.GetString(gridViewRegisterSchedule.GetRowCellValue(i, "Schedule")) == "")
                                {
                                    MessageHandler.ShowMessageBox("请输入完成进度。");
                                    gridViewRegisterSchedule.FocusedRowHandle = i;
                                    FocusedHeadView("Schedule");
                                    return;
                                }
                            }                            
                        }
                    }

                    taskSRDAO.SaveTaskScheduleRegister(TableRegisterSchedule);

                    SetButtonAndColumnState(false);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--保存按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 设定表列状态
        /// </summary>
        private void SetButtonAndColumnState(bool state)
        {
            if (state)
            {
                btnSave.Text = "保存";

                colActualStartDate.AppearanceCell.ForeColor = Color.Red;
                colActualStartDate.AppearanceHeader.ForeColor = Color.Red;
                colActualEndDate.AppearanceCell.ForeColor = Color.Red;
                colActualEndDate.AppearanceHeader.ForeColor = Color.Red;
                colActualTotalDays.AppearanceCell.ForeColor = Color.Red;
                colActualTotalDays.AppearanceHeader.ForeColor = Color.Red;
                colSchedule.AppearanceCell.ForeColor = Color.Red;
                colSchedule.AppearanceHeader.ForeColor = Color.Red;
            }
            else
            {
                btnSave.Text = "修改";

                colActualStartDate.AppearanceCell.ForeColor = colModifierint.AppearanceCell.ForeColor;
                colActualStartDate.AppearanceHeader.ForeColor = colModifierint.AppearanceCell.ForeColor;
                colActualEndDate.AppearanceCell.ForeColor = colModifierint.AppearanceCell.ForeColor;
                colActualEndDate.AppearanceHeader.ForeColor = colModifierint.AppearanceCell.ForeColor;
                colActualTotalDays.AppearanceCell.ForeColor = colModifierint.AppearanceCell.ForeColor;
                colActualTotalDays.AppearanceHeader.ForeColor = colModifierint.AppearanceCell.ForeColor;
                colSchedule.AppearanceCell.ForeColor = colModifierint.AppearanceCell.ForeColor;
                colSchedule.AppearanceHeader.ForeColor = colModifierint.AppearanceCell.ForeColor;
            }
            gridViewRegisterSchedule.OptionsBehavior.Editable = state;
        }

        /// <summary>
        /// 聚焦主表当前行的列
        /// </summary>
        private void FocusedHeadView(string colName)
        {
            gridControlRegisterSchedule.Focus();
            ColumnView headView = (ColumnView)gridControlRegisterSchedule.FocusedView;
            headView.FocusedColumn = headView.Columns[colName];
            gridViewRegisterSchedule.FocusedRowHandle = headView.FocusedRowHandle;
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewRegisterSchedule_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewRegisterSchedule_KeyDown(object sender, KeyEventArgs e)
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
        /// 子表单元格值变化进行的操作
        /// </summary>
        private void gridViewRegisterSchedule_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (isLockControl)
                    return;

                isLockControl = true;

                int userIdInt = DataTypeConvert.GetInt(gridViewRegisterSchedule.GetDataRow(e.RowHandle)["UserId"]);
                if (userIdInt != SystemInfo.user.AutoId)
                {
                    if (DataTypeConvert.GetInt(gridViewRegisterSchedule.GetDataRow(e.RowHandle)["IsReplace"]) != 1)
                    {
                        MessageHandler.ShowMessageBox("计划任务的进度必须本人更新，不可以其他操作员替代更新。");
                        gridViewRegisterSchedule.SetRowCellValue(e.RowHandle, e.Column, gridViewRegisterSchedule.GetDataRow(e.RowHandle)[e.Column.FieldName, DataRowVersion.Original]);
                        isLockControl = false;
                        return;
                    }
                }

                string actualStartDate = "";
                string actualEndDate = "";
                switch (e.Column.FieldName)
                {
                    case "ActualStartDate":
                    case "ActualEndDate":
                        actualStartDate = DataTypeConvert.GetString(gridViewRegisterSchedule.GetRowCellValue(e.RowHandle, "ActualStartDate"));
                        actualEndDate = DataTypeConvert.GetString(gridViewRegisterSchedule.GetRowCellValue(e.RowHandle, "ActualEndDate"));

                        if (actualStartDate == "" && actualEndDate != "")
                        {
                            MessageHandler.ShowMessageBox("设定了实际结束日期，必须设定实际开始日期。");
                            gridViewRegisterSchedule.FocusedRowHandle = e.RowHandle;
                            FocusedHeadView("ActualStartDate");
                            break;
                        }
                        if (actualStartDate == "" && actualEndDate == "")
                        {
                            gridViewRegisterSchedule.SetRowCellValue(e.RowHandle, "ActualTotalDays", null);
                        }
                        if (actualStartDate != "" && actualEndDate != "")
                        {
                            DateTime actualStartDateDate = DataTypeConvert.GetDateTime(gridViewRegisterSchedule.GetRowCellValue(e.RowHandle, "ActualStartDate"));
                            DateTime actualEndDateDate = DataTypeConvert.GetDateTime(gridViewRegisterSchedule.GetRowCellValue(e.RowHandle, "ActualEndDate"));
                            if (actualStartDateDate > actualEndDateDate)
                            {
                                MessageHandler.ShowMessageBox("实际开始日期不能大于实际结束日期。");
                                gridViewRegisterSchedule.SetRowCellValue(e.RowHandle, "ActualEndDate", actualStartDateDate);
                                break;
                            }

                            gridViewRegisterSchedule.SetRowCellValue(e.RowHandle, "ActualTotalDays", (actualEndDateDate.Date - actualStartDateDate.Date).Days + 1);
                        }
                        break;
                    case "ActualTotalDays":
                        actualStartDate = DataTypeConvert.GetString(gridViewRegisterSchedule.GetRowCellValue(e.RowHandle, "ActualStartDate"));
                        int actualTotalDays = DataTypeConvert.GetInt(gridViewRegisterSchedule.GetRowCellValue(e.RowHandle, "ActualTotalDays"));
                        if (actualStartDate != "" && actualTotalDays > 0)
                        {
                            gridViewRegisterSchedule.SetRowCellValue(e.RowHandle, "ActualEndDate", DataTypeConvert.GetDateTime(gridViewRegisterSchedule.GetRowCellValue(e.RowHandle, "ActualStartDate")).Date.AddDays(actualTotalDays - 1));
                        }
                        break;
                }
                isLockControl = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--子表单元格值变化进行的操作错误。", ex);
            }
        }

        /// <summary>
        /// 设定列表显示信息
        /// </summary>
        private void gridViewRegisterSchedule_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "PlanTaskStatus")
            {
                e.DisplayText = CommonHandler.Get_PlanTaskStatus_Desc(e.Value.ToString());
            }
        }

    }
}
