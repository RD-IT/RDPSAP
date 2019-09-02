using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.INVDAO
{
    class FrmWarehouseNowInfoDAO
    {
        /// <summary>
        /// 查询当前库存表
        /// </summary>
        public void QueryWarehouseNowInfo(DataTable queryDataTable, string codeFileNameStr, int repertoryIdInt, string projectNameStr, bool isIncludeZeroBool)
        {
            string sqlStr = " Qty!=0";
            if (isIncludeZeroBool)
            {
                sqlStr = " 1=1";
            }
            if (codeFileNameStr != "")
            {
                sqlStr += string.Format(" and CodeFileName='{0}'", codeFileNameStr);
            }
            if (repertoryIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryId={0}", repertoryIdInt);
            }
            if (projectNameStr != "")
            {
                sqlStr += string.Format(" and ProjectName='{0}'", projectNameStr);
            }
            sqlStr = string.Format("select AutoId, CodeFileName, CodeName, ProjectNo, ProjectName, RepertoryId, LocationId, ShelfId, Qty from V_INV_WarehouseNowInfo where {0} order by RepertoryId, LocationId, ProjectNo, CodeFileName, ShelfId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 当前库存查询的SQL
        /// </summary>
        public string QueryWarehouseNowInfo_SQL(string codeFileNameStr, int repertoryIdInt, int locationIdInt, string projectNameStr, int ShelfIdInt, string commonStr, bool isIncludeZeroBool)
        {
            string sqlStr = " Qty!=0";
            if (isIncludeZeroBool)
            {
                sqlStr = " 1=1";
            }
            if (codeFileNameStr != "")
            {
                sqlStr += string.Format(" and CodeFileName='{0}'", codeFileNameStr);
            }
            if (repertoryIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryId={0}", repertoryIdInt);
            }
            if (locationIdInt != 0)
            {
                sqlStr += string.Format(" and LocationId={0}", locationIdInt);
            }
            if (projectNameStr != "")
            {
                sqlStr += string.Format(" and ProjectName='{0}'", projectNameStr);
            }
            if (ShelfIdInt != 0)
            {
                sqlStr += string.Format(" and ShelfId={0}", ShelfIdInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (CodeName like '%{0}%' or CodeSpec like '%{0}%' or Brand like '%{0}%' or CatgName like '%{0}%')", commonStr);
            }
            sqlStr = string.Format("select * from V_INV_WarehouseNowInfo where {0} order by RepertoryId, LocationId, CodeFileName, ProjectName, ShelfId", sqlStr);
            return sqlStr;
        }

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
            IDataParameter[] parameters = new System.Data.IDataParameter[] { p1, p2 };
            return BaseSQL.RunProcedure(cmd, "P_Update_WarehouseNowInfo", parameters, out resultInt, out errorText);
        }

        /// <summary>
        /// 查询期间库存统计的SQL
        /// </summary>
        public string QueryStockDurationTotal_SQL(DateTime beginDate, string beginDateStr, string endDateStr, int repertoryIdInt, int locationIdInt, string projectNameStr, string codeFileNameStr, string commonStr)
        {
            string sqlStr = " 1=1";
            if (repertoryIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryId={0}", repertoryIdInt);
            }
            if (locationIdInt != 0)
            {
                sqlStr += string.Format(" and LocationId={0}", locationIdInt);
            }
            if (projectNameStr != "")
            {
                sqlStr += string.Format(" and ProjectName='{0}'", projectNameStr);
            }
            if (codeFileNameStr != "")
            {
                sqlStr += string.Format(" and CodeFileName='{0}'", codeFileNameStr);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (CodeName like '%{0}%' or CodeSpec like '%{0}%' or Brand like '%{0}%' or CatgName like '%{0}%')", commonStr);
            }
            string yearStr = beginDate.Year.ToString();
            string beginingBeginDateStr = DateTime.Parse(beginDate.ToString("yyyy-01-01")).ToString("yyyy-MM-dd");
            string beginingEndDateStr = beginDate.ToString("yyyy-MM-dd");
            sqlStr = string.Format("select * from F_QueryStockDurationTotal_Column({1}, '{2}', '{3}', '{4}', '{5}') where {0} order by RepertoryId, LocationId, CodeFileName, ProjectNo", sqlStr, yearStr, beginingBeginDateStr, beginingEndDateStr, beginDateStr, endDateStr);
            //BaseSQL.Query(sqlStr, queryDataTable);
            return sqlStr;
        }

        /// <summary>
        /// 查询Bom零件的库存数量
        /// </summary>
        public DataTable QueryBomWarehouseNowInfo(string codeFileNameStr, int repertoryIdInt, int locationIdInt)
        {
            string repNoSQLStr = "";
            if (repertoryIdInt != 0)
            {
                repNoSQLStr += string.Format(" and RepertoryId = {0}", repertoryIdInt);
            }
            if (locationIdInt != 0)
            {
                repNoSQLStr += string.Format(" and LocationId = {0}", locationIdInt);
            }
            string sqlStr = string.Format("select bom.*, SW_PartsCode.CodeName, SW_PartsCode.AutoId as PCAutoId, SW_PartsCode.FilePath, SW_PartsCode.Brand, SW_PartsCode.CatgName, SW_PartsCode.CodeSpec, SW_PartsCode.Unit, BS_BomMaterieState.MaterieStateText, (select IsNull(SUM(Qty), 0) from INV_WarehouseNowInfo where INV_WarehouseNowInfo.CodeFileName = bom.CodeFileName {1} ) as WarehouseQty from F_BomMateriel_TreeRelation('{0}') as bom left join SW_PartsCode on bom.CodeFileName = SW_PartsCode.CodeFileName left join BS_BomManagement on bom.CodeFileName = BS_BomManagement.MaterielNo left join BS_BomMaterieState on BS_BomMaterieState.MaterieStateId = BS_BomManagement.MaterieStateId Order by CodeFileName", codeFileNameStr, repNoSQLStr);
            return BaseSQL.Query(sqlStr).Tables[0];
        }

        /// <summary>
        /// 保存登记单及时更新当前库存
        /// </summary>
        /// <param name="conn">SqlConnection</param>
        /// <param name="tran">SqlTransaction</param>
        /// <param name="cmd">SqlCommand</param>
        /// <param name="headRow">主表行</param>
        /// <param name="updateListTable">更新的明细列表</param>
        /// <param name="orderNoStr">登记单号</param>
        /// <param name="dbListTable">更新之前数据库的记录</param>
        /// <param name="tableCaption">表标题</param>
        /// <param name="memoText">备注</param>
        /// <param name="inoutStockSign">出入库标志，true入库 false出库</param>
        /// <returns></returns>
        public int SaveUpdate_WarehouseNowInfo(SqlConnection conn, SqlTransaction tran, SqlCommand cmd, DataRow headRow, DataTable updateListTable, string orderNoStr, DataTable dbListTable, string tableCaption, string memoText, bool inoutStockSign)
        {
            if (updateListTable == null)
                return 1;
            updateListTable.AcceptChanges();
            if (headRow.RowState == DataRowState.Added)
            {
                string errorText = "";
                SqlCommand cmd_proc = new SqlCommand("", conn, tran);
                if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, orderNoStr, 1, out errorText))
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
                                MessageHandler.ShowMessageBox(string.Format("{1}{0}错误--{1}[{2}]中的[{3}]库存数不足，差[{4}]个。", memoText, tableCaption, orderNoStr, dbCodeFileName, -nowQty));
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
                            MessageHandler.ShowMessageBox(string.Format("{1}{0}错误--{1}[{2}]中的[{3}]库存数不足，差[{4}]个。", memoText, tableCaption, orderNoStr, updateCodeFileName, -nowQty));
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
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <param name="cmd"></param>
        /// <param name="headRow"></param>
        /// <param name="updateInListTable"></param>
        /// <param name="orderNoStr"></param>
        /// <param name="dbListTable"></param>
        /// <param name="tableCaption"></param>
        /// <param name="memoText"></param>
        /// <returns></returns>
        public int SaveMoveUpdate_WarehouseNowInfo(SqlConnection conn, SqlTransaction tran, SqlCommand cmd, DataRow headRow, DataTable updateInListTable, string orderNoStr, DataTable dbInListTable, DataTable dbOutListTable)
        {
            if (updateInListTable == null)
                return 1;
            updateInListTable.AcceptChanges();
            
            if (headRow.RowState == DataRowState.Added)
            {
                string errorText = "";
                SqlCommand cmd_proc = new SqlCommand("", conn, tran);
                if (!new FrmWarehouseNowInfoDAO().Update_WarehouseNowInfo(cmd_proc, orderNoStr, 1, out errorText))
                {
                    tran.Rollback();
                    MessageHandler.ShowMessageBox(string.Format("库存移动单出入库错误--{0}", errorText));
                    return 0;
                }
                return 1;
            }
            else
            {
                DataTable updateOutListTable = updateInListTable.Copy();

                foreach (DataRow dbInRow in dbInListTable.Rows)
                {
                    string dbCodeFileName = DataTypeConvert.GetString(dbInRow["CodeFileName"]);
                    int dbInRepertoryId = DataTypeConvert.GetInt(dbInRow["InRepertoryId"]);
                    int dbInLocationId = DataTypeConvert.GetInt(dbInRow["InLocationId"]);
                    string dbInProjectNo = DataTypeConvert.GetString(dbInRow["InProjectNo"]);
                    int dbInShelfId = DataTypeConvert.GetInt(dbInRow["InShelfId"]);

                    //int dbOutLocationId = DataTypeConvert.GetInt(dbRow["OutLocationId"]);
                    //int dbOutRepertoryId = DataTypeConvert.GetInt(dbRow["OutRepertoryId"]);
                    //string dbOutProjectNo = DataTypeConvert.GetString(dbRow["OutProjectNo"]);
                    //int dbOutShelfId = DataTypeConvert.GetInt(dbRow["OutShelfId"]);
                    double dbQty = DataTypeConvert.GetDouble(dbInRow["Qty"]);
                    double iaSumQty = DataTypeConvert.GetDouble(updateInListTable.Compute("Sum(Qty)", string.Format("CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", dbCodeFileName, dbInRepertoryId, dbInLocationId, dbInProjectNo, dbInShelfId)));

                    if (dbQty == iaSumQty)
                    {

                    }
                    else
                    {
                        double modifiedQty = iaSumQty - dbQty;

                        UpdateWarehouseNowInfo(cmd, dbCodeFileName, dbInRepertoryId, dbInLocationId, dbInProjectNo, dbInShelfId, modifiedQty);

                        if (!SystemInfo.EnableNegativeInventory)
                        {
                            cmd.CommandText = string.Format("Select Qty from INV_WarehouseNowInfo where CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", dbCodeFileName, dbInRepertoryId, dbInLocationId, dbInProjectNo, dbInShelfId);

                            double nowQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
                            if (nowQty < 0)
                            {
                                tran.Rollback();
                                MessageHandler.ShowMessageBox(string.Format("库存调整单入库错误--库存调整单[{0}]中的[{1}]库存数不足，差[{2}]个。", orderNoStr, dbCodeFileName, -nowQty));
                                return 0;
                            }
                        }
                    }

                    DataRow[] drs = updateInListTable.Select(string.Format("CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", dbCodeFileName, dbInRepertoryId, dbInLocationId, dbInProjectNo, dbInShelfId));

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
                    double updateQty = DataTypeConvert.GetDouble(updateInRow["Qty"]);

                    UpdateWarehouseNowInfo(cmd, updateCodeFileName, updateInRepertoryId, updateInLocationId, updateInProjectNo, updateInShelfId, updateQty);

                    if (!SystemInfo.EnableNegativeInventory)
                    {
                        cmd.CommandText = string.Format("Select Qty from INV_WarehouseNowInfo where CodeFileName='{0}' and RepertoryId={1} and LocationId={2} and ProjectNo='{3}' and ShelfId={4}", updateCodeFileName, updateInRepertoryId, updateInLocationId, updateInProjectNo, updateInShelfId);

                        double nowQty = DataTypeConvert.GetDouble(cmd.ExecuteScalar());
                        if (nowQty < 0)
                        {
                            tran.Rollback();
                            MessageHandler.ShowMessageBox(string.Format("库存调整单入库错误--库存调整单[{0}]中的[{1}]库存数不足，差[{2}]个。", orderNoStr, updateCodeFileName, -nowQty));
                            return 0;
                        }
                    }
                }

                return 1;
            }
        }

        /// <summary>
        /// 更新当前库存数
        /// </summary>
        public void UpdateWarehouseNowInfo(SqlCommand cmd, string codeFileNameStr, int repertoryIdInt, int locationIdInt, string projectNoStr, int shelfIdInt, double qtyDouble)
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
    }
}
