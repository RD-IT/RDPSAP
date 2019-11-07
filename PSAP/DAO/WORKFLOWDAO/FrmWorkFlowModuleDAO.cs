using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.WORKFLOWDAO
{
    class FrmWorkFlowModuleDAO
    {
        /// <summary>
        /// 查询业务模块列表
        /// </summary>
        public DataTable QueryWorkFlowModule(bool addAllItem)
        {
            string sqlStr = "select AutoId, FlowModuleId, FlowModuleText, FlowModuleFormName, FlowModuleTableName from BS_WorkFlowModule order by AutoId";
            if (addAllItem)
            {
                sqlStr = "select 0 as AutoId, '' as FlowModuleId, '全部' as FlowModuleText, '' as FlowModuleFormName, '' as FlowModuleTableName union " + sqlStr;
            }
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询数据类型的视图表
        /// </summary>
        public DataTable QueryDataTypeView()
        {
            string sqlStr = "select * from V_DataTypeView";
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询模块表信息
        /// </summary>
        public DataTable QueryModuleTableInfo()
        {
            string sqlStr = "select * from V_ModuleTableInfo";
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询模块类型信息
        /// </summary>
        public DataTable QueryModuleType()
        {
            DataTable table = new DataTable("table");
            table.Columns.Add("AutoId", Type.GetType("System.Int32"));
            table.Columns.Add("ModuleTypeName", Type.GetType("System.String"));

            DataRow newRow;

            newRow = table.NewRow();
            newRow["AutoId"] = 1;
            newRow["ModuleTypeName"] = "制单";
            table.Rows.Add(newRow);

            newRow = table.NewRow();
            newRow["AutoId"] = 2;
            newRow["ModuleTypeName"] = "审批";
            table.Rows.Add(newRow);

            return table;
        }

        /// <summary>
        /// 生成业务模块的字段信息
        /// </summary>
        public bool Insert_WorkFlowModuleProper(string flowModuleIdStr,string tableNameStr)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (QueryModuleIsUse(cmd, flowModuleIdStr))
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("有流程图在使用当前业务模块，不可以修改。");
                            return false;
                        }

                        cmd.CommandText = string.Format("delete from BS_WorkFlowModuleProper where FlowModuleId = '{0}'", flowModuleIdStr);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("insert into BS_WorkFlowModuleProper (FlowModuleId, ProperName, ProperText, Proper) select '{0}', COLUMN_NAME, COLUMN_NAME, V_DataTypeView.AutoId from information_schema.columns left join V_DataTypeView on DATA_TYPE = V_DataTypeView.DataTypeName where table_name = '{1}' and TABLE_SCHEMA = 'dbo'", flowModuleIdStr, tableNameStr);
                        int count = cmd.ExecuteNonQuery();

                        if(count == 0)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("未查询到当前数据表，无法生成业务模块的字段信息。");
                            return false;
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
        /// 查询数据表名在数据库是否存在
        /// </summary>
        public bool QueryTableNameIsExists(string tableNameStr)
        {
            string sqlStr = string.Format("SELECT Count(*) FROM information_schema.TABLES WHERE table_name = '{0}'", tableNameStr);
            int count = DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
            if (count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 查询模块在流程图的结点中是否在使用
        /// </summary>
        public bool QueryModuleIsUse(SqlCommand cmd, string autoId)
        {
            cmd.CommandText = string.Format("select COUNT(*) from BS_WorkFlowNode where FlowModuleId = '{0}'", autoId);
            int count = DataTypeConvert.GetInt(cmd.ExecuteScalar());
            if (count > 0)
                return true;
            return false;
        }
    }
}
