using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using PSAP.DAO.BSDAO;
using System;
using System.Data;

namespace PSAP.PSAPCommon
{
    class ControlCommonInit
    {
        FrmCommonDAO commonDAO = new FrmCommonDAO();

        /// <summary>
        /// 确定行号
        /// </summary>
        private void searchLookUpView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ControlHandler.GridView_CustomDrawRowIndicator(e);
        }

        #region 用户信息控件

        /// <summary>
        /// 用户信息表
        /// </summary>
        private DataTable userInfoTable_True = null;

        /// <summary>
        /// SearchLookUpEdit用户信息控件初始化
        /// </summary>
        public void SearchLookUpEdit_UserInfo_ValueMember_AutoId(SearchLookUpEdit searchLookUp)
        {
            SearchLookUpEdit_UserInfo(searchLookUp, "AutoId", true);
        }

        public void SearchLookUpEdit_UserInfo_ValueMember_AutoId_NoAll(SearchLookUpEdit searchLookUp)
        {
            SearchLookUpEdit_UserInfo(searchLookUp, "AutoId", false);
        }

        public void SearchLookUpEdit_UserInfo(SearchLookUpEdit searchLookUp, string valueMemberStr, bool addAllItem)
        {
            if (DataTypeConvert.GetString(searchLookUp.Properties.View.Tag) == "Init")
                return;

            GridColumn grdColAutoId = new GridColumn();
            grdColAutoId.Caption = "AutoId";
            grdColAutoId.FieldName = "AutoId";
            grdColAutoId.Name = "grdColAutoId";

            GridColumn grdColLoginId = new GridColumn();
            grdColLoginId.Caption = "用户名";
            grdColLoginId.FieldName = "LoginId";
            grdColLoginId.Name = "grdColLoginId";
            grdColLoginId.AppearanceHeader.Options.UseTextOptions = true;
            grdColLoginId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColLoginId.Visible = true;
            grdColLoginId.VisibleIndex = 0;

            GridColumn grdColEmpName = new GridColumn();
            grdColEmpName.Caption = "员工名";
            grdColEmpName.FieldName = "EmpName";
            grdColEmpName.Name = "grdColEmpName";
            grdColEmpName.AppearanceHeader.Options.UseTextOptions = true;
            grdColEmpName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColEmpName.Visible = true;
            grdColEmpName.VisibleIndex = 1;

            GridColumn grdColDepartmentName = new GridColumn();
            grdColDepartmentName.Caption = "部门";
            grdColDepartmentName.FieldName = "DepartmentName";
            grdColDepartmentName.Name = "grdColDepartmentName";
            grdColDepartmentName.AppearanceHeader.Options.UseTextOptions = true;
            grdColDepartmentName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColDepartmentName.Visible = true;
            grdColDepartmentName.VisibleIndex = 2;

            searchLookUp.Properties.View.Columns.AddRange(new GridColumn[] { grdColAutoId, grdColLoginId, grdColEmpName, grdColDepartmentName });

            searchLookUp.Properties.NullText = "";
            searchLookUp.EnterMoveNextControl = true;
            searchLookUp.Properties.DisplayMember = "EmpName";
            searchLookUp.Properties.ValueMember = valueMemberStr;

            if (userInfoTable_True == null)
                userInfoTable_True = commonDAO.QueryUserInfo(addAllItem);

            searchLookUp.Properties.DataSource = userInfoTable_True;

            searchLookUp.Properties.View.IndicatorWidth = 60;
            searchLookUp.Properties.View.CustomDrawRowIndicator += searchLookUpView_CustomDrawRowIndicator;

            searchLookUp.Properties.View.Tag = "Init";
        }

        #endregion

        #region 往来方信息控件   还没有统一

        /// <summary>
        /// 往来方信息表
        /// </summary>
        private DataTable bussInfoTable_True = null;

