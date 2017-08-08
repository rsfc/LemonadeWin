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
    public class ToolsItemProcessButton : ToolsItemProcess
    {
         /// <summary>
         /// 
         /// </summary>
        /// <param name="Tb"></param>
         /// <returns></returns>
        protected override bool IsType(IToolsItem Tb)
        {
            if (Lemon.GetObjType(Tb) == typeof(ToolsButton))
            {
                return true;
            }
            else {
                return false;
            }
        }
      
        /// <summary>
        ///  这里判断是否为ui元素 不是则不予创建
        /// </summary>
        /// <param name="Tb"></param>
        /// <returns></returns>
        protected override System.Windows.Forms.ToolStripItem CreateItem(IToolsItem Tb)
        {
            ToolsButton btn = (ToolsButton)Tb; 
            ToolStripItem newItem = new ToolStripButton();
            newItem.Text = btn.Title;
            if (File.Exists(btn.ItemImage))
            {
                newItem.Image = System.Drawing.Image.FromFile(btn.ItemImage);
            }
            //newItem.Name = btn..ToString(); 
            newItem.Tag = Tb;
            newItem.Click += new EventHandler(BindClickEvent); 
            return newItem;
        } 


        /// <summary>
        /// 绑定到单击事件
        /// </summary>
        protected virtual void BindClickEvent(object sender, EventArgs e)
        { 
            ((IToolsItem)((ToolStripItem)sender).Tag).UIElement.Executive();
            if (((ToolsButton)((ToolStripItem)sender).Tag).GroupName != null)
            {
                if (((ToolsButton)((ToolStripItem)sender).Tag).GroupName.Trim().Length>0)
                {
                    SetButtionCheck(((ToolsButton)((ToolStripItem)sender).Tag));
                }
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Btn"></param>
        protected  void SetButtionCheck(object Btn)
        {
            if (Btn.GetType().GetInterface("IToolsItem") == null)
            {
                return;
            }
            //获取所有分组按钮
            List<IToolsItem> tiList = Lemon.GetGroupToolsItem(((IToolsItem)Btn).GroupName);
            if (tiList != null)
            {
                foreach (IToolsItem iti in tiList)
                {
                    if (iti.HostObject != null)
                    {
                        if (Lemon.GetObjType(iti.HostObject)==typeof(ToolStripButton))
                        {
                            (iti.HostObject as ToolStripButton).Checked = false;
                        }
                    }
                }
            }
            if (Btn != null)
            {
                (((IToolsItem)Btn).HostObject as ToolStripButton).Checked = true;
            }

        }

    }
}
