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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SuperMap.Data;
using Lemonade.Frame;

namespace Lemonade.Samples.SM.WorkspaceManage
{
    public partial class FormMain : Form,IModule
    {
        private SampleRun m_sampleRun;
        private Workspace m_workspace;
        private WorkspaceConnectionInfo m_connectionInfo;

        public FormMain()
        {
            try
            {
                InitializeComponent();

                m_workspace = new SuperMap.Data.Workspace();
 
                m_connectionInfo = new WorkspaceConnectionInfo();
                //ʵ����SampleRun
                m_sampleRun = new SampleRun(m_workspace);
                m_sampleRun.OnCheck += new SampleRun.CheckEventHandler(m_sampleRun_OnCheck);
                this.comboBoxCreateSDBVersion.SelectedIndexChanged += new EventHandler(comboBoxCreateSDBVersion_SelectedIndexChanged);
                this.comboBoxSaveSDBVersion.SelectedIndexChanged += new EventHandler(comboBoxSaveSDBVersion_SelectedIndexChanged);
                // ��ʼ���ؼ�

                comboBoxCreateSQLVersion.SelectedIndex = 0;
                comboBoxCreateOracleVersion.SelectedIndex = 0;
                comboBoxCreateSDBType.SelectedIndex = 0;
                comboBoxCreateSDBVersion.SelectedIndex = 0;
                comboBoxSaveSQLVersion.SelectedIndex = 0;
                comboBoxSaveOracleVersion.SelectedIndex = 0;
                comboBoxSaveSDBType.SelectedIndex = 0;
                comboBoxSaveSDBVersion.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void comboBoxSaveSDBVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSaveSDBVersion.SelectedIndex == 0)
                {
                    comboBoxSaveSDBType.Items.Clear();
                    comboBoxSaveSDBType.Items.Add("SMWU");
                    comboBoxSaveSDBType.Items.Add("SXWU");
                }
                else
                {
                    comboBoxSaveSDBType.Items.Clear();
                    comboBoxSaveSDBType.Items.Add("SMW");
                    comboBoxSaveSDBType.Items.Add("SXW");
                }

                comboBoxSaveSDBType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void comboBoxCreateSDBVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCreateSDBVersion.SelectedIndex == 0)
                {
                    comboBoxCreateSDBType.Items.Clear();
                    comboBoxCreateSDBType.Items.Add("SMWU");
                    comboBoxCreateSDBType.Items.Add("SXWU");
                }
                else
                {
                    comboBoxCreateSDBType.Items.Clear();
                    comboBoxCreateSDBType.Items.Add("SMW");
                    comboBoxCreateSDBType.Items.Add("SXW");
                }

