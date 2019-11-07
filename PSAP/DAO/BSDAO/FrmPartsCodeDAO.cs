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

        /// <summary>
        /// 得到查询零件信息的条件SQL
        /// </summary>
        public string GetQueryWhereSql(string codeFileNameStr, string codeNoStr, string codeNameStr, string codeSpecStr, string materialVersionStr, string designerStr, string catgNameStr, int materialInt, string unitStr, string brandStr, int machiningLevelInt, int finishInt, int isPreferredInt, int isLongPeriodInt, int isPreciousInt, int isPreprocessingInt, int isBuyInt, string getTimeBeginStr, string getTimeEndStr, string commonStr)
        {
            string sqlStr = " 1=1";
            if (codeFileNameStr != "")
                sqlStr += string.Format(" and CodeFileName like '%{0}%'", codeFileNameStr);

            if (codeNoStr != "")
                sqlStr += string.Format(" and CodeNo like '%{0}%'", codeNoStr);

            if (codeNameStr != "")
                sqlStr += string.Format(" and CodeName like '%{0}%'", codeNameStr);

            if (codeSpecStr != "")
                sqlStr += string.Format(" and CodeSpec like '%{0}%'", codeSpecStr);

            if (materialVersionStr != "")
                sqlStr += string.Format(" and MaterialVersion like '%{0}%'", materialVersionStr);

            if (designerStr != "")
                sqlStr += string.Format(" and Designer like '%{0}%'", designerStr);

            if (catgNameStr != "")
                sqlStr += string.Format(" and CatgName='{0}'", catgNameStr);

            if (materialInt != 0)
                sqlStr += string.Format(" and Material={0}", materialInt);

            if (unitStr != "")
                sqlStr += string.Format(" and Unit='{0}'", unitStr);

            if (brandStr != "")
                sqlStr += string.Format(" and Brand='{0}'", brandStr);

            if (machiningLevelInt != 0)
                sqlStr += string.Format(" and MachiningLevel={0}", machiningLevelInt);

            if (finishInt != 0)
                sqlStr += string.Format(" and Finish={0}", finishInt);

            if (isPreferredInt != -1)
                sqlStr += string.Format(" and IsPreferred={0}", isPreferredInt);

            if (isLongPeriodInt != -1)
                sqlStr += string.Format(" and IsLongPeriod={0}", isLongPeriodInt);

            if (isPreciousInt != -1)
                sqlStr += string.Format(" and IsPrecious={0}", isPreciousInt);

            if (isPreprocessingInt != -1)
                sqlStr += string.Format(" and IsPreprocessing={0}", isPreprocessingInt);

            if (isBuyInt != -1)
                sqlStr += string.Format(" and IsNull(IsBuy,0)={0}", isBuyInt);

            if (getTimeBeginStr != "")
                sqlStr += BaseSQL.GetDateRegion_SingleColumn_WhereSql("GetTime", getTimeBeginStr, getTimeEndStr);

            if (commonStr != "")
            {
                sqlStr += string.Format(" and (CodeNo like '%{0}%' or CodeFileName like '%{0}%' or CodeName like '%{0}%' or FilePath like '%{0}%' or CatgName like '%{0}%' or CodeSpec like '%{0}%' or Brand like '%{0}%' or Unit like '%{0}%' or Designer like '%{0}%' or Tel like '%{0}%')", commonStr);
            }

            return sqlStr;
        }

        /// <summary>
        /// 批量更新零件信息
        /// </summary>
        public int QueryPartsCode(string queryWhereSqlStr)
        {
            string sqlStr = string.Format("select Count(*) from SW_PartsCode where {0}", queryWhereSqlStr);
            return DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
        }

        /// <summary>
        /// 批量更新零件信息
        /// </summary>
        public void UpdatePartsCode(string setSqlStr, string queryWhereSqlStr)
        {
            string sqlStr = string.Format("Update SW_PartsCode set {0} where {1}", setSqlStr, queryWhereSqlStr);
            BaseSQL.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 全部零件查询的SQL
        /// </summary>
        public string GetQueryPartsCodeSQL_Standard()
        {
            return "select * from SW_PartsCode order by AutoId";
        }

        /// <summary>
        /// 指定零件编号查询的SQL
        /// </summary>
        public string GetQueryPartsCodeSQL_CodeFileName(string codeFileNameStr)
        {
            return string.Format("select * from SW_PartsCode where CodeFileName = '{0}' order by AutoId", codeFileNameStr);
        }

        /// <summary>
        /// 按照条件查询的SQL
        /// </summary>
        public string GetQueryPartsCodeSQL_WhereSQL(string queryWhereSqlStr)
        {
            return string.Format("select * from SW_PartsCode where {0} order by AutoId", queryWhereSqlStr);
        }
    }
}
