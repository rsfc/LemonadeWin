using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.DAL;
namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public interface IUser : IEntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        long RoleCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        long UnitCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        long UserCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Userpd { get; set; }
    }
}
