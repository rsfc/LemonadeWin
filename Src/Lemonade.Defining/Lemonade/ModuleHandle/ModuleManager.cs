using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Module;
using Lemonade.Frame;
using System.Windows.Forms;
namespace Lemonade.ModuleHandle
{
    /// <summary>
    /// 模块管理器实现
    /// </summary>
    public class ModuleManager:IModuleManager
    {
        /// <summary>
        /// 容器
        /// </summary>
        ModuleContainer Container = null;

        ContainerMaintain maintain = null;


        /// <summary>
        /// 
        /// </summary>
        public ModuleManager()
        {
            this.Container = new ModuleContainer();
            this.maintain = new ContainerMaintain(this.Container);
        }
 
        /// <summary>
        ///  查找正在运行的模块
        /// </summary>
        /// <param name="FullClassName"></param>
        /// <returns></returns>
        public virtual Frame.IModule FindRunningModule(string FullClassName)
        {
            IModule result= this.Container.GetRunningModule(FullClassName);
            if (result != null)
            {
                if (Lemon.GetObjType(result).IsSubclassOf(typeof(Form)))
                {
                    if (((Form)result).IsDisposed)
                    {
                        this.Container.RemoveModule(result);
                        result = null;
                    }
                }
            }

            return result;
        }

    

        /// <summary>
        /// 运行模块
        /// </summary> 
        /// <param name="FullClassName"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public virtual Frame.IModule LaunchModule(string FullClassName, params object[] Parameters)
        {
            IModule m = null;
            ModuleInfo mi = this.Container.GetModuleInfo(FullClassName);
            if (mi == null)
            {
                Lemon.SendMsgError("没有找到模块信息：" + FullClassName);
                return null;
            }
            m = this.FindRunningModule(FullClassName);
            if (m != null)
            { 
                if (m.GetType().IsSubclassOf(typeof(Form)))
                {
                    if (!((Form)m).IsDisposed)
                    {
                        m.RunCache();
                        System.Threading.Thread.Sleep(100);
                    }
                    else
                    {
                        if (this.Container.CheckoutModule(mi))
                        {
                            //重新创建
                            m = this.Container.CheckinModule(mi, Parameters);
                        }
                        else
                        {
                            this.maintain.Compressor();
                        }
                    }
                }
                else
                { 
                    m.RunCache();
                    System.Threading.Thread.Sleep(100);
                }
            }
            else
            {
                m = this.Container.CheckinModule(mi, Parameters);
            } 
            return m;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int RunningModuleCount()
        {
            return this.Container.RunningModuleCount;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<string> RunningModuleFullClassName()
        {
            return this.Container.RunningModuleFullClassName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FullClassName"></param>
        /// <returns></returns>
        public virtual bool TurnOffModule(string FullClassName)
        {
            IModule m=this.Container.GetRunningModule(FullClassName);
            if(m!=null)
            {
                return this.Container.RemoveModule(m);
            }
            return false;
        }




        /// <summary>
        /// 所有的插件信息
        /// </summary>
        public List<ModuleInfo> ModuleInfos
        {
            get {
                return this.Container.ModuleInfos;
            }
        }

        public List<string> RunningModuleAlias
        {
            get
            {
                return this.Container.getRunningModuleAlias;
            }
        }
    }
}
