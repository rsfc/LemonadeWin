using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms; 
using System.IO;
using System.Reflection;
using Lemonade.Frame.Module;
using Protein.Enzyme.Log;
using Protein.Enzyme.Message; 
namespace Lemonade.Frame.Module
{
    /// <summary>
    /// 模块实例化功能
    /// </summary>
    public class ModuleInstantiationHandle 
    {
        /// <summary>
        /// 
        /// </summary>
        protected IMainForm menuform = null;
        /// <summary>
        /// 
        /// </summary>
        private PtModuleHandler moduleHandlerLink = null;
        /// <summary>
        /// 模块实例功能
        /// </summary>
        /// <param name="MenuForm"></param>
        /// <param name="ModuleHandlerLink"></param>
        public ModuleInstantiationHandle(IMainForm MenuForm, PtModuleHandler ModuleHandlerLink)
        {
            this.menuform = MenuForm;
            this.moduleHandlerLink = ModuleHandlerLink;
        }

        /// <summary>  
        /// 程序集实例
        /// </summary>  
        /// <param name="FullClassName">类名</param>  
        /// <param name="AssemblyPath">程序集名称</param>
        public  virtual void AssemblyInstance(string FullClassName, string AssemblyPath)
        {
            try
            {
                this.menuform.WatingProgram.ShowDialog();
                MessageObject mo = new MessageObject(MessageType.Debug);
                IModule module = Lemon.ModuleLaunch(FullClassName);  
                if (module != null)
                { 
                    mo.Message = "模块 " + FullClassName + " 实例 启动成功"; 
                }
                else
                { 
                    mo.Message = "模块 " + FullClassName + " 实例 创建失败";
                }  
                this.menuform.WatingProgram.CloseDialog();
            }
            catch(Exception ex)
            {
                this.menuform.WatingProgram.CloseDialog();
                throw ex;
            }
        }
 

        /// <summary>
        ///  判断模块对象实例是否可用
        /// </summary>
        /// <param name="Module"></param>
        /// <returns></returns>
        protected virtual bool IsAvailableObject(IModule Module)
        {
            try
            {
                Form frm = (Form)Module;
                if (frm.IsDisposed)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch {
                return false;
            }
 
        }

    }
}
