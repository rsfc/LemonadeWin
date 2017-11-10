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
    public class FunButton: IRibbonFunction
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
        /// 
        /// </summary>
        public string ButtonImage
        {
            get;
            set;
        }


        /// <summary>
        /// 标题
        /// </summary>
        public string ButtonTitle
        {
            get;
            set;
        }

        /// <summary>
        /// 按钮事件程序集路径
        /// </summary>
        public string Assembly { get; set; }

        /// <summary>
        /// 按钮事件执行类全名
        /// </summary>
        public string FullClassName { get; set; }
         
        public string RibbonStyle { get; set; }
    }
}
