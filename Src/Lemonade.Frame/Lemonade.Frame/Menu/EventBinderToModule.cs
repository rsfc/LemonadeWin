using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Lemonade.Frame.Module;
using Protein.Enzyme.Log;
using Protein.Enzyme.Message;
using DevExpress.XtraBars.Ribbon;

namespace Lemonade.Frame.Menu
{
    /// <summary>
    /// 事件绑定到模块
    /// </summary>
    public class EventBinderToModule:IEventBinder
    {
        /// <summary>
        /// 
        /// </summary>
        protected IMainForm menuform = null;
        /// <summary>
        /// 事件绑定到模块
        /// </summary>
        /// <param name="MenuForm"></param> 
        public EventBinderToModule(IMainForm MenuForm)
        {
            this.menuform = MenuForm; 
        }

        #region IEventBinder 成员
        /// <summary>
        /// 绑定事件
        /// </summary>
        /// <param name="Item"></param>
        public virtual void Binder(PtMenuItem Item)
        {
            if (!Item.IsChild)
            {
                Item.ItemClick += new BackstageViewItemEventHandler(MenuItem_Click); 
            }
        }

    
        #endregion

        
        /// <summary>  
        /// 菜单单击事件  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        protected virtual void MenuItem_Click(object sender, EventArgs e)
        {
            string classname = ((IPtMenuItem)sender).FullClassName.ToString();
            ModuleInstantiationHandle mih = new ModuleInstantiationHandle(this.menuform, GetModulHandlerLink());
            //string assemblyfile = System.IO.Directory.GetCurrentDirectory() + "\\Module\\"
                    //+ ((IPtMenuItem)sender).AssemblyPath + "\\" + ((IPtMenuItem)sender).AssemblyPath + ".dll";
            mih.AssemblyInstance(classname, ((IPtMenuItem)sender).AssemblyPath.ToString());
        }


        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        protected virtual PtModuleHandler GetModulHandlerLink()
        {

            return this.menuform.Envir.ModuleHandles;
        }
         
 
    }
}
