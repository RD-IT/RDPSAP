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
    public partial class FrmWorkFlowDataHandle : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmWorkFlowModuleDAO modDAO = new FrmWorkFlowModuleDAO();
        FrmWorkFlowDataHandleDAO dataHandleDAO = new FrmWorkFlowDataHandleDAO();

        /// <summary>
        /// 单据名称
        /// </summary>
        public string orderNameStr = "";

        /// <summary>
        /// 单据号列表
        /// </summary>
        public List<string> dataNoList = new List<string>();

        /// <summary>
        /// 流程类型名称  销售流程，采购流程，库存流程，人事流程
        /// </summary>
        public string workFlowTypeText = "";

        /// <summary>
        /// 数据表名称
        /// </summary>
        public string tableNameStr = "";

        /// <summary>
        /// 模块类型编号  1 制单 2 审核
        /// </summary>
        public int moduleTypeInt = 2;

        /// <summary>
        /// 业务模块ID 返回信息
        /// </summary>
        public string flowModuleIdStr = "";

        /// <summary>
        /// 流程结点ID 返回信息
        /// </summary>
        public int nodeIdInt = 0;

        public FrmWorkFlowDataHandle()
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
                DataTable wfNodeTable = dataHandleDAO.ModuleGetWorkFlowNode(workFlowTypeText, tableNameStr, moduleTypeInt);
                if (wfNodeTable.Rows.Count == 0)
                {
                    MessageHandler.ShowMessageBox("未查询到当前操作所属的流程节点信息，请在系统里登记模块流程信息。");
                    this.Close();
                    return;
                }

                flowModuleIdStr = DataTypeConvert.GetString(wfNodeTable.Rows[0]["FlowModuleId"]);
                nodeIdInt = DataTypeConvert.GetInt(wfNodeTable.Rows[0]["AutoId"]);

                lookUpNodeText.Properties.DataSource = dataHandleDAO.QueryWorkFlowNode();
                lookUpWorkFlowModule.Properties.DataSource = modDAO.QueryWorkFlowModule(false);
                lookUpPrepared.Properties.DataSource = commonDAO.QueryUserInfo(false);

                string dataNoStrs = "";
                foreach (string dataNo in dataNoList)
                {
                    dataNoStrs += dataNo + ",";
                }

                textDataNo.Text = dataNoStrs.Substring(0, dataNoStrs.Length - 1);
                lookUpNodeText.EditValue = nodeIdInt;
                lookUpWorkFlowModule.EditValue = flowModuleIdStr;
                lookUpPrepared.EditValue = SystemInfo.user.LoginID;
                memoApproverOption.Text = "";
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
                if (memoApproverOption.Text == "")
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
