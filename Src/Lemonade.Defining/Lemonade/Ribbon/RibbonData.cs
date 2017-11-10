using Lemonade.Ribbon.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Lemonade.Ribbon.Datas;

namespace Lemonade.Ribbon
{
    /// <summary>
    /// 功能区数据
    /// </summary>
    public class RibbonData
    { 
        /// <summary>
        /// 分页
        /// </summary>
        public List<RPage> Pages { get; set; }
        /// <summary>
        /// 分组
        /// </summary>
        public List<RPageGroup> Groups { get; set; }
        /// <summary>
        /// 按钮
        /// </summary>
        public List<RBarButton> Buttons { get; set; }

       
    }
}
