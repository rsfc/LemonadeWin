using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;
using Lemonade.ToolBar.Items;
using DevExpress.XtraBars.Ribbon;
using Lemonade.Ribbon.Items;

namespace Lemonade.Ribbon
{
    /// <summary>
    /// 功能区域设置
    /// </summary>
    public class RibbonSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public RibbonSetting()
        {
            this.Pages = new List<FunPage>();
            //this.ComboBoxs = new List<ToolsComboBox>();
            this.Buttons = new List<FunButton>();
            this.Groups = new List<FunGroup>();
        }
        /// <summary>
        /// 工具栏
        /// </summary>
        public List<FunPage> Pages { get; set; }
        /// <summary>
        /// 按钮
        /// </summary>
        public List<FunButton> Buttons { get; set; }
        ///// <summary>
        ///// 下拉框
        ///// </summary>
        //public List<ToolsComboBox> ComboBoxs { get; set; }
        /// <summary>
        /// 分组
        /// </summary>
        public List<FunGroup> Groups { get; set; }
    }
}
