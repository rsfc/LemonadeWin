using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Running;
using Lemonade.Frame;
using System.Windows.Forms;

namespace Lemonade.Daemon
{
    /// <summary>
    /// 扫尾操作
    /// </summary>
    public class RoundOff: IRoundOff
    {
        private List<RoundOpration> oprations = new List<RoundOpration>();
        private bool IsClose=false;
        /// <summary>
        /// 当前主窗体的扫尾接口
        /// </summary>
        /// <param name="MainForm"></param>
        public RoundOff(IMainForm MainForm)
        {
            this.MainForm = MainForm;
            SetCloseing();
        }
        /// <summary>
        /// 设置关闭系统功能
        /// </summary>
        protected  virtual  void SetCloseing()
        {
            Form mf = (Form)this.MainForm;
            mf.FormClosing+=new FormClosingEventHandler(mf_FormClosing);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected  virtual  void mf_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !IsClose;
            if (!this.IsClose)
            {
                SystemExit();
            }
        }
        /// <summary>
        /// 运行操作
        /// </summary>
        protected  virtual bool RunningOpration()
        {
            bool result=true;
            foreach (RoundOpration ro in this.oprations)
            {
                if (!ro())
                {
                    result= false;
                }
            }
            return result;
        }
        /// <summary>
        /// 添加操作
        /// </summary>
        /// <param name="Opration"></param>
        /// <returns></returns>
        public virtual  int AddOpration(RoundOpration Opration)
        {
            if (!this.oprations.Contains(Opration))
            {
                this.oprations.Add(Opration);
            }
            return 0;
        }

        public IMainForm MainForm { get; set; }


        /// <summary>
        /// 退出系统
        /// </summary>
        public void SystemExit()
        {
            if (this.RunningOpration())
            {
                this.IsClose = true;
                Form mf = (Form)this.MainForm;
                mf.Close();
            }
        }
    }
}
