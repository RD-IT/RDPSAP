using DevExpress.XtraGrid.Views.Base;
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
    public partial class FrmOrderList_Overplus : DockContent
    {
        FrmOrderDAO orderDAO = new FrmOrderDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmOrderList_Overplus()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(f);
            PSAP.BLL.BSBLL.BSBLL.language(this);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmOrderList_Overplus_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateOrderDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateOrderDateEnd.DateTime = nowDate.Date;
                datePlanDateBegin.DateTime = nowDate.Date;
                datePlanDateEnd.DateTime = nowDate.Date.AddDays(SystemInfo.OrderQueryDate_DateIntervalDays);
                checkPlanDate.Checked = false;

                DataTable departmentTable_t = commonDAO.QueryDepartment(true);
                DataTable bussInfoTable_t = commonDAO.QueryBussinessBaseInfo(true);
                DataTable purCateTable_t = commonDAO.QueryPurCategory(true);

                lookUpReqDep.Properties.DataSource = departmentTable_t;
                lookUpReqDep.ItemIndex = 0;
                searchLookUpBussinessBaseNo.Properties.DataSource = bussInfoTable_t;
                searchLookUpBussinessBaseNo.Text = "全部";
                lookUpPurCategory.Properties.DataSource = purCateTable_t;
                lookUpPurCategory.ItemIndex = 0;
                //searchLookUpProjectNo.Properties.DataSource = projectTable_t;
                //searchLookUpProjectNo.Text = "全部";
                //searchLookUpCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(true);
                //searchLookUpCodeFileName.EditValue = 0;

                ControlCommonInit ctlInit = new ControlCommonInit();
                ctlInit.SearchLookUpEdit_PartsCode(searchLookUpCodeFileName, true);
                searchLookUpCodeFileName.EditValue = 0;
                ctlInit.SearchLookUpEdit_ProjectList(searchLookUpProjectNo, true);
                searchLookUpProjectNo.Text = "全部";
                ctlInit.ComboBoxEdit_OrderState_Submit(comboBoxReqState);
                comboBoxReqState.SelectedIndex = 0;

                //repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                //repSearchBussinessBaseNo.DataSource = commonDAO.QueryBussinessBaseInfo(false);
                //repLookUpPurCategory.DataSource = commonDAO.QueryPurCategory(false);
                //repSearchProjectNo.DataSource = commonDAO.QueryProjectList(false);
                repLookUpReqDep.DataSource = departmentTable_t;
                repSearchBussinessBaseNo.DataSource = bussInfoTable_t;
                repLookUpPurCategory.DataSource = purCateTable_t;
                repSearchProjectNo.DataSource = searchLookUpProjectNo.Properties.DataSource;

                if (SystemInfo.DisableProjectNo)
                {
                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    colProjectNo.Visible = false;
                    colStnNo.Visible = false;
                }

                gridBottomOrderHead.pageRowCount = SystemInfo.OrderQueryGrid_PageRowCount;

                btnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiCtjzsjcw.Text , ex);
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
        /// 设定列表显示信息
        /// </summary>
        private void gridViewOrderList_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "ReqState")
            {
                e.DisplayText = CommonHandler.Get_OrderState_Desc(e.Value.ToString());
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewOrderList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewOrderList_KeyDown(object sender, KeyEventArgs e)
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

                if (dateOrderDateBegin.EditValue == null || dateOrderDateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox(tsmiDgrqbnwk.Text);// ("订购日期不能为空，请设置后重新进行查询。");
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
                        MessageHandler.ShowMessageBox(tsmiJhdhribnwk.Text );// ("计划到货日期不能为空，请设置后重新进行查询。");
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
                string projectNoStr = searchLookUpProjectNo.Text != "全部" ? DataTypeConvert.GetString(searchLookUpProjectNo.EditValue) : "";
                //string codeFileNameStr = searchLookUpCodeFileName.Text != "全部" ? DataTypeConvert.GetString(searchLookUpCodeFileName.EditValue) : "";
                int codeIdInt = DataTypeConvert.GetInt(searchLookUpCodeFileName.EditValue);
                string commonStr = textCommon.Text.Trim();
                dataSet_Order.Tables[0].Clear();

                string querySqlStr = orderDAO.Query_OrderList_Overplus_SQL(orderDateBeginStr, orderDateEndStr, planDateBeginStr, planDateEndStr, reqDepStr, purCategoryStr, bussinessBaseNoStr, reqStateInt, projectNoStr, codeIdInt, checkOverplus.Checked, commonStr);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);
                gridBottomOrderHead.QueryGridData(ref dataSet_Order, "OrderList", querySqlStr, countSqlStr, true);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--查询按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiCxansjcw.Text , ex);
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

                //FileHandler.SaveDevGridControlExportToExcel(gridViewOrderList);
                if (gridBottomOrderHead.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewOrderList);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_Order.Tables[0], lastQuerySqlStr, gridViewOrderList);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiCxjgcwexcelcw.Text , ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewOrderList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string formNameStr = "FrmOrder_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string orderHeadNoStr = DataTypeConvert.GetString(gridViewOrderList.GetFocusedDataRow()["OrderHeadNo"]);
                    int autoIdInt = DataTypeConvert.GetInt(gridViewOrderList.GetFocusedDataRow()["AutoId"]);
                    FrmOrder_Drag.queryOrderHeadNo = orderHeadNoStr;
                    FrmOrder_Drag.queryListAutoId = autoIdInt;
                    ViewHandler.ShowRightWindow(formNameStr);
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--双击查询明细错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiSjcxmxcw.Text , ex);
            }
        }

    }
}
