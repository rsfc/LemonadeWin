using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;
using Lemonade.Frame.Running;
 
namespace Lemonade.Samples.Action
{
    public partial class FrmAction2 : Form,IModule
    {
        public FrmAction2()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.Show();
        }

        public IMainForm MainForm
        {
            get;
            set;
        }

        public string ModuleAlias
        {
            get { return "动作示例 按钮"; }
        }

        public string ModuleName
        {
            get;
            set;
        }

        public void RunCache()
        {
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IModule targetModule = Lemon.ModuleFind("NewModuleMutual.FrmMutualB");
            //if (targetModule == null)
            //{
            //    targetModule = Lemon.ModuleLaunch("NewModuleMutual.FrmMutualB");
            //}
            //Lemon.ModuleInvoke(targetModule, "Add",1);
        }

        

        protected void EventHandler(object sender, EventArgs e)
        {

            this.textBox1.Text = ((TextBox)sender).Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ///获取要设置处理函数的调用者，这里是一个文本框
            TextBox tb = (TextBox)(Lemon.SwapFindObject(false, "ActionText")[0]);
            //通知框架注册这个文本框的textchanged事件监控动作
            Lemon.ActionAppend(tb, "TextChanged", ActionType.Single, new EventHandler(this.EventHandler));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)(Lemon.SwapFindObject(false, "ActionText")[0]);
            Lemon.ActionRemove(tb, "TextChanged", new EventHandler(this.EventHandler));
        }
    
      
    }
}
