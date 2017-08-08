///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap Objects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//
//-----------------------SuperMap Objects .NET 示范程序说明--------------------------
//
//1、范例简介：示范如何添加各种类型的数据集到地图，并设置风格
//2、示例数据：安装目录\SampleData\world\world.smwu；
//3、关键类型/成员: 
//      Workspace.Open 方法
//      Layers.Add 方法
//      LayerSettingVector.Style 属性
//      LayerSettingImage.OpaqueRate 属性
//      LayerSettingGrid.IsSpecialValueTransparent 属性
//
//4、使用步骤：
//   (1)通过选择自定义风格还是默认风格来控制添加图层的风格
//   (2)通过各个添加数据集按钮将各种类型的数据集添加到地图中
//   (3)通过清空图层按钮清空地图中的所有图层。
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
                //实例化SampleRun
                m_sampleRun = new SampleRun(m_workspace, m_mapControl);

                //初始化m_toolStripComboBoxIsCustom
                m_toolStripComboBoxIsCustom.Items.Add("自定义风格");
                m_toolStripComboBoxIsCustom.Items.Add("默认风格");
                m_toolStripComboBoxIsCustom.SelectedItem = m_toolStripComboBoxIsCustom.Items[0];
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 在窗体关闭时，需要释放相关的资源
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
        /// 根据选择的项设置布尔值m_isCustomStyle
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
        /// 清空图层
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
        /// 添加点数据集
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
        /// 添加线数据集
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
        /// 添加面数据集
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
        /// 添加影像数据集
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
        /// 添加栅格数据集
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
            get { return "图层添加操作"; }
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
            //添加一个框架处理的动作
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
