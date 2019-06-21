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
        /// <summary>
        /// 清空操作记录
        /// </summary>
        public void ClearOperationRecord(bool clearSale, bool clearPurchase, bool clearWarehouse, bool clearProduction)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (clearSale)//销售模块
                        {
                            cmd.CommandText = "Delete From SA_DeliveryDetail"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From SA_MaterialDetail"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From SA_Quotation"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From SA_QuotationBaseInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From SA_QuotationPriceInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From SA_SalesOrder"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From SA_SettleAccountsHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From SA_SettleAccountsList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From SA_StnModule"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From SA_StnSummary"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From SA_StnSummaryList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From SA_StnSummaryListModule"; cmd.ExecuteNonQuery();
                        }

                        if (clearPurchase)//采购模块
                        {
                            cmd.CommandText = "Delete From PUR_SettlementApprovalInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From PUR_SettlementList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From PUR_SettlementHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From PUR_OrderApprovalInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From PUR_OrderList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From PUR_OrderHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From PUR_PrApprovalInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From PUR_PrReqList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From PUR_PrReqHead"; cmd.ExecuteNonQuery();
                        }

                        if (clearWarehouse)//库存模块
                        {
                            cmd.CommandText = "Delete From INV_WarehouseBeginingInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_WarehouseNowInfo"; cmd.ExecuteNonQuery();

                            cmd.CommandText = "Delete From INV_InventoryAdjustmentsList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_InventoryAdjustmentsHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_InventoryMoveList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_InventoryMoveHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_ReturnedGoodsReportList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_ReturnedGoodsReportHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_SpecialWarehouseReceiptList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_SpecialWarehouseReceiptHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_SpecialWarehouseWarrantList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_SpecialWarehouseWarrantHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_WarehouseReceiptApprovalInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_WarehouseReceiptList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_WarehouseReceiptHead"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_WarehouseApprovalInfo"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_WarehouseWarrantList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From INV_WarehouseWarrantHead"; cmd.ExecuteNonQuery();
                        }

                        if (clearProduction)//生产模块
                        {
                            cmd.CommandText = "Delete From PB_DesignBomList"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From PB_ProductionScheduleBom"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From PB_ScheduleAbsorbe"; cmd.ExecuteNonQuery();
                            cmd.CommandText = "Delete From DesignBomListAbsorbe"; cmd.ExecuteNonQuery();
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
        /// 清空基础资料
        /// </summary>
        public void ClearBasicData()
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
                        cmd.CommandText = "Delete From BS_DeliveryLocation"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_ManufactureInfo"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_RepertoryInfo"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_ShelfInfo"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_WarehouseReceiptType"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_WarehouseWarrantType"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_StnList"; cmd.ExecuteNonQuery();
                        cmd.CommandText = "Delete From BS_ProjectList"; cmd.ExecuteNonQuery();

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

            #endregion

            #region 销售

            tmpStr = GetValue(sysParameterTable, "Sale", "QuotationDefaultTax");
            if (tmpStr != "")
                SystemInfo.Quotation_DefaultTax = DataTypeConvert.GetDouble(tmpStr);

            tmpStr = GetValue(sysParameterTable, "Sale", "SalesOrderDefaultTax");
            if (tmpStr != "")
                SystemInfo.SalesOrder_DefaultTax = DataTypeConvert.GetDouble(tmpStr);

            #endregion

            #region 采购

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

    }
}
