using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.DAL;
using System.Data; 
namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// �����߽ӿ� 
    /// </summary>
    public interface IManager
    {
        
        /// <summary>
        /// ���ݿ������
        /// </summary>
        IDBInfo DbHelper { get;set;}

        #region �û�

        /// <summary>
        /// �����û����Ʋ�ѯ�û�
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        IUser QueryUserName(string UserName);
        /// <summary>
        /// �����û������ѯ�û�
        /// </summary>
        /// <param name="UserCode">�û�����</param>
        /// <returns></returns>
        IUser QueryUserCode(long UserCode);
        /// <summary>
        /// ��ѯ�����û�
        /// </summary>
        /// <returns></returns>
        List<IUser> QueryUser();
        /// <summary>
        /// ���ݵ�λ��ѯ�û�
        /// </summary>
        /// <param name="Units"></param>
        /// <returns></returns>
        List<IUser> QueryUser(IUnits Units);
        /// <summary>
        /// ���ݽ�ɫ��ѯ�û�
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        List<IUser> QueryUser(IRole Role);
        /// <summary>
        /// �����û����ƺ������ѯ�û�
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPassword"></param>
        /// <returns></returns>
        IUser QueryUserInfo(string UserName,string UserPassword);
        /// <summary>
        /// ���ݽ�ɫ�����ѯ�û�
        /// </summary>
        /// <param name="RoleCode"></param>
        /// <returns></returns>
        List<IUser> QueryUserRoleCode(long RoleCode); 
        /// <summary>
        /// �����û�����ɾ���û�
        /// </summary>
        /// <returns></returns>
        int RemoveUserCode(long UserCode);
        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="NewUser"></param>
        /// <returns></returns>
        int AddUser(IUser NewUser); 
        ///// <summary>
        ///// �����û�����ʵ��
        ///// </summary>
        ///// <returns></returns>
        //IUser CreateInstance();
        /// <summary>
        /// �����û���������û�����
        /// </summary>
        /// <param name="EditUser"></param>
        /// <returns></returns>
        int Update(IUser EditUser);
        /// <summary>
        /// ��ȡ�µ��û���ţ���ȡ��ǰ�û���ŵ����ֵȻ��+1
        /// </summary>
        /// <returns></returns>
        long GetNewUserCode(IUser User);
        /// <summary>
        /// ��������û�
        /// </summary>
        /// <param name="UserList"></param>
        /// <returns></returns>
        int AddUser(List<IUser> UserList);
        /// <summary>
        /// ���������û�
        /// </summary>
        /// <param name="UserList"></param>
        /// <returns></returns>
        int Update(List<IUser> UserList);

        #endregion
        
        #region ��λ

        /// <summary>
        /// ��ѯ���е�λ
        /// </summary>
        /// <returns></returns>
        List<IUnits> QueryUnits();
        /// <summary>
        /// ��ѯ���е�λ����
        /// </summary>
        /// <returns></returns>
        List<string> QueryUnitName();
        /// <summary>
        /// ���ݵ�λ���Ʋ�ѯ��λ
        /// </summary>
        /// <param name="UnitName"></param>
        /// <returns></returns>
        IUnits QueryUnits(string UnitName);
        /// <summary>
        /// ���ݵ�λ�����ѯ��λ
        /// </summary>
        /// <param name="UnitCode"></param>
        /// <returns></returns>
        IUnits QueryUnitsForCode(long UnitCode);
        /// <summary>
        /// ��ӵ�λ
        /// </summary>
        /// <param name="Units"></param>
        /// <returns></returns>
        int AddUnits(IUnits Units);
        /// <summary>
        /// �Ƴ���λ
        /// </summary>
        /// <param name="UnitName"></param>
        /// <returns></returns>
        int RemoveUnits(string UnitName);
        /// <summary>
        /// ���µ�λ
        /// </summary>
        /// <param name="Units"></param>
        /// <returns></returns>
        int UpdateUnits(IUnits Units);
        /// <summary>
        /// ��ȡ�µĵ�λ����
        /// </summary>
        /// <param name="Unit"></param>
        /// <returns></returns>
        long GetNewUnitsCode(IUnits Unit);
        
        #endregion

        #region ��ɫ
        /// <summary>
        /// ���½�ɫ
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        int UpdateRole(IRole Role);
        /// <summary>
        /// ��ӽ�ɫ
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        int AddRole(IRole Role);
        /// <summary>
        /// �Ƴ���ɫ
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        int RemoveRole(string RoleName); 

        /// <summary>
        /// ��ȡ�µĵ�λ����
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        long GetNewRoleCode(IRole Role);
        /// <summary>
        /// ��ѯ���н�ɫ
        /// </summary>
        /// <returns></returns>
        List<IRole> QueryRole();
        /// <summary>
        /// ���ݽ�ɫ���Ʋ�ѯ��ɫ
        /// </summary>
        /// <param name="RoleName">��ɫ����</param>
        /// <returns></returns>
        IRole QueryRole(string RoleName);
        /// <summary>
        /// ���ݽ�ɫ�����ѯ��ɫ
        /// </summary>
        /// <param name="RoleCode">��ɫ����</param>
        /// <returns></returns>
        IRole QueryRoleForCode(long RoleCode);
        #endregion

        #region Ȩ������

        /// <summary>
        /// �Ƿ�ȱ�ٲ˵�Ȩ��
        /// ���û���ɫȨ�޴���Ŀ���ɫʱ false
        /// ���û���ɫȨ��С��Ŀ���ɫʱ true ��ȱ��Ȩ��
        /// </summary>
        bool IsLackRoleMenuAuth(IRole UserRole, IRole TargetRole, IMenu Menu);
        ///// <summary>
        ///// ���ݽ�ɫ���Ʋ�ѯ��ɫ
        ///// </summary>
        ///// <param name="AuthName">��ɫ����</param>
        ///// <returns></returns>
        //IAuthType QueryAuthType(string AuthName);
        ///// <summary>
        ///// ����Ȩ������
        ///// </summary>
        ///// <param name="AuthType"></param>
        ///// <returns></returns>
        //int UpdateAuthType(IAuthType AuthType);
        ///// <summary>
        ///// ���Ȩ������
        ///// </summary>
        ///// <param name="AuthType"></param>
        ///// <returns></returns>
        //int AddAuthType(IAuthType AuthType);
        ///// <summary>
        ///// ɾ��Ȩ������
        ///// </summary>
        ///// <param name="AuthCode"></param>
        ///// <returns></returns>
        //int RemoveAuthType(string AuthCode);
        ///// <summary>
        ///// ��ȡ�µ�Ȩ�����ͱ���
        ///// </summary>
        ///// <param name="AuthType"></param>
        ///// <returns></returns>
        //int GetNewAuthTypeCode(IAuthType AuthType);
        ///// <summary>
        ///// ��ѯ����Ȩ������
        ///// </summary>
        ///// <returns></returns>
        //List<IAuthType> QueryAuthType();
         
        #endregion

        #region ͨ�õ�
        /// <summary>
        /// ����ʵ�����ʵ��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T CreateEntityInstance<T>(); 

        #endregion 

        #region Ȩ�޿�����
        /// <summary>
        /// ��ȡ�µ�Ȩ�޿�������ˮ��
        /// </summary>
        /// <param name="AuthCtrl"></param>
        /// <returns></returns>
        long GetNewAuthCtrlCode(IAuthControl AuthCtrl);
        /// <summary>
        /// ���Ȩ�޿�����
        /// </summary>
        /// <param name="AuthCtrl"></param>
        /// <returns></returns>
        int AddAuthCtrl(IAuthControl AuthCtrl); 
        /// <summary>
        /// ����Ȩ����Ŀ
        /// </summary>
        /// <param name="AuthCtrl"></param>
        /// <returns></returns>
        int UpdateAuthCtrl(IAuthControl AuthCtrl); 
        /// <summary>
        /// ���ݽ�ɫ���Ʋ�ѯȨ�޿�����
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        List<IAuthControl> QueryAuthCtrl(IRole Role);
        /// <summary>
        /// ����Ȩ���������Ʋ�ѯȨ�޿�����
        /// </summary>
        /// <param name="AuthType"></param>
        /// <returns></returns>
        List<IAuthControl> QueryAuthCtrl(AuthType AuthType);
        /// <summary>
        /// ��ѯ����Ȩ�޿�����
        /// </summary>
        /// <returns></returns>
        List<IAuthControl> QueryAuthCtrl();
    
        /// <summary>
        /// ���ݲ˵���ѯȨ�޿�����
        /// </summary>
        /// <param name="Menu"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        IAuthControl QueryAuthCtrl(IMenu Menu,IRole Role);
        /// <summary>
        /// ����Ȩ����ͽ�ɫ��ѯȨ�޿�����
        /// </summary>
        /// <param name="AuthItem"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        IAuthControl QueryAuthCtrl(IAuthItem AuthItem, IRole Role);
        ///// <summary>
        ///// �Ƴ�Ȩ�޿�����
        ///// </summary>
        ///// <param name="AuthCode"></param>
        ///// <returns></returns>
        //int RemoveAuthCtrl(long AuthCode);
        /// <summary>
        /// �Ƴ�ָ����ɫ������Ȩ�޿�����
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        int RemoveAuthCtrl(IRole Role);
        /// <summary>
        /// �Ƴ�ָ���û��µ�ָ��Ȩ�޿��������Ŀ�����
        /// </summary>
        /// <param name="Role"></param>
        /// <param name="FItemCode"></param>
        /// <returns></returns>
        int RemoveAuthCtrl(IRole Role, string FItemCode);
        /// <summary>
        /// �Ƴ�ָ��Ȩ�������Ŀ�����
        /// </summary>
        /// <param name="FItemCode"></param>
        /// <returns></returns>
        int RemoveAuthCtrl(string FItemCode);
        #endregion

        #region �˵�
        /// <summary>
        /// ��Ӳ˵�
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns></returns>
        int AddMenu(IMenu Menu);
        /// <summary>
        /// �Ƴ��˵�
        /// </summary>
        /// <param name="MenuCode"></param>
        /// <returns></returns>
        int RemoveMenu(string MenuCode);
        /// <summary>
        /// ����˵�Ȩ����
        /// </summary>
        /// <param name="Menu">�˵�</param>
        /// <param name="Role">��ɫ</param>
        /// <param name="AuthType">Ȩ������</param>
        /// <returns></returns>
        IAuthControl BuildMenuAuthCtrl(IMenu Menu, IRole Role, AuthType AuthType);
        /// <summary>
        /// ����˵�Ȩ����
        /// </summary>
        /// <param name="MenuCode">�˵�����</param>
        /// <param name="MenuTitle">�˵�����</param>
        /// <param name="RoleCode">��ɫ����</param>
        /// <param name="TypeCode">Ȩ�����ͱ���</param>
        /// <returns></returns>
        IAuthControl BuildMenuAuthCtrl(string MenuCode, string MenuTitle
            , long RoleCode, long TypeCode);
        /// <summary>
        /// ���ݲ˵����Ͳ�ѯ�˵�
        /// </summary>
        /// <param name="MType">�˵�����</param>
        /// <returns></returns>
        List<IMenu> QueryMenus(MenuType MType);
        /// <summary>
        /// ���ݽ�ɫ�Ͳ˵����Ͳ�ѯ�˵�
        /// </summary>
        /// <param name="Role">��ɫ</param>
        /// <param name="MType">�˵�����</param>
        /// <returns></returns>
        List<IMenu> QueryMenus(IRole Role,MenuType MType);
        /// <summary>
        /// �����û��Ͳ˵����Ͳ�ѯ�˵�
        /// </summary>
        /// <param name="User"></param>
        /// <param name="MType"></param>
        /// <returns></returns>
        List<IMenu> QueryMenus(IUser User, MenuType MType);
        /// <summary>
        /// ��ȡ�µĲ˵����� 
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns></returns>
        string GetNewMenuCode(IMenu Menu);
        /// <summary>
        /// ���²˵���
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns></returns>
        int UpdateMenu(IMenu Menu);
        /// <summary>
        /// ��ѯ���в˵�
        /// </summary>
        /// <returns></returns>
        List<IMenu> QueryMenus();
        /// <summary>
        /// ��ѯ�Ӳ˵�
        /// </summary>
        /// <param name="PerntCode">���˵����</param>
        /// <returns></returns>
        List<IMenu> QuerySubmenu(string PerntCode);
        /// <summary>
        /// ���ݲ˵������ѯ�˵�
        /// </summary>
        /// <param name="MenuCode"></param>
        /// <returns></returns>
        IMenu QueryCode(string MenuCode);
        /// <summary>
        /// ���ݲ˵���ȫ����ѯ�˵�
        /// </summary>
        /// <param name="FullClassName"></param>
        /// <returns></returns>
        IMenu QueryMenu(string FullClassName);
        /// <summary>
        /// ��ѯ���в˵���ȡdataset
        /// </summary>
        /// <returns></returns>
        DataSet QueryAllSet();
        #endregion

        #region Ȩ����
        /// <summary>
        /// ���Ȩ����Ŀ
        /// </summary>
        /// <param name="AuthItem"></param>
        /// <returns></returns>
        int AddAuthItem(IAuthItem AuthItem);
        /// <summary>
        /// �Ƴ�Ȩ����
        /// </summary>
        /// <param name="AuthItemCode"></param>
        /// <returns></returns>
        int RemoveAuthItem(string AuthItemCode);
        /// <summary>
        /// ��ѯ����Ȩ����
        /// </summary>
        /// <returns></returns>
        List<IAuthItem> QueryAuthItem();
        /// <summary>
        /// ����ָ����Ȩ��������ѯȨ�������
        /// </summary>
        /// <param name="AuthItemCode"></param>
        /// <returns></returns>
        IAuthItem QueryAuthItem(string AuthItemCode);
        /// <summary>
        /// ���ݽ�ɫ��ѯȨ����
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        List<IAuthItem> QueryAuthItem(IRole Role);
        /// <summary>
        /// ��֤�µ�Ȩ������ˮ�� ����Ѿ������򷵻�true �������򷵻�false
        /// </summary>
        /// <param name="AuthItemCode"></param>
        /// <returns></returns>
        bool IsExistAuthItemCode(string AuthItemCode);

        #endregion

       

        
    }
}
