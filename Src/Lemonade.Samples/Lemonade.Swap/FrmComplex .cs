using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;
using Lemonade.Frame.Swapping;
using Lemonade.Samples.SampleEntity;

namespace Lemonade.Samples.Swap
{
    public partial class FrmComplex : Samplebase
    {
        public FrmComplex()
        {
            InitializeComponent();
        }

         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Food fd2 = (Food)Lemon.SwapFindObject(new CustomMatchBaseType());
            if (fd2 == null)
            {
                Lemon.SendMsgNote("存入的对象类型是Apple，使用基类查找无结果");
            }
            else
            {
                Lemon.SendMsgNote("使用自定义匹配器查询抽象基类获得正确结果"); 
                this.textBox1.Text = fd2.Name;
                this.textBox2.Text = fd2.Weight.ToString();
                this.textBox3.Text = fd2.Transgenosis.ToString(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Food fd2 = (Food)Lemon.SwapFindObject(new CustomMatchFoodName("Apple"));
            if (fd2 == null)
            {
                Lemon.SendMsgNote("根据自定义名称查找无结果");
            }
            else
            {
                Lemon.SendMsgNote("使用自定义匹配器，针对食物名称匹配查询获得正确结果");
                this.textBox1.Text = fd2.Name;
                this.textBox2.Text = fd2.Weight.ToString();
                this.textBox3.Text = fd2.Transgenosis.ToString();
            }
        }
    }

    /// <summary>
    /// 自定义匹配器，用于创建需要的查找规则.
    /// 判断基类
    /// </summary>
    public class CustomMatchBaseType : ISwapMatch
    {
        /// <summary>
        /// 定义框架在查找交换对象时复合什么条件的Swap对象能使用该匹配器
        /// </summary>
        /// <param name="Swap"></param>
        /// <returns></returns>
        public bool IsSwap(ISwap Swap)
        {
            return Swap.ThisType.IsSubclassOf(typeof(Food));

        }
    }

    /// <summary>
    /// 自定义匹配器，用于创建需要的查找规则.
    /// 判断基类
    /// </summary>
    public class CustomMatchFoodName : ISwapMatch
    {
        string foodname = "";
        public CustomMatchFoodName(string FoodName)
        {
            this.foodname = FoodName;

        }
        /// <summary>
        /// 定义框架在查找交换对象时复合什么条件的Swap对象能使用该匹配器
        /// </summary>
        /// <param name="Swap"></param>
        /// <returns></returns>
        public bool IsSwap(ISwap Swap)
        { 
            if (Swap.PackageObject != null)
            {
                if (Swap.PackageObject.GetType().IsSubclassOf(typeof(Food)))
                {
                    if (((Food)Swap.PackageObject).Name==this.foodname)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
