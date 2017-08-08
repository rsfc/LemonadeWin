using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.UI;
using Lemonade.Frame.Solon;
using System.Diagnostics;
using System.Windows.Forms; 

namespace Lemonade.Nazgul.General
{
    /// <summary>
    /// 一个技能，这是技能的实现，在架构上与抽象解耦 
    /// </summary>
    public class GeneralUI:INazgulSkill
    {
        private Object thisLock = new Object(); 
        /// <summary>
        /// 已经设置过的窗体
        /// </summary>
        List<Form> handle = new List<Form>();

        /// <summary>
        /// 
        /// </summary>
        public void UseSkill(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (thisLock)
            {
                this.SetWindow();
            }
        }
        
        /// <summary>
        /// 设置窗体
        /// </summary>
        protected virtual void SetWindow()
        {
            try
            {
                List<Form> forms = Lemon.GetOpenForms();
                if (forms != null)
                { 
                    foreach (Form f in forms)
                    {
                        if (!this.handle.Contains(f))
                        { 
                            if (Lemon.SetLayoutWindowStyle(f))
                            {
                                f.FormClosed -= new FormClosedEventHandler(f_FormClosed); 
                                f.FormClosed+=new FormClosedEventHandler(f_FormClosed); 
                                this.handle.Add(f);
                            }
                        }
                    } 
                }
            }
            catch(Exception ex)
            {
                Lemon.SendMsgError(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.handle.Remove((Form)sender);
        }

        /// <summary>
        /// 冷却时间
        /// </summary>
        public int Cooldown
        {
            get {
                return 500;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool IsContinuous
        {
            get {
                return true;
            
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SkillName
        {
            get { return "界面通用样式设置"; }
        }
    }
}
