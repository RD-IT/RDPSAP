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
    public partial class FrmProductionScheduleBom_InputSingle : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmPBDesignBom_PSDAO bomDAO = new FrmPBDesignBom_PSDAO();

        /// <summary>
        /// 设计Bom的ID
        /// </summary>
        public static int bomListAutoId = 0;

        /// <summary>
        /// 生产计划的ID
        /// </summary>
        public static int psBomAutoId = 0;

        /// <summary>
        /// 设计Bom信息表
        /// </summary>
        private DataTable designBomListTable = new DataTable();

        public FrmProductionScheduleBom_InputSingle()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmProductionScheduleBom_InputSingle_Load(object sender, EventArgs e)
        {
            try
            {
                bomDAO.QueryDesignBomList(designBomListTable, bomListAutoId, psBomAutoId);
                if (designBomListTable.Rows.Count == 0)
                {
                    MessageHandler.ShowMessageBox("未查询到设计Bom的信息，请重新操作。");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }

                textPbBomNo.Text = DataTypeConvert.GetString(designBomListTable.Rows[0]["PbBomNo"]);
                textMaterielNo.Text = DataTypeConvert.GetString(designBomListTable.Rows[0]["LevelMaterielNo"]);
                if (textMaterielNo.Text.Trim() == "")
                    textMaterielNo.Text = DataTypeConvert.GetString(designBomListTable.Rows[0]["MaterielNo"]);
                double remainQty = DataTypeConvert.GetDouble(designBomListTable.Rows[0]["RemainQty"]);
                double psBomRemainQty = DataTypeConvert.GetDouble(designBomListTable.Rows[0]["PSBomRemainQty"]);
                textRemainQty.Text = DataTypeConvert.GetString(remainQty);
                textOKRemainQty.Text = DataTypeConvert.GetString(psBomRemainQty);

                if (psBomAutoId == 0)
                {
                    if (psBomRemainQty >= remainQty)
                    {
                        MessageHandler.ShowMessageBox("已经计划的数量大于或者等于设计Bom的数量，不可以再输入生产计划信息，请重新操作。");
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }

                    if (psBomRemainQty == 0)
                    {
                        radioType.ReadOnly = false;
                        //radioType.EditValue = 1;
                        radioType.SelectedIndex = 0;
                        spinRemainQty.Value = DataTypeConvert.GetDecimal(remainQty);
                        spinRemainQty.Properties.MaxValue = DataTypeConvert.GetDecimal(remainQty);
                        spinRemainQty.Properties.MinValue = 0;
                        spinRemainQty.ReadOnly = true;
                    }
                    else
                    {
                        radioType.ReadOnly = true;
                        //radioType.EditValue = 0;
                        radioType.SelectedIndex = 1;
                        spinRemainQty.Value = DataTypeConvert.GetDecimal(remainQty - psBomRemainQty);
                        spinRemainQty.Properties.MaxValue = DataTypeConvert.GetDecimal(remainQty - psBomRemainQty);
                        spinRemainQty.Properties.MinValue = 0;
                    }

                    datePlanDate.DateTime = BaseSQL.GetServerDateTime().Date.AddDays(14);
                }
                else
                {
                    DataTable psBomTable = bomDAO.QueryProductionScheduleBom(psBomAutoId);
                    int isall = DataTypeConvert.GetInt(designBomListTable.Rows[0]["IsAll"]);
                    radioType.ReadOnly = false;
                    radioType.SelectedIndex = isall==1?0:1;
                    spinRemainQty.Value = DataTypeConvert.GetDecimal(psBomTable.Rows[0]["RemainQty"]);
                    if (radioType.SelectedIndex == 0 && spinRemainQty.Value < DataTypeConvert.GetDecimal(remainQty - psBomRemainQty))
                    {
                        spinRemainQty.Value = DataTypeConvert.GetDecimal(remainQty - psBomRemainQty);
                    }
                    spinRemainQty.Properties.MaxValue = DataTypeConvert.GetDecimal(remainQty - psBomRemainQty);
                    spinRemainQty.ReadOnly = isall==1;
                    datePlanDate.DateTime = DataTypeConvert.GetDateTime(psBomTable.Rows[0]["PlanDate"]);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确认输入的信息
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (spinRemainQty.Value == 0)
                {
                    MessageHandler.ShowMessageBox("计划数量必须大于0，请重新操作。");
                    return;
                }

                if (spinRemainQty.Value > DataTypeConvert.GetDecimal(textRemainQty.Text) - DataTypeConvert.GetDecimal(textOKRemainQty.Text))
                {
                    MessageHandler.ShowMessageBox("当前计划数量 + 其他计划数量 > 设计Bom的数量，请重新操作。");
                    return;
                }

                int isAll = DataTypeConvert.GetInt(radioType.EditValue);
                if(DataTypeConvert.GetDouble(spinRemainQty.Value) == DataTypeConvert.GetDouble(textRemainQty.Text))
                {
                    isAll = 1;
                }

                if (bomDAO.SaveProductionScheduleBom(bomListAutoId, psBomAutoId, isAll, datePlanDate.DateTime, DataTypeConvert.GetDouble(spinRemainQty.Value)))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确认输入的信息错误。", ex);
            }
        }

        /// <summary>
        /// 设定选择状态
        /// </summary>
        private void radioType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(radioType.SelectedIndex == 0)
            {
                spinRemainQty.Value = DataTypeConvert.GetDecimal(textRemainQty.Text);
                spinRemainQty.ReadOnly = true;
            }
            else
            {
                spinRemainQty.ReadOnly = false;
            }
        }
    }
}
