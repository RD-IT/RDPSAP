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
    public partial class FrmSystemSet : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmSystemDAO systemDAO = new FrmSystemDAO();

        bool LoadSystemSet = true;

        public FrmSystemSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmSystemSet_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSystemSet = true;

                systemDAO.QuerySystemParameter(dataSet_SystemParameter.Tables[0]);

                SetSysParameterDefaultValue();

                LoadSystemSet = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                LoadSystemSet = false;
            }
        }

        /// <summary>
        /// 设定系统参数默认值
        /// </summary>
        private void SetSysParameterDefaultValue()
        {
            #region 常规

            string tmpStr = GetValue("Common", "PageRowCount");
            if (tmpStr != "")
                spinPageRowCount.Value = DataTypeConvert.GetInt(tmpStr);
            else
                spinPageRowCount.Value = 500;

            tmpStr = GetValue("Common", "DateIntervalDays");
            if (tmpStr != "")
                spinDateIntervalDays.Value = DataTypeConvert.GetInt(tmpStr);
            else
                spinDateIntervalDays.Value = 14;

            tmpStr = GetValue("Common", "FormDragDropMaxRecordCount");
            if (tmpStr != "")
                spinFormDragDropMaxRecordCount.Value = DataTypeConvert.GetInt(tmpStr);
            else
                spinFormDragDropMaxRecordCount.Value = 50;

            tmpStr = GetValue("Common", "LeftDockWidth");
            if (tmpStr != "")
                spinLeftDockWidth.Value = DataTypeConvert.GetInt(tmpStr);
            else
                spinLeftDockWidth.Value = 400;

            tmpStr = GetValue("Common", "EnableWorkFlowMessage");
            if (tmpStr != "")
                checkEnableWorkFlowMessage.EditValue = tmpStr;
            else
                checkEnableWorkFlowMessage.Checked = false;

            tmpStr = GetValue("Common", "MessageInterval");
            if (tmpStr != "")
                spinMessageInterval.Value = DataTypeConvert.GetInt(tmpStr);
            else
                spinMessageInterval.Value = 10;

            tmpStr = GetValue("Common", "ApproveAfterPrint");
            if (tmpStr != "")
                checkApproveAfterPrint.EditValue = tmpStr;
            else
                checkApproveAfterPrint.Checked = true;

            #endregion

            #region 销售

            tmpStr = GetValue("Sale", "QuotationDefaultTax");
            if (tmpStr != "")
                spinQuotationDefaultTax.Value = DataTypeConvert.GetDecimal(tmpStr);
            else
                spinQuotationDefaultTax.Value = 0.16M;

            tmpStr = GetValue("Sale", "SalesOrderDefaultTax");
            if (tmpStr != "")
                spinSalesOrderDefaultTax.Value = DataTypeConvert.GetDecimal(tmpStr);
            else
                spinSalesOrderDefaultTax.Value = 0.16M;

            #endregion

            #region 项目

            tmpStr = GetValue("Project", "GanttResourcesPerPage");
            if (tmpStr != "")
                spinGanttResourcesPerPage.Value = DataTypeConvert.GetDecimal(tmpStr);
            else
                spinGanttResourcesPerPage.Value = 12;

            tmpStr = GetValue("Project", "GanttSchedulerBarHeight");
            if (tmpStr != "")
                spinGanttSchedulerBarHeight.Value = DataTypeConvert.GetDecimal(tmpStr);
            else
                spinGanttSchedulerBarHeight.Value = 30;

            tmpStr = GetValue("Project", "GanttSchedulerBarColor");
            if (tmpStr != "")
                colorPickGanttSchedulerBarColor.Color = ColorTranslator.FromHtml(tmpStr);
            else
                colorPickGanttSchedulerBarColor.Color = Color.FromArgb(128, 255, 128);

            #endregion

            #region 采购

            tmpStr = GetValue("Purchase", "PrReqIsAlterPSBomAutoId");
            if (tmpStr != "")
                checkPrReqIsAlterPSBomAutoId.EditValue = tmpStr;
            else
                checkPrReqIsAlterPSBomAutoId.Checked = false;

            tmpStr = GetValue("Purchase", "OrderListDefaultTax");
            if (tmpStr != "")
                spinOrderListDefaultTax.Value = DataTypeConvert.GetDecimal(tmpStr);
            else
                spinOrderListDefaultTax.Value = 0.16M;

            tmpStr = GetValue("Purchase", "SettlementDefaultTax");
            if (tmpStr != "")
                spinSettlementDefaultTax.Value = DataTypeConvert.GetDecimal(tmpStr);
            else
                spinSettlementDefaultTax.Value = 0.16M;

            tmpStr = GetValue("Purchase", "OrderNoWarehousingDays");
            if (tmpStr != "")
                spinOrderNoWarehousingDays.Value = DataTypeConvert.GetInt(tmpStr);
            else
                spinOrderNoWarehousingDays.Value = 5;

            tmpStr = GetValue("Purchase", "PrReqApplyBeyondCountIsSave");
            if (tmpStr != "")
                checkPrReqApplyBeyondCountIsSave.EditValue = tmpStr;
            else
                checkPrReqApplyBeyondCountIsSave.Checked = false;

            tmpStr = GetValue("Purchase", "WWApplyBeyondCountIsSave");
            if (tmpStr != "")
                checkWWApplyBeyondCountIsSave.EditValue = tmpStr;
            else
                checkWWApplyBeyondCountIsSave.Checked = false;

            #endregion

            #region 库存

            tmpStr = GetValue("Warehouse", "OrderApplyBeyondCountIsSave");
            if (tmpStr != "")
                checkOrderApplyBeyondCountIsSave.EditValue = tmpStr;
            else
                checkOrderApplyBeyondCountIsSave.Checked = false;

            tmpStr = GetValue("Warehouse", "WWIsAlterDate");
            if (tmpStr != "")
                checkWWIsAlterDate.EditValue = tmpStr;
            else
                checkWWIsAlterDate.Checked = false;

            tmpStr = GetValue("Warehouse", "WRIsAlterDate");
            if (tmpStr != "")
                checkWRIsAlterDate.EditValue = tmpStr;
            else
                checkWRIsAlterDate.Checked = false;

            tmpStr = GetValue("Warehouse", "DisableProjectNo");
            if (tmpStr != "")
                checkDisableProjectNo.EditValue = tmpStr;
            else
                checkDisableProjectNo.Checked = false;

            tmpStr = GetValue("Warehouse", "DisableShelfInfo");
            if (tmpStr != "")
                checkDisableShelfInfo.EditValue = tmpStr;
            else
                checkDisableShelfInfo.Checked = false;

            tmpStr = GetValue("Warehouse", "EnableNegativeInventory");
            if (tmpStr != "")
                checkEnableNegativeInventory.EditValue = tmpStr;
            else
                checkEnableNegativeInventory.Checked = false;

            #endregion

            #region 生产



            #endregion

            #region 人事



            #endregion

            #region 会计



            #endregion

            #region 系统

            tmpStr = GetValue("System", "BackupPath");
            if (tmpStr != "")
                textBackupPath.Text = tmpStr;
            else
                textBackupPath.Text = @"D:\DATA\";

            #endregion
        }

        /// <summary>
        /// 保存系统设定
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                #region 常规
                SetValue("Common", "PageRowCount", DataTypeConvert.GetString(spinPageRowCount.Value));
                SetValue("Common", "DateIntervalDays", DataTypeConvert.GetString(spinDateIntervalDays.Value));
                SetValue("Common", "FormDragDropMaxRecordCount", DataTypeConvert.GetString(spinFormDragDropMaxRecordCount.Value));
                SetValue("Common", "LeftDockWidth", DataTypeConvert.GetString(spinLeftDockWidth.Value));
                SetValue("Common", "EnableWorkFlowMessage", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkEnableWorkFlowMessage.EditValue)));
                SetValue("Common", "MessageInterval", DataTypeConvert.GetString(spinMessageInterval.Value));
                SetValue("Common", "ApproveAfterPrint", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkApproveAfterPrint.EditValue)));
                #endregion

                #region 销售
                SetValue("Sale", "QuotationDefaultTax", DataTypeConvert.GetString(spinQuotationDefaultTax.Value));
                SetValue("Sale", "SalesOrderDefaultTax", DataTypeConvert.GetString(spinSalesOrderDefaultTax.Value));
                #endregion

                #region 项目
                SetValue("Project", "GanttResourcesPerPage", DataTypeConvert.GetString(spinGanttResourcesPerPage.Value));
                SetValue("Project", "GanttSchedulerBarHeight", DataTypeConvert.GetString(spinGanttSchedulerBarHeight.Value));
                SetValue("Project", "GanttSchedulerBarColor", ColorTranslator.ToHtml(colorPickGanttSchedulerBarColor.Color));
                #endregion

                #region 采购
                SetValue("Purchase", "PrReqIsAlterPSBomAutoId", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkPrReqIsAlterPSBomAutoId.EditValue)));
                SetValue("Purchase", "OrderListDefaultTax", DataTypeConvert.GetString(spinOrderListDefaultTax.Value));
                SetValue("Purchase", "SettlementDefaultTax", DataTypeConvert.GetString(spinSettlementDefaultTax.Value));
                SetValue("Purchase", "OrderNoWarehousingDays", DataTypeConvert.GetString(spinOrderNoWarehousingDays.Value));
                SetValue("Purchase", "PrReqApplyBeyondCountIsSave", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkPrReqApplyBeyondCountIsSave.EditValue)));
                SetValue("Purchase", "WWApplyBeyondCountIsSave", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkWWApplyBeyondCountIsSave.EditValue)));
                #endregion

                #region 库存
                SetValue("Warehouse", "OrderApplyBeyondCountIsSave", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkOrderApplyBeyondCountIsSave.EditValue)));
                SetValue("Warehouse", "WWIsAlterDate", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkWWIsAlterDate.EditValue)));
                SetValue("Warehouse", "WRIsAlterDate", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkWRIsAlterDate.EditValue)));
                SetValue("Warehouse", "DisableProjectNo", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkDisableProjectNo.EditValue)));
                SetValue("Warehouse", "DisableShelfInfo", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkDisableShelfInfo.EditValue)));
                SetValue("Warehouse", "EnableNegativeInventory", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkEnableNegativeInventory.EditValue)));

                if (checkDisableProjectNo.Checked)
                {
                    systemDAO.Insert_Default_ProjectListAndStnList();
                }
                if(checkDisableShelfInfo.Checked)
                {
                    systemDAO.Insert_Default_ShelfInfo();
                }

                #endregion

                #region 系统
                SetValue("System", "BackupPath", textBackupPath.Text);
                #endregion

                if (systemDAO.SaveSystemParameter(TableSysParameter))
                {
                    MessageHandler.ShowMessageBox("保存系统设定成功。");
                    dataSet_SystemParameter.Tables[0].Rows.Clear();
                    systemDAO.QuerySystemParameter(dataSet_SystemParameter.Tables[0]);

                    systemDAO.RefreshAllSystemParameter();
                }
                else
                {
                    MessageHandler.ShowMessageBox("保存失败。");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--保存系统设定错误。", ex);
            }
        }

        /// <summary>
        /// 系统参数全部初始化
        /// </summary>
        private void btnSetinitialization_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSystemSet = true;

                dataSet_SystemParameter.Tables[0].Rows.Clear();

                SetSysParameterDefaultValue();

                LoadSystemSet = false;

                MessageHandler.ShowMessageBox("系统参数恢复初始化，请确认完毕参数后点击保存。");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--系统参数全部初始化错误。", ex);
                LoadSystemSet = false;
            }
        }

        /// <summary>
        /// 根据模块号和Key索引临时表的Value
        /// </summary>
        private string GetValue(string moduleCateStr, string keyStr)
        {
            DataRow[] drs = TableSysParameter.Select(string.Format("ModuleCate = '{0}' and ParameterKey = '{1}'", moduleCateStr, keyStr));
            if (drs.Length == 0)
                return "";
            else
                return DataTypeConvert.GetString(drs[0]["ParameterValue"]);
        }

        /// <summary>
        /// 根据模块号和Key索引设定Value值
        /// </summary>
        private void SetValue(string moduleCateStr, string keyStr, string valueStr)
        {
            DataRow[] drs = TableSysParameter.Select(string.Format("ModuleCate = '{0}' and ParameterKey = '{1}'", moduleCateStr, keyStr));
            if (drs.Length > 0)
                drs[0]["ParameterValue"] = valueStr;
            else
            {
                DataRow dr = TableSysParameter.NewRow();
                dr["ModuleCate"] = moduleCateStr;
                dr["ParameterKey"] = keyStr;
                dr["ParameterValue"] = valueStr;
                TableSysParameter.Rows.Add(dr);
            }
        }

        #region 备份数据库

        /// <summary>
        /// 备份服务器的数据库
        /// </summary>
        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBackupPath.Text.Trim() == "")
                {
                    MessageHandler.ShowMessageBox("数据库备份路径不能为空，请重新操作。");
                    return;
                }

                DateTime nowTime = BaseSQL.GetServerDateTime();
                string fileNameStr = string.Format("{0}-{1}.bak", SystemInfo.ServerDataBaseName, nowTime.ToString("yyyyMMddHHmmss"));
                string filePathNameStr = string.Format("{0}\\{1}", textBackupPath.Text.Trim(), fileNameStr);
                if (BaseSQL.BackupDataBase(SystemInfo.ServerDataBaseName, filePathNameStr))//数据库SQL备份，没有进度条
                {
                    MessageHandler.ShowMessageBox(string.Format("备份数据库成功，文件名为[{0}]。", fileNameStr));
                }

                //if (BackupDataBase(SystemInfo.ServerDataBaseName, filePathNameStr, progressBarBackup))//引用SQLDMO类备份，有进度条
                //{
                //    MessageHandler.ShowMessageBox(string.Format("备份数据库成功，文件名为[{0}]。", fileNameStr));
                //}
            }
            catch (Exception ex)
            {
                MessageHandler.ShowMessageBox(string.Format("备份数据库失败--{0}。", ex.Message));
            }
        }

        #region 引用SQLDMO类备份数据库，有进度条  暂时不用，客户端还得注册控件，比较麻烦

        ///// <summary>
        ///// 备份数据库
        ///// </summary>
        //public bool BackupDataBase(string strDbName, string strFileName, ProgressBar proBar)
        //{
        //    SQLDMO.SQLServer sqlServer = new SQLDMO.SQLServer();
        //    try
        //    {
        //        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PSAP.Properties.Settings.PSAPConnectionString"].ConnectionString;
        //        string tmpStr = "Data Source=";
        //        string DataSource = connectionString.Substring(connectionString.IndexOf(tmpStr) + tmpStr.Length);
        //        DataSource = DataSource.Substring(0, DataSource.IndexOf(";"));

        //        tmpStr = "User ID=";
        //        string UserID = connectionString.Substring(connectionString.IndexOf(tmpStr) + tmpStr.Length);
        //        if (UserID.IndexOf(";") == -1)
        //            UserID = UserID.Substring(0);
        //        else
        //            UserID = UserID.Substring(0, UserID.IndexOf(";"));

        //        tmpStr = "Password=";
        //        string Password = connectionString.Substring(connectionString.IndexOf(tmpStr) + tmpStr.Length);
        //        if (Password.IndexOf(";") == -1)
        //            Password = Password.Substring(0);
        //        else
        //            Password = Password.Substring(0, Password.IndexOf(";"));

        //        sqlServer.Connect(DataSource, UserID, Password);
        //        SQLDMO.Backup backup = new SQLDMO.Backup();
        //        proBar.Value = 0;
        //        backup.Action = SQLDMO.SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;
        //        backup.Initialize = true;
        //        backup.PercentComplete += new SQLDMO.BackupSink_PercentCompleteEventHandler(Backup_PercentComplete);
        //        backup.Files = strFileName;
        //        backup.Database = strDbName;
        //        backup.PercentCompleteNotification = 1;
        //        backup.SQLBackup(sqlServer);
        //        proBar.Value = 100;
        //        backup.PercentComplete -= new SQLDMO.BackupSink_PercentCompleteEventHandler(Backup_PercentComplete);
        //        backup = null;
        //        return true;
        //    }
        //    catch (Exception err)
        //    {
        //        throw (new Exception("备份数据库失败" + err.Message));
        //    }
        //    finally
        //    {
        //        sqlServer.DisConnect();
        //    }
        //}

        ///// <summary>
        ///// 实时刷新进度条的方法
        ///// </summary>
        //private void Backup_PercentComplete(string message, int percent)
        //{
        //    char[] a = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        //    int startPos = message.IndexOfAny(a);
        //    int endPos = message.LastIndexOfAny(a);
        //    int value = DataTypeConvert.GetInt(message.Substring(startPos, endPos - startPos + 1));
        //    progressBarBackup.Value = value;
        //    Application.DoEvents();
        //}

        #endregion

        #endregion
        
        /// <summary>
        /// 设定相关控件状态
        /// </summary>
        private void checkEnableWorkFlowMessage_CheckedChanged(object sender, EventArgs e)
        {
            spinMessageInterval.Properties.ReadOnly = !checkEnableWorkFlowMessage.Checked;
        }

        /// <summary>
        /// 选择提示
        /// </summary>
        private void checkDisableProjectNo_CheckedChanged(object sender, EventArgs e)
        {
            if (!LoadSystemSet)
            {
                if (checkDisableProjectNo.Checked)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确认停用登记单中的项目号和站号吗？\r\n（包括请购单、采购单、入库单、出库单以及库存的所有登记单，停用之后会造成库存数量不准确，请谨慎操作。）", 2) == DialogResult.Yes)
                    {
                        checkDisableProjectNo.Checked = true;
                    }
                    else
                        checkDisableProjectNo.Checked = false;
                }
            }
        }

        /// <summary>
        /// 选择提示
        /// </summary>
        private void checkDisableShelfInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (!LoadSystemSet)
            {
                if (checkDisableShelfInfo.Checked)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确认停用仓库中的货架号吗？\r\n（包括入库单、出库单以及库存的所有登记单，停用之后会造成库存数量不准确，请谨慎操作。）", 2) == DialogResult.Yes)
                    {
                        checkDisableShelfInfo.Checked = true;
                    }
                    else
                        checkDisableShelfInfo.Checked = false;
                }
            }
        }

        /// <summary>
        /// 清空操作记录
        /// </summary>
        private void btnClearOperation_Click(object sender, EventArgs e)
        {
            try
            {
                int moduleCount = 0;
                string moduleStr = "";
                if (checkSale.Checked)
                {
                    moduleCount++;
                    moduleStr += "[销售]";
                }
                if (checkProject.Checked)
                {
                    moduleCount++;
                    moduleStr += "[项目]";
                }
                if (checkPurchase.Checked)
                {
                    moduleCount++;
                    moduleStr += "[采购]";
                }
                if (checkWarehouse.Checked)
                {
                    moduleCount++;
                    moduleStr += "[库存]";
                }
                if (checkProduction.Checked)
                {
                    moduleCount++;
                    moduleStr += "[生产]";
                }
                if (moduleCount == 0)
                {
                    MessageHandler.ShowMessageBox("请选择要操作的模块。");
                    return;
                }
                if (MessageHandler.ShowMessageBox_YesNo(string.Format("确认要清空模块 {0} 的操作记录吗？（请谨慎操作此步骤，清空后所有选中模块的登记单都将会进行删除）", moduleStr), 2) == DialogResult.Yes)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确认要清空吗？", 2) != DialogResult.Yes)
                        return;

                    if (systemDAO.ClearOperationRecord(checkSale.Checked, checkProject.Checked, checkPurchase.Checked, checkWarehouse.Checked, checkProduction.Checked))
                    {
                        MessageHandler.ShowMessageBox(string.Format("清空模块 {0} 的操作记录成功。", moduleStr));
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--清空操作记录错误。", ex);
            }
        }

        /// <summary>
        /// 清空基础资料
        /// </summary>
        private void btnClearBasicData_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageHandler.ShowMessageBox_YesNo("确认要清空基础资料吗？（请谨慎操作此步骤，清空后所有的基础资料都将会进行删除）", 2) == DialogResult.Yes)
                {
                    if (MessageHandler.ShowMessageBox_YesNo("确认要清空吗？", 2) != DialogResult.Yes)
                        return;

                    //if (systemDAO.ClearBasicData())
                    //{
                    //    MessageHandler.ShowMessageBox("清空基础资料成功。");
                    //}
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--清空基础资料错误。", ex);
            }
        }

    }
}