        /// <summary>
        /// SearchLookUpEdit往来方信息控件初始化   怕以后各个模块的往来方名称不一样，暂时未启用
        /// </summary>
        public void SearchLookUpEdit_BussinessBaseInfo(SearchLookUpEdit searchLookUp, bool addAllItem)
        {
            if (DataTypeConvert.GetString(searchLookUp.Properties.View.Tag) == "Init")
                return;

            GridColumn grdColAutoId = new GridColumn();
            grdColAutoId.Caption = "AutoId";
            grdColAutoId.FieldName = "AutoId";
            grdColAutoId.Name = "grdColAutoId";

            GridColumn grdColLoginId = new GridColumn();
            grdColLoginId.Caption = "往来方编号";
            grdColLoginId.FieldName = "BussinessBaseNo";
            grdColLoginId.Name = "grdColBussinessBaseNo";
            grdColLoginId.Visible = true;
            grdColLoginId.VisibleIndex = 0;

            GridColumn grdColEmpName = new GridColumn();
            grdColEmpName.Caption = "往来方名称";
            grdColEmpName.FieldName = "BussinessBaseText";
            grdColEmpName.Name = "grdColBussinessBaseText";
            grdColEmpName.Visible = true;
            grdColEmpName.VisibleIndex = 1;

            GridColumn grdColBussinessCategoryText = new GridColumn();
            grdColEmpName.Caption = "往来方类别";
            grdColEmpName.FieldName = "BussinessCategoryText";
            grdColEmpName.Name = "grdColBussinessCategoryText";
            grdColEmpName.Visible = true;
            grdColEmpName.VisibleIndex = 2;

            searchLookUp.Properties.View.Columns.AddRange(new GridColumn[] { grdColAutoId, grdColLoginId, grdColBussinessCategoryText });

            searchLookUp.Properties.NullText = "";
            searchLookUp.EnterMoveNextControl = true;
            searchLookUp.Properties.DisplayMember = "BussinessBaseText";
            searchLookUp.Properties.ValueMember = "BussinessBaseNo";

            if (bussInfoTable_True == null)
                bussInfoTable_True = commonDAO.QueryBussinessBaseInfo(addAllItem);
            searchLookUp.Properties.DataSource = bussInfoTable_True;

            searchLookUp.Properties.View.IndicatorWidth = 60;
            searchLookUp.Properties.View.CustomDrawRowIndicator += searchLookUpView_CustomDrawRowIndicator;

            searchLookUp.Properties.View.Tag = "Init";
        }

        #endregion

        #region 零件信息控件

        /// <summary>
        /// 零件信息表
        /// </summary>
        private DataTable partsCodeTable_True = null;//包含全部选项
        private DataTable partsCodeTable_false = null;//不包含全部选项

        /// <summary>
        /// SearchLookUpEdit零件信息控件初始化
        /// </summary>
        public void SearchLookUpEdit_PartsCode(SearchLookUpEdit searchLookUp, bool addAllItem, string valueMemberStr = "AutoId", string displayMemberStr = "CodeName")
        {
            if (DataTypeConvert.GetString(searchLookUp.Properties.View.Tag) == "Init")
                return;

            GridColumn grdColAutoId = new GridColumn();
            grdColAutoId.Caption = "AutoId";
            grdColAutoId.FieldName = "AutoId";
            grdColAutoId.Name = "grdColAutoId";

            GridColumn grdColCodeFileName = new GridColumn();
            grdColCodeFileName.Caption = "零件编号";
            grdColCodeFileName.FieldName = "CodeFileName";
            grdColCodeFileName.Name = "grdColCodeFileName";
            grdColCodeFileName.AppearanceHeader.Options.UseTextOptions = true;
            grdColCodeFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColCodeFileName.Visible = true;
            grdColCodeFileName.VisibleIndex = 0;

            GridColumn grdColCodeName = new GridColumn();
            grdColCodeName.Caption = "零件名称";
            grdColCodeName.FieldName = "CodeName";
            grdColCodeName.Name = "grdColCodeName";
            grdColCodeName.AppearanceHeader.Options.UseTextOptions = true;
            grdColCodeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColCodeName.Visible = true;
            grdColCodeName.VisibleIndex = 1;

            searchLookUp.Properties.View.Columns.AddRange(new GridColumn[] { grdColAutoId, grdColCodeFileName, grdColCodeName });

            searchLookUp.Properties.NullText = "";
            searchLookUp.EnterMoveNextControl = true;
            searchLookUp.Properties.ValueMember = valueMemberStr;
            searchLookUp.Properties.DisplayMember = displayMemberStr;

            if (addAllItem)
            {
                if (partsCodeTable_True == null)
                    partsCodeTable_True = commonDAO.QueryPartsCode(true);
                searchLookUp.Properties.DataSource = partsCodeTable_True;
            }
            else
            {
                if (partsCodeTable_false == null)
                    partsCodeTable_false = commonDAO.QueryPartsCode(false);
                searchLookUp.Properties.DataSource = partsCodeTable_false;
            }

            searchLookUp.Properties.View.IndicatorWidth = 60;
            searchLookUp.Properties.View.CustomDrawRowIndicator += searchLookUpView_CustomDrawRowIndicator;

            searchLookUp.Properties.View.Tag = "Init";
        }

