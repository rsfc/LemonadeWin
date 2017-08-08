using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Lemonade.Frame.Module
{
    /// <summary>
    /// 调用状态类型
    /// </summary>
    public enum StateType
    {
        /// <summary>
        /// 异常
        /// </summary>   
        [Description("Error")]
        Error = 0,
        /// <summary>
        /// 成功
        /// </summary>
        [Description("ok")]
        OK = 1,
        /// <summary>
        /// 未找到模块
        /// </summary>
        [Description("NonModule")]
        NonModule = 2,
        /// <summary>
        /// 未找到方法
        /// </summary>
        [Description("NonMethod")]
        NonMethod = 3,
        /// <summary>
        /// 未进行
        /// </summary>
        [Description("未进行")]
        NotRunning  = 4,
    }
}
