using PSAP.DAO.BSDAO;
using PSAP.DAO.WORKFLOWDAO;
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
    public partial class FrmQueryUserWorkFlow : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmQueryUserWorkFlowDAO userWFDAO = new FrmQueryUserWorkFlowDAO();
        FrmWorkFlowModuleDAO wfDAO = new FrmWorkFlowModuleDAO();

        public FrmQueryUserWorkFlow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmQueryUserWorkFlow_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable moduleTypeTable = wfDAO.QueryModuleType();

                repLookUpModuleType.DataSource = moduleTypeTable;
                repositoryItemLookUpEdit1.DataSource = moduleTypeTable;
                repLookUpLFMText.DataSource = wfDAO.QueryWorkFlowModule(false);
                btnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 窗体激活事件
        /// </summary>
        private void FrmQueryUserWorkFlow_Activated(object sender, EventArgs e)
        {
            try
            {
                btnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体激活事件错误。", ex);
            }
        }

        /// <summary>
        /// 查询用户流程信息
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                dataSet_UserWF.Tables[0].Rows.Clear();
                userWFDAO.QueryUserWorkFlow(dataSet_UserWF.Tables[0]);
                PageHandle.Text = string.Format("待处理信息 ({0})", dataSet_UserWF.Tables[0].Rows.Count);

                dataSet_Reject.Tables[0].Rows.Clear();
                userWFDAO.QueryRejectOrder(dataSet_Reject.Tables[0]);
                PageReject.Text = string.Format("被拒绝信息 ({0})", dataSet_Reject.Tables[0].Rows.Count);

                if (dataSet_Reject.Tables[0].Rows.Count > 0 && dataSet_UserWF.Tables[0].Rows.Count == 0)
                {
                    xtraTabCtl.SelectedTabPageIndex = 1;
                }
                else
                {
                    xtraTabCtl.SelectedTabPageIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询用户流程信息错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewUserWF_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewUserWF_KeyDown(object sender, KeyEventArgs e)
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
        /// Test按钮事件
        /// </summary>
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                FrmWorkFlowDataHandle wfDataHandle = new FrmWorkFlowDataHandle();
                wfDataHandle.orderNameStr = "请购单";
                wfDataHandle.dataNoList = new List<string>() { "PR00000000119" };
                wfDataHandle.workFlowTypeText = "采购流程";
                wfDataHandle.tableNameStr = "PUR_PrReqHead";
                wfDataHandle.moduleTypeInt = 2;
                if (wfDataHandle.ShowDialog() == DialogResult.OK)
                {
                    int nodeIdInt = wfDataHandle.nodeIdInt;
                    string flowModuleIdStr = wfDataHandle.flowModuleIdStr;
                    string approverOptionStr = wfDataHandle.memoApproverOption.Text;
                    int approverResultInt = DataTypeConvert.GetInt(wfDataHandle.radioApproverResult.EditValue);

                    MessageHandler.ShowMessageBox(nodeIdInt + "-----" + flowModuleIdStr + "-----" + approverOptionStr + "-----" + approverResultInt);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--Test按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 双击查询用户处理信息明细
        /// </summary>
        private void gridViewUserWF_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string oldOrderNoStr = DataTypeConvert.GetString(gridViewUserWF.GetFocusedDataRow()["DataNo"]);
                    string fmTableStr = DataTypeConvert.GetString(gridViewUserWF.GetFocusedDataRow()["FMTable"]);
                    string lfmTableStr = DataTypeConvert.GetString(gridViewUserWF.GetFocusedDataRow()["LFMTable"]);
                    string newOrderNoStr = oldOrderNoStr;
                    if (fmTableStr != lfmTableStr)
                        newOrderNoStr = "";
                    OpenRelationForm(lfmTableStr, newOrderNoStr, oldOrderNoStr);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击查询用户处理信息明细错误。", ex);
            }
        }

        /// <summary>
        /// 双击查询用户被拒绝信息明细
        /// </summary>
        private void gridViewReject_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string orderNoStr = DataTypeConvert.GetString(gridViewReject.GetFocusedDataRow()["DataNo"]);
                    string fmTableStr = DataTypeConvert.GetString(gridViewReject.GetFocusedDataRow()["FMTable"]);

                    OpenRelationForm(fmTableStr, orderNoStr, orderNoStr);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击查询用户被拒绝信息明细错误。", ex);
            }
        }

        /// <summary>
        /// 打开相关窗体
        /// </summary>
        private void OpenRelationForm(string tableNameStr, string newOrderNoStr, string oldOrderNoStr)
        {
            string formNameStr = "";
            switch (tableNameStr)
            {
                //采购
                case "PUR_PrReqHead"://请购单
                    formNameStr = "FrmPrReq";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmPrReq.queryPrReqNo = newOrderNoStr;
                    FrmPrReq.queryListAutoId = 0;                    
                    break;
                case "PUR_OrderHead"://采购单
                    formNameStr = "FrmOrder_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmOrder_Drag.queryOrderHeadNo = newOrderNoStr;
                    if (newOrderNoStr == "")
                        FrmOrder_Drag.queryPrReqNo = oldOrderNoStr;
                    FrmOrder_Drag.queryListAutoId = 0;
                    break;
                case "PUR_SettlementHead"://采购结账单
                    formNameStr = "FrmSettlement_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmSettlement_Drag.querySettlementNo = newOrderNoStr;
                    break;

                //销售
                case "SA_QuotationBaseInfo"://报价单
                    formNameStr = "FrmQuotationInfo_History";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmQuotationInfo_History.queryAutoQuotationNoStr = newOrderNoStr;
                    break;
                case "SA_SalesOrder"://销售订单
                    formNameStr = "FrmSalesOrder_History";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmSalesOrder_History.queryAutoSalesOrderNoStr = newOrderNoStr;
                    break;
                case "SA_SettleAccountsHead"://销售结账单
                    formNameStr = "FrmSettleAccounts_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmSettleAccounts_Drag.querySettleAccountNo = newOrderNoStr;
                    break;
                case "SA_StnSummary"://工位描述登记
                    formNameStr = "FrmStnModule";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmStnModule.querySMNoStr = newOrderNoStr;
                    break;

                //库存
                case "INV_WarehouseWarrantHead"://入库单
                    formNameStr = "FrmWarehouseWarrant_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmWarehouseWarrant_Drag.queryWWHeadNo = newOrderNoStr;
                    break;
                case "INV_WarehouseReceiptHead"://出库单
                    formNameStr = "FrmWarehouseReceipt_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmWarehouseReceipt_Drag.queryWRHeadNo = newOrderNoStr;
                    break;
                case "INV_SpecialWarehouseWarrantHead"://预算外入库单
                    formNameStr = "FrmSpecialWarehouseWarrant";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmSpecialWarehouseWarrant.querySWWHeadNo = newOrderNoStr;
                    break;
                case "INV_SpecialWarehouseReceiptHead"://预算外出库单
                    formNameStr = "FrmSpecialWarehouseReceipt";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmSpecialWarehouseReceipt.querySWRHeadNo = newOrderNoStr;
                    break;
                case "INV_InventoryMoveHead"://库存移动单
                    formNameStr = "FrmInventoryMove_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmInventoryMove_Drag.queryIMHeadNo = newOrderNoStr;
                    FrmInventoryMove_Drag.queryListAutoId = 0;
                    break;
                case "INV_InventoryAdjustmentsHead"://库存调整单
                    formNameStr = "FrmInventoryAdjustments_Drag";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmInventoryAdjustments_Drag.queryIAHeadNo = newOrderNoStr;
                    FrmInventoryAdjustments_Drag.queryListAutoId = 0;
                    break;
                case "INV_ReturnedGoodsReportHead"://退货单
                    formNameStr = "FrmReturnedGoodsReport";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmReturnedGoodsReport.queryRGRHeadNo = newOrderNoStr;
                    break;

                //生产
                case "PB_ProductionScheduleBom"://生产视图登记
                    formNameStr = "FrmPBDesignBom_PS_New";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    break;
                case "PB_ProductionPlan"://工单
                    formNameStr = "FrmProductionPlan";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmProductionPlan.queryPlanNo = newOrderNoStr;
                    break;
            }

            ViewHandler.ShowRightWindow(formNameStr);
        }


    }
}
