using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.Running
{
    /// <summary>
    /// 扩展程序接口
    /// </summary>
    public interface IExtendApp:IModule
    {  
         
        ///// <summary>
        ///// 运行
        ///// </summary>
        //void Launch();
        /// <summary>
        /// 是否健康
        /// </summary>
        bool IsHealth { get; set; }
    }
}
