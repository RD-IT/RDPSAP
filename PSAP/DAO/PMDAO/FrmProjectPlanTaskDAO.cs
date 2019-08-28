using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.PMDAO
{
    class FrmProjectPlanTaskDAO
    {
        /// <summary>
        /// 查询项目任务类别信息
        /// </summary>
        public DataTable QueryProjectTaskType(string projectNoStr)
        {
            string sqlStr = string.Format("select AutoId, TaskNo, TaskText from PM_ProjectTaskType where ProjectNo = '{0}' order by AutoId", projectNoStr);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询项目人员是否可以修改计划
        /// </summary>
        public int QueryProjectUser_SingleValue(string columnNameStr, int autoIdInt)
        {
            string sqlStr = string.Format("select {1} from BS_ProjectUser where AutoId = {0}", autoIdInt,columnNameStr);
            return DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
        }

        /// <summary>
        /// 查询项目计划任务表的SQL
        /// </summary>
        public string QueryProjectPlanTask_SQL(string projectNoStr)
        {
            return string.Format("select PM_ProjectPlanTask.*, BS_ProjectUser.UserId from PM_ProjectPlanTask left join BS_ProjectUser on PM_ProjectPlanTask.ProjectUser = BS_ProjectUser.AutoId where PM_ProjectPlanTask.ProjectNo = '{0}' order by AutoId", projectNoStr);
        }

        /// <summary>
        /// 更新项目计划任务表的计划开始结束日期
        /// </summary>
        public void UpdateProjectPlanTask_PlanDate(int autoIdInt, DateTime planStartDate, DateTime planEndDate)
        {
            int planTotalDays = (planEndDate.Date - planStartDate).Days + 1;

            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        //如果不更新登记修改人用下面SQL
                        //string sqlStr = string.Format("Update PM_ProjectPlanTask set PlanStartDate = '{1}', PlanEndDate = '{2}', PlanTotalDays = {3} where AutoId = {0}", autoIdInt, planStartDate.Date.ToString("yyyy-MM-dd"), planEndDate.Date.ToString("yyyy-MM-dd"), planTotalDays);

                        cmd.CommandText = string.Format("Update PM_ProjectPlanTask set PlanStartDate = '{1}', PlanEndDate = '{2}', PlanTotalDays = {3}, Creator = {4} where AutoId = {0}", autoIdInt, planStartDate.Date.ToString("yyyy-MM-dd"), planEndDate.Date.ToString("yyyy-MM-dd"), planTotalDays, SystemInfo.user.AutoId);
                        cmd.ExecuteNonQuery();

                        string logStr = string.Format("更新项目计划任务信息：[编号AutoId]的值为[{0}]，[计划开始日期]的值为[{1}]，[计划结束日期]的值为[{2}]，[计划工期]的值为[{3}]", autoIdInt, planStartDate.Date.ToString("yyyy-MM-dd"), planEndDate.Date.ToString("yyyy-MM-dd"), planTotalDays);
                        LogHandler.RecordLog(cmd, logStr);

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 查询项目计划任务表的状态
        /// </summary>
        public int QueryProjectPlanTask_PlanTaskStatus(int autoIdInt)
        {
            string sqlStr = string.Format("Select PlanTaskStatus from PM_ProjectPlanTask where AutoId = {0}", autoIdInt);
            return DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
        }

        /// <summary>
        /// 查询甘特图的日程条信息
        /// </summary>
        public void QueryGanttAppointment(DataTable queryDataTable, string projectNoStr)
        {
            string sqlStr = string.Format("select AutoId, PlanTaskText, PlanStartDate, DATEADD(day, 1, PlanEndDate) as PlanEndDate, Cast(1 as bit) as AllDay from PM_ProjectPlanTask where ProjectNo = '{0}' order by AutoId", projectNoStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }
        
    }
}
