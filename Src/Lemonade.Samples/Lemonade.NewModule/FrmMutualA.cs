using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;

namespace Lemonade.Samples.NewModule
{
    public partial class FrmMutualA : Form,IModule
    {
        public FrmMutualA()
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            IModule targetModule = Lemon.ModuleFind("Lemonade.Samples.NewModuleMutual.FrmMutualB");
            if (targetModule == null)
            {
                targetModule = Lemon.ModuleLaunch("Lemonade.Samples.NewModuleMutual.FrmMutualB");
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
