using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;

namespace Lemonade.Samples.ToolsBar
{
    /// <summary>
    /// 自定义下拉项
    /// </summary>
    public class MyComoBoxItem : IControlToolsComoBoxItem
    {
        public void Executive()
        {
            OtherComoBoxItem.otheritem = false;
            System.Windows.Forms.MessageBox.Show("MyComoBoxItem");
        }

        public bool IsActive()
        {
            return false;
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
