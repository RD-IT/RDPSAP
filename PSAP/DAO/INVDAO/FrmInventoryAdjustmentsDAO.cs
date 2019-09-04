using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.INVDAO
{
    class FrmInventoryAdjustmentsDAO
    {
        /// <summary>
        /// 查询库存调整单表头表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="beginDateStr">开始日期字符串</param>
        /// <param name="endDateStr">结束日期字符串</param>
        /// <param name="repertoryIdInt">调整仓库</param>
        /// <param name="projectNoStr">调整项目号</param>
        /// <param name="reqDepStr">部门</param>
        /// <param name="creatorInt">制单人</param>
        /// <param name="commonStr">通用查询条件</param>
        /// <param name="nullTable">是否查询空表</param>
        public void QueryInventoryAdjustmentsHead(DataTable queryDataTable, string beginDateStr, string endDateStr, int repertoryIdInt, int locationIdInt, string projectNoStr, string reqDepStr, int warehouseStateInt, int creatorInt, int approverInt, string commonStr, bool nullTable)
        {
            BaseSQL.Query(QueryInventoryAdjustmentsHead_SQL(beginDateStr, endDateStr, repertoryIdInt, locationIdInt, projectNoStr, reqDepStr, warehouseStateInt, creatorInt, approverInt, commonStr, nullTable), queryDataTable);
        }

        /// <summary>
        /// 查询库存调整单表头表的SQL
        /// </summary>
        public string QueryInventoryAdjustmentsHead_SQL(string beginDateStr, string endDateStr, int repertoryIdInt, int locationIdInt, string projectNoStr, string reqDepStr, int warehouseStateInt, int creatorInt, int approverInt, string commonStr, bool nullTable)
        {
            string sqlStr = " 1=1";
            if (beginDateStr != "")
            {
                sqlStr += string.Format(" and InventoryAdjustmentsDate between '{0}' and '{1}'", beginDateStr, endDateStr);
            }
            if (repertoryIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryId={0}", repertoryIdInt);
            }
            if(locationIdInt!=0)
            {
                sqlStr += string.Format(" and LocationId={0}", locationIdInt);                
            }
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and ProjectNo='{0}'", projectNoStr);
            }
            if (reqDepStr != "")
            {
                sqlStr += string.Format(" and ReqDep='{0}'", reqDepStr);
            }
            if (warehouseStateInt != 0)
            {
                sqlStr += string.Format(" and WarehouseState={0}", warehouseStateInt);
            }
            if (creatorInt != 0)
            {
                sqlStr += string.Format(" and Creator={0}", creatorInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (InventoryAdjustmentsNo like '%{0}%' or Remark like '%{0}%')", commonStr);
            }
            if (approverInt >= 0)
            {
                if (approverInt == 0)
                    sqlStr += string.Format(" and WarehouseState in (1,4)");
                else
                {
                    sqlStr = string.Format("select Head.* from INV_InventoryAdjustmentsHead as Head left join PUR_ApprovalType on Head.ApprovalType = PUR_ApprovalType.TypeNo where {0} and Head.WarehouseState in (1, 4) and ((PUR_ApprovalType.ApprovalCat = 0 and exists (select * from(select top 1 * from F_OrderNoApprovalList(Head.InventoryAdjustmentsNo, Head.ApprovalType) Order by AppSequence) as minlist where Approver = {1})) or(PUR_ApprovalType.ApprovalCat = 1 and exists(select * from F_OrderNoApprovalList(Head.InventoryAdjustmentsNo, Head.ApprovalType) where Approver = {1}))) order by AutoId", sqlStr, approverInt);
                    return sqlStr;
                }
            }
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select * from INV_InventoryAdjustmentsHead where {0} order by AutoId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 查询库存调整单明细表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="inventoryMoveNoStr">调整单号</param>
        public void QueryInventoryAdjustmentsList(DataTable queryDataTable, string inventoryAdjustmentsNoStr, bool nullTable)
        {
            string sqlStr = string.Format(" and InventoryAdjustmentsNo='{0}'", inventoryAdjustmentsNoStr);
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select INV_InventoryAdjustmentsList.*, SW_PartsCode.CodeName from INV_InventoryAdjustmentsList left join SW_PartsCode on INV_InventoryAdjustmentsList.CodeFileName = SW_PartsCode.CodeFileName where 1=1 {0} order by AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 保存库存调整单
        /// </summary>
        /// <param name="IAHeadRow">库存调整单表头数据表</param>
        /// <param name="IAListTable">库存调整单明细数据表</param>
        public int SaveInventoryAdjustments(DataRow IAHeadRow, DataTable IAListTable)
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

                        FrmWarehouseCommonDAO whDAO = new FrmWarehouseCommonDAO();

                        if (!whDAO.IsSaveWarehouseOrder(cmd, IAHeadRow, DataTypeConvert.GetDateTime(IAHeadRow["InventoryAdjustmentsDate"])))
                            return 0;

                        for (int i = 0; i < IAListTable.Rows.Count; i++)
                        {
                            if (IAListTable.Rows[i].RowState == DataRowState.Deleted)
                                continue;
                            IAListTable.Rows[i]["InventoryAdjustmentsDate"] = IAHeadRow["InventoryAdjustmentsDate"];
                            IAListTable.Rows[i]["RepertoryId"] = IAHeadRow["RepertoryId"];
                            IAListTable.Rows[i]["LocationId"] = IAHeadRow["LocationId"];
                            IAListTable.Rows[i]["ProjectNo"] = IAHeadRow["ProjectNo"];
                        }

                        ////检查当前库存数是否满足
                        //if (!SystemInfo.EnableNegativeInventory && !CheckWarehouseNowInfoBeyondCount(cmd, DataTypeConvert.GetString(IAHeadRow["InventoryMoveNo"]), IAListTable))
                        //{
                        //    return 0;
                        //}

                        //if (DataTypeConvert.GetString(IAHeadRow["InventoryAdjustmentsNo"]) == "")//新增
                        if (IAHeadRow.RowState == DataRowState.Added)//新增
                        {
                            string iaNo = BaseSQL.GetMaxCodeNo(cmd, "IA");
                            IAHeadRow["InventoryAdjustmentsNo"] = iaNo;
                            IAHeadRow["CreatorIp"] = SystemInfo.HostIpAddress;

                            for (int i = 0; i < IAListTable.Rows.Count; i++)
                            {
                                IAListTable.Rows[i]["InventoryAdjustmentsNo"] = iaNo;
                            }
                        }
                        else//修改
                        {
                            if (!CheckWarehouseState(IAHeadRow.Table, IAListTable, string.Format("'{0}'", DataTypeConvert.GetString(IAHeadRow["InventoryAdjustmentsNo"])), false, true, true, true))
                                return -1;

                            IAHeadRow["Modifier"] = SystemInfo.user.AutoId;
                            IAHeadRow["ModifierIp"] = SystemInfo.HostIpAddress;
                            IAHeadRow["ModifierTime"] = serverTime;
                        }

                        string iaNoStr = DataTypeConvert.GetString(IAHeadRow["InventoryAdjustmentsNo"]);

                        #region 单独提出为通用方法
                        //string errorText = "";
                        //int affectedRowNo = 0;
                        //if (IAHeadRow.RowState != DataRowState.Added)
                        //{
                        //    SqlCommand cmd_proc_cancel = new SqlCommand("", conn, trans);
                        //    if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc_cancel, iaNoStr, 2, out errorText))
                        //    {
                        //        trans.Rollback();
                        //        MessageHandler.ShowMessageBox("库存调整单取消入库错误--" + errorText);
                        //        return 0;
                        //    }
                        //}

                        //if (IAHeadRow.RowState == DataRowState.Added)
                        //{

                        //}
                        //else
                        //{
                        //    cmd.CommandText = string.Format("select CodeFileName, head.RepertoryId, head.LocationId, head.ProjectNo, list.ShelfId, Sum(Qty) as Qty from INV_InventoryAdjustmentsList as list left join INV_InventoryAdjustmentsHead as head on list.InventoryAdjustmentsNo = head.InventoryAdjustmentsNo where list.InventoryAdjustmentsNo = '{0}' group by CodeFileName, head.RepertoryId, head.LocationId, head.ProjectNo, list.ShelfId", iaNoStr);
                        //    SqlDataAdapter dbListAdapter = new SqlDataAdapter(cmd);
                        //    DataTable dbListTable = new DataTable();
                        //    dbListAdapter.Fill(dbListTable);

                        //    DataTable copyNewTable = IAListTable.GetChanges();
                        //    copyNewTable.AcceptChanges();
                        //    foreach (DataRow dbRow in dbListTable.Rows)
                        //    {
                        //        string tmpCodeFileName = DataTypeConvert.GetString(dbRow["CodeFileName"]);
                        //        int tmpRepertoryId = DataTypeConvert.GetInt(dbRow["RepertoryId"]);
                        //        int tmpLocationId = DataTypeConvert.GetInt(dbRow["LocationId"]);
                        //        string tmpProjectNo = DataTypeConvert.GetString(dbRow["ProjectNo"]);
                        //        int tmpShelfId = DataTypeConvert.GetInt(dbRow["ShelfId"]);
                        //        double tmpQty = DataTypeConvert.GetDouble(dbRow["Qty"]);
                        //        double iaSumQty = 0;
                        //        if (tmpQty > 0)
                        //        {
                        //            iaSumQty = DataTypeConvert.GetDouble(copyNewTable.Compute("Sum(Qty)", string.Format("CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", tmpCodeFileName, tmpRepertoryId, tmpLocationId, tmpProjectNo, tmpShelfId)));
                        //        }
                        //        if (tmpQty == iaSumQty)
                        //        {

                        //        }
                        //        else
                        //        {
                        //            cmd.CommandText = string.Format("update INV_WarehouseNowInfo set Qty = Qty + ({5}) where CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", tmpCodeFileName, tmpRepertoryId, tmpLocationId, tmpProjectNo, tmpShelfId, iaSumQty - tmpQty);
                        //            affectedRowNo = cmd.ExecuteNonQuery();
                        //            if (affectedRowNo == 0)
                        //            {
                        //                cmd.CommandText = string.Format("insert into INV_WarehouseNowInfo(CodeFileName, RepertoryId, LocationId, ProjectNo, ShelfId, Qty) values ('{0}', {1}, {2}, '{3}', {4}, {5})", tmpCodeFileName, tmpRepertoryId, tmpLocationId, tmpProjectNo, tmpShelfId, iaSumQty - tmpQty);
                        //                cmd.ExecuteNonQuery();
                        //            }
                        //        }

                        //        DataRow[] drs = copyNewTable.Select(string.Format("CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", tmpCodeFileName, tmpRepertoryId, tmpLocationId, tmpProjectNo, tmpShelfId));

                        //        foreach (DataRow dr in drs)
                        //        {
                        //            copyNewTable.Rows.Remove(dr);
                        //        }
                        //    }

                        //    foreach (DataRow newRow in copyNewTable.Rows)
                        //    {
                        //        string newCodeFileName = DataTypeConvert.GetString(newRow["CodeFileName"]);
                        //        int newRepertoryId = DataTypeConvert.GetInt(newRow["RepertoryId"]);
                        //        int newLocationId = DataTypeConvert.GetInt(newRow["LocationId"]);
                        //        string newProjectNo = DataTypeConvert.GetString(newRow["ProjectNo"]);
                        //        int newShelfId = DataTypeConvert.GetInt(newRow["ShelfId"]);
                        //        double newQty = DataTypeConvert.GetDouble(newRow["Qty"]);

                        //        cmd.CommandText = string.Format("update INV_WarehouseNowInfo set Qty = Qty + ({5}) where CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", newCodeFileName, newRepertoryId, newLocationId, newProjectNo, newShelfId, newQty);
                        //        affectedRowNo = cmd.ExecuteNonQuery();
                        //        if (affectedRowNo == 0)
                        //        {
                        //            cmd.CommandText = string.Format("insert into INV_WarehouseNowInfo(CodeFileName, RepertoryId, LocationId, ProjectNo, ShelfId, Qty) values ('{0}', {1}, {2}, '{3}', {4}, {5})", newCodeFileName, newRepertoryId, newLocationId, newProjectNo, newShelfId, newQty);
                        //            cmd.ExecuteNonQuery();
                        //        }
                        //    }
                        //}
                        #endregion

                        DataTable dbListTable = new DataTable();
                        if (IAHeadRow.RowState != DataRowState.Added)
                        {
                            cmd.CommandText = string.Format("select CodeFileName, head.RepertoryId, head.LocationId, head.ProjectNo, list.ShelfId, Sum(Qty) as Qty from INV_InventoryAdjustmentsList as list left join INV_InventoryAdjustmentsHead as head on list.InventoryAdjustmentsNo = head.InventoryAdjustmentsNo where list.InventoryAdjustmentsNo = '{0}' group by CodeFileName, head.RepertoryId, head.LocationId, head.ProjectNo, list.ShelfId", iaNoStr);
                            SqlDataAdapter dbListAdapter = new SqlDataAdapter(cmd);
                            dbListAdapter.Fill(dbListTable);
                        }

                        //保存日志到日志表中
                        string logStr = LogHandler.RecordLog_DataRow(cmd, "库存调整单", IAHeadRow, "InventoryAdjustmentsNo");

                        cmd.CommandText = "select * from INV_InventoryAdjustmentsHead where 1=2";
                        SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                        DataTable tmpHeadTable = new DataTable();
                        adapterHead.Fill(tmpHeadTable);
                        BaseSQL.UpdateDataTable(adapterHead, IAHeadRow.Table.GetChanges());

                        cmd.CommandText = "select * from INV_InventoryAdjustmentsList where 1=2";
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable tmpListTable = new DataTable();
                        adapterList.Fill(tmpListTable);
                        BaseSQL.UpdateDataTable(adapterList, IAListTable.GetChanges());

                        //Set_WWHead_End(cmd, IMListTable);

                        //SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                        //if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, iaNoStr, 1, out errorText))
                        //{
                        //    trans.Rollback();
                        //    MessageHandler.ShowMessageBox("库存调整单入库错误--" + errorText);
                        //    return 0;
                        //}

                        if (whDAO.SaveUpdate_WarehouseNowInfo(conn, trans, cmd, IAHeadRow, IAListTable.Copy(), iaNoStr, dbListTable, "库存调整单", "入库", true) != 1)
                            return 0;

                        if (SystemInfo.InventorySaveApproval)
                        {
                            //cmd.CommandText = string.Format("Insert into PUR_OrderApprovalInfo(OrderHeadNo, Approver, ApproverTime) values ('{0}', {1}, '{2}')", iaNoStr, SystemInfo.user.AutoId, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            //cmd.ExecuteNonQuery();

                            //logStr = LogHandler.RecordLog_OperateRow(cmd, "库存调整单", IAHeadRow, "InventoryAdjustmentsNo", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            new PURDAO.FrmApprovalDAO().InventorySaveApproval(cmd, IAHeadRow, "库存调整单", "InventoryAdjustmentsNo", iaNoStr, serverTime);

                            cmd.CommandText = string.Format("Update INV_InventoryAdjustmentsHead set WarehouseState=2 where InventoryAdjustmentsNo='{0}'", iaNoStr);
                            cmd.ExecuteNonQuery();

                            IAHeadRow["WarehouseState"] = 2;
                        }

                        trans.Commit();
                        IAHeadRow.Table.AcceptChanges();
                        IAListTable.AcceptChanges();

                        return 1;
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
        /// 检测数据库中库存调整单状态是否可以操作
        /// </summary>
        public bool CheckWarehouseState(DataTable iaHeadTable, DataTable iaListTable, string inventoryAdjustmentsNoListStr, bool checkNoApprover, bool checkApprover, bool checkSettle, bool checkApproverBetween)
        {
            string sqlStr = string.Format("select InventoryAdjustmentsNo, WarehouseState from INV_InventoryAdjustmentsHead where InventoryAdjustmentsNo in ({0})", inventoryAdjustmentsNoListStr);
            DataTable tmpTable = BaseSQL.Query(sqlStr).Tables[0];
            for (int i = 0; i < tmpTable.Rows.Count; i++)
            {
                int wState = DataTypeConvert.GetInt(tmpTable.Rows[i]["WarehouseState"]);
                switch (wState)
                {
                    case 1:
                        if (checkNoApprover)
                        {
                            MessageHandler.ShowMessageBox(string.Format("库存调整单[{0}]未审批，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["InventoryAdjustmentsNo"])));
                            iaHeadTable.RejectChanges();
                            if (iaListTable != null)
                                iaListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case 2:
                        if (checkApprover)
                        {
                            MessageHandler.ShowMessageBox(string.Format("库存调整单[{0}]已经审批，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["InventoryAdjustmentsNo"])));
                            iaHeadTable.RejectChanges();
                            if (iaListTable != null)
                                iaListTable.RejectChanges();
                            return false;
                        }
                        break;
                    //case 3:
                    //    if (checkSettle)
                    //    {
                    //        MessageHandler.ShowMessageBox(string.Format("库存调整单[{0}]已经结账，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["InventoryAdjustmentsNo"])));
                    //        swwHeadTable.RejectChanges();
                    //        if (swwListTable != null)
                    //            swwListTable.RejectChanges();
                    //        return false;
                    //    }
                    //    break;
                    case 4:
                        if (checkApproverBetween)
                        {
                            MessageHandler.ShowMessageBox(string.Format("库存调整单[{0}]已经审批中，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["InventoryAdjustmentsNo"])));
                            iaHeadTable.RejectChanges();
                            if (iaListTable != null)
                                iaListTable.RejectChanges();
                            return false;
                        }
                        break;
                }
            }

            return true;
        }

        /// <summary>
        /// 根据选择删除多条库存调整单
        /// </summary>
        public bool DeleteInventoryAdjustments_Multi(DataTable iaHeadTable)
        {
            string iaHeadNoListStr = "";
            for (int i = 0; i < iaHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(iaHeadTable.Rows[i]["Select"]))
                {
                    iaHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(iaHeadTable.Rows[i]["InventoryAdjustmentsNo"]));
                }
            }
            iaHeadNoListStr = iaHeadNoListStr.Substring(0, iaHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(iaHeadTable, null, iaHeadNoListStr, false, true, true, true))
                return false;
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        string errorText = "";
                        //cmd.CommandText = string.Format("select * from INV_InventoryAdjustmentsList where InventoryAdjustmentsNo in ({0})", iaHeadNoListStr);
                        //DataTable tmpTable = new DataTable();
                        //SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        //adpt.Fill(tmpTable);

                        //保存日志到日志表中
                        DataRow[] headRows = iaHeadTable.Select("select=1");
                        FrmWarehouseCommonDAO whDAO = new FrmWarehouseCommonDAO();

                        for (int i = 0; i < headRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_DeleteRow(cmd, "库存调整单", headRows[i], "InventoryAdjustmentsNo");

                            if (!whDAO.IsDeleteWarehouseOrder(cmd, DataTypeConvert.GetDateTime(headRows[i]["InventoryAdjustmentsDate"])))
                                return false;

                            SqlCommand cmd_proc_cancel = new SqlCommand("", conn, trans);
                            if (!whDAO.Update_WarehouseNowInfo(cmd_proc_cancel, DataTypeConvert.GetString(headRows[i]["InventoryAdjustmentsNo"]), 2, out errorText))
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("库存调整单删除入库错误--" + errorText);
                                return false;
                            }
                        }

                        //cmd.CommandText = string.Format("Delete from INV_WarehouseNowInfo where Qty = 0 and exists (select * from INV_InventoryAdjustmentsList as list where list.CodeFileName = INV_WarehouseNowInfo.CodeFileName and list.RepertoryId = INV_WarehouseNowInfo.RepertoryId and list.LocationId = INV_WarehouseNowInfo.LocationId and list.ProjectNo = INV_WarehouseNowInfo.ProjectNo and list.ShelfId = INV_WarehouseNowInfo.ShelfId and InventoryAdjustmentsNo in ({0}))", iaHeadNoListStr);
                        //cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("Delete from INV_InventoryAdjustmentsList where InventoryAdjustmentsNo in ({0})", iaHeadNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from INV_InventoryAdjustmentsHead where InventoryAdjustmentsNo in ({0})", iaHeadNoListStr);
                        cmd.ExecuteNonQuery();

                        //Set_WWHead_End(cmd, tmpTable);

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
        /// 审批选中的多条库存调整单
        /// </summary>
        public bool IAApprovalInfo_Multi(DataTable iaHeadTable, ref int successCountInt)
        {
            string iaHeadNoListStr = "";
            for (int i = 0; i < iaHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(iaHeadTable.Rows[i]["Select"]))
                {
                    iaHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(iaHeadTable.Rows[i]["InventoryAdjustmentsNo"]));
                }
            }

            iaHeadNoListStr = iaHeadNoListStr.Substring(0, iaHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(iaHeadTable, null, iaHeadNoListStr, false, true, true, false))
                return false;
            successCountInt = 0;
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        DateTime serverTime = BaseSQL.GetServerDateTime();

                        if (SystemInfo.InventorySaveApproval)
                        {
                            for (int i = 0; i < iaHeadTable.Rows.Count; i++)
                            {
                                if (DataTypeConvert.GetBoolean(iaHeadTable.Rows[i]["Select"]))
                                {
                                    string iaHeadNoStr = DataTypeConvert.GetString(iaHeadTable.Rows[i]["InventoryAdjustmentsNo"]);

                                    new PURDAO.FrmApprovalDAO().InventorySaveApproval(cmd, iaHeadTable.Rows[i], "库存调整单", "InventoryAdjustmentsNo", iaHeadNoStr, serverTime);

                                    cmd.CommandText = string.Format("Update INV_InventoryAdjustmentsHead set WarehouseState=2 where InventoryAdjustmentsNo='{0}'", iaHeadNoStr);
                                    cmd.ExecuteNonQuery();

                                    iaHeadTable.Rows[i]["WarehouseState"] = 2;

                                    successCountInt++;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < iaHeadTable.Rows.Count; i++)
                            {
                                if (DataTypeConvert.GetBoolean(iaHeadTable.Rows[i]["Select"]))
                                {
                                    DataRow iaRow = iaHeadTable.Rows[i];
                                    string iaHeadNoStr = DataTypeConvert.GetString(iaRow["InventoryAdjustmentsNo"]);

                                    cmd.CommandText = string.Format("select INV_InventoryAdjustmentsHead.InventoryAdjustmentsNo, INV_InventoryAdjustmentsHead.ApprovalType, PUR_ApprovalType.ApprovalCat from INV_InventoryAdjustmentsHead left join PUR_ApprovalType on INV_InventoryAdjustmentsHead.ApprovalType = PUR_ApprovalType.TypeNo where InventoryAdjustmentsNo = '{0}'", iaHeadNoStr);
                                    DataTable tmpTable = new DataTable();
                                    SqlDataAdapter orderadpt = new SqlDataAdapter(cmd);
                                    orderadpt.Fill(tmpTable);
                                    if (tmpTable.Rows.Count == 0)
                                    {
                                        trans.Rollback();
                                        MessageHandler.ShowMessageBox("未查询到要操作的库存调整单，请刷新后再进行操作。");
                                        return false;
                                    }

                                    //Set_OrderHead_End(cmd, orderListTable);

                                    string approvalTypeStr = DataTypeConvert.GetString(tmpTable.Rows[0]["ApprovalType"]);
                                    cmd.CommandText = string.Format("select * from F_OrderNoApprovalList('{0}','{1}') Order by AppSequence", iaHeadNoStr, approvalTypeStr);
                                    DataTable listTable = new DataTable();
                                    SqlDataAdapter listadpt = new SqlDataAdapter(cmd);
                                    listadpt.Fill(listTable);
                                    if (listTable.Rows.Count == 0)
                                    {
                                        cmd.CommandText = string.Format("Update INV_InventoryAdjustmentsHead set WarehouseState = 2 where InventoryAdjustmentsNo='{0}'", iaHeadNoStr);
                                        cmd.ExecuteNonQuery();
                                        iaHeadTable.Rows[i]["WarehouseState"] = 2;
                                        continue;
                                    }
                                    int approvalCatInt = DataTypeConvert.GetInt(tmpTable.Rows[0]["ApprovalCat"]);
                                    switch (approvalCatInt)
                                    {
                                        case 0:
                                            if (DataTypeConvert.GetInt(listTable.Rows[0]["Approver"]) != SystemInfo.user.AutoId)
                                                continue;
                                            break;
                                        case 1:
                                        case 2:
                                            if (listTable.Select(string.Format("Approver={0}", SystemInfo.user.AutoId)).Length == 0)
                                                continue;
                                            break;
                                    }

                                    cmd.CommandText = string.Format("Insert into PUR_OrderApprovalInfo(OrderHeadNo, Approver, ApproverTime) values ('{0}', {1}, '{2}')", iaHeadNoStr, SystemInfo.user.AutoId, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                    cmd.ExecuteNonQuery();

                                    if (listTable.Rows.Count == 1 || approvalCatInt == 2)
                                    {
                                        cmd.CommandText = string.Format("Update INV_InventoryAdjustmentsHead set WarehouseState=2 where InventoryAdjustmentsNo='{0}'", iaHeadNoStr);
                                        cmd.ExecuteNonQuery();
                                        iaHeadTable.Rows[i]["WarehouseState"] = 2;
                                    }
                                    else
                                    {
                                        cmd.CommandText = string.Format("Update INV_InventoryAdjustmentsHead set WarehouseState=4 where InventoryAdjustmentsNo='{0}'", iaHeadNoStr);
                                        cmd.ExecuteNonQuery();
                                        iaHeadTable.Rows[i]["WarehouseState"] = 4;
                                    }

                                    //保存日志到日志表中
                                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "库存调整单", iaHeadTable.Rows[i], "InventoryAdjustmentsNo", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));

                                    //if (DataTypeConvert.GetInt(iaHeadTable.Rows[i]["WarehouseState"]) == 2)//全部审核通过进行下一步操作
                                    //{
                                    //    SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                                    //    string errorText = "";
                                    //    if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, iaHeadNoStr, 1, out errorText))
                                    //    {
                                    //        trans.Rollback();
                                    //        MessageHandler.ShowMessageBox("库存调整单审核出库错误--" + errorText);
                                    //        return false;
                                    //    }
                                    //}

                                    successCountInt++;
                                }
                            }
                        }

                        trans.Commit();
                        iaHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        iaHeadTable.RejectChanges();
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
        /// 取消审批选中的多条库存调整单
        /// </summary>
        public bool CancalIAApprovalInfo_Multi(DataTable iaHeadTable)
        {
            string iaHeadNoListStr = "";
            for (int i = 0; i < iaHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(iaHeadTable.Rows[i]["Select"]))
                {
                    iaHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(iaHeadTable.Rows[i]["InventoryAdjustmentsNo"]));
                    iaHeadTable.Rows[i]["WarehouseState"] = 1;
                }
            }

            iaHeadNoListStr = iaHeadNoListStr.Substring(0, iaHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(iaHeadTable, null, iaHeadNoListStr, true, false, true, false))
                return false;

            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        DateTime serverTime = BaseSQL.GetServerDateTime();
                        cmd.CommandText = string.Format("select InventoryAdjustmentsNo from INV_InventoryAdjustmentsHead where WarehouseState = 2 and InventoryAdjustmentsNo in ({0})", iaHeadNoListStr);
                        DataTable approcalSWWTable = new DataTable();
                        SqlDataAdapter appradpt = new SqlDataAdapter(cmd);
                        appradpt.Fill(approcalSWWTable);

                        cmd.CommandText = string.Format("Delete from PUR_OrderApprovalInfo where OrderHeadNo in ({0})", iaHeadNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Update INV_InventoryAdjustmentsHead set WarehouseState=1 where InventoryAdjustmentsNo in ({0})", iaHeadNoListStr);
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        DataRow[] orderHeadRows = iaHeadTable.Select("select=1");
                        for (int i = 0; i < orderHeadRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "库存调整单", orderHeadRows[i], "InventoryAdjustmentsNo", "取消审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        }

                        //for (int i = 0; i < approcalSWWTable.Rows.Count; i++)
                        //{
                        //    SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                        //    string errorText = "";
                        //    if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, DataTypeConvert.GetString(approcalSWWTable.Rows[i]["InventoryAdjustmentsNo"]), 2, out errorText))
                        //    {
                        //        trans.Rollback();
                        //        MessageHandler.ShowMessageBox("库存调整单取消审核出库错误--" + errorText);
                        //        return false;
                        //    }
                        //}

                        trans.Commit();
                        iaHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        iaHeadTable.RejectChanges();
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
        /// 打印处理
        /// </summary>
        /// <param name="iaHeadNoStr">库存调整单号</param>
        /// <param name="handleTypeInt">打印处理类型：1 预览 2 打印 3 设计</param>
        public void PrintHandle(string iaHeadNoStr, int handleTypeInt)
        {
            DataSet ds = new DataSet();
            DataTable headTable = BaseSQL.GetTableBySql(string.Format("select * from V_Prn_INV_InventoryAdjustmentsHead where InventoryAdjustmentsNo = '{0}' order by AutoId", iaHeadNoStr));
            headTable.TableName = "InventoryAdjustmentsHead";
            for (int i = 0; i < headTable.Columns.Count; i++)
            {
                #region 设定主表显示的标题

                switch (headTable.Columns[i].ColumnName)
                {
                    case "InventoryAdjustmentsNo":
                        headTable.Columns[i].Caption = "调整单号";
                        break;
                    case "InventoryAdjustmentsDate":
                        headTable.Columns[i].Caption = "调整日期";
                        break;
                    case "DepartmentNo":
                        headTable.Columns[i].Caption = "部门编号";
                        break;
                    case "DepartmentName":
                        headTable.Columns[i].Caption = "部门名称";
                        break;
                    case "RepertoryNo":
                        headTable.Columns[i].Caption = "仓库编号";
                        break;
                    case "RepertoryName":
                        headTable.Columns[i].Caption = "仓库名称";
                        break;
                    case "LocationNo":
                        headTable.Columns[i].Caption = "仓位编号";
                        break;
                    case "LocationName":
                        headTable.Columns[i].Caption = "仓位名称";
                        break;
                    case "ProjectNo":
                        headTable.Columns[i].Caption = "项目号";
                        break;
                    case "ProjectName":
                        headTable.Columns[i].Caption = "项目名称";
                        break;
                    case "Remark":
                        headTable.Columns[i].Caption = "备注";
                        break;
                    case "Prepared":
                        headTable.Columns[i].Caption = "制单人";
                        break;
                    case "PreparedIp":
                        headTable.Columns[i].Caption = "制单人IP";
                        break;
                    case "Modifier":
                        headTable.Columns[i].Caption = "修改人";
                        break;
                    case "ModifierIp":
                        headTable.Columns[i].Caption = "修改人IP";
                        break;
                    case "ModifierTime":
                        headTable.Columns[i].Caption = "修改时间";
                        break;
                }

                #endregion
            }
            ds.Tables.Add(headTable);

            DataTable listTable = BaseSQL.GetTableBySql(string.Format("select *, ROW_NUMBER() over (order by AutoId) as RowNum from V_Prn_INV_InventoryAdjustmentsList where InventoryAdjustmentsNo = '{0}' order by AutoId", iaHeadNoStr));
            listTable.TableName = "InventoryAdjustmentsList";
            for (int i = 0; i < listTable.Columns.Count; i++)
            {
                #region 设定子表显示的标题

                switch (listTable.Columns[i].ColumnName)
                {
                    case "RowNum":
                        listTable.Columns[i].Caption = "行号";
                        break;
                    case "InventoryAdjustmentsNo":
                        listTable.Columns[i].Caption = "调整单号";
                        break;
                    case "CodeNo":
                        listTable.Columns[i].Caption = "物料编号";
                        break;
                    case "CodeFileName":
                        listTable.Columns[i].Caption = "零件编号";
                        break;
                    case "CodeName":
                        listTable.Columns[i].Caption = "零件名称";
                        break;
                    case "CatgName":
                        listTable.Columns[i].Caption = "分类名称";
                        break;
                    case "CatgDescription":
                        listTable.Columns[i].Caption = "分类说明";
                        break;
                    case "CodeSpec":
                        listTable.Columns[i].Caption = "规格型号";
                        break;
                    case "CodeWeight":
                        listTable.Columns[i].Caption = "重量";
                        break;
                    case "MaterialVersion":
                        listTable.Columns[i].Caption = "物料版本";
                        break;
                    case "LibName":
                        listTable.Columns[i].Caption = "Level 1";
                        break;
                    case "MaterialCategory":
                        listTable.Columns[i].Caption = "Level 2";
                        break;
                    case "MaterialName":
                        listTable.Columns[i].Caption = "Level 3";
                        break;
                    case "Brand":
                        listTable.Columns[i].Caption = "品牌";
                        break;
                    case "FinishCatg":
                        listTable.Columns[i].Caption = "表面处理";
                        break;
                    case "LevelCatg":
                        listTable.Columns[i].Caption = "加工等级";
                        break;
                    case "Unit":
                        listTable.Columns[i].Caption = "单位";
                        break;
                    case "Qty":
                        listTable.Columns[i].Caption = "调整数量";
                        break;
                    case "Remark":
                        listTable.Columns[i].Caption = "备注";
                        break;                    
                    case "ShelfId":
                        listTable.Columns[i].Caption = "货架ID";
                        break;
                    case "ShelfNo":
                        listTable.Columns[i].Caption = "货架号";
                        break;
                    case "ShelfLocation":
                        listTable.Columns[i].Caption = "货架位置";
                        break;
                }

                #endregion
            }
            ds.Tables.Add(listTable);


            ReportHandler rptHandler = new ReportHandler();
            List<DevExpress.XtraReports.Parameters.Parameter> paralist = rptHandler.GetSystemInfo_ParamList();
            rptHandler.XtraReport_Handle("INV_InventoryAdjustmentsHead", ds, paralist, handleTypeInt);
        }
    }
}
