﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Tools;
using System.Windows.Forms;
using Lemonade.ToolBar.Items;

namespace Lemonade.ToolBar.Datas
{
    /// <summary>
    /// 工具栏下拉框数据对象项
    /// </summary>
    public class TComboBoxItem  
    { 
        /// <summary>
        /// 程序集
        /// </summary>
        public string Assembly { get; set; }
        /// <summary>
        /// 类全名
        /// </summary>
        public string FullClassName { get; set; } 
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        ///// <summary>
        ///// 是否自动运行, 当触发默认值时是否自动运行
        ///// </summary>
        //public bool IsAutoRunning { get; set; }

        //public bool IsRunning { get; set; }
    }
}
