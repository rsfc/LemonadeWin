using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// 权限项目 非菜单类权限项目
    /// 最理想的方式是 菜单、模块 关联到权限项目 权限项目关联到控制项 控制项关联到类型
    /// </summary>
    public interface IAuthItem : Protein.Enzyme.DAL.IEntityBase
    {
        /// <summary>
        /// 权限项名称
        /// </summary>
        string AuthItemName { get;set;}
        /// <summary>
        /// 权限项编码
        /// </summary>
        string AuthItemCode { get;set;}
    }
}
