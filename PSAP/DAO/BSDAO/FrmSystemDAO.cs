using PSAP.DAO.BSDAO;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using PSAP.PSAPCommon;

namespace PSAP.DAO.BSDAO
{
    class FrmSystemDAO
    {
        string defaultShelfNo = "Default";

        /// <summary>
        /// 清空操作记录
        /// </summary>
        public bool ClearOperationRecord(bool clearSale, bool clearProject, bool clearPurchase, bool clearWarehouse, bool clearProduction)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (clearWarehouse)//库存模块
                        {
                            cmd.CommandText = "Truncate Table INV_InventoryAdjustmentsList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_InventoryAdjustmentsHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_InventoryMoveList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_InventoryMoveHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_ReturnedGoodsReportList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_ReturnedGoodsReportHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_SpecialWarehouseReceiptList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_SpecialWarehouseReceiptHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_SpecialWarehouseWarrantList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_SpecialWarehouseWarrantHead"; cmd.ExecuteNonQuery();
                            //cmd.CommandText = "Truncate Table INV_WarehouseReceiptApprovalInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_WarehouseReceiptList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_WarehouseReceiptHead"; cmd.ExecuteNonQuery();
                            //cmd.CommandText = "Truncate Table INV_WarehouseApprovalInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_WarehouseWarrantList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_WarehouseWarrantHead"; cmd.ExecuteNonQuery();

                            cmd.CommandText = "Truncate Table INV_WarehouseBeginingInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table INV_WarehouseNowInfo"; cmd.ExecuteNonQuery();
                        }

                        if (clearPurchase)//采购模块
                        {
                            //cmd.CommandText = "Truncate Table PUR_SettlementApprovalInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table PUR_SettlementList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table PUR_SettlementHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table PUR_OrderApprovalInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table PUR_OrderList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table PUR_OrderHead"; cmd.ExecuteNonQuery();
                            //cmd.CommandText = "Truncate Table PUR_PrApprovalInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table PUR_PrReqList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table PUR_PrReqHead"; cmd.ExecuteNonQuery();
                        }

                        if (clearProduction)//生产模块
                        {
                            cmd.CommandText = "Truncate Table PB_ScheduleAbsorbe"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table DesignBomListAbsorbe"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table PB_DesignBomList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table PB_ProductionScheduleBom"; cmd.ExecuteNonQuery();
                        }

                        if(clearProject)//项目模块
                        {
                            cmd.CommandText = "Truncate Table PM_ProjectPlanTask"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table PM_ProjectTaskType"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table BS_ProjectUser"; cmd.ExecuteNonQuery();
                        }

