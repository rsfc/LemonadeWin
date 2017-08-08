using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Running;

namespace Lemonade.Frame
{
    /// <summary>
    /// 框架通用功能入口
    /// </summary>
    public static partial class Lemon
    {

        #region 其他系统功能函数

         

        /// <summary>
        /// 系统关闭
        /// </summary>
        public static void SystemClose()
        {
            Lemonade.Frame.Running.LemonEnvironment.GetInstance().SystemRoundOff.SystemExit();
        }

        /// <summary>
        /// 添加系统关闭时的扫尾功能
        /// </summary>
        /// <param name="Opration"></param>
        public static void AddRoundOffOpration(RoundOpration Opration)
        {
            Lemonade.Frame.Running.LemonEnvironment.GetInstance().SystemRoundOff.AddOpration(Opration);
        }

        #endregion
    }
}
