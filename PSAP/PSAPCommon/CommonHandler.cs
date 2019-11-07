using PSAP.VIEW.BSVIEW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PSAP.PSAPCommon
{
    public class CommonHandler
    {
        static FrmLanguageText f = new FrmLanguageText();
        public CommonHandler()
        {
            PSAP.BLL.BSBLL.BSBLL.language(f);//刷新窗口语言
        }

        /// <summary>
        /// 订单状态编号
        /// </summary>
        public enum OrderState
        {
            待提交 = 1,
            已审批 = 2,
            已关闭 = 3,
            审批中 = 4,
        }

        /// <summary>
        /// 根据订单状态编号得到订单状态描述
        /// </summary>
        public static string Get_OrderState_Desc(string reqStateStr)
        {
            string stateDescStr = "";
            switch (DataTypeConvert.GetInt(reqStateStr))
            {
                case (int)OrderState.待提交:
                    stateDescStr = OrderState.待提交.ToString();
                    break;
                case (int)OrderState.已审批:
                    stateDescStr = OrderState.已审批.ToString();
                    break;
                case (int)OrderState.已关闭:
                    stateDescStr = OrderState.已关闭.ToString();
                    break;
                case (int)OrderState.审批中:
                    stateDescStr = OrderState.审批中.ToString();
                    break;
            }
            return stateDescStr;
        }
        


        /// <summary>
        /// 根据订单状态描述得到订单状态编号
        /// </summary>
        public static int Get_OrderState_No(string stateDescStr)
        {
            int stateNoInt = 0;//全部
            if (stateDescStr == OrderState.待提交.ToString())
                stateNoInt = (int)OrderState.待提交;
            else if (stateDescStr == OrderState.已审批.ToString())
                stateNoInt = (int)OrderState.已审批;
            else if (stateDescStr == OrderState.已关闭.ToString())
                stateNoInt = (int)OrderState.已关闭;
            else if (stateDescStr == OrderState.审批中.ToString())
                stateNoInt = (int)OrderState.审批中;

            return stateNoInt;
        }

        /// <summary>
        /// 库存状态编号
        /// </summary>
        public enum WarehouseState
        {
            待审批 = 1,
            已审批 = 2,
            已结账 = 3,
            审批中 = 4,
        }

        /// <summary>
        /// 根据库存状态编号得到入库单状态描述
        /// </summary>
        public static string Get_WarehouseState_Desc(string wStateStr)
        {
            string stateDescStr = "";
            switch (DataTypeConvert.GetInt(wStateStr))
            {
                case (int)WarehouseState.待审批:
                    stateDescStr = WarehouseState.待审批.ToString();
                    break;
                case (int)WarehouseState.已审批:
                    stateDescStr = WarehouseState.已审批.ToString();
                    break;
                case (int)WarehouseState.已结账:
                    stateDescStr = WarehouseState.已结账.ToString();
                    break;
                case (int)WarehouseState.审批中:
                    stateDescStr = WarehouseState.审批中.ToString();
                    break;
            }
            return stateDescStr;
        }

        /// <summary>
        /// 根据库存状态描述得到入库单状态编号
        /// </summary>
        public static int Get_WarehouseState_No(string wStateDescStr)
        {
            int wStateNoInt = 0;//全部
            if (wStateDescStr == WarehouseState.待审批.ToString())//待审批
                wStateNoInt = (int)WarehouseState.待审批;
            else if (wStateDescStr == WarehouseState.已审批.ToString())//审批
                wStateNoInt = (int)WarehouseState.已审批;
            else if (wStateDescStr == WarehouseState.已结账.ToString())//已结账
                wStateNoInt = (int)WarehouseState.已结账;
            else if (wStateDescStr == WarehouseState.审批中.ToString())//审批中
                wStateNoInt = (int)WarehouseState.审批中;

            return wStateNoInt;
        }

        /// <summary>
        /// 根据单据编号得到单据名称
        /// </summary>
        public static string Get_WarehouseOrderType_Desc(string orderTypeNo)
        {
            switch (orderTypeNo)
            {
                case "1":
                    return "入库单";
                case "2":
                    return "预算外入库单";
                case "3":
                    return "库存移动单-入库";
                case "4":
                    return "库存调整单";
                case "5":
                    return "出库单";
                case "6":
                    return "预算外出库单";
                case "7":
                    return "退货单";
                case "8":
                    return "库存移动单-出库";
            }
            return "";
        }

        /// <summary>
        /// 根据审批类型编号得到审批类型描述
        /// </summary>
        public static string Get_ApprovalCat_Desc(string approvalCatStr)
        {
            string approvalCatDescStr = "";
            switch (approvalCatStr)
            {
                case "0":
                    //approvalCatDescStr = "串行审批";
                    approvalCatDescStr = f.tsmiCxsp.Text;
                    break;
                case "1":
                    //approvalCatDescStr = "并行审批";
                    approvalCatDescStr = f.tsmiBxsp.Text;
                    break;
                case "2":
                    //approvalCatDescStr = "多选一审批";
                    approvalCatDescStr = f.tsmiDxysh.Text;
                    break;
            }
            return approvalCatDescStr;
        }

        /// <summary>
        /// 根据仓库类型编号得到仓库类型描述
        /// </summary>
        public static string Get_RepertoryType_Desc(string repertoryTypeStr)
        {
            string repertoryTypeDescStr = "";
            switch (repertoryTypeStr)
            {
                case "1":
                    //repertoryTypeDescStr = "正常";
                    repertoryTypeDescStr = f.tsmiZc.Text;
                    break;
                case "2":
                    //repertoryTypeDescStr = "虚拟";
                    repertoryTypeDescStr = f.tsmiXn.Text;
                    break;
            }
            return repertoryTypeDescStr;
        }

        /// <summary>
        /// 根据工程类型编号得到工程类型描述
        /// </summary>
        public static string Get_ManufactureType_Desc(string manufactureTypeStr)
        {
            string manufactureTypeDescStr = "";
            switch (manufactureTypeStr)
            {
                case "1":
                    //manufactureTypeDescStr = "正常";
                    manufactureTypeDescStr = f.tsmiZc.Text;
                    break;
                case "2":
                    //manufactureTypeDescStr = "虚拟";
                    manufactureTypeDescStr = f.tsmiXn.Text;
                    break;
            }
            return manufactureTypeDescStr;
        }

        /// <summary>
        /// 得到新的版本号
        /// </summary>
        public static string GetNewVersionNo(string oldVersionStr)
        {
            if (oldVersionStr == "")
                return "1";

            int ii = (int)Convert.ToChar(oldVersionStr);
            ii++;
            if (ii > 57 && ii < 97)
                ii = 97;
            return ((char)ii).ToString();
        }

        /// <summary>
        /// 得到报价单状态数据表
        /// </summary>
        public static DataTable GetQuotationInfoStateTable(bool isAll)
        {
            DataTable table = new DataTable("table");
            table.Columns.Add("AutoId", Type.GetType("System.Int32"));
            table.Columns.Add("Name", Type.GetType("System.String"));

            DataRow newRow;

            if(isAll)
            {
                newRow = table.NewRow();
                newRow["AutoId"] = -1;
                newRow["Name"] = "全部";
                table.Rows.Add(newRow);
            }

            newRow = table.NewRow();
            newRow["AutoId"] = 0;
            newRow["Name"] = "正常";
            table.Rows.Add(newRow);

            newRow = table.NewRow();
            newRow["AutoId"] = 1;
            newRow["Name"] = "关闭";
            table.Rows.Add(newRow);

            return table;
        }


        /// <summary>
        /// 根据任务状态编号得到任务状态描述
        /// </summary>
        public static string Get_PlanTaskStatus_Desc(string planTaskStatusStr)
        {
            string stateDescStr = "";
            switch (planTaskStatusStr)
            {
                case "1":
                    stateDescStr = "未开始";
                    break;
                case "2":
                    stateDescStr = "进行中";
                    break;
                case "3":
                    stateDescStr = "已完成";
                    break;
            }
            return stateDescStr;
        }

        /// <summary>
        /// 根据购买方式编号得到购买方式描述
        /// </summary>
        public static string Get_DesignBomList_IsBuy_Desc(string isBuyStr)
        {
            string buyDescStr = "";
            switch (isBuyStr)
            {
                case "1":
                    buyDescStr = "整体采购";
                    break;
                case "2":
                    buyDescStr = "下级采购";
                    break;
                case "3":
                    buyDescStr = "不采购";
                    break;
            }
            return buyDescStr;
        }
    }
}
