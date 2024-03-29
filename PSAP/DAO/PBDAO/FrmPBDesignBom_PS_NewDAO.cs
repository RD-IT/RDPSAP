﻿using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.PBDAO
{
    class FrmPBDesignBom_PS_NewDAO
    {
        /// <summary>
        /// 查询销售订单信息
        /// </summary>
        public DataTable QuerySalesOrder(string salesOrderNoStr)
        {
            string sqlStr = string.Format("select AutoSalesOrderNo, ProjectNo, ProjectName from SA_SalesOrder where AutoSalesOrderNo = '{0}'", salesOrderNoStr);
            return BaseSQL.Query(sqlStr).Tables[0];
        }

        /// <summary>
        /// 查询零件信息
        /// </summary>
        public void QueryPartsCode(DataTable queryDataTable, int codeIdInt, string codeNameStr, string catgNameStr, string brandStr)
        {
            string sqlStr = " 1=1";
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and AutoId = '{0}'", codeIdInt);
            }
            if (codeNameStr != "")
            {
                sqlStr += string.Format(" and CodeName like '%{0}%'", codeNameStr);
            }
            if (catgNameStr != "")
            {
                sqlStr += string.Format(" and CatgName = '{0}'", catgNameStr);
            }
            if (brandStr != "")
            {
                sqlStr += string.Format(" and Brand = '{0}'", brandStr);
            }

            sqlStr = string.Format("select AutoId, CodeNo, CodeFileName, CodeName, CatgName, CodeSpec, CodeWeight, Material, Brand, Unit, IsPreferred,  IsLongPeriod, IsPrecious, IsPreprocessing, Designer, GetTime, IsBuy from SW_PartsCode where {0} order by AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询单个Bom的树形更多信息
        /// </summary>
        public DataTable QueryBomInfo_Single(string materielNoStr)
        {
            string sqlStr = string.Format("select bom.*, SW_PartsCode.CodeName, SW_PartsCode.AutoId as PCAutoId, SW_PartsCode.Brand, SW_PartsCode.CatgName, SW_PartsCode.CodeSpec, SW_PartsCode.Unit, BS_BomMaterieState.MaterieStateText from F_BomMateriel_TreeRelation('{0}') as bom left join SW_PartsCode on bom.CodeFileName = SW_PartsCode.CodeFileName left join BS_BomManagement on bom.CodeFileName = BS_BomManagement.MaterielNo left join BS_BomMaterieState on BS_BomMaterieState.MaterieStateId = BS_BomManagement.MaterieStateId Order by CodeFileName", materielNoStr);
            return BaseSQL.Query(sqlStr).Tables[0];
        }

        /// <summary>
        /// 查询BOM的根节点信息
        /// </summary>
        public DataTable QueryBomInfo_OnlyRoot(string codeFileNameStr, string codeNameStr, string catgNameStr, string brandStr)
        {
            string sqlStr = " 1=1";
            if (codeFileNameStr != "")
            {
                sqlStr += string.Format(" and CodeFileName = '{0}'", codeFileNameStr);
            }
            if (codeNameStr != "")
            {
                sqlStr += string.Format(" and CodeName like '%{0}%'", codeNameStr);
            }
            if (catgNameStr != "")
            {
                sqlStr += string.Format(" and CatgName = '{0}'", catgNameStr);
            }
            if (brandStr != "")
            {
                sqlStr += string.Format(" and Brand = '{0}'", brandStr);
            }

            sqlStr = string.Format("select ('/' + Cast(PartsCodeId as varchar(max)) + '/') as ReID, Cast('' as varchar(max)) as ReParent, MaterielNo as CodeFileName, Cast('' as varchar(200)) as ParentCodeFileName, 1 as Qty, SW_PartsCode.CodeName, SW_PartsCode.AutoId as PCAutoId, SW_PartsCode.Brand, SW_PartsCode.CatgName, SW_PartsCode.CodeSpec, SW_PartsCode.Unit, BS_BomMaterieState.MaterieStateText from BS_BomManagement as bom left join SW_PartsCode on bom.MaterielNo = SW_PartsCode.CodeFileName left join BS_BomMaterieState on BS_BomMaterieState.MaterieStateId = bom.MaterieStateId where MaterielNo in (select CodeFileName from SW_PartsCode where {0}) and MaterielNo in (select MaterielNo from BS_BomMateriel) Order by MaterielNo", sqlStr);
            return BaseSQL.Query(sqlStr).Tables[0];
        }

        /// <summary>
        /// 查询BOM的子节点信息
        /// </summary>
        public void QueryBomInfo_OnlyLeaf(DataTable queryDataTable, string codeFileNameStr)
        {
            string sqlStr = string.Format("select bom.*, SW_PartsCode.CodeName, SW_PartsCode.AutoId as PCAutoId, SW_PartsCode.Brand, SW_PartsCode.CatgName, SW_PartsCode.CodeSpec, SW_PartsCode.Unit, BS_BomMaterieState.MaterieStateText from F_BomMateriel_TreeRelation('{0}') as bom left join SW_PartsCode on bom.CodeFileName = SW_PartsCode.CodeFileName left join BS_BomManagement on bom.CodeFileName = BS_BomManagement.MaterielNo left join BS_BomMaterieState on BS_BomMaterieState.MaterieStateId = BS_BomManagement.MaterieStateId where bom.CodeFileName != '{0}' Order by bom.CodeFileName", codeFileNameStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询设计Bom的树类型信息
        /// </summary>
        public void QueryDesignBomTree(DataTable queryDataTable, string salesOrderNoStr, int IsUse)
        {
            string sqlStr = "";
            if (IsUse >= 0)
            {
                sqlStr += string.Format(" and IsUse = {0}", IsUse);
            }
            sqlStr = string.Format("select * from V_PB_DesignBom_Tree where SalesOrderNo = '{0}' {1} Order by ReId", salesOrderNoStr, sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询包含某个零件的设计Bom的树类型信息
        /// </summary>
        public void QueryDesignBomTree_CodeFileName(DataTable queryDataTable, string salesOrderNoStr, string codeFileNameStr)
        {
            string sqlStr = string.Format("select * from V_PB_DesignBom_Tree where SalesOrderNo = '{0}' and PbBomNo in (select PbBomNo from PB_DesignBomList where MaterielNo in ({1}) or LevelMaterielNo in ({1})) Order by ReId", salesOrderNoStr, codeFileNameStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 根据Id查询制作Bom信息的单条信息
        /// </summary>
        public void QueryDesignBomList(DataTable queryDataTable, int autoIdInt)
        {
            string sqlStr = string.Format("select PB_DesignBomList.*, case when ParentId = 0 then pc1.CodeName else pc2.CodeName end as CodeName, case when ParentId = 0 then MaterielNo else LevelMaterielNo end as CodeFileName, case when ParentId = 0 then pc1.AutoId else pc2.AutoId end as CodeAutoId from PB_DesignBomList left join SW_PartsCode as pc1 on PB_DesignBomList.MaterielNo = pc1.CodeFileName left join SW_PartsCode as pc2 on PB_DesignBomList.LevelMaterielNo = pc2.CodeFileName where PB_DesignBomList.AutoId = {0}", autoIdInt);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询基本工序信息
        /// </summary>
        public void QueryWorkProcess(DataTable queryDataTable, string workProcessNoStr, string commonStr)
        {
            string sqlStr = " 1=1";
            if (workProcessNoStr!="")
            {
                sqlStr += string.Format(" and WorkProcessNo = '{0}'", workProcessNoStr);
            }
            if(commonStr!="")
            {
                sqlStr += string.Format(" and (WorkProcessNo like '%{0}%' or WorkProcessText like '%{0}%' or Remark like '%{0}%')", commonStr);
            }
            sqlStr = string.Format("select * from BS_WorkProcess where {0}", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 保存设计Bom信息
        /// </summary>
        public bool SaveDesignBom(string salesOrderNoStr, Dictionary<int, string> codeIdList, float qty, int isBuyInt)
        {
            bool result = false;

            foreach (int codeId in codeIdList.Keys)
            {
                string sqlStr = string.Format("select Count(*) from BS_BomMateriel left join SW_PartsCode on BS_BomMateriel.MaterielNo = SW_PartsCode.CodeFileName where SW_PartsCode.AutoId = {0}                ", codeId);
                int count = DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
                if (count == 0)//按照零件进行录入
                {
                    if (SaveDesignBom_PartsCode(salesOrderNoStr, codeId, codeIdList[codeId], qty, isBuyInt))
                        result = true;
                }
                else//按照Bom进行录入
                {
                    if (SaveDesignBom_Bom(salesOrderNoStr, codeId, codeIdList[codeId], qty, isBuyInt))
                        result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// 保存设计Bom信息处理零件方法
        /// </summary>
        private bool SaveDesignBom_PartsCode(string salesOrderNoStr, int codeIdInt, string codeFileNameStr, float qty, int isBuyInt)
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

                        string logStr = string.Format("设计Bom信息增加零件[{0}]，数量为[{1}]。", codeFileNameStr, qty);
                        LogHandler.RecordLog(cmd, logStr);

                        cmd.CommandText = string.Format("select * from PB_DesignBomList where SalesOrderNo = '{0}' and CodeId = {1} and RemainQty > 0 and ParentId = 0", salesOrderNoStr, codeIdInt);
                        DataTable bomMagTable = BaseSQL.GetTableBySql(cmd);
                        if (bomMagTable.Rows.Count > 0)//更新数量
                        {
                            if (qty < 0)
                            {
                                if (DataTypeConvert.GetDouble(bomMagTable.Rows[0]["RemainQty"]) + qty < 0)
                                {
                                    MessageHandler.ShowMessageBox("零件或者Bom增加数量后必须大于等于0，请重新操作。");
                                    return false;
                                }
                            }
                            string pbbomno = DataTypeConvert.GetString(bomMagTable.Rows[0]["PbBomNo"]);

                            SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                            SqlParameter p1 = new SqlParameter("@PbBomNo", SqlDbType.VarChar);
                            p1.Value = pbbomno;
                            SqlParameter p2 = new SqlParameter("@Qty", SqlDbType.Float);
                            p2.Value = qty;
                            IDataParameter[] parameters = new IDataParameter[] { p1, p2 };
                            BaseSQL.RunProcedure(cmd_proc, "P_DesignBom_Parts_UpdateQty", parameters, out resultInt, out errorText);
                            if (resultInt != 1)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("设计Bom更新零件信息错误--" + errorText);
                                return false;
                            }
                        }
                        else//新增记录
                        {
                            string pbBomNo = BaseSQL.GetMaxCodeNo(cmd, "PB");

                            SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                            SqlParameter p1 = new SqlParameter("@SalesOrderNo", SqlDbType.VarChar);
                            p1.Value = salesOrderNoStr;
                            SqlParameter p2 = new SqlParameter("@PbBomNo", SqlDbType.VarChar);
                            p2.Value = pbBomNo;
                            SqlParameter p3 = new SqlParameter("@CodeId", SqlDbType.Int);
                            p3.Value = codeIdInt;
                            SqlParameter p4 = new SqlParameter("@CodeFileName", SqlDbType.VarChar);
                            p4.Value = codeFileNameStr;
                            SqlParameter p5 = new SqlParameter("@Qty", SqlDbType.Float);
                            p5.Value = qty;
                            SqlParameter p6 = new SqlParameter("@Creator", SqlDbType.Int);
                            p6.Value = SystemInfo.user.AutoId;
                            SqlParameter p7 = new SqlParameter("@PreparedIp", SqlDbType.VarChar);
                            p7.Value = SystemInfo.HostIpAddress;
                            SqlParameter p8 = new SqlParameter("@IsBuy", SqlDbType.Int);
                            p8.Value = isBuyInt;
                            IDataParameter[] parameters = new IDataParameter[] { p1, p2, p3, p4, p5, p6, p7, p8 };
                            BaseSQL.RunProcedure(cmd_proc, "P_DesignBom_Parts_Insert", parameters, out resultInt, out errorText);
                            if (resultInt != 1)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("设计Bom新增零件信息错误--" + errorText);
                                return false;
                            }
                        }

                        //没有被动吸收 被其他Bom吸收

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
        /// 保存设计Bom信息处理Bom方法
        /// </summary>
        private bool SaveDesignBom_Bom(string salesOrderNoStr, int codeIdInt, string codeFileNameStr, float qty, int isBuyInt)
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

                        string pbBomNo = "";

                        string logStr = string.Format("设计Bom信息增加Bom[{0}]，数量为[{1}]。", codeFileNameStr, qty);
                        LogHandler.RecordLog(cmd, logStr);

                        cmd.CommandText = string.Format("select * from PB_DesignBomList where SalesOrderNo = '{0}' and CodeId = {1} and RemainQty > 0 and ParentId = 0", salesOrderNoStr, codeIdInt);
                        DataTable bomMagTable = BaseSQL.GetTableBySql(cmd);
                        if (bomMagTable.Rows.Count > 0)//更新数量
                        {
                            if (qty < 0)
                            {
                                if (DataTypeConvert.GetDouble(bomMagTable.Rows[0]["RemainQty"]) + qty < 0)
                                {
                                    MessageHandler.ShowMessageBox("Bom修改后的数量必须大于等于0。");
                                    return false;
                                }
                            }
                            pbBomNo = DataTypeConvert.GetString(bomMagTable.Rows[0]["PbBomNo"]);

                            SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                            SqlParameter p1 = new SqlParameter("@PbBomNo", SqlDbType.VarChar);
                            p1.Value = pbBomNo;
                            SqlParameter p2 = new SqlParameter("@Qty", SqlDbType.Float);
                            p2.Value = qty;
                            IDataParameter[] updateParas = new IDataParameter[] { p1, p2 };
                            BaseSQL.RunProcedure(cmd_proc, "P_DesignBom_Bom_UpdateQty", updateParas, out resultInt, out errorText);
                            if (resultInt != 1)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("设计Bom更新Bom信息错误--" + errorText);
                                return false;
                            }
                        }
                        else//新增记录
                        {
                            pbBomNo = BaseSQL.GetMaxCodeNo(cmd, "PB");

                            SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                            SqlParameter p1 = new SqlParameter("@SalesOrderNo", SqlDbType.VarChar);
                            p1.Value = salesOrderNoStr;
                            SqlParameter p2 = new SqlParameter("@PbBomNo", SqlDbType.VarChar);
                            p2.Value = pbBomNo;
                            SqlParameter p3 = new SqlParameter("@CodeId", SqlDbType.Int);
                            p3.Value = codeIdInt;
                            SqlParameter p4 = new SqlParameter("@CodeFileName", SqlDbType.VarChar);
                            p4.Value = codeFileNameStr;
                            SqlParameter p5 = new SqlParameter("@Qty", SqlDbType.Float);
                            p5.Value = qty;
                            SqlParameter p6 = new SqlParameter("@Creator", SqlDbType.Int);
                            p6.Value = SystemInfo.user.AutoId;
                            SqlParameter p7 = new SqlParameter("@PreparedIp", SqlDbType.VarChar);
                            p7.Value = SystemInfo.HostIpAddress;
                            SqlParameter p8 = new SqlParameter("@IsBuy", SqlDbType.Int);
                            p8.Value = isBuyInt;
                            IDataParameter[] insertParas = new IDataParameter[] { p1, p2, p3, p4, p5, p6, p7, p8 };
                            BaseSQL.RunProcedure(cmd_proc, "P_DesignBom_Bom_Insert", insertParas, out resultInt, out errorText);
                            if (resultInt != 1)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("设计Bom新增Bom信息错误--" + errorText);
                                return false;
                            }
                        }

                        //进行吸收其他Bom和零件
                        SqlCommand cmd_Absorb = new SqlCommand("", conn, trans);
                        SqlParameter p1_Absorb = new SqlParameter("@SalesOrderNo", SqlDbType.VarChar);
                        p1_Absorb.Value = salesOrderNoStr;
                        SqlParameter p2_Absorb = new SqlParameter("@PbBomNo", SqlDbType.VarChar);
                        p2_Absorb.Value = pbBomNo;
                        SqlParameter p3_Absorb = new SqlParameter("@MainBomAutoId", SqlDbType.Int);
                        p3_Absorb.Value = 0;
                        SqlParameter p4_Absorb = new SqlParameter("@ParentId", SqlDbType.Int);
                        p4_Absorb.Value = 0;
                        SqlParameter p5_Absorb = new SqlParameter("@OpQty", SqlDbType.Float);
                        p5_Absorb.Value = qty;
                        IDataParameter[] parameters = new IDataParameter[] { p1_Absorb, p2_Absorb, p3_Absorb, p4_Absorb, p5_Absorb };
                        BaseSQL.RunProcedure(cmd_Absorb, "P_DesignBom_Bom_Absorbed", parameters, out resultInt, out errorText);
                        if (resultInt != 1)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("设计Bom吸收Bom和零件数量错误--" + errorText);
                            return false;
                        }
                        //没有被动吸收 被其他Bom吸收

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
        /// 删除设计Bom信息
        /// </summary>
        public int DeleteDesignBom(string salesOrderNoStr, List<string> pbBomNoList)
        {
            int countInt = 0;
            foreach (string pbBomNoStr in pbBomNoList)
            {
                string sqlStr = string.Format("select * from PB_DesignBomList where SalesOrderNo = '{0}' and PbBomNo = '{1}' and ParentId = 0", salesOrderNoStr, pbBomNoStr);
                DataTable bomTable = BaseSQL.Query(sqlStr).Tables[0];
                if (bomTable.Rows.Count == 0)
                {
                    MessageHandler.ShowMessageBox(string.Format("未查询到当前要操作的设计Bom信息[{0}]，请查询后重新操作。", pbBomNoStr));
                    return 0;
                }
                //else
                //{
                //    int hasLevelInt = DataTypeConvert.GetInt(bomTable.Rows[0]["HasLevel"]);
                //    if (hasLevelInt == 0)
                //    {
                //        if (DeleteDesignBom_PartsCode(salesOrderNoStr, pbBomNoStr))
                //            countInt++;
                //        else
                //            return countInt;
                //    }
                //    else
                //    {
                //        if (DeleteDesignBom_Bom(salesOrderNoStr, pbBomNoStr))
                //            countInt++;
                //        else
                //            return countInt;
                //    }
                //}
            }


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
                        foreach (string pbBomNoStr in pbBomNoList)
                        {
                            cmd.CommandText = string.Format("select COUNT(*) from V_PB_ProductionPlanList_All where DesignBomListId in (select AutoId from PB_DesignBomList where PbBomNo = '{0}')", pbBomNoStr);
                            if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox(string.Format("设计Bom信息[{0}]已经生成工单，不可以删除。", pbBomNoStr));
                                return 0;
                            }

                            string logStr = string.Format("删除设计Bom信息[{0}]。", pbBomNoStr);
                            LogHandler.RecordLog(cmd, logStr);

                            SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                            SqlParameter p1 = new SqlParameter("@SalesOrderNo", SqlDbType.VarChar);
                            p1.Value = salesOrderNoStr;
                            SqlParameter p2 = new SqlParameter("@PbBomNo", SqlDbType.VarChar);
                            p2.Value = pbBomNoStr;
                            IDataParameter[] updateParas = new IDataParameter[] { p1, p2 };
                            BaseSQL.RunProcedure(cmd_proc, "P_DesignBom_Delete", updateParas, out resultInt, out errorText);
                            if (resultInt != 1)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("设计Bom删除信息错误--" + errorText);
                                return 0;
                            }
                        }
                        trans.Commit();
                        countInt = pbBomNoList.Count;
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

            return countInt;
        }

        /// <summary>
        /// 停用设计Bom信息
        /// </summary>
        public bool StopDesignBom(string salesOrderNoStr, List<string> pbBomNoList)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        string pbBomNoStr = "";
                        foreach (string pbBomNo in pbBomNoList)
                        {
                            cmd.CommandText = string.Format("select COUNT(*) from V_PB_ProductionPlanList_All where DesignBomListId in (select AutoId from PB_DesignBomList where PbBomNo = '{0}')", pbBomNoStr);
                            if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox(string.Format("设计Bom信息[{0}]已经生成工单，不可以停用。", pbBomNoStr));
                                return false;
                            }

                            string logStr = string.Format("设计Bom信息[{0}]停用。", pbBomNo);
                            LogHandler.RecordLog(cmd, logStr);
                            pbBomNoStr += string.Format("'{0}',", pbBomNo);

                            cmd.CommandText = string.Format("select Count(*) from PB_ProductionScheduleBom where BomListAutoId in (select AutoId from PB_DesignBomList where PbBomNo = '{0}')", pbBomNo);
                            int count = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox(string.Format("设计Bom信息[{0}]已经设定了生产计划，不可以停用。", pbBomNo));
                                return false;
                            }
                        }

                        cmd.CommandText = string.Format("Update PB_DesignBomList set IsUse = 0 where PbBomNo in ({0})", pbBomNoStr.Substring(0, pbBomNoStr.Length - 1));
                        cmd.ExecuteNonQuery();

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
        /// 恢复设计Bom信息
        /// </summary>
        public bool RecoverDesignBom(string salesOrderNoStr, List<string> pbBomNoList)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        string pbBomNoStr = "";
                        foreach (string pbBomNo in pbBomNoList)
                        {
                            string logStr = string.Format("设计Bom信息[{0}]恢复停用。", pbBomNo);
                            LogHandler.RecordLog(cmd, logStr);
                            pbBomNoStr += string.Format("'{0}',", pbBomNo);
                        }

                        cmd.CommandText = string.Format("Update PB_DesignBomList set IsUse = 1 where PbBomNo in ({0})", pbBomNoStr.Substring(0, pbBomNoStr.Length - 1));
                        cmd.ExecuteNonQuery();

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
        /// 查询生产计划Bom的树类型信息
        /// </summary>
        public void QueryProductionScheduleBomTree(DataTable queryDataTable, string salesOrderNoStr)
        {
            string sqlStr = "";
            sqlStr = string.Format("select * from V_PB_ProductionScheduleBom_Tree where SalesOrderNo = '{0}' {1} Order by ReId", salesOrderNoStr, sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询生产计划信息
        /// </summary>
        public void QueryProductionScheduleBom(DataTable queryDataTable, string salesOrderNoStr, int bomListAutoId)
        {
            string sqlStr = string.Format(" SalesOrderNo = '{0}' and RemainQty > 0", salesOrderNoStr);
            if (bomListAutoId != 0)
            {
                sqlStr += string.Format(" and BomListAutoId = {0}", bomListAutoId);
            }
            sqlStr = string.Format("select bom.AutoId, bom.BomListAutoId, bom.MaterielNo as CodeFileName, case when IsNull(CodeName, '') != '' then CodeName else wp.WorkProcessText end as CodeName, PbBomNo, RemainQty, PlanDate, bom.IsBuy, PrReqNo, case when IsNull(absorb.AutoId, 0) = 0 then 0 else 1 end IsAbsorb from PB_ProductionScheduleBom as bom left join SW_PartsCode as pc on bom.MaterielNo = pc.CodeFileName left join BS_WorkProcess as wp on bom.MaterielNo = wp.WorkProcessNo left join PB_ScheduleAbsorbe as absorb on bom.AutoId = absorb.MainAutoId where {0} Order by bom.AutoId", sqlStr);

            //sqlStr = string.Format("select bom.AutoId, bom.BomListAutoId, bom.MaterielNo as CodeFileName, CodeName, PbBomNo, RemainQty, PlanDate, IsAll from PB_ProductionScheduleBom as bom left join SW_PartsCode as pc on bom.MaterielNo = pc.CodeFileName where {0} union all select bom.AutoId, bom.BomListAutoId, bom.MaterielNo as CodeFileName, CodeName, PbBomNo, RemainQty, PlanDate, IsAll from PB_ProductionScheduleBom as bom left join SW_PartsCode as pc on bom.MaterielNo = pc.CodeFileName where bom.BomListAutoId in (select AbsorbedAutoId from DesignBomListAbsorbe where MainAutoId = {1})", sqlStr, bomListAutoId);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询生产计划信息
        /// </summary>
        public void QueryProductionScheduleBom_HaveChildren(DataTable queryDataTable, string salesOrderNoStr, int bomListAutoId)
        {
            //string sqlStr = string.Format("with cte as ( select list.AutoId from PB_DesignBomList as list where AutoId = {1} and SalesOrderNo = '{0}' union all select list.AutoId from cte join PB_DesignBomList as list on cte.AutoId = list.ParentId ) select bom.AutoId, BomListAutoId, MaterielNo as CodeFileName, CodeName, PbBomNo, RemainQty, PlanDate, bom.IsBuy, case when IsNull(absorb.AutoId, 0) = 0 then 0 else 1 end IsAbsorb from PB_ProductionScheduleBom as bom left join SW_PartsCode as pc on bom.MaterielNo = pc.CodeFileName left join PB_ScheduleAbsorbe as absorb on bom.AutoId = absorb.MainAutoId where BomListAutoId in (select AutoId from cte) and RemainQty > 0 Order by BomListAutoId,bom.AutoId", salesOrderNoStr, bomListAutoId);

            string sqlStr = string.Format("with cte as (select list.AutoId from PB_DesignBomList as list where AutoId = {1} and SalesOrderNo = '{0}' union all select list.AutoId from cte join PB_DesignBomList as list on cte.AutoId = list.ParentId ) select bom.AutoId, BomListAutoId, MaterielNo as CodeFileName, case when IsNull(CodeName, '') != '' then CodeName else wp.WorkProcessText end as CodeName, PbBomNo, RemainQty, PlanDate, bom.IsBuy, PrReqNo, case when IsNull(absorb.AutoId, 0) = 0 then 0 else 1 end IsAbsorb from PB_ProductionScheduleBom as bom left join SW_PartsCode as pc on bom.MaterielNo = pc.CodeFileName left join BS_WorkProcess as wp on bom.MaterielNo = wp.WorkProcessNo left join PB_ScheduleAbsorbe as absorb on bom.AutoId = absorb.MainAutoId where BomListAutoId in (select AutoId from cte) and RemainQty > 0 Order by BomListAutoId,bom.AutoId", salesOrderNoStr, bomListAutoId);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        ///// <summary>
        ///// 查询销售订单的全部生产计划
        ///// </summary>
        //public void QueryProductionScheduleBom_All(DataTable queryDataTable, string salesOrderNoStr)
        //{
        //    string sqlStr = string.Format("select bom.AutoId, bom.BomListAutoId, bom.MaterielNo as CodeFileName, CodeName, PbBomNo, RemainQty, PlanDate, IsAll from PB_ProductionScheduleBom as bom left join SW_PartsCode as pc on bom.MaterielNo = pc.CodeFileName where SalesOrderNo = '{0}' Order by bom.AutoId", salesOrderNoStr);
        //    BaseSQL.Query(sqlStr, queryDataTable);
        //}

        /// <summary>
        /// 查询设计Bom的单条信息
        /// </summary>
        public void QueryDesignBomList(DataTable queryDataTable, int autoIdInt, int psBomAutoId)
        {
            string sqlStr = string.Format("select *, (Select IsNull(Sum(RemainQty), 0) from PB_ProductionScheduleBom where PB_ProductionScheduleBom.BomListAutoId = PB_DesignBomList.AutoId and AutoId != {1}) as PSBomRemainQty from PB_DesignBomList where AutoId = {0}", autoIdInt, psBomAutoId);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询生产计划的单条信息
        /// </summary>
        public DataTable QueryProductionScheduleBom(int autoIdInt)
        {
            string sqlStr = string.Format("select * from PB_ProductionScheduleBom where AutoId = {0}", autoIdInt);
            return BaseSQL.Query(sqlStr).Tables[0];
        }

        /// <summary>
        /// 保存生产计划Bom信息
        /// </summary>
        public bool SaveProductionScheduleBom(int bomListAutoId, int psBomAutoId, int isAll, DateTime planDate, double remainQty, int isBuy, int isChildLevel)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("select Count(*) from PB_ScheduleAbsorbe where MainAutoId in ({0})", psBomAutoId);
                        int count = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            if (MessageHandler.ShowMessageBox_YesNo("当前选中的生产计划记录是吸收的生产计划记录，是否继续修改？") != System.Windows.Forms.DialogResult.Yes)
                            {
                                trans.Rollback();
                                return false;
                            }
                        }

                        cmd.CommandText = string.Format("Select PrReqNo from PB_ProductionScheduleBom where AutoId = {0}", psBomAutoId);
                        if(DataTypeConvert.GetString(cmd.ExecuteScalar())!="")
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("当前修改的生产计划信息已经生成请购单，不可以进行操作。");
                            return false;
                        }

                        int resultInt = 0;
                        string errorText = "";
                        string logStr = string.Format("保存生产计划Bom信息：[BomListAutoId]的值[{0}],[是否统一]的值[{1}],[需求日期]的值[{2}],[需求数量]的值[{3}],[是否购买]的值[{4}]。", bomListAutoId, isAll, planDate.ToString("yyyy-MM-dd"), remainQty, isBuy);
                        LogHandler.RecordLog(cmd, logStr);

                        SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                        SqlParameter p1 = new SqlParameter("@BomListAutoId", SqlDbType.Int);
                        p1.Value = bomListAutoId;
                        SqlParameter p2 = new SqlParameter("@AutoId", SqlDbType.Int);
                        p2.Value = psBomAutoId;
                        SqlParameter p3 = new SqlParameter("@IsAll", SqlDbType.Int);
                        p3.Value = isAll;
                        SqlParameter p4 = new SqlParameter("@PlanDate", SqlDbType.DateTime);
                        p4.Value = planDate;
                        SqlParameter p5 = new SqlParameter("@RemainQty", SqlDbType.Float);
                        p5.Value = remainQty;
                        SqlParameter p6 = new SqlParameter("@IsBuy", SqlDbType.Int);
                        p6.Value = isBuy;
                        SqlParameter p7 = new SqlParameter("@Creator", SqlDbType.Int);
                        p7.Value = SystemInfo.user.AutoId;
                        SqlParameter p8 = new SqlParameter("@PreparedIp", SqlDbType.VarChar);
                        p8.Value = SystemInfo.HostIpAddress;
                        IDataParameter[] updateParas = new IDataParameter[] { p1, p2, p3, p4, p5, p6, p7, p8 };
                        BaseSQL.RunProcedure(cmd_proc, "P_PSBom_Insert", updateParas, out resultInt, out errorText);
                        if (resultInt != 1)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("保存生产计划Bom信息错误--" + errorText);
                            return false;
                        }

                        if (isChildLevel == 1)
                        {
                            SqlCommand cmd_proclevel = new SqlCommand("", conn, trans);
                            SqlParameter para1 = new SqlParameter("@BomListAutoId", SqlDbType.Int);
                            para1.Value = bomListAutoId;
                            SqlParameter para2 = new SqlParameter("@IsAll", SqlDbType.Int);
                            para2.Value = isAll;
                            SqlParameter para3 = new SqlParameter("@PlanDate", SqlDbType.DateTime);
                            para3.Value = planDate;
                            SqlParameter para4 = new SqlParameter("@ParentRemainQty", SqlDbType.Float);
                            para4.Value = remainQty;
                            SqlParameter para5 = new SqlParameter("@Creator", SqlDbType.Int);
                            para5.Value = SystemInfo.user.AutoId;
                            SqlParameter para6 = new SqlParameter("@PreparedIp", SqlDbType.VarChar);
                            para6.Value = SystemInfo.HostIpAddress;
                            IDataParameter[] updateParameters = new IDataParameter[] { para1, para2, para3, para4, para5, para6 };
                            BaseSQL.RunProcedure(cmd_proclevel, "P_PSBom_Insert_SubLevel", updateParameters, out resultInt, out errorText);
                            if (resultInt != 1)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("保存子级生产计划Bom信息错误--" + errorText);
                                return false;
                            }
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
        /// 保存多条生产计划Bom信息
        /// </summary>
        public bool SaveMultiProductionScheduleBom(List<int> bomListAutoIdList, int isAll, DateTime planDate, double remainQty)
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
                        foreach (int bomListAutoId in bomListAutoIdList)
                        {
                            string logStr = string.Format("保存生产计划Bom信息：[BomListAutoId]的值[{0}],[是否统一]的值[{1}],[需求日期]的值[{2}],[需求数量]的值[{3}]。", bomListAutoId, isAll, planDate.ToString("yyyy-MM-dd"), remainQty);
                            LogHandler.RecordLog(cmd, logStr);

                            SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                            SqlParameter p1 = new SqlParameter("@BomListAutoId", SqlDbType.Int);
                            p1.Value = bomListAutoId;
                            SqlParameter p2 = new SqlParameter("@AutoId", SqlDbType.Int);
                            p2.Value = 0;
                            SqlParameter p3 = new SqlParameter("@IsAll", SqlDbType.Int);
                            p3.Value = isAll;
                            SqlParameter p4 = new SqlParameter("@PlanDate", SqlDbType.DateTime);
                            p4.Value = planDate;
                            SqlParameter p5 = new SqlParameter("@RemainQty", SqlDbType.Float);
                            p5.Value = remainQty;
                            SqlParameter p6 = new SqlParameter("@IsBuy", SqlDbType.Int);
                            p6.Value = -1;
                            SqlParameter p7 = new SqlParameter("@Creator", SqlDbType.Int);
                            p7.Value = SystemInfo.user.AutoId;
                            SqlParameter p8 = new SqlParameter("@PreparedIp", SqlDbType.VarChar);
                            p8.Value = SystemInfo.HostIpAddress;
                            IDataParameter[] updateParas = new IDataParameter[] { p1, p2, p3, p4, p5, p6, p7, p8 };
                            BaseSQL.RunProcedure(cmd_proc, "P_PSBom_Insert", updateParas, out resultInt, out errorText);
                            if (resultInt != 1)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("保存生产计划Bom信息错误--" + errorText);
                                return false;
                            }
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
        /// 删除生产计划Bom信息
        /// </summary>
        public bool DeleteProductionScheduleBom(List<int> psBomAutoIdList)
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
                        string sqlwhere = "";
                        foreach (int psBomAutoId in psBomAutoIdList)
                        {
                            sqlwhere += psBomAutoId + ",";
                        }
                        cmd.CommandText = string.Format("select Count(*) from PB_ScheduleAbsorbe where MainAutoId in ({0})", sqlwhere.Substring(0, sqlwhere.Length - 1));
                        int count = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            if (MessageHandler.ShowMessageBox_YesNo(string.Format("当前选中的生产计划记录包括{0}条吸收的生产计划记录，是否继续删除？", count)) != System.Windows.Forms.DialogResult.Yes)
                            {
                                trans.Rollback();
                                return false;
                            }
                        }

                        cmd.CommandText = string.Format("Select Count(*) from PB_ProductionScheduleBom where AutoId in ({0}) and IsNull(PrReqNo, '') != ''", sqlwhere.Substring(0, sqlwhere.Length - 1));
                        if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("当前选中的生产计划信息已经生成请购单，不可以进行操作。");
                            return false;
                        }

                        foreach (int psBomAutoId in psBomAutoIdList)
                        {
                            string logStr = string.Format("删除生产计划Bom信息：[AutoId]的值[{0}]。", psBomAutoId);
                            LogHandler.RecordLog(cmd, logStr);

                            SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                            SqlParameter p1 = new SqlParameter("@AutoId", SqlDbType.Int);
                            p1.Value = psBomAutoId;
                            IDataParameter[] updateParas = new IDataParameter[] { p1 };
                            BaseSQL.RunProcedure(cmd_proc, "P_PSBom_Delete", updateParas, out resultInt, out errorText);
                            if (resultInt != 1)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("删除生产计划Bom信息错误--" + errorText);
                                return false;
                            }
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
        /// 查询设计Bom信息
        /// </summary>
        public string Query_DesignBomList_SQL(string projectNoStr, int codeIdInt, bool containNoUse, int creatorInt, string commonStr, bool nullTable)
        {
            string sqlStr = " 1=1";
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and ProjectNo = '{0}'", projectNoStr);
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and MainCodeId = {0}", codeIdInt);
            }
            if (!containNoUse)
            {
                sqlStr += " and IsUse = 1";
            }
            if (creatorInt != 0)
            {
                sqlStr += string.Format(" and Creator = {0}", creatorInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (SalesOrderNo like '%{0}%' or PbBomNo like '%{0}%' or CodeFileName like '%{0}%' or CodeName like '%{0}%')", commonStr);
            }
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select * from V_PB_DesignBomList where {0} order by AutoId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 新增工序信息
        /// </summary>
        public bool Insert_WorkProcess(string salesOrderNo, string pbBomNo, int parentId, int parentCodeId, string parentCodeFileName, decimal parentQty, string workProcessNo, decimal Qty, int isBuyInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("select Count(*) from PB_DesignBomList where IsNull(LevelCodeId, 0) = 0 and LevelMaterielNo = '{0}' and ParentId = {1}", workProcessNo, parentId);
                        if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("一个零件或者Bom不可以登记重复的工序信息，请重新操作。");
                            return false;
                        }

                        decimal totalQty = parentQty * Qty;
                        cmd.CommandText = string.Format("Insert Into PB_DesignBomList(SalesOrderNo, PbBomNo, MaterielNo, LevelMaterielNo, Qty, TotalQty, IsAbsorbed, AbsorbedQty, RemainQty, GetTime, ParentId, IsAll, HasLevel, IsUse, Creator, PreparedIp, IsMaterial, CodeId, LevelCodeId, IsBuy) values('{0}', '{1}', '{2}', '{3}', {4}, {5}, 0, 0, {5}, GETDATE(), {6}, 0, 0, 1, {7}, '{8}', 2, {9}, Null, {10})", salesOrderNo, pbBomNo, parentCodeFileName, workProcessNo, Qty, totalQty, parentId, SystemInfo.user.AutoId, SystemInfo.HostIpAddress, parentCodeId, isBuyInt);
                        cmd.ExecuteNonQuery();

                        string logStr = string.Format("新增制作Bom工序信息：[制作Bom编号]的值[{0}]，[工序名称]的值[{1}]，[数量]的值[{2}]。", pbBomNo, workProcessNo, Qty);
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

        /// <summary>
        /// 删除工序信息
        /// </summary>
        public bool Delete_WorkProcess(int autoIdInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("select Count(*) from PB_ProductionScheduleBom where BomListAutoId = {0}", autoIdInt);
                        if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("当前要删除的工序信息已经设定了生产计划，不可以删除。");
                            return false;
                        }

                        cmd.CommandText = string.Format("Select * from PB_DesignBomList where AutoId = {0}", autoIdInt);
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable bomListTable = new DataTable();
                        adapterList.Fill(bomListTable);
                        if (bomListTable.Rows.Count == 0)
                        {
                            trans.Rollback();
                            return false;
                        }

                        string logStr = string.Format("删除制作Bom工序信息：[制作Bom编号]的值[{0}]，[工序名称]的值[{1}]，[数量]的值[{2}]。", DataTypeConvert.GetString(bomListTable.Rows[0]["PbBomNo"]), DataTypeConvert.GetString(bomListTable.Rows[0]["LevelMaterielNo"]), DataTypeConvert.GetDecimal(bomListTable.Rows[0]["Qty"]));
                        LogHandler.RecordLog(cmd, logStr);

                        //处理删除被吸收记录
                        cmd.CommandText = string.Format("Delete from DesignBomListAbsorbe where AbsorbedAutoId = {0}", autoIdInt);
                        cmd.ExecuteNonQuery();

                        //处理主动吸收的记录
                        //cmd.CommandText = string.Format("Select Count(*) from DesignBomListAbsorbe where LevelAutoId = {0}", autoIdInt);
                        //if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                        //{
                        //    cmd.CommandText = string.Format("update DesignBomListAbsorbe set AbsorbedQty = 0 where LevelAutoId = {0}", autoIdInt);
                        //    cmd.ExecuteNonQuery();
                        //    cmd.CommandText = string.Format("update PB_DesignBomList set AbsorbedQty = (select ISNULL(Sum(AbsorbedQty), 0) from DesignBomListAbsorbe where PB_DesignBomList.AutoId = DesignBomListAbsorbe.AbsorbedAutoId), RemainQty = TotalQty - (select ISNULL(Sum(AbsorbedQty), 0) from DesignBomListAbsorbe where PB_DesignBomList.AutoId = DesignBomListAbsorbe.AbsorbedAutoId) where PB_DesignBomList.AutoId in (select AbsorbedAutoId from DesignBomListAbsorbe where LevelAutoId = {0}) ", autoIdInt);
                        //    cmd.ExecuteNonQuery();
                        //    cmd.CommandText = string.Format("update PB_DesignBomList set IsAbsorbed = 0 where AbsorbedQty = 0 and PB_DesignBomList.AutoId in (select AbsorbedAutoId from DesignBomListAbsorbe where LevelAutoId = {0})", autoIdInt);
                        //    cmd.ExecuteNonQuery();
                        //    cmd.CommandText = string.Format("Delete from DesignBomListAbsorbe where LevelAutoId = {0}", autoIdInt);
                        //    cmd.ExecuteNonQuery();
                        //}
                        //

                        cmd.CommandText = string.Format("Delete from PB_DesignBomList where AutoId = {0}", autoIdInt);
                        cmd.ExecuteNonQuery();

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
