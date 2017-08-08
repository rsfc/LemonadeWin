using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Lemonade.Frame.Menu
{
    /// <summary>
    /// 自定义菜单项
    /// </summary>
    public class PtMenuItem : ToolStripMenuItem, Lemonade.Frame.Menu.IPtMenuItem
    {
        /// <summary>
        /// 标题
        /// </summary>
        private string title = "";
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// 菜单项id
        /// </summary>
        private int itemID = 0;
        /// <summary>
        /// 项id
        /// </summary>
        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        /// <summary>
        /// 上级菜单id
        /// </summary>
        private string parentItemID = "";
        /// <summary>
        /// 父级id
        /// </summary>
        public string ParentItemID
        {
            get { return parentItemID; }
            set { parentItemID = value; }
        }
        /// <summary>
        /// 是否有子项
        /// </summary>
        private bool isChild = false;
        /// <summary>
        /// 
        /// </summary>
        public bool IsChild
        {
            get { return isChild; }
            set { isChild = value; }
        }
        /// <summary>
        /// 菜单项图片路径
        /// </summary>
        private string imagename = "";
        /// <summary>
        /// 
        /// </summary>
        public string ImageName
        {
            get { return imagename; }
            set { imagename = value; }
        }
        /// <summary>
        /// 菜单时间加载程序集文件名
        /// </summary>
        private string assemblyPath = "";
        /// <summary>
        /// 
        /// </summary>
        public string AssemblyPath
        {
            get { return assemblyPath; }
            set { assemblyPath = value; }
        }
        /// <summary>
        /// 类全面 带命名空间
        /// </summary>
        private string fullClassName = "";
        /// <summary>
        /// 
        /// </summary>
        public string FullClassName
        {
            get { return fullClassName; }
            set { fullClassName = value; }
        }
         
        private string shortcutKey = "";
        /// <summary>
        /// 
        /// </summary>
        public string ShortcutKey
        {
            get
            {
                return this.shortcutKey;
            }
            set
            {
                this.shortcutKey = value;
            }
        }
         
        private int orderIndex;
        /// <summary>
        /// 排列顺序号
        /// </summary>
        public int OrderIndex
        {
            get
            {
                return orderIndex;
            }
            set
            {
                orderIndex = value;
            }
        }
 
    }
}
