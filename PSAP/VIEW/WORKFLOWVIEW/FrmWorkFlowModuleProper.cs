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
    public partial class FrmWorkFlowModuleProper : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmBaseEdit editForm = null;
        FrmWorkFlowModuleDAO wfDAO = new FrmWorkFlowModuleDAO();

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public FrmWorkFlowModuleProper()
        {
            InitializeComponent();

            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.TopLevel = false;
                    editForm.TableName = "BS_WorkFlowModuleProper";
                    editForm.TableCaption = "审核流-模块字段";
                    editForm.Sql = "select BS_WorkFlowModuleProper.*, BS_WorkFlowModule.FlowModuleText from BS_WorkFlowModuleProper left join BS_WorkFlowModule on BS_WorkFlowModuleProper.FlowModuleId = BS_WorkFlowModule.FlowModuleId order by AutoId";
                    editForm.PrimaryKeyColumn = "AutoId";
                    editForm.MasterDataSet = dSWorkFlowModuleProper;
                    editForm.MasterBindingSource = bSWorkFlowModuleProper;
                    editForm.MasterEditPanel = pnlEdit;
                    //editForm.PrimaryKeyControl = textFlowModuleId;
                    editForm.OtherNoChangeControl = new List<Control>() { searchLookUpFlowModuleId, textProperName, searchLookUplabProper };
                    editForm.BrowseXtraGridView = gridViewWorkFlowModuleProper;
                    //editForm.CheckControl += CheckControl;
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
        private void FrmWorkFlowModuleProper_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTypeTable = wfDAO.QueryDataTypeView();

                searchLookUpFlowModuleId.Properties.DataSource = wfDAO.QueryWorkFlowModule(false);
                searchLookUplabProper.Properties.DataSource = dataTypeTable;

                //repItemSearchFlowModuleId.DataSource = wfDAO.QueryWorkFlowModule(false);
                repItemSearchProper.DataSource = dataTypeTable;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void searchLookUpFlowModuleIdView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

    }
}
