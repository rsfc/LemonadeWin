using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// 等待窗体
    /// </summary>
    public  interface  IWaitionForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        void SetContent(string Content);
        /// <summary>
        /// 关闭
        /// </summary>
        void ThisClose(); 
        /// <summary>
        /// 开启
        /// </summary>
        void ThisOpen();
    }
}
