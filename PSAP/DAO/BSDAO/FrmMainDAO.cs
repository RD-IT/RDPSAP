using DevExpress.XtraEditors;
using PSAP.PSAPCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PSAP.DAO.BSDAO
{
    class FrmMainDAO
    {
        /// <summary>
        /// 获取菜单数据
        /// </summary>
        public static DataTable GetMenuData()
        {
            string sql = "select MenuName, MenuText, FormName, ParentMenuName from BS_Menu where Visible = 1 order by MenuOrder";
            return BaseSQL.GetTableBySql(sql);
        }

        /// <summary>
        /// 获取一级菜单数据
        /// </summary>
        public static DataTable GetTopMenuData()
        {
            string sql = "select MenuName, MenuText from BS_Menu where ParentMenuName is null order by MenuOrder"; //一级菜单，其父菜单id为null
            DataTable dt = BaseSQL.GetTableBySql(sql);
            return dt;
        }

        /// <summary>
        /// 获取子菜单数据
        /// </summary>
        public static DataTable GetChildMenuData(string mname)
        {
            string sql = string.Format("select MenuName, MenuText, FormName from BS_Menu where ParentMenuName = '{0}' and Visible = 1 order by MenuOrder", mname);
            DataTable dt = BaseSQL.GetTableBySql(sql);
            return dt;
        }


        /// <summary>
        /// 获取子菜单权限数据（角色）
        /// </summary>
        /// <returns></returns>
        public static DataTable GetChildMenuRoleRightData(string mname, string strRoleNo)
        {
            string sql = string.Format("select * from BS_Menu where ParentMenuName ='{0}' and MenuName in (select MenuName from BS_RoleMenu where convert(varchar(20),RoleNo)='{1}')", mname, strRoleNo.Trim());
            DataTable dt = BaseSQL.GetTableBySql(sql);
            return dt;
        }

        public DataTable QueryRoleMenu(string roleNoStr)
        {
            string sqlStr = string.Format("Select MenuName from BS_RoleMenu where RoleNo='{0}'", roleNoStr);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 获取子菜单权限数据（个人）
        /// </summary>
        /// <returns></returns>
        public static DataTable GetChildMenuPersonalRightData(string mname, string strPersonalNo)
        {
            //根据父菜单项加载子菜单
            string sql = string.Format("select * from BS_Menu where ParentMenuName ='{0}' and MenuName in (select b.MenuName from BS_UserMenuButton a inner join BS_MenuButton b on a.MenuButtonId=b.AutoId where b.buttonName like 'menuItemFlag' and convert(varchar(20),a.UserNo)='{1}')", mname, strPersonalNo.Trim());
            DataTable dt = BaseSQL.GetTableBySql(sql);
            return dt;
        }

        public DataTable QueryPersonalMenu(string personalNoStr)
        {
            string sqlStr = string.Format("select b.MenuName from BS_UserMenuButton a inner join BS_MenuButton b on a.MenuButtonId=b.AutoId where b.buttonName like 'menuItemFlag' and a.UserNo = '{0}'", personalNoStr);
            return BaseSQL.GetTableBySql(sqlStr);
        }

        /// <summary>
        /// 查询用户按钮的权限
        /// </summary>
        public static bool QueryUserButtonPower(string formNameStr, string formTextStr, object sender, bool isMessage)
        { 
            if (sender == null || !SystemInfo.IsCheckUserButtonPower)
            {
                return true;
            }

            string buttonNameStr = "";
            string buttonTextStr = "";

            switch (sender.GetType().ToString())
            {
                case "DevExpress.XtraEditors.SimpleButton":
                    SimpleButton sbtn = (SimpleButton)sender;
                    buttonNameStr = sbtn.Name;
                    buttonTextStr = sbtn.Text;
                    break;
                case "System.Windows.Forms.Button":
                    Button btn = (Button)sender;
                    buttonNameStr = btn.Name;
                    buttonTextStr = btn.Text;
                    break;
                default:
                    return true;
            }

            string sqlStr = string.Format("select Count(*) from BS_MenuButton where MenuName in (select MenuName from BS_Menu where FormName = '{0}') and ButtonName = '{1}' and AutoId in (select MenuButtonId from BS_UserMenuButton where UserNo = {2})", formNameStr, buttonNameStr, SystemInfo.user.AutoId);
            int count = DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr));
            if (count > 0)
            {
                return true;
            }
            else
            {
                sqlStr = string.Format("select Count(*) from BS_Menu where FormName = '{0}'", formNameStr);
                if (DataTypeConvert.GetInt(BaseSQL.GetSingle(sqlStr)) == 0)
                    return true;
                else
                {
                    if(isMessage)
                        MessageHandler.ShowMessageBox(string.Format("您没有操作模块【{0}】中按钮【{1}】的操作权限，请联系相关的负责管理员。", formTextStr, buttonTextStr));
                    return false;
                }
            }
        }

        /// <summary>
        /// 刷新用户的按钮权限
        /// </summary>
        public void RefreshUserButtonPower()
        {
            if (SystemInfo.user.LoginID == "ADMIN")
            {
                SystemInfo.IsCheckUserButtonPower = false;
            }
            else
            {
                SystemInfo.IsCheckUserButtonPower = SystemInfo.user.ButtonPower == 1;
            }
        }
        
    }
}
