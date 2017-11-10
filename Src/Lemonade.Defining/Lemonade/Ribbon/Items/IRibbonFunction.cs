using Lemonade.Frame.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Ribbon.Items
{
    /// <summary>
    /// 功能区内容接口
    /// </summary>
    public interface IRibbonFunction
    {
        /// <summary>
        /// 内容编码
        /// </summary>
        string ContentCode { get; set; }
        /// <summary>
        /// 内容索引
        /// </summary>
        int ContentIndex { get; set; }
        ///// <summary>
        ///// 上下文
        ///// </summary>
        //void Context();

        IUIElement UIElement { get; set; }
    }
}
