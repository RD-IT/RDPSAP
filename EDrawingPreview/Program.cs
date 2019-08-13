using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SWPreview
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
            Application.SetCompatibleTextRenderingDefault(false);

            string pString = "";
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                pString = Environment.GetCommandLineArgs()[1];
                //MessageBox.Show(pString);
                pString = pString == "" ? @"[DF00055979~0][D:\DATA\TestEDrawingFile.sldasm]" : pString;
                string[] parameterStrs = pString.Split(new string[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);

                Process[] Pros = Process.GetProcessesByName(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

                int curId = Process.GetCurrentProcess().Id;
                foreach (Process p in Pros)
                {
                    if (p.Id != curId)
                        p.Kill();
                }

                FrmSWPreview frm = new FrmSWPreview(parameterStrs[0], parameterStrs[1]);
                Application.Run(frm);
            }

        }
    }
}
