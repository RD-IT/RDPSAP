using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using PSAP.DAO.BSDAO;
using PSAP.DAO.PBDAO;
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
    public partial class FrmProductionPlan : DockContent
    {
        #region 私有变量

        FrmProductionPlanDAO ppDAO = new FrmProductionPlanDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        /// <summary>
        /// 主表聚焦的行号
        /// </summary>
        int headFocusedLineNo = 0;

        /// <summary>
        /// 查询的工单号
        /// </summary>
        public static string queryPlanNo = "";

        /// <summary>
        /// 只有选择列改变行状态的时候
        /// </summary>
        bool onlySelectColChangeRowState = false;

        #endregion

        #region 构造方法

        public FrmProductionPlan()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmProductionPlan_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                datePlanDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                datePlanDateEnd.DateTime = nowDate.Date;

                DataTable codeIdInfoTable_f = commonDAO.QueryPartsCode(false);

                lookUpManufactureNo.Properties.DataSource = commonDAO.QueryManufactureInfo(true);
                lookUpManufactureNo.ItemIndex = 0;
                //searchLookUpCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(true);
                //searchLookUpCodeFileName.EditValue = 0;
                //searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(true);
                //searchLookUpProjectNo.Text = "全部";

                ControlCommonInit ctlInit = new ControlCommonInit();
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpApprover);
                searchLookUpApprover.EditValue = null;
                ctlInit.SearchLookUpEdit_PartsCode(searchLookUpCodeFileName, true);
                searchLookUpCodeFileName.EditValue = 0;
                ctlInit.SearchLookUpEdit_ProjectList(searchLookUpProjectNo, true);
                searchLookUpProjectNo.Text = "全部";
                ctlInit.ComboBoxEdit_OrderState_Submit(comboBoxCurrentStatus, false);
                comboBoxCurrentStatus.SelectedIndex = 0;

                //repSearchCodeId.DataSource = codeIdInfoTable_f;

                repLookUpManufactureNo.DataSource = commonDAO.QueryManufactureInfo(false);
                repSearchProjectNo.DataSource = searchLookUpProjectNo.Properties.DataSource;
                repLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;

                repLookUpCodeName.DataSource = codeIdInfoTable_f;
                repLookUpCodeId.DataSource = codeIdInfoTable_f;

                if (textCommon.Text == "")
                {
                    ppDAO.QueryProductionPlan(dataSet_ProductionPlan.Tables[0], "", "", 0, "", "", 0, 0, -1, "", true);
                }

                if (SystemInfo.DisableProjectNo)
                {
                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    colProjectNo.Visible = false;
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
        private void FrmProductionPlan_Activated(object sender, EventArgs e)
        {
            try
            {
                if (queryPlanNo != "")
                {
                    textCommon.Text = queryPlanNo;
                    queryPlanNo = "";
                    lookUpManufactureNo.ItemIndex = 0;
                    searchLookUpCodeFileName.EditValue = 0;
                    searchLookUpProjectNo.Text = "全部";
                    comboBoxCurrentStatus.SelectedIndex = 0;
                    searchLookUpCreator.EditValue = 0;
                    searchLookUpApprover.EditValue = null;

                    dataSet_ProductionPlan.Tables[0].Clear();
                    headFocusedLineNo = 0;
                    ppDAO.QueryProductionPlan(dataSet_ProductionPlan.Tables[0], "", "", 0, "", "", 0, 0, -1, textCommon.Text, false);
                    SetButtonAndColumnState(false);

                    if (dataSet_ProductionPlan.Tables[0].Rows.Count > 0)
                    {
                        datePlanDateBegin.DateTime = DataTypeConvert.GetDateTime(dataSet_ProductionPlan.Tables[0].Rows[0]["StartTime"]).Date;
                        datePlanDateEnd.DateTime = datePlanDateBegin.DateTime.AddDays(7);
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
        private void FrmProductionPlan_Shown(object sender, EventArgs e)
        {
            pnlMiddle.Height = (this.Height - pnltop.Height) / 2;
        }

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

                if (datePlanDateBegin.EditValue == null || datePlanDateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("计划日期不能为空，请设置后重新进行查询。");
                    if (datePlanDateBegin.EditValue == null)
                        datePlanDateBegin.Focus();
                    else
                        datePlanDateEnd.Focus();
                    return;
                }
                string reqDateBeginStr = datePlanDateBegin.DateTime.ToString("yyyy-MM-dd");
                string reqDateEndStr = datePlanDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                string manufactureNoStr = lookUpManufactureNo.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpManufactureNo.EditValue) : "";
                int codeIdInt = DataTypeConvert.GetInt(searchLookUpCodeFileName.EditValue);
                string projectNoStr = searchLookUpProjectNo.Text != "全部" ? DataTypeConvert.GetString(searchLookUpProjectNo.EditValue) : "";

                int currentStateInt = CommonHandler.Get_OrderState_No(comboBoxCurrentStatus.Text);
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
                dataSet_ProductionPlan.Tables[0].Rows.Clear();
                dataSet_ProductionPlan.Tables[1].Rows.Clear();
                headFocusedLineNo = 0;
                ppDAO.QueryProductionPlan(dataSet_ProductionPlan.Tables[0], reqDateBeginStr, reqDateEndStr, codeIdInt, manufactureNoStr, projectNoStr, currentStateInt, creatorInt, approverInt, commonStr, false);

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
        private void gridViewProductionPlan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewProductionPlan.GetFocusedDataRow() != null)
                {
                    if (onlySelectColChangeRowState)
                    {
                        dataSet_ProductionPlan.Tables[0].AcceptChanges();
                        onlySelectColChangeRowState = false;

                        if (btnNew.Enabled)
                            ControlHandler.SetButtonBar_EnabledState_Order(dataSet_ProductionPlan.Tables[0].Select("select=1"), gridViewProductionPlan.GetFocusedDataRow(), "CurrentStatus", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, null, null, btnPreview);
                    }
                    else
                    {
                        if (headFocusedLineNo < gridViewProductionPlan.DataRowCount && gridViewProductionPlan.FocusedRowHandle != headFocusedLineNo && gridViewProductionPlan.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                        {
                            MessageHandler.ShowMessageBox("当前工单已经修改，请保存后再进行换行。");
                            gridViewProductionPlan.FocusedRowHandle = headFocusedLineNo;
                        }
                        else if (headFocusedLineNo == gridViewProductionPlan.DataRowCount)
                        {

                        }
                        else
                        {
                            if (gridViewProductionPlan.FocusedRowHandle != headFocusedLineNo && gridViewProductionPlan.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                            else if (gridViewProductionPlan.GetDataRow(headFocusedLineNo).RowState == DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                        }
                    }

                    if (DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]) != "")
                    {
                        dataSet_ProductionPlan.Tables[1].Clear();
                        ppDAO.QueryProductionPlanList(dataSet_ProductionPlan.Tables[1], DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]));
                        treeListDesignBom.ExpandAll();
                        //if (queryListAutoId > 0)
                        //{
                        //    for (int i = 0; i < gridViewPrReqList.DataRowCount; i++)
                        //    {
                        //        if (DataTypeConvert.GetInt(gridViewPrReqList.GetDataRow(i)["AutoId"]) == queryListAutoId)
                        //        {
                        //            gridViewPrReqList.FocusedRowHandle = i;
                        //            queryListAutoId = 0;
                        //            break;
                        //        }
                        //    }
                        //}
                    }

                    if (gridViewProductionPlan.FocusedRowHandle >= 0)
                    {
                        headFocusedLineNo = gridViewProductionPlan.FocusedRowHandle;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--主表聚焦行改变事件错误。", ex);
            }
        }

        /// <summary>
        /// 设定列表显示信息
        /// </summary>
        private void gridViewProductionPlan_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "CurrentStatus")
            {
                e.DisplayText = CommonHandler.Get_OrderState_Desc(e.Value.ToString());
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewProductionPlan_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
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
        private void gridViewProductionPlan_KeyDown(object sender, KeyEventArgs e)
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
        /// 新增按钮事件
        /// </summary>
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                ClearHeadGridAllSelect();

                //gridViewProductionPlan.PostEditor();
                gridViewProductionPlan.AddNewRow();
                FocusedHeadView("CodeFileName");

                //dataSet_ProductionPlan.Tables[1].Clear();
                //gridViewPrReqList.AddNewRow();
                //FocusedListView(false, "CodeFileName", gridViewPrReqList.GetFocusedDataSourceRowIndex());
                //gridViewPrReqList.RefreshData();

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewProductionPlan.DataRowCount;
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

                if (gridViewProductionPlan.GetFocusedDataRow() == null)
                    return;

                if (!CheckCurrentStatus())
                    return;

                if (btnSave.Text != "保存")
                {
                    ClearHeadGridAllSelect();

                    SetButtonAndColumnState(true);
                    FocusedHeadView("CodeFileName");
                }
                else
                {
                    bindingSource_ProductionPlan.EndEdit();
                    bindingSource_ProductionPlanList.EndEdit();

                    DataRow headRow = gridViewProductionPlan.GetFocusedDataRow();
                    if (DataTypeConvert.GetString(headRow["CodeId"]) == "")
                    {
                        MessageHandler.ShowMessageBox("零件名称不能为空，请填写后再进行保存。");
                        FocusedHeadView("CodeFileName");
                        return;
                    }
                    if (DataTypeConvert.GetDouble(headRow["Qty"]) == 0)
                    {
                        MessageHandler.ShowMessageBox("数量不能为空或者零，请填写后再进行保存。");
                        FocusedHeadView("Qty");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["ManufactureNo"]) == "")
                    {
                        MessageHandler.ShowMessageBox("工程信息不能为空，请填写后再进行保存。");
                        FocusedHeadView("ManufactureNo");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["ProjectNo"]) == "")
                    {
                        MessageHandler.ShowMessageBox("项目号不能为空，请填写后再进行保存。");
                        FocusedHeadView("ProjectNo");
                        return;
                    }

                    if (DataTypeConvert.GetString(headRow["StartTime"]) == "")
                    {
                        MessageHandler.ShowMessageBox("计划开始日期不能为空，请填写后再进行保存。");
                        FocusedHeadView("StartTime");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["EndTime"]) == "")
                    {
                        MessageHandler.ShowMessageBox("计划结束日期不能为空，请填写后再进行保存。");
                        FocusedHeadView("EndTime");
                        return;
                    }

                    DateTime startDate = DataTypeConvert.GetDateTime(gridViewProductionPlan.GetFocusedDataRow()["StartTime"]);
                    DateTime endDate = DataTypeConvert.GetDateTime(gridViewProductionPlan.GetFocusedDataRow()["EndTime"]);
                    if (startDate > endDate)
                    {
                        MessageHandler.ShowMessageBox("计划开始日期不能大于计划结束日期，请重新操作。");
                        FocusedHeadView("EndTime");
                        return;
                    }

                    //for (int i = gridViewProductionPlanList.DataRowCount - 1; i >= 0; i--)
                    //{
                    //    DataRow listRow = gridViewProductionPlanList.GetDataRow(i);
                    //    if (DataTypeConvert.GetString(listRow["CodeId"]) == "")
                    //    {
                    //        gridViewProductionPlanList.DeleteRow(i);
                    //        continue;
                    //    }
                    //    if (DataTypeConvert.GetString(listRow["Qty"]) == "")
                    //    {
                    //        MessageHandler.ShowMessageBox("数量不能为空，请填写后再进行保存。");
                    //        FocusedListView(true, "Qty", i);
                    //        return;
                    //    }
                    //}

                    int ret = ppDAO.SaveProductionPlan(gridViewProductionPlan.GetFocusedDataRow(), dataSet_ProductionPlan.Tables[1]);
                    switch (ret)
                    {
                        case -1:
                            btnQuery_Click(null, null);
                            break;
                        case 1:
                            dataSet_ProductionPlan.Tables[1].Clear();
                            ppDAO.QueryProductionPlanList(dataSet_ProductionPlan.Tables[1], DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]));
                            treeListDesignBom.ExpandAll();
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

                if (gridViewProductionPlan.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                {
                    if (DataTypeConvert.GetString(gridViewProductionPlan.GetDataRow(headFocusedLineNo)["PlanNo"]) == "")
                    {
                        gridViewProductionPlan.DeleteRow(headFocusedLineNo);
                    }
                    else
                    {
                        gridViewProductionPlan.GetFocusedDataRow().RejectChanges();
                    }
                }

                SetButtonAndColumnState(false);

                dataSet_ProductionPlan.Tables[1].Clear();
                if (gridViewProductionPlan.GetFocusedDataRow() != null)
                {
                    ppDAO.QueryProductionPlanList(dataSet_ProductionPlan.Tables[1], DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]));
                    treeListDesignBom.ExpandAll();
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

                int count = dataSet_ProductionPlan.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckCurrentStatus_Multi(false, true, true, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要删除当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }

                if (!ppDAO.DeleteProductionPlan_Multi(dataSet_ProductionPlan.Tables[0]))
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

                int count = dataSet_ProductionPlan.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                //if (!WorkFlowsHandleDAO.QueryWorkFlowsLineNextNodeIsEnabled(WorkFlowsHandleDAO.OrderType.工单, WorkFlowsHandleDAO.LineType.提交))
                //{
                //    if (MessageHandler.ShowMessageBox_YesNo(string.Format("流程图中状态节点[提交]已经停用，确定要直接审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                //    {
                //        return;
                //    }
                //    else
                //    {
                //        ApproveProductionPlan(1);
                //        return;
                //    }
                //}

                if (!CheckCurrentStatus_Multi(false, true, true, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要提交当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!ppDAO.SubmitPPlan_Multi(dataSet_ProductionPlan.Tables[0]))
                    btnQuery_Click(null, null);

                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_ProductionPlan.Tables[0].Select("select=1"), gridViewProductionPlan.GetFocusedDataRow(), "CurrentStatus", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, null, null, btnPreview);
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

                int count = dataSet_ProductionPlan.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckCurrentStatus_Multi(true, true, true, false, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要取消提交当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!ppDAO.CancelSubmitPPlan_Multi(dataSet_ProductionPlan.Tables[0]))
                    btnQuery_Click(null, null);

                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_ProductionPlan.Tables[0].Select("select=1"), gridViewProductionPlan.GetFocusedDataRow(), "CurrentStatus", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, null, null, btnPreview);
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

                int count = dataSet_ProductionPlan.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckCurrentStatus_Multi(true, true, true, false, "（请确保订单提交后再进行审批操作）"))
                    return;

                //if (count == 1)
                //{
                //    //弹出审批页面
                //    FrmOrderApproval frmOrder = new FrmOrderApproval(DataTypeConvert.GetString(dataSet_ProductionPlan.Tables[0].Select("select=1")[0]["PlanNo"]));
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
                //    DataRow[] drs = dataSet_ProductionPlan.Tables[0].Select("select=1");
                //    for (int i = 0; i < drs.Length; i++)
                //    {
                //        dataNoList.Add(DataTypeConvert.GetString(drs[i]["PlanNo"]));
                //    }

                //    FrmWorkFlowDataHandle wfDataHandle = new FrmWorkFlowDataHandle();
                //    wfDataHandle.orderNameStr = "工单";
                //    wfDataHandle.dataNoList = dataNoList;
                //    wfDataHandle.workFlowTypeText = "生产流程";
                //    wfDataHandle.tableNameStr = "PB_ProductionPlan";
                //    wfDataHandle.moduleTypeInt = 2;
                //    if (wfDataHandle.ShowDialog() == DialogResult.OK)
                //    {
                //        int nodeIdInt = wfDataHandle.nodeIdInt;
                //        string flowModuleIdStr = wfDataHandle.flowModuleIdStr;
                //        string approverOptionStr = wfDataHandle.memoApproverOption.Text;
                //        int approverResultInt = DataTypeConvert.GetInt(wfDataHandle.radioApproverResult.EditValue);

                //        int successCountInt = 0;
                //        //直接审批，不再谈页面
                //        if (!ppDAO.PPlanApprovalInfo_Multi(dataSet_ProductionPlan.Tables[0], nodeIdInt, flowModuleIdStr, approverOptionStr, approverResultInt, ref successCountInt))
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

                ApproveProductionPlan(4);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--审批按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 审批工单
        /// </summary>
        private void ApproveProductionPlan(int CurrentStatusInt)
        {
            List<string> dataNoList = new List<string>();
            DataRow[] drs = dataSet_ProductionPlan.Tables[0].Select("select=1");
            for (int i = 0; i < drs.Length; i++)
            {
                dataNoList.Add(DataTypeConvert.GetString(drs[i]["PlanNo"]));
            }

            FrmWorkFlowsDataHandle wfDataHandle = new FrmWorkFlowsDataHandle();
            wfDataHandle.orderNameStr = "工单";
            wfDataHandle.dataNoList = dataNoList;
            wfDataHandle.orderType = WorkFlowsHandleDAO.OrderType.工单;
            if (wfDataHandle.ShowDialog() == DialogResult.OK)
            {
                string approverOptionStr = wfDataHandle.memoApproverOption.Text;
                int approverResultInt = DataTypeConvert.GetInt(wfDataHandle.radioApproverResult.EditValue);

                int successCountInt = CurrentStatusInt;

                //直接审批，不再谈页面
                if (!ppDAO.PPlanApprovalInfoNew_Multi(dataSet_ProductionPlan.Tables[0], approverOptionStr, approverResultInt, ref successCountInt))
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
            ControlHandler.SetButtonBar_EnabledState_Order(dataSet_ProductionPlan.Tables[0].Select("select=1"), gridViewProductionPlan.GetFocusedDataRow(), "CurrentStatus", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, null, null, btnPreview);
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

                int count = dataSet_ProductionPlan.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckCurrentStatus_Multi(true, false, true, true, ""))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要取消审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }

                if (!ppDAO.CancalPPlanApprovalInfo_Multi(dataSet_ProductionPlan.Tables[0]))
                    btnQuery_Click(null, null);
                else
                {
                    MessageHandler.ShowMessageBox(string.Format("成功取消审批了{0}条记录。", count));
                }
                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_ProductionPlan.Tables[0].Select("select=1"), gridViewProductionPlan.GetFocusedDataRow(), "CurrentStatus", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, null, null, btnPreview);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--取消审批按钮事件错误。", ex);
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

                string planNoStr = "";
                DataRow dr = null;
                DataRow[] drs = dataSet_ProductionPlan.Tables[0].Select("select=1");
                if (drs.Length > 1)
                {
                    MessageHandler.ShowMessageBox("只能选中一条记录进行打印预览，请重新选择。");
                    return;
                }
                else if (drs.Length == 0)
                {
                    if (gridViewProductionPlan.GetFocusedDataRow() != null)
                    {
                        planNoStr = DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]);
                        dr = gridViewProductionPlan.GetFocusedDataRow();
                    }
                }
                else
                {
                    planNoStr = DataTypeConvert.GetString(drs[0]["PlanNo"]);
                    dr = drs[0];
                }

                if (dr != null && SystemInfo.ApproveAfterPrint)
                {
                    if (DataTypeConvert.GetInt(dr["CurrentStatus"]) != 2)
                    {
                        MessageHandler.ShowMessageBox("请审批通过后，再进行打印预览操作。");
                        return;
                    }
                }

                ppDAO.PrintHandle(planNoStr, 1);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--打印预览操作错误。", ex);
            }
        }

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
            foreach (DataRow dr in dataSet_ProductionPlan.Tables[0].Rows)
            {
                dr["Select"] = value;
            }
            onlySelectColChangeRowState = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_ProductionPlan.Tables[0].Select("select=1"), gridViewProductionPlan.GetFocusedDataRow(), "CurrentStatus", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, null, null, btnPreview);
        }

        /// <summary>
        /// 主表设定默认值
        /// </summary>
        private void gridViewProductionPlan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                gridViewProductionPlan.SetFocusedRowCellValue("Qty", 1);
                gridViewProductionPlan.SetFocusedRowCellValue("StartTime", nowDate.Date.AddDays(1));
                gridViewProductionPlan.SetFocusedRowCellValue("EndTime", nowDate.Date.AddDays(8));
                gridViewProductionPlan.SetFocusedRowCellValue("PlanStatus", 1);
                gridViewProductionPlan.SetFocusedRowCellValue("CurrentStatus", 1);
                gridViewProductionPlan.SetFocusedRowCellValue("Creator", SystemInfo.user.AutoId);

                if (SystemInfo.DisableProjectNo)
                {
                    gridViewProductionPlan.SetFocusedRowCellValue("ProjectNo", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--主表设定默认值错误。", ex);
            }
        }

        /// <summary>
        /// 主表单元格值变化进行的操作
        /// </summary>
        private void gridViewProductionPlan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //if (e.Column == colPlanStatus)
                //{
                //    DataRow focusedRow = gridViewProductionPlan.GetFocusedDataRow();
                //    bool isStatus = DataTypeConvert.GetInt(focusedRow["PlanStatus"]) == 1;
                //    if (isStatus)
                //    {
                //        DataTable bomTable = new DataTable();
                //        new FrmBomManagementDAO().QueryBomMateriel(bomTable, DataTypeConvert.GetInt(focusedRow["CodeId"]));
                //        foreach (DataRow bomRow in bomTable.Rows)
                //        {
                //            DataRow dr = dataSet_ProductionPlan.Tables[1].NewRow();
                //            dr["PlanNo"] = focusedRow["PlanNo"];
                //            dr["CodeId"] = bomRow["LevelCodeId"];
                //            dr["CodeName"] = bomRow["LevelCodeName"];
                //            dr["UnitQty"] = bomRow["Qty"];
                //            dr["PlanQty"] = DataTypeConvert.GetDouble(bomRow["Qty"]) * DataTypeConvert.GetDouble(focusedRow["Qty"]);
                //            dr["Qty"] = dr["PlanQty"];
                //            dr["AfterFlag"] = 0;
                //            dataSet_ProductionPlan.Tables[1].Rows.Add(dr);
                //        }
                //    }
                //    else
                //    {
                //        for (int i = gridViewProductionPlanList.DataRowCount - 1; i >= 0; i--)
                //        {
                //            gridViewProductionPlanList.DeleteRow(i);
                //        }
                //    }
                //}

                //if (e.Column == colStartTime)
                //{
                //    DateTime startDate = DataTypeConvert.GetDateTime(gridViewProductionPlan.GetFocusedDataRow()["StartTime"]);
                //    DateTime endDate = DataTypeConvert.GetDateTime(gridViewProductionPlan.GetFocusedDataRow()["EndTime"]);
                //    if (startDate > endDate)
                //    {
                //        MessageHandler.ShowMessageBox("计划开始日期不能大于计划结束日期，请重新操作。");
                //        gridViewProductionPlan.SetFocusedRowCellValue("StartTime", endDate);
                //        FocusedHeadView("StartTime");
                //    }
                //}
                //else if (e.Column == colEndTime)
                //{
                //    DateTime startDate = DataTypeConvert.GetDateTime(gridViewProductionPlan.GetFocusedDataRow()["StartTime"]);
                //    DateTime endDate = DataTypeConvert.GetDateTime(gridViewProductionPlan.GetFocusedDataRow()["EndTime"]);
                //    if (startDate > endDate)
                //    {
                //        MessageHandler.ShowMessageBox("计划开始日期不能大于计划结束日期，请重新操作。");
                //        gridViewProductionPlan.SetFocusedRowCellValue("EndTime", startDate);
                //        FocusedHeadView("EndTime");
                //    }
                //}
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--主表单元格值变化进行的操作错误。", ex);
            }
        }

        /// <summary>
        /// 设定零件信息
        /// </summary>
        private void repSearchCodeId_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                //int newCodeIdInt = DataTypeConvert.GetInt(e.NewValue);
                //if (newCodeIdInt == 0)
                //{
                //    ClearBomInfo();
                //    return;
                //}

                //DataTable pcTable = (DataTable)repSearchCodeId.DataSource;
                //DataRow[] drs = pcTable.Select(string.Format("AutoId = {0}", newCodeIdInt));

                //FrmSelectPartsCode.codeIdInt = newCodeIdInt;
                //FrmSelectPartsCode.codeFileNameStr = DataTypeConvert.GetString(drs[0]["CodeFileName"]);
                //FrmSelectPartsCode selectPC = new FrmSelectPartsCode();
                //if (selectPC.ShowDialog() == DialogResult.OK)
                //{
                //    DataRow pcRow = selectPC.gridViewDBList.GetFocusedDataRow();
                //    gridViewProductionPlan.SetFocusedRowCellValue("DesignBomListId", pcRow["AutoId"]);
                //    gridViewProductionPlan.SetFocusedRowCellValue("ProjectNo", pcRow["ProjectNo"]);
                //    e.NewValue = pcRow["CodeId"];

                //    if (DataTypeConvert.GetInt(gridViewProductionPlan.GetFocusedDataRow()["PlanStatus"]) == 1)
                //    {
                //        ClearBomInfo();
                //        QueryBomInfo(newCodeIdInt);
                //    }
                //}
                //else
                //{
                //    e.NewValue = 0;
                //    ClearBomInfo();
                //}
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定展开的值错误。", ex);
            }
        }

        /// <summary>
        /// 聚焦直接点击按钮
        /// </summary>
        private void repButtonCodeId_Enter(object sender, EventArgs e)
        {
            repButtonCodeId_ButtonClick(null, null);
        }

        /// <summary>
        /// 设定零件信息
        /// </summary>
        private void repButtonCodeId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmSelectPartsCode selectPC = new FrmSelectPartsCode();
                if (selectPC.ShowDialog() == DialogResult.OK)
                {
                    TreeListNode tlNode = selectPC.treeListDesignBom.FocusedNode;

                    object obj = tlNode["ReId"];
                    int dbListId = DataTypeConvert.GetInt(obj);
                    gridViewProductionPlan.SetFocusedRowCellValue("DesignBomListId", dbListId);
                    gridViewProductionPlan.SetFocusedRowCellValue("ProjectNo", tlNode["ProjectNo"]);
                    gridViewProductionPlan.SetFocusedRowCellValue("CodeId", tlNode["CodeId"]);
                    gridViewProductionPlan.SetFocusedRowCellValue("CodeFileName", tlNode["CodeFileName"]);
                    gridViewProductionPlan.SetFocusedRowCellValue("CodeName", tlNode["CodeName"]);

                    string planNoStr = DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]);
                    double opQty = ppDAO.Query_DesignBomList_OpQty(dbListId, planNoStr);
                    gridViewProductionPlan.SetFocusedRowCellValue("Qty", opQty);

                    if (DataTypeConvert.GetInt(gridViewProductionPlan.GetFocusedDataRow()["PlanStatus"]) == 1)
                    {
                        ClearBomInfo();
                        QueryBomInfo(DataTypeConvert.GetInt(tlNode["CodeId"]));
                    }
                }
                else
                {
                    //gridViewProductionPlan.SetFocusedRowCellValue("CodeId", DBNull.Value);
                    //gridViewProductionPlan.SetFocusedRowCellValue("CodeFileName", "");
                    //gridViewProductionPlan.SetFocusedRowCellValue("CodeName", "");
                    //gridViewProductionPlan.SetFocusedRowCellValue("Qty", 0);
                    //ClearBomInfo();
                }
                SendKeys.Send("{ENTER}");
                FocusedHeadView("CodeFileName");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定展开的值错误。", ex);
            }
        }

        /// <summary>
        /// 设定零件数量
        /// </summary>
        private void repSpinQty_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (DataTypeConvert.GetInt(gridViewProductionPlan.GetFocusedDataRow()["PlanStatus"]) == 1 && treeListDesignBom.Nodes.Count > 0)
                {
                    int dbListId = DataTypeConvert.GetInt(gridViewProductionPlan.GetFocusedDataRow()["DesignBomListId"]);
                    string planNoStr = DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]);
                    if (treeListDesignBom.AllNodesCount == 1 && DataTypeConvert.GetInt(treeListDesignBom.Nodes[0]["DesignBomListId"]) == dbListId)
                    {
                        treeListDesignBom.Nodes[0]["PlanQty"] = DataTypeConvert.GetDouble(e.NewValue);
                        treeListDesignBom.Nodes[0]["Qty"] = treeListDesignBom.Nodes[0]["PlanQty"];
                    }
                    else if (dataTableProductionPlanList.Rows.Count > 0)
                    {
                        HandleLevelQty(planNoStr, dbListId, DataTypeConvert.GetDouble(e.NewValue));
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定零件数量错误。", ex);
            }
        }

        /// <summary>
        /// 处理子零件数量
        /// </summary>
        private void HandleLevelQty(string planNoStr, int parentIdInt, double planQty)
        {
            DataRow[] drs = dataSet_ProductionPlan.Tables[1].Select(string.Format("IsNull(DesignBomListParentId, 0) = {0}", parentIdInt));
            if (drs.Length > 0)
            {
                foreach (DataRow dr in drs)
                {
                    dr["PlanQty"] = planQty * DataTypeConvert.GetDouble(dr["UnitQty"]);

                    double opQty = ppDAO.Query_DesignBomList_OpQty(DataTypeConvert.GetInt(dr["DesignBomListId"]), planNoStr);
                    if (opQty < DataTypeConvert.GetDouble(dr["PlanQty"]))
                        dr["Qty"] = opQty;
                    else
                        dr["Qty"] = dr["PlanQty"];

                    HandleLevelQty(planNoStr, DataTypeConvert.GetInt(dr["DesignBomListId"]), DataTypeConvert.GetDouble(dr["PlanQty"]));
                }
            }
        }

        /// <summary>
        /// 设定展开的值
        /// </summary>
        private void repCheckPlanStatus_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (e.NewValue.ToString() == "1")
                {
                    ClearBomInfo();
                    QueryBomInfo(0);
                }
                else
                {
                    ClearBomInfo();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定展开的值错误。", ex);
            }
        }

        /// <summary>
        /// 查询Bom信息
        /// </summary>
        private void QueryBomInfo(int codeIdInt)
        {
            DataRow focusedRow = gridViewProductionPlan.GetFocusedDataRow();
            int dbListId = DataTypeConvert.GetInt(focusedRow["DesignBomListId"]);

            if (dbListId > 0)
            {
                DataTable dbListTable = ppDAO.QueryDesignBomList_My(dbListId);

                if (dbListTable.Rows.Count == 0)
                {
                    throw new Exception("未查询到设计Bom的明细信息，请重新操作。");
                }
                else
                {
                    double mainQty = DataTypeConvert.GetDouble(focusedRow["Qty"]);
                    int isBuyInt = DataTypeConvert.GetInt(dbListTable.Rows[0]["IsBuy"]);
                    string planNoStr = DataTypeConvert.GetString(focusedRow["PlanNo"]);
                    int codeId = DataTypeConvert.GetInt(dbListTable.Rows[0]["CodeId"]);
                    isBuyInt = 2;//回来调试完设计Bom注销这句
                    switch (isBuyInt)
                    {
                        case 1://整体采购
                            DataRow newRow = dataSet_ProductionPlan.Tables[1].NewRow();
                            newRow["PlanNo"] = planNoStr;
                            newRow["CodeId"] = codeId;
                            newRow["LevelCodeId"] = codeId;
                            newRow["ParentId"] = DBNull.Value;
                            newRow["CodeName"] = codeId;
                            newRow["UnitQty"] = 1;
                            newRow["PlanQty"] = mainQty;
                            newRow["Qty"] = ppDAO.Query_DesignBomList_OpQty(DataTypeConvert.GetInt(dbListTable.Rows[0]["AutoId"]), planNoStr);
                            newRow["HasLevel"] = dbListTable.Rows[0]["HasLevel"];
                            newRow["IsAll"] = dbListTable.Rows[0]["IsAll"];
                            newRow["IsBuy"] = dbListTable.Rows[0]["IsBuy"];
                            newRow["AfterFlag"] = 0;
                            newRow["DesignBomListId"] = dbListTable.Rows[0]["AutoId"];
                            newRow["DesignBomListParentId"] = DBNull.Value;
                            dataSet_ProductionPlan.Tables[1].Rows.Add(newRow);
                            break;
                        case 2://下级采购
                            DataTable dbListTable_Level = ppDAO.QueryDesignBomList_MyLevel(dbListId);
                            if (dbListTable_Level.Rows.Count > 1)
                            {
                                DataRow[] drs = dbListTable_Level.Select(string.Format("AutoId={0}", dbListId));
                                if (drs.Length > 0)
                                {
                                    dbListTable_Level.Rows.Remove(drs[0]);
                                }

                                HandleLevelList(dbListTable_Level, planNoStr, dbListId, codeId, mainQty);
                                treeListDesignBom.ExpandAll();
                            }
                            else if (dbListTable_Level.Rows.Count == 1)
                            {
                                DataRow dblistRow = dbListTable_Level.Rows[0];

                                DataRow newDataRow = dataSet_ProductionPlan.Tables[1].NewRow();
                                newDataRow["PlanNo"] = planNoStr;
                                newDataRow["CodeId"] = DataTypeConvert.GetInt(dblistRow["LevelCodeId"]) == 0 ? dblistRow["CodeId"] : dblistRow["LevelCodeId"];
                                newDataRow["LevelCodeId"] = newDataRow["CodeId"];
                                newDataRow["ParentId"] = DBNull.Value;
                                newDataRow["CodeName"] = newDataRow["CodeId"];
                                newDataRow["UnitQty"] = 1;
                                newDataRow["PlanQty"] = mainQty;
                                newDataRow["Qty"] = ppDAO.Query_DesignBomList_OpQty(DataTypeConvert.GetInt(dblistRow["AutoId"]), planNoStr);
                                newDataRow["HasLevel"] = dblistRow["HasLevel"];
                                newDataRow["IsAll"] = dblistRow["IsAll"];
                                newDataRow["IsBuy"] = dblistRow["IsBuy"];
                                newDataRow["AfterFlag"] = 0;
                                newDataRow["DesignBomListId"] = dblistRow["AutoId"];
                                newDataRow["DesignBomListParentId"] = DBNull.Value;
                                dataSet_ProductionPlan.Tables[1].Rows.Add(newDataRow);
                            }
                            break;
                        case 3://不采购

                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 处理子节点列表
        /// </summary>
        private void HandleLevelList(DataTable DBListTable, string planNoStr, int parentIdInt, int codeIdInt, double planQty)
        {
            DataRow[] drs = DBListTable.Select(string.Format("IsNull(ParentId, 0) = {0}", parentIdInt));
            if (drs.Length > 0)
            {
                foreach (DataRow dr in drs)
                {
                    DataRow newRow = dataSet_ProductionPlan.Tables[1].NewRow();
                    newRow["AutoId"] = dr["AutoId"];
                    newRow["PlanNo"] = planNoStr;
                    newRow["CodeId"] = codeIdInt;
                    newRow["LevelCodeId"] = dr["LevelCodeId"];
                    newRow["ParentId"] = dr["ParentId"];
                    newRow["CodeName"] = dr["LevelCodeId"];
                    newRow["UnitQty"] = dr["Qty"];
                    newRow["PlanQty"] = planQty * DataTypeConvert.GetDouble(dr["Qty"]);

                    double opQty = ppDAO.Query_DesignBomList_OpQty(DataTypeConvert.GetInt(dr["AutoId"]), planNoStr);
                    if (opQty < DataTypeConvert.GetDouble(newRow["PlanQty"]))
                        newRow["Qty"] = opQty;
                    else
                        newRow["Qty"] = newRow["PlanQty"];
                    newRow["HasLevel"] = dr["HasLevel"];
                    newRow["IsAll"] = dr["IsAll"];
                    newRow["IsBuy"] = dr["IsBuy"];
                    newRow["AfterFlag"] = 0;
                    newRow["DesignBomListId"] = dr["AutoId"];
                    newRow["DesignBomListParentId"] = dr["ParentId"];
                    dataSet_ProductionPlan.Tables[1].Rows.Add(newRow);

                    HandleLevelList(DBListTable, planNoStr, DataTypeConvert.GetInt(dr["AutoId"]), DataTypeConvert.GetInt(newRow["LevelCodeId"]), DataTypeConvert.GetDouble(newRow["PlanQty"]));
                }
            }
        }

        /// <summary>
        /// 清空Bom信息
        /// </summary>
        private void ClearBomInfo()
        {
            for (int i = dataSet_ProductionPlan.Tables[1].Rows.Count - 1; i >= 0; i--)
            {
                dataSet_ProductionPlan.Tables[1].Rows[i].Delete();
            }
        }

        /// <summary>
        /// 设定当前行选择
        /// </summary>
        private void repCheckSelect_EditValueChanged(object sender, EventArgs e)
        {
            if (DataTypeConvert.GetBoolean(gridViewProductionPlan.GetFocusedDataRow()["Select"]))
                gridViewProductionPlan.GetFocusedDataRow()["Select"] = false;
            else
                gridViewProductionPlan.GetFocusedDataRow()["Select"] = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_ProductionPlan.Tables[0].Select("select=1"), gridViewProductionPlan.GetFocusedDataRow(), "CurrentStatus", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, null, null, btnPreview);

            onlySelectColChangeRowState = true;
        }

        /// <summary>
        /// 设定零件数量
        /// </summary>
        private void repSpinRemainQty_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (DataTypeConvert.GetInt(gridViewProductionPlan.GetFocusedDataRow()["PlanStatus"]) == 1)
                {
                    int dbListId = DataTypeConvert.GetInt(gridViewProductionPlan.GetFocusedDataRow()["DesignBomListId"]);
                    if (treeListDesignBom.AllNodesCount == 1 && DataTypeConvert.GetInt(treeListDesignBom.FocusedNode["DesignBomListId"]) == dbListId)
                    {
                        gridViewProductionPlan.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(e.NewValue));
                        treeListDesignBom.FocusedNode["PlanQty"] = DataTypeConvert.GetDouble(e.NewValue);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定零件数量错误。", ex);
            }
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
                btnDelete.Enabled = false;
                btnSubmit.Enabled = false;
                btnCancelSubmit.Enabled = false;
                btnApprove.Enabled = false;
                btnCancelApprove.Enabled = false;
                btnPreview.Enabled = false;
            }
            else
            {
                btnNew.Enabled = true;
                btnSave.Text = "修改";
                btnCancel.Enabled = false;
                //btnDelete.Enabled = true;
                //btnSubmit.Enabled = true;
                //btnCancelSubmit.Enabled = true;
                //btnApprove.Enabled = true;
                //btnCancelApprove.Enabled = true;
                //btnPreview.Enabled = true;

                ControlHandler.SetButtonBar_EnabledState_Order(dataSet_ProductionPlan.Tables[0].Select("select=1"), gridViewProductionPlan.GetFocusedDataRow(), "CurrentStatus", btnSave, btnDelete, btnSubmit, btnCancelSubmit, btnApprove, btnCancelApprove, null, null, btnPreview);
            }

            coluCodeFileName.OptionsColumn.AllowEdit = ret;
            colQty.OptionsColumn.AllowEdit = ret;
            colManufactureNo.OptionsColumn.AllowEdit = ret;
            //colProjectNo.OptionsColumn.AllowEdit = ret;
            colLine.OptionsColumn.AllowEdit = ret;

            colStartTime.OptionsColumn.AllowEdit = ret;
            colEndTime.OptionsColumn.AllowEdit = ret;
            colRemark.OptionsColumn.AllowEdit = ret;
            colPlanStatus.OptionsColumn.AllowEdit = ret;

            columnQty.OptionsColumn.AllowEdit = ret;

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
        /// 检测工单状态是否可以操作
        /// </summary>
        private bool CheckCurrentStatus()
        {
            if (gridViewProductionPlan.GetFocusedDataRow() == null)
                return false;
            int currentStatusInt = DataTypeConvert.GetInt(gridViewProductionPlan.GetFocusedDataRow()["CurrentStatus"]);
            switch (currentStatusInt)
            {
                case (int)CommonHandler.OrderState.已审批:
                    MessageHandler.ShowMessageBox(string.Format("工单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]), CommonHandler.OrderState.已审批));
                    return false;
                case (int)CommonHandler.OrderState.已关闭:
                    MessageHandler.ShowMessageBox(string.Format("工单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]), CommonHandler.OrderState.已关闭));
                    return false;
                case (int)CommonHandler.OrderState.审批中:
                    MessageHandler.ShowMessageBox(string.Format("工单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]), CommonHandler.OrderState.审批中));
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 检测当前选中的工单状态是否可以操作
        /// </summary>
        private bool CheckCurrentStatus_Multi(bool checkNoSubmit, bool checkApprover, bool checkClosed, bool checkApproverBetween, string messageStr)
        {
            for (int i = 0; i < gridViewProductionPlan.DataRowCount; i++)
            {
                if (DataTypeConvert.GetBoolean(gridViewProductionPlan.GetDataRow(i)["Select"]))
                {
                    int currentStatusInt = DataTypeConvert.GetInt(gridViewProductionPlan.GetDataRow(i)["CurrentStatus"]);
                    switch (currentStatusInt)
                    {
                        case (int)CommonHandler.OrderState.待提交:
                            if (checkNoSubmit)
                            {
                                MessageHandler.ShowMessageBox(string.Format("工单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewProductionPlan.GetDataRow(i)["PlanNo"]), messageStr, CommonHandler.OrderState.待提交));
                                gridViewProductionPlan.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.OrderState.已审批:
                            if (checkApprover)
                            {
                                MessageHandler.ShowMessageBox(string.Format("工单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewProductionPlan.GetDataRow(i)["PlanNo"]), messageStr, CommonHandler.OrderState.已审批));
                                gridViewProductionPlan.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.OrderState.已关闭:
                            if (checkClosed)
                            {
                                MessageHandler.ShowMessageBox(string.Format("工单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewProductionPlan.GetDataRow(i)["PlanNo"]), messageStr, CommonHandler.OrderState.已关闭));
                                gridViewProductionPlan.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.OrderState.审批中:
                            if (checkApproverBetween)
                            {
                                MessageHandler.ShowMessageBox(string.Format("工单[{0}]{2}，不可以操作。{1}", DataTypeConvert.GetString(gridViewProductionPlan.GetDataRow(i)["PlanNo"]), messageStr, CommonHandler.OrderState.审批中));
                                gridViewProductionPlan.FocusedRowHandle = i;
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
            gridControlProductionPlan.Focus();
            ColumnView headView = (ColumnView)gridControlProductionPlan.FocusedView;
            headView.FocusedColumn = headView.Columns[colName];
            gridViewProductionPlan.FocusedRowHandle = headView.FocusedRowHandle;
        }

        ///// <summary>
        ///// 聚焦子表当前行的列
        ///// </summary>
        //private void FocusedListView(bool isFocusedControl, string colName, int lineNo)
        //{
        //    if (isFocusedControl)
        //        gridControlProductionPlanList.Focus();
        //    ColumnView listView = (ColumnView)gridControlProductionPlanList.FocusedView;
        //    listView.FocusedColumn = listView.Columns[colName];
        //    gridViewProductionPlanList.FocusedRowHandle = lineNo;
        //}

        /// <summary>
        /// 清楚当前的所有选择
        /// </summary>
        private void ClearHeadGridAllSelect()
        {
            checkAll.Checked = false;
            for (int i = 0; i < dataSet_ProductionPlan.Tables[0].Rows.Count; i++)
            {
                dataSet_ProductionPlan.Tables[0].Rows[i]["Select"] = false;
            }
            dataSet_ProductionPlan.Tables[0].AcceptChanges();
            onlySelectColChangeRowState = false;
        }

        /// <summary>
        /// 右击工单明细弹出菜单
        /// </summary>
        private void treeListDesignBom_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    TreeListHitInfo hInfo = treeListDesignBom.CalcHitInfo(new Point(e.X, e.Y));
                    TreeListNode node = hInfo.Node;
                    treeListDesignBom.FocusedNode = node;
                    if (node != null)
                    {
                        popupMenuPP.MenuCaption = "工单明细";
                        popupMenuPP.ShowPopup(Control.MousePosition);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--右击工单明细弹出菜单错误。", ex);
            }
        }

        /// <summary>
        /// 查询上级的制造Bom登记
        /// </summary>
        private void barButtonItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (popupMenuPP.MenuCaption == "工单主单")
                {
                    if (gridViewProductionPlan.GetFocusedDataRow() != null)
                    {
                        string formNameStr = "FrmPBDesignBom_PS_New";
                        if (!commonDAO.QueryUserFormPower(formNameStr))
                            return;

                        int autoIdInt = DataTypeConvert.GetInt(gridViewProductionPlan.GetFocusedDataRow()["DesignBomListId"]);
                        FrmPBDesignBom_PS_New.QuerySalesOrderNoStr = ppDAO.GetSalesOrderNo(autoIdInt);
                        FrmPBDesignBom_PS_New.QueryPBBomListAutoId = autoIdInt;
                        ViewHandler.ShowRightWindow(formNameStr);
                    }
                }
                else
                {
                    if (treeListDesignBom.FocusedNode != null)
                    {
                        string formNameStr = "FrmPBDesignBom_PS_New";
                        if (!commonDAO.QueryUserFormPower(formNameStr))
                            return;

                        int autoIdInt = DataTypeConvert.GetInt(treeListDesignBom.FocusedNode["DesignBomListId"]);
                        FrmPBDesignBom_PS_New.QuerySalesOrderNoStr = ppDAO.GetSalesOrderNo(autoIdInt);
                        FrmPBDesignBom_PS_New.QueryPBBomListAutoId = autoIdInt;
                        ViewHandler.ShowRightWindow(formNameStr);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询上级的制造Bom登记错误。", ex);
            }
        }

        /// <summary>
        /// 鼠标操作主单行事件
        /// </summary>
        private void gridViewProductionPlan_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (btnNew.Enabled)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        popupMenuPP.MenuCaption = "工单主单";
                        popupMenuPP.ShowPopup(Control.MousePosition);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--鼠标操作主单行事件错误。", ex);
            }
        }
    }
}
