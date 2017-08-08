using System;
using System.Collections.Generic;
using System.Text;
using Lemonade.Frame; 
using Lemonade.Frame.Running; 
using System.Collections;
using Protein.Enzyme.Message;
using Lemonade.Frame.Module;
using Protein.Enzyme.Log;

namespace Lemonade.Frame.Running
{
    /// <summary>
    /// ����ʵ����
    /// </summary>
    public class LemonEnvironment : ILemonEnvironment
    {

        #region ����
        /// <summary>
        /// ���������
        /// </summary>
        public IMainForm CSFMain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private static LemonEnvironment envi = null; 
        
        /// <summary>
        /// 
        /// </summary>
        private List<IExtendApp> prelist = new List<IExtendApp>();
        
        #endregion


      /// <summary>
      /// 
      /// </summary>
        private  LemonEnvironment()
        {
            this.DatabaseConn = "";
            this.ModuleHandles = null;
            this.UseProxy = true;

        }
        /// <summary>
        /// ��ȡ������ʵ��
        /// </summary>
        /// <returns></returns>
        public static ILemonEnvironment GetInstance()
        {
            if (envi == null)
            {
                envi = new LemonEnvironment();
            }
            return envi;
        }


        /// <summary>
        /// �쳣�������Զ���ӿ�
        /// </summary>
        public ISystemExceptionDefine ExDefine { get; set; }
        /// <summary>
        /// ��չ�����б�
        /// </summary>
        public List<IExtendApp> PreposeApps
        {
            get
            {
                return this.prelist;
            }
            set
            {
                this.prelist = value;
            }
        }
       

        private  Protein.Enzyme.Message.MessageType msglevel;
        /// <summary>
        /// 
        /// </summary>
        public  MessageType SysMessageLevel
        {
            get
            {
                return msglevel;
            }
            set
            {
                this.msglevel = value;
            }
        }


 


        private List<string> beginModule = new List<string>(); 
        /// <summary>
        /// ��ʼģ������
        /// </summary>
        public List<string> BeginModules
        {
            get
            {
                return this.beginModule;
            }
            set
            {
                this.beginModule =value;
            }
        }

        private List<string> showdownModules = new List<string>();
        public List<string> ShowdownModules
        {
            get
            {
                return this.showdownModules;
            }
            set
            {
                this.showdownModules = value;
            }
        }
        


        private BLLAdapter config = new BLLAdapter();
        /// <summary>
        /// ���ù�����
        /// </summary>
        public BLLAdapter BllConfig
        {
            get
            {
                return this.config;
            }
            set
            {
                this.config=value;
            }
        }


         
        /// <summary>
        /// 
        /// </summary>
        public string DatabaseConn
        {
            get;
            set;
        } 
         
        /// <summary>
        /// �˵�����
        /// </summary>
        public Lemonade.Frame.Menu.IMenuItemFactory MenuItemFactory
        {
            get;
            set;
        }
         

        /// <summary>
        /// 
        /// </summary>
        public  PtModuleHandler  ModuleHandles
        {
            get;
            set;
        }


        /// <summary>
        /// ģ�������
        /// </summary>
        public IModuleManager ModuleManager
        {
            get;
            set;
        }

        /// <summary>
        /// �ڲ�����
        /// </summary>
        public IRunningRules Rules
        {
            get;
            set;
        }

        /// <summary>
        /// ������
        /// </summary>
        public Swapping.ISwapPool SwapPool
        {
            get;
            set;
        }
        /// <summary>
        /// ���������
        /// </summary>
        public UI.ILayoutManager UIManager { get; set; }
        /// <summary>
        /// �ػ���
        /// </summary>
        public Solon.INazgul Guardian { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        public IActionManager ActionsManager { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Tools.IToolsBarManager ToolsBarManager { get; set; }

        /// <summary>
        ///  ϵͳɨβ
        /// </summary>
        public IRoundOff SystemRoundOff { get; set; }

        /// <summary>
        /// �Ƿ�ʹ��AOP
        /// </summary>
        public bool UseProxy { get; set; }
    }
}
