using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.Module
{ 
    /// <summary>
    /// 模块跨界操作事件数据
    /// </summary>
    public class ModuleSpanEventArgs : EventArgs
    {
        private string moduleName = "";

        /// <summary>
        /// 
        /// </summary>
        public string ModuleName
        {
            get { return this.moduleName; }
            set { this.moduleName = value; }
        } 
    }
}
