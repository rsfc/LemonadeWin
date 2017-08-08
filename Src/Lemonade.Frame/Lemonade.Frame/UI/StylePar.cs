using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// 样式参数用于在框架能定义窗体的风格
    /// </summary>
    public class StylePar
    {
        /// <summary>
        /// 
        /// </summary>
        public StylePar()
        {
        
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="Frm"></param>
        public StylePar(Form Frm)
        {
            this.Location = Frm.Location;
            this.FormBorderStyle = Frm.FormBorderStyle;
            this.Height = Frm.Height;
            this.Width = Frm.Width;
            this.WindowClassFullName = Lemon.GetObjType(Frm).FullName;
            this.WindowState = Frm.WindowState; 
            this.TopMost = Frm.TopMost;
            this.ShowIcon = Frm.ShowIcon;
            this.ShowInTaskbar = Frm.ShowInTaskbar;
            this.MaximizeBox = Frm.MaximizeBox;
            this.MinimizeBox = Frm.MinimizeBox;
        }

        /// <summary>
        /// 窗体的类全名 
        /// </summary>
        public string WindowClassFullName { get; set; }
        /// <summary>
        /// 是否顶级窗体
        /// </summary>
        public bool TopMost {get;set;}
        /// <summary>
        /// 是否显示图标
        /// </summary>
        public bool ShowIcon { get; set; }
        /// <summary>
        /// 是否显示任务栏
        /// </summary>
        public bool ShowInTaskbar { get; set; }
        /// <summary>
        /// 是否有最大化按钮
        /// </summary>
        public bool MaximizeBox { get; set; }
        /// <summary>
        /// 是否有最小化按钮
        /// </summary>
        public bool MinimizeBox { get; set; } 
        /// <summary>
        /// 窗体显示模式
        /// </summary>
        public FormWindowState WindowState { get; set; }
        /// <summary>
        /// 边框样式
        /// </summary>
        public FormBorderStyle FormBorderStyle { get; set; } 
        /// <summary>
        /// 宽
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 获取或设置以屏幕坐标表示的代表 System.Windows.Forms.Form 左上角的 System.Drawing.Point
        /// </summary>
        public Point Location { get; set; }
    }
}
