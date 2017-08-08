//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Lemonade.Frame.Running;
//using System.Reflection;
//using Lemonade.Frame;
//using System.ComponentModel;
//using System.Drawing;
//using System.Windows.Forms;  


//namespace Lemonade.Action.MapCtrlContext
//{
//    /// <summary>
//    /// 事件动作上下文
//    /// </summary>
//    public class EventContext  : IActionContext
//    {
//        Dictionary<object, List<IAction>> actions = new Dictionary<object, List<IAction>>();

//        /// <summary>
//        /// 
//        /// </summary>
//        public EventContext()
//        { 
            
//        }

//        /// <summary>
//        /// 当前上下文处理的对象类型
//        /// </summary>
//        public Type ContextProcessType
//        {
//            get;
//            set;
//        }

         
//        /// <summary>
//        /// 激活
//        /// </summary>
//        public void Activate()
//        {
//            foreach (object mc in this.actions.Keys)
//            {
//                foreach (IAction ac in this.actions[mc])
//                {
//                    RemoveHandler(ac);
//                }
//                CheckUp(mc); 
//            }
//        }



//        /// <summary>
//        /// 添加动作
//        /// </summary>
//        /// <param name="Action"></param>
//        public void AddAction(IAction Action)
//        {
//            if (Action != null)
//            {
//                if (this.ContextProcessType == Lemon.GetObjType(Action.InvokeObject))
//                {
//                    var ik = this.actions.Keys.ToList().Find(delegate(object mc) { return mc == Action.InvokeObject; });
//                    if (ik != null)
//                    { 
//                        var qac=this.actions[ik].ToList().Find(delegate(IAction ac){return ac.InvokeProcessor==Action.InvokeProcessor;});
//                        if (qac != null)
//                        {
//                            this.actions[ik].Remove(qac);
//                        }
//                        this.actions[ik].Add(Action);
//                    }
//                    else
//                    {
//                        List<IAction> newList = new List<IAction>();
//                        newList.Add(Action);
//                        this.actions.Add((object)Action.InvokeObject, newList);
//                    }
//                }
//            }
            
//        }
//        /// <summary>
//        /// 根据指定参数获取索引指定的动作对象
//        /// </summary>
//        /// <param name="InvokeObject"></param>
//        /// <param name="AcIndex"></param>
//        /// <returns></returns>
//        public IAction this[object InvokeObject,int AcIndex]
//        { 
//            get{
//                return this.actions[(object)InvokeObject][AcIndex];
//            }
//        }

//        /// <summary>
//        /// 获取动作数量
//        /// </summary>
//        public int GetActionCount(object InvokeObject)
//        {
//            if (this.actions.ContainsKey(InvokeObject))
//            {
//                return this.actions[(object)InvokeObject].Count;
//            }
//            else
//            {
//                return 0;
//            }
            
//        }
//        /// <summary>
//        /// 获取调用者数量
//        /// </summary>
//        public int GetInvokeObjectCount
//        {
//            get {
//                return this.actions.Keys.Count;
//            }
//        }
//        /// <summary>
//        /// 获取调用者对象
//        /// </summary>
//        /// <param name="Index"></param>
//        /// <returns></returns>
//        public object this[int Index]
//        {
//            get {

//                return this.actions.Keys.ToList()[Index];
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        protected virtual List<Delegate> FindHandler(object McObject)
//        {  
//            List<Delegate> result = new List<Delegate>();
//            List<Delegate> resultSingle=new List<Delegate>();
//            List<Delegate> resultSequence=new List<Delegate>();
//            foreach (IAction act in this.actions[(object)McObject])
//            {
//                if (act.Type == ActionType.Single)
//                {
//                    resultSingle.Add(act.InvokeProcessor);
//                }
//                else if (act.Type == ActionType.Sequence)
//                {
//                    resultSequence.Add(act.InvokeProcessor);
//                }
//            }
//            if (resultSequence.Count == 0)
//            {
//                if (resultSingle.Count > 0)
//                {
//                    result.Add(resultSingle[resultSingle.Count-1]);
//                }
//            }
//            else 
//            {
//                result.AddRange(resultSequence);
//                if (resultSingle.Count > 0)
//                {
//                    result.Add(resultSingle[resultSingle.Count - 1]);
//                }
//            }
//            return result;
//        }

