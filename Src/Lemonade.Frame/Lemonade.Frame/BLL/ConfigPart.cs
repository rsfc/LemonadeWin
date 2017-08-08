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
    /// 配置文件抽象类
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
        /// 实施配置
        /// </summary>
        public abstract void Deploy();

        #region ISubject 成员
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
        /// 注册
        /// </summary>
        /// <param name="Obser"></param>
        public void Regidit(Lemonade.Frame.Design.IObserver Obser)
        {
            this.obsertable.Add(Obser, Obser);
        }
        /// <summary>
        /// 卸载
        /// </summary>
        /// <param name="Obser"></param>
        public void UnRegidit(Lemonade.Frame.Design.IObserver Obser)
        {
            this.obsertable.Remove(Obser);
        }

        #endregion
    }
}
