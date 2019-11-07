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
    public partial class FrmProductionSchedule_Drag : DockContent
    {
        #region 私有变量

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmPBDesignBomDAO bomDAO = new FrmPBDesignBomDAO();
        FrmProductionScheduleDAO psDAO = new FrmProductionScheduleDAO();

        /// <summary>
        /// 查询的生产计划单号
        /// </summary>
        public static string queryPsNoStr = "";

        /// <summary>
        /// 操作的销售单号
        /// </summary>
        public static string salesOrderNoStr = "";

        /// <summary>
        /// 拖动Tree区域的信息
        /// </summary>
        TreeListHitInfo downHitInfo = null;

        /// <summary>
        /// 当前的生产计划单号
        /// </summary>
        private string currentPsNoStr = "";

        #endregion

        #region 构造方法

        public FrmProductionSchedule_Drag()
        {
            InitializeComponent();
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmProductionSchedule_Drag_Load(object sender, EventArgs e)
        {
            try
            {
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
        private void FrmProductionSchedule_Drag_Activated(object sender, EventArgs e)
        {
            try
            {
                if (queryPsNoStr != "")
                {
                    btnEditQueryPsNo.Text = queryPsNoStr;
                    queryPsNoStr = "";
                    btnEditQueryPsNo_ButtonClick(null, null);
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
        private void FrmProductionSchedule_Drag_Shown(object sender, EventArgs e)
        {
            //pnlMiddle.Height = (this.Height - pnltop.Height) / 2;
            //pnlLeftMiddle.Height = gridControlWWHead.Height - 17;

            dockPnlLeft.Width = SystemInfo.DragForm_LeftDock_Width;

            RefreshPSBomTreeListNode();
        }

        #endregion

        #region 左侧设计Bom区域

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
        /// 确定行号
        /// </summary>
        private void treeListDesignBom_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            ControlHandler.TreeList_CustomDrawNodeIndicator_RootNode(sender, e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void treeListDesignBom_KeyDown(object sender, KeyEventArgs e)
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
        /// 设定Bom显示的信息
        /// </summary>
        private void treeListDesignBom_GetNodeDisplayValue(object sender, GetNodeDisplayValueEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "HasLevel")
                {
                    if (DataTypeConvert.GetInt(e.Node["HasLevel"]) == 0)
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

        #region 拖出设计Bom信息TreeList

        /// <summary>
        /// 在TreeList中按下鼠标事件
        /// </summary>
        private void treeListDesignBom_MouseDown(object sender, MouseEventArgs e)
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
        private void treeListDesignBom_MouseMove(object sender, MouseEventArgs e)
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
                        foreach (TreeListNode n in treelist.GetAllCheckedNodes())
                        {
                            nodes.Add(n);
                        }

                        if (nodes.Count == 0 && treelist.FocusedNode != null)
                        {
                            string reParentStr = DataTypeConvert.GetString(treelist.FocusedNode["ReParent"]);
                            if (reParentStr == "")
                            {
                                nodes.Add(treelist.FocusedNode);
                            }
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

            bomDAO.QueryDesignBomTree(dataSet_DesignBom.Tables[0], salesOrderNoStr, 1);

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


        #endregion

        #region 右侧生产计划单登记区域

        #region 拖入

        /// <summary>
        /// 拖拽在TreeList上面
        /// </summary>
        private void treeListPSBom_DragOver(object sender, DragEventArgs e)
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
        private void treeListPSBom_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 实现拖拽设计Bom信息事件
        /// </summary>
        private void treeListPSBom_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (TableProductionSchedule.Rows.Count == 0 || bindingSource_PSchedule.Current == null)
                    return;

                if (btnEditAutoSalesOrderNo.Text != buttonEditSalesOrderNo.Text)
                {
                    MessageHandler.ShowMessageBox("设计Bom信息的销售单号必须和生产计划单的销售单号相同。");
                    return;
                }

                DataRow headRow = ((DataRowView)bindingSource_PSchedule.Current).Row;
                //if (headRow.RowState == DataRowState.Added || headRow.RowState == DataRowState.Modified || btnSave.Text == "保存")
                if(headRow==null|| btnSave.Text == "保存")
                {
                    MessageHandler.ShowMessageBox("请先保存生产计划单后，再进行Bom操作。");
                    return;
                }

                List<string> pbBomNoList = new List<string>();
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
                            pbBomNoList.Add(DataTypeConvert.GetString(node["PbBomNo"]));
                            //MessageHandler.ShowMessageBox(node["PbBomNo"].ToString());
                        }
                    }
                }

                if (pbBomNoList.Count > 0)
                {
                    decimal defValue = 1;
                    if (pbBomNoList.Count == 1)
                    {
                        foreach (TreeListNode node in treeListDesignBom.Nodes)
                        {
                            if (DataTypeConvert.GetString(node["PbBomNo"]) == pbBomNoList[0])
                            {
                                defValue = DataTypeConvert.GetDecimal(node["RemainQty"]);
                                break;
                            }
                        }

                        foreach (TreeListNode node in treeListPSBom.Nodes)
                        {
                            if (DataTypeConvert.GetString(node["PbBomNo"]) == pbBomNoList[0])
                            {
                                defValue = defValue - DataTypeConvert.GetDecimal(node["PurQty"]);
                                break;
                            }
                        }
                        if (defValue == 0)
                        {
                            MessageHandler.ShowMessageBox("剩余数量为0，不能再进行添加。");
                            return;
                        }
                    }

                    defValue = FrmInputNumber.ShowFrmInputNumber("输入数量", "增加数量", defValue);
                    if (defValue == 0)
                        return;

                    if (!CheckDragBomAmount(DataTypeConvert.GetString(headRow["PsNo"]), pbBomNoList, defValue))
                        return;

                    if (defValue != 0)
                    {
                        psDAO.ProductionSchedule_InsertBom(DataTypeConvert.GetString(headRow["PsNo"]), pbBomNoList, DataTypeConvert.GetDateTime(headRow["ReqDate"]), defValue);

                        RefreshPSBom();

                        treeListDesignBom.UncheckAll();
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--实现拖拽设计Bom信息事件错误。", ex);
            }
        }

        #endregion

        /// <summary>
        /// 新增按钮事件
        /// </summary>
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                TableProductionSchedule.Rows.Clear();
                DataRow baseRow = TableProductionSchedule.NewRow();
                TableProductionSchedule.Rows.Add(baseRow);
                bindingSource_PSchedule.MoveLast();

                TablePSBom.Clear();

                Set_ButtonEditGrid_State(false);
                buttonEditSalesOrderNo.Focus();
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
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (TableProductionSchedule.Rows.Count == 0 || bindingSource_PSchedule.Current == null)
                    return;

                if (btnSave.Text != "保存")
                {
                    DataRow headRow = ((DataRowView)bindingSource_PSchedule.Current).Row;
                    string psNoStr = DataTypeConvert.GetString(headRow["PsNo"]);
                    //if (quoDAO.CheckQuotationInfo_IsSalesOrder(null, autoQuotationNoStr))
                    //    return;

                    Set_ButtonEditGrid_State(false);
                    dateReqDate.Focus();
                }
                else
                {
                    bindingSource_PSchedule.EndEdit();
                    DataRow headRow = ((DataRowView)bindingSource_PSchedule.Current).Row;

                    if (buttonEditSalesOrderNo.Text.Trim() == "")
                    {
                        MessageHandler.ShowMessageBox("销售单号不能为空，请重新操作。");
                        buttonEditSalesOrderNo.Focus();
                        return;
                    }
                    if (dateReqDate.Text.Trim() == "")
                    {
                        MessageHandler.ShowMessageBox("需求日期不能为空，请重新操作。");
                        dateReqDate.Focus();
                        return;
                    }
                    if (dateReqDate.DateTime.Date < BaseSQL.GetServerDateTime().Date)
                    {
                        MessageHandler.ShowMessageBox("需求日期不能小于当前的日期，请重新操作。");
                        dateReqDate.Focus();
                        return;
                    }

                    int ret = psDAO.SaveProductionSchedule_Drag(headRow);
                    switch (ret)
                    {
                        case -1:

                            break;
                        case 1:

                            break;
                        case 0:
                            return;
                    }

                    currentPsNoStr = DataTypeConvert.GetString(headRow["PsNo"]);
                    btnRefresh_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--保存按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (bindingSource_PSchedule.Current != null)
                {
                    bindingSource_PSchedule.CancelEdit();
                    ((DataRowView)bindingSource_PSchedule.Current).Row.RejectChanges();

                    btnRefresh_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--取消按钮事件错误。", ex);
            }
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

                if (TableProductionSchedule.Rows.Count == 0 || bindingSource_PSchedule.Current == null)
                {
                    MessageHandler.ShowMessageBox("当前没有生产计划记录，不能进行删除。");
                    return;
                }
                DataRow headRow = ((DataRowView)bindingSource_PSchedule.Current).Row;
                string psNoStr = DataTypeConvert.GetString(headRow["PsNo"]);
                //if (quoDAO.CheckQuotationInfo_IsSalesOrder(null, autoQuotationNoStr))
                //    return;

                if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的记录吗？") != DialogResult.Yes)
                {
                    return;
                }
                int autoIdInt = DataTypeConvert.GetInt(headRow["AutoId"]);
                if (psDAO.DeleteProductionSchedule(psNoStr))
                {
                    TableProductionSchedule.Rows.Clear();
                    currentPsNoStr = "";
                    psDAO.QueryProductionSchedule_UpOne(TableProductionSchedule, autoIdInt);
                    if (TableProductionSchedule.Rows.Count > 0)
                    {
                        RefreshPSBom();
                    }
                    else
                    {
                        psDAO.QueryProductionSchedule_DownOne(TableProductionSchedule, autoIdInt);
                        RefreshPSBom();
                    }
                }
                else
                {
                    currentPsNoStr = DataTypeConvert.GetString(headRow["PsNo"]);
                    btnRefresh_Click(null, null);
                }

                if (currentPsNoStr != "")
                {
                    salesOrderNoStr = DataTypeConvert.GetString(TableProductionSchedule.Rows[0]["SalesOrderNo"]);
                    RefreshSalesOrderInfo();
                    RefreshDesignBomInfo(null);
                }

                Set_ButtonEditGrid_State(true);
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

                TableProductionSchedule.Rows.Clear();
                if (currentPsNoStr != "")
                {
                    psDAO.QueryProductionSchedule(TableProductionSchedule, currentPsNoStr);
                    RefreshPSBom();
                }
                else
                {
                    psDAO.QueryProductionSchedule_LastOne(TableProductionSchedule);
                    RefreshPSBom();
                }

                if (currentPsNoStr != "")
                {
                    salesOrderNoStr = DataTypeConvert.GetString(TableProductionSchedule.Rows[0]["SalesOrderNo"]);
                    RefreshSalesOrderInfo();
                    RefreshDesignBomInfo(null);
                }

                Set_ButtonEditGrid_State(true);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 预览按钮事件
        /// </summary>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                string psNoStr = "";
                if (bindingSource_PSchedule.Current != null)
                    psNoStr = DataTypeConvert.GetString(((DataRowView)bindingSource_PSchedule.Current).Row["PsNo"]);
                psDAO.PrintHandle(psNoStr, 1);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--预览按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 回车自动查询
        /// </summary>
        private void btnEditQueryPsNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEditQueryPsNo_ButtonClick(null, null);
            }
        }

        /// <summary>
        /// 按照生产计划单号查询生产计划单
        /// </summary>
        private void btnEditQueryPsNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (!btnEditQueryPsNo.Properties.Buttons[0].Enabled)
                    return;

                if (btnEditQueryPsNo.Text.Trim() != "")
                {
                    TableProductionSchedule.Rows.Clear();
                    psDAO.QueryProductionSchedule(TableProductionSchedule, btnEditQueryPsNo.Text.Trim());

                    RefreshPSBom();

                    if (currentPsNoStr != "")
                    {
                        salesOrderNoStr = DataTypeConvert.GetString(TableProductionSchedule.Rows[0]["SalesOrderNo"]);
                        RefreshSalesOrderInfo();
                        RefreshDesignBomInfo(null);
                    }

                    Set_ButtonEditGrid_State(true);
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--按照生产计划单号查询生产计划单错误。", ex);
            }
        }

        /// <summary>
        /// 修改选择销售订单
        /// </summary>
        private void buttonEditSalesOrderNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmSelectSalesOrder selectForm = new FrmSelectSalesOrder();
                if (selectForm.ShowDialog() == DialogResult.OK)
                {
                    salesOrderNoStr = DataTypeConvert.GetString(selectForm.gridViewSalesOrder.GetFocusedDataRow()["AutoSalesOrderNo"]);
                    if (salesOrderNoStr != "")
                    {
                        buttonEditSalesOrderNo.Text = salesOrderNoStr;
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
        /// 设定主表的默认值
        /// </summary>
        private void TableProductionSchedule_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                e.Row["CurrentDate"] = nowDate;
                e.Row["ReqDate"] = nowDate.Date.AddDays(14);
                e.Row["PsState"] = 1;
                e.Row["Creator"] = SystemInfo.user.AutoId;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定主表的默认值错误。", ex);
            }
        }

        /// <summary>
        /// 增加零件数量
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                DataRow headRow = ((DataRowView)bindingSource_PSchedule.Current).Row;
                if (headRow == null || headRow.RowState == DataRowState.Added)
                {
                    MessageHandler.ShowMessageBox("请先保存生产计划单后，再进行Bom操作。");
                    return;
                }

                List<TreeListNode> nodes = GetCheckedPSBomNodeList(true);
                if (nodes.Count == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的零件Bom的根节点信息。");
                    return;
                }

                List<string> pbBomNoList = new List<string>();
                foreach (TreeListNode node in nodes)
                {
                    pbBomNoList.Add(DataTypeConvert.GetString(node["PbBomNo"]));
                }

                
                string psNoStr = DataTypeConvert.GetString(headRow["PsNo"]);

                decimal defValue = 1;
                defValue = FrmInputNumber.ShowFrmInputNumber("输入数量", "增加数量", defValue);
                if (defValue == 0)
                    return;
                if (!CheckDragBomAmount(psNoStr, pbBomNoList, defValue))
                    return;
                if (defValue != 0)
                {
                    psDAO.ProductionSchedule_InsertBom(psNoStr, pbBomNoList, DataTypeConvert.GetDateTime(headRow["ReqDate"]), defValue);
                }

                RefreshPSBom();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--操作当前选中的信息错误。", ex);
            }
        }

        /// <summary>
        /// 删除零件信息
        /// </summary>
        private void btnDeleteBom_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                DataRow headRow = ((DataRowView)bindingSource_PSchedule.Current).Row;
                if (headRow == null || headRow.RowState == DataRowState.Added)
                {
                    MessageHandler.ShowMessageBox("请先保存生产计划单后，再进行Bom操作。");
                    return;
                }

                List<TreeListNode> nodes = GetCheckedPSBomNodeList(true);
                if (nodes.Count == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的零件Bom的根节点信息。");
                    return;
                }

                List<string> pbBomNoList = new List<string>();
                foreach (TreeListNode node in nodes)
                {
                    pbBomNoList.Add(DataTypeConvert.GetString(node["PbBomNo"]));
                }

                string psNoStr = DataTypeConvert.GetString(headRow["PsNo"]);

                if (MessageHandler.ShowMessageBox_YesNo("确认删除当前选中的生产计划单Bom信息吗？") != DialogResult.Yes)
                    return;

                if(psDAO.ProductionSchedule_Delete(psNoStr, pbBomNoList))
                {
                    MessageHandler.ShowMessageBox(string.Format("成功删除{0}条生产计划单Bom信息。", pbBomNoList.Count));
                }

                RefreshPSBom();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--操作当前选中的信息错误。", ex);
            }
        }

        /// <summary>
        /// 修改需求日期
        /// </summary>
        private void btnReqDate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                DataRow headRow = ((DataRowView)bindingSource_PSchedule.Current).Row;
                if (headRow == null || headRow.RowState == DataRowState.Added)
                {
                    MessageHandler.ShowMessageBox("请先保存生产计划单后，再进行Bom操作。");
                    return;
                }

                List<TreeListNode> nodes = GetCheckedPSBomNodeList(false);
                if (nodes.Count == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的零件Bom的子节点信息。");
                    return;
                }

                List<int> autoIdList = new List<int>();
                foreach (TreeListNode node in nodes)
                {
                    autoIdList.Add(DataTypeConvert.GetInt(node["ListAutoId"]));
                }

                string psNoStr = DataTypeConvert.GetString(headRow["PsNo"]);

                DateTime reqDate = DateTime.Now.Date;
                if (FrmInputDate.ShowFrmInputDate("输入日期", "需求日期", DateTime.Now.Date.AddDays(14), ref reqDate))
                {
                    if(reqDate.Date<BaseSQL.GetServerDateTime().Date)
                    {
                        MessageHandler.ShowMessageBox("设定的需求日期不能小于当前的日期，请重新选择。");
                        return;
                    }

                    psDAO.ProductionSchedule_BomListReqDate(psNoStr, autoIdList, reqDate);
                }

                RefreshPSBom();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--操作当前选中的信息错误。", ex);
            }
        }

        /// <summary>
        /// 生产计划单Bom信息预览  由于XtraReport打印没法打印TreeList，只能调用TreeList本身控件自己的打印了
        /// </summary>
        private void btnBomPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (treeListPSBom.Nodes.Count > 0)
                {
                    //treeListPSBom.ShowPrintPreview();

                    CompositeLink compLink = new CompositeLink(new PrintingSystem());
                    PrintableComponentLink treeListLink = new PrintableComponentLink();
                    treeListLink.Component = treeListPSBom;
                    //compLink.PaperKind = System.Drawing.Printing.PaperKind.A4;//设置纸张大小
                    System.Drawing.Printing.Margins margins = new System.Drawing.Printing.Margins(50, 50, 100, 50);
                    compLink.Margins = margins;

                    PageHeaderFooter phf = compLink.PageHeaderFooter as PageHeaderFooter;
                    phf.Header.Content.Clear();
                    phf.Header.Content.AddRange(new string[] { "", "生产计划单", "" });
                    phf.Header.Font = new System.Drawing.Font("宋体", 22, System.Drawing.FontStyle.Bold);
                    phf.Header.LineAlignment = BrickAlignment.Center;

                    phf.Footer.Content.AddRange(new string[] { "", String.Format("打印时间: {0:g}", DateTime.Now), "" });

                    Link headerLink = new Link();
                    headerLink.CreateDetailArea += new CreateAreaEventHandler(HeaderLink_CreateDetailArea);
                    compLink.Links.Add(headerLink);
                    compLink.Links.Add(treeListLink);

                    compLink.ShowRibbonPreviewDialog(treeListPSBom.LookAndFeel);                    
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--生产计划单Bom信息预览错误。", ex);
            }
        }

        /// <summary>
        /// 设定打印主单信息
        /// </summary>
        private void HeaderLink_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            TextBrick brick = new TextBrick();
            brick.BorderWidth = 0;
            brick.Text = string.Format("生产计划单号：{0}      销售单号：{1}      需求日期：{2}", currentPsNoStr, buttonEditSalesOrderNo.Text, dateReqDate.DateTime.ToString("yyyy-MM-dd"));
            brick.Rect = new RectangleF(0, 0, 600, 23);
            brick.Font = new Font("宋体", 10);
            e.Graph.DrawBrick(brick);
        }

        ///// <summary>
        ///// 操作当前选中的信息
        ///// </summary>
        //private void repBtnPSBomOpBtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    try
        //    {
        //        TreeListNode focusedNode = treeListPSBom.FocusedNode;
        //        if (focusedNode == null)
        //            return;
        //        string reParentStr = DataTypeConvert.GetString(focusedNode["ReParent"]).Trim();
        //        if (reParentStr != "")
        //            return;
        //        DataRow headRow = ((DataRowView)bindingSource_PSchedule.Current).Row;
        //        string psNoStr = DataTypeConvert.GetString(headRow["PsNo"]);
        //        List<string> pbBomNoList = new List<string>();
        //        pbBomNoList.Add(DataTypeConvert.GetString(focusedNode["PbBomNo"]));
        //        switch (e.Button.Caption)
        //        {
        //            case "增加":
        //                decimal defValue = 1;
        //                defValue = FrmInputNumber.ShowFrmInputNumber("输入数量", "增加数量", defValue);
        //                if (defValue == 0)
        //                    return;
        //                if (!CheckDragBomAmount(psNoStr, pbBomNoList, defValue))
        //                    return;
        //                if (defValue != 0)
        //                {
        //                    psDAO.ProductionSchedule_InsertBom(psNoStr, pbBomNoList, DataTypeConvert.GetDateTime(headRow["ReqDate"]), defValue);
        //                }

        //                break;
        //            case "删除":
        //                if (MessageHandler.ShowMessageBox_YesNo("确认删除当前选中的生产计划单Bom信息吗？") != DialogResult.Yes)
        //                    return;

        //                psDAO.ProductionSchedule_Delete(psNoStr, pbBomNoList);
        //                break;
        //            case "日期":
        //                DateTime reqDate=DateTime.Now.Date;
        //                if(FrmInputDate.ShowFrmInputDate("输入日期", "需求日期", DateTime.Now.Date,ref reqDate))
        //                {
        //                    List<int> autoIdList = new List<int>();
        //                    autoIdList.Add(DataTypeConvert.GetInt(focusedNode["AutoId"]));
        //                    psDAO.ProductionSchedule_BomListReqDate(autoIdList, reqDate);
        //                }
        //                break;
        //        }

        //        RefreshPSBom();
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandler.HandleException(this.Text + "--操作当前选中的信息错误。", ex);
        //    }
        //}

        ///// <summary>
        ///// 设定树的单元格显示按钮事件
        ///// </summary>
        //private void treeListPSBom_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Node == null)
        //            return;
        //        string reParentStr = DataTypeConvert.GetString(e.Node["ReParent"]).Trim();
        //        if (e.Column.FieldName == "PSBomOpBtn")
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
        ///// 设定树的显示修改事件
        ///// </summary>
        //private void treeListPSBom_ShowingEditor(object sender, CancelEventArgs e)
        //{
        //    try
        //    {
        //        TreeListNode focusedNode = treeListPSBom.FocusedNode;
        //        if (focusedNode == null)
        //            return;
        //        if (treeListPSBom.FocusedColumn.FieldName == "PSBomOpBtn")
        //        {
        //            string reParentStr = DataTypeConvert.GetString(focusedNode["ReParent"]).Trim();
        //            if (reParentStr != "")
        //                e.Cancel = true;
        //            else
        //                e.Cancel = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandler.HandleException(this.Text + "--设定树的显示修改事件错误。", ex);
        //    }
        //}

        /// <summary>
        /// 设定按钮修改区列表区的状态
        /// </summary>
        private void Set_ButtonEditGrid_State(bool state)
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
            btnPreview.Enabled = state;

            btnAdd.Enabled = state;
            btnDeleteBom.Enabled = state;
            btnReqDate.Enabled = state;
            btnBomPreview.Enabled = state;

            buttonEditSalesOrderNo.Properties.Buttons[0].Enabled = state;

            dateReqDate.ReadOnly = state;
            textPlannedText.ReadOnly = state;
            textRemark.ReadOnly = state;

            if (bindingSource_PSchedule.Current != null)
            {
                DataRow headRow = ((DataRowView)bindingSource_PSchedule.Current).Row;
                //string salesOrderNoStr = DataTypeConvert.GetString(headRow["SalesOrderNo"]);
                //bool isAdd = headRow.RowState == DataRowState.Added;
                //bool isVisible = salesOrderNoStr != "";

                buttonEditSalesOrderNo.Properties.Buttons[0].Enabled = !state && (headRow.RowState == DataRowState.Added);
            }
            else
            {
                buttonEditSalesOrderNo.Properties.Buttons[0].Enabled = false;
            }

            if (this.Controls.ContainsKey("lblEditFlag"))
            {
                //检测窗口状态：新增、修改="EDIT"，保存、取消=""
                if (state)
                {
                    ((Label)this.Controls["lblEditFlag"]).Text = "";
                }
                else
                {
                    ((Label)this.Controls["lblEditFlag"]).Text = "EDIT";
                }
            }
        }

        /// <summary>
        /// 检查拖入Bom的数量
        /// </summary>
        private bool CheckDragBomAmount(string psNoStr, List<string> pbBomNoList, decimal defValue)
        {
            //判断输入的数量是否大于了设计Bom的数量减去已经登记的数量
            foreach (string pbBomNo in pbBomNoList)
            {
                decimal designBomQty = 0;
                foreach (TreeListNode node in treeListDesignBom.Nodes)
                {
                    if (DataTypeConvert.GetString(node["PbBomNo"]) == pbBomNo)
                    {
                        designBomQty = DataTypeConvert.GetDecimal(node["RemainQty"]);
                        break;
                    }
                }

                decimal otherPSBomQty = psDAO.QueryPSBom_PurQty(pbBomNo);

                if (defValue > designBomQty - otherPSBomQty)
                {
                    MessageHandler.ShowMessageBox(string.Format("设计Bom信息中的[{0}]数量[{1}] - 已经登记生产计划单的数量[{2}] < 输入的数量[{3}]，请重新操作。", pbBomNo, designBomQty, otherPSBomQty, defValue));
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 刷新生产计划Bom信息
        /// </summary>
        private void RefreshPSBom()
        {
            TablePSBom.Rows.Clear();
            if (TableProductionSchedule.Rows.Count > 0)
            {
                currentPsNoStr = DataTypeConvert.GetString(TableProductionSchedule.Rows[0]["PsNo"]);
                psDAO.QueryPSBom(TablePSBom, currentPsNoStr);
                RefreshPSBomTreeListNode();
            }
        }

        /// <summary>
        /// 刷新树显示状态
        /// </summary>
        private void RefreshPSBomTreeListNode()
        {
            foreach (TreeListNode node in treeListPSBom.Nodes)
            {
                node.Expanded = true;
            }
        }

        /// <summary>
        /// 得到当前选中的节点列表
        /// </summary>
        /// <param name="isRoot">根节点还是子节点</param>
        private List<TreeListNode> GetCheckedPSBomNodeList(bool isRoot)
        {
            List<TreeListNode> checkNodeList = treeListPSBom.GetAllCheckedNodes();

            if (checkNodeList.Count == 0 && treeListPSBom.FocusedNode != null)
            {
                checkNodeList.Add(treeListPSBom.FocusedNode);
            }
            if (isRoot)
            {
                List<TreeListNode> rootNodeList = new List<TreeListNode>();
                foreach (TreeListNode node in checkNodeList)
                {
                    string reParentStr = DataTypeConvert.GetString(node["ReParent"]);
                    if (reParentStr == "")
                    {
                        rootNodeList.Add(node);
                    }
                }
                return rootNodeList;
            }
            else
            {
                List<TreeListNode> childNodeList = new List<TreeListNode>();
                foreach (TreeListNode node in checkNodeList)
                {
                    string reParentStr = DataTypeConvert.GetString(node["ReParent"]);
                    if (reParentStr != "")
                    {
                        childNodeList.Add(node);
                    }
                    else
                    {
                        if (DataTypeConvert.GetInt(node["HasLevel"]) == 0)
                        {
                            childNodeList.Add(node);
                        }
                    }
                }
                return childNodeList;
            }
        }

        #endregion
    }
}
