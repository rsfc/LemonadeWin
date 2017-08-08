using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Menu;
using Lemonade.Frame.Module;
using Lemonade.Frame.Tools;

namespace Lemonade.Frame.Running
{
 
    /// <summary>
    /// 内部规则，用于强制验证菜单、工具栏、工具按钮、模块运行等是否具备足够的权限，
    /// 该接口的实现是在业务层，与其他框架内置机制相同使用可扩展的插件机制运行。
    /// 达到不同业务系统对权限的不同需求与框架解耦的目的。
    /// </summary>
    public interface IRunningRules
    {
        /// <summary>
        /// 菜单项是否可见
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        bool IsVisibleMenuItem(IMenuItem Item); 
        /// <summary>
        /// 工具栏按钮 是否可见
        /// </summary>
        /// <param name="Btn"></param>
        /// <returns></returns>
        bool IsVisibleToolButton(IToolsItem Btn);
        /// <summary>
        /// 工具栏是否可见
        /// </summary>
        /// <param name="Bar"></param>
        /// <returns></returns>
        bool IsVisibleToolbar(IToolsBar Bar);
        /// <summary>
        /// 是否运行模块运行
        /// </summary>
        /// <param name="Module"></param>
        /// <returns></returns>
        bool IsEnabledModule(IModule Module);

        
    }
}
