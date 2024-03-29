﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DevExpress.Utils;
using DevExpress.XtraTreeList.Nodes;
using System.Data;

namespace PSAP.PSAPCommon
{
    public class ControlHandler
    {
        /// <summary>
        /// 设定DevExpress控件的Enabled状态
        /// </summary>
        public void Set_Control_Enabled(Control ctl, bool enabledState)
        {
            string ctlStr = ctl.GetType().ToString();
            switch (ctlStr)
            {
                case "DevExpress.XtraEditors.TextEdit":
                    ((TextEdit)ctl).Enabled = enabledState;
                    break;
                case "DevExpress.XtraEditors.MemoEdit":
                    ((MemoEdit)ctl).Enabled = enabledState;
                    break;
                case "DevExpress.XtraEditors.RadioGroup":
                    ((RadioGroup)ctl).Enabled = enabledState;
                    break;
                case "DevExpress.XtraEditors.CheckEdit":
                    ((CheckEdit)ctl).Enabled = enabledState;
                    break;
                case "DevExpress.XtraEditors.ButtonEdit":
                    ButtonEdit btnEd = ((ButtonEdit)ctl);
                    btnEd.Enabled = enabledState;
                    if (btnEd.Properties.Buttons.Count > 0)
                    {
                        for (int i = 0; i < btnEd.Properties.Buttons.Count; i++)
                        {
                            btnEd.Properties.Buttons[i].Enabled = enabledState;
                        }
                    }
                    break;
                case "DevExpress.XtraEditors.SpinEdit":
                    ((SpinEdit)ctl).Enabled = enabledState;
                    break;
                case "DevExpress.XtraEditors.TimeEdit":
                    ((TimeEdit)ctl).Enabled = enabledState;
                    break;
                case "DevExpress.XtraEditors.DateEdit":
                    ((DateEdit)ctl).Enabled = enabledState;
                    break;
                case "DevExpress.XtraEditors.ComboBoxEdit":
                    ((ComboBoxEdit)ctl).Enabled = enabledState;
                    break;
                case "DevExpress.XtraEditors.LookUpEdit":
                    ((LookUpEdit)ctl).Enabled = enabledState;
                    break;
                case "DevExpress.XtraEditors.SearchLookUpEdit":
                    ((SearchLookUpEdit)ctl).Enabled = enabledState;
                    break;
                case "DevExpress.XtraEditors.ListBoxControl":
                    ((ListBoxControl)ctl).Enabled = enabledState;
                    break;
                case "DevExpress.XtraTreeList.TreeList":
                    ((TreeList)ctl).Enabled = enabledState;
                    break;
            }
        }

        /// <summary>
        /// 设定DevExpress控件的ReadOnly状态
        /// </summary>
        public void Set_Control_ReadOnly(Control ctl, bool readOnlyState)
        {
            string ctlStr = ctl.GetType().ToString();
            switch (ctlStr)
            {
                case "DevExpress.XtraEditors.TextEdit":
                    ((TextEdit)ctl).ReadOnly = readOnlyState;
                    break;
                case "DevExpress.XtraEditors.MemoEdit":
                    ((MemoEdit)ctl).ReadOnly = readOnlyState;
                    break;
                case "DevExpress.XtraEditors.RadioGroup":
                    ((RadioGroup)ctl).ReadOnly = readOnlyState;
                    break;
                case "DevExpress.XtraEditors.CheckEdit":
                    ((CheckEdit)ctl).ReadOnly = readOnlyState;
                    break;
                case "DevExpress.XtraEditors.ButtonEdit":
                    ButtonEdit btnEd = ((ButtonEdit)ctl);
                    btnEd.ReadOnly = readOnlyState;
                    if (btnEd.Properties.Buttons.Count > 0)
                    {
                        for (int i = 0; i < btnEd.Properties.Buttons.Count; i++)
                        {
                            btnEd.Properties.Buttons[i].Enabled = !readOnlyState;
                        }
                    }
                    break;
                case "DevExpress.XtraEditors.SpinEdit":
                    ((SpinEdit)ctl).ReadOnly = readOnlyState;
                    break;
                case "DevExpress.XtraEditors.TimeEdit":
                    ((TimeEdit)ctl).ReadOnly = readOnlyState;
                    break;
                case "DevExpress.XtraEditors.DateEdit":
                    ((DateEdit)ctl).ReadOnly = readOnlyState;
                    break;
                case "DevExpress.XtraEditors.ComboBoxEdit":
                    ((ComboBoxEdit)ctl).ReadOnly = readOnlyState;
                    break;
                case "DevExpress.XtraEditors.LookUpEdit":
                    ((LookUpEdit)ctl).ReadOnly = readOnlyState;
                    break;
                case "DevExpress.XtraEditors.SearchLookUpEdit":
                    ((SearchLookUpEdit)ctl).ReadOnly = readOnlyState;
                    break;
                case "DevExpress.XtraEditors.ListBoxControl":
                    ((ListBoxControl)ctl).Enabled = !readOnlyState;
                    break;
                case "DevExpress.XtraTreeList.TreeList":
                    ((TreeList)ctl).Enabled = !readOnlyState;
                    break;
            }
        }

