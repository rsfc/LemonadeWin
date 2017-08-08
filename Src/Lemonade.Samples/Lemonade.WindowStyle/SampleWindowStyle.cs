using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;

namespace Lemonade.Samples.WindowStyle
{
    /// <summary>
    /// 在窗体中定义窗体样式
    /// </summary>
    public partial class SampleWindowStyle : Form,IModule
    {
        /// <summary>
        /// 
        /// </summary>
        public SampleWindowStyle()
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
            ///打开窗体
            this.Show();
        }

        /// <summary>
        /// 在初始化时设置窗体的相关样式属性，融入框架中 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SampleWindowStyle_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
