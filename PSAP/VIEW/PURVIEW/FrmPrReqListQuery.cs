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
    public partial class FrmPrReqListQuery : DockContent
    {
        FrmPrReqDAO prReqDAO = new FrmPrReqDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmPrReqListQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPrReqListQuery_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateRequirementDateBegin.DateTime = nowDate.Date;
                dateRequirementDateEnd.DateTime = nowDate.Date.AddDays(SystemInfo.OrderQueryDate_DateIntervalDays);
                dateReqDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateReqDateEnd.DateTime = nowDate.Date;
                checkReqDate.Checked = false;

                DataTable departmentTable_t = commonDAO.QueryDepartment(true);
                DataTable purCateTable_t = commonDAO.QueryPurCategory(true);

                lookUpReqDep.Properties.DataSource = departmentTable_t;
                lookUpReqDep.ItemIndex = 0;
                lookUpPurCategory.Properties.DataSource = purCateTable_t;
                lookUpPurCategory.ItemIndex = 0;
                comboBoxReqState.SelectedIndex = 0;
                searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(true);
                searchLookUpProjectNo.Text = "全部";
                searchLookUpCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(true);
                searchLookUpCodeFileName.EditValue = 0;

                //repItemLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                //repItemLookUpPurCategory.DataSource = commonDAO.QueryPurCategory(false);
                repItemLookUpReqDep.DataSource = departmentTable_t;
                repItemLookUpPurCategory.DataSource = purCateTable_t;

                if (SystemInfo.DisableProjectNo)
                {
                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    colProjectNo.Visible = false;
                    colStnNo.Visible = false;
                }

                gridBottomPrReq.pageRowCount = SystemInfo.OrderQueryGrid_PageRowCount;

                btnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 选择请购日期
        /// </summary>
        private void checkReqDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkReqDate.Checked)
            {
                dateReqDateBegin.Enabled = true;
                dateReqDateEnd.Enabled = true;
            }
            else
            {
                dateReqDateBegin.Enabled = false;
                dateReqDateEnd.Enabled = false;
            }
        }

        /// <summary>
        /// 设定列表显示信息
        /// </summary>
        private void gridViewPrReqHead_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "ReqState")
            {
                e.DisplayText = CommonHandler.Get_OrderState_Desc(e.Value.ToString());
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
        /// 查询按钮事件
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                if (dateRequirementDateBegin.EditValue == null || dateRequirementDateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("需求日期不能为空，请设置后重新进行查询。");
                    if (dateRequirementDateBegin.EditValue == null)
                        dateRequirementDateBegin.Focus();
                    else
                        dateRequirementDateEnd.Focus();
                    return;
                }
                string requirementDateBeginStr = dateRequirementDateBegin.DateTime.ToString("yyyy-MM-dd");
                string requirementDateEndStr = dateRequirementDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                string reqDateBeginStr = "";
                string reqDateEndStr = "";
                if (checkReqDate.Checked)
                {
                    if (dateReqDateBegin.EditValue == null || dateReqDateEnd.EditValue == null)
                    {
                        MessageHandler.ShowMessageBox("请购日期不能为空，请设置后重新进行查询。");
                        if (dateReqDateBegin.EditValue == null)
                            dateReqDateBegin.Focus();
                        else
                            dateReqDateEnd.Focus();
                        return;
                    }
                    reqDateBeginStr = dateReqDateBegin.DateTime.ToString("yyyy-MM-dd");
                    reqDateEndStr = dateReqDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                }

                string reqDepStr = lookUpReqDep.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpReqDep.EditValue) : "";
                string purCategoryStr = lookUpPurCategory.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpPurCategory.EditValue) : "";
                int reqStateInt = CommonHandler.Get_OrderState_No(comboBoxReqState.Text);

                string projectNoStr = searchLookUpProjectNo.Text != "全部" ? DataTypeConvert.GetString(searchLookUpProjectNo.EditValue) : "";
                int codeIdInt = DataTypeConvert.GetInt(searchLookUpCodeFileName.EditValue);
                string commonStr = textCommon.Text.Trim();
                dataSet_PrReq.Tables[0].Clear();

                string querySqlStr = prReqDAO.QueryPrReqList_Head_SQL(requirementDateBeginStr, requirementDateEndStr, reqDateBeginStr, reqDateEndStr, reqDepStr, purCategoryStr,  reqStateInt, projectNoStr, codeIdInt, commonStr);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);
                gridBottomPrReq.QueryGridData(ref dataSet_PrReq, "PrReqHead", querySqlStr, countSqlStr, true);
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

                if (gridBottomPrReq.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewPrReqHead);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_PrReq.Tables[0], lastQuerySqlStr, gridViewPrReqHead);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewPrReqHead_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string prReqNoStr = DataTypeConvert.GetString(gridViewPrReqHead.GetFocusedDataRow()["PrReqNo"]);
                    FrmPrReq.queryPrReqNo = prReqNoStr;
                    FrmPrReq.queryListAutoId = 0;
                    ViewHandler.ShowRightWindow("FrmPrReq");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击查询明细错误。", ex);
            }
        }
    }
}
