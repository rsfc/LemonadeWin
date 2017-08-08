using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO; 

namespace Lemonade.Frame.Menu 
{
    /// <summary>
    /// 菜单项目工厂接口
    /// </summary>
    public interface IMenuItemFactory
    { 
        /// <summary>
        /// 创建菜单项目
        /// </summary> 
        /// <returns></returns>
        Dictionary<string, PtMenuItem> CreateMenuItems();
         
        /// <summary>
        /// 主窗体
        /// </summary>
        IMainForm Mainform { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IEventBinder Eventbinder { get; set; }
    }
}
