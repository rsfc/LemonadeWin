using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using System.Windows.Forms;

namespace Lemonade.Samples.NewModule
{
    /// <summary>
    /// 实现IModule接口，表示对框架来说这个是一个插件模块
    /// </summary>
    public class LemonNewModule : IModule
    {
        /// <summary>
        /// 实现接口方法，框架默认的运行模块后自动调用初始化方法
        /// </summary>
        public void Initialize()
        {
            //有个缺陷，提示框会被等待窗体挡住，涉及线程运行有空在处理，
            //目前的处理方法有两种只要在Initialize后显示提示框即可，还可以主动直接调用框架封装的关闭等待窗体函数
            Lemon.GetMainForm().WatingProgram.CloseDialog();
            Lemon.SendMsgNote("这是一个由插件弹出的提示框，插件可以是窗体也可以是一个类似这样运行的后台功能"); 
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
            get { return "LemonNewModule"; }
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
            Lemon.SendMsgNote("再次运行");
        }
    }
}
