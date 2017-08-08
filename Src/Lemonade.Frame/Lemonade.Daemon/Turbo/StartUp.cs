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
    /// ϵͳ�������,����Ӧ����Frame�У��Զ�������ض���
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
        /// ��ʼ��
        /// </summary>
        public StartUp()
        {
            Regedit(); 
            ShowDisplay();
            ThreadLoad();
        }
       

        /// <summary>
        /// ��ʾ
        /// </summary>
        public virtual void ShowDisplay()
        {
            ((Form)this.displayFrm).Show();
        }

        /// <summary>
        /// ʵ������ע�����
        /// </summary>
        public virtual void Regedit()
        {  
            this.systemFrm = Lemon.GetInstance<ILoadSystem>(typeof(FrmMain));
            this.displayFrm = Lemon.GetInstance<ILoadDisplay>(typeof(Frm_Welcome), this);
            this.systemFrm.Regidit(this.displayFrm);
            
        }
        /// <summary>
        /// ������� 
        /// </summary>
        public virtual void Processing()
        {
            AddMessageBus();
            Debug.WriteLine("����������� " + Thread.CurrentThread.ManagedThreadId.ToString()); 
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
        /// ���ÿ��������Ϣ���ߣ�Ŀǰ��ʱ�������ȥ
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
        /// ���ÿ��������Ϣ���ߣ�Ŀǰ��ʱ�������ȥ
        /// </summary>
        protected virtual void RemoveMessageBus()
        { 
            MessageFactory.GetMegBus().RemoveProcessor(p1);
            MessageFactory.GetMegBus().RemoveProcessor(p2); 
        }

        /// <summary>
        /// ����ϵͳ����
        /// </summary>
        public virtual ILemonEnvironment DeployConfig()
        {
            ILemonEnvironment sysconfig = LemonEnvironment.GetInstance(); 
            Lemonade.Frame.BLL.IConfigFactory configsetup = new Lemonade.Frame.BLL.ConfigFactory(AppDomain.CurrentDomain.BaseDirectory + "\\config\\", sysconfig, this.displayFrm); 
            configsetup.Processing();
            return sysconfig;
        }

        /// <summary>
        /// ǰ�ô���
        /// </summary>
        protected virtual void Prepose()
        {
            PreposeBoot pboot = new PreposeBoot(this); 
        }

        /// <summary>
        /// ���ع���
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
