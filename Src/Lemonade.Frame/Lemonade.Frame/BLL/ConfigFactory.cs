using System;
using System.Collections.Generic;
using System.Text; 
using Protein.Enzyme.Repository;
using Lemonade.Frame;
using Protein.Enzyme.Log;  
using Lemonade.Frame.Running;
using System.Diagnostics;
using System.IO;
namespace Lemonade.Frame.BLL
{
    /// <summary>
    /// ���ù���
    /// </summary>
    public class ConfigFactory : Lemonade.Frame.BLL.IConfigFactory
    {
        
        List<ConfigPart> partlist = new List<ConfigPart>();
        private ILemonEnvironment config = null;
        /// <summary>
        /// ���ö���
        /// </summary>
        public ILemonEnvironment Config
        {
            get { return config; }
            set { config = value; }
        }
        private string configfolder = "";
        /// <summary>
        /// �����ļ�ͳһ��·���ļ���
        /// </summary>
        public string Configfolder
        {
            get { return configfolder; }
            set { configfolder = value; }
        }

        Lemonade.Frame.Design.IObserver obser = null;

        /// <summary>
        /// �����ȡͬһ·�������ù���
        /// </summary>
        /// <param name="ConfigFolder"></param>
        /// <param name="ConfigObj"></param>
        ///  <param name="Obser"></param>
        public ConfigFactory(string ConfigFolder, ILemonEnvironment ConfigObj, Lemonade.Frame.Design.IObserver Obser)
        {
            this.configfolder = ConfigFolder;
            this.config = ConfigObj;
            this.obser = Obser;
            InsConfig();
        }

        /// <summary>
        /// ʵ����
        /// </summary>
        public  void InsConfig()
        {
            
            ConfigPart sett = new Setting(this.configfolder + "Setting.xml", this.config); 
            sett.Regidit(this.obser);
            this.partlist.Add(sett);
            //��չ���� ��ȡ
            //Debug.WriteLine(sett.Confi);
            //System.Windows.Forms.MessageBox.Show(this.configfolder + "System.xml");
            //ConfigPart sys = new PtSystem(this.configfolder + "System.xml", this.config);
            //sys.Regidit(this.obser);
            //this.partlist.Add(sys);
            //RedConfigParts();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void RedConfigParts()
        {
            XmlHelper configXml = new XmlHelper(this.configfolder + "Setting.xml");
            System.Xml.XmlNodeList aaa = configXml.GetNodeList("descendant::ConfigParts");
            foreach (System.Xml.XmlNode node in aaa)
            {
                if (node.Attributes != null)
                {
                    DirectoryInfo dr = new DirectoryInfo(this.configfolder);
                    string fullClassName = node.SelectSingleNode("descendant::FullClassName").InnerText;
                    string assemblyPath = dr.Parent.FullName + "\\Module\\" + node.SelectSingleNode("descendant::AssemblyPath").InnerText+"\\" + node.SelectSingleNode("descendant::AssemblyPath").InnerText + ".dll";
                    Protein.Enzyme.Design.ClassDrive ci = new Protein.Enzyme.Design.ClassDrive();
                    ConfigPart newpapp =ci.Instance<ConfigPart>(assemblyPath,fullClassName, new object[] { this.configfolder + node.Attributes[0].Value + ".xml", this.config }); 
                    if (newpapp == null)
                    { 
                        continue;
                    } 
                    this.partlist.Add(newpapp);
                }
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        public virtual void Processing()
        {
            foreach (ConfigPart cp in this.partlist)
            {
                cp.Deploy();
    
            }
        }

       

        
       
    }
}
