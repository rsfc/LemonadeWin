using System;
using Lemonade.Frame.UI;

namespace Lemonade.Frame.Tools
{
    /// <summary>
    /// 工具栏操作项接口
    /// </summary>
    public interface IToolsItem
    { 
        /// <summary>
        /// 项id 唯一的编号
        /// </summary>
        string ItemID { get; set; }
        /// <summary>
        /// 在工具栏中的索引
        /// </summary>
        int ItemIndex { get; set; } 
        /// <summary>
        /// 分组名称
        /// </summary>
        string GroupName { get; set; }
        /// <summary>
        /// 工具栏编码
        /// </summary>
        string ToolsBarCode { get; set; }
        /// <summary>
        /// 工具栏操作项的寄主对象,即控件对象
        /// </summary>
        object HostObject { get; set; }
        /// <summary>
        /// 绑定的界面元素
        /// </summary>
        IUIElement UIElement { get; set; }

    }
}