        /// <summary>
        /// SearchLookUpEdit零件信息控件初始化
        /// </summary>
        public void RepositoryItemSearchLookUpEdit_PartsCode(RepositoryItemSearchLookUpEdit repSearchLookUp, string valueMemberStr = "AutoId", string displayMemberStr = "CodeName")
        {
            if (DataTypeConvert.GetString(repSearchLookUp.View.Tag) == "Init")
                return;

            GridColumn grdColAutoId = new GridColumn();
            grdColAutoId.Caption = "AutoId";
            grdColAutoId.FieldName = "AutoId";
            grdColAutoId.Name = "grdColAutoId";

            GridColumn grdColCodeFileName = new GridColumn();
            grdColCodeFileName.Caption = "零件编号";
            grdColCodeFileName.FieldName = "CodeFileName";
            grdColCodeFileName.Name = "grdColCodeFileName";
            grdColCodeFileName.AppearanceHeader.Options.UseTextOptions = true;
            grdColCodeFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColCodeFileName.Visible = true;
            grdColCodeFileName.VisibleIndex = 0;

            GridColumn grdColCodeName = new GridColumn();
            grdColCodeName.Caption = "零件名称";
            grdColCodeName.FieldName = "CodeName";
            grdColCodeName.Name = "grdColCodeName";
            grdColCodeName.AppearanceHeader.Options.UseTextOptions = true;
            grdColCodeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColCodeName.Visible = true;
            grdColCodeName.VisibleIndex = 1;

            repSearchLookUp.View.Columns.AddRange(new GridColumn[] { grdColAutoId, grdColCodeFileName, grdColCodeName });

            repSearchLookUp.NullText = "";
            repSearchLookUp.ValueMember = valueMemberStr;
            repSearchLookUp.DisplayMember = displayMemberStr;

            if (partsCodeTable_false == null)
                partsCodeTable_false = commonDAO.QueryPartsCode(false);
            repSearchLookUp.DataSource = partsCodeTable_false;

            repSearchLookUp.View.IndicatorWidth = 60;
            repSearchLookUp.View.CustomDrawRowIndicator += searchLookUpView_CustomDrawRowIndicator;

            repSearchLookUp.View.Tag = "Init";
        }

        #endregion

        #region 项目信息控件

        /// <summary>
        /// 项目信息表
        /// </summary>
        private DataTable projectListTable_True = null;//包含全部选项
        private DataTable projectListTable_false = null;//不包含全部选项

        /// <summary>
        /// SearchLookUpEdit项目信息控件初始化
        /// </summary>
        public void SearchLookUpEdit_ProjectList(SearchLookUpEdit searchLookUp, bool addAllItem, string valueMemberStr = "ProjectNo", string displayMemberStr = "ProjectName")
        {
            if (DataTypeConvert.GetString(searchLookUp.Properties.View.Tag) == "Init")
                return;

            GridColumn grdColAutoId = new GridColumn();
            grdColAutoId.Caption = "AutoId";
            grdColAutoId.FieldName = "AutoId";
            grdColAutoId.Name = "grdColAutoId";

            GridColumn grdColProjectNo = new GridColumn();
            grdColProjectNo.Caption = "项目号";
            grdColProjectNo.FieldName = "ProjectNo";
            grdColProjectNo.Name = "grdColProjectNo";
            grdColProjectNo.AppearanceHeader.Options.UseTextOptions = true;
            grdColProjectNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColProjectNo.Visible = true;
            grdColProjectNo.VisibleIndex = 0;

            GridColumn grdColProjectName = new GridColumn();
            grdColProjectName.Caption = "项目名称";
            grdColProjectName.FieldName = "ProjectName";
            grdColProjectName.Name = "grdColProjectName";
            grdColProjectName.AppearanceHeader.Options.UseTextOptions = true;
            grdColProjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColProjectName.Visible = true;
            grdColProjectName.VisibleIndex = 1;

            GridColumn grdColRemark = new GridColumn();
            grdColRemark.Caption = "备注";
            grdColRemark.FieldName = "Remark";
            grdColRemark.Name = "grdColRemark";
            grdColRemark.AppearanceHeader.Options.UseTextOptions = true;
            grdColRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColRemark.Visible = true;
            grdColRemark.VisibleIndex = 2;

            searchLookUp.Properties.View.Columns.AddRange(new GridColumn[] { grdColAutoId, grdColProjectNo, grdColProjectName, grdColRemark });

            searchLookUp.Properties.NullText = "";
            searchLookUp.EnterMoveNextControl = true;
            searchLookUp.Properties.ValueMember = valueMemberStr;
            searchLookUp.Properties.DisplayMember = displayMemberStr;

            if (addAllItem)
            {
                if (projectListTable_True == null)
                    projectListTable_True = commonDAO.QueryProjectList(true);
                searchLookUp.Properties.DataSource = projectListTable_True;
            }
            else
            {
                if (projectListTable_false == null)
                    projectListTable_false = commonDAO.QueryProjectList(false);
                searchLookUp.Properties.DataSource = projectListTable_false;
            }

            searchLookUp.Properties.View.IndicatorWidth = 60;
            searchLookUp.Properties.View.CustomDrawRowIndicator += searchLookUpView_CustomDrawRowIndicator;

            searchLookUp.Properties.View.Tag = "Init";
        }

