using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.Design
{
    /// <summary>
    /// 观察者接口
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// 通知
        /// </summary>
        /// <param name="Content">通知内容</param>
        void Notify(object Content);
    }
}
