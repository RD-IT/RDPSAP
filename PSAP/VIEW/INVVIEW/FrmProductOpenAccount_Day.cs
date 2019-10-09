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
    public partial class FrmProductOpenAccount_Day : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmWarehouseNowInfoDAO wNowInfoDAO = new FrmWarehouseNowInfoDAO();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmProductOpenAccount_Day()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmProductOpenAccount_Day_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateOpDate.DateTime = nowDate.Date.AddDays(-1);

                DataTable repertoryTable_t = commonDAO.QueryRepertoryInfo(true);
                DataTable locationTable_t = commonDAO.QueryRepertoryLocationInfo(true);
                DataTable shelfTable_t = commonDAO.QueryShelfInfo(true);

                lookUpRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpRepertoryId.ItemIndex = 0;
                SearchLocationId.Properties.DataSource = locationTable_t;
                SearchLocationId.EditValue = 0;
                searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(true);
                searchLookUpProjectNo.Text = "全部";
                searchLookUpShelfId.Properties.DataSource = shelfTable_t;
                searchLookUpShelfId.EditValue = 0;
                searchLookUpCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(true);
                searchLookUpCodeFileName.EditValue = 0;

                //repLookUpRepertoryId.DataSource = commonDAO.QueryRepertoryInfo(false);
                //repLookUpLocationId.DataSource = commonDAO.QueryRepertoryLocationInfo(false);
                repLookUpRepertoryId.DataSource = repertoryTable_t;
                repLookUpLocationId.DataSource = locationTable_t;
                repLookUpShelfId.DataSource = shelfTable_t;

                if (SystemInfo.DisableProjectNo)
                {
                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    colProjectNo.Visible = false;
                    colProjectName.Visible = false;
                }

                if (SystemInfo.DisableShelfInfo)
                {
                    labShelfId.Visible = false;
                    searchLookUpShelfId.Visible = false;
                    colShelfId.Visible = false;
                }

                gridBottomWNowInfo.pageRowCount = SystemInfo.OrderQueryGrid_PageRowCount;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 设定列表显示信息
        /// </summary>
        private void gridViewOpenAccount_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "TypeNo")
            {
                e.DisplayText = CommonHandler.Get_WarehouseOrderType_Desc(e.Value.ToString());
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewOpenAccount_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewOpenAccount_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

                if (dateOpDate.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("操作日期不能为空，请设置后重新进行查询。");
                    dateOpDate.Focus();
                    return;
                }
                string opBeginStr = dateOpDate.DateTime.Date.ToString("yyyy-MM-dd");
                string opEndStr = dateOpDate.DateTime.Date.AddDays(1).ToString("yyyy-MM-dd");

                int repertoryIdInt = lookUpRepertoryId.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpRepertoryId.EditValue) : 0;
                int locationIdInt = DataTypeConvert.GetInt(SearchLocationId.EditValue);
                //string codeFileNameStr = searchLookUpCodeFileName.Text != "全部" ? DataTypeConvert.GetString(searchLookUpCodeFileName.EditValue) : "";
                int codeIdInt = DataTypeConvert.GetInt(searchLookUpCodeFileName.EditValue);
                int shelfIdInt = searchLookUpShelfId.Text != "全部" ? DataTypeConvert.GetInt(searchLookUpShelfId.EditValue) : 0;
                string projectNoStr = searchLookUpProjectNo.Text != "全部" ? DataTypeConvert.GetString(searchLookUpProjectNo.EditValue) : "";

                string querySqlStr = wNowInfoDAO.QueryProductOpenAccount_SQL(opBeginStr, opEndStr, repertoryIdInt, locationIdInt, projectNoStr, shelfIdInt, codeIdInt);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);
                gridBottomWNowInfo.QueryGridData(ref dataSet_OpenAccount, "OpenAccount", querySqlStr, countSqlStr, true);
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

                //FileHandler.SaveDevGridControlExportToExcel(gridViewDurationStock);
                if (gridBottomWNowInfo.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewOpenAccount);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_OpenAccount.Tables[0], lastQuerySqlStr, gridViewOpenAccount);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
            }
        }

    }
}
