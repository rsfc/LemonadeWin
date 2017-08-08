using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Samples.LayoutSplitA
{
    /// <summary>
    /// 分栏区域设置
    /// </summary>
    public class SplitRegion
    {
        /// <summary>
        /// 模块类名
        /// </summary>
        public List<string> FormClassName { get; set; }
        /// <summary>
        /// 分栏区域索引
        /// </summary>
        public int SplitPanelIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Height { get; set; }

    }
}
