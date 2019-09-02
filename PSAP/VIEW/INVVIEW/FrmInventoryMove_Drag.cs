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
    public partial class FrmInventoryMove_Drag : DockContent
    {
        #region 私有变量

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmInventoryMoveDAO imDAO = new FrmInventoryMoveDAO();
        FrmWarehouseNowInfoDAO nowInfoDAO = new FrmWarehouseNowInfoDAO();

        /// <summary>
        /// 主表聚焦的行号
        /// </summary>
        int headFocusedLineNo = 0;

        /// <summary>
        /// 查询的库存移动单号
        /// </summary>
        public static string queryIMHeadNo = "";

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

        public FrmInventoryMove_Drag()
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
        private void FrmInventoryMove_Load(object sender, EventArgs e)
        {
            try
            {
                //ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd, checkAll });
                ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd });

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateIMDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateIMDateEnd.DateTime = nowDate.Date;

                DataTable repertoryTable_f = commonDAO.QueryRepertoryInfo(false);
                DataTable repertoryTable_t = commonDAO.QueryRepertoryInfo(true);
                DataTable locationTable_t = commonDAO.QueryRepertoryLocationInfo(true);
                DataTable locationTable_f = commonDAO.QueryRepertoryLocationInfo(false);
                DataTable shelfInfoTable = commonDAO.QueryShelfInfo(false);
                DataTable userInfoTable_t = commonDAO.QueryUserInfo(true);

                lookUpInRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpInRepertoryId.ItemIndex = 0;
                lookUpOutRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpOutRepertoryId.ItemIndex = 0;
                SearchInLocationId.Properties.DataSource = locationTable_t;
                SearchInLocationId.EditValue = 0;
                SearchOutLocationId.Properties.DataSource = locationTable_t;
                SearchOutLocationId.EditValue = 0;
                lookUpReqDep.Properties.DataSource = commonDAO.QueryDepartment(true);
                lookUpReqDep.ItemIndex = 0;
                comboBoxWarehouseState.SelectedIndex = 0;
                lookUpCreator.Properties.DataSource = userInfoTable_t;
                lookUpCreator.EditValue = SystemInfo.user.AutoId;
                lookUpApprover.Properties.DataSource = userInfoTable_t;
                lookUpApprover.ItemIndex = -1;

                repLookUpInRepertoryId.DataSource = repertoryTable_f;
                repSearchInLocationId.DataSource = locationTable_f;
                repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);
                repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                repLookUpCreator.DataSource = commonDAO.QueryUserInfo(false);
                repSearchCodeFileName.DataSource = commonDAO.QueryPartsCode(false);
                repSearchOutProjectNo.DataSource = commonDAO.QueryProjectList(false);
                repSearchOutShelfId.DataSource = shelfInfoTable;

                lookUpRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpRepertoryId.ItemIndex = 0;
                searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(true);
                searchLookUpProjectNo.Text = "全部";
                searchLookUpCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(true);
                searchLookUpCodeFileName.Text = "全部";

                repLookUpRepertoryId.DataSource = repertoryTable_f;
                repLookUpLocationId.DataSource = locationTable_f;
                repLookUpShelfId.DataSource = shelfInfoTable;

                if (textCommon.Text == "")
                {
                    imDAO.QueryInventoryMoveHead(dataSet_IM.Tables[0], "", "", 0, 0, 0, 0, "", 0, 0, -1, "", true);
                    imDAO.QueryInventoryMoveList(dataSet_IM.Tables[1], "", true);
                }

                if (SystemInfo.DisableProjectNo)
                {
                    btnWNowInfoQuery.Location = new Point(245, 43);
                    pnlLeftTop.Height = 80;

                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    colProjectName.Visible = false;
                    colOutProjectNo.Visible = false;
                    colInProjectNo.Visible = false;
                }

                if (SystemInfo.DisableShelfInfo)
                {
                    colSShelfId.Visible = false;
                    colOutShelfId.Visible = false;
                    colInShelfId.Visible = false;
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
        private void FrmInventoryMove_Activated(object sender, EventArgs e)
        {
            try
            {
                if (queryIMHeadNo != "")
                {
                    textCommon.Text = queryIMHeadNo;
                    queryIMHeadNo = "";
                    lookUpInRepertoryId.ItemIndex = 0;
                    lookUpOutRepertoryId.ItemIndex = 0;
                    SearchInLocationId.EditValue = 0;
                    SearchOutLocationId.EditValue = 0;
                    lookUpReqDep.ItemIndex = 0;
                    lookUpCreator.ItemIndex = 0;

                    dataSet_IM.Tables[0].Clear();
                    headFocusedLineNo = 0;
                    imDAO.QueryInventoryMoveHead(dataSet_IM.Tables[0], "", "", 0, 0, 0, 0, "", 0, 0, -1, textCommon.Text, false);
                    SetButtonAndColumnState(false);

                    if (dataSet_IM.Tables[0].Rows.Count > 0)
                    {
                        dateIMDateBegin.DateTime = DataTypeConvert.GetDateTime(dataSet_IM.Tables[0].Rows[0]["InventoryMoveDate"]).Date;
                        dateIMDateEnd.DateTime = dateIMDateBegin.DateTime.AddDays(7);
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
        private void FrmInventoryMove_Shown(object sender, EventArgs e)
        {
            pnlMiddle.Height = (this.Height - pnltop.Height) / 2;

            dockPnlLeft.Width = SystemInfo.DragForm_LeftDock_Width;
        }

        /// <summary>
        /// 删除选项
        /// </summary>
        private void lookUpApprover_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                lookUpApprover.EditValue = null;
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

                if (dateIMDateBegin.EditValue == null || dateIMDateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox(tsmiYdrqbnwkcx.Text);// ("移动日期不能为空，请设置后重新进行查询。");
                    if (dateIMDateBegin.EditValue == null)
                        dateIMDateBegin.Focus();
                    else
                        dateIMDateEnd.Focus();
                    return;
                }
                string orderDateBeginStr = dateIMDateBegin.DateTime.ToString("yyyy-MM-dd");
                string orderDateEndStr = dateIMDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                int inRepertoryIdInt = lookUpInRepertoryId.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpInRepertoryId.EditValue) : 0;
                int outRepertoryIdInt = lookUpOutRepertoryId.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpOutRepertoryId.EditValue) : 0;
                int inLocationIdInt = DataTypeConvert.GetInt(SearchInLocationId.EditValue);
                int outLcationIdInt = DataTypeConvert.GetInt(SearchOutLocationId.EditValue);
                string reqDepStr = lookUpReqDep.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpReqDep.EditValue) : "";

                int warehouseStateInt = CommonHandler.Get_WarehouseState_No(comboBoxWarehouseState.Text);
                int creatorInt = lookUpCreator.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpCreator.EditValue) : 0;
                int approverInt = -1;
                if (lookUpApprover.ItemIndex == 0)
                    approverInt = 0;
                else if (lookUpApprover.ItemIndex > 0)
                    approverInt = DataTypeConvert.GetInt(lookUpApprover.EditValue);
                string commonStr = textCommon.Text.Trim();

                dataSet_IM.Tables[0].Clear();
                dataSet_IM.Tables[1].Clear();
                headFocusedLineNo = 0;
                imDAO.QueryInventoryMoveHead(dataSet_IM.Tables[0], orderDateBeginStr, orderDateEndStr, inRepertoryIdInt, outRepertoryIdInt, inLocationIdInt, outLcationIdInt, reqDepStr, warehouseStateInt, creatorInt, approverInt, commonStr, false);

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
        private void gridViewIMHead_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewIMHead.GetFocusedDataRow() != null)
                {
                    if (onlySelectColChangeRowState)
                    {
                        dataSet_IM.Tables[0].AcceptChanges();
                        onlySelectColChangeRowState = false;
                    }
                    else
                    {
                        if (headFocusedLineNo < gridViewIMHead.DataRowCount && gridViewIMHead.FocusedRowHandle != headFocusedLineNo && gridViewIMHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                        {
                            MessageHandler.ShowMessageBox(tsmiDqkcyddyjxghh.Text);// ("当前库存移动单已经修改，请保存后再进行换行。");
                            gridViewIMHead.FocusedRowHandle = headFocusedLineNo;
                        }
                        else if (headFocusedLineNo == gridViewIMHead.DataRowCount)
                        {

                        }
                        else
                        {
                            if (gridViewIMHead.FocusedRowHandle != headFocusedLineNo && gridViewIMHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                            else if (gridViewIMHead.GetDataRow(headFocusedLineNo).RowState == DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                        }
                    }

                    if (DataTypeConvert.GetString(gridViewIMHead.GetFocusedDataRow()["InventoryMoveNo"]) != "")
                    {
                        dataSet_IM.Tables[1].Clear();
                        imDAO.QueryInventoryMoveList(dataSet_IM.Tables[1], DataTypeConvert.GetString(gridViewIMHead.GetFocusedDataRow()["InventoryMoveNo"]), false);
                        //if (queryListAutoId > 0)
                        //{
                        //    for (int i = 0; i < gridViewIMList.DataRowCount; i++)
                        //    {
                        //        if (DataTypeConvert.GetInt(gridViewIMList.GetDataRow(i)["AutoId"]) == queryListAutoId)
                        //        {
                        //            gridViewIMList.FocusedRowHandle = i;
                        //            queryListAutoId = 0;
                        //            break;
                        //        }
                        //    }
                        //}
                    }

                    if (gridViewIMHead.FocusedRowHandle >= 0)
                    {
                        headFocusedLineNo = gridViewIMHead.FocusedRowHandle;
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
        /// 确定行号
        /// </summary>
        private void gridViewIMHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        private void gridViewIMHead_KeyDown(object sender, KeyEventArgs e)
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
        private void gridViewIMHead_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

                ClearHeadGridAllSelect();

                //gridViewPrReqHead.PostEditor();
                gridViewIMHead.AddNewRow();
                FocusedHeadView("OutRepertoryId");

                dataSet_IM.Tables[1].Clear();
                gridViewIMList.AddNewRow();
                FocusedListView(false, "CodeFileName", gridViewIMList.GetFocusedDataSourceRowIndex());
                gridViewIMList.RefreshData();

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewIMHead.DataRowCount;
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

                if (gridViewIMHead.GetFocusedDataRow() == null)
                    return;

                if (!CheckWarehouseState())
                    return;

                if (btnSave.Tag.ToString() != f.tsmiBc.Text)
                {
                    ClearHeadGridAllSelect();

                    SetButtonAndColumnState(true);
                    FocusedHeadView("OutRepertoryId");
                }
                else
                {
                    DataRow headRow = gridViewIMHead.GetFocusedDataRow();
                    int outRepertoryIdInt = DataTypeConvert.GetInt(headRow["OutRepertoryId"]);
                    int inRepertoryIdInt = DataTypeConvert.GetInt(headRow["InRepertoryId"]);
                    int outLocationIdInt = DataTypeConvert.GetInt(headRow["OutLocationId"]);
                    int inLocationIdInt = DataTypeConvert.GetInt(headRow["InLocationId"]);
                    if (outRepertoryIdInt == 0)
                    {
                        MessageHandler.ShowMessageBox(tsmiCkckbnwkbc.Text);// ("出库仓库不能为空，请填写后再进行保存。");
                        FocusedHeadView("OutRepertoryId");
                        return;
                    }
                    if (inRepertoryIdInt == 0)
                    {
                        MessageHandler.ShowMessageBox(tsmiRkckbnwkbc.Text);// ("入库仓库不能为空，请填写后再进行保存。");
                        FocusedHeadView("InRepertoryId");
                        return;
                    }
                    if (outLocationIdInt == 0)
                    {
                        MessageHandler.ShowMessageBox("出库仓位不能为空，请填写后再进行保存。");
                        FocusedHeadView("OutLocationId");
                        return;
                    }
                    if (inLocationIdInt == 0)
                    {
                        MessageHandler.ShowMessageBox("入库仓位不能为空，请填写后再进行保存。");
                        FocusedHeadView("InLocationId");
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

                    for (int i = gridViewIMList.DataRowCount - 1; i >= 0; i--)
                    {
                        DataRow listRow = gridViewIMList.GetDataRow(i);
                        if (DataTypeConvert.GetString(listRow["CodeFileName"]) == "")
                        {
                            gridViewIMList.DeleteRow(i);
                            continue;
                        }
                        //if (DataTypeConvert.GetString(listRow["Qty"]) == "")
                        //{
                        //    MessageHandler.ShowMessageBox(tsmiSlbnwkbc.Text);// ("数量不能为空，请填写后再进行保存。");
                        //    FocusedListView(true, "Qty", i);
                        //    return;
                        //}
                        if (DataTypeConvert.GetDouble(listRow["Qty"]) == 0)
                        {
                            MessageHandler.ShowMessageBox("数量不能为空或者零，请填写后再进行保存。");
                            FocusedListView(true, "Qty", i);
                            return;
                        }
                        string outProjectNoStr = DataTypeConvert.GetString(listRow["OutProjectNo"]);
                        int outShelfIdInt = DataTypeConvert.GetInt(listRow["OutShelfId"]);
                        string inProjectNoStr = DataTypeConvert.GetString(listRow["InProjectNo"]);
                        int inShelfIdInt = DataTypeConvert.GetInt(listRow["InShelfId"]);

                        if (outProjectNoStr == "")
                        {
                            MessageHandler.ShowMessageBox(tsmiCkxmhbnwkbc.Text);// ("出库项目号不能为空，请填写后再进行保存。");
                            FocusedListView(true, "OutProjectNo", i);
                            return;
                        }
                        if (outShelfIdInt == 0)
                        {
                            MessageHandler.ShowMessageBox(tsmiCkhjhbnwkbc.Text);// ("出库货架号不能为空，请填写后再进行保存。");
                            FocusedListView(true, "OutShelfId", i);
                            return;
                        }
                        if (inProjectNoStr == "")
                        {
                            MessageHandler.ShowMessageBox(tsmiRkxmhbnwkbc.Text);// ("入库项目号不能为空，请填写后再进行保存。");
                            FocusedListView(true, "InProjectNo", i);
                            return;
                        }
                        if (inShelfIdInt == 0)
                        {
                            MessageHandler.ShowMessageBox(tsmiRkhjhbnwkbc.Text);// ("入库货架号不能为空，请填写后再进行保存。");
                            FocusedListView(true, "InShelfId", i);
                            return;
                        }
                        if (outRepertoryIdInt == inRepertoryIdInt && outLocationIdInt == inLocationIdInt && outProjectNoStr == inProjectNoStr && outShelfIdInt == inShelfIdInt)
                        {
                            MessageHandler.ShowMessageBox("出库的【仓库】【仓位】【项目号】【货架号】和入库的【仓库】【仓位】【项目号】【货架号】完全相同，请填写后再进行保存。");
                            FocusedListView(true, "OutProjectNo", i);
                            return;
                        }
                    }

                    if (gridViewIMList.DataRowCount == 0)
                    {
                        MessageHandler.ShowMessageBox("库存移动单明细不能为空，请填写后再进行保存。");
                        return;
                    }

                    int ret = imDAO.SaveInventoryMove(gridViewIMHead.GetFocusedDataRow(), dataSet_IM.Tables[1]);
                    switch (ret)
                    {
                        case -1:
                            btnQuery_Click(null, null);
                            break;
                        case 1:
                            dataSet_IM.Tables[1].Clear();
                            imDAO.QueryInventoryMoveList(dataSet_IM.Tables[1], DataTypeConvert.GetString(gridViewIMHead.GetFocusedDataRow()["InventoryMoveNo"]), false);
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

                if (gridViewIMHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                {
                    if (DataTypeConvert.GetString(gridViewIMHead.GetDataRow(headFocusedLineNo)["InventoryMoveNo"]) == "")
                    {
                        gridViewIMHead.DeleteRow(headFocusedLineNo);
                    }
                    else
                    {
                        gridViewIMHead.GetFocusedDataRow().RejectChanges();
                    }
                }

                SetButtonAndColumnState(false);

                dataSet_IM.Tables[1].Clear();
                if (gridViewIMHead.GetFocusedDataRow() != null)
                    imDAO.QueryInventoryMoveList(dataSet_IM.Tables[1], DataTypeConvert.GetString(gridViewIMHead.GetFocusedDataRow()["InventoryMoveNo"]), false);

                //gridViewPrReqHead_FocusedRowChanged(sender, null);
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

                int count = dataSet_IM.Tables[0].Select("select=1").Length;
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
                if (!imDAO.DeleteInventoryMove_Multi(dataSet_IM.Tables[0]))
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

                int count = dataSet_IM.Tables[0].Select("select=1").Length;
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
                    FrmOrderApproval frmOrder = new FrmOrderApproval(DataTypeConvert.GetString(dataSet_IM.Tables[0].Select("select=1")[0]["InventoryMoveNo"]));
                    if (frmOrder.ShowDialog() == DialogResult.OK)
                        btnQuery_Click(null, null);
                }
                else
                {
                    if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要审批当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                    {
                        return;
                    }

                    int successCountInt = 0;
                    //直接审批，不再谈页面
                    if (!imDAO.IMApprovalInfo_Multi(dataSet_IM.Tables[0], ref successCountInt))
                        btnQuery_Click(null, null);
                    else
                    {
                        MessageHandler.ShowMessageBox(string.Format("成功审批了{0}条记录。", successCountInt));
                    }
                }
                ClearHeadGridAllSelect();
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

                int count = dataSet_IM.Tables[0].Select("select=1").Length;
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

                if (!imDAO.CancalIMApprovalInfo_Multi(dataSet_IM.Tables[0]))
                    btnQuery_Click(null, null);
                else
                {
                    MessageHandler.ShowMessageBox(string.Format("成功取消审批了{0}条记录。", count));
                }
                ClearHeadGridAllSelect();
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

                string imHeadNoStr = "";
                DataRow dr = null;
                DataRow[] drs = dataSet_IM.Tables[0].Select("select=1");
                if (drs.Length > 1)
                {
                    MessageHandler.ShowMessageBox("只能选中一条记录进行打印预览，请重新选择。");
                    return;
                }
                else if (drs.Length == 0)
                {
                    if (gridViewIMHead.GetFocusedDataRow() != null)
                    {
                        imHeadNoStr = DataTypeConvert.GetString(gridViewIMHead.GetFocusedDataRow()["InventoryMoveNo"]);
                        dr = gridViewIMHead.GetFocusedDataRow();
                    }
                }
                else
                {
                    imHeadNoStr = DataTypeConvert.GetString(drs[0]["InventoryMoveNo"]);
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

                //string imHeadNoStr = "";
                //if (gridViewIMHead.GetFocusedDataRow() != null)
                //    imHeadNoStr = DataTypeConvert.GetString(gridViewIMHead.GetFocusedDataRow()["InventoryMoveNo"]);

                imDAO.PrintHandle(imHeadNoStr, 1);
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
            foreach (DataRow dr in dataSet_IM.Tables[0].Rows)
            {
                dr["Select"] = value;
            }
            onlySelectColChangeRowState = true;
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
        private void gridViewIMHead_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                gridViewIMHead.SetFocusedRowCellValue("InventoryMoveDate", nowDate);
                gridViewIMHead.SetFocusedRowCellValue("ReqDep", SystemInfo.user.DepartmentNo);
                gridViewIMHead.SetFocusedRowCellValue("WarehouseState", 1);
                gridViewIMHead.SetFocusedRowCellValue("Creator", SystemInfo.user.AutoId);
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
        private void gridViewIMList_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridViewIMList.SetFocusedRowCellValue("InventoryMoveNo", DataTypeConvert.GetString(gridViewIMHead.GetFocusedDataRow()["InventoryMoveNo"]));

                if (SystemInfo.DisableProjectNo)
                {
                    gridViewIMList.SetFocusedRowCellValue("OutProjectNo", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                    gridViewIMList.SetFocusedRowCellValue("InProjectNo", SystemInfo.DisableProjectNo_Default_ProjectNoAndStnNo);
                }

                if (SystemInfo.DisableShelfInfo)
                {
                    gridViewIMList.SetFocusedRowCellValue("OutShelfId", SystemInfo.DisableShelfInfo_Default_ShelfId);
                    gridViewIMList.SetFocusedRowCellValue("InShelfId", SystemInfo.DisableShelfInfo_Default_ShelfId);
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
        private void gridViewIMList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!colRemark.OptionsColumn.AllowEdit)
                        return;

                    if (gridViewIMList.GetFocusedDataSourceRowIndex() >= gridViewIMList.DataRowCount - 1 && gridViewIMList.FocusedColumn.Name == "colRemark")
                    {
                        ListNewRow();
                    }
                    else if (gridViewIMList.FocusedColumn.Name == "colRemark")
                    {
                        gridViewIMList.FocusedRowHandle = gridViewIMList.FocusedRowHandle + 1;
                        FocusedListView(true, "CodeFileName", gridViewIMList.GetFocusedDataSourceRowIndex());
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
                if (gridViewIMList.GetFocusedDataRow().RowState != DataRowState.Added)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的明细记录吗？") != DialogResult.Yes)
                    {
                        return;
                    }
                }
                //int prListAutoIdInt = 0;
                //if (gridViewIMList.GetFocusedDataRow() != null)
                //    prListAutoIdInt = DataTypeConvert.GetInt(gridViewIMList.GetFocusedDataRow()["PrListAutoId"]);
                gridViewIMList.DeleteRow(gridViewIMList.FocusedRowHandle);
                //if (prListAutoIdInt > 0)
                //    gridViewPrReqHead_FocusedRowChanged(sender, null);
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
        private void gridViewIMHead_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (isLockControl)
                    return;
                switch (e.Column.FieldName)
                {
                    case "InRepertoryId":
                        BindingLocationInfo(e.RowHandle, "InRepertoryId", "InLocationId");
                        break;
                    case "OutRepertoryId":
                        BindingLocationInfo(e.RowHandle, "OutRepertoryId", "OutLocationId");
                        break;
                    case "InLocationId":
                        isLockControl = true;
                        BindingShelfInfo(e.RowHandle, "InLocationId", "InShelfId");
                        isLockControl = false;
                        break;
                    case "OutLocationId":
                        isLockControl = true;
                        BindingShelfInfo(e.RowHandle, "OutLocationId", "OutShelfId");
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
        private void BindingLocationInfo(int rowHandleInt, string repertoryColName, string locationColName)
        {
            int repertoryIdInt = DataTypeConvert.GetInt(gridViewIMHead.GetDataRow(rowHandleInt)[repertoryColName]);
            if (repertoryIdInt == 0)
            {
                gridViewIMHead.SetRowCellValue(rowHandleInt, repertoryColName, null);
                gridViewIMHead.SetRowCellValue(rowHandleInt, locationColName, null);
            }
            else
            {
                gridViewIMHead.SetRowCellValue(rowHandleInt, locationColName, null);
            }
        }

        /// <summary>
        /// 绑定货架数据源
        /// </summary>
        private void BindingShelfInfo(int rowHandleInt, string locationColName, string shelfColName)
        {
            int repertoryLocationIdInt = DataTypeConvert.GetInt(gridViewIMHead.GetDataRow(rowHandleInt)[locationColName]);
            if (repertoryLocationIdInt == 0)
            {
                gridViewIMHead.SetRowCellValue(rowHandleInt, locationColName, null);
            }
            else
            {
                if (!SystemInfo.DisableShelfInfo)
                {
                    for (int i = 0; i < gridViewIMList.RowCount; i++)
                    {
                        gridViewIMList.SetRowCellValue(i, shelfColName, null);
                    }
                }
            }
        }

        /// <summary>
        /// 子表单元格值变化进行的操作
        /// </summary>
        private void gridViewIMList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string tmpStr = "";
                switch (e.Column.FieldName)
                {
                    case "CodeFileName":
                        tmpStr = DataTypeConvert.GetString(gridViewIMList.GetDataRow(e.RowHandle)["CodeFileName"]);
                        if (tmpStr == "")
                            gridViewIMList.SetRowCellValue(e.RowHandle, "CodeName", "");
                        else
                        {
                            DataTable temp = (DataTable)repSearchCodeFileName.DataSource;
                            DataRow[] drs = temp.Select(string.Format("CodeFileName='{0}'", tmpStr));
                            if (drs.Length > 0)
                            {
                                gridViewIMList.SetRowCellValue(e.RowHandle, "CodeName", DataTypeConvert.GetString(drs[0]["CodeName"]));
                            }
                        }
                        break;
                    case "OutProjectNo":
                        tmpStr = DataTypeConvert.GetString(gridViewIMList.GetDataRow(e.RowHandle)["OutProjectNo"]);
                        if (tmpStr == "")
                            gridViewIMList.SetRowCellValue(e.RowHandle, "OutProjectName", "");
                        else
                        {
                            DataTable temp = (DataTable)repSearchOutProjectNo.DataSource;
                            DataRow[] drs = temp.Select(string.Format("ProjectNo='{0}'", tmpStr));
                            if (drs.Length > 0)
                            {
                                gridViewIMList.SetRowCellValue(e.RowHandle, "OutProjectName", DataTypeConvert.GetString(drs[0]["ProjectName"]));
                            }
                        }
                        break;
                    case "InProjectNo":
                        tmpStr = DataTypeConvert.GetString(gridViewIMList.GetDataRow(e.RowHandle)["InProjectNo"]);
                        if (tmpStr == "")
                            gridViewIMList.SetRowCellValue(e.RowHandle, "InProjectName", "");
                        else
                        {
                            DataTable temp = (DataTable)repSearchOutProjectNo.DataSource;
                            DataRow[] drs = temp.Select(string.Format("ProjectNo='{0}'", tmpStr));
                            if (drs.Length > 0)
                            {
                                gridViewIMList.SetRowCellValue(e.RowHandle, "InProjectName", DataTypeConvert.GetString(drs[0]["ProjectName"]));
                            }
                        }
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
        private void repSearchInLocationId_Popup(object sender, EventArgs e)
        {
            try
            {
                switch (gridViewIMHead.FocusedColumn.FieldName)
                {
                    case "InLocationId":
                        FilterLookup(sender, "RepertoryId", "InRepertoryId");
                        break;
                    case "OutLocationId":
                        FilterLookup(sender, "RepertoryId", "OutRepertoryId");
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--仓位弹出下拉列表设定过滤错误。", ex);
            }
        }

        /// <summary>
        /// 货架号弹出下拉列表设定过滤
        /// </summary>
        private void repSearchOutShelfId_Popup(object sender, EventArgs e)
        {
            try
            {
                switch (gridViewIMList.FocusedColumn.FieldName)
                {
                    case "InShelfId":
                        FilterLookup(sender, "RepertoryLocationId", "InLocationId");
                        break;
                    case "OutShelfId":
                        FilterLookup(sender, "RepertoryLocationId", "OutLocationId");
                        break;
                }
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

            gridView.ActiveFilterString = string.Format("{0} = {1}", fieldNameStr, DataTypeConvert.GetInt(gridViewIMHead.GetFocusedDataRow()[gridColumnNameStr]));
            gridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;

            MethodInfo mi = gridView.GetType().GetMethod("ApplyColumnsFilterEx", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(gridView, null);
        }

        /// <summary>
        /// 设定当前行选择
        /// </summary>
        private void repCheckSelect_EditValueChanged(object sender, EventArgs e)
        {
            if (DataTypeConvert.GetBoolean(gridViewIMHead.GetFocusedDataRow()["Select"]))
                gridViewIMHead.GetFocusedDataRow()["Select"] = false;
            else
                gridViewIMHead.GetFocusedDataRow()["Select"] = true;
            onlySelectColChangeRowState = true;
        }

        /// <summary>
        /// 检查是否有未填写字段
        /// </summary>
        private bool IsHaveBlankLine()
        {
            gridViewIMList.FocusedRowHandle = 0;
            for (int i = 0; i < gridViewIMList.DataRowCount; i++)
            {
                if (DataTypeConvert.GetString(gridViewIMList.GetDataRow(i)["CodeFileName"]) == "")
                {
                    gridViewIMList.Focus();
                    gridViewIMList.FocusedColumn = colCodeFileName;
                    gridViewIMList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewIMList.GetDataRow(i)["Qty"]) == "")
                {
                    gridViewIMList.Focus();
                    gridViewIMList.FocusedColumn = colQty;
                    gridViewIMList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewIMList.GetDataRow(i)["OutProjectNo"]) == "")
                {
                    gridViewIMList.Focus();
                    gridViewIMList.FocusedColumn = colOutProjectNo;
                    gridViewIMList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewIMList.GetDataRow(i)["OutShelfId"]) == "")
                {
                    gridViewIMList.Focus();
                    gridViewIMList.FocusedColumn = colOutShelfId;
                    gridViewIMList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewIMList.GetDataRow(i)["InProjectNo"]) == "")
                {
                    gridViewIMList.Focus();
                    gridViewIMList.FocusedColumn = colInProjectNo;
                    gridViewIMList.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewIMList.GetDataRow(i)["InShelfId"]) == "")
                {
                    gridViewIMList.Focus();
                    gridViewIMList.FocusedColumn = colInShelfId;
                    gridViewIMList.FocusedRowHandle = i;
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
            gridViewIMList.AddNewRow();
            FocusedListView(true, "CodeFileName", gridViewIMList.GetFocusedDataSourceRowIndex());
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
                btnSave.Text = f.tsmiBc.Text;
                btnCancel.Enabled = true;
                btnDelete.Enabled = false;
            }
            else
            {
                btnNew.Enabled = true;
                btnSave.Tag = "修改";
                btnSave.Text = f.tsmiXg.Text;
                btnCancel.Enabled = false;
                btnDelete.Enabled = true;
            }
            btnPreview.Enabled = !ret;

            btnListAdd.Enabled = ret;

            colOutRepertoryId.OptionsColumn.AllowEdit = ret;
            colInRepertoryId.OptionsColumn.AllowEdit = ret;
            colOutLocationId.OptionsColumn.AllowEdit = ret;
            colInLocationId.OptionsColumn.AllowEdit = ret;
            colApprovalType.OptionsColumn.AllowEdit = ret;
            colPRemark.OptionsColumn.AllowEdit = ret;

            colCodeFileName.OptionsColumn.AllowEdit = ret;
            colQty.OptionsColumn.AllowEdit = ret;
            colOutProjectNo.OptionsColumn.AllowEdit = ret;
            colOutShelfId.OptionsColumn.AllowEdit = ret;
            colInProjectNo.OptionsColumn.AllowEdit = ret;
            colInShelfId.OptionsColumn.AllowEdit = ret;
            colRemark.OptionsColumn.AllowEdit = ret;

            repbtnDelete.Buttons[0].Enabled = ret;
            repCheckSelect.ReadOnly = ret;
            checkAll.ReadOnly = ret;

            if (this.Controls.ContainsKey("lblEditFlag"))
            {
                //检测窗口状态：新增、编辑="EDIT"，保存、取消=""
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
            if (gridViewIMHead.GetFocusedDataRow() == null)
                return false;
            int reqState = DataTypeConvert.GetInt(gridViewIMHead.GetFocusedDataRow()["WarehouseState"]);
            switch (reqState)
            {
                case 2:
                    MessageHandler.ShowMessageBox(string.Format("库存移动单[{0}]已经审批，不可以操作。", DataTypeConvert.GetString(gridViewIMHead.GetFocusedDataRow()["InventoryMoveNo"])));
                    return false;
                //case 3:
                //    MessageHandler.ShowMessageBox(string.Format("库存移动单[{0}]已经结账，不可以操作。", DataTypeConvert.GetString(gridViewIMHead.GetFocusedDataRow()["InventoryMoveNo"])));
                //    return false;
                case 4:
                    MessageHandler.ShowMessageBox(string.Format("库存移动单[{0}]已经审批中，不可以操作。", DataTypeConvert.GetString(gridViewIMHead.GetFocusedDataRow()["InventoryMoveNo"])));
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检测当前选中的出库单状态是否可以操作
        /// </summary>
        private bool CheckWarehouseState_Multi(bool checkNoApprover, bool checkApprover, bool checkSettle, bool checkApproverBetween)
        {
            for (int i = 0; i < gridViewIMHead.DataRowCount; i++)
            {
                if (DataTypeConvert.GetBoolean(gridViewIMHead.GetDataRow(i)["Select"]))
                {
                    int reqState = DataTypeConvert.GetInt(gridViewIMHead.GetDataRow(i)["WarehouseState"]);
                    switch (reqState)
                    {
                        case 1:
                            if (checkNoApprover)
                            {
                                MessageHandler.ShowMessageBox(string.Format("库存移动单[{0}]未审批，不可以操作。", DataTypeConvert.GetString(gridViewIMHead.GetDataRow(i)["InventoryMoveNo"])));
                                gridViewIMHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        case 2:
                            if (checkApprover)
                            {
                                MessageHandler.ShowMessageBox(string.Format("库存移动单[{0}]已经审批，不可以操作。", DataTypeConvert.GetString(gridViewIMHead.GetDataRow(i)["InventoryMoveNo"])));
                                gridViewIMHead.FocusedRowHandle = i;
                                return false;
                            }
                            break;
                        //case 3:
                        //    if (checkSettle)
                        //    {
                        //        MessageHandler.ShowMessageBox(string.Format("库存移动单[{0}]已经结账，不可以操作。", DataTypeConvert.GetString(gridViewIMHead.GetDataRow(i)["InventoryMoveNo"])));
                        //        gridViewIMHead.FocusedRowHandle = i;
                        //        return false;
                        //    }
                        //    break;
                        case 4:
                            if (checkApproverBetween)
                            {
                                MessageHandler.ShowMessageBox(string.Format("库存移动单[{0}]已经审批中，不可以操作。", DataTypeConvert.GetString(gridViewIMHead.GetDataRow(i)["InventoryMoveNo"])));
                                gridViewIMHead.FocusedRowHandle = i;
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
            gridControlIMHead.Focus();
            ColumnView headView = (ColumnView)gridControlIMHead.FocusedView;
            headView.FocusedColumn = headView.Columns[colName];
            gridViewIMHead.FocusedRowHandle = headView.FocusedRowHandle;
        }

        /// <summary>
        /// 聚焦子表当前行的列
        /// </summary>
        private void FocusedListView(bool isFocusedControl, string colName, int lineNo)
        {
            if (isFocusedControl)
                gridControlIMList.Focus();
            ColumnView listView = (ColumnView)gridControlIMList.FocusedView;
            listView.FocusedColumn = listView.Columns[colName];
            gridViewIMList.FocusedRowHandle = lineNo;
        }

        /// <summary>
        /// 清楚当前的所有选择
        /// </summary>
        private void ClearHeadGridAllSelect()
        {
            checkAll.Checked = false;
            for (int i = 0; i < dataSet_IM.Tables[0].Rows.Count; i++)
            {
                dataSet_IM.Tables[0].Rows[i]["Select"] = false;
            }
            dataSet_IM.Tables[0].AcceptChanges();
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
                string codeFileNameStr = searchLookUpCodeFileName.Text != "全部" ? DataTypeConvert.GetString(searchLookUpCodeFileName.EditValue) : "";

                dataSet_WNowInfo.Tables[0].Clear();
                nowInfoDAO.QueryWarehouseNowInfo(dataSet_WNowInfo.Tables[0], codeFileNameStr, repertoryIdInt, projectNameStr, !checkZero.Checked);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--查询当前库存事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiCcdqkdsjcw.Text, ex);
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
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiZgridviewzaxsbsjcw.Text, ex);
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
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiZgridviewzaxsbsjcw.Text, ex);
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

                    WNowInfoToInvMove_DragOrder(sender, drs);
                    ClearAlreadyDragWNowInfo();
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--实现拖拽当前库存事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiSxtzcgddsjcw.Text, ex);
            }
        }

        /// <summary>
        /// 拖拽当前库存转成库存移动单 
        /// </summary>
        private void WNowInfoToInvMove_DragOrder(object sender, List<DataRow> drs)
        {
            int repertoryIdInt = 0;
            int locationIdInt = 0;
            if (drs.Count > 0)
            {
                repertoryIdInt = DataTypeConvert.GetInt(drs[0]["RepertoryId"]);
                locationIdInt = DataTypeConvert.GetInt(drs[0]["LocationId"]);
            }
            else
                return;

            foreach (DataRow dr in drs)
            {
                if (DataTypeConvert.GetInt(dr["RepertoryId"]) != repertoryIdInt)
                {
                    //MessageHandler.ShowMessageBox("一张库存移动单必须选择相同的仓库进行登记，请重新操作。");
                    MessageHandler.ShowMessageBox(tsmiYzkcyddbxxz.Text);
                    return;
                }

                if (DataTypeConvert.GetInt(dr["LocationId"]) != locationIdInt)
                {
                    MessageHandler.ShowMessageBox("一张库存移动单必须选择相同的仓位进行登记，请重新操作。");
                    return;
                }
            }

            if (btnNew.Enabled)
            {
                ClearHeadGridAllSelect();
                gridViewIMHead.AddNewRow();
                FocusedHeadView("OutRepertoryId");

                gridViewIMHead.SetFocusedRowCellValue("OutRepertoryId", repertoryIdInt);
                gridViewIMHead.SetFocusedRowCellValue("OutLocationId", locationIdInt);

                dataSet_IM.Tables[1].Clear();
                foreach (DataRow dr in drs)
                {
                    gridViewIMList.AddNewRow();
                    gridViewIMList.SetFocusedRowCellValue("CodeFileName", dr["CodeFileName"]);
                    gridViewIMList.SetFocusedRowCellValue("CodeName", dr["CodeName"]);
                    gridViewIMList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(dr["Qty"]));
                    gridViewIMList.SetFocusedRowCellValue("OutProjectNo", dr["ProjectNo"]);
                    gridViewIMList.SetFocusedRowCellValue("OutShelfId", dr["ShelfId"]);
                    gridViewIMList.SetFocusedRowCellValue("OutRepertoryId", repertoryIdInt);
                    gridViewIMList.SetFocusedRowCellValue("OutLocationId", locationIdInt);
                }
                gridViewIMList.RefreshData();
                FocusedListView(false, "Qty", gridViewIMList.GetFocusedDataSourceRowIndex());

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewIMHead.DataRowCount;
            }
            else
            {
                int outRepertoryIdInt = DataTypeConvert.GetInt(gridViewIMHead.GetFocusedDataRow()["OutRepertoryId"]);
                int outLocationIdInt = DataTypeConvert.GetInt(gridViewIMHead.GetFocusedDataRow()["OutLocationId"]);
                if (outRepertoryIdInt == 0)
                {
                    outRepertoryIdInt = repertoryIdInt;
                    gridViewIMHead.GetFocusedDataRow()["OutRepertoryId"] = repertoryIdInt;
                }
                else
                {
                    if (outRepertoryIdInt != repertoryIdInt)
                    {
                        //MessageHandler.ShowMessageBox("一张库存移动单必须选择相同的仓库进行登记，请重新操作。");
                        MessageHandler.ShowMessageBox(tsmiYzkcyddbxxz.Text);
                        return;
                    }
                }
                if (outLocationIdInt == 0)
                {
                    outLocationIdInt = locationIdInt;
                    gridViewIMHead.GetFocusedDataRow()["OutLocationId"] = locationIdInt;
                }
                else
                {
                    if (outLocationIdInt != locationIdInt)
                    {
                        MessageHandler.ShowMessageBox("一张库存移动单必须选择相同的仓位进行登记，请重新操作。");
                        return;
                    }
                }

                foreach (DataRow dr in drs)
                {
                    string codeFileNameStr = DataTypeConvert.GetString(dr["CodeFileName"]);
                    string projectNoStr = DataTypeConvert.GetString(dr["ProjectNo"]);
                    int shelfNoInt = DataTypeConvert.GetInt(dr["ShelfId"]);
                    if (dataSet_IM.Tables[1].Select(string.Format("CodeFileName='{0}' and OutProjectNo='{1}' and OutShelfId={2}", codeFileNameStr, projectNoStr, shelfNoInt)).Length > 0)
                        continue;

                    gridViewIMList.AddNewRow();
                    gridViewIMList.SetFocusedRowCellValue("CodeFileName", codeFileNameStr);
                    gridViewIMList.SetFocusedRowCellValue("CodeName", dr["CodeName"]);
                    gridViewIMList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(dr["Qty"]));
                    gridViewIMList.SetFocusedRowCellValue("OutProjectNo", projectNoStr);
                    gridViewIMList.SetFocusedRowCellValue("OutShelfId", shelfNoInt);
                    gridViewIMList.SetFocusedRowCellValue("OutRepertoryId", repertoryIdInt);
                    gridViewIMList.SetFocusedRowCellValue("OutLocationId", locationIdInt);
                }

                gridViewIMList.FocusedRowHandle = gridViewIMList.DataRowCount;
                FocusedListView(false, "Qty", gridViewIMList.GetFocusedDataSourceRowIndex());
                gridViewIMList.RefreshData();
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
            //    if (dataSet_IM.Tables[1].Select(string.Format("CodeFileName='{0}' and ProjectName='{1}' and ShelfNo='{2}'", DataTypeConvert.GetString(dataSet_WNowInfo.Tables[0].Rows[i]["CodeFileName"]), DataTypeConvert.GetString(dataSet_WNowInfo.Tables[0].Rows[i]["ProjectName"]), DataTypeConvert.GetString(dataSet_WNowInfo.Tables[0].Rows[i]["ShelfNo"]))).Length > 0)
            //        dataSet_WNowInfo.Tables[0].Rows.RemoveAt(i);
            //}
        }


        #endregion
    }
}
