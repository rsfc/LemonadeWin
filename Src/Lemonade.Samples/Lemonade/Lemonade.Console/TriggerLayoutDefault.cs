using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;

namespace Lemonade.Samples.Console
{
    /// <summary>
    /// 触发默认布局
    /// </summary>
    public class TriggerLayoutDefault : IModule
    {
        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {   
            Lemon.SetLayout("");
        }
        

        public IMainForm MainForm
        {
            get;
            set;
        }

        public string ModuleAlias
        {
            get { return "用于触发默认布局"; }
        }

        public string ModuleName
        {
            get;
            set;
        }

        public void RunCache()
        {
            Lemon.SetLayout("");
        }
    }
}
