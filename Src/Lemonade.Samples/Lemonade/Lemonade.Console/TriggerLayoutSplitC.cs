using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;

namespace Lemonade.Samples.Console
{
    /// <summary>
    /// 触发布局C
    /// </summary>
    public class TriggerLayoutSplitC : IModule
    {
        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {  
            //IModule GISIniti = CallModule("NewModuleMutual.FrmStyleTest1");
            //IModule MappingIniti = CallModule("NewModuleMutual.FrmStyleTest2");
            //IModule FrmMap = CallModule("NewModuleMutual.FrmStyleTest3");
            //IModule FrmFeatures = CallModule("NewModuleMutual.FrmStyleTest4"); 
            //System.Threading.Thread.Sleep(500);
            Lemon.SetLayout("框架布局分栏C");
        }
        /// <summary>
        /// 访问插件
        /// </summary>
        protected IModule CallModule(string ModuleFullClassName)
        {
            IModule m = Lemon.ModuleFind(ModuleFullClassName);
            if (m == null)
            {
                m = Lemon.ModuleLaunch(ModuleFullClassName);
            }
            return m;
        }


        public IMainForm MainForm
        {
            get;
            set;
        }

        public string ModuleAlias
        {
            get { return "用于触发分栏a布局的功能"; }
        }

        public string ModuleName
        {
            get;
            set;
        }

        public void RunCache()
        {
            Lemon.SetLayout("框架布局分栏C");
        }
    }
}
