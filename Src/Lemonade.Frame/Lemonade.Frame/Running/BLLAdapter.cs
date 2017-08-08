using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace Lemonade.Frame.Running
{ 
    /// <summary>
    /// ҵ���������
    /// </summary>
    public class BLLAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        protected Hashtable configobjs = new Hashtable();

         

        /// <summary>
        /// ��ȡ���ö���
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T GetConfig<T>()
        { 
            string tname = typeof(T).Name;
            foreach (object obj in this.configobjs.Values)
            {
                Type[] interfaces = obj.GetType().GetInterfaces();
                List<Type> intlist = new List<Type>(interfaces);
                Type findT = intlist.Find(delegate(Type tp) { return tp.Name == tname; });
                if (findT != null)
                {
                    return (T)obj;
                }
                else
                {
                    continue;
                }
            }
            return default(T);
        }

        /// <summary>
        /// ��ȡ���ö���
        /// </summary>
        /// <param name="ConfigName"></param>
        /// <returns></returns>
        public virtual object GetConfig(string ConfigName)
        {
            if (this.configobjs.ContainsKey(ConfigName))
            {
                return this.configobjs[ConfigName];
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// ������ö�����������
        /// </summary>
        public virtual bool AddConfig(object ConfigObj)
        {
            string key=ConfigObj.ToString();
            if (!this.configobjs.ContainsKey(key))
            {
                this.configobjs.Add(key, ConfigObj);
                return true;
            }
            else
            {
                return false;
            }

        }



    }
}
