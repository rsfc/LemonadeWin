using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Message;
using Lemonade.Frame.Solon;
using Lemonade.Frame.Running;
using Lemonade.Frame.Message;
namespace Lemonade.Frame
{
    /// <summary>
    /// 框架通用功能入口
    /// </summary>
    public static partial class Lemon
    {
        #region 消息总线功能封装函数

        /// <summary>
        /// 发送内部消息，启动窗体提示属于内部消息
        /// </summary>
        /// <param name="Content"></param>
        public static void SendMsgInsideInfo(string Content)
        {
            MessageObject mo = new MessageObject(MessageType.InsideInfo);
            mo.Message = Content;
            MessageFactory.GetMegBus().Send(mo);
        }

 
        /// <summary>
        /// 发送提示消息，弹出提示窗体
        /// </summary>
        /// <param name="Content"></param>
        public static void SendMsgNote(string Content)
        {
            MessageObject mo = new MessageObject(MessageType.Note);
            mo.Message = Content;
            MessageFactory.GetMegBus().Send(mo);
        } 
        /// <summary>
        /// 发送平台调试消息
        /// </summary>
        /// <param name="Content"></param>
        public static void SendMsgPtDebug(string Content)
        {
            MessageObject mo = new MessageObject(MessageType.PtDebug);
            mo.Message = Content;
            MessageFactory.GetMegBus().Send(mo);
        }
        /// <summary>
        /// 发送调试消息
        /// </summary>
        /// <param name="Content"></param>
        public static void SendMsgDebug(string Content)
        {
            MessageObject mo = new MessageObject(MessageType.Debug);
            mo.Message = Content;
            MessageFactory.GetMegBus().Send(mo);
        }

        /// <summary>
        /// 发送异常消息
        /// </summary>
        /// <param name="Content"></param>
        public static void SendMsgError(string Content)
        {
            MessageObject mo = new MessageObject(MessageType.Error);
            mo.Message = new Exception(Content);
            MessageFactory.GetMegBus().Send(mo);
        }

        /// <summary>
        /// 发送异常消息
        /// </summary>
        /// <param name="Content"></param>
        public static void SendMsgError(Exception Content)
        {
            MessageObject mo = new MessageObject(MessageType.Error);
            mo.Message = Content;
            MessageFactory.GetMegBus().Send(mo);    
        }
        /// <summary>
        /// 发送警告信息
        /// </summary>
        /// <param name="Content"></param>
        public static void SendMsgWarning(string  Content)
        {
            MessageObject mo = new MessageObject(MessageType.Warning);
            mo.Message = new Exception(Content);
            MessageFactory.GetMegBus().Send(mo);
        }
        /// <summary>
        /// 添加参数指定的消息处理对象到消息总线中
        /// </summary>
        /// <param name="ProcessData"></param>
        public static bool AddMsgProcess(IMsgProcess ProcessData)
        { 
            return ProcessFactory.GetInit().AddProcess(ProcessData);
        }

        /// <summary>
        /// 删除参数指定的消息处理对象到消息总线中
        /// </summary>
        /// <param name="ProcessData"></param>
        public static bool RemoveMsgProcess(IMsgProcess ProcessData)
        {
            return ProcessFactory.GetInit().RemoveProcess(ProcessData);
        }

        /// <summary>
        /// 根据异常对象获取系统自定义异常信息
        /// </summary>
        /// <returns></returns>
        public static string SystemCustomException(Exception SourceException)
        {
            return LemonEnvironment.GetInstance().ExDefine.GetCustomException(SourceException.Message);
        }
        /// <summary>
        /// 根据一个异常标示符获取系统自定义异常信息
        /// </summary>
        /// <param name="SourceExceptionMessage"></param>
        /// <returns></returns>
        public static string SystemCustomException(string SourceExceptionMessage)
        {
            return LemonEnvironment.GetInstance().ExDefine.GetCustomException(SourceExceptionMessage);
        }

        /// <summary>
        /// 获取历史消息
        /// </summary>
        /// <returns></returns>
        public static List<LemonMessage> GetMsgHistory(MsgType Type)
        {
            return ProcessFactory.GetInit().GetHistory(Type);
        }



        #endregion



       

        
    }
}
