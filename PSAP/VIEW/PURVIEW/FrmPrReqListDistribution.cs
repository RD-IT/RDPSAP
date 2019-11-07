using PSAP.DAO.BSDAO;
using PSAP.DAO.PURDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmPrReqListDistribution : DockContent
    {
        FrmPrReqListDistributionDAO prReqDAO = new FrmPrReqListDistributionDAO();
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        /// <summary>
        /// 查询的请购单号
        /// </summary>
        public static string queryPrReqNo = "";

        public FrmPrReqListDistribution()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPrReqDistribution_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime nowDate = BaseSQL.GetServerDateTime();
                checkRequirementDate.Checked = true;
                dateRequirementDateBegin.DateTime = nowDate.Date;
                dateRequirementDateEnd.DateTime = nowDate.Date.AddDays(SystemInfo.OrderQueryDate_DateIntervalDays);

                //DataTable partsCodeTable_t = commonDAO.QueryPartsCode(true);

                //searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(true);
                //searchLookUpProjectNo.Text = "全部";
                //searchLookUpCodeFileName.Properties.DataSource = partsCodeTable_t;
                //searchLookUpCodeFileName.EditValue = 0;

                ControlCommonInit ctlInit = new ControlCommonInit();
                ctlInit.SearchLookUpEdit_UserInfo_ValueMember_AutoId_NoAll(searchLookUpArrangement);
                //searchLookUpCreator.EditValue = SystemInfo.user.AutoId;
                ctlInit.SearchLookUpEdit_PartsCode(searchLookUpCodeFileName, true);
                searchLookUpCodeFileName.EditValue = 0;
                ctlInit.SearchLookUpEdit_ProjectList(searchLookUpProjectNo, true);
                searchLookUpProjectNo.Text = "全部";

                repLookUpCodeName.DataSource = searchLookUpCodeFileName.Properties.DataSource;
                repLookUpOperator.DataSource = searchLookUpArrangement.Properties.DataSource;

                checkContainOk.Checked = false;

                if (SystemInfo.DisableProjectNo)
                {
                    labProjectNo.Visible = false;
                    searchLookUpProjectNo.Visible = false;
                    colProjectNo.Visible = false;
                    colStnNo.Visible = false;
                }

                btnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 窗体激活事件
        /// </summary>
        private void FrmPrReqListDistribution_Activated(object sender, EventArgs e)
        {
            try
            {
                if (queryPrReqNo != "")
                {
                    textCommon.Text = queryPrReqNo;
                    queryPrReqNo = "";
                    checkRequirementDate.Checked = false;
                    searchLookUpCodeFileName.EditValue = 0;
                    searchLookUpProjectNo.Text = "全部";
                    checkContainOk.Checked = true;

                    btnQuery_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体激活事件错误。", ex);
            }
        }

        /// <summary>
        /// 选择需求日期
        /// </summary>
        private void checkRequirementDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRequirementDate.Checked)
            {
                dateRequirementDateBegin.Enabled = true;
                dateRequirementDateEnd.Enabled = true;
            }
            else
            {
                dateRequirementDateBegin.Enabled = false;
                dateRequirementDateEnd.Enabled = false;
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewPrReqList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewPrReqList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ControlHandler.GridView_GetFocusedCellDisplayText_KeyDown(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--获取单元格显示的信息错误。", ex);
            }
        }

        /// <summary>
        /// 双击选择当前行
        /// </summary>
        private void gridViewPrReqList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    int[] rowint = gridViewPrReqList.GetSelectedRows();

                    ArrayList ar = new ArrayList();
                    ar.AddRange(rowint);

                    if (ar.Contains(gridViewPrReqList.FocusedRowHandle))
                        gridViewPrReqList.UnselectRow(gridViewPrReqList.FocusedRowHandle);
                    else
                        gridViewPrReqList.SelectRow(gridViewPrReqList.FocusedRowHandle);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击选择当前行错误。", ex);
            }
        }

        /// <summary>
        /// 查询按钮事件
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                string requirementDateBeginStr = "";
                string requirementDateEndStr = "";
                if (checkRequirementDate.Checked)
                {
                    if (dateRequirementDateBegin.EditValue == null || dateRequirementDateEnd.EditValue == null)
                    {
                        MessageHandler.ShowMessageBox("请购日期不能为空，请设置后重新进行查询。");
                        if (dateRequirementDateBegin.EditValue == null)
                            dateRequirementDateBegin.Focus();
                        else
                            dateRequirementDateEnd.Focus();
                        return;
                    }
                    requirementDateBeginStr = dateRequirementDateBegin.DateTime.ToString("yyyy-MM-dd");
                    requirementDateEndStr = dateRequirementDateEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
                }

                string projectNoStr = searchLookUpProjectNo.Text != "全部" ? DataTypeConvert.GetString(searchLookUpProjectNo.EditValue) : "";
                int codeIdInt = DataTypeConvert.GetInt(searchLookUpCodeFileName.EditValue);
                string commonStr = textCommon.Text.Trim();
                dataSet_PrReqList.Tables[0].Clear();

                prReqDAO.QueryPrReqListDistribution(dataSet_PrReqList.Tables[0], requirementDateBeginStr, requirementDateEndStr, projectNoStr, codeIdInt, 0, commonStr, checkContainOk.Checked, checkContainPO.Checked);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--查询按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 设定执行人
        /// </summary>
        private void btnSetArrangement_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int[] rowint = gridViewPrReqList.GetSelectedRows();
                if (rowint.Length == 0)
                {
                    MessageHandler.ShowMessageBox("请先选择要设定的请购明细记录。");
                    return;
                }

                if (searchLookUpArrangement.Text == "")
                {
                    MessageHandler.ShowMessageBox("请选择要设定的执行人。");
                    searchLookUpArrangement.Focus();
                    return;
                }

                List<int> autoIdList = new List<int>();
                foreach (int i in rowint)
                {
                    autoIdList.Add(DataTypeConvert.GetInt(gridViewPrReqList.GetDataRow(i)["AutoId"]));
                }

                if (prReqDAO.SetArrangement(autoIdList, DataTypeConvert.GetInt(searchLookUpArrangement.EditValue)))
                {
                    MessageHandler.ShowMessageBox(string.Format("设定{0}条请购明细记录的执行人成功。", autoIdList.Count));

                    btnQuery_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定执行人错误。", ex);
            }
        }

        /// <summary>
        /// 清空执行人
        /// </summary>
        private void btnClearArrangement_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                int[] rowint = gridViewPrReqList.GetSelectedRows();
                if (rowint.Length == 0)
                {
                    MessageHandler.ShowMessageBox("请先选择要设定的请购明细记录。");
                    return;
                }

                List<int> autoIdList = new List<int>();
                foreach (int i in rowint)
                {
                    autoIdList.Add(DataTypeConvert.GetInt(gridViewPrReqList.GetDataRow(i)["AutoId"]));
                }

                if (prReqDAO.ClearArrangement(autoIdList))
                {
                    MessageHandler.ShowMessageBox(string.Format("清空{0}条请购明细记录的执行人成功。", autoIdList.Count));

                    btnQuery_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定执行人错误。", ex);
            }
        }

    }
}
