using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.DAL;
namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// 单位接口
    /// </summary>
    public interface IUnits : IEntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        long UnitCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string UnitName { get; set; }
    }
}
