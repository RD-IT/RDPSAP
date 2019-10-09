using PSAP.DAO.BSDAO;
using PSAP.DAO.PURDAO;
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
    public partial class FrmPrReqListDistributionQuery : DockContent
    {
        FrmPrReqListDistributionDAO prReqDAO = new FrmPrReqListDistributionDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        public FrmPrReqListDistributionQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPrReqListDistributionQuery_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable userTable_t = commonDAO.QueryUserInfo(true);
                DataTable partsCodeTable_t = commonDAO.QueryPartsCode(true);

                lookUpArrangement.Properties.DataSource = userTable_t;
                lookUpArrangement.EditValue = SystemInfo.user.AutoId;

                repLookUpCodeName.DataSource = partsCodeTable_t;
                repLookUpOperator.DataSource = userTable_t;

                //if (!SystemInfo.PrListDistributionAllHandle)
                //{
                //    pnlTop.Visible = false;
                //}

                if (SystemInfo.DisableProjectNo)
                {
                    colProjectNo.Visible = false;
                    colStnNo.Visible = false;
                }

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
        private void gridViewPrReqList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewPrReqList_KeyDown(object sender, KeyEventArgs e)
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
        /// 双击查询明细
        /// </summary>
        private void gridViewPrReqList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string formNameStr = "FrmOrder_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;

                    string prReqNoStr = DataTypeConvert.GetString(gridViewPrReqList.GetFocusedDataRow()["PrReqNo"]);
                    FrmOrder_Drag.queryOrderHeadNo = "";
                    FrmOrder_Drag.queryPrReqNo = prReqNoStr;
                    FrmOrder_Drag.queryListAutoId = 0;
                    ViewHandler.ShowRightWindow(formNameStr);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击查询明细错误。", ex);
            }
        }

        /// <summary>
        /// 查询按钮事件
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpArrangement.ItemIndex < 0)
                {
                    MessageHandler.ShowMessageBox("请选择要查询的执行人。");
                    lookUpArrangement.Focus();
                    return;
                }

                int arrangementId = lookUpArrangement.ItemIndex > 0 ? DataTypeConvert.GetInt(lookUpArrangement.EditValue) : 0;

                dataSet_PrReqList.Tables[0].Clear();
                prReqDAO.QueryPrReqListDistribution(dataSet_PrReqList.Tables[0], "", "", "", 0, arrangementId, "", true);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询按钮事件错误。", ex);
            }
        }
    }
}
