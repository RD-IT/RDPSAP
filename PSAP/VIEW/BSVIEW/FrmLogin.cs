using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PSAP.DAO.BSDAO;
using PSAP.BLL.BSBLL;
using PSAP.VIEW.BSVIEW;
using PSAP.PSAPCommon;
using System.Threading;

namespace PSAP
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            //txtUserID.Text = "ADMIN";//测试用
            //txtPassword.Text = "ADMIN";//测试用

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Close();
                Application.ExitThread();
                //System.Environment.Exit(0);
            }
            catch
            {

            }
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserID.Text == string.Empty)
                {
                    //MessageHandler.ShowMessageBox(string.Format("用户ID不能为空。"), "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageHandler.ShowMessageBox("用户ID不能为空。");
                    txtUserID.Focus();
                    return;
                }

                if (txtPassword.Text == string.Empty)
                {
                    //MessageHandler.ShowMessageBox(string.Format("密码不能为空。"), "用户登录", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageHandler.ShowMessageBox("密码不能为空。");
                    txtPassword.Focus();
                    return;
                }

                FileHandler fileHandler = new FileHandler();
                string iniPath = System.Windows.Forms.Application.StartupPath + "\\Config.ini";

                try
                {
                    //Data Source=192.168.0.3;Initial Catalog=PSAP;Persist Security Info=True;User ID=sa;Password=1qaz2wsx

                    string dataSourceStr = fileHandler.IniReadValue(iniPath, "System", "DataSource");
                    string userIDStr = fileHandler.IniReadValue(iniPath, "System", "UserID");
                    string passwordStr = fileHandler.IniReadValue(iniPath, "System", "Password");

                    BaseSQL.connectionString = BaseSQL.GetConnectionString(dataSourceStr, "PSAP", userIDStr, passwordStr);

                    string tempStr = BaseSQL.connectionString.Replace("Data Source=", "");
                    string ipAddressStr = tempStr.Substring(0, tempStr.IndexOf(";"));

                    if (!new SystemHandler().TestIPAddress(ipAddressStr, 1000))
                    {
                        MessageHandler.ShowMessageBox(string.Format("IP地址【{0}】连接不通，请确认客户端和服务端的网络是否正常。", ipAddressStr));
                        btnSet.Visible = true;
                        return;
                    }
                    if (!BaseSQL.TestSqlConnection())
                    {
                        MessageHandler.ShowMessageBox("服务端的数据库不能正常访问，请确认数据库是否正常");
                        btnSet.Visible = true;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageHandler.ShowMessageBox(ex.Message);
                    return;
                }

                EncryptMD5 en = new EncryptMD5(txtPassword.Text);//实例化EncryptMD5, 加密后值引用en.str2
                if (FrmLoginBLL.CheckUser(txtUserID.Text, en.str2, cboLanguage))// en.str2为加密后密码
                {
                    if (SystemInfo.user.IsDisable == 1)
                    {
                        MessageHandler.ShowMessageBox("当前用户已经停用，不可以登陆系统。");
                        txtUserID.Focus();
                        return;
                    }

                    new SystemHandler().InitializationSystemInfo(txtPassword.Text);

                    if (SystemInfo.IsCheckServer)//启动服务端检测
                    {
                        SocketHandler socket = new SocketHandler();
                        string messageStr = "";
                        if (!socket.ConnectServer(ref messageStr))
                        {
                            MessageHandler.ShowMessageBox(messageStr);
                            return;
                        }
                    }

                    fileHandler.IniWriteValue(iniPath, "System", "LastLanguage", cboLanguage.SelectedValue.ToString());

                    //Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    // cfa.AppSettings.Settings["last"].Value = "111";
                    //            cfa.Save();


                    Thread formThread = new Thread(ThreadInitializeForm);
                    formThread.Start();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--用户登录错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiYhdlcw.Text, ex);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FrmChangePassword f = new FrmChangePassword(txtUserID.Text.Trim());
            f.ShowDialog();
            txtUserID.Focus();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                FrmLoginBLL.InitCboLanguage(cboLanguage);
                PSAP.BLL.BSBLL.BSBLL.language(this);
                string iniPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase.TrimEnd('\\') + "\\Config.ini";
                //txtUserID.Text = new FileHandler().IniReadValue(iniPath, "System", "LastLoginID");
                txtUserID.Text = new GetLangusgeSet().IniReadValue1(iniPath, "System", "LastLoginID");

                //cboLanguage.SelectedValue = new FileHandler().IniReadValue(iniPath, "System", "LastLanguage");
                cboLanguage.SelectedValue = new GetLangusgeSet().IniReadValue1(iniPath, "System", "LastLanguage");

                if (SystemInfo.LoginSavePwd)
                {
                    //string pwdStr = new FileHandler().IniReadValue(iniPath, "System", "LastLoginPwd");
                    string pwdStr = new GetLangusgeSet().IniReadValue1(iniPath, "System", "LastLoginPwd");

                    if (pwdStr != "")
                        txtPassword.Text = pwdStr;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 单独线程初始化第一次加载速度慢的窗体
        /// </summary>
        private void ThreadInitializeForm()
        {
            try
            {
                using (FrmRight_UserMenuButton userForm = new FrmRight_UserMenuButton())
                {
                    userForm.FormBorderStyle = FormBorderStyle.None;
                    userForm.TopLevel = false;
                    userForm.Dock = DockStyle.Fill;
                    DevExpress.XtraEditors.PanelControl pnl = new DevExpress.XtraEditors.PanelControl();
                    pnl.Visible = false;
                    pnl.Controls.Add(userForm);
                    userForm.Show();
                    userForm.FrmRight_UserMenuButton_Load(null, null);
                    userForm.Dispose();
                    pnl.Dispose();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException_NoMessage("线程初始化窗体错误。", ex);
            }
        }

        /// <summary>
        /// 设置数据库配置
        /// </summary>
        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDBConfig dbConfig = new FrmDBConfig();
                dbConfig.ShowDialog();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException("设置数据库配置错误。", ex);
            }
        }
    }
}
