using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Running;
using Lemonade.Frame;
using System.IO;


namespace Lemonade.Action
{
    /// <summary>
    /// 动作管理器
    /// </summary>
    public class ActionManager : IActionManager
    {
        /// <summary>
        /// 上下文模板集合
        /// </summary>
        List<IActionContext> contexttemplates = new List<IActionContext>();
        /// <summary>
        /// 上下文实例集合
        /// </summary>
        List<IActionContext> contexts = new List<IActionContext>();
        ///// <summary>
        ///// 是否已经存在调用者对象
        ///// </summary>
        ///// <param name="InvokeObject"></param>
        ///// <returns></returns>
        //public bool HasInvokeObject(object InvokeObject)
        //{
        //    bool result = false;
        //    var f = this.contexts.Find(delegate(IActionContext ac) { return ac.GetInvokeObjectIndex(InvokeObject) > -1; });
        //    if (f != null)
        //    {
        //        result = true;
        //    }
        //    return result;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ActionName"></param>
        /// <param name="Type"></param>
        /// <param name="InvokeObject"></param>
        /// <param name="InvokeProcessor"></param>
        /// <param name="Performer"></param>
        /// <returns></returns>
        public bool HasAction(string ActionName, ActionType Type, object InvokeObject, Delegate InvokeProcessor, ActionPerformer Performer = null)
        {
            IAction newAction = new Action(InvokeObject, ActionName, Type, InvokeProcessor, Performer);
            IActionContext context = this.MatcherContext(newAction);
            if (context == null)
            {
                return false;
            }
            else
            {
                
                if (context.GetInvokeObjectIndex(InvokeObject) > -1)
                {
                    int account = context.GetActionCount(InvokeObject);
                    if (account > 0)
                    {
                        for (int i = 0; i < account; i++)
                        {
                            IAction tmpac= context[InvokeObject, i];
                            if (tmpac != null)
                            {
                                if (tmpac.ActionName == ActionName
                                    && tmpac.InvokeProcessor == InvokeProcessor)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
                //context.
            }
        }
        /// <summary>
        ///  获取指定调用者的动作数量
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <returns></returns>
        public int GetActionCount(object InvokeObject)
        {
            int result = 0;
            var f = this.contexts.Find(delegate(IActionContext ac) { return ac.GetInvokeObjectIndex(InvokeObject) > -1; });

            if (f != null)
            {
                result = f.GetActionCount(InvokeObject);
            }
            return result;
        }
     
        /// <summary>
        /// 创建动作
        /// </summary>
        /// <param name="ActionName">动作名称</param>
        /// <param name="Type">动作类型</param>
        /// <param name="InvokeObject">调用的对象</param>
        /// <param name="InvokeProcessor">对象处理者委托</param>
        /// <param name="Performer">注销动作时的回调函数</param>
        /// <returns></returns>
        public bool CreateAction(string ActionName, ActionType Type, object InvokeObject, Delegate InvokeProcessor, ActionPerformer Performer=null)
        {
            bool iscmp = false;
            IAction newAction = new Action(InvokeObject, ActionName, Type, InvokeProcessor, Performer);
            //查找是否已经存在上下文
            var f = this.contexts.Find(delegate(IActionContext ac) { return ac.ContextProcessType == Lemon.GetObjType(InvokeObject); });
            if (f == null)
            { 
                //不存在则创建新的
                if (this.contexttemplates.Count > 0)
                {
                    //创建新的上下文
                    IActionContext newAc = Lemon.GetInstance<IActionContext>(Lemon.GetObjType(this.MatcherContextTemplate(newAction)));
                    newAc.ContextProcessType = Lemon.GetObjType(InvokeObject);
                    f = newAc;
                    //加入上下文实例的集合
                    this.contexts.Add(f);
                }
            }
            if (f != null)
            {  
                //判断是否是单一动作
                if (newAction.Type == Lemonade.Frame.Running.ActionType.Single)
                {
                    this.Remove(newAction.InvokeObject, newAction.ActionName, ActionType.Single);
                }
                else
                {
                    f.RemoveAction(newAction);
                }  
                f.AddAction(newAction);
                iscmp = true;
            }

            return iscmp;
        }

        /// <summary>
        /// 从模版中查找匹配的上下文对象实例,创建运行上下文
        /// </summary>
        protected virtual IActionContext MatcherContextTemplate(IAction Action)
        {
            IActionContext result    = null;
            foreach (IActionContext context in this.contexttemplates)
            {
                if (context.IsAdapterAction(Action))
                {
                    result = context;
                }
            }
            return result;
        }

        /// <summary>
        /// 从已经运行的上下文中查找匹配的上下文对象实例
        /// </summary>
        protected virtual IActionContext MatcherContext(IAction Action)
        {
            IActionContext result = null;
            foreach (IActionContext context in this.contexts)
            {
                if (context.IsAdapterAction(Action))
                {
                    result = context;
                }
            }
            return result;
        }

        /// <summary>
        /// 加载动作上下文处理器到模板
        /// </summary>
        /// <returns></returns>
        public void LoadActionsContext()
        {
            string styledir = Lemon.GetCSFRootDirectory() + @"\Actions\";
            this.contexttemplates = Lemon.FindInstanceFromDirectory<IActionContext>(styledir, false);
        }


        /// <summary>
        /// 激活动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        public void ActionActivate(object InvokeObject)
        {
            foreach (IActionContext context in this.contexts)
            {
                if (context.ContextProcessType == Lemon.GetObjType(InvokeObject))
                {
                    context.Activate();
                }
            }
        }
         
        /// <summary>
        /// 移除全部动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <returns></returns>
        public bool RemoveAll(object InvokeObject)
        {
            bool iscmp = false;
            var f = this.contexts.Find(delegate(IActionContext ac) { return ac.GetInvokeObjectIndex(InvokeObject) > -1; });
            if (f == null)
            {
                //获取同类型的上下文
                f = this.contexts.Find(delegate(IActionContext ac) { return ac.ContextProcessType == Lemon.GetObjType(InvokeObject); });
            }
            if (f != null)
            {
                List<IAction> tmpac = new List<IAction>();
                for (int i = 0; i < f.GetActionCount(InvokeObject); i++)
                {
                    tmpac.Add(f[InvokeObject, i]); 
                }
                foreach (IAction tmpiac in tmpac)
                {
                    f.RemoveAction(tmpiac);
                }
                if (f.GetActionCount(InvokeObject) == 0)
                {
                    iscmp = true;
                }

            } 
            return iscmp;
        }
        /// <summary>
        /// 移除指定名称的所有类型的动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <returns></returns>
        public bool Remove(object InvokeObject, string ActionName)
        {
            bool iscmp = false;
            var f = this.contexts.Find(delegate(IActionContext ac) { return ac.GetInvokeObjectIndex(InvokeObject) > -1; });
            if (f == null)
            {
                //获取同类型的上下文
                f = this.contexts.Find(delegate(IActionContext ac) { return ac.ContextProcessType == Lemon.GetObjType(InvokeObject); });
            }
            if (f != null)
            {
                List<IAction> tmpac = new List<IAction>();
                for (int i = 0; i < f.GetActionCount(InvokeObject); i++)
                {
                    tmpac.Add(f[InvokeObject, i]);
                }
                foreach (IAction tmpiac in tmpac)
                { 
                    f.RemoveAction(tmpiac);
                    iscmp = true; 
                }
            } 
            return iscmp;
        }

        /// <summary>
        /// 移除指定类型的动作
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public bool Remove(object InvokeObject, string ActionName, ActionType Type)
        {
            bool iscmp = false;
            var f = this.contexts.Find(delegate(IActionContext ac) { return ac.GetInvokeObjectIndex(InvokeObject) > -1; });
            if (f == null)
            {
                //获取同类型的上下文
                f = this.contexts.Find(delegate(IActionContext ac) { return ac.ContextProcessType == Lemon.GetObjType(InvokeObject); });
            }
            if (f != null)
            {
                List<IAction> tmpac = new List<IAction>();
                for (int i = 0; i < f.GetActionCount(InvokeObject); i++)
                {
                    tmpac.Add(f[InvokeObject, i]);
                }
                foreach (IAction tmpiac in tmpac)
                {
                    if (tmpiac.ActionName == ActionName && tmpiac.Type == Type)
                    {
                        f.RemoveAction(tmpiac);
                        iscmp = true;
                    }
                }
            } 
            return iscmp;
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="ActionName"></param>
        /// <param name="InvokeProcessor"></param>
        /// <returns></returns>
        public bool Remove(object InvokeObject, string ActionName, Delegate InvokeProcessor)
        {
            bool iscmp = false;
            var f = this.contexts.Find(delegate(IActionContext ac) { return ac.GetInvokeObjectIndex(InvokeObject) > -1; });
            if (f == null)
            {
                //获取同类型的上下文
                f = this.contexts.Find(delegate(IActionContext ac) { return ac.ContextProcessType == Lemon.GetObjType(InvokeObject); });
            }
            if (f != null)
            {
                List<IAction> tmpac = new List<IAction>();
                for (int i = 0; i < f.GetActionCount(InvokeObject); i++)
                {
                    tmpac.Add(f[InvokeObject, i]);
                }
                foreach (IAction tmpiac in tmpac)
                {
                    if (tmpiac.ActionName == ActionName && tmpiac.InvokeProcessor == InvokeProcessor)
                    {
                        f.RemoveAction(tmpiac);
                        iscmp = true;
                    }
                }
            }
            //this.ActionActivate(InvokeObject);
            return iscmp;
        }


      
         
    }
}
