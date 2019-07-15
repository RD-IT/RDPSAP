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
    public partial class FrmWorkFlowEdit : DockContent
    {
        #region 私有变量

        /// <summary>
        /// 要查询的流程图ID
        /// </summary>
        public static int queryAutoIdInt = 0;

        /// <summary>
        /// 当前查询的流程图ID
        /// </summary>
        private int currentAutoIdInt = 0;
        
        //private Dictionary<DiagramShape, string> dShapeDic_WFId = new Dictionary<DiagramShape, string>();
        //private Dictionary<DiagramConnector, int> dConnDic = new Dictionary<DiagramConnector, int>();

        private int diagramMainWidth = 1440;
        private int diagramMainHeight = 900;

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmWorkFlowModuleDAO wfDAO = new FrmWorkFlowModuleDAO();
        FrmWorkFlowEditDAO wfEditDAO = new FrmWorkFlowEditDAO();

        #endregion

        #region 构造方法

        public FrmWorkFlowEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWorkFlowEdit_Load(object sender, EventArgs e)
        {
            try
            {
                searchLookUpFlowModuleId.Properties.DataSource = wfDAO.QueryWorkFlowModule(false);
                lookUpCreator.Properties.DataSource = commonDAO.QueryUserInfo(false);
                radioHandleCate_SelectedIndexChanged(null, null);

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
        /// 窗体激活事件
        /// </summary>
        private void FrmWorkFlowEdit_Activated(object sender, EventArgs e)
        {
            try
            {
                if (queryAutoIdInt > 0)
                {
                    currentAutoIdInt = queryAutoIdInt;
                    queryAutoIdInt = 0;
                    btnRefresh_Click(null, null);
                }
                else if (queryAutoIdInt == -1)
                {
                    queryAutoIdInt = 0;
                    btnNew_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体激活事件错误。", ex);
            }
        }

        #endregion
        
        #region 工具栏事件

        /// <summary>
        /// 新增按钮事件
        /// </summary>
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = dSWorkFlow.Tables[0].NewRow();
                dSWorkFlow.Tables[0].Rows.Add(dr);
                bSWorkFlow.MoveLast();

                InitializationDiagram();

                Set_ButtonAndControl_State(false);
                textWorkFlowText.Focus();
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
                    if (bSWorkFlow.Current == null)
                        return;
                    DataRow headRow = ((DataRowView)bSWorkFlow.Current).Row;
                    if (!wfEditDAO.CheckCurrentData(DataTypeConvert.GetInt(headRow["AutoId"])))
                        return;

                    Set_ButtonAndControl_State(false);
                    textWorkFlowText.Focus();
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(this.Text + "--修改按钮事件错误。", ex);
                    textWorkFlowText.Focus();
                }
            }
            else
            {
                try
                {
                    bSWorkFlow.EndEdit();
                    DataRow headRow = ((DataRowView)bSWorkFlow.Current).Row;

                    if (textWorkFlowText.Text == "")
                    {
                        MessageHandler.ShowMessageBox("流程名称不能为空，请填写后再进行保存。");
                        textWorkFlowText.Focus();
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
                            currentAutoIdInt = DataTypeConvert.GetInt(headRow["AutoId"]);
                            break;
                        case 0:
                            return;
                    }

                    Set_ButtonAndControl_State(true);
                    btnRefresh_Click(null, null);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(this.Text + "--保存按钮事件错误。", ex);
                    textWorkFlowText.Focus();
                }
            }
        }

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableWorkFlow.Rows.Count == 0 || bSWorkFlow.Current == null)
                {
                    MessageHandler.ShowMessageBox("当前没有模块流程记录，不能进行删除。");
                    return;
                }
                DataRow headRow = ((DataRowView)bSWorkFlow.Current).Row;

                if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的记录吗？") != DialogResult.Yes)
                {
                    return;
                }
                if (wfEditDAO.DeleteWorkFlow(DataTypeConvert.GetInt(headRow["AutoId"])))
                {
                    MessageHandler.ShowMessageBox("删除成功。");
                    dSWorkFlow.Tables[0].Rows.Clear();
                    InitializationDiagram();
                    wfEditDAO.QueryWorkFlow_UpOne(dSWorkFlow.Tables[0], currentAutoIdInt);
                    if (dSWorkFlow.Tables[0].Rows.Count > 0)
                    {
                        currentAutoIdInt = DataTypeConvert.GetInt(dSWorkFlow.Tables[0].Rows[0]["AutoId"]);
                    }
                    else
                    {
                        wfEditDAO.QueryWorkFlow_DownOne(dSWorkFlow.Tables[0], currentAutoIdInt);
                        if (dSWorkFlow.Tables[0].Rows.Count > 0)
                        {
                            currentAutoIdInt = DataTypeConvert.GetInt(dSWorkFlow.Tables[0].Rows[0]["AutoId"]);
                        }
                    }
                    QueryWorkFlowAllInfo();
                }
                else
                {
                    currentAutoIdInt = DataTypeConvert.GetInt(headRow["AutoId"]);
                    btnRefresh_Click(null, null);
                }
                Set_ButtonAndControl_State(true);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                dSWorkFlow.Tables[0].Clear();
                if (currentAutoIdInt != 0)
                {
                    wfEditDAO.QueryWorkFlow(dSWorkFlow.Tables[0], currentAutoIdInt);
                }
                else
                {
                    wfEditDAO.QueryWorkFlow_LastOne(dSWorkFlow.Tables[0]);
                    if (dSWorkFlow.Tables[0].Rows.Count > 0)
                    {
                        currentAutoIdInt = DataTypeConvert.GetInt(dSWorkFlow.Tables[0].Rows[0]["AutoId"]);
                    }
                }

                QueryWorkFlowAllInfo();
                Set_ButtonAndControl_State(true);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--刷新按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 查询上一条信息事件
        /// </summary>
        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tmpTable = new DataTable();
                wfEditDAO.QueryWorkFlow_UpOne(tmpTable, currentAutoIdInt);
                if (tmpTable.Rows.Count > 0)
                {
                    dSWorkFlow.Tables[0].Rows.Clear();
                    dSWorkFlow.Tables[0].ImportRow(tmpTable.Rows[0]);
                    currentAutoIdInt = DataTypeConvert.GetInt(tmpTable.Rows[0]["AutoId"]);
                    QueryWorkFlowAllInfo();
                    Set_ButtonAndControl_State(true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询上一条信息事件错误。", ex);
            }
        }

        /// <summary>
        /// 查询下一条信息事件
        /// </summary>
        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tmpTable = new DataTable();
                wfEditDAO.QueryWorkFlow_DownOne(tmpTable, currentAutoIdInt);
                if (tmpTable.Rows.Count > 0)
                {
                    dSWorkFlow.Tables[0].Rows.Clear();
                    dSWorkFlow.Tables[0].ImportRow(tmpTable.Rows[0]);
                    currentAutoIdInt = DataTypeConvert.GetInt(tmpTable.Rows[0]["AutoId"]);
                    QueryWorkFlowAllInfo();
                    Set_ButtonAndControl_State(true);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询下一条信息事件错误。", ex);
            }
        }

        /// <summary>
        /// 设定按钮和编辑区控件的状态
        /// </summary>
        private void Set_ButtonAndControl_State(bool state)
        {
            btnNew.Enabled = state;
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
            btnUp.Enabled = state;
            btnDown.Enabled = state;
            
            textWorkFlowText.ReadOnly = state;
            textRemark.ReadOnly = state;

            //diagramMain.Enabled = !state;
            diagramMainState(!state);

            //pnlDiagramInfo.Enabled = !state;
            pnlProperty.Enabled = !state;
            if (state)
            {
                diagramMain.ClearSelection();
            }
        }

        /// <summary>
        /// 设置流程图里面所有项目的状态
        /// </summary>
        private void diagramMainState(bool state)
        {
            foreach (DiagramItem item in diagramMain.Items)
            {
                switch (item.GetType().ToString())
                {
                    case "DevExpress.XtraDiagram.DiagramConnector":
                        DiagramConnector dConn = (DiagramConnector)item;
                        dConn.CanSelect = state;
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

            diagramClipboardRibbonPageGroup1.Enabled = state;
            diagramFontRibbonPageGroup1.Enabled = state;

            diagramConnectorToolBarItem1.Enabled = state;
            diagramShapeToolSelectionBarItem1.Enabled = state;
        }

        /// <summary>
        /// 清空流程编辑区
        /// </summary>
        private void InitializationDiagram()
        {
            diagramMain.ClearSelection();
            diagramMain.Items.Clear();
            diagramMain.OptionsView.PageSize = new SizeF(diagramMainWidth, diagramMainHeight);
            diagramMain.ScrollPos = new Point(0, 0);

            //dShapeDic_WFId.Clear();
        }

        /// <summary>
        /// 查询流程图信息
        /// </summary>
        private void QueryWorkFlowAllInfo()
        {
            if (TableWorkFlow.Rows.Count == 0 || bSWorkFlow.Current == null)
            {
                InitializationDiagram();
            }
            else
            {
                InitializationDiagram();

                //dConnDic.Clear();

                Dictionary<int, DiagramShape> dShapeDic_int = new Dictionary<int, DiagramShape>();
                DataTable wfNodeTable = wfEditDAO.QueryWorkFlowNode_WorkFlowId(currentAutoIdInt);
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
                    dshape.Appearance.Name = DataTypeConvert.GetString(dr["FlowModuleId"]);
                    dshape.CanRotate = false;
                    diagramMain.Items.Add(dshape);

                    dShapeDic_int.Add(DataTypeConvert.GetInt(dr["AutoId"]), dshape);
                    //dShapeDic_WFId.Add(dshape, DataTypeConvert.GetString(dr["FlowModuleId"]));                    
                }

                DataTable wfNodeToNodeTable = wfEditDAO.QueryWorkFlowNodeToNode_WorkFlowId(currentAutoIdInt);
                foreach (DataRow dr in wfNodeToNodeTable.Rows)
                {
                    DiagramConnector dConn = new DiagramConnector();
                    dConn.Text = DataTypeConvert.GetString(dr["Condition"]);
                    dConn.CustomStyleId = DataTypeConvert.GetInt(dr["AutoId"]);

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

            int beginNode = 0;
            int endNode = 0;

            foreach (DiagramShape dshape in shapeList)
            {
                if (DataTypeConvert.GetString(dshape.Content) == "")
                {
                    MessageHandler.ShowMessageBox("节点的内容不能为空，请重新编辑。");
                    diagramMain.ClearSelection();
                    diagramMain.SelectItem(dshape);
                    textContent.Focus();
                    return false;
                }
                if (dshape.Appearance.Name == "")
                {
                    MessageHandler.ShowMessageBox("节点的业务模块不能为空，请重新编辑。");
                    diagramMain.ClearSelection();
                    diagramMain.SelectItem(dshape);
                    searchLookUpFlowModuleId.Focus();
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
                    MessageHandler.ShowMessageBox("节点的信息只能包括一个开始节点和一个结束节点，请重新编辑。");
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
                    MessageHandler.ShowMessageBox("节点的信息必须且只能包括一个开始节点和一个结束节点，请重新编辑。");
                    diagramMain.ClearSelection();
                    diagramMain.SelectItem(dshape);
                    return false;
                }
            }

            if (!(beginNode == 1 && endNode == 1))
            {
                MessageHandler.ShowMessageBox("节点的信息必须且只能包括一个开始节点和一个结束节点，请重新编辑。");
                diagramMain.ClearSelection();
                return false;
            }

            foreach (DiagramConnector dConn in connectorList)
            {
                if (dConn.BeginItem == null || dConn.EndItem == null)
                {
                    MessageHandler.ShowMessageBox("连接线两端不能为空，请重新编辑。");
                    diagramMain.ClearSelection();
                    diagramMain.SelectItem(dConn);
                    return false;
                }

                if (dConn.BeginItem == dConn.EndItem)
                {
                    MessageHandler.ShowMessageBox("连接线两端不能同时指向相同节点，请重新编辑。");
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

        #region Diagram工作区

        /// <summary>
        /// 刷新当前选择节点的属性
        /// </summary>
        private void diagramMain_SelectionChanged(object sender, DiagramSelectionChangedEventArgs e)
        {
            try
            {
                if (diagramMain.SelectedItems.Length > 0)
                {
                    //colorPickBackColor.ReadOnly = false;
                    //colorPickBackColor.Color = diagramMain.SelectedItems[0].Appearance.GetBackColor();
                    //colorPickFontColor.ReadOnly = false;
                    //colorPickFontColor.Color = diagramMain.SelectedItems[0].Appearance.ForeColor;
                    
                    int autoId = 0;
                    switch (diagramMain.SelectedItems[0].GetType().ToString())
                    {
                        case "DevExpress.XtraDiagram.DiagramConnector":
                            DiagramConnector dConn = (DiagramConnector)diagramMain.SelectedItems[0];
                            textContent.ReadOnly = true;
                            textContent.Text = "";
                            searchLookUpFlowModuleId.ReadOnly = true;
                            searchLookUpFlowModuleId.EditValue = null;
                            memoText.ReadOnly = true;
                            memoText.Text = dConn.Text;
                            btnText.Enabled = true;
                            autoId = DataTypeConvert.GetInt(dConn.CustomStyleId);

                            if (autoId > 0)
                            {
                                for (int i = 0; i < diagramMain.Items.Count; i++)
                                {
                                    if (diagramMain.Items[i].GetType().ToString() == "DevExpress.XtraDiagram.DiagramConnector")
                                    {
                                        if (diagramMain.SelectedItems[0] != diagramMain.Items[i] && autoId == DataTypeConvert.GetInt(diagramMain.Items[i].CustomStyleId))
                                        {
                                            autoId = 0;
                                            dConn.Text = "";
                                            dConn.CustomStyleId = "";
                                            break;
                                        }
                                    }
                                }
                            }

                            if (autoId > 0)
                            {
                                DataTable dConnTable = wfEditDAO.QueryWorkFlowNodeToNode_Single(autoId);
                                if (dConnTable.Rows.Count > 0)
                                {
                                    lookUpCreator.EditValue = dConnTable.Rows[0]["Creator"];
                                    dateGetTime.DateTime = DataTypeConvert.GetDateTime(dConnTable.Rows[0]["GetTime"]);
                                }
                                else
                                {
                                    lookUpCreator.ItemIndex = -1;
                                    dateGetTime.DateTime = DateTime.Now;
                                }
                            }
                            else
                            {
                                lookUpCreator.ItemIndex = -1;
                                dateGetTime.DateTime = DateTime.Now;
                            }

                            PageHandle.PageVisible = false;
                            break;
                        case "DevExpress.XtraDiagram.DiagramShape":
                            DiagramShape dshape = (DiagramShape)diagramMain.SelectedItems[0];
                            textContent.ReadOnly = false;
                            textContent.Text = dshape.Content;
                            searchLookUpFlowModuleId.ReadOnly = false;
                            //if (dShapeDic_WFId.ContainsKey(dshape))
                            //    searchLookUpFlowModuleId.EditValue = dShapeDic_WFId[dshape];
                            //else
                            //    searchLookUpFlowModuleId.EditValue = null;

                            searchLookUpFlowModuleId.EditValue = dshape.Appearance.Name;

                            memoText.ReadOnly = true;
                            memoText.Text = "";
                            btnText.Enabled = false;
                            dshape.CanRotate = false;
                            autoId = DataTypeConvert.GetInt(dshape.CustomStyleId);

                            if (autoId > 0)
                            {
                                for (int i = 0; i < diagramMain.Items.Count; i++)
                                {
                                    if (diagramMain.Items[i].GetType().ToString() == "DevExpress.XtraDiagram.DiagramShape")
                                    {
                                        if (diagramMain.SelectedItems[0] != diagramMain.Items[i]&&  autoId == DataTypeConvert.GetInt(diagramMain.Items[i].CustomStyleId))
                                        {
                                            autoId = 0;
                                            dshape.Content = "";
                                            dshape.CustomStyleId = "";
                                            dshape.Appearance.Name = "";
                                            break;
                                        }
                                    }
                                }
                            }

                            if (autoId > 0)
                            {
                                DataTable dConnTable = wfEditDAO.QueryWorkFlowNode_Single(autoId);
                                if (dConnTable.Rows.Count > 0)
                                {
                                    lookUpCreator.EditValue = dConnTable.Rows[0]["Creator"];
                                    dateGetTime.DateTime = DataTypeConvert.GetDateTime(dConnTable.Rows[0]["GetTime"]);
                                }
                                else
                                {
                                    lookUpCreator.ItemIndex = -1;
                                    dateGetTime.DateTime = DateTime.Now;
                                }
                            }
                            else
                            {
                                lookUpCreator.ItemIndex = -1;
                                dateGetTime.DateTime = DateTime.Now;
                            }

                            PageHandle.PageVisible = true;
                            PageHandle.Text = string.Format("节点【{0}】的处理人员", dshape.Content);
                            QueryNodeHandle(autoId);

                            break;
                    }
                }
                else
                {
                    //colorPickBackColor.ReadOnly = true;
                    //colorPickFontColor.ReadOnly = true;
                    textContent.ReadOnly = true;
                    textContent.Text = "";
                    searchLookUpFlowModuleId.ReadOnly = true;
                    searchLookUpFlowModuleId.EditValue = null;
                    memoText.ReadOnly = true;
                    memoText.Text = "";
                    btnText.Enabled = false;
                    lookUpCreator.EditValue = null;
                    dateGetTime.EditValue = null;

                    PageHandle.PageVisible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--刷新当前选择节点的属性错误。", ex);
            }
        }
         
        /// <summary>
        /// 禁用双击编辑控件
        /// </summary>
        private void diagramMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!btnNew.Enabled)
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
                                        btnText.Focus();
                                        break;
                                    case "DevExpress.XtraDiagram.DiagramShape":
                                        textContent.SelectAll();
                                        textContent.Focus();
                                        break;
                                }
                            }
                        };
                        Invoke(action, 1);
                    }).Start();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--禁用双击编辑控件错误。", ex);
            }
        }

        /// <summary>
        /// 禁用剪切编辑控件
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
                //else if(e.Control && (e.KeyCode == Keys.Y || e.KeyCode == Keys.Z))
                //{

                //}
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--禁用剪切编辑控件错误。", ex);
            }
        }

        #endregion

        #region Diagram的TabPage信息

        ///// <summary>
        ///// 设置选中节点的文本信息
        ///// </summary>
        //private void memoContent_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (diagramMain.SelectedItems.Length > 0)
        //        {
        //            switch (diagramMain.SelectedItems[0].GetType().ToString())
        //            {
        //                case "DevExpress.XtraDiagram.DiagramConnector":
        //                    DiagramConnector dConn = (DiagramConnector)diagramMain.SelectedItems[0];
        //                    dConn.Text = memoText.Text;
        //                    break;
        //                case "DevExpress.XtraDiagram.DiagramShape":
        //                    DiagramShape dshape = (DiagramShape)diagramMain.SelectedItems[0];
        //                    dshape.Content = memoText.Text;
        //                    break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandler.HandleException(this.Text + "--设置选中节点的文本信息错误。", ex);
        //    }
        //}

        /// <summary>
        /// 设置选中节点的内容信息
        /// </summary>
        private void textContent_Leave(object sender, EventArgs e)
        {
            try
            {
                if (diagramMain.SelectedItems.Length > 0)
                {
                    switch (diagramMain.SelectedItems[0].GetType().ToString())
                    {
                        case "DevExpress.XtraDiagram.DiagramShape":
                            DiagramShape dshape = (DiagramShape)diagramMain.SelectedItems[0];
                            dshape.Content = textContent.Text;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设置选中节点的文本信息错误。", ex);
            }
        }

        ///// <summary>
        ///// 设置选中节点的文本信息
        ///// </summary>
        private void searchLookUpFlowModuleId_Leave(object sender, EventArgs e)
        {
            try
            {
                if (diagramMain.SelectedItems.Length > 0)
                {
                    switch (diagramMain.SelectedItems[0].GetType().ToString())
                    {
                        case "DevExpress.XtraDiagram.DiagramShape":
                            DiagramShape dshape = (DiagramShape)diagramMain.SelectedItems[0];

                            //foreach (DiagramShape key in dShapeDic_WFId.Keys)
                            //{
                            //    if (key == dshape)
                            //    {
                            //        if (dShapeDic_WFId[key] == DataTypeConvert.GetString(searchLookUpFlowModuleId.EditValue))
                            //            return;
                            //    }
                            //    else
                            //    {
                            //        if (dShapeDic_WFId[key] == DataTypeConvert.GetString(searchLookUpFlowModuleId.EditValue))
                            //        {
                            //            MessageHandler.ShowMessageBox("流程图中的节点不能设置相同的业务模块，请重新操作。");
                            //            if (dShapeDic_WFId.ContainsKey(dshape))
                            //                searchLookUpFlowModuleId.EditValue = dShapeDic_WFId[dshape];
                            //            else
                            //                searchLookUpFlowModuleId.EditValue = null;
                            //            searchLookUpFlowModuleId.Focus();
                            //            return;
                            //        }
                            //    }
                            //}

                            //dshape.Content = DataTypeConvert.GetString(searchLookUpFlowModuleId.Text);
                            //if (dShapeDic_WFId.ContainsKey(dshape))
                            //    dShapeDic_WFId[dshape] = DataTypeConvert.GetString(searchLookUpFlowModuleId.EditValue);
                            //else
                            //    dShapeDic_WFId.Add(dshape, DataTypeConvert.GetString(searchLookUpFlowModuleId.EditValue));

                            dshape.Appearance.Name = DataTypeConvert.GetString(searchLookUpFlowModuleId.EditValue);

                            for (int i = 0; i < diagramMain.Items.Count; i++)
                            {
                                if (diagramMain.Items[i].GetType().ToString() == "DevExpress.XtraDiagram.DiagramConnector")
                                {
                                    DiagramConnector dConn = (DiagramConnector)diagramMain.Items[i];
                                    if (dConn.BeginItem == dshape)
                                        dConn.Text = "";
                                }
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设置选中节点的文本信息错误。", ex);
            }
        }

        /// <summary>
        /// 设定节点和节点关系的条件
        /// </summary>
        private void btnText_Click(object sender, EventArgs e)
        {
            try
            {
                if (diagramMain.SelectedItems.Length < 1)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的节点连接线后，再进行操作。");
                    return;
                }

                if (diagramMain.SelectedItems[0].GetType().ToString() != "DevExpress.XtraDiagram.DiagramConnector")
                {
                    MessageHandler.ShowMessageBox("请选择要操作的节点连接线后，再进行操作。");
                    return;
                }
                DiagramConnector dConn = (DiagramConnector)diagramMain.SelectedItems[0];

                if (dConn.BeginItem == null)
                {
                    MessageHandler.ShowMessageBox("请选择连接线的上级节点后，再进行操作。");
                    return;
                }

                if (((DiagramShape)dConn.BeginItem).Appearance.Name == "")
                {
                    MessageHandler.ShowMessageBox("请选择连接线的上级节点的业务模块后，再进行操作。");
                    diagramMain.ClearSelection();
                    diagramMain.SelectItem(dConn.BeginItem);
                    return;
                }

                string flowModuleIdStr = ((DiagramShape)dConn.BeginItem).Appearance.Name;
                if (flowModuleIdStr == "")
                {
                    MessageHandler.ShowMessageBox("请先设定连接线上级节点的业务模块后，再进行操作。");
                    diagramMain.ClearSelection();
                    diagramMain.SelectItem(dConn.BeginItem);
                    return;
                }

                FrmWorkFlowNToN_Condition.flowModuleIdStr = flowModuleIdStr;
                FrmWorkFlowNToN_Condition.oldConditionStr = dConn.Text;
                FrmWorkFlowNToN_Condition condForm = new FrmWorkFlowNToN_Condition();
                if (condForm.ShowDialog() == DialogResult.OK)
                {
                    dConn.Text = FrmWorkFlowNToN_Condition.flowModuleIdStr;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定节点和节点关系的条件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void searchLookUpFlowModuleIdView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 设定列表显示信息
        /// </summary>
        private void gridViewNodeHandle_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "NodeHandleCate")
            {
                switch (e.Value.ToString())
                {
                    case "0":
                        e.DisplayText = "操作员";
                        break;
                    case "1":
                        e.DisplayText = "权限角色";
                        break;
                }
            }
        }

        /// <summary>
        /// 查询节点处理人员表
        /// </summary>
        private void QueryNodeHandle(int autoIdInt)
        {
            dSWorkFlowNodeHandle.Tables[0].Rows.Clear();
            if (autoIdInt > 0)
                wfEditDAO.QueryWorkFlowNodeHandle(dSWorkFlowNodeHandle.Tables[0], autoIdInt);
        }

        /// <summary>
        /// 选择操作员或者权限角色
        /// </summary>
        private void radioHandleCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioHandleCate.SelectedIndex == 0)//操作员
                {
                    labHandleOwner.Text = "操作员";
                    searchLookUpHandleOwner.Properties.DataSource = commonDAO.QueryUserInfo(false);
                    searchLookUpHandleOwner.Properties.DisplayMember = "EmpName";
                    searchLookUpHandleOwner.Properties.ValueMember = "LoginId";

                    gridColRoleNo.Visible = false;
                    gridColRoleName.Visible = false;
                    gridColLoginId.Visible = true;
                    gridColEmpName.Visible = true;
                }
                else//权限角色
                {
                    labHandleOwner.Text = "权限角色";
                    searchLookUpHandleOwner.Properties.DataSource = commonDAO.QueryRole(false);
                    searchLookUpHandleOwner.Properties.DisplayMember = "RoleName";
                    searchLookUpHandleOwner.Properties.ValueMember = "RoleNo";

                    gridColLoginId.Visible = false;
                    gridColEmpName.Visible = false;
                    gridColRoleNo.Visible = true;
                    gridColRoleName.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择操作员或者权限角色错误。", ex);
            }
        }

        /// <summary>
        /// 添加节点处理人员信息
        /// </summary>
        private void btnHandleInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (diagramMain.SelectedItems.Length == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的节点。");
                    return;
                }

                if (diagramMain.SelectedItems[0].GetType().ToString() == "DevExpress.XtraDiagram.DiagramConnector")
                {
                    MessageHandler.ShowMessageBox("连接线不能登记节点处理人员信息，请重新操作。");
                    return;
                }

                string handleOwnerStr = DataTypeConvert.GetString(searchLookUpHandleOwner.EditValue);
                if (handleOwnerStr == "")
                {
                    MessageHandler.ShowMessageBox("请选择要登记的操作员或者权限角色。");
                    searchLookUpHandleOwner.Focus();
                    return;
                }

                DiagramShape dshape = (DiagramShape)diagramMain.SelectedItems[0];
                int autoIdInt = DataTypeConvert.GetInt(dshape.CustomStyleId);
                if (autoIdInt == 0)
                {
                    MessageHandler.ShowMessageBox("请先新增保存后，再编辑进行登记节点处理人员信息。");
                    return;
                }

                if (wfEditDAO.SaveWorkFlowNodeHandle(autoIdInt, radioHandleCate.SelectedIndex, DataTypeConvert.GetString(searchLookUpHandleOwner.EditValue)))
                {
                    QueryNodeHandle(autoIdInt);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--添加节点处理人员信息错误。", ex);
            }
        }

        /// <summary>
        /// 删除节点处理人员信息
        /// </summary>
        private void btnHandleDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (diagramMain.SelectedItems.Length == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的节点。");
                    return;
                }

                if (diagramMain.SelectedItems[0].GetType().ToString() == "DevExpress.XtraDiagram.DiagramConnector")
                {
                    MessageHandler.ShowMessageBox("连接线不能登记节点处理人员信息，请重新操作。");
                    return;
                }

                if (gridViewNodeHandle.GetFocusedDataRow() == null)
                {
                    MessageHandler.ShowMessageBox("请选择下面列表要删除的信息。");
                    return;
                }

                DiagramShape dshape = (DiagramShape)diagramMain.SelectedItems[0];
                int autoIdInt = DataTypeConvert.GetInt(dshape.CustomStyleId);
                
                if (wfEditDAO.DeleteWorkFlowNodeHandle(gridViewNodeHandle.GetFocusedDataRow()))
                {
                    MessageHandler.ShowMessageBox("删除节点处理人员信息成功。");
                    QueryNodeHandle(autoIdInt);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除节点处理人员信息错误。", ex);
            }
        }

        #endregion


    }
}
