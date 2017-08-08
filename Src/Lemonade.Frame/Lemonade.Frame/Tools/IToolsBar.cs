using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Lemonade.Frame.Tools
{ 
    /// <summary>
    /// 工具栏接口
    /// </summary>
    public interface IToolsBar
    {
        /// <summary>
        /// 添加按钮事件
        /// </summary>
        event ToolsBarItemOperation  EventAddItem;
        /// <summary>
        /// 工具栏编码
        /// </summary>
        string ToolsBarCode { get; set; }
        /// <summary>
        /// 工具栏名称
        /// </summary>
        string ToolsBarName { get; set; }
        /// <summary>
        /// 父窗体名称
        /// </summary>
        string ParentFormName { get; set; }
        /// <summary>
        /// 清除所有按钮
        /// </summary>
        void RemoveAllBtn(); 
        /// <summary>
        /// 获取分组名称列表
        /// </summary>
        /// <returns></returns>
        List<string> GetGroupName { get; }
        /// <summary>
        /// 获取全部项
        /// </summary>    
        /// <returns></returns>
        List<IToolsItem> GetItems();
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="Item"></param>
        void AddItem(IToolsItem Item);
        /// <summary>
        /// 分组数量
        /// </summary>
        int CollectionCount { get; }
        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="ColsName"></param>
        /// <returns></returns>
        IToolsItemCollection this[string ColsName] { get; }
    }
}
