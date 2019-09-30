using DevExpress.XtraGrid.Views.Grid;
using PSAP.DAO.BSDAO;
using PSAP.DAO.INVDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmQueryStockDurationTotal : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmWarehouseNowInfoDAO wNowInfoDAO = new FrmWarehouseNowInfoDAO();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmQueryStockDurationTotal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmQueryStockDurationTotal_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateDurBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateDurEnd.DateTime = nowDate.Date;

                DataTable repertoryTable_t = commonDAO.QueryRepertoryInfo(true);
                DataTable locationTable_t = commonDAO.QueryRepertoryLocationInfo(true);
                DataTable catgNameTable_f = commonDAO.QueryPartNoCatg(false);

                lookUpRepertoryId.Properties.DataSource = repertoryTable_t;
                lookUpRepertoryId.ItemIndex = 0;
                SearchLocationId.Properties.DataSource = locationTable_t;
                SearchLocationId.EditValue = 0;
                searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(true);
                searchLookUpProjectNo.Text = "全部";
                searchLookUpCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(true);
                searchLookUpCodeFileName.Text = "全部";

                //repLookUpRepertoryId.DataSource = commonDAO.QueryRepertoryInfo(false);
                //repLookUpLocationId.DataSource = commonDAO.QueryRepertoryLocationInfo(false);
                repLookUpRepertoryId.DataSource = repertoryTable_t;
                repLookUpLocationId.DataSource = locationTable_t;
                repLookUpCatgName.DataSource = catgNameTable_f;

                if (SystemInfo.DisableProjectNo)
                {
                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    colProjectNo.Visible = false;
                    colProjectName.Visible = false;
                }

                gridBottomWNowInfo.pageRowCount = SystemInfo.OrderQueryGrid_PageRowCount;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewDurationStock_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewDurationStock_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

                if (dateDurBegin.EditValue == null || dateDurEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("期间日期不能为空，请设置后重新进行查询。");
                    if (dateDurBegin.EditValue == null)
                        dateDurBegin.Focus();
                    else
                        dateDurEnd.Focus();
                    return;
                }
                string durDateBeginStr = dateDurBegin.DateTime.ToString("yyyy-MM-dd");
                string durDateEndStr = dateDurEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                int repertoryIdInt = lookUpRepertoryId.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpRepertoryId.EditValue) : 0;
                int locationIdInt = DataTypeConvert.GetInt(SearchLocationId.EditValue);
                string codeFileNameStr = searchLookUpCodeFileName.Text != "全部" ? DataTypeConvert.GetString(searchLookUpCodeFileName.EditValue) : "";
                string projectNameStr = searchLookUpProjectNo.Text != "全部" ? searchLookUpProjectNo.Text : "";
                string commonStr = textCommon.Text.Trim();

                string querySqlStr = wNowInfoDAO.QueryStockDurationTotal_SQL(dateDurBegin.DateTime.Date, durDateBeginStr, durDateEndStr, repertoryIdInt, locationIdInt, projectNameStr, codeFileNameStr, commonStr);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);
                gridBottomWNowInfo.QueryGridData(ref dataSet_DurationStock, "DurationStock", querySqlStr, countSqlStr, true);
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
                    FileHandler.SaveDevGridControlExportToExcel(gridViewDurationStock);
                else
                    commonDAO.SaveExcel_QueryAllData(dataSet_DurationStock.Tables[0], lastQuerySqlStr, gridViewDurationStock);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
            }
        }

        /// <summary>
        /// 设置Grid单元格合并
        /// </summary>
        private void gridViewDurationStock_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                string firstColumnFieldName = "CodeFileName";

                switch (e.Column.FieldName)
                {
                    case "CodeName":
                    case "CodeNo":
                    case "CodeSpec":
                    case "Brand":
                    case "CatgName":
                    case "MaterialVersion":
                    case "CodeWeight":
                        {
                            string valueFirstColumn1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, firstColumnFieldName));
                            string valueFirstColumn2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, firstColumnFieldName));
                            string valueOtherColumn1 = Convert.ToString(view.GetRowCellValue(e.RowHandle1, e.Column.FieldName));
                            string valueOtherColumn2 = Convert.ToString(view.GetRowCellValue(e.RowHandle2, e.Column.FieldName));
                            e.Merge = valueFirstColumn1 == valueFirstColumn2 && valueOtherColumn1 == valueOtherColumn2;
                            e.Handled = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设置Grid单元格合并错误。", ex);
            }
        }        
    }
}
