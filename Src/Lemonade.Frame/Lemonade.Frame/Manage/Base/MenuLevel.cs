using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace Lemonade.Frame.Manage.Base
{
    /// <summary>
    /// �˵�����  �Ƿ����Ӳ˵�
    /// </summary>
    public enum MenuLevel
    {

        /// <summary>
        /// ���Ӳ˵�
        /// </summary>
        [Description("�����Ӳ˵�")]
        BeSubmenu = 0,
        /// <summary>
        /// �������Ӳ˵�
        /// </summary>
        [Description("�������Ӳ˵�")]
        NotBeSubmenu = 1, 

    }
}
