using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;

namespace Lemonade.Samples.NewModuleMutual
{
    public partial class FrmMutualB : Form,IModule
    {
        public FrmMutualB()
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
            get { return "跨插件调用示例"; }
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
            IModule targetModule = Lemon.ModuleFind("Lemonade.Samples.NewModule.FrmMutualA");
            if (targetModule == null)
            {
                targetModule = Lemon.ModuleLaunch("Lemonade.Samples.NewModule.FrmMutualA");
            }
            Lemon.ModuleInvoke(targetModule, "Add",1);
        }

        int counter=0;
        public void Add(int Setp)
        {
            this.counter += Setp;
            this.textBox1.Text = this.counter.ToString();

        }
    }
}
