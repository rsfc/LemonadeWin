using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lemonade.Frame.Running
{
    /// <summary>
    /// 动作接口管理器，以对象为基础和索引
    /// </summary>
    public  interface IActionManager
    {
        /// <summary>
        /// 加载动作上下文
        /// </summary>
        void LoadActionsContext();
        ///// <summary>
        ///// 判断是否包含指定的调用者
        ///// </summary>
        ///// <param name="InvokeObject"></param>
        ///// <returns></returns>
        //bool HasInvokeObject(object InvokeObject);
        /// <summary>
        /// 获取调用的动作数量
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <returns></returns>
        int GetActionCount(object InvokeObject);
        /// <summary>
        /// 是否包含动作
        /// </summary>
        /// <param name="ActionName"></param>
        /// <param name="Type"></param>
        /// <param name="InvokeObject"></param>
        /// <param name="InvokeProcessor"></param>
        /// <param name="Performer"></param>
        /// <returns></returns>
        bool HasAction(string ActionName, ActionType Type, object InvokeObject, Delegate InvokeProcessor, ActionPerformer Performer);
        /// <summary>
        /// 创建动作
        ///  <param name="InvokeObject"></param>
        /// <param name="Type"></param>
        /// <param name="ActionName"></param>
        /// <param name="InvokeProcessor">处理过程</param>
        /// <param name="Performer"></param>
        /// </summary>
        bool CreateAction(string ActionName, ActionType Type, object InvokeObject, Delegate InvokeProcessor, ActionPerformer Performer);
        /// <summary>
        /// 激活指定调用者的动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        void ActionActivate(object InvokeObject);
        /// <summary>
        /// 移除所有动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <returns></returns>
        bool RemoveAll(object InvokeObject);
        /// <summary>
        /// 移除指定名称的动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <returns></returns>
        bool Remove(object InvokeObject, string ActionName); 
        /// <summary>
        /// 移除指定名称和类型的动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        bool Remove(object InvokeObject, string ActionName, ActionType Type);

        /// <summary>
        /// 移除指定处理过程的动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <param name="InvokeProcessor"></param>
        /// <returns></returns>
        bool Remove(object InvokeObject, string ActionName, Delegate InvokeProcessor);
    }
}
