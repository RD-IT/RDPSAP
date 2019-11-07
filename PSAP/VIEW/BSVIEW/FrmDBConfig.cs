using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmDBConfig : Form
    {
        FileHandler fileHandler = new FileHandler();
        string iniPath = System.Windows.Forms.Application.StartupPath + "\\Config.ini";

        public FrmDBConfig()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmDBConfig_Load(object sender, EventArgs e)
        {
            try
            {
                textDataSource.Text = fileHandler.IniReadValue(iniPath, "System", "DataSource");
                textUserID.Text = fileHandler.IniReadValue(iniPath, "System", "UserID");
                textPassword.Text = fileHandler.IniReadValue(iniPath, "System", "Password");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 保存数据库配置信息
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(textDataSource.Text.Trim()=="")
                {
                    MessageHandler.ShowMessageBox("数据库IP地址不能为空，请重新输入。");
                    textDataSource.Focus();
                    return;
                }
                if (textUserID.Text.Trim() == "")
                {
                    MessageHandler.ShowMessageBox("用户名不能为空，请重新输入。");
                    textUserID.Focus();
                    return;
                }

                fileHandler.IniWriteValue(iniPath, "System", "DataSource", textDataSource.Text.Trim());
                fileHandler.IniWriteValue(iniPath, "System", "UserID", textUserID.Text.Trim());
                fileHandler.IniWriteValue(iniPath, "System", "Password", textPassword.Text.Trim());

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--保存数据库配置信息错误。", ex);
            }
        }

        /// <summary>
        /// 测试数据库配置信息是否正确
        /// </summary>
        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!new SystemHandler().TestIPAddress(textDataSource.Text.Trim(), 1000))
                {
                    MessageHandler.ShowMessageBox(string.Format("IP地址【{0}】连接不通，请确认客户端和服务端的网络是否正常。", textDataSource.Text.Trim()));
                    return;
                }
                if (!BaseSQL.TestSqlConnection(BaseSQL.GetConnectionString(textDataSource.Text.Trim(), "PSAP", textUserID.Text.Trim(), textPassword.Text.Trim())))
                {
                    MessageHandler.ShowMessageBox("服务端的数据库不能正常访问，请确认数据库是否正常");
                    return;
                }

                MessageHandler.ShowMessageBox("测试连接成功。");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--测试数据库配置信息是否正确错误。", ex);
            }
        }
    }
}
