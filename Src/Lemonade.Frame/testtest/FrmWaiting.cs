using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Protein.Enzyme.Message;
namespace Lemonade.Daemon
{
    /// <summary>
    /// 等待动作
    /// </summary>
    public delegate void ActiveWaiting();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Form"></param>
    public delegate void ActiveWaitingClose(FrmWaiting Form );
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmWaiting : Form, Lemonade.Frame.UI.IWaitionForm
    {
        /// <summary>
        /// 
        /// </summary>
        public FrmWaiting()
        {
            InitializeComponent();
        }

        #region IWaitionForm 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        public virtual void SetContent(string Content)
        {
            this.label1.Text = Content;
        }
 
        /// <summary>
        /// 
        /// </summary>
        public virtual void ThisClose()
        {
            try
            {
                ActiveWaiting closew = new ActiveWaiting(CloseObj);
                while (!this.IsHandleCreated)
                {
                    this.CreateHandle();
                } 
                if (this.InvokeRequired)
                {
                    this.Invoke(closew);
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageObject mo = new MessageObject(MessageType.Debug);
                mo.Message = ex;
                MessageFactory.GetMegBus().Send(mo); 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void CloseObj()
        { 
                this.Close(); 
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void OpenObj(FrmWaiting Form)
        {
            this.TopMost = true;
            this.Show();
        }
        /// <summary>
        /// 
        /// </summary>
        public void ThisOpen()
        { 
            ActiveWaitingClose open = new ActiveWaitingClose(OpenObj); 
            //this.ShowDialog();
            this.BeginInvoke(open,this);
        }

        #endregion
    }
}