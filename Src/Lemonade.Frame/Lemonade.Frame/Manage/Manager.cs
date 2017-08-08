using System;
using System.Collections.Generic;
using System.Text; 
using Lemonade.Frame.Manage; 
using System.Data;
using Protein.Enzyme.Repository;
using Protein.Enzyme.DAL; 
using System.Text.RegularExpressions;
using Protein.Enzyme.Design;
using Lemonade.Frame.Manage.Base;
using Lemonade.Frame.Design;
namespace Lemonade.Frame.Manage
{
    /// <summary>
    /// 管理类 
    /// </summary>
    public class Manager : IManager
    {
        #region 其他

        IEntityFactory entityfactory;
        DalHandler dalh=new DalHandler();
        DataHelper dh = new DataHelper();
        /// <summary>
        /// 管理类
        /// </summary>
        /// <param name="Dbh"></param>
        public Manager( IDBInfo Dbh)
        {
            this.dbHelper = Dbh;
            CreateDALFactory cdf = new CreateDALFactory();
            entityfactory = cdf.GetInstance(this.dbHelper);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ManageFile"></param>
        /// <param name="Dbh"></param>
        public Manager(string ManageFile, IDBInfo Dbh)
        {
            this.dbHelper = Dbh;
            CreateDALFactory cdf = new CreateDALFactory();
            entityfactory = cdf.GetInstance(ManageFile,this.dbHelper);
        }
        private  IDBInfo dbHelper = null;
        /// <summary>
        /// 
        /// </summary>
        public  IDBInfo DbHelper
        {
            get
            {
                return this.dbHelper; ;
            }
            set
            {
                this.dbHelper = value; ;
            }
        }
        

      
        
        /// <summary>
        /// 创建实体对象实例
        /// </summary>
        /// <returns></returns>
        public  T  CreateEntityInstance<T>()
        {
            return this.entityfactory.CreateEntityInstance<T>();
        } 

        #endregion
         
        #region  用户操作
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public virtual List<IUser> QueryUser()
        { 
            IUser user = entityfactory.CreateEntityInstance<IUser>();
            IDvTable dvt = entityfactory.CreateDriveTable(user); 
            DataSet ds = dvt.Select(); 
            List<IUser> list = this.dh.Convert<IUser>(user.GetType(), ds);
            return list;
        }
        /// <summary>
        /// 根据单位查询用户
        /// </summary>
        /// <param name="Units"></param>
        /// <returns></returns>
        public virtual List<IUser> QueryUser(IUnits Units)
        {
            IUser user = entityfactory.CreateEntityInstance<IUser>();
            user.UnitCode = Units.UnitCode;
            IDvTable dvt = entityfactory.CreateDriveTable(user);
            dvt.WhereClause("UnitCode", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            List<IUser> list = this.dh.Convert<IUser>(user.GetType(), ds);
            return list;
        }
        /// <summary>
        /// 根据角色查询用户
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public virtual List<IUser> QueryUser(IRole Role)
        {
            IUser user = entityfactory.CreateEntityInstance<IUser>();
            user.RoleCode = Role.RoleCode;
            IDvTable dvt = entityfactory.CreateDriveTable(user);
            dvt.WhereClause("RoleCode", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            List<IUser> list = this.dh.Convert<IUser>(user.GetType(), ds);
            return list;
        }
        /// <summary>
        /// 根据用户名称查询用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public virtual IUser QueryUserName(string UserName)
        {　
            IUser user = entityfactory.CreateEntityInstance<IUser>();
            IDvTable dvt = entityfactory.CreateDriveTable(user);
            user.UserName = UserName;
            dvt.WhereClause("UserName", Operator.Deng, LinkOperator.nul); 
            DataSet ds = dvt.Select();
            user = this.dh.Convert<IUser>(user.GetType(), ds, 0);
            return user;

        }  
        /// <summary>
        /// 根据用户编码查询用户
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public virtual IUser QueryUserCode(long UserCode)
        { 
            IUser user = entityfactory.CreateEntityInstance<IUser>();
            IDvTable dvt = entityfactory.CreateDriveTable(user);
            user.UserCode = UserCode;
            dvt.WhereClause("UserCode", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            DataHelper dte = new DataHelper();
            List<object> userlist = dte.ConvertToEntity(user.GetType(), ds);
            if (userlist.Count > 0)
            {
                user = (IUser)userlist[0];
            }
            else
            {
                user = null;
            }
            return user; 
        } 

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public virtual int RemoveUserCode(long UserCode)
        {
            IUser user = entityfactory.CreateEntityInstance<IUser>();
            IDvTable dvt = entityfactory.CreateDriveTable(user);
            user.UserCode = UserCode;
            dvt.WhereClause("UserCode", Operator.Deng, LinkOperator.nul);
            int i = dvt.Delete();
            return i;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="NewUser"></param>
        /// <returns></returns>
        public virtual int AddUser(IUser NewUser)
        {
            IDvTable dvt = entityfactory.CreateDriveTable(NewUser);
            int i = dvt.Insert();
            return i;
        }

       
        /// <summary>
        /// 根据用户名称和密码查询用户
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPassword"></param>
        /// <returns></returns>
        public IUser QueryUserInfo(string UserName, string UserPassword)
        {
            IUser user = entityfactory.CreateEntityInstance<IUser>();
            IDvTable dvt = entityfactory.CreateDriveTable(user);
            user.UserName = UserName;
            user.Userpd = UserPassword;
            dvt.WhereClause("UserName", Operator.Deng, LinkOperator.and);
            dvt.WhereClause("Userpd", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            DataHelper dte = new DataHelper();
            List<object> userlist = dte.ConvertToEntity(user.GetType(), ds);
            if (userlist.Count > 0)
            {
                user = (IUser)userlist[0];
            }
            else
            {
                user = null;
            }
            return user;
        }


        /// <summary>
        /// 根据角色编码查询用户
        /// </summary>
        /// <param name="RoleCode"></param>
        /// <returns></returns>
        public List<IUser> QueryUserRoleCode(long RoleCode)
        {
            IUser user = entityfactory.CreateEntityInstance<IUser>();
            IDvTable dvt = entityfactory.CreateDriveTable(user);
            user.RoleCode = RoleCode; 
            dvt.WhereClause("UserName", Operator.Deng, LinkOperator.nul); 
            DataSet ds = dvt.Select();
            DataHelper dte = new DataHelper();
            List<object> userlist = dte.ConvertToEntity(user.GetType(), ds);
            List<IUser> result = new List<IUser>();
            foreach (object obj in userlist)
            {
                result.Add((IUser)obj);
            }
            return result;
        }

       
        /// <summary>
        /// 根据用户编码更新用户数据
        /// </summary>
        /// <param name="EditUser">要更新数据的用户对象实例</param>
        /// <returns></returns>
        public int Update(IUser EditUser)
        {
            IDvTable dvt = entityfactory.CreateDriveTable(EditUser);
            dvt.WhereClause("UserCode", Operator.Deng, LinkOperator.nul);
            int i = dvt.Update();
            return i;
        }

       
        /// <summary>
        /// 获取可用的新用户编号，获取当前用户编号的最大值然后+1
        /// </summary>
        /// <returns></returns>
        public long GetNewUserCode(IUser User)
        {
            long i = 0;
            DataHelper dh = new DataHelper();
            i = dh.GetMaxField(User, "UserCode",this.entityfactory) + 1;
            
            return i;
        }

        /// <summary>
        /// 批量添加用户
        /// </summary>
        /// <param name="UserList"></param>
        /// <returns></returns>
        public int AddUser(List<IUser> UserList)
        {
            IDvTableBatch dvtb = entityfactory.CreateDriveTableBatch();
            foreach (IUser user in UserList)
            {
                dvtb.AddInsert(user);
            }
            int i = dvtb.Execute();
            return i;
        } 

        /// <summary>
        /// 批量更新用户
        /// </summary>
        /// <param name="UserList"></param>
        /// <returns></returns>
        public int Update(List<IUser> UserList)
        {
            IDvTableBatch dvtb = entityfactory.CreateDriveTableBatch();
            foreach (IUser user in UserList)
            {
                IDvTable dvt = dvtb.CreateDriveTable(user);
                dvt.WhereClause("UserCode", Operator.Deng, LinkOperator.nul);
                dvtb.AddUpdate(dvt);
            }
            int i = dvtb.Execute();
            return i;
        }


        #endregion
         
        #region 单位

        /// <summary>
        /// 查询所有单位
        /// </summary>
        /// <returns></returns>
        public List<IUnits> QueryUnits()
        {
            IUnits nit = entityfactory.CreateEntityInstance<IUnits>();
            IDvTable dvt = entityfactory.CreateDriveTable(nit);
            DataSet ds=dvt.Select();
            List<IUnits> uitlist = this.dh.Convert<IUnits>(nit.GetType(), ds);
            return uitlist;
        }

        /// <summary>
        /// 查询所有单位名称
        /// </summary>
        /// <returns></returns>
        public List<string> QueryUnitName()
        {
            List<IUnits> list = this.QueryUnits();
            List<string> namelist = new List<string>();
            foreach (IUnits uit in list)
            {
                namelist.Add(uit.UnitName);
            }
            return namelist;
        }

        /// <summary>
        /// 根据单位名称查询单位
        /// </summary>
        /// <param name="UnitName"></param>
        /// <returns></returns>
        public IUnits QueryUnits(string UnitName)
        {
            IUnits uit = entityfactory.CreateEntityInstance<IUnits>();
            IDvTable dvt = entityfactory.CreateDriveTable(uit);
            uit.UnitName = UnitName;
            dvt.WhereClause("UnitName", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            uit = this.dh.Convert<IUnits>(uit.GetType(), ds, 0);
            return uit;
        }

        /// <summary>
        /// 添加单位
        /// </summary>
        /// <param name="Units"></param>
        /// <returns></returns>
        public int AddUnits(IUnits Units)
        {
            IDvTable dvt = entityfactory.CreateDriveTable(Units);
            int i = dvt.Insert();
            return i;
        }

        /// <summary>
        /// 移除单位
        /// </summary>
        /// <param name="UnitName"></param>
        /// <returns></returns>
        public int RemoveUnits(string UnitName)
        {
            IUnits nit = entityfactory.CreateEntityInstance<IUnits>();
            IDvTable dvt = entityfactory.CreateDriveTable(nit);
            nit.UnitName = UnitName;
            dvt.WhereClause("UnitName", Operator.Deng, LinkOperator.nul);
            int i = dvt.Delete();
            return i;
        }

        /// <summary>
        /// 更新单位
        /// </summary>
        /// <param name="Units"></param>
        /// <returns></returns>
        public int UpdateUnits(IUnits Units)
        {
            IDvTable dvt = entityfactory.CreateDriveTable(Units);
            dvt.WhereClause("UnitCode", Operator.Deng, LinkOperator.nul);
            int i = dvt.Update();
            return i;
        }

        /// <summary>
        /// 获取新的可用的单位编码
        /// </summary>
        /// <param name="Unit"></param>
        /// <returns></returns>
        public long GetNewUnitsCode(IUnits Unit)
        {
            long i = 0;
            DataHelper dh = new DataHelper();
            i = dh.GetMaxField(Unit, "UnitCode",this.entityfactory) + 1; 
            return i;
        }

        /// <summary>
        /// 根据单位编码查询单位
        /// </summary>
        /// <param name="UnitCode"></param>
        /// <returns></returns>
        public IUnits QueryUnitsForCode(long UnitCode)
        {
            IUnits uit = entityfactory.CreateEntityInstance<IUnits>();
            IDvTable dvt = entityfactory.CreateDriveTable(uit);
            uit.UnitCode = UnitCode;
            dvt.WhereClause("UnitCode", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            uit = this.dh.Convert<IUnits>(uit.GetType(), ds, 0);
            return uit;
        }

        #endregion
 
        #region 角色
        /// <summary>
        /// 根据角色名称查询角色
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        /// <returns></returns>
        public IRole QueryRole(string RoleName)
        {
            IRole role = entityfactory.CreateEntityInstance<IRole>();
            IDvTable dvt = entityfactory.CreateDriveTable(role);
            role.RoleName = RoleName;
            dvt.WhereClause("RoleName", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            role = this.dh.Convert<IRole>(role.GetType(), ds, 0);
            return role;
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public int UpdateRole(IRole Role)
        {
            IDvTable dvt = entityfactory.CreateDriveTable(Role);
            dvt.WhereClause("RoleCode", Operator.Deng, LinkOperator.nul);
            int i = dvt.Update();
            return i;
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public int AddRole(IRole Role)
        {
            IDvTable dvt = entityfactory.CreateDriveTable(Role);
            int i = dvt.Insert();
            return i; 
        }

        /// <summary>
        /// 移除角色
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public int RemoveRole(string RoleName)
        {
            IRole role = entityfactory.CreateEntityInstance<IRole>();
            IDvTable dvt = entityfactory.CreateDriveTable(role);
            role.RoleName = RoleName;
            dvt.WhereClause("RoleName", Operator.Deng, LinkOperator.nul);
            int i = dvt.Delete();
            return i;
        }

        /// <summary>
        /// 获取新的可用的单位编码
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public long GetNewRoleCode(IRole Role)
        {
            DataHelper dh = new DataHelper();
            long i = 0;
            i =dh.GetMaxField(Role, "RoleCode",this.entityfactory) + 1;
            return i;
        }

        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns></returns>
        public List<IRole> QueryRole()
        {
            IRole role = entityfactory.CreateEntityInstance<IRole>();
            IDvTable dvt = entityfactory.CreateDriveTable(role);
            DataSet ds = dvt.Select();
            List<IRole> list = this.dh.Convert<IRole>(role.GetType(), ds);
            return list;
        }
        /// <summary>
        /// 根据角色编码查询角色
        /// </summary>
        /// <param name="RoleCode">角色编码</param>
        /// <returns></returns>
        public IRole QueryRoleForCode(long RoleCode)
        {
            IRole role = entityfactory.CreateEntityInstance<IRole>();
            IDvTable dvt = entityfactory.CreateDriveTable(role);
            role.RoleCode = RoleCode;
            dvt.WhereClause("RoleCode", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            role = this.dh.Convert<IRole>(role.GetType(), ds, 0);
            return role;
        }

        #endregion

        #region 权限类型 
        ///// <summary>
        ///// 添加权限类型
        ///// </summary>
        ///// <param name="AuthType"></param>
        ///// <returns></returns>
        //public int AddAuthType(IAuthType AuthType)
        //{
        //    IDvTable dvt = entityfactory.CreateDriveTable(AuthType);
        //    int i = dvt.Insert();
        //    return i; 
        //}
        ///// <summary>
        ///// 删除权限类型
        ///// </summary>
        ///// <param name="AuthCode"></param>
        ///// <returns></returns>
        //public int RemoveAuthType(string AuthCode)
        //{
        //    IAuthType atype = entityfactory.CreateEntityInstance<IAuthType>();
        //    IDvTable dvt = entityfactory.CreateDriveTable(atype);
        //    atype.AuthCode = AuthCode;
        //    dvt.WhereClause("AuthCode", Operator.Deng, LinkOperator.nul);
        //    int i = dvt.Delete();
        //    return i;
        //}
        ///// <summary>
        ///// 获取新的权限类型编码
        ///// </summary>
        ///// <param name="AuthType"></param>
        ///// <returns></returns>
        //public int GetNewAuthTypeCode(IAuthType AuthType)
        //{
        //    int i = 0;
        //    i = GetMaxField(AuthType, "AuthCode") + 1;
        //    return i;
        //}
        ///// <summary>
        ///// 查询所有权限类型
        ///// </summary>
        ///// <returns></returns>
        //public List<IAuthType> QueryAuthType()
        //{
        //    IAuthType atype = entityfactory.CreateEntityInstance<IAuthType>();
        //    IDvTable dvt = entityfactory.CreateDriveTable(atype);
        //    DataSet ds = dvt.Select();
        //    List<IAuthType> list = Convert<IAuthType>(atype.GetType(), ds);
        //    return list;
        //}
        ///// <summary>
        ///// 根据角色名称查询角色
        ///// </summary>
        ///// <param name="AuthName">角色名称</param>
        ///// <returns></returns>
        //public IAuthType QueryAuthType(string AuthName)
        //{
        //    IAuthType atype = entityfactory.CreateEntityInstance<IAuthType>();
        //    IDvTable dvt = entityfactory.CreateDriveTable(atype);
        //    atype.AuthName = AuthName;
        //    dvt.WhereClause("AuthName", Operator.Deng, LinkOperator.nul);
        //    DataSet ds = dvt.Select();
        //    atype = this.Convert<IAuthType>(atype.GetType(), ds, 0);
        //    return atype;
        //}
        ///// <summary>
        ///// 更新权限类型
        ///// </summary>
        ///// <param name="AuthType"></param>
        ///// <returns></returns>
        //public int UpdateAuthType(IAuthType AuthType)
        //{
        //    IDvTable dvt = entityfactory.CreateDriveTable(AuthType);
        //    dvt.WhereClause("AuthCode", Operator.Deng, LinkOperator.nul);
        //    int i = dvt.Update();
        //    return i;
        //}

        #endregion

        #region 权限控制项 
         
        /// <summary>
        /// 获取新的权限控制项流水码
        /// </summary>
        /// <param name="AuthCtrl"></param>
        /// <returns></returns>
        public long GetNewAuthCtrlCode(IAuthControl AuthCtrl)
        {
            DataHelper dh = new DataHelper();
            long i = 0;
            i = dh.GetMaxField(AuthCtrl,"RowCode",this.entityfactory) + 1;
            return i;
        } 
        /// <summary>
        /// 添加权限控制项
        /// </summary>
        /// <param name="AuthCtrl"></param>
        /// <returns></returns>
        public int AddAuthCtrl(IAuthControl AuthCtrl)
        {
            IDvTable dvt = entityfactory.CreateDriveTable(AuthCtrl);
            int i = dvt.Insert();
            return i; 
        }

        /// <summary>
        /// 更新权限项目
        /// </summary>
        /// <param name="AuthCtrl"></param>
        /// <returns></returns>
        public int UpdateAuthCtrl(IAuthControl AuthCtrl)
        {
            IDvTable dvt = entityfactory.CreateDriveTable(AuthCtrl);
            dvt.WhereClause("RowCode", Operator.Deng, LinkOperator.nul);
            int i = dvt.Update();
            return i;
        }

        /// <summary>
        /// 根据角色名称查询权限控制项
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public List<IAuthControl> QueryAuthCtrl(IRole Role)
        {
            IAuthControl actrl = entityfactory.CreateEntityInstance<IAuthControl>();
            IDvTable dvt = entityfactory.CreateDriveTable(actrl);
            actrl.RoleCode = Role.RoleCode;
            dvt.WhereClause("RoleCode", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            List<IAuthControl> list = this.dh.Convert<IAuthControl>(actrl.GetType(), ds);
            return list;
        }

        /// <summary>
        /// 根据权限类型名称查询权限控制项
        /// </summary>
        /// <param name="AuthType"></param>
        /// <returns></returns>
        public List<IAuthControl> QueryAuthCtrl(AuthType AuthType)
        {
            IAuthControl actrl = entityfactory.CreateEntityInstance<IAuthControl>();
            IDvTable dvt = entityfactory.CreateDriveTable(actrl);
            actrl.AuthCode =long.Parse(Enum.Parse(typeof(AuthType), AuthType.ToString()).ToString());
            DataSet ds = dvt.Select();
            List<IAuthControl> list = this.dh.Convert<IAuthControl>(actrl.GetType(), ds);
            return list;
        } 
        /// <summary>
        /// 根据菜单查询权限控制项
        /// </summary>
        /// <param name="Menu"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public IAuthControl QueryAuthCtrl(IMenu Menu,IRole Role)
        {
            IAuthControl actrl = entityfactory.CreateEntityInstance<IAuthControl>();
            IDvTable dvt = entityfactory.CreateDriveTable(actrl);
            actrl.FItemCode = Menu.MENUCODE.ToString();
            actrl.RoleCode = Role.RoleCode; 
            dvt.WhereClause("FItemCode", Operator.Deng, LinkOperator.and);
            dvt.WhereClause("RoleCode", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            actrl = this.dh.Convert<IAuthControl>(actrl.GetType(), ds, 0);
            return actrl;
        }
        /// <summary>
        /// 查询所有权限控制项
        /// </summary>
        /// <returns></returns>
        public List<IAuthControl> QueryAuthCtrl()
        {
            IAuthControl actrl = entityfactory.CreateEntityInstance<IAuthControl>();
            IDvTable dvt = entityfactory.CreateDriveTable(actrl);
            DataSet ds = dvt.Select();
            List<IAuthControl> list = this.dh.Convert<IAuthControl>(actrl.GetType(), ds);
            return list;
        }
 
        /// <summary>
        /// 移除权限控制项
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public int RemoveAuthCtrl(IRole Role)
        { 
            IAuthControl auth = entityfactory.CreateEntityInstance<IAuthControl>();
            auth.RoleCode = Role.RoleCode;
            IDvTable dvt = entityfactory.CreateDriveTable(auth);
            dvt.WhereClause("RoleCode", Operator.Deng, LinkOperator.nul);
            int i = dvt.Delete();
            return i; 
        }

        /// <summary>
        /// 移除指定用户下的指定权限控制项编码的控制项
        /// </summary>
        /// <param name="Role"></param>
        /// <param name="FItemCode"></param>
        /// <returns></returns>
        public int RemoveAuthCtrl(IRole Role, string FItemCode)
        {
            IAuthControl auth = entityfactory.CreateEntityInstance<IAuthControl>();
            auth.RoleCode = Role.RoleCode;
            auth.FItemCode = FItemCode;
            IDvTable dvt = entityfactory.CreateDriveTable(auth);
            dvt.WhereClause("FItemCode", Operator.Deng, LinkOperator.and);
            dvt.WhereClause("RoleCode", Operator.Deng, LinkOperator.nul);
            int i = dvt.Delete();
            return i; 
        }
 
        /// <summary>
        /// 根据权限项和角色查询权限控制项
        /// </summary>
        /// <param name="AuthItem"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public IAuthControl QueryAuthCtrl(IAuthItem AuthItem, IRole Role)
        {
            IAuthControl actrl = entityfactory.CreateEntityInstance<IAuthControl>();
            IDvTable dvt = entityfactory.CreateDriveTable(actrl);
            actrl.FItemCode = AuthItem.AuthItemCode.ToString();
            actrl.RoleCode = Role.RoleCode;
            dvt.WhereClause("FItemCode", Operator.Deng, LinkOperator.and);
            dvt.WhereClause("RoleCode", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            actrl = this.dh.Convert<IAuthControl>(actrl.GetType(), ds, 0);
            return actrl;
        }
        /// <summary>
        /// 移除指定权限项编码的控制项
        /// </summary>
        /// <param name="FItemCode"></param>
        /// <returns></returns>
        public int RemoveAuthCtrl(string FItemCode)
        {
            IAuthControl auth = entityfactory.CreateEntityInstance<IAuthControl>();
            auth.FItemCode = FItemCode;
            IDvTable dvt = entityfactory.CreateDriveTable(auth);
            dvt.WhereClause("FItemCode", Operator.Deng, LinkOperator.nul);
            int i = dvt.Delete();
            return i; 
        }
        #endregion 

        #region 菜单


        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns></returns>
        public int AddMenu(IMenu Menu)
        {
            IDvTable dvt = entityfactory.CreateDriveTable(Menu);
            int i = dvt.Insert();
            return i; 
        }
        /// <summary>
        /// 移除菜单
        /// </summary>
        /// <param name="MenuCode"></param>
        /// <returns></returns>
        public int RemoveMenu(string MenuCode)
        {
            IMenu menu = entityfactory.CreateEntityInstance<IMenu>();
            IDvTable dvt = entityfactory.CreateDriveTable(menu);
            menu.MENUCODE = MenuCode;
            dvt.WhereClause("MENUCODE", Operator.Deng, LinkOperator.nul);
            int i = dvt.Delete();
            return i;
        }
        /// <summary>
        /// 根据菜单编码更新数据
        /// </summary> 
        /// <returns></returns>
        public int UpdateMenu(IMenu Menu)
        {
            IDvTable dvt = entityfactory.CreateDriveTable(Menu);
            dvt.WhereClause("MENUCODE", Operator.Deng, LinkOperator.nul);
            int i = dvt.Update();
            return i;
        }
        /// <summary>
        /// 查询菜单
        /// </summary> 
        /// <returns></returns>
        public virtual List<IMenu> QueryMenus()
        {
            DataSet ds = QueryAllSet(); 
            List<IMenu> list=this.dh.Convert<IMenu>( this.entityfactory.CreateEntityInstance<IMenu>().GetType(),ds);
            List < IMenu > result = RefactoringMenu(list);
            return result;
        }
        /// <summary>
        /// 查询菜单
        /// </summary> 
        /// <returns></returns>
        public virtual DataSet QueryAllSet()
        {
            IMenu menu = this.entityfactory.CreateEntityInstance<IMenu>();
            IDvTable dvt = this.entityfactory.CreateDriveTable(menu);
            DataSet ds = dvt.Select();
            return ds;
        }
        /// <summary>
        /// 查询菜单
        /// </summary>
        /// <param name="PerntCode">父菜单编号</param>
        /// <returns></returns>
        public virtual List<IMenu> QuerySubmenu(string PerntCode)
        {
            IMenu menu = this.entityfactory.CreateEntityInstance<IMenu>();
            menu.PARENTCODE = PerntCode;
            IDvTable dvt = this.entityfactory.CreateDriveTable(menu);
            dvt.WhereClause("PARENTCODE", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select(); 
            return this.dh.Convert<IMenu>(menu.GetType(), ds);
        }
        /// <summary>
        /// 查询菜单编码
        /// </summary>
        /// <param name="MenuCode"></param>
        /// <returns></returns>
        public virtual IMenu QueryCode(string MenuCode)
        {
            IMenu menu = this.entityfactory.CreateEntityInstance<IMenu>();
            menu.MENUCODE = MenuCode;
            IDvTable dvt = this.entityfactory.CreateDriveTable(menu);
            dvt.WhereClause("MENUCODE", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            DataHelper dte = new DataHelper();
            return dte.Convert<IMenu>(menu.GetType(), ds, 0); ;
        } 
        /// <summary>
        /// 构造菜单权限项
        /// </summary>
        /// <param name="Menu">菜单</param>
        /// <param name="Role">角色</param>
        /// <param name="AuthType">权限类型</param>
        /// <returns></returns>
        public IAuthControl BuildMenuAuthCtrl(IMenu Menu, IRole Role, AuthType AuthType)
        { 
           return this.BuildMenuAuthCtrl(Menu.MENUCODE,Menu.MENUTITLE,Role.RoleCode,((int)AuthType)); 
        }
        /// <summary>
        /// 构造菜单权限项
        /// </summary>
        /// <param name="MenuCode">菜单编码</param> 
        /// <param name="MenuTitle">菜单标题</param>
        /// <param name="RoleCode">角色编码</param>
        /// <param name="TypeCode">权限类型编码</param>
        /// <returns></returns>
        public IAuthControl BuildMenuAuthCtrl(string MenuCode, string MenuTitle
            , long RoleCode, long TypeCode)
        {
            IAuthControl actrl = this.entityfactory.CreateEntityInstance<IAuthControl>();
            actrl.RoleCode = RoleCode;
            actrl.AuthCode = TypeCode;
            actrl.FItemCode = MenuCode.ToString();
            actrl.FItemName = MenuTitle;
            actrl.RowCode = this.GetNewAuthCtrlCode(actrl);
            return actrl;
        }
        /// <summary>
        /// 根据菜单类型查询菜单
        /// </summary> 
        /// <param name="MType">菜单类型</param>
        /// <returns></returns>
        public List<IMenu> QueryMenus(MenuType MType)
        {
            IMenu menu = entityfactory.CreateEntityInstance<IMenu>();
            IDvTable dvt = entityfactory.CreateDriveTable(menu);
            menu.MENUTYPE = MType.ToString();
            dvt.WhereClause("MENUTYPE", Operator.Deng, LinkOperator.nul); 
            DataSet ds = dvt.Select();
            List<IMenu> list = this.dh.Convert<IMenu>(menu.GetType(), ds);
            return list;
        }
        /// <summary>
        /// 根据角色名和菜单类型查询菜单
        /// </summary>
        /// <param name="Role">角色</param>
        /// <param name="MType">菜单类型</param>
        /// <returns></returns>
        public List<IMenu> QueryMenus(IRole Role, MenuType MType) 
        {
            IMenu menu = entityfactory.CreateEntityInstance<IMenu>();
            menu.MENUTYPE = MType.ToString();
            IAuthControl actrl = entityfactory.CreateEntityInstance<IAuthControl>();
            actrl.RoleCode = Role.RoleCode;
            IDvTable dvt = entityfactory.CreateDriveTable(menu);
            dvt.Join.Entitys.Add(actrl);
            dvt.WhereClause("MENUTYPE", Operator.Deng, LinkOperator.and);
            dvt.WhereClause(actrl, "RoleCode", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            List<IMenu> list = this.dh.Convert<IMenu>(menu.GetType(), ds);
            List<IMenu> result = RefactoringMenu(list);
            return result; 
        } 
        /// <summary>
        /// 根据用户和菜单类型查询菜单
        /// </summary>
        /// <param name="User"></param>
        /// <param name="MType"></param>
        /// <returns></returns>
        public List<IMenu> QueryMenus(IUser User, MenuType MType)
        {
            if (User == null)
            {
                return null;
            }
            IRole role = entityfactory.CreateEntityInstance<IRole>();
            role.RoleCode = User.RoleCode;  
            return QueryMenus(role,MType); 
        }
        /// <summary>
        /// 获取新的菜单编码 菜单名称加上功能编码加上随机数
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns></returns>
        public string GetNewMenuCode(IMenu Menu)
        {
            long i = 0; 
            DataHelper dh = new DataHelper();
            i = dh.GetMaxField(Menu, "MENUCODE", this.entityfactory) + 1;
            return i.ToString();
        } 
        /// <summary>
        /// 重构菜单顺序
        /// </summary>
        /// <param name="InMenus"></param>
        protected virtual List<IMenu> RefactoringMenu(List<IMenu> InMenus)
        {
            //先判断从属关系 再判断序号 
            List<IMenu> result = new List<IMenu>();
            foreach (IMenu m in InMenus)
            {
                if (m.PARENTCODE == "0")
                {
                    result.Add(m); 
                } 
            }
            result.Sort(SortOrderIndex);
            Dictionary<IMenu, List<IMenu>> tmelist = new Dictionary<IMenu, List<IMenu>>();
            foreach (IMenu m in result)
            {
                List<IMenu> childmenu = FindChildMenu(m.MENUCODE, InMenus);
                tmelist.Add(m,childmenu); 
            }
            foreach(IMenu tmpm in tmelist.Keys)
            {
                result.InsertRange(result.IndexOf(tmpm)+1, tmelist[tmpm]);
            }
            return result;
        }

        /// <summary>
        /// 查找子菜单
        /// </summary> 
        protected virtual List<IMenu> FindChildMenu(string FatherMenuCode, List<IMenu> InMenus)
        {
            List<IMenu> result = new List<IMenu>();
            foreach (IMenu m in InMenus)
            {
                if (m.PARENTCODE == FatherMenuCode)
                {
                    result.Add(m);
                    //List<IMenu> childmenu = FindChildMenu(m.MENUCODE, InMenus);
                    //childmenu.Sort(SortOrderIndex);
                    //result.InsertRange(result.Count, childmenu);
                }
            } 
            result.Sort(SortOrderIndex);
            Dictionary<IMenu, List<IMenu>> tmelist = new Dictionary<IMenu, List<IMenu>>();
            foreach (IMenu m in result)
            {
                List<IMenu> childmenu = FindChildMenu(m.MENUCODE, InMenus);
                tmelist.Add(m, childmenu);
            }
            foreach (IMenu tmpm in tmelist.Keys)
            {
                result.InsertRange(result.IndexOf(tmpm) + 1, tmelist[tmpm]);
            }
            return result;
        }

        /// <summary>
        /// 菜单排序规则 1对比2
        /// </summary>
        /// <param name="Menu1"></param>
        /// <param name="Menu2"></param>
        /// <returns></returns>
        protected virtual   int SortOrderIndex(IMenu Menu1, IMenu Menu2)
        {
            return Menu1.OrderIndex.CompareTo(Menu2.OrderIndex);
        } 
       
        /// <summary>
        /// 根据菜单类全名查询菜单
        /// </summary>
        /// <param name="FullClassName"></param>
        /// <returns></returns>
        public IMenu QueryMenu(string FullClassName)
        {
            IMenu menu = entityfactory.CreateEntityInstance<IMenu>();
            IDvTable dvt = entityfactory.CreateDriveTable(menu);
            menu.FULLCLASSNAME = FullClassName;
            dvt.WhereClause("FULLCLASSNAME", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select(); 
            DataHelper dte = new DataHelper();
            return dte.Convert<IMenu>(menu.GetType(), ds, 0); 
        }
 

        #endregion

        #region 权限项 

         /// <summary>
         /// 添加权限项
         /// </summary>
         /// <param name="AuthItem"></param>
         /// <returns></returns>
         public virtual  int AddAuthItem(IAuthItem AuthItem)
        {
            IDvTable dvt = entityfactory.CreateDriveTable(AuthItem);
            int i = dvt.Insert();
            return i; 
        }
        /// <summary>
        /// 移除权限项
        /// </summary>
        /// <param name="AuthItemCode"></param>
        /// <returns></returns>
         public virtual  int RemoveAuthItem(string AuthItemCode)
        {
            IAuthItem item = entityfactory.CreateEntityInstance<IAuthItem>();
            IDvTable dvt = entityfactory.CreateDriveTable(item);
            item.AuthItemCode = AuthItemCode;
            dvt.WhereClause("AuthItemCode", Operator.Deng, LinkOperator.nul);
            int i = dvt.Delete();
            return i;
        }
        /// <summary>
        /// 查询所有权限项
        /// </summary>
        /// <returns></returns>
         public virtual  List<IAuthItem> QueryAuthItem()
        {
            IAuthItem item = this.entityfactory.CreateEntityInstance<IAuthItem>();
            IDvTable dvt = this.entityfactory.CreateDriveTable(item);
            DataSet ds = dvt.Select();
            return this.dh.Convert<IAuthItem>(this.entityfactory.CreateEntityInstance<IAuthItem>().GetType(), ds);
        }
        /// <summary>
        /// 获取新的权限项编码
        /// </summary>
         /// <param name="AuthItemCode"></param>
        /// <returns></returns>
        public virtual bool IsExistAuthItemCode(string AuthItemCode)
        {
            bool result = true;
            if (QueryAuthItem(AuthItemCode) == null)
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 根据指定的权限项编码查询权限项对象
        /// </summary>
        /// <param name="AuthItemCode"></param>
        /// <returns></returns>
        public virtual IAuthItem QueryAuthItem(string AuthItemCode)
        {
            IAuthItem item = this.entityfactory.CreateEntityInstance<IAuthItem>();
            item.AuthItemCode = AuthItemCode;
            IDvTable dvt = this.entityfactory.CreateDriveTable(item);
            dvt.WhereClause("AuthItemCode", Operator.Deng, LinkOperator.nul);
            DataSet ds = dvt.Select();
            DataHelper dte = new DataHelper();
            return dte.Convert<IAuthItem>(item.GetType(), ds, 0); ;
        }

        /// <summary>
        /// 根据角色查询权限项 
        /// 角色关联权限控制项 权限控制项关联权限项
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public List<IAuthItem> QueryAuthItem(IRole Role)
        {
            IAuthItem item=this.entityfactory.CreateEntityInstance<IAuthItem>();
            IAuthControl actrl = entityfactory.CreateEntityInstance<IAuthControl>();
            actrl.RoleCode = Role.RoleCode;
            IDvTable dvt = entityfactory.CreateDriveTable(item);
            dvt.Join.Entitys.Add(actrl);
            dvt.WhereClause(actrl, "RoleCode", Operator.Deng, LinkOperator.nul); 
            DataSet ds = dvt.Select();
            List<IAuthItem> list = this.dh.Convert<IAuthItem>(item.GetType(), ds);
            return list;
        }
 
        #endregion

 


        #region IManager 成员


        /// <summary>
        /// 是否缺少菜单权限
        /// 当用户角色权限大于目标角色时 false
        /// 当用户角色权限小于目标角色时 true 即缺少权限
        /// </summary>
        public virtual bool IsLackRoleMenuAuth(IRole UserRole, IRole TargetRole, IMenu Menu)
        {
            bool result = false;
            //IRole userRole = manager.QueryRoleForCode(this.MainForm.SysState.LogonUser.RoleCode);
            //IMenu menu = this.manager.QueryMenu(this.GetType().BaseType.FullName);
            IAuthControl userAuth = this.QueryAuthCtrl(Menu, UserRole);
            IAuthControl targetAuth = this.QueryAuthCtrl(Menu, TargetRole);
            if (userAuth == null)
            {
                //缺少权限
                return true;
            }
            if(targetAuth == null)
            {
                return false;
            }
            if (userAuth.AuthCode < targetAuth.AuthCode)
            {
                //缺少权限
                result = true;
            }
            return result;
        }
 
        #endregion
    }
}
