using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;
using Lemonade.Frame.Message;

namespace Lemonade.StatusBox
{
    /// <summary>
    /// 消息处理基类
    /// </summary>
    public abstract  class MsgProcess : IMsgProcess
    {
        public FrmStatusBox TargetFrom { get; set; }

        protected int rowindex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StatusFrame"></param>
        public MsgProcess(FrmStatusBox StatusFrame)
        {
            this.TargetFrom = StatusFrame;
        }
        protected abstract MsgType ProType();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public bool IsUse(MsgType Type)
        {
            if (Type == ProType())
            {
                if (this.TargetFrom != null)
                {
                    if (!this.TargetFrom.IsDisposed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected abstract void ShowMsg(object Msg,DateTime Date);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        public void Process(object Msg, DateTime Date)
        {
            ShowMsg(Msg, Date); 
        }

       
       
    }


}
