using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms; 
using System.IO;
using System.Reflection;
using Protein.Enzyme.Design;

namespace Lemonade.Frame.Module
{
    /// <summary>
    /// ģ�鴴���������
    /// </summary>
    public abstract class PtModuleHandler
    {
        /// <summary>
        /// 
        /// </summary>
        protected PtModuleHandler successor = null;

        /// <summary>
        /// ������һ���������
        /// </summary>
        /// <param name="Successor"></param>
        public virtual void SetSuccessor(PtModuleHandler Successor)
        { 
            this.successor = Successor;
        }

  
        /// <summary>
        /// ʵ����
        /// </summary>
        /// <param name="FullClassName"></param>
        /// <param name="AssemblyName"></param>
        /// <param name="MenuForm"></param>
        /// <returns></returns>
        public  virtual object Instance(string FullClassName, string AssemblyName, IMainForm MenuForm)
        {
            string assemblyfile = System.IO.Directory.GetCurrentDirectory() + "\\Module\\" 
                + AssemblyName + "\\" + AssemblyName + ".dll";
            ClassDrive ci = new ClassDrive();
            object obj = ci.Instance<object>(assemblyfile,FullClassName);
            if (obj != null)
            { 
                if (IsTargetInterface(obj))
                {
                    obj = SetCurrency((IModule)obj, MenuForm);
                    obj = SetModule((IModule)obj, MenuForm);
                }
                else if (this.successor != null)
                {
                    obj = this.successor.Instance(FullClassName,AssemblyName, MenuForm);
                }
                else
                {
                    obj = null;
                }
            }

            return obj;
        }

        /// <summary>
        /// ͨ������
        /// </summary>
        protected virtual IModule SetCurrency(IModule NewModule, IMainForm MenuForm)
        {
            //NewModule.Logger = MenuForm.SysConfig.SysLogger; 
            return NewModule;
        }

        /// <summary>
        /// ����ģ�����
        /// </summary> 
        protected abstract IModule SetModule(IModule NewModule,IMainForm MenuForm);


        /// <summary>
        /// �ж���ģ���ҵ��ӿ�����
        /// </summary>
        /// <param name="NewModule"></param>
        /// <returns></returns>
        protected abstract bool IsTargetInterface(object NewModule);
    }
}
