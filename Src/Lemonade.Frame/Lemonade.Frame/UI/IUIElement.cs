using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// 界面元素
    /// </summary>
    public interface IUIElement
    {
        /// <summary>
        /// 是否可用
        /// </summary>
        /// <returns></returns>
        bool IsEnabled();
        /// <summary>
        /// 是否活跃
        /// </summary>
        /// <returns></returns>
        bool IsActive(); 
        /// <summary>
        /// 触发界面元素的操作
        /// </summary>
        void Executive();
        /// <summary>
        /// 是否显示
        /// </summary>
        bool IsVisible();
        /// <summary>
        /// 界面元素的父窗体
        /// </summary>
        System.Windows.Forms.Form ParentForm { get; set; }
    }
}
