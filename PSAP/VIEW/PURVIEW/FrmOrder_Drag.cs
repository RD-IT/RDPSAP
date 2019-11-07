using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using PSAP.DAO.PURDAO;
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
    public partial class FrmOrder_Drag : DockContent
    {
        #region 私有变量

        FrmOrderDAO orderDAO = new FrmOrderDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmPrReqApplyDAO applyDAO = new FrmPrReqApplyDAO();

        /// <summary>
        /// 主表聚焦的行号
        /// </summary>
        int headFocusedLineNo = 0;

        /// <summary>
        /// 查询的采购单号
        /// </summary>
        public static string queryOrderHeadNo = "";

        /// <summary>
        /// 查询的明细AutoId
        /// </summary>
        public static int queryListAutoId = 0;

        /// <summary>
        /// 查询的请购单号
        /// </summary>
        public static string queryPrReqNo = "";

        /// <summary>
        /// 只有选择列改变行状态的时候
        /// </summary>
        bool onlySelectColChangeRowState = false;

        /// <summary>
        /// 拖动区域的信息
        /// </summary>
        GridHitInfo GriddownHitInfo = null;

        /// <summary>
        /// 修改锁
        /// </summary>
        private bool modifyLock = false;

        /// <summary>
        /// 明细表的修改锁
        /// </summary>
        private bool subLock = false;

        #endregion

        #region 构造方法

        public FrmOrder_Drag()
        {
            InitializeComponent();
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            try
            {
                //ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd, checkAll });
                ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd });

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateOrderDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateOrderDateEnd.DateTime = nowDate.Date;
                datePlanDateBegin.DateTime = nowDate.Date;
                datePlanDateEnd.DateTime = nowDate.Date.AddDays(SystemInfo.OrderQueryDate_DateIntervalDays);
                checkPlanDate.Checked = false;

                DataTable departmentTable_f = commonDAO.QueryDepartment(false);
                DataTable purCategoryTable_f = commonDAO.QueryPurCategory(false);

                lookUpReqDep.Properties.DataSource = commonDAO.QueryDepartment(true);
                lookUpReqDep.ItemIndex = 0;
                lookUpPurCategory.Properties.DataSource = commonDAO.QueryPurCategory(true);
                lookUpPurCategory.ItemIndex = 0;
                searchLookUpBussinessBaseNo.Properties.DataSource = commonDAO.QueryBussinessBaseInfo(true);
                searchLookUpBussinessBaseNo.Text = "全部";

                ControlCommonInit ctlInit = new ControlCommonInit();
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpApprover);
                searchLookUpApprover.EditValue = null;
                ctlInit.RepositoryItemSearchLookUpEdit_PartsCode(repSearchCodeFileName, "CodeFileName", "CodeFileName");
                ctlInit.RepositoryItemSearchLookUpEdit_ProjectList(repSearchProjectNo,"ProjectNo", "ProjectNo");
                ctlInit.SearchLookUpEdit_ProjectList(searchLookUpProjectNo, true);
                searchLookUpProjectNo.Text = "全部";
                ctlInit.ComboBoxEdit_OrderState_Submit(comboBoxReqState);
                comboBoxReqState.SelectedIndex = 0;

                repLookUpReqDep.DataSource = departmentTable_f;
                repLookUpPurCategory.DataSource = purCategoryTable_f;
                //repSearchProjectNo.DataSource = projectListTable_f;
                repSearchBussinessBaseNo.DataSource = commonDAO.QueryBussinessBaseInfo(false);
                //repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);
                repLookUpPayTypeNo.DataSource = commonDAO.QueryPayType(false);
                repLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;

                //repSearchCodeFileName.DataSource = partsCodeTable_f;

                repLookUpCodeId.DataSource = repSearchCodeFileName.DataSource;

                dateReqDateBegin.DateTime = dateOrderDateBegin.DateTime;
                dateReqDateEnd.DateTime = dateOrderDateEnd.DateTime;
                //searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(true);
                //searchLookUpProjectNo.Text = "全部";

                repLookUpPrReqReqDep.DataSource = departmentTable_f;
                repLookUpPrReqPurCategory.DataSource = purCategoryTable_f;
                repSearchPrReqProjectNo.DataSource = repSearchProjectNo.DataSource;
                repItemLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;

                if (textCommon.Text == "")
                {
                    orderDAO.QueryOrderHead(dataSet_Order.Tables[0], "", "", "", "", "", "", "", 0, 0, -1, "", true);
                    orderDAO.QueryOrderList(dataSet_Order.Tables[1], "", true);
                    orderDAO.QueryPRPO_Relation(dataSet_Order.Tables[2], "", true);
                }

                if (SystemInfo.DisableProjectNo)
                {
                    btnPrReqQuery.Location = new Point(243, 13);
                    pnlLeftTop.Height = 80;

                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    gridColuProjectNo.Visible = false;
                    gridColuStnNo.Visible = false;
                    colProjectNo.Visible = false;
                    colStnNo.Visible = false;
                    colProjectNo1.Visible = false;
                    colStnNo1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 窗体激活事件
        /// </summary>
        private void FrmOrder_Activated(object sender, EventArgs e)
        {
            try
            {
                if (queryOrderHeadNo != "")
                {
                    textCommon.Text = queryOrderHeadNo;
                    queryOrderHeadNo = "";
                    lookUpReqDep.ItemIndex = 0;
                    lookUpPurCategory.ItemIndex = 0;
                    searchLookUpBussinessBaseNo.Text = "全部";
                    comboBoxReqState.SelectedIndex = 0;
                    searchLookUpCreator.EditValue = 0;
                    searchLookUpApprover.EditValue = null;
                    checkPlanDate.Checked = false;

                    dataSet_Order.Tables[0].Clear();
                    dataSet_Order.Tables[1].Clear();
                    dataSet_Order.Tables[2].Clear();
                    headFocusedLineNo = 0;
                    orderDAO.QueryOrderHead(dataSet_Order.Tables[0], "", "", "", "", "", "", "", 0, 0, -1, textCommon.Text, false);
                    SetButtonAndColumnState(false);

                    if (dataSet_Order.Tables[0].Rows.Count > 0)
                    {
                        dateOrderDateBegin.DateTime = DataTypeConvert.GetDateTime(dataSet_Order.Tables[0].Rows[0]["OrderHeadDate"]).Date;
                        dateOrderDateEnd.DateTime = dateOrderDateBegin.DateTime.AddDays(7);
                    }
                }
                else if (queryPrReqNo != "")
                {
                    textPrReqNo.Text = queryPrReqNo;
                    textCommon.Text = queryPrReqNo;
                    queryPrReqNo = "";

                    lookUpReqDep.ItemIndex = 0;
                    lookUpPurCategory.ItemIndex = 0;
                    searchLookUpBussinessBaseNo.Text = "全部";
                    comboBoxReqState.SelectedIndex = 0;
                    searchLookUpCreator.EditValue = 0;
                    searchLookUpApprover.EditValue = null;
                    checkPlanDate.Checked = false;

                    dataSet_Order.Tables[0].Clear();
                    dataSet_Order.Tables[1].Clear();
                    dataSet_Order.Tables[2].Clear();
                    headFocusedLineNo = 0;
                    orderDAO.QueryOrderHead(dataSet_Order.Tables[0], "", "", "", "", "", "", "", 0, 0, -1, textCommon.Text, false);
                    SetButtonAndColumnState(false);
                    
                    searchLookUpProjectNo.Text = "全部";

                    dataSet_PrReq.Tables[0].Clear();
                    dataSet_PrReq.Tables[1].Clear();
                    applyDAO.QueryPrReqHead(dataSet_PrReq.Tables[0], textPrReqNo.Text, "", "", "", "", 0, "", "");

                    if (dataSet_PrReq.Tables[0].Rows.Count > 0)
                    {
                        dateReqDateBegin.DateTime = DataTypeConvert.GetDateTime(dataSet_PrReq.Tables[0].Rows[0]["ReqDate"]).Date;
                        dateReqDateEnd.DateTime = dateReqDateBegin.DateTime.AddDays(7);
                    }
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
        private void FrmOrder_Shown(object sender, EventArgs e)
        {
            pnlMiddleHead.Height = (this.Height - pnltop.Height) / 2;
            pnlLeftMiddle.Height = gridControlOrderHead.Height - 19;

            dockPnlLeft.Width = SystemInfo.DragForm_LeftDock_Width;
        }

        #endregion

        #region 右侧采购订单模块的相关事件和方法

        /// <summary>
        /// 删除选项
        /// </summary>
        private void searchLookUpApprover_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                searchLookUpApprover.EditValue = null;
            }
        }

        /// <summary>
        /// 查询按钮事件
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (dateOrderDateBegin.EditValue == null || dateOrderDateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("订购日期不能为空，请设置后重新进行查询。");
                    if (dateOrderDateBegin.EditValue == null)
                        dateOrderDateBegin.Focus();
                    else
                        dateOrderDateEnd.Focus();
                    return;
                }
                string orderDateBeginStr = dateOrderDateBegin.DateTime.ToString("yyyy-MM-dd");
                string orderDateEndStr = dateOrderDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                string planDateBeginStr = "";
                string planDateEndStr = "";
                if (checkPlanDate.Checked)
                {
                    if (datePlanDateBegin.EditValue == null || datePlanDateEnd.EditValue == null)
                    {
                        MessageHandler.ShowMessageBox("计划到货日期不能为空，请设置后重新进行查询。");
                        if (datePlanDateBegin.EditValue == null)
                            datePlanDateBegin.Focus();
                        else
                            datePlanDateEnd.Focus();
                        return;
                    }
                    planDateBeginStr = datePlanDateBegin.DateTime.ToString("yyyy-MM-dd");
                    planDateEndStr = datePlanDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                }

                string reqDepStr = lookUpReqDep.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpReqDep.EditValue) : "";
                string purCategoryStr = lookUpPurCategory.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpPurCategory.EditValue) : "";
                string bussinessBaseNoStr = DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) != "全部" ? DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) : "";
                int reqStateInt = CommonHandler.Get_OrderState_No(comboBoxReqState.Text);
                int creatorInt = DataTypeConvert.GetInt(searchLookUpCreator.EditValue);
                int approverInt = -1;
                if (searchLookUpApprover.Text != "")
                {
                    if (DataTypeConvert.GetInt(searchLookUpApprover.EditValue) == 0)
                        approverInt = 0;
                    else
                        approverInt = DataTypeConvert.GetInt(searchLookUpApprover.EditValue);
                }
                string commonStr = textCommon.Text.Trim();
                dataSet_Order.Tables[0].Clear();
                dataSet_Order.Tables[1].Clear();
                dataSet_Order.Tables[2].Clear();
                headFocusedLineNo = 0;
                orderDAO.QueryOrderHead(dataSet_Order.Tables[0], orderDateBeginStr, orderDateEndStr, planDateBeginStr, planDateEndStr, reqDepStr, purCategoryStr, bussinessBaseNoStr, reqStateInt, creatorInt, approverInt, commonStr, false);

                SetButtonAndColumnState(false);
                checkAll.Checked = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 主表聚焦行改变事件
        /// </summary>
        private void gridViewOrderHead_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewOrderHead.GetFocusedDataRow() != null)
                {
                    if (onlySelectColChangeRowState)
                    {
                        dataSet_Order.Tables[0].AcceptChanges();
                        onlySelectColChangeRowState = false;

                        if (btnNew.Enabled)
                            ControlHandler.SetButtonBar_EnabledState_Order(dataSet_Order.Tables[0].Select("select=1"), gridViewOrderHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
                    }
                    else
                    {
                        if (headFocusedLineNo < gridViewOrderHead.DataRowCount && gridViewOrderHead.FocusedRowHandle != headFocusedLineNo && gridViewOrderHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                        {
                            MessageHandler.ShowMessageBox("当前采购单已经修改，请保存后再进行换行。");
                            gridViewOrderHead.FocusedRowHandle = headFocusedLineNo;
                        }
                        else if (headFocusedLineNo == gridViewOrderHead.DataRowCount)
                        {

                        }
                        else
                        {
                            if (gridViewOrderHead.FocusedRowHandle != headFocusedLineNo && gridViewOrderHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                            else if (gridViewOrderHead.GetDataRow(headFocusedLineNo).RowState == DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                        }
                    }

                    string orderHeadNoStr = DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["OrderHeadNo"]);
                    if (orderHeadNoStr != "")
                    {
                        dataSet_Order.Tables[1].Clear();
                        dataSet_Order.Tables[2].Clear();
                        orderDAO.QueryOrderList(dataSet_Order.Tables[1], orderHeadNoStr, false);
                        orderDAO.QueryPRPO_Relation(dataSet_Order.Tables[2], orderHeadNoStr, false);
                        if (queryListAutoId > 0)
                        {
                            for (int i = 0; i < gridViewOrderList.DataRowCount; i++)
                            {
                                if (DataTypeConvert.GetInt(gridViewOrderList.GetDataRow(i)["AutoId"]) == queryListAutoId)
                                {
                                    gridViewOrderList.FocusedRowHandle = i;
                                    queryListAutoId = 0;
                                    break;
                                }
                            }
                        }
                    }

                    if (gridViewOrderHead.FocusedRowHandle >= 0)
                    {
                        headFocusedLineNo = gridViewOrderHead.FocusedRowHandle;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--主表聚焦行改变事件错误。", ex);
            }
        }

        /// <summary>
        /// 子表聚焦行改变事件
        /// </summary>
        private void gridViewOrderList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewOrderList.GetFocusedDataRow() != null)
                {
                    int autoIdInt = DataTypeConvert.GetInt(gridViewOrderList.GetFocusedDataRow()["AutoId"]);
                    if (radioType.SelectedIndex == 1)
                    {
                        bindingSource_PRPO.Filter = string.Format("POListId = {0}", autoIdInt);
                    }

                    if (!btnNew.Enabled && dataSet_Order.Tables[2].Select(string.Format("POListId = {0}", autoIdInt)).Length == 0)
                    {
                        colCodeFileName.OptionsColumn.AllowEdit = true;
                        colQty.OptionsColumn.AllowEdit = true;
                        colQty.OptionsColumn.TabStop = true;
                    }
                    else
                    {
                        colCodeFileName.OptionsColumn.AllowEdit = false;
                        colQty.OptionsColumn.AllowEdit = false;
                        colQty.OptionsColumn.TabStop = false;
                    }
                }
                else
                {
                    colCodeFileName.OptionsColumn.AllowEdit = false;
                    colQty.OptionsColumn.AllowEdit = false;
                    colQty.OptionsColumn.TabStop = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--子表聚焦行改变事件错误。", ex);
            }
        }

        /// <summary>
        /// 选择查询零件请购信息类型
        /// </summary>
        private void radioType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (radioType.SelectedIndex)
                {
                    case 1:
                        gridViewOrderList_FocusedRowChanged(null, null);
                        break;
                    default:
                        bindingSource_PRPO.Filter = "";
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择查询零件请购信息类型错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewOrderHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void repSearchCodeFileNameView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewOrderHead_KeyDown(object sender, KeyEventArgs e)
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
        /// 设定列表显示信息
        /// </summary>
        private void gridViewOrderHead_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "ReqState")
            {
                e.DisplayText = CommonHandler.Get_OrderState_Desc(e.Value.ToString());
            }
        }

        /// <summary>
        /// 选择计划到货日期
        /// </summary>
        private void checkPlanDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPlanDate.Checked)
            {
                datePlanDateBegin.Enabled = true;
                datePlanDateEnd.Enabled = true;
            }
            else
            {
                datePlanDateBegin.Enabled = false;
                datePlanDateEnd.Enabled = false;
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

                ClearHeadGridAllSelect();

                //gridViewPrReqHead.PostEditor();
                gridViewOrderHead.AddNewRow();
                FocusedHeadView("PurCategory");

                dataSet_Order.Tables[1].Clear();
                gridViewOrderList.AddNewRow();
                FocusedListView(false, "CodeFileName", gridViewOrderList.GetFocusedDataSourceRowIndex());
                gridViewOrderList.RefreshData();

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewOrderHead.DataRowCount;
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

                if (gridViewOrderHead.GetFocusedDataRow() == null)
                    return;

                if (!CheckReqState())
                    return;

                if (btnSave.Text != "保存")
                {
                    ClearHeadGridAllSelect();

                    SetButtonAndColumnState(true);
                    FocusedHeadView("PurCategory");
                    BingStnListComboBox();
                }
                else
                {
                    DataRow headRow = gridViewOrderHead.GetFocusedDataRow();

                    bindingSource_OrderHead.EndEdit();
                    bindingSource_OrderList.EndEdit();
                    bindingSource_PRPO.EndEdit();
                    if (DataTypeConvert.GetString(headRow["PurCategory"]) == "")
                    {
                        MessageHandler.ShowMessageBox("采购类型不能为空，请填写后再进行保存。");
                        FocusedHeadView("PurCategory");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["BussinessBaseNo"]) == "")
                    {
                        MessageHandler.ShowMessageBox("往来方不能为空，请填写后再进行保存。");
                        FocusedHeadView("BussinessBaseNo");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["ReqDep"]) == "")
                    {
                        MessageHandler.ShowMessageBox("申请部门不能为空，请填写后再进行保存。");
                        FocusedHeadView("ReqDep");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["ProjectNo"]) == "")
                    {
                        MessageHandler.ShowMessageBox("项目号不能为空，请填写后再进行保存。");
                        FocusedHeadView("ProjectNo");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["StnNo"]) == "")
                    {
                        MessageHandler.ShowMessageBox("站号不能为空，请填写后再进行保存。");
                        FocusedHeadView("StnNo");
                        return;
                    }
                    //if (DataTypeConvert.GetString(headRow["ApprovalType"]) == "")
                    //{
                    //    MessageHandler.ShowMessageBox("审批类型不能为空，请填写后再进行保存。");
                    //    FocusedHeadView("ApprovalType");
                    //    return;
                    //}
                    if (DataTypeConvert.GetString(headRow["PayTypeNo"]) == "")
                    {
                        MessageHandler.ShowMessageBox("付款类型不能为空，请填写后再进行保存。");
                        FocusedHeadView("PayTypeNo");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["Tax"]) == "")
                    {
                        MessageHandler.ShowMessageBox("税率不能为空，请填写后再进行保存。");
                        FocusedHeadView("Tax");
                        return;
                    }

                    if (!commonDAO.StnNoIsContainProjectNo(DataTypeConvert.GetString(headRow["ProjectNo"]), DataTypeConvert.GetString(headRow["StnNo"])))
                    {
                        MessageHandler.ShowMessageBox("输入的站号不属于项目号，请重新填写后再进行保存。");
                        FocusedHeadView("StnNo");
                        return;
                    }

                    for (int i = gridViewOrderList.DataRowCount - 1; i >= 0; i--)
                    {
                        DataRow listRow = gridViewOrderList.GetDataRow(i);
                        if (DataTypeConvert.GetString(listRow["CodeFileName"]) == "")
                        {
                            gridViewOrderList.DeleteRow(i);
                            continue;
                        }
                        if (DataTypeConvert.GetString(listRow["Qty"]) == "")
                        {
                            MessageHandler.ShowMessageBox("数量不能为空，请填写后再进行保存。");
                            FocusedListView(true, "Qty", i);
                            return;
                        }
                        if (DataTypeConvert.GetString(listRow["Unit"]) == "")
                        {
                            MessageHandler.ShowMessageBox("单价不能为空，请填写后再进行保存。");
                            FocusedListView(true, "Unit", i);
                            return;
                        }
                        if (DataTypeConvert.GetString(listRow["Amount"]) == "")
                        {
                            MessageHandler.ShowMessageBox("金额不能为空，请填写后再进行保存。");
                            FocusedListView(true, "Amount", i);
                            return;
                        }
                        if (DataTypeConvert.GetString(listRow["SumAmount"]) == "")
                        {
                            MessageHandler.ShowMessageBox("价税合计不能为空，请填写后再进行保存。");
                            FocusedListView(true, "SumAmount", i);
                            return;
                        }                        
                    }

                    for (int i = 0; i < gridViewPRPO.DataRowCount; i++)
                    {
                        DataRow subRow = gridViewPRPO.GetDataRow(i);
                        if (DataTypeConvert.GetDouble(subRow["PRQty"]) == 0)
                        {
                            MessageHandler.ShowMessageBox("请购数量不能为空或者零，请填写后再进行保存。");
                            FocusedSubListView(true, "PRQty", i);
                            return;
                        }
                    }

                    int ret = orderDAO.SaveOrder(gridViewOrderHead.GetFocusedDataRow(), dataSet_Order.Tables[1], dataSet_Order.Tables[2]);
                    switch (ret)
                    {
                        case -1:
                            btnQuery_Click(null, null);
                            break;
                        case 1:
                            dataSet_Order.Tables[1].Clear();
                            dataSet_Order.Tables[2].Clear();
                            string orderHeadNoStr = DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["OrderHeadNo"]);
                            orderDAO.QueryOrderList(dataSet_Order.Tables[1], orderHeadNoStr, false);
                            orderDAO.QueryPRPO_Relation(dataSet_Order.Tables[2], orderHeadNoStr, false);
                            break;
                        case 0:
                            return;
                    }

                    SetButtonAndColumnState(false);
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

                if (gridViewOrderHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                {
                    if (DataTypeConvert.GetString(gridViewOrderHead.GetDataRow(headFocusedLineNo)["OrderHeadNo"]) == "")
                    {
                        gridViewOrderHead.DeleteRow(headFocusedLineNo);
                    }
                    else
                    {
                        gridViewOrderHead.GetFocusedDataRow().RejectChanges();
                    }
                }

                SetButtonAndColumnState(false);

                dataSet_Order.Tables[1].Clear();
                dataSet_Order.Tables[2].Clear();
                if (gridViewOrderHead.GetFocusedDataRow() != null)
                {
                    string orderHeadNoStr = DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["OrderHeadNo"]);
                    orderDAO.QueryOrderList(dataSet_Order.Tables[1], orderHeadNoStr, false);
                    orderDAO.QueryPRPO_Relation(dataSet_Order.Tables[2], orderHeadNoStr, false);
                }

                gridViewPrReqHead_FocusedRowChanged(sender, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--取消按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 提交按钮事件
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int count = dataSet_Order.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                //if (!WorkFlowsHandleDAO.QueryWorkFlowsLineNextNodeIsEnabled(WorkFlowsHandleDAO.OrderType.采购订单, WorkFlowsHandleDAO.LineType.提交))
                //{
                //    if (MessageHandler.ShowMessageBox_YesNo(string.Format("流程图中状态节点[提交]已经停用，确定要直接审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                //    {
                //        return;
                //    }
                //    else
                //    {
                //        ApproveOrder(1);
                //        return;
                //    }
                //}

                if (!CheckReqState_Multi(false, true, true, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要提交当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!orderDAO.SubmitOrder_Multi(dataSet_Order.Tables[0]))
                    btnQuery_Click(null, null);

                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_Order.Tables[0].Select("select=1"), gridViewOrderHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--提交按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 取消提交按钮事件 
        /// </summary>
        private void btnCancelSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int count = dataSet_Order.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckReqState_Multi(true, true, true, false, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要取消提交当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!orderDAO.CancelSubmitOrder_Multi(dataSet_Order.Tables[0]))
                    btnQuery_Click(null, null);

                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_Order.Tables[0].Select("select=1"), gridViewOrderHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--取消提交按钮事件错误。", ex);
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

                int count = dataSet_Order.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckReqState_Multi(false, true, true, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要删除当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!orderDAO.DeleteOrder_Multi(dataSet_Order.Tables[0]))
                {
                    
                }

                btnQuery_Click(null, null);
                ClearHeadGridAllSelect();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 审批按钮事件
        /// </summary>
        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int count = dataSet_Order.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckReqState_Multi(true, true, true, false, "（请确保订单提交后再进行审批操作）"))
                    return;

                //if (count == 1)
                //{
                //    //弹出审批页面
                //    FrmOrderApproval frmOrder = new FrmOrderApproval(DataTypeConvert.GetString(dataSet_Order.Tables[0].Select("select=1")[0]["OrderHeadNo"]));
                //    if (frmOrder.ShowDialog() == DialogResult.OK)
                //        btnQuery_Click(null, null);
                //}
                //else
                //{
                //    if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                //    {
                //        return;
                //    }
                //    List<string> dataNoList = new List<string>();
                //    DataRow[] drs = dataSet_Order.Tables[0].Select("select=1");
                //    for (int i = 0; i < drs.Length; i++)
                //    {
                //        dataNoList.Add(DataTypeConvert.GetString(drs[i]["OrderHeadNo"]));
                //    }

                //    FrmWorkFlowDataHandle wfDataHandle = new FrmWorkFlowDataHandle();
                //    wfDataHandle.orderNameStr = "采购订单";
                //    wfDataHandle.dataNoList = dataNoList;
                //    wfDataHandle.workFlowTypeText = "采购流程";
                //    wfDataHandle.tableNameStr = "PUR_OrderHead";
                //    wfDataHandle.moduleTypeInt = 2;
                //    if (wfDataHandle.ShowDialog() == DialogResult.OK)
                //    {
                //        int nodeIdInt = wfDataHandle.nodeIdInt;
                //        string flowModuleIdStr = wfDataHandle.flowModuleIdStr;
                //        string approverOptionStr = wfDataHandle.memoApproverOption.Text;
                //        int approverResultInt = DataTypeConvert.GetInt(wfDataHandle.radioApproverResult.EditValue);

                //        int successCountInt = 0;
                //        //直接审批，不再谈页面
                //        if (!orderDAO.OrderApprovalInfo_Multi(dataSet_Order.Tables[0], nodeIdInt, flowModuleIdStr, approverOptionStr, approverResultInt, ref successCountInt))
                //            btnQuery_Click(null, null);
                //        else
                //        {
                //            if (approverResultInt == 1)
                //                MessageHandler.ShowMessageBox(string.Format("成功审批了{0}条记录。", successCountInt));
                //            else
                //                MessageHandler.ShowMessageBox(string.Format("成功拒绝了{0}条记录。", successCountInt));
                //        }
                //    }
                //}

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }

                ApproveOrder(4);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--审批按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 审批采购订单
        /// </summary>
        private void ApproveOrder(int reqStateInt)
        {
            List<string> dataNoList = new List<string>();
            DataRow[] drs = dataSet_Order.Tables[0].Select("select=1");
            for (int i = 0; i < drs.Length; i++)
            {
                dataNoList.Add(DataTypeConvert.GetString(drs[i]["OrderHeadNo"]));
            }

            FrmWorkFlowsDataHandle wfDataHandle = new FrmWorkFlowsDataHandle();
            wfDataHandle.orderNameStr = "采购订单";
            wfDataHandle.dataNoList = dataNoList;
            wfDataHandle.orderType = WorkFlowsHandleDAO.OrderType.采购订单;
            if (wfDataHandle.ShowDialog() == DialogResult.OK)
            {
                string approverOptionStr = wfDataHandle.memoApproverOption.Text;
                int approverResultInt = DataTypeConvert.GetInt(wfDataHandle.radioApproverResult.EditValue);

                int successCountInt = reqStateInt;

                //直接审批，不再谈页面
                if (!orderDAO.OrderApprovalInfoNew_Multi(dataSet_Order.Tables[0], approverOptionStr, approverResultInt, ref successCountInt))
                    btnQuery_Click(null, null);
                else
                {
                    if (approverResultInt == 1)
                        MessageHandler.ShowMessageBox(string.Format("成功审批了{0}条记录。", successCountInt));
                    else
                        MessageHandler.ShowMessageBox(string.Format("成功拒绝了{0}条记录。", successCountInt));
                }
            }

            ClearHeadGridAllSelect();
            ControlHandler.SetButtonBar_EnabledState_Order(dataSet_Order.Tables[0].Select("select=1"), gridViewOrderHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
            //if (!orderDAO.ApproveOrder_Multi(dataSet_Order.Tables[0]))
            //    btnQuery_Click(null, null);
        }

        /// <summary>
        /// 取消审批按钮事件
        /// </summary>
        private void btnCancelApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int count = dataSet_Order.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckReqState_Multi(true, false, true, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要取消审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }

                if (!orderDAO.CancalOrderApprovalInfo_Multi(dataSet_Order.Tables[0]))
                    btnQuery_Click(null, null);
                else
                {
                    MessageHandler.ShowMessageBox(string.Format("成功取消审批了{0}条记录。", count));
                }
                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_Order.Tables[0].Select("select=1"), gridViewOrderHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--取消审批按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int count = dataSet_Order.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckReqState_Multi(false, true, true, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要关闭当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!orderDAO.CloseOrder_Multi(dataSet_Order.Tables[0]))
                    btnQuery_Click(null, null);
                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_Order.Tables[0].Select("select=1"), gridViewOrderHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--关闭按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 取消关闭按钮事件
        /// </summary>
        private void btnCancelClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int count = dataSet_Order.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckReqState_Multi(true, true, false, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要取消关闭当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!orderDAO.CancelCloseOrder_Multi(dataSet_Order.Tables[0]))
                    btnQuery_Click(null, null);
                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_Order.Tables[0].Select("select=1"), gridViewOrderHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--取消关闭按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 请购适用按钮事件    --暂时不用这个通过打开窗体选择，直接拖拽选择
        /// </summary>
        private void btnPrReqApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                FrmPrReqApply prReqApplyForm = new FrmPrReqApply();
                if (prReqApplyForm.ShowDialog() == DialogResult.OK)
                {
                    PRToPO_Order(prReqApplyForm.gridViewPrReqHead.GetFocusedDataRow(), prReqApplyForm.dataSet_PrReq.Tables[1]);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--请购适用按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 打印预览按钮事件
        /// </summary>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                string orderHeadNoStr = "";
                DataRow dr = null;
                DataRow[] drs = dataSet_Order.Tables[0].Select("select=1");
                if (drs.Length > 1)
                {
                    MessageHandler.ShowMessageBox("只能选中一条记录进行打印预览，请重新选择。");
                    return;
                }
                else if (drs.Length == 0)
                {
                    if (gridViewOrderHead.GetFocusedDataRow() != null)
                    {
                        orderHeadNoStr = DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["OrderHeadNo"]);
                        dr = gridViewOrderHead.GetFocusedDataRow();
                    }
                }
                else
                {
                    orderHeadNoStr = DataTypeConvert.GetString(drs[0]["OrderHeadNo"]);
                    dr = drs[0];
                }

                if (dr != null && SystemInfo.ApproveAfterPrint)
                {
                    if (DataTypeConvert.GetInt(dr["ReqState"]) != 2)
                    {
                        MessageHandler.ShowMessageBox("请审批通过后，再进行打印预览操作。");
                        return;
                    }
                }

                //string orderHeadNoStr = "";
                //if (gridViewOrderHead.GetFocusedDataRow() != null)
                //    orderHeadNoStr = DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["OrderHeadNo"]);

                //if(SystemInfo.ApproveAfterPrint)
                //{
                //    if (DataTypeConvert.GetInt(gridViewOrderHead.GetFocusedDataRow()["ReqState"])!=2)
                //    {
                //        MessageHandler.ShowMessageBox("请审批通过后，再进行打印预览操作。");
                //        return;
                //    }
                //}

                orderDAO.PrintHandle(orderHeadNoStr, 1);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--打印预览按钮事件错误。", ex);
            }
        }

        ///// <summary>
        ///// 打印设计
        ///// </summary>
        //private void btnDesigner_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string orderHeadNoStr = "";
        //        if (gridViewOrderHead.GetFocusedDataRow() != null)
        //            orderHeadNoStr = DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["OrderHeadNo"]);
        //        orderDAO.PrintHandle(orderHeadNoStr, 3);
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandler.HandleException(this.Text + "--打印设计操作错误。", ex);
        //    }
        //}

        /// <summary>
        /// 全部选中
        /// </summary>
        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            bool value = false;
            if (checkAll.Checked)
            {
                value = true;
            }
            foreach (DataRow dr in dataSet_Order.Tables[0].Rows)
            {
                dr["Select"] = value;
            }
            onlySelectColChangeRowState = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_Order.Tables[0].Select("select=1"), gridViewOrderHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
        }

        /// <summary>
        /// 子表新增一行事件
        /// </summary>
        private void btnListAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!colRemark.OptionsColumn.AllowEdit)
                    return;

                ListNewRow();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--子表新增一行事件错误。", ex);
            }
        }

        /// <summary>
        /// 主表设定默认值
        /// </summary>
        private void gridViewOrderHead_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                gridViewOrderHead.SetFocusedRowCellValue("OrderHeadDate", nowDate);
                gridViewOrderHead.SetFocusedRowCellValue("ReqDep", SystemInfo.user.DepartmentNo);
                gridViewOrderHead.SetFocusedRowCellValue("PurCategory", DataTypeConvert.GetString(((DataTable)lookUpPurCategory.Properties.DataSource).Rows[1]["PurCategory"]));
                gridViewOrderHead.SetFocusedRowCellValue("ReqState", 1);

                gridViewOrderHead.SetFocusedRowCellValue("Creator", SystemInfo.user.AutoId);
                gridViewOrderHead.SetFocusedRowCellValue("Tax", SystemInfo.OrderList_DefaultTax);
                gridViewOrderHead.SetFocusedRowCellValue("PlanDate", nowDate.Date.AddDays(7));

                if (SystemInfo.DisableProjectNo)
                {
                    gridViewPrReqHead.SetFocusedRowCellValue("ProjectNo", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                    gridViewPrReqHead.SetFocusedRowCellValue("StnNo", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--主表设定默认值错误。", ex);
            }
        }

        /// <summary>
        /// 子表设定默认值
        /// </summary>
        private void gridViewOrderList_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridViewOrderList.SetFocusedRowCellValue("OrderHeadNo", DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["OrderHeadNo"]));
                if (DataTypeConvert.GetDouble(gridViewOrderList.GetFocusedDataRow()["Qty"]) == 0)
                    gridViewOrderList.SetFocusedRowCellValue("Qty", 1);
                double d = DataTypeConvert.GetDouble(gridViewOrderHead.GetFocusedDataRow()["Tax"]);
                gridViewOrderList.SetFocusedRowCellValue("Tax", DataTypeConvert.GetDouble(gridViewOrderHead.GetFocusedDataRow()["Tax"]));
                gridViewOrderList.SetFocusedRowCellValue("PlanDate", DataTypeConvert.GetDateTime(gridViewOrderHead.GetFocusedDataRow()["PlanDate"]));
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--子表设定默认值错误。", ex);
            }
        }

        /// <summary>
        /// 子表按键事件
        /// </summary>
        private void gridViewOrderList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!colRemark.OptionsColumn.AllowEdit)
                        return;

                    if (gridViewOrderList.GetFocusedDataSourceRowIndex() >= gridViewOrderList.DataRowCount - 1 && gridViewOrderList.FocusedColumn.Name == "colRemark")
                    {
                        ListNewRow();
                    }
                    else if (gridViewOrderList.FocusedColumn.Name == "colRemark")
                    {
                        gridViewOrderList.FocusedRowHandle = gridViewOrderList.FocusedRowHandle + 1;
                        FocusedListView(true, "CodeFileName", gridViewOrderList.GetFocusedDataSourceRowIndex());
                    }
                }
                else
                {
                    ControlHandler.GridView_GetFocusedCellDisplayText_KeyDown(sender, e);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--子表按键事件错误。", ex);
            }
        }

        /// <summary>
        /// 删除子表中的一行
        /// </summary>
        private void repbtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridViewOrderList.GetFocusedDataRow().RowState != DataRowState.Added)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的明细记录吗？") != DialogResult.Yes)
                    {
                        return;
                    }
                }

                bool isPartType = radioType.SelectedIndex == 1;
                if (isPartType)
                    radioType.SelectedIndex = 0;

                int autoIdInt = 0;
                if (gridViewOrderList.GetFocusedDataRow() != null)
                    autoIdInt = DataTypeConvert.GetInt(gridViewOrderList.GetFocusedDataRow()["AutoId"]);
                gridViewOrderList.DeleteRow(gridViewOrderList.FocusedRowHandle);
                for (int i = gridViewPRPO.DataRowCount - 1; i >= 0; i--)
                {
                    if (DataTypeConvert.GetInt(gridViewPRPO.GetDataRow(i)["POListId"]) == autoIdInt)
                    {
                        gridViewPRPO.DeleteRow(i);
                    }
                }
                if (isPartType)
                    radioType.SelectedIndex = 1;

                gridViewPrReqHead_FocusedRowChanged(sender, null);
                SetProjectIsEdit();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除子表中的一行错误。", ex);
            }
        }

        /// <summary>
        /// 删除明细表中的一行
        /// </summary>
        private void repbtnPRPO_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridViewPRPO.GetFocusedDataRow().RowState != DataRowState.Added)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的明细记录吗？") != DialogResult.Yes)
                    {
                        return;
                    }
                }
                int poListIdInt = 0;
                if (gridViewPRPO.GetFocusedDataRow() != null)
                    poListIdInt = DataTypeConvert.GetInt(gridViewPRPO.GetFocusedDataRow()["POListId"]);
                gridViewPRPO.DeleteRow(gridViewPRPO.FocusedRowHandle);
                if (poListIdInt > 0)
                {
                    UpdateOrderListQty(poListIdInt);
                }
                SetProjectIsEdit();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除明细表中的一行错误。", ex);
            }
        }

        /// <summary>
        /// 主表单元格值变化进行的操作
        /// </summary>
        private void gridViewOrderHead_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                switch (e.Column.FieldName)
                {
                    case "ProjectNo":
                        string projectNoStr = DataTypeConvert.GetString(gridViewOrderHead.GetDataRow(e.RowHandle)["ProjectNo"]);
                        if (projectNoStr == "")
                        {
                            gridViewOrderHead.SetRowCellValue(e.RowHandle, "ProjectNo", "");
                            gridViewOrderHead.SetRowCellValue(e.RowHandle, "StnNo", "");
                        }
                        else
                        {
                            gridViewOrderHead.SetRowCellValue(e.RowHandle, "StnNo", "");
                        }

                        BingStnListComboBox();
                        break;
                    case "Tax":
                        for (int i = 0; i < gridViewOrderList.DataRowCount; i++)
                        {
                            gridViewOrderList.SetRowCellValue(i, "Tax", DataTypeConvert.GetDouble(gridViewOrderHead.GetDataRow(e.RowHandle)["Tax"]));
                        }
                        break;
                    case "PlanDate":
                        for (int i = 0; i < gridViewOrderList.DataRowCount; i++)
                        {
                            gridViewOrderList.SetRowCellValue(i, "PlanDate", DataTypeConvert.GetDateTime(gridViewOrderHead.GetDataRow(e.RowHandle)["PlanDate"]));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--主表单元格值变化进行的操作错误。", ex);
            }
        }

        /// <summary>
        /// 子表单元格值变化进行的操作
        /// </summary>
        private void gridViewOrderList_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (modifyLock)
                    return;

                modifyLock = true;

                double qtyDouble = 0;
                double unitDouble = 0;
                double amountDouble = 0;
                double taxDouble = 0;
                double taxAmountDouble = 0;
                double sumAmountDouble = 0;
                switch (e.Column.FieldName)
                {
                    case "CodeFileName":
                        string tmpStr = DataTypeConvert.GetString(gridViewOrderList.GetDataRow(e.RowHandle)["CodeFileName"]);
                        if (tmpStr == "")
                        {
                            gridViewOrderList.SetRowCellValue(e.RowHandle, "CodeId", null);
                            gridViewOrderList.SetRowCellValue(e.RowHandle, "CodeName", "");
                        }
                        else
                        {
                            DataTable temp = (DataTable)repSearchCodeFileName.DataSource;
                            DataRow[] drs = temp.Select(string.Format("CodeFileName='{0}'", tmpStr));
                            if (drs.Length > 0)
                            {
                                gridViewOrderList.SetRowCellValue(e.RowHandle, "CodeId", DataTypeConvert.GetString(drs[0]["AutoId"]));
                                gridViewOrderList.SetRowCellValue(e.RowHandle, "CodeName", DataTypeConvert.GetString(drs[0]["CodeName"]));
                            }
                        }
                        //if (DataTypeConvert.GetString(gridViewOrderList.GetDataRow(e.RowHandle)["PrReqNo"]) != "")
                        //{
                        //    gridViewOrderList.SetRowCellValue(e.RowHandle, "PrReqNo", "");
                        //    gridViewOrderList.SetRowCellValue(e.RowHandle, "PrListAutoId", 0);
                        //}
                        break;
                    case "Qty":
                    case "Unit":
                    case "Tax":
                        qtyDouble = DataTypeConvert.GetDouble(gridViewOrderList.GetDataRow(e.RowHandle)["Qty"]);
                        unitDouble = DataTypeConvert.GetDouble(gridViewOrderList.GetDataRow(e.RowHandle)["Unit"]);
                        amountDouble = Math.Round(qtyDouble * unitDouble, 2, MidpointRounding.AwayFromZero);
                        taxDouble = DataTypeConvert.GetDouble(gridViewOrderList.GetDataRow(e.RowHandle)["Tax"]);
                        taxAmountDouble = Math.Round(amountDouble * taxDouble, 2, MidpointRounding.AwayFromZero);
                        sumAmountDouble = amountDouble + taxAmountDouble;
                        gridViewOrderList.SetRowCellValue(e.RowHandle, "Amount", amountDouble);
                        gridViewOrderList.SetRowCellValue(e.RowHandle, "TaxAmount", taxAmountDouble);
                        gridViewOrderList.SetRowCellValue(e.RowHandle, "SumAmount", sumAmountDouble);
                        break;
                    case "Amount":
                        if (DataTypeConvert.GetString(gridViewOrderList.GetDataRow(e.RowHandle)["Qty"]) == "")
                        {
                            MessageHandler.ShowMessageBox("请输入数量。");
                            gridViewOrderList.FocusedColumn = colQty;
                            modifyLock = false;
                            return;
                        }
                        amountDouble = DataTypeConvert.GetDouble(gridViewOrderList.GetDataRow(e.RowHandle)["Amount"]);
                        qtyDouble = DataTypeConvert.GetDouble(gridViewOrderList.GetDataRow(e.RowHandle)["Qty"]);
                        unitDouble = Math.Round(amountDouble / qtyDouble, 2, MidpointRounding.AwayFromZero);
                        taxDouble = DataTypeConvert.GetDouble(gridViewOrderList.GetDataRow(e.RowHandle)["Tax"]);
                        taxAmountDouble = Math.Round(amountDouble * taxDouble, 2, MidpointRounding.AwayFromZero);
                        sumAmountDouble = amountDouble + taxAmountDouble;
                        gridViewOrderList.SetRowCellValue(e.RowHandle, "Unit", unitDouble);
                        gridViewOrderList.SetRowCellValue(e.RowHandle, "TaxAmount", taxAmountDouble);
                        gridViewOrderList.SetRowCellValue(e.RowHandle, "SumAmount", sumAmountDouble);
                        break;
                    case "SumAmount":
                        if (DataTypeConvert.GetString(gridViewOrderList.GetDataRow(e.RowHandle)["Qty"]) == "")
                        {
                            MessageHandler.ShowMessageBox("请输入数量。");
                            gridViewOrderList.FocusedColumn = colQty;
                            modifyLock = false;
                            return;
                        }
                        sumAmountDouble = DataTypeConvert.GetDouble(gridViewOrderList.GetDataRow(e.RowHandle)["SumAmount"]);
                        qtyDouble = DataTypeConvert.GetDouble(gridViewOrderList.GetDataRow(e.RowHandle)["Qty"]);
                        taxDouble = DataTypeConvert.GetDouble(gridViewOrderList.GetDataRow(e.RowHandle)["Tax"]);
                        amountDouble = Math.Round(sumAmountDouble / (1 + taxDouble), 2, MidpointRounding.AwayFromZero);
                        taxAmountDouble = sumAmountDouble - amountDouble;
                        unitDouble = Math.Round(amountDouble / qtyDouble, 2, MidpointRounding.AwayFromZero);
                        gridViewOrderList.SetRowCellValue(e.RowHandle, "Unit", unitDouble);
                        gridViewOrderList.SetRowCellValue(e.RowHandle, "TaxAmount", taxAmountDouble);
                        gridViewOrderList.SetRowCellValue(e.RowHandle, "Amount", amountDouble);
                        break;
                }

                modifyLock = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--子表单元格值变化进行的操作错误。", ex);
            }
        }

        /// <summary>
        /// 明细表数量改变更新子表的合计数量
        /// </summary>
        private void gridViewPRPO_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (subLock)
                    return;

                switch (e.Column.FieldName)
                {
                    case "PRQty":
                        double prQty = DataTypeConvert.GetDouble(gridViewPRPO.GetDataRow(e.RowHandle)["PRQty"]);
                        double maxPRQty = DataTypeConvert.GetDouble(gridViewPRPO.GetDataRow(e.RowHandle)["MaxPRQty"]);
                        if (prQty > maxPRQty)
                        {
                            MessageHandler.ShowMessageBox("采购订单的请购数量不能超过请购单明细的剩余数量。");
                            gridViewPRPO.SetRowCellValue(e.RowHandle, "PRQty", maxPRQty);
                        }

                        int poListIdInt = DataTypeConvert.GetInt(gridViewPRPO.GetDataRow(e.RowHandle)["POListId"]);
                        UpdateOrderListQty(poListIdInt);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--明细表数量改变更新子表的合计数量错误。", ex);
            }
        }

        /// <summary>
        /// 更新子表的合计数量
        /// </summary>
        private void UpdateOrderListQty(int autoIdInt)
        {
            DataRow[] codeRows = dataSet_Order.Tables[1].Select(string.Format("AutoId = {0}", autoIdInt));
            if (codeRows.Length > 0)
            {
                double sumQty = DataTypeConvert.GetDouble(dataSet_Order.Tables[2].Compute("Sum(PRQty)", string.Format("POListId = {0}", autoIdInt)));
                if (sumQty == 0)
                {
                    for (int i = 0; i < gridViewOrderList.DataRowCount; i++)
                    {
                        if (DataTypeConvert.GetInt(gridViewOrderList.GetDataRow(i)["AutoId"]) == autoIdInt)
                        {
                            gridViewOrderList.DeleteRow(i);
                            break;
                        }
                    }
                }
                else
                    codeRows[0]["Qty"] = sumQty;
            }
        }

        /// <summary>
        /// 设定当前行选择
        /// </summary>
        private void repCheckSelect_EditValueChanged(object sender, EventArgs e)
        {
            if (DataTypeConvert.GetBoolean(gridViewOrderHead.GetFocusedDataRow()["Select"]))
                gridViewOrderHead.GetFocusedDataRow()["Select"] = false;
            else
                gridViewOrderHead.GetFocusedDataRow()["Select"] = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_Order.Tables[0].Select("select=1"), gridViewOrderHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);

            onlySelectColChangeRowState = true;
        }

        /// <summary>
        /// 鼠标操作明细行事件
        /// </summary>
        private void gridViewOrderList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (btnNew.Enabled)
                {
                    //if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                    //{
                    //    barButtonUp_ItemClick(null, null);
                    //}
                    if (e.Button == MouseButtons.Right)
                    {
                        barButtonUp.Visibility= DevExpress.XtraBars.BarItemVisibility.Never;
                        barButtonDown.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        popupMenuList.ShowPopup(Control.MousePosition);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--鼠标操作明细行事件错误。", ex);
            }
        }

        /// <summary>
        /// 鼠标操作明细行事件
        /// </summary>
        private void gridViewPRPO_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (btnNew.Enabled)
                {
                    if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                    {
                        barButtonUp_ItemClick(null, null);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        barButtonUp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barButtonDown.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        barButtonPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        popupMenuList.ShowPopup(Control.MousePosition);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--鼠标操作明细行事件错误。", ex);
            }
        }

        /// <summary>
        /// 查询明细的上一级请购单
        /// </summary>
        private void barButtonUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridViewPRPO.GetFocusedDataRow() != null)
                {
                    string formNameStr = "FrmPrReq";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string prReqNoStr = DataTypeConvert.GetString(gridViewPRPO.GetFocusedDataRow()["PrReqNo"]);
                    int prListAutoId = DataTypeConvert.GetInt(gridViewPRPO.GetFocusedDataRow()["PRListId"]);
                    if (prReqNoStr == "" || prListAutoId == 0)
                        return;
                    FrmPrReq.queryPrReqNo = prReqNoStr;
                    FrmPrReq.queryListAutoId = prListAutoId;
                    ViewHandler.ShowRightWindow(formNameStr);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询明细的上一级请购单错误。", ex);
            }
        }

        /// <summary>
        /// 查询明细的下一级入库单
        /// </summary>
        private void barButtonDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridViewOrderList.GetFocusedDataRow() != null)
                {
                    string formNameStr = "FrmWarehouseWarrantQuery";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    int autoIdInt = DataTypeConvert.GetInt(gridViewOrderList.GetFocusedDataRow()["AutoId"]);
                    FrmWarehouseWarrantQuery.orderListAutoId = autoIdInt;
                    ViewHandler.ShowRightWindow(formNameStr);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询明细的下一级入库单错误。", ex);
            }
        }

        /// <summary>
        /// 零件预览
        /// </summary>
        private void barButtonPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //FrmEDrawingPreview.codeFileNameStr = DataTypeConvert.GetString(gridViewOrderList.GetFocusedDataRow()["CodeFileName"]);
                //FrmEDrawingPreview.partPathStr = new FrmPartsCodeDAO().QueryPartsCode_FilePath(FrmEDrawingPreview.codeFileNameStr);
                //if(FrmEDrawingPreview.partPathStr=="")
                //{
                //    MessageHandler.ShowMessageBox("未查询到零件的文件路径，请重新操作。");
                //    return;
                //}
                //FrmEDrawingPreview edrawingForm = new FrmEDrawingPreview();
                //edrawingForm.ShowDialog();
                string cfnStr = DataTypeConvert.GetString(gridViewOrderList.GetFocusedDataRow()["CodeFileName"]);
                string pString = string.Format("[{0}][{1}]", cfnStr, new FrmPartsCodeDAO().QueryPartsCode_FilePath(cfnStr));
                System.Diagnostics.Process.Start(Application.StartupPath + @"\SWPreview.exe", pString);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--零件预览错误。", ex);
            }
        }

        /// <summary>
        /// 检查是否有未填写字段
        /// </summary>
        private bool IsHaveBlankLine()
        {
            gridViewOrderList.FocusedRowHandle = 0;
            for (int i = 0; i < gridViewOrderList.DataRowCount; i++)
            {
                if (DataTypeConvert.GetString(gridViewOrderList.GetDataRow(i)["CodeFileName"]) == "")
                {
                    gridViewOrderList.Focus();
                    gridViewOrderList.FocusedColumn = colCodeFileName;
                    gridViewOrderList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewOrderList.GetDataRow(i)["Qty"]) == "")
                {
                    gridViewOrderList.Focus();
                    gridViewOrderList.FocusedColumn = colQty;
                    gridViewOrderList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewOrderList.GetDataRow(i)["Unit"]) == "")
                {
                    gridViewOrderList.Focus();
                    gridViewOrderList.FocusedColumn = colUnit;
                    gridViewOrderList.FocusedRowHandle = i;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 子表新增一行
        /// </summary>
        private void ListNewRow()
        {
            if (IsHaveBlankLine())
                return;

            //gridViewPrReqList.PostEditor();
            gridViewOrderList.AddNewRow();
            FocusedListView(true, "CodeFileName", gridViewOrderList.GetFocusedDataSourceRowIndex());
            //gridViewOrderList.RefreshData();
        }

        /// <summary>
        /// 设定按钮和表列状态
        /// </summary>
        /// <param name="ret">状态标准</param>
        private void SetButtonAndColumnState(bool ret)
        {
            if (ret)
            {
                btnNew.Enabled = false;
                btnSave.Text = "保存";
                btnCancel.Enabled = true;
                btnPrReqApply.Enabled = false;

                btnDelete.Enabled = false;
                btnSubmit.Enabled = false;
                btnCancelSubmit.Enabled = false;
                btnApprove.Enabled = false;
                btnCancelApprove.Enabled = false;
                btnClose.Enabled = false;
                btnCancelClose.Enabled = false;                
                btnPreview.Enabled = false;
            }
            else
            {
                btnNew.Enabled = true;
                btnSave.Text = "修改";
                btnCancel.Enabled = false;
                btnPrReqApply.Enabled = true;

                //btnDelete.Enabled = true;
                //btnSubmit.Enabled = true;
                //btnCancelSubmit.Enabled = true;
                //btnApprove.Enabled = true;
                //btnCancelApprove.Enabled = true;
                //btnClose.Enabled = true;
                //btnCancelClose.Enabled = true;                
                //btnPreview.Enabled = true;

                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_Order.Tables[0].Select("select=1"), gridViewOrderHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
            }
            btnListAdd.Enabled = ret;

            colPurCategory.OptionsColumn.AllowEdit = ret;
            colBussinessBaseNo.OptionsColumn.AllowEdit = ret;
            colReqDep.OptionsColumn.AllowEdit = ret;
            colTax.OptionsColumn.AllowEdit = ret;
            //colProjectNo.OptionsColumn.AllowEdit = ret;
            //colStnNo.OptionsColumn.AllowEdit = ret;
            colApprovalType.OptionsColumn.AllowEdit = ret;
            colPayTypeNo.OptionsColumn.AllowEdit = ret;
            colPlanDate.OptionsColumn.AllowEdit = ret;
            colPrReqRemark.OptionsColumn.AllowEdit = ret;

            //colCodeFileName.OptionsColumn.AllowEdit = ret;
            colUnit.OptionsColumn.AllowEdit = ret;
            //colQty.OptionsColumn.AllowEdit = ret;
            colAmount.OptionsColumn.AllowEdit = ret;
            colTax1.OptionsColumn.AllowEdit = ret;
            colSumAmount.OptionsColumn.AllowEdit = ret;
            colPlanDate1.OptionsColumn.AllowEdit = ret;
            colRemark.OptionsColumn.AllowEdit = ret;

            colPRQty.OptionsColumn.AllowEdit = ret;

            SetProjectIsEdit();
            gridViewOrderList_FocusedRowChanged(null, null);

            repbtnDelete.Buttons[0].Enabled = ret;
            repbtnPRPO.Buttons[0].Enabled = ret;
            repCheckSelect.ReadOnly = ret;
            checkAll.ReadOnly = ret;

            if (this.Controls.ContainsKey("lblEditFlag"))
            {
                //检测窗口状态：新增、修改="EDIT"，保存、取消=""
                if (ret)
                {
                    ((Label)this.Controls["lblEditFlag"]).Text = "EDIT";
                }
                else
                {
                    ((Label)this.Controls["lblEditFlag"]).Text = "";
                }
            }
        }

        /// <summary>
        /// 检测请购单状态是否可以操作
        /// </summary>
        private bool CheckReqState()
        {
            if (gridViewOrderHead.GetFocusedDataRow() == null)
                return false;
            int reqState = DataTypeConvert.GetInt(gridViewOrderHead.GetFocusedDataRow()["ReqState"]);
            switch (reqState)
            {
                case (int)CommonHandler.OrderState.已审批:
                    MessageHandler.ShowMessageBox(string.Format("采购订单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["OrderHeadNo"]), CommonHandler.OrderState.已审批));
                    return false;
                case (int)CommonHandler.OrderState.已关闭:
                    MessageHandler.ShowMessageBox(string.Format("采购订单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["OrderHeadNo"]), CommonHandler.OrderState.已关闭));
                    return false;
                case (int)CommonHandler.OrderState.审批中:
                    MessageHandler.ShowMessageBox(string.Format("采购订单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["OrderHeadNo"]), CommonHandler.OrderState.审批中));
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检测当前选中的请购单状态是否可以操作
        /// </summary>
        private bool CheckReqState_Multi(bool checkNoSubmit, bool checkApprover, bool checkClosed, bool checkApproverBetween, string messageStr)
        {
            for (int i = 0; i < gridViewOrderHead.DataRowCount; i++)
            {
                if (DataTypeConvert.GetBoolean(gridViewOrderHead.GetDataRow(i)["Select"]))
                {
                    int reqState = DataTypeConvert.GetInt(gridViewOrderHead.GetDataRow(i)["ReqState"]);
                    switch (reqState)
                    {
                        case (int)CommonHandler.OrderState.待提交:
                            if (checkNoSubmit)
                            {
                                MessageHandler.ShowMessageBox(string.Format("采购订单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewOrderHead.GetDataRow(i)["OrderHeadNo"]), messageStr, CommonHandler.OrderState.待提交));
                                gridViewOrderHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.OrderState.已审批:
                            if (checkApprover)
                            {
                                MessageHandler.ShowMessageBox(string.Format("采购订单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewOrderHead.GetDataRow(i)["OrderHeadNo"]), messageStr, CommonHandler.OrderState.已审批));
                                gridViewOrderHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.OrderState.已关闭:
                            if (checkClosed)
                            {
                                MessageHandler.ShowMessageBox(string.Format("采购订单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewOrderHead.GetDataRow(i)["OrderHeadNo"]), messageStr, CommonHandler.OrderState.已关闭));
                                gridViewOrderHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.OrderState.审批中:
                            if (checkApproverBetween)
                            {
                                MessageHandler.ShowMessageBox(string.Format("采购订单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewOrderHead.GetDataRow(i)["OrderHeadNo"]), messageStr, CommonHandler.OrderState.审批中));
                                gridViewOrderHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 聚焦主表当前行的列
        /// </summary>
        private void FocusedHeadView(string colName)
        {
            gridControlOrderHead.Focus();
            ColumnView headView = (ColumnView)gridControlOrderHead.FocusedView;
            headView.FocusedColumn = headView.Columns[colName];
            gridViewOrderHead.FocusedRowHandle = headView.FocusedRowHandle;
        }

        /// <summary>
        /// 聚焦子表当前行的列
        /// </summary>
        private void FocusedListView(bool isFocusedControl, string colName, int lineNo)
        {
            if (isFocusedControl)
                gridControlOrderList.Focus();
            ColumnView listView = (ColumnView)gridControlOrderList.FocusedView;
            listView.FocusedColumn = listView.Columns[colName];
            gridViewOrderList.FocusedRowHandle = lineNo;
        }

        /// <summary>
        /// 聚焦子表当前行的列
        /// </summary>
        private void FocusedSubListView(bool isFocusedControl, string colName, int lineNo)
        {
            if (isFocusedControl)
                gridControlPRPO.Focus();
            ColumnView listView = (ColumnView)gridControlPRPO.FocusedView;
            listView.FocusedColumn = listView.Columns[colName];
            gridViewPRPO.FocusedRowHandle = lineNo;
        }

        /// <summary>
        /// 绑定站号的ComboBox控件
        /// </summary>
        private void BingStnListComboBox()
        {
            string tmpStr = DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["ProjectNo"]);
            DataTable stnListTable = commonDAO.QueryStnList(tmpStr);
            repComboBoxStnNo.Items.Clear();
            for (int i = 0; i < stnListTable.Rows.Count; i++)
            {
                repComboBoxStnNo.Items.Add(DataTypeConvert.GetString(stnListTable.Rows[i]["StnNo"]));
            }
        }

        /// <summary>
        /// 清楚当前的所有选择
        /// </summary>
        private void ClearHeadGridAllSelect()
        {
            checkAll.Checked = false;
            for (int i = 0; i < dataSet_Order.Tables[0].Rows.Count; i++)
            {
                dataSet_Order.Tables[0].Rows[i]["Select"] = false;
            }
            dataSet_Order.Tables[0].AcceptChanges();
            onlySelectColChangeRowState = false;
        }

        /// <summary>
        /// 请购单转成采购单    --暂时不用这个通过打开窗体选择，直接拖拽选择
        /// </summary>
        /// <param name="prReqHeadRow"></param>
        /// <param name="prReqListTable"></param>
        private void PRToPO_Order(DataRow prReqHeadRow, DataTable prReqListTable)
        {
            ClearHeadGridAllSelect();
            gridViewOrderHead.AddNewRow();
            FocusedHeadView("BussinessBaseNo");

            gridViewOrderHead.SetFocusedRowCellValue("PurCategory", prReqHeadRow["PurCategory"]);
            gridViewOrderHead.SetFocusedRowCellValue("ReqDep", prReqHeadRow["ReqDep"]);
            //gridViewPrReqHead.SetFocusedRowCellValue("BussinessBaseNo", orderDAO.GetBussinessBaseNo_ProjectNo(DataTypeConvert.GetString(prReqHeadRow["ProjectNo"])));
            gridViewOrderHead.SetFocusedRowCellValue("ProjectNo", prReqHeadRow["ProjectNo"]);
            gridViewOrderHead.SetFocusedRowCellValue("StnNo", prReqHeadRow["StnNo"]);

            dataSet_Order.Tables[1].Clear();
            foreach (DataRow dr in prReqListTable.Rows)
            {
                if (DataTypeConvert.GetBoolean(dr["ListSelect"]))
                {
                    gridViewOrderList.AddNewRow();
                    gridViewOrderList.SetFocusedRowCellValue("CodeId", dr["CodeId"]);
                    gridViewOrderList.SetFocusedRowCellValue("CodeFileName", dr["CodeFileName"]);
                    gridViewOrderList.SetFocusedRowCellValue("CodeName", dr["CodeName"]);
                    gridViewOrderList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(dr["Overplus"]));
                    gridViewOrderList.SetFocusedRowCellValue("PrReqNo", dr["PrReqNo"]);
                    gridViewOrderList.SetFocusedRowCellValue("PrListAutoId", dr["AutoId"]);
                }
            }
            gridViewOrderList.RefreshData();
            FocusedListView(false, "Unit", gridViewOrderList.GetFocusedDataSourceRowIndex());

            SetButtonAndColumnState(true);
            headFocusedLineNo = gridViewOrderHead.DataRowCount;
        }

        /// <summary>
        /// 设定项目号和站号是否可以进行修改
        /// </summary>
        private void SetProjectIsEdit()
        {
            if (!btnNew.Enabled)
            {
                int count = 0;
                foreach (DataRow dr in dataTablePRPO.Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                        count++;
                }

                if (count == 0)
                {
                    colProjectNo.OptionsColumn.AllowEdit = true;
                    colProjectNo.OptionsColumn.TabStop = true;
                    colStnNo.OptionsColumn.AllowEdit = true;
                    colStnNo.OptionsColumn.TabStop = true;
                    return;
                }
            }

            colProjectNo.OptionsColumn.AllowEdit = false;
            colProjectNo.OptionsColumn.TabStop = false;
            colStnNo.OptionsColumn.AllowEdit = false;
            colStnNo.OptionsColumn.TabStop = false;
        }

        #endregion

        #region 左侧请购单模块的相关事件和方法

        /// <summary>
        /// 查询请购单事件
        /// </summary>
        private void btnPrReqQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (dateReqDateBegin.EditValue == null || dateReqDateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("请购日期不能为空，请设置后重新进行查询。");
                    if (dateReqDateBegin.EditValue == null)
                        dateReqDateBegin.Focus();
                    else
                        dateReqDateEnd.Focus();
                    return;
                }
                string prReqNoStr = textPrReqNo.Text.Trim();
                string orderDateBeginStr = dateReqDateBegin.DateTime.ToString("yyyy-MM-dd");
                string orderDateEndStr = dateReqDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                string projectNoStr = searchLookUpProjectNo.Text != "全部" ? DataTypeConvert.GetString(searchLookUpProjectNo.EditValue) : "";

                dataSet_PrReq.Tables[0].Clear();
                dataSet_PrReq.Tables[1].Clear();
                applyDAO.QueryPrReqHead(dataSet_PrReq.Tables[0], prReqNoStr, orderDateBeginStr, orderDateEndStr, "", "", 0, projectNoStr, "");
                //if (prReqNoStr != "" && dataSet_PrReq.Tables[0].Rows.Count > 0)
                //    textPrReqNo.Text = "";
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询请购单事件错误。", ex);
            }
        }

        /// <summary>
        /// 聚焦查询请购单明细事件
        /// </summary>
        private void gridViewPrReqHead_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewPrReqHead.GetFocusedDataRow() != null && sender != null)
                {
                    dataSet_PrReq.Tables[1].Clear();
                    applyDAO.QueryPrReqList(dataSet_PrReq.Tables[1], DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]));
                    ClearAlreadyDragPrReqList();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--聚焦查询请购单明细事件错误。", ex);
            }
        }

        #region 拖出

        /// <summary>
        /// 在GridView中按下鼠标事件
        /// </summary>
        private void gridViewPrReqList_MouseDown(object sender, MouseEventArgs e)
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
        private void gridViewPrReqList_MouseMove(object sender, MouseEventArgs e)
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

        #region 拖入

        /// <summary>
        /// 拖拽在GridControl上面
        /// </summary>
        private void gridControlOrderList_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<DataRow>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// 拖拽进入到GridControl控件
        /// </summary>
        private void gridControlOrderList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 实现拖拽请购单事件
        /// </summary>
        private void gridControlOrderList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                List<DataRow> drs = e.Data.GetData(typeof(List<DataRow>)) as List<DataRow>;
                if (drs != null)
                {
                    PRToPO_DragOrder(sender, drs);
                    ClearAlreadyDragPrReqList();
                    SetProjectIsEdit();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--实现拖拽请购单事件错误。", ex);
            }
        }

        /// <summary>
        /// 拖拽请购单转成采购订单 
        /// </summary>
        private void PRToPO_DragOrder(object sender, List<DataRow> drs)
        { 
            subLock = true;

            bool isMerge = true;
            bool isMessage = true;
            int dbListMaxAutoIdInt = orderDAO.GetOrderListMaxAutoId();

            DataRow headRow = gridViewPrReqHead.GetFocusedDataRow();

            if (btnNew.Enabled)
            {
                ClearHeadGridAllSelect();
                gridViewOrderHead.AddNewRow();
                FocusedHeadView("BussinessBaseNo");

                gridViewOrderHead.SetFocusedRowCellValue("PurCategory", headRow["PurCategory"]);
                gridViewOrderHead.SetFocusedRowCellValue("ReqDep", headRow["ReqDep"]);
                //gridViewPrReqHead.SetFocusedRowCellValue("BussinessBaseNo", orderDAO.GetBussinessBaseNo_ProjectNo(DataTypeConvert.GetString(prReqHeadRow["ProjectNo"])));
                gridViewOrderHead.SetFocusedRowCellValue("ProjectNo", headRow["ProjectNo"]);
                gridViewOrderHead.SetFocusedRowCellValue("StnNo", headRow["StnNo"]);

                dataSet_Order.Tables[1].Clear();
                dataSet_Order.Tables[2].Clear();

                //foreach (DataRow dr in drs)
                //{
                //    gridViewOrderList.AddNewRow();
                //    gridViewOrderList.SetFocusedRowCellValue("CodeId", dr["CodeId"]);
                //    gridViewOrderList.SetFocusedRowCellValue("CodeFileName", dr["CodeFileName"]);
                //    gridViewOrderList.SetFocusedRowCellValue("CodeName", dr["CodeName"]);
                //    gridViewOrderList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(dr["Overplus"]));
                //    gridViewOrderList.SetFocusedRowCellValue("PrReqNo", dr["PrReqNo"]);
                //    gridViewOrderList.SetFocusedRowCellValue("PrListAutoId", dr["AutoId"]);
                //}

                InsertList(headRow, drs, ref isMessage, ref isMerge, dbListMaxAutoIdInt);

                gridViewPRPO.RefreshData();
                gridViewPRPO.UpdateTotalSummary();
                gridViewOrderList.RefreshData();

                FocusedListView(false, "Unit", gridViewOrderList.GetFocusedDataSourceRowIndex());
                FocusedSubListView(false, "PRQty", gridViewPRPO.GetFocusedDataSourceRowIndex());

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewOrderHead.DataRowCount;
            }
            else
            {
                string currentProNo = DataTypeConvert.GetString(gridViewOrderHead.GetFocusedDataRow()["ProjectNo"]);
                if (dataSet_Order.Tables[1].Rows.Count > 0)
                {
                    if (currentProNo != "" && currentProNo != DataTypeConvert.GetString(headRow["ProjectNo"]))
                    {
                        MessageHandler.ShowMessageBox("一张采购订单只允许相同的项目号进行登记。");
                        return;
                    }
                }

                if(currentProNo =="")
                {
                    gridViewOrderHead.SetFocusedRowCellValue("ProjectNo", headRow["ProjectNo"]);
                    gridViewOrderHead.SetFocusedRowCellValue("StnNo", headRow["StnNo"]);
                }

                //foreach (DataRow dr in drs)
                //{
                //    if (dataSet_Order.Tables[1].Select(string.Format("PrListAutoId={0}", DataTypeConvert.GetString(dr["AutoId"]))).Length > 0)
                //        continue;
                //    gridViewOrderList.AddNewRow();
                //    gridViewOrderList.SetFocusedRowCellValue("CodeId", dr["CodeId"]);
                //    gridViewOrderList.SetFocusedRowCellValue("CodeFileName", dr["CodeFileName"]);
                //    gridViewOrderList.SetFocusedRowCellValue("CodeName", dr["CodeName"]);
                //    gridViewOrderList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(dr["Overplus"]));
                //    gridViewOrderList.SetFocusedRowCellValue("PrReqNo", dr["PrReqNo"]);
                //    gridViewOrderList.SetFocusedRowCellValue("PrListAutoId", dr["AutoId"]);
                //}

                InsertList(headRow, drs, ref isMessage, ref isMerge, dbListMaxAutoIdInt);

                gridViewOrderList.FocusedRowHandle = gridViewOrderList.DataRowCount;
                gridViewPRPO.FocusedRowHandle = gridViewPRPO.DataRowCount;
                FocusedListView(false, "Unit", gridViewOrderList.GetFocusedDataSourceRowIndex());
                FocusedSubListView(false, "PRQty", gridViewPRPO.GetFocusedDataSourceRowIndex());

                gridViewPRPO.RefreshData();
                gridViewPRPO.UpdateTotalSummary();
                gridViewOrderList.RefreshData();
            }

            subLock = false;
        }

        /// <summary>
        /// 新增列表明细
        /// </summary>
        private void InsertList(DataRow headRow, List<DataRow> drs, ref bool isMessage, ref bool isMerge, int dbListMaxAutoIdInt)
        {
            foreach (DataRow dr in drs)
            {
                if (dataTablePRPO.Select(string.Format("PRListId = {0}", DataTypeConvert.GetInt(dr["AutoId"]))).Length > 0)
                    continue;

                DataRow[] codeRows = dataSet_Order.Tables[1].Select(string.Format("CodeId = {0}", DataTypeConvert.GetInt(dr["CodeId"])));

                if (isMessage && codeRows.Length > 0)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("采购询价单明细中有相同的零件，是否合并成一条记录？") == DialogResult.Yes)
                        isMerge = true;
                    else
                        isMerge = false;
                    isMessage = false;
                }

                int listAutoIdInt = DataTypeConvert.GetInt(dataTableOrderList.Compute("Max(AutoId)", "")) + 1;
                if (listAutoIdInt < dbListMaxAutoIdInt)
                    listAutoIdInt = dbListMaxAutoIdInt + 1;

                if (codeRows.Length == 0 || !isMerge)
                {
                    gridViewOrderList.AddNewRow();
                    gridViewOrderList.SetFocusedRowCellValue("AutoId", listAutoIdInt);
                    gridViewOrderList.SetFocusedRowCellValue("CodeId", dr["CodeId"]);
                    gridViewOrderList.SetFocusedRowCellValue("CodeFileName", dr["CodeFileName"]);
                    gridViewOrderList.SetFocusedRowCellValue("CodeName", dr["CodeName"]);
                    //gridViewOrderList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(dr["Overplus"]));
                    //gridViewOrderList.SetFocusedRowCellValue("PrReqNo", dr["PrReqNo"]);
                    //gridViewOrderList.SetFocusedRowCellValue("PrListAutoId", dr["AutoId"]);
                }

                gridViewPRPO.AddNewRow();

                gridViewPRPO.SetFocusedRowCellValue("PRListId", dr["AutoId"]);
                gridViewPRPO.SetFocusedRowCellValue("CodeId", dr["CodeId"]);
                gridViewPRPO.SetFocusedRowCellValue("CodeFileName", dr["CodeFileName"]);
                gridViewPRPO.SetFocusedRowCellValue("PRQty", dr["Overplus"]);
                gridViewPRPO.SetFocusedRowCellValue("PrReqNo", dr["PrReqNo"]);
                gridViewPRPO.SetFocusedRowCellValue("ProjectNo", headRow["ProjectNo"]);
                gridViewPRPO.SetFocusedRowCellValue("StnNo", headRow["StnNo"]);
                gridViewPRPO.SetFocusedRowCellValue("MaxPRQty", dr["Overplus"]);

                if (codeRows.Length == 0 || !isMerge)
                {
                    gridViewPRPO.SetFocusedRowCellValue("POListId", gridViewOrderList.GetFocusedDataRow()["AutoId"]);
                    gridViewOrderList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(dr["Overplus"]));
                }
                else
                {
                    gridViewPRPO.SetFocusedRowCellValue("POListId", codeRows[0]["AutoId"]);
                    codeRows[0]["Qty"] = DataTypeConvert.GetDouble(codeRows[0]["Qty"]) + DataTypeConvert.GetDouble(dr["Overplus"]);
                }

                gridViewOrderList.RefreshData();
            }
        }

        #endregion

        /// <summary>
        /// 清空已经拖拽的请购单明细
        /// </summary>
        private void ClearAlreadyDragPrReqList()
        {
            for (int i = dataSet_PrReq.Tables[1].Rows.Count - 1; i >= 0; i--)
            {
                if (dataSet_Order.Tables[2].Select(string.Format("PRListId={0}", DataTypeConvert.GetString(dataSet_PrReq.Tables[1].Rows[i]["AutoId"]))).Length > 0)
                    dataSet_PrReq.Tables[1].Rows.RemoveAt(i);
            }
        }

        #endregion
    }
}
