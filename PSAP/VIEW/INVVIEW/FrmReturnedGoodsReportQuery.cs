using PSAP.DAO.BSDAO;
using PSAP.DAO.INVDAO;
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
    public partial class FrmReturnedGoodsReportQuery : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmReturnedGoodsReportDAO rgrDAO = new FrmReturnedGoodsReportDAO();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmReturnedGoodsReportQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmReturnedGoodsReportQuery_Load(object sender, EventArgs e)
        {
            try
            {
                ControlCommonInit ctlInit = new ControlCommonInit();

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateRGRDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateRGRDateEnd.DateTime = nowDate.Date;

                DataTable departmentTable_t = commonDAO.QueryDepartment(true);
                DataTable bussInfoTable_t = commonDAO.QueryBussinessBaseInfo(true);
                DataTable repertoryTable_t = commonDAO.QueryRepertoryInfo(true);

                lookUpReqDep.Properties.DataSource = departmentTable_t;
                lookUpReqDep.ItemIndex = 0;
                searchLookUpBussinessBaseNo.Properties.DataSource = bussInfoTable_t;
                searchLookUpBussinessBaseNo.Text = "全部";
                lookUpRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpRepertoryId.ItemIndex = 0;
                //SearchLocationId.Properties.DataSource = locationTable_t;
                //SearchLocationId.EditValue = 0;
                ctlInit.SearchLookUpEdit_RepertoryLocationInfo(SearchLocationId, true);
                SearchLocationId.EditValue = 0;
                ctlInit.ComboBoxEdit_WarehouseState(comboBoxWarehouseState);
                comboBoxWarehouseState.SelectedIndex = 0;
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;

                //repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                //repSearchBussinessBaseNo.DataSource = commonDAO.QueryBussinessBaseInfo(false);
                //repLookUpRepertoryId.DataSource = commonDAO.QueryRepertoryInfo(false);
                //repLookUpRepertoryLocationId.DataSource = commonDAO.QueryRepertoryLocationInfo(false);
                repLookUpReqDep.DataSource = departmentTable_t;
                repSearchBussinessBaseNo.DataSource = bussInfoTable_t;
                repLookUpRepertoryId.DataSource = repertoryTable_t;
                repLookUpRepertoryLocationId.DataSource = SearchLocationId.Properties.DataSource;
                repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);
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
        /// 确定行号
        /// </summary>
        private void gridViewRGRHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
                string commonStr = textCommon.Text.Trim();

                dataSet_RGR.Tables[0].Rows.Clear();
                string querySqlStr = rgrDAO.QueryReturnedGoodsReportHead_SQL(rgrDateBeginStr, rgrDateEndStr, reqDepStr, bussinessBaseNoStr, repertoryIdInt, locationIdInt, warehouseStateInt, creatorInt, -1, commonStr, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);

                gridBottomOrderHead.QueryGridData(ref dataSet_RGR, "RGRHead", querySqlStr, countSqlStr, true);
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

                //FileHandler.SaveDevGridControlExportToExcel(gridViewRGRHead);
                if (gridBottomOrderHead.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewRGRHead);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_RGR.Tables[0], lastQuerySqlStr, gridViewRGRHead);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewRGRHead_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string formNameStr = "FrmReturnedGoodsReport";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string rgrHeadNoStr = DataTypeConvert.GetString(gridViewRGRHead.GetFocusedDataRow()["ReturnedGoodsReportNo"]);
                    FrmReturnedGoodsReport.queryRGRHeadNo = rgrHeadNoStr;
                    //FrmWarehouseWarrant_Drag.queryListAutoId = 0;
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
