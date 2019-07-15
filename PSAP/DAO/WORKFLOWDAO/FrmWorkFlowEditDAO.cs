using DevExpress.XtraDiagram;
using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PSAP.DAO.WORKFLOWDAO
{
    class FrmWorkFlowEditDAO
    {
        /// <summary>
        /// 查询流程表信息
        /// </summary>
        public void QueryWorkFlow(DataTable queryDataTable, int autoIdInt)
        {
            string sqlStr = string.Format("select * from BS_WorkFlow where AutoId = {0}", autoIdInt);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询当前的前一条流程表信息
        /// </summary>
        public void QueryWorkFlow_UpOne(DataTable queryDataTable, int autoIdInt)
        {
            string sqlStr = string.Format("select top 1 * from BS_WorkFlow where AutoId < {0} order by AutoId desc", autoIdInt);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询当前的后一条流程表信息
        /// </summary>
        public void QueryWorkFlow_DownOne(DataTable queryDataTable, int autoIdInt)
        {
            string sqlStr = string.Format("select top 1 * from BS_WorkFlow where AutoId > {0} order by AutoId", autoIdInt);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询最后一条流程表信息
        /// </summary>
        public void QueryWorkFlow_LastOne(DataTable queryDataTable)
        {
            string sqlStr = string.Format("select top 1 * from BS_WorkFlow order by AutoId Desc");
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询流程节点表
        /// </summary>
        public DataTable QueryWorkFlowNode_WorkFlowId(int workFlowIdInt)
        {
            string sqlStr = string.Format("select * from BS_WorkFlowNode where WorkFlowId = {0}", workFlowIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询节点和节点关系表
        /// </summary>
        public DataTable QueryWorkFlowNodeToNode_WorkFlowId(int workFlowIdInt)
        {
            string sqlStr = string.Format("select * from BS_WorkFlowNodeToNode where NodeId in (select AutoId from BS_WorkFlowNode where WorkFlowId = {0}) or LevelNodeId in (select AutoId from BS_WorkFlowNode where WorkFlowId = {0})", workFlowIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询流程节点表
        /// </summary>
        public DataTable QueryWorkFlowNode_Single(int autoIdInt)
        {
            string sqlStr = string.Format("select * from BS_WorkFlowNode where AutoId = {0}", autoIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询节点和节点关系表
        /// </summary>
        public DataTable QueryWorkFlowNodeToNode_Single(int autoIdInt)
        {
            string sqlStr = string.Format("select * from BS_WorkFlowNodeToNode where AutoId = {0}", autoIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询流程类型信息
        /// </summary>
        public DataTable QueryWorkFlowType()
        {
            string sqlStr = "select * from BS_WorkFlowType Order by AutoId";
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询某个节点处理人员表
        /// </summary>
        public void QueryWorkFlowNodeHandle(DataTable queryDataTable, int NodeIdInt)
        {
            string sqlStr = string.Format("select BS_WorkFlowNodeHandle.*, BS_UserInfo.EmpName as HandleOwnerText, BS_WorkFlowNode.NodeText from BS_WorkFlowNodeHandle left join BS_UserInfo on HandleOwner = BS_UserInfo.LoginId left join BS_WorkFlowNode on NodeId = BS_WorkFlowNode.AutoId where NodeHandleCate = 0 and NodeId = {0} Union All select BS_WorkFlowNodeHandle.*, BS_Role.RoleName as HandleOwnerText, BS_WorkFlowNode.NodeText from BS_WorkFlowNodeHandle left join BS_Role on HandleOwner = BS_Role.RoleNo left join BS_WorkFlowNode on NodeId = BS_WorkFlowNode.AutoId where NodeHandleCate = 1 and NodeId = {0}", NodeIdInt);
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 修改检查当前单据是否有使用该流程图
        /// </summary>
        public bool CheckCurrentData(int workFlowAutoIdInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);
                        if (!CheckCurrentData(cmd, workFlowAutoIdInt))
                            return false;

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
        /// 修改检查当前单据是否有使用该流程图
        /// </summary>
        public bool CheckCurrentData(SqlCommand cmd, int workFlowAutoIdInt)
        {
            cmd.CommandText = string.Format("select Count(*) from BS_DataCurrentNode where CurrentNodeId in (select AutoId from BS_WorkFlowNode where WorkFlowId = {0}) and IsEnd <> 1", workFlowAutoIdInt);
            int count = DataTypeConvert.GetInt(cmd.ExecuteScalar());
            if (count > 0)
            {
                cmd.Transaction.Rollback();
                MessageHandler.ShowMessageBox("有单据处在非最终节点，不可以修改流程信息。");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 删除检查当前单据是否有使用该流程图
        /// </summary>
        public bool CheckCurrentData_Delete(SqlCommand cmd, int workFlowAutoIdInt)
        {
            cmd.CommandText = string.Format("select Count(*) from BS_DataCurrentNode where CurrentNodeId in (select AutoId from BS_WorkFlowNode where WorkFlowId = {0})", workFlowAutoIdInt);
            int count = DataTypeConvert.GetInt(cmd.ExecuteScalar());
            if (count > 0)
            {
                cmd.Transaction.Rollback();
                MessageHandler.ShowMessageBox("有单据已经使用当前流程信息，不可以删除。");
                return false;
            }

            return true;
        }

        ///// <summary>
        ///// 查询流程表中的文件信息
        ///// </summary>
        //public string QueryWorkFlow_Document(int autoIdInt, string workFlowTextStr, string tempFilePath)
        //{
        //    string sqlStr = string.Format("select AutoId, FileByte from BS_WorkFlow where AutoId = {0}", autoIdInt);
        //    DataTable docTable = BaseSQL.GetTableBySql(sqlStr);
        //    if (docTable.Rows.Count == 0)
        //        return "";
        //    Byte[] fileByte = (byte[])docTable.Rows[0]["FileByte"];

        //    FileHandler fileHandler = new FileHandler();
        //    fileHandler.ByteArrayToFile(fileByte, tempFilePath);
        //    return tempFilePath;
        //}

        ///// <summary>
        ///// 更新某个单据模板
        ///// </summary>
        //public bool UpdateWorkFlow(SqlCommand cmd, int autoIdInt, string iniPath)
        //{
        //    long streamLength = 0;
        //    Byte[] buffer = new FileHandler().FileToByteArray(iniPath, ref streamLength);

        //    SqlParameter p1 = new SqlParameter("@filebyte", SqlDbType.Image);
        //    p1.Value = buffer;
        //    SqlParameter p2 = new SqlParameter("@AutoId", SqlDbType.Int);
        //    p2.Value = autoIdInt;
        //    cmd.Parameters.Add(p1);
        //    cmd.Parameters.Add(p2);
        //    cmd.CommandText = "Update BS_WorkFlow Set FileByte = @filebyte where AutoId = @AutoId";
        //    cmd.ExecuteNonQuery();


        //    return true;
        //}

        /// <summary>
        /// 保存流程表
        /// </summary>
        public int SaveWorkFlow(DataRow headRow, List<DiagramConnector> connectorList, List<DiagramShape> shapeList)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        DateTime nowTime = BaseSQL.GetServerDateTime();
                        int autoIdInt = 0;

                        if(CheckWorkFlowType(cmd, DataTypeConvert.GetInt(headRow["AutoId"]), DataTypeConvert.GetInt(headRow["WorkFlowTypeAutoId"])))
                        {
                            return 0;
                        }

                        if (headRow.RowState == DataRowState.Added)//新增
                        {
                            headRow["GetTime"] = nowTime;
                            //新增保存流程主表
                            cmd.CommandText = string.Format("Insert into BS_WorkFlow (WorkFlowText, Remark, GetTime) values ('{0}', '{1}', '{2}')", DataTypeConvert.GetString(headRow["WorkFlowText"]), DataTypeConvert.GetString(headRow["Remark"]), nowTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            autoIdInt = cmd.ExecuteNonQuery();
                            if (autoIdInt != 1)
                            {
                                trans.Rollback();
                                headRow.Table.RejectChanges();
                                MessageHandler.ShowMessageBox("保存流程表信息错误，请重新新增操作。");
                                return -1;
                            }
                            cmd.CommandText = "select @@IDENTITY";
                            autoIdInt = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                            headRow["AutoId"] = autoIdInt;

                            InsertWorkFlowNodeInfo(cmd, autoIdInt, connectorList, shapeList);
                        }
                        else//修改
                        {
                            if (!CheckCurrentData(cmd, DataTypeConvert.GetInt(headRow["AutoId"])))
                                return 0;

                            //修改保存流程主表
                            cmd.CommandText = "select * from BS_WorkFlow where 1=2";
                            SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                            DataTable tmpHeadTable = new DataTable();
                            adapterHead.Fill(tmpHeadTable);
                            BaseSQL.UpdateDataTable(adapterHead, headRow.Table);
                            autoIdInt = DataTypeConvert.GetInt(headRow["AutoId"]);

                            UpdateWorkFlowNodeInfo(cmd, autoIdInt, connectorList, shapeList);
                        }

                        //保存日志到日志表中
                        string logStr = LogHandler.RecordLog_DataRow(cmd, "流程表信息", headRow, "AutoId");

                        //UpdateWorkFlow(cmd, autoIdInt, tempFilePath);

                        trans.Commit();
                        headRow.AcceptChanges();

                        return 1;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        headRow.Table.RejectChanges();
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
        /// 检查选择的功能模块是否存在
        /// </summary>
        private bool CheckWorkFlowType(SqlCommand cmd, int autoIdInt, int workFlowTypeAutoIdInt)
        {
            cmd.CommandText = string.Format("select Count(*) from BS_WorkFlow where AutoId != {0} and WorkFlowTypeAutoId = {1}", autoIdInt, workFlowTypeAutoIdInt);
            if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
            {
                cmd.Transaction.Rollback();
                MessageHandler.ShowMessageBox("当前选中的流程类型已经在其他流程图中启用，不可以重复启用，请重新选择。");
                return true;
            }
            return false;
        }

        /// <summary>
        /// 新增保存流程节点的全部信息
        /// </summary>
        private void InsertWorkFlowNodeInfo(SqlCommand cmd, int autoIdInt, List<DiagramConnector> connectorList, List<DiagramShape> shapeList)
        {
            //新增保存流程节点表
            Dictionary<DiagramShape, int> tempDict = new Dictionary<DiagramShape, int>();
            foreach (DiagramShape dShape in shapeList)
            {
                //dShape.Height临时存储NodeCate节点类别
                cmd.CommandText = string.Format("insert into BS_WorkFlowNode (WorkFlowId, NodeCate, NodeText, Creator, PositionX, PositionY, Width, Height, BackColor, ForeColor, FontName, FontSize, FlowModuleId) values ({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '{10}', {11}, {12})", autoIdInt, dShape.MinHeight, dShape.Content, SystemInfo.user.LoginID, dShape.Position.X, dShape.Position.Y, dShape.Width, dShape.Height, DataTypeConvert.ColorToString(dShape.Appearance.BackColor), DataTypeConvert.ColorToString(dShape.Appearance.ForeColor), dShape.Appearance.Font.Name, DataTypeConvert.GetInt(dShape.Appearance.Font.Size), dShape.Appearance.Name == "" ? "null" : "'" + dShape.Appearance.Name + "'");
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select @@IDENTITY";
                int tempAutoId = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                tempDict.Add(dShape, tempAutoId);
            }

            //新增保存节点和节点关系表
            foreach (DiagramConnector dConn in connectorList)
            {
                int nodeId = 0;
                int levelNodeId = 0;
                if (dConn.BeginItem != null)
                {
                    nodeId = tempDict[(DiagramShape)dConn.BeginItem];
                }
                if (dConn.EndItem != null)
                {
                    levelNodeId = tempDict[(DiagramShape)dConn.EndItem];
                }

                cmd.CommandText = string.Format("insert into BS_WorkFlowNodeToNode (NodeId, LevelNodeId, Condition, Creator, BeginPositionX, BeginPositionY, EndPositionX, EndPositionY, BackColor, ForeColor, FontName, FontSize, BeginPointIndex, EndPointIndex) values({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '{10}', {11}, {12}, {13})", nodeId, levelNodeId, dConn.Text, SystemInfo.user.LoginID, dConn.BeginPoint.X, dConn.BeginPoint.Y, dConn.EndPoint.X, dConn.EndPoint.Y, DataTypeConvert.ColorToString(dConn.Appearance.BackColor), DataTypeConvert.ColorToString(dConn.Appearance.ForeColor), dConn.Appearance.Font.Name, DataTypeConvert.GetInt(dConn.Appearance.Font.Size), dConn.BeginItemPointIndex, dConn.EndItemPointIndex);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 更新保存流程节点的全部信息
        /// </summary>
        private void UpdateWorkFlowNodeInfo(SqlCommand cmd, int autoIdInt, List<DiagramConnector> connectorList, List<DiagramShape> shapeList)
        {
            Dictionary<DiagramShape, int> tempDict = new Dictionary<DiagramShape, int>();
            string dShapeAutoIdSql = "";
            foreach (DiagramShape dShape in shapeList)
            {
                if (DataTypeConvert.GetInt(dShape.CustomStyleId) == 0)
                {
                    cmd.CommandText = string.Format("insert into BS_WorkFlowNode (WorkFlowId, NodeCate, NodeText, Creator, PositionX, PositionY, Width, Height, BackColor, ForeColor, FontName, FontSize, FlowModuleId) values ({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '{10}', {11}, {12})", autoIdInt, dShape.MinHeight, dShape.Content, SystemInfo.user.LoginID, dShape.Position.X, dShape.Position.Y, dShape.Width, dShape.Height, DataTypeConvert.ColorToString(dShape.Appearance.BackColor), DataTypeConvert.ColorToString(dShape.Appearance.ForeColor), dShape.Appearance.Font.Name, DataTypeConvert.GetInt(dShape.Appearance.Font.Size), dShape.Appearance.Name == "" ? "null" : "'" + dShape.Appearance.Name + "'");
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select @@IDENTITY";
                    dShape.CustomStyleId = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                }
                else
                {
                    cmd.CommandText = string.Format("update BS_WorkFlowNode set NodeCate = {1}, NodeText = '{2}', Creator = '{3}', GetTime = GETDATE(), PositionX = {4}, PositionY = {5}, Width = {6}, Height = {7}, BackColor = '{8}', ForeColor = '{9}' , FontName = '{10}' , FontSize = {11}, FlowModuleId = {12} where AutoId = {0}", DataTypeConvert.GetInt(dShape.CustomStyleId), dShape.MinHeight, dShape.Content, SystemInfo.user.LoginID, dShape.Position.X, dShape.Position.Y, dShape.Width, dShape.Height, DataTypeConvert.ColorToString(dShape.Appearance.BackColor), DataTypeConvert.ColorToString(dShape.Appearance.ForeColor), dShape.Appearance.Font.Name, DataTypeConvert.GetInt(dShape.Appearance.Font.Size), dShape.Appearance.Name == "" ? "null" : "'" + dShape.Appearance.Name + "'");
                    int count = cmd.ExecuteNonQuery();
                    if(count == 0)
                    {
                        cmd.CommandText = string.Format("insert into BS_WorkFlowNode (WorkFlowId, NodeCate, NodeText, Creator, PositionX, PositionY, Width, Height, BackColor, ForeColor, FontName, FontSize, FlowModuleId) values ({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '{10}', {11}, {12})", autoIdInt, dShape.MinHeight, dShape.Content, SystemInfo.user.LoginID, dShape.Position.X, dShape.Position.Y, dShape.Width, dShape.Height, DataTypeConvert.ColorToString(dShape.Appearance.BackColor), DataTypeConvert.ColorToString(dShape.Appearance.ForeColor), dShape.Appearance.Font.Name, DataTypeConvert.GetInt(dShape.Appearance.Font.Size), dShape.Appearance.Name == "" ? "null" : "'" + dShape.Appearance.Name + "'");
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "select @@IDENTITY";
                        dShape.CustomStyleId = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                    }
                }
                tempDict.Add(dShape, DataTypeConvert.GetInt(dShape.CustomStyleId));
                dShapeAutoIdSql += string.Format("{0},", DataTypeConvert.GetInt(dShape.CustomStyleId));
            }


            string dConnAutoIdSql = "";
            foreach (DiagramConnector dConn in connectorList)
            {
                int nodeId = 0;
                int levelNodeId = 0;
                if (dConn.BeginItem != null)
                {
                    nodeId = tempDict[(DiagramShape)dConn.BeginItem];
                }
                if (dConn.EndItem != null)
                {
                    levelNodeId = tempDict[(DiagramShape)dConn.EndItem];
                }
                if (DataTypeConvert.GetInt(dConn.CustomStyleId) == 0)
                {
                    cmd.CommandText = string.Format("insert into BS_WorkFlowNodeToNode (NodeId, LevelNodeId, Condition, Creator, BeginPositionX, BeginPositionY, EndPositionX, EndPositionY, BackColor, ForeColor, FontName, FontSize, BeginPointIndex, EndPointIndex) values({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '{10}', {11}, {12}, {13})", nodeId, levelNodeId, dConn.Text, SystemInfo.user.LoginID, dConn.BeginPoint.X, dConn.BeginPoint.Y, dConn.EndPoint.X, dConn.EndPoint.Y, DataTypeConvert.ColorToString(dConn.Appearance.BackColor), DataTypeConvert.ColorToString(dConn.Appearance.ForeColor), dConn.Appearance.Font.Name, DataTypeConvert.GetInt(dConn.Appearance.Font.Size), dConn.BeginItemPointIndex, dConn.EndItemPointIndex);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select @@IDENTITY";
                    dConn.CustomStyleId = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                }
                else
                {
                    cmd.CommandText = string.Format("update BS_WorkFlowNodeToNode set NodeId = {1}, LevelNodeId = {2}, Condition = '{3}', Creator = '{4}', GetTime = GETDATE(), BeginPositionX = {5}, BeginPositionY = {6}, EndPositionX = {7}, EndPositionY = {8}, BackColor = '{9}', ForeColor = '{10}', FontName = '{11}', FontSize = {12}, BeginPointIndex = {13}, EndPointIndex = {14} where AutoId = {0}", DataTypeConvert.GetInt(dConn.CustomStyleId), nodeId, levelNodeId, dConn.Text, SystemInfo.user.LoginID, dConn.BeginPoint.X, dConn.BeginPoint.Y, dConn.EndPoint.X, dConn.EndPoint.Y, DataTypeConvert.ColorToString(dConn.Appearance.BackColor), DataTypeConvert.ColorToString(dConn.Appearance.ForeColor), dConn.Appearance.Font.Name, DataTypeConvert.GetInt(dConn.Appearance.Font.Size), dConn.BeginItemPointIndex, dConn.EndItemPointIndex);
                    int count = cmd.ExecuteNonQuery();
                    if(count == 0)
                    {
                        cmd.CommandText = string.Format("insert into BS_WorkFlowNodeToNode (NodeId, LevelNodeId, Condition, Creator, BeginPositionX, BeginPositionY, EndPositionX, EndPositionY, BackColor, ForeColor, FontName, FontSize, BeginPointIndex, EndPointIndex) values({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '{10}', {11}, {12}, {13})", nodeId, levelNodeId, dConn.Text, SystemInfo.user.LoginID, dConn.BeginPoint.X, dConn.BeginPoint.Y, dConn.EndPoint.X, dConn.EndPoint.Y, DataTypeConvert.ColorToString(dConn.Appearance.BackColor), DataTypeConvert.ColorToString(dConn.Appearance.ForeColor), dConn.Appearance.Font.Name, DataTypeConvert.GetInt(dConn.Appearance.Font.Size), dConn.BeginItemPointIndex, dConn.EndItemPointIndex);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "select @@IDENTITY";
                        dConn.CustomStyleId = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                    }
                }
                dConnAutoIdSql += string.Format("{0},", DataTypeConvert.GetInt(dConn.CustomStyleId));
            }

            cmd.CommandText = string.Format("delete from BS_WorkFlowNodeToNode where (NodeId in (select AutoId from BS_WorkFlowNode where WorkFlowId = {0}) or LevelNodeId in (select AutoId from BS_WorkFlowNode where WorkFlowId = {0})) and AutoId not in ({1})", autoIdInt, dConnAutoIdSql.Substring(0, dConnAutoIdSql.Length - 1));
            cmd.ExecuteNonQuery();

            cmd.CommandText = string.Format("delete from BS_WorkFlowNode where WorkFlowId = {0} and AutoId not in ({1})", autoIdInt, dShapeAutoIdSql.Substring(0, dShapeAutoIdSql.Length - 1));
            cmd.ExecuteNonQuery();
        }


        /// <summary>
        /// 删除流程表
        /// </summary>
        public bool DeleteWorkFlow(int autoIdInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        if (!CheckCurrentData_Delete(cmd, autoIdInt))
                            return false;

                        //查询当前使用节点的记录
                        cmd.CommandText = string.Format("select Count(*) from BS_DataCurrentNode where CurrentNodeId in (select AutoId from BS_WorkFlowNode where WorkFlowId = {0})", autoIdInt);
                        if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("有单据正在使用当前的流程信息，不可以删除。");
                            return false;
                        }

                        //查询历史单据使用节点的记录
                        cmd.CommandText = string.Format("select COUNT(*) from BS_WorkFlowDataHandle where NodeId in (select AutoId from BS_WorkFlowNode where WorkFlowId = {0})", autoIdInt);
                        if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("有历史单据使用当前的流程信息，不可以删除。");
                            return false;
                        }

                        cmd.CommandText = string.Format("select * from BS_WorkFlow where AutoId = {0}", autoIdInt);
                        DataTable tmpTable = new DataTable();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(tmpTable);

                        if (tmpTable.Rows.Count > 0)
                        {
                            //保存日志到日志表中
                            LogHandler.RecordLog(cmd, string.Format("删除流程表信息：流程名称的原值为[{0}]，备注的原值为[{1}]", DataTypeConvert.GetString(tmpTable.Rows[0]["WorkFlowText"]), DataTypeConvert.GetString(tmpTable.Rows[0]["Remark"])));
                        }

                        cmd.CommandText = string.Format("delete from BS_WorkFlowNodeHandle where NodeId in (select AutoId from BS_WorkFlowNode where WorkFlowId = {0})", autoIdInt);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("delete from BS_WorkFlowNodeToNode where NodeId in (select AutoId from BS_WorkFlowNode where WorkFlowId = {0})", autoIdInt);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("delete from BS_WorkFlowNode where WorkFlowId = {0}", autoIdInt);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("delete from BS_WorkFlow where AutoId = {0}", autoIdInt);
                        cmd.ExecuteNonQuery();

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
        /// 保存节点处理人员信息
        /// </summary>
        public bool SaveWorkFlowNodeHandle(int nodeIdInt, int handleCateInt, string handleOwnerStr)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("select Count(*) from BS_WorkFlowNodeHandle where NodeId = {0} and NodeHandleCate = {1} and HandleOwner = '{2}'", nodeIdInt, handleCateInt, handleOwnerStr);
                        if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("当前信息已经登记过，不能重复登记。");
                            return true;
                        }

                        cmd.CommandText = string.Format("select NodeCate from BS_WorkFlowNode where AutoId = {0}", nodeIdInt);
                        if(DataTypeConvert.GetInt(cmd.ExecuteScalar()) == 1)
                        {
                            trans.Rollback();
                            MessageHandler.ShowMessageBox("开始节点不用登记节点处理人员。");
                            return true;
                        }

                        cmd.CommandText = string.Format("insert into BS_WorkFlowNodeHandle (NodeId, NodeHandleCate, HandleOwner, Creator) values({0}, {1}, '{2}', '{3}')", nodeIdInt, handleCateInt, handleOwnerStr, SystemInfo.user.LoginID);
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        LogHandler.RecordLog(cmd, string.Format("新增节点处理人员信息：节点ID为[{0}]，类型为[{1}]，用户或角色编号为[{2}]", nodeIdInt, handleCateInt, handleOwnerStr));

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
        /// 删除节点处理人员信息
        /// </summary>
        public bool DeleteWorkFlowNodeHandle(DataRow headRow)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("delete from BS_WorkFlowNodeHandle where AutoId = {0}", DataTypeConvert.GetString(headRow["AutoId"]));
                        cmd.ExecuteNonQuery();

                        //保存日志到日志表中
                        LogHandler.RecordLog(cmd, string.Format("新增节点处理人员信息：节点ID的原值为[{0}]，类型的原值为[{1}]，用户或角色编号的原值为[{2}]", DataTypeConvert.GetString(headRow["NodeId"]), DataTypeConvert.GetString(headRow["NodeHandleCate"]), DataTypeConvert.GetString(headRow["HandleOwner"])));

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

    }
}
