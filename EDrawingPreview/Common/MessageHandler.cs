using System;
using System.Text;
using System.Windows.Forms;

namespace SWPreview
{
    class MessageHandler
    {
        /// <summary>
        /// 弹出提示消息框
        /// </summary>
        /// <param name="messageText">消息内容</param>
        public static void ShowMessageBox(string messageText)
        {
            MessageBox.Show(messageText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 弹出提示消息框，带Yes和No两个按钮
        /// </summary>
        /// <param name="messageText">消息内容</param>
        public static DialogResult ShowMessageBox_YesNo(string messageText)
        {
            return MessageBox.Show(messageText, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// 弹出提示消息框，带Yes、No和Cancel三个按钮
        /// </summary>
        /// <param name="messageText">消息内容</param>
        public static DialogResult ShowMessageBox_YesNoCancel(string messageText)
        {
            return MessageBox.Show(messageText, "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        /// <summary>
        /// 弹出提示消息框，带OK和Cancel两个按钮
        /// </summary>
        /// <param name="messageText">消息内容</param>
        public static DialogResult ShowMessageBox_OKCancel(string messageText)
        {
            return MessageBox.Show(messageText, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }
}
