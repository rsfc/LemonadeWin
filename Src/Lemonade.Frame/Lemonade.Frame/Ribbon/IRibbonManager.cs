using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Ribbon
{
    /// <summary>
    /// 功能区管理接口
    /// </summary>
    public  interface IRibbonManager
    {
        /// <summary>
        /// 功能区分页名称
        /// </summary>
        List<string> RibbonPageNames { get; }
        /// <summary>
        /// 加载功能区
        /// </summary>
        void LoadRibbon();
        /// <summary>
        /// 获取所有功能区分页
        /// </summary>
        /// <returns></returns>
        List<RibbonPage> GetPages();
        /// <summary>
        /// 功能区分页添加到窗体
        /// </summary>
        void CreateRibbonPagesToForm(DevExpress.XtraBars.Ribbon.RibbonForm TargetForm);
    }
}
