using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;
using Lemonade.ToolBar.Items;

namespace Lemonade.ToolBar
{
    /// <summary>
    /// 工具栏设置
    /// </summary>
    public class ToolsBarSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public ToolsBarSetting()
        {
            this.Bars = new List<ToolsBar>();
            this.ComboBoxs = new List<ToolsComboBox>();
            this.Buttons = new List<ToolsButton>();
            this.Separator = new List<ToolsSeparator>();
        }
        /// <summary>
        /// 工具栏
        /// </summary>
        public List<ToolsBar> Bars { get; set; }
        /// <summary>
        /// 按钮
        /// </summary>
        public List<ToolsButton> Buttons { get; set; }
        /// <summary>
        /// 下拉框
        /// </summary>
        public List<ToolsComboBox> ComboBoxs { get; set; }
        /// <summary>
        /// 分隔符
        /// </summary>
        public List<ToolsSeparator> Separator { get; set; }
    }
}
