using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.UI;
using Lemonade.Frame;

namespace Lemonade.Samples.LayoutDefault
{
    /// <summary>
    /// 
    /// </summary>
    public class LayoutDefault : ILayout
    {
        public void CancelLayout()
        {
            //无效果
        }
        /// <summary>
        /// 该布局受控的窗体
        ///  
        /// </summary>
        public List<string> Controlleds
        {
            get {
                ////List<string> result = new List<string>();

                ////foreach (System.Windows.Forms.Form f in Lemon.GetOpenForms())
                ////{ 
                ////    result.Add(Lemon.GetObjType(f).FullName);
                ////}
                return new List<string>();
            }
        }

        /// <summary>
        /// 创建布局
        /// </summary>
        /// <param name="MainForm"></param>
        public void CreateLayout(IMainForm MainForm)
        {
            
        }
        /// <summary>
        /// 布局名称
        /// </summary>
        public string LayoutName
        {
            get { return ""; }
        }
        /// <summary>
        /// 设置窗口的布局样式
        /// </summary>
        /// <param name="TargetForm"></param>
        public bool SetLayoutForm(System.Windows.Forms.Form TargetForm)
        {
            return true;
        }
    }
}
