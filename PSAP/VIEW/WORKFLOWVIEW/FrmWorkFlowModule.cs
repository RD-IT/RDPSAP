using PSAP.DAO.BSDAO;
using PSAP.DAO.WORKFLOWDAO;
using PSAP.PSAPCommon;
using System;
using System.Data;
using System.Data.SqlClient;
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

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public FrmWorkFlowModule()
        {
            InitializeComponent();

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
                    editForm.SaveRowBefore += SaveRowBefore;
                    editForm.DeleteRowBefore += DeleteRowBefore;
                    this.pnlToolBar.Controls.Add(editForm);
                    editForm.Dock = DockStyle.Fill;
                    editForm.Show();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体构造函数错误。", ex);
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWorkFlowModule_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable moduleTypeTable = wfDAO.QueryModuleType();

                lookUpFlowModuleTableName.Properties.DataSource = wfDAO.QueryModuleTableInfo();
                lookUpModuleType.Properties.DataSource = moduleTypeTable;
                repLookUpModuleType.DataSource = moduleTypeTable;
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
            //if (lookUpFlowModuleTableName.ItemIndex < 0)
            //{
            //    MessageHandler.ShowMessageBox("数据库表名不能为空，请重新操作。");
            //    lookUpFlowModuleTableName.Focus();
            //    return false;
            //}
            if (lookUpFlowModuleTableName.ItemIndex > 0)
            {
                if (!wfDAO.QueryTableNameIsExists(lookUpFlowModuleTableName.Text.Trim()))
                {
                    MessageHandler.ShowMessageBox("数据库表名在数据库中不存在，请重新填写。");
                    lookUpFlowModuleTableName.Focus();
                    return false;
                }

                if (lookUpModuleType.ItemIndex < 0)
                {
                    MessageHandler.ShowMessageBox("业务类型不能为空，请重新操作。");
                    lookUpModuleType.Focus();
                    return false;
                }
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
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                DataRow dr = gridViewWorkFlowModule.GetFocusedDataRow();
                if (dr != null)
                {
                    string tableNameStr = DataTypeConvert.GetString(dr["FlowModuleTableName"]);
                    if(tableNameStr == "")
                    {
                        MessageHandler.ShowMessageBox("数据库表名未空，不能自动生成业务模块的字段。");
                        return;
                    }

                    if (MessageHandler.ShowMessageBox_YesNo("确实生成业务模块的字段吗？\r\n（如果之前已经生成将直接进行覆盖）") == DialogResult.Yes)
                    {
                        string flowModuleIdStr = DataTypeConvert.GetString(dr["FlowModuleId"]);
                        if (wfDAO.Insert_WorkFlowModuleProper(flowModuleIdStr, tableNameStr))
                            MessageHandler.ShowMessageBox("生成业务模块字段成功。");
                        else
                            lookUpFlowModuleTableName.Focus();
                    }
                }

                //
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--自动生成业务模块的字段错误。", ex);
            }
        }

        /// <summary>
        /// 保存之前信息检查
        /// </summary>
        private bool SaveRowBefore(DataRow dr, SqlCommand cmd)
        {
            if (dr.RowState != DataRowState.Added)
            {
                if (wfDAO.QueryModuleIsUse(cmd, DataTypeConvert.GetString(dr["FlowModuleId"])))
                {
                    MessageHandler.ShowMessageBox("有流程图在使用当前业务模块，不可以修改。");
                    return false;
                }
            }
            if(DataTypeConvert.GetString(dr["FlowModuleTableName"])!="")
            {
                dr["FlowModulePrimaryKey"] = lookUpFlowModuleTableName.GetColumnValue("MPrimaryKey");
            }

            return true;
        }

        /// <summary>
        /// 删除之前清空子表
        /// </summary>
        private bool DeleteRowBefore(DataRow dr, SqlCommand cmd)
        {
            cmd.CommandText = string.Format("delete from BS_WorkFlowModuleProper where FlowModuleId = '{0}'", DataTypeConvert.GetString(dr["FlowModuleId",DataRowVersion.Original]));
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
