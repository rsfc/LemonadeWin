using System;
using System.Collections.Generic;
using System.Text; 
using Lemonade.Frame;
using Lemonade.Frame.Running;
using Protein.Enzyme.Log; 
using System.Xml;
using System.Diagnostics;
using Protein.Enzyme.Design; 
using Protein.Enzyme.Message;
using System.Windows.Forms;
using Lemonade.Frame.Solon;


namespace Lemonade.Frame.BLL
{
    /// <summary>
    /// ������������
    /// </summary>
    public class Setting : ConfigPart
    {
         /// <summary>
        /// ϵͳ����
        /// </summary>
        public Setting(string FileFullName, ILemonEnvironment ConfigObj) 
            :base(FileFullName,ConfigObj)
        {

        } 
        
        /// <summary>
        /// ��ȡǰ����չ����
        /// </summary>
        /// <returns></returns>
        protected virtual List<IExtendApp> ReadXmlCreateApp()
        {
            List<IExtendApp> list = new List<IExtendApp>();
            System.Xml.XmlNodeList aaa = this.ConfigXml.GetNodeList("descendant::Prepose");
            foreach (System.Xml.XmlNode node in aaa)
            {
                if (node.Attributes != null)
                {   
                    string fullClassName = node.SelectSingleNode("descendant::FullClassName").InnerText; 
                    IExtendApp newpapp = CreateExtendAppIns(fullClassName);
                    if (newpapp == null || newpapp.IsHealth==false)
                    {
                        //ǰ������ʧ�� ϵͳ�Զ��ر�
                        Lemon.SendMsgError("ǰ�������������ʧ�ܣ�" + fullClassName+" ϵͳ�޷����С�");
                        Application.Exit();
                    }
                    else
                    { 
                        list.Add(newpapp); 
                    }
                }
            }
            return list;

        }
         
        /// <summary>
        /// ������Ϣ����
        /// </summary>
        protected virtual  MessageType ReadMsgLevel()
        {
            string level = this.ConfigXml.GetNodeValue("descendant::MessageLevel");
            Protein.Enzyme.Message.MessageType result
            = (Protein.Enzyme.Message.MessageType)Enum.Parse(typeof(Protein.Enzyme.Message.MessageType), level);
            return result;
        }

        /// <summary>
        /// ��ʼ����ģ��
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> ReadBeginModule()
        { 
            List<string> result = new List<string>();
            System.Xml.XmlNodeList aaa = this.ConfigXml.GetNodeList("descendant::Module/BeginModules"); 
            foreach (System.Xml.XmlNode node in aaa)
            { 
                string FullClassName = node.InnerText;
                if (!result.Contains(FullClassName))
                {
                    result.Add(FullClassName);
                }
            }
            return result; 
        }
        /// <summary>
        /// ����֮�����е�ģ��
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> ReadShowdownModules()
        {
            List<string> result = new List<string>();
            System.Xml.XmlNodeList aaa = this.ConfigXml.GetNodeList("descendant::Module/ShowdownModules");
            foreach (System.Xml.XmlNode node in aaa)
            {
                string FullClassName = node.InnerText;
                if (!result.Contains(FullClassName))
                {
                    result.Add(FullClassName);
                }
            }
            return result;
        }
        /// <summary>
        /// ��ʾ��Ϣ
        /// </summary>
        public override void Deploy()
        {
            this.NotifyObsers("���ؿ���쳣�Զ��������");
            this.Envir.ExDefine = LoadExceptionDefine();
            //
            this.NotifyObsers("���ؿ�ܿ�����");
            this.Envir.Rules = LoadRules(); 
            //
            this.NotifyObsers("���ز��������");
            this.Envir.ModuleManager = loadModuleManager();
            ChecksNull(this.Envir.ModuleManager, "ģ�����������ʧ�ܣ�����޷����С�");
            //
            this.NotifyObsers("���ض��󽻻���");
            this.Envir.SwapPool = LoadSwapPool();
            ChecksNull(this.Envir.SwapPool, "���󽻻���" + "����ʧ�ܣ�����޷����С�");
            //
            this.NotifyObsers("����ǰ����������");
            this.Envir.PreposeApps = ReadXmlCreateApp();
            //
            this.NotifyObsers("���ز˵�����");
            this.Envir.MenuItemFactory = LoadMenuItemFactory();
            ChecksNull(this.Envir.MenuItemFactory, "�˵�����" + "����ʧ�ܣ�����޷����С�");
            //
            this.NotifyObsers("solon");
            this.Envir.Guardian= LaunchSummon();
            ChecksNull(this.Envir.Guardian, "solon" + "����ʧ�ܣ�����޷����С�");
            //
            this.NotifyObsers("��������ģ������");
            this.Envir.BeginModules = ReadBeginModule();
            //
            this.NotifyObsers("�����������������ģ��");
            this.Envir.ShowdownModules = ReadShowdownModules();
            //
            this.NotifyObsers("���������-------��ʱȡ����δ���µ���ǰ״̬");
            //this.Envir.UIManager = LoadUI();
            //
            this.NotifyObsers("���ض���������");
            this.Envir.ActionsManager = LoadActionManager();
            //
            this.NotifyObsers("���ع�����������");
            this.Envir.ToolsBarManager  = LoadToolsBarManager();  
            //
            this.Envir.BllConfig.AddConfig(this.Envir);
        }


