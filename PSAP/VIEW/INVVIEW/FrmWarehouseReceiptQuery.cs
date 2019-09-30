using DevExpress.XtraGrid.Views.Base;
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
    public partial class FrmWarehouseReceiptQuery : DockContent
    {
        FrmWarehouseReceiptDAO wrDAO = new FrmWarehouseReceiptDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();
            static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmWarehouseReceiptQuery()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(f);
            PSAP.BLL.BSBLL.BSBLL.language(this);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWarehouseReceiptQuery_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateWRDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateWRDateEnd.DateTime = nowDate.Date;

                DataTable departmentTable_t = commonDAO.QueryDepartment(true);
                DataTable repertoryTable_t = commonDAO.QueryRepertoryInfo(true);
                DataTable locationTable_t = commonDAO.QueryRepertoryLocationInfo(true);
                DataTable wrTypeTable_t = wrDAO.QueryWarehouseReceiptType(true);
                DataTable manuInfoTable_t = commonDAO.QueryManufactureInfo(true);

                lookUpReqDep.Properties.DataSource = departmentTable_t;
                lookUpReqDep.ItemIndex = 0;
                lookUpRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpRepertoryId.ItemIndex = 0;
                SearchLocationId.Properties.DataSource = locationTable_t;
                SearchLocationId.EditValue = 0;
                lookUpWarehouseReceiptTypeNo.Properties.DataSource = wrTypeTable_t;
                lookUpWarehouseReceiptTypeNo.ItemIndex = 0;
                lookUpManufactureNo.Properties.DataSource = manuInfoTable_t;
                lookUpManufactureNo.ItemIndex = 0;
                comboBoxWarehouseState.SelectedIndex = 0;
                lookUpPrepared.Properties.DataSource = commonDAO.QueryUserInfo(true);
                lookUpPrepared.EditValue = SystemInfo.user.EmpName;


                //repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                //repLookUpRepertoryId.DataSource = commonDAO.QueryRepertoryInfo(false);
                //repLookUpRepertoryLocationId.DataSource = commonDAO.QueryRepertoryLocationInfo(false);
                //repLookUpWRTypeNo.DataSource = wrDAO.QueryWarehouseReceiptType(false);
                //repLookUpManufactureNo.DataSource = wrDAO.QueryManufactureInfo(false);
                repLookUpReqDep.DataSource = departmentTable_t;
                repLookUpRepertoryId.DataSource = repertoryTable_t;
                repLookUpRepertoryLocationId.DataSource = locationTable_t;
                repLookUpWRTypeNo.DataSource = wrTypeTable_t;
                repLookUpManufactureNo.DataSource = manuInfoTable_t;
                repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);

                gridBottomOrderHead.pageRowCount = SystemInfo.OrderQueryGrid_PageRowCount;

                btnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiCtjzsjcw.Text, ex);
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
        /// 确定行号
        /// </summary>
        private void gridViewWRHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
                    MessageHandler.ShowMessageBox(tsmiCkrqbnwkcx.Text );// ("出库日期不能为空，请设置后重新进行查询。");
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
                string empNameStr = lookUpPrepared.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpPrepared.EditValue) : "";
                string commonStr = textCommon.Text.Trim();

                dataSet_WR.Tables[0].Rows.Clear();
                string querySqlStr = wrDAO.QueryWarehouseReceiptHead_SQL(wrDateBeginStr, wrDateEndStr, reqDepStr, repertoryIdInt, locationIdInt, wrTypeNoStr, manufactureNoStr, warehouseStateInt, empNameStr, -1, commonStr, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);

                gridBottomOrderHead.QueryGridData(ref dataSet_WR, "WRHead", querySqlStr, countSqlStr, true);
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

                //FileHandler.SaveDevGridControlExportToExcel(gridViewWRHead);
                if (gridBottomOrderHead.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewWRHead);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_WR.Tables[0], lastQuerySqlStr, gridViewWRHead);
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
        private void gridViewWRHead_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string wrHeadNoStr = DataTypeConvert.GetString(gridViewWRHead.GetFocusedDataRow()["WarehouseReceipt"]);
                    FrmWarehouseReceipt_Drag.queryWRHeadNo = wrHeadNoStr;
                    //FrmWarehouseReceipt_Drag.queryListAutoId = 0;
                    ViewHandler.ShowRightWindow("FrmWarehouseReceipt_Drag");
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
