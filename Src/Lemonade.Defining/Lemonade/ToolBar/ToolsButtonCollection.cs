using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;

namespace Lemonade.ToolBar
{
    /// <summary>
    /// 
    /// </summary>
    public  class ToolsButtonCollection:IToolsItemCollection
    {
        List<IToolsItem> btns = new List<IToolsItem>();

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Button"></param>
        public void AddButton(IToolsItem Button)
        {
            this.btns.Add(Button);
        }
        /// <summary>
        /// 
        /// </summary>
        public int ButtonCount 
        {
            get {
                return this.btns.Count();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CollectionName
        {
            get;
            set;
        }
        /// <summary>
        /// 根据索引获取工具栏按钮
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IToolsItem this[int index]
        {
            get {

                if (this.btns.Count > index)
                {
                    return this.btns[index];
                }
                else
                {
                    return null;
                }
            }
        }


          
    }
}
