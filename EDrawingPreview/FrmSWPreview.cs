using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SWPreview
{
    public partial class FrmSWPreview : Form
    {
        /// <summary>
        /// 零件文件路径
        /// </summary>
        string partPathStr = "";

        public FrmSWPreview(string codeFileNameStr, string partPathStr)
        {
            InitializeComponent();
            this.Text = string.Format("零件【{0}】预览", codeFileNameStr);
            this.partPathStr = partPathStr;

            FileHandler fileHandler = new FileHandler();
            string iniPath = System.Windows.Forms.Application.StartupPath + "\\Config.ini";
            int width = DataTypeConvert.GetInt(fileHandler.IniReadValue(iniPath, "System", "SWPreviewWidth"));
            int height = DataTypeConvert.GetInt(fileHandler.IniReadValue(iniPath, "System", "SWPreviewHeight"));
            if (width > 600 && height > 480)
            {
                this.Width = width;
                this.Height = height;
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmEDrawingPreview_Load(object sender, EventArgs e)
        {
            try
            {
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
