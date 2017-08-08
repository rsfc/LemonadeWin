using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// 布局设计接口
    /// </summary>
    public interface ILayout
    {
        /// <summary>
        /// 布局名称
        /// </summary>
        string LayoutName { get; }
        /// <summary>
        /// 创建布局
        /// </summary>
        /// <param name="MainForm"></param>
        void CreateLayout(IMainForm MainForm);
        /// <summary>
        /// 设置窗体样式
        /// </summary>
        bool SetLayoutForm(Form TargetForm);
        /// <summary>
        /// 取消布局
        /// </summary>
        void CancelLayout(); 
        ///// <summary>
        ///// 保存布局
        ///// </summary>
        ///// <param name="MainForm"></param>
        //void SaveLayout(IMainForm MainForm);

        /// <summary>
        /// 受控制的窗体名称
        /// </summary>
        List<string> Controlleds { get; }
    }
}
