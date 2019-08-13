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

        ///// <summary>
        ///// 查询项目计划任务表
        ///// </summary>
        //public DataTable QueryProjectPlanTask(int autoIdInt)
        //{
        //    string sqlStr = string.Format("select * from PM_ProjectPlanTask where AutoId = {0}", autoIdInt);
        //    return BaseSQL.GetTableBySql(sqlStr);
        //}

        ///// <summary>
        ///// 查询项目计划任务表
        ///// </summary>
        //public void QueryProjectPlanTask(DataTable queryDataTable, string projectNoStr, string taskNoStr, string ProjectUserStr, string commonStr, bool nullTable)
        //{
        //    string sqlStr = " 1=1";
        //    if (projectNoStr != "")
        //    {
        //        sqlStr += string.Format(" and task.ProjectNo='{0}'", projectNoStr);
        //    }
        //    if (taskNoStr != "")
        //    {
        //        sqlStr += string.Format(" and task.TaskNo={0}", taskNoStr);
        //    }
        //    if (ProjectUserStr != "")
        //    {
        //        sqlStr += string.Format(" and task.ProjectUser={0}", ProjectUserStr);
        //    }
        //    if (commonStr != "")
        //    {
        //        sqlStr += string.Format(" and (task.ProjectNo like '%{0}%' or task.PlanTaskText like '%{0}%' or task.Remark like '%{0}%')", commonStr);
        //    }
        //    if (nullTable)
        //    {
        //        sqlStr += " and 1=2";
        //    }
        //    sqlStr = string.Format("select task.*, BS_ProjectUser.UserId from PM_ProjectPlanTask as task left join BS_ProjectUser on task.ProjectUser = BS_ProjectUser.AutoId where {0} order by AutoId", sqlStr);
        //    BaseSQL.Query(sqlStr, queryDataTable);
        //}

        ///// <summary>
        ///// 更新项目计划任务的进度信息
        ///// </summary>
        //public void UpdateProjectPlanTask_ActualInfo(int autoIdInt, string actualStartDateStr, string actualEndDateStr, int actualTotalDaysInt,double scheduleDouble)
        //{
        //    int planTaskStatus = 2;
        //    if (actualStartDateStr == "")
        //        planTaskStatus = 1;
        //    if (actualStartDateStr != "" && actualEndDateStr != "" && scheduleDouble == 1)
        //        planTaskStatus = 3;

        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                cmd.CommandText = string.Format("Update PM_ProjectPlanTask set ActualStartDate = '{1}', ActualEndDate = '{2}', ActualTotalDays = {3}, Schedule = {4}, Modifierint = {5}, ModifyTime = '{6}' where AutoId = {0}");
        //                cmd.ExecuteNonQuery();


        //                ////保存日志到日志表中
        //                //DataRow[] headRows = imHeadTable.Select("select=1");
        //                //for (int i = 0; i < headRows.Length; i++)
        //                //{
        //                //    string logStr = LogHandler.RecordLog_DeleteRow(cmd, "库存移动单", headRows[i], "InventoryMoveNo");
        //                //}

        //                trans.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}
    }
}
