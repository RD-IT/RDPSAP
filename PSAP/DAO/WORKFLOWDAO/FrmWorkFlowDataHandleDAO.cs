using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.WORKFLOWDAO
{
    class FrmWorkFlowDataHandleDAO
    {
        /// <summary>
        /// 查询节点信息
        /// </summary>
        public DataTable QueryWorkFlowNode()
        {
            string sqlStr = "select AutoId, NodeText from BS_WorkFlowNode";
            return BaseSQL.Query(sqlStr).Tables[0];
        }

        /// <summary>
        /// 新增数据流处理记录
        /// </summary>
        /// <param name="orderNoList">单据号列表</param>
        /// <param name="WorkFlowTypeText">流程类型名称  销售流程，采购流程，库存流程，人事流程</param>
        /// <param name="tableNameStr">数据表名称</param>
        /// <param name="moduleTypeInt">模块类型编号  1 登记 2 审批</param>
        /// <param name="stateInt">单据状态</param>
        /// <param name="approverStr">审批人</param>
        /// <param name="approverOptionStr">审批意见</param>
        /// <param name="approverResultInt">审批结果 1 同意 0 不同意</param>
        /// <param name="allNewDataHandle">全部新增单据处理记录</param>
        public bool InsertWorkFlowDataHandle(SqlCommand cmd, List<string> orderNoList, string WorkFlowTypeText, string tableNameStr, int moduleTypeInt, int stateInt, string approverStr, string approverOptionStr, int approverResultInt, bool allNewDataHandle)
        {
            DataTable wfNodeTable = ModuleGetWorkFlowNode(cmd, WorkFlowTypeText, tableNameStr, moduleTypeInt);
            if (wfNodeTable.Rows.Count == 0)
                return false;

            string flowModuleIdStr = DataTypeConvert.GetString(wfNodeTable.Rows[0]["FlowModuleId"]);
            int nodeIdInt = DataTypeConvert.GetInt(wfNodeTable.Rows[0]["AutoId"]);

            return InsertWorkFlowDataHandle(cmd, orderNoList, flowModuleIdStr, nodeIdInt, stateInt, approverStr, approverOptionStr, approverResultInt, allNewDataHandle);
        }
        public bool InsertWorkFlowDataHandle(SqlCommand cmd, List<string> orderNoList, string flowModuleIdStr, int nodeIdInt, int stateInt, string approverStr, string approverOptionStr, int approverResultInt, bool allNewDataHandle)
        {
            foreach (string orderNo in orderNoList)
            {
                cmd.CommandText = string.Format("Select Count(*) from BS_DataCurrentNode where DataNo = '{0}'", orderNo);
                if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) == 0)//新增
                {
                    cmd.CommandText = string.Format("Insert into BS_DataCurrentNode (DataNo, FlowModuleId, CurrentNodeId, currentState, isEnd) values ('{0}', '{1}', {2}, {3}, 0)", orderNo, flowModuleIdStr, nodeIdInt, stateInt);
                    cmd.ExecuteNonQuery();
                }
                else//修改
                {
                    cmd.CommandText = string.Format("update BS_DataCurrentNode set FlowModuleId = '{1}', CurrentNodeId = {2}, currentState = {3} where DataNo = '{0}'", orderNo, flowModuleIdStr, nodeIdInt, stateInt);
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = string.Format("update BS_DataCurrentNode set isEnd = (case BS_WorkFlowNode.NodeCate when 3 then 1 else 0 end) from BS_DataCurrentNode left join BS_WorkFlowNode on BS_DataCurrentNode.CurrentNodeId = BS_WorkFlowNode.AutoId where DataNo = '{0}'", orderNo);
                cmd.ExecuteNonQuery();

                int count = 0;
                int autoIdInt = 0;
                if (!allNewDataHandle)
                {
                    //cmd.CommandText = string.Format("select top 1 AutoId from BS_WorkFlowDataHandle where DataNo = '{0}' and NodeId = '{1}' and Approver = '{2}' order by AutoId desc", orderNo, nodeIdInt, approverStr);
                    cmd.CommandText = string.Format("select top 1 AutoId from BS_WorkFlowDataHandle where DataNo = '{0}' and NodeId = '{1}' and ApproverResult = {2} order by AutoId desc", orderNo, nodeIdInt, approverResultInt);
                    DataTable tempTable = BaseSQL.GetTableBySql(cmd);

                    count = tempTable.Rows.Count;
                    if (count > 0)
                        autoIdInt = DataTypeConvert.GetInt(tempTable.Rows[0]["AutoId"]);
                }

                if (count == 0)//新增
                {
                    cmd.CommandText = string.Format("Insert into BS_WorkFlowDataHandle (DataNo, FlowModuleId, NodeId, Approver, ApproverOption, ApproverResult) values ('{0}', '{1}', {2}, '{3}', '{4}', {5})", orderNo, flowModuleIdStr, nodeIdInt, approverStr, approverOptionStr, approverResultInt);
                    cmd.ExecuteNonQuery();
                }
                else//修改
                {
                    //cmd.CommandText = string.Format("Update BS_WorkFlowDataHandle set FlowModuleId = '{4}', ApproverOption = '{5}', ApproverResult = {6}, ApproverTime = getdate() where DataNo = '{0}' and NodeId = '{1}' and Approver = '{2}' and AutoId = {3}", orderNo, nodeIdInt, approverStr, autoIdInt, flowModuleIdStr, approverOptionStr, approverResultInt);
                    cmd.CommandText = string.Format("Update BS_WorkFlowDataHandle set Approver = '{3}', FlowModuleId = '{4}', ApproverOption = '{5}', ApproverResult = {6}, ApproverTime = getdate() where DataNo = '{0}' and NodeId = '{1}' and AutoId = {2}", orderNo, nodeIdInt, autoIdInt, approverStr, flowModuleIdStr, approverOptionStr, approverResultInt);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        /// <summary>
        /// 根据模块查询所属节点信息
        /// </summary>
        public DataTable ModuleGetWorkFlowNode(string WorkFlowTypeText, string tableNameStr, int moduleTypeInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        DataTable wfNodeTable = ModuleGetWorkFlowNode(cmd, WorkFlowTypeText, tableNameStr, moduleTypeInt);

                        trans.Commit();
                        return wfNodeTable;
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
        /// 根据模块查询所属节点信息
        /// </summary>
        public DataTable ModuleGetWorkFlowNode(SqlCommand cmd, string WorkFlowTypeText, string tableNameStr, int moduleTypeInt)
        {
            cmd.CommandText = string.Format("select AutoId from BS_WorkFlowType where WorkFlowTypeText = '{0}'", WorkFlowTypeText);
            int workFlowTypeAutoId = DataTypeConvert.GetInt(cmd.ExecuteScalar());
            if (workFlowTypeAutoId == 0)
            {
                throw new Exception("未查询到当前操作的流程类型信息，请设置流程信息后再进行操作。");
            }
            cmd.CommandText = string.Format("select AutoId, FlowModuleId from BS_WorkFlowNode where WorkFlowId in (select AutoId from BS_WorkFlow where WorkFlowTypeAutoId = {0}) and FlowModuleId in (select FlowModuleId from BS_WorkFlowModule where FlowModuleTableName = '{1}' and ModuleType = {2}) order by AutoId", workFlowTypeAutoId, tableNameStr, moduleTypeInt);
            DataTable wfNodeTable = BaseSQL.GetTableBySql(cmd);
            return wfNodeTable;
        }

        /// <summary>
        /// 处理单据在当前节点表里面的结束标志
        /// </summary>
        public void HandleDataCurrentNode_IsEnd(SqlCommand cmd, List<string> orderNoList, int stateInt, int isEndInt)
        {
            foreach (string orderNo in orderNoList)
            {
                cmd.CommandText = string.Format("update BS_DataCurrentNode set currentState = {1}, isEnd = {2} where DataNo = '{0}'", orderNo, stateInt, isEndInt);
                cmd.ExecuteNonQuery();
            }
        }
        public void HandleDataCurrentNode_IsEnd(SqlCommand cmd, string orderNoListStr, int stateInt, int isEndInt)
        {
            cmd.CommandText = string.Format("update BS_DataCurrentNode set currentState = {1}, isEnd = {2} where DataNo in ({0})", orderNoListStr, stateInt, isEndInt);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 删除单据的当前结点信息
        /// </summary>
        public void DeleteDataCurrentNode(SqlCommand cmd, string orderNoListStr)
        {
            cmd.CommandText = string.Format("Delete from BS_DataCurrentNode where DataNo in ({0})", orderNoListStr);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 查询流程图定义的条件字符串
        /// </summary>
        /// <param name="tableNameStr">数据库表名</param>
        /// <param name="moduleTypeInt">模块类型编号  1 登记 2 审批</param>
        /// <param name="approverInt">审批人</param>
        public string GetWorkFlowLine_ConditionString(string tableNameStr, int moduleTypeInt, int approverInt)
        {
            string loginIdStr = "";
            string roleNoStr = "";
            QueryUserInfo_LoginIdAndRoleNo(null, approverInt, ref loginIdStr, ref roleNoStr);

            string tmpSqlStr = "";

            tmpSqlStr = string.Format("select Condition from BS_WorkFlowNodeToNode where LevelNodeId in (select AutoId from BS_WorkFlowNode where FlowModuleId in (select FlowModuleId from BS_WorkFlowModule where FlowModuleTableName = '{0}' and ModuleType = {1}) and AutoId in (select NodeId from BS_WorkFlowNodeHandle where ((NodeHandleCate = 0 and HandleOwner = '{2}') or(NodeHandleCate = 1 and HandleOwner = '{3}'))))", tableNameStr, moduleTypeInt, loginIdStr, roleNoStr);
            DataTable conditionTable = BaseSQL.GetTableBySql(tmpSqlStr);
            tmpSqlStr = "";
            foreach (DataRow conRow in conditionTable.Rows)
            {
                tmpSqlStr += string.Format(" ({0}) or", DataTypeConvert.GetString(conRow["Condition"]));
            }

            if (tmpSqlStr.Length > 0)
            {
                tmpSqlStr = tmpSqlStr.Replace("‘", "'");
                tmpSqlStr = tmpSqlStr.Replace("’", "'");
                tmpSqlStr = string.Format(" and ({0})", tmpSqlStr.Substring(0, tmpSqlStr.Length - 2));
            }
            else
                tmpSqlStr = string.Format(" and (1=2)");

            return tmpSqlStr;
        }

        /// <summary>
        /// 登记单处理流程信息数据
        /// </summary>
        /// <param name="orderNoStr">单据号</param>
        /// <param name="workFlowTypeText">流程类型名称  销售流程，采购流程，库存流程，人事流程，生产流程</param>
        /// <param name="tableNameStr">数据表名称</param>
        /// <param name="primaryKeyStr">主键列名</param>
        /// <param name="moduleTypeInt">模块类型编号  1 登记 2 审批</param>
        /// <param name="stateInt">单据状态，可返回修改的状态</param>
        /// <param name="approverInt">审批人</param>
        /// <param name="approverOptionStr">审批意见</param>
        /// <param name="approverResultInt">审批结果 1 同意 0 不同意</param>
        /// <param name="allNewDataHandle">全部新增单据处理记录</param>
        public bool HandleWorkFlowData(SqlCommand cmd, string orderNoStr, string workFlowTypeText, string tableNameStr, string primaryKeyStr, int moduleTypeInt, ref int stateInt, int approverInt, string approverStr, string approverOptionStr, int approverResultInt, bool allNewDataHandle)
        {
            string flowModuleIdStr = "";
            int currentNodeIdInt = 0;
            DataTable newNodeTable;

            cmd.CommandText = string.Format("select * from BS_DataCurrentNode where DataNo = '{0}'", orderNoStr);
            DataTable curNodeTable = BaseSQL.GetTableBySql(cmd);
            if (curNodeTable.Rows.Count == 0 || DataTypeConvert.GetInt(curNodeTable.Rows[0]["currentState"]) == 1 || DataTypeConvert.GetInt(curNodeTable.Rows[0]["currentState"]) == 6)
            {
                cmd.CommandText = string.Format("select AutoId from BS_WorkFlowType where WorkFlowTypeText = '{0}'", workFlowTypeText);
                int workFlowTypeAutoId = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                if (workFlowTypeAutoId == 0)
                {
                    MessageHandler.ShowMessageBox("未查询到当前操作的流程类型信息，请设置流程信息后再进行操作。"); return false;
                }
                cmd.CommandText = string.Format("select wfNode.AutoId, wfNode.WorkFlowId, NodeCate, wfNode.FlowModuleId, FlowModuleTableName, ModuleType, WorkFlowTypeText, '' as Condition from BS_WorkFlowNode as wfNode left join BS_WorkFlowModule on wfNode.FlowModuleId = BS_WorkFlowModule.FlowModuleId left join BS_WorkFlow on wfNode.WorkFlowId = BS_WorkFlow.AutoId left join BS_WorkFlowType on BS_WorkFlow.WorkFlowTypeAutoId = BS_WorkFlowType.AutoId where wfNode.WorkFlowId in (select AutoId from BS_WorkFlow where WorkFlowTypeAutoId = {0}) and wfNode.FlowModuleId in (select FlowModuleId from BS_WorkFlowModule where FlowModuleTableName = '{1}' and ModuleType = {2}) order by AutoId", workFlowTypeAutoId, tableNameStr, moduleTypeInt);
                newNodeTable = BaseSQL.GetTableBySql(cmd);
                if (newNodeTable.Rows.Count == 0)
                {
                    MessageHandler.ShowMessageBox("未查询到当前操作所属的流程节点，请联系系统的维护人员。"); return false;
                }
            }
            else
            {
                int previousNodeId = DataTypeConvert.GetInt(curNodeTable.Rows[0]["CurrentNodeId"]);

                cmd.CommandText = string.Format("select wfNode.AutoId, wfNode.WorkFlowId, NodeCate, wfNode.FlowModuleId, FlowModuleTableName, ModuleType, WorkFlowTypeText, wfLine.Condition from BS_WorkFlowNode as wfNode left join BS_WorkFlowNodeToNode as wfLine on wfNode.AutoId = wfLine.LevelNodeId left join BS_WorkFlowModule on wfNode.FlowModuleId = BS_WorkFlowModule.FlowModuleId left join BS_WorkFlow on wfNode.WorkFlowId = BS_WorkFlow.AutoId left join BS_WorkFlowType on BS_WorkFlow.WorkFlowTypeAutoId = BS_WorkFlowType.AutoId where wfLine.NodeId = {0}", previousNodeId);
                newNodeTable = BaseSQL.GetTableBySql(cmd);
            }

            string tmpStr = "";
            bool isFindNewNode = false;
            string memoStr = "";
            foreach (DataRow nodeRow in newNodeTable.Rows)
            {
                if (curNodeTable.Rows.Count > 0)
                {
                    string queryWorkFlowTypeTextStr = DataTypeConvert.GetString(nodeRow["WorkFlowTypeText"]);
                    string queryTableNameStr = DataTypeConvert.GetString(nodeRow["FlowModuleTableName"]);
                    int queryModuleTypeInt = DataTypeConvert.GetInt(nodeRow["ModuleType"]);
                    if (queryWorkFlowTypeTextStr != workFlowTypeText || queryTableNameStr != tableNameStr || queryModuleTypeInt != moduleTypeInt)
                    {
                        memoStr = string.Format("当前操作的流程类型与登记单[{0}]所在的节点的下级节点信息不符，请重新正确设置流程信息。", orderNoStr);
                        continue;
                    }
                }

                tmpStr = DataTypeConvert.GetString(nodeRow["Condition"]);
                if (tmpStr != "")
                {
                    tmpStr = tmpStr.Replace("‘", "'");
                    tmpStr = tmpStr.Replace("’", "'");

                    cmd.CommandText = string.Format("select Count(*) from {0} where {1} = '{2}' and {3}", tableNameStr, primaryKeyStr, orderNoStr, tmpStr);

                    if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) == 0)
                        continue;
                }

                if (moduleTypeInt == 2)
                {
                    int nodeAutoIdInt = DataTypeConvert.GetInt(nodeRow["AutoId"]);

                    string loginIdStr = "";
                    string roleNoStr = "";
                    QueryUserInfo_LoginIdAndRoleNo(cmd, approverInt, ref loginIdStr, ref roleNoStr);

                    cmd.CommandText = string.Format("select Count(*) from BS_WorkFlowNodeHandle where NodeId = {0} and ((NodeHandleCate = 0 and HandleOwner = '{1}') or (NodeHandleCate = 1 and HandleOwner = '{2}'))", nodeAutoIdInt, loginIdStr, roleNoStr);

                    if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) == 0)
                    {
                        memoStr = string.Format("登记单[{0}]流程图设定的审批人员列表不包含当前的审批人，无法通过审批。", orderNoStr);
                        continue;
                    }
                }

                isFindNewNode = true;
                flowModuleIdStr = DataTypeConvert.GetString(nodeRow["FlowModuleId"]);
                currentNodeIdInt = DataTypeConvert.GetInt(nodeRow["AutoId"]);
                break;
            }

            if (!isFindNewNode)
            {
                if (memoStr != "")
                    MessageHandler.ShowMessageBox(memoStr);
                else
                    MessageHandler.ShowMessageBox(string.Format("登记单[{0}]未查询到符合流程图的节点，无法继续操作。", orderNoStr));
                return false;
            }

            if (moduleTypeInt == 2 && approverInt < 0)
                return true;

            if (moduleTypeInt == 2)
            {
                if (approverResultInt == 0)
                {
                    stateInt = 6;
                }
                else
                {
                    //判断下个节点还是不是审批
                    cmd.CommandText = string.Format("select wfNode.AutoId, wfNode.WorkFlowId, NodeCate, wfNode.FlowModuleId, FlowModuleTableName, ModuleType, WorkFlowTypeText, wfLine.Condition from BS_WorkFlowNode as wfNode left join BS_WorkFlowNodeToNode as wfLine on wfNode.AutoId = wfLine.LevelNodeId left join BS_WorkFlowModule on wfNode.FlowModuleId = BS_WorkFlowModule.FlowModuleId left join BS_WorkFlow on wfNode.WorkFlowId = BS_WorkFlow.AutoId left join BS_WorkFlowType on BS_WorkFlow.WorkFlowTypeAutoId = BS_WorkFlowType.AutoId where wfLine.NodeId = {0}", currentNodeIdInt);
                    DataTable nextNodeTable = BaseSQL.GetTableBySql(cmd);
                    if (nextNodeTable.Rows.Count > 0)
                    {
                        string queryWorkFlowTypeTextStr = DataTypeConvert.GetString(nextNodeTable.Rows[0]["WorkFlowTypeText"]);
                        string queryTableNameStr = DataTypeConvert.GetString(nextNodeTable.Rows[0]["FlowModuleTableName"]);
                        int queryModuleTypeInt = DataTypeConvert.GetInt(nextNodeTable.Rows[0]["ModuleType"]);
                        if (queryWorkFlowTypeTextStr == workFlowTypeText && queryTableNameStr == tableNameStr && queryModuleTypeInt == moduleTypeInt)
                        {
                            stateInt = 4;
                        }
                    }
                }
            }

            if (curNodeTable.Rows.Count == 0)
            {
                cmd.CommandText = string.Format("Insert into BS_DataCurrentNode (DataNo, FlowModuleId, CurrentNodeId, currentState, isEnd) values ('{0}', '{1}', {2}, {3}, 0)", orderNoStr, flowModuleIdStr, currentNodeIdInt, stateInt);
            }
            else
            {
                cmd.CommandText = string.Format("update BS_DataCurrentNode set FlowModuleId = '{1}', CurrentNodeId = {2}, currentState = {3} where DataNo = '{0}'", orderNoStr, flowModuleIdStr, currentNodeIdInt, stateInt);
            }
            cmd.ExecuteNonQuery();

            UpdateCurrentNode_IsEnd(cmd, orderNoStr);

            InsertWorkFlowDataHandle(cmd, allNewDataHandle, orderNoStr, flowModuleIdStr, currentNodeIdInt, approverStr, approverResultInt, approverOptionStr);

            return true;

            //1 查询流程图节点列表是否存在
            //    不存在
            //        新增节点表信息

            //    存在
            //        查询主单符合下面连接线的那个条件，
            //        判断下个节点是否就是当前的操作所属的节点类型，如果是继续，如果不符合弹出Message退出

            //        判断下个节点的审批人是否是当前操作人员
            //        是否符合可以审批

            //        判断再下个节点还是不是当前操作类型，如果是返回审批中的状态，否则返回审批的状态

            //2 查询流程图节点是否结束，设定结束标志
            //3 保存流程记录 提交保存一条，审批保存多条            
        }

        /// <summary>
        /// 更新主单的当前节点的结束标志
        /// </summary>
        /// <param name="orderNoStr">单据号</param>
        private void UpdateCurrentNode_IsEnd(SqlCommand cmd, string orderNoStr)
        {
            cmd.CommandText = string.Format("update BS_DataCurrentNode set isEnd = (case BS_WorkFlowNode.NodeCate when 3 then 1 else 0 end) from BS_DataCurrentNode left join BS_WorkFlowNode on BS_DataCurrentNode.CurrentNodeId = BS_WorkFlowNode.AutoId where DataNo = '{0}'", orderNoStr);
            cmd.ExecuteNonQuery();

            cmd.CommandText = string.Format("update BS_DataCurrentNode set isEnd = 1 from BS_DataCurrentNode left join BS_WorkFlowNodeToNode on BS_DataCurrentNode.CurrentNodeId = BS_WorkFlowNodeToNode.NodeId left join BS_WorkFlowNode on BS_WorkFlowNodeToNode.LevelNodeId = BS_WorkFlowNode.AutoId where BS_WorkFlowNode.NodeCate = 3 and DataNo = '{0}'", orderNoStr);
            //cmd.CommandText = string.Format("update BS_DataCurrentNode set isEnd = 1 from BS_DataCurrentNode left join BS_WorkFlowNodeToNode on BS_DataCurrentNode.CurrentNodeId = BS_WorkFlowNodeToNode.NodeId left join BS_WorkFlowNode on BS_WorkFlowNodeToNode.LevelNodeId = BS_WorkFlowNode.AutoId where (BS_WorkFlowNode.NodeCate = 3 or BS_DataCurrentNode.currentState = 2) and DataNo = '{0}'", orderNoStr);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 新增一条工作流的流程记录
        /// </summary>
        /// <param name="allNewDataHandle">全部新增单据处理记录</param>
        /// <param name="orderNoStr">单据号</param>
        /// <param name="flowModuleIdStr">节点所属的模块编号</param>
        /// <param name="nodeIdInt">截图Id</param>
        /// <param name="approverStr">审批人</param>
        /// <param name="approverResultInt">审批结果</param>
        /// <param name="approverOptionStr">审批信息</param>
        private void InsertWorkFlowDataHandle(SqlCommand cmd, bool allNewDataHandle, string orderNoStr, string flowModuleIdStr, int nodeIdInt, string approverStr, int approverResultInt, string approverOptionStr)
        {
            int autoIdInt = 0;
            if (!allNewDataHandle)
            {
                //cmd.CommandText = string.Format("select top 1 AutoId from BS_WorkFlowDataHandle where DataNo = '{0}' and NodeId = '{1}' and Approver = '{2}' order by AutoId desc", orderNo, nodeIdInt, approverStr);
                cmd.CommandText = string.Format("select top 1 AutoId from BS_WorkFlowDataHandle where DataNo = '{0}' and NodeId = '{1}' and ApproverResult = {2} order by AutoId desc", orderNoStr, nodeIdInt, approverResultInt);
                DataTable tempTable = BaseSQL.GetTableBySql(cmd);

                if (tempTable.Rows.Count > 0)
                    autoIdInt = DataTypeConvert.GetInt(tempTable.Rows[0]["AutoId"]);
            }

            if (autoIdInt == 0)//新增
            {
                cmd.CommandText = string.Format("Insert into BS_WorkFlowDataHandle (DataNo, FlowModuleId, NodeId, Approver, ApproverOption, ApproverResult) values ('{0}', '{1}', {2}, '{3}', '{4}', {5})", orderNoStr, flowModuleIdStr, nodeIdInt, approverStr, approverOptionStr, approverResultInt);
            }
            else//修改
            {
                //cmd.CommandText = string.Format("Update BS_WorkFlowDataHandle set FlowModuleId = '{4}', ApproverOption = '{5}', ApproverResult = {6}, ApproverTime = getdate() where DataNo = '{0}' and NodeId = '{1}' and Approver = '{2}' and AutoId = {3}", orderNo, nodeIdInt, approverStr, autoIdInt, flowModuleIdStr, approverOptionStr, approverResultInt);
                cmd.CommandText = string.Format("Update BS_WorkFlowDataHandle set Approver = '{3}', FlowModuleId = '{4}', ApproverOption = '{5}', ApproverResult = {6}, ApproverTime = getdate() where DataNo = '{0}' and NodeId = '{1}' and AutoId = {2}", orderNoStr, nodeIdInt, autoIdInt, approverStr, flowModuleIdStr, approverOptionStr, approverResultInt);
            }
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 查询审批人的登陆号和角色名
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="approverInt"></param>
        /// <param name="loginIdStr"></param>
        /// <param name="roleNoStr"></param>
        private void QueryUserInfo_LoginIdAndRoleNo(SqlCommand cmd, int approverInt, ref string loginIdStr, ref string roleNoStr)
        {
            string tmpSql = string.Format("select LoginId, RoleNo from BS_UserInfo left join BS_RoleUser on BS_RoleUser.UserNo = BS_UserInfo.AutoId where BS_UserInfo.AutoId = {0}", approverInt);
            DataTable userTable;
            if (cmd != null)
            {
                cmd.CommandText = tmpSql;
                userTable = BaseSQL.GetTableBySql(cmd);
            }
            else
            {
                userTable = BaseSQL.GetTableBySql(tmpSql);
            }

            if (userTable.Rows.Count == 0)
            {
                throw new Exception("未查询到审批人的信息，请重新操作。");
            }
            loginIdStr = DataTypeConvert.GetString(userTable.Rows[0]["LoginId"]);
            roleNoStr = DataTypeConvert.GetString(userTable.Rows[0]["RoleNo"]);
        }
    }
}



//select* from BS_WorkFlowModule

//select* from BS_WorkFlowModuleProper

//select* from BS_WorkFlowType

//select* from BS_WorkFlow

//select* from BS_WorkFlowNode

//select* from BS_WorkFlowNodeToNode

//select* from BS_WorkFlowNodeHandle
//select* from BS_DataCurrentNode


//select wfNode.AutoId, wfNode.WorkFlowId, NodeCate, wfNode.FlowModuleId, FlowModuleTableName, ModuleType, WorkFlowTypeText, wfLine.Condition
//from BS_WorkFlowNode as wfNode
//left join BS_WorkFlowNodeToNode as wfLine on wfNode.AutoId = wfLine.LevelNodeId
//left join BS_WorkFlowModule on wfNode.FlowModuleId = BS_WorkFlowModule.FlowModuleId
//left join BS_WorkFlow on wfNode.WorkFlowId = BS_WorkFlow.AutoId
//left join BS_WorkFlowType on BS_WorkFlow.WorkFlowTypeAutoId = BS_WorkFlowType.AutoId
//where wfLine.NodeId =


//select * from BS_WorkFlowDataHandle


//select wfNode.AutoId, wfNode.WorkFlowId, NodeCate, wfNode.FlowModuleId, FlowModuleTableName, ModuleType, WorkFlowTypeText, '' as Condition
//from BS_WorkFlowNode as wfNode
//left join BS_WorkFlowModule on wfNode.FlowModuleId = BS_WorkFlowModule.FlowModuleId
//left join BS_WorkFlow on wfNode.WorkFlowId = BS_WorkFlow.AutoId
//left join BS_WorkFlowType on BS_WorkFlow.WorkFlowTypeAutoId = BS_WorkFlowType.AutoId
//where wfNode.WorkFlowId in (select AutoId from BS_WorkFlow where WorkFlowTypeAutoId = 0) and wfNode.FlowModuleId in (select FlowModuleId from BS_WorkFlowModule where FlowModuleTableName = '{1}' and ModuleType = 2) order by AutoId

