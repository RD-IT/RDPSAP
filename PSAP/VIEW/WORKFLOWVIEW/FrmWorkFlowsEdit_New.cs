using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using PSAP.DAO.BSDAO;
using PSAP.DAO.WORKFLOWDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmWorkFlowsEdit_New : DockContent
    {
        #region 私有变量

        /// <summary>
        /// 手动撤销或者重做
        /// </summary>
        bool IsRudoOrRedo = false;

        /// <summary>
        /// 流程图修改区域的宽度和高度
        /// </summary>
        private int diagramMainWidth = 1440;
        private int diagramMainHeight = 900;

        /// <summary>
        /// 是否可以编辑流程图信息
        /// </summary>
        private bool IsEditWorkFlows = true;

        /// <summary>
        /// 是否可以编辑流程图明细信息
        /// </summary>
        private bool IsEditWorkFlowsDetail = true;

        /// <summary>
        /// 是系统默认的流程图
        /// </summary>
        private bool IsDefault = false;

        FrmWorkFlowsEdit_NewDAO wfEditDAO = new FrmWorkFlowsEdit_NewDAO();

        #endregion

        #region 构造方法

        public FrmWorkFlowsEdit_New()
        {
            InitializeComponent();
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWorkFlowsEdit_New_Load(object sender, EventArgs e)
        {
            try
            {
                lookUpWorkFlowsType.Properties.DataSource = DataTypeConvert.EnumToDataTable(typeof(WorkFlowsHandleDAO.OrderType), "WorkFlowsType", "TypeId");
                lookUpNextWorkFlowsType.Properties.DataSource = DataTypeConvert.EnumToDataTable(typeof(WorkFlowsHandleDAO.NextWorkFlowsType), "WorkFlowsType", "TypeId");

                diagramCopyBarItem1.ImageUri = "copy;Colored;Size32x32";
                diagramShapeToolSelectionBarItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;

                btnRefresh_Click(null, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 捕获窗体按键输入事件
        /// </summary>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                switch (keyData)
                {
                    case Keys.F11:
                        IsEditWorkFlows = !IsEditWorkFlows;
                        if (IsEditWorkFlows)
                            IsEditWorkFlowsDetail = true;
                        Set_ButtonAndControl_State(true);
                        break;

                    case Keys.F12:
                        if (!IsEditWorkFlows)
                        {
                            IsEditWorkFlowsDetail = !IsEditWorkFlowsDetail;
                            Set_ButtonAndControl_State(true);
                        }
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                return false;
            }
        }

        #endregion

        #region 登记单树形列表事件

        /// <summary>
        /// 选择节点之前设定控件状态
        /// </summary>
        private void treeListWorkFlows_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            try
            {
                if (bSWorkFlows.Current != null)
                {
                    //if (((DataRowView)bSWorkFlows.Current).IsEdit)
                    {
                        int oldId = e.OldNode == null ? -1 : DataTypeConvert.GetInt(e.OldNode["AutoId"]);
                        DataRow dr = ((DataRowView)bSWorkFlows.Current).Row;
                        if (dr.RowState == DataRowState.Added && oldId != -1)
                        {
                            return;
                        }
                        else
                        {
                            dr.RejectChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择节点之前设定控件状态错误。", ex);
            }
        }

        /// <summary>
        /// 聚焦树节点刷新当前信息
        /// </summary>
        private void treeListWorkFlows_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (bSWorkFlows.Current != null)
                {
                    DataRow dr = ((DataRowView)bSWorkFlows.Current).Row;
                    IsDefault = DataTypeConvert.GetInt(dr["IsDefault"]) == 1;
                    if (DataTypeConvert.GetInt(dr["AutoId"]) == 0)
                    {
                        InitializationDiagram();
                    }
                    else
                    {
                        QueryWorkFlowAllInfo();
                        Set_ButtonAndControl_State(true);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--聚焦树节点刷新当前信息错误。", ex);
            }
        }

        #endregion

        #region 主登记单事件

        /// <summary>
        /// 设定主表的默认值
        /// </summary>
        private void TableWorkFlows_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            try
            {
                e.Row["Enabled"] = 1;
                e.Row["ParentAutoId"] = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定主表的默认值错误。", ex);
            }
        }

        /// <summary>
        /// 新增按钮事件
        /// </summary>
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                DataRow dr = dSWorkFlows.Tables[0].NewRow();
                dSWorkFlows.Tables[0].Rows.Add(dr);
                bSWorkFlows.MoveLast();

                InitializationDiagram();

                Set_ButtonAndControl_State(false);
                textWorkFlowsText.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--新增按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.ToString() != "保存")
            {
                try
                {
                    if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                        return;

                    if (bSWorkFlows.Current == null)
                        return;
                    DataRow headRow = ((DataRowView)bSWorkFlows.Current).Row;
                    if (DataTypeConvert.GetInt(headRow["AutoId"]) == 0)
                        return;

                    Set_ButtonAndControl_State(false);
                    textWorkFlowsText.Focus();
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(this.Text + "--修改按钮事件错误。", ex);
                    textWorkFlowsText.Focus();
                }
            }
            else
            {
                try
                {
                    if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                        return;

                    bSWorkFlows.EndEdit();
                    DataRow headRow = ((DataRowView)bSWorkFlows.Current).Row;

                    if (textWorkFlowsText.Text == "")
                    {
                        MessageHandler.ShowMessageBox("流程图名称不能为空，请填写后再进行保存。");
                        textWorkFlowsText.Focus();
                        return;
                    }

                    if (lookUpWorkFlowsType.ItemIndex == -1)
                    {
                        MessageHandler.ShowMessageBox("流程图类型不能为空，请填写后再进行保存。");
                        lookUpWorkFlowsType.Focus();
                        return;
                    }

                    if (diagramMain.IsTextEditMode)
                    {
                        MessageHandler.ShowMessageBox("请完成节点或者连接线的内容编辑后，再进行保存。");
                        return;
                    }

                    List<DiagramConnector> connectorList;
                    List<DiagramShape> shapeList;
                    if (!CheckDiagramItem(out connectorList, out shapeList))
                        return;

                    int ret = wfEditDAO.SaveWorkFlow(headRow, connectorList, shapeList);
                    switch (ret)
                    {
                        case -1:

                            break;
                        case 1:
                            btnRefresh_Click(null, null);
                            return;
                        case 0:
                            return;
                    }

                    Set_ButtonAndControl_State(true);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(this.Text + "--保存按钮事件错误。", ex);
                    textWorkFlowsText.Focus();
                }
            }
        }

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (TableWorkFlows.Rows.Count == 0 || bSWorkFlows.Current == null)
                {
                    MessageHandler.ShowMessageBox("当前没有模块流程图记录，不能进行删除。");
                    return;
                }
                DataRow headRow = ((DataRowView)bSWorkFlows.Current).Row;
                if (DataTypeConvert.GetInt(headRow["AutoId"]) == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的流程图。");
                    return;
                }

                if (DataTypeConvert.GetInt(headRow["IsDefault"]) == 1)
                {
                    MessageHandler.ShowMessageBox("系统默认的流程图不可以删除。");
                    return;
                }

                if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的记录吗？") != DialogResult.Yes)
                {
                    return;
                }
                if (wfEditDAO.DeleteWorkFlows(DataTypeConvert.GetInt(headRow["AutoId"])))
                {
                    MessageHandler.ShowMessageBox("删除成功。");
                    dSWorkFlows.Tables[0].Rows.Clear();
                    InitializationDiagram();
                }

                btnRefresh_Click(null, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 查询按钮事件
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int currentAutoIdInt = -1;
                if (bSWorkFlows.Current != null)
                    currentAutoIdInt = DataTypeConvert.GetInt(((DataRowView)bSWorkFlows.Current).Row["AutoId"]);

                dSWorkFlows.Tables[0].Clear();
                wfEditDAO.QueryWorkFlows(dSWorkFlows.Tables[0]);
                treeListWorkFlows.ExpandAll();

                if (currentAutoIdInt > 0)
                {
                    for (int i = 0; i < dSWorkFlows.Tables[0].Rows.Count; i++)
                    {
                        if (DataTypeConvert.GetInt(dSWorkFlows.Tables[0].Rows[i]["AutoId"]) == currentAutoIdInt)
                        {
                            bSWorkFlows.Position = i;
                            break;
                        }
                    }
                    currentAutoIdInt = -1;
                }

                QueryWorkFlowAllInfo();
                Set_ButtonAndControl_State(true);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 重新生成流程图类型字段
        /// </summary>
        private void btnTypeField_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (TableWorkFlows.Rows.Count == 0 || bSWorkFlows.Current == null)
                {
                    MessageHandler.ShowMessageBox("当前没有模块流程图记录，不能进行操作。");
                    return;
                }
                DataRow headRow = ((DataRowView)bSWorkFlows.Current).Row;
                if (DataTypeConvert.GetInt(headRow["AutoId"]) == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的流程图。");
                    return;
                }
                if (wfEditDAO.RebuildWorkFlowsTypeField(DataTypeConvert.GetInt(headRow["AutoId"]), DataTypeConvert.GetInt(headRow["WorkFlowsType"])))
                {
                    MessageHandler.ShowMessageBox("重新生成流程图类型字段成功。");
                }
                else
                {
                    MessageHandler.ShowMessageBox("重新生成流程图类型字段失败。");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--重新生成流程图类型字段错误。", ex);
            }
        }

        /// <summary>
        /// 下级流程信息设定
        /// </summary>
        private void btnNextSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (TableWorkFlows.Rows.Count == 0 || bSWorkFlows.Current == null)
                {
                    MessageHandler.ShowMessageBox("当前没有模块流程图记录，不能进行操作。");
                    return;
                }
                DataRow headRow = ((DataRowView)bSWorkFlows.Current).Row;
                int autoIdInt = DataTypeConvert.GetInt(headRow["AutoId"]);
                if (autoIdInt == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的流程图。");
                    return;
                }
                int nextWorkFlowsTypeInt = DataTypeConvert.GetInt(lookUpNextWorkFlowsType.EditValue);
                if (nextWorkFlowsTypeInt < 1)
                {
                    MessageHandler.ShowMessageBox("当前流程图没有设定下级流程类型，不能进行操作。");
                    return;
                }
                FrmWorkFlowsLineSet lineSetForm = new FrmWorkFlowsLineSet(autoIdInt, textWorkFlowsText.Text.Trim(), nextWorkFlowsTypeInt);
                lineSetForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--下级流程信息设定错误。", ex);
            }
        }

        /// <summary>
        /// 设定按钮和修改区控件的状态
        /// </summary>
        private void Set_ButtonAndControl_State(bool state)
        {
            if (IsEditWorkFlows)
            {
                btnNew.Enabled = state;
                btnSave.Enabled = true;
                if (state)
                {
                    btnSave.Text = "修改";

                }
                else
                {
                    btnSave.Text = "保存";
                }
                btnCancel.Enabled = !state;
                btnDelete.Enabled = state;
                btnRefresh.Enabled = state;
                btnTypeField.Enabled = state;

                textWorkFlowsText.ReadOnly = state;
                lookUpWorkFlowsType.ReadOnly = state;
                textRemark.ReadOnly = state;
                checkEnabled.ReadOnly = state;
                if(bSWorkFlows.Current != null)
                {
                    DataRow headRow = ((DataRowView)bSWorkFlows.Current).Row;
                    if (headRow.RowState == DataRowState.Added)
                        lookUpNextWorkFlowsType.ReadOnly = false;
                    else
                        lookUpNextWorkFlowsType.ReadOnly = true;
                }
                else
                    lookUpNextWorkFlowsType.ReadOnly = true;


                btnNextSet.Enabled = state;

                //diagramMain.Enabled = !state;
                diagramMainState(!state);

                //pnlDiagramInfo.Enabled = !state;
                //pnlProperty.Enabled = !state;
                if (state)
                {
                    diagramMain.ClearSelection();
                }
            }
            else
            {
                btnNew.Enabled = false;
                btnSave.Text = "修改";
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnDelete.Enabled = false;
                btnRefresh.Enabled = state;
                btnTypeField.Enabled = IsEditWorkFlowsDetail && state;

                textWorkFlowsText.ReadOnly = true;
                lookUpWorkFlowsType.ReadOnly = true;
                textRemark.ReadOnly = true;
                checkEnabled.ReadOnly = true;
                lookUpNextWorkFlowsType.ReadOnly = true;

                btnNextSet.Enabled = IsEditWorkFlowsDetail && state;

                diagramMainState(false);
            }
        }

        /// <summary>
        /// 设置流程图里面所有项目的状态
        /// </summary>
        private void diagramMainState(bool state)
        {
            if (state && IsDefault)
                state = !state;

            foreach (DiagramItem item in diagramMain.Items)
            {
                switch (item.GetType().ToString())
                {
                    case "DevExpress.XtraDiagram.DiagramConnector":
                        DiagramConnector dConn = (DiagramConnector)item;
                        dConn.CanSelect = IsEditWorkFlowsDetail;

                        dConn.CanCopy = state;
                        dConn.CanDelete = state;
                        dConn.CanMove = state;
                        dConn.CanResize = state;
                        break;
                    case "DevExpress.XtraDiagram.DiagramShape":
                        DiagramShape dShape = (DiagramShape)item;
                        dShape.CanCopy = state;
                        dShape.CanDelete = state;
                        dShape.CanMove = state;
                        dShape.CanResize = state;
                        break;
                }
            }

            if (!state)
            {
                diagramPointerToolBarItem1.Checked = true;
            }

            diagramDocumentRibbonPageGroup1.Enabled = state;
            diagramClipboardRibbonPageGroup1.Enabled = state;
            diagramFontRibbonPageGroup1.Enabled = state;

            diagramConnectorToolBarItem1.Enabled = state;
            diagramShapeToolSelectionBarItem1.Enabled = state;
        }

        /// <summary>
        /// 清空流程修改区
        /// </summary>
        private void InitializationDiagram()
        {
            diagramMain.ClearSelection();
            diagramMain.Items.Clear();

            Clipboard.Clear();

            diagramMain.OptionsView.PageSize = new SizeF(diagramMainWidth, diagramMainHeight);
            diagramMain.ScrollPos = new Point(0, 0);

            //dShapeDic_WFId.Clear();
        }

        /// <summary>
        /// 查询流程图信息
        /// </summary>
        private void QueryWorkFlowAllInfo()
        {
            if (TableWorkFlows.Rows.Count == 0 || bSWorkFlows.Current == null)
            {
                InitializationDiagram();
            }
            else
            {
                InitializationDiagram();

                //dConnDic.Clear();
                int currentAutoIdInt = DataTypeConvert.GetInt(((DataRowView)bSWorkFlows.Current).Row["AutoId"]);
                if (currentAutoIdInt == 0)
                    return;

                Dictionary<int, DiagramShape> dShapeDic_int = new Dictionary<int, DiagramShape>();
                DataTable wfNodeTable = wfEditDAO.QueryWorkFlowsNode_WorkFlowsId(currentAutoIdInt);
                foreach (DataRow dr in wfNodeTable.Rows)
                {
                    DiagramShape dshape = new DiagramShape();
                    dshape.Position = new DevExpress.Utils.PointFloat(DataTypeConvert.GetInt(dr["PositionX"]), DataTypeConvert.GetInt(dr["PositionY"]));
                    dshape.Size = new Size(DataTypeConvert.GetInt(dr["Width"]), DataTypeConvert.GetInt(dr["Height"]));
                    dshape.Appearance.BackColor = DataTypeConvert.StringToColor(DataTypeConvert.GetString(dr["BackColor"]));
                    dshape.Appearance.ForeColor = DataTypeConvert.StringToColor(DataTypeConvert.GetString(dr["ForeColor"]));
                    dshape.Appearance.Font = new Font(DataTypeConvert.GetString(dr["FontName"]), DataTypeConvert.GetInt(dr["FontSize"]));

                    dshape.Content = DataTypeConvert.GetString(dr["NodeText"]);
                    dshape.CustomStyleId = DataTypeConvert.GetInt(dr["AutoId"]);
                    //dshape.Appearance.Name = DataTypeConvert.GetString(dr["FlowModuleId"]);
                    dshape.CanRotate = false;

                    int beginNode = DataTypeConvert.GetInt(dr["BeginNode"]);
                    if (beginNode == (int)WorkFlowsHandleDAO.NodePositionType.开始节点 || beginNode == (int)WorkFlowsHandleDAO.NodePositionType.结束节点)
                    {
                        dshape.Shape = DevExpress.Diagram.Core.BasicFlowchartShapes.StartEnd;
                    }
                    dshape.MinHeight = beginNode;

                    diagramMain.Items.Add(dshape);

                    dShapeDic_int.Add(DataTypeConvert.GetInt(dr["AutoId"]), dshape);
                    //dShapeDic_WFId.Add(dshape, DataTypeConvert.GetString(dr["FlowModuleId"]));
                }

                DataTable wfNodeToNodeTable = wfEditDAO.QueryWorkFlowsLine_WorkFlowsId(currentAutoIdInt);
                DataTable linePointTable = wfEditDAO.QueryWorkFlowsLinePoint(currentAutoIdInt);

                foreach (DataRow dr in wfNodeToNodeTable.Rows)
                {
                    DiagramConnector dConn = new DiagramConnector();
                    dConn.Text = DataTypeConvert.GetString(dr["LineText"]);
                    dConn.CustomStyleId = DataTypeConvert.GetInt(dr["AutoId"]);
                    dConn.Appearance.Name = DataTypeConvert.GetString(dr["LineType"]);

                    dConn.BeginItem = dShapeDic_int[DataTypeConvert.GetInt(dr["NodeId"])];
                    dConn.EndItem = dShapeDic_int[DataTypeConvert.GetInt(dr["LevelNodeId"])];

                    dConn.BeginItemPointIndex = DataTypeConvert.GetInt(dr["BeginPointIndex"]);
                    dConn.EndItemPointIndex = DataTypeConvert.GetInt(dr["EndPointIndex"]);
                    dConn.BeginPoint = new DevExpress.Utils.PointFloat(DataTypeConvert.GetInt(dr["BeginPositionX"]), DataTypeConvert.GetInt(dr["BeginPositionY"]));
                    dConn.EndPoint = new DevExpress.Utils.PointFloat(DataTypeConvert.GetInt(dr["EndPositionX"]), DataTypeConvert.GetInt(dr["EndPositionY"]));
                    dConn.Appearance.BackColor = DataTypeConvert.StringToColor(DataTypeConvert.GetString(dr["BackColor"]));
                    dConn.Appearance.ForeColor = DataTypeConvert.StringToColor(DataTypeConvert.GetString(dr["ForeColor"]));
                    dConn.Appearance.Font = new Font(DataTypeConvert.GetString(dr["FontName"]), DataTypeConvert.GetInt(dr["FontSize"]));
                    dConn.EndArrow = DevExpress.Diagram.Core.ArrowDescriptions.Filled90;
                    dConn.Type = ConnectorType.RightAngle;

                    DataRow[] pointRows = linePointTable.Select(string.Format("LineId = {0}", DataTypeConvert.GetInt(dr["AutoId"])));
                    foreach(DataRow pRow in pointRows)
                    {
                        dConn.IntermediatePoints.Add(new DevExpress.Utils.PointFloat(DataTypeConvert.GetInt(pRow["PositionX"]), DataTypeConvert.GetInt(pRow["PositionY"])));
                    }

                    diagramMain.Items.Add(dConn);
                    
                    //dConnDic.Add(dConn, DataTypeConvert.GetInt(dr["AutoId"]));
                }
            }

            diagramMain.ScrollPos = new Point(0, 0);
        }

        /// <summary>
        /// 检查流程图的信息
        /// </summary>
        private bool CheckDiagramItem(out List<DiagramConnector> connectorList, out List<DiagramShape> shapeList)
        {
            connectorList = new List<DiagramConnector>();
            shapeList = new List<DiagramShape>();
            foreach (DiagramItem item in diagramMain.Items)
            {
                switch (item.GetType().ToString())
                {
                    case "DevExpress.XtraDiagram.DiagramConnector":
                        connectorList.Add((DiagramConnector)item);
                        break;
                    case "DevExpress.XtraDiagram.DiagramShape":
                        shapeList.Add((DiagramShape)item);
                        break;
                }
            }

            //检查信息重复的节点和连接线
            foreach (DiagramShape dshape in shapeList)
            {
                foreach (DiagramShape subdshape in shapeList)
                {
                    if (dshape == subdshape)
                        continue;
                    int dshapeId = DataTypeConvert.GetInt(dshape.CustomStyleId);
                    if (dshapeId > 0 && dshapeId == DataTypeConvert.GetInt(subdshape.CustomStyleId))
                    {
                        subdshape.CustomStyleId = null;
                        subdshape.MinHeight = 0;
                    }
                }
            }
            foreach (DiagramConnector dConn in connectorList)
            {
                foreach (DiagramConnector subConn in connectorList)
                {
                    if (dConn == subConn)
                        continue;
                    int dConnId = DataTypeConvert.GetInt(dConn.CustomStyleId);
                    if (dConnId > 0 && dConnId == DataTypeConvert.GetInt(subConn.CustomStyleId))
                    {
                        subConn.CustomStyleId = null;
                        subConn.Appearance.Name = "";
                    }
                }
            }

            int beginNode = 0;
            int endNode = 0;

            foreach (DiagramShape dshape in shapeList)
            {
                if (DataTypeConvert.GetString(dshape.Content) == "")
                {
                    MessageHandler.ShowMessageBox("节点内容不能为空，请双击节点重新修改。");
                    diagramMain.ClearSelection();
                    diagramMain.SelectItem(dshape);
                    //textContent.Focus();
                    return false;
                }

                bool isFindBegin = false;
                bool isFindEnd = false;
                foreach (DiagramConnector dc in connectorList)
                {
                    if (dc.BeginItem == dshape)
                        isFindBegin = true;
                    if (dc.EndItem == dshape)
                        isFindEnd = true;
                    if (isFindBegin && isFindEnd)
                        break;
                }

                if (isFindBegin && !isFindEnd)
                {
                    beginNode++;
                    dshape.MinHeight = 1;
                }
                else if (!isFindBegin && isFindEnd)
                {
                    endNode++;
                    dshape.MinHeight = 3;
                }
                else if (!isFindBegin && !isFindEnd)
                {
                    MessageHandler.ShowMessageBox("节点必须和其他节点相关联，请重新修改。");
                    diagramMain.ClearSelection();
                    diagramMain.SelectItem(dshape);
                    return false;
                }
                else
                {
                    dshape.MinHeight = 2;
                }

                if (beginNode > 1 || endNode > 1)
                {
                    MessageHandler.ShowMessageBox("节点的信息必须且只能包括一个开始节点和一个结束节点，请重新修改。");
                    diagramMain.ClearSelection();
                    diagramMain.SelectItem(dshape);
                    return false;
                }

                //if (dshape.Appearance.Name == "" && dshape.MinHeight != 3)
                //{
                //    MessageHandler.ShowMessageBox("节点的业务模块不能为空，请重新修改。");
                //    diagramMain.ClearSelection();
                //    diagramMain.SelectItem(dshape);
                //    //searchLookUpFlowModuleId.Focus();
                //    return false;
                //}
            }

            //if (!(beginNode == 1 && endNode == 1))
            //{
            //    MessageHandler.ShowMessageBox("节点的信息必须且只能包括一个开始节点和一个结束节点，请重新修改。");
            //    diagramMain.ClearSelection();
            //    return false;
            //}

            foreach (DiagramConnector dConn in connectorList)
            {
                if (dConn.BeginItem == null || dConn.EndItem == null)
                {
                    MessageHandler.ShowMessageBox("连接线两端不能为空，请重新修改。");
                    diagramMain.ClearSelection();
                    diagramMain.SelectItem(dConn);
                    return false;
                }

                if (dConn.BeginItem == dConn.EndItem)
                {
                    MessageHandler.ShowMessageBox("连接线两端不能同时指向相同节点，请重新修改。");
                    diagramMain.ClearSelection();
                    diagramMain.SelectItem(dConn);
                    return false;
                }
            }

            //List<DiagramShape> test = new List<DiagramShape>(dShapeDic_WFId.Keys);
            //for (int i = 0; i < dShapeDic_WFId.Count; i++)
            //{
            //    if (!diagramMain.Items.Contains(test[i]))
            //    {
            //        dShapeDic_WFId.Remove(test[i]);
            //    }
            //}

            return true;
        }

        #endregion
        
        #region 流程图区域事件

        /// <summary>
        /// 单击设定相关信息
        /// </summary>
        private void diagramMain_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!btnCancel.Enabled)
                {
                    if (IsEditWorkFlowsDetail)
                    {
                        new System.Threading.Thread(() =>
                        {
                            Action<int> action = (data) =>
                            {
                                if (diagramMain.SelectedItems.Length > 0)
                                {
                                    switch (diagramMain.SelectedItems[0].GetType().ToString())
                                    {
                                        case "DevExpress.XtraDiagram.DiagramConnector":
                                            //MessageHandler.ShowMessageBox("操作连接线设定窗体");
                                            DiagramConnector dConn = (DiagramConnector)diagramMain.SelectedItems[0];
                                            int lineIdInt = DataTypeConvert.GetInt(dConn.CustomStyleId);
                                            FrmWorkFlowsLineSet lineSetForm = new FrmWorkFlowsLineSet(lineIdInt, textWorkFlowsText.Text, dConn.Text);
                                            lineSetForm.isEditWorkFlows = IsEditWorkFlows;
                                            if (lineSetForm.ShowDialog() == DialogResult.OK)
                                            {
                                                dConn.Text = lineSetForm.textLineText.Text.Trim();
                                                dConn.Appearance.Name = DataTypeConvert.GetString(lineSetForm.lookUpLineType.EditValue);
                                            }
                                            dConn.CanSelect = false;
                                            dConn.CanSelect = true;
                                            break;
                                        case "DevExpress.XtraDiagram.DiagramShape":
                                            //MessageHandler.ShowMessageBox("状态节点设定窗体");
                                            DiagramShape dShape = (DiagramShape)diagramMain.SelectedItems[0];
                                            int nodeIdInt = DataTypeConvert.GetInt(dShape.CustomStyleId);
                                            FrmWorkFlowsNodeSet nodeSetForm = new FrmWorkFlowsNodeSet(nodeIdInt, textWorkFlowsText.Text, dShape.Content);
                                            nodeSetForm.isEditWorkFlows = IsEditWorkFlows;
                                            if (nodeSetForm.ShowDialog() == DialogResult.OK)
                                            {
                                                dShape.Content = nodeSetForm.textNodeText.Text.Trim();

                                                int beginNodeInt = DataTypeConvert.GetInt(nodeSetForm.radioBeginNode.EditValue);
                                                if (beginNodeInt == (int)WorkFlowsHandleDAO.NodePositionType.开始节点 || beginNodeInt == (int)WorkFlowsHandleDAO.NodePositionType.结束节点)
                                                {
                                                    for (int i = 0; i < diagramMain.Items.Count; i++)
                                                    {
                                                        if (diagramMain.Items[i].GetType().ToString() == "DevExpress.XtraDiagram.DiagramShape")
                                                        {
                                                            //if (((DiagramShape)diagramMain.Items[i]).Shape == DevExpress.Diagram.Core.BasicFlowchartShapes.StartEnd)
                                                            if (((DiagramShape)diagramMain.Items[i]).MinHeight == beginNodeInt)
                                                            {
                                                                ((DiagramShape)diagramMain.Items[i]).MinHeight = 0;
                                                                ((DiagramShape)diagramMain.Items[i]).Shape = DevExpress.Diagram.Core.BasicShapes.Rectangle;
                                                            }
                                                        }
                                                    }

                                                    dShape.Shape = DevExpress.Diagram.Core.BasicFlowchartShapes.StartEnd;
                                                    dShape.MinHeight = beginNodeInt;
                                                }
                                            }
                                            break;
                                    }
                                    diagramMain.ClearSelection();
                                }
                            };
                            Invoke(action, 1);
                        }).Start();
                    }
                }
                else if (IsDefault)
                {
                    new System.Threading.Thread(() =>
                    {
                        Action<int> action = (data) =>
                        {
                            if (diagramMain.SelectedItems.Length > 0)
                            {
                                diagramMain.ClearSelection();
                            }
                        };
                        Invoke(action, 1);
                    }).Start();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--单击设定相关信息错误。", ex);
            }
        }

        /// <summary>
        /// 禁用双击修改控件
        /// </summary>
        private void diagramMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!btnCancel.Enabled)
                {
                    diagramMain.Enabled = false;
                    new System.Threading.Thread(() =>
                    {
                        Action<int> action = (data) =>
                        {
                            System.Threading.Thread.Sleep(500);
                            diagramMain.Enabled = true;
                            if (diagramMain.SelectedItems.Length > 0)
                            {
                                switch (diagramMain.SelectedItems[0].GetType().ToString())
                                {
                                    case "DevExpress.XtraDiagram.DiagramConnector":
                                        //MessageHandler.ShowMessageBox("操作连接线设定窗体");
                                        break;
                                    case "DevExpress.XtraDiagram.DiagramShape":
                                        //MessageHandler.ShowMessageBox("状态节点设定窗体");
                                        break;
                                }
                            }
                        };
                        Invoke(action, 1);
                    }).Start();
                }
                else if (IsDefault)
                {
                    diagramMain.Enabled = false;
                    new System.Threading.Thread(() =>
                    {
                        Action<int> action = (data) =>
                        {
                            System.Threading.Thread.Sleep(500);
                            diagramMain.Enabled = true;
                        };
                        Invoke(action, 1);
                    }).Start();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--禁用双击修改控件错误。", ex);
            }
        }

        /// <summary>
        /// 禁用剪切修改控件
        /// </summary>
        private void diagramMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.X)
                {
                    if (diagramMain.SelectedItems.Length > 0)
                    {
                        diagramMain.SelectedItems[0].CanDelete = false;
                        new System.Threading.Thread(() =>
                        {
                            Action<int> action = (data) =>
                            {
                                System.Threading.Thread.Sleep(500);
                                diagramMain.Enabled = true;
                                if (diagramMain.SelectedItems.Length > 0)
                                {
                                    diagramMain.SelectedItems[0].CanDelete = true;
                                }
                            };
                            Invoke(action, 1);
                        }).Start();
                    }
                }
                else if (e.Control && (e.KeyCode == Keys.Y || e.KeyCode == Keys.Z))
                {
                    if (!btnCancel.Enabled)
                        IsRudoOrRedo = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--禁用剪切修改控件错误。", ex);
            }
        }

        #endregion

    }
}
