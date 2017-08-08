///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap Objects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap Objects .NET 示范程序说明--------------------------
//
//1、范例简介：示范打开、创建、另存、删除文件型和数据库型工作空间
//2、示例数据：无        
//3、关键类型/成员: 
//      WorkspaceConnectionInfo 类型
//      Workspace.Open 方法
//      Workspace.Create 方法
//      Workspace.SavaAs 方法
//      Workspace.DeleteWorkspace 方法
//
//4、使用步骤：
//   (1)打开或创建工作空间，查看工作空间属性。
//   (2)另存当前工作空间。
//   (3)删除当前工作空间。
//---------------------------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SuperMap.Data;
using Lemonade.Frame;


namespace Lemonade.Samples.SM.WorkspaceManage
{
    public class SampleRun
    {
        private Workspace m_workspace;
        private WorkspaceConnectionInfo m_connectionInfo;

        public delegate void CheckEventHandler(Boolean isInitialize);
        public event CheckEventHandler OnCheck;


        /// <summary>
        /// 根据workspace构造 SampleRun对象
        /// </summary>
        public SampleRun(Workspace workspace)
        {
            try
            {
                m_workspace = workspace;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 打开工作空间
        /// </summary>
        /// <param name="connectionInfo">工作空间连接信息</param>
        /// <returns>操作结果描述信息</returns>
        public String Open(WorkspaceConnectionInfo connectionInfo)
        {
            String result = String.Empty;

            try
            {
                m_workspace.Close();
                m_connectionInfo = connectionInfo;

                Boolean isSucceed = m_workspace.Open(m_connectionInfo);

                if (isSucceed)
                {

                    Lemon.SwapAppend(m_workspace, true);
                    result = System.Environment.NewLine;
                    result += "打开工作空间成功！";
                    result += System.Environment.NewLine;
                    // 获取成功后的工作空间信息
                    result += GetWorkspaceInfomation();
                    //触发事件，通知界面做相应的处理，false则另存和删除功能可用，true为不可用
                    OnCheck(false);
                }
                else
                {
                    result = System.Environment.NewLine;
                    result += "打开工作空间失败!";
                    result += System.Environment.NewLine;
                    //触发事件，通知界面做相应的处理，false则另存和删除功能可用，true为不可用
                    OnCheck(true);
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 创建工作空间
        /// </summary>
        /// <param name="connectionInfo">工作空间连接信息</param>
        /// <returns>操作结果描述信息</returns>
        public String Create(WorkspaceConnectionInfo connectionInfo)
        {
            String result = String.Empty;
            try
            {
                m_workspace.Close();
                m_connectionInfo = connectionInfo;

                Boolean isSucceed = m_workspace.Create(m_connectionInfo);


                if (isSucceed)
                {
                    result = System.Environment.NewLine;
                    result += "创建工作空间成功！";
                    result += System.Environment.NewLine;
                    result += GetWorkspaceInfomation();
                    OnCheck(false);
                }
                else
                {
                    result = System.Environment.NewLine;
                    result += "创建工作空间失败!";
                    result += System.Environment.NewLine;
                    OnCheck(true);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 另存工作空间
        /// </summary>
        /// <param name="connectionInfo">工作空间连接信息</param>
        /// <returns>操作结果描述信息</returns>
        public String SaveAs(WorkspaceConnectionInfo connectionInfo)
        {
            String result = String.Empty;
            try
            {
                m_connectionInfo = connectionInfo;

                Boolean isSucceed = m_workspace.SaveAs(m_connectionInfo);


                if (isSucceed)
                {
                    result = System.Environment.NewLine;
                    result += "另存工作空间成功！";
                    result += System.Environment.NewLine;
                    result += GetWorkspaceInfomation();
                    OnCheck(false);
                }
                else
                {
                    result = System.Environment.NewLine;
                    result += "另存工作空间失败!";
                    result += System.Environment.NewLine;
                    OnCheck(false);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除工作空间
        /// </summary>
        /// <returns>操作结果描述信息</returns>
        public String Delete()
        {
            String result = String.Empty;

            try
            {
                Boolean isSucceed = Workspace.DeleteWorkspace(m_connectionInfo);

                if (isSucceed)
                {
                    result = System.Environment.NewLine;
                    result += "删除工作空间成功！";
                    result += System.Environment.NewLine;
                    result += GetWorkspaceInfomation();
                    OnCheck(true);
                }
                else
                {
                    result = System.Environment.NewLine;
                    result += "删除工作空间失败!";
                    result += System.Environment.NewLine;
                    OnCheck(false);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 获取当前的工作空间信息
        /// </summary>
        /// <returns>工作空间信息</returns>
        public String GetWorkspaceInfomation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                stringBuilder.Append("工作空间基本信息：");
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("服务器名或文件路径：");
                stringBuilder.Append(m_connectionInfo.Server);
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("数据库名：");
                stringBuilder.Append(m_connectionInfo.Database);
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("用户名：");
                stringBuilder.Append(m_connectionInfo.User);
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("工作空间名称：");
                stringBuilder.Append(m_connectionInfo.Name);
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("工作空间类型：");
                stringBuilder.Append(m_connectionInfo.Type.ToString());
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("工作空间版本：");
                stringBuilder.Append(m_connectionInfo.Version.ToString());
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("************************************************************");
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("工作空间中数据源信息：");

                Int32 datasourceCount = m_workspace.Datasources.Count;
                if (datasourceCount > 0)
                {
                    for (int i = 0; i < datasourceCount; i++)
                    {
                        stringBuilder.Append("数据源编号" + i + ": ");
                        stringBuilder.Append(m_workspace.Datasources[i].Alias);
                        stringBuilder.Append(System.Environment.NewLine);
                    }
                }
                else
                {
                    stringBuilder.Append("工作空间中没有数据源!");
                    stringBuilder.Append(System.Environment.NewLine);
                }
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("************************************************************");
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("工作空间中地图信息：");

                Int32 mapCount = m_workspace.Maps.Count;
                if (mapCount > 0)
                {
                    for (int i = 0; i < mapCount; i++)
                    {
                        stringBuilder.Append("地图编号" + i + ": ");
                        stringBuilder.Append(m_workspace.Maps[i]);
                        stringBuilder.Append(System.Environment.NewLine);
                    }
                }
                else
                {
                    stringBuilder.Append("工作空间中没有地图!");
                    stringBuilder.Append(System.Environment.NewLine);
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return stringBuilder.ToString();
        }
    }
}