//        /// <summary>
//        /// 登记处理者
//        /// </summary>
//        protected virtual void CheckUp(object McObject)
//        {  
//            //查找要注册的处理器 
//            foreach(Delegate delg in this.FindHandler(McObject))
//            {
//                var act = this.actions[(object)McObject].ToList().Find(delegate(IAction ac) { return ac.InvokeProcessor == delg; });
//                if (act != null)
//                {
//                    Lemon.GetObjType(McObject).GetEvent(act.ActionName).AddEventHandler(McObject, delg);
//                }
//            }  
//        }

//        /// <summary>
//        /// 清理处理者
//        /// </summary>
//        /// <param name="Action"></param>
//        protected virtual void RemoveHandler(IAction Action)
//        { 
//            ///获取当前事件的处理器
//            Delegate[] invokeList = GetEventList(Action.InvokeObject, Action.ActionName, Action.InvokeProcessor); 
//            if (invokeList != null)
//            {
//                //移除所有处理器
//                foreach (Delegate del in invokeList)
//                {
//                    Lemon.GetObjType(Action.InvokeObject).GetEvent(Action.ActionName).RemoveEventHandler(Action.InvokeObject, del);
//                }
//            } 
            
//        }

//        /// <summary>
//        /// 获取对象事件 
//        /// </summary>
//        /// <param name="p_Object">对象</param>
//        /// <param name="p_EventName">事件名</param>
//        /// <returns>委托列</returns>
//        public Delegate[] GetObjectEventList1(object p_Object, string p_EventName)
//        {
//            System.Reflection.FieldInfo _Field = p_Object.GetType().GetField(p_EventName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
//            if (_Field == null)
//            {
//                return null;
//            }
//            object _FieldValue = _Field.GetValue(p_Object);

//            if (_FieldValue != null && _FieldValue is Delegate)
//            {
//                Delegate _ObjectDelegate = (Delegate)_FieldValue;
//                return _ObjectDelegate.GetInvocationList();
//            }
//            return null;
//        }

//        /// <summary>
//        /// 获取控件事件 
//        /// </summary>
//        /// <param name="p_Control">对象</param>
//        /// <param name="p_EventName">事件名 EventClick EventDoubleClick </param>
//        /// <returns>委托列</returns>
//        public Delegate[] GetObjectEventList2(Control p_Control, string p_EventName)
//        {
//            PropertyInfo _PropertyInfo = p_Control.GetType().GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
//            if (_PropertyInfo != null)
//            {
//                object _EventList = _PropertyInfo.GetValue(p_Control, null);
//                if (_EventList != null && _EventList is EventHandlerList)
//                {
//                    EventHandlerList _List = (EventHandlerList)_EventList;
//                    FieldInfo _FieldInfo = (typeof(Control)).GetField(p_EventName, BindingFlags.Static | BindingFlags.NonPublic);
//                    if (_FieldInfo == null) return null;
//                    Delegate _ObjectDelegate = _List[_FieldInfo.GetValue(p_Control)];
//                    if (_ObjectDelegate == null) return null;
//                    return _ObjectDelegate.GetInvocationList();
//                }
//            }
//            return null;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="p_Object"></param>
//        /// <param name="p_EventName"></param>
//        /// <param name="p_EventType"></param>
//        /// <returns></returns>
//        public static Delegate[] GetObjectEventList(object p_Object, string p_EventName, Type p_EventType)
//        {
//            PropertyInfo _PropertyInfo = p_Object.GetType().GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
//            if (_PropertyInfo != null)
//            {
//                object _EventList = _PropertyInfo.GetValue(p_Object, null);
//                if (_EventList != null && _EventList is EventHandlerList)
//                {
//                    EventHandlerList _List = (EventHandlerList)_EventList;
//                    FieldInfo _FieldInfo = p_EventType.GetField(p_EventName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
//                    if (_FieldInfo == null) return null;
//                    Delegate _ObjectDelegate = _List[_FieldInfo.GetValue(p_Object)];
//                    if (_ObjectDelegate == null) return null;
//                    return _ObjectDelegate.GetInvocationList();
//                }
//            }
//            return null;
//        }

//        /// <summary>
//        /// 根据处理者获取字段信息
//        /// </summary>
//        /// <param name="TypeObj"></param>
//        /// <returns></returns>
//        protected virtual List<FieldInfo> GetFieldInfos(Type TypeObj)
//        {
//            List<FieldInfo> result = new List<FieldInfo>(); 
//            //FieldInfo[] fieldInfos = TypeObj.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);

