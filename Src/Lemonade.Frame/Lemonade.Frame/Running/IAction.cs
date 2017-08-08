using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Running
{
    /// <summary>
    /// 动作接口，请使用动作管理创建该接口实例
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// 动作名称
        /// </summary>
        string ActionName { get; }
        /// <summary>
        /// 动作类型
        /// </summary>
        ActionType Type { get; } 
        /// <summary>
        /// 调用处理者
        /// </summary>
        Delegate InvokeProcessor { get; }
        /// <summary>
        /// 接触调用处理者
        /// </summary>
        ActionPerformer Performer { get; }
        /// <summary>
        /// 调用者对象
        /// </summary>
        object InvokeObject { get; }
    }
}
