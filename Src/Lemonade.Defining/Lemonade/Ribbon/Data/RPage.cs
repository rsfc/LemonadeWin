using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Ribbon.Data
{
    /// <summary>
    /// 分页
    /// </summary>
    public class RPage
    {
        /// <summary>
        /// 功能分页编码
        /// </summary>
        public string RibbonPageCode
        {
            get;
            set;
        }
        
        /// <summary>
        /// 功能分页名称
        /// </summary>
        public string RibbonPageName
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

        public List<string> Groups
        { get; set; }
    }
}
