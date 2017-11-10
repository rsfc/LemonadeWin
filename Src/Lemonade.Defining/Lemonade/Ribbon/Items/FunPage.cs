using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.UI;

namespace Lemonade.Ribbon.Items
{
    /// <summary>
    /// 
    /// </summary>
    public class FunPage : IRibbonFunction
    { 
        /// <summary>
        /// 功能分页名称
        /// </summary>
        public string RibbonPageName
        {
            get;
            set;
        }

        public string ContentCode
        {
            get;set;
        }

        public int ContentIndex
        {
            get; set;
        }

        public IUIElement UIElement
        {
            get; set;
        }

        public List<string> Groups
        { get; set; }
    }
}
