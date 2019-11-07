using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using PSAP.DAO.BSDAO;
using PSAP.DAO.INVDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmReturnedGoodsReport : DockContent
    {
        #region 私有变量

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmReturnedGoodsReportDAO rgrDAO = new FrmReturnedGoodsReportDAO();
        FrmWarehouseCommonDAO whDAO = new FrmWarehouseCommonDAO();

        /// <summary>
        /// 主表聚焦的行号
        /// </summary>
        int headFocusedLineNo = 0;

        /// <summary>
        /// 查询的退货单号
        /// </summary>
        public static string queryRGRHeadNo = "";

        /// <summary>
        /// 只有选择列改变行状态的时候
        /// </summary>
        bool onlySelectColChangeRowState = false;

        ///// <summary>
        ///// 拖动区域的信息
        ///// </summary>
        //GridHitInfo GriddownHitInfo = null;

        /// <summary>
        /// 控件锁
        /// </summary>
        bool isLockControl = false;

        #endregion

        #region 构造方法

        public FrmReturnedGoodsReport()
        {
            InitializeComponent();
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmReturnedGoodsReport_Load(object sender, EventArgs e)
        {
            try
            {
                //ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd, checkAll });
                ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd });

                ControlCommonInit ctlInit = new ControlCommonInit();

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateRGRDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateRGRDateEnd.DateTime = nowDate.Date;

                lookUpReqDep.Properties.DataSource = commonDAO.QueryDepartment(true);
                lookUpReqDep.ItemIndex = 0;
                searchLookUpBussinessBaseNo.Properties.DataSource = commonDAO.QueryBussinessBaseInfo(true);
                searchLookUpBussinessBaseNo.Text = "全部";
                lookUpRepertoryId.Properties.DataSource = commonDAO.QueryRepertoryInfo(true);
                lookUpRepertoryId.ItemIndex = 0;
                //SearchLocationId.Properties.DataSource = commonDAO.QueryRepertoryLocationInfo(true);
                //SearchLocationId.EditValue = 0;
                ctlInit.SearchLookUpEdit_RepertoryLocationInfo(SearchLocationId, true);
                SearchLocationId.EditValue = 0;
                ctlInit.ComboBoxEdit_WarehouseState(comboBoxWarehouseState);
                comboBoxWarehouseState.SelectedIndex = 0;                
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpApprover);
                searchLookUpApprover.EditValue = null;

                repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                repLookUpRepertoryId.DataSource = commonDAO.QueryRepertoryInfo(false);
                //repSearchRepertoryLocationId.DataSource = commonDAO.QueryRepertoryLocationInfo(false);
                ctlInit.RepositoryItemSearchLookUpEdit_RepertoryLocationInfo(repSearchRepertoryLocationId);
                repSearchBussinessBaseNo.DataSource = commonDAO.QueryBussinessBaseInfo(false);
                repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);
                repLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;

                //repSearchCodeFileName.DataSource = commonDAO.QueryPartsCode(false);
                ctlInit.RepositoryItemSearchLookUpEdit_PartsCode(repSearchCodeFileName, "CodeFileName", "CodeFileName");
                //repSearchShelfId.DataSource = commonDAO.QueryShelfInfo(false);
                ctlInit.RepositoryItemSearchLookUpEdit_ShelfInfo(repSearchShelfId);
                //repSearchProjectNo.DataSource = commonDAO.QueryProjectList(false);
                ctlInit.RepositoryItemSearchLookUpEdit_ProjectList(repSearchProjectNo, "ProjectName", "ProjectName");

                if (textCommon.Text == "")
                {
                    rgrDAO.QueryReturnedGoodsReportHead(dataSet_RGR.Tables[0], "", "", "", "", 0, 0, 0, 0, -1, "", true);
                    rgrDAO.QueryReturnedGoodsReportList(dataSet_RGR.Tables[1], "", true);
                }
                
                if (SystemInfo.DisableProjectNo)
                {
                    colProjectName.Visible = false;
                    colStnNo.Visible = false;
                }

                if (SystemInfo.DisableShelfInfo)
                {
                    colShelfId.Visible = false;
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
        private void FrmReturnedGoodsReport_Activated(object sender, EventArgs e)
        {
            try
            {
                if (queryRGRHeadNo != "")
                {
                    textCommon.Text = queryRGRHeadNo;
                    queryRGRHeadNo = "";

                    lookUpReqDep.ItemIndex = 0;
                    searchLookUpBussinessBaseNo.Text = "全部";
                    lookUpRepertoryId.ItemIndex = 0;
                    SearchLocationId.EditValue = 0;
                    comboBoxWarehouseState.SelectedIndex = 0;
                    searchLookUpCreator.EditValue = 0;
                    searchLookUpApprover.EditValue = null;

                    dataSet_RGR.Tables[0].Clear();
                    headFocusedLineNo = 0;
                    rgrDAO.QueryReturnedGoodsReportHead(dataSet_RGR.Tables[0], "", "", "", "", 0, 0, 0, 0, -1, textCommon.Text, false);
                    SetButtonAndColumnState(false);

                    if (dataSet_RGR.Tables[0].Rows.Count > 0)
                    {
                        dateRGRDateBegin.DateTime = DataTypeConvert.GetDateTime(dataSet_RGR.Tables[0].Rows[0]["ReturnedGoodsReportDate"]).Date;
                        dateRGRDateEnd.DateTime = dateRGRDateBegin.DateTime.AddDays(7);
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
        private void FrmReturnedGoodsReport_Shown(object sender, EventArgs e)
        {
            pnlMiddle.Height = (this.Height - pnltop.Height) / 2;
        }

        #endregion

        #region 右侧退货单模块的相关事件和方法

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

                if (dateRGRDateBegin.EditValue == null || dateRGRDateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("退货日期不能为空，请设置后重新进行查询。");
                    if (dateRGRDateBegin.EditValue == null)
                        dateRGRDateBegin.Focus();
                    else
                        dateRGRDateEnd.Focus();
                    return;
                }
                string rgrDateBeginStr = dateRGRDateBegin.DateTime.ToString("yyyy-MM-dd");
                string rgrDateEndStr = dateRGRDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                string reqDepStr = lookUpReqDep.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpReqDep.EditValue) : "";
                string bussinessBaseNoStr = DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) != "全部" ? DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) : "";
                int repertoryIdInt = lookUpRepertoryId.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpRepertoryId.EditValue) : 0;
                int locationIdInt = DataTypeConvert.GetInt(SearchLocationId.EditValue);

                int warehouseStateInt = CommonHandler.Get_WarehouseState_No(comboBoxWarehouseState.Text);
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

                dataSet_RGR.Tables[0].Rows.Clear();
                dataSet_RGR.Tables[1].Rows.Clear();
                headFocusedLineNo = 0;
                rgrDAO.QueryReturnedGoodsReportHead(dataSet_RGR.Tables[0], rgrDateBeginStr, rgrDateEndStr, reqDepStr, bussinessBaseNoStr, repertoryIdInt, locationIdInt, warehouseStateInt, creatorInt, approverInt, commonStr, false);

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
        private void gridViewRGRHead_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewRGRHead.GetFocusedDataRow() != null)
                {
                    if (onlySelectColChangeRowState)
                    {
                        dataSet_RGR.Tables[0].AcceptChanges();
                        onlySelectColChangeRowState = false;

                        if (btnNew.Enabled)
                            ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_RGR.Tables[0].Select("select=1"), gridViewRGRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
                    }
                    else
                    {
                        if (headFocusedLineNo < gridViewRGRHead.DataRowCount && gridViewRGRHead.FocusedRowHandle != headFocusedLineNo && gridViewRGRHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                        {
                            MessageHandler.ShowMessageBox("当前退货单已经修改，请保存后再进行换行。");
                            gridViewRGRHead.FocusedRowHandle = headFocusedLineNo;
                        }
                        else if (headFocusedLineNo == gridViewRGRHead.DataRowCount)
                        {

                        }
                        else
                        {
                            if (gridViewRGRHead.FocusedRowHandle != headFocusedLineNo && gridViewRGRHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                            else if (gridViewRGRHead.GetDataRow(headFocusedLineNo).RowState == DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                        }
                    }

                    if (DataTypeConvert.GetString(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportNo"]) != "")
                    {
                        dataSet_RGR.Tables[1].Clear();
                        rgrDAO.QueryReturnedGoodsReportList(dataSet_RGR.Tables[1], DataTypeConvert.GetString(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportNo"]), false);
                    }

                    if (gridViewRGRHead.FocusedRowHandle >= 0)
                    {
                        headFocusedLineNo = gridViewRGRHead.FocusedRowHandle;
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
        private void gridViewRGRList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewRGRList.GetFocusedDataRow() != null)
                {
                    DataRow dr = gridViewRGRList.GetFocusedDataRow();

                    string projectNoStr = DataTypeConvert.GetString(gridViewRGRList.GetFocusedDataRow()["ProjectNo"]);
                    BingStnListComboBox(projectNoStr);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--子表聚焦行改变事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewRGRHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        private void gridViewRGRHead_KeyDown(object sender, KeyEventArgs e)
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
        private void gridViewRGRHead_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "WarehouseState")
            {
                e.DisplayText = CommonHandler.Get_WarehouseState_Desc(e.Value.ToString());
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

                if (!whDAO.IsNewWarehouseOrder())
                    return;

                ClearHeadGridAllSelect();

                gridViewRGRHead.AddNewRow();
                FocusedHeadView("BussinessBaseNo");

                dataSet_RGR.Tables[1].Clear();
                gridViewRGRList.AddNewRow();
                FocusedListView(false, "CodeFileName", gridViewRGRList.GetFocusedDataSourceRowIndex());
                gridViewRGRList.RefreshData();

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewRGRHead.DataRowCount;
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

                if (gridViewRGRHead.GetFocusedDataRow() == null)
                    return;

                if (!CheckWarehouseState())
                    return;

                if (btnSave.Text != "保存")
                {
                    if (!whDAO.IsAlterWarehouseOrder(DataTypeConvert.GetDateTime(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportDate"])))
                        return;

                    ClearHeadGridAllSelect();

                    SetButtonAndColumnState(true);
                    FocusedHeadView("BussinessBaseNo");
                }
                else
                {
                    DataRow headRow = gridViewRGRHead.GetFocusedDataRow();
                    if (DataTypeConvert.GetString(headRow["BussinessBaseNo"]) == "")
                    {
                        MessageHandler.ShowMessageBox("供应商不能为空，请填写后再进行保存。");
                        FocusedHeadView("BussinessBaseNo");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["ReqDep"]) == "")
                    {
                        MessageHandler.ShowMessageBox("退货部门不能为空，请填写后再进行保存。");
                        FocusedHeadView("ReqDep");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["RepertoryId"]) == "")
                    {
                        MessageHandler.ShowMessageBox("退货仓库不能为空，请填写后再进行保存。");
                        FocusedHeadView("RepertoryId");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["RepertoryLocationId"]) == "")
                    {
                        MessageHandler.ShowMessageBox("退货仓位不能为空，请填写后再进行保存。");
                        FocusedHeadView("RepertoryLocationId");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["ApprovalType"]) == "")
                    {
                        MessageHandler.ShowMessageBox("审批类型不能为空，请填写后再进行保存。");
                        FocusedHeadView("ApprovalType");
                        return;
                    }

                    string projectNameStr = "";
                    for (int i = gridViewRGRList.DataRowCount - 1; i >= 0; i--)
                    {
                        DataRow listRow = gridViewRGRList.GetDataRow(i);
                        if (DataTypeConvert.GetString(listRow["CodeFileName"]) == "")
                        {
                            gridViewRGRList.DeleteRow(i);
                            continue;
                        }
                        //if (DataTypeConvert.GetString(listRow["Qty"]) == "" || DataTypeConvert.GetDouble(listRow["Qty"]) == 0)
                        //{
                        //    MessageHandler.ShowMessageBox("数量不能为空，请填写后再进行保存。");
                        //    FocusedListView(true, "Qty", i);
                        //    return;
                        //}
                        if (DataTypeConvert.GetDouble(listRow["Qty"]) == 0)
                        {
                            MessageHandler.ShowMessageBox("数量不能为空或者零，请填写后再进行保存。");
                            FocusedListView(true, "Qty", i);
                            return;
                        }
                        if (DataTypeConvert.GetString(listRow["ShelfId"]) == "")
                        {
                            MessageHandler.ShowMessageBox("货架编号不能为空，请填写后再进行保存。");
                            FocusedListView(true, "ShelfId", i);
                            return;
                        }
                        if (DataTypeConvert.GetString(listRow["ProjectName"]) == "")
                        {
                            MessageHandler.ShowMessageBox("项目号不能为空，请填写后再进行保存。");
                            FocusedListView(true, "ProjectName", i);
                            return;
                        }
                        if (DataTypeConvert.GetString(listRow["StnNo"]) == "")
                        {
                            MessageHandler.ShowMessageBox("站号不能为空，请填写后再进行保存。");
                            FocusedListView(true, "StnNo", i);
                            return;
                        }
                        if (projectNameStr != "")
                        {
                            //if (DataTypeConvert.GetString(listRow["ProjectName"]) != projectNameStr)
                            //{
                            //    MessageHandler.ShowMessageBox("一张出库单只能选择相同的项目号进行出库，请重新填写后再进行保存。");
                            //    FocusedListView(true, "ProjectName", i);
                            //    return;
                            //}
                        }
                        else
                            projectNameStr = DataTypeConvert.GetString(listRow["ProjectName"]);

                        if (!commonDAO.StnNoIsContainProjectNo(DataTypeConvert.GetString(listRow["ProjectNo"]), DataTypeConvert.GetString(listRow["StnNo"])))
                        {
                            MessageHandler.ShowMessageBox("输入的站号不属于项目号，请重新填写后再进行保存。");
                            FocusedListView(true, "StnNo", i);
                            return;
                        }
                    }

                    if (gridViewRGRList.DataRowCount == 0)
                    {
                        MessageHandler.ShowMessageBox("退货单明细不能为空，请填写后再进行保存。");
                        return;
                    }

                    int ret = rgrDAO.SaveReturnedGoodsReport(gridViewRGRHead.GetFocusedDataRow(), dataSet_RGR.Tables[1]);
                    switch (ret)
                    {
                        case -1:
                            btnQuery_Click(null, null);
                            break;
                        case 1:
                            dataSet_RGR.Tables[1].Clear();
                            rgrDAO.QueryReturnedGoodsReportList(dataSet_RGR.Tables[1], DataTypeConvert.GetString(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportNo"]), false);
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

                if (gridViewRGRHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                {
                    if (DataTypeConvert.GetString(gridViewRGRHead.GetDataRow(headFocusedLineNo)["ReturnedGoodsReportNo"]) == "")
                    {
                        gridViewRGRHead.DeleteRow(headFocusedLineNo);
                    }
                    else
                    {
                        gridViewRGRHead.GetFocusedDataRow().RejectChanges();
                    }
                }

                SetButtonAndColumnState(false);

                dataSet_RGR.Tables[1].Clear();
                if (gridViewRGRHead.GetFocusedDataRow() != null)
                    rgrDAO.QueryReturnedGoodsReportList(dataSet_RGR.Tables[1], DataTypeConvert.GetString(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportNo"]), false);

                //gridViewOrderHead_FocusedRowChanged(sender, null);
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

                int count = dataSet_RGR.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckWarehouseState_Multi(false, true, true, true))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要删除当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!rgrDAO.DeleteRGR_Multi(dataSet_RGR.Tables[0]))
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

                int count = dataSet_RGR.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckWarehouseState_Multi(false, true, true, false))
                    return;

                if (!SystemInfo.InventorySaveApproval && count == 1)
                {
                    //弹出审批页面
                    string returnedGoodsReportNoStr = DataTypeConvert.GetString(dataSet_RGR.Tables[0].Select("select=1")[0]["ReturnedGoodsReportNo"]);
                    FrmOrderApproval frmOrder = new FrmOrderApproval(returnedGoodsReportNoStr);
                    if (frmOrder.ShowDialog() == DialogResult.OK)
                    {
                        btnQuery_Click(null, null);
                        for (int i = 0; i < gridViewRGRHead.DataRowCount; i++)
                        {
                            if (DataTypeConvert.GetString(gridViewRGRHead.GetDataRow(i)["ReturnedGoodsReportNo"]) == returnedGoodsReportNoStr)
                            {
                                gridViewRGRHead.FocusedRowHandle = i;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                    {
                        return;
                    }

                    int successCountInt = 0;
                    //直接审批，不再谈页面
                    if (!rgrDAO.RGRApprovalInfo_Multi(dataSet_RGR.Tables[0], ref successCountInt))
                        btnQuery_Click(null, null);
                    else
                    {
                        MessageHandler.ShowMessageBox(string.Format("成功审批了{0}条记录。", successCountInt));
                    }
                }
                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_RGR.Tables[0].Select("select=1"), gridViewRGRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--审批按钮事件错误。", ex);
            }
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

                int count = dataSet_RGR.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckWarehouseState_Multi(true, false, true, false))
                    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要取消审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }

                if (!rgrDAO.CancalRGRApprovalInfo_Multi(dataSet_RGR.Tables[0]))
                    btnQuery_Click(null, null);
                else
                {
                    MessageHandler.ShowMessageBox(string.Format("成功取消审批了{0}条记录。", count));
                }
                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_RGR.Tables[0].Select("select=1"), gridViewRGRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--取消审批按钮事件错误。", ex);
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

                string rgrHeadNoStr = "";
                DataRow dr = null;
                DataRow[] drs = dataSet_RGR.Tables[0].Select("select=1");
                if (drs.Length > 1)
                {
                    MessageHandler.ShowMessageBox("只能选中一条记录进行打印预览，请重新选择。");
                    return;
                }
                else if (drs.Length == 0)
                {
                    if (gridViewRGRHead.GetFocusedDataRow() != null)
                    {
                        rgrHeadNoStr = DataTypeConvert.GetString(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportNo"]);
                        dr = gridViewRGRHead.GetFocusedDataRow();
                    }
                }
                else
                {
                    rgrHeadNoStr = DataTypeConvert.GetString(drs[0]["ReturnedGoodsReportNo"]);
                    dr = drs[0];
                }

                if (dr != null && SystemInfo.ApproveAfterPrint)
                {
                    if (DataTypeConvert.GetInt(dr["WarehouseState"]) != 2)
                    {
                        MessageHandler.ShowMessageBox("请审批通过后，再进行打印预览操作。");
                        return;
                    }
                }

                //string rgrHeadNoStr = "";
                //if (gridViewRGRHead.GetFocusedDataRow() != null)
                //    rgrHeadNoStr = DataTypeConvert.GetString(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportNo"]);

                //if (SystemInfo.ApproveAfterPrint)
                //{
                //    if (DataTypeConvert.GetInt(gridViewRGRHead.GetFocusedDataRow()["WarehouseState"]) != 2)
                //    {
                //        MessageHandler.ShowMessageBox("请审批通过后，再进行打印预览操作。");
                //        return;
                //    }
                //}

                rgrDAO.PrintHandle(rgrHeadNoStr, 1);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--预览按钮事件错误。", ex);
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
            foreach (DataRow dr in dataSet_RGR.Tables[0].Rows)
            {
                dr["Select"] = value;
            }
            onlySelectColChangeRowState = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_RGR.Tables[0].Select("select=1"), gridViewRGRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
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
        private void gridViewRGRHead_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridViewRGRHead.SetFocusedRowCellValue("ReturnedGoodsReportDate", BaseSQL.GetServerDateTime());
                gridViewRGRHead.SetFocusedRowCellValue("ReqDep", SystemInfo.user.DepartmentNo);
                gridViewRGRHead.SetFocusedRowCellValue("WarehouseState", 1);
                gridViewRGRHead.SetFocusedRowCellValue("Creator", SystemInfo.user.AutoId);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--主表设定默认值错误。", ex);
            }
        }

        /// <summary>
        /// 子表设定默认值
        /// </summary>
        private void gridViewRGRList_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridViewRGRList.SetFocusedRowCellValue("ReturnedGoodsReportNo", DataTypeConvert.GetString(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportNo"]));
                if (gridViewRGRList.DataRowCount > 0)
                {
                    if (gridViewRGRList.GetFocusedDataSourceRowIndex() == 0)
                    {
                        gridViewRGRList.SetFocusedRowCellValue("ProjectNo", gridViewRGRList.GetDataRow(1)["ProjectNo"]);
                        gridViewRGRList.SetFocusedRowCellValue("ProjectName", gridViewRGRList.GetDataRow(1)["ProjectName"]);
                    }
                    else
                    {
                        gridViewRGRList.SetFocusedRowCellValue("ProjectNo", gridViewRGRList.GetDataRow(0)["ProjectNo"]);
                        gridViewRGRList.SetFocusedRowCellValue("ProjectName", gridViewRGRList.GetDataRow(0)["ProjectName"]);
                    }
                }

                if (SystemInfo.DisableProjectNo)
                {
                    gridViewRGRList.SetFocusedRowCellValue("ProjectNo", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                    gridViewRGRList.SetFocusedRowCellValue("ProjectName", SystemInfo.DisableProjectNo_Default_ProjectName);
                    gridViewRGRList.SetFocusedRowCellValue("StnNo", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                }

                if (SystemInfo.DisableShelfInfo)
                {
                    gridViewRGRList.SetFocusedRowCellValue("ShelfId", SystemInfo.DisableShelfInfo_Default_ShelfId);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--子表设定默认值错误。", ex);
            }
        }

        /// <summary>
        /// 子表按键事件
        /// </summary>
        private void gridViewRGRList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!colRemark.OptionsColumn.AllowEdit)
                        return;

                    if (gridViewRGRList.GetFocusedDataSourceRowIndex() >= gridViewRGRList.DataRowCount - 1 && gridViewRGRList.FocusedColumn.Name == "colRemark")
                    {
                        ListNewRow();
                    }
                    else if (gridViewRGRList.FocusedColumn.Name == "colRemark")
                    {
                        gridViewRGRList.FocusedRowHandle = gridViewRGRList.FocusedRowHandle + 1;
                        FocusedListView(true, "CodeFileName", gridViewRGRList.GetFocusedDataSourceRowIndex());
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
                if (gridViewRGRList.GetFocusedDataRow().RowState != DataRowState.Added)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的明细记录吗？") != DialogResult.Yes)
                    {
                        return;
                    }
                }
                gridViewRGRList.DeleteRow(gridViewRGRList.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除子表中的一行错误。", ex);
            }
        }

        /// <summary>
        /// 主表单元格值变化进行的操作
        /// </summary>
        private void gridViewRGRHead_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (isLockControl)
                    return;
                switch (e.Column.FieldName)
                {
                    case "RepertoryId":
                        BindingLocationInfo(e.RowHandle);
                        break;
                    case "RepertoryLocationId":
                        isLockControl = true;

                        BindingShelfInfo(e.RowHandle);

                        isLockControl = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--主表单元格值变化进行的操作错误。", ex);
                if (isLockControl)
                    isLockControl = false;
            }
        }

        /// <summary>
        /// 绑定仓位数据源
        /// </summary>
        private void BindingLocationInfo(int rowHandleInt)
        {
            int repertoryIdInt = DataTypeConvert.GetInt(gridViewRGRHead.GetDataRow(rowHandleInt)["RepertoryId"]);
            if (repertoryIdInt == 0)
            {
                gridViewRGRHead.SetRowCellValue(rowHandleInt, "RepertoryId", null);
                gridViewRGRHead.SetRowCellValue(rowHandleInt, "RepertoryLocationId", null);
            }
            else
            {
                gridViewRGRHead.SetRowCellValue(rowHandleInt, "RepertoryLocationId", null);
            }
        }

        /// <summary>
        /// 绑定货架数据源
        /// </summary>
        private void BindingShelfInfo(int rowHandleInt)
        {
            int repertoryLocationIdInt = DataTypeConvert.GetInt(gridViewRGRHead.GetDataRow(rowHandleInt)["RepertoryLocationId"]);
            if (repertoryLocationIdInt == 0)
            {
                gridViewRGRHead.SetRowCellValue(rowHandleInt, "RepertoryLocationId", null);
            }
            else
            {
                if (!SystemInfo.DisableShelfInfo)
                {
                    for (int i = 0; i < gridViewRGRList.RowCount; i++)
                    {
                        gridViewRGRList.SetRowCellValue(i, "ShelfId", null);
                    }
                }
            }
        }

        /// <summary>
        /// 子表单元格值变化进行的操作
        /// </summary>
        private void gridViewRGRList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                switch (e.Column.FieldName)
                {
                    case "CodeFileName":
                        string tmpStr = DataTypeConvert.GetString(gridViewRGRList.GetDataRow(e.RowHandle)["CodeFileName"]);
                        if (tmpStr == "")
                        {
                            gridViewRGRList.SetRowCellValue(e.RowHandle, "CodeId", null);
                            gridViewRGRList.SetRowCellValue(e.RowHandle, "CodeName", "");
                        }
                        else
                        {
                            DataTable temp = (DataTable)repSearchCodeFileName.DataSource;
                            DataRow[] drs = temp.Select(string.Format("CodeFileName='{0}'", tmpStr));
                            if (drs.Length > 0)
                            {
                                gridViewRGRList.SetRowCellValue(e.RowHandle, "CodeId", DataTypeConvert.GetInt(drs[0]["AutoId"]));
                                gridViewRGRList.SetRowCellValue(e.RowHandle, "CodeName", DataTypeConvert.GetString(drs[0]["CodeName"]));
                            }
                        }
                        break;
                    case "ProjectName":
                        string projectNameStr = DataTypeConvert.GetString(gridViewRGRList.GetDataRow(e.RowHandle)["ProjectName"]);
                        string projectNoStr = "";
                        if (projectNameStr == "")
                        {
                            gridViewRGRList.SetRowCellValue(e.RowHandle, "ProjectNo", "");
                            gridViewRGRList.SetRowCellValue(e.RowHandle, "ProjectName", "");
                            gridViewRGRList.SetRowCellValue(e.RowHandle, "StnNo", "");
                        }
                        else
                        {
                            DataTable temp = (DataTable)repSearchProjectNo.DataSource;
                            DataRow[] drs = temp.Select(string.Format("ProjectName='{0}'", projectNameStr));
                            if (drs.Length > 0)
                            {
                                gridViewRGRList.SetRowCellValue(e.RowHandle, "ProjectNo", DataTypeConvert.GetString(drs[0]["ProjectNo"]));
                                projectNoStr = DataTypeConvert.GetString(drs[0]["ProjectNo"]);
                            }
                            gridViewRGRList.SetRowCellValue(e.RowHandle, "StnNo", "");
                        }
                        BingStnListComboBox(projectNoStr);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--子表单元格值变化进行的操作错误。", ex);
            }
        }

        /// <summary>
        /// 仓位弹出下拉列表设定过滤
        /// </summary>
        private void repSearchRepertoryLocationId_Popup(object sender, EventArgs e)
        {
            try
            {
                FilterLookup(sender, "RepertoryId", "RepertoryId");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--仓位弹出下拉列表设定过滤错误。", ex);
            }
        }

        /// <summary>
        /// 货架号弹出下拉列表设定过滤
        /// </summary>
        private void repSearchShelfId_Popup(object sender, EventArgs e)
        {
            try
            {
                FilterLookup(sender, "RepertoryLocationId", "RepertoryLocationId");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--货架号弹出下拉列表设定过滤错误。", ex);
            }
        }

        /// <summary>
        /// 设定过滤条件
        /// </summary>
        private void FilterLookup(object sender, string fieldNameStr, string gridColumnNameStr)
        {
            SearchLookUpEdit edit = sender as SearchLookUpEdit;
            GridView gridView = edit.Properties.View as GridView;

            gridView.ActiveFilterString = string.Format("{0} = {1}", fieldNameStr, DataTypeConvert.GetInt(gridViewRGRHead.GetFocusedDataRow()[gridColumnNameStr]));
            gridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;

            MethodInfo mi = gridView.GetType().GetMethod("ApplyColumnsFilterEx", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(gridView, null);
        }

        /// <summary>
        /// 设定当前行选择
        /// </summary>
        private void repCheckSelect_EditValueChanged(object sender, EventArgs e)
        {
            if (DataTypeConvert.GetBoolean(gridViewRGRHead.GetFocusedDataRow()["Select"]))
                gridViewRGRHead.GetFocusedDataRow()["Select"] = false;
            else
                gridViewRGRHead.GetFocusedDataRow()["Select"] = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_RGR.Tables[0].Select("select=1"), gridViewRGRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);

            onlySelectColChangeRowState = true;
        }

        /// <summary>
        /// 检查是否有未填写字段
        /// </summary>
        private bool IsHaveBlankLine()
        {
            gridViewRGRList.FocusedRowHandle = 0;
            for (int i = 0; i < gridViewRGRList.DataRowCount; i++)
            {
                if (DataTypeConvert.GetString(gridViewRGRList.GetDataRow(i)["CodeFileName"]) == "")
                {
                    gridViewRGRList.Focus();
                    gridViewRGRList.FocusedColumn = colCodeFileName;
                    gridViewRGRList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewRGRList.GetDataRow(i)["ShelfId"]) == "")
                {
                    gridViewRGRList.Focus();
                    gridViewRGRList.FocusedColumn = colShelfId;
                    gridViewRGRList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewRGRList.GetDataRow(i)["Qty"]) == "")
                {
                    gridViewRGRList.Focus();
                    gridViewRGRList.FocusedColumn = colQty;
                    gridViewRGRList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewRGRList.GetDataRow(i)["ProjectName"]) == "")
                {
                    gridViewRGRList.Focus();
                    gridViewRGRList.FocusedColumn = colProjectName;
                    gridViewRGRList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewRGRList.GetDataRow(i)["StnNo"]) == "")
                {
                    gridViewRGRList.Focus();
                    gridViewRGRList.FocusedColumn = colStnNo;
                    gridViewRGRList.FocusedRowHandle = i;
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

            //gridViewWRList.PostEditor();
            gridViewRGRList.AddNewRow();
            FocusedListView(true, "CodeFileName", gridViewRGRList.GetFocusedDataSourceRowIndex());
            //gridViewWRList.RefreshData();
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
                //btnApprove.Enabled = true;
                //btnCancelApprove.Enabled = true;
                //btnPreview.Enabled = true;

                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_RGR.Tables[0].Select("select=1"), gridViewRGRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
            }
            btnListAdd.Enabled = ret;

            //if (SystemInfo.WarehouseReceiptIsAlterDate)
            //{
            //    colWarehouseReceiptDate.OptionsColumn.AllowEdit = ret;
            //    colWarehouseReceiptDate.OptionsColumn.TabStop = ret;
            //}

            colBussinessBaseNo.OptionsColumn.AllowEdit = ret;
            colRepertoryId.OptionsColumn.AllowEdit = ret;
            colRepertoryLocationId.OptionsColumn.AllowEdit = ret;
            colReturnedGoodsReasons.OptionsColumn.AllowEdit = ret;
            colApprovalType.OptionsColumn.AllowEdit = ret;
            colRemark1.OptionsColumn.AllowEdit = ret;

            colCodeFileName.OptionsColumn.AllowEdit = ret;
            colQty.OptionsColumn.AllowEdit = ret;
            colShelfId.OptionsColumn.AllowEdit = ret;
            colProjectName.OptionsColumn.AllowEdit = ret;
            colStnNo.OptionsColumn.AllowEdit = ret;
            colRemark.OptionsColumn.AllowEdit = ret;

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
        /// 检测出库单状态是否可以操作
        /// </summary>
        private bool CheckWarehouseState()
        {
            if (gridViewRGRHead.GetFocusedDataRow() == null)
                return false;
            int reqState = DataTypeConvert.GetInt(gridViewRGRHead.GetFocusedDataRow()["WarehouseState"]);
            switch (reqState)
            {
                case (int)CommonHandler.WarehouseState.已审批:
                    MessageHandler.ShowMessageBox(string.Format("退货单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportNo"]), CommonHandler.WarehouseState.已审批));
                    return false;
                //case (int)CommonHandler.WarehouseState.已结账:
                //    MessageHandler.ShowMessageBox(string.Format("退货单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportNo"]),CommonHandler.WarehouseState.已结账));
                //    return false;
                case (int)CommonHandler.WarehouseState.审批中:
                    MessageHandler.ShowMessageBox(string.Format("退货单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportNo"]), CommonHandler.WarehouseState.审批中));
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检测当前选中的出库单状态是否可以操作
        /// </summary>
        private bool CheckWarehouseState_Multi(bool checkNoApprover, bool checkApprover, bool checkSettle, bool checkApproverBetween)
        {
            for (int i = 0; i < gridViewRGRHead.DataRowCount; i++)
            {
                if (DataTypeConvert.GetBoolean(gridViewRGRHead.GetDataRow(i)["Select"]))
                {
                    int reqState = DataTypeConvert.GetInt(gridViewRGRHead.GetDataRow(i)["WarehouseState"]);
                    switch (reqState)
                    {
                        case (int)CommonHandler.WarehouseState.待审批:
                            if (checkNoApprover)
                            {
                                MessageHandler.ShowMessageBox(string.Format("退货单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewRGRHead.GetDataRow(i)["ReturnedGoodsReportNo"]), CommonHandler.WarehouseState.待审批));
                                gridViewRGRHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.WarehouseState.已审批:
                            if (checkApprover)
                            {
                                MessageHandler.ShowMessageBox(string.Format("退货单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewRGRHead.GetDataRow(i)["ReturnedGoodsReportNo"]), CommonHandler.WarehouseState.已审批));
                                gridViewRGRHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        //case (int)CommonHandler.WarehouseState.已结账:
                        //    if (checkSettle)
                        //    {
                        //        MessageHandler.ShowMessageBox(string.Format("退货单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewRGRHead.GetDataRow(i)["ReturnedGoodsReportNo"]),CommonHandler.WarehouseState.已结账));
                        //        gridViewRGRHead.FocusedRowHandle = i;
                        //        return false;
                        //    }
                        //    break;
                        case (int)CommonHandler.WarehouseState.审批中:
                            if (checkApproverBetween)
                            {
                                MessageHandler.ShowMessageBox(string.Format("退货单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewRGRHead.GetDataRow(i)["ReturnedGoodsReportNo"]), CommonHandler.WarehouseState.审批中));
                                gridViewRGRHead.FocusedRowHandle = i;
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
            gridControlRGRHead.Focus();
            ColumnView headView = (ColumnView)gridControlRGRHead.FocusedView;
            headView.FocusedColumn = headView.Columns[colName];
            gridViewRGRHead.FocusedRowHandle = headView.FocusedRowHandle;
        }

        /// <summary>
        /// 聚焦子表当前行的列
        /// </summary>
        private void FocusedListView(bool isFocusedControl, string colName, int lineNo)
        {
            if (isFocusedControl)
                gridControlRGRList.Focus();
            ColumnView listView = (ColumnView)gridControlRGRList.FocusedView;
            listView.FocusedColumn = listView.Columns[colName];
            gridViewRGRList.FocusedRowHandle = lineNo;
        }

        /// <summary>
        /// 绑定站号的ComboBox控件
        /// </summary>
        private void BingStnListComboBox(string projectNoStr)
        {
            DataTable stnListTable = commonDAO.QueryStnList(projectNoStr);
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
            for (int i = 0; i < dataSet_RGR.Tables[0].Rows.Count; i++)
            {
                dataSet_RGR.Tables[0].Rows[i]["Select"] = false;
            }
            dataSet_RGR.Tables[0].AcceptChanges();
            onlySelectColChangeRowState = false;
        }

        #endregion

    }
}
