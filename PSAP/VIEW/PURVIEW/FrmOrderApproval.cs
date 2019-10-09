using PSAP.DAO.INVDAO;
using PSAP.DAO.PBDAO;
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
    public partial class FrmOrderApproval : DockContent
    {
        /// <summary>
        /// 采购单号
        /// </summary>
        string orderHeadNoStr = "";

        FrmApprovalDAO approvalDAO = new FrmApprovalDAO();
        static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();

        public FrmOrderApproval()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(f);
            PSAP.BLL.BSBLL.BSBLL.language(this);
        }

        public FrmOrderApproval(string orderHeadNo)
        {
            InitializeComponent();
            this.orderHeadNoStr = orderHeadNo;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmApprovalOrder_Load(object sender, EventArgs e)
        {
            try
            {
                lookUpApprovalType.Properties.DataSource = new DAO.BSDAO.FrmCommonDAO().QueryApprovalType(false);
                switch(orderHeadNoStr.Substring(0,2))
                {
                    case "PR"://请购单
                        approvalDAO.QueryPrReqHead(dataSet_Order.Tables[0], orderHeadNoStr);
                        break;
                    case "PO"://采购订单
                        approvalDAO.QueryOrderHead(dataSet_Order.Tables[0], orderHeadNoStr);
                        break;
                    case "PS"://采购结账单
                        approvalDAO.QuerySettlementHead(dataSet_Order.Tables[0], orderHeadNoStr);
                        break;

                    case "WW"://入库单
                        approvalDAO.QueryWarehouseWarrantHead(dataSet_Order.Tables[0], orderHeadNoStr);
                        break;
                    case "WR"://材料出库单
                        approvalDAO.QueryWarehouseReceiptHead(dataSet_Order.Tables[0], orderHeadNoStr);
                        break;
                    case "SW"://预算外入库单
                        approvalDAO.QuerySpecialWarehouseWarrantHead(dataSet_Order.Tables[0], orderHeadNoStr);
                        break;
                    case "SR"://预算外出库单
                        approvalDAO.QuerySpecialWarehouseReceiptHead(dataSet_Order.Tables[0], orderHeadNoStr);
                        break;
                    case "RG"://退货单
                        approvalDAO.QueryReturnedGoodsReportHead(dataSet_Order.Tables[0], orderHeadNoStr);
                        break;
                    case "IA"://库存调整单
                        approvalDAO.QueryInventoryAdjustmentsHead(dataSet_Order.Tables[0], orderHeadNoStr);
                        break;
                    case "IM"://库存移动单
                        approvalDAO.QueryInventoryMoveHead(dataSet_Order.Tables[0], orderHeadNoStr);
                        break;

                    case "PP"://工单
                        approvalDAO.QueryProductionPlan(dataSet_Order.Tables[0], orderHeadNoStr);
                        break;
                }
                if (dataSet_Order.Tables[0].Rows.Count == 0)
                {
                    MessageHandler.ShowMessageBox("查询单据信息错误，请重新操作。");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }

                string typeNoStr = DataTypeConvert.GetString(dataSet_Order.Tables[0].Rows[0]["ApprovalType"]);
                int approvalCatInt = DataTypeConvert.GetInt(dataSet_Order.Tables[0].Rows[0]["ApprovalCat"]);
                approvalDAO.QueryOrderApprovalInfo(dataSet_Order.Tables[1], orderHeadNoStr, typeNoStr);

                if (approvalCatInt == 0)
                {
                    for (int i = 0; i < dataSet_Order.Tables[1].Rows.Count; i++)
                    {
                        if (DataTypeConvert.GetString(dataSet_Order.Tables[1].Rows[i]["OrderHeadNo"]) == "")
                        {
                            if (DataTypeConvert.GetInt(dataSet_Order.Tables[1].Rows[i]["Approver"]) != SystemInfo.user.AutoId)
                                btnApproval.Enabled = false;
                            else
                                btnApproval.Enabled = true;
                            return;
                        }
                    }
                }
                else if (approvalCatInt == 1 || approvalCatInt == 2)
                {
                    if (dataSet_Order.Tables[1].Select(string.Format("IsNull(OrderHeadNo,'')='' and Approver={0}", SystemInfo.user.AutoId)).Length == 0)
                    {
                        btnApproval.Enabled = false;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiCtjzsjcw.Text, ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewOrderAppInfo_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewOrderAppInfo_KeyDown(object sender, KeyEventArgs e)
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
        /// 设定状态显示文字
        /// </summary>
        private void textReqState_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null)
            {
                e.DisplayText = CommonHandler.Get_OrderState_Desc(e.Value.ToString());
            }
        }

        /// <summary>
        /// 设定审批方式显示文字
        /// </summary>
        private void textApprovalCat_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null)
            {
                e.DisplayText = CommonHandler.Get_ApprovalCat_Desc(e.Value.ToString());
            }
        }

        /// <summary>
        /// 审批按钮事件
        /// </summary>
        private void btnApproval_Click(object sender, EventArgs e)
        {
            try
            {
                dataSet_Order.Tables[0].Rows[0]["Select"] = true;
                int successCountInt = 0;
                int approverResultInt = 1;
                switch (orderHeadNoStr.Substring(0, 2))
                {
                    case "PR":
                        //#region 请购单
                        //{
                        //    FrmWorkFlowDataHandle wfDataHandle = new FrmWorkFlowDataHandle();
                        //    wfDataHandle.orderNameStr = "请购单";
                        //    wfDataHandle.dataNoList = new List<string>() { orderHeadNoStr };
                        //    wfDataHandle.workFlowTypeText = "采购流程";
                        //    wfDataHandle.tableNameStr = "PUR_PrReqHead";
                        //    wfDataHandle.moduleTypeInt = 2;
                        //    if (wfDataHandle.ShowDialog() == DialogResult.OK)
                        //    {
                        //        int nodeIdInt = wfDataHandle.nodeIdInt;
                        //        string flowModuleIdStr = wfDataHandle.flowModuleIdStr;
                        //        string approverOptionStr = wfDataHandle.memoApproverOption.Text;
                        //        approverResultInt = DataTypeConvert.GetInt(wfDataHandle.radioApproverResult.EditValue);

                        //        if (!new FrmPrReqDAO().PrReqApprovalInfo_Multi(dataSet_Order.Tables[0], nodeIdInt, flowModuleIdStr, approverOptionStr, approverResultInt, ref successCountInt))
                        //        {

                        //        }
                        //    }
                        //}
                        //#endregion
                        break;
                    case "PO":
                        //#region 采购订单
                        //{
                        //    FrmWorkFlowDataHandle wfDataHandle = new FrmWorkFlowDataHandle();
                        //    wfDataHandle.orderNameStr = "采购订单";
                        //    wfDataHandle.dataNoList = new List<string>() { orderHeadNoStr };
                        //    wfDataHandle.workFlowTypeText = "采购流程";
                        //    wfDataHandle.tableNameStr = "PUR_OrderHead";
                        //    wfDataHandle.moduleTypeInt = 2;
                        //    if (wfDataHandle.ShowDialog() == DialogResult.OK)
                        //    {
                        //        int nodeIdInt = wfDataHandle.nodeIdInt;
                        //        string flowModuleIdStr = wfDataHandle.flowModuleIdStr;
                        //        string approverOptionStr = wfDataHandle.memoApproverOption.Text;
                        //        approverResultInt = DataTypeConvert.GetInt(wfDataHandle.radioApproverResult.EditValue);

                        //        if (!new FrmOrderDAO().OrderApprovalInfo_Multi(dataSet_Order.Tables[0], nodeIdInt, flowModuleIdStr, approverOptionStr, approverResultInt, ref successCountInt))
                        //        {

                        //        }
                        //    }
                        //}
                        //#endregion
                        break;
                    case "PS"://采购结账单
                        new FrmSettlementDAO().SettlementApprovalInfo_Multi(dataSet_Order.Tables[0], ref successCountInt);
                        break;

                    case "WW"://入库单
                        new FrmWarehouseWarrantDAO().WWApprovalInfo_Multi(dataSet_Order.Tables[0], ref successCountInt);
                        break;
                    case "WR"://材料出库单
                        new FrmWarehouseReceiptDAO().WRApprovalInfo_Multi(dataSet_Order.Tables[0], ref successCountInt);
                        break;
                    case "SW"://预算外入库单
                        new FrmSpecialWarehouseWarrantDAO().SWWApprovalInfo_Multi(dataSet_Order.Tables[0], ref successCountInt);
                        break;
                    case "SR"://预算外出库单
                        new FrmSpecialWarehouseReceiptDAO().SWRApprovalInfo_Multi(dataSet_Order.Tables[0], ref successCountInt);
                        break;
                    case "RG"://退货单
                        new FrmReturnedGoodsReportDAO().RGRApprovalInfo_Multi(dataSet_Order.Tables[0], ref successCountInt);
                        break;
                    case "IA"://库存调整单
                        new FrmInventoryAdjustmentsDAO().IAApprovalInfo_Multi(dataSet_Order.Tables[0], ref successCountInt);
                        break;
                    case "IM"://库存移动单
                        new FrmInventoryMoveDAO().IMApprovalInfo_Multi(dataSet_Order.Tables[0], ref successCountInt);
                        break;

                    case "PP":
                        //#region 工单
                        //{
                        //    FrmWorkFlowDataHandle wfDataHandle = new FrmWorkFlowDataHandle();
                        //    wfDataHandle.orderNameStr = "工单";
                        //    wfDataHandle.dataNoList = new List<string>() { orderHeadNoStr };
                        //    wfDataHandle.workFlowTypeText = "生产流程";
                        //    wfDataHandle.tableNameStr = "PB_ProductionPlan";
                        //    wfDataHandle.moduleTypeInt = 2;
                        //    if (wfDataHandle.ShowDialog() == DialogResult.OK)
                        //    {
                        //        int nodeIdInt = wfDataHandle.nodeIdInt;
                        //        string flowModuleIdStr = wfDataHandle.flowModuleIdStr;
                        //        string approverOptionStr = wfDataHandle.memoApproverOption.Text;
                        //        approverResultInt = DataTypeConvert.GetInt(wfDataHandle.radioApproverResult.EditValue);

                        //        if (!new FrmProductionPlanDAO().PPlanApprovalInfo_Multi(dataSet_Order.Tables[0], nodeIdInt, flowModuleIdStr, approverOptionStr, approverResultInt, ref successCountInt))
                        //        {

                        //        }
                        //    }
                        //}
                        //#endregion
                        break;
                }

                if (successCountInt > 0)
                {
                    if (approverResultInt == 1)
                        MessageHandler.ShowMessageBox("审批成功。");
                    else
                        MessageHandler.ShowMessageBox("审批拒绝。");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--审批按钮事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiSpansj.Text, ex);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
