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
    public partial class FrmListDesignBomWorkProcess : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmPBDesignBom_PS_NewDAO bomDAO = new FrmPBDesignBom_PS_NewDAO();

        /// <summary>
        /// 制造Bom的ID
        /// </summary>
        public static int designBomListAutoId = 0;

        public FrmListDesignBomWorkProcess()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmListDesignBomWorkProcess_Load(object sender, EventArgs e)
        {
            try
            {
                bomDAO.QueryDesignBomList(TableDesignBom, designBomListAutoId);
                if (TableDesignBom.Rows.Count == 0)
                {
                    MessageHandler.ShowMessageBox("未查询到当前要操作的制作Bom信息，请重新操作。");
                    this.Close();
                    return;
                }

                btnQuery_Click(null, null);

                spinWorkProcessQty.Value = 1;
                spinWorkProcessQty.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewWorkProcess_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewWorkProcess_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
        /// 确定登记信息
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (textWorkProcessNo.Text.Trim() == "")
                {
                    MessageHandler.ShowMessageBox("工序编号不能为空，请重新输入。");
                    textWorkProcessNo.Focus();
                    return;
                }

                if (spinWorkProcessQty.Value <= 0)
                {
                    MessageHandler.ShowMessageBox("工序数量不能为零，请重新输入。");
                    spinWorkProcessQty.Focus();
                    return;
                }

                DataRow headRow = TableDesignBom.Rows[0];
                decimal remainQty = DataTypeConvert.GetDecimal(headRow["RemainQty"]);
                if (bomDAO.Insert_WorkProcess(textSalesOrderNo.Text, textPbBomNo.Text, designBomListAutoId, textCodeFileName.Text, remainQty, textWorkProcessNo.Text, spinWorkProcessQty.Value))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确定登记信息错误。", ex);
            }
        }

        /// <summary>
        /// 双击行确定
        /// </summary>
        private void gridViewWorkProcess_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.Clicks == 1)
                    {
                        textWorkProcessNo.Text = DataTypeConvert.GetString(gridViewWorkProcess.GetFocusedDataRow()["WorkProcessNo"]);
                    }
                    else if (e.Clicks == 2)
                    {
                        textWorkProcessNo.Text = DataTypeConvert.GetString(gridViewWorkProcess.GetFocusedDataRow()["WorkProcessNo"]);

                        BtnConfirm_Click(null, null);
                    }

                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击行确定错误。", ex);
            }
        }

        /// <summary>
        /// 查询工序信息
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                TableWorkProcess.Rows.Clear();
                bomDAO.QueryWorkProcess(TableWorkProcess, "", textCommon.Text);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击行确定错误。", ex);
            }
        }
    }
}
