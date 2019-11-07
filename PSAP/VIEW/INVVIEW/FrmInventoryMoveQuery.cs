using PSAP.DAO.BSDAO;
using PSAP.DAO.INVDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmInventoryMoveQuery : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmInventoryMoveDAO imDAO = new FrmInventoryMoveDAO();
        static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmInventoryMoveQuery()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(f);
            PSAP.BLL.BSBLL.BSBLL.language(this);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmInventoryMoveQuery_Load(object sender, EventArgs e)
        {
            try
            {
                ControlCommonInit ctlInit = new ControlCommonInit();

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateIMDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateIMDateEnd.DateTime = nowDate.Date;

                DataTable repertoryTable_t = commonDAO.QueryRepertoryInfo(true);
                DataTable departmentTable_t = commonDAO.QueryDepartment(true);

                lookUpInRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpInRepertoryId.ItemIndex = 0;
                lookUpOutRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpOutRepertoryId.ItemIndex = 0;
                //SearchInLocationId.Properties.DataSource = locationTable_t;
                //SearchInLocationId.EditValue = 0;
                ctlInit.SearchLookUpEdit_RepertoryLocationInfo(SearchInLocationId, true);
                SearchInLocationId.EditValue = 0;
                //SearchOutLocationId.Properties.DataSource = locationTable_t;
                //SearchOutLocationId.EditValue = 0;
                ctlInit.SearchLookUpEdit_RepertoryLocationInfo(SearchOutLocationId, true);
                SearchOutLocationId.EditValue = 0;
                ctlInit.ComboBoxEdit_WarehouseState(comboBoxWarehouseState);
                comboBoxWarehouseState.SelectedIndex = 0;
                lookUpReqDep.Properties.DataSource = departmentTable_t;
                lookUpReqDep.ItemIndex = 0;
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;

                //repLookUpInRepertoryId.DataSource = commonDAO.QueryRepertoryInfo(false);
                //repLookUpLocationId.DataSource = commonDAO.QueryRepertoryLocationInfo(false);
                //repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                //repLookUpCreator.DataSource = commonDAO.QueryUserInfo(false);
                repLookUpInRepertoryId.DataSource = repertoryTable_t;
                repLookUpLocationId.DataSource = SearchInLocationId.Properties.DataSource;
                repLookUpReqDep.DataSource = departmentTable_t;
                repLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;
                repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);

                gridBottomIM.pageRowCount = SystemInfo.OrderQueryGrid_PageRowCount;

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
        private void gridViewIMHead_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "WarehouseState")
            {
                e.DisplayText = CommonHandler.Get_WarehouseState_Desc(e.Value.ToString());
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
                int creatorInt = DataTypeConvert.GetInt(searchLookUpCreator.EditValue);
                string commonStr = textCommon.Text.Trim();

                dataSet_IM.Tables[0].Clear();
                string querySqlStr = imDAO.QueryInventoryMoveHead_SQL(orderDateBeginStr, orderDateEndStr, inRepertoryIdInt, outRepertoryIdInt, inLocationIdInt, outLcationIdInt, reqDepStr, warehouseStateInt, creatorInt, -1, commonStr, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);
                gridBottomIM.QueryGridData(ref dataSet_IM, "IMHead", querySqlStr, countSqlStr, true);
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

                //FileHandler.SaveDevGridControlExportToExcel(gridViewIMHead);
                if (gridBottomIM.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewIMHead);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_IM.Tables[0], lastQuerySqlStr, gridViewIMHead);
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
        private void gridViewIMHead_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string formNameStr = "FrmInventoryMove_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string inventoryMoveNoStr = DataTypeConvert.GetString(gridViewIMHead.GetFocusedDataRow()["InventoryMoveNo"]);
                    FrmInventoryMove_Drag.queryIMHeadNo = inventoryMoveNoStr;
                    FrmInventoryMove_Drag.queryListAutoId = 0;
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
