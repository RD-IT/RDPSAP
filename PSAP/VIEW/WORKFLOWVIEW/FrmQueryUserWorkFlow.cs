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
                repLookUpModuleType.DataSource = wfDAO.QueryModuleType();
                btnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 查询用户流程信息
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                dataSet_UserWF.Tables[0].Rows.Clear();
                userWFDAO.QueryUserWorkFlow(dataSet_UserWF.Tables[0]);
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
        /// 双击查询明细
        /// </summary>
        private void gridViewUserWF_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    string orderNoStr = DataTypeConvert.GetString(gridViewUserWF.GetFocusedDataRow()["DataNo"]);
                    string fmTableStr = DataTypeConvert.GetString(gridViewUserWF.GetFocusedDataRow()["FMTable"]);
                    string lfmTableStr = DataTypeConvert.GetString(gridViewUserWF.GetFocusedDataRow()["LFMTable"]);
                    if (fmTableStr != lfmTableStr)
                        orderNoStr = "";
                    switch (lfmTableStr)
                    {
                        //采购
                        case "PUR_PrReqHead"://请购单
                            FrmPrReq.queryPrReqNo = orderNoStr;
                            FrmPrReq.queryListAutoId = 0;
                            ViewHandler.ShowRightWindow("FrmPrReq");
                            break;
                        case "PUR_OrderHead"://采购单
                            FrmOrder_Drag.queryOrderHeadNo = orderNoStr;
                            FrmOrder_Drag.queryListAutoId = 0;
                            ViewHandler.ShowRightWindow("FrmOrder_Drag");
                            break;
                        case "PUR_SettlementHead"://采购结账单
                            FrmSettlement_Drag.querySettlementNo = orderNoStr;
                            ViewHandler.ShowRightWindow("FrmSettlement_Drag");
                            break;

                        //销售
                        case "SA_QuotationBaseInfo"://报价单
                            FrmQuotationInfo_History.queryAutoQuotationNoStr = orderNoStr;
                            ViewHandler.ShowRightWindow("FrmQuotationInfo_History");
                            break;
                        case "SA_SalesOrder"://销售订单
                            FrmSalesOrder_History.queryAutoSalesOrderNoStr = orderNoStr;
                            ViewHandler.ShowRightWindow("FrmSalesOrder_History");
                            break;
                        case "SA_SettleAccountsHead"://销售结账单
                            FrmSettleAccounts_Drag.querySettleAccountNo = orderNoStr;
                            ViewHandler.ShowRightWindow("FrmSettleAccounts_Drag");
                            break;
                        case "SA_StnSummary"://工位描述登记
                            FrmStnModule.querySMNoStr = orderNoStr;
                            ViewHandler.ShowRightWindow("FrmStnModule");
                            break;

                        //库存
                        case "INV_WarehouseWarrantHead"://入库单
                            string wwHeadNoStr = orderNoStr;
                            FrmWarehouseWarrant_Drag.queryWWHeadNo = wwHeadNoStr;
                            ViewHandler.ShowRightWindow("FrmWarehouseWarrant_Drag");
                            break;
                        case "INV_WarehouseReceiptHead"://出库单
                            FrmWarehouseReceipt_Drag.queryWRHeadNo = orderNoStr;
                            ViewHandler.ShowRightWindow("FrmWarehouseReceipt_Drag");
                            break;
                        case "INV_SpecialWarehouseWarrantHead"://预算外入库单
                            FrmSpecialWarehouseWarrant.querySWWHeadNo = orderNoStr;
                            ViewHandler.ShowRightWindow("FrmSpecialWarehouseWarrant");
                            break;
                        case "INV_SpecialWarehouseReceiptHead"://预算外出库单
                            FrmSpecialWarehouseReceipt.querySWRHeadNo = orderNoStr;
                            ViewHandler.ShowRightWindow("FrmSpecialWarehouseReceipt");
                            break;
                        case "INV_InventoryMoveHead"://库存移动单
                            FrmInventoryMove_Drag.queryIMHeadNo = orderNoStr;
                            FrmInventoryMove_Drag.queryListAutoId = 0;
                            ViewHandler.ShowRightWindow("FrmInventoryMove_Drag");
                            break;
                        case "INV_InventoryAdjustmentsHead"://库存调整单
                            FrmInventoryAdjustments_Drag.queryIAHeadNo = orderNoStr;
                            FrmInventoryAdjustments_Drag.queryListAutoId = 0;
                            ViewHandler.ShowRightWindow("FrmInventoryAdjustments_Drag");
                            break;
                        case "INV_ReturnedGoodsReportHead"://退货单
                            FrmReturnedGoodsReport.queryRGRHeadNo = orderNoStr;
                            ViewHandler.ShowRightWindow("FrmReturnedGoodsReport");
                            break;

                        //生产
                        case "PB_ProductionScheduleBom"://生产视图登记
                            ViewHandler.ShowRightWindow("FrmPBDesignBom_PS");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击查询明细错误。", ex);
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
    }
}
