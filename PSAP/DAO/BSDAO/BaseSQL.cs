﻿using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PSAP.PSAPCommon;

namespace PSAP.DAO.BSDAO
{
    /// <summary>
    /// 数据访问基础类(基于SQLServer)
    /// </summary>
    public abstract class BaseSQL
    {
        //数据库连接字符串(app.config来配置)
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PSAP.Properties.Settings.PSAPConnectionString"].ConnectionString;

        public BaseSQL()
        {

        }

        /// <summary>
        /// 得到数据库连接字符串
        /// </summary>
        public static string GetConnectionString(string dataSourceStr, string dbNameStr, string userIDStr, string passwordStr)
        {
            return string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", dataSourceStr, dbNameStr, userIDStr, passwordStr);
        }

        #region 公用方法

        /// <summary>
        /// 测试是否成功
        /// </summary>
        public static bool TestSqlConnection()
        {
            return TestSqlConnection(BaseSQL.connectionString);
        }
        public static bool TestSqlConnection(string connStr)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获得最大ID
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        /// <summary>
        /// 获得最大ID(类别字段中的某一类)
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <param name="categoryFieldName"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public static int GetMaxID(string FieldName, string TableName, string categoryFieldName, int category)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName + " where " + categoryFieldName + "=" + category + " ";
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }


        public static string GetMaxCodeNo(string catgName)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        string codeNoStr = GetMaxCodeNo(cmd, catgName);
                        trans.Commit();
                        return codeNoStr;
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
        /// 从SW_MaxCodeNo表中根据类别取最大编号
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="catgName"></param>
        /// <returns></returns>
        public static string GetMaxCodeNo(SqlCommand cmd, string catgName)
        {
            cmd.CommandText = string.Format("select * from SW_MaxCodeNo where CatgName='{0}'", catgName);
            DataTable maxCodeNoTable = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(maxCodeNoTable);
            int maxCodeNoInt = 1;
            string maxCodeNoStr = "";
            if (maxCodeNoTable.Rows.Count > 0)
            {
                maxCodeNoInt = DataTypeConvert.GetInt(maxCodeNoTable.Rows[0]["MaxCodeNo"]);
                int autoId = DataTypeConvert.GetInt(maxCodeNoTable.Rows[0]["AutoId"]);
                maxCodeNoInt++;
                maxCodeNoStr = catgName + maxCodeNoInt.ToString().PadLeft(11, '0');
                cmd.CommandText = string.Format("Update SW_MaxCodeNo set MaxCodeNo='{1}', MaxCode='{2}' where AutoId={0}", autoId, maxCodeNoInt, maxCodeNoStr);
                cmd.ExecuteNonQuery();
            }
            else
            {
                maxCodeNoStr = catgName + maxCodeNoInt.ToString().PadLeft(11, '0');
                cmd.CommandText = string.Format("Insert into SW_MaxCodeNo(MaxCodeNo, MaxCode, CatgName) values ('{0}', '{1}', '{2}')", maxCodeNoInt, maxCodeNoStr, catgName);
                cmd.ExecuteNonQuery();
            }

            return maxCodeNoStr;
        }

        //判断用Sql查询的数据是否存在,true表示存在，False表示不存在
        public static bool Exists(string strSql)
        {
            object obj = BaseSQL.GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        public static int ExecuteSql(SqlCommand cmd, string SQLString)
        {
            cmd.CommandText = SQLString;
            return cmd.ExecuteNonQuery();
        }

        public static DataTable GetTableBySql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    try
                    {
                        adpt.Fill(dt);

                    }
                    catch (Exception e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                    cmd.Connection.Close();
                    return dt;
                }
            }
        }

        public static DataTable GetTableBySql(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>  
        //static  object nn;
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            //nn = n;
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        public static object GetSingle(SqlCommand cmd, string SQLString)
        {
            cmd.CommandText = SQLString;
            object obj = cmd.ExecuteScalar();
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return null;
            }
            else
            {
                return obj;
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static void Query(string SQLString, DataTable QueryTable)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(QueryTable);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        ///         /// 执行查询语句，返回多表DataSet
        /// </summary>
        /// <param name="SQLStringList"></param>
        /// <param name="TablesName"></param>
        /// <returns></returns>
        public static DataSet GetDataSetBySql(ArrayList SQLStringList, ArrayList TablesName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    //SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    SqlDataAdapter command;
                    string strsql;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            command = new SqlDataAdapter(strsql, connection);
                            command.Fill(ds, TablesName[n].ToString());
                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 得到服务器数据库的当前时间
        /// </summary>
        public static DateTime GetServerDateTime()
        {
            return Convert.ToDateTime(GetSingle("select getdate()"));
        }

        /// <summary>
        /// 得到查询单列日期区域的条件SQL
        /// </summary>
        public static string GetDateRegion_SingleColumn_WhereSql(string columnStr, string beginDateStr, string endDateStr)
        {
            return string.Format(" and {0} >= '{1}' and {0} < '{2}'", columnStr, beginDateStr, endDateStr);
        }

        /// <summary>
        /// 得到查询双列日期区域的条件SQL
        /// </summary>
        public static string GetDateRegion_DoubleColumn_WhereSql(string oneColumnStr, string twoColumnStr, string beginDateStr, string endDateStr)
        {
            return string.Format(" and (({0} >= '{2}' and {0} < '{3}') or ({1} >= '{2}' and {1} < '{3}'))", oneColumnStr, twoColumnStr, beginDateStr, endDateStr);
        }

        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="databaseNameStr">数据库名称</param>
        /// <param name="saveFileStr">保存数据库的文件路径名</param>
        public static bool BackupDataBase(string databaseNameStr, string filePathNameStr)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("", conn);
                    cmd.CommandText = string.Format("BACKUP DATABASE {0} TO DISK = '{1}'", databaseNameStr, filePathNameStr);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// 使用DataAdapter方式，把DataTable的数据更新到数据库中
        /// </summary>
        public static void UpdateDataTable(SqlDataAdapter dataAdapter, DataTable dataTable)
        {
            if (dataTable == null)
                return;

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            commandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
            dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand(true);
            dataAdapter.InsertCommand = commandBuilder.GetInsertCommand(true);
            dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
            dataAdapter.Update(dataTable);
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader returnReader;
            connection.Open();
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            return returnReader;
        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数  
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 执行存储过程，返回执行是否成功，返回值为1则成功，其他值为失败
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="resultInt">执行存储过程的返回值</param>
        /// <param name="errorText">错误描述</param>
        /// <returns></returns>
        public static bool RunProcedure(SqlCommand cmd, string storedProcName, IDataParameter[] parameters, out int resultInt, out string errorText)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcName;
            cmd.Parameters.Add("@ReturnValue", SqlDbType.Int, 4).Direction = ParameterDirection.ReturnValue;
            foreach (SqlParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            cmd.Parameters.Add("@ErrorText", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            errorText = DataTypeConvert.GetString(cmd.Parameters["@ErrorText"].Value);
            resultInt = DataTypeConvert.GetInt(cmd.Parameters["@ReturnValue"].Value);
            return resultInt == 1;
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值) 
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
             SqlDbType.Int, 4, ParameterDirection.ReturnValue,
             false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion
        
    }    
}
