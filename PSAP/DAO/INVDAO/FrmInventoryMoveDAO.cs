using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.INVDAO
{
    class FrmInventoryMoveDAO
    {
        static PSAP.VIEW.BSVIEW.FrmLanguageINVDAO f = new VIEW.BSVIEW.FrmLanguageINVDAO();
        public FrmInventoryMoveDAO()
        {
            PSAP.BLL.BSBLL.BSBLL.language(f);
        }
        /// <summary>
        /// 查询库存移动单表头表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="beginDateStr">开始日期字符串</param>
        /// <param name="endDateStr">结束日期字符串</param>
        /// <param name="inRepertoryIdInt">入库仓库</param>
        /// <param name="outRepertoryIdInt">出库仓库</param>
        /// <param name="reqDepStr">部门</param>
        /// <param name="creatorInt">制单人</param>
        /// <param name="commonStr">通用查询条件</param>
        /// <param name="nullTable">是否查询空表</param>
        public void QueryInventoryMoveHead(DataTable queryDataTable, string beginDateStr, string endDateStr, int inRepertoryIdInt, int outRepertoryIdInt, int inLocationIdInt, int outLcationIdInt, string reqDepStr, int warehouseStateInt, int creatorInt, int approverInt, string commonStr, bool nullTable)
        {
            BaseSQL.Query(QueryInventoryMoveHead_SQL(beginDateStr, endDateStr, inRepertoryIdInt, outRepertoryIdInt, inLocationIdInt, outLcationIdInt, reqDepStr, warehouseStateInt, creatorInt, approverInt, commonStr, nullTable), queryDataTable);
        }

        /// <summary>
        /// 查询库存移动单表头表的SQL
        /// </summary>
        public string QueryInventoryMoveHead_SQL(string beginDateStr, string endDateStr, int inRepertoryIdInt, int outRepertoryIdInt, int inLocationIdInt, int outLcationIdInt, string reqDepStr, int warehouseStateInt, int creatorInt, int approverInt, string commonStr, bool nullTable)
        {
            string sqlStr = " 1=1";
            if (beginDateStr != "")
            {
                sqlStr += string.Format(" and InventoryMoveDate between '{0}' and '{1}'", beginDateStr, endDateStr);
            }
            if (inRepertoryIdInt != 0)
            {
                sqlStr += string.Format(" and InRepertoryId={0}", inRepertoryIdInt);
            }
            if (outRepertoryIdInt != 0)
            {
                sqlStr += string.Format(" and OutRepertoryId={0}", outRepertoryIdInt);
            }
            if (inLocationIdInt != 0)
            {
                sqlStr += string.Format(" and InLocationId={0}", inLocationIdInt);
            }
            if (outLcationIdInt != 0)
            {
                sqlStr += string.Format(" and OutLocationId={0}", outLcationIdInt);
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
                sqlStr += string.Format(" and (InventoryMoveNo like '%{0}%' or Remark like '%{0}%')", commonStr);
            }
            if (approverInt >= 0)
            {
                if (approverInt == 0)
                    sqlStr += string.Format(" and WarehouseState in (1,4)");
                else
                {
                    sqlStr = string.Format("select Head.* from INV_InventoryMoveHead as Head left join PUR_ApprovalType on Head.ApprovalType = PUR_ApprovalType.TypeNo where {0} and Head.WarehouseState in (1, 4) and ((PUR_ApprovalType.ApprovalCat = 0 and exists (select * from(select top 1 * from F_OrderNoApprovalList(Head.InventoryMoveNo, Head.ApprovalType) Order by AppSequence) as minlist where Approver = {1})) or(PUR_ApprovalType.ApprovalCat = 1 and exists(select * from F_OrderNoApprovalList(Head.InventoryMoveNo, Head.ApprovalType) where Approver = {1}))) order by AutoId", sqlStr, approverInt);
                    return sqlStr;
                }
            }
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select * from INV_InventoryMoveHead where {0} order by AutoId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 查询库存移动单明细表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="inventoryMoveNoStr">移动单号</param>
        public void QueryInventoryMoveList(DataTable queryDataTable, string inventoryMoveNoStr, bool nullTable)
        {
            string sqlStr = string.Format(" and InventoryMoveNo='{0}'", inventoryMoveNoStr);
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select INV_InventoryMoveList.*, SW_PartsCode.CodeName from INV_InventoryMoveList left join SW_PartsCode on INV_InventoryMoveList.CodeFileName = SW_PartsCode.CodeFileName where 1=1 {0} order by AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 保存库存移动单
        /// </summary>
        /// <param name="IMHeadRow">库存移动单表头数据表</param>
        /// <param name="IMListTable">库存移动单明细数据表</param>
        public int SaveInventoryMove(DataRow IMHeadRow, DataTable IMListTable)
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

                        for (int i = 0; i < IMListTable.Rows.Count; i++)
                        {
                            if (IMListTable.Rows[i].RowState == DataRowState.Deleted)
                                continue;
                            IMListTable.Rows[i]["InventoryMoveDate"] = IMHeadRow["InventoryMoveDate"];
                            IMListTable.Rows[i]["InRepertoryId"] = IMHeadRow["InRepertoryId"];
                            IMListTable.Rows[i]["OutRepertoryId"] = IMHeadRow["OutRepertoryId"];
                            IMListTable.Rows[i]["InLocationId"] = IMHeadRow["InLocationId"];
                            IMListTable.Rows[i]["OutLocationId"] = IMHeadRow["OutLocationId"];
                        }

                        ////检查当前库存数是否满足
                        //if (!SystemInfo.EnableNegativeInventory && !CheckWarehouseNowInfoBeyondCount(cmd, DataTypeConvert.GetString(IMHeadRow["InventoryMoveNo"]), IMListTable))
                        //{
                        //    return 0;
                        //}

                        //if (DataTypeConvert.GetString(IMHeadRow["InventoryMoveNo"]) == "")//新增
                        if (IMHeadRow.RowState == DataRowState.Added)//新增
                        {
                            string imNo = BaseSQL.GetMaxCodeNo(cmd, "IM");
                            IMHeadRow["InventoryMoveNo"] = imNo;
                            IMHeadRow["CreatorIp"] = SystemInfo.HostIpAddress;

                            for (int i = 0; i < IMListTable.Rows.Count; i++)
                            {
                                IMListTable.Rows[i]["InventoryMoveNo"] = imNo;
                            }
                        }
                        else//修改
                        {
                            if (!CheckWarehouseState(IMHeadRow.Table, IMListTable, string.Format("'{0}'", DataTypeConvert.GetString(IMHeadRow["InventoryMoveNo"])), false, true, true, true))
                                return -1;

                            IMHeadRow["Modifier"] = SystemInfo.user.AutoId;
                            IMHeadRow["ModifierIp"] = SystemInfo.HostIpAddress;
                            IMHeadRow["ModifierTime"] = BaseSQL.GetServerDateTime();
                        }

                        string imNoStr = DataTypeConvert.GetString(IMHeadRow["InventoryMoveNo"]);
                        //if (IMHeadRow.RowState != DataRowState.Added)
                        //{
                        //    SqlCommand cmd_proc_cancel = new SqlCommand("", conn, trans);
                        //    if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc_cancel, imNoStr, 2, out errorText))
                        //    {
                        //        trans.Rollback();
                        //        MessageHandler.ShowMessageBox("库存移动单取消入库错误--" + errorText);
                        //        return 0;
                        //    }
                        //}

                        DataTable dbInListTable = new DataTable();
                        DataTable dbOutListTable = new DataTable();
                        if (IMHeadRow.RowState != DataRowState.Added)
                        {
                            cmd.CommandText = string.Format("select CodeFileName, head.InRepertoryId, head.InLocationId, list.InProjectNo, list.InShelfId, Sum(Qty) as Qty from INV_InventoryMoveList as list left join INV_InventoryMoveHead as head on list.InventoryMoveNo = head.InventoryMoveNo where list.InventoryMoveNo = '{0}' group by CodeFileName, head.InRepertoryId, head.InLocationId, list.InProjectNo, list.InShelfId", imNoStr);
                            SqlDataAdapter dbInListAdapter = new SqlDataAdapter(cmd);
                            dbInListAdapter.Fill(dbInListTable);

                            cmd.CommandText = string.Format("select CodeFileName, head.OutLocationId, head.OutRepertoryId, list.OutProjectNo, list.OutShelfId, Sum(Qty) as Qty from INV_InventoryMoveList as list left join INV_InventoryMoveHead as head on list.InventoryMoveNo = head.InventoryMoveNo where list.InventoryMoveNo = '{0}' group by CodeFileName, head.OutLocationId, head.OutRepertoryId, list.OutProjectNo, list.OutShelfId", imNoStr);
                            SqlDataAdapter dbOutListAdapter = new SqlDataAdapter(cmd);
                            dbOutListAdapter.Fill(dbOutListTable);
                        }

                        //保存日志到日志表中
                        string logStr = LogHandler.RecordLog_DataRow(cmd, "库存移动单", IMHeadRow, "InventoryMoveNo");

                        cmd.CommandText = "select * from INV_InventoryMoveHead where 1=2";
                        SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                        DataTable tmpHeadTable = new DataTable();
                        adapterHead.Fill(tmpHeadTable);
                        BaseSQL.UpdateDataTable(adapterHead, IMHeadRow.Table.GetChanges());

                        cmd.CommandText = "select * from INV_InventoryMoveList where 1=2";
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable tmpListTable = new DataTable();
                        adapterList.Fill(tmpListTable);
                        BaseSQL.UpdateDataTable(adapterList, IMListTable.GetChanges());

                        //Set_WWHead_End(cmd, IMListTable);

                        //SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                        //if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, imNoStr, 1, out errorText))
                        //{
                        //    trans.Rollback();
                        //    MessageHandler.ShowMessageBox("库存移动单入库错误--" + errorText);
                        //    return 0;
                        //}

                        if (new FrmWarehouseNowInfoDAO().SaveMoveUpdate_WarehouseNowInfo(conn, trans, cmd, IMHeadRow, IMListTable.Copy(), imNoStr, dbInListTable, dbOutListTable) != 1)
                            return 0;

                        if (SystemInfo.InventorySaveApproval)
                        {
                            //cmd.CommandText = string.Format("Insert into PUR_OrderApprovalInfo(OrderHeadNo, Approver, ApproverTime) values ('{0}', {1}, '{2}')", imNoStr, SystemInfo.user.AutoId, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            //cmd.ExecuteNonQuery();

                            //logStr = LogHandler.RecordLog_OperateRow(cmd, "库存移动单", IMHeadRow, "InventoryMoveNo", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            new PURDAO.FrmApprovalDAO().InventorySaveApproval(cmd, IMHeadRow, "库存移动单", "InventoryMoveNo", imNoStr, serverTime);

                            cmd.CommandText = string.Format("Update INV_InventoryMoveHead set WarehouseState=2 where InventoryMoveNo='{0}'", imNoStr);
                            cmd.ExecuteNonQuery();

                            IMHeadRow["WarehouseState"] = 2;
                        }

                        trans.Commit();
                        IMHeadRow.Table.AcceptChanges();
                        IMListTable.AcceptChanges();

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
        /// 检测数据库中库存移动单状态是否可以操作
        /// </summary>
        public bool CheckWarehouseState(DataTable imHeadTable, DataTable imListTable, string inventoryMoveNoListStr, bool checkNoApprover, bool checkApprover, bool checkSettle, bool checkApproverBetween)
        {
            string sqlStr = string.Format("select InventoryMoveNo, WarehouseState from INV_InventoryMoveHead where InventoryMoveNo in ({0})", inventoryMoveNoListStr);
            DataTable tmpTable = BaseSQL.Query(sqlStr).Tables[0];
            for (int i = 0; i < tmpTable.Rows.Count; i++)
            {
                int wState = DataTypeConvert.GetInt(tmpTable.Rows[i]["WarehouseState"]);
                switch (wState)
                {
                    case 1:
                        if (checkNoApprover)
                        {
                            MessageHandler.ShowMessageBox(string.Format("库存移动单[{0}]未审批，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["InventoryMoveNo"])));
                            imHeadTable.RejectChanges();
                            if (imListTable != null)
                                imListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case 2:
                        if (checkApprover)
                        {
                            MessageHandler.ShowMessageBox(string.Format("库存移动单[{0}]已经审批，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["InventoryMoveNo"])));
                            imHeadTable.RejectChanges();
                            if (imListTable != null)
                                imListTable.RejectChanges();
                            return false;
                        }
                        break;
                    //case 3:
                    //    if (checkSettle)
                    //    {
                    //        MessageHandler.ShowMessageBox(string.Format("库存移动单[{0}]已经结账，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["InventoryMoveNo"])));
                    //        swwHeadTable.RejectChanges();
                    //        if (swwListTable != null)
                    //            swwListTable.RejectChanges();
                    //        return false;
                    //    }
                    //    break;
                    case 4:
                        if (checkApproverBetween)
                        {
                            MessageHandler.ShowMessageBox(string.Format("库存移动单[{0}]已经审批中，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["InventoryMoveNo"])));
                            imHeadTable.RejectChanges();
                            if (imListTable != null)
                                imListTable.RejectChanges();
                            return false;
                        }
                        break;
                }
            }

            return true;
        }

        ///// <summary>
        ///// 检查当前库存的数量是否满足库存移动的数量
        ///// </summary>
        //private bool CheckWarehouseNowInfoBeyondCount(SqlCommand cmd, string inventoryMoveNoStr, DataTable imListTable)
        //{
        //    foreach (DataRow lrow in imListTable.Rows)
        //    {
        //        if (lrow.RowState == DataRowState.Deleted)
        //            continue;
        //        string codeFileNameStr = DataTypeConvert.GetString(lrow["CodeFileName"]);
        //        int outRepertoryIdInt = DataTypeConvert.GetInt(lrow["OutRepertoryId"]);
        //        int outLocationIdInt = DataTypeConvert.GetInt(lrow["OutLocationId"]);
        //        string outProjectNoStr = DataTypeConvert.GetString(lrow["OutProjectNo"]);
        //        int outShelfIdInt = DataTypeConvert.GetInt(lrow["OutShelfId"]);
        //        cmd.CommandText = string.Format("select Qty from INV_WarehouseNowInfo where CodeFileName = '{0}' and RepertoryId = {1} and LocationId = {2} and ProjectNo = '{3}' and ShelfId = {4}", codeFileNameStr, outRepertoryIdInt, outLocationIdInt, outProjectNoStr, outShelfIdInt);
        //        double nowQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
        //        string sqlStr = string.Format("CodeFileName = '{0}' and OutRepertoryId = {1} and OutLocationId = {2} and OutProjectNo = '{3}' and OutShelfId = {4}", codeFileNameStr, outRepertoryIdInt, outLocationIdInt, outProjectNoStr, outShelfIdInt);
        //        double qtySum = DataTypeConvert.GetDouble(imListTable.Compute("Sum(Qty)", sqlStr));
        //        if (qtySum > nowQty)
        //        {
        //            //MessageHandler.ShowMessageBox(string.Format("库存移动单中明细[{0}]的数量[{1}]超过当前的库存数量[{2}]，不可以保存。", codeFileNameStr, qtySum, nowQty));
        //            MessageHandler.ShowMessageBox(string.Format(f.tsmiKcyddz.Text + "[{0}]" + f.tsmiDsl.Text + "[{1}]" + f.tsmiCgdqdk.Text + "[{2}]，" + f.tsmiBkybc.Text, codeFileNameStr, qtySum, nowQty));
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        /// <summary>
        /// 根据选择删除多条库存移动单
        /// </summary>
        public bool DeleteInventoryMove_Multi(DataTable imHeadTable)
        {
            string imHeadNoListStr = "";
            for (int i = 0; i < imHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(imHeadTable.Rows[i]["Select"]))
                {
                    imHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(imHeadTable.Rows[i]["InventoryMoveNo"]));
                }
            }
            imHeadNoListStr = imHeadNoListStr.Substring(0, imHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(imHeadTable, null, imHeadNoListStr, false, true, true, true))
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
                        //cmd.CommandText = string.Format("select * from INV_InventoryMoveList where InventoryMoveNo in ({0})", imHeadNoListStr);
                        //DataTable tmpTable = new DataTable();
                        //SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        //adpt.Fill(tmpTable);

                        //保存日志到日志表中
                        DataRow[] headRows = imHeadTable.Select("select=1");
                        for (int i = 0; i < headRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_DeleteRow(cmd, "库存移动单", headRows[i], "InventoryMoveNo");

                            SqlCommand cmd_proc_cancel = new SqlCommand("", conn, trans);
                            if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc_cancel, DataTypeConvert.GetString(headRows[i]["InventoryMoveNo"]), 2, out errorText))
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("库存移动单删除入库错误--" + errorText);
                                return false;
                            }
                        }

                        cmd.CommandText = string.Format("Delete from INV_InventoryMoveList where InventoryMoveNo in ({0})", imHeadNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from INV_InventoryMoveHead where InventoryMoveNo in ({0})", imHeadNoListStr);
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
        /// 审批选中的多条库存移动单
        /// </summary>
        public bool IMApprovalInfo_Multi(DataTable imHeadTable, ref int successCountInt)
        {
            string imHeadNoListStr = "";
            for (int i = 0; i < imHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(imHeadTable.Rows[i]["Select"]))
                {
                    imHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(imHeadTable.Rows[i]["InventoryMoveNo"]));
                }
            }

            imHeadNoListStr = imHeadNoListStr.Substring(0, imHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(imHeadTable, null, imHeadNoListStr, false, true, true, false))
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
                            for (int i = 0; i < imHeadTable.Rows.Count; i++)
                            {
                                if (DataTypeConvert.GetBoolean(imHeadTable.Rows[i]["Select"]))
                                {
                                    string imHeadNoStr = DataTypeConvert.GetString(imHeadTable.Rows[i]["InventoryMoveNo"]);

                                    new PURDAO.FrmApprovalDAO().InventorySaveApproval(cmd, imHeadTable.Rows[i], "库存移动单", "InventoryMoveNo", imHeadNoStr, serverTime);

                                    cmd.CommandText = string.Format("Update INV_InventoryMoveHead set WarehouseState=2 where InventoryMoveNo='{0}'", imHeadNoStr);
                                    cmd.ExecuteNonQuery();

                                    imHeadTable.Rows[i]["WarehouseState"] = 2;

                                    successCountInt++;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < imHeadTable.Rows.Count; i++)
                            {
                                if (DataTypeConvert.GetBoolean(imHeadTable.Rows[i]["Select"]))
                                {
                                    DataRow imRow = imHeadTable.Rows[i];
                                    string imHeadNoStr = DataTypeConvert.GetString(imRow["InventoryMoveNo"]);

                                    cmd.CommandText = string.Format("select INV_InventoryMoveHead.InventoryMoveNo, INV_InventoryMoveHead.ApprovalType, PUR_ApprovalType.ApprovalCat from INV_InventoryMoveHead left join PUR_ApprovalType on INV_InventoryMoveHead.ApprovalType = PUR_ApprovalType.TypeNo where InventoryMoveNo = '{0}'", imHeadNoStr);
                                    DataTable tmpTable = new DataTable();
                                    SqlDataAdapter orderadpt = new SqlDataAdapter(cmd);
                                    orderadpt.Fill(tmpTable);
                                    if (tmpTable.Rows.Count == 0)
                                    {
                                        trans.Rollback();
                                        MessageHandler.ShowMessageBox("未查询到要操作的库存移动单，请刷新后再进行操作。");
                                        return false;
                                    }

                                    //Set_OrderHead_End(cmd, orderListTable);

                                    string approvalTypeStr = DataTypeConvert.GetString(tmpTable.Rows[0]["ApprovalType"]);
                                    cmd.CommandText = string.Format("select * from F_OrderNoApprovalList('{0}','{1}') Order by AppSequence", imHeadNoStr, approvalTypeStr);
                                    DataTable listTable = new DataTable();
                                    SqlDataAdapter listadpt = new SqlDataAdapter(cmd);
                                    listadpt.Fill(listTable);
                                    if (listTable.Rows.Count == 0)
                                    {
                                        cmd.CommandText = string.Format("Update INV_InventoryMoveHead set WarehouseState = 2 where InventoryMoveNo='{0}'", imHeadNoStr);
                                        cmd.ExecuteNonQuery();
                                        imHeadTable.Rows[i]["WarehouseState"] = 2;
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

                                    cmd.CommandText = string.Format("Insert into PUR_OrderApprovalInfo(OrderHeadNo, Approver, ApproverTime) values ('{0}', {1}, '{2}')", imHeadNoStr, SystemInfo.user.AutoId, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                    cmd.ExecuteNonQuery();

                                    if (listTable.Rows.Count == 1 || approvalCatInt == 2)
                                    {
                                        cmd.CommandText = string.Format("Update INV_InventoryMoveHead set WarehouseState=2 where InventoryMoveNo='{0}'", imHeadNoStr);
                                        cmd.ExecuteNonQuery();
                                        imHeadTable.Rows[i]["WarehouseState"] = 2;
                                    }
                                    else
                                    {
                                        cmd.CommandText = string.Format("Update INV_InventoryMoveHead set WarehouseState=4 where InventoryMoveNo='{0}'", imHeadNoStr);
                                        cmd.ExecuteNonQuery();
                                        imHeadTable.Rows[i]["WarehouseState"] = 4;
                                    }

                                    //保存日志到日志表中
                                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "库存移动单", imHeadTable.Rows[i], "InventoryMoveNo", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));

                                    //if (DataTypeConvert.GetInt(imHeadTable.Rows[i]["WarehouseState"]) == 2)//全部审核通过进行下一步操作
                                    //{
                                    //    SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                                    //    string errorText = "";
                                    //    if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, imHeadNoStr, 1, out errorText))
                                    //    {
                                    //        trans.Rollback();
                                    //        MessageHandler.ShowMessageBox("库存移动单审核出库错误--" + errorText);
                                    //        return false;
                                    //    }
                                    //}

                                    successCountInt++;
                                }
                            }
                        }

                        trans.Commit();
                        imHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        imHeadTable.RejectChanges();
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
        /// 取消审批选中的多条库存移动单
        /// </summary>
        public bool CancalIMApprovalInfo_Multi(DataTable imHeadTable)
        {
            string imHeadNoListStr = "";
            for (int i = 0; i < imHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(imHeadTable.Rows[i]["Select"]))
                {
                    imHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(imHeadTable.Rows[i]["InventoryMoveNo"]));
                    imHeadTable.Rows[i]["WarehouseState"] = 1;
                }
            }

            imHeadNoListStr = imHeadNoListStr.Substring(0, imHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(imHeadTable, null, imHeadNoListStr, true, false, true, false))
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
                        cmd.CommandText = string.Format("select InventoryMoveNo from INV_InventoryMoveHead where WarehouseState = 2 and InventoryMoveNo in ({0})", imHeadNoListStr);
                        DataTable approcalIMTable = new DataTable();
                        SqlDataAdapter appradpt = new SqlDataAdapter(cmd);
                        appradpt.Fill(approcalIMTable);

                        cmd.CommandText = string.Format("Delete from PUR_OrderApprovalInfo where OrderHeadNo in ({0})", imHeadNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Update INV_InventoryMoveHead set WarehouseState=1 where InventoryMoveNo in ({0})", imHeadNoListStr);
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        DataRow[] orderHeadRows = imHeadTable.Select("select=1");
                        for (int i = 0; i < orderHeadRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "库存移动单", orderHeadRows[i], "InventoryMoveNo", "取消审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        }

                        //for (int i = 0; i < approcalIMTable.Rows.Count; i++)
                        //{
                        //    SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                        //    string errorText = "";
                        //    if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, DataTypeConvert.GetString(approcalIMTable.Rows[i]["InventoryMoveNo"]), 2, out errorText))
                        //    {
                        //        trans.Rollback();
                        //        MessageHandler.ShowMessageBox("库存移动单取消审核出库错误--" + errorText);
                        //        return false;
                        //    }
                        //}

                        trans.Commit();
                        imHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        imHeadTable.RejectChanges();
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
        /// <param name="imHeadNoStr">库存移动单号</param>
        /// <param name="handleTypeInt">打印处理类型：1 预览 2 打印 3 设计</param>
        public void PrintHandle(string imHeadNoStr, int handleTypeInt)
        {
            DataSet ds = new DataSet();
            DataTable headTable = BaseSQL.GetTableBySql(string.Format("select * from V_Prn_INV_InventoryMoveHead where InventoryMoveNo = '{0}' order by AutoId", imHeadNoStr));
            headTable.TableName = "InventoryMoveHead";
            for (int i = 0; i < headTable.Columns.Count; i++)
            {
                #region 设定主表显示的标题

                switch (headTable.Columns[i].ColumnName)
                {
                    case "InventoryMoveNo":
                        headTable.Columns[i].Caption = "移动单号";
                        break;
                    case "InventoryMoveDate":
                        headTable.Columns[i].Caption = "移动日期";
                        break;
                    case "DepartmentNo":
                        headTable.Columns[i].Caption = "部门编号";
                        break;
                    case "DepartmentName":
                        headTable.Columns[i].Caption = "部门名称";
                        break;
                    case "InRepertoryNo":
                        headTable.Columns[i].Caption = "入库仓库编号";
                        break;
                    case "InRepertoryName":
                        headTable.Columns[i].Caption = "入库仓库名称";
                        break;
                    case "InLocationNo":
                        headTable.Columns[i].Caption = "入库仓位编号";
                        break;
                    case "InLocationName":
                        headTable.Columns[i].Caption = "入库仓位名称";
                        break;
                    case "OutRepertoryNo":
                        headTable.Columns[i].Caption = "出库仓库编号";
                        break;
                    case "OutRepertoryName":
                        headTable.Columns[i].Caption = "出库仓库名称";
                        break;
                    case "OutLocationNo":
                        headTable.Columns[i].Caption = "出库仓位编号";
                        break;
                    case "OutLocationName":
                        headTable.Columns[i].Caption = "出库仓位名称";
                        break;
                    case "Prepared":
                        headTable.Columns[i].Caption = "制单人";
                        break;
                    case "PreparedIp":
                        headTable.Columns[i].Caption = "制单人IP";
                        break;
                    case "Remark":
                        headTable.Columns[i].Caption = "备注";
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

            DataTable listTable = BaseSQL.GetTableBySql(string.Format("select *, ROW_NUMBER() over (order by AutoId) as RowNum from V_Prn_INV_InventoryMoveList where InventoryMoveNo = '{0}' order by AutoId", imHeadNoStr));
            listTable.TableName = "InventoryMoveList";
            for (int i = 0; i < listTable.Columns.Count; i++)
            {
                #region 设定子表显示的标题

                switch (listTable.Columns[i].ColumnName)
                {
                    case "RowNum":
                        listTable.Columns[i].Caption = "行号";
                        break;
                    case "InventoryMoveNo":
                        listTable.Columns[i].Caption = "移动单号";
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
                        listTable.Columns[i].Caption = "移动数量";
                        break;
                    case "InProjectNo":
                        listTable.Columns[i].Caption = "入库项目号";
                        break;
                    case "InProjectName":
                        listTable.Columns[i].Caption = "入库项目名称";
                        break;
                    case "InShelfId":
                        listTable.Columns[i].Caption = "入库货架ID";
                        break;
                    case "InShelfNo":
                        listTable.Columns[i].Caption = "入库货架号";
                        break;
                    case "InShelfLocation":
                        listTable.Columns[i].Caption = "入库货架位置";
                        break;
                    case "OutProjectNo":
                        listTable.Columns[i].Caption = "出库项目号";
                        break;
                    case "OutProjectName":
                        listTable.Columns[i].Caption = "出库项目名称";
                        break;
                    case "OutShelfId":
                        listTable.Columns[i].Caption = "出库货架ID";
                        break;
                    case "OutShelfNo":
                        listTable.Columns[i].Caption = "出库货架号";
                        break;
                    case "OutShelfLocation":
                        listTable.Columns[i].Caption = "出库货架位置";
                        break;
                    case "Remark":
                        listTable.Columns[i].Caption = "备注";
                        break;
                }

                #endregion
            }
            ds.Tables.Add(listTable);

            ReportHandler rptHandler = new ReportHandler();
            List<DevExpress.XtraReports.Parameters.Parameter> paralist = rptHandler.GetSystemInfo_ParamList();
            rptHandler.XtraReport_Handle("INV_InventoryMoveHead", ds, paralist, handleTypeInt);
        }
    }
}
