using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Lemonade.Frame.Design
{
    /// <summary>
    /// �۲��߻���
    /// </summary>
    public  abstract  class SubjectHandle:ISubject
    {
        Hashtable obsTable = new Hashtable();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        protected virtual void NotifyObsers(object Content)
        {
            foreach (Lemonade.Frame.Design.IObserver obser in this.obsTable.Values)
            {
                obser.Notify(Content);
            }
        }

        #region ISubject ��Ա
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Obser"></param>
        public void Regidit(IObserver Obser)
        {
            this.obsTable.Add(Obser, Obser);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Obser"></param>
        public void UnRegidit(IObserver Obser)
        {
            this.obsTable.Remove(Obser);
        }

        #endregion
    }
}
