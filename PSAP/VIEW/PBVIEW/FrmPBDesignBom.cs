using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class FrmPBDesignBom : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmPBDesignBomDAO bomDAO = new FrmPBDesignBomDAO();

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
        public static string salesOrderNoStr = "";

        public FrmPBDesignBom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPBBomManagement_Load(object sender, EventArgs e)
        {
            try
            {
                searchCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(false);
                lookUpCatgName.Properties.DataSource = commonDAO.QueryPartNoCatg(true);
                lookUpCatgName.ItemIndex = 0;
                lookUpBrand.Properties.DataSource = commonDAO.QueryBrandCatg(true);
                lookUpBrand.ItemIndex = 0;

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
        private void FrmPBDesignBom_Activated(object sender, EventArgs e)
        {
            try
            {
                if (salesOrderNoStr != "")
                {
                    RefreshSalesOrderInfo();
                    RefreshDesignBomInfo(null);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体激活事件错误。", ex);
            }
        }

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
                    treeListBom.FocusedNode.ExpandAll();
                    treeListBom.FocusedNode.Expanded = false;
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
                QueryPartsCodeInfo();
                QueryBOMInfo();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询零件信息和BOM信息错误。", ex);
            }
        }

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
                        RefreshDesignBomInfo(null);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择销售订单错误。", ex);
            }
        }

        /// <summary>
        /// 刷新信息
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (salesOrderNoStr != "")
            {
                RefreshSalesOrderInfo();
                RefreshDesignBomInfo(null);
            }
        }

        /// <summary>
        /// 设定Bom显示的信息
        /// </summary>
        private void treeListDesignBom_GetNodeDisplayValue(object sender, GetNodeDisplayValueEventArgs e)
        {
            try
            {
                if (e.Column == colHasLevel)
                {
                    if (DataTypeConvert.GetInt(e.Node[colHasLevel]) == 0)
                        e.Value = "零件";
                    else
                        e.Value = "BOM";
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

        ///// <summary>
        ///// 设定树的单元格显示按钮事件
        ///// </summary>
        //private void treeListDesignBom_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Node == null)
        //            return;
        //        string reParentStr = DataTypeConvert.GetString(e.Node["ReParent"]).Trim();
        //        if (e.Column.FieldName == "OpBtn")
        //        {
        //            ButtonEditViewInfo buttonEditViewInfo = (ButtonEditViewInfo)e.EditViewInfo;
        //            if (buttonEditViewInfo.RightButtons.Count > 0)
        //            {
        //                if (reParentStr == "")
        //                {
        //                    buttonEditViewInfo.RightButtons[0].State = DevExpress.Utils.Drawing.ObjectState.Normal;
        //                    buttonEditViewInfo.RightButtons[1].State = DevExpress.Utils.Drawing.ObjectState.Normal;
        //                }
        //                else
        //                {
        //                    buttonEditViewInfo.RightButtons[0].State = DevExpress.Utils.Drawing.ObjectState.Disabled;
        //                    buttonEditViewInfo.RightButtons[1].State = DevExpress.Utils.Drawing.ObjectState.Disabled;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandler.HandleException(this.Text + "--设定树的单元格显示按钮事件错误。", ex);
        //    }
        //}

        ///// <summary>
        ///// 设定树的显示编辑事件
        ///// </summary>
        //private void treeListDesignBom_ShowingEditor(object sender, CancelEventArgs e)
        //{
        //    try
        //    {
        //        TreeListNode focusedNode = treeListDesignBom.FocusedNode;
        //        if (focusedNode == null)
        //            return;
        //        string reParentStr = DataTypeConvert.GetString(focusedNode["ReParent"]).Trim();
        //        if (reParentStr != "")
        //            e.Cancel = true;
        //        else
        //            e.Cancel = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandler.HandleException(this.Text + "--设定树的显示编辑事件错误。", ex);
        //    }
        //}

        /// <summary>
        /// 操作当前选中的信息
        /// </summary>
        private void repButtonOpBtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //try
            //{
            //    TreeListNode focusedNode = treeListDesignBom.FocusedNode;
            //    if (focusedNode == null)
            //        return;
            //    string reParentStr = DataTypeConvert.GetString(focusedNode["ReParent"]).Trim();
            //    if (reParentStr != "")
            //        return;               

            //    switch (e.Button.Caption)
            //    {
            //        case "增加":
            //            List<string> codeFileNameList = new List<string>();
            //            codeFileNameList.Add(DataTypeConvert.GetString(focusedNode["CodeFileName"]));
            //            float qty = FrmPBDesignBom_InputNumber.Show_FrmPBDesignBom_InputNumber("输入增加数量", "增加数量", 1, salesOrderNoStr, codeFileNameList,false);
            //            if (qty != 0)
            //            {
            //                bomDAO.SaveDesignBom(salesOrderNoStr, codeFileNameList, qty);
            //                RefreshDesignBomInfo();
            //            }

            //            break;
            //        case "删除":
            //            if (MessageHandler.ShowMessageBox_YesNo("确认删除当前选中的设计Bom信息吗？") != DialogResult.Yes)
            //                return;
            //            string pbBomNoStr = DataTypeConvert.GetString(focusedNode["PbBomNo"]);
            //            bomDAO.DeleteDesignBom(salesOrderNoStr, pbBomNoStr);
            //            RefreshDesignBomInfo();
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ExceptionHandler.HandleException(this.Text + "--操作当前选中的信息错误。", ex);
            //}
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
        }

        /// <summary>
        /// 刷新设计Bom信息
        /// </summary>
        private void RefreshDesignBomInfo(TreeListNode focusedNode)
        {
            dataSet_DesignBom.Tables[0].Rows.Clear();
            //DataTable designBomTable = bomDAO.QueryDesignBomManagement(salesOrderNoStr);
            //if(designBomTable.Rows.Count>0)
            //{
            //string pbBomNoStr = DataTypeConvert.GetString(designBomTable.Rows[0]["PbBomNo"]);
            bomDAO.QueryDesignBomTree(dataSet_DesignBom.Tables[0], salesOrderNoStr, -1);
            //}

            if (focusedNode != null)
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

        /// <summary>
        /// 查询零件信息
        /// </summary>
        private void QueryPartsCodeInfo()
        {
            dSPartsCode.Tables[0].Rows.Clear();
            string codeFileNameStr = DataTypeConvert.GetString(searchCodeFileName.EditValue) != "" ? DataTypeConvert.GetString(searchCodeFileName.EditValue) : "";
            string codeNameStr = textCodeName.Text.Trim();
            string catgNameStr = lookUpCatgName.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpCatgName.EditValue) : "";
            string brandStr = lookUpBrand.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpBrand.EditValue) : "";

            bomDAO.QueryPartsCode(dSPartsCode.Tables[0], codeFileNameStr, codeNameStr, catgNameStr, brandStr);
        }

        /// <summary>
        /// 查询BOM信息
        /// </summary>
        private void QueryBOMInfo()
        {
            string codeFileNameStr = DataTypeConvert.GetString(searchCodeFileName.EditValue);
            string codeNameStr = textCodeName.Text.Trim();
            string catgNameStr = lookUpCatgName.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpCatgName.EditValue) : "";
            string brandStr = lookUpBrand.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpBrand.EditValue) : "";
            if (codeFileNameStr != "")
            {
                treeListBom.DataSource = bomDAO.QueryBomInfo_Single(codeFileNameStr);
            }
            else
            {
                DataTable bomInfoTable = bomDAO.QueryBomInfo_OnlyRoot(codeFileNameStr, codeNameStr, catgNameStr, brandStr);
                if (bomInfoTable.Rows.Count == 1)
                {
                    bomDAO.QueryBomInfo_OnlyLeaf(bomInfoTable, DataTypeConvert.GetString(bomInfoTable.Rows[0]["CodeFileName"]));
                }
                treeListBom.DataSource = bomInfoTable;
            }
            treeListBom.ExpandAll();
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

                List<string> codeFileNameList = new List<string>();
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
                            codeFileNameList.Add(DataTypeConvert.GetString(node["CodeFileName"]));
                            //MessageBox.Show(node["CodeFileName"].ToString());
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
                            //MessageBox.Show(drs[0]["CodeFileName"].ToString().ToString());
                            codeFileNameList.Add(DataTypeConvert.GetString(dr["CodeFileName"]));
                        }
                    }
                }

                if (codeFileNameList.Count > 0)
                {
                    float qty = FrmPBDesignBom_InputNumber.Show_FrmPBDesignBom_InputNumber("输入增加数量", "增加数量", 1, salesOrderNoStr, codeFileNameList, true);
                    if (qty != 0)
                    {
                        bomDAO.SaveDesignBom(salesOrderNoStr, codeFileNameList, qty);
                        RefreshDesignBomInfo(null);
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
                TreeListNode focusedNode = OperateDesignBomCheck();
                if (focusedNode == null)
                    return;

                if (DataTypeConvert.GetInt(focusedNode["IsUse"]) == 0)
                {
                    MessageHandler.ShowMessageBox("当前选中的设计Bom信息已经停用，不可以操作。");
                    return;
                }

                List<string> codeFileNameList = new List<string>();
                codeFileNameList.Add(DataTypeConvert.GetString(focusedNode["CodeFileName"]));
                float qty = FrmPBDesignBom_InputNumber.Show_FrmPBDesignBom_InputNumber("输入增加数量", "增加数量", 1, salesOrderNoStr, codeFileNameList, false);
                if (qty != 0)
                {
                    bomDAO.SaveDesignBom(salesOrderNoStr, codeFileNameList, qty);
                    RefreshDesignBomInfo(focusedNode);
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
                }
                RefreshDesignBomInfo(null);
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

                bomDAO.StopDesignBom(salesOrderNoStr, pbBomNoList);
                RefreshDesignBomInfo(treeListDesignBom.FocusedNode);
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

                bomDAO.RecoverDesignBom(salesOrderNoStr, pbBomNoList);
                RefreshDesignBomInfo(treeListDesignBom.FocusedNode);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--恢复当前选中设计Bom信息错误。", ex);
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

        
    }
}
