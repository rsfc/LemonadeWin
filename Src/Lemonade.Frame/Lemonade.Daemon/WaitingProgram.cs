using System;
using System.Collections.Generic;
using System.Text;
using Lemonade.Frame.UI;
using System.Windows.Forms;
using System.Threading;

namespace Lemonade.Daemon
{
    /// <summary>
    /// 
    /// </summary>
   public  class WaitingProgram:IWaitingProgram
    {
       /// <summary>
       /// 
       /// </summary>
       private string content = "";
       /// <summary>
       /// 
       /// </summary>
       private IWaitionForm waitingForm = null;
       /// <summary>
       /// 
       /// </summary>
       private Lemonade.Frame.IMainForm MainForm;
       /// <summary>
       /// 
       /// </summary>
       protected Thread mainThread = null;
       ///// <summary>
       ///// 
       ///// </summary>
       //protected bool isopenform = false;
       /// <summary>
       /// 
       /// </summary>
       protected Thread newThrd = null;
       /// <summary>
       /// 
       /// </summary>
       /// <param name="MainForm"></param>
       public WaitingProgram(Lemonade.Frame.IMainForm MainForm)
       {
           this.MainForm = MainForm;
       }


        #region IWaitingProgram 成员
       /// <summary>
       /// 设置内容
       /// </summary>
       /// <param name="Content"></param>
        public virtual  void SetContent(string Content)
        {
            this.content = Content; 
        }
      
       /// <summary>
       /// 显示
       /// </summary>
        public virtual  void ShowDialog()
        {
            CloseDialog();
            ThreadStart thrdStart = delegate { ShowProcess(); };
            newThrd = new Thread(thrdStart);
            newThrd.IsBackground = true;
            newThrd.Start(); 
            //newThrd.
        }
        
       /// <summary>
       /// 关闭
       /// </summary>
        public virtual  void CloseDialog()
        {
            if (this.waitingForm != null)
            {
                this.waitingForm.ThisClose();
            }
            else
            {
                if (this.newThrd != null)
                {
                    if (this.newThrd.IsAlive)
                    {
                        this.newThrd.Abort();
                    }
                }
            }
        }

 
       /// <summary>
       /// 设置窗体
       /// </summary>
       /// <param name="WaitingForm"></param>
        public void SetForm(IWaitionForm WaitingForm)
        {
            this.waitingForm = WaitingForm;
        }

        #endregion


  
        /// <summary>
        /// 创建等待窗体
        /// </summary>
        protected virtual void CreateForm()
        { 
            //this.waitingForm.SetContent(this.content);
        }
        /// <summary>
        /// 显示处理方法
        /// </summary>
        protected virtual void Show()
        {　
            //this.waitingForm.ThisOpen(); 
            ((Form)this.waitingForm).ShowDialog(); 
            //this.isopenform = true;
        }
        /// <summary>
        /// 显示处理过程
        /// </summary>
        protected virtual void ShowProcess()
        {
            this.waitingForm = new FrmWaiting(); 
            ActiveWaiting setchild = new ActiveWaiting(SetChild);
            this.waitingForm.SetContent(this.content);
            Show();
        }

       /// <summary>
       /// 
       /// </summary>
       protected virtual void SetChild()
       {
           //CSF.Frame.Universal.SetFrmSlaveSytle(this.MainForm, (Form)this.waitingForm);
           ((Form)this.waitingForm).MdiParent = (Form)this.MainForm;
       }

    }
}
