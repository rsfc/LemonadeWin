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
    /// 配置实体类
    /// </summary>
    public class LemonEnvironment : ILemonEnvironment
    {

        #region 变量
        /// <summary>
        /// 框架主窗体
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
        /// 获取配置类实例
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
        /// 异常可用性自定义接口
        /// </summary>
        public ISystemExceptionDefine ExDefine { get; set; }
        /// <summary>
        /// 扩展程序列表
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
        /// 开始模块名称
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
        /// 配置管理器
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
        /// 菜单工厂
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
        /// 模块管理器
        /// </summary>
        public IModuleManager ModuleManager
        {
            get;
            set;
        }

        /// <summary>
        /// 内部规则
        /// </summary>
        public IRunningRules Rules
        {
            get;
            set;
        }

        /// <summary>
        /// 交换池
        /// </summary>
        public Swapping.ISwapPool SwapPool
        {
            get;
            set;
        }
        /// <summary>
        /// 界面管理器
        /// </summary>
        public UI.ILayoutManager UIManager { get; set; }
        /// <summary>
        /// 守护者
        /// </summary>
        public Solon.INazgul Guardian { get; set; }
        /// <summary>
        /// 动作管理器
        /// </summary>
        public IActionManager ActionsManager { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Tools.IToolsBarManager ToolsBarManager { get; set; }

        /// <summary>
        ///  系统扫尾
        /// </summary>
        public IRoundOff SystemRoundOff { get; set; }

        /// <summary>
        /// 是否使用AOP
        /// </summary>
        public bool UseProxy { get; set; }
    }
}
