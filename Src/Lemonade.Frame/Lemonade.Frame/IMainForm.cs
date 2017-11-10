using System;
using System.Collections.Generic;
using System.Text; 
using System.Windows.Forms;
using Lemonade.Frame.Swapping;
using Protein.Enzyme.Log;
using Lemonade.Frame.Running;
using Lemonade.Frame.UI;

namespace Lemonade.Frame
{
    /// <summary>
    /// 主界面接口 
    /// </summary>
    public interface IMainForm
    {  
        /// <summary>
        /// 框架运行环境
        /// </summary>
        ILemonEnvironment Envir { get;set;}  
        /// <summary>
        /// 系统运行等待接口
        /// </summary>
        IWaitingProgram WatingProgram { get;}
        /// <summary>
        /// 皮肤管理器
        /// </summary> 
        ISkin SkinManager();
        DevExpress.XtraBars.Ribbon.RibbonControl getRibbon { get; }

    }
}
