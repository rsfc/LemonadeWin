using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Message;
using Lemonade.Frame.Solon;
using Lemonade.Frame.Running;

namespace Lemonade.Frame.Message
{
    /// <summary>
    /// 消息处理过程的设置工厂，框架在消息响应上封装了支撑类库的类型
    /// </summary>
    internal class ProcessFactory
    {
        private static ProcessFactory pfobj=null;
        protected Dictionary<IMsgProcess, IProcessor> processList = new Dictionary<IMsgProcess, IProcessor>();
        /// <summary>
        /// 
        /// </summary>
        private  ProcessFactory()
        { 
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ProcessFactory GetInit()
        {
            if (pfobj == null)
            {
                pfobj = new ProcessFactory();
            }
            return pfobj;
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <returns></returns>
        protected bool HasExtend(IMsgProcess ProcessData)
        {
            foreach (IMsgProcess msgdata in this.processList.Keys)
            {
                if (Lemon.GetObjType(msgdata) == Lemon.GetObjType(ProcessData))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 添加一个消息总线的处理器
        /// </summary>
        public bool AddProcess(IMsgProcess ProcessData)
        {
            if (!HasExtend(ProcessData))
            {
                IProcessor process = new LemnadeProcessorTemplate(ProcessData);
                MessageFactory.GetMegBus().AddProcessor(process);
                this.processList.Add(ProcessData, process);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 移除一个消息总线的处理器
        /// </summary>
        public bool RemoveProcess(IMsgProcess ProcessData)
        {
            if (this.processList.ContainsKey(ProcessData))
            {
                IProcessor process = this.processList[ProcessData];
                MessageFactory.GetMegBus().RemoveProcessor(process);
                this.processList.Remove(ProcessData);
                return true;
            }
            else {

                return false;
            }
           
        }
        /// <summary>
        /// 获取历史消息
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public List<LemonMessage> GetHistory(MsgType Type)
        {
            List<LemonMessage> result = new List<LemonMessage>();
            if (Type == MsgType.Error)
            {
                List<MessageHistory> errorList   = MessageFactory.History().FindHistory(MessageType.Error);
                List<MessageHistory> errorWarning = MessageFactory.History().FindHistory(MessageType.Warning);
                errorList.AddRange(errorWarning);
                foreach (MessageHistory mh in errorList)
                {
                    LemonMessage lm = new LemonMessage();
                    lm.MsgObject = mh.MsgObject.Message;
                    lm.RecordTime = mh.RecordTime;
                    lm.Type = MsgType.Error;
                    result.Add(lm);
                } 
                    
            }
            else if (Type == MsgType.Debug)
            {
                List<MessageHistory> errorDebug = MessageFactory.History().FindHistory(MessageType.Debug);
                List<MessageHistory> errorPtDebug = MessageFactory.History().FindHistory(MessageType.PtDebug);
                errorDebug.AddRange(errorPtDebug);
                foreach (MessageHistory mh in errorDebug)
                {
                    LemonMessage lm = new LemonMessage();
                    lm.MsgObject = mh.MsgObject.Message;
                    lm.RecordTime = mh.RecordTime;
                    lm.Type = MsgType.Debug;
                    result.Add(lm);
                } 
            }
            else if (Type == MsgType.Note)
            {
                List<MessageHistory> errorNote = MessageFactory.History().FindHistory(MessageType.Note);
                List<MessageHistory> errorInsideInfo = MessageFactory.History().FindHistory(MessageType.InsideInfo);
                errorNote.AddRange(errorInsideInfo);
                foreach (MessageHistory mh in errorNote)
                {
                    LemonMessage lm = new LemonMessage();
                    lm.MsgObject = mh.MsgObject.Message;
                    lm.RecordTime = mh.RecordTime;
                    lm.Type = MsgType.Note;
                    result.Add(lm);
                } 
            }
            return result;
        }


    }
}
