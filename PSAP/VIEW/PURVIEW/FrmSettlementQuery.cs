﻿using PSAP.DAO.BSDAO;
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
    public partial class FrmSettlementQuery : DockContent
    {
        FrmSettlementDAO setDAO = new FrmSettlementDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        /// <summary>
        /// 入库单明细的AutoId
        /// </summary>
        public static int wwListAutoId = 0;

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmSettlementQuery()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(this);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmSettlementQuery_Load(object sender, EventArgs e)
        {
            try
            {
                ControlCommonInit ctlInit = new ControlCommonInit();

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateSettlementDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateSettlementDateEnd.DateTime = nowDate.Date;
                datePayDateBegin.DateTime = nowDate.Date;
                datePayDateEnd.DateTime = nowDate.Date.AddDays(SystemInfo.OrderQueryDate_DateIntervalDays);
                checkPayDate.Checked = false;

                searchLookUpBussinessBaseNo.Properties.DataSource = commonDAO.QueryBussinessBaseInfo(true);
                searchLookUpBussinessBaseNo.Text = "全部";
                lookUpReqDep.Properties.DataSource = commonDAO.QueryDepartment(true);
                lookUpReqDep.ItemIndex = 0;
                ctlInit.ComboBoxEdit_WarehouseState(comboBoxWarehouseState, true);
                comboBoxWarehouseState.SelectedIndex = 0;                
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;

                repSearchBussinessBaseNo.DataSource = commonDAO.QueryBussinessBaseInfo(false);
                repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);
                repLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;

                gridBottomOrderHead.pageRowCount = SystemInfo.OrderQueryGrid_PageRowCount;

                if (textCommon.Text == "")
                {
                    btnQuery_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiCtjz.Text, ex);
            }
        }

        /// <summary>
        /// 窗体激活事件
        /// </summary>
        private void FrmSettlementQuery_Activated(object sender, EventArgs e)
        {
            try
            {
                if (wwListAutoId != 0)
                {
                    spinwwListAutoId.Value = wwListAutoId;
                    wwListAutoId = 0;
                    checkwwListAutoId.Checked = true;

                    DateTime nowDate = BaseSQL.GetServerDateTime();
                    dateSettlementDateBegin.DateTime = nowDate.AddMonths(-6);
                    dateSettlementDateEnd.DateTime = nowDate.AddMonths(6);
                    searchLookUpBussinessBaseNo.Text = "全部";
                    lookUpReqDep.ItemIndex = 0;
                    comboBoxWarehouseState.SelectedIndex = 0;
                    searchLookUpCreator.Text = "全部";
                    checkPayDate.Checked = false;
                    textCommon.Text = "";

                    btnQuery_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体激活事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiCtjh.Text, ex);
            }
        }

        /// <summary>
        /// 选择付款日期
        /// </summary>
        private void checkPayDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPayDate.Checked)
            {
                datePayDateBegin.Enabled = true;
                datePayDateEnd.Enabled = true;
            }
            else
            {
                datePayDateBegin.Enabled = false;
                datePayDateEnd.Enabled = false;
            }
        }

        /// <summary>
        /// 选择入库单明细ID
        /// </summary>
        private void checkwwListAutoId_CheckedChanged(object sender, EventArgs e)
        {
            if (checkwwListAutoId.Checked)
            {
                spinwwListAutoId.Enabled = true;
            }
            else
            {
                spinwwListAutoId.Enabled = false;
            }
        }

        /// <summary>
        /// 设定列表显示信息
        /// </summary>
        private void gridViewSettlementHead_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "WarehouseState")
            {
                e.DisplayText = CommonHandler.Get_WarehouseState_Desc(e.Value.ToString());
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewSettlementHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewSettlementHead_KeyDown(object sender, KeyEventArgs e)
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
        /// 查询按钮事件
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (dateSettlementDateBegin.EditValue == null || dateSettlementDateEnd.EditValue == null)
                {
                    //MessageHandler.ShowMessageBox("结账日期不能为空，请设置后重新进行查询。");
                    MessageHandler.ShowMessageBox(tsmiJzrqbnwk.Text);
                    if (dateSettlementDateBegin.EditValue == null)
                        dateSettlementDateBegin.Focus();
                    else
                        dateSettlementDateEnd.Focus();
                    return;
                }
                string orderDateBeginStr = dateSettlementDateBegin.DateTime.ToString("yyyy-MM-dd");
                string orderDateEndStr = dateSettlementDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                string payDateBeginStr = "";
                string payDateEndStr = "";
                if (checkPayDate.Checked)
                {
                    if (datePayDateBegin.EditValue == null || datePayDateEnd.EditValue == null)
                    {
                        //MessageHandler.ShowMessageBox("付款日期不能为空，请设置后重新进行查询。");
                        MessageHandler.ShowMessageBox(tsmiFkrqbnwk.Text);
                        if (datePayDateBegin.EditValue == null)
                            datePayDateBegin.Focus();
                        else
                            datePayDateEnd.Focus();
                        return;
                    }
                    payDateBeginStr = datePayDateBegin.DateTime.ToString("yyyy-MM-dd");
                    payDateEndStr = datePayDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                }

                string bussinessBaseNoStr = DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) != "全部" ? DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) : "";
                string reqDepStr = lookUpReqDep.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpReqDep.EditValue) : "";
                int wStateInt = CommonHandler.Get_WarehouseState_No(comboBoxWarehouseState.Text);
                int creatorInt = DataTypeConvert.GetInt(searchLookUpCreator.EditValue);
                string commonStr = textCommon.Text.Trim();
                int wwListAutoIdInt = (checkwwListAutoId.Checked && spinwwListAutoId.Value > 0) ? DataTypeConvert.GetInt(spinwwListAutoId.Value) : 0;
                dataSet_Settlement.Tables[0].Clear();

                string querySqlStr = setDAO.QuerySettlementHead_SQL(orderDateBeginStr, orderDateEndStr, payDateBeginStr, payDateEndStr, reqDepStr, bussinessBaseNoStr, wStateInt, creatorInt, -1, commonStr, wwListAutoIdInt, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);

                gridBottomOrderHead.QueryGridData(ref dataSet_Settlement, "SettlementHead", querySqlStr, countSqlStr, true);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--查询按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiCxan.Text, ex);
            }
        }

        /// <summary>
        /// 查询结果存为Excel
        /// </summary>
        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                //FileHandler.SaveDevGridControlExportToExcel(gridViewSettlementHead);
                if (gridBottomOrderHead.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewSettlementHead);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_Settlement.Tables[0], lastQuerySqlStr, gridViewSettlementHead);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiCxjgcw.Text, ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewSettlementHead_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string formNameStr = "FrmSettlement_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string settlementNoStr = DataTypeConvert.GetString(gridViewSettlementHead.GetFocusedDataRow()["SettlementNo"]);
                    FrmSettlement_Drag.querySettlementNo = settlementNoStr;
                    //FrmWarehouseWarrant_Drag.queryListAutoId = 0;
                    ViewHandler.ShowRightWindow(formNameStr);
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--双击查询明细错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiSjcx.Text, ex);
            }
        }
    }
}
