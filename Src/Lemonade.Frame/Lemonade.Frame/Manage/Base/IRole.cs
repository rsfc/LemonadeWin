using System;

namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// 角色
    /// </summary>
    public interface IRole:Protein.Enzyme.DAL.IEntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        long RoleCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string RoleName { get; set; }
    }
}
