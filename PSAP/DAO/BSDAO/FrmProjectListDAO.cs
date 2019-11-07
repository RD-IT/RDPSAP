using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.BSDAO
{
    class FrmProjectListDAO
    {
        ///// <summary>
        ///// 查询用户信息
        ///// </summary>
        //public DataTable QueryUserInfo(bool addAllItem)
        //{
        //    string sqlStr = "select BS_UserInfo.AutoId, EmpName, BS_UserInfo.DepartmentNo, DepartmentName from BS_UserInfo left join BS_Department on BS_UserInfo.DepartmentNo = BS_Department.DepartmentNo";
        //    if (addAllItem)
        //    {
        //        sqlStr = "select 0 as AutoId, '全部' as EmpName, '' as DepartmentNo, '' as DepartmentName union " + sqlStr;
        //    }
        //    return BaseSQL.GetTableBySql(sqlStr);
        //}

        public void QueryUserInfo(DataTable queryDataTable)
        {
            string sqlStr = "select BS_UserInfo.AutoId, EmpName, BS_UserInfo.DepartmentNo, DepartmentName from BS_UserInfo left join BS_Department on BS_UserInfo.DepartmentNo = BS_Department.DepartmentNo order by BS_UserInfo.AutoId";
            BaseSQL.Query(sqlStr, queryDataTable);
        }
        
    }
}
