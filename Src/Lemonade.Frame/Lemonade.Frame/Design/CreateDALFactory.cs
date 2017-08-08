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
    /// ���ݲ�������ʵ��������,�������ڲ������ݿ�����Ĺ���ʵ��
    /// </summary>
    public sealed class CreateDALFactory
    {
        private static  IEntityFactory fac = null; 
        /// <summary>
        /// ��������ʵ��
        /// </summary>
        /// <returns></returns>
        public static IEntityFactory CreateFactory(string ManageFile, IDBInfo Dbh)
        {
            return CreateInstance(ManageFile,Dbh); 
        }

        /// <summary>
        /// ��������ʵ������
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
        /// ����ʵ�������ļ���������ʵ�� �ڴ˽����ݿ������ҵ���������
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
        /// ��ȡ����ʵ��
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
