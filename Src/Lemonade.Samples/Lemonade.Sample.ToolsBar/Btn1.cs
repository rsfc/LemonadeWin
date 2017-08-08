using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;
using Lemonade.Frame.UI;
namespace Lemonade.Samples.ToolsBar
{
    /// <summary>
    /// 实例按钮1
    /// </summary>
    public class Btn1 : IControlToolsButton
    {
        bool adsfsf = true;
        /// <summary>
        /// 执行
        /// </summary>
        public virtual  void Executive()
        { 
            throw new Exception("阿萨德发生地方");
        }

        /// <summary>
        /// 判断是否激活当前ui元素，即工具栏按钮
        /// </summary>
        /// <returns></returns>
        public bool IsActive()
        {
            return adsfsf;
        }

        /// <summary>
        /// 是否可用
        /// </summary>
        /// <returns></returns>
        public bool IsEnabled()
        {
            return adsfsf;
        }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsVisible()
        {
            return adsfsf;
        }


        public System.Windows.Forms.Form ParentForm
        {
            get;
            set;
        }
    }
}
