using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using PSAP.PSAPCommon;
using System.Data;

namespace PSAP.DAO.BSDAO
{
    class FrmProjectStatusDAO
    {
        /// <summary>
        /// 查询项目状态信息
        /// </summary>
        public DataTable QueryProjectStatus(bool addAllItem)
        {
            string sqlStr = "select AutoId, StatusText, IsDefault from BS_ProjectStatus order by AutoId";
            if (addAllItem)
            {
                sqlStr = "select 0 as AutoId, '全部' as StatusText, 0 as IsDefault union " + sqlStr;
            }
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询项目状态信息的默认数量
        /// </summary>
        public int GetProjectStatus_DefaultCount(int autoIdInt)
        {
            string sqlStr = string.Format("select Count(*) from BS_ProjectStatus where IsDefault = 1 and AutoId != {0}", autoIdInt);
            return DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
        }

        /// <summary>
        /// 查询项目状态信息的默认编号
        /// </summary>
        public int GetProjectStatus_DefaultAutoId()
        {
            string sqlStr = "select AutoId from BS_ProjectStatus where IsDefault = 1";
            return DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
        }

        /// <summary>
        /// 更新项目状态信息的默认标志
        /// </summary>
        public void UpdateProjectStatus_SetNoDefault(SqlCommand cmd, int autoIdInt, int isDefaultInt)
        {
            cmd.CommandText = string.Format("Update BS_ProjectStatus set IsDefault = {1} where AutoId != {0}", autoIdInt, isDefaultInt);
            cmd.ExecuteNonQuery();
        }
    }
}
