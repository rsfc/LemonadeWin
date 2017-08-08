using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;
using System.Reflection;

namespace Lemonade.Samples.Action
{
    public partial class FrmActionText : Form,IModule
    {
        public FrmActionText()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.Show();
            Lemon.SwapAppend(this.textBox1,"ActionText"); 
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

         
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmActionText_Load(object sender, EventArgs e)
        {
           
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)(Lemon.SwapFindObject(false, "ActionText")[0]);
            Lemon.ActionRemove(tb, "TextChanged");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)(Lemon.SwapFindObject(false, "ActionText")[0]);
            Lemon.ActionRemove(tb, "TextChanged",Frame.Running.ActionType.Single);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)(Lemon.SwapFindObject(false, "ActionText")[0]);
            Lemon.ActionRemove(tb, "TextChanged", Frame.Running.ActionType.Sequence);
        }

      
    }
}
