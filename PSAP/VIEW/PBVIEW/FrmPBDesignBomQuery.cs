using PSAP.DAO.BSDAO;
using PSAP.DAO.PBDAO;
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
    public partial class FrmPBDesignBomQuery : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmPBDesignBom_PSDAO bomDAO = new FrmPBDesignBom_PSDAO();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmPBDesignBomQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPBDesignBomQuery_Load(object sender, EventArgs e)
        {
            try
            {
                checkIsUse.Checked = false;
                searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(true);
                searchLookUpProjectNo.Text = "全部";
                searchLookUpCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(true);
                searchLookUpCodeFileName.Text = "全部";
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
        /// 设定列表显示信息
        /// </summary>
        private void gridViewDesignBom_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colHasLevel)
            {
                switch (e.Value.ToString())
                {
                    case "0":
                        e.DisplayText = "零件";
                        break;
                    default:
                        e.DisplayText = "BOM";
                        break;
                }
            }
        }
        
        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewDesignBom_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewDesignBom_KeyDown(object sender, KeyEventArgs e)
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
                string projectNoStr = searchLookUpProjectNo.Text != "全部" ? DataTypeConvert.GetString(searchLookUpProjectNo.EditValue) : "";
                string codeFileNameStr = searchLookUpCodeFileName.Text != "全部" ? DataTypeConvert.GetString(searchLookUpCodeFileName.EditValue) : "";
                string empNameStr = lookUpPrepared.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpPrepared.EditValue) : "";
                string commonStr = textCommon.Text.Trim();

                dataSet_DesignBom.Tables[0].Rows.Clear();
                string querySqlStr = bomDAO.Query_DesignBomList_SQL(projectNoStr, codeFileNameStr, checkIsUse.Checked, empNameStr, commonStr, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);

                gridBottomOrderHead.QueryGridData(ref dataSet_DesignBom, "DesignBom", querySqlStr, countSqlStr, true);
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
                //FileHandler.SaveDevGridControlExportToExcel(gridViewDesignBom);
                if (gridBottomOrderHead.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewDesignBom);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_DesignBom.Tables[0], lastQuerySqlStr, gridViewDesignBom);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewDesignBom_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string salesOrderNoStr = DataTypeConvert.GetString(gridViewDesignBom.GetFocusedDataRow()["SalesOrderNo"]);
                    int autoIdInt = DataTypeConvert.GetInt(gridViewDesignBom.GetFocusedDataRow()["AutoId"]);
                    FrmPBDesignBom_PS.QuerySalesOrderNoStr = salesOrderNoStr;
                    FrmPBDesignBom_PS.QueryPBBomListAutoId = autoIdInt;
                    ViewHandler.ShowRightWindow("FrmPBDesignBom_PS");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击查询明细错误。", ex);
            }
        }
    }
}
