using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;
using System.Windows.Forms;
using Lemonade.Frame;

namespace Lemonade.ToolBar.Items
{
    /// <summary>
    /// 分隔符项
    /// </summary>
    public class ToolsItemProcessSeparator : ToolsItemProcess
    {
         /// <summary>
        ///  
         /// </summary>
        /// <param name="Tb"></param>
         /// <returns></returns>
        protected override bool IsType(IToolsItem Tb)
        {
            if (Lemon.GetObjType(Tb) == typeof(ToolsSeparator))
            {
                return true;
            }
            else {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tb"></param>
        /// <returns></returns>
        protected override System.Windows.Forms.ToolStripItem CreateItem(IToolsItem Tb)
        {
            ToolsSeparator item = (ToolsSeparator)Tb;
            ToolStripItem newItem = new ToolStripSeparator();  
            //newItem.Name = item.ItemID.ToString(); 
            return newItem;
        }
    }
}
