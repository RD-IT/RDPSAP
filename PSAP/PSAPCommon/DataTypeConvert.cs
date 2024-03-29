﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace PSAP.PSAPCommon
{
    public class DataTypeConvert
    {
        /// <summary>
        /// 将Object类型转换为String类型
        /// </summary>
        public static string GetString(object obj)
        {
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return "";
            }
            else
                return obj.ToString();
        }

        /// <summary>
        /// 将Object类型转换为Int类型
        /// </summary>
        public static int GetInt(object obj)
        {
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)) || (Object.Equals(obj, "")))
            {
                return 0;
            }
            else
                return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 将Object类型转换为Boolean类型
        /// </summary>
        public static bool GetBoolean(object obj)
        {
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)) || (Object.Equals(obj, "")))
            {
                return false;
            }
            else
                return Convert.ToBoolean(obj);
        }

        /// <summary>
        /// 将Object类型转换为Double类型
        /// </summary>
        public static double GetDouble(object obj)
        {
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)) || (Object.Equals(obj, "")))
            {
                return 0;
            }
            else
                return Convert.ToDouble(obj);
        }
        
        /// <summary>
        /// 将Object类型转换为Decimal类型
        /// </summary>
        public static decimal GetDecimal(object obj)
        {
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value) || (Object.Equals(obj, ""))))
            {
                return 0;
            }
            else
                return Convert.ToDecimal(obj);
        }

        /// <summary>
        /// 将Object类型转换为DateTime类型，为空时默认返回服务器的时间
        /// </summary>
        public static DateTime GetDateTime(object obj)
        {
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return DAO.BSDAO.BaseSQL.GetServerDateTime();
            }
            else
                return Convert.ToDateTime(obj);
        }

        /// <summary>
        /// 将Object类型转换为Bit类型
        /// </summary>
        public static int GetBit(object obj)
        {
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 0;
            }
            else if (GetBoolean(obj))
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 将Bool类型转换为Bit类型
        /// </summary>
        public static int BoolToBit(bool b)
        {
            if (b == true)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 将颜色类型转换为字符串类型
        /// </summary>
        public static string ColorToString(Color color)
        {
            return ColorTranslator.ToHtml(color);
        }

        /// <summary>
        /// 将字符串类型转换为颜色类型
        /// </summary>
        public static Color StringToColor(string colorStr)
        {
            return ColorTranslator.FromHtml(colorStr);
        }

        /// <summary>
        /// 枚举类型转化为DataTable
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="key">键的列名</param>
        /// <param name="val">值得列名</param>
        public static DataTable EnumToDataTable(Type enumType, string key, string val)
        {
            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType);

            var table = new DataTable();
            table.Columns.Add(key, Type.GetType("System.String"));
            table.Columns.Add(val, Type.GetType("System.Int32"));
            table.Columns[key].Unique = true;
            for (int i = 0; i < values.Length; i++)
            {
                var dr = table.NewRow();
                dr[key] = names[i];
                dr[val] = (int)values.GetValue(i);
                table.Rows.Add(dr);
            }
            return table;
        }

        /// <summary>
        /// 枚举类型转化为DataTable
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="key">键的列名</param>
        /// <param name="val">值得列名</param>
        /// <param name="noIncludeList">不包含的列表</param>
        public static DataTable EnumToDataTable_NoInclude(Type enumType, string key, string val,List<int> noIncludeList)
        {
            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType);

            var table = new DataTable();
            table.Columns.Add(key, Type.GetType("System.String"));
            table.Columns.Add(val, Type.GetType("System.Int32"));
            table.Columns[key].Unique = true;
            for (int i = 0; i < values.Length; i++)
            {
                if (!noIncludeList.Contains((int)values.GetValue(i)))
                {
                    var dr = table.NewRow();
                    dr[key] = names[i];
                    dr[val] = (int)values.GetValue(i);
                    table.Rows.Add(dr);
                }
            }
            return table;
        }

        /// <summary>
        /// 将一个一维数组转换为DataTable
        /// </summary>
        /// <param name="Array">一维数组</param>
        /// <param name="numberColumnNameStr">数组下标的列名</param>
        /// <param name="valueColumnNameStr">数组下标所对应值的列名</param>
        public static DataTable ArrayToDataTable(string[] Array, string numberColumnNameStr, string valueColumnNameStr)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(numberColumnNameStr, typeof(int));
            dt.Columns.Add(valueColumnNameStr, typeof(string));

            for (int i = 0; i < Array.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr[numberColumnNameStr] = i + 1;
                dr[valueColumnNameStr] = Array[i].ToString();
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
