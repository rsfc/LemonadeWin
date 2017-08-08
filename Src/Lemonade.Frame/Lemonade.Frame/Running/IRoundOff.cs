using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Running
{
    /// <summary>
    /// 扫尾操作
    /// </summary> 
    /// <returns></returns>
    public delegate bool RoundOpration();
    /// <summary>
    /// 框架扫尾接口，框架屏蔽系统提供的关闭方法，由扫尾接口提供关闭功能
    /// </summary>
    public interface IRoundOff
    {
        /// <summary>
        /// 添加扫尾操作
        /// </summary>
        /// <param name="Opration"></param>
        /// <returns></returns>
        int AddOpration(RoundOpration Opration);
        /// <summary>
        /// 主窗体对象
        /// </summary>
        IMainForm MainForm { get; set; }
        /// <summary>
        /// 退出系统
        /// </summary>
        void SystemExit();
    }
}
