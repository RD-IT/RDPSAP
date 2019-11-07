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
    public partial class FrmWorkFlowsDataHandle : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        WorkFlowsHandleDAO wfHandleDAO = new WorkFlowsHandleDAO();

        /// <summary>
        /// 单据名称
        /// </summary>
        public string orderNameStr = "";

        /// <summary>
        /// 单据号列表
        /// </summary>
        public List<string> dataNoList = new List<string>();

        /// <summary>
        /// 订单类型
        /// </summary>
        public WorkFlowsHandleDAO.OrderType orderType;

        public FrmWorkFlowsDataHandle()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWorkFlowDataHandle_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = orderNameStr + "单据处理";
                lookUpPrepared.Properties.DataSource = commonDAO.QueryUserInfo_OnlyColumn(false);

                string dataNoStrs = "";
                foreach (string dataNo in dataNoList)
                {
                    dataNoStrs += dataNo + ",";
                }

                textDataNo.Text = dataNoStrs.Substring(0, dataNoStrs.Length - 1);
                lookUpPrepared.EditValue = SystemInfo.user.AutoId;
                memoApproverOption.Text = "";

                if (!wfHandleDAO.MultiOrderWorkFlowsIsPower(orderType, WorkFlowsHandleDAO.LineType.审批, dataNoList))
                {
                    for (int i = 0; i < radioApproverResult.Properties.Items.Count; i++)
                    {
                        if (radioApproverResult.Properties.Items[i].Description == "同意")
                        {
                            radioApproverResult.Properties.Items.RemoveAt(i);
                            break;
                        }
                    }
                }
                if (!wfHandleDAO.MultiOrderWorkFlowsIsPower(orderType, WorkFlowsHandleDAO.LineType.拒绝, dataNoList))
                {
                    for (int i = 0; i < radioApproverResult.Properties.Items.Count; i++)
                    {
                        if (radioApproverResult.Properties.Items[i].Description == "不同意")
                        {
                            radioApproverResult.Properties.Items.RemoveAt(i);
                            break;
                        }
                    }
                }
                if (radioApproverResult.Properties.Items.Count == 0)
                {
                    MessageHandler.ShowMessageBox("您选择的登记单包含没有操作登记单[审批]和[拒绝]的权限，请联系管理员调整权限后再进行操作。");
                    this.Close();
                    return;
                }

                radioApproverResult.SelectedIndex = 0;

                memoApproverOption.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确认按钮事件
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (memoApproverOption.Text.Trim() == "")
                {
                    MessageHandler.ShowMessageBox("审批意见不能为空，请重新填写。");
                    memoApproverOption.Focus();
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确认按钮事件错误。", ex);
            }
        }
    }
}
