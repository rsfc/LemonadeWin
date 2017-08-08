using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;
using System.Windows.Forms;
using Lemonade.Frame.UI;

namespace Lemonade.ToolBar.Items
{
 
    /// <summary>
    /// 工具栏下拉框
    /// </summary>
    public class ToolsComboBox : IToolsItem
    { 
        /// <summary>
        /// 下拉框中的项列表
        /// </summary>
        public List<ToolsComboBoxItem> Items { get; set; }

        public string GroupName
        {
            get;
            set;
        }

        public object HostObject
        {
            get;
            set;
        }

        public string ItemID
        {
            get;
            set;
        }

        public int ItemIndex
        {
            get;
            set;
        }

        public string ToolsBarCode
        {
            get;
            set;
        }

        public IUIElement UIElement
        {
            get;
            set;
        }

        public ToolsComboBox()
        {
            this.Items = new List<ToolsComboBoxItem>();
        }
       
    }
}
