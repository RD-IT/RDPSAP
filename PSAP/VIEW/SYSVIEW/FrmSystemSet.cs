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
                systemDAO.QuerySystemParameter(dataSet_SystemParameter.Tables[0]);

                SetSysParameterDefaultValue();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
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

            tmpStr = GetValue("Common", "DateIntervalDays");
            if (tmpStr != "")
                spinDateIntervalDays.Value = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue("Common", "FormDragDropMaxRecordCount");
            if (tmpStr != "")
                spinFormDragDropMaxRecordCount.Value = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue("Common", "LeftDockWidth");
            if (tmpStr != "")
                spinLeftDockWidth.Value = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue("Common", "EnableWorkFlowMessage");
            if (tmpStr != "")
                checkEnableWorkFlowMessage.EditValue = tmpStr;

            tmpStr = GetValue("Common", "MessageInterval");
            if (tmpStr != "")
                spinMessageInterval.Value = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue("Common", "ApproveAfterPrint");
            if (tmpStr != "")
                checkApproveAfterPrint.EditValue = tmpStr;

            #endregion

            #region 销售

            tmpStr = GetValue("Sale", "QuotationDefaultTax");
            if (tmpStr != "")
                spinQuotationDefaultTax.Value = DataTypeConvert.GetDecimal(tmpStr);

            tmpStr = GetValue("Sale", "SalesOrderDefaultTax");
            if (tmpStr != "")
                spinSalesOrderDefaultTax.Value = DataTypeConvert.GetDecimal(tmpStr);

            #endregion

            #region 采购

            tmpStr = GetValue("Purchase", "PrReqIsAlterPSBomAutoId");
            if (tmpStr != "")
                checkPrReqIsAlterPSBomAutoId.EditValue = tmpStr;

            tmpStr = GetValue("Purchase", "OrderListDefaultTax");
            if (tmpStr != "")
                spinOrderListDefaultTax.Value = DataTypeConvert.GetDecimal(tmpStr);

            tmpStr = GetValue("Purchase", "SettlementDefaultTax");
            if (tmpStr != "")
                spinSettlementDefaultTax.Value = DataTypeConvert.GetDecimal(tmpStr);

            tmpStr = GetValue("Purchase", "OrderNoWarehousingDays");
            if (tmpStr != "")
                spinOrderNoWarehousingDays.Value = DataTypeConvert.GetInt(tmpStr);

            tmpStr = GetValue("Purchase", "PrReqApplyBeyondCountIsSave");
            if (tmpStr != "")
                checkPrReqApplyBeyondCountIsSave.EditValue = tmpStr;

            tmpStr = GetValue("Purchase", "WWApplyBeyondCountIsSave");
            if (tmpStr != "")
                checkWWApplyBeyondCountIsSave.EditValue = tmpStr;

            #endregion

            #region 库存

            tmpStr = GetValue("Warehouse", "OrderApplyBeyondCountIsSave");
            if (tmpStr != "")
                checkOrderApplyBeyondCountIsSave.EditValue = tmpStr;

            tmpStr = GetValue("Warehouse", "WWIsAlterDate");
            if (tmpStr != "")
                checkWWIsAlterDate.EditValue = tmpStr;

            tmpStr = GetValue("Warehouse", "WRIsAlterDate");
            if (tmpStr != "")
                checkWRIsAlterDate.EditValue = tmpStr;

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

                //常规
                SetValue("Common", "PageRowCount", DataTypeConvert.GetString(spinPageRowCount.Value));
                SetValue("Common", "DateIntervalDays", DataTypeConvert.GetString(spinDateIntervalDays.Value));
                SetValue("Common", "FormDragDropMaxRecordCount", DataTypeConvert.GetString(spinFormDragDropMaxRecordCount.Value));
                SetValue("Common", "LeftDockWidth", DataTypeConvert.GetString(spinLeftDockWidth.Value));
                SetValue("Common", "EnableWorkFlowMessage", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkEnableWorkFlowMessage.EditValue)));
                SetValue("Common", "MessageInterval", DataTypeConvert.GetString(spinMessageInterval.Value));
                SetValue("Common", "ApproveAfterPrint", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkApproveAfterPrint.EditValue)));

                //销售
                SetValue("Sale", "QuotationDefaultTax", DataTypeConvert.GetString(spinQuotationDefaultTax.Value));
                SetValue("Sale", "SalesOrderDefaultTax", DataTypeConvert.GetString(spinSalesOrderDefaultTax.Value));

                //采购
                SetValue("Purchase", "PrReqIsAlterPSBomAutoId", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkPrReqIsAlterPSBomAutoId.EditValue)));
                SetValue("Purchase", "OrderListDefaultTax", DataTypeConvert.GetString(spinOrderListDefaultTax.Value));
                SetValue("Purchase", "SettlementDefaultTax", DataTypeConvert.GetString(spinSettlementDefaultTax.Value));
                SetValue("Purchase", "OrderNoWarehousingDays", DataTypeConvert.GetString(spinOrderNoWarehousingDays.Value));
                SetValue("Purchase", "PrReqApplyBeyondCountIsSave", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkPrReqApplyBeyondCountIsSave.EditValue)));
                SetValue("Purchase", "WWApplyBeyondCountIsSave", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkWWApplyBeyondCountIsSave.EditValue)));

                //库存
                SetValue("Warehouse", "OrderApplyBeyondCountIsSave", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkOrderApplyBeyondCountIsSave.EditValue)));
                SetValue("Warehouse", "WWIsAlterDate", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkWWIsAlterDate.EditValue)));
                SetValue("Warehouse", "WRIsAlterDate", DataTypeConvert.GetString(DataTypeConvert.GetInt(checkWRIsAlterDate.EditValue)));

                //系统
                SetValue("System", "BackupPath", textBackupPath.Text);

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
    }
}
