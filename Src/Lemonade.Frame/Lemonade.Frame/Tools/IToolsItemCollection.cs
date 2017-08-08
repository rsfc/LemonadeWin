using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame; 


namespace Lemonade.Frame.Tools
{
    /// <summary>
    /// 工具栏按钮集合
    /// </summary>
    public interface  IToolsItemCollection
    {
        /// <summary>
        /// 集合名称
        /// </summary>
        string CollectionName { get; set; }
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="Button"></param>
        void AddButton(IToolsItem Button);
        /// <summary>
        /// 根据索引获取按钮
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IToolsItem this[int index] { get; }
        /// <summary>
        /// 按钮数量
        /// </summary>
        /// <returns></returns>
        int ButtonCount{get;}
    }
}
