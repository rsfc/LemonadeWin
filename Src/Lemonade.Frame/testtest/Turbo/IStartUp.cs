using System;
using Lemonade.Frame;
using Lemonade.Frame.Running;
using Lemonade.Frame.UI;
namespace Lemonade.Daemon.Turbo
{
    /// <summary>
    ///  系统启动接口
    /// </summary>
    public interface IStartUp
    {
        /// <summary>
        /// 
        /// </summary>
        ILoadDisplay DisplayFrm { get; set; }
        ILoadSystem SystemFrm { get; set; }
        ILemonEnvironment SysConfig { get;set;}
        /// <summary>
        /// 实例化并注册对象
        /// </summary>
        void Regedit();
        /// <summary>
        /// 显示展示窗体
        /// </summary>
        void ShowDisplay();
        /// <summary>
        /// 处理过程
        /// </summary>
        void Processing();
        
    }
}
