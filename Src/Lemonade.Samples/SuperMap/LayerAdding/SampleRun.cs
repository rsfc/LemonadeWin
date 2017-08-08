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
//2、示例数据：安装目录\SampleData\World\World.smwu；
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
        //添加的各中类型数据集的名称
        private readonly String m_datasetPoint = "Capital";
        private readonly String m_datasetLine = "Grids";
        private readonly String m_datasetRegion = "World";
        private readonly String m_datasetImage = "day";
        private readonly String m_datasetGrid = "Raster";

        /// <summary>
        /// 根据workspace和map构造 SampleRun对象
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
        /// 打开需要的工作空间文件及地图
        /// </summary>
        private void Initialize()
        {
            try
            {
                ////打开工作空间及地图
                //WorkspaceConnectionInfo conInfo = new WorkspaceConnectionInfo(@"..\..\SampleData\World\World.smwu");

                //m_workspace.Open(conInfo);
                m_datasource = m_workspace.Datasources[0];

                this.m_mapControl.Map.Open(m_workspace.Maps[1]);
                //加入交换池
                Lemon.SwapAppend(this.m_mapControl);
                // 调整mapControl的状态
                m_mapControl.Action = SuperMap.UI.Action.Pan;
                m_mapControl.Map.ViewEntire();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 清空图层
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
        /// 向地图中添加点数据集
        /// </summary>
        /// <param name="isWithStyle">是否自定义风格</param>
        public void AddPoint(Boolean isWithStyle)
        {
            try
            {
                DatasetVector dataset = m_datasource.Datasets[m_datasetPoint] as DatasetVector;
                //设置风格并添加数据集
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
                //全幅显示添加的图层
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 向地图中添加线数据集
        /// </summary>
        /// <param name="isWithStyle">是否自定义风格</param>
        public void AddLine(Boolean isWithStyle)
        {
            try
            {
                DatasetVector dataset = m_datasource.Datasets[m_datasetLine] as DatasetVector;
                //设置风格并添加数据集
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

                //全幅显示添加的图层
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 向地图中添加面数据集
        /// </summary>
        /// <param name="isWithStyle">是否自定义风格</param>
        public void AddRegion(Boolean isWithStyle)
        {
            try
            {
                DatasetVector dataset = m_datasource.Datasets[m_datasetRegion] as DatasetVector;
                //设置风格并添加数据集
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
                //全幅显示添加的图层
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 向地图中添加影像数据集
        /// </summary>
        /// <param name="isWithStyle">是否自定义风格</param>
        public void AddImage(Boolean isWithStyle)
        {
            try
            {
                DatasetImage dataset = m_datasource.Datasets[m_datasetImage] as DatasetImage;
                //设置风格并添加数据集
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
                //全幅显示添加的图层
                m_mapControl.Map.EnsureVisible(layer);
                m_mapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 向地图中添加栅格数据集
        /// </summary>
        /// <param name="isWithStyle">是否自定义风格</param>
        public void AddGrid(Boolean isWithStyle)
        {
            try
            {
                DatasetGrid dataset = m_datasource.Datasets[m_datasetGrid] as DatasetGrid;
                //设置风格并添加数据集
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
                //全幅显示添加的图层
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
