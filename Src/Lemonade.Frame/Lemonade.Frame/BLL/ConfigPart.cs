using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Repository;
using Lemonade.Frame;
using Protein.Enzyme.Log; 
using System.Collections;
using Lemonade.Frame.Running;


namespace Lemonade.Frame.BLL
{
    /// <summary>
    /// �����ļ�������
    /// </summary>
    public abstract class ConfigPart : Lemonade.Frame.Design.ISubject
    {
        /// <summary>
        /// 
        /// </summary>
        private Hashtable obsertable = new Hashtable();
         
        /// <summary>
        /// 
        /// </summary>
        public ILemonEnvironment Envir
        {

            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        private XmlHelper configXml = null;
        /// <summary>
        /// 
        /// </summary>
        public XmlHelper ConfigXml
        {
            get { return configXml; }
            set { configXml = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileFullName"></param>
        /// <param name="EnvirObj"></param>
        public ConfigPart(string FileFullName, ILemonEnvironment EnvirObj)
        {
            this.configXml = new XmlHelper(FileFullName);
            this.Envir = EnvirObj;
            
        }
        /// <summary>
        /// ʵʩ����
        /// </summary>
        public abstract void Deploy();

        #region ISubject ��Ա
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        protected virtual void NotifyObsers(object Content)
        {
            foreach (Lemonade.Frame.Design.IObserver obser in this.obsertable.Values)
            {
                obser.Notify(Content);
            }
        }
        /// <summary>
        /// ע��
        /// </summary>
        /// <param name="Obser"></param>
        public void Regidit(Lemonade.Frame.Design.IObserver Obser)
        {
            this.obsertable.Add(Obser, Obser);
        }
        /// <summary>
        /// ж��
        /// </summary>
        /// <param name="Obser"></param>
        public void UnRegidit(Lemonade.Frame.Design.IObserver Obser)
        {
            this.obsertable.Remove(Obser);
        }

        #endregion
    }
}