        /// <summary>
        /// 根据DevExpress的样式不同，改变控件的位置
        /// </summary>
        public static void DevExpressStyle_ChangeControlLocation(string devExpressStyleStr, List<Control> controlList)
        {
            switch (devExpressStyleStr)
            {
                case "DevExpress Style":
                case "Foggy":
                case "Metropolis":
                case "Metropolis Dark":
                case "Office 2010 Black":
                case "Office 2010 Blue":
                case "Office 2010 Silver":
                case "Office 2013":
                case "Office 2013 Dark Gray":
                case "Office 2013 Light Gray":
                case "Office 2016 Colorful":
                case "Office 2016 Dark":
                case "Seven":
                case "Seven Classic":
                case "Sharp":
                case "Sharp Plus":
                case "Visual Studio 2013 Blue":
                case "Visual Studio 2013 Dark":
                case "Visual Studio 2013 Light":
                case "VS2010":
                case "Whiteprint":

                    break;
                default:
                    foreach (Control ctl in controlList)
                    {
                        ctl.Location = new Point(ctl.Location.X + 1, ctl.Location.Y + 1);
                    }
                    break;
            }
        }

        /// <summary>
        /// GridView复制显示的信息到剪贴板中
        /// </summary>
        /// <param name="sender">GridView对象</param>
        /// <param name="e">KeyDown事件的参数</param>
        public static void GridView_GetFocusedCellDisplayText_KeyDown(object sender, KeyEventArgs e)
        {
            GridView gridView = (GridView)sender;
            if (e.Control & e.KeyCode == Keys.C)
            {
                string displayText = DataTypeConvert.GetString(gridView.GetFocusedRowCellDisplayText(gridView.FocusedColumn));
                Clipboard.SetDataObject(displayText);
                e.Handled = true;
            }
        }

        /// <summary>
        /// TreeList复制显示的信息到剪贴板中
        /// </summary>
        /// <param name="sender">TreeList对象</param>
        /// <param name="e">KeyDown事件的参数</param>
        public static void TreeList_GetFocusedCellDisplayText_KeyDown(object sender, KeyEventArgs e)
        {
            TreeList treeList = (TreeList)sender;
            if (e.Control & e.KeyCode == Keys.C)
            {
                string displayText = DataTypeConvert.GetString(treeList.FocusedNode[treeList.FocusedColumn]);
                Clipboard.SetDataObject(displayText);
                e.Handled = true;
            }
        }

