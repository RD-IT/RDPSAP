using PSAP.DAO.BSDAO;
using PSAP.DAO.WORKFLOWDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.PBDAO
{
    class FrmProductionPlanDAO
    {
        /// <summary>
        /// 查询工单信息
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="beginDateStr">开始日期字符串</param>
        /// <param name="endDateStr">结束日期字符串</param>
        /// <param name="codeIdInt">物料信息AutoId</param>
        /// <param name="manufactureNoStr">工程信息</param>
        /// <param name="projectNoStr">项目号</param>
        /// <param name="currentStatusInt">状态</param>
        /// <param name="creatorInt">创建人</param>
        /// <param name="approverInt">审核人</param>
        /// <param name="commonStr">通用查询条件</param>
        /// <param name="nullTable">是否查询空表</param>
        public void QueryProductionPlan(DataTable queryDataTable, string beginDateStr, string endDateStr, int codeIdInt, string manufactureNoStr, string projectNoStr, int currentStatusInt, int creatorInt, int approverInt, string commonStr, bool nullTable)
        {
            BaseSQL.Query(QueryProductionPlan_SQL(beginDateStr, endDateStr, codeIdInt, manufactureNoStr, projectNoStr, currentStatusInt, creatorInt, approverInt, commonStr, nullTable), queryDataTable);
        }
        /// <summary>
        /// 查询工单表头的SQL
        /// </summary>
        public string QueryProductionPlan_SQL(string beginDateStr, string endDateStr, int codeIdInt, string manufactureNoStr, string projectNoStr, int currentStatusInt, int creatorInt, int approverInt, string commonStr, bool nullTable)
        {
            string sqlStr = " 1=1";
            if (beginDateStr != "")
            {
                sqlStr += string.Format(" and (StartTime between '{0}' and '{1}' or EndTime between '{0}' and '{1}')", beginDateStr, endDateStr);
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and (CodeId = {0} or PlanNo in (select PlanNo from PB_ProductionPlanList where LevelCodeId = {0}))", codeIdInt);
            }
            if (manufactureNoStr != "")
            {
                sqlStr += string.Format(" and ManufactureNo='{0}'", manufactureNoStr);
            }
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and ProjectNo='{0}'", projectNoStr);
            }
            if (currentStatusInt != 0)
            {
                sqlStr += string.Format(" and CurrentStatus={0}", currentStatusInt);
            }
            if (creatorInt != 0)
            {
                sqlStr += string.Format(" and Creator={0}", creatorInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (PlanNo like '%{0}%' or ProjectNo like '%{0}%' or Line like '%{0}%' or Remark like '%{0}%' or (DesignBomListId in (select AutoId from PB_DesignBomList where SalesOrderNo = '{0}' or PbBomNo = '{0}')))", commonStr);
            }
            if (approverInt >= 0)
            {
                //if (approverInt == 0)
                //    sqlStr += string.Format(" and CurrentStatus in (4, 5)");
                //else
                //{
                //    sqlStr = string.Format("select Head.* from PB_ProductionPlan as Head left join PUR_ApprovalType on Head.ApprovalType = PUR_ApprovalType.TypeNo where {0} and Head.CurrentStatus in (4) and ((PUR_ApprovalType.ApprovalCat = 0 and exists (select * from(select top 1 * from F_OrderNoApprovalList(Head.PlanNo, Head.ApprovalType) Order by AppSequence) as minlist where Approver = {1})) or(PUR_ApprovalType.ApprovalCat = 1 and exists(select * from F_OrderNoApprovalList(Head.PlanNo, Head.ApprovalType) where Approver = {1}))) order by AutoId", sqlStr, approverInt);
                //    return sqlStr;
                //}

                if (approverInt == 0)
                    sqlStr += string.Format(" and CurrentStatus in (4, 5)");
                else
                {
                    string tableNameStr = "PB_ProductionPlan";
                    int moduleTypeInt = 2;
                    string tmpSqlStr = new FrmWorkFlowDataHandleDAO().GetWorkFlowLine_ConditionString(tableNameStr, moduleTypeInt, approverInt);
                    sqlStr = string.Format("select PB_ProductionPlan.*, CodeFileName, CodeName from PB_ProductionPlan left join SW_PartsCode on PB_ProductionPlan.CodeId = SW_PartsCode.AutoId where {0} {1} order by AutoId", sqlStr, tmpSqlStr);
                    return sqlStr;
                }
            }
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select PB_ProductionPlan.*, CodeFileName, CodeName from PB_ProductionPlan left join SW_PartsCode on PB_ProductionPlan.CodeId = SW_PartsCode.AutoId where {0} order by AutoId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 查询生产计划展开信息表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="planNoStr">工单号</param>
        public void QueryProductionPlanList(DataTable queryDataTable, string planNoStr)
        {
            string sqlStr = string.Format(" and PlanNo='{0}'", planNoStr);
            sqlStr = string.Format("select PB_ProductionPlanList.*, Case When ISNULL(LevelCodeId, 0) = 0 then CodeId else LevelCodeId end as CodeName from PB_ProductionPlanList where 1=1 {0} order by AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 根据选择删除多条工单
        /// </summary>
        public bool DeleteProductionPlan_Multi(DataTable productionPlanTable)
        {
            string planNoListStr = "";
            for (int i = 0; i < productionPlanTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(productionPlanTable.Rows[i]["Select"]))
                {
                    planNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(productionPlanTable.Rows[i]["PlanNo"]));
                }
            }
            planNoListStr = planNoListStr.Substring(0, planNoListStr.Length - 1);
            if (!CheckCurrentStatus(productionPlanTable, null, planNoListStr, false, true, true, true, false))
                return false;
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        //保存日志到日志表中
                        DataRow[] productionPlanRows = productionPlanTable.Select("select=1");
                        for (int i = 0; i < productionPlanRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_DeleteRow(cmd, "工单", productionPlanRows[i], "PlanNo");
                        }

                        cmd.CommandText = string.Format("Delete from PB_ProductionPlanList where PlanNo in ({0})", planNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from PB_ProductionPlan where PlanNo in ({0})", planNoListStr);
                        cmd.ExecuteNonQuery();

                        //if (SystemInfo.EnableWorkFlowMessage)
                        {
                            new FrmWorkFlowDataHandleDAO().DeleteDataCurrentNode(cmd, planNoListStr);
                        }

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
        /// 检测数据库中工单状态是否可以操作
        /// </summary>
        public bool CheckCurrentStatus(DataTable productionPlanTable, DataTable productionPlanListTable, string planNoListStr, bool checkNoApprover, bool checkApprover, bool checkApproverBetween, bool checkSubmit, bool checkReject)
        {
            string sqlStr = string.Format("select PlanNo, CurrentStatus from PB_ProductionPlan where PlanNo in ({0})", planNoListStr);
            DataTable tmpTable = BaseSQL.Query(sqlStr).Tables[0];
            for (int i = 0; i < tmpTable.Rows.Count; i++)
            {
                int currentStatusInt = DataTypeConvert.GetInt(tmpTable.Rows[i]["CurrentStatus"]);
                switch (currentStatusInt)
                {
                    case 1:
                        if (checkNoApprover)
                        {
                            MessageHandler.ShowMessageBox(string.Format("工单[{0}]未审批，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["PlanNo"])));
                            productionPlanTable.RejectChanges();
                            if (productionPlanListTable != null)
                                productionPlanListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case 2:
                        if (checkApprover)
                        {
                            MessageHandler.ShowMessageBox(string.Format("工单[{0}]已经审批，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["PlanNo"])));
                            productionPlanTable.RejectChanges();
                            if (productionPlanListTable != null)
                                productionPlanListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case 4:
                        if (checkApproverBetween)
                        {
                            MessageHandler.ShowMessageBox(string.Format("工单[{0}]已经审批中，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["PlanNo"])));
                            productionPlanTable.RejectChanges();
                            if (productionPlanListTable != null)
                                productionPlanListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case 5:
                        if (checkSubmit)
                        {
                            MessageHandler.ShowMessageBox(string.Format("工单[{0}]已经提交，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["PlanNo"])));
                            productionPlanTable.RejectChanges();
                            if (productionPlanListTable != null)
                                productionPlanListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case 6:
                        if (checkReject)
                        {
                            MessageHandler.ShowMessageBox(string.Format("工单[{0}]已经拒绝，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["PlanNo"])));
                            productionPlanTable.RejectChanges();
                            if (productionPlanListTable != null)
                                productionPlanListTable.RejectChanges();
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

        /// <summary>
        /// 保存工单
        /// </summary>
        public int SaveProductionPlan(DataRow productionPlanRow, DataTable productionPlanListTable)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        int dbListId = DataTypeConvert.GetInt(productionPlanRow["DesignBomListId"]);
                        if (dbListId <= 0)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("设计Bom列表选择的零件不正确，请重新选择。");
                            return 0;
                        }

                        //cmd.CommandText = string.Format("select RemainQty - (Select IsNull(SUM(Qty), 0) from V_PB_ProductionPlanList_All as ppList where ppList.DesignBomListId = PB_DesignBomList.AutoId and ppList.PlanNo != '{1}') as OpQty from PB_DesignBomList where AutoId = {0}", dbListId, DataTypeConvert.GetString(productionPlanRow["PlanNo"]));
                        double remainQty = Query_DesignBomList_OpQty(cmd,dbListId, DataTypeConvert.GetString(productionPlanRow["PlanNo"]));
                        double ppRowQty = DataTypeConvert.GetDouble(productionPlanRow["Qty"]);
                        if (ppRowQty > remainQty)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox(string.Format("设计Bom列表的可登记零件数量[{0}]小于登记单主表的数量[{1}]，请重新输入。", remainQty, ppRowQty));
                            return 0;
                        }

                        if (DataTypeConvert.GetInt(productionPlanRow["PlanStatus"]) == 1)
                        {
                            if (productionPlanListTable.Rows.Count == 1 && DataTypeConvert.GetInt(productionPlanListTable.Rows[0]["DesignBomListId"]) == dbListId)
                            {

                            }
                            else
                            {
                                for (int i = 0; i < productionPlanListTable.Rows.Count; i++)
                                {
                                    if (productionPlanListTable.Rows[i].RowState != DataRowState.Deleted)
                                    {
                                        int tmpListId = DataTypeConvert.GetInt(productionPlanListTable.Rows[i]["DesignBomListId"]);
                                        double opQty = DataTypeConvert.GetDouble(Query_DesignBomList_OpQty(cmd, tmpListId, DataTypeConvert.GetString(productionPlanRow["PlanNo"])));
                                        double listQty = DataTypeConvert.GetDouble(productionPlanListTable.Rows[i]["Qty"]);
                                        if (listQty > opQty)
                                        {
                                            trans.Rollback();
                                            cmd.CommandText = string.Format("select CodeName from SW_PartsCode where AutoId = {0}", productionPlanListTable.Rows[i]["LevelCodeId"]);
                                            MessageHandler.ShowMessageBox(string.Format("设计Bom列表的可登记零件[{2}]数量[{0}]小于登记单明细的数量[{1}]，请重新输入。", opQty, listQty, DataTypeConvert.GetString(cmd.ExecuteScalar())));
                                            return 0;
                                        }
                                    }
                                }
                            }
                        }

                        if (productionPlanRow.RowState == DataRowState.Added)//新增
                        {
                            string planNo = BaseSQL.GetMaxCodeNo(cmd, "PP");
                            productionPlanRow["PlanNo"] = planNo;
                            productionPlanRow["CreatorIp"] = SystemInfo.HostIpAddress;
                            productionPlanRow["Currentdatetime"] = BaseSQL.GetServerDateTime();

                            for (int i = 0; i < productionPlanListTable.Rows.Count; i++)
                            {
                                productionPlanListTable.Rows[i]["PlanNo"] = planNo;
                            }
                        }
                        else//修改
                        {
                            if (!CheckCurrentStatus(productionPlanRow.Table, productionPlanListTable, string.Format("'{0}'", DataTypeConvert.GetString(productionPlanRow["PlanNo"])), false, true, true, true, false))
                                return -1;

                            productionPlanRow["Modifier"] = SystemInfo.user.AutoId;
                            productionPlanRow["ModifierIp"] = SystemInfo.HostIpAddress;
                            productionPlanRow["ModifierTime"] = BaseSQL.GetServerDateTime();
                        }

                        //保存日志到日志表中
                        string logStr = LogHandler.RecordLog_DataRow(cmd, "工单", productionPlanRow, "PlanNo");

                        //if (SystemInfo.EnableWorkFlowMessage)
                        //{
                        //    if (!new FrmWorkFlowDataHandleDAO().InsertWorkFlowDataHandle(cmd, new List<string>() { DataTypeConvert.GetString(productionPlanRow["PlanNo"]) }, "生产流程", "PB_ProductionPlan", 1, DataTypeConvert.GetInt(productionPlanRow["CurrentStatus"]), "", "", 1, false))
                        //    {
                        //        trans.Rollback();
                        //        MessageHandler.ShowMessageBox("未查询到当前操作所属的流程节点信息，请在系统里登记模块流程信息。");
                        //        return -1;
                        //    }
                        //}

                        for (int i = 0; i < productionPlanListTable.Rows.Count; i++)
                        {
                            if (productionPlanListTable.Rows[i].RowState != DataRowState.Deleted)
                                productionPlanListTable.Rows[i]["ParentId"] = DBNull.Value;
                            else
                            {
                                cmd.CommandText = string.Format("Update PB_ProductionPlanList set ParentId = Null where AutoId = {0}", productionPlanListTable.Rows[i]["AutoId", DataRowVersion.Original]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        cmd.CommandText = "select * from PB_ProductionPlan where 1=2";
                        SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                        DataTable tmpHeadTable = new DataTable();
                        adapterHead.Fill(tmpHeadTable);
                        BaseSQL.UpdateDataTable(adapterHead, productionPlanRow.Table);

                        cmd.CommandText = "select * from PB_ProductionPlanList where 1=2";
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable tmpListTable = new DataTable();
                        adapterList.Fill(tmpListTable);
                        BaseSQL.UpdateDataTable(adapterList, productionPlanListTable.GetChanges());

                        if (productionPlanListTable.Rows.Count > 0)
                        {
                            cmd.CommandText = string.Format("Update PB_ProductionPlanList set ParentId = PPListB.AutoId from PB_ProductionPlanList left join PB_ProductionPlanList as PPListB on PB_ProductionPlanList.DesignBomListParentId = PPListB.DesignBomListId where PB_ProductionPlanList.PlanNo = '{0}'", DataTypeConvert.GetString(productionPlanRow["PlanNo"]));
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                        productionPlanRow.Table.AcceptChanges();
                        productionPlanListTable.AcceptChanges();
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        productionPlanRow.Table.RejectChanges();
                        productionPlanListTable.RejectChanges();
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
        /// 查询设计Bom列表某项可以操作的数量
        /// </summary>
        public double Query_DesignBomList_OpQty(int dbListIdInt, string planNo)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        double opQty = Query_DesignBomList_OpQty(cmd, dbListIdInt, planNo);

                        trans.Commit();
                        return opQty;
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

        public double Query_DesignBomList_OpQty(SqlCommand cmd, int dbListIdInt, string planNo)
        {
            cmd.CommandText = string.Format("select TotalQty from PB_DesignBomList where AutoId = {0}", dbListIdInt);
            double myTotalQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
            cmd.CommandText = string.Format("Select IsNull(SUM(Qty), 0) from V_PB_ProductionPlanList_All where DesignBomListId = {0} and PlanNo != '{1}'", dbListIdInt, planNo);
            double myTotalQty_OtherPPList = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
            double opQty_myTotalQty = myTotalQty - myTotalQty_OtherPPList;

            cmd.CommandText = string.Format("select SUM(TotalQty) - SUM(AbsQty) from F_DesignBomList_RelationNodeTotal({0})", dbListIdInt);
            double relationTotalQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
            cmd.CommandText =string.Format("Select IsNull(SUM(Qty), 0) from V_PB_ProductionPlanList_All where DesignBomListId in (select AutoId from F_DesignBomList_RelationNodeTotal({0})) and PlanNo != '{1}'", dbListIdInt, planNo);
            double relationTotalQty_OtherPPList = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
            double opQty_relationTotalQty = relationTotalQty - relationTotalQty_OtherPPList;

            return Math.Min(opQty_myTotalQty, opQty_relationTotalQty);

            //cmd.CommandText = string.Format("select RemainQty - (Select IsNull(SUM(Qty), 0) from V_PB_ProductionPlanList_All as ppList where ppList.DesignBomListId = PB_DesignBomList.AutoId and ppList.PlanNo != '{1}') as OpQty from PB_DesignBomList where AutoId = {0}", dbListIdInt, planNo);
            //return DataTypeConvert.GetDouble(cmd.ExecuteScalar());
        }

        /// <summary>
        /// 提交选中的多条工单
        /// </summary>
        public bool SubmitPPlan_Multi(DataTable productionPlanTable)
        {
            string planNoListStr = "";
            DateTime serverTime = BaseSQL.GetServerDateTime();
            for (int i = 0; i < productionPlanTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(productionPlanTable.Rows[i]["Select"]))
                {
                    planNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(productionPlanTable.Rows[i]["PlanNo"]));
                    productionPlanTable.Rows[i]["CurrentStatus"] = 5;
                }
            }

            planNoListStr = planNoListStr.Substring(0, planNoListStr.Length - 1);
            if (!CheckCurrentStatus(productionPlanTable, null, planNoListStr, false, true, true, true, false))
                return false;

            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        cmd.CommandText = string.Format("Update PB_ProductionPlan set CurrentStatus={1} where PlanNo in ({0})", planNoListStr, 5);
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        DataRow[] productionPlanRows = productionPlanTable.Select("select=1");
                        for (int i = 0; i < productionPlanRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "工单", productionPlanRows[i], "PlanNo", "提交", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            
                            //if (SystemInfo.EnableWorkFlowMessage)
                            {
                                int stateInt = 5;
                                if (!new FrmWorkFlowDataHandleDAO().HandleWorkFlowData(cmd, DataTypeConvert.GetString(productionPlanRows[i]["PlanNo"]), "生产流程", "PB_ProductionPlan", "PlanNo", 1, ref stateInt, -1, "", "", 0, false))
                                {
                                    trans.Rollback();
                                    return false;
                                }

                                //if (!new FrmWorkFlowDataHandleDAO().InsertWorkFlowDataHandle(cmd, new List<string>() { DataTypeConvert.GetString(productionPlanRows[i]["PlanNo"]) }, "生产流程", "PB_ProductionPlan", 1, DataTypeConvert.GetInt(productionPlanRows[i]["CurrentStatus"]), "", "", 1, false))
                                //{
                                //    trans.Rollback();
                                //    MessageHandler.ShowMessageBox("未查询到当前操作所属的流程节点信息，请在系统里登记模块流程信息。");
                                //    return false;
                                //}
                            }
                        }
                        trans.Commit();
                        productionPlanTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        productionPlanTable.RejectChanges();
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
        /// 取消提交选中的多条工单
        /// </summary>
        public bool CancelSubmitPPlan_Multi(DataTable productionPlanTable)
        {
            string planNoListStr = "";
            DateTime serverTime = BaseSQL.GetServerDateTime();
            for (int i = 0; i < productionPlanTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(productionPlanTable.Rows[i]["Select"]))
                {
                    planNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(productionPlanTable.Rows[i]["PlanNo"]));
                    productionPlanTable.Rows[i]["CurrentStatus"] = 1;
                }
            }

            planNoListStr = planNoListStr.Substring(0, planNoListStr.Length - 1);
            if (!CheckCurrentStatus(productionPlanTable, null, planNoListStr, true, true, true, false, true))
                return false;

            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        cmd.CommandText = string.Format("Update PB_ProductionPlan set CurrentStatus={1} where PlanNo in ({0})", planNoListStr, 1);
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        DataRow[] productionPlanRows = productionPlanTable.Select("select=1");
                        for (int i = 0; i < productionPlanRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "工单", productionPlanRows[i], "PlanNo", "取消提交", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        }

                        //if (SystemInfo.EnableWorkFlowMessage)
                        {
                            new FrmWorkFlowDataHandleDAO().HandleDataCurrentNode_IsEnd(cmd, planNoListStr, 1, 0);
                        }

                        trans.Commit();
                        productionPlanTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        productionPlanTable.RejectChanges();
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
        /// 审批选中的多条工单
        /// </summary>
        public bool PPlanApprovalInfo_Multi(DataTable productionPlanTable, int nodeIdInt, string flowModuleIdStr, string approverOptionStr, int approverResultInt, ref int successCountInt)
        {
            string planNoListStr = "";
            for (int i = 0; i < productionPlanTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(productionPlanTable.Rows[i]["Select"]))
                {
                    planNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(productionPlanTable.Rows[i]["PlanNo"]));
                }
            }

            planNoListStr = planNoListStr.Substring(0, planNoListStr.Length - 1);
            if (!CheckCurrentStatus(productionPlanTable, null, planNoListStr, true, true, false, false, true))
                return false;
            successCountInt = 0;
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        DateTime serverTime = BaseSQL.GetServerDateTime();
                        for (int i = 0; i < productionPlanTable.Rows.Count; i++)
                        {
                            if (DataTypeConvert.GetBoolean(productionPlanTable.Rows[i]["Select"]))
                            {
                                DataRow productionPlanRow = productionPlanTable.Rows[i];
                                string planNoStr = DataTypeConvert.GetString(productionPlanRow["PlanNo"]);

                                cmd.CommandText = string.Format("select PB_ProductionPlan.PlanNo, PB_ProductionPlan.ApprovalType, PUR_ApprovalType.ApprovalCat from PB_ProductionPlan left join PUR_ApprovalType on PB_ProductionPlan.ApprovalType = PUR_ApprovalType.TypeNo where PlanNo='{0}'", planNoStr);
                                DataTable tmpTable = new DataTable();
                                SqlDataAdapter prReqadpt = new SqlDataAdapter(cmd);
                                prReqadpt.Fill(tmpTable);
                                if (tmpTable.Rows.Count == 0)
                                {
                                    trans.Rollback();
                                    MessageHandler.ShowMessageBox("未查询到要操作的工单，请刷新后再进行操作。");
                                    return false;
                                }

                                string approvalTypeStr = DataTypeConvert.GetString(tmpTable.Rows[0]["ApprovalType"]);
                                cmd.CommandText = string.Format("select * from F_OrderNoApprovalList('{0}','{1}') Order by AppSequence", planNoStr, approvalTypeStr);
                                DataTable listTable = new DataTable();
                                SqlDataAdapter listadpt = new SqlDataAdapter(cmd);
                                listadpt.Fill(listTable);
                                if (listTable.Rows.Count == 0)
                                {
                                    cmd.CommandText = string.Format("Update PB_ProductionPlan set CurrentStatus=2 where PlanNo='{0}'", planNoStr);
                                    cmd.ExecuteNonQuery();
                                    productionPlanTable.Rows[i]["CurrentStatus"] = 2;
                                    continue;
                                }
                                int approvalCatInt = DataTypeConvert.GetInt(tmpTable.Rows[0]["ApprovalCat"]);
                                switch (approvalCatInt)
                                {
                                    case 0:
                                        if (DataTypeConvert.GetInt(listTable.Rows[0]["Approver"]) != SystemInfo.user.AutoId)
                                            continue;
                                        break;
                                    case 1:
                                    case 2:
                                        if (listTable.Select(string.Format("Approver={0}", SystemInfo.user.AutoId)).Length == 0)
                                            continue;
                                        break;
                                }

                                if (!SystemInfo.EnableWorkFlowMessage || (SystemInfo.EnableWorkFlowMessage && approverResultInt == 1))
                                {
                                    cmd.CommandText = string.Format("Insert into PUR_OrderApprovalInfo(OrderHeadNo, Approver, ApproverTime) values ('{0}', {1}, '{2}')", planNoStr, SystemInfo.user.AutoId, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                    cmd.ExecuteNonQuery();

                                    //保存日志到日志表中
                                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "工单", productionPlanTable.Rows[i], "PlanNo", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                                else
                                {
                                    //保存日志到日志表中
                                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "工单", productionPlanTable.Rows[i], "PlanNo", "拒绝审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                }

                                successCountInt++;
                                if (listTable.Rows.Count == 1 || approvalCatInt == 2)
                                {
                                    productionPlanTable.Rows[i]["CurrentStatus"] = 2;
                                }
                                else
                                {
                                    productionPlanTable.Rows[i]["CurrentStatus"] = 4;
                                }

                                if (SystemInfo.EnableWorkFlowMessage)
                                {
                                    if (approverResultInt != 1)
                                    {
                                        productionPlanTable.Rows[i]["CurrentStatus"] = 6;
                                    }

                                    if (!new FrmWorkFlowDataHandleDAO().InsertWorkFlowDataHandle(cmd, new List<string>() { planNoStr }, "生产流程", "PB_ProductionPlan", approverResultInt == 1 ? 2 : 1, DataTypeConvert.GetInt(productionPlanTable.Rows[i]["CurrentStatus"]), SystemInfo.user.LoginID, approverOptionStr, approverResultInt, true))
                                    {
                                        trans.Rollback();
                                        MessageHandler.ShowMessageBox("未查询到当前操作所属的流程节点信息，请在系统里登记模块流程信息。");
                                        return false;
                                    }
                                }

                                cmd.CommandText = string.Format("Update PB_ProductionPlan set CurrentStatus={1} where PlanNo='{0}'", planNoStr, productionPlanTable.Rows[i]["CurrentStatus"]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        productionPlanTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        productionPlanTable.RejectChanges();
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
        /// 取消审批选中的多条工单
        /// </summary>
        public bool CancalPPlanApprovalInfo_Multi(DataTable productionPlanTable)
        {
            string planNoListStr = "";
            for (int i = 0; i < productionPlanTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(productionPlanTable.Rows[i]["Select"]))
                {
                    planNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(productionPlanTable.Rows[i]["PlanNo"]));
                    productionPlanTable.Rows[i]["CurrentStatus"] = 1;
                }
            }

            planNoListStr = planNoListStr.Substring(0, planNoListStr.Length - 1);
            if (!CheckCurrentStatus(productionPlanTable, null, planNoListStr, true, false, false, true, true))
                return false;

            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        cmd.CommandText = string.Format("Delete from PUR_OrderApprovalInfo where OrderHeadNo in ({0})", planNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Update PB_ProductionPlan set CurrentStatus = 1 where PlanNo in ({0})", planNoListStr);
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        DataRow[] productionPlanRows = productionPlanTable.Select("select=1");
                        for (int i = 0; i < productionPlanRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "工单", productionPlanRows[i], "PlanNo", "取消审批", SystemInfo.user.EmpName, BaseSQL.GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss"));
                        }

                        //if (SystemInfo.EnableWorkFlowMessage)
                        {
                            new FrmWorkFlowDataHandleDAO().HandleDataCurrentNode_IsEnd(cmd, planNoListStr, 1, 0);
                        }

                        trans.Commit();
                        productionPlanTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        productionPlanTable.RejectChanges();
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
        /// <param name="planNoStr">工单号</param>
        /// <param name="handleTypeInt">打印处理类型：1 预览 2 打印 3 设计</param>
        public void PrintHandle(string planNoStr, int handleTypeInt)
        {
            DataSet ds = new DataSet();
            DataTable headTable = BaseSQL.GetTableBySql(string.Format("select * from V_Prn_PB_ProductionPlan where PlanNo = '{0}' order by AutoId", planNoStr));
            headTable.TableName = "ProductionPlan";
            for (int i = 0; i < headTable.Columns.Count; i++)
            {
                #region 设定主表显示的标题

                switch (headTable.Columns[i].ColumnName)
                {
                    case "PlanNo":
                        headTable.Columns[i].Caption = "工单号";
                        break;
                    case "CodeNo":
                        headTable.Columns[i].Caption = "物料编号";
                        break;
                    case "CodeFileName":
                        headTable.Columns[i].Caption = "零件编号";
                        break;
                    case "CodeName":
                        headTable.Columns[i].Caption = "零件名称";
                        break;
                    case "CatgName":
                        headTable.Columns[i].Caption = "分类名称";
                        break;
                    case "CatgDescription":
                        headTable.Columns[i].Caption = "分类说明";
                        break;
                    case "CodeSpec":
                        headTable.Columns[i].Caption = "规格型号";
                        break;
                    case "CodeWeight":
                        headTable.Columns[i].Caption = "重量";
                        break;                    
                    case "Brand":
                        headTable.Columns[i].Caption = "品牌";
                        break;
                    case "Unit":
                        headTable.Columns[i].Caption = "单位";
                        break;
                    case "Qty":
                        headTable.Columns[i].Caption = "数量";
                        break;
                    case "ManufactureNo":
                        headTable.Columns[i].Caption = "工程编号";
                        break;
                    case "ManufactureName":
                        headTable.Columns[i].Caption = "工程名称";
                        break;
                    case "ProjectNo":
                        headTable.Columns[i].Caption = "项目号";
                        break;
                    case "ProjectName":
                        headTable.Columns[i].Caption = "项目名称";
                        break;
                    case "Currentdatetime":
                        headTable.Columns[i].Caption = "登记时间";
                        break;                    
                    case "Line":
                        headTable.Columns[i].Caption = "产线名称";
                        break;
                    case "StartTime":
                        headTable.Columns[i].Caption = "计划开始日期";
                        break;
                    case "EndTime":
                        headTable.Columns[i].Caption = "计划结束日期";
                        break;
                    case "PlanStatus":
                        headTable.Columns[i].Caption = "展开状态";
                        break;
                    case "CurrentStatus":
                        headTable.Columns[i].Caption = "单据状态";
                        break;
                    case "CurrentStatusDesc":
                        headTable.Columns[i].Caption = "单据状态描述";
                        break;
                    case "Creator":
                        headTable.Columns[i].Caption = "创建人";
                        break;
                    case "CreatorIp":
                        headTable.Columns[i].Caption = "创建人IP";
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
                    case "Remark":
                        headTable.Columns[i].Caption = "备注";
                        break;
                }

                #endregion
            }
            ds.Tables.Add(headTable);

            DataTable listTable = BaseSQL.GetTableBySql(string.Format("select *, ROW_NUMBER() over (order by AutoId) as RowNum from F_Prn_PB_ProductionPlanList('{0}') Order By AutoString", planNoStr));
            listTable.TableName = "ProductionPlanList";
            for (int i = 0; i < listTable.Columns.Count; i++)
            {
                #region 设定子表显示的标题

                switch (listTable.Columns[i].ColumnName)
                {
                    case "RowNum":
                        listTable.Columns[i].Caption = "行号";
                        break;
                    case "PlanNo":
                        listTable.Columns[i].Caption = "工单号";
                        break;
                    case "CodeNo":
                        listTable.Columns[i].Caption = "物料编号";
                        break;
                    case "CodeFileName":
                        listTable.Columns[i].Caption = "零件编号";
                        break;
                    case "CodeString":
                        listTable.Columns[i].Caption = "零件编号字符串";
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
                    case "Brand":
                        listTable.Columns[i].Caption = "品牌";
                        break;
                    case "Unit":
                        listTable.Columns[i].Caption = "单位";
                        break;
                    case "UnitQty":
                        listTable.Columns[i].Caption = "单位数量";
                        break;
                    case "PlanQty":
                        listTable.Columns[i].Caption = "计划数量";
                        break;
                    case "Qty":
                        listTable.Columns[i].Caption = "实际数量";
                        break;
                }

                #endregion
            }
            ds.Tables.Add(listTable);

            ReportHandler rptHandler = new ReportHandler();
            List<DevExpress.XtraReports.Parameters.Parameter> paralist = rptHandler.GetSystemInfo_ParamList();
            rptHandler.XtraReport_Handle("PB_ProductionPlan", ds, paralist, handleTypeInt);
        }

        /// <summary>
        /// 审批选中的多条工单
        /// </summary>
        public bool PPlanApprovalInfo2_Multi(DataTable productionPlanTable, int nodeIdInt, string flowModuleIdStr, string approverOptionStr, int approverResultInt, ref int successCountInt)
        {
            string planNoListStr = "";
            for (int i = 0; i < productionPlanTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(productionPlanTable.Rows[i]["Select"]))
                {
                    planNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(productionPlanTable.Rows[i]["PlanNo"]));
                }
            }

            planNoListStr = planNoListStr.Substring(0, planNoListStr.Length - 1);
            if (!CheckCurrentStatus(productionPlanTable, null, planNoListStr, true, true, false, false, true))
                return false;
            successCountInt = 0;

            FrmWorkFlowDataHandleDAO wfdhDAO = new FrmWorkFlowDataHandleDAO();
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        DateTime serverTime = BaseSQL.GetServerDateTime();
                        for (int i = 0; i < productionPlanTable.Rows.Count; i++)
                        {
                            if (DataTypeConvert.GetBoolean(productionPlanTable.Rows[i]["Select"]))
                            {
                                DataRow productionPlanRow = productionPlanTable.Rows[i];
                                string planNoStr = DataTypeConvert.GetString(productionPlanRow["PlanNo"]);

                                int reqStateInt = 2;
                                if (!wfdhDAO.HandleWorkFlowData(cmd, planNoStr, "生产流程", "PB_ProductionPlan", "PlanNo", 2, ref reqStateInt, SystemInfo.user.AutoId, SystemInfo.user.LoginID, approverOptionStr, approverResultInt, true))
                                {
                                    trans.Rollback();
                                    return false;
                                }

                                if (approverResultInt == 1)
                                {
                                    productionPlanTable.Rows[i]["CurrentStatus"] = reqStateInt;

                                    //保存日志到日志表中
                                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "生产计划单", productionPlanTable.Rows[i], "PlanNo", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                                else
                                {
                                    wfdhDAO.HandleDataCurrentNode_IsEnd(cmd, "'" + planNoStr + "'", 6, 0);

                                    productionPlanTable.Rows[i]["CurrentStatus"] = 6;

                                    //保存日志到日志表中
                                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "生产计划单", productionPlanTable.Rows[i], "PlanNo", "拒绝审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                }

                                successCountInt++;

                                cmd.CommandText = string.Format("Update PB_ProductionPlan set CurrentStatus={1} where PlanNo='{0}'", planNoStr, productionPlanTable.Rows[i]["CurrentStatus"]);                         
                                cmd.ExecuteNonQuery();                                
                            }
                        }

                        trans.Commit();
                        productionPlanTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        productionPlanTable.RejectChanges();
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
        /// 查询设计Bom的树类型信息
        /// </summary>
        public void QueryDesignBomTree(DataTable queryDataTable, string projectNoStr, int codeIdInt, string commonStr)
        {
            string sqlStr = "";
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and ProjectNo = '{0}'", projectNoStr);
            }
            if(codeIdInt > 0)
            {
                sqlStr += string.Format(" and CodeId = {0}", codeIdInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (CodeName like '%{0}%' or PbBomNo like '%{0}%' or SalesOrderNo like '%{0}%' or CodeFileName like '%{0}%')", commonStr);
            }
            //sqlStr = string.Format("select *, RemainQty - (Select IsNull(SUM(Qty), 0) from PB_ProductionPlan where cast(PB_ProductionPlan.DesignBomListId as varchar(10)) = DBTree.ReId) as OpQty from V_PB_DesignBom_Tree as DBTree where IsUse = 1 and IsMaterial = 1 {0} Order by ReId", sqlStr);
            sqlStr = string.Format("select * from V_PB_DesignBom_Tree as DBTree where IsUse = 1 and IsMaterial = 1 and RemainQty > 0 {0} Order by ReId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询单条设计Bom记录
        /// </summary>
        public DataTable QueryDesignBomList_My(int autoIdInt)
        {
            string sql = string.Format("select PB_DesignBomList.*, CodeName from PB_DesignBomList left join SW_PartsCode on PB_DesignBomList.CodeId = SW_PartsCode.AutoId where PB_DesignBomList.AutoId = {0}", autoIdInt);
            return BaseSQL.Query(sql).Tables[0];
        }

        /// <summary>
        /// 查询下级设计Bom记录
        /// </summary>
        public DataTable QueryDesignBomList_MyLevel(int autoIdInt)
        {
            string sql = string.Format("WITH CTE AS (SELECT c.* FROM PB_DesignBomList c WHERE IsNull(IsMaterial, 1) = 1 and c.AutoId = {0} UNION ALL SELECT a.* FROM PB_DesignBomList a INNER JOIN CTE b ON b.AutoId = a.ParentId where IsNull(a.IsMaterial, 1) = 1) select * from CTE", autoIdInt);
            return BaseSQL.Query(sql).Tables[0];
        }
    }
}
