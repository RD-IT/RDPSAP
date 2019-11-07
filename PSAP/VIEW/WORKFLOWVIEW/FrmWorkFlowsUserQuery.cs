using DevExpress.XtraGrid.Views.Grid;
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
    public partial class FrmWorkFlowsUserQuery : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmWorkFlowsNodeLineSetDAO setDAO = new FrmWorkFlowsNodeLineSetDAO();
        WorkFlowsHandleDAO handleDAO = new WorkFlowsHandleDAO();

        public FrmWorkFlowsUserQuery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWorkFlowsUserQuery_Load(object sender, EventArgs e)
        {
            try
            {
                repLookUpCurrentNodeId.DataSource = setDAO.QueryWorkFlowsNode();
                repLookUpWorkFlowsType.DataSource = DataTypeConvert.EnumToDataTable(typeof(WorkFlowsHandleDAO.OrderType), "OrderType", "TypeId");
                repLookUpLineType.DataSource = DataTypeConvert.EnumToDataTable(typeof(WorkFlowsHandleDAO.LineType), "LineType", "TypeId");
                repLookUpNextWorkFlowsType.DataSource = DataTypeConvert.EnumToDataTable(typeof(WorkFlowsHandleDAO.NextWorkFlowsType), "NextWorkFlowsType", "NextTypeId");

                btnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 查询用户工作流提醒信息
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                dataSet_UserWorkFlow.Tables[0].Rows.Clear();
                handleDAO.QueryUserWorkFlows_Table(dataSet_UserWorkFlow.Tables[0]);

                PageWorkFlowsInfo.Text = string.Format("您有{0}个登记单需要处理", dataSet_UserWorkFlow.Tables[0].DefaultView.ToTable(true, "DataNo").Rows.Count);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询用户工作流提醒信息错误。", ex);
            }
        }

        /// <summary>
        /// 窗体激活事件
        /// </summary>
        private void FrmWorkFlowsUserQuery_Activated(object sender, EventArgs e)
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
        /// 确定行号
        /// </summary>
        private void gridViewUserWorkFlow_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewUserWorkFlow_KeyDown(object sender, KeyEventArgs e)
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
        /// 设定列表显示信息
        /// </summary>
        private void gridViewUserWorkFlow_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "CurrentState")
            {
                e.DisplayText = CommonHandler.Get_OrderState_Desc(e.Value.ToString());
            }
        }

        /// <summary>
        /// 设置Grid单元格合并
        /// </summary>
        private void gridViewUserWorkFlow_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                string firstColumnFieldName = "DataNo";

                switch (e.Column.FieldName)
                {
                    case "CurrentState":
                    case "CurrentNodeId":
                    case "ApproverLevel":
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

        /// <summary>
        /// 双击查询用户处理信息明细
        /// </summary>
        private void gridViewUserWorkFlow_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    int workFlowsTypeInt = DataTypeConvert.GetInt(gridViewUserWorkFlow.GetFocusedDataRow()["WorkFlowsType"]);
                    int lineTypeInt = DataTypeConvert.GetInt(gridViewUserWorkFlow.GetFocusedDataRow()["LineType"]);
                    string dataNoStr= DataTypeConvert.GetString(gridViewUserWorkFlow.GetFocusedDataRow()["DataNo"]);
                    OpenRelationForm(workFlowsTypeInt, lineTypeInt, dataNoStr);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击查询用户处理信息明细错误。", ex);
            }
        }

        /// <summary>
        /// 打开相关窗体
        /// </summary>
        private void OpenRelationForm(int workFlowsTypeInt, int lineTypeInt, string dataNoStr)
        {
            string formNameStr = "";
            switch (workFlowsTypeInt)
            {
                case (int)WorkFlowsHandleDAO.OrderType.请购单:
                    switch (lineTypeInt)
                    {
                        case (int)WorkFlowsHandleDAO.LineType.保存:
                            formNameStr = "FrmOrder_Drag";
                            if (!commonDAO.QueryUserFormPower(formNameStr))
                                return;
                            FrmOrder_Drag.queryPrReqNo = dataNoStr;
                            FrmOrder_Drag.queryOrderHeadNo = "";
                            FrmOrder_Drag.queryListAutoId = 0;
                            break;
                        case (int)WorkFlowsHandleDAO.LineType.任务分配:
                            formNameStr = "FrmPrReqListDistribution";
                            if (!commonDAO.QueryUserFormPower(formNameStr))
                                return;
                            FrmPrReqListDistribution.queryPrReqNo = dataNoStr;
                            break;
                        default:
                            formNameStr = "FrmPrReq";
                            if (!commonDAO.QueryUserFormPower(formNameStr))
                                return;
                            FrmPrReq.queryPrReqNo = dataNoStr;
                            FrmPrReq.queryListAutoId = 0;
                            break;
                    }
                    break;
                case (int)WorkFlowsHandleDAO.OrderType.采购订单:
                    switch (lineTypeInt)
                    {
                        case (int)WorkFlowsHandleDAO.LineType.保存:
                            formNameStr = "FrmWarehouseWarrant_Drag";
                            if (!commonDAO.QueryUserFormPower(formNameStr))
                                return;
                            FrmWarehouseWarrant_Drag.queryOrderHeadNo = dataNoStr;
                            FrmWarehouseWarrant_Drag.queryWWHeadNo = "";
                            FrmWarehouseWarrant_Drag.queryListAutoId = 0;
                            break;
                        default:
                            formNameStr = "FrmOrder_Drag";
                            if (!commonDAO.QueryUserFormPower(formNameStr))
                                return;
                            FrmOrder_Drag.queryOrderHeadNo = dataNoStr;
                            FrmOrder_Drag.queryListAutoId = 0;
                            break;
                    }
                    break;
                case (int)WorkFlowsHandleDAO.OrderType.工单:
                    formNameStr = "FrmProductionPlan";
                    if (!commonDAO.QueryUserFormPower(formNameStr))
                        return;
                    FrmProductionPlan.queryPlanNo = dataNoStr;
                    break;
            }

            ViewHandler.ShowRightWindow(formNameStr);
        }

    }
}
