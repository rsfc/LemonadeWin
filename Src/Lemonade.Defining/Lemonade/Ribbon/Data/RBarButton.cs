using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.UI;

namespace Lemonade.Ribbon.Data
{
    /// <summary>
    /// 功能区按钮数据对象
    /// </summary>
    public class RBarButton
    { 

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
        /// <summary>
        /// 
        /// </summary>
        public string ButtonCode
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Index
        {
            get; set;
        }

        public string RibbonStyle { get; set; }


    }
}
