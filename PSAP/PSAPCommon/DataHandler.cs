using System;
using System.Collections.Generic;
using System.Text;

namespace PSAP.PSAPCommon
{
    class DataHandler
    {
        /// <summary>
        /// SQL字符串替换处理
        /// </summary>
        public static string SQLStringReplaceHandle(string partSQLStr)
        {
            return partSQLStr.Replace("‘", "'").Replace("’", "'");
        }
    }
}
