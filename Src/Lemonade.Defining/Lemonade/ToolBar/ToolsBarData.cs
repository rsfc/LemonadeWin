using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using Lemonade.ToolBar.Datas;

namespace Lemonade.ToolBar
{
    /// <summary>
    /// 工具栏数据
    /// </summary>
    public class ToolsBarData
    { 
        /// <summary>
        /// 工具栏
        /// </summary>
        public List<TBar> Bars { get; set; }
        /// <summary>
        /// 按钮
        /// </summary>
        public List<TButton> Buttons { get; set; }
        /// <summary>
        /// 下拉框
        /// </summary>
        public List<TComboBox> ComboBoxs { get; set; }
        /// <summary>
        /// 分隔符
        /// </summary>
        public List<TSeparator> Separator { get; set; }
    }
}
