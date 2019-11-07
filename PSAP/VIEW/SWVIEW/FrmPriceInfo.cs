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
    public partial class FrmPriceInfo : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmBaseEdit editForm = null;

        /// <summary>
        /// 本地存放的项目号
        /// </summary>
        public int codeIdInt = 0;

        public FrmPriceInfo()
        {
            InitializeComponent();

            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.TopLevel = false;
                    editForm.TableName = "BS_PriceInfo";
                    editForm.TableCaption = "供应商价格信息";
                    SetEditFormSQL();
                    editForm.PrimaryKeyColumn = "AutoID";
                    editForm.MasterDataSet = dSPriceInfo;
                    editForm.MasterBindingSource = bSPriceInfo;
                    editForm.MasterEditPanel = pnlEdit;
                    editForm.BrowseXtraGridView = gridViewPriceInfo;
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

        public FrmPriceInfo(int codeIdInt,string codeFileNameStr, string codeNameStr)
        {
            InitializeComponent();
            this.codeIdInt = codeIdInt;
            this.Text = string.Format("【{0}-{1}】的价格信息", codeFileNameStr,codeNameStr);

            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.TopLevel = false;
                    editForm.TableName = "BS_PriceInfo";
                    editForm.TableCaption = "供应商价格信息";
                    SetEditFormSQL();
                    editForm.PrimaryKeyColumn = "AutoID";
                    editForm.MasterDataSet = dSPriceInfo;
                    editForm.MasterBindingSource = bSPriceInfo;
                    editForm.MasterEditPanel = pnlEdit;
                    editForm.BrowseXtraGridView = gridViewPriceInfo;
                    editForm.CheckControl += CheckControl;
                    editForm.SaveRowBefore += SaveRowBefore;
                    editForm.VisibleSearchControl = false;
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
        private void FrmPriceInfo_Load(object sender, EventArgs e)
        {
            try
            {
                searchLookUpBussinessBaseNo.Properties.DataSource = commonDAO.QueryBussinessBaseInfo(false);
                lookUpCurrencyCate.Properties.DataSource = commonDAO.QueryCurrencyCate(false);

                repLookUpBussinessBaseNo.DataSource = searchLookUpBussinessBaseNo.Properties.DataSource;
                repLookUpCurrencyCate.DataSource = lookUpCurrencyCate.Properties.DataSource;
                repLookUpCreator.DataSource = commonDAO.QueryUserInfo(false);
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
            if (searchLookUpBussinessBaseNo.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("供应商不能为空，请重新操作。");
                searchLookUpBussinessBaseNo.Focus();
                return false;
            }
            if (lookUpCurrencyCate.ItemIndex < 0)
            {
                MessageHandler.ShowMessageBox("币种不能为空，请重新操作。");
                lookUpCurrencyCate.Focus();
                return false;
            }
            if (spinUnit.Value <= 0)
            {
                MessageHandler.ShowMessageBox("单价不能小于等于零，请重新操作。");
                spinUnit.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存之前设定数据库的顺序
        /// </summary>
        public bool SaveRowBefore(DataRow dr, SqlCommand cmd)
        {
            if(DataTypeConvert.GetInt(dr["CodeId"])==0)
            {
                MessageHandler.ShowMessageBox("设定零件信息错误。");
                return false;
            }

            if (dr.RowState == DataRowState.Added)
            {
                dr["CreatorIp"] = SystemInfo.HostIpAddress;
            }
            else
            {
                dr["Modifier"] = SystemInfo.user.AutoId;
                dr["ModifierIp"] = SystemInfo.HostIpAddress;
                dr["ModifierTime"] = BaseSQL.GetServerDateTime();
            }

            return true;
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void searchLookUpBussinessBaseNoView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 设定工具栏的SQL
        /// </summary>
        private void SetEditFormSQL()
        {
            editForm.Sql = string.Format("select * from BS_PriceInfo where CodeId = {0} order by AutoId", codeIdInt);
        }

        /// <summary>
        /// 设定GridView的默认值
        /// </summary>
        private void gridViewPriceInfo_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridViewPriceInfo.SetFocusedRowCellValue("CodeId", codeIdInt);
                gridViewPriceInfo.SetFocusedRowCellValue("Creator", SystemInfo.user.AutoId);
                DataTable tmpTable = ((DataTable)lookUpCurrencyCate.Properties.DataSource);
                if (tmpTable.Rows.Count > 0)
                    gridViewPriceInfo.SetFocusedRowCellValue("CurrencyCate",tmpTable.Rows[0]["AutoId"]);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定GridView的默认值错误。", ex);
            }
        }

        /// <summary>
        /// 设定Table的默认值
        /// </summary>
        private void TablePriceInfo_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            try
            {
                e.Row["CodeId"] = codeIdInt;
                e.Row["Creator"] = SystemInfo.user.AutoId;
                DataTable tmpTable = ((DataTable)lookUpCurrencyCate.Properties.DataSource);
                if (tmpTable.Rows.Count > 0)
                    e.Row["CurrencyCate"] = tmpTable.Rows[0]["AutoId"];
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定Table的默认值错误。", ex);
            }
        }

        /// <summary>
        /// 刷新当前的站号信息
        /// </summary>
        public void RefreshCurrentInfo(int codeIdInt, string codeFileNameStr, string codeNameStr)
        {
            this.codeIdInt = codeIdInt;
            this.Text = string.Format("【{0}-{1}】的价格信息", codeFileNameStr, codeNameStr);
            SetEditFormSQL();
            editForm.btnRefresh_Click(null, null);
        }


    }
}
