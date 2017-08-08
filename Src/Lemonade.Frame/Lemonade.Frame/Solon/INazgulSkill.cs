using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Lemonade.Frame.Solon
{
    /// <summary>
    /// 戒灵技能，具体程序运行逻辑的提供者，相当于实现，也就是将实现和抽象解耦
    /// </summary>
    public  interface INazgulSkill
    {
        /// <summary>
        /// 技能名称
        /// </summary>
        string SkillName { get; }
        /// <summary>
        /// 使用技能
        /// </summary>
        void UseSkill(object sender, ElapsedEventArgs e);
        /// <summary>
        /// 冷却时间
        /// </summary>
        int Cooldown { get; }
        /// <summary>
        /// 是否连续释放技能
        /// </summary>
        bool IsContinuous { get; }
        
    }
}
