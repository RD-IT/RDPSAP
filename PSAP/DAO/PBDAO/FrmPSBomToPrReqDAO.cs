using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.PBDAO
{
    class FrmPSBomToPrReqDAO
    {
        ///// <summary>
        ///// 根据销售订单得到项目号
        ///// </summary>
        //public string GetProjectNo(string salesOrderNoStr)
        //{
        //    string sqlStr = string.Format("select ProjectNo from SA_SalesOrder where AutoSalesOrderNo = '{0}'", salesOrderNoStr);
        //    return DataTypeConvert.GetString(BaseSQL.GetSingle(sqlStr));
        //}

        /// <summary>
        /// 查询未生成请购单的生产计划信息
        /// </summary>
        public DataTable Query_NoPr_PSBom(string pbBomNoStr, int bomListAutoIdInt)
        {
            string sqlStr = string.Format("select PSBom.AutoId, PSBom.MaterielNo, CodeName, PlanDate, PSBom.RemainQty from PB_ProductionScheduleBom as PSBom left join PB_DesignBomList on PSBom.BomListAutoId = PB_DesignBomList.AutoId left join SW_PartsCode on PSBom.MaterielNo = SW_PartsCode.CodeFileName where PSBom.PbBomNo = '{0}' and PSBom.IsBuy = 1 and ISNULL(PSBom.PrReqNo, '') = '' and ISNULL(IsMaterial, 1) = 1 and ({1} = 0 or PSBom.BomListAutoId = {1})", pbBomNoStr, bomListAutoIdInt);
            return BaseSQL.Query(sqlStr).Tables[0];
        }

        /// <summary>
        /// 保存生产计划生成请购单
        /// </summary>
        public bool Save_PSBomToPrReq(string salesOrderNoStr, string pbBomNoStr, int bomListAutoIdInt, string projectNoStr, string stnNoStr, string departmentNoStr, string purCategoryStr, string approvalTypeStr)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        int resultInt = 0;
                        string errorText = "";

                        string prReqNoStr = BaseSQL.GetMaxCodeNo(cmd, "PR");

                        SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                        SqlParameter p1 = new SqlParameter("@PbBomNo", SqlDbType.VarChar);
                        p1.Value = pbBomNoStr;
                        SqlParameter p2 = new SqlParameter("@BomListAutoId", SqlDbType.Int);
                        p2.Value = bomListAutoIdInt;
                        SqlParameter p3 = new SqlParameter("@PrReqNo", SqlDbType.VarChar);
                        p3.Value = prReqNoStr;
                        SqlParameter p4 = new SqlParameter("@ProjectNo", SqlDbType.VarChar);
                        p4.Value = projectNoStr;
                        SqlParameter p5 = new SqlParameter("@StnNo", SqlDbType.VarChar);
                        p5.Value = stnNoStr;

                        SqlParameter p6 = new SqlParameter("@DepartmentNo", SqlDbType.VarChar);
                        p6.Value = departmentNoStr;
                        SqlParameter p7 = new SqlParameter("@PurCategory", SqlDbType.VarChar);
                        p7.Value = purCategoryStr;
                        SqlParameter p8 = new SqlParameter("@ApprovalType", SqlDbType.VarChar);
                        p8.Value = approvalTypeStr;
                        SqlParameter p9 = new SqlParameter("@Creator", SqlDbType.Int);
                        p9.Value = SystemInfo.user.AutoId;
                        SqlParameter p10 = new SqlParameter("@PreparedIp", SqlDbType.VarChar);
                        p10.Value = SystemInfo.HostIpAddress;

                        IDataParameter[] parameters = new IDataParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
                        BaseSQL.RunProcedure(cmd_proc, "P_PSBomToPrReq", parameters, out resultInt, out errorText);
                        if (resultInt != 1)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("生产计划生成请购单错误--" + errorText);
                            return false;
                        }

                        string logStr = string.Format("制作Bom [{0}] 的生产计划生成请购单 [{1}]。", pbBomNoStr, prReqNoStr);
                        LogHandler.RecordLog(cmd, logStr);

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


    }
}
