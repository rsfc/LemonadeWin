using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Module
{
    /// <summary>
    /// 模块管理器
    /// </summary>
    public interface IModuleManager
    { 
        /// <summary>
        /// 在运行的模块中查找指定类全名的模块
        /// </summary>
        /// <param name="FullClassName"></param>
        /// <returns></returns>
        IModule FindRunningModule(string FullClassName);
        /// <summary>
        /// 运行指定的模块
        /// </summary>
        /// <returns></returns>
        IModule LaunchModule(string FullClassName, params object[] Parameters); 
        /// <summary>
        /// 关闭指定的模块
        /// </summary>
        /// <returns></returns>
        bool TurnOffModule(string FullClassName);
        /// <summary>
        /// 运行的模块数量
        /// </summary>
        /// <returns></returns>
        int RunningModuleCount();
        /// <summary>
        /// 获取运行的模块类全名列表
        /// </summary>
        /// <returns></returns>
        List<string> RunningModuleFullClassName(); 
        /// <summary>
        /// 获取所有的插件信息
        /// </summary>
        List<ModuleInfo> ModuleInfos { get; }
        /// <summary>
        /// 获取所有正在运行的插件别名。
        /// 由于插件别名是在插件内部定义的属性，用于标识创建插件之初的功能定位。对未实例化的插件不便通过反射获取以免造成资源浪费。
        /// </summary>
        List<string> RunningModuleAlias { get; }
    }
}
