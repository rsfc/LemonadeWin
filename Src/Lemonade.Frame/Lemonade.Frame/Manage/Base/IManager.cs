using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.DAL;
using System.Data; 
namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// 管理者接口 
    /// </summary>
    public interface IManager
    {
        
        /// <summary>
        /// 数据库操作类
        /// </summary>
        IDBInfo DbHelper { get;set;}

        #region 用户

        /// <summary>
        /// 根据用户名称查询用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        IUser QueryUserName(string UserName);
        /// <summary>
        /// 根据用户编码查询用户
        /// </summary>
        /// <param name="UserCode">用户编码</param>
        /// <returns></returns>
        IUser QueryUserCode(long UserCode);
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        List<IUser> QueryUser();
        /// <summary>
        /// 根据单位查询用户
        /// </summary>
        /// <param name="Units"></param>
        /// <returns></returns>
        List<IUser> QueryUser(IUnits Units);
        /// <summary>
        /// 根据角色查询用户
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        List<IUser> QueryUser(IRole Role);
        /// <summary>
        /// 根据用户名称和密码查询用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPassword"></param>
        /// <returns></returns>
        IUser QueryUserInfo(string UserName,string UserPassword);
        /// <summary>
        /// 根据角色编码查询用户
        /// </summary>
        /// <param name="RoleCode"></param>
        /// <returns></returns>
        List<IUser> QueryUserRoleCode(long RoleCode); 
        /// <summary>
        /// 根据用户编码删除用户
        /// </summary>
        /// <returns></returns>
        int RemoveUserCode(long UserCode);
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="NewUser"></param>
        /// <returns></returns>
        int AddUser(IUser NewUser); 
        ///// <summary>
        ///// 创建用户对象实例
        ///// </summary>
        ///// <returns></returns>
        //IUser CreateInstance();
        /// <summary>
        /// 根据用户编码更新用户数据
        /// </summary>
        /// <param name="EditUser"></param>
        /// <returns></returns>
        int Update(IUser EditUser);
        /// <summary>
        /// 获取新的用户编号，获取当前用户编号的最大值然后+1
        /// </summary>
        /// <returns></returns>
        long GetNewUserCode(IUser User);
        /// <summary>
        /// 批量添加用户
        /// </summary>
        /// <param name="UserList"></param>
        /// <returns></returns>
        int AddUser(List<IUser> UserList);
        /// <summary>
        /// 批量更新用户
        /// </summary>
        /// <param name="UserList"></param>
        /// <returns></returns>
        int Update(List<IUser> UserList);

        #endregion
        
        #region 单位

        /// <summary>
        /// 查询所有单位
        /// </summary>
        /// <returns></returns>
        List<IUnits> QueryUnits();
        /// <summary>
        /// 查询所有单位名称
        /// </summary>
        /// <returns></returns>
        List<string> QueryUnitName();
        /// <summary>
        /// 根据单位名称查询单位
        /// </summary>
        /// <param name="UnitName"></param>
        /// <returns></returns>
        IUnits QueryUnits(string UnitName);
        /// <summary>
        /// 根据单位编码查询单位
        /// </summary>
        /// <param name="UnitCode"></param>
        /// <returns></returns>
        IUnits QueryUnitsForCode(long UnitCode);
        /// <summary>
        /// 添加单位
        /// </summary>
        /// <param name="Units"></param>
        /// <returns></returns>
        int AddUnits(IUnits Units);
        /// <summary>
        /// 移除单位
        /// </summary>
        /// <param name="UnitName"></param>
        /// <returns></returns>
        int RemoveUnits(string UnitName);
        /// <summary>
        /// 更新单位
        /// </summary>
        /// <param name="Units"></param>
        /// <returns></returns>
        int UpdateUnits(IUnits Units);
        /// <summary>
        /// 获取新的单位编码
        /// </summary>
        /// <param name="Unit"></param>
        /// <returns></returns>
        long GetNewUnitsCode(IUnits Unit);
        
        #endregion

        #region 角色
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        int UpdateRole(IRole Role);
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        int AddRole(IRole Role);
        /// <summary>
        /// 移除角色
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        int RemoveRole(string RoleName); 

        /// <summary>
        /// 获取新的单位编码
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        long GetNewRoleCode(IRole Role);
        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns></returns>
        List<IRole> QueryRole();
        /// <summary>
        /// 根据角色名称查询角色
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        /// <returns></returns>
        IRole QueryRole(string RoleName);
        /// <summary>
        /// 根据角色编码查询角色
        /// </summary>
        /// <param name="RoleCode">角色编码</param>
        /// <returns></returns>
        IRole QueryRoleForCode(long RoleCode);
        #endregion

        #region 权限类型

        /// <summary>
        /// 是否缺少菜单权限
        /// 当用户角色权限大于目标角色时 false
        /// 当用户角色权限小于目标角色时 true 即缺少权限
        /// </summary>
        bool IsLackRoleMenuAuth(IRole UserRole, IRole TargetRole, IMenu Menu);
        ///// <summary>
        ///// 根据角色名称查询角色
        ///// </summary>
        ///// <param name="AuthName">角色名称</param>
        ///// <returns></returns>
        //IAuthType QueryAuthType(string AuthName);
        ///// <summary>
        ///// 更新权限类型
        ///// </summary>
        ///// <param name="AuthType"></param>
        ///// <returns></returns>
        //int UpdateAuthType(IAuthType AuthType);
        ///// <summary>
        ///// 添加权限类型
        ///// </summary>
        ///// <param name="AuthType"></param>
        ///// <returns></returns>
        //int AddAuthType(IAuthType AuthType);
        ///// <summary>
        ///// 删除权限类型
        ///// </summary>
        ///// <param name="AuthCode"></param>
        ///// <returns></returns>
        //int RemoveAuthType(string AuthCode);
        ///// <summary>
        ///// 获取新的权限类型编码
        ///// </summary>
        ///// <param name="AuthType"></param>
        ///// <returns></returns>
        //int GetNewAuthTypeCode(IAuthType AuthType);
        ///// <summary>
        ///// 查询所有权限类型
        ///// </summary>
        ///// <returns></returns>
        //List<IAuthType> QueryAuthType();
         
        #endregion

        #region 通用的
        /// <summary>
        /// 创建实体对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T CreateEntityInstance<T>(); 

        #endregion 

        #region 权限控制项
        /// <summary>
        /// 获取新的权限控制项流水码
        /// </summary>
        /// <param name="AuthCtrl"></param>
        /// <returns></returns>
        long GetNewAuthCtrlCode(IAuthControl AuthCtrl);
        /// <summary>
        /// 添加权限控制项
        /// </summary>
        /// <param name="AuthCtrl"></param>
        /// <returns></returns>
        int AddAuthCtrl(IAuthControl AuthCtrl); 
        /// <summary>
        /// 更新权限项目
        /// </summary>
        /// <param name="AuthCtrl"></param>
        /// <returns></returns>
        int UpdateAuthCtrl(IAuthControl AuthCtrl); 
        /// <summary>
        /// 根据角色名称查询权限控制项
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        List<IAuthControl> QueryAuthCtrl(IRole Role);
        /// <summary>
        /// 根据权限类型名称查询权限控制项
        /// </summary>
        /// <param name="AuthType"></param>
        /// <returns></returns>
        List<IAuthControl> QueryAuthCtrl(AuthType AuthType);
        /// <summary>
        /// 查询所有权限控制项
        /// </summary>
        /// <returns></returns>
        List<IAuthControl> QueryAuthCtrl();
    
        /// <summary>
        /// 根据菜单查询权限控制项
        /// </summary>
        /// <param name="Menu"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        IAuthControl QueryAuthCtrl(IMenu Menu,IRole Role);
        /// <summary>
        /// 根据权限项和角色查询权限控制项
        /// </summary>
        /// <param name="AuthItem"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        IAuthControl QueryAuthCtrl(IAuthItem AuthItem, IRole Role);
        ///// <summary>
        ///// 移除权限控制项
        ///// </summary>
        ///// <param name="AuthCode"></param>
        ///// <returns></returns>
        //int RemoveAuthCtrl(long AuthCode);
        /// <summary>
        /// 移除指定角色的所有权限控制项
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        int RemoveAuthCtrl(IRole Role);
        /// <summary>
        /// 移除指定用户下的指定权限控制项编码的控制项
        /// </summary>
        /// <param name="Role"></param>
        /// <param name="FItemCode"></param>
        /// <returns></returns>
        int RemoveAuthCtrl(IRole Role, string FItemCode);
        /// <summary>
        /// 移除指定权限项编码的控制项
        /// </summary>
        /// <param name="FItemCode"></param>
        /// <returns></returns>
        int RemoveAuthCtrl(string FItemCode);
        #endregion

        #region 菜单
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns></returns>
        int AddMenu(IMenu Menu);
        /// <summary>
        /// 移除菜单
        /// </summary>
        /// <param name="MenuCode"></param>
        /// <returns></returns>
        int RemoveMenu(string MenuCode);
        /// <summary>
        /// 构造菜单权限项
        /// </summary>
        /// <param name="Menu">菜单</param>
        /// <param name="Role">角色</param>
        /// <param name="AuthType">权限类型</param>
        /// <returns></returns>
        IAuthControl BuildMenuAuthCtrl(IMenu Menu, IRole Role, AuthType AuthType);
        /// <summary>
        /// 构造菜单权限项
        /// </summary>
        /// <param name="MenuCode">菜单编码</param>
        /// <param name="MenuTitle">菜单标题</param>
        /// <param name="RoleCode">角色编码</param>
        /// <param name="TypeCode">权限类型编码</param>
        /// <returns></returns>
        IAuthControl BuildMenuAuthCtrl(string MenuCode, string MenuTitle
            , long RoleCode, long TypeCode);
        /// <summary>
        /// 根据菜单类型查询菜单
        /// </summary>
        /// <param name="MType">菜单类型</param>
        /// <returns></returns>
        List<IMenu> QueryMenus(MenuType MType);
        /// <summary>
        /// 根据角色和菜单类型查询菜单
        /// </summary>
        /// <param name="Role">角色</param>
        /// <param name="MType">菜单类型</param>
        /// <returns></returns>
        List<IMenu> QueryMenus(IRole Role,MenuType MType);
        /// <summary>
        /// 根据用户和菜单类型查询菜单
        /// </summary>
        /// <param name="User"></param>
        /// <param name="MType"></param>
        /// <returns></returns>
        List<IMenu> QueryMenus(IUser User, MenuType MType);
        /// <summary>
        /// 获取新的菜单编码 
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns></returns>
        string GetNewMenuCode(IMenu Menu);
        /// <summary>
        /// 更新菜单项
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns></returns>
        int UpdateMenu(IMenu Menu);
        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        List<IMenu> QueryMenus();
        /// <summary>
        /// 查询子菜单
        /// </summary>
        /// <param name="PerntCode">父菜单编号</param>
        /// <returns></returns>
        List<IMenu> QuerySubmenu(string PerntCode);
        /// <summary>
        /// 根据菜单编码查询菜单
        /// </summary>
        /// <param name="MenuCode"></param>
        /// <returns></returns>
        IMenu QueryCode(string MenuCode);
        /// <summary>
        /// 根据菜单类全名查询菜单
        /// </summary>
        /// <param name="FullClassName"></param>
        /// <returns></returns>
        IMenu QueryMenu(string FullClassName);
        /// <summary>
        /// 查询所有菜单获取dataset
        /// </summary>
        /// <returns></returns>
        DataSet QueryAllSet();
        #endregion

        #region 权限项
        /// <summary>
        /// 添加权限项目
        /// </summary>
        /// <param name="AuthItem"></param>
        /// <returns></returns>
        int AddAuthItem(IAuthItem AuthItem);
        /// <summary>
        /// 移除权限项
        /// </summary>
        /// <param name="AuthItemCode"></param>
        /// <returns></returns>
        int RemoveAuthItem(string AuthItemCode);
        /// <summary>
        /// 查询所有权限项
        /// </summary>
        /// <returns></returns>
        List<IAuthItem> QueryAuthItem();
        /// <summary>
        /// 根据指定的权限项编码查询权限项对象
        /// </summary>
        /// <param name="AuthItemCode"></param>
        /// <returns></returns>
        IAuthItem QueryAuthItem(string AuthItemCode);
        /// <summary>
        /// 根据角色查询权限项
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        List<IAuthItem> QueryAuthItem(IRole Role);
        /// <summary>
        /// 验证新的权限项流水码 如果已经存在则返回true 不存在则返回false
        /// </summary>
        /// <param name="AuthItemCode"></param>
        /// <returns></returns>
        bool IsExistAuthItemCode(string AuthItemCode);

        #endregion

       

        
    }
}
