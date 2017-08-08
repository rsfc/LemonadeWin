using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;

namespace Lemonade.Daemon.MsgBuss
{
    /// <summary>
    /// 消息窗口
    /// </summary>
    public partial class FrmMessagePanel : Form, IModule
    {
        /// <summary>
        /// 消息窗口
        /// </summary>
        public FrmMessagePanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加
        /// </summary>
        public virtual void DisplayChars(string Chars)
        {
            this.listBox1.Items.Add(Chars);
        }

        /// <summary>
        /// 清空
        /// </summary>
        public virtual void ClearChars(string Chars)
        {
            this.listBox1.Items.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        public void RunCache()
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
        
        /// <summary>
        /// 
        /// </summary>
        public void AddSwapping()
        {
             
        }

        public string ModuleName
        {
            get;
            set;
        }

        public string ModuleAlias
        {
            get { return "消息面板"; }
        }
    }
}

 