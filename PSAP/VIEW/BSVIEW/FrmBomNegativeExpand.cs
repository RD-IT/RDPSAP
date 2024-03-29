﻿using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
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
    public partial class FrmBomNegativeExpand : DockContent
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();
        FrmBomManagementDAO bomDAO = new FrmBomManagementDAO();

        public FrmBomNegativeExpand()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(this);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmBomNegativeExpand_Load(object sender, EventArgs e)
        {
            try
            {
                //searchCodeFileName.Properties.DataSource = commonDAO.QueryPartsCode(false);

                ControlCommonInit ctlInit = new ControlCommonInit();
                ctlInit.SearchLookUpEdit_PartsCode(searchCodeFileName, false, "AutoId", "CodeFileName");
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiCtjzsj.Text, ex);
            }
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void gridViewBomMateriel_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 反向查询零件的Bom信息
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                //treeListBom.OptionsBehavior.EnableFiltering = true;
                //treeListBom.OptionsFilter.FilterMode = FilterMode.Smart;

                //treeListBom.DataSource = bomDAO.QueryBomTreeList_MoreInfo("");
                //treeListBom.ExpandAll();
                //treeListBom.FilterNodes();

                string codeFileNameStr = DataTypeConvert.GetString(searchCodeFileName.Text);
                treeListBom.DataSource = bomDAO.QueryBomTreeList_Negative_MoreInfo(codeFileNameStr);
                treeListBom.ExpandAll();
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--反向查询零件的Bom信息错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiFxcxlj.Text, ex);
            }
        }
        
        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void treeListBom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ControlHandler.TreeList_GetFocusedCellDisplayText_KeyDown(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--获取单元格显示的信息错误。", ex);
            }
        }

        /// <summary>
        /// 双击查看Bom信息
        /// </summary>
        private void treeListBom_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string formNameStr = "FrmBomManagement";
                if (!commonDAO.QueryUserFormPower(formNameStr))
                    return;

                string codeFileNameStr = DataTypeConvert.GetString(treeListBom.FocusedNode["CodeFileName"]);
                string parentCodeFileNameStr = DataTypeConvert.GetString(treeListBom.FocusedNode["ParentCodeFileName"]);
                FrmBomManagement.queryCodeFileNameStr = codeFileNameStr;
                FrmBomManagement.queryParentCodeFileNameStr = parentCodeFileNameStr;
                ViewHandler.ShowRightWindow(formNameStr);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--双击查看Bom信息错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiSjckbom.Text, ex);
            }
        }

        /// <summary>
        /// 设定树的过来条件
        /// </summary>
        private void treeListBom_FilterNode(object sender, DevExpress.XtraTreeList.FilterNodeEventArgs e)
        {
            //try
            //{
            //    string nodeCFNStr = DataTypeConvert.GetString(e.Node["CodeFileName"]);
            //    string codeFileNameStr = DataTypeConvert.GetString(searchCodeFileName.Text);

            //    bool IsVisible = nodeCFNStr.IndexOf(codeFileNameStr) >= 0;

            //    if (IsVisible)
            //    {
            //        TreeListNode Node = e.Node.ParentNode;
            //        while (Node != null)
            //        {
            //            if (!Node.Visible)
            //            {
            //                Node.Visible = true;
            //                Node = Node.ParentNode;
            //            }
            //            else
            //                break;
            //        }
            //    }

            //    e.Node.Visible = IsVisible;
            //    e.Handled = true;
            //}
            //catch (Exception ex)
            //{
            //    //ExceptionHandler.HandleException(this.Text + "--设定树的过来条件错误。", ex);
            //    ExceptionHandler.HandleException(this.Text + "--" + tsmiSdsdgltjcw.Text, ex);
            //}
        }

        /// <summary>
        /// 查询结果存为Excel
        /// </summary>
        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmMainDAO.QueryUserButtonPower(this.Name, this.Text, sender, true))
                    return;

                FileHandler.SaveTreeListControlExportToExcel(treeListBom);
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--查询结果存为Excel错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiCxjgcw.Text, ex);
            }
        }

        /// <summary>
        /// 根据选择显示零件名称
        /// </summary>
        private void searchCodeFileName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                textCodeName.Text = DataTypeConvert.GetString(searchCodeFileNameView.GetRowCellValue(searchCodeFileName.Properties.GetIndexByKeyValue(e.NewValue), "CodeName"));
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--根据选择显示零件名称错误。", ex);
            }
        }

    }
}
