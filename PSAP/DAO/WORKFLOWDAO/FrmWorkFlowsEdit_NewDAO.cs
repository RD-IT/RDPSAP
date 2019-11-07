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
    class FrmWorkFlowsEdit_NewDAO
    {
        /// <summary>
        /// 查询流程图信息
        /// </summary>
        /// <param name="queryDataTable">要填充的数据表</param>
        public void QueryWorkFlows(DataTable queryDataTable)
        {
            string sqlStr = string.Format("select * from V_BS_WorkFlows_TreeList Order by IndexNo");
            BaseSQL.Query(sqlStr, queryDataTable);
        }

        /// <summary>
        /// 查询流程图状态节点表
        /// </summary>
        /// <param name="workFlowsIdInt">流程图Id</param>
        public DataTable QueryWorkFlowsNode_WorkFlowsId(int workFlowsIdInt)
        {
            string sqlStr = string.Format("select * from BS_WorkFlowsNode where WorkFlowsId = {0}", workFlowsIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询流程图连接线表
        /// </summary>
        /// <param name="workFlowsIdInt">流程图Id</param>
        public DataTable QueryWorkFlowsLine_WorkFlowsId(int workFlowsIdInt)
        {
            string sqlStr = string.Format("select * from BS_WorkFlowsLine where WorkFlowsId = {0}", workFlowsIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询流程图连接线的所有转节点
        /// </summary>
        /// <param name="workFlowsIdInt">流程图Id</param>
        public DataTable QueryWorkFlowsLinePoint(int workFlowsIdInt)
        {
            string sqlStr = string.Format("select * from BS_WorkFlowsLinePoint where LineId in (select AutoId from BS_WorkFlowsLine where WorkFlowsId = {0}) Order by LineId, PointIndex", workFlowsIdInt);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 保存流程表
        /// </summary>
        /// <param name="headRow">流程图主表行信息</param>
        /// <param name="connectorList">流程图中的所有连接线列表</param>
        /// <param name="shapeList">流程图中的所有状态节点列表</param>
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

                        if (DataTypeConvert.GetInt(headRow["Enabled"]) == 1 && CheckWorkFlowType(cmd, DataTypeConvert.GetInt(headRow["AutoId"]), DataTypeConvert.GetInt(headRow["WorkFlowsType"])))
                        {
                            //headRow.Table.RejectChanges();
                            return 0;
                        }

                        if (headRow.RowState == DataRowState.Added)//新增
                        {
                            if (DataTypeConvert.GetInt(headRow["Enabled"]) == 1)
                                headRow["EnabledTime"] = nowTime;
                            else
                                headRow["EnabledTime"] = DBNull.Value;

                            //新增保存流程主表
                            cmd.CommandText = string.Format("Insert into BS_WorkFlows (WorkFlowsText, WorkFlowsType, Enabled, Remark, EnabledTime, IndexNo, NextWorkFlowsType) values ('{0}', {1}, {2}, '{3}', {4}, (select IsNull(Max(IndexNo), 0) + 1 from BS_WorkFlows), {5})", DataTypeConvert.GetString(headRow["WorkFlowsText"]), DataTypeConvert.GetInt(headRow["WorkFlowsType"]), DataTypeConvert.GetInt(headRow["Enabled"]), DataTypeConvert.GetString(headRow["Remark"]), DataTypeConvert.GetInt(headRow["Enabled"]) == 1 ? "'" + nowTime.ToString("yyyy-MM-dd HH:mm:ss") + "'" : "Null", DataTypeConvert.GetInt(headRow["NextWorkFlowsType"]));
                            autoIdInt = cmd.ExecuteNonQuery();
                            if (autoIdInt != 1)
                            {
                                trans.Rollback();
                                headRow.Table.RejectChanges();
                                MessageHandler.ShowMessageBox("保存流程图信息错误，请重新新增操作。");
                                return -1;
                            }
                            cmd.CommandText = "select @@IDENTITY";
                            autoIdInt = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                            headRow["AutoId"] = autoIdInt;

                            InsertWorkFlowNodeInfo(cmd, autoIdInt, connectorList, shapeList);
                        }
                        else//修改
                        {
                            if (DataTypeConvert.GetInt(headRow["Enabled", DataRowVersion.Original]) != DataTypeConvert.GetInt(headRow["Enabled", DataRowVersion.Current]))
                            {
                                if (DataTypeConvert.GetInt(headRow["Enabled"]) == 1)
                                    headRow["EnabledTime"] = nowTime;
                                else
                                    headRow["EnabledTime"] = DBNull.Value;
                            }

                            //修改保存流程主表
                            cmd.CommandText = "select * from BS_WorkFlows where 1=2";
                            SqlDataAdapter adapterHead = new SqlDataAdapter(cmd);
                            DataTable tmpHeadTable = new DataTable();
                            adapterHead.Fill(tmpHeadTable);
                            BaseSQL.UpdateDataTable(adapterHead, headRow.Table);
                            autoIdInt = DataTypeConvert.GetInt(headRow["AutoId"]);

                            UpdateWorkFlowNodeInfo(cmd, autoIdInt, connectorList, shapeList);
                        }

                        //保存日志到日志表中
                        string logStr = LogHandler.RecordLog_DataRow(cmd, "流程图信息", headRow, "AutoId");

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
        /// <param name="autoIdInt">流程图Id</param>
        /// <param name="workFlowsTypeInt">流程图类别编号</param>
        private bool CheckWorkFlowType(SqlCommand cmd, int autoIdInt, int workFlowsTypeInt)
        {
            cmd.CommandText = string.Format("select Count(*) from BS_WorkFlows where AutoId != {0} and WorkFlowsType = {1} and IsNull(Enabled, 0) = 1", autoIdInt, workFlowsTypeInt);
            if (DataTypeConvert.GetInt(cmd.ExecuteScalar()) > 0)
            {
                cmd.Transaction.Rollback();
                MessageHandler.ShowMessageBox("当前选中的流程图类型已经在其他启用的流程图中使用，不可以重复使用，请重新选择。");
                return true;
            }
            return false;
        }

        /// <summary>
        /// 新增保存流程节点的全部信息
        /// </summary>
        /// <param name="autoIdInt">流程图Id</param>
        /// <param name="connectorList">流程图中的所有连接线列表</param>
        /// <param name="shapeList">流程图中的所有状态节点列表</param>
        private void InsertWorkFlowNodeInfo(SqlCommand cmd, int autoIdInt, List<DiagramConnector> connectorList, List<DiagramShape> shapeList)
        {
            //新增保存流程节点表
            Dictionary<DiagramShape, int> tempDict = new Dictionary<DiagramShape, int>();
            foreach (DiagramShape dShape in shapeList)
            {
                //dShape.Height临时存储NodeCate节点类别
                int tempAutoId = InsertWorkFlowsNode(cmd, dShape, autoIdInt);
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

                InsertWorkFlowsLine(cmd, dConn, autoIdInt, nodeId, levelNodeId);

                //cmd.CommandText = string.Format("insert into BS_WorkFlowsLine (WorkFlowsId, LineText, NodeId, LevelNodeId, LineType, Creator, GetTime, BeginPositionX, BeginPositionY, EndPositionX, EndPositionY, BackColor, ForeColor, FontName, FontSize, BeginPointIndex, EndPointIndex) values({0}, '{1}', {2}, {3}, {4}, {5}, getdate(), {6}, {7}, {8}, {9}, '{10}', '{11}', '{12}', {13}, {14}, {15})", autoIdInt, dConn.Text, nodeId, levelNodeId, DataTypeConvert.GetInt(dConn.Appearance.Name), SystemInfo.user.AutoId, dConn.BeginPoint.X, dConn.BeginPoint.Y, dConn.EndPoint.X, dConn.EndPoint.Y, DataTypeConvert.ColorToString(dConn.Appearance.BackColor), DataTypeConvert.ColorToString(dConn.Appearance.ForeColor), dConn.Appearance.Font.Name, DataTypeConvert.GetInt(dConn.Appearance.Font.Size), dConn.BeginItemPointIndex, dConn.EndItemPointIndex);
                //cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 新增流程图状态节点
        /// </summary>
        /// <param name="dShape">状态节点的实例</param>
        /// <param name="autoIdInt">流程图Id</param>
        private int InsertWorkFlowsNode(SqlCommand cmd, DiagramShape dShape, int autoIdInt)
        {
            cmd.CommandText = string.Format("insert into BS_WorkFlowsNode (WorkFlowsId, NodeText, Creator, GetTime, PositionX, PositionY, Width, Height, BackColor, ForeColor, FontName, FontSize) values ({0}, '{1}', {2}, getdate(), {3}, {4}, {5}, {6}, '{7}', '{8}', '{9}', {10})", autoIdInt, dShape.Content, SystemInfo.user.AutoId, dShape.Position.X, dShape.Position.Y, dShape.Width, dShape.Height, DataTypeConvert.ColorToString(dShape.Appearance.BackColor), DataTypeConvert.ColorToString(dShape.Appearance.ForeColor), dShape.Appearance.Font.Name, DataTypeConvert.GetInt(dShape.Appearance.Font.Size));
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select @@IDENTITY";
            return DataTypeConvert.GetInt(cmd.ExecuteScalar());
        }

        /// <summary>
        /// 新增流程图连接线
        /// </summary>
        /// <param name="dConn">连接线的实例</param>
        /// <param name="autoIdInt">流程图Id</param>
        /// <param name="nodeIdInt">连接线的上级节点Id</param>
        /// <param name="levelNodeIdInt">连接线的下级节点Id</param>
        private int InsertWorkFlowsLine(SqlCommand cmd, DiagramConnector dConn, int autoIdInt, int nodeIdInt, int levelNodeIdInt)
        {
            cmd.CommandText = string.Format("insert into BS_WorkFlowsLine (WorkFlowsId, LineText, NodeId, LevelNodeId, LineType, Creator, GetTime, BeginPositionX, BeginPositionY, EndPositionX, EndPositionY, BackColor, ForeColor, FontName, FontSize, BeginPointIndex, EndPointIndex) values({0}, '{1}', {2}, {3}, {4}, {5}, getdate(), {6}, {7}, {8}, {9}, '{10}', '{11}', '{12}', {13}, {14}, {15})", autoIdInt, dConn.Text, nodeIdInt, levelNodeIdInt, DataTypeConvert.GetInt(dConn.Appearance.Name), SystemInfo.user.AutoId, dConn.BeginPoint.X, dConn.BeginPoint.Y, dConn.EndPoint.X, dConn.EndPoint.Y, DataTypeConvert.ColorToString(dConn.Appearance.BackColor), DataTypeConvert.ColorToString(dConn.Appearance.ForeColor), dConn.Appearance.Font.Name, DataTypeConvert.GetInt(dConn.Appearance.Font.Size), dConn.BeginItemPointIndex, dConn.EndItemPointIndex);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select @@IDENTITY";
            int lineIdInt = DataTypeConvert.GetInt(cmd.ExecuteScalar());
            InsertWorkFlowsLinePoint(cmd, lineIdInt, dConn);
            return lineIdInt;
        }

        /// <summary>
        /// 新增流程图连接线转节点
        /// </summary>
        /// <param name="lineIdInt">连接线Id</param>
        /// <param name="dConn">连接线的实例</param>
        private void InsertWorkFlowsLinePoint(SqlCommand cmd, int lineIdInt, DiagramConnector dConn)
        {
            for (int i = 0; i < dConn.IntermediatePoints.Count; i++)
            {
                cmd.CommandText = string.Format("insert into BS_WorkFlowsLinePoint(LineId, PositionX, PositionY, PointIndex) values ({0}, {1}, {2}, {3})", lineIdInt, dConn.IntermediatePoints[i].X, dConn.IntermediatePoints[i].Y, i);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 更新保存流程节点的全部信息
        /// </summary>
        /// <param name="autoIdInt">流程图Id</param>
        /// <param name="connectorList">流程图中的所有连接线列表</param>
        /// <param name="shapeList">流程图中的所有状态节点列表</param>
        private void UpdateWorkFlowNodeInfo(SqlCommand cmd, int autoIdInt, List<DiagramConnector> connectorList, List<DiagramShape> shapeList)
        {
            Dictionary<DiagramShape, int> tempDict = new Dictionary<DiagramShape, int>();
            string dShapeAutoIdSql = "";
            foreach (DiagramShape dShape in shapeList)
            {
                if (DataTypeConvert.GetInt(dShape.CustomStyleId) == 0)
                {
                    dShape.CustomStyleId = InsertWorkFlowsNode(cmd, dShape, autoIdInt);
                }
                else
                {
                    cmd.CommandText = string.Format("update BS_WorkFlowsNode set NodeText = '{1}', PositionX = {2}, PositionY = {3}, Width = {4}, Height = {5}, BackColor = '{6}', ForeColor = '{7}' , FontName = '{8}' , FontSize = {9} where AutoId = {0}", DataTypeConvert.GetInt(dShape.CustomStyleId), dShape.Content, dShape.Position.X, dShape.Position.Y, dShape.Width, dShape.Height, DataTypeConvert.ColorToString(dShape.Appearance.BackColor), DataTypeConvert.ColorToString(dShape.Appearance.ForeColor), dShape.Appearance.Font.Name, DataTypeConvert.GetInt(dShape.Appearance.Font.Size));
                    int count = cmd.ExecuteNonQuery();
                    if (count == 0)
                    {
                        dShape.CustomStyleId = InsertWorkFlowsNode(cmd, dShape, autoIdInt);
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
                    dConn.CustomStyleId = InsertWorkFlowsLine(cmd, dConn, autoIdInt, nodeId, levelNodeId);
                }
                else
                {
                    int lineIdInt = DataTypeConvert.GetInt(dConn.CustomStyleId);
                    cmd.CommandText = string.Format("update BS_WorkFlowsLine set NodeId = {1}, LevelNodeId = {2}, LineText = '{3}', LineType = {4}, BeginPositionX = {5}, BeginPositionY = {6}, EndPositionX = {7}, EndPositionY = {8}, BackColor = '{9}', ForeColor = '{10}', FontName = '{11}', FontSize = {12}, BeginPointIndex = {13}, EndPointIndex = {14} where AutoId = {0}", lineIdInt, nodeId, levelNodeId, dConn.Text, DataTypeConvert.GetInt(dConn.Appearance.Name), dConn.BeginPoint.X, dConn.BeginPoint.Y, dConn.EndPoint.X, dConn.EndPoint.Y, DataTypeConvert.ColorToString(dConn.Appearance.BackColor), DataTypeConvert.ColorToString(dConn.Appearance.ForeColor), dConn.Appearance.Font.Name, DataTypeConvert.GetInt(dConn.Appearance.Font.Size), dConn.BeginItemPointIndex, dConn.EndItemPointIndex);
                    int count = cmd.ExecuteNonQuery();
                    if (count == 0)
                    {
                        dConn.CustomStyleId = InsertWorkFlowsLine(cmd, dConn, autoIdInt, nodeId, levelNodeId);
                    }
                    else
                    {
                        cmd.CommandText = string.Format("Delete from BS_WorkFlowsLinePoint where LineId = {0}", lineIdInt);
                        cmd.ExecuteNonQuery();
                        InsertWorkFlowsLinePoint(cmd, lineIdInt, dConn);
                    }
                }
                dConnAutoIdSql += string.Format("{0},", DataTypeConvert.GetInt(dConn.CustomStyleId));
            }

            //删除连接线表以及相关的表
            string autoIdListStr = dConnAutoIdSql.Length > 0? dConnAutoIdSql.Substring(0, dConnAutoIdSql.Length - 1): "0";
            cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineNotice where LineId in (Select AutoId from BS_WorkFlowsLine where WorkFlowsId = {0} and AutoId not in ({1}))", autoIdInt, autoIdListStr);
            cmd.ExecuteNonQuery();
            cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineHandle where LineId in (Select AutoId from BS_WorkFlowsLine where WorkFlowsId = {0} and AutoId not in ({1}))", autoIdInt, autoIdListStr);
            cmd.ExecuteNonQuery();

            cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineConditionList where ConditionId in (Select AutoId from BS_WorkFlowsLineCondition where LineId in (Select AutoId from BS_WorkFlowsLine where WorkFlowsId = {0} and AutoId not in ({1})))", autoIdInt, autoIdListStr);
            cmd.ExecuteNonQuery();
            cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineCondition where LineId in (Select AutoId from BS_WorkFlowsLine where WorkFlowsId = {0} and AutoId not in ({1}))", autoIdInt, autoIdListStr);
            cmd.ExecuteNonQuery();

            cmd.CommandText = string.Format("Delete from BS_WorkFlowsLinePoint where LineId in (select AutoId from BS_WorkFlowsLine where WorkFlowsId = {0} and AutoId not in ({1}))", autoIdInt, autoIdListStr);
            cmd.ExecuteNonQuery();
            cmd.CommandText = string.Format("Delete from BS_WorkFlowsLine where WorkFlowsId = {0} and AutoId not in ({1})", autoIdInt, autoIdListStr);
            cmd.ExecuteNonQuery();

            //删除状态节点
            autoIdListStr = dShapeAutoIdSql.Length > 0 ? dShapeAutoIdSql.Substring(0, dShapeAutoIdSql.Length - 1) : "0";
            cmd.CommandText = string.Format("Delete from BS_WorkFlowsNode where WorkFlowsId = {0} and AutoId not in ({1})", autoIdInt, autoIdListStr);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 删除流程表
        /// </summary>
        /// <param name="autoIdInt">流程图Id</param>
        public bool DeleteWorkFlows(int autoIdInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("select * from BS_WorkFlows where AutoId = {0}", autoIdInt);
                        DataTable tmpTable = new DataTable();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(tmpTable);

                        if (tmpTable.Rows.Count > 0)
                        {
                            //保存日志到日志表中
                            LogHandler.RecordLog(cmd, string.Format("删除流程图信息：流程图名称的原值为[{0}]，流程图类型的原值为[{1}]，备注的原值为[{2}]", DataTypeConvert.GetString(tmpTable.Rows[0]["WorkFlowsText"]), DataTypeConvert.GetInt(tmpTable.Rows[0]["WorkFlowsType"]), DataTypeConvert.GetString(tmpTable.Rows[0]["Remark"])));
                        }

                        cmd.CommandText = string.Format("Delete from BS_WorkFlowsTypeField where WorkFlowsId = {0}", autoIdInt);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineNotice where LineId in (Select AutoId from BS_WorkFlowsLine where WorkFlowsId = {0})", autoIdInt);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineHandle where LineId in (Select AutoId from BS_WorkFlowsLine where WorkFlowsId = {0})", autoIdInt);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineConditionList where ConditionId in (Select AutoId from BS_WorkFlowsLineCondition where LineId in (Select AutoId from BS_WorkFlowsLine where WorkFlowsId = {0}))", autoIdInt);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from BS_WorkFlowsLineCondition where LineId in (Select AutoId from BS_WorkFlowsLine where WorkFlowsId = 0)", autoIdInt);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("Delete from BS_WorkFlowsLinePoint where LineId in (Select AutoId from BS_WorkFlowsLine where WorkFlowsId = {0})", autoIdInt);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from BS_WorkFlowsLine where WorkFlowsId = {0}", autoIdInt);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from BS_WorkFlowsNode where WorkFlowsId = {0}", autoIdInt);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = string.Format("Delete from BS_WorkFlows where AutoId = {0}", autoIdInt);
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
        /// 重新生成流程图类型的字段
        /// </summary>
        /// <param name="workFlowsIdInt">流程图Id</param>
        /// <param name="orderType">流程图类型</param>
        public bool RebuildWorkFlowsTypeField(int workFlowsIdInt, int orderTypeInt)
        {
            using (SqlConnection conn = new SqlConnection(BaseSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("", conn, trans);

                        cmd.CommandText = string.Format("Delete from BS_WorkFlowsTypeField where WorkFlowsId = {0}", workFlowsIdInt);
                        cmd.ExecuteNonQuery();

                        switch(orderTypeInt)
                        {
                            case (int)WorkFlowsHandleDAO.OrderType.请购单:
                                cmd.CommandText = string.Format("Insert into BS_WorkFlowsTypeField (WorkFlowsId, FieldName, FieldText, FieldType) select {0}, ColumnName, ColumnText, AutoId from V_WorkFlows_TypeField_PrReqHead", workFlowsIdInt);
                                break;
                            case (int)WorkFlowsHandleDAO.OrderType.采购订单:
                                cmd.CommandText = string.Format("Insert into BS_WorkFlowsTypeField (WorkFlowsId, FieldName, FieldText, FieldType) select {0}, ColumnName, ColumnText, AutoId from V_WorkFlows_TypeField_OrderHead", workFlowsIdInt);
                                break;
                            case (int)WorkFlowsHandleDAO.OrderType.工单:
                                cmd.CommandText = string.Format("Insert into BS_WorkFlowsTypeField (WorkFlowsId, FieldName, FieldText, FieldType) select {0}, ColumnName, ColumnText, AutoId from V_WorkFlows_TypeField_ProductionPlan", workFlowsIdInt);
                                break;
                            default:
                                trans.Rollback();
                                return false;
                        }
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
    }
}
