using Lemonade.Frame.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Ribbon.Items
{
    /// <summary>
    /// 
    /// </summary>
    public class FunGroup : IRibbonFunction
    {
        /// <summary>
        /// 
        /// </summary>
        public string ContentCode
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int ContentIndex
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public IUIElement UIElement
        {
            get; set;
        }
        /// <summary>
        /// 按钮集合
        /// </summary>
        public List<string> Buttons
        {
            get;
            set;
        }


        /// <summary>
        /// 
        /// </summary>
        public string Image
        {
            get;
            set;
        }
        /// <summary>
        /// 索引
        /// </summary>
        public int Index
        {
            get;
            set;
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get;
            set;
        }


    }
}
