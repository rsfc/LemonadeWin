using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using System.Windows.Forms;
using Lemonade.Frame.Message;
namespace Lemonade.SystemException
{
    /// <summary>
    /// 自动记录
    /// </summary>
    public class AutomaticRecording : IMsgProcess
    {
        private ExceptionDefine exdefine = null;
        /// <summary>
        /// 
        /// </summary>
        public AutomaticRecording(ExceptionDefine Exdefine)
        {
            this.exdefine = Exdefine;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public bool IsUse(MsgType Type)
        {
            if (Type == MsgType.Error)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }

        /// <summary>
        /// 记录
        /// </summary>
        /// <param name="Msg"></param>
        public virtual void Process(object Msg,DateTime Date)
        {
            bool isExt = false;
            if (Lemon.GetObjType(Msg) == typeof(string))
            {
                isExt=CheckString((string)Msg);
            }
            else if(Lemon.GetObjType(Msg) == typeof(Exception))
            {
                isExt = CheckString(((Exception)Msg).Message);
            }
            if (!isExt)
            { 
                //不存在 写入一条新的记录
                Lemon.XmlSerialize<ExceptionDefine>(Lemon.GetCSFRootDirectory() + @"\SystemException\ExceptionDefine.xml", Encoding.Unicode, this.exdefine);
            }
        }

        /// <summary>
        /// 检查字符串
        /// </summary>
        /// <param name="Msg"></param>
        protected virtual bool CheckString(string Msg)
        {
            var tagce=this.exdefine.ExList.Find(delegate(CustomException ce) { return ce.Value == Msg; });
            if (tagce == null)
            {
                CustomException newce = new CustomException();
                newce.Title = "";
                newce.Value= Msg;
                this.exdefine.ExList.Add(newce);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
