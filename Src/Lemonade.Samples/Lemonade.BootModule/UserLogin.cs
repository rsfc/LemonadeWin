using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.Running;

namespace Lemonade.Samples.BootModule
{
    /// <summary>
    /// 示例前置启动的用户登录功能
    /// 扩展程序接口继承模块接口
    /// </summary>
    public class UserLogin:IExtendApp
    {
        /// <summary>
        /// 实现IExtendApp的属性，表示当前扩展程序是否正常运行
        /// </summary>
        public bool IsHealth
        {
            get;
            set;
        }

        /// <summary>
        /// 实现接口方法，框架默认的运行模块后自动调用初始化方法
        /// </summary>
        public void Initialize()
        {
            FrmLogin fl = new FrmLogin();
            fl.ShowDialog();
        }
        /// <summary>
        /// 实现接口属性，该属性用于对象传递主窗体对象，在某些需要的场景下调用
        /// </summary>
        public IMainForm MainForm
        {
            get;
            set;
        }
        /// <summary>
        /// 实现接口属性，该模块别名
        /// </summary>
        public string ModuleAlias
        {
            get { return "示例前置启动模块"; }
        }
        /// <summary>
        /// 实现接口属性，该模块的唯一名称，由框架维护，不需要认为指定
        /// </summary>
        public string ModuleName
        {
            get;
            set;
        }
        /// <summary>
        /// 实现接口方法，运行缓存，当模块在框架中已经存在实例是，框架默认运行的方法
        /// </summary>
        public void RunCache()
        {
             
        }
    }
}
