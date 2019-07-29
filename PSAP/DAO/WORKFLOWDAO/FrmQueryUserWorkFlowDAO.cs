using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PSAP.DAO.WORKFLOWDAO
{
    class FrmQueryUserWorkFlowDAO
    {
        /// <summary>
        /// 查询用户流程信息数量
        /// </summary>
        public int QueryUserWorkFlow()
        {
            string sqlStr = string.Format("select Count(*) from F_QueryUserWorkFlow('{0}')", SystemInfo.user.LoginID);
            return DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
        }

        /// <summary>
        /// 查询用户流程信息
        /// </summary>
        public void QueryUserWorkFlow(DataTable queryDataTable)
        {
            string sqlStr = Get_QueryUserWorkFlow_Sql("CurNode.*,BS_WorkFlowNode.NodeText,FlowModuleText,ModuleType");
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询用户流程信息的条数
        /// </summary>
        public int QueryUserWorkFlow_Count()
        {
            string sqlStr = Get_QueryUserWorkFlow_Sql("Count(*)");
            return DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
        }

        /// <summary>
        /// 查询用户流程信息的SQL
        /// </summary>
        public string Get_QueryUserWorkFlow_Sql(string columnStr)
        {
            string sqlStr = string.Format("select * from F_QueryUserWorkFlow('{0}') Order by AutoId", SystemInfo.user.LoginID);
            DataTable userWFTable = BaseSQL.GetTableBySql(sqlStr);

            string allSqlStr = string.Format("select {0} from (", columnStr);
            foreach (DataRow dr in userWFTable.Rows)
            {
                string tempStr = DataTypeConvert.GetString(dr["Condition"]).Replace("‘", "'").Replace("’", "'");
                if (tempStr == "")
                {
                    tempStr = " 1=1";
                }
                allSqlStr += string.Format("select AutoId,DataNo,FlowModuleId,CurrentNodeId,'{3}' as FMTable,'{4}' as LFMTable,{5} as LMType,'{6}' as LFMId from BS_DataCurrentNode where isEnd!=1 and DataNo in (select {1} from {0} where 1=1 and ({2})) Union ", DataTypeConvert.GetString(dr["FlowModuleTableName"]), DataTypeConvert.GetString(dr["FlowModulePrimaryKey"]), tempStr, DataTypeConvert.GetString(dr["FlowModuleTableName"]), DataTypeConvert.GetString(dr["LevelFlowModuleTableName"]), DataTypeConvert.GetString(dr["LevelModuleType"]), DataTypeConvert.GetString(dr["LevelFlowModuleId"]));
            }

            allSqlStr = allSqlStr.Substring(0, allSqlStr.Length - 6) + ") as CurNode left join BS_WorkFlowNode on CurNode.CurrentNodeId = BS_WorkFlowNode.AutoId left join BS_WorkFlowModule on BS_WorkFlowModule.FlowModuleId = CurNode.FlowModuleId";

            return allSqlStr;
        }

        /// <summary>
        /// 查询用户登记被拒绝的单据
        /// </summary>
        public void QueryRejectOrder(DataTable queryDataTable)
        {
            string sqlStr = Get_QueryRejectOrder_Sql("BS_DataCurrentNode.*, Approver, ApproverOption, FlowModuleTableName as FMTable, BS_WorkFlowNode.NodeText, FlowModuleText,ModuleType");
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询用户登记被拒绝的单据的条数
        /// </summary>
        public int QueryRejectOrder_Count()
        {
            string sqlStr = Get_QueryRejectOrder_Sql("Count(*)");
            return DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
        }

        /// <summary>
        /// 查询用户登记被拒绝的单据的SQL
        /// </summary>
        public string Get_QueryRejectOrder_Sql(string columnStr)
        {
            return string.Format("select {1} from BS_DataCurrentNode left join BS_WorkFlowDataHandle on BS_DataCurrentNode.CurrentNodeId = BS_WorkFlowDataHandle.NodeId and BS_DataCurrentNode.DataNo = BS_WorkFlowDataHandle.DataNo and BS_WorkFlowDataHandle.AutoId = (select MAX(AutoId) from BS_WorkFlowDataHandle as wfData where wfData.NodeId = BS_WorkFlowDataHandle.NodeId and wfData.DataNo = BS_WorkFlowDataHandle.DataNo) left join BS_WorkFlowNode on BS_DataCurrentNode.CurrentNodeId = BS_WorkFlowNode.AutoId left join BS_WorkFlowModule on BS_WorkFlowModule.FlowModuleId = BS_WorkFlowNode.FlowModuleId where BS_DataCurrentNode.currentState = 6 and Approver = '{0}'", SystemInfo.user.LoginID, columnStr);
        }
    }
}
