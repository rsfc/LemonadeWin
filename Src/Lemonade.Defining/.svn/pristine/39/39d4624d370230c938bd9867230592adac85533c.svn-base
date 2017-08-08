using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;
using System.Windows.Forms;
using Lemonade.Frame;
using System.IO;

namespace Lemonade.ToolBar.Items
{
    /// <summary>
    /// 按钮项
    /// </summary>
    public class ToolsItemProcessComboBox : ToolsItemProcess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ItemObj"></param>
        /// <returns></returns>
        protected override bool IsType(Frame.Tools.IToolsItem ItemObj)
        {
            if (Lemon.GetObjType(ItemObj) == typeof(ToolsComboBox))
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
        /// <summary>
        /// 创建下拉框
        /// </summary>
        /// <param name="Tb"></param>
        /// <returns></returns>
        protected override System.Windows.Forms.ToolStripItem CreateItem(Frame.Tools.IToolsItem Tb)
        {
            ToolsComboBox cbox = (ToolsComboBox)Tb;
            ToolStripComboBox newItem = new ToolStripComboBox();
            newItem.DropDownStyle = ComboBoxStyle.DropDownList; 
            foreach (ToolsComboBoxItem item in cbox.Items)
            { 
                newItem.Items.Add(item);
            } 
            newItem.Tag = Tb;
            //Lemon.ActionAppend(newItem, "SelectedIndexChanged", Frame.Running.ActionType.Single, new EventHandler(newItem_SelectedIndexChanged));
            Lemon.ActionAppend(newItem, "DropDownClosed", Frame.Running.ActionType.Single, new EventHandler(comboBox1_DropDownClosed));
            //newItem.SelectedIndexChanged += new EventHandler(newItem_SelectedIndexChanged); 
            //newItem..MouseUp+=new MouseEventHandler(newItem_MouseUp);// += new EventHandler(newItem_SelectedIndexChanged); 
            return newItem;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected virtual void newItem_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    System.Windows.Forms.ToolStripComboBox selectitem = sender as System.Windows.Forms.ToolStripComboBox;
        //    ToolsComboBoxItem item = selectitem.SelectedItem as ToolsComboBoxItem;
        //    item.UIElement.Executive(); 
             
        //}
        /// <summary>
        /// 下拉框关闭的时候触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripComboBox selectitem = sender as System.Windows.Forms.ToolStripComboBox;
            ToolsComboBoxItem item = selectitem.SelectedItem as ToolsComboBoxItem;
            if (item != null)
            {
                item.UIElement.Executive();
            }
            else { }
        }
       
      
    }
}
