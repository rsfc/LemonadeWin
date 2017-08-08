using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Message;
using System.Windows.Forms;

namespace Lemonade.Samples.Msg
{
    /// <summary>
    /// 自定义的异常处理类
    /// </summary>
    public class CustomErrorProcess:IMsgProcess
    {
        delegate void ShowData(FrmCustomError Frm, object Msg);
        FrmCustomError targetFrm = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Frm"></param>
        public CustomErrorProcess(FrmCustomError Frm)
        {
            this.targetFrm = Frm; 
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        public void Process(object Msg,DateTime Date)
        {
            this.targetFrm.Invoke(new ShowData(Show),this.targetFrm,Msg); 
        }
        /// <summary>
        /// 只能在创建线程的控件上操作控件，所以这里没有直接调用，而是使用一个委托
        /// </summary>
        /// <param name="Frm"></param>
        /// <param name="Msg"></param>
        protected virtual void Show(FrmCustomError Frm, object Msg)
        {
            Frm.ShowMsg(Msg);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public bool IsUse(MsgType Type)
        {
            if (Type == MsgType.Error)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
