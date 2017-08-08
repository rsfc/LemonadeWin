using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.Swapping;

namespace Lemonade.Swap
{
    /// <summary>
    /// 类型匹配器
    /// </summary>
    public class SwapMatchType:ISwapMatch
    {
        Type tagType = null;
        /// <summary>
        /// 类型匹配器
        /// </summary>
        public SwapMatchType(Type TagType)
        {
            this.tagType = TagType;

        }

        /// <summary>
        /// 判断是否是参数输入的交换对象
        /// </summary>
        /// <param name="Swap"></param>
        /// <returns></returns>
        public bool IsSwap(ISwap Swap)
        {
            if (Swap.ThisType == this.tagType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
