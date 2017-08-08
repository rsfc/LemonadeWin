using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;

namespace Lemonade.ModuleHandle
{
    /// <summary>
    /// 模块集合维持功能
    /// </summary>
    public class ContainerMaintain
    {
        /// <summary>
        /// 
        /// </summary>
        ModuleContainer mc = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MContainer"></param>
        public ContainerMaintain(ModuleContainer MContainer)
        {
            this.mc = MContainer;
        }

        /// <summary>
        /// 紧缩
        /// </summary>
        public virtual void Compressor()
        {
            //List<string> cpIndex=new List<int>();
            //foreach (string name in this.mc.RunningModuleFullClassName)
            //{
            //    IModule tmpm = this.mc.GetRunningModule(name);
            //    if (tmpm.GetType().IsSubclassOf(typeof(System.Windows.Forms.Form)))
            //    {
            //        if (((System.Windows.Forms.Form)tmpm).IsDisposed)
            //        {
            //            cpIndex.Add(
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 释放null对象
        /// </summary>
        protected  virtual   void CompressorNull()
        { 
        
        }
        /// <summary>
        /// 释放窗口对象已经释放的
        /// </summary>
        protected virtual  void CompressorDisposed()
        { 
            
        }
    }
}
