using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// ��������ϵͳģ��ʱ������Ϣ�ӿ�
    /// </summary>
    public interface ILoadDisplay : Lemonade.Frame.Design.IObserver
    {
        /// <summary>
        /// ��ɼ��ع���
        /// </summary>
        void Complete(); 
    }
}
