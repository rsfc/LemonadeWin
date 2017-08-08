using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Message;
using Lemonade.Frame.Solon;
using Lemonade.Frame.Running;

namespace Lemonade.Frame
{
    /// <summary>
    /// 框架通用功能入口
    /// </summary>
    public static partial class Lemon
    { 

        #region Nazgul

        /// <summary>
        /// 获取守护线程的处理器名称列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GuardianNames()
        {
            List<string> result = new List<string>();
            INazgul nzg = Lemonade.Frame.Running.LemonEnvironment.GetInstance().Guardian;
            for (int i = 0; i < nzg.SkillCount; i++)
            {
                result.Add(nzg[i].SkillName);
            }
            return result;
        }

        /// <summary>
        /// 关闭处理器
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static void GuardianShutDown(string Name)
        { 
            INazgul nzg = Lemonade.Frame.Running.LemonEnvironment.GetInstance().Guardian; 
            for (int i = 0; i < nzg.SkillCount; i++)
            {
                if (nzg[i].SkillName == Name)
                {
                    nzg.ShutDown(i);
                }
            } 
        }

        /// <summary>
        /// 启动处理器
        /// </summary>
        /// <returns></returns>
        public static void GuardianStartUp(string Name)
        {
            INazgul nzg = Lemonade.Frame.Running.LemonEnvironment.GetInstance().Guardian;
            for (int i = 0; i < nzg.SkillCount; i++)
            {
                if (nzg[i].SkillName == Name)
                {
                    nzg.StartUp(i);
                }
            }
        }

        #endregion

        
    }
}
