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
    public partial class FrmRegisterSchedule : DockContent
    {
        FrmProjectPlanTaskDAO planTaskDAO = new FrmProjectPlanTaskDAO();
        FrmProjectUserAndTaskTypeDAO taskTypeDAO = new FrmProjectUserAndTaskTypeDAO();

        /// <summary>
        /// 项目计划任务的AutoId
        /// </summary>
        public static int autoIdInt = 0;

        public FrmRegisterSchedule()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmRegisterSchedule_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable planTaskTable = planTaskDAO.QueryProjectPlanTask(autoIdInt);
                if (planTaskTable.Rows.Count == 0)
                {
                    MessageHandler.ShowMessageBox("未查询到选择项目计划任务信息，请重新操作。");
                    this.Close();
                    return;
                }

                DataTable tempTable = new DataTable();
                taskTypeDAO.QueryProjectUser(tempTable, DataTypeConvert.GetString(planTaskTable.Rows[0]["ProjectNo"]));
                searchLookUpProjectUser.Properties.DataSource = tempTable;

                textPlanTaskText.Text = DataTypeConvert.GetString(planTaskTable.Rows[0]["PlanTaskText"]);
                searchLookUpProjectUser.EditValue = planTaskTable.Rows[0]["ProjectUser"];

                if (DataTypeConvert.GetString(planTaskTable.Rows[0]["ActualStartDate"]) != "")
                    dateActualStartDate.EditValue = DataTypeConvert.GetDateTime(planTaskTable.Rows[0]["ActualStartDate"]);
                if (DataTypeConvert.GetString(planTaskTable.Rows[0]["ActualEndDate"]) != "")
                    dateActualEndDate.EditValue = DataTypeConvert.GetDateTime(planTaskTable.Rows[0]["ActualEndDate"]);

                spinSchedule.Value = DataTypeConvert.GetDecimal(planTaskTable.Rows[0]["Schedule"]);

                textPlanTaskStatus.Text = CommonHandler.Get_PlanTaskStatus_Desc(DataTypeConvert.GetString(planTaskTable.Rows[0]["PlanTaskStatus"]));

                textModifierint.Text = SystemInfo.user.EmpName;

                dateActualStartDate.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确认按钮事件
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateActualStartDate.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("请输入实际开始日期。");
                    dateActualStartDate.Focus();
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确认按钮事件错误。", ex);
            }
        }
    }
}
