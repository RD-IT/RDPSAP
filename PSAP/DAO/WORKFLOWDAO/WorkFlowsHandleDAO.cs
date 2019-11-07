using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.WORKFLOWDAO
{
    public class WorkFlowsHandleDAO
    {
        /// <summary>
        /// 单据类型（三个枚举一起新增）
        /// </summary>
        public enum OrderType
        {
            请购单 = 1,
            采购订单 = 2,
            工单 = 3,
        }

        /// <summary>
        /// 查询订单视图名称
        /// </summary>
        public enum QueryOrderViewName
        {
            V_WorkFlows_PUR_PrReqHead = 1,
            V_WorkFlows_PUR_OrderHead = 2,
            V_WorkFlows_PB_ProductionPlan = 3,
        }

        /// <summary>
        /// 查询订单的登记单号列名
        /// </summary>
        public enum QueryOrderPrimaryKey
        {
            PrReqNo = 1,
            OrderHeadNo = 2,
            PlanNo = 3,
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public enum LineType
        {
            删除 = -1,
            保存 = 0,
            提交 = 1,
            取消提交 = 2,
            审批 = 3,
            取消审批 = 4,
            关闭 = 5,
            取消关闭 = 6,
            拒绝 = 7,
            任务分配 = 8,
            取消分配 = 9,
        }

        /// <summary>
        /// 下级工作流类型
        /// </summary>
        public enum NextWorkFlowsType
        {
            请购单 = 1,
            采购订单 = 2,
            工单 = 3,
            入库单 = 4
        }

        /// <summary>
        /// 流程图中节点位置类型
        /// </summary>
        public enum NodePositionType
        {
            中间节点 = 0,
            开始节点 = 1,
            结束节点 = 2,
        }

        /// <summary>
        /// SQL语句中的操作关系
        /// </summary>
        public static string[] OperateRelation = new string[] { "=", ">", "<", ">=", "<=", "<>", "IN", "LIKE"};

        /// <summary>
        /// SQL语句中的逻辑关系
        /// </summary>
        public enum LogicRelation
        {
            并且 = 1,
            或者 = 2,
        }

        /// <summary>
        /// 批量订单工作流处理
        /// </summary>
        /// <param name="orderType">订单类型</param>
        /// <param name="lineType">操作类型</param>
        /// <param name="orderNoDictionary">Key：登记单号 Value：新状态</param>
        /// <returns>是否通过</returns>
        public bool MultiOrderWorkFlowsHandle(SqlCommand cmd, OrderType orderType, LineType lineType, ref Dictionary<string, int> orderNoDictionary)
        {
            return MultiOrderWorkFlowsHandle(cmd, orderType, lineType, "", ref orderNoDictionary);
        }

        /// <summary>
        /// 批量订单工作流处理
        /// </summary>
        /// <param name="orderType">订单类型</param>
        /// <param name="lineType">操作类型</param>
        /// <param name="approverOptionStr">审批意见</param>
        /// <param name="orderNoDictionary">Key：登记单号 Value：新状态</param>
        /// <returns>是否通过</returns>
        public bool MultiOrderWorkFlowsHandle(SqlCommand cmd, OrderType orderType, LineType lineType, string approverOptionStr, ref Dictionary<string, int> orderNoDictionary)
        {
            String[] keyStrs = new String[orderNoDictionary.Keys.Count];
            orderNoDictionary.Keys.CopyTo(keyStrs, 0);
            for (int i = 0; i < keyStrs.Length; i++)
            {
                int resultInt = OrderWorkFlowsHandle(cmd, orderType, lineType, keyStrs[i], approverOptionStr);
                if (resultInt > 0)
                    orderNoDictionary[keyStrs[i]] = resultInt;
                else if (resultInt < 0)
                {
                    cmd.CommandText = keyStrs[i];
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 订单工作流处理
        /// </summary>
        /// <param name="orderType">订单类型  请购单 = 1，采购订单 = 2，工单 = 3,</param>
        /// <param name="lineType">操作类型删除 = -1，保存 = 0，提交 = 1，取消提交 = 2，审批 = 3，取消审批 = 4，关闭 = 5，取消关闭 = 6，拒绝 = 7，任务分配 = 8，取消分配 = 9</param>
        /// <param name="orderNoStr">登记单号</param>
        /// <param name="approverOptionStr">审批意见</param>
        /// <returns>返回结果状态（ -1：未通过，取消当前操作； 0：正常通过； >0：正常通过返回新的状态编号；）</returns>
        public int OrderWorkFlowsHandle(SqlCommand cmd, OrderType orderType, LineType lineType, string orderNoStr, string approverOptionStr)
        {
            cmd.CommandText = string.Format("Select AutoId from BS_WorkFlows where WorkFlowsType = {0} and IsNull(Enabled, 0) = 1", (int)orderType);
            DataTable workFlowsTable = BaseSQL.GetTableBySql(cmd);
            if (workFlowsTable.Rows.Count == 0)
                return 0;
            int workFlowsIdInt = DataTypeConvert.GetInt(workFlowsTable.Rows[0]["AutoId"]);

            int operationAfterOrderStatus = (int)CommonHandler.OrderState.待提交;
            int approverLevelInt = 1;
            int isEndInt = 0;

            switch (lineType)
            {
                case LineType.删除:
                    cmd.CommandText = string.Format("Delete from BS_WorkFlowsDataCurrentNode where DataNo = '{0}'", orderNoStr);
                    cmd.ExecuteNonQuery();
                    return 0;
                case LineType.保存:
                    operationAfterOrderStatus = (int)CommonHandler.OrderState.待提交;
                    cmd.CommandText = string.Format("Select AutoId from BS_WorkFlowsNode where WorkFlowsId = {0} and IsNull(BeginNode, 0) = 1", workFlowsIdInt);
                    int autoIdInt_BeginNode = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                    if (autoIdInt_BeginNode > 0)
                    {
                        Update_WorkFlowsDataCurrentNode(cmd, orderNoStr, autoIdInt_BeginNode, operationAfterOrderStatus, approverLevelInt, isEndInt);
                    }
                    return 0;
                case LineType.提交:
                    operationAfterOrderStatus = (int)CommonHandler.OrderState.审批中;

                    break;
                case LineType.取消提交:
                    operationAfterOrderStatus = (int)CommonHandler.OrderState.待提交;

                    break;
                case LineType.审批:
                    operationAfterOrderStatus = (int)CommonHandler.OrderState.已审批;

                    break;
                case LineType.取消审批:
                    operationAfterOrderStatus = (int)CommonHandler.OrderState.待提交;

                    break;
                case LineType.关闭:
                    operationAfterOrderStatus = (int)CommonHandler.OrderState.已关闭;

                    break;
                case LineType.取消关闭:
                    operationAfterOrderStatus = (int)CommonHandler.OrderState.待提交;

                    break;
                case LineType.拒绝:
                    operationAfterOrderStatus = (int)CommonHandler.OrderState.待提交;

                    break;
                case LineType.任务分配:
                    operationAfterOrderStatus = (int)CommonHandler.OrderState.已审批;

                    break;
                case LineType.取消分配:
                    operationAfterOrderStatus = (int)CommonHandler.OrderState.已审批;

                    break;
            }

            //查询当前操作所属的连接线信息
            cmd.CommandText = string.Format("select line.*, IsNull(ApproverLevel, 1) as ApproverLevel from BS_WorkFlowsLine as line left join BS_WorkFlowsDataCurrentNode on BS_WorkFlowsDataCurrentNode.CurrentNodeId = line.NodeId where line.WorkFlowsId = {0} and line.LineType = {1} and DataNo = '{2}'", workFlowsIdInt, (int)lineType, orderNoStr);
            DataTable lineTable = BaseSQL.GetTableBySql(cmd);
            if (lineTable.Rows.Count == 0)
            {
                cmd.CommandText = string.Format("select line.*, 1 as ApproverLevel from BS_WorkFlowsLine as line where line.WorkFlowsId = {0} and line.LineType = {1}", workFlowsIdInt, (int)lineType);
                lineTable = BaseSQL.GetTableBySql(cmd);
            }
            if (lineTable.Rows.Count == 0)
                return 0;

            int lineIdInt = DataTypeConvert.GetInt(lineTable.Rows[0]["AutoId"]);
            int nodeIdInt_Current = DataTypeConvert.GetInt(lineTable.Rows[0]["NodeId"]);
            int nodeIdInt_Next = DataTypeConvert.GetInt(lineTable.Rows[0]["LevelNodeId"]);
            switch (lineType)
            {
                case LineType.审批://采用多级操作
                    approverLevelInt = DataTypeConvert.GetInt(lineTable.Rows[0]["ApproverLevel"]);
                    break;
                default:
                    approverLevelInt = 1;
                    break;
            }

            //查询流程图连接线下个状态节点信息，来判断是否结束标志等
            cmd.CommandText = string.Format("select * from BS_WorkFlowsNode where AutoId = {0}", nodeIdInt_Next);
            DataTable nextNodeTable = BaseSQL.GetTableBySql(cmd);
            if (nextNodeTable.Rows.Count > 0)
            {
                int beginNodeInt = DataTypeConvert.GetInt(nextNodeTable.Rows[0]["BeginNode"]);
                int nodeEnabledInt = DataTypeConvert.GetInt(nextNodeTable.Rows[0]["Enabled"]);
                if (beginNodeInt == (int)NodePositionType.结束节点)
                    isEndInt = 1;
                else
                {
                    cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsLine where NodeId = {0} and LevelNodeId in (select AutoId from BS_WorkFlowsNode where IsNull(BeginNode, 0) = 2 and ISNULL(Enabled, 0) = 0)", nodeIdInt_Next);
                    if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                        isEndInt = 1;
                }

                if (nodeEnabledInt == 0)
                {
                    switch (lineType)
                    {
                        case LineType.关闭:
                            cmd.Transaction.Rollback();
                            MessageHandler.ShowMessageBox("关闭状态已经在流程图中停用，关闭操作取消。");
                            return -1;
                        case LineType.提交:
                            cmd.CommandText = string.Format("Select AutoId, BeginNode from BS_WorkFlowsNode where WorkFlowsId = {0} and AutoId in (Select LevelNodeId from BS_WorkFlowsLine where LineType = {1})", workFlowsIdInt, (int)LineType.审批);
                            DataTable approveNodeTable = BaseSQL.GetTableBySql(cmd);
                            if (approveNodeTable.Rows.Count > 0)
                            {
                                operationAfterOrderStatus = (int)CommonHandler.OrderState.已审批;
                                nodeIdInt_Next = DataTypeConvert.GetInt(approveNodeTable.Rows[0]["AutoId"]);
                                if (DataTypeConvert.GetInt(approveNodeTable.Rows[0]["BeginNode"]) == (int)NodePositionType.结束节点)
                                {
                                    isEndInt = 1;
                                }
                                else
                                {
                                    cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsLine where NodeId = {0} and LevelNodeId in (select AutoId from BS_WorkFlowsNode where IsNull(BeginNode, 0) = 2 and ISNULL(Enabled, 0) = 0)", nodeIdInt_Next);
                                    if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                                        isEndInt = 1;
                                }
                            }
                            break;
                    }
                }
            }

            if (DataTypeConvert.GetInt(lineTable.Rows[0]["Enabled"]) == 1)
            {
                WorkFlowsHandleDAO.QueryOrderViewName viewName = (WorkFlowsHandleDAO.QueryOrderViewName)((int)orderType);
                WorkFlowsHandleDAO.QueryOrderPrimaryKey primaryKey = (WorkFlowsHandleDAO.QueryOrderPrimaryKey)((int)orderType);

                cmd.CommandText = string.Format("Select AutoId, Condition, ConditionText from BS_WorkFlowsLineCondition where LineId = {0}", lineIdInt);
                DataTable conditionTable = BaseSQL.GetTableBySql(cmd);
                for (int i = 0; i < conditionTable.Rows.Count; i++)
                {
                    string tempStr = DataHandler.SQLStringReplaceHandle(DataTypeConvert.GetString(conditionTable.Rows[i]["Condition"]));
                    if (tempStr == "")
                        tempStr = " 1=1";

                    cmd.CommandText = string.Format("Select Count(*) from {0} where {1} = '{2}' and ({3})", viewName, primaryKey, orderNoStr, tempStr);
                    if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                    {
                        int conditionIdInt = DataTypeConvert.GetInt(conditionTable.Rows[i]["AutoId"]);
                        cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsLineHandle where LineId = {0} and ConditionId = {1} and MultiLevelApprover = {2} and ((LineHandleCate = 0 and HandleOwner = '{3}') or (LineHandleCate = 1 and HandleOwner = '{4}'))", lineIdInt, conditionIdInt, approverLevelInt, SystemInfo.user.LoginID, SystemInfo.user.RoleNo);
                        if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                        {
                            switch (lineType)
                            {
                                case LineType.审批://采用多级操作

                                    approverLevelInt++;
                                    cmd.CommandText = string.Format("select COUNT(*) from BS_WorkFlowsLineHandle where LineId = {0} and ConditionId = {1} and MultiLevelApprover ={2}", lineIdInt, conditionIdInt, approverLevelInt);
                                    if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                                    {
                                        operationAfterOrderStatus = (int)CommonHandler.OrderState.审批中;
                                        nodeIdInt_Next = nodeIdInt_Current;
                                        isEndInt = 0;
                                    }
                                    else
                                    {
                                        approverLevelInt = 1;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            cmd.Transaction.Rollback();
                            MessageHandler.ShowMessageBox(string.Format("您没有操作登记单[{0}]的[{1}]权限，请联系管理员调整权限后再进行操作。", orderNoStr, lineType));
                            return -1;
                        }

                        break;
                    }
                }
            }

            Update_WorkFlowsDataCurrentNode(cmd, orderNoStr, nodeIdInt_Next, operationAfterOrderStatus, approverLevelInt, isEndInt);
            Insert_WorkFlowsDataHandle(cmd, orderNoStr, lineType, SystemInfo.user.AutoId, approverOptionStr);


            //if ((int)orderType == 20)
            //{
            //    cmd.Transaction.Rollback();
            //    MessageHandler.ShowMessageBox("提示");                
            //    return -1;
            //}

            return operationAfterOrderStatus;
        }

        /// <summary>
        /// 更新登记单流程图所在的节点信息
        /// </summary>
        /// <param name="orderNoStr">登记单号</param>
        /// <param name="currentNodeIdInt">所在的状态节点</param>
        /// <param name="currentStateInt">登记单当前的状态</param>
        /// <param name="approverLevelInt">审批级别</param>
        /// <param name="isEndInt">结束标志</param>
        private void Update_WorkFlowsDataCurrentNode(SqlCommand cmd, string orderNoStr, int currentNodeIdInt, int currentStateInt, int approverLevelInt, int isEndInt)
        {
            cmd.CommandText = string.Format("Update BS_WorkFlowsDataCurrentNode set CurrentNodeId = {1}, CurrentState = {2}, ApproverLevel = {3}, IsEnd = {4}, NextHandleEnd = 0 where DataNo = '{0}'", orderNoStr, currentNodeIdInt, currentStateInt, approverLevelInt, isEndInt);
            if (cmd.ExecuteNonQuery() == 0)
            {
                cmd.CommandText = string.Format("Insert into BS_WorkFlowsDataCurrentNode(DataNo, CurrentNodeId, CurrentState, ApproverLevel, IsEnd) values ('{0}', {1}, {2}, {3}, {4})", orderNoStr, currentNodeIdInt, currentStateInt, approverLevelInt, isEndInt);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 新增登记单流程处理记录
        /// </summary>
        /// <param name="orderNoStr">登记单号</param>
        /// <param name="lineType">操作类型</param>
        /// <param name="operatorInt">操作人员</param>
        /// <param name="handleOptionStr">日志说明</param>
        private void Insert_WorkFlowsDataHandle(SqlCommand cmd, string orderNoStr, LineType lineType, int operatorInt, string handleOptionStr)
        {
            //switch(lineType)
            //{
            //    case LineType.删除:
            //    case LineType.保存:

            //        break;
            //    default:
            cmd.CommandText = string.Format("Insert into BS_WorkFlowsDataHandle(DataNo, Operator, LineType, HandleOption, HandleTime) values ('{0}', {1}, {2}, '{3}', GETDATE())", orderNoStr, operatorInt, (int)lineType, handleOptionStr);
            cmd.ExecuteNonQuery();
            //        break;
            //}
        }

        /// <summary>
        /// 查询用户的工作流信息列表
        /// </summary>
        /// <param name="queryDataTable">要填充的数据表</param>
        public void QueryUserWorkFlows_Table(DataTable queryDataTable)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("select * from F_QueryUserWorkFlows_Internal('{0}', '{1}')", SystemInfo.user.LoginID, SystemInfo.user.RoleNo);
                        DataTable wfInternalTable = BaseSQL.GetTableBySql(cmd);

                        DataTable wfTypeInternalTable = wfInternalTable.DefaultView.ToTable(true, "WorkFlowsType", "LineId", "LineType");
                        foreach (DataRow wfTypeRow in wfTypeInternalTable.Rows)
                        {
                            int workFlowsTypeInt = DataTypeConvert.GetInt(wfTypeRow["WorkFlowsType"]);
                            int lineIdInt = DataTypeConvert.GetInt(wfTypeRow["LineId"]);
                            int lineTypeInt = DataTypeConvert.GetInt(wfTypeRow["lineType"]);
                            WorkFlowsHandleDAO.QueryOrderViewName viewName = (WorkFlowsHandleDAO.QueryOrderViewName)workFlowsTypeInt;
                            WorkFlowsHandleDAO.QueryOrderPrimaryKey primaryKey = (WorkFlowsHandleDAO.QueryOrderPrimaryKey)workFlowsTypeInt;
                            DataRow[] userWFRows = wfInternalTable.Select(string.Format("WorkFlowsType = {0} and LineId = {1} and LineType = {2}", workFlowsTypeInt, lineIdInt, lineTypeInt));
                            string sqlStr = "";
                            int approverInt = 1;
                            switch (lineTypeInt)
                            {
                                case (int)LineType.审批:
                                    approverInt = -1;
                                    break;
                            }

                            foreach (DataRow userRow in userWFRows)
                            {
                                string tempStr = DataHandler.SQLStringReplaceHandle(DataTypeConvert.GetString(userRow["Condition"]));
                                if (tempStr == "")
                                {
                                    tempStr = " 1=1";
                                }

                                sqlStr += string.Format("select curNode.*,{0} as WorkFlowsType,{1} as LineType,{2} as LevelNodeId,{0} as NextType from BS_WorkFlowsDataCurrentNode as curNode where ISNULL(IsEnd,0)=0 and DataNo in (select {3} from {4} where {5}) and CurrentNodeId in (select NodeId from BS_WorkFlowsLine where AutoId = {6}) and (ApproverLevel={7} or {8}={7}) Union All ", workFlowsTypeInt, lineTypeInt, userRow["LevelNodeId"], primaryKey, viewName, tempStr, userRow["LineId"], userRow["MultiLevelApprover"], approverInt);
                            }
                            if (sqlStr.Length > 10)
                            {
                                cmd.CommandText = sqlStr.Substring(0, sqlStr.Length - 10);
                                SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                                adapterList.Fill(queryDataTable);
                            }
                        }

                        string whereSqlStr_Between = "";
                        cmd.CommandText = string.Format("select * from F_QueryUserWorkFlows_Between('{0}', '{1}')", SystemInfo.user.LoginID, SystemInfo.user.RoleNo);
                        DataTable wfBetweenTable = BaseSQL.GetTableBySql(cmd);
                        foreach (DataRow wfTypeRow in wfBetweenTable.Rows)
                        {
                            int workFlowsTypeInt = DataTypeConvert.GetInt(wfTypeRow["WorkFlowsType"]);
                            int nextWorkFlowsTypeInt = DataTypeConvert.GetInt(wfTypeRow["NextWorkFlowsType"]);
                            //int lineType = DataTypeConvert.GetInt(wfTypeRow["LineType"]);
                            //lineType = lineType == 1 ? 0 : lineType;
                            int lineType = 0;
                            WorkFlowsHandleDAO.QueryOrderViewName viewName = (WorkFlowsHandleDAO.QueryOrderViewName)workFlowsTypeInt;
                            WorkFlowsHandleDAO.QueryOrderPrimaryKey primaryKey = (WorkFlowsHandleDAO.QueryOrderPrimaryKey)workFlowsTypeInt;
                            string tempStr = DataHandler.SQLStringReplaceHandle(DataTypeConvert.GetString(wfTypeRow["Condition"]));
                            if (tempStr == "")
                            {
                                tempStr = " 1=1";
                            }
                            whereSqlStr_Between += string.Format("select curNode.*,{0} as WorkFlowsType,{1} as LineType,{2} as LevelNodeId,{3} as NextType from BS_WorkFlowsDataCurrentNode as curNode where ISNULL(IsEnd,0)=1 and ISNULL(NextHandleEnd,0)=0 and DataNo in (select {4} from {5} where {6}) Union All ", workFlowsTypeInt, lineType, -1, nextWorkFlowsTypeInt, primaryKey, viewName, tempStr);
                        }

                        if (whereSqlStr_Between.Length > 10)
                        {
                            cmd.CommandText = whereSqlStr_Between.Substring(0, whereSqlStr_Between.Length - 10);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(queryDataTable);
                        }

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
        /// 查询用户的工作流信息数量
        /// </summary>
        public int QueryUserWorkFlows_Count()
        {
            DataTable userWorkFlowsTable = new DataTable();
            QueryUserWorkFlows_Table(userWorkFlowsTable);
            DataTable wfTypeTable = userWorkFlowsTable.DefaultView.ToTable(true, "DataNo");
            return wfTypeTable.Rows.Count;

            //using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            //{
            //    conn.Open();
            //    using (SqlTransaction trans = conn.BeginTransaction())
            //    {
            //        try
            //        {
            //            SqlCommand cmd = new SqlCommand("", conn, trans);

            //            cmd.CommandText = string.Format("select * from F_QueryUserWorkFlows_Internal('{0}', '{1}')", SystemInfo.user.LoginID, SystemInfo.user.RoleNo);
            //            DataTable userWFTable = BaseSQL.GetTableBySql(cmd);

            //            cmd.CommandText = string.Format("select WorkFlowsType from F_QueryUserWorkFlows_Internal('{0}', '{1}') group by WorkFlowsType", SystemInfo.user.LoginID, SystemInfo.user.RoleNo);
            //            DataTable wfTypeTable = BaseSQL.GetTableBySql(cmd);
            //            int sumCount = 0;
            //            foreach (DataRow wfTypeRow in wfTypeTable.Rows)
            //            {
            //                int workFlowsType = DataTypeConvert.GetInt(wfTypeRow["WorkFlowsType"]);
            //                WorkFlowsHandleDAO.OrderType orderType = (WorkFlowsHandleDAO.OrderType)workFlowsType;
            //                WorkFlowsHandleDAO.QueryOrderViewName viewName = (WorkFlowsHandleDAO.QueryOrderViewName)workFlowsType;
            //                WorkFlowsHandleDAO.QueryOrderPrimaryKey primaryKey = (WorkFlowsHandleDAO.QueryOrderPrimaryKey)workFlowsType;
            //                DataRow[] userWFRows = userWFTable.Select(string.Format("WorkFlowsType = {0}", workFlowsType));
            //                string whereSqlStr = "";
            //                foreach (DataRow userRow in userWFRows)
            //                {
            //                    string tempStr = DataHandler.SQLStringReplaceHandle(DataTypeConvert.GetString(userRow["Condition"]));
            //                    if (tempStr == "")
            //                    {
            //                        tempStr = " 1=1";
            //                    }

            //                    whereSqlStr += string.Format("or (DataNo in (select {0} from {1} where 1=1 and ({2})))", primaryKey, viewName, tempStr, userRow["MultiLevelApprover"]);
            //                }
            //                cmd.CommandText = string.Format("select Count(*) from BS_WorkFlowsDataCurrentNode where ISNULL(IsEnd,0)=0 and (1=2 {0})", whereSqlStr);

            //                sumCount += DataTypeConvert.GetInt(cmd.ExecuteScalar());
            //            }

            //            trans.Commit();

            //            return sumCount;
            //        }
            //        catch (Exception ex)
            //        {
            //            trans.Rollback();
            //            throw ex;
            //        }
            //        finally
            //        {
            //            conn.Close();
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 更新当前登记单流程处理状态的下级流程图处理结束标志
        /// </summary>
        /// <param name="dataNoStr">登记单号</param>
        /// <param name="nextType">下级流程图类型</param>
        public void Update_WorkFlowsDataCurrentNode_NextHandleEnd(SqlCommand cmd, string dataNoStr, WorkFlowsHandleDAO.NextWorkFlowsType nextType)
        {
            switch (nextType)
            {
                case NextWorkFlowsType.采购订单:
                    cmd.CommandText = string.Format("Update BS_WorkFlowsDataCurrentNode set NextHandleEnd = (select IsEnd from PUR_PrReqHead where PrReqNo = '{0}') where DataNo = '{0}'", dataNoStr);
                    break;
                case NextWorkFlowsType.入库单:
                    cmd.CommandText = string.Format("Update BS_WorkFlowsDataCurrentNode set NextHandleEnd = (select IsEnd from PUR_OrderHead where OrderHeadNo = '{0}') where DataNo = '{0}'", dataNoStr);
                    break;
            }

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 查询流程图连接线下级状态节点是否停用
        /// </summary>
        /// <param name="orderType">订单类型  请购单 = 1，采购订单 = 2，工单 = 3,</param>
        /// <param name="lineType">操作类型删除 = -1，保存 = 0，提交 = 1，取消提交 = 2，审批 = 3，取消审批 = 4，关闭 = 5，取消关闭 = 6，拒绝 = 7，任务分配 = 8，取消分配 = 9</param>
        public bool QueryWorkFlowsLineNextNodeIsEnabled(OrderType orderType, LineType lineType)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("select * from BS_WorkFlowsLine where WorkFlowsId in (select AutoId from BS_WorkFlows where Enabled = 1 and WorkFlowsType = {0}) and LineType = {1}", (int)orderType, (int)lineType);
                        DataTable workFlowsTable = BaseSQL.GetTableBySql(cmd);
                        DataTable lineTable = BaseSQL.GetTableBySql(cmd);
                        if (lineTable.Rows.Count > 0)
                        {
                            int nodeIdInt_Next = DataTypeConvert.GetInt(lineTable.Rows[0]["LevelNodeId"]);

                            cmd.CommandText = string.Format("select Enabled from BS_WorkFlowsNode where AutoId = {0}", nodeIdInt_Next);
                            DataTable nextNodeTable = BaseSQL.GetTableBySql(cmd);
                            if (nextNodeTable.Rows.Count > 0)
                            {
                                int nodeEnabledInt = DataTypeConvert.GetInt(nextNodeTable.Rows[0]["Enabled"]);
                                switch (lineType)
                                {
                                    case LineType.提交:
                                        if (nodeEnabledInt == 0)
                                        {
                                            return false;
                                        }
                                        break;
                                }
                            }
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
        /// 批量订单流程图是否有权限
        /// </summary>
        /// <param name="orderType">订单类型</param>
        /// <param name="lineType">操作类型</param>
        /// <param name="orderNoDictionary">登记单号列表</param>
        public bool MultiOrderWorkFlowsIsPower(OrderType orderType, LineType lineType, List<string> orderNoDictionary)
        {
            for (int i = 0; i < orderNoDictionary.Count; i++)
            {
                int resultInt = OrderWorkFlowsIsPower(orderType, lineType, orderNoDictionary[i]);
                if (resultInt < 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 订单流程图是否有权限
        /// </summary>
        /// <param name="orderType">订单类型</param>
        /// <param name="lineType">操作类型</param>
        /// <param name="orderNoDictionary">登记单号</param>
        private int OrderWorkFlowsIsPower(OrderType orderType, LineType lineType, string orderNoStr)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("Select AutoId, Enabled from BS_WorkFlows where WorkFlowsType = {0}", (int)orderType);
                        DataTable workFlowsTable = BaseSQL.GetTableBySql(cmd);
                        if (workFlowsTable.Rows.Count == 0)
                            return 0;
                        else if (DataTypeConvert.GetInt(workFlowsTable.Rows[0]["Enabled"]) != 1)
                            return 0;
                        int workFlowsIdInt = DataTypeConvert.GetInt(workFlowsTable.Rows[0]["AutoId"]);

                        int approverLevelInt = 1;                       

                        //查询当前操作所属的连接线信息
                        cmd.CommandText = string.Format("select line.*, IsNull(ApproverLevel, 1) as ApproverLevel from BS_WorkFlowsLine as line left join BS_WorkFlowsDataCurrentNode on BS_WorkFlowsDataCurrentNode.CurrentNodeId = line.NodeId where line.WorkFlowsId = {0} and line.LineType = {1} and DataNo = '{2}'", workFlowsIdInt, (int)lineType, orderNoStr);
                        DataTable lineTable = BaseSQL.GetTableBySql(cmd);
                        if (lineTable.Rows.Count == 0)
                        {
                            cmd.CommandText = string.Format("select line.*, 1 as ApproverLevel from BS_WorkFlowsLine as line where line.WorkFlowsId = {0} and line.LineType = {1}", workFlowsIdInt, (int)lineType);
                            lineTable = BaseSQL.GetTableBySql(cmd);
                        }
                        if (lineTable.Rows.Count == 0)
                            return 0;

                        int lineIdInt = DataTypeConvert.GetInt(lineTable.Rows[0]["AutoId"]);
                        switch (lineType)
                        {
                            case LineType.审批://采用多级操作
                                approverLevelInt = DataTypeConvert.GetInt(lineTable.Rows[0]["ApproverLevel"]);
                                break;
                            default:
                                approverLevelInt = 1;
                                break;
                        }

                        int enabledInt = DataTypeConvert.GetInt(lineTable.Rows[0]["Enabled"]);
                        if (enabledInt == 1)
                        {
                            WorkFlowsHandleDAO.QueryOrderViewName viewName = (WorkFlowsHandleDAO.QueryOrderViewName)((int)orderType);
                            WorkFlowsHandleDAO.QueryOrderPrimaryKey primaryKey = (WorkFlowsHandleDAO.QueryOrderPrimaryKey)((int)orderType);

                            cmd.CommandText = string.Format("Select AutoId, Condition, ConditionText from BS_WorkFlowsLineCondition where LineId = {0}", lineIdInt);
                            DataTable conditionTable = BaseSQL.GetTableBySql(cmd);
                            for (int i = 0; i < conditionTable.Rows.Count; i++)
                            {
                                string tempStr = DataHandler.SQLStringReplaceHandle(DataTypeConvert.GetString(conditionTable.Rows[i]["Condition"]));
                                if (tempStr == "")
                                    tempStr = " 1=1";

                                cmd.CommandText = string.Format("Select Count(*) from {0} where {1} = '{2}' and ({3})", viewName, primaryKey, orderNoStr, tempStr);
                                if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                                {
                                    int conditionIdInt = DataTypeConvert.GetInt(conditionTable.Rows[i]["AutoId"]);
                                    cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsLineHandle where LineId = {0} and ConditionId = {1} and MultiLevelApprover = {2} and ((LineHandleCate = 0 and HandleOwner = '{3}') or (LineHandleCate = 1 and HandleOwner = '{4}'))", lineIdInt, conditionIdInt, approverLevelInt, SystemInfo.user.LoginID, SystemInfo.user.RoleNo);
                                    if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                                    {

                                    }
                                    else
                                    {
                                        cmd.Transaction.Rollback();
                                        return -1;
                                    }
                                    break;
                                }
                            }
                        }

                        trans.Commit();
                        return 1;
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
        /// 查询流程图定义的条件字符串
        /// </summary>
        /// <param name="orderType">订单类型</param>
        /// <param name="approverInt">审批人</param>
        public string GetWorkFlowsLine_OrderQuerySQL(WorkFlowsHandleDAO.OrderType orderType, int approverInt)
        {
            string sqlStr = string.Format("Select AutoId from BS_WorkFlows where WorkFlowsType = {0} and IsNull(Enabled, 0) = 1", (int)orderType);
            DataTable workFlowsTable = BaseSQL.GetTableBySql(sqlStr);
            if (workFlowsTable.Rows.Count == 0)
                return "";
            int workFlowsIdInt = DataTypeConvert.GetInt(workFlowsTable.Rows[0]["AutoId"]);

            sqlStr = string.Format("select AutoId, Enabled from BS_WorkFlowsLine where WorkFlowsId = {0} and LineType = {1}", workFlowsIdInt, (int)WorkFlowsHandleDAO.LineType.审批);
            DataTable lineTable = BaseSQL.GetTableBySql(sqlStr);
            if (lineTable.Rows.Count == 0)
                return "";

            if (DataTypeConvert.GetInt(lineTable.Rows[0]["Enabled"]) == 1)
            {
                int lineIdInt = DataTypeConvert.GetInt(lineTable.Rows[0]["AutoId"]);

                string loginIdStr = "";
                string roleNoStr = "";
                QueryUserInfo_LoginIdAndRoleNo(approverInt, ref loginIdStr, ref roleNoStr);

                sqlStr = string.Format("select MultiLevelApprover, Condition from BS_WorkFlowsLineHandle as wfHandle join BS_WorkFlowsLineCondition as cond on wfHandle.ConditionId = cond.AutoId where wfHandle.LineId = {0} and ((LineHandleCate = 0 and HandleOwner = '{1}') or (LineHandleCate = 1 and HandleOwner = '{2}'))", lineIdInt, loginIdStr, roleNoStr);
                DataTable wfHandleTable = BaseSQL.GetTableBySql(sqlStr);

                WorkFlowsHandleDAO.QueryOrderViewName viewName = (WorkFlowsHandleDAO.QueryOrderViewName)orderType;
                WorkFlowsHandleDAO.QueryOrderPrimaryKey primaryKey = (WorkFlowsHandleDAO.QueryOrderPrimaryKey)orderType;
                sqlStr = "";
                foreach (DataRow conditonRow in wfHandleTable.Rows)
                {
                    string tempStr = DataHandler.SQLStringReplaceHandle(DataTypeConvert.GetString(conditonRow["Condition"]));
                    if (tempStr == "")
                    {
                        tempStr = " 1=1";
                    }
                    sqlStr += string.Format("select * from {0} where {1} and {2} in (select DataNo from BS_WorkFlowsDataCurrentNode as curNode where ISNULL(IsEnd,0)= 0 and CurrentNodeId in (select NodeId from BS_WorkFlowsLine where AutoId = {3}) and ApproverLevel ={4}) Union ", viewName, tempStr, primaryKey, lineIdInt, conditonRow["MultiLevelApprover"]);
                }
                if (sqlStr.Length > 6)
                    return sqlStr.Substring(0, sqlStr.Length - 6);
                else
                    return string.Format("Select * from {0} where 1=2", viewName);
            }
            else
                return "";
        }

        /// <summary>
        /// 查询审批人的登陆号和角色名
        /// </summary>
        /// <param name="approverInt">审批人的AutoId</param>
        /// <param name="loginIdStr">返回审批人的登陆号</param>
        /// <param name="roleNoStr">返回审批人的角色名</param>
        private void QueryUserInfo_LoginIdAndRoleNo(int approverInt, ref string loginIdStr, ref string roleNoStr)
        {
            string tmpSql = string.Format("select LoginId, RoleNo from BS_UserInfo left join BS_RoleUser on BS_RoleUser.UserNo = BS_UserInfo.AutoId where BS_UserInfo.AutoId = {0}", approverInt);
            DataTable userTable;
            userTable = BaseSQL.GetTableBySql(tmpSql);

            if (userTable.Rows.Count == 0)
            {
                throw new Exception("未查询到审批人的信息，请重新操作。");
            }
            loginIdStr = DataTypeConvert.GetString(userTable.Rows[0]["LoginId"]);
            roleNoStr = DataTypeConvert.GetString(userTable.Rows[0]["RoleNo"]);
        }

    }
}
