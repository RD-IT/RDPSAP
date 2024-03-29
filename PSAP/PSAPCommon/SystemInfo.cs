﻿using PSAP.ENTITY.BSENTITY;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Text;

namespace PSAP.PSAPCommon
{
    class SystemInfo
    {
        #region 公司信息

        /// <summary>
        /// 公司名称
        /// </summary>
        public static string CompanyName = "天津容大机电科技有限公司";

        /// <summary>
        /// 公司地址
        /// </summary>
        public static string CompAddress = "天津市 华苑产业区 物华道2号 海泰火炬创业园 B座101室";

        /// <summary>
        /// 公司邮编
        /// </summary>
        public static string CompZipCode = "300384";

        /// <summary>
        /// 公司电话
        /// </summary>
        public static string CompTel = "86-22-83717906";

        /// <summary>
        /// 公司传真
        /// </summary>
        public static string CompFax = "86-22-83719776";

        /// <summary>
        /// 公司邮箱
        /// </summary>
        public static string CompE_Mail = "";

        /// <summary>
        /// 公司网址
        /// </summary>
        public static string CompWebSite = "www.rongda-tech.com";

        /// <summary>
        /// 公司商标
        /// </summary>
        public static Image CompImage = null;

        /// <summary>
        /// 工厂地址
        /// </summary>
        public static string PlantAddress = "天津市 西青学府工业区 学府西路2号 西区J4厂房 A座、B座";

        /// <summary>
        /// 工厂邮编
        /// </summary>
        public static string PlantZipCode = "300382";

        #endregion

        #region 系统信息

        /// <summary>
        /// 当前操作员信息类
        /// </summary>
        public static UserInfo user;

        /// <summary>
        /// 当前主机的IP地址
        /// </summary>
        public static string HostIpAddress;

        /// <summary>
        /// 默认打印机名称
        /// </summary>
        public static string DefaultPrinterName = "";

        /// <summary>
        /// 服务器数据库名称
        /// </summary>
        public static string ServerDataBaseName = "PSAP";

        #endregion

        #region 系统参数

        #region 常规

        /// <summary>
        /// 各种登记单查询的列表每页显示行数
        /// </summary>
        public static int OrderQueryGrid_PageRowCount = 500;

        /// <summary>
        /// 各种登记单查询界面默认查询日期的间隔天数
        /// </summary>
        public static int OrderQueryDate_DateIntervalDays = 14;

        /// <summary>
        /// 页面拖拽的最大记录数
        /// </summary>
        public static int FormDragDropMaxRecordCount = 50;

        /// <summary>
        /// 可拖拽的窗体左侧停靠栏的默认宽度
        /// </summary>
        public static int DragForm_LeftDock_Width = 400;

        /// <summary>
        /// 启用流程消息提醒
        /// </summary>
        public static bool EnableWorkFlowMessage = true;

        /// <summary>
        /// 审批通过后才能打印
        /// </summary>
        public static bool ApproveAfterPrint = true;

        /// <summary>
        /// 是否检查用户按钮权限
        /// </summary>
        public static bool IsCheckUserButtonPower = true;

        #endregion

        #region 销售

        /// <summary>
        /// 报价单里面的默认税率值
        /// </summary>
        public static double Quotation_DefaultTax = 0.16;

        /// <summary>
        /// 销售订单里面的默认税率值
        /// </summary>
        public static double SalesOrder_DefaultTax = 0.16;

        #endregion

        #region 项目

        /// <summary>
        /// 甘特图每页显示的行数
        /// </summary>
        public static int Gantt_ResourcesPerPage = 12;

        /// <summary>
        /// 甘特图计划进度条的高度
        /// </summary>
        public static int Gantt_SchedulerBarHeight = 30;

        /// <summary>
        /// 甘特图日程条的颜色
        /// </summary>
        public static Color Gantt_SchedulerBarColor = Color.FromArgb(128, 255, 128);

        #endregion

        #region 采购

        /// <summary>
        /// 是否可以修改生产计划生产的请购单
        /// </summary>
        public static bool PrReqIsAlter_PSBomAutoId = false;

