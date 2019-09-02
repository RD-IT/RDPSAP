using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.BSDAO
{
    class FrmPartsCodeDAO
    {
        /// <summary>
        /// 查询和当前零件编号相同的零件个数
        /// </summary>
        public int QueryPartsCode_CodeFileNameCount(string codeFileNameStr)
        {
            string sqlStr = string.Format("select Count(*) from SW_PartsCode where CodeFileName = '{0}'", codeFileNameStr);
            return DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
        }

        public string QueryPartsCode_FilePath(string codeFileNameStr)
        {
            string sqlStr= string.Format("select FilePath from SW_PartsCode where CodeFileName = '{0}'", codeFileNameStr);
            return DataTypeConvert.GetString(BaseSQL.GetSingle(sqlStr));
        }

        /// <summary>
        /// 保存导入的物料信息
        /// </summary>
        public void SaveImportPartsCode(DataTable partsCodeTable)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = "select * from SW_PartsCode where 1=2";
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable tmpPCTable = new DataTable();
                        adapterList.Fill(tmpPCTable);
                        BaseSQL.UpdateDataTable(adapterList, partsCodeTable);

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
        /// 查询物料信息表
        /// </summary>
        public string QueryPartsCode_SQL(DataTable queryDataTable, string catgNameStr, int materialInt, string brandStr, string commonStr, bool nullTable)
        {
            string sqlStr = " 1=1";
            if (catgNameStr != "")
            {
                sqlStr += string.Format(" and CatgName='{0}'", catgNameStr);
            }
            if (materialInt != 0)
            {
                sqlStr += string.Format(" and Material={0}", materialInt);
            }
            if (brandStr != "")
            {
                sqlStr += string.Format(" and Brand='{0}'", brandStr);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (CodeNo like '%{0}%' or CodeFileName like '%{0}%' or CodeName like '%{0}%' or FilePath like '%{0}%' or CatgName like '%{0}%' or CodeSpec like '%{0}%' or Brand like '%{0}%' or Unit like '%{0}%' or Designer like '%{0}%' or Tel like '%{0}%')", commonStr);
            }
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select * from SW_PartsCode where {0} order by AutoId", sqlStr);
            return sqlStr;
        }
    }
}
