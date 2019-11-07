using PSAP.DAO.BSDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmRepertoryLocationInfo : DockContent
    {
        FrmBaseEdit editForm = null;
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        public FrmRepertoryLocationInfo()
        {
            InitializeComponent();

            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.TopLevel = false;
                    editForm.TableName = "BS_RepertoryLocationInfo";
                    editForm.TableCaption = "仓位信息";
                    editForm.Sql = "select * from BS_RepertoryLocationInfo Order by AutoId";
                    editForm.PrimaryKeyColumn = "AutoId";
                    editForm.MasterDataSet = dSLocationInfo;
                    editForm.MasterBindingSource = bSLocationInfo;
                    editForm.MasterEditPanel = pnlEdit;
                    //editForm.PrimaryKeyControl = textLocationNo;
                    editForm.BrowseXtraGridView = gridViewLocationInfo;
                    editForm.CheckControl += CheckControl;
                    editForm.SaveRowBefore += SaveRowBefore;
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
        private void FrmRepertoryLocationInfo_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable repertoryInfoTable = commonDAO.QueryRepertoryInfo(false);
                lookUpRepertoryId.Properties.DataSource = repertoryInfoTable;

                repLookUpRepertoryId.DataSource = repertoryInfoTable;
                repLookUpCreator.DataSource = commonDAO.QueryUserInfo_OnlyColumn(false);
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
            if (textLocationNo.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("仓位编号不能为空，请重新操作。");
                textLocationNo.Focus();
                return false;
            }
            if (textLocationName.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("仓位名称不能为空，请重新操作。");
                textLocationName.Focus();
                return false;
            }
            if (lookUpRepertoryId.ItemIndex == -1)
            {
                MessageHandler.ShowMessageBox("所属仓库不能为空，请重新操作。");
                lookUpRepertoryId.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存之前的更新其他表
        /// </summary>
        private bool SaveRowBefore(DataRow dr, SqlCommand cmd)
        {
            if (dr.RowState == DataRowState.Modified)
            {
                if (DataTypeConvert.GetInt(dr["RepertoryId", DataRowVersion.Current]) != DataTypeConvert.GetInt(dr["RepertoryId", DataRowVersion.Original]))
                {
                    cmd.CommandText = string.Format("Update BS_ShelfInfo set RepertoryInfoId = {1} where RepertoryLocationId = {0}", DataTypeConvert.GetInt(dr["AutoId"]), DataTypeConvert.GetInt(dr["RepertoryId", DataRowVersion.Current]));
                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }

        /// <summary>
        /// 设定默认值
        /// </summary>
        private void TableLocationInfo_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["Creator"] = SystemInfo.user.AutoId;
            e.Row["CreatorIp"] = SystemInfo.HostIpAddress;
        }
    }
}
