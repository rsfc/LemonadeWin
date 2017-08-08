using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace Lemonade.Frame.Running
{
    /// <summary>
    /// 动作类型，目前定义两种数据类型，一个是
    /// 单同时存在单独和顺序时，都执行，当都是单独运行时，最后一个运行，当都是按顺序执行时，都运行
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// 单独运行的，当该动作注册时，动作调用者上的其他动作挂起
        /// </summary>
        [Description("Single")]
        Single = 0,
        /// <summary>
        /// 按顺序执行
        /// </summary>
        [Description("Sequence")]
        Sequence = 1,

    }
}
