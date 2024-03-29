﻿using PSAP.DAO.BSDAO;
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
    public partial class FrmInventoryAdjustmentsQuery : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmInventoryAdjustmentsDAO iaDAO = new FrmInventoryAdjustmentsDAO();
            static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmInventoryAdjustmentsQuery()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(f);
            PSAP.BLL.BSBLL.BSBLL.language(this);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmInventoryAdjustmentsQuery_Load(object sender, EventArgs e)
        {
            try
            {
                ControlCommonInit ctlInit = new ControlCommonInit();

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateIADateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateIADateEnd.DateTime = nowDate.Date;                

                DataTable departmentTable_t = commonDAO.QueryDepartment(true);
                DataTable repertoryTable_t = commonDAO.QueryRepertoryInfo(true);

                lookUpReqDep.Properties.DataSource = departmentTable_t;
                lookUpReqDep.ItemIndex = 0;
                lookUpRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpRepertoryId.ItemIndex = 0;
                //SearchLocationId.Properties.DataSource = locationTable_t;
                //SearchLocationId.EditValue = 0;
                ctlInit.SearchLookUpEdit_RepertoryLocationInfo(SearchLocationId, true);
                SearchLocationId.EditValue = 0;
                //searchProjectNo.Properties.DataSource = projectTable_t;
                //searchProjectNo.Text = "全部";
                ctlInit.SearchLookUpEdit_ProjectList(searchProjectNo, true);
                searchProjectNo.Text = "全部";
                ctlInit.ComboBoxEdit_WarehouseState(comboBoxWarehouseState);
                comboBoxWarehouseState.SelectedIndex = 0;
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;

                //repLookUpReqDep.DataSource = commonDAO.QueryDepartment(false);
                //repLookUpRepertoryId.DataSource = commonDAO.QueryRepertoryInfo(false);
                //repLookUpLocationId.DataSource = commonDAO.QueryRepertoryLocationInfo(false);
                //repSearchProjectNo.DataSource = commonDAO.QueryProjectList(false);

                repLookUpReqDep.DataSource = departmentTable_t;
                repLookUpRepertoryId.DataSource = repertoryTable_t;
                repLookUpLocationId.DataSource = SearchLocationId.Properties.DataSource;
                repSearchProjectNo.DataSource = searchProjectNo.Properties.DataSource;
                repLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;
                repLookUpApprovalType.DataSource = commonDAO.QueryApprovalType(false);

                if (SystemInfo.DisableProjectNo)
                {
                    labProjectNo.Visible = false;
                    searchProjectNo.Visible = false;
                    colProjectNo.Visible = false;
                }

                gridBottomIA.pageRowCount = SystemInfo.OrderQueryGrid_PageRowCount;

                btnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--"+f.tsmiCtjzsjcw.Text , ex);
            }
        }

        /// <summary>
        /// 设定列表显示信息
        /// </summary>
        private void gridViewIAHead_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "WarehouseState")
            {
                e.DisplayText = CommonHandler.Get_WarehouseState_Desc(e.Value.ToString());
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewIAHead_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewIAHead_KeyDown(object sender, KeyEventArgs e)
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

                if (dateIADateBegin.EditValue == null || dateIADateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox(tsmiTzrqbnwkcx.Text);// ("调整日期不能为空，请设置后重新进行查询。");
                    if (dateIADateBegin.EditValue == null)
                        dateIADateBegin.Focus();
                    else
                        dateIADateEnd.Focus();
                    return;
                }
                string orderDateBeginStr = dateIADateBegin.DateTime.ToString("yyyy-MM-dd");
                string orderDateEndStr = dateIADateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                int repertoryIdInt = lookUpRepertoryId.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpRepertoryId.EditValue) : 0;
                int locationIdInt = DataTypeConvert.GetInt(SearchLocationId.EditValue);
                string projectNoStr = searchProjectNo.Text != "全部" ? DataTypeConvert.GetString(searchProjectNo.EditValue) : "";
                string reqDepStr = lookUpReqDep.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpReqDep.EditValue) : "";
                int warehouseStateInt = CommonHandler.Get_WarehouseState_No(comboBoxWarehouseState.Text);
                int creatorInt = DataTypeConvert.GetInt(searchLookUpCreator.EditValue);
                string commonStr = textCommon.Text.Trim();

                dataSet_IA.Tables[0].Clear();
                string querySqlStr = iaDAO.QueryInventoryAdjustmentsHead_SQL(orderDateBeginStr, orderDateEndStr, repertoryIdInt, locationIdInt, projectNoStr, reqDepStr, warehouseStateInt, creatorInt, -1, commonStr, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);
                gridBottomIA.QueryGridData(ref dataSet_IA, "IAHead", querySqlStr, countSqlStr, true);
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

                //FileHandler.SaveDevGridControlExportToExcel(gridViewIAHead);
                if (gridBottomIA.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewIAHead);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_IA.Tables[0], lastQuerySqlStr, gridViewIAHead);
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
        private void gridViewIAHead_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string formNameStr = "FrmInventoryAdjustments_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string inventoryAdjustmentsNoStr = DataTypeConvert.GetString(gridViewIAHead.GetFocusedDataRow()["InventoryAdjustmentsNo"]);
                    FrmInventoryAdjustments_Drag.queryIAHeadNo = inventoryAdjustmentsNoStr;
                    FrmInventoryAdjustments_Drag.queryListAutoId = 0;
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
