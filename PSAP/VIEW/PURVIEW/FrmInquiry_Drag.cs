using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using PSAP.DAO.BSDAO;
using PSAP.DAO.PURDAO;
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
    public partial class FrmInquiry_Drag : DockContent
    {
        #region 私有变量

        FrmInquiryDAO inqDAO = new FrmInquiryDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        /// <summary>
        /// 主表聚焦的行号
        /// </summary>
        int headFocusedLineNo = 0;

        /// <summary>
        /// 查询的询价单号
        /// </summary>
        public static string queryPIHeadNo = "";

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

        public FrmInquiry_Drag()
        {
            InitializeComponent();
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmInquiry_Drag_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateOrderDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateOrderDateEnd.DateTime = nowDate.Date;

                DataTable userInfoTable_t = commonDAO.QueryUserInfo(true);
                DataTable departmentTable_f = commonDAO.QueryDepartment(false);
                DataTable purCategoryTable_f = commonDAO.QueryPurCategory(false);
                DataTable projectListTable_t = commonDAO.QueryProjectList(true);
                DataTable partsCodeTable_t = commonDAO.QueryPartsCode(true);

                lookUpDepartmentNo.Properties.DataSource = commonDAO.QueryDepartment(true);
                lookUpDepartmentNo.ItemIndex = 0;
                searchLookUpBussinessBaseNo.Properties.DataSource = commonDAO.QueryBussinessBaseInfo(true);
                searchLookUpBussinessBaseNo.Text = "全部";
                lookUpCreator.Properties.DataSource = userInfoTable_t;
                lookUpCreator.EditValue = SystemInfo.user.AutoId;

                repSearchBussinessBaseNo.DataSource = commonDAO.QueryBussinessBaseInfo(false);
                repLookUpDepartmentNo.DataSource = departmentTable_f;
                repLookUpCreator.DataSource = userInfoTable_t;

                repLookUpCodeId.DataSource = partsCodeTable_t;

                dateReqDateBegin.DateTime = dateOrderDateBegin.DateTime;
                dateReqDateEnd.DateTime = dateOrderDateEnd.DateTime;
                searchLookUpProjectNo.Properties.DataSource = projectListTable_t;
                searchLookUpProjectNo.Text = "全部";

                repLookUpPrReqReqDep.DataSource = departmentTable_f;
                repLookUpPrReqPurCategory.DataSource = purCategoryTable_f;
                repSearchPrReqProjectNo.DataSource = projectListTable_t;

                dateReqDateBegin2.DateTime = dateOrderDateBegin.DateTime;
                dateReqDateEnd2.DateTime = dateOrderDateEnd.DateTime;
                searchLookUpCodeFileName.Properties.DataSource = partsCodeTable_t;
                searchLookUpCodeFileName.EditValue = 0;

                if (textCommon.Text == "")
                {
                    inqDAO.QueryInquiryHead(dataSet_Inquiry.Tables[0], "", "", "", "", "", 0, 0, "", true);
                    inqDAO.QueryInquiryList(dataSet_Inquiry.Tables[1], "", true);
                    inqDAO.QueryPIPR_Relation(dataSet_Inquiry.Tables[2], "", true);
                }

                if (SystemInfo.DisableProjectNo)
                {
                    btnPrReqQuery.Location = new Point(243, 13);
                    pnlLeftTop.Height = 80;

                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    gridColuProjectNo.Visible = false;
                    gridColuStnNo.Visible = false;
                    gridColumProjectNo.Visible = false;
                    gridColumStnNo.Visible = false;
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
        private void FrmInquiry_Drag_Activated(object sender, EventArgs e)
        {
            try
            {
                if (queryPIHeadNo != "")
                {
                    textCommon.Text = queryPIHeadNo;
                    queryPIHeadNo = "";
                    lookUpDepartmentNo.ItemIndex = 0;
                    searchLookUpBussinessBaseNo.Text = "全部";
                    lookUpCreator.ItemIndex = 0;

                    dataSet_Inquiry.Tables[0].Clear();
                    dataSet_Inquiry.Tables[1].Clear();
                    dataSet_Inquiry.Tables[2].Clear();
                    headFocusedLineNo = 0;
                    inqDAO.QueryInquiryHead(dataSet_Inquiry.Tables[0], "", "", "", "", "", 0, 0, textCommon.Text, false);
                    SetButtonAndColumnState(false);

                    if (dataSet_Inquiry.Tables[0].Rows.Count > 0)
                    {
                        dateOrderDateBegin.DateTime = DataTypeConvert.GetDateTime(dataSet_Inquiry.Tables[0].Rows[0]["OrderHeadDate"]).Date;
                        dateOrderDateEnd.DateTime = dateOrderDateBegin.DateTime.AddDays(7);
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
        private void FrmInquiry_Drag_Shown(object sender, EventArgs e)
        {
            pnlMiddleHead.Height = (this.Height - pnltop.Height) / 2;
            pnlLeftMiddle.Height = gridControlInquiryHead.Height - 42;

            dockPnlLeft.Width = SystemInfo.DragForm_LeftDock_Width;
        }

        #endregion

        #region 右侧询价单模块的相关事件和方法

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
                    MessageHandler.ShowMessageBox("登记日期不能为空，请设置后重新进行查询。");
                    if (dateOrderDateBegin.EditValue == null)
                        dateOrderDateBegin.Focus();
                    else
                        dateOrderDateEnd.Focus();
                    return;
                }
                string orderDateBeginStr = dateOrderDateBegin.DateTime.ToString("yyyy-MM-dd");
                string orderDateEndStr = dateOrderDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                string departmentNoStr = lookUpDepartmentNo.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpDepartmentNo.EditValue) : "";
                string bussinessBaseNoStr = DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) != "全部" ? DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) : "";
                int creatorInt = lookUpCreator.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpCreator.EditValue) : 0;
                string commonStr = textCommon.Text.Trim();

                dataSet_Inquiry.Tables[0].Clear();
                dataSet_Inquiry.Tables[1].Clear();
                dataSet_Inquiry.Tables[2].Clear();
                headFocusedLineNo = 0;
                inqDAO.QueryInquiryHead(dataSet_Inquiry.Tables[0], orderDateBeginStr, orderDateEndStr, bussinessBaseNoStr, departmentNoStr, "", 0, creatorInt, commonStr, false);

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
        private void gridViewInquiryHead_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewInquiryHead.GetFocusedDataRow() != null)
                {
                    if (onlySelectColChangeRowState)
                    {
                        dataSet_Inquiry.Tables[0].AcceptChanges();
                        onlySelectColChangeRowState = false;
                    }
                    else
                    {
                        if (headFocusedLineNo < gridViewInquiryHead.DataRowCount && gridViewInquiryHead.FocusedRowHandle != headFocusedLineNo && gridViewInquiryHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                        {
                            MessageHandler.ShowMessageBox("当前询价单已经修改，请保存后再进行换行。");
                            gridViewInquiryHead.FocusedRowHandle = headFocusedLineNo;
                        }
                        else if (headFocusedLineNo == gridViewInquiryHead.DataRowCount)
                        {

                        }
                        else
                        {
                            if (gridViewInquiryHead.FocusedRowHandle != headFocusedLineNo && gridViewInquiryHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                            else if (gridViewInquiryHead.GetDataRow(headFocusedLineNo).RowState == DataRowState.Unchanged)
                                btnCancel_Click(null, null);
                        }
                    }

                    string piHeadNo = DataTypeConvert.GetString(gridViewInquiryHead.GetFocusedDataRow()["PIHeadNo"]);
                    if (piHeadNo != "")
                    {
                        dataSet_Inquiry.Tables[1].Clear();
                        dataSet_Inquiry.Tables[2].Clear();
                        inqDAO.QueryInquiryList(dataSet_Inquiry.Tables[1], piHeadNo, false);
                        inqDAO.QueryPIPR_Relation(dataSet_Inquiry.Tables[2], piHeadNo, false);
                        //if (queryListAutoId > 0)
                        //{
                        //    for (int i = 0; i < gridViewInquiryList.DataRowCount; i++)
                        //    {
                        //        if (DataTypeConvert.GetInt(gridViewInquiryList.GetDataRow(i)["AutoId"]) == queryListAutoId)
                        //        {
                        //            gridViewInquiryList.FocusedRowHandle = i;
                        //            queryListAutoId = 0;
                        //            break;
                        //        }
                        //    }
                        //}
                    }

                    if (gridViewInquiryHead.FocusedRowHandle >= 0)
                    {
                        headFocusedLineNo = gridViewInquiryHead.FocusedRowHandle;
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
        private void gridViewInquiryList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewInquiryList.GetFocusedDataRow() != null && radioType.SelectedIndex == 1)
                {
                    int autoIdInt = DataTypeConvert.GetInt(gridViewInquiryList.GetFocusedDataRow()["AutoId"]);
                    bindingSource_PIPR.Filter = "PIListId = " + autoIdInt;
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
                switch(radioType.SelectedIndex)
                {
                    case 1:
                        gridViewInquiryList_FocusedRowChanged(null, null);
                        break;
                    default:
                        bindingSource_PIPR.Filter = "";
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
        private void gridViewInquiryHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewInquiryHead_KeyDown(object sender, KeyEventArgs e)
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

                //gridViewPrReqHead.PostEditor();
                gridViewInquiryHead.AddNewRow();
                FocusedHeadView("BussinessBaseNo");

                //dataSet_Order.Tables[1].Clear();
                //gridViewInquiryList.AddNewRow();
                //FocusedListView(false, "CodeFileName", gridViewInquiryList.GetFocusedDataSourceRowIndex());
                //gridViewInquiryList.RefreshData();

                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewInquiryHead.DataRowCount;
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

                if (gridViewInquiryHead.GetFocusedDataRow() == null)
                    return;

                if (btnSave.Text != "保存")
                {
                    ClearHeadGridAllSelect();

                    SetButtonAndColumnState(true);
                    FocusedHeadView("BussinessBaseNo");
                }
                else
                {
                    DataRow headRow = gridViewInquiryHead.GetFocusedDataRow();
                    if (DataTypeConvert.GetString(headRow["BussinessBaseNo"]) == "")
                    {
                        MessageHandler.ShowMessageBox("往来方不能为空，请填写后再进行保存。");
                        FocusedHeadView("BussinessBaseNo");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["DepartmentNo"]) == "")
                    {
                        MessageHandler.ShowMessageBox("部门不能为空，请填写后再进行保存。");
                        FocusedHeadView("DepartmentNo");
                        return;
                    }
                    if (DataTypeConvert.GetString(headRow["Tax"]) == "")
                    {
                        MessageHandler.ShowMessageBox("税率不能为空，请填写后再进行保存。");
                        FocusedHeadView("Tax");
                        return;
                    }
                    //if (DataTypeConvert.GetString(headRow["ProjectNo"]) == "")
                    //{
                    //    MessageHandler.ShowMessageBox(tsmiXmhbnwkbc.Text);// ("项目号不能为空，请填写后再进行保存。");
                    //    FocusedHeadView("ProjectNo");
                    //    return;
                    //}
                    //if (DataTypeConvert.GetString(headRow["StnNo"]) == "")
                    //{
                    //    MessageHandler.ShowMessageBox(tsmiZhbnwkbc.Text);// ("站号不能为空，请填写后再进行保存。");
                    //    FocusedHeadView("StnNo");
                    //    return;
                    //}
                    //if (!commonDAO.StnNoIsContainProjectNo(DataTypeConvert.GetString(headRow["ProjectNo"]), DataTypeConvert.GetString(headRow["StnNo"])))
                    //{
                    //    MessageHandler.ShowMessageBox(tsmiSrdzhbsyxmh.Text);// ("输入的站号不属于项目号，请重新填写后再进行保存。");
                    //    FocusedHeadView("StnNo");
                    //    return;
                    //}

                    for (int i = gridViewInquiryList.DataRowCount - 1; i >= 0; i--)
                    {
                        DataRow listRow = gridViewInquiryList.GetDataRow(i);
                        if (DataTypeConvert.GetString(listRow["CodeFileName"]) == "")
                        {
                            gridViewInquiryList.DeleteRow(i);
                            continue;
                        }
                        if (DataTypeConvert.GetString(listRow["Qty"]) == "")
                        {
                            MessageHandler.ShowMessageBox("数量不能为空，请填写后再进行保存。");
                            FocusedListView(true, "Qty", i);
                            return;
                        }
                        if (DataTypeConvert.GetString(listRow["UnitPrice"]) == "")
                        {
                            MessageHandler.ShowMessageBox("单价不能为空，请填写后再进行保存。");
                            FocusedListView(true, "UnitPrice", i);
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

                    for (int i = 0; i < gridViewPIPR.DataRowCount; i++)
                    {
                        DataRow subRow = gridViewPIPR.GetDataRow(i);
                        if (DataTypeConvert.GetDouble(subRow["PRQty"]) == 0)
                        {
                            MessageHandler.ShowMessageBox("请购数量不能为空或者零，请填写后再进行保存。");
                            FocusedSubListView(true, "PRQty", i);
                            return;
                        }
                    }

                    int ret = inqDAO.SaveInquiry(gridViewInquiryHead.GetFocusedDataRow(), dataSet_Inquiry.Tables[1], dataSet_Inquiry.Tables[2]);
                    switch (ret)
                    {
                        case -1:
                            btnQuery_Click(null, null);
                            break;
                        case 1:
                            dataSet_Inquiry.Tables[1].Clear();
                            dataSet_Inquiry.Tables[2].Clear();
                            string piHeadNo = DataTypeConvert.GetString(gridViewInquiryHead.GetFocusedDataRow()["PIHeadNo"]);
                            inqDAO.QueryInquiryList(dataSet_Inquiry.Tables[1], piHeadNo, false);
                            inqDAO.QueryPIPR_Relation(dataSet_Inquiry.Tables[2], piHeadNo, false);
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

                if (gridViewInquiryHead.GetDataRow(headFocusedLineNo).RowState != DataRowState.Unchanged)
                {
                    if (DataTypeConvert.GetString(gridViewInquiryHead.GetDataRow(headFocusedLineNo)["PIHeadNo"]) == "")
                    {
                        gridViewInquiryHead.DeleteRow(headFocusedLineNo);
                    }
                    else
                    {
                        gridViewInquiryHead.GetFocusedDataRow().RejectChanges();
                    }
                }

                SetButtonAndColumnState(false);

                dataSet_Inquiry.Tables[1].Clear();
                dataSet_Inquiry.Tables[2].Clear();
                if (gridViewInquiryHead.GetFocusedDataRow() != null)
                {
                    string piHeadNo = DataTypeConvert.GetString(gridViewInquiryHead.GetFocusedDataRow()["PIHeadNo"]);
                    inqDAO.QueryInquiryList(dataSet_Inquiry.Tables[1], piHeadNo, false);
                    inqDAO.QueryPIPR_Relation(dataSet_Inquiry.Tables[2], piHeadNo, false);
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

                int count = dataSet_Inquiry.Tables[0].Select("select=1").Length;
                if (count == 0)
                {
                    MessageHandler.ShowMessageBox("请在要操作的记录前面选中。");
                    return;
                }

                //if (!CheckReqState_Multi(false, true, true, true, true, false, ""))
                //    return;

                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确定要删除当前选中的{0}条记录吗？", count)) != DialogResult.Yes)
                {
                    return;
                }
                if (!inqDAO.DeleteInquiry_Multi(dataSet_Inquiry.Tables[0]))
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
        /// 打印预览按钮事件
        /// </summary>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                string piHeadNoStr = "";
                DataRow dr = null;
                DataRow[] drs = dataSet_Inquiry.Tables[0].Select("select=1");
                if (drs.Length > 1)
                {
                    MessageHandler.ShowMessageBox("只能选中一条记录进行打印预览，请重新选择。");
                    return;
                }
                else if (drs.Length == 0)
                {
                    if (gridViewInquiryHead.GetFocusedDataRow() != null)
                    {
                        piHeadNoStr = DataTypeConvert.GetString(gridViewInquiryHead.GetFocusedDataRow()["PIHeadNo"]);
                        dr = gridViewInquiryHead.GetFocusedDataRow();
                    }
                }
                else
                {
                    piHeadNoStr = DataTypeConvert.GetString(drs[0]["PIHeadNo"]);
                    dr = drs[0];
                }

                //if (dr != null && SystemInfo.ApproveAfterPrint)
                //{
                //    if (DataTypeConvert.GetInt(dr["ReqState"]) != 2)
                //    {
                //        MessageHandler.ShowMessageBox("请审批通过后，再进行打印预览操作。");
                //        return;
                //    }
                //}

                inqDAO.PrintHandle(piHeadNoStr, 1);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--打印预览按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 复制询价单事件
        /// </summary>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (gridViewInquiryHead.GetFocusedDataRow() == null)
                {
                    MessageHandler.ShowMessageBox("请选择要复制的询价单。");
                    return;
                }

                string piHeadNo = DataTypeConvert.GetString(gridViewInquiryHead.GetFocusedDataRow()["PIHeadNo"]);
                if (piHeadNo == "")
                {
                    MessageHandler.ShowMessageBox("请选择要复制的询价单。");
                    return;
                }

                DataTable headTable = new DataTable();
                DataTable listTable = new DataTable();
                DataTable piprTable = new DataTable();
                inqDAO.QueryInquiryHead(headTable, "", "", "", "", "", 0, 0, piHeadNo, false);
                inqDAO.QueryInquiryList(listTable, piHeadNo, false);
                inqDAO.QueryPIPR_Relation(piprTable, piHeadNo, false);

                btnNew_Click(null, null);
                FocusedHeadView("BussinessBaseNo");

                gridViewInquiryHead.SetFocusedRowCellValue("DepartmentNo", SystemInfo.user.DepartmentNo);
                gridViewInquiryHead.SetFocusedRowCellValue("Tax", headTable.Rows[0]["Tax"]);
                gridViewInquiryHead.SetFocusedRowCellValue("Creator", SystemInfo.user.AutoId);

                dataTableInquiryList.Rows.Clear();
                dataTablePIPR.Rows.Clear();

                for (int i = 0; i < listTable.Rows.Count; i++)
                {
                    dataTableInquiryList.ImportRow(listTable.Rows[i]);
                    dataTableInquiryList.Rows[i].SetAdded();
                }
                for (int i = 0; i < piprTable.Rows.Count; i++)
                {
                    dataTablePIPR.ImportRow(piprTable.Rows[i]);
                    dataTablePIPR.Rows[i].SetAdded();
                }

                MessageHandler.ShowMessageBox("复制询价单成功，请选择往来方。");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--复制询价单事件错误。", ex);
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
            foreach (DataRow dr in dataSet_Inquiry.Tables[0].Rows)
            {
                dr["Select"] = value;
            }
            onlySelectColChangeRowState = true;
        }

        /// <summary>
        /// 主表设定默认值
        /// </summary>
        private void gridViewInquiryHead_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridViewInquiryHead.SetFocusedRowCellValue("Tax", SystemInfo.OrderList_DefaultTax);
                gridViewInquiryHead.SetFocusedRowCellValue("DepartmentNo", SystemInfo.user.DepartmentNo);
                gridViewInquiryHead.SetFocusedRowCellValue("Tax", SystemInfo.OrderList_DefaultTax);
                gridViewInquiryHead.SetFocusedRowCellValue("Creator", SystemInfo.user.AutoId);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--主表设定默认值错误。", ex);
            }
        }

        /// <summary>
        /// 子表按键事件
        /// </summary>
        private void gridViewInquiryList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!colRemark.OptionsColumn.AllowEdit)
                        return;

                    if (gridViewInquiryList.GetFocusedDataSourceRowIndex() >= gridViewInquiryList.DataRowCount - 1 && gridViewInquiryList.FocusedColumn.Name == "colRemark")
                    {
                        //ListNewRow();
                    }
                    else if (gridViewInquiryList.FocusedColumn.Name == "colRemark")
                    {
                        gridViewInquiryList.FocusedRowHandle = gridViewInquiryList.FocusedRowHandle + 1;
                        FocusedListView(true, "UnitPrice", gridViewInquiryList.GetFocusedDataSourceRowIndex());
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
                if (gridViewInquiryList.GetFocusedDataRow().RowState != DataRowState.Added)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的明细记录吗？") != DialogResult.Yes)
                    {
                        return;
                    }
                }
                int autoIdInt = 0;
                if (gridViewInquiryList.GetFocusedDataRow() != null)
                    autoIdInt = DataTypeConvert.GetInt(gridViewInquiryList.GetFocusedDataRow()["AutoId"]);
                gridViewInquiryList.DeleteRow(gridViewInquiryList.FocusedRowHandle);
                if (autoIdInt > 0)
                {
                    for (int i = gridViewPIPR.DataRowCount - 1; i >= 0; i--)
                    {
                        if (DataTypeConvert.GetInt(gridViewPIPR.GetDataRow(i)["PIListId"]) == autoIdInt)
                        {
                            gridViewPIPR.DeleteRow(i);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除子表中的一行错误。", ex);
            }
        }

        /// <summary>
        /// 删除明细表中的一行
        /// </summary>
        private void repbtnPIPR_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridViewPIPR.GetFocusedDataRow().RowState != DataRowState.Added)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的明细记录吗？") != DialogResult.Yes)
                    {
                        return;
                    }
                }
                int piListIdInt = 0;
                if (gridViewPIPR.GetFocusedDataRow() != null)
                    piListIdInt = DataTypeConvert.GetInt(gridViewPIPR.GetFocusedDataRow()["PIListId"]);
                gridViewPIPR.DeleteRow(gridViewPIPR.FocusedRowHandle);
                if (piListIdInt > 0)
                {
                    UpdateInquiryListQty(piListIdInt);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除明细表中的一行错误。", ex);
            }
        }

        /// <summary>
        /// 主表单元格值变化进行的操作
        /// </summary>
        private void gridViewInquiryHead_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                switch (e.Column.FieldName)
                {
                    case "Tax":
                        for (int i = 0; i < gridViewInquiryList.DataRowCount; i++)
                        {
                            gridViewInquiryList.SetRowCellValue(i, "Tax", DataTypeConvert.GetDouble(gridViewInquiryHead.GetDataRow(e.RowHandle)["Tax"]));
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
        private void gridViewInquiryList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
                    //case "CodeFileName":
                    //    string tmpStr = DataTypeConvert.GetString(gridViewInquiryList.GetDataRow(e.RowHandle)["CodeFileName"]);
                    //    if (tmpStr == "")
                    //    {
                    //        gridViewInquiryList.SetRowCellValue(e.RowHandle, "CodeId", null);
                    //        gridViewInquiryList.SetRowCellValue(e.RowHandle, "CodeName", "");
                    //    }
                    //    else
                    //    {
                    //        DataTable temp = (DataTable)repSearchCodeFileName.DataSource;
                    //        DataRow[] drs = temp.Select(string.Format("CodeFileName='{0}'", tmpStr));
                    //        if (drs.Length > 0)
                    //        {
                    //            gridViewInquiryList.SetRowCellValue(e.RowHandle, "CodeId", DataTypeConvert.GetString(drs[0]["AutoId"]));
                    //            gridViewInquiryList.SetRowCellValue(e.RowHandle, "CodeName", DataTypeConvert.GetString(drs[0]["CodeName"]));
                    //        }
                    //    }
                    //    if (DataTypeConvert.GetString(gridViewInquiryList.GetDataRow(e.RowHandle)["PrReqNo"]) != "")
                    //    {
                    //        gridViewInquiryList.SetRowCellValue(e.RowHandle, "PrReqNo", "");
                    //        gridViewInquiryList.SetRowCellValue(e.RowHandle, "PrListAutoId", 0);
                    //    }
                    //    break;
                    case "Qty":
                    case "UnitPrice":
                    case "Tax":
                        qtyDouble = DataTypeConvert.GetDouble(gridViewInquiryList.GetDataRow(e.RowHandle)["Qty"]);
                        unitDouble = DataTypeConvert.GetDouble(gridViewInquiryList.GetDataRow(e.RowHandle)["UnitPrice"]);
                        amountDouble = Math.Round(qtyDouble * unitDouble, 2, MidpointRounding.AwayFromZero);
                        taxDouble = DataTypeConvert.GetDouble(gridViewInquiryList.GetDataRow(e.RowHandle)["Tax"]);
                        taxAmountDouble = Math.Round(amountDouble * taxDouble, 2, MidpointRounding.AwayFromZero);
                        sumAmountDouble = amountDouble + taxAmountDouble;
                        gridViewInquiryList.SetRowCellValue(e.RowHandle, "Amount", amountDouble);
                        gridViewInquiryList.SetRowCellValue(e.RowHandle, "TaxAmount", taxAmountDouble);
                        gridViewInquiryList.SetRowCellValue(e.RowHandle, "SumAmount", sumAmountDouble);
                        break;
                    case "Amount":
                        if (DataTypeConvert.GetString(gridViewInquiryList.GetDataRow(e.RowHandle)["Qty"]) == "")
                        {
                            MessageHandler.ShowMessageBox("请输入数量。");
                            gridViewInquiryList.FocusedColumn = colQty;
                            modifyLock = false;
                            return;
                        }
                        amountDouble = DataTypeConvert.GetDouble(gridViewInquiryList.GetDataRow(e.RowHandle)["Amount"]);
                        qtyDouble = DataTypeConvert.GetDouble(gridViewInquiryList.GetDataRow(e.RowHandle)["Qty"]);
                        unitDouble = Math.Round(amountDouble / qtyDouble, 2, MidpointRounding.AwayFromZero);
                        taxDouble = DataTypeConvert.GetDouble(gridViewInquiryList.GetDataRow(e.RowHandle)["Tax"]);
                        taxAmountDouble = Math.Round(amountDouble * taxDouble, 2, MidpointRounding.AwayFromZero);
                        sumAmountDouble = amountDouble + taxAmountDouble;
                        gridViewInquiryList.SetRowCellValue(e.RowHandle, "UnitPrice", unitDouble);
                        gridViewInquiryList.SetRowCellValue(e.RowHandle, "TaxAmount", taxAmountDouble);
                        gridViewInquiryList.SetRowCellValue(e.RowHandle, "SumAmount", sumAmountDouble);
                        break;
                    case "SumAmount":
                        if (DataTypeConvert.GetString(gridViewInquiryList.GetDataRow(e.RowHandle)["Qty"]) == "")
                        {
                            MessageHandler.ShowMessageBox("请输入数量。");
                            gridViewInquiryList.FocusedColumn = colQty;
                            modifyLock = false;
                            return;
                        }
                        sumAmountDouble = DataTypeConvert.GetDouble(gridViewInquiryList.GetDataRow(e.RowHandle)["SumAmount"]);
                        qtyDouble = DataTypeConvert.GetDouble(gridViewInquiryList.GetDataRow(e.RowHandle)["Qty"]);
                        taxDouble = DataTypeConvert.GetDouble(gridViewInquiryList.GetDataRow(e.RowHandle)["Tax"]);
                        amountDouble = Math.Round(sumAmountDouble / (1 + taxDouble), 2, MidpointRounding.AwayFromZero);
                        taxAmountDouble = sumAmountDouble - amountDouble;
                        unitDouble = Math.Round(amountDouble / qtyDouble, 2, MidpointRounding.AwayFromZero);
                        gridViewInquiryList.SetRowCellValue(e.RowHandle, "UnitPrice", unitDouble);
                        gridViewInquiryList.SetRowCellValue(e.RowHandle, "TaxAmount", taxAmountDouble);
                        gridViewInquiryList.SetRowCellValue(e.RowHandle, "Amount", amountDouble);
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
        private void gridViewPIPR_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (subLock)
                    return;

                switch (e.Column.FieldName)
                {
                    case "PRQty":
                        double prQty = DataTypeConvert.GetDouble(gridViewPIPR.GetDataRow(e.RowHandle)["PRQty"]);
                        double maxPRQty = DataTypeConvert.GetDouble (gridViewPIPR.GetDataRow(e.RowHandle)["MaxPRQty"]);
                        if (prQty > maxPRQty)
                        {
                            MessageHandler.ShowMessageBox("采购询价单的请购数量不能超过请购单明细的数量。");
                            gridViewPIPR.SetRowCellValue(e.RowHandle, "PRQty", maxPRQty);
                        }

                        int piListIdInt = DataTypeConvert.GetInt(gridViewPIPR.GetDataRow(e.RowHandle)["PIListId"]);
                        UpdateInquiryListQty(piListIdInt);
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
        private void UpdateInquiryListQty(int autoIdInt)
        {
            DataRow[] codeRows = dataSet_Inquiry.Tables[1].Select(string.Format("AutoId = {0}", autoIdInt));
            if (codeRows.Length > 0)
            {
                double sumQty = DataTypeConvert.GetDouble(dataSet_Inquiry.Tables[2].Compute("Sum(PRQty)", string.Format("PIListId = {0}", autoIdInt)));
                if (sumQty == 0)
                {
                    for (int i = 0; i < gridViewInquiryList.DataRowCount; i++)
                    {
                        if (DataTypeConvert.GetInt(gridViewInquiryList.GetDataRow(i)["AutoId"]) == autoIdInt)
                        {
                            gridViewInquiryList.DeleteRow(i);
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
            if (DataTypeConvert.GetBoolean(gridViewInquiryHead.GetFocusedDataRow()["Select"]))
                gridViewInquiryHead.GetFocusedDataRow()["Select"] = false;
            else
                gridViewInquiryHead.GetFocusedDataRow()["Select"] = true;
            onlySelectColChangeRowState = true;
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
            }
            else
            {
                btnNew.Enabled = true;
                btnSave.Text = "修改";
                btnCancel.Enabled = false;
                btnDelete.Enabled = true;
            }

            btnPreview.Enabled = !ret;
            btnCopy.Enabled = !ret;

            colBussinessBaseNo.OptionsColumn.AllowEdit = ret;
            colDepartmentNo.OptionsColumn.AllowEdit = ret;
            colTax.OptionsColumn.AllowEdit = ret;
            //colProjectNo.OptionsColumn.AllowEdit = ret;
            //colStnNo.OptionsColumn.AllowEdit = ret;
            colPIRemark.OptionsColumn.AllowEdit = ret;

            //colCodeFileName.OptionsColumn.AllowEdit = ret;
            colUnitPrice.OptionsColumn.AllowEdit = ret;
            //colQty.OptionsColumn.AllowEdit = ret;
            colAmount.OptionsColumn.AllowEdit = ret;
            colTax1.OptionsColumn.AllowEdit = ret;
            colSumAmount.OptionsColumn.AllowEdit = ret;
            colRemark.OptionsColumn.AllowEdit = ret;

            colPRQty.OptionsColumn.AllowEdit = ret;

            repbtnDelete.Buttons[0].Enabled = ret;
            repbtnPIPR.Buttons[0].Enabled = ret;
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
        /// 聚焦主表当前行的列
        /// </summary>
        private void FocusedHeadView(string colName)
        {
            gridControlInquiryHead.Focus();
            ColumnView headView = (ColumnView)gridControlInquiryHead.FocusedView;
            headView.FocusedColumn = headView.Columns[colName];
            gridViewInquiryHead.FocusedRowHandle = headView.FocusedRowHandle;
        }

        /// <summary>
        /// 聚焦子表当前行的列
        /// </summary>
        private void FocusedListView(bool isFocusedControl, string colName, int lineNo)
        {
            if (isFocusedControl)
                gridControlInquiryList.Focus();
            ColumnView listView = (ColumnView)gridControlInquiryList.FocusedView;
            listView.FocusedColumn = listView.Columns[colName];
            gridViewInquiryList.FocusedRowHandle = lineNo;
        }

        /// <summary>
        /// 聚焦子表当前行的列
        /// </summary>
        private void FocusedSubListView(bool isFocusedControl, string colName, int lineNo)
        {
            if (isFocusedControl)
                gridControlPIPR.Focus();
            ColumnView listView = (ColumnView)gridControlPIPR.FocusedView;
            listView.FocusedColumn = listView.Columns[colName];
            gridViewPIPR.FocusedRowHandle = lineNo;
        }

        /// <summary>
        /// 清楚当前的所有选择
        /// </summary>
        private void ClearHeadGridAllSelect()
        {
            checkAll.Checked = false;
            for (int i = 0; i < dataSet_Inquiry.Tables[0].Rows.Count; i++)
            {
                dataSet_Inquiry.Tables[0].Rows[i]["Select"] = false;
            }
            dataSet_Inquiry.Tables[0].AcceptChanges();
            onlySelectColChangeRowState = false;
        }

        #endregion

        #region 左侧请购订单查询区域的相关事件和方法

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
                inqDAO.QueryPrReqHead(dataSet_PrReq.Tables[0], prReqNoStr, orderDateBeginStr, orderDateEndStr, projectNoStr);
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
                    inqDAO.QueryPrReqList(dataSet_PrReq.Tables[1], DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]));
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
        private void gridControlInquiryList_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<DataRow>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// 拖拽进入到GridControl控件
        /// </summary>
        private void gridControlInquiryList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 实现拖拽请购单事件
        /// </summary>
        private void gridControlInquiryList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                List<DataRow> drs = e.Data.GetData(typeof(List<DataRow>)) as List<DataRow>;
                if (drs != null)
                {
                    PRToPI_DragOrder(sender, drs);
                    ClearAlreadyDragPrReqList();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--" + "实现拖拽请购单事件错误。", ex);
            }
        }

        /// <summary>
        /// 拖拽请购单转成询价单
        /// </summary>
        private void PRToPI_DragOrder(object sender, List<DataRow> drs)
        {
            subLock = true;

            bool isMerge = true;
            bool isMessage = true;
            int dbListMaxAutoIdInt = inqDAO.GetInquiryListMaxAutoId();

            if (btnDelete.Enabled)
            {
                ClearHeadGridAllSelect();
                gridViewInquiryHead.AddNewRow();
                FocusedHeadView("BussinessBaseNo");

                //gridViewInquiryHead.SetFocusedRowCellValue("ProjectNo", headRow["ProjectNo"]);
                //gridViewInquiryHead.SetFocusedRowCellValue("StnNo", headRow["StnNo"]);

                DataRow headRow = gridViewInquiryHead.GetFocusedDataRow();

                dataSet_Inquiry.Tables[1].Clear();
                dataSet_Inquiry.Tables[2].Clear();

                InsertList(headRow, drs, ref isMessage, ref isMerge, dbListMaxAutoIdInt);

                gridViewPIPR.RefreshData();
                gridViewPIPR.UpdateTotalSummary();
                gridViewInquiryList.RefreshData();

                FocusedListView(false, "UnitPrice", gridViewInquiryList.GetFocusedDataSourceRowIndex());
                FocusedSubListView(false, "PRQty", gridViewPIPR.GetFocusedDataSourceRowIndex());
                SetButtonAndColumnState(true);
                headFocusedLineNo = gridViewInquiryHead.DataRowCount;
            }
            else
            {
                DataRow headRow = gridViewInquiryHead.GetFocusedDataRow();

                InsertList(headRow, drs, ref isMessage, ref isMerge, dbListMaxAutoIdInt);

                gridViewInquiryList.FocusedRowHandle = gridViewInquiryList.DataRowCount;
                gridViewPIPR.FocusedRowHandle = gridViewPIPR.DataRowCount;
                FocusedListView(false, "UnitPrice", gridViewInquiryList.GetFocusedDataSourceRowIndex());
                FocusedSubListView(false, "PRQty", gridViewPIPR.GetFocusedDataSourceRowIndex());

                gridViewPIPR.RefreshData();
                gridViewPIPR.UpdateTotalSummary();
                gridViewInquiryList.RefreshData();
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
                if (dataTablePIPR.Select(string.Format("PRListId = {0}", DataTypeConvert.GetInt(dr["AutoId"]))).Length > 0)
                    continue;

                DataRow[] codeRows = dataSet_Inquiry.Tables[1].Select(string.Format("CodeId = {0}", DataTypeConvert.GetInt(dr["CodeId"])));

                if (isMessage && codeRows.Length > 0)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("采购询价单明细中有相同的零件，是否合并成一条记录？") == DialogResult.Yes)
                        isMerge = true;
                    else
                        isMerge = false;
                    isMessage = false;
                }

                int listAutoIdInt = DataTypeConvert.GetInt(dataTableInquiryList.Compute("Max(AutoId)", "")) + 1;
                if (listAutoIdInt < dbListMaxAutoIdInt)
                    listAutoIdInt = dbListMaxAutoIdInt + 1;

                if (codeRows.Length == 0 || !isMerge)
                {
                    gridViewInquiryList.AddNewRow();
                    gridViewInquiryList.SetFocusedRowCellValue("AutoId", listAutoIdInt);
                    gridViewInquiryList.SetFocusedRowCellValue("PIHeadNo", headRow["PIHeadNo"]);
                    gridViewInquiryList.SetFocusedRowCellValue("CodeId", dr["CodeId"]);
                    gridViewInquiryList.SetFocusedRowCellValue("CodeFileName", dr["CodeFileName"]);
                    gridViewInquiryList.SetFocusedRowCellValue("CodeName", dr["CodeName"]);
                    gridViewInquiryList.SetFocusedRowCellValue("Tax", headRow["Tax"]);
                }

                gridViewPIPR.AddNewRow();

                gridViewPIPR.SetFocusedRowCellValue("PRListId", dr["AutoId"]);
                gridViewPIPR.SetFocusedRowCellValue("CodeId", dr["CodeId"]);
                gridViewPIPR.SetFocusedRowCellValue("PRQty", dr["Qty"]);
                gridViewPIPR.SetFocusedRowCellValue("PrReqNo", dr["PrReqNo"]);
                gridViewPIPR.SetFocusedRowCellValue("ProjectNo", dr["ProjectNo"]);
                gridViewPIPR.SetFocusedRowCellValue("StnNo", dr["StnNo"]);
                gridViewPIPR.SetFocusedRowCellValue("MaxPRQty", dr["Qty"]);

                if (codeRows.Length == 0 || !isMerge)
                {
                    gridViewPIPR.SetFocusedRowCellValue("PIListId", gridViewInquiryList.GetFocusedDataRow()["AutoId"]);
                    gridViewInquiryList.SetFocusedRowCellValue("Qty", DataTypeConvert.GetDouble(gridViewInquiryList.GetFocusedDataRow()["Qty"]) + DataTypeConvert.GetDouble(dr["Qty"]));
                }
                else
                {
                    gridViewPIPR.SetFocusedRowCellValue("PIListId", codeRows[0]["AutoId"]);
                    codeRows[0]["Qty"] = DataTypeConvert.GetDouble(codeRows[0]["Qty"]) + DataTypeConvert.GetDouble(dr["Qty"]);
                }

                gridViewInquiryList.RefreshData();
            }
        }

        #endregion

        /// <summary>
        /// 清空已经拖拽的请购单明细 
        /// </summary>
        private void ClearAlreadyDragPrReqList()
        {
            gridViewPrReqList.ClearSelection();
            gridViewPrHeadList.ClearSelection();
            //for (int i = dataSet_PrReq.Tables[1].Rows.Count - 1; i >= 0; i--)
            //{
            //    if (dataSet_Inquiry.Tables[1].Select(string.Format("PrListAutoId={0}", DataTypeConvert.GetString(dataSet_PrReq.Tables[1].Rows[i]["AutoId"]))).Length > 0)
            //        dataSet_PrReq.Tables[1].Rows.RemoveAt(i);
            //}
        }

        #endregion

        #region 左侧请购明细查询区域的相关事件和方法

        /// <summary>
        /// 查询请购明细单事件
        /// </summary>
        private void btnPrReqListQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (dateReqDateBegin2.EditValue == null || dateReqDateEnd2.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("请购日期不能为空，请设置后重新进行查询。");
                    if (dateReqDateBegin2.EditValue == null)
                        dateReqDateBegin2.Focus();
                    else
                        dateReqDateEnd2.Focus();
                    return;
                }
                
                string orderDateBeginStr = dateReqDateBegin2.DateTime.ToString("yyyy-MM-dd");
                string orderDateEndStr = dateReqDateEnd2.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                int codeIdInt = DataTypeConvert.GetInt(searchLookUpCodeFileName.EditValue);
                string commonStr = textReqCommon.Text.Trim();

                dataSet_PrReq.Tables[2].Clear();
                inqDAO.QueryPrHeadList(dataSet_PrReq.Tables[2], orderDateBeginStr, orderDateEndStr, codeIdInt, commonStr);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询请购单事件错误。", ex);
            }
        }

        #endregion

    }
}
