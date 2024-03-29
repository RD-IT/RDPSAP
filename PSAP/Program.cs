﻿using System;
using System.Windows.Forms;
using System.Configuration;
using PSAP.PSAPCommon;
using PSAP.DAO.BSDAO;
using System.Diagnostics;

namespace PSAP.VIEW.BSVIEW
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            ConfigurationManager.RefreshSection("PSAP.Properties.Settings.PSAPConnectionString");//重新加载新的配置文件  
            ConfigurationManager.RefreshSection("ThemeId");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            
            FrmLogin frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                //if (PSAPCommon.LoginInfo != null)
                if (SystemInfo.user != null)
                {
                    //等系统正式启用再初始加载系统默认参数
                    new FrmSystemDAO().RefreshAllSystemParameter();
                    new FrmCompanyInfoDAO().RefreshCompanyInfo();
                    new FrmMainDAO().RefreshUserButtonPower();

                    FrmMain frmMain = new FrmMain();
                    frmMain.WindowState = FormWindowState.Maximized;
                    Application.Run(frmMain);

                    if(SystemInfo.IsCheckServer)
                        new SocketHandler().DisconnectServer(SocketHandler.clientSocket);

                    CloseAllProcess();
                }
            }
        }

        /// <summary>
        /// 关闭所有调用的进程
        /// </summary>
        private static void CloseAllProcess()
        {
            Process[] Pros = Process.GetProcessesByName("SWPreview");
            foreach (Process p in Pros)
            {
                p.Kill();
            }
        }
    }
}
