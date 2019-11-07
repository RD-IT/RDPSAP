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
    public partial class FrmWarehouseWarrantQuery : DockContent
    {
        FrmWarehouseWarrantDAO wwDAO = new FrmWarehouseWarrantDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        /// <summary>
        /// 采购订单明细ID
        /// </summary>
        public static int orderListAutoId = 0;

        public FrmWarehouseWarrantQuery()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(f);
            PSAP.BLL.BSBLL.BSBLL.language(this);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWarehouseWarrantQuery_Load(object sender, EventArgs e)
        {
            try
            {
                ControlCommonInit ctlInit = new ControlCommonInit();

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateWWDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateWWDateEnd.DateTime = nowDate.Date;

                DataTable departmentTable_t = commonDAO.QueryDepartment(true);
                DataTable bussInfoTable_t = commonDAO.QueryBussinessBaseInfo(true);
                DataTable repertoryTable_t = commonDAO.QueryRepertoryInfo(true);
                DataTable wwTypeTable_t = wwDAO.QueryWarehouseWarrantType(true);

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
                lookUpWarehouseWarrantTypeNo.Properties.DataSource = wwTypeTable_t;
                lookUpWarehouseWarrantTypeNo.ItemIndex = 0;
                ctlInit.ComboBoxEdit_WarehouseState(comboBoxWarehouseState,true);
                comboBoxWarehouseState.SelectedIndex = 0;                
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;

                //repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                //repSearchBussinessBaseNo.DataSource = commonDAO.QueryBussinessBaseInfo(false);
                //repLookUpRepertoryId.DataSource = commonDAO.QueryRepertoryInfo(false);
                //repLookUpRepertoryLocationId.DataSource = commonDAO.QueryRepertoryLocationInfo(false);
                //repLookUpWWTypeNo.DataSource = wwDAO.QueryWarehouseWarrantType(false);
                repLookUpReqDep.DataSource = departmentTable_t;
                repSearchBussinessBaseNo.DataSource = bussInfoTable_t;
                repLookUpRepertoryId.DataSource = repertoryTable_t;
                repLookUpRepertoryLocationId.DataSource = SearchLocationId.Properties.DataSource;
                repLookUpWWTypeNo.DataSource = wwTypeTable_t;
                repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);
                repLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;

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
        /// 窗体激活事件
        /// </summary>
        private void FrmWarehouseWarrantQuery_Activated(object sender, EventArgs e)
        {
            try
            {
                if (orderListAutoId != 0)
                {
                    spinorderListAutoId.Value = orderListAutoId;
                    orderListAutoId = 0;
                    checkorderListAutoId.Checked = true;

                    DateTime nowDate = BaseSQL.GetServerDateTime();
                    dateWWDateBegin.DateTime = nowDate.AddMonths(-6);
                    dateWWDateEnd.DateTime = nowDate.AddMonths(6);
                    searchLookUpBussinessBaseNo.Text = "全部";
                    lookUpRepertoryId.ItemIndex = 0;
                    SearchLocationId.EditValue = 0;
                    lookUpReqDep.ItemIndex = 0;
                    lookUpWarehouseWarrantTypeNo.ItemIndex = 0;
                    comboBoxWarehouseState.SelectedIndex = 0;
                    searchLookUpCreator.EditValue = 0;
                    textCommon.Text = "";

                    btnQuery_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体激活事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiCtjhsjcw.Text, ex);
            }
        }

        /// <summary>
        /// 选择采购单明细ID
        /// </summary>
        private void checkorderListAutoId_CheckedChanged(object sender, EventArgs e)
        {
            if (checkorderListAutoId.Checked)
            {
                spinorderListAutoId.Enabled = true;
            }
            else
            {
                spinorderListAutoId.Enabled = false;
            }
        }

        /// <summary>
        /// 设定列表显示信息
        /// </summary>
        private void gridViewWWHead_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "WarehouseState")
            {
                e.DisplayText = CommonHandler.Get_WarehouseState_Desc(e.Value.ToString());
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewWWHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewWWHead_KeyDown(object sender, KeyEventArgs e)
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

                if (dateWWDateBegin.EditValue == null || dateWWDateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox(tsmiRkrqbnwkcx.Text);// ("入库日期不能为空，请设置后重新进行查询。");
                    if (dateWWDateBegin.EditValue == null)
                        dateWWDateBegin.Focus();
                    else
                        dateWWDateEnd.Focus();
                    return;
                }
                string orderDateBeginStr = dateWWDateBegin.DateTime.ToString("yyyy-MM-dd");
                string orderDateEndStr = dateWWDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                string reqDepStr = lookUpReqDep.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpReqDep.EditValue) : "";
                string bussinessBaseNoStr = DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) != "全部" ? DataTypeConvert.GetString(searchLookUpBussinessBaseNo.EditValue) : "";
                int repertoryIdInt = lookUpRepertoryId.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpRepertoryId.EditValue) : 0;
                int locationIdInt = DataTypeConvert.GetInt(SearchLocationId.EditValue);
                string wwTypeNoStr = lookUpWarehouseWarrantTypeNo.ItemIndex > 0 ? lookUpWarehouseWarrantTypeNo.EditValue.ToString() : "";

                int warehouseStateInt = CommonHandler.Get_WarehouseState_No(comboBoxWarehouseState.Text);
                int creatorInt = DataTypeConvert.GetInt(searchLookUpCreator.EditValue);
                string commonStr = textCommon.Text.Trim();
                int orderListAutoIdInt = (checkorderListAutoId.Checked && spinorderListAutoId.Value > 0) ? DataTypeConvert.GetInt(spinorderListAutoId.Value) : 0;

                dataSet_WW.Tables[0].Rows.Clear();
                string querySqlStr = wwDAO.QueryWarehouseWarrantHead_SQL(orderDateBeginStr, orderDateEndStr, reqDepStr, bussinessBaseNoStr, repertoryIdInt, locationIdInt, wwTypeNoStr, warehouseStateInt, creatorInt, -1, commonStr, orderListAutoIdInt, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);

                gridBottomOrderHead.QueryGridData(ref dataSet_WW, "WWHead", querySqlStr, countSqlStr, true);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--查询按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiCxansjcw.Text, ex);
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

                //FileHandler.SaveDevGridControlExportToExcel(gridViewWWHead);
                if (gridBottomOrderHead.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewWWHead);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_WW.Tables[0], lastQuerySqlStr, gridViewWWHead);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiCxjgcwexcelcw.Text, ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewWWHead_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string formNameStr = "FrmWarehouseWarrant_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string wwHeadNoStr = DataTypeConvert.GetString(gridViewWWHead.GetFocusedDataRow()["WarehouseWarrant"]);
                    FrmWarehouseWarrant_Drag.queryWWHeadNo = wwHeadNoStr;
                    //FrmWarehouseWarrant_Drag.queryListAutoId = 0;
                    ViewHandler.ShowRightWindow(formNameStr);
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--双击查询明细错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiSjcxmxcw.Text, ex);
            }
        }
    }
}
