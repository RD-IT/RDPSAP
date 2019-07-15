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
        /// <param name="moduleTypeInt">模块类型编号  1 登记 2 审核</param>
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
                if (!allNewDataHandle)
                {
                    cmd.CommandText = string.Format("select Count(*) from BS_WorkFlowDataHandle where DataNo = '{0}' and NodeId = '{1}' and Approver = '{2}'", orderNo, nodeIdInt, approverStr);
                    count = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                }

                if (count == 0)//新增
                {
                    cmd.CommandText = string.Format("Insert into BS_WorkFlowDataHandle (DataNo, FlowModuleId, NodeId, Approver, ApproverOption, ApproverResult) values ('{0}', '{1}', {2}, '{3}', '{4}', {5})", orderNo, flowModuleIdStr, nodeIdInt, approverStr, approverOptionStr, approverResultInt);
                    cmd.ExecuteNonQuery();
                }
                else//修改
                {
                    cmd.CommandText = string.Format("Update BS_WorkFlowDataHandle set FlowModuleId = '{3}', ApproverOption = '{4}', ApproverResult = {5}, ApproverTime = getdate() where DataNo = '{0}' and NodeId = '{1}' and Approver = '{2}'", orderNo, nodeIdInt, approverStr, flowModuleIdStr, approverOptionStr, approverResultInt);
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
                throw new Exception("查询流程类型信息错误。");
            }
            cmd.CommandText = string.Format("select AutoId, FlowModuleId from BS_WorkFlowNode where WorkFlowId in (select AutoId from BS_WorkFlow where WorkFlowTypeAutoId = {0}) and FlowModuleId in (select FlowModuleId from BS_WorkFlowModule where FlowModuleTableName = '{1}' and ModuleType = {2})", workFlowTypeAutoId, tableNameStr, moduleTypeInt);
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
    }
}
