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
    public partial class FrmStyleTest2 : Form,IModule
    {
        public FrmStyleTest2()
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IModule targetModule = Lemon.ModuleFind("NewModule.FrmMutualA");
            if (targetModule == null)
            {
                targetModule = Lemon.ModuleLaunch("NewModule.FrmMutualA");
            }
            Lemon.ModuleInvoke(targetModule, "Add",1);
        }
 
    }
}
