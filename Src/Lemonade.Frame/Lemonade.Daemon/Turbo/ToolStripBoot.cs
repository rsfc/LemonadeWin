using System;
using System.Collections.Generic;
using System.Text;
using Lemonade.Frame;
using System.Reflection;
using Lemonade.Frame.Running;
using Protein.Enzyme.Design;
namespace Lemonade.Daemon.Turbo
{
    /// <summary>
    /// 工具栏处理程序 未完成
    /// </summary>
    public  class ToolStripBoot
    {
        private IStartUp startup = null;

        /// <summary>
        /// 系统启动处理器
        /// </summary>
        public IStartUp Startup
        {
            get { return startup; }
            set { startup = value; }
        }

        public ToolStripBoot(IStartUp StartUpObj)
        {
            this.startup = StartUpObj;
            Configure();
        }
       

        protected virtual void Configure()
        {
            foreach(IExtendApp papp in this.startup.SysConfig.PreposeApps)
            {
                if (papp != null)
               {
                    //object newobj= CreateIns(papp);
                   papp.MainForm = (IMainForm)this.Startup.SystemFrm; 
                   SetPreEvent(papp);
                   SetSwap(papp);
               }
            }
        }

 


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Papp"></param>
        protected virtual void SetPreEvent(IExtendApp Papp)
        {
            Protein.Enzyme.Design.ClassDrive cd = new Protein.Enzyme.Design.ClassDrive();
            cd.MethodDelegate(this.startup.SystemFrm
            , "Prepose", Papp, "Launch");  
        }

        /// <summary>
        /// 设置模块功能
        /// </summary>
        protected virtual void SetSwap(IExtendApp Papp)
        {
            if (Papp.GetType().GetInterface("IModule") == null)
            {
                return;
            }
            //((IModule)Papp).AddSwapping();
            //if (Papp.GetType().GetInterface("IModuleMapForm")!=null)
            //{
            //    ((IMainForm)this.Startup.SystemFrm).MapFormSwapData.Add(Papp.GetType().BaseType.FullName,(IModule)Papp);
            //}
            //else if (Papp.GetType().GetInterface("IModuleSystem")!=null)
            //{
            //    ((IMainForm)this.Startup.SystemFrm).SystemSwapData.Add(Papp.GetType().BaseType.FullName, (IModule)Papp);
            //}
        }

   

    }
}
