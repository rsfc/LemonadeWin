using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;
using System.Windows.Forms;
using Lemonade.ToolBar.Datas;

namespace Lemonade.ToolBar.Items
{
    /// <summary>
    /// 下拉框项类
    /// </summary>
    public class ToolsComboBoxItem : IToolsItem
    {
        /// <summary>
        /// 项的数据
        /// </summary>
        public TComboBoxItem ItemData { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ItemData.Title;
        }

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

        public Frame.UI.IUIElement UIElement
        {
            get;
            set;
        }
    }
}
