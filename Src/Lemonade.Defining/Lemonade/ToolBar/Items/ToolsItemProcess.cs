﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using System.Windows.Forms;
using Lemonade.Frame.Tools;

namespace Lemonade.ToolBar.Items
{
    /// <summary>
    /// 项创建处理器,用于创建微软的控件
    /// </summary>
    public abstract class ToolsItemProcess
    {
        private ToolsItemProcess nextProcess = null;

        /// <summary>
        /// 设置下一个处理器
        /// </summary>
        public ToolsItemProcess NextProcess
        {
            set {
                if (this.nextProcess == null)
                {
                    this.nextProcess = value;
                }
                else
                {
                    this.nextProcess.nextProcess = value;
                }
            }
            get {
                return this.nextProcess;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tb"></param>
        /// <returns></returns>
        public ToolStripItem BuildItem(IToolsItem Tb)
        {
            if (IsType(Tb))
            {
                return this.CreateItem(Tb);
            }
            else if (this.nextProcess != null)
            {

                return this.nextProcess.BuildItem(Tb);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ItemObj"></param>
        /// <returns></returns>
        protected abstract bool IsType(IToolsItem ItemObj);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tb"></param>
        /// <returns></returns>
        protected abstract ToolStripItem CreateItem(IToolsItem Tb);
    }
}
