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
//2��ʾ�����ݣ���װĿ¼\SampleData\World\World.smwu��
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
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.UI;
using SuperMap.Mapping;
using Lemonade.Frame;

namespace Lemonade.Samples.SM.SampleCode.Mapping
{
    public class SampleRun
    {
        private Workspace m_workspace;
        private MapControl m_mapControl;
        private Datasource m_datasource;
        //��ӵĸ����������ݼ�������
        private readonly String m_datasetPoint = "Capital";
        private readonly String m_datasetLine = "Grids";
        private readonly String m_datasetRegion = "World";
        private readonly String m_datasetImage = "day";
        private readonly String m_datasetGrid = "Raster";

        /// <summary>
        /// ����workspace��map���� SampleRun����
        /// </summary>
        public SampleRun(Workspace workspace, MapControl mapControl)
        {
            try
            {
                m_workspace = workspace;
                m_mapControl = mapControl;

                m_mapControl.Map.Workspace = workspace;
                Initialize();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ����Ҫ�Ĺ����ռ��ļ�����ͼ
        /// </summary>
        private void Initialize()
        {
            try
            {
                ////�򿪹����ռ估��ͼ
                //WorkspaceConnectionInfo conInfo = new WorkspaceConnectionInfo(@"..\..\SampleData\World\World.smwu");

                //m_workspace.Open(conInfo);
                m_datasource = m_workspace.Datasources[0];

                this.m_mapControl.Map.Open(m_workspace.Maps[1]);
                //���뽻����
                Lemon.SwapAppend(this.m_mapControl);
                // ����mapControl��״̬
                m_mapControl.Action = SuperMap.UI.Action.Pan;
                m_mapControl.Map.ViewEntire();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���ͼ��
        /// </summary>
        public void ClearLayers()
        {
            try
            {
                m_mapControl.Map.Layers.Clear();
                m_mapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���ͼ����ӵ����ݼ�
        /// </summary>
        /// <param name="isWithStyle">�Ƿ��Զ�����</param>
        public void AddPoint(Boolean isWithStyle)
        {
            try
            {
                DatasetVector dataset = m_datasource.Datasets[m_datasetPoint] as DatasetVector;
                //���÷��������ݼ�
                Layer layer = null;
                if (isWithStyle)
                {

                    LayerSettingVector setting = new LayerSettingVector();
                    setting.Style.LineColor = Color.SeaGreen;
                    setting.Style.MarkerSize = new Size2D(4, 4);
                    setting.Style.MarkerSymbolID = 12;
                    layer = m_mapControl.Map.Layers.Add(dataset, setting, true);
                }
                else
                {
                    layer = m_mapControl.Map.Layers.Add(dataset, true);
                }
                //ȫ����ʾ��ӵ�ͼ��
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���ͼ����������ݼ�
        /// </summary>
        /// <param name="isWithStyle">�Ƿ��Զ�����</param>
        public void AddLine(Boolean isWithStyle)
        {
            try
            {
                DatasetVector dataset = m_datasource.Datasets[m_datasetLine] as DatasetVector;
                //���÷��������ݼ�
                Layer layer = null;
                if (isWithStyle)
                {
                    LayerSettingVector setting = new LayerSettingVector();
                    setting.Style.LineColor = Color.Gray;
                    setting.Style.LineSymbolID = 2;
                    setting.Style.LineWidth = 0.3;
                    layer = m_mapControl.Map.Layers.Add(dataset, setting, true);
                }
                else
                {
                    layer = m_mapControl.Map.Layers.Add(dataset, true);
                }

                //ȫ����ʾ��ӵ�ͼ��
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���ͼ����������ݼ�
        /// </summary>
        /// <param name="isWithStyle">�Ƿ��Զ�����</param>
        public void AddRegion(Boolean isWithStyle)
        {
            try
            {
                DatasetVector dataset = m_datasource.Datasets[m_datasetRegion] as DatasetVector;
                //���÷��������ݼ�
                Layer layer = null;
                if (isWithStyle)
                {
                    LayerSettingVector setting = new LayerSettingVector();
                    setting.Style.LineColor = Color.Teal;
                    setting.Style.LineSymbolID = 11;
                    setting.Style.LineWidth = 0.5;
                    setting.Style.FillForeColor = Color.FromArgb(2, 138, 226);
                    setting.Style.FillBackColor = Color.FromArgb(232, 245, 254);
                    setting.Style.FillGradientMode = FillGradientMode.Radial;
                    layer = m_mapControl.Map.Layers.Add(dataset, setting, true);
                }
                else
                {
                    layer = m_mapControl.Map.Layers.Add(dataset, true);
                }
                //ȫ����ʾ��ӵ�ͼ��
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���ͼ�����Ӱ�����ݼ�
        /// </summary>
        /// <param name="isWithStyle">�Ƿ��Զ�����</param>
        public void AddImage(Boolean isWithStyle)
        {
            try
            {
                DatasetImage dataset = m_datasource.Datasets[m_datasetImage] as DatasetImage;
                //���÷��������ݼ�
                Layer layer = null;
                if (isWithStyle)
                {
                    LayerSettingImage setting = new LayerSettingImage();
                    setting.OpaqueRate = 50;
                    layer = m_mapControl.Map.Layers.Add(dataset, setting, true);
                }
                else
                {
                    layer = m_mapControl.Map.Layers.Add(dataset, true);
                }
                //ȫ����ʾ��ӵ�ͼ��
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ���ͼ�����դ�����ݼ�
        /// </summary>
        /// <param name="isWithStyle">�Ƿ��Զ�����</param>
        public void AddGrid(Boolean isWithStyle)
        {
            try
            {
                DatasetGrid dataset = m_datasource.Datasets[m_datasetGrid] as DatasetGrid;
                //���÷��������ݼ�
                Layer layer = null;
                if (isWithStyle)
                {
                    LayerSettingGrid setting = new LayerSettingGrid();
                    setting.ColorTable = Colors.MakeGradient(20, ColorGradientType.BlueWhite, false);
                    setting.SpecialValue = -9999;
                    setting.IsSpecialValueTransparent = true;
                    layer = m_mapControl.Map.Layers.Add(dataset, setting, true);
                }
                else
                {
                    layer = m_mapControl.Map.Layers.Add(dataset, true);
                }
                //ȫ����ʾ��ӵ�ͼ��
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
}
