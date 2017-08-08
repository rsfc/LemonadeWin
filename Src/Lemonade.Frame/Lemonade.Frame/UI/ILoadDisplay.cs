using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// 启动加载系统模块时接收消息接口
    /// </summary>
    public interface ILoadDisplay : Lemonade.Frame.Design.IObserver
    {
        /// <summary>
        /// 完成加载过程
        /// </summary>
        void Complete(); 
    }
}
