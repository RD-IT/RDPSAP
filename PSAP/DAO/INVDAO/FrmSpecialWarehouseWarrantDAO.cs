﻿using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSAP.DAO.INVDAO
{
    public class FrmSpecialWarehouseWarrantDAO
    {
        /// <summary>
        /// 查询预算外入库单表头
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="beginDateStr">开始日期字符串</param>
        /// <param name="endDateStr">结束日期字符串</param>
        /// <param name="repertoryIdInt">入库仓库编号</param>
        /// <param name="creatorInt">制单人</param>
        /// <param name="commonStr">通用查询条件</param>
        /// <param name="nullTable">是否查询空表</param>
        public void QuerySpecialWarehouseWarrantHead(DataTable queryDataTable, string beginDateStr, string endDateStr, string reqDepStr, int repertoryIdInt, int locationIdInt, int warehouseStateInt, int creatorInt, int approverInt, string commonStr, bool nullTable)
        {
            BaseSQL.Query(QuerySpecialWarehouseWarrantHead_SQL(beginDateStr, endDateStr, reqDepStr, repertoryIdInt, locationIdInt, warehouseStateInt, creatorInt, approverInt, commonStr, nullTable), queryDataTable);
        }

        /// <summary>
        /// 查询预算外入库单表头的SQL
        /// </summary>
        public string QuerySpecialWarehouseWarrantHead_SQL(string beginDateStr, string endDateStr, string reqDepStr, int repertoryIdInt, int locationIdInt, int warehouseStateInt, int creatorInt, int approverInt, string commonStr, bool nullTable)
        {
            string sqlStr = " 1=1";
            if (beginDateStr != "")
            {
                sqlStr += string.Format(" and SpecialWarehouseWarrantDate between '{0}' and '{1}'", beginDateStr, endDateStr);
            }
            if (reqDepStr != "")
            {
                sqlStr += string.Format(" and ReqDep='{0}'", reqDepStr);
            }
            if (repertoryIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryId={0}", repertoryIdInt);
            }
            if (locationIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryLocationId={0}", locationIdInt);
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
                sqlStr += string.Format(" and (SpecialWarehouseWarrant like '%{0}%' or Remark like '%{0}%')", commonStr);
            }
            if (approverInt >= 0)
            {
                if (approverInt == 0)
                    sqlStr += string.Format(" and WarehouseState in (1,4)");
                else
                {
                    sqlStr = string.Format("select Head.* from INV_SpecialWarehouseWarrantHead as Head left join PUR_ApprovalType on Head.ApprovalType = PUR_ApprovalType.TypeNo where {0} and Head.WarehouseState in (1, 4) and ((PUR_ApprovalType.ApprovalCat = 0 and exists (select * from(select top 1 * from F_OrderNoApprovalList(Head.SpecialWarehouseWarrant, Head.ApprovalType) Order by AppSequence) as minlist where Approver = {1})) or(PUR_ApprovalType.ApprovalCat = 1 and exists(select * from F_OrderNoApprovalList(Head.SpecialWarehouseWarrant, Head.ApprovalType) where Approver = {1}))) order by AutoId", sqlStr, approverInt);
                    return sqlStr;
                }
            }
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select * from INV_SpecialWarehouseWarrantHead where {0} order by AutoId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 查询预算外入库单明细表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="specialWarehouseWarrantStr">预算外入库单号</param>
        public void QuerySpecialWarehouseWarrantList(DataTable queryDataTable, string specialWarehouseWarrantStr, bool nullTable)
        {
            string sqlStr = string.Format(" and SpecialWarehouseWarrant='{0}'", specialWarehouseWarrantStr);
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select INV_SpecialWarehouseWarrantList.*, SW_PartsCode.CodeName, BS_ProjectList.ProjectNo from INV_SpecialWarehouseWarrantList left join SW_PartsCode on INV_SpecialWarehouseWarrantList.CodeId = SW_PartsCode.AutoId left join BS_ProjectList on INV_SpecialWarehouseWarrantList.ProjectName = BS_ProjectList.ProjectName where 1=1 {0} order by AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }


        /// <summary>
        /// 保存预算外入库单
        /// </summary>
        /// <param name="swwHeadRow">预算外入库单表头数据表</param>
        /// <param name="swwListTable">预算外入库单明细数据表</param>
        public int SaveSpecialWarehouseWarrant(DataRow swwHeadRow, DataTable swwListTable)
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

                        if (!whDAO.IsSaveWarehouseOrder(cmd, swwHeadRow, DataTypeConvert.GetDateTime(swwHeadRow["SpecialWarehouseWarrantDate"])))
                            return 0;

                        //if (DataTypeConvert.GetString(swwHeadRow["SpecialWarehouseWarrant"]) == "")//新增
                        if (swwHeadRow.RowState == DataRowState.Added)//新增
                        {
                            string swwNo = BaseSQL.GetMaxCodeNo(cmd, "SW");
                            swwHeadRow["SpecialWarehouseWarrant"] = swwNo;
                            swwHeadRow["PreparedIp"] = SystemInfo.HostIpAddress;

                            for (int i = 0; i < swwListTable.Rows.Count; i++)
                            {
                                swwListTable.Rows[i]["SpecialWarehouseWarrant"] = swwNo;
                            }
                        }
                        else//修改
                        {
                            if (!CheckWarehouseState(swwHeadRow.Table, swwListTable, string.Format("'{0}'", DataTypeConvert.GetString(swwHeadRow["SpecialWarehouseWarrant"])), false, true, true, true))
                                return -1;

                            swwHeadRow["ModifierId"] = SystemInfo.user.AutoId;
                            //swwHeadRow["Modifier"] = SystemInfo.user.EmpName;
                            swwHeadRow["ModifierIp"] = SystemInfo.HostIpAddress;
                            swwHeadRow["ModifierTime"] = serverTime;
                        }

                        string swwNoStr = DataTypeConvert.GetString(swwHeadRow["SpecialWarehouseWarrant"]);

                        DataTable dbListTable = new DataTable();
                        if (swwHeadRow.RowState != DataRowState.Added)
                        {
                            cmd.CommandText = string.Format("select CodeId, CodeFileName, head.RepertoryId, head.RepertoryLocationId, ProjectNo, list.ShelfId, Sum(Qty) as Qty from INV_SpecialWarehouseWarrantList as list left join INV_SpecialWarehouseWarrantHead as head on list.SpecialWarehouseWarrant = head.SpecialWarehouseWarrant left join BS_ProjectList on list.ProjectName = BS_ProjectList.ProjectName where list.SpecialWarehouseWarrant = '{0}' group by CodeId, CodeFileName, head.RepertoryId, head.RepertoryLocationId, ProjectNo, list.ShelfId", swwNoStr);
                            SqlDataAdapter dbListAdapter = new SqlDataAdapter(cmd);
                            dbListAdapter.Fill(dbListTable);
                        }

                        //保存日志到日志表中
                        string logStr = LogHandler.RecordLog_DataRow(cmd, "预算外入库单", swwHeadRow, "SpecialWarehouseWarrant");

                        cmd.CommandText = "select * from INV_SpecialWarehouseWarrantHead where 1=2";
                        SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                        DataTable tmpHeadTable = new DataTable();
                        adapterHead.Fill(tmpHeadTable);
                        BaseSQL.UpdateDataTable(adapterHead, swwHeadRow.Table.GetChanges());

                        cmd.CommandText = "select * from INV_SpecialWarehouseWarrantList where 1=2";
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable tmpListTable = new DataTable();
                        adapterList.Fill(tmpListTable);
                        BaseSQL.UpdateDataTable(adapterList, swwListTable.GetChanges());

                        //Set_OrderHead_End(cmd, swwListTable);

                        if (whDAO.SaveUpdate_WarehouseNowInfo(conn, trans, cmd, swwHeadRow, swwListTable.Copy(), swwNoStr, dbListTable, "预算外入库单", "入库", true) != 1)
                            return 0;

                        if (SystemInfo.InventorySaveApproval)
                        {
                            //cmd.CommandText = string.Format("Insert into PUR_OrderApprovalInfo(OrderHeadNo, Approver, ApproverTime) values ('{0}', {1}, '{2}')", swwNoStr, SystemInfo.user.AutoId, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            //cmd.ExecuteNonQuery();

                            //logStr = LogHandler.RecordLog_OperateRow(cmd, "预算外入库单", swwHeadRow, "SpecialWarehouseWarrant", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            new PURDAO.FrmApprovalDAO().InventorySaveApproval(cmd, swwHeadRow, "预算外入库单", "SpecialWarehouseWarrant", swwNoStr, serverTime);

                            cmd.CommandText = string.Format("Update INV_SpecialWarehouseWarrantHead set WarehouseState=2 where SpecialWarehouseWarrant='{0}'", swwNoStr);
                            cmd.ExecuteNonQuery();

                            swwHeadRow["WarehouseState"] = 2;
                        }

                        trans.Commit();
                        swwHeadRow.Table.AcceptChanges();
                        swwListTable.AcceptChanges();

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
        /// 检测数据库中预算外入库单状态是否可以操作
        /// </summary>
        public bool CheckWarehouseState(DataTable swwHeadTable, DataTable swwListTable, string specialWarehouseWarrantListStr, bool checkNoApprover, bool checkApprover, bool checkSettle, bool checkApproverBetween)
        {
            string sqlStr = string.Format("select SpecialWarehouseWarrant, WarehouseState from INV_SpecialWarehouseWarrantHead where SpecialWarehouseWarrant in ({0})", specialWarehouseWarrantListStr);
            DataTable tmpTable = BaseSQL.Query(sqlStr).Tables[0];
            for (int i = 0; i < tmpTable.Rows.Count; i++)
            {
                int wState = DataTypeConvert.GetInt(tmpTable.Rows[i]["WarehouseState"]);
                switch (wState)
                {
                    case (int)CommonHandler.WarehouseState.待审批:
                        if (checkNoApprover)
                        {
                            MessageHandler.ShowMessageBox(string.Format("预算外入库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["SpecialWarehouseWarrant"]), CommonHandler.WarehouseState.待审批));
                            swwHeadTable.RejectChanges();
                            if (swwListTable != null)
                                swwListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case (int)CommonHandler.WarehouseState.已审批:
                        if (checkApprover)
                        {
                            MessageHandler.ShowMessageBox(string.Format("预算外入库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["SpecialWarehouseWarrant"]), CommonHandler.WarehouseState.已审批));
                            swwHeadTable.RejectChanges();
                            if (swwListTable != null)
                                swwListTable.RejectChanges();
                            return false;
                        }
                        break;
                    //case (int)CommonHandler.WarehouseState.已结账:
                    //    if (checkSettle)
                    //    {
                    //        MessageHandler.ShowMessageBox(string.Format("预算外入库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["SpecialWarehouseWarrant"]),CommonHandler.WarehouseState.已结账));
                    //        swwHeadTable.RejectChanges();
                    //        if (swwListTable != null)
                    //            swwListTable.RejectChanges();
                    //        return false;
                    //    }
                    //    break;
                    case (int)CommonHandler.WarehouseState.审批中:
                        if (checkApproverBetween)
                        {
                            MessageHandler.ShowMessageBox(string.Format("预算外入库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["SpecialWarehouseWarrant"]), CommonHandler.WarehouseState.审批中));
                            swwHeadTable.RejectChanges();
                            if (swwListTable != null)
                                swwListTable.RejectChanges();
                            return false;
                        }
                        break;
                }
            }

            return true;
        }


        /// <summary>
        /// 根据选择删除多条预算外入库单
        /// </summary>
        public bool DeleteSWW_Multi(DataTable swwHeadTable)
        {
            string swwHeadNoListStr = "";
            for (int i = 0; i < swwHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(swwHeadTable.Rows[i]["Select"]))
                {
                    swwHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(swwHeadTable.Rows[i]["SpecialWarehouseWarrant"]));
                }
            }
            swwHeadNoListStr = swwHeadNoListStr.Substring(0, swwHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(swwHeadTable, null, swwHeadNoListStr, false, true, true, true))
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
                        cmd.CommandText = string.Format("select * from INV_SpecialWarehouseWarrantList where SpecialWarehouseWarrant in ({0})", swwHeadNoListStr);
                        DataTable tmpTable = new DataTable();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(tmpTable);

                        //保存日志到日志表中
                        DataRow[] swwHeadRows = swwHeadTable.Select("select=1");
                        FrmWarehouseCommonDAO whDAO = new FrmWarehouseCommonDAO();

                        for (int i = 0; i < swwHeadRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_DeleteRow(cmd, "预算外入库单", swwHeadRows[i], "SpecialWarehouseWarrant");

                            if (!whDAO.IsDeleteWarehouseOrder(cmd, DataTypeConvert.GetDateTime(swwHeadRows[i]["SpecialWarehouseWarrantDate"])))
                                return false;

                            SqlCommand cmd_proc_cancel = new SqlCommand("", conn, trans);
                            if (!whDAO.Update_WarehouseNowInfo(cmd_proc_cancel, DataTypeConvert.GetString(swwHeadRows[i]["SpecialWarehouseWarrant"]), 2, out errorText))
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("预算外入库单删除入库错误--" + errorText);
                                return false;
                            }
                        }

                        cmd.CommandText = string.Format("Delete from INV_SpecialWarehouseWarrantList where SpecialWarehouseWarrant in ({0})", swwHeadNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from INV_SpecialWarehouseWarrantHead where SpecialWarehouseWarrant in ({0})", swwHeadNoListStr);
                        cmd.ExecuteNonQuery();

                        //Set_OrderHead_End(cmd, tmpTable);

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
        /// 审批选中的多条预算外入库单
        /// </summary>
        public bool SWWApprovalInfo_Multi(DataTable swwHeadTable, ref int successCountInt)
        {
            string swwHeadNoListStr = "";
            for (int i = 0; i < swwHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(swwHeadTable.Rows[i]["Select"]))
                {
                    swwHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(swwHeadTable.Rows[i]["SpecialWarehouseWarrant"]));
                }
            }

            swwHeadNoListStr = swwHeadNoListStr.Substring(0, swwHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(swwHeadTable, null, swwHeadNoListStr, false, true, true, false))
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
                            for (int i = 0; i < swwHeadTable.Rows.Count; i++)
                            {
                                if (DataTypeConvert.GetBoolean(swwHeadTable.Rows[i]["Select"]))
                                {
                                    string swwHeadNoStr = DataTypeConvert.GetString(swwHeadTable.Rows[i]["SpecialWarehouseWarrant"]);

                                    new PURDAO.FrmApprovalDAO().InventorySaveApproval(cmd, swwHeadTable.Rows[i], "预算外入库单", "SpecialWarehouseWarrant", swwHeadNoStr, serverTime);

                                    cmd.CommandText = string.Format("Update INV_SpecialWarehouseWarrantHead set WarehouseState={1} where SpecialWarehouseWarrant='{0}'", swwHeadNoStr, (int)CommonHandler.WarehouseState.已审批);
                                    cmd.ExecuteNonQuery();

                                    swwHeadTable.Rows[i]["WarehouseState"] = (int)CommonHandler.WarehouseState.已审批;

                                    successCountInt++;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < swwHeadTable.Rows.Count; i++)
                            {
                                if (DataTypeConvert.GetBoolean(swwHeadTable.Rows[i]["Select"]))
                                {
                                    DataRow swwRow = swwHeadTable.Rows[i];
                                    string swwHeadNoStr = DataTypeConvert.GetString(swwRow["SpecialWarehouseWarrant"]);

                                    cmd.CommandText = string.Format("select INV_SpecialWarehouseWarrantHead.SpecialWarehouseWarrant, INV_SpecialWarehouseWarrantHead.ApprovalType, PUR_ApprovalType.ApprovalCat from INV_SpecialWarehouseWarrantHead left join PUR_ApprovalType on INV_SpecialWarehouseWarrantHead.ApprovalType = PUR_ApprovalType.TypeNo where SpecialWarehouseWarrant = '{0}'", swwHeadNoStr);
                                    DataTable tmpTable = new DataTable();
                                    SqlDataAdapter orderadpt = new SqlDataAdapter(cmd);
                                    orderadpt.Fill(tmpTable);
                                    if (tmpTable.Rows.Count == 0)
                                    {
                                        trans.Rollback();
                                        MessageHandler.ShowMessageBox("未查询到要操作的预算外入库单，请查询后再进行操作。");
                                        return false;
                                    }

                                    ////审批检查入库明细数量是否超过采购订单明细数量
                                    //DataTable orderListTable = new DataTable();
                                    //QueryWarehouseWarrantList(orderListTable, swwHeadNoStr, false);
                                    //if (!CheckOrderApplyBeyondCount(cmd, swwHeadNoStr, orderListTable))
                                    //{
                                    //    trans.Rollback();
                                    //    return false;
                                    //}

                                    //Set_OrderHead_End(cmd, orderListTable);

                                    string approvalTypeStr = DataTypeConvert.GetString(tmpTable.Rows[0]["ApprovalType"]);
                                    cmd.CommandText = string.Format("select * from F_OrderNoApprovalList('{0}','{1}') Order by AppSequence", swwHeadNoStr, approvalTypeStr);
                                    DataTable listTable = new DataTable();
                                    SqlDataAdapter listadpt = new SqlDataAdapter(cmd);
                                    listadpt.Fill(listTable);
                                    if (listTable.Rows.Count == 0)
                                    {
                                        cmd.CommandText = string.Format("Update INV_SpecialWarehouseWarrantHead set WarehouseState={1} where SpecialWarehouseWarrant='{0}'", swwHeadNoStr, (int)CommonHandler.WarehouseState.已审批);
                                        cmd.ExecuteNonQuery();
                                        swwHeadTable.Rows[i]["WarehouseState"] = (int)CommonHandler.WarehouseState.已审批;
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

                                    cmd.CommandText = string.Format("Insert into PUR_OrderApprovalInfo(OrderHeadNo, Approver, ApproverTime) values ('{0}', {1}, '{2}')", swwHeadNoStr, SystemInfo.user.AutoId, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                    cmd.ExecuteNonQuery();

                                    if (listTable.Rows.Count == 1 || approvalCatInt == 2)
                                    {
                                        cmd.CommandText = string.Format("Update INV_SpecialWarehouseWarrantHead set WarehouseState={1} where SpecialWarehouseWarrant='{0}'", swwHeadNoStr, (int)CommonHandler.WarehouseState.已审批);
                                        cmd.ExecuteNonQuery();
                                        swwHeadTable.Rows[i]["WarehouseState"] = (int)CommonHandler.WarehouseState.已审批;
                                    }
                                    else
                                    {
                                        cmd.CommandText = string.Format("Update INV_SpecialWarehouseWarrantHead set WarehouseState={1} where SpecialWarehouseWarrant='{0}'", swwHeadNoStr, (int)CommonHandler.WarehouseState.审批中);
                                        cmd.ExecuteNonQuery();
                                        swwHeadTable.Rows[i]["WarehouseState"] = (int)CommonHandler.WarehouseState.审批中;
                                    }

                                    //保存日志到日志表中
                                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "预算外入库单", swwHeadTable.Rows[i], "SpecialWarehouseWarrant", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));

                                    //if (DataTypeConvert.GetInt(swwHeadTable.Rows[i]["WarehouseState"]) == (int)CommonHandler.WarehouseState.已审批)//全部审批通过进行下一步操作
                                    //{
                                    //    SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                                    //    string errorText = "";
                                    //    if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, swwHeadNoStr, 1, out errorText))
                                    //    {
                                    //        trans.Rollback();
                                    //        MessageHandler.ShowMessageBox("预算外入库单审批入库错误--" + errorText);
                                    //        return false;
                                    //    }
                                    //}

                                    successCountInt++;
                                }
                            }
                        }

                        trans.Commit();
                        swwHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        swwHeadTable.RejectChanges();
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
        /// 取消审批选中的多条预算外入库单
        /// </summary>
        public bool CancalSWWApprovalInfo_Multi(DataTable swwHeadTable)
        {
            string swwHeadNoListStr = "";
            for (int i = 0; i < swwHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(swwHeadTable.Rows[i]["Select"]))
                {
                    swwHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(swwHeadTable.Rows[i]["SpecialWarehouseWarrant"]));
                    swwHeadTable.Rows[i]["WarehouseState"] = (int)CommonHandler.WarehouseState.待审批;
                }
            }

            swwHeadNoListStr = swwHeadNoListStr.Substring(0, swwHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(swwHeadTable, null, swwHeadNoListStr, true, false, true, false))
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
                        cmd.CommandText = string.Format("select SpecialWarehouseWarrant from INV_SpecialWarehouseWarrantHead where WarehouseState={1} and SpecialWarehouseWarrant in ({0})", swwHeadNoListStr, (int)CommonHandler.WarehouseState.已审批);
                        DataTable approcalSWWTable = new DataTable();
                        SqlDataAdapter appradpt = new SqlDataAdapter(cmd);
                        appradpt.Fill(approcalSWWTable);

                        cmd.CommandText = string.Format("Delete from PUR_OrderApprovalInfo where OrderHeadNo in ({0})", swwHeadNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Update INV_SpecialWarehouseWarrantHead set WarehouseState={1} where SpecialWarehouseWarrant in ({0})", swwHeadNoListStr, (int)CommonHandler.WarehouseState.待审批);
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        DataRow[] orderHeadRows = swwHeadTable.Select("select=1");
                        for (int i = 0; i < orderHeadRows.Length; i++)
                        {
                            ////检查是否有下级的主单
                            //if (CheckApplySettlement(cmd, DataTypeConvert.GetString(orderHeadRows[i]["WarehouseWarrant"])))
                            //{
                            //    trans.Rollback();
                            //    swwHeadTable.RejectChanges();
                            //    MessageHandler.ShowMessageBox("入库单已经有适用的采购结账单记录，不可以操作。");
                            //    return false;
                            //}

                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "预算外入库单", orderHeadRows[i], "SpecialWarehouseWarrant", "取消审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        }

                        //for (int i = 0; i < approcalSWWTable.Rows.Count; i++)
                        //{
                        //    SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                        //    string errorText = "";
                        //    if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, DataTypeConvert.GetString(approcalSWWTable.Rows[i]["SpecialWarehouseWarrant"]), 2, out errorText))
                        //    {
                        //        trans.Rollback();
                        //        MessageHandler.ShowMessageBox("预算外入库单取消审批出库错误--" + errorText);
                        //        return false;
                        //    }
                        //}

                        trans.Commit();
                        swwHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        swwHeadTable.RejectChanges();
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
        /// <param name="swwHeadNoStr">预算外入库单号</param>
        /// <param name="handleTypeInt">打印处理类型：1 预览 2 打印 3 设计</param>
        public void PrintHandle(string swwHeadNoStr, int handleTypeInt)
        {
            DataSet ds = new DataSet();
            DataTable headTable = BaseSQL.GetTableBySql(string.Format("select * from V_Prn_INV_SpecialWarehouseWarrantHead where SpecialWarehouseWarrant = '{0}' order by AutoId", swwHeadNoStr));
            headTable.TableName = "SpecialWarehouseWarrantHead";
            for (int i = 0; i < headTable.Columns.Count; i++)
            {
                #region 设定主表显示的标题

                switch (headTable.Columns[i].ColumnName)
                {
                    case "SpecialWarehouseWarrant":
                        headTable.Columns[i].Caption = "预算外入库单号";
                        break;
                    case "SpecialWarehouseWarrantDate":
                        headTable.Columns[i].Caption = "预算外入库日期";
                        break;
                    case "DepartmentNo":
                        headTable.Columns[i].Caption = "部门编号";
                        break;
                    case "DepartmentName":
                        headTable.Columns[i].Caption = "部门名称";
                        break;
                    case "RepertoryNo":
                        headTable.Columns[i].Caption = "入库仓库编号";
                        break;
                    case "RepertoryName":
                        headTable.Columns[i].Caption = "入库仓库名称";
                        break;
                    case "LocationNo":
                        headTable.Columns[i].Caption = "入库仓位编号";
                        break;
                    case "LocationName":
                        headTable.Columns[i].Caption = "入库仓位名称";
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
                    case "ApprovalTypeNo":
                        headTable.Columns[i].Caption = "审批类型编码";
                        break;
                    case "ApprovalTypeNoText":
                        headTable.Columns[i].Caption = "审批类型名称";
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
                    case "WarehouseState":
                        headTable.Columns[i].Caption = "单据状态";
                        break;
                    case "WarehouseStateDesc":
                        headTable.Columns[i].Caption = "单据状态描述";
                        break;
                }

                #endregion
            }
            ds.Tables.Add(headTable);

            DataTable listTable = BaseSQL.GetTableBySql(string.Format("select *, ROW_NUMBER() over (order by AutoId) as RowNum from V_Prn_INV_SpecialWarehouseWarrantList where SpecialWarehouseWarrant = '{0}' order by AutoId", swwHeadNoStr));
            listTable.TableName = "SpecialWarehouseWarrantList";
            for (int i = 0; i < listTable.Columns.Count; i++)
            {
                #region 设定子表显示的标题

                switch (listTable.Columns[i].ColumnName)
                {
                    case "RowNum":
                        listTable.Columns[i].Caption = "行号";
                        break;
                    case "SpecialWarehouseWarrant":
                        listTable.Columns[i].Caption = "预算外入库单号";
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
                        listTable.Columns[i].Caption = "入库数量";
                        break;
                    case "ProjectNo":
                        listTable.Columns[i].Caption = "项目号";
                        break;
                    case "ProjectName":
                        listTable.Columns[i].Caption = "项目名称";
                        break;
                    case "StnNo":
                        listTable.Columns[i].Caption = "站号";
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
            rptHandler.XtraReport_Handle("INV_SpecialWarehouseWarrantHead", ds, paralist, handleTypeInt);
        }
    }
}
