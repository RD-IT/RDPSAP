﻿using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace PSAP.DAO.INVDAO
{
    public class FrmWarehouseWarrantDAO
    {
        static PSAP.VIEW.BSVIEW.FrmLanguageINVDAO f = new VIEW.BSVIEW.FrmLanguageINVDAO();
        public FrmWarehouseWarrantDAO()
        {
            PSAP.BLL.BSBLL.BSBLL.language(f);
        }

        /// <summary>
        /// 得到仓库类别默认的个数
        /// </summary>
        public int Get_WarehouseType_DefaultCount(SqlCommand cmd, string tableNameStr)
        {
            cmd.CommandText = string.Format("Select Count(*) from {0} where IsDefault = 1", tableNameStr);
            return DataTypeConvert.GetInt(cmd.ExecuteScalar());
        }

        /// <summary>
        /// 得到仓库类别默认的类别编号
        /// </summary>
        public string Get_WarehouseType_TypeNo(string tableNameStr, string primaryKeyStr)
        {
            string sqlStr = string.Format("select {1} from {0} where IsDefault = 1", tableNameStr, primaryKeyStr);
            string typeNoStr = DataTypeConvert.GetString(BaseSQL.GetSingle(sqlStr));
            if (typeNoStr != "")
                return typeNoStr;
            else
            {
                sqlStr = string.Format("select top 1 {1} from {0}", tableNameStr, primaryKeyStr);
                return DataTypeConvert.GetString(BaseSQL.GetSingle(sqlStr));
            }
        }

        /// <summary>
        /// 查询入库类别（增加一个全部选项）
        /// </summary>
        public DataTable QueryWarehouseWarrantType(bool addAllItem)
        {
            string sqlStr = "select AutoId, WarehouseWarrantTypeNo, WarehouseWarrantTypeName, IsDefault from BS_WarehouseWarrantType Order by AutoId";
            if (addAllItem)
            {
                //sqlStr = "select 0 as AutoId, '全部' as WarehouseWarrantTypeNo, '全部' as WarehouseWarrantTypeName, 0 as IsDefault union " + sqlStr;
                sqlStr = "select 0 as AutoId, '" + f.tsmiQb.Text + "' as WarehouseWarrantTypeNo, '" + f.tsmiQb.Text + "' as WarehouseWarrantTypeName, 0 as IsDefault union " + sqlStr;

            }
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 更新仓库类别的默认选项
        /// </summary>
        public bool Update_WarehouseType_Default(string warehouseTypeNoStr, string tableNameStr, string primaryKeyStr, string tableLogNameStr)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        cmd.CommandText = string.Format("Update {0} set IsDefault=0", tableNameStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Update {1} set IsDefault=1 where {2} = '{0}'", warehouseTypeNoStr, tableNameStr, primaryKeyStr);
                        cmd.ExecuteNonQuery();

                        string logStr = string.Format("对[{1}]表进行[设定默认值]操作：主键的值为[{0}]", warehouseTypeNoStr, tableLogNameStr);
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
        /// 查询入库单表头
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="beginDateStr">开始日期字符串</param>
        /// <param name="endDateStr">结束日期字符串</param>
        /// <param name="bussinessBaseNoStr">往来方编号</param>
        /// <param name="repertoryIdInt">入库仓库编号</param>
        /// <param name="wwTypeNoStr">入库类别编号</param>
        /// <param name="creatorInt">制单人</param>
        /// <param name="commonStr">通用查询条件</param>
        /// <param name="nullTable">是否查询空表</param>
        public void QueryWarehouseWarrantHead(DataTable queryDataTable, string beginDateStr, string endDateStr, string reqDepStr, string bussinessBaseNoStr, int repertoryIdInt, int locationIdInt, string wwTypeNoStr, int warehouseStateInt, int creatorInt, int approverInt, string commonStr, bool nullTable)
        {
            BaseSQL.Query(QueryWarehouseWarrantHead_SQL(beginDateStr, endDateStr, reqDepStr, bussinessBaseNoStr, repertoryIdInt, locationIdInt, wwTypeNoStr, warehouseStateInt, creatorInt, approverInt, commonStr, 0, nullTable), queryDataTable);
        }

        /// <summary>
        /// 查询入库单表头的SQL
        /// </summary>
        public string QueryWarehouseWarrantHead_SQL(string beginDateStr, string endDateStr, string reqDepStr, string bussinessBaseNoStr, int repertoryIdInt, int locationIdInt, string wwTypeNoStr, int warehouseStateInt, int creatorInt, int approverInt, string commonStr, int orderListAutoIdInt, bool nullTable)
        {
            string sqlStr = " 1=1";
            if (beginDateStr != "")
            {
                sqlStr += string.Format(" and WarehouseWarrantDate between '{0}' and '{1}'", beginDateStr, endDateStr);
            }
            if (reqDepStr != "")
            {
                sqlStr += string.Format(" and ReqDep='{0}'", reqDepStr);
            }
            if (bussinessBaseNoStr != "")
            {
                sqlStr += string.Format(" and BussinessBaseNo='{0}'", bussinessBaseNoStr);
            }
            if (repertoryIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryId={0}", repertoryIdInt);
            }
            if (locationIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryLocationId={0}", locationIdInt);
            }
            if (wwTypeNoStr != "")
            {
                sqlStr += string.Format(" and WarehouseWarrantTypeNo='{0}'", wwTypeNoStr);
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
                sqlStr += string.Format(" and (WarehouseWarrant like '%{0}%' or Remark like '%{0}%' or INV_WarehouseWarrantHead.WarehouseWarrant in (select WarehouseWarrant from INV_WarehouseWarrantList where OrderHeadNo like '%{0}%'))", commonStr);
            }
            if (orderListAutoIdInt > 0)
            {
                sqlStr += string.Format("and WarehouseWarrant in (Select WarehouseWarrant from INV_WarehouseWarrantList where PoListAutoId = {0})", orderListAutoIdInt);
            }
            if (approverInt >= 0)
            {
                if (approverInt == 0)
                    sqlStr += string.Format(" and WarehouseState in (1,4)");
                else
                {
                    //sqlStr = string.Format("select INV_WarehouseWarrantHead.* from INV_WarehouseWarrantHead left join PUR_ApprovalType on INV_WarehouseWarrantHead.ApprovalType = PUR_ApprovalType.TypeNo where {0} and INV_WarehouseWarrantHead.WarehouseState in (1, 4) and( (PUR_ApprovalType.ApprovalCat = 0 and exists (select * from (select top 1 * from F_WarehouseWarrantNoApprovalList(INV_WarehouseWarrantHead.WarehouseWarrant, INV_WarehouseWarrantHead.ApprovalType) Order by AppSequence) as minlist where Approver = {1})) or (PUR_ApprovalType.ApprovalCat = 1 and exists (select * from F_WarehouseWarrantNoApprovalList(INV_WarehouseWarrantHead.WarehouseWarrant, INV_WarehouseWarrantHead.ApprovalType) where Approver = {1}))) order by AutoId", sqlStr, approverInt);
                    sqlStr = string.Format("select Head.* from INV_WarehouseWarrantHead as Head left join PUR_ApprovalType on Head.ApprovalType = PUR_ApprovalType.TypeNo where {0} and Head.WarehouseState in (1, 4) and ((PUR_ApprovalType.ApprovalCat = 0 and exists (select * from(select top 1 * from F_OrderNoApprovalList(Head.WarehouseWarrant, Head.ApprovalType) Order by AppSequence) as minlist where Approver = {1})) or(PUR_ApprovalType.ApprovalCat = 1 and exists(select * from F_OrderNoApprovalList(Head.WarehouseWarrant, Head.ApprovalType) where Approver = {1}))) order by AutoId", sqlStr, approverInt);
                    return sqlStr;
                }
            }
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select * from INV_WarehouseWarrantHead where {0} order by AutoId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 查询入库单明细表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="warehouseWarrantStr">入库单号</param>
        public void QueryWarehouseWarrantList(DataTable queryDataTable, string warehouseWarrantStr, bool nullTable)
        {
            string sqlStr = string.Format(" and WarehouseWarrant='{0}'", warehouseWarrantStr);
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select INV_WarehouseWarrantList.*, SW_PartsCode.CodeName, ProjectNo from INV_WarehouseWarrantList left join SW_PartsCode on INV_WarehouseWarrantList.CodeId = SW_PartsCode.AutoId left join BS_ProjectList on INV_WarehouseWarrantList.ProjectName = BS_ProjectList.ProjectName where 1=1 {0} order by AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 保存入库单
        /// </summary>
        /// <param name="wwHeadRow">入库单表头数据表</param>
        /// <param name="wwListTable">入库单明细数据表</param>
        public int SaveWarehouseWarrant(DataRow wwHeadRow, DataTable wwListTable)
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

                        if (!CheckOrderApplyBeyondCount(cmd, DataTypeConvert.GetString(wwHeadRow["WarehouseWarrant"]), wwListTable))
                        {
                            return 0;
                        }

                        FrmWarehouseCommonDAO whDAO = new FrmWarehouseCommonDAO();

                        if (!whDAO.IsSaveWarehouseOrder(cmd, wwHeadRow, DataTypeConvert.GetDateTime(wwHeadRow["WarehouseWarrantDate"])))
                            return 0;

                        //if (DataTypeConvert.GetString(wwHeadRow["WarehouseWarrant"]) == "")//新增
                        if (wwHeadRow.RowState == DataRowState.Added)//新增
                        {
                            string wwNo = BaseSQL.GetMaxCodeNo(cmd, "WW");
                            wwHeadRow["WarehouseWarrant"] = wwNo;
                            wwHeadRow["PreparedIp"] = SystemInfo.HostIpAddress;

                            for (int i = 0; i < wwListTable.Rows.Count; i++)
                            {
                                wwListTable.Rows[i]["WarehouseWarrant"] = wwNo;
                            }
                        }
                        else//修改
                        {
                            if (!CheckWarehouseState(wwHeadRow.Table, wwListTable, string.Format("'{0}'", DataTypeConvert.GetString(wwHeadRow["WarehouseWarrant"])), false, true, true, true))
                                return -1;

                            wwHeadRow["ModifierId"] = SystemInfo.user.AutoId;
                            wwHeadRow["ModifierIp"] = SystemInfo.HostIpAddress;
                            wwHeadRow["ModifierTime"] = serverTime;
                        }

                        string wwNoStr = DataTypeConvert.GetString(wwHeadRow["WarehouseWarrant"]);

                        DataTable dbListTable = new DataTable();
                        if (wwHeadRow.RowState != DataRowState.Added)
                        {
                            cmd.CommandText = string.Format("select CodeId, CodeFileName, head.RepertoryId, head.RepertoryLocationId, ProjectNo, list.ShelfId, Sum(Qty) as Qty from INV_WarehouseWarrantList as list left join INV_WarehouseWarrantHead as head on list.WarehouseWarrant = head.WarehouseWarrant left join BS_ProjectList on list.ProjectName = BS_ProjectList.ProjectName where list.WarehouseWarrant = '{0}' group by CodeId, CodeFileName, head.RepertoryId, head.RepertoryLocationId, ProjectNo, list.ShelfId", wwNoStr);
                            SqlDataAdapter dbListAdapter = new SqlDataAdapter(cmd);
                            dbListAdapter.Fill(dbListTable);
                        }

                        //保存日志到日志表中
                        string logStr = LogHandler.RecordLog_DataRow(cmd, "入库单", wwHeadRow, "WarehouseWarrant");

                        cmd.CommandText = "select * from INV_WarehouseWarrantHead where 1=2";
                        SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                        DataTable tmpHeadTable = new DataTable();
                        adapterHead.Fill(tmpHeadTable);
                        BaseSQL.UpdateDataTable(adapterHead, wwHeadRow.Table.GetChanges());

                        DataTable copyTable = wwListTable.GetChanges();
                        cmd.CommandText = "select * from INV_WarehouseWarrantList where 1=2";
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable tmpListTable = new DataTable();
                        adapterList.Fill(tmpListTable);
                        BaseSQL.UpdateDataTable(adapterList, copyTable);

                        if (whDAO.SaveUpdate_WarehouseNowInfo(conn, trans, cmd, wwHeadRow, wwListTable.Copy(), wwNoStr, dbListTable, "入库单", "入库", true) != 1)
                            return 0;

                        if (SystemInfo.InventorySaveApproval)
                        {
                            //cmd.CommandText = string.Format("Insert into PUR_OrderApprovalInfo(OrderHeadNo, Approver, ApproverTime) values ('{0}', {1}, '{2}')", wwNoStr, SystemInfo.user.AutoId, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            //cmd.ExecuteNonQuery();

                            //logStr = LogHandler.RecordLog_OperateRow(cmd, "入库单", wwHeadRow, "WarehouseWarrant", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            new PURDAO.FrmApprovalDAO().InventorySaveApproval(cmd, wwHeadRow, "入库单", "WarehouseWarrant", wwNoStr, serverTime);

                            cmd.CommandText = string.Format("Update INV_WarehouseWarrantHead set WarehouseState=2 where WarehouseWarrant='{0}'", wwNoStr);
                            cmd.ExecuteNonQuery();

                            wwHeadRow["WarehouseState"] = 2;
                        }

                        Set_OrderHead_End(cmd, wwListTable);

                        trans.Commit();
                        wwHeadRow.Table.AcceptChanges();
                        wwListTable.AcceptChanges();

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
        /// 检测数据库中入库单状态是否可以操作
        /// </summary>
        public bool CheckWarehouseState(DataTable wwHeadTable, DataTable wwListTable, string warehouseWarrantListStr, bool checkNoApprover, bool checkApprover, bool checkSettle, bool checkApproverBetween)
        {
            string sqlStr = string.Format("select WarehouseWarrant, WarehouseState from INV_WarehouseWarrantHead where WarehouseWarrant in ({0})", warehouseWarrantListStr);
            DataTable tmpTable = BaseSQL.Query(sqlStr).Tables[0];
            for (int i = 0; i < tmpTable.Rows.Count; i++)
            {
                int wState = DataTypeConvert.GetInt(tmpTable.Rows[i]["WarehouseState"]);
                switch (wState)
                {
                    case (int)CommonHandler.WarehouseState.待审批:
                        if (checkNoApprover)
                        {
                            MessageHandler.ShowMessageBox(string.Format("入库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["WarehouseWarrant"]), CommonHandler.WarehouseState.待审批));
                            wwHeadTable.RejectChanges();
                            if (wwListTable != null)
                                wwListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case (int)CommonHandler.WarehouseState.已审批:
                        if (checkApprover)
                        {
                            MessageHandler.ShowMessageBox(string.Format("入库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["WarehouseWarrant"]), CommonHandler.WarehouseState.已审批));
                            wwHeadTable.RejectChanges();
                            if (wwListTable != null)
                                wwListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case (int)CommonHandler.WarehouseState.已结账:
                        if (checkSettle)
                        {
                            MessageHandler.ShowMessageBox(string.Format("入库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["WarehouseWarrant"]), CommonHandler.WarehouseState.已结账));
                            wwHeadTable.RejectChanges();
                            if (wwListTable != null)
                                wwListTable.RejectChanges();
                            return false;
                        }
                        break;
                    case (int)CommonHandler.WarehouseState.审批中:
                        if (checkApproverBetween)
                        {
                            MessageHandler.ShowMessageBox(string.Format("入库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(tmpTable.Rows[i]["WarehouseWarrant"]), CommonHandler.WarehouseState.审批中));
                            wwHeadTable.RejectChanges();
                            if (wwListTable != null)
                                wwListTable.RejectChanges();
                            return false;
                        }
                        break;
                }
            }

            return true;
        }

        /// <summary>
        /// 检查订单明细的数量是否超过采购订单明细的数量
        /// </summary>
        private bool CheckOrderApplyBeyondCount(SqlCommand cmd, string wwHeadNoStr, DataTable wwListTable)
        {
            if (SystemInfo.OrderApplyBeyondCountIsSave)
                return true;

            foreach (DataRow lrow in wwListTable.Rows)
            {
                if (lrow.RowState == DataRowState.Deleted)
                    continue;

                string codeFileNameStr = DataTypeConvert.GetString(lrow["CodeFileName"]);
                int poListAutoId = DataTypeConvert.GetInt(lrow["PoListAutoId"]);
                string sqlStr = string.Format("PoListAutoId = {0}", poListAutoId);
                double qtySum = DataTypeConvert.GetDouble(wwListTable.Compute("Sum(Qty)", sqlStr));
                cmd.CommandText = string.Format("select Sum(List.Qty) from INV_WarehouseWarrantList as List where List.PoListAutoId = {0} and List.WarehouseWarrant != '{1}'", poListAutoId, wwHeadNoStr);
                double otherWWQtySum = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
                cmd.CommandText = string.Format("select Qty from PUR_OrderList where AutoId = {0}", poListAutoId);
                double orderQtySum = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
                if (qtySum + otherWWQtySum > orderQtySum)
                {
                    //MessageHandler.ShowMessageBox(string.Format("入库单中明细[{0}]的数量[{1}]超过采购订单的数量[{2}]，不可以保存。", codeFileNameStr, qtySum + otherWWQtySum, orderQtySum));
                    MessageHandler.ShowMessageBox(string.Format(f.tsmiRkdzmx.Text + "[{0}]" + f.tsmiDsl.Text + "[{1}]" + f.tsmiCgcgdd.Text + "[{2}]" + f.tsmiBkybc.Text, codeFileNameStr, qtySum + otherWWQtySum, orderQtySum));

                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 根据选择删除多条入库单
        /// </summary>
        public bool DeleteWW_Multi(DataTable wwHeadTable)
        {
            string wwHeadNoListStr = "";
            for (int i = 0; i < wwHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(wwHeadTable.Rows[i]["Select"]))
                {
                    wwHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(wwHeadTable.Rows[i]["WarehouseWarrant"]));
                }
            }
            wwHeadNoListStr = wwHeadNoListStr.Substring(0, wwHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(wwHeadTable, null, wwHeadNoListStr, false, true, true, true))
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
                        cmd.CommandText = string.Format("select * from INV_WarehouseWarrantList where WarehouseWarrant in ({0})", wwHeadNoListStr);
                        DataTable tmpTable = new DataTable();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(tmpTable);

                        //保存日志到日志表中
                        DataRow[] wwHeadRows = wwHeadTable.Select("select=1");
                        FrmWarehouseCommonDAO whDAO = new FrmWarehouseCommonDAO();

                        for (int i = 0; i < wwHeadRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_DeleteRow(cmd, "入库单", wwHeadRows[i], "WarehouseWarrant");

                            if (!whDAO.IsDeleteWarehouseOrder(cmd, DataTypeConvert.GetDateTime(wwHeadRows[i]["WarehouseWarrantDate"])))
                                return false;

                            SqlCommand cmd_proc_cancel = new SqlCommand("", conn, trans);                            
                            if (!whDAO.Update_WarehouseNowInfo(cmd_proc_cancel, DataTypeConvert.GetString(wwHeadRows[i]["WarehouseWarrant"]), 2, out errorText))
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("入库单删除入库错误--" + errorText);
                                return false;
                            }
                        }

                        cmd.CommandText = string.Format("Delete from INV_WarehouseWarrantList where WarehouseWarrant in ({0})", wwHeadNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from INV_WarehouseWarrantHead where WarehouseWarrant in ({0})", wwHeadNoListStr);
                        cmd.ExecuteNonQuery();

                        Set_OrderHead_End(cmd, tmpTable);

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
        /// 设定采购单完结标志
        /// </summary>
        public void Set_OrderHead_End(SqlCommand cmd, DataTable orderListTable)
        {
            //string orderHeadNoStr = "";
            //IEnumerable<IGrouping<string, DataRow>> result = orderListTable.Rows.Cast<DataRow>().GroupBy<DataRow, string>(dr => dr["OrderHeadNo"].ToString());//按OrderHeadNo分组
            //foreach (IGrouping<string, DataRow> ig in result)
            //{
            //    if (ig.Key != "")
            //    {
            //        orderHeadNoStr = ig.Key;
            //        cmd.CommandText = string.Format("select Count(*) from V_PUR_OrderList_WarehouseWarrent where OrderHeadNo = '{0}' and Qty>WarehouseWarrentCount", orderHeadNoStr);
            //        int count = DataTypeConvert.GetInt(cmd.ExecuteScalar());
            //        int isEnd = 0;
            //        if (count == 0)
            //            isEnd = 1;
            //        cmd.CommandText = string.Format("Update PUR_OrderHead set IsEnd={1} where OrderHeadNo='{0}'", orderHeadNoStr, isEnd);
            //        cmd.ExecuteNonQuery();
            //    }
            //}

            if (orderListTable == null)
                return;

            List<string> orderHeadNoList = new List<string>();
            foreach (DataRow dr in orderListTable.Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                {
                    if (!orderHeadNoList.Contains(DataTypeConvert.GetString(dr["OrderHeadNo", DataRowVersion.Original])))
                        orderHeadNoList.Add(DataTypeConvert.GetString(dr["OrderHeadNo", DataRowVersion.Original]));
                }
                else
                {
                    if (!orderHeadNoList.Contains(DataTypeConvert.GetString(dr["OrderHeadNo"])))
                        orderHeadNoList.Add(DataTypeConvert.GetString(dr["OrderHeadNo"]));
                }
            }

            foreach (string orderHeadNoStr in orderHeadNoList)
            {
                if (orderHeadNoStr == "")
                    continue;

                cmd.CommandText = string.Format("Update PUR_OrderHead set IsEnd = case when (select Count(*) from V_PUR_OrderList_WarehouseWarrent where OrderHeadNo = '{0}' and Qty > WarehouseWarrentCount) = 0 then 1 else 0 end where OrderHeadNo='{0}'", orderHeadNoStr);
                cmd.ExecuteNonQuery();

                new WORKFLOWDAO.WorkFlowsHandleDAO().Update_WorkFlowsDataCurrentNode_NextHandleEnd(cmd, orderHeadNoStr, WORKFLOWDAO.WorkFlowsHandleDAO.NextWorkFlowsType.入库单);
            }
        }

        /// <summary>
        /// 审批选中的多条入库单
        /// </summary>
        public bool WWApprovalInfo_Multi(DataTable wwHeadTable, ref int successCountInt)
        {
            string wwHeadNoListStr = "";
            for (int i = 0; i < wwHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(wwHeadTable.Rows[i]["Select"]))
                {
                    wwHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(wwHeadTable.Rows[i]["WarehouseWarrant"]));
                }
            }

            wwHeadNoListStr = wwHeadNoListStr.Substring(0, wwHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(wwHeadTable, null, wwHeadNoListStr, false, true, true, false))
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
                            for (int i = 0; i < wwHeadTable.Rows.Count; i++)
                            {
                                if (DataTypeConvert.GetBoolean(wwHeadTable.Rows[i]["Select"]))
                                {
                                    string wwHeadNoStr = DataTypeConvert.GetString(wwHeadTable.Rows[i]["WarehouseWarrant"]);

                                    new PURDAO.FrmApprovalDAO().InventorySaveApproval(cmd, wwHeadTable.Rows[i], "入库单", "WarehouseWarrant", wwHeadNoStr, serverTime);

                                    cmd.CommandText = string.Format("Update INV_WarehouseWarrantHead set WarehouseState={1} where WarehouseWarrant='{0}'", wwHeadNoStr, (int)CommonHandler.WarehouseState.已审批);
                                    cmd.ExecuteNonQuery();

                                    wwHeadTable.Rows[i]["WarehouseState"] = (int)CommonHandler.WarehouseState.已审批;

                                    successCountInt++;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < wwHeadTable.Rows.Count; i++)
                            {
                                if (DataTypeConvert.GetBoolean(wwHeadTable.Rows[i]["Select"]))
                                {
                                    DataRow wwRow = wwHeadTable.Rows[i];
                                    string wwHeadNoStr = DataTypeConvert.GetString(wwRow["WarehouseWarrant"]);

                                    cmd.CommandText = string.Format("select INV_WarehouseWarrantHead.WarehouseWarrant, INV_WarehouseWarrantHead.ApprovalType, PUR_ApprovalType.ApprovalCat from INV_WarehouseWarrantHead left join PUR_ApprovalType on INV_WarehouseWarrantHead.ApprovalType = PUR_ApprovalType.TypeNo where WarehouseWarrant = '{0}'", wwHeadNoStr);
                                    DataTable tmpTable = new DataTable();
                                    SqlDataAdapter orderadpt = new SqlDataAdapter(cmd);
                                    orderadpt.Fill(tmpTable);
                                    if (tmpTable.Rows.Count == 0)
                                    {
                                        trans.Rollback();
                                        //MessageHandler.ShowMessageBox("未查询到要操作的入库单，请查询后再进行操作。");
                                        MessageHandler.ShowMessageBox(f.tsmiWccdyc.Text);
                                        return false;
                                    }

                                    //审批检查入库明细数量是否超过采购订单明细数量
                                    DataTable orderListTable = new DataTable();
                                    QueryWarehouseWarrantList(orderListTable, wwHeadNoStr, false);
                                    if (!CheckOrderApplyBeyondCount(cmd, wwHeadNoStr, orderListTable))
                                    {
                                        trans.Rollback();
                                        return false;
                                    }

                                    Set_OrderHead_End(cmd, orderListTable);

                                    string approvalTypeStr = DataTypeConvert.GetString(tmpTable.Rows[0]["ApprovalType"]);
                                    cmd.CommandText = string.Format("select * from F_OrderNoApprovalList('{0}','{1}') Order by AppSequence", wwHeadNoStr, approvalTypeStr);
                                    DataTable listTable = new DataTable();
                                    SqlDataAdapter listadpt = new SqlDataAdapter(cmd);
                                    listadpt.Fill(listTable);
                                    if (listTable.Rows.Count == 0)
                                    {
                                        cmd.CommandText = string.Format("Update INV_WarehouseWarrantHead set WarehouseState={1} where WarehouseWarrant='{0}'", wwHeadNoStr, (int)CommonHandler.WarehouseState.已审批);
                                        cmd.ExecuteNonQuery();
                                        wwHeadTable.Rows[i]["WarehouseState"] = (int)CommonHandler.WarehouseState.已审批;
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

                                    cmd.CommandText = string.Format("Insert into PUR_OrderApprovalInfo(OrderHeadNo, Approver, ApproverTime) values ('{0}', {1}, '{2}')", wwHeadNoStr, SystemInfo.user.AutoId, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                    cmd.ExecuteNonQuery();

                                    if (listTable.Rows.Count == 1 || approvalCatInt == 2)
                                    {
                                        cmd.CommandText = string.Format("Update INV_WarehouseWarrantHead set WarehouseState={1} where WarehouseWarrant='{0}'", wwHeadNoStr, (int)CommonHandler.WarehouseState.已审批);
                                        cmd.ExecuteNonQuery();
                                        wwHeadTable.Rows[i]["WarehouseState"] = (int)CommonHandler.WarehouseState.已审批;
                                    }
                                    else
                                    {
                                        cmd.CommandText = string.Format("Update INV_WarehouseWarrantHead set WarehouseState={1} where WarehouseWarrant='{0}'", wwHeadNoStr, (int)CommonHandler.WarehouseState.审批中);
                                        cmd.ExecuteNonQuery();
                                        wwHeadTable.Rows[i]["WarehouseState"] = (int)CommonHandler.WarehouseState.审批中;
                                    }

                                    //保存日志到日志表中
                                    string logStr = LogHandler.RecordLog_OperateRow(cmd, "入库单", wwHeadTable.Rows[i], "WarehouseWarrant", "审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));

                                    //if (DataTypeConvert.GetInt(wwHeadTable.Rows[i]["WarehouseState"]) == (int)CommonHandler.WarehouseState.已审批)//全部审批通过进行下一步操作
                                    //{
                                    //    ////更新采购单明细已经进行采购结账的明细的入库单号和入库单明细的AutoId        什么时候采购结账单明细加采购单明细的AutoId什么时候启用
                                    //    //cmd.CommandText = string.Format("update PUR_SettlementList set PUR_SettlementList.WarehouseWarrant = INV_WarehouseWarrantList.WarehouseWarrant, PUR_SettlementList.WarehouseWarrantListAutoId = INV_WarehouseWarrantList.AutoId from INV_WarehouseWarrantList where INV_WarehouseWarrantList.PoListAutoId = PUR_SettlementList.PoListAutoId and INV_WarehouseWarrantList.OrderHeadNo = PUR_SettlementList.OrderHeadNo and INV_WarehouseWarrantList.WarehouseWarrant = '{0}'", wwHeadNoStr);
                                    //    //cmd.ExecuteNonQuery();

                                    //    SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                                    //    string errorText = "";
                                    //    if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, wwHeadNoStr, 1, out errorText))
                                    //    {
                                    //        trans.Rollback();
                                    //        //MessageHandler.ShowMessageBox("入库单审批入库错误--" + errorText);
                                    //        MessageHandler.ShowMessageBox(f.tsmiRkdshr.Text + "--" + errorText);
                                    //        return false;
                                    //    }
                                    //}

                                    successCountInt++;
                                }
                            }
                        }

                        trans.Commit();
                        wwHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        wwHeadTable.RejectChanges();
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
        /// 取消审批选中的多条入库单
        /// </summary>
        public bool CancalWWApprovalInfo_Multi(DataTable wwHeadTable)
        {
            string wwHeadNoListStr = "";
            for (int i = 0; i < wwHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(wwHeadTable.Rows[i]["Select"]))
                {
                    wwHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(wwHeadTable.Rows[i]["WarehouseWarrant"]));
                    wwHeadTable.Rows[i]["WarehouseState"] = (int)CommonHandler.WarehouseState.待审批;
                }
            }

            wwHeadNoListStr = wwHeadNoListStr.Substring(0, wwHeadNoListStr.Length - 1);
            if (!CheckWarehouseState(wwHeadTable, null, wwHeadNoListStr, true, false, true, false))
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
                        cmd.CommandText = string.Format("select WarehouseWarrant from INV_WarehouseWarrantHead where WarehouseState={1} and WarehouseWarrant in ({0})", wwHeadNoListStr, (int)CommonHandler.WarehouseState.已审批);
                        DataTable approcalWWTable = new DataTable();
                        SqlDataAdapter appradpt = new SqlDataAdapter(cmd);
                        appradpt.Fill(approcalWWTable);

                        cmd.CommandText = string.Format("Delete from PUR_OrderApprovalInfo where OrderHeadNo in ({0})", wwHeadNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Update INV_WarehouseWarrantHead set WarehouseState={1} where WarehouseWarrant in ({0})", wwHeadNoListStr, (int)CommonHandler.WarehouseState.待审批);
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        DataRow[] orderHeadRows = wwHeadTable.Select("select=1");
                        for (int i = 0; i < orderHeadRows.Length; i++)
                        {
                            //检查是否有下级的主单
                            if (CheckApply(cmd, DataTypeConvert.GetString(orderHeadRows[i]["WarehouseWarrant"])))
                            {
                                wwHeadTable.RejectChanges();
                                return false;
                            }

                            string logStr = LogHandler.RecordLog_OperateRow(cmd, "入库单", orderHeadRows[i], "WarehouseWarrant", "取消审批", SystemInfo.user.EmpName, serverTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        }

                        //for (int i = 0; i < approcalWWTable.Rows.Count; i++)
                        //{
                        //    SqlCommand cmd_proc = new SqlCommand("", conn, trans);
                        //    string errorText = "";
                        //    if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, DataTypeConvert.GetString(approcalWWTable.Rows[i]["WarehouseWarrant"]), 2, out errorText))
                        //    {
                        //        trans.Rollback();
                        //        //MessageHandler.ShowMessageBox("入库单取消审批出库错误--" + errorText);
                        //        MessageHandler.ShowMessageBox(f.tsmiRkdqxs.Text + "--" + errorText);
                        //        return false;
                        //    }
                        //}

                        trans.Commit();
                        wwHeadTable.AcceptChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        wwHeadTable.RejectChanges();
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
        /// <param name="wwHeadNoStr">入库单号</param>
        /// <param name="handleTypeInt">打印处理类型：1 预览 2 打印 3 设计</param>
        public void PrintHandle(string wwHeadNoStr, int handleTypeInt)
        {
            DataSet ds = new DataSet();
            DataTable headTable = BaseSQL.GetTableBySql(string.Format("select * from V_Prn_INV_WarehouseWarrantHead where WarehouseWarrant = '{0}' order by AutoId", wwHeadNoStr));
            headTable.TableName = "WarehouseWarrantHead";
            for (int i = 0; i < headTable.Columns.Count; i++)
            {
                #region 设定主表显示的标题

                switch (headTable.Columns[i].ColumnName)
                {
                    case "WarehouseWarrant":
                        headTable.Columns[i].Caption = "入库单号";
                        break;
                    case "WarehouseWarrantDate":
                        headTable.Columns[i].Caption = "入库日期";
                        break;
                    case "BussinessBaseNo":
                        headTable.Columns[i].Caption = "供应商编号";
                        break;
                    case "BussinessBaseText":
                        headTable.Columns[i].Caption = "供应商名称";
                        break;
                    case "BussAddress":
                        headTable.Columns[i].Caption = "供应商公司地址";
                        break;
                    case "BussPhoneNo":
                        headTable.Columns[i].Caption = "供应商电话";
                        break;
                    case "BussFaxNo":
                        headTable.Columns[i].Caption = "供应商传真";
                        break;
                    case "BussContact":
                        headTable.Columns[i].Caption = "供应商联系人";
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
                    case "WarehouseWarrantTypeNo":
                        headTable.Columns[i].Caption = "入库类别编号";
                        break;
                    case "WarehouseWarrantTypeName":
                        headTable.Columns[i].Caption = "入库类别名称";
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
                    case "DepartmentNo":
                        headTable.Columns[i].Caption = "部门编号";
                        break;
                    case "DepartmentName":
                        headTable.Columns[i].Caption = "部门名称";
                        break;
                }

                #endregion
            }
            ds.Tables.Add(headTable);

            DataTable listTable = BaseSQL.GetTableBySql(string.Format("select *, ROW_NUMBER() over (order by AutoId) as RowNum from V_Prn_INV_WarehouseWarrantList where WarehouseWarrant = '{0}' order by AutoId", wwHeadNoStr));
            listTable.TableName = "WarehouseWarrantList";
            for (int i = 0; i < listTable.Columns.Count; i++)
            {
                #region 设定子表显示的标题

                switch (listTable.Columns[i].ColumnName)
                {
                    case "RowNum":
                        listTable.Columns[i].Caption = "行号";
                        break;
                    case "WarehouseWarrant":
                        listTable.Columns[i].Caption = "入库单号";
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
                    case "OrderHeadNo":
                        listTable.Columns[i].Caption = "采购单号";
                        break;
                    case "Price":
                        listTable.Columns[i].Caption = "单价";
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
            rptHandler.XtraReport_Handle("INV_WarehouseWarrantHead", ds, paralist, handleTypeInt);
        }

        /// <summary>
        /// 检测数据库中采购结账单是否有适用的记录
        /// </summary>
        private bool CheckApply(SqlCommand cmd, string wwHeadNoStr)
        {
            cmd.CommandText = string.Format("select Count(*) from PUR_SettlementList where WarehouseWarrant = '{0}'", wwHeadNoStr);
            if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
            {
                cmd.Transaction.Rollback();
                MessageHandler.ShowMessageBox(string.Format("入库单[{0}]已经有适用的采购结账单记录，不可以操作。", wwHeadNoStr));
                return true;
            }

            return false;
        }

        ///// <summary>
        ///// 根据入库单明细记录ID查询下级采购结账单
        ///// </summary>
        //public DataTable QueryDownSettlement(int autoIdInt)
        //{
        //    string sqlStr = string.Format("select SettlementNo from PUR_SettlementList where WarehouseWarrantListAutoId = {0}", autoIdInt);
        //    return BaseSQL.Query(sqlStr).Tables[0];
        //}

        /// <summary>
        /// 查询入库未结账表明细的SQL
        /// </summary>
        public string Query_WWList_NoSettlement_SQL(string beginDateStr, string endDateStr, string reqDepStr, string bussinessBaseNoStr, int repertoryIdInt, int repertoryLocationIdInt, string wwTypeNoStr, int warehouseStateInt, string projectNameStr, int codeIdInt, bool containPartSettlementBool, string commonStr)
        {
            string sqlStr = " 1=1";
            if (beginDateStr != "")
            {
                sqlStr += string.Format(" and WarehouseWarrantDate between '{0}' and '{1}'", beginDateStr, endDateStr);
            }
            if (reqDepStr != "")
            {
                sqlStr += string.Format(" and ReqDep='{0}'", reqDepStr);
            }
            if (bussinessBaseNoStr != "")
            {
                sqlStr += string.Format(" and BussinessBaseNo='{0}'", bussinessBaseNoStr);
            }
            if (repertoryIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryId={0}", repertoryIdInt);
            }
            if(repertoryLocationIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryLocationId={0}", repertoryLocationIdInt); 
            }
            if (wwTypeNoStr != "")
            {
                sqlStr += string.Format(" and WarehouseWarrantTypeNo='{0}'", wwTypeNoStr);
            }
            if (warehouseStateInt != 0)
            {
                sqlStr += string.Format(" and WarehouseState={0}", warehouseStateInt);
            }
            if (projectNameStr != "")
            {
                sqlStr += string.Format(" and ProjectName='{0}'", projectNameStr);
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and CodeId={0}", codeIdInt);
            }
            if (!containPartSettlementBool)
            {
                sqlStr += string.Format(" and IsNull(SettlementCount, 0)=0");
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (WarehouseWarrant like '%{0}%' or Remark like '%{0}%' or OrderHeadNo like '%{0}%')", commonStr);
            }

            sqlStr = string.Format("select * from V_INV_WarehouseWarrentList_NoSettleWWList where {0} order by AutoId", sqlStr);
            return sqlStr;
        }
    }
}
