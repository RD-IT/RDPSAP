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
    public partial class FrmPartsCode_InputCondition : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmPartsCodeDAO pcDAO = new FrmPartsCodeDAO();

        /// <summary>
        /// 查询零件信息的条件SQL
        /// </summary>
        public string queryWhereSqlStr = "";

        /// <summary>
        /// 是否显示底部按钮区
        /// </summary>
        public bool isVisibleBottomPanel = true;

        public FrmPartsCode_InputCondition()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPartsCode_InputCondition_Load(object sender, EventArgs e)
        {
            try
            {
                if (!isVisibleBottomPanel)
                    pnlBottom.Visible = false;

                searchLookUpMaterial.Properties.DataSource = commonDAO.QueryMaterialSelectLib(true);
                searchLookUpMaterial.EditValue = 0;
                lookUpCatgName.Properties.DataSource = commonDAO.QueryPartNoCatg(true);
                lookUpCatgName.ItemIndex = 0;
                lookUpBrand.Properties.DataSource = commonDAO.QueryBrandCatg(true);
                lookUpBrand.ItemIndex = 0;
                lookUpUnit.Properties.DataSource = commonDAO.QueryUnitCatg(true);
                lookUpUnit.ItemIndex = 0;
                lookUpMachiningLevel.Properties.DataSource = commonDAO.QueryLevelCatg(true);
                lookUpMachiningLevel.ItemIndex = 0;
                lookUpFinish.Properties.DataSource = commonDAO.QueryFinishCatg(true);
                lookUpFinish.ItemIndex = 0;

                checkIsPreferred.EditValue = -1;
                checkIsLongPeriod.EditValue = -1;
                checkIsPrecious.EditValue = -1;
                checkIsPreprocessing.EditValue = -1;
                checkIsBuy.EditValue = -1;

                DateTime nowDate = BaseSQL.GetServerDateTime();
                dateGetTimeBegin.DateTime = nowDate.Date.AddDays(-SystemInfo.OrderQueryDate_DateIntervalDays);
                dateGetTimeEnd.DateTime = nowDate.Date;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void searchLookUpMaterialView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 选择登记日期
        /// </summary>
        private void checkGetTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkGetTime.Checked)
            {
                dateGetTimeBegin.Enabled = true;
                dateGetTimeEnd.Enabled = true;
            }
            else
            {
                dateGetTimeBegin.Enabled = false;
                dateGetTimeEnd.Enabled = false;
            }
        }

        /// <summary>
        /// 确认按钮事件
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetQueryWhereSqlStr())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确认按钮事件错误。", ex);
            }
        }

        /// <summary>
        /// 设定查询条件SQL
        /// </summary>
        public bool SetQueryWhereSqlStr()
        {
            string catgNameStr = lookUpCatgName.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpCatgName.EditValue) : "";
            int materialInt = DataTypeConvert.GetInt(searchLookUpMaterial.EditValue);
            string unitStr = lookUpUnit.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpUnit.EditValue) : "";
            string brandStr = lookUpBrand.ItemIndex > 0 ? DataTypeConvert.GetString(lookUpBrand.EditValue) : "";
            int machiningLevelInt = DataTypeConvert.GetInt(lookUpMachiningLevel.EditValue);
            int finishInt = DataTypeConvert.GetInt(lookUpFinish.EditValue);
            string getTimeBeginStr = "";
            string getTimeEndStr = "";

            if (checkGetTime.Checked)
            {
                if (dateGetTimeBegin.EditValue == null || dateGetTimeEnd.EditValue == null)
                {
                    MessageHandler.ShowMessageBox("登记日期不能为空，请设置后重新操作。");
                    if (dateGetTimeBegin.EditValue == null)
                        dateGetTimeBegin.Focus();
                    else
                        dateGetTimeEnd.Focus();
                    return false;
                }
                getTimeBeginStr = dateGetTimeBegin.DateTime.ToString("yyyy-MM-dd");
                getTimeEndStr = dateGetTimeEnd.DateTime.AddDays(1).ToString("yyyy-MM-dd");
            }

            queryWhereSqlStr = pcDAO.GetQueryWhereSql(textCodeFileName.Text.Trim(), textCodeNo.Text.Trim(), textCodeName.Text.Trim(), textCodeSpec.Text.Trim(), textMaterialVersion.Text.Trim(), textDesigner.Text.Trim(), catgNameStr, materialInt, unitStr, brandStr, machiningLevelInt, finishInt, DataTypeConvert.GetInt(checkIsPreferred.EditValue), DataTypeConvert.GetInt(checkIsLongPeriod.EditValue), DataTypeConvert.GetInt(checkIsPrecious.EditValue), DataTypeConvert.GetInt(checkIsPreprocessing.EditValue), DataTypeConvert.GetInt(checkIsBuy.EditValue), getTimeBeginStr, getTimeEndStr, textCommon.Text.Trim());

            return true;
        }
    }
}
