using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;
using Lemonade.Frame.Tools;
namespace Lemonade.ToolBar
{
    /// <summary>
    /// 分组按钮是否可以使用
    /// </summary>
    public   class GroupButtonEnabled
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Btn"></param>
        public  void SetButtionCheck(object Btn)
        {
            if(Btn.GetType().GetInterface("IToolsItem")==null)
            {
                return;
            }
            //获取所有分组按钮
            List<IToolsItem> tiList= Lemon.GetGroupToolsItem(((IToolsItem)Btn).GroupName);
            foreach (IToolsItem iti in tiList)
            {
                if (iti.HostObject != null)
                {
                    if (iti.HostObject.GetType().IsSubclassOf(typeof(ToolStripButton)))
                    {
                        (iti.HostObject as ToolStripButton).Checked = false;
                    }
                }
            } 
            (Btn as ToolStripButton).Checked = true;

        }
    }
}
