using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lemonade.Frame.Tools
{
    /// <summary>
    /// 工具栏管理器
    /// </summary>
    public interface IToolsBarManager
    { 
        /// <summary>
        /// 获取工具栏名称列表
        /// </summary>
        List<string> ToolsBarNames { get; } 
        /// <summary>
        /// 工具栏所在窗体名称集合
        /// </summary>
        List<string> ParentFormNames { get; } 
        /// <summary>
        /// 工具栏总数
        /// </summary>
        int ToolsBarCount { get; }
        /// <summary>
        /// 获取指定索引的工具栏
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        IToolsBar  this[int Index] { get; }
        /// <summary>
        /// 加载工具栏
        /// </summary>
        void LoadToolsBar();
        /// <summary>
        /// 工具栏添加到
        /// </summary>
        void CreateToolsBarToForm(Form TargetForm);
        /// <summary>
        /// 根据分组名称获取整组项
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        List<IToolsItem> GetGroupItem(string GroupName);

        /// <summary>
        /// 获取全部工具栏项
        /// </summary>
        /// <returns></returns>
        List<IToolsItem> GetItemAll();
    }
}
