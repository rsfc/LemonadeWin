using System;
using System.Collections.Generic;
using System.Text; 
using Lemonade.Frame;
using Lemonade.Frame.Running;
using Protein.Enzyme.Log; 
using System.Xml;
using System.Diagnostics;
using Protein.Enzyme.Design; 
using Protein.Enzyme.Message;
using System.Windows.Forms;
using Lemonade.Frame.Solon;


namespace Lemonade.Frame.BLL
{
    /// <summary>
    /// 环境变量配置
    /// </summary>
    public class Setting : ConfigPart
    {
         /// <summary>
        /// 系统配置
        /// </summary>
        public Setting(string FileFullName, ILemonEnvironment ConfigObj) 
            :base(FileFullName,ConfigObj)
        {

        } 
        
        /// <summary>
        /// 读取前置扩展程序
        /// </summary>
        /// <returns></returns>
        protected virtual List<IExtendApp> ReadXmlCreateApp()
        {
            List<IExtendApp> list = new List<IExtendApp>();
            System.Xml.XmlNodeList aaa = this.ConfigXml.GetNodeList("descendant::Prepose");
            foreach (System.Xml.XmlNode node in aaa)
            {
                if (node.Attributes != null)
                {   
                    string fullClassName = node.SelectSingleNode("descendant::FullClassName").InnerText; 
                    IExtendApp newpapp = CreateExtendAppIns(fullClassName);
                    if (newpapp == null || newpapp.IsHealth==false)
                    {
                        //前置启动失败 系统自动关闭
                        Lemon.SendMsgError("前置启动程序加载失败：" + fullClassName+" 系统无法运行。");
                        Application.Exit();
                    }
                    else
                    { 
                        list.Add(newpapp); 
                    }
                }
            }
            return list;

        }
         
        /// <summary>
        /// 设置消息级别
        /// </summary>
        protected virtual  MessageType ReadMsgLevel()
        {
            string level = this.ConfigXml.GetNodeValue("descendant::MessageLevel");
            Protein.Enzyme.Message.MessageType result
            = (Protein.Enzyme.Message.MessageType)Enum.Parse(typeof(Protein.Enzyme.Message.MessageType), level);
            return result;
        }

        /// <summary>
        /// 开始启动模块
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> ReadBeginModule()
        { 
            List<string> result = new List<string>();
            System.Xml.XmlNodeList aaa = this.ConfigXml.GetNodeList("descendant::Module/BeginModules"); 
            foreach (System.Xml.XmlNode node in aaa)
            { 
                string FullClassName = node.InnerText;
                if (!result.Contains(FullClassName))
                {
                    result.Add(FullClassName);
                }
            }
            return result; 
        }
        /// <summary>
        /// 启动之后运行的模块
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> ReadShowdownModules()
        {
            List<string> result = new List<string>();
            System.Xml.XmlNodeList aaa = this.ConfigXml.GetNodeList("descendant::Module/ShowdownModules");
            foreach (System.Xml.XmlNode node in aaa)
            {
                string FullClassName = node.InnerText;
                if (!result.Contains(FullClassName))
                {
                    result.Add(FullClassName);
                }
            }
            return result;
        }
        /// <summary>
        /// 显示消息
        /// </summary>
        public override void Deploy()
        {
            this.NotifyObsers("加载框架异常自定义可用性");
            this.Envir.ExDefine = LoadExceptionDefine();
            //
            this.NotifyObsers("加载框架控制器");
            this.Envir.Rules = LoadRules(); 
            //
            this.NotifyObsers("加载插件管理器");
            this.Envir.ModuleManager = loadModuleManager();
            ChecksNull(this.Envir.ModuleManager, "模块管理器加载失败，框架无法运行。");
            //
            this.NotifyObsers("加载对象交换池");
            this.Envir.SwapPool = LoadSwapPool();
            ChecksNull(this.Envir.SwapPool, "对象交换池" + "加载失败，框架无法运行。");
            //
            this.NotifyObsers("加载前置启动程序");
            this.Envir.PreposeApps = ReadXmlCreateApp();
            //
            this.NotifyObsers("加载菜单工厂");
            this.Envir.MenuItemFactory = LoadMenuItemFactory();
            ChecksNull(this.Envir.MenuItemFactory, "菜单工厂" + "加载失败，框架无法运行。");
            //
            this.NotifyObsers("solon");
            this.Envir.Guardian= LaunchSummon();
            ChecksNull(this.Envir.Guardian, "solon" + "加载失败，框架无法运行。");
            //
            this.NotifyObsers("加载启动模块配置");
            this.Envir.BeginModules = ReadBeginModule();
            //
            this.NotifyObsers("加载完成启动后运行模块");
            this.Envir.ShowdownModules = ReadShowdownModules();
            //
            this.NotifyObsers("界面风格设计-------暂时取消，未更新到当前状态");
            //this.Envir.UIManager = LoadUI();
            //
            this.NotifyObsers("加载动作控制器");
            this.Envir.ActionsManager = LoadActionManager();
            //
            this.NotifyObsers("加载工具栏控制器");
            this.Envir.ToolsBarManager  = LoadToolsBarManager();  
            //
            this.Envir.BllConfig.AddConfig(this.Envir);
        }


