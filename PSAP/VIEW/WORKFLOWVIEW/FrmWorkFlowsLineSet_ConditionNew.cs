using DevExpress.XtraGrid.Views.Base;
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
    public partial class FrmWorkFlowsLineSet_ConditionNew : DockContent
    {
        /// <summary>
        /// 流程图ID
        /// </summary>
        public static int workFlowsIdInt = 0;

        /// <summary>
        /// 连接线Id
        /// </summary>
        public static int lineIdInt = 0;

        /// <summary>
        /// 连接线名称
        /// </summary>
        public static string lineTextStr = "";

        /// <summary>
        /// 查询条件Id
        /// </summary>
        public static int conditionIdInt = 0;

        /// <summary>
        /// 条件名称
        /// </summary>
        public static string conditionTextStr = "";

        FrmWorkFlowsNodeLineSetDAO setDAO = new FrmWorkFlowsNodeLineSetDAO();

        public FrmWorkFlowsLineSet_ConditionNew()
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
                ControlHandler.DevExpressStyle_ChangeControlLocation(btnListAdd.LookAndFeel.ActiveSkinName, new List<Control> { btnListAdd });

                this.Text = string.Format("设定连接线【{0}】的条件", lineTextStr);

                //DataTable lineTable = setDAO.QueryWorkFlowsLine(lineIdInt);
                //if (lineTable.Rows.Count > 0 && DataTypeConvert.GetInt(lineTable.Rows[0]["LineType"]) == (int)WorkFlowsHandleDAO.LineType.任务分配)
                //{
                //    DataTable workFlowsTable = setDAO.QueryWorkFlows((int)WorkFlowsHandleDAO.OrderType.请购单);
                //    workFlowsIdInt = DataTypeConvert.GetInt(workFlowsTable.Rows[0]["AutoId"]);
                //}

                DataTable typeFieldTable = setDAO.QueryWorkFlowsTypeField(workFlowsIdInt);
                if (typeFieldTable.Rows.Count == 0)
                {
                    MessageHandler.ShowMessageBox("流程图类型没有设定字段，不能设定条件。");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                repLookUpFieldName.DataSource = typeFieldTable;
                repLookUpLogicType.DataSource = DataTypeConvert.EnumToDataTable(typeof(WorkFlowsHandleDAO.LogicRelation), "LogicName", "LogicId");
                repLookUpOperateType.DataSource = DataTypeConvert.ArrayToDataTable(WorkFlowsHandleDAO.OperateRelation, "TypeId", "TypeName");

                textConditionText.Text = conditionTextStr;
                textConditionText.Focus();
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
        /// 单元格值变化进行的操作
        /// </summary>
        private void gridViewCondition_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colFieldName)
                {
                    SetColumnControl(e.RowHandle);
                }
                switch (e.Column.FieldName)
                {
                    case "LogicType":
                    case "FieldName":
                    case "OperateType":
                    case "OperateValue":
                        SetColumnCondition(e.RowHandle);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--单元格值变化进行的操作错误。", ex);
            }
        }

        /// <summary>
        /// 聚焦行改变事件
        /// </summary>
        private void gridViewCondition_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                SetColumnControl(gridViewCondition.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--聚焦行改变事件错误。", ex);
            }
        }

        /// <summary>
        /// 新增设定默认值
        /// </summary>
        private void gridViewCondition_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridViewCondition.SetFocusedRowCellValue("ConditionId", conditionIdInt);
            int maxid = DataTypeConvert.GetInt(((DataSet)bindingSource_Condition.DataSource).Tables[bindingSource_Condition.DataMember].Compute("Max(AutoId)", ""));

            gridViewCondition.SetFocusedRowCellValue("AutoId", maxid + 1);
        }

        /// <summary>
        /// 表按键事件
        /// </summary>
        private void gridViewCondition_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (gridViewCondition.GetFocusedDataSourceRowIndex() >= gridViewCondition.DataRowCount - 1 && gridViewCondition.FocusedColumn == colOperateValue)
                    {
                        btnListAdd_Click(null, null);
                    }
                    else if (gridViewCondition.FocusedColumn == colOperateValue)
                    {
                        gridViewCondition.FocusedRowHandle = gridViewCondition.FocusedRowHandle + 1;
                        FocusedListView(true, "LogicType", gridViewCondition.GetFocusedDataSourceRowIndex());
                    }
                }
                else
                {
                    ControlHandler.GridView_GetFocusedCellDisplayText_KeyDown(sender, e);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--表按键事件错误。", ex);
            }
        }

        /// <summary>
        /// 删除表中的一行
        /// </summary>
        private void repbtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的明细记录吗？") != DialogResult.Yes)
                {
                    return;
                }
                gridViewCondition.DeleteRow(gridViewCondition.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除表中的一行错误。", ex);
            }
        }

        /// <summary>
        /// 新增一行事件
        /// </summary>
        private void btnListAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsHaveBlankLine())
                    return;

                gridViewCondition.AddNewRow();
                FocusedListView(true, "LogicType", gridViewCondition.GetFocusedDataSourceRowIndex());
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--新增一行事件错误。", ex);
            }
        }

        /// <summary>
        /// 确定当前已选择的关系条件
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (textConditionText.Text.Trim() == "")
                {
                    MessageHandler.ShowMessageBox("条件名称不能为空，请重新输入。");
                    textConditionText.Focus();
                    return;
                }

                DataTable fieldTable = (DataTable)repLookUpFieldName.DataSource;
                for (int i = gridViewCondition.DataRowCount - 1; i >= 0; i--)
                {
                    DataRow listRow = gridViewCondition.GetDataRow(i);
                    if (DataTypeConvert.GetString(listRow["LogicType"]) == "")
                    {
                        MessageHandler.ShowMessageBox("逻辑关系不能为空，请填写后再进行确定。");
                        FocusedListView(true, "Qty", i);
                        return;
                    }
                    if (DataTypeConvert.GetString(listRow["FieldName"]) == "")
                    {
                        MessageHandler.ShowMessageBox("条件项不能为空，请填写后再进行确定。");
                        FocusedListView(true, "FieldName", i);
                        return;
                    }
                    if (DataTypeConvert.GetString(listRow["OperateType"]) == "")
                    {
                        MessageHandler.ShowMessageBox("关系选择不能为空，请填写后再进行确定。");
                        FocusedListView(true, "OperateType", i);
                        return;
                    }

                    string fieldNameStr = DataTypeConvert.GetString(listRow["FieldName"]);
                    int columnType = DataTypeConvert.GetInt(fieldTable.Select(string.Format("FieldName='{0}'", fieldNameStr))[0]["DataTypeNo"]);
                    int type = GetType(columnType);
                    switch (type)
                    {
                        case 1:
                            if (DataTypeConvert.GetString(listRow["OperateValue"]) == "")
                            {
                                MessageHandler.ShowMessageBox("条件项是数值类型，条件值不能为空，请填写后再进行确定。");
                                FocusedListView(true, "OperateValue", i);
                                return;
                            }
                            break;
                        case 2:
                            if (DataTypeConvert.GetString(listRow["OperateValue"]) == "")
                            {
                                MessageHandler.ShowMessageBox("条件项是日期类型，条件值不能为空，请填写后再进行确定。");
                                FocusedListView(true, "OperateValue", i);
                                return;
                            }
                            break;
                    }
                }

                string tempStr = "";
                for (int i = 0; i < gridViewCondition.DataRowCount; i++)
                {
                    string conditionStr = DataTypeConvert.GetString(gridViewCondition.GetDataRow(i)["Condition"]) + " ";
                    if (i == 0)
                    {
                        int logicTypeInt = DataTypeConvert.GetInt(gridViewCondition.GetDataRow(i)["LogicType"]);
                        if (logicTypeInt == 0)
                            return;
                        string loginTypeStr = ((WorkFlowsHandleDAO.LogicRelation)logicTypeInt) == WorkFlowsHandleDAO.LogicRelation.并且 ? "and" : "or";
                        conditionStr = conditionStr.Substring(loginTypeStr.Length);
                    }

                    tempStr += conditionStr;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();

                lineTextStr = tempStr;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确定当前已选择的关系条件错误。", ex);
            }
        }

        /// <summary>
        /// 设定条件值列控件
        /// </summary>
        /// <param name="lineNoInt">行号</param>
        private void SetColumnControl(int lineNoInt)
        {
            if (lineNoInt >= 0)
            {
                string fieldNameStr = DataTypeConvert.GetString(gridViewCondition.GetDataRow(lineNoInt)["FieldName"]);
                DataTable fieldTable = (DataTable)repLookUpFieldName.DataSource;
                DataRow[] drs = fieldTable.Select(string.Format("FieldName='{0}'", fieldNameStr));
                if (drs.Length > 0)
                {
                    int columnType = DataTypeConvert.GetInt(drs[0]["DataTypeNo"]);
                    int type = GetType(columnType);
                    switch (type)
                    {
                        case 1:
                            colOperateValue.ColumnEdit = repSpinOperateValue;
                            break;
                        case 2:
                            colOperateValue.ColumnEdit = repDateOperateValue;
                            break;
                        case 3:
                            colOperateValue.ColumnEdit = repTextOperateValue;
                            break;
                    }
                }
                else
                    colOperateValue.ColumnEdit = repTextOperateValue;
            }
        }

        /// <summary>
        /// 设定条件的SQL
        /// </summary>
        /// <param name="lineNoInt">行号</param>
        private void SetColumnCondition(int lineNoInt)
        {
            int logicTypeInt = DataTypeConvert.GetInt(gridViewCondition.GetDataRow(lineNoInt)["LogicType"]);
            if (logicTypeInt == 0)
                return;
            string loginTypeStr = ((WorkFlowsHandleDAO.LogicRelation)logicTypeInt) == WorkFlowsHandleDAO.LogicRelation.并且 ? "and" : "or";

            string fieldNameStr = DataTypeConvert.GetString(gridViewCondition.GetDataRow(lineNoInt)["FieldName"]);
            if (fieldNameStr == "")
                return;
            DataTable fieldTable = (DataTable)repLookUpFieldName.DataSource;
            int columnType = DataTypeConvert.GetInt(fieldTable.Select(string.Format("FieldName='{0}'", fieldNameStr))[0]["DataTypeNo"]);
            int type = GetType(columnType);

            int operateTypeInt = DataTypeConvert.GetInt(gridViewCondition.GetDataRow(lineNoInt)["OperateType"]);
            if (operateTypeInt == 0)
                return;
            string operateTypeStr = WorkFlowsHandleDAO.OperateRelation[operateTypeInt - 1];

            string operateValueStr = DataTypeConvert.GetString(gridViewCondition.GetDataRow(lineNoInt)["OperateValue"]);

            int symbolType = operateTypeStr != "IN" ? 1 : 2;

            string condStr = "";
            switch (type)
            {
                case 1:
                    if (symbolType == 1)
                        condStr = string.Format("{0} {1} {2} {3}", loginTypeStr, fieldNameStr, operateTypeStr, operateValueStr);
                    else
                        condStr = string.Format("{0} {1} IN ({2})", loginTypeStr, fieldNameStr, operateValueStr);
                    break;
                case 2:
                    if (symbolType == 1)
                        condStr = string.Format("{0} {1} {2} ‘{3}’", loginTypeStr, fieldNameStr, operateTypeStr, operateValueStr);
                    else
                        condStr = string.Format("{0} {1} IN ({2})", loginTypeStr, fieldNameStr, operateValueStr);
                    break;
                case 3:
                    if (symbolType == 1)
                        condStr = string.Format("{0} {1} {2} ‘{3}’", loginTypeStr, fieldNameStr, operateTypeStr, operateValueStr);
                    else
                        condStr = string.Format("{0} {1} IN ({2})", loginTypeStr, fieldNameStr, operateValueStr);
                    break;
            }

            gridViewCondition.SetRowCellValue(lineNoInt, gridColCondition, condStr);
        }

        /// <summary>
        /// 检查是否有未填写字段
        /// </summary>
        private bool IsHaveBlankLine()
        {
            gridViewCondition.FocusedRowHandle = 0;
            for (int i = 0; i < gridViewCondition.DataRowCount; i++)
            {
                if (DataTypeConvert.GetString(gridViewCondition.GetDataRow(i)["LogicType"]) == "")
                {
                    gridViewCondition.Focus();
                    gridViewCondition.FocusedColumn = colLogicType;
                    gridViewCondition.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewCondition.GetDataRow(i)["FieldName"]) == "")
                {
                    gridViewCondition.Focus();
                    gridViewCondition.FocusedColumn = colFieldName;
                    gridViewCondition.FocusedRowHandle = i;
                    return true;
                }
                if (DataTypeConvert.GetString(gridViewCondition.GetDataRow(i)["OperateType"]) == "")
                {
                    gridViewCondition.Focus();
                    gridViewCondition.FocusedColumn = colOperateType;
                    gridViewCondition.FocusedRowHandle = i;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 聚焦子表当前行的列
        /// </summary>
        private void FocusedListView(bool isFocusedControl, string colName, int lineNo)
        {
            if (isFocusedControl)
                gridControlCondition.Focus();
            ColumnView listView = (ColumnView)gridControlCondition.FocusedView;
            listView.FocusedColumn = listView.Columns[colName];
            gridViewCondition.FocusedRowHandle = lineNo;
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

    }
}
