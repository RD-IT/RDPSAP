using PSAP.DAO.BSDAO;
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
    public partial class FrmWorkFlowsLineSet : DockContent
    {
        #region 私有方法

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmWorkFlowsNodeLineSetDAO setDAO = new FrmWorkFlowsNodeLineSetDAO();

        /// <summary>
        /// 连接线Id
        /// </summary>
        private int lineIdInt = 0;

        /// <summary>
        /// 流程图Id
        /// </summary>
        private int workFlowsIdInt = 0;

        /// <summary>
        /// 是否可以编辑流程图信息
        /// </summary>
        public bool isEditWorkFlows = true;

        #endregion

        #region 构造函数

        public FrmWorkFlowsLineSet(int lineIdInt, string workFlowsTextStr, string lineTextStr)
        {
            InitializeComponent();
            this.lineIdInt = lineIdInt;
            if (workFlowsTextStr != "")
                this.Text = string.Format("流程图【{0}】中的连接线设定", workFlowsTextStr);

            textLineText.Text = lineTextStr;
        }

        public FrmWorkFlowsLineSet(int workFlowsIdInt, string workFlowsTextStr, int nextWorkFlowsTypeInt)
        {
            InitializeComponent();
            this.lineIdInt = -1;
            this.workFlowsIdInt = workFlowsIdInt;
            if(workFlowsTextStr !="")
                this.Text = string.Format("流程图【{0}】的下级流程【{1}】设定", workFlowsTextStr, (WorkFlowsHandleDAO.NextWorkFlowsType)nextWorkFlowsTypeInt);
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmWorkFlowsLineSet_Load(object sender, EventArgs e)
        {
            try
            {
                if (!isEditWorkFlows)
                {
                    lookUpLineType.Properties.ReadOnly = true;
                }

                if (lineIdInt == 0)
                {
                    labEnabled.Visible = false;
                    checkEnabled.Visible = false;

                    PageCondition.PageVisible = false;

                    lookUpLineType.Properties.DataSource = DataTypeConvert.EnumToDataTable_NoInclude(typeof(WorkFlowsHandleDAO.LineType), "LineType", "TypeId", new List<int>() { -1, 0 });
                }
                else if (lineIdInt > 0)
                {
                    repLookUpCreator.DataSource = commonDAO.QueryUserInfo(false);
                    repLookUpCreator1.DataSource = repLookUpCreator.DataSource;
                    repLookUpCreator2.DataSource = repLookUpCreator.DataSource;

                    lookUpLineType.Properties.DataSource = DataTypeConvert.EnumToDataTable_NoInclude(typeof(WorkFlowsHandleDAO.LineType), "LineType", "TypeId", new List<int>() { -1, 0 });

                    RefreshLineControlInfo();

                    setDAO.QueryWorkFlowsLineConditionList(TableCondition, lineIdInt);
                }
                else
                {
                    PageBaseInfo.PageVisible = false;
                    BtnCopy.Visible = false;
                    PageLineHandle.PageVisible = false;

                    colMultiLevelApprover.Visible = false;
                    colMultiLevelApprover1.Visible = false;
                    pnlLineHandleTop.Height = 97;
                    btnHandleNew.Location = new Point(298, 54);
                    btnHandleDelete.Location = new Point(354, 54);

                    repLookUpCreator.DataSource = commonDAO.QueryUserInfo(false);
                    repLookUpCreator2.DataSource = repLookUpCreator.DataSource;

                    radioHandleCate_SelectedIndexChanged(null, null);

                    RefreshConditionInfo();

                    setDAO.QueryWorkFlowsLineConditionList(TableCondition, lineIdInt);                    
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 刷新绑定控件信息
        /// </summary>
        private void RefreshLineControlInfo()
        {
            DataTable lineTable = setDAO.QueryWorkFlowsLine(lineIdInt);
            if (lineTable.Rows.Count > 0)
            {
                checkEnabled.EditValue = DataTypeConvert.GetInt(lineTable.Rows[0]["Enabled"]);
                lookUpLineType.EditValue = DataTypeConvert.GetInt(lineTable.Rows[0]["LineType"]);
                workFlowsIdInt = DataTypeConvert.GetInt(lineTable.Rows[0]["WorkFlowsId"]);

                switch (DataTypeConvert.GetInt(lookUpLineType.EditValue))
                {
                    case (int)WorkFlowsHandleDAO.LineType.审批://采用多级操作   可以添加级别

                        labMultiLevelApprover.Visible = true;
                        spinMultiLevelApprover.Visible = true;
                        colMultiLevelApprover.Visible = true;
                        pnlLineHandleTop.Height = 131;
                        btnHandleNew.Location = new Point(209, 88);
                        btnHandleDelete.Location = new Point(265, 88);

                        break;
                    default://不可以添加级别

                        colMultiLevelApprover.Visible = false;
                        colMultiLevelApprover1.Visible = false;
                        pnlLineHandleTop.Height = 97;
                        btnHandleNew.Location = new Point(298, 54);
                        btnHandleDelete.Location = new Point(354, 54);

                        break;
                }

                radioHandleCate_SelectedIndexChanged(null, null);

                RefreshConditionInfo();
            }
        }

        /// <summary>
        /// 窗体激活事件
        /// </summary>
        private void FrmWorkFlowsLineSet_Activated(object sender, EventArgs e)
        {
            if(PageBaseInfo.PageVisible)
                textLineText.Focus();
            else
                radioHandleCate.Focus();
        }

        /// <summary>
        /// 保存连接线信息事件
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (PageBaseInfo.PageVisible)
                {
                    if (textLineText.Text.Trim() == "")
                    {
                        MessageHandler.ShowMessageBox("连接线名称不能为空，请重新输入。");
                        return;
                    }
                    if (lookUpLineType.ItemIndex == -1)
                    {
                        MessageHandler.ShowMessageBox("连接线类型不能为空，请重新输入。");
                        return;
                    }
                }

                if (lineIdInt != 0)
                {
                    if(!setDAO.SaveWorkFlowsLineSet(lineIdInt, textLineText.Text.Trim(), DataTypeConvert.GetInt(checkEnabled.EditValue), DataTypeConvert.GetInt(lookUpLineType.EditValue), TableLineCondition, TableLineHandle, TableLineNotice,TableCondition))
                    {
                        return;
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--保存连接线信息事件错误。", ex);
            }
        }

        #endregion

        #region 条件设定页的事件

        /// <summary>
        /// 设定列表显示信息
        /// </summary>
        private void gridViewLineHandle_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "LineHandleCate")
            {
                switch (e.Value.ToString())
                {
                    case "0":
                        e.DisplayText = "操作员";
                        break;
                    case "1":
                        e.DisplayText = "权限角色";
                        break;
                }
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewLineHandle_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewLineHandle_KeyDown(object sender, KeyEventArgs e)
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
        /// 新增查询条件事件
        /// </summary>
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                int minId = DataTypeConvert.GetInt(TableLineCondition.Compute("min(AutoId)", ""));
                int newId = minId > 0 ? -1 : minId - 1;

                DataTable copyTable = TableCondition.Copy();
                FrmWorkFlowsLineSet_ConditionNew.workFlowsIdInt = workFlowsIdInt;
                FrmWorkFlowsLineSet_ConditionNew.lineIdInt = lineIdInt;
                FrmWorkFlowsLineSet_ConditionNew.lineTextStr = textLineText.Text.Trim();
                FrmWorkFlowsLineSet_ConditionNew.conditionIdInt = newId;
                FrmWorkFlowsLineSet_ConditionNew.conditionTextStr = "";
                FrmWorkFlowsLineSet_ConditionNew condForm = new FrmWorkFlowsLineSet_ConditionNew();
                condForm.bindingSource_Condition.DataSource = dSCondition;
                condForm.bindingSource_Condition.DataMember = "Condition";
                condForm.bindingSource_Condition.Filter = string.Format("ConditionId = {0}", newId);                

                if (condForm.ShowDialog() == DialogResult.OK)
                {
                    string whereSql = FrmWorkFlowsLineSet_ConditionNew.lineTextStr;
                    string conditionTextStr = condForm.textConditionText.Text.Trim();
                    //int autoIdInt = setDAO.InsertWorkFlowsLineCondition(lineIdInt, conditionTextStr, whereSql, workFlowsIdInt);
                    //RefreshLineControlInfo();
                    //if (autoIdInt > 0)
                    //    RefreshConditionInfo(autoIdInt);                    

                    DataRow dr = TableLineCondition.NewRow();
                    dr["AutoId"] = newId;
                    dr["LineId"] = lineIdInt;
                    dr["ConditionText"] = conditionTextStr;
                    dr["Condition"] = whereSql;
                    dr["Creator"] = SystemInfo.user.AutoId;
                    dr["GetTime"] = BaseSQL.GetServerDateTime();
                    dr["WorkFlowsId"] = workFlowsIdInt;
                    TableLineCondition.Rows.Add(dr);
                    bSLineCondition.MoveLast();
                }
                else
                {
                    dSCondition.Tables[0].Rows.Clear();
                    foreach (DataRow copyRow in copyTable.Rows)
                    {
                        TableCondition.ImportRow(copyRow);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--新增查询条件事件错误。", ex);
            }
        }

        /// <summary>
        /// 删除查询条件事件
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow focusedRow = gridViewLineCondition.GetFocusedDataRow();
                if (focusedRow == null)
                {
                    MessageHandler.ShowMessageBox("请先选择要删除的条件信息后，再进行操作。");
                    return;
                }


                if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的记录吗？") != DialogResult.Yes)
                {
                    return;
                }

                if (gridViewLineHandle.DataRowCount > 0 || gridViewLineNotice.DataRowCount > 0)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("当前条件设定了处理人员或者通知人员，确定是否继续删除？") != DialogResult.Yes)
                        return;
                }

                for (int i = gridViewLineHandle.DataRowCount - 1; i >= 0; i--)
                {
                    gridViewLineHandle.GetDataRow(i).Delete();
                }

                for (int i = gridViewLineNotice.DataRowCount - 1; i >= 0; i--)
                {
                    gridViewLineNotice.GetDataRow(i).Delete();
                }

                int conditionAutoIdInt = DataTypeConvert.GetInt(focusedRow["AutoId"]);
                focusedRow.Delete();
                //if (setDAO.DeleteWorkFlowsLineCondition(conditionAutoIdInt))
                //{
                //    MessageHandler.ShowMessageBox("删除成功。");
                //    RefreshLineControlInfo();
                //}
                gridViewLineCondition_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除查询条件事件错误。", ex);
            }
        }

        /// <summary>
        /// 双击查询明细
        /// </summary>
        private void gridViewLineCondition_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                {
                    DataTable copyTable = dSCondition.Tables[0].Copy();

                    int conditionIdInt = DataTypeConvert.GetInt(gridViewLineCondition.GetFocusedDataRow()["AutoId"]);
                    FrmWorkFlowsLineSet_ConditionNew.workFlowsIdInt = workFlowsIdInt;
                    FrmWorkFlowsLineSet_ConditionNew.lineIdInt = lineIdInt;
                    FrmWorkFlowsLineSet_ConditionNew.lineTextStr = textLineText.Text.Trim();
                    FrmWorkFlowsLineSet_ConditionNew.conditionIdInt = conditionIdInt;
                    FrmWorkFlowsLineSet_ConditionNew.conditionTextStr = DataTypeConvert.GetString(gridViewLineCondition.GetFocusedDataRow()["ConditionText"]);
                    FrmWorkFlowsLineSet_ConditionNew condForm = new FrmWorkFlowsLineSet_ConditionNew();
                    condForm.bindingSource_Condition.DataSource = dSCondition;
                    condForm.bindingSource_Condition.DataMember = "Condition";
                    condForm.bindingSource_Condition.Filter = string.Format("ConditionId = {0}", conditionIdInt);

                    if (condForm.ShowDialog() == DialogResult.OK)
                    {
                        gridViewLineCondition.GetFocusedDataRow()["ConditionText"] = condForm.textConditionText.Text.Trim();
                        gridViewLineCondition.GetFocusedDataRow()["Condition"] = FrmWorkFlowsLineSet_ConditionNew.lineTextStr;
                    }
                    else
                    {
                        dSCondition.Tables[0].Rows.Clear();
                        foreach (DataRow copyRow in copyTable.Rows)
                        {
                            TableCondition.ImportRow(copyRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--双击查询明细错误。", ex);
            }
        }

        /// <summary>
        /// 聚焦条件列表信息事件
        /// </summary>
        private void gridViewLineCondition_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow focusedRow = gridViewLineCondition.GetFocusedDataRow();
                if (focusedRow != null)
                {
                    int conditionAutoIdInt = DataTypeConvert.GetInt(focusedRow["AutoId"]);

                    string filterStr = string.Format("ConditionId = {0}", conditionAutoIdInt);
                    BSLineHandle.Filter = filterStr;
                    BSLineNotice.Filter = filterStr;

                    int maxLevel = DataTypeConvert.GetInt(TableLineHandle.Compute("Max(MultiLevelApprover)", filterStr));
                    spinMultiLevelApprover.Value = maxLevel < 1 ? 1 : maxLevel;
                }
                else
                {
                    BSLineHandle.Filter = "1=2";
                    BSLineNotice.Filter = "1=2";

                    spinMultiLevelApprover.Value = 1;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--聚焦条件列表信息事件错误。", ex);
            }
        }

        /// <summary>
        /// 刷新条件信息列表
        /// </summary>
        public void RefreshConditionInfo()
        {
            TableLineCondition.Rows.Clear();
            setDAO.QueryWorkFlowsLineCondition(TableLineCondition, lineIdInt, workFlowsIdInt);

            TableLineHandle.Rows.Clear();
            setDAO.QueryWorkFlowsLineHandle(TableLineHandle, lineIdInt, workFlowsIdInt);

            TableLineNotice.Rows.Clear();
            setDAO.QueryWorkFlowsLineNotice(TableLineNotice, lineIdInt, workFlowsIdInt);
        }

        /// <summary>
        /// 处理人员和通知人员进行转换
        /// </summary>
        private void TabControlConditionOtherInfo_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (TabControlConditionOtherInfo.SelectedTabPage == PageLineHandle)
            {
                labHandleCate.Text = "处理人员类型";
            }
            else
            {
                labHandleCate.Text = "通知人员类型";
            }
        }

        /// <summary>
        /// 选择操作员或者权限角色
        /// </summary>
        private void radioHandleCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioHandleCate.SelectedIndex == 0)//操作员
                {
                    labHandleOwner.Text = "操作员";
                    searchLookUpHandleOwner.Properties.DataSource = commonDAO.QueryUserInfo(false);
                    searchLookUpHandleOwner.Properties.DisplayMember = "EmpName";
                    searchLookUpHandleOwner.Properties.ValueMember = "LoginId";
                    searchLookUpHandleOwner.EditValue = null;

                    gridColRoleNo.Visible = false;
                    gridColRoleName.Visible = false;
                    gridColLoginId.Visible = true;
                    gridColEmpName.Visible = true;
                }
                else//权限角色
                {
                    labHandleOwner.Text = "权限角色";
                    searchLookUpHandleOwner.Properties.DataSource = commonDAO.QueryRole(false);
                    searchLookUpHandleOwner.Properties.DisplayMember = "RoleName";
                    searchLookUpHandleOwner.Properties.ValueMember = "RoleNo";
                    searchLookUpHandleOwner.EditValue = null;

                    gridColLoginId.Visible = false;
                    gridColEmpName.Visible = false;
                    gridColRoleNo.Visible = true;
                    gridColRoleName.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择操作员或者权限角色错误。", ex);
            }
        }

        /// <summary>
        /// 新增操作员或权限角色
        /// </summary>
        private void btnHandleNew_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow focusedRow = gridViewLineCondition.GetFocusedDataRow();
                if (focusedRow == null)
                {
                    MessageHandler.ShowMessageBox("请先新增条件信息后，再进行新增处理人员或通知人员的操作。");
                    btnNew.Focus();
                    return;
                }
                string handleOwnerStr = DataTypeConvert.GetString(searchLookUpHandleOwner.EditValue);
                if (handleOwnerStr == "")
                {
                    MessageHandler.ShowMessageBox("请选择要登记的操作员或者权限角色。");
                    searchLookUpHandleOwner.Focus();
                    return;
                }
                int conditionAutoIdInt = DataTypeConvert.GetInt(focusedRow["AutoId"]);

                if (TabControlConditionOtherInfo.SelectedTabPage == PageLineHandle)//处理人员
                {
                    //setDAO.InsertWorkFlowsLineHandle(lineIdInt, conditionAutoIdInt, radioHandleCate.SelectedIndex, DataTypeConvert.GetString(searchLookUpHandleOwner.EditValue), DataTypeConvert.GetInt(spinMultiLevelApprover.EditValue));
                    //RefreshHandleInfo(conditionAutoIdInt);

                    DataRow dr = TableLineHandle.NewRow();
                    dr["LineId"] = lineIdInt > 0 ? lineIdInt : (object)DBNull.Value;
                    dr["ConditionId"] = conditionAutoIdInt;
                    dr["MultiLevelApprover"] = DataTypeConvert.GetInt(spinMultiLevelApprover.EditValue);
                    dr["LineHandleCate"] = radioHandleCate.SelectedIndex;
                    dr["HandleOwner"] = DataTypeConvert.GetString(searchLookUpHandleOwner.EditValue);
                    dr["HandleName"] = searchLookUpHandleOwner.Text;
                    dr["Creator"] = SystemInfo.user.AutoId;
                    dr["GetTime"] = BaseSQL.GetServerDateTime();
                    TableLineHandle.Rows.Add(dr);
                    BSLineHandle.MoveLast();
                }
                else if (TabControlConditionOtherInfo.SelectedTabPage == PageLineNotice)//通知人员
                {
                    //setDAO.InsertWorkFlowsLineNotice(lineIdInt, conditionAutoIdInt, radioHandleCate.SelectedIndex, DataTypeConvert.GetString(searchLookUpHandleOwner.EditValue), DataTypeConvert.GetInt(spinMultiLevelApprover.EditValue));
                    //RefreshNoticeInfo(conditionAutoIdInt);
                    DataRow dr = TableLineNotice.NewRow();
                    dr["LineId"] = lineIdInt > 0 ? lineIdInt : (object)DBNull.Value;
                    dr["ConditionId"] = conditionAutoIdInt;
                    dr["MultiLevelApprover"] = DataTypeConvert.GetInt(spinMultiLevelApprover.EditValue);
                    dr["LineHandleCate"] = radioHandleCate.SelectedIndex;
                    dr["HandleOwner"] = DataTypeConvert.GetString(searchLookUpHandleOwner.EditValue);
                    dr["HandleName"] = searchLookUpHandleOwner.Text;
                    dr["Creator"] = SystemInfo.user.AutoId;
                    dr["GetTime"] = BaseSQL.GetServerDateTime();
                    TableLineNotice.Rows.Add(dr);
                    BSLineNotice.MoveLast();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--新增操作员或权限角色错误。", ex);
            }
        }

        /// <summary>
        /// 删除操作员或权限角色
        /// </summary>
        private void btnHandleDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow focusedConditionRow = gridViewLineCondition.GetFocusedDataRow();
                if (focusedConditionRow == null)
                {
                    MessageHandler.ShowMessageBox("请先新增条件信息后，再进行处理人员或通知人员的操作。");
                    btnNew.Focus();
                    return;
                }
                int conditionAutoIdInt = DataTypeConvert.GetInt(focusedConditionRow["AutoId"]);

                if (MessageHandler.ShowMessageBox_YesNo("确定要删除当前选中的记录吗？") != DialogResult.Yes)
                {
                    return;
                }

                if (TabControlConditionOtherInfo.SelectedTabPage == PageLineHandle)//处理人员
                {
                    DataRow focusedRow = gridViewLineHandle.GetFocusedDataRow();
                    if (focusedRow == null)
                    {
                        MessageHandler.ShowMessageBox("请先选择要删除的处理人员信息后，再进行操作。");
                        return;
                    }
                    int handleAutoIdInt = DataTypeConvert.GetInt(focusedRow["AutoId"]);
                    focusedRow.Delete();
                    //setDAO.DeleteWorkFlowsLineHandle(handleAutoIdInt);
                    //MessageHandler.ShowMessageBox("删除处理人员信息成功。");
                    //RefreshHandleInfo(conditionAutoIdInt);
                }
                else if (TabControlConditionOtherInfo.SelectedTabPage == PageLineNotice)//通知人员
                {
                    DataRow focusedRow = gridViewLineNotice.GetFocusedDataRow();
                    if (focusedRow == null)
                    {
                        MessageHandler.ShowMessageBox("请先选择要删除的通知人员信息后，再进行操作。");
                        return;
                    }
                    int noticeAutoIdInt = DataTypeConvert.GetInt(focusedRow["AutoId"]);
                    focusedRow.Delete();
                    //setDAO.DeleteWorkFlowsLineNotice(noticeAutoIdInt);
                    //MessageHandler.ShowMessageBox("删除通知人员信息成功。");
                    //RefreshNoticeInfo(conditionAutoIdInt);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--删除操作员或权限角色错误。", ex);
            }
        }

        /// <summary>
        /// 复制处理人员信息到通知人员事件
        /// </summary>
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow focusedConditionRow = gridViewLineCondition.GetFocusedDataRow();
                if (focusedConditionRow == null)
                {
                    MessageHandler.ShowMessageBox("请先新增条件信息后，再进行处理人员或通知人员的操作。");
                    btnNew.Focus();
                    return;
                }
                int conditionAutoIdInt = DataTypeConvert.GetInt(focusedConditionRow["AutoId"]);

                if (gridViewLineHandle.DataRowCount == 0)
                {
                    MessageHandler.ShowMessageBox("没有处理人员可以进行复制，请添加处理人员后再进行操作。");
                    return;
                }
                if (gridViewLineNotice.DataRowCount > 0)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("通知人员已经有记录，确认是否删除之前的通知人员，复制处理人员信息吗？") != DialogResult.Yes)
                        return;
                }

                for (int i = gridViewLineNotice.DataRowCount - 1; i >= 0; i--)
                {
                    gridViewLineNotice.GetDataRow(i).Delete();
                }

                for (int i = 0; i < gridViewLineHandle.DataRowCount; i++)
                {
                    DataRow dr = gridViewLineHandle.GetDataRow(i);
                    DataRow newRow = TableLineNotice.NewRow();
                    newRow["LineId"] = dr["LineId"];
                    newRow["ConditionId"] = dr["ConditionId"];
                    newRow["MultiLevelApprover"] = dr["MultiLevelApprover"];
                    newRow["LineHandleCate"] = dr["LineHandleCate"];
                    newRow["HandleOwner"] = dr["HandleOwner"];
                    newRow["HandleName"] = dr["HandleName"];
                    newRow["Creator"] = SystemInfo.user.AutoId;
                    newRow["GetTime"] = BaseSQL.GetServerDateTime();
                    TableLineNotice.Rows.Add(newRow);
                }

                MessageHandler.ShowMessageBox("通知人员复制成功。");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--复制处理人员信息到通知人员事件错误。", ex);
            }
        }

        #endregion

    }
}