        /// <summary>
        /// SearchLookUpEdit项目信息控件初始化
        /// </summary>
        public void RepositoryItemSearchLookUpEdit_ProjectList(RepositoryItemSearchLookUpEdit repSearchLookUp, string valueMemberStr = "ProjectNo", string displayMemberStr = "ProjectName")
        {
            if (DataTypeConvert.GetString(repSearchLookUp.View.Tag) == "Init")
                return;

            GridColumn grdColAutoId = new GridColumn();
            grdColAutoId.Caption = "AutoId";
            grdColAutoId.FieldName = "AutoId";
            grdColAutoId.Name = "grdColAutoId";

            GridColumn grdColProjectNo = new GridColumn();
            grdColProjectNo.Caption = "项目号";
            grdColProjectNo.FieldName = "ProjectNo";
            grdColProjectNo.Name = "grdColProjectNo";
            grdColProjectNo.AppearanceHeader.Options.UseTextOptions = true;
            grdColProjectNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColProjectNo.Visible = true;
            grdColProjectNo.VisibleIndex = 0;

            GridColumn grdColProjectName = new GridColumn();
            grdColProjectName.Caption = "项目名称";
            grdColProjectName.FieldName = "ProjectName";
            grdColProjectName.Name = "grdColProjectName";
            grdColProjectName.AppearanceHeader.Options.UseTextOptions = true;
            grdColProjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColProjectName.Visible = true;
            grdColProjectName.VisibleIndex = 1;

            GridColumn grdColRemark = new GridColumn();
            grdColRemark.Caption = "备注";
            grdColRemark.FieldName = "Remark";
            grdColRemark.Name = "grdColRemark";
            grdColRemark.AppearanceHeader.Options.UseTextOptions = true;
            grdColRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColRemark.Visible = true;
            grdColRemark.VisibleIndex = 2;

            repSearchLookUp.View.Columns.AddRange(new GridColumn[] { grdColAutoId, grdColProjectNo, grdColProjectName, grdColRemark });

            repSearchLookUp.NullText = "";
            repSearchLookUp.ValueMember = valueMemberStr;
            repSearchLookUp.DisplayMember = displayMemberStr;

            if (projectListTable_false == null)
                projectListTable_false = commonDAO.QueryProjectList(false);
            repSearchLookUp.DataSource = projectListTable_false;

            repSearchLookUp.View.IndicatorWidth = 60;
            repSearchLookUp.View.CustomDrawRowIndicator += searchLookUpView_CustomDrawRowIndicator;

            repSearchLookUp.View.Tag = "Init";
        }

        #endregion

        #region 仓位信息控件

        /// <summary>
        /// 仓位信息表
        /// </summary>
        private DataTable repertoryLocationInfoTable_True = null;//包含全部选项
        private DataTable repertoryLocationInfoTable_false = null;//不包含全部选项

