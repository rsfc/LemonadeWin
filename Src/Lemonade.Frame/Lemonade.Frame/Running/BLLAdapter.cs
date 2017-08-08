using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace Lemonade.Frame.Running
{ 
    /// <summary>
    /// 业务层适配器
    /// </summary>
    public class BLLAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        protected Hashtable configobjs = new Hashtable();

         

        /// <summary>
        /// 获取配置对象
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
        /// 获取配置对象
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
        /// 添加配置对象到配置器中
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
