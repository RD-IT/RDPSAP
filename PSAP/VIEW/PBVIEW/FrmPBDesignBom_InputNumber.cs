using PSAP.DAO.PBDAO;
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
    public partial class FrmPBDesignBom_InputNumber : DockContent
    {
        FrmPBDesignBom_PSDAO bomDAO = new FrmPBDesignBom_PSDAO();
        /// <summary>
        /// 销售单号
        /// </summary>
        string salesOrderNoStr = "";
        /// <summary>
        /// 零件编号列表
        /// </summary>
        List<string> codeFileNameList;

        /// <summary>
        /// 是否是新增信息
        /// </summary>
        bool isNew = true;

        /// <summary>
        /// 显示输入数量窗体
        /// </summary>
        /// <param name="formText">窗体名称</param>
        /// <param name="labelText">输入信息文本</param>
        /// <param name="defaultNumber">默认值</param>
        /// <param name="salesOrderNoStr">销售单号</param>
        /// <param name="codeFileNameList">零件编号列表</param>
        /// <returns>输入数量</returns>
        public static float Show_FrmPBDesignBom_InputNumber(string formText, string labelText, decimal defaultNumber,string salesOrderNoStr, List<string> codeFileNameList,bool isNew)
        {
            FrmPBDesignBom_InputNumber form = new FrmPBDesignBom_InputNumber();
            form.Text = formText;
            form.labNumber.Text = labelText;
            form.spinNumber.Value = defaultNumber;
            form.salesOrderNoStr = salesOrderNoStr;
            form.codeFileNameList = codeFileNameList;
            form.isNew = isNew;
            if (form.ShowDialog() == DialogResult.OK)
            {
                return (float)form.spinNumber.Value;
            }
            else
                return 0;
        }

        public FrmPBDesignBom_InputNumber()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPBDesignBom_InputNumber_Load(object sender, EventArgs e)
        {
            try
            {
                string listStr = "";
                foreach(string cfn in codeFileNameList)
                {
                    listStr += string.Format("'{0}',", cfn);
                }
                textCodeFileName.Text = listStr.Substring(0, listStr.Length - 1);
                RefreshDesignBomInfo();
                spinNumber.Focus();
                spinNumber.SelectAll();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void treeListBom_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            ControlHandler.TreeList_CustomDrawNodeIndicator_RootNode(sender, e);
        }

        /// <summary>
        /// 确定输入数量
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (spinNumber.Value == 0)
                {
                    MessageHandler.ShowMessageBox("数量不能为零，请重新输入。");
                    spinNumber.Focus();
                    return;
                }

                if (isNew)
                {
                    DataRow[] drs = dataSet_DesignBom.Tables[0].Select(string.Format("ReParent = '' and CodeFileName in ({0})", textCodeFileName.Text));

                    if (drs.Length > 0)
                    {
                        if (MessageHandler.ShowMessageBox_YesNo("当前零件已经选择过，是否继续增加？") != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                    if (spinNumber.Value < 0)
                    {
                        MessageHandler.ShowMessageBox("拖拽新增数量不能小于零，请重新输入。");
                        spinNumber.Focus();
                        return;
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确定输入数量错误。", ex);
            }
        }

        /// <summary>
        /// 刷新设计Bom信息
        /// </summary>
        private void RefreshDesignBomInfo()
        {
            dataSet_DesignBom.Tables[0].Rows.Clear();
            bomDAO.QueryDesignBomTree_CodeFileName(dataSet_DesignBom.Tables[0], salesOrderNoStr, textCodeFileName.Text);
        }

    }
}
