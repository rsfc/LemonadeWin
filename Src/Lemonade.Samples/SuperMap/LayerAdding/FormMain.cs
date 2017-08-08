///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------��Ȩ����----------------------------
//
// ���ļ�Ϊ SuperMap Objects .NET ��ʾ������
// ��Ȩ���У�������ͼ����ɷ����޹�˾
//------------------------------------------------------------------
//
//-----------------------SuperMap Objects .NET ʾ������˵��--------------------------
//
//1��������飺ʾ�������Ӹ������͵����ݼ�����ͼ�������÷��
//2��ʾ�����ݣ���װĿ¼\SampleData\world\world.smwu��
//3���ؼ�����/��Ա: 
//      Workspace.Open ����
//      Layers.Add ����
//      LayerSettingVector.Style ����
//      LayerSettingImage.OpaqueRate ����
//      LayerSettingGrid.IsSpecialValueTransparent ����
//
//4��ʹ�ò��裺
//   (1)ͨ��ѡ���Զ�������Ĭ�Ϸ�����������ͼ��ķ��
//   (2)ͨ������������ݼ���ť���������͵����ݼ���ӵ���ͼ��
//   (3)ͨ�����ͼ�㰴ť��յ�ͼ�е�����ͼ�㡣
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
using Lemonade.Frame;
using Lemonade.Frame.Running;
using SuperMap.UI;
using SuperMap.Data;

namespace Lemonade.Samples.SM.SampleCode.Mapping
{
    public partial class FormMain : Form,IModule
    {
        private SampleRun m_sampleRun;
        private SuperMap.Data.Workspace m_workspace;
        private SuperMap.UI.MapControl m_mapControl;

        private Boolean m_isCustomStyle = true;

        public FormMain()
        {
            try
            {
                InitializeComponent();
                this.Load += new EventHandler(FormMain_Load);

                //this.m_workspace = new SuperMap.Data.Workspace();
                this.m_workspace = (SuperMap.Data.Workspace)Lemon.SwapFindObject(typeof(SuperMap.Data.Workspace));
                this.m_mapControl = new SuperMap.UI.MapControl();
                
                m_mapControl.Dock = DockStyle.Fill;

                base.Controls.Add(m_mapControl);
                base.Controls.SetChildIndex(m_mapControl, 0);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                //ʵ����SampleRun
                m_sampleRun = new SampleRun(m_workspace, m_mapControl);

                //��ʼ��m_toolStripComboBoxIsCustom
                m_toolStripComboBoxIsCustom.Items.Add("�Զ�����");
                m_toolStripComboBoxIsCustom.Items.Add("Ĭ�Ϸ��");
                m_toolStripComboBoxIsCustom.SelectedItem = m_toolStripComboBoxIsCustom.Items[0];
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
        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                m_mapControl.Dispose();
                m_workspace.Dispose();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ����ѡ��������ò���ֵm_isCustomStyle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_toolStripComboBoxIsCustom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_toolStripComboBoxIsCustom.SelectedItem == m_toolStripComboBoxIsCustom.Items[0])
                {
                    m_isCustomStyle = true;
                }
                else
                {
                    m_isCustomStyle = false;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���ͼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_toolStripButtonClear_Click(object sender, EventArgs e)
        {
            try
            {
                m_sampleRun.ClearLayers();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ��ӵ����ݼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_toolStripButtonPoint_Click(object sender, EventArgs e)
        {
            try
            {
                m_sampleRun.AddPoint(m_isCustomStyle);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ��������ݼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_toolStripButtonLine_Click(object sender, EventArgs e)
        {
            try
            {
                m_sampleRun.AddLine(m_isCustomStyle);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ��������ݼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_toolStripButtonRegion_Click(object sender, EventArgs e)
        {
            try
            {
                m_sampleRun.AddRegion(m_isCustomStyle);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���Ӱ�����ݼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_toolStripButtonImage_Click(object sender, EventArgs e)
        {
            try
            {
                m_sampleRun.AddImage(m_isCustomStyle);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���դ�����ݼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_toolStripButtonGrid_Click(object sender, EventArgs e)
        {
            try
            {
                m_sampleRun.AddGrid(m_isCustomStyle);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        public void Initialize()
        {
            this.Show();
        }

        public IMainForm MainForm
        {
            get;set;
        }

        public string ModuleAlias
        {
            get { return "ͼ����Ӳ���"; }
        }

        public string ModuleName
        {
            get;
            set;
        }

        public void RunCache()
        {
             
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //this.m_mapControl.GeometryAdded += new UI.GeometryEventHandler(GeometryEventHandler);
            //this.m_mapControl.GeometrySelected += new UI.GeometrySelectedEventHandler(GeometrySelectedEventHandler1);
            //���һ����ܴ���Ķ���
            Lemon.ActionAppend(this.m_mapControl, "GeometrySelected", ActionType.Single, new GeometrySelectedEventHandler(GeometrySelectedEventHandler1));
        }

    

        public void GeometrySelectedEventHandler1(object sender, SuperMap.UI.GeometrySelectedEventArgs e)
        {
            MessageBox.Show("1");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //this.m_mapControl.GeometrySelected += new UI.GeometrySelectedEventHandler(GeometrySelectedEventHandler2);
            Lemon.ActionAppend(this.m_mapControl, "GeometrySelected", ActionType.Single, new GeometrySelectedEventHandler(GeometrySelectedEventHandler2));
        }

        public void GeometrySelectedEventHandler2(object sender, SuperMap.UI.GeometrySelectedEventArgs e)
        {
            MessageBox.Show("2");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //this.m_mapControl.GeometrySelected += new UI.GeometrySelectedEventHandler(GeometrySelectedEventHandler3);
            Lemon.ActionAppend(this.m_mapControl, "GeometrySelected", ActionType.Single, new GeometrySelectedEventHandler(GeometrySelectedEventHandler3));
        }

        public void GeometrySelectedEventHandler3(object sender, SuperMap.UI.GeometrySelectedEventArgs e)
        {
            MessageBox.Show("3");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            //this.m_mapControl.GeometrySelected += new UI.GeometrySelectedEventHandler(GeometrySelectedEventHandler4);
            Lemon.ActionAppend(this.m_mapControl, "GeometrySelected", ActionType.Sequence, new GeometrySelectedEventHandler(GeometrySelectedEventHandler4));
        }

        public void GeometrySelectedEventHandler4(object sender, SuperMap.UI.GeometrySelectedEventArgs e)
        {
            MessageBox.Show("4");
        } 
        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            Lemon.ActionRemoveAll(this.m_mapControl, "GeometrySelected");
        }

       
    }
}
