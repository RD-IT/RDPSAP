﻿using PSAP.DAO.BSDAO;
using PSAP.DAO.SADAO;
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
    public partial class FrmSettleAccountsQuery : DockContent
    {
        #region 私有变量

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmSettleAccountsDAO saDAO = new FrmSettleAccountsDAO();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        #endregion

        #region 构造方法

        public FrmSettleAccountsQuery()
        {
            InitializeComponent();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmSettleAccountsQuery_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateSADateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateSADateEnd.DateTime = nowDate.Date;

                DataTable bussInfoTable_t = commonDAO.QueryBussinessBaseInfo(true);
                DataTable departmentTable_t = commonDAO.QueryDepartment(true);                

                searchLookUpBussinessBaseNo.Properties.DataSource = bussInfoTable_t;
                searchLookUpBussinessBaseNo.Text = "全部";
                lookUpReqDep.Properties.DataSource = departmentTable_t;
                lookUpReqDep.ItemIndex = 0;

                ControlCommonInit ctlInit = new ControlCommonInit();
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;

                //repSearchBussinessBaseNo.DataSource = commonDAO.QueryBussinessBaseInfo(false);
                //repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                repSearchBussinessBaseNo.DataSource = bussInfoTable_t;
                repLookUpReqDep.DataSource = departmentTable_t;
                repLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;

                gridBottomOrderHead.pageRowCount = SystemInfo.OrderQueryGrid_PageRowCount;

                btnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewQuotationBaseInfo_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewSettleAccountsHead_KeyDown(object sender, KeyEventArgs e)
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

                if (dateSADateBegin.EditValue == null || dateSADateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("结账日期不能为空，请设置后重新进行查询。");
                    if (dateSADateBegin.EditValue == null)
                        dateSADateBegin.Focus();
                    else
                        dateSADateEnd.Focus();
                    return;
                }
                string saDateBeginStr = dateSADateBegin.DateTime.ToString("yyyy-MM-dd");
                string saDateEndStr = dateSADateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                string bussinessBaseNoStr = DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) != "全部" ? DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) : "";
                string reqDepStr = lookUpReqDep.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpReqDep.EditValue) : "";
                int creatorInt = DataTypeConvert.GetInt(searchLookUpCreator.EditValue);
                string commonStr = textCommon.Text.Trim();

                dataSet_SettleAccounts.Tables[0].Clear();

                string querySqlStr = saDAO.QuerySettleAccountsHead_SQL(saDateBeginStr, saDateEndStr, reqDepStr, bussinessBaseNoStr, creatorInt, commonStr, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);

                gridBottomOrderHead.QueryGridData(ref dataSet_SettleAccounts, "SettleAccountsHead", querySqlStr, countSqlStr, true);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询按钮事件错误。", ex);
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

                //FileHandler.SaveDevGridControlExportToExcel(gridViewSettleAccountsHead);
                if (gridBottomOrderHead.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewSettleAccountsHead);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_SettleAccounts.Tables[0], lastQuerySqlStr, gridViewSettleAccountsHead);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewSettleAccountsHead_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string formNameStr = "FrmSettleAccounts_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string settleAccountNoStr = DataTypeConvert.GetString(gridViewSettleAccountsHead.GetFocusedDataRow()["SettleAccountNo"]);
                    FrmSettleAccounts_Drag.querySettleAccountNo = settleAccountNoStr;
                    //FrmWarehouseWarrant_Drag.queryListAutoId = 0;
                    ViewHandler.ShowRightWindow(formNameStr);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击查询明细错误。", ex);
            }
        }

        #endregion
    }
}
