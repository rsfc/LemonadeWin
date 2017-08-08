using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// 菜单级别  是否有子菜单
    /// </summary>
    public enum MenuLevel
    {

        /// <summary>
        /// 有子菜单
        /// </summary>
        [Description("包含子菜单")]
        BeSubmenu = 0,
        /// <summary>
        /// 不存在子菜单
        /// </summary>
        [Description("不包含子菜单")]
        NotBeSubmenu = 1, 

    }
}