        /// <summary>
        /// SearchLookUpEdit仓位信息控件初始化
        /// </summary>
        public void SearchLookUpEdit_RepertoryLocationInfo(SearchLookUpEdit searchLookUp, bool addAllItem, string valueMemberStr = "AutoId", string displayMemberStr = "LocationName")
        {
            if (DataTypeConvert.GetString(searchLookUp.Properties.View.Tag) == "Init")
                return;

            GridColumn grdColAutoId = new GridColumn();
            grdColAutoId.Caption = "AutoId";
            grdColAutoId.FieldName = "AutoId";
            grdColAutoId.Name = "grdColAutoId";

            GridColumn grdColLocationNo = new GridColumn();
            grdColLocationNo.Caption = "仓位号";
            grdColLocationNo.FieldName = "LocationNo";
            grdColLocationNo.Name = "grdColLocationNo";
            grdColLocationNo.AppearanceHeader.Options.UseTextOptions = true;
            grdColLocationNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColLocationNo.Visible = true;
            grdColLocationNo.VisibleIndex = 0;

            GridColumn grdColLocationName = new GridColumn();
            grdColLocationName.Caption = "仓位名称";
            grdColLocationName.FieldName = "LocationName";
            grdColLocationName.Name = "grdColLocationName";
            grdColLocationName.AppearanceHeader.Options.UseTextOptions = true;
            grdColLocationName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColLocationName.Visible = true;
            grdColLocationName.VisibleIndex = 1;

            GridColumn grdColRepertoryName = new GridColumn();
            grdColRepertoryName.Caption = "仓库名称";
            grdColRepertoryName.FieldName = "RepertoryName";
            grdColRepertoryName.Name = "grdColRepertoryName";
            grdColRepertoryName.AppearanceHeader.Options.UseTextOptions = true;
            grdColRepertoryName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColRepertoryName.Visible = true;
            grdColRepertoryName.VisibleIndex = 2;

            searchLookUp.Properties.View.Columns.AddRange(new GridColumn[] { grdColAutoId, grdColLocationNo, grdColLocationName, grdColRepertoryName });

            searchLookUp.Properties.NullText = "";
            searchLookUp.EnterMoveNextControl = true;
            searchLookUp.Properties.ValueMember = valueMemberStr;
            searchLookUp.Properties.DisplayMember = displayMemberStr;

            if (addAllItem)
            {
                if (repertoryLocationInfoTable_True == null)
                    repertoryLocationInfoTable_True = commonDAO.QueryRepertoryLocationInfo(true);
                searchLookUp.Properties.DataSource = repertoryLocationInfoTable_True;
            }
            else
            {
                if (repertoryLocationInfoTable_false == null)
                    repertoryLocationInfoTable_false = commonDAO.QueryRepertoryLocationInfo(false);
                searchLookUp.Properties.DataSource = repertoryLocationInfoTable_false;
            }

            searchLookUp.Properties.View.IndicatorWidth = 60;
            searchLookUp.Properties.View.CustomDrawRowIndicator += searchLookUpView_CustomDrawRowIndicator;

            searchLookUp.Properties.View.Tag = "Init";
        }

        /// <summary>
        /// SearchLookUpEdit仓位信息控件初始化
        /// </summary>
        public void RepositoryItemSearchLookUpEdit_RepertoryLocationInfo(RepositoryItemSearchLookUpEdit repSearchLookUp, string valueMemberStr = "AutoId", string displayMemberStr = "LocationName")
        {
            if (DataTypeConvert.GetString(repSearchLookUp.View.Tag) == "Init")
                return;

            GridColumn grdColAutoId = new GridColumn();
            grdColAutoId.Caption = "AutoId";
            grdColAutoId.FieldName = "AutoId";
            grdColAutoId.Name = "grdColAutoId";

            GridColumn grdColLocationNo = new GridColumn();
            grdColLocationNo.Caption = "仓位号";
            grdColLocationNo.FieldName = "LocationNo";
            grdColLocationNo.Name = "grdColLocationNo";
            grdColLocationNo.AppearanceHeader.Options.UseTextOptions = true;
            grdColLocationNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColLocationNo.Visible = true;
            grdColLocationNo.VisibleIndex = 0;

            GridColumn grdColLocationName = new GridColumn();
            grdColLocationName.Caption = "仓位名称";
            grdColLocationName.FieldName = "LocationName";
            grdColLocationName.Name = "grdColLocationName";
            grdColLocationName.AppearanceHeader.Options.UseTextOptions = true;
            grdColLocationName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColLocationName.Visible = true;
            grdColLocationName.VisibleIndex = 1;

            GridColumn grdColRepertoryName = new GridColumn();
            grdColRepertoryName.Caption = "仓库名称";
            grdColRepertoryName.FieldName = "RepertoryName";
            grdColRepertoryName.Name = "grdColRepertoryName";
            grdColRepertoryName.AppearanceHeader.Options.UseTextOptions = true;
            grdColRepertoryName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColRepertoryName.Visible = true;
            grdColRepertoryName.VisibleIndex = 2;

            repSearchLookUp.View.Columns.AddRange(new GridColumn[] { grdColAutoId, grdColLocationNo, grdColLocationName, grdColRepertoryName });

            repSearchLookUp.NullText = "";
            repSearchLookUp.ValueMember = valueMemberStr;
            repSearchLookUp.DisplayMember = displayMemberStr;

            if (repertoryLocationInfoTable_false == null)
                repertoryLocationInfoTable_false = commonDAO.QueryRepertoryLocationInfo(false);
            repSearchLookUp.DataSource = repertoryLocationInfoTable_false;

            repSearchLookUp.View.IndicatorWidth = 60;
            repSearchLookUp.View.CustomDrawRowIndicator += searchLookUpView_CustomDrawRowIndicator;

            repSearchLookUp.View.Tag = "Init";
        }

