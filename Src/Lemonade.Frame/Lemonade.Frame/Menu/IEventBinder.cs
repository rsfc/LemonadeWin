using System;
using System.Collections.Generic;
using System.Text; 
namespace Lemonade.Frame.Menu
{
    /// <summary>
    /// �¼�����
    /// </summary>
    public  interface IEventBinder
    {
        
        /// <summary>
        /// ��
        /// </summary>
        /// <param name="Item"></param>
        void Binder(PtMenuItem Item);
    }
}
