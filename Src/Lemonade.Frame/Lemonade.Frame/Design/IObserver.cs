using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.Design
{
    /// <summary>
    /// �۲��߽ӿ�
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// ֪ͨ
        /// </summary>
        /// <param name="Content">֪ͨ����</param>
        void Notify(object Content);
    }
}
