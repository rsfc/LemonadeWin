using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Message.Processors;
using Protein.Enzyme.Message;
using System.Windows.Forms;

namespace Lemonade.Frame.Message
{
    /// <summary>
    ///  Lemonade消息总线的消息处理器模板
    ///  为了框架便于使用，对外暴露框架级别的消息处理器，而不是蛋白质类库的消息处理器
    /// </summary>
    internal class LemnadeProcessorTemplate : IProcessor
    {
        IMsgProcess processdata = null;
        /// <summary>
        /// Lemonade消息总线的消息处理器 
        /// </summary> 
        public LemnadeProcessorTemplate(IMsgProcess ProcessData)
        {
            this.processdata = ProcessData;
        }
         
        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="Content"></param>
        public void ProcessMessage(MessageObject Content)
        {
            MsgType type=MsgType.Note;
            if (Content.Type == MessageType.Debug || Content.Type == MessageType.PtDebug)
            {
                type = MsgType.Debug;
            }
            else if (Content.Type == MessageType.Error || Content.Type == MessageType.Warning)
            {
                type = MsgType.Error;
            }
            else if (Content.Type == MessageType.Note || Content.Type == MessageType.InsideInfo)
            {
                type = MsgType.Note;
            }
            //(MsgType)Enum.Parse(typeof(MsgType), Content.Type.ToString("d")))
            if (processdata.IsUse(type))
            {
                processdata.Process(Content.Message,DateTime.Now);
            } 
        }

   

       
    }
}
