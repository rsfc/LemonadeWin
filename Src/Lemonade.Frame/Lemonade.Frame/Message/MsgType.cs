using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Lemonade.Frame.Message
{
    /// <summary>
    /// 框架的消息类型，框架在消息响应上封装了支撑类库的类型
    /// </summary>
    public enum MsgType
    {
        /// <summary>
        /// 异常，警告
        /// </summary>   
        [Description("Error")]
        Error = 0, 
        /// <summary> 
        /// 消息提示
        /// </summary>
        [Description("Note")]
        Note = 1, 
        /// <summary>
        /// 调试
        /// </summary>
        [Description("Debug")]
        Debug = 2, 
    }
}