        /// <summary>
        /// 从框架根目录中加载动作管理器
        /// </summary>
        /// <returns></returns>
        protected virtual IActionManager LoadActionManager()
        {
            Lemonade.Frame.Running.IActionManager result = null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Running.IActionManager>(s);
            if (result != null)
            {
                result.LoadActionsContext();
            }
            return result;
        }


        /// <summary>
        /// 从框架的模块存储路径中自动获取菜单工厂的实例
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.UI.ILayoutManager LoadUI()
        {
            Lemonade.Frame.UI.ILayoutManager result = null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.UI.ILayoutManager>(s);
            return result;
        }


        /// <summary>
        /// 从框架的模块存储路径中自动获取菜单工厂的实例
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.Menu.IMenuItemFactory LoadMenuItemFactory()
        { 
            Lemonade.Frame.Menu.IMenuItemFactory result=null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Menu.IMenuItemFactory>(s);
            return result;
        }

        /// <summary>
        /// 创建扩展程序实例
        /// </summary> 
        /// <param name="FullClassName"></param>
        /// <returns></returns>
        protected virtual IExtendApp CreateExtendAppIns(string FullClassName)
        { 
            IExtendApp newobj = null;
            IModule m = Lemon.ModuleLaunch(FullClassName);
            if(m!=null)
            {
                if (m.GetType().GetInterface("IExtendApp")!=null)
                {
                    newobj = (IExtendApp)m;
                } 
            }
            return newobj;
        }

         

        /// <summary>
        /// 启动守护线程
        /// </summary>
        /// <returns></returns>
        protected virtual INazgul LaunchSummon()
        {
            ISummon summon = null;
            string s = Lemon.GetCSFRootDirectory();
            summon = Lemon.FindInstanceFromDirectory<ISummon>(s);
            if (summon != null)
            {
                INazgul nazgul = summon.RingtoWear();
                nazgul.LoadNazgulSkill();
                nazgul.UseAllSkill();
                return nazgul;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 加载数据交换池
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.Swapping.ISwapPool LoadSwapPool()
        {
            Lemonade.Frame.Swapping.ISwapPool result = null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Swapping.ISwapPool>(s);
            return result;
        }


        /// <summary>
        /// 读取模块管理器配置
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.Module.IModuleManager loadModuleManager()
        {
            Lemonade.Frame.Module.IModuleManager result = null; 
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Module.IModuleManager>(s); 
            return result;  
        }
        /// <summary>
        /// 读取模块管理器配置
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.Running.ISystemExceptionDefine LoadExceptionDefine()
        {
            Lemonade.Frame.Running.ISystemExceptionDefine result = null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Running.ISystemExceptionDefine>(s);
            return result;
        }
        /// <summary>
        /// 读取模块管理器配置
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.Running.IRunningRules LoadRules()
        {
            Lemonade.Frame.Running.IRunningRules result = null;
            string s=Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Running.IRunningRules>(s); 
            return result;
        }

        /// <summary>
        /// 检查
        /// </summary>
        protected virtual void ChecksNull(object Obj,string Context)
        {
            if (Obj == null)
            {
                Lemon.SendMsgError(Context);
                Application.Exit();
            }
        }

 
        /// <summary>
        /// 从框架根目录中加载工具栏管理器
        /// </summary>
        /// <returns></returns>
        protected virtual Tools.IToolsBarManager LoadToolsBarManager()
        {
            Tools.IToolsBarManager result = null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Tools.IToolsBarManager>(s);
            if (result != null)
            {
                result.LoadToolsBar();
            }
            return result;
        }

        ///// <summary>
        ///// 从框架根目录中加载工具栏管理器
        ///// </summary>
        ///// <returns></returns>
        //protected virtual Tools.IToolsBarManager LoadToolsBarManager()
        //{
        //    Tools.IToolsBarManager result = null;
        //    string s = Lemon.GetCSFRootDirectory();
        //    result = Lemon.FindInstanceFromDirectory<Tools.IToolsBarManager>(s);
        //    if (result != null)
        //    {
        //        result.LoadToolsBar();
        //    }
        //    return result;
        //}
       
    }
}
