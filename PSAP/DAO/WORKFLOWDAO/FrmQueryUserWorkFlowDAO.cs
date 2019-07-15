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
            string sqlStr = string.Format("select * from F_QueryUserWorkFlow('{0}') Order by AutoId", SystemInfo.user.LoginID);
            DataTable userWFTable = BaseSQL.GetTableBySql(sqlStr);

            string allSqlStr = "";
            foreach (DataRow dr in userWFTable.Rows)
            {
                string tempStr = DataTypeConvert.GetString(dr["Condition"]).Replace("‘", "'").Replace("’", "'");
                if(tempStr == "")
                {
                    tempStr = " 1=1";
                }
                allSqlStr += string.Format("select AutoId,DataNo,FlowModuleId,'{3}' as NodeText,'{4}' as FlowModuleText,{5} as ModuleType,'{6}' as FMTable,'{7}' as LFMTable from BS_DataCurrentNode where DataNo in (select {1} from {0} where 1=1 and ({2})) Union All ", DataTypeConvert.GetString(dr["FlowModuleTableName"]), DataTypeConvert.GetString(dr["FlowModulePrimaryKey"]), tempStr, DataTypeConvert.GetString(dr["NodeText"]), DataTypeConvert.GetString(dr["FlowModuleText"]), DataTypeConvert.GetString(dr["ModuleType"]), DataTypeConvert.GetString(dr["FlowModuleTableName"]), DataTypeConvert.GetString(dr["LevelFlowModuleTableName"]));
            }

            BaseSQL.Query(allSqlStr.Substring(0, allSqlStr.Length - 10), queryDataTable);
        }
    }
}