//            FieldInfo[] fieldInfos = TypeObj.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
//            result.AddRange(fieldInfos);
//            if (TypeObj != typeof(object))
//            {
//                result.AddRange(GetFieldInfos(TypeObj.BaseType));
//            } 
//            return result;
//        }

//        /// <summary>
//        /// 获取控件事件 
//        /// </summary>
//        /// <param name="p_Control">对象</param>
//        /// <param name="p_EventName">事件名 EventClick EventDoubleClick </param>
//        /// <returns>委托列</returns>
//        protected virtual Delegate[] GetEventList(object Contl, string EventName,Delegate InvokeProcess)
//        {
//            List<Delegate> result = new List<Delegate>();
//            BindingFlags mPropertyFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Static;
 
//            //PropertyInfo propertyInfo = Lemon.GetObjType(Contl).GetProperty("Events", BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
//            Type type = Lemon.GetObjType(Contl);
//            PropertyInfo propertyInfo = type.GetProperty("Events", mPropertyFlags);
//            if (propertyInfo != null)
//            {
//                object eventList = propertyInfo.GetValue(Contl, null);
//                if (eventList != null && eventList is EventHandlerList)
//                {
//                    //所有事件
//                    EventHandlerList list = (EventHandlerList)eventList; 
//                    //FieldInfo[] fieldInfos = Lemon.GetObjType(Contl).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase);

//                    FieldInfo[] fieldInfos = GetFieldInfos(Lemon.GetObjType(Contl)).ToArray();
//                    //判断是否是要找的
//                    foreach (FieldInfo fi in fieldInfos)
//                    { 
//                        Delegate d = list[fi.GetValue(Contl)];
//                        if (d != null)
//                        {
//                            foreach (Delegate del in d.GetInvocationList())
//                            {
//                                if (del == InvokeProcess)
//                                {
//                                    result.Add(del);
//                                }
//                                //Console.WriteLine(del.Method.Name);
//                            }
//                        }
//                    }


//                    //foreach (FieldInfo fi in fieldInfos)
//                    //{
//                    //    if (fi.Name.IndexOf(EventName) > -1)
//                    //    {
//                    //        object _FieldValue = fi.GetValue(Contl);
//                    //        if (_FieldValue != null && _FieldValue is Delegate)
//                    //        {
//                    //            Delegate _ObjectDelegate = (Delegate)_FieldValue;
//                    //            result = _ObjectDelegate.GetInvocationList();
//                    //        }
//                    //    }
//                    //}

//                }
//            }
//            return result.ToArray();
//        }

//         /// <summary>
//         /// 获取参数指定的上下文的调用者索引
//         /// </summary>
//         /// <param name="InvokeObject"></param>
//         /// <returns></returns>
//        public int GetInvokeObjectIndex(object InvokeObject)
//        {
//            int result = -1;
//            if (Lemon.GetObjType(InvokeObject) == typeof(object))
//            {
//                result = this.actions.Keys.ToList().IndexOf((object)InvokeObject);
//            }

//            return result;
//        }

//        /// <summary>
//        /// 移除动作
//        /// </summary>
//        /// <param name="Action"></param>
//        public void RemoveAction(IAction Action)
//        {
//            if (Action != null)
//            {
//                if (this.ContextProcessType == Lemon.GetObjType(Action.InvokeObject))
//                {
//                    var ik = this.actions.Keys.ToList().Find(delegate(object mc) { return mc == Action.InvokeObject; });
//                    if (ik != null)
//                    {
//                        this.RemoveHandler(Action);
//                        if (Action.Performer != null)
//                        {
//                            Action.Performer(Action.InvokeObject);
//                        }
//                        this.actions[ik].Remove(Action);
//                    }
//                }
//            }
//        }

 
//        /// <summary>
//        /// 判断是否是指定动作类型的上下文
//        /// 当前是处理事件的上下文所以这个检查是否存在这个上下文
//        /// </summary>
//        /// <param name="Action"></param>
//        /// <returns></returns>
//        public bool IsAdapterAction(IAction Action)
//        {
//            if (Lemon.GetObjType(Action.InvokeObject).GetEvent(Action.ActionName) != null)
//            {
//                return true;
//            }
//            return false;
//        }
//    }
//}
