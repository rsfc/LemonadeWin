using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace Lemonade.Frame.Manage.Base
{ 
    /// <summary>
    /// �˵�����
    /// </summary>
    public enum MenuType : int
    {
        /// <summary>
        /// C/S������ C/S�ͻ��˵Ĳ˵����ݼ�¼
        /// </summary>
        [Description("CS")]
        CS = 0,
        /// <summary>
        /// B/S������B/S�ͻ��˵Ĳ˵����ݼ�¼
        /// </summary>
        [Description("BS")]
        BS = 1, 

    }
}
