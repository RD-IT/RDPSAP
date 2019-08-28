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
    public partial class FrmShelfInfo : DockContent
    {
        FrmBaseEdit editForm = null;
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public FrmShelfInfo()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(f);
            PSAP.BLL.BSBLL.BSBLL.language(this);

            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.TopLevel = false;
                    editForm.TableName = "BS_ShelfInfo";
                    editForm.TableCaption = "货架信息";
                    editForm.Sql = "select * from BS_ShelfInfo order by AutoId";
                    editForm.PrimaryKeyColumn = "AutoId";
                    editForm.MasterDataSet = dSShelfInfo;
                    editForm.MasterBindingSource = bSShelfInfo;
                    editForm.MasterEditPanel = pnlEdit;
                    editForm.PrimaryKeyControl = textShelfNo;
                    editForm.BrowseXtraGridView = gridViewShelfInfo;
                    editForm.CheckControl += CheckControl;
                    this.pnlToolBar.Controls.Add(editForm);
                    editForm.Dock = DockStyle.Fill;
                    editForm.Show();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体构造函数错误。", ex);
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmShelfInfo_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable locationInfoTable = commonDAO.QueryRepertoryLocationInfo(false);
                SearchRepertoryLocationId.Properties.DataSource = locationInfoTable;

                repLookUpRepertoryLocationId.DataSource = locationInfoTable;
                repLookUpRepertoryInfoId.DataSource = commonDAO.QueryRepertoryInfo(false);
                repLookUpCreator.DataSource = commonDAO.QueryUserInfo(false);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiCtjzsjcw.Text, ex);
            }
        }

        /// <summary>
        /// 保存之前的回调方法
        /// </summary>
        public bool CheckControl()
        {
            if (textShelfNo.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox(tsmiHjbhbnwk.Text);// ("货架编号不能为空，请重新操作。");
                textShelfNo.Focus();
                return false;
            }
            if (textShelfLocation.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox(tsmiHjwzbnwk.Text);// ("货架位置不能为空，请重新操作。");
                textShelfLocation.Focus();
                return false;
            }
            if (SearchRepertoryLocationId.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("所属仓位不能为空，请重新操作。");
                SearchRepertoryLocationId.Focus();
                return false;
            }

            DataRow dr = ((DataRowView)bSShelfInfo.Current).Row;
            dr["RepertoryInfoId"] = DataTypeConvert.GetInt(((DataRowView)SearchRepertoryLocationId.GetSelectedDataRow())["RepertoryId"]);            

            return true;
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void SearchRepertoryLocationIdView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 设定默认值
        /// </summary>
        private void TableShelfInfo_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["Creator"] = SystemInfo.user.AutoId;
            e.Row["CreatorIp"] = SystemInfo.HostIpAddress;
        }
    }
}
