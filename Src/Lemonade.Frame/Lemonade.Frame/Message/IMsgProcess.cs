using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Message;

namespace Lemonade.Frame.Message
{
    /// <summary>
    /// 框架消息处理接口，实现该接口的对象将声明一个消息处理的具体方法，同时制定需要处理什么类型的消息。
    /// </summary>
    public interface IMsgProcess
    {
        /// <summary>
        /// 是否可用，框架通过该方法判断在消息总线中是否使用该消息处理器处理数据
        /// </summary>
        /// <returns></returns>
        bool IsUse(MsgType Type);
        
        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="Date"></param>
        void Process(object Msg,DateTime Date);
    }
}
