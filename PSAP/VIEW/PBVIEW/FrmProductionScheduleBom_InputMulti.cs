using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmProductionScheduleBom_InputMulti : DockContent
    {
        public FrmProductionScheduleBom_InputMulti()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmProductionScheduleBom_InputMulti_Load(object sender, EventArgs e)
        {
            try
            {
                radioType.SelectedIndex = 0;
                radioType_SelectedIndexChanged(null, null);
                datePlanDate.DateTime = BaseSQL.GetServerDateTime().Date.AddDays(14);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 设定选择状态
        /// </summary>
        private void radioType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioType.SelectedIndex == 0)
            {                
                spinRemainQty.ReadOnly = true;
                spinRemainQty.Value = 0;
            }
            else
            {
                spinRemainQty.ReadOnly = false;
                spinRemainQty.Value = 1;
            }
        }

        /// <summary>
        /// 确认输入的信息
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioType.SelectedIndex == 0 && spinRemainQty.Value != 0)
                {
                    MessageHandler.ShowMessageBox("统一处理方式的计划数量请输入0。");
                    return;

                }
                else if (radioType.SelectedIndex == 1 && spinRemainQty.Value == 0)
                {
                    MessageHandler.ShowMessageBox("分批处理方式的计划数量必须大于0。");
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确认输入的信息错误。", ex);
            }
        }
    }
}
