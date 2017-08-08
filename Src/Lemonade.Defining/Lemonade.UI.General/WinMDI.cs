using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.UI;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection;

namespace Lemonade.UI.General
{
    /// <summary>
    /// 通用的mid窗口设置  
    /// </summary>
    public class WinMDI : WindowStyle
    {
        /// <summary>
        /// 是否使用此设置器进行ui管理
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <returns></returns>
        public override bool IsUse(System.Windows.Forms.Form TargetForm)
        {
            bool result=true;

            if (TargetForm.Modal)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <param name="MainForm"></param>
        protected override void WinStyle(Form TargetForm, Form MainForm, ILayoutManager Manager)
        {  
            TargetForm.ShowIcon = false;
            TargetForm.ShowInTaskbar = false;
            TargetForm.MaximizeBox = false;
            TargetForm.MinimizeBox = false;
            TargetForm.TopMost = true;
            try
            {
                TargetForm.TopLevel = false;
            }
            catch
            { }
            TargetForm.Parent = MainForm;  
            MainForm.Controls.Add(TargetForm);
            MainForm.Controls.SetChildIndex(TargetForm, 0);
            TargetForm.Dock = DockStyle.None; 
        }

        ///// <summary>
        ///// 加载目标窗体参数
        ///// </summary>
        //protected virtual StylePar LoadTagWindow(Form TargetForm)
        //{
        //    //判断窗体是否具有stylepar属性
        //    PropertyInfo[] pis = TargetForm.GetType().GetProperties();
        //    foreach (PropertyInfo pi in pis)
        //    {
        //        if (pi.PropertyType == typeof(StylePar))
        //        {
        //            object tmpvalue = pi.GetValue(TargetForm, null);
        //            if (tmpvalue != null)
        //            {
        //                return (StylePar)tmpvalue;
        //            }
        //        }
        //    }
        //    return null;
        //}



    }
}
