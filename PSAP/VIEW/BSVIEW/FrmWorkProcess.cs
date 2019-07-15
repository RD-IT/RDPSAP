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
    public partial class FrmWorkProcess : DockContent
    {
        FrmBaseEdit editForm = null;

        public FrmWorkProcess()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWorkProcess_Load(object sender, EventArgs e)
        {
            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.TopLevel = false;
                    editForm.TableName = "BS_WorkProcess";
                    editForm.TableCaption = "基本工序";
                    editForm.Sql = "select * from BS_WorkProcess order by AutoId";
                    editForm.PrimaryKeyColumn = "AutoId";
                    editForm.MasterDataSet = dSWorkProcess;
                    editForm.MasterBindingSource = bSWorkProcess;
                    editForm.MasterEditPanel = pnlEdit;
                    editForm.PrimaryKeyControl = textWorkProcessNo;
                    editForm.BrowseXtraGridView = gridViewWorkProcess;
                    editForm.CheckControl += CheckControl;
                    this.pnlToolBar.Controls.Add(editForm);
                    editForm.Dock = DockStyle.Fill;
                    editForm.Show();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 保存之前的回调方法
        /// </summary>
        public bool CheckControl()
        {
            if (textWorkProcessNo.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("工序编号不能为空，请重新操作。");
                textWorkProcessNo.Focus();
                return false;
            }
            if (textWorkProcessText.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("工序名称不能为空，请重新操作。");
                textWorkProcessText.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 设定Table的默认值
        /// </summary>
        private void TableWorkProcess_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            try
            {
                e.Row["IsBuy"] = 1;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定Table的默认值错误。", ex);
            }
        }
    }
}
