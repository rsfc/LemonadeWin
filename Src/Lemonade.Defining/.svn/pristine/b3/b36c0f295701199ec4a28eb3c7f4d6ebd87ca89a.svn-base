using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.Solon;
using System.Timers;
using Lemonade.Skills;
namespace Lemonade.Nazgul
{
    /// <summary>
    /// 戒灵
    /// </summary>
    public class Nzagul : INazgul
    { 
        /// <summary>
        /// 时钟列表
        /// </summary>
        List<Timer> timers = null;
        /// <summary>
        /// 技能列表
        /// </summary>
        List<INazgulSkill> skills = new List<INazgulSkill>();
        /// <summary>
        /// 
        /// </summary>
        public Nzagul()
        {
            this.timers = new List<Timer>();
             
        }
        
   

        

        /// <summary>
        /// 加载戒灵技能
        /// </summary>
        public void LoadNazgulSkill()
        { 
            string s = Lemon.GetCSFRootDirectory()+@"\Skills\";
            this.skills = Lemon.FindInstanceFromDirectory<INazgulSkill>(s,false); 
        }

        /// <summary>
        /// 技能数量
        /// </summary>
        public int SkillCount
        {
            get { return this.skills.Count; }
        }

        /// <summary>
        /// 使用技能
        /// </summary>
        public void UseAllSkill()
        {
            if (this.skills != null)
            {
                foreach (INazgulSkill ns in this.skills)
                {
                    Scream(ns);
                }
            } 
        }

        /// <summary>
        /// 尖啸
        /// </summary>
        protected virtual void Scream(INazgulSkill Skill)
        {
            CheckSkill cs = new CheckSkill(Skill); 
            this.timers.Add(cs.GetTimer);
        }

 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public INazgulSkill this[int Index]
        {
            get {

                return this.skills[Index];
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="Index"></param>
        public void ShutDown(int Index)
        {
            this.timers[Index].Stop();
        }

        /// <summary>
        /// 开启
        /// </summary>
        /// <param name="Index"></param>
        public void StartUp(int Index)
        {
            this.timers[Index].Start();
        }
    }
}
