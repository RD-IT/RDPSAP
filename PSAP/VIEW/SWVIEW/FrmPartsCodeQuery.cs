using PSAP.DAO.BSDAO;
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
    public partial class FrmPartsCodeQuery : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmPartsCodeDAO pcDAO = new FrmPartsCodeDAO();

        /// <summary>
        /// 最后一次查询的SQL
        /// </summary>
        string lastQuerySqlStr = "";

        public FrmPartsCodeQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPartsCodeQuery_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable materialTable_t = commonDAO.QueryMaterialSelectLib(true);
                DataTable catgNameTable_t = commonDAO.QueryPartNoCatg(true);
                DataTable finishTable_f = commonDAO.QueryFinishCatg(false);
                DataTable machTable_f = commonDAO.QueryLevelCatg(false);

                searchLookUpMaterial.Properties.DataSource = materialTable_t;
                searchLookUpMaterial.EditValue = 0;
                lookUpCatgName.Properties.DataSource = catgNameTable_t;
                lookUpCatgName.ItemIndex = 0;
                lookUpBrand.Properties.DataSource = commonDAO.QueryBrandCatg(true);
                lookUpBrand.ItemIndex = 0;

                repLookUpMaterial.DataSource = materialTable_t;
                repLookUpCatgName.DataSource = catgNameTable_t;
                repLookUpFinish.DataSource = finishTable_f;
                repLookUpMachiningLevel.DataSource = machTable_f;

                gridBottomPrReq.pageRowCount = SystemInfo.OrderQueryGrid_PageRowCount;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewPartsCode_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewPartsCode_KeyDown(object sender, KeyEventArgs e)
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

                string catgNameStr = lookUpCatgName.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpCatgName.EditValue) : "";
                int materialInt = DataTypeConvert.GetInt(searchLookUpMaterial.EditValue);
                string brandStr = lookUpBrand.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpBrand.EditValue) : "";
                string commonStr = textCommon.Text.Trim();
                dSPartsCode.Tables[0].Clear();

                string querySqlStr = pcDAO.QueryPartsCode_SQL(dSPartsCode.Tables[0], catgNameStr, materialInt, brandStr, commonStr, false);
                lastQuerySqlStr = querySqlStr;
                string countSqlStr = commonDAO.QuerySqlTranTotalCountSql(querySqlStr);
                gridBottomPrReq.QueryGridData(ref dSPartsCode, "PartsCode", querySqlStr, countSqlStr, true);
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

                //FileHandler.SaveDevGridControlExportToExcel(gridViewPartsCode);
                if (gridBottomPrReq.pageCount <= 1)
                    FileHandler.SaveDevGridControlExportToExcel(gridViewPartsCode);
                else
                    commonDAO.SaveExcel_QueryAllData(dSPartsCode.Tables[0], lastQuerySqlStr, gridViewPartsCode);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewPartsCode_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string formNameStr = "FrmPartsCode";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string codeFileNameStr = DataTypeConvert.GetString(gridViewPartsCode.GetFocusedDataRow()["CodeFileName"]);
                    FrmPartsCode.codeFileNameStr = codeFileNameStr;
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
