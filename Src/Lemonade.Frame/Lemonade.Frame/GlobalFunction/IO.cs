using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Design;
using Protein.Enzyme.Repository;
using System.IO;
using System.Xml.Serialization;
using System.Xml; 

namespace Lemonade.Frame
{
    /// <summary>
    /// 框架通用功能入口 
    /// </summary>
    public static partial class Lemon
    {

        #region IO
        /// <summary>
        /// 获取框架exe文件所在目录
        /// </summary>
        /// <returns></returns>
        public static string GetCSFRootDirectory()
        {
       
            string s = AppDomain.CurrentDomain.BaseDirectory; 
            return s;
        }
        /// <summary>
        /// 获取模块的根目录
        /// </summary>
        /// <returns></returns>
        public static string GetModuleRootDirectory()
        {  
            string s = AppDomain.CurrentDomain.BaseDirectory + @"Module\";
            
            return s;
        }

        /// <summary>
        /// 获取模块文件夹的绝对路径,dll文件所在文件夹路径
        /// </summary>
        /// <returns></returns>
        public static string GetModuleDirectory(string AssemblyName)
        {
            string s = GetModuleRootDirectory() + AssemblyName + @"\";
            return s;
        }

        /// <summary>
        /// 获取模块的绝对路径,dll文件的路径
        /// </summary>
        /// <returns></returns>
        public static string GetModulePath(string AssemblyName)
        {
            string s = GetModuleDirectory(AssemblyName) + AssemblyName + ".dll";
            return s;
        }
        /// <summary>
        /// 获取扩展配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetExtendConfig<T>()
        {
            return ProteinHandler.GetExtendConfig<T>();
        }
        /// <summary>
        /// 保存扩展配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Obj"></param>
        public static void SaveExtendConfig<T>(T Obj)
        {
            ProteinHandler.SetExtendConfig<T>(Obj);
        }

        /// <summary>  
        /// 反序列化，将参数指定的xml文件转换为实体类
        /// </summary>  
        /// <param name="TypeObj">类型</param>  
        /// <param name="XmlPath">文件路径</param>  
        /// <returns></returns>  
        public static object Deserialize(Type TypeObj, string XmlPath)
        {
            try
            {
                using (FileStream fs=File.OpenRead(XmlPath))
                {
                    XmlSerializer xmldes = new XmlSerializer(TypeObj);
                    object result=xmldes.Deserialize(fs);
                    fs.Close();
                    return result;
                }
                //using (StringReader sr = new StringReader(XmlPath))
                //{
                //    XmlSerializer xmldes = new XmlSerializer(TypeObj);
                //    return xmldes.Deserialize(sr);
                //}
            }
            catch(Exception ex)
            {
                Lemon.SendMsgError(ex);
                return null;
            }
        }

        ///// <summary>  
        ///// 序列化XML文件  
        ///// </summary>  
        ///// <param name="type">类型</param>  
        ///// <param name="obj">对象</param>  
        ///// <returns></returns>  
        //public static string Serializer(Type type, object obj)
        //{ 
        //    MemoryStream Stream = new MemoryStream(); 
        //    //创建序列化对象  
        //    XmlSerializer xml = new XmlSerializer(type); 
        //    try
        //    { 
        //        //序列化对象  
        //        xml.Serialize(Stream, obj); 
        //    } 
        //    catch (InvalidOperationException)
        //    { 
        //        throw; 
        //    } 
        //    Stream.Position = 0; 
        //    StreamReader sr = new StreamReader(Stream); 
        //    string str = sr.ReadToEnd(); 
        //    return str; 
        //} 

        /// <summary> 
        /// 对象序列化成 XML String  
        /// </summary> 
        public static void XmlSerialize<T>(string path, Encoding encoding, T obj)
        {

            string xmlString = string.Empty;
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                xmlSerializer.Serialize(ms, obj);
                xmlString = Encoding.UTF8.GetString(ms.ToArray());
            }
            System.IO.File.WriteAllText(path, xmlString, encoding);
            //return xmlString;

        }

        #endregion
    }

}