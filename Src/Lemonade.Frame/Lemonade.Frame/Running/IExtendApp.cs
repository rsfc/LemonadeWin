using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.Running
{
    /// <summary>
    /// ��չ����ӿ�
    /// </summary>
    public interface IExtendApp:IModule
    {  
         
        ///// <summary>
        ///// ����
        ///// </summary>
        //void Launch();
        /// <summary>
        /// �Ƿ񽡿�
        /// </summary>
        bool IsHealth { get; set; }
    }
}
