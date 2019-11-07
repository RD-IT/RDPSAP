using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSAP.PSAPCommon
{
    /// <summary>
    /// 当前登录的用户变化（登录、注销和解锁屏）
    /// </summary>
    class SessionSwitchHandler
    {
        public bool isLock = false;

        /// <summary>
        /// 解屏后执行的委托
        /// </summary>
        public Action SessionUnlockAction { get; set; }

        /// <summary>
        /// 锁屏后执行的委托
        /// </summary>
        public Action SessionLockAction { get; set; }

        public SessionSwitchHandler()
        {
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        //析构，防止句柄泄漏
        ~SessionSwitchHandler()
        {
            //Do this during application close to avoid handle leak
            SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
        }

        //当前登录的用户变化（登录、注销和解锁屏）
        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                //用户登录
                case SessionSwitchReason.SessionLogon:
                    BeginSessionUnlock();
                    break;
                //解锁屏
                case SessionSwitchReason.SessionUnlock:
                    BeginSessionUnlock();
                    break;
                //锁屏
                case SessionSwitchReason.SessionLock:
                    BeginSessionLock();
                    break;
                //注销
                case SessionSwitchReason.SessionLogoff:
                    break;
            }
        }

        /// <summary>
        /// 解屏、登录后执行
        /// </summary>
        private void BeginSessionUnlock()
        {
            //解屏、登录后执行
            isLock = false;
        }

        /// <summary>
        /// 锁屏后执行
        /// </summary>
        private void BeginSessionLock()
        {
            //锁屏后执行
            isLock = true;
        }
    }
}
