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
    public partial class FrmSelectUserList : DockContent
    {
        /// <summary>
        /// 默认选择的用户列表
        /// </summary>
        public static List<int> SelectUserAutoIdList = new List<int>();

        /// <summary>
        /// 确定选择的用户列表
        /// </summary>
        public List<int> OkSelectUserAutoIdList = new List<int>();

        public FrmSelectUserList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 移动单行记录
        /// </summary>
        private void MoveSingleRow(DataTable sourceTable, DataTable targetTable, DataRow opRow)
        {
            targetTable.ImportRow(opRow);

            sourceTable.Rows.Remove(opRow);
        }

        /// <summary>
        /// 移动全部记录
        /// </summary>
        private void MoveAllRow(DataTable sourceTable, DataTable targetTable)
        {
            for (int i = 0; i < sourceTable.Rows.Count; i++)
            {
                targetTable.ImportRow(sourceTable.Rows[i]);
            }

            sourceTable.Rows.Clear();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmSelectUserList_Load(object sender, EventArgs e)
        {
            try
            {
                new FrmProjectListDAO().QueryUserInfo(TableLeft);

                for (int i = 0; i < SelectUserAutoIdList.Count; i++)
                {
                    DataRow[] drs = TableLeft.Select(string.Format("AutoId = {0}", SelectUserAutoIdList[i]));
                    if (drs.Length > 0)
                    {
                        MoveSingleRow(TableLeft, TableRight, drs[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
            }
        }

        /// <summary>
        /// 选择单条信息
        /// </summary>
        private void btnRightOne_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rows = gridViewLeft.GetSelectedRows();
                List<DataRow> rowList = new List<DataRow>();
                if (rows.Length == 0)
                {
                    rowList.Add(gridViewLeft.GetFocusedDataRow());
                }
                else
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        rowList.Add(gridViewLeft.GetDataRow(rows[i]));
                    }
                }

                foreach (DataRow row in rowList)
                {
                    MoveSingleRow(TableLeft, TableRight, row);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择单条信息错误。", ex);
            }
        }

        /// <summary>
        /// 选择全部信息
        /// </summary>
        private void btnRightAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableLeft.Rows.Count > 0)
                    MoveAllRow(TableLeft, TableRight);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--选择全部信息错误。", ex);
            }
        }

        /// <summary>
        /// 清除单条信息
        /// </summary>
        private void btnLeftOne_Click(object sender, EventArgs e)
        {
            try
            {
                //if (gridViewRight.GetFocusedDataRow() != null)
                //    MoveSingleRow(TableRight, TableLeft, gridViewRight.GetFocusedDataRow());

                int[] rows = gridViewRight.GetSelectedRows();
                List<DataRow> rowList = new List<DataRow>();
                if (rows.Length == 0)
                {
                    rowList.Add(gridViewRight.GetFocusedDataRow());
                }
                else
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        rowList.Add(gridViewRight.GetDataRow(rows[i]));
                    }
                }

                foreach (DataRow row in rowList)
                {
                    MoveSingleRow(TableRight, TableLeft, row);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--清除单条信息错误。", ex);
            }
        }

        /// <summary>
        /// 清除全部信息
        /// </summary>
        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableRight.Rows.Count > 0)
                    MoveAllRow(TableRight, TableLeft);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--清除全部信息错误。", ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewLeft_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 确定选择的用户
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                OkSelectUserAutoIdList.Clear();
                for (int i = 0; i < gridViewRight.DataRowCount; i++)
                {
                    OkSelectUserAutoIdList.Add(DataTypeConvert.GetInt(gridViewRight.GetDataRow(i)["AutoId"]));
                }              

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--确定选择的用户错误。", ex);
            }
        }
    }
}
