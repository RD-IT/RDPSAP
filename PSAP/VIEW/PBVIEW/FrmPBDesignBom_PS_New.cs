using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using PSAP.DAO.BSDAO;
using PSAP.DAO.PBDAO;
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
    public partial class FrmPBDesignBom_PS_New : DockContent
    {
        #region 私有变量

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmPBDesignBom_PS_NewDAO bomDAO = new FrmPBDesignBom_PS_NewDAO();

        /// <summary>
        /// 要查询的销售单号
        /// </summary>
        public static string QuerySalesOrderNoStr = "";

        /// <summary>
        /// 要查询的设计Bom的ID
        /// </summary>
        public static int QueryPBBomListAutoId = 0;

        /// <summary>
        /// 拖动Grid区域的信息
        /// </summary>
        GridHitInfo GriddownHitInfo = null;

        /// <summary>
        /// 拖动Tree区域的信息
        /// </summary>
        TreeListHitInfo downHitInfo = null;

        /// <summary>
        /// 操作的销售单号
        /// </summary>
        private string salesOrderNoStr = "";

        #endregion

        #region 构造方法

        public FrmPBDesignBom_PS_New()
        {
            InitializeComponent();
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPBDesignBom_PS_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable catgNameTable_t = commonDAO.QueryPartNoCatg(true);

                //searchCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(true);
                ControlCommonInit ctlInit = new ControlCommonInit();
                ctlInit.SearchLookUpEdit_PartsCode(searchCodeFileName, true,"AutoId","CodeFileName");
                searchCodeFileName.EditValue = 0;

                lookUpCatgName.Properties.DataSource = catgNameTable_t;
                lookUpCatgName.ItemIndex = 0;
                lookUpBrand.Properties.DataSource = commonDAO.QueryBrandCatg(true);
                lookUpBrand.ItemIndex = 0;

                repLookUpMaterial.DataSource = commonDAO.QueryMaterialSelectLib(false);
                repLookUpCatgName.DataSource = catgNameTable_t;

                btnEditAutoSalesOrderNo.Focus();
                btnEditAutoSalesOrderNo.SelectAll();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 窗体激活事件
        /// </summary>
        private void FrmPBDesignBom_PS_Activated(object sender, EventArgs e)
        {
            try
            {
                if (QuerySalesOrderNoStr != "")
                {
                    salesOrderNoStr = QuerySalesOrderNoStr;
                    RefreshSalesOrderInfo();
                    RefreshDesignBomInfo(null,false);
                    if (QueryPBBomListAutoId > 0)
                    {
                        foreach (TreeListNode node in treeListDesignBom.Nodes)
                        {
                            if (SearchFocusedNode(node, QueryPBBomListAutoId))
                            {
                                break;
                            }
                        }
                        QueryPBBomListAutoId = 0;
                    }
                    QuerySalesOrderNoStr = "";
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体激活事件错误。", ex);
            }
        }

        /// <summary>
        /// 窗体显示事件
        /// </summary>
        private void FrmPBDesignBom_PS_Shown(object sender, EventArgs e)
        {
            try
            {                
                dockPnlLeft.Width = SystemInfo.DragForm_LeftDock_Width;
                pnlPS.Width = pnlMiddle.Width / 2;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体显示事件错误。", ex);
            }
        }
        
        /// <summary>
        /// 递归查询设计Bom信息树定位节点
        /// </summary>
        private bool SearchFocusedNode(TreeListNode node, int queryBomListAutoId)
        {
            if (DataTypeConvert.GetInt(node["ReId"]) == queryBomListAutoId)
            {
                treeListDesignBom.FocusedNode = node;
                return true;
            }
            foreach (TreeListNode subNode in node.Nodes)
            {
                if (SearchFocusedNode(subNode, queryBomListAutoId))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 左侧查询基础资料区域

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewBomMateriel_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void treeListBom_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            ControlHandler.TreeList_CustomDrawNodeIndicator_RootNode(sender, e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewPartsCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ControlHandler.GridView_GetFocusedCellDisplayText_KeyDown(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--获取单元格显示的信息错误。", ex);
            }
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void treeListBom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ControlHandler.TreeList_GetFocusedCellDisplayText_KeyDown(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--获取单元格显示的信息错误。", ex);
            }
        }

        /// <summary>
        /// 双击刷新BOM信息
        /// </summary>
        private void treeListBom_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeListNode node = treeListBom.FocusedNode;
                if (node.Nodes.Count == 0 && DataTypeConvert.GetString(node["ParentCodeFileName"]) == "")
                {
                    bomDAO.QueryBomInfo_OnlyLeaf((DataTable)treeListBom.DataSource, DataTypeConvert.GetString(node["CodeFileName"]));

                    treeListBom.RefreshDataSource();
                    treeListBom.FocusedNode.ExpandAll();
                    treeListBom.FocusedNode.Expanded = false;

                    treeListBom.Refresh();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击刷新BOM信息错误。", ex);
            }
        }

        /// <summary>
        /// 查询零件信息和BOM信息
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                QueryPartsCodeInfo();
                QueryBOMInfo();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询零件信息和BOM信息错误。", ex);
            }
        }

        /// <summary>
        /// 查询零件信息
        /// </summary>
        private void QueryPartsCodeInfo()
        {
            dSPartsCode.Tables[0].Rows.Clear();
            //string codeFileNameStr = DataTypeConvert.GetString(searchCodeFileName.EditValue) != "" ? DataTypeConvert.GetString(searchCodeFileName.EditValue) : "";
            int codeIdInt = DataTypeConvert.GetInt(searchCodeFileName.EditValue);
            string codeNameStr = textCodeName.Text.Trim();
            string catgNameStr = lookUpCatgName.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpCatgName.EditValue) : "";
            string brandStr = lookUpBrand.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpBrand.EditValue) : "";

            bomDAO.QueryPartsCode(dSPartsCode.Tables[0], codeIdInt, codeNameStr, catgNameStr, brandStr);
        }

        /// <summary>
        /// 查询BOM信息
        /// </summary>
        private void QueryBOMInfo()
        {
            string codeFileNameStr = DataTypeConvert.GetString(searchCodeFileName.Text);
            string codeNameStr = textCodeName.Text.Trim();
            string catgNameStr = lookUpCatgName.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpCatgName.EditValue) : "";
            string brandStr = lookUpBrand.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpBrand.EditValue) : "";
            if (codeFileNameStr != "全部" && codeFileNameStr != "")
            {
                treeListBom.DataSource = bomDAO.QueryBomInfo_Single(codeFileNameStr);
            }
            else
            {
                codeFileNameStr = "";
                DataTable bomInfoTable = bomDAO.QueryBomInfo_OnlyRoot(codeFileNameStr, codeNameStr, catgNameStr, brandStr);
                if (bomInfoTable.Rows.Count == 1)
                {
                    bomDAO.QueryBomInfo_OnlyLeaf(bomInfoTable, DataTypeConvert.GetString(bomInfoTable.Rows[0]["CodeFileName"]));
                }
                treeListBom.DataSource = bomInfoTable;
            }
            treeListBom.ExpandAll();
        }

        #endregion

        #region 右侧查询销售订单区域

        /// <summary>
        /// 选择销售订单
        /// </summary>
        private void btnEditAutoSalesOrderNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmSelectSalesOrder selectForm = new FrmSelectSalesOrder();
                if (selectForm.ShowDialog() == DialogResult.OK)
                {
                    salesOrderNoStr = DataTypeConvert.GetString(selectForm.gridViewSalesOrder.GetFocusedDataRow()["AutoSalesOrderNo"]);
                    if (salesOrderNoStr != "")
                    {
                        RefreshSalesOrderInfo();
                        RefreshDesignBomInfo(null, false);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择销售订单错误。", ex);
            }
        }

        /// <summary>
        /// 销售订单号手动输入后检测
        /// </summary>
        private void btnEditAutoSalesOrderNo_Leave(object sender, EventArgs e)
        {
            try
            {
                salesOrderNoStr = btnEditAutoSalesOrderNo.Text.Trim();
                RefreshSalesOrderInfo();
                RefreshDesignBomInfo(null, false);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--销售订单号手动输入后检测错误。", ex);
            }
        }

        /// <summary>
        /// 刷新销售订单信息和设计Bom信息
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (salesOrderNoStr != "")
                {
                    RefreshSalesOrderInfo();
                    RefreshDesignBomInfo(null, false);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--刷新销售订单信息和设计Bom信息错误。", ex);
            }
        }

        /// <summary>
        /// 刷新销售订单信息
        /// </summary>
        private void RefreshSalesOrderInfo()
        {
            DataTable salesOrderTable = bomDAO.QuerySalesOrder(salesOrderNoStr);
            if (salesOrderTable.Rows.Count > 0)
            {
                btnEditAutoSalesOrderNo.Text = DataTypeConvert.GetString(salesOrderTable.Rows[0]["AutoSalesOrderNo"]);
                textProjectNo.Text = DataTypeConvert.GetString(salesOrderTable.Rows[0]["ProjectNo"]);
                textProjectName.Text = DataTypeConvert.GetString(salesOrderTable.Rows[0]["ProjectName"]);
            }
            else
            {
                btnEditAutoSalesOrderNo.Text = "";
                textProjectNo.Text = "";
                textProjectName.Text = "";
            }
        }

        /// <summary>
        /// 刷新设计Bom信息
        /// </summary>
        private void RefreshDesignBomInfo(TreeListNode focusedNode, bool checkAllNode)
        {
            dataSet_DesignBom.Tables[0].Rows.Clear();
            dataSet_PSBom.Tables[0].Rows.Clear();
            spinRemainQty.Value = 0;
            //DataTable designBomTable = bomDAO.QueryDesignBomManagement(salesOrderNoStr);
            //if(designBomTable.Rows.Count>0)
            //{
            //string pbBomNoStr = DataTypeConvert.GetString(designBomTable.Rows[0]["PbBomNo"]);
            bomDAO.QueryDesignBomTree(dataSet_DesignBom.Tables[0], salesOrderNoStr, -1);
            //}

            if (focusedNode != null)
            {
                if (checkAllNode)
                {
                    foreach (TreeListNode node in treeListDesignBom.Nodes)
                    {
                        if (SearchHistoryNode(focusedNode, node))
                            break;
                    }
                }
                else
                {
                    foreach (TreeListNode node in treeListDesignBom.Nodes)
                    {
                        if (DataTypeConvert.GetString(node["ReId"]) == DataTypeConvert.GetString(focusedNode["ReId"]))
                        {
                            treeListDesignBom.FocusedNode = node;
                            break;
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// 递归找寻历史的节点
        /// </summary>
        private bool SearchHistoryNode(TreeListNode desNode, TreeListNode parentNode)
        {
            if (DataTypeConvert.GetString(desNode["ReId"]) == DataTypeConvert.GetString(parentNode["ReId"]))
            {
                treeListDesignBom.FocusedNode = parentNode;
                return true;
            }
            else
            {
                foreach(TreeListNode node in parentNode.Nodes)
                {
                    if (SearchHistoryNode(desNode, node))
                        return true;

                }
                return false;
            }
        }

        #endregion

        #region 右侧设计Bom登记区域

        /// <summary>
        /// 设定Bom显示的信息
        /// </summary>
        private void treeListDesignBom_GetNodeDisplayValue(object sender, GetNodeDisplayValueEventArgs e)
        {
            try
            {
                if (e.Column == colHasLevel)
                {
                    int value = DataTypeConvert.GetInt(e.Node[colHasLevel]);
                    switch(value)
                    {
                        case 0:
                            e.Value = "零件";
                            break;
                        case 2:
                            e.Value = "工序";
                            break;
                        default:
                            e.Value = "BOM";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定Bom显示的信息错误。", ex);
            }
        }

        /// <summary>
        /// 设定TreeList控件是否显示选项
        /// </summary>
        private void treeListDesignBom_CustomDrawNodeCheckBox(object sender, CustomDrawNodeCheckBoxEventArgs e)
        {
            try
            {
                if (e.Node == null)
                    return;
                string reParentStr = DataTypeConvert.GetString(e.Node["ReParent"]);
                if (reParentStr == "")
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定TreeList控件是否显示选项错误。", ex);
            }
        }

        /// <summary>
        /// 设定TreeList控件是否可以选中
        /// </summary>
        private void treeListDesignBom_BeforeCheckNode(object sender, CheckNodeEventArgs e)
        {
            try
            {
                if (e.Node == null)
                    return;
                string reParentStr = DataTypeConvert.GetString(e.Node["ReParent"]);
                if (reParentStr == "")
                    e.CanCheck = true;
                else
                    e.CanCheck = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定TreeList控件是否可以选中错误。", ex);
            }
        }

        /// <summary>
        /// 聚焦设计Bom树刷新信息
        /// </summary>
        private void treeListDesignBom_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                RefreshPSBomInfo();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--聚焦设计Bom树刷新信息错误。", ex);
            }
        }

        #region 拖出

        #region 拖出零件信息Grid

        /// <summary>
        /// 在GridView中按下鼠标事件
        /// </summary>
        private void gridViewPartsCode_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                GriddownHitInfo = null;
                GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));

                if (Control.ModifierKeys != Keys.None)
                    return;
                if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
                {
                    GriddownHitInfo = hitInfo;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--在GridView中按下鼠标事件错误。", ex);
            }
        }

        /// <summary>
        /// 在GridView中移动鼠标事件
        /// </summary>
        private void gridViewPartsCode_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.Button == MouseButtons.Left && GriddownHitInfo != null)
                {
                    Size dragSize = SystemInformation.DragSize;
                    Rectangle dragRect = new Rectangle(new Point(GriddownHitInfo.HitPoint.X - dragSize.Width / 2,
                        GriddownHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                    if (!dragRect.Contains(new Point(e.X, e.Y)))
                    {
                        int[] rowint = view.GetSelectedRows();

                        if (rowint.Length == 0)
                            rowint = new int[] { view.FocusedRowHandle };

                        List<DataRow> row = new List<DataRow>();
                        foreach (int i in rowint)
                        {
                            row.Add(view.GetDataRow(i));
                        }
                        if (row != null && row.Count > 0)
                        {
                            view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                            GriddownHitInfo = null;
                            DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--在GridView中按下鼠标事件错误。", ex);
            }
        }

        #endregion

        #region 拖出Bom信息TreeList

        /// <summary>
        /// 在TreeList中按下鼠标事件
        /// </summary>
        private void treeListBom_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                TreeList treelist = sender as TreeList;
                downHitInfo = null;
                TreeListHitInfo hitInfo = treelist.CalcHitInfo(new Point(e.X, e.Y));

                if (Control.ModifierKeys != Keys.None)
                    return;
                if (e.Button == MouseButtons.Left)
                {
                    downHitInfo = hitInfo;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--在TreeList中按下鼠标事件错误。", ex);
            }
        }

        /// <summary>
        /// 在TreeList中移动鼠标事件
        /// </summary>
        private void treeListBom_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                TreeList treelist = sender as TreeList;
                if (e.Button == MouseButtons.Left && downHitInfo != null)
                {
                    if (treelist.Selection.Count == 0)
                        return;
                    else
                    {
                        string parentCFN = DataTypeConvert.GetString(treelist.Selection[0]["ParentCodeFileName"]);
                        if (parentCFN != "")
                        {
                            MessageHandler.ShowMessageBox("拖拽选项只能选择主Bom信息，不可以拖拽Bom的明细信息。");
                            return;
                        }
                    }
                    Size dragSize = SystemInformation.DragSize;
                    Rectangle dragRect = new Rectangle(new Point(downHitInfo.MousePoint.X - dragSize.Width / 2,
                        downHitInfo.MousePoint.Y - dragSize.Height / 2), dragSize);

                    if (!dragRect.Contains(new Point(e.X, e.Y)))
                    {
                        List<TreeListNode> nodes = new List<TreeListNode>();
                        foreach (TreeListNode n in treelist.Selection)
                        {
                            nodes.Add(n);
                        }
                        if (nodes.Count > 0)
                        {
                            treelist.DoDragDrop(nodes, DragDropEffects.Move);
                            downHitInfo = null;
                            DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--在TreeList中移动鼠标事件错误。", ex);
            }
        }

        #endregion

        #endregion

        #region 拖入

        /// <summary>
        /// 拖拽在TreeList上面
        /// </summary>
        private void treeListDesignBom_DragOver(object sender, DragEventArgs e)
        {
            TreeList treelist = sender as TreeList;
            if (treelist != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        /// <summary>
        /// 拖拽进入到TreeList控件
        /// </summary>
        private void treeListDesignBom_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 实现拖拽Bom或者零件信息事件
        /// </summary>
        private void treeListDesignBom_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (salesOrderNoStr == "")
                {
                    MessageHandler.ShowMessageBox("请先选择要操作的销售订单。");
                    return;
                }

                //List<int> codeIdList = new List<int>();
                //List<string> codeFileNameList = new List<string>();
                Dictionary<int, string> codeIdList = new Dictionary<int, string>();
                List<TreeListNode> nodes = e.Data.GetData(typeof(List<TreeListNode>)) as List<TreeListNode>;
                if (nodes != null)//拖拽Bom信息
                {
                    //TreeList grid = sender as TreeList;
                    //DataTable table = grid.DataSource as DataTable;

                    if (nodes != null && nodes.Count > 0)
                    {
                        foreach (TreeListNode node in nodes)
                        {
                            //treeList1.Nodes.Add(node);
                            codeIdList.Add(DataTypeConvert.GetInt(node["PCAutoId"]), DataTypeConvert.GetString(node["CodeFileName"]));
                            //MessageHandler.ShowMessageBox(node["CodeFileName"].ToString());
                        }
                    }
                }
                else//拖拽零件信息
                {
                    List<DataRow> drs = e.Data.GetData(typeof(List<DataRow>)) as List<DataRow>;
                    if (drs != null)
                    {
                        foreach (DataRow dr in drs)
                        {
                            //MessageHandler.ShowMessageBox(drs[0]["CodeFileName"].ToString().ToString());
                            codeIdList.Add(DataTypeConvert.GetInt(dr["AutoId"]), DataTypeConvert.GetString(dr["CodeFileName"]));
                        }
                    }
                }

                if (codeIdList.Count > SystemInfo.FormDragDropMaxRecordCount)
                {
                    MessageHandler.ShowMessageBox(string.Format("拖拽记录的最大数量为{0}，请重新操作。", SystemInfo.FormDragDropMaxRecordCount));
                    return;
                }

                if (codeIdList.Count > 0)
                {
                    int buyTypeInt = 1;
                    float qty = FrmPBDesignBom_InputNumberAndType.Show_FrmPBDesignBom_InputNumberAndType("输入增加数量和购买方式", "增加数量", 1, salesOrderNoStr, codeIdList, true, ref buyTypeInt);
                    if (qty != 0)
                    {
                        if (bomDAO.SaveDesignBom(salesOrderNoStr, codeIdList, qty, buyTypeInt))
                            RefreshDesignBomInfo(null, false);
                    }
                    gridViewPartsCode.ClearSelection();
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--实现拖拽Bom或者零件信息事件错误。", ex);
            }
        }


        #endregion

        /// <summary>
        /// 增加当前选中设计Bom信息数量
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                TreeListNode focusedNode = OperateDesignBomCheck();
                if (focusedNode == null)
                    return;

                if (DataTypeConvert.GetInt(focusedNode["IsUse"]) == 0)
                {
                    MessageHandler.ShowMessageBox("当前选中的设计Bom信息已经停用，不可以操作。");
                    return;
                }

                Dictionary<int, string> codeIdList = new Dictionary<int, string>();
                codeIdList.Add(DataTypeConvert.GetInt(focusedNode["CodeId"]), DataTypeConvert.GetString(focusedNode["CodeFileName"]));
                int buyTypeInt = 1;
                float qty = FrmPBDesignBom_InputNumberAndType.Show_FrmPBDesignBom_InputNumberAndType("输入增加数量", "增加数量", 1, salesOrderNoStr, codeIdList, false,ref buyTypeInt);
                if (qty != 0)
                {
                    if (bomDAO.SaveDesignBom(salesOrderNoStr, codeIdList, qty, buyTypeInt))
                        RefreshDesignBomInfo(focusedNode, false);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--增加当前选中设计Bom信息数量错误。", ex);
            }
        }

        /// <summary>
        /// 删除当前选中设计Bom信息
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                List<TreeListNode> nodeList = OperateMultiDesignBomCheck();
                if (nodeList.Count == 0)
                    return;

                string pbBomNoStr = "";
                List<string> pbBomNoList = new List<string>();
                foreach (TreeListNode node in nodeList)
                {
                    if (DataTypeConvert.GetInt(node["IsUse"]) == 0)
                    {
                        MessageHandler.ShowMessageBox("当前选中的设计Bom信息已经停用，不可以重复操作。");
                        return;
                    }
                    pbBomNoStr += string.Format("{0},", DataTypeConvert.GetString(node["PbBomNo"]));
                    pbBomNoList.Add(DataTypeConvert.GetString(node["PbBomNo"]));
                }

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确认删除当前选中的设计Bom信息[{0}]吗？", pbBomNoStr.Substring(0, pbBomNoStr.Length - 1))) != DialogResult.Yes)
                    return;

                int countInt = bomDAO.DeleteDesignBom(salesOrderNoStr, pbBomNoList);
                if (countInt > 0)
                {
                    MessageHandler.ShowMessageBox(string.Format("成功删除{0}条设计Bom信息。", countInt));
                    RefreshDesignBomInfo(null, false);
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除当前选中设计Bom信息错误。", ex);
            }
        }

        /// <summary>
        /// 停用当前选中设计Bom信息
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                List<TreeListNode> nodeList = OperateMultiDesignBomCheck();
                if (nodeList.Count == 0)
                    return;

                string pbBomNoStr = "";
                List<string> pbBomNoList = new List<string>();
                foreach (TreeListNode node in nodeList)
                {
                    if (DataTypeConvert.GetInt(node["IsUse"]) == 0)
                    {
                        MessageHandler.ShowMessageBox("当前选中的设计Bom信息已经停用，不可以重复操作。");
                        return;
                    }
                    pbBomNoStr += string.Format("{0},", DataTypeConvert.GetString(node["PbBomNo"]));
                    pbBomNoList.Add(DataTypeConvert.GetString(node["PbBomNo"]));
                }

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确认停用当前选中的设计Bom信息[{0}]吗？", pbBomNoStr.Substring(0, pbBomNoStr.Length - 1))) != DialogResult.Yes)
                    return;

                if (bomDAO.StopDesignBom(salesOrderNoStr, pbBomNoList))
                    RefreshDesignBomInfo(treeListDesignBom.FocusedNode, false);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--停用当前选中设计Bom信息错误。", ex);
            }
        }

        /// <summary>
        /// 恢复当前选中设计Bom信息
        /// </summary>
        private void btnRecover_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                List<TreeListNode> nodeList = OperateMultiDesignBomCheck();
                if (nodeList.Count == 0)
                    return;

                string pbBomNoStr = "";
                List<string> pbBomNoList = new List<string>();
                foreach (TreeListNode node in nodeList)
                {
                    if (DataTypeConvert.GetInt(node["IsUse"]) == 1)
                    {
                        MessageHandler.ShowMessageBox("当前选中的设计Bom信息正在使用，不可以重复操作。");
                        return;
                    }
                    pbBomNoStr += string.Format("{0},", DataTypeConvert.GetString(node["PbBomNo"]));
                    pbBomNoList.Add(DataTypeConvert.GetString(node["PbBomNo"]));
                }

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确认恢复当前选中的设计Bom信息[{0}]吗？", pbBomNoStr.Substring(0, pbBomNoStr.Length - 1))) != DialogResult.Yes)
                    return;

                if (bomDAO.RecoverDesignBom(salesOrderNoStr, pbBomNoList))
                    RefreshDesignBomInfo(treeListDesignBom.FocusedNode, false);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--恢复当前选中设计Bom信息错误。", ex);
            }
        }

        /// <summary>
        /// 预览当前设计Bom信息
        /// </summary>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (treeListDesignBom.Nodes.Count > 0)
                {
                    //treeListDesignBom.ShowPrintPreview();                    

                    CompositeLink compLink = new CompositeLink(new PrintingSystem());
                    PrintableComponentLink treeListLink = new PrintableComponentLink();
                    treeListLink.Component = treeListDesignBom;
                    compLink.PaperKind = System.Drawing.Printing.PaperKind.A4;//设置纸张大小
                    System.Drawing.Printing.Margins margins = new System.Drawing.Printing.Margins(50, 50, 100, 50);
                    compLink.Margins = margins;

                    PageHeaderFooter phf = compLink.PageHeaderFooter as PageHeaderFooter;
                    phf.Header.Content.Clear();
                    phf.Header.Content.AddRange(new string[] { "", "设计Bom登记单", "" });
                    phf.Header.Font = new System.Drawing.Font("宋体", 22, System.Drawing.FontStyle.Bold);
                    phf.Header.LineAlignment = BrickAlignment.Center;

                    phf.Footer.Content.AddRange(new string[] { "", String.Format("打印时间: {0:g}", DateTime.Now), "" });

                    Link headerLink = new Link();
                    headerLink.CreateDetailArea += new CreateAreaEventHandler(HeaderLink_CreateDetailArea);
                    compLink.Links.Add(headerLink);
                    compLink.Links.Add(treeListLink);

                    compLink.ShowRibbonPreviewDialog(treeListDesignBom.LookAndFeel);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--预览当前设计Bom信息错误。", ex);
            }
        }

        /// <summary>
        /// 设定打印主单信息
        /// </summary>
        private void HeaderLink_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            TextBrick brick = new TextBrick();
            brick.BorderWidth = 0;
            brick.Text = string.Format("销售单号：{0}   项目号：{1}   项目名称：{2}", btnEditAutoSalesOrderNo.Text, textProjectNo.Text, textProjectName.Text);
            brick.Rect = new RectangleF(0, 0, 600, 23);
            brick.Font = new Font("宋体", 10);
            e.Graph.DrawBrick(brick);
        }

        /// <summary>
        /// 设定零件工序信息
        /// </summary>
        private void btnWorkProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                TreeListNode focusedNode = treeListDesignBom.FocusedNode;
                if (focusedNode == null)
                    return;

                if (DataTypeConvert.GetInt(focusedNode["IsUse"]) == 0)
                {
                    MessageHandler.ShowMessageBox("当前选中的制作Bom信息已经停用，不可以操作。");
                    return;
                }
                if (DataTypeConvert.GetInt(focusedNode["IsMaterial"]) == 2)
                {
                    MessageHandler.ShowMessageBox("当前选中的制作Bom信息是工序信息，不可以再进行工序信息登记。");
                    return;
                }
                int autoIdInt = DataTypeConvert.GetInt(focusedNode["ReId"]);
                FrmListDesignBomWorkProcess dbWorkProcess = new FrmListDesignBomWorkProcess();
                FrmListDesignBomWorkProcess.designBomListAutoId = autoIdInt;
                if (dbWorkProcess.ShowDialog() == DialogResult.OK)
                {
                    RefreshDesignBomInfo(focusedNode, true);
                    treeListDesignBom.FocusedNode.Expanded = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定零件工序信息错误。", ex);
            }
        }

        /// <summary>
        /// 显示所有分节点
        /// </summary>
        private void btnExpand_Click(object sender, EventArgs e)
        {
            treeListDesignBom.ExpandAll();
        }

        /// <summary>
        /// 隐藏所有分节点
        /// </summary>
        private void btnCollapse_Click(object sender, EventArgs e)
        {
            treeListDesignBom.CollapseAll();
        }

        /// <summary>
        /// 选择制作Bom节点弹出右击菜单
        /// </summary>
        private void treeListDesignBom_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    TreeListHitInfo hitInfo = (sender as TreeList).CalcHitInfo(new Point(e.X, e.Y));
                    treeListDesignBom.Selection.Set(hitInfo.Node);
                    treeListDesignBom.FocusedNode = hitInfo.Node;

                    TreeListHitInfo hInfo = this.treeListDesignBom.CalcHitInfo(new Point(e.X, e.Y));
                    if (hInfo.HitInfoType == HitInfoType.Cell) //在单元格上右击了
                    {
                        int IsMaterial = DataTypeConvert.GetInt(treeListDesignBom.FocusedNode["IsMaterial"]);
                        if (IsMaterial == 2)
                        {
                            barBtnInsertWorkProcess.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barBtnDeleteWorkProcess.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barBtnPrReq.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                        else
                        {
                            barBtnInsertWorkProcess.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barBtnDeleteWorkProcess.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barBtnPrReq.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }

                        popupMenuDBom.ShowPopup(Control.MousePosition);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择制作Bom节点弹出右击菜单错误。", ex);
            }
        }

        /// <summary>
        /// 右击菜单新增工序信息
        /// </summary>
        private void barBtnInsertWorkProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnWorkProcess_Click(null, null);
        }

        /// <summary>
        /// 右击菜单删除工序信息
        /// </summary>
        private void barBtnDeleteWorkProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                TreeListNode focusedNode = treeListDesignBom.FocusedNode;
                if (focusedNode == null)
                    return;

                if (DataTypeConvert.GetInt(focusedNode["IsUse"]) == 0)
                {
                    MessageHandler.ShowMessageBox("当前选中的制作Bom信息已经停用，不可以操作。");
                    return;
                }
                if (DataTypeConvert.GetInt(focusedNode["IsMaterial"]) != 2)
                {
                    MessageHandler.ShowMessageBox("当前选中的制作Bom信息是非工序信息，不可以删除。");
                    return;
                }                

                int autoIdInt = DataTypeConvert.GetInt(focusedNode["ReId"]);
                if (bomDAO.Delete_WorkProcess(autoIdInt))
                {
                    MessageHandler.ShowMessageBox("删除工序信息成功。");
                    RefreshDesignBomInfo(focusedNode.ParentNode,true);
                    treeListDesignBom.FocusedNode.Expanded = true;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--右击菜单删除工序信息错误。", ex);
            }
        }

        /// <summary>
        /// 查询生成计划相关联的请购单
        /// </summary>
        private void barBtnPrReq_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow focusedRow = gridViewPSBom.GetFocusedDataRow();
                if (focusedRow == null || DataTypeConvert.GetString(focusedRow["PrReqNo"]) == "")
                    return;

                string formNameStr = "FrmPrReq";
                if (!commonDAO.QueryUserFormPower(formNameStr))
                    return;

                string prReqNoStr = DataTypeConvert.GetString(focusedRow["PrReqNo"]);
                FrmPrReq.queryPrReqNo = prReqNoStr;
                FrmPrReq.queryListAutoId = 0;
                ViewHandler.ShowRightWindow(formNameStr);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询生成计划相关联的请购单错误。", ex);
            }
        }

        /// <summary>
        /// 生产计划生成请购单信息
        /// </summary>
        private void btnToPr_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                TreeListNode focusedNode = OperateDesignBomCheck();
                if (focusedNode == null)
                    return;

                if (DataTypeConvert.GetInt(focusedNode["IsUse"]) == 0)
                {
                    MessageHandler.ShowMessageBox("当前选中的设计Bom信息已经停用，不可以操作。");
                    return;
                }

                FrmPSBomToPrReq.salesOrderNoStr = btnEditAutoSalesOrderNo.Text;
                FrmPSBomToPrReq.projectNoStr = textProjectNo.Text;
                FrmPSBomToPrReq.pbBomNoStr = DataTypeConvert.GetString(focusedNode["PbBomNo"]);
                FrmPSBomToPrReq.bomListAutoIdInt = 0;

                if (new FrmPSBomToPrReq().ShowDialog() == DialogResult.OK)
                {
                    RefreshDesignBomInfo(treeListDesignBom.FocusedNode, true);
                    treeListDesignBom_FocusedNodeChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--生产计划生成请购单信息错误。", ex);
            }
        }

        /// <summary>
        /// 操作设计Bom检测
        /// </summary>
        private TreeListNode OperateDesignBomCheck()
        {
            TreeListNode focusedNode = treeListDesignBom.FocusedNode;
            if (focusedNode == null)
            {
                MessageHandler.ShowMessageBox("请选择要操作的设计Bom信息。");
                return null;
            }
            string reParentStr = DataTypeConvert.GetString(focusedNode["ReParent"]).Trim();
            if (reParentStr != "")
            {
                MessageHandler.ShowMessageBox("要操作的设计Bom信息必须是根节点信息。");
                return null;
            }

            return focusedNode;
        }

        /// <summary>
        /// 操作设计Bom的多个检测
        /// </summary>
        private List<TreeListNode> OperateMultiDesignBomCheck()
        {
            List<TreeListNode> nodeList = new List<TreeListNode>();
            foreach (TreeListNode node in treeListDesignBom.GetAllCheckedNodes())
            {
                string reParentStr = DataTypeConvert.GetString(node["ReParent"]).Trim();
                if (reParentStr == "")
                {
                    nodeList.Add(node);
                }
            }

            if (nodeList.Count == 0)
            {
                //MessageHandler.ShowMessageBox("请选择要操作的设计Bom信息中的根节点信息。");

                TreeListNode focusedNode = OperateDesignBomCheck();
                if (focusedNode != null)
                    nodeList.Add(focusedNode);
            }
            return nodeList;
        }

        /// <summary>
        /// 刷新生产计划Bom信息
        /// </summary>
        private void RefreshPSBomInfo()
        {
            dataSet_PSBom.Tables[0].Rows.Clear();
            if (treeListDesignBom.FocusedNode != null)
            {
                spinRemainQty.Value = DataTypeConvert.GetDecimal(treeListDesignBom.FocusedNode["RemainQty"]);
                int reId = DataTypeConvert.GetInt(treeListDesignBom.FocusedNode["ReId"]);
                if (radioType.SelectedIndex == 1)
                {
                    bomDAO.QueryProductionScheduleBom(dataSet_PSBom.Tables[0], salesOrderNoStr, reId);
                }
                else
                {
                    bomDAO.QueryProductionScheduleBom_HaveChildren(dataSet_PSBom.Tables[0], salesOrderNoStr, reId);
                }
            }
        }

        #endregion

        #region 右侧生产计划登记区域

        /// <summary>
        /// 设定计划事件
        /// </summary>
        private void btnPlan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                TreeListMultiSelection NodeList = treeListDesignBom.Selection;
                if (NodeList.Count == 1)
                {
                    TreeListNode focusedNode = treeListDesignBom.FocusedNode;
                    if (focusedNode == null)
                    {
                        MessageHandler.ShowMessageBox("请选择要设定生产计划的设计Bom信息。");
                        return;
                    }
                    int isUse = DataTypeConvert.GetInt(focusedNode["IsUse"]);
                    if (isUse == 0)
                    {
                        MessageHandler.ShowMessageBox("设计Bom已经停用，不可以设定生产计划。");
                        return;
                    }

                    int autoId = DataTypeConvert.GetInt(focusedNode["ReId"]);
                    FrmProductionScheduleBom_InputSingle.bomListAutoId = autoId;
                    FrmProductionScheduleBom_InputSingle.psBomAutoId = 0;
                    FrmProductionScheduleBom_InputSingle psBomForm = new FrmProductionScheduleBom_InputSingle();
                    if (psBomForm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshDesignBomInfo(treeListDesignBom.FocusedNode, true);
                        RefreshPSBomInfo();
                    }
                }
                else
                {
                    if (NodeList.Count == 0)
                    {
                        MessageHandler.ShowMessageBox("请选择要设定生产计划的设计Bom信息。");
                        return;
                    }
                    List<int> bomListAutoIdList = new List<int>();
                    foreach (TreeListNode node in NodeList)
                    {
                        bomListAutoIdList.Add(DataTypeConvert.GetInt(node["ReId"]));
                    }

                    FrmProductionScheduleBom_InputMulti multiPSBomForm = new FrmProductionScheduleBom_InputMulti();
                    if (multiPSBomForm.ShowDialog() == DialogResult.OK)
                    {
                        //int isAll = DataTypeConvert.GetInt(multiPSBomForm.radioType.EditValue);
                        double remainQty = DataTypeConvert.GetDouble(multiPSBomForm.spinRemainQty.Value);
                        DateTime planDate = multiPSBomForm.datePlanDate.DateTime.Date;
                        if (bomDAO.SaveMultiProductionScheduleBom(bomListAutoIdList, 0, planDate, remainQty))
                        {
                            RefreshDesignBomInfo(treeListDesignBom.FocusedNode, true);
                            RefreshPSBomInfo();
                            ClearTreeListSelection_FocusedNode();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定计划事件错误。", ex);
            }
        }

        /// <summary>
        /// 修改生产计划信息
        /// </summary>
        private void btnAlterPSBom_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                DataRow dr = gridViewPSBom.GetFocusedDataRow();
                if (dr == null)
                {
                    MessageHandler.ShowMessageBox("请选择要修改的生产计划Bom信息。");
                    return;
                }
                if (DataTypeConvert.GetString(dr["PrReqNo"]) != "")
                {
                    MessageHandler.ShowMessageBox("当前修改的生产计划信息已经生成请购单，不可以进行操作。");
                    return;
                }

                FrmProductionScheduleBom_InputSingle.bomListAutoId = DataTypeConvert.GetInt(dr["BomListAutoId"]);
                FrmProductionScheduleBom_InputSingle.psBomAutoId = DataTypeConvert.GetInt(dr["AutoId"]);
                FrmProductionScheduleBom_InputSingle psBomForm = new FrmProductionScheduleBom_InputSingle();
                if (psBomForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshDesignBomInfo(treeListDesignBom.FocusedNode, true);
                    RefreshPSBomInfo();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击查询明细错误。", ex);
            }
        }

        /// <summary>
        /// 删除生产计划Bom信息
        /// </summary>
        private void btnDeleteBom_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int[] rowint = gridViewPSBom.GetSelectedRows();
                if (rowint.Length == 0)
                {
                    if (gridViewPSBom.GetFocusedDataRow() == null)
                    {
                        MessageHandler.ShowMessageBox("请选择要删除的生产计划Bom信息。");
                        return;
                    }
                    rowint = new int[] { gridViewPSBom.FocusedRowHandle };
                }

                List<int> psBomAutoIdList = new List<int>();
                foreach (int i in rowint)
                {
                    psBomAutoIdList.Add(DataTypeConvert.GetInt(gridViewPSBom.GetDataRow(i)["AutoId"]));

                    if (DataTypeConvert.GetString(gridViewPSBom.GetDataRow(i)["PrReqNo"]) != "")
                    {
                        MessageHandler.ShowMessageBox("当前选中的生产计划信息已经生成请购单，不可以进行操作。");
                        return;
                    }
                }
                if (psBomAutoIdList.Count == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要删除的生产计划Bom信息。");
                    return;
                }

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定删除当前选中的{0}条生产计划Bom信息吗？", psBomAutoIdList.Count)) != DialogResult.Yes)
                {
                    return;
                }

                if (bomDAO.DeleteProductionScheduleBom(psBomAutoIdList))
                {
                    RefreshDesignBomInfo(treeListDesignBom.FocusedNode, true);
                    RefreshPSBomInfo();
                    MessageHandler.ShowMessageBox(string.Format("删除{0}条生产计划Bom信息成功。", psBomAutoIdList.Count));
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除生产计划Bom信息错误。", ex);
            }
        }

        /// <summary>
        /// 改变当前查询生产计划的方式
        /// </summary>
        private void radioType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshPSBomInfo();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--改变当前查询生产计划的方式错误。", ex);
            }
        }

        /// <summary>
        /// 双击修改生产计划信息
        /// </summary>
        private void gridViewPSBom_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    btnAlterPSBom_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击修改生产计划信息错误。", ex);
            }
        }

        /// <summary>
        /// 点击生产计划信息列表事件
        /// </summary>
        private void gridViewPSBom_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    GridView view = sender as GridView;
                    GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
                    gridViewPSBom.FocusedRowHandle = hitInfo.RowHandle;
                    if (gridViewPSBom.GetFocusedDataRow() == null || DataTypeConvert.GetString(gridViewPSBom.GetFocusedDataRow()["PrReqNo"]) == "")
                        return;

                    barBtnInsertWorkProcess.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barBtnDeleteWorkProcess.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barBtnPrReq.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    popupMenuDBom.ShowPopup(Control.MousePosition);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--点击生产计划信息列表事件错误。", ex);
            }
        }

        /// <summary>
        /// 设定显示的信息
        /// </summary>
        private void gridViewPSBom_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IsBuy")
            {
                switch (e.Value.ToString())
                {
                    case "0":
                        e.DisplayText = "不购买";
                        break;
                    case "1":
                        e.DisplayText = "购买";
                        break;
                }
            }
        }

        /// <summary>
        /// 清空树的所有选择，默认选择当前节点
        /// </summary>
        private void ClearTreeListSelection_FocusedNode()
        {
            TreeListNode focusedNode = treeListDesignBom.FocusedNode;
            treeListDesignBom.Selection.Clear();
            treeListDesignBom.FocusedNode = focusedNode;
            treeListDesignBom.Selection.Add(focusedNode);
        }

        #endregion

    }
}
