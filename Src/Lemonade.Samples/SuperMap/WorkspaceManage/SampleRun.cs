///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------��Ȩ����----------------------------
//
// ���ļ�Ϊ SuperMap Objects .NET ��ʾ������
// ��Ȩ���У�������ͼ����ɷ����޹�˾
//------------------------------------------------------------------
//
//-----------------------SuperMap Objects .NET ʾ������˵��--------------------------
//
//1��������飺ʾ���򿪡���������桢ɾ���ļ��ͺ����ݿ��͹����ռ�
//2��ʾ�����ݣ���        
//3���ؼ�����/��Ա: 
//      WorkspaceConnectionInfo ����
//      Workspace.Open ����
//      Workspace.Create ����
//      Workspace.SavaAs ����
//      Workspace.DeleteWorkspace ����
//
//4��ʹ�ò��裺
//   (1)�򿪻򴴽������ռ䣬�鿴�����ռ����ԡ�
//   (2)��浱ǰ�����ռ䡣
//   (3)ɾ����ǰ�����ռ䡣
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
        /// ����workspace���� SampleRun����
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
        /// �򿪹����ռ�
        /// </summary>
        /// <param name="connectionInfo">�����ռ�������Ϣ</param>
        /// <returns>�������������Ϣ</returns>
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
                    result += "�򿪹����ռ�ɹ���";
                    result += System.Environment.NewLine;
                    // ��ȡ�ɹ���Ĺ����ռ���Ϣ
                    result += GetWorkspaceInfomation();
                    //�����¼���֪ͨ��������Ӧ�Ĵ���false������ɾ�����ܿ��ã�trueΪ������
                    OnCheck(false);
                }
                else
                {
                    result = System.Environment.NewLine;
                    result += "�򿪹����ռ�ʧ��!";
                    result += System.Environment.NewLine;
                    //�����¼���֪ͨ��������Ӧ�Ĵ���false������ɾ�����ܿ��ã�trueΪ������
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
        /// ���������ռ�
        /// </summary>
        /// <param name="connectionInfo">�����ռ�������Ϣ</param>
        /// <returns>�������������Ϣ</returns>
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
                    result += "���������ռ�ɹ���";
                    result += System.Environment.NewLine;
                    result += GetWorkspaceInfomation();
                    OnCheck(false);
                }
                else
                {
                    result = System.Environment.NewLine;
                    result += "���������ռ�ʧ��!";
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
        /// ��湤���ռ�
        /// </summary>
        /// <param name="connectionInfo">�����ռ�������Ϣ</param>
        /// <returns>�������������Ϣ</returns>
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
                    result += "��湤���ռ�ɹ���";
                    result += System.Environment.NewLine;
                    result += GetWorkspaceInfomation();
                    OnCheck(false);
                }
                else
                {
                    result = System.Environment.NewLine;
                    result += "��湤���ռ�ʧ��!";
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
        /// ɾ�������ռ�
        /// </summary>
        /// <returns>�������������Ϣ</returns>
        public String Delete()
        {
            String result = String.Empty;

            try
            {
                Boolean isSucceed = Workspace.DeleteWorkspace(m_connectionInfo);

                if (isSucceed)
                {
                    result = System.Environment.NewLine;
                    result += "ɾ�������ռ�ɹ���";
                    result += System.Environment.NewLine;
                    result += GetWorkspaceInfomation();
                    OnCheck(true);
                }
                else
                {
                    result = System.Environment.NewLine;
                    result += "ɾ�������ռ�ʧ��!";
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
        /// ��ȡ��ǰ�Ĺ����ռ���Ϣ
        /// </summary>
        /// <returns>�����ռ���Ϣ</returns>
        public String GetWorkspaceInfomation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                stringBuilder.Append("�����ռ������Ϣ��");
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("�����������ļ�·����");
                stringBuilder.Append(m_connectionInfo.Server);
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("���ݿ�����");
                stringBuilder.Append(m_connectionInfo.Database);
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("�û�����");
                stringBuilder.Append(m_connectionInfo.User);
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("�����ռ����ƣ�");
                stringBuilder.Append(m_connectionInfo.Name);
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("�����ռ����ͣ�");
                stringBuilder.Append(m_connectionInfo.Type.ToString());
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("�����ռ�汾��");
                stringBuilder.Append(m_connectionInfo.Version.ToString());
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("************************************************************");
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("�����ռ�������Դ��Ϣ��");

                Int32 datasourceCount = m_workspace.Datasources.Count;
                if (datasourceCount > 0)
                {
                    for (int i = 0; i < datasourceCount; i++)
                    {
                        stringBuilder.Append("����Դ���" + i + ": ");
                        stringBuilder.Append(m_workspace.Datasources[i].Alias);
                        stringBuilder.Append(System.Environment.NewLine);
                    }
                }
                else
                {
                    stringBuilder.Append("�����ռ���û������Դ!");
                    stringBuilder.Append(System.Environment.NewLine);
                }
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("************************************************************");
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append("�����ռ��е�ͼ��Ϣ��");

                Int32 mapCount = m_workspace.Maps.Count;
                if (mapCount > 0)
                {
                    for (int i = 0; i < mapCount; i++)
                    {
                        stringBuilder.Append("��ͼ���" + i + ": ");
                        stringBuilder.Append(m_workspace.Maps[i]);
                        stringBuilder.Append(System.Environment.NewLine);
                    }
                }
                else
                {
                    stringBuilder.Append("�����ռ���û�е�ͼ!");
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
