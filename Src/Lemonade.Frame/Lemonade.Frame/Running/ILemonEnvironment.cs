using System;
using System.Collections.Generic;
using System.Text;  
using Protein.Enzyme.Message;
using Lemonade.Frame.Module;
using Lemonade.Frame.Swapping;

namespace Lemonade.Frame.Running
{
    /// <summary>
    /// 框架运行环境接口
    /// </summary>
    public interface ILemonEnvironment
    {
        /// <summary>
        /// 框架主窗体
        /// </summary>
        IMainForm CSFMain { get; set; }
        /// <summary>
        /// 前置程序列表
        /// </summary>
        List<IExtendApp> PreposeApps { get;set;} 
        /// <summary>
        /// 消息受理类型
        /// </summary>
        MessageType SysMessageLevel { get;set;} 
        /// <summary>
        /// 启动开始模块类名
        /// </summary>
        List<string> BeginModules { get; set; }
        /// <summary>
        /// 启动之后运行的模块
        /// </summary>
        List<string> ShowdownModules { get; set; }
        /// <summary>
        /// 配置器
        /// </summary>
        BLLAdapter BllConfig { get;set;}
        /// <summary>
        /// 框架使用的数据库连接字符创
        /// </summary>
        string DatabaseConn { get; set; } 
        /// <summary>
        /// 框架菜单解析类名称 目前是内置在以来的BLL程序集中
        /// </summary>
        Lemonade.Frame.Menu.IMenuItemFactory MenuItemFactory { get; set; } 
        /// <summary>
        /// 模块创建类库对象引擎
        /// </summary>
        PtModuleHandler  ModuleHandles { get; set; } 
        /// <summary>
        /// 框架模块管理器
        /// </summary>
        Lemonade.Frame.Module.IModuleManager ModuleManager { get; set; }
        /// <summary>
        /// 异常可用性自定义接口
        /// </summary>
        ISystemExceptionDefine ExDefine { get; set; }
        /// <summary>
        /// 框架内置运行规则
        /// </summary>
        IRunningRules Rules { get; set; }
        /// <summary>
        /// 框架数据交换池
        /// </summary>
        ISwapPool SwapPool { get; set; }

        /// <summary>
        /// 界面设置
        /// </summary>
        UI.ILayoutManager UIManager { get; set; }
        /// <summary>
        /// 守护线程
        /// </summary>
        Solon.INazgul Guardian { get; set; }
        /// <summary>
        /// 动作管理器
        /// </summary>
        IActionManager ActionsManager { get; set; } 
        /// <summary>
        /// 工具栏管理器
        /// </summary>
        Tools.IToolsBarManager ToolsBarManager { get; set; }

        /// <summary>
        ///  系统扫尾
        /// </summary>
        IRoundOff SystemRoundOff { get; set; }

        /// <summary>
        /// 是否使用AOP
        /// </summary>
         bool UseProxy { get; set; }
    }
}
