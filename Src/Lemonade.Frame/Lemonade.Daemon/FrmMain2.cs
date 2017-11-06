using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Lemonade.Frame.Running;
using Lemonade.Frame.UI;
using Lemonade.Frame.Design;
using Protein.Enzyme.Repository;
using Lemonade.Frame;
using Lemonade.Frame.Menu;
using System.Threading;
using System.Diagnostics;

namespace Lemonade.Daemon
{
    public partial class FrmMain2 : DevExpress.XtraBars.Ribbon.RibbonForm
        , Lemonade.Frame.IMainForm, ILoadSystem, IObserver
    {
        #region 变量
        protected DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
        delegate void DelgLemonMainTread(string str);
        /// <summary>
        /// 
        /// </summary>
        IWaitingProgram waitingobj;
        /// <summary>
        /// 加载模块消息处理对象表
        /// </summary>
        ILoadDisplay loadMsgerTable = null;
        /// <summary>
        /// 前置处理事件
        /// </summary>
        public event SetActive Prepose;
        ISkin skinmanager = null;
        #endregion

        #region 窗体事件方法
        /// <summary>
        /// 
        /// </summary>
        public FrmMain2()
        {
            InitializeComponent();
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful";
        }

        private void FrmMain2_Load(object sender, EventArgs e)
        {
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful";
            //this.Envir.SystemRoundOff = new RoundOff(this);
            this.waitingobj = new Lemonade.Daemon.WaitingProgram(this);
            Protein.Enzyme.Message.MessageObject msg
                = new Protein.Enzyme.Message.MessageObject(Protein.Enzyme.Message.MessageType.Debug);
            msg.Message = "启动";

            XmlHelper xfile = new XmlHelper(Lemon.GetCSFRootDirectory() + "config\\Setting.xml");
            string title = xfile.GetNodeValue("descendant::LabelText/WelcomeTitle");
            this.Text = title;
        }

        private void FrmMain2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void FrmMain2_Shown(object sender, EventArgs e)
        {
            BeginModule();
        }
        #endregion

        #region 设置前置动作

        /// <summary>
        /// 设置前置后置动作
        /// </summary>
        protected virtual void SetActive()
        {
            this.backstageViewControl1.
            SetActive acMenu = new SetActive(LoadMenu);
            this.Prepose += acMenu;
        }

        #endregion

        #region 初始化


        /// <summary>
        /// 添加工具栏   
        /// </summary>
        protected virtual void LoadToolStrip()
        {

        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        protected virtual void LoadMenu()
        {
            IEventBinder binder = Lemon.GetInstance<EventBinderToModule>(typeof(EventBinderToModule), new object[] { this });
            IMenuItemFactory itemfac = this.Envir.BllConfig.GetConfig<ILemonEnvironment>().MenuItemFactory;
            itemfac.Eventbinder = binder;
            itemfac.Mainform = this; 
            IMenuFactory menuFac = new MenuFactory(this, itemfac);
            menuFac.SetMenuStrip();
            Thread newThrd = null;
            ThreadStart thrdStart = delegate { AddMenuControl(menuFac); };
            newThrd = new Thread(thrdStart);
            newThrd.IsBackground = true;
            newThrd.Start();
        }

        /// <summary>
        /// 菜单添加到窗体
        /// </summary>
        /// <param name="Fac"></param>
        protected virtual void AddMenuControl(IMenuFactory Fac)
        {
            //Debug.WriteLine("添加菜单 " + Thread.CurrentThread.ManagedThreadId.ToString());
            SetActive menu = new SetActive(Fac.AddMenuControl);
            while (!this.IsHandleCreated) ;
            this.Invoke(menu);
        }

        /// <summary>
        /// 开始的模块
        /// 这里需要重写
        /// </summary>
        protected virtual void BeginModule()
        {
            this.WatingProgram.ShowDialog();
            foreach (string dmname in LemonEnvironment.GetInstance().BeginModules)
            {
                IModule module = Lemon.ModuleLaunch(dmname);
                if (module == null)
                {
                    this.WatingProgram.CloseDialog();
                    Lemon.SendMsgError("默认启动模块创建失败");
                    return;
                }
                //SetActive moduleInitialize = new SetActive(module.Initialize);
                //this.Invoke(moduleInitialize);
            }
            //while (!this.IsHandleCreated) ; 
            //module.Initialize();  
            this.WatingProgram.CloseDialog();

            DelgLemonMainTread objSet = delegate (string str)
            {
                Thread t1 = new Thread(new ParameterizedThreadStart(Thread1));
                object[] pas1 = { 500 };
                t1.IsBackground = true;
                t1.Start(pas1);
            };
            this.Invoke(objSet, new object[] { "" });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Thread1(object data)
        {
            object[] whs = (object[])data;
            Thread.Sleep((int)whs[0]);
            ShowdownModule();
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void ShowdownModule()
        {
            foreach (string dmname in LemonEnvironment.GetInstance().ShowdownModules)
            {
                IModule module = Lemon.ModuleLaunch(dmname);
            }
        }

        #endregion
         
        #region IMainForm 成员
        /// <summary>
        /// 皮肤管理
        /// </summary>
        /// <returns></returns>
        public ISkin SkinManager()
        {
            if (this.skinmanager == null)
            {
                //this.skinmanager = new Lemonade.Daemon.Skins.Skin(this);
            }
            return this.skinmanager;
        }
        /// <summary>
        /// 
        /// </summary>
        public ILemonEnvironment Envir
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public IWaitingProgram WatingProgram
        {
            get
            {
                return this.waitingobj;
            }
        }
       
        #endregion

        #region ILoadSystem 成员
        /// <summary>
        /// 
        /// </summary>
        public void StartProcess()
        {
            SetActive();
            if (this.Prepose != null)
            {
                this.Prepose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Finish()
        {
            //Debug.WriteLine("mainComplate " + Thread.CurrentThread.ManagedThreadId.ToString());
            this.loadMsgerTable.Complete();
        }
        #endregion

        #region IObserver 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        public void Notify(object Content)
        {
            if (!((Form)this.loadMsgerTable).IsDisposed)
            {
                this.loadMsgerTable.Notify(Content);
            }
        }
        #endregion

        #region ISubject 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Obser"></param>
        public void Regidit(IObserver Obser)
        {
            this.loadMsgerTable = (ILoadDisplay)Obser;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Obser"></param>
        public void UnRegidit(IObserver Obser)
        {
            this.loadMsgerTable = null;
        }

        #endregion
 
    }
}