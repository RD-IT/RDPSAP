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
        public void QueryWarehouseNowInfo(DataTable queryDataTable, int codeIdInt, int repertoryIdInt, string projectNameStr, bool isIncludeZeroBool)
        {
            string sqlStr = " Qty!=0";
            if (isIncludeZeroBool)
            {
                sqlStr = " 1=1";
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and CodeId={0}", codeIdInt);
            }
            if (repertoryIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryId={0}", repertoryIdInt);
            }
            if (projectNameStr != "")
            {
                sqlStr += string.Format(" and ProjectName='{0}'", projectNameStr);
            }
            sqlStr = string.Format("select AutoId, CodeId, CodeFileName, CodeName, ProjectNo, ProjectName, RepertoryId, LocationId, ShelfId, Qty from V_INV_WarehouseNowInfo where {0} order by RepertoryId, LocationId, ProjectNo, CodeId, CodeFileName, ShelfId", sqlStr);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 当前库存查询的SQL
        /// </summary>
        public string QueryWarehouseNowInfo_SQL(int codeIdInt, int repertoryIdInt, int locationIdInt, string projectNameStr, int ShelfIdInt, string commonStr, bool isIncludeZeroBool)
        {
            string sqlStr = " Qty!=0";
            if (isIncludeZeroBool)
            {
                sqlStr = " 1=1";
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and CodeId={0}", codeIdInt);
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
            sqlStr = string.Format("select * from V_INV_WarehouseNowInfo where {0} order by RepertoryId, LocationId, CodeId, CodeFileName, ProjectName, ShelfId", sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 查询产品收发帐的SQL
        /// </summary>
        public string QueryProductOpenAccount_SQL(string beginDateStr, string endDateStr, int repertoryIdInt, int locationIdInt, string projectNoStr, int shelfIdInt, int codeIdInt)
        {
            string sqlStr = "";
            if (repertoryIdInt != 0)
            {
                sqlStr += string.Format(" and RepertoryId={0}", repertoryIdInt);
            }
            if (locationIdInt != 0)
            {
                sqlStr += string.Format(" and LocationId={0}", locationIdInt);
            }
            if (projectNoStr != "")
            {
                sqlStr += string.Format(" and ProjectNo='{0}'", projectNoStr);
            }
            if (shelfIdInt != 0)
            {
                sqlStr += string.Format(" and ShelfId={0}", shelfIdInt);
            }
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and CodeId={0}", codeIdInt);
            }

            sqlStr = string.Format("select *, CurQty - Qty as BeginingQty from F_ProductOpenAccount('{0}', '{1}') where StockId > 0 {2} order by StockId", beginDateStr, endDateStr, sqlStr);
            return sqlStr;
        }

        /// <summary>
        /// 查询期间库存统计的SQL
        /// </summary>
        public string QueryStockDurationTotal_SQL(DateTime beginDate, string beginDateStr, string endDateStr, int repertoryIdInt, int locationIdInt, string projectNameStr, int codeIdInt, string commonStr)
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
            if (codeIdInt != 0)
            {
                sqlStr += string.Format(" and CodeId={0}", codeIdInt);
            }
            if (commonStr != "")
            {
                sqlStr += string.Format(" and (CodeName like '%{0}%' or CodeSpec like '%{0}%' or Brand like '%{0}%' or CatgName like '%{0}%')", commonStr);
            }
            string yearStr = beginDate.Year.ToString();
            string beginingBeginDateStr = DateTime.Parse(beginDate.ToString("yyyy-01-01")).ToString("yyyy-MM-dd");
            string beginingEndDateStr = beginDate.ToString("yyyy-MM-dd");
            sqlStr = string.Format("select * from F_QueryStockDurationTotal_Column({1}, '{2}', '{3}', '{4}', '{5}') where {0} order by RepertoryId, LocationId, CodeId, CodeFileName, ProjectNo", sqlStr, yearStr, beginingBeginDateStr, beginingEndDateStr, beginDateStr, endDateStr);
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
        
    }
}
