using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Lemonade.Daemon.Turbo;
using Lemonade.Frame; 
using Protein.Enzyme.Design;
using Protein.Enzyme.Repository;
using Lemonade.Frame.UI;
 
namespace Lemonade.Daemon
{
    /// <summary>
    /// 欢迎界面
    /// </summary>
    public partial class Frm_Welcome : Form, ILoadDisplay
    { 
        /// <summary>
        /// 
        /// </summary>
        private IStartUp starup = null;
      
        /// <summary>
        /// 
        /// </summary>
        bool IsSsable = true;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        public void Notify(object Content)
        {
            if (IsSsable)
            {
                SetContent sc = new SetContent(LabText);
                this.Invoke(sc, new object[] { Content });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Complete()
        {
            this.IsSsable = false;
            while (!this.IsHandleCreated) ; 
            SetActive show = new SetActive(ShowMainActive);
            //show();
            this.Invoke(show);
            SetActive close = new SetActive(CloseActive);
            //close();
            this.Invoke(close); 
        }
          

        #region 动作
        /// <summary>
        /// 显示主窗体动作
        /// </summary>
        protected virtual void ShowMainActive()
        {
            ((Form)this.starup.SystemFrm).Show();
 
        }
        /// <summary>
        /// 关闭欢迎窗体动作
        /// </summary>
        protected virtual void CloseActive()
        {
            this.Close();

        }
        #endregion

        #region 窗体事件方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartUpObj"></param>
        public    Frm_Welcome(IStartUp StartUpObj)
        {
            InitializeComponent();
            this.starup = StartUpObj;
             
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual  void Frm_Welcome_Load(object sender, EventArgs e)
        {
            this.label5.Text = DateTime.Now.ToString("yyyy'年'MM'月'dd'日'");
            //加载图片
            string picfile = Lemon.GetCSFRootDirectory() + "welcome.jpg";
            //是否存在文件
            if (System.IO.File.Exists(picfile))
            {
                this.BackgroundImage = Image.FromFile(picfile);
            }
            //文字
            XmlHelper  xfile= new XmlHelper(Lemon.GetCSFRootDirectory()+"config\\Setting.xml");
            string title = xfile.GetNodeValue("descendant::LabelText/WelcomeTitle");
            this.label2.Text = title;
            string Halftitle = xfile.GetNodeValue("descendant::LabelText/WelcomeHalfTitle");
            this.label3.Text = Halftitle;
            xfile = null;
        }

        protected virtual void Frm_Welcome_Shown(object sender, EventArgs e)
        {  
         
        }

        #endregion

        #region 业务方法

        protected virtual void LabText(object Content)
        {
            if (!this.IsDisposed)
            {
                if (!this.label1.IsDisposed)
                {
                    this.label1.Text = Content.ToString();
                    Debug.WriteLine("线程" + Thread.CurrentThread.ManagedThreadId.ToString());
                }
            }
        }
        #endregion

 
    }
}