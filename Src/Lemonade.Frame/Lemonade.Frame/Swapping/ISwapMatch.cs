using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Swapping
{
    /// <summary>
    /// 数据交换匹配接口用于查找获取匹配的数据封装对象
    /// </summary>
    public interface ISwapMatch
    {
        /// <summary>
        /// 判断是否为当前的交换对象
        /// </summary>
        /// <returns></returns>
        bool IsSwap(ISwap Swap);
    }
}
