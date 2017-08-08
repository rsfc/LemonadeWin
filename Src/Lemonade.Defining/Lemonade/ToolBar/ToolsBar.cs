using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;

namespace Lemonade.ToolBar
{
    /// <summary>
    /// 工具栏对象
    /// </summary>
    public  class ToolsBar:IToolsBar
    {
        List<IToolsItemCollection> btnCols = new List<IToolsItemCollection>();

        /// <summary>
        /// 添加按钮
        /// </summary>
        public event ToolsBarItemOperation EventAddItem;
 
        /// <summary>
        /// 添加工具栏按钮
        /// </summary>
        /// <param name="Btn"></param>
        public void AddItem(IToolsItem Btn)
        {
            var btc = this.btnCols.Find(delegate(IToolsItemCollection bc) { return bc.CollectionName == Btn.GroupName; });
            if (btc != null)
            {
                btc.AddButton(Btn);

            }
            else
            {
                IToolsItemCollection tbc = new ToolBar.ToolsButtonCollection();
                tbc.CollectionName = Btn.GroupName;
                tbc.AddButton(Btn);
                this.btnCols.Add(tbc);
            }

            if (this.EventAddItem != null)
            {
                this.EventAddItem(this, Btn);
            }
        }
 

        /// <summary>
        /// 获取分组名称
        /// </summary>
        public List<string> GetGroupName
        {
            get {
                var q =
                   from p in this.btnCols
                   group p by p.CollectionName into g
                   select g.Key; 
                return q.ToList();
            }
        }

        
        /// <summary>
        /// 清除按钮
        /// </summary>
        public void RemoveAllBtn()
        {
            this.btnCols.Clear(); 
        }

        /// <summary>
        /// 父窗体名称
        /// </summary>
        public string ParentFormName
        {
            get;
            set;
        }
        /// <summary>
        /// 工具栏名称
        /// </summary>
        public string ToolsBarName
        {
            get;
            set;
        }
        /// <summary>
        /// 工具栏编码
        /// </summary>
        public string ToolsBarCode
        {
            get;
            set;
        }

         /// <summary>
         /// 
         /// </summary>
        public int CollectionCount
        {
            get {
                return this.btnCols.Count();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ColsName"></param>
        /// <returns></returns>
        public IToolsItemCollection this[string ColsName]
        {
            get { 
                var tbc = this.btnCols.Find(delegate(IToolsItemCollection tmptbc) { return tmptbc.CollectionName == ColsName; });
                return tbc;
            }
        }

        
        /// <summary>
        /// 
        /// </summary> 
        /// <returns></returns>
        public List<IToolsItem> GetItems()
        { 
            List<IToolsItem> result = new List<IToolsItem>();
            //创建分组
            foreach (string tbcname in this.GetGroupName)
            {
                IToolsItemCollection tbc = this[tbcname];
                for (int i = 0; i < tbc.ButtonCount; i++)
                {
                    result.Add(tbc[i]); ;
                }
            }
            //根据index排序  
            result = result.OrderBy(a => a.ItemIndex).ToList();
            return result;
        }
    }
}