                comboBoxCreateSDBType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ��������ͬʱ���ý���
        /// </summary>
        /// <param name="args"></param>
        private void m_sampleRun_OnCheck(Boolean isInitialize)
        {
            try
            {
                if (isInitialize)
                {
                    tabControlSave.Enabled = false;
                    buttonDeleteOK.Enabled = false;
                    buttonDeleteCancel.Enabled = false;
                }
                else
                {
                    tabControlSave.Enabled = true;
                    buttonDeleteOK.Enabled = true;
                    buttonDeleteCancel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// �ڴ���ر�ʱ����Ҫ�ͷ���ص���Դ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //m_workspace.Dispose();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���ѡ��SDB�ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenSDBFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDig = new OpenFileDialog();
                openFileDig.Filter = "SXW files (*.sxw)|*.sxw|SMW files (*.smw)|*.smw|SXWU files (*.sxwu)|*.sxwu|SMWU files (*.smwu)|*.smwu";

                if (openFileDig.ShowDialog() == DialogResult.OK)
                {
                    textBoxSDBPath.Text = openFileDig.FileName;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ��SDB�����ռ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSDBOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxSDBPath.Text;
                m_connectionInfo.Type = this.GetType(System.IO.Path.GetExtension(textBoxSDBPath.Text).ToUpper().Replace(".", String.Empty));
                m_connectionInfo.Name = System.IO.Path.GetFileNameWithoutExtension(textBoxSDBPath.Text);
                m_connectionInfo.Password = textBoxSDBPassword.Text;

                richTextBoxOutput.Text += m_sampleRun.Open(m_connectionInfo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// ��Oracle�����ռ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOracleOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxOrcleServer.Text;
                m_connectionInfo.Database = textBoxOrcleDatabase.Text;
                m_connectionInfo.User = textBoxOracleUser.Text;
                m_connectionInfo.Password = textBoxOraclePassword.Text;
                m_connectionInfo.Name = textBoxOrcleName.Text;
                m_connectionInfo.Type = WorkspaceType.Oracle;

                richTextBoxOutput.Text += m_sampleRun.Open(m_connectionInfo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// ��SQL�����ռ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSQLOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxSQLServer.Text;
                m_connectionInfo.Database = textBoxSQLDatabase.Text;
                m_connectionInfo.User = textBoxSQLUser.Text;
                m_connectionInfo.Password = textBoxSQLPassword.Text;
                m_connectionInfo.Name = textBoxSQLName.Text;
                m_connectionInfo.Driver = "SQL Server";
                m_connectionInfo.Type = WorkspaceType.SQL;

                richTextBoxOutput.Text += m_sampleRun.Open(m_connectionInfo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ѡ�񴴽���SDB·��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateSDBFile_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDig = new FolderBrowserDialog();

                if (folderBrowserDig.ShowDialog() == DialogResult.OK)
                {
                    textBoxCreateSDBPath.Text = folderBrowserDig.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ����SDB�����ռ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateSDBOK_Click(object sender, EventArgs e)
        {
            try
            {
                String extension = comboBoxCreateSDBType.SelectedItem as String;

                m_connectionInfo.Version = this.GetVersion(comboBoxCreateSDBVersion.SelectedIndex);
                m_connectionInfo.Type = this.GetType(extension);
                m_connectionInfo.Server = System.IO.Path.Combine(textBoxCreateSDBPath.Text, textBoxCreateSDBName.Text + "." + extension);
                m_connectionInfo.Name = textBoxCreateSDBName.Text;
                m_connectionInfo.Password = textBoxCreateSDBPassword.Text;

                richTextBoxOutput.Text += m_sampleRun.Create(m_connectionInfo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ����Oracle�����ռ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateOracleOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxCreateOracleServer.Text;
                m_connectionInfo.Database = textBoxCreateOracleDatabase.Text;
                m_connectionInfo.User = textBoxCreateOracleUser.Text;
                m_connectionInfo.Password = textBoxCreateOraclePassword.Text;
                m_connectionInfo.Name = textBoxCreateOracleName.Text;
                m_connectionInfo.Version = GetVersion(comboBoxCreateOracleVersion.SelectedIndex);
                m_connectionInfo.Type = WorkspaceType.Oracle;

                richTextBoxOutput.Text += m_sampleRun.Create(m_connectionInfo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ����SQL�����ռ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateSQLOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxCreateSQLServer.Text;
                m_connectionInfo.Database = textBoxCreateSQLDatabase.Text;
                m_connectionInfo.User = textBoxCreateSQLUser.Text;
                m_connectionInfo.Password = textBoxCreateSQLPassword.Text;
                m_connectionInfo.Name = textBoxCreateSQLName.Text;
                m_connectionInfo.Version = GetVersion(comboBoxCreateSQLVersion.SelectedIndex);
                m_connectionInfo.Type = WorkspaceType.SQL;
                m_connectionInfo.Driver = "SQL Server";

                richTextBoxOutput.Text += m_sampleRun.Create(m_connectionInfo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ѡ������·��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveSDBOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDig = new FolderBrowserDialog();

                if (folderBrowserDig.ShowDialog() == DialogResult.OK)
                {
                    textBoxSaveSDBFilePath.Text = folderBrowserDig.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���SDB�����ռ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveSDBOK_Click(object sender, EventArgs e)
        {
            try
            {
                String extension = comboBoxCreateSDBType.SelectedItem as String;

                m_connectionInfo.Version = GetVersion(comboBoxSaveSDBVersion.SelectedIndex);
                m_connectionInfo.Type = this.GetType(extension);
                m_connectionInfo.Server = System.IO.Path.Combine(textBoxSaveSDBFilePath.Text, textBoxSaveSDBName.Text + "." + extension);
                m_connectionInfo.Name = textBoxSaveSDBName.Text;
                m_connectionInfo.Password = textBoxSaveSDBPassword.Text;

                richTextBoxOutput.Text += m_sampleRun.SaveAs(m_connectionInfo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���Oracle�����ռ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveOracleOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxSaveOracleServer.Text;
                m_connectionInfo.Database = textBoxSaveOracleDatabase.Text;
                m_connectionInfo.User = textBoxSaveOracleUser.Text;
                m_connectionInfo.Password = textBoxSaveOraclePassword.Text;
                m_connectionInfo.Name = textBoxSaveOracleName.Text;
                m_connectionInfo.Version = GetVersion(comboBoxSaveOracleVersion.SelectedIndex);
                m_connectionInfo.Type = WorkspaceType.Oracle;

                richTextBoxOutput.Text += m_sampleRun.SaveAs(m_connectionInfo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���SQL�����ռ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveSQLOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_connectionInfo.Server = textBoxSaveSQLServer.Text;
                m_connectionInfo.Database = textBoxSaveSQLDatabase.Text;
                m_connectionInfo.User = textBoxSaveSQLUser.Text;
                m_connectionInfo.Password = textBoxSaveSQLPassword.Text;
                m_connectionInfo.Name = textBoxSaveSQLName.Text;
                m_connectionInfo.Version = GetVersion(comboBoxSaveSQLVersion.SelectedIndex);
                m_connectionInfo.Type = WorkspaceType.SQL;
                m_connectionInfo.Driver = "SQL Server";

                richTextBoxOutput.Text += m_sampleRun.SaveAs(m_connectionInfo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ȡ��ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteCancel_Click(object sender, EventArgs e)
        {
            richTextBoxOutput.Text += "ɾ��ȡ��" + System.Environment.NewLine;
        }

        /// <summary>
        /// ɾ����ǰ�����ռ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteOK_Click(object sender, EventArgs e)
        {
            richTextBoxOutput.Text += m_sampleRun.Delete();
        }


        /// <summary>
        /// ��ȡѡ��Ĺ����ռ�����
        /// </summary>
        /// <param name="index">ѡ�е�������</param>
        /// <returns>��Ӧ������</returns>
        private WorkspaceType GetType(String type)
        {
            WorkspaceType result = WorkspaceType.Default;

            switch (type.ToUpper())
            {
                case "SMW":
                    {
                        result = WorkspaceType.SMW;
                    }
                    break;
                case "SXW":
                    {
                        result = WorkspaceType.SXW;
                    }
                    break;
                case "SMWU":
                    {
                        result = WorkspaceType.SMWU;
                    }
                    break;
                case "SXWU":
                    {
                        result = WorkspaceType.SXWU;
                    }
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// ��ȡѡ��İ汾��
        /// </summary>
        /// <param name="selectIndex">ѡ�е�������</param>
        /// <returns>��Ӧ�İ汾��</returns>
        private WorkspaceVersion GetVersion(Int32 selectIndex)
        {
            WorkspaceVersion version = WorkspaceVersion.SFC50;
            switch (selectIndex)
            {
                case 0:
                    {
                        version = WorkspaceVersion.UGC60;
                    }
                    break;
                case 1:
                    {
                        version = WorkspaceVersion.UGC20;
                    }
                    break;
                case 2:
                    {
                        version = WorkspaceVersion.SFC60;
                    }
                    break;
                default:
                    break;
            }

            return version;
        }


        public void Initialize()
        {
            this.Show();
        }

        public IMainForm MainForm
        {
            get;
            set;
        }

        public string ModuleAlias
        {
            get { return "�����ռ�"; }
        }

        public string ModuleName
        {
            get;
            set;
        }

        public void RunCache()
        {
             
        }
    }
}
