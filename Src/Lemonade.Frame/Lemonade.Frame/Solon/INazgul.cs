using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Solon
{
    /// <summary>
    /// 戒灵接口，负责加载戒灵职责和运行戒灵职责，相当于抽象
    /// </summary>
    public interface  INazgul
    {
        /// <summary>
        /// 加载戒灵能力
        /// </summary>
        void LoadNazgulSkill();
        /// <summary>
        /// 使用当前戒灵所有技能
        /// </summary>
        void UseAllSkill();
        /// <summary>
        /// 当前戒灵具备的技能总数
        /// </summary>
        int SkillCount { get; }
        /// <summary>
        /// 获取指定索引的技能
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        INazgulSkill this[int Index] { get; }
        /// <summary>
        /// 关闭指定名称的技能
        /// </summary>
        void ShutDown(int Index);
        /// <summary>
        /// 开始指定名称的技能
        /// </summary>
        void StartUp(int Index);
         

    }


}
