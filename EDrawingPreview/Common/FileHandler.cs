﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SWPreview
{
    class FileHandler
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        
        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="section">项目名称(如 [TypeName] )</param> 
        /// <param name="key">键</param> 
        /// <param name="value">值</param> 
        public void IniWriteValue(string iniPath, string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, iniPath);
        }

        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="section">项目名称(如 [TypeName] )</param> 
        /// <param name="key">键</param> 
        public string IniReadValue(string iniPath, string section, string key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(section, key, "", temp, 500, iniPath);
            return temp.ToString();
        }
    }
}
