using PSAP.DAO.WORKFLOWDAO;
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
    public partial class FrmWorkFlowNToN_Condition : DockContent
    {
        /// <summary>
        /// 业务模块ID
        /// </summary>
        public static string flowModuleIdStr = "";

        /// <summary>
        /// 历史的条件字符串
        /// </summary>
        public static string oldConditionStr = "";

        FrmWorkFlowNToN_ConditionDAO conDAO = new FrmWorkFlowNToN_ConditionDAO();
        FrmWorkFlowModuleDAO wfDAO = new FrmWorkFlowModuleDAO();

        public FrmWorkFlowNToN_Condition()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWorkFlowNToN_Condition_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable wfModuleTable = wfDAO.QueryWorkFlowModule(false);
                if(wfModuleTable.Rows.Count>0)
                {
                    this.Text = string.Format("设定结点模块【{0}】的关系条件", DataTypeConvert.GetString(wfModuleTable.Rows[0]["FlowModuleText"]));
                }
                lookUpConditionItem.Properties.DataSource = conDAO.QueryWorkFlowModuleProper(flowModuleIdStr);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewCondition_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 添加关系条件
        /// </summary>
        private void btnJoin_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewCondition.DataRowCount > 0)
                {
                    if (comBoxRelation.SelectedIndex == -1)
                    {
                        MessageHandler.ShowMessageBox("请选择逻辑关系。");
                        comBoxRelation.Focus();
                        return;
                    }
                }
                if (lookUpConditionItem.ItemIndex == -1)
                {
                    MessageHandler.ShowMessageBox("请选择条件项。");
                    lookUpConditionItem.Focus();
                    return;
                }
                if (comBoxRelationSelect.SelectedIndex == -1)
                {
                    MessageHandler.ShowMessageBox("请选择关系选择。");
                    lookUpConditionItem.Focus();
                    return;
                }

                int columnType = DataTypeConvert.GetInt(lookUpConditionItem.GetColumnValue("DataTypeNo"));
                int type = GetType(columnType);
                string value = "";
                switch (type)
                {
                    case 1:
                        if (spinConditionValue.EditValue == null)
                        {
                            MessageHandler.ShowMessageBox("请输入查询条件值。");
                            spinConditionValue.Focus();
                            return;
                        }
                        value = DataTypeConvert.GetString(spinConditionValue.Value);
                        break;
                    case 2:
                        if (dateConditionValue.EditValue == null)
                        {
                            MessageHandler.ShowMessageBox("请输入查询条件值。");
                            dateConditionValue.Focus();
                            return;
                        }
                        value = DataTypeConvert.GetString(dateConditionValue.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        break;
                    case 3:
                        if (textConditionValue.Text == "")
                        {
                            MessageHandler.ShowMessageBox("请输入查询条件值。");
                            textConditionValue.Focus();
                            return;
                        }
                        value = textConditionValue.Text;
                        break;
                }

                int symbolType = DataTypeConvert.GetString(comBoxRelationSelect.EditValue) != "IN" ? 1 : 2;

                string connect = "";
                string column = DataTypeConvert.GetString(lookUpConditionItem.EditValue);
                string symbol = DataTypeConvert.GetString(comBoxRelationSelect.EditValue);               

                string condStr = "";

                if (gridViewCondition.DataRowCount > 0)
                    connect = comBoxRelation.SelectedIndex == 0 ? "and" : "or";

                switch (type)
                {
                    case 1:
                        if (symbolType == 1)
                            condStr = string.Format("{0} {1} {2} {3}", connect, column, symbol, value);
                        else
                            condStr = string.Format("{0} {1} IN ({2})", connect, column, value);
                        break;
                    case 2:
                        if (symbolType == 1)
                            condStr = string.Format("{0} {1} {2} ‘{3}’", connect, column, symbol, value);
                        else
                            condStr = string.Format("{0} {1} IN ({2})", connect, column, value);
                        break;
                    case 3:
                        if (symbolType == 1)
                            condStr = string.Format("{0} {1} {2} ‘{3}’", connect, column, symbol, value);
                        else
                            condStr = string.Format("{0} {1} IN ({2})", connect, column, value);
                        break;
                }

                DataRow dr = dSCondition.Tables[0].NewRow();
                dr["Condition"] = condStr;
                dSCondition.Tables[0].Rows.Add(dr);

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--添加关系条件错误。", ex);
            }
        }

        /// <summary>
        /// 清除关系条件
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewCondition.GetFocusedDataRow() == null)
                {
                    MessageHandler.ShowMessageBox("请先选择要清除的关系条件后，再进行操作。");
                    return;
                }
                if (gridViewCondition.GetFocusedDataSourceRowIndex() == 0)
                {
                    dSCondition.Tables[0].Rows.Remove(gridViewCondition.GetFocusedDataRow());
                    if (dSCondition.Tables[0].Rows.Count > 0)
                    {
                        string s = DataTypeConvert.GetString(dSCondition.Tables[0].Rows[0]["Condition"]);
                        if (s.Substring(0, 2) == "or")
                        {
                            dSCondition.Tables[0].Rows[0]["Condition"] = s.Substring(3);
                        }
                        else
                        {
                            dSCondition.Tables[0].Rows[0]["Condition"] = s.Substring(4);
                        }
                    }
                }
                else
                {
                    dSCondition.Tables[0].Rows.Remove(gridViewCondition.GetFocusedDataRow());
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--清除关系条件错误。", ex);
            }
        }

        /// <summary>
        /// 根据选择的条件项，变换显示的控件
        /// </summary>
        private void lookUpConditionItem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int columnType = 5;
                if (lookUpConditionItem.ItemIndex == -1)
                {
                    columnType = 5;
                }
                else
                {
                    columnType = DataTypeConvert.GetInt(lookUpConditionItem.GetColumnValue("DataTypeNo"));
                }
                int type = GetType(columnType);
                switch (type)
                {
                    case 1:
                        spinConditionValue.Visible = true;
                        spinConditionValue.Value = 1;
                        textConditionValue.Visible = false;
                        textConditionValue.Text = "";
                        dateConditionValue.Visible = false;
                        dateConditionValue.EditValue = null;
                        break;
                    case 2:
                        dateConditionValue.Visible = true;
                        dateConditionValue.EditValue = DateTime.Now.Date;
                        spinConditionValue.Visible = false;
                        spinConditionValue.EditValue = null;
                        textConditionValue.Visible = false;
                        textConditionValue.Text = "";
                        break;
                    case 3:
                        textConditionValue.Visible = true;
                        textConditionValue.Text = "";
                        dateConditionValue.Visible = false;
                        dateConditionValue.EditValue = null;
                        spinConditionValue.Visible = false;
                        spinConditionValue.EditValue = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--根据选择的条件项，变换显示的控件错误。", ex);
            }
        }

        /// <summary>
        /// 1 数字 2 日期 3 字符串
        /// </summary>
        private int GetType(int columnType)
        {
            switch (columnType)
            {
                case 1://整数数据
                case 2://精确数值数据
                case 3://近似浮点数值数据
                case 7://货币数据类型
                    return 1;
                case 4://日期时间数据
                    return 2;
                case 5://字符串数据
                case 6://Unincode字符串数据
                case 8://标记数据
                case 9://二进制码字符串数据
                default:
                    return 3;
            }
        }

        /// <summary>
        /// 确定当前已选择的关系条件
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string tempStr = "";
                for(int i=0;i< dSCondition.Tables[0].Rows.Count;i++)
                {
                    tempStr += DataTypeConvert.GetString(dSCondition.Tables[0].Rows[i]["Condition"]) + " ";
                }

                this.DialogResult = DialogResult.OK;
                this.Close();

                flowModuleIdStr = tempStr;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确定当前已选择的关系条件错误。", ex);
            }
        }
    }
}
