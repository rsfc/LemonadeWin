using Lemonade.Frame.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace Lemonade.Samples.Ribbon
{
    public class Btn : IRibbonButtonItem
    {
        bool adsfsf = true;


        public System.Windows.Forms.Form ParentForm
        {
            get;set;
        }

        public void Executive()
        {
            MessageBox.Show("这是一个按钮响应事件");



        }

        public bool IsActive()
        {
            return adsfsf;
        }

        public bool IsEnabled()
        {
            return adsfsf;
        }

        public bool IsVisible()
        {
            return adsfsf;
        }
    }
}
