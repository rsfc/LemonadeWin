using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;

namespace Lemonade.Samples.Declare
{
    /// <summary>
    ///  实例如何读取扩展配置，实现了IModule接口，表示对框架来说这个是一个插件模块
    /// </summary>
    public partial class SampleExConfig : Form,IModule
    {
        public SampleExConfig()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 实现接口方法，框架默认的运行模块后自动调用初始化方法
        /// </summary>
        public void Initialize()
        {
            ///打开窗体
            this.Show();
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadConfig()
        {
            SampleConfig config = Lemon.GetExtendConfig<SampleConfig>();
            this.textBox1.Text = config.FieldString;
            this.textBox2.Text = config.FieldInt.ToString();
            this.textBox3.Text = config.FieldDate.ToString();
            this.textBox4.Text = config.FieldDouble.ToString();

            this.textBox5.Text = config.CoffeeSet.Bitter.ToString();
            this.textBox6.Text = config.CoffeeSet.Puckery.ToString();
            this.textBox7.Text = config.CoffeeSet.Smell.ToString();
            this.textBox8.Text = config.CoffeeSet.Sour.ToString();

            foreach (Coffee cf in config.CoffeeSetList)
            {
                this.textBox9.Text += cf.Bitter.ToString() + ","
                    + cf.Puckery.ToString() + ","
                    + cf.Smell.ToString() + ","
                    + cf.Sour.ToString();
            }

        }
        /// <summary>
        /// 实现接口属性，该属性用于对象传递主窗体对象，在某些需要的场景下调用
        /// </summary>
        public IMainForm MainForm
        {
            get;
            set;
        }
        /// <summary>
        /// 实现接口属性，该模块别名
        /// </summary>
        public string ModuleAlias
        {
            get { return "示例插件窗体"; }
        }
        /// <summary>
        /// 实现接口属性，该模块的唯一名称，由框架维护，不需要人为指定
        /// </summary>
        public string ModuleName
        {
            get;
            set;
        }
        /// <summary>
        /// 实现接口方法，运行缓存，当模块在框架中已经存在实例是，框架默认运行的方法
        /// </summary>
        public void RunCache()
        { 
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ReadConfig();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveConfig()
        {
            SampleConfig config = Lemon.GetExtendConfig<SampleConfig>();
            config.FieldString=this.textBox1.Text;
            config.FieldInt=int.Parse(this.textBox2.Text);
            config.FieldDate=DateTime.Parse(this.textBox3.Text);
            config.FieldDouble=double.Parse(this.textBox4.Text);

            config.CoffeeSet.Bitter=int.Parse(this.textBox5.Text);
            config.CoffeeSet.Puckery=int.Parse(this.textBox6.Text);
            config.CoffeeSet.Smell=int.Parse(this.textBox7.Text);
            config.CoffeeSet.Sour=int.Parse(this.textBox8.Text);

            Lemon.SaveExtendConfig<SampleConfig>(config);
        }
    }
}
