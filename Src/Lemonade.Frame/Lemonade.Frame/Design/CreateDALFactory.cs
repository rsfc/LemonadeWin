using System;
using System.Collections.Generic;
using System.Text; 
using System.Reflection;
using System.IO;
using Protein.Enzyme.Repository;
using Protein.Enzyme.DAL;
namespace Lemonade.Frame.Design
{
    /// <summary>
    /// 数据操作工厂实例创建类,创建用于产生数据库操作的工厂实例
    /// </summary>
    public sealed class CreateDALFactory
    {
        private static  IEntityFactory fac = null; 
        /// <summary>
        /// 创建工厂实例
        /// </summary>
        /// <returns></returns>
        public static IEntityFactory CreateFactory(string ManageFile, IDBInfo Dbh)
        {
            return CreateInstance(ManageFile,Dbh); 
        }

        /// <summary>
        /// 创建工厂实例对象
        /// </summary> 
        /// <returns></returns>
        public  static  IEntityFactory CreateInstance(string ManageFile,  IDBInfo Dbh)
        {
            string xmlpath = ManageFile; 
            XmlHelper xmh = new XmlHelper(xmlpath);
            string AssemblyPath =  xmh.GetNodeValue("descendant::AssemblyPath") + ".dll";
            if (File.Exists(AssemblyPath))
            {
                Assembly ably = Assembly.LoadFile(AssemblyPath);
                System.Type[] types = ably.GetTypes();
                foreach (System.Type type in types)
                {
                    if (type.GetInterface("IEntityFactory") != null)
                    {
                        return ( IEntityFactory)Activator.CreateInstance(type, Dbh);

                    }
                }
            }
            else
            { 
                
            }
            return null;
        }

        /// <summary>
        /// 根据实体配置文件创建工厂实例 在此将数据库操作和业务操作解耦
        /// </summary>
        /// <returns></returns>
        public  IEntityFactory GetInstance(IDBInfo Dbh)
        {
            string xmlpath = System.Environment.CurrentDirectory.ToString() + "\\EntityFactory.xml"; 
            if (fac == null)
            {
                fac = CreateFactory(xmlpath,Dbh);
            }
            
            return fac;
             
        }

        /// <summary>
        /// 获取工厂实例
        /// </summary>
        /// <returns></returns>
        public IEntityFactory GetInstance(string  ManageFile, IDBInfo Dbh)
        {
            if (fac == null)
            {
                fac = CreateFactory(ManageFile,Dbh);
            }

            return fac;

        }
    }
}
