using PSAP.DAO.BSDAO;
using PSAP.DAO.PMDAO;
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
    public partial class FrmProjectUserAndTaskType : DockContent
    {
        #region 私有变量

        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmProjectUserAndTaskTypeDAO taskTypeDAO = new FrmProjectUserAndTaskTypeDAO();
        FrmBaseEdit editForm = null;

        #endregion

        #region 构造函数

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public FrmProjectUserAndTaskType()
        {
            InitializeComponent();

            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.TopLevel = false;
                    editForm.TableName = "PM_ProjectTaskType";
                    editForm.TableCaption = "项目任务类别";
                    editForm.Sql = string.Format("select * from PM_ProjectTaskType where ProjectNo = '{0}' order by AutoId", "");
                    editForm.PrimaryKeyColumn = "AutoId";
                    editForm.MasterDataSet = dSProjectTaskType;
                    editForm.MasterBindingSource = bSProjectTaskType;
                    editForm.MasterEditPanel = pnlEditProjectTaskType;
                    editForm.BrowseXtraGridView = gridViewProjectTaskType;
                    editForm.CheckControl += CheckControl;
                    editForm.NewBefore += NewBefore;
                    this.pnlToolBarProjectTaskType.Controls.Add(editForm);
                    editForm.Dock = DockStyle.Fill;
                    editForm.Show();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体构造函数错误。", ex);
            }
        }

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmProjectTaskType_Load(object sender, EventArgs e)
        {
            try
            {
                searchLookUpProjectNo.Properties.DataSource = commonDAO.QueryProjectList(false);


            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 窗体显示事件
        /// </summary>
        private void FrmProjectTaskType_Shown(object sender, EventArgs e)
        {
            TabControlProjectUser.Width = this.Width / 2;
        }

        #endregion

        #region 主区域

        /// <summary>
        /// 选择项目号查询人员信息和任务类别信息
        /// </summary>
        private void searchLookUpProjectNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string projectNoStr = DataTypeConvert.GetString(searchLookUpProjectNo.EditValue);
                RefreshProjectUser(projectNoStr);
                RefreshProjectTaskType(projectNoStr);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择项目号查询人员信息和任务类别信息错误。", ex);
            }
        }

        #endregion

        #region 项目人员区域

        /// <summary>
        /// 刷新项目人员信息
        /// </summary>
        private void RefreshProjectUser(string projectNoStr)
        {
            TableProjectUser.Rows.Clear();
            taskTypeDAO.QueryProjectUser(TableProjectUser, projectNoStr);
        }

        /// <summary>
        /// 设定项目人员信息
        /// </summary>
        private void btnSetProjectUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                FrmSelectUserList userList = new FrmSelectUserList();
                FrmSelectUserList.SelectUserAutoIdList.Clear();
                for (int i = 0; i < gridViewProjectUser.DataRowCount; i++)
                {
                    FrmSelectUserList.SelectUserAutoIdList.Add(DataTypeConvert.GetInt(gridViewProjectUser.GetDataRow(i)["UserId"]));
                }

                if (userList.ShowDialog() == DialogResult.OK)
                {
                    string projectNoStr = DataTypeConvert.GetString(searchLookUpProjectNo.EditValue);
                    taskTypeDAO.SaveProjectUser(projectNoStr, userList.OkSelectUserAutoIdList);
                    RefreshProjectUser(projectNoStr);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定项目人员信息错误。", ex);
            }
        }

        /// <summary>
        /// 设定修改个人计划信息事件
        /// </summary>
        private void btnSetIsPlanEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rowNos = gridViewProjectUser.GetSelectedRows();
                if (rowNos.Length == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的人员信息。");
                    return;
                }

                int resultInt = new CustomXtraMessageBoxForm().ShowMessageBox("请选择是否可以修改个人计划", new string[] { "可以修改", "不可以修改", "取消" });
                int isPlanEditInt = 0;
                switch(resultInt)
                {
                    case 0:
                        isPlanEditInt = 1;
                        break;
                    case 1:
                        isPlanEditInt = 0;
                        break;
                    case 2:
                        return;
                }

                string autoIdListStr = "";
                foreach (int rowno in rowNos)
                {
                    autoIdListStr += string.Format(" {0},", DataTypeConvert.GetString(gridViewProjectUser.GetDataRow(rowno)["AutoId"]));
                }
                autoIdListStr = autoIdListStr.Substring(0, autoIdListStr.Length - 1);
                string projectNoStr = DataTypeConvert.GetString(searchLookUpProjectNo.EditValue);

                taskTypeDAO.UpdateProjectUser_IsPlanEdit(projectNoStr, autoIdListStr, isPlanEditInt);

                RefreshProjectUser(projectNoStr);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定修改个人计划信息事件错误。", ex);
            }
        }

        /// <summary>
        /// 设定代替更新计划进度事件
        /// </summary>
        private void btnSetIsReplace_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rowNos = gridViewProjectUser.GetSelectedRows();
                if (rowNos.Length == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的人员信息。");
                    return;
                }

                int resultInt = new CustomXtraMessageBoxForm().ShowMessageBox("请选择是否可以代替更新计划进度", new string[] { "可以代替", "不可以代替", "取消" });
                int isReplaceInt = 0;
                switch (resultInt)
                {
                    case 0:
                        isReplaceInt = 1;
                        break;
                    case 1:
                        isReplaceInt = 0;
                        break;
                    case 2:
                        return;
                }

                string autoIdListStr = "";
                foreach (int rowno in rowNos)
                {
                    autoIdListStr += string.Format(" {0},", DataTypeConvert.GetString(gridViewProjectUser.GetDataRow(rowno)["AutoId"]));
                }
                autoIdListStr = autoIdListStr.Substring(0, autoIdListStr.Length - 1);
                string projectNoStr = DataTypeConvert.GetString(searchLookUpProjectNo.EditValue);

                taskTypeDAO.UpdateProjectUser_IsReplace(projectNoStr, autoIdListStr, isReplaceInt);

                RefreshProjectUser(projectNoStr);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--设定代替更新计划进度事件错误。", ex);
            }
        }

        #endregion

        #region 任务类别区域

        /// <summary>
        /// 刷新项目任务类别
        /// </summary>
        private void RefreshProjectTaskType(string projectNoStr)
        {
            editForm.Sql = string.Format("select * from PM_ProjectTaskType where ProjectNo = '{0}' order by AutoId", projectNoStr);
            editForm.btnRefresh_Click(null, null);
        }

        /// <summary>
        /// 保存之前的回调方法
        /// </summary>
        public bool CheckControl()
        {
            if (textTaskNo.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("类别编号不能为空，请重新操作。");
                textTaskNo.Focus();
                return false;
            }
            if (textTaskText.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("类别名称不能为空，请重新操作。");
                textTaskText.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 新增之前的回调方法
        /// </summary>
        public bool NewBefore()
        {
            if (searchLookUpProjectNo.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox("请先选择要配置的项目号。");
                searchLookUpProjectNo.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 新增设定默认值
        /// </summary>
        private void TableProjectTaskType_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["ProjectNo"] = DataTypeConvert.GetString(searchLookUpProjectNo.EditValue);
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewProjectTaskType_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewProjectTaskType_KeyDown(object sender, KeyEventArgs e)
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

        #endregion
        
    }
}
