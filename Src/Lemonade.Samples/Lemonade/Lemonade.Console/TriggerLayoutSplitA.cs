using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;

namespace Lemonade.Samples.Console
{
    /// <summary>
    /// 触发布局A
    /// </summary>
    public class TriggerLayoutSplitA : IModule
    {
        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {  
            //IModule GISIniti = CallModule("SSMTools.Console.GISIniti");
            //IModule MappingIniti = CallModule("SSMTools.Console.MappingIniti");
            //IModule FrmMap = CallModule("SSMTools.MapPanel.FrmMap");
            //IModule FrmFeatures = CallModule("SSMTools.FeaturesPanel.FrmFeatures");
            //IModule FrmLayerCtrl = CallModule("SSMTools.MapPanel.FrmLayerCtrl");
            //IModule FrmAttriPanel = CallModule("SSMTools.AttributesPanel.FrmAttriPanel");
            //System.Threading.Thread.Sleep(500);
            Lemon.SetLayout("框架布局分栏A");
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
            Lemon.SetLayout("框架布局分栏A");
        }
    }
}
