using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Protein.Enzyme.Log;
using Lemonade.Frame.Design;
using System.Security;
using System.Security.Permissions;
namespace Lemonade.Frame
{
    /// <summary>
    /// 框架插件接口
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// 模块别名 用于显示友好提示 
        /// </summary>
        string ModuleAlias { get;}
        /// <summary>
        /// 模块名称,在模块创建时由框架赋值
        /// </summary>
        string ModuleName { get; set; }
        /// <summary>
        /// 初始化
        /// </summary> 
        void Initialize();
        /// <summary>
        /// 再次运行
        /// </summary>
        void RunCache();
        /// <summary>
        /// 主窗体接口
        /// </summary>
        IMainForm MainForm { get;set;} 
    }
}
