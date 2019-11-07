using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.PSAPCommon
{
    class FormHandler
    {
        /// <summary>
        /// 动态创建窗体
        /// </summary>
        /// <param name="type">窗体类型</param>
        /// <returns>DockContent窗体</returns>
        public static DockContent DynamicCreateDockContent(Type type)
        {
            try
            {
                //DockContent dcForm = (DockContent)Activator.CreateInstance(type, true);

                DockContent dcForm = (DockContent)Assembly.GetExecutingAssembly().CreateInstance(type.FullName);

                return dcForm;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 动态创建窗体
        /// </summary>
        /// <param name="type">窗体类型</param>
        /// <returns>Form窗体</returns>
        public static Form DynamicCreateForm(Type type)
        {
            //Form form = (Form)Activator.CreateInstance(type, true);

            Form form = (Form)Assembly.GetExecutingAssembly().CreateInstance(type.FullName);

            return form;
        }
    }
}
