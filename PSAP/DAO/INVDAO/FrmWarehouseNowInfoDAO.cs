﻿using PSAP.DAO.BSDAO;
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
            if(isIncludeZeroBool)
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
    }
}
