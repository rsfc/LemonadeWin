using System;
using System.Collections.Generic;
using System.Text; 
namespace Lemonade.Frame.Menu
{
    /// <summary>
    /// 事件绑定器
    /// </summary>
    public  interface IEventBinder
    {
        
        /// <summary>
        /// 绑定
        /// </summary>
        /// <param name="Item"></param>
        void Binder(PtMenuItem Item);
    }
}
