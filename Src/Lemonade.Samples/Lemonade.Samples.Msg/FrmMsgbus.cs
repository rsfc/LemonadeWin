using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;
using Lemonade.Frame.Message;

namespace Lemonade.Samples.Msg
{
    /// <summary>
    ///   实现了IModule接口，表示对框架来说这个是一个插件模块
    /// </summary>
    public partial class FrmMsgbus : Form, IModule,IMsgProcess
    {
        delegate void ShowData(FrmMsgbus Frm, object Msg);
        /// <summary>
        /// 
        /// </summary>
        IMsgProcess process = null;
        public FrmMsgbus()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 实现接口方法，框架默认的运行模块后自动调用初始化方法
        /// </summary>
        public void Initialize()
        {
            //Lemon.SetFormDefaultStyle(this);
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
            get { return "FrmMsgbus"; }
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

        private void SampleWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            Lemon.AddMsgProcess(this); 
        }

        public void Process(object Msg, DateTime Date)
        {
            this.Invoke(new ShowData(Show), this, Msg); 
        }

        /// <summary>
        /// 只能在创建线程的控件上操作控件，所以这里没有直接调用，而是使用一个委托
        /// </summary>
        /// <param name="Frm"></param>
        /// <param name="Msg"></param>
        protected virtual void Show(FrmMsgbus Frm, object Msg)
        {
            Frm.ShowMsg(Msg);
        }

        protected virtual void ShowMsg(object Msg)
        {

            if (Msg.GetType() == typeof(Exception))
            {
                this.listBox1.Items.Add(((Exception)Msg).Message.ToString() + "::::" + ((Exception)Msg).StackTrace.ToString());
            }
            else {
                this.listBox1.Items.Add(Msg.ToString());
            }
            
        }
        /// <summary>
        /// 所有消息都接受
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public bool IsUse(MsgType Type)
        {
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lemon.RemoveMsgProcess(process); 
        }
    }
}
