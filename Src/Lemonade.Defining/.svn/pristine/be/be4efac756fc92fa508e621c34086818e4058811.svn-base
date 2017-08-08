using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Running;

namespace Lemonade.Running
{
    /// <summary>
    /// 规则实现
    /// </summary>
    public class Rules:IRunningRules
    {
         
        //public virtual  void DomainControl()
        //{
        //    //随时加密的程序集
        //    AppDomain.CurrentDomain.GetAssemblies();
        //    throw new Exception("");
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Module"></param>
        /// <returns></returns>
        public virtual bool IsEnabledModule(Frame.IModule Module)
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public virtual bool IsVisibleMenuItem(Frame.Menu.IMenuItem Item)
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public virtual bool IsVisibleToolButton(Frame.Tools.IToolsItem Item)
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bar"></param>
        /// <returns></returns>
        public virtual bool IsVisibleToolbar(Frame.Tools.IToolsBar Bar)
        {
            return true;
        }
    }
}
