using PSAP.BLL.SALEBLL;
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
    public partial class FrmAddRemarks : Form
    {
        ListView lv = new ListView();

        public FrmAddRemarks()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(this);
        }

        public FrmAddRemarks(ListView lv0)
        {
            InitializeComponent();
            lv = lv0;
            PSAP.BLL.BSBLL.BSBLL.language(this);
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRemarks.Text.Trim()))
            {
                //MessageHandler.ShowMessageBox("备注内容不能为空！");
                MessageHandler.ShowMessageBox(tsmiBznr.Text);
            }
            else
            {
                FrmAddRemarksBLL.SaveRemarks(lv, txtRemarks.Text);
                this.Close();
            }
        }
    }
}
