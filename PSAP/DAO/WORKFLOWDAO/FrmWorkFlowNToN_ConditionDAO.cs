using DevExpress.XtraDiagram;
using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PSAP.DAO.WORKFLOWDAO
{
    class FrmWorkFlowNToN_ConditionDAO
    {
        /// <summary>
        /// 查询模块字段信息
        /// </summary>
        public DataTable QueryWorkFlowModuleProper(string flowModuleIdStr)
        {
            string sqlStr = string.Format("select BS_WorkFlowModuleProper.AutoId, ProperName, ProperText, Proper, V_DataTypeView.DataTypeName, V_DataTypeView.DataTypeNo from BS_WorkFlowModuleProper left join V_DataTypeView on BS_WorkFlowModuleProper.Proper = V_DataTypeView.AutoId where FlowModuleId = '{0}'", flowModuleIdStr);
            return BaseSQL.GetTableBySql(sqlStr);
        }
    }
}
