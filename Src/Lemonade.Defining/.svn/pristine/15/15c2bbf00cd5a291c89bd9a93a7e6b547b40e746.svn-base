using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.Running;

namespace Lemonade.SystemException
{
    /// <summary>
    /// 异常记录
    /// </summary>
    public class SystemExceptionDefine : ISystemExceptionDefine
    {
        public SystemExceptionDefine()
        {
            Initialize();
        }
        /// <summary>
        /// 初始化，加载已经有的自定义异常定义数据列表
        /// </summary>
        public virtual  void Initialize()
        {
            this.AddProcess();
        }

        /// <summary>
        /// 添加处理器
        /// </summary>
        protected virtual void AddProcess()
        {
            object tbs = Lemon.Deserialize(typeof(ExceptionDefine), Lemon.GetCSFRootDirectory() + @"\SystemException\ExceptionDefine.xml");
            if (tbs != null)
            {
                Lemonade.Frame.Message.IMsgProcess msgp = new AutomaticRecording((ExceptionDefine)tbs);
                Lemon.AddMsgProcess(msgp); 
            } 
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="SourceException"></param>
        public virtual string GetCustomException(string SourceExceptionMsg)
        {
            string result = "未定义";
            object tbs = Lemon.Deserialize(typeof(ExceptionDefine), Lemon.GetCSFRootDirectory() + @"\SystemException\ExceptionDefine.xml");
            if (tbs != null)
            {
                var tagce = ((ExceptionDefine)tbs).ExList.Find(delegate(CustomException ce) { return ce.Value == SourceExceptionMsg; });
                if (tagce != null)
                {
                    result= tagce.Title;
                }
            }
            return result;
        }
    }
}
