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
    public partial class Frm1 : Samplebase
    {
        public Frm1()
            :base()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 重写初始化方法
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            this.Show();
        }
        /// <summary>
        /// 重写再次运行方法
        /// </summary>
        public override void  RunCache()
        {
 	         base.RunCache();
        }
        /// <summary>
        /// 覆盖基类的属性
        /// </summary>
        public new string ModuleAlias
        {
            get { return "Frm1"; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.ModuleAlias);
        }
          
    }
}
