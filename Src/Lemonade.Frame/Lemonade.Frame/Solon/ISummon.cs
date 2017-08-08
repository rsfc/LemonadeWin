using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Solon
{
    /// <summary>
    /// 召唤接口,负责创建戒灵
    /// </summary>
    public interface ISummon
    {
        /// <summary>
        /// 召唤戒灵
        /// </summary>
        /// <returns></returns>
        INazgul RingtoWear();
    }
}
