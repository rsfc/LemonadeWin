using System;
namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// 权限控制项对象接口
    /// </summary>
    public interface IAuthControl : Protein.Enzyme.DAL.IEntityBase
    {
        /// <summary>
        /// 权限类型编码
        /// </summary>
        long AuthCode { get; set; }
        /// <summary>
        /// 控制项编码
        /// </summary>
        string FItemCode { get; set; }
        /// <summary>
        /// 控制项名称
        /// </summary>
        string FItemName { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>
        long RoleCode { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        long RowCode { get; set; }
    }
}
