using PSAP.DAO.BSDAO;
using PSAP.DAO.PBDAO;
using PSAP.PSAPCommon;
using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmProductionPlanQuery : DockContent
    {
        FrmProductionPlanDAO ppDAO = new FrmProductionPlanDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmProductionPlanQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmProductionPlanQuery_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                datePlanDateBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                datePlanDateEnd.DateTime = nowDate.Date;

                DataTable manuInfoTable_t = commonDAO.QueryManufactureInfo(true);

                lookUpManufactureNo.Properties.DataSource = manuInfoTable_t;
                lookUpManufactureNo.ItemIndex = 0;
                //searchLookUpCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(true);
                //searchLookUpCodeFileName.EditValue = 0;
                //searchLookUpProjectNo.Properties.DataSource = projectTable_t;
                //searchLookUpProjectNo.Text = "全部";                

                ControlCommonInit ctlInit = new ControlCommonInit();
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId(searchLookUpCreator);
                searchLookUpCreator.EditValue = SystemInfo.user.AutoId;
                ctlInit.SearchLookUpEdit_PartsCode(searchLookUpCodeFileName, true);
                searchLookUpCodeFileName.EditValue = 0;
                ctlInit.SearchLookUpEdit_ProjectList(searchLookUpProjectNo, true);
                searchLookUpProjectNo.Text = "全部";
                ctlInit.ComboBoxEdit_OrderState_Submit(comboBoxCurrentStatus, false);
                comboBoxCurrentStatus.SelectedIndex = 0;

                repLookUpManufactureNo.DataSource = manuInfoTable_t;
                repSearchProjectNo.DataSource = searchLookUpProjectNo.Properties.DataSource;
                repLookUpCreator.DataSource = searchLookUpCreator.Properties.DataSource;

                gridBottomOrderHead.pageRowCount = SystemInfo.OrderQueryGrid_PageRowCount;

                if (SystemInfo.DisableProjectNo)
                {
                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    colProjectNo.Visible = false;
                }

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
        private void gridViewProductionPlan_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "CurrentStatus")
            {
                e.DisplayText = CommonHandler.Get_OrderState_Desc(e.Value.ToString());
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewProductionPlan_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewProductionPlan_KeyDown(object sender, KeyEventArgs e)
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

                if (datePlanDateBegin.EditValue == null || datePlanDateEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("计划日期不能为空，请设置后重新进行查询。");
                    if (datePlanDateBegin.EditValue == null)
                        datePlanDateBegin.Focus();
                    else
                        datePlanDateEnd.Focus();
                    return;
                }
                string reqDateBeginStr = datePlanDateBegin.DateTime.ToString("yyyy-MM-dd");
                string reqDateEndStr = datePlanDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                string manufactureNoStr = lookUpManufactureNo.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpManufactureNo.EditValue) : "";
                int codeIdInt = DataTypeConvert.GetInt(searchLookUpCodeFileName.EditValue);
                string projectNoStr = searchLookUpProjectNo.Text != "全部" ? DataTypeConvert.GetString(searchLookUpProjectNo.EditValue) : "";

                int currentStateInt = CommonHandler.Get_OrderState_No(comboBoxCurrentStatus.Text);
                int creatorInt = DataTypeConvert.GetInt(searchLookUpCreator.EditValue);
                int approverInt = -1;

                string commonStr = textCommon.Text.Trim();
                dataSet_ProductionPlan.Tables[0].Rows.Clear();

                string querySqlStr = ppDAO.QueryProductionPlan_SQL(reqDateBeginStr, reqDateEndStr, codeIdInt, manufactureNoStr, projectNoStr, currentStateInt, creatorInt, approverInt, commonStr, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);

                gridBottomOrderHead.QueryGridData(ref dataSet_ProductionPlan, "ProductionPlan", querySqlStr, countSqlStr, true);
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

                if (gridBottomOrderHead.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewProductionPlan);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_ProductionPlan.Tables[0], lastQuerySqlStr, gridViewProductionPlan);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewProductionPlan_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string formNameStr = "FrmProductionPlan";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string planNoStr = DataTypeConvert.GetString(gridViewProductionPlan.GetFocusedDataRow()["PlanNo"]);
                    FrmProductionPlan.queryPlanNo = planNoStr;
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
