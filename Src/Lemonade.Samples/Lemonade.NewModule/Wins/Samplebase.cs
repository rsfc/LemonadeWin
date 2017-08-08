using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;

namespace Lemonade.Samples.NewModule.Wins
{
    /// <summary>
    /// 
    /// </summary>
    public   partial class Samplebase :  Form, IModule
    {
        /// <summary>
        /// 
        /// </summary>
        public Samplebase()
            :base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 实现接口方法，框架默认的运行模块后自动调用初始化方法
        /// </summary>
        public virtual void Initialize()
        { 
        
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
            get { return "示例插件窗体的基类"; }
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
        public virtual void RunCache()
        {

        }
    }
}
