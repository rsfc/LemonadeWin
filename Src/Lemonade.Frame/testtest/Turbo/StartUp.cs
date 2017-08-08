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
using Lemonade.Frame.BLL;
using Protein.Enzyme.Design;
using Lemonade.Frame.Running; 
using Protein.Enzyme.Message;
using Protein.Enzyme.Repository;
using Lemonade.Frame.UI;
namespace Lemonade.Daemon.Turbo
{
    /// <summary>
    /// 系统启动入口,该类应该在Frame中，自动创建相关对象
    /// </summary>
    public class StartUp : System.Windows.Forms.ApplicationContext, Lemonade.Daemon.Turbo.IStartUp
    {
        private ILoadSystem systemFrm = null; 
        public  ILoadSystem SystemFrm
        {
            get { return systemFrm; }
            set { systemFrm = value; }
        }
        private ILoadDisplay displayFrm = null;

        public  ILoadDisplay DisplayFrm
        {
            get { return displayFrm; }
            set { displayFrm = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public ILemonEnvironment SysConfig
        {
            get;
            set;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public StartUp()
        {
            Regedit(); 
            ShowDisplay();
            ThreadLoad();
        }
       

        /// <summary>
        /// 显示
        /// </summary>
        public virtual void ShowDisplay()
        {
            ((Form)this.displayFrm).Show();
        }

        /// <summary>
        /// 实例化并注册对象
        /// </summary>
        public virtual void Regedit()
        {  
            this.systemFrm = Lemon.GetInstance<ILoadSystem>(typeof(FrmMain));
            this.displayFrm = Lemon.GetInstance<ILoadDisplay>(typeof(Frm_Welcome), this);
            this.systemFrm.Regidit(this.displayFrm);
            
        }
        /// <summary>
        /// 处理过程 
        /// </summary>
        public virtual void Processing()
        {
            AddMessageBus();
            Debug.WriteLine("启动处理过程 " + Thread.CurrentThread.ManagedThreadId.ToString()); 
            this.SysConfig = DeployConfig();
            this.SysConfig.CSFMain = (IMainForm)this.systemFrm;
            ((Lemonade.Frame.IMainForm)this.systemFrm).Envir = this.SysConfig;  
            Prepose();
            this.systemFrm.StartProcess();
            this.systemFrm.Finish();
            this.RemoveMessageBus();
        }
        IProcessor p1, p2;
        /// <summary>
        /// 设置框架内置消息总线，目前暂时不分离出去
        /// </summary>
        protected virtual void AddMessageBus()
        {
            p1 = new Lemonade.Daemon.MsgBuss.ProcessorWelcome((IMainForm)this.systemFrm);
            p2 = new Lemonade.Daemon.MsgBuss.ProcessorShow();
            MessageFactory.GetMegBus().Pcslist.Insert(0,new Lemonade.Daemon.MsgBuss.ProcessorCloseWaitWindow((IMainForm)this.systemFrm));
            MessageFactory.GetMegBus().AddProcessor(p1);
            //MessageFactory.GetMegBus().AddProcessor(p2); 
        }

        /// <summary>
        /// 设置框架内置消息总线，目前暂时不分离出去
        /// </summary>
        protected virtual void RemoveMessageBus()
        { 
            MessageFactory.GetMegBus().RemoveProcessor(p1);
            MessageFactory.GetMegBus().RemoveProcessor(p2); 
        }

        /// <summary>
        /// 创建系统配置
        /// </summary>
        public virtual ILemonEnvironment DeployConfig()
        {
            ILemonEnvironment sysconfig = LemonEnvironment.GetInstance(); 
            Lemonade.Frame.BLL.IConfigFactory configsetup = new Lemonade.Frame.BLL.ConfigFactory(AppDomain.CurrentDomain.BaseDirectory + "\\config\\", sysconfig, this.displayFrm); 
            configsetup.Processing();
            return sysconfig;
        }

        /// <summary>
        /// 前置处理
        /// </summary>
        protected virtual void Prepose()
        {
            PreposeBoot pboot = new PreposeBoot(this); 
        }

        /// <summary>
        /// 加载过程
        /// </summary>
        protected virtual void ThreadLoad()
        {
            Thread newThrd = null;
            ThreadStart thrdStart = delegate { Processing(); };
            newThrd = new Thread(thrdStart);
            newThrd.IsBackground = true;
            newThrd.Start();  

        }

 



       
    }
}
