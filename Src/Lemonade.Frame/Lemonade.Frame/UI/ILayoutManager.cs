using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// 界面布局管理器接口
    /// </summary>
    public interface ILayoutManager
    {
        /// <summary>
        /// 当前的界面布局名称
        /// </summary>
        string CurrentLayoutName { get; }
        /// <summary>
        /// 获取当前框架使用的布局
        /// </summary>
        ILayout GetLayout(string LayoutName);
        /// <summary>
        /// 获取所有的布局名称
        /// </summary>
        List<string> LayoutNames { get; }
        /// <summary>
        /// 获取窗体设置器数量
        /// </summary>
        int WindowStyleCount { get; }
        /// <summary>
        /// 获取布局设计器数量
        /// </summary>
        int LayoutDesignCount { get; }
        /// <summary>
        /// 设置窗体样式,对参数传递的窗体是用所有的窗体设置器进行设置
        /// </summary>
        bool SetLayoutWindow(Form TargetForm);
        /// <summary>
        /// 根据布局名称样式进行样式设置
        /// </summary>
        void SetLayout(string LayoutName);
        /// <summary>
        /// 取消当前布局
        /// </summary> 
        void CancelLayout(); 
        /// <summary>
        /// 获取窗体样式参数
        /// </summary>
        StylePar GetStyleParameter(string WindowClassFullName);
        /// <summary>
        /// 获取当前布局中受控窗体名称集合
        /// </summary>
        List<string> GetControlleds { get; }
         

    }
}
