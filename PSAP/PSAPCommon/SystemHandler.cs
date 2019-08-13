using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Drawing;
using System.Net.NetworkInformation;

namespace PSAP.PSAPCommon
{
    class SystemHandler
    {
        static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();
        public SystemHandler()
        {
            PSAP.BLL.BSBLL.BSBLL.language(f);
        }

        /// <summary>
        /// 获取本机名
        /// </summary>
        public string GetHostName()
        {
            return Dns.GetHostName();
        }

        /// <summary>
        /// 获取本机的IP地址
        /// </summary>
        public string GetIpAddress()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(hostName);
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    return ipa.ToString();
            }
            //throw new Exception("获取本机的IP地址异常。");
            throw new Exception(f.tsmiHqbjdi.Text);

        }

        /// <summary>
        /// 计算机发送 Internet 控制消息协议 (ICMP)判断是否能连通目标计算机
        /// </summary>
        /// <param name="AddressStr">一个 System.String，它标识作为 ICMP 回送消息目标的计算机。为此参数指定的值可以是主机名，也可以是以字符串形式表示的 IP 地址。</param>
        /// <param name="timeOut">一个 System.Int32 值，指定（发送回送消息后）等待 ICMP 回送答复消息的最大毫秒数。</param>
        /// <returns>True:Success False: No Success</returns>
        public bool TestIPAddress(string AddressStr, int timeOut)
        {
            try
            {
                Ping myping = new Ping();

                PingReply pr = myping.Send(AddressStr, timeOut);
                if (pr.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new ArgumentException(string.Format("IP地址【{0}】连接不通，请确认客户端和服务端的网络是否正常。", AddressStr));
            }
        }

        /// <summary>
        /// 初始化系统信息
        /// </summary>
        public void InitializationSystemInfo(string pwdStr)
        {
            SystemInfo.HostIpAddress = GetIpAddress();
            string SourFilePath = "Images\\CompanyLogo.jpg";
            if (File.Exists(SourFilePath))
            {
                Image img = new Bitmap(SourFilePath);
                SystemInfo.CompImage = img;
            }

            FileHandler fileHandler = new FileHandler();
            string iniPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase.TrimEnd('\\') + "\\Config.ini";
            string sectionStr = "System";
            fileHandler.IniWriteValue(iniPath, sectionStr, "LastLoginID", SystemInfo.user.LoginID);
            if (SystemInfo.LoginSavePwd)
            {
                fileHandler.IniWriteValue(iniPath, sectionStr, "LastLoginPwd", pwdStr);
            }

            #region 设置连接服务端的IP地址和端口号

            SystemInfo.ServerIP = new SystemHandler().GetIpAddress();

            if (File.Exists(iniPath))
            {
                string serverIpStr = fileHandler.IniReadValue(iniPath, sectionStr, "ServerIP");
                int portInt = DataTypeConvert.GetInt(fileHandler.IniReadValue(iniPath, sectionStr, "ServerPort"));
                if (serverIpStr != "")
                    SystemInfo.ServerIP = serverIpStr;
                else
                    fileHandler.IniWriteValue(iniPath, sectionStr, "ServerIP", SystemInfo.ServerIP);
                if (portInt > 0)
                    SystemInfo.ServerPort = portInt;
                else
                    fileHandler.IniWriteValue(iniPath, sectionStr, "ServerPort", SystemInfo.ServerPort.ToString());
            }
            else
            {
                fileHandler.IniWriteValue(iniPath, sectionStr, "ServerIP", SystemInfo.ServerIP);
                fileHandler.IniWriteValue(iniPath, sectionStr, "ServerPort", SystemInfo.ServerPort.ToString());
            }

            #endregion
        }
    }
}
