using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.PMDAO
{
    class FrmProjectUserAndTaskTypeDAO
    {
        /// <summary>
        /// 查询项目人员信息
        /// </summary>
        public void QueryProjectUser(DataTable queryDataTable, string projectNoStr)
        {
            string sqlStr = string.Format("select BS_ProjectUser.*, BS_UserInfo.EmpName, BS_UserInfo.DepartmentNo, DepartmentName from BS_ProjectUser left join BS_UserInfo on BS_ProjectUser.UserId = BS_UserInfo.AutoId left join BS_Department on BS_UserInfo.DepartmentNo = BS_Department.DepartmentNo where BS_ProjectUser.ProjectNo = '{0}' Order by BS_ProjectUser.AutoId", projectNoStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 保存项目人员信息
        /// </summary>
        public void SaveProjectUser(string projectNoStr, List<int> autoIdList)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("select * from BS_ProjectUser where ProjectNo = '{0}'", projectNoStr);
                        DataTable tmpTable = new DataTable();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(tmpTable);

                        for (int i = tmpTable.Rows.Count - 1; i >= 0; i--)
                        {
                            int tmpUserId = DataTypeConvert.GetInt(tmpTable.Rows[i]["UserId"]);
                            if (autoIdList.Contains(tmpUserId))
                            {
                                autoIdList.Remove(tmpUserId);
                            }
                            else
                            {
                                tmpTable.Rows[i].Delete();
                            }
                        }

                        BaseSQL.UpdateDataTable(adpt, tmpTable);

                        foreach (int autoId in autoIdList)
                        {
                            cmd.CommandText = string.Format("Insert Into BS_ProjectUser (ProjectNo, UserId, IsPlanEdit, IsReplace) values ('{0}', {1}, 1, 1)", projectNoStr, autoId);
                            cmd.ExecuteNonQuery();
                        }

                        //cmd.CommandText = string.Format("Delete from BS_ProjectUser where ProjectNo = '{0}'", projectNoStr);
                        //cmd.ExecuteNonQuery();

                        //for (int i = 0; i < autoIdList.Count; i++)
                        //{
                        //    cmd.CommandText = string.Format("Insert Into BS_ProjectUser (ProjectNo, UserId, IsPlanEdit, IsReplace) values ('{0}', {1}, 1, 1)", projectNoStr, autoIdList[i]);
                        //    cmd.ExecuteNonQuery();
                        //}

                        LogHandler.RecordLog(cmd, string.Format("更新项目[{0}]的人员信息。", projectNoStr));

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
        /// 更新项目人员信息中的是否可以修改个人计划
        /// </summary>
        public void UpdateProjectUser_IsPlanEdit(string projectNoStr, string autoIdListStr, int isPlanEditInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("update BS_ProjectUser set IsPlanEdit = {2} where ProjectNo = '{0}' and AutoId in ({1})", projectNoStr, autoIdListStr, isPlanEditInt);
                        cmd.ExecuteNonQuery();

                        LogHandler.RecordLog(cmd, string.Format("更新项目[{0}]的人员[{1}]信息：[是否可以修改个人计划]的值为[{2}]。", projectNoStr, autoIdListStr, isPlanEditInt));

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
        /// 更新项目人员信息中的是否可以代替更新计划进度
        /// </summary>
        public void UpdateProjectUser_IsReplace(string projectNoStr, string autoIdListStr, int isReplaceInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("update BS_ProjectUser set IsReplace = {2} where ProjectNo = '{0}' and AutoId in ({1})", projectNoStr, autoIdListStr, isReplaceInt);
                        cmd.ExecuteNonQuery();

                        LogHandler.RecordLog(cmd, string.Format("更新项目[{0}]的人员[{1}]信息：[是否可以代替更新计划进度]的值为[{2}]。", projectNoStr, autoIdListStr, isReplaceInt));

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
    }
}
