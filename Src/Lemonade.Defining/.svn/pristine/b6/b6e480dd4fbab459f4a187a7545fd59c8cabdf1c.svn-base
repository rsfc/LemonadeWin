using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.UI;
using Lemonade.Frame.Solon;
using System.Diagnostics;
using System.Windows.Forms; 

namespace Lemonade.Nazgul.ToolsBar
{
    /// <summary>
    /// 一个技能，这是技能的实现，在架构上与抽象解耦
    /// </summary>
    public class SetToolsBar : INazgulSkill
    {
        private Object thisLock = new Object(); 
        /// <summary>
        /// 
        /// </summary>
        List<string> targetforms = null;
        /// <summary>
        /// 已经设置过的窗体
        /// </summary>
        List<Form> handle = new List<Form>();

        /// <summary>
        /// 
        /// </summary>
        public void UseSkill(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.targetforms == null)
            {
                this.targetforms = Lemon.GetToolsBarFormName();
            } 
            if (this.targetforms != null)
            {
                lock (thisLock)
                {
                    this.SetWindow();
                }
            }
        }
        
        /// <summary>
        /// 设置窗体
        /// </summary>
        protected virtual void SetWindow()
        {
            try
            {
                List<Form> forms = Lemon.GetOpenAllForms();
                if (forms != null)
                {
                    foreach (Form f in forms)
                    {
                        if (this.targetforms.Contains(f.Text))
                        {
                            if (!this.handle.Contains(f))
                            {
                                this.handle.Add(f);
                                Lemon.SetWindowToolsBar(f);
                            }
                        }
                    }

                }
            }
            catch
            { }
            
            
        }
         
        /// <summary>
        /// 冷却时间
        /// </summary>
        public int Cooldown
        {
            get {
                return 400;
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
            get { return "工具栏设置管理"; }
        }
    }
}