        #endregion

        #region 货架信息控件

        /// <summary>
        /// 货架信息表
        /// </summary>
        private DataTable shelfInfoTable_True = null;//包含全部选项
        private DataTable shelfInfoTable_false = null;//不包含全部选项

        /// <summary>
        /// SearchLookUpEdit货架信息控件初始化
        /// </summary>
        public void SearchLookUpEdit_ShelfInfo(SearchLookUpEdit searchLookUp, bool addAllItem, string valueMemberStr = "AutoId", string displayMemberStr = "ShelfNo")
        {
            if (DataTypeConvert.GetString(searchLookUp.Properties.View.Tag) == "Init")
                return;

            GridColumn grdColAutoId = new GridColumn();
            grdColAutoId.Caption = "AutoId";
            grdColAutoId.FieldName = "AutoId";
            grdColAutoId.Name = "grdColAutoId";

            GridColumn grdColShelfNo = new GridColumn();
            grdColShelfNo.Caption = "货架号";
            grdColShelfNo.FieldName = "ShelfNo";
            grdColShelfNo.Name = "grdColShelfNo";
            grdColShelfNo.AppearanceHeader.Options.UseTextOptions = true;
            grdColShelfNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColShelfNo.Visible = true;
            grdColShelfNo.VisibleIndex = 0;

            GridColumn grdColShelfLocation = new GridColumn();
            grdColShelfLocation.Caption = "货架位置";
            grdColShelfLocation.FieldName = "ShelfLocation";
            grdColShelfLocation.Name = "grdColShelfLocation";
            grdColShelfLocation.AppearanceHeader.Options.UseTextOptions = true;
            grdColShelfLocation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColShelfLocation.Visible = true;
            grdColShelfLocation.VisibleIndex = 1;

            GridColumn grdColLocationName = new GridColumn();
            grdColLocationName.Caption = "仓位名称";
            grdColLocationName.FieldName = "LocationName";
            grdColLocationName.Name = "grdColLocationName";
            grdColLocationName.AppearanceHeader.Options.UseTextOptions = true;
            grdColLocationName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColLocationName.Visible = true;
            grdColLocationName.VisibleIndex = 2;

            searchLookUp.Properties.View.Columns.AddRange(new GridColumn[] { grdColAutoId, grdColShelfNo, grdColShelfLocation, grdColLocationName });

            searchLookUp.Properties.NullText = "";
            searchLookUp.EnterMoveNextControl = true;
            searchLookUp.Properties.ValueMember = valueMemberStr;
            searchLookUp.Properties.DisplayMember = displayMemberStr;

            if (addAllItem)
            {
                if (shelfInfoTable_True == null)
                    shelfInfoTable_True = commonDAO.QueryShelfInfo(true);
                searchLookUp.Properties.DataSource = shelfInfoTable_True;
            }
            else
            {
                if (shelfInfoTable_false == null)
                    shelfInfoTable_false = commonDAO.QueryShelfInfo(false);
                searchLookUp.Properties.DataSource = shelfInfoTable_false;
            }

            searchLookUp.Properties.View.IndicatorWidth = 60;
            searchLookUp.Properties.View.CustomDrawRowIndicator += searchLookUpView_CustomDrawRowIndicator;

            searchLookUp.Properties.View.Tag = "Init";
        }

