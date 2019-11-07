using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using PSAP.DAO.BSDAO;
using PSAP.DAO.INVDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmWarehouseReceipt_Drag : DockContent
    {
        #region 私有变量

        FrmWarehouseReceiptDAO wrDAO = new FrmWarehouseReceiptDAO();
        FrmWarehouseWarrantDAO wwDAO = new FrmWarehouseWarrantDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmWarehouseCommonDAO whDAO = new FrmWarehouseCommonDAO();

        /// <summary>
        /// 主表聚焦的行号
        /// </summary>
        int headFocusedLineNo = 0;

        /// <summary>
        /// 查询的入库单号
        /// </summary>
        public static string queryWRHeadNo = "";

        /// <summary>
        /// 只有选择列改变行状态的时候
        /// </summary>
        bool onlySelectColChangeRowState = false;

        ///// <summary>
        ///// 拖动区域的信息
        ///// </summary>
        //GridHitInfo GriddownHitInfo = null;

        /// <summary>
        /// 拖动Tree区域的信息
        /// </summary>
        TreeListHitInfo downHitInfo = null;

        /// <summary>
        /// 控件锁
        /// </summary>
        bool isLockControl = false;

        static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();

        #endregion

        #region 构造方法

        public FrmWarehouseReceipt_Drag()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(f);
            PSAP.BLL.BSBLL.BSBLL.language(this);
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWarehouseReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                //ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd, checkAll });
                ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd });

                ControlCommonInit ctlInit = new ControlCommonInit();

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateWRDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateWRDateEnd.DateTime = nowDate.Date;

                DataTable manufactureInfo_f = commonDAO.QueryManufactureInfo(false);

                lookUpReqDep.Properties.DataSource = commonDAO.QueryDepartment(true);
                lookUpReqDep.ItemIndex = 0;
                lookUpRepertoryId.Properties.DataSource = commonDAO.QueryRepertoryInfo(true);
                lookUpRepertoryId.ItemIndex = 0;
                //SearchLocationId.Properties.DataSource = commonDAO.QueryRepertoryLocationInfo(true);
                //SearchLocationId.EditValue = 0;
                ctlInit.SearchLookUpEdit_RepertoryLocationInfo(SearchLocationId, true);
                SearchLocationId.EditValue = 0;
                lookUpWarehouseReceiptTypeNo.Properties.DataSource = wrDAO.QueryWarehouseReceiptType(true);
                lookUpWarehouseReceiptTypeNo.ItemIndex = 0;
                ctlInit.ComboBoxEdit_WarehouseState(comboBoxWarehouseState);
                comboBoxWarehouseState.SelectedIndex = 0;
                lookUpManufactureNo.Properties.DataSource = commonDAO.QueryManufactureInfo(true);
                lookUpManufactureNo.ItemIndex = 0;
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpApprover);
                searchLookUpApprover.EditValue = null;
                
                repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                repLookUpRepertoryId.DataSource = commonDAO.QueryRepertoryInfo(false);
                //repSearchRepertoryLocationId.DataSource = commonDAO.QueryRepertoryLocationInfo(false);
                ctlInit.RepositoryItemSearchLookUpEdit_RepertoryLocationInfo(repSearchRepertoryLocationId);
                repLookUpWRTypeNo.DataSource = wrDAO.QueryWarehouseReceiptType(false);
                repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);
                repLookUpManufactureNo.DataSource = manufactureInfo_f;
                repItemLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;

                //repSearchCodeFileName.DataSource = codeIdInfoTable_f;
                ctlInit.RepositoryItemSearchLookUpEdit_PartsCode(repSearchCodeFileName, "CodeFileName", "CodeFileName");
                //repSearchShelfId.DataSource = commonDAO.QueryShelfInfo(false);
                ctlInit.RepositoryItemSearchLookUpEdit_ShelfInfo(repSearchShelfId);
                //repSearchProjectNo.DataSource = projectNo_f;
                ctlInit.RepositoryItemSearchLookUpEdit_ProjectList(repSearchProjectNo, "ProjectName", "ProjectName");

                datePlanDateBegin.DateTime = dateWRDateBegin.DateTime;
                datePlanDateEnd.DateTime = dateWRDateEnd.DateTime;
                //searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(true);
                //searchLookUpProjectNo.Text = "全部";
                ctlInit.SearchLookUpEdit_ProjectList(searchLookUpProjectNo, true);
                searchLookUpProjectNo.Text = "全部";

                //repLookUpManufactureNo.DataSource = manufactureInfo_f;
                repItemSearchProjectNo.DataSource = repSearchProjectNo.DataSource;
                //repLookUpCreator.DataSource = userInfoTable_t;

                repLookUpCodeId.DataSource = repSearchCodeFileName.DataSource;

                if (textCommon.Text == "")
                {
                    wrDAO.QueryWarehouseReceiptHead(dataSet_WR.Tables[0], "", "", "", 0, 0, "", "", 0, 0, -1, "", true);
                    wrDAO.QueryWarehouseReceiptList(dataSet_WR.Tables[1], "", true);
                }

                if (SystemInfo.DisableProjectNo)
                {
                    btnOrderQuery.Location = new Point(243, 13);
                    pnlLeftTop.Height = 80;

                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    colProjectName.Visible = false;
                    colStnNo.Visible = false;
                    gridColumProjectNo.Visible = false;
                }

                if (SystemInfo.DisableShelfInfo)
                {
                    colShelfId.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiCtjzsjcw.Text, ex);
            }
        }

        /// <summary>
        /// 窗体激活事件
        /// </summary>
        private void FrmWarehouseReceipt_Activated(object sender, EventArgs e)
        {
            try
            {
                if (queryWRHeadNo != "")
                {
                    textCommon.Text = queryWRHeadNo;
                    queryWRHeadNo = "";

                    lookUpReqDep.ItemIndex = 0;
                    lookUpRepertoryId.ItemIndex = 0;
                    SearchLocationId.EditValue = 0;
                    lookUpWarehouseReceiptTypeNo.ItemIndex = 0;
                    comboBoxWarehouseState.SelectedIndex = 0;
                    searchLookUpCreator.EditValue = 0;
                    searchLookUpApprover.EditValue = null;

                    dataSet_WR.Tables[0].Clear();
                    headFocusedLineNo = 0;
                    wrDAO.QueryWarehouseReceiptHead(dataSet_WR.Tables[0], "", "", "", 0, 0, "", "", 0, 0, -1, textCommon.Text, false);
                    SetButtonAndColumnState(false);

                    if (dataSet_WR.Tables[0].Rows.Count > 0)
                    {
                        dateWRDateBegin.DateTime = DataTypeConvert.GetDateTime(dataSet_WR.Tables[0].Rows[0]["WarehouseReceiptDate"]).Date;
                        dateWRDateEnd.DateTime = dateWRDateBegin.DateTime.AddDays(7);
                    }
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体激活事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiCtjhsjcw.Text, ex);
            }
        }

        /// <summary>
        /// 窗体显示事件
        /// </summary>
        private void FrmWarehouseReceipt_Shown(object sender, EventArgs e)
        {
            pnlMiddle.Height = (this.Height - pnltop.Height) / 2;
            pnlLeftMiddle.Height = gridControlWRHead.Height - 17;

            dockPnlLeft.Width = SystemInfo.DragForm_LeftDock_Width;
        }

        #endregion

        #region 右侧材料出库单模块的相关事件和方法

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

                if (dateWRDateBegin.EditValue == null || dateWRDateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox(tsmiCkrqbnwkcx.Text);// ("出库日期不能为空，请设置后重新进行查询。");
                    if (dateWRDateBegin.EditValue == null)
                        dateWRDateBegin.Focus();
                    else
                        dateWRDateEnd.Focus();
                    return;
                }
                string wrDateBeginStr = dateWRDateBegin.DateTime.ToString("yyyy-MM-dd");
                string wrDateEndStr = dateWRDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                string reqDepStr = lookUpReqDep.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpReqDep.EditValue) : "";
                int repertoryIdInt = lookUpRepertoryId.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpRepertoryId.EditValue) : 0;
                int locationIdInt = DataTypeConvert.GetInt(SearchLocationId.EditValue);
                string wrTypeNoStr = lookUpWarehouseReceiptTypeNo.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpWarehouseReceiptTypeNo.EditValue) : "";
                string manufactureNoStr = lookUpManufactureNo.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpManufactureNo.EditValue) : "";

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

                dataSet_WR.Tables[0].Rows.Clear();
                dataSet_WR.Tables[1].Rows.Clear();
                headFocusedLineNo = 0;
                wrDAO.QueryWarehouseReceiptHead(dataSet_WR.Tables[0], wrDateBeginStr, wrDateEndStr, reqDepStr, repertoryIdInt, locationIdInt, wrTypeNoStr, manufactureNoStr, warehouseStateInt, creatorInt, approverInt, commonStr, false);

                SetButtonAndColumnState(false);
                checkAll.Checked = false;
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--查询按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiCxansjcw.Text, ex);
            }
        }

        /// <summary>
        /// 主表聚焦行改变事件
        /// </summary>
        private void gridViewWRHead_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewWRHead.GetFocusedDataRow() != null)
                {
                    if (onlySelectColChangeRowState)
                    {
                        dataSet_WR.Tables[0].AcceptChanges();
                        onlySelectColChangeRowState = false;

                        if (btnNew.Enabled)
                            ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_WR.Tables[0].Select("select=1"), gridViewWRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
                    }
                    else
                    {
                        if (headFocusedLineNo < gridViewWRHead.DataRowCount && gridViewWRHead.FocusedRowHandle != headFocusedLineNo && gridViewWRHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                        {
                            MessageHandler.ShowMessageBox(tsmiDqckdyjxghh.Text);// ("当前出库单已经修改，请保存后再进行换行。");
                            gridViewWRHead.FocusedRowHandle = headFocusedLineNo;
                        }
                        else if (headFocusedLineNo == gridViewWRHead.DataRowCount)
                        {

                        }
                        else
                        {
                            if (gridViewWRHead.FocusedRowHandle != headFocusedLineNo && gridViewWRHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                            else if (gridViewWRHead.GetDataRow(headFocusedLineNo).RowState == DataRowState.Unchanged)
                            {
                                btnCancel_Click(null, null);
                            }
                        }
                    }

                    if (DataTypeConvert.GetString(gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]) != "")
                    {
                        dataSet_WR.Tables[1].Clear();
                        wrDAO.QueryWarehouseReceiptList(dataSet_WR.Tables[1], DataTypeConvert.GetString(gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]), false);
                    }

                    if (gridViewWRHead.FocusedRowHandle >= 0)
                    {
                        headFocusedLineNo = gridViewWRHead.FocusedRowHandle;
                    }
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--主表聚焦行改变事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiZbjjhgb.Text, ex);
            }
        }

        /// <summary>
        /// 子表聚焦行改变事件
        /// </summary>
        private void gridViewWRList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewWRList.GetFocusedDataRow() != null)
                {
                    string projectNoStr = DataTypeConvert.GetString(gridViewWRList.GetFocusedDataRow()["ProjectNo"]);
                    BingStnListComboBox(projectNoStr);

                    if (!btnNew.Enabled && DataTypeConvert.GetInt(gridViewWRList.GetFocusedDataRow()["ProductionPlanListId"]) == 0)
                    {
                        colCodeFileName.OptionsColumn.AllowEdit = true;
                        colProjectName.OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        colCodeFileName.OptionsColumn.AllowEdit = false;
                        colProjectName.OptionsColumn.AllowEdit = false;
                    }
                }
                else
                {
                    colCodeFileName.OptionsColumn.AllowEdit = false;
                    colProjectName.OptionsColumn.AllowEdit = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--子表聚焦行改变事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiZbjjhgb.Text, ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewWRHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        private void gridViewWRHead_KeyDown(object sender, KeyEventArgs e)
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
        private void gridViewWRHead_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
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

                gridViewWRHead.AddNewRow();
                FocusedHeadView("RepertoryId");

                dataSet_WR.Tables[1].Clear();
                gridViewWRList.AddNewRow();
                FocusedListView(false, "CodeFileName", gridViewWRList.GetFocusedDataSourceRowIndex());
                gridViewWRList.RefreshData();

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewWRHead.DataRowCount;
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--新增按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiXzansj.Text, ex);
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

                if (gridViewWRHead.GetFocusedDataRow() == null)
                    return;

                if (!CheckWarehouseState())
                    return;

                if (btnSave.Tag.ToString() != "保存")
                {
                    if (!whDAO.IsAlterWarehouseOrder(DataTypeConvert.GetDateTime(gridViewWRHead.GetFocusedDataRow()["WarehouseReceiptDate"])))
                        return;

                    ClearHeadGridAllSelect();

                    SetButtonAndColumnState(true);
                    FocusedHeadView("RepertoryId");
                }
                else
                {
                    DataRow headRow = gridViewWRHead.GetFocusedDataRow();
                    if (DataTypeConvert.GetString(headRow["ReqDep"]) == "")
                    {
                        MessageHandler.ShowMessageBox(tsmiCkbmbnwkbc.Text);// ("出库部门不能为空，请填写后再进行保存。");
                        FocusedHeadView("ReqDep");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["RepertoryId"]) == "")
                    {
                        MessageHandler.ShowMessageBox(tsmiCkckbnwkbc.Text);// ("出库仓库不能为空，请填写后再进行保存。");
                        FocusedHeadView("RepertoryId");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["RepertoryLocationId"]) == "")
                    {
                        MessageHandler.ShowMessageBox("出库仓位不能为空，请填写后再进行保存。");
                        FocusedHeadView("RepertoryLocationId");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["WarehouseReceiptTypeNo"]) == "")
                    {
                        MessageHandler.ShowMessageBox(tsmiCklbbnwkbc.Text);// ("出库类别不能为空，请填写后再进行保存。");
                        FocusedHeadView("WarehouseReceiptTypeNo");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["ApprovalType"]) == "")
                    {
                        MessageHandler.ShowMessageBox(tsmiSplxbnwkbc.Text);// ("审批类型不能为空，请填写后再进行保存。");
                        FocusedHeadView("ApprovalType");
                        return;
                    }

                    string projectNameStr = "";
                    for (int i = gridViewWRList.DataRowCount - 1; i >= 0; i--)
                    {
                        DataRow listRow = gridViewWRList.GetDataRow(i);
                        if (DataTypeConvert.GetString(listRow["CodeFileName"]) == "")
                        {
                            gridViewWRList.DeleteRow(i);
                            continue;
                        }
                        if (DataTypeConvert.GetString(listRow["Qty"]) == "" || DataTypeConvert.GetDouble(listRow["Qty"]) == 0)
                        {
                            MessageHandler.ShowMessageBox(tsmiSlbnwkbc.Text);// ("数量不能为空，请填写后再进行保存。");
                            FocusedListView(true, "Qty", i);
                            return;
                        }
                        if (DataTypeConvert.GetString(listRow["ShelfId"]) == "")
                        {
                            MessageHandler.ShowMessageBox(tsmiHjbhbnwkbc.Text);// ("货架编号不能为空，请填写后再进行保存。");
                            FocusedListView(true, "ShelfId", i);
                            return;
                        }
                        if (DataTypeConvert.GetString(listRow["ProjectName"]) == "")
                        {
                            MessageHandler.ShowMessageBox(f.tsmiXmhbnwkbc.Text);// ("项目号不能为空，请填写后再进行保存。");
                            FocusedListView(true, "ProjectName", i);
                            return;
                        }
                        if (DataTypeConvert.GetString(listRow["StnNo"]) == "")
                        {
                            MessageHandler.ShowMessageBox(f.tsmiZhbnwkbc.Text);// ("站号不能为空，请填写后再进行保存。");
                            FocusedListView(true, "StnNo", i);
                            return;
                        }
                        if (projectNameStr != "")
                        {
                            if (DataTypeConvert.GetString(listRow["ProjectName"]) != projectNameStr)
                            {
                                MessageHandler.ShowMessageBox(tsmiYzckdznxzxtdxmhjxckbc.Text);// ("一张出库单只能选择相同的项目号进行出库，请重新填写后再进行保存。");
                                FocusedListView(true, "ProjectName", i);
                                return;
                            }
                        }
                        else
                            projectNameStr = DataTypeConvert.GetString(listRow["ProjectName"]);

                        if (!commonDAO.StnNoIsContainProjectNo(DataTypeConvert.GetString(listRow["ProjectNo"]), DataTypeConvert.GetString(listRow["StnNo"])))
                        {
                            MessageHandler.ShowMessageBox(f.tsmiSrdzhbsyxmhbc.Text);// ("输入的站号不属于项目号，请重新填写后再进行保存。");
                            FocusedListView(true, "StnNo", i);
                            return;
                        }
                    }

                    if (gridViewWRList.DataRowCount == 0)
                    {
                        MessageHandler.ShowMessageBox(tsmiCkdmxbnwkbc.Text);// ("出库单明细不能为空，请填写后再进行保存。");
                        return;
                    }

                    int ret = wrDAO.SaveWarehouseReceipt(gridViewWRHead.GetFocusedDataRow(), dataSet_WR.Tables[1]);
                    switch (ret)
                    {
                        case -1:
                            btnQuery_Click(null, null);
                            break;
                        case 1:
                            dataSet_WR.Tables[1].Clear();
                            wrDAO.QueryWarehouseReceiptList(dataSet_WR.Tables[1], DataTypeConvert.GetString(gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]), false);
                            break;
                        case 0:
                            return;
                    }

                    SetButtonAndColumnState(false);
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--保存按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiBcansj.Text, ex);
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

                if (gridViewWRHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                {
                    if (DataTypeConvert.GetString(gridViewWRHead.GetDataRow(headFocusedLineNo)["WarehouseReceipt"]) == "")
                    {
                        gridViewWRHead.DeleteRow(headFocusedLineNo);
                    }
                    else
                    {
                        gridViewWRHead.GetFocusedDataRow().RejectChanges();
                    }
                }

                SetButtonAndColumnState(false);

                dataSet_WR.Tables[1].Clear();
                if (gridViewWRHead.GetFocusedDataRow() != null)
                    wrDAO.QueryWarehouseReceiptList(dataSet_WR.Tables[1], DataTypeConvert.GetString(gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]), false);

                gridViewProductionPlan_FocusedRowChanged(sender, null);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--取消按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiQxansj.Text, ex);
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

                int count = dataSet_WR.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox(f.tsmiQzyczdjlq.Text);// ("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckWarehouseState_Multi(false, true, true, true))
                    return;

                //if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要删除当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                if (MessageHandler.ShowMessageBox_YesNo(string.Format(f.tsmiQdyscdqxzd.Text + "{0}" + f.tsmiTjlm.Text, count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!wrDAO.DeleteWR_Multi(dataSet_WR.Tables[0]))
                {

                }

                btnQuery_Click(null, null);
                ClearHeadGridAllSelect();
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--删除按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiScansj.Text, ex);
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

                int count = dataSet_WR.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox(f.tsmiQzyczdjlq.Text);// ("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckWarehouseState_Multi(false, true, true, false))
                    return;

                if (!SystemInfo.InventorySaveApproval && count == 1)
                {
                    ////弹出审批页面
                    //FrmWarehouseReceiptApproval frmWR = new FrmWarehouseReceiptApproval(DataTypeConvert.GetString(dataSet_WR.Tables[0].Select("select=1")[0]["WarehouseReceipt"]));
                    //if (frmWR.ShowDialog() == DialogResult.OK)
                    //    btnQuery_Click(null, null);

                    //弹出审批页面
                    string warehouseReceiptStr = DataTypeConvert.GetString(dataSet_WR.Tables[0].Select("select=1")[0]["WarehouseReceipt"]);
                    FrmOrderApproval frmOrder = new FrmOrderApproval(warehouseReceiptStr);
                    if (frmOrder.ShowDialog() == DialogResult.OK)
                    {
                        btnQuery_Click(null, null);
                        for (int i = 0; i < gridViewWRHead.DataRowCount; i++)
                        {
                            if (DataTypeConvert.GetString(gridViewWRHead.GetDataRow(i)["WarehouseReceipt"]) == warehouseReceiptStr)
                            {
                                gridViewWRHead.FocusedRowHandle = i;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    //if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                    if (MessageHandler.ShowMessageBox_YesNo(string.Format(f.tsmiQdyspxzd.Text + "{0}" + f.tsmiTjlm.Text, count)) != DialogResult.Yes)
                    {
                        return;
                    }

                    int successCountInt = 0;
                    //直接审批，不再谈页面
                    if (!wrDAO.WRApprovalInfo_Multi(dataSet_WR.Tables[0], ref successCountInt))
                        btnQuery_Click(null, null);
                    else
                    {
                        //MessageHandler.ShowMessageBox(string.Format("成功审批了{0}条记录。", successCountInt));
                        MessageHandler.ShowMessageBox(string.Format(f.tsmiCgspl.Text + "{0}" + f.tsmiTjl.Text, successCountInt));
                    }
                }
                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_WR.Tables[0].Select("select=1"), gridViewWRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--审批按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiSpansj.Text, ex);
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

                int count = dataSet_WR.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox(f.tsmiQzyczdjlq.Text);// ("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckWarehouseState_Multi(true, false, true, false))
                    return;

                //if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要取消审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                if (MessageHandler.ShowMessageBox_YesNo(string.Format(f.tsmiQdyqxspdq.Text + "{0}" + f.tsmiTjlm.Text, count)) != DialogResult.Yes)
                {
                    return;
                }

                if (!wrDAO.CancalWRApprovalInfo_Multi(dataSet_WR.Tables[0]))
                    btnQuery_Click(null, null);
                else
                {
                    //MessageHandler.ShowMessageBox(string.Format("成功取消审批了{0}条记录。", count));
                    MessageHandler.ShowMessageBox(string.Format(f.tsmiCgqxspl.Text + "{0}" + f.tsmiTjl.Text, count));
                }
                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_WR.Tables[0].Select("select=1"), gridViewWRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--取消审批按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiQxspansj.Text, ex);
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

                string wrHeadNoStr = "";
                DataRow dr = null;
                DataRow[] drs = dataSet_WR.Tables[0].Select("select=1");
                if (drs.Length > 1)
                {
                    MessageHandler.ShowMessageBox("只能选中一条记录进行打印预览，请重新选择。");
                    return;
                }
                else if (drs.Length == 0)
                {
                    if (gridViewWRHead.GetFocusedDataRow() != null)
                    {
                        wrHeadNoStr = DataTypeConvert.GetString(gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]);
                        dr = gridViewWRHead.GetFocusedDataRow();
                    }
                }
                else
                {
                    wrHeadNoStr = DataTypeConvert.GetString(drs[0]["WarehouseReceipt"]);
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

                //string wrHeadNoStr = "";
                //if (gridViewWRHead.GetFocusedDataRow() != null)
                //    wrHeadNoStr = DataTypeConvert.GetString(gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]);

                //if (SystemInfo.ApproveAfterPrint)
                //{
                //    if (DataTypeConvert.GetInt(gridViewWRHead.GetFocusedDataRow()["WarehouseState"]) != 2)
                //    {
                //        MessageHandler.ShowMessageBox("请审批通过后，再进行打印预览操作。");
                //        return;
                //    }
                //}

                wrDAO.PrintHandle(wrHeadNoStr, 1);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--预览按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiYlansjcw.Text, ex);
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
            foreach (DataRow dr in dataSet_WR.Tables[0].Rows)
            {
                dr["Select"] = value;
            }
            onlySelectColChangeRowState = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_WR.Tables[0].Select("select=1"), gridViewWRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
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
                //ExceptionHandler.HandleException(this.Text + "--子表新增一行事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiZbxzyhsjcw.Text, ex);
            }
        }

        /// <summary>
        /// 主表设定默认值
        /// </summary>
        private void gridViewWRHead_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridViewWRHead.SetFocusedRowCellValue("WarehouseReceiptDate", BaseSQL.GetServerDateTime());
                gridViewWRHead.SetFocusedRowCellValue("ReqDep", SystemInfo.user.DepartmentNo);
                gridViewWRHead.SetFocusedRowCellValue("WarehouseState", 1);
                gridViewWRHead.SetFocusedRowCellValue("Creator", SystemInfo.user.AutoId);
                gridViewWRHead.SetFocusedRowCellValue("WarehouseReceiptTypeNo", wwDAO.Get_WarehouseType_TypeNo("BS_WarehouseReceiptType", "WarehouseReceiptTypeNo"));
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--主表设定默认值错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiZbsdmrzcw.Text, ex);
            }
        }

        /// <summary>
        /// 子表设定默认值
        /// </summary>
        private void gridViewWRList_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridViewWRList.SetFocusedRowCellValue("WarehouseReceipt", DataTypeConvert.GetString(gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]));
                if (gridViewWRList.DataRowCount > 0)
                {
                    if (gridViewWRList.GetFocusedDataSourceRowIndex() == 0)
                    {
                        gridViewWRList.SetFocusedRowCellValue("ProjectNo", gridViewWRList.GetDataRow(1)["ProjectNo"]);
                        gridViewWRList.SetFocusedRowCellValue("ProjectName", gridViewWRList.GetDataRow(1)["ProjectName"]);
                    }
                    else
                    {
                        gridViewWRList.SetFocusedRowCellValue("ProjectNo", gridViewWRList.GetDataRow(0)["ProjectNo"]);
                        gridViewWRList.SetFocusedRowCellValue("ProjectName", gridViewWRList.GetDataRow(0)["ProjectName"]);
                    }
                }

                if (SystemInfo.DisableProjectNo)
                {
                    gridViewWRList.SetFocusedRowCellValue("ProjectNo", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                    gridViewWRList.SetFocusedRowCellValue("ProjectName", SystemInfo.DisableProjectNo_Default_ProjectName);
                    gridViewWRList.SetFocusedRowCellValue("StnNo", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                }

                if (SystemInfo.DisableShelfInfo)
                {
                    gridViewWRList.SetFocusedRowCellValue("ShelfId", SystemInfo.DisableShelfInfo_Default_ShelfId);
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--子表设定默认值错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiZbsdmrzcw.Text, ex);
            }
        }

        /// <summary>
        /// 子表按键事件
        /// </summary>
        private void gridViewWRList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!colRemark.OptionsColumn.AllowEdit)
                        return;

                    if (gridViewWRList.GetFocusedDataSourceRowIndex() >= gridViewWRList.DataRowCount - 1 && gridViewWRList.FocusedColumn.Name == "colRemark")
                    {
                        ListNewRow();
                    }
                    else if (gridViewWRList.FocusedColumn.Name == "colRemark")
                    {
                        gridViewWRList.FocusedRowHandle = gridViewWRList.FocusedRowHandle + 1;
                        FocusedListView(true, "CodeFileName", gridViewWRList.GetFocusedDataSourceRowIndex());
                    }
                }
                else
                {
                    ControlHandler.GridView_GetFocusedCellDisplayText_KeyDown(sender, e);
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--子表按键事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiZbajsjcw.Text, ex);
            }
        }

        /// <summary>
        /// 删除子表中的一行
        /// </summary>
        private void repbtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridViewWRList.GetFocusedDataRow().RowState != DataRowState.Added)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的明细记录吗？") != DialogResult.Yes)
                    {
                        return;
                    }
                }

                int ppListIdInt = 0;
                if (gridViewWRList.GetFocusedDataRow() != null)
                    ppListIdInt = DataTypeConvert.GetInt(gridViewWRList.GetFocusedDataRow()["ProductionPlanListId"]);
                gridViewWRList.DeleteRow(gridViewWRList.FocusedRowHandle);
                if (ppListIdInt > 0)
                    gridViewProductionPlan_FocusedRowChanged(sender, null);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--删除子表中的一行错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiSczbzyhcw.Text, ex);
            }
        }

        /// <summary>
        /// 主表单元格值变化进行的操作
        /// </summary>
        private void gridViewWRHead_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
            int repertoryIdInt = DataTypeConvert.GetInt(gridViewWRHead.GetDataRow(rowHandleInt)["RepertoryId"]);
            if (repertoryIdInt == 0)
            {
                gridViewWRHead.SetRowCellValue(rowHandleInt, "RepertoryId", null);
                gridViewWRHead.SetRowCellValue(rowHandleInt, "RepertoryLocationId", null);
            }
            else
            {
                gridViewWRHead.SetRowCellValue(rowHandleInt, "RepertoryLocationId", null);
            }
        }

        /// <summary>
        /// 绑定货架数据源
        /// </summary>
        private void BindingShelfInfo(int rowHandleInt)
        {
            int repertoryLocationIdInt = DataTypeConvert.GetInt(gridViewWRHead.GetDataRow(rowHandleInt)["RepertoryLocationId"]);
            if (repertoryLocationIdInt == 0)
            {
                gridViewWRHead.SetRowCellValue(rowHandleInt, "RepertoryLocationId", null);
            }
            else
            {
                if (!SystemInfo.DisableShelfInfo)
                {
                    for (int i = 0; i < gridViewWRList.RowCount; i++)
                    {
                        gridViewWRList.SetRowCellValue(i, "ShelfId", null);
                    }
                }
            }
        }

        /// <summary>
        /// 子表单元格值变化进行的操作
        /// </summary>
        private void gridViewWRList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                switch (e.Column.FieldName)
                {
                    case "CodeFileName":
                        string tmpStr = DataTypeConvert.GetString(gridViewWRList.GetDataRow(e.RowHandle)["CodeFileName"]);
                        if (tmpStr == "")
                        {
                            gridViewWRList.SetRowCellValue(e.RowHandle, "CodeId", null);
                            gridViewWRList.SetRowCellValue(e.RowHandle, "CodeName", "");
                        }
                        else
                        {
                            DataTable temp = (DataTable)repSearchCodeFileName.DataSource;
                            DataRow[] drs = temp.Select(string.Format("CodeFileName='{0}'", tmpStr));
                            if (drs.Length > 0)
                            {
                                gridViewWRList.SetRowCellValue(e.RowHandle, "CodeId", DataTypeConvert.GetInt(drs[0]["AutoId"]));
                                gridViewWRList.SetRowCellValue(e.RowHandle, "CodeName", DataTypeConvert.GetString(drs[0]["CodeName"]));
                            }
                        }
                        break;
                    case "ProjectName":
                        string projectNameStr = DataTypeConvert.GetString(gridViewWRList.GetDataRow(e.RowHandle)["ProjectName"]);
                        string projectNoStr = "";
                        if (projectNameStr == "")
                        {
                            gridViewWRList.SetRowCellValue(e.RowHandle, "ProjectNo", "");
                            gridViewWRList.SetRowCellValue(e.RowHandle, "ProjectName", "");
                            gridViewWRList.SetRowCellValue(e.RowHandle, "StnNo", "");
                        }
                        else
                        {
                            DataTable temp = (DataTable)repSearchProjectNo.DataSource;
                            DataRow[] drs = temp.Select(string.Format("ProjectName='{0}'", projectNameStr));
                            if (drs.Length > 0)
                            {
                                gridViewWRList.SetRowCellValue(e.RowHandle, "ProjectNo", DataTypeConvert.GetString(drs[0]["ProjectNo"]));
                                projectNoStr = DataTypeConvert.GetString(drs[0]["ProjectNo"]);
                            }
                            gridViewWRList.SetRowCellValue(e.RowHandle, "StnNo", "");
                        }
                        BingStnListComboBox(projectNoStr);
                        break;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--子表单元格值变化进行的操作错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiZbdygzbhjxdczcw.Text, ex);
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

            gridView.ActiveFilterString = string.Format("{0} = {1}", fieldNameStr, DataTypeConvert.GetInt(gridViewWRHead.GetFocusedDataRow()[gridColumnNameStr]));
            gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            MethodInfo mi = gridView.GetType().GetMethod("ApplyColumnsFilterEx", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(gridView, null);
        }

        /// <summary>
        /// 设定当前行选择
        /// </summary>
        private void repCheckSelect_EditValueChanged(object sender, EventArgs e)
        {
            if (DataTypeConvert.GetBoolean(gridViewWRHead.GetFocusedDataRow()["Select"]))
                gridViewWRHead.GetFocusedDataRow()["Select"] = false;
            else
                gridViewWRHead.GetFocusedDataRow()["Select"] = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_WR.Tables[0].Select("select=1"), gridViewWRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);

            onlySelectColChangeRowState = true;
        }

        /// <summary>
        /// 鼠标操作明细行事件
        /// </summary>
        private void gridViewWRList_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (btnNew.Enabled)
                {
                    if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                    {
                        string formNameStr = "FrmProductionPlan";
                        if (!commonDAO.QueryUserFormPower(formNameStr))
                            return;

                        string planNoStr = DataTypeConvert.GetString(gridViewWRList.GetFocusedDataRow()["PlanNo"]);
                        if (planNoStr == "")
                            return;
                        FrmProductionPlan.queryPlanNo = planNoStr;
                        ViewHandler.ShowRightWindow(formNameStr);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--鼠标操作明细行事件错误。", ex);
            }
        }

        /// <summary>
        /// 检查是否有未填写字段
        /// </summary>
        private bool IsHaveBlankLine()
        {
            gridViewWRList.FocusedRowHandle = 0;
            for (int i = 0; i < gridViewWRList.DataRowCount; i++)
            {
                if (DataTypeConvert.GetString(gridViewWRList.GetDataRow(i)["CodeFileName"]) == "")
                {
                    gridViewWRList.Focus();
                    gridViewWRList.FocusedColumn = colCodeFileName;
                    gridViewWRList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewWRList.GetDataRow(i)["ShelfId"]) == "")
                {
                    gridViewWRList.Focus();
                    gridViewWRList.FocusedColumn = colShelfId;
                    gridViewWRList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewWRList.GetDataRow(i)["Qty"]) == "")
                {
                    gridViewWRList.Focus();
                    gridViewWRList.FocusedColumn = colQty;
                    gridViewWRList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewWRList.GetDataRow(i)["ProjectName"]) == "")
                {
                    gridViewWRList.Focus();
                    gridViewWRList.FocusedColumn = colProjectName;
                    gridViewWRList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewWRList.GetDataRow(i)["StnNo"]) == "")
                {
                    gridViewWRList.Focus();
                    gridViewWRList.FocusedColumn = colStnNo;
                    gridViewWRList.FocusedRowHandle = i;
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
            gridViewWRList.AddNewRow();
            FocusedListView(true, "CodeFileName", gridViewWRList.GetFocusedDataSourceRowIndex());
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
                btnSave.Tag = "保存";
                btnSave.Text = f.tsmiBc.Text;
                btnCancel.Enabled = true;
                btnDelete.Enabled = false;
                btnApprove.Enabled = false;
                btnCancelApprove.Enabled = false;
                btnPreview.Enabled = false;
            }
            else
            {
                btnNew.Enabled = true;
                btnSave.Tag = "修改";
                btnSave.Text = f.tsmiXg.Text;
                btnCancel.Enabled = false;
                //btnDelete.Enabled = true;
                //btnApprove.Enabled = true;
                //btnCancelApprove.Enabled = true;
                //btnPreview.Enabled = true;

                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_WR.Tables[0].Select("select=1"), gridViewWRHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
            }
            btnListAdd.Enabled = ret;

            if (SystemInfo.WarehouseReceiptIsAlterDate)
            {
                colWarehouseReceiptDate.OptionsColumn.AllowEdit = ret;
                colWarehouseReceiptDate.OptionsColumn.TabStop = ret;
            }

            colRepertoryId.OptionsColumn.AllowEdit = ret;
            colRepertoryLocationId.OptionsColumn.AllowEdit = ret;
            colWarehouseReceiptTypeNo.OptionsColumn.AllowEdit = ret;
            colApprovalType.OptionsColumn.AllowEdit = ret;
            colManufactureNo.OptionsColumn.AllowEdit = ret;
            colRemark1.OptionsColumn.AllowEdit = ret;

            //colCodeFileName.OptionsColumn.AllowEdit = ret;
            //colProjectName.OptionsColumn.AllowEdit = ret;
            colQty.OptionsColumn.AllowEdit = ret;
            colShelfId.OptionsColumn.AllowEdit = ret;
            colStnNo.OptionsColumn.AllowEdit = ret;
            colRemark.OptionsColumn.AllowEdit = ret;

            gridViewWRList_FocusedRowChanged(null, null);

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
            if (gridViewWRHead.GetFocusedDataRow() == null)
                return false;
            int reqState = DataTypeConvert.GetInt(gridViewWRHead.GetFocusedDataRow()["WarehouseState"]);
            switch (reqState)
            {
                case (int)CommonHandler.WarehouseState.已审批:
                    MessageHandler.ShowMessageBox(string.Format("出库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]), CommonHandler.WarehouseState.已审批));
                    return false;
                case (int)CommonHandler.WarehouseState.已结账:
                    MessageHandler.ShowMessageBox(string.Format("出库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]), CommonHandler.WarehouseState.已结账));
                    return false;
                case (int)CommonHandler.WarehouseState.审批中:
                    MessageHandler.ShowMessageBox(string.Format("出库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]), CommonHandler.WarehouseState.审批中));
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检测当前选中的出库单状态是否可以操作
        /// </summary>
        private bool CheckWarehouseState_Multi(bool checkNoApprover, bool checkApprover, bool checkSettle, bool checkApproverBetween)
        {
            for (int i = 0; i < gridViewWRHead.DataRowCount; i++)
            {
                if (DataTypeConvert.GetBoolean(gridViewWRHead.GetDataRow(i)["Select"]))
                {
                    int reqState = DataTypeConvert.GetInt(gridViewWRHead.GetDataRow(i)["WarehouseState"]);
                    switch (reqState)
                    {
                        case (int)CommonHandler.WarehouseState.待审批:
                            if (checkNoApprover)
                            {
                                MessageHandler.ShowMessageBox(string.Format("出库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewWRHead.GetDataRow(i)["WarehouseReceipt"]), CommonHandler.WarehouseState.待审批));
                                gridViewWRHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.WarehouseState.已审批:
                            if (checkApprover)
                            {
                                MessageHandler.ShowMessageBox(string.Format("出库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewWRHead.GetDataRow(i)["WarehouseReceipt"]), CommonHandler.WarehouseState.已审批));
                                gridViewWRHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.WarehouseState.已结账:
                            if (checkSettle)
                            {
                                MessageHandler.ShowMessageBox(string.Format("出库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewWRHead.GetDataRow(i)["WarehouseReceipt"]), CommonHandler.WarehouseState.已结账));
                                gridViewWRHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.WarehouseState.审批中:
                            if (checkApproverBetween)
                            {
                                MessageHandler.ShowMessageBox(string.Format("出库单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewWRHead.GetDataRow(i)["WarehouseReceipt"]), CommonHandler.WarehouseState.审批中));
                                gridViewWRHead.FocusedRowHandle = i;
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
            gridControlWRHead.Focus();
            ColumnView headView = (ColumnView)gridControlWRHead.FocusedView;
            headView.FocusedColumn = headView.Columns[colName];
            gridViewWRHead.FocusedRowHandle = headView.FocusedRowHandle;
        }

        /// <summary>
        /// 聚焦子表当前行的列
        /// </summary>
        private void FocusedListView(bool isFocusedControl, string colName, int lineNo)
        {
            if (isFocusedControl)
                gridControlWRList.Focus();
            ColumnView listView = (ColumnView)gridControlWRList.FocusedView;
            listView.FocusedColumn = listView.Columns[colName];
            gridViewWRList.FocusedRowHandle = lineNo;
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
            for (int i = 0; i < dataSet_WR.Tables[0].Rows.Count; i++)
            {
                dataSet_WR.Tables[0].Rows[i]["Select"] = false;
            }
            dataSet_WR.Tables[0].AcceptChanges();
            onlySelectColChangeRowState = false;
        }

        #endregion

        #region 左侧工单模块的相关事件和方法

        /// <summary>
        /// 确定行号
        /// </summary>
        private void treeProductionPlanList_CustomDrawNodeIndicator(object sender, CustomDrawNodeIndicatorEventArgs e)
        {
            ControlHandler.TreeList_CustomDrawNodeIndicator_RootNode(sender, e);
        }

        /// <summary>
        /// 查询工单事件
        /// </summary>
        private void btnOrderQuery_Click(object sender, EventArgs e)
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
                string planNoStr = textPlanNo.Text.Trim();
                string reqDateBeginStr = datePlanDateBegin.DateTime.ToString("yyyy-MM-dd");
                string reqDateEndStr = datePlanDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                string projectNoStr = searchLookUpProjectNo.Text != "全部" ? DataTypeConvert.GetString(searchLookUpProjectNo.EditValue) : "";

                dataSet_ProductionPlan.Tables[0].Clear();
                dataSet_ProductionPlan.Tables[1].Clear();
                wrDAO.QueryProductionPlan(dataSet_ProductionPlan.Tables[0], planNoStr, reqDateBeginStr, reqDateEndStr, projectNoStr, "");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询工单事件错误。", ex);
            }
        }

        /// <summary>
        /// 聚焦查询工单明细事件
        /// </summary>
        private void gridViewProductionPlan_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewProductionPlan.GetFocusedDataRow() != null && sender != null)
                {
                    dataSet_ProductionPlan.Tables[1].Clear();
                    wrDAO.QueryProductionPlanList(dataSet_ProductionPlan.Tables[1], DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]));
                    ClearAlreadyDragPPList();

                    treeProductionPlanList.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--聚焦查询工单明细事件错误。", ex);
            }
        }

        #region 拖出

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
                else if (e.Button == MouseButtons.Right)
                {
                    TreeListNode node = hitInfo.Node;

                    node.Checked = !node.Checked;
                    ControlHandler.SetCheckedChildNodes(node, node.CheckState);
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

                    Size dragSize = SystemInformation.DragSize;
                    Rectangle dragRect = new Rectangle(new Point(downHitInfo.MousePoint.X - dragSize.Width / 2,
                        downHitInfo.MousePoint.Y - dragSize.Height / 2), dragSize);

                    if (!dragRect.Contains(new Point(e.X, e.Y)))
                    {
                        List<TreeListNode> nodes = new List<TreeListNode>();
                        foreach (TreeListNode checkNode in treelist.GetAllCheckedNodes())
                        {
                            if (DataTypeConvert.GetDouble(checkNode["Overplus"]) <= 0)
                                continue;

                            nodes.Add(checkNode);
                        }
                        if (nodes.Count > 0)
                        {
                            treelist.DoDragDrop(nodes, DragDropEffects.Move);
                            downHitInfo = null;
                            DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                        }
                        else if (treelist.GetAllCheckedNodes().Count > 0 && nodes.Count == 0)
                        {
                            MessageHandler.ShowMessageBox("选择工单列表明细的剩余数量必须大于零。");
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

        #region 拖入

        /// <summary>
        /// 拖拽在GridControl上面
        /// </summary>
        private void gridControlWRHead_DragOver(object sender, DragEventArgs e)
        {
            TreeList treelist = sender as TreeList;
            if (treelist != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        /// <summary>
        /// 拖拽进入到GridControl控件
        /// </summary>
        private void gridControlWRHead_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 实现拖拽工单事件
        /// </summary>
        private void gridControlWRHead_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                List<TreeListNode> nodes = e.Data.GetData(typeof(List<TreeListNode>)) as List<TreeListNode>;
                if (nodes != null)
                {
                    PPToWR_DragOrder(sender, nodes);
                    ClearAlreadyDragPPList();

                    checkPPList.Checked = false;
                    treeProductionPlanList.UncheckAll();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--实现拖拽采购订单事件错误。", ex);
            }
        }

        /// <summary>
        /// 拖拽工单转成材料出库单
        /// </summary>
        private void PPToWR_DragOrder(object sender, List<TreeListNode> nodes)
        {
            if (!whDAO.IsNewWarehouseOrder())
                return;

            DataRow headRow = gridViewProductionPlan.GetFocusedDataRow();

            if (btnNew.Enabled)
            {
                ClearHeadGridAllSelect();
                gridViewWRHead.AddNewRow();
                FocusedHeadView("RepertoryId");

                gridViewWRHead.SetFocusedRowCellValue("WarehouseReceiptDate", BaseSQL.GetServerDateTime());
                gridViewWRHead.SetFocusedRowCellValue("ReqDep", SystemInfo.user.DepartmentNo);
                gridViewWRHead.SetFocusedRowCellValue("WarehouseReceiptTypeNo", wwDAO.Get_WarehouseType_TypeNo("BS_WarehouseReceiptType", "WarehouseReceiptTypeNo"));
                gridViewWRHead.SetFocusedRowCellValue("Creator", SystemInfo.user.AutoId);
                gridViewWRHead.SetFocusedRowCellValue("WarehouseState", 1);

                dataSet_WR.Tables[1].Clear();

                foreach (TreeListNode node in nodes)
                {
                    gridViewWRList.AddNewRow();
                    gridViewWRList.SetFocusedRowCellValue("WarehouseReceipt", gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]);
                    gridViewWRList.SetFocusedRowCellValue("PlanNo", node["PlanNo"]);
                    gridViewWRList.SetFocusedRowCellValue("CodeId", node["CodeId"]);
                    gridViewWRList.SetFocusedRowCellValue("CodeFileName", node["CodeFileName"]);
                    gridViewWRList.SetFocusedRowCellValue("CodeName", node["CodeName"]);
                    gridViewWRList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(node["Overplus"]));
                    gridViewWRList.SetFocusedRowCellValue("ProjectNo", headRow["ProjectNo"]);
                    gridViewWRList.SetFocusedRowCellValue("ProjectName", headRow["ProjectName"]);
                    gridViewWRList.SetFocusedRowCellValue("ProductionPlanListId", node["AutoId"]);
                    //gridViewWRList.SetFocusedRowCellValue("OrderHeadNo", headRow["OrderHeadNo"]);
                }
                //FocusedListView(false, "Qty", gridViewWRList.GetFocusedDataSourceRowIndex());
                FocusedListView(false, "Qty", 0);
                gridViewWRList.RefreshData();

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewWRHead.DataRowCount;
            }
            else
            {
                if (dataSet_WR.Tables[1].Rows.Count > 0)
                {
                    string projectNameStr = "";
                    if (dataSet_WR.Tables[1].Rows[0].RowState == DataRowState.Deleted)
                    {
                        projectNameStr = DataTypeConvert.GetString(dataSet_WR.Tables[1].Rows[0]["ProjectName", DataRowVersion.Original]);
                    }
                    else
                    {
                        projectNameStr = DataTypeConvert.GetString(dataSet_WR.Tables[1].Rows[0]["ProjectName"]);
                    }

                    if (projectNameStr != DataTypeConvert.GetString(headRow["ProjectName"]))
                    {
                        MessageHandler.ShowMessageBox("一张出库单只允许相同的项目号进行登记。");
                        return;
                    }
                }

                foreach (TreeListNode node in nodes)
                {
                    if (dataSet_WR.Tables[1].Select(string.Format("ProductionPlanListId={0}", DataTypeConvert.GetString(node["AutoId"]))).Length > 0)
                        continue;
                    gridViewWRList.AddNewRow();
                    gridViewWRList.SetFocusedRowCellValue("WarehouseReceipt", gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]);
                    gridViewWRList.SetFocusedRowCellValue("PlanNo", node["PlanNo"]);
                    gridViewWRList.SetFocusedRowCellValue("CodeId", node["CodeId"]);
                    gridViewWRList.SetFocusedRowCellValue("CodeFileName", node["CodeFileName"]);
                    gridViewWRList.SetFocusedRowCellValue("CodeName", node["CodeName"]);
                    gridViewWRList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(node["Overplus"]));
                    gridViewWRList.SetFocusedRowCellValue("ProjectNo", headRow["ProjectNo"]);
                    gridViewWRList.SetFocusedRowCellValue("ProjectName", headRow["ProjectName"]);
                    gridViewWRList.SetFocusedRowCellValue("ProductionPlanListId", node["AutoId"]);
                }

                gridViewWRList.FocusedRowHandle = gridViewWRList.DataRowCount;
                FocusedListView(false, "Qty", gridViewWRList.GetFocusedDataSourceRowIndex());
                gridViewWRList.RefreshData();
            }
        }

        #endregion

        /// <summary>
        /// 选择工单明细
        /// </summary>
        private void checkPPList_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPPList.Checked)
            {
                treeProductionPlanList.CheckAll();
            }
            else
            {
                treeProductionPlanList.UncheckAll();
            }
        }

        /// <summary>
        /// 清空已经拖拽的采购订单明细
        /// </summary>
        private void ClearAlreadyDragPPList()
        {
            for (int i = dataSet_ProductionPlan.Tables[1].Rows.Count - 1; i >= 0; i--)
            {
                if (dataSet_WR.Tables[1].Select(string.Format("ProductionPlanListId={0}", DataTypeConvert.GetString(dataSet_ProductionPlan.Tables[1].Rows[i]["AutoId"]))).Length > 0)
                    dataSet_ProductionPlan.Tables[1].Rows.RemoveAt(i);
            }
        }

        #endregion
        
    }
}
