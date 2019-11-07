using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.PBDAO
{
    class FrmPBDesignBomDAO
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
        public void QueryPartsCode(DataTable queryDataTable, string codeFileNameStr, string codeNameStr, string catgNameStr, string brandStr)
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

            sqlStr = string.Format("select * from SW_PartsCode where {0} order by AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询单个Bom的树形更多信息
        /// </summary>
        public DataTable QueryBomInfo_Single(string materielNoStr)
        {
            string sqlStr = string.Format("select bom.*, SW_PartsCode.CodeName, SW_PartsCode.AutoId as PCAutoId, SW_PartsCode.FilePath, SW_PartsCode.Brand, SW_PartsCode.CatgName, SW_PartsCode.CodeSpec, SW_PartsCode.Unit, BS_BomMaterieState.MaterieStateText from F_BomMateriel_TreeRelation('{0}') as bom left join SW_PartsCode on bom.CodeFileName = SW_PartsCode.CodeFileName left join BS_BomManagement on bom.CodeFileName = BS_BomManagement.MaterielNo left join BS_BomMaterieState on BS_BomMaterieState.MaterieStateId = BS_BomManagement.MaterieStateId Order by CodeFileName", materielNoStr);
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

            sqlStr = string.Format("select ('/' + Cast(PartsCodeId as varchar(max)) + '/') as ReID, Cast('' as varchar(max)) as ReParent, MaterielNo as CodeFileName, Cast('' as varchar(200)) as ParentCodeFileName, 1 as Qty, SW_PartsCode.CodeName, SW_PartsCode.AutoId as PCAutoId, SW_PartsCode.FilePath, SW_PartsCode.Brand, SW_PartsCode.CatgName, SW_PartsCode.CodeSpec, SW_PartsCode.Unit, BS_BomMaterieState.MaterieStateText from BS_BomManagement as bom left join SW_PartsCode on bom.MaterielNo = SW_PartsCode.CodeFileName left join BS_BomMaterieState on BS_BomMaterieState.MaterieStateId = bom.MaterieStateId where MaterielNo in (select CodeFileName from SW_PartsCode where {0}) Order by MaterielNo", sqlStr);
            return BaseSQL.Query(sqlStr).Tables[0];
        }

        /// <summary>
        /// 查询BOM的子节点信息
        /// </summary>
        public void QueryBomInfo_OnlyLeaf(DataTable queryDataTable, string codeFileNameStr)
        {
            string sqlStr = string.Format("select bom.*, SW_PartsCode.CodeName, SW_PartsCode.AutoId as PCAutoId, SW_PartsCode.FilePath, SW_PartsCode.Brand, SW_PartsCode.CatgName, SW_PartsCode.CodeSpec, SW_PartsCode.Unit, BS_BomMaterieState.MaterieStateText from F_BomMateriel_TreeRelation('{0}') as bom left join SW_PartsCode on bom.CodeFileName = SW_PartsCode.CodeFileName left join BS_BomManagement on bom.CodeFileName = BS_BomManagement.MaterielNo left join BS_BomMaterieState on BS_BomMaterieState.MaterieStateId = BS_BomManagement.MaterieStateId where bom.CodeFileName != '{0}' Order by bom.CodeFileName", codeFileNameStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        ///// <summary>
        ///// 保存生产BOM信息
        ///// </summary>
        //public int SavePBBomManagement(string salesOrderNoStr, DataTable bomListTable)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                DateTime nowTime = BaseSQL.GetServerDateTime();

        //                //foreach(DataRow dr in drs)
        //                //{
        //                //    cmd.CommandText = string.Format("Insert into PB_BomManagement(SalesOrderNo, MaterielNo, LevelMaterielNo, Qty, IsUse, Creator, PreparedIp, GetTime)")
        //                //}

        //                for (int i = 0; i < bomListTable.Rows.Count; i++)
        //                {
        //                    if (bomListTable.Rows[i].RowState == DataRowState.Added)
        //                    {
        //                        bomListTable.Rows[i]["IsUse"] = 1;
        //                        bomListTable.Rows[i]["Creator"] = SystemInfo.user.AutoId;
        //                        bomListTable.Rows[i]["PreparedIp"] = SystemInfo.HostIpAddress;
        //                        bomListTable.Rows[i]["GetTime"] = nowTime;
        //                    }
        //                }

        //                //保存日志到日志表中
        //                //string logStr = LogHandler.RecordLog_DataRow(cmd, "Bom登记信息", bomHeadRow, "MaterielNo");

        //                cmd.CommandText = "select * from PB_BomManagement where 1=2";
        //                SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
        //                DataTable tmpListTable = new DataTable();
        //                adapterList.Fill(tmpListTable);
        //                BaseSQL.UpdateDataTable(adapterList, bomListTable);

        //                trans.Commit();

        //                return 1;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                bomListTable.RejectChanges();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 全部删除生产BOM信息
        ///// </summary>
        //public bool ClearPBBomManagement(string salesOrderNoStr)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                //保存日志到日志表中
        //                LogHandler.RecordLog(cmd, string.Format("全部删除销售订单[{0}]的生产BOM信息",salesOrderNoStr));

        //                cmd.CommandText = string.Format("Delete from PB_BomManagement where SalesOrderNo = '{0}'", salesOrderNoStr);
        //                cmd.ExecuteNonQuery();

        //                trans.Commit();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 删除生产BOM中的BOM信息
        ///// </summary>
        //public bool DeletePBBomManagement(string salesOrderNoStr,string bomMaterielNoStr)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);



        //                trans.Commit();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 查询设计Bom的主表信息
        ///// </summary>
        //public DataTable QueryDesignBomManagement(string salesOrderNoStr)
        //{
        //    string sqlStr = string.Format("select * from PB_DesignBomManagement where SalesOrderNo = '{0}'", salesOrderNoStr);
        //    return BaseSQL.Query(sqlStr).Tables[0];
        //}

        /// <summary>
        /// 查询设计Bom的树类型信息
        /// </summary>
        public void QueryDesignBomTree(DataTable queryDataTable, string salesOrderNoStr, int IsUse)
        {
            string sqlStr = "";
            if(IsUse >= 0)
            {
                sqlStr += string.Format(" and IsUse = {0}", IsUse);
            }
            sqlStr = string.Format("select * from V_PB_DesignBom_Tree where SalesOrderNo = '{0}' {1} Order by AutoId", salesOrderNoStr, sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询包含某个零件的设计Bom的树类型信息
        /// </summary>
        public void QueryDesignBomTree_CodeFileName(DataTable queryDataTable, string salesOrderNoStr, string codeFileNameStr)
        {
            string sqlStr = string.Format("select * from V_PB_DesignBom_Tree where SalesOrderNo = '{0}' and PbBomNo in (select PbBomNo from PB_DesignBomList where MaterielNo in ({1}) or LevelMaterielNo in ({1})) Order by AutoId", salesOrderNoStr, codeFileNameStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 保存设计Bom信息
        /// </summary>
        public void SaveDesignBom(string salesOrderNoStr, Dictionary<int, string> codeIdList, float qty)
        {
            foreach (string codeFileName in codeIdList.Values)
            {
                string sqlStr = string.Format("select COUNT(*) from BS_BomMateriel where MaterielNo = '{0}'", codeFileName);
                int count = DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
                if (count == 0)//按照零件进行录入
                {
                    SaveDesignBom_PartsCode(salesOrderNoStr, codeFileName, qty);
                }
                else//按照Bom进行录入
                {
                    SaveDesignBom_Bom(salesOrderNoStr, codeFileName, qty);
                }
            }
        }

        /// <summary>
        /// 保存设计Bom信息处理零件方法
        /// </summary>
        private bool SaveDesignBom_PartsCode(string salesOrderNoStr, string codeFileNameStr, float qty)
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

                        cmd.CommandText = string.Format("select * from PB_DesignBomManagement where SalesOrderNo = '{0}' and MaterielNo = '{1}' and RemainQty > 0", salesOrderNoStr, codeFileNameStr);
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
                            SqlParameter p3 = new SqlParameter("@CodeFileName", SqlDbType.VarChar);
                            p3.Value = codeFileNameStr;
                            SqlParameter p4 = new SqlParameter("@Qty", SqlDbType.Float);
                            p4.Value = qty;
                            SqlParameter p5 = new SqlParameter("@Creator", SqlDbType.Int);
                            p5.Value = SystemInfo.user.AutoId;
                            SqlParameter p6 = new SqlParameter("@PreparedIp", SqlDbType.VarChar);
                            p6.Value = SystemInfo.HostIpAddress;
                            IDataParameter[] parameters = new IDataParameter[] { p1, p2, p3, p4, p5, p6 };
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
        private bool SaveDesignBom_Bom(string salesOrderNoStr, string codeFileNameStr, float qty)
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

                        cmd.CommandText = string.Format("select * from PB_DesignBomManagement where SalesOrderNo = '{0}' and MaterielNo = '{1}' and RemainQty > 0", salesOrderNoStr, codeFileNameStr);
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
                            SqlParameter p3 = new SqlParameter("@CodeFileName", SqlDbType.VarChar);
                            p3.Value = codeFileNameStr;
                            SqlParameter p4 = new SqlParameter("@Qty", SqlDbType.Float);
                            p4.Value = qty;
                            SqlParameter p5 = new SqlParameter("@Creator", SqlDbType.Int);
                            p5.Value = SystemInfo.user.AutoId;
                            SqlParameter p6 = new SqlParameter("@PreparedIp", SqlDbType.VarChar);
                            p6.Value = SystemInfo.HostIpAddress;
                            IDataParameter[] insertParas = new IDataParameter[] { p1, p2, p3, p4, p5, p6 };
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
                        SqlParameter p3_Absorb = new SqlParameter("@ParentId", SqlDbType.Int);
                        p3_Absorb.Value = 0;
                        SqlParameter p4_Absorb = new SqlParameter("@OpQty", SqlDbType.Float);
                        p4_Absorb.Value = qty;
                        IDataParameter[] parameters = new IDataParameter[] { p1_Absorb, p2_Absorb, p3_Absorb, p4_Absorb };
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
                string sqlStr = string.Format("select * from PB_DesignBomManagement where SalesOrderNo = '{0}' and PbBomNo = '{1}'", salesOrderNoStr, pbBomNoStr);
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
                            string logStr = string.Format("删除设计Bom中的信息[{0}]。", pbBomNoStr);
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

        ///// <summary>
        ///// 删除设计Bom信息处理零件方法
        ///// </summary>
        //private bool DeleteDesignBom_PartsCode(string salesOrderNoStr, string pbBomNoStr)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                int resultInt = 0;
        //                string errorText = "";

        //                string logStr = string.Format("删除设计Bom中的零件信息[{0}]。", pbBomNoStr);
        //                LogHandler.RecordLog(cmd, logStr);

        //                SqlCommand cmd_proc = new SqlCommand("", conn, trans);
        //                SqlParameter p1 = new SqlParameter("@SalesOrderNo", SqlDbType.VarChar);
        //                p1.Value = salesOrderNoStr;
        //                SqlParameter p2 = new SqlParameter("@PbBomNo", SqlDbType.VarChar);
        //                p2.Value = pbBomNoStr;
        //                IDataParameter[] updateParas = new IDataParameter[] { p1, p2 };
        //                BaseSQL.RunProcedure(cmd_proc, "P_DesignBom_Parts_Delete", updateParas, out resultInt, out errorText);
        //                if (resultInt != 1)
        //                {
        //                    trans.Rollback();
        //                    MessageHandler.ShowMessageBox("设计Bom删除零件信息错误--" + errorText);
        //                    return false;
        //                }
        //                trans.Commit();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 删除设计Bom信息处理Bom方法
        ///// </summary>
        //private bool DeleteDesignBom_Bom(string salesOrderNoStr, string pbBomNoStr)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                int resultInt = 0;
        //                string errorText = "";

        //                string logStr = string.Format("删除设计Bom中的Bom信息[{0}]。", pbBomNoStr);
        //                LogHandler.RecordLog(cmd, logStr);

        //                SqlCommand cmd_proc = new SqlCommand("", conn, trans);
        //                SqlParameter p1 = new SqlParameter("@SalesOrderNo", SqlDbType.VarChar);
        //                p1.Value = salesOrderNoStr;
        //                SqlParameter p2 = new SqlParameter("@PbBomNo", SqlDbType.VarChar);
        //                p2.Value = pbBomNoStr;
        //                IDataParameter[] updateParas = new IDataParameter[] { p1, p2 };
        //                BaseSQL.RunProcedure(cmd_proc, "P_DesignBom_Bom_Delete", updateParas, out resultInt, out errorText);
        //                if (resultInt != 1)
        //                {
        //                    trans.Rollback();
        //                    MessageHandler.ShowMessageBox("设计Bom删除Bom信息错误--" + errorText);
        //                    return false;
        //                }

        //                trans.Commit();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 停用设计Bom信息
        /// </summary>
        public void StopDesignBom(string salesOrderNoStr, List<string> pbBomNoList)
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
                            string logStr = string.Format("设计Bom信息[{0}]停用。", pbBomNo);
                            LogHandler.RecordLog(cmd, logStr);
                            pbBomNoStr += string.Format("'{0}',", pbBomNo);
                        }

                        cmd.CommandText = string.Format("Update PB_DesignBomManagement set IsUse = 0 where PbBomNo in ({0})", pbBomNoStr.Substring(0, pbBomNoStr.Length - 1));
                        cmd.ExecuteNonQuery();

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
        /// 恢复设计Bom信息
        /// </summary>
        public void RecoverDesignBom(string salesOrderNoStr, List<string> pbBomNoList)
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

                        cmd.CommandText = string.Format("Update PB_DesignBomManagement set IsUse = 1 where PbBomNo in ({0})", pbBomNoStr.Substring(0, pbBomNoStr.Length - 1));
                        cmd.ExecuteNonQuery();

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

    }
}