        /// <summary>
        /// 采购订单里面的默认税率值
        /// </summary>
        public static double OrderList_DefaultTax = 0.16;

        /// <summary>
        /// 采购国内结账里面的默认税率值
        /// </summary>
        public static double Settlement_DefaultTax = 0.16;

        /// <summary>
        /// 查询采购未入库天数的接近计划到货日期的天数
        /// </summary>
        public static int OrderNoWarehousing_Days = 5;

        /// <summary>
        /// 请购单适用转换为采购订单，明细的合计总数是否可以超过原请购单的数量 
        /// </summary>
        public static bool PrReqApplyBeyondCountIsSave = false;

        /// <summary>
        /// 入库单适用转换为采购结账单，明细的合计总数是否可以超过原入库单的数量 
        /// </summary>
        public static bool WarehouseWarrantApplyBeyondCountIsSave = false;

        /// <summary>
        /// 请购单明细分配执行人消息提醒
        /// </summary>
        public static bool PrListDistributionMessage = false;

        /// <summary>
        /// 请购单明细分配执行人后是否全部操作员都可以处理
        /// </summary>
        public static bool PrListDistributionAllHandle = false; 

        #endregion

        #region 库存

        /// <summary>
        /// 采购订单适用转换为入库单，明细的合计总数是否可以超过原采购订单的数量 
        /// </summary>
        public static bool OrderApplyBeyondCountIsSave = false;

        /// <summary>
        /// 工单适用转换为出库单，明细的合计总数是否可以超过原工单的数量
        /// </summary>
        public static bool PPApplyBeyondCountIsSave = false;

        /// <summary>
        /// 入库单是否可以修改入库日期
        /// </summary>
        public static bool WarehouseWarrantIsAlterDate = false;

        /// <summary>
        /// 出库单是否可以修改出库日期
        /// </summary>
        public static bool WarehouseReceiptIsAlterDate = false;

        /// <summary>
        /// 停用登记单中的项目号和站号（注：包括请购单、采购单、入库单、出库单以及库存的所有登记单，停用之后会造成库存数量不准确，请谨慎操作。）
        /// </summary>
        public static bool DisableProjectNo = false;

        /// <summary>
        /// 停用登记单中的默认项目号和站号
        /// </summary>
        public static string DisableProjectNo_Default_ProjectNoAndStnNo = "Default";

        /// <summary>
        /// 停用登记单中的默认项目名称
        /// </summary>
        public static string DisableProjectNo_Default_ProjectName = "默认项目";

        /// <summary>
        /// 停用仓库中的货架号（注：包括入库单、出库单以及库存的所有登记单，停用之后会造成库存数量不准确，请谨慎操作。）
        /// </summary>
        public static bool DisableShelfInfo = false;

        /// <summary>
        /// 停用仓库中的货架号的默认货架号AutoId
        /// </summary>
        public static int DisableShelfInfo_Default_ShelfId = 0;

        /// <summary>
        /// 可以负库存数功能
        /// </summary>
        public static bool EnableNegativeInventory = false;

        /// <summary>
        /// 库存登记单保存直接审批
        /// </summary>
        public static bool InventorySaveApproval = false;

        #endregion

        ///// <summary>
        ///// 生成计划单审批生成BOM信息：1 生成BOM第一级节点  2 生成BOM最末节点  3 系统提示选择1或者2
        ///// </summary>
        //public static int ProductionScheduleBOMType = 3;

        #endregion

        #region Socket设置参数

        /// <summary>
        /// 是否检查服务端程序
        /// </summary>
        public static bool IsCheckServer = false;

        /// <summary>
        /// 服务器的IP地址
        /// </summary>
        public static string ServerIP = "192.168.0.146";

        /// <summary>
        /// 服务器通信的端口号
        /// </summary>
        public static int ServerPort = 9988;

        /// <summary>
        /// 服务器通信协议类型
        /// </summary>
        public static ProtocolType ServerProtocolType = ProtocolType.Tcp;

        /// <summary>
        /// 登陆保存密码
        /// </summary>
        public static bool LoginSavePwd = true;

        #endregion

    }
}
