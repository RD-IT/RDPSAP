using DevExpress.XtraTreeList.Nodes;
using PSAP.DAO.BSDAO;
using PSAP.DAO.INVDAO;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace PSAP.VIEW.BSVIEW
{
    public partial class FrmRight_Role : DockContent
    {
        FrmBaseEdit editForm = null;
        static PSAP.VIEW.BSVIEW.FrmLanguageText f = new VIEW.BSVIEW.FrmLanguageText();

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public FrmRight_Role()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(this);
            PSAP.BLL.BSBLL.BSBLL.language(f);

            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.TopLevel = false;
                    editForm.TableName = "BS_Role";
                    editForm.TableCaption = "角色权限管理";
                    editForm.Sql = "select * from BS_Role Order by AutoId";
                    editForm.PrimaryKeyColumn = "RoleNo";
                    editForm.MasterDataSet = dSRole;
                    editForm.MasterBindingSource = bSRole;
                    editForm.MasterEditPanel = pnlEdit;
                    editForm.PrimaryKeyControl = textRoleNo;
                    editForm.MasterEditPanelAddControl = new List<Control>() { treeListRole };
                    editForm.BrowseXtraGridView = gridViewRole;
                    editForm.RowStateUnchangedIsSave = true;
                    editForm.CheckControl += CheckControl;
                    editForm.QueryDataAfter += QueryDataAfter;
                    editForm.CancelAfter += QueryDataAfter;
                    editForm.SaveRowAfter += SaveRowAfter;
                    this.pnlToolBar.Controls.Add(editForm);
                    editForm.Dock = DockStyle.Fill;
                    editForm.Show();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体构造函数错误。", ex);
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmRight_Role_Load(object sender, EventArgs e)
        {
            try
            {
                QueryMenuTreeList();
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiCtjzsjcw.Text, ex);
            }
        }

        /// <summary>
        /// 保存之前的回调方法
        /// </summary>
        public bool CheckControl()
        {
            if (textRoleNo.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox(tsmiJsbhbnwk.Text);// ("角色编号不能为空，请重新操作。");
                textRoleNo.Focus();
                return false;
            }
            if (textRoleName.Text.Trim() == "")
            {
                MessageHandler.ShowMessageBox(tsmiJsmcbnwk.Text);// ("角色名称不能为空，请重新操作。");
                textRoleName.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 查询数据之后的回调方法
        /// </summary>
        public void QueryDataAfter()
        {
            SetRoleMenuTreeCheck();
        }

        /// <summary>
        /// 保存之后执行的回调方法
        /// </summary>
        public bool SaveRowAfter(DataRow dr, SqlCommand cmd)
        {
            FrmRightDAO.SaveRoleMenu_TreeList(cmd, DataTypeConvert.GetString(dr["RoleNo"]), treeListRole);

            return true;
        }

        /// <summary>
        /// 选中角色查看权限
        /// </summary>
        public void gridViewRole_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewRole.GetFocusedDataRow() != null)
                {
                    SetRoleMenuTreeCheck();
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--选中角色查看权限错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiXzjsckqxcw.Text, ex);
            }
        }

        /// <summary>
        /// 查询权限树的所有节点
        /// </summary>
        public void QueryMenuTreeList()
        {
            treeListRole.DataSource = FrmRightDAO.QueryMenuTree();
            treeListRole.CollapseAll();
        }

        /// <summary>
        /// 设定角色菜单树的选择状态
        /// </summary>
        private void SetRoleMenuTreeCheck()
        {
            treeListRole.UncheckAll();
            foreach (TreeListNode node in treeListRole.Nodes)
            {
                node.Checked = true;
            }
            if (gridViewRole.GetFocusedDataRow() != null)
            {
                DataTable roleMenuTable = FrmRightDAO.QueryRoleMenu(DataTypeConvert.GetString(gridViewRole.GetFocusedDataRow()["RoleNo"]));
                int cont = treeListRole.GetAllCheckedNodes().Count;

                foreach (TreeListNode node in treeListRole.GetNodeList())
                {
                    string menuNameStr = DataTypeConvert.GetString(node["MenuName"]);
                    DataRow[] drs = roleMenuTable.Select(string.Format("MenuName = '{0}'", menuNameStr));
                    if (drs.Length > 0)
                        node.Checked = true;
                }
            }
        }

        /// <summary>
        /// 根据选择节点状态更新树其他节点状态
        /// </summary>
        private void treeListRole_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            try
            {
                ControlHandler.SetCheckedChildNodes(e.Node, e.Node.CheckState);
                ControlHandler.SetCheckedParentNodes(e.Node, e.Node.CheckState);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--根据选择节点状态更新树其他节点状态错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + f.tsmiGjxzjdztgxsqtjd.Text, ex);
            }
        }

        private void treeListRole_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        /// <summary>
        /// 扩展树节点
        /// </summary>
        private void btnExpand_Click(object sender, EventArgs e)
        {
            treeListRole.ExpandAll();
        }

        /// <summary>
        /// 收缩树节点
        /// </summary>
        private void btnCollapse_Click(object sender, EventArgs e)
        {
            treeListRole.CollapseAll();
        }
    }
}
