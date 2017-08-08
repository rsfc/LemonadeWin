using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Message;
using Lemonade.Frame.Solon;
using Lemonade.Frame.Running;

namespace Lemonade.Frame
{
    /// <summary>
    /// 框架通用功能入口
    /// </summary>
    public static partial class Lemon
    {
        
        #region 动作

        /// <summary>
        /// 激活指定调用者的动作
        /// </summary>
        /// <param name="InvokeObject">调用者</param>
        public static void ActionActivate(object InvokeObject)
        {
            LemonEnvironment.GetInstance().ActionsManager.ActionActivate(InvokeObject);

        }

        /// <summary>
        /// 使用框架动作管理器向调用者添加动作，自动响应内置的动作处理机制，注册后自动激活动作
        /// </summary>
        /// <param name="InvokeObject">调用者</param>
        /// <param name="ActionName">动作名称</param>
        /// <param name="Type">动作类型</param>
        /// <param name="InvokeProcessor">处理者</param>
        /// <param name="Performer">在动作注销时执行的委托</param>
        public static bool ActionAppend(object InvokeObject, string ActionName, ActionType Type, Delegate InvokeProcessor, ActionPerformer Performer = null)
        {
            bool isCup = LemonEnvironment.GetInstance().ActionsManager.CreateAction(ActionName, Type, InvokeObject, InvokeProcessor, Performer);
           if (isCup)
           {
               Lemon.ActionActivate(InvokeObject);
           }
           return isCup;
        }

        /// <summary>
        /// 使用框架动作管理器向调用者添加动作，单独执行的
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <param name="InvokeProcessor"></param>
        /// <param name="Performer"></param>
        public static void ActionAppendSingle(this object InvokeObject, string ActionName, Delegate InvokeProcessor, ActionPerformer Performer = null)
        {
            Lemon.ActionAppend(InvokeObject, ActionName, ActionType.Single, InvokeProcessor, Performer);
        }

        /// <summary>
        /// 使用框架动作管理器向调用者添加动作，按顺序执行的多个执行
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <param name="InvokeProcessor"></param>
        /// <param name="Performer"></param>
        public static void ActionAppendMulti(this object InvokeObject, string ActionName, Delegate InvokeProcessor, ActionPerformer Performer=null)
        {
            Lemon.ActionAppend(InvokeObject, ActionName, ActionType.Sequence, InvokeProcessor, Performer);
        }
        /// <summary>
        /// 从调用者上移除所有的动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <returns></returns>
        public static bool ActionAll(object InvokeObject)
        {
            return LemonEnvironment.GetInstance().ActionsManager.RemoveAll(InvokeObject);
        }
        /// <summary>
        /// 从调用者上移除指定名称的所有类型的动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <returns></returns>
        public static bool ActionRemove(object InvokeObject, string ActionName)
        { 
            return LemonEnvironment.GetInstance().ActionsManager.Remove(InvokeObject, ActionName);

        }
        /// <summary>
        /// 从调用者上移除指定名称和类型的动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public static bool ActionRemove(object InvokeObject, string ActionName, ActionType Type)
        {
            return LemonEnvironment.GetInstance().ActionsManager.Remove(InvokeObject, ActionName, Type);
        }

        /// <summary>
        /// 从调用者上移除指定名称和类型的动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <param name="InvokeProcessor"></param>
        /// <returns></returns>
        public static bool ActionRemove(object InvokeObject, string ActionName, Delegate InvokeProcessor)
        { 
            return LemonEnvironment.GetInstance().ActionsManager.Remove(InvokeObject, ActionName, InvokeProcessor);
        }
        /// <summary>
        /// 判断指定的调用者上是否存在参数的动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <param name="InvokeProcessor"></param>
        /// <returns></returns>
        public static bool HasAction(object InvokeObject, string ActionName, ActionType Type, Delegate InvokeProcessor)
        {
            bool result = LemonEnvironment.GetInstance().ActionsManager.HasAction(ActionName, Type, InvokeObject, InvokeProcessor, null);
             

            return result;
        }


        #endregion
    }
}
