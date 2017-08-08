using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Message.Processors;
using Protein.Enzyme.Message;
using System.Windows.Forms;

namespace Lemonade.Daemon.MsgBuss
{
    /// <summary>
    ///  Lemonade消息总线的消息处理器--欢迎界面的消息提示仅提示pt框架级别类型的提示
    /// </summary>
    public class ProcessorWelcome : IProcessor
    {
        Lemonade.Frame.IMainForm mainform = null;

        /// <summary>
        /// Lemon消息总线的消息处理器--欢迎界面的消息提示仅提示pt框架级别类型的提示
        /// </summary> 
        public ProcessorWelcome(Lemonade.Frame.IMainForm Mainform)
        {
            this.mainform = Mainform;
        }


        #region IProcessor 成员
        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="Content"></param>
        public void ProcessMessage(MessageObject Content)
        {
            if (Content.Type == MessageType.InsideInfo)
            {
                if (this.mainform != null)
                {
                    if (this.mainform.GetType().GetInterface("IObserver") != null)
                    {
                        ((Lemonade.Frame.Design.IObserver)this.mainform).Notify(Content.Message.ToString());
                    }
                }
            } 
        }

        #endregion

       
    }
}
