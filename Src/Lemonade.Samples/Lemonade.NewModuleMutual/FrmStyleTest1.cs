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
    public partial class FrmStyleTest1 : Form,IModule
    {
        public FrmStyleTest1()
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

        

     
    }
}
