using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// Ȩ����Ŀ �ǲ˵���Ȩ����Ŀ
    /// ������ķ�ʽ�� �˵���ģ�� ������Ȩ����Ŀ Ȩ����Ŀ������������ ���������������
    /// </summary>
    public interface IAuthItem : Protein.Enzyme.DAL.IEntityBase
    {
        /// <summary>
        /// Ȩ��������
        /// </summary>
        string AuthItemName { get;set;}
        /// <summary>
        /// Ȩ�������
        /// </summary>
        string AuthItemCode { get;set;}
    }
}
