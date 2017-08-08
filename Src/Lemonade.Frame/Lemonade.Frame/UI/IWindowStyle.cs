using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// 设置窗口样式委托
    /// </summary>
    /// <param name="TargetForm"></param>
    ///  <param name="MainForm"></param>
    ///  <param name="Manager"></param>
    public delegate void SetWindowStyle(Form TargetForm, Form MainForm,ILayoutManager Manager);

    /// <summary>
    /// 窗口设计接口,实现该接口的类用于定义窗口的样式 。
    /// 在布局之外管理窗口位置等信息，该接口在Styles文件夹下自动加载
    /// </summary>
    public interface IWindowStyle
    {
        /// <summary>
        /// 窗体名称
        /// </summary>
        string FormName { get; set; }
        /// <summary>
        /// 窗体的类全名
        /// </summary>
        string FormClassFullName { get; set; }
        /// <summary>
        /// 作废的-----判断是否使用当前样式处理
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <returns></returns>
        bool IsUse(Form TargetForm);
        /// <summary>
        /// 设置窗口
        /// </summary>
        bool SetWindows(Form TargetForm,ILayoutManager Manager);
         
    }
}
