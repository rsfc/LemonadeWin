using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Message.Processors;
using Protein.Enzyme.Message;
using System.Windows.Forms;
using Lemonade.Frame;

namespace Lemonade.Daemon.MsgBuss
{
    /// <summary>
    ///  Lemonade消息总线的消息处理器--当出现错误异常消息时关闭等待界面
    /// </summary>
    public class ProcessorCloseWaitWindow : IProcessor
    {
        IMainForm mainForm = null;

        /// <summary>
        ///  Lemon消息总线的消息处理器--当出现错误异常消息时关闭等待界面
        /// </summary> 
        public ProcessorCloseWaitWindow(IMainForm MainForm)
        {
            this.mainForm = MainForm;
        }


        #region IProcessor 成员
        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="Content"></param>
        public void ProcessMessage(MessageObject Content)
        {
            if (Content.Type == MessageType.Error
                || Content.Type == MessageType.Note)
            {
                if (this.mainForm != null)
                {
                    if (this.mainForm.WatingProgram != null)
                    {
                        //if (!((Form)this.mainForm.WatingProgram).IsDisposed)
                        //{
                            this.mainForm.WatingProgram.CloseDialog();
                        //}
                    }
                }
            }
         
        }

        #endregion

         
    }
}
