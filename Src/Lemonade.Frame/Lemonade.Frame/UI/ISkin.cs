using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// 皮肤接口
    /// </summary>
    public interface ISkin
    {
        /// <summary>
        /// 皮肤数量
        /// </summary>
        /// <returns></returns>
        int SkinCount();
        /// <summary>
        /// 设置皮肤
        /// </summary>
        /// <param name="Index"></param>
        void SetSkin(int Index);

    }
}
