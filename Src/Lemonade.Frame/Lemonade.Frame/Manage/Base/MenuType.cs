using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace Lemonade.Frame.Manage.Base
{ 
    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuType : int
    {
        /// <summary>
        /// C/S，用于 C/S客户端的菜单数据记录
        /// </summary>
        [Description("CS")]
        CS = 0,
        /// <summary>
        /// B/S，用于B/S客户端的菜单数据记录
        /// </summary>
        [Description("BS")]
        BS = 1, 

    }
}
