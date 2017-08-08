using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;

namespace Lemonade.ToolBar
{
    /// <summary>
    /// 工具栏对象数据对象
    /// </summary>
    public  class TBar
    {   
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

        
    }
}
