using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmEDrawingPreview : DockContent
    {
        /// <summary>
        /// 零件编号
        /// </summary>
        public static string codeFileNameStr = "";

        /// <summary>
        /// 零件文件路径
        /// </summary>
        public static string partPathStr = "";

        public FrmEDrawingPreview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmEDrawingPreview_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = string.Format("零件【{0}】预览", codeFileNameStr);
                string filePathStr = @"D:\DATA\TestEDrawingFile.sldasm";

                if (File.Exists(filePathStr))
                    eDrawingCtl.OpenDocument(filePathStr);
                else
                {
                    if (File.Exists(partPathStr))
                        eDrawingCtl.OpenDocument(partPathStr);
                    else
                    {
                        MessageHandler.ShowMessageBox(string.Format("要查询的零件路径【{0}】不存在，请重新操作。", partPathStr));
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }
    }
}
