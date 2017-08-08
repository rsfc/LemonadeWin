using System;
namespace Lemonade.Frame.Menu
{
    /// <summary>
    /// cs菜单项接口 
    /// </summary>
    public interface IPtMenuItem : IMenuItem
    {
        /// <summary>
        /// 程序集路径
        /// </summary>
        string AssemblyPath { get; set; }
        /// <summary>
        /// 类全名
        /// </summary>
        string FullClassName { get; set; } 
    }
}
