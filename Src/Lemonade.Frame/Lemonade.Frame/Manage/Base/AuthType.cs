using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// Ȩ������
    /// </summary>
    public enum AuthType : int
    {
        /// <summary>
        /// ֻ��
        /// </summary>
        [Description("Readonly")]
        Readonly = 0,
        /// <summary>
        /// ���޸�
        /// </summary>
        [Description("Modify")]
        Modify = 1,
        /// <summary>
        /// ����
        /// </summary>
        [Description("Admin")]
        Admin = 2,



    }
}
