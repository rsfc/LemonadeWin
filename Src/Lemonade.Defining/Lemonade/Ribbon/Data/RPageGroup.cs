using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Ribbon.Data
{
    /// <summary>
    /// 分页中的功能区分组
    /// </summary>
    public class RPageGroup
    {
        /// <summary>
        /// 
        /// </summary>
        public string GroupCode { get; set; }
        /// <summary>
        /// 按钮集合
        /// </summary>
        public List<string> Buttons
        {
            get;
            set;
        }

         
        /// <summary>
        /// 
        /// </summary>
        public string Image
        {
            get;
            set;
        }
        /// <summary>
        /// 索引
        /// </summary>
        public int Index
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

        

    }
}
