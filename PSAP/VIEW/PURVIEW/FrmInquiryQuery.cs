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
    public partial class FrmInquiryQuery : DockContent
    {
        FrmInquiryDAO inqDAO = new FrmInquiryDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmInquiryQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmInquiryQuery_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateOrderDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateOrderDateEnd.DateTime = nowDate.Date;

                DataTable bussInfoTable_t = commonDAO.QueryBussinessBaseInfo(true);
                DataTable departmentTable_t = commonDAO.QueryDepartment(true);

                lookUpDepartmentNo.Properties.DataSource = departmentTable_t;
                lookUpDepartmentNo.ItemIndex = 0;
                searchLookUpBussinessBaseNo.Properties.DataSource = bussInfoTable_t;
                searchLookUpBussinessBaseNo.Text = "全部";

                ControlCommonInit ctlInit = new ControlCommonInit();
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;
                ctlInit.SearchLookUpEdit_PartsCode(searchLookUpCodeFileName, true);
                searchLookUpCodeFileName.EditValue = 0;


                repSearchBussinessBaseNo.DataSource = bussInfoTable_t;
                repLookUpDepartmentNo.DataSource = departmentTable_t;
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
                int creatorInt = DataTypeConvert.GetInt(searchLookUpCreator.EditValue);
                int codeIdInt = DataTypeConvert.GetInt(searchLookUpCodeFileName.EditValue);
                string commonStr = textCommon.Text.Trim();

                dataSet_Inquiry.Tables[0].Clear();

                string querySqlStr = inqDAO.QueryInquiryHead_SQL(orderDateBeginStr, orderDateEndStr, bussinessBaseNoStr, departmentNoStr, "", codeIdInt, creatorInt, commonStr, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);
                gridBottomOrderHead.QueryGridData(ref dataSet_Inquiry, "InquiryHead", querySqlStr, countSqlStr, true);
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

                //FileHandler.SaveDevGridControlExportToExcel(gridViewPrReqHead);
                if (gridBottomOrderHead.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewInquiryHead);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_Inquiry.Tables[0], lastQuerySqlStr, gridViewInquiryHead);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewInquiryHead_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string formNameStr = "FrmInquiry_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string piHeadNoStr = DataTypeConvert.GetString(gridViewInquiryHead.GetFocusedDataRow()["PIHeadNo"]);
                    FrmInquiry_Drag.queryPIHeadNo = piHeadNoStr;
                    ViewHandler.ShowRightWindow(formNameStr);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击查询明细错误。", ex);
            }
        }

    }
}
