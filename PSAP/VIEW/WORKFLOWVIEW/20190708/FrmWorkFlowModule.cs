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
    public partial class FrmWorkFlowModule : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmBaseEdit editForm = null;
        FrmWorkFlowModuleDAO wfDAO = new FrmWorkFlowModuleDAO();

        public FrmWorkFlowModule()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWorkFlowModule_Load(object sender, EventArgs e)
        {
            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.TopLevel = false;
                    editForm.TableName = "BS_WorkFlowModule";
                    editForm.TableCaption = "审核流-业务模块";
                    editForm.Sql = "select * from BS_WorkFlowModule order by AutoId";
                    editForm.PrimaryKeyColumn = "FlowModuleId";
                    editForm.MasterDataSet = dSWorkFlowModule;
                    editForm.MasterBindingSource = bSWorkFlowModule;
                    editForm.MasterEditPanel = pnlEdit;
                    editForm.PrimaryKeyControl = textFlowModuleId;
                    //editForm.OtherNoChangeControl = new List<Control>() { textProjectName };
                    editForm.ButtonList.Add(btnModuleProper);
                    editForm.BrowseXtraGridView = gridViewWorkFlowModule;
                    editForm.CheckControl += CheckControl;
                    this.pnlToolBar.Controls.Add(editForm);
                    editForm.Dock = DockStyle.Fill;
                    editForm.Show();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 保存之前的回调方法
        /// </summary>
        public bool CheckControl()
        {
            if (textFlowModuleId.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("模块编号不能为空，请重新操作。");
                textFlowModuleId.Focus();
                return false;
            }
            if (textFlowModuleText.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("模块名称不能为空，请重新操作。");
                textFlowModuleText.Focus();
                return false;
            }
            if (textFlowModuleFormName.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("项目窗体名称不能为空，请重新操作。");
                textFlowModuleFormName.Focus();
                return false;
            }
            if (textFlowModuleTableName.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("数据库表名不能为空，请重新操作。");
                textFlowModuleTableName.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 自动生成业务模块的字段
        /// </summary>
        private void btnModuleProper_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gridViewWorkFlowModule.GetFocusedDataRow();
                if (dr !=null)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确实生成业务模块的字段吗？\r\n（如果之前已经生成将直接进行覆盖）") == DialogResult.Yes)
                    {
                        string flowModuleIdStr = DataTypeConvert.GetString(dr["FlowModuleId"]);
                        string tableNameStr = DataTypeConvert.GetString(dr["FlowModuleTableName"]);
                        if (wfDAO.Insert_WorkFlowModuleProper(flowModuleIdStr, tableNameStr))
                            MessageHandler.ShowMessageBox("生成业务模块字段成功。");
                        else
                            textFlowModuleTableName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--自动生成业务模块的字段错误。", ex);
            }
        }


    }
}
