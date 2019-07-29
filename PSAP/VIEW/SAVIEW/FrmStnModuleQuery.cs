using PSAP.DAO.BSDAO;
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
    public partial class FrmStnModuleQuery : DockContent
    {
        #region 私有变量

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmStnModuleDAO smDAO = new FrmStnModuleDAO();
        FrmStnSummaryDAO ssDAO = new FrmStnSummaryDAO();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        #endregion

        #region 构造方法

        public FrmStnModuleQuery()
        {
            InitializeComponent();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmStnModuleQuery_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateGetTimeBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateGetTimeEnd.DateTime = nowDate.Date;

                searchLookUpStnModule.Properties.DataSource = ssDAO.QueryStnModule(true);
                searchLookUpStnModule.Text = "全部";
                lookUpPrepared.Properties.DataSource = commonDAO.QueryUserInfo(true);
                lookUpPrepared.EditValue = SystemInfo.user.EmpName;

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
        private void gridViewStnModuleListInfo_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewStnModuleListInfo_KeyDown(object sender, KeyEventArgs e)
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

                if (dateGetTimeBegin.EditValue == null || dateGetTimeEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("登记日期不能为空，请设置后重新进行查询。");
                    if (dateGetTimeBegin.EditValue == null)
                        dateGetTimeBegin.Focus();
                    else
                        dateGetTimeEnd.Focus();
                    return;
                }
                string getDateBeginStr = dateGetTimeBegin.DateTime.ToString("yyyy-MM-dd");
                string getDateEndStr = dateGetTimeEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                string smNoStr = DataTypeConvert.GetString(searchLookUpStnModule.EditValue) != "全部" ? DataTypeConvert.GetString(searchLookUpStnModule.EditValue) : "";
                string empNameStr = lookUpPrepared.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpPrepared.EditValue) : "";
                string commonStr = textCommon.Text.Trim();

                dataSet_StnModuleListInfo.Tables[0].Clear();

                string querySqlStr = smDAO.QueryStnModuleList_SQL(getDateBeginStr, getDateEndStr, smNoStr, empNameStr, commonStr, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);

                gridBottomOrderHead.QueryGridData(ref dataSet_StnModuleListInfo, "StnModuleListInfo", querySqlStr, countSqlStr, true);
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
                //FileHandler.SaveDevGridControlExportToExcel(gridViewStnSummaryList);
                if (gridBottomOrderHead.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewStnModuleListInfo);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_StnModuleListInfo.Tables[0], lastQuerySqlStr, gridViewStnModuleListInfo);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewStnModuleListInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string smNoStr = DataTypeConvert.GetString(gridViewStnModuleListInfo.GetFocusedDataRow()["SMNo"]);
                    FrmStnModule.querySMNoStr = smNoStr;
                    ViewHandler.ShowRightWindow("FrmStnModule");
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