                        if (clearSale)//销售模块
                        {
                            cmd.CommandText = "Truncate Table SA_DeliveryDetail"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table SA_MaterialDetail"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table SA_Quotation"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table SA_QuotationBaseInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table SA_QuotationPriceInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table SA_SalesOrder"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table SA_SettleAccountsHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table SA_SettleAccountsList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table SA_StnModule"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table SA_StnSummary"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table SA_StnSummaryList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Truncate Table SA_StnSummaryListModule"; cmd.ExecuteNonQuery();
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
        /// 清空基础资料
        /// </summary>
        public bool ClearBasicData()
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = "Delete From PUR_ApprovalList"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From PUR_ApprovalType"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From PUR_PayTypeList"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From PUR_PayType"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From PUR_PurCategory"; cmd.ExecuteNonQuery();

                        cmd.CommandText = "Delete From BS_BussinessFinancialInfo"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_BussinessDetailInfo"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_BussinessBaseInfo"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_BussinessCategory"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_CountryCodeManagement"; cmd.ExecuteNonQuery();

                        cmd.CommandText = "Delete From BS_CollectionTypeList"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_CollectionType"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_CurrencyCate";cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_DeliveryLocation"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_ManufactureInfo"; cmd.ExecuteNonQuery();                        
                        cmd.CommandText = "Delete From BS_ShelfInfo"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_RepertoryLocationInfo"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_RepertoryInfo"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_WarehouseReceiptType"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_WarehouseWarrantType"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_StnList"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_ProjectList"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_ProjectStatus";cmd.ExecuteNonQuery();

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
        /// 刷新所有的系统参数
        /// </summary>
        public void RefreshAllSystemParameter()
        {
            DataTable sysParameterTable = new DataTable();
            QuerySystemParameter(sysParameterTable);

            #region 常规

            string tmpStr = GetValue(sysParameterTable, "Common", "PageRowCount");
            if (tmpStr != "")
                SystemInfo.OrderQueryGrid_PageRowCount = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue(sysParameterTable, "Common", "DateIntervalDays");
            if (tmpStr != "")
                SystemInfo.OrderQueryDate_DateIntervalDays = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue(sysParameterTable, "Common", "FormDragDropMaxRecordCount");
            if (tmpStr != "")
                SystemInfo.FormDragDropMaxRecordCount = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue(sysParameterTable, "Common", "LeftDockWidth");
            if (tmpStr != "")
                SystemInfo.DragForm_LeftDock_Width = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue(sysParameterTable, "Common", "EnableWorkFlowMessage");
            if (tmpStr != "")
                SystemInfo.EnableWorkFlowMessage = tmpStr == "1";

            tmpStr = GetValue(sysParameterTable, "Common", "ApproveAfterPrint");
            if (tmpStr != "")
                SystemInfo.ApproveAfterPrint = tmpStr == "1";

            #endregion

            #region 销售

            tmpStr = GetValue(sysParameterTable, "Sale", "QuotationDefaultTax");
            if (tmpStr != "")
                SystemInfo.Quotation_DefaultTax = DataTypeConvert.GetDouble(tmpStr);

            tmpStr = GetValue(sysParameterTable, "Sale", "SalesOrderDefaultTax");
            if (tmpStr != "")
                SystemInfo.SalesOrder_DefaultTax = DataTypeConvert.GetDouble(tmpStr);

            #endregion

            #region 项目

            tmpStr = GetValue(sysParameterTable, "Project", "GanttResourcesPerPage");
            if (tmpStr != "")
                SystemInfo.Gantt_ResourcesPerPage = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue(sysParameterTable, "Project", "GanttSchedulerBarHeight");
            if (tmpStr != "")
                SystemInfo.Gantt_SchedulerBarHeight = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue(sysParameterTable, "Project", "GanttSchedulerBarColor");
            if (tmpStr != "")
                SystemInfo.Gantt_SchedulerBarColor = System.Drawing.ColorTranslator.FromHtml(tmpStr);

            #endregion

            #region 采购

            tmpStr = GetValue(sysParameterTable, "Purchase", "PrReqIsAlterPSBomAutoId");
            if (tmpStr != "")
                SystemInfo.PrReqIsAlter_PSBomAutoId = tmpStr == "1";

            tmpStr = GetValue(sysParameterTable, "Purchase", "OrderListDefaultTax");
            if (tmpStr != "")
                SystemInfo.OrderList_DefaultTax = DataTypeConvert.GetDouble(tmpStr);

            tmpStr = GetValue(sysParameterTable, "Purchase", "SettlementDefaultTax");
            if (tmpStr != "")
                SystemInfo.Settlement_DefaultTax = DataTypeConvert.GetDouble(tmpStr);

            tmpStr = GetValue(sysParameterTable, "Purchase", "OrderNoWarehousingDays");
            if (tmpStr != "")
                SystemInfo.OrderNoWarehousing_Days = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue(sysParameterTable, "Purchase", "PrReqApplyBeyondCountIsSave");
            if (tmpStr != "")
                SystemInfo.PrReqApplyBeyondCountIsSave = tmpStr == "1";

            tmpStr = GetValue(sysParameterTable, "Purchase", "WWApplyBeyondCountIsSave");
            if (tmpStr != "")
                SystemInfo.WarehouseWarrantApplyBeyondCountIsSave = tmpStr == "1";

            #endregion

            #region 库存

            tmpStr = GetValue(sysParameterTable, "Warehouse", "OrderApplyBeyondCountIsSave");
            if (tmpStr != "")
                SystemInfo.OrderApplyBeyondCountIsSave = tmpStr == "1";

            tmpStr = GetValue(sysParameterTable, "Warehouse", "WWIsAlterDate");
            if (tmpStr != "")
                SystemInfo.WarehouseWarrantIsAlterDate = tmpStr == "1";

            tmpStr = GetValue(sysParameterTable, "Warehouse", "WRIsAlterDate");
            if (tmpStr != "")
                SystemInfo.WarehouseReceiptIsAlterDate = tmpStr == "1";

            tmpStr = GetValue(sysParameterTable, "Warehouse", "DisableProjectNo");
            if (tmpStr != "")
                SystemInfo.DisableProjectNo = tmpStr == "1";

            tmpStr = GetValue(sysParameterTable, "Warehouse", "DisableShelfInfo");
            if (tmpStr != "")
                SystemInfo.DisableShelfInfo = tmpStr == "1";

            SystemInfo.DisableShelfInfo_Default_ShelfId = DataTypeConvert.GetInt(BaseSQL.GetSingle(string.Format("select AutoId from BS_ShelfInfo where ShelfNo = '{0}' and RepertoryInfoId is null and RepertoryLocationId is null", defaultShelfNo)));

            tmpStr = GetValue(sysParameterTable, "Warehouse", "EnableNegativeInventory");
            if (tmpStr != "")
                SystemInfo.EnableNegativeInventory = tmpStr == "1";

            tmpStr = GetValue(sysParameterTable, "Warehouse", "InventorySaveApproval");
            if (tmpStr != "")
                SystemInfo.InventorySaveApproval = tmpStr == "1";

            #endregion

            #region 生产



            #endregion

            #region 人事



            #endregion

            #region 会计



            #endregion

        }

        /// <summary>
        /// 根据模块号和Key索引临时表的Value
        /// </summary>
        private string GetValue(DataTable sysParameterTable, string moduleCateStr, string keyStr)
        {
            DataRow[] drs = sysParameterTable.Select(string.Format("ModuleCate = '{0}' and ParameterKey = '{1}'", moduleCateStr, keyStr));
            if (drs.Length == 0)
                return "";
            else
                return DataTypeConvert.GetString(drs[0]["ParameterValue"]);
        }

        /// <summary>
        /// 查询系统参数表
        /// </summary>
        public void QuerySystemParameter(DataTable queryDataTable)
        {
            string sqlStr = "select * from BS_SysParameter";
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 删除全部系统参数
        /// </summary>
        public void DeleteSystemParameter()
        {
            string sqlStr = "Delete from BS_SysParameter";
            BaseSQL.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// 查询单个系统参数值
        /// </summary>
        public static object QuerySystemParameter_Single(string moduleCateStr, string keyStr)
        {
            string sqlStr = string.Format("select ParameterValue from BS_SysParameter where ModuleCate = '{0}' and ParameterKey = '{1}'", moduleCateStr, keyStr);
            return BaseSQL.GetSingle(sqlStr);
        }

        /// <summary>
        /// 保存系统参数表
        /// </summary>
        public bool SaveSystemParameter(DataTable queryDataTable)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = "select * from BS_SysParameter where 1=2";
                        SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                        DataTable tmpHeadTable = new DataTable();
                        adapterHead.Fill(tmpHeadTable);
                        BaseSQL.UpdateDataTable(adapterHead, queryDataTable);

                        cmd.CommandText = "update BS_DataCurrentNode set isEnd = 1";

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        queryDataTable.RejectChanges();
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
        /// 数据库新增默认的项目号和站号
        /// </summary>
        public void Insert_Default_ProjectListAndStnList()
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("Select Count(*) from BS_BussinessBaseInfo where BussinessBaseNo = '{0}'", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                        if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) == 0)
                        {
                            cmd.CommandText = string.Format("Insert into BS_BussinessBaseInfo(BussinessBaseNo, BussinessBaseText, BussinessIsUse) values('{0}', '默认往来方', 1)", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = string.Format("Select Count(*) from BS_ProjectList where ProjectNo = '{0}'", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                        if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) == 0)
                        {
                            cmd.CommandText = string.Format("Insert into BS_ProjectList(ProjectNo, BussinessBaseNo, ProjectName, Remark) values('{0}', '{0}', '{1}', '系统默认')", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo, SystemInfo.DisableProjectNo_Default_ProjectName);
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = string.Format("Select Count(*) from BS_StnList where StnNo = '{0}'", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                        if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) == 0)
                        {
                            cmd.CommandText = string.Format("Insert into BS_StnList(ProjectNo, StnNo, Remark, StnText) values('{0}', '{0}', '系统默认', '默认站号')", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                            cmd.ExecuteNonQuery();
                        }

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
        /// 数据库删除默认的项目号和站号
        /// </summary>
        public void Delete_ProjectListAndStnList()
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        cmd.CommandText = "delete from BS_StnList where StnNo = 'Default'";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "delete from BS_ProjectList where ProjectNo = 'Default'";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "delete from BS_BussinessBaseInfo where BussinessBaseNo = 'Default'";
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
        /// 数据库新增默认的货架号
        /// </summary>
        public void Insert_Default_ShelfInfo()
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("Select Count(*) from BS_ShelfInfo where ShelfNo = '{0}' and RepertoryInfoId is null and RepertoryLocationId is null", defaultShelfNo);
                        if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) == 0)
                        {
                            cmd.CommandText = string.Format("insert into BS_ShelfInfo(ShelfNo, ShelfLocation, ShelfDescription, RepertoryInfoId, RepertoryLocationId, Creator, CreatorIp, Remark)  values('{0}', '{0}', '默认货架号', null, null, {1}, '{2}', '停用仓库中的货架号，新增默认的货架号。')", defaultShelfNo, SystemInfo.user.AutoId, SystemInfo.HostIpAddress);
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = string.Format("select AutoId from BS_ShelfInfo where ShelfNo = '{0}' and RepertoryInfoId is null and RepertoryLocationId is null", defaultShelfNo);
                        SystemInfo.DisableShelfInfo_Default_ShelfId = DataTypeConvert.GetInt(cmd.ExecuteScalar());

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
