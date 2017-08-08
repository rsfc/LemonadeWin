using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// 权限类型
    /// </summary>
    public enum AuthType : int
    {
        /// <summary>
        /// 只读
        /// </summary>
        [Description("Readonly")]
        Readonly = 0,
        /// <summary>
        /// 可修改
        /// </summary>
        [Description("Modify")]
        Modify = 1,
        /// <summary>
        /// 管理
        /// </summary>
        [Description("Admin")]
        Admin = 2,



    }
}
