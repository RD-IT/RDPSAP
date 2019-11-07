using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.WORKFLOWDAO
{
    class FrmWorkFlowsNodeLineSetDAO
    {
        ///// <summary>
        ///// 根据流程图类型查询流程图信息
        ///// </summary>
        //public DataTable QueryWorkFlows(int workFlowsTypeInt)
        //{
        //    string sqlStr = string.Format("Select * from BS_WorkFlows where WorkFlowsType = {0} and Enabled = 1", workFlowsTypeInt);
        //    return BaseSQL.GetTableBySql(sqlStr);
        //}

        /// <summary>
        /// 查询单个流程图节点信息
        /// </summary>
        /// <param name="nodeIdInt">状态节点Id</param>
        public DataTable QueryWorkFlowsNode(int nodeIdInt)
        {
            string sqlStr = string.Format("Select * from BS_WorkFlowsNode where AutoId = {0}", nodeIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 根据节点编号查询上级连接线的类型
        /// </summary>
        /// <param name="nodeIdInt">状态节点Id</param>
        public DataTable QueryLineType_LevelNodeId(int nodeIdInt)
        {
            string sqlStr = string.Format("Select LineType from BS_WorkFlowsLine where LevelNodeId = {0} group by LineType", nodeIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 根据节点编号查询下级连接线的类型
        /// </summary>
        /// <param name="nodeIdInt">状态节点Id</param>
        public DataTable QueryLineType_NodeId(int nodeIdInt)
        {
            string sqlStr = string.Format("Select LineType from BS_WorkFlowsLine where NodeId = {0} group by LineType", nodeIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询流程图节点信息
        /// </summary>
        public DataTable QueryWorkFlowsNode()
        {
            string sqlStr = string.Format("Select AutoId, NodeText from BS_WorkFlowsNode");
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询流程图类型字段信息
        /// </summary>
        /// <param name="workFlowsIdInt">流程图Id</param>
        public DataTable QueryWorkFlowsTypeField(int workFlowsIdInt)
        {
            string sqlStr = string.Format("select BS_WorkFlowsTypeField.*, V_DataTypeView.DataTypeName, V_DataTypeView.DataTypeNo from BS_WorkFlowsTypeField left join V_DataTypeView on BS_WorkFlowsTypeField.FieldType = V_DataTypeView.AutoId where WorkFlowsId = {0}", workFlowsIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询连接线条件信息列表
        /// </summary>
        /// <param name="queryDataTable">填充的数据表</param>
        /// <param name="lineIdInt">连接线Id</param>
        public void QueryWorkFlowsLineConditionList(DataTable queryDataTable, int lineIdInt)
        {
            string sqlStr = string.Format("select * from BS_WorkFlowsLineConditionList where ConditionId in (select AutoId from BS_WorkFlowsLineCondition where LineId = {0}) order by AutoId", lineIdInt);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 更新流程图节点信息
        /// </summary>
        /// <param name="nodeIdInt">状态节点Id</param>
        /// <param name="nodeTextStr">状态节点名称</param>
        /// <param name="enabledInt">启用标志 1：启用 0：停用</param>
        /// <param name="beginNodeInt">开始结束节点标志 0：中间 1：开始节点 2：结束节点</param>
        public bool SaveWorkFlowsNode(int nodeIdInt, string nodeTextStr, int enabledInt, int beginNodeInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        if (beginNodeInt == (int)WorkFlowsHandleDAO.NodePositionType.开始节点)
                        {
                            cmd.CommandText = string.Format("Update BS_WorkFlowsNode set BeginNode = 0 where WorkFlowsId in (select WorkFlowsId from BS_WorkFlowsNode where AutoId = {0}) and BeginNode = 1", nodeIdInt);
                            cmd.ExecuteNonQuery();
                        }
                        else if (beginNodeInt == (int)WorkFlowsHandleDAO.NodePositionType.结束节点)
                        {
                            cmd.CommandText = string.Format("Update BS_WorkFlowsNode set BeginNode = 0 where WorkFlowsId in (select WorkFlowsId from BS_WorkFlowsNode where AutoId = {0}) and BeginNode = 2", nodeIdInt);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsNode where WorkFlowsId in (select WorkFlowsId from BS_WorkFlowsNode where AutoId = {0}) and AutoId != {0} and IsNull(BeginNode, 0) = 1", nodeIdInt);
                            if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) == 0)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("流程图必须拥有一个开始节点，请重新操作。");
                                return false;
                            }

                            cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsNode where WorkFlowsId in (select WorkFlowsId from BS_WorkFlowsNode where AutoId = {0}) and AutoId != {0} and IsNull(BeginNode, 0) = 2", nodeIdInt);
                            if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) == 0)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox("流程图必须拥有一个结束节点，请重新操作。");
                                return false;
                            }
                        }

                        cmd.CommandText = string.Format("Update BS_WorkFlowsNode set NodeText = '{1}', Enabled = {2}, BeginNode = {3} where AutoId = {0}", nodeIdInt, nodeTextStr, enabledInt, beginNodeInt);
                        cmd.ExecuteNonQuery();

                        if(beginNodeInt == (int)WorkFlowsHandleDAO.NodePositionType.结束节点)
                        {
                            if (enabledInt == 1)
                            {
                                cmd.CommandText = string.Format("update BS_WorkFlowsDataCurrentNode set IsEnd = 0 from BS_WorkFlowsDataCurrentNode as curNode left join BS_WorkFlowsLine as line on curNode.CurrentNodeId = line.NodeId left join BS_WorkFlowsNode as lvlNode on line.LevelNodeId = lvlNode.AutoId where IsNull(curNode.IsEnd, 0) = 1 and lvlNode.BeginNode = 2 and lvlNode.AutoId = {0}", nodeIdInt);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                cmd.CommandText = string.Format("update BS_WorkFlowsDataCurrentNode set IsEnd = 1 from BS_WorkFlowsDataCurrentNode as curNode left join BS_WorkFlowsLine as line on curNode.CurrentNodeId = line.NodeId left join BS_WorkFlowsNode as lvlNode on line.LevelNodeId = lvlNode.AutoId where IsNull(curNode.IsEnd, 0) = 0 and lvlNode.BeginNode = 2 and lvlNode.AutoId = {0}", nodeIdInt);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        string logStr = string.Format("修改流程图节点信息：[AutoId]的值为[{0}]，[节点名称]的值改为[{1}]，[启用标志]的值改为[{2}]，[开始节点标志]的值改为[{3}]", nodeIdInt, nodeTextStr, enabledInt, beginNodeInt);
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
        /// 查询单个流程图连接线信息
        /// </summary>
        /// <param name="lineIdInt">连接线Id</param>
        public DataTable QueryWorkFlowsLine(int lineIdInt)
        {
            string sqlStr = string.Format("Select * from BS_WorkFlowsLine where AutoId = {0}", lineIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 更新流程图连接线信息
        /// </summary>
        /// <param name="lineIdInt">连接线Id</param>
        /// <param name="lineTextStr">连接线名称</param>
        /// <param name="enabledInt">启用条件标志 1启用 0停用</param>
        /// <param name="lineTypeInt">连接线类型</param>
        /// <param name="lineConditionTable">连接线条件列表</param>
        /// <param name="lineHandleTable">连接线处理人员列表</param>
        /// <param name="lineNoticeTable">连接线通知人员列表</param>
        /// <param name="conditionListTable">条件具体明细列表</param>
        public bool SaveWorkFlowsLineSet(int lineIdInt, string lineTextStr, int enabledInt, int lineTypeInt, DataTable lineConditionTable, DataTable lineHandleTable, DataTable lineNoticeTable, DataTable conditionListTable)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (lineIdInt > 0)
                        {
                            cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsLine where WorkFlowsId in (select WorkFlowsId from BS_WorkFlowsLine where AutoId = {0}) and LineType = {1} and AutoId != {0}", lineIdInt, lineTypeInt);
                            if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                            {
                                trans.Rollback();
                                MessageHandler.ShowMessageBox(string.Format("流程图连接线的类型【{0}】有重复，不可以保存。", (WorkFlowsHandleDAO.LineType)lineTypeInt));
                                return false;
                            }

                            cmd.CommandText = string.Format("Update BS_WorkFlowsLine set LineText = '{1}', Enabled = {2}, LineType = {3} where AutoId = {0}", lineIdInt, lineTextStr, enabledInt, lineTypeInt);
                            cmd.ExecuteNonQuery();

                            string logStr = string.Format("修改流程图连接线信息：[AutoId]的值为[{0}]，[连接线名称]的值改为[{1}]，[启用标志]的值改为[{2}]，[连接线类型]的值改为[{3}]", lineIdInt, lineTextStr, enabledInt, lineTypeInt);
                            LogHandler.RecordLog(cmd, logStr);
                        }

                        for (int i = 0; i < lineConditionTable.Rows.Count; i++)
                        {
                            DataRow tmpRow = lineConditionTable.Rows[i];
                            switch (tmpRow.RowState)
                            {
                                case DataRowState.Added:
                                    string lineIdStr = DataTypeConvert.GetInt(tmpRow["LineId"]) <= 0 ? "null" : DataTypeConvert.GetString(tmpRow["LineId"]);

                                    int autoId = InsertWorkFlowsLineCondition(cmd, lineIdStr, DataTypeConvert.GetString(tmpRow["ConditionText"]), DataTypeConvert.GetString(tmpRow["Condition"]), DataTypeConvert.GetInt(tmpRow["WorkFlowsId"]));

                                    DataRow[] handleRows = lineHandleTable.Select(string.Format("ConditionId={0}", lineConditionTable.Rows[i]["AutoId"]));
                                    foreach (DataRow dr in handleRows)
                                    {
                                        dr["ConditionId"] = autoId;
                                    }
                                    DataRow[] noticeRows = lineNoticeTable.Select(string.Format("ConditionId={0}", lineConditionTable.Rows[i]["AutoId"]));
                                    foreach (DataRow dr in noticeRows)
                                    {
                                        dr["ConditionId"] = autoId;
                                    }
                                    DataRow[] listRows = conditionListTable.Select(string.Format("ConditionId={0}", lineConditionTable.Rows[i]["AutoId"]));
                                    foreach (DataRow dr in listRows)
                                    {
                                        dr["ConditionId"] = autoId;
                                    }
                                    break;
                                case DataRowState.Modified:
                                    cmd.CommandText = string.Format("UPDATE BS_WorkFlowsLineCondition SET ConditionText = '{1}', Condition = '{2}' where AutoId = {0}", DataTypeConvert.GetInt(tmpRow["AutoId"]), DataTypeConvert.GetString(tmpRow["ConditionText"]), DataTypeConvert.GetString(tmpRow["Condition"]));
                                    cmd.ExecuteNonQuery();
                                    break;
                            }
                        }
                        
                        cmd.CommandText = "select * from BS_WorkFlowsLineHandle where 1=2";
                        SqlDataAdapter adapterHandle = new SqlDataAdapter(cmd);
                        DataTable tmpHandleTable = new DataTable();
                        adapterHandle.Fill(tmpHandleTable);
                        BaseSQL.UpdateDataTable(adapterHandle, lineHandleTable.GetChanges());

                        cmd.CommandText = "select * from BS_WorkFlowsLineNotice where 1=2";
                        SqlDataAdapter adapterNotice = new SqlDataAdapter(cmd);
                        DataTable tmpNoticeTable = new DataTable();
                        adapterNotice.Fill(tmpNoticeTable);
                        BaseSQL.UpdateDataTable(adapterNotice, lineNoticeTable.GetChanges());

                        cmd.CommandText = "select * from BS_WorkFlowsLineConditionList where 1=2";
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable tmpListTable = new DataTable();
                        adapterList.Fill(tmpListTable);
                        BaseSQL.UpdateDataTable(adapterList, conditionListTable.GetChanges());

                        for (int i = 0; i < lineConditionTable.Rows.Count; i++)
                        {
                            DataRow tmpRow = lineConditionTable.Rows[i];
                            switch (tmpRow.RowState)
                            {
                                case DataRowState.Deleted:
                                    cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineConditionList where ConditionId = {0}", DataTypeConvert.GetInt(tmpRow["AutoId", DataRowVersion.Original]));
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineCondition where AutoId = {0}", DataTypeConvert.GetInt(tmpRow["AutoId", DataRowVersion.Original]));
                                    cmd.ExecuteNonQuery();

                                    string logStr = string.Format("删除连接线设定条件：[AutoId]的值[{0}]，[条件名称]的值[{1}]，[条件SQL]的值[{2}]", DataTypeConvert.GetInt(tmpRow["AutoId", DataRowVersion.Original]), DataTypeConvert.GetString(tmpRow["ConditionText", DataRowVersion.Original]), DataTypeConvert.GetString(tmpRow["Condition", DataRowVersion.Original]));
                                    LogHandler.RecordLog(cmd, logStr);
                                    break;
                            }
                        }
                        LogHandler.RecordLog_DataTable(cmd, "连接线处理人员", lineHandleTable, "AutoId");
                        LogHandler.RecordLog_DataTable(cmd, "连接线通知人员", lineNoticeTable, "AutoId");

                        trans.Commit();

                        lineConditionTable.AcceptChanges();
                        lineHandleTable.AcceptChanges();
                        lineNoticeTable.AcceptChanges();
                        conditionListTable.AcceptChanges();

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
        /// 新增连接线的设定条件
        /// </summary>
        /// <param name="lineIdStr">连接线ID</param>
        /// <param name="conditionTextStr">设定条件名称</param>
        /// <param name="conditionStr">设定条件SQL</param>
        /// <param name="workFlowsIdInt">流程图ID</param>
        private int InsertWorkFlowsLineCondition(SqlCommand cmd, string lineIdStr, string conditionTextStr, string conditionStr, int workFlowsIdInt)
        {
            cmd.CommandText = string.Format("Insert into BS_WorkFlowsLineCondition (LineId, ConditionText, Condition, Creator, GetTime, WorkFlowsId) values ({0}, '{1}', '{2}', {3}, getdate(), {4})", lineIdStr, conditionTextStr, conditionStr, SystemInfo.user.AutoId, workFlowsIdInt);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select @@IDENTITY";
            int autoIdInt = DataTypeConvert.GetInt(cmd.ExecuteScalar());

            string logStr = string.Format("新增连接线设定条件：[连接线ID]的值[{0}]，[条件名称]的值[{1}]，[条件SQL]的值[{2}]，[流程图ID]的值[{3}]", lineIdStr, conditionTextStr, conditionStr, workFlowsIdInt);
            LogHandler.RecordLog(cmd, logStr);

            return autoIdInt;
        }

        /// <summary>
        /// 查询连接线的设定条件
        /// </summary>
        /// <param name="queryDataTable">填充的数据表</param>
        /// <param name="lineIdInt">连接线Id</param>
        /// <param name="workFlowsIdInt">流程图Id</param>
        public void QueryWorkFlowsLineCondition(DataTable queryDataTable, int lineIdInt, int workFlowsIdInt)
        {
            string sqlStr = string.Format("Select * from BS_WorkFlowsLineCondition where IsNull(LineId, -1) = {0} and WorkFlowsId = {1}", lineIdInt,workFlowsIdInt);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询条件处理人员
        /// </summary>
        /// <param name="queryDataTable">填充的数据表</param>
        /// <param name="lineIdInt">连接线Id</param>
        /// <param name="workFlowsIdInt">流程图Id</param>
        public void QueryWorkFlowsLineHandle(DataTable queryDataTable, int lineIdInt, int workFlowsIdInt)
        {
            string sqlStr = string.Format("Select BS_WorkFlowsLineHandle.*, case LineHandleCate when 0 then BS_UserInfo.EmpName else BS_Role.RoleName end as HandleName from BS_WorkFlowsLineHandle left join BS_UserInfo on BS_WorkFlowsLineHandle.HandleOwner = BS_UserInfo.LoginId left join BS_Role on BS_WorkFlowsLineHandle.HandleOwner = BS_Role.RoleNo where ConditionId in (Select AutoId from BS_WorkFlowsLineCondition where IsNull(LineId, -1) = {0} and WorkFlowsId = {1}) order by AutoId", lineIdInt, workFlowsIdInt);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询条件通知人员
        /// </summary>
        /// <param name="queryDataTable">填充的数据表</param>
        /// <param name="lineIdInt">连接线Id</param>
        /// <param name="workFlowsIdInt">流程图Id</param>
        public void QueryWorkFlowsLineNotice(DataTable queryDataTable, int lineIdInt, int workFlowsIdInt)
        {
            string sqlStr = string.Format("Select BS_WorkFlowsLineNotice.*, case LineHandleCate when 0 then BS_UserInfo.EmpName else BS_Role.RoleName end as HandleName from BS_WorkFlowsLineNotice left join BS_UserInfo on BS_WorkFlowsLineNotice.HandleOwner = BS_UserInfo.LoginId left join BS_Role on BS_WorkFlowsLineNotice.HandleOwner = BS_Role.RoleNo where ConditionId in (Select AutoId from BS_WorkFlowsLineCondition where IsNull(LineId, -1) = {0} and WorkFlowsId = {1}) order by AutoId", lineIdInt, workFlowsIdInt);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        #region 使用统一更新，分别更新注释

        ///// <summary>
        ///// 新增连接线的设定条件
        ///// </summary>
        //public int InsertWorkFlowsLineCondition(int lineIdInt, string conditionTextStr, string conditionStr, int workFlowsIdInt)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsLineCondition where LineId = {0} and Condition = '{1}'", lineIdInt, conditionStr);
        //                if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
        //                {
        //                    trans.Rollback();
        //                    MessageHandler.ShowMessageBox("连接线的设定条件不能重复，请重新输入。");
        //                    return -1;
        //                }

        //                cmd.CommandText = string.Format("Update BS_WorkFlowsLine set Enabled = 1 where AutoId = {0}", lineIdInt);
        //                cmd.ExecuteNonQuery();

        //                int autoIdInt = InsertWorkFlowsLineCondition(cmd, lineIdInt < 1 ? "null" : lineIdInt.ToString(), conditionTextStr, conditionStr, workFlowsIdInt);

        //                trans.Commit();
        //                return autoIdInt;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}        

        ///// <summary>
        ///// 删除连接线的设定条件
        ///// </summary>
        //public bool DeleteWorkFlowsLineCondition(int autoIdInt)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsLineHandle where ConditionId = {0}", autoIdInt);
        //                if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
        //                {
        //                    trans.Rollback();
        //                    MessageHandler.ShowMessageBox("当前条件设定了处理人员，不可以删除。");
        //                    return false;
        //                }
        //                cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsLineNotice where ConditionId = {0}", autoIdInt);
        //                if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
        //                {
        //                    trans.Rollback();
        //                    MessageHandler.ShowMessageBox("当前条件设定了通知人员，不可以删除。");
        //                    return false;
        //                }

        //                cmd.CommandText = string.Format("Select * from BS_WorkFlowsLineCondition where AutoId = {0}", autoIdInt);
        //                DataTable conditionTable = BaseSQL.GetTableBySql(cmd);

        //                cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineCondition where AutoId = {0}", autoIdInt);
        //                cmd.ExecuteNonQuery();

        //                if (conditionTable.Rows.Count > 0)
        //                {
        //                    string logStr = string.Format("删除连接线设定条件：[AutoId]的值[{0}]，[条件名称]的值[{1}]，[条件SQL]的值[{2}]", autoIdInt, DataTypeConvert.GetString(conditionTable.Rows[0]["ConditionText"]), DataTypeConvert.GetString(conditionTable.Rows[0]["Condition"]));
        //                    LogHandler.RecordLog(cmd, logStr);

        //                    int lineIdInt = DataTypeConvert.GetInt(conditionTable.Rows[0]["LineId"]);
        //                    cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsLineCondition where LineId = {0}", lineIdInt);
        //                    if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) == 0)
        //                    {
        //                        cmd.CommandText = string.Format("Update BS_WorkFlowsLine set Enabled = 0 where AutoId = {0}", lineIdInt);
        //                        cmd.ExecuteNonQuery();
        //                    }
        //                }

        //                trans.Commit();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 新增条件处理人员
        ///// </summary>
        //public void InsertWorkFlowsLineHandle(int lineIdInt, int conditionIdInt, int lineHandleCateInt,string handleOwnerStr, int multiLevelApproverInt)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsLineHandle where LineId = {0} and ConditionId = {1} and LineHandleCate = {2} and HandleOwner = '{3}' and MultiLevelApprover = {4}", lineIdInt, conditionIdInt, lineHandleCateInt, handleOwnerStr, multiLevelApproverInt);
        //                if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
        //                {
        //                    trans.Rollback();
        //                    MessageHandler.ShowMessageBox("设定条件的处理人员不能重复，请重新输入。");
        //                    return;
        //                }

        //                cmd.CommandText = string.Format("Insert into BS_WorkFlowsLineHandle (LineId, ConditionId, LineHandleCate, HandleOwner, Creator, GetTime, MultiLevelApprover) values ({0}, {1}, {2}, '{3}', {4}, getdate(), {5})", lineIdInt, conditionIdInt, lineHandleCateInt, handleOwnerStr, SystemInfo.user.AutoId, multiLevelApproverInt);
        //                cmd.ExecuteNonQuery();

        //                string logStr = string.Format("新增条件的处理人员：[连接线ID]的值为[{0}]，[条件ID]的值为[{1}]，[人员类型]的值为[{2}]，[操作员角色编码]的值为[{3}]", lineIdInt, conditionIdInt, lineHandleCateInt, handleOwnerStr);
        //                LogHandler.RecordLog(cmd, logStr);

        //                trans.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 删除条件处理人员
        ///// </summary>
        //public void DeleteWorkFlowsLineHandle(int autoIdInt)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                cmd.CommandText = string.Format("Select * from BS_WorkFlowsLineHandle where AutoId = {0}", autoIdInt);
        //                DataTable handleTable = BaseSQL.GetTableBySql(cmd);

        //                cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineHandle where AutoId = {0}", autoIdInt);
        //                cmd.ExecuteNonQuery();

        //                if (handleTable.Rows.Count > 0)
        //                {
        //                    string logStr = string.Format("删除条件处理人员：[AutoId]的值[{0}]，[连接线ID]的值为[{1}]，[条件ID]的值为[{2}]，[人员类型]的值为[{3}]，[操作员角色编码]的值为[{4}]", autoIdInt, DataTypeConvert.GetString(handleTable.Rows[0]["LineId"]), DataTypeConvert.GetString(handleTable.Rows[0]["ConditionId"]), DataTypeConvert.GetString(handleTable.Rows[0]["LineHandleCate"]), DataTypeConvert.GetString(handleTable.Rows[0]["HandleOwner"]));
        //                    LogHandler.RecordLog(cmd, logStr);
        //                }

        //                trans.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 新增条件通知人员
        ///// </summary>
        //public void InsertWorkFlowsLineNotice(int lineIdInt, int conditionIdInt, int lineHandleCateInt, string handleOwnerStr, int multiLevelApproverInt)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                cmd.CommandText = string.Format("Select Count(*) from BS_WorkFlowsLineNotice where LineId = {0} and ConditionId = {1} and LineHandleCate = {2} and HandleOwner = '{3}' and MultiLevelApprover = {4}", lineIdInt, conditionIdInt, lineHandleCateInt, handleOwnerStr, multiLevelApproverInt);
        //                if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
        //                {
        //                    trans.Rollback();
        //                    MessageHandler.ShowMessageBox("设定条件的通知人员不能重复，请重新输入。");
        //                    return;
        //                }

        //                cmd.CommandText = string.Format("Insert into BS_WorkFlowsLineNotice (LineId, ConditionId, LineHandleCate, HandleOwner, Creator, GetTime, MultiLevelApprover) values ({0}, {1}, {2}, '{3}', {4}, getdate(), {5})", lineIdInt, conditionIdInt, lineHandleCateInt, handleOwnerStr, SystemInfo.user.AutoId, multiLevelApproverInt);
        //                cmd.ExecuteNonQuery();

        //                string logStr = string.Format("新增条件的通知人员：[连接线ID]的值为[{0}]，[条件ID]的值为[{1}]，[人员类型]的值为[{2}]，[操作员角色编码]的值为[{3}]", lineIdInt, conditionIdInt, lineHandleCateInt, handleOwnerStr);
        //                LogHandler.RecordLog(cmd, logStr);

        //                trans.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 删除条件通知人员
        ///// </summary>
        //public void DeleteWorkFlowsLineNotice(int autoIdInt)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                cmd.CommandText = string.Format("Select * from BS_WorkFlowsLineNotice where AutoId = {0}", autoIdInt);
        //                DataTable noticeTable = BaseSQL.GetTableBySql(cmd);

        //                cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineNotice where AutoId = {0}", autoIdInt);
        //                cmd.ExecuteNonQuery();

        //                if (noticeTable.Rows.Count > 0)
        //                {
        //                    string logStr = string.Format("删除条件通知人员：[AutoId]的值[{0}]，[连接线ID]的值为[{1}]，[条件ID]的值为[{2}]，[人员类型]的值为[{3}]，[操作员角色编码]的值为[{4}]", autoIdInt, DataTypeConvert.GetString(noticeTable.Rows[0]["LineId"]), DataTypeConvert.GetString(noticeTable.Rows[0]["ConditionId"]), DataTypeConvert.GetString(noticeTable.Rows[0]["LineHandleCate"]), DataTypeConvert.GetString(noticeTable.Rows[0]["HandleOwner"]));
        //                    LogHandler.RecordLog(cmd, logStr);
        //                }

        //                trans.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 复制处理人员信息到通知人员
        ///// </summary>
        //public void HandleCopyNotice(int conditionId)
        //{
        //    using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                SqlCommand cmd = new SqlCommand("", conn, trans);

        //                cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineNotice where ConditionId = {0}", conditionId);
        //                cmd.ExecuteNonQuery();

        //                cmd.CommandText = string.Format("Insert into BS_WorkFlowsLineNotice (LineId, ConditionId, MultiLevelApprover, LineHandleCate, HandleOwner, Creator, GetTime) select LineId, ConditionId, MultiLevelApprover, LineHandleCate, HandleOwner, {1} as Creator, GetDate() as GetTime from BS_WorkFlowsLineHandle where ConditionId = {0}", conditionId,SystemInfo.user.AutoId);
        //                cmd.ExecuteNonQuery();

        //                string logStr = string.Format("复制处理人员信息到通知人员：[条件ID]的值为[{0}]", conditionId);
        //                LogHandler.RecordLog(cmd, logStr);

        //                trans.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw ex;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        #endregion
    }
}
