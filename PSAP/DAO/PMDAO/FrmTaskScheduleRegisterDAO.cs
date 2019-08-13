using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.PMDAO
{
    class FrmTaskScheduleRegisterDAO
    {
        /// <summary>
        /// 查询项目计划任务表
        /// </summary>
        public void QueryProjectPlanTask(DataTable queryDataTable, string projectNoStr, string taskNoStr, string ProjectUserStr, string commonStr, bool noCompleteBool, bool nullTable)
        {
            string sqlStr = " 1=1";
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and task.ProjectNo='{0}'", projectNoStr);
            }
            if (taskNoStr != "")
            {
                sqlStr += string.Format(" and task.TaskNo={0}", taskNoStr);
            }
            if (ProjectUserStr != "")
            {
                sqlStr += string.Format(" and BS_ProjectUser.UserId={0}", ProjectUserStr);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (task.ProjectNo like '%{0}%' or task.PlanTaskText like '%{0}%' or task.Remark like '%{0}%')", commonStr);
            }
            if (noCompleteBool)
            {
                sqlStr += string.Format(" and PlanTaskStatus!=3");
            }
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select task.*, BS_ProjectUser.UserId, PM_ProjectTaskType.TaskText, BS_ProjectUser.IsReplace from PM_ProjectPlanTask as task left join BS_ProjectUser on task.ProjectUser = BS_ProjectUser.AutoId left join PM_ProjectTaskType on task.TaskNo = PM_ProjectTaskType.AutoId where {0} order by AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 保存任务计划登记信息
        /// </summary>
        public bool SaveTaskScheduleRegister(DataTable updateTable)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        DateTime nowTime = BaseSQL.GetServerDateTime();
                        for (int i = 0; i < updateTable.Rows.Count; i++)
                        {
                            DataRow dr = updateTable.Rows[i];
                            if (dr.RowState == DataRowState.Modified)
                            {
                                dr["Modifierint"] = SystemInfo.user.AutoId;
                                dr["ModifyTime"] = nowTime;

                                string actualStartDate = DataTypeConvert.GetString(dr["ActualStartDate"]);
                                string actualEndDate = DataTypeConvert.GetString(dr["ActualEndDate"]);
                                int schedule = DataTypeConvert.GetInt(dr["Schedule"]);
                                if (actualStartDate == "" && actualEndDate == "")
                                {
                                    dr["ActualTotalDays"] = DBNull.Value;
                                }

                                int planTaskStatus = 2;
                                if (actualStartDate == "")
                                    planTaskStatus = 1;
                                if (actualStartDate != "" && actualEndDate != "" && schedule == 100)
                                    planTaskStatus = 3;

                                dr["PlanTaskStatus"] = planTaskStatus;
                            }
                        }

                        cmd.CommandText = "select * from PM_ProjectPlanTask where 1=2";
                        SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                        DataTable tmpHeadTable = new DataTable();
                        adapterHead.Fill(tmpHeadTable);
                        BaseSQL.UpdateDataTable(adapterHead, updateTable);


                        ////保存日志到日志表中
                        //DataRow[] headRows = imHeadTable.Select("select=1");
                        //for (int i = 0; i < headRows.Length; i++)
                        //{
                        //    string logStr = LogHandler.RecordLog_DeleteRow(cmd, "库存移动单", headRows[i], "InventoryMoveNo");
                        //}

                        trans.Commit();
                        return true;
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
    }
}
