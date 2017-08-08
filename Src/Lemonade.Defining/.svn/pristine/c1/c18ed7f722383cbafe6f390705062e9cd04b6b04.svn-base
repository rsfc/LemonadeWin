using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Running;
using Lemonade.Frame;
namespace Lemonade.Action
{
    /// <summary>
    /// 动作实现
    /// </summary>
    public class Action:IAction
    {
        /// <summary>
        /// 
        /// </summary>
        string name = "";
        /// <summary>
        /// 
        /// </summary>
        Delegate processor=null;
        /// <summary>
        /// 
        /// </summary>
        ActionPerformer performer = null;
        /// <summary>
        /// 
        /// </summary>
        ActionType type = ActionType.Single;
        /// <summary>
        /// 
        /// </summary>
        object invokobject = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InvokeObject"></param>
        /// <param name="Name"></param>
        /// <param name="Type"></param>
        /// <param name="Processor"></param>
        /// <param name="Performer"></param>
        public Action(object InvokeObject, string Name,ActionType Type,Delegate Processor,ActionPerformer Performer)
        { 
            this.name = Name;
            this.type = Type;
            this.processor = Processor;
            this.invokobject = InvokeObject;
            this.performer = Performer;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ActionName
        {
            get { 
                return this.name;
            }
        }
        /// <summary>
        /// 调用者处理器
        /// </summary>
        public Delegate InvokeProcessor
        {
            get {
                return this.processor;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ActionType Type
        {
            get {
                return this.type;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object InvokeObject
        {
            get { return this.invokobject; }
        }

        /// <summary>
        /// 解除处理器
        /// </summary>
        public ActionPerformer Performer
        {
            get { return this.performer; }
        }

 
    }
}
