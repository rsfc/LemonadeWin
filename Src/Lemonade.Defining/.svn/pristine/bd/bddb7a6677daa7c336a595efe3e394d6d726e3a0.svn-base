using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.Swapping; 
using System.Collections.Concurrent;
using System.Collections;

namespace Lemonade.Swap
{
    /// <summary>
    /// 类型匹配器，匹配关键字
    /// </summary>
    public class SwapMatchKeys:ISwapMatch
    {
        List<object> keys = null;   
        /// <summary>
        /// 类型匹配器
        /// </summary>
        public SwapMatchKeys(List<object> Keys)
        {
            this.keys = Keys;

        }

        /// <summary>
        /// 判断是否是参数输入的交换对象
        /// </summary>
        /// <param name="Swap"></param>
        /// <returns></returns>
        public bool IsSwap(ISwap Swap)
        { 
            IEnumerable<object> eA = Swap.CustomKeys; 
            IEnumerable<object> eB = this.keys;
            IEnumerable<object> intersect = eA.Intersect(eB);
            if (intersect != null)
            {
                if (intersect.Count() == this.keys.Count() && this.keys.Count()>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
