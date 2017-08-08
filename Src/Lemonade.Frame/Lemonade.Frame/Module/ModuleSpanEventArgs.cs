using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.Module
{ 
    /// <summary>
    /// ģ��������¼�����
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
