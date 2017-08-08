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
    public partial class FrmKeys : Samplebase
    {
        public FrmKeys()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取交换对象，
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Food fd1 =null;
            List<object> tmp = Lemon.SwapFindObject(false, "牛肉");
            Lemon.SendMsgNote("查询获得结果数量：" + tmp.Count);
            if (tmp != null && tmp.Count>0)
            {
                fd1 = (Food)tmp[0]; 
                this.textBox1.Text = fd1.Name;
                this.textBox2.Text = fd1.Weight.ToString();
                this.textBox3.Text = fd1.Transgenosis.ToString();
            }
            else
            {
                Lemon.SendMsgNote("查询失败");
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Food fd1 = null;
            List<object> tmp = Lemon.SwapFindObject(false, "牛肉",true);
            Lemon.SendMsgNote("查询获得结果数量：" + tmp.Count);
            if (tmp != null && tmp.Count > 0)
            {
                fd1 = (Food)tmp[0];
                this.textBox1.Text = fd1.Name;
                this.textBox2.Text = fd1.Weight.ToString();
                this.textBox3.Text = fd1.Transgenosis.ToString();
            }
            else
            {
                Lemon.SendMsgNote("查询失败");
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Food fd1 = null;
            List<object> tmp = Lemon.SwapFindObject(true, "牛肉");
            Lemon.SendMsgNote("查询获得结果数量：" + tmp.Count);
            if (tmp != null && tmp.Count > 0)
            {
                fd1 = (Food)tmp[0];
                this.textBox1.Text ="";
                this.textBox2.Text ="";
                this.textBox3.Text = "";
            }
            else
            {
                Lemon.SendMsgNote("查询失败");
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Food fd1 = null;
            List<object> tmp1 = Lemon.SwapFindObject(true, "榛子");
            List<object> tmp2 = Lemon.SwapFindObject(true, "铁岭");
            List<object> tmp3 = Lemon.SwapFindObject(true, "开原");
            List<object> tmp4 = Lemon.SwapFindObject(true, "好吃的");
            List<object> tmp5 = Lemon.SwapFindObject(true, 88);
            if (tmp1[0] != null && tmp2[0] != null && tmp3[0] != null && tmp4[0] != null && tmp5[0] != null)
            {
                fd1 = (Food)tmp1[0];
                this.textBox1.Text = fd1.Name;
                this.textBox2.Text = fd1.Weight.ToString();
                this.textBox3.Text = fd1.Transgenosis.ToString();
            }
            else
            {
                Lemon.SendMsgNote("查询失败");
            } 
        }
    }
}
