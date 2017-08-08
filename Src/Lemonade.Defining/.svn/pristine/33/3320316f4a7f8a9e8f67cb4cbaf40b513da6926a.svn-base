using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.Solon;
using System.Timers;

namespace Lemonade.Skills
{
    /// <summary>
    /// 检查技能功能
    /// </summary>
    public class CheckSkill
    {
        /// <summary>
        /// 
        /// </summary>
        public INazgulSkill Skill { get; set; }
        /// <summary>
        /// 
        /// </summary>
        Timer timer = null;
        /// <summary>
        /// 
        /// </summary>
        public Timer GetTimer { 
            get { return this.timer; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Skill"></param>
        public CheckSkill(INazgulSkill Skill)
        { 
            this.Skill = Skill;
            this.timer = new Timer(this.Skill.Cooldown);
            this.timer.AutoReset = true;
            this.timer.Enabled = true;
            this.timer.Elapsed += new ElapsedEventHandler(Pass); 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Pass(object sender, System.Timers.ElapsedEventArgs e)
        { 
            this.timer.Enabled = this.Skill.IsContinuous;
            if (this.Skill.IsContinuous)
            {
                this.Skill.UseSkill(sender, e);
            }
        
        }
 
    }
}