        /// <summary>
        /// SearchLookUpEdit货架信息控件初始化
        /// </summary>
        public void RepositoryItemSearchLookUpEdit_ShelfInfo(RepositoryItemSearchLookUpEdit repSearchLookUp, string valueMemberStr = "AutoId", string displayMemberStr = "ShelfNo")
        {
            if (DataTypeConvert.GetString(repSearchLookUp.View.Tag) == "Init")
                return;

            GridColumn grdColAutoId = new GridColumn();
            grdColAutoId.Caption = "AutoId";
            grdColAutoId.FieldName = "AutoId";
            grdColAutoId.Name = "grdColAutoId";

            GridColumn grdColShelfNo = new GridColumn();
            grdColShelfNo.Caption = "货架号";
            grdColShelfNo.FieldName = "ShelfNo";
            grdColShelfNo.Name = "grdColShelfNo";
            grdColShelfNo.AppearanceHeader.Options.UseTextOptions = true;
            grdColShelfNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColShelfNo.Visible = true;
            grdColShelfNo.VisibleIndex = 0;

            GridColumn grdColShelfLocation = new GridColumn();
            grdColShelfLocation.Caption = "货架位置";
            grdColShelfLocation.FieldName = "ShelfLocation";
            grdColShelfLocation.Name = "grdColShelfLocation";
            grdColShelfLocation.AppearanceHeader.Options.UseTextOptions = true;
            grdColShelfLocation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColShelfLocation.Visible = true;
            grdColShelfLocation.VisibleIndex = 1;

            GridColumn grdColLocationName = new GridColumn();
            grdColLocationName.Caption = "仓位名称";
            grdColLocationName.FieldName = "LocationName";
            grdColLocationName.Name = "grdColLocationName";
            grdColLocationName.AppearanceHeader.Options.UseTextOptions = true;
            grdColLocationName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdColLocationName.Visible = true;
            grdColLocationName.VisibleIndex = 2;

            repSearchLookUp.View.Columns.AddRange(new GridColumn[] { grdColAutoId, grdColShelfNo, grdColShelfLocation, grdColLocationName });

            repSearchLookUp.NullText = "";
            repSearchLookUp.ValueMember = valueMemberStr;
            repSearchLookUp.DisplayMember = displayMemberStr;

            if (shelfInfoTable_false == null)
                shelfInfoTable_false = commonDAO.QueryShelfInfo(false);
            repSearchLookUp.DataSource = shelfInfoTable_false;

            repSearchLookUp.View.IndicatorWidth = 60;
            repSearchLookUp.View.CustomDrawRowIndicator += searchLookUpView_CustomDrawRowIndicator;

            repSearchLookUp.View.Tag = "Init";
        }

        #endregion

        #region 单据状态控件(有提交功能)

        /// <summary>
        /// ComboBoxEdit状态信息控件初始化
        /// </summary>
        public void ComboBoxEdit_OrderState_Submit(ComboBoxEdit comboBox, bool closeItem = true)
        {
            if (DataTypeConvert.GetString(comboBox.Tag) == "Init")
                return;

            comboBox.Properties.Items.Add("全部");
            comboBox.Properties.Items.Add(CommonHandler.OrderState.待提交);
            comboBox.Properties.Items.Add(CommonHandler.OrderState.已审批);
            if(closeItem)
                comboBox.Properties.Items.Add(CommonHandler.OrderState.已关闭);
            comboBox.Properties.Items.Add(CommonHandler.OrderState.审批中);

            comboBox.Tag = "Init";
        }

        #endregion

        #region 单据状态控件(库存状态)

        /// <summary>
        /// ComboBoxEdit状态信息控件初始化
        /// </summary>
        public void ComboBoxEdit_WarehouseState(ComboBoxEdit comboBox,bool settleItem = false)
        {
            if (DataTypeConvert.GetString(comboBox.Tag) == "Init")
                return;

            comboBox.Properties.Items.Add("全部");
            comboBox.Properties.Items.Add(CommonHandler.WarehouseState.待审批);
            comboBox.Properties.Items.Add(CommonHandler.WarehouseState.已审批);
            if (settleItem)
                comboBox.Properties.Items.Add(CommonHandler.WarehouseState.已结账);
            comboBox.Properties.Items.Add(CommonHandler.WarehouseState.审批中);

            comboBox.Tag = "Init";
        }

        #endregion
    }
}
