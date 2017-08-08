using System;
using System.Collections.Generic;
namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// 数据层 菜单接口
    /// </summary>
    public interface IMenu : Protein.Enzyme.DAL.IEntityBase

    {
        /// <summary>
        /// 类全名
        /// </summary>
        string FULLCLASSNAME { get; set; }
        ///// <summary>
        ///// 是否有子菜单
        ///// </summary>
        //string ISCHILD { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        string MARK { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        string MENUCODE { get; set; }
        /// <summary>
        /// 菜单功能
        /// </summary>
        string MENUFUNCTION { get; set; }
        /// <summary>
        /// 菜单标题
        /// </summary>
        string MENUTITLE { get; set; }
        /// <summary>
        /// 添加菜单类型 用于区分c/s和b/s
        /// </summary>
        string MENUTYPE { get; set; }
        /// <summary>
        /// 上级菜单编号
        /// </summary>
        string PARENTCODE { get; set; } 
        /// <summary>
        /// 目标路径
        /// </summary>
        string TARGETPATH { get; set; }
        /// <summary>
        /// 快捷键
        /// </summary>
        string ShortcutKey { get;set;} 
        /// <summary>
        /// 排列顺序号 菜单所在级别中的排列顺序
        /// </summary>
        int OrderIndex { get;set;}
    }
}
