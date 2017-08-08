using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.UI;
using System.Windows.Forms;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// 作废的-----窗体设置基类，封装窗体线程调用设置样式
    /// </summary>
    public abstract  class WindowStyle : IWindowStyle
    {

        /// <summary>
        /// 是否使用此设置器进行ui管理
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <returns></returns>
        public abstract bool IsUse(System.Windows.Forms.Form TargetForm);

        /// <summary>
        /// 设置窗体
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <param name="Manager"></param>
        public  virtual  bool SetWindows(System.Windows.Forms.Form TargetForm,ILayoutManager Manager)
        {
            try
            {
                Form mf = (Form)Lemon.GetMainForm();
                if (TargetForm != mf)
                { 
                    mf.Invoke(new SetWindowStyle(WinStyle), TargetForm, mf, Manager);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Lemon.SendMsgError(ex);
                return false;
            }
        }
        /// <summary>
        /// 窗口样式
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <param name="MainForm"></param>
        /// <param name="Manager"></param>
        protected  abstract void WinStyle(Form TargetForm, Form MainForm, ILayoutManager Manager);


        /// <summary>
        /// 窗体名称
        /// </summary>
        public string FormName
        {
            get;
            set;
        }
        /// <summary>
        /// 窗体类全名
        /// </summary>
        public string FormClassFullName
        {
            get;
            set;
        }
    }
}
