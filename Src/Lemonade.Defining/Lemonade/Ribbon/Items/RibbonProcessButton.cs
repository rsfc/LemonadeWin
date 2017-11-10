using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;
using System.Windows.Forms;
using Lemonade.Frame;
using System.IO;
using DevExpress.XtraBars;
using System.Drawing;
using DevExpress.XtraBars.Ribbon;

namespace Lemonade.Ribbon.Items
{
    /// <summary>
    /// 功能分区
    /// </summary>
    public class RibbonProcessButton 
    {
        public RibbonProcessButton()
        {

        }
        /// <summary>
        ///  这里判断是否为ui元素 不是则不予创建
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <param name="Tb"></param>
        /// <returns></returns>
        public  BarButtonItem CreateItem(RibbonForm TargetForm, FunButton Tb)
        {
            BarButtonItem newbutn = new BarButtonItem();
            newbutn.Caption = Tb.ButtonTitle;
            newbutn.Glyph = Image.FromFile(Tb.ButtonImage);
            newbutn.Id = Tb.ContentIndex;
            newbutn.Name = Tb.ContentCode;
            newbutn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            //TargetForm.Ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            //            TargetForm.Ribbon.ExpandCollapseItem, newbutn});
            newbutn.Tag = Tb;
            newbutn.ItemClick += BindClickEvent; 
            return newbutn;
        }

        private void BindClickEvent(object sender, ItemClickEventArgs e)
            //((FunButton)((BarButtonItem)e).Tag).UIElement.Executive(); 
        {
            ((FunButton)e.Item.Tag).UIElement.Executive();
        }

 


    }
}
