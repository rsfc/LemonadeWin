using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Design;
using Lemonade.Frame.Running;
using Lemonade.Frame.Module;
using System.IO;
using Protein.Enzyme.Message;
using Protein.Enzyme.Repository;

namespace Lemonade.Frame
{
    #region 定义框架委托

    /// <summary>
    /// 动作执行者回调
    /// <param name="sender">定义该动作的对象，</param>
    /// </summary>
    public delegate void ActionPerformer(object sender);
    
     
    #endregion
    /// <summary>
    /// 框架通用功能入口 
    /// </summary>
    public static partial class Lemon
    { 
        #region 设计功能函数集合

        /// <summary>
        /// 设置是否使用aop
        /// </summary>
        /// <param name="Use"></param>
        public static void SetEnviUseProxy(bool Use)
        {
            LemonEnvironment.GetInstance().UseProxy = Use;
        }

        /// <summary>
        /// 创建并获取指定泛型类型的对象的动态代理实例，该实例在切向捕捉对象控制范围内
        /// </summary>
        /// <param name="FullClassName"></param> 
        /// <param name="AssemblyPath"></param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public static T GetInstance<T>(string AssemblyPath, string FullClassName, params object[] Parameters)
        {
            T result = default(T);
            ClassDrive cdiv = new ClassDrive();
            try
            {
                if (LemonEnvironment.GetInstance().UseProxy)
                {
                    result = cdiv.ProxyInstance<T>(FullClassName, AssemblyPath, Parameters);
                }
                else
                {
                    result = cdiv.Instance<T>(AssemblyPath, FullClassName, Parameters);
                }
            }
            catch
            {
                string str = "创建对象实例失败。 AssemblyPath：" + AssemblyPath + " FullClassName:" + FullClassName;
                MessageObject newmsg = new MessageObject(MessageType.Error);
                newmsg.Message = str;
                MessageFactory.GetMegBus().Send(newmsg);
            }
            return result;
        }

        /// <summary>
        /// 创建并获取指定泛型类型的对象的动态代理实例，使该实例在切向捕捉对象控制范围内
        /// </summary>
        /// <param name="InitType"></param>  
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public static T GetInstance<T>(Type InitType, params object[] Parameters)
        {
            T result = default(T);
            ClassDrive cdiv = new ClassDrive();
            try
            {
                if (LemonEnvironment.GetInstance().UseProxy)
                {
                    result = cdiv.ProxyInstance<T>(InitType, Parameters);
                }
                else
                {
                    result = cdiv.Instance<T>(InitType, Parameters);
                }
            }
            catch {
                string str = "创建对象实例失败。 " + InitType.ToString();
                MessageObject newmsg = new MessageObject(MessageType.Error);
                newmsg.Message = str;
                MessageFactory.GetMegBus().Send(newmsg);
            }
            return result;
        }

       
        /// <summary>
        /// 在指定的文件夹中查找指定类型的对象并且实例化，只实例化匹配的第一个，实例类型必须有无参数构造函数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Directory"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public static T FindInstanceFromDirectory<T>(string Directory, params object[] Parameters)
        {
            T result = default(T);
            ClassDrive cd = new ClassDrive();
            DirectoryInfo dir = new DirectoryInfo(Directory);
            FileInfo[] ff = dir.GetFiles("*.dll");
            foreach (FileInfo temp in ff)
            {
                Dictionary<string, Type> dic =   cd.GetTypeListForInterface<T>(temp.FullName); 
                foreach (string s in dic.Keys)
                {
                    result=Lemon.GetInstance<T>(dic[s], Parameters);
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// 在指定的文件夹中查找指定类型的对象并且实例化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="IsPar">是否带参数构造</param>
        /// <param name="Directory"></param>
        /// <param name="ParFullClassName"></param> 
        /// <param name="ParValue"></param>
        /// <returns></returns>
        public static List<T> FindInstanceFromDirectory<T>(string Directory, bool IsPar,List<string> ParFullClassName=null,List<object[]> ParValue=null)
        {
            List<T> result = new List<T>();
            ClassDrive cd = new ClassDrive();
            DirectoryInfo dir = new DirectoryInfo(Directory);
            FileInfo[] ff = dir.GetFiles("*.dll");
            foreach (FileInfo temp in ff)
            {
                Dictionary<string, Type> dic = cd.GetTypeListForInterface<T>(temp.FullName);
                foreach (string s in dic.Keys)
                {
                    object[] tmpPar=null;
                    if (IsPar)
                    {
                        if (ParFullClassName != null && ParValue != null)
                        {
                            int index = ParFullClassName.IndexOf(s);
                            if (index > -1)
                            {
                                tmpPar = ParValue[index];
                            }
                        }
                    }
                    T tmpobj = default(T);
                    if (tmpPar != null)
                    {
                        tmpobj = Lemon.GetInstance<T>(dic[s], tmpPar);
                    }
                    else {
                        tmpobj = Lemon.GetInstance<T>(dic[s]);
                    }
                    if (tmpobj != null)
                    {
                        result.Add(tmpobj);
                    }
                        
                }
            }
            return result;
        }

        /// <summary>
        /// 获取对象的类全名
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static string GetFullClassName(object Obj)
        {
            Type t = GetObjType(Obj); 
            return t.FullName;
        }

        /// <summary>
        /// 获取对象的类型
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static Type GetObjType(object Obj)
        {
            return Obj.GetObjTypeFromProxy(); 
        }
     

        #endregion
    }

}