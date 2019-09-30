﻿using PSAP.DAO.BSDAO;
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
    public partial class FrmPartsCode : DockContent
    {
        FrmBaseEdit editForm = null;
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        public static string codeFileNameStr = "";

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public FrmPartsCode()
        {
            InitializeComponent();
            PSAP.BLL.BSBLL.BSBLL.language(this);

            try
            {
                if (editForm == null)
                {
                    editForm = new FrmBaseEdit();
                    editForm.FormBorderStyle = FormBorderStyle.None;
                    editForm.TopLevel = false;
                    editForm.TableName = "SW_PartsCode";
                    editForm.TableCaption = "物料信息";
                    //editForm.Sql = "select * from SW_PartsCode order by AutoId";

                    if (codeFileNameStr == "")
                        editForm.Sql = "select * from SW_PartsCode order by AutoId";
                    else
                        editForm.Sql = string.Format("select * from SW_PartsCode where CodeFileName = '{0}' order by AutoId", codeFileNameStr);
                    editForm.PrimaryKeyColumn = "AutoId";
                    editForm.MasterDataSet = dSPartsCode;
                    editForm.MasterBindingSource = bSPartsCode;
                    editForm.MasterEditPanel = pnlEdit;
                    editForm.PrimaryKeyControl = textCodeFileName;
                    editForm.BrowseXtraGridView = gridViewPartsCode;
                    editForm.CheckControl += CheckControl;
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
        private void FrmPartsCode_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable materialTable_f = commonDAO.QueryMaterialSelectLib(false);
                DataTable catgNameTable_f = commonDAO.QueryPartNoCatg(false);
                DataTable finishTable_f = commonDAO.QueryFinishCatg(false);
                DataTable machTable_f = commonDAO.QueryLevelCatg(false);

                searchLookUpMaterial.Properties.DataSource = materialTable_f;
                lookUpCatgName.Properties.DataSource = catgNameTable_f;
                lookUpBrand.Properties.DataSource = commonDAO.QueryBrandCatg(false);
                lookUpFinish.Properties.DataSource = finishTable_f;
                lookUpMachiningLevel.Properties.DataSource = machTable_f;
                lookUpUnit.Properties.DataSource = commonDAO.QueryUnitCatg(false);

                repLookUpMaterial.DataSource = materialTable_f;
                repLookUpCatgName.DataSource = catgNameTable_f;
                repLookUpFinish.DataSource = finishTable_f;
                repLookUpMachiningLevel.DataSource = machTable_f;
            }
            catch (Exception ex)
            {
                //ExceptionHandler.HandleException(this.Text + "--窗体加载事件错误。", ex);
                ExceptionHandler.HandleException(this.Text + "--" + tsmiCtjzsj.Text, ex);
            }
        }

        /// <summary>
        /// 窗体激活事件
        /// </summary>
        private void FrmPartsCode_Activated(object sender, EventArgs e)
        {
            try
            {
                if (codeFileNameStr != "")
                {
                    editForm.Sql = string.Format("select * from SW_PartsCode where CodeFileName = '{0}' order by AutoId", codeFileNameStr);
                    editForm.btnRefresh_Click(null, null);

                    codeFileNameStr = "";
                    editForm.Sql = "select * from SW_PartsCode order by AutoId";
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(this.Text + "--窗体激活事件错误。", ex);
            }
        }

        /// <summary>
        /// 保存之前的回调方法
        /// </summary>
        public bool CheckControl()
        {
            if (textCodeFileName.Text.Trim() == "")
            {
                //MessageHandler.ShowMessageBox("零件编号不能为空，请重新操作。");
                MessageHandler.ShowMessageBox(tsmiLjbh.Text);
                textCodeFileName.Focus();
                return false;
            }
            if (textCodeNo.Text.Trim() == "")
            {
                //MessageHandler.ShowMessageBox("物料编号不能为空，请重新操作。");
                MessageHandler.ShowMessageBox(tsmiWlbh.Text);
                textCodeNo.Focus();
                return false;
            }
            if (textCodeName.Text.Trim() == "")
            {
                //MessageHandler.ShowMessageBox("零件名称不能为空，请重新操作。");
                MessageHandler.ShowMessageBox(tsmiLjmc.Text);

                textCodeName.Focus();
                return false;
            }
            if (lookUpCatgName.ItemIndex < 0)
            {
                //MessageHandler.ShowMessageBox("零件分类不能为空，请重新操作。");
                MessageHandler.ShowMessageBox(tsmiLjfl.Text);
                lookUpCatgName.Focus();
                return false;
            }
            if (textFilePath.Text.Trim() == "")
            {
                //MessageHandler.ShowMessageBox("文件路径不能为空，请重新操作。");
                MessageHandler.ShowMessageBox(tsmiWjlj.Text);
                textFilePath.Focus();
                return false;
            }
            if (textCodeSpec.Text.Trim() == "")
            {
                //MessageHandler.ShowMessageBox("规格型号不能为空，请重新操作。");
                MessageHandler.ShowMessageBox(tsmiGgxh.Text);

                textCodeSpec.Focus();
                return false;
            }
            if (textMaterialVersion.Text.Trim() == "")
            {
                //MessageHandler.ShowMessageBox("物料版本不能为空，请重新操作。");
                MessageHandler.ShowMessageBox(tsmiWlbb.Text);
                textMaterialVersion.Focus();
                return false;
            }
            if (lookUpUnit.ItemIndex < 0)
            {
                //MessageHandler.ShowMessageBox("单位不能为空，请重新操作。");
                MessageHandler.ShowMessageBox(tsmiDw.Text);
                lookUpUnit.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 设定默认值
        /// </summary>
        private void TablePartsCode_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["FilePath"] = "D:\\RongDaPDM\\零部件库\\";
            e.Row["CatgName"] = "A";
            e.Row["CodeWeight"] = 0;
            e.Row["MaterialVersion"] = "0";
            //e.Row["Material"]=
            e.Row["Brand"] = "RD";
            e.Row["Finish"] = 2;
            e.Row["MachiningLevel"] = 1;
            e.Row["Unit"] = "PC";
            e.Row["IsPreferred"] = false;
            e.Row["IsLongPeriod"] = false;
            e.Row["IsPrecious"] = false;
            e.Row["IsPreprocessing"] = false;
            e.Row["IsBuy"] = 1;
            e.Row["GetTime"] = BaseSQL.GetServerDateTime();

        }

        /// <summary>
        /// 设定物料编号和型号规格的默认值
        /// </summary>
        private void textCodeFileName_EditValueChanged(object sender, EventArgs e)
        {
            if (textCodeNo.Text == "")
                textCodeNo.Text = textCodeFileName.Text;
            if (textCodeSpec.Text == "")
                textCodeSpec.Text = textCodeFileName.Text;
        }

        /// <summary>
        /// 确定行号
        /// </summary>
        private void searchLookUpMaterialView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        /// <summary>
        /// 获取单元格显示的信息
        /// </summary>
        private void gridViewPartsCode_KeyDown(object sender, KeyEventArgs e)
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

    }
}
