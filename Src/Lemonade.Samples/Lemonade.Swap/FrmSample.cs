using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;
using Lemonade.Samples.SampleEntity;

namespace Lemonade.Samples.Swap
{
    public partial class FrmSample : Samplebase
    {
        public FrmSample()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取交换对象，为了便于使用框架封装了泛型参数的方法，下面展示不同写法的不同效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Food fd1 = Lemon.SwapFindObject<Food>();
            Food fd3 = Lemon.SwapFindObject<Food>(typeof(Food)); 
            if (fd1 == null && fd3==null)
            {
                Lemon.SendMsgNote("存入的对象类型是Apple，使用基类查找无结果");
            } 
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Food fd2 = Lemon.SwapFindObject<Food>("Lemonade.Samples.SampleEntity.Apple");
            Food fd4 = Lemon.SwapFindObject<Apple>(typeof(Apple));
            Food fd5 = Lemon.SwapFindObject<Food>(typeof(Apple));
            if (fd2 != null && fd4 != null && fd5 != null)
            {
                this.textBox1.Text = fd2.Name;
                this.textBox2.Text = fd2.Weight.ToString();
                this.textBox3.Text = fd2.Transgenosis.ToString();
            }
        }
    }
}