        /// <summary>
        /// GridView设置显示的行号
        /// </summary>
        public static void GridView_CustomDrawRowIndicator(RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// TreeList设置显示根节点的行号
        /// </summary>
        public static void TreeList_CustomDrawNodeIndicator_RootNode(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            TreeList tmpTree = sender as TreeList;
            IndicatorObjectInfoArgs args = e.ObjectArgs as IndicatorObjectInfoArgs;
            if (args != null)
            {
                if (tmpTree.Nodes.Contains(e.Node))
                {
                    int rowNum = tmpTree.GetNodeIndex(e.Node) + 1;
                    //this.treeList.IndicatorWidth = rowNum.ToString().Length * 10 + 10;
                    args.DisplayText = rowNum.ToString();
                }
            }
        }

        /// <summary>
        /// TreeList设置显示所有节点的行号
        /// </summary>
        public static void TreeList_CustomDrawNodeIndicator_AllNode(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            TreeList tmpTree = sender as TreeList;
            IndicatorObjectInfoArgs args = e.ObjectArgs as IndicatorObjectInfoArgs;
            if (args != null)
            {
                int rowNum = tmpTree.GetVisibleIndexByNode(e.Node) + 1;
                //this.treeList.IndicatorWidth = rowNum.ToString().Length * 10 + 10;
                args.DisplayText = rowNum.ToString();
            }
        }

        /// <summary>
        /// 设置子节点的状态  选择某一节点时,该节点的子节点全部选择  取消某一节点时,该节点的子节点全部取消选择
        /// </summary>
        public static void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        /// <summary>
        /// 设置父节点的状态
        /// </summary>
        public static void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                //node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                node.ParentNode.CheckState = b ? CheckState.Checked : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        public static ToolTipController MyToolTipClt = null;
        public static ToolTipControllerShowEventArgs args = null;

        /// <summary>
        /// ToolTip消息提示
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="showTime">显示时长</param>
        /// <param name="isAutoHide">自动隐藏</param>
        public static void NewToolTip(string title, string content, int showTime, bool isAutoHide)
        {
            try
            {
                MyToolTipClt = new ToolTipController();
                args = MyToolTipClt.CreateShowArgs();
                title = string.IsNullOrEmpty(title) ? "温馨提示" : title;
                args.AutoHide = isAutoHide;
                MyToolTipClt.ShowBeak = true;
                MyToolTipClt.ShowShadow = true;
                MyToolTipClt.Rounded = true;
                MyToolTipClt.AutoPopDelay = (showTime == 0 ? 2000 : showTime);
                MyToolTipClt.Active = true;
                MyToolTipClt.HideHint();
                MyToolTipClt.ShowHint(content, title, Control.MousePosition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设定登记单按钮栏的状态--库存
        /// </summary>
        public static void SetButtonBar_EnabledState_Warehouse(DataRow[] selectRows, DataRow focusedRow, string columnNameStr, SimpleButton saveBtn, SimpleButton deleteBtn, SimpleButton approveBtn, SimpleButton cancelApproveBtn, SimpleButton previewBtn)
        {
            DataRow dr = null;
            if (selectRows.Length == 1)
            {
                dr = selectRows[0];
            }
            else if (selectRows.Length == 0)
            {
                dr = focusedRow;
            }
            if (dr != null)
            {
                int stateInt = DataTypeConvert.GetInt(dr[columnNameStr]);
                switch (stateInt)
                {
                    case 1://待审批
                        saveBtn.Enabled = true;
                        deleteBtn.Enabled = true;
                        approveBtn.Enabled = true;
                        cancelApproveBtn.Enabled = false;
                        previewBtn.Enabled = SystemInfo.ApproveAfterPrint ? false : true;
                        break;
                    case 2://已审批
                        saveBtn.Enabled = false;
                        deleteBtn.Enabled = false;
                        approveBtn.Enabled = false;
                        cancelApproveBtn.Enabled = true;
                        previewBtn.Enabled = true;
                        break;
                    case 3://已结账
                        saveBtn.Enabled = false;
                        deleteBtn.Enabled = false;
                        approveBtn.Enabled = false;
                        cancelApproveBtn.Enabled = false;
                        previewBtn.Enabled = true;
                        break;
                    case 4://审批中
                        saveBtn.Enabled = false;
                        deleteBtn.Enabled = false;
                        approveBtn.Enabled = true;
                        cancelApproveBtn.Enabled = true;
                        previewBtn.Enabled = SystemInfo.ApproveAfterPrint ? false : true;
                        break;
                }
            }
            else
            {
                saveBtn.Enabled = true;
                deleteBtn.Enabled = true;
                approveBtn.Enabled = true;
                cancelApproveBtn.Enabled = true;
                previewBtn.Enabled = true;
            }
        }

        /// <summary>
        /// 设定登记单按钮栏的状态--采购订单
        /// </summary>
        public static void SetButtonBar_EnabledState_Order(DataRow[] selectRows, DataRow focusedRow, string columnNameStr, SimpleButton saveBtn, SimpleButton deleteBtn, SimpleButton submitBtn, SimpleButton cancelSubmitBtn, SimpleButton approveBtn, SimpleButton cancelApproveBtn, SimpleButton closeBtn, SimpleButton cancelCloseBtn, SimpleButton previewBtn)
        {
            DataRow dr = null;
            if (selectRows.Length == 1)
            {
                dr = selectRows[0];
            }
            else if (selectRows.Length == 0)
            {
                dr = focusedRow;
            }
            if (dr != null)
            {
                int stateInt = DataTypeConvert.GetInt(dr[columnNameStr]);
                switch (stateInt)
                {
                    case 1://待提交
                        saveBtn.Enabled = true;
                        deleteBtn.Enabled = true;
                        submitBtn.Enabled = true;
                        cancelSubmitBtn.Enabled = false;
                        approveBtn.Enabled = false;
                        cancelApproveBtn.Enabled = false;
                        if (closeBtn != null)
                        {
                            closeBtn.Enabled = true;
                            cancelCloseBtn.Enabled = false;
                        }
                        previewBtn.Enabled = SystemInfo.ApproveAfterPrint ? false : true;
                        break;
                    case 2://已审批
                        saveBtn.Enabled = false;
                        deleteBtn.Enabled = false;
                        submitBtn.Enabled = false;
                        cancelSubmitBtn.Enabled = false;
                        approveBtn.Enabled = false;
                        cancelApproveBtn.Enabled = true;
                        if (closeBtn != null)
                        {
                            closeBtn.Enabled = false;
                            cancelCloseBtn.Enabled = false;
                        }
                        previewBtn.Enabled = true;
                        break;
                    case 3://已关闭
                        saveBtn.Enabled = false;
                        deleteBtn.Enabled = false;
                        submitBtn.Enabled = false;
                        cancelSubmitBtn.Enabled = false;
                        approveBtn.Enabled = false;
                        cancelApproveBtn.Enabled = false;
                        if (closeBtn != null)
                        {
                            closeBtn.Enabled = false;
                            cancelCloseBtn.Enabled = true;
                        }
                        previewBtn.Enabled = false;
                        break;
                    case 4://审批中
                        saveBtn.Enabled = false;
                        deleteBtn.Enabled = false;
                        submitBtn.Enabled = false;
                        cancelSubmitBtn.Enabled = true;
                        approveBtn.Enabled = true;
                        cancelApproveBtn.Enabled = false;
                        if (closeBtn != null)
                        {
                            closeBtn.Enabled = false;
                            cancelCloseBtn.Enabled = false;
                        }
                        previewBtn.Enabled = SystemInfo.ApproveAfterPrint ? false : true;
                        break;
                }
            }
            else
            {
                saveBtn.Enabled = true;
                deleteBtn.Enabled = true;
                submitBtn.Enabled = true;
                cancelSubmitBtn.Enabled = true;
                approveBtn.Enabled = true;
                cancelApproveBtn.Enabled = true;
                if (closeBtn != null)
                {
                    closeBtn.Enabled = true;
                    cancelCloseBtn.Enabled = true;
                }
                previewBtn.Enabled = true;
            }
        }
    }
}
