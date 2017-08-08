using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Module
{
 
    /// <summary>
    /// 调用状态
    /// </summary>
    public class InvokeResult
    {
        /// <summary>
        /// 
        /// </summary>
        public InvokeResult()
        {
            this.State = StateType.NotRunning;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public StateType State { get; set; }
        /// <summary>
        /// 一个对象，包含被调用方法的返回值，如果调用的是构造函数，则为 null。
        /// </summary>
        public object ReturnValue { get; set; }
        /// <summary>
        /// 异常信息
        /// </summary>
        public Exception Error { get; set; }
        /// <summary>
        /// 操作的插件
        /// </summary>
        public IModule Module { get; set; }
    }
}
