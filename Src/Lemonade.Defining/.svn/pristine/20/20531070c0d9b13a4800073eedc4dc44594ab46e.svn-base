using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.Swapping;

namespace Lemonade.Swap
{
    /// <summary>
    /// 类全名匹配器
    /// </summary>
    public class SwapMatchFullClassName:ISwapMatch
    {
        string  fcn = "";
        /// <summary>
        /// 类型匹配器
        /// </summary>
        public SwapMatchFullClassName(string  FullClassName)
        {
            this.fcn = FullClassName;

        }

        /// <summary>
        /// 判断是否是参数输入的交换对象
        /// </summary>
        /// <param name="Swap"></param>
        /// <returns></returns>
        public bool IsSwap(ISwap Swap)
        {
            if (Swap.PackageObject == null)
            {
                return false;
            }
            if (Lemon.GetFullClassName(Swap.PackageObject) == this.fcn)
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
