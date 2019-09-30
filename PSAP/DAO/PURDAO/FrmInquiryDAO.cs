using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PSAP.DAO.PURDAO
{
    class FrmInquiryDAO
    {
        /// <summary>
        /// 查询采购询价单主表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="beginDateStr">开始日期字符串</param>
        /// <param name="endDateStr">结束日期字符串</param>
        /// <param name="bussinessBaseNoStr">往来方编号</param>
        /// <param name="departmentNoStr">部门编号</param>
        /// <param name="projectNoStr">项目号</param>
        /// <param name="creatorInt">询价人</param>
        /// <param name="commonStr">通用查询条件</param>
        /// <param name="nullTable">是否查询空表</param>
        public void QueryInquiryHead(DataTable queryDataTable, string beginDateStr, string endDateStr, string bussinessBaseNoStr, string departmentNoStr, string projectNoStr, int codeIdInt, int creatorInt, string commonStr, bool nullTable)
        {
            BaseSQL.Query(QueryInquiryHead_SQL(beginDateStr, endDateStr, bussinessBaseNoStr, departmentNoStr, projectNoStr, codeIdInt, creatorInt, commonStr, nullTable), queryDataTable);
        }
        /// <summary>
        /// 采购询价单主表的SQL
        /// </summary>
        public string QueryInquiryHead_SQL(string beginDateStr, string endDateStr, string bussinessBaseNoStr, string departmentNoStr, string projectNoStr, int codeIdInt, int creatorInt, string commonStr, bool nullTable)
        {
            string sqlStr = " 1=1";
            if (beginDateStr != "")
            {
                sqlStr += BaseSQL.GetDateRegion_SingleColumn_WhereSql("OrderHeadDate", beginDateStr, endDateStr);
            }
            if (bussinessBaseNoStr != "")
            {
                sqlStr += string.Format(" and BussinessBaseNo='{0}'", bussinessBaseNoStr);
            }
            if (departmentNoStr != "")
            {
                sqlStr += string.Format(" and DepartmentNo='{0}'", departmentNoStr);
            }
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and ProjectNo='{0}'", projectNoStr);
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and PIHeadNo in (select PIHeadNo from PUR_InquiryList where CodeId = {0})", codeIdInt);
            }
            if (creatorInt != 0)
            {
                sqlStr += string.Format(" and Creator={0}", creatorInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (PIHeadNo like '%{0}%' or ProjectNo like '%{0}%' or StnNo like '%{0}%' or PIRemark like '%{0}%')", commonStr);
            }
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select * from PUR_InquiryHead where {0} order by AutoId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 查询询价单明细表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="piHeadNoStr">询价单号</param>
        public void QueryInquiryList(DataTable queryDataTable, string piHeadNoStr, bool nullTable)
        {
            string sqlStr = string.Format(" and PIHeadNo='{0}'", piHeadNoStr);
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select PUR_InquiryList.*, SW_PartsCode.CodeFileName, SW_PartsCode.CodeName from PUR_InquiryList left join SW_PartsCode on PUR_InquiryList.CodeId = SW_PartsCode.AutoId where 1=1 {0} order by AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询询价单明细和PR明细关系表 
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="piHeadNoStr">询价单号</param>
        public void QueryPIPR_Relation(DataTable queryDataTable, string piHeadNoStr, bool nullTable)
        {
            string sqlStr = string.Format(" and PIHeadNo='{0}'", piHeadNoStr);
            if (nullTable)
            {
                sqlStr += " and 1=2";
            }
            sqlStr = string.Format("select PUR_PIPR.*, PUR_PrReqList.PrReqNo, PUR_PrReqList.CodeId, PUR_PrReqHead.ProjectNo, PUR_PrReqHead.StnNo, PUR_PrReqList.Qty as MaxPRQty from PUR_PIPR left join PUR_PrReqList on PUR_PIPR.PRListId = PUR_PrReqList.AutoId left join PUR_PrReqHead on PUR_PrReqList.PrReqNo = PUR_PrReqHead.PrReqNo where PIListId in (select AutoId from PUR_InquiryList where 1=1 {0})", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 根据选择删除多条采购询价单
        /// </summary>
        public bool DeleteInquiry_Multi(DataTable inquiryHeadTable)
        {
            string piHeadNoListStr = "";
            for (int i = 0; i < inquiryHeadTable.Rows.Count; i++)
            {
                if (DataTypeConvert.GetBoolean(inquiryHeadTable.Rows[i]["Select"]))
                {
                    piHeadNoListStr += string.Format("'{0}',", DataTypeConvert.GetString(inquiryHeadTable.Rows[i]["PIHeadNo"]));
                }
            }
            piHeadNoListStr = piHeadNoListStr.Substring(0, piHeadNoListStr.Length - 1);
            //if (!CheckOrderState(inquiryHeadTable, null, piHeadNoListStr, false, true, true, true, true, false))
            //    return false;
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        cmd.CommandText = string.Format("select PUR_InquiryList.*, PRListId, PRQty from PUR_InquiryList join PUR_PIPR on PUR_PIPR.PIListId = PUR_InquiryList.AutoId where PIHeadNo in ({0})", piHeadNoListStr);
                        DataTable tmpTable = new DataTable();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(tmpTable);

                        //保存日志到日志表中
                        DataRow[] inquiryHeadRows = inquiryHeadTable.Select("select=1");
                        for (int i = 0; i < inquiryHeadRows.Length; i++)
                        {
                            string logStr = LogHandler.RecordLog_DeleteRow(cmd, "采购询价单", inquiryHeadRows[i], "PIHeadNo");
                        }

                        cmd.CommandText = string.Format("Delete from PUR_PIPR where PIListId in (select AutoId from PUR_InquiryList where PIHeadNo in ({0}))", piHeadNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from PUR_InquiryList where PIHeadNo in ({0})", piHeadNoListStr);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from PUR_InquiryHead where PIHeadNo in ({0})", piHeadNoListStr);
                        cmd.ExecuteNonQuery();

                        //Set_PrReqHead_End(cmd, tmpTable);

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
        /// 保存采购询价单
        /// </summary>
        /// <param name="inquiryHeadRow">采购询价单表头数据表</param>
        /// <param name="inquiryListTable">采购询价单明细数据表</param>
        /// <param name="PIPRTable">采购询价单明细和PR明细关系表</param>
        public int SaveInquiry(DataRow inquiryHeadRow, DataTable inquiryListTable, DataTable PIPRTable)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (!CheckBeyondPrReqCount(cmd, PIPRTable))
                        {
                            return 0;
                        }

                        if (inquiryHeadRow.RowState == DataRowState.Added)//新增
                        {
                            string piHeadNo = BaseSQL.GetMaxCodeNo(cmd, "PI");
                            inquiryHeadRow["PIHeadNo"] = piHeadNo;
                            inquiryHeadRow["CreatorIp"] = SystemInfo.HostIpAddress;
                            inquiryHeadRow["OrderHeadDate"] = BaseSQL.GetServerDateTime();

                            for (int i = 0; i < inquiryListTable.Rows.Count; i++)
                            {
                                inquiryListTable.Rows[i]["PIHeadNo"] = piHeadNo;
                            }
                        }
                        else//修改
                        {
                            inquiryHeadRow["Modifier"] = SystemInfo.user.AutoId;
                            inquiryHeadRow["ModifierIp"] = SystemInfo.HostIpAddress;
                            inquiryHeadRow["ModifierTime"] = BaseSQL.GetServerDateTime();
                        }

                        //保存日志到日志表中
                        string logStr = LogHandler.RecordLog_DataRow(cmd, "询价单", inquiryHeadRow, "PIHeadNo");
                        
                        cmd.CommandText = "select * from PUR_InquiryHead where 1=2";
                        SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                        DataTable tmpHeadTable = new DataTable();
                        adapterHead.Fill(tmpHeadTable);
                        BaseSQL.UpdateDataTable(adapterHead, inquiryHeadRow.Table);

                        for (int i = 0; i < inquiryListTable.Rows.Count; i++)
                        {
                            DataRow tmpRow = inquiryListTable.Rows[i];
                            switch (tmpRow.RowState)
                            {
                                case DataRowState.Added:
                                    cmd.CommandText = string.Format("INSERT INTO PUR_InquiryList(PIHeadNo, CodeId, Qty, UnitPrice, Amount, Tax, TaxAmount, SumAmount, Remark) VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, '{8}')", DataTypeConvert.GetString(tmpRow["PIHeadNo"]), DataTypeConvert.GetInt(tmpRow["CodeId"]), DataTypeConvert.GetDouble(tmpRow["Qty"]), DataTypeConvert.GetDouble(tmpRow["UnitPrice"]), DataTypeConvert.GetDouble(tmpRow["Amount"]), DataTypeConvert.GetDouble(tmpRow["Tax"]), DataTypeConvert.GetDouble(tmpRow["TaxAmount"]), DataTypeConvert.GetDouble(tmpRow["SumAmount"]), DataTypeConvert.GetString(tmpRow["Remark"]));
                                    cmd.ExecuteNonQuery();
                                    cmd.CommandText = string.Format("select @@IDENTITY");
                                    int autoId = DataTypeConvert.GetInt(cmd.ExecuteScalar());

                                    DataRow[] drs = PIPRTable.Select(string.Format("PIListId={0}", inquiryListTable.Rows[i]["AutoId"]));
                                    foreach (DataRow dr in drs)
                                    {
                                        dr["PIListId"] = autoId;
                                    }
                                    break;
                                case DataRowState.Modified:
                                    cmd.CommandText = string.Format("UPDATE PUR_InquiryList SET PIHeadNo = '{1}', CodeId = {2}, Qty = {3}, UnitPrice = {4}, Amount = {5}, Tax = {6}, TaxAmount = {7}, SumAmount = {8}, Remark = '{9}' WHERE AutoId = {0}", DataTypeConvert.GetInt(tmpRow["AutoId"]), DataTypeConvert.GetString(tmpRow["PIHeadNo"]), DataTypeConvert.GetInt(tmpRow["CodeId"]), DataTypeConvert.GetDouble(tmpRow["Qty"]), DataTypeConvert.GetDouble(tmpRow["UnitPrice"]), DataTypeConvert.GetDouble(tmpRow["Amount"]), DataTypeConvert.GetDouble(tmpRow["Tax"]), DataTypeConvert.GetDouble(tmpRow["TaxAmount"]), DataTypeConvert.GetDouble(tmpRow["SumAmount"]), DataTypeConvert.GetString(tmpRow["Remark"]));
                                    cmd.ExecuteNonQuery();
                                    break;
                            }
                        }

                        cmd.CommandText = "select * from PUR_PIPR where 1=2";
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable tmpPIPRTable = new DataTable();
                        adapterList.Fill(tmpPIPRTable);
                        BaseSQL.UpdateDataTable(adapterList, PIPRTable);

                        for (int i = 0; i < inquiryListTable.Rows.Count; i++)
                        {
                            DataRow tmpRow = inquiryListTable.Rows[i];
                            switch (tmpRow.RowState)
                            {
                                case DataRowState.Deleted:
                                    cmd.CommandText = string.Format("Delete from PUR_InquiryList where AutoId = {0}", DataTypeConvert.GetInt(tmpRow["AutoId", DataRowVersion.Original]));
                                    cmd.ExecuteNonQuery();
                                    break;
                            }
                        }

                        //Set_PrReqHead_End(cmd, inquiryListTable);

                        trans.Commit();
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        inquiryHeadRow.Table.RejectChanges();
                        inquiryListTable.RejectChanges();
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
        /// 检查是否超过请购明细单的数量
        /// </summary>
        public bool CheckBeyondPrReqCount(SqlCommand cmd, DataTable PIPRTable)
        {
            foreach (DataRow row in PIPRTable.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                    continue;

                int prListIdInt = DataTypeConvert.GetInt(row["PRListId"]);
                cmd.CommandText = string.Format("select Qty from PUR_PrReqList where AutoId = {0}", prListIdInt);
                double prListQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
                if (prListQty < DataTypeConvert.GetDouble(row["PRQty"]))
                {
                    MessageHandler.ShowMessageBox("采购询价单的请购数量不能超过请购单明细的数量。");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 查询请购单表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="prReqNoStr">请购单号</param>
        public void QueryPrReqHead(DataTable queryDataTable, string prReqNoStr, string reqDateBeginStr, string reqDateEndStr, string projectNoStr)
        {
            string sqlStr = " ReqState in (2)";
            if (prReqNoStr != "")
            {
                sqlStr += string.Format(" and PrReqNo like '%{0}%'", prReqNoStr);
            }
            if (reqDateBeginStr != "")
            {
                sqlStr += string.Format(" and ReqDate between '{0}' and '{1}'", reqDateBeginStr, reqDateEndStr);
            }
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and ProjectNo='{0}'", projectNoStr);
            }
            sqlStr = string.Format("select * from PUR_PrReqHead where {0} order by AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询请购单明细表
        /// </summary>
        /// <param name="queryDataTable">要查询填充的数据表</param>
        /// <param name="prReqNoStr">请购单号</param>
        public void QueryPrReqList(DataTable queryDataTable, string prReqNoStr)
        {
            string sqlStr = "";
            if (prReqNoStr != "")
            {
                sqlStr += string.Format(" and PrReq.PrReqNo='{0}'", prReqNoStr);
            }
            sqlStr = string.Format("select PrReq.*, Parts.CodeName, PUR_PrReqHead.ProjectNo, PUR_PrReqHead.StnNo, case when (select COUNT(*) from PUR_PIPR where PRListId = PrReq.AutoId) > 0 then 1 else 0 end as IsInquiry from PUR_PrReqList as PrReq left join SW_PartsCode as Parts on PrReq.CodeFileName = Parts.CodeFileName left join PUR_PrReqHead on PrReq.PrReqNo = PUR_PrReqHead.PrReqNo where 1=1 {0} order by PrReq.AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询请购明细单事件
        /// </summary>
        public void QueryPrHeadList(DataTable queryDataTable, string reqDateBeginStr, string reqDateEndStr, int codeIdInt, string commonStr)
        {
            string sqlStr = " ReqState in (2)";
            if (reqDateBeginStr != "")
            {
                sqlStr += string.Format(" and ReqDate between '{0}' and '{1}'", reqDateBeginStr, reqDateEndStr);
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and CodeId = {0}", codeIdInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (PrReq.PrReqNo like '%{0}%' or ProjectNo like '%{0}%' or StnNo like '%{0}%' or PrReqRemark like '%{0}%' or PrReqListRemark like '%{0}%')", commonStr);
            }
            sqlStr = string.Format("select PrReq.*, Parts.CodeName, PUR_PrReqHead.ProjectNo, PUR_PrReqHead.StnNo, PUR_PrReqHead.ReqDate, case when (select COUNT(*) from PUR_PIPR where PRListId = PrReq.AutoId) > 0 then 1 else 0 end as IsInquiry from PUR_PrReqList as PrReq left join SW_PartsCode as Parts on PrReq.CodeFileName = Parts.CodeFileName left join PUR_PrReqHead on PrReq.PrReqNo = PUR_PrReqHead.PrReqNo where {0} order by PrReq.AutoId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 得到询价单的AutoId最大号
        /// </summary>
        public int GetInquiryListMaxAutoId()
        {
            string sqlStr = "Select IsNull(Max(AutoId), 0) from PUR_InquiryList";
            return DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
        }

        /// <summary>
        /// 打印处理
        /// </summary>
        /// <param name="orderHeadNoStr">订购单号</param>
        /// <param name="handleTypeInt">打印处理类型：1 预览 2 打印 3 设计</param>
        public void PrintHandle(string orderHeadNoStr, int handleTypeInt)
        {
            DataSet ds = new DataSet();
            DataTable headTable = BaseSQL.GetTableBySql(string.Format("select * from V_Prn_PUR_InquiryHead where PIHeadNo = '{0}' order by AutoId", orderHeadNoStr));
            headTable.TableName = "InquiryHead";
            for (int i = 0; i < headTable.Columns.Count; i++)
            {
                #region 设定主表显示的标题

                switch (headTable.Columns[i].ColumnName)
                {
                    case "PIHeadNo":
                        headTable.Columns[i].Caption = "询价单号";
                        break;
                    case "OrderHeadDate":
                        headTable.Columns[i].Caption = "单据日期";
                        break;
                    case "BussinessBaseNo":
                        headTable.Columns[i].Caption = "往来方编号";
                        break;
                    case "BussinessBaseText":
                        headTable.Columns[i].Caption = "往来方名称";
                        break;
                    case "BussAddress":
                        headTable.Columns[i].Caption = "往来方公司地址";
                        break;
                    case "BussPhoneNo":
                        headTable.Columns[i].Caption = "往来方电话";
                        break;
                    case "BussFaxNo":
                        headTable.Columns[i].Caption = "往来方传真";
                        break;
                    case "BussContact":
                        headTable.Columns[i].Caption = "往来方联系人";
                        break;
                    case "Tax":
                        headTable.Columns[i].Caption = "税率";
                        break;
                    case "DepartmentNo":
                        headTable.Columns[i].Caption = "部门编号";
                        break;
                    case "DepartmentName":
                        headTable.Columns[i].Caption = "部门名称";
                        break;
                    case "ProjectNo":
                        headTable.Columns[i].Caption = "项目号";
                        break;
                    case "ProjectName":
                        headTable.Columns[i].Caption = "项目名称";
                        break;
                    case "StnNo":
                        headTable.Columns[i].Caption = "站号";
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
                    case "PIRemark":
                        headTable.Columns[i].Caption = "备注";
                        break;                    
                }

                #endregion
            }
            ds.Tables.Add(headTable);

            DataTable listTable = BaseSQL.GetTableBySql(string.Format("select *, ROW_NUMBER() over (order by AutoId) as RowNum from V_Prn_PUR_InquiryList where PIHeadNo = '{0}' order by AutoId", orderHeadNoStr));
            listTable.TableName = "InquiryList";
            for (int i = 0; i < listTable.Columns.Count; i++)
            {
                #region 设定子表显示的标题

                switch (listTable.Columns[i].ColumnName)
                {
                    case "RowNum":
                        listTable.Columns[i].Caption = "行号";
                        break;
                    case "PIHeadNo":
                        listTable.Columns[i].Caption = "询价单号";
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
                        listTable.Columns[i].Caption = "数量";
                        break;
                    case "Price":
                        listTable.Columns[i].Caption = "单价";
                        break;
                    case "Amount":
                        listTable.Columns[i].Caption = "金额";
                        break;
                    case "Tax":
                        listTable.Columns[i].Caption = "税率";
                        break;
                    case "TaxAmount":
                        listTable.Columns[i].Caption = "税额";
                        break;
                    case "SumAmount":
                        listTable.Columns[i].Caption = "价税合计";
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
            rptHandler.XtraReport_Handle("PUR_InquiryHead", ds, paralist, handleTypeInt);
        }
    }
}
