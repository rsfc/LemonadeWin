using System;
namespace Lemonade.Frame.Menu
{
    /// <summary>
    /// 系统菜单项接口
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// 菜单图片
        /// </summary>
        string ImageName { get; set; }
        /// <summary>
        /// 是否存在子菜单
        /// </summary>
        bool IsChild { get; set; }
        /// <summary>
        /// 项id
        /// </summary>
        int ItemID { get; set; }
        /// <summary>
        /// 上级id
        /// </summary>
        string ParentItemID { get; set; }
        /// <summary>
        /// 菜单标题
        /// </summary>
        string Title { get; set; } 
        /// <summary>
        /// 快捷键
        /// </summary>
        string ShortcutKey { get;set;}
        /// <summary>
        /// 排列顺序号
        /// </summary>
        int OrderIndex { get;set;}
    }
}
