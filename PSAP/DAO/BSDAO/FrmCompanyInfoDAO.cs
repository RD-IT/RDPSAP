using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using PSAP.PSAPCommon;

namespace PSAP.DAO.BSDAO
{
    class FrmCompanyInfoDAO
    {
        /// <summary>
        /// 刷新企业信息
        /// </summary>
        public void RefreshCompanyInfo()
        {
            DataTable companyInfoTable = new DataTable();
            QueryCompanyInfo(companyInfoTable);
            if (companyInfoTable.Rows.Count > 0)
            {
                string tmpStr = DataTypeConvert.GetString(companyInfoTable.Rows[0]["CompanyName"]);
                if (tmpStr != "")
                    SystemInfo.CompanyName = tmpStr;

                tmpStr = DataTypeConvert.GetString(companyInfoTable.Rows[0]["CompanyAddress"]);
                if (tmpStr != "")
                    SystemInfo.CompAddress = tmpStr;

                tmpStr = DataTypeConvert.GetString(companyInfoTable.Rows[0]["ZipCode"]);
                if (tmpStr != "")
                    SystemInfo.CompZipCode = tmpStr;

                tmpStr = DataTypeConvert.GetString(companyInfoTable.Rows[0]["PhoneNo"]);
                if (tmpStr != "")
                    SystemInfo.CompTel = tmpStr;

                tmpStr = DataTypeConvert.GetString(companyInfoTable.Rows[0]["FaxNo"]);
                if (tmpStr != "")
                    SystemInfo.CompFax = tmpStr;

                tmpStr = DataTypeConvert.GetString(companyInfoTable.Rows[0]["E_mail"]);
                if (tmpStr != "")
                    SystemInfo.CompE_Mail = tmpStr;

                tmpStr = DataTypeConvert.GetString(companyInfoTable.Rows[0]["WebSite"]);
                if (tmpStr != "")
                    SystemInfo.CompWebSite = tmpStr;
            }
        }

        /// <summary>
        /// 查询公司信息表
        /// </summary>
        public void QueryCompanyInfo(DataTable queryDataTable)
        {
            string sqlStr = "select * from BS_CompanyInfo";
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 保存公司信息表
        /// </summary>
        public bool SaveCompanyInfo(DataRow headRow)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        string logStr = LogHandler.RecordLog_DataRow(cmd, "公司信息", headRow, "AutoId");

                        cmd.CommandText = "select * from BS_CompanyInfo";
                        DataTable companyInfoTable = BaseSQL.GetTableBySql(cmd);
                        if (companyInfoTable.Rows.Count > 0)
                        {
                            if (headRow.RowState == DataRowState.Modified && DataTypeConvert.GetString(companyInfoTable.Rows[0]["AutoId"]) != DataTypeConvert.GetString(headRow["AutoId"]))
                            {
                                string CompanyName = DataTypeConvert.GetString(headRow["CompanyName"]);
                                string CompanyAddress = DataTypeConvert.GetString(headRow["CompanyAddress"]);
                                string CompanyLR = DataTypeConvert.GetString(headRow["CompanyLR"]);
                                string CompanyLicense = DataTypeConvert.GetString(headRow["CompanyLicense"]);
                                string ZipCode = DataTypeConvert.GetString(headRow["ZipCode"]);
                                string PhoneNo = DataTypeConvert.GetString(headRow["PhoneNo"]);
                                string FaxNo = DataTypeConvert.GetString(headRow["FaxNo"]);
                                string E_mail = DataTypeConvert.GetString(headRow["E_mail"]);
                                string WebSite = DataTypeConvert.GetString(headRow["WebSite"]);

                                cmd.CommandText = string.Format("Update BS_CompanyInfo set CompanyName = '{1}', CompanyAddress = '{2}', CompanyLR = '{3}', CompanyLicense = '{4}', ZipCode = '{5}', PhoneNo = '{6}', FaxNo = '{7}', E_mail = '{8}', WebSite = '{9}' where AutoId = '{0}'", DataTypeConvert.GetString(companyInfoTable.Rows[0]["AutoId"]), CompanyName, CompanyAddress, CompanyLR, CompanyLicense, ZipCode, PhoneNo, FaxNo, E_mail, WebSite);
                                cmd.ExecuteNonQuery();
                                trans.Commit();
                                return true;
                            }
                        }

                        cmd.CommandText = "select * from BS_CompanyInfo where 1=2";
                        SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                        DataTable tmpHeadTable = new DataTable();
                        adapterHead.Fill(tmpHeadTable);
                        BaseSQL.UpdateDataTable(adapterHead, headRow.Table);

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        headRow.Table.RejectChanges();
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }


    }
}
