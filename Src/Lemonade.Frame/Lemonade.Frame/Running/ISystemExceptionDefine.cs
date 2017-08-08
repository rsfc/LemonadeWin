using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Running
{
    /// <summary>
    /// 系统异常定义接口，用于自定义异常的可用数据，例如友好提示
    /// </summary>
    public interface ISystemExceptionDefine
    {
        /// <summary>
        /// 获取自定义异常
        /// </summary>
        /// <param name="SourceExceptionMsg"></param>
        /// <returns></returns>
        string GetCustomException(string SourceExceptionMsg);
    }
}
