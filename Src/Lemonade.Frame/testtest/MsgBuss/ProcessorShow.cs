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
    ///  Lemonade消息总线的消息处理器--当出现错误异常消息是显示提示框
    /// </summary>
    public class ProcessorShow : IProcessor
    {

        /// <summary>
        /// Lemon消息总线的消息处理器--当出现错误异常消息是显示提示框
        /// </summary> 
        public ProcessorShow()
        {

        }


        #region IProcessor 成员
        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="Content"></param>
        public void ProcessMessage(MessageObject Content)
        {
            if (Content.Type == MessageType.Error)
            {
                System.Windows.Forms.MessageBox.Show(Content.Message.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        #endregion

       
    }
}
