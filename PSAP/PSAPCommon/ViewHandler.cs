using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.PSAPCommon
{
    class ViewHandler
    {
        /// <summary>
        /// 显示窗体在右方Page页中
        /// </summary>
        /// <param name="windowName">窗体名称</param>
        public static void ShowRightWindow(string windowName)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
                string strFrm = "PSAP.VIEW.BSVIEW." + windowName;
                object obj = assembly.CreateInstance(strFrm); //类的完全限定名（即包括命名空间）
                if (obj != null)
                {
                    if (obj.GetType().BaseType.ToString() == "WeifenLuo.WinFormsUI.Docking.DockContent")
                    {
                        PSAP.VIEW.BSVIEW.FrmMain.frmMain.showRight((DockContent)obj);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException_NoMessage("ViewHandler--ShowRightWindow。", ex);
                throw ex;
            }
        }

        /// <summary>
        /// 显示窗体在右方Page页中 (带参数)
        /// </summary>
        /// <param name="windowName">窗体名称</param>
        /// <param name="parameters">参数数组</param>
        public static void ShowRightWindow_Parameters(string windowName,object[] parameters)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
                string strFrm = "PSAP.VIEW.BSVIEW." + windowName;
                object obj = assembly.CreateInstance(strFrm, true, System.Reflection.BindingFlags.Default, null, parameters, null, null);//类的完全限定名（即包括命名空间）
                if (obj != null)
                {
                    if (obj.GetType().BaseType.ToString() == "WeifenLuo.WinFormsUI.Docking.DockContent")
                    {
                        PSAP.VIEW.BSVIEW.FrmMain.frmMain.showRight((DockContent)obj);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException_NoMessage("ViewHandler--ShowRightWindow_Parameters。", ex);
                throw ex;
            }
        }
    }
}
