using PSAP.DAO.BSDAO;
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
    public partial class FrmCompanyInfo : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmCompanyInfoDAO companyDAO = new FrmCompanyInfoDAO();

        public FrmCompanyInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件 
        /// </summary>
        private void FrmCompanyInfo_Load(object sender, EventArgs e)
        {
            try
            {
                QueryCompanyInfo();
                textCompanyName.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 保存公司信息
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                bindingSource_CompanyInfo.EndEdit();
                DataRow headRow = ((DataRowView)bindingSource_CompanyInfo.Current).Row;
                if (companyDAO.SaveCompanyInfo(headRow))
                {
                    MessageHandler.ShowMessageBox("保存公司信息成功。");
                    QueryCompanyInfo();
                    companyDAO.RefreshCompanyInfo();
                }
                else
                {
                    MessageHandler.ShowMessageBox("保存失败。");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--保存系统设定错误。", ex);
            }
        }

        /// <summary>
        /// 查询公司信息
        /// </summary>
        private void QueryCompanyInfo()
        {
            TableCompanyInfo.Rows.Clear();
            companyDAO.QueryCompanyInfo(TableCompanyInfo);
            if (TableCompanyInfo.Rows.Count == 0)
            {
                DataRow row = TableCompanyInfo.NewRow();
                TableCompanyInfo.Rows.Add(row);
                bindingSource_CompanyInfo.MoveLast();
            }
            Set_ButtonEditGrid_State(false);
        }

        /// <summary>
        /// 设定按钮编辑区列表区的状态
        /// </summary>
        private void Set_ButtonEditGrid_State(bool state)
        {
            BtnSave.Enabled = !state;

            textCompanyName.ReadOnly = state;
            textCompanyAddress.ReadOnly = state;
            textCompanyLR.ReadOnly = state;
            textCompanyLicense.ReadOnly = state;
            textZipCode.ReadOnly = state;
            textPhoneNo.ReadOnly = state;
            textFaxNo.ReadOnly = state;
            textE_mail.ReadOnly = state;
            textWebSite.ReadOnly = state;
        }
    }
}
