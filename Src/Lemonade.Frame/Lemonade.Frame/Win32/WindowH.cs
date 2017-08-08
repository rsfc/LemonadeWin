using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Lemonade.Frame.Win32
{ 
    /// <summary>
    /// 超找
    /// </summary>
    public class WindowH
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 找子窗体
        /// </summary>
        /// <param name="hwndParent"></param>
        /// <param name="hwndChildAfter"></param>
        /// <param name="lpszClass"></param>
        /// <param name="lpszWindow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")] 
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        /// <summary>
        /// 用于发送信息给窗体
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")] 
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);


        /// <summary>
        /// 查找是否已创建窗体
        /// </summary>
        /// <param name="FormTitle">标题名称</param>
        /// <returns></returns>
        public static bool SearchForm(string FormTitle)
        {
            IntPtr ParenthWnd = new IntPtr(0);
            IntPtr EdithWnd = new IntPtr(0);

            //查到窗体，得到整个窗体 
            ParenthWnd = FindWindow(null, FormTitle);
            if (!ParenthWnd.Equals(IntPtr.Zero))
            {
                return true;
            }
            else
            {
                return false;
            }

        }




    }
}
