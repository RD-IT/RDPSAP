﻿using DevExpress.XtraGrid.Views.Base;
using PSAP.DAO.BSDAO;
using PSAP.DAO.PURDAO;
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
    public partial class FrmPrReq : DockContent
    {
        #region 私有变量

        FrmPrReqDAO prReqDAO = new FrmPrReqDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        /// <summary>
        /// 主表聚焦的行号
        /// </summary>
        int headFocusedLineNo = 0;

        /// <summary>
        /// 查询的请购单号
        /// </summary>
        public static string queryPrReqNo = "";

        /// <summary>
        /// 查询的明细AutoId
        /// </summary>
        public static int queryListAutoId = 0;

        /// <summary>
        /// 只有选择列改变行状态的时候
        /// </summary>
        bool onlySelectColChangeRowState = false;

        static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();
        #endregion

        #region 构造方法

        public FrmPrReq()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(this);
            PSAP.BLL.BSBLL.BSBLL.language(f);

        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPrReq_Load(object sender, EventArgs e)
        {
            try
            {
                //ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd, checkAll });
                ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd });

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateReqDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateReqDateEnd.DateTime = nowDate.Date;

                lookUpReqDep.Properties.DataSource = commonDAO.QueryDepartment(true);
                lookUpReqDep.ItemIndex = 0;
                lookUpPurCategory.Properties.DataSource = commonDAO.QueryPurCategory(true);
                lookUpPurCategory.ItemIndex = 0;                

                ControlCommonInit ctlInit = new ControlCommonInit();
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpApprover);
                searchLookUpApprover.EditValue = null;
                ctlInit.RepositoryItemSearchLookUpEdit_PartsCode(repSearchCodeFileName, "CodeFileName", "CodeFileName");
                ctlInit.RepositoryItemSearchLookUpEdit_ProjectList(repSearchProjectNo, "ProjectNo", "ProjectNo");
                ctlInit.ComboBoxEdit_OrderState_Submit(comboBoxReqState);
                comboBoxReqState.SelectedIndex = 0;

                repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                repLookUpPurCategory.DataSource = commonDAO.QueryPurCategory(false);
                //repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);
                //repSearchProjectNo.DataSource = commonDAO.QueryProjectList(false);
                repLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;

                //repSearchCodeFileName.DataSource = commonDAO.QueryPartsCode(false);

                if (textCommon.Text == "")
                {
                    prReqDAO.QueryPrReqHead(dataSet_PrReq.Tables[0], "", "", "", "", 0, 0, -1, "", true);
                }

                if (SystemInfo.DisableProjectNo)
                {
                    colProjectNo.Visible = false;
                    colStnNo.Visible = false;
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
        private void FrmPrReq_Activated(object sender, EventArgs e)
        {
            try
            {
                if (queryPrReqNo != "")
                {
                    textCommon.Text = queryPrReqNo;
                    queryPrReqNo = "";
                    lookUpReqDep.ItemIndex = 0;
                    lookUpPurCategory.ItemIndex = 0;
                    comboBoxReqState.SelectedIndex = 0;
                    searchLookUpCreator.EditValue = 0;
                    searchLookUpApprover.EditValue = null;

                    dataSet_PrReq.Tables[0].Clear();
                    headFocusedLineNo = 0;
                    prReqDAO.QueryPrReqHead(dataSet_PrReq.Tables[0], "", "", "", "", 0, 0, -1, textCommon.Text, false);
                    SetButtonAndColumnState(false);

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
        private void FrmPrReq_Shown(object sender, EventArgs e)
        {
            pnlMiddle.Height = (this.Height - pnltop.Height) / 2;
        }

        #endregion

        #region 下面请购单模块的相关事件和方法

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

                if (dateReqDateBegin.EditValue == null || dateReqDateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("请购日期不能为空，请设置后重新进行查询。");
                    if (dateReqDateBegin.EditValue == null)
                        dateReqDateBegin.Focus();
                    else
                        dateReqDateEnd.Focus();
                    return;
                }
                string reqDateBeginStr = dateReqDateBegin.DateTime.ToString("yyyy-MM-dd");
                string reqDateEndStr = dateReqDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                string reqDepStr = lookUpReqDep.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpReqDep.EditValue) : "";
                string purCategoryStr = lookUpPurCategory.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpPurCategory.EditValue) : "";
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
                dataSet_PrReq.Tables[0].Clear();
                dataSet_PrReq.Tables[1].Clear();
                headFocusedLineNo = 0;
                prReqDAO.QueryPrReqHead(dataSet_PrReq.Tables[0], reqDateBeginStr, reqDateEndStr, reqDepStr, purCategoryStr, reqStateInt, creatorInt, approverInt, commonStr, false);

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
        private void gridViewPrReqHead_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewPrReqHead.GetFocusedDataRow() != null)
                {
                    if (onlySelectColChangeRowState)
                    {
                        dataSet_PrReq.Tables[0].AcceptChanges();
                        onlySelectColChangeRowState = false;

                        if (btnNew.Enabled)
                            ControlHandler.SetButtonBar_EnabledState_Order(dataSet_PrReq.Tables[0].Select("select=1"), gridViewPrReqHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
                    }
                    else
                    {
                        if (headFocusedLineNo < gridViewPrReqHead.DataRowCount && gridViewPrReqHead.FocusedRowHandle != headFocusedLineNo && gridViewPrReqHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                        {
                            MessageHandler.ShowMessageBox("当前请购单已经修改，请保存后再进行换行。");
                            gridViewPrReqHead.FocusedRowHandle = headFocusedLineNo;
                        }
                        else if (headFocusedLineNo == gridViewPrReqHead.DataRowCount)
                        {

                        }
                        else
                        {
                            if (gridViewPrReqHead.FocusedRowHandle != headFocusedLineNo && gridViewPrReqHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                            else if (gridViewPrReqHead.GetDataRow(headFocusedLineNo).RowState == DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                        }
                    }

                    if (DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]) != "")
                    {
                        dataSet_PrReq.Tables[1].Clear();
                        prReqDAO.QueryPrReqList(dataSet_PrReq.Tables[1], DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]));
                        if (queryListAutoId > 0)
                        {
                            for (int i = 0; i < gridViewPrReqList.DataRowCount; i++)
                            {
                                if (DataTypeConvert.GetInt(gridViewPrReqList.GetDataRow(i)["AutoId"]) == queryListAutoId)
                                {
                                    gridViewPrReqList.FocusedRowHandle = i;
                                    queryListAutoId = 0;
                                    break;
                                }
                            }
                        }
                    }

                    if (gridViewPrReqHead.FocusedRowHandle >= 0)
                    {
                        headFocusedLineNo = gridViewPrReqHead.FocusedRowHandle;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--主表聚焦行改变事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewPrReqHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        private void gridViewPrReqHead_KeyDown(object sender, KeyEventArgs e)
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
        private void gridViewPrReqHead_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "ReqState")
            {
                e.DisplayText = CommonHandler.Get_OrderState_Desc(e.Value.ToString());
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
                gridViewPrReqHead.AddNewRow();
                FocusedHeadView("ReqDep");

                dataSet_PrReq.Tables[1].Clear();
                gridViewPrReqList.AddNewRow();
                FocusedListView(false, "CodeFileName", gridViewPrReqList.GetFocusedDataSourceRowIndex());
                gridViewPrReqList.RefreshData();

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewPrReqHead.DataRowCount;
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

                if (gridViewPrReqHead.GetFocusedDataRow() == null)
                    return;

                if (!CheckReqState())
                    return;

                if (btnSave.Tag.ToString() != "保存")
                {
                    ClearHeadGridAllSelect();

                    SetButtonAndColumnState(true);
                    FocusedHeadView("ReqDep");
                    BingStnListComboBox();
                }
                else
                {
                    DataRow headRow = gridViewPrReqHead.GetFocusedDataRow();
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
                    if (DataTypeConvert.GetString(headRow["PurCategory"]) == "")
                    {
                        MessageHandler.ShowMessageBox("采购类型不能为空，请填写后再进行保存。");
                        FocusedHeadView("PurCategory");
                        return;
                    }
                    //if (DataTypeConvert.GetString(headRow["ApprovalType"]) == "")
                    //{
                    //    MessageHandler.ShowMessageBox("审批类型不能为空，请填写后再进行保存。");
                    //    FocusedHeadView("ApprovalType");
                    //    return;
                    //}

                    if (!commonDAO.StnNoIsContainProjectNo(DataTypeConvert.GetString(headRow["ProjectNo"]), DataTypeConvert.GetString(headRow["StnNo"])))
                    {
                        MessageHandler.ShowMessageBox("输入的站号不属于项目号，请重新填写后再进行保存。");
                        FocusedHeadView("StnNo");
                        return;
                    }

                    for (int i = gridViewPrReqList.DataRowCount - 1; i >= 0; i--)
                    {
                        DataRow listRow = gridViewPrReqList.GetDataRow(i);
                        if (DataTypeConvert.GetString(listRow["CodeFileName"]) == "")
                        {
                            gridViewPrReqList.DeleteRow(i);
                            continue;
                        }
                        if (DataTypeConvert.GetString(listRow["Qty"]) == "")
                        {
                            MessageHandler.ShowMessageBox("数量不能为空，请填写后再进行保存。");
                            FocusedListView(true, "Qty", i);
                            return;
                        }
                    }

                    int ret = prReqDAO.SavePrReq(gridViewPrReqHead.GetFocusedDataRow(), dataSet_PrReq.Tables[1]);
                    switch (ret)
                    {
                        case -1:
                            btnQuery_Click(null, null);
                            break;
                        case 1:
                            dataSet_PrReq.Tables[1].Clear();
                            prReqDAO.QueryPrReqList(dataSet_PrReq.Tables[1], DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]));
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

                if (gridViewPrReqHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                {
                    if (DataTypeConvert.GetString(gridViewPrReqHead.GetDataRow(headFocusedLineNo)["PrReqNo"]) == "")
                    {
                        gridViewPrReqHead.DeleteRow(headFocusedLineNo);
                    }
                    else
                    {
                        gridViewPrReqHead.GetFocusedDataRow().RejectChanges();
                    }
                }

                SetButtonAndColumnState(false);

                dataSet_PrReq.Tables[1].Clear();
                if (gridViewPrReqHead.GetFocusedDataRow() != null)
                    prReqDAO.QueryPrReqList(dataSet_PrReq.Tables[1], DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]));
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

                int count = dataSet_PrReq.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox(f.tsmiQzyczdjlq.Text);// ("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckReqState_Multi(false, true, true, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要删除当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                //prReqDAO.DeletePrReq(DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]));
                if (!prReqDAO.DeletePrReq_Multi(dataSet_PrReq.Tables[0]))
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
        /// 提交按钮事件
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int count = dataSet_PrReq.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                //if (!WorkFlowsHandleDAO.QueryWorkFlowsLineNextNodeIsEnabled(WorkFlowsHandleDAO.OrderType.请购单, WorkFlowsHandleDAO.LineType.提交))
                //{
                //    if (MessageHandler.ShowMessageBox_YesNo(string.Format("流程图中状态节点[提交]已经停用，确定要直接审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                //    {
                //        return;
                //    }
                //    else
                //    {
                //        ApprovePrReq(1);
                //        return;
                //    }
                //}

                if (!CheckReqState_Multi(false, true, true, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要提交当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!prReqDAO.SubmitPrReq_Multi(dataSet_PrReq.Tables[0]))
                    btnQuery_Click(null, null);

                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_PrReq.Tables[0].Select("select=1"), gridViewPrReqHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
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

                int count = dataSet_PrReq.Tables[0].Select("select=1").Length;
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
                if (!prReqDAO.CancelSubmitPrReq_Multi(dataSet_PrReq.Tables[0]))
                    btnQuery_Click(null, null);

                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_PrReq.Tables[0].Select("select=1"), gridViewPrReqHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--取消提交按钮事件错误。", ex);
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

                int count = dataSet_PrReq.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckReqState_Multi(true, true, true, false,"（请确保订单提交后再进行审批操作）"))
                    return;

                //if (count == 1)
                //{
                //    ////弹出审批页面
                //    //FrmPrReqApproval frmPrReq = new FrmPrReqApproval(DataTypeConvert.GetString(dataSet_PrReq.Tables[0].Select("select=1")[0]["PrReqNo"]));
                //    //if (frmPrReq.ShowDialog() == DialogResult.OK)
                //    //    btnQuery_Click(null, null);

                //    //弹出审批页面
                //    FrmOrderApproval frmOrder = new FrmOrderApproval(DataTypeConvert.GetString(dataSet_PrReq.Tables[0].Select("select=1")[0]["PrReqNo"]));
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
                //    DataRow[] drs = dataSet_PrReq.Tables[0].Select("select=1");
                //    for (int i = 0; i < drs.Length; i++)
                //    {
                //        dataNoList.Add(DataTypeConvert.GetString(drs[i]["PrReqNo"]));
                //    }

                //    FrmWorkFlowDataHandle wfDataHandle = new FrmWorkFlowDataHandle();
                //    wfDataHandle.orderNameStr = "请购单";
                //    wfDataHandle.dataNoList = dataNoList;
                //    wfDataHandle.workFlowTypeText = "采购流程";
                //    wfDataHandle.tableNameStr = "PUR_PrReqHead";
                //    wfDataHandle.moduleTypeInt = 2;
                //    if (wfDataHandle.ShowDialog() == DialogResult.OK)
                //    {
                //        int nodeIdInt = wfDataHandle.nodeIdInt;
                //        string flowModuleIdStr = wfDataHandle.flowModuleIdStr;
                //        string approverOptionStr = wfDataHandle.memoApproverOption.Text;
                //        int approverResultInt = DataTypeConvert.GetInt(wfDataHandle.radioApproverResult.EditValue);

                //        int successCountInt = 0;
                //        //直接审批，不再谈页面
                //        if (!prReqDAO.PrReqApprovalInfo_Multi(dataSet_PrReq.Tables[0], nodeIdInt, flowModuleIdStr, approverOptionStr, approverResultInt, ref successCountInt))
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

                ApprovePrReq(4);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--审批按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 审批请购单
        /// </summary>
        private void ApprovePrReq(int reqStateInt)
        {
            List<string> dataNoList = new List<string>();
            DataRow[] drs = dataSet_PrReq.Tables[0].Select("select=1");
            for (int i = 0; i < drs.Length; i++)
            {
                dataNoList.Add(DataTypeConvert.GetString(drs[i]["PrReqNo"]));
            }

            FrmWorkFlowsDataHandle wfDataHandle = new FrmWorkFlowsDataHandle();
            wfDataHandle.orderNameStr = "请购单";
            wfDataHandle.dataNoList = dataNoList;
            wfDataHandle.orderType = WorkFlowsHandleDAO.OrderType.请购单;
            if (wfDataHandle.ShowDialog() == DialogResult.OK)
            {
                string approverOptionStr = wfDataHandle.memoApproverOption.Text;
                int approverResultInt = DataTypeConvert.GetInt(wfDataHandle.radioApproverResult.EditValue);

                int successCountInt = reqStateInt;

                //直接审批，不再谈页面
                if (!prReqDAO.PrReqApprovalInfoNew_Multi(dataSet_PrReq.Tables[0], approverOptionStr, approverResultInt, ref successCountInt))
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
            ControlHandler.SetButtonBar_EnabledState_Order(dataSet_PrReq.Tables[0].Select("select=1"), gridViewPrReqHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
            //if (!prReqDAO.ApprovePrReq_Multi(dataSet_PrReq.Tables[0]))
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

                int count = dataSet_PrReq.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox(f.tsmiQzyczdjlq.Text);// ("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckReqState_Multi(true, false, true, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要取消审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }

                if (!prReqDAO.CancalPrReqApprovalInfo_Multi(dataSet_PrReq.Tables[0]))
                    btnQuery_Click(null, null);
                else
                {
                    MessageHandler.ShowMessageBox(string.Format("成功取消审批了{0}条记录。", count));
                }
                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_PrReq.Tables[0].Select("select=1"), gridViewPrReqHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
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

                int count = dataSet_PrReq.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox(f.tsmiQzyczdjlq.Text);// ("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckReqState_Multi(false, true, true, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要关闭当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!prReqDAO.ClosePrReq_Multi(dataSet_PrReq.Tables[0]))
                    btnQuery_Click(null, null);

                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_PrReq.Tables[0].Select("select=1"), gridViewPrReqHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
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

                int count = dataSet_PrReq.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox(f.tsmiQzyczdjlq.Text);// ("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckReqState_Multi(true, true, false, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要取消关闭当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!prReqDAO.CancelClosePrReq_Multi(dataSet_PrReq.Tables[0]))
                    btnQuery_Click(null, null);

                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_PrReq.Tables[0].Select("select=1"), gridViewPrReqHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--取消关闭按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                //DataSet ds = new DataSet();
                //DataTable dt1 = dataSet_PrReq.Tables[0].Clone();
                //dt1.ImportRow(gridViewPrReqHead.GetFocusedDataRow());
                //DataTable dt2 = dataSet_PrReq.Tables[1].Copy();
                //ds.Tables.Add(dt1);
                //ds.Tables.Add(dt2);
                //List<DevExpress.XtraReports.Parameters.Parameter> paralist = ReportHandler.GetSystemInfo_ParamList();
                //ReportHandler.XtraReport_Handle(new REPORT.XReport_PrReq(), "Report_PrReq.repx", ds, paralist, 1);

                string prReqNoStr = "";
                DataRow dr = null;
                DataRow[] drs = dataSet_PrReq.Tables[0].Select("select=1");
                if (drs.Length > 1)
                {
                    MessageHandler.ShowMessageBox("只能选中一条记录进行打印预览，请重新选择。");
                    return;
                }
                else if (drs.Length == 0)
                {
                    if (gridViewPrReqHead.GetFocusedDataRow() != null)
                    {
                        prReqNoStr = DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]);
                        dr = gridViewPrReqHead.GetFocusedDataRow();
                    }
                }
                else
                {
                    prReqNoStr = DataTypeConvert.GetString(drs[0]["PrReqNo"]);
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

                prReqDAO.PrintHandle(prReqNoStr, 1);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--打印预览操作错误。", ex);
            }
        }
        
        ///// <summary>
        ///// 打印设计
        ///// </summary>
        //private void btnDesigner_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //DataSet ds = new DataSet();
        //        //DataTable dt1 = dataSet_PrReq.Tables[0].Clone();
        //        //dt1.ImportRow(gridViewPrReqHead.GetFocusedDataRow());
        //        //DataTable dt2 = dataSet_PrReq.Tables[1].Copy();
        //        //ds.Tables.Add(dt1);
        //        //ds.Tables.Add(dt2);
        //        //List<DevExpress.XtraReports.Parameters.Parameter> paralist = ReportHandler.GetSystemInfo_ParamList();
        //        //ReportHandler.XtraReport_Handle(new REPORT.XReport_PrReq(), "Report_PrReq.repx", ds, paralist, 3);

        //        string prReqNoStr = "";
        //        if (gridViewPrReqHead.GetFocusedDataRow() != null)
        //            prReqNoStr = DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]);
        //        prReqDAO.PrintHandle(prReqNoStr, 3);
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
            foreach (DataRow dr in dataSet_PrReq.Tables[0].Rows)
            {
                dr["Select"] = value;
            }
            onlySelectColChangeRowState = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_PrReq.Tables[0].Select("select=1"), gridViewPrReqHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
        }

        /// <summary>
        /// 子表新增一行事件
        /// </summary>
        private void btnListAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!colPrReqListRemark.OptionsColumn.AllowEdit)
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
        private void gridViewPrReqHead_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridViewPrReqHead.SetFocusedRowCellValue("ReqDate", BaseSQL.GetServerDateTime());
                gridViewPrReqHead.SetFocusedRowCellValue("ReqDep", SystemInfo.user.DepartmentNo);
                gridViewPrReqHead.SetFocusedRowCellValue("PurCategory", DataTypeConvert.GetString(((DataTable)lookUpPurCategory.Properties.DataSource).Rows[1]["PurCategory"]));
                gridViewPrReqHead.SetFocusedRowCellValue("ReqState", 1);
                gridViewPrReqHead.SetFocusedRowCellValue("Creator", SystemInfo.user.AutoId);

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
        private void gridViewPrReqList_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridViewPrReqList.SetFocusedRowCellValue("PrReqNo", DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]));
                gridViewPrReqList.SetFocusedRowCellValue("RequirementDate", DataTypeConvert.GetDateTime(gridViewPrReqHead.GetFocusedDataRow()["ReqDate"]).AddDays(7));
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--子表设定默认值错误。", ex);
            }
        }

        /// <summary>
        /// 子表按键事件
        /// </summary>
        private void gridViewPrReqList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!colPrReqListRemark.OptionsColumn.AllowEdit)
                        return;

                    if (gridViewPrReqList.GetFocusedDataSourceRowIndex() >= gridViewPrReqList.DataRowCount - 1 && gridViewPrReqList.FocusedColumn == colPrReqListRemark)
                    {
                        ListNewRow();
                    }
                    else if (gridViewPrReqList.FocusedColumn == colPrReqListRemark)
                    {
                        gridViewPrReqList.FocusedRowHandle = gridViewPrReqList.FocusedRowHandle + 1;
                        FocusedListView(true, "CodeFileName", gridViewPrReqList.GetFocusedDataSourceRowIndex());
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
                if (gridViewPrReqList.GetFocusedDataRow().RowState != DataRowState.Added)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的明细记录吗？") != DialogResult.Yes)
                    {
                        return;
                    }
                }
                gridViewPrReqList.DeleteRow(gridViewPrReqList.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除子表中的一行错误。", ex);
            }
        }

        /// <summary>
        /// 主表单元格值变化进行的操作
        /// </summary>
        private void gridViewPrReqHead_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colProjectNo)
                {
                    string projectNoStr = DataTypeConvert.GetString(gridViewPrReqHead.GetDataRow(e.RowHandle)["ProjectNo"]);
                    if (projectNoStr == "")
                    {
                        gridViewPrReqHead.SetRowCellValue(e.RowHandle, "ProjectNo", "");
                        gridViewPrReqHead.SetRowCellValue(e.RowHandle, "StnNo", "");
                    }
                    else
                    {
                        gridViewPrReqHead.SetRowCellValue(e.RowHandle, "StnNo", "");
                    }

                    BingStnListComboBox();
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
        private void gridViewPrReqList_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                switch (e.Column.FieldName)
                {
                    case "CodeFileName":
                        string tmpStr = DataTypeConvert.GetString(gridViewPrReqList.GetDataRow(e.RowHandle)["CodeFileName"]);
                        if (tmpStr == "")
                        {
                            gridViewPrReqList.SetRowCellValue(e.RowHandle, "CodeId", null);
                            gridViewPrReqList.SetRowCellValue(e.RowHandle, "CodeName", "");                            
                        }
                        else
                        {
                            DataTable temp = (DataTable)repSearchCodeFileName.DataSource;
                            DataRow[] drs = temp.Select(string.Format("CodeFileName='{0}'", tmpStr));
                            if (drs.Length > 0)
                            {
                                gridViewPrReqList.SetRowCellValue(e.RowHandle, "CodeId", DataTypeConvert.GetString(drs[0]["AutoId"]));
                                gridViewPrReqList.SetRowCellValue(e.RowHandle, "CodeName", DataTypeConvert.GetString(drs[0]["CodeName"]));                                
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--子表单元格值变化进行的操作错误。", ex);
            }
        }

        /// <summary>
        /// 设定当前行选择
        /// </summary>
        private void repCheckSelect_EditValueChanged(object sender, EventArgs e)
        {
            if (DataTypeConvert.GetBoolean(gridViewPrReqHead.GetFocusedDataRow()["Select"]))
                gridViewPrReqHead.GetFocusedDataRow()["Select"] = false;
            else
                gridViewPrReqHead.GetFocusedDataRow()["Select"] = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_PrReq.Tables[0].Select("select=1"), gridViewPrReqHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);

            onlySelectColChangeRowState = true;
        }

        /// <summary>
        /// 鼠标操作明细行事件
        /// </summary>
        private void gridViewPrReqList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (btnNew.Enabled)
                {
                    if (e.Button == MouseButtons.Right)
                    {
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
        /// 查询明细的下一级采购订单
        /// </summary>
        private void barButtonUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridViewPrReqList.GetFocusedDataRow() != null)
                {
                    string formNameStr = "FrmOrderQuery";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    int autoIdInt = DataTypeConvert.GetInt(gridViewPrReqList.GetFocusedDataRow()["AutoId"]);
                    FrmOrderQuery.prReqListAutoId = autoIdInt;
                    ViewHandler.ShowRightWindow(formNameStr);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询明细的下一级采购订单错误。", ex);
            }
        }

        /// <summary>
        /// 检查是否有未填写字段
        /// </summary>
        private bool IsHaveBlankLine()
        {
            gridViewPrReqList.FocusedRowHandle = 0;
            for (int i = 0; i < gridViewPrReqList.DataRowCount; i++)
            {
                if (DataTypeConvert.GetString(gridViewPrReqList.GetDataRow(i)["CodeFileName"]) == "")
                {
                    gridViewPrReqList.Focus();
                    gridViewPrReqList.FocusedColumn = colCodeFileName;
                    gridViewPrReqList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewPrReqList.GetDataRow(i)["Qty"]) == "")
                {
                    gridViewPrReqList.Focus();
                    gridViewPrReqList.FocusedColumn = colQty;
                    gridViewPrReqList.FocusedRowHandle = i;
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
            gridViewPrReqList.AddNewRow();
            FocusedListView(true, "CodeFileName", gridViewPrReqList.GetFocusedDataSourceRowIndex());
            //gridViewPrReqList.RefreshData();
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
                btnSave.Tag = "保存";
                btnSave.Text = f.tsmiBc.Text;
                btnCancel.Enabled = true;
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
                btnSave.Tag = "修改";
                btnSave.Text = f.tsmiXg.Text;
                btnCancel.Enabled = false;
                //btnDelete.Enabled = true;
                //btnSubmit.Enabled = true;
                //btnCancelSubmit.Enabled = true;
                //btnApprove.Enabled = true;
                //btnCancelApprove.Enabled = true;
                //btnClose.Enabled = true;
                //btnCancelClose.Enabled = true;
                //btnPreview.Enabled = true;

                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_PrReq.Tables[0].Select("select=1"), gridViewPrReqHead.GetFocusedDataRow(), "ReqState", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, btnClose, btnCancelClose, btnPreview);
            }            
            btnListAdd.Enabled = ret;

            colReqDep.OptionsColumn.AllowEdit = ret;
            colProjectNo.OptionsColumn.AllowEdit = ret;
            colStnNo.OptionsColumn.AllowEdit = ret;
            colPurCategory.OptionsColumn.AllowEdit = ret;
            //colApprovalType.OptionsColumn.AllowEdit = ret;
            colPrReqRemark.OptionsColumn.AllowEdit = ret;

            colCodeFileName.OptionsColumn.AllowEdit = ret;
            colQty.OptionsColumn.AllowEdit = ret;
            colRequirementDate.OptionsColumn.AllowEdit = ret;
            colPrReqListRemark.OptionsColumn.AllowEdit = ret;

            repbtnDelete.Buttons[0].Enabled = ret;
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
            if (gridViewPrReqHead.GetFocusedDataRow() == null)
                return false;
            int reqState = DataTypeConvert.GetInt(gridViewPrReqHead.GetFocusedDataRow()["ReqState"]);
            switch (reqState)
            {
                case (int)CommonHandler.OrderState.已审批:
                    MessageHandler.ShowMessageBox(string.Format("请购单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]), CommonHandler.OrderState.已审批));
                    return false;
                case (int)CommonHandler.OrderState.已关闭:
                    MessageHandler.ShowMessageBox(string.Format("请购单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]), CommonHandler.OrderState.已关闭));
                    return false;
                case (int)CommonHandler.OrderState.审批中:
                    MessageHandler.ShowMessageBox(string.Format("请购单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]), CommonHandler.OrderState.审批中));
                    return false;
            }

            if (!SystemInfo.PrReqIsAlter_PSBomAutoId && gridViewPrReqHead.GetFocusedDataRow().RowState != DataRowState.Added)
            {
                if (prReqDAO.Query_PrReqList_PSBomAutoId(DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"])))
                {
                    MessageHandler.ShowMessageBox("请购单明细中包含由生产计划生成的信息，不可以操作。");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 检测当前选中的请购单状态是否可以操作
        /// </summary>
        private bool CheckReqState_Multi(bool checkNoSubmit, bool checkApprover, bool checkClosed, bool checkApproverBetween, string messageStr)
        {
            for (int i = 0; i < gridViewPrReqHead.DataRowCount; i++)
            {
                if (DataTypeConvert.GetBoolean(gridViewPrReqHead.GetDataRow(i)["Select"]))
                {
                    int reqState = DataTypeConvert.GetInt(gridViewPrReqHead.GetDataRow(i)["ReqState"]);
                    switch (reqState)
                    {
                        case (int)CommonHandler.OrderState.待提交:
                            if (checkNoSubmit)
                            {
                                MessageHandler.ShowMessageBox(string.Format("请购单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewPrReqHead.GetDataRow(i)["PrReqNo"]), messageStr, CommonHandler.OrderState.待提交));
                                gridViewPrReqHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.OrderState.已审批:
                            if (checkApprover)
                            {
                                MessageHandler.ShowMessageBox(string.Format("请购单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewPrReqHead.GetDataRow(i)["PrReqNo"]), messageStr, CommonHandler.OrderState.已审批));
                                gridViewPrReqHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.OrderState.已关闭:
                            if (checkClosed)
                            {
                                MessageHandler.ShowMessageBox(string.Format("请购单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewPrReqHead.GetDataRow(i)["PrReqNo"]), messageStr, CommonHandler.OrderState.已关闭));
                                gridViewPrReqHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.OrderState.审批中:
                            if (checkApproverBetween)
                            {
                                MessageHandler.ShowMessageBox(string.Format("请购单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewPrReqHead.GetDataRow(i)["PrReqNo"]), messageStr, CommonHandler.OrderState.审批中));
                                gridViewPrReqHead.FocusedRowHandle = i;
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
            gridControlPrReqHead.Focus();
            ColumnView headView = (ColumnView)gridControlPrReqHead.FocusedView;
            headView.FocusedColumn = headView.Columns[colName];
            gridViewPrReqHead.FocusedRowHandle = headView.FocusedRowHandle;
        }

        /// <summary>
        /// 聚焦子表当前行的列
        /// </summary>
        private void FocusedListView(bool isFocusedControl, string colName, int lineNo)
        {
            if (isFocusedControl)
                gridControlPrReqList.Focus();
            ColumnView listView = (ColumnView)gridControlPrReqList.FocusedView;
            listView.FocusedColumn = listView.Columns[colName];
            gridViewPrReqList.FocusedRowHandle = lineNo;
        }

        /// <summary>
        /// 绑定站号的ComboBox控件
        /// </summary>
        private void BingStnListComboBox()
        {
            string tmpStr = DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["ProjectNo"]);
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
            for (int i = 0; i < dataSet_PrReq.Tables[0].Rows.Count; i++)
            {
                dataSet_PrReq.Tables[0].Rows[i]["Select"] = false;
            }
            dataSet_PrReq.Tables[0].AcceptChanges();
            onlySelectColChangeRowState = false;
        }

        #endregion

    }
}
