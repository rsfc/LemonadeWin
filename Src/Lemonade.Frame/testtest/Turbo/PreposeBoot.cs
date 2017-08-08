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
    /// 前置处理程序
    /// </summary>
    public  class PreposeBoot
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartUpObj"></param>
        public PreposeBoot(IStartUp StartUpObj)
        {
            this.startup = StartUpObj;
            Configure();
        }
       
        /// <summary>
        /// 
        /// </summary>
        protected virtual void Configure()
        {
            foreach(IExtendApp papp in this.startup.SysConfig.PreposeApps)
            {
                if (papp != null)
                {
                    papp.MainForm = (IMainForm)this.Startup.SystemFrm; 
                    //SetPreEvent(papp); 
                }
            }
        }

 
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="Papp"></param>
        //protected virtual void SetPreEvent(IExtendApp Papp)
        //{
        //    Protein.Enzyme.Design.ClassDrive cd = new Protein.Enzyme.Design.ClassDrive();
        //    cd.MethodDelegate(this.startup.SystemFrm
        //    , "Prepose", Papp, "Launch");  
        //}

        

   

    }
}
