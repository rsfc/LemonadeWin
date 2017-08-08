using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// 设置内容
    /// </summary>
    /// <param name="Content"></param>
    public delegate void SetContent(object Content);
    /// <summary>
    /// 设置动作
    /// </summary>
    public delegate void SetActive();
     
     

    /// <summary>
    /// 启动加载系统模块接口
    /// </summary>
    public interface ILoadSystem : Lemonade.Frame.Design.ISubject
    {
        
        /// <summary>
        /// 前置处理事件
        /// </summary>
        event SetActive Prepose; 
        /// <summary>
        /// 开始动作
        /// </summary>
        void StartProcess();  
        /// <summary>
        /// 完成结束操作方法
        /// </summary>
        void Finish();
    }
}
