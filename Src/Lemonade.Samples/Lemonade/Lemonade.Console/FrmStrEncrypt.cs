using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using Lemonade.Frame;  
using Lemonade.Frame.UI;

namespace Lemonade.Samples.Console
{
    /// <summary>
    /// 字符串加密窗体
    /// </summary>
    public partial class FrmStrEncrypt : Form, IModule,IFrameWindow
    {
        /// <summary>
        /// 
        /// </summary>
        public FrmStrEncrypt()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {   
            this.textBox2.Text = this.textBox1.Text.SafetyEncryptDES();
            Clipboard.SetText(this.textBox2.Text);
            MessageBox.Show("已经复制到剪贴板");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        { 
            this.Show();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ScrollEventHandler(object sender, ScrollEventArgs e)
        { 
        
        }
        /// <summary>
        /// 
        /// </summary>
        public IMainForm MainForm
        {
            get;
            set;
        }

        public void RunCache()
        {
             
        }


        public string ModuleName
        {
            get;
            set;
        }


        public string ModuleAlias
        {
            get { return "加密字符串窗口"; }
        }

        private void FrmStrEncrypt_Load(object sender, EventArgs e)
        { 
        }
    }
}
