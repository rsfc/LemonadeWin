using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// 等待程序处理接口
    /// </summary>
    public interface IWaitingProgram
    {
        /// <summary>
        /// 设置等待对话内容
        /// </summary>
        /// <param name="Content"></param>
        void SetContent(string Content);
        /// <summary>
        /// 显示对话界面
        /// </summary>
        void ShowDialog();
        /// <summary>
        /// 关闭
        /// </summary>
        void CloseDialog();
        /// <summary>
        /// 设置显示的窗体 暂时不抽象等待窗体对象
        /// </summary>
        /// <param name="WaitingForm"></param>
        void SetForm(IWaitionForm WaitingForm);
    }
}
