using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmProjectStatus : DockContent
    {
        FrmBaseEdit editForm = null;
        FrmProjectStatusDAO statusDAO = new FrmProjectStatusDAO();

        public FrmProjectStatus()
        {
            InitializeComponent();

            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.TopLevel = false;
                    editForm.TableName = "BS_ProjectStatus";
                    editForm.TableCaption = "项目状态信息";
                    editForm.Sql = "select * from BS_ProjectStatus order by AutoId";
                    editForm.PrimaryKeyColumn = "AutoId";
                    editForm.MasterDataSet = dSProjectStatus;
                    editForm.MasterBindingSource = bSProjectStatus;
                    editForm.MasterEditPanel = pnlEdit;
                    //editForm.PrimaryKeyControl = textShelfNo;
                    editForm.BrowseXtraGridView = gridViewProjectStatus;
                    editForm.CheckControl += CheckControl;
                    editForm.SaveRowBefore += SaveRowBefore;
                    editForm.SaveRowAfter += SaveRowAfter;
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
        private void FrmProjectStatus_Load(object sender, EventArgs e)
        {
            try
            {

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
            if (textStatusText.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("状态名称不能为空，请重新操作。");
                textStatusText.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存之前进行默认标志检测
        /// </summary>
        public bool SaveRowBefore(DataRow dr, SqlCommand cmd)
        {
            if (statusDAO.GetProjectStatus_DefaultCount(DataTypeConvert.GetInt(dr["AutoId"])) == 0)
            {
                dr["IsDefault"] = 1;
            }

            return true;
        }

        /// <summary>
        /// 保存之后更新其他记录的默认标志
        /// </summary>
        public bool SaveRowAfter(DataRow dr, SqlCommand cmd)
        {
            if (DataTypeConvert.GetInt(dr["IsDefault"]) == 1)
            {
                int autoIdInt = DataTypeConvert.GetInt(dr["AutoId"]);

                if (autoIdInt == 0)
                {
                    cmd.CommandText = "select @@identity";
                    autoIdInt = DataTypeConvert.GetInt(cmd.ExecuteScalar());
                }

                statusDAO.UpdateProjectStatus_SetNoDefault(cmd, autoIdInt, 0);
            }

            return true;
        }

        /// <summary>
        /// 设定默认值
        /// </summary>
        private void TableProjectStatus_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (statusDAO.GetProjectStatus_DefaultCount(0) > 0)
            {
                e.Row["IsDefault"] = 0;
            }
            else
            {
                e.Row["IsDefault"] = 1;
            }
        }
    }
}
