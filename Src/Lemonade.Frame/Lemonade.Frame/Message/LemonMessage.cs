using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Message
{
    /// <summary>
    /// 框架消息
    /// </summary>
    public class LemonMessage
    {
        /// <summary>
        /// 类型
        /// </summary>
        public MsgType Type { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public object MsgObject { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecordTime { get; set; }
    }
}
