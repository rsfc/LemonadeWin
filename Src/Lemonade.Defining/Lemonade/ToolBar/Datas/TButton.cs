using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;
using System.Windows.Forms;

namespace Lemonade.ToolBar.Datas
{
    /// <summary>
    /// 工具栏按钮数据对象
    /// </summary>
    public class TButton  
    { 
        /// <summary>
        /// 
        /// </summary>
        public string ToolsBarCode
        {
            get;
            set;
        }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string ItemImage
        {
            get;
            set;
        } 
        /// <summary>
        /// 索引
        /// </summary>
        public int ItemIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get;
            set;
        } 

        /// <summary>
        /// 按钮事件程序集路径
        /// </summary>
        public string Assembly { get; set; } 

        /// <summary>
        /// 按钮事件执行类全名
        /// </summary>
        public string FullClassName { get; set; }

         
 
    }
}
