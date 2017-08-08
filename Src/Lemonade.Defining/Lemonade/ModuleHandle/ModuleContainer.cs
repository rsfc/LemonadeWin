using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using System.IO;
using Protein.Enzyme.Design;
using System.Threading;
using Lemonade.Frame.Module;

namespace Lemonade.ModuleHandle
{
    /// <summary>
    /// 模块容器 用于存放模块的实例
    /// </summary>
    public class ModuleContainer
    {
        /// <summary>
        /// 模块信息容器
        /// </summary>
        List<ModuleInfo> infoList = new List<ModuleInfo>();

        /// <summary>
        /// 实例存放容器
        /// </summary>
        List<IModule> moduleList = new List<IModule>();

        /// <summary>
        /// 当前框架加载的所有插件信息
        /// </summary>
        public List<ModuleInfo> ModuleInfos
        {
            get {
                List<ModuleInfo> result = this.infoList.ToList();
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual int RunningModuleCount
        {
            get
            {
                return this.moduleList.Count;
            }
        }
        /// <summary>
        /// 移除模块
        /// </summary>
        public virtual bool RemoveModule(IModule Module)
        {
            if (this.moduleList.Remove(Module))
            {
                Module = null;
                return true;
            }
            return false;

        }
        /// <summary>
        /// 
        /// </summary>
        public virtual List<string> RunningModuleFullClassName
        {
            get
            {
                List<string> sname=new List<string>();
                foreach(IModule m in moduleList)
                {
                    sname.Add(m.GetType().FullName);
                }
                return sname;
            }
        }
        /// <summary>
        /// 获取运行的模块别名
        /// </summary>
        public virtual List<string> getRunningModuleAlias
        {
            get
            {
                List<string> sname = new List<string>();
                foreach (IModule m in moduleList)
                {
                    sname.Add(m.ModuleAlias);
                }
                return sname;
            }
        }
        /// <summary>
        /// 模块容器
        /// </summary>
        public ModuleContainer()
        {
            SearchAllModuleAssembly();
            //this.cm = new ContainerMaintain(this);
            //EasyComeEasyGo();
            
        }
        ///// <summary>
        ///// 易得者亦易失
        ///// </summary>
        //protected void EasyComeEasyGo()
        //{

        //    Thread newThrd = null;
        //    ThreadStart thrdStart = delegate {   SearchAllModuleAssembly();};
        //    newThrd = new Thread(thrdStart);
        //    newThrd.IsBackground = true;
        //    newThrd.Start();   
        //}

        /// <summary>
        /// 获取运行的模块，如果没有返回null
        /// </summary>
        /// <returns></returns>
        public IModule GetRunningModule(string FullClassName)
        {
            IModule result = this.moduleList.Find(delegate(IModule m) { return (m.ModuleName == FullClassName); });
            return result;
        }
          
        /// <summary>
        /// 获取模块信息，如果不存在返回null
        /// </summary>
        /// <returns></returns>
        public ModuleInfo GetModuleInfo(string FullClassName)
        {
            ModuleInfo result = this.infoList.Find(delegate(ModuleInfo m) { return (m.FullClassName == FullClassName); });
            return result;
        }

        /// <summary>
        /// 登记模块信息，先查找是否已经存在模块信息，如果不存在则创建新的模块信息
        /// </summary>
        /// <param name="AssemblyPath"></param>
        /// <param name="FullClassName"></param>
        /// <returns></returns>
        public virtual ModuleInfo CheckinInfo(string AssemblyPath, string FullClassName)
        {
            ModuleInfo result = this.GetModuleInfo(FullClassName);
            if (result == null)
            {
                //这里需要验证是否存在
                result = new ModuleInfo();
                result.AssemblyPath = AssemblyPath;
                result.FullClassName = FullClassName;
                Lemon.SendMsgDebug("加载模块信息：" + FullClassName);
                this.infoList.Add(result);
            }
            return result;
        }

        /// <summary>
        /// 搜索所有模块程序集
        /// </summary>
        /// <returns></returns>
        public virtual void SearchAllModuleAssembly()
        {
            ClassDrive cd = new ClassDrive();
            this.infoList = new List<ModuleInfo>();
            DirectoryInfo rootDir = new DirectoryInfo(Lemon.GetModuleRootDirectory());
            DirectoryInfo[] childDir = rootDir.GetDirectories();
            foreach (DirectoryInfo dir in childDir)
            {
                FileInfo[] ff = dir.GetFiles("*.dll");
                foreach (FileInfo temp in ff)
                { 
                    Dictionary<string,Type> dic= cd.GetTypeListForInterface<IModule>(temp.FullName);
                    foreach (string s in dic.Keys)
                    {
                        this.CheckinInfo(temp.FullName, s);
                    }
                }   
            }
                  
        }

        
        /// <summary>
        /// 登记模块，创建新的模块实例
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public IModule CheckinModule(ModuleInfo Info, params object[] Parameters)
        {
            if (Info != null)
            {
                IModule result = Lemon.GetInstance<IModule>(Info.AssemblyPath, Info.FullClassName, Parameters);
                if (result != null)
                {
                    result.ModuleName = Info.FullClassName;
                    result.MainForm = Lemon.GetMainForm();
                    result.Initialize();
                    Lemon.SendMsgDebug("运行插件：" + Info.FullClassName);
                    this.moduleList.Add(result); 
                    return result;
                }
                else
                {
                    Lemon.SendMsgError("运行插件失败：" + Info.FullClassName);
                    return null;
                }
            }
            else
            {
                Lemon.SendMsgError("没找到插件信息,无法提示插件详细信息");
                return null;
            }
        }

        /// <summary>
        /// 移除模块实例登记记录
        /// </summary>
        /// <param name="Info"></param>
        public bool CheckoutModule(ModuleInfo Info)
        {
            IModule result = this.moduleList.Find(delegate(IModule m) { return (m.ModuleName == Info.FullClassName); });
            if (result != null)
            {
                return this.moduleList.Remove(result);
            }
            return false;
        }

    }
}
