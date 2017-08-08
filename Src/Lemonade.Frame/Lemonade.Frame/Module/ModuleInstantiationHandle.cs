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
    /// ģ��ʵ��������
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
        /// ģ��ʵ������
        /// </summary>
        /// <param name="MenuForm"></param>
        /// <param name="ModuleHandlerLink"></param>
        public ModuleInstantiationHandle(IMainForm MenuForm, PtModuleHandler ModuleHandlerLink)
        {
            this.menuform = MenuForm;
            this.moduleHandlerLink = ModuleHandlerLink;
        }

        /// <summary>  
        /// ����ʵ��
        /// </summary>  
        /// <param name="FullClassName">����</param>  
        /// <param name="AssemblyPath">��������</param>
        public  virtual void AssemblyInstance(string FullClassName, string AssemblyPath)
        {
            try
            {
                this.menuform.WatingProgram.ShowDialog();
                MessageObject mo = new MessageObject(MessageType.Debug);
                IModule module = Lemon.ModuleLaunch(FullClassName);  
                if (module != null)
                { 
                    mo.Message = "ģ�� " + FullClassName + " ʵ�� �����ɹ�"; 
                }
                else
                { 
                    mo.Message = "ģ�� " + FullClassName + " ʵ�� ����ʧ��";
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
        ///  �ж�ģ�����ʵ���Ƿ����
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
