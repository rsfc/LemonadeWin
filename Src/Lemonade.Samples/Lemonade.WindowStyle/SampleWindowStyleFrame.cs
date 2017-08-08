using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;
using Lemonade.Frame.UI;

namespace Lemonade.Samples.WindowStyle
{
    /// <summary>
    /// 将窗体设置为框架管理样式的窗体 继承CSF.Frame.UI.IFrameWindow接口
    /// </summary>
    public partial class SampleWindowStyleFrame : Form,IModule,IFrameWindow
    {
        /// <summary>
        /// 
        /// </summary>
        public SampleWindowStyleFrame()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        { 
            ///打开窗体
            this.Show();
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
            get { return "示例插件窗体"; }
        }
        /// <summary>
        /// 实现接口属性，该模块的唯一名称，由框架维护，不需要人为指定
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