        /// <summary>
        /// �ӿ�ܸ�Ŀ¼�м��ض���������
        /// </summary>
        /// <returns></returns>
        protected virtual IActionManager LoadActionManager()
        {
            Lemonade.Frame.Running.IActionManager result = null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Running.IActionManager>(s);
            if (result != null)
            {
                result.LoadActionsContext();
            }
            return result;
        }


        /// <summary>
        /// �ӿ�ܵ�ģ��洢·�����Զ���ȡ�˵�������ʵ��
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.UI.ILayoutManager LoadUI()
        {
            Lemonade.Frame.UI.ILayoutManager result = null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.UI.ILayoutManager>(s);
            return result;
        }


        /// <summary>
        /// �ӿ�ܵ�ģ��洢·�����Զ���ȡ�˵�������ʵ��
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.Menu.IMenuItemFactory LoadMenuItemFactory()
        { 
            Lemonade.Frame.Menu.IMenuItemFactory result=null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Menu.IMenuItemFactory>(s);
            return result;
        }

        /// <summary>
        /// ������չ����ʵ��
        /// </summary> 
        /// <param name="FullClassName"></param>
        /// <returns></returns>
        protected virtual IExtendApp CreateExtendAppIns(string FullClassName)
        { 
            IExtendApp newobj = null;
            IModule m = Lemon.ModuleLaunch(FullClassName);
            if(m!=null)
            {
                if (m.GetType().GetInterface("IExtendApp")!=null)
                {
                    newobj = (IExtendApp)m;
                } 
            }
            return newobj;
        }

         

        /// <summary>
        /// �����ػ��߳�
        /// </summary>
        /// <returns></returns>
        protected virtual INazgul LaunchSummon()
        {
            ISummon summon = null;
            string s = Lemon.GetCSFRootDirectory();
            summon = Lemon.FindInstanceFromDirectory<ISummon>(s);
            if (summon != null)
            {
                INazgul nazgul = summon.RingtoWear();
                nazgul.LoadNazgulSkill();
                nazgul.UseAllSkill();
                return nazgul;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// �������ݽ�����
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.Swapping.ISwapPool LoadSwapPool()
        {
            Lemonade.Frame.Swapping.ISwapPool result = null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Swapping.ISwapPool>(s);
            return result;
        }


        /// <summary>
        /// ��ȡģ�����������
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.Module.IModuleManager loadModuleManager()
        {
            Lemonade.Frame.Module.IModuleManager result = null; 
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Module.IModuleManager>(s); 
            return result;  
        }
        /// <summary>
        /// ��ȡģ�����������
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.Running.ISystemExceptionDefine LoadExceptionDefine()
        {
            Lemonade.Frame.Running.ISystemExceptionDefine result = null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Running.ISystemExceptionDefine>(s);
            return result;
        }
        /// <summary>
        /// ��ȡģ�����������
        /// </summary>
        /// <returns></returns>
        protected virtual Lemonade.Frame.Running.IRunningRules LoadRules()
        {
            Lemonade.Frame.Running.IRunningRules result = null;
            string s=Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Lemonade.Frame.Running.IRunningRules>(s); 
            return result;
        }

        /// <summary>
        /// ���
        /// </summary>
        protected virtual void ChecksNull(object Obj,string Context)
        {
            if (Obj == null)
            {
                Lemon.SendMsgError(Context);
                Application.Exit();
            }
        }

 
        /// <summary>
        /// �ӿ�ܸ�Ŀ¼�м��ع�����������
        /// </summary>
        /// <returns></returns>
        protected virtual Tools.IToolsBarManager LoadToolsBarManager()
        {
            Tools.IToolsBarManager result = null;
            string s = Lemon.GetCSFRootDirectory();
            result = Lemon.FindInstanceFromDirectory<Tools.IToolsBarManager>(s);
            if (result != null)
            {
                result.LoadToolsBar();
            }
            return result;
        }

        ///// <summary>
        ///// �ӿ�ܸ�Ŀ¼�м��ع�����������
        ///// </summary>
        ///// <returns></returns>
        //protected virtual Tools.IToolsBarManager LoadToolsBarManager()
        //{
        //    Tools.IToolsBarManager result = null;
        //    string s = Lemon.GetCSFRootDirectory();
        //    result = Lemon.FindInstanceFromDirectory<Tools.IToolsBarManager>(s);
        //    if (result != null)
        //    {
        //        result.LoadToolsBar();
        //    }
        //    return result;
        //}
       
    }
}
