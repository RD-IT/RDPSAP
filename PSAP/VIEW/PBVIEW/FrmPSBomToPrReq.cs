using PSAP.DAO.BSDAO;
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
    public partial class FrmPSBomToPrReq : DockContent
    {
        /// <summary>
        /// 设计Bom单号
        /// </summary>
        public static string pbBomNoStr = "";

        /// <summary>
        /// 销售单号
        /// </summary>
        public static string salesOrderNoStr = "";

        /// <summary>
        /// 项目号
        /// </summary>
        public static string projectNoStr = "";

        /// <summary>
        /// 制作Bom的AutoId  为0时生成PbBomNo单号里面所有的
        /// </summary>
        public static int bomListAutoIdInt = 0;

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmPSBomToPrReqDAO PStoPRDAO = new FrmPSBomToPrReqDAO();

        public FrmPSBomToPrReq()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPSBomToPrReq_Load(object sender, EventArgs e)
        {
            try
            {
                textPbBomNo.Text = pbBomNoStr;

                lookUpReqDep.Properties.DataSource = commonDAO.QueryDepartment(false);
                lookUpReqDep.EditValue = SystemInfo.user.DepartmentNo;

                searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(false);
                searchLookUpProjectNo.Text = projectNoStr;

                DataTable tempTable = commonDAO.QueryStnList(projectNoStr);
                searchLookUpStnNo.Properties.DataSource = tempTable;
                if (tempTable.Rows.Count > 0)
                {
                    searchLookUpStnNo.EditValue = tempTable.Rows[0]["StnNo"];
                }

                lookUpPurCategory.Properties.DataSource = commonDAO.QueryPurCategory(false);
                lookUpPurCategory.ItemIndex = 0;

                lookUpEditApprovalType.Properties.DataSource = commonDAO.QueryApprovalType(false);
                lookUpEditApprovalType.ItemIndex = 0;

                DataTable psBomTable = PStoPRDAO.Query_NoPr_PSBom(pbBomNoStr, bomListAutoIdInt);
                gridControlPSBom.DataSource = psBomTable;
                if (psBomTable.Rows.Count == 0)
                {
                    MessageHandler.ShowMessageBox("当前选中的制作Bom信息没有生产计划，不能生成请购单。");
                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewPSBom_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewPSBom_KeyDown(object sender, KeyEventArgs e)
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
        /// 确认按钮事件
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpReqDep.ItemIndex == -1)
                {
                    MessageHandler.ShowMessageBox("请选择申请部门。");
                    lookUpReqDep.Focus();
                    return;
                }
                if (DataTypeConvert.GetString(searchLookUpStnNo.EditValue) == "")
                {
                    MessageHandler.ShowMessageBox("请选择站号。");
                    searchLookUpStnNo.Focus();
                    return;
                }
                if (lookUpPurCategory.ItemIndex == -1)
                {
                    MessageHandler.ShowMessageBox("请选择采购类型。");
                    lookUpPurCategory.Focus();
                    return;
                }
                if (lookUpEditApprovalType.ItemIndex == -1)
                {
                    MessageHandler.ShowMessageBox("请选择审批类型。");
                    lookUpEditApprovalType.Focus();
                    return;
                }

                if (PStoPRDAO.Save_PSBomToPrReq(salesOrderNoStr, pbBomNoStr, bomListAutoIdInt, projectNoStr, DataTypeConvert.GetString(searchLookUpStnNo.EditValue), DataTypeConvert.GetString(lookUpReqDep.EditValue), DataTypeConvert.GetString(lookUpPurCategory.EditValue), DataTypeConvert.GetString(lookUpEditApprovalType.EditValue)))
                {
                    MessageHandler.ShowMessageBox("生产计划生成请购单成功。");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {                    
                    return;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确认按钮事件错误。", ex);
            }
        }
    }
}
