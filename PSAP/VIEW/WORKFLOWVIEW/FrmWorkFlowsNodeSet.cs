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
    public partial class FrmWorkFlowsNodeSet : DockContent
    {
        FrmWorkFlowsNodeLineSetDAO setDAO = new FrmWorkFlowsNodeLineSetDAO();
        /// <summary>
        /// 状态节点Id
        /// </summary>
        private int nodeIdInt = 0;

        /// <summary>
        /// 是否可以编辑流程图信息
        /// </summary>
        public bool isEditWorkFlows = true;

        public FrmWorkFlowsNodeSet(int nodeIdInt, string workFlowsTextStr, string nodeTextStr)
        {
            InitializeComponent();
            this.nodeIdInt = nodeIdInt;
            if(workFlowsTextStr!="")
                this.Text = string.Format("流程图【{0}】中的节点设定", workFlowsTextStr);

            textNodeText.Text = nodeTextStr;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWorkFlowsNodeSet_Load(object sender, EventArgs e)
        {
            try
            {
                if (nodeIdInt == 0)
                {
                    labEnabled.Visible = false;
                    checkEnabled.Visible = false;
                }

                DataTable nodeTable = setDAO.QueryWorkFlowsNode(nodeIdInt);
                if (nodeTable.Rows.Count > 0)
                {
                    checkEnabled.EditValue = DataTypeConvert.GetInt(nodeTable.Rows[0]["Enabled"]);
                    radioBeginNode.EditValue = DataTypeConvert.GetInt(nodeTable.Rows[0]["BeginNode"]);
                }

                if(!isEditWorkFlows)
                {
                    radioBeginNode.ReadOnly = true;
                }

                List<WorkFlowsHandleDAO.LineType> upLineTypeList = new List<WorkFlowsHandleDAO.LineType>();
                DataTable upLineTable = setDAO.QueryLineType_LevelNodeId(nodeIdInt);
                foreach(DataRow upLineRow in upLineTable.Rows)
                {
                    upLineTypeList.Add((WorkFlowsHandleDAO.LineType)upLineRow["LineType"]);
                }

                List<WorkFlowsHandleDAO.LineType> downLineTypeList = new List<WorkFlowsHandleDAO.LineType>();
                DataTable downLineTable = setDAO.QueryLineType_NodeId(nodeIdInt);
                foreach (DataRow downLineRow in downLineTable.Rows)
                {
                    downLineTypeList.Add((WorkFlowsHandleDAO.LineType)downLineRow["LineType"]);
                }

                if (upLineTypeList.Contains(WorkFlowsHandleDAO.LineType.审批))
                {
                    checkEnabled.Enabled = false;
                }

                if(downLineTypeList.Contains(WorkFlowsHandleDAO.LineType.提交))
                {
                    checkEnabled.Enabled = false;
                }

                textNodeText.Focus();
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
                if (textNodeText.Text.Trim() == "")
                {
                    MessageHandler.ShowMessageBox("节点名称不能为空，请重新输入。");
                    return;
                }
                if(!checkEnabled.Checked&& DataTypeConvert.GetInt(radioBeginNode.EditValue)==1)
                {
                    MessageHandler.ShowMessageBox("开始节点不可以停用。");
                    return;
                }

                if (nodeIdInt > 0)
                {
                    if (!setDAO.SaveWorkFlowsNode(nodeIdInt, textNodeText.Text.Trim(), DataTypeConvert.GetInt(checkEnabled.EditValue), DataTypeConvert.GetInt(radioBeginNode.EditValue)))
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

        private void radioBeginNode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataTypeConvert.GetInt(radioBeginNode.EditValue) == 1)
            {
                checkEnabled.Checked = true;
            }
        }
    }
}
