using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;

namespace Lemonade.Samples.ToolsBar
{
    /// <summary>
    /// 其他自定义下拉项
    /// </summary>
    public class OtherComoBoxItem : IControlToolsComoBoxItem
    {
        public static bool otheritem = false;
        public void Executive()
        {
            System.Windows.Forms.MessageBox.Show("OtherComoBoxItem");
            OtherComoBoxItem.otheritem = true;
        }

        public bool IsActive()
        {
            return OtherComoBoxItem.otheritem;
        }

        public bool IsEnabled()
        {
            return true;
        }

        public bool IsVisible()
        {
            return true;
        }

        public System.Windows.Forms.Form ParentForm
        {
            get;
            set;
        }
    }
}
