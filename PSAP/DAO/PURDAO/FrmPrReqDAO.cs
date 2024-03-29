﻿using PSAP.DAO.BSDAO;
using PSAP.DAO.WORKFLOWDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.PURDAO
{
    class FrmPrReqDAO
    {
        WorkFlowsHandleDAO wfHandleDAO = new WorkFlowsHandleDAO();

        PSAP.VIEW.BSVIEW.FrmLanguagePURDAO f = new VIEW.BSVIEW.FrmLanguagePURDAO();
        public FrmPrReqDAO()
        {
            PSAP.BLL.BSBLL.BSBLL.language(f);
        }

        #region 部门只能设定最后一级，不用此方法的递归了，暂时注释

        ///// <summary>
        ///// 得到部门及子部门的编号SQL
        ///// </summary>
        ///// <param name="colName"></param>
        ///// <param name="departmentNo"></param>
        ///// <returns></returns>
        //public string GetDepartmentNoSQL_AllChild(string colName, string departmentNo)
        //{
        //    string sqlStr = string.Format("with temp as ( select b.* from BS_Department b where ParentDepartmentNo = '{0}' union all select a.* from BS_Department a join temp on a.ParentDepartmentNo = temp.DepartmentNo ) select AutoID, DepartmentNo, DepartmentName from temp union all select AutoID, DepartmentNo, DepartmentName from BS_Department where DepartmentNo = '{0}' Order by AutoId", departmentNo);
        //    DataTable depTable = BaseSQL.GetTableBySql(sqlStr);
        //    string resultString = "";
        //    for (int i = 0; i < depTable.Rows.Count; i++)
        //    {
        //        resultString += string.Format(" '{0}',", DataTypeConvert.GetString(depTable.Rows[i]["DepartmentNo"]));
        //    }
        //    return string.Format("{0} in ({1})", colName, resultString.Substring(0, resultString.Length - 1));
        //}

        # endregion

        /// <summary>
        /// 查询请购单表头表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="beginDateStr">开始日期字符串</param>
        /// <param name="endDateStr">结束日期字符串</param>
        /// <param name="reqDepStr">部门编号</param>
        /// <param name="purCategoryStr">采购类型</param>
        /// <param name="reqStateInt">状态</param>
        /// <param name="creatorInt">申请人</param>
        /// <param name="commonStr">通用查询条件</param>
        /// <param name="nullTable">是否查询空表</param>
        public void QueryPrReqHead(DataTable queryDataTable, string beginDateStr, string endDateStr, string reqDepStr, string purCategoryStr, int reqStateInt, int creatorInt, int approverInt, string commonStr, bool nullTable)
        {
            BaseSQL.Query(QueryPrReqHead_SQL(beginDateStr, endDateStr, reqDepStr, purCategoryStr, reqStateInt, creatorInt, approverInt, commonStr, nullTable), queryDataTable);
        }
        /// <summary>
        /// 查询请购单表头表的SQL
        /// </summary>
        public string QueryPrReqHead_SQL(string beginDateStr, string endDateStr, string reqDepStr, string purCategoryStr, int reqStateInt, int creatorInt, int approverInt, string commonStr, bool nullTable)
        {
            string sqlStr = " 1=1";
            if (beginDateStr != "")
            {
                sqlStr += string.Format(" and ReqDate between '{0}' and '{1}'", beginDateStr, endDateStr);
            }
            if (reqDepStr != "")
            {
                sqlStr += string.Format(" and ReqDep='{0}'", reqDepStr);
                //sqlStr += string.Format(" and {0}", GetDepartmentNoSQL_AllChild("ReqDep", reqDepStr));
            }
            if (purCategoryStr != "")
            {
                sqlStr += string.Format(" and PurCategory='{0}'", purCategoryStr);
            }
            if (reqStateInt != 0)
            {
                sqlStr += string.Format(" and ReqState={0}", reqStateInt);
            }
            if (creatorInt != 0)
            {
                sqlStr += string.Format(" and Creator={0}", creatorInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (PrReqNo like '%{0}%' or ProjectNo like '%{0}%' or StnNo like '%{0}%' or PrReqRemark like '%{0}%')", commonStr);
            }
            if (approverInt >= 0)
            {
                //if (approverInt == 0)
                //    sqlStr += string.Format(" and ReqState in (4, 5)");
                //else
                //{
                //    //sqlStr = string.Format("select PUR_PrReqHead.* from PUR_PrReqHead left join PUR_ApprovalType on PUR_PrReqHead.ApprovalType = PUR_ApprovalType.TypeNo where {0} and PUR_PrReqHead.ReqState in (1, 4) and( (PUR_ApprovalType.ApprovalCat = 0 and exists (select * from (select top 1 * from F_PrReqNoApprovalList(PUR_PrReqHead.PrReqNo, PUR_PrReqHead.ApprovalType) Order by AppSequence) as minlist where Approver = {1})) or (PUR_ApprovalType.ApprovalCat = 1 and exists (select * from F_PrReqNoApprovalList(PUR_PrReqHead.PrReqNo, PUR_PrReqHead.ApprovalType) where Approver = {1}))) order by AutoId", sqlStr, approverInt);

                //    sqlStr = string.Format("select Head.* from PUR_PrReqHead as Head left join PUR_ApprovalType on Head.ApprovalType = PUR_ApprovalType.TypeNo where {0} and Head.ReqState in (4, 5) and ((PUR_ApprovalType.ApprovalCat = 0 and exists (select * from(select top 1 * from F_OrderNoApprovalList(Head.PrReqNo, Head.ApprovalType) Order by AppSequence) as minlist where Approver = {1})) or(PUR_ApprovalType.ApprovalCat = 1 and exists(select * from F_OrderNoApprovalList(Head.PrReqNo, Head.ApprovalType) where Approver = {1}))) order by AutoId", sqlStr, approverInt);
                //    return sqlStr;
                //}
                if (approverInt == 0)
                    sqlStr += string.Format(" and ReqState in (4, 5)");
                else
                {
                    //string tableNameStr = "PUR_PrReqHead";
                    //int moduleTypeInt = 2;
                    //string tmpSqlStr = new FrmWorkFlowDataHandleDAO().GetWorkFlowLine_ConditionString(tableNameStr, moduleTypeInt, approverInt);
                    //sqlStr = string.Format("select * from PUR_PrReqHead where {0} {1} order by AutoId", sqlStr, tmpSqlStr);
                    //return sqlStr;
                    
                    string tmpSqlStr = wfHandleDAO.GetWorkFlowsLine_OrderQuerySQL(WorkFlowsHandleDAO.OrderType.请购单, approverInt);
                    if (tmpSqlStr != "")
                        return tmpSqlStr;
                    else
                        sqlStr += string.Format(" and ReqState in (4, 5)");
                }
            }
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select * from PUR_PrReqHead where {0} order by AutoId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 查询请购单明细表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="prReqNoStr">请购单号</param>
        public void QueryPrReqList(DataTable queryDataTable, string prReqNoStr)
        {
            string sqlStr = string.Format(" and PrReqNo='{0}'", prReqNoStr);
            //sqlStr = string.Format("select * from PUR_PrReqList where 1=1 {0} order by AutoId", sqlStr);
            sqlStr = string.Format("select PUR_PrReqList.*, SW_PartsCode.CodeName from PUR_PrReqList left join SW_PartsCode on PUR_PrReqList.CodeId = SW_PartsCode.AutoId where 1=1 {0} order by AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        ///// <summary>
        ///// 根据请购单号删除请购单
        ///// </summary>
        ///// <param name="prReqNoStr">请购单号</param>
        //public bool DeletePrReq(DataRow prReqHeadRow)
        //{
        //    if (!CheckReqState(prReqHeadRow.Table, null, string.Format("'{0}'", DataTypeConvert.GetString(prReqHeadRow["PrReqNo"])), false, true, true, true))
        //        return false;

        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                //保存日志到日志表中
        //                string logStr = LogHandler.RecordLog_DeleteRow(cmd, "请购单", prReqHeadRow, "PrReqNo");

        //                cmd.CommandText = string.Format("Delete from PUR_PrReqList where PrReqNo='{0}'", DataTypeConvert.GetString(prReqHeadRow["PrReqNo"]));
        //                cmd.ExecuteNonQuery();
        //                cmd.CommandText = string.Format("Delete from PUR_PrReqHead where PrReqNo='{0}'", DataTypeConvert.GetString(prReqHeadRow["PrReqNo"]));
        //                cmd.ExecuteNonQuery();

        //                trans.Commit();
        //                return true;
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

        /// <summary>
        /// 根据选择删除多条请购单
        /// </summary>
        public bool DeletePrReq_Multi(DataTable prReqHeadTable)
        {
            string prReqNoListStr = "";
            Dictionary<string, int> prReqNoDictionary = new Dictionary<string, int>();
            for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
                {
                    string prReqNoStr = DataTypeConvert.GetString(prReqHeadTable.Rows[i]["PrReqNo"]);
                    prReqNoListStr += string.Format("'{0}',", prReqNoStr);
                    prReqNoDictionary.Add(prReqNoStr, 0);
                }
            }
            prReqNoListStr = prReqNoListStr.Substring(0, prReqNoListStr.Length - 1);
            if (!CheckReqState(prReqHeadTable, null, prReqNoListStr, false, true, true, true))
                return false;
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (!wfHandleDAO.MultiOrderWorkFlowsHandle(cmd, WorkFlowsHandleDAO.OrderType.请购单, WorkFlowsHandleDAO.LineType.删除, ref prReqNoDictionary))
                        {
                            return false;
                        }

                        //保存日志到日志表中
                        DataRow[] prReqHeadRows = prReqHeadTable.Select("select=1");
                        for (int i = 0; i < prReqHeadRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_DeleteRow(cmd, "请购单", prReqHeadRows[i], "PrReqNo");
                        }

                        cmd.CommandText = string.Format("update PB_DesignBomList set PrReqQty = (Select ISNULL(SUM(RemainQty), 0) from PB_ProductionScheduleBom where PB_DesignBomList.AutoId = PB_ProductionScheduleBom.BomListAutoId and ISNULL(PrReqNo, '') != '' and PrReqNo not in ({0})) where AutoId in (select BomListAutoId from PB_ProductionScheduleBom where PrReqNo in ({0}))", prReqNoListStr);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("Update PB_ProductionScheduleBom set PrReqNo = Null where PrReqNo in ({0})", prReqNoListStr);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("Delete from PUR_PrReqList where PrReqNo in ({0})", prReqNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from PUR_PrReqHead where PrReqNo in ({0})", prReqNoListStr);
                        cmd.ExecuteNonQuery();

                        //new FrmWorkFlowDataHandleDAO().DeleteDataCurrentNode(cmd, prReqNoListStr);                        

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
        /// 判断站号是否包含在项目号中
        /// </summary>
        /// <param name="projectNoStr">项目号</param>
        /// <param name="stnNoStr">站号</param>
        public bool StnNoIsContainProjectNo(string projectNoStr, string stnNoStr)
        {
            string sqlStr = string.Format("select Count(*) from BS_StnList where ProjectNo='{0}' and StnNo='{1}'", projectNoStr, stnNoStr);
            int count = DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
            return count == 0 ? false : true;
        }

        /// <summary>
        /// 保存请购单
        /// </summary>
        /// <param name="prReqHeadRow">请购单表头数据表</param>
        /// <param name="prReqListTable">请购单明细数据表</param>
        public int SavePrReq(DataRow prReqHeadRow, DataTable prReqListTable)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        //if (DataTypeConvert.GetString(prReqHeadRow["PrReqNo"]) == "")//新增
                        if (prReqHeadRow.RowState == DataRowState.Added)//新增
                        {
                            string prReqNo = BaseSQL.GetMaxCodeNo(cmd, "PR");
                            prReqHeadRow["PrReqNo"] = prReqNo;
                            prReqHeadRow["ApplicantIp"] = SystemInfo.HostIpAddress;
                            prReqHeadRow["ApplicantTime"] = BaseSQL.GetServerDateTime();

                            for (int i = 0; i < prReqListTable.Rows.Count; i++)
                            {
                                prReqListTable.Rows[i]["PrReqNo"] = prReqNo;
                            }
                        }
                        else//修改
                        {
                            if (!CheckReqState(prReqHeadRow.Table, prReqListTable, string.Format("'{0}'", DataTypeConvert.GetString(prReqHeadRow["PrReqNo"])), false, true, true, true))
                                return -1;

                            prReqHeadRow["ModifierId"] = SystemInfo.user.AutoId;
                            //prReqHeadRow["Modifier"] = SystemInfo.user.EmpName;
                            prReqHeadRow["ModifierIp"] = SystemInfo.HostIpAddress;
                            prReqHeadRow["ModifierTime"] = BaseSQL.GetServerDateTime();
                        }

                        if (wfHandleDAO.OrderWorkFlowsHandle(cmd, WorkFlowsHandleDAO.OrderType.请购单, WorkFlowsHandleDAO.LineType.保存, DataTypeConvert.GetString(prReqHeadRow["PrReqNo"]), "") < 0)
                            return -1;

                        //保存日志到日志表中
                        string logStr = LogHandler.RecordLog_DataRow(cmd, "请购单", prReqHeadRow, "PrReqNo");

                        //if (SystemInfo.EnableWorkFlowMessage)
                        //{
                        //    if (!new FrmWorkFlowDataHandleDAO().InsertWorkFlowDataHandle(cmd, new List<string>() { DataTypeConvert.GetString(prReqHeadRow["PrReqNo"]) }, "采购流程", "PUR_PrReqHead", 1, DataTypeConvert.GetInt(prReqHeadRow["ReqState"]), "", "", 1, false))
                        //    {
                        //        trans.Rollback();
                        //        MessageHandler.ShowMessageBox("未查询到当前操作所属的流程节点信息，请在系统里登记模块流程信息。");
                        //        return -1;
                        //    }
                        //}

                        cmd.CommandText = "select * from PUR_PrReqHead where 1=2";
                        SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                        DataTable tmpHeadTable = new DataTable();
                        adapterHead.Fill(tmpHeadTable);
                        BaseSQL.UpdateDataTable(adapterHead, prReqHeadRow.Table);

                        cmd.CommandText = "select * from PUR_PrReqList where 1=2";
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable tmpListTable = new DataTable();
                        adapterList.Fill(tmpListTable);
                        BaseSQL.UpdateDataTable(adapterList, prReqListTable);

                        trans.Commit();
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        prReqHeadRow.Table.RejectChanges();
                        prReqListTable.RejectChanges();
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
        /// 提交选中的多条请购单
        /// </summary>
        public bool SubmitPrReq_Multi(DataTable prReqHeadTable)
        {
            string prReqNoListStr = "";
            Dictionary<string, int> prReqNoDictionary = new Dictionary<string, int>();
            DateTime serverTime = BaseSQL.GetServerDateTime();
            for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
                {
                    string prReqNoStr = DataTypeConvert.GetString(prReqHeadTable.Rows[i]["PrReqNo"]);
                    prReqNoListStr += string.Format("'{0}',", prReqNoStr);
                    prReqHeadTable.Rows[i]["ReqState"] = (int)CommonHandler.OrderState.审批中;
                    prReqNoDictionary.Add(prReqNoStr, (int)CommonHandler.OrderState.审批中);
                }
            }

            prReqNoListStr = prReqNoListStr.Substring(0, prReqNoListStr.Length - 1);
            if (!CheckReqState(prReqHeadTable, null, prReqNoListStr, false, true, true, true))
                return false;

            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (!wfHandleDAO.MultiOrderWorkFlowsHandle(cmd, WorkFlowsHandleDAO.OrderType.请购单, WorkFlowsHandleDAO.LineType.提交, ref prReqNoDictionary))
                        {
                            return false;
                        }

                        int stateInt = (int)CommonHandler.OrderState.审批中;
                        if (!prReqNoDictionary.ContainsValue(stateInt))
                        {                            
                            for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
                            {
                                if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
                                {
                                    stateInt = prReqNoDictionary[DataTypeConvert.GetString(prReqHeadTable.Rows[i]["PrReqNo"])];
                                    prReqHeadTable.Rows[i]["ReqState"] = stateInt;
                                }
                            }
                        }

                        cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState={1} where PrReqNo in ({0})", prReqNoListStr, stateInt, SystemInfo.user.EmpName, SystemInfo.HostIpAddress, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        DataRow[] prReqHeadRows = prReqHeadTable.Select("select=1");
                        for (int i = 0; i < prReqHeadRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadRows[i], "PrReqNo", "提交", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));

                            //int stateInt = 4;
                            //if (!new FrmWorkFlowDataHandleDAO().HandleWorkFlowData(cmd, DataTypeConvert.GetString(prReqHeadRows[i]["PrReqNo"]), "采购流程", "PUR_PrReqHead", "PrReqNo", 1, ref stateInt, -1, "", "", 0, false))
                            //{
                            //    trans.Rollback();
                            //    return false;
                            //}
                        }
                        trans.Commit();
                        prReqHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        prReqHeadTable.RejectChanges();
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
        /// 取消提交选中的多条请购单
        /// </summary>
        public bool CancelSubmitPrReq_Multi(DataTable prReqHeadTable)
        {
            string prReqNoListStr = "";
            Dictionary<string, int> prReqNoDictionary = new Dictionary<string, int>();
            DateTime serverTime = BaseSQL.GetServerDateTime();
            for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
                {
                    string prReqNoStr = DataTypeConvert.GetString(prReqHeadTable.Rows[i]["PrReqNo"]);
                    prReqNoListStr += string.Format("'{0}',", prReqNoStr);
                    prReqHeadTable.Rows[i]["ReqState"] = (int)CommonHandler.OrderState.待提交;
                    prReqNoDictionary.Add(prReqNoStr, (int)CommonHandler.OrderState.待提交);
                }
            }

            prReqNoListStr = prReqNoListStr.Substring(0, prReqNoListStr.Length - 1);
            if (!CheckReqState(prReqHeadTable, null, prReqNoListStr, true, true, true, false))
                return false;

            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (!wfHandleDAO.MultiOrderWorkFlowsHandle(cmd, WorkFlowsHandleDAO.OrderType.请购单, WorkFlowsHandleDAO.LineType.取消提交, ref prReqNoDictionary))
                        {
                            return false;
                        }

                        cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState={1} where PrReqNo in ({0})", prReqNoListStr, (int)CommonHandler.OrderState.待提交, SystemInfo.user.EmpName, SystemInfo.HostIpAddress, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        DataRow[] prReqHeadRows = prReqHeadTable.Select("select=1");
                        for (int i = 0; i < prReqHeadRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadRows[i], "PrReqNo", "取消提交", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        }

                        //new FrmWorkFlowDataHandleDAO().HandleDataCurrentNode_IsEnd(cmd, prReqNoListStr, 1, 0);                        

                        trans.Commit();
                        prReqHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        prReqHeadTable.RejectChanges();
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        ///// <summary>
        ///// 审批请购单
        ///// </summary>
        ///// <param name="prReqHeadRow">请购单表头数据行</param>
        //public bool ApprovePrReq(DataRow prReqHeadRow)
        //{
        //    if (!CheckReqState(prReqHeadRow.Table, null, string.Format("'{0}'", DataTypeConvert.GetString(prReqHeadRow["PrReqNo"])), true, true, true, false))
        //        return false;

        //    DateTime serverTime = BaseSQL.GetServerDateTime();
        //    prReqHeadRow["Approver"] = SystemInfo.user.EmpName;
        //    prReqHeadRow["ApproverIp"] = SystemInfo.HostIpAddress;
        //    prReqHeadRow["ApproverTime"] = serverTime;
        //    prReqHeadRow["ReqState"] = 2;

        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);
        //                //cmd.CommandText = "select * from PUR_PrReqHead where 1=2";
        //                //SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
        //                //DataTable tmpHeadTable = new DataTable();
        //                //adapterHead.Fill(tmpHeadTable);
        //                //BaseSQL.UpdateDataTable(adapterHead, prReqHeadRow.Table);
        //                cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState={1}, Approver='{2}', ApproverIp='{3}', ApproverTime='{4}' where PrReqNo='{0}'", DataTypeConvert.GetString(prReqHeadRow["PrReqNo"]), 2, SystemInfo.user.EmpName, SystemInfo.HostIpAddress, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
        //                cmd.ExecuteNonQuery();

        //                //保存日志到日志表中
        //                string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadRow, "PrReqNo", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));

        //                trans.Commit();
        //                prReqHeadRow.AcceptChanges();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                prReqHeadRow.Table.RejectChanges();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 审批选中的多条请购单
        ///// </summary>
        //public bool ApprovePrReq_Multi(DataTable prReqHeadTable)
        //{
        //    string prReqNoListStr = "";
        //    DateTime serverTime = BaseSQL.GetServerDateTime();
        //    for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
        //    {
        //        if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
        //        {
        //            prReqNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(prReqHeadTable.Rows[i]["PrReqNo"]));
        //            prReqHeadTable.Rows[i]["Approver"] = SystemInfo.user.EmpName;
        //            prReqHeadTable.Rows[i]["ApproverIp"] = SystemInfo.HostIpAddress;
        //            prReqHeadTable.Rows[i]["ApproverTime"] = serverTime;
        //            prReqHeadTable.Rows[i]["ReqState"] = 2;
        //        }
        //    }

        //    prReqNoListStr = prReqNoListStr.Substring(0, prReqNoListStr.Length - 1);
        //    if (!CheckReqState(prReqHeadTable, null, prReqNoListStr, true, true, true, false))
        //        return false;

        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);
        //                cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState={1}, Approver='{2}', ApproverIp='{3}', ApproverTime='{4}' where PrReqNo in ({0})", prReqNoListStr, 2, SystemInfo.user.EmpName, SystemInfo.HostIpAddress, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
        //                cmd.ExecuteNonQuery();

        //                //保存日志到日志表中
        //                DataRow[] prReqHeadRows = prReqHeadTable.Select("select=1");
        //                for (int i = 0; i < prReqHeadRows.Length; i++)
        //                {
        //                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadRows[i], "PrReqNo", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
        //                }

        //                trans.Commit();
        //                prReqHeadTable.AcceptChanges();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                prReqHeadTable.RejectChanges();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 取消审批请购单
        ///// </summary>
        ///// <param name="prReqHeadRow">请购单表头数据行</param>
        //public bool CancelApprovePrReq(DataRow prReqHeadRow)
        //{
        //    if (!CheckReqState(prReqHeadRow.Table, null, string.Format("'{0}'", DataTypeConvert.GetString(prReqHeadRow["PrReqNo"])), true, false, true, true))
        //        return false;

        //    prReqHeadRow["Approver"] = "";
        //    prReqHeadRow["ApproverIp"] = "";
        //    prReqHeadRow["ApproverTime"] = "";
        //    prReqHeadRow["ReqState"] = 1;

        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                //检查是否有下级的订单
        //                if (CheckApply(cmd, DataTypeConvert.GetString(prReqHeadRow["PrReqNo"])))
        //                {
        //                    prReqHeadRow.Table.RejectChanges();
        //                    return false;
        //                }

        //                cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState={1}, Approver='{2}', ApproverIp='{3}', ApproverTime='{4}' where PrReqNo='{0}'", DataTypeConvert.GetString(prReqHeadRow["PrReqNo"]), 1, "", "", "");
        //                cmd.ExecuteNonQuery();

        //                //保存日志到日志表中
        //                string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadRow, "PrReqNo", "取消审批", SystemInfo.user.EmpName, BaseSQL.GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss"));

        //                trans.Commit();
        //                prReqHeadRow.AcceptChanges();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                prReqHeadRow.Table.RejectChanges();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 取消审批选中的多条请购单
        ///// </summary>
        //public bool CancelApprovePrReq_Multi(DataTable prReqHeadTable)
        //{
        //    string prReqNoListStr = "";
        //    for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
        //    {
        //        if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
        //        {
        //            prReqNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(prReqHeadTable.Rows[i]["PrReqNo"]));
        //            prReqHeadTable.Rows[i]["Approver"] = "";
        //            prReqHeadTable.Rows[i]["ApproverIp"] = "";
        //            prReqHeadTable.Rows[i]["ApproverTime"] = DBNull.Value;
        //            prReqHeadTable.Rows[i]["ReqState"] = 1;
        //        }
        //    }

        //    prReqNoListStr = prReqNoListStr.Substring(0, prReqNoListStr.Length - 1);
        //    if (!CheckReqState(prReqHeadTable, null, prReqNoListStr, true, false, true, true))
        //        return false;

        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);
        //                cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState={1}, Approver='{2}', ApproverIp='{3}', ApproverTime=null where PrReqNo in ({0})", prReqNoListStr, 1, "", "");
        //                cmd.ExecuteNonQuery();

        //                //保存日志到日志表中
        //                DataRow[] prReqHeadRows = prReqHeadTable.Select("select=1");
        //                for (int i = 0; i < prReqHeadRows.Length; i++)
        //                {
        //                    //检查是否有下级的订单
        //                    if (CheckApply(cmd, DataTypeConvert.GetString(prReqHeadRows[i]["PrReqNo"])))
        //                    {
        //                        prReqHeadTable.RejectChanges();
        //                        return false;
        //                    }

        //                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadRows[i], "PrReqNo", "取消审批", SystemInfo.user.EmpName, BaseSQL.GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss"));
        //                }

        //                trans.Commit();
        //                prReqHeadTable.AcceptChanges();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                prReqHeadTable.RejectChanges();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 关闭请购单
        ///// </summary>
        ///// <param name="prReqHeadRow">请购单表头数据行</param>
        //public bool ClosePrReq(DataRow prReqHeadRow)
        //{
        //    if (!CheckReqState(prReqHeadRow.Table, null, string.Format("'{0}'", DataTypeConvert.GetString(prReqHeadRow["PrReqNo"])), false, true, true, true))
        //        return false;

        //    DateTime serverTime = BaseSQL.GetServerDateTime();
        //    prReqHeadRow["ClosedId"] = SystemInfo.user.AutoId;
        //    prReqHeadRow["ClosedIp"] = SystemInfo.HostIpAddress;
        //    prReqHeadRow["ClosedTime"] = serverTime;
        //    prReqHeadRow["ReqState"] = 3;

        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);
        //                cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState={1}, ClosedId={2}, ClosedIp='{3}', ClosedTime='{4}' where PrReqNo='{0}'", DataTypeConvert.GetString(prReqHeadRow["PrReqNo"]), 3, SystemInfo.user.AutoId, SystemInfo.HostIpAddress, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
        //                cmd.ExecuteNonQuery();

        //                //保存日志到日志表中
        //                string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadRow, "PrReqNo", "关闭", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));

        //                trans.Commit();
        //                prReqHeadRow.AcceptChanges();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                prReqHeadRow.Table.RejectChanges();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 关闭选中的多条请购单
        /// </summary>
        public bool ClosePrReq_Multi(DataTable prReqHeadTable)
        {
            string prReqNoListStr = "";
            Dictionary<string, int> prReqNoDictionary = new Dictionary<string, int>();
            DateTime serverTime = BaseSQL.GetServerDateTime();
            for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
                {
                    string prReqNoStr = DataTypeConvert.GetString(prReqHeadTable.Rows[i]["PrReqNo"]);
                    prReqNoListStr += string.Format("'{0}',", prReqNoStr);
                    prReqHeadTable.Rows[i]["ClosedId"] = SystemInfo.user.AutoId;
                    prReqHeadTable.Rows[i]["ClosedIp"] = SystemInfo.HostIpAddress;
                    prReqHeadTable.Rows[i]["ClosedTime"] = serverTime;
                    prReqHeadTable.Rows[i]["ReqState"] = (int)CommonHandler.OrderState.已关闭;
                    prReqNoDictionary.Add(prReqNoStr, (int)CommonHandler.OrderState.已关闭);
                }
            }

            prReqNoListStr = prReqNoListStr.Substring(0, prReqNoListStr.Length - 1);
            if (!CheckReqState(prReqHeadTable, null, prReqNoListStr, false, true, true, true))
                return false;

            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (!wfHandleDAO.MultiOrderWorkFlowsHandle(cmd, WorkFlowsHandleDAO.OrderType.请购单, WorkFlowsHandleDAO.LineType.关闭, ref prReqNoDictionary))
                        {
                            return false;
                        }

                        cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState={1}, ClosedId={2}, ClosedIp='{3}', ClosedTime='{4}' where PrReqNo in ({0})", prReqNoListStr, (int)CommonHandler.OrderState.已关闭, SystemInfo.user.AutoId, SystemInfo.HostIpAddress, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        DataRow[] prReqHeadRows = prReqHeadTable.Select("select=1");
                        for (int i = 0; i < prReqHeadRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadRows[i], "PrReqNo", "关闭", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        }

                        //new FrmWorkFlowDataHandleDAO().HandleDataCurrentNode_IsEnd(cmd, prReqNoListStr, 3, 1);

                        trans.Commit();
                        prReqHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        prReqHeadTable.RejectChanges();
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
        /// 取消关闭选中的多条请购单
        /// </summary>
        public bool CancelClosePrReq_Multi(DataTable prReqHeadTable)
        {
            string prReqNoListStr = "";
            Dictionary<string, int> prReqNoDictionary = new Dictionary<string, int>();
            DateTime serverTime = BaseSQL.GetServerDateTime();
            for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
                {
                    string prReqNoStr = DataTypeConvert.GetString(prReqHeadTable.Rows[i]["PrReqNo"]);
                    prReqNoListStr += string.Format("'{0}',", prReqNoStr);
                    prReqHeadTable.Rows[i]["ClosedId"] = DBNull.Value;
                    prReqHeadTable.Rows[i]["ClosedIp"] = "";
                    prReqHeadTable.Rows[i]["ClosedTime"] = DBNull.Value;
                    prReqHeadTable.Rows[i]["ReqState"] = DataTypeConvert.GetString(prReqHeadTable.Rows[i]["Approver"]) == "" ? (int)CommonHandler.OrderState.待提交 : (int)CommonHandler.OrderState.已审批;
                    prReqNoDictionary.Add(prReqNoStr, DataTypeConvert.GetInt(prReqHeadTable.Rows[i]["ReqState"]));
                }
            }

            prReqNoListStr = prReqNoListStr.Substring(0, prReqNoListStr.Length - 1);
            if (!CheckReqState(prReqHeadTable, null, prReqNoListStr, true, true, false, true))
                return false;

            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (!wfHandleDAO.MultiOrderWorkFlowsHandle(cmd, WorkFlowsHandleDAO.OrderType.请购单, WorkFlowsHandleDAO.LineType.取消关闭, ref prReqNoDictionary))
                        {
                            return false;
                        }

                        DataRow[] prReqHeadRows = prReqHeadTable.Select("select=1");
                        for (int i = 0; i < prReqHeadRows.Length; i++)
                        {
                            string prReqNoStr = DataTypeConvert.GetString(prReqHeadRows[i]["PrReqNo"]);

                            cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState={1}, ClosedId=null, ClosedIp='{3}', ClosedTime=null where PrReqNo = '{0}'", prReqNoStr, DataTypeConvert.GetInt(prReqHeadRows[i]["ReqState"]), "", "");
                            cmd.ExecuteNonQuery();

                            //保存日志到日志表中
                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadRows[i], "PrReqNo", "取消关闭", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));

                            //new FrmWorkFlowDataHandleDAO().HandleDataCurrentNode_IsEnd(cmd, new List<string>() { prReqNoStr }, DataTypeConvert.GetInt(prReqHeadRows[i]["ReqState"]), 0);
                        }

                        trans.Commit();
                        prReqHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        prReqHeadTable.RejectChanges();
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
        /// 检测数据库中请购单状态是否可以操作
        /// </summary>
        public bool CheckReqState(DataTable prReqHeadTable, DataTable prReqListTable, string prReqNoListStr, bool checkNoSubmit, bool checkApprover, bool checkClosed, bool checkApproverBetween)
        {
            string sqlStr = string.Format("select PrReqNo, ReqState from PUR_PrReqHead where PrReqNo in ({0})", prReqNoListStr);
            DataTable tmpTable = BaseSQL.Query(sqlStr).Tables[0];
            for (int i = 0; i < tmpTable.Rows.Count; i++)
            {
                int reqState = DataTypeConvert.GetInt(tmpTable.Rows[i]["ReqState"]);
                switch (reqState)
                {
                    case (int)CommonHandler.OrderState.待提交:
                        if (checkNoSubmit)
                        {
                            MessageHandler.ShowMessageBox(string.Format("请购单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["PrReqNo"]), CommonHandler.OrderState.待提交));
                            prReqHeadTable.RejectChanges();
                            if (prReqListTable != null)
                                prReqListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case (int)CommonHandler.OrderState.已审批:
                        if (checkApprover)
                        {
                            MessageHandler.ShowMessageBox(string.Format("请购单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["PrReqNo"]), CommonHandler.OrderState.已审批));
                            prReqHeadTable.RejectChanges();
                            if (prReqListTable != null)
                                prReqListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case (int)CommonHandler.OrderState.已关闭:
                        if (checkClosed)
                        {
                            MessageHandler.ShowMessageBox(string.Format("请购单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["PrReqNo"]), CommonHandler.OrderState.已关闭));
                            prReqHeadTable.RejectChanges();
                            if (prReqListTable != null)
                                prReqListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case (int)CommonHandler.OrderState.审批中:
                        if (checkApproverBetween)
                        {
                            MessageHandler.ShowMessageBox(string.Format("请购单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["PrReqNo"]), CommonHandler.OrderState.审批中));
                            prReqHeadTable.RejectChanges();
                            if (prReqListTable != null)
                                prReqListTable.RejectChanges();
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

        /// <summary>
        /// 检测数据库中请购单是否有请购适用的记录
        /// </summary>
        private bool CheckApply(SqlCommand cmd, string prReqNoStr)
        {
            //cmd.CommandText = string.Format("select Count(*) from PUR_OrderList where PrReqNo = '{0}'", prReqNoStr);
            cmd.CommandText = string.Format("select COUNT(*) from PUR_PRPO where PRListId in (select AutoId from PUR_PrReqList where PrReqNo = '{0}')", prReqNoStr);
            if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
            {
                cmd.Transaction.Rollback();
                MessageHandler.ShowMessageBox(string.Format("请购单[{0}]已经有适用的采购订单记录，不可以操作。", prReqNoStr));
                return true;
            }
            cmd.CommandText = string.Format("select COUNT(*) from PUR_PIPR where PRListId in (select AutoId from PUR_PrReqList where PrReqNo = '{0}')", prReqNoStr);
            if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
            {
                cmd.Transaction.Rollback();
                MessageHandler.ShowMessageBox(string.Format("请购单[{0}]已经有适用的询价单记录，不可以操作。", prReqNoStr));
                return true;
            }

            return false;
        }

        ///// <summary>
        ///// 审批选中的多条请购单
        ///// </summary>
        //public bool PrReqApprovalInfo_Multi(DataTable prReqHeadTable, int nodeIdInt, string flowModuleIdStr, string approverOptionStr, int approverResultInt, ref int successCountInt)
        //{
        //    string prReqNoListStr = "";
        //    for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
        //    {
        //        if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
        //        {
        //            prReqNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(prReqHeadTable.Rows[i]["PrReqNo"]));
        //        }
        //    }

        //    prReqNoListStr = prReqNoListStr.Substring(0, prReqNoListStr.Length - 1);
        //    if (!CheckReqState(prReqHeadTable, null, prReqNoListStr, true, true, true, false))
        //        return false;
        //    successCountInt = 0;
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);
        //                DateTime serverTime = BaseSQL.GetServerDateTime();
        //                for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
        //                {
        //                    if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
        //                    {
        //                        DataRow prReqRow = prReqHeadTable.Rows[i];
        //                        string prReqNoStr = DataTypeConvert.GetString(prReqRow["PrReqNo"]);

        //                        cmd.CommandText = string.Format("select PUR_PrReqHead.PrReqNo, PUR_PrReqHead.ApprovalType, PUR_ApprovalType.ApprovalCat from PUR_PrReqHead left join PUR_ApprovalType on PUR_PrReqHead.ApprovalType = PUR_ApprovalType.TypeNo where PrReqNo='{0}'", prReqNoStr);
        //                        DataTable tmpTable = new DataTable();
        //                        SqlDataAdapter prReqadpt = new SqlDataAdapter(cmd);
        //                        prReqadpt.Fill(tmpTable);
        //                        if (tmpTable.Rows.Count == 0)
        //                        {
        //                            trans.Rollback();
        //                            //MessageHandler.ShowMessageBox("未查询到要操作的请购单，请查询后再进行操作。");
        //                            MessageHandler.ShowMessageBox(f.tsmiWcxdyc.Text);
        //                            return false;
        //                        }

        //                        string approvalTypeStr = DataTypeConvert.GetString(tmpTable.Rows[0]["ApprovalType"]);
        //                        cmd.CommandText = string.Format("select * from F_OrderNoApprovalList('{0}','{1}') Order by AppSequence", prReqNoStr, approvalTypeStr);
        //                        DataTable listTable = new DataTable();
        //                        SqlDataAdapter listadpt = new SqlDataAdapter(cmd);
        //                        listadpt.Fill(listTable);
        //                        if (listTable.Rows.Count == 0)
        //                        {
        //                            cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState=2 where PrReqNo='{0}'", prReqNoStr);
        //                            cmd.ExecuteNonQuery();
        //                            prReqHeadTable.Rows[i]["ReqState"] = 2;
        //                            continue;
        //                        }
        //                        int approvalCatInt = DataTypeConvert.GetInt(tmpTable.Rows[0]["ApprovalCat"]);
        //                        switch (approvalCatInt)
        //                        {
        //                            case 0:
        //                                if (DataTypeConvert.GetInt(listTable.Rows[0]["Approver"]) != SystemInfo.user.AutoId)
        //                                    continue;
        //                                break;
        //                            case 1:
        //                            case 2:
        //                                if (listTable.Select(string.Format("Approver={0}", SystemInfo.user.AutoId)).Length == 0)
        //                                    continue;
        //                                break;
        //                        }

        //                        if (approverResultInt == 1)
        //                        {
        //                            cmd.CommandText = string.Format("Insert into PUR_OrderApprovalInfo(OrderHeadNo, Approver, ApproverTime) values ('{0}', {1}, '{2}')", prReqNoStr, SystemInfo.user.AutoId, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
        //                            cmd.ExecuteNonQuery();

        //                            //保存日志到日志表中
        //                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadTable.Rows[i], "PrReqNo", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
        //                        }
        //                        else
        //                        {
        //                            //保存日志到日志表中
        //                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadTable.Rows[i], "PrReqNo", "拒绝审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
        //                        }

        //                        successCountInt++;
        //                        if (listTable.Rows.Count == 1 || approvalCatInt == 2)
        //                        {
        //                            prReqHeadTable.Rows[i]["ReqState"] = 2;
        //                        }
        //                        else
        //                        {
        //                            prReqHeadTable.Rows[i]["ReqState"] = 4;
        //                        }

        //                        if (approverResultInt != 1)
        //                        {
        //                            prReqHeadTable.Rows[i]["ReqState"] = 6;
        //                        }

        //                        if (SystemInfo.EnableWorkFlowMessage)
        //                        {
        //                            if (!new FrmWorkFlowDataHandleDAO().InsertWorkFlowDataHandle(cmd, new List<string>() { prReqNoStr }, "采购流程", "PUR_PrReqHead", approverResultInt == 1 ? 2 : 1, DataTypeConvert.GetInt(prReqHeadTable.Rows[i]["ReqState"]), SystemInfo.user.LoginID, approverOptionStr, approverResultInt, true))
        //                            {
        //                                trans.Rollback();
        //                                MessageHandler.ShowMessageBox("未查询到当前操作所属的流程节点信息，请在系统里登记模块流程信息。");
        //                                return false;
        //                            }
        //                        }

        //                        if (DataTypeConvert.GetInt(prReqHeadTable.Rows[i]["ReqState"]) == 2)
        //                        {
        //                            cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState = {1}, Approver = '{2}', ApproverIp = '{3}', ApproverTime = '{4}' where PrReqNo = '{0}'", prReqNoStr, prReqHeadTable.Rows[i]["ReqState"], SystemInfo.user.EmpName, SystemInfo.HostIpAddress, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
        //                        }
        //                        else
        //                        {
        //                            cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState={1} where PrReqNo='{0}'", prReqNoStr, prReqHeadTable.Rows[i]["ReqState"]);
        //                        }
        //                        cmd.ExecuteNonQuery();
        //                    }
        //                }

        //                trans.Commit();
        //                prReqHeadTable.AcceptChanges();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                prReqHeadTable.RejectChanges();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 取消审批选中的多条请购单
        /// </summary>
        public bool CancalPrReqApprovalInfo_Multi(DataTable prReqHeadTable)
        {
            string prReqNoListStr = "";
            Dictionary<string, int> prReqNoDictionary = new Dictionary<string, int>();
            for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
                {
                    string prReqNoStr = DataTypeConvert.GetString(prReqHeadTable.Rows[i]["PrReqNo"]);
                    prReqNoListStr += string.Format("'{0}',", prReqNoStr);
                    prReqHeadTable.Rows[i]["ReqState"] = (int)CommonHandler.OrderState.待提交;
                    prReqNoDictionary.Add(prReqNoStr, (int)CommonHandler.OrderState.待提交);
                }
            }

            prReqNoListStr = prReqNoListStr.Substring(0, prReqNoListStr.Length - 1);
            if (!CheckReqState(prReqHeadTable, null, prReqNoListStr, true, false, true, true))
                return false;

            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (!wfHandleDAO.MultiOrderWorkFlowsHandle(cmd, WorkFlowsHandleDAO.OrderType.请购单, WorkFlowsHandleDAO.LineType.取消审批, ref prReqNoDictionary))
                        {
                            return false;
                        }

                        cmd.CommandText = string.Format("Delete from PUR_OrderApprovalInfo where OrderHeadNo in ({0})", prReqNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState = {1}, Approver = null, ApproverIp = null, ApproverTime = null where PrReqNo in ({0})", prReqNoListStr, (int)CommonHandler.OrderState.待提交);
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        DataRow[] prReqHeadRows = prReqHeadTable.Select("select=1");
                        for (int i = 0; i < prReqHeadRows.Length; i++)
                        {
                            //检查是否有下级的订单
                            if (CheckApply(cmd, DataTypeConvert.GetString(prReqHeadRows[i]["PrReqNo"])))
                            {
                                prReqHeadTable.RejectChanges();
                                return false;
                            }

                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadRows[i], "PrReqNo", "取消审批", SystemInfo.user.EmpName, BaseSQL.GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss"));
                        }

                        //new FrmWorkFlowDataHandleDAO().HandleDataCurrentNode_IsEnd(cmd, prReqNoListStr, 1, 0);                        

                        trans.Commit();
                        prReqHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        prReqHeadTable.RejectChanges();
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
        /// 打印处理
        /// </summary>
        /// <param name="prReqNoStr">请购单号</param>
        /// <param name="handleTypeInt">打印处理类型：1 预览 2 打印 3 设计</param>
        public void PrintHandle(string prReqNoStr, int handleTypeInt)
        {
            DataSet ds = new DataSet();
            DataTable headTable = BaseSQL.GetTableBySql(string.Format("select * from V_Prn_PUR_PrReqHead where PrReqNo = '{0}' order by AutoId", prReqNoStr));
            headTable.TableName = "PrReqHead";
            for (int i = 0; i < headTable.Columns.Count; i++)
            {
                #region 设定主表显示的标题

                switch (headTable.Columns[i].ColumnName)
                {
                    case "PrReqNo":
                        headTable.Columns[i].Caption = "请购单号";
                        break;
                    case "ReqDate":
                        headTable.Columns[i].Caption = "请购日期";
                        break;
                    case "DepartmentNo":
                        headTable.Columns[i].Caption = "部门编号";
                        break;
                    case "DepartmentName":
                        headTable.Columns[i].Caption = "部门名称";
                        break;
                    case "ProjectNo":
                        headTable.Columns[i].Caption = "项目号";
                        break;
                    case "ProjectName":
                        headTable.Columns[i].Caption = "项目名称";
                        break;
                    case "StnNo":
                        headTable.Columns[i].Caption = "站号";
                        break;
                    case "PurCategory":
                        headTable.Columns[i].Caption = "采购类型编号";
                        break;
                    case "PurCategoryText":
                        headTable.Columns[i].Caption = "采购类型名称";
                        break;
                    case "ReqState":
                        headTable.Columns[i].Caption = "单据状态";
                        break;
                    case "ReqStateDesc":
                        headTable.Columns[i].Caption = "单据状态描述";
                        break;
                    case "Applicant":
                        headTable.Columns[i].Caption = "申请人";
                        break;
                    case "ApplicantIp":
                        headTable.Columns[i].Caption = "申请人IP";
                        break;
                    case "ApplicantTime":
                        headTable.Columns[i].Caption = "申请时间";
                        break;
                    case "Approver":
                        headTable.Columns[i].Caption = "审批人";
                        break;
                    case "ApproverIp":
                        headTable.Columns[i].Caption = "审批人IP";
                        break;
                    case "ApproverTime":
                        headTable.Columns[i].Caption = "审批时间";
                        break;
                    case "Modifier":
                        headTable.Columns[i].Caption = "修改人";
                        break;
                    case "ModifierIp":
                        headTable.Columns[i].Caption = "修改人IP";
                        break;
                    case "ModifierTime":
                        headTable.Columns[i].Caption = "修改时间";
                        break;
                    case "PrReqRemark":
                        headTable.Columns[i].Caption = "备注";
                        break;
                    case "Closed":
                        headTable.Columns[i].Caption = "关闭人";
                        break;
                    case "ClosedIp":
                        headTable.Columns[i].Caption = "关闭人IP";
                        break;
                    case "ClosedTime":
                        headTable.Columns[i].Caption = "关闭时间";
                        break;
                }

                #endregion
            }
            ds.Tables.Add(headTable);

            DataTable listTable = BaseSQL.GetTableBySql(string.Format("select *, ROW_NUMBER() over (order by AutoId) as RowNum from V_Prn_PUR_PrReqList where PrReqNo = '{0}' order by AutoId", prReqNoStr));
            listTable.TableName = "PrReqList";
            for (int i = 0; i < listTable.Columns.Count; i++)
            {
                #region 设定子表显示的标题

                switch (listTable.Columns[i].ColumnName)
                {
                    case "RowNum":
                        listTable.Columns[i].Caption = "行号";
                        break;
                    case "PrReqNo":
                        listTable.Columns[i].Caption = "请购单号";
                        break;
                    case "CodeNo":
                        listTable.Columns[i].Caption = "物料编号";
                        break;
                    case "CodeFileName":
                        listTable.Columns[i].Caption = "零件编号";
                        break;
                    case "CodeName":
                        listTable.Columns[i].Caption = "零件名称";
                        break;
                    case "CatgName":
                        listTable.Columns[i].Caption = "分类名称";
                        break;
                    case "CatgDescription":
                        listTable.Columns[i].Caption = "分类说明";
                        break;
                    case "CodeSpec":
                        listTable.Columns[i].Caption = "规格型号";
                        break;
                    case "CodeWeight":
                        listTable.Columns[i].Caption = "重量";
                        break;
                    case "MaterialVersion":
                        listTable.Columns[i].Caption = "物料版本";
                        break;
                    case "LibName":
                        listTable.Columns[i].Caption = "Level 1";
                        break;
                    case "MaterialCategory":
                        listTable.Columns[i].Caption = "Level 2";
                        break;
                    case "MaterialName":
                        listTable.Columns[i].Caption = "Level 3";
                        break;
                    case "Brand":
                        listTable.Columns[i].Caption = "品牌";
                        break;
                    case "FinishCatg":
                        listTable.Columns[i].Caption = "表面处理";
                        break;
                    case "LevelCatg":
                        listTable.Columns[i].Caption = "加工等级";
                        break;
                    case "Unit":
                        listTable.Columns[i].Caption = "单位";
                        break;
                    case "Qty":
                        listTable.Columns[i].Caption = "数量";
                        break;
                    case "RequirementDate":
                        listTable.Columns[i].Caption = "需求日期";
                        break;
                    case "PrReqListRemark":
                        listTable.Columns[i].Caption = "备注";
                        break;
                }

                #endregion
            }
            ds.Tables.Add(listTable);

            ReportHandler rptHandler = new ReportHandler();
            List<DevExpress.XtraReports.Parameters.Parameter> paralist = rptHandler.GetSystemInfo_ParamList();
            rptHandler.XtraReport_Handle("PUR_PrReqHead", ds, paralist, handleTypeInt);

        }

        /// <summary>
        /// 查询请购余量表的SQL
        /// </summary>
        public string Query_PrReqList_Overplus(string beginDateStr, string endDateStr, string reqDepStr, string purCategoryStr, string projectNoStr, int reqStateInt, int codeIdInt, bool overplusBool, string commonStr)
        {
            string sqlStr = " 1=1";
            if (beginDateStr != "")
            {
                sqlStr += string.Format(" and ReqDate between '{0}' and '{1}'", beginDateStr, endDateStr);
            }
            if (reqDepStr != "")
            {
                sqlStr += string.Format(" and ReqDep='{0}'", reqDepStr);
            }
            if (purCategoryStr != "")
            {
                sqlStr += string.Format(" and PurCategory='{0}'", purCategoryStr);
            }
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and ProjectNo='{0}'", projectNoStr);
            }
            if (reqStateInt != 0)
            {
                sqlStr += string.Format(" and ReqState={0}", reqStateInt);
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and CodeId={0}", codeIdInt);
            }
            if (overplusBool)
            {
                sqlStr += string.Format(" and IsNull(Overplus, 0)>0");
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (PrReqNo like '%{0}%' or ProjectNo like '%{0}%' or StnNo like '%{0}%' or PrReqListRemark like '%{0}%')", commonStr);
            }
            sqlStr = string.Format("select * from V_PUR_PrReqList_Overplus where {0} order by AutoId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 请购与采购查询的SQL
        /// </summary>
        public string Query_PrReqListAndOrderList(string beginDateStr, string endDateStr, string reqDepStr, string purCategoryStr, string projectNoStr, int reqStateInt, int codeIdInt, string commonStr)
        {
            string sqlStr = " 1=1";
            if (beginDateStr != "")
            {
                sqlStr += string.Format(" and ReqDate between '{0}' and '{1}'", beginDateStr, endDateStr);
            }
            if (reqDepStr != "")
            {
                sqlStr += string.Format(" and ReqDep='{0}'", reqDepStr);
            }
            if (purCategoryStr != "")
            {
                sqlStr += string.Format(" and PurCategory='{0}'", purCategoryStr);
            }
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and ProjectNo='{0}'", projectNoStr);
            }
            if (reqStateInt != 0)
            {
                sqlStr += string.Format(" and ReqState={0}", reqStateInt);
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and CodeId={0}", codeIdInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (PrReqNo like '%{0}%' or ProjectNo like '%{0}%' or StnNo like '%{0}%' or PrReqListRemark like '%{0}%')", commonStr);
            }
            sqlStr = string.Format("select * from V_PUR_PrReqListAndOrderList where {0} order by AutoId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 查询请购明细的信息是否有生产计划生成的
        /// </summary>
        public bool Query_PrReqList_PSBomAutoId(string prReqNoStr)
        {
            string sqlStr = string.Format("select Count(*) from PUR_PrReqList where PrReqNo = '{0}' and ISNULL(PSBomAutoId, 0) != 0", prReqNoStr);
            int count = DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
            if (count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 查询请购单明细表关联表头表的SQL
        /// </summary>
        public string QueryPrReqList_Head_SQL(string beginRequirementDateStr, string endRequirementDateStr, string beginDateStr, string endDateStr, string reqDepStr, string purCategoryStr, int reqStateInt, string projectNoStr, int codeIdInt, string commonStr)
        {
            string sqlStr = " 1=1";
            if (beginRequirementDateStr != "")
            {
                sqlStr += string.Format(" and RequirementDate between '{0}' and '{1}'", beginRequirementDateStr, endRequirementDateStr);
            }
            if (beginDateStr != "")
            {
                sqlStr += string.Format(" and ReqDate between '{0}' and '{1}'", beginDateStr, endDateStr);
            }
            if (reqDepStr != "")
            {
                sqlStr += string.Format(" and ReqDep='{0}'", reqDepStr);
            }
            if (purCategoryStr != "")
            {
                sqlStr += string.Format(" and PurCategory='{0}'", purCategoryStr);
            }
            if (reqStateInt != 0)
            {
                sqlStr += string.Format(" and ReqState={0}", reqStateInt);
            }
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and ProjectNo='{0}'", projectNoStr);
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and List.CodeId={0}", codeIdInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (PrReqNo like '%{0}%' or CreatorName like '%{0}%' or StnNo like '%{0}%' or PrReqListRemark like '%{0}%' or PrReqRemark like '%{0}%' or ProjectNo like '%{0}%' or List.CodeFileName like '%{0}%' or CodeName like '%{0}%')", commonStr);
            }
            sqlStr = string.Format("select List.*, Parts.CodeName from V_PUR_PrReqList_Head as List left join SW_PartsCode as Parts on List.CodeId = Parts.AutoId where {0} order by ListAutoId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 审批选中的多条请购单
        /// </summary>
        public bool PrReqApprovalInfoNew_Multi(DataTable prReqHeadTable, string approverOptionStr, int approverResultInt, ref int successCountInt)
        {
            string prReqNoListStr = "";
            Dictionary<string, int> prReqNoDictionary = new Dictionary<string, int>();
            int stateInt = (int)CommonHandler.OrderState.已审批;
            if (approverResultInt != 1)
                stateInt = (int)CommonHandler.OrderState.待提交;

            for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
                {
                    string prReqNoStr = DataTypeConvert.GetString(prReqHeadTable.Rows[i]["PrReqNo"]);
                    prReqNoListStr += string.Format("'{0}',", prReqNoStr);
                    prReqNoDictionary.Add(prReqNoStr, stateInt);
                }
            }

            prReqNoListStr = prReqNoListStr.Substring(0, prReqNoListStr.Length - 1);
            if (successCountInt == 1)
            {
                if (!CheckReqState(prReqHeadTable, null, prReqNoListStr, false, true, true, false))
                    return false;
            }
            else
            {
                if (!CheckReqState(prReqHeadTable, null, prReqNoListStr, true, true, true, false))
                    return false;
            }
            successCountInt = 0;

            //FrmWorkFlowDataHandleDAO wfdhDAO = new FrmWorkFlowDataHandleDAO();
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        DateTime serverTime = BaseSQL.GetServerDateTime();

                        if (!wfHandleDAO.MultiOrderWorkFlowsHandle(cmd, WorkFlowsHandleDAO.OrderType.请购单, approverResultInt == 1 ? WorkFlowsHandleDAO.LineType.审批 : WorkFlowsHandleDAO.LineType.拒绝, approverOptionStr, ref prReqNoDictionary))
                        {
                            return false;
                        }

                        for (int i = 0; i < prReqHeadTable.Rows.Count; i++)
                        {
                            if (DataTypeConvert.GetBoolean(prReqHeadTable.Rows[i]["Select"]))
                            {
                                DataRow prReqRow = prReqHeadTable.Rows[i];
                                string prReqNoStr = DataTypeConvert.GetString(prReqRow["PrReqNo"]);

                                int reqStateInt = prReqNoDictionary[prReqNoStr];

                                //if (!wfdhDAO.HandleWorkFlowData(cmd, prReqNoStr, "采购流程", "PUR_PrReqHead", "PrReqNo", 2, ref reqStateInt, SystemInfo.user.AutoId, SystemInfo.user.LoginID, approverOptionStr, approverResultInt, true))
                                //{
                                //    trans.Rollback();
                                //    return false;
                                //}

                                prReqHeadTable.Rows[i]["ReqState"] = reqStateInt;

                                if (approverResultInt == 1)
                                {
                                    //保存日志到日志表中
                                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadTable.Rows[i], "PrReqNo", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));

                                    cmd.CommandText = string.Format("Insert into PUR_OrderApprovalInfo(OrderHeadNo, Approver, ApproverTime) values ('{0}', {1}, '{2}')", prReqNoStr, SystemInfo.user.AutoId, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                    cmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    //wfdhDAO.HandleDataCurrentNode_IsEnd(cmd, "'" + prReqNoStr + "'", 1, 0);

                                    //保存日志到日志表中
                                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "请购单", prReqHeadTable.Rows[i], "PrReqNo", "拒绝审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                }

                                successCountInt++;

                                if (DataTypeConvert.GetInt(prReqHeadTable.Rows[i]["ReqState"]) == (int)CommonHandler.OrderState.已审批)
                                {
                                    cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState = {1}, Approver = '{2}', ApproverIp = '{3}', ApproverTime = '{4}' where PrReqNo = '{0}'", prReqNoStr, prReqHeadTable.Rows[i]["ReqState"], SystemInfo.user.EmpName, SystemInfo.HostIpAddress, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                                else
                                {
                                    cmd.CommandText = string.Format("Update PUR_PrReqHead set ReqState={1} where PrReqNo='{0}'", prReqNoStr, prReqHeadTable.Rows[i]["ReqState"]);
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        prReqHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        prReqHeadTable.RejectChanges();
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
