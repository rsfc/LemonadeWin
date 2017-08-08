using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Running
{
    /// <summary>
    /// 框架动作上下文接口，在框架内任何操作、执行过程、命令都可以抽象为该接口
    /// 该接口与ui类似是高层次的逻辑抽象，可以在戒灵机制下扩展
    /// </summary>
    public  interface IActionContext
    {
        /// <summary>
        /// 判断是否是指定动作类型的上下文
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        bool IsAdapterAction(IAction Action);
        /// <summary>
        /// 激活上下文中的操作
        /// </summary>
        void Activate();
        /// <summary>
        /// 向上下文添加动作
        /// </summary>
        void AddAction(Lemonade.Frame.Running.IAction Action);
        /// <summary>
        /// 移除向上下文动作
        /// </summary>
        void RemoveAction(Lemonade.Frame.Running.IAction Action);
        /// <summary>
        /// 当前上下的处理对象类型
        /// </summary>
        Type ContextProcessType { get; set; }
        /// <summary>
        /// 获取指定调用者的动作数量
        /// </summary>
        int GetActionCount(object InvokeObject);
        /// <summary>
        /// 获取调用者数量
        /// </summary>
        int GetInvokeObjectCount { get; }
        /// <summary>
        /// 获取指定索引的调用者
        /// </summary>
        object this[int Index] { get; }
        /// <summary>
        /// 获取指定调用者和索引的动作
        /// </summary>
        Lemonade.Frame.Running.IAction this[object InvokeObject, int AcIndex] { get; }
        /// <summary>
        /// 获取指定参数实例的调用者在上下文中的索引 不包含返回-1
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <returns></returns>
        int GetInvokeObjectIndex(object InvokeObject);
 
         
    }
}
