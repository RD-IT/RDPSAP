using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PSAP.DAO.INVDAO
{
    class FrmWarehouseCommonDAO
    {
        /// <summary>
        /// 更新当前的库存数
        /// </summary>
        public bool Update_WarehouseNowInfo(SqlCommand cmd, string warehouseNoStr, int HandleType, out string errorText)
        {
            int resultInt = 0;
            SqlParameter p1 = new SqlParameter("@WarehouseNo", SqlDbType.VarChar);
            p1.Value = warehouseNoStr;
            SqlParameter p2 = new SqlParameter("@HandleType", SqlDbType.VarChar);
            p2.Value = HandleType;
            IDataParameter[] parameters = new IDataParameter[] { p1, p2 };
            return BaseSQL.RunProcedure(cmd, "P_Update_WarehouseNowInfo", parameters, out resultInt, out errorText);
        }

        /// <summary>
        /// 保存登记单及时更新当前库存
        /// </summary>
        /// <param name="conn">SqlConnection</param>
        /// <param name="tran">SqlTransaction</param>
        /// <param name="cmd">SqlCommand</param>
        /// <param name="headRow">主表行</param>
        /// <param name="updateListTable">更新的明细列表</param>
        /// <param name="warehouseNoStr">登记单号</param>
        /// <param name="dbListTable">更新之前数据库的明细列表</param>
        /// <param name="tableCaption">表标题</param>
        /// <param name="memoText">备注</param>
        /// <param name="inoutStockSign">出入库标志，true入库 false出库</param>
        public int SaveUpdate_WarehouseNowInfo(SqlConnection conn, SqlTransaction tran, SqlCommand cmd, DataRow headRow, DataTable updateListTable, string warehouseNoStr, DataTable dbListTable, string tableCaption, string memoText, bool inoutStockSign)
        {
            if (updateListTable == null)
                return 1;
            updateListTable.AcceptChanges();
            if (headRow.RowState == DataRowState.Added)
            {
                string errorText = "";
                SqlCommand cmd_proc = new SqlCommand("", conn, tran);
                if (!Update_WarehouseNowInfo(cmd_proc, warehouseNoStr, 1, out errorText))
                {
                    tran.Rollback();
                    MessageHandler.ShowMessageBox(string.Format("{0}{1}错误--{2}", tableCaption, memoText, errorText));
                    return 0;
                }
                return 1;
            }
            else
            {
                string columnName = dbListTable.Columns.Contains("LocationId") ? "LocationId" : "RepertoryLocationId";
                bool locationIsList = dbListTable.Columns.Contains("LocationId");
                foreach (DataRow dbRow in dbListTable.Rows)
                {
                    string dbCodeFileName = DataTypeConvert.GetString(dbRow["CodeFileName"]);
                    int dbRepertoryId = DataTypeConvert.GetInt(dbRow["RepertoryId"]);
                    int dbLocationId = DataTypeConvert.GetInt(dbRow[columnName]);
                    string dbProjectNo = DataTypeConvert.GetString(dbRow["ProjectNo"]);
                    int dbShelfId = DataTypeConvert.GetInt(dbRow["ShelfId"]);
                    double dbQty = DataTypeConvert.GetDouble(dbRow["Qty"]);
                    double iaSumQty = 0;

                    if (locationIsList)
                        iaSumQty = DataTypeConvert.GetDouble(updateListTable.Compute("Sum(Qty)", string.Format("CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", dbCodeFileName, dbRepertoryId, dbLocationId, dbProjectNo, dbShelfId)));
                    else
                        iaSumQty = DataTypeConvert.GetDouble(updateListTable.Compute("Sum(Qty)", string.Format("CodeFileName='{0}' and ProjectNo='{1}' and ShelfId={2}", dbCodeFileName, dbProjectNo, dbShelfId)));

                    if (dbQty == iaSumQty)
                    {

                    }
                    else
                    {
                        double modifiedQty = iaSumQty - dbQty;
                        if (!inoutStockSign)
                            modifiedQty = 0 - modifiedQty;

                        UpdateWarehouseNowInfo(cmd, dbCodeFileName, dbRepertoryId, dbLocationId, dbProjectNo, dbShelfId, modifiedQty);

                        if (!SystemInfo.EnableNegativeInventory)
                        {
                            cmd.CommandText = string.Format("Select Qty from INV_WarehouseNowInfo where CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", dbCodeFileName, dbRepertoryId, dbLocationId, dbProjectNo, dbShelfId);

                            double nowQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
                            if (nowQty < 0)
                            {
                                tran.Rollback();
                                MessageHandler.ShowMessageBox(string.Format("{1}{0}错误--{1}[{2}]中的[{3}]库存数不足，差[{4}]个。", memoText, tableCaption, warehouseNoStr, dbCodeFileName, -nowQty));
                                return 0;
                            }
                        }
                    }

                    DataRow[] drs;
                    if (locationIsList)
                        drs = updateListTable.Select(string.Format("CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", dbCodeFileName, dbRepertoryId, dbLocationId, dbProjectNo, dbShelfId));
                    else
                        drs = updateListTable.Select(string.Format("CodeFileName='{0}' and ProjectNo='{1}' and ShelfId={2}", dbCodeFileName, dbProjectNo, dbShelfId));

                    foreach (DataRow dr in drs)
                    {
                        updateListTable.Rows.Remove(dr);
                    }
                }

                foreach (DataRow updateRow in updateListTable.Rows)
                {
                    string updateCodeFileName = DataTypeConvert.GetString(updateRow["CodeFileName"]);
                    int updateRepertoryId = locationIsList ? DataTypeConvert.GetInt(updateRow["RepertoryId"]) : DataTypeConvert.GetInt(headRow["RepertoryId"]);
                    int updateLocationId = locationIsList ? DataTypeConvert.GetInt(updateRow["RepertoryId"]) : DataTypeConvert.GetInt(headRow["RepertoryLocationId"]);
                    string updateProjectNo = DataTypeConvert.GetString(updateRow["ProjectNo"]);
                    int updateShelfId = DataTypeConvert.GetInt(updateRow["ShelfId"]);
                    double updateQty = DataTypeConvert.GetDouble(updateRow["Qty"]);

                    if (!inoutStockSign)
                        updateQty = 0 - updateQty;

                    UpdateWarehouseNowInfo(cmd, updateCodeFileName, updateRepertoryId, updateLocationId, updateProjectNo, updateShelfId, updateQty);

                    if (!SystemInfo.EnableNegativeInventory)
                    {
                        cmd.CommandText = string.Format("Select Qty from INV_WarehouseNowInfo where CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", updateCodeFileName, updateRepertoryId, updateLocationId, updateProjectNo, updateShelfId);

                        double nowQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
                        if (nowQty < 0)
                        {
                            tran.Rollback();
                            MessageHandler.ShowMessageBox(string.Format("{1}{0}错误--{1}[{2}]中的[{3}]库存数不足，差[{4}]个。", memoText, tableCaption, warehouseNoStr, updateCodeFileName, -nowQty));
                            return 0;
                        }
                    }
                }

                return 1;
            }
        }

        /// <summary>
        /// 保存库存移动登记单及时更新当前库存
        /// </summary>
        /// <param name="conn">SqlConnection</param>
        /// <param name="tran">SqlTransaction</param>
        /// <param name="cmd">SqlCommand</param>
        /// <param name="headRow">主表行信息</param>
        /// <param name="updateInListTable">要更新的明细列表</param>
        /// <param name="warehouseNoStr">单据号</param>
        /// <param name="dbInListTable">更新之前的数据库入库明细列表</param>
        /// <param name="dbOutListTable">更新之前的数据库出库明细列表</param>
        public int SaveMoveUpdate_WarehouseNowInfo(SqlConnection conn, SqlTransaction tran, SqlCommand cmd, DataRow headRow, DataTable updateInListTable, string warehouseNoStr, DataTable dbInListTable, DataTable dbOutListTable)
        {
            if (updateInListTable == null)
                return 1;
            updateInListTable.AcceptChanges();

            if (headRow.RowState == DataRowState.Added)
            {
                string errorText = "";
                SqlCommand cmd_proc = new SqlCommand("", conn, tran);
                if (!Update_WarehouseNowInfo(cmd_proc, warehouseNoStr, 1, out errorText))
                {
                    tran.Rollback();
                    MessageHandler.ShowMessageBox(string.Format("库存移动单出入库错误--{0}", errorText));
                    return 0;
                }
                return 1;
            }
            else
            {
                #region 出库

                DataTable updateOutListTable = updateInListTable.Copy();
                foreach (DataRow dbOutRow in dbOutListTable.Rows)
                {
                    string dbCodeFileName = DataTypeConvert.GetString(dbOutRow["CodeFileName"]);
                    int dbOutLocationId = DataTypeConvert.GetInt(dbOutRow["OutLocationId"]);
                    int dbOutRepertoryId = DataTypeConvert.GetInt(dbOutRow["OutRepertoryId"]);
                    string dbOutProjectNo = DataTypeConvert.GetString(dbOutRow["OutProjectNo"]);
                    int dbOutShelfId = DataTypeConvert.GetInt(dbOutRow["OutShelfId"]);
                    double dbOutQty = DataTypeConvert.GetDouble(dbOutRow["Qty"]);
                    double imOutSumQty = DataTypeConvert.GetDouble(updateOutListTable.Compute("Sum(Qty)", string.Format("CodeFileName='{0}' and OutRepertoryId={1} and OutLocationId={2} and OutProjectNo='{3}' and OutShelfId={4}", dbCodeFileName, dbOutLocationId, dbOutRepertoryId, dbOutProjectNo, dbOutShelfId)));

                    if (dbOutQty == imOutSumQty)
                    {

                    }
                    else
                    {
                        double modifiedQty = 0 - (imOutSumQty - dbOutQty);

                        UpdateWarehouseNowInfo(cmd, dbCodeFileName, dbOutRepertoryId, dbOutLocationId, dbOutProjectNo, dbOutShelfId, modifiedQty);

                        if (!SystemInfo.EnableNegativeInventory)
                        {
                            cmd.CommandText = string.Format("Select Qty from INV_WarehouseNowInfo where CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", dbCodeFileName, dbOutRepertoryId, dbOutLocationId, dbOutProjectNo, dbOutShelfId);

                            double nowQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
                            if (nowQty < 0)
                            {
                                tran.Rollback();
                                MessageHandler.ShowMessageBox(string.Format("库存调整单出库错误--库存调整单[{0}]中的[{1}]库存数不足，差[{2}]个。", warehouseNoStr, dbCodeFileName, -nowQty));
                                return 0;
                            }
                        }
                    }

                    DataRow[] drs = updateOutListTable.Select(string.Format("CodeFileName='{0}' and OutRepertoryId={1} and OutLocationId={2} and OutProjectNo='{3}' and OutShelfId={4}", dbCodeFileName, dbOutLocationId, dbOutRepertoryId, dbOutProjectNo, dbOutShelfId));

                    foreach (DataRow dr in drs)
                    {
                        updateOutListTable.Rows.Remove(dr);
                    }
                }

                foreach (DataRow updateOutRow in updateOutListTable.Rows)
                {
                    string updateCodeFileName = DataTypeConvert.GetString(updateOutRow["CodeFileName"]);
                    int updateOutRepertoryId = DataTypeConvert.GetInt(updateOutRow["OutRepertoryId"]);
                    int updateOutLocationId = DataTypeConvert.GetInt(updateOutRow["OutLocationId"]);
                    string updateOutProjectNo = DataTypeConvert.GetString(updateOutRow["OutProjectNo"]);
                    int updateOutShelfId = DataTypeConvert.GetInt(updateOutRow["OutShelfId"]);
                    double updateOutQty = DataTypeConvert.GetDouble(updateOutRow["Qty"]);

                    UpdateWarehouseNowInfo(cmd, updateCodeFileName, updateOutRepertoryId, updateOutLocationId, updateOutProjectNo, updateOutShelfId, 0 - updateOutQty);

                    if (!SystemInfo.EnableNegativeInventory)
                    {
                        cmd.CommandText = string.Format("Select Qty from INV_WarehouseNowInfo where CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", updateCodeFileName, updateOutRepertoryId, updateOutLocationId, updateOutProjectNo, updateOutShelfId);

                        double nowQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
                        if (nowQty < 0)
                        {
                            tran.Rollback();
                            MessageHandler.ShowMessageBox(string.Format("库存调整单出库错误--库存调整单[{0}]中的[{1}]库存数不足，差[{2}]个。", warehouseNoStr, updateCodeFileName, -nowQty));
                            return 0;
                        }
                    }
                }

                #endregion

                #region 入库

                foreach (DataRow dbInRow in dbInListTable.Rows)
                {
                    string dbCodeFileName = DataTypeConvert.GetString(dbInRow["CodeFileName"]);
                    int dbInRepertoryId = DataTypeConvert.GetInt(dbInRow["InRepertoryId"]);
                    int dbInLocationId = DataTypeConvert.GetInt(dbInRow["InLocationId"]);
                    string dbInProjectNo = DataTypeConvert.GetString(dbInRow["InProjectNo"]);
                    int dbInShelfId = DataTypeConvert.GetInt(dbInRow["InShelfId"]);

                    double dbInQty = DataTypeConvert.GetDouble(dbInRow["Qty"]);
                    double imInSumQty = DataTypeConvert.GetDouble(updateInListTable.Compute("Sum(Qty)", string.Format("CodeFileName='{0}' and InRepertoryId={1} and InLocationId={2} and InProjectNo='{3}' and InShelfId={4}", dbCodeFileName, dbInRepertoryId, dbInLocationId, dbInProjectNo, dbInShelfId)));

                    if (dbInQty == imInSumQty)
                    {

                    }
                    else
                    {
                        double modifiedQty = imInSumQty - dbInQty;

                        UpdateWarehouseNowInfo(cmd, dbCodeFileName, dbInRepertoryId, dbInLocationId, dbInProjectNo, dbInShelfId, modifiedQty);

                        if (!SystemInfo.EnableNegativeInventory)
                        {
                            cmd.CommandText = string.Format("Select Qty from INV_WarehouseNowInfo where CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", dbCodeFileName, dbInRepertoryId, dbInLocationId, dbInProjectNo, dbInShelfId);

                            double nowQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
                            if (nowQty < 0)
                            {
                                tran.Rollback();
                                MessageHandler.ShowMessageBox(string.Format("库存调整单入库错误--库存调整单[{0}]中的[{1}]库存数不足，差[{2}]个。", warehouseNoStr, dbCodeFileName, -nowQty));
                                return 0;
                            }
                        }
                    }

                    DataRow[] drs = updateInListTable.Select(string.Format("CodeFileName='{0}' and InRepertoryId={1} and InLocationId={2} and InProjectNo='{3}' and InShelfId={4}", dbCodeFileName, dbInRepertoryId, dbInLocationId, dbInProjectNo, dbInShelfId));

                    foreach (DataRow dr in drs)
                    {
                        updateInListTable.Rows.Remove(dr);
                    }
                }

                foreach (DataRow updateInRow in updateInListTable.Rows)
                {
                    string updateCodeFileName = DataTypeConvert.GetString(updateInRow["CodeFileName"]);
                    int updateInRepertoryId = DataTypeConvert.GetInt(updateInRow["InRepertoryId"]);
                    int updateInLocationId = DataTypeConvert.GetInt(updateInRow["InLocationId"]);
                    string updateInProjectNo = DataTypeConvert.GetString(updateInRow["InProjectNo"]);
                    int updateInShelfId = DataTypeConvert.GetInt(updateInRow["InShelfId"]);
                    double updateInQty = DataTypeConvert.GetDouble(updateInRow["Qty"]);

                    UpdateWarehouseNowInfo(cmd, updateCodeFileName, updateInRepertoryId, updateInLocationId, updateInProjectNo, updateInShelfId, updateInQty);

                    if (!SystemInfo.EnableNegativeInventory)
                    {
                        cmd.CommandText = string.Format("Select Qty from INV_WarehouseNowInfo where CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", updateCodeFileName, updateInRepertoryId, updateInLocationId, updateInProjectNo, updateInShelfId);

                        double nowQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
                        if (nowQty < 0)
                        {
                            tran.Rollback();
                            MessageHandler.ShowMessageBox(string.Format("库存调整单入库错误--库存调整单[{0}]中的[{1}]库存数不足，差[{2}]个。", warehouseNoStr, updateCodeFileName, -nowQty));
                            return 0;
                        }
                    }
                }

                #endregion

                return 1;
            }
        }

        /// <summary>
        /// 更新当前库存数
        /// </summary>
        private void UpdateWarehouseNowInfo(SqlCommand cmd, string codeFileNameStr, int repertoryIdInt, int locationIdInt, string projectNoStr, int shelfIdInt, double qtyDouble)
        {
            int affectedRowNo = 0;
            cmd.CommandText = string.Format("update INV_WarehouseNowInfo set Qty = Qty + ({5}) where CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", codeFileNameStr, repertoryIdInt, locationIdInt, projectNoStr, shelfIdInt, qtyDouble);
            affectedRowNo = cmd.ExecuteNonQuery();
            if (affectedRowNo == 0)
            {
                cmd.CommandText = string.Format("insert into INV_WarehouseNowInfo(CodeFileName, RepertoryId, LocationId, ProjectNo, ShelfId, Qty) values ('{0}', {1}, {2}, '{3}', {4}, {5})", codeFileNameStr, repertoryIdInt, locationIdInt, projectNoStr, shelfIdInt, qtyDouble);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 更新当前库存数，所有库存登记单全部统计，整年全部更新
        /// </summary>
        public void UpdateWarehouseNowInfo_AllOrderTotal_YearAgain(int yearInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        DateTime curYearFirstDate = new DateTime(yearInt, 1, 1);
                        DateTime nextYearFirstDate = curYearFirstDate.AddYears(1);

                        cmd.CommandText = string.Format("select Count(*) from INV_WarehouseBeginingInfo where BeginingDate > {0}", yearInt);
                        int countInt = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                        if (countInt > 0)
                        {
                            cmd.Transaction.Rollback();
                            MessageHandler.ShowMessageBox(string.Format("年份[{0}]的库存已经结转到下一年，不可以重新更新当前库存数。", yearInt));
                            return;
                        }

                        cmd.CommandText = string.Format("update INV_WarehouseNowInfo set Qty = 0");
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("update INV_WarehouseNowInfo set Qty = IsNull(beg.Qty, 0) from INV_WarehouseNowInfo as nowInfo left join F_ProductOpenAccount_Beginning('{0}', '{1}') as beg on nowInfo.CodeFileName = beg.CodeFileName and nowInfo.RepertoryId = beg.RepertoryId and nowInfo.LocationId = beg.LocationId and nowInfo.ProjectNo = beg.ProjectNo and nowInfo.ShelfId = beg.ShelfId", curYearFirstDate.ToString("yyyy-MM-dd"), nextYearFirstDate.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("insert into INV_WarehouseNowInfo (CodeFileName, RepertoryId, LocationId, ProjectNo, ShelfId, Qty) select CodeFileName, RepertoryId, LocationId, ProjectNo, ShelfId, Qty from F_ProductOpenAccount_Beginning('{0}', '{1}') as beg where not exists (select * from INV_WarehouseNowInfo as nowInfo where nowInfo.CodeFileName = beg.CodeFileName and nowInfo.RepertoryId = beg.RepertoryId and nowInfo.LocationId = beg.LocationId and nowInfo.ProjectNo = beg.ProjectNo and nowInfo.ShelfId = beg.ShelfId)", curYearFirstDate.ToString("yyyy-MM-dd"), nextYearFirstDate.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();

                        LogHandler.RecordLog(cmd, "当前库存数全部重新更新。");

                        MessageHandler.ShowMessageBox("当前库存数全部重新更新成功。");

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
        /// 是否可以新增库存单据
        /// </summary>
        public bool IsNewWarehouseOrder()
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        DateTime serverTime = BaseSQL.GetServerDateTime();

                        if (!IsDeleteWarehouseOrder(cmd, serverTime))
                            return false;

                        if (!IsHistoryOrder(cmd, serverTime))
                            return false;

                        //int yearInt = serverTime.Year;
                        //string sqlStr = string.Format("select Count(*) from INV_WarehouseBeginingInfo where BeginingDate = {0}", yearInt);
                        //int countInt = DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
                        //if (countInt == 0)
                        //{
                        //    DateTime firstDate = new DateTime(yearInt, 1, 1);
                        //    sqlStr = string.Format("select Count(*) from ( select WarehouseWarrantDate as OpDate from INV_WarehouseWarrantHead Union All select WarehouseReceiptDate as OpDate from INV_WarehouseReceiptHead Union All select SpecialWarehouseWarrantDate as OpDate from INV_SpecialWarehouseWarrantHead Union All select SpecialWarehouseReceiptDate as OpDate from INV_SpecialWarehouseReceiptHead Union All select ReturnedGoodsReportDate as OpDate from INV_ReturnedGoodsReportHead Union All select InventoryAdjustmentsDate as OpDate from INV_InventoryAdjustmentsHead Union All select InventoryMoveDate as OpDate from INV_InventoryMoveHead ) as StockOrderDate where OpDate < '{0}'", firstDate.ToString("yyyy-MM-dd"));
                        //    countInt = DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));

                        //    if (countInt > 0)
                        //    {
                        //        MessageHandler.ShowMessageBox(string.Format("之前年份的库存未做结转，不可以新增[{0}]年的库存单据。", yearInt));
                        //        return false;
                        //    }
                        //}

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
        /// 是否可以修改库存单据
        /// </summary>
        public bool IsAlterWarehouseOrder(DateTime orderDate)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (!IsDeleteWarehouseOrder(cmd, orderDate))
                            return false;

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
        /// 是否可以保存库存单据
        /// </summary>
        public bool IsSaveWarehouseOrder(SqlCommand cmd, DataRow headRow, DateTime orderDate)
        {
            if (!IsDeleteWarehouseOrder(cmd, orderDate))
                return false;

            if (headRow.RowState == DataRowState.Added)
            {
                if (!IsHistoryOrder(cmd, orderDate))
                    return false;
            }
            else
            {

            }
            return true;
        }

        /// <summary>
        /// 是否可以删除库存单据
        /// </summary>
        public bool IsDeleteWarehouseOrder(SqlCommand cmd, DateTime orderDate)
        {
            int yearInt = orderDate.Year;
            cmd.CommandText = string.Format("select Count(*) from INV_WarehouseBeginingInfo where BeginingDate > {0}", yearInt);
            int countInt = DataTypeConvert.GetInt(cmd.ExecuteScalar());
            if (countInt > 0)
            {
                cmd.Transaction.Rollback();
                MessageHandler.ShowMessageBox(string.Format("[{0}]年的库存已经结转到下一年，不可以修改或删除库存单据。", yearInt));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 是否有历史年份的库存单据
        /// </summary>
        private bool IsHistoryOrder(SqlCommand cmd, DateTime orderDate)
        {
            int yearInt = orderDate.Year;
            cmd.CommandText = string.Format("select Count(*) from INV_WarehouseBeginingInfo where BeginingDate = {0}", yearInt);
            int countInt = DataTypeConvert.GetInt(cmd.ExecuteScalar());
            if (countInt == 0)
            {
                DateTime firstDate = new DateTime(yearInt, 1, 1);
                cmd.CommandText = string.Format("select Count(*) from ( select WarehouseWarrantDate as OpDate from INV_WarehouseWarrantHead Union All select WarehouseReceiptDate as OpDate from INV_WarehouseReceiptHead Union All select SpecialWarehouseWarrantDate as OpDate from INV_SpecialWarehouseWarrantHead Union All select SpecialWarehouseReceiptDate as OpDate from INV_SpecialWarehouseReceiptHead Union All select ReturnedGoodsReportDate as OpDate from INV_ReturnedGoodsReportHead Union All select InventoryAdjustmentsDate as OpDate from INV_InventoryAdjustmentsHead Union All select InventoryMoveDate as OpDate from INV_InventoryMoveHead ) as StockOrderDate where OpDate < '{0}'", firstDate.ToString("yyyy-MM-dd"));
                countInt = DataTypeConvert.GetInt(cmd.ExecuteScalar());

                if (countInt > 0)
                {
                    cmd.Transaction.Rollback();
                    MessageHandler.ShowMessageBox(string.Format("之前年份的库存未做结转，不可以新增[{0}]年的库存单据。", yearInt));
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 年库存结转  第一年的当前库存数->第二年的期初库存数    自己写的，未启用
        /// </summary>
        public void YearWarehouseFinish(int yearInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("select Count(*) from INV_WarehouseBeginingInfo where BeginingDate >= {0}", yearInt);
                        int countInt = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                        if (countInt > 0)
                        {
                            cmd.Transaction.Rollback();
                            MessageHandler.ShowMessageBox(string.Format("[{0}]年的库存已经结转，不可以重复结转。", yearInt - 1));
                            return;
                        }

                        //涉及不涉及把当前库存数为0的删除了

                        cmd.CommandText = string.Format("insert into INV_WarehouseBeginingInfo (BeginingDate, RepertoryId, LocationId, ProjectNo, ShelfId, CodeFileName, BeginingQty) select {0}, RepertoryId, LocationId, ProjectNo, ShelfId, CodeFileName, Qty from INV_WarehouseNowInfo", yearInt);
                        cmd.ExecuteNonQuery();

                        LogHandler.RecordLog(cmd, string.Format("[{0}]年的库存结转成功。", yearInt - 1));

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
