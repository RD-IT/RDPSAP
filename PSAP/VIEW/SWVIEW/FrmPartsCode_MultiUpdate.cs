using System;
using PSAP.PSAPCommon;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using PSAP.DAO.BSDAO;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmPartsCode_MultiUpdate : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmPartsCodeDAO pcDAO = new FrmPartsCodeDAO();

        /// <summary>
        /// 查询零件信息的条件SQL
        /// </summary>
        public string queryWhereSqlStr = "";

        /// <summary>
        /// 物料信息表
        /// </summary>
        public DataTable partsCodeTable = new DataTable();

        /// <summary>
        /// 默认类型 1：查询条件 2：批量修改
        /// </summary>
        public int typeInt = 1;

        ///// <summary>
        ///// 过滤条件窗体
        ///// </summary>
        //FrmPartsCode_InputCondition inputConditionForm;

        public FrmPartsCode_MultiUpdate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmPartsCode_MultiUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                #region 查询条件

                //inputConditionForm = new FrmPartsCode_InputCondition();
                //inputConditionForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                //inputConditionForm.TopLevel = false;
                //inputConditionForm.Dock = DockStyle.Fill;
                //inputConditionForm.isVisibleBottomPanel = false;
                //xtraTabPageQuery.Controls.Add(inputConditionForm);
                //inputConditionForm.Show();

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

                #endregion

                #region 批量修改

                searchLookUpMaterialUpdate.Properties.DataSource = commonDAO.QueryMaterialSelectLib(false);
                lookUpCatgNameUpdate.Properties.DataSource = commonDAO.QueryPartNoCatg(false);
                lookUpBrandUpdate.Properties.DataSource = commonDAO.QueryBrandCatg(false);
                lookUpUnitUpdate.Properties.DataSource = commonDAO.QueryUnitCatg(false);
                lookUpMachiningLevelUpdate.Properties.DataSource = commonDAO.QueryLevelCatg(false);
                lookUpFinishUpdate.Properties.DataSource = commonDAO.QueryFinishCatg(false);

                DataTable partsCodeColumnTable = new DataTable("partsCodeColumnTable");
                partsCodeColumnTable.Columns.Add("ColumnFieldName", Type.GetType("System.String"));
                partsCodeColumnTable.Columns.Add("ColumnCaptionName", Type.GetType("System.String"));

                DataRow newRow;

                foreach (DataColumn column in partsCodeTable.Columns)
                {
                    switch (column.ColumnName)
                    {
                        case "AutoId":
                        case "CodeNo":
                        case "CodeFileName":
                        case "CodeName":
                        case "FilePath":

                            continue;
                        default:
                            newRow = partsCodeColumnTable.NewRow();
                            newRow["ColumnFieldName"] = column.ColumnName;
                            newRow["ColumnCaptionName"] = column.Caption;
                            partsCodeColumnTable.Rows.Add(newRow);
                            break;
                    }
                }

                lookUpColumnInfo.Properties.DataSource = partsCodeColumnTable;
                lookUpColumnInfo.ItemIndex = -1;

                #endregion

                TypeSetFormState();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 选择不同列名显示不同的设定控件
        /// </summary>
        private void lookUpColumnInfo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                SetControlState(DataTypeConvert.GetString(e.OldValue), false);
                SetControlState(DataTypeConvert.GetString(e.NewValue), true);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择不同列名显示不同的设定控件错误。", ex);
            }
        }

        /// <summary>
        /// 设定控件状态
        /// </summary>
        private void SetControlState(string columnNameStr, bool state)
        {
            int height = 28;
            switch (columnNameStr)
            {
                case "GetTime":
                    dateEditType.Visible = state;
                    dateEditType.Location = new Point(373, height);
                    dateEditType.DateTime = DateTime.Now;
                    break;
                case "CodeWeight":
                    spinEditType.Visible = state;
                    spinEditType.Location = new Point(373, height);
                    spinEditType.Value = 1;
                    break;
                case "IsPreferred":
                case "IsLongPeriod":
                case "IsPrecious":
                case "IsPreprocessing":
                case "IsBuy":
                    checkEditType.Visible = state;
                    checkEditType.Location = new Point(395, height);
                    checkEditType.Checked = false;
                    break;
                case "CatgName":
                    lookUpCatgNameUpdate.Visible = state;
                    lookUpCatgNameUpdate.Location = new Point(373, height);
                    lookUpCatgNameUpdate.ItemIndex = -1;
                    break;
                case "Material":
                    searchLookUpMaterialUpdate.Visible = state;
                    searchLookUpMaterialUpdate.Location = new Point(373, height);
                    searchLookUpMaterialUpdate.EditValue = null;
                    break;
                case "Unit":
                    lookUpUnitUpdate.Visible = state;
                    lookUpUnitUpdate.Location = new Point(373, height);
                    lookUpUnitUpdate.ItemIndex = -1;
                    break;
                case "Brand":
                    lookUpBrandUpdate.Visible = state;
                    lookUpBrandUpdate.Location = new Point(373, height);
                    lookUpBrandUpdate.ItemIndex = -1;
                    break;
                case "MachiningLevel":
                    lookUpMachiningLevelUpdate.Visible = state;
                    lookUpMachiningLevelUpdate.Location = new Point(373, height);
                    lookUpMachiningLevelUpdate.ItemIndex = -1;
                    break;
                case "Finish":
                    lookUpFinishUpdate.Visible = state;
                    lookUpFinishUpdate.Location = new Point(373, height);
                    lookUpFinishUpdate.ItemIndex = -1;
                    break;
                default:
                    textEditType.Visible = state;
                    textEditType.Location = new Point(373, height);
                    textEditType.Text = "";
                    break;
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
        /// 显示隐藏批量修改
        /// </summary>
        private void btnExpand_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnExpand.Text == "+")
                {
                    typeInt = 2;
                }
                else
                {
                    typeInt = 1;
                }
                TypeSetFormState();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--显示隐藏批量修改错误。", ex);
            }
        }

        /// <summary>
        /// 确认批量修改物料信息
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (typeInt == 1)   //查询条件
                {
                    if (SetQueryWhereSqlStr())
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else    //批量修改
                {
                    if (!SetQueryWhereSqlStr())
                        return;

                    string setSqlStr = "";
                    if (lookUpColumnInfo.ItemIndex < 0)
                    {
                        MessageHandler.ShowMessageBox("请选择要修改的列名。");
                        lookUpColumnInfo.Focus();
                        return;
                    }
                    switch (DataTypeConvert.GetString(lookUpColumnInfo.EditValue))
                    {
                        case "GetTime":
                            if (dateEditType.EditValue == null)
                            {
                                MessageHandler.ShowMessageBox(string.Format("请输入要修改的{0}。", lookUpColumnInfo.Text));
                                dateEditType.Focus();
                                return;
                            }
                            setSqlStr = string.Format("{0}='{1}'", DataTypeConvert.GetString(lookUpColumnInfo.EditValue), dateEditType.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            break;
                        case "CodeWeight":
                            setSqlStr = string.Format("{0}={1}", DataTypeConvert.GetString(lookUpColumnInfo.EditValue), DataTypeConvert.GetDouble(spinEditType.Value));
                            break;
                        case "IsPreferred":
                        case "IsLongPeriod":
                        case "IsPrecious":
                        case "IsPreprocessing":
                        case "IsBuy":
                            setSqlStr = string.Format("{0}={1}", DataTypeConvert.GetString(lookUpColumnInfo.EditValue), DataTypeConvert.GetInt(checkEditType.EditValue));
                            break;
                        case "CatgName":
                            if (lookUpCatgNameUpdate.ItemIndex == -1)
                            {
                                MessageHandler.ShowMessageBox(string.Format("请输入要修改的{0}。", lookUpColumnInfo.Text));
                                lookUpCatgNameUpdate.Focus();
                                return;
                            }
                            setSqlStr = string.Format("{0}='{1}'", DataTypeConvert.GetString(lookUpColumnInfo.EditValue), lookUpCatgNameUpdate.EditValue);
                            break;
                        case "Material":
                            if (DataTypeConvert.GetInt(searchLookUpMaterialUpdate.EditValue) == 0)
                            {
                                MessageHandler.ShowMessageBox(string.Format("请输入要修改的{0}。", lookUpColumnInfo.Text));
                                searchLookUpMaterialUpdate.Focus();
                                return;
                            }
                            setSqlStr = string.Format("{0}={1}", DataTypeConvert.GetString(lookUpColumnInfo.EditValue), DataTypeConvert.GetInt(searchLookUpMaterialUpdate.EditValue));
                            break;
                        case "Unit":
                            if (lookUpUnitUpdate.ItemIndex == -1)
                            {
                                MessageHandler.ShowMessageBox(string.Format("请输入要修改的{0}。", lookUpColumnInfo.Text));
                                lookUpUnitUpdate.Focus();
                                return;
                            }
                            setSqlStr = string.Format("{0}='{1}'", DataTypeConvert.GetString(lookUpColumnInfo.EditValue), lookUpUnitUpdate.EditValue);
                            break;
                        case "Brand":
                            if (lookUpBrandUpdate.ItemIndex == -1)
                            {
                                MessageHandler.ShowMessageBox(string.Format("请输入要修改的{0}。", lookUpColumnInfo.Text));
                                lookUpBrandUpdate.Focus();
                                return;
                            }
                            setSqlStr = string.Format("{0}='{1}'", DataTypeConvert.GetString(lookUpColumnInfo.EditValue), lookUpBrandUpdate.EditValue);
                            break;
                        case "MachiningLevel":
                            if (lookUpMachiningLevelUpdate.ItemIndex == -1)
                            {
                                MessageHandler.ShowMessageBox(string.Format("请输入要修改的{0}。", lookUpColumnInfo.Text));
                                lookUpMachiningLevelUpdate.Focus();
                                return;
                            }
                            setSqlStr = string.Format("{0}={1}", DataTypeConvert.GetString(lookUpColumnInfo.EditValue), DataTypeConvert.GetInt(lookUpMachiningLevelUpdate.EditValue));
                            break;
                        case "Finish":
                            if (lookUpFinishUpdate.ItemIndex == -1)
                            {
                                MessageHandler.ShowMessageBox(string.Format("请输入要修改的{0}。", lookUpColumnInfo.Text));
                                lookUpFinishUpdate.Focus();
                                return;
                            }
                            setSqlStr = string.Format("{0}={1}", DataTypeConvert.GetString(lookUpColumnInfo.EditValue), DataTypeConvert.GetInt(lookUpFinishUpdate.EditValue));
                            break;
                        default:
                            if (textEditType.Text.Trim() == "")
                            {
                                MessageHandler.ShowMessageBox(string.Format("请输入要修改的{0}。", lookUpColumnInfo.Text));
                                textEditType.Focus();
                                return;
                            }
                            setSqlStr = string.Format("{0}='{1}'", DataTypeConvert.GetString(lookUpColumnInfo.EditValue), textEditType.Text.Trim());
                            break;
                    }

                    int countInt = pcDAO.QueryPartsCode(queryWhereSqlStr);
                    if (countInt == 0)
                    {
                        MessageHandler.ShowMessageBox("未查询到符合条件的物料信息。");
                        return;
                    }

                    if (MessageHandler.ShowMessageBox_YesNo(string.Format("根据条件查询到{0}条物料信息，确认是否修改？", countInt)) == DialogResult.Yes)
                    {
                        //MessageHandler.ShowMessageBox(string.Format("Update SW_PartsCode set {0} where {1}", setSqlStr, queryWhereSqlStr));
                        pcDAO.UpdatePartsCode(setSqlStr, queryWhereSqlStr);
                        MessageHandler.ShowMessageBox("批量修改成功。");
                    }
                    //this.DialogResult = DialogResult.OK;
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确认批量修改物料信息错误。", ex);
            }
        }

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (typeInt == 1)
                this.DialogResult = DialogResult.Cancel;
            else
            {
                if (queryWhereSqlStr != "")
                    this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 设定查询条件SQL
        /// </summary>
        private bool SetQueryWhereSqlStr()
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

        /// <summary>
        /// 根据类型设定窗体显示效果
        /// </summary>
        private void TypeSetFormState()
        {
            if(typeInt == 1)
            {
                this.Size = new Size(600, 448);
                xtraTabControlUpdate.Visible = false;
                btnExpand.Text = "+";
                BtnConfirm.Text = "确定";
                btnCancel.Text = "取消";
            }
            else
            {
                this.Size = new Size(600, 560);
                xtraTabControlUpdate.Visible = true;
                btnExpand.Text = "-";
                BtnConfirm.Text = "修改";
                btnCancel.Text = "关闭";
            }
        }

    }
}
