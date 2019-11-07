using PSAP.DAO.BSDAO;
using PSAP.DAO.WORKFLOWDAO;
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
        WorkFlowsHandleDAO wfHandleDAO = new WorkFlowsHandleDAO();

        /// <summary>
        /// 查询采购任务分配信息
        /// </summary>
        public void QueryPrReqListDistribution(DataTable queryDataTable, string beginRequirementDateStr, string endRequirementDateStr, string projectNoStr, int codeIdInt, int arrangementIdInt, string commonStr, bool containDistribution, bool IsPrToPo)
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
            if(!IsPrToPo)
            {
                sqlStr += " and List.AutoId not in (select PRListId from PUR_PRPO)";
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
        public bool SetArrangement(List<int> autoIdList, int arrangementId)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        string sqlStr = "";
                        foreach (int autoId in autoIdList)
                        {
                            sqlStr += string.Format("{0},", autoId);
                        }
                        sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);

                        if(CheckPrIsPO(cmd,sqlStr))
                        {
                            return false;
                        }

                        DateTime nowTime = BaseSQL.GetServerDateTime();
                        cmd.CommandText = string.Format("Update PUR_PrReqList set Arrangement = {1}, Operator = {2}, ArrangementTime = '{3}', ArrangementFlat = 1 where AutoId in ({0})", sqlStr, arrangementId, SystemInfo.user.AutoId, nowTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.ExecuteNonQuery();

                        //cmd.CommandText = string.Format("select PrReqNo from PUR_PrReqList where AutoId in ({0}) group by PrReqNo", sql.Substring(0, sql.Length - 1));
                        cmd.CommandText = string.Format("select PrReqNo from PUR_PrReqList where IsNull(ArrangementFlat, 0) = 1 and PrReqNo in (select PrReqNo from PUR_PrReqList where AutoId in ({0})) group by PrReqNo", sqlStr);
                        DataTable prTable = BaseSQL.GetTableBySql(cmd);
                        Dictionary<string, int> prReqNoDictionary = new Dictionary<string, int>();
                        foreach (DataRow prRow in prTable.Rows)
                        {
                            prReqNoDictionary.Add(DataTypeConvert.GetString(prRow["PrReqNo"]), (int)CommonHandler.OrderState.已审批);
                        }

                        if (!wfHandleDAO.MultiOrderWorkFlowsHandle(cmd, WorkFlowsHandleDAO.OrderType.请购单, WorkFlowsHandleDAO.LineType.任务分配, ref prReqNoDictionary))
                        {
                            return false;
                        }

                        //cmd.CommandText = string.Format("Update BS_WorkFlowsDataCurrentNode set NextHandleEnd = 1 where DataNo in (select PrReqNo from PUR_PrReqList where IsNull(ArrangementFlat, 0) = 1 and PrReqNo in (select PrReqNo from PUR_PrReqList where AutoId in ({0})))", sql.Substring(0, sql.Length - 1));
                        //cmd.ExecuteNonQuery();

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

        /// <summary>
        /// 检查请购单明细是否已经生成采购订单
        /// </summary>
        private bool CheckPrIsPO(SqlCommand cmd, string autoIdListStr)
        {
            cmd.CommandText = string.Format("select PrReqNo, CodeFileName from PUR_PrReqList join PUR_PRPO on PUR_PrReqList.AutoId = PUR_PRPO.PRListId where PUR_PrReqList.AutoId in ({0}) group by PrReqNo, CodeFileName", autoIdListStr);
            DataTable orderPrTable = BaseSQL.GetTableBySql(cmd);
            if (orderPrTable.Rows.Count > 0)
            {
                cmd.Transaction.Rollback();
                MessageHandler.ShowMessageBox(string.Format("请购单[{0}]中的[{1}]已经生成采购订单，不可以再进行操作。", orderPrTable.Rows[0]["PrReqNo"], orderPrTable.Rows[0]["CodeFileName"]));
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 清空执行人
        /// </summary>
        public bool ClearArrangement(List<int> autoIdList)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        string sqlStr = "";
                        foreach (int autoId in autoIdList)
                        {
                            sqlStr += string.Format("{0},", autoId);
                        }
                        sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);

                        if (CheckPrIsPO(cmd, sqlStr))
                        {
                            return false;
                        }

                        cmd.CommandText = string.Format("Update PUR_PrReqList set Arrangement = null, Operator = null, ArrangementTime = null, ArrangementFlat = 0 where AutoId in({0})", sqlStr);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("select PrReqNo from PUR_PrReqList where IsNull(ArrangementFlat, 0) = 0 and PrReqNo in (select PrReqNo from PUR_PrReqList where AutoId in ({0})) group by PrReqNo", sqlStr);
                        DataTable prTable = BaseSQL.GetTableBySql(cmd);
                        Dictionary<string, int> prReqNoDictionary = new Dictionary<string, int>();
                        foreach (DataRow prRow in prTable.Rows)
                        {
                            prReqNoDictionary.Add(DataTypeConvert.GetString(prRow["PrReqNo"]), (int)CommonHandler.OrderState.已审批);
                        }

                        if (!wfHandleDAO.MultiOrderWorkFlowsHandle(cmd, WorkFlowsHandleDAO.OrderType.请购单, WorkFlowsHandleDAO.LineType.取消分配, ref prReqNoDictionary))
                        {
                            return false;
                        }

                        //cmd.CommandText = string.Format("Update BS_WorkFlowsDataCurrentNode set NextHandleEnd = 0 where DataNo in (select PrReqNo from PUR_PrReqList where AutoId in ({0}))", sql.Substring(0, sql.Length - 1));
                        //cmd.ExecuteNonQuery();

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
