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
    public partial class FrmInventoryAdjustments_Drag : DockContent
    {
        #region 私有变量

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmInventoryAdjustmentsDAO iaDAO = new FrmInventoryAdjustmentsDAO();
        FrmWarehouseNowInfoDAO nowInfoDAO = new FrmWarehouseNowInfoDAO();
        FrmWarehouseCommonDAO whDAO = new FrmWarehouseCommonDAO();

        /// <summary>
        /// 主表聚焦的行号
        /// </summary>
        int headFocusedLineNo = 0;

        /// <summary>
        /// 查询的库存调整单号
        /// </summary>
        public static string queryIAHeadNo = "";

        /// <summary>
        /// 查询的明细AutoId
        /// </summary>
        public static int queryListAutoId = 0;

        /// <summary>
        /// 只有选择列改变行状态的时候
        /// </summary>
        bool onlySelectColChangeRowState = false;

        /// <summary>
        /// 拖动区域的信息
        /// </summary>
        GridHitInfo GriddownHitInfo = null;

        /// <summary>
        /// 控件锁
        /// </summary>
        bool isLockControl = false;

        static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();

        #endregion

        #region 构造方法

        public FrmInventoryAdjustments_Drag()
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
        private void FrmInventoryAdjustments_Load(object sender, EventArgs e)
        {
            try
            {
                //ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd, checkAll });
                ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd });
                ControlCommonInit ctlInit = new ControlCommonInit();

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateIADateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateIADateEnd.DateTime = nowDate.Date;

                DataTable repertoryTable_f = commonDAO.QueryRepertoryInfo(false);
                DataTable repertoryTable_t = commonDAO.QueryRepertoryInfo(true);

                lookUpAdjRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpAdjRepertoryId.ItemIndex = 0;
                //SearchLocationId.Properties.DataSource = commonDAO.QueryRepertoryLocationInfo(true);
                //SearchLocationId.EditValue = 0;
                ctlInit.SearchLookUpEdit_RepertoryLocationInfo(SearchLocationId, true);
                SearchLocationId.EditValue = 0;
                lookUpReqDep.Properties.DataSource = commonDAO.QueryDepartment(true);
                lookUpReqDep.ItemIndex = 0;
                //searchProjectNo.Properties.DataSource = projectListTable_t;
                //searchProjectNo.Text = "全部";
                ctlInit.SearchLookUpEdit_ProjectList(searchProjectNo, true);
                searchProjectNo.Text = "全部";
                ctlInit.ComboBoxEdit_WarehouseState(comboBoxWarehouseState);
                comboBoxWarehouseState.SelectedIndex = 0;
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpApprover);
                searchLookUpApprover.EditValue = null;

                repLookUpInRepertoryId.DataSource = repertoryTable_f;
                //repSearchLocationId.DataSource = locationTable_f;
                ctlInit.RepositoryItemSearchLookUpEdit_RepertoryLocationInfo(repSearchLocationId);
                repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);
                //repSearchProjectNo.DataSource = commonDAO.QueryProjectList(false);
                ctlInit.RepositoryItemSearchLookUpEdit_ProjectList(repSearchProjectNo);
                repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                repLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;
                //repSearchCodeFileName.DataSource = commonDAO.QueryPartsCode(false);
                ctlInit.RepositoryItemSearchLookUpEdit_PartsCode(repSearchCodeFileName, "CodeFileName", "CodeFileName");
                //repSearchShelfId.DataSource = shelfInfoTable_f;
                ctlInit.RepositoryItemSearchLookUpEdit_ShelfInfo(repSearchShelfId);

                lookUpRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpRepertoryId.ItemIndex = 0;
                //searchLookUpProjectNo.Properties.DataSource = projectListTable_t;
                //searchLookUpProjectNo.Text = "全部";
                ctlInit.SearchLookUpEdit_ProjectList(searchLookUpProjectNo, true);
                searchLookUpProjectNo.Text = "全部";
                //searchLookUpCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(true);
                //searchLookUpCodeFileName.EditValue = 0;
                ctlInit.SearchLookUpEdit_PartsCode(searchLookUpCodeFileName, true);
                searchLookUpCodeFileName.EditValue = 0;

                repLookUpRepertoryId.DataSource = repertoryTable_f;
                repLookUpLocationId.DataSource = repSearchLocationId.DataSource;
                repLookUpShelfId.DataSource = repSearchShelfId.DataSource;

                if (textCommon.Text == "")
                {
                    iaDAO.QueryInventoryAdjustmentsHead(dataSet_IA.Tables[0], "", "", 0, 0, "", "", 0, 0, -1, "", true);
                    iaDAO.QueryInventoryAdjustmentsList(dataSet_IA.Tables[1], "", true);
                }

                if (SystemInfo.DisableProjectNo)
                {
                    btnWNowInfoQuery.Location = new Point(245, 43);
                    pnlLeftTop.Height = 80;

                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    colProjectName.Visible = false;
                    labAdjProjectNo.Visible = false;
                    searchProjectNo.Visible = false;
                    colProjectNo.Visible = false;
                }

                if (SystemInfo.DisableShelfInfo)
                {
                    colShelfId.Visible = false;
                    colAdjShelfId.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiCtjzsjcw.Text , ex);
            }
        }

        /// <summary>
        /// 窗体激活事件
        /// </summary>
        private void FrmInventoryAdjustments_Activated(object sender, EventArgs e)
        {
            try
            {
                if (queryIAHeadNo != "")
                {
                    textCommon.Text = queryIAHeadNo;
                    queryIAHeadNo = "";
                    lookUpAdjRepertoryId.ItemIndex = 0;
                    SearchLocationId.EditValue = 0;
                    lookUpReqDep.ItemIndex = 0;
                    searchLookUpCreator.EditValue = 0;
                    searchLookUpApprover.EditValue = null;
                    searchProjectNo.Text = "全部";

                    dataSet_IA.Tables[0].Clear();
                    headFocusedLineNo = 0;
                    iaDAO.QueryInventoryAdjustmentsHead(dataSet_IA.Tables[0], "", "", 0, 0,"", "", 0, 0, -1, textCommon.Text, false);
                    SetButtonAndColumnState(false);

                    if (dataSet_IA.Tables[0].Rows.Count > 0)
                    {
                        dateIADateBegin.DateTime = DataTypeConvert.GetDateTime(dataSet_IA.Tables[0].Rows[0]["InventoryAdjustmentsDate"]).Date;
                        dateIADateEnd.DateTime = dateIADateBegin.DateTime.AddDays(7);
                    }
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体激活事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiCtjhsjcw.Text , ex);
            }
        }

        /// <summary>
        /// 窗体显示事件
        /// </summary>
        private void FrmInventoryAdjustments_Shown(object sender, EventArgs e)
        {
            pnlMiddle.Height = (this.Height - pnltop.Height) / 2;
            dockPnlLeft.Width = SystemInfo.DragForm_LeftDock_Width;
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

                if (dateIADateBegin.EditValue == null || dateIADateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox(tsmiTzrqbnwkcx.Text);// ("调整日期不能为空，请设置后重新进行查询。");
                    if (dateIADateBegin.EditValue == null)
                        dateIADateBegin.Focus();
                    else
                        dateIADateEnd.Focus();
                    return;
                }
                string orderDateBeginStr = dateIADateBegin.DateTime.ToString("yyyy-MM-dd");
                string orderDateEndStr = dateIADateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                int repertoryIdInt = lookUpRepertoryId.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpRepertoryId.EditValue) : 0;
                int locationIdInt = DataTypeConvert.GetInt(SearchLocationId.EditValue);
                string projectNoStr = searchProjectNo.Text != "全部" ? DataTypeConvert.GetString(searchProjectNo.EditValue) : "";
                string reqDepStr = lookUpReqDep.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpReqDep.EditValue) : "";

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

                dataSet_IA.Tables[0].Clear();
                dataSet_IA.Tables[1].Clear();
                headFocusedLineNo = 0;
                iaDAO.QueryInventoryAdjustmentsHead(dataSet_IA.Tables[0], orderDateBeginStr, orderDateEndStr, repertoryIdInt, locationIdInt, projectNoStr, reqDepStr, warehouseStateInt, creatorInt, approverInt, commonStr, false);

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
        private void gridViewIAHead_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewIAHead.GetFocusedDataRow() != null)
                {
                    if (onlySelectColChangeRowState)
                    {
                        dataSet_IA.Tables[0].AcceptChanges();
                        onlySelectColChangeRowState = false;

                        if (btnNew.Enabled)
                            ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_IA.Tables[0].Select("select=1"), gridViewIAHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
                    }
                    else
                    {
                        if (headFocusedLineNo < gridViewIAHead.DataRowCount && gridViewIAHead.FocusedRowHandle != headFocusedLineNo && gridViewIAHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                        {
                            MessageHandler.ShowMessageBox(tsmiDqkctzdyjxghh.Text );// ("当前库存调整单已经修改，请保存后再进行换行。");
                            gridViewIAHead.FocusedRowHandle = headFocusedLineNo;
                        }
                        else if (headFocusedLineNo == gridViewIAHead.DataRowCount)
                        {

                        }
                        else
                        {
                            if (gridViewIAHead.FocusedRowHandle != headFocusedLineNo && gridViewIAHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                            else if (gridViewIAHead.GetDataRow(headFocusedLineNo).RowState == DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                        }
                    }

                    if (DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsNo"]) != "")
                    {
                        dataSet_IA.Tables[1].Clear();
                        iaDAO.QueryInventoryAdjustmentsList(dataSet_IA.Tables[1], DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsNo"]), false);
                        //if (queryListAutoId > 0)
                        //{
                        //    for (int i = 0; i < gridViewIAList.DataRowCount; i++)
                        //    {
                        //        if (DataTypeConvert.GetInt(gridViewIAList.GetDataRow(i)["AutoId"]) == queryListAutoId)
                        //        {
                        //            gridViewIAList.FocusedRowHandle = i;
                        //            queryListAutoId = 0;
                        //            break;
                        //        }
                        //    }
                        //}
                    }

                    if (gridViewIAHead.FocusedRowHandle >= 0)
                    {
                        headFocusedLineNo = gridViewIAHead.FocusedRowHandle;
                    }
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--主表聚焦行改变事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiZbjjhgb.Text , ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewIAHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        private void gridViewIAHead_KeyDown(object sender, KeyEventArgs e)
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
        private void gridViewIAHead_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

                //gridViewPrReqHead.PostEditor();
                gridViewIAHead.AddNewRow();
                FocusedHeadView("RepertoryId");

                dataSet_IA.Tables[1].Clear();
                gridViewIAList.AddNewRow();
                FocusedListView(false, "CodeFileName", gridViewIAList.GetFocusedDataSourceRowIndex());
                gridViewIAList.RefreshData();

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewIAHead.DataRowCount;
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--新增按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiXzansj.Text , ex);
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

                if (gridViewIAHead.GetFocusedDataRow() == null)
                    return;

                if (!CheckWarehouseState())
                    return;

                if (btnSave.Tag.ToString() != "保存")
                {
                    if (!whDAO.IsAlterWarehouseOrder(DataTypeConvert.GetDateTime(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsDate"])))
                        return;

                    ClearHeadGridAllSelect();

                    SetButtonAndColumnState(true);
                    FocusedHeadView("RepertoryId");
                }
                else
                {
                    DataRow headRow = gridViewIAHead.GetFocusedDataRow();
                    int repertoryIdInt = DataTypeConvert.GetInt(headRow["RepertoryId"]);
                    string projectNoStr = DataTypeConvert.GetString(headRow["ProjectNo"]);
                    if (repertoryIdInt == 0)
                    {
                        MessageHandler.ShowMessageBox(tsmiCkbnwkbc.Text );// ("仓库不能为空，请填写后再进行保存。");
                        FocusedHeadView("RepertoryId");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["LocationId"]) == "")
                    {
                        MessageHandler.ShowMessageBox("仓位不能为空，请填写后再进行保存。");
                        FocusedHeadView("LocationId");
                        return;
                    }
                    if (projectNoStr == "")
                    {
                        MessageHandler.ShowMessageBox(tsmiXmhbnwkbc.Text );// ("项目号不能为空，请填写后再进行保存。");
                        FocusedHeadView("ProjectNo");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["ReqDep"]) == "")
                    {
                        MessageHandler.ShowMessageBox(tsmiSqbmbnwkbc.Text);// ("申请部门不能为空，请填写后再进行保存。");
                        FocusedHeadView("ReqDep");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["ApprovalType"]) == "")
                    {
                        MessageHandler.ShowMessageBox("审批类型不能为空，请填写后再进行保存。");
                        FocusedHeadView("ApprovalType");
                        return;
                    }

                    for (int i = gridViewIAList.DataRowCount - 1; i >= 0; i--)
                    {
                        DataRow listRow = gridViewIAList.GetDataRow(i);
                        if (DataTypeConvert.GetString(listRow["CodeFileName"]) == "")
                        {
                            gridViewIAList.DeleteRow(i);
                            continue;
                        }
                        if (DataTypeConvert.GetDouble(listRow["Qty"]) == 0)
                        {
                            MessageHandler.ShowMessageBox("调整数量不能为空或者零，请填写后再进行保存。");
                            FocusedListView(true, "Qty", i);
                            return;
                        }
                        if (DataTypeConvert.GetString(listRow["ShelfId"]) == "")
                        {
                            MessageHandler.ShowMessageBox(tsmiTzhjhbnwkbc.Text);// ("调整货架号不能为空，请填写后再进行保存。");
                            FocusedListView(true, "ShelfId", i);
                            return;
                        }
                    }

                    if (gridViewIAList.DataRowCount == 0)
                    {
                        MessageHandler.ShowMessageBox("库存调整单明细不能为空，请填写后再进行保存。");
                        return;
                    }

                    int ret = iaDAO.SaveInventoryAdjustments(gridViewIAHead.GetFocusedDataRow(), dataSet_IA.Tables[1]);
                    switch (ret)
                    {
                        case -1:
                            btnQuery_Click(null, null);
                            break;
                        case 1:
                            dataSet_IA.Tables[1].Clear();
                            iaDAO.QueryInventoryAdjustmentsList(dataSet_IA.Tables[1], DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsNo"]), false);
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
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiBcansj.Text , ex);
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

                if (gridViewIAHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                {
                    if (DataTypeConvert.GetString(gridViewIAHead.GetDataRow(headFocusedLineNo)["InventoryAdjustmentsNo"]) == "")
                    {
                        gridViewIAHead.DeleteRow(headFocusedLineNo);
                    }
                    else
                    {
                        gridViewIAHead.GetFocusedDataRow().RejectChanges();
                    }
                }

                SetButtonAndColumnState(false);

                dataSet_IA.Tables[1].Clear();
                if (gridViewIAHead.GetFocusedDataRow() != null)
                    iaDAO.QueryInventoryAdjustmentsList(dataSet_IA.Tables[1], DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsNo"]), false);

                //gridViewPrReqHead_FocusedRowChanged(sender, null);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--取消按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiQxansj.Text , ex);
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

                int count = dataSet_IA.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox(f.tsmiQzyczdjlq.Text );// ("请在要操作的记录前面选中。");
                    return;
                }

                if (!CheckWarehouseState_Multi(false, true, true, true))
                    return;

                //if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要删除当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                if (MessageHandler.ShowMessageBox_YesNo(string.Format(f.tsmiQdyscdqxzd.Text +"{0}"+f.tsmiTjlm.Text, count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!iaDAO.DeleteInventoryAdjustments_Multi(dataSet_IA.Tables[0]))
                {

                }

                btnQuery_Click(null, null);
                ClearHeadGridAllSelect();
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--删除按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiScansj.Text , ex);
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

                int count = dataSet_IA.Tables[0].Select("select=1").Length;
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
                    string inventoryAdjustmentsNoStr = DataTypeConvert.GetString(dataSet_IA.Tables[0].Select("select=1")[0]["InventoryAdjustmentsNo"]);
                    FrmOrderApproval frmOrder = new FrmOrderApproval(inventoryAdjustmentsNoStr);
                    if (frmOrder.ShowDialog() == DialogResult.OK)
                    {
                        btnQuery_Click(null, null);
                        for (int i = 0; i < gridViewIAHead.DataRowCount; i++)
                        {
                            if (DataTypeConvert.GetString(gridViewIAHead.GetDataRow(i)["InventoryAdjustmentsNo"]) == inventoryAdjustmentsNoStr)
                            {
                                gridViewIAHead.FocusedRowHandle = i;
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
                    if (!iaDAO.IAApprovalInfo_Multi(dataSet_IA.Tables[0], ref successCountInt))
                        btnQuery_Click(null, null);
                    else
                    {
                        MessageHandler.ShowMessageBox(string.Format("成功审批了{0}条记录。", successCountInt));
                    }
                }
                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_IA.Tables[0].Select("select=1"), gridViewIAHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
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

                int count = dataSet_IA.Tables[0].Select("select=1").Length;
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

                if (!iaDAO.CancalIAApprovalInfo_Multi(dataSet_IA.Tables[0]))
                    btnQuery_Click(null, null);
                else
                {
                    MessageHandler.ShowMessageBox(string.Format("成功取消审批了{0}条记录。", count));
                }
                ClearHeadGridAllSelect();
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_IA.Tables[0].Select("select=1"), gridViewIAHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
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

                string iaHeadNoStr = "";
                DataRow dr = null;
                DataRow[] drs = dataSet_IA.Tables[0].Select("select=1");
                if (drs.Length > 1)
                {
                    MessageHandler.ShowMessageBox("只能选中一条记录进行打印预览，请重新选择。");
                    return;
                }
                else if (drs.Length == 0)
                {
                    if (gridViewIAHead.GetFocusedDataRow() != null)
                    {
                        iaHeadNoStr = DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsNo"]);
                        dr = gridViewIAHead.GetFocusedDataRow();
                    }
                }
                else
                {
                    iaHeadNoStr = DataTypeConvert.GetString(drs[0]["InventoryAdjustmentsNo"]);
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

                //string iaHeadNoStr = "";
                //if (gridViewIAHead.GetFocusedDataRow() != null)
                //    iaHeadNoStr = DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsNo"]);

                iaDAO.PrintHandle(iaHeadNoStr, 1);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--预览按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiYlansjcw.Text , ex);
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
            foreach (DataRow dr in dataSet_IA.Tables[0].Rows)
            {
                dr["Select"] = value;
            }
            onlySelectColChangeRowState = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_IA.Tables[0].Select("select=1"), gridViewIAHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
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
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiZbxzyhsjcw.Text , ex);
            }
        }

        /// <summary>
        /// 主表设定默认值
        /// </summary>
        private void gridViewIAHead_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                gridViewIAHead.SetFocusedRowCellValue("InventoryAdjustmentsDate", nowDate);
                gridViewIAHead.SetFocusedRowCellValue("ReqDep", SystemInfo.user.DepartmentNo);
                gridViewIAHead.SetFocusedRowCellValue("WarehouseState", 1);
                gridViewIAHead.SetFocusedRowCellValue("Creator", SystemInfo.user.AutoId);

                if (SystemInfo.DisableProjectNo)
                {
                    gridViewIAHead.SetFocusedRowCellValue("ProjectNo", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--主表设定默认值错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiZbsdmrzcw.Text , ex);
            }
        }

        /// <summary>
        /// 子表设定默认值
        /// </summary>
        private void gridViewIAList_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridViewIAList.SetFocusedRowCellValue("InventoryAdjustmentsNo", DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsNo"]));

                if (SystemInfo.DisableShelfInfo)
                {
                    gridViewIAList.SetFocusedRowCellValue("ShelfId", SystemInfo.DisableShelfInfo_Default_ShelfId);
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--子表设定默认值错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiZbsdmrzcw.Text , ex);
            }
        }

        /// <summary>
        /// 子表按键事件
        /// </summary>
        private void gridViewIAList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!colRemark.OptionsColumn.AllowEdit)
                        return;

                    if (gridViewIAList.GetFocusedDataSourceRowIndex() >= gridViewIAList.DataRowCount - 1 && gridViewIAList.FocusedColumn.Name == "colRemark")
                    {
                        ListNewRow();
                    }
                    else if (gridViewIAList.FocusedColumn.Name == "colRemark")
                    {
                        gridViewIAList.FocusedRowHandle = gridViewIAList.FocusedRowHandle + 1;
                        FocusedListView(true, "CodeFileName", gridViewIAList.GetFocusedDataSourceRowIndex());
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
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiZbajsjcw.Text , ex);
            }
        }

        /// <summary>
        /// 删除子表中的一行
        /// </summary>
        private void repbtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridViewIAList.GetFocusedDataRow().RowState != DataRowState.Added)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的明细记录吗？") != DialogResult.Yes)
                    {
                        return;
                    }
                }
                //int prListAutoIdInt = 0;
                //if (gridViewIMList.GetFocusedDataRow() != null)
                //    prListAutoIdInt = DataTypeConvert.GetInt(gridViewIMList.GetFocusedDataRow()["PrListAutoId"]);
                gridViewIAList.DeleteRow(gridViewIAList.FocusedRowHandle);
                //if (prListAutoIdInt > 0)
                //    gridViewPrReqHead_FocusedRowChanged(sender, null);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--删除子表中的一行错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiSczbzyhcw.Text , ex);
            }
        }

        /// <summary>
        /// 主表单元格值变化进行的操作
        /// </summary>
        private void gridViewIAHead_CellValueChanged(object sender, CellValueChangedEventArgs e)
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
                    case "LocationId":
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
            int repertoryIdInt = DataTypeConvert.GetInt(gridViewIAHead.GetDataRow(rowHandleInt)["RepertoryId"]);
            if (repertoryIdInt == 0)
            {
                gridViewIAHead.SetRowCellValue(rowHandleInt, "RepertoryId", null);
                gridViewIAHead.SetRowCellValue(rowHandleInt, "LocationId", null);
            }
            else
            {
                gridViewIAHead.SetRowCellValue(rowHandleInt, "LocationId", null);
            }
        }

        /// <summary>
        /// 绑定货架数据源
        /// </summary>
        private void BindingShelfInfo(int rowHandleInt)
        {
            int repertoryLocationIdInt = DataTypeConvert.GetInt(gridViewIAHead.GetDataRow(rowHandleInt)["LocationId"]);
            if (repertoryLocationIdInt == 0)
            {
                gridViewIAHead.SetRowCellValue(rowHandleInt, "LocationId", null);
            }
            else
            {
                if (!SystemInfo.DisableShelfInfo)
                {
                    for (int i = 0; i < gridViewIAList.RowCount; i++)
                    {
                        gridViewIAList.SetRowCellValue(i, "ShelfId", null);
                    }
                }
            }
        }

        /// <summary>
        /// 子表单元格值变化进行的操作
        /// </summary>
        private void gridViewIAList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string tmpStr = "";
                switch (e.Column.FieldName)
                {
                    case "CodeFileName":
                        tmpStr = DataTypeConvert.GetString(gridViewIAList.GetDataRow(e.RowHandle)["CodeFileName"]);
                        if (tmpStr == "")
                        {
                            gridViewIAList.SetRowCellValue(e.RowHandle, "CodeId", null);
                            gridViewIAList.SetRowCellValue(e.RowHandle, "CodeName", "");
                        }
                        else
                        {
                            DataTable temp = (DataTable)repSearchCodeFileName.DataSource;
                            DataRow[] drs = temp.Select(string.Format("CodeFileName='{0}'", tmpStr));
                            if (drs.Length > 0)
                            {
                                gridViewIAList.SetRowCellValue(e.RowHandle, "CodeId", DataTypeConvert.GetInt(drs[0]["AutoId"]));
                                gridViewIAList.SetRowCellValue(e.RowHandle, "CodeName", DataTypeConvert.GetString(drs[0]["CodeName"]));
                            }
                        }
                        break; 
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--子表单元格值变化进行的操作错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiZbdygzbhjxdczcw.Text , ex);
            }
        }

        /// <summary>
        /// 仓位弹出下拉列表设定过滤
        /// </summary>
        private void repSearchLocationId_Popup(object sender, EventArgs e)
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
                FilterLookup(sender, "RepertoryLocationId", "LocationId");
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

            gridView.ActiveFilterString = string.Format("{0} = {1}", fieldNameStr, DataTypeConvert.GetInt(gridViewIAHead.GetFocusedDataRow()[gridColumnNameStr]));
            gridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;

            MethodInfo mi = gridView.GetType().GetMethod("ApplyColumnsFilterEx", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(gridView, null);
        }

        /// <summary>
        /// 设定当前行选择
        /// </summary>
        private void repCheckSelect_EditValueChanged(object sender, EventArgs e)
        {
            if (DataTypeConvert.GetBoolean(gridViewIAHead.GetFocusedDataRow()["Select"]))
                gridViewIAHead.GetFocusedDataRow()["Select"] = false;
            else
                gridViewIAHead.GetFocusedDataRow()["Select"] = true;

            if (btnNew.Enabled)
                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_IA.Tables[0].Select("select=1"), gridViewIAHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);

            onlySelectColChangeRowState = true;
        }

        /// <summary>
        /// 检查是否有未填写字段
        /// </summary>
        private bool IsHaveBlankLine()
        {
            gridViewIAList.FocusedRowHandle = 0;
            for (int i = 0; i < gridViewIAList.DataRowCount; i++)
            {
                if (DataTypeConvert.GetString(gridViewIAList.GetDataRow(i)["CodeFileName"]) == "")
                {
                    gridViewIAList.Focus();
                    gridViewIAList.FocusedColumn = colCodeFileName;
                    gridViewIAList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewIAList.GetDataRow(i)["Qty"]) == "")
                {
                    gridViewIAList.Focus();
                    gridViewIAList.FocusedColumn = colQty;
                    gridViewIAList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewIAList.GetDataRow(i)["ShelfId"]) == "")
                {
                    gridViewIAList.Focus();
                    gridViewIAList.FocusedColumn = colAdjShelfId;
                    gridViewIAList.FocusedRowHandle = i;
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
            gridViewIAList.AddNewRow();
            FocusedListView(true, "CodeFileName", gridViewIAList.GetFocusedDataSourceRowIndex());
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
                btnSave.Tag = "保存";
                btnSave.Text = f.tsmiBc.Text ;
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
                btnSave.Text = f.tsmiXg.Text ;
                btnCancel.Enabled = false;
                //btnDelete.Enabled = true;
                //btnApprove.Enabled = true;
                //btnCancelApprove.Enabled = true;
                //btnPreview.Enabled = true;

                ControlHandler.SetButtonBar_EnabledState_Warehouse(dataSet_IA.Tables[0].Select("select=1"), gridViewIAHead.GetFocusedDataRow(), "WarehouseState", btnSave, btnDelete, btnApprove, btnCancelApprove, btnPreview);
            }
            btnListAdd.Enabled = ret;

            colRepertoryId.OptionsColumn.AllowEdit = ret;
            colLocationId.OptionsColumn.AllowEdit = ret;
            colApprovalType.OptionsColumn.AllowEdit = ret;
            colProjectNo.OptionsColumn.AllowEdit = ret;
            colPRemark.OptionsColumn.AllowEdit = ret;

            colCodeFileName.OptionsColumn.AllowEdit = ret;
            colQty.OptionsColumn.AllowEdit = ret;
            colAdjShelfId.OptionsColumn.AllowEdit = ret;
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
            if (gridViewIAHead.GetFocusedDataRow() == null)
                return false;
            int reqState = DataTypeConvert.GetInt(gridViewIAHead.GetFocusedDataRow()["WarehouseState"]);
            switch (reqState)
            {
                case (int)CommonHandler.WarehouseState.已审批:
                    MessageHandler.ShowMessageBox(string.Format("库存调整单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsNo"]), CommonHandler.WarehouseState.已审批));
                    return false;
                //case (int)CommonHandler.WarehouseState.已结账:
                //    MessageHandler.ShowMessageBox(string.Format("库存调整单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsNo"]),CommonHandler.WarehouseState.已结账));
                //    return false;
                case (int)CommonHandler.WarehouseState.审批中:
                    MessageHandler.ShowMessageBox(string.Format("库存调整单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsNo"]), CommonHandler.WarehouseState.审批中));
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检测当前选中的出库单状态是否可以操作
        /// </summary>
        private bool CheckWarehouseState_Multi(bool checkNoApprover, bool checkApprover, bool checkSettle, bool checkApproverBetween)
        {
            for (int i = 0; i < gridViewIAHead.DataRowCount; i++)
            {
                if (DataTypeConvert.GetBoolean(gridViewIAHead.GetDataRow(i)["Select"]))
                {
                    int reqState = DataTypeConvert.GetInt(gridViewIAHead.GetDataRow(i)["WarehouseState"]);
                    switch (reqState)
                    {
                        case (int)CommonHandler.WarehouseState.待审批:
                            if (checkNoApprover)
                            {
                                MessageHandler.ShowMessageBox(string.Format("库存调整单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewIAHead.GetDataRow(i)["InventoryAdjustmentsNo"]), CommonHandler.WarehouseState.待审批));
                                gridViewIAHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case (int)CommonHandler.WarehouseState.已审批:
                            if (checkApprover)
                            {
                                MessageHandler.ShowMessageBox(string.Format("库存调整单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewIAHead.GetDataRow(i)["InventoryAdjustmentsNo"]), CommonHandler.WarehouseState.已审批));
                                gridViewIAHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        //case (int)CommonHandler.WarehouseState.已结账:
                        //    if (checkSettle)
                        //    {
                        //        MessageHandler.ShowMessageBox(string.Format("库存调整单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewIAHead.GetDataRow(i)["InventoryAdjustmentsNo"]),CommonHandler.WarehouseState.已结账));
                        //        gridViewIAHead.FocusedRowHandle = i;
                        //        return false;
                        //    }
                        //    break;
                        case (int)CommonHandler.WarehouseState.审批中:
                            if (checkApproverBetween)
                            {
                                MessageHandler.ShowMessageBox(string.Format("库存调整单[{0}]{1}，不可以操作。", DataTypeConvert.GetString(gridViewIAHead.GetDataRow(i)["InventoryAdjustmentsNo"]), CommonHandler.WarehouseState.审批中));
                                gridViewIAHead.FocusedRowHandle = i;
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
            gridControlIAHead.Focus();
            ColumnView headView = (ColumnView)gridControlIAHead.FocusedView;
            headView.FocusedColumn = headView.Columns[colName];
            gridViewIAHead.FocusedRowHandle = headView.FocusedRowHandle;
        }

        /// <summary>
        /// 聚焦子表当前行的列
        /// </summary>
        private void FocusedListView(bool isFocusedControl, string colName, int lineNo)
        {
            if (isFocusedControl)
                gridControlIAList.Focus();
            ColumnView listView = (ColumnView)gridControlIAList.FocusedView;
            listView.FocusedColumn = listView.Columns[colName];
            gridViewIAList.FocusedRowHandle = lineNo;
        }

        /// <summary>
        /// 清楚当前的所有选择
        /// </summary>
        private void ClearHeadGridAllSelect()
        {
            checkAll.Checked = false;
            for (int i = 0; i < dataSet_IA.Tables[0].Rows.Count; i++)
            {
                dataSet_IA.Tables[0].Rows[i]["Select"] = false;
            }
            dataSet_IA.Tables[0].AcceptChanges();
            onlySelectColChangeRowState = false;
        }

        #endregion

        #region 左侧当前库存模块的相关事件和方法

        /// <summary>
        /// 查询当前库存事件
        /// </summary>
        private void btnWNowInfoQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int repertoryIdInt = lookUpRepertoryId.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpRepertoryId.EditValue) : 0;
                string projectNameStr = searchLookUpProjectNo.Text != "全部" ? searchLookUpProjectNo.Text.Trim() : "";
                int codeIdInt = DataTypeConvert.GetInt(searchLookUpCodeFileName.EditValue);

                dataSet_WNowInfo.Tables[0].Clear();
                nowInfoDAO.QueryWarehouseNowInfo(dataSet_WNowInfo.Tables[0], codeIdInt, repertoryIdInt, projectNameStr, !checkZero.Checked);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--查询当前库存事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiCxdqkcsjcw.Text , ex);
            }
        }

        #region 拖出

        /// <summary>
        /// 在GridView中按下鼠标事件
        /// </summary>
        private void gridViewWNowInfo_MouseDown(object sender, MouseEventArgs e)
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
                //ExceptionHandler.HandleException(this.Text + "--在GridView中按下鼠标事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiZgridviewzaxsbsjcw.Text , ex);
            }
        }

        /// <summary>
        /// 在GridView中移动鼠标事件
        /// </summary>
        private void gridViewWNowInfo_MouseMove(object sender, MouseEventArgs e)
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
                //ExceptionHandler.HandleException(this.Text + "--在GridView中按下鼠标事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiZgridviewzaxsbsjcw.Text , ex);
            }
        }

        #endregion

        #region 拖入

        /// <summary>
        /// 拖拽在GridControl上面
        /// </summary>
        private void gridControlIMList_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<DataRow>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// 拖拽进入到GridControl控件
        /// </summary>
        private void gridControlIMList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 实现拖拽当前库存事件
        /// </summary>
        private void gridControlIMList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                List<DataRow> drs = e.Data.GetData(typeof(List<DataRow>)) as List<DataRow>;
                if (drs != null)
                {
                    if (drs.Count > SystemInfo.FormDragDropMaxRecordCount)
                    {
                        MessageHandler.ShowMessageBox(string.Format("拖拽记录的最大数量为{0}，请重新操作。", SystemInfo.FormDragDropMaxRecordCount));
                        return;
                    }

                    WNowInfoToInvAdjust_DragOrder(sender, drs);
                    ClearAlreadyDragWNowInfo();
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--实现拖拽当前库存事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiSxtzdqkcsjcw.Text, ex);
            }
        }

        /// <summary>
        /// 拖拽当前库存转成库存调整单 
        /// </summary>
        private void WNowInfoToInvAdjust_DragOrder(object sender, List<DataRow> drs)
        {
            if (!whDAO.IsNewWarehouseOrder())
                return;

            int repertoryIdInt = 0;
            int locationIdInt = 0;
            string projectNoStr = "";
            
            if (drs.Count > 0)
            {
                repertoryIdInt = DataTypeConvert.GetInt(drs[0]["RepertoryId"]);
                locationIdInt = DataTypeConvert.GetInt(drs[0]["LocationId"]);
                projectNoStr = DataTypeConvert.GetString(drs[0]["ProjectNo"]);
            }
            else
                return;

            //foreach (DataRow dr in drs)
            //{
            //    if (DataTypeConvert.GetInt(dr["RepertoryId"]) != repertoryIdInt || DataTypeConvert.GetInt(dr["LocationId"]) != locationIdInt || DataTypeConvert.GetString(dr["ProjectNo"]) != projectNoStr)
            //    {
            //        MessageHandler.ShowMessageBox("一张库存调整单必须选择相同的仓库和项目号进行登记，请重新操作。");
            //        return;
            //    }
            //}

            if (btnNew.Enabled)
            {
                ClearHeadGridAllSelect();
                gridViewIAHead.AddNewRow();
                FocusedHeadView("RepertoryId");

                gridViewIAHead.SetFocusedRowCellValue("RepertoryId", repertoryIdInt);
                gridViewIAHead.SetFocusedRowCellValue("LocationId", locationIdInt);
                gridViewIAHead.SetFocusedRowCellValue("ProjectNo", projectNoStr);

                dataSet_IA.Tables[1].Clear();
                foreach (DataRow dr in drs)
                {
                    gridViewIAList.AddNewRow();
                    gridViewIAList.SetFocusedRowCellValue("CodeId", dr["CodeId"]);
                    gridViewIAList.SetFocusedRowCellValue("CodeFileName", dr["CodeFileName"]);
                    gridViewIAList.SetFocusedRowCellValue("CodeName", dr["CodeName"]);
                    gridViewIAList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(dr["Qty"]));
                    gridViewIAList.SetFocusedRowCellValue("ShelfId", dr["ShelfId"]);
                }
                gridViewIAList.RefreshData();
                FocusedListView(false, "Qty", gridViewIAList.GetFocusedDataSourceRowIndex());

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewIAHead.DataRowCount;
            }
            else
            {
                int adjRepertoryIdInt = DataTypeConvert.GetInt(gridViewIAHead.GetFocusedDataRow()["RepertoryId"]);
                int adjLoctionIdInt = DataTypeConvert.GetInt(gridViewIAHead.GetFocusedDataRow()["LocationId"]);
                string adjProjectNoStr = DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["ProjectNo"]);
                if (adjRepertoryIdInt == 0)
                    gridViewIAHead.GetFocusedDataRow()["RepertoryId"] = repertoryIdInt;
                if (adjLoctionIdInt == 0)
                    gridViewIAHead.GetFocusedDataRow()["LocationId"] = locationIdInt;
                if (adjProjectNoStr == "")
                    gridViewIAHead.GetFocusedDataRow()["ProjectNo"] = projectNoStr;

                adjRepertoryIdInt = adjRepertoryIdInt == 0 ? repertoryIdInt : adjRepertoryIdInt;
                adjLoctionIdInt = adjLoctionIdInt == 0 ? locationIdInt : adjLoctionIdInt;
                adjProjectNoStr = adjProjectNoStr == "" ? projectNoStr : adjProjectNoStr;
                //adjRepertoryIdInt = adjRepertoryIdInt == "" ? repertoryIdInt : adjRepertoryIdInt;
                //adjProjectNoStr = adjProjectNoStr == "" ? projectNoStr : adjProjectNoStr;

                //if (adjRepertoryIdInt != repertoryIdInt || adjLoctionIdInt != locationIdInt || adjProjectNoStr != projectNoStr)
                //{
                //    MessageHandler.ShowMessageBox("一张库存移动单必须选择相同的仓库和项目号进行登记，请重新操作。");
                //    return;
                //}

                foreach (DataRow dr in drs)
                {
                    gridViewIAList.AddNewRow();
                    gridViewIAList.SetFocusedRowCellValue("CodeId", dr["CodeId"]);
                    gridViewIAList.SetFocusedRowCellValue("CodeFileName", dr["CodeFileName"]);
                    gridViewIAList.SetFocusedRowCellValue("CodeName", dr["CodeName"]);
                    gridViewIAList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(dr["Qty"]));
                    gridViewIAList.SetFocusedRowCellValue("ShelfId", dr["ShelfId"]);
                }

                gridViewIAList.FocusedRowHandle = gridViewIAList.DataRowCount;
                FocusedListView(false, "Qty", gridViewIAList.GetFocusedDataSourceRowIndex());
                gridViewIAList.RefreshData();
            }
        }

        #endregion


        /// <summary>
        /// 清空已经拖拽的当前库存明细
        /// </summary>
        private void ClearAlreadyDragWNowInfo()
        {
            //for (int i = dataSet_WNowInfo.Tables[0].Rows.Count - 1; i >= 0; i--)
            //{
            //    if (dataSet_IM.Tables[1].Select(string.Format("CodeFileName='{0}' and ProjectName='{1}' and ShelfId='{2}'", DataTypeConvert.GetString(dataSet_WNowInfo.Tables[0].Rows[i]["CodeFileName"]), DataTypeConvert.GetString(dataSet_WNowInfo.Tables[0].Rows[i]["ProjectName"]), DataTypeConvert.GetString(dataSet_WNowInfo.Tables[0].Rows[i]["ShelfId"]))).Length > 0)
            //        dataSet_WNowInfo.Tables[0].Rows.RemoveAt(i);
            //}
        }

        #endregion

    }
}
