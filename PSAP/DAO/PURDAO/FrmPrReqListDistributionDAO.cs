using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.PURDAO
{
    class FrmPrReqListDistributionDAO
    {
        /// <summary>
        /// 查询采购任务分配信息
        /// </summary>
        public void QueryPrReqListDistribution(DataTable queryDataTable, string beginRequirementDateStr, string endRequirementDateStr, string projectNoStr, int codeIdInt, int arrangementIdInt, string commonStr, bool containDistribution)
        {
            string sqlStr = " ReqState in (2) and List.AutoId not in (select IsNull(PrListAutoId, 0) from PUR_OrderList)";
            if (beginRequirementDateStr != "")
            {
                sqlStr += string.Format(" and RequirementDate between '{0}' and '{1}'", beginRequirementDateStr, endRequirementDateStr);
            }
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and ProjectNo='{0}'", projectNoStr);
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and List.CodeId={0}", codeIdInt);
            }
            if (arrangementIdInt != 0)
            {
                sqlStr += string.Format(" and IsNull(List.Arrangement, 0)={0}", arrangementIdInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (List.PrReqNo like '%{0}%' or StnNo like '%{0}%' or PrReqListRemark like '%{0}%' or ProjectNo like '%{0}%' or List.CodeFileName like '%{0}%' or CodeName like '%{0}%')", commonStr);
            }
            if (!containDistribution)
            {
                sqlStr += string.Format(" and IsNull(ArrangementFlat, 0) = 0");
            }
            sqlStr = string.Format("select List.*, ProjectNo, StnNo from PUR_PrReqList as List left join PUR_PrReqHead as Head on List.PrReqNo = Head.PrReqNo left join SW_PartsCode as Parts on List.CodeId = Parts.AutoId where {0} order by List.AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询请购单指定某个操作员为执行人的明细数量
        /// </summary>
        public int QueryPrReqList_ArrangementCount(int arrangementIdInt)
        {
            string sqlStr = string.Format("select COUNT(*) from PUR_PrReqList where Arrangement = {0} and AutoId not in (select IsNull(PrListAutoId, 0) from PUR_OrderList)", arrangementIdInt);
            return DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
        }

        /// <summary>
        /// 设定执行人
        /// </summary>
        public void SetArrangement(List<int> autoIdList, int arrangementId)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        string sql = "";
                        foreach (int autoId in autoIdList)
                        {
                            sql += string.Format("{0},", autoId);
                        }

                        DateTime nowTime = BaseSQL.GetServerDateTime();
                        cmd.CommandText = string.Format("Update PUR_PrReqList set Arrangement = {1}, Operator = {2}, ArrangementTime = '{3}', ArrangementFlat = 1 where AutoId in ({0})", sql.Substring(0,sql.Length -1), arrangementId, SystemInfo.user.AutoId, nowTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.ExecuteNonQuery();
                        
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
        /// 清空执行人
        /// </summary>
        public void ClearArrangement(List<int> autoIdList)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        string sql = "";
                        foreach (int autoId in autoIdList)
                        {
                            sql += string.Format("{0},", autoId);
                        }

                        cmd.CommandText = string.Format("Update PUR_PrReqList set Arrangement = null, Operator = null, ArrangementTime = null, ArrangementFlat = 0 where AutoId in({0})", sql.Substring(0, sql.Length - 1));
                        cmd.ExecuteNonQuery();

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
